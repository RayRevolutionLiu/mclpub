using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace mclpub
{
    public class CustListFilter_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"].ToString();

        public DataTable SelectJtype(string otp_otp1cd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT otp_otpid, otp_otp1cd, otp_otp1nm, otp_otp2cd, otp_otp2nm FROM c1_otp WHERE otp_otp1cd=@otp_otp1cd");
            //if (mfrno.ToString() != "")
            //{
            //    sb.Append(@"and mfr_mfrno=@mfrno ");
            //}
            //if (company.ToString() != "")
            //{
            //    sb.Append(@"and mfr_inm=@company ");
            //}
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oCmd.Parameters.AddWithValue("@otp_otp1cd", otp_otp1cd);
            //oCmd.Parameters.AddWithValue("@company", company);

            oda.Fill(ds);
            return ds;

        }

        public DataTable SelectBooktype(string obtp_otp1cd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT obtp_obtpid, obtp_otp1cd, obtp_obtpcd, obtp_obtpnm FROM c1_obtp WHERE obtp_otp1cd=@obtp_otp1cd");
            //if (mfrno.ToString() != "")
            //{
            //    sb.Append(@"and mfr_mfrno=@mfrno ");
            //}
            //if (company.ToString() != "")
            //{
            //    sb.Append(@"and mfr_inm=@company ");
            //}
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            oCmd.Parameters.AddWithValue("@obtp_otp1cd", obtp_otp1cd);
            //oCmd.Parameters.AddWithValue("@company", company);

            oda.Fill(ds);
            return ds;

        }

        public DataTable SelectMailtype(string mtp_mtpcd)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            if (mtp_mtpcd.ToString() == "0")
            {
                sb.Append(@"SELECT mtp_mtpid, mtp_mtpcd, mtp_nm FROM mtp WHERE mtp_mtpcd LIKE '1%'");
            }
            if (mtp_mtpcd.ToString() == "1")
            {
                sb.Append(@"SELECT mtp_mtpid, mtp_mtpcd, mtp_nm FROM mtp WHERE mtp_mtpcd LIKE '2%'");
            }
            //if (mfrno.ToString() != "")
            //{
            //    sb.Append(@"and mfr_mfrno=@mfrno ");
            //}
            //if (company.ToString() != "")
            //{
            //    sb.Append(@"and mfr_inm=@company ");
            //}
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            //oCmd.Parameters.AddWithValue("@mtp_mtpcd", mtp_mtpcd);
            //oCmd.Parameters.AddWithValue("@company", company);

            oda.Fill(ds);
            return ds;

        }


        public DataTable SelectChkBtn(string ddlCustType, string tbxOrderDate1, string tbxOrderDate2, string tbxDate1, string tbxDate2, string ddlOrderType1, string ddlOrderType2,
            string ddlBookType, string ddlMailType, string tbxRecName, string tbxDate,string top300,string WebOrExcel)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            //StringBuilder sb = new StringBuilder();
            //sb.Append(@"SELECT" + top300 + "od_odid, od_syscd, od_custno, od_o");
            //sb.Append(@"tp1cd, od_otp1seq, od_oditem, od_sdate, ");
            //sb.Append(@"od_edate, od_btpcd, od_amt, or_inm, or_n");
            //sb.Append(@"m, or_addr, or_zip, or_tel, ra_mnt, ");
            //sb.Append(@"o_pytpcd, o_otp1seq, ra_oditem, ");
            //sb.Append(@"ra_oritem, o_custno, o_otp1cd, o_syscd, ");
            //sb.Append(@"or_custno, or_oritem, or_otp1cd, or_otp1s");
            //sb.Append(@"eq, or_syscd, ra_custno, ra_otp1cd, ");
            //sb.Append(@"ra_otp1seq, ra_syscd,od_syscd + od_custno + ");
            //sb.Append(@"od_otp1cd + od_otp1seq AS nostr, o_date, ");
            //sb.Append(@"obtp_obtpnm, obtp_obtpcd,obtp_otp1cd, od");
            //sb.Append(@"_sdate + '~' + od_edate AS datestr, o_fgpreinv, ");
            //sb.Append(@"o_indate,o_empno, ra_mtpcd,o_otp2cd ");
            //sb.Append(@"FROM c1_od INNER JOIN c1_order ON od_syscd = o_sy");
            //sb.Append(@"scd AND od_custno = o_custno AND od_otp1cd = ");
            //sb.Append(@"o_otp1cd AND od_otp1seq = o_otp1seq INNER JOIN");
            //sb.Append(@" c1_ramt ON od_syscd = ra_syscd AND od_custn");
            //sb.Append(@"o = ra_custno AND od_otp1cd = ra_otp1cd AND ");
            //sb.Append(@"od_otp1seq = ra_otp1seq AND od_oditem = ");
            //sb.Append(@"ra_oditem INNER JOIN c1_or ON ra_syscd = or_syscd AN");
            //sb.Append(@"D ra_custno = or_custno AND ra_otp1cd = ");
            //sb.Append(@"or_otp1cd AND ra_otp1seq = or_otp1seq AND ");
            //sb.Append(@"ra_oritem = or_oritem LEFT OUTER JOIN c1_obtp ON od_btpc");
            //sb.Append(@"d = obtp_obtpcd AND od_otp1cd = obtp_otp1cd WH");
            //sb.Append(@"ERE (od_syscd = 'C1')");
            //if (ddlCustType.ToString() != "請選擇")
            //{
            //    if (ddlCustType.ToString()=="新訂戶")
            //        sb.Append(@" and od_otp1seq='001'");
            //    else
            //        sb.Append(@" and od_otp1seq<>'001'");
            //    //sb.Append(@"");
            //}
            //if (tbxOrderDate1.ToString() != "" && tbxOrderDate2.ToString() != "")
            //{
            //    sb.Append(@" and (o_date>=@tbxOrderDate1 and o_date<=@tbxOrderDate2)");
            //}
            //if (tbxDate1.ToString() != "" && tbxDate2.ToString()!="")
            //{
            //    sb.Append(@" and (o_indate>=@tbxDate1 and o_indate<=@tbxDate2)");
            //}
            //if (ddlOrderType1.ToString() != "00")
            //{
            //    sb.Append(@" and od_otp1cd=@ddlOrderType1");
            //}
            //if (ddlOrderType2.ToString() != "0")
            //{
            //    sb.Append(@" and o_otp2cd=@ddlOrderType2");
            //}
            //if (ddlBookType.ToString() != "0")
            //{
            //    sb.Append(@" and od_btpcd=@ddlBookType");
            //}
            //if (ddlMailType.ToString() != "00")
            //{
            //    sb.Append(@" and ra_mtpcd=@ddlMailType");
            //}
            //if (tbxRecName.ToString() != "")
            //{
            //    sb.Append(@" and or_nm LIKE '%'+@tbxRecName+'%'");
            //}
            //if (tbxDate.ToString() != "")
            //{
            //    sb.Append(@" and (od_sdate <= @tbxDate and od_edate >= @tbxDate)");
            //}

            oCmd.CommandText = "Subscriber_CustListFilter";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataTable ds = new DataTable();
            if (ddlCustType.ToString() == "請選擇")
            {
                oCmd.Parameters.AddWithValue("@ddlCustType", DBNull.Value);
            }
            else
            {
                oCmd.Parameters.AddWithValue("@ddlCustType", ddlCustType);
            }

            if (tbxOrderDate1.ToString() != "" && tbxOrderDate2.ToString() != "")
            {
                oCmd.Parameters.AddWithValue("@tbxOrderDate1", tbxOrderDate1);
                oCmd.Parameters.AddWithValue("@tbxOrderDate2", tbxOrderDate2);
            }
            else
            {
                oCmd.Parameters.AddWithValue("@tbxOrderDate1", DBNull.Value);
                oCmd.Parameters.AddWithValue("@tbxOrderDate2", DBNull.Value);
            }

            if (tbxDate1.ToString() != "" && tbxDate2.ToString() != "")
            {
                oCmd.Parameters.AddWithValue("@tbxDate1", tbxDate1);
                oCmd.Parameters.AddWithValue("@tbxDate2", tbxDate2);
            }
            else
            {
                oCmd.Parameters.AddWithValue("@tbxDate1", DBNull.Value);
                oCmd.Parameters.AddWithValue("@tbxDate2", DBNull.Value);
            }

            if (ddlOrderType1.ToString() != "00")
            {
                oCmd.Parameters.AddWithValue("@ddlOrderType1", ddlOrderType1);
            }
            else
            {
                oCmd.Parameters.AddWithValue("@ddlOrderType1", DBNull.Value);
            }

            if (ddlOrderType2.ToString() != "0")
            {
                oCmd.Parameters.AddWithValue("@ddlOrderType2", ddlOrderType2);
            }
            else
            {
                oCmd.Parameters.AddWithValue("@ddlOrderType2", DBNull.Value);
            }

            if (ddlBookType.ToString() != "0")
            {
                oCmd.Parameters.AddWithValue("@ddlBookType", ddlBookType);
            }
            else
            {
                oCmd.Parameters.AddWithValue("@ddlBookType", DBNull.Value);
            }

            if (ddlMailType.ToString() != "00")
            {
                oCmd.Parameters.AddWithValue("@ddlMailType", ddlMailType);
            }
            else
            {
                oCmd.Parameters.AddWithValue("@ddlMailType", DBNull.Value);
            }

            if (tbxRecName.ToString() != "")
            {
                oCmd.Parameters.AddWithValue("@tbxRecName", tbxRecName);
            }
            else
            {
                oCmd.Parameters.AddWithValue("@tbxRecName", DBNull.Value);
            }

            if (tbxDate.ToString() != "")
            {
                oCmd.Parameters.AddWithValue("@tbxDate", tbxDate);
            }
            else
            {
                oCmd.Parameters.AddWithValue("@tbxDate", DBNull.Value);
            }

            oCmd.Parameters.AddWithValue("@top300", top300);
            oCmd.Parameters.AddWithValue("@WebOrExcel", WebOrExcel);
            oda.Fill(ds);
            return ds;

        }
    }
}
