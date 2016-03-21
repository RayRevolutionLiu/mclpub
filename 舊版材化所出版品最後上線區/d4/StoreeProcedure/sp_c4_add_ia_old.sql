/*c4大批產生發票*/
/*找出某一合約之為開發票之落版的發票開立單*/
/* adrd_fginved 已開發票開立單註記default---' '  已挑選---'v'  已產生ia ---'1' */
CREATE proc dbo.sp_c4_add_ia (@syscd char(02), @contno char(6), @imseq char(2), @iabdate char(6), @iabseq char(6))  
as
begin 
set nocount on
/*測試資料區
declare @syscd    char(02), @contno char(6), @imseq char(2)
SELECT @syscd = 'C4'
select @contno = '910009'
select @imseq = '02'  */
/* 將同一個imseq的廣告中的 t 改成 v */
DECLARE @c_adrseq CHAR(2)
DECLARE adrseq_cursor CURSOR FOR
SELECT adr_seq FROM c4_adr WHERE adr_syscd=@syscd AND adr_contno=@contno AND adr_imseq=@imseq
OPEN adrseq_cursor
FETCH NEXT FROM adrseq_cursor INTO @c_adrseq
WHILE (@@FETCH_STATUS=0)
BEGIN
	UPDATE c4_adrd SET adrd_fginved='v'
		 WHERE adrd_fginved='t' AND
		  adrd_syscd=@syscd AND adrd_contno=@contno AND adrd_adrseq=@c_adrseq
	FETCH NEXT FROM adrseq_cursor INTO @c_adrseq
END
CLOSE adrseq_cursor
DEALLOCATE adrseq_cursor
DECLARE   @cname char(10), @tel char(12), @edate0 char(8), @yy char(02)
select @edate0 = convert(char(8),getdate(),112)
select @yy = substring(@edate0,3,2)
/*讀出c4_cont*/
declare @cnt int
SELECT @cnt = count(c4_adrd.adrd_addate)  
    FROM c4_adr,   
         c4_adrd  
   WHERE ( c4_adr.adr_syscd = c4_adrd.adrd_syscd ) and  
         ( c4_adr.adr_contno = c4_adrd.adrd_contno ) and  
         ( c4_adr.adr_seq = c4_adrd.adrd_adrseq ) and  
         ( ( c4_adr.adr_syscd = @syscd ) AND  
         ( c4_adr.adr_contno = @contno ) AND  
         ( c4_adr.adr_imseq = @imseq ) AND  
         ( c4_adrd.adrd_fginved = 'v' ) )    
   
select @cnt
if @cnt = 0 
begin
   return
end 
 SELECT @cname = srspn_cname,   
                @tel = srspn_tel 
    FROM c4_cont,   
                 srspn  
   WHERE ( c4_cont.cont_empno = srspn.srspn_empno ) and      
          ( c4_cont.cont_syscd  =  @syscd ) AND  
         ( c4_cont.cont_contno  =  @contno )    
DECLARE  adr_cursor  CURSOR FOR  
  SELECT b.adrd_addate,
          a.adr_seq,  
          a.adr_imseq,   
          b.adrd_adramt,   
          b.adrd_chgamt,
          b.adrd_desamt,   
        a.adr_projno,   
        a.adr_costctr   
    FROM c4_adr   a, 
          c4_adrd  b  
   WHERE ( a.adr_syscd = b.adrd_syscd ) and  
         ( a.adr_contno = b.adrd_contno ) and  
         ( a.adr_seq = b.adrd_adrseq ) and
          (  b.adrd_fginved = 'v' and
            a.adr_contno = @contno and 
            a.adr_imseq = @imseq   )
/* open the cursor */
open adr_cursor
/* Declare some variables to hold results.*/
DECLARE @date char(8), @adrseq char(02),     
          @adramt real,   
          @chgamt real, @desamt real,   
          @projno char(10),   
          @costctr char(7),    
          @tmp_imseq char(02)
declare  @im_fgitri char(2),   
        @im_nm   char(30),   
        @im_jbti   char(12),   
        @im_zip    char(5),   
        @im_addr   char(120),   
        @im_tel    char(30),   
        @im_invcd  char(1),   
        @im_taxtp  char(1),   
        @im_mfrno char(10)
declare @amt real, @amtnet real
declare @desc char(100), @uprice real, @iaditem int, @s_iaditem char(3)
declare @first_rec int, @iaseq int, @s_iaseq char(6)
declare @iano char(8), @refno char(10)
/* get the first row from the cursor */
FETCH  NEXT FROM  adr_cursor
 INTO @date, @adrseq, @imseq, @adramt, @chgamt, @desamt, @projno, @costctr
