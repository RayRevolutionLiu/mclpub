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
    public class LostSearch_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc1_order(string tbxCompanyname, string tbxMfrno, string tbxCustNo, string tbxCustName, string tbxRecName, string tbxRecAddr, string tbxRecTel)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_order.o_mfrno, dbo.");
            sb.Append(@"c1_or.or_nm, dbo.c1_or.or_addr, dbo.c1_or.or_tel, dbo.c1_od.od_sdate, dbo.c1_od.");
            sb.Append(@"od_edate, dbo.c1_order.o_syscd, dbo.mfr.mfr_inm, dbo.c1_od.od_custno, dbo.c1_od.");
            sb.Append(@"od_oditem, dbo.c1_od.od_otp1cd, dbo.c1_od.od_otp1seq, dbo.c1_od.od_syscd, dbo.c1");
            sb.Append(@"_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, d");
            sb.Append(@"bo.c1_or.or_syscd, dbo.mfr.mfr_mfrid, dbo.c1_obtp.obtp_obtpnm, dbo.c1_obtp.obtp_");
            sb.Append(@"obtpcd, dbo.c1_obtp.obtp_otp1cd, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2cd, d");
            sb.Append(@"bo.c1_otp.otp_otp1cd, dbo.c1_od.od_syscd + dbo.c1_od.od_custno + dbo.c1_od.od_ot");
            sb.Append(@"p1cd + dbo.c1_od.od_otp1seq AS orderno, dbo.mfr.mfr_mfrno, dbo.c1_order.o_date, ");
            sb.Append(@"dbo.c1_cust.cust_nm, dbo.c1_cust.cust_custno FROM dbo.c1_order INNER JOIN dbo.c1");
            sb.Append(@"_od ON dbo.c1_order.o_syscd = dbo.c1_od.od_syscd AND dbo.c1_order.o_custno = dbo");
            sb.Append(@".c1_od.od_custno AND dbo.c1_order.o_otp1cd = dbo.c1_od.od_otp1cd AND dbo.c1_orde");
            sb.Append(@"r.o_otp1seq = dbo.c1_od.od_otp1seq INNER JOIN dbo.mfr ON dbo.c1_order.o_mfrno = ");
            sb.Append(@"dbo.mfr.mfr_mfrno INNER JOIN dbo.c1_obtp ON dbo.c1_od.od_otp1cd = dbo.c1_obtp.ob");
            sb.Append(@"tp_otp1cd AND dbo.c1_od.od_btpcd = dbo.c1_obtp.obtp_obtpcd INNER JOIN dbo.c1_otp");
            sb.Append(@" ON dbo.c1_order.o_otp1cd = dbo.c1_otp.otp_otp1cd AND dbo.c1_order.o_otp2cd = db");
            sb.Append(@"o.c1_otp.otp_otp2cd INNER JOIN dbo.c1_ramt ON dbo.c1_od.od_syscd = dbo.c1_ramt.r");
            sb.Append(@"a_syscd AND dbo.c1_od.od_custno = dbo.c1_ramt.ra_custno AND dbo.c1_od.od_otp1cd ");
            sb.Append(@"= dbo.c1_ramt.ra_otp1cd AND dbo.c1_od.od_otp1seq = dbo.c1_ramt.ra_otp1seq AND db");
            sb.Append(@"o.c1_od.od_oditem = dbo.c1_ramt.ra_oditem INNER JOIN dbo.c1_or ON dbo.c1_ramt.ra");
            sb.Append(@"_syscd = dbo.c1_or.or_syscd AND dbo.c1_ramt.ra_custno = dbo.c1_or.or_custno AND ");
            sb.Append(@"dbo.c1_ramt.ra_otp1cd = dbo.c1_or.or_otp1cd AND dbo.c1_ramt.ra_otp1seq = dbo.c1_");
            sb.Append(@"or.or_otp1seq AND dbo.c1_ramt.ra_oritem = dbo.c1_or.or_oritem INNER JOIN dbo.c1_");
            sb.Append(@"cust ON dbo.c1_order.o_custno = dbo.c1_cust.cust_custno WHERE (dbo.c1_order.o_sy");
            sb.Append(@"scd = 'C1')");

            if (tbxCompanyname.ToString().Trim() != "")
            {
                sb.Append(@" AND mfr_inm Like '%'+@tbxCompanyname+'%' ");
            }
            if (tbxMfrno.ToString().Trim() != "")
            {
                sb.Append(@" AND o_mfrno = @tbxMfrno ");
            }
            if (tbxCustNo.ToString().Trim() != "")
            {
                sb.Append(@" AND o_custno = @tbxCustNo ");
            }
            if (tbxCustName.ToString().Trim() != "")
            {
                sb.Append(@" AND cust_nm Like '%'+@tbxCustName+'%' ");
            }
            if (tbxRecName.ToString().Trim() != "")
            {
                sb.Append(@" AND or_nm Like '%'+@tbxRecName+'%' ");
            }
            if (tbxRecAddr.ToString().Trim() != "")
            {
                sb.Append(@" AND or_addr Like '%'+@tbxRecAddr+'%' ");
            }
            if (tbxRecTel.ToString().Trim() != "")
            {
                sb.Append(@" AND or_tel = @tbxRecTel ");
            }

            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@tbxCompanyname", tbxCompanyname);
            oCmd.Parameters.AddWithValue("@tbxMfrno", tbxMfrno);
            oCmd.Parameters.AddWithValue("@tbxCustNo", tbxCustNo);
            oCmd.Parameters.AddWithValue("@tbxCustName", tbxCustName);
            oCmd.Parameters.AddWithValue("@tbxRecName", tbxRecName);
            oCmd.Parameters.AddWithValue("@tbxRecAddr", tbxRecAddr);
            oCmd.Parameters.AddWithValue("@tbxRecTel", tbxRecTel);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public DataSet Selectc1_lost(string rblSent, string tbxOrderNo, string tbxCompanyname, string tbxMfrno, string tbxCustNo, string tbxCustName, string tbxRecName, string tbxRecAddr, string tbxRecTel)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_lost.lst_lstid, dbo.c1_lost.lst_syscd, dbo.c1_lost.lst_custno");
            sb.Append(@", dbo.c1_lost.lst_otp1cd, dbo.c1_lost.lst_otp1seq, dbo.c1_lost.lst_oritem, dbo.c1_lost.lst_seq, dbo.c1_lost.lst_cont, dbo.c1_lost.lst_date, dbo.c1_lost.lst_rea");
            sb.Append(@", dbo.c1_lost.lst_fgsent, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2nm, dbo.c1_cust.cust_nm, dbo.mfr.mfr_inm, dbo.c1_or.or_nm, dbo.c1_lost.lst_syscd + dbo.c1_lost.lst_custno ");
            sb.Append(@"+ dbo.c1_lost.lst_otp1cd + dbo.c1_lost.lst_otp1seq AS orderno, dbo.c1_cust.cust_custno, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, dbo.c1_or.or_syscd");
            sb.Append(@", dbo.c1_otp.otp_otp1cd, dbo.c1_otp.otp_otp2cd, dbo.mfr.mfr_mfrno FROM dbo.c1_lost INNER JOIN dbo.c1_order ON dbo.c1_lost.lst_syscd = dbo.c1_order.o_syscd AND dbo.c1_lost.lst_custno = ");
            sb.Append(@"dbo.c1_order.o_custno AND dbo.c1_lost.lst_otp1cd = dbo.c1_order.o_otp1cd AND dbo.c1_lost.lst_otp1seq = dbo.c1_order.o_otp1seq INNER JOIN dbo.c1_otp ON dbo.c1_order.o_otp1cd =");
            sb.Append(@" dbo.c1_otp.otp_otp1cd AND dbo.c1_order.o_otp2cd = dbo.c1_otp.otp_otp2cd INNER JOIN dbo.c1_cust ON dbo.c1_lost.lst_custno = dbo.c1_cust.cust_custno INNER JOIN dbo.mfr ");
            sb.Append(@"ON dbo.c1_cust.cust_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.c1_or ON dbo.c1_lost.lst_syscd = dbo.c1_or.or_syscd AND dbo.c1_lost.lst_custno = dbo.c1_or.or_custno");
            sb.Append(@" AND dbo.c1_lost.lst_otp1cd = dbo.c1_or.or_otp1cd AND dbo.c1_lost.lst_otp1seq = dbo.c1_or.or_otp1seq AND dbo.c1_lost.lst_oritem = dbo.c1_or.or_oritem WHERE 1=1 ");
            if (rblSent.ToString() == "0")
            {
                sb.Append(@" AND lst_fgsent <> 'C' ");
            }
            else if (rblSent.ToString() == "1")
            {
                sb.Append(@" AND lst_fgsent = 'C' ");
            }
            if (tbxOrderNo.ToString().Trim() != "" && tbxOrderNo.ToString().Length == 13)
            {
                sb.Append(@" AND lst_custno = @lst_custno ");
                sb.Append(@" AND lst_otp1cd = @lst_otp1cd ");
                sb.Append(@" AND lst_otp1seq = @lst_otp1seq ");
            }

            if (tbxCompanyname.ToString().Trim() != "")
            {
                sb.Append(@" AND mfr_inm Like '%'+@tbxCompanyname+'%' ");
            }
            if (tbxMfrno.ToString().Trim() != "")
            {
                sb.Append(@" AND cust_mfrno Like '%'+@tbxMfrno+'%' ");
            }
            if (tbxCustNo.ToString().Trim() != "")
            {
                sb.Append(@" AND lst_custno = @tbxCustNo ");
            }
            if (tbxCustName.ToString().Trim() != "")
            {
                sb.Append(@" AND cust_nm Like '%'+@tbxCustName+'%' ");
            }
            if (tbxRecName.ToString().Trim() != "")
            {
                sb.Append(@" AND or_nm Like '%'+@tbxRecName+'%' ");
            }
            if (tbxRecAddr.ToString().Trim() != "")
            {
                sb.Append(@" AND or_addr Like '%'+@tbxRecAddr+'%' ");
            }
            if (tbxRecTel.ToString().Trim() != "")
            {
                sb.Append(@" AND or_tel = @tbxRecTel ");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            if (tbxOrderNo.ToString().Trim() != "" && tbxOrderNo.ToString().Length == 13)
            {
                oCmd.Parameters.AddWithValue("@lst_custno", tbxOrderNo.Substring(2, 6));
                oCmd.Parameters.AddWithValue("@lst_otp1cd", tbxOrderNo.Substring(8, 2));
                oCmd.Parameters.AddWithValue("@lst_otp1seq", tbxOrderNo.Substring(10, 3));
            }
            oCmd.Parameters.AddWithValue("@tbxCompanyname", tbxCompanyname);
            oCmd.Parameters.AddWithValue("@tbxMfrno", tbxMfrno);
            oCmd.Parameters.AddWithValue("@tbxCustNo", tbxCustNo);
            oCmd.Parameters.AddWithValue("@tbxCustName", tbxCustName);
            oCmd.Parameters.AddWithValue("@tbxRecName", tbxRecName);
            oCmd.Parameters.AddWithValue("@tbxRecAddr", tbxRecAddr);
            oCmd.Parameters.AddWithValue("@tbxRecTel", tbxRecTel);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }
    }
}