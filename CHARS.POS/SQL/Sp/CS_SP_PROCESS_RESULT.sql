CREATE PROCEDURE [dbo].[CS_SP_PROCESS_RESULT]
@TypeAsk BIGINT=0,
@PeriodAsk BIGINT=0
AS
BEGIN
DECLARE @PassType INT =0
SELECT @PassType =  [Pass Type] FROM LM_LuckyType WHERE ASK = @TypeAsk
--SELECT @PassType
DECLARE @PassCount INT =0
SELECT @PassCount =  [Number of Pass] FROM LM_LuckyType WHERE ASK = @TypeAsk
--SELECT @PassCount
DECLARE @StartDate NVARCHAR(8)
SELECT @StartDate = [Start Date]  FROM LM_Period WHERE ASK = @PeriodAsk
--SELECT @StartDate
DECLARE @EndDate NVARCHAR(8)
SELECT @EndDate =  [End Date]  FROM LM_Period WHERE ASK = @PeriodAsk
--SELECT @EndDate
DECLARE @query NVARCHAR(4000)

IF (@PassType='1')
BEGIN

SET @query = ' SELECT Top '+ cast ( @PassCount as nvarchar)
+ ' ASK,[List Code],[List Description]  FROM LM_LIST WHERE [Lucky Type]= '+   cast ( @TypeAsk as nvarchar)  +
' AND ' +@StartDate +' BETWEEN [Start Date] AND [End Date] '
+' AND  ' +@EndDate +' BETWEEN [Start Date] AND [End Date]'
+ ' ORDER BY NEWID() '


END
ELSE IF  (@PassType='0')
BEGIN
 SET @query =  'SELECT * FROM LM_List'
END
--select  @query		
EXEC sp_executesql @query
END







