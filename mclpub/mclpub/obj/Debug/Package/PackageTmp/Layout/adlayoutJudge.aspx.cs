using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class adlayoutJudge : System.Web.UI.Page
    {
        adlayout_DB myad = new adlayout_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string ltp_ltpcd = Request.Form["ltp_ltpcd"];
                string ltp_nm = Request.Form["ltp_nm"];

                DataSet ds1 = myad.Selectc2_ltp();

                DataView dv = ds1.Tables[0].DefaultView;
                dv.RowFilter = "ltp_ltpcd = '" + ltp_ltpcd + "'";

                if (dv.Count > 0)
                {
                    Response.Write("No!");
                }

                else
                {
                    myad.INSERTc2_clr(ltp_ltpcd, ltp_nm);
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