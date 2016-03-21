/* C4秎盚セ计参璸 */
/* 璸衡る跋丁いるΤ祅のゼ祅掸计*/
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

/*	琩高セる琌ゼ祅orΤ祅
	璸衡璶秎盚计秖 */
DELETE FROM wk_c4_mail_mnt

declare @contno char(6), @yyyymm char(6)
declare @unpubcount int, @pubcount int
declare @mfrno char(10), @empno char(7), @conttp char(2), @fgmosea char(1), @mtpcd char(2), @bkcd char(2)
declare @pubmnt int, @unpubmnt int

DECLARE Cont_Cursor CURSOR FOR
 select cont_contno
 from c4_cont
 where (  ( dbo.c4_cont.cont_fgcancel = '0' ) AND
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
			--セるゼ祅
			DECLARE my_Cursor CURSOR FOR
			SELECT c4_cont.cont_contno, 
				c4_cont.cont_mfrno, 
				c4_cont.cont_empno, 
				c4_cont.cont_conttp, 
				c4_or.or_fgmosea, 
				c4_ramt.ma_mtpcd, 
				c4_ramt.ma_pubmnt,		/*Τ祅セ计*/
				c4_ramt.ma_unpubmnt,	/*ゼ祅セ计*/
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
			--セるΤ祅
			DECLARE my_Cursor CURSOR FOR
			SELECT c4_cont.cont_contno, 
				c4_cont.cont_mfrno, 
				c4_cont.cont_empno, 
				c4_cont.cont_conttp, 
				c4_or.or_fgmosea, 
				c4_ramt.ma_mtpcd, 
				c4_ramt.ma_pubmnt,		/*Τ祅セ计*/
				c4_ramt.ma_unpubmnt,	/*ゼ祅セ计*/
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
