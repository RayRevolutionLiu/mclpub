using System;
using System.Collections.Generic;
using System.Linq;
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
            XmlNode xmlItem;
            XmlDocument xmldoc;
            // Put user code to initialize the page here
            if (!IsPostBack)
            {
                Response.Expires = 0;
            }
        }
    }
}
