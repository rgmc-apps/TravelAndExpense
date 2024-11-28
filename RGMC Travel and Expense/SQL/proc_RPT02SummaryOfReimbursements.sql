ALTER PROCEDURE proc_RPT02SummaryOfReimbursements
(
	@batchDate DATE
)
AS

--DECLARE @batchDate DATE = '02/16/2017'

BEGIN

SELECT CONCAT(receivedBy.lastName, ', ', receivedBy.firstName) AS employeeName,
 transactionTypeId, formNumber, requestDate,
totalExpense AS actualExpenses, modeOfPaymentCode AS modeOfSettlement, releasingDate
FROM EPV E
INNER JOIN SystemUser SU ON SU.employeeId = E.employeeId
INNER JOIN ModeOfPayment MP ON MP.modeOfPaymentId = E.modeOfPaymentId
INNER JOIN SystemUser receivedBy ON receivedBy.employeeId = E.employeeId
INNER JOIN EPVDetail ED ON ED.epvId = E.epvId
WHERE batchDate = @batchDate 
	AND E.employeeId <> -1 
	AND transactionTypeId = 1 --REIMBURSEMENT
	AND E.epvStatusId <> 8 --REJECTED
GROUP BY E.epvId, receivedBy.lastName, formNumber, requestDate, receivedBy.firstName, transactionTypeId, totalExpense, modeOfPaymentCode, releasingDate
ORDER BY E.epvId

END
RETURN