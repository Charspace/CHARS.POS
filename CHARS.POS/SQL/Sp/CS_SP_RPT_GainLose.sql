CREATE PROCEDURE [dbo].[CS_SP_RPT_GainLose]
@LuckyTypeAsk Bigint=0,
@PeriodAsk Bigint=0,
@ListOperator INT=0,
@List nvarchar(25)='',
@AgentAsk Bigint=0,
@PlayerAsk Bigint=0,
@MasterAsk Bigint=0,
@GainType int=4
AS	
BEGIN
CREATE TABLE #Result
([Lucky Type Ask]  bigint not null default((0)), 
[Lucky Type Code]  nvarchar(255) not null default(('')),
[Period Ask]  bigint not null default((0)), 
[Period Code]  nvarchar(255) not null default(''),
[ListAsk]  bigint not null default((0)),
[List Code]  nvarchar(255) not null default(('')),
[List Desc]  nvarchar(255) not null default(''),
[Agent Ask]  bigint not null default((0)), 
[Agent Code]  nvarchar(255) not null default(''),
[Player Ask]  bigint not null default((0)), 
[Player Code]  nvarchar(255) not null default(''),
[Master Ask]  bigint not null default((0)), 
[Master Code]  nvarchar(255) not null default(''),
[Submit Code]  nvarchar(255) not null default(''),
[Submit Date]  nvarchar(255) not null default(''),
[Amount]  decimal(18,2) not null default((0)),
[Lose]  decimal(18,2) not null default((0)),
[Gain]  decimal(18,2) not null default((0)),
[Gain Type] nvarchar(255) not null default(''),
[Type] int not null default(''))


--DROP TABLE #Gain
SELECT [LM_SubmitHeader].[Lucky Type] as [Lucky Type Ask]
,'' as [Lucky Type Code] 
,[LM_SubmitHeader].Period   as [Period Ask]
,''  as [Period Code]
,LM_Gain.List as [List Ask]
,'' AS [List Code]
,SUM(LM_Gain.[Amount]) AS [Total Amount]
,SUM(LM_Gain.[ToPay]) AS [Gain/Lose]
,LM_Gain.[Gain Type] AS [Type]
,CASE WHEN (LM_Gain.[Gain Type]=1) THEN 'EXACT' WHEN (LM_Gain.[Gain Type]=2) THEN 'UP/DOWN' WHEN (LM_Gain.[Gain Type]= 3) THEN 'ROUND'
ELSE 'LOSE' END AS [Gain Type]
, [LM_SubmitHeader].Agent as [Agent Ask]
, [LM_SubmitHeader].Player as [Play Ask]
,[LM_SubmitHeader].[Master] as [Master Ask]
,[LM_SubmitHeader].[Submit Code] AS [Submit Code]
,[LM_SubmitHeader].[Submit Date] AS [Submit Date]
INTO #Gain FROM LM_Gain
INNER JOIN  [LM_SubmitHeader] ON [LM_SubmitHeader].Ask = LM_Gain.[Header]
WHERE 1=1 
AND [LM_SubmitHeader].[Period] = @PeriodAsk
AND [LM_SubmitHeader].[Lucky Type] = @LuckyTypeAsk
--AND [LM_SubmitHeader].[Agent]  = @AgentAsk
GROUP BY  [LM_SubmitHeader].[Lucky Type],[LM_SubmitHeader].Period,LM_Gain.List
,[LM_SubmitHeader].Player, [LM_SubmitHeader].[Master],LM_Gain.[Gain Type] , [LM_SubmitHeader].Agent
, [LM_SubmitHeader].Player,[LM_SubmitHeader].[Master],[LM_SubmitHeader].[Submit Code],[LM_SubmitHeader].[Submit Date]
 
 
 
INSERT INTO #Result ([Lucky Type Ask], [Lucky Type Code],[Period Ask],[Period Code]
,[ListAsk],[List Code],[List Desc],[Agent Ask],[Agent Code],[Player Ask],[Player Code],[Master Ask],[Master Code]
,[Submit Code],[Submit Date],[Amount],[Lose],[Type],[Gain Type])
SELECT [Lucky Type Ask],[Lucky Type Code],[Period Ask],[Period Code]
,[List Ask],[List Code],'',[Agent Ask],'', [Play Ask],'',[Master Ask],'',[Submit Code], [Submit Date]
,[Total Amount],[Gain/Lose],[Type],[Gain Type]
FROM #Gain
WHERE [Type]= 0 --LOSE


