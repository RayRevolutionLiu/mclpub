using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Collections;

namespace mclpub
{
    public class AdrPublish_DB
    {
        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"];

        public DataSet GetSingleContractByContNo(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT c4_cont.cont_syscd, c4_cont.cont_contno, c4_cont.cont_conttp, c4_cont.cont_signdate, c4_cont.cont_sdate, c4_cont.cont_edate, c4_cont.cont_empno, c4_cont.cont_mfrno, c4_cont.cont_custno, c4_cont.cont_aunm, c4_cont.cont_autel, c4_cont.cont_aufax, c4_cont.cont_aucell, c4_cont.cont_auemail, c4_cont.cont_freetm, c4_cont.cont_resttm, c4_cont.cont_pubtm, c4_cont.cont_totimgtm, c4_cont.cont_toturltm, c4_cont.cont_disc, c4_cont.cont_totamt, c4_cont.cont_paidamt, c4_cont.cont_restamt, c4_cont.cont_ccont, c4_cont.cont_csdate, c4_cont.cont_pdcont, c4_cont.cont_remark, c4_cont.cont_credate, c4_cont.cont_moddate, c4_cont.cont_modempno, c4_cont.cont_oldcontno, c4_cont.cont_fgpayonce, c4_cont.cont_fgtemp, c4_cont.cont_fgpubed, c4_cont.cont_fgclosed, c4_cont.cont_fgcancel, cust.cust_custno, cust.cust_nm, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_tel, mfr.mfr_fax, mfr.mfr_respnm, mfr.mfr_respjbti FROM c4_cont LEFT OUTER JOIN cust ON c4_cont.cont_custno = cust.cust_custno LEFT OUTER JOIN mfr ON cust.cust_mfrno = mfr.mfr_mfrno AND c4_cont.cont_mfrno = mfr.mfr_mfrno WHERE c4_cont.cont_contno=@contno");
            //sb.Append(@"");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            //oCmd.Parameters.AddWithValue("@lp_ltpcd", lp_ltpcd);
            //oCmd.Parameters.AddWithValue("@lp_clrcd", lp_clrcd);
            //oCmd.Parameters.AddWithValue("@lp_pgscd", lp_pgscd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public DataSet GetAdrCounts(string adr_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            DataSet ds = new DataSet();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"sp_c4_get_adr_counts");
                oCmd.CommandText = sb.ToString();
                oCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter oda = new SqlDataAdapter(oCmd);
                oCmd.Parameters.AddWithValue("@adr_contno", adr_contno);
                //oCmd.Parameters.AddWithValue("@lp_ltpcd", lp_ltpcd);
                //oCmd.Parameters.AddWithValue("@lp_clrcd", lp_clrcd);
                //oCmd.Parameters.AddWithValue("@lp_pgscd", lp_pgscd);

                //OUTPUT Parameters
                SqlParameter param_pubedtm = new SqlParameter("@imgtm", SqlDbType.Int);
                param_pubedtm.Direction = ParameterDirection.Output;
                oCmd.Parameters.Add(param_pubedtm);

                SqlParameter param_paidamt = new SqlParameter("@urltm", SqlDbType.Int);
                param_paidamt.Direction = ParameterDirection.Output;
                oCmd.Parameters.Add(param_paidamt);
                oda.Fill(ds);
                return ds;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oCmd.Connection.Close();
                ds = null;
            }
        }


