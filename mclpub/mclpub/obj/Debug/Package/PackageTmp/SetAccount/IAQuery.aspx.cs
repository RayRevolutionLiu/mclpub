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

namespace mclpub.SetAccount
{
    public partial class IAQuery : System.Web.UI.Page
    {
        IAQuery_DB myIA = new IAQuery_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            if (tbxDate.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "請輸入日期再進行查詢");
                return;
            }
            DateTime Date1;// = DateTime.Parse(tbxDate.Text.Trim());
            try
            {
                Date1 = DateTime.ParseExact(tbxDate.Text.Trim(), "yyyy/MM/dd", null);
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "截止播出日日期格式錯誤，請重新輸入");
                return;
            }
            Bind_dgdAdr();
        }

        #region Bind_dgdAdr
        private void Bind_dgdAdr()
        {
            DateTime Date1 = DateTime.Parse(tbxDate.Text.Trim());
            string strDate = Date1.ToString("yyyyMMdd");

            DataSet ds = myIA.GetAdrForIA(strDate.Trim());
            DataView dv = ds.Tables[0].DefaultView;
            if (dv.Count > 0)
            {
                pnlSelect.Visible = true;
                pnlConfirm.Visible = false;
                DataGrid1.Visible = true;
                DataGrid1.DataSource = dv;
                DataGrid1.DataBind();
                lblMessage.Text = "目前尚有 " + dv.Count.ToString() + " 筆落版資料尚未開立發票!";
            }
            else
            {
                pnlSelect.Visible = false;
                lblMessage.Text = "沒有可開立發票之落版明細";
            }
        }
        #endregion

        protected void DataGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[21].Visible = false;
                DateTime Date1 = DateTime.Parse(tbxDate.Text.Trim());
                string strDate = Date1.ToString("yyyyMMdd");
                string strYYYYMM = strDate.Substring(0, 6);
                string yyyymm;
                // 刊登日 -- 針對不同月份, 整行給予不同顏色標示
                // 而且設定為'未選取'狀態
                yyyymm = e.Row.Cells[8].Text.Substring(0, 6);
                //Response.Write("yyyymm= " + yyyymm + "<br>");
                if (yyyymm != strYYYYMM)
                {
                    e.Row.Cells[8].ForeColor = System.Drawing.Color.LimeGreen;
                    e.Row.BackColor = System.Drawing.Color.MistyRose;//.Lavender;
                    ((CheckBox)e.Row.Cells[0].FindControl("CheckBox2")).Checked = false;
                }
                e.Row.Cells[11].Text = MatchAdCate(e.Row.Cells[11].Text);
                e.Row.Cells[12].Text = MatchKeyword(e.Row.Cells[12].Text);
                e.Row.Cells[19].Text = MatchFgitri(e.Row.Cells[19].Text.Replace("&nbsp;",""));//資料欄位&nbsp;
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[21].Visible = false;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[20].Visible = false;
                DateTime Date1 = DateTime.Parse(tbxDate.Text.Trim());
                string strDate = Date1.ToString("yyyyMMdd");
                string strYYYYMM = strDate.Substring(0, 6);
                string yyyymm;

                // 刊登日 -- 針對不同月份, 整行給予不同顏色標示
                yyyymm = e.Row.Cells[7].Text.Substring(0, 6);
                //Response.Write("yyyymm= " + yyyymm + "<br>");
                if (yyyymm != strYYYYMM)
                {
                    e.Row.Cells[7].ForeColor = System.Drawing.Color.LimeGreen;
                    e.Row.BackColor = System.Drawing.Color.Lavender;
                }
                e.Row.Cells[10].Text = MatchAdCate(e.Row.Cells[10].Text);
                e.Row.Cells[11].Text = MatchKeyword(e.Row.Cells[11].Text);
                e.Row.Cells[18].Text = MatchFgitri(e.Row.Cells[18].Text.Replace("&nbsp;", ""));
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[20].Visible = false;
            }
        }


        protected void GVEdit_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null)//如果第一次點選排序的話，預設就是「升」
            {
                ViewState["SortDirection"] = " ASC";
            }
            //判斷如果已經對某欄位排序過，再判斷是否針對同個欄位排序
            if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
            {
                //如果針對同個欄位排序，則進行「升」「降」的切換
                if (ViewState["SortDirection"].ToString() == " DESC")
                    ViewState["SortDirection"] = " ASC";
                else
                    ViewState["SortDirection"] = " DESC";

            }
            else
            {
                //第一次對某欄位排序，就是「升」
                ViewState["SortDirection"] = " ASC";
            }

            for (int i = 0; i <= ((GridView)sender).Columns.Count - 1; i++)
            {
                ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText.Replace("▲", "");
                ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText.Replace("▼", "");
            }
            int Columns_i = 0;
            for (int i = 0; i <= ((GridView)sender).Columns.Count - 1; i++)
            {
                if (e.SortExpression == ((GridView)sender).Columns[i].SortExpression)
                {
                    Columns_i = i;
                    if (ViewState["SortDirection"].ToString() == " DESC")
                    {
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText + "▼";
                    }
                    else
                    {
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText + "▲";
                    }
                }
            }

            ViewState["SortExpression"] = e.SortExpression;//指定欄位名稱


            DateTime Date1 = DateTime.Parse(tbxDate.Text.Trim());
            string strDate = Date1.ToString("yyyyMMdd");

            DataSet ds = myIA.GetAdrForIA(strDate.Trim());
            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortDirection"].ToString();
            if (dv.Count > 0)
            {
                pnlSelect.Visible = true;
                pnlConfirm.Visible = false;
                DataGrid1.Visible = true;
                DataGrid1.DataSource = dv;
                DataGrid1.DataBind();
                lblMessage.Text = "目前尚有 " + dv.Count.ToString() + " 筆落版資料尚未開立發票!";
            }
            else
            {
                pnlSelect.Visible = false;
                lblMessage.Text = "沒有可開立發票之落版明細";
            }
        }

        #region 下一步
        protected void btnNextStep_Click(object sender, EventArgs e)
        {
            //將資料庫中殘存的adr_fginved = 'v'清為 ''
            myIA.ClearAdrFginved();

            //將勾選的落版資料adr_fginved = 'v'
            int i;
            bool judge = false;
            for (i = 0; i < DataGrid1.Rows.Count; i++)
            {
                if (((CheckBox)DataGrid1.Rows[i].Cells[0].FindControl("CheckBox2")).Checked == true)
                {
                    myIA.UpdateAdrFginved(DataGrid1.Rows[i].Cells[1].Text.Trim(), DataGrid1.Rows[i].Cells[7].Text.Trim(), DataGrid1.Rows[i].Cells[8].Text.Trim(), "v");
                    judge = true;
                }
            }

            if (judge == false)
            {
                JavaScript.AlertMessage(this.Page, "尚未勾選任何項目");
                return;
            }


            //讀出資料
            DateTime Date1 = DateTime.Parse(tbxDate.Text.Trim());
            string strDate = Date1.ToString("yyyyMMdd");
            //			Advertisements adr = new Advertisements();
            DataSet ds = myIA.GetAdrForIA(strDate.Trim());
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "adr_fginved = 'v'";
            if (dv.Count > 0)
            {
                pnlSelect.Visible = false;
                pnlConfirm.Visible = true;
                btnPrint.Visible = true;
                GridView1.Visible = true;
                GridView1.DataSource = dv;
                GridView1.DataBind();

                lblMessage.Text = "已選取 " + dv.Count.ToString() + " 筆落版資料";
            }
            else
            {
                lblMessage.Text = "沒有選取任何落版明細";
            }
        }
        #endregion

        protected void btnPreStep_Click(object sender, EventArgs e)
        {
            //將資料庫中殘存的adr_fginved = 'v'清為 ''
            myIA.ClearAdrFginved();

            //讀出資料
            Bind_dgdAdr();
        }

        #region 格式化廣告資料
        protected string MatchAdCate(string adcate)
        {
            string transAdCate = "";
            switch (adcate.ToString().Trim())
            {
                case "M":
                    transAdCate = "首頁";
                    break;
                case "I":
                    transAdCate = "內頁";
                    break;
                case "N":
                    transAdCate = "奈米";
                    break;
                default:
                    throw new Exception("資料庫原生廣告頁面資料錯誤，請通知聯絡人");
                    break;
            }
            return transAdCate;
        }

        protected string MatchKeyword(string keyword)
        {
            string transKeyword = "";
            switch (keyword.ToString().Trim())
            {
                case "h0":
                    transKeyword = "正中";
                    break;
                case "h1":
                    transKeyword = "右一";
                    break;
                case "h2":
                    transKeyword = "右二";
                    break;
                case "h3":
                    transKeyword = "右三";
                    break;
                case "h4":
                    transKeyword = "右四";
                    break;
                case "w1":
                    transKeyword = "右文一";
                    break;
                case "w2":
                    transKeyword = "右文二";
                    break;
                case "w3":
                    transKeyword = "右文三";
                    break;
                case "w4":
                    transKeyword = "右文四";
                    break;
                case "w5":
                    transKeyword = "右文五";
                    break;
                case "w6":
                    transKeyword = "右文六";
                    break;
                default:
                    throw new Exception("資料庫原生廣告位置資料錯誤，請通知聯絡人");
                    break;
            }
            return transKeyword;
        }

        protected string MatchFgitri(string fgitri)
        {
            string transFgitri = "";
            switch (fgitri.ToString().Trim())
            {
                case "06":
                    transFgitri = "所內";
                    break;
                case "07":
                    transFgitri = "院內";
                    break;
                case "":
                    transFgitri = "一般";
                    break;
                default:
                    throw new Exception("資料庫原生廣告頁面資料錯誤，請通知聯絡人");
                    break;
            }
            return transFgitri;
        }
        #endregion

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string empno = Account.GetAccInfo().srspn_empno.ToString().Trim();
            myIA.IAPreList();//把資料塞入wk_c4_ia_prelist tmpTable 內
            bool flag = myIA.AddBatchIa(empno);
            if (flag)
            {
                JavaScript.AlertMessage(this.Page, "新增發票開立單作業完成");
                pnlConfirm.Visible = false;
            }
            else
                JavaScript.AlertMessage(this.Page, "新增發票開立單作業發生錯誤, 請重新新增或稍後再進行");
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            myIA.IAPreList();//把資料塞入wk_c4_ia_prelist tmpTable 內


            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/SetAccount/template/RptIA_PreList.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            DataSet ds = myIA.Selectwk_c4_ia_prelist();
            DataTable dt = ds.Tables[0];
            DataSet dtLCount = myIA.GroupByContnoAndimseq();//算出有多少個小計
            int TotalCountRow = dt.Rows.Count;//迴圈應該跑出多少個ROW
            if (dtLCount.Tables[0].Rows.Count > 0)
            {
                TotalCountRow = dt.Rows.Count + Convert.ToInt32(dtLCount.Tables[0].Rows[0]["TotalCount"].ToString());
            }
            TXlsCellRange myRange = new TXlsCellRange("A6:V6");
            TXlsCellRange myRangeBlue = new TXlsCellRange("A7:V7");
            TXlsCellRange myRangeTotal = new TXlsCellRange("A1:V1");

            if (TotalCountRow == 1)
            {
                Xls.DeleteRange(myRangeBlue, TFlxInsertMode.NoneDown);//只有一筆的話刪除第一區塊的藍色
                //下面一個迴圈添加單一筆內所有資料
            }
            else
            {
                if (TotalCountRow > 2)
                {
                    int countback = 0;
                    //兩筆的話就不用動任何迴圈
                    for (int i = 8; i < TotalCountRow + 8 - 2; i++)
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

            #region 小計金額Format
            TFlxFormat tfLcount = Xls.GetDefaultFormat;
            tfLcount.Borders.Top.Style = TFlxBorderStyle.Double;
            tfLcount.Borders.Top.Color = System.Drawing.Color.Blue;
            tfLcount.Font.Size20 = 160;
            tfLcount.Format = "$#,##0";
            int tfLcountI = Xls.AddFormat(tfLcount);
            tfLcount = null;
            #endregion

            #region 小計筆數Format
            TFlxFormat tfRLcount = Xls.GetDefaultFormat;
            tfRLcount.Borders.Top.Style = TFlxBorderStyle.Double;
            tfRLcount.Borders.Top.Color = System.Drawing.Color.Blue;
            tfRLcount.Font.Size20 = 160;
            int tfRLcountI = Xls.AddFormat(tfRLcount);
            tfRLcount = null;
            #endregion

            Xls.SetCellValue(3, 4, tbxDate.Text.Trim());
            Xls.SetCellValue(4, 4, Account.GetAccInfo().srspn_cname.ToString());
            Xls.SetCellValue(4, 17, DateTime.Now.ToString("yyy/MM/dd"));

            string contno = "";
            string imseq = "";
            int num = 0;//項次
            int ExcelRow = 0;
            int littleCount = 0;//小計筆數
            int littleMoney = 0;//小計金額
            int TotalCount = 0;//總金額
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["cont_contno"].ToString() == contno && dt.Rows[i]["adr_imseq"].ToString() == imseq)
                {
                    Xls.SetCellValue(6 + ExcelRow, 1, "");
                    Xls.SetCellValue(6 + ExcelRow, 2, "");
                    Xls.SetCellValue(6 + ExcelRow, 3, "");
                    Xls.SetCellValue(6 + ExcelRow, 4, "");
                    Xls.SetCellValue(6 + ExcelRow, 5, "");
                    Xls.SetCellValue(6 + ExcelRow, 6, "");
                    Xls.SetCellValue(6 + ExcelRow, 7, "");
                    Xls.SetCellValue(6 + ExcelRow, 8, "");
                    Xls.SetCellValue(6 + ExcelRow, 9, "");
                    Xls.SetCellValue(6 + ExcelRow, 10, "");
                    Xls.SetCellValue(6 + ExcelRow, 11, "");
                    Xls.SetCellValue(6 + ExcelRow, 12, "");
                    Xls.SetCellValue(6 + ExcelRow, 13, "");
                    Xls.SetCellValue(6 + ExcelRow, 14, "");
                    Xls.SetCellValue(6 + ExcelRow, 15, "");
                    Xls.SetCellValue(6 + ExcelRow, 16, "");
                    Xls.SetCellValue(6 + ExcelRow, 17, dt.Rows[i]["adr_addate"].ToString() == "" ? "" : dt.Rows[i]["adr_addate"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["adr_addate"].ToString().Substring(6, 2));
                    Xls.SetCellValue(6 + ExcelRow, 18, dt.Rows[i]["adr_seq"].ToString());
                    Xls.SetCellValue(6 + ExcelRow, 19, Convert.ToInt32(dt.Rows[i]["adr_adamt"].ToString()));
                    Xls.SetCellValue(6 + ExcelRow, 20, Convert.ToInt32(dt.Rows[i]["adr_desamt"].ToString()));
                    Xls.SetCellValue(6 + ExcelRow, 21, Convert.ToInt32(dt.Rows[i]["adr_chgamt"].ToString()));
                    Xls.SetCellValue(6 + ExcelRow, 22, Convert.ToInt32(dt.Rows[i]["adr_invamt"].ToString()));
                    contno = dt.Rows[i]["cont_contno"].ToString();
                    imseq = dt.Rows[i]["adr_imseq"].ToString();
                    ExcelRow++;
                    littleCount++;
                    littleMoney += Convert.ToInt32(dt.Rows[i]["adr_invamt"].ToString());
                    TotalCount += Convert.ToInt32(dt.Rows[i]["adr_invamt"].ToString());
                }
                else
                {
                    if (ExcelRow != 0)
                    {
                        Xls.SetCellValue(6 + ExcelRow, 1, "");
                        Xls.SetCellValue(6 + ExcelRow, 2, "");
                        Xls.SetCellValue(6 + ExcelRow, 3, "");
                        Xls.SetCellValue(6 + ExcelRow, 4, "");
                        Xls.SetCellValue(6 + ExcelRow, 5, "");
                        Xls.SetCellValue(6 + ExcelRow, 6, "");
                        Xls.SetCellValue(6 + ExcelRow, 7, "");
                        Xls.SetCellValue(6 + ExcelRow, 8, "");
                        Xls.SetCellValue(6 + ExcelRow, 9, "");
                        Xls.SetCellValue(6 + ExcelRow, 10, "");
                        Xls.SetCellValue(6 + ExcelRow, 11, "");
                        Xls.SetCellValue(6 + ExcelRow, 12, "");
                        Xls.SetCellValue(6 + ExcelRow, 13, "");
                        Xls.SetCellValue(6 + ExcelRow, 14, "");
                        Xls.SetCellValue(6 + ExcelRow, 15, "");
                        Xls.SetCellValue(6 + ExcelRow, 16, "");

                        Xls.SetCellValue(6 + ExcelRow, 17, "小計筆數：", tfLcountI);
                        Xls.MergeCells(6 + ExcelRow, 17, 6 + ExcelRow, 18);
                        Xls.SetCellValue(6 + ExcelRow, 18, "", tfLcountI);
                        Xls.SetCellValue(6 + ExcelRow, 19, littleCount, tfRLcountI);
                        Xls.MergeCells(6 + ExcelRow, 20, 6 + ExcelRow, 21);
                        Xls.SetCellValue(6 + ExcelRow, 20, "小計金額：", tfLcountI);                      
                        Xls.SetCellValue(6 + ExcelRow, 21, "小計金額：", tfLcountI);
                        Xls.SetCellValue(6 + ExcelRow, 22, littleMoney, tfLcountI);
                        ExcelRow++;
                        littleCount = 0;
                        littleMoney = 0;
                    }

                    num++;
                    Xls.SetCellValue(6 + ExcelRow, 1, num);
                    Xls.SetCellValue(6 + ExcelRow, 2, dt.Rows[i]["cont_contno"].ToString());
                    string sdate = dt.Rows[i]["cont_sdate"].ToString() == "" ? "" : dt.Rows[i]["cont_sdate"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["cont_sdate"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["cont_sdate"].ToString().Substring(6, 2);
                    string edate = dt.Rows[i]["cont_edate"].ToString() == "" ? "" : dt.Rows[i]["cont_edate"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["cont_edate"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["cont_edate"].ToString().Substring(6, 2);
                    Xls.SetCellValue(6 + ExcelRow, 3, sdate + "~" + edate);
                    Xls.SetCellValue(6 + ExcelRow, 4, dt.Rows[i]["cont_mfrno"].ToString());
                    Xls.SetCellValue(6 + ExcelRow, 5, dt.Rows[i]["cont_mfr_inm"].ToString());
                    Xls.SetCellValue(6 + ExcelRow, 6, dt.Rows[i]["srspn_cname"].ToString());
                    Xls.SetCellValue(6 + ExcelRow, 7, Convert.ToInt32(dt.Rows[i]["cont_totamt"].ToString()));
                    Xls.SetCellValue(6 + ExcelRow, 10, dt.Rows[i]["im_nm"].ToString());
                    Xls.SetCellValue(6 + ExcelRow, 11, dt.Rows[i]["im_mfr_inm"].ToString());
                    Xls.SetCellValue(6 + ExcelRow, 12, dt.Rows[i]["im_zip"].ToString() + " " + dt.Rows[i]["im_addr"].ToString());
                    switch (dt.Rows[i]["im_invcd"].ToString())
                    {
                        case "2":
                            {
                                Xls.SetCellValue(6 + ExcelRow, 13, "二聯");
                                break;
                            }
                        case "3":
                            {
                                Xls.SetCellValue(6 + ExcelRow, 13, "三聯");
                                break;
                            }
                        case "4":
                            {
                                Xls.SetCellValue(6 + ExcelRow, 13, "其他");
                                break;
                            }
                    }

                    switch (dt.Rows[i]["im_taxtp"].ToString())
                    {
                        case "1":
                            {
                                Xls.SetCellValue(6 + ExcelRow, 14, "5%");
                                break;
                            }
                        case "2":
                            {
                                Xls.SetCellValue(6 + ExcelRow, 14, "零稅");
                                break;
                            }
                        case "3":
                            {
                                Xls.SetCellValue(6 + ExcelRow, 14, "免稅");
                                break;
                            }
                    }


                    switch (dt.Rows[i]["im_fgitri"].ToString())
                    {
                        case "06":
                            {
                                Xls.SetCellValue(6 + ExcelRow, 15, "所內");
                                break;
                            }
                        case "07":
                            {
                                Xls.SetCellValue(6 + ExcelRow, 15, "院內");
                                break;
                            }
                        default:
                            {
                                Xls.SetCellValue(6 + ExcelRow, 15, "一般");
                                break;
                            }
                    }
                    Xls.SetCellValue(6 + ExcelRow, 16, dt.Rows[i]["proj_projno"].ToString());
                    Xls.SetCellValue(6 + ExcelRow, 17, dt.Rows[i]["adr_addate"].ToString() == "" ? "" : dt.Rows[i]["adr_addate"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["adr_addate"].ToString().Substring(6, 2));
                    Xls.SetCellValue(6 + ExcelRow, 18, dt.Rows[i]["adr_seq"].ToString());
                    Xls.SetCellValue(6 + ExcelRow, 19, Convert.ToInt32(dt.Rows[i]["adr_adamt"].ToString()));
                    Xls.SetCellValue(6 + ExcelRow, 20, Convert.ToInt32(dt.Rows[i]["adr_desamt"].ToString()));
                    Xls.SetCellValue(6 + ExcelRow, 21, Convert.ToInt32(dt.Rows[i]["adr_chgamt"].ToString()));
                    Xls.SetCellValue(6 + ExcelRow, 22, Convert.ToInt32(dt.Rows[i]["adr_invamt"].ToString()));

                    DataSet dspy = myIA.GetSAPMoneysum_py(dt.Rows[i]["cont_contno"].ToString());
                    if (dspy.Tables[0].Rows.Count > 0)
                    {
                        Xls.SetCellValue(6 + ExcelRow, 8, Convert.ToInt32(dspy.Tables[0].Rows[0]["sum_py"].ToString()));
                    }
                    else
                    {
                        Xls.SetCellValue(6 + ExcelRow, 8, 0);
                    }

                    DataSet dsia = myIA.GetSAPMoneysum_ia(dt.Rows[i]["cont_contno"].ToString());
                    if (dsia.Tables[0].Rows.Count > 0)
                    {
                        Xls.SetCellValue(6 + ExcelRow, 9, Convert.ToInt32(dsia.Tables[0].Rows[0]["sum_ia"].ToString()));
                    }
                    else
                    {
                        Xls.SetCellValue(6 + ExcelRow, 9, 0);
                    }

                    contno = dt.Rows[i]["cont_contno"].ToString();
                    imseq = dt.Rows[i]["adr_imseq"].ToString();
                    ExcelRow++;
                    littleCount++;
                    littleMoney += Convert.ToInt32(dt.Rows[i]["adr_invamt"].ToString());
                    TotalCount += Convert.ToInt32(dt.Rows[i]["adr_invamt"].ToString());
                }

                if (i == dt.Rows.Count - 1)//如果是最後一筆 把小計加進去
                {
                    Xls.SetCellValue(6 + ExcelRow, 1, "");
                    Xls.SetCellValue(6 + ExcelRow, 2, "");
                    Xls.SetCellValue(6 + ExcelRow, 3, "");
                    Xls.SetCellValue(6 + ExcelRow, 4, "");
                    Xls.SetCellValue(6 + ExcelRow, 5, "");
                    Xls.SetCellValue(6 + ExcelRow, 6, "");
                    Xls.SetCellValue(6 + ExcelRow, 7, "");
                    Xls.SetCellValue(6 + ExcelRow, 8, "");
                    Xls.SetCellValue(6 + ExcelRow, 9, "");
                    Xls.SetCellValue(6 + ExcelRow, 10, "");
                    Xls.SetCellValue(6 + ExcelRow, 11, "");
                    Xls.SetCellValue(6 + ExcelRow, 12, "");
                    Xls.SetCellValue(6 + ExcelRow, 13, "");
                    Xls.SetCellValue(6 + ExcelRow, 14, "");
                    Xls.SetCellValue(6 + ExcelRow, 15, "");
                    Xls.SetCellValue(6 + ExcelRow, 16, "");

                    Xls.SetCellValue(6 + ExcelRow, 17, "", tfLcountI);
                    Xls.SetCellValue(6 + ExcelRow, 18, "小計筆數：", tfLcountI);
                    Xls.MergeCells(6 + ExcelRow, 18, 6 + ExcelRow, 19);
                    Xls.SetCellValue(6 + ExcelRow, 19, "", tfLcountI);
                    Xls.SetCellValue(6 + ExcelRow, 20, littleCount, tfRLcountI);
                    Xls.SetCellValue(6 + ExcelRow, 21, "小計金額：", tfLcountI);
                    Xls.SetCellValue(6 + ExcelRow, 22, littleMoney, tfLcountI);
                }
            }


            //塞總和
            Xls.InsertAndCopyRange(myRangeTotal, 6 + ExcelRow + 1, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
            Xls.SetCellValue(6 + ExcelRow + 1, 22, TotalCount);
            Xls.ActiveSheet = 2;
            Xls.DeleteRange(myRangeTotal, TFlxInsertMode.NoneDown);
            Xls.ActiveSheet = 1;

            Common.excuteExcel(Xls, "RptIA_PreList.xls");
        }
    }
}