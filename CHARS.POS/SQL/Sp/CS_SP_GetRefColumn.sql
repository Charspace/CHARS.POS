CREATE PROCEDURE [dbo].[CS_SP_GetRefColumn]
@tableName VARCHAR(20)
,@columnName VARCHAR(20)
AS	

DECLARE @refTable VARCHAR(20)
DECLARE @refColumn VARCHAR(20)

SELECT @refTable = object_name(rkeyid) 
,@refColumn = c2.name 
FROM
SYS.SYSFOREIGNKEYS s
INNER JOIN SYS.SYSCOLUMNS AS c1
ON ( s.fkeyid = c1.id And s.fkey = c1.colid )
INNER JOIN SYS.SYSCOLUMNS AS c2
ON ( s.rkeyid = c2.id And s.rkey = c2.colid )
WHERE object_name(fkeyid) = @tableName
AND c1.name = @columnName

DECLARE @statement NVARCHAR(MAX)

SET @statement = 'SELECT ' + @refColumn + ',' +
                 dbo.CS_FUN_GetColumnNameByIndex(@refTable,4)  +
                 ' FROM ' + @refTable

EXEC sp_executesql @statement






