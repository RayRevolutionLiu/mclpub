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
    public partial class FreeFM : System.Web.UI.Page
    {
        FreeFM_DB myFree = new FreeFM_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Put user code to initialize the page here
                string id = Context.Request.QueryString["id"];
                string type1 = Context.Request.QueryString["type1"];
                string seq = Context.Request.QueryString["seq"];
                DataSet ds1 = myFree.SelectC1_order();
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
                }
                //訂購類別
                hiddenType1.Value = type1;
                seq = Context.Request.QueryString["seq1"];
                DataSet ds2 = myFree.Selectc1_otp();
                DataView dv2 = ds2.Tables["c1_otp"].DefaultView;
                ddlOrderType2.DataSource = dv2;
                dv2.RowFilter = "otp_otp1cd='" + type1 + "'";
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
                //訂單來源
                DataSet ds3 = myFree.Selectc1_ores();
                ddlOrderRes.DataSource = ds3;
                ddlOrderRes.DataTextField = "ores_oresnm";
                ddlOrderRes.DataValueField = "ores_orescd";
                ddlOrderRes.DataBind();
                //書籍類別
                DataSet ds4 = myFree.SelectXml();
                hiddenBook.Value = ds4.GetXml();

                DataView dv4 = ds4.Tables[0].DefaultView;
                ddlBookType.DataSource = dv4;
                dv4.RowFilter = "obtp_otp1cd='" + type1 + "' and fgitri=''";
                ddlBookType.DataTextField = "obtp_obtpnm";
                ddlBookType.DataValueField = "obtp_obtpcd";
                //				ddlBookType.DataValueField="nostr";
                ddlBookType.DataBind();
                //訂戶資料
                DataSet ds5 = myFree.Selectc1_cust();
                DataView dv5 = ds5.Tables["c1_cust"].DefaultView;
                dv5.RowFilter = "cust_custno = '" + id + "'";
                //				hiddenMfrno.Value=dv5[0].Row["cust_mfrno"].ToString();
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
