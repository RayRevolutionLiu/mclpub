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
    public partial class orcounts_stat_search3 : System.Web.UI.Page
    {
        orcounts_stat_search1_DB myORCount = new orcounts_stat_search1_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitialData();
                SearchIcon.Visible = false;
                lblMessage.Visible = false;
                lblMessage2.Visible = false;
                LinkButton1.Visible = false;
            }
        }

        // 給預設值
        private void InitialData()
        {
            lblMessage.Text = "";
            lblMessage2.Text = "";

            // 顯示下拉式選單 書籍類別的 DB 值
            // 關於 nostr, 請參 sqlDataAdapter3.Select statement;
            // nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
            DataSet ds1 = myORCount.SelectBook();
            DataView dv1 = ds1.Tables[0].DefaultView;
            ddlBookCode.DataSource = dv1;
            dv1.RowFilter = "proj_fgitri=''";
            ddlBookCode.DataTextField = "bk_nm";
            //ddlBookCode.DataValueField="nostr";
            // 同維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
            ddlBookCode.DataValueField = "bk_bkcd";
            ddlBookCode.DataBind();


            // 顯示下拉式選單 業務員 DB 值
            DataSet ds2 = myORCount.Selectmtp();
            DataRow dr = ds2.Tables[0].NewRow();
            dr["mtp_mtpcd"] = "00";
            dr["mtp_nm"] = "請選擇";
            ds2.Tables[0].Rows.Add(dr);
            DataView dv2 = ds2.Tables[0].DefaultView;
            dv2.Sort = "mtp_mtpcd ASC";
            ddlMtpcd.DataSource = dv2;
            ddlMtpcd.DataTextField = "mtp_nm";
            ddlMtpcd.DataValueField = "mtp_mtpcd";
            ddlMtpcd.DataBind();

            tbxPubDate.Text = System.DateTime.Today.ToString("yyyy/MM");
        }

        public DataTable BindExcel()
        {
            // 抓出篩選條件
            string strBkcd = ddlBookCode.SelectedItem.Value.ToString();
            string strYYYYMM = tbxPubDate.Text.ToString().Trim();
            strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            string strConttp = ddlConttp.SelectedItem.Value.ToString() == "00" ? "" : ddlConttp.SelectedItem.Value.ToString();
            string fgMOSea = ddlfgMOSea.SelectedItem.Value.ToString().Trim();
            string Mtpcd = ddlMtpcd.SelectedItem.Value.ToString().Trim() == "00" ? "" : ddlMtpcd.SelectedItem.Value.ToString().Trim();

            DataSet ds = myORCount.Selectc2_cont3(strBkcd, strYYYYMM, strConttp, fgMOSea, Mtpcd);

            DataTable dt = ds.Tables[0];

            return dt;
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;
            //lblMessage.Visible = false;
            //lblMessage2.Visible = false;
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
            DataTable dt = BindExcel();

            if (dt.Rows.Count > 0)
            {
                this.lblMessage.Text = "結果: 找到 <B>" + dt.Rows.Count + "</B>筆資料;";
                LinkButton1.Visible = true;
                lblMessage.Visible = true;
                lblMessage2.Visible = true;
                this.lblMessage2.Text = "請繼續按 來繼續進行下一動作!<br />";
            }
            else
            {
                LinkButton1.Visible = false;
                lblMessage.Visible = true;
                lblMessage2.Visible = true;
                this.lblMessage.Text = "很抱歉, 本月無廣告收入資料！";
                this.lblMessage2.Text = "";
            }
        }

        protected void ddlfgMOSea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strfgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();
            //Response.Write("strfgMOSea= " + strfgMOSea + "<br>");

            if (strfgMOSea == "1")
            {
                this.ddlMtpcd.ClearSelection();
                this.ddlMtpcd.Items.FindByValue("24").Selected = true;
            }
            else
            {
                this.ddlMtpcd.ClearSelection();
                this.ddlMtpcd.Items.FindByValue("11").Selected = true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Statistics/Template/ORCounts_stat2a.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            TXlsCellRange myRange = new TXlsCellRange("A7:E7");
            TXlsCellRange myRangeBlue = new TXlsCellRange("A8:E8");
            TXlsCellRange myRangeToTal = new TXlsCellRange("A1:E1");

            DataTable dt = BindExcel();
            DataSet dsbkp_pno = myORCount.Selectbkp_pno(tbxPubDate.Text.Trim().Replace("/", ""), ddlBookCode.SelectedItem.Value.ToString().Trim());
            Xls.SetCellValue(2, 1, ddlBookCode.SelectedItem.Text.ToString().Trim());
            Xls.SetCellValue(2, 4, tbxPubDate.Text.Trim());
            Xls.SetCellValue(2, 6, dsbkp_pno.Tables[0].Rows[0]["bkp_pno"].ToString());
            Xls.SetCellValue(1, 1, "郵寄本數統計表 － 合約外寄送");
            Xls.SetCellValue(4, 3, ddlConttp.SelectedItem.Value.ToString() == "00" ? "" : ddlConttp.SelectedItem.Text.ToString());
            Xls.SetCellValue(5, 3, ddlfgMOSea.SelectedItem.Value.ToString() == "" ? "" : ddlfgMOSea.SelectedItem.Text.ToString());
            Xls.SetCellValue(5, 4, ddlMtpcd.SelectedItem.Value.ToString() == "00" ? "" : ddlMtpcd.SelectedItem.Text.ToString());

            Xls.SetCellValue(4, 6, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(5, 6, DateTime.Now.ToString("yyyy/MM/dd"));
            Xls.SetCellValue(6, 5, "未登本數");

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

            int PubCounts = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Xls.SetCellValue(i + 7, 1, i + 1);
                Xls.SetCellValue(i + 7, 2, dt.Rows[i]["cont_contno"].ToString());
                Xls.SetCellValue(i + 7, 3, dt.Rows[i]["mfr_inm"].ToString());
                Xls.SetCellValue(i + 7, 4, dt.Rows[i]["mtp_nm"].ToString());
                Xls.SetCellValue(i + 7, 5, Convert.ToInt32(dt.Rows[i]["UnPubCounts"].ToString()));
                PubCounts += Convert.ToInt32(dt.Rows[i]["UnPubCounts"].ToString());
            }

            Xls.SetCellValue(dt.Rows.Count + 7, 5, PubCounts);

            Xls.ActiveSheet = 2;
            Xls.DeleteRange(myRangeToTal, TFlxInsertMode.NoneDown);
            Xls.ActiveSheet = 1;

            Common.excuteExcel(Xls, "ORCounts_stat2c.xls");

        }
    }
}