CREATE PROCEDURE [dbo].[CS_SP_SELECT_PROCESS_RESULT]
@TypeAsk BIGINT=0,
@StartDate nVARCHAR(8),
@EndDate nVARCHAR(8),
@ResultCount INT =0
AS
BEGIN
DECLARE @query NVARCHAR(4000)

--SET @query = '
--SELECT * FROM LM_LIST WHERE [Lucky Type]= '+ CONVERT(NVARCHAR,@TypeAsk) +'
--AND [Start Date]  BETWEEN '+@StartDate+' AND '+@EndDate +
--' AND  [End Date] BETWEEN '+  @StartDate+' AND ' + @EndDate 


SET @query = ' SELECT Top '+ CONVERT(nvarchar, @ResultCount)
+ ' * FROM LM_LIST WHERE [Lucky Type]= '+ CONVERT(NVARCHAR,@TypeAsk) +'
AND [Start Date]  BETWEEN '+@StartDate+' AND '+@EndDate +
' AND  [End Date] BETWEEN '+  @StartDate+' AND ' + @EndDate 
+ ' ORDER BY NEWID() ' 
--select @query
EXEC sp_executesql @query
--SELECT * FROM #LM_List



	----Filtered By @List
	--IF ((ISNULL(@List,''))<>'')
	--BEGIN
	--		IF(@ListOperator=0)--Equal
	--		BEGIN
	--			SET @query= @query + ' AND [List Code] LIKE N''' +@List+ '''';
	--			--SET @ID=' LIKE N''' +@EmployeeID+ ''''
	--		END
	--		ELSE IF (@ListOperator=1)--Contain
	--		BEGIN
	--			SET @query= @query + ' AND [List Code] LIKE N''%' +@List+ '%''';
	--			--SET @ID=' LIKE N''%' +@EmployeeID+ '%'''
	--		END
	--		ELSE IF (@ListOperator=2)--BeginsWith
	--		BEGIN
	--			SET @query= @query + ' AND [List Code] LIKE N''' +@List+ '%''';
	--			--SET @ID=' LIKE N''' +@EmployeeID+ '%'''
	--		END
	--		ELSE IF (@ListOperator=3)--EndsWith
	--		BEGIN	
	--			SET @query= @query + ' AND [List Code] LIKE N''%' +@List+ '''';			
	--			--SET @ID=' LIKE N''%' +@EmployeeID+ ''''
	--		END
	--		ELSE
	--		BEGIN
	--			SET @query= @query ;
	--			--SET @ID='';
	--		END
	--	END

		--select  @query		
		EXEC sp_executesql @query
END







