CREATE PROCEDURE [dbo].[CS_SP_SELECT_PERSON]
@PersonAsk nVARCHAR(MAX)
AS
BEGIN
SELECT ISNULL( [LM_Person].Ask ,0) AS ASK
,ISNULL([LM_Master].[Ask],0) AS MasterAsk
,ISNULL([LM_Player].[Ask],0) AS PlayerAsk
,ISNULL([LM_Agent].[Ask],0) AS AgentAsk
,ISNULL( [LM_Person].[Person Name],'') AS [Person Name]
,ISNULL([LM_Person].[Person Nice Name],'') AS [Person Nice Name]
,ISNULL([LM_Person].[Person Address],'') AS [Person Address]
,ISNULL( [LM_Person].[Person Phone],'')
,ISNULL([LM_Person].[Person Email],'')
,ISNULL([LM_Person].[Person Remark],'')
,ISNULL([LM_Master].[Master Code],'') AS  [Master Code]
--,[LM_Master].[Master Description] AS [Master Description]
,ISNULL([LM_Master].[Master Phone],'') AS [Master Phone]
,ISNULL([LM_Master].[Master Email],'') AS [Master Email]
,ISNULL([LM_Player].[Player Code],'') AS [Player Code]
--,[LM_Player].[Player Description] AS [Player Description]
,ISNULL([LM_Player].[Player Phone],'') AS [Player Phone] 
,ISNULL( [LM_Player].[Player Email],'') AS [Player Email]
,ISNULL([LM_Agent].[Agent Code],'') AS [Agent Code]
--,[LM_Agent].[Agent Description] AS [Agent Description]
,ISNULL([LM_Agent].[Agent Phone],'') AS [Agent Phone] 
,ISNULL([LM_Agent].[Agent Email],'') AS [Agent Email]
,ISNULL([LM_Agent].[Agent Commission] ,0) AS [Agent Commission]
FROM [LM_Person]
LEFT JOIN [LM_Master]  ON [LM_Master].[Person Ask] =[LM_Person].Ask
LEFT JOIN [LM_Player]  ON [LM_Player].[Person Ask] =[LM_Person].Ask
LEFT JOIN [LM_Agent]  ON [LM_Agent].[Person Ask] =[LM_Person].Ask
--WHERE [LM_Person].Ask  =@PersonAsk 
END







