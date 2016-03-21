using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class bookp_get : System.Web.UI.Page
    {
        PubFm_DB myPub = new PubFm_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        public void BindGrid()
        {
            // Put user code to initialize the page here
            // 抓出當月的刊登年月 Currentyyyymm, (若是, 並以紅色顯示)
            string ThisYear = System.DateTime.Today.Year.ToString().Trim();
            string ThisMonth = System.DateTime.Today.Month.ToString().Trim();
            if (ThisMonth.Length == 1)
                ThisMonth = "0" + ThisMonth;
            string Currentyyyymm = ThisYear + ThisMonth;
            //Response.Write("Currentyyyymm= " + Currentyyyymm + "<br>");

            // 抓出 書籍類別代碼
            string BookCode;
            if (Context.Request.QueryString["bkcd"].Trim() == "")
                BookCode = "01";
            else
                BookCode = Context.Request.QueryString["bkcd"].Trim();
            //Response.Write("BookCode= " + BookCode + "<br>");
            //Response.Write("ThisYear+2= " + (int.Parse(ThisYear)+2) + "<br>");

            // 由網頁變數抓出所填之刊登年月, 好使該筆顏色為藍
            string ym;
            if (Context.Request.QueryString["ym"].Trim() == "")
                ym = Currentyyyymm;
            else
                ym = Context.Request.QueryString["ym"].Trim();
            hiddenYYYYMM.Value = ym;
            //Response.Write("ym= " + ym + "<br>");
            // 抓出 ym 的年度碼 4碼, 好塞入 sql RowFilter
            string Gotyyyy = "";
            Gotyyyy = ym.Substring(0, 4).Trim();

            // 指定 lblGetBookPNo 的預設訊息顯示
            string Searchym = ym.Substring(0, 4).ToString() + "/" + ym.Substring(4, 2).ToString();
            this.lblMessage.Text = "查詢之刊登年月= " + Searchym.Trim();
            this.lblGetBookPNo.Text = "";


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = myPub.Selectbookp_get();
            DataView dv1 = ds1.Tables[0].DefaultView;

            // **注意: 原本資料庫內之 bkp_pno  是 char(x) 型態, 故其 sqlDataAdapter4 裡, 要先做 RTRIM 的處理 (如 RTRIM(dbo.bookp.bkp_pno) AS bkp_pno), 否則其值會含有空白, 如 '184 ' .
            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
            string rowfilterstr1 = "1=1";
            rowfilterstr1 = rowfilterstr1 + "AND bkp_date LIKE '" + Gotyyyy + "%'";
            rowfilterstr1 = rowfilterstr1 + "AND bk_bkcd = " + BookCode;
            dv1.RowFilter = rowfilterstr1;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

            DataGrid1.DataSource = dv1;
            DataGrid1.DataBind();


            // 變更刊登年月的格式, 是為當月, 並且以紅色顯示
            int i;
            for (i = 0; i < DataGrid1.Items.Count; i++)
            {
                // 抓出 刊登年月, Reformat
                string yyyymm = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();
                DataGrid1.Items[i].Cells[1].Text = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);

                // 若刊登年月=當月資料, 刊登年月及書籍期別顯示為紅色字體
                //				if(yyyymm==Currentyyyymm)  {
                //					// 指定該 '書籍期別' 預設值 hiddenBookPNo (為 [當月資料] 之相對應 [書籍期別] 值.)
                ////					hiddenBookPNo.Value = DataGrid1.Items[i].Cells[2].Text;
                ////					//Response.Write("hiddenBookPNo.Value= " + hiddenBookPNo.Value + "<br>");
                ////					this.lblGetBookPNo.Text = "; 書籍期別= " + hiddenBookPNo.Value;
                //
                //					DataGrid1.Items[i].Cells[1].Text = "<font color=Red>" + DataGrid1.Items[i].Cells[1].Text + "</font>";
                //					DataGrid1.Items[i].Cells[2].Text = "<font color=Red>" + DataGrid1.Items[i].Cells[2].Text + "</font>";
                //				}
                // 若刊登年月=Query年月, 則 '刊登年月及書籍期別' 改顯示為藍色字體
                if (yyyymm == ym)
                {
                    // 指定該 '書籍期別' 預設值 hiddenBookPNo (為 [所填入年月] 之相對應 [書籍期別] 值.)
                    hiddenBookPNo.Value = DataGrid1.Items[i].Cells[2].Text;
                    //Response.Write("hiddenBookPNo.Value= " + hiddenBookPNo.Value + "<br>");
                    this.lblGetBookPNo.Text = "; 書籍期別= " + hiddenBookPNo.Value;

                    DataGrid1.Items[i].Cells[1].Text = "<font color=Blue>" + DataGrid1.Items[i].Cells[1].Text + "</font>";
                    DataGrid1.Items[i].Cells[2].Text = "<font color=Blue>" + DataGrid1.Items[i].Cells[2].Text + "</font>";
                }

            }
        }

        private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
        {
            string strbuf;
            DataGrid1.SelectedIndex = e.Item.ItemIndex;
        }


        private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
        {
            DataGrid1.CurrentPageIndex = e.NewPageIndex;

            // 清除已選之 ItemStyle 之設定(顏色...)
            //DataGrid1.SelectedItemStyle.Reset();
        }

    }
}