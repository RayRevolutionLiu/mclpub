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

namespace mclpub.LabelArea
{
    public partial class PubFm_label_search2 : System.Web.UI.Page
    {
        PubFm_label_search_DB myPub = new PubFm_label_search_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                InitialData();
            }
        }

        // 給預設值
        private void InitialData()
        {
            this.lblMessage.Text = "";
            this.btnPrintLabel.Visible = false;
            this.btnPrintList.Visible = false;


            // 顯示下拉式選單 書籍類別的 DB 值
            // 關於 nostr, 請參 sqlDataAdapter3.Select statement;
            // nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
            DataSet ds1 = myPub.SelectBook();
            DataView dv1 = ds1.Tables["book"].DefaultView;
            ddlBookCode.DataSource = dv1;
            dv1.RowFilter = "proj_fgitri=''";
            ddlBookCode.DataTextField = "bk_nm";
            //ddlBookCode.DataValueField="nostr";
            // 同維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
            ddlBookCode.DataValueField = "bk_bkcd";
            ddlBookCode.DataBind();

            this.tbxPubDate.Text = System.DateTime.Today.ToString("yyyy/MM");


            // 顯示下拉式選單 業務員 DB 值
            // 關於 nostr, 請參 sqlDataAdapter3.Select statement;
            // nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
            DataSet ds2 = myPub.SelectSrspn();
            DataRow dr = ds2.Tables[0].NewRow();
            dr["srspn_empno"] = "000000";
            dr["srspn_cname"] = "請選擇";
            ds2.Tables[0].Rows.Add(dr);

            ds2.Tables[0].DefaultView.Sort = "srspn_empno ASC";
            DataView dv2 = ds2.Tables["srspn"].DefaultView;
            ddlEmpNo.DataSource = dv2;
            ddlEmpNo.DataTextField = "srspn_cname";
            ddlEmpNo.DataValueField = "srspn_empno";
            ddlEmpNo.DataBind();

            // 顯示下拉式選單 郵寄類別 DB 值
            DataSet ds4 = myPub.SelectMtp();
            DataRow dr2 = ds4.Tables[0].NewRow();
            dr2["mtp_mtpcd"] = "00";
            dr2["mtp_nm"] = "請選擇";
            ds4.Tables[0].Rows.Add(dr2);

            ds4.Tables[0].DefaultView.Sort = "mtp_mtpcd ASC";

            DataView dv4 = ds4.Tables["mtp"].DefaultView;
            ddlMtpcd.DataSource = dv4;
            ddlMtpcd.DataTextField = "mtp_nm";
            ddlMtpcd.DataValueField = "mtp_mtpcd";
            ddlMtpcd.DataBind();

            //如果是D級管理者，僅能查看到自己的客戶資料
            if (Account.GetAccInfo().srspn_atype.ToString().Trim() == "D")
            {
                if (this.ddlEmpNo.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()) != null)
                {
                    this.ddlEmpNo.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()).Selected = true;
                    this.ddlEmpNo.Enabled = false;
                }
            }

        }

        private void BindGrid1()
        {
            GVSearchLabel.DataSource = ReturnDataSet();
            GVSearchLabel.DataBind();

            if (ReturnDataSet().Count > 0)
            {
                GetBkpNo();
                btnPrintLabel.Visible = true;
                btnPrintList.Visible = true;
                lblMessage.Visible = true;
                lblMessage.Text = "查詢結果: 找到 " + ReturnDataSet().Count + " 筆雜誌收件人資料!";
            }
            else
            {
                lblMessage.Visible = false;
                btnPrintLabel.Visible = false;
                btnPrintList.Visible = false;
            }
        }

        // 抓出書籍期別, 好代入標籤及清單中
        private void GetBkpNo()
        {
            // 抓出篩選條件
            string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
            string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
            strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            string strBkPNo = "";


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds5 = myPub.SelectBookp();
            DataView dv5 = ds5.Tables["bookp"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr5 = "1=1";
            rowfilterstr5 = rowfilterstr5 + " AND bkp_bkcd='" + strBkcd + "'";
            rowfilterstr5 = rowfilterstr5 + " AND bkp_date='" + strYYYYMM + "'";
            dv5.RowFilter = rowfilterstr5;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
            //Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            if (dv5.Count > 0)
            {
                strBkPNo = dv5[0]["bkp_pno"].ToString().Trim();
            }
            else
            {
                strBkPNo = strBkPNo;
            }
            this.tbxBookPNo.Text = strBkPNo;
            //Response.Write("strBkPNo= " + strBkPNo + "<br>");
        }


        private DataView ReturnDataSet()
        {
            // 抓出篩選條件
            string strBkcd = ddlBookCode.SelectedItem.Value.ToString();
            string strYYYYMM = tbxPubDate.Text.ToString().Trim() == "" ? "" : tbxPubDate.Text.ToString().Substring(0, 4) + tbxPubDate.Text.ToString().Substring(5, 2);
            string strEmpNo = ddlEmpNo.SelectedItem.Value.ToString().Trim() == "000000" ? "" : ddlEmpNo.SelectedItem.Value.ToString().Trim();
            string strConttp = ddlConttp.SelectedItem.Value.ToString();
            string fgMOSea = ddlfgMOSea.SelectedItem.Value.ToString().Trim();
            string strMtpcd = ddlMtpcd.SelectedItem.Value.ToString() == "00" ? "" : ddlMtpcd.SelectedItem.Value.ToString();


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds3 = myPub.SelectC2_cont2(strBkcd, strConttp, fgMOSea, strYYYYMM);
            DataView dv3 = ds3.Tables[0].DefaultView;
            string rowfilterstr3 = "1=1";
            // 承辦業務員 篩選條件
            if (ddlEmpNo.SelectedItem.Value.ToString().Trim() != "000000")
            {
                rowfilterstr3 = rowfilterstr3 + " AND cont_empno='" + strEmpNo + "'";
            }
            // 郵寄類別
            if (ddlMtpcd.SelectedItem.Value.ToString() != "00")
            {
                rowfilterstr3 = rowfilterstr3 + " AND or_mtpcd='" + strMtpcd + "'";
            }
            dv3.RowFilter = rowfilterstr3;
            return dv3;
        }


        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;
            BindGrid1();
        }

        protected void GVSearchLabel_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text.Trim() != "")
                {
                    e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(0, 4) + "/" + e.Row.Cells[1].Text.Substring(4, 2);
                }
                if (e.Row.Cells[2].Text.Trim() != "")
                {
                    e.Row.Cells[2].Text = e.Row.Cells[2].Text.Substring(0, 4) + "/" + e.Row.Cells[2].Text.Substring(4, 2);
                }
            }
        }

        protected void btnPrintList_Click(object sender, EventArgs e)
        {
            DataView dv = ReturnDataSet();
            DataTable dt = dv.ToTable();

            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/LabelArea/Template/PubFm_list2.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            TXlsCellRange myRange = new TXlsCellRange("A8:H8");
            TXlsCellRange myRangeBlue = new TXlsCellRange("A9:H9");
            TXlsCellRange myRange2 = new TXlsCellRange("A1:H1");

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
                    for (int i = 10; i < dt.Rows.Count + 10 - 2; i++)
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
                    }
                }
            }

            Xls.SetCellValue(7, 7, "未登本數");

            Xls.SetCellValue(2, 4, ddlBookCode.SelectedItem.Text.ToString());
            Xls.SetCellValue(2, 6, tbxPubDate.Text.Trim());
            Xls.SetCellValue(5, 3, ddlEmpNo.SelectedItem.Value.ToString().Trim() == "000000" ? "(所有)" : ddlEmpNo.SelectedItem.Text.ToString().Trim());
            Xls.SetCellValue(4, 3, ddlConttp.SelectedItem.Text.ToString() + "合約");
            Xls.SetCellValue(6, 3, ddlfgMOSea.SelectedItem.Text.ToString());
            Xls.SetCellValue(6, 4, ddlMtpcd.SelectedItem.Value.ToString().Trim() == "00" ? "(所有)" : ddlMtpcd.SelectedItem.Text.ToString().Trim());
            Xls.SetCellValue(5, 7, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(6, 7, DateTime.Now.ToString("yyyy/MM/dd"));
            string strBkcd = ddlBookCode.SelectedItem.Value.ToString();
            string strYYYYMM = tbxPubDate.Text.ToString().Trim() == "" ? "" : tbxPubDate.Text.ToString().Substring(0, 4) + tbxPubDate.Text.ToString().Substring(5, 2);
            DataSet ds2 = myPub.SelectBookpNo(strYYYYMM, strBkcd);
            if (ds2.Tables[0].Rows.Count != 0)
            {
                Xls.SetCellValue(2, 8, ds2.Tables[0].Rows[0]["bkp_pno"].ToString());
            }
            else
            {
                Xls.SetCellValue(2, 8, "");
            }

            Xls.InsertAndCopyRange(myRange2, dt.Rows.Count + 7 + 3, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 3);

            string preNo = "";
            int totalcount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["cont_contno"].ToString() == preNo)
                {
                    Xls.SetCellValue(i + 8, 1, "");
                    Xls.SetCellValue(i + 8, 2, "");
                    Xls.SetCellValue(i + 8, 3, "");
                    Xls.SetCellValue(i + 8, 4, "");
                }
                else
                {
                    Xls.SetCellValue(i + 8, 1, i + 1);
                    Xls.SetCellValue(i + 8, 2, dt.Rows[i]["cont_contno"].ToString());
                    Xls.SetCellValue(i + 8, 3, dt.Rows[i]["cont_sedate"].ToString());
                    Xls.SetCellValue(i + 8, 4, dt.Rows[i]["or_inm"].ToString());
                    //Xls.SetCellValue(i + 8, 5, dt.Rows[i]["or_nm"].ToString() + "" + dt.Rows[i]["or_jbti"].ToString());
                    //Xls.SetCellValue(i + 8, 6, dt.Rows[i]["or_zip"].ToString() + "" + dt.Rows[i]["or_addr"].ToString());
                    //Xls.SetCellValue(i + 8, 7, dt.Rows[i]["or_pubcnt"].ToString());
                    //Xls.SetCellValue(i + 8, 8, dt.Rows[i]["mtp_nm"].ToString());
                }

                Xls.SetCellValue(i + 8, 5, dt.Rows[i]["or_nm"].ToString() + "" + dt.Rows[i]["or_jbti"].ToString());
                Xls.SetCellValue(i + 8, 6, dt.Rows[i]["or_zip"].ToString() + "" + dt.Rows[i]["or_addr"].ToString());
                Xls.SetCellValue(i + 8, 7, dt.Rows[i]["or_unpubcnt"].ToString());
                Xls.SetCellValue(i + 8, 8, dt.Rows[i]["mtp_nm"].ToString());
                preNo = dt.Rows[i]["cont_contno"].ToString();
                totalcount = totalcount + Convert.ToInt32(dt.Rows[i]["or_unpubcnt"].ToString());
            }
            Xls.SetCellValue(dt.Rows.Count + 3 + 7, 7, totalcount);

            Xls.ActiveSheet = 3;
            Xls.DeleteRange(myRange2, TFlxInsertMode.NoneDown);
            Xls.ActiveSheet = 1;

            Common.excuteExcel(Xls, "PubFm_list2.xls");

        }

        protected void btnPrintLabel_Click(object sender, EventArgs e)
        {
            // 抓出篩選條件
            string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
            string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
            strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            string strEmpNo = "";
            if (ddlEmpNo.SelectedItem.Value.ToString().Trim() != "000000")
            {
                strEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
            }
            string strConttp = this.ddlConttp.SelectedItem.Value.ToString();
            string strPubCountType = "1";
            string fgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();
            string strMtpcd = "";
            if (ddlMtpcd.SelectedItem.Value.ToString() != "00")
            {
                strMtpcd = this.ddlMtpcd.SelectedItem.Value.ToString();
            }
            string strBkPNo = this.tbxBookPNo.Text.ToString().Trim();


            // 轉址
            string strbuf;
            strbuf = "PubFm_label2.aspx?bkcd=" + strBkcd + "&yyyymm=" + strYYYYMM + "&empno=" + strEmpNo + "&conttp=" + strConttp + "&pubcnttp=" + strPubCountType + "&fgmosea=" + fgMOSea + "&mtpcd=" + strMtpcd + "&bkpno=" + strBkPNo;

            this.ClientScript.RegisterStartupScript(typeof(string), "", "<script>window.open(\"" + strbuf + "\");</script>");
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }
    }
}