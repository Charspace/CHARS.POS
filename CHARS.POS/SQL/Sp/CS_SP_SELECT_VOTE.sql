CREATE PROCEDURE [dbo].[CS_SP_SELECT_VOTE]
@TypeAsk BIGINT=0,
@StartDate nVARCHAR(8),
@DendDate nVARCHAR(8)
AS
BEGIN

SELECT * FROM LM_LIST WHERE [Lucky Type]=  @TypeAsk
AND [Start Date]  BETWEEN @StartDate AND @DendDate
AND [End Date] BETWEEN @StartDate AND @DendDate 

END







