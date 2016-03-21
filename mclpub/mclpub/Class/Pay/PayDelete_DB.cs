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
    public class PayDelete_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectpy()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.py.py_pyid, dbo.py.py_pyno, dbo.py.py_amt, dbo.py.py_pytpcd, dbo.py.py_date, dbo.py.py_moseq, dbo.py.py_moitem, dbo.py.py_chkno, dbo.py.py_chkbnm, dbo.py.py_chkdate, dbo.py.py_waccno, dbo.py.py_wdate, dbo.py.py_wbcd, dbo.py.py_ccno, dbo.py.py_cctp, dbo.py.py_ccauthcd, dbo.py.py_ccvdate, dbo.py.py_ccdate,");
            sb.Append(@" dbo.py.py_fgprinted, dbo.py.py_syscd, dbo.py.py_pysdate, dbo.py.py_pysseq, dbo.py.py_pysitem, dbo.pyd.pyd_pyditem, dbo.pyd.pyd_syscd, dbo.pyd.pyd_iano, dbo.pyd.pyd_cancel");
            sb.Append(@", dbo.pyd.pyd_pyno, dbo.pytp.pytp_nm, dbo.pytp.pytp_pytpcd, dbo.ias.ias_trans_sap, dbo.ia.ia_iasdate, dbo.ia.ia_iasseq, dbo.ia.ia_iaitem, dbo.ia.ia_iano, dbo.ia.ia_syscd");
            sb.Append(@", dbo.ias.ias_iasdate, dbo.ias.ias_iasseq FROM dbo.py INNER JOIN dbo.pyd ON dbo.py.py_pyno = dbo.pyd.pyd_pyno INNER JOIN dbo.pytp ON dbo.py.py_pytpcd =");
            sb.Append(@" dbo.pytp.pytp_pytpcd INNER JOIN dbo.ia ON dbo.pyd.pyd_syscd = dbo.ia.ia_syscd AND dbo.pyd.pyd_iano = dbo.ia.ia_iano LEFT OUTER JOIN dbo.ias");
            sb.Append(@" ON dbo.ia.ia_syscd = dbo.ias.ias_syscd AND dbo.ia.ia_iasdate = dbo.ias.ias_iasdate AND dbo.ia.ia_iasseq = dbo.ias.ias_iasseq");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        public void Deletepy(string pyno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"sp_c1_delete_py";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@pyno", pyno);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }


        public DataSet SelectCheckList7()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.pyd.pyd_pyditem, dbo.pyd.pyd_iano, dbo.pyd.pyd_pyno, dbo.pyd.pyd_cancel, dbo.py.py_pyid, dbo.py.py_pyno, dbo.py.py_amt, dbo.py.py_pytpcd, dbo.py.py_date, dbo.py.py_moseq, dbo.py.py_moitem, dbo.py.py_chkno, dbo.py.py_chkbnm,");
            sb.Append(@" dbo.py.py_chkdate, dbo.py.py_waccno, dbo.py.py_wdate, dbo.py.py_wbcd, dbo.py.py_ccno, dbo.py.py_cctp, dbo.py.py_ccauthcd, dbo.py.py_ccvdate, dbo.py.py_ccdate");
            sb.Append(@", dbo.py.py_fgprinted, dbo.py.py_syscd, dbo.py.py_pysdate, dbo.py.py_pysseq, dbo.py.py_pysitem, dbo.pytp.pytp_nm, dbo.pytp.pytp_pytpcd FROM dbo.py");
            sb.Append(@" INNER JOIN dbo.pyd ON dbo.py.py_pyno = dbo.pyd.pyd_pyno INNER JOIN dbo.pytp ON dbo.py.py_pytpcd = dbo.pytp.pytp_pytpcd");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@keyword", keyword.ToLower());
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}