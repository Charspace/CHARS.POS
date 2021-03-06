CREATE PROCEDURE [dbo].[CS_SP_SELECT]
@statement VARCHAR(MAX)
,@table VARCHAR(MAX)
AS	
DECLARE @result VARCHAR(20) = ''
DECLARE @condition VARCHAR(MAX) = ''
DECLARE @selectQuery NVARCHAR(MAX)

IF (@statement != '')
	BEGIN									--IF (@statement != '')
		WHILE (@statement != @result)			
			BEGIN							--WHILE (@statement != @result)
				SET @result = dbo.GetFirstWord(@statement,',')	
				IF (LEN(@statement) > (LEN(@result)))
					BEGIN
						SET @statement = SUBSTRING(@statement,LEN(@result) + 2,LEN(@statement))
					END	

				IF (@condition = '')
					BEGIN					--IF (@condition = '')
						SET @condition = 'WHERE (' +  
							(
								SELECT COLUMN_NAME 
								FROM INFORMATION_SCHEMA.COLUMNS 
								WHERE TABLE_NAME = @table 
								AND ORDINAL_POSITION = LEFT(@result,CHARINDEX('-',@result) - 1)
							) +
							' ' +
							SUBSTRING(@result,LEN(LEFT(@result,CHARINDEX('-',@result))) + 1,LEN(@result)) +
							')'					 
					END						--IF (@condition = '')	
				ELSE
					BEGIN					--IF (@condition = '')
						SET @condition = @condition + 
									' AND (' +
									(
										SELECT COLUMN_NAME 
										FROM INFORMATION_SCHEMA.COLUMNS 
										WHERE TABLE_NAME = @table 
										AND ORDINAL_POSITION = LEFT(@result,CHARINDEX('-',@result) - 1)
									) + 
									' ' +												
									SUBSTRING(@result,LEN(LEFT(@result,CHARINDEX('-',@result))) + 1,LEN(@result)) +
									')'
					END						--IF (@condition = '')
			END								--WHILE (@statement != @result)

			SET @selectQuery = 'SELECT ' + 
							dbo.[CS_FUN_GETCOLUMNNAME](@table) +
							' FROM ' +
							@table +
							' ' +
							@condition
	END										--IF (@statement != '')
ELSE
	BEGIN									--IF (@statement == '')
			SET @selectQuery = 'SELECT ' + 
							dbo.[CS_FUN_GETCOLUMNNAME](@table) +
							' FROM ' +
							@table
	END										--IF (@statement == '')	

SET @selectQuery =@selectQuery + ' order by ASK asc' 
--select @selectQuery
EXEC sp_executesql @selectQuery
	
	
------------------------------------------------------------------


------------------------------------------------------------------


------------------------------------------------------------------


------------------------------------------------------------------




