if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_RESET_C4]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_RESET_C4]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_add_1_ia_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_add_1_ia_1]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_add_adr]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_add_adr]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_add_adr_old]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_add_adr_old]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_add_cont]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_add_cont]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_add_freebk]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_add_freebk]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_add_ia]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_add_ia]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_add_ia_batch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_add_ia_batch]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_add_im]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_add_im]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_add_lost]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_add_lost]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_add_new_cont]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_add_new_cont]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_add_or]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_add_or]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_add_remail]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_add_remail]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_check_adr_slot]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_check_adr_slot]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_clean_c4_tempcont]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_clean_c4_tempcont]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_clean_c4_tempcont_all]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_clean_c4_tempcont_all]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_delete_1_freebk]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_delete_1_freebk]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_delete_1_im]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_delete_1_im]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_delete_adr]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_delete_adr]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_delete_cont]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_delete_cont]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_delete_ia_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_delete_ia_1]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_delete_ia_batch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_delete_ia_batch]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_delete_or]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_delete_or]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_fill_adcnt_block]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_fill_adcnt_block]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_get_adcnt]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_get_adcnt]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_get_adr_amounts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_get_adr_amounts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_get_adr_counts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_get_adr_counts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_get_adr_xml_data]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_get_adr_xml_data]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_get_adrpublish_fileup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_get_adrpublish_fileup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_get_cont_counts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_get_cont_counts]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_ia_1_recovery]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_ia_1_recovery]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_ia_batch_prelist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_ia_batch_prelist]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_ia_batch_recovery]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_ia_batch_recovery]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_ia_prelist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_ia_prelist]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_invbatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_invbatch]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_label_list]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_label_list]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_mail_mnt]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_mail_mnt]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_rp_ad_list]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_rp_ad_list]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_rp_adrlist]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_rp_adrlist]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_rp_getad]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_rp_getad]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_rp_getad_adr]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_rp_getad_adr]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_rpt_contlist_gendata]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_rpt_contlist_gendata]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_substract_xml_filg_log]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_substract_xml_filg_log]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_update_adcnt]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_update_adcnt]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_update_adr_fileup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_update_adr_fileup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_update_adr_lite_1]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_update_adr_lite_1]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_update_cont]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_update_cont]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_update_cont_to_be_formal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_update_cont_to_be_formal]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_update_freebk]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_update_freebk]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_update_im]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_update_im]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_update_or]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_update_or]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sp_c4_update_xml_filg_log]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_c4_update_xml_filg_log]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- ==================================
-- RESET C4 的Table，清空所有C4相關資料
-- ==================================

CREATE PROCEDURE dbo.sp_c4_RESET_C4
AS
BEGIN
SET NOCOUNT ON
BEGIN DISTRIBUTED TRANSACTION myTransaction

/* 為了保險起見，remark內容，避免誤砍 */
/*
DELETE FROM c4_adcnt
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END

DELETE FROM c4_adr
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END

DELETE FROM c4_adrd
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END

DELETE FROM c4_classes
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END

DELETE FROM c4_cont
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END

DELETE FROM c4_freebk
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END

DELETE FROM c4_lost
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END

DELETE FROM c4_or
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END

DELETE FROM c4_ramt
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END

DELETE FROM c4_remail
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END

DELETE FROM c4_xmlfilelog
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END

DELETE FROM invmfr WHERE im_syscd='C4'
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END

DELETE FROM ia WHERE ia_syscd='C4'
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END

DELETE FROM iad WHERE iad_syscd='C4'
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END

DELETE FROM iab WHERE iab_syscd='C4'
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END

DELETE FROM ias WHERE ias_syscd='C4'
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END
*/


-- Commit 
COMMIT TRANSACTION myTransaction
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/*找出某一合約之為開發票之落版的發票開立單*/
/* adr_fginved 已開發票開立單註記default---' '  已挑選---'v'  已產生ia ---'1' */
CREATE proc dbo.sp_c4_add_1_ia_1 
(@syscd char(2),
 @contno char(6), 
 @imseq char(2), 
 @createmen char(7), 	
 @effects INT OUTPUT)  
as
begin 
set nocount on
/*declare @syscd    char(02), @contno char(6), @imseq char(2)
SELECT @syscd = 'C4'
select @contno = '910009'
select @imseq = '02'  */
DECLARE   @cname char(10), @tel char(12), @edate0 char(8), @yy char(02)
select @edate0 = convert(char(8),getdate(),112)
select @yy = substring(@edate0,3,2)
/*讀出c2_cont*/
declare @cnt int, @fgitri char(2)
SELECT @cnt = COUNT(*), @fgitri = invmfr.im_fgitri
  FROM   c4_adr INNER JOIN
       invmfr ON c4_adr.adr_syscd = invmfr.im_syscd AND 
       c4_adr.adr_contno = invmfr.im_contno AND 
       c4_adr.adr_imseq = invmfr.im_imseq
  WHERE ( ( c4_adr.adr_syscd = 'C4' ) AND  
        ( c4_adr.adr_contno = @contno ) AND  
        ( c4_adr.adr_imseq = @imseq ) AND  
        ( c4_adr.adr_fginved = 'v' ) )    
  GROUP BY  invmfr.im_fgitri   
if @cnt = 0 
begin
   return
end 
---取得承辦人資料
SELECT @cname = srspn_cname,   
       @tel = srspn_tel 
  FROM c4_cont, srspn  
  WHERE ( c4_cont.cont_empno = srspn.srspn_empno ) and      
          ( c4_cont.cont_syscd  =  @syscd ) AND  
         ( c4_cont.cont_contno  =  @contno )    
---取得計劃代號及成本中心
DECLARE	@projno char(10), @costctr char(7)
select @projno = proj_projno,
		@costctr = proj_costctr
	from proj
	where proj_syscd='C4' and proj_fgitri=@fgitri
	
DECLARE  adr_cursor  CURSOR FOR  
  SELECT adr_addate,
          adr_seq,
          adr_invamt
    FROM c4_adr 
   WHERE adr_fginved = 'v' and
         adr_contno = @contno and 
         adr_imseq = @imseq 
/* open the cursor */
open adr_cursor
/* Declare some variables to hold results.*/
DECLARE @date char(8), @adrseq char(02),     
          @invamt real,   
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
 INTO @date, @adrseq, @invamt

/* select @tmp_imseq = @imseq   */
begin  distributed transaction  tran_1
/*求發票主檔之銷售額、稅額、發票金額*/
select @iaseq = 0 
SELECT @iaseq =  convert(int, max(substring(ia.ia_iano,3,6))) 
  FROM ia  
where (substring(ia.ia_iano,1,2) = @yy) and 
(ia.ia_syscd = @syscd)
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


/*新增 ia*/
INSERT ia(ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat,
                 ia_invno, ia_invdate, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti,   ia_rtel,
                 ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno, ia_iabdate, ia_iabseq  )
VALUES (@syscd, '', '', '', @iano, @refno, '', '', '', 0, 0, '', '', '', '', '', '', '', '', '0',  '', '', '', @cname, @tel, @syscd + @contno, '', '')
if @@error != 0
    begin
	    set @effects=0
        rollback transaction
        return
    end
    
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
         WHEN @iaditem > 99 THEN '' + @s_iaditem
      END  
	SELECT @desc =  '材網廣告費' + @date 
	select @amt = @amt + @invamt
---SELECT @syscd, @iano, @s_iaditem, @contno, @date, @adrseq,  @projno, @costctr, @desc,  @uprice, @uprice

	/*新增 iad*/
	INSERT iad(iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, iad_fk4, iad_projno, iad_costctr, iad_desc,  iad_qty, iad_unit, iad_uprice, iad_amt  )
	    VALUES (@syscd, @iano, @s_iaditem, @contno, @date, @adrseq, '', @projno, @costctr, @desc,  1,  '' , @invamt, @invamt)  

	if @@error != 0
    begin
	    set @effects=0
        rollback transaction
        return
    end

	/*將c4_adr中的fginved改為'1'*/
	update c4_adr
		set  adr_fginved = '1'
	WHERE adr_fginved = 'v' and
        adr_contno = @contno and
        adr_seq = @adrseq and
        adr_addate = @date 
	if @@error != 0
    begin
	    set @effects=0
        rollback transaction
        return
    end

	/*讀下一筆落版資料*/
	FETCH  NEXT FROM  adr_cursor
		INTO @date, @adrseq, @invamt
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
if @@error != 0
    begin
	    set @effects=0
        rollback transaction
        return
    end

update c4_cont
    SET cont_fgpayonce = '1'
    WHERE cont_syscd = 'C4' AND cont_contno = @contno
if @@error != 0
    begin
	    set @effects=0
        rollback transaction
        return
    end

set @effects=1
commit transaction  tran_1 
CLOSE adr_cursor   
                                                                                                                                 
DEALLOCATE adr_cursor
                       
set nocount off            
end
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/*******************************************************
	2003/05/13，新改版
	新增廣告落版
	INSERT: c4_adr
	UPDATE: c4_adcnt
******************************************************/
CREATE PROCEDURE dbo.sp_c4_add_adr
(
	@adr_contno CHAR(6),
	@adr_sdate CHAR(8), --帶狀新增，所以提供起迄日
	@adr_edate CHAR(8), 
	@adr_adcate CHAR(1), 
	@adr_keyword CHAR(2), 
	@adr_alttext VARCHAR(30), 
	@adr_imgurl VARCHAR(30), 
	@adr_navurl VARCHAR(255), 
	@adr_impr INT, 
	@adr_drafttp CHAR(1), 
	@adr_urltp CHAR(1), 
	--@adr_invamt REAL, 應該是adamt+desamt+chgamt的總和
	@adr_imseq CHAR(2),
	@adr_adamt INT, 
	@adr_desamt INT, 
	@adr_chgamt INT, 
	@adr_remark VARCHAR(50), 
	@adr_fgfixad CHAR(1),
	@fgitri CHAR(2),
	@adr_fgimggot CHAR(1),
	@adr_fgurlgot CHAR(1)
)
AS
BEGIN
SET NOCOUNT ON
BEGIN DISTRIBUTED TRANSACTION myTransaction

-- 取得目前該合約最大的編號
DECLARE @max_adrseq CHAR(2), @new_adrseq CHAR(2)
SELECT @max_adrseq=ISNULL(MAX(adr_seq), '0') FROM c4_adr WHERE adr_contno=@adr_contno
SELECT @new_adrseq=CONVERT(CHAR(2), (CONVERT(INT, @max_adrseq)+1))
SELECT @new_adrseq=
	CASE
	WHEN LEN(RTRIM(@new_adrseq))=1 THEN '0'+ @new_adrseq
	ELSE @new_adrseq
	END

-- 找出計劃代號
DECLARE @adr_projno CHAR(10), @adr_costctr CHAR(7)
IF @fgitri<>'' 
BEGIN
	--找出所內或院內的成本中心、計畫代號
	SELECT @adr_projno=proj_projno, @adr_costctr=proj_costctr FROM proj WHERE proj_syscd='C4' AND proj_fgitri=@fgitri
END
ELSE
BEGIN
	-- 院外使用另一個
	SELECT @adr_projno=proj_projno, @adr_costctr=proj_costctr FROM proj WHERE proj_syscd='C4' AND RTRIM(proj_fgitri)=''
END

-- 強制設定定播數字為20
IF @adr_fgfixad='1'
BEGIN
	SELECT @adr_impr=20
END

-----------------------
-- 跑天數LOOP
-----------------------


----- 計算廣告天數
DECLARE @d_sdate DATETIME, @d_edate DATETIME
SELECT @d_sdate=CONVERT(DATETIME, @adr_sdate, 112)
SELECT @d_edate=CONVERT(DATETIME, @adr_edate, 112)
DECLARE @days INT
SELECT @days=DATEDIFF(DAY, @d_sdate, @d_edate)+1

--更新合約的剩餘次數, 落版註記
UPDATE c4_cont 
	SET 	cont_resttm = cont_pubtm - @days,
		cont_fgpubed = '1'
 	WHERE cont_contno=@adr_contno

---- 計算平均每日廣告價格，與第一日廣告價格
---- 按照康靜怡訂定的規則每日平均價格取整數，
---- 金額扣除每日平均價格總和後的剩餘數目加入第一日的價格
---- 設計費用與換稿費用僅在廣告第一天計算
DECLARE @FirstUnitAdAmt INT, @AvgUnitAdAmt INT
SELECT @AvgUnitAdAmt=@adr_adamt/@days
--SELECT CONVERT(INT, @AvgUnitAdAmt)
SELECT @FirstUnitAdAmt=@adr_adamt- @AvgUnitAdAmt*@days + @AvgUnitAdAmt
--SELECT @FirstUnitAdAmt
DECLARE @invamt INT


	------------------------------------------------------------
	--先檢查那一天存不存在
	--不存在的話
	--由資料庫現有資料最後一天起開始補足
	------------------------------------------------------------
	DECLARE @iecode INT
	DECLARE @lastcntdate CHAR(8)
	SELECT @lastcntdate = ISNULL(MAX(cnt_date), '20030101') FROM c4_adcnt WHERE cnt_adcate=@adr_adcate
	IF @lastcntdate<@adr_sdate OR @lastcntdate<@adr_edate
	BEGIN

	--多加一天當作頭
	SELECT @lastcntdate = CONVERT(CHAR(8), DATEADD(DAY, 1, CONVERT(DATETIME, @lastcntdate, 112)), 112)
	EXEC sp_c4_fill_adcnt_block @lastcntdate, @adr_edate, @adr_adcate, @iecode
	IF @iecode = -1
	BEGIN
		--計數補完失敗
		ROLLBACK TRANSACTION
		RETURN
	END

	END



---- 新增廣告明細資料項
DECLARE @tmpdate CHAR(8)
SELECT @tmpdate=CONVERT(CHAR(8), @d_sdate, 112)

WHILE @tmpdate<=@adr_edate
BEGIN
	IF @tmpdate=@adr_sdate
	BEGIN
	--第一天，發票金額=(平均廣告+廣告金額餘數)+設計費用+換稿費用
	SELECT @invamt = @FirstUnitAdAmt + @adr_desamt + @adr_chgamt

	INSERT INTO c4_adr
	(
		adr_syscd,
		adr_contno,
		adr_seq,
		adr_addate,
		adr_adcate,
		adr_keyword,
		adr_alttext,
		adr_imgurl,
		adr_impr,
		adr_navurl,
		adr_drafttp,
		adr_urltp,
		adr_imseq, 
                adr_invamt,
		adr_adamt,
		adr_desamt,
		adr_chgamt,
		adr_remark,
		adr_projno, 
               	adr_costctr,
		adr_fginved,
		adr_fgfixad,
		adr_fgimggot,
		adr_fgurlgot,
		adr_fginvself,
		adr_fgact
	)
	VALUES
	(
		'C4',
		@adr_contno,
		@new_adrseq,
		@tmpdate,
		@adr_adcate,
		@adr_keyword,
		@adr_alttext,
		@adr_imgurl,
		@adr_impr,
		@adr_navurl,
		@adr_drafttp,
		@adr_urltp,
		@adr_imseq, 
                	@invamt,
		@FirstUnitAdAmt,
		@adr_desamt,
		@adr_chgamt,
		@adr_remark,
		@adr_projno, 
               	@adr_costctr,
		'',
		@adr_fgfixad,
		@adr_fgimggot,
		@adr_fgurlgot,
		'0',
		'0'
	)
	END
	ELSE
	BEGIN
	--第二天以後，發票金額=平均廣告+設計費用(0)+換稿費用(0), 圖檔類別=舊稿
	SELECT @invamt = @AvgUnitAdAmt + @adr_desamt + @adr_chgamt
	INSERT INTO c4_adr
	(
		adr_syscd,
		adr_contno,
		adr_seq,
		adr_addate,
		adr_adcate,
		adr_keyword,
		adr_alttext,
		adr_imgurl,
		adr_impr,
		adr_navurl,
		adr_drafttp,
		adr_urltp,
		adr_imseq, 
                	adr_invamt,
		adr_adamt,
		adr_desamt,
		adr_chgamt,
		adr_remark,
		adr_projno, 
               	adr_costctr,
		adr_fginved,
		adr_fgfixad,
		adr_fgimggot,
		adr_fgurlgot,
		adr_fginvself,
		adr_fgact
	)
	VALUES
	(
		'C4',
		@adr_contno,
		@new_adrseq,
		@tmpdate,
		@adr_adcate,
		@adr_keyword,
		@adr_alttext,
		@adr_imgurl,
		@adr_impr,
		@adr_navurl,
		'1',	---舊
		'1',	---舊
		@adr_imseq, 
                @invamt,
		@AvgUnitAdAmt,
		0,
		0,
		@adr_remark,
		@adr_projno, 
               	@adr_costctr,
		'',
		@adr_fgfixad,
		@adr_fgimggot,
		@adr_fgurlgot,
		'0',
		'0'
	)
	END
	-------------------------
	--更新計數
	-------------------------
	-- UPDATE c4_adcnt把廣告數減一
	IF @adr_keyword='h0'
	BEGIN
		UPDATE c4_adcnt SET cnt_h0=cnt_h0+@adr_impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h1'
	BEGIN
		UPDATE c4_adcnt SET cnt_h1=cnt_h1+@adr_impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h2'
	BEGIN
		UPDATE c4_adcnt SET cnt_h2=cnt_h2+@adr_impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h3'
	BEGIN
		UPDATE c4_adcnt SET cnt_h3=cnt_h3+@adr_impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h4'
	BEGIN
		UPDATE c4_adcnt SET cnt_h4=cnt_h4+@adr_impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w1'
	BEGIN
		UPDATE c4_adcnt SET cnt_w1=cnt_w1+@adr_impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w2'
	BEGIN
		UPDATE c4_adcnt SET cnt_w2=cnt_w2+@adr_impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w3'
	BEGIN
		UPDATE c4_adcnt SET cnt_w3=cnt_w3+@adr_impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w4'
	BEGIN
		UPDATE c4_adcnt SET cnt_w4=cnt_w4+@adr_impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w5'
	BEGIN
		UPDATE c4_adcnt SET cnt_w5=cnt_w5+@adr_impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adr_adcate
	END
	ELSE 
		UPDATE c4_adcnt SET cnt_w6=cnt_w6+@adr_impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adr_adcate

	--SELECT '>>'+@tmpdate，日期遞增
	SELECT @tmpdate=CONVERT(CHAR(8), DATEADD(DAY, 1, CONVERT(DATETIME, @tmpdate, 112)), 112)
END

-- Commit 
COMMIT TRANSACTION myTransaction
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/* 
	舊版....改版前:p
	新增單筆廣告，對應
	INSERT: c4_adr
	INSERT: c4_adrd
	UPDATE: c4_adcnt
*/
CREATE PROCEDURE dbo.sp_c4_add_adr_old
	@cont_contno CHAR(6),
	@adr_imseq CHAR(2), 
	@adr_sdate CHAR(8), 
	@adr_edate CHAR(8), 
	@adr_invamt REAL, 
	@adr_adcate CHAR(1), 
	@adr_keyword CHAR(2), 
	@adr_alttext VARCHAR(30), 
	@adr_imgurl VARCHAR(30), 
	@adr_drafttp CHAR(1), 
	@adr_navurl VARCHAR(255), 
	@adr_urltp CHAR(1), 
	@adr_impr INT, 
	@adr_adamt REAL, 
	@adr_desamt REAL, 
	@adr_chgamt REAL, 
	@adr_remark VARCHAR(50), 
	@adr_fgfixad CHAR(1)
AS
BEGIN
SET NOCOUNT ON
BEGIN DISTRIBUTED TRANSACTION myTransaction
-- 取得目前該合約最大的編號
DECLARE @max_adrseq CHAR(2), @new_adrseq CHAR(2)
SELECT @max_adrseq=ISNULL(MAX(adr_seq), '0') FROM c4_adr WHERE adr_contno=@cont_contno
SELECT @new_adrseq=
CASE
WHEN (CONVERT(INT, @max_adrseq)+1)<10 THEN '0'+ CONVERT(CHAR(1), (CONVERT(INT, @max_adrseq)+1))
ELSE CONVERT(CHAR(2), (CONVERT(INT, @max_adrseq)+1))
END
-- 找出計劃代號
DECLARE @adr_projno CHAR(10), @adr_costctr CHAR(7)
IF @adr_imseq='06' 
BEGIN
	-- 所內的計劃代號，成本中心
	SELECT @adr_projno=proj_projno, @adr_costctr=proj_costctr FROM proj WHERE proj_syscd='C4' AND proj_fgitri='06'
END
ELSE IF @adr_imseq='07'
BEGIN
	-- 院內的
	SELECT @adr_projno=proj_projno, @adr_costctr=proj_costctr FROM proj WHERE proj_syscd='C4' AND proj_fgitri='07'
