using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class itpJudge : System.Web.UI.Page
    {
        itp_DB myitp = new itp_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string itp_itpcd = Request.Form["itp_itpcd"];
                string itp_nm = Request.Form["itp_nm"];


                DataSet ds1 = myitp.Selectitp();

                DataView dv = ds1.Tables[0].DefaultView;
                string Strfilter = " 1=1 AND itp_itpcd = '" + itp_itpcd.ToString().Trim() + "'";

                dv.RowFilter = Strfilter;

                if (dv.Count > 0)
                {
                    Response.Write("No!");
                }

                else
                {
                    myitp.Insertitp(itp_itpcd, itp_nm);
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