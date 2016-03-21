using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class pgnoJudge : System.Web.UI.Page
    {
        pgno_DB mypgno = new pgno_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string ddlBkcd = Request.Form["ddlBkcd"];
               
                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds2 = mypgno.Selectc2_pgnoNEW();
                DataView dv2 = ds2.Tables[0].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr2 = "1=1";
                rowfilterstr2 = rowfilterstr2 + " AND pg_bkcd='" + ddlBkcd + "'";
                dv2.RowFilter = rowfilterstr2;

                if (dv2.Count > 0)
                {
                    Response.Write("No!");
                    return;
                }
                else
                {
                    InsertToDB();
                }
            }
            catch
            {
                Response.Write("Error!");
            }

        }

        private void InsertToDB()
        {
            // 抓出畫面上的值
            string ddlBkcd = Request.Form["ddlBkcd"];
            string tbxStartPageNo = Request.Form["tbxStartPageNo"];

            mypgno.INSERTC2_pgno(ddlBkcd, tbxStartPageNo);

            Response.Write("Ok!");
        }
		
    }
}