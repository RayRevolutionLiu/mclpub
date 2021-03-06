USE [mrlpub]
GO
/****** Object:  StoredProcedure [pubmrlpub].[Subscriber_CustListFilter]    Script Date: 06/30/2011 11:23:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [pubmrlpub].[Subscriber_CustListFilter]
@ddlCustType nvarchar(500),
@tbxOrderDate1 nvarchar(500),
@tbxOrderDate2 nvarchar(500),
@tbxDate1 nvarchar(500),
@tbxDate2 nvarchar(500),
@ddlOrderType1 nvarchar(500),
@ddlOrderType2 nvarchar(500),
@ddlBookType nvarchar(500),
@ddlMailType nvarchar(500),
@tbxRecName nvarchar(500),
@tbxDate nvarchar(500),
@top300 nvarchar(500),
@WebOrExcel nvarchar(500)
            
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @ALL nvarchar(max)
	DECLARE @WHERE nvarchar(max)
	--DECLARE @TOTAL nvarchar(max)
	
	set @ALL = 'SELECT '+@top300+' od_odid, od_syscd, od_custno, od_otp1cd, od_otp1seq, od_oditem, od_sdate,od_edate, od_btpcd, od_amt, or_inm, or_nm, or_addr, or_zip, or_tel, ra_mnt, 
	o_pytpcd, o_otp1seq, ra_oditem, ra_oritem, o_custno, o_otp1cd, o_syscd,or_custno, or_oritem, or_otp1cd, or_otp1seq, or_syscd, ra_custno, ra_otp1cd, 
	 ra_otp1seq, ra_syscd,od_syscd + od_custno + od_otp1cd + od_otp1seq AS nostr, o_date, obtp_obtpnm, obtp_obtpcd,obtp_otp1cd, od_sdate + ''~'' + od_edate AS datestr, o_fgpreinv, 
	 o_indate,o_empno, ra_mtpcd,o_otp2cd into #tmp1 FROM c1_od INNER JOIN c1_order ON od_syscd = o_syscd AND od_custno = o_custno AND od_otp1cd = o_otp1cd AND od_otp1seq = o_otp1seq INNER JOIN c1_ramt ON od_syscd = ra_syscd AND od_custno = ra_custno AND od_otp1cd = ra_otp1cd AND 
	 od_otp1seq = ra_otp1seq AND od_oditem = ra_oditem INNER JOIN c1_or ON ra_syscd = or_syscd AND ra_custno = or_custno AND ra_otp1cd = 
	 or_otp1cd AND ra_otp1seq = or_otp1seq AND ra_oritem = or_oritem LEFT OUTER JOIN c1_obtp ON od_btpcd = obtp_obtpcd AND od_otp1cd = obtp_otp1cd WHERE (od_syscd = ''C1'')'
	 
	 if(@ddlCustType is null)
	 begin
		set @WHERE =' and 1=1'
	 end
	 else
	 begin
			if(@ddlCustType='新訂戶')
			begin
				set @WHERE = ' and od_otp1seq=''001'''
			end
			else
			begin
				set @WHERE = ' and od_otp1seq<>''001'''
			end
	 end
	 
	 if(@tbxOrderDate1 is not null and @tbxOrderDate2 is not null)
	 begin
		set @WHERE = @WHERE + ' and (o_date>='''+@tbxOrderDate1+''' and o_date<='''+@tbxOrderDate2+''')'
	 end
	 
	 if(@tbxDate1 is not null and @tbxDate2 is not null)
	 begin
		set @WHERE = @WHERE + ' and (o_indate>='''+@tbxDate1+''' and o_indate<='''+@tbxDate2+''')'
	 end
	 
	 if(@ddlOrderType1 is not null)
	 begin
		set @WHERE = @WHERE + ' and od_otp1cd='''+@ddlOrderType1+''''
	 end
	 
	 if(@ddlOrderType2 is not null)
	 begin
		set @WHERE = @WHERE + ' and o_otp2cd='''+@ddlOrderType2+''''
	 end
	 
	 if(@ddlBookType is not null)
	 begin
		set @WHERE = @WHERE + ' and od_btpcd='''+@ddlBookType+''''
	 end
	 
	 if(@ddlMailType is not null)
	 begin
		set @WHERE = @WHERE + ' and ra_mtpcd='''+@ddlMailType+''''
	 end
	 
	 if(@tbxRecName is not null)
	 begin
		set @WHERE = @WHERE + ' or_nm LIKE ''%' + @tbxRecName + '%'''
	 end
	 
	 if(@tbxDate is not null)
	 begin
		set @WHERE = @WHERE + ' and (od_sdate <= '''+@tbxDate+''' and od_edate >= '''+@tbxDate+''')'
	 end
	 
	 if(@WebOrExcel='web')
	 begin
		set @ALL = @ALL+@WHERE+';SELECT * FROM #tmp1;'
	 end

	 if(@WebOrExcel='excel')
	 begin
		set @ALL = @ALL+@WHERE+';SELECT * FROM #tmp1 INNER JOIN c1_cust ON #tmp1.od_custno = c1_cust.cust_custno INNER JOIN mtp ON #tmp1.ra_mtpcd = mtp.mtp_mtpcd;'
	 end
	 
	 EXEC sp_executesql @ALL
END