END
ELSE
	-- 院外使用另一個
	SELECT @adr_projno=proj_projno, @adr_costctr=proj_costctr FROM proj WHERE proj_syscd='C4' AND proj_fgitri=''
-- 新增廣告
INSERT c4_adr
	(adr_syscd, adr_contno, adr_seq, adr_imseq, adr_sdate, adr_edate, 
	adr_invamt, adr_adcate, adr_keyword, adr_alttext, adr_imgurl, adr_drafttp, 
	adr_navurl, adr_urltp, adr_impr, adr_adamt, adr_desamt, adr_chgamt, 
	adr_remark, adr_projno, adr_costctr, adr_fgfixad, adr_fggot, adr_fginvself, 
	adr_fgact)
VALUES
	('C4', @cont_contno, @new_adrseq, @adr_imseq, @adr_sdate, @adr_edate, 
	@adr_invamt, @adr_adcate, @adr_keyword, @adr_alttext, @adr_imgurl, @adr_drafttp,
	@adr_navurl, @adr_urltp, @adr_impr, @adr_adamt, @adr_desamt, @adr_chgamt,
	@adr_remark, @adr_projno, @adr_costctr, @adr_fgfixad, '0', '0', '0')
-- 新增廣告明細
----- 計算廣告天數
DECLARE @d_sdate DATETIME, @d_edate DATETIME
SELECT @d_sdate=CONVERT(DATETIME, @adr_sdate, 112)
SELECT @d_edate=CONVERT(DATETIME, @adr_edate, 112)
DECLARE @days INT
SELECT @days=DATEDIFF(DAY, @d_sdate, @d_edate)+1
---- 計算平均每日廣告價格，與第一日廣告價格
---- 按照康靜怡訂定的規則每日平均價格取整數，
---- 金額扣除每日平均價格總和後的剩餘數目加入第一日的價格
---- 設計費用與換稿費用僅在廣告第一天計算
DECLARE @FirstUnitAdAmt REAL, @AvgUnitAdAmt REAL
SELECT @AvgUnitAdAmt=@adr_adamt/@days
SELECT CONVERT(INT, @AvgUnitAdAmt)
SELECT @FirstUnitAdAmt=@adr_adamt-CONVERT(INT, @AvgUnitAdAmt)*@days+CONVERT(INT, @AvgUnitAdAmt)
SELECT @FirstUnitAdAmt
---- 新增廣告明細資料項
DECLARE @tmpdate CHAR(8)
SELECT @tmpdate=CONVERT(CHAR(8), @d_sdate, 112)
WHILE @tmpdate<=@adr_edate
BEGIN
	IF @tmpdate=@adr_sdate
	BEGIN
		-- 第一天
		INSERT INTO c4_adrd VALUES ('C4', @cont_contno, @new_adrseq, @tmpdate, '0', @FirstUnitAdAmt, @adr_chgamt, @adr_desamt)
	END
	ELSE
		-- 第二天以及以後
		INSERT INTO c4_adrd VALUES ('C4', @cont_contno, @new_adrseq, @tmpdate, '0', @AvgUnitAdAmt, 0, 0)
	
	--SELECT '>>'+@tmpdate
	SELECT @tmpdate=CONVERT(CHAR(8), DATEADD(DAY, 1, CONVERT(DATETIME, @tmpdate, 112)), 112)
END
-- 更新廣告計數
---- 定義CURSOR
DECLARE @adrd_addate CHAR(8)
DECLARE adrd_cursor CURSOR FOR
	SELECT 
		adrd_addate
	FROM c4_adrd
	WHERE
		adrd_contno=@cont_contno AND
		adrd_adrseq=@new_adrseq
OPEN adrd_cursor
FETCH NEXT FROM adrd_cursor INTO @adrd_addate
-- 對於廣告的所有明細做一遍
WHILE @@FETCH_STATUS=0
BEGIN
	-- UPDATE c4_adcnt把廣告數減一	
	IF @adr_keyword='h0'
	BEGIN
		UPDATE c4_adcnt SET cnt_h0=cnt_h0+@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h1'
	BEGIN
		UPDATE c4_adcnt SET cnt_h1=cnt_h1+@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h2'
	BEGIN
		UPDATE c4_adcnt SET cnt_h2=cnt_h2+@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h3'
	BEGIN
		UPDATE c4_adcnt SET cnt_h3=cnt_h3+@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h4'
	BEGIN
		UPDATE c4_adcnt SET cnt_h4=cnt_h4+@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w1'
	BEGIN
		UPDATE c4_adcnt SET cnt_w1=cnt_w1+@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w2'
	BEGIN
		UPDATE c4_adcnt SET cnt_w2=cnt_w2+@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w3'
	BEGIN
		UPDATE c4_adcnt SET cnt_w3=cnt_w3+@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w4'
	BEGIN
		UPDATE c4_adcnt SET cnt_w4=cnt_w4+@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w5'
	BEGIN
		UPDATE c4_adcnt SET cnt_w5=cnt_w5+@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE 
		UPDATE c4_adcnt SET cnt_w6=cnt_w6+@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	--SELECT '<<'+@adrd_addate+'<<'+CONVERT(CHAR(2),@adr_impr)+'<<'++@adr_adcate
	-- 下一筆
	FETCH NEXT FROM adrd_cursor INTO @adrd_addate
END
CLOSE adrd_cursor
DEALLOCATE adrd_cursor
-- Commit 
COMMIT TRANSACTION myTransaction
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

/* 新增合約--舊 */
CREATE PROCEDURE dbo.sp_c4_add_cont
	@cont_conttp CHAR(2),
	@cont_signdate CHAR(8),
	@cont_sdate CHAR(8),
	@cont_edate CHAR(8),
	@cont_empno CHAR(7),
	@cont_aunm VARCHAR(30),
	@cont_autel VARCHAR(30),
	@cont_aufax VARCHAR(30),
	@cont_aucell VARCHAR(30),
	@cont_auemail VARCHAR(80),
	@cont_disc REAL,
	@cont_freetm INT,
	@cont_totimgtm INT,
	@cont_toturltm INT,
	@cont_pubtm INT,
	@cont_resttm INT,
	@cont_totamt REAL,
	@cont_paidamt REAL,
	@cont_restamt REAL,
	@cont_moddate CHAR(8),
	@cont_fgpayonce CHAR(1),
	@cont_fgpubed CHAR(1),
	@cont_modempno CHAR(7),
	@cont_credate CHAR(8),
	@cont_contno CHAR(6)
AS
BEGIN
	SET NOCOUNT ON
	
	UPDATE
		c4_cont
	SET
		cont_conttp = @cont_conttp,
		cont_signdate = @cont_signdate,
		cont_sdate = @cont_sdate, 
		cont_edate = @cont_edate,
		cont_empno = @cont_empno, 
		cont_aunm = @cont_aunm, 
		cont_autel = @cont_autel,
		cont_aufax = @cont_aufax, 
		cont_aucell = @cont_aucell,
		cont_auemail = @cont_auemail, 
		cont_disc = @cont_disc,
		cont_freetm = @cont_freetm, 
		cont_totimgtm = @cont_totimgtm,
		cont_toturltm = @cont_toturltm, 
		cont_pubtm = @cont_pubtm,
		cont_resttm = @cont_resttm, 
		cont_totamt = @cont_totamt,
		cont_paidamt = @cont_paidamt, 
		cont_restamt = @cont_restamt,
		cont_fgclosed = '0',				/*這裡是新增合約*/
		cont_moddate = @cont_moddate,
		cont_fgpayonce = @cont_fgpayonce, 
		cont_fgtemp = '0',					/*儲存合約就不是暫存*/
		cont_fgpubed = @cont_fgpubed, 
		cont_fgcancel = '0',				/*這裡是新增合約*/
		cont_modempno = @cont_modempno, 
		cont_credate = @cont_credate
	WHERE
		(cont_contno = @cont_contno)
	
	SET NOCOUNT OFF
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- =======================
-- 新增贈書資料
-- =======================
CREATE PROCEDURE dbo.sp_c4_add_freebk
(
	@new_contno CHAR(6),
	@fbk_bkcd CHAR(2),
	@ma_oritem CHAR(2),
	@ma_sdate CHAR(6),
	@ma_edate CHAR(6),
	@ma_pubmnt INT,
	@ma_unpubmnt INT,
	@ma_mtpcd CHAR(2),
	@fbk_fbkitem CHAR(2) OUTPUT
)
AS
BEGIN
SET NOCOUNT ON
DECLARE @new_fbkitem CHAR(2)
--SELECT @new_fbkitem='00'
BEGIN  DISTRIBUTED TRANSACTION  myTrans
-- 取得新的贈書項次編號
SELECT @new_fbkitem=CONVERT(CHAR(2), CONVERT(INT, ISNULL(MAX(fbk_fbkitem), '00'))+1)
FROM
	c4_freebk
WHERE
	fbk_syscd = 'C4' AND
	fbk_contno = @new_contno
IF @@ERROR<>0
BEGIN
	SELECT @new_fbkitem = '00'
	ROLLBACK TRANSACTION
	RETURN
END
SELECT @new_fbkitem = CASE
	WHEN LEN(@new_fbkitem) = 1 THEN '0'+@new_fbkitem
	WHEN LEN(@new_fbkitem) = 2 THEN @new_fbkitem
END
-- 新增c4_freebk贈書
INSERT INTO c4_freebk
(
	fbk_syscd, 
	fbk_contno, 
	fbk_fbkitem, 
	fbk_bkcd
)
VALUES
(
	'C4',
	@new_contno,
	@new_fbkitem,
	@fbk_bkcd
)
IF @@ERROR<>0
BEGIN
	SELECT @new_fbkitem = '00'
	ROLLBACK TRANSACTION
	RETURN
END
-- 新增c4_ramt郵寄份數
INSERT INTO c4_ramt
(
	ma_syscd,
	ma_contno,
	ma_fbkitem,
	ma_oritem,
	ma_sdate,
	ma_edate,
	ma_pubmnt,
	ma_unpubmnt,
	ma_mtpcd
)
VALUES
(
	'C4',
	@new_contno,
	@new_fbkitem,
	@ma_oritem,
	@ma_sdate,
	@ma_edate,
	@ma_pubmnt,
	@ma_unpubmnt,
	@ma_mtpcd
)
IF @@ERROR<>0
BEGIN
	SELECT @new_fbkitem = '00'
	ROLLBACK TRANSACTION
	RETURN
END
SELECT @fbk_fbkitem=@new_fbkitem
COMMIT TRANSACTION  myTrans
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/*c4大批產生發票*/
/*找出某一合約之為開發票之落版的發票開立單*/
/* adr_fginved 已開發票開立單註記default---' '  已挑選---'v'  已產生ia ---'1' */
CREATE proc dbo.sp_c4_add_ia
(@contno char(6), 
 @imseq char(2), 
 @iabdate char(6), 
 @iabseq char(6))  
as
begin 
set nocount on
/*declare @syscd    char(2), @contno char(6), @imseq char(2)
SELECT @syscd = 'C4'
select @contno = '910009'
select @imseq = '02'  */
declare @syscd    char(2)
select @syscd = 'C4'
DECLARE   @cname char(10), @tel char(12), @edate0 char(8), @yy char(02)
select @edate0 = convert(char(8),getdate(),112)
select @yy = substring(@edate0,3,2)
/*讀出c2_cont*/
declare @cnt int, @fgitri char(2)
SELECT @cnt = COUNT(*), @fgitri = invmfr.im_fgitri
  FROM   c4_adr INNER JOIN
       invmfr ON c4_adr.adr_syscd = invmfr.im_syscd AND 
       c4_adr.adr_contno = invmfr.im_contno AND 
       c4_adr.adr_imseq = invmfr.im_imseq
  WHERE ( ( c4_adr.adr_syscd = 'C4' ) AND  
        ( c4_adr.adr_contno = @contno ) AND  
        ( c4_adr.adr_imseq = @imseq ) AND  
        ( c4_adr.adr_fginved = 'v' ) )    
  GROUP BY  invmfr.im_fgitri   
if @cnt = 0 
begin
   return
end 
---取得承辦人資料
SELECT @cname = srspn_cname,   
       @tel = srspn_tel 
  FROM c4_cont, srspn  
  WHERE ( c4_cont.cont_empno = srspn.srspn_empno ) and      
          ( c4_cont.cont_syscd  =  @syscd ) AND  
         ( c4_cont.cont_contno  =  @contno )    
---取得計劃代號及成本中心
DECLARE	@projno char(10), @costctr char(7)
select @projno = proj_projno,
		@costctr = proj_costctr
	from proj
	where proj_syscd='C4' and proj_fgitri=@fgitri
	
DECLARE  adr_cursor  CURSOR FOR  
  SELECT adr_addate,
          adr_seq,
          adr_invamt
    FROM c4_adr 
   WHERE adr_fginved = 'v' and
         adr_contno = @contno and 
         adr_imseq = @imseq 
/* open the cursor */
open adr_cursor
/* Declare some variables to hold results.*/
DECLARE @date char(8), @adrseq char(02),     
          @invamt real,   
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
 INTO @date, @adrseq, @invamt

/* select @tmp_imseq = @imseq   */
---begin  distributed transaction  tran_1
/*求發票主檔之銷售額、稅額、發票金額*/
select @iaseq = 0 
SELECT @iaseq =  convert(int, max(substring(ia.ia_iano,3,6))) 
  FROM ia  
where (substring(ia.ia_iano,1,2) = @yy) and 
(ia.ia_syscd = @syscd)
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

/*新增 ia*/
INSERT ia(ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat,
                 ia_invno, ia_invdate, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti,   ia_rtel,
                 ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno, ia_iabdate, ia_iabseq  )
VALUES (@syscd, '', '', '', @iano, @refno, '', '', '', 0, 0, '', '', '', '', '', '', '', '', '0',  '', '', '', @cname, @tel, @syscd + @contno, @iabdate, @iabseq)
if @@error != 0
    begin
--	    set @effects=0
        rollback transaction
        return
    end
    
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
         WHEN @iaditem > 99 THEN '' + @s_iaditem
      END  
	SELECT @desc =  '材網廣告費' + @date 
	select @amt = @amt + @invamt
---SELECT @syscd, @iano, @s_iaditem, @contno, @date, @adrseq,  @projno, @costctr, @desc,  @uprice, @uprice

	/*新增 iad*/
	INSERT iad(iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, iad_fk4, iad_projno, iad_costctr, iad_desc,  iad_qty, iad_unit, iad_uprice, iad_amt  )
	    VALUES (@syscd, @iano, @s_iaditem, @contno, @date, @adrseq, '', @projno, @costctr, @desc,  1,  '' , @invamt, @invamt)  
	if @@error != 0
    begin
--	    set @effects=0
        rollback transaction
        return
    end

	/*將c4_adr中的fginved改為'1'*/
	update c4_adr
		set  adr_fginved = '1'
	WHERE adr_fginved = 'v' and
        adr_contno = @contno and
        adr_seq = @adrseq and
        adr_addate = @date 
	if @@error != 0
    begin
--	    set @effects=0
        rollback transaction
        return
    end

	/*讀下一筆落版資料*/
	FETCH  NEXT FROM  adr_cursor
		INTO @date, @adrseq, @invamt
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
	if @@error != 0
    begin
--	    set @effects=0
        rollback transaction
        return
    end
--set @effects=1    
---commit transaction  tran_1 
CLOSE adr_cursor   
                                                                                                                                 
DEALLOCATE adr_cursor
                       
set nocount off            
end
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

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
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- =======================
-- 新增發票廠商收件人資料
-- =======================
CREATE PROCEDURE dbo.sp_c4_add_im
(
	@im_contno CHAR( 6),
	@im_mfrno CHAR(10),
	@im_nm VARCHAR(30),
	@im_jbti CHAR(12),
	@im_addr CHAR(120),
	@im_zip CHAR(5),
	@im_tel VARCHAR(30),
	@im_fax VARCHAR(30),
	@im_cell VARCHAR(30),
	@im_email VARCHAR(80),
	@im_invcd CHAR(1),
	@im_taxtp CHAR(1),
	@im_fgitri CHAR(2),
	@ret_imseq CHAR(2) OUTPUT
)
AS
BEGIN
SET NOCOUNT ON
BEGIN  DISTRIBUTED TRANSACTION  myTrans
--取得新的發票廠商收件人序號
DECLARE @new_imseq CHAR(2)
SELECT @new_imseq=CONVERT(CHAR(6), ISNULL(MAX(im_imseq), 0)+1) FROM invmfr WHERE im_syscd='C4' AND im_contno=@im_contno
SELECT @new_imseq = CASE
	WHEN LEN(@new_imseq) = 1 THEN '0'+@new_imseq
	WHEN LEN(@new_imseq) = 2 THEN @new_imseq
END
INSERT INTO invmfr
(
	im_syscd, 
	im_contno, 
	im_imseq, 
	im_mfrno, 
	im_nm, 
	im_jbti, 
	im_zip, 
	im_addr,
	im_tel, 
	im_fax, 
	im_cell, 
	im_email, 
	im_invcd, 
	im_taxtp, 
	im_fgitri
)
VALUES
(
	'C4', 
	@im_contno, 
	@new_imseq, 
	@im_mfrno, 
	@im_nm, 
	@im_jbti, 
	@im_zip, 
	@im_addr,
	@im_tel, 
	@im_fax, 
	@im_cell, 
	@im_email, 
	@im_invcd, 
	@im_taxtp, 
	@im_fgitri
)         
SELECT @ret_imseq=@new_imseq
COMMIT TRANSACTION  myTrans
SET NOCOUNT OFF
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- ======================
-- 2003/05/27
-- 新增缺書資料
-- ======================
CREATE PROCEDURE dbo.sp_c4_add_lost
(
	@lst_contno CHAR(6),
	@lst_fbkitem CHAR(2),
	@lst_oritem CHAR(2),
	@lst_seq CHAR(2) OUTPUT
)
AS
BEGIN
SET NOCOUNT ON
BEGIN  DISTRIBUTED TRANSACTION  myTrans

-- 取得新的缺書序號
DECLARE @new_seq CHAR(2)
SELECT @new_seq=CONVERT(CHAR(2), ISNULL(MAX(lst_seq), 0)+1) FROM c4_lost WHERE lst_contno=@lst_contno
SELECT @new_seq = CASE
	WHEN LEN(@new_seq) = 1 THEN '0' +@new_seq
	ELSE @new_seq
END

-- 可以新增了
INSERT INTO dbo.c4_lost
(
	lst_syscd, 
	lst_contno, 
	lst_fbkitem, 
	lst_oritem, 
	lst_seq,
	lst_cont, 
	lst_date,
	lst_rea,
	lst_fgsent
)
VALUES
(
	'C4',
	@lst_contno,
	@lst_fbkitem,
	@lst_oritem,
	@new_seq,
	'',
	'',
	'',
	'Y'
)

-- 傳回新的補書序號
SELECT @lst_seq = @new_seq
SELECT @lst_seq

COMMIT TRANSACTION  myTrans
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- ====================
-- 新增合約，狀態為暫存
-- ====================
CREATE PROCEDURE dbo.sp_c4_add_new_cont
(
	@cont_empno CHAR(7),
	@cont_oldcontno CHAR(6),
	@cont_contno CHAR(6) OUTPUT
)
AS
BEGIN
SET NOCOUNT ON
BEGIN  DISTRIBUTED TRANSACTION  myTrans
-- 取得新的合約編號
DECLARE @new_contno CHAR(6)
SELECT @new_contno=CONVERT(CHAR(6), ISNULL(MAX(cont_contno), 0)+1) FROM c4_cont
SELECT @new_contno = CASE
	WHEN LEN(@new_contno) = 1 THEN '00000'+@new_contno
	WHEN LEN(@new_contno) = 2 THEN '0000'+@new_contno
	WHEN LEN(@new_contno) = 3 THEN '000'+@new_contno
	WHEN LEN(@new_contno) = 4 THEN '00'+@new_contno
	WHEN LEN(@new_contno) = 5 THEN '0'+@new_contno
	WHEN LEN(@new_contno) = 6 THEN @new_contno
