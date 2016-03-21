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
    public class SAP_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectias()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT ias_iasid, ias_syscd, ias_iasdate, ias_iasseq, ias_toitem, ias_cancel, ias_trans_sap, ias_createdate, ias_createmen,case RTRIM(LTRIM(ias_fgitri)) when '' then '一般' when '06' then '所內' when '07' then '院內' end AS ias_fgitri FROM dbo.ias");
            sb.Append(@" WHERE ias_trans_sap = '0' AND RTRIM(LTRIM(ias_fgitri))='' ");
            //20130223 新增不要顯示2012以前的資料
            sb.Append(@" AND ias_iasdate > '201212' ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@strdate", strdate);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet Selectia(string ia_iasdate, string ia_iasseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT ia_iaid, ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat, ia_invno, ia_invdate, ia_fgitri, ");
            sb.Append(@"ia_rnm, ia_raddr, ia_rzip, ia_rjbti, ia_rtel, ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno FROM dbo.ia");
            sb.Append(@" WHERE ia_iasdate=@ia_iasdate AND ia_iasseq=@ia_iasseq ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@ia_iasdate", ia_iasdate);
            oCmd.Parameters.AddWithValue("@ia_iasseq", ia_iasseq);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public void EXEC_sap01(string yyyymm, string batch_seq, string empno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"sp_to_sap_001");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            oCmd.Parameters.AddWithValue("@batch_seq", batch_seq);
            oCmd.Parameters.AddWithValue("@empno", empno);
            SqlParameter retValParam = oCmd.Parameters.Add("@rtn", SqlDbType.Int);
            retValParam.Direction = ParameterDirection.Output;
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void EXEC_sap02(string yyyymm, string batch_seq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"sp_to_sap_002");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            oCmd.Parameters.AddWithValue("@batch_seq", batch_seq);
            SqlParameter retValParam = oCmd.Parameters.Add("@rtn", SqlDbType.Int);
            retValParam.Direction = ParameterDirection.Output;
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void EXEC_sap03(string yyyymm, string batch_seq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"sp_to_sap_003");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            oCmd.Parameters.AddWithValue("@batch_seq", batch_seq);
            SqlParameter retValParam = oCmd.Parameters.Add("@rtn", SqlDbType.Int);
            retValParam.Direction = ParameterDirection.Output;
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void EXEC_sp_from_sap_001()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"sp_from_sap_001");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@yyyymm", yyyymm);
            //oCmd.Parameters.AddWithValue("@batch_seq", batch_seq);
            //SqlParameter retValParam = oCmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
            //retValParam.Direction = ParameterDirection.Output;
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}