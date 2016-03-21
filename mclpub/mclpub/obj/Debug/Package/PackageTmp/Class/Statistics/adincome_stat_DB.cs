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
    public class adincome_stat_DB
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

        public DataSet SelectSrspn()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel");
            sb.Append(@", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srspn_empno FROM dbo.srspn WHERE (UPPER(srspn_atype) <> 'F') AND (UPPER(srspn_atype) <> 'A') ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet Selectc2_cont(string yyyymm, string bkcd,string empno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT TOP 100 PERCENT dbo.c2_cont.cont_contno, dbo.c2_cont.cont_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.c2_cont.cont_mfrno, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, SUM(dbo.c2_pub.pub_adamt) AS TotalAdamt,");
            sb.Append(@" SUM(dbo.c2_pub.pub_chgamt) AS TotalChgAmt, COUNT(dbo.c2_pub.pub_pubseq) AS TotalPubCounts, SUM(dbo.c2_pub.pub_adamt) AS TotalAmt");
            sb.Append(@", RTRIM(dbo.c2_cont.cont_empno) AS cont_empno FROM dbo.c2_cont INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = dbo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno =");
            sb.Append(@" dbo.c2_pub.pub_contno INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno WHERE");
            sb.Append(@" (dbo.c2_pub.pub_yyyymm = @yyyymm) AND (dbo.c2_cont.cont_bkcd = @bkcd) AND (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_cont.cont_fgpubed = '1') ");
            if (empno != "")
            {
                sb.Append(@" AND cont_empno = @empno ");
            }
            sb.Append(@"GROUP BY dbo.c2_cont.cont_contno, dbo.c2_cont.cont_bkcd, dbo.book.bk_nm, dbo.c2_cont.cont_mfrno, dbo.mfr.mfr_inm, dbo.c2_cont.cont_empno ORDER BY dbo.c2_cont.cont_contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            oCmd.Parameters.AddWithValue("@bkcd", bkcd);
            oCmd.Parameters.AddWithValue("@empno", empno);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }
    }
}