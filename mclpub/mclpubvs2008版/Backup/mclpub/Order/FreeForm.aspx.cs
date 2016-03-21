using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Configuration;
using System.Data;

namespace mclpub.Order
{
    public partial class FreeForm : System.Web.UI.Page
    {
        FreeForm_DB myFree = new FreeForm_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //
                // Evals true first time browser hits the page
                //
                string id = Context.Request.QueryString["id"];
                string type1 = Context.Request.QueryString["type1"];
                string seq = Context.Request.QueryString["seq"];
                //訂購日期
                tbxOrderDate.Value = System.DateTime.Today.ToString("yyyy/MM/dd");
                //訂戶編號
                lblInvoiceid.Text = id;
                hiddenID.Value = id;
                //訂購類別
                hiddenType1.Value = type1;
                DataSet ds1 = myFree.Selectc1_otp();
                DataView dv1 = ds1.Tables["c1_otp"].DefaultView;
                ddlOrderType2.DataSource = dv1;
                dv1.RowFilter = "otp_otp1cd='" + type1 + "'";
                ddlOrderType2.DataTextField = "otp_otp2nm";
                ddlOrderType2.DataValueField = "otp_otp2cd";
                ddlOrderType2.DataBind();
                if (type1 == "02")
                {
                    tbxOrderType1.Text = "贈閱";
                    lblTitle.Text = "贈閱訂單";
                }
                else if (type1 == "03")
                {
                    tbxOrderType1.Text = "推廣";
                    lblTitle.Text = "推廣訂單";
                }
                //前一筆訂單資料
                DataSet ds2 = myFree.SelectC1_order();
                DataView dv2;
                if (seq != "000")
                {
                    dv2 = ds2.Tables["c1_order"].DefaultView;
                    dv2.RowFilter = "o_syscd='C1' and o_custno='" + id + "' and o_otp1cd='" + type1 + "' and o_otp1seq='" + seq + "'";
                    XmlNode xmlItem;
                    XmlDocument xmldoc = new XmlDocument();
                    if (dv2.Count > 0)
                    {
                        //						tbxMfrno.Text=dv3[0].Row["o_mfrno"].ToString();
                        hiddenPreXml.Value = dv2[0].Row["o_xmldata"].ToString();
                        xmldoc.LoadXml(hiddenPreXml.Value);
                        xmlItem = xmldoc.SelectSingleNode("/root/收件人資料");
                        //收件人資料
                        hiddenRec.Value = xmlItem.OuterXml;
                    }
                }

                dv2 = ds2.Tables["c1_order"].DefaultView;
                dv2.RowFilter = "o_syscd='C1' and o_custno='" + id + "' and o_otp1cd='" + type1 + "'";
                string str1 = "";
                string str2 = "";
                if (dv2.Count > 0)
                {
                    str1 += dv2[0].Row["o_syscd"].ToString();
                    str1 += dv2[0].Row["o_custno"].ToString();
                    str1 += dv2[0].Row["o_otp1cd"].ToString();
                    if (type1 == "02")
                        str2 = Convert.ToString(Convert.ToInt32(dv2[0].Row["cust_otp1seq2"]) + 1);
                    else if (type1 == "03")
                        str2 = Convert.ToString(Convert.ToInt32(dv2[0].Row["cust_otp1seq3"]) + 1);
                    int j = 3 - str2.Length;
                    for (int i = 0; i < j; i++)
                        str2 = "0" + str2;
                }
                else
                {
                    str1 = str1 + "C1" + id + type1;
                    str2 = "001";
                }
                //				string str2=((int)(dv2.Count+1)).ToString();
                //訂單流水號
                lblOrderNo.Text = str1 + str2;
                hiddenOrderNo.Value = str1 + str2;
                //書籍類別
                DataSet ds3 = myFree.SelectXml();
                hiddenBook.Value = ds3.GetXml();

                DataView dv3 = ds3.Tables[0].DefaultView;
                ddlBookType.DataSource = dv3;
                dv3.RowFilter = "obtp_otp1cd='" + type1 + "' and fgitri=''";
                ddlBookType.DataTextField = "obtp_obtpnm";
                ddlBookType.DataValueField = "obtp_obtpcd";
                //				ddlBookType.DataValueField="nostr";
                ddlBookType.DataBind();
                //訂單來源
                DataSet ds4 = myFree.Selectc1_ores();
                ddlOrderRes.DataSource = ds4;
                ddlOrderRes.DataTextField = "ores_oresnm";
                ddlOrderRes.DataValueField = "ores_orescd";
                ddlOrderRes.DataBind();
                //統一編號
                DataSet ds5 = myFree.Selectc1_cust();
                DataView dv5 = ds5.Tables["c1_cust"].DefaultView;
                dv5.RowFilter = "cust_custno = '" + id + "'";
                hiddenMfrno.Value = dv5[0].Row["cust_mfrno"].ToString();
                lblName.Text = dv5[0].Row["cust_nm"].ToString();
                lblCoName.Text = dv5[0].Row["mfr_inm"].ToString();
                hiddenCoName.Value = dv5[0].Row["mfr_inm"].ToString().Trim();
                hiddenCoAddress.Value = dv5[0].Row["mfr_iaddr"].ToString().Trim();
                //承辦業務員
                DataSet ds6 = myFree.Selectsrspn();
                DataView dv6 = ds6.Tables["srspn"].DefaultView;
                dv6.RowFilter = "srspn_atype <> 'A'";
                ddlSpn.DataSource = dv6;
                ddlSpn.DataTextField = "srspn_cname";
                ddlSpn.DataValueField = "srspn_empno";
                ddlSpn.DataBind();
            }
        }
    }
}
