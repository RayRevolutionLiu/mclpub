using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class oresJudge : System.Web.UI.Page
    {
        ores_DB myores = new ores_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string ores_orescd = Request.Form["ores_orescd"];
                string ores_oresnm = Request.Form["ores_oresnm"];

                int intores_orescd = Convert.ToInt32(ores_orescd);
                DataSet ds1 = myores.Selectc1_ores();

                DataView dv = ds1.Tables[0].DefaultView;
                string Strfilter = " 1=1 AND ores_orescd = '" + ores_orescd.ToString().Trim() + "'";

                dv.RowFilter = Strfilter;

                if (dv.Count > 0)
                {
                    Response.Write("No!");
                }

                else
                {
                    myores.Insertc1_ores(ores_orescd, ores_oresnm);
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