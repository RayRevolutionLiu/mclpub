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
    public class orcounts_stat_search1_DB
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


        public DataSet Selectmtp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT mtp_mtpcd, RTRIM(mtp_nm) AS mtp_nm FROM dbo.mtp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
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


        public DataSet Selectc2_cont(string cont_bkcd, string pub_yyyymm, string cont_conttp, string or_fgmosea, string or_mtpcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT DISTINCT dbo.c2_or.or_contno, dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_bkcd, RTRIM(dbo.book.bk_nm) ");
            sb.Append(@"AS bk_nm, RTRIM(dbo.c2_cont.cont_mfrno) AS cont_mfrno, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, dbo.c2_or.or_fgmosea,");
            sb.Append(@" dbo.c2_or.or_mtpcd, RTRIM(dbo.mtp.mtp_nm) AS mtp_nm, COUNT(dbo.c2_or.or_pubcnt) AS PubCounts, dbo.c2_pub.pub_yyyymm, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate,");
            sb.Append(@" SUBSTRING(dbo.c2_cont.cont_sdate, 1, 4) + '/' + SUBSTRING(dbo.c2_cont.cont_sdate, 5, 2) + ' ~ ' + SUBSTRING(dbo.c2_cont.cont_edate, 1, 4) + '/' + ");
            sb.Append(@"SUBSTRING(dbo.c2_cont.cont_edate, 5, 2) AS cont_sedate FROM dbo.c2_cont INNER JOIN dbo.c2_or ON dbo.c2_cont.cont_syscd = dbo.c2_or.or_syscd AND dbo.c2_cont.cont_contno");
            sb.Append(@" = dbo.c2_or.or_contno INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.mtp ON dbo.c2_or.or_mtpcd = dbo.mtp.mtp_mtpcd INNER JOIN ");
            sb.Append(@"dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd ");
            sb.Append(@"= dbo.book.bk_bkcd WHERE (dbo.c2_cont.cont_fgclosed = '0') AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0') ");
            sb.Append(@" AND cont_bkcd = @cont_bkcd AND pub_yyyymm = @pub_yyyymm ");
            //sb.Append(@" AND cont_sdate<=@pub_yyyymm  AND cont_edate>=@pub_yyyymm ");//新功能只要新增這行就好 如果被問說查出來的筆數跟標籤不一樣 就要他看登本數的總和就對了
            if (cont_conttp != "")
            {
                sb.Append(@" AND cont_conttp = @cont_conttp ");
            }
            if (or_fgmosea != "")
            {
                sb.Append(@" AND or_fgmosea = @or_fgmosea ");
            }
            if (or_mtpcd != "")
            {
                sb.Append(@" AND or_mtpcd = @or_mtpcd ");
            }
            sb.Append(@"GROUP BY dbo.c2_or.or_contno,");
            sb.Append(@" dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_bkcd, dbo.book.bk_nm, dbo.c2_cont.cont_mfrno, dbo.mfr.mfr_inm, dbo.c2_or.or_fgmosea, dbo.c2_or.or_mtpcd");
            sb.Append(@", dbo.mtp.mtp_nm, dbo.c2_pub.pub_yyyymm, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate ORDER BY dbo.c2_or.or_mtpcd, dbo.c2_or.or_contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@cont_bkcd", cont_bkcd);
            oCmd.Parameters.AddWithValue("@pub_yyyymm", pub_yyyymm);
            oCmd.Parameters.AddWithValue("@cont_conttp", cont_conttp);
            oCmd.Parameters.AddWithValue("@or_fgmosea", or_fgmosea);
            oCmd.Parameters.AddWithValue("@or_mtpcd", or_mtpcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet Selectc2_cont2(string cont_bkcd, string pub_yyyymm, string cont_conttp, string or_fgmosea, string or_mtpcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c2_cont.cont_contno, c2_cont.cont_mfrno, ");
            sb.Append(@"RTRIM(mfr.mfr_inm) AS mfr_inm, c2_or.or_mtpcd, ");
            sb.Append(@"RTRIM(mtp.mtp_nm) AS mtp_nm, COUNT(c2_or.or_unpubcnt) ");
            sb.Append(@"AS UnPubCounts, c2_cont.cont_sdate, c2_cont.cont_edate,");
            sb.Append(@"SUBSTRING(c2_cont.cont_sdate, 1, 4)+ '/' + SUBSTRING(c2_cont.cont_sdate, 5, 6)");
            sb.Append(@"+ ' ~ ' + SUBSTRING(c2_cont.cont_edate, 1, 4)+ '/' + SUBSTRING(c2_cont.cont_edate, 5, 6) AS cont_sedate,");
            sb.Append(@"c2_cont.cont_conttp, c2_or.or_fgmosea FROM c2_cont INNER JOIN ");
            sb.Append(@"c2_or ON c2_cont.cont_syscd = c2_or.or_syscd AND c2_cont.cont_contno = c2_or.or_contno INNER JOIN ");
            sb.Append(@"mtp ON c2_or.or_mtpcd = mtp.mtp_mtpcd INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno ");
            sb.Append(@"WHERE (c2_cont.cont_fgclosed = '0') AND (c2_cont.cont_contno NOT IN (SELECT DISTINCT c2_pub.pub_contno ");
            sb.Append(@"FROM c2_pub WHERE c2_pub.pub_yyyymm = @yyyymm)) AND (c2_or.or_unpubcnt > 0) AND (c2_cont.cont_fgcancel = '0') AND ");
            sb.Append(@"(c2_cont.cont_fgtemp = '0') AND (c2_cont.cont_bkcd = @bkcd) ");
            //sb.Append(@" AND cont_sdate<=@yyyymm AND cont_edate>=@yyyymm ");//新功能只要新增這行就好 如果被問說查出來的筆數跟標籤不一樣 就要他看登本數的總和就對了
            if (cont_conttp != "")
            {
                sb.Append(@" AND cont_conttp = @cont_conttp ");
            }
            if (or_fgmosea != "")
            {
                sb.Append(@" AND or_fgmosea = @or_fgmosea ");
            }
            if (or_mtpcd != "")
            {
                sb.Append(@" AND or_mtpcd = @or_mtpcd ");
            }
            sb.Append(@" GROUP BY c2_cont.cont_contno, c2_cont.cont_mfrno, mfr.mfr_inm,c2_or.or_mtpcd, mtp.mtp_nm, c2_cont.cont_sdate,");
            sb.Append(@" c2_cont.cont_edate, c2_cont.cont_conttp, c2_or.or_fgmosea ORDER BY  c2_or.or_mtpcd, c2_cont.cont_contno ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkcd", cont_bkcd);
            oCmd.Parameters.AddWithValue("@yyyymm", pub_yyyymm);
            oCmd.Parameters.AddWithValue("@cont_conttp", cont_conttp);
            oCmd.Parameters.AddWithValue("@or_fgmosea", or_fgmosea);
            oCmd.Parameters.AddWithValue("@or_mtpcd", or_mtpcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet Selectc2_cont3(string cont_bkcd, string pub_yyyymm, string cont_conttp, string or_fgmosea, string or_mtpcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT DISTINCT TOP 100 PERCENT c2_cont.cont_contno, c2_cont.cont_mfrno, ");
            sb.Append(@"RTRIM(mfr.mfr_inm) AS mfr_inm, c2_or.or_mtpcd, ");
            sb.Append(@"RTRIM(mtp.mtp_nm) AS mtp_nm,c2_or.or_unpubcnt ");
            sb.Append(@"AS UnPubCounts, c2_cont.cont_sdate, c2_cont.cont_edate,");
            sb.Append(@"SUBSTRING(c2_cont.cont_sdate, 1, 4)+ '/' + SUBSTRING(c2_cont.cont_sdate, 5, 6)");
            sb.Append(@"+ ' ~ ' + SUBSTRING(c2_cont.cont_edate, 1, 4)+ '/' + SUBSTRING(c2_cont.cont_edate, 5, 6) AS cont_sedate,");
            sb.Append(@"c2_cont.cont_conttp, c2_or.or_fgmosea FROM c2_cont INNER JOIN ");
            sb.Append(@"c2_or ON c2_cont.cont_syscd = c2_or.or_syscd AND c2_cont.cont_contno = c2_or.or_contno INNER JOIN ");
            sb.Append(@"mtp ON c2_or.or_mtpcd = mtp.mtp_mtpcd INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN ");
            sb.Append(@"dbo.labelprint ON dbo.c2_cont.cont_contno = dbo.labelprint.lp_contno ");
            sb.Append(@"AND dbo.c2_cont.cont_sdate = dbo.labelprint.lp_sdate ");
            sb.Append(@"AND dbo.c2_cont.cont_edate = dbo.labelprint.lp_edate ");
            sb.Append(@"AND dbo.c2_or.or_oritem = dbo.labelprint.lp_oritem ");
            sb.Append(@"WHERE (c2_cont.cont_fgclosed = '0')");
            sb.Append(@" AND (c2_or.or_unpubcnt > 0) AND (c2_cont.cont_fgcancel = '0') AND ");
            sb.Append(@"(c2_cont.cont_fgtemp = '0') AND (c2_cont.cont_bkcd = @bkcd) ");
            sb.Append(@" AND lp_printdate = @yyyymm");
            if (cont_conttp != "")
            {
                sb.Append(@" AND cont_conttp = @cont_conttp ");
            }
            if (or_fgmosea != "")
            {
                sb.Append(@" AND or_fgmosea = @or_fgmosea ");
            }
            if (or_mtpcd != "")
            {
                sb.Append(@" AND or_mtpcd = @or_mtpcd ");
            }
            //sb.Append(@" GROUP BY c2_cont.cont_contno, c2_cont.cont_mfrno, mfr.mfr_inm,c2_or.or_mtpcd, mtp.mtp_nm, c2_cont.cont_sdate,");
            sb.Append(@" ORDER BY  c2_or.or_mtpcd, c2_cont.cont_contno ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@bkcd", cont_bkcd);
            oCmd.Parameters.AddWithValue("@yyyymm", pub_yyyymm);
            oCmd.Parameters.AddWithValue("@cont_conttp", cont_conttp);
            oCmd.Parameters.AddWithValue("@or_fgmosea", or_fgmosea);
            oCmd.Parameters.AddWithValue("@or_mtpcd", or_mtpcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}