ALTER PROCEDURE proc_RPT03SummaryOfLiquidations
(
@batchDate DATE
)
AS

--DECLARE @batchDate DATE = '11/30/2017'

BEGIN

SELECT epvId, R.requestDate, CA.caNumber,
CONCAT (SU.lastName, ', ', SU.firstName) AS employeeName,
totalExpense AS actualExpense, Ca.caAmount AS cashAdvance, transactionTypeId,
cashOverUnder AS caUnderOver, modeOfPaymentCode AS modeOfSettlement, releasingDate
FROM EPV R
INNER JOIN SystemUser SU ON SU.employeeId = R.employeeId
INNER JOIN ModeOfPayment MP ON MP.modeOfPaymentId = R.modeOfPaymentId
INNER JOIN CashAdvance CA ON CA.caid = R.caId AND CA.chargeToId = R.chargeToId
WHERE batchDate = @batchDate 
	AND R.employeeId <> -1 
	AND transactionTypeId = 2
	AND R.epvStatusId <> 8 --REJECTED
ORDER BY epvId

END
RETURN