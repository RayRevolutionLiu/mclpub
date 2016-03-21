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
    public class CheckList_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet SelectC1_order()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_order.o_syscd + dbo.c1_order.o_custno + dbo.c1_order.o_otp1cd + dbo");
            sb.Append(@".c1_order.o_otp1seq AS nostr, dbo.c1_order.o_otp2cd, dbo.c1_order.o_mfrno, dbo.c");
            sb.Append(@"1_order.o_inm, dbo.c1_order.o_ijbti, dbo.c1_order.o_iaddr, dbo.c1_order.o_izip, ");
            sb.Append(@"dbo.c1_order.o_itel, dbo.c1_order.o_ifax, dbo.c1_order.o_icell, dbo.c1_order.o_i");
            sb.Append(@"email, dbo.c1_order.o_pytpcd, dbo.c1_order.o_fgpreinv, dbo.c1_order.o_date, dbo.");
            sb.Append(@"c1_order.o_empno, dbo.c1_order.o_orescd, dbo.c1_order.o_invcd, dbo.c1_order.o_ta");
            sb.Append(@"xtp, dbo.c1_order.o_indate, dbo.c1_order.o_status, dbo.c1_od.od_oditem, dbo.c1_o");
            sb.Append(@"d.od_sdate, dbo.c1_od.od_edate, dbo.c1_od.od_btpcd, dbo.c1_od.od_projno, dbo.c1_");
            sb.Append(@"od.od_costctr, dbo.c1_od.od_remark, dbo.c1_od.od_amt, dbo.c1_od.od_custtp, dbo.c");
            sb.Append(@"1_ramt.ra_mnt, dbo.c1_ramt.ra_mtpcd, dbo.c1_or.or_inm, dbo.c1_or.or_nm, dbo.c1_o");
            sb.Append(@"r.or_jbti, dbo.c1_or.or_addr, dbo.c1_or.or_zip, dbo.c1_or.or_tel, dbo.c1_or.or_f");
            sb.Append(@"ax, dbo.c1_or.or_cell, dbo.c1_or.or_email, dbo.c1_or.or_fgmosea, dbo.c1_od.od_cu");
            sb.Append(@"stno, dbo.c1_od.od_otp1cd, dbo.c1_od.od_otp1seq, dbo.c1_od.od_syscd, dbo.c1_orde");
            sb.Append(@"r.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_order.o_syscd,");
            sb.Append(@" dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp");
            sb.Append(@"1seq, dbo.c1_or.or_syscd, dbo.c1_ramt.ra_custno, dbo.c1_ramt.ra_oditem, dbo.c1_r");
            sb.Append(@"amt.ra_oritem, dbo.c1_ramt.ra_otp1cd, dbo.c1_ramt.ra_otp1seq, dbo.c1_ramt.ra_sys");
            sb.Append(@"cd, dbo.c1_obtp.obtp_obtpnm, dbo.mtp.mtp_nm, dbo.c1_obtp.obtp_obtpcd, dbo.c1_obt");
            sb.Append(@"p.obtp_otp1cd, dbo.mtp.mtp_mtpcd FROM dbo.c1_order INNER JOIN dbo.c1_od ON dbo.c");
            sb.Append(@"1_order.o_syscd = dbo.c1_od.od_syscd AND dbo.c1_order.o_custno = dbo.c1_od.od_cu");
            sb.Append(@"stno AND dbo.c1_order.o_otp1cd = dbo.c1_od.od_otp1cd AND dbo.c1_order.o_otp1seq ");
            sb.Append(@"= dbo.c1_od.od_otp1seq INNER JOIN dbo.c1_ramt ON dbo.c1_od.od_syscd = dbo.c1_ram");
            sb.Append(@"t.ra_syscd AND dbo.c1_od.od_custno = dbo.c1_ramt.ra_custno AND dbo.c1_od.od_otp1");
            sb.Append(@"cd = dbo.c1_ramt.ra_otp1cd AND dbo.c1_od.od_otp1seq = dbo.c1_ramt.ra_otp1seq AND");
            sb.Append(@" dbo.c1_od.od_oditem = dbo.c1_ramt.ra_oditem INNER JOIN dbo.c1_or ON dbo.c1_ramt");
            sb.Append(@".ra_syscd = dbo.c1_or.or_syscd AND dbo.c1_ramt.ra_custno = dbo.c1_or.or_custno A");
            sb.Append(@"ND dbo.c1_ramt.ra_otp1cd = dbo.c1_or.or_otp1cd AND dbo.c1_ramt.ra_otp1seq = dbo.");
            sb.Append(@"c1_or.or_otp1seq AND dbo.c1_ramt.ra_oritem = dbo.c1_or.or_oritem INNER JOIN dbo.");
            sb.Append(@"c1_obtp ON dbo.c1_od.od_btpcd = dbo.c1_obtp.obtp_obtpcd AND dbo.c1_od.od_otp1cd ");
            sb.Append(@"= dbo.c1_obtp.obtp_otp1cd INNER JOIN dbo.mtp ON dbo.c1_ramt.ra_mtpcd = dbo.mtp.m");
            sb.Append(@"tp_mtpcd");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds, "c1_order");
            return ds;

        }
    }
}