END
-- 新增入暫存合約
INSERT INTO c4_cont
(
	cont_syscd,
	cont_contno,
	cont_empno,
	cont_credate,
	cont_oldcontno,
	cont_fgtemp
)
VALUES
(
	'C4',
	@new_contno,
	RTRIM(@cont_empno),
	CONVERT(CHAR(8), GETDATE(), 112),
	@cont_oldcontno,
	'1'
)
-- 傳回此合約的合約編號
SELECT @cont_contno = @new_contno
COMMIT TRANSACTION  myTrans
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- =======================
-- 新增收件人
-- =======================
CREATE PROCEDURE dbo.sp_c4_add_or
(
	@or_contno CHAR(6),
	@or_inm VARCHAR(40), 
	@or_nm VARCHAR(30), 
	@or_jbti VARCHAR(12), 
	@or_addr CHAR(120), 
	@or_zip CHAR(5), 
	@or_tel VARCHAR(30), 
        @or_fax VARCHAR(30), 
	@or_cell VARCHAR(30), 
	@or_email VARCHAR(80), 
	@or_fgmosea CHAR(1),
	@or_oritem CHAR(2) OUTPUT
)
AS
BEGIN
SET NOCOUNT ON
BEGIN  DISTRIBUTED TRANSACTION  myTrans
-- 取得新的收件人序號
DECLARE @new_oritem CHAR(2)
SELECT @new_oritem=CONVERT(CHAR(2), ISNULL(MAX(or_oritem), 0)+1) FROM c4_or WHERE or_syscd='C4' AND or_contno=@or_contno
SELECT @new_oritem = CASE
	WHEN LEN(@new_oritem) = 1 THEN '0'+@new_oritem
	WHEN LEN(@new_oritem) = 2 THEN @new_oritem
END
-- INSERT收件人
INSERT INTO c4_or
(
	or_syscd,
	or_contno,
	or_oritem, 
	or_inm, 
	or_nm, 
	or_jbti, 
	or_addr, 
	or_zip, 
	or_tel, 
         or_fax, 
	or_cell, 
	or_email, 
	or_fgmosea
)
VALUES
(
	'C4',
	@or_contno,
	@new_oritem,
	@or_inm, 
	@or_nm, 
	@or_jbti, 
	@or_addr, 
	@or_zip, 
	@or_tel, 
        @or_fax, 
	@or_cell, 
	@or_email, 
	@or_fgmosea
)
SELECT @or_oritem=@new_oritem
COMMIT TRANSACTION  myTrans
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- ======================
-- 2003/05/26
-- 新增補書資料
-- ======================
CREATE PROCEDURE dbo.sp_c4_add_remail
(
	@rm_contno CHAR(6),
	@rm_oritem CHAR(2),
	@rm_seq CHAR(2) OUTPUT
)
AS
BEGIN
SET NOCOUNT ON
BEGIN  DISTRIBUTED TRANSACTION  myTrans

-- 取得新的補書序號
DECLARE @new_seq CHAR(2)
SELECT @new_seq=CONVERT(CHAR(2), ISNULL(MAX(rm_seq), 0)+1) FROM c4_remail WHERE rm_contno=@rm_contno
SELECT @new_seq = CASE
	WHEN LEN(@new_seq) = 1 THEN '0' +@new_seq
	ELSE @new_seq
END

-- 可以新增了
INSERT INTO c4_remail
(
	rm_syscd,
	rm_contno,
	rm_oritem,
	rm_seq,
	rm_cont,
	rm_date,
	rm_fgsent
)
VALUES
(
	'C4',
	@rm_contno,
	@rm_oritem,
	@new_seq,
	'',		--預設不打內容
	'',		--預設不打日期
	'Y'		--預設為可寄出
)

-- 傳回新的補書序號
SELECT @rm_seq = @new_seq
SELECT @rm_seq

COMMIT TRANSACTION  myTrans
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/*
	2003/06/19
	檢查區段內的剩餘空間夠不夠
*/

CREATE PROCEDURE dbo.sp_c4_check_adr_slot
(
	@adcate CHAR(1),
	@keyword CHAR(2),
	@sdate CHAR(8),
	@edate CHAR(8),
	@impr INT,
	@impr_old INT
)
AS
BEGIN

	IF @keyword='h0'
	BEGIN
		SELECT cnt_date FROM c4_adcnt WHERE (@sdate <= cnt_date AND cnt_date<= @edate) AND cnt_adcate=@adcate AND (cnt_h0 - @impr_old + @impr) > 20
	END
	ELSE
	IF @keyword='h1'
	BEGIN
		SELECT cnt_date FROM c4_adcnt WHERE (@sdate <= cnt_date AND cnt_date<= @edate) AND cnt_adcate=@adcate AND cnt_h1 - @impr_old + @impr > 20
	END
	ELSE
	IF @keyword='h2'
	BEGIN
		SELECT cnt_date FROM c4_adcnt WHERE (@sdate <= cnt_date AND cnt_date<= @edate) AND cnt_adcate=@adcate AND cnt_h2 - @impr_old + @impr > 20
	END
	ELSE
	IF @keyword='h3'
	BEGIN
		SELECT cnt_date FROM c4_adcnt WHERE (@sdate <= cnt_date AND cnt_date<= @edate) AND cnt_adcate=@adcate AND cnt_h3 - @impr_old + @impr > 20
	END
	ELSE
	IF @keyword='h4'
	BEGIN
		SELECT cnt_date FROM c4_adcnt WHERE (@sdate <= cnt_date AND cnt_date<= @edate) AND cnt_adcate=@adcate AND cnt_h4 - @impr_old + @impr > 20
	END
	ELSE
	IF @keyword='w1'
	BEGIN
		SELECT cnt_date FROM c4_adcnt WHERE (@sdate <= cnt_date AND cnt_date<= @edate) AND cnt_adcate=@adcate AND cnt_w1 - @impr_old + @impr > 20
	END
	ELSE
	IF @keyword='w2'
	BEGIN
		SELECT cnt_date FROM c4_adcnt WHERE (@sdate <= cnt_date AND cnt_date<= @edate) AND cnt_adcate=@adcate AND cnt_w2 - @impr_old + @impr > 20
	END
	ELSE
	IF @keyword='w3'
	BEGIN
		SELECT cnt_date FROM c4_adcnt WHERE (@sdate <= cnt_date AND cnt_date<= @edate) AND cnt_adcate=@adcate AND cnt_w3 - @impr_old + @impr > 20
	END
	ELSE
	IF @keyword='w4'
	BEGIN
		SELECT cnt_date FROM c4_adcnt WHERE (@sdate <= cnt_date AND cnt_date<= @edate) AND cnt_adcate=@adcate AND cnt_w4 - @impr_old + @impr > 20
	END
	ELSE
	IF @keyword='w5'
	BEGIN
		SELECT cnt_date FROM c4_adcnt WHERE (@sdate <= cnt_date AND cnt_date<= @edate) AND cnt_adcate=@adcate AND cnt_w5 - @impr_old + @impr > 20
	END
	ELSE 
		SELECT cnt_date FROM c4_adcnt WHERE (@sdate <= cnt_date AND cnt_date<= @edate) AND cnt_adcate=@adcate AND cnt_w6 - @impr_old + @impr > 20

END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/*清除未完成的合約資料*/
CREATE PROC dbo.sp_c4_clean_c4_tempcont 
		@contno CHAR(6)
AS
BEGIN
SET NOCOUNT ON

DELETE FROM c4_classes WHERE cls_contno=@contno
DELETE FROM invmfr WHERE im_syscd='C4' AND  im_contno=@contno
DELETE FROM c4_or WHERE or_contno=@contno
DELETE FROM c4_freebk WHERE fbk_contno=@contno
DELETE FROM c4_ramt WHERE ma_contno=@contno
DELETE FROM c4_cont WHERE cont_contno=@contno

SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/*定時清除未完成殘存的合約資料*/
CREATE PROC dbo.sp_c4_clean_c4_tempcont_all
AS
BEGIN
SET NOCOUNT ON
DECLARE @contno CHAR(6)
DECLARE tmp_cursor CURSOR FOR
SELECT cont_contno FROM c4_cont WHERE cont_fgtemp='1'
OPEN tmp_cursor
FETCH NEXT FROM tmp_cursor INTO @contno
WHILE (@@FETCH_STATUS=0)
BEGIN
DELETE FROM c4_classes WHERE cls_contno=@contno
DELETE FROM invmfr WHERE im_syscd='C4' AND  im_contno=@contno
DELETE FROM c4_or WHERE or_contno=@contno
DELETE FROM c4_freebk WHERE fbk_contno=@contno
DELETE FROM c4_ramt WHERE ma_contno=@contno
DELETE FROM c4_cont WHERE cont_contno=@contno
FETCH NEXT FROM tmp_cursor INTO @contno
END
CLOSE tmp_cursor
DEALLOCATE tmp_cursor
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

-- =====================
-- 刪除單筆贈書資料(與郵寄份數)
-- =====================
CREATE PROCEDURE dbo.sp_c4_delete_1_freebk
	@new_contno CHAR(6),
	@fbk_fbkitem CHAR(2),
	@ma_oritem CHAR(2),
	@success INT OUTPUT
AS
BEGIN
SET NOCOUNT ON
SELECT @success=0
BEGIN DISTRIBUTED TRANSACTION myTransaction
/* 刪除寄件份數 */
DELETE FROM
	c4_ramt
WHERE
	ma_syscd='C4' AND
	ma_contno=@new_contno AND
	ma_fbkitem=@fbk_fbkitem AND
	ma_oritem=@ma_oritem
IF @@ERROR<>0
BEGIN
	SELECT @success = 9999
	ROLLBACK TRANSACTION
	RETURN
END
/* 刪除贈書 */
DELETE FROM
	c4_freebk
WHERE
	fbk_syscd='C4' AND
	fbk_contno=@new_contno AND
	fbk_fbkitem=@fbk_fbkitem
IF @@ERROR<>0
BEGIN
	SELECT @success = 9999
	ROLLBACK TRANSACTION
	RETURN
END
-- Commit 
COMMIT TRANSACTION myTransaction
DECLARE @c1 INT
SELECT
	@c1=COUNT(*)
FROM
	c4_freebk
WHERE
	fbk_syscd='C4' AND
	fbk_contno=@new_contno AND
	fbk_fbkitem=@fbk_fbkitem
DECLARE @c2 INT
SELECT
	@c2=COUNT(*)
FROM
	c4_ramt
WHERE
	ma_syscd='C4' AND
	ma_contno=@new_contno AND
	ma_fbkitem=@fbk_fbkitem AND
	ma_oritem=@ma_oritem
IF @c1+@c2 > 0
	BEGIN
	SELECT @success=0
	END
ELSE
	SELECT @success=1
SET NOCOUNT OFF
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- =======================
-- 刪除一個發票廠商收件人收件人
-- =======================
CREATE PROCEDURE dbo.sp_c4_delete_1_im
(
	@im_contno CHAR(6),
	@im_imseq CHAR(2),
	@effects INT OUTPUT
)
AS
BEGIN
SET NOCOUNT ON
BEGIN  DISTRIBUTED TRANSACTION  myTrans
-- 跟郵寄份數的交集
DECLARE @c1 INT
SELECT
	@c1=COUNT(*)
FROM
	c4_adr
WHERE
	adr_contno = @im_contno AND
	adr_imseq = @im_imseq
-- 取回結果
SELECT @effects = @c1
-- 如果沒有郵寄份數或者缺書用到此收件人，那就可以DELETE
IF @effects = 0
BEGIN
	DELETE FROM invmfr WHERE im_syscd='C4' AND im_contno = @im_contno AND im_imseq = @im_imseq
END
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END
COMMIT TRANSACTION  myTrans
SET NOCOUNT OFF
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/* 刪除單筆廣告，對應
	UPDATE: c4_adcnt
	DELETE: c4_adrd
	DELETE: c4_adr
*/
CREATE PROCEDURE dbo.sp_c4_delete_adr
	@adr_contno CHAR(6),
	@adr_seq CHAR(2)
AS
BEGIN
SET NOCOUNT ON
BEGIN DISTRIBUTED TRANSACTION myTransaction
-- 取出該廣告一些資料欄位
DECLARE @adr_adcate CHAR(1), @adr_keyword CHAR(2), @adr_impr INT
SELECT
	@adr_adcate=adr_adcate,
	@adr_keyword=adr_keyword,
	@adr_impr=adr_impr
FROM
	c4_adr
WHERE
	adr_contno=@adr_contno AND
	adr_seq=@adr_seq
-- 定義CURSOR
DECLARE @adrd_addate CHAR(8)
DECLARE adrd_cursor CURSOR FOR
	SELECT 
		adrd_addate
	FROM c4_adrd
	WHERE
		adrd_contno=@adr_contno AND
		adrd_adrseq=@adr_seq
OPEN adrd_cursor
FETCH NEXT FROM adrd_cursor INTO @adrd_addate
-- 對於廣告的所有明細做一遍
WHILE @@FETCH_STATUS=0
BEGIN
	-- UPDATE c4_adcnt把廣告數減一	
	IF @adr_keyword='h0'
	BEGIN
		UPDATE c4_adcnt SET cnt_h0=cnt_w6-@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h1'
	BEGIN
		UPDATE c4_adcnt SET cnt_h1=cnt_w6-@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h2'
	BEGIN
		UPDATE c4_adcnt SET cnt_h2=cnt_w6-@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h3'
	BEGIN
		UPDATE c4_adcnt SET cnt_h3=cnt_w6-@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h4'
	BEGIN
		UPDATE c4_adcnt SET cnt_h4=cnt_w6-@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w1'
	BEGIN
		UPDATE c4_adcnt SET cnt_w1=cnt_w6-@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w2'
	BEGIN
		UPDATE c4_adcnt SET cnt_w2=cnt_w6-@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w3'
	BEGIN
		UPDATE c4_adcnt SET cnt_w3=cnt_w6-@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w4'
	BEGIN
		UPDATE c4_adcnt SET cnt_w4=cnt_w6-@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w5'
	BEGIN
		UPDATE c4_adcnt SET cnt_w5=cnt_w6-@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	END
	ELSE 
		UPDATE c4_adcnt SET cnt_w6=cnt_w6-@adr_impr WHERE cnt_date=@adrd_addate AND cnt_adcate=@adr_adcate
	-- 刪除單筆adrd
	DELETE FROM c4_adrd WHERE adrd_contno=@adr_contno AND adrd_adrseq=@adr_seq AND adrd_addate=@adrd_addate
	-- 下一筆
	FETCH NEXT FROM adrd_cursor INTO @adrd_addate
END
CLOSE adrd_cursor
DEALLOCATE adrd_cursor
-- 全部明細做完了之後，刪除廣告本身
DELETE FROM c4_adr WHERE adr_contno=@adr_contno AND adr_seq=@adr_seq
-- Commit 
COMMIT TRANSACTION myTransaction
SET NOCOUNT OFF
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

/* 刪除合約，不是註銷 */
/* 用於新增合約卻又不想儲存時 */
CREATE PROCEDURE dbo.sp_c4_delete_cont
	@cont_contno CHAR(6)
AS
BEGIN
	SET NOCOUNT ON
	
	BEGIN DISTRIBUTED TRANSACTION myTransaction
	/* 刪除廣告 */
	DECLARE @adr_seq CHAR(2)
	
	DECLARE adr_cursor CURSOR FOR
	SELECT adr_seq FROM c4_adr WHERE adr_contno=@cont_contno
	
	OPEN adr_cursor
	FETCH NEXT FROM adr_cursor INTO @adr_seq
	-- 對於合約的每一個廣告進行刪除
	WHILE @@FETCH_STATUS=0
	BEGIN
		EXEC sp_c4_delete_adr @cont_contno, @adr_seq
		FETCH NEXT FROM adr_cursor INTO @adr_seq
	END
	
	CLOSE adr_cursor
	DEALLOCATE adr_cursor
	
	/* 刪除發票廠商 */
	DELETE FROM invmfr WHERE im_syscd='C4' AND im_contno=@cont_contno
	
	/* 刪除郵寄份數資料 */
	DELETE FROM c4_ramt WHERE ma_contno=@cont_contno
	
	/* 刪除贈書 */
	DELETE FROM c4_freebk WHERE fbk_contno=@cont_contno
	
	/* 刪除雜誌收件人 */
	DELETE FROM c4_or WHERE or_contno=@cont_contno	
	
	/* 刪除材料特性 應用產業 */
	DELETE FROM c4_classd WHERE clsd_contno=@cont_contno
	
	/* 最後刪除合約 */
	DELETE FROM c4_cont WHERE (cont_contno = @cont_contno)
	
	COMMIT TRANSACTION myTransaction
	
	SET NOCOUNT OFF
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/* 發票開立單回復一次付款: 找出某一次付款的發票開立資料 */
/* 未完成，勿執行 */
CREATE PROCEDURE dbo.sp_c4_delete_ia_1
	@iabdate CHAR(6), @iabseq CHAR(6)
AS
BEGIN
SET NOCOUNT ON
/*測試資料區
declare @iabdate char(6), @iabseq char(6)
select @iabdate = '200208'
select @iabseq = '000001'
*/
/* 讀出 c4_cont, invmfr 資料: 抓 @syscd, @iano, @pyat, @contno */
DECLARE ia_cursor CURSOR FOR
	SELECT         ia_syscd, RTRIM(ia_iano) AS ia_iano, ia_pyat,  RTRIM(ia_contno) AS ia_contno
	FROM             ia
	WHERE         (ia.ia_status = '') AND (ia.ia_syscd = 'C4') AND
                          (ia.ia_iabdate = @iabdate) AND (ia.ia_iabseq = @iabseq)
/* open the cursor */
OPEN ia_cursor
------Transaction
BEGIN  DISTRIBUTED TRANSACTION  tran_1
/* Declare some variables to hold results.*/
DECLARE @syscd CHAR(2), @iano CHAR(8), @pyat REAL, @contno CHAR(13)
FETCH  NEXT FROM  ia_cursor
INTO @syscd, @iano, @pyat, @contno
--select @contno = substring(@contno, 3, 6)
/* 若有 ia_cursor 資料, 則做以下之處理 */
-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
WHILE @@FETCH_STATUS = 0
BEGIN
	/* 檢查 ia_cursor 資料 */
	SELECT @syscd
	SELECT @iano
	SELECT @pyat
	SELECT @contno
	/* for loop 刪除&更新 detail */
	DECLARE iad_cursor CURSOR FOR
		SELECT          RTRIM(iad_fk2) AS iad_fk2,
				  RTRIM(iad_fk3) AS iad_fk3,
	                          RTRIM(iad_fk4) AS iad_fk4
		FROM             iad
		WHERE         (iad_syscd = 'C4') AND (iad_iano = @iano)
	OPEN iad_cursor
	/* Declare some variables to hold results.*/
	DECLARE @fk2 CHAR(10), @fk3 CHAR(10), @fk4 CHAR(10)
	FETCH  NEXT FROM  iad_cursor
	 INTO @fk2, @fk3, @fk4
	/* 若有 iad_cursor 資料, 則做以下之處理 */
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		/* 檢查 iad_cursor 資料 */
		--select @iano
		SELECT @fk2
		SELECT @fk3
		SELECT @fk4
		------ 更新 c4_adrd 之 pub_fginved= 值為 '0'
		UPDATE        c4_adrd
		SET                adrd_fginved = '0'
		WHERE         (adrd_syscd = @syscd)
			        AND (adrd_contno = RTRIM(@fk2))
			        AND (adrd_adrseq = RTRIM(@fk3))
			        AND (adrd_addate = RTRIM(@fk4))
		                
		FETCH  NEXT FROM  iad_cursor
			 INTO @fk2, @fk3, @fk4
	END
	CLOSE  iad_cursor
	DEALLOCATE  iad_cursor
	------ 刪除iad
	DELETE iad WHERE iad_syscd=@syscd
			 AND iad_iano= RTRIM(@iano)
	------ 更新 c4_cont 之 合約相關金額: cont_paidamt 值
	UPDATE c4_cont
	SET cont_paidamt=cont_paidamt-@pyat
	WHERE cont_syscd=@syscd AND cont_contno=RTRIM(substring(@contno, 3, 6))
	/*顯示*/
	SELECT cont_paidamt
	FROM c4_cont
	WHERE cont_syscd=@syscd AND cont_contno=RTRIM(substring(@contno, 3, 6))
	------ 刪除ia
	DELETE ia 
	WHERE ia_syscd=@syscd AND ia_status= ' ' AND ia_iano=RTRIM(@iano)
	------ 讀下一筆 ia
	------ This is executed as long as the previous fetch succeeds.
	FETCH  NEXT FROM  ia_cursor
		 INTO @syscd, @iano, @pyat, @contno
END
------ 刪除iab
DELETE iab
WHERE iab_syscd=@syscd AND iab_iabdate=@iabdate AND iab_iabseq=@iabseq
COMMIT TRANSACTION  tran_1
CLOSE  ia_cursor
DEALLOCATE  ia_cursor
SET NOCOUNT OFF
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/* 發票開立單回復 大批月結: 找出某一批發票開立單 */
CREATE PROCEDURE dbo.sp_c4_delete_ia_batch
	@iabdate CHAR(6), @iabseq CHAR(6)
