CREATE PROCEDURE [dbo].[CS_SP_PROCESS]
@TypeAsk BIGINT=0,
@PeridoAsk BIGINT=0,
@StartDate nVARCHAR(8),
@EndDate nVARCHAR(8),
@ResultCount int
AS
BEGIN
DECLARE @query NVARCHAR(MAX)
DECLARE @LuckyType int
DECLARE @List NVARCHAR(5)

CREATE TABLE #LM_Result(
	[ListASK] [bigint] NOT NULL DEFAULT(0),
	[ListCode] [nvarchar](255) NOT NULL DEFAULT(''),
	[ListDes] [nvarchar](255) NOT NULL DEFAULT(''),
	[ResultType] [smallint] NOT NULL DEFAULT(0), --1 for exace, 2 for round2, 3 for round6	
	[LuckyTypeAsk] 	 [bigint] NOT NULL DEFAULT(0),
	[Pass Type] [smallint] NOT NULL DEFAULT(0),  --1 for time, 2 for percent 
	[Pass] [decimal] (18,2) NOT NULL DEFAULT(0), 

)

--INSERT EXACT RESULT
INSERT INTO #LM_Result  ([ListASK],[ListCode],[ListDes],[ResultType],[LuckyTypeAsk],[Pass Type],[Pass])
SELECT LM_Result.List, LM_List.[List Code], LM_List.[List Description],1,LM_Result.LuckyType,LM_LuckyType.[Pass Type],LM_LuckyType.Pass
FROM LM_Result
INNER JOIN LM_List ON LM_List.Ask = LM_Result.List
INNER JOIN LM_LuckyType  ON LM_LuckyType.Ask = LM_Result.LuckyType
WHERE LM_Result.TS <> 6 
AND LM_ResuLT.Period =  @PeridoAsk -- 160121095018764225 --@PeridoAsk
AND LM_Result.LuckyType =@TypeAsk --   20151022132842356 -- @TypeAsk

--SELECT 'EXACT'
--SELECT * FROM #LM_Result
SELECT @List=  [ListCode]  FROM #LM_Result WHERE [ResultType] = 1 



--INSERT ROUND3 RESULT
SET @query = ' INSERT INTO #LM_Result   ([ListASK],[ListCode],[ListDes],[ResultType],[LuckyTypeAsk],[Pass Type],[Pass])
SELECT LM_List.Ask, LM_List.[List Code], LM_List.[List Description],2,LM_LuckyType.Ask,LM_LuckyType.[Pass Type],10
FROM LM_List 
INNER JOIN LM_LuckyType  ON LM_LuckyType.Ask = LM_List.[Lucky Type]
WHERE LM_List.TS <> 6 ' 
DECLARE @round VARCHAR(MAX)
SET @round = '(' + '[List Code] = ' + CAST( (CAST( @List AS int) - 1) AS VARCHAR(25));
SET @round +=  ' OR [List Code] = ' + CAST( (CAST(@List  AS int) + 1) AS VARCHAR(25)) + ')';
SET @query= @query + ' AND ' +	@round
--SELECT 'ROUND 3'
--SELECT @query	
EXEC sp_executesql @query



--INSERT ROUND6 RESULT
SET @query = ' 
INSERT INTO #LM_Result  ([ListASK],[ListCode],[ListDes],[ResultType],[LuckyTypeAsk],[Pass Type],[Pass])
SELECT LM_List.Ask, LM_List.[List Code], LM_List.[List Description],3,LM_LuckyType.Ask,LM_LuckyType.[Pass Type],10
FROM LM_List 
INNER JOIN LM_LuckyType  ON LM_LuckyType.Ask = LM_List.[Lucky Type]
WHERE LM_List.TS <> 6' 
DECLARE @number VARCHAR(3)
DECLARE @round6 VARCHAR(MAX)
SET @number = SUBSTRING(@List,1,1) + SUBSTRING(@List,2,1) + SUBSTRING(@List,3,1);				 
SET @round6 = '(' + '[List Code] = ' + @number
SET @number = SUBSTRING(@List,1,1) + SUBSTRING(@List,3,1) + SUBSTRING(@List,2,1);
SET @round6 += ' OR [List Code] = ' + @number
SET @number = SUBSTRING(@List,2,1) + SUBSTRING(@List,1,1) + SUBSTRING(@List,3,1); 	
SET @round6 += ' OR [List Code] = ' + @number	
SET @number = SUBSTRING(@List,2,1) + SUBSTRING(@List,3,1) + SUBSTRING(@List,1,1);
SET @round6 += ' OR [List Code] = ' + @number 	
SET @number = SUBSTRING(@List,3,1) + SUBSTRING(@List,1,1) + SUBSTRING(@List,2,1);
SET @round6 += ' OR [List Code] = ' + @number
SET @number = SUBSTRING(@List,3,1) + SUBSTRING(@List,2,1) + SUBSTRING(@List,1,1);
SET @round6 += ' OR [List Code] = ' + @number + ')'
SET @query= @query + ' AND ' +	@round6;
--SELECT 'ROUND6'
--SELECT @query	
EXEC sp_executesql @query


