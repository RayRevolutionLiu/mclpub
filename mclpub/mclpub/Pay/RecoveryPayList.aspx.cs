using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Pay
{
    public partial class RecoveryPayList : System.Web.UI.Page
    {
        PayListPrint_DB myPay = new PayListPrint_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
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
            DataSet ds1 = myPay.Selectpyseq();
            DataView dv1 = ds1.Tables[0].DefaultView;
            dv1.RowFilter = "pys_pysdate='" + ddlYear.SelectedItem.Value.Trim() + ddlMonth.SelectedItem.Value.Trim() + "'";
            DataGrid1.DataSource = dv1;
            DataGrid1.DataBind();
        }
    }
}