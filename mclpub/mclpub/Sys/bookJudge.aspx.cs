using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class bookJudge : System.Web.UI.Page
    {
        book_DB myBook = new book_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string bk_bkcd = Request.Form["bk_bkcd"];
                string bk_nm = Request.Form["bk_nm"];

                DataSet ds1 = myBook.Selectbook();

                DataView dv = ds1.Tables[0].DefaultView;
                dv.RowFilter = "bk_bkcd = '" + bk_bkcd + "'";

                if (dv.Count > 0)
                {
                    Response.Write("No!");
                }

                else
                {
                    myBook.Insertbook(bk_bkcd,bk_nm);
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