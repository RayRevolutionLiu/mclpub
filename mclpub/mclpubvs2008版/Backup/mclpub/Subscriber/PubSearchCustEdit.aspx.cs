using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Subscriber
{
    public partial class PubSearchCustEdit : System.Web.UI.Page
    {
        PubSearchCustEdit_DB myPub = new PubSearchCustEdit_DB();
        PubSearchCust_DB myPubS = new PubSearchCust_DB();
        Cust_Edit_DB myCust = new Cust_Edit_DB();//CheckBox綁定用

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbxJob.Visible = false;
                BindData();

                if (Request.QueryString["custnoID"] != null)
                {
                    string id = Request.QueryString["custnoID"].ToString();
                    DataTable dtAll = myPub.SelectAllC1_Cust(id);
                    DataTable dtCompName = myPubS.SelectComp(dtAll.Rows[0]["cust_mfrno"].ToString(), "");//把統一編號帶入 找出公司名稱帶入
                    tbxCompanyname.Text = dtCompName.Rows[0]["mfr_inm"].ToString().Trim();
                    tbxMfrno.Text = dtCompName.Rows[0]["mfr_mfrno"].ToString().Trim();

                    lblInvoiceid.Text = dtAll.Rows[0]["cust_custno"].ToString();
                    tbxCustname.Text = dtAll.Rows[0]["cust_nm"].ToString();
                    tbxTel.Text = dtAll.Rows[0]["cust_tel"].ToString();
                    tbxRegDate.Text = dtAll.Rows[0]["cust_regdate"].ToString();
                    tbxRegDate.Enabled = false;//註冊日期不可改
                    tbxLastModdate.Text = dtAll.Rows[0]["cust_moddate"].ToString();
                    tbxCell.Text = dtAll.Rows[0]["cust_tel"].ToString();
                    tbxFax.Text = dtAll.Rows[0]["cust_fax"].ToString();

                    if (dtAll.Rows[0]["cust_jbti"].ToString().Trim() == "先生")
                    {
                        rblJob.SelectedIndex = 0;
                    }
                    else if (dtAll.Rows[0]["cust_jbti"].ToString().Trim() == "小姐")
                    {
                        rblJob.SelectedIndex = 1;
                    }
                    else
                    {
                        rblJob.SelectedIndex = 2;
                        tbxJob.Visible = true;
                        tbxJob.Text = dtAll.Rows[0]["cust_jbti"].ToString();
                    }

                    tbxEmail.Text = dtAll.Rows[0]["cust_email"].ToString();

                    string strbtp = dtAll.Rows[0]["cust_btpcd"].ToString();
                    string stritp = dtAll.Rows[0]["cust_itpcd"].ToString();
                    TopTitleName.Text = "修改雜誌叢書訂戶資料";
                    TitleName.Text = "修改雜誌叢書訂戶資料";
                    submitBtn.Text = "確定修改";
                    this.Page.Controls.Add(new LiteralControl("<script>document.getElementById('Button1').setAttribute('value', '放棄修改');</script>"));

                    ////選出營業項目
                    if (strbtp.Length > 0)
                    {
                        int j;
                        for (int i = 0; i < strbtp.Length; i += 2)
                        {
                            j = int.Parse(strbtp.Substring(i, 2)) - 1;
                            cblbtp.Items[j].Selected = true;
                            //((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblbtp")).Items[j].Selected = true;
                        }
                    }
                    ////選出領域項目
                    if (stritp.Length > 0)
                    {
                        int j;
                        for (int i = 0; i < stritp.Length; i += 2)
                        {
                            j = int.Parse(stritp.Substring(i, 2)) - 1;
                            cblitp.Items[j].Selected = true;
                            //((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblitp")).Items[j].Selected = true;
                        }
                    }

                }
                else
                {
                    tbxRegDate.Text = DateTime.Now.ToString("yyyyMMdd");
                    DataTable dt = myPub.CreateNewCustno();

                    int j = Int32.Parse(dt.Rows[0]["maxcustno"].ToString()) + 1;
                    string str1 = j.ToString();
                    j = 6 - str1.Length;
                    for (int i = 0; i < j; i++)
                        str1 = "0" + str1;
                    lblInvoiceid.Text = str1;
                }


            }
        }

        public void BindData()
        {
            DataTable dt1 = myCust.SelectChKBoxs1();
            DataTable dt2 = myCust.SelectChKBoxs2();

            cblbtp.DataSource = dt2;
            cblbtp.DataTextField = "btp_nm";
            cblbtp.DataValueField = "btp_btpcd";
            cblbtp.DataBind();

            cblitp.DataSource = dt1;
            cblitp.DataTextField = "itp_nm";
            cblitp.DataValueField = "itp_itpcd";
            cblitp.DataBind();
        }

        protected void rblJob_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblJob.SelectedItem.Value == "自訂")
            {
                tbxJob.Visible = true;
                tbxJob.Text = "請輸入";
            }
            else
            {
                tbxJob.Visible = false;
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

            string cblstr1, cblstr2;
            cblstr1 = cblstr2 = "";

            //存訂戶營業檔1_custbtp
            for (int i = 0; i < cblbtp.Items.Count; i++)
            {
                if (cblbtp.Items[i].Selected)
                {
                    if (i + 1 < 10)
                        cblstr1 = cblstr1 + "0" + (i + 1).ToString();
                    else
                        cblstr1 = cblstr1 + (i + 1).ToString();
                }
                //						cblstr1=cblstr1+"0"+(i+1).ToString();
            }

            //存訂戶領域檔1_custitp
            for (int i = 0; i < cblitp.Items.Count; i++)
            {
                if (cblitp.Items[i].Selected)
                {
                    if (i + 1 < 10)
                        cblstr2 = cblstr2 + "0" + (i + 1).ToString();
                    else
                        cblstr2 = cblstr2 + (i + 1).ToString();
                }
                //						cblstr2=cblstr2+"0"+(i+1).ToString();
            }

            string jbti ="";
            if (rblJob.SelectedItem.Value == "自訂")
            {
                jbti = tbxJob.Text.Trim();
            }
            else
            {
                jbti = rblJob.SelectedItem.Text;
            }

            if (Request.QueryString["custnoID"] != null)
            {
                myPub.EditCustEdit(cblstr1, lblInvoiceid.Text, tbxCustname.Text.Trim(), jbti, tbxMfrno.Text, tbxTel.Text.Trim(), tbxFax.Text.Trim(), tbxCell.Text.Trim(), tbxEmail.Text.Trim(),
                    tbxRegDate.Text, DateTime.Now.ToString("yyyyMMdd"), cblstr2);
                JavaScript.AlertMessageRedirect(this.Page, "修改成功!", "PubSearchCust.aspx");
            }
            else
            {
                //存訂戶檔1_cust
                myPub.InsertCustEdit(cblstr1, lblInvoiceid.Text, tbxCustname.Text.Trim(), jbti, tbxMfrno.Text, tbxTel.Text.Trim(), tbxFax.Text.Trim(), tbxCell.Text.Trim(),
                    tbxEmail.Text.Trim(), tbxRegDate.Text, DateTime.Now.ToString("yyyyMMdd"), "0", "0", "000", "000", "000", "000", cblstr2);
                JavaScript.AlertMessageRedirect(this.Page, "新增成功!", "PubSearchCust.aspx");
            }


        }

        private string CheckData()
        {
            string msg = "";
            DataTable dt = myPubS.SelectComp(tbxMfrno.Text.Trim(), tbxCompanyname.Text.Trim());
            if (dt.Rows.Count <= 0)
            {
                msg += "無此廠商資料,請先新增廠商資料!\\r\\n";
            }

            return msg;
        }
    }
}
