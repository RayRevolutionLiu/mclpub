using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.SetAccount
{
    public partial class IA1QueryCont : System.Web.UI.Page
    {
        security sec = new security();
        IA1QueryCont_DB myia1 = new IA1QueryCont_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string contno = sec.decryptquerystring(Request.QueryString["ContNo"].ToString());
                    LoadContData(contno);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        #region 載入合約資料
        private void LoadContData(string contno)
        {
            if (contno.Trim() == "")
                throw new Exception("合約編號不可為空白");

            DataSet ds = myia1.GetSingleContractByContNo(contno);
            if (ds.Tables[0].Rows.Count>0)
            {
                DataTable dt = ds.Tables[0];
                lblContNo.Text = dt.Rows[0]["cont_contno"].ToString();

                switch (dt.Rows[0]["cont_conttp"].ToString().Trim())
                {
                    case "01":
                        lblContTp.Text = "一般";
                        break;
                    case "09":
                        lblContTp.Text = "推廣";
                        break;
                    default:
                        lblContTp.Text = "(無法辨識)";
                        break;
                }

                lblSignDate.Text = DateTime.ParseExact(dt.Rows[0]["cont_signdate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
                lblSDate.Text = DateTime.ParseExact(dt.Rows[0]["cont_sdate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
                lblEDate.Text = DateTime.ParseExact(dt.Rows[0]["cont_edate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
                lblPubTm.Text = dt.Rows[0]["cont_pubtm"].ToString();
                lblFreeTm.Text = dt.Rows[0]["cont_freetm"].ToString();
                lblTotAmt.Text = dt.Rows[0]["cont_totamt"].ToString();
                lblDisc.Text = dt.Rows[0]["cont_disc"].ToString();
                lblTotImgTm.Text = dt.Rows[0]["cont_totimgtm"].ToString();
                lblTotUrlTm.Text = dt.Rows[0]["cont_toturltm"].ToString();

                //Message
                lblContInfo.Text = "本合約基本資料";
                //				tblCont.Visible = true;

                //Load InvMfr
                Bind_ddlInvMfr(contno);

                //Load Advertisements



                LoadAdr(contno);
                MatchCheckBox();
                string imseq =Request.QueryString["ImSeq"].ToString();
                if (imseq != "00")
                {
                    ddlInvMfr.Items.FindByValue(imseq.Trim()).Selected = true;
                }
            }
            else
            {
                //Message
                lblContInfo.Text = "無此編號的合約資料，請確認合約編號";
                //				tblCont.Visible = false;
            }
        }
        #endregion

        #region 連結發票廠商下拉式選單
        private void Bind_ddlInvMfr(string contno)
        {

            string imseq = Request.QueryString["ImSeq"].ToString();
            DataSet ds = myia1.GetInvMfr(contno);
            DataRow dr;
            dr = ds.Tables[0].NewRow();
            dr["im_nm"] = "請選擇";
            dr["im_imseq"] = "00";
            ds.Tables[0].Rows.Add(dr);
            DataView dv = ds.Tables[0].DefaultView;

            ddlInvMfr.DataTextField = "im_nm";
            ddlInvMfr.DataValueField = "im_imseq";
            ddlInvMfr.DataSource = dv;
            ddlInvMfr.DataBind();
            //			if(imseq=="")
            //				ddlInvMfr.Items.FindByValue("00").Selected=true;
            //			else
            ddlInvMfr.Items.FindByValue(imseq.Trim()).Selected = true;
        }
        #endregion

        #region 載入合約的廣告落版資料
        private void LoadAdr(string contno)
        {
            if (contno.Trim().Length != 6)
            {
                JavaScript.AlertMessage(this.Page, "合約編號為空值或格式錯誤，請通知聯絡人");
                return;
            }

            DataSet ds = myia1.GetAdvertisements(contno);
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "adr_fginved <> '1'";
            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();

            if (dv.Count > 0)
            {
                lblAdrInfo.Text = "本合約廣告資料";
                DataGrid1.Visible = true;
                pnlOptions.Visible = true;
                MatchCheckBox();
                //				FormatAdr();
            }
            else
            {
                lblAdrInfo.Text = "本合約尚無廣告資料";
                DataGrid1.Visible = false;
                pnlOptions.Visible = false;
            }
        }
        #endregion

        #region 第一次讀入廣告落版資料時，把以前tag的落版標示出來
        private void MatchCheckBox()
        {
            //只有第一次載入才要做，所以要獨立出來
            for (int i = 0; i < DataGrid1.Rows.Count; i++)
            {
                if (DataGrid1.Rows[i].Cells[14].Text.Trim() == "v")
                {
                    ((CheckBox)DataGrid1.Rows[i].Cells[0].FindControl("CheckBox2")).Checked = true;
                }
            }
        }
        #endregion

        protected void DataGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[14].Visible = false;
                string imseq = Request.QueryString["ImSeq"].ToString();
                if (imseq != "00")
                {
                    if (e.Row.Cells[12].Text.Trim() == ddlInvMfr.SelectedItem.Text.Trim())
                    {
                        ((CheckBox)e.Row.Cells[0].FindControl("CheckBox2")).Enabled = true;
                        e.Row.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        //					((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Checked = false;
                        ((CheckBox)e.Row.Cells[0].FindControl("CheckBox2")).Enabled = false;
                        e.Row.ForeColor = System.Drawing.Color.Black;
                    }

                }

                //處理發票廠商名稱
                string transImSeq = "";
                try
                {
                    transImSeq = ddlInvMfr.Items.FindByValue(e.Row.Cells[12].Text).Text;
                    e.Row.Cells[12].Text = transImSeq;
                }
                catch
                {
                    throw new Exception("發票廠商欄位對應錯誤");
                }
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[14].Visible = false;
            }
        }

        protected void btnConfirmSelected_Click(object sender, EventArgs e)
        {
            int j = 0;
            for (int i = 0; i < DataGrid1.Rows.Count; i++)
            {
                if ((((CheckBox)DataGrid1.Rows[i].Cells[0].FindControl("CheckBox2")).Enabled == true) && (((CheckBox)DataGrid1.Rows[i].Cells[0].FindControl("CheckBox2")).Checked == true))
                {
                    myia1.UpdateAdrFginved(lblContNo.Text.Trim(), DataGrid1.Rows[i].Cells[1].Text.Trim(), DataGrid1.Rows[i].Cells[2].Text.Trim(), "v");
                    j++;
                }
                else if ((((CheckBox)DataGrid1.Rows[i].Cells[0].FindControl("CheckBox2")).Enabled == true) && (((CheckBox)DataGrid1.Rows[i].Cells[0].FindControl("CheckBox2")).Checked == false))
                {
                    myia1.UpdateAdrFginved(lblContNo.Text.Trim(), DataGrid1.Rows[i].Cells[1].Text.Trim(), DataGrid1.Rows[i].Cells[2].Text.Trim(), "");
                }
                //				else
                //					adr.UpdateAdrFginved(lblContNo.Text.Trim(), dgdAdr.Items[i].Cells[1].Text.Trim(), dgdAdr.Items[i].Cells[2].Text.Trim(), "");
            }
            if (j > 0)
                Response.Redirect("IA1ConfirmChecked.aspx?ContNo=" + sec.encryptquerystring(lblContNo.Text.Trim()) + "&Imseq=" + ddlInvMfr.SelectedItem.Value.Trim());
            else
                JavaScript.AlertMessage(this.Page, "您沒有選取落版資料"); return;
        }

        protected void ddlInvMfr_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < DataGrid1.Rows.Count; i++)
            {
                if (DataGrid1.Rows[i].Cells[12].Text == ddlInvMfr.SelectedItem.Text.Trim())
                {
                    ((CheckBox)DataGrid1.Rows[i].Cells[0].FindControl("CheckBox2")).Enabled = true;
                    DataGrid1.Rows[i].ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    //					((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Checked = false;
                    ((CheckBox)DataGrid1.Rows[i].Cells[0].FindControl("CheckBox2")).Enabled = false;
                    DataGrid1.Rows[i].ForeColor = System.Drawing.Color.Black;
                }
            }
        }
    }
}