/* select @tmp_imseq = @imseq   */
begin  distributed transaction  tran_1
/*求發票主檔之銷售額、稅額、發票金額*/
select @iaseq = 0 
SELECT @iaseq =  convert(int, max(substring(ia.ia_iano,3,6))) 
  FROM ia  
where (substring(ia.ia_iano,1,2) = @yy) and 
(ia.ia_syscd = @syscd)
select @iaseq
if @iaseq <> null
begin
select @iaseq = @iaseq + 1
end 
else
  begin 
    select @iaseq = 1
  end  
select @s_iaseq =  convert(char(6), @iaseq) 
SELECT  @s_iaseq  = 
      CASE 
         WHEN @iaseq > 0 and @iaseq < 10 THEN '00000' + @s_iaseq
         WHEN @iaseq > 9 and @iaseq < 100 THEN '0000' + @s_iaseq   
         WHEN @iaseq >99 and @iaseq < 1000 THEN '000' + @s_iaseq
         WHEN @iaseq > 999 and @iaseq < 10000 THEN '00' + @s_iaseq
         WHEN @iaseq > 9999 and @iaseq < 100000 THEN '0' + @s_iaseq     
      END  
select @iano = @yy + @s_iaseq
select @refno = @syscd + @iano 
select @yy, @s_iaseq, @iano
INSERT ia(ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat,
                 ia_invno, ia_invdate, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti,   ia_rtel,
                 ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno, ia_iabdate, ia_iabseq)
VALUES (@syscd, '', '', '', @iano, @refno, '', '', '', 0, 0, '', '', '', '', '', '', '', '', '0',  '', '', '', @cname, @tel, @syscd + @contno, @iabdate, @iabseq)
SELECT @iaditem =0
select @amt = 0
 
 
WHILE (@@FETCH_STATUS = 0)
BEGIN
                                    
SELECT @iaditem = @iaditem + 1
select @s_iaditem =  convert(char(3), @iaditem)
SELECT  @s_iaditem  = 
      CASE 
         WHEN @iaditem > 0 and @iaditem < 10 THEN '00' + @s_iaditem
         WHEN @iaditem > 9 and @iaditem < 100 THEN '0' + @s_iaditem   
      END  
SELECT @desc =  '材網廣告費' + @date 
select @uprice = @adramt + @chgamt + @desamt
select @amt = @amt + @uprice
SELECT @syscd, @iano, @s_iaditem, @contno, @date, @adrseq,  @projno, @costctr, @desc,  @uprice, @uprice
 
INSERT iad(iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, iad_fk4, iad_projno, iad_costctr, iad_desc,  iad_qty, iad_unit, iad_uprice, iad_amt  )
VALUES (@syscd, @iano, @s_iaditem, @syscd, @contno, @adrseq, @date,  @projno, @costctr, @desc,  1,  '' , @uprice, @uprice)  
update c4_adrd
  set  adrd_fginved = '1'
  WHERE adrd_fginved = 'v' and
               adrd_contno = @contno and
              adrd_adrseq = @adrseq and
              adrd_addate = @date 
FETCH  NEXT FROM  adr_cursor
 INTO @date, @adrseq, @imseq, @adramt, @chgamt, @desamt, @projno, @costctr
END
SELECT  @im_fgitri =  im_fgitri, @im_nm =  im_nm, @im_jbti =  im_jbti, @im_zip = im_zip,
               @im_addr = im_addr, @im_tel =  im_tel, @im_invcd =  im_invcd, @im_taxtp = im_taxtp, 
               @im_mfrno = im_mfrno 
    FROM invmfr
    WHERE ( invmfr.im_syscd = @syscd ) AND  
         ( invmfr.im_contno = @contno ) AND  
         ( invmfr.im_imseq = @imseq )  
UPDATE ia  
     SET ia_mfrno =  @im_mfrno,
             ia_pyat = @amt,       
             ia_fgitri = @im_fgitri,
             ia_rnm = @im_nm,
             ia_raddr = @im_addr,
             ia_rzip = @im_zip,
             ia_rjbti = @im_jbti,
             ia_rtel = @im_tel,
             ia_invcd = @im_invcd,
             ia_taxtp = @im_taxtp 
WHERE ( ia.ia_syscd = @syscd ) AND
              ( ia.ia_iano = @iano ) 
    
commit transaction  tran_1 
CLOSE adr_cursor   
                                                                                                                                 
DEALLOCATE adr_cursor
                       
set nocount off            
end

GO
