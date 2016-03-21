using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Contract
{
    public partial class ContNew : System.Web.UI.Page
    {
        ContNew_DB myCont = new ContNew_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                postbackBtn.Attributes.Add("style", "display:none");
                Bind_ddlEmpData();
                if (Request.QueryString["old_contno"] == null || Request.QueryString["old_contno"] == "")
                {
                    InitNewCont();
                }
                else
                {
                    LoadHistContData();
                }

                ShowAtpMatp();
                ShowFreeBook();
                ShowInvMfr();
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

        #region 初始化無參考的全新合約
        private void InitNewCont()
        {
            string cust_custno;
            if (Request.QueryString["CustNo"] == null || Request.QueryString["CustNo"] == "")
            {
                throw new Exception("新增全新合約時，客戶編號不可為空值");
            }
            else
            {
                cust_custno = Request.QueryString["CustNo"];
            }

            string new_contno = PreAddNewCont(); //去資料庫新增暫存合約，傳回新合約的合約編號

            DataSet ds= myCont.GetMfrCustByCustNo(cust_custno);

            if (ds.Tables[0].Rows.Count>0)
            {
                //廠商及客戶資料
                lblCustNm.Text = ds.Tables[0].Rows[0]["cust_nm"].ToString().Trim();
                lblCustNo.Text = cust_custno;
                tbxHidCustNo.Text = cust_custno;
                lblMfrNm.Text = ds.Tables[0].Rows[0]["mfr_inm"].ToString().Trim();
                lblMfrNo.Text = ds.Tables[0].Rows[0]["cust_mfrno"].ToString().Trim();
                tbxHidMfrNo.Text = ds.Tables[0].Rows[0]["cust_mfrno"].ToString().Trim();
                lblMfrTelFax.Text = ds.Tables[0].Rows[0]["mfr_tel"].ToString() + "(Fax：" + ds.Tables[0].Rows[0]["mfr_fax"].ToString().Trim() + ")";
                lblRespData.Text = ds.Tables[0].Rows[0]["mfr_respnm"].ToString() + "(" + ds.Tables[0].Rows[0]["mfr_respjbti"].ToString().Trim() + ")";

                //合約書基本資料
                tbxSignDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                ddlContTp.SelectedIndex = 0;
                tbxSDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                tbxEDate.Text = "";
                tbxRemark.Text = "";
                lblContNo.Text = new_contno;
                ddlContTp.SelectedIndex = 0;
                rblPayOnce.SelectedIndex = 1;

                //合約書細節
                tbxPubTm.Text = "0";
                tbxFreeTm.Text = "0";
                tbxTotImgTm.Text = "0";
                tbxTotUrlTm.Text = "0";
                tbxTotAmt.Text = "0";
                tbxDisc.Text = "1";

                //廣告聯絡人資料
                tbxAuNm.Text = "";
                tbxAuEmail.Text = "";
                tbxAuTel.Text = "";
                tbxAuCell.Text = "";
                tbxAuFax.Text = "";

                //廣告推廣內文、期限、產品設備內文、材料特性、應用產業等相關資料

                //發票廠商收件人資料

                //雜誌收件人及贈書資料
            }
            else
            {
                Application["ErrorMsg"] = "找不到客戶及廠商資料，請通知聯絡人";
                Response.Redirect("~/errorPage.aspx");
            }
        }
        #endregion

        #region 事先新增合約，設定合約屬性為暫存
        private string PreAddNewCont()
        {
            string cont_oldcontno = "";
            if (Request.QueryString["old_contno"] == null || Request.QueryString["old_contno"] == "")
            {
                JavaScript.AlertMessage(this.Page, "注意：本合約無歷史合約參考資料...");
            }
            else
            {
                cont_oldcontno = Request.QueryString["old_contno"];
            }

            string cont_empno = Account.GetAccInfo().srspn_empno.ToString().Trim();

            string new_contno = myCont.AddContract(cont_empno, cont_oldcontno);

            return new_contno;
        }
        #endregion

        #region 取回歷史合約資料
        private void LoadHistContData()
        {
            string old_contno;
            string new_contno = PreAddNewCont(); //去資料庫新增暫存合約，傳回新合約的合約編號

            if (Request.QueryString["old_contno"] == null || Request.QueryString["old_contno"] == "")
            {
                throw new Exception("歷史合約編號不可為空值");
            }
            else
            {
                old_contno = Request.QueryString["old_contno"];
                tbxOldContNo.Text = old_contno;
            }

            DataSet ds = myCont.GetSingleContractByContNo(old_contno);

            if (ds.Tables[0].Rows.Count>0)
            {
                //廠商及客戶資料
                lblCustNm.Text = ds.Tables[0].Rows[0]["cust_nm"].ToString().Trim();
                lblCustNo.Text = ds.Tables[0].Rows[0]["cont_custno"].ToString().Trim();
                tbxHidCustNo.Text = ds.Tables[0].Rows[0]["cont_custno"].ToString().Trim();
                lblMfrNm.Text = ds.Tables[0].Rows[0]["mfr_inm"].ToString().Trim();
                lblMfrNo.Text = ds.Tables[0].Rows[0]["cont_mfrno"].ToString().Trim();
                tbxHidMfrNo.Text = ds.Tables[0].Rows[0]["cont_mfrno"].ToString().Trim();
                lblMfrTelFax.Text = ds.Tables[0].Rows[0]["mfr_tel"].ToString() + "(Fax：" + ds.Tables[0].Rows[0]["mfr_fax"].ToString().Trim() + ")";
                lblRespData.Text = ds.Tables[0].Rows[0]["mfr_respnm"].ToString() + "(" + ds.Tables[0].Rows[0]["mfr_respjbti"].ToString().Trim() + ")";

                //合約書基本資料
                tbxSignDate.Text = DateTime.Today.ToString("yyyy/MM/dd");

                ddlContTp.SelectedIndex = -1;
                if (ddlContTp.Items.FindByValue(ds.Tables[0].Rows[0]["cont_conttp"].ToString()) != null)
                {
                    ddlContTp.Items.FindByValue(ds.Tables[0].Rows[0]["cont_conttp"].ToString()).Selected = true;
                }
                else
                {
                    ddlContTp.SelectedIndex = 0;
                }

                tbxSDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
                tbxEDate.Text = "";
                tbxRemark.Text = ds.Tables[0].Rows[0]["cont_remark"].ToString().Trim();
                lblContNo.Text = new_contno;

                ddlContTp.SelectedIndex = -1;
                if (ddlEmpData.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()) != null)
                {
                    ddlEmpData.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()).Selected = true;
                }
                else
                {
                    ddlContTp.SelectedIndex = 0;
                }

                rblPayOnce.SelectedIndex = 0;

                //合約書細節
                tbxPubTm.Text = "0";
                tbxFreeTm.Text = "0";
                tbxTotImgTm.Text = "0";
                tbxTotUrlTm.Text = "0";
                tbxTotAmt.Text = "0";
                tbxDisc.Text = "1";

                //廣告聯絡人資料
                tbxAuNm.Text = ds.Tables[0].Rows[0]["cont_aunm"].ToString().Trim();
                tbxAuEmail.Text = ds.Tables[0].Rows[0]["cont_auemail"].ToString().Trim();
                tbxAuTel.Text = ds.Tables[0].Rows[0]["cont_autel"].ToString().Trim();
                tbxAuCell.Text = ds.Tables[0].Rows[0]["cont_aucell"].ToString().Trim();
                tbxAuFax.Text = ds.Tables[0].Rows[0]["cont_aufax"].ToString().Trim();

                //廣告推廣內文、期限、產品設備內文、材料特性、應用產業等相關資料

                //發票廠商收件人資料

                //雜誌收件人及贈書資料
            }


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
            string cont_contno = lblContNo.Text.Trim();
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
            string cont_mfrno = tbxHidMfrNo.Text.Trim();
            string cont_custno = tbxHidCustNo.Text.Trim();
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

            int pubedtm = 0;
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

            float cont_paidamt = 0; //一開始應該都還沒付錢
            float cont_restamt = Convert.ToSingle(tbxTotAmt.Text.Trim()); //一開始都是滿的...
            string cont_remark = tbxRemark.Text.Trim();
            string cont_credate = DateTime.Now.ToString("yyyyMMdd");
            string cont_moddate = DateTime.Now.ToString("yyyyMMdd");
            string cont_modempno = Account.GetAccInfo().srspn_empno.ToString().Trim();
            string cong_fgpayonce = rblPayOnce.SelectedItem.Value;

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

            bool success = myCont.UpdateToBeFormal(cont_contno, cont_conttp, cont_signdate, cont_sdate, cont_edate, cont_empno, cont_mfrno, cont_custno,
                                cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_freetm, cont_pubtm,
                                cont_resttm, cont_totimgtm, cont_toturltm, cont_disc, cont_totamt, cont_paidamt, cont_restamt,
                                cont_remark, cont_credate, cont_moddate, cont_modempno, cong_fgpayonce, cont_ccont, cont_pdcont, cont_csdate);

            //檢查合約是否正式儲存成功
            if (success)
            {
                JavaScript.AlertMessageRedirect(this.Page, "合約儲存成功，可繼續從選單進行落版或其他相關事宜", "InterPlaneCont.aspx");
            }
            else
            {
                JavaScript.AlertMessage(this.Page, "合約儲存失敗，系統可能出錯，請通知聯絡人");
                return;
            }
        }

        protected void btnNoSave_Click(object sender, EventArgs e)
        {
            string contno = lblContNo.Text.Trim();
            myCont.DeleteContTemp(contno);

            JavaScript.AlertMessageRedirect(this.Page, "暫存資料已經清除，請繼續其他功能處理", "InterPlaneCont.aspx");

        }

        protected void postbackBtn_Click(object sender, EventArgs e)
        {
            ShowAtpMatp();
            ShowFreeBook();
            ShowInvMfr();
        }
    }
}
