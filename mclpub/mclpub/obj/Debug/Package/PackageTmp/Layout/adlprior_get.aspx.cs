using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class adlprior_get : System.Web.UI.Page
    {
        adlprior_get_DB myadl = new adlprior_get_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // 抓出 書籍名稱
                GetBookName();

                // 顯示 DataGrid1 資料
                BindGrid1();
            }
        }

        // 抓出 書籍名稱
        public void GetBookName()
        {
            // 抓出 書籍類別代碼
            string BookCode;
            if (Context.Request.QueryString["bkcd"].Trim() == "")
                BookCode = "01";
            else
                BookCode = Context.Request.QueryString["bkcd"].Trim();
            //Response.Write("BookCode= " + BookCode + "<br>");


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds2 = myadl.Selectbook();
            DataView dv2 = ds2.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
            string rowfilterstr2 = "1=1";
            rowfilterstr2 = rowfilterstr2 + "AND bk_bkcd = " + BookCode;
            dv2.RowFilter = rowfilterstr2;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
            //Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

            // 若有資料, 則輸出顯示之
            if (dv2.Count > 0)
            {
                // 計算及顯示筆數
                this.lblBookName.Text = dv2[0]["bk_nm"].ToString().Trim();
            }
        }


        // 顯示 DataGrid1 資料
        public void BindGrid1()
        {
            // 抓出 書籍類別代碼
            string BookCode;
            if (Context.Request.QueryString["bkcd"].Trim() == "")
                BookCode = "01";
            else
                BookCode = Context.Request.QueryString["bkcd"].Trim();
            //Response.Write("BookCode= " + BookCode + "<br>");


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = myadl.Selectlprior();
            DataView dv1 = ds1.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
            string rowfilterstr1 = "1=1";
            rowfilterstr1 = rowfilterstr1 + "AND lp_bkcd = " + BookCode;
            dv1.RowFilter = rowfilterstr1;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

            // 若有資料, 則輸出顯示之
            if (dv1.Count > 0)
            {
                DataGrid1.DataSource = dv1;
                DataGrid1.DataBind();

                // 計算及顯示筆數
                this.lblResult.Text = "搜尋結果...";
                this.lblNum.Text = dv1.Count.ToString();
            }
        }


        //// 選取 DataGrid1 某筆資料的處理
        //private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        //{
        //    DataGrid1.SelectedIndex = e.Item.ItemIndex;
        //}


        //// 換頁處理
        //private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        //{
        //    DataGrid1.CurrentPageIndex = e.NewPageIndex;
        //}
    }
}