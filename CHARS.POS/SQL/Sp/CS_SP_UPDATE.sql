CREATE PROCEDURE [dbo].[CS_SP_UPDATE]
@statement VARCHAR(MAX)
,@table VARCHAR(MAX)
,@columnIndex INT
AS

DECLARE @total int= ( SELECT COUNT(*) 
					FROM INFORMATION_SCHEMA.COLUMNS 
					WHERE TABLE_NAME = @table)
DECLARE @columnsName VARCHAR(MAX) = [dbo].[CS_FUN_GETCOLUMNNAME](@table)

DECLARE @updateQuery NVARCHAR(MAX) =(
									'UPDATE ' + @table + ' SET ' +
									 [dbo].[CS_FUN_GETALLCOLUMNVALUEPAIR](@columnsName,@statement,@total,@columnIndex) +
									 ' WHERE ' +[dbo].[CS_FUN_GETINDEXCOLUMNVALUEPAIR](@columnsName,@statement,@total,@columnIndex)
									)
									--select @updateQuery
EXEC sp_executesql @updateQuery
