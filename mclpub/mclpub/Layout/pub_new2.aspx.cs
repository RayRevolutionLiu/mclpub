using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class pub_new2 : System.Web.UI.Page
    {
        pub_new2_DB mypub = new pub_new2_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GVcont";

            if (!IsPostBack)
            {
                UCPager1.Visible = false;
                SearchIcon.Visible = false;
                this.tbxPubDate.Text = System.DateTime.Today.ToString("yyyyMM").Trim();
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;
            ShowPub();
        }

        private void ShowPub()
        {
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = mypub.Selectc2_pub();
            DataView dv1 = ds1.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
            string rowfilterstr1 = "1=1";

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

            //防呆處理: 若無資料時, 則給錯誤訊息
            if (tbxContNo.Text != "")
                rowfilterstr1 = rowfilterstr1 + " and cont_contno like '%" + tbxContNo.Text.Trim() + "%'";

            if (tbxPubDate.Text != "")
                rowfilterstr1 = rowfilterstr1 + " and pub_yyyymm like '" + tbxPubDate.Text.Trim() + "%'";

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("rowfilterstr1= " + rowfilterstr1 + "<BR>");
            dv1.RowFilter = rowfilterstr1;


            // 若搜尋結果為 "找不到" 的處理
            if (dv1.Count == 0)
            {
                GVcont.Visible = true;
            }
            else
            {
                UCPager1.Visible = true;
                lblMessage.Text = "結果: 找到 " + dv1.Count.ToString() + "筆資料";
            }

            UCPager1.Dtdata = dv1.ToTable();
            UCPager1.UCPageBind();

        }

        protected void btnRedirect_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ide = thisRow.Cells[0].Text;
            string ide2 = thisRow.Cells[2].Text;
            string ide12 = thisRow.Cells[8].Text;
            // 按下確定(挑人)的處理: 先轉址
            //Response.Write("ConttpText= " + ConttpText + "<br>");
            Response.Redirect("PubFm.aspx?contno=" + ide + "&bkcd=" + ide2 + "&fgnew=" + ide12);
        }


        protected void GVcont_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[8].Visible = false;
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                // 已落版註記
                string strfgclosed = e.Row.Cells[9].Text.Trim();
                //Response.Write("strfgclosed= " + strfgclosed + "<br>");
                if (strfgclosed == "0")
                {
                    e.Row.Cells[9].Text = "否";
                }
                else
                {
                    e.Row.Cells[9].Text = "<font color=red>是</font>";
                }

            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[8].Visible = false;
            }

        }

    }
}