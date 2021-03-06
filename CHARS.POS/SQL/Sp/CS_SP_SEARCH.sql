CREATE PROCEDURE [dbo].[CS_SP_SEARCH]
@condition VARCHAR(MAX)
,@table VARCHAR(20)
AS

DECLARE @columnsName VARCHAR(MAX) = [dbo].[CS_FUN_GETCOLUMNNAME](@table)

IF @condition = ''
   BEGIN
		SET @condition = '1 = 1'
   END

DECLARE @selectQuery NVARCHAR(MAX) =(
									'SELECT ' + @columnsName + ' FROM ' + @table + 
									 ' WHERE ' + @condition 
									)									
EXEC sp_executesql @selectQuery
