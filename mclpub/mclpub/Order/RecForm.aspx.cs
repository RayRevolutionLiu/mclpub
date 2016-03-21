using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Web.UI.HtmlControls;

namespace mclpub.Order
{
    public partial class RecForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //XmlNode xmlItem;
            //XmlDocument xmldoc;
            // Put user code to initialize the page here
            if (!IsPostBack)
            {
                Response.Expires = 0;

                //因為SERVER不知道為什麼不能讀取實體XML 只好轉成字串再讀取
                XmlDocument xd = new XmlDocument();
                xd.Load(Server.MapPath("~/Order/RecAddr.xml"));
                //Response.Write(xd.OuterXml.ToString());
                //return;
                RecAddr.Value = xd.OuterXml.ToString();
                
            }
        }
    }
}