        public DataSet GetInvMfr(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select invmfr.*, proj.proj_projno, invcd = CASE im_invcd WHEN '2' THEN '二聯' WHEN '3' THEN '三聯' ELSE '其他' END, taxtp = CASE im_taxtp WHEN '1' THEN '應稅5%' WHEN '2' THEN '零稅' ELSE '免稅' END FROM invmfr INNER JOIN proj ON invmfr.im_syscd = proj.proj_syscd AND invmfr.im_fgitri = proj.proj_fgitri WHERE im_syscd='C4' AND im_contno=@contno");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            //oCmd.Parameters.AddWithValue("@lp_ltpcd", lp_ltpcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public DataSet GetAdvertisements(string contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT adr_syscd, adr_contno, adr_seq, adr_addate, adr_adcate, adr_keyword, adr_alttext, adr_imgurl, adr_impr, adr_navurl, adr_drafttp, adr_urltp, adr_imseq, adr_invamt, adr_adamt, adr_desamt, adr_chgamt, adr_remark, adr_projno, adr_costctr, adr_fginved, adr_fgfixad, adr_fgimggot, adr_fgurlgot, adr_fginvself, adr_fgact FROM c4_adr WHERE adr_syscd='C4' AND adr_contno=@contno ORDER BY adr_addate");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            //oCmd.Parameters.AddWithValue("@lp_ltpcd", lp_ltpcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public DataSet GetAdrAmounts(string adr_contno)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"sp_c4_get_adr_amounts");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@adr_contno", adr_contno);
            //oCmd.Parameters.AddWithValue("@lp_ltpcd", lp_ltpcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public DataSet CheckAdrSlot(string adcate, string keyword, string sdate, string edate, int impr, int impr_old)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"sp_c4_check_adr_slot");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@adcate", adcate);
            oCmd.Parameters.AddWithValue("@keyword", keyword);
            oCmd.Parameters.AddWithValue("@sdate", sdate);
            oCmd.Parameters.AddWithValue("@edate", edate);
            oCmd.Parameters.AddWithValue("@impr", impr);
            oCmd.Parameters.AddWithValue("@impr_old", impr_old);
            //oCmd.Parameters.AddWithValue("@lp_ltpcd", lp_ltpcd);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }

