using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using mclpub;

namespace mclpub.Subscriber
{
    public partial class Company : System.Web.UI.Page
    {
        Company_DB myCompany = new Company_DB();


        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "CompGV";
            if (!IsPostBack)
            {
                BindGrid();
            }

        }

        public void BindGrid()
        {
            string atype = Account.GetAccInfo().srspn_atype.ToString();
            DataTable dt = myCompany.SelectCompanyTable(TicketName.Text.Trim(), TicketNum.Text.Trim(), TicketAddr.Text.Trim(), CompTel.Text.Trim(), atype, Account.GetAccInfo().srspn_empno);
            this.UCPager1.Dtdata = dt;
            this.UCPager1.UCPageBind();
            //Response.Write(Account.GetAccInfo().srspn_atype.ToString());

        }

        protected void CompGVOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                // e.Row.Cells[1].Visible = false;
                Button d = (Button)e.Row.Cells[6].FindControl("Button2");
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
            Response.Redirect(string.Format("AddComp.aspx?ID={0}",ide));

        }

        protected void Delete(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ide = thisRow.Cells[0].Text;
            myCompany.DelComp(ide);
            BindGrid();
            JavaScript.AlertMessage(this.Page, "資料刪除成功!");

        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void AddCompBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddComp.aspx");
        }
    }
}