AS
BEGIN
SET NOCOUNT ON
/*測試資料區
declare @iabdate char(6), @iabseq char(6)
select @iabdate = '200208'
select @iabseq = '000001'
*/
/* 讀出 c4_cont, invmfr 資料: 抓 @syscd, @iano, @pyat, @contno */
DECLARE ia_cursor CURSOR FOR
	SELECT         ia_syscd, RTRIM(ia_iano) AS ia_iano, ia_pyat,  RTRIM(ia_contno) AS ia_contno
	FROM             ia
	WHERE         (ia.ia_status = '') AND (ia.ia_syscd = 'C4') AND
                          (ia.ia_iabdate = @iabdate) AND (ia.ia_iabseq = @iabseq)
/* open the cursor */
OPEN ia_cursor
------Transaction
BEGIN  DISTRIBUTED TRANSACTION  tran_1
/* Declare some variables to hold results.*/
DECLARE @syscd CHAR(2), @iano CHAR(8), @pyat REAL, @contno CHAR(13)
FETCH  NEXT FROM  ia_cursor
INTO @syscd, @iano, @pyat, @contno
--select @contno = substring(@contno, 3, 6)
/* 若有 ia_cursor 資料, 則做以下之處理 */
-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
WHILE @@FETCH_STATUS = 0
BEGIN
	/* 檢查 ia_cursor 資料 */
	SELECT @syscd
	SELECT @iano
	SELECT @pyat
	SELECT @contno
	/* for loop 刪除&更新 detail */
	DECLARE iad_cursor CURSOR FOR
		SELECT          RTRIM(iad_fk2) AS iad_fk2,
				  RTRIM(iad_fk3) AS iad_fk3,
	                          RTRIM(iad_fk4) AS iad_fk4
		FROM             iad
		WHERE         (iad_syscd = 'C4') AND (iad_iano = @iano)
	OPEN iad_cursor
	/* Declare some variables to hold results.*/
	DECLARE @fk2 CHAR(10), @fk3 CHAR(10), @fk4 CHAR(10)
	FETCH  NEXT FROM  iad_cursor
	 INTO @fk2, @fk3, @fk4
	/* 若有 iad_cursor 資料, 則做以下之處理 */
	WHILE (@@FETCH_STATUS = 0)
	BEGIN
		/* 檢查 iad_cursor 資料 */
		--select @iano
		SELECT @fk2
		SELECT @fk3
		SELECT @fk4
		------ 更新 c4_adrd 之 pub_fginved= 值為 '0'
		UPDATE        c4_adrd
		SET                adrd_fginved = '0'
		WHERE         (adrd_syscd = @syscd)
			        AND (adrd_contno = RTRIM(@fk2))
			        AND (adrd_adrseq = RTRIM(@fk3))
			        AND (adrd_addate = RTRIM(@fk4))
		                
		FETCH  NEXT FROM  iad_cursor
			 INTO @fk2, @fk3, @fk4
	END
	CLOSE  iad_cursor
	DEALLOCATE  iad_cursor
	------ 刪除iad
	DELETE iad WHERE iad_syscd=@syscd
			 AND iad_iano= RTRIM(@iano)
	------ 更新 c4_cont 之 合約相關金額: cont_paidamt 值
	UPDATE c4_cont
	SET cont_paidamt=cont_paidamt-@pyat
	WHERE cont_syscd=@syscd AND cont_contno=RTRIM(substring(@contno, 3, 6))
	/*顯示*/
	SELECT cont_paidamt
	FROM c4_cont
	WHERE cont_syscd=@syscd AND cont_contno=RTRIM(substring(@contno, 3, 6))
	------ 刪除ia
	DELETE ia 
	WHERE ia_syscd=@syscd AND ia_status= ' ' AND ia_iano=RTRIM(@iano)
	------ 讀下一筆 ia
	------ This is executed as long as the previous fetch succeeds.
	FETCH  NEXT FROM  ia_cursor
		 INTO @syscd, @iano, @pyat, @contno
END
------ 刪除iab
DELETE iab
WHERE iab_syscd=@syscd AND iab_iabdate=@iabdate AND iab_iabseq=@iabseq
COMMIT TRANSACTION  tran_1
CLOSE  ia_cursor
DEALLOCATE  ia_cursor
SET NOCOUNT OFF
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- =======================
-- 刪除收件人
-- =======================
CREATE PROCEDURE dbo.sp_c4_delete_or
(
	@or_contno CHAR(6),
	@or_oritem CHAR(2),
	@effects INT OUTPUT
)
AS
BEGIN
SET NOCOUNT ON
BEGIN  DISTRIBUTED TRANSACTION  myTrans
-- 跟郵寄份數的交集
DECLARE @c1 INT
SELECT
	@c1=COUNT(*)
FROM
	c4_or
INNER JOIN
	c4_ramt ON
	or_syscd = ma_syscd AND 
        or_contno = ma_contno AND 
        or_oritem = ma_oritem
WHERE
	or_contno = @or_contno AND
	or_oritem = @or_oritem
-- 跟缺書的交集
DECLARE @c2 INT
SELECT
	@c2=COUNT(*)
FROM
	c4_or
INNER JOIN
        c4_lost ON
	c4_or.or_syscd = c4_lost.lst_syscd AND 
        c4_or.or_contno = c4_lost.lst_contno AND 
        c4_or.or_oritem = c4_lost.lst_oritem
WHERE
	or_contno = @or_contno AND
	or_oritem = @or_oritem
-- 取回結果
SELECT @effects = @c1 + @c2
-- 如果沒有郵寄份數或者缺書用到此收件人，那就可以DELETE
IF @effects = 0
BEGIN
	DELETE FROM c4_or WHERE	or_contno = @or_contno AND or_oritem = @or_oritem
END
COMMIT TRANSACTION  myTrans
SET NOCOUNT OFF
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/*******************************************************
	2003/05/16，新改版
	補足落版計數資料區段
	INSERT：c4_adcnt
******************************************************/
CREATE PROCEDURE dbo.sp_c4_fill_adcnt_block
(
	@cnt_sdate CHAR(8),	--包含此日 
	@cnt_edate CHAR(8),	--包含此日
	@cnt_adcate CHAR(1),
	@errorcode INT OUTPUT
	--錯誤訊息碼：-1：新增預設資料失敗
)
AS
BEGIN
SET NOCOUNT ON
BEGIN DISTRIBUTED TRANSACTION myTransaction

	---- 新增廣告落版計數
	DECLARE @tmpdate CHAR(8)
	--SELECT @tmpdate=CONVERT(CHAR(8), @cnt_sdate, 112)
	SELECT @tmpdate = CONVERT(CHAR(8), DATEADD(DAY, 1, CONVERT(DATETIME, @cnt_sdate, 112)), 112)

	WHILE @tmpdate<=@cnt_edate
	BEGIN

		--新增該日計數原始值
		INSERT INTO c4_adcnt
		(
			cnt_date,
			cnt_adcate,
			cnt_h0,
			cnt_h1,
			cnt_h2,
			cnt_h3,
			cnt_h4,
			cnt_w1,
			cnt_w2,
			cnt_w3,
			cnt_w4,
			cnt_w5,
			cnt_w6
		)
		VALUES
		(
			@tmpdate,
			@cnt_adcate,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		)

		--UPDATE失敗
		IF @@ERROR<>0
		BEGIN
			ROLLBACK TRANSACTION
			SELECT @errorcode=-1
			RETURN
		END

		--SELECT 'ADD>>'+@tmpdate--，日期遞增
		SELECT @tmpdate=CONVERT(CHAR(8), DATEADD(DAY, 1, CONVERT(DATETIME, @tmpdate, 112)), 112)
	END	


-- Commit 
COMMIT TRANSACTION myTransaction
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- ====================
-- 取得廣告落版計數
-- 如該月某日缺乏計數日期，則補上預設值
-- ====================
CREATE PROCEDURE dbo.sp_c4_get_adcnt
(
	@adcate CHAR(1),
	@admonth DATETIME,
	@errors INT OUTPUT
)
AS
BEGIN
SET NOCOUNT ON
BEGIN  DISTRIBUTED TRANSACTION  myTrans


--DECLARE @adcate CHAR(1)
--SELECT @adcate='M'
--DECLARE @admonth DATETIME
--SELECT @admonth=GETDATE()

SELECT @errors=0

--PRE  CHECK
DECLARE @c0 INT
SELECT
	@c0=COUNT(*)
FROM
	c4_adcnt
WHERE
	(cnt_h0<0 OR cnt_h0>20) OR
	(cnt_h1<0 OR cnt_h1>20) OR
	(cnt_h2<0 OR cnt_h2>20) OR
	(cnt_h3<0 OR cnt_h3>20) OR
	(cnt_h4<0 OR cnt_h4>20) OR
	(cnt_w1<0 OR cnt_w1>20) OR
	(cnt_w2<0 OR cnt_w2>20) OR
	(cnt_w3<0 OR cnt_w3>20) OR
	(cnt_w4<0 OR cnt_w4>20) OR
	(cnt_w5<0 OR cnt_w5>20) OR
	(cnt_w6<0 OR cnt_w6>20)

IF @c0>0
BEGIN
	SELECT @errors=-1
	RETURN
END

--VERIFY START
DECLARE @tmpdate DATETIME
SELECT @tmpdate=CONVERT(DATETIME, SUBSTRING(CONVERT(CHAR(8), @admonth, 112), 1, 6)+'01', 112)

DECLARE @c1 INT

WHILE DATEPART(mm, @tmpdate)=DATEPART(mm, @admonth)
BEGIN 
	SELECT @c1=COUNT(*) FROM c4_adcnt
	WHERE
		cnt_adcate=@adcate AND
		cnt_date=CONVERT(CHAR(8), @tmpdate, 112)

	IF @c1=0
	BEGIN
		INSERT INTO c4_adcnt (cnt_date, cnt_adcate, cnt_h0, cnt_h1, cnt_h2, cnt_h3, cnt_h4, cnt_w1, cnt_w2, cnt_w3, cnt_w4, cnt_w5, cnt_w6)
		VALUES (CONVERT(CHAR(8), @tmpdate, 112), @adcate, 0, 0, 0, 0, 0, 0, 0 ,0, 0, 0, 0)
	END

	SELECT @tmpdate = DATEADD(DAY, 1, @tmpdate)

	IF @@ERROR<>0
	BEGIN
		ROLLBACK TRANSACTION
		SELECT @errors=1
		RETURN
	END
END
--VERIFY END

--正確的SELECT
SELECT
	SUBSTRING(cnt_date, 1, 4)+'/'+SUBSTRING(cnt_date, 5, 2)+'/'+SUBSTRING(cnt_date,7, 2) AS cnt_date,
	cnt_adcate,
	cnt_h0,
	cnt_h1,
	cnt_h2,
	cnt_h3,
	cnt_h4,
	cnt_w1,
	cnt_w2,
	cnt_w3,
	cnt_w4,
	cnt_w5,
	cnt_w6
FROM
	c4_adcnt
WHERE
	cnt_adcate=@adcate AND
	DATEPART(yyyy, CONVERT(DATETIME, cnt_date, 112))=DATEPART(yyyy, @admonth) AND
	DATEPART(mm, CONVERT(DATETIME, cnt_date, 112))=DATEPART(mm, @admonth)

IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	SELECT @errors=2
	RETURN
END

COMMIT TRANSACTION  myTrans
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- =================================
-- 2003/06/11
-- 計算廣告中的廣告總金額
--			設計總金額
--			換稿總金額
-- =================================
CREATE PROCEDURE dbo.sp_c4_get_adr_amounts
(
	@adr_contno CHAR(6)
)
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @totadamt INT, @totdesamt INT, @totchgamt INT

	--BEGIN DISTRIBUTED TRANSACTION myTransaction
	-- 已廣告落版次數
	SELECT @totadamt=ISNULL(SUM(adr_adamt), 0) FROM c4_adr WHERE adr_contno=@adr_contno
	
	-- 已開立發票金額
	SELECT @totdesamt=ISNULL(SUM(adr_desamt), 0) FROM c4_adr WHERE adr_contno=@adr_contno

	-- 已刊登次數
	SELECT @totchgamt=ISNULL(SUM(adr_chgamt), 0) FROM c4_adr WHERE adr_contno=@adr_contno

	SELECT @totadamt AS totadamt, @totdesamt AS totdesamt, @totchgamt AS totchgamt
	--COMMIT TRANSACTION myTransaction
	SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- =================================
