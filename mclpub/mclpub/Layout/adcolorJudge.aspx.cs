using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class adcolorJudge : System.Web.UI.Page
    {
        adcolor_DB myadcolor = new adcolor_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string clr_clrcd = Request.Form["clr_clrcd"];
                string clr_nm = Request.Form["clr_nm"];

                DataSet ds1 = myadcolor.Selectc2_clr();

                DataView dv = ds1.Tables[0].DefaultView;
                dv.RowFilter = "clr_clrcd = '" + clr_clrcd + "'";

                if (dv.Count > 0)
                {
                    Response.Write("No!");
                }
                else
                {
                    myadcolor.INSERTc2_clr(clr_clrcd, clr_nm);
                    Response.Write("Ok!");
                }
            }
            catch
            {
                Response.Write("Error!");
            }
            
        }
    }
}