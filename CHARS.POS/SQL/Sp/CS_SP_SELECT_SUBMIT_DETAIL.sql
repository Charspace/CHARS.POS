CREATE PROCEDURE [dbo].[CS_SP_SELECT_SUBMIT_DETAIL]
@PeriodAsk Bigint=0
,@LuckyTypeAsk Bigint=0
,@SubmitHeader Bigint=0
AS	
BEGIN

--SELECT * FROM [LM_SubmitHeader] WHERE  [Lucky Type]= @LuckyTypeAsk and [PeriodASK] = @PeriodAsk

--DECLARE @query NVARCHAR(max)
--SET @query = '  '


--SET @query = '  
SELECT [LM_LuckyType].[Lucky Code] as [Lucky Type]
,[LM_Period].[Period Code]  as [Period]
, [LM_List].[List Code] AS [List]
,SUM([LM_SubmitDetail].[Amount]) AS [Total Amount]
--, [LM_SubmitHeader].[Submit Code]
FROM [LM_SubmitDetail]
INNER JOIN  [LM_SubmitHeader] ON [LM_SubmitHeader].Ask = [LM_SubmitDetail].[HeaderASK]
INNER JOIN [LM_List] ON [LM_List].Ask = [LM_SubmitDetail].List
INNER JOIN [LM_Period] ON [LM_Period].Ask = [LM_SubmitHeader].[Period]
INNER JOIN [LM_LuckyType] ON [LM_LuckyType].Ask = [LM_SubmitHeader].[Lucky Type]
WHERE 1=1 
AND [LM_SubmitHeader].[Period] = @PeriodAsk 
 AND [LM_SubmitHeader].[Lucky Type] =  @LuckyTypeAsk 

--IF (@SubmitHeader <> 0) 
--begin
--SET @query = '  AND [LM_SubmitHeader].Ask = '+ @SubmitHeader 
--end



--SET @query = ' 
 GROUP BY  [LM_LuckyType].[Lucky Code],[LM_Period].[Period Code] , [LM_List].[List Code]
 
 --EXEC sp_executesql @query 
END





