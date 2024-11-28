ALTER PROCEDURE proc_RPT05EPV
(
	@epvId INT,
	@chargeToId INT
)
AS

--DECLARE @epvId INT = 1750,
--	@chargeToId INT = 3

BEGIN

SELECT epvId, E.chargeToId, E.formNumber, TT.transactionTypeId, transactionTypeName,
CA.caId, CA.caNumber, CA.caAmount, SU.employeeId, CT.chargeToName,
CC.costCenterId, costCenterName, S.storeId, storeName, BP.businessPurposeId, businessPurposeName, E.bpOthers,
MP.modeOfPaymentId, modeOfPaymentCode, totalExpense, cashOverUnder,
releasingDate, releasedById, releasedDate,
RS.epvStatusId, RS.name, E.batchDate,
E.remark,
CASE WHEN SU.employeeId IS NULL THEN ''
ELSE
CONCAT(SU.lastName, ', ', SU.firstName) END AS employeeName,

E.requestDate,

E.headApprovedById,
CASE WHEN E.epvStatusId <= 2 AND E.epvStatusId != 10 THEN ''
ELSE
CASE WHEN E.headApprovedById = -1 THEN ''
ELSE
CONCAT(headApprovedBy.lastName, ', ', headApprovedBy.firstName) END END AS headApprovedByName,
E.headApprovedDate,

E.mgtApprovedById,
CASE WHEN E.epvStatusId <= 2 AND E.epvStatusId != 10 THEN ''
ELSE 
CASE WHEN E.mgtApprovedById = -1  THEN '' ELSE
CONCAT(mgtApprovedBy.lastName, ', ', mgtApprovedBy.firstName) END END AS mgtApprovedByName,
E.mgtApprovedDate,

E.auditedById,

CASE WHEN E.auditedById = -1   THEN ''
ELSE
CONCAT(audited.lastName, ', ', audited.firstName) END AS auditedName, E.auditedDate,

CASE WHEN E.uploadedById = -1 THEN ''
ELSE
CONCAT(uploaded.lastName, ', ', uploaded.firstName) END AS uploadedByName, E.uploadedDate,

CASE WHEN E.receivedByAcctId = -1 THEN ''
ELSE
CONCAT(receivedAcct.lastName, ', ', receivedAcct.firstName) END AS receivedByAcct,

CASE WHEN E.receivedByAcctId = -1 THEN
''
ELSE E.receivedByAcctDate END AS receivedByAcctDate,

CASE WHEN E.releasedById = -1 THEN
''
ELSE
CONCAT(releasedAcct.lastName, ', ', releasedAcct.firstName) END AS releasedByAcct,

CASE WHEN releasedAcct.employeeId = -1 THEN
''
ELSE E.releasedDate END AS releasedByAcctDate

FROM EPV E
INNER JOIN ChargeTo CT ON CT.chargeToId = E.chargeToId
INNER JOIN SystemUser SU ON SU.employeeId = E.employeeId
LEFT JOIN CashAdvance CA ON CA.caId = E.caId AND CA.chargeToId = E.chargeToId
INNER JOIN TransactionType TT ON TT.transactionTypeId = E.transactionTypeId
INNER JOIN CostCenter CC ON CC.costCenterId = E.costCenterId
LEFT JOIN Stores S ON S.storeId = E.storeId
INNER JOIN BusinessPurpose BP ON BP.businessPurposeId = E.businessPurposeId
LEFT JOIN ModeOfPayment MP ON MP.modeOfPaymentId = E.modeOfPaymentId
LEFT JOIN SystemUser headApprovedBy ON headApprovedBy.employeeId = E.headApprovedById
LEFT JOIN SystemUser mgtApprovedBy ON mgtApprovedBy.employeeId = E.mgtApprovedById
LEFT JOIN SystemUser audited ON audited.employeeId = E.auditedById
LEFT JOIN SystemUser uploaded ON uploaded.employeeId = E.uploadedById
LEFT JOIN SystemUser receivedAcct ON receivedAcct.employeeId = E.receivedByAcctId
LEFT JOIN SystemUser releasedAcct ON releasedAcct.employeeId = E.releasedById
LEFT JOIN EPVStatus RS ON RS.epvStatusId = E.epvStatusId
WHERE epvId = @epvId
	AND E.chargeToId = @chargeToId

SELECT RD.epvId, RD.chargeToId, transactionDate, RD.natureOfExpenseId, natureOfExpenseName,
particulars, amount, ISNULL(lineNumber, -1) AS lineNumber
FROM EPVDetail RD
INNER JOIN NatureOfExpense NE ON NE.natureOfExpenseId = RD.natureOfExpenseId
WHERE RD.epvId = @epvId
	AND RD.chargeToId = @chargeToId
	AND RD.isActive = 1
ORDER BY lineNumber

END

