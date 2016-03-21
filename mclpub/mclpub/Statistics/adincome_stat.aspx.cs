using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FlexCel.Core;
using FlexCel.XlsAdapter;
using FlexCel.Render;

namespace mclpub.Statistics
{
    public partial class adincome_stat : System.Web.UI.Page
    {
        adincome_stat_DB myadincome = new adincome_stat_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitialData();
                SearchIcon.Visible = false;
                LinkButton1.Visible = false;
            }
        }

        // 給預設值
        private void InitialData()
        {
            this.lblMessage.Text = "";


            // 顯示下拉式選單 書籍類別的 DB 值
            // 關於 nostr, 請參 sqlDataAdapter3.Select statement; 
            // nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
            DataSet ds1 = myadincome.SelectBook();
            DataView dv1 = ds1.Tables[0].DefaultView;
            ddlBookCode.DataSource = dv1;
            dv1.RowFilter = "proj_fgitri=''";
            ddlBookCode.DataTextField = "bk_nm";
            //ddlBookCode.DataValueField="nostr";
            // 同維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
            ddlBookCode.DataValueField = "bk_bkcd";
            ddlBookCode.DataBind();


            // 顯示下拉式選單 業務員 DB 值
            // 關於 nostr, 請參 sqlDataAdapter3.Select statement; 
            // nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
            DataSet ds3 = myadincome.SelectSrspn();
            DataRow dr = ds3.Tables[0].NewRow();
            dr["srspn_empno"] = "000000";
            dr["srspn_cname"] = "請選擇";
            ds3.Tables[0].Rows.Add(dr);
            ds3.Tables[0].DefaultView.Sort = "srspn_empno ASC";
            DataView dv3 = ds3.Tables[0].DefaultView;
            ddlEmpNo.DataSource = dv3;
            ddlEmpNo.DataTextField = "srspn_cname";
            ddlEmpNo.DataValueField = "srspn_empno";
            ddlEmpNo.DataBind();

            //如果是D級管理者，僅能查看到自己的客戶資料
            if (Account.GetAccInfo().srspn_atype.ToString().Trim() == "D")
            {
                try
                {
                    ddlEmpNo.SelectedValue = ddlEmpNo.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()).Value.ToString();
                    ddlEmpNo.Enabled = false;
                }
                catch
                {
                    ddlEmpNo.SelectedIndex = 0;
                }
            }

            this.tbxPubDate.Text = System.DateTime.Today.ToString("yyyy/MM");

        }

        public DataTable BindExcel()
        {
            // 抓出 網頁變數
            string bkcd = this.ddlBookCode.SelectedItem.Value.ToString();
            string yyyyymm = this.tbxPubDate.Text.ToString().Trim();
            yyyyymm = yyyyymm.Substring(0, 4) + yyyyymm.Substring(5, 2);
            string empno = "";
            if (ddlEmpNo.SelectedItem.Value.ToString().Trim() != "000000")
            {
                empno = ddlEmpNo.SelectedItem.Value.ToString().Trim();
            }
            DataSet ds = myadincome.Selectc2_cont(yyyyymm, bkcd, empno);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            // 抓出 網頁變數
            string bkcd = this.ddlBookCode.SelectedItem.Value.ToString();
            string yyyyymm = this.tbxPubDate.Text.ToString().Trim();
            try
            {
                yyyyymm = yyyyymm.Substring(0, 4) + yyyyymm.Substring(5, 2);
                string strEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "日期格式錯誤");
                return;
            }

            SearchIcon.Visible = true;

            DataTable dt = BindExcel();

            if (dt.Rows.Count > 0)
            {
                this.lblMessage.Text = "結果: 找到 <B>" + dt.Rows.Count + "</B>筆資料;";
                LinkButton1.Visible = true;
                this.lblMessage2.Text = "請繼續按 來繼續進行下一動作!<br />";
            }
            else
            {
                LinkButton1.Visible = false;
                this.lblMessage.Text = "很抱歉, 本月無廣告收入資料！";
                this.lblMessage2.Text = "";
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Statistics/Template/adincome_stat2.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            TXlsCellRange myRange = new TXlsCellRange("A7:G7");
            TXlsCellRange myRangeBlue = new TXlsCellRange("A8:G8");
            TXlsCellRange myRangeToTal = new TXlsCellRange("A1:G1");

            //TFlxFormat f = Xls.GetDefaultFormat;
            //f.Font.Size20 = 160;
            ////f.Font.Style = TFlxFontStyles.Bold;
            ////f.Font.Name = "標楷體";
            //int xf = Xls.AddFormat(f);
            //f = null;

            DataTable dt = BindExcel();

            Xls.SetCellValue(2, 3, ddlBookCode.SelectedItem.Text.ToString());
            Xls.SetCellValue(2, 5, tbxPubDate.Text.Trim());
            Xls.SetCellValue(5, 2, ddlEmpNo.SelectedItem.Value.ToString() == "000000" ? "" : ddlEmpNo.SelectedItem.Text.ToString());
            Xls.SetCellValue(4, 7, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(5, 7, DateTime.Now.ToString("yyyy/MM/dd"));

            if (dt.Rows.Count == 1)
            {
                Xls.DeleteRange(myRangeBlue, TFlxInsertMode.NoneDown);//只有一筆的話刪除第一區塊的藍色
                //下面一個迴圈添加單一筆內所有資料
            }
            else
            {
                if (dt.Rows.Count > 2)
                {
                    int countback = 0;
                    //兩筆的話就不用動任何迴圈
                    for (int i = 9; i < dt.Rows.Count + 9 - 2; i++)
                    {
                        countback++;
                        if (countback % 2 == 0)
                        {
                            //藍色
                            Xls.InsertAndCopyRange(myRangeBlue, i, 1, 1, TFlxInsertMode.NoneDown);
                        }
                        else
                        {
                            //白色
                            Xls.InsertAndCopyRange(myRange, i, 1, 1, TFlxInsertMode.NoneDown);
                        }
                        Xls.SetRowHeight(i, 250);//250等於高度12
                    }
                }
            }

            Xls.InsertAndCopyRange(myRangeToTal, dt.Rows.Count + 7, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);

            int TotalAdamt = 0;
            int TotalChgAmt = 0;
            int TotalPubCounts = 0;
            int TotalAmt = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Xls.SetCellValue(i + 7, 1, i + 1);
                Xls.SetCellValue(i + 7, 2, dt.Rows[i]["cont_contno"].ToString());
                Xls.SetCellValue(i + 7, 3, dt.Rows[i]["mfr_inm"].ToString());
                Xls.SetCellValue(i + 7, 4, Convert.ToInt32(dt.Rows[i]["TotalAdamt"].ToString()));
                Xls.SetCellValue(i + 7, 5, Convert.ToInt32(dt.Rows[i]["TotalChgAmt"].ToString()));
                Xls.SetCellValue(i + 7, 6, Convert.ToInt32(dt.Rows[i]["TotalPubCounts"].ToString()));
                Xls.SetCellValue(i + 7, 7, Convert.ToInt32(dt.Rows[i]["TotalAmt"].ToString()));

                TotalAdamt += Convert.ToInt32(dt.Rows[i]["TotalAdamt"].ToString());
                TotalChgAmt += Convert.ToInt32(dt.Rows[i]["TotalChgAmt"].ToString());
                TotalPubCounts += Convert.ToInt32(dt.Rows[i]["TotalPubCounts"].ToString());
                TotalAmt += Convert.ToInt32(dt.Rows[i]["TotalAmt"].ToString());
            }

            Xls.SetCellValue(dt.Rows.Count + 7, 4, TotalAdamt);
            Xls.SetCellValue(dt.Rows.Count + 7, 5, TotalChgAmt);
            Xls.SetCellValue(dt.Rows.Count + 7, 6, TotalPubCounts);
            Xls.SetCellValue(dt.Rows.Count + 7, 7, TotalAmt);

            Xls.ActiveSheet = 2;
            Xls.DeleteRange(myRangeToTal, TFlxInsertMode.NoneDown);
            Xls.ActiveSheet = 1;
            Common.excuteExcel(Xls, "adincome_stat2.xls");

        }
    }
}