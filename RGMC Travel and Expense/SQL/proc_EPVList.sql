ALTER PROCEDURE proc_EPVList
(
	@chargeToId INT,
	@employeeId INT,
	@transactionTypeId INT,
	@startDate DATE,
	@endDate DATE,
	@statusId INT,
	@headEmployeeId INT
)
AS

--DECLARE @chargeToId INT = -1
--DECLARE @employeeId INT = -1
--DECLARE @transactionTypeId INT = -1
--DECLARE @startDate DATE = '1/17/2017'
--DECLARE @endDate DATE = '11/17/2018'
--DECLARE @statusId INT = -1
--DECLARE @headEmployeeId INT = 95

DECLARE	@userType VARCHAR(50)

SELECT @userType = (SELECT STUFF((SELECT ' | ' + groupCode 
FROM SystemUser SU INNER JOIN SystemMember SM ON SM.secCode = SU.secCode 
WHERE employeeId = @headEmployeeId 
FOR XML PATH(''), TYPE  
     ).value('.', 'NVARCHAR(MAX)') 
, 1, 1, ''))  
FROM SystemMember 

IF NOT OBJECT_ID ('tempdb..#tmpEmployee') IS NULL DROP TABLE #tmpEmployee
	SELECT 
		CAST(-1 AS INT) AS employeeId,
		CAST('' AS VARCHAR(50)) AS secCode,
		CAST('' AS VARCHAR(200)) AS name
	INTO #tmpEmployee

	TRUNCATE TABLE #tmpEmployee

IF CHARINDEX('ALL', @userType) > 0 
	OR CHARINDEX('ACTG', @userType) > 0
	OR CHARINDEX('TREASURY', @userType) > 0
	OR CHARINDEX('APPROVER', @userType) > 0 
	OR CHARINDEX('ACTG2', @userType) > 0 
    OR CHARINDEX('ADMINISTRATOR', @userType) > 0 
BEGIN
	INSERT INTO #tmpEmployee(employeeId, secCode, name)
	SELECT employeeId, secCode, name
	FROM SystemUser 
END
ELSE 
BEGIN
	DECLARE @costCenterCode VARCHAR(50)

	SELECT @costCenterCode = costCenterCode 
	FROM CostCenter
	WHERE employeeId = @headEmployeeId
	
	IF @costCenterCode IS NULL
	BEGIN
		INSERT INTO #tmpEmployee(employeeId, secCode, name)
		SELECT employeeId, secCode, name
		FROM SystemUser 
		WHERE employeeId = @headEmployeeId 
	END
	ELSE
	BEGIN
	
		INSERT INTO #tmpEmployee(employeeId, secCode, name)
		SELECT employeeId, SU.secCode, name
		FROM SystemUser SU
			INNER JOIN SystemMember SM ON SM.secCode = SU.secCode
		WHERE groupCode = @costCenterCode			
	END
END

BEGIN

SELECT E.epvId 'epvId', E.chargeToId 'chargeToId', E.epvStatusId 'epvStatusId',
RS.name 'Status', E.formNumber 'EPV #', transactionTypeName 'Transaction Type',
E.requestDate 'Request Date', totalExpense 'Total Expense', CA.caNumber 'CA #',
CA.caAmount 'CA Amount', E.cashOverUnder 'Cash Under/(Over)',
CONCAT(SU.lastName, ', ', SU.firstName) 'Requested By', 
businessPurposeName 'Business Purpose', E.bpOthers 'Other Details',
MP.modeOfPaymentCode 'Mode of Payment', CT.chargeToName 'Company',
CC.costCenterName 'Department', S.storeName 'Store', 
E.updateDate AS 'Date Last Modified'
FROM EPV E
	INNER JOIN SystemUser SU ON SU.employeeId = E.employeeId
	LEFT JOIN  CashAdvance CA ON CA.caId = E.caId AND CA.chargeToId = E.chargeToId
	INNER JOIN BusinessPurpose BP ON BP.businessPurposeId = E.businessPurposeId
	INNER JOIN TransactionType TT ON TT.transactionTypeId = E.TransactionTypeId
	LEFT JOIN ModeOfPayment MP ON MP.modeOfPaymentId = E.modeOfPaymentId
	INNER JOIN CostCenter CC ON CC.costCenterId = E.costCenterId
	INNER JOIN Stores S ON S.storeId = E.storeId
	INNER JOIN SystemUser reqBy ON reqBy.employeeId = E.employeeId
	INNER JOIN #tmpEmployee tmp ON tmp.employeeId = SU.employeeId
	INNER JOIN EPVStatus RS ON RS.epvStatusId = E.epvStatusId
	INNER JOIN ChargeTo CT ON CT.chargeToId = E.chargeToId
WHERE E.transactionTypeId = CASE WHEN @transactionTypeId = -1 THEN E.transactionTypeId ELSE @transactionTypeId END
AND E.chargeToId like CASE WHEN @chargeToId = -1 THEN E.chargeToId ELSE @chargeToId END
AND E.employeeId = CASE WHEN @employeeId = -1 THEN E.employeeId ELSE @employeeId END
AND E.requestDate >= IIF(@statusId = -1, @startDate, E.requestDate)
AND E.requestDate <= IIF(@statusId = -1, DATEADD(d, 1, @endDate), E.requestDate)
AND E.epvStatusId = CASE WHEN @statusId = -1 THEN E.epvStatusId ELSE @statusId END

END

RETURN

GO


