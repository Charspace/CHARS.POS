CREATE PROCEDURE [dbo].[CS_SP_SELECT_GAIN]
@PeriodAsk Bigint=0
,@LuckyTypeAsk Bigint=0
AS	
BEGIN
SELECT * FROM [LM_Gain]  WHERE  [Lucky Type] = @LuckyTypeAsk and [Period] = @PeriodAsk 
END





