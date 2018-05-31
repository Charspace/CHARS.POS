CREATE PROCEDURE [dbo].[CS_SP_SELECT_SUBMIT_DETAIL_INFO]
@headerASK VARCHAR(50)
,@StartDate nVARCHAR(8)
,@EndDate nVARCHAR(8) 
AS

SELECT 
L.Ask
,L.[List Code]
,L.[List Description]
,D.Amount
FROM LM_List AS L
,LM_SubmitDetail AS D
WHERE L.ASK = D.List
AND HeaderASK = @headerASK
AND L.[Start Date] <  @StartDate
AND  L.[End Date] >  @EndDate 


