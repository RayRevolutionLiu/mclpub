using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class mtpJudge : System.Web.UI.Page
    {
        mtp_DB mymtp = new mtp_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string mtp_mtpcd = Request.Form["mtp_mtpcd"];
                string mtp_nm = Request.Form["mtp_nm"];

                DataSet ds1 = mymtp.Selectmtp();

                DataView dv = ds1.Tables[0].DefaultView;
                string Strfilter = " 1=1 AND mtp_mtpcd = '" + mtp_mtpcd.ToString().Trim() + "'";

                dv.RowFilter = Strfilter;

                if (dv.Count > 0)
                {
                    Response.Write("No!");
                }

                else
                {
                    mymtp.Insertmtp(mtp_mtpcd, mtp_nm);
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