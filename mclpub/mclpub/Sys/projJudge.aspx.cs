using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class projJudge : System.Web.UI.Page
    {
        proj_DB myproj = new proj_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sys_nm = Request.Form["sys_nm"];
                string bk_nm = Request.Form["bk_nm"];
                string fgitri_nm = Request.Form["fgitri_nm"];
                string proj_projno = Request.Form["proj_projno"];
                string proj_costctr = Request.Form["proj_costctr"];
                string proj_cont = Request.Form["proj_cont"];

                DataTable ds1 = myproj.Selectproj();

                DataView dv = ds1.DefaultView;
                string Strfilter = " 1=1 AND proj_syscd = '" + sys_nm.ToString().Trim() + "' AND proj_bkcd = '" + bk_nm.ToString().Trim() + "' AND proj_fgitri = '" + fgitri_nm.ToString().Trim() + "'";

                dv.RowFilter = Strfilter;

                if (dv.Count > 0)
                {
                    Response.Write("No!");
                }

                else
                {
                    myproj.Insertproj(sys_nm, bk_nm, fgitri_nm, proj_projno, proj_costctr, proj_cont);
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