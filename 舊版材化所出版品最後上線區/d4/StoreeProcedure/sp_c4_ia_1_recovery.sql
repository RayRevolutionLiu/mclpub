/*單一發票開立單Recovery*/
CREATE proc dbo.sp_c4_ia_1_recovery 
(@iano char(8),
 @effects INT OUTPUT)  
as
begin 
set nocount on
DECLARE   @cname char(10), @tel char(12), @edate0 char(8), @yy char(02)
select @edate0 = convert(char(8),getdate(),112)
select @yy = substring(@edate0,3,2)
/*讀出iad中之細項*/
	
DECLARE  iad_cursor  CURSOR FOR  
SELECT   iad.iad_fk1, iad.iad_fk2, iad.iad_fk3
FROM     ia INNER JOIN iad ON ia.ia_syscd = iad.iad_syscd AND ia.ia_iano = iad.iad_iano
WHERE    (ia.ia_syscd = 'C4') AND (ia.ia_iano = @iano)
/* open the cursor */
open iad_cursor
DECLARE @contno char(6), @addate char(8), @adrseq char(2) 
/* get the first row from the cursor */
FETCH  NEXT FROM  iad_cursor
 INTO @contno, @addate, @adrseq

begin  distributed transaction  tran_1
    
WHILE (@@FETCH_STATUS = 0)
BEGIN
                                    
	/*將c4_adr中的fginved改為''*/
	update c4_adr
		set  adr_fginved = ''
	WHERE adr_fginved = '1' and
        adr_contno = @contno and
        adr_seq = @adrseq and
        adr_addate = @addate 
	if @@error != 0
    begin
	    set @effects=0
        rollback transaction
        return
    end

	/*讀下一筆落版資料*/
	FETCH  NEXT FROM  iad_cursor
		INTO @contno, @addate, @adrseq
END
/* delete iad*/
delete iad where iad_syscd='C4' and iad_iano=@iano
if @@error != 0
begin
    set @effects=0
    rollback transaction
    return
end
/* delete ia*/
delete ia where ia_syscd='C4' and ia_iano=@iano
if @@error != 0
begin
    set @effects=0
    rollback transaction
    return
end
set @effects=1    
commit transaction  tran_1 
CLOSE iad_cursor

DEALLOCATE iad_cursor
                       
set nocount off            
end
GO
