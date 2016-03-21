using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace mclpub.Contract
{
    public partial class ContMaintain : System.Web.UI.Page
    {
        ContMaintain_DB myCont = new ContMaintain_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                postbackBtn.Attributes.Add("style", "display:none");
                Bind_ddlEmpData();

                string contno = "";
                if (Request.QueryString["contno"] == null || Request.QueryString["contno"] == "")
                {
                    throw new Exception("找不到合約編號");
                }
                else
                {
                    contno = Request.QueryString["contno"];
                }
                if (LoadCont(contno))
                {
                    ShowAtpMatp();
                    ShowFreeBook();
                    ShowInvMfr();
                }
                else
                {
                    Response.Redirect("ContQueryMaintain.aspx");
                }
            }
        }


        #region 連結員工資料
        private void Bind_ddlEmpData()
        {
            DataSet ds = myCont.SelectSrspn();

            this.ddlEmpData.DataTextField = "srspn_cname";
            this.ddlEmpData.DataValueField = "srspn_empno";
            this.ddlEmpData.DataSource = ds;
            this.ddlEmpData.DataBind();

            ddlEmpData.SelectedIndex = -1;
            if (ddlEmpData.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()) != null)
                ddlEmpData.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()).Selected = true;
            else
                ddlEmpData.SelectedIndex = 0;
        }
        #endregion

        #region 載入合約資料
        private bool LoadCont(string contno)
        {
            if (contno.Trim() == "")
            {
                throw new Exception("合約編號不可為空白");
            }

            InterPlaneCont_DB myInter = new InterPlaneCont_DB();
            DataTable dt = myInter.GetSingleContractByContNo(contno);

            bool fgtemp = false;

            if (dt.Rows.Count>0)
            {
                //廠商及客戶資料
                lblCustNm.Text = dt.Rows[0]["cust_nm"].ToString().Trim();
                lblCustNo.Text = dt.Rows[0]["cont_custno"].ToString().Trim();
                lblMfrNm.Text = dt.Rows[0]["mfr_inm"].ToString().Trim();
                lblMfrNo.Text = dt.Rows[0]["cont_mfrno"].ToString().Trim();
                lblMfrTelFax.Text = dt.Rows[0]["mfr_tel"].ToString() + "(Fax：" + dt.Rows[0]["mfr_fax"].ToString().Trim() + ")";
                lblRespData.Text = dt.Rows[0]["mfr_respnm"].ToString() + "(" + dt.Rows[0]["mfr_respjbti"].ToString().Trim() + ")";

                //合約書基本資料
                tbxSignDate.Text = DateTime.ParseExact(dt.Rows[0]["cont_signdate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");

                ddlContTp.SelectedIndex = -1;
                if (ddlContTp.Items.FindByValue(dt.Rows[0]["cont_conttp"].ToString()) != null)
                {
                    ddlContTp.Items.FindByValue(dt.Rows[0]["cont_conttp"].ToString()).Selected = true;
                }
                else
                {
                    ddlContTp.SelectedIndex = 0;
                }

                tbxSDate.Text = DateTime.ParseExact(dt.Rows[0]["cont_sdate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
                tbxEDate.Text = DateTime.ParseExact(dt.Rows[0]["cont_edate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
                tbxRemark.Text = dt.Rows[0]["cont_remark"].ToString().Trim();
                lblContNo.Text = contno;

                ddlEmpData.SelectedIndex = -1;
                if (ddlEmpData.Items.FindByValue(dt.Rows[0]["cont_empno"].ToString().Trim()) != null)
                {
                    ddlEmpData.Items.FindByValue(dt.Rows[0]["cont_empno"].ToString().Trim()).Selected = true;
                }
                else
                {
                    ddlEmpData.SelectedIndex = 0;
                }

                rblPayOnce.SelectedIndex = -1;
                if (rblPayOnce.Items.FindByValue(dt.Rows[0]["cont_fgpayonce"].ToString()) != null)
                {
                    rblPayOnce.Items.FindByValue(dt.Rows[0]["cont_fgpayonce"].ToString()).Selected = true;
                }
                else
                {
                    rblPayOnce.SelectedIndex = 0;
                }

                rblClosed.SelectedIndex = -1;
                if (rblClosed.Items.FindByValue(dt.Rows[0]["cont_fgclosed"].ToString()) != null)
                {
                    rblClosed.Items.FindByValue(dt.Rows[0]["cont_fgclosed"].ToString()).Selected = true;
                }
                else
                {
                    rblClosed.SelectedIndex = 0;
                }

                //合約書細節
                tbxPubTm.Text = dt.Rows[0]["cont_pubtm"].ToString();
                tbxFreeTm.Text = dt.Rows[0]["cont_freetm"].ToString();
                tbxTotImgTm.Text = dt.Rows[0]["cont_totimgtm"].ToString();
                tbxTotUrlTm.Text = dt.Rows[0]["cont_toturltm"].ToString();
                tbxTotAmt.Text = dt.Rows[0]["cont_totamt"].ToString();
                tbxDisc.Text = dt.Rows[0]["cont_disc"].ToString();

                //廣告聯絡人資料
                tbxAuNm.Text = dt.Rows[0]["cont_aunm"].ToString().Trim();
                tbxAuEmail.Text = dt.Rows[0]["cont_auemail"].ToString().Trim();
                tbxAuTel.Text = dt.Rows[0]["cont_autel"].ToString().Trim();
                tbxAuCell.Text = dt.Rows[0]["cont_aucell"].ToString().Trim();
                tbxAuFax.Text = dt.Rows[0]["cont_aufax"].ToString().Trim();

                //合約是否是tmp
                if (dt.Rows[0]["cont_fgtemp"].ToString() == "1")
                {
                    fgtemp = true;
                }
                //Response.Write("tempflag=" + dr["cont_fgtemp"].ToString());

                //產品設備內文、廣告推廣內文、搜尋期限
                string cont_ccont = dt.Rows[0]["cont_ccont"].ToString().Trim();
                string cont_pdcont = dt.Rows[0]["cont_pdcont"].ToString().Trim();
                string cont_csdate = "";
                try
                {
                    cont_csdate = DateTime.ParseExact(dt.Rows[0]["cont_csdate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
                }
                catch (Exception ex)
                {
                    cont_csdate = "";
                }

                tbxCCont.Text = cont_ccont;
                tbxPdCont.Text = cont_pdcont;
                tbxCsDate.Text = cont_csdate;
            }
            else
            {
                JavaScript.AlertMessage(this.Page, "找不到合約" + contno + "的資料，請通知聯絡人");
                return false;
            }

            //暫存合約要可以maintain嗎？不行-_-
            if (fgtemp)
            {
                Response.Redirect("ContQueryMaintain.aspx");
            }
            return true;
        }
        #endregion

        #region Show應用產業及材料特性
        private void ShowAtpMatp()
        {
            string contno = lblContNo.Text.Trim();
            DataSet ds1 = myCont.GetAtpMtps_Display(contno, "1");
            DataView dv1 = ds1.Tables[0].DefaultView;
            if (dv1.Count > 0)
            {
                DataTable dt = new DataTable();
                DataColumn c1 = new DataColumn("cls2_cname", typeof(System.String));
                dt.Columns.Add(c1);
                DataColumn c2 = new DataColumn("cls3_cname", typeof(System.String));
                dt.Columns.Add(c2);
                DataRow dr;

                string strcls2, strcls3;
                strcls2 = strcls3 = "";
                for (int idx = 0; idx < dv1.Count; idx++)
                {
                    if (dv1[idx].Row["cls2_cname"].ToString() != strcls2)
                    {
                        if (idx > 0)
                        {
                            dr = dt.NewRow();
                            dr["cls2_cname"] = strcls2;
                            dr["cls3_cname"] = strcls3;
                            dt.Rows.Add(dr);
                        }
                        strcls2 = dv1[idx].Row["cls2_cname"].ToString();
                        strcls3 = dv1[idx].Row["cls3_cname"].ToString();
                    }
                    else
                    {
                        strcls3 = strcls3 + ";" + dv1[idx].Row["cls3_cname"].ToString();
                    }
                }
                //最後一次
                dr = dt.NewRow();
                dr["cls2_cname"] = strcls2;
                dr["cls3_cname"] = strcls3;
                dt.Rows.Add(dr);
                dgdAtpMatp1.DataSource = dt;
                dgdAtpMatp1.DataBind();
            }
            else
            {
                dgdAtpMatp1.DataSource = dv1;
                dgdAtpMatp1.DataBind();
            }


            DataSet ds2 = myCont.GetAtpMtps_Display(contno, "2");
            DataView dv2 = ds2.Tables[0].DefaultView;

            if (dv2.Count > 0)
            {
                DataTable dt = new DataTable();
                DataColumn c1 = new DataColumn("cls2_cname", typeof(System.String));
                dt.Columns.Add(c1);
                DataColumn c2 = new DataColumn("cls3_cname", typeof(System.String));
                dt.Columns.Add(c2);
                DataRow dr;

                string strcls2, strcls3;
                strcls2 = strcls3 = "";
                for (int idx = 0; idx < dv2.Count; idx++)
                {
                    if (dv2[idx].Row["cls2_cname"].ToString() != strcls2)
                    {
                        if (idx > 0)
                        {
                            dr = dt.NewRow();
                            dr["cls2_cname"] = strcls2;
                            dr["cls3_cname"] = strcls3;
                            dt.Rows.Add(dr);
                        }
                        strcls2 = dv2[idx].Row["cls2_cname"].ToString();
                        strcls3 = dv2[idx].Row["cls3_cname"].ToString();
                    }
                    else
                    {
                        strcls3 = strcls3 + ";" + dv2[idx].Row["cls3_cname"].ToString();
                    }
                }
                //最後一次
                dr = dt.NewRow();
                dr["cls2_cname"] = strcls2;
                dr["cls3_cname"] = strcls3;
                dt.Rows.Add(dr);
                dgdAtpMatp2.DataSource = dt;
                dgdAtpMatp2.DataBind();
            }
            else
            {
                dgdAtpMatp2.DataSource = dv2;
                dgdAtpMatp2.DataBind();
            }

        }
        #endregion

        #region Show雜誌收件人及贈書資料
        private void ShowFreeBook()
        {
            string contno = lblContNo.Text.Trim();
            DataSet ds1 = myCont.GetOrByContNo(contno);
            DataView dv1 = ds1.Tables[0].DefaultView;
            dgdNewOr.DataSource = dv1;
            dgdNewOr.DataBind();
            if (dv1.Count > 0)
            {
                dgdNewOr.Visible = true;
            }
            else
            {
                dgdNewOr.Visible = false;
            }

            DataSet ds2 = myCont.GetFbkOrByContNo(contno);
            DataView dv2 = ds2.Tables[0].DefaultView;
            dgdNewFreeBk.DataSource = dv2;
            dgdNewFreeBk.DataBind();
            if (dv2.Count > 0)
            {
                dgdNewFreeBk.Visible = true;
            }
            else
            {
                dgdNewFreeBk.Visible = false;
            }

        }
        #endregion

        #region Show發票廠商資料
        private void ShowInvMfr()
        {
            string contno = lblContNo.Text.Trim();
            DataSet ds = myCont.GetInvMfr(contno);
            DataView dv = ds.Tables[0].DefaultView;
            dgdNewInvMfr.DataSource = dv;
            dgdNewInvMfr.DataBind();
            if (dv.Count > 0)
            {
                dgdNewInvMfr.Visible = true;

            }
            else
            {
                dgdNewInvMfr.Visible = false;
            }

        }
        #endregion

        protected void btnCount_Click(object sender, EventArgs e)
        {
            DateTime sdate;
            DateTime edate;
            try
            {
                sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "合約起始日期格式錯誤，無法用來計算區間天數");
                return;
            }

            try
            {
                edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "合約結束日期格式錯誤，無法用來計算區間天數");
                return;
            }

            double pubdays = ((TimeSpan)edate.Subtract(sdate)).TotalDays + 1;

            tbxPubTm.Text = pubdays.ToString();		
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //取得欄位...
            string cont_contno = lblContNo.Text.Trim();

            int pubedtm = 0;
            float paidamt = 0;

            SqlDataReader dr = myCont.GetContCounts(cont_contno);
            if (dr.Read())
            {
                pubedtm = Convert.ToInt32(dr["pubedtm"]);
                paidamt = Convert.ToSingle(dr["paidamt"]);
            }
            else
            {
                throw new Exception("無法取得合約相關計算資料，資料存取錯誤");
            }
            dr.Close();


            string cont_conttp = ddlContTp.SelectedItem.Value;

            //日期部分
            DateTime signdate;
            DateTime sdate;
            DateTime edate;

            try
            {
                signdate = DateTime.ParseExact(tbxSignDate.Text.Trim(), "yyyy/MM/dd", null);
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "合約簽約日期錯誤，請更正");
                return;
            }

            try
            {
                sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "合約起始日期錯誤，請更正");
                return;
            }

            try
            {
                edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "合約結束日期錯誤，請更正");
                return;
            }

            if (sdate > edate)
            {
                JavaScript.AlertMessage(this.Page, "起始日期不可大於結束日期，請更正");
                return;
            }

            string cont_signdate = signdate.ToString("yyyyMMdd");
            string cont_sdate = sdate.ToString("yyyyMMdd");
            string cont_edate = edate.ToString("yyyyMMdd");


            string cont_empno = ddlEmpData.SelectedItem.Value.Trim();
            //			string cont_mfrno = tbxHidMfrNo.Text.Trim();
            //			string cont_custno = tbxHidCustNo.Text.Trim();
            string cont_aunm = tbxAuNm.Text.Trim();
            string cont_autel = tbxAuTel.Text.Trim();
            string cont_aufax = tbxAuFax.Text.Trim();
            string cont_aucell = tbxAuCell.Text.Trim();
            string cont_auemail = tbxAuEmail.Text.Trim();

            int cont_freetm = 0;
            try
            {
                cont_freetm = Convert.ToInt32(tbxFreeTm.Text.Trim());
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "贈送次數格式錯誤，應為整數");
                return;
            }

            int cont_pubtm = 0;
            try
            {
                cont_pubtm = Convert.ToInt32(tbxPubTm.Text.Trim());
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "刊登次數格式錯誤，應為整數");
                return;
            }

            int cont_resttm = cont_pubtm - pubedtm;	//總刊登次數 - 已刊登(落版)次數

            int cont_totimgtm = 0;
            try
            {
                cont_totimgtm = Convert.ToInt32(tbxTotImgTm.Text.Trim());
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "總製圖檔稿次數格式錯誤，應為整數");
                return;
            }

            int cont_toturltm = 0;
            try
            {
                cont_toturltm = Convert.ToInt32(tbxTotUrlTm.Text.Trim());
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "總製網頁稿次數格式錯誤，應為整數");
                return;
            }

            float cont_disc = 0;
            try
            {
                cont_disc = Convert.ToSingle(tbxDisc.Text.Trim());
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "優惠折數格式錯誤，應為整數");
                return;
            }

            float cont_totamt = 0;
            try
            {
                cont_totamt = Convert.ToSingle(tbxTotAmt.Text.Trim());
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "合約金額格式錯誤，應為整數");
                return;
            }

            float cont_paidamt = paidamt;				//已產生發票的金額總和
            float cont_restamt = cont_totamt - paidamt;	//合約總金額 - 已產生發票的金額總和
            string cont_remark = tbxRemark.Text.Trim();
            string cont_moddate = DateTime.Now.ToString("yyyyMMdd");
            string cont_modempno = Account.GetAccInfo().srspn_empno.ToString().Trim();
            string cont_fgpayonce = rblPayOnce.SelectedItem.Value;
            string cont_fgclosed = rblClosed.SelectedItem.Value;

            //產品設備內文、廣告推廣內文、搜尋期限
            string cont_ccont = tbxCCont.Text.Trim();
            string cont_pdcont = tbxPdCont.Text.Trim();
            string cont_csdate = "";
            if (tbxCsDate.Text.Trim() != "")
            {
                try
                {
                    cont_csdate = DateTime.ParseExact(tbxCsDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
                }
                catch (Exception ex)
                {
                    JavaScript.AlertMessage(this.Page, "[搜尋期限]<BR>無法轉換日期格式，請重新輸入合法的日期，如2003/01/01");
                    return;
                }
            }
            myCont.UpdateCont(cont_contno, cont_conttp, cont_signdate, cont_sdate, cont_edate, cont_empno,
                cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_freetm, cont_pubtm, cont_resttm,
                cont_totimgtm, cont_toturltm, cont_disc, cont_totamt, cont_paidamt, cont_restamt,
                cont_remark, cont_moddate, cont_modempno, cont_fgpayonce, cont_fgclosed, cont_ccont, cont_pdcont, cont_csdate);

            //檢查合約是否正式儲存成功？？
            JavaScript.AlertMessageRedirect(this.Page, "合約儲存成功", "InterPlaneCont.aspx");
        }

        protected void btnNoSave_Click(object sender, EventArgs e)
        {
            Response.Redirect("InterPlaneCont.aspx");
        }

        protected void btnFgCancel_Click(object sender, EventArgs e)
        {
            string contno = lblContNo.Text.Trim();
            myCont.UpdateContSetCancel(contno);

            JavaScript.AlertMessageRedirect(this.Page, "合約註銷成功，若要取消註銷，請由已註銷合約處理進行更動", "ContQueryFormal.aspx?custno=" + lblCustNo.Text.Trim() + "");
        }

        protected void postbackBtn_Click(object sender, EventArgs e)
        {
            ShowAtpMatp();
            ShowFreeBook();
            ShowInvMfr();
        }

    }
}
