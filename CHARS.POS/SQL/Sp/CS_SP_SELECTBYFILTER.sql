CREATE PROCEDURE [dbo].[CS_SP_SELECTBYFILTER]
@statement VARCHAR(MAX)
,@table VARCHAR(20)
,@columnIndex INT
AS

DECLARE @total int= ( SELECT COUNT(*) 
					FROM INFORMATION_SCHEMA.COLUMNS 
					WHERE TABLE_NAME = @table)
DECLARE @columnsName VARCHAR(MAX) = DBO.CS_FUN_GETCOLUMNNAME(@table)

DECLARE @selectQuery NVARCHAR(MAX) =(
									'SELECT ' + @columnsName + ' FROM ' + @table + 
									 ' WHERE ' + dbo.[CS_FUN_GETINDEXCOLUMNVALUEPAIR](@columnsName,@statement,@total,@columnIndex)
									)	
									--select 		@selectQuery						
EXEC sp_executesql @selectQuery

