using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Subscriber
{
    public partial class AddCust1 : System.Web.UI.Page
    {
        AddCust_DB MyAdd = new AddCust_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "CompGV";
            if (!IsPostBack)
            {
                UCPager1.Visible = false;

                if (CompGV.Rows.Count == 0)
                {
                    SearchIcon.Visible = false;
                }
                else
                {
                    SearchIcon.Visible = true;
                }
            }

        }

        protected void CompGVOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }

        }

        public void BindGrid()
        {
            DataTable dt = MyAdd.SelectAllComp(tbxInm.Text.Trim(), tbxMfrno.Text.Trim());
            this.UCPager1.Dtdata = dt;
            this.UCPager1.UCPageBind();
        }


        protected void AddComp_Lk_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddComp.aspx");
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            //this.Page.Controls.Add(new LiteralControl("<script>alert(document.getElementById('SearchIcon'))</script>"));
            SearchIcon.Visible = true;
            UCPager1.Visible = true;
            BindGrid();
        }

        protected void RedrectEdit(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ide = thisRow.Cells[1].Text;
            //把廠商統編帶參數過去
            Response.Redirect(string.Format("Cust_Edit.aspx?ID={0}", ide));

        }
    }
}
