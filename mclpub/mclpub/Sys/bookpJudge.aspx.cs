using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class bookpJudge : System.Web.UI.Page
    {
        bookp_DB myBook = new bookp_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string ddlbkp_bkcd = Request.Form["ddlbkp_bkcd"];
                string bkp_date = Request.Form["bkp_date"];
                string bkp_pno = Request.Form["bkp_pno"];
                int intPno = Convert.ToInt32(bkp_pno);
                
                DataSet ds1 = myBook.Selectbookp();

                DataView dv = ds1.Tables[0].DefaultView;
                string Strfilter = " 1=1 AND bkp_bkcd = '" + ddlbkp_bkcd + "' AND bkp_date = '" + bkp_date + "' AND bkp_pno='" + bkp_pno + "'";

                dv.RowFilter = Strfilter;

                if (dv.Count > 0)
                {
                    Response.Write("No!");
                }

                else
                {
                    myBook.Insertbook(ddlbkp_bkcd, bkp_date, bkp_pno);
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