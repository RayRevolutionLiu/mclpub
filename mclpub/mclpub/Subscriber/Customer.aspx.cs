using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FlexCel.Core;
using FlexCel.XlsAdapter;
using FlexCel.Render;

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
                DataTable dt = BindGrid();
                this.UCPager1.Dtdata = dt;
                this.UCPager1.UCPageBind();
            }

        }

        public DataTable BindGrid()
        {
            string atype = Account.GetAccInfo().srspn_atype.ToString();
            DataTable dt = myCust.SelectCustomerTable(TXcust_nm.Text.Trim(), TXcust_custno.Text.Trim(), TXmfr_inm.Text.Trim(),TXcust_mfrno.Text.Trim(),TXcust_tel.Text.Trim(),TXcust_srspn_empno.Text.Trim(), atype, Account.GetAccInfo().srspn_empno.ToString());
            return dt;
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
            DataTable dt = BindGrid();
            this.UCPager1.Dtdata = dt;
            this.UCPager1.UCPageBind();
        }

        protected void AddNewBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCust.aspx");
        }

        protected void ExportExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = BindGrid();
            //Response.Write(dt.Rows.Count);
            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Subscriber/Template/Customer.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;
            Xls.SetCellValue(2, 2, DateTime.Now.ToString("yyyy/MM/dd"));
            Xls.SetCellValue(2, 10, Account.GetAccInfo().srspn_cname.ToString());

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Xls.SetCellValue(i + 3, 1, dt.Rows[i]["mfr_inm"].ToString());
                Xls.SetCellValue(i + 3, 2, dt.Rows[i]["mfr_mfrno"].ToString());
                Xls.SetCellValue(i + 3, 3, dt.Rows[i]["cust_nm"].ToString());
                Xls.SetCellValue(i + 3, 4, dt.Rows[i]["cust_jbti"].ToString());
                Xls.SetCellValue(i + 3, 5, dt.Rows[i]["cust_fax"].ToString());
                Xls.SetCellValue(i + 3, 6, dt.Rows[i]["cust_cell"].ToString());
                Xls.SetCellValue(i + 3, 7, dt.Rows[i]["cust_email"].ToString());
                Xls.SetCellValue(i + 3, 8, dt.Rows[i]["cust_custno"].ToString());
                Xls.SetCellValue(i + 3, 9, dt.Rows[i]["srspn_cname"].ToString());
                Xls.SetCellValue(i + 3, 10, dt.Rows[i]["cust_tel"].ToString());
            }

            Common.excuteExcel(Xls, "Customer.xls");
        }

        protected void ExportEmail_Click(object sender, EventArgs e)
        {
            DataTable dt = BindGrid();
            //Response.Write(dt.Rows.Count);
            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Subscriber/Template/CustomerEmail.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;
            TXlsCellRange myRange = new TXlsCellRange("A4:B4");
            Xls.SetCellValue(2, 2, DateTime.Now.ToString("yyyy/MM/dd"));
            Xls.SetCellValue(2, 5, Account.GetAccInfo().srspn_cname.ToString());

            for (int i = 4; i < dt.Rows.Count + 4; i++)
            {
                Xls.MergeCells(i, 2, i, 5);
            }

            if (dt.Rows.Count > 1)
            {
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{
                //    Xls.InsertAndCopyRange(myRange, 5 + i, 1, 1, TFlxInsertMode.NoneDown);
                //}
                Xls.InsertAndCopyRange(myRange, 5, 1, dt.Rows.Count - 1, TFlxInsertMode.NoneDown);
                Xls.InsertAndCopyRange(myRange, 5, 2, dt.Rows.Count - 1, TFlxInsertMode.NoneDown);
                Xls.InsertAndCopyRange(myRange, 5, 3, dt.Rows.Count - 1, TFlxInsertMode.NoneDown);
                Xls.InsertAndCopyRange(myRange, 5, 4, dt.Rows.Count - 1, TFlxInsertMode.NoneDown);
            }
            else
            {
                //do nothing
            }

            for (int i = 4; i < dt.Rows.Count + 4; i++)
            {
                Xls.MergeCells(i, 2, i, 5);
                Xls.SetAutoRowHeight(i, true);
                Xls.SetCellValue(i, 1, i - 3);
                Xls.SetCellValue(i, 2, dt.Rows[i - 4]["cust_email"].ToString().Trim());
            }


            Common.excuteExcel(Xls, "CustomerEmail.xls");
        }
    }
}
