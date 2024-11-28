SELECT * FROM ChargeTo 
SELECT * FROM EPVStatus 


DECLARE @epvId INT = -1
DECLARE @chargeToId INT = -1
DECLARE @formNumber VARCHAR(20) = ''

SELECT @epvId FROM EPV WHERE formNumber = @formNumber
SELECT * FROM EPV WHERE epvId = @epvId
SELECT * FROM EPVDetail WHERE epvId = @epvId


--UPDATE EPV SET
--chargeToId = @chargeToId
--WHERE epvId = @epvId

--UPDATE EPVDetail SET
--chargeToId = @chargeToId
--WHERE epvId = @epvId

SELECT * FROM CashAdvanceStatus 
DECLARE @cashAdvanceStatusId INT = 5
DECLARE @caNumber VARCHAR(20) = 'SHARED19-131'
DECLARE @caId INT = -1

SELECT @caId = caId FROM CashAdvance WHERE caNumber = @caNumber 

SELECT * FROM EPV WHERE caId = @caId

SELECT * FROM CashAdvance WHERE caId = @caId


--UPDATE CashAdvance SET
--cashAdvanceStatusId = @cashAdvanceStatusId
--WHERE caId = @caId