--SELECT 'RESULT'
--SELECT * FROM #LM_Result


CREATE TABLE #LM_Gain(
	[Ask] [bigint] NOT NULL DEFAULT(0),
	[TS] [smallint] NOT NULL DEFAULT(0),
	[UD] [bigint] NOT NULL DEFAULT(0),
	[HeaderASK] [bigint] NOT NULL DEFAULT(0),
	[ListASK] [bigint] NOT NULL DEFAULT(0),
	[Amount] [decimal](18, 10) NOT NULL DEFAULT(0),
	[Status] [smallint] NOT NULL DEFAULT(0),
	[ToPay] [decimal](18, 2) NOT NULL DEFAULT(0),
	[Comfirm] [smallint] NOT NULL DEFAULT(0),
	[Lucky Type] [bigint] NOT NULL DEFAULT(0),
	[Period] [bigint] NOT NULL DEFAULT(0),
	[GAIN/LOSS] [bigint] NOT NULL DEFAULT(0),
	[GainType]  [smallint] NOT NULL DEFAULT(0),
	[GainTypeDes]  [nvarchar](255) NOT NULL DEFAULT(''),
) 


--GETTING ALL SUBMITTED
INSERT INTO #LM_Gain ([Ask],[TS],[UD],[HeaderASK],[ListASK],[Amount],[Status],[ToPay],[Comfirm],[Lucky Type],
[Period],[GAIN/LOSS] ) 
SELECT 0,0,0, [LM_SubmitHeader].[Ask],[LM_SubmitDetail].[List],[LM_SubmitDetail].[Amount],0 
,0
,0 
,[LM_SubmitHeader].[Lucky Type] AS TYPEASK
,[LM_SubmitHeader].[Period] AS PeriodASK
,0
FROM [LM_SubmitDetail]
INNER JOIN [LM_SubmitHeader] ON [LM_SubmitDetail].[HeaderASK] = [LM_SubmitHeader].[Ask]
--INNER JOIN #LM_Result ON [LM_SubmitDetail].ListASK = #LM_Result.ListASK
WHERE [LM_SubmitDetail].TS <> 6
AND [LM_SubmitHeader].[Period] = CONVERT(NVARCHAR, @PeridoAsk)
AND [LM_SubmitHeader].[Lucky Type] =  CONVERT(NVARCHAR, @TypeAsk)


--SELECT 'ALL DETAIL'
--SELECT * FROM #LM_Gain
--SELECT * FROM #LM_Result


UPDATE #LM_Gain SET #LM_Gain.[ToPay] = 
CASE WHEN (#LM_Result.[Pass Type] =1) THEN   (#LM_Gain.Amount * #LM_Result.PASS)
WHEN (#LM_Result.[Pass Type] = 0) THEN (#LM_Gain.Amount * (#LM_Result.PASS/100)) 
ELSE (#LM_Gain.Amount) END
,#LM_Gain.[GAIN/LOSS]= 1
,#LM_Gain.[GainType] = #LM_Result.[ResultType]
,#LM_Gain.[Status] = 1
,#LM_Gain.[GainTypeDes] = 
CASE WHEN (#LM_Result.[ResultType] =  1 ) THEN   'EXACT'
WHEN (#LM_Result.[ResultType] =  2) THEN 'UP/DOWN' 
WHEN (#LM_Result.[ResultType] =  3) THEN 'ROUND' 
ELSE 'LOSE' END
FROM #LM_Result WHERE #LM_Result.ListASK = #LM_Gain.[ListASK]
AND #LM_Result.LuckyTypeAsk = #LM_Gain.[Lucky Type]


UPDATE #LM_Gain SET 
#LM_Gain.[GainTypeDes] = 'LOSE'
WHERE #LM_Gain.[GAIN/LOSS]= 0

DELETE FROM  LM_Gain WHERE [Lucky Type] = @TypeAsk
AND Period = @PeridoAsk


INSERT INTO LM_Gain (ASK,TS,UD,Header,List,Amount,[Status],ToPay,Comfirm,[Lucky type] ,Period,[Gain Type])
SELECT dbo.[GetAsk](0),TS,UD,HeaderASK,ListASK,Amount,[Status],ToPay,Comfirm, [Lucky Type],Period,GainType
FROM #LM_Gain

--while 1<3
--begin
--SELECT dbo.[GetAsk](0)
--end

--select * from LM_Gain
--SELECT 'CALC'

SELECT * FROM LM_Gain --WHERE LM_Gain.[status]= 1
ORDER BY [status] DESC,[Gain Type] ASC ,List DESC

	
--SELECT * FROM #LM_Gain --WHERE LM_Gain.[status]= 1
--ORDER BY [status] DESC,[GainType] ASC ,ListASK DESC


END







