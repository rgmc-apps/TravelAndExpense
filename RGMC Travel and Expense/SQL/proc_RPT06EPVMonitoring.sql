ALTER PROCEDURE proc_RPT06EPVMonitoring
(
	@startDate DATE,
	@endDate DATE,
	@mode INT
)
AS
BEGIN

DECLARE @MODE_BATCH INT = 0
DECLARE @MODE_RELEASED INT = 1

--DECLARE @startDate DATE = '01/01/2017'
--DECLARE @endDate DATE = '12/31/2017'
--DECLARE @mode BIT = 1

IF @mode = @MODE_BATCH
	BEGIN
		SELECT ES.name AS epvStatus, formNumber, receivedByAcctDate, batchDate, releasingDate, releasedDate,
		CONCAT(lastName, ', ',firstName) AS employeeName, businessPurposeName,
		totalExpense, modeOfPaymentCode, transactionTypeId
		FROM EPV E
		INNER JOIN SystemUser SU ON SU.employeeId = E.employeeId
		INNER JOIN BusinessPurpose BP ON BP.businessPurposeId = E.businessPurposeId
		INNER JOIN ModeOfPayment MP ON MP.modeOfPaymentId = E.modeOfPaymentId
		INNER JOIN EPVStatus ES ON ES.epvStatusId = E.epvStatusId
		WHERE batchDate >= @startDate 
			AND batchDate <= @endDate 
	END
ELSE
	BEGIN
		SELECT ES.name AS epvStatus, formNumber, receivedByAcctDate, batchDate, releasingDate, releasedDate,
		CONCAT(lastName, ', ',firstName) AS employeeName, businessPurposeName,
		totalExpense, modeOfPaymentCode, transactionTypeId
		FROM EPV E
		INNER JOIN SystemUser SU ON SU.employeeId = E.employeeId
		INNER JOIN BusinessPurpose BP ON BP.businessPurposeId = E.businessPurposeId
		INNER JOIN ModeOfPayment MP ON MP.modeOfPaymentId = E.modeOfPaymentId
		INNER JOIN EPVStatus ES ON ES.epvStatusId = E.epvStatusId
		WHERE E.releasedDate >= @startDate 
			AND E.releasedDate <= @endDate 
	END 
END
RETURN