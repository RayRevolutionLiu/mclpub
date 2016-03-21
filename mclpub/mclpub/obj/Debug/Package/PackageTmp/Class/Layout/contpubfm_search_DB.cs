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
    public class contpubfm_search_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc2_pub()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c2_cont.cont_contid, c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_conttp, c2_cont.cont_bkcd, c2_cont.cont_signdate");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            sb.Append(@", c2_cont.cont_empno, c2_cont.cont_mfrno, c2_cont.cont_aunm, c2_cont.cont_autel");
            sb.Append(@", c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_custno, mfr.mfr_mfrid, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_respnm, mfr.mfr_respjbti, mfr.mfr_tel, cust.cust_custid, cust.cust_custno");
            sb.Append(@", cust.cust_nm, cust.cust_jbti, cust.cust_tel, cust.cust_oldcustno, book.bk_nm, book.bk_bkcd, c2_cont.cont_fgclosed, c2_cont.cont_fgpubed, c2_cont.cont_fgcancel FROM c2_cont");
            sb.Append(@" INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd WHERE (c2_cont.cont_fgpubed <> '0')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }
    }
}