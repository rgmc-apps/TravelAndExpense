ALTER PROCEDURE proc_StatusCount
(
	 @employeeId INT, 
	 @modeId INT, 
	 @statusId INT
)
AS

--DECLARE @employeeId INT = 191
--DECLARE @modeId INT = 1
--DECLARE @statusId INT = -1

DECLARE @userType VARCHAR(250)
DECLARE @MODE_EPV INT = 1
DECLARE @MODE_CA INT = 2

SELECT @userType = (SELECT STUFF((SELECT ' | ' + groupCode 
FROM SystemUser SU INNER JOIN SystemMember SM ON SM.secCode = SU.secCode 
WHERE employeeId = @employeeId 
FOR XML PATH(''), TYPE  
     ).value('.', 'NVARCHAR(MAX)') 
, 1, 1, ''))  
FROM SystemMember 
 
IF NOT OBJECT_ID ('tempdb..#tmpEmployee') IS NULL DROP TABLE #tmpEmployee 
	SELECT  
		CAST(-1 AS INT) AS employeeId, 
		CAST('' AS VARCHAR(50)) AS secCode, 
		CAST('' AS VARCHAR(200)) AS name 
	INTO #tmpEmployee 
 
	TRUNCATE TABLE #tmpEmployee 
 
IF CHARINDEX('ALL', @userType) > 0 
	OR CHARINDEX('ACTG', @userType) > 0
	OR CHARINDEX('TREASURY', @userType) > 0
	OR CHARINDEX('APPROVER', @userType) > 0 
	OR CHARINDEX('ACTG2', @userType) > 0 
BEGIN 
	INSERT INTO #tmpEmployee(employeeId, secCode, name) 
	SELECT employeeId, secCode, name 
	FROM SystemUser  
END 
ELSE
BEGIN
	INSERT INTO #tmpEmployee(employeeId, secCode, name) 
	SELECT employeeId, secCode, name 
	FROM SystemUser 
	WHERE employeeId = @employeeId
END

IF @modeId = @MODE_EPV
BEGIN
	SELECT COUNT(*) AS statusCount
	FROM EPV EPV 
	INNER JOIN #tmpEmployee tmp ON tmp.employeeId = EPV.employeeId
	WHERE EPV.epvStatusId = IIF(@statusId <> -1, @statusId, EPV.epvStatusId)
END
ELSE IF @modeId = @MODE_CA
BEGIN
	SELECT COUNT(*) AS statusCount
	FROM CashAdvance CA
	INNER JOIN #tmpEmployee tmp ON tmp.employeeId = CA.employeeId
	WHERE CA.cashAdvanceStatusId = IIF(@statusId <> -1, @statusId, CA.cashAdvanceStatusId)
END