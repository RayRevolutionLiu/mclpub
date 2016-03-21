CREATE TRIGGER trg_c4_adr ON [dbo].[c4_adr] 
FOR INSERT, UPDATE
AS
DECLARE @fgimggot char(1), @fgurlgot char(1)
DECLARE @imgurl char(30), @navurl char(250)
select @imgurl=''
select @navurl=''
IF UPDATE (adr_imgurl) or UPDATE (adr_navurl)
BEGIN
	select @imgurl=a.adr_imgurl, @navurl=a.adr_navurl
	from c4_adr a, inserted i
	where a.adr_contno=i.adr_contno 
		and a.adr_seq=i.adr_seq 
		and a.adr_addate=i.adr_addate

	IF RTRIM(@imgurl)=''
	  select @fgimggot='0'
	else
	  select @fgimggot='1'

	IF RTRIM(@navurl)=''
	  select @fgurlgot='0'
	else
	  select @fgurlgot='1'

	update c4_adr 
	Set	adr_fgimggot=@fgimggot, adr_fgurlgot=@fgurlgot
	from	c4_adr a, inserted i
	where a.adr_contno=i.adr_contno 
		and a.adr_seq=i.adr_seq 
		and a.adr_addate=i.adr_addate
END 