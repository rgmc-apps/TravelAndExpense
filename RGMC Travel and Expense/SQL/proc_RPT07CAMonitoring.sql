ALTER PROCEDURE proc_RPT07CAMonitoring
(
	@startDate DATE
	, @endDate DATE
	, @mode INT
)
AS
BEGIN

--proc_RPT07CAMonitoring '12/28/2017', '06/28/2018', 1

--DECLARE @startDate DATE = '12/28/2017'
--DECLARE @endDate DATE = '06/28/2018'
--DECLARE @mode INT = 0

IF @mode = 0
BEGIN
	SELECT CAS.name AS caStatus, caNumber, CONCAT(SU.lastName, ', ',SU.firstName) AS employeeName,
	businessPurposeName, CA.bpOthers,
	CA.receivedByAcctDate AS dateCAReceived, CA.releasedByAcctDate AS dateReleased,
	caAmount, totalExpense, cashOverUnder, ES.name AS epvStatus,
	dateLiquidated, E.receivedByAcctDate, formNumber, batchDate, releasingDate AS settlementDate,
	releasedDate AS dateSettled, modeOfPaymentCode,
	transactionTypeId, CAS.cashAdvanceStatusId
	FROM CashAdvance CA
	INNER JOIN SystemUser SU ON SU.employeeId = CA.employeeId
	INNER JOIN ModeOfPayment MP ON MP.modeOfPaymentId = CA.modeOfPaymentId
	INNER JOIN CashAdvanceStatus CAS ON CAS.cashAdvanceStatusId = CA.cashAdvanceStatusId
	INNER JOIN BusinessPurpose BP ON BP.businessPurposeId = CA.businessPurposeId
	LEFT JOIN EPV E ON E.caId = CA.caId AND E.chargeToId = CA.chargeToId
	LEFT JOIN EPVStatus ES ON ES.epvStatusId = E.epvStatusId
	WHERE CA.releasedByAcctDate >= @startDate 
		AND CA.releasedByAcctDate <= @endDate 
	ORDER BY CAS.cashAdvanceStatusId, releasedByAcctDate, CA.modeOfPaymentId
END
ELSE
BEGIN
	SELECT CAS.name AS caStatus, caNumber, CONCAT(SU.lastName, ', ',SU.firstName) AS employeeName, 
	businessPurposeName, CA.bpOthers,
	CA.receivedByAcctDate AS dateCAReceived, CA.releasedByAcctDate AS dateReleased,
	caAmount, totalExpense, cashOverUnder, ES.name AS epvStatus,
	dateLiquidated, E.receivedByAcctDate, formNumber, batchDate, releasingDate AS settlementDate,
	releasedDate AS dateSettled, modeOfPaymentCode,
	transactionTypeId, CAS.cashAdvanceStatusId
	FROM CashAdvance CA
	INNER JOIN SystemUser SU ON SU.employeeId = CA.employeeId
	INNER JOIN ModeOfPayment MP ON MP.modeOfPaymentId = CA.modeOfPaymentId
	INNER JOIN CashAdvanceStatus CAS ON CAS.cashAdvanceStatusId = CA.cashAdvanceStatusId
	INNER JOIN BusinessPurpose BP ON BP.businessPurposeId = CA.businessPurposeId
	LEFT JOIN EPV E ON E.caId = CA.caId AND E.chargeToId = CA.chargeToId
	LEFT JOIN EPVStatus ES ON ES.epvStatusId = E.epvStatusId
	WHERE CA.receivedByAcctDate >= @startDate 
		AND CA.receivedByAcctDate <= @endDate 
	ORDER BY CAS.cashAdvanceStatusId, releasedByAcctDate, CA.modeOfPaymentId
END 

END
RETURN