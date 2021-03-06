CREATE PROCEDURE [dbo].[CS_SP_INSERT_HISTORY]
@statement VARCHAR(MAX)
,@table VARCHAR(MAX)
,@userID VARCHAR(20)
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
										'OUTPUT INSERTED.*,' + @userID + ',' + '''ADD''' + ',' + 'CAST(GETDATE() AS VARCHAR(20))' + ' INTO ' + @table + '_History ' +
										'VALUES (' + @statement + ')'
									 )
--DECLARE @insertQuery NVARCHAR(MAX) =(
--'INSERT INTO ' + @table + '(' + @columnsName + ') ' +
--'VALUES ('	+ @ASK_Key + ',' + @statement + ')'
--)
EXEC sp_executesql @insertQuery



