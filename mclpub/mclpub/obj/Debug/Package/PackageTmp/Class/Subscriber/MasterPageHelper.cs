using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Text;

namespace mclpub
{
    public class MasterPageHelper
    {
        public MasterPageHelper()
        {
        }

        public static void RegisterMPGet(MasterPage mp)
        {
            List<string> lstCph = new List<string>();
            lstCph.Add(mp.ClientID);
            searchContentPlaceHolder(mp.Page.Form, lstCph);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<script type=""text/javascript"">function afa_mpget(objId) {    var inp = document.getElementById(objId);");
            foreach (string cphId in lstCph)
            {
                sb.AppendFormat(
            " if (!inp) inp = document.getElementById(\"{0}_\" + objId);\n",
                    cphId);
            }
            sb.Append("return inp;\n}\n</script>");
            Literal js = new Literal();
            js.Text = sb.ToString();
            mp.Page.Header.Controls.AddAt(0, js);

        }

        public static void searchContentPlaceHolder(Control ctrl, List<string> lst)
        {
            if (ctrl is ContentPlaceHolder)
                lst.Add(ctrl.ClientID);
            else if (ctrl.HasControls())
                foreach (Control c in ctrl.Controls)
                    searchContentPlaceHolder(c, lst);
        }
    }
}
