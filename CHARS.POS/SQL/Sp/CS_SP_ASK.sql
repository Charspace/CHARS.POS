CREATE PROCEDURE [dbo].[CS_SP_ASK]
AS	
DECLARE @Ask int=0
select  @Ask = max(ask) +1 from ASK
insert into ASK 
values(@Ask)
select @Ask


	
	
------------------------------------------------------------------


------------------------------------------------------------------


------------------------------------------------------------------


------------------------------------------------------------------





GO


