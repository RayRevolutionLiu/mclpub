using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace mclpub.Pay
{
    public partial class PayListPrint : System.Web.UI.Page
    {
        PayListPrint_DB myPay = new PayListPrint_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                int myYear = System.DateTime.Today.Year;
                int j = 0;
                for (int i = myYear - 1; i <= myYear; i++)
                {
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    j++;
                }
                ddlYear.SelectedIndex = j - 1;
                int myMonth = System.DateTime.Today.Month;
                ddlMonth.SelectedIndex = myMonth - 1;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;
            DataSet ds = myPay.Selectpyseq();
            DataView dv2 = ds.Tables[0].DefaultView;
            dv2.RowFilter = "pys_pysdate='" + ddlYear.SelectedItem.Value.Trim() + ddlMonth.SelectedItem.Value.Trim() + "'";
            DataGrid1.DataSource = dv2;
            DataGrid1.DataBind();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;
            DataSet ds = myPay.Selectpyseq();
            DataView dv2 = ds.Tables[0].DefaultView;
            dv2.RowFilter = "pys_pysdate='" + ddlYear.SelectedItem.Value.Trim() + ddlMonth.SelectedItem.Value.Trim() + "'";
            DataGrid1.DataSource = dv2;
            DataGrid1.DataBind();
        }
    }
}