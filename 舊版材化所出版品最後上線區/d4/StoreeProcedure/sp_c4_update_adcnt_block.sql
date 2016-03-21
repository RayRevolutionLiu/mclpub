/*************************************************
*--更新計數, 重新計算本日的空間資料
*****************************************************/

CREATE PROCEDURE dbo.sp_c4_update_adcnt_block
(
	@adr_addate CHAR(8)
)
AS
BEGIN
SET NOCOUNT ON
BEGIN TRANSACTION myTransaction

DECLARE @cnt_h0 INT, @cnt_h1 INT, @cnt_h2 INT, @cnt_h3 INT, @cnt_h4 INT
DECLARE @cnt_w1 INT, @cnt_w2 INT, @cnt_w3 INT, @cnt_w4 INT, @cnt_w5 INT, @cnt_w6 INT
DECLARE @adr_adcate char(1)
--首頁
select @adr_adcate = 'M'

SELECT @cnt_h0 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'h0')
SELECT @cnt_h1 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'h1')
SELECT @cnt_h2 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'h2')
SELECT @cnt_h3 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'h3')
SELECT @cnt_h4 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'h4')
SELECT @cnt_w1 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w1')
SELECT @cnt_w2 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w2')
SELECT @cnt_w3 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w3')
SELECT @cnt_w4 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w4')
SELECT @cnt_w5 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w5')
SELECT @cnt_w6 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w6')
	
UPDATE  c4_adcnt
SET     cnt_h0 = @cnt_h0, cnt_h1 = @cnt_h1, cnt_h2 = @cnt_h2, cnt_h3 = @cnt_h3, cnt_h4 = @cnt_h4, cnt_w1 = @cnt_w1, 
        cnt_w2 = @cnt_w2, cnt_w3 = @cnt_w3, cnt_w4 = @cnt_w4, cnt_w5 = @cnt_w5, cnt_w6 = @cnt_w6
WHERE   (cnt_date = @adr_addate) AND (cnt_adcate = @adr_adcate)

--內頁
select @adr_adcate = 'I'

SELECT @cnt_h0 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'h0')
SELECT @cnt_h1 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'h1')
SELECT @cnt_h2 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'h2')
SELECT @cnt_h3 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'h3')
SELECT @cnt_h4 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'h4')
SELECT @cnt_w1 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w1')
SELECT @cnt_w2 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w2')
SELECT @cnt_w3 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w3')
SELECT @cnt_w4 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w4')
SELECT @cnt_w5 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w5')
SELECT @cnt_w6 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w6')
	
UPDATE  c4_adcnt
SET     cnt_h0 = @cnt_h0, cnt_h1 = @cnt_h1, cnt_h2 = @cnt_h2, cnt_h3 = @cnt_h3, cnt_h4 = @cnt_h4, cnt_w1 = @cnt_w1, 
        cnt_w2 = @cnt_w2, cnt_w3 = @cnt_w3, cnt_w4 = @cnt_w4, cnt_w5 = @cnt_w5, cnt_w6 = @cnt_w6
WHERE   (cnt_date = @adr_addate) AND (cnt_adcate = @adr_adcate)
--奈米頁
select @adr_adcate = 'N'

SELECT @cnt_h0 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'h0')
SELECT @cnt_h1 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'h1')
SELECT @cnt_h2 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'h2')
SELECT @cnt_h3 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'h3')
SELECT @cnt_h4 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'h4')
SELECT @cnt_w1 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w1')
SELECT @cnt_w2 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w2')
SELECT @cnt_w3 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w3')
SELECT @cnt_w4 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w4')
SELECT @cnt_w5 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w5')
SELECT @cnt_w6 = ISNULL(SUM(adr_impr), 0) FROM c4_adr
	WHERE (adr_addate = @adr_addate) AND (adr_adcate = @adr_adcate) AND (adr_keyword = 'w6')
	
UPDATE  c4_adcnt
SET     cnt_h0 = @cnt_h0, cnt_h1 = @cnt_h1, cnt_h2 = @cnt_h2, cnt_h3 = @cnt_h3, cnt_h4 = @cnt_h4, cnt_w1 = @cnt_w1, 
        cnt_w2 = @cnt_w2, cnt_w3 = @cnt_w3, cnt_w4 = @cnt_w4, cnt_w5 = @cnt_w5, cnt_w6 = @cnt_w6
WHERE   (cnt_date = @adr_addate) AND (cnt_adcate = @adr_adcate)

-- Commit 
COMMIT TRANSACTION myTransaction
SET NOCOUNT OFF
END

GO

