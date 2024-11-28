ALTER PROCEDURE proc_RPT01ExpenseReport
(
	@startDate DATE,
	@endDate DATE
)
AS

--DECLARE @startDate DATE = '01/01/2019'
--DECLARE @endDate DATE = '12/31/2019'

BEGIN

SELECT ES.name AS epvStatus, formNumber, CONCAT (SU.lastName, ', ', SU.firstName) AS employeeName,
	businessPurposeName, E.createDate AS submittedDate, batchDate, releasingDate AS settlementDate, costCenterCode,
	costCenterName AS departmentName, storeCode, storeName, transactionTypeName, modeOfPaymentCode,
	caNumber, transactionDate, NE.natureOfExpenseCode, NE.natureOfExpenseName, particulars, CT.chargeToName, amount,
	vatAmount AS vat, ClaimableBy.chargeToName AS claimableBy, V.vendorName AS vendor, V.address, tin, referenceNumber,
	E.receivedByAcctId
FROM EPV E
	INNER JOIN EPVDetail RD ON RD.epvId = E.epvId
		AND RD.chargeToId = E.chargeToId
	INNER JOIN ChargeTo CT ON CT.chargeToId = E.chargeToId
	INNER JOIN BusinessPurpose BP ON E.businessPurposeId = BP.businessPurposeId
	INNER JOIN CostCenter CC ON E.costCenterId = CC.costCenterId
	INNER JOIN Stores S ON E.storeId = S.storeId
	INNER JOIN TransactionType TT ON E.transactionTypeId = TT.transactionTypeId
	INNER JOIN ModeOfPayment MP ON E.modeOfPaymentId = MP.modeOfPaymentId
	LEFT JOIN CashAdvance CA ON CA.caId = E.caId  AND CA.chargeToId = E.chargeToId
	INNER JOIN SystemUser SU ON SU.employeeId = E.employeeId
	LEFT JOIN ChargeTo ClaimableBy ON ClaimableBy.chargeToId = RD.claimToId
	LEFT JOIN Vendor V ON V.vendorId = RD.vendorId
	INNER JOIN NatureOfExpense NE ON NE.natureOfExpenseId = RD.natureOfExpenseId
	INNER JOIN EPVStatus ES ON ES.epvStatusId = E.epvStatusId
WHERE E.batchDate >= @startDate 
	AND E.batchDate <= @endDate
	AND E.epvStatusId <> 8 --REJECTED
	--AND formNumber = 'US-R19-8234'
ORDER BY E.epvStatusId, E.batchDate
END

RETURN