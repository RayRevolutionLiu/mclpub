using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Web.UI.HtmlControls;

namespace mclpub.Order
{
    public partial class ShowOrder : System.Web.UI.Page
    {
        ShowOrder_DB myShow = new ShowOrder_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Context.Request.QueryString["id"];
                string type1 = Context.Request.QueryString["type1"];
                string seq = Context.Request.QueryString["seq"];
                DataSet ds1 = myShow.SelectAll();
                DataView dv1;
                dv1 = ds1.Tables["c1_order"].DefaultView;
                dv1.RowFilter = "o_syscd='C1' and o_custno='" + id + "' and o_otp1cd='" + type1 + "' and o_otp1seq='" + seq + "'";
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
                //付款方式
                DataSet ds2 = myShow.Selectpytp();
                ddlPayType.DataSource = ds2;
                ddlPayType.DataTextField = "pytp_nm";
                ddlPayType.DataValueField = "pytp_pytpcd";
                ddlPayType.DataBind();
                //訂購類別
                seq = Context.Request.QueryString["seq1"];
                DataSet ds3 = myShow.SelectC1_otp();
                DataView dv3 = ds3.Tables["c1_otp"].DefaultView;
                ddlOrderType2.DataSource = dv3;
                dv3.RowFilter = "otp_otp1cd='" + type1 + "'";
                ddlOrderType2.DataTextField = "otp_otp2nm";
                ddlOrderType2.DataValueField = "otp_otp2cd";
                ddlOrderType2.DataBind();
                if (type1 == "01")
                    tbxOrderType1.Text = "訂閱";
                if (type1 == "02")
                    tbxOrderType1.Text = "贈閱";
                if (type1 == "03")
                    tbxOrderType1.Text = "推廣";
                else if (type1 == "09")
                {
                    seq = Context.Request.QueryString["seq"];
                    tbxOrderType1.Text = "零售";
                    ddlOrderType2.Visible = false;
                }
                //訂單來源
                DataSet ds4 = myShow.Selectc1_ores();
                ddlOrderRes.DataSource = ds4;
                ddlOrderRes.DataTextField = "ores_oresnm";
                ddlOrderRes.DataValueField = "ores_orescd";
                ddlOrderRes.DataBind();
                //書籍類別
                DataSet ds5 = myShow.Selectc1_obtp();
                DataView dv5 = ds5.Tables["c1_obtp"].DefaultView;
                ddlBookType.DataSource = dv5;
                dv5.RowFilter = "obtp_otp1cd='" + type1 + "' and fgitri=''";
                ddlBookType.DataTextField = "obtp_obtpnm";
                ddlBookType.DataValueField = "obtp_obtpcd";
                //				ddlBookType.DataValueField="nostr";
                ddlBookType.DataBind();

            }
        }
    }
}
