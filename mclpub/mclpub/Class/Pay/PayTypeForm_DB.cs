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
    public class PayTypeForm_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectpytp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pytp_pytpid, pytp_pytpcd, pytp_nm FROM dbo.pytp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet Selectpy()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT MAX(py_pyno) AS max_pyno FROM dbo.py");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet Selectc1_order()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT o_xmldata, o_iano, o_custno, o_otp1cd, o_otp1seq, o_syscd FROM dbo.c1_order");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public DataSet Selectia()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.ia.ia_iaid, dbo.ia.ia_syscd, dbo.ia.ia_iano, dbo.iad.iad_fk1, dbo.iad.");
            sb.Append(@"iad_fk2, dbo.iad.iad_iaditem, dbo.iad.iad_iano, dbo.iad.iad_syscd FROM dbo.ia IN");
            sb.Append(@"NER JOIN dbo.iad ON dbo.ia.ia_syscd = dbo.iad.iad_syscd AND dbo.ia.ia_iano = dbo");
            sb.Append(@".iad.iad_iano");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public SqlCommand SaveToPy_DB(string sqlCommandStr)
        {
            SqlCommand sqlInsertComPy = new SqlCommand();
            sqlInsertComPy.Connection = new SqlConnection(Conn);
            sqlInsertComPy.CommandText = sqlCommandStr;
            sqlInsertComPy.CommandType = CommandType.Text;

            return sqlInsertComPy;
        }

        public void Insertpyd(string pyd_syscd, string pyd_iano, string pyd_pyno, string pyd_pyditem)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"INSERT INTO dbo.pyd(pyd_syscd, pyd_pyno, pyd_pyditem, pyd_iano) VALUES (@pyd_syscd, @pyd_pyno, @pyd_pyditem, @pyd_iano)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@pyd_syscd", pyd_syscd);
            oCmd.Parameters.AddWithValue("@pyd_iano", pyd_iano);
            oCmd.Parameters.AddWithValue("@pyd_pyno", pyd_pyno);
            oCmd.Parameters.AddWithValue("@pyd_pyditem", pyd_pyditem);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void Updateia(string Original_ia_syscd, string Original_ia_iano, string ia_syscd, string ia_iano, string ia_pyno, string ia_pyseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"UPDATE dbo.ia SET ia_pyno = @ia_pyno, ia_pyseq = @ia_pyseq, ia_iano = @ia_iano, ia_syscd = @ia_syscd WHERE (ia_iano = @Original_ia_iano) AND (ia_syscd = @Original_ia_syscd)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@Original_ia_syscd", Original_ia_syscd);
            oCmd.Parameters.AddWithValue("@Original_ia_iano", Original_ia_iano);
            oCmd.Parameters.AddWithValue("@ia_syscd", ia_syscd);
            oCmd.Parameters.AddWithValue("@ia_iano", ia_iano);
            oCmd.Parameters.AddWithValue("@ia_pyno", ia_pyno);
            oCmd.Parameters.AddWithValue("@ia_pyseq", ia_pyseq);
            //oCmd.Parameters.AddWithValue("@pyd_pyditem", pyd_pyditem);
            //oCmd.Parameters.AddWithValue("@pyd_pyditem", pyd_pyditem);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}