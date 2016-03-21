using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace mclpub
{
    public class PubFm_label_search_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectBook()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (dbo.proj.proj_fgitri = '')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds, "book");
            return ds;

        }


        public DataSet SelectSrspn()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) ");
            sb.Append(@"AS srspn_empno FROM dbo.srspn WHERE (srspn_atype <> 'A') AND (srspn_atype <> 'F')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds, "srspn");
            return ds;

        }


        public DataSet SelectMtp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT mtp_mtpcd, RTRIM(mtp_nm) AS mtp_nm FROM dbo.mtp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds, "mtp");
            return ds;

        }


        public DataSet SelectC2_cont(string strBkcd, string strConttp, string strEmpNo, string fgMOSea, string strMtpcd, string strYYYYMM)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT DISTINCT TOP 100 PERCENT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno,SUBSTRING(c2_cont.cont_sdate, 1, 4) +'/'+ SUBSTRING(c2_cont.cont_sdate, 5, 6) + ' ~ '");
            sb.Append(@" + SUBSTRING(c2_cont.cont_edate, 1, 4) + '/' + SUBSTRING(c2_cont.cont_edate, 5, 6) AS cont_sedate,dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, ");
            sb.Append(@"dbo.c2_cont.cont_signdate, RTRIM(dbo.c2_cont.cont_empno) AS cont_empno, RTRIM(db");
            sb.Append(@"o.c2_cont.cont_mfrno) AS cont_mfrno, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_ed");
            sb.Append(@"ate, dbo.c2_or.or_oritem, RTRIM(dbo.c2_or.or_inm) AS or_inm, RTRIM(dbo.c2_or.or_");
            sb.Append(@"nm) AS or_nm, dbo.c2_or.or_mtpcd, RTRIM(dbo.mtp.mtp_nm) AS mtp_nm, dbo.c2_or.or_");
            sb.Append(@"pubcnt, dbo.c2_or.or_unpubcnt, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname, dbo.");
            sb.Append(@"c2_or.or_contno, dbo.c2_or.or_syscd, RTRIM(dbo.c2_or.or_zip) AS or_zip, RTRIM(db");
            sb.Append(@"o.c2_or.or_addr) AS or_addr, RTRIM(dbo.c2_or.or_jbti) AS or_jbti, RTRIM(dbo.book");
            sb.Append(@"p.bkp_pno) AS bkp_pno, dbo.c2_pub.pub_yyyymm, dbo.c2_or.or_fgmosea, dbo.c2_cont.");
            sb.Append(@"cont_fgclosed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp FROM dbo.c2_co");
            sb.Append(@"nt INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd INNER JOIN db");
            sb.Append(@"o.c2_or ON dbo.c2_cont.cont_syscd = dbo.c2_or.or_syscd AND dbo.c2_cont.cont_cont");
            sb.Append(@"no = dbo.c2_or.or_contno INNER JOIN dbo.mtp ON dbo.c2_or.or_mtpcd = dbo.mtp.mtp_");
            sb.Append(@"mtpcd INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND");
            sb.Append(@" dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno INNER JOIN dbo.srspn ON dbo.c2_");
            sb.Append(@"cont.cont_empno = dbo.srspn.srspn_empno INNER JOIN dbo.bookp ON dbo.c2_pub.pub_y");
            sb.Append(@"yyymm = dbo.bookp.bkp_date AND dbo.c2_pub.pub_bkcd = dbo.bookp.bkp_bkcd WHERE (d");
            sb.Append(@"bo.c2_cont.cont_fgclosed = '0') AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c");
            sb.Append(@"2_cont.cont_fgtemp = '0') ");
            sb.Append(@" AND or_pubcnt > 0 AND cont_bkcd=@strBkcd AND cont_conttp=@strConttp AND or_fgmosea=@fgMOSea ");

            if (strEmpNo != "")
            {
                sb.Append(@" AND cont_empno=@strEmpNo ");
            }
            if (strYYYYMM != "")
            {
                sb.Append(@" AND cont_sdate<=@strYYYYMM ");
                sb.Append(@" AND cont_edate>=@strYYYYMM");
                sb.Append(@" AND pub_yyyymm=@strYYYYMM");
            }
            if (strMtpcd != "")
            {
                sb.Append(@" AND or_mtpcd=@strMtpcd ");
            }
            sb.Append(@"");
            sb.Append(@" ORDER BY dbo.c2_cont.cont_contno");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@strBkcd", strBkcd);
            oCmd.Parameters.AddWithValue("@strYYYYMM", strYYYYMM);
            oCmd.Parameters.AddWithValue("@strConttp", strConttp);
            oCmd.Parameters.AddWithValue("@strEmpNo", strEmpNo);
            oCmd.Parameters.AddWithValue("@fgMOSea", fgMOSea);
            oCmd.Parameters.AddWithValue("@strMtpcd", strMtpcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet SelectBookp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT bkp_bkcd, bkp_date, bkp_pno FROM dbo.bookp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "bookp");
            return ds;

        }


        public DataSet SelectBookpNo(string strYYYYMM, string strBkcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT bkp_pno FROM bookp WHERE (bkp_date = @strYYYYMM) AND (bkp_bkcd = @strBkcd) ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@strYYYYMM", strYYYYMM);
            oCmd.Parameters.AddWithValue("@strBkcd", strBkcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        //PubFm_label_search2
        public DataSet SelectC2_cont2(string bkcd, string conttp, string fgmosea, string yyyymm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"pubfm_lbl_unpub");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            oCmd.Parameters.AddWithValue("@conttp", conttp);
            oCmd.Parameters.AddWithValue("@fgmosea", fgmosea);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);//這裡的已經被去掉/了 所以不需要再substring
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        //PubFm_label_search3
        public DataSet SelectC2_cont3(string bkcd, string conttp, string yyyymm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT  DISTINCT dbo.c2_cont.cont_contno, dbo.c2_cont.cont_sdate,");
            sb.Append(@"dbo.c2_cont.cont_edate, SUBSTRING(dbo.c2_cont.cont_sdate, 1, 4)");
            sb.Append(@"+ '/' + SUBSTRING(dbo.c2_cont.cont_sdate, 5, 6)");
            sb.Append(@"+ ' ~ ' + SUBSTRING(dbo.c2_cont.cont_edate, 1, 4)");
            sb.Append(@"+ '/' + SUBSTRING(dbo.c2_cont.cont_edate, 5, 6) AS cont_sedate,");
            sb.Append(@"RTRIM(dbo.c2_or.or_inm) AS or_inm, RTRIM(dbo.c2_or.or_nm) AS or_nm,");
            sb.Append(@"RTRIM(dbo.c2_or.or_jbti) AS or_jbti, RTRIM(dbo.c2_or.or_zip) AS or_zip,");
            sb.Append(@"RTRIM(dbo.c2_or.or_addr) AS or_addr, dbo.c2_or.or_unpubcnt,dbo.c2_or.or_pubcnt,");
            sb.Append(@"dbo.c2_or.or_mtpcd, RTRIM(dbo.mtp.mtp_nm) AS mtp_nm,");
            sb.Append(@"RTRIM(dbo.c2_cont.cont_empno) AS cont_empno, dbo.c2_or.or_oritem,");
            sb.Append(@"RTRIM(dbo.book.bk_nm) AS bk_nm,");
            sb.Append(@"CASE WHEN dbo.c2_cont.cont_conttp = '01' THEN '一般' ELSE '推廣' END AS cont_conttpName ");
            sb.Append(@"FROM dbo.c2_cont INNER JOIN dbo.c2_or ON dbo.c2_cont.cont_syscd = dbo.c2_or.or_syscd AND");
            sb.Append(@" dbo.c2_cont.cont_contno = dbo.c2_or.or_contno INNER JOIN ");
            sb.Append(@"dbo.mtp ON dbo.c2_or.or_mtpcd = dbo.mtp.mtp_mtpcd  INNER JOIN ");
            sb.Append(@"dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd ");
            sb.Append(@" INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno ");
            sb.Append(@"WHERE cont_edate<@yyyymm AND ");//只要合約迄月小於輸入之月份 及表示是合約外
            sb.Append(@"(dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_or.or_unpubcnt > 0) ");
            sb.Append(@"AND (c2_cont.cont_bkcd = @bkcd) AND (c2_cont.cont_conttp = @conttp) AND ");
            sb.Append(@"(dbo.c2_cont.cont_fgclosed = '0')  AND (dbo.c2_cont.cont_fgcancel = '0') ");
            //sb.Append(@"AND cont_contno NOT IN (SELECT lp_contno from labelprint where lp_contno=cont_contno AND lp_sdate=cont_sdate AND lp_edate=cont_edate AND lp_oritem=or_oritem) ");
            sb.Append(@"ORDER BY cont_contno desc ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            oCmd.Parameters.AddWithValue("@conttp", conttp);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            //oCmd.Parameters.AddWithValue("@cont_empno", cont_empno);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public void InsertC2_cont3(string contno, string sdate, string edate, string oritem, string printdate, string empno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"INSERT INTO labelprint (lp_contno,lp_sdate,lp_edate,lp_oritem,lp_printdate,lp_empno) VALUES (@contno,@sdate,@edate,@oritem,@printdate,@empno) ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@empno", empno);
            oCmd.Parameters.AddWithValue("@contno", contno);
            oCmd.Parameters.AddWithValue("@sdate", sdate.IndexOf("/") != -1 && sdate.Length == 7 ? sdate.Substring(0, 4) + sdate.Substring(5, 2) : "");
            oCmd.Parameters.AddWithValue("@edate", edate.IndexOf("/") != -1 && edate.Length == 7 ? edate.Substring(0, 4) + edate.Substring(5, 2) : "");
            oCmd.Parameters.AddWithValue("@oritem", oritem);
            oCmd.Parameters.AddWithValue("@printdate", printdate.IndexOf("/") != -1 && printdate.Length == 7 ? printdate.Substring(0, 4) + printdate.Substring(5, 2) : "");
            //oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public DataSet SelectC2_cont3print(string bkcd, string fgmosea,string yyyymm,string empno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT  DISTINCT dbo.c2_cont.cont_contno, dbo.c2_cont.cont_sdate,");
            sb.Append(@"dbo.c2_cont.cont_edate, SUBSTRING(dbo.c2_cont.cont_sdate, 1, 4)");
            sb.Append(@"+ '/' + SUBSTRING(dbo.c2_cont.cont_sdate, 5, 6)");
            sb.Append(@"+ ' ~ ' + SUBSTRING(dbo.c2_cont.cont_edate, 1, 4)");
            sb.Append(@"+ '/' + SUBSTRING(dbo.c2_cont.cont_edate, 5, 6) AS cont_sedate,");
            sb.Append(@"RTRIM(dbo.c2_or.or_inm) AS or_inm, RTRIM(dbo.c2_or.or_nm) AS or_nm,");
            sb.Append(@"RTRIM(dbo.c2_or.or_jbti) AS or_jbti, RTRIM(dbo.c2_or.or_zip) AS or_zip,");
            sb.Append(@"RTRIM(dbo.c2_or.or_addr) AS or_addr, dbo.c2_or.or_unpubcnt,dbo.c2_or.or_pubcnt,");
            sb.Append(@"dbo.c2_or.or_mtpcd, RTRIM(dbo.mtp.mtp_nm) AS mtp_nm,");
            sb.Append(@"RTRIM(dbo.c2_cont.cont_empno) AS cont_empno, dbo.c2_or.or_oritem,");
            sb.Append(@"RTRIM(dbo.book.bk_nm) AS bk_nm,");
            sb.Append(@"CASE WHEN dbo.c2_cont.cont_conttp = '01' THEN '一般' ELSE '推廣' END AS cont_conttpName  ");
            sb.Append(@"FROM dbo.c2_cont INNER JOIN dbo.c2_or ON dbo.c2_cont.cont_syscd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.c2_or.or_syscd AND");
            sb.Append(@" dbo.c2_cont.cont_contno COLLATE Chinese_Taiwan_Stroke_BIN = dbo.c2_or.or_contno INNER JOIN ");
            sb.Append(@"dbo.mtp ON dbo.c2_or.or_mtpcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.mtp.mtp_mtpcd  INNER JOIN ");
            sb.Append(@"dbo.book ON dbo.c2_cont.cont_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.book.bk_bkcd INNER JOIN ");
            sb.Append(@"dbo.labelprint ON dbo.c2_cont.cont_contno COLLATE Chinese_Taiwan_Stroke_BIN = dbo.labelprint.lp_contno ");
            sb.Append(@"AND dbo.c2_cont.cont_sdate COLLATE Chinese_Taiwan_Stroke_BIN = dbo.labelprint.lp_sdate ");
            sb.Append(@"AND dbo.c2_cont.cont_edate COLLATE Chinese_Taiwan_Stroke_BIN = dbo.labelprint.lp_edate ");
            sb.Append(@"AND dbo.c2_or.or_oritem COLLATE Chinese_Taiwan_Stroke_BIN = dbo.labelprint.lp_oritem ");
            sb.Append(@" INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno COLLATE Chinese_Taiwan_Stroke_BIN = dbo.c2_pub.pub_contno ");         
            sb.Append(@"WHERE ");
            sb.Append(@"(dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_or.or_unpubcnt > 0) ");
            sb.Append(@"AND (c2_cont.cont_bkcd = @bkcd) AND ");
            sb.Append(@"(dbo.c2_cont.cont_fgclosed = '0')  AND (dbo.c2_cont.cont_fgcancel = '0') AND (c2_or.or_fgmosea = @fgmosea) ");
            //sb.Append(@" AND (convert(nvarchar(10),YEAR(lp_createdate))+convert(nvarchar(10),replicate('0', (2-LEN(MONTH(lp_createdate)))))+CONVERT(nvarchar(10),MONTH(lp_createdate))) = @yyyymm ");
            sb.Append(@" AND lp_printdate = @yyyymm");
            if (empno.Trim() != "")
            {
                sb.Append(@" AND lp_empno LIKE '%'+@empno+'%'");
            }
            //sb.Append(@" AND (dbo.c2_cont.cont_contno IN (SELECT DISTINCT c2_pub.pub_contno FROM c2_pub WHERE c2_pub.pub_yyyymm = @yyyymm))");
            sb.Append(@" ORDER BY dbo.c2_or.or_unpubcnt, d");
            sb.Append(@"bo.c2_cont.cont_contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            oCmd.Parameters.AddWithValue("@fgmosea", fgmosea);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            oCmd.Parameters.AddWithValue("@empno", empno);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

    }
}