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
    public partial class ormtpcounts_stat_search1 : System.Web.UI.Page
    {
        ormtpcounts_stat_search1_DB myOrMtp = new ormtpcounts_stat_search1_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitialData();
                SearchIcon.Visible = false;

            }
        }

        public DataTable BindGrid()
        {
            // 抓出篩選條件
            string strConttp = this.ddlConttp.SelectedItem.Value.ToString() == "00" ? "" : ddlConttp.SelectedItem.Value.ToString();
            string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
            string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
            strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            string fgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();
            string strMailType = this.ddlMailType.SelectedItem.Value.ToString().Trim();

            DataSet ds = myOrMtp.SelectC2_or(strConttp, strBkcd, strYYYYMM, fgMOSea, strMailType);

            DataTable dt = ds.Tables[0];

            return dt;
        }

        // 給預設值
        private void InitialData()
        {
            // 顯示下拉式選單 書籍類別的 DB 值
            // 關於 nostr, 請參 sqlDataAdapter3.Select statement;
            // nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
            DataSet ds1 = myOrMtp.SelectBook();
            DataView dv1 = ds1.Tables[0].DefaultView;
            ddlBookCode.DataSource = dv1;
            dv1.RowFilter = "proj_fgitri=''";
            ddlBookCode.DataTextField = "bk_nm";
            //ddlBookCode.DataValueField="nostr";
            // 同維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
            ddlBookCode.DataValueField = "bk_bkcd";
            ddlBookCode.DataBind();

            tbxPubDate.Text = System.DateTime.Today.ToString("yyyy/MM");
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;
            try
            {
                string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
                strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "日期格式錯誤");
                return;
            }

            DataTable dt = BindGrid();
            int intTotalPubCounts = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                intTotalPubCounts += Convert.ToInt32(dt.Rows[i]["SumCounts"].ToString());
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();

            if (dt.Rows.Count > 0)
            {
                lblMessage.Text = "查詢結果: 找到 " + dt.Rows.Count + " 筆資料, 總本數：" + intTotalPubCounts;
                lblMessage.Visible = true;
            }
            else
            {
                lblMessage.Visible = false;
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[6].Visible = false;
                try
                {
                    if (Convert.ToInt32(e.Row.Cells[6].Text.Trim()) >= 20)
                    {
                        e.Row.Cells[6].ForeColor = System.Drawing.Color.Blue;
                    }
                }
                catch(Exception ex)
                {
                    JavaScript.AlertMessage(this.Page, "轉換欄位格式錯誤");
                    throw new Exception(ex.Message);
                }

            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[6].Visible = false;
            }
        }

        protected void btnPrintList_Click(object sender, EventArgs e)
        {
            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Statistics/Template/ORMtpCounts_stat2a.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;
            DataTable dt = BindGrid();

            TXlsCellRange myRange = new TXlsCellRange("A7:G7");
            TXlsCellRange myRangeToTal = new TXlsCellRange("A1:G1");

            Xls.SetCellValue(2, 1, ddlBookCode.SelectedItem.Text.ToString());
            Xls.SetCellValue(2, 5, tbxPubDate.Text.Trim());
            DataSet dsbkp_pno = myOrMtp.Selectbkp_pno(tbxPubDate.Text.Trim().Replace("/", ""), ddlBookCode.SelectedItem.Value.ToString().Trim());
            Xls.SetCellValue(2, 7, dsbkp_pno.Tables[0].Rows[0]["bkp_pno"].ToString());
            Xls.SetCellValue(4, 4, ddlConttp.SelectedItem.Value.ToString() == "00" ? "" : ddlConttp.SelectedItem.Text.ToString());
            Xls.SetCellValue(4, 7, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(5, 4, ddlfgMOSea.SelectedItem.Value.ToString() == "" ? "" : ddlfgMOSea.SelectedItem.Text.ToString());
            Xls.SetCellValue(5, 5, ddlMailType.SelectedItem.Text.ToString());
            Xls.SetCellValue(5, 7, DateTime.Now.ToString("yyyy/MM/dd"));

            if (dt.Rows.Count == 1)
            {
                //do nothing
            }
            else
            {
                for (int i = 8; i < dt.Rows.Count + 8 + 20; i++)//因為不知道底下會插入多少小計 先隨便多塞幾個格式進去
                {
                    //白色
                    Xls.InsertAndCopyRange(myRange, i, 1, 1, TFlxInsertMode.NoneDown);
                    Xls.SetRowHeight(i, 250);//250等於高度12
                }

            }

            string preNo = "";
            int X1 = 0;
            int count = 0;
            int sum_PubCounts = 0;
            int sum_Counts = 0;
            int TotalPubCounts = 0;
            int TotalCounts = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["or_mtpcd"].ToString() != preNo)
                {
                    if (X1 != 0)
                    {
                        Xls.SetCellValue(X1 + 7, 1, "");
                        Xls.SetCellValue(X1 + 7, 2, "-----");
                        Xls.SetCellValue(X1 + 7, 3, "-----");
                        Xls.SetCellValue(X1 + 7, 4, "----------------------------------");
                        Xls.SetCellValue(X1 + 7, 5, "小計：");
                        Xls.SetCellValue(X1 + 7, 6, sum_PubCounts + " 份");
                        Xls.SetCellValue(X1 + 7, 7, sum_Counts + " 本");
                        sum_PubCounts = 0;
                        sum_Counts = 0;
                        X1++;
                    }

                    Xls.SetCellValue(X1 + 7, 1, count + 1);
                    Xls.SetCellValue(X1 + 7, 2, dt.Rows[i]["cont_conttpName"].ToString());
                    Xls.SetCellValue(X1 + 7, 3, dt.Rows[i]["bk_nm"].ToString());
                    Xls.SetCellValue(X1 + 7, 4, dt.Rows[i]["mtp_nm"].ToString());
                    Xls.SetCellValue(X1 + 7, 5, dt.Rows[i]["or_pubcnt"].ToString() + " x");
                    Xls.SetCellValue(X1 + 7, 6, dt.Rows[i]["PubCounts"].ToString() + " 份 = ");
                    Xls.SetCellValue(X1 + 7, 7, dt.Rows[i]["SumCounts"].ToString() + " 本");
                    sum_PubCounts += Convert.ToInt32(dt.Rows[i]["PubCounts"].ToString());
                    sum_Counts += Convert.ToInt32(dt.Rows[i]["SumCounts"].ToString());
                    TotalPubCounts += Convert.ToInt32(dt.Rows[i]["PubCounts"].ToString());
                    TotalCounts  += Convert.ToInt32(dt.Rows[i]["SumCounts"].ToString());
                    X1++;
                    count++;
                }
                else
                {
                    Xls.SetCellValue(X1 + 7, 1, "");
                    Xls.SetCellValue(X1 + 7, 2, "");
                    Xls.SetCellValue(X1 + 7, 3, "");
                    Xls.SetCellValue(X1 + 7, 4, "");
                    Xls.SetCellValue(X1 + 7, 5, dt.Rows[i]["or_pubcnt"].ToString() + " x");
                    Xls.SetCellValue(X1 + 7, 6, dt.Rows[i]["PubCounts"].ToString() + " 份 = ");
                    Xls.SetCellValue(X1 + 7, 7, dt.Rows[i]["SumCounts"].ToString() + " 本");
                    sum_PubCounts += Convert.ToInt32(dt.Rows[i]["PubCounts"].ToString());
                    sum_Counts += Convert.ToInt32(dt.Rows[i]["SumCounts"].ToString());
                    TotalPubCounts += Convert.ToInt32(dt.Rows[i]["PubCounts"].ToString());
                    TotalCounts += Convert.ToInt32(dt.Rows[i]["SumCounts"].ToString());
                    X1++;
                }

                preNo = dt.Rows[i]["or_mtpcd"].ToString();
            }

            Xls.SetCellValue(X1 + 7, 1, "");
            Xls.SetCellValue(X1 + 7, 2, "-----");
            Xls.SetCellValue(X1 + 7, 3, "-----");
            Xls.SetCellValue(X1 + 7, 4, "----------------------------------");
            Xls.SetCellValue(X1 + 7, 5, "小計：");
            Xls.SetCellValue(X1 + 7, 6, sum_PubCounts + " 份");
            Xls.SetCellValue(X1 + 7, 7, sum_Counts + " 本");
            X1++;

            Xls.InsertAndCopyRange(myRangeToTal, 7 + X1 + 1, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
            Xls.SetCellValue(7 + X1 + 1, 6, TotalPubCounts);
            Xls.SetCellValue(7 + X1 + 1, 7, TotalCounts);

            Xls.ActiveSheet = 2;
            Xls.DeleteRange(myRangeToTal, TFlxInsertMode.NoneDown);
            Xls.ActiveSheet = 1;

            Common.excuteExcel(Xls, "ORMtpCounts_stat2a.xls");

        }
    }
}