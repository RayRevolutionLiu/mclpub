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
    public partial class RptIA1_ChkFilter : System.Web.UI.Page
    {
        RptIA1_ChkFilter_DB myRpt = new RptIA1_ChkFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind_dgdIA();
            }
        }

        private void Bind_dgdIA()
        {
            DataSet ds = myRpt.GetIA("", "");		//沒有批次資料
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "ia_status = ''";
            dv.Sort = "ia_iano";



            //			switch (ddlSort.SelectedItem.Value)
            //			{
            //				case "1":
            //					dv.Sort = "ia_iano";
            //					break;
            //				case "2":
            //					dv.Sort = "cont_empno, ia_contno";
            //					break;
            //			}
            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();
        }

        protected void DataGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                switch (e.Row.Cells[6].Text.Trim())
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
                switch (e.Row.Cells[7].Text.Trim())
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
                switch (e.Row.Cells[8].Text.Trim())
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string iano = thisRow.Cells[0].Text.Trim();

            DataSet ds = myRpt.GetIAPrint(iano);
            DataTable dt = ds.Tables[0];

            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/SetAccount/template/RptIA1_ChkListNew.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            TXlsCellRange myRange = new TXlsCellRange("A5:X5");
            TXlsCellRange myRangeBlue = new TXlsCellRange("A6:X6");
            TXlsCellRange myRangeTotal = new TXlsCellRange("A1:X1");

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
                    for (int i = 7; i < dt.Rows.Count + 7 - 2; i++)
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

            Xls.SetCellValue(3, 4, Account.GetAccInfo().srspn_cname.ToString().Trim());

            string iano_pre = "";
            int count = 0;
            int TotalMoney = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ia_iano"].ToString().Trim() == iano_pre)
                {
                    Xls.SetCellValue(i + 5, 1, "");
                    Xls.SetCellValue(i + 5, 2, "");
                    Xls.SetCellValue(i + 5, 4, "");
                    Xls.SetCellValue(i + 5, 5, "");
                    Xls.SetCellValue(i + 5, 6, "");
                    Xls.SetCellValue(i + 5, 7, "");
                    Xls.SetCellValue(i + 5, 8, "");
                    Xls.SetCellValue(i + 5, 9, "");
                    Xls.SetCellValue(i + 5, 10, "");
                    Xls.SetCellValue(i + 5, 12, "");
                    Xls.SetCellValue(i + 5, 13, "");
                    Xls.SetCellValue(i + 5, 14, "");
                    Xls.SetCellValue(i + 5, 15, "");
                    Xls.SetCellValue(i + 5, 16, "");
                    Xls.SetCellValue(i + 5, 19, "");
                }
                else
                {
                    iano_pre = dt.Rows[i]["ia_iano"].ToString().Trim();
                    Xls.SetCellValue(i + 5, 1, i + 1);

                    Xls.SetCellValue(i + 5, 2, dt.Rows[i]["ia_iano"].ToString().Trim());
                    Xls.SetCellValue(i + 5, 4, dt.Rows[i]["ia_mfrno"].ToString().Trim());
                    Xls.SetCellValue(i + 5, 5, dt.Rows[i]["im_mfr_inm"].ToString().Trim());
                    Xls.SetCellValue(i + 5, 6, dt.Rows[i]["ia_rnm"].ToString().Trim() + dt.Rows[i]["ia_rjbti"].ToString().Trim());
                    Xls.SetCellValue(i + 5, 7, dt.Rows[i]["ia_rzip"].ToString().Trim() + dt.Rows[i]["ia_raddr"].ToString().Trim());
                    Xls.SetCellValue(i + 5, 8, dt.Rows[i]["ia_rtel"].ToString().Trim());
                    Xls.SetCellValue(i + 5, 9, dt.Rows[i]["cont_mfr_inm"].ToString().Trim());

                    if (dt.Rows[i]["ia_invcd"].ToString().Trim() == "2")
                    {
                        Xls.SetCellValue(i + 5, 10, "二聯");
                    }
                    else if (dt.Rows[i]["ia_invcd"].ToString().Trim() == "3")
                    {
                        Xls.SetCellValue(i + 5, 10, "三聯");
                    }
                    else if (dt.Rows[i]["ia_invcd"].ToString().Trim() == "4")
                    {
                        Xls.SetCellValue(i + 5, 10, "其他");
                    }


                    if (dt.Rows[i]["ia_taxtp"].ToString().Trim() == "1")
                    {
                        Xls.SetCellValue(i + 5, 11, "5%");
                    }
                    else if (dt.Rows[i]["ia_taxtp"].ToString().Trim() == "2")
                    {
                        Xls.SetCellValue(i + 5, 11, "零稅");
                    }
                    else if (dt.Rows[i]["ia_taxtp"].ToString().Trim() == "3")
                    {
                        Xls.SetCellValue(i + 5, 11, "免稅");
                    }

                    if (dt.Rows[i]["ia_fgitri"].ToString().Trim() == "06")
                    {
                        Xls.SetCellValue(i + 5, 12, "所內");
                    }
                    else if (dt.Rows[i]["ia_taxtp"].ToString().Trim() == "07")
                    {
                        Xls.SetCellValue(i + 5, 12, "院內");
                    }
                    else if (dt.Rows[i]["ia_taxtp"].ToString().Trim() == "")
                    {
                        Xls.SetCellValue(i + 5, 12, "一般");
                    }

                    Xls.SetCellValue(i + 5, 13, dt.Rows[i]["iad_costctr"].ToString().Trim());
                    Xls.SetCellValue(i + 5, 14, dt.Rows[i]["iad_projno"].ToString().Trim());
                    Xls.SetCellValue(i + 5, 15, dt.Rows[i]["iad_fk1"].ToString().Trim());
                    Xls.SetCellValue(i + 5, 16, dt.Rows[i]["cont_sdate"].ToString().Trim() + "~" + dt.Rows[i]["cont_edate"].ToString().Trim());
                    Xls.SetCellValue(i + 5, 19, dt.Rows[i]["ia_cname"].ToString().Trim());
                }

                Xls.SetCellValue(i + 5, 3, dt.Rows[i]["iad_iaditem"].ToString().Trim());
                Xls.SetCellValue(i + 5, 17, dt.Rows[i]["iad_fk3"].ToString().Trim());
                Xls.SetCellValue(i + 5, 18, dt.Rows[i]["iad_fk2"].ToString().Trim().Substring(0, 4) + "/" + dt.Rows[i]["iad_fk2"].ToString().Trim().Substring(4, 2) + "/" + dt.Rows[i]["iad_fk2"].ToString().Trim().Substring(6, 2));
                Xls.SetCellValue(i + 5, 20, Convert.ToInt32(dt.Rows[i]["adr_adamt"].ToString().Trim()));
                Xls.SetCellValue(i + 5, 21, Convert.ToInt32(dt.Rows[i]["adr_desamt"].ToString().Trim()));
                Xls.SetCellValue(i + 5, 22, Convert.ToInt32(dt.Rows[i]["adr_chgamt"].ToString().Trim()));
                Xls.SetCellValue(i + 5, 23, Convert.ToInt32(dt.Rows[i]["adr_invamt"].ToString().Trim()));
                Xls.SetCellValue(i + 5, 24, dt.Rows[i]["adr_remark"].ToString().Trim());
                count++;
                TotalMoney += Convert.ToInt32(dt.Rows[i]["adr_invamt"].ToString().Trim());
            }

            Xls.InsertAndCopyRange(myRangeTotal, dt.Rows.Count + 7, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);

            Xls.SetCellValue(dt.Rows.Count + 7, 19, count);
            Xls.SetCellValue(dt.Rows.Count + 7, 23, TotalMoney);

            Common.excuteExcel(Xls, "RptIA1_ChkListNew.xls");
        }
    }
}