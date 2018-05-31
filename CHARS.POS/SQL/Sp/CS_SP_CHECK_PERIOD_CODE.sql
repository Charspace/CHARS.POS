CREATE procedure [dbo].[CS_SP_CHECK_PERIOD_CODE]
@luckyType VARCHAR(20)
,@periodCode VARCHAR(20)
AS 

SELECT Ask
FROM LM_Period
WHERE 
[Period Code] = @periodCode
AND 
[Lucky Type] = @luckyType



