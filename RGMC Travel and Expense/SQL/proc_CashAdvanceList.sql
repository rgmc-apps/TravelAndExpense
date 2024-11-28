ALTER PROCEDURE proc_CashAdvanceList
(
	@chargeToId INT,
	@employeeId INT,
	@startDate DATE,
	@endDate DATE,
	@statusId INT,
	@headEmployeeId INT
)
AS

--DECLARE @chargeToId INT = -1
--DECLARE @employeeId INT = -1
--DECLARE @startDate DATE = '01/01/1900'
--DECLARE @endDate DATE = '12/31/2019'
--DECLARE @statusId INT = -1
--DECLARE @headEmployeeId INT = 95

DECLARE	@userType VARCHAR(50)

SELECT @userType = (SELECT STUFF((SELECT ' | ' + groupCode 
FROM SystemUser SU INNER JOIN SystemMember SM ON SM.secCode = SU.secCode 
WHERE SU.employeeId = @headEmployeeId 
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

SELECT CA.caId, 
CA.chargeToId,
CAS.name AS 'Status',
caNumber 'CA #',
caAmount 'Amount', 
businessPurposeName AS 'Business Purpose',
CA.bpOthers AS 'Other Details',
CONVERT(VARCHAR(11), dateNeeded, 101) 'Date Needed',
CONCAT(SU.lastName, ', ', SU.firstName) 'Employee Name',
MP.modeOfPaymentCode 'Mode of Payment',
CC.costCenterName 'Department', 
S.storeName 'Store',
CT.chargeToName AS 'Company',

CASE WHEN CA.headApprovedById = -1 THEN '' ELSE 
(SELECT CONCAT(headApprovedBy.lastName, ', ', headApprovedBy.firstName) 
FROM SystemUser headApprovedBy WHERE headApprovedBy.employeeId = CA.headApprovedById)
END AS 'Head Approved By',
CASE WHEN CA.headApprovedById = -1 THEN '' ELSE CONVERT(VARCHAR(11), CA.headApprovedDate, 101) END AS 'Head Approved Date',

CASE WHEN CA.mgtApprovedById = -1 THEN '' ELSE
(SELECT CONCAT(mgtApprovedBy.lastName, ', ', mgtApprovedBy.firstName) 
FROM SystemUser mgtApprovedBy WHERE mgtApprovedBy.employeeId = CA.mgtApprovedById)
END AS 'Mgt Approved By',
CASE WHEN CA.mgtApprovedById = -1 THEN '' ELSE CONVERT(VARCHAR(11), CA.mgtApprovedDate, 101) END AS 'Mgt Approved Date',

CA.remarks AS 'Remarks',
CA.updateDate AS 'Date Last Modified'
FROM CashAdvance CA
	INNER JOIN BusinessPurpose BP ON BP.businessPurposeId = CA.businessPurposeId
	INNER JOIN ChargeTo CT ON CT.chargeToId = CA.chargeToId
	INNER JOIN SystemUser SU ON SU.employeeId = CA.employeeId
	INNER JOIN #tmpEmployee tmp ON tmp.employeeId = SU.employeeId
	INNER JOIN CostCenter CC ON CC.costCenterId = CA.costCenterId
	LEFT JOIN ModeOfPayment MP ON MP.modeOfPaymentId = CA.modeOfPaymentId
	INNER JOIN Stores S ON S.storeId = CA.storeId
	INNER JOIN CashAdvanceStatus CAS ON CAS.cashAdvanceStatusId = CA.cashAdvanceStatusId
WHERE CA.chargeToId = CASE WHEN @chargeToId = -1 THEN CT.chargeToId ELSE @chargeToId END
AND CA.employeeId = CASE WHEN @employeeId = -1 THEN CA.employeeId ELSE @employeeId END
AND CA.createDate >= IIF(@statusId = -1, @startDate, CA.createDate)
AND CA.createDate <= IIF(@statusId = -1, DATEADD(d, 1, @endDate), CA.createDate)
AND CA.cashAdvanceStatusId =  CASE WHEN @statusId = -1 THEN CA.cashAdvanceStatusId ELSE @statusId END

--SELECT * FROM CashAdvance CA

--SELECT CA.caId, CA.chargeToId, MAX(CAS.name) 'Status', MAX(caNumber) 'CA #', MAX(caAmount) 'Amount', 
--MAX(businessPurposeName) 'Business Purpose', MAX(CA.bpOthers) 'Other Details',
--CONVERT(VARCHAR(11), MAX(dateNeeded), 101) 'Date Needed',
--CONCAT(MAX(SU.lastName), ', ', MAX(SU.firstName)) 'Employee Name',
--MAX(MP.modeOfPaymentCode) 'Mode of Payment',
--MAX(CC.costCenterName) 'Department', MAX(S.storeName) 'Store',
--MAX(CT.chargeToName) AS 'Company',
----CONVERT(VARCHAR(11), MAX(CA.reqDate), 101) 'Request Date',
--CASE WHEN MAX(CA.headApprovedById) = -1 THEN '' ELSE MAX(CONCAT(headApprovedBy.lastName, ', ', headApprovedBy.firstName)) END AS 'Head Approved By',
--CASE WHEN MAX(CA.headApprovedById) = -1 THEN '' ELSE CONVERT(VARCHAR(11), MAX(CA.headApprovedDate), 101) END AS 'Head Approved Date',
--CASE WHEN MAX(CA.mgtApprovedById) = -1 THEN '' ELSE MAX(CONCAT(mgtApprovedBy.lastName, ', ', mgtApprovedBy.firstName)) END AS 'Mgt Approved By',
--CASE WHEN MAX(CA.mgtApprovedById) = -1 THEN '' ELSE CONVERT(VARCHAR(11), MAX(CA.mgtApprovedDate), 101) END AS 'Mgt Approved Date',
--MAX((SELECT E.formNumber FROM EPV E WHERE E.CaId = CA.caId AND E.chargeToId = CA.chargeToId)) AS 'Released to', MAX(CA.remarks) AS 'Remarks', MAX(CA.updateDate) AS 'Date Last Modified'
--FROM CashAdvance CA
--	INNER JOIN BusinessPurpose BP ON BP.businessPurposeId = CA.businessPurposeId
--	INNER JOIN ChargeTo CT ON CT.chargeToId = CA.chargeToId
--	INNER JOIN SystemUser SU ON SU.employeeId = CA.employeeId
--	INNER JOIN #tmpEmployee tmp ON tmp.employeeId = SU.employeeId
--	INNER JOIN SystemUser headApprovedBy ON headApprovedBy.employeeId = CA.headApprovedById
--	INNER JOIN SystemUser mgtApprovedBy ON mgtApprovedBy.employeeId = CA.mgtApprovedById
--	INNER JOIN CostCenter CC ON CC.costCenterId = CA.costCenterId
--	INNER JOIN ModeOfPayment MP ON MP.modeOfPaymentId = CA.modeOfPaymentId
--	INNER JOIN Stores S ON S.storeId = CA.storeId
--	INNER JOIN CashAdvanceStatus CAS ON CAS.cashAdvanceStatusId = CA.cashAdvanceStatusId
--WHERE CA.chargeToId = CASE WHEN @chargeToId = -1 THEN CT.chargeToId ELSE @chargeToId END
--AND CA.employeeId = CASE WHEN @employeeId = -1 THEN CA.employeeId ELSE @employeeId END
--AND CA.createDate >= IIF(@statusId = -1, @startDate, CA.createDate)
--AND CA.createDate <= IIF(@statusId = -1, DATEADD(d, 1, @endDate), CA.createDate)
--AND CA.cashAdvanceStatusId =  CASE WHEN @statusId = -1 THEN CA.cashAdvanceStatusId ELSE @statusId END
--GROUP BY CA.caId, CA.chargeToId

END

RETURN