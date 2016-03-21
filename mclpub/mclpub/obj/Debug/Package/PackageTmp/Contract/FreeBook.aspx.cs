using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Contract
{
    public partial class FreeBook : System.Web.UI.Page
    {
        FreeBook_DB myFree = new FreeBook_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string new_contno = "";
                if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
                {
                    JavaScript.AlertMessage(this.Page, "無合約編號，程式錯誤，請通知聯絡人");
                    return;
                }
                else
                {
                    new_contno = Request.QueryString["NewContNo"].Trim();
                }

                string old_contno = "";
                if (Request.QueryString["OldContNo"] == null || Request.QueryString["OldContNo"] == "")
                {
                    DataSet ds = myFree.GetSingleContractByContNo(new_contno);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            old_contno = ds.Tables[0].Rows[0]["cont_oldcontno"].ToString().Trim();//dr["cont_oldcontno"].ToString();
                        }
                        catch
                        {
                            Application["ErrorMsg"] = "找不到合約資料，請通知聯絡人";
                            Response.Redirect("~/errorPage.aspx");
                        }
                    }
                }
                else
                {
                    old_contno = Request.QueryString["OldContNo"];
                }


                string custno = "";
                if (Request.QueryString["CustNo"] == null || Request.QueryString["CustNo"] == "")
                {
                    JavaScript.AlertMessage(this.Page, "無合約編號，程式錯誤，請通知聯絡人");
                    return;
                }
                else
                {
                    custno = Request.QueryString["CustNo"];
                }
                LoadCustToBeDefaultOr(custno);

                //三個唯讀的資料，歷史收件人，歷史贈書，郵寄類別
                if (old_contno != "")
                {
                    Bind_dgdOldOr(old_contno);
                    Bind_dgdOldFreeBk(old_contno);
                }
                else
                {
                    //設定資訊
                    dgdOldOr.Visible = false;
                    lblOldOr.Text = "[無歷史合約雜誌收件人資料]";

                    dgdOldFreeBk.Visible = false;
                    lblOldFreeBk.Text = "[無歷史合約贈書資料]";
                }
                Bind_ddlMtpCd();

                //本合約收件人、本合約贈書
                Bind_dgdNewOr(new_contno);
                Bind_dgdNewFreeBk(new_contno);

                //設定修改按鈕為invisible
                btnUpdateOr.Visible = false;
                btnCancelOr.Visible = false;
                btnUpdateFreeBk.Visible = false;
                btnCancelFreeBk.Visible = false;
            }
        }


        #region 載入客戶資料作為預設收件人資料
        private void LoadCustToBeDefaultOr(string custno)
        {
            DataSet ds = myFree.GetMfrCustByCustNo(custno);
            tbxOrInm.Text = ds.Tables[0].Rows[0]["mfr_inm"].ToString().Trim();
            tbxOrNm.Text = ds.Tables[0].Rows[0]["cust_nm"].ToString().Trim();
            tbxOrJbti.Text = ds.Tables[0].Rows[0]["cust_jbti"].ToString().Trim();
            tbxOrTel.Text = ds.Tables[0].Rows[0]["cust_tel"].ToString().Trim();
            tbxOrCell.Text = ds.Tables[0].Rows[0]["cust_cell"].ToString().Trim();
            tbxOrFax.Text = ds.Tables[0].Rows[0]["cust_fax"].ToString().Trim();
            tbxOrEmail.Text = ds.Tables[0].Rows[0]["cust_email"].ToString().Trim();

            //海內外註記就不管了
            ddlOrMoSea.SelectedIndex = 0;
        }
        #endregion

        #region 連結歷史合約收件人資料資料
        private void Bind_dgdOldOr(string contno)
        {
            DataSet ds = myFree.GetOrByContNo(contno);
            DataView dv = ds.Tables[0].DefaultView;
            dgdNewOr.DataSource = dv;
            dgdNewOr.DataBind();

            if (dv.Count > 0)
            {
                dgdOldOr.Visible = true;
                lblOldOr.Text = "[歷史合約雜誌收件人資料]";
            }
            else
            {
                dgdOldOr.Visible = false;
                lblOldOr.Text = "[無歷史合約雜誌收件人資料]";
            }
        }
        #endregion

        #region 連結歷史贈書資料
        private void Bind_dgdOldFreeBk(string contno)
        {
            DataSet ds = myFree.GetFbkOrByContNo(contno);
            DataView dv = ds.Tables[0].DefaultView;
            dgdOldFreeBk.DataSource = dv;
            dgdOldFreeBk.DataBind();

            if (dv.Count > 0)
            {
                dgdOldFreeBk.Visible = true;
                lblOldFreeBk.Text = "[歷史合約贈書資料]";
            }
            else
            {
                dgdOldFreeBk.Visible = false;
                lblOldFreeBk.Text = "[無歷史合約贈書資料]";
            }
        }
        #endregion

        #region 連結郵寄類別選單
        private void Bind_ddlMtpCd()
        {
            if (Session["MTP"] == null)
            {
                DataSet ds = myFree.GetMtps();
                DataView dv = ds.Tables[0].DefaultView;
                Session.Add("MTP", dv);
            }
            DataView mtpdv = (DataView)Session["MTP"];

            ddlMtpCd.DataSource = mtpdv;
            ddlMtpCd.DataTextField = "mtp_nm";
            ddlMtpCd.DataValueField = "mtp_mtpcd";
            ddlMtpCd.DataBind();
        }
        #endregion

        #region 連結本合約收件人資料資料
        private void Bind_dgdNewOr(string contno)
        {
            DataSet ds = myFree.GetOrByContNo(contno);
            DataView dv = ds.Tables[0].DefaultView;
            dgdNewOr.DataSource = dv;
            dgdNewOr.DataBind();

            //順便連結收件人的下拉式選單
            Bind_ddlOr(dv);


            if (dv.Count > 0)
            {
                lblOrMsg.Text = "[本合約雜誌收件人資料]";
                dgdNewOr.Visible = true;
            }
            else
            {
                lblOrMsg.Text = "[本合約尚無雜誌收件人資料]";
                dgdNewOr.Visible = false;
            }
        }
        #endregion

        #region 連結收件人選單
        private void Bind_ddlOr(DataView dv)
        {
            ddlOrSeq.DataSource = dv;
            ddlOrSeq.DataTextField = "or_nm";
            ddlOrSeq.DataValueField = "or_oritem";
            ddlOrSeq.DataBind();

            if (dv.Count > 0)
            {
                ddlOrSeq.Enabled = true;
                ddlOrSeq.BackColor = System.Drawing.Color.Transparent;
            }
            else
            {
                ddlOrSeq.Enabled = false;
                ddlOrSeq.BackColor = System.Drawing.Color.LightGray;
            }
        }
        #endregion

        #region 連結本合約贈書資料
        private void Bind_dgdNewFreeBk(string contno)
        {
            DataSet ds = myFree.GetFbkOrByContNo(contno);
            DataView dv = ds.Tables[0].DefaultView;
            dgdNewFreeBk.DataSource = dv;
            dgdNewFreeBk.DataBind();

            if (dv.Count > 0)
            {
                lblFreeBkMsg.Text = "[本合約贈書資料]";
                dgdNewFreeBk.Visible = true;
            }
            else
            {
                lblFreeBkMsg.Text = "[本合約尚無贈書資料]";
                dgdNewFreeBk.Visible = false;
            }
        }
        #endregion

        #region 取回海內外郵寄註記名稱
        protected object GetYNCh(object fgmosea)
        {
            if (Convert.ToString(fgmosea) == "1")
                return "國外";
            else
                return "國內";
        }
        #endregion

        #region 取回郵寄類別名稱
        protected object GetMtpNm(object mtpcd)
        {
            string strReturn = "";
            if (Session["MTP"] == null)
            {
                DataSet ds = myFree.GetMtps();
                DataView dv = ds.Tables[0].DefaultView;
                Session.Add("MTP", dv);
            }
            DataView mtpdv = (DataView)Session["MTP"];
            mtpdv.RowFilter = "mtp_mtpcd='" + mtpcd.ToString() + "'";
            if (mtpdv.Count > 0)
            {
                strReturn = mtpdv[0]["mtp_nm"].ToString().Trim();
            }
            mtpdv.RowFilter = "";

            return strReturn;
        }
        #endregion

        protected void dgdNewFreeBk_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[10].Visible = false;
                string bkcd = e.Row.Cells[5].Text.Trim();
                try
                {
                    if (bkcd == "01")
                    {
                        e.Row.Cells[5].Text = "工材";
                    }
                    else if (bkcd == "02")
                    {
                        e.Row.Cells[5].Text = "電材";
                    }
                    //e.Row.Cells[5].Text = ddlFbkBkCd;
                }
                catch
                {
                    e.Row.Cells[5].Text = "(轉換失敗)";
                }


            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[10].Visible = false;
            }
        }

        protected void btnAddOr_Click(object sender, EventArgs e)
        {
            string new_contno = "";
            if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
            {
                JavaScript.AlertMessage(this.Page, "找不到合約編號");
                return;
            }
            else
            {
                new_contno = Request.QueryString["NewContNo"];
            }
            string or_inm = tbxOrInm.Text.Trim();
            string or_nm = tbxOrNm.Text.Trim();
            string or_jbti = tbxOrJbti.Text.Trim();
            string or_addr = tbxOrAddr.Text.Trim();
            string or_zip = tbxOrZip.Text.Trim();
            string or_tel = tbxOrTel.Text.Trim();
            string or_fax = tbxOrFax.Text.Trim();
            string or_cell = tbxOrCell.Text.Trim();
            string or_email = tbxOrEmail.Text.Trim();
            string or_fgmosea = ddlOrMoSea.SelectedItem.Value.Trim();

            string or_oritem = myFree.AddOr(new_contno, or_inm, or_nm, or_jbti, or_addr, or_zip, or_tel, or_fax, or_cell, or_email, or_fgmosea);

            if (or_oritem == null || or_oritem == "00")
            {
                JavaScript.AlertMessage(this.Page, "新增收件人失敗"); 
                return;
            }

            Bind_dgdNewOr(new_contno);
            CleanOrFields();
        }

        #region 清空收件人欄位
        private void CleanOrFields()
        {
            tbxOrSeq.Text = "";
            tbxOrInm.Text = "";
            tbxOrNm.Text = "";
            tbxOrJbti.Text = "";
            tbxOrAddr.Text = "";
            tbxOrZip.Text = "";
            tbxOrTel.Text = "";
            tbxOrFax.Text = "";
            tbxOrCell.Text = "";
            tbxOrEmail.Text = "";
            ddlOrMoSea.SelectedIndex = 0;
        }
        #endregion

        protected void lkedit_Click(object sender, EventArgs e)
        {
            LinkButton thislbtn = (LinkButton)sender;
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;

            string or_oritem = row.Cells[2].Text.Trim();
            string or_inm = row.Cells[3].Text.Trim();
            string or_nm = row.Cells[4].Text.Trim();
            string or_jbti = row.Cells[5].Text.Trim();
            string or_zip = row.Cells[6].Text.Trim();
            string or_addr = row.Cells[7].Text.Trim();
            string or_tel = row.Cells[8].Text.Trim();
            string or_fax = row.Cells[9].Text.Trim();
            string or_cell = row.Cells[10].Text.Trim().Replace("&nbsp;", "");
            string or_email = row.Cells[11].Text.Trim().Replace("&nbsp;", "");
            string or_fgmosea = row.Cells[13].Text.Trim();

            //Response.Write(or_fgmosea);
            tbxOrSeq.Text = or_oritem;
            tbxOrInm.Text = or_inm;
            tbxOrNm.Text = or_nm;
            tbxOrJbti.Text = or_jbti;
            tbxOrAddr.Text = or_addr;
            tbxOrZip.Text = or_zip;
            tbxOrTel.Text = or_tel;
            tbxOrFax.Text = or_fax;
            tbxOrCell.Text = or_cell;
            tbxOrEmail.Text = or_email;

            if (or_fgmosea == "1")
            {
                ddlOrMoSea.SelectedValue = or_fgmosea;
            }
            else
            {
                ddlOrMoSea.SelectedIndex = 0;
            }

            //隱藏新增，顯示修改
            btnAddOr.Visible = false;
            btnUpdateOr.Visible = true;
            btnCancelOr.Visible = true;

        }

        protected void lkdel_Click(object sender, EventArgs e)
        {
            string new_contno = "";
            if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
            {
                throw new Exception("找不到合約編號");
            }
            else
            {
                new_contno = Request.QueryString["NewContNo"];
            }

            LinkButton thislbtn = (LinkButton)sender;
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;

            string or_oritem = row.Cells[2].Text.Trim();

            int effects = myFree.DeleteOr(new_contno, or_oritem);
            //efffects>0就是有郵寄份數或者缺書用到此收件人
            if (effects > 0)
            {
                JavaScript.AlertMessage(this.Page, "無法刪除此收件人，因為此收件人仍有贈書或缺書");
                return;
            }

            Bind_dgdNewOr(new_contno);
            CleanOrFields();

            //隱藏修改，顯示新增
            btnAddOr.Visible = true;
            btnUpdateOr.Visible = false;
        }

        protected void btnCancelOr_Click(object sender, EventArgs e)
        {
            CleanOrFields();
            string custno = Request.QueryString["CustNo"];
            LoadCustToBeDefaultOr(custno);
            //隱藏修改，顯示新增
            btnAddOr.Visible = true;
            btnUpdateOr.Visible = false;
            btnCancelOr.Visible = false;
        }

        protected void dgdNewOr_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[13].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[13].Visible = false;
            }
        }

        protected void btnAddFreeBk_Click(object sender, EventArgs e)
        {
            string new_contno = "";
            if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
            {
                throw new Exception("找不到合約編號");
            }
            else
            {
                new_contno = Request.QueryString["NewContNo"];
            }

            //有收件人才可以新增贈書
            if (!(ddlOrSeq.Items.Count > 0))
            {
                JavaScript.AlertMessage(this.Page, "請先增收件人後才能新增贈書");
                return;
            }

            //檢查時間先後順序
            DateTime sdate = DateTime.ParseExact(tbxMaSDate.Text.Trim(), "yyyy/MM", null);
            DateTime edate = DateTime.ParseExact(tbxMaEDate.Text.Trim(), "yyyy/MM", null);
            string ma_sdate = sdate.ToString("yyyyMM");
            string ma_edate = edate.ToString("yyyyMM");

            if (edate < sdate)
            {
                JavaScript.AlertMessage(this.Page, "贈書起迄月區段錯誤，請檢查時間合理性");
                return;
            }

            string ma_oritem = ddlOrSeq.SelectedItem.Value;
            string fbk_bkcd = ddlFbkBkCd.SelectedItem.Value;
            string ma_pubmnt = tbxPubMnt.Text.Trim();
            string ma_unpubmnt = tbxUnPubMnt.Text.Trim();
            string ma_mtpcd = ddlMtpCd.SelectedItem.Value;

            //新增贈書與郵寄份數
            string new_fbkitem = myFree.AddFreeBk(new_contno, fbk_bkcd, ma_oritem, ma_sdate, ma_edate, ma_pubmnt, ma_unpubmnt, ma_mtpcd);

            if (new_fbkitem == null || new_fbkitem == "00")
            {
                JavaScript.AlertMessage(this.Page, "新增贈書失敗");
                return;
            }

            Bind_dgdNewFreeBk(new_contno);
            CleanFreeBkFields();
        }


        protected void lkdgdNewFreeBkedit_Click(object sender, EventArgs e)
        {
            LinkButton thislbtn = (LinkButton)sender;
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;


            string ma_sdate = row.Cells[3].Text.Trim();
            string ma_edate = row.Cells[4].Text.Trim();
            string fbk_bkcd = row.Cells[5].Text.Trim();
            string ma_oritem = row.Cells[6].Text.Trim();
            string ma_pubmnt = row.Cells[7].Text.Trim();
            string ma_unpubmnt = row.Cells[8].Text.Trim();
            string ma_mtpcd = ((Label)row.Cells[9].FindControl("lblMtpNm")).Text.Trim();
            ViewState["cell2"] = row.Cells[2].Text.Trim();//給予修改時按下確定鎖帶入的序號

            tbxMaSDate.Text = ma_sdate;
            tbxMaEDate.Text = ma_edate;

            if (fbk_bkcd == "2")
            {
                ddlFbkBkCd.SelectedValue = fbk_bkcd;
            }
            else
            {
                ddlFbkBkCd.SelectedIndex = 0;
            }

            ddlOrSeq.SelectedIndex = -1;
            if (ddlOrSeq.Items.FindByText(ma_oritem) != null)
                ddlOrSeq.Items.FindByText(ma_oritem).Selected = true;
            else
                ddlOrSeq.SelectedIndex = 0;

            tbxPubMnt.Text = ma_pubmnt;
            tbxUnPubMnt.Text = ma_unpubmnt;

            ddlMtpCd.SelectedIndex = -1;
            if (ddlMtpCd.Items.FindByText(ma_mtpcd) != null)
                ddlMtpCd.Items.FindByText(ma_mtpcd).Selected = true;
            else
                ddlMtpCd.SelectedIndex = 0;

            //隱藏新增，顯示修改
            btnAddFreeBk.Visible = false;
            btnUpdateFreeBk.Visible = true;
            btnCancelFreeBk.Visible = true;

        }


        protected void lkdgdNewFreeBkdel_Click(object sender, EventArgs e)
        {
            LinkButton thislbtn = (LinkButton)sender;
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;

            string new_contno = "";
            if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
            {
                throw new Exception("找不到合約編號");
            }
            else
            {
                new_contno = Request.QueryString["NewContNo"];
            }

            string fbk_fbkitem = row.Cells[2].Text.Trim();
            string ma_oritem = row.Cells[10].Text.Trim();


            //Response.Write(new_contno + "," + fbk_fbkitem + "," + ma_oritem);
            bool success = myFree.Delete_1_FreeBk(new_contno, fbk_fbkitem, ma_oritem);

            if (!success)
            {
                JavaScript.AlertMessage(this.Page, "刪除贈書失敗");
                return;
            }

            Bind_dgdNewFreeBk(new_contno);
            CleanFreeBkFields();

            //顯示新增，隱藏修改
            btnAddFreeBk.Visible = true;
            btnUpdateFreeBk.Visible = false;
        }


        #region 清除贈書欄位
        private void CleanFreeBkFields()
        {
            string ma_sdate = "";
            string ma_edate = "";
            string fbk_bkcd = "";
            string ma_oritem = "";
            string ma_pubmnt = "";
            string ma_unpubmnt = "";
            string ma_mtpcd = "";

            tbxMaSDate.Text = "";
            tbxMaEDate.Text = "";

            ddlFbkBkCd.SelectedIndex = 0;

            ddlOrSeq.SelectedIndex = 0;

            tbxPubMnt.Text = "";
            tbxUnPubMnt.Text = "";

            ddlMtpCd.SelectedIndex = 0;
        }
        #endregion

        protected void btnCancelFreeBk_Click(object sender, EventArgs e)
        {
            CleanFreeBkFields();

            //顯示新增，隱藏修改
            btnAddFreeBk.Visible = true;
            btnUpdateFreeBk.Visible = false;
            btnCancelFreeBk.Visible = false;
        }

        protected void btnUpdateFreeBk_Click(object sender, EventArgs e)
        {
            string new_contno = "";
            if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
            {
                throw new Exception("找不到合約編號");
            }
            else
            {
                new_contno = Request.QueryString["NewContNo"];
            }

            //避免user又把收件人弄掉了...再檢查一次，雖然是不太可能啦
            if (!(ddlOrSeq.Items.Count > 0))
            {
                JavaScript.AlertMessage(this.Page, "請先增收件人後才能新增贈書");
                return;
            }

            //檢查時間先後順序
            DateTime sdate = DateTime.ParseExact(tbxMaSDate.Text.Trim(), "yyyy/MM", null);
            DateTime edate = DateTime.ParseExact(tbxMaEDate.Text.Trim(), "yyyy/MM", null);
            string ma_sdate = sdate.ToString("yyyyMM");
            string ma_edate = edate.ToString("yyyyMM");

            if (edate < sdate)
            {
                JavaScript.AlertMessage(this.Page, "贈書起迄月區段錯誤，請檢查時間合理性");
                return;
            }

            //Response.Write(ViewState["cell2"].ToString());
            string fbk_fbkitem = ViewState["cell2"].ToString();
            string ma_oritem = ddlOrSeq.SelectedItem.Value;
            string fbk_bkcd = ddlFbkBkCd.SelectedItem.Value;
            string ma_pubmnt = tbxPubMnt.Text.Trim();
            string ma_unpubmnt = tbxUnPubMnt.Text.Trim();
            string ma_mtpcd = ddlMtpCd.SelectedItem.Value;

            //先delete再insert
            string new_fbkitem = myFree.UpdateFreeBk(new_contno, fbk_fbkitem, fbk_bkcd, ma_oritem, ma_sdate, ma_edate, ma_pubmnt, ma_unpubmnt, ma_mtpcd);

            if (new_fbkitem == null || new_fbkitem == "00")
            {
                JavaScript.AlertMessage(this.Page, "修改贈書失敗");
                return;
            }

            Bind_dgdNewFreeBk(new_contno);
            CleanFreeBkFields();

            //顯示新增，隱藏修改
            btnAddFreeBk.Visible = true;
            btnUpdateFreeBk.Visible = false;
            btnCancelFreeBk.Visible = false;
        }

        protected void btnUpdateOr_Click(object sender, EventArgs e)
        {
            string new_contno = "";
            if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
            {
                throw new Exception("找不到合約編號");
            }
            else
            {
                new_contno = Request.QueryString["NewContNo"];
            }

            string or_oritem = "";
            if (tbxOrSeq.Text.Trim() == "")
            {
                throw new Exception("收件人序號為空白");
            }
            else
            {
                or_oritem = tbxOrSeq.Text.Trim();
            }

            string or_inm = tbxOrInm.Text.Trim();
            string or_nm = tbxOrNm.Text.Trim();
            string or_jbti = tbxOrJbti.Text.Trim();
            string or_addr = tbxOrAddr.Text.Trim();
            string or_zip = tbxOrZip.Text.Trim();
            string or_tel = tbxOrTel.Text.Trim();
            string or_fax = tbxOrFax.Text.Trim();
            string or_cell = tbxOrCell.Text.Trim();
            string or_email = tbxOrEmail.Text.Trim();
            string or_fgmosea = ddlOrMoSea.SelectedItem.Value.Trim();

            myFree.UpdateOr(new_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, or_tel, or_fax, or_cell, or_email, or_fgmosea);

            Bind_dgdNewOr(new_contno);
            CleanOrFields();

            //隱藏修改，顯示新增
            btnAddOr.Visible = true;
            btnUpdateOr.Visible = false;
            btnCancelOr.Visible = false;
        }
    }
}
