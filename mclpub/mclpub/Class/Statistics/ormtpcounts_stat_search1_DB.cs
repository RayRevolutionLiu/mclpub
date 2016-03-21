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
    public class ormtpcounts_stat_search1_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectBook()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd,");
            sb.Append(@" dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON");
            sb.Append(@" dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (RTRIM(LTRIM(dbo.proj.proj_fgitri)) = '')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet SelectC2_or(string strConttp, string strBkcd, string strYYYYMM, string fgMOSea, string strMailType)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT DISTINCT dbo.c2_cont.cont_conttp, CASE WHEN cont_conttp = '01' THEN '一般' ELSE '推廣' END AS cont_conttpName, dbo.c2_cont.cont_bkcd");
            sb.Append(@", dbo.book.bk_nm, dbo.c2_or.or_mtpcd, dbo.mtp.mtp_nm, dbo.c2_or.or_pubcnt, COUNT(dbo.c2_or.or_pubcnt) AS PubCounts, dbo.c2_or.or_fgmosea,");
            sb.Append(@" dbo.c2_pub.pub_yyyymm, dbo.bookp.bkp_pno, dbo.c2_or.or_pubcnt * COUNT(dbo.c2_or.or_pubcnt) AS SumCounts FROM dbo.c2_cont INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = ");
            sb.Append(@"dbo.book.bk_bkcd INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno INNER JOIN");
            sb.Append(@" dbo.c2_or ON dbo.c2_pub.pub_syscd = dbo.c2_or.or_syscd AND dbo.c2_pub.pub_contno = dbo.c2_or.or_contno INNER JOIN dbo.mtp ON dbo.c2_or.or_mtpcd = dbo.mtp.mtp_mtpcd");
            sb.Append(@" INNER JOIN dbo.bookp ON dbo.c2_pub.pub_yyyymm = dbo.bookp.bkp_date AND dbo.c2_pub.pub_bkcd = dbo.bookp.bkp_bkcd WHERE (dbo.c2_cont.cont_fgclosed = '0')");
            sb.Append(@" AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0') ");
            if (strConttp != "")
            {
                sb.Append(@" AND (cont_conttp = @cont_conttp) ");
            }
            if (strBkcd != "")
            {
                sb.Append(@" AND cont_bkcd = @cont_bkcd ");
            }
            if (strYYYYMM != "")
            {
                sb.Append(@" AND pub_yyyymm = @pub_yyyymm ");
                //sb.Append(@" AND cont_sdate<=@pub_yyyymm  AND cont_edate>=@pub_yyyymm ");//新功能只要新增這行就好 如果被問說查出來的筆數跟標籤不一樣 就要他看登本數的總和就對了
            }
            if (fgMOSea != "")
            {
                sb.Append(@" AND or_fgmosea = @or_fgmosea ");
            }
            if (strMailType != "")
            {
                if (strMailType == "0")
                {
                    sb.Append(@" AND or_mtpcd = '11' ");
                }
                else
                {
                    sb.Append(@" AND or_mtpcd <> '11' ");
                }
            }
            //sb.Append(@"");
            //sb.Append(@"");
            sb.Append(@" GROUP BY dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_bkcd, dbo.book.bk_nm,");
            sb.Append(@" dbo.c2_or.or_mtpcd, dbo.mtp.mtp_nm, dbo.c2_or.or_pubcnt, dbo.c2_or.or_fgmosea, dbo.c2_pub.pub_yyyymm, dbo.bookp.bkp_pno ORDER BY dbo.c2_or.or_mtpcd");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cont_conttp", strConttp);
            oCmd.Parameters.AddWithValue("@cont_bkcd", strBkcd);
            oCmd.Parameters.AddWithValue("@pub_yyyymm", strYYYYMM);
            oCmd.Parameters.AddWithValue("@or_fgmosea", fgMOSea);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet Selectbkp_pno(string strYYYYMM, string strBkcd)
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


        public void Runsp_c2_ORMtpCounts_stat2b(string bkcd, string conttp, string fgmosea, string yyyymm)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"sp_c2_ORMtpCounts_stat2b";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            oCmd.Parameters.AddWithValue("@conttp", conttp);
            oCmd.Parameters.AddWithValue("@fgmosea", fgmosea);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }


        public DataSet Selectwk_c2_rp3()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT mtpcd, mtpnm, bknm, conttpnm, Unpubcnt, COUNT(Unpubcnt) AS UnPubCounts, Unpubcnt * COUNT(Unpubcnt) AS SumCounts FROM dbo.wk_c2_rp3 GROUP BY mtpcd, mtpnm, bknm, conttpnm, Unpubcnt");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}