using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Web.UI.HtmlControls;

namespace mclpub.Sys
{
    public partial class S_OrderForm : System.Web.UI.Page
    {
        OrderForm_DB myOrder = new OrderForm_DB();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string id = Context.Request.QueryString["id"];
                string type1 = Request.QueryString["type1"];
                if (type1 != "01" && type1 != "02" && type1 != "03" && type1 != "09")
                {
                    JavaScript.AlertMessageRedirect(this.Page, "參數不正確", "../Default.aspx");
                    return;
                }
                string seq = Context.Request.QueryString["seq"];
                //付款方式
                DataSet ds = myOrder.SelectPytp();
                ddlPayType.DataSource = ds;
                ddlPayType.DataTextField = "pytp_nm";
                ddlPayType.DataValueField = "pytp_pytpcd";
                ddlPayType.DataBind();
                //訂戶編號
                lblInvoiceid.Text = id;
                hiddenID.Value = id;
                //訂購類別
                hiddenType1.Value = type1;
                if (type1 == "01")
                {
                    DataSet ds2 = myOrder.SelectC1_otp();
                    DataView dv2 = ds2.Tables[0].DefaultView;
                    ddlOrderType2.DataSource = dv2;
                    dv2.RowFilter = "otp_otp1cd='" + type1 + "'";
                    ddlOrderType2.DataTextField = "otp_otp2nm";
                    ddlOrderType2.DataValueField = "otp_otp2cd";
                    ddlOrderType2.DataBind();
                    tbxOrderType1.Text = "訂閱";
                }
                else if (type1 == "09")
                {
                    tbxOrderType1.Text = "零售";
                    ddlOrderType2.Visible = false;
                }
                //前一筆訂單資料
                DataSet ds3 = myOrder.SelectC1_order();
                DataView dv3;
                if (seq != "000")
                {
                    dv3 = ds3.Tables["c1_order"].DefaultView;
                    dv3.RowFilter = "o_syscd='C1' and o_custno='" + id + "' and o_otp1cd='" + type1 + "' and o_otp1seq='" + seq + "'";
                    XmlNode xmlItem;
                    XmlDocument xmldoc = new XmlDocument();
                    if (dv3.Count > 0)
                    {
                        //						tbxMfrno.Text=dv3[0].Row["o_mfrno"].ToString();
                        tbxInvoiceName.Text = dv3[0].Row["o_inm"].ToString().Trim();
                        tbxInvoiceJob.Text = dv3[0].Row["o_ijbti"].ToString().Trim();
                        tbxTel.Text = dv3[0].Row["o_itel"].ToString().Trim();
                        tbxFax.Text = dv3[0].Row["o_ifax"].ToString().Trim();
                        tbxCell.Text = dv3[0].Row["o_icell"].ToString().Trim();
                        tbxEmail.Text = dv3[0].Row["o_iemail"].ToString().Trim();
                        tbxPostCode.Text = dv3[0].Row["o_izip"].ToString().Trim();
                        tbxAddress.Text = dv3[0].Row["o_iaddr"].ToString().Trim();
                        hiddenPreXml.Value = dv3[0].Row["o_xmldata"].ToString().Trim();
                        xmldoc.LoadXml(hiddenPreXml.Value);
                        xmlItem = xmldoc.SelectSingleNode("/root/收件人資料");
                        //收件人資料
                        hiddenRec.Value = xmlItem.OuterXml;
                    }
                }

