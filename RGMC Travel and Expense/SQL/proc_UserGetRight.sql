ALTER PROCEDURE [dbo].[proc_UserGetRight]
(
	@modCode	VARCHAR(50) = '',
	@secCode	VARCHAR(50) = ''
)
AS

DECLARE	@groupCode VARCHAR(50) = ''
--DECLARE	@modCode	VARCHAR(50) = 'CA',
--	@secCode	VARCHAR(50) = 'jcflores'

BEGIN	

	SELECT @groupCode = groupCode 
	FROM SystemMember  
	WHERE secCode = @secCode  

	IF @@ROWCOUNT = 1
		BEGIN
			IF @groupCode = 'GU'
				BEGIN
				 RETURN 
				END
		END

	SELECT SystemAccess.accessRight, SystemAccess.secCode
	FROM SystemAccess
		LEFT JOIN SystemMember ON SystemAccess.secCode = SystemMember.groupCode
		LEFT JOIN SystemModule ON SystemAccess.modCode = SystemModule.modCode
			AND SystemModule.isActive = 1
	WHERE SystemAccess.modCode = @modCode 
		AND (SystemAccess.secCode = @secCode 
		OR SystemMember.secCode = @secCode)		

END
RETURN



