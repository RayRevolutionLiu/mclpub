using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class RptCont_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public void RtpGenData()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            //StringBuilder sb = new StringBuilder();
            oCmd.CommandText = "sp_c4_rpt_contlist_gendata";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

        }


        public DataSet rsCount(string cont_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT COUNT(*) ");
            sb.Append(@"FROM c4_cont LEFT OUTER JOIN cust ON cont_custno = cust_custno ");
            sb.Append(@"LEFT OUTER JOIN mfr ON cust_mfrno = mfr_mfrno AND cont_mfrno = mfr_mfrno ");
            sb.Append(@"LEFT OUTER JOIN wk_c4_matpstring ON cont_contno COLLATE Chinese_Taiwan_Stroke_BIN=wkmatp_contno ");
            sb.Append(@"LEFT OUTER JOIN wk_c4_atpstring ON cont_contno COLLATE Chinese_Taiwan_Stroke_BIN=wkatp_contno ");
            sb.Append(@"LEFT OUTER JOIN wk_c4_fbkstring ON cont_contno COLLATE Chinese_Taiwan_Stroke_BIN=wkfbk_contno ");
            sb.Append(@"WHERE (cont_fgtemp = '0') AND cont_contno=@cont_contno ");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            oda.Fill(ds);
            return ds;
        }



        public DataSet rsData(string cont_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT *, cust_custno, cust_nm, mfr_mfrno, mfr_inm, wkmatp_matpstr, wkatp_atpstr, wkfbk_fbkstr ");
            sb.Append(@"FROM c4_cont LEFT OUTER JOIN cust ON cont_custno = cust_custno ");
            sb.Append(@"LEFT OUTER JOIN mfr ON cust_mfrno = mfr_mfrno AND cont_mfrno = mfr_mfrno ");
            sb.Append(@"LEFT OUTER JOIN wk_c4_matpstring ON cont_contno COLLATE Chinese_Taiwan_Stroke_BIN=wkmatp_contno ");
            sb.Append(@"LEFT OUTER JOIN wk_c4_atpstring ON cont_contno COLLATE Chinese_Taiwan_Stroke_BIN=wkatp_contno ");
            sb.Append(@"LEFT OUTER JOIN wk_c4_fbkstring ON cont_contno COLLATE Chinese_Taiwan_Stroke_BIN=wkfbk_contno ");
            sb.Append(@"WHERE (cont_fgtemp = '0') AND cont_contno=@cont_contno ");

            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            oda.Fill(ds);
            return ds;
        }


        public DataSet rsAdrCount(string cont_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT COUNT(*) AS AdrCount ");
            sb.Append(@"FROM c4_adr INNER JOIN c4_cont ON adr_contno = cont_contno LEFT OUTER JOIN invmfr ON adr_syscd = im_syscd AND adr_contno = im_contno AND adr_imseq = im_imseq ");
            sb.Append(@"WHERE 1=1 AND cont_contno=@cont_contno ");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            oda.Fill(ds);
            return ds;
        }


        public DataSet rsEmp()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT srspn_empno, srspn_cname FROM srspn ");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            oda.Fill(ds);
            return ds;
        }

        //取得已繳款之總金額
        public DataSet rsPy(string cont_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT SUM(ia.ia_pyat) AS sum_py, ia_contno from ia ");
            sb.Append(@"WHERE (ia_syscd = 'C4') ");
            sb.Append(@"AND (SUBSTRING(ia_contno, 3, 6) = @cont_contno) ");
            sb.Append(@"AND (ia.ia_pyno <> '') GROUP BY  ia_contno ");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            oda.Fill(ds);
            return ds;
        }

        //取得已轉SAP的發票總金額
        public DataSet rsIa(string cont_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT SUM(ia.ia_pyat) AS sum_ia, ia_contno from ia ");
            sb.Append(@"WHERE (ia_syscd = 'C4') ");
            sb.Append(@"AND (SUBSTRING(ia_contno, 3, 6) = @cont_contno) ");
            sb.Append(@"AND (ia_status = '7') GROUP BY  ia_contno");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            oda.Fill(ds);
            return ds;
        }


        public DataSet rsAdr(string cont_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT adr_contno, adr_seq, adr_addate, adr_adcate, adr_keyword, adr_alttext, adr_imgurl, adr_impr, ");
            sb.Append(@"adr_navurl, adr_drafttp, adr_urltp, adr_imseq, adr_invamt, adr_adamt, adr_desamt, adr_chgamt, ");
            sb.Append(@"adr_remark, adr_projno, adr_costctr, adr_fginved, adr_fgfixad, adr_fgimggot, adr_fgurlgot, adr_fginvself, adr_fgact, ");
            sb.Append(@"im_mfrno, im_nm, im_jbti, im_zip, im_addr, im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri, cont_signdate ");
            sb.Append(@"FROM c4_adr INNER JOIN c4_cont ON adr_contno = cont_contno LEFT OUTER JOIN invmfr ON adr_syscd = im_syscd AND adr_contno = im_contno AND adr_imseq = im_imseq WHERE (1=1) AND adr_contno=@cont_contno ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            oda.Fill(ds);
            return ds;
        }


        public DataSet GetSrspns()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT RTRIM(srspn_empno) AS srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, srspn_pwd FROM srspn where (srspn_atype = 'B') OR (srspn_atype = 'C')");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            //oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            oda.Fill(ds);
            return ds;
        }



        public DataSet rsDataBig(string cont_contno, string tbxSDate, string tbxEDate, string cont_empno, string mfr_inm, string cont_fgclosed, string cont_fgcancel)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c4_cont.*, cust_custno, cust_nm, mfr_mfrno, mfr_inm, wkmatp_matpstr, wkatp_atpstr, wkfbk_fbkstr ");
            sb.Append(@"FROM c4_cont LEFT OUTER JOIN cust ON cont_custno = cust_custno ");
            sb.Append(@"LEFT OUTER JOIN mfr ON cust_mfrno = mfr_mfrno AND cont_mfrno = mfr_mfrno ");
            sb.Append(@"LEFT OUTER JOIN wk_c4_matpstring ON cont_contno COLLATE Chinese_Taiwan_Stroke_BIN=wkmatp_contno ");
            sb.Append(@"LEFT OUTER JOIN wk_c4_atpstring ON cont_contno COLLATE Chinese_Taiwan_Stroke_BIN=wkatp_contno ");
            sb.Append(@"LEFT OUTER JOIN wk_c4_fbkstring ON cont_contno COLLATE Chinese_Taiwan_Stroke_BIN=wkfbk_contno ");
            sb.Append(@"WHERE (cont_fgtemp = '0') ");

            if (cont_contno.ToString() != "")
            {
                sb.Append(@" AND (cont_contno=@cont_contno) ");
            }

            if (tbxSDate.ToString() != "" && tbxEDate.ToString() != "")
            {
                sb.Append(@" AND (@tbxSDate<=cont_signdate AND cont_signdate<=@tbxEDate) ");
            }
            else if (tbxSDate.ToString() != "")
            {
                sb.Append(@" AND (@tbxSDate<=cont_signdate) ");
            }
            else if (tbxEDate.ToString() != "")
            {
                sb.Append(@" AND (cont_signdate<=@tbxEDate) ");
            }

            if (cont_empno.ToString() != "")
            {
                sb.Append(@" AND cont_empno=@cont_empno ");
            }

            if (mfr_inm.ToString() != "")
            {
                sb.Append(@" AND mfr_inm LIKE '%'+@mfr_inm+'%' ");
            }

            if (cont_fgclosed.ToString() != "")
            {
                sb.Append(@" AND cont_fgclosed=@cont_fgclosed ");
            }

            if (cont_fgcancel.ToString() != "")
            {
                sb.Append(@" AND cont_fgcancel=@cont_fgcancel ");
            }
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            oCmd.Parameters.AddWithValue("@tbxSDate", tbxSDate);
            oCmd.Parameters.AddWithValue("@tbxEDate", tbxEDate);
            oCmd.Parameters.AddWithValue("@cont_empno", cont_empno);
            oCmd.Parameters.AddWithValue("@mfr_inm", mfr_inm);
            oCmd.Parameters.AddWithValue("@cont_fgclosed", cont_fgclosed);
            oCmd.Parameters.AddWithValue("@cont_fgcancel", cont_fgcancel);
            oda.Fill(ds);
            return ds;
        }



        public DataSet rsAdrBig(string cont_contno, string tbxSDate, string tbxEDate, string cont_empno, string mfr_inm, string cont_fgclosed, string cont_fgcancel)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT adr_contno, adr_seq, adr_addate, adr_adcate, adr_keyword, adr_alttext, adr_imgurl, adr_impr, ");
            sb.Append(@"adr_navurl, adr_drafttp, adr_urltp, adr_imseq, adr_invamt, adr_adamt, adr_desamt, adr_chgamt, ");
            sb.Append(@"adr_remark, adr_projno, adr_costctr, adr_fginved, adr_fgfixad, adr_fgimggot, adr_fgurlgot, adr_fginvself, adr_fgact, ");
            sb.Append(@"im_mfrno, im_nm, im_jbti, im_zip, im_addr, im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri, cont_signdate ");
            sb.Append(@"FROM c4_adr INNER JOIN c4_cont ON adr_contno = cont_contno LEFT OUTER JOIN invmfr ON adr_syscd = im_syscd AND adr_contno = im_contno AND adr_imseq = im_imseq WHERE (1=1) ");

            if (cont_contno.ToString() != "")
            {
                sb.Append(@" AND (adr_contno=@cont_contno) ");
            }

            if (tbxSDate.ToString() != "" && tbxEDate.ToString() != "")
            {
                sb.Append(@" AND (@tbxSDate<=cont_signdate AND cont_signdate<=@tbxEDate) ");
            }
            else if (tbxSDate.ToString() != "")
            {
                sb.Append(@" AND (@tbxSDate<=cont_signdate) ");
            }
            else if (tbxEDate.ToString() != "")
            {
                sb.Append(@" AND (cont_signdate<=@tbxEDate) ");
            }

            if (cont_empno.ToString() != "")
            {
                sb.Append(@" AND cont_empno=@cont_empno ");
            }

            if (mfr_inm.ToString() != "")
            {
                sb.Append(@" AND mfr_inm LIKE '%'+@mfr_inm+'%' ");
            }

            if (cont_fgclosed.ToString() != "")
            {
                sb.Append(@" AND cont_fgclosed=@cont_fgclosed ");
            }

            if (cont_fgcancel.ToString() != "")
            {
                sb.Append(@" AND cont_fgcancel=@cont_fgcancel ");
            }
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@cont_contno", cont_contno);
            oCmd.Parameters.AddWithValue("@tbxSDate", tbxSDate);
            oCmd.Parameters.AddWithValue("@tbxEDate", tbxEDate);
            oCmd.Parameters.AddWithValue("@cont_empno", cont_empno);
            oCmd.Parameters.AddWithValue("@mfr_inm", mfr_inm);
            oCmd.Parameters.AddWithValue("@cont_fgclosed", cont_fgclosed);
            oCmd.Parameters.AddWithValue("@cont_fgcancel", cont_fgcancel);
            oda.Fill(ds);
            return ds;
        }


    }
}
