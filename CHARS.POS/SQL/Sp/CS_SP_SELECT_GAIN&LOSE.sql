CREATE PROCEDURE [dbo].[CS_SP_SELECT_GAIN&LOSE]
@PeriodAsk Bigint=0
,@LuckyTypeAsk Bigint=0
,@Status int =0
AS	
BEGIN
DECLARE @query NVARCHAR(MAX)


DECLARE @St int=0


SET @query = '
SELECT * FROM [LM_Gain] WHERE  [LM_Gain].[Lucky Type] = '+ CAST (@LuckyTypeAsk AS NVARCHAR(255))+ 'AND [LM_Gain].Period ='  + CAST (@PeriodAsk AS NVARCHAR(255))  

if (@Status ='0')
begin
SET @query =@query + '  AND [LM_Gain].[Status] = 1'
end
else if (@Status ='1')
begin
SET @query =@query + '  AND [LM_Gain].[Status] = 0'
end
else
begin
SET @query =@query 
end

SET @query =@query  + 'ORDER BY [status] DESC,[Gain Type] ASC ,List DESC'


EXEC sp_executesql @query
END





