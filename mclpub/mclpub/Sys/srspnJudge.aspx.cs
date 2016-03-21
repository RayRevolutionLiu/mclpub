using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class srspnJudge : System.Web.UI.Page
    {
        srspn_DB mysrspn = new srspn_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string srspn_empnoAdd = Request.Form["srspn_empnoAdd"];
                string srspn_cnameAdd = Request.Form["srspn_cnameAdd"];
                string srspn_telAdd = Request.Form["srspn_telAdd"];
                string srspn_atypeAdd = Request.Form["srspn_atypeAdd"];
                string OrgAbbNameAdd = Request.Form["OrgAbbNameAdd"];
                string srspn_deptcdAdd = Request.Form["srspn_deptcdAdd"];
                string srspn_datedAdd = Request.Form["srspn_datedAdd"];

                DataSet ds1 = mysrspn.Selectsrspn();

                DataView dv = ds1.Tables[0].DefaultView;
                string Strfilter = " 1=1 AND srspn_empno = '" + srspn_empnoAdd.ToString().Trim() + "'";

                dv.RowFilter = Strfilter;

                if (dv.Count > 0)
                {
                    Response.Write("No!");
                }

                else
                {
                    mysrspn.Insertsrspn(srspn_empnoAdd, srspn_cnameAdd, srspn_telAdd, srspn_atypeAdd, OrgAbbNameAdd, srspn_deptcdAdd, srspn_datedAdd);
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