-- 2003/06/11
-- 計算合約中以用掉的(新稿+換稿)次數
-- =================================
CREATE PROCEDURE dbo.sp_c4_get_adr_counts
(
	@adr_contno CHAR(6),
	@imgtm INT OUTPUT,
	@urltm INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON

	--BEGIN DISTRIBUTED TRANSACTION myTransaction
	-- 已廣告落版次數
	SELECT @imgtm=COUNT(*) FROM c4_adr WHERE adr_contno=@adr_contno AND (adr_drafttp='2' OR adr_drafttp='3')
	
	-- 已開立發票金額
	SELECT @urltm=COUNT(*) FROM c4_adr WHERE adr_contno=@adr_contno AND (adr_urltp='2' OR adr_urltp='3')

	-- 已刊登次數
	DECLARE @pubedtm INT
	SELECT @pubedtm=COUNT(*) FROM c4_adr WHERE adr_contno=@adr_contno
	
	--首頁總落版次數
	DECLARE @totmtm INT
	SELECT @totmtm=COUNT(*) FROM c4_adr WHERE adr_contno=@adr_contno AND adr_adcate='M'

	--內頁總落版次數
	DECLARE @totitm INT
	SELECT @totitm=COUNT(*) FROM c4_adr WHERE adr_contno=@adr_contno AND adr_adcate='I'

	--奈米頁總落版次數
	DECLARE @totntm INT
	SELECT @totntm=COUNT(*) FROM c4_adr WHERE adr_contno=@adr_contno AND adr_adcate='N'

	SELECT @imgtm AS imgtm, @urltm AS urltm, @pubedtm AS pubedtm, @totmtm AS totmtm, @totitm AS totitm, @totntm AS totntm
	--COMMIT TRANSACTION myTransaction
	SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- =====================
-- 2003/05/22 
-- 廣告落版上稿狀況查詢
-- 與GetAdrPublishFileUp條件要一致，
-- 僅欄位變更或精簡
-- 合約狀態fgtemp='0' fgcancel='0' fgclosed='0'
-- =====================
CREATE PROCEDURE dbo.sp_c4_get_adr_xml_data
(
	@adr_addate CHAR(8)
)
AS
BEGIN
SET NOCOUNT ON

BEGIN DISTRIBUTED TRANSACTION myTransaction

--超複雜一把的
SELECT
	adr_imgurl AS ImageUrl,
	adr_navurl AS NavigateUrl,
	adr_alttext AS AlternateText,
	adr_adcate+adr_keyword AS Keyword,
	adr_impr AS Impression
FROM
	c4_adr
INNER JOIN c4_cont ON
	c4_adr.adr_syscd = c4_cont.cont_syscd AND
        c4_adr.adr_contno = c4_cont.cont_contno
WHERE
	adr_addate=@adr_addate AND
	cont_fgtemp='0' AND cont_fgcancel='0' AND cont_fgclosed='0'
ORDER BY  adr_adcate, adr_keyword
-- Commit 
COMMIT TRANSACTION myTransaction

SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- =====================
-- 2003/05/22 
--廣告落版上稿狀況查詢
-- =====================
CREATE PROCEDURE dbo.sp_c4_get_adrpublish_fileup
(
	@adr_addate CHAR(8)
)
AS
BEGIN
SET NOCOUNT ON

BEGIN DISTRIBUTED TRANSACTION myTransaction

--超複雜一把的
SELECT
	c4_adr.adr_syscd,
	c4_adr.adr_contno,
	c4_adr.adr_seq,
	CONVERT(CHAR(10), CONVERT(DATETIME, c4_adr.adr_addate, 112), 111) as adr_addate,
	adr_adcate=CASE
			WHEN adr_adcate='M' THEN '首頁'
			WHEN adr_adcate='I' THEN '內頁'
			WHEN adr_adcate='N' THEN '奈米'
			ELSE '(無定義)'
			END,
	adr_keyword=CASE
			WHEN adr_keyword='h0' THEN '正中'
			WHEN adr_keyword='h1' THEN '右一'
			WHEN adr_keyword='h2' THEN '右二'
			WHEN adr_keyword='h3' THEN '右三'
			WHEN adr_keyword='h4' THEN '右四'
			WHEN adr_keyword='w1' THEN '右文一'
			WHEN adr_keyword='w2' THEN '右文二'
			WHEN adr_keyword='w3' THEN '右文三'
			WHEN adr_keyword='w4' THEN '右文四'
			WHEN adr_keyword='w5' THEN '右文五'
			WHEN adr_keyword='w6' THEN '右文六'
			ELSE '(無定義)'
			END,
	c4_adr.adr_alttext,
	c4_adr.adr_imgurl,
	c4_adr.adr_impr,
	c4_adr.adr_navurl,
	adr_drafttp=CASE
			WHEN adr_drafttp='1' THEN '舊槁'
			WHEN adr_drafttp='2' THEN '新槁'
			WHEN adr_drafttp='3' THEN '改槁'
			ELSE '(無定義)'
			END,
	adr_urltp=CASE
			WHEN adr_urltp='1' THEN '舊槁'
			WHEN adr_urltp='2' THEN '新槁'
			WHEN adr_urltp='3' THEN '改槁'
			ELSE '(無定義)'
			END,
	c4_adr.adr_imseq,
	c4_adr.adr_remark,
	adr_fgfixad=CASE
			WHEN adr_fgfixad='1' THEN '定播'
			WHEN adr_fgfixad='0' THEN '輪播'
			ELSE '(無定義)'
			END,
	c4_cont.cont_conttp,
	c4_cont.cont_empno,
	c4_cont.cont_mfrno,
	c4_cont.cont_custno,
	c4_cont.cont_aunm,
	cust.cust_nm, mfr.mfr_inm,
	invmfr.im_nm,
	srspn.srspn_cname,
	adr_adcate AS sort_adcate,
	adr_keyword AS sort_keyword
FROM
	c4_adr
INNER JOIN c4_cont ON
	c4_adr.adr_syscd = c4_cont.cont_syscd AND
        c4_adr.adr_contno = c4_cont.cont_contno
LEFT OUTER JOIN invmfr ON
	c4_adr.adr_syscd = invmfr.im_syscd AND 
	c4_adr.adr_contno = invmfr.im_contno AND 
	c4_adr.adr_imseq = invmfr.im_imseq
LEFT OUTER JOIN mfr ON
	c4_cont.cont_mfrno = mfr.mfr_mfrno
LEFT OUTER JOIN cust ON
	c4_cont.cont_custno = cust.cust_custno
LEFT OUTER JOIN srspn ON
	RTRIM(c4_cont.cont_empno) = RTRIM(srspn_empno)
WHERE
	adr_addate=@adr_addate AND
	cont_fgtemp='0' AND cont_fgcancel='0' AND cont_fgclosed='0'

-- Commit 
COMMIT TRANSACTION myTransaction

SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- =================================
-- 計算已廣告落版次數、已付金額
-- =================================
CREATE PROCEDURE dbo.sp_c4_get_cont_counts
(
	@adr_contno CHAR(6),
	@pubedtm INT OUTPUT,
	@paidamt INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON
	--BEGIN DISTRIBUTED TRANSACTION myTransaction
	-- 已廣告落版次數
	SELECT @pubedtm=COUNT(*) FROM c4_adr WHERE adr_contno=@adr_contno
	
	-- 已開立發票金額
	SELECT
		@paidamt=ISNULL(SUM(adr_adamt+adr_chgamt+adr_desamt), 0)
	FROM
		c4_adr
	WHERE
		adr_contno=@adr_contno AND
		adr_fginved='0'
	SELECT @pubedtm AS pubedtm, @paidamt AS paidamt
	--COMMIT TRANSACTION myTransaction
	SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

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
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- =====================
-- 2003/09/09
-- 大批月結
-- 發票開立預覽清單
-- =====================
CREATE PROCEDURE dbo.sp_c4_ia_batch_prelist
AS
BEGIN
SET NOCOUNT ON

BEGIN DISTRIBUTED TRANSACTION myTransaction
DELETE wk_c4_ia_prelist
INSERT INTO wk_c4_ia_prelist
SELECT         c4_cont.cont_syscd, c4_cont.cont_contno, c4_cont.cont_custno, cust.cust_nm, 
                          c4_cont.cont_mfrno, ISNULL(mfr_1.mfr_inm, '') AS cont_mfr_inm, 
                          c4_cont.cont_sdate, c4_cont.cont_edate, c4_cont.cont_empno, 
                          srspn.srspn_cname, c4_cont.cont_totamt, invmfr.im_nm, invmfr.im_mfrno, 
                          ISNULL(mfr_2.mfr_inm, '') AS im_mfr_inm, invmfr.im_zip, invmfr.im_addr, 
                          invmfr.im_invcd, invmfr.im_taxtp, invmfr.im_fgitri, c4_adr.adr_addate, 
                          c4_adr.adr_seq, c4_adr.adr_invamt, c4_adr.adr_adamt, c4_adr.adr_desamt, 
                          c4_adr.adr_chgamt, c4_adr.adr_imseq
FROM             srspn INNER JOIN
                          c4_cont INNER JOIN
                          mfr mfr_1 ON c4_cont.cont_mfrno = mfr_1.mfr_mfrno ON 
                          srspn.srspn_empno = c4_cont.cont_empno INNER JOIN
                          cust ON c4_cont.cont_custno = cust.cust_custno RIGHT OUTER JOIN
                          mfr mfr_2 RIGHT OUTER JOIN
                          c4_adr INNER JOIN
                          invmfr ON c4_adr.adr_syscd = invmfr.im_syscd AND 
                          c4_adr.adr_contno = invmfr.im_contno AND 
                          c4_adr.adr_imseq = invmfr.im_imseq ON mfr_2.mfr_mfrno = invmfr.im_mfrno ON
                           c4_cont.cont_syscd = c4_adr.adr_syscd AND 
                          c4_cont.cont_contno = c4_adr.adr_contno
WHERE         (c4_adr.adr_fginved = 'v')

-- Commit 
COMMIT TRANSACTION myTransaction

SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

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
	exec sp_c4_ia_1_recovery @iano, 1
	
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
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- =====================
-- 2003/09/01 
-- 單一合約單一發票廠商
-- 發票開立預覽清單
-- =====================
CREATE PROCEDURE dbo.sp_c4_ia_prelist
(
	@contno CHAR(6),
	@imseq	CHAR(2)
)
AS
BEGIN
SET NOCOUNT ON

BEGIN DISTRIBUTED TRANSACTION myTransaction
DELETE wk_c4_ia_prelist
INSERT INTO wk_c4_ia_prelist
SELECT         c4_cont.cont_syscd, c4_cont.cont_contno, c4_cont.cont_custno, cust.cust_nm, 
                          c4_cont.cont_mfrno, ISNULL(mfr_1.mfr_inm, '') AS cont_mfr_inm, 
                          c4_cont.cont_sdate, c4_cont.cont_edate, c4_cont.cont_empno, 
                          srspn.srspn_cname, c4_cont.cont_totamt, invmfr.im_nm, invmfr.im_mfrno, 
                          ISNULL(mfr_2.mfr_inm, '') AS im_mfr_inm, invmfr.im_zip, invmfr.im_addr, 
                          invmfr.im_invcd, invmfr.im_taxtp, invmfr.im_fgitri, c4_adr.adr_addate, 
                          c4_adr.adr_seq, c4_adr.adr_invamt, c4_adr.adr_adamt, c4_adr.adr_desamt, 
                          c4_adr.adr_chgamt, c4_adr.adr_imseq
FROM             srspn INNER JOIN
                          c4_cont INNER JOIN
                          mfr mfr_1 ON c4_cont.cont_mfrno = mfr_1.mfr_mfrno ON 
                          srspn.srspn_empno = c4_cont.cont_empno INNER JOIN
                          cust ON c4_cont.cont_custno = cust.cust_custno RIGHT OUTER JOIN
                          mfr mfr_2 RIGHT OUTER JOIN
                          c4_adr INNER JOIN
                          invmfr ON c4_adr.adr_syscd = invmfr.im_syscd AND 
                          c4_adr.adr_contno = invmfr.im_contno AND 
                          c4_adr.adr_imseq = invmfr.im_imseq ON mfr_2.mfr_mfrno = invmfr.im_mfrno ON
                           c4_cont.cont_syscd = c4_adr.adr_syscd AND 
                          c4_cont.cont_contno = c4_adr.adr_contno
WHERE         (c4_cont.cont_contno = @contno) AND (c4_adr.adr_imseq = @imseq)  AND (c4_adr.adr_fginved = 'v')

-- Commit 
COMMIT TRANSACTION myTransaction

SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/* 產生C4的大批月結發票 (未使用)*/
CREATE PROC dbo.sp_c4_invbatch(@admonth CHAR(6))
AS
BEGIN
SET NOCOUNT ON
/*先清空*/
DELETE  FROM wk_c4_invbatch
/*產生資料*/
INSERT INTO wk_c4_invbatch
SELECT dbo.c4_cont.cont_syscd, dbo.c4_cont.cont_contno, dbo.c4_cont.cont_custno, 
                  dbo.c4_cont.cont_mfrno, dbo.c4_adr.adr_sdate, dbo.c4_adr.adr_edate, 
                  dbo.c4_adr.adr_adcate, dbo.c4_adr.adr_keyword, dbo.c4_adr.adr_impr, 
                  DRIVERTBL.suminvamt, dbo.mfr.mfr_inm, dbo.invmfr.im_nm, dbo.invmfr.im_jbti, 
                  dbo.invmfr.im_invcd, dbo.invmfr.im_taxtp, dbo.invmfr.im_fgitri, 
                  dbo.c4_cont.cont_empno, dbo.c4_adr.adr_seq, dbo.c4_adr.adr_imseq, 
                  dbo.c4_adr.adr_alttext
FROM     dbo.c4_adr INNER JOIN
                      (SELECT DISTINCT 
                                         adrd_syscd, adrd_contno, adrd_adrseq, suminvamt = SUM(adrd_adramt) 
                                         + SUM(adrd_chgamt) + SUM(adrd_desamt)
                       FROM      c4_adrd
                       WHERE   adrd_fginved = '0' AND SUBSTRING(adrd_addate,1,6)=@admonth
                       GROUP BY adrd_syscd, adrd_contno, adrd_adrseq) DRIVERTBL ON 
                  DRIVERTBL.adrd_syscd = dbo.c4_adr.adr_syscd AND 
                  DRIVERTBL.adrd_contno = dbo.c4_adr.adr_contno AND 
                  DRIVERTBL.adrd_adrseq = dbo.c4_adr.adr_seq INNER JOIN
                  dbo.c4_cont ON dbo.c4_adr.adr_syscd = dbo.c4_cont.cont_syscd AND 
                  dbo.c4_adr.adr_contno = dbo.c4_cont.cont_contno INNER JOIN
                  dbo.invmfr ON dbo.c4_adr.adr_syscd = dbo.invmfr.im_syscd AND 
                  dbo.c4_adr.adr_contno = dbo.invmfr.im_contno AND 
                  dbo.c4_adr.adr_imseq = dbo.invmfr.im_imseq INNER JOIN
                  dbo.mfr ON dbo.invmfr.im_mfrno = dbo.mfr.mfr_mfrno
WHERE  (dbo.c4_cont.cont_conttp = '01') AND (dbo.c4_cont.cont_fgclosed <> '1') AND 
                  (dbo.c4_cont.cont_fgtemp <> '1') AND (dbo.c4_cont.cont_fgcancel <> '1')
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/* C4標籤清單 */

CREATE PROC dbo.sp_c4_label_list
(
	@yyyymm  CHAR(6),  
	@effects	int OUTPUT
)
AS
BEGIN 
SET NOCOUNT ON
BEGIN TRANSACTION create_trans

/* 目前製圖檔稿，新稿、改稿次數和 */
DELETE FROM wk_c4_label_list

declare @contno char(6)
declare @fgpub char(1), @pubcount int

DECLARE Cont_Cursor CURSOR FOR
 select cont_contno
 from c4_cont
 where ( ( dbo.c4_cont.cont_fgclosed = '0' ) AND
          ( dbo.c4_cont.cont_fgcancel = '0' ) AND
          ( dbo.c4_cont.cont_fgtemp = '0' ))
OPEN Cont_Cursor
FETCH NEXT FROM Cont_Cursor
    into @contno
WHILE @@FETCH_STATUS = 0
BEGIN
	SELECT @pubcount = COUNT(*)
	FROM   c4_cont INNER JOIN c4_adr ON c4_cont.cont_contno = c4_adr.adr_contno
	WHERE  (SUBSTRING(c4_adr.adr_addate, 1, 6) = @yyyymm) AND 
           (c4_adr.adr_contno = @contno)

	IF @pubcount = 0
	begin
		--本月未刊登
		INSERT INTO wk_c4_label_list
		SELECT c4_or.or_contno, c4_cont.cont_sdate, c4_cont.cont_edate, c4_cont.cont_empno, 
			c4_cont.cont_conttp, c4_ramt.ma_sdate, c4_ramt.ma_edate, c4_or.or_oritem, c4_or.or_inm, 
			c4_or.or_nm, c4_or.or_jbti, c4_or.or_addr, c4_or.or_zip, c4_or.or_tel, 
			c4_or.or_fgmosea, c4_ramt.ma_mtpcd, c4_ramt.ma_unpubmnt, 
			c4_freebk.fbk_bkcd, '0'
		FROM   c4_freebk INNER JOIN
			c4_or ON c4_freebk.fbk_syscd = c4_or.or_syscd AND 
			c4_freebk.fbk_contno = c4_or.or_contno INNER JOIN
			c4_ramt ON c4_or.or_syscd = c4_ramt.ma_syscd AND 
			c4_or.or_contno = c4_ramt.ma_contno AND 
			c4_or.or_oritem = c4_ramt.ma_oritem AND 
			c4_freebk.fbk_fbkitem = c4_ramt.ma_fbkitem INNER JOIN
			c4_cont ON c4_freebk.fbk_syscd = c4_cont.cont_syscd AND 
			c4_freebk.fbk_contno = c4_cont.cont_contno
		WHERE  (c4_or.or_contno = @contno)
		if @@error != 0
		begin
			set @effects=0
			rollback transaction
			return
		end

	end
	
	IF @pubcount > 0
	begin
		--本月有刊登
		INSERT INTO wk_c4_label_list
		SELECT c4_or.or_contno, c4_cont.cont_sdate, c4_cont.cont_edate, c4_cont.cont_empno, 
			c4_cont.cont_conttp, c4_ramt.ma_sdate, c4_ramt.ma_edate, c4_or.or_oritem, c4_or.or_inm, 
			c4_or.or_nm, c4_or.or_jbti, c4_or.or_addr, c4_or.or_zip, c4_or.or_tel, 
			c4_or.or_fgmosea, c4_ramt.ma_mtpcd, c4_ramt.ma_pubmnt, 
			c4_freebk.fbk_bkcd, '1'
		FROM   c4_freebk INNER JOIN
			c4_or ON c4_freebk.fbk_syscd = c4_or.or_syscd AND 
			c4_freebk.fbk_contno = c4_or.or_contno INNER JOIN
			c4_ramt ON c4_or.or_syscd = c4_ramt.ma_syscd AND 
			c4_or.or_contno = c4_ramt.ma_contno AND 
			c4_or.or_oritem = c4_ramt.ma_oritem AND 
			c4_freebk.fbk_fbkitem = c4_ramt.ma_fbkitem INNER JOIN
			c4_cont ON c4_freebk.fbk_syscd = c4_cont.cont_syscd AND 
			c4_freebk.fbk_contno = c4_cont.cont_contno
		WHERE  (c4_or.or_contno = @contno)
	end
	if @@error != 0
    begin
	    set @effects=0
        rollback transaction
        return
    end
	
           
    FETCH NEXT FROM Cont_Cursor
    into @contno
END
CLOSE Cont_Cursor
DEALLOCATE Cont_Cursor

set @effects=1
COMMIT TRANSACTION create_trans
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/* C4郵寄本數統計表 */
/* 計算年月區間中各月的有刊登及未刊登筆數*/
CREATE PROC dbo.sp_c4_mail_mnt
(
	@yyyymm_start	CHAR(6),  
	@yyyymm_end		CHAR(6),  
	@effects	int OUTPUT
)
AS
BEGIN 
SET NOCOUNT ON
BEGIN TRANSACTION create_trans

/*	查詢本月是未刊登or有刊登
	並計算要郵寄的數量 */
DELETE FROM wk_c4_mail_mnt

declare @contno char(6), @yyyymm char(6)
declare @unpubcount int, @pubcount int
declare @mfrno char(10), @empno char(7), @conttp char(2), @fgmosea char(1), @mtpcd char(2), @bkcd char(2)
declare @pubmnt int, @unpubmnt int

DECLARE Cont_Cursor CURSOR FOR
 select cont_contno
 from c4_cont
 where ( ( dbo.c4_cont.cont_fgcancel = '0' ) AND
          ( dbo.c4_cont.cont_fgtemp = '0' ))
OPEN Cont_Cursor
FETCH NEXT FROM Cont_Cursor
    into @contno
WHILE @@FETCH_STATUS = 0
BEGIN
	SELECT  @yyyymm = @yyyymm_start
	WHILE @yyyymm <= @yyyymm_end
	BEGIN
		SELECT @pubcount = COUNT(*)
		FROM   c4_cont INNER JOIN c4_adr ON c4_cont.cont_contno = c4_adr.adr_contno
		WHERE  (SUBSTRING(c4_adr.adr_addate, 1, 6) = @yyyymm) AND 
			(c4_adr.adr_contno = @contno)

		IF @pubcount = 0
		begin
			--本月未刊登
			DECLARE my_Cursor CURSOR FOR
			SELECT c4_cont.cont_contno, 
				c4_cont.cont_mfrno, 
				c4_cont.cont_empno, 
				c4_cont.cont_conttp, 
				c4_or.or_fgmosea, 
				c4_ramt.ma_mtpcd, 
				c4_ramt.ma_pubmnt,		/*有登本數*/
				c4_ramt.ma_unpubmnt,	/*未登本數*/
				c4_freebk.fbk_bkcd
			FROM c4_cont INNER JOIN
				c4_or ON c4_cont.cont_contno = c4_or.or_contno INNER JOIN
				c4_freebk ON c4_cont.cont_contno = c4_freebk.fbk_contno INNER JOIN
				c4_ramt ON c4_or.or_contno = c4_ramt.ma_contno AND 
				c4_or.or_oritem = c4_ramt.ma_oritem AND 
				c4_freebk.fbk_fbkitem = c4_ramt.ma_fbkitem
			WHERE (c4_cont.cont_contno = @contno) AND ((c4_ramt.ma_sdate <= @yyyymm) AND (c4_ramt.ma_edate >= @yyyymm))
			OPEN my_Cursor
			FETCH NEXT FROM my_Cursor
				into @contno, @mfrno, @empno, @conttp, @fgmosea, @mtpcd, @pubmnt, @unpubmnt, @bkcd
			WHILE @@FETCH_STATUS = 0
			BEGIN

				INSERT INTO wk_c4_mail_mnt
                          (contno, yyyymm, mfrno, empno, conttp, fgmosea, mtpcd, pubmnt, unpubmnt, bkcd)
					VALUES  (@contno, @yyyymm, @mfrno, @empno, @conttp, @fgmosea, @mtpcd, 0, @unpubmnt, @bkcd)
				if @@error != 0
				begin
					set @effects=0
					rollback transaction
					return
				end
				FETCH NEXT FROM my_Cursor
				into @contno, @mfrno, @empno, @conttp, @fgmosea, @mtpcd, @pubmnt, @unpubmnt, @bkcd
			END
			CLOSE my_Cursor
			DEALLOCATE my_Cursor
		end
		
		IF @pubcount > 0
		begin
			--本月有刊登
			DECLARE my_Cursor CURSOR FOR
			SELECT c4_cont.cont_contno, 
				c4_cont.cont_mfrno, 
				c4_cont.cont_empno, 
				c4_cont.cont_conttp, 
				c4_or.or_fgmosea, 
				c4_ramt.ma_mtpcd, 
				c4_ramt.ma_pubmnt,		/*有登本數*/
				c4_ramt.ma_unpubmnt,	/*未登本數*/
				c4_freebk.fbk_bkcd
			FROM c4_cont INNER JOIN
				c4_or ON c4_cont.cont_contno = c4_or.or_contno INNER JOIN
				c4_freebk ON c4_cont.cont_contno = c4_freebk.fbk_contno INNER JOIN
				c4_ramt ON c4_or.or_contno = c4_ramt.ma_contno AND 
				c4_or.or_oritem = c4_ramt.ma_oritem AND 
				c4_freebk.fbk_fbkitem = c4_ramt.ma_fbkitem
			WHERE (c4_cont.cont_contno = @contno) AND ((c4_ramt.ma_sdate <= @yyyymm) AND (c4_ramt.ma_edate >= @yyyymm))
			OPEN my_Cursor
			FETCH NEXT FROM my_Cursor
				into @contno, @mfrno, @empno, @conttp, @fgmosea, @mtpcd, @pubmnt, @unpubmnt, @bkcd
			WHILE @@FETCH_STATUS = 0
			BEGIN

				INSERT INTO wk_c4_mail_mnt
                          (contno, yyyymm, mfrno, empno, conttp, fgmosea, mtpcd, pubmnt, unpubmnt, bkcd)
					VALUES  (@contno, @yyyymm, @mfrno, @empno, @conttp, @fgmosea, @mtpcd, @pubmnt, 0, @bkcd)
				if @@error != 0
				begin
					set @effects=0
					rollback transaction
					return
				end
				FETCH NEXT FROM my_Cursor
				into @contno, @mfrno, @empno, @conttp, @fgmosea, @mtpcd, @pubmnt, @unpubmnt, @bkcd
			END
			CLOSE my_Cursor
			DEALLOCATE my_Cursor

		end
		SELECT @yyyymm = SUBSTRING(CONVERT(char(8), DATEADD(month,1, @yyyymm+'01'), 112), 1, 6)
	END
           
    FETCH NEXT FROM Cont_Cursor
    into @contno
END
CLOSE Cont_Cursor
DEALLOCATE Cont_Cursor

set @effects=1
COMMIT TRANSACTION create_trans
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROC dbo.sp_c4_rp_ad_list
AS
BEGIN
SET NOCOUNT ON
DELETE FROM wk_c4_adlist
INSERT INTO wk_c4_adlist 
SELECT adr_contno, mfr_inm, adr_sdate, adr_edate
,s_adr_adcate=
CASE
    WHEN adr_adcate='M' THEN '首頁'
    WHEN adr_adcate='I' THEN '內頁'
    WHEN adr_adcate='N' THEN '奈米'
END
, s_adr_keyword=
CASE
    WHEN adr_keyword='h0' THEN '正中'
    WHEN adr_keyword='h1' THEN '右一'
    WHEN adr_keyword='h2' THEN '右二'
    WHEN adr_keyword='h3' THEN '右三'
    WHEN adr_keyword='h4' THEN '右四'
    WHEN adr_keyword='w1' THEN '文一'
    WHEN adr_keyword='w2' THEN '文二'
    WHEN adr_keyword='w3' THEN '文三'
    WHEN adr_keyword='w4' THEN '文四'
    WHEN adr_keyword='w5' THEN '文五'
    WHEN adr_keyword='w6' THEN '文六'
    ELSE ''
END
,adr_impr,adr_adamt,adr_desamt,adr_chgamt,adr_invamt
,s_adr_drafttp_1=
CASE
    WHEN adr_drafttp='1' THEN 'V'
    ELSE ''
END
,s_adr_drafttp_2=
CASE
    WHEN adr_drafttp='2' THEN 'V'
    ELSE ''
END
,s_adr_drafttp_3=
CASE
    WHEN adr_drafttp='3' THEN 'V'
    ELSE ''
END
, adr_imgurl
,s_adr_urltp_1=
CASE
    WHEN adr_urltp='1' THEN 'V'
    ELSE ''
END
,s_adr_urlttp_2=
CASE
    WHEN adr_urltp='2' THEN 'V'
    ELSE ''
END
,s_adr_urltp_3=
CASE
    WHEN adr_urltp='3' THEN 'V'
    ELSE ''
END
,adr_navurl,adr_alttext,adr_remark, cont_empno, cont_mfrno
FROM c4_cont INNER JOIN c4_adr ON adr_contno=cont_contno INNER JOIN mfr ON mfr_mfrno=cont_mfrno
SET NOCOUNT OFF
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/* C4廣告落版統計表*/

CREATE PROC dbo.sp_c4_rp_adrlist
(
 @sdate  CHAR(8),	---廣告起始日期
 @edate  CHAR(8)	---廣告結束日期
)
AS
BEGIN 
SET NOCOUNT ON
BEGIN DISTRIBUTED TRANSACTION create_trans

/* 目前製圖檔稿，新稿、改稿次數和 */
DELETE FROM wk_c4_getad_drafttp
INSERT INTO wk_c4_getad_drafttp
SELECT dbo.c4_cont.cont_contno, COUNT(*)  
FROM dbo.c4_cont, dbo.c4_adr  
WHERE ( dbo.c4_cont.cont_syscd = dbo.c4_adr.adr_syscd ) AND  
	( dbo.c4_cont.cont_contno = dbo.c4_adr.adr_contno ) AND  
	( ( dbo.c4_adr.adr_drafttp IN ('2', '3') ) )   
GROUP BY dbo.c4_cont.cont_contno  
ORDER BY dbo.c4_cont.cont_contno ASC   
/* 目前製網頁稿，新稿、改稿次數和 */
DELETE FROM wk_c4_getad_urltp
INSERT INTO wk_c4_getad_urltp
SELECT dbo.c4_cont.cont_contno, COUNT(*)  
FROM dbo.c4_cont, dbo.c4_adr  
WHERE ( dbo.c4_cont.cont_contno = dbo.c4_adr.adr_contno ) AND  
	( ( dbo.c4_adr.adr_urltp IN ('2', '3') ) )   
GROUP BY dbo.c4_cont.cont_contno  
ORDER BY dbo.c4_cont.cont_contno ASC   
/* 計算區間中之落版起訖 */
DELETE FROM wk_c4_adrlist_adr

declare @adr_sdate char(8), @adr_edate char(8), @adr_addate char(8), @adr_count	int
declare @contno char(6), @seq char(2), @fgfixad char(1)
declare @adcate_M_count int, @adcate_I_count int, @adcate_N_count int
declare @adr_adcate char(1), @adr_impr int
declare @sum_adamt int, @sum_desamt int, @sum_chgamt int
declare @adr_adamt int, @adr_desamt int, @adr_chgamt int
set @adr_count=0
set @adr_sdate=''
set @adr_edate=''
set @adcate_M_count = 0
set @adcate_I_count = 0
set @adcate_N_count = 0
set @sum_adamt = 0
set @sum_desamt = 0
set @sum_chgamt = 0
DECLARE Cont_Cursor CURSOR FOR
SELECT DISTINCT c4_adr.adr_seq, c4_cont.cont_contno, c4_adr.adr_fgfixad
FROM c4_cont INNER JOIN
     c4_adr ON c4_cont.cont_contno = c4_adr.adr_contno
WHERE (c4_cont.cont_fgtemp = '0') AND (c4_cont.cont_fgcancel = '0')
ORDER BY  c4_cont.cont_contno
OPEN Cont_Cursor
FETCH NEXT FROM Cont_Cursor
    into @seq, @contno, @fgfixad
WHILE @@FETCH_STATUS = 0
BEGIN
    set @adr_count=0
	set @adr_sdate=''
	set @adr_edate=''
	set @adcate_M_count = 0
	set @adcate_I_count = 0
	set @adcate_N_count = 0
	set @sum_adamt = 0
	set @sum_desamt = 0
	set @sum_chgamt = 0
	DECLARE Adr_Cursor CURSOR FOR
	 select adr_addate, adr_adcate, adr_impr, adr_adamt, adr_desamt, adr_chgamt
	 from c4_adr
	 where ( ( adr_contno = @contno )
	  AND (adr_seq = @seq)
	  AND (adr_addate>=@sdate)
	  AND (adr_addate<=@edate))
	ORDER BY adr_addate
	OPEN Adr_Cursor
	FETCH NEXT FROM Adr_Cursor
		into @adr_addate, @adr_adcate, @adr_impr, @adr_adamt, @adr_desamt, @adr_chgamt
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if @adr_count=0
		  begin
			set @adr_sdate=@adr_addate
		  end
		set @adr_edate=@adr_addate
		set @adr_count=@adr_count+1
		if @adr_adcate = 'M'
		  begin
			set @adcate_M_count = @adcate_M_count + 1
		  end
		if @adr_adcate = 'I'
		  begin
			set @adcate_I_count = @adcate_I_count + 1
		  end
		if @adr_adcate = 'N'
		  begin
			set @adcate_N_count = @adcate_N_count + 1
		  end
		set @sum_adamt = @sum_adamt + @adr_adamt
		set @sum_desamt = @sum_desamt + @adr_desamt
		set @sum_chgamt = @sum_chgamt + @adr_chgamt
		  
	    FETCH NEXT FROM Adr_Cursor
	    into @adr_addate, @adr_adcate, @adr_impr, @adr_adamt, @adr_desamt, @adr_chgamt
	END
	CLOSE Adr_Cursor
	DEALLOCATE Adr_Cursor
	INSERT INTO wk_c4_adrlist_adr
		values (@contno, @seq, @adr_sdate, @adr_edate, @adr_count, 
		@adcate_M_count, @adcate_I_count, @adcate_N_count, @fgfixad, 
		@sum_adamt, @sum_desamt, @sum_chgamt)

    FETCH NEXT FROM Cont_Cursor
    into @seq, @contno, @fgfixad
END
CLOSE Cont_Cursor
DEALLOCATE Cont_Cursor
/* 產生統計表資料 */
DELETE  FROM wk_c4_adrlist
INSERT INTO wk_c4_adrlist
SELECT
         dbo.c4_cont.cont_contno,
         dbo.wk_c4_adrlist_adr.adr_seq,
         dbo.mfr.mfr_inm,   
         dbo.wk_c4_adrlist_adr.adr_sdate,   
         dbo.wk_c4_adrlist_adr.adr_edate,
         /* 廣告天數 */  
         dbo.wk_c4_adrlist_adr.tot_adr_addays,
         /* 各版面落版次數 */
         dbo.wk_c4_adrlist_adr.adr_adcate_M,
         dbo.wk_c4_adrlist_adr.adr_adcate_I,
         dbo.wk_c4_adrlist_adr.adr_adcate_N,
         dbo.wk_c4_adrlist_adr.adr_fgfixad,
         dbo.c4_cont.cont_pubtm,   
         dbo.c4_cont.cont_resttm,   
         dbo.c4_cont.cont_freetm,   
         dbo.c4_cont.cont_totimgtm,
         (dbo.c4_cont.cont_totimgtm - ISNULL(dbo.wk_c4_getad_drafttp.drafttp_cnt, 0)) AS res_drafttp,   
         dbo.c4_cont.cont_toturltm,
         (dbo.c4_cont.cont_toturltm - ISNULL(dbo.wk_c4_getad_urltp.urltp_cnt, 0)) AS res_urltp,
         ISNULL(dbo.wk_c4_adrlist_adr.sum_adamt, 0),
         ISNULL(dbo.wk_c4_adrlist_adr.sum_desamt, 0),
         ISNULL(dbo.wk_c4_adrlist_adr.sum_chgamt, 0),
         dbo.c4_cont.cont_totamt,
         dbo.c4_cont.cont_empno,
         dbo.c4_cont.cont_remark
FROM dbo.c4_cont,   
         dbo.mfr,   
         dbo.wk_c4_getad_drafttp,   
         dbo.wk_c4_getad_urltp,
         dbo.wk_c4_adrlist_adr
WHERE ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_urltp.contno) AND  
         ( dbo.c4_cont.cont_mfrno *= dbo.mfr.mfr_mfrno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_drafttp.contno ) AND  
         ( dbo.c4_cont.cont_contno = dbo.wk_c4_adrlist_adr.cont_contno ) AND  
          ( dbo.c4_cont.cont_fgcancel = '0' ) AND
          ( dbo.c4_cont.cont_fgtemp = '0' )  
ORDER BY dbo.c4_cont.cont_contno

COMMIT TRANSACTION create_trans
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/* C4催稿單 不包含落版明細*/

CREATE PROC dbo.sp_c4_rp_getad
(
 @sdate  CHAR(8),	---催稿起始日期
 @edate  CHAR(8)	---催稿結束日期
)
AS
BEGIN 
SET NOCOUNT ON
BEGIN DISTRIBUTED TRANSACTION create_trans

/* 目前製圖檔稿，新稿、改稿次數和 */
DELETE  wk_c4_getad_drafttp
INSERT INTO wk_c4_getad_drafttp
SELECT dbo.c4_cont.cont_contno, COUNT(*)  
FROM dbo.c4_cont, dbo.c4_adr  
WHERE ( dbo.c4_cont.cont_syscd = dbo.c4_adr.adr_syscd ) AND  
	( dbo.c4_cont.cont_contno = dbo.c4_adr.adr_contno ) AND  
	( ( dbo.c4_adr.adr_drafttp IN ('2', '3') ) )   
GROUP BY dbo.c4_cont.cont_contno  
ORDER BY dbo.c4_cont.cont_contno ASC   
/* 目前製網頁稿，新稿、改稿次數和 */
DELETE  wk_c4_getad_urltp
INSERT INTO wk_c4_getad_urltp
SELECT dbo.c4_cont.cont_contno, COUNT(*)  
FROM dbo.c4_cont, dbo.c4_adr  
WHERE ( dbo.c4_cont.cont_contno = dbo.c4_adr.adr_contno ) AND  
	( ( dbo.c4_adr.adr_urltp IN ('2', '3') ) )   
GROUP BY dbo.c4_cont.cont_contno  
ORDER BY dbo.c4_cont.cont_contno ASC   
/* 已開立發票金額, 已轉SAP */
DELETE  wk_c4_getad_ia_amt
INSERT INTO  wk_c4_getad_ia_amt        
 SELECT substring(dbo.ia.ia_contno,3,6),   
         dbo.ia.ia_pyat  
    FROM dbo.ia  
   WHERE ( dbo.ia.ia_syscd = 'C4' ) AND  
         ( dbo.ia.ia_status = '7' )    
/* 計算催稿區間中之落版起訖 */
DELETE wk_c4_getad_adr

declare @adr_sdate char(8), @adr_edate char(8), @adr_addate char(8), @adr_count	int
declare @contno char(6)
set @adr_count=0
set @adr_sdate=''
set @adr_edate=''
DECLARE Cont_Cursor CURSOR FOR
 select cont_contno
 from c4_cont
 where ( ( dbo.c4_cont.cont_fgclosed = '0' ) AND
          ( dbo.c4_cont.cont_fgcancel = '0' ) AND
          ( dbo.c4_cont.cont_fgtemp = '0' ))
OPEN Cont_Cursor
FETCH NEXT FROM Cont_Cursor
    into @contno
WHILE @@FETCH_STATUS = 0
BEGIN
    set @adr_count=0
	set @adr_sdate=''
	set @adr_edate=''
	DECLARE Adr_Cursor CURSOR FOR
	 select adr_addate
	 from c4_adr
	 where ( ( adr_contno = @contno )
	  AND (adr_addate>=@sdate)
	  AND (adr_addate<=@edate))
	ORDER BY adr_addate
	OPEN Adr_Cursor
	FETCH NEXT FROM Adr_Cursor
		into @adr_addate
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if @adr_count=0
			set @adr_sdate=@adr_addate
		set @adr_edate=@adr_addate
		set @adr_count=@adr_count+1

	    FETCH NEXT FROM Adr_Cursor
	    into @adr_addate
	END
	CLOSE Adr_Cursor
	DEALLOCATE Adr_Cursor
	INSERT INTO wk_c4_getad_adr
		values (@contno, @adr_sdate, @adr_edate, @adr_count)

    FETCH NEXT FROM Cont_Cursor
    into @contno
END
CLOSE Cont_Cursor
DEALLOCATE Cont_Cursor
/* 產生催稿單資料 */
DELETE  wk_c4_getad
/*1:已到期,未結案*/
INSERT INTO wk_c4_getad
SELECT
         dbo.c4_cont.cont_contno,
         dbo.c4_cont.cont_aunm,   
         dbo.mfr.mfr_inm,   
         dbo.c4_cont.cont_autel,   
         dbo.c4_cont.cont_aufax,   
         dbo.c4_cont.cont_aucell,   
         dbo.c4_cont.cont_sdate,   
         dbo.c4_cont.cont_edate,
         dbo.wk_c4_getad_adr.adr_sdate,   
         dbo.wk_c4_getad_adr.adr_edate,'',
         /* 廣告天數 */  
         dbo.wk_c4_getad_adr.tot_adr_addays,
         '','','',0,'', '', '', '', '','',
         dbo.c4_cont.cont_pubtm,   
         dbo.c4_cont.cont_freetm,   
         dbo.c4_cont.cont_totimgtm,
         (dbo.c4_cont.cont_totimgtm - ISNULL(dbo.wk_c4_getad_drafttp.drafttp_cnt, 0)) AS res_drafttp,   
         dbo.c4_cont.cont_toturltm,
         (dbo.c4_cont.cont_toturltm - ISNULL(dbo.wk_c4_getad_urltp.urltp_cnt, 0)) AS res_urltp,   
         dbo.c4_cont.cont_totamt,
         0,--ISNULL(dbo.wk_c4_getad_ia_amt.ia_amt, 0),   不在這裡算
         0,--dbo.c4_cont.cont_paidamt,
         dbo.c4_cont.cont_empno,
         '1'	---到期註記
FROM dbo.c4_cont,   
         dbo.mfr,   
         dbo.wk_c4_getad_ia_amt,   
         dbo.wk_c4_getad_drafttp,   
         dbo.wk_c4_getad_urltp,
         dbo.wk_c4_getad_adr
WHERE ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_urltp.contno) AND  
         ( dbo.c4_cont.cont_mfrno *= dbo.mfr.mfr_mfrno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_ia_amt.contno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_drafttp.contno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_adr.cont_contno ) AND  
         ( ( dbo.c4_cont.cont_fgclosed = '0' ) AND
          ( dbo.c4_cont.cont_fgcancel = '0' ) AND
          ( dbo.c4_cont.cont_fgtemp = '0' ) AND
         ( dbo.c4_cont.cont_edate < @sdate ) )   
