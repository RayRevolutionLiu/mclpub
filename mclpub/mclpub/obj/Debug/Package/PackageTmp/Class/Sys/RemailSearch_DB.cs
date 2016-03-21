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
    public class RemailSearch_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet Selectc1_order(string tbxOrderNo, string tbxCompanyname, string tbxMfrno, string tbxCustNo, string tbxCustName, string tbxRecName, string tbxRecAddr, string tbxRecTel, string tbxOrderDate1, string tbxOrderDate2)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.");
            sb.Append(@"c1_order.o_mfrno, dbo.c1_or.or_nm, dbo.c1_or.or_addr, dbo.c1_or.or_tel, dbo.c1_o");
            sb.Append(@"d.od_sdate, dbo.c1_od.od_edate, dbo.c1_order.o_syscd, dbo.mfr.mfr_inm, dbo.c1_od");
            sb.Append(@".od_custno, dbo.c1_od.od_oditem, dbo.c1_od.od_otp1cd, dbo.c1_od.od_otp1seq, dbo.");
            sb.Append(@"c1_od.od_syscd, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, d");
            sb.Append(@"bo.c1_or.or_otp1seq, dbo.c1_or.or_syscd, dbo.mfr.mfr_mfrid, dbo.c1_obtp.obtp_obt");
            sb.Append(@"pnm, dbo.c1_obtp.obtp_obtpcd, dbo.c1_obtp.obtp_otp1cd, dbo.c1_otp.otp_otp1nm, db");
            sb.Append(@"o.c1_otp.otp_otp2cd, dbo.c1_otp.otp_otp1cd, dbo.c1_od.od_syscd + dbo.c1_od.od_cu");
            sb.Append(@"stno + dbo.c1_od.od_otp1cd + dbo.c1_od.od_otp1seq AS orderno, dbo.mfr.mfr_mfrno,");
            sb.Append(@" dbo.c1_cust.cust_nm, dbo.c1_cust.cust_custno, dbo.c1_order.o_date FROM dbo.c1_o");
            sb.Append(@"rder INNER JOIN dbo.c1_od ON dbo.c1_order.o_syscd = dbo.c1_od.od_syscd AND dbo.c");
            sb.Append(@"1_order.o_custno = dbo.c1_od.od_custno AND dbo.c1_order.o_otp1cd = dbo.c1_od.od_");
            sb.Append(@"otp1cd AND dbo.c1_order.o_otp1seq = dbo.c1_od.od_otp1seq INNER JOIN dbo.mfr ON d");
            sb.Append(@"bo.c1_order.o_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.c1_obtp ON dbo.c1_od.od_o");
            sb.Append(@"tp1cd = dbo.c1_obtp.obtp_otp1cd AND dbo.c1_od.od_btpcd = dbo.c1_obtp.obtp_obtpcd");
            sb.Append(@" INNER JOIN dbo.c1_otp ON dbo.c1_order.o_otp1cd = dbo.c1_otp.otp_otp1cd AND dbo.");
            sb.Append(@"c1_order.o_otp2cd = dbo.c1_otp.otp_otp2cd INNER JOIN dbo.c1_ramt ON dbo.c1_od.od");
            sb.Append(@"_syscd = dbo.c1_ramt.ra_syscd AND dbo.c1_od.od_custno = dbo.c1_ramt.ra_custno AN");
            sb.Append(@"D dbo.c1_od.od_otp1cd = dbo.c1_ramt.ra_otp1cd AND dbo.c1_od.od_otp1seq = dbo.c1_");
            sb.Append(@"ramt.ra_otp1seq AND dbo.c1_od.od_oditem = dbo.c1_ramt.ra_oditem INNER JOIN dbo.c");
            sb.Append(@"1_or ON dbo.c1_ramt.ra_syscd = dbo.c1_or.or_syscd AND dbo.c1_ramt.ra_custno = db");
            sb.Append(@"o.c1_or.or_custno AND dbo.c1_ramt.ra_otp1cd = dbo.c1_or.or_otp1cd AND dbo.c1_ram");
            sb.Append(@"t.ra_otp1seq = dbo.c1_or.or_otp1seq AND dbo.c1_ramt.ra_oritem = dbo.c1_or.or_ori");
            sb.Append(@"tem INNER JOIN dbo.c1_cust ON dbo.c1_order.o_custno = dbo.c1_cust.cust_custno WH");
            sb.Append(@"ERE (dbo.c1_order.o_syscd = 'C1') ");
            if (tbxOrderNo != "")
            {
                sb.Append(@" and o_custno= SUBSTRING(@tbxOrderNo, 3, 6) ");
                sb.Append(@" and o_otp1cd= SUBSTRING(@tbxOrderNo, 9, 2) ");
                sb.Append(@" and o_otp1seq= SUBSTRING(@tbxOrderNo, 11, 3) ");
            }
            if (tbxCompanyname != "")
                sb.Append(@" and mfr_inm Like '%'+@tbxCompanyname+'%' ");
            if (tbxMfrno != "")
                sb.Append(@" and o_mfrno = @tbxMfrno ");
            if (tbxCustNo != "")
                sb.Append(@" and o_custno = @tbxCustNo ");

            if (tbxCustName != "")
                sb.Append(@" and cust_nm Like '%'+@tbxCustName+'%' ");
            if (tbxRecName != "")
                sb.Append(@" and or_nm Like '%'+@tbxRecName+'%' ");
            if (tbxRecAddr != "")
                sb.Append(@" and or_addr Like '%'+@tbxRecAddr+'%' ");
            if (tbxRecTel != "")
                sb.Append(@" and or_tel= @tbxRecTel ");
            if (tbxOrderDate1 != "" && tbxOrderDate2 != "")
            {
                sb.Append(@" and (o_date >= @tbxOrderDate1 and o_date <= @tbxOrderDate2 )");
            }
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            oCmd.Parameters.AddWithValue("@tbxOrderNo", tbxOrderNo);
            oCmd.Parameters.AddWithValue("@tbxCompanyname", tbxCompanyname);
            oCmd.Parameters.AddWithValue("@tbxMfrno", tbxMfrno);
            oCmd.Parameters.AddWithValue("@tbxCustNo", tbxCustNo);
            oCmd.Parameters.AddWithValue("@tbxCustName", tbxCustName);
            oCmd.Parameters.AddWithValue("@tbxRecName", tbxRecName);
            oCmd.Parameters.AddWithValue("@tbxRecAddr", tbxRecAddr);
            oCmd.Parameters.AddWithValue("@tbxRecTel", tbxRecTel);
            oCmd.Parameters.AddWithValue("@tbxOrderDate1", tbxOrderDate1 == "" ? "" : tbxOrderDate1.Substring(0, 4) + tbxOrderDate1.Substring(5, 2) + tbxOrderDate1.Substring(8, 2));
            oCmd.Parameters.AddWithValue("@tbxOrderDate2", tbxOrderDate2 == "" ? "" : tbxOrderDate2.Substring(0, 4) + tbxOrderDate2.Substring(5, 2) + tbxOrderDate2.Substring(8, 2));
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public DataSet Selectc1_remail()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT dbo.c1_order.o_date, dbo.c1_remail.rm_rmid, dbo.c1_remail.rm_syscd, dbo.c1_remail.rm_custno");
            sb.Append(@", dbo.c1_remail.rm_otp1cd, dbo.c1_remail.rm_otp1seq, dbo.c1_remail.rm_oritem, dbo.c1_remail.rm_seq");
            sb.Append(@", dbo.c1_remail.rm_cont, dbo.c1_remail.rm_date, dbo.c1_remail.rm_fgsent, dbo.c1_otp.otp_otp1nm, dbo.c1_or.or_nm, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, ");
            sb.Append(@"dbo.c1_or.or_otp1seq, dbo.c1_or.or_syscd, dbo.c1_otp.otp_otp1cd, dbo.c1_otp.otp_otp2cd, dbo.c1_cust.cust_nm, dbo.mfr.mfr_inm, dbo.c1_cust.cust_custno, dbo.mfr.mfr_mfrno,");
            sb.Append(@" dbo.c1_or.or_addr, dbo.c1_or.or_tel, dbo.c1_remail.rm_syscd + dbo.c1_remail.rm_custno + dbo.c1_remail.rm_otp1cd + dbo.c1_remail.rm_otp1seq AS orderno, dbo.c1_otp.otp_otp2nm");
            sb.Append(@" FROM dbo.c1_remail INNER JOIN dbo.c1_or ON dbo.c1_remail.rm_syscd = dbo.c1_or.or_syscd AND dbo.c1_remail.rm_custno = dbo.c1_or.or_custno AND dbo.c1_remail.rm_otp1cd");
            sb.Append(@" = dbo.c1_or.or_otp1cd AND dbo.c1_remail.rm_otp1seq = dbo.c1_or.or_otp1seq AND dbo.c1_remail.rm_oritem = dbo.c1_or.or_oritem INNER JOIN dbo.c1_cust ON ");
            sb.Append(@"dbo.c1_remail.rm_custno = dbo.c1_cust.cust_custno INNER JOIN dbo.mfr ON dbo.c1_cust.cust_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.c1_order ON dbo.c1_remail.rm_syscd");
            sb.Append(@" = dbo.c1_order.o_syscd AND dbo.c1_remail.rm_custno = dbo.c1_order.o_custno AND dbo.c1_remail.rm_otp1cd = dbo.c1_order.o_otp1cd AND dbo.c1_remail.rm_otp1seq");
            sb.Append(@" = dbo.c1_order.o_otp1seq INNER JOIN dbo.c1_otp ON dbo.c1_order.o_otp1cd = dbo.c1_otp.otp_otp1cd AND dbo.c1_order.o_otp2cd = dbo.c1_otp.otp_otp2cd");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public void Delc1_remail(string rm_custno, string rm_oritem, string rm_otp1cd, string rm_otp1seq, string rm_syscd, string rm_seq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"DELETE FROM dbo.c1_remail WHERE (rm_custno = @rm_custno) AND (rm_oritem = @rm_oritem) AND (rm_otp1cd = @rm_otp1cd) AND (rm_otp1seq = @rm_otp1seq) AND (rm_syscd = @rm_syscd) AND (rm_seq = @rm_seq)";
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@rm_custno", rm_custno);
            oCmd.Parameters.AddWithValue("@rm_oritem", rm_oritem);
            oCmd.Parameters.AddWithValue("@rm_otp1cd", rm_otp1cd);
            oCmd.Parameters.AddWithValue("@rm_otp1seq", rm_otp1seq);
            oCmd.Parameters.AddWithValue("@rm_syscd", rm_syscd);
            oCmd.Parameters.AddWithValue("@rm_seq", rm_seq);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}