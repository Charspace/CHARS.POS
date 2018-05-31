CREATE procedure [dbo].[CS_SP_CHECK_PERIOD]
@luckyType VARCHAR(20)
,@startDate VARCHAR(20)
,@endDate VARCHAR(20)
AS 

SELECT Ask
FROM LM_Period
WHERE 
[Lucky Type] = @luckyType
AND 
(
[Start Date] BETWEEN @startDate AND @endDate
OR
[End Date] BETWEEN @startDate AND @endDate
)	
	

