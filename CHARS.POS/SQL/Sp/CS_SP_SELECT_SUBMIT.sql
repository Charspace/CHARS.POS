CREATE PROCEDURE [dbo].[CS_SP_SELECT_SUBMIT]
@PeriodAsk Bigint=0
,@LuckyTypeAsk Bigint=0
AS	
BEGIN
SELECT * FROM [LM_SubmitHeader] WHERE  [Lucky Type]= @LuckyTypeAsk and [Period] = @PeriodAsk
END





