/* C4大批月結的發票批次月份抓系統月份 */
CREATE proc dbo.sp_c4_add_ia_batch
(@createmen char(7), 
 @effects	int OUTPUT)  
as
begin 
set nocount on

set @effects=0

DECLARE @thismonth char(6), @maxiabseq char(6)
select @thismonth = substring(convert(char(6),getdate(),112),1,6)
select @maxiabseq =  convert(int, isnull(max(iab_iabseq), '0') )
from iab
where iab_syscd='C4' AND iab_iabdate=@thismonth
DECLARE @s_iabseq char(6)
select @maxiabseq=@maxiabseq+1 /*遞增1*/
select @s_iabseq = convert(char(6), @maxiabseq)
/* iabseq的轉換 */
select @s_iabseq =
      CASE 
         WHEN @maxiabseq > 0 and @maxiabseq < 10 THEN '00000' + @s_iabseq
         WHEN @maxiabseq > 9 and @maxiabseq < 100 THEN '0000' + @s_iabseq   
         WHEN @maxiabseq >99 and @maxiabseq < 1000 THEN '000' + @s_iabseq
         WHEN @maxiabseq > 999 and @maxiabseq < 10000 THEN '00' + @s_iabseq
         WHEN @maxiabseq > 9999 and @maxiabseq < 100000 THEN '0' + @s_iabseq
         WHEN @maxiabseq > 99999 and @maxiabseq < 1000000 THEN '' + @s_iabseq     
      END
/* 取得iab_createdate */
DECLARE @iab_createdate char(8)
select @iab_createdate = convert(char(8),getdate(),112)

begin  distributed transaction  tran_1

/*新增 iab*/
INSERT iab (iab_syscd, iab_iabdate, iab_iabseq, iab_createdate, iab_createmen)
VALUES ('C4', @thismonth, @s_iabseq, @iab_createdate, @createmen)
if @@error != 0
    begin
	    set @effects=0
        rollback transaction
        return
    end
/*新增ia, iad*/
DECLARE @contno	char(6), @imseq	char(2), @mfrno char(10)
DECLARE  ia_cursor  CURSOR FOR  
SELECT DISTINCT cont_contno, adr_imseq, im_mfrno
FROM             wk_c4_ia_prelist
ORDER BY  cont_contno, im_mfrno
/* open the cursor */
open ia_cursor
/* get the first row from the cursor */
FETCH  NEXT FROM  ia_cursor
 INTO @contno, @imseq, @mfrno

--exec sp_c4_add_ia @contno, @imseq, @thismonth, @s_iabseq

WHILE (@@FETCH_STATUS = 0)
BEGIN

    exec sp_c4_add_ia @contno, @imseq, @thismonth, @s_iabseq
	
	FETCH  NEXT FROM  ia_cursor
		INTO @contno, @imseq, @mfrno
END


commit transaction  tran_1 
set @effects=1

CLOSE ia_cursor   
DEALLOCATE ia_cursor
    
set nocount off            
end
GO