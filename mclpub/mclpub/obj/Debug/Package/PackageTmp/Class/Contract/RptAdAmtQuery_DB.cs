using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class RptAdAmtQuery_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet GetSrspns()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT RTRIM(srspn_empno) AS srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, srspn_pwd FROM srspn where (srspn_atype = 'B') OR (srspn_atype = 'C')");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cust_custno", cust_custno);
            oda.Fill(ds);
            return ds;
        }


        public DataSet SelectAll(string STRtbxMfrName, string STRtbxSDate, string STRtbxEDate, string STRddlEmpData)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT v_c4_adamtlist.cont_contno, v_c4_adamtlist.adr_seq, ");
            sb.Append(@"v_c4_adamtlist.mfr_mfrno, v_c4_adamtlist.mfr_inm, v_c4_adamtlist.mfr_iaddr, ");
            sb.Append(@"v_c4_adamtlist.adr_addate, v_c4_adamtlist.adr_adcate, ");
            sb.Append(@"v_c4_adamtlist.adr_keyword, v_c4_adamtlist.adr_impr, ");
            sb.Append(@"v_c4_adamtlist.adr_invamt, v_c4_adamtlist.adr_adamt, ");
            sb.Append(@"v_c4_adamtlist.adr_desamt, v_c4_adamtlist.adr_chgamt, ");
            sb.Append(@"v_c4_adamtlist.adr_fginved, ISNULL(v_c4_adamtlist.ia_invno, '') AS invno, ");
            sb.Append(@"ISNULL(v_c4_adamtlist.ia_iano, '') AS iano, srspn.srspn_cname ");
            sb.Append(@"FROM v_c4_adamtlist INNER JOIN ");
            sb.Append(@"srspn ON v_c4_adamtlist.cont_empno = srspn.srspn_empno WHERE 1=1 ");

            if (STRtbxMfrName.ToString() != "")
            {
                sb.Append(@" AND mfr_inm LIKE '%'+@STRtbxMfrName+'%' ");
            }

            if (STRtbxSDate.ToString() != "" && STRtbxEDate.ToString() != "")
            {
                sb.Append(@" AND (@STRtbxSDate<=adr_addate AND adr_addate<=@STRtbxEDate) ");
            }
            else if (STRtbxSDate.ToString() != "")
            {
                sb.Append(@" AND (@STRtbxSDate<=adr_addate) ");
            }
            else if (STRtbxEDate.ToString() != "")
            {
                sb.Append(@" AND (adr_addate<=@STRtbxEDate) ");
            }

            if (STRddlEmpData.ToString() != "")
            {
                sb.Append(@" AND cont_empno=@STRddlEmpData ");
            }

            sb.Append(@" ORDER BY v_c4_adamtlist.cont_contno, v_c4_adamtlist.adr_addate, v_c4_adamtlist.adr_seq");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@STRtbxMfrName", STRtbxMfrName);
            oCmd.Parameters.AddWithValue("@STRtbxSDate", STRtbxSDate);
            oCmd.Parameters.AddWithValue("@STRtbxEDate", STRtbxEDate);
            oCmd.Parameters.AddWithValue("@STRddlEmpData", STRddlEmpData);
            oda.Fill(ds);
            return ds;
        }



        public DataSet SubDs(string STRtbxMfrName, string STRtbxSDate, string STRtbxEDate, string STRddlEmpData,string cont_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT COUNT(*) AS countCol ");
            sb.Append(@"FROM v_c4_adamtlist INNER JOIN ");
            sb.Append(@"srspn ON v_c4_adamtlist.cont_empno = srspn.srspn_empno WHERE 1=1 AND cont_contno=@cont_contno ");

            if (STRtbxMfrName.ToString() != "")
            {
                sb.Append(@" AND mfr_inm LIKE '%'+@STRtbxMfrName+'%' ");
            }

            if (STRtbxSDate.ToString() != "" && STRtbxEDate.ToString() != "")
            {
                sb.Append(@" AND (@STRtbxSDate<=adr_addate AND adr_addate<=@STRtbxEDate) ");
            }
            else if (STRtbxSDate.ToString() != "")
            {
                sb.Append(@" AND (@STRtbxSDate<=adr_addate) ");
            }
            else if (STRtbxEDate.ToString() != "")
            {
                sb.Append(@" AND (adr_addate<=@STRtbxEDate) ");
            }

            if (STRddlEmpData.ToString() != "")
            {
                sb.Append(@" AND cont_empno=@STRddlEmpData ");
            }

            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@STRtbxMfrName", STRtbxMfrName);
            oCmd.Parameters.AddWithValue("@STRtbxSDate", STRtbxSDate);
            oCmd.Parameters.AddWithValue("@STRtbxEDate", STRtbxEDate);
            oCmd.Parameters.AddWithValue("@STRddlEmpData", STRddlEmpData);
            oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            oda.Fill(ds);
            return ds;
        }



        public DataSet AddFormat(string STRtbxMfrName, string STRtbxSDate, string STRtbxEDate, string STRddlEmpData)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select distinct cont_contno FROM v_c4_adamtlist INNER JOIN ");
            sb.Append(@"srspn ON v_c4_adamtlist.cont_empno = srspn.srspn_empno WHERE 1=1 ");

            if (STRtbxMfrName.ToString() != "")
            {
                sb.Append(@" AND mfr_inm LIKE '%'+@STRtbxMfrName+'%' ");
            }

            if (STRtbxSDate.ToString() != "" && STRtbxEDate.ToString() != "")
            {
                sb.Append(@" AND (@STRtbxSDate<=adr_addate AND adr_addate<=@STRtbxEDate) ");
            }
            else if (STRtbxSDate.ToString() != "")
            {
                sb.Append(@" AND (@STRtbxSDate<=adr_addate) ");
            }
            else if (STRtbxEDate.ToString() != "")
            {
                sb.Append(@" AND (adr_addate<=@STRtbxEDate) ");
            }

            if (STRddlEmpData.ToString() != "")
            {
                sb.Append(@" AND cont_empno=@STRddlEmpData ");
            }

            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@STRtbxMfrName", STRtbxMfrName);
            oCmd.Parameters.AddWithValue("@STRtbxSDate", STRtbxSDate);
            oCmd.Parameters.AddWithValue("@STRtbxEDate", STRtbxEDate);
            oCmd.Parameters.AddWithValue("@STRddlEmpData", STRddlEmpData);
            oda.Fill(ds);
            return ds;
        }


    }
}
