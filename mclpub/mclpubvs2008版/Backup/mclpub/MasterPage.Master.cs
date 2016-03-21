using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace mclpub
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //MasterPageHelper.RegisterMPGet(this);
            HtmlGenericControl objjQuery = new HtmlGenericControl("script");  
            objjQuery.Attributes.Add("language", "javascript");
            objjQuery.Attributes.Add("src", ResolveUrl("~/jquery/js/jquery-1.5.1.min.js"));
            this.Page.Header.Controls.Add(objjQuery);

            HtmlGenericControl objjQuery2 = new HtmlGenericControl("script");
            objjQuery2.Attributes.Add("language", "javascript");
            objjQuery2.Attributes.Add("src", ResolveUrl("~/Art/js/superfish.js"));
            this.Page.Header.Controls.Add(objjQuery2);

            HtmlGenericControl objjQuery3 = new HtmlGenericControl("script");
            objjQuery3.Attributes.Add("language", "javascript");
            objjQuery3.Attributes.Add("src", ResolveUrl("~/Art/js/jquery.bgiframe.min.js"));
            this.Page.Header.Controls.Add(objjQuery3);

            HtmlGenericControl objjQuery4 = new HtmlGenericControl("script");
            objjQuery4.Attributes.Add("language", "javascript");
            objjQuery4.Attributes.Add("src", ResolveUrl("~/jquery/development-bundle/external/jquery.bgiframe-2.1.2.js"));
            this.Page.Header.Controls.Add(objjQuery4);

            HtmlGenericControl objjQuery5 = new HtmlGenericControl("script");
            objjQuery5.Attributes.Add("language", "javascript");
            objjQuery5.Attributes.Add("src", ResolveUrl("~/jquery/development-bundle/ui/jquery.ui.core.js"));
            this.Page.Header.Controls.Add(objjQuery5);

            HtmlGenericControl objjQuery6 = new HtmlGenericControl("script");
            objjQuery6.Attributes.Add("language", "javascript");
            objjQuery6.Attributes.Add("src", ResolveUrl("~/jquery/development-bundle/ui/jquery.ui.widget.js"));
            this.Page.Header.Controls.Add(objjQuery6);

            HtmlGenericControl objjQuery7 = new HtmlGenericControl("script");
            objjQuery7.Attributes.Add("language", "javascript");
            objjQuery7.Attributes.Add("src", ResolveUrl("~/jquery/development-bundle/ui/jquery.ui.datepicker.js"));
            this.Page.Header.Controls.Add(objjQuery7);


            HtmlGenericControl objjQuery8 = new HtmlGenericControl("script");
            objjQuery8.Attributes.Add("language", "javascript");
            objjQuery8.Attributes.Add("src", ResolveUrl("~/Myjs/MyCommon.js"));
            this.Page.Header.Controls.Add(objjQuery8);

        }
    }
}
