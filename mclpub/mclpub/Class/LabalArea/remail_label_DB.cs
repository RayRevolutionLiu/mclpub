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
    public class remail_label_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc1_remail()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_remail.rm_rmid, dbo.c1_remail.rm_syscd, dbo.c1_remail.rm_custno, dbo.c1_remail.rm_otp1cd, dbo.c1_remail.rm_otp1seq, dbo.c1_remail.rm_oritem, dbo.c1_remail.rm_seq, dbo.c1_remail.rm_cont, dbo.c1_remail.rm_date, dbo.c1_remail.rm_fgsent, dbo.c1_or.or_inm, dbo.c1_or.or_nm, dbo.c1_or.or_jbti, dbo.c1_or.or_addr, dbo.c1_or.or_zip, dbo.c1_or.or_fgmosea, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, dbo.c1_or.or_syscd FROM dbo.c1_remail INNER JOIN dbo.tmp_label2 ON dbo.c1_remail.rm_syscd = dbo.tmp_label2.tmp_syscd AND dbo.c1_remail.rm_custno = dbo.tmp_label2.tmp_custno AND dbo.c1_remail.rm_otp1cd = dbo.tmp_label2.tmp_otp1cd AND dbo.c1_remail.rm_otp1seq = dbo.tmp_label2.tmp_otp1seq AND dbo.c1_remail.rm_oritem = dbo.tmp_label2.tmp_oritem AND dbo.c1_remail.rm_seq = dbo.tmp_label2.tmp_seq INNER JOIN dbo.c1_or ON dbo.c1_remail.rm_syscd = dbo.c1_or.or_syscd AND dbo.c1_remail.rm_custno = dbo.c1_or.or_custno AND dbo.c1_remail.rm_otp1cd = dbo.c1_or.or_otp1cd AND dbo.c1_remail.rm_otp1seq = dbo.c1_or.or_otp1seq AND dbo.c1_remail.rm_oritem = dbo.c1_or.or_oritem");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c1_remail");
            return ds;

        }
    }
}