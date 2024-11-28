ALTER PROCEDURE proc_EPVDetail
(
	@epvId INT
)
AS

--DECLARE @epvId INT = 1812

BEGIN

SELECT epvId, formNumber, TT.transactionTypeId, transactionTypeName, E.epvStatusId, ES.name, ES.name AS epvStatusName, E.chargeToId,
	E.caId, ISNULL(CA.caNumber, 0) caNumber, ISNULL(CA.caAmount, 0) AS caAmount, E.businessPurposeId, businessPurposeName, E.bpOthers,
	CASE WHEN E.employeeId = -1 THEN '' ELSE CONCAT(reqBy.lastName, ', ', reqBy.firstName) END AS employeeName,
	CASE WHEN E.employeeId = -1 THEN '' ELSE CONCAT(reqBy.lastName, ', ', reqBy.firstName) END AS requestedByName, 
	E.employeeId, E.requestDate,
	CASE WHEN E.headApprovedById = -1 THEN '' ELSE CONCAT(headApprovedBy.lastName, ', ', headApprovedBy.firstName) END AS headApprovedByName, 
	E.headApprovedById, E.headApprovedDate,
	CASE WHEN E.mgtApprovedById = -1 THEN '' ELSE CONCAT(mgtApprovedBy.lastName, ', ', mgtApprovedBy.firstName) END AS mgtApprovedByName, 
	E.mgtApprovedById, E.mgtApprovedDate,
	CASE WHEN E.auditedById = -1 THEN '' ELSE CONCAT(auditedBy.lastName, ', ', auditedBy.firstName) END AS auditedByName, 
	E.auditedById, E.auditedDate,
	CASE WHEN E.uploadedById = -1 THEN '' ELSE CONCAT(uploadedBy.lastname, ', ', uploadedBy.firstName) END AS uploadedByName,  
	E.uploadedById, E.uploadedDate,
	CASE WHEN E.receivedByAcctId = -1 THEN '' ELSE CONCAT(receivedByAccounting.lastName, ', ', receivedByAccounting.firstName) END AS receivedByAcctName,
	CASE WHEN E.receivedByAcctId = -1 THEN '' ELSE CONCAT(receivedByAccounting.lastName, ', ', receivedByAccounting.firstName) END AS receivedByAccountingName, 
	E.receivedByAcctId, E.receivedByAcctDate,
	CASE WHEN E.releasedById = -1 THEN '' ELSE CONCAT(releasedBy.lastName, ', ', releasedBy.firstName) END AS releasedByName, 
	releasedById, releasedDate, E.remark,
	releasingDate, batchDate, CC.costCenterId, CC.costCenterName,
	S.storeId, S.storeName, MP.modeOfPaymentId, MP.modeOfPaymentCode, totalExpense, cashOverUnder, 
	CAS.cashAdvanceStatusId AS caStatusId, CAS.name AS caStatus, CA.chargeToId AS caChargeToId
FROM EPV E
	INNER JOIN TransactionType TT ON TT.transactionTypeId = E.TransactionTypeId
	INNER JOIN BusinessPurpose BP ON BP.businessPurposeId = E.businessPurposeId
	INNER JOIN CostCenter CC ON CC.costCenterId = E.costCenterId
	LEFT JOIN ModeOfPayment MP ON MP.modeOfPaymentId = E.modeOfPaymentId
	LEFT JOIN Stores S ON S.storeId = E.storeId
	LEFT JOIN SystemUser reqBy ON reqBy.employeeId = E.employeeId
	LEFT JOIN SystemUser headApprovedBy ON headApprovedBy.employeeId = E.headApprovedById
	LEFT JOIN SystemUser mgtApprovedBy ON mgtApprovedBy.employeeId = E.mgtApprovedById
	LEFT JOIN SystemUser auditedBy ON auditedBy.employeeId = E.auditedById
	LEFT JOIN SystemUser uploadedBy ON uploadedBy.employeeId = E.uploadedById
	LEFT JOIN SystemUser receivedByAccounting ON receivedByAccounting.employeeId = E.receivedByAcctId
	LEFT JOIN SystemUser releasedBy ON releasedBy.employeeId = E.releasedById	
	LEFT JOIN CashAdvance CA ON CA.caId = E.caId AND CA.chargeToId = E.chargeToId
	LEFT JOIN CashAdvanceStatus CAS ON CAS.cashAdvanceStatusId = CA.cashAdvanceStatusId
	INNER JOIN EPVStatus ES ON ES.epvStatusId = E.epvStatusId
WHERE epvId = @epvId

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