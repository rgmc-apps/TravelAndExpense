ALTER PROCEDURE [dbo].[proc_RPT08TopSheetReimbursement]
(
	@batchDate DATE,
	@modeofPaymentId INT
)
AS

--DECLARE 	@batchDate DATE = '06/25/2018'
--DECLARE 	@modeofPaymentId INT = '1'

BEGIN

	SELECT ROW_NUMBER() OVER(ORDER BY SU.name ASC) AS lineNumber,
	MOP.modeOfPaymentCode, EPV.batchDate, EPV.releasingDate,
	AA.setValue AS AcctAssistant, AASup.setValue AS AsstAcctSupervisor, ASup.setValue AS AcctSupervisor, TA.setValue AS TreasuryAssist,
	AA.setName AS AcctAssistantName, AASup.setName AS AsstAcctSupervisorName, ASup.setName AS AcctSupervisorName, TA.setName AS TreasuryAssistName,
	ISNULL(CT.chargeToName, '') AS chargeToName, EPV.formNumber, SU.name AS employeeName, ISNULL(EPV.totalExpense, 0) AS totalExpense
	FROM EPV
	INNER JOIN ModeOfPayment MOP ON MOP.modeOfPaymentId = EPV.modeOfPaymentId
	INNER JOIN ChargeTo CT ON CT.chargeToId = EPV.chargeToId
	INNER JOIN SystemUser SU ON SU.employeeId = EPV.employeeId
	LEFT JOIN SystemSetting AA ON AA.setCode = 'AcctAssistant'
	LEFT JOIN SystemSetting AASup ON AASup.setCode = 'AsstAcctSupervisor'
	LEFT JOIN SystemSetting ASup ON ASup.setCode = 'AcctSupervisor'
	LEFT JOIN SystemSetting TA ON TA.setCode = 'TreasuryAssist'
	WHERE EPV.batchDate = @batchDate
		AND transactionTypeId = 1
		AND EPV.epvStatusId > 2 --FOR APPROVAL
		AND EPV.epvStatusId <> 8 --REJECTED
		AND EPV.modeOfPaymentId = @modeofPaymentId
	ORDER BY SU.lastName ASC

END