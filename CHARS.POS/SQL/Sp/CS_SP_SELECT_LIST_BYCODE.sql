CREATE PROCEDURE [dbo].[CS_SP_SELECT_LIST_BYCODE]
@ListCode NVARCHAR(10)=''
AS
BEGIN
--SELECT @ListCode
SELECT * FROM LM_List WHERE [List Code] = @ListCode
END







