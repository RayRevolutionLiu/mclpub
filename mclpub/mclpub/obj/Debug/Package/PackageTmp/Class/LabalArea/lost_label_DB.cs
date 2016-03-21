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
    public class lost_label_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc1_lost()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_lost.lst_lstid, dbo.c1_lost.lst_syscd, dbo.c1_lost.lst_custno, dbo.c1_lost.lst_otp1cd, dbo.c1_lost.lst_otp1seq, dbo.c1_lost.lst_oritem, dbo.c1_lost.lst_seq, dbo.c1_lost.lst_cont, dbo.c1_lost.lst_date, dbo.c1_lost.lst_rea, dbo.c1_lost.lst_fgsent, dbo.c1_or.or_inm, dbo.c1_or.or_nm, dbo.c1_or.or_jbti, dbo.c1_or.or_addr, dbo.c1_or.or_zip, dbo.c1_or.or_fgmosea, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, dbo.c1_or.or_syscd FROM dbo.c1_lost INNER JOIN dbo.c1_or ON dbo.c1_lost.lst_syscd = dbo.c1_or.or_syscd AND dbo.c1_lost.lst_custno = dbo.c1_or.or_custno AND dbo.c1_lost.lst_otp1cd = dbo.c1_or.or_otp1cd AND dbo.c1_lost.lst_otp1seq = dbo.c1_or.or_otp1seq AND dbo.c1_lost.lst_oritem = dbo.c1_or.or_oritem INNER JOIN dbo.tmp_label2 ON dbo.c1_lost.lst_syscd = dbo.tmp_label2.tmp_syscd AND dbo.c1_lost.lst_custno = dbo.tmp_label2.tmp_custno AND dbo.c1_lost.lst_otp1cd = dbo.tmp_label2.tmp_otp1cd AND dbo.c1_lost.lst_otp1seq = dbo.tmp_label2.tmp_otp1seq AND dbo.c1_lost.lst_oritem = dbo.tmp_label2.tmp_oritem AND dbo.c1_lost.lst_seq = dbo.tmp_label2.tmp_seq");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c1_lost");
            return ds;

        }
    }
}