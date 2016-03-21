using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

namespace mclpub.Order
{
    public partial class OrderFM : System.Web.UI.Page
    {
        OrderFM_DB myOrder = new OrderFM_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Put user code to initialize the page here
                string status = "";
                string id = Context.Request.QueryString["id"];
                string type1 = Request.QueryString["type1"];
                string seq = Context.Request.QueryString["seq"];
                DataSet ds1 = myOrder.SelectC1_order();
                DataView dv1;
                dv1 = ds1.Tables["c1_order"].DefaultView;
                dv1.RowFilter = "o_syscd='C1' and o_custno='" + id + "' and o_otp1cd='" + type1 + "' and o_otp1seq='" + seq + "'";
                //				dv1.RowFilter="o_syscd='C1' and o_custno='"+id+"' and o_otp1cd='"+type1+"'";
                XmlNode xmlItem;
                XmlDocument xmldoc = new XmlDocument();
                if (dv1.Count > 0)
                {
                    hiddenXML.Value = dv1[0].Row["o_xmldata"].ToString();
                    xmldoc.LoadXml(hiddenXML.Value);
                    xmlItem = xmldoc.SelectSingleNode("/root/收件人資料");
                    //收件人資料
                    hiddenRec.Value = xmlItem.OuterXml;
                    //					textarea1.Value=xmldoc.OuterXml;
                    status = dv1[0].Row["o_status"].ToString().Trim();
                    lblModifyDate.Text = dv1[0].Row["o_moddate"].ToString().Trim();
                }
                //付款方式
                DataSet ds2 = myOrder.Select_pytp();
                ddlPayType.DataSource = ds2;
                ddlPayType.DataTextField = "pytp_nm";
                ddlPayType.DataValueField = "pytp_pytpcd";
                ddlPayType.DataBind();
                //訂購類別
                hiddenType1.Value = type1;
                //seq = Context.Request.QueryString["seq1"];
                DataSet ds3 = myOrder.Selectc1_otp();
                DataView dv3 = ds3.Tables["c1_otp"].DefaultView;
                ddlOrderType2.DataSource = dv3;
                dv3.RowFilter = "otp_otp1cd='" + type1 + "'";
                ddlOrderType2.DataTextField = "otp_otp2nm";
                ddlOrderType2.DataValueField = "otp_otp2cd";
                ddlOrderType2.DataBind();
                if (type1 == "01")
                {
                    tbxOrderType1.Text = "訂閱";
                    lblTitle.Text = "訂閱訂單";
                }
                else if (type1 == "09")
                {
                    seq = Context.Request.QueryString["seq"];
                    tbxOrderType1.Text = "零售";
                    ddlOrderType2.Visible = false;
                    lblTitle.Text = "零售訂單";
                }
                //訂單來源
                DataSet ds4 = myOrder.Selectc1_ores();
                ddlOrderRes.DataSource = ds4;
                ddlOrderRes.DataTextField = "ores_oresnm";
                ddlOrderRes.DataValueField = "ores_orescd";
                ddlOrderRes.DataBind();
                //書籍類別
                DataSet ds5 = myOrder.SelectXml();
                hiddenBook.Value = ds5.GetXml();

                DataView dv5 = ds5.Tables[0].DefaultView;
                dv5.RowFilter = "obtp_otp1cd='" + type1 + "' and fgitri=''";
                ddlBookType.DataSource = dv5;
                ddlBookType.DataTextField = "obtp_obtpnm";
                ddlBookType.DataValueField = "obtp_obtpcd";
                //				ddlBookType.DataValueField="nostr";
                ddlBookType.DataBind();
                //新舊訂戶註記
                DataSet ds6 = myOrder.Selectc1_cust();
                DataView dv6 = ds6.Tables["c1_cust"].DefaultView;
                dv6.RowFilter = "cust_custno = '" + id + "'";
                //				tbxMfrno.Text=dv6[0].Row["cust_mfrno"].ToString();
                lblName.Text = dv6[0].Row["cust_nm"].ToString();
                lblCoName.Text = dv6[0].Row["mfr_inm"].ToString();
                hiddenFgoi.Value = dv6[0].Row["cust_fgoi"].ToString();
                hiddenFgoe.Value = dv6[0].Row["cust_fgoe"].ToString();
                hiddenCoName.Value = dv6[0].Row["mfr_inm"].ToString().Trim();
                //承辦業務員
                DataSet ds7 = myOrder.Selectsrspn();
                DataView dv7 = ds7.Tables["srspn"].DefaultView;
                //				dv7.RowFilter="srspn_atype <> 'A'";
                dv7.RowFilter = "srspn_atype = 'B' OR srspn_atype = 'C'";
                ddlSpn.DataSource = dv7;
                ddlSpn.DataTextField = "cname";
                ddlSpn.DataValueField = "empno";
                ddlSpn.DataBind();
                //不允許修改之欄位
                if (status != "1")
                {
                    panel1.Enabled = false;
                    panel2.Enabled = false;
                    ddlPayType.Disabled = true;
                    tbxMfrno.Disabled = true;
                    tbxTel.Disabled = true;
                    tbxInvoiceName.Disabled = true;
                    tbxFax.Disabled = true;
                    tbxInvoiceJob.Disabled = true;
                    tbxCell.Disabled = true;
                    tbxEmail.Disabled = true;
                    tbxPostCode.Disabled = true;
                    tbxAddress.Disabled = true;
                    tbxAmt.Disabled = true;
                }
            }
        }
    }
}
