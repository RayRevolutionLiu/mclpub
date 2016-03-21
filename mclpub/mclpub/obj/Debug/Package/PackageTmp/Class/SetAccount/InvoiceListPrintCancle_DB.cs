using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace mclpub
{
    public class InvoiceListPrintCancle_DB
    {

        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"].ToString();

        public DataTable SelectComp(string sysoc)
        {


            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            //sb.Append(@"SELECT mfr_mfrid, mfr_mfrno, mfr_inm FROM mfr WHERE 1=1 ");

            sb.Append(@"SELECT TOP 1000 * FROM mclpub.dbo.ias ");

            if (sysoc.ToString() != "")
            {
                sb.Append(@"and ias_syscd=@sysoc ");
            }

            /*
            if (company.ToString() != "")
            {
                sb.Append(@"and mfr_inm=@company ");
            }

            */
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();

            oCmd.Parameters.AddWithValue("@sysoc", sysoc);

            oda.Fill(ds);
            return ds;

        }

        public DataTable SelectC1cust(string sysoc, string yearmoon, string batch)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT * FROM [mclpub].[dbo].[ias] AS a LEFT JOIN [mclpub].[dbo].[srspn] AS b ON a.[ias_createmen] = b.[srspn_empno] WHERE a.ias_trans_sap = '0' ");

            //系統序號
            if (sysoc.ToString() != "")
            {
                sb.Append(@"and a.ias_syscd=@sysoc ");
            }

            //轉檔年月
            if (yearmoon.ToString() != "")
            {
                sb.Append(@"and a.ias_iasdate=@yearmoon ");
            }

            //批次
            if (batch.ToString() != "")
            {
                sb.Append(@"and a.ias_iasseq=@batch ");
            }


            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();

            oCmd.Parameters.AddWithValue("@sysoc", sysoc);
            oCmd.Parameters.AddWithValue("@yearmoon", yearmoon);
            oCmd.Parameters.AddWithValue("@batch", batch);

            oda.Fill(ds);
            return ds;

        }

        public DataTable SelectC2cust(string syscd, string date, string seq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT [ia_iaid],[mfr_inm]
      ,[ia_syscd]
      ,[ia_iasdate]
      ,[ia_iasseq]
      ,[ia_iaitem]
      ,[ia_iano]
      ,[ia_refno]
      ,[ia_mfrno]
      ,[ia_pyno]
      ,[ia_pyseq]
      ,[ia_pyat]
      ,[ia_ivat]
      ,[ia_invno]
      ,[ia_invdate]
      ,CASE RTRIM(LTRIM([ia_fgitri])) WHEN '' THEN '一般' WHEN '06' THEN '所內委託' WHEN '07' THEN '院內往來' ELSE '其他' END AS ia_fgitri 
      ,[ia_rnm]
      ,[ia_raddr]
      ,[ia_rzip]
      ,[ia_rjbti]
      ,[ia_rtel]
      ,[ia_fgnonauto]
      ,[ia_invcd]
      ,[ia_taxtp]
      ,[ia_status]
      ,[ia_cname]
      ,[ia_tel]
      ,[ia_contno]
      ,[ia_iabdate]
      ,[ia_iabseq]
      ,[ia_remark]
  FROM [mclpub].[dbo].[ia],[mfr] WHERE ia.ia_mfrno = mfr.mfr_mfrno AND ia_syscd = @sysoc AND ia_iasdate = @date AND ia_iasseq = @seq ORDER BY ia_iaitem");

            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();

            oCmd.Parameters.AddWithValue("@sysoc", syscd);
            oCmd.Parameters.AddWithValue("@date", date);
            oCmd.Parameters.AddWithValue("@seq", seq);
            
            oda.Fill(ds);
            return ds;

        }

    }
}