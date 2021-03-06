CREATE PROCEDURE [dbo].[CS_SP_RPT_AgentComission]
@LuckyTypeAsk Bigint=0,
@PeriodAsk Bigint=0,
@AgentAsk Bigint=0,
@PlayerAsk Bigint=0,
@MasterAsk Bigint=0,
@SubmitDateOperator INT=0,
@StartDate nVARCHAR(8)='',
@EndDate nVARCHAR(8)=''
AS	
BEGIN

CREATE TABLE #Result
([Lucky Type Ask]  bigint not null default((0)), 
[Lucky Type Code]  nvarchar(255) not null default(('')),
[Period Ask]  bigint not null default((0)), 
[Period Code]  nvarchar(255) not null default(''),
[Agent Ask]  bigint not null default((0)), 
[Agent Code]  nvarchar(255) not null default(''),
[Agent Comission]   decimal(18,2) not null default((0)),
[Player Ask]  bigint not null default((0)), 
[Player Code]  nvarchar(255) not null default(''),
[Master Ask]  bigint not null default((0)), 
[Master Code]  nvarchar(255) not null default(''),
[Submit Code]  nvarchar(255) not null default(''),
[Submit Date]  nvarchar(255) not null default(''),
--[Count]  int not null default(0),
[Amount]  decimal(18,2) not null default((0)),  
[Comission Amount] decimal(18,2) not null default((0))
)


INSERT INTO #Result ([Lucky Type Ask],[Lucky Type Code],[Period Ask],[Period Code]
,[Agent Ask],[Agent Code],[Agent Comission],[Player Ask],[Player Code],[Master Ask],[Master Code],[Submit Code]
,[Submit Date],[Amount],[Comission Amount])
SELECT [LM_SubmitHeader].[Lucky Type] as [Lucky Type Ask]
,'' as [Lucky Type Code] 
,[LM_SubmitHeader].Period   as [Period Ask]
,''  as [Period Code]
,[LM_SubmitHeader].Agent AS [Agent Ask]
,'' AS [Agent Code]
,0 AS [Agent Comission]
, [LM_SubmitHeader].Player AS [Player Ask]
,'' AS [Player Code]
, [LM_SubmitHeader].Master AS [Master Ask]
,'' AS [Master Code]
, [LM_SubmitHeader].[Submit Code] AS [Submit Code]
,[LM_SubmitHeader].[Submit Date] as [Submit Date]
,[LM_SubmitHeader].Total AS [Amount]
,[LM_SubmitHeader].Comm AS [Comission Amount]
FROM [LM_SubmitHeader]
WHERE TS <> 6  
--AND [LM_SubmitHeader].[Status] = 1
AND [LM_SubmitHeader].[Period] = @PeriodAsk
AND [LM_SubmitHeader].[Lucky Type] = @LuckyTypeAsk
 
UPDATE #Result --LUCKY TYPE
SET #Result.[Lucky Type Code] = LM_LuckyType.[Lucky Code]
FROM LM_LuckyType	
WHERE  #Result.[Lucky Type Ask] = LM_LuckyType.Ask


UPDATE #Result --PERIOD 
SET #Result.[Period Code] =LM_Period.[Period Code]
FROM LM_Period
WHERE  #Result.[Period Ask] = LM_Period.Ask

UPDATE #Result --AGENT
SET #Result.[Agent Code] =LM_Agent.[Agent Code]
, #Result.[Agent Comission] = LM_Agent.[Agent Commission]
FROM LM_Agent
WHERE  #Result.[Agent Ask] = LM_Agent.Ask

UPDATE #Result --PLAYER
SET #Result.[Player Code] =LM_Player.[Player Code]
FROM LM_Player
WHERE  #Result.[Player Ask] = LM_Player.Ask


UPDATE #Result --MASTER
SET #Result.[Master Code] =LM_Master.[Master Code]
FROM LM_Master
WHERE  #Result.[Master Ask] = LM_Master.Ask



--SELECT CONVERT(DATETIME,[Submit Date])

DECLARE @query NVARCHAR(max)
SET @query = ' SELECT [Lucky Type Ask],[Lucky Type Code],[Period Ask],[Period Code]
,[Agent Ask],[Agent Code],[Agent Comission] AS [Agent Comission],[Player Ask],[Player Code],[Master Ask],[Master Code],[Submit Code]
,CONVERT(DATETIME,[Submit Date]) AS [Submit Date] ,[Amount],[Comission Amount] 
FROM #Result WHERE 1=1 '


	--Agent
	IF (@AgentAsk <> 0)
	BEGIN
	SET @query= @query + ' AND #Result.[Agent Ask]= ' + CAST(@AgentAsk AS NVARCHAR(255)) 
	END

	--Player
	IF (@PlayerAsk <> 0)	
	BEGIN
	SET @query= @query + ' AND #Result.[Player Ask]= ' +  CAST(@PlayerAsk AS NVARCHAR(255))  
	END

	--Master
	IF (@MasterAsk <> 0)
	BEGIN
	SET @query= @query + ' AND #Result.[Master Ask]= ' +  CAST(@MasterAsk AS NVARCHAR(255)) 
	END


	
	--Filtered By Submit Date	
	IF @StartDate <> ''
	BEGIN
		IF @StartDate <> 0
		BEGIN
			IF @SubmitDateOperator = 1
				SET @query = @query + ' AND #Result.[Submit Date] = ' + @StartDate
			ELSE IF @SubmitDateOperator = 2
				SET @query = @query + ' AND #Result.[Submit Date] > ' + @StartDate
			ELSE IF @SubmitDateOperator = 3
				SET @query = @query + ' AND #Result.[Submit Date] < ' + @StartDate
			ELSE IF @SubmitDateOperator = 4
				SET @query = @query + ' AND #Result.[Submit Date] >= ' + @StartDate
			ELSE IF @SubmitDateOperator = 5
				SET @query = @query + ' AND #Result.[Submit Date] <= ' + @StartDate
			ELSE IF @SubmitDateOperator = 6
			BEGIN
				IF @SubmitDateOperator <> ''
					SET @query = @query + ' AND #Result.[Submit Date] BETWEEN ''' + @StartDate + ''' AND ''' + @EndDate + ''''
			END
		END
	END


	EXEC sp_executesql @query 

END





