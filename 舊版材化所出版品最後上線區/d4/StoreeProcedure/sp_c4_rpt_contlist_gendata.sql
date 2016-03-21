/*
2003/06/19
���ͧ��ƯS�ʦr��Cwk_c4_matpstring
�������β��~�r��Cwk_c4_atpstring
�����خѤΦ���H��Ʀr��Cwk_c4_fbkstring
���Ѥ��X���ѲM��]�@����^�ϥΡC
*/
CREATE PROCEDURE dbo.sp_c4_rpt_contlist_gendata
AS
BEGIN


SET NOCOUNT ON
BEGIN DISTRIBUTED TRANSACTION myTransaction


-------------------------------------
--        ���M���ȦsTable
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



-- �Ȧs�B�@�ܼ�
DECLARE @tmpcontno CHAR(6)
DECLARE @tmpcls2 VARCHAR(50)
DECLARE @loop INT
-- �ܼƪ�l��
SELECT @tmpcontno = ''
SELECT @tmpcls2 = ''
SELECT @loop=1

--�C�@��cursor���ܼ�
DECLARE @contno CHAR(6), @cls1name VARCHAR(50), @cls2cname VARCHAR(50), @cls3cname VARCHAR(50)

----------------------------
--        ���ƯS��
----------------------------

--���ƯS�ʦr��
DECLARE @matpstring VARCHAR(1000)
SELECT @matpstring = ''

--�s�@cursor
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

	-- �p�G���F�X���s���A�N���ƥ�X�h�A�M�᭫�]�l���h���ܼ�(�Ĥ@����ƨҥ~)
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
	
	--�p�G���F���O�A�N�]�w���j�Ÿ�
	IF @tmpcls2 <> @cls2cname
	BEGIN
		SELECT @matpstring = @matpstring + '*' + @cls2cname + '�G'
	END

	--�զX�r��	
	SELECT @matpstring=@matpstring+@cls3cname +', '


	--�B�z�U�@����ƫe�A���ܼȦs�ܼ�
	SELECT @tmpcls2 = @cls2cname
	SELECT @tmpcontno=@contno
	SELECT @loop = @loop + 1
	FETCH  NEXT FROM  matp_cursor  INTO @contno, @cls1name, @cls2cname, @cls3cname
END

--�����F��̫�@���զX�n����ƥ�X
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


-- �ܼƪ�l��
SELECT @tmpcontno = ''
SELECT @tmpcls2 = ''
SELECT @loop=1
----------------------------
--        ���β��~
----------------------------

--���β��~�r��
DECLARE @atpstring VARCHAR(1000)
SELECT @atpstring = ''

--�s�@cursor
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

	-- �p�G���F�X���s���A�N���ƥ�X�h�A�M�᭫�]�l���h���ܼ�(�Ĥ@����ƨҥ~)
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
	
	--�p�G���F���O�A�N�]�w���j�Ÿ�
	IF @tmpcls2 <> @cls2cname
	BEGIN
		SELECT @atpstring = @atpstring + '*' + @cls2cname + '�G'
	END

	--�զX�r��	
	SELECT @atpstring=@atpstring+@cls3cname +', '


	--�B�z�U�@����ƫe�A���ܼȦs�ܼ�
	SELECT @tmpcls2 = @cls2cname
	SELECT @tmpcontno=@contno
	SELECT @loop = @loop + 1
	FETCH  NEXT FROM  atp_cursor  INTO @contno, @cls1name, @cls2cname, @cls3cname
END

--�����F��̫�@���զX�n����ƥ�X
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



-- �ܼƪ�l��
SELECT @tmpcontno = ''
SELECT @loop=1
----------------------------------------------
--        �خѤ����x����H���
----------------------------------------------


--�خѤ����x����H�r��
DECLARE @fbkstring VARCHAR(1000)
DECLARE @tmpstring VARCHAR(200)
SELECT @fbkstring = ''
SELECT @tmpstring = ''

--�s�@cursor
DECLARE  fbk_cursor  CURSOR FOR 
	SELECT fbk_contno, fbk_fbkitem COLLATE Chinese_Taiwan_Stroke_BIN +'�G'+ fc_nm + '(' + ma_sdate + '~' +  ma_edate + '),(' +
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

	-- �p�G���F�X���s���A�N���ƥ�X�h�A�M�᭫�]�l���h���ܼ�(�Ĥ@����ƨҥ~)
	IF @tmpcontno=@contno OR @loop=1
	BEGIN
		--�զX�r��	
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
	
	--�B�z�U�@����ƫe�A���ܼȦs�ܼ�
	SELECT @tmpcontno=@contno
	SELECT @loop = @loop + 1
	FETCH  NEXT FROM  fbk_cursor INTO @contno, @tmpstring
END

--�����F��̫�@���զX�n����ƥ�X
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
