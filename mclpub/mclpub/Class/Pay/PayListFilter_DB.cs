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
    public class PayListFilter_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectpy()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT py_pyid, py_pyno, py_amt, py_pytpcd, py_date, py_moseq, py_moitem, py_chkno, py_chkbnm, py_chkdate, py_waccno");
            sb.Append(@", py_wdate, py_wbcd, py_ccno, py_cctp, py_ccauthcd, py_ccvdate, py_fgprinted, py_syscd, py_pysdate, py_pysseq, py_pysitem FROM dbo.py");
            //sb.Append(@"");
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

        public DataSet Selectpytp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pytp_pytpid, pytp_pytpcd, pytp_nm FROM dbo.pytp");
            //sb.Append(@"");
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


        public DataSet SelectMAXpyseq()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT MAX(pys_pysseq) AS maxseq, pys_pysdate FROM dbo.pyseq GROUP BY pys_pysdate ");
            //sb.Append(@"");
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

        public void Insertpyseq(string pys_syscd, string pys_pysdate, string pys_pysseq, string pys_toitem, string pys_pytpcd, string pys_fgprinted,
            string pys_createdate, string pys_createmen)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"INSERT INTO dbo.pyseq(pys_syscd, pys_pysdate, pys_pysseq, pys_toitem, pys_pytpcd,");
            sb.Append(@" pys_fgprinted, pys_createdate, pys_createmen) VALUES (@pys_syscd, @pys_pysdate,");
            sb.Append(@" @pys_pysseq, @pys_toitem, @pys_pytpcd, @pys_fgprinted, @pys_createdate, @pys_createmen) ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@pys_syscd", pys_syscd);
            oCmd.Parameters.AddWithValue("@pys_pysdate", pys_pysdate);
            oCmd.Parameters.AddWithValue("@pys_pysseq", pys_pysseq);
            oCmd.Parameters.AddWithValue("@pys_toitem", pys_toitem);
            oCmd.Parameters.AddWithValue("@pys_pytpcd", pys_pytpcd);
            oCmd.Parameters.AddWithValue("@pys_fgprinted", pys_fgprinted);
            oCmd.Parameters.AddWithValue("@pys_createdate", pys_createdate);
            oCmd.Parameters.AddWithValue("@pys_createmen", pys_createmen);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public void UPDATEpy(string py_pysdate, string py_pysseq, string py_pysitem, string py_pyno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"UPDATE dbo.py SET py_pysdate = @py_pysdate, py_pysseq = @py_pysseq, py_pysitem = ");
            sb.Append(@"@py_pysitem WHERE (py_pyno = @py_pyno) ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@py_pysdate", py_pysdate);
            oCmd.Parameters.AddWithValue("@py_pysseq", py_pysseq);
            oCmd.Parameters.AddWithValue("@py_pysitem", py_pysitem);
            oCmd.Parameters.AddWithValue("@py_pyno", py_pyno);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public DataSet SelectExportExcel(string py_pytpcd, string yyyymm, string batch)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT py.*, ia.ia_syscd, ia.ia_mfrno, mfr.mfr_inm, ia.ia_invno, ia.ia_rnm, ia_iano, ia_pyat,");
            sb.Append(@"iad_syscd, iad.iad_fk1, iad.iad_fk2, iad.iad_fk3, iad.iad_projno, iad.iad_desc ");
            sb.Append(@"FROM py INNER JOIN ia ON py.py_pyno = ia.ia_pyno INNER JOIN mfr ON ia.ia_mfrno = mfr.mfr_mfrno INNER JOIN ");
            sb.Append(@"iad ON ia.ia_syscd = iad.iad_syscd AND ia.ia_iano = iad.iad_iano WHERE (py.py_pytpcd = @py_pytpcd) ");
            sb.Append(@"and py_pysdate=@yyyymm and py_pysseq=@batch ");
            sb.Append(@" ORDER BY  py.py_pyno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            oCmd.Parameters.AddWithValue("@batch", batch);
            oCmd.Parameters.AddWithValue("@py_pytpcd", py_pytpcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}