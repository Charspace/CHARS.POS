CREATE PROCEDURE [dbo].[CS_SP_SELECT_RESULT]
--@PeriodAsk Bigint=0
@LuckyTypeAsk Bigint=0
AS	
BEGIN
SELECT * FROM [LM_Result] WHERE  [LuckyType] = @LuckyTypeAsk --and [PeriodASK] = @PeriodAsk
END





