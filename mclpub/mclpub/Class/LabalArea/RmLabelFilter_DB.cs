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
    public class RmLabelFilter_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectC1_rmail()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_or.or_nm, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1seq, dbo.c1_or.or_fgmosea, dbo.c1_remail.rm_syscd, dbo.c1_remail.rm_custno, dbo.c1_remail.rm_otp1cd, dbo.c1_remail.rm_otp1seq, dbo.c1_remail.rm_oritem, dbo.c1_remail.rm_seq, dbo.c1_remail.rm_cont, dbo.c1_remail.rm_date, dbo.c1_remail.rm_fgsent, dbo.c1_or.or_custno, dbo.c1_or.or_otp1cd, dbo.c1_or.or_syscd, dbo.c1_remail.rm_syscd + dbo.c1_remail.rm_custno + dbo.c1_remail.rm_otp1cd + dbo.c1_remail.rm_otp1seq+dbo.c1_remail.rm_oritem+dbo.c1_remail.rm_seq AS nostr FROM dbo.c1_or INNER JOIN dbo.c1_remail ON dbo.c1_or.or_syscd = dbo.c1_remail.rm_syscd AND dbo.c1_or.or_custno = dbo.c1_remail.rm_custno AND dbo.c1_or.or_otp1cd = dbo.c1_remail.rm_otp1cd AND dbo.c1_or.or_otp1seq = dbo.c1_remail.rm_otp1seq AND dbo.c1_or.or_oritem = dbo.c1_remail.rm_oritem");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c1_rmail");
            return ds;

        }


        public void DelTmp_table2()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"DELETE FROM dbo.tmp_label2";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@contno", contno);
            //oCmd.Parameters.AddWithValue("@Istr0", Istr0);
            //oCmd.Parameters.AddWithValue("@Istr1", Istr1);
            //oCmd.Parameters.AddWithValue("@Istr2", Istr2);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void Update2(string rm_syscd, string rm_custno, string rm_otp1cd, string rm_otp1seq, string rm_oritem, string rm_seq, string rm_date, string rm_fgsent, string Original_rm_custno, string Original_rm_oritem, string Original_rm_otp1cd, string Original_rm_otp1seq, string Original_rm_syscd, string Original_rm_seq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE dbo.c1_remail SET rm_syscd = @rm_syscd, rm_custno = @rm_custno, rm_otp1cd = @rm_otp1cd, rm_otp1seq = @rm_otp1seq, rm_oritem = @rm_oritem, rm_seq = @rm_seq, rm_date = @rm_date, rm_fgsent = @rm_fgsent WHERE (rm_custno = @Original_rm_custno) AND (rm_oritem = @Original_rm_oritem) AND (rm_otp1cd = @Original_rm_otp1cd) AND (rm_otp1seq = @Original_rm_otp1seq) AND (rm_syscd = @Original_rm_syscd) AND (rm_seq = @Original_rm_seq)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@rm_syscd", rm_syscd);
            oCmd.Parameters.AddWithValue("@rm_custno", rm_custno);
            oCmd.Parameters.AddWithValue("@rm_otp1cd", rm_otp1cd);
            oCmd.Parameters.AddWithValue("@rm_otp1seq", rm_otp1seq);
            oCmd.Parameters.AddWithValue("@rm_oritem", rm_oritem);
            oCmd.Parameters.AddWithValue("@rm_seq", rm_seq);
            oCmd.Parameters.AddWithValue("@rm_date", rm_date);
            oCmd.Parameters.AddWithValue("@rm_fgsent", rm_fgsent);
            oCmd.Parameters.AddWithValue("@Original_rm_custno", Original_rm_custno);
            oCmd.Parameters.AddWithValue("@Original_rm_oritem", Original_rm_oritem);
            oCmd.Parameters.AddWithValue("@Original_rm_otp1cd", Original_rm_otp1cd);
            oCmd.Parameters.AddWithValue("@Original_rm_otp1seq", Original_rm_otp1seq);
            oCmd.Parameters.AddWithValue("@Original_rm_syscd", Original_rm_syscd);
            oCmd.Parameters.AddWithValue("@Original_rm_seq", Original_rm_seq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public void Insert1(string tmp_syscd, string tmp_custno, string tmp_otp1cd, string tmp_otp1seq, string tmp_oritem, string tmp_seq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"INSERT INTO dbo.tmp_label2(tmp_syscd, tmp_custno, tmp_otp1cd, tmp_otp1seq, tmp_oritem, tmp_seq) VALUES (@tmp_syscd, @tmp_custno, @tmp_otp1cd, @tmp_otp1seq, @tmp_oritem, @tmp_seq)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@tmp_syscd", tmp_syscd);
            oCmd.Parameters.AddWithValue("@tmp_custno", tmp_custno);
            oCmd.Parameters.AddWithValue("@tmp_otp1cd", tmp_otp1cd);
            oCmd.Parameters.AddWithValue("@tmp_otp1seq", tmp_otp1seq);
            oCmd.Parameters.AddWithValue("@tmp_oritem", tmp_oritem);
            oCmd.Parameters.AddWithValue("@tmp_seq", tmp_seq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}