ORDER BY dbo.c4_cont.cont_contno
/*0:未到期*/
INSERT INTO wk_c4_getad
SELECT
         dbo.c4_cont.cont_contno,
         dbo.c4_cont.cont_aunm,   
         dbo.mfr.mfr_inm,   
         dbo.c4_cont.cont_autel,   
         dbo.c4_cont.cont_aufax,   
         dbo.c4_cont.cont_aucell,   
         dbo.c4_cont.cont_sdate,   
         dbo.c4_cont.cont_edate,
         dbo.wk_c4_getad_adr.adr_sdate,   
         dbo.wk_c4_getad_adr.adr_edate,'',
         /* 廣告天數 */  
         dbo.wk_c4_getad_adr.tot_adr_addays,
         '','','',0,'', '', '', '', '','',
         dbo.c4_cont.cont_pubtm,   
         dbo.c4_cont.cont_freetm,   
         dbo.c4_cont.cont_totimgtm,
         (dbo.c4_cont.cont_totimgtm - ISNULL(dbo.wk_c4_getad_drafttp.drafttp_cnt, 0)) AS res_drafttp,   
         dbo.c4_cont.cont_toturltm,
         (dbo.c4_cont.cont_toturltm - ISNULL(dbo.wk_c4_getad_urltp.urltp_cnt, 0)) AS res_urltp,   
         dbo.c4_cont.cont_totamt,
         0,--ISNULL(dbo.wk_c4_getad_ia_amt.ia_amt, 0),   不在這裡算
         0,--dbo.c4_cont.cont_paidamt,
         dbo.c4_cont.cont_empno,
         '0'
FROM dbo.c4_cont,   
         dbo.mfr,   
         dbo.wk_c4_getad_ia_amt,   
         dbo.wk_c4_getad_drafttp,   
         dbo.wk_c4_getad_urltp ,
         dbo.wk_c4_getad_adr
WHERE ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_urltp.contno) AND  
         ( dbo.c4_cont.cont_mfrno *= dbo.mfr.mfr_mfrno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_ia_amt.contno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_drafttp.contno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_adr.cont_contno ) AND  
         ( ( dbo.c4_cont.cont_fgclosed = '0' ) AND
          ( dbo.c4_cont.cont_fgcancel = '0' ) AND
          ( dbo.c4_cont.cont_fgtemp = '0' ) AND
         ( dbo.c4_cont.cont_edate >= @sdate ) )   
ORDER BY dbo.c4_cont.cont_contno
COMMIT TRANSACTION create_trans
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

/* C4催稿單 包含落版明細*/

CREATE PROC dbo.sp_c4_rp_getad_adr
(
 @sdate  CHAR(8),	---催稿起始日期
 @edate  CHAR(8)	---催稿結束日期
)
AS
BEGIN 
SET NOCOUNT ON
BEGIN DISTRIBUTED TRANSACTION create_trans

/* 目前製圖檔稿，新稿、改稿次數和 */
DELETE  wk_c4_getad_drafttp
INSERT INTO wk_c4_getad_drafttp
SELECT dbo.c4_cont.cont_contno, COUNT(*)  
FROM dbo.c4_cont, dbo.c4_adr  
WHERE ( dbo.c4_cont.cont_syscd = dbo.c4_adr.adr_syscd ) AND  
	( dbo.c4_cont.cont_contno = dbo.c4_adr.adr_contno ) AND  
	( ( dbo.c4_adr.adr_drafttp IN ('2', '3') ) )   
GROUP BY dbo.c4_cont.cont_contno  
ORDER BY dbo.c4_cont.cont_contno ASC   
/* 目前製網頁稿，新稿、改稿次數和 */
DELETE   wk_c4_getad_urltp
INSERT INTO wk_c4_getad_urltp
SELECT dbo.c4_cont.cont_contno, COUNT(*)  
FROM dbo.c4_cont, dbo.c4_adr  
WHERE ( dbo.c4_cont.cont_contno = dbo.c4_adr.adr_contno ) AND  
	( ( dbo.c4_adr.adr_urltp IN ('2', '3') ) )   
GROUP BY dbo.c4_cont.cont_contno  
ORDER BY dbo.c4_cont.cont_contno ASC   
/* 已開立發票金額, 已轉SAP */
DELETE  wk_c4_getad_ia_amt
INSERT INTO  wk_c4_getad_ia_amt        
 SELECT substring(dbo.ia.ia_contno,3,6),   
         dbo.ia.ia_pyat  
    FROM dbo.ia  
   WHERE ( dbo.ia.ia_syscd = 'C4' ) AND  
         ( dbo.ia.ia_status = '7' )    
/* 計算催稿區間中之落版起訖 */
DELETE  wk_c4_getad_adr

declare @adr_sdate char(8), @adr_edate char(8), @adr_addate char(8), @adr_count	int
declare @contno char(6)
set @adr_count=0
set @adr_sdate=''
set @adr_edate=''
DECLARE Cont_Cursor CURSOR FOR
 select cont_contno
 from c4_cont
 where ( ( dbo.c4_cont.cont_fgclosed = '0' ) AND
          ( dbo.c4_cont.cont_fgcancel = '0' ) AND
          ( dbo.c4_cont.cont_fgtemp = '0' ))
OPEN Cont_Cursor
FETCH NEXT FROM Cont_Cursor
    into @contno
WHILE @@FETCH_STATUS = 0
BEGIN
    set @adr_count=0
	set @adr_sdate=''
	set @adr_edate=''
	DECLARE Adr_Cursor CURSOR FOR
	 select adr_addate
	 from c4_adr
	 where ( ( adr_contno = @contno )
	  AND (adr_addate>=@sdate)
	  AND (adr_addate<=@edate))
	ORDER BY adr_addate
	OPEN Adr_Cursor
	FETCH NEXT FROM Adr_Cursor
		into @adr_addate
	WHILE @@FETCH_STATUS = 0
	BEGIN
		if @adr_count=0
			set @adr_sdate=@adr_addate
		set @adr_edate=@adr_addate
		set @adr_count=@adr_count+1

	    FETCH NEXT FROM Adr_Cursor
	    into @adr_addate
	END
	CLOSE Adr_Cursor
	DEALLOCATE Adr_Cursor
	 select @adr_count=COUNT(*)
	 from c4_adr
	 where ( ( adr_contno = @contno )
	  AND (adr_addate>=@sdate)
	  AND (adr_addate<=@edate))
	INSERT INTO wk_c4_getad_adr
		values (@contno, @adr_sdate, @adr_edate, @adr_count)

    FETCH NEXT FROM Cont_Cursor
    into @contno
