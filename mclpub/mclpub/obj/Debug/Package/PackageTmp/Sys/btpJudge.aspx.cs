using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class btpJudge : System.Web.UI.Page
    {
        btp_DB myitp = new btp_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string btp_btpcd = Request.Form["btp_btpcd"];
                string btp_nm = Request.Form["btp_nm"];


                DataSet ds1 = myitp.Selectbtp();

                DataView dv = ds1.Tables[0].DefaultView;
                string Strfilter = " 1=1 AND btp_btpcd = '" + btp_btpcd.ToString().Trim() + "'";

                dv.RowFilter = Strfilter;

                if (dv.Count > 0)
                {
                    Response.Write("No!");
                }

                else
                {
                    myitp.Insertbtp(btp_btpcd, btp_nm);
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