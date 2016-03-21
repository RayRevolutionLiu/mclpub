using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace mclpub
{
    public class SAPListEdit_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"].ToString();

        public DataSet SelectSyscd()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT [sys_syscd] ,[sys_nm] FROM [mclpub].[dbo].[syscd]");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet Selectias()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT ias.ias_iasid,RTRIM(LTRIM(ias.ias_syscd)) AS ias_syscd ,");
            sb.Append(@"ISNULL( SUBSTRING(ias_iasdate,1,4)+'/'+SUBSTRING(ias_iasdate,5,2),'') as ias_iasdateNew,ias_iasdate,");
            sb.Append(@"ias.ias_iasseq ");
            sb.Append(@",ias.ias_toitem ,case ias.ias_cancel when '0' then '否' when '1' then '是' end as ias_cancel ,case ias.ias_trans_sap when '0' then '否' when '1' then '是' end as ias_trans_sap ");
            sb.Append(@", CONVERT(varchar(12),CONVERT(datetime,ias.ias_createdate,112),111) as ias_createdate");
            sb.Append(@", ias.ias_createmen , case ias.ias_fgitri when '' then '一般' when '06' then '所內委託' when '07' then '院內往來' end as ias_fgitri");
            sb.Append(@",srspn.srspn_cname FROM ias,srspn WHERE ( ias.ias_createmen = srspn.srspn_empno)");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet Selectia(string ia_syscd, string ia_iasdate, string ia_iasseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT ia.ia_iaitem ,ia.ia_refno ,ia.ia_mfrno ,mfr.mfr_inm ,ia.ia_invno ,ia.ia_invdate ,ia.ia_syscd ,ia.ia_iasdate ,ia.ia_iasseq, ");
            sb.Append(@"case ia.ia_fgitri when '' then '一般' when '06' then '所內委託' when '07' then '院內往來' end AS ia_fgitri ");
            sb.Append(@" ,case ia.ia_fgnonauto when '0' then '否' when '1' then '是' end AS ia_fgnonauto ");
            //sb.Append(@"");
            //sb.Append(@"");
            //sb.Append(@"");
            sb.Append(@" FROM ia inner join mfr ON ia.ia_mfrno = mfr.mfr_mfrno ");
            sb.Append(@"WHERE ( ( ia.ia_syscd = @ia_syscd ) and ( ia.ia_iasdate = @ia_iasdate ) and ( ia.ia_iasseq = @ia_iasseq ) ) ");

            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@ia_syscd", ia_syscd);
            oCmd.Parameters.AddWithValue("@ia_iasdate", ia_iasdate);
            oCmd.Parameters.AddWithValue("@ia_iasseq", ia_iasseq);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}