END
CLOSE Cont_Cursor
DEALLOCATE Cont_Cursor
/* 產生催稿單資料 */
DELETE   wk_c4_getad
/*1:已到期,未結案*/
INSERT INTO wk_c4_getad
SELECT
         dbo.c4_cont.cont_contno,
         dbo.c4_cont.cont_aunm,   
         dbo.mfr.mfr_inm,   
         dbo.c4_cont.cont_autel,   
         dbo.c4_cont.cont_aufax,   
         dbo.c4_cont.cont_aucell,   
         dbo.c4_cont.cont_sdate,   
         dbo.c4_cont.cont_edate,
         dbo.wk_c4_getad_adr.adr_sdate,   
         dbo.wk_c4_getad_adr.adr_edate,
         ISNULL(dbo.c4_adr.adr_addate,''),
         /* 廣告天數 */  
         dbo.wk_c4_getad_adr.tot_adr_addays,
         /*廣告頁面
         dbo.c4_adr.adr_adcate,
        */
	ISNULL(adr_adcate, ''),
         /*廣告位置   
         dbo.c4_adr.adr_keyword,
        */
        ISNULL(adr_keyword,''),
        ISNULL(adr_fgfixad,''),
         ISNULL(adr_impr, ''),
         /* 圖檔稿類別   
         dbo.c4_adr.adr_drafttp,
         */
         ISNULL(adr_drafttp, ''),
         ISNULL(adr_imgurl, ''),
         /* 到稿   
         dbo.c4_adr.adr_fgimggot,   
         */
	ISNULL(adr_fgimggot, ''),
         /* 網頁稿類別
         dbo.c4_adr.adr_urltp,   
         */
	ISNULL(adr_urltp, ''),
         /* 到稿   
         dbo.c4_adr.adr_fgurlgot,   
         */
	ISNULL(adr_fgurlgot, ''),
         ISNULL(dbo.c4_adr.adr_navurl, ''),   
         dbo.c4_cont.cont_pubtm,   
         dbo.c4_cont.cont_freetm,   
         dbo.c4_cont.cont_totimgtm,
         (dbo.c4_cont.cont_totimgtm - ISNULL(dbo.wk_c4_getad_drafttp.drafttp_cnt, 0)) AS res_drafttp,   
         dbo.c4_cont.cont_toturltm,
         (dbo.c4_cont.cont_toturltm - ISNULL(dbo.wk_c4_getad_urltp.urltp_cnt, 0)) AS res_urltp,   
         dbo.c4_cont.cont_totamt,
         0,--ISNULL(dbo.wk_c4_getad_ia_amt.ia_amt, 0),   不在這裡算
         0,--dbo.c4_cont.cont_paidamt,
         dbo.c4_cont.cont_empno,
         '1'	---到期註記         
FROM dbo.c4_cont,   
         dbo.mfr,
         dbo.c4_adr,
         dbo.wk_c4_getad_ia_amt,   
         dbo.wk_c4_getad_drafttp,   
         dbo.wk_c4_getad_urltp,
         dbo.wk_c4_getad_adr
WHERE ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_urltp.contno) AND  
         ( dbo.c4_cont.cont_syscd *= dbo.c4_adr.adr_syscd ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.c4_adr.adr_contno ) AND  
         ( dbo.c4_cont.cont_mfrno *= dbo.mfr.mfr_mfrno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_ia_amt.contno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_drafttp.contno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_adr.cont_contno ) AND  
         ( ( dbo.c4_cont.cont_fgclosed = '0' ) AND
          ( dbo.c4_cont.cont_fgcancel = '0' ) AND
          ( dbo.c4_cont.cont_fgtemp = '0' ) AND
         ( dbo.c4_cont.cont_edate < @sdate )   AND
         (( dbo.c4_adr.adr_addate >= @sdate )   AND
         ( dbo.c4_adr.adr_addate <= @edate )))  
ORDER BY dbo.c4_cont.cont_contno
/*0:未到期*/
INSERT INTO wk_c4_getad
SELECT
         dbo.c4_cont.cont_contno,
         dbo.c4_cont.cont_aunm,   
         dbo.mfr.mfr_inm,   
         dbo.c4_cont.cont_autel,   
         dbo.c4_cont.cont_aufax,   
         dbo.c4_cont.cont_aucell,   
         dbo.c4_cont.cont_sdate,   
         dbo.c4_cont.cont_edate,
         dbo.wk_c4_getad_adr.adr_sdate,   
         dbo.wk_c4_getad_adr.adr_edate,
         ISNULL(dbo.c4_adr.adr_addate,''),
         /* 廣告天數 */  
         dbo.wk_c4_getad_adr.tot_adr_addays,
         /*廣告頁面
         dbo.c4_adr.adr_adcate,
        */
		ISNULL(adr_adcate, ''),
         /*廣告位置   
         dbo.c4_adr.adr_keyword,
        */
        ISNULL(adr_keyword,''),
         ISNULL(adr_fgfixad,''),
         ISNULL(adr_impr, ''),
         /* 圖檔稿類別   
         dbo.c4_adr.adr_drafttp,
         */
         ISNULL(adr_drafttp, ''),
         ISNULL(adr_imgurl, ''),
         /* 到稿   
         dbo.c4_adr.adr_fgimggot,   
         */
	ISNULL(adr_fgimggot, ''),
         /* 網頁稿類別
         dbo.c4_adr.adr_urltp,   
         */
	ISNULL(adr_urltp, ''),
         /* 到稿   
         dbo.c4_adr.adr_fgurlgot,   
         */
	ISNULL(adr_fgurlgot, ''),
         ISNULL(dbo.c4_adr.adr_navurl, ''),   
         dbo.c4_cont.cont_pubtm,   
         dbo.c4_cont.cont_freetm,   
         dbo.c4_cont.cont_totimgtm,
         (dbo.c4_cont.cont_totimgtm - ISNULL(dbo.wk_c4_getad_drafttp.drafttp_cnt, 0)) AS res_drafttp,   
         dbo.c4_cont.cont_toturltm,
         (dbo.c4_cont.cont_toturltm - ISNULL(dbo.wk_c4_getad_urltp.urltp_cnt, 0)) AS res_urltp,   
         dbo.c4_cont.cont_totamt,
         0,--ISNULL(dbo.wk_c4_getad_ia_amt.ia_amt, 0),   不在這裡算
         0,--dbo.c4_cont.cont_paidamt,
         dbo.c4_cont.cont_empno,
         '0'
FROM dbo.c4_cont,   
         dbo.mfr,   
         dbo.c4_adr,
         dbo.wk_c4_getad_ia_amt,   
         dbo.wk_c4_getad_drafttp,   
         dbo.wk_c4_getad_urltp ,
         dbo.wk_c4_getad_adr
WHERE ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_urltp.contno) AND  
         ( dbo.c4_cont.cont_syscd *= dbo.c4_adr.adr_syscd ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.c4_adr.adr_contno ) AND  
         ( dbo.c4_cont.cont_mfrno *= dbo.mfr.mfr_mfrno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_ia_amt.contno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_drafttp.contno ) AND  
         ( dbo.c4_cont.cont_contno *= dbo.wk_c4_getad_adr.cont_contno ) AND  
         ( ( dbo.c4_cont.cont_fgclosed = '0' ) AND
          ( dbo.c4_cont.cont_fgcancel = '0' ) AND
          ( dbo.c4_cont.cont_fgtemp = '0' ) AND
         ( dbo.c4_cont.cont_edate >= @sdate )   AND
         (( dbo.c4_adr.adr_addate >= @sdate )   AND
         ( dbo.c4_adr.adr_addate <= @edate )))   
ORDER BY dbo.c4_cont.cont_contno
COMMIT TRANSACTION create_trans
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/*
2003/06/19
產生材料特性字串。wk_c4_matpstring
產生應用產業字串。wk_c4_atpstring
產生贈書及收件人資料字串。wk_c4_fbkstring
提供予合約書清單（一覽表）使用。
*/
CREATE PROCEDURE dbo.sp_c4_rpt_contlist_gendata
AS
BEGIN


SET NOCOUNT ON
BEGIN DISTRIBUTED TRANSACTION myTransaction


-------------------------------------
--        先清除暫存Table
-------------------------------------
DELETE FROM wk_c4_matpstring
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END

DELETE FROM wk_c4_atpstring
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END

DELETE FROM wk_c4_fbkstring
IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	RETURN
END
--------------------------------------------------------------------



-- 暫存運作變數
DECLARE @tmpcontno CHAR(6)
DECLARE @tmpcls2 VARCHAR(50)
DECLARE @loop INT
-- 變數初始化
SELECT @tmpcontno = ''
SELECT @tmpcls2 = ''
SELECT @loop=1

--每一組cursor的變數
DECLARE @contno CHAR(6), @cls1name VARCHAR(50), @cls2cname VARCHAR(50), @cls3cname VARCHAR(50)

----------------------------
--        材料特性
----------------------------

--材料特性字串
DECLARE @matpstring VARCHAR(1000)
SELECT @matpstring = ''

--製作cursor
DECLARE  matp_cursor  CURSOR FOR 
	SELECT cls_contno, cls1_name, cls2_cname, cls3_cname
	FROM c4_classes
	INNER JOIN c4_class3 ON cls_cls3id = cls3_cls3id AND cls_cls2id = cls3_cls2id AND cls_cls1id = cls3_cls1id
	INNER JOIN c4_class2 ON cls_cls2id = cls2_cls2id AND cls_cls1id = cls2_cls1id
	INNER JOIN c4_class1 ON cls_cls1id = cls1_cls1id
	WHERE cls_cls1id = 1
	ORDER BY cls_contno, cls1_name, cls2_cname

OPEN matp_cursor
FETCH  NEXT FROM  matp_cursor  INTO @contno, @cls1name, @cls2cname, @cls3cname

WHILE (@@FETCH_STATUS=0)
BEGIN

	-- 如果換了合約編號，就把資料丟出去，然後重設子階層的變數(第一筆資料例外)
	IF @tmpcontno<>@contno AND @loop<>1
	BEGIN
		--SHOW--SELECT @tmpcontno, @matpstring
		INSERT INTO wk_c4_matpstring (wkmatp_contno, wkmatp_matpstr) VALUES (@tmpcontno, @matpstring)
		IF @@ERROR<>0
		BEGIN
			ROLLBACK TRANSACTION
			RETURN
		END

		SELECT @matpstring = ''
		SELECT @tmpcls2=''
	END
	
	--如果換了類別，就設定分隔符號
	IF @tmpcls2 <> @cls2cname
	BEGIN
		SELECT @matpstring = @matpstring + '*' + @cls2cname + '：'
	END

	--組合字串	
	SELECT @matpstring=@matpstring+@cls3cname +', '


	--處理下一筆資料前，改變暫存變數
	SELECT @tmpcls2 = @cls2cname
	SELECT @tmpcontno=@contno
	SELECT @loop = @loop + 1
	FETCH  NEXT FROM  matp_cursor  INTO @contno, @cls1name, @cls2cname, @cls3cname
END

--做完了把最後一筆組合好的資料丟出
IF @loop<>1
BEGIN
	--SHOW--SELECT @tmpcontno, @matpstring
	INSERT INTO wk_c4_matpstring (wkmatp_contno, wkmatp_matpstr) VALUES (@tmpcontno, @matpstring)
	IF @@ERROR<>0
	BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END
END
SELECT @matpstring = ''
SELECT @tmpcls2=''

CLOSE matp_cursor
DEALLOCATE matp_cursor
-------------------------------------------------------------------------------


-- 變數初始化
SELECT @tmpcontno = ''
SELECT @tmpcls2 = ''
SELECT @loop=1
----------------------------
--        應用產業
----------------------------

--應用產業字串
DECLARE @atpstring VARCHAR(1000)
SELECT @atpstring = ''

--製作cursor
DECLARE  atp_cursor  CURSOR FOR 
	SELECT cls_contno, cls1_name, cls2_cname, cls3_cname
	FROM c4_classes
	INNER JOIN c4_class3 ON cls_cls3id = cls3_cls3id AND cls_cls2id = cls3_cls2id AND cls_cls1id = cls3_cls1id
	INNER JOIN c4_class2 ON cls_cls2id = cls2_cls2id AND cls_cls1id = cls2_cls1id
	INNER JOIN c4_class1 ON cls_cls1id = cls1_cls1id
	WHERE cls_cls1id = 2
	ORDER BY cls_contno, cls1_name, cls2_cname



OPEN atp_cursor
FETCH  NEXT FROM  atp_cursor  INTO @contno, @cls1name, @cls2cname, @cls3cname

WHILE (@@FETCH_STATUS=0)
BEGIN

	-- 如果換了合約編號，就把資料丟出去，然後重設子階層的變數(第一筆資料例外)
	IF @tmpcontno<>@contno AND @loop<>1
	BEGIN
		--SHOW--SELECT @tmpcontno, @atpstring
		INSERT INTO wk_c4_atpstring (wkatp_contno, wkatp_atpstr) VALUES (@tmpcontno, @atpstring)
		IF @@ERROR<>0
		BEGIN
			ROLLBACK TRANSACTION
			RETURN
		END

		SELECT @atpstring = ''
		SELECT @tmpcls2=''
	END
	
	--如果換了類別，就設定分隔符號
	IF @tmpcls2 <> @cls2cname
	BEGIN
		SELECT @atpstring = @atpstring + '*' + @cls2cname + '：'
	END

	--組合字串	
	SELECT @atpstring=@atpstring+@cls3cname +', '


	--處理下一筆資料前，改變暫存變數
	SELECT @tmpcls2 = @cls2cname
	SELECT @tmpcontno=@contno
	SELECT @loop = @loop + 1
	FETCH  NEXT FROM  atp_cursor  INTO @contno, @cls1name, @cls2cname, @cls3cname
END

--做完了把最後一筆組合好的資料丟出
IF @loop<>1
BEGIN
	--SHOW--SELECT @tmpcontno, @atpstring
	INSERT INTO wk_c4_atpstring (wkatp_contno, wkatp_atpstr) VALUES (@tmpcontno, @atpstring)
	IF @@ERROR<>0
	BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END
END
SELECT @atpstring = ''
SELECT @tmpcls2=''

CLOSE atp_cursor
DEALLOCATE atp_cursor
-------------------------------------------------------------------------------



-- 變數初始化
SELECT @tmpcontno = ''
SELECT @loop=1
----------------------------------------------
--        贈書及雜誌收件人資料
----------------------------------------------


--贈書及雜誌收件人字串
DECLARE @fbkstring VARCHAR(1000)
DECLARE @tmpstring VARCHAR(200)
SELECT @fbkstring = ''
SELECT @tmpstring = ''

--製作cursor
DECLARE  fbk_cursor  CURSOR FOR 
	SELECT fbk_contno, fbk_fbkitem COLLATE Chinese_Taiwan_Stroke_BIN +'：'+ fc_nm + '(' + ma_sdate + '~' +  ma_edate + '),(' +
              CONVERT(VARCHAR(3), ma_pubmnt) +'/' + CONVERT(VARCHAR(3), ma_unpubmnt) + '),' + mtp_nm + ',' + or_nm + ',' +
              RTRIM(or_addr) + ',' + or_tel AS fkbstring
	FROM c4_freebk 
	INNER JOIN c4_ramt ON fbk_contno = ma_contno AND fbk_fbkitem = ma_fbkitem 
	INNER JOIN freecat ON fbk_bkcd = fc_fccd 
	INNER JOIN c4_or ON ma_oritem = or_oritem AND ma_contno = or_contno 
	INNER JOIN mtp ON ma_mtpcd = mtp_mtpcd



OPEN fbk_cursor
FETCH  NEXT FROM  fbk_cursor INTO @contno, @tmpstring

WHILE (@@FETCH_STATUS=0)
BEGIN

	-- 如果換了合約編號，就把資料丟出去，然後重設子階層的變數(第一筆資料例外)
	IF @tmpcontno=@contno OR @loop=1
	BEGIN
		--組合字串	
		SELECT @fbkstring=@fbkstring+' *' +@tmpstring
	END
	ELSE
	BEGIN

		INSERT INTO wk_c4_fbkstring (wkfbk_contno, wkfbk_fbkstr) VALUES (@tmpcontno, @fbkstring)
		--SHOW DATA--SELECT @tmpcontno, @fbkstring

		IF @@ERROR<>0
		BEGIN
			ROLLBACK TRANSACTION
			RETURN
		END

		SELECT @fbkstring = ' *' +@tmpstring
	END
	
	--處理下一筆資料前，改變暫存變數
	SELECT @tmpcontno=@contno
	SELECT @loop = @loop + 1
	FETCH  NEXT FROM  fbk_cursor INTO @contno, @tmpstring
END

--做完了把最後一筆組合好的資料丟出
IF @loop<>1 
BEGIN
	--SHOW DATA--SELECT @tmpcontno, @fbkstring
	INSERT INTO wk_c4_fbkstring (wkfbk_contno, wkfbk_fbkstr) VALUES (@tmpcontno, @fbkstring)
	IF @@ERROR<>0
	BEGIN
		ROLLBACK TRANSACTION
		RETURN
	END
END
SELECT @fbkstring = ''
SELECT @tmpstring=''

CLOSE fbk_cursor
DEALLOCATE fbk_cursor


COMMIT TRANSACTION myTransaction
SET NOCOUNT OFF


END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- =================================
-- 2003/06/12
-- 更新xml file log，刪除檔案時使用
-- =================================
CREATE PROCEDURE dbo.sp_c4_substract_xml_filg_log
(
	@addate CHAR(8)
)
AS
BEGIN
	SET NOCOUNT ON

	--因為是刪除檔案，所以重置回0
	UPDATE c4_xmlfilelog SET xml_fgexist=0, xml_createdate=GETDATE() WHERE xml_date=@addate		

	SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

CREATE PROC dbo.sp_c4_update_adcnt(@syscd CHAR(2), @contno CHAR(6))
AS
BEGIN
SET NOCOUNT ON
/*測試用資料
DECLARE @syscd CHAR(2), @contno CHAR(6)
SELECT @syscd='C4'
SELECT @contno='000024'
*/
DECLARE @sdate CHAR(8), @edate CHAR(8), @adcate CHAR(1), @keyword CHAR(2), @impr INT
DECLARE @tmpdate CHAR(8)
DECLARE adcnt_cursor CURSOR FOR
SELECT adr_sdate,adr_edate,adr_adcate,adr_keyword,adr_impr
FROM c4_adr 
WHERE (adr_syscd = @syscd) AND (adr_contno = @contno)
OPEN adcnt_cursor
FETCH NEXT FROM adcnt_cursor
INTO @sdate, @edate, @adcate, @keyword, @impr
WHILE (@@FETCH_STATUS=0)
BEGIN
	SELECT @tmpdate = @sdate
	WHILE (DATEDIFF(DAY, CONVERT(DATETIME, @tmpdate, 112),  CONVERT(DATETIME, @edate, 112))>=0)
	BEGIN
		IF @keyword='h0'
                               		UPDATE c4_adcnt SET cnt_h0=cnt_h0-@impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adcate
                                ELSE IF @keyword='h1'
			UPDATE c4_adcnt SET cnt_h1=cnt_h1-@impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adcate
		ELSE IF @keyword='h2'
			UPDATE c4_adcnt SET cnt_h2=cnt_h2-@impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adcate
		ELSE IF @keyword='h3'
			UPDATE c4_adcnt SET cnt_h3=cnt_h3-@impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adcate
		ELSE IF @keyword='h4'
			UPDATE c4_adcnt SET cnt_h4=cnt_h4-@impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adcate
		ELSE IF @keyword='w1'
			UPDATE c4_adcnt SET cnt_w1=cnt_w1-@impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adcate
		ELSE IF @keyword='w2'
			UPDATE c4_adcnt SET cnt_w2=cnt_w2-@impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adcate
		ELSE IF @keyword='w3'
			UPDATE c4_adcnt SET cnt_w3=cnt_w3-@impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adcate
		ELSE IF @keyword='w4'
			UPDATE c4_adcnt SET cnt_w4=cnt_w4-@impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adcate
		ELSE IF @keyword='w5'
			UPDATE c4_adcnt SET cnt_w5=cnt_w5-@impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adcate
		ELSE IF @keyword='w6'
			UPDATE c4_adcnt SET cnt_w6=cnt_w6-@impr WHERE cnt_date=@tmpdate AND cnt_adcate=@adcate
				
		SELECT @tmpdate = CONVERT(CHAR(8), DATEADD(DAY, 1, @tmpdate), 112)
	END
FETCH NEXT FROM adcnt_cursor
END
CLOSE adcnt_cursor
DEALLOCATE adcnt_cursor
SET NOCOUNT OFF
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/*******************************************************
	2003/05/21，新改版
	修改廣告落版資料，在美編上稿的時候

******************************************************/
CREATE PROCEDURE dbo.sp_c4_update_adr_fileup
(
	@adr_contno CHAR(6),
	@adr_seq CHAR(2),
	@adr_addate CHAR(8), 
	@adr_alttext VARCHAR(30), 
	@adr_navurl VARCHAR(255), 
	@adr_remark VARCHAR(50),
	@adr_imgurl VARCHAR(30),
	@adr_drafttp CHAR(1),
	@adr_urltp CHAR(1)
)
AS
BEGIN
SET NOCOUNT ON
BEGIN TRANSACTION myTransaction

UPDATE
	c4_adr
SET
	adr_alttext=@adr_alttext,
	adr_navurl=@adr_navurl,
	adr_remark=@adr_remark,
	adr_imgurl=@adr_imgurl,
	adr_drafttp=@adr_drafttp,
	adr_urltp=@adr_urltp
