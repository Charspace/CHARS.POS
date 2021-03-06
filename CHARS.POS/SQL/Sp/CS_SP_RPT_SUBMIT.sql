CREATE PROCEDURE [dbo].[CS_SP_RPT_SUBMIT]
@LuckyTypeAsk Bigint=0,
@PeriodAsk Bigint=0,
@ListOperator INT=0,
@List nvarchar(25)='',

--@SubmitDateOperator INT=0,
--@StartDate nVARCHAR(8)='',
--@EndDate nVARCHAR(8)='',

@AmountOperator INT=0,
@FromAmount decimal(18,2),
@ToAmount decimal(18,2),

@AgentAsk Bigint=0,
@PlayerAsk Bigint=0,
@MasterAsk Bigint=0


AS	
BEGIN

--Declare @FilterAmt as nvarchar(255) =0
--SET @FilterAmt = @FromAmount + @ToAmount


CREATE TABLE #Result
([Lucky Type Ask]  bigint not null default((0)), 
[Lucky Type Code]  nvarchar(255) not null default(('')),
[Period Ask]  bigint not null default((0)), 
[Period Code]  nvarchar(255) not null default(''),
[ListAsk]  bigint not null default((0)),
[List Code]  nvarchar(255) not null default(('')),
[List Desc]  nvarchar(255) not null default(''),
[Group One]  nvarchar(255) not null default(''),
[Group Two]  nvarchar(255) not null default(''),
[Group Three]  nvarchar(255) not null default(''),
[Group List]  nvarchar(255) not null default(''),
[Group Amount]  decimal(18,2) not null default((0)),
[Filter Amount]  decimal(18,2) not null default((0)),
[Over Amount]  decimal(18,2) not null default((0))
)


INSERT INTO #Result
SELECT 
@LuckyTypeAsk AS [Lucky Type Ask]
,'' AS [Lucky Type Code]
,@PeriodAsk AS [Period Ask]
,'' AS [Period Code]
,LM_List.Ask AS [ListAsk]
,LM_List.[List Code] AS [List Code]
,LM_List.[List Description] AS [List Desc]
, SUBSTRING(LM_List.[List Code],1,1)  AS [Group One]
, SUBSTRING(LM_List.[List Code],1,2)  AS [Group Two]
, SUBSTRING(LM_List.[List Code],1,3)  AS [Group Three]
,LM_List.[List Code]+'-' AS [Group List]
,0.0 AS [Group Amount]
,0 as [Filter Amount] 
,0 as [Over Amount]
FROM LM_List
WHERE LM_List.[Lucky Type] = @LuckyTypeAsk -- 20151022132842356


CREATE TABLE #Detail
([Lucky Type Ask]  bigint not null default((0)), 
[Lucky Type Code]  nvarchar(255) not null default(('')),
[Period Ask]  bigint not null default((0)), 
[Period Code]  nvarchar(255) not null default(''),
[List Ask] bigint not null default((0)),
[List Code]  nvarchar(255) not null default(('')),
[Total Amount] decimal(18,2) not null default((0))
)

--select * from  #Detail
--drop table #Detail
INSERT INTO #Detail -- ([Lucky Type Ask],[Lucky Type Code],[Period Ask],[Period Code],[List Ask],[List Code],[Total Amount])
SELECT
[LM_LuckyType].Ask as [Lucky Type Ask]
,[LM_LuckyType].[Lucky Code] as [Lucky Type Code] 
,[LM_Period].Ask  as [Period Ask]
,[LM_Period].[Period Code]  as [Period Code]
, [LM_List].Ask as [List Ask]
, [LM_List].[List Code] AS [List Code]
,SUM([LM_SubmitDetail].[Amount]) AS [Total Amount]
FROM [LM_SubmitDetail]
INNER JOIN  [LM_SubmitHeader] ON [LM_SubmitHeader].Ask = [LM_SubmitDetail].[HeaderASK]
INNER JOIN [LM_List] ON [LM_List].Ask = [LM_SubmitDetail].List
INNER JOIN [LM_Period] ON [LM_Period].Ask = [LM_SubmitHeader].[Period]
INNER JOIN [LM_LuckyType] ON [LM_LuckyType].Ask = [LM_SubmitHeader].[Lucky Type]
WHERE 1=1 
AND [LM_SubmitHeader].[Period] = @PeriodAsk
AND [LM_SubmitHeader].[Lucky Type] = @LuckyTypeAsk
GROUP BY  [LM_LuckyType].[Lucky Code],[LM_Period].[Period Code], [LM_List].Ask , [LM_LuckyType].Ask, [LM_Period].Ask ,[LM_List].[List Code]
 
 --SELECT 'DETAIL'
 --SELECT * FROM #Detail

