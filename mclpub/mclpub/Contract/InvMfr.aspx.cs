using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Contract
{
    public partial class InvMfr : System.Web.UI.Page
    {
        InvMfr_DB myIn = new InvMfr_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                tbxImMfrNo.Text = Request.QueryString["mfrno"];
                //				Response.Write(Request.QueryString["mfrno"]);
                //檢查變數，這樣大概可以過濾一些
                string new_contno = "";
                if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
                {
                    throw new Exception("找不到合約編號");
                }
                else
                {
                    new_contno = Request.QueryString["NewContNo"];
                    DataSet ds = myIn.GetSingleContractByContNo(new_contno);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        tbxImMfrNo.Text = ds.Tables[0].Rows[0]["cont_mfrno"].ToString();
                    }
                    if (tbxImMfrNo.Text.Trim() == "")
                        tbxImMfrNo.Text = Request.QueryString["mfrno"];
                    //				Response.Write("test");
                }

                string old_contno = "";
                if (Request.QueryString["OldContNo"] == null || Request.QueryString["OldContNo"] == "")
                {
                    //在維護合約時，從合約資料去找.....
                    DataSet ds = myIn.GetSingleContractByContNo(new_contno);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            old_contno = ds.Tables[0].Rows[0]["cont_oldcontno"].ToString();
                        }
                        catch
                        {
                            throw new Exception("找不到合約資料，請通知聯絡人");
                        }
                    }

                    if (old_contno == "")
                    {
                        JavaScript.AlertMessage(this.Page, "無歷史合約編號，不帶入歷史資料；注意：若本合約有歷史參考合約，則為系統帶入資料時發生錯誤，請通知聯絡人。");
                        return;
                    }

                }
                else
                {
                    old_contno = Request.QueryString["OldContNo"];
                }

                //				if (tbxOldContNo.Text.Trim() == "")
                //				{
                //					jsAlertMsg("NOOLDCONT", "無歷史合約資料，所以不帶入該合約發票廠商資料");
                //				}
                //				else
                //				{
                //					old_contno = tbxOldContNo.Text.Trim();
                //				}
                //				Response.Write(Request.QueryString["mfrno"]);
                Bind_dgdOldInvMfr(old_contno);
                Bind_NewInvMfr(new_contno);
                btnUpdateFreeBk.Visible = false;
                btnCancelFreeBk.Visible = false;
            }
        }


        #region 歷史合約的發票廠商收件人資料
        private void Bind_dgdOldInvMfr(string contno)
        {
            if (contno.Trim() == "")
            {
                lblOldIm.Text = "無歷史合約發票廠商收件人資料";
                dgdOldInvMfr.Visible = false;
                return;
            }

            DataSet ds = myIn.GetInvMfr(contno);
            DataView dv = ds.Tables[0].DefaultView;
            dgdOldInvMfr.DataSource = dv;
            dgdOldInvMfr.DataBind();

            if (dv.Count > 0)
            {
                lblOldIm.Text = "歷史合約發票廠商收件人資料";
                dgdOldInvMfr.Visible = true;
            }
            else
            {
                lblOldIm.Text = "無歷史合約發票廠商收件人資料";
                dgdOldInvMfr.Visible = false;
            }
        }
        #endregion

        protected void dgdOldInvMfr_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    //找的到所內、院內就show
                    e.Row.Cells[13].Text = ddlFgItri.Items.FindByValue(e.Row.Cells[13].Text.Trim()).Text;
                }
                catch
                {
                    //其他的視為一般
                    e.Row.Cells[13].Text = "一般";
                }
            }
        }

        #region 本合約的發票廠商收件人資料
        private void Bind_NewInvMfr(string contno)
        {
            DataSet ds = myIn.GetInvMfr(contno);
            DataView dv = ds.Tables[0].DefaultView;
            dgdNewInvMfr.DataSource = dv;
            dgdNewInvMfr.DataBind();


            if (dv.Count > 0)
            {
                lblNewIm.Text = "本合約發票廠商收件人資料";
                dgdNewInvMfr.Visible = true;

                //				for (int i=0; i<dgdNewInvMfr.Items.Count; i++)
                //				{
                //					try
                //					{
                //						//找的到所內、院內就show
                //						dgdNewInvMfr.Items[i].Cells[13].Text = ddlFgItri.Items.FindByValue(dgdNewInvMfr.Items[i].Cells[13].Text.Trim()).Text;
                //					}
                //					catch
                //					{
                //						//其他的視為一般
                //						dgdNewInvMfr.Items[i].Cells[13].Text = "一般";
                //					}
                //				}
            }
            else
            {
                lblNewIm.Text = "本合約尚無發票廠商收件人資料";
                dgdNewInvMfr.Visible = false;
            }
        }
        #endregion

        #region 清除欄位
        private void ClearForm()
        {
            tbxImSeq.Text = "";
            tbxImMfrNo.Text = "";
            tbxImNm.Text = "";
            tbxImJbti.Text = "";
            tbxImAddr.Text = "";
            tbxImZip.Text = "";
            tbxImTel.Text = "";
            tbxImFax.Text = "";
            tbxImCell.Text = "";
            tbxImEmail.Text = "";
            ddlInvCd.SelectedIndex = 0;
            ddlTaxTp.SelectedIndex = 0;
            ddlFgItri.SelectedIndex = 0;
        }
        #endregion

        protected void btnAddIm_Click(object sender, EventArgs e)
        {
            string mfrno = tbxImMfrNo.Text.Trim();
            string nm = tbxImNm.Text.Trim();
            string jbti = tbxImJbti.Text.Trim();
            string addr = tbxImAddr.Text.Trim();
            string zip = tbxImZip.Text.Trim();
            string tel = tbxImTel.Text.Trim();
            string fax = tbxImFax.Text.Trim();
            string cell = tbxImCell.Text.Trim();
            string email = tbxImEmail.Text.Trim();
            string invcd = ddlInvCd.SelectedItem.Value;
            string taxtp = ddlTaxTp.SelectedItem.Value;
            string fgitri = ddlFgItri.SelectedItem.Value;
            string contno = Request.QueryString["NewContNo"];


            string new_imseq = myIn.AddInvMfr(contno, mfrno, nm, jbti, addr, zip, tel, fax, cell, email, invcd, taxtp, fgitri);

            if (new_imseq == "0" || new_imseq == "00")
            {
                JavaScript.AlertMessage(this.Page, "無法新增發票廠商資料，請通知聯絡人");
                return;
            }

            Bind_NewInvMfr(contno);

            ClearForm();
        }


        protected void Del_click(object sender, EventArgs e)
        {
            LinkButton thislbtn = (LinkButton)sender;
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;

            string contno = Request.QueryString["NewContNo"].Trim();
            string imseq = row.Cells[1].Text.Trim();

            bool flag = myIn.DeleteIm(contno, imseq);
            if (!flag)
                JavaScript.AlertMessage(this.Page,"此發票廠商有落版資料, 不能刪除");
            else
                Bind_NewInvMfr(contno);
        }


        protected void edit_Click(object sender, EventArgs e)
        {
            LinkButton thislbtn = (LinkButton)sender;
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;

            btnUpdateFreeBk.Visible = true;
            btnCancelFreeBk.Visible = true;
            btnAddIm.Visible = false;

            string id = row.Cells[1].Text.Trim();
            string mfrno = row.Cells[2].Text.Trim();
            string nm = row.Cells[3].Text.Trim();
            string jbti = row.Cells[4].Text.Trim().Replace("&nbsp;", "");
            string addr = row.Cells[5].Text.Trim().Replace("&nbsp;", "");
            string zip = row.Cells[6].Text.Trim().Replace("&nbsp;", "");
            string tel = row.Cells[7].Text.Trim().Replace("&nbsp;", "");
            string fax = row.Cells[8].Text.Trim().Replace("&nbsp;", "");
            string cell = row.Cells[9].Text.Trim().Replace("&nbsp;", "");
            string email = row.Cells[10].Text.Trim().Replace("&nbsp;", "");
            string invcd = row.Cells[11].Text.Trim();
            string taxtp = row.Cells[12].Text.Trim();
            string fgitri = row.Cells[13].Text.Trim();

            tbxImSeq.Text = id;
            tbxImMfrNo.Text = mfrno;
            tbxImNm.Text = nm;
            tbxImJbti.Text = jbti;
            tbxImAddr.Text = addr;
            tbxImZip.Text = zip;
            tbxImTel.Text = tel;
            tbxImFax.Text = fax;
            tbxImCell.Text = cell;
            tbxImEmail.Text = email;

            //Response.Write(ddlInvCd.Items.FindByText(invcd).Value);
            //Response.Write("1111");
            //Response.Write(invcd);
            if (ddlInvCd.Items.FindByText(invcd) != null)
            {
                //Response.Write("111");
                //ddlInvCd.Items.FindByValue(invcd).Selected = true;
                ddlInvCd.SelectedValue = ddlInvCd.Items.FindByText(invcd).Value;
                //ddlInvCd.Items.FindByText(invcd).Selected = true;

            }
            else
            {
                ddlInvCd.SelectedIndex = 0;
            }

            if (ddlTaxTp.Items.FindByText(taxtp) != null)
            {
                ddlTaxTp.SelectedValue = ddlTaxTp.Items.FindByText(taxtp).Value;
                //ddlTaxTp.Items.FindByText(taxtp).Selected = true;
            }
            else
            {
                ddlTaxTp.SelectedIndex = 0;
            }

            if (ddlFgItri.Items.FindByText(fgitri) != null)
            {
                ddlFgItri.SelectedValue = ddlFgItri.Items.FindByText(fgitri).Value;
                //ddlFgItri.Items.FindByText(fgitri).Selected = true;
            }
            else
            {
                ddlFgItri.SelectedIndex = 0;
            }		
        }


        protected void onLoad_click(object sender, EventArgs e)
        {
            LinkButton thislbtn = (LinkButton)sender;
            GridViewRow row = ((LinkButton)sender).Parent.Parent as GridViewRow;

            string mfrno = row.Cells[2].Text.Trim();
            string nm = row.Cells[3].Text.Trim();
            string jbti = row.Cells[4].Text.Trim().Replace("&nbsp;", "");
            string addr = row.Cells[5].Text.Trim().Replace("&nbsp;", "");
            string zip = row.Cells[6].Text.Trim().Replace("&nbsp;", "");
            string tel = row.Cells[7].Text.Trim().Replace("&nbsp;", "");
            string fax = row.Cells[8].Text.Trim().Replace("&nbsp;", "");
            string cell = row.Cells[9].Text.Trim().Replace("&nbsp;", "");
            string email = row.Cells[10].Text.Trim().Replace("&nbsp;", "");
            string invcd = row.Cells[11].Text.Trim();
            string taxtp = row.Cells[12].Text.Trim();
            string fgitri = row.Cells[13].Text.Trim();

            tbxImSeq.Text = "";
            tbxImMfrNo.Text = mfrno;
            tbxImNm.Text = nm;
            tbxImJbti.Text = jbti;
            tbxImAddr.Text = addr;
            tbxImZip.Text = zip;
            tbxImTel.Text = tel;
            tbxImFax.Text = fax;
            tbxImCell.Text = cell;
            tbxImEmail.Text = email;

            //Response.Write(ddlInvCd.Items.FindByText(invcd).Value);
            //Response.Write(invcd);
            if (ddlInvCd.Items.FindByText(invcd) != null)
            {
                //Response.Write("111");
                //ddlInvCd.Items.FindByValue(invcd).Selected = true;
                ddlInvCd.SelectedValue = ddlInvCd.Items.FindByText(invcd).Value;
                //ddlInvCd.Items.FindByText(invcd).Selected = true;

            }
            else
            {
                ddlInvCd.SelectedIndex = 0;
            }

            if (ddlTaxTp.Items.FindByText(taxtp) != null)
            {
                ddlTaxTp.SelectedValue = ddlTaxTp.Items.FindByText(taxtp).Value;
                //ddlTaxTp.Items.FindByText(taxtp).Selected = true;
            }
            else
            {
                ddlTaxTp.SelectedIndex = 0;
            }

            if (ddlFgItri.Items.FindByText(fgitri) != null)
            {
                ddlFgItri.SelectedValue = ddlFgItri.Items.FindByText(fgitri).Value;
                ddlFgItri.Items.FindByText(fgitri).Selected = true;
            }
            else
            {
                ddlFgItri.SelectedIndex = 0;
            }		

        }

        protected void btnUpdateFreeBk_Click(object sender, EventArgs e)
        {
            string imseq = tbxImSeq.Text.Trim();
            string mfrno = tbxImMfrNo.Text.Trim();
            string nm = tbxImNm.Text.Trim();
            string jbti = tbxImJbti.Text.Trim();
            string zip = tbxImZip.Text.Trim();
            string addr = tbxImAddr.Text.Trim();
            string tel = tbxImTel.Text.Trim();
            string fax = tbxImFax.Text.Trim();
            string cell = tbxImCell.Text.Trim();
            string email = tbxImEmail.Text.Trim();
            string invcd = ddlInvCd.SelectedItem.Value;
            string taxtp = ddlTaxTp.SelectedItem.Value;
            string fgitri = ddlFgItri.SelectedItem.Value;
            string contno = Request.QueryString["NewContNo"];

            myIn.UpdateInvMfr(contno, imseq, mfrno, nm, jbti, addr, zip, tel, fax, cell, email, invcd, taxtp, fgitri);

            Bind_NewInvMfr(contno);

            ClearForm();

            //顯示新增，隱藏修改
            btnAddIm.Visible = true;
            btnUpdateFreeBk.Visible = false;
            btnCancelFreeBk.Visible = false;
        }

        protected void btnCancelFreeBk_Click(object sender, EventArgs e)
        {
            ClearForm();

            //顯示新增，隱藏修改
            btnAddIm.Visible = true;
            btnUpdateFreeBk.Visible = false;
            btnCancelFreeBk.Visible = false;
        }


    }

}
