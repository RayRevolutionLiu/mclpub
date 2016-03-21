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
    public class adlprior_get_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectbook()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT bk_bkcd, bk_nm FROM book");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet Selectlprior()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c2_lprior.lp_bkcd, c2_lprior.lp_priorseq, c2_lprior.lp_clrcd, c2_lprior.lp_ltpcd, c2_lprior.lp_pgscd, c2_ltp.ltp_nm, c2_clr.clr_nm, c2_pgsize.pgs_nm, c2_clr.clr_clrcd, c2_ltp.ltp_ltpcd, c2_pgsize.pgs_pgscd FROM c2_lprior INNER JOIN c2_clr ON c2_lprior.lp_clrcd = c2_clr.clr_clrcd INNER JOIN c2_ltp ON c2_lprior.lp_ltpcd = c2_ltp.ltp_ltpcd INNER JOIN c2_pgsize ON c2_lprior.lp_pgscd = c2_pgsize.pgs_pgscd");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }
    }
}