UPDATE #Result
SET #Result.[Group Amount] = #DETAIL.[Total Amount],
#Result.[Lucky Type Ask] =#Detail.[Lucky Type Ask],
#Result.[Lucky Type Code] = #Detail.[Lucky Type code],
#Result.[period ask] = #Detail.[Period Ask],
#Result.[period code] = #Detail.[Period Code]
FROM #Detail
WHERE #Result.ListAsk = #DETAIL.[LIST ASK]


 --SELECT '#Result'
 --SELECT * FROM #Result

UPDATE #Result
SET #Result.[Lucky Type Code] = LM_LuckyType.[Lucky Code]
FROM LM_LuckyType	
WHERE  #Result.[Lucky Type Ask] = LM_LuckyType.Ask

 --SELECT '#Result  LUCKY TYPE CODE'
 --SELECT * FROM #Result

UPDATE #Result
SET #Result.[Period Code] =LM_Period.[Period Code]
FROM LM_Period
WHERE  #Result.[Period Ask] = LM_Period.Ask


 --SELECT '#Result  PERIOD'
 --SELECT * FROM #Result
UPDATE #Result
SET #Result. [Over Amount] =#Result.[Group Amount] - @FromAmount,
#Result.[Filter Amount] = @FromAmount


DECLARE @query NVARCHAR(max)
SET @query = ' SELECT * FROM #Result WHERE 1=1 '


	----Agent
	--IF (@AgentAsk <> 0)
	--BEGIN

	--END

	----Player
	--IF (@AgentAsk <> 0)
	--BEGIN

	--END

	----Master
	--IF (@AgentAsk <> 0)
	--BEGIN
	--END

	--Filtered By Total Amount	
	--IF ((ISNULL(@List,''))<>'')
	--BEGIN
		IF @FromAmount <> 0
		BEGIN
			IF @AmountOperator = 1
				SET @query = @query + ' AND #Result.[Group Amount] = ' + CAST(@FromAmount AS NVARCHAR(255)) 
			ELSE IF @AmountOperator = 2
				SET @query = @query + ' AND #Result.[Group Amount] > ' + CAST(@FromAmount AS NVARCHAR(255)) 
			ELSE IF @AmountOperator = 3
				SET @query = @query + ' AND #Result.[Group Amount] < ' +  CAST(@FromAmount AS NVARCHAR(255)) 
			ELSE IF @AmountOperator = 4
				SET @query = @query + ' AND #Result.[Group Amount] >= ' + CAST(@FromAmount AS NVARCHAR(255)) 
			ELSE IF @AmountOperator = 5
				SET @query = @query + ' AND #Result.[Group Amount] <= ' + CAST(@FromAmount AS NVARCHAR(255)) 
			ELSE IF @AmountOperator = 6
			BEGIN --CAST(@DepartmentSyskey AS NVARCHAR(255))
				IF @AmountOperator <> ''
					--SET @query = @query + ' AND #Result.[Group Amount] BETWEEN ''' + @FromAmount + ''' AND ''' + @ToAmount + ''''
					SET @query = @query + ' AND #Result.[Group Amount] BETWEEN ''' +   CAST(@FromAmount AS NVARCHAR(255))   + ''' AND ''' +  CAST(@ToAmount AS NVARCHAR(255))   + ''''
			END
		END
	--END




	----Filtered By Submit Date	
	--IF @StartDate <> ''
	--BEGIN
	--	IF @StartDate <> 0
	--	BEGIN
	--		IF @SubmitDateOperator = 1
	--			SET @query = @query + ' AND T3 = ' + @StartDate
	--		ELSE IF @SubmitDateOperator = 2
	--			SET @query = @query + ' AND T3 > ' + @StartDate
	--		ELSE IF @SubmitDateOperator = 3
	--			SET @query = @query + ' AND T3 < ' + @StartDate
	--		ELSE IF @SubmitDateOperator = 4
	--			SET @query = @query + ' AND T3 >= ' + @StartDate
	--		ELSE IF @SubmitDateOperator = 5
	--			SET @query = @query + ' AND T3 <= ' + @StartDate
	--		ELSE IF @SubmitDateOperator = 6
	--		BEGIN
	--			IF @SubmitDateOperator <> ''
	--				SET @query = @query + ' AND T3 BETWEEN ''' + @StartDate + ''' AND ''' + @EndDate + ''''
	--		END
	--	END
	--END

	


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
		SET @query= @query +  ' AND #Result.[Group Amount] <> 0'
		
		
		--select @query
				
	    EXEC sp_executesql @query 
END





