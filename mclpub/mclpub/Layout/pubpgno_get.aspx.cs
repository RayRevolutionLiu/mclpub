using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class pubpgno_get : System.Web.UI.Page
    {
        PubFm_DB myPub = new PubFm_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid1();
            }
        }

        public void BindGrid1()
        {
            // Put user code to initialize the page here
            // 抓出當月的刊登年月 Currentyyyymm, (若是, 並以紅色顯示)
            string ThisYear = System.DateTime.Today.Year.ToString().Trim();
            string ThisMonth = System.DateTime.Today.Month.ToString().Trim();
            if (ThisMonth.Length == 1)
                ThisMonth = "0" + ThisMonth;
            string Currentyyyymm = ThisYear + ThisMonth;
            //Response.Write("Currentyyyymm= " + Currentyyyymm + "<br>");


            // 抓出 廠商編號 & 舊稿期別/改稿期別, 來參考列出該廠商曾刊登(並寫回)之落版資料
            // 做為輸入 舊稿期別 / 改稿期別 時, 自動動出 舊稿頁碼 / 改稿頁碼 查詢結果
            string MfrNo;
            if (Context.Request.QueryString["mfrno"].Trim() == "")
                MfrNo = "<font color='gray'>(無資料)</font>";
            else
                MfrNo = Context.Request.QueryString["mfrno"].Trim();
            hiddenMfrNo.Value = MfrNo;
            //Response.Write("MfrNo= " + MfrNo + "<br>");

            string bkpno;
            if (Context.Request.QueryString["bkpno"].Trim() == "")
                bkpno = "";
            else
                bkpno = Context.Request.QueryString["bkpno"].Trim();
            hiddenBookPNo.Value = bkpno;
            //Response.Write("bkpno= " + bkpno + "<br>");


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds = myPub.Selectc2_pubForpubqno_get();
            DataView dv = ds.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
            string rowfilterstr = "1=1";
            this.lblMessage.Text = "查詢條件：";
            this.lblGetPageNo.Text = "";
            if (MfrNo != "")
            {
                this.lblMessage.Text = this.lblMessage.Text + "廠商統編=" + MfrNo;
                rowfilterstr = rowfilterstr + " AND (cont_mfrno = '" + MfrNo + "') ";
            }

            if (bkpno != "")
            {
                this.lblMessage.Text = this.lblMessage.Text + ", 刊登期別=" + bkpno;
                //rowfilterstr = rowfilterstr + " AND (pub_pno = '" + bkpno + "') ";
            }


            dv.RowFilter = rowfilterstr;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv.Count= "+ dv.Count + "<BR>");
            //Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");
            this.hiddenBookPNo.Value = "";


            // 檢查是否有搜尋結果
            if (dv.Count < 1)
            {
                this.lblMessage.Text = "查無資料, 請重新輸入查詢!<br>";
                this.lblGetPageNo.Text = "";

                // 若無 DB 資料, 頁碼預設值為 0, 以稍後帶回到 hidden 值裡
                this.hiddenBookPNo.Value = bkpno;
                this.hiddenPageNo.Value = "0";
                //Response.Write("hiddenBookPNo= " + this.hiddenBookPNo.Value + "<br>");
                //Response.Write("hiddenPageNo= " + this.hiddenPageNo.Value + "<br>");
            }
            else
            {
                DataGrid1.DataSource = dv;
                DataGrid1.DataBind();


                // 將 DB 第一筆資料, 寫入 hidden 值裡
                // 先寫在此處, 是因 才能避免帶回以下含 <font...> 的值!
                this.hiddenBookPNo.Value = DataGrid1.Items[0].Cells[5].Text;
                this.hiddenPageNo.Value = DataGrid1.Items[0].Cells[6].Text;
                //Response.Write("hiddenBookPNo= " + this.hiddenBookPNo.Value + "<br>");
                //Response.Write("hiddenPageNo= " + this.hiddenPageNo.Value + "<br>");


                //變更刊登年月的格式, 是為當月, 並且以紅色顯示
                int j;
                for (j = 0; j < DataGrid1.Items.Count; j++)
                {
                    // 抓出 刊登年月, Reformat
                    string yyyymm = DataGrid1.Items[j].Cells[3].Text.ToString().Trim();
                    DataGrid1.Items[j].Cells[3].Text = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
                    //Response.Write("yyyymm= " + yyyymm + "<br>");

                    // 將第一筆之 '書籍期別' & '刊登頁碼' 改顯示為紅色字體
                    DataGrid1.Items[0].Cells[5].Text = "<font color=red>" + DataGrid1.Items[0].Cells[5].Text + "</font>";
                    DataGrid1.Items[0].Cells[6].Text = "<font color=red>" + DataGrid1.Items[0].Cells[6].Text + "</font>";
                }

                // 指定 lblMessage 的預設訊息顯示
                this.lblMessage.Text = this.lblMessage.Text;
                this.lblGetPageNo.Text = "=> 刊登頁碼 = " + DataGrid1.Items[0].Cells[6].Text;
            }
        }

        protected void DataGrid1_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strbuf;
            DataGrid1.SelectedIndex = e.Item.ItemIndex;
        }

        protected void DataGrid1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            DataGrid1.CurrentPageIndex = e.NewPageIndex;
        }

        protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                LinkButton NewLink = (LinkButton)e.Item.Cells[7].FindControl("lkbtnSelect");
                NewLink.Attributes.Add("onclick", "doGetPgNo('" + e.Item.Cells[5].Text.Trim() + "','" + e.Item.Cells[6].Text.Trim() + "');return false;");

                //NewLink.Text = e.Item.Cells[5].ToString();


            }
        } 


    }
}