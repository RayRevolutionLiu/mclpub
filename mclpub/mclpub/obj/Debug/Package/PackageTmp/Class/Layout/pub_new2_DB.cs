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
    public class pub_new2_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc2_pub()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT DISTINCT dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_cont.cont_contid, dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_empno, dbo.c2_cont.cont_mfrno, dbo.c2_cont.cont_sdate");
            sb.Append(@", dbo.c2_cont.cont_edate, dbo.c2_cont.cont_custno, dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_autel, dbo.cust.cust_custid, dbo.cust.cust_nm, dbo.cust.cust_jbti, dbo.cust.cust_tel, dbo.mfr.mfr_mfrid");
            sb.Append(@", dbo.mfr.mfr_inm, dbo.cust.cust_custno, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_modempno, dbo.mfr.mfr_mfrno, dbo.c2_cont.cont_fgpubed, dbo.book.bk_nm,");
            sb.Append(@" dbo.book.bk_bkcd, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp FROM dbo.c2_pub INNER JOIN dbo.c2_cont ON dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno INNER JOIN dbo.cust");
            sb.Append(@" ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.book ON dbo.c2_pub.pub_bkcd = dbo.book.bk_bkcd");
            sb.Append(@" WHERE (dbo.c2_cont.cont_fgclosed = '0') AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }
    }
}