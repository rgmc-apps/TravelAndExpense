ALTER PROCEDURE [dbo].[proc_RPT04CashAdvance]
(
	@caId INT,
	@chargeToId INT = -1
)
AS

--DECLARE @caId INT = 789,
--	@chargeToId INT = 8

BEGIN

SELECT CA.caId, CA.chargeToId, caNumber, caAmount AS totalAmount, CAS.cashAdvanceStatusId,
CAS.name, dateNeeded, CA.employeeId, CA.requestDate, BP.businessPurposeName, CA.bpOthers,
CT.chargeToName, SU.employeeId, 
CASE WHEN SU.employeeId = -1  THEN ''
ELSE
CONCAT(SU.lastName, ', ', SU.firstName) END AS employeeName,

CC.costCenterId, costCenterName, S.storeId, S.storeName, MP.modeOfPaymentId, modeOfPaymentCode,

CA.headApprovedById,
CASE WHEN CA.cashAdvanceStatusId <= 2 THEN ''
ELSE
CASE WHEN CA.headApprovedById = -1 THEN ''
ELSE
CONCAT(headApprovedBy.lastName, ', ', headApprovedBy.firstName) END END AS headApprovedByName,
CA.headApprovedDate,

CA.mgtApprovedById,
CASE WHEN CA.cashAdvanceStatusId <= 2 THEN ''
ELSE
CASE WHEN CA.mgtApprovedById = -1 THEN ''
ELSE
CONCAT(mgtApprovedBy.lastName, ', ', mgtApprovedBy.firstName) END END AS mgtApprovedByName,
CA.mgtApprovedDate,

CASE WHEN CA.receivedByAcctId = -1 THEN
''
ELSE
CONCAT(receivedAcct.lastName, ', ', receivedAcct.firstName) END AS receivedByAcct,

CASE WHEN CA.receivedByAcctId = -1 THEN
''
ELSE E.receivedByAcctDate END AS receivedByAcctDate,

CASE WHEN CA.auditedById = -1 THEN
''
ELSE
CONCAT(auditedBy.lastName, ', ', auditedBy.firstName) END AS auditedBy,

CASE WHEN CA.auditedById = -1 THEN
''
ELSE E.auditedDate END AS auditedDate,

CASE WHEN releasedAcct.employeeId = -1 THEN
''
ELSE
CONCAT(releasedAcct.lastName, ', ', releasedAcct.firstName) END AS releasedByAcct,

CASE WHEN releasedAcct.employeeId = -1 THEN
''
ELSE E.releasedDate END AS releasedByAcctDate,

E.formNumber AS formNumber,

CA.remarks, CA.createBy, CA.createDate

FROM CashAdvance CA
INNER JOIN SystemUser SU ON SU.employeeId = CA.employeeId
INNER JOIN ChargeTo CT ON CT.chargeToId = CA.chargeToId
INNER JOIN BusinessPurpose BP ON BP.businessPurposeId = CA.businessPurposeId
INNER JOIN Stores S ON S.storeId = CA.storeId
INNER JOIN CostCenter CC ON CC.costCenterId = CA.costCenterId
LEFT JOIN ModeOfPayment MP ON MP.modeOfPaymentId = CA.modeOfPaymentId
LEFT JOIN CashAdvanceStatus CAS ON CAS.cashAdvanceStatusId = CA.cashAdvanceStatusId
LEFT JOIN EPV E ON E.CaId = CA.caId AND E.chargeToId = CA.chargeToId
LEFT JOIN SystemUser headApprovedBy ON headApprovedBy.employeeId = CA.headApprovedById
LEFT JOIN SystemUser mgtApprovedBy ON mgtApprovedBy.employeeId = CA.mgtApprovedById
LEFT JOIN SystemUser receivedBy ON receivedBy.employeeId = CA.employeeId
LEFT JOIN SystemUser receivedAcct ON receivedAcct.employeeId = CA.receivedByAcctId
LEFT JOIN SystemUser auditedBy ON auditedBy.employeeId = CA.auditedById
LEFT JOIN SystemUser releasedAcct ON releasedAcct.employeeId = E.releasedById
WHERE CA.caId = @caId
	AND CA.chargeToId = IIF(@chargeToId = -1, CA.chargeToId, @chargeToId)

SELECT particulars, amount, CAD.chargeToId, lineNumber
FROM CashAdvanceDetail CAD
WHERE CAD.caId = @caId
	AND CAD.chargeToId = IIF(@chargeToId = -1, CAD.chargeToId, @chargeToId)
	AND isActive = 1
ORDER BY lineNumber

END