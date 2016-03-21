/*單一發票開立單Recovery*/
CREATE proc dbo.sp_c4_ia_batch_recovery 
(@iabdate	char(6),
 @iabseq	char(6),
 @effects	INT OUTPUT)  
as
begin 
set nocount on

DECLARE @iano char(8)

/*讀出ia中同一批的發票*/	
DECLARE  ia_cursor  CURSOR FOR  
SELECT   ia_iano
FROM     ia
WHERE    (ia.ia_syscd = 'C4') AND (ia.ia_iabdate = @iabdate) AND (ia.ia_iabseq = @iabseq)
/* open the cursor */
open ia_cursor
/* get the first row from the cursor */
FETCH  NEXT FROM  ia_cursor
 INTO @iano

begin  distributed transaction  tran_1
    
WHILE (@@FETCH_STATUS = 0)
BEGIN
                                    
	/*刪除單筆ia*/
	exec sp_ia_1_recovery @iano, 1
	
	/*讀下一筆落版資料*/
	FETCH  NEXT FROM  ia_cursor
	 INTO @iano
END

/* delete iab*/
delete iab where (iab_syscd = 'C4') and (iab_iabdate = @iabdate) and (iab_iabseq = @iabseq)
if @@error != 0
begin
    set @effects=0
    rollback transaction
    return
end

set @effects=1    
commit transaction  tran_1 
CLOSE ia_cursor

DEALLOCATE ia_cursor
                       
set nocount off            
end
GO
