CREATE PROCEDURE proc_EPVDetailList
(
	@epvId INT
)
AS

--DECLARE @epvId INT = 1812

BEGIN

SELECT ED.natureOfExpenseId, CAST(transactionDate AS DATE) AS transactionDate, 
	natureOfExpenseName, particulars, CT.chargeToName, amount, 
	ED.vendorId, ISNULL(V.vendorName, '') AS vendorName,  ISNULL(V.vendorName, '') AS tin, 
	referenceNumber, vatAmount, ISNULL(claimToId, -1) AS claimToId, ED.isActive, ISNULL(V.[address], '') AS vendorAddress, 	
	ED.chargeToId, lineNumber
FROM EPVDetail ED
	INNER JOIN NatureOfExpense NE ON NE.natureOfExpenseId = ED.natureOfExpenseId
	INNER JOIN ChargeTo CT ON CT.chargeToId = ED.chargeToId
	LEFT JOIN Vendor V ON V.vendorId = ED.vendorId
WHERE ED.epvId = @epvId
ORDER BY lineNumber

END
RETURN