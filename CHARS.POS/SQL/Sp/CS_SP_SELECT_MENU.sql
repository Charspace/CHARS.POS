CREATE PROCEDURE [dbo].[CS_SP_SELECT_MENU]
@menuGroup BIGINT

AS

SELECT MGJ.Menu AS ASK
FROM SYS_MENUGROUP AS MG
,SYS_MENUGROUP_JUN AS MGJ
WHERE MG.Ask = MGJ.[Menu Group]
AND MG.Ask = @menuGroup



