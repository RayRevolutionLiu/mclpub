using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class adpgsizeJudge : System.Web.UI.Page
    {
        adpgsize_DB myad = new adpgsize_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pgs_pgscd = Request.Form["pgs_pgscd"];
                string pgs_nm = Request.Form["pgs_nm"];

                DataSet ds1 = myad.Selectc2_pgsize();

                DataView dv = ds1.Tables[0].DefaultView;
                dv.RowFilter = "pgs_pgscd = '" + pgs_pgscd + "'";

                if (dv.Count > 0)
                {
                    Response.Write("No!");
                }

                else
                {
                    myad.INSERTc2_pgsize(pgs_pgscd, pgs_nm);
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