INSERT INTO #Result ([Lucky Type Ask], [Lucky Type Code],[Period Ask],[Period Code]
,[ListAsk],[List Code],[List Desc],[Agent Ask],[Agent Code],[Player Ask],[Player Code],[Master Ask],[Master Code]
,[Submit Code],[Submit Date],[Amount],[Gain],[Type],[Gain Type])
SELECT [Lucky Type Ask],[Lucky Type Code],[Period Ask],[Period Code]
,[List Ask],[List Code],'',[Agent Ask],'',[Play Ask],'',[Master Ask],'',[Submit Code], [Submit Date]
,[Total Amount],[Gain/Lose],[Type],[Gain Type]
FROM #Gain
WHERE [Type] IN (1,2,3) --GAIN





UPDATE #Result --LUCKY TYPE
SET #Result.[Lucky Type Code] = LM_LuckyType.[Lucky Code]
FROM LM_LuckyType	
WHERE  #Result.[Lucky Type Ask] = LM_LuckyType.Ask


UPDATE #Result --PERIOD 
SET #Result.[Period Code] =LM_Period.[Period Code]
FROM LM_Period
WHERE  #Result.[Period Ask] = LM_Period.Ask

UPDATE #Result --PLAYER
SET #Result.[Player Code] =LM_Player.[Player Code]
FROM LM_Player
WHERE  #Result.[Player Ask] = LM_Player.Ask


UPDATE #Result --Agent
SET #Result.[Agent Code] =LM_Agent.[Agent Code]
FROM LM_Agent
WHERE  #Result.[Agent Ask] = LM_Agent.Ask


UPDATE #Result --MASTER
SET #Result.[Master Code] =LM_Master.[Master Code]
FROM LM_Master
WHERE  #Result.[Master Ask] = LM_Master.Ask

UPDATE #Result --LUCKY TYPE
SET #Result.[list code] = LM_List.[List Code]
, #Result.[List Desc]= LM_List.[List Description]
FROM LM_List	
WHERE  #Result.ListAsk = LM_List.Ask




DECLARE @query NVARCHAR(max)
SET @query = ' SELECT * FROM #Result WHERE 1=1 '


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

	--Gain Type
	IF (@GainType <> 4)
	BEGIN
	SET @query= @query + ' AND #Result.[Type]= ' +  CAST(@GainType AS NVARCHAR(255)) 
	END
	
	
	--Filtered By @List
	IF ((ISNULL(@List,''))<>'')
	BEGIN
			IF(@ListOperator=0)--Equal
			BEGIN
				SET @query= @query + ' AND #Result.[List Code] LIKE N''' +@List+ '''';
				--SET @ID=' LIKE N''' +@EmployeeID+ ''''
			END
			ELSE IF (@ListOperator=1)--Contain
			BEGIN
				SET @query= @query + ' AND #Result.[List Code] LIKE N''%' +@List+ '%''';
				--SET @ID=' LIKE N''%' +@EmployeeID+ '%'''
			END
			ELSE IF (@ListOperator=2)--BeginsWith
			BEGIN
				SET @query= @query + ' AND #Result.[List Code] LIKE N''' +@List+ '%''';
				--SET @ID=' LIKE N''' +@EmployeeID+ '%'''
			END
			ELSE IF (@ListOperator=3)--EndsWith
			BEGIN	
				SET @query= @query + ' AND #Result.[List Code] LIKE N''%' +@List+ '''';			
				--SET @ID=' LIKE N''%' +@EmployeeID+ ''''
			END			
			ELSE
			BEGIN
				SET @query= @query ;
				--SET @ID='';
			END
		END		
		--SET @query= @query +  ' AND #Result.[Group Amount] <> 0'
		
		
		--select @query
				
	    EXEC sp_executesql @query 
END





