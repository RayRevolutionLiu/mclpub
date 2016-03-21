using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace mclpub.Layout
{
    public partial class adpgsize : System.Web.UI.Page
    {
        adpgsize_DB myad = new adpgsize_DB();

        private static string global_cd;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GridView1";
            if (!IsPostBack)
            {
                BindGrid();
                GiveNum();
            }
        }


        public void GiveNum()
        {
            string strAssignedNewCode = "";
            //string strAssignedContNo = Convert.ToString(System.DateTime.Today.Year-1911);
            DataSet ds = myad.SelectCountc2_pgsize();
            DataView dv = ds.Tables[0].DefaultView;

            if (dv.Count > 0 && dv[0]["CountNo"].ToString() != "0")
            {
                if (Convert.ToInt32((Convert.ToInt32(dv[0]["MaxCountNo"]) + 1)) < 10)
                {
                    strAssignedNewCode = Convert.ToString("0" + (Convert.ToInt32(dv[0]["MaxCountNo"]) + 1));
                }
                else
                {
                    strAssignedNewCode = Convert.ToString((Convert.ToInt32(dv[0]["MaxCountNo"]) + 1));
                }
            }
            else
            {
                strAssignedNewCode += "01";
            }

            pgs_pgscd.Text = strAssignedNewCode;
        }


        public void BindGrid()
        {

            DataSet ds = myad.Selectc2_pgsize();
            DataView dv = ds.Tables[0].DefaultView;
            if (dv.Count > 0)
            {
                UCPager1.Dtdata = dv.ToTable();
                UCPager1.UCPageBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Label accid = (Label)thisRow.Cells[1].FindControl("Label1");
            Label accid2 = (Label)thisRow.Cells[2].FindControl("Label2");
            TextBox accidTbx = (TextBox)thisRow.Cells[1].FindControl("TextBox1");
            TextBox accidTbx2 = (TextBox)thisRow.Cells[2].FindControl("TextBox2");
            Button Edit_button = (Button)sender;
            Button SubBtn = (Button)thisRow.Cells[3].FindControl("SubBtn");
            Button CancelBtn = (Button)thisRow.Cells[3].FindControl("CancelBtn");

            accid.Visible = false;
            accidTbx.Visible = true;
            accid2.Visible = false;
            accidTbx2.Visible = true;
            SubBtn.Visible = true;
            CancelBtn.Visible = true;
            Edit_button.Visible = false;
            global_cd = accid.Text;
        }

        protected void SubBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string CellZreo = thisRow.Cells[0].Text.Trim();
            Label accid = (Label)thisRow.Cells[1].FindControl("Label1");
            Label accid2 = (Label)thisRow.Cells[2].FindControl("Label2");
            TextBox accidTbx = (TextBox)thisRow.Cells[1].FindControl("TextBox1");
            TextBox accidTbx2 = (TextBox)thisRow.Cells[2].FindControl("TextBox2");
            Button Edit_button = (Button)sender;
            Button btnEdit = (Button)thisRow.Cells[3].FindControl("btnEdit");
            Button CancelBtn = (Button)thisRow.Cells[3].FindControl("CancelBtn");

            accid.Visible = true;
            accidTbx.Visible = false;
            accid2.Visible = true;
            accidTbx2.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;
            Edit_button.Visible = false;

            if (accidTbx.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "廣告篇幅代碼為必填欄位!");
                return;
            }
            if (accidTbx2.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "廣告篇幅名稱為必填欄位!");
                return;
            }

            DataSet ds = myad.Selectc2_pgsize();

            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "pgs_pgscd = '" + accidTbx.Text.Trim() + "'";

            if (dv.Count > 0 && accidTbx.Text.Trim() != global_cd)
            {
                JavaScript.AlertMessage(this.Page, "此筆資料已經存在!");
            }

            else
            {
                myad.UPDATEc2_pgsize(accidTbx.Text.Trim(), accidTbx2.Text.Trim(), thisRow.Cells[0].Text.Trim());

                JavaScript.AlertMessage(this.Page, "資料修改成功!");
                BindGrid();
            }

        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row

            Label accid = (Label)thisRow.Cells[1].FindControl("Label1");
            Label accid2 = (Label)thisRow.Cells[2].FindControl("Label2");
            TextBox accidTbx = (TextBox)thisRow.Cells[1].FindControl("TextBox1");
            TextBox accidTbx2 = (TextBox)thisRow.Cells[2].FindControl("TextBox2");
            Button Edit_button = (Button)sender;
            Button SubBtn = (Button)thisRow.Cells[3].FindControl("SubBtn");
            Button btnEdit = (Button)thisRow.Cells[3].FindControl("btnEdit");

            accid.Visible = true;
            accidTbx.Visible = false;
            accid2.Visible = true;
            accidTbx2.Visible = false;

            SubBtn.Visible = false;
            btnEdit.Visible = true;
            Edit_button.Visible = false;


        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            Label accid = (Label)thisRow.Cells[1].FindControl("Label1");
            DataSet ds1 = myad.Selectc2_pub(accid.Text.Trim());
            DataView dv1 = ds1.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr1 = "1=1";
            dv1.RowFilter = rowfilterstr1;
            //mypgno.DelC2_pgno(id);
            //BindGrid1();

            if (dv1.Count > 0)
            {
                int intPubCounts = Convert.ToInt16(dv1[0]["PubCounts"].ToString().Trim());
                //Response.Write("intPubCounts= "+ intPubCounts + "<BR>");

                if (intPubCounts > 0)
                {
                    JavaScript.AlertMessage(this.Page, "刪除無效：本筆資料已被使用, 將不允許刪除！");
                }
            }
            // 進行刪除
            else
            {
                myad.Delc2_pgsize(thisRow.Cells[0].Text.ToString().Trim());
                BindGrid();
                JavaScript.AlertMessage(this.Page, "資料刪除成功!");
            }

        }

    }
}