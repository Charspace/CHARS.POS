 CREATE PROCEDURE [dbo].[CS_SP_SELECT_LIST]
@SD nVARCHAR(20)=''
,@LuckyTypeAsk Bigint=0
AS	
BEGIN
SELECT * FROM LM_List WHERE  [Lucky Type] = @LuckyTypeAsk and [Start Date] = @SD
END
