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

/*	查詢本月是未刊登or有刊登
	並計算要郵寄的數量 */
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
			c4_freebk.fbk_bkcd, '0'	/*本月未刊登*/
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
			c4_freebk.fbk_bkcd, '1' /*本月有刊登*/
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
