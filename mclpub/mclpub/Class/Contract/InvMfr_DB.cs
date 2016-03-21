using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace mclpub
{
    public class InvMfr_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet GetSingleContractByContNo(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c4_cont.cont_syscd, c4_cont.cont_contno, c4_cont.cont_conttp, ");
            sb.Append(@"c4_cont.cont_signdate, c4_cont.cont_sdate, c4_cont.cont_edate, ");
            sb.Append(@"c4_cont.cont_empno, c4_cont.cont_mfrno, c4_cont.cont_custno, ");
            sb.Append(@"c4_cont.cont_aunm, c4_cont.cont_autel, c4_cont.cont_aufax, ");
            sb.Append(@"c4_cont.cont_aucell, c4_cont.cont_auemail, c4_cont.cont_freetm, ");
            sb.Append(@"c4_cont.cont_resttm, c4_cont.cont_pubtm, c4_cont.cont_totimgtm, ");
            sb.Append(@"c4_cont.cont_toturltm, c4_cont.cont_disc, c4_cont.cont_totamt, ");
            sb.Append(@"c4_cont.cont_paidamt, c4_cont.cont_restamt, c4_cont.cont_ccont, ");
            sb.Append(@"c4_cont.cont_csdate, c4_cont.cont_pdcont, c4_cont.cont_remark, ");
            sb.Append(@"c4_cont.cont_credate, c4_cont.cont_moddate, ");
            sb.Append(@"c4_cont.cont_modempno, c4_cont.cont_fgpayonce, ");
            sb.Append(@"c4_cont.cont_fgtemp, c4_cont.cont_fgpubed, ");
            sb.Append(@"c4_cont.cont_fgclosed, c4_cont.cont_fgcancel, cust.cust_custno,cont_oldcontno, ");
            sb.Append(@"cust.cust_nm, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_tel, mfr.mfr_fax, ");
            sb.Append(@"mfr.mfr_respnm, mfr.mfr_respjbti ");
            sb.Append(@"FROM c4_cont INNER JOIN ");
            sb.Append(@"cust ON c4_cont.cont_custno = cust.cust_custno INNER JOIN ");
            sb.Append(@"mfr ON cust.cust_mfrno = mfr.mfr_mfrno AND c4_cont.cont_mfrno = mfr.mfr_mfrno ");
            sb.Append(@"WHERE c4_cont.cont_contno=@contno ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@contno", contno);
            oda.Fill(ds);
            return ds;
        }


        public DataSet GetInvMfr(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select invmfr.*, proj.proj_projno, invcd = CASE im_invcd ");
            sb.Append(@"WHEN '2' THEN '二聯' WHEN '3' THEN '三聯' ELSE '其他' END, taxtp = CASE im_taxtp WHEN '1' THEN '應稅5%' WHEN '2' THEN '零稅' ELSE '免稅' END,");
            sb.Append(@"imfgitri= CASE im_fgitri WHEN '06' THEN '所內' WHEN '07' THEN '院內' ELSE '一般' END");
            sb.Append(@" FROM invmfr INNER JOIN proj ON invmfr.im_syscd = proj.proj_syscd AND invmfr.im_fgitri = proj.proj_fgitri WHERE im_syscd='C4' AND im_contno=@contno ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            DataSet ds = new DataSet();
            oCmd.Parameters.AddWithValue("@contno", contno);
            oda.Fill(ds);
            return ds;
        }

        public string AddInvMfr(string im_contno, string im_mfrno, string im_nm, string im_jbti, string im_addr, string im_zip, string im_tel, string im_fax, string im_cell, string im_email, string im_invcd, string im_taxtp, string im_fgitri)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            try
            {
                //StringBuilder sb = new StringBuilder();
                oCmd.CommandText = "sp_c4_add_im";
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter oda = new SqlDataAdapter(oCmd);
                oCmd.Parameters.AddWithValue("@im_contno", im_contno);
                oCmd.Parameters.AddWithValue("@im_mfrno", im_mfrno);
                oCmd.Parameters.AddWithValue("@im_nm", im_nm);
                oCmd.Parameters.AddWithValue("@im_jbti", im_jbti);
                oCmd.Parameters.AddWithValue("@im_addr", im_addr);
                oCmd.Parameters.AddWithValue("@im_zip", im_zip);
                oCmd.Parameters.AddWithValue("@im_tel", im_tel);
                oCmd.Parameters.AddWithValue("@im_fax", im_fax);
                oCmd.Parameters.AddWithValue("@im_cell", im_cell);
                oCmd.Parameters.AddWithValue("@im_email", im_email);
                oCmd.Parameters.AddWithValue("@im_invcd", im_invcd);
                oCmd.Parameters.AddWithValue("@im_taxtp", im_taxtp);
                oCmd.Parameters.AddWithValue("@im_fgitri", im_fgitri);

                SqlParameter retValParam = oCmd.Parameters.Add("@ret_imseq", SqlDbType.Char, 2);
                retValParam.Direction = ParameterDirection.Output;
                oCmd.Connection.Open();
                oCmd.ExecuteNonQuery();
                oCmd.Connection.Close();


                return Convert.ToString(retValParam.Value);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oCmd.Connection.Close();
            }
        }


        public bool DeleteIm(string im_contno, string im_imseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            //StringBuilder sb = new StringBuilder();
            oCmd.CommandText = "sp_c4_delete_1_im";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@im_contno", im_contno);
            oCmd.Parameters.AddWithValue("@im_imseq", im_imseq);

            SqlParameter retValParam = oCmd.Parameters.Add("@effects", SqlDbType.Int);
            retValParam.Direction = ParameterDirection.Output;
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

            if (Convert.ToInt32(retValParam.Value) > 0)
            {
                return false;
            }
            return true;

        }


        public void UpdateInvMfr(string im_contno, string im_imseq, string im_mfrno, string im_nm, string im_jbti, string im_addr, string im_zip, string im_tel, string im_fax, string im_cell, string im_email, string im_invcd, string im_taxtp, string im_fgitri)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            //StringBuilder sb = new StringBuilder();
            oCmd.CommandText = "sp_c4_update_im";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@im_contno", im_contno);
            oCmd.Parameters.AddWithValue("@im_imseq", im_imseq);
            oCmd.Parameters.AddWithValue("@im_mfrno", im_mfrno);
            oCmd.Parameters.AddWithValue("@im_nm", im_nm);
            oCmd.Parameters.AddWithValue("@im_jbti", im_jbti);
            oCmd.Parameters.AddWithValue("@im_addr", im_addr);
            oCmd.Parameters.AddWithValue("@im_zip", im_zip);
            oCmd.Parameters.AddWithValue("@im_tel", im_tel);
            oCmd.Parameters.AddWithValue("@im_fax", im_fax);
            oCmd.Parameters.AddWithValue("@im_cell", im_cell);
            oCmd.Parameters.AddWithValue("@im_email", im_email);
            oCmd.Parameters.AddWithValue("@im_invcd", im_invcd);
            oCmd.Parameters.AddWithValue("@im_taxtp", im_taxtp);
            oCmd.Parameters.AddWithValue("@im_fgitri", im_fgitri);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }
    }
}
