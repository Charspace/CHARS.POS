CREATE PROCEDURE [dbo].[CS_SP_INSERT]
@statement VARCHAR(MAX)
,@table VARCHAR(MAX)
AS

SET @statement = REPLACE(@statement,'|->',',')
DECLARE @total int= ( SELECT COUNT(*) 
					FROM INFORMATION_SCHEMA.COLUMNS 
					WHERE TABLE_NAME = @table)
DECLARE @columnsName VARCHAR(MAX) = dbo.[CS_FUN_GETCOLUMNNAME](@table) 
--DECLARE @ASK_Key VARCHAR(30)
--SET @ASK_Key = dbo.GetASK(RAND())

DECLARE @insertQuery NVARCHAR(MAX) =(
										'INSERT INTO ' + @table + '(' + @columnsName + ') ' +
										'VALUES (' + @statement + ')'
									 )
--DECLARE @insertQuery NVARCHAR(MAX) =(
--'INSERT INTO ' + @table + '(' + @columnsName + ') ' +
--'VALUES ('	+ @ASK_Key + ',' + @statement + ')'
--)
select @insertQuery
EXEC sp_executesql @insertQuery
