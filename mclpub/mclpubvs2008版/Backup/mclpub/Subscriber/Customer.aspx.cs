using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Subscriber
{
    public partial class Customer : System.Web.UI.Page
    {
        Customer_DB myCust = new Customer_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "CustGV";
            if (!IsPostBack)
            {
                BindGrid();
            }

        }

        public void BindGrid()
        {
            string atype = Account.GetAccInfo().srspn_atype.ToString();
            DataTable dt = myCust.SelectCustomerTable(TXcust_nm.Text.Trim(), TXcust_custno.Text.Trim(), TXmfr_inm.Text.Trim(),TXcust_mfrno.Text.Trim(),TXcust_tel.Text.Trim(),TXcust_srspn_empno.Text.Trim(), atype, Account.GetAccInfo().srspn_empno.ToString());
            this.UCPager1.Dtdata = dt;
            this.UCPager1.UCPageBind();
            //Response.Write(Account.GetAccInfo().srspn_atype.ToString());

        }

        protected void CustGVOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                // e.Row.Cells[1].Visible = false;
                Button d = (Button)e.Row.Cells[12].FindControl("Button2");
                //LinkButton d = (LinkButton)e.Row.Cells[8].FindControl("LinkButton1");
                d.OnClientClick = "javascript:return confirm('確定刪除？')";
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
                //e.Row.Cells[1].Visible = false;
            }

        }

        protected void RedrectEdit(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ide = thisRow.Cells[0].Text;
            Response.Redirect(string.Format("Cust_Edit.aspx?editID={0}", ide));

        }

        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ide = thisRow.Cells[0].Text;
            myCust.DelCust(ide);
            BindGrid();
            JavaScript.AlertMessage(this.Page, "資料刪除成功!");

        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCust.aspx");
        }
    }
}
