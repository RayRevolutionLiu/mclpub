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
using System.IO;

namespace mclpub.Pay
{
    public partial class UnpaidListFilter : System.Web.UI.Page
    {
        UnpaidListFilter_DB myUna = new UnpaidListFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
            }
        }

        public DataSet BindGrid(string type)
        {
            string date1, date2;
            date1 = tbxDate1.Text == "" ? "" : tbxDate1.Text.Substring(0, 4) + tbxDate1.Text.Substring(5, 2) + tbxDate1.Text.Substring(8, 2);
            date2 = tbxDate2.Text == "" ? "" : tbxDate2.Text.Substring(0, 4) + tbxDate2.Text.Substring(5, 2) + tbxDate2.Text.Substring(8, 2);

            DataSet ds1 = myUna.Selectv_ia_unpaid(tbxProj.Text.Trim(), date1, date2, tbxMfrno.Text.Trim(), tbxMfrname.Text.Trim(), tbxInvno.Text.Trim(), tbxIano.Text.Trim(), type);

            return ds1;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;

            DataSet ds1 = BindGrid("");

            if (ds1.Tables[0].Rows.Count > 0)
            {
                lblMessage.Text = "查詢到" + ds1.Tables[0].Rows.Count.ToString() + "筆資料";
                btnPrintList.Enabled = true;

            }
            else
            {
                lblMessage.Text = "";
                btnPrintList.Enabled = false;
            }
            DataGrid1.DataSource = ds1;
            DataGrid1.DataBind();
        }

        protected void btnPrintList_Click(object sender, EventArgs e)
        {
            string cname = Account.GetAccInfo().srspn_cname.ToString().Trim();
            string dateNow = DateTime.Now.ToString("yyyy/MM/dd");
            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Pay/Template/unpaid_list.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;
            Xls.SetCellValue(2, 3, tbxProj.Text.Trim());
            Xls.SetCellValue(2, 6, tbxDate1.Text.Trim() + "～" + tbxDate2.Text.Trim());
            Xls.SetCellValue(2, 11, tbxInvno.Text.Trim());
            Xls.SetCellValue(2, 16, tbxIano.Text.Trim());
            Xls.SetCellValue(3, 3, tbxMfrno.Text.Trim());
            Xls.SetCellValue(3, 6, tbxMfrname.Text.Trim());
            Xls.SetCellValue(4, 3, dateNow);
            Xls.SetCellValue(4, 6, cname);

            DataSet ds1 = BindGrid("excel");
            DataTable dt = ds1.Tables[0];

            int Tia_pyat = 0;
            int Tpy_amt = 0;
            int Tiad_amt = 0;

            TXlsCellRange myRange = new TXlsCellRange("A7:Z7");
            TXlsCellRange myRangeTotal = new TXlsCellRange("A1:Z1");

            TFlxFormat tfMoney = Xls.GetDefaultFormat;
            tfMoney.Font.Name = "Times New Roman";
            //tfMoney.Font.Color = TExcelColor.FromArgb(System.Drawing.Color.Red.ToArgb());
            tfMoney.Font.Size20 = 160;
            tfMoney.Format = "$#,##0";
            //tfMoney.Borders.Bottom.Style = TFlxBorderStyle.Medium;
            int tfMoneyI = Xls.AddFormat(tfMoney);
            tfMoney = null;

            TFlxFormat tfBorderTop = Xls.GetDefaultFormat;
            tfBorderTop.Borders.Top.Style = TFlxBorderStyle.Medium;
            tfBorderTop.Borders.Bottom.Style = TFlxBorderStyle.Medium;
            tfBorderTop.Font.Size20 = 160;
            tfBorderTop.Format = "$#,##0";
            tfBorderTop.Font.Name = "Times New Roman";
            int tfBorderTopI = Xls.AddFormat(tfBorderTop);
            tfBorderTop = null;

            Common.FillEmptyRow(dt.Rows.Count, 7, myRange, Xls);//填格式

            if (ds1.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Xls.SetCellValue(i + 7, 1, i + 1);
                    Xls.SetCellValue(i + 7, 2, dt.Rows[i]["mfr_inm"].ToString());
                    Xls.SetCellValue(i + 7, 3, dt.Rows[i]["ia_mfrno"].ToString());
                    Xls.SetCellValue(i + 7, 4, dt.Rows[i]["ia_invdate"].ToString() == "" ? "" : dt.Rows[i]["ia_invdate"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["ia_invdate"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["ia_invdate"].ToString().Substring(6, 2));
                    Xls.SetCellValue(i + 7, 5, dt.Rows[i]["ia_invno"].ToString());
                    Xls.SetCellValue(i + 7, 6, dt.Rows[i]["iad_desc"].ToString());
                    Xls.SetCellValue(i + 7, 7, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                    Xls.SetCellValue(i + 7, 8, Convert.ToInt32(dt.Rows[i]["py_amt"].ToString() == "" ? "0" : dt.Rows[i]["py_amt"].ToString()), tfMoneyI);
                    Xls.SetCellValue(i + 7, 9, Convert.ToInt32(dt.Rows[i]["iad_amt"].ToString() == "" ? "0" : dt.Rows[i]["iad_amt"].ToString()), tfMoneyI);
                    Xls.SetCellValue(i + 7, 10, dt.Rows[i]["py_chkno"].ToString());
                    Xls.SetCellValue(i + 7, 11, dt.Rows[i]["py_pyno"].ToString());
                    Xls.SetCellValue(i + 7, 12,dt.Rows[i]["py_date"].ToString() == "" ? "" : dt.Rows[i]["py_date"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["py_date"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["py_date"].ToString().Substring(6, 2));
                    Xls.SetCellValue(i + 7, 13, dt.Rows[i]["ia_syscd"].ToString());
                    Xls.SetCellValue(i + 7, 14, dt.Rows[i]["ia_iano"].ToString());
                    Xls.SetCellValue(i + 7, 15, dt.Rows[i]["ia_iasdate"].ToString());
                    Xls.SetCellValue(i + 7, 16, dt.Rows[i]["ia_iasseq"].ToString());
                    Xls.SetCellValue(i + 7, 17, dt.Rows[i]["ias_createdate"].ToString() == "" ? "" : dt.Rows[i]["ias_createdate"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["ias_createdate"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["ias_createdate"].ToString().Substring(6, 2));
                    Xls.SetCellValue(i + 7, 18, dt.Rows[i]["srspn_cname"].ToString());
                    Xls.SetCellValue(i + 7, 19, dt.Rows[i]["ia_fgitri"].ToString());
                    if (dt.Rows[i]["ias_trans_sap"].ToString() == "1")
                    {
                        Xls.SetCellValue(i + 7, 20, "v");
                    }
                    else
                    {
                        Xls.SetCellValue(i + 7, 20, "");
                    }
                    if (dt.Rows[i]["ia_fgnonauto"].ToString() == "0")
                    {
                        Xls.SetCellValue(i + 7, 21, "");
                    }
                    else if (dt.Rows[i]["ia_fgnonauto"].ToString() == "1")
                    {
                        Xls.SetCellValue(i + 7, 21, "手工發票");
                    }
                    else if (dt.Rows[i]["ia_fgnonauto"].ToString() == "2")
                    {
                        Xls.SetCellValue(i + 7, 21, "手工發票,手工繳款");
                    }
                    else if (dt.Rows[i]["ia_fgnonauto"].ToString() == "3")
                    {
                        Xls.SetCellValue(i + 7, 21, "手工繳款");
                    }
                    Xls.SetCellValue(i + 7, 22, dt.Rows[i]["ia_remark"].ToString());
                    Xls.SetCellValue(i + 7, 23, dt.Rows[i]["iad_fk1"].ToString());
                    Xls.SetCellValue(i + 7, 24, dt.Rows[i]["iad_fk2"].ToString());
                    Xls.SetCellValue(i + 7, 25, dt.Rows[i]["iad_fk3"].ToString());
                    Xls.SetCellValue(i + 7, 26, dt.Rows[i]["iad_fk4"].ToString());
                    Tia_pyat += Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString());
                    Tpy_amt += Convert.ToInt32(dt.Rows[i]["py_amt"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString());
                    Tiad_amt += Convert.ToInt32(dt.Rows[i]["iad_amt"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString());
                }

                Xls.InsertAndCopyRange(myRangeTotal, dt.Rows.Count + 6 + 1, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
                Xls.SetCellValue(dt.Rows.Count + 6 + 1, 7, Tia_pyat, tfBorderTopI);
                Xls.SetCellValue(dt.Rows.Count + 6 + 1, 8, Tpy_amt, tfBorderTopI);
                Xls.SetCellValue(dt.Rows.Count + 6 + 1, 9, Tiad_amt, tfBorderTopI);

                Xls.ActiveSheet = 2;
                Xls.DeleteRange(myRangeTotal, TFlxInsertMode.NoneDown);
                Xls.ActiveSheet = 1;

                Common.excuteExcel(Xls, "unpaid_list.xls");
            }
            else
            {
                JavaScript.AlertMessage(this.Page, "查詢無資料");
                return;
            }
        }
    }
}