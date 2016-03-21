using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Order
{
    public partial class CheckList : System.Web.UI.Page
    {
        CheckList_DB myCheck = new CheckList_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbxDate1.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
                tbxDate2.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
            }
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            string date1, date2;
            date1 = tbxDate1.Text.Substring(0, 4) + tbxDate1.Text.Substring(5, 2) + tbxDate1.Text.Substring(8, 2);
            date2 = tbxDate2.Text.Substring(0, 4) + tbxDate2.Text.Substring(5, 2) + tbxDate2.Text.Substring(8, 2);
            DataSet ds1 = myCheck.SelectC1_order();
            DataView dv1 = ds1.Tables["c1_order"].DefaultView;
            dv1.RowFilter = "o_status='1' and (o_indate>='" + date1 + "' and o_indate<='" + date2 + "')";
            GVSearchCust.DataSource = dv1;
            GVSearchCust.DataBind();
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }
    }
}
