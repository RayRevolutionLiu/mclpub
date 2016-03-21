using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Subscriber
{
    public partial class AddComp : System.Web.UI.Page
    {
        AddComp_DB myAdC = new AddComp_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    //底下先把最上面的類別隱藏
                    Label_type.Visible = false;
                    ddlmfr_type.Visible = false;
                    PSddlmfr_type.Visible = false;
                    this.Page.Controls.Add(new LiteralControl("<script>document.getElementById('TopTr').setAttribute('style', 'display:none');</script>"));

                    //再來把輸入統一編號的TXBOX隱藏
                    mfr_mfrno.Visible = false;
                    //RegularExpression關掉
                    RegularExpressionValidator1.Visible = false;
                    RequiredFieldValidator1.Visible = false;

                    //改掉btn的名稱
                    submitBtn.Text = "確定更新";
                    this.Page.Controls.Add(new LiteralControl("<script>document.getElementById('Button1').setAttribute('value', '放棄修改');</script>"));

                    string id = Request.QueryString["ID"].ToString();
                    DataTable dt = myAdC.Checkmfrno(id);

                    DataView dv = dt.DefaultView;

                    if (dv.Count <= 0)
                    {
                        Application["ErrorMsg"] = "無此筆資料";
                        Response.Redirect("errorPage.aspx");
                    }
                    else
                    {
                        string mfrno = dv[0]["mfr_mfrno"].ToString();
                        string inm = dv[0]["mfr_inm"].ToString();
                        string iaddr = dv[0]["mfr_iaddr"].ToString();
                        string izip = dv[0]["mfr_izip"].ToString();
                        string respnm = dv[0]["mfr_respnm"].ToString();
                        string respjbti = dv[0]["mfr_respjbti"].ToString();
                        string tel = dv[0]["mfr_tel"].ToString();
                        string fax = dv[0]["mfr_fax"].ToString();
                        string regdate = dv[0]["mfr_regdate"].ToString();
                        string foreign = dv[0]["mfr_foreign"].ToString();

                        Labelddlmfr_type.Text = mfrno.Trim();
                        mfr_inm.Text = inm.Trim();
                        mfr_addr.Text = iaddr.Trim();
                        mfr_izip.Text = izip.Trim();
                        mfr_respnm.Text = respnm.Trim();
                        mfr_respjbti.Text = respjbti.Trim();
                        mfr_tel.Text = tel.Trim();
                        mfr_fax.Text = fax.Trim();
                        createdate.Text = regdate.Trim();
                        if (foreign == "Y")
                        {
                            foreignChk.Checked = true;
                        }
                    }

                }
                else
                {
                    createdate.Text = DateTime.Now.ToString("yyyyMMdd");

                }
            }

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string foreign = "N";
            if (foreignChk.Checked == true)
            {
                foreign = "Y";
            }

            if (Request.QueryString["ID"] != null)
            {
                myAdC.UpdateComp(Labelddlmfr_type.Text.Trim(), mfr_inm.Text.Trim(), mfr_addr.Text.Trim(), mfr_izip.Text.Trim(),
                    mfr_respnm.Text.Trim(), mfr_respjbti.Text.Trim(), mfr_tel.Text.Trim(), mfr_fax.Text.Trim(), createdate.Text.Trim(), Request.QueryString["ID"].ToString(), foreign);
                JavaScript.AlertMessageRedirect(this.Page, "修改成功!", "Company.aspx");
            }
            else
            {
                string msg = CheckData();
                if (msg.Length > 0)
                {
                    this.Page.Controls.Add(new LiteralControl("<script>alert('" + msg + "');</script>"));
                    return;
                }

                myAdC.InsertNewComp(mfr_mfrno.Text.Trim(), mfr_inm.Text.Trim(), mfr_addr.Text.Trim(), mfr_izip.Text.Trim(),
                    mfr_respnm.Text.Trim(), mfr_respjbti.Text.Trim(), mfr_tel.Text.Trim(), mfr_fax.Text.Trim(), createdate.Text.Trim(),foreign);

                JavaScript.AlertMessageRedirect(this.Page, "新增成功!", "Company.aspx");
            }
        }


        private string CheckData()
        {
            string msg = "";
            DataTable dt = myAdC.Checkmfrno("");
            DataView dv = dt.DefaultView;
            dv.RowFilter = "mfr_mfrno = '" + mfr_mfrno.Text.Trim() + "'";
            if (dv.Count > 0)
            {
                msg += "此統一編號已經存在!\\r\\n";
            }

            //廠商統一編號驗證
            if (ddlmfr_type.SelectedItem.Value.ToString() == "A")
            {
                string invno = mfr_mfrno.Text.Trim();
                string check = "12121241";
                int sum = 0;
                int sumA = 1001;

                for (int i = 0; i < 8; i++)
                {
                    string sum1 = Convert.ToString(Convert.ToUInt32(invno[i].ToString()) * Convert.ToInt32(check[i].ToString()));

                    if (Convert.ToInt32(sum1) < 10)
                    {
                        sum1 = "0" + sum1.ToString();
                    }

                    sum1 = Convert.ToString(Convert.ToInt32(sum1[0].ToString()) + Convert.ToInt32(sum1[1].ToString()));

                    if (Convert.ToInt32(sum1) > 9)
                    {
                        sum = sum + 0;
                        sumA = sum + 1;
                    }

                    if (Convert.ToInt32(sum1) <= 9)
                    {
                        sum = sum + Convert.ToInt32(sum1);

                        if (sumA != 1000)
                        {
                            sumA = sumA + Convert.ToInt32(sum1);
                        }
                    }
                }

                if (sum % 10 != 0 && sumA % 10 != 0)
                {
                    msg += "您的廠商統一編號錯誤!\\r\\n";
                }
            }

            if (ddlmfr_type.SelectedItem.Value.ToString() == "B")
            {
                string invno = mfr_mfrno.Text.Trim();
                if (!Common.CheckIdentificationId(invno))
                {
                    msg += "請輸入【正確的身分證字號】\\r\\n";
                }
            }



            return msg;
        }

        protected void ddlmfr_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ddlmfr_type.SelectedItem.Value.ToString();

            if (id == "A")
            {
                this.lblmfr_mfrno.Text = "*廠商統一編號:";
                this.mfr_mfrno.Text = "";
                this.mfr_mfrno.ReadOnly = false;
                RegularExpressionValidator1.Visible = true;
                this.mfr_mfrno.BackColor = System.Drawing.Color.White;
                this.lblmfr_inm.Text = "*發票抬頭:";
            }

            if (id == "B")
            {
                this.lblmfr_mfrno.Text = "*身份證字號:";
                this.mfr_mfrno.Text = "";
                this.mfr_mfrno.ReadOnly = false;
                RegularExpressionValidator1.Visible = false;
                this.mfr_mfrno.BackColor = System.Drawing.Color.White;
                this.lblmfr_inm.Text = "*姓名:";
            }

            if (id == "C")
            {
                this.lblmfr_mfrno.Text = "*資料編號:";
                string strAssignedContNo = "";
                DataTable dt = myAdC.Drop3rdSelect();
                DataView dv = dt.DefaultView;
                if (dv.Count > 0 && dv[0]["C1"].ToString() != "0")
                {
                    string MaxCountNo = dv[0]["MaxCountNo"].ToString().Trim();
                    string MaxCountNoInt = MaxCountNo.Substring(2, 5);

                    strAssignedContNo = Convert.ToString(Convert.ToInt32(MaxCountNoInt) + 1);

                    int ZeroLength = 5 - strAssignedContNo.Length;

                    for (int i = 0; i < ZeroLength; i++)
                    {
                        strAssignedContNo = "0" + strAssignedContNo;
                    }
                    strAssignedContNo = "AA" + strAssignedContNo;
                }

                else
                {
                    strAssignedContNo += "AA00001";
                }

                this.mfr_mfrno.Text = strAssignedContNo;
                this.mfr_mfrno.ReadOnly = true;
                RegularExpressionValidator1.Visible = false;
                this.mfr_mfrno.BackColor = System.Drawing.Color.Gainsboro;

                this.lblmfr_inm.Text = "*發票抬頭:";
            }
        }
    }
}