                dv3 = ds3.Tables["c1_order"].DefaultView;
                dv3.RowFilter = "o_syscd='C1' and o_custno='" + id + "' and o_otp1cd='" + type1 + "'";
                string str1 = "";
                string str2 = "";
                if (dv3.Count > 0)
                {
                    str1 += dv3[0].Row["o_syscd"].ToString();
                    str1 += dv3[0].Row["o_custno"].ToString();
                    str1 += dv3[0].Row["o_otp1cd"].ToString();
                    if (type1 == "01")
                        str2 = Convert.ToString(Convert.ToInt32(dv3[0].Row["cust_otp1seq1"]) + 1);
                    else if (type1 == "09")
                        str2 = Convert.ToString(Convert.ToInt32(dv3[0].Row["cust_otp1seq9"]) + 1);
                    int j = 3 - str2.Length;
                    for (int i = 0; i < j; i++)
                        str2 = "0" + str2;
                }
                else
                {
                    str1 = str1 + "C1" + id + type1;
                    str2 = "001";
                }
                //				string str2=((int)(dv3.Count+1)).ToString();
                //訂單流水號
                lblOrderNo.Text = str1 + str2;
                hiddenOrderNo.Value = str1 + str2;
                //收件人資料
                //				DataSet ds4 = new DataSet("收件人資料");
                //				this.sqlSelectCommand4.CommandText += " where or_syscd='C1' and or_custno='"+id+
                //													"' and or_otp1cd='"+type1+"' and or_otp1seq='"+seq+"'";
                //				this.sqlDataAdapter4.Fill(ds4, "收件人明細");
                //				DataView dv4=ds4.Tables["收件人明細"].DefaultView;
                //				if (dv4.Count>0)
                //					hiddenRec.Value=ds4.GetXml();
                //書籍類別
                DataSet ds5 = myOrder.SelectC1_obtpJoinProj();
                hiddenBook.Value = ds5.GetXml();
                //				text1.Value=hiddenBook.Value;
                DataView dv5 = ds5.Tables[0].DefaultView;
                dv5.RowFilter = "obtp_otp1cd='" + type1 + "' and fgitri=''";
                ddlBookType.DataSource = dv5;
                ddlBookType.DataTextField = "obtp_obtpnm";
                ddlBookType.DataValueField = "obtp_obtpcd";
                //				ddlBookType.DataValueField="nostr";
                ddlBookType.DataBind();
                //新舊訂戶註記
                DataSet ds6 = myOrder.SelectC1_cust();
                DataView dv6 = ds6.Tables[0].DefaultView;
                dv6.RowFilter = "cust_custno = '" + id + "'";
                tbxMfrno.Text = dv6[0].Row["cust_mfrno"].ToString().Trim();
                lblName.Text = dv6[0].Row["cust_nm"].ToString().Trim();
                lblCoName.Text = dv6[0].Row["mfr_inm"].ToString().Trim();
                hiddenCoName.Value = dv6[0].Row["mfr_inm"].ToString().Trim();
                hiddenCoAddr.Value = dv6[0].Row["mfr_iaddr"].ToString().Trim();
                //				Response.Write(dv6[0].Row["mfr_iaddr"].ToString().Trim());
                //				Response.Write(hiddenAddress.Value);
                hiddenFgoi.Value = dv6[0].Row["cust_fgoi"].ToString();
                hiddenFgoe.Value = dv6[0].Row["cust_fgoe"].ToString();
                tbxOrderDate.Value = System.DateTime.Today.ToString("yyyy/MM/dd");
                //訂單來源
                DataSet ds7 = myOrder.SelectC1_ores();
                ddlOrderRes.DataSource = ds7;
                ddlOrderRes.DataTextField = "ores_oresnm";
                ddlOrderRes.DataValueField = "ores_orescd";
                ddlOrderRes.DataBind();
                //承辦業務員
                DataSet ds8 = myOrder.Selectsrspn();
                //				dv8.RowFilter="srspn_atype <> 'A'";
                ddlSpn.DataSource = ds8;
                ddlSpn.DataTextField = "srspn_cname";
                ddlSpn.DataValueField = "srspn_empno";
                ddlSpn.DataBind();


                //因為SERVER不知道為什麼不能讀取實體XML 只好轉成字串再讀取
                XmlDocument xd = new XmlDocument();
                xd.Load(Server.MapPath("~/Order/EmptyOrder.xml"));
                EmptyOrder.Value = xd.OuterXml.ToString();

                XmlDocument xd1 = new XmlDocument();
                xd1.Load(Server.MapPath("~/Order/EmptyList.xml"));
                EmptyList.Value = xd1.OuterXml.ToString();
            }
        }
    }
}