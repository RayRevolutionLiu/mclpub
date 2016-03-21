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
    public partial class RptIA_ChkFilter : System.Web.UI.Page
    {
        RptIA_ChkFilter_DB myRpt = new RptIA_ChkFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                string datestr = DateTime.Today.ToString("yyyy/MM/dd");
                tbxYYYYMM.Text = datestr.Substring(0, 7);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            lblMessage.Text = "";
            string iabseq = thisRow.Cells[1].Text.Trim();
            hiddenSeq.Value = iabseq;
            string iabdate = tbxYYYYMM.Text.Substring(0, 4) + tbxYYYYMM.Text.Substring(5, 2);
            DataSet ds = myRpt.GetIA(iabdate, iabseq);
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "ia_status = ''";//底下的是正式的 下面的是測試用
            switch (ddlSort.SelectedItem.Value)
            {
                case "1":
                    dv.Sort = "ia_iano";
                    break;
                case "2":
                    dv.Sort = "cont_empno, ia_contno";
                    break;
            }
            GridView1.DataSource = dv;
            GridView1.DataBind();
            if (GridView1.Rows.Count > 0)
            {
                pnlIA.Visible = true;
                DataGrid1.Visible = false;
                btnPrint.Visible = true;
            }
            else
            {
                pnlIA.Visible = false;
                JavaScript.AlertMessage(this.Page, "此批發票已進入會計系統, 無法列印檢核表");
                lblMessage.Text = "此批發票已進入會計系統, 無法列印檢核表";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;
            lblMessage.Text = "";
            if (tbxYYYYMM.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "產生年月不可空白");
                return;
            }
            string iabdate = tbxYYYYMM.Text.Substring(0, 4) + tbxYYYYMM.Text.Substring(5, 2);
            DataSet ds = myRpt.GetIAB(iabdate);
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
            pnlIA.Visible = false;
            btnPrint.Visible = false;
            DataGrid1.Visible = true;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (e.Row.Cells[6].Text.Trim().Replace("&nbsp;",""))
                {
                    case "2":
                        e.Row.Cells[6].Text = "二聯";
                        break;
                    case "3":
                        e.Row.Cells[6].Text = "三聯";
                        break;
                    case "4":
                        e.Row.Cells[6].Text = "其他";
                        break;
                    default:
                        e.Row.Cells[6].Text = "";
                        break;
                }
                switch (e.Row.Cells[7].Text.Trim().Replace("&nbsp;", ""))
                {
                    case "1":
                        e.Row.Cells[7].Text = "應稅5%";
                        break;
                    case "2":
                        e.Row.Cells[7].Text = "零稅";
                        break;
                    case "3":
                        e.Row.Cells[7].Text = "免稅";
                        break;
                    default:
                        e.Row.Cells[7].Text = "";
                        break;
                }
                switch (e.Row.Cells[8].Text.Trim().Replace("&nbsp;", ""))
                {
                    case "06":
                        e.Row.Cells[8].Text = "所內";
                        break;
                    case "07":
                        e.Row.Cells[8].Text = "院內";
                        break;
                    case "":
                        e.Row.Cells[8].Text = "一般";
                        break;
                    default:
                        e.Row.Cells[8].Text = "";
                        break;
                }
            }
        }


        protected void gv_data_Sorting(object sender, GridViewSortEventArgs e)
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
                {
                    ViewState["SortDirection"] = " ASC";
                }
                else
                {
                    ViewState["SortDirection"] = " DESC";
                }

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
                    if (ViewState["SortDirection"].ToString() == " ASC")
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

            lblMessage.Text = "";
            if (tbxYYYYMM.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "產生年月不可空白");
                return;
            }
            string iabdate = tbxYYYYMM.Text.Substring(0, 4) + tbxYYYYMM.Text.Substring(5, 2);
            DataSet ds = myRpt.GetIAB(iabdate);

            //給予資料來源(DataTable)並重新繫結資料
            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortDirection"].ToString();
            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();
            pnlIA.Visible = false;
            btnPrint.Visible = false;
            DataGrid1.Visible = true;
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string iabseq = hiddenSeq.Value;
            string iabdate = tbxYYYYMM.Text.Substring(0, 4) + tbxYYYYMM.Text.Substring(5, 2);
            DataSet ds = myRpt.GetIAPrint(iabdate, iabseq);
            DataView dv = ds.Tables[0].DefaultView;
            switch (ddlSort.SelectedItem.Value)
            {
                case "1":
                    dv.Sort = "ia_iano";
                    break;
                case "2":
                    dv.Sort = "cont_empno, ia_contno";
                    break;
            }

            if (dv.Count == 0)
            {
                JavaScript.AlertMessage(this.Page, "無資料");
                return;
            }

            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/SetAccount/template/RptIA_ChkListNew.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            TXlsCellRange myRange = new TXlsCellRange("A6:X6");
            TXlsCellRange myRangeBlue = new TXlsCellRange("A7:X7");
            TXlsCellRange myRangeTotal = new TXlsCellRange("A1:X1");

            if (dv.Count == 1)
            {
                Xls.DeleteRange(myRangeBlue, TFlxInsertMode.NoneDown);//只有一筆的話刪除第一區塊的藍色
                //下面一個迴圈添加單一筆內所有資料
            }
            else
            {
                if (dv.Count > 2)
                {
                    int countback = 0;
                    //兩筆的話就不用動任何迴圈
                    for (int i = 8; i < dv.Count + 8 - 2; i++)
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

            Xls.SetCellValue(4, 4, iabseq);
            Xls.SetCellValue(3, 4, tbxYYYYMM.Text.Trim());
            Xls.SetCellValue(3, 18, Account.GetAccInfo().srspn_cname.ToString().Trim());

            int Totalcount = 0;
            int FirstCol = 1;
            string iano_pre = "";
            for (int i = 0; i < dv.Count; i++)
            {
                if (dv[i]["ia_iano"].ToString().Trim() == iano_pre)
                {
                    Xls.SetCellValue(i + 6, 1, "");
                    Xls.SetCellValue(i + 6, 2, "");
                    Xls.SetCellValue(i + 6, 4, "");
                    Xls.SetCellValue(i + 6, 5, "");
                    Xls.SetCellValue(i + 6, 6, "");
                    Xls.SetCellValue(i + 6, 7, "");
                    Xls.SetCellValue(i + 6, 8, "");
                    Xls.SetCellValue(i + 6, 9, "");
                    Xls.SetCellValue(i + 6, 10, "");
                    Xls.SetCellValue(i + 6, 12, "");
                    Xls.SetCellValue(i + 6, 13, "");
                    Xls.SetCellValue(i + 6, 14, "");
                    Xls.SetCellValue(i + 6, 15, "");
                    Xls.SetCellValue(i + 6, 16, "");
                    Xls.SetCellValue(i + 6, 19, "");
                }
                else
                {
                    Xls.SetCellValue(i + 6, 1, FirstCol);
                    Xls.SetCellValue(i + 6, 2, dv[i]["ia_iano"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 3, dv[i]["iad_iaditem"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 4, dv[i]["ia_mfrno"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 5, dv[i]["im_mfr_inm"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 6, dv[i]["ia_rnm"].ToString().Trim() + dv[i]["ia_rjbti"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 7, dv[i]["ia_rzip"].ToString().Trim() + dv[i]["ia_raddr"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 8, dv[i]["ia_rtel"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 9, dv[i]["cont_mfr_inm"].ToString().Trim());
                    switch (dv[i]["ia_invcd"].ToString().Trim())
                    {
                        case "2":
                            {
                                Xls.SetCellValue(i + 6, 10, "二聯");
                                break;
                            }
                        case "3":
                            {
                                Xls.SetCellValue(i + 6, 10, "三聯");
                                break;
                            }
                        case "4":
                            {
                                Xls.SetCellValue(i + 6, 10, "其他");
                                break;
                            }
                    }

                    switch (dv[i]["ia_taxtp"].ToString().Trim())
                    {
                        case "1":
                            {
                                Xls.SetCellValue(i + 6, 11, "5%");
                                break;
                            }
                        case "2":
                            {
                                Xls.SetCellValue(i + 6, 11, "零稅");
                                break;
                            }
                        case "3":
                            {
                                Xls.SetCellValue(i + 6, 11, "免稅");
                                break;
                            }
                    }

                    switch (dv[i]["ia_fgitri"].ToString().Trim())
                    {
                        case "06":
                            {
                                Xls.SetCellValue(i + 6, 12, "所內");
                                break;
                            }
                        case "07":
                            {
                                Xls.SetCellValue(i + 6, 12, "院內");
                                break;
                            }
                        default:
                            {
                                Xls.SetCellValue(i + 6, 12, "一般");
                                break;
                            }
                    }

                    Xls.SetCellValue(i + 6, 13, dv[i]["iad_costctr"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 14, dv[i]["iad_projno"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 15, dv[i]["iad_fk1"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 16, dv[i]["cont_sdate"].ToString().Trim() + "~" + dv[i]["cont_edate"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 17, dv[i]["iad_fk3"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 18, dv[i]["iad_fk2"].ToString().Trim() == "" ? "" : dv[i]["iad_fk2"].ToString().Trim().Substring(0, 4) + "/" + dv[i]["iad_fk2"].ToString().Trim().Substring(4, 2) + "/" + dv[i]["iad_fk2"].ToString().Trim().Substring(6, 2));
                    Xls.SetCellValue(i + 6, 19, dv[i]["ia_cname"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 20, Convert.ToInt32(dv[i]["adr_adamt"].ToString().Trim()));
                    Xls.SetCellValue(i + 6, 21, Convert.ToInt32(dv[i]["adr_desamt"].ToString().Trim()));
                    Xls.SetCellValue(i + 6, 22, Convert.ToInt32(dv[i]["adr_chgamt"].ToString().Trim()));
                    Xls.SetCellValue(i + 6, 23, Convert.ToInt32(dv[i]["adr_invamt"].ToString().Trim()));
                    Xls.SetCellValue(i + 6, 24, dv[i]["adr_remark"].ToString().Trim());

                    FirstCol++;
                }

                Xls.SetCellValue(i + 6, 3, dv[i]["iad_iaditem"].ToString().Trim());

                switch (dv[i]["ia_taxtp"].ToString().Trim())
                {
                    case "1":
                        {
                            Xls.SetCellValue(i + 6, 11, "5%");
                            break;
                        }
                    case "2":
                        {
                            Xls.SetCellValue(i + 6, 11, "零稅");
                            break;
                        }
                    case "3":
                        {
                            Xls.SetCellValue(i + 6, 11, "免稅");
                            break;
                        }
                }

                Xls.SetCellValue(i + 6, 17, dv[i]["iad_fk3"].ToString().Trim());
                Xls.SetCellValue(i + 6, 18, dv[i]["iad_fk2"].ToString().Trim() == "" ? "" : dv[i]["iad_fk2"].ToString().Trim().Substring(0, 4) + "/" + dv[i]["iad_fk2"].ToString().Trim().Substring(4, 2) + "/" + dv[i]["iad_fk2"].ToString().Trim().Substring(6, 2));

                Xls.SetCellValue(i + 6, 20, Convert.ToInt32(dv[i]["adr_adamt"].ToString().Trim()));
                Xls.SetCellValue(i + 6, 21, Convert.ToInt32(dv[i]["adr_desamt"].ToString().Trim()));
                Xls.SetCellValue(i + 6, 22, Convert.ToInt32(dv[i]["adr_chgamt"].ToString().Trim()));
                Xls.SetCellValue(i + 6, 23, Convert.ToInt32(dv[i]["adr_invamt"].ToString().Trim()));
                Xls.SetCellValue(i + 6, 24, dv[i]["adr_remark"].ToString().Trim());

                Totalcount += Convert.ToInt32(dv[i]["adr_invamt"].ToString().Trim());
                iano_pre = dv[i]["ia_iano"].ToString().Trim();
            }

            Xls.InsertAndCopyRange(myRangeTotal, dv.Count + 6 + 1, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
            Xls.SetCellValue(dv.Count + 6 + 1, 23, Totalcount);

            Common.excuteExcel(Xls, "RptIA_ChkListNew.xls");
        }
    }
}