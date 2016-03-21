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
    public class appriselabel_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectTmp1_table()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.tmp_label1.od_odid, dbo.tmp_label1.od_syscd, dbo.tmp_label1.od_custno, dbo.tmp_label1.od_otp1cd, dbo.tmp_label1.od_otp1seq, dbo.tmp_label1.od_oditem, dbo.tmp_label1.od_sdate, dbo.tmp_label1.od_edate, dbo.tmp_label1.ra_mnt, dbo.tmp_label1.mtp_nm, dbo.tmp_label1.obtp_obtpnm, dbo.tmp_label1.ra_oritem, dbo.c1_or.or_inm, dbo.c1_or.or_nm, dbo.c1_or.or_jbti, dbo.c1_or.or_addr, dbo.c1_or.or_zip, dbo.c1_or.or_fgmosea, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, dbo.c1_or.or_syscd FROM dbo.tmp_label1 INNER JOIN dbo.c1_or ON dbo.tmp_label1.od_syscd = dbo.c1_or.or_syscd AND dbo.tmp_label1.od_custno = dbo.c1_or.or_custno AND dbo.tmp_label1.od_otp1cd = dbo.c1_or.or_otp1cd AND dbo.tmp_label1.od_otp1seq = dbo.c1_or.or_otp1seq ORDER BY dbo.tmp_label1.od_custno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@whereST1", whereST1);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds, "tmp_label1");
            return ds;

        }
    }
}