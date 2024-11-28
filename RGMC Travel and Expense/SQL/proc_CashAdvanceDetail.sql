ALTER PROCEDURE proc_CashAdvanceDetail
(
	@caId INT
)
AS

--DECLARE @caID INT = 413

BEGIN

SELECT CA.caId, caNumber, caAmount, CAS.cashAdvanceStatusId,
CAS.name AS caStatus, CA.chargeToId, dateNeeded, CA.businessPurposeId, CA.bpOthers, CA.employeeId,
SU.employeeId, CA.requestDate,
CASE WHEN SU.employeeId IS NULL THEN ''
ELSE
CONCAT(SU.lastName, ', ', SU.firstName) END AS employeeName,

CC.costCenterId, costCenterName, S.storeId, S.storeName, MP.modeOfPaymentId, modeOfPaymentCode,

CA.headApprovedById,
CASE WHEN CA.headApprovedById= -1 THEN ''
ELSE
CONCAT(headApprovedBy.lastName, ', ', headApprovedBy.firstName) END AS headApprovedByName,
CA.headApprovedDate,

CA.mgtApprovedById,
CASE WHEN CA.mgtApprovedById = -1 THEN ''
ELSE
CONCAT(mgtApprovedBy.lastName, ', ', mgtApprovedBy.firstName) END AS mgtApprovedByName,
CA.mgtApprovedDate,

CA.receivedByAcctId,
CASE WHEN CA.receivedByAcctId = -1 THEN
''
ELSE
CONCAT(receivedAcct.lastName, ', ', receivedAcct.firstName) END AS receivedByAcct,

CASE WHEN receivedAcct.employeeId = -1 THEN
''
ELSE CA.receivedByAcctDate END AS receivedByAcctDate,

CA.auditedById,
CASE WHEN CA.auditedById = -1 THEN
''
ELSE
CONCAT(auditedBy.lastName, ', ', auditedBy.firstName) END AS auditedBy,

CASE WHEN auditedBy.employeeId = -1 THEN
''
ELSE CA.auditedDate END AS auditedDate,

CA.uploadedById,
CASE WHEN CA.uploadedById = -1 THEN
''
ELSE
CONCAT(uploadedBy.lastName, ', ', uploadedBy.firstName) END AS uploadedBy,

CASE WHEN CA.uploadedById = -1 THEN
''
ELSE CA.uploadedDate END AS uploadedDate,

CA.releasedByAcctId,
CASE WHEN CA.releasedByAcctId	 = -1 THEN
''
ELSE
CONCAT(releasedAcct.lastName, ', ', releasedAcct.firstName) END AS releasedBy,

CASE WHEN CA.releasedByAcctId = -1 THEN
''
ELSE CA.releasedByAcctDate END AS releasedDate,

E.formNumber AS formNumber,

CA.remarks, CA.createBy, CA.createDate
FROM CashAdvance CA
INNER JOIN Stores S ON S.storeId = CA.storeId
INNER JOIN CostCenter CC ON CC.costCenterId = CA.costCenterId
LEFT JOIN ModeOfPayment MP ON MP.modeOfPaymentId = CA.modeOfPaymentId
INNER JOIN CashAdvanceStatus CAS ON CAS.cashAdvanceStatusId = CA.cashAdvanceStatusId
INNER JOIN SystemUser SU ON SU.employeeId = CA.employeeId
	LEFT JOIN EPV E ON E.caId = CA.caId AND E.chargeToId = CA.chargeToId
	LEFT JOIN SystemUser headApprovedBy ON headApprovedBy.employeeId = CA.headApprovedById
	LEFT JOIN SystemUser mgtApprovedBy ON mgtApprovedBy.employeeId = CA.mgtApprovedById
	LEFT JOIN SystemUser receivedAcct ON receivedAcct.employeeId = CA.receivedByAcctId
	LEFT JOIN SystemUser auditedBy ON auditedBy.employeeId = CA.auditedById
	LEFT JOIN SystemUser uploadedBy ON uploadedBy.employeeId = CA.uploadedById
	LEFT JOIN SystemUser releasedAcct ON releasedAcct.employeeId = CA.releasedByAcctId	
WHERE CA.caId = @caId

SELECT caId, particulars, CT.chargeToName, amount, CAD.isActive, CAD.chargeToId
FROM CashAdvanceDetail CAD
	LEFT JOIN ChargeTo CT ON CT.chargeToId = CAD.chargeToId
WHERE caId = @caId

END