WHERE
	adr_syscd='C4' AND
	adr_contno=@adr_contno AND
	adr_seq=@adr_seq AND
	adr_addate=@adr_addate 

-- Commit 
COMMIT TRANSACTION myTransaction
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

/*******************************************************
	2003/05/16，新改版
	修改廣告落版資料，在業務落版時的修改
	UPDATE: c4_adr
	UPDATE: c4_adcnt
******************************************************/
CREATE PROCEDURE dbo.sp_c4_update_adr_lite_1
(
	@adr_contno CHAR(6),
	@adr_seq CHAR(2),
	@adr_addate CHAR(8), 
	@adr_adcate CHAR(1), 
	@adr_keyword CHAR(2), 
	@adr_alttext VARCHAR(30), 
	@adr_navurl VARCHAR(255), 
	@adr_impr INT, 
	--@vadr_inamt REAL, 應該是adamt+desamt+chgamt的總和
	@adr_imseq CHAR(2),
	@adr_adamt INT, 
	@adr_desamt INT, 
	@adr_chgamt INT, 
	@adr_remark VARCHAR(50), 
	@adr_fgfixad CHAR(1),
	@errorcode INT OUTPUT
	-- 錯誤碼：-1：空間不足，-2：更新失敗：-3：計數補完失敗
)
AS
BEGIN
SET NOCOUNT ON
BEGIN DISTRIBUTED TRANSACTION myTransaction

SELECT @errorcode=0

DECLARE @fgitri CHAR(2)
DECLARE @adr_projno CHAR(10), @adr_costctr CHAR(7)
IF @adr_imseq <>''
BEGIN
	--    一般合約時，有發票廠商
	SELECT @fgitri=im_fgitri FROM invmfr WHERE im_syscd='C4' AND im_contno=@adr_contno AND im_imseq=@adr_imseq

	-- 找出計劃代號
	IF @fgitri<>'00' 
	BEGIN
		--找出所內或院內的成本中心、計畫代號
		SELECT @adr_projno=proj_projno, @adr_costctr=proj_costctr FROM proj WHERE proj_syscd='C4' AND proj_fgitri=@fgitri
	END
	ELSE
	BEGIN
		-- 院外使用另一個
		SELECT @adr_projno=proj_projno, @adr_costctr=proj_costctr FROM proj WHERE proj_syscd='C4' AND RTRIM(proj_fgitri)=''
	END

END
ELSE
BEGIN
	SELECT @fgitri=''
	SELECT @adr_projno=''
	SELECT @adr_costctr=''
END

DECLARE @adr_impr_old INT
SELECT @adr_impr_old=adr_impr from c4_adr 
	where adr_syscd='C4' and adr_contno=@adr_contno and adr_seq=@adr_seq and adr_addate=@adr_addate

-- 強制設定定播數字為20
IF @adr_impr=20
BEGIN
	SELECT @adr_fgfixad='1'
END

------------------------------------------------------------
--先檢查那一天存不存在
--不存在的話
--由資料庫現有資料最後一天起開始補足
------------------------------------------------------------
DECLARE @iecode INT
DECLARE @lastcntdate CHAR(8)
SELECT @lastcntdate = ISNULL(MAX(cnt_date), '20030101') FROM c4_adcnt WHERE cnt_adcate=@adr_adcate
IF @lastcntdate<@adr_addate
BEGIN

	SELECT @lastcntdate = CONVERT(CHAR(8), DATEADD(DAY, 1, CONVERT(DATETIME, @lastcntdate, 112)), 112)
	EXEC sp_c4_fill_adcnt_block @lastcntdate, @adr_addate, @adr_adcate, @iecode OUTPUT
	IF @iecode = -1
	BEGIN
		--計數補完失敗
		ROLLBACK TRANSACTION
		SELECT @errorcode = -3
		RETURN
	END

END

----------------------------------
-- 檢查落版空間是否足夠
----------------------------------
DECLARE @currentCount INT
IF @adr_keyword='h0'
	BEGIN
		SELECT @currentCount=cnt_h0 FROM c4_adcnt WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h1'
	BEGIN
		SELECT @currentCount=cnt_h1 FROM c4_adcnt WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h2'
	BEGIN
		SELECT @currentCount=cnt_h2 FROM c4_adcnt WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h3'
	BEGIN
		SELECT @currentCount=cnt_h3 FROM c4_adcnt WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h4'
	BEGIN
		SELECT @currentCount=cnt_h4 FROM c4_adcnt WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w1'
	BEGIN
		SELECT @currentCount=cnt_w1 FROM c4_adcnt WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w2'
	BEGIN
		SELECT @currentCount=cnt_w2 FROM c4_adcnt WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w3'
	BEGIN
		SELECT @currentCount=cnt_w3 FROM c4_adcnt WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w4'
	BEGIN
		SELECT @currentCount=cnt_w4 FROM c4_adcnt WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w5'
	BEGIN
		SELECT @currentCount=cnt_w5 FROM c4_adcnt WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE 
		SELECT @currentCount=cnt_w6 FROM c4_adcnt WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate

IF 20<@currentCount - @adr_impr_old + @adr_impr
BEGIN
	--空間不足，無法修改
	ROLLBACK TRANSACTION
	SELECT @errorcode = -1
	RETURN
END
ELSE
BEGIN

	-- 空間足夠，開始UPDATE
	DECLARE @diff INT, @ori_impr INT
	SELECT @ori_impr=adr_impr FROM c4_adr WHERE adr_syscd='C4' AND adr_contno=@adr_contno AND adr_seq=@adr_seq AND adr_addate=@adr_addate
	SELECT @diff=@adr_impr-@ori_impr
	-------------------------
	--更新計數
	-------------------------
	-- UPDATE c4_adcnt把廣告數減一
	IF @adr_keyword='h0'
	BEGIN
		UPDATE c4_adcnt SET cnt_h0=cnt_h0+@diff WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h1'
	BEGIN
		UPDATE c4_adcnt SET cnt_h1=cnt_h1+@diff WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h2'
	BEGIN
		UPDATE c4_adcnt SET cnt_h2=cnt_h2+@diff WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h3'
	BEGIN
		UPDATE c4_adcnt SET cnt_h3=cnt_h3+@diff WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='h4'
	BEGIN
		UPDATE c4_adcnt SET cnt_h4=cnt_h4+@diff WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w1'
	BEGIN
		UPDATE c4_adcnt SET cnt_w1=cnt_w1+@diff WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w2'
	BEGIN
		UPDATE c4_adcnt SET cnt_w2=cnt_w2+@diff WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w3'
	BEGIN
		UPDATE c4_adcnt SET cnt_w3=cnt_w3+@diff WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w4'
	BEGIN
		UPDATE c4_adcnt SET cnt_w4=cnt_w4+@diff WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE
	IF @adr_keyword='w5'
	BEGIN
		UPDATE c4_adcnt SET cnt_w5=cnt_w5+@diff WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate
	END
	ELSE 
		UPDATE c4_adcnt SET cnt_w6=cnt_w6+@diff WHERE cnt_date=@adr_addate AND cnt_adcate=@adr_adcate

	--UPDATE失敗
	IF @@ERROR<>0
	BEGIN
		ROLLBACK TRANSACTION
		SELECT @errorcode=-2
		RETURN
	END
END

----------------------------------
-- 更新廣告
----------------------------------
UPDATE
	c4_adr
SET
	adr_alttext=@adr_alttext,
	adr_adcate=@adr_adcate,
	adr_keyword=@adr_keyword,
	adr_impr=@adr_impr,
	adr_navurl=@adr_navurl,
	adr_imseq=@adr_imseq,
	adr_adamt=@adr_adamt,
	adr_desamt=@adr_desamt,
	adr_chgamt=@adr_chgamt,
	adr_invamt=@adr_adamt+@adr_desamt+@adr_chgamt,
	adr_remark=@adr_remark,
	adr_projno=@adr_projno,
	adr_costctr=@adr_costctr,
	adr_fgfixad=@adr_fgfixad
WHERE
	adr_contno=@adr_contno AND
	adr_seq=@adr_seq AND
	adr_addate=@adr_addate

IF @@ERROR<>0
BEGIN
	ROLLBACK TRANSACTION
	SELECT @errorcode=-2
	RETURN
END



-- Commit 
COMMIT TRANSACTION myTransaction
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- ==========================
-- 更新合約，用於維護合約
-- ==========================
CREATE PROCEDURE dbo.sp_c4_update_cont
(
	@cont_contno CHAR(6),
	@cont_conttp CHAR(2),
	@cont_signdate CHAR(8),
	@cont_sdate CHAR(8),
	@cont_edate CHAR(8),
	@cont_empno CHAR(7),
	@cont_aunm VARCHAR(30),
	@cont_autel VARCHAR(30),
	@cont_aufax VARCHAR(30),
	@cont_aucell VARCHAR(30),
	@cont_auemail VARCHAR(80),
	@cont_freetm INT,
	@cont_pubtm INT,
	@cont_resttm INT,
	@cont_totimgtm INT,
	@cont_toturltm INT,
	@cont_disc REAL,
	@cont_totamt REAL,
	@cont_paidamt REAL,
	@cont_restamt REAL,
	@cont_remark VARCHAR(50),
	@cont_moddate CHAR(8),
	@cont_modempno CHAR(7),
	@cont_fgpayonce CHAR(1),
	@cont_fgclosed CHAR(1),
	@cont_ccont VARCHAR(50),
	@cont_pdcont VARCHAR(500),
	@cont_csdate CHAR(8)
)
AS
BEGIN
	SET NOCOUNT ON
	
	UPDATE
		c4_cont
	SET
		cont_conttp = @cont_conttp,
		cont_signdate = @cont_signdate,
		cont_sdate = @cont_sdate, 
		cont_edate = @cont_edate,
		cont_empno = @cont_empno,
		cont_aunm = @cont_aunm, 
		cont_autel = @cont_autel,
		cont_aufax = @cont_aufax, 
		cont_aucell = @cont_aucell,
		cont_auemail = @cont_auemail, 
		cont_freetm = @cont_freetm, 
		cont_pubtm = @cont_pubtm,
		cont_resttm = @cont_resttm, 
		cont_totimgtm = @cont_totimgtm,
		cont_toturltm = @cont_toturltm, 
		cont_disc = @cont_disc,
		cont_totamt = @cont_totamt,
		cont_paidamt = @cont_paidamt, 
		cont_restamt = @cont_restamt,
		cont_remark = @cont_remark,
		cont_moddate = @cont_moddate,
		cont_modempno = @cont_modempno, 
		cont_fgpayonce = @cont_fgpayonce,
		cont_fgclosed = @cont_fgclosed,
		cont_ccont = @cont_ccont,
		cont_pdcont = @cont_pdcont,
		cont_csdate = @cont_csdate
	WHERE
		(cont_contno = @cont_contno)
	
	SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- ==========================
-- 設定為正式合約
-- ==========================
CREATE PROCEDURE dbo.sp_c4_update_cont_to_be_formal
(
	@cont_contno CHAR(6),
	@cont_conttp CHAR(2),
	@cont_signdate CHAR(8),
	@cont_sdate CHAR(8),
	@cont_edate CHAR(8),
	@cont_empno CHAR(7),
	@cont_mfrno CHAR(10),
	@cont_custno CHAR(6),
	@cont_aunm VARCHAR(30),
	@cont_autel VARCHAR(30),
	@cont_aufax VARCHAR(30),
	@cont_aucell VARCHAR(30),
	@cont_auemail VARCHAR(80),
	@cont_freetm INT,
	@cont_pubtm INT,
	@cont_resttm INT,
	@cont_totimgtm INT,
	@cont_toturltm INT,
	@cont_disc REAL,
	@cont_totamt REAL,
	@cont_paidamt REAL,
	@cont_restamt REAL,
	@cont_remark VARCHAR(50),
	@cont_credate CHAR(8),
	@cont_moddate CHAR(8),
	@cont_modempno CHAR(7),
	@cont_fgpayonce CHAR(1),
	@cont_ccont VARCHAR(50),
	@cont_pdcont VARCHAR(500),
	@cont_csdate CHAR(8),
	@success INT OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON
	
	UPDATE
		c4_cont
	SET
		cont_conttp = @cont_conttp,
		cont_signdate = @cont_signdate,
		cont_sdate = @cont_sdate, 
		cont_edate = @cont_edate,
		cont_empno = @cont_empno,
		cont_mfrno = @cont_mfrno,
		cont_custno = @cont_custno,
		cont_aunm = @cont_aunm, 
		cont_autel = @cont_autel,
		cont_aufax = @cont_aufax, 
		cont_aucell = @cont_aucell,
		cont_auemail = @cont_auemail, 
		cont_freetm = @cont_freetm, 
		cont_pubtm = @cont_pubtm,
		cont_resttm = @cont_resttm, 
		cont_totimgtm = @cont_totimgtm,
		cont_toturltm = @cont_toturltm, 
		cont_disc = @cont_disc,
		cont_totamt = @cont_totamt,
		cont_paidamt = @cont_paidamt, 
		cont_restamt = @cont_restamt,
		cont_remark = @cont_remark,
		cont_credate = @cont_credate,
		cont_moddate = @cont_moddate,
		cont_modempno = @cont_modempno, 
		cont_fgpayonce = @cont_fgpayonce, 
		cont_fgtemp = '0',	--設定為正式，所以不是temp
		cont_fgpubed = '0', 	--才剛剛設定為正式，還沒開始落版
		cont_fgclosed = '0',	--才設定為正式，所以未結案
		cont_fgcancel = '0',	--才設定為正式，所以不為註銷
		cont_ccont = @cont_ccont,
		cont_pdcont = @cont_pdcont,
		cont_csdate = @cont_csdate
	WHERE
		(cont_contno = @cont_contno)
	--檢查有沒成功
	SELECT
		@success=COUNT(*)
	FROM
		c4_cont
	WHERE
		cont_contno = @cont_contno AND
		cont_fgtemp='0'
	
	SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- =======================
-- 修改贈書資料-先刪除，再新增
-- =======================
CREATE PROCEDURE dbo.sp_c4_update_freebk
(
	@new_contno CHAR(6),
	@fbk_fbkitem CHAR(2),
	@fbk_bkcd CHAR(2),
	@ma_oritem CHAR(2),
	@ma_sdate CHAR(6),
	@ma_edate CHAR(6),
	@ma_pubmnt INT,
	@ma_unpubmnt INT,
	@ma_mtpcd CHAR(2),
	@ret_fbkitem CHAR(2) OUTPUT
)
AS
BEGIN
SET NOCOUNT ON
BEGIN  DISTRIBUTED TRANSACTION  myTrans
-- ==============================
-- 先刪除
-- ==============================
DELETE FROM
	c4_ramt
WHERE
	ma_syscd='C4' AND
	ma_contno=@new_contno AND
	ma_fbkitem=@fbk_fbkitem AND
	ma_oritem=@ma_oritem
IF @@ERROR<>0
BEGIN
	SELECT @ret_fbkitem = '00'
	ROLLBACK TRANSACTION
	RETURN
END
DELETE FROM
	c4_freebk
WHERE
	fbk_syscd='C4' AND
	fbk_contno=@new_contno AND
	fbk_fbkitem=@fbk_fbkitem
IF @@ERROR<>0
BEGIN
	SELECT @ret_fbkitem = '00'
	ROLLBACK TRANSACTION
	RETURN
END
-- ==============================
-- 再新增回去
-- ==============================
DECLARE @new_fbkitem CHAR(2)
-- 取得新的贈書項次編號
SELECT @new_fbkitem=CONVERT(CHAR(2), CONVERT(INT, ISNULL(MAX(fbk_fbkitem), '00'))+1)
FROM
	c4_freebk
WHERE
	fbk_syscd = 'C4' AND
	fbk_contno = @new_contno
SELECT @new_fbkitem = CASE
	WHEN LEN(@new_fbkitem) = 1 THEN '0'+@new_fbkitem
	WHEN LEN(@new_fbkitem) = 2 THEN @new_fbkitem
END
-- 新增c4_freebk贈書
INSERT INTO c4_freebk
(
	fbk_syscd, 
	fbk_contno, 
	fbk_fbkitem, 
	fbk_bkcd
)
VALUES
(
	'C4',
	@new_contno,
	@new_fbkitem,
	@fbk_bkcd
)
IF @@ERROR<>0
BEGIN
	SELECT @ret_fbkitem = '00'
	ROLLBACK TRANSACTION
	RETURN
END
-- 新增c4_ramt郵寄份數
INSERT INTO c4_ramt
(
	ma_syscd,
	ma_contno,
	ma_fbkitem,
	ma_oritem,
	ma_sdate,
	ma_edate,
	ma_pubmnt,
	ma_unpubmnt,
	ma_mtpcd
)
VALUES
(
	'C4',
	@new_contno,
	@new_fbkitem,
	@ma_oritem,
	@ma_sdate,
	@ma_edate,
	@ma_pubmnt,
	@ma_unpubmnt,
	@ma_mtpcd
)
IF @@ERROR<>0
BEGIN
	SELECT @ret_fbkitem = '00'
	ROLLBACK TRANSACTION
	RETURN
END
SELECT @ret_fbkitem=@new_fbkitem
COMMIT TRANSACTION  myTrans
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- =======================
-- 修改發票廠商收件人資料
-- =======================
CREATE PROCEDURE dbo.sp_c4_update_im
(
	@im_contno CHAR( 6),
	@im_mfrno CHAR(10),
	@im_imseq CHAR(2),
	@im_nm VARCHAR(30),
	@im_jbti CHAR(12),
	@im_addr CHAR(120),
	@im_zip CHAR(5),
	@im_tel VARCHAR(30),
	@im_fax VARCHAR(30),
	@im_cell VARCHAR(30),
	@im_email VARCHAR(80),
	@im_invcd CHAR(1),
	@im_taxtp CHAR(1),
	@im_fgitri CHAR(2)
)
AS
BEGIN
SET NOCOUNT ON
BEGIN  DISTRIBUTED TRANSACTION  myTrans
UPDATE
	invmfr
SET
	im_mfrno=@im_mfrno,
	im_nm=@im_nm, 
	im_jbti=@im_jbti, 
	im_zip=@im_zip, 
	im_addr=@im_addr,
	im_tel=@im_tel, 
	im_fax=@im_fax, 
	im_cell=@im_cell, 
	im_email=@im_email, 
	im_invcd=@im_invcd, 
	im_taxtp=@im_taxtp, 
	im_fgitri=@im_fgitri
WHERE
	im_syscd='C4' AND
	im_contno=@im_contno AND 
	im_imseq=@im_imseq       
COMMIT TRANSACTION  myTrans
SET NOCOUNT OFF
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS OFF 
GO

-- =====================
--  修改收件人資料
-- =====================
CREATE PROCEDURE dbo.sp_c4_update_or
	@new_contno CHAR(6),
	@or_oritem CHAR(2),
	@or_inm VARCHAR(40),
	@or_nm VARCHAR(30),
	@or_jbti VARCHAR(12),
	@or_addr VARCHAR(120),
	@or_zip CHAR(5),
	@or_tel VARCHAR(30),
	@or_fax VARCHAR(30),
	@or_cell VARCHAR(30),
	@or_email VARCHAR(80),
	@or_fgmosea CHAR(1)
AS
BEGIN
SET NOCOUNT ON
BEGIN DISTRIBUTED TRANSACTION myTransaction
UPDATE
	c4_or
SET
	or_inm = @or_inm,
	or_nm = @or_nm,
	or_jbti = @or_jbti, 
	or_addr = @or_addr, 
	or_zip = @or_zip, 
	or_tel = @or_tel, 
	or_fax = @or_fax, 
	or_cell = @or_cell, 
	or_email = @or_email, 
	or_fgmosea = @or_fgmosea
WHERE
	or_syscd ='C4' AND
	or_contno = @new_contno AND 
	or_oritem = @or_oritem 
-- Commit 
COMMIT TRANSACTION myTransaction
SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

-- =================================
-- 2003/06/12
-- 更新xml file log
-- =================================
CREATE PROCEDURE dbo.sp_c4_update_xml_filg_log
(
	@addate CHAR(8)
)
AS
BEGIN
	SET NOCOUNT ON

	-- 看看有沒有這筆紀錄
	DECLARE @c1 INT
	SELECT @c1=COUNT(*) FROM c4_xmlfilelog WHERE xml_date=@addate

	IF @c1=0
	BEGIN
		-- 資料不存在就INSERT一筆新的
		INSERT INTO c4_xmlfilelog (xml_date, xml_fgexist, xml_createdate) VALUES (@addate, 1, GETDATE())
	END
	ELSE
	BEGIN
		-- 資料存在就遞增flag
		UPDATE c4_xmlfilelog SET xml_fgexist=xml_fgexist+1, xml_createdate=GETDATE() WHERE xml_date=@addate
	END
		

	SET NOCOUNT OFF
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

