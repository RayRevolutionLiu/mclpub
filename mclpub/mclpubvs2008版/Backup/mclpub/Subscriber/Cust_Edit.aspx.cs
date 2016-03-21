using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Subscriber
{
    public partial class AddCust : System.Web.UI.Page
    {
        Cust_Edit_DB myCust = new Cust_Edit_DB();

        private static string global_custno;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();
            }
        }

        private void InitData()
        {
            //#region 時間預設今天
            //#endregion
            if (Request.QueryString["ID"] == null && Request.QueryString["editID"] == null)
            {
                Application["ErrorMsg"] = "參數錯誤";
                Response.Redirect("~/errorPage.aspx");
            }
            else
            {
                #region 榜定抬頭
                DataTable dt2 = myCust.SelectTitle();
                this.ddlcust_inm.DataTextField = "mfr_inm";
                this.ddlcust_inm.DataValueField = "mfr_mfrno";
                this.ddlcust_inm.DataSource = dt2;
                this.ddlcust_inm.DataBind();
                #endregion

                #region 榜定業務員
                DataTable dtSeles = myCust.SelecSeles();
                ddlEmpNo.DataSource = dtSeles;
                ddlEmpNo.DataTextField = "srspn_cname";
                ddlEmpNo.DataValueField = "srspn_empno";
                ddlEmpNo.DataBind();
                #endregion

                #region 榜定客戶領域代碼
                DataTable dt4 = myCust.SelectChKBoxs1();
                this.cblcust_itpcd.DataTextField = "itp_nm";
                this.cblcust_itpcd.DataValueField = "itp_itpcd";
                this.cblcust_itpcd.DataSource = dt4;
                this.cblcust_itpcd.DataBind();
                #endregion

                #region 榜定客戶營業代碼
                DataTable dt5 = myCust.SelectChKBoxs2();
                this.cblcust_btpcd.DataTextField = "btp_nm";
                this.cblcust_btpcd.DataValueField = "btp_btpcd";
                this.cblcust_btpcd.DataSource = dt5;
                this.cblcust_btpcd.DataBind();
                #endregion

                #region 榜定客戶閱讀代碼(跟領域代碼一樣)
                DataTable dt6 = myCust.SelectChKBoxs1();
                this.cblcust_rtpcd.DataTextField = "itp_nm";
                this.cblcust_rtpcd.DataValueField = "itp_itpcd";
                this.cblcust_rtpcd.DataSource = dt6;
                this.cblcust_rtpcd.DataBind();
                #endregion

                //新增
                if (Request.QueryString["ID"] != null)
                {
                    string id = Request.QueryString["ID"].ToString();
                    TitleName.Text = "新增客戶資料";
                    showWhere.Text = "新增客戶資料";

                    #region 產生客戶編號
                    string strAssignedContNo = "";
                    DataTable dt = myCust.AddNum();
                    if (dt.Rows.Count <= 0)
                    {
                        Application["ErrorMsg"] = "無此筆資料";
                        Response.Redirect("~/errorPage.aspx");
                    }

                    if (dt.Rows.Count > 0 && dt.Rows[0]["C1"].ToString() != "0")
                    {
                        if (Convert.ToInt32((Convert.ToInt32(dt.Rows[0]["MaxCountNo"]) + 1)) < 10)
                        {
                            strAssignedContNo = Convert.ToString("00000" + (Convert.ToInt32(dt.Rows[0]["MaxCountNo"]) + 1));
                        }
                        else if (Convert.ToInt32((Convert.ToInt32(dt.Rows[0]["MaxCountNo"]) + 1)) < 100)
                        {
                            strAssignedContNo = Convert.ToString("0000" + (Convert.ToInt32(dt.Rows[0]["MaxCountNo"]) + 1));
                        }
                        else if (Convert.ToInt32((Convert.ToInt32(dt.Rows[0]["MaxCountNo"]) + 1)) < 1000)
                        {
                            strAssignedContNo = Convert.ToString("000" + (Convert.ToInt32(dt.Rows[0]["MaxCountNo"]) + 1));
                        }
                        else if (Convert.ToInt32((Convert.ToInt32(dt.Rows[0]["MaxCountNo"]) + 1)) < 10000)
                        {
                            strAssignedContNo = Convert.ToString("00" + (Convert.ToInt32(dt.Rows[0]["MaxCountNo"]) + 1));
                        }
                        else if (Convert.ToInt32((Convert.ToInt32(dt.Rows[0]["MaxCountNo"]) + 1)) < 100000)
                        {
                            strAssignedContNo = Convert.ToString("0" + (Convert.ToInt32(dt.Rows[0]["MaxCountNo"]) + 1));
                        }
                        else
                        {
                            strAssignedContNo = Convert.ToString((Convert.ToInt32(dt.Rows[0]["MaxCountNo"]) + 1));
                        }
                    }
                    else
                    {
                        strAssignedContNo += "000001";
                    }

                    cust_custno.Text = strAssignedContNo;
                    #endregion

                    #region 把如果廠商有輸入的電話傳真帶入
                    DataTable dt3 = myCust.SelectOthers(id);

                    if (dt3.Rows.Count <= 0)
                    {
                        Application["ErrorMsg"] = "無此筆資料";
                        Response.Redirect("~/errorPage.aspx");
                    }


                    string mfrno = dt3.Rows[0]["mfr_mfrno"].ToString();
                    string tel = dt3.Rows[0]["mfr_tel"].ToString();
                    string fax = dt3.Rows[0]["mfr_fax"].ToString();

                    for (int i = 0; i < ddlcust_inm.Items.Count; i++)
                    {
                        if (ddlcust_inm.Items[i].Value == mfrno)
                        {
                            ddlcust_inm.SelectedIndex = i;
                        }
                    }

                    cust_mfrno.Text = mfrno.Trim();
                    cust_tel.Text = tel.Trim();
                    cust_fax.Text = fax.Trim();
                    #endregion

                    #region 時間預設今天
                    this.cust_regdate.Text = DateTime.Now.ToString("yyyyMMdd");
                    this.cust_moddate.Text = DateTime.Now.ToString("yyyyMMdd");
                    #endregion

                }

                //編輯
                if (Request.QueryString["editID"] != null)
                {
                    //把按鈕名稱改變
                    TitleName.Text = "修改客戶資料";
                    showWhere.Text = "修改客戶資料";
                    submitBtn.Text = "確定修改";
                    this.Page.Controls.Add(new LiteralControl("<script>document.getElementById('Button1').setAttribute('value', '放棄修改');</script>"));

                    string id = Request.QueryString["editID"].ToString();
                    DataTable dt = myCust.SelectAllForEdit(id);

                    string custno = dt.Rows[0]["cust_custno"].ToString().Trim();
                    string nm = dt.Rows[0]["cust_nm"].ToString().Trim();
                    string jbti = dt.Rows[0]["cust_jbti"].ToString().Trim();
                    string mfrno = dt.Rows[0]["cust_mfrno"].ToString().Trim();
                    string tel = dt.Rows[0]["cust_tel"].ToString().Trim();
                    string fax = dt.Rows[0]["cust_fax"].ToString().Trim();
                    string cell = dt.Rows[0]["cust_cell"].ToString().Trim();
                    string email = dt.Rows[0]["cust_email"].ToString().Trim();
                    string regdate = dt.Rows[0]["cust_regdate"].ToString().Trim();
                    //string moddate = dv[0]["cust_moddate"].ToString();
                    string oldcustno = dt.Rows[0]["cust_oldcustno"].ToString().Trim();
                    string itpcd = dt.Rows[0]["cust_itpcd"].ToString().Trim();
                    string btpcd = dt.Rows[0]["cust_btpcd"].ToString().Trim();
                    string rtpcd = dt.Rows[0]["cust_rtpcd"].ToString().Trim();

                    cust_custno.Text = custno.Trim();
                    cust_nm.Text = nm.Trim();
                    cust_jbti.Text = jbti.Trim();

                    for (int i = 0; i < ddlcust_inm.Items.Count; i++)
                    {
                        if (ddlcust_inm.Items[i].Value.Trim() == mfrno)
                        {
                            ddlcust_inm.SelectedIndex = i;
                        }
                    }

                    cust_mfrno.Text = mfrno.Trim();
                    cust_tel.Text = tel.Trim();
                    cust_fax.Text = fax.Trim();
                    cust_cell.Text = cell.Trim();
                    cust_email.Text = email.Trim();
                    cust_regdate.Text = regdate.Trim();
                    //cust_moddate.Text=moddate.Trim();
                    cust_oldcustno.Text = oldcustno.Trim();
                    //cust_itpcd.Text=itpcd.Trim();
                    //cust_btpcd.Text=btpcd.Trim();
                    //cust_rtpcd.Text=rtpcd.Trim();

                    cust_moddate.Text = DateTime.Now.ToString("yyyyMMdd");

                    if (itpcd.Length > 0)
                    {
                        int j;
                        for (int i = 0; i < itpcd.Length; i += 2)
                        {
                            j = int.Parse(itpcd.Substring(i, 2)) - 1;
                            cblcust_itpcd.Items[j].Selected = true;
                        }
                    }

                    if (btpcd.Length > 0)
                    {
                        int j;
                        for (int i = 0; i < btpcd.Length; i += 2)
                        {
                            j = int.Parse(btpcd.Substring(i, 2)) - 1;
                            cblcust_btpcd.Items[j].Selected = true;
                        }
                    }

                    if (rtpcd.Length > 0)
                    {
                        int j;
                        for (int i = 0; i < rtpcd.Length; i += 2)
                        {
                            j = int.Parse(rtpcd.Substring(i, 2)) - 1;
                            cblcust_rtpcd.Items[j].Selected = true;
                        }
                    }

                    if (ddlEmpNo.Items.FindByValue(dt.Rows[0]["cust_srspn_empno"].ToString()) != null)
                        ddlEmpNo.Items.FindByValue(dt.Rows[0]["cust_srspn_empno"].ToString()).Selected = true;

                    global_custno = custno.Trim();//把資料庫內的客戶編號放到全域變數 好去跟欄位內的比較
                }
            }

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string msg = CheckData();
            if (msg.Length > 0)
            {
                this.Page.Controls.Add(new LiteralControl("<script>alert('" + msg + "');</script>"));
                return;
            }

            string stritpcd = "";
            for (int i = 0; i < this.cblcust_itpcd.Items.Count; i++)
            {
                if (this.cblcust_itpcd.Items[i].Selected)
                {
                    stritpcd += this.cblcust_itpcd.Items[i].Value;
                }
            }

            string strbtpcd = "";
            for (int i = 0; i < this.cblcust_btpcd.Items.Count; i++)
            {
                if (this.cblcust_btpcd.Items[i].Selected)
                {
                    strbtpcd += this.cblcust_btpcd.Items[i].Value;
                }
            }

            string strrtpcd = "";
            for (int i = 0; i < this.cblcust_rtpcd.Items.Count; i++)
            {
                if (this.cblcust_rtpcd.Items[i].Selected)
                {
                    strrtpcd += this.cblcust_rtpcd.Items[i].Value;
                }
            }


            if (Request.QueryString["ID"] != null)
            {
                myCust.InsertNewCust(cust_custno.Text.Trim(), cust_nm.Text.Trim(), cust_jbti.Text.Trim(), cust_mfrno.Text.Trim(), cust_tel.Text.Trim(),
                    cust_fax.Text.Trim(), cust_cell.Text.Trim(), cust_email.Text.Trim(), cust_regdate.Text.Trim(), cust_moddate.Text, cust_oldcustno.Text.Trim(),
                    stritpcd, strrtpcd, strbtpcd, ddlEmpNo.SelectedValue.ToString());
                JavaScript.AlertMessageRedirect(this.Page, "新增成功!", "Customer.aspx");
            }
            if (Request.QueryString["editID"] != null)
            {
                myCust.EditCust(cust_custno.Text.Trim(), cust_nm.Text.Trim(), cust_jbti.Text.Trim(), cust_mfrno.Text.Trim(), cust_tel.Text.Trim(),
                    cust_fax.Text.Trim(), cust_cell.Text.Trim(), cust_email.Text.Trim(), cust_regdate.Text.Trim(), cust_moddate.Text, cust_oldcustno.Text.Trim(),
                    stritpcd, strrtpcd, strbtpcd, ddlEmpNo.SelectedValue.ToString(), Request.QueryString["editID"].ToString());
                JavaScript.AlertMessageRedirect(this.Page, "更新成功!", "Customer.aspx");
            }
                
        }


        private string CheckData()
        {
            string msg = "";
            DataTable dt = myCust.JudgeDoubleOrNot(cust_custno.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                if (Request.QueryString["ID"] != null)
                {
                    msg += "此客戶編號已經存在!\\r\\n";
                }
                if (Request.QueryString["editID"] != null)
                {
                    if (dt.Rows[0]["cust_custno"].ToString() != global_custno)
                    {
                        msg += "此客戶編號已經存在!\\r\\n";
                    }
                }              
            }

            return msg;
        }

        protected void ddlcust_inm_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ddlcust_inm.SelectedItem.Value.ToString();

            DataTable dt = myCust.SelectOthers(id);
            cust_mfrno.Text = dt.Rows[0]["mfr_mfrno"].ToString();
            cust_tel.Text = dt.Rows[0]["mfr_tel"].ToString();
            cust_fax.Text = dt.Rows[0]["mfr_fax"].ToString();

        }
    }
}
