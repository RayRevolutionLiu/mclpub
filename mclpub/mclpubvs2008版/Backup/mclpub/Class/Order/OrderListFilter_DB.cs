using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace mclpub
{
    public class OrderListFilter_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc1_obtp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT obtp_obtpid, obtp_otp1cd, obtp_obtpcd, obtp_obtpnm FROM dbo.c1_obtp");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c1_obtp");
            return ds;

        }

        public DataSet SelectPytp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT pytp_pytpcd, pytp_nm FROM dbo.pytp ORDER BY pytp_pytpcd ASC");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "pytp");
            return ds;

        }


        public DataSet Selectc1_od(string STRddlPayType, string STRtbxOrderDate1, string STRtbxOrderDate2, string STRtbxDate1, string STRtbxDate2, string STRddlOrderType, string STRddlBookType, string STRtbxRecName)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_od.od_odid, dbo.c1_od.od_syscd, dbo.c1_od.od_custno, dbo.c1_od.od_o");
            sb.Append(@"tp1cd, dbo.c1_od.od_otp1seq, dbo.c1_od.od_oditem, dbo.c1_od.od_sdate, dbo.c1_od.");
            sb.Append(@"od_edate, dbo.c1_od.od_btpcd, dbo.c1_od.od_amt, dbo.c1_or.or_inm, dbo.c1_or.or_n");
            sb.Append(@"m, dbo.c1_or.or_addr, dbo.c1_or.or_zip, dbo.c1_or.or_tel, dbo.c1_ramt.ra_mnt, db");
            sb.Append(@"o.c1_order.o_pytpcd, dbo.c1_order.o_otp1seq, dbo.c1_ramt.ra_oditem, dbo.c1_ramt.");
            sb.Append(@"ra_oritem, dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_syscd, d");
            sb.Append(@"bo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1s");
            sb.Append(@"eq, dbo.c1_or.or_syscd, dbo.c1_ramt.ra_custno, dbo.c1_ramt.ra_otp1cd, dbo.c1_ram");
            sb.Append(@"t.ra_otp1seq, dbo.c1_ramt.ra_syscd, dbo.c1_od.od_syscd + dbo.c1_od.od_custno + d");
            sb.Append(@"bo.c1_od.od_otp1cd + dbo.c1_od.od_otp1seq AS nostr, dbo.c1_order.o_date, dbo.pyt");
            sb.Append(@"p.pytp_nm, dbo.c1_obtp.obtp_obtpnm, dbo.c1_obtp.obtp_obtpcd, dbo.c1_obtp.obtp_ot");
            sb.Append(@"p1cd, dbo.pytp.pytp_pytpcd, dbo.c1_od.od_sdate + '~' + dbo.c1_od.od_edate AS dat");
            sb.Append(@"estr, dbo.c1_order.o_fgpreinv, dbo.c1_order.o_indate, dbo.c1_order.o_empno, dbo.");
            sb.Append(@"srspn.srspn_cname, dbo.srspn.srspn_empno, dbo.ia.ia_pyno, dbo.ia.ia_iano, dbo.ia");
            sb.Append(@".ia_syscd, dbo.c1_od.od_custtp FROM dbo.c1_od INNER JOIN dbo.c1_order ON dbo.c1_");
            sb.Append(@"od.od_syscd = dbo.c1_order.o_syscd AND dbo.c1_od.od_custno = dbo.c1_order.o_cust");
            sb.Append(@"no AND dbo.c1_od.od_otp1cd = dbo.c1_order.o_otp1cd AND dbo.c1_od.od_otp1seq = db");
            sb.Append(@"o.c1_order.o_otp1seq INNER JOIN dbo.c1_ramt ON dbo.c1_od.od_syscd = dbo.c1_ramt.");
            sb.Append(@"ra_syscd AND dbo.c1_od.od_custno = dbo.c1_ramt.ra_custno AND dbo.c1_od.od_otp1cd");
            sb.Append(@" = dbo.c1_ramt.ra_otp1cd AND dbo.c1_od.od_otp1seq = dbo.c1_ramt.ra_otp1seq AND d");
            sb.Append(@"bo.c1_od.od_oditem = dbo.c1_ramt.ra_oditem INNER JOIN dbo.c1_or ON dbo.c1_ramt.r");
            sb.Append(@"a_syscd = dbo.c1_or.or_syscd AND dbo.c1_ramt.ra_custno = dbo.c1_or.or_custno AND");
            sb.Append(@" dbo.c1_ramt.ra_otp1cd = dbo.c1_or.or_otp1cd AND dbo.c1_ramt.ra_otp1seq = dbo.c1");
            sb.Append(@"_or.or_otp1seq AND dbo.c1_ramt.ra_oritem = dbo.c1_or.or_oritem LEFT OUTER JOIN d");
            sb.Append(@"bo.ia ON dbo.c1_order.o_syscd = dbo.ia.ia_syscd AND dbo.c1_order.o_iano = dbo.ia.ia_iano LEFT OUTER JOIN dbo.srspn ON dbo.c");
            sb.Append(@"1_order.o_empno = dbo.srspn.srspn_empno LEFT OUTER JOIN dbo.c1_obtp ON dbo.c1_od");
            sb.Append(@".od_btpcd = dbo.c1_obtp.obtp_obtpcd AND dbo.c1_od.od_otp1cd = dbo.c1_obtp.obtp_o");
            sb.Append(@"tp1cd LEFT OUTER JOIN dbo.pytp ON dbo.c1_order.o_pytpcd = dbo.pytp.pytp_pytpcd W");
            sb.Append(@"HERE (dbo.c1_od.od_syscd = 'C1') ");
            if (STRddlPayType.ToString() != "")
            {
                //sb.Append(@"");
                sb.Append(@" and o_pytpcd=@STRddlPayType ");
            }
            if (STRtbxOrderDate1.ToString() != "" && STRtbxOrderDate2.ToString() != "")
            {
                sb.Append(@" and (o_date>=@STRtbxOrderDate1 and o_date<=@STRtbxOrderDate2) ");
            }
            if (STRtbxDate1.ToString() != "" && STRtbxDate2.ToString() != "")
            {
                sb.Append(@" and (o_indate>=@STRtbxDate1 and o_indate<=@STRtbxDate2) ");
            }
            if (STRddlOrderType.ToString() != "")
            {
                sb.Append(@" and od_otp1cd=@STRddlOrderType ");
            }
            if (STRddlBookType.ToString() != "")
            {
                sb.Append(@" and od_btpcd=@STRddlBookType ");
            }
            if (STRtbxRecName.ToString() != "")
            {
                sb.Append(@" and or_nm LIKE '%'+@STRtbxRecName+'%' ");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@STRddlPayType", STRddlPayType);
            oCmd.Parameters.AddWithValue("@STRtbxOrderDate1", STRtbxOrderDate1);
            oCmd.Parameters.AddWithValue("@STRtbxOrderDate2", STRtbxOrderDate2);
            oCmd.Parameters.AddWithValue("@STRtbxDate1", STRtbxDate1);
            oCmd.Parameters.AddWithValue("@STRtbxDate2", STRtbxDate2);
            oCmd.Parameters.AddWithValue("@STRddlOrderType", STRddlOrderType);
            oCmd.Parameters.AddWithValue("@STRddlBookType", STRddlBookType);
            oCmd.Parameters.AddWithValue("@STRtbxRecName", STRtbxRecName);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c1_od");
            return ds;

        }
    }
}
