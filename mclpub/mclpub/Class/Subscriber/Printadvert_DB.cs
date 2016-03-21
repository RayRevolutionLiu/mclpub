using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class Printadvert_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataTable SelectddlItpcdDrpdownList()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT itp_itpcd, itp_nm FROM itp");
            //if (mfr_inm.ToString() != "")
            //{
            //    sb.Append(@"AND mfr_inm LIKE '%'+@mfr_inm+'%' ");
            //}
            //if (mfr_mfrno.ToString() != "")
            //{
            //    sb.Append(@"AND mfr_mfrno LIKE '%'+@mfr_mfrno+'%' ");
            ////}
            //sb.Append(@"order by mfr_inm");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@mfr_inm", mfr_inm);
            //oCmd.Parameters.AddWithValue("@mfr_mfrno", mfr_mfrno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }

        public DataTable SelectddlBtpcdDrpdownList()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT btp_btpcd, btp_nm FROM btp");
            //if (mfr_inm.ToString() != "")
            //{
            //    sb.Append(@"AND mfr_inm LIKE '%'+@mfr_inm+'%' ");
            //}
            //if (mfr_mfrno.ToString() != "")
            //{
            //    sb.Append(@"AND mfr_mfrno LIKE '%'+@mfr_mfrno+'%' ");
            ////}
            //sb.Append(@"order by mfr_inm");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@mfr_inm", mfr_inm);
            //oCmd.Parameters.AddWithValue("@mfr_mfrno", mfr_mfrno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }


        public DataTable SelectddlBookCodeDrpdownList()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT bk_bkid, bk_bkcd, RTRIM(bk_nm) AS bk_nm,proj_syscd, proj_bkcd, proj_fgitri,proj_projno, proj_costctr ");
            sb.Append(@"FROM book INNER JOIN proj ON bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = proj_bkcd WHERE (proj_syscd = 'C2') AND (proj_fgitri = ' ')");
            //if (mfr_inm.ToString() != "")
            //{
            //    sb.Append(@"AND mfr_inm LIKE '%'+@mfr_inm+'%' ");
            //}
            //if (mfr_mfrno.ToString() != "")
            //{
            //    sb.Append(@"AND mfr_mfrno LIKE '%'+@mfr_mfrno+'%' ");
            ////}
            //sb.Append(@"order by mfr_inm");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@mfr_inm", mfr_inm);
            //oCmd.Parameters.AddWithValue("@mfr_mfrno", mfr_mfrno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }

        public DataTable SelectddlMtpcdDrpdownList()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT mtp_mtpcd, RTRIM(mtp_nm) AS mtp_nm FROM mtp");
            //if (mfr_inm.ToString() != "")
            //{
            //    sb.Append(@"AND mfr_inm LIKE '%'+@mfr_inm+'%' ");
            //}
            //if (mfr_mfrno.ToString() != "")
            //{
            //    sb.Append(@"AND mfr_mfrno LIKE '%'+@mfr_mfrno+'%' ");
            ////}
            //sb.Append(@"order by mfr_inm");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@mfr_inm", mfr_inm);
            //oCmd.Parameters.AddWithValue("@mfr_mfrno", mfr_mfrno);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }


        //-----以下為查詢command

        public DataTable Select1Chkbtn(string CustNoQ1, string CustNoQ2, string TelAC, string Itpcd, string Btpcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT cust.cust_custno, cust.cust_mfrno, cust.cust_nm,");
            sb.Append(@"cust.cust_jbti, cust.cust_tel, cust.cust_fax, cust.cust_cell,");
            sb.Append(@"cust.cust_email, cust.cust_itpcd, cust.cust_btpcd, ");
            sb.Append(@"cust.cust_rtpcd, mfr.mfr_inm, mfr.mfr_izip, mfr.mfr_iaddr,");
            sb.Append(@"cust.cust_regdate, mfr.mfr_respnm ");
            sb.Append(@"FROM cust INNER JOIN ");
            sb.Append(@"mfr ON cust.cust_mfrno = mfr.mfr_mfrno WHERE 1=1 ");

            if (CustNoQ1.ToString() != "" && CustNoQ2.ToString() != "")
            {
                sb.Append(@" and cust_custno BETWEEN @CustNoQ1 AND @CustNoQ2");
            }
            if (TelAC.ToString() != "")
            {
                sb.Append(@" and cust_tel LIKE '%'+@TelAC+'%'");
            }
            if (Itpcd.ToString() != "00")
            {
                sb.Append(@" and CHARINDEX(@Itpcd, cust_itpcd)<>0");
            }
            if (Btpcd.ToString() != "00")
            {
                sb.Append(@" and CHARINDEX(@Btpcd, cust_btpcd)<>0");
            }
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@CustNoQ1", CustNoQ1);
            oCmd.Parameters.AddWithValue("@CustNoQ2", CustNoQ2);
            oCmd.Parameters.AddWithValue("@TelAC", TelAC);
            oCmd.Parameters.AddWithValue("@Itpcd", Itpcd);
            oCmd.Parameters.AddWithValue("@Btpcd", Btpcd);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }


        public DataTable Select2Chkbtn(string ddlConttp, string ddlBookCode)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT DISTINCT TOP 100 PERCENT cont_contno, RTRIM(cont_custno) AS cont_custno, ");
            sb.Append(@"RTRIM(cont_mfrno) AS cont_mfrno, RTRIM(mfr_inm) AS mfr_inm,RTRIM(cust_nm) AS cust_nm,cont_aunm, ");
            sb.Append(@"RTRIM(cust_jbti) AS cust_jbti, cust_tel,cust_fax,cont_signdate,cont_sdate,cont_edate,cont_autel,");
            sb.Append(@"cust_cell,cust_email,cust_regdate,cust_moddate,cust_itpcd,cust_btpcd,cust_rtpcd,mfr_respnm, ");
            sb.Append(@"RTRIM(mfr_respjbti) AS mfr_respjbti, RTRIM(mfr_izip) AS mfr_izip, RTRIM(mfr_iaddr) AS mfr_iaddr, ");
            sb.Append(@"cont_syscd, cust_custno, mfr_mfrno, cont_conttp, RTRIM(cont_empno) AS cont_empno, RTRIM(srspn_cname) AS srspn_cname, ");
            sb.Append(@"cont_bkcd FROM c2_cont INNER JOIN cust ON cont_custno = cust_custno INNER JOIN mfr ON cont_mfrno = dbo.mfr.mfr_mfrno ");
            sb.Append(@"INNER JOIN srspn ON cont_empno = srspn_empno WHERE (cont_fgclosed = '0') AND (cont_fgcancel = '0') AND (cont_fgtemp = '0') ");
            sb.Append(@"AND cont_conttp=@ddlConttp AND cont_bkcd=@ddlBookCode ");
            sb.Append(@"ORDER BY cont_bkcd, cont_empno, cont_contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@ddlConttp", ddlConttp);
            oCmd.Parameters.AddWithValue("@ddlBookCode", ddlBookCode);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }


        public DataTable Select3Chkbtn(string ddlConttp2, string ddlBookCode2, string ddlMtpcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT DISTINCT TOP 100 PERCENT dbo.c2_cont.cont_contno, RTRIM(dbo.c2_cont.cont_custno) AS cont_custno, ");
            sb.Append(@"RTRIM(dbo.c2_cont.cont_mfrno) AS cont_mfrno, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, RTRIM(dbo.cust.cust_nm) AS cust_nm, RTRIM(dbo.cust.cust_jbti) AS cust_jbti,");
            sb.Append(@"dbo.cust.cust_tel, dbo.cust.cust_fax, dbo.cust.cust_cell, dbo.cust.cust_email, dbo.cust.cust_regdate, dbo.cust.cust_moddate, dbo.cust.cust_itpcd, ");
            sb.Append(@"dbo.cust.cust_btpcd, dbo.cust.cust_rtpcd, dbo.mfr.mfr_respnm, RTRIM(dbo.mfr.mfr_respjbti) AS mfr_respjbti,");
            sb.Append(@"RTRIM(dbo.mfr.mfr_izip) AS mfr_izip, RTRIM(dbo.mfr.mfr_iaddr) AS mfr_iaddr, dbo.c2_cont.cont_syscd, dbo.cust.cust_custno, ");
            sb.Append(@"dbo.mfr.mfr_mfrno, dbo.c2_cont.cont_conttp, RTRIM(dbo.c2_cont.cont_empno) AS cont_empno, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname,");
            sb.Append(@"dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate, dbo.c2_cont.cont_aunm,");
            sb.Append(@"dbo.c2_cont.cont_autel, SUBSTRING(dbo.c2_cont.cont_sdate, 1, 4) + '/' + SUBSTRING(dbo.c2_cont.cont_sdate, 5, 6) + '~' + SUBSTRING(dbo.c2_cont.cont_edate, 1, 4) + '/' + SUBSTRING(dbo.c2_cont.cont_edate, 5, 6) AS cont_sedate,");
            sb.Append(@"CASE WHEN dbo.c2_cont.cont_conttp = '01' THEN '一般' ELSE '推廣' END AS cont_conttpName,");
            sb.Append(@"dbo.c2_or.or_inm, dbo.c2_or.or_nm, dbo.c2_or.or_jbti, dbo.c2_or.or_addr, dbo.c2_or.or_zip,");
            sb.Append(@"dbo.c2_or.or_pubcnt, dbo.c2_or.or_unpubcnt, dbo.c2_or.or_fgmosea, dbo.c2_or.or_mtpcd, RTRIM(dbo.mtp.mtp_nm) AS mtp_nm,");
            sb.Append(@"RTRIM(dbo.book.bk_nm) AS bk_nm FROM dbo.c2_cont ");
            sb.Append(@"INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno ");
            sb.Append(@"INNER JOIN dbo.srspn ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno INNER JOIN dbo.c2_or ON dbo.c2_cont.cont_syscd = dbo.c2_or.or_syscd ");
            sb.Append(@"AND dbo.c2_cont.cont_contno = dbo.c2_or.or_contno INNER JOIN dbo.mtp ON dbo.c2_or.or_mtpcd = dbo.mtp.mtp_mtpcd ");
            sb.Append(@"INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd WHERE (dbo.c2_cont.cont_fgclosed = '0') AND (dbo.c2_cont.cont_fgcancel = '0') ");
            sb.Append(@"AND (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_or.or_pubcnt > 0) AND cont_bkcd=@ddlBookCode2 AND cont_conttp=@ddlConttp2");

            if (ddlMtpcd.ToString() != "00")
            {
                sb.Append(@" AND or_mtpcd=@ddlMtpcd ");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@ddlConttp2", ddlConttp2);
            oCmd.Parameters.AddWithValue("@ddlBookCode2", ddlBookCode2);
            oCmd.Parameters.AddWithValue("@ddlMtpcd", ddlMtpcd);
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;

        }
    }
}
