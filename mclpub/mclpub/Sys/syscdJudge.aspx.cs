using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class syscdJudge : System.Web.UI.Page
    {
        syscd_DB myitp = new syscd_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sys_syscd = Request.Form["sys_syscd"];
                string sys_nm = Request.Form["sys_nm"];
                string sys_deptcd = Request.Form["sys_deptcd"];

                DataSet ds1 = myitp.Selectsyscd();

                DataView dv = ds1.Tables[0].DefaultView;
                string Strfilter = " 1=1 AND sys_syscd = '" + sys_syscd.ToString().Trim() + "'";

                dv.RowFilter = Strfilter;

                if (dv.Count > 0)
                {
                    Response.Write("No!");
                }

                else
                {
                    myitp.Insertsyscd(sys_syscd, sys_nm, sys_deptcd);
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