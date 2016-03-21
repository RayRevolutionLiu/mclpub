/*******************************************************
	2003/05/16�A�s�睊
	�ק�s�i������ơA�b�~�ȸ����ɪ��ק�
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
	--@vadr_inamt REAL, ���ӬOadamt+desamt+chgamt���`�M
	@adr_imseq CHAR(2),
	@adr_adamt INT, 
	@adr_desamt INT, 
	@adr_chgamt INT, 
	@adr_remark VARCHAR(50), 
	@adr_fgfixad CHAR(1),
	@errorcode INT OUTPUT
	-- ���~�X�G-1�G�Ŷ������A-2�G��s���ѡG-3�G�p�Ƹɧ�����
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
	--    �@��X���ɡA���o���t��
	SELECT @fgitri=im_fgitri FROM invmfr WHERE im_syscd='C4' AND im_contno=@adr_contno AND im_imseq=@adr_imseq

	-- ��X�p���N��
	IF @fgitri<>'00' 
	BEGIN
		--��X�Ҥ��ΰ|�����������ߡB�p�e�N��
		SELECT @adr_projno=proj_projno, @adr_costctr=proj_costctr FROM proj WHERE proj_syscd='C4' AND proj_fgitri=@fgitri
	END
	ELSE
	BEGIN
		-- �|�~�ϥΥt�@��
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

-- �j��]�w�w���Ʀr��20
IF @adr_impr=20
BEGIN
	SELECT @adr_fgfixad='1'
END

------------------------------------------------------------
--���ˬd���@�Ѧs���s�b
--���s�b����
--�Ѹ�Ʈw�{����Ƴ̫�@�Ѱ_�}�l�ɨ�
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
		--�p�Ƹɧ�����
		ROLLBACK TRANSACTION
		SELECT @errorcode = -3
		RETURN
	END

END

----------------------------------
-- �ˬd�����Ŷ��O�_����
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
	--�Ŷ������A�L�k�ק�
	ROLLBACK TRANSACTION
	SELECT @errorcode = -1
	RETURN
END
ELSE
BEGIN

	-- �Ŷ������A�}�lUPDATE
	DECLARE @diff INT, @ori_impr INT
	SELECT @ori_impr=adr_impr FROM c4_adr WHERE adr_syscd='C4' AND adr_contno=@adr_contno AND adr_seq=@adr_seq AND adr_addate=@adr_addate
	SELECT @diff=@adr_impr-@ori_impr
	-------------------------
	--��s�p��, ���s�p�⥻�骺�Ŷ����
	-------------------------
	
	-- UPDATE c4_adcnt��s�i�ƴ�@
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

	--UPDATE����
	IF @@ERROR<>0
	BEGIN
		ROLLBACK TRANSACTION
		SELECT @errorcode=-2
		RETURN
	END
END

----------------------------------
-- ��s�s�i
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
