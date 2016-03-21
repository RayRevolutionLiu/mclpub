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
    public class RmListFilter_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataTable Selectc1_remailEdit(string status, string STRtbxRemailDate1, string STRtbxRemailDate2, string STRtbxOrderDate1, string STRtbxOrderDate2)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT  *, c1_or.or_nm, c1_or.or_addr, rm_syscd+rm_custno+rm_otp1cd+rm_otp1seq AS nostr,c1_order.o_date ");
            sb.Append(@" FROM c1_remail INNER JOIN c1_or ON c1_remail.rm_syscd = c1_or.or_syscd AND ");
            sb.Append(@"c1_remail.rm_custno = c1_or.or_custno AND c1_remail.rm_otp1cd = c1_or.or_otp1cd AND ");
            sb.Append(@"c1_remail.rm_otp1seq = c1_or.or_otp1seq AND c1_remail.rm_oritem = c1_or.or_oritem INNER JOIN ");
            sb.Append(@"dbo.c1_order ON dbo.c1_or.or_syscd = dbo.c1_order.o_syscd AND dbo.c1_or.or_custno = dbo.c1_order.o_custno AND ");
            sb.Append(@"dbo.c1_or.or_otp1cd = dbo.c1_order.o_otp1cd AND dbo.c1_or.or_otp1seq = dbo.c1_order.o_otp1seq ");
            sb.Append(@"where 1=1 ");
            if (status == "C")
            {
                if (STRtbxRemailDate1 != "" && STRtbxRemailDate2 != "")
                {
                    sb.Append(@"AND (c1_remail.rm_date >= @STRtbxRemailDate1) AND (c1_remail.rm_date <= @STRtbxRemailDate2) AND  c1_remail.rm_fgsent='C' ");
                }
            }
            else if (status == "N")
            {
                sb.Append(@"AND c1_remail.rm_fgsent<>'C' ");
            }
            if (STRtbxOrderDate1 != "" && STRtbxOrderDate2 != "")
            {
                sb.Append(@"AND (c1_order.o_date >= @STRtbxOrderDate1) AND (c1_order.o_date <= @STRtbxOrderDate2) ");
            }
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@STRtbxRemailDate1", STRtbxRemailDate1 == "" ? "" : STRtbxRemailDate1.Substring(0, 4) + STRtbxRemailDate1.Substring(5, 2) + STRtbxRemailDate1.Substring(8, 2));
            oCmd.Parameters.AddWithValue("@STRtbxRemailDate2", STRtbxRemailDate2 == "" ? "" : STRtbxRemailDate2.Substring(0, 4) + STRtbxRemailDate2.Substring(5, 2) + STRtbxRemailDate2.Substring(8, 2));
            oCmd.Parameters.AddWithValue("@STRtbxOrderDate1",  STRtbxOrderDate1 == "" ? "" : STRtbxOrderDate1.Substring(0, 4) + STRtbxOrderDate1.Substring(5, 2) + STRtbxOrderDate1.Substring(8, 2));
            oCmd.Parameters.AddWithValue("@STRtbxOrderDate2", STRtbxOrderDate2 == "" ? "" : STRtbxOrderDate2.Substring(0, 4) + STRtbxOrderDate2.Substring(5, 2) + STRtbxOrderDate2.Substring(8, 2));
            DataTable ds = new DataTable();
            oda.Fill(ds);
            return ds;
        }
    }
}