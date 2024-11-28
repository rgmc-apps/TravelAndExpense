ALTER PROCEDURE proc_RPT10EPVStatusMonitoring
(
	@startDate DATE,
	@endDate DATE,
	@mode INT
)
AS
BEGIN

--DECLARE @startDate DATE = '01/01/2017'
--DECLARE @endDate DATE = '12/31/2017'

IF @mode = 0
	BEGIN
		SELECT ES.name AS epvStatus, formNumber,
		CONCAT(lastName, ', ',firstName) AS employeeName, businessPurposeName,
		totalExpense, modeOfPaymentCode, transactionTypeId, requestDate, batchDate, releasingDate
		, IIF(headApprovedById = -1, '',headApprovedDate) AS headApprovedDate
		, IIF(mgtApprovedById = -1, '', mgtApprovedDate) AS mgtApprovedDate
		, IIF(receivedByAcctId = -1, '', receivedByAcctDate) AS receivedByAcctDate
		, IIF(auditedById = -1, '', auditedDate) AS auditedDate
		, IIF(uploadedById = -1, '', uploadedDate) AS uploadedDate
		, IIF(releasedById = -1, '', releasedDate) AS releasedDate	
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
		SELECT ES.name AS epvStatus, formNumber,
		CONCAT(lastName, ', ',firstName) AS employeeName, businessPurposeName,
		totalExpense, modeOfPaymentCode, transactionTypeId, requestDate, batchDate, releasingDate
		, IIF(headApprovedById = -1, '',headApprovedDate) AS headApprovedDate
		, IIF(mgtApprovedById = -1, '', mgtApprovedDate) AS mgtApprovedDate
		, IIF(receivedByAcctId = -1, '', receivedByAcctDate) AS receivedByAcctDate
		, IIF(auditedById = -1, '', auditedDate) AS auditedDate
		, IIF(uploadedById = -1, '', uploadedDate) AS uploadedDate
		, IIF(releasedById = -1, '', releasedDate) AS releasedDate	
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