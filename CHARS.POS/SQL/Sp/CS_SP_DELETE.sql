CREATE PROCEDURE [dbo].[CS_SP_DELETE]
@statement VARCHAR(Max)
,@table VARCHAR(20)
,@columnIndex INT
AS

DECLARE @total int= ( SELECT COUNT(*) 
					FROM INFORMATION_SCHEMA.COLUMNS 
					WHERE TABLE_NAME = @table)
DECLARE @columnsName VARCHAR(200) = [dbo].[CS_FUN_GETCOLUMNNAME](@table)

DECLARE @deleteQuery NVARCHAR(MAX) =(
									'DELETE FROM ' + @table + 
									 ' WHERE ' + [dbo].[CS_FUN_GETINDEXCOLUMNVALUEPAIR](@columnsName,@statement,@total,@columnIndex)
									)

EXEC sp_executesql @deleteQuery

