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
    public class IAQuery_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet GetAdrForIA(string strdate)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c4_cont.cont_contno, c4_cont.cont_conttp, c4_cont.cont_sdate, c4_cont.cont_edate, c4_cont.cont_empno, srspn.srspn_cname,");
            sb.Append(@" c4_cont.cont_mfrno, mfr_2.mfr_inm AS cont_mfr_inm, c4_cont.cont_custno, c4_adr.adr_seq, c4_adr.adr_addate, c4_adr.adr_adcate, c4_adr.adr_keyword,");
            sb.Append(@" c4_adr.adr_alttext, c4_adr.adr_imgurl, c4_adr.adr_impr, c4_adr.adr_navurl, c4_adr.adr_drafttp, c4_adr.adr_urltp, c4_adr.adr_imseq, invmfr.im_mfrno, mfr_1.mfr_inm");
            sb.Append(@" AS im_mfr_inm, invmfr.im_nm, c4_adr.adr_invamt, c4_adr.adr_adamt, c4_adr.adr_desamt, c4_adr.adr_chgamt, c4_adr.adr_remark, invmfr.im_fgitri, proj.proj_projno,");
            sb.Append(@" proj.proj_costctr, c4_adr.adr_fginved FROM c4_cont INNER JOIN c4_adr ON c4_cont.cont_syscd = c4_adr.adr_syscd AND c4_cont.cont_contno = c4_adr.adr_contno");
            sb.Append(@" INNER JOIN invmfr INNER JOIN proj ON invmfr.im_syscd = proj.proj_syscd AND invmfr.im_fgitri = proj.proj_fgitri ON c4_adr.adr_syscd = invmfr.im_syscd AND");
            sb.Append(@" c4_adr.adr_contno = invmfr.im_contno AND c4_adr.adr_imseq = invmfr.im_imseq LEFT OUTER JOIN srspn ON c4_cont.cont_empno = srspn.srspn_empno");
            sb.Append(@" LEFT OUTER JOIN mfr mfr_1 ON invmfr.im_mfrno = mfr_1.mfr_mfrno LEFT OUTER JOIN mfr mfr_2 ON c4_cont.cont_mfrno = mfr_2.mfr_mfrno WHERE cont_syscd='C4'");
            sb.Append(@" AND c4_cont.cont_conttp='01' AND c4_cont.cont_fgcancel='0' AND c4_cont.cont_fgtemp='0' AND c4_cont.cont_fgclosed='0' AND (c4_adr.adr_addate <= @strdate)");
            sb.Append(@" AND c4_adr.adr_fginved<>'1' AND c4_adr.adr_invamt>0 ORDER BY  c4_cont.cont_empno, c4_cont.cont_contno, invmfr.im_mfrno, c4_adr.adr_addate ");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@strdate", strdate);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public void ClearAdrFginved()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"UPDATE c4_adr SET adr_fginved='' WHERE adr_fginved='v'");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }

        public void UpdateAdrFginved(string adr_contno, string adr_seq, string adr_addate, string adr_fginved)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"UPDATE c4_adr SET adr_fginved=@adr_fginved WHERE adr_contno=@adr_contno and adr_seq=@adr_seq and adr_addate=@adr_addate");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@adr_contno", adr_contno);
            oCmd.Parameters.AddWithValue("@adr_seq", adr_seq);
            oCmd.Parameters.AddWithValue("@adr_addate", adr_addate);
            oCmd.Parameters.AddWithValue("@adr_fginved", adr_fginved);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }



        public void IAPreList()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"sp_c4_ia_batch_prelist");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public bool AddBatchIa(string createmen)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"sp_c4_add_ia_batch");
                oCmd.CommandText = sb.ToString();
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter oda = new SqlDataAdapter(oCmd);
                oCmd.Parameters.AddWithValue("@createmen", createmen);
                SqlParameter retValParam = oCmd.Parameters.Add("@effects", SqlDbType.Int);
                retValParam.Direction = ParameterDirection.Output;
                oCmd.Connection.Open();
                oCmd.ExecuteNonQuery();
                oCmd.Connection.Close();

                if (Convert.ToInt32(retValParam.Value) <= 0)
                {
                    return false;
                }

                return true;
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


        public DataSet Selectwk_c4_ia_prelist()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT * , proj.proj_projno FROM wk_c4_ia_prelist INNER JOIN ");
            sb.Append(@"proj ON wk_c4_ia_prelist.cont_syscd  COLLATE Chinese_Taiwan_Stroke_CI_AS = proj.proj_syscd ");
            sb.Append(@"AND wk_c4_ia_prelist.im_fgitri = proj.proj_fgitri ");
            sb.Append(@"ORDER BY  wk_c4_ia_prelist.cont_contno, wk_c4_ia_prelist.im_mfrno, wk_c4_ia_prelist.adr_addate");
            //sb.Append(@"");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@strdate", strdate);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }


        public DataSet GroupByContnoAndimseq()
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select COUNT(*) AS TotalCount FROM ");
            sb.Append(@"(select distinct cont_contno,adr_imseq from  ");
            sb.Append(@"wk_c4_ia_prelist INNER JOIN ");
            sb.Append(@"proj ON wk_c4_ia_prelist.cont_syscd  COLLATE Chinese_Taiwan_Stroke_CI_AS = proj.proj_syscd ");
            sb.Append(@"AND wk_c4_ia_prelist.im_fgitri = proj.proj_fgitri ");
            sb.Append(@") tableA ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            //oCmd.Parameters.AddWithValue("@strdate", strdate);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        //取得已轉SAP的發票總金額
        public DataSet GetSAPMoneysum_ia(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT SUM(ia.ia_pyat) AS sum_ia, ia_contno from ia ");
            sb.Append(@"WHERE (ia_syscd = 'C4') ");
            sb.Append(@"AND (SUBSTRING(ia_contno, 3, 6) = @contno )");
            sb.Append(@"AND (ia_status = '7') GROUP BY  ia_contno ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }

        //取得已轉SAP的發票總金額
        public DataSet GetSAPMoneysum_py(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT SUM(ia.ia_pyat) AS sum_py, ia_contno from ia ");
            sb.Append(@"WHERE (ia_syscd = 'C4') ");
            sb.Append(@"AND (SUBSTRING(ia_contno, 3, 6) = @contno )");
            sb.Append(@"AND (ia.ia_pyno <> '') GROUP BY  ia_contno ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            //oCmd.Parameters.AddWithValue("@whereST2", whereST2);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;

        }
    }
}