        public DataSet GetSingleIm(string contno, string im_imseq)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri, im_syscd FROM invmfr WHERE im_syscd='C4' AND im_contno=@contno AND im_imseq=@im_imseq ");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@contno", contno);
            oCmd.Parameters.AddWithValue("@im_imseq", im_imseq);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            return ds;
        }


        public void AddAdr(string adr_contno, string adr_sdate, string adr_edate, string adr_adcate, string adr_keyword, string adr_alttext, string adr_imgurl, string adr_navurl, int adr_impr, string adr_drafttp, string adr_urltp, string adr_imseq, int adr_adamt, int adr_desamt, int adr_chgamt, string adr_remark, string adr_fgfixad, string fgitri, string fgimggot, string fgurlgot)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"sp_c4_add_adr";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@adr_contno", adr_contno);
            oCmd.Parameters.AddWithValue("@adr_sdate", adr_sdate);
            oCmd.Parameters.AddWithValue("@adr_edate", adr_edate);
            oCmd.Parameters.AddWithValue("@adr_adcate", adr_adcate);
            oCmd.Parameters.AddWithValue("@adr_keyword", adr_keyword);
            oCmd.Parameters.AddWithValue("@adr_alttext", adr_alttext);
            oCmd.Parameters.AddWithValue("@adr_imgurl", adr_imgurl);
            oCmd.Parameters.AddWithValue("@adr_navurl", adr_navurl);
            oCmd.Parameters.AddWithValue("@adr_impr", adr_impr);
            oCmd.Parameters.AddWithValue("@adr_drafttp", adr_drafttp);
            oCmd.Parameters.AddWithValue("@adr_urltp", adr_urltp);
            oCmd.Parameters.AddWithValue("@adr_imseq", adr_imseq);
            oCmd.Parameters.AddWithValue("@adr_adamt", adr_adamt);
            oCmd.Parameters.AddWithValue("@adr_desamt", adr_desamt);
            oCmd.Parameters.AddWithValue("@adr_chgamt", adr_chgamt);
            oCmd.Parameters.AddWithValue("@adr_remark", adr_remark);
            oCmd.Parameters.AddWithValue("@adr_fgfixad", adr_fgfixad);
            oCmd.Parameters.AddWithValue("@fgitri", fgitri);
            oCmd.Parameters.AddWithValue("@adr_fgimggot", fgimggot);
            oCmd.Parameters.AddWithValue("@adr_fgurlgot", fgurlgot);
            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();
        }


        public bool CheckXmlFileLog(string xmldate)
        {
            bool flag = false;
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT xml_date, xml_fgexist FROM c4_xmlfilelog WHERE xml_date=@xmldate");
            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@xmldate", xmldate);
            DataSet ds = new DataSet();
            oda.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["xml_fgexist"].ToString() == "1")
                {
                    flag = true;
                }
            }
            else
            {
                flag = false;
            }
            return flag;

        }

        public void DeleteAdr(string adr_contno, ArrayList ary)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandType = CommandType.Text;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@adr_contno", adr_contno);
            string str = "";
            try
            {
                for (int i = 0; i < ary.Count; i++)
                {
                    string str2 = (string)ary[i];
                    string str3 = "";
                    string str4 = "";
                    string str5 = "";
                    string str6 = "";
                    string str7 = "";

                    try
                    {
                        str3 = (string)str2.Split(new char[] { ',' }).GetValue(0);
                        str4 = (string)str2.Split(new char[] { ',' }).GetValue(1);
                        str5 = (string)str2.Split(new char[] { ',' }).GetValue(2);
                        str6 = (string)str2.Split(new char[] { ',' }).GetValue(3);
                        str7 = (string)str2.Split(new char[] { ',' }).GetValue(4);
                    }
                    catch (Exception)
                    {
                        throw new Exception("無法取得落版序號、廣告日期、廣告頁面、廣告位置、播出機率等資料");
                    }
                    if (((str3 == "") || (str4 == "")) || (((str5 == "") || (str6 == "")) || (str7 == "")))
                    {
                        throw new Exception("原生落版序號、廣告日期、廣告頁面、廣告位置、播出機率等資料錯誤");
                    }

                    oCmd.Parameters.AddWithValue("@str3", str3);
                    oCmd.Parameters.AddWithValue("@str4", str4);
                    oCmd.Parameters.AddWithValue("@str5", str5);
                    oCmd.Connection.Open();
                    oCmd.CommandText = @"DELETE FROM c4_adr WHERE adr_syscd='C4' AND adr_contno=@adr_contno AND adr_seq=@str3 AND adr_addate=@str4";
                    oCmd.ExecuteNonQuery();
                    oCmd.CommandText = @"UPDATE c4_adcnt SET cnt_" + str6 + "=cnt_" + str6 + "-" + str7 + " WHERE cnt_date=@str4 AND cnt_adcate=@str5 ";
                    oCmd.ExecuteNonQuery();
                    oCmd.CommandText = @"UPDATE c4_cont SET cont_resttm=cont_resttm+1 WHERE cont_contno=@adr_contno";
                    oCmd.ExecuteNonQuery();
                    oCmd.Parameters.RemoveAt("@str3");
                    oCmd.Parameters.RemoveAt("@str4");
                    oCmd.Parameters.RemoveAt("@str5");
                    oCmd.Connection.Close();
                }
            }
            catch (Exception exception2)
            {
                throw new Exception("刪除落版失敗，原因：" + exception2.Message);
            }

        }


        public int UpdateAdrLite1(string adr_contno, string adr_seq, string adr_addate, string adr_adcate, string adr_keyword, string adr_alttext, string adr_navurl, int adr_impr, string adr_imseq, int adr_adamt, int adr_desamt, int adr_chgamt, string adr_remark)
        {
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            oCmd.CommandText = @"sp_c4_update_adr_lite_1";
            oCmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);
            oCmd.Parameters.AddWithValue("@adr_contno", adr_contno);
            oCmd.Parameters.AddWithValue("@adr_seq", adr_seq);
            oCmd.Parameters.AddWithValue("@adr_addate", adr_addate);
            oCmd.Parameters.AddWithValue("@adr_adcate", adr_adcate);
            oCmd.Parameters.AddWithValue("@adr_keyword", adr_keyword);
            oCmd.Parameters.AddWithValue("@adr_alttext", adr_alttext);
            oCmd.Parameters.AddWithValue("@adr_navurl", adr_navurl);
            oCmd.Parameters.AddWithValue("@adr_impr", adr_impr);
            oCmd.Parameters.AddWithValue("@adr_imseq", adr_imseq);
            oCmd.Parameters.AddWithValue("@adr_adamt", adr_adamt);
            oCmd.Parameters.AddWithValue("@adr_desamt", adr_desamt);
            oCmd.Parameters.AddWithValue("@adr_chgamt", adr_chgamt);
            oCmd.Parameters.AddWithValue("@adr_remark", adr_remark);
            string str2 = "0";
            if (adr_impr == 20)
            {
                str2 = "1";
            }
            oCmd.Parameters.AddWithValue("@adr_fgfixad", str2);
            SqlParameter retValParam = oCmd.Parameters.Add("@errorcode", SqlDbType.Int);
            retValParam.Direction = ParameterDirection.Output;

            oCmd.Connection.Open();
            oCmd.ExecuteNonQuery();
            oCmd.Connection.Close();

            return Convert.ToInt32(retValParam.Value);

        }

    }
}