using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;

namespace mclpub.Pay
{
    public partial class PayTypeFM : System.Web.UI.Page
    {
        PayFMFilter_DB myPay = new PayFMFilter_DB();
        security se = new security();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Expires = 0;
                lblPayNo.Text = Context.Request.QueryString["pyno"];
                DataSet ds1 = myPay.Selectpy();
                DataView dv1 = ds1.Tables[0].DefaultView;
                dv1.RowFilter = "py_pyno='" + lblPayNo.Text.Trim() + "'";
                lblAmt.Text = dv1[0].Row["py_amt"].ToString();
                lblDate.Text = dv1[0].Row["py_date"].ToString();
                //付款方式
                DataSet ds2 = myPay.Selectpytp();
                ddlPayType.DataSource = ds2;
                ddlPayType.DataTextField = "pytp_nm";
                ddlPayType.DataValueField = "pytp_pytpcd";
                ddlPayType.DataBind();
                ddlPayType.Items.FindByValue(dv1[0].Row["py_pytpcd"].ToString()).Selected = true;
                //				ddlPayType.SelectedIndex=int.Parse(dv1[0].Row["py_pytpcd"].ToString())-1;
                PayTypeChange();
                //繳款資料
                string strbuf;
                switch (ddlPayType.SelectedItem.Value)
                {
                    case "02":
                        tbxChkno.Value = dv1[0].Row["py_chkno"].ToString();
                        tbxChkbnm.Value = dv1[0].Row["py_chkbnm"].ToString();
                        strbuf = dv1[0].Row["py_chkdate"].ToString();
                        tbxChkdate.Value = strbuf.Substring(0, 4) + "/" + strbuf.Substring(4, 2) + "/" + strbuf.Substring(6, 2);
                        break;
                    case "03":
                        tbxMoseq.Value = dv1[0].Row["py_moseq"].ToString();
                        tbxMoitem.Value = dv1[0].Row["py_moitem"].ToString();
                        break;
                    case "04":
                        tbxWaccno.Value = dv1[0].Row["py_waccno"].ToString();
                        strbuf = dv1[0].Row["py_wdate"].ToString();
                        tbxWdate.Value = strbuf.Substring(0, 4) + "/" + strbuf.Substring(4, 2) + "/" + strbuf.Substring(6, 2);
                        tbxWbcd.Value = dv1[0].Row["py_wbcd"].ToString();
                        break;
                    case "05":
                        rblCctp.SelectedIndex = int.Parse(dv1[0].Row["py_cctp"].ToString()) - 1;
                        strbuf = dv1[0].Row["py_ccno"].ToString();
                        tbxCcno1.Value = strbuf.Substring(0, 4);
                        tbxCcno2.Value = strbuf.Substring(4, 4);
                        tbxCcno3.Value = strbuf.Substring(8, 4);
                        tbxCcno4.Value = strbuf.Substring(12, 4);
                        tbxCcauthcd.Value = dv1[0].Row["py_ccauthcd"].ToString();
                        strbuf = dv1[0].Row["py_ccvdate"].ToString();
                        tbxYear.Value = strbuf.Substring(0, 4);
                        tbxMonth.Value = strbuf.Substring(4, 2);
                        strbuf = dv1[0].Row["py_ccdate"].ToString();
                        tbxCcDate.Value = strbuf.Substring(0, 4) + "/" + strbuf.Substring(4, 2) + "/" + strbuf.Substring(6, 2);
                        break;
                }

            }
        }

        private void PayTypeChange()
        {
            switch (ddlPayType.SelectedItem.Value)
            {
                case "01":
                case "06":
                case "07":
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    break;
                case "02":
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    break;
                case "03":
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    break;
                case "04":
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                    Panel4.Visible = false;
                    break;
                case "05":
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = true;
                    break;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                SaveToPy();
                Update_c1_order_pytpcd();
                JavaScript.AlertMessageRedirect(this.Page, "繳款處理已完成", "PayFMFilter.aspx");
            }
            catch(Exception ex)
            {
                JavaScript.AlertMessageRedirect(this.Page, ex.Message.ToString(), "../Default.aspx");
            }
        }

        private void SaveToPy()
        {

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"UPDATE dbo.py SET py_pyno = @py_pyno, py_amt = @py_amt, py_pytpcd = @py_pytpcd, py_date = @py_date, py_moseq = @py_moseq, py_moitem = @py_moitem");
                sb.Append(@", py_chkno = @py_chkno, py_chkbnm = @py_chkbnm, py_chkdate = @py_chkdate, py_waccno = @py_waccno, py_wdate = @py_wdate, py_wbcd = @py_wbcd");
                sb.Append(@", py_ccno = @py_ccno, py_cctp = @py_cctp, py_ccauthcd = @py_ccauthcd, py_ccvdate = @py_ccvdate, py_ccdate = @py_ccdate, py_fgprinted = @py_fgprinted");
                sb.Append(@", py_syscd = @py_syscd, py_pysdate = @py_pysdate, py_pysseq = @py_pysseq, py_pysitem = @py_pysitem WHERE (py_pyno = @Original_py_pyno)");

                SqlCommand sqlInsertComPy = myPay.UpdatePy_DB(sb.ToString());

                //繳款單檔 py


                sqlInsertComPy.Parameters.AddWithValue("@py_pyno", lblPayNo.Text.Trim());
                sqlInsertComPy.Parameters.AddWithValue("@Original_py_pyno", lblPayNo.Text.Trim());
                sqlInsertComPy.Parameters.AddWithValue("@py_amt", lblAmt.Text.Trim());
                sqlInsertComPy.Parameters.AddWithValue("@py_pytpcd", ddlPayType.SelectedItem.Value.Trim());
                sqlInsertComPy.Parameters.AddWithValue("@py_date", lblDate.Text);
                sqlInsertComPy.Parameters.AddWithValue("@py_fgprinted", "0");
                sqlInsertComPy.Parameters.AddWithValue("@py_chkno", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_chkbnm", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_chkdate", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_moseq", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_moitem", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_waccno", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_wdate", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_wbcd", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_ccno", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_cctp", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_ccauthcd", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_ccvdate", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_syscd", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_ccdate", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_pysdate", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_pysseq", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_pysitem", "");

                switch (ddlPayType.SelectedItem.Value)
                {
                    case "01":
                    case "06":
                    case "07":
                        break;
                    case "02":
                        sqlInsertComPy.Parameters["@py_chkno"].Value = tbxChkno.Value;
                        sqlInsertComPy.Parameters["@py_chkbnm"].Value = tbxChkbnm.Value;
                        sqlInsertComPy.Parameters["@py_chkdate"].Value = tbxChkdate.Value.Substring(0, 4) + tbxChkdate.Value.Substring(5, 2) + tbxChkdate.Value.Substring(8, 2);
                        break;
                    case "03":
                        sqlInsertComPy.Parameters["@py_moseq"].Value = tbxMoseq.Value;
                        sqlInsertComPy.Parameters["@py_moitem"].Value = tbxMoitem.Value;
                        break;
                    case "04":
                        sqlInsertComPy.Parameters["@py_waccno"].Value = tbxWaccno.Value;
                        sqlInsertComPy.Parameters["@py_wdate"].Value = tbxWdate.Value.Substring(0, 4) + tbxWdate.Value.Substring(5, 2) + tbxWdate.Value.Substring(8, 2);
                        sqlInsertComPy.Parameters["@py_wbcd"].Value = tbxWbcd.Value;
                        break;
                    case "05":
                        sqlInsertComPy.Parameters["@py_ccno"].Value = tbxCcno1.Value + tbxCcno2.Value + tbxCcno3.Value + tbxCcno4.Value;
                        sqlInsertComPy.Parameters["@py_cctp"].Value = rblCctp.SelectedItem.Value;
                        sqlInsertComPy.Parameters["@py_ccauthcd"].Value = tbxCcauthcd.Value;
                        if (tbxMonth.Value.Length < 2)
                            tbxMonth.Value = "0" + tbxMonth.Value;
                        sqlInsertComPy.Parameters["@py_ccvdate"].Value = tbxYear.Value + tbxMonth.Value;
                        sqlInsertComPy.Parameters["@py_ccdate"].Value = tbxCcDate.Value.Substring(0, 4) + tbxCcDate.Value.Substring(5, 2) + tbxCcDate.Value.Substring(8, 2);
                        break;
                }

                sqlInsertComPy.Connection.Open();
                sqlInsertComPy.ExecuteNonQuery();
                sqlInsertComPy.Connection.Close();
            }
            catch (Exception ex)
            {
                JavaScript.AlertMessageRedirect(this.Page, ex.Message.ToString(), "../Default.aspx");
                return;
            }
        }


        private void Update_c1_order_pytpcd()
        {
            XmlDocument XmlDoc;
            XmlDoc = new System.Xml.XmlDocument();

            XmlNode ItemMain;//=XmlDoc.SelectSingleNode("/root");
            XmlNode ItemOrder;//=XmlDoc.SelectSingleNode("/root/訂單");
            string nostr;
            string strbuf = Context.Request.QueryString["no"];
            DataSet ds3 = myPay.SelectC1_order();
            DataView dv3 = ds3.Tables[0].DefaultView;

            for (int i = 0; i < (strbuf.Length / 8); i++)
            {
                nostr = strbuf.Substring(i * 8, 8);
                dv3.RowFilter = "o_syscd='C1' and o_iano='" + nostr + "'";
                if (dv3.Count > 0)
                {
                    XmlDoc.LoadXml(dv3[0].Row["o_xmldata"].ToString());
                    ItemMain = XmlDoc.SelectSingleNode("/root");
                    ItemOrder = XmlDoc.SelectSingleNode("/root/訂單");
                    ItemOrder["付款方式"].FirstChild.InnerText = ddlPayType.SelectedItem.Value.Trim();

                    myPay.UpdateC1_Order(ddlPayType.SelectedItem.Value.Trim(), ItemMain.OuterXml, "C1", nostr);
                }
            }
        }

        protected void ddlPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PayTypeChange();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}