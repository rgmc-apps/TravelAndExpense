ALTER Procedure proc_Dashboard
(
	@employeeId INT,
	@modeId		BIT
)
AS

--DECLARE @employeeId INT = 95
--DECLARE @modeId INT = 0

DECLARE	@userType VARCHAR(50)
DECLARE @MODE_EPV INT = 1
DECLARE @MODE_CA INT = 0

SELECT @userType = (SELECT STUFF((SELECT ' | ' + groupCode 
FROM SystemUser SU INNER JOIN SystemMember SM ON SM.secCode = SU.secCode 
WHERE employeeId = @employeeId 
FOR XML PATH(''), TYPE  
     ).value('.', 'NVARCHAR(MAX)') 
, 1, 1, ''))  
FROM SystemMember 

IF NOT OBJECT_ID ('tempdb..#tmpStatus') IS NULL DROP TABLE #tmpStatus
	SELECT  
		CAST(-1 AS INT) AS lineNumber, 
		CAST(-1 AS INT)  AS statusId, 
		CAST('' AS VARCHAR(200)) AS statusName 
	INTO #tmpStatus 

	TRUNCATE TABLE #tmpStatus 

	IF @modeId = @MODE_EPV
	BEGIN
		INSERT INTO #tmpStatus(lineNumber, statusId, statusName)
		SELECT ES.lineNumber, ES.epvStatusId, ES.name
		FROM EPVStatus ES
		WHERE epvStatusId <> 1 AND epvStatusId < 7
	END
	ELSE IF @modeId = @MODE_CA
	BEGIN
		INSERT INTO #tmpStatus(lineNumber, statusId, statusName)
		SELECT CAS.lineNumber, CAS.cashAdvanceStatusId, CAS.name
		FROM CashAdvanceStatus CAS
		WHERE cashAdvanceStatusId <> 1 AND cashAdvanceStatusId < 5
	END

IF NOT OBJECT_ID ('tempdb..#tmpRows') IS NULL DROP TABLE #tmpRows	
	SELECT 
		CAST(-1 AS INT) AS lineNumber,		
		CAST('' AS VARCHAR(250)) AS statusName,			
		CAST('' AS VARCHAR(250)) AS refNumber,				
		CAST(0 AS DECIMAL(18,2)) AS refAmount,	
		CAST(GETDATE() AS DATE) AS refDate,
		CAST('' AS VARCHAR(250)) AS refName,
		CAST(0 AS INT) AS elapseDays
	INTO #tmpRows

	TRUNCATE TABLE #tmpRows

	IF @modeId = @MODE_EPV
	BEGIN
	INSERT INTO #tmpRows(lineNumber, statusName, refNumber, refAmount, refDate, refName, elapseDays)
		SELECT ROW_NUMBER() OVER(PARTITION BY epvStatusId ORDER BY DATEDIFF(day, GETDATE(), EPV.requestDate) ASC) as lineNumber,
			statusName, formNumber, totalExpense, requestDate, SU.name, DATEDIFF(day, GETDATE(), EPV.requestDate)
		FROM EPV 
			INNER JOIN SystemUser SU ON SU.employeeId = EPV.employeeId
			INNER JOIN #tmpStatus S ON S.statusId = EPV.epvStatusId
		WHERE formNumber <> ''
	END
	ELSE IF @modeId = @MODE_CA
	BEGIN
		INSERT INTO #tmpRows(lineNumber, statusName, refNumber, refAmount, refDate, refName, elapseDays)
		SELECT ROW_NUMBER() OVER(PARTITION BY cashAdvanceStatusId ORDER BY DATEDIFF(day, GETDATE(), CA.dateNeeded) ASC) as lineNumber,
			statusName, caNumber, caAmount, dateNeeded, SU.name, DATEDIFF(day, GETDATE(), CA.dateNeeded)
		FROM CashAdvance CA
			INNER JOIN SystemUser SU ON SU.employeeId = CA.employeeId
			INNER JOIN #tmpStatus S ON S.statusId = CA.cashAdvanceStatusId
		WHERE caNumber <> ''
	END

DECLARE @cols AS NVARCHAR(MAX),
@query  AS NVARCHAR(MAX),
@p1  AS VARCHAR(3) = '(',
@p2  AS VARCHAR(3) = ')'

select @cols = STUFF((SELECT ',' + QUOTENAME(statusName) 
                    from #tmpStatus
                    order by lineNumber
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')

set @query = N'SELECT lineNumber, ' + @cols + N' from 
             (
                select 
				lineNumber, CONCAT(refNumber,''' + @p1 + ''', elapseDays*-1, ''' 
				+ @p2 +''','''+CHAR(13)+''','''+CHAR(10)+''',convert(varchar, convert(money, refAmount), 1)) AS refDetail, statusName
                from #tmpRows
            ) x			
            pivot 
            (
                max(refDetail)
                for statusName in (' + @cols + N')
            ) p '


exec sp_executesql @query;

