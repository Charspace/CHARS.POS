CREATE PROCEDURE [dbo].[CS_SP_SELECT_DRAW]
@TypeAsk BIGINT=0,
@StartDate nVARCHAR(8),
@EndDate nVARCHAR(8),
@ListOperator INT=0,
@List nvarchar(25)=''
AS
BEGIN
DECLARE @query NVARCHAR(4000)
SET @query = '
SELECT Ask,[List Code],[List Description] FROM LM_LIST WHERE [Lucky Type]= '+ CONVERT(NVARCHAR,@TypeAsk) +'
AND  '+@StartDate +'  BETWEEN  [Start Date] AND [End Date] 
AND  '+@EndDate +'  BETWEEN  [Start Date] AND [End Date] '

--+@StartDate+' AND '+@EndDate +
--' AND   [End Date] BETWEEN '+  @StartDate+' AND ' + @EndDate + ')'
	--Filtered By @List
	IF ((ISNULL(@List,''))<>'')
	BEGIN
			IF(@ListOperator=0)--Equal
			BEGIN
				SET @query= @query + ' AND [List Code] LIKE N''' +@List+ '''';
				--SET @ID=' LIKE N''' +@EmployeeID+ ''''
			END
			ELSE IF (@ListOperator=1)--Contain
			BEGIN
				SET @query= @query + ' AND [List Code] LIKE N''%' +@List+ '%''';
				--SET @ID=' LIKE N''%' +@EmployeeID+ '%'''
			END
			ELSE IF (@ListOperator=2)--BeginsWith
			BEGIN
				SET @query= @query + ' AND [List Code] LIKE N''' +@List+ '%''';
				--SET @ID=' LIKE N''' +@EmployeeID+ '%'''
			END
			ELSE IF (@ListOperator=3)--EndsWith
			BEGIN	
				SET @query= @query + ' AND [List Code] LIKE N''%' +@List+ '''';			
				--SET @ID=' LIKE N''%' +@EmployeeID+ ''''
			END
			ELSE IF (@ListOperator=4)--rond 3
			BEGIN	
				DECLARE @round VARCHAR(MAX)
				SET @round = '(' + '[List Code] = ' + CAST( (CAST(@List AS int) - 1) AS VARCHAR(25));
				SET @round +=  ' OR [List Code] = ' + @List;
				SET @round +=  ' OR [List Code] = ' + CAST( (CAST(@List AS int) + 1) AS VARCHAR(25)) + ')';
				SET @query= @query + ' AND ' +	@round;
						
				--SET @ID=' LIKE N''%' +@EmployeeID+ ''''
			END
			ELSE IF (@ListOperator=5)--Round 6
			BEGIN	
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
			END


			ELSE IF (@ListOperator=5)--All
			BEGIN	
				SET @query= @query + ' AND [List Code] <>''0''';							
			END

			ELSE
			BEGIN
				SET @query= @query ;
				--SET @ID='';
			END
		END		
		--select 	@query
		EXEC sp_executesql @query
END





		

--SELECT * FROM LM_LIST WHERE [Lucky Type]= 20151022132842356
--AND ( [Start Date]  BETWEEN 20150301 AND 20150331 OR  [End Date] BETWEEN 20150301 AND 20150331) AND [List Code] LIKE N'11%'
