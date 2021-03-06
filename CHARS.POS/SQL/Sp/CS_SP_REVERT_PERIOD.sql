CREATE PROCEDURE [dbo].[CS_SP_REVERT_PERIOD]
@PeridoAsk nVARCHAR(255)
AS

BEGIN

DECLARE @query NVARCHAR(MAX)=''
DECLARE @LuckyType int=0
DECLARE @List NVARCHAR(5)=''
DECLARE @StartDate nVARCHAR(8)=''
DECLARE @EndDate nVARCHAR(8)=''
DECLARE @ResultCount int =0
DECLARE @TypeAsk BIGINT=0

SELECT @TypeAsk= [Lucky Type],@StartDate= [Start Date] , @EndDate =[End Date] FROM LM_Period WHERE ASK = @PeridoAsk
SELECT @ResultCount =[Number of Pass] FROM LM_LuckyType WHERE ASK = @TypeAsk

DELETE FROM  LM_Gain WHERE [Lucky Type] = @TypeAsk
AND Period = @PeridoAsk

--UPDATE STATUS TO PROCESS
BEGIN 
UPDATE LM_SubmitHeader SET [Status] =0 
WHERE [Period] = @PeridoAsk
UPDATE LM_SubmitDetail SET [Status] =0 
FROM LM_SubmitHeader WHERE LM_SubmitHeader.Ask = LM_SubmitDetail.HeaderASK
AND LM_SubmitHeader.[Period] = @PeridoAsk
UPDATE LM_Result SET [Status] =0 WHERE [Period]=@PeridoAsk
UPDATE LM_Period SET [Status] =0 WHERE ASK = @PeridoAsk
END


SELECT * FROM LM_Period WHERE ASK = @PeridoAsk
END
