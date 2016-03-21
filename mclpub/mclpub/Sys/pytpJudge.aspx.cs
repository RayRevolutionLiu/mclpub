using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class pytpJudge : System.Web.UI.Page
    {
        pytp_DB mypytp = new pytp_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pytp_pytpcd = Request.Form["pytp_pytpcd"];
                string pytp_nm = Request.Form["pytp_nm"];

                DataSet ds1 = mypytp.Selectpytp();

                DataView dv = ds1.Tables[0].DefaultView;
                string Strfilter = " 1=1 AND pytp_pytpcd = '" + pytp_pytpcd.ToString().Trim() + "'";

                dv.RowFilter = Strfilter;

                if (dv.Count > 0)
                {
                    Response.Write("No!");
                }

                else
                {
                    mypytp.Insertpytp(pytp_pytpcd, pytp_nm);
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