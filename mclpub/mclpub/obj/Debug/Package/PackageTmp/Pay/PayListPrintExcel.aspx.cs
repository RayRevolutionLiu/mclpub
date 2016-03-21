using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using FlexCel.Core;
using FlexCel.XlsAdapter;
using FlexCel.Render;
using System.IO;

namespace mclpub.Pay
{
    public partial class PayListPrintExcel1 : System.Web.UI.Page
    {
        PayListFilter_DB myPay = new PayListFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //由於兩個參數都是數字 用轉換來判斷是否亂輸入
                Convert.ToInt32(Request.QueryString["lblyyyymm"]).ToString();
                Convert.ToInt32(Request.QueryString["lblbatch"]).ToString();
                //pytp_nm為五種範圍內 所以可以強迫宣告
                string pytp_nm = Request.QueryString["pytp_nm"];
                if (pytp_nm != "現金" && pytp_nm != "票據" && pytp_nm != "劃撥" && pytp_nm != "電匯" && pytp_nm != "信用卡")
                {
                    JavaScript.AlertMessageRedirect(this.Page, "參數錯誤", "../Default.aspx");
                }


                string lblyyyymm = Request.QueryString["lblyyyymm"].ToString();
                string lblbatch = Request.QueryString["lblbatch"].ToString();
                string cname = Account.GetAccInfo().srspn_cname.ToString().Trim();
                //string cname = "劉明睿";
                Response.Clear();
                ExcelFile Xls = new XlsFile(true);
                //用SWITCH來控制要去抓哪個EXCEL TEMPLATE
                string whitch = "";
                switch (pytp_nm)
                {
                    case "現金":
                        {
                            whitch = "1";
                            break;
                        }
                    case "票據":
                        {
                            whitch = "2";
                            break;
                        }
                    case "劃撥":
                        {
                            whitch = "3";
                            break;
                        }
                    case "電匯":
                        {
                            whitch = "4";
                            break;
                        }
                    case "信用卡":
                        {
                            whitch = "5";
                            break;
                        }
                    default:
                        {
                            return;
                        }
                }
                string fileSpec = Server.MapPath("~/Pay/Template/" + "py_list" + whitch + ".xls");
                Xls.Open(fileSpec);
                Xls.ActiveSheet = 1;
                //把上面的日期跟列印人放上去
                Xls.SetCellValue(3, 3, DateTime.Now.ToString("yyyy/MM/dd"));
                Xls.SetCellValue(3, 10, cname);

                if (pytp_nm == "現金")
                {
                    FunCtionpy_list1(Xls, cname, lblyyyymm, lblbatch);
                }
                else if (pytp_nm == "票據")
                {
                    FunCtionpy_list2(Xls, cname, lblyyyymm, lblbatch);
                }
                else if (pytp_nm == "劃撥")
                {
                    FunCtionpy_list3(Xls, cname, lblyyyymm, lblbatch);
                }
                else if (pytp_nm == "電匯")
                {
                    FunCtionpy_list4(Xls, cname, lblyyyymm, lblbatch);
                }
                else if (pytp_nm == "信用卡")
                {
                    FunCtionpy_list5(Xls, cname, lblyyyymm, lblbatch);
                }
            }
            catch (Exception ex)
            {
                JavaScript.AlertMessageRedirect(this.Page, ex.Message.ToString(), "../Default.aspx");
            }
        }

        #region 匯出報表list1~list5

        public void FunCtionpy_list1(ExcelFile Xls, string cname, string lblyyyymm, string lblbatch)
        {
            DataSet ds = myPay.SelectExportExcel("01", lblyyyymm, lblbatch);
            DataTable dt = ds.Tables[0];
            string preNo = "";
            string preIano = "";
            int TotalCount = 0;
            int count = 0;
            TXlsCellRange myRange = new TXlsCellRange("A6:L6");
            TXlsCellRange myRangeTotal = new TXlsCellRange("A1:L3");

            TFlxFormat tfMoney = Xls.GetDefaultFormat;
            tfMoney.Font.Name = "Times New Roman";
            //tfMoney.Font.Color = TExcelColor.FromArgb(System.Drawing.Color.Red.ToArgb());
            tfMoney.Font.Size20 = 180;
            tfMoney.Format = "$#,##0";
            //tfMoney.Borders.Bottom.Style = TFlxBorderStyle.Medium;
            int tfMoneyI = Xls.AddFormat(tfMoney);
            tfMoney = null;

            TFlxFormat tfBorder = Xls.GetDefaultFormat;
            tfBorder.Borders.Right.Style = TFlxBorderStyle.Medium;
            tfBorder.Font.Size20 = 180;
            tfBorder.Font.Name = "Times New Roman";
            int tfBorderI = Xls.AddFormat(tfBorder);

            TFlxFormat tfBorderTop = Xls.GetDefaultFormat;
            tfBorderTop.Borders.Top.Style = TFlxBorderStyle.Medium;
            tfBorderTop.Font.Size20 = 180;
            tfBorderTop.Format = "$#,##0";
            tfBorderTop.Font.Name = "Times New Roman";
            int tfBorderTopI = Xls.AddFormat(tfBorderTop);

            Common.FillEmptyRow(dt.Rows.Count, 6, myRange, Xls);//填格式

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (preNo == dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim())
                {
                    Xls.SetCellValue(i + 6, 1, "");
                    Xls.SetCellValue(i + 6, 2, "");
                    Xls.SetCellValue(i + 6, 3, "");
                    Xls.SetCellValue(i + 6, 4, "");
                    if (dt.Rows[i]["ia_iano"].ToString() == preIano)
                    {
                        Xls.SetCellValue(i + 6, 4, "");
                        Xls.SetCellValue(i + 6, 5, "");
                        Xls.SetCellValue(i + 6, 6, "");
                        Xls.SetCellValue(i + 6, 7, "");
                        Xls.SetCellValue(i + 6, 8, "");
                        Xls.SetCellValue(i + 6, 11, "");
                        Xls.SetCellValue(i + 6, 12, "", tfBorderI);
                    }
                    else
                    {
                        Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                        Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                        Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                        Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                        Xls.SetCellValue(i + 6, 8, dt.Rows[i]["ia_invno"].ToString());
                        Xls.SetCellValue(i + 6, 11, dt.Rows[i]["ia_syscd"].ToString());
                        Xls.SetCellValue(i + 6, 12, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                        TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString());
                    }

                }
                else
                {
                    Xls.SetCellValue(i + 6, 1, count + 1);
                    count = count + 1;
                    Xls.SetCellValue(i + 6, 2, dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 3, dt.Rows[i]["py_pyno"].ToString());
                    Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                    Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                    Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                    Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                    Xls.SetCellValue(i + 6, 8, dt.Rows[i]["ia_invno"].ToString());
                    Xls.SetCellValue(i + 6, 11, dt.Rows[i]["ia_syscd"].ToString());
                    Xls.SetCellValue(i + 6, 12, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                    TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString());
                }


                Xls.SetCellValue(i + 6, 9, dt.Rows[i]["iad_projno"].ToString());
                Xls.SetCellValue(i + 6, 10, dt.Rows[i]["iad_desc"].ToString());

                preNo = dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim();
                preIano = dt.Rows[i]["ia_iano"].ToString();


            }
            Xls.InsertAndCopyRange(myRangeTotal, dt.Rows.Count + 5 + 1, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
            Xls.SetCellValue(dt.Rows.Count + 6, 4, TotalCount, tfBorderTopI);

            Xls.ActiveSheet = 2;
            Xls.DeleteRange(myRangeTotal, TFlxInsertMode.NoneDown);
            Xls.ActiveSheet = 1;

            Common.excuteExcel(Xls, "py_list1.xls");
        }

        public void FunCtionpy_list2(ExcelFile Xls, string cname, string lblyyyymm, string lblbatch)
        {
            DataSet ds = myPay.SelectExportExcel("02", lblyyyymm, lblbatch);
            DataTable dt = ds.Tables[0];
            string preNo = "";
            string preIano = "";
            string prePyno = "";
            int TotalCount = 0;
            int count = 0;
            TXlsCellRange myRange = new TXlsCellRange("A6:O6");
            TXlsCellRange myRangeTotal = new TXlsCellRange("A1:O3");

            TFlxFormat tfMoney = Xls.GetDefaultFormat;
            tfMoney.Font.Name = "Times New Roman";
            //tfMoney.Font.Color = TExcelColor.FromArgb(System.Drawing.Color.Red.ToArgb());
            tfMoney.Font.Size20 = 180;
            tfMoney.Format = "$#,##0";
            //tfMoney.Borders.Bottom.Style = TFlxBorderStyle.Medium;
            int tfMoneyI = Xls.AddFormat(tfMoney);
            tfMoney = null;

            TFlxFormat tfBorder = Xls.GetDefaultFormat;
            tfBorder.Borders.Right.Style = TFlxBorderStyle.Medium;
            tfBorder.Font.Size20 = 180;
            tfBorder.Font.Name = "Times New Roman";
            int tfBorderI = Xls.AddFormat(tfBorder);

            TFlxFormat tfBorderTop = Xls.GetDefaultFormat;
            tfBorderTop.Borders.Top.Style = TFlxBorderStyle.Medium;
            tfBorderTop.Font.Size20 = 180;
            tfBorderTop.Format = "$#,##0";
            tfBorderTop.Font.Name = "Times New Roman";
            int tfBorderTopI = Xls.AddFormat(tfBorderTop);

            Common.FillEmptyRow(dt.Rows.Count, 6, myRange, Xls);//填格式

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (preNo == dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim())
                {
                    Xls.SetCellValue(i + 6, 1, "");
                    Xls.SetCellValue(i + 6, 2, "");
                    Xls.SetCellValue(i + 6, 3, "");
                    Xls.SetCellValue(i + 6, 4, "");
                    //Xls.SetCellValue(i + 6, 5, "");
                    //Xls.SetCellValue(i + 6, 6, "");
                    //Xls.SetCellValue(i + 6, 7, "");
                    Xls.SetCellValue(i + 6, 8, "");
                    Xls.SetCellValue(i + 6, 9, "");
                    Xls.SetCellValue(i + 6, 10, "");
                    if (dt.Rows[i]["ia_iano"].ToString() == preIano)
                    {
                        Xls.SetCellValue(i + 6, 4, "");
                        Xls.SetCellValue(i + 6, 5, "");
                        Xls.SetCellValue(i + 6, 6, "");
                        Xls.SetCellValue(i + 6, 7, "");
                        Xls.SetCellValue(i + 6, 14, "");
                        Xls.SetCellValue(i + 6, 15, "", tfBorderI);
                    }
                    else
                    {
                        //Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                        Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                        Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                        Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                        Xls.SetCellValue(i + 6, 11, dt.Rows[i]["ia_invno"].ToString());
                        Xls.SetCellValue(i + 6, 14, dt.Rows[i]["ia_syscd"].ToString());
                        Xls.SetCellValue(i + 6, 15, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                        TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["py_amt"].ToString() == "" ? "0" : dt.Rows[i]["py_amt"].ToString());
                    }

                }
                else
                {
                    Xls.SetCellValue(i + 6, 1, count + 1);
                    count = count + 1;
                    Xls.SetCellValue(i + 6, 2, dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim());
                    if (dt.Rows[i]["py_pyno"].ToString() == prePyno)
                    {
                        Xls.SetCellValue(i + 6, 3, "");
                        Xls.SetCellValue(i + 6, 4, "");
                    }
                    else
                    {
                        Xls.SetCellValue(i + 6, 3, dt.Rows[i]["py_pyno"].ToString());
                        Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["py_amt"].ToString() == "" ? "0" : dt.Rows[i]["py_amt"].ToString()), tfMoneyI);
                    }
                    //Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                    Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                    Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                    Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                    Xls.SetCellValue(i + 6, 8, dt.Rows[i]["py_chkno"].ToString());
                    Xls.SetCellValue(i + 6, 9, dt.Rows[i]["py_chkbnm"].ToString());
                    Xls.SetCellValue(i + 6, 10, dt.Rows[i]["py_chkdate"].ToString() == "" ? "" : dt.Rows[i]["py_chkdate"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["py_chkdate"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["py_chkdate"].ToString().Substring(6, 2));
                    Xls.SetCellValue(i + 6, 11, dt.Rows[i]["ia_invno"].ToString());
                    Xls.SetCellValue(i + 6, 14, dt.Rows[i]["ia_syscd"].ToString());
                    Xls.SetCellValue(i + 6, 15, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                    TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["py_amt"].ToString() == "" ? "0" : dt.Rows[i]["py_amt"].ToString());
                }

                Xls.SetCellValue(i + 6, 12, dt.Rows[i]["iad_projno"].ToString());
                Xls.SetCellValue(i + 6, 13, dt.Rows[i]["iad_desc"].ToString());

                preNo = dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim();
                preIano = dt.Rows[i]["ia_iano"].ToString();
                prePyno = dt.Rows[i]["py_pyno"].ToString();

            }
            Xls.InsertAndCopyRange(myRangeTotal, dt.Rows.Count + 5 + 1, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
            Xls.SetCellValue(dt.Rows.Count + 6, 4, TotalCount, tfBorderTopI);

            Xls.ActiveSheet = 2;
            Xls.DeleteRange(myRangeTotal, TFlxInsertMode.NoneDown);
            Xls.ActiveSheet = 1;

            Common.excuteExcel(Xls, "py_list2.xls");
        }

        public void FunCtionpy_list3(ExcelFile Xls, string cname, string lblyyyymm, string lblbatch)
        {
            DataSet ds = myPay.SelectExportExcel("03", lblyyyymm, lblbatch);
            DataTable dt = ds.Tables[0];
            string preNo = "";
            string preIano = "";
            int TotalCount = 0;
            int count = 0;
            TXlsCellRange myRange = new TXlsCellRange("A6:N6");
            TXlsCellRange myRangeTotal = new TXlsCellRange("A1:N3");

            TFlxFormat tfMoney = Xls.GetDefaultFormat;
            tfMoney.Font.Name = "Times New Roman";
            //tfMoney.Font.Color = TExcelColor.FromArgb(System.Drawing.Color.Red.ToArgb());
            tfMoney.Font.Size20 = 180;
            tfMoney.Format = "$#,##0";
            //tfMoney.Borders.Bottom.Style = TFlxBorderStyle.Medium;
            int tfMoneyI = Xls.AddFormat(tfMoney);
            tfMoney = null;

            TFlxFormat tfBorder = Xls.GetDefaultFormat;
            tfBorder.Borders.Right.Style = TFlxBorderStyle.Medium;
            tfBorder.Font.Size20 = 180;
            tfBorder.Font.Name = "Times New Roman";
            int tfBorderI = Xls.AddFormat(tfBorder);

            TFlxFormat tfBorderTop = Xls.GetDefaultFormat;
            tfBorderTop.Borders.Top.Style = TFlxBorderStyle.Medium;
            tfBorderTop.Font.Size20 = 180;
            tfBorderTop.Format = "$#,##0";
            tfBorderTop.Font.Name = "Times New Roman";
            int tfBorderTopI = Xls.AddFormat(tfBorderTop);

            Common.FillEmptyRow(dt.Rows.Count, 6, myRange, Xls);//填格式

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (preNo == dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim())
                {
                    Xls.SetCellValue(i + 6, 1, "");
                    Xls.SetCellValue(i + 6, 2, "");
                    Xls.SetCellValue(i + 6, 3, "");
                    Xls.SetCellValue(i + 6, 4, "");
                    Xls.SetCellValue(i + 6, 8, "");
                    Xls.SetCellValue(i + 6, 9, "");
                    if (dt.Rows[i]["ia_iano"].ToString() == preIano)
                    {
                        Xls.SetCellValue(i + 6, 4, "");
                        Xls.SetCellValue(i + 6, 5, "");
                        Xls.SetCellValue(i + 6, 6, "");
                        Xls.SetCellValue(i + 6, 7, "");
                        Xls.SetCellValue(i + 6, 10, "");
                        Xls.SetCellValue(i + 6, 13, "");
                        Xls.SetCellValue(i + 6, 14, "", tfBorderI);
                    }
                    else
                    {
                        Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                        Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                        Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                        Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                        Xls.SetCellValue(i + 6, 10, dt.Rows[i]["ia_invno"].ToString());
                        Xls.SetCellValue(i + 6, 13, dt.Rows[i]["ia_syscd"].ToString());
                        Xls.SetCellValue(i + 6, 14, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                        TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString());
                    }

                }
                else
                {
                    Xls.SetCellValue(i + 6, 1, count + 1);
                    count = count + 1;
                    Xls.SetCellValue(i + 6, 2, dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 3, dt.Rows[i]["py_pyno"].ToString());
                    Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                    Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                    Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                    Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                    Xls.SetCellValue(i + 6, 8, dt.Rows[i]["py_moseq"].ToString());
                    Xls.SetCellValue(i + 6, 9, dt.Rows[i]["py_moitem"].ToString());
                    Xls.SetCellValue(i + 6, 10, dt.Rows[i]["ia_invno"].ToString());
                    Xls.SetCellValue(i + 6, 13, dt.Rows[i]["ia_syscd"].ToString());
                    Xls.SetCellValue(i + 6, 14, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                    TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString());
                }

                Xls.SetCellValue(i + 6, 11, dt.Rows[i]["iad_projno"].ToString());
                Xls.SetCellValue(i + 6, 12, dt.Rows[i]["iad_desc"].ToString());

                preNo = dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim();
                preIano = dt.Rows[i]["ia_iano"].ToString();

            }
            Xls.InsertAndCopyRange(myRangeTotal, dt.Rows.Count + 5 + 1, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
            Xls.SetCellValue(dt.Rows.Count + 6, 4, TotalCount, tfBorderTopI);

            Xls.ActiveSheet = 2;
            Xls.DeleteRange(myRangeTotal, TFlxInsertMode.NoneDown);
            Xls.ActiveSheet = 1;

            Common.excuteExcel(Xls, "py_list3.xls");
        }

        public void FunCtionpy_list4(ExcelFile Xls, string cname, string lblyyyymm, string lblbatch)
        {
            DataSet ds = myPay.SelectExportExcel("04", lblyyyymm, lblbatch);
            DataTable dt = ds.Tables[0];
            string preNo = "";
            string preIano = "";
            int TotalCount = 0;
            int count = 0;
            TXlsCellRange myRange = new TXlsCellRange("A6:O6");
            TXlsCellRange myRangeTotal = new TXlsCellRange("A1:O3");

            TFlxFormat tfMoney = Xls.GetDefaultFormat;
            tfMoney.Font.Name = "Times New Roman";
            //tfMoney.Font.Color = TExcelColor.FromArgb(System.Drawing.Color.Red.ToArgb());
            tfMoney.Font.Size20 = 180;
            tfMoney.Format = "$#,##0";
            //tfMoney.Borders.Bottom.Style = TFlxBorderStyle.Medium;
            int tfMoneyI = Xls.AddFormat(tfMoney);
            tfMoney = null;

            TFlxFormat tfBorder = Xls.GetDefaultFormat;
            tfBorder.Borders.Right.Style = TFlxBorderStyle.Medium;
            tfBorder.Font.Size20 = 180;
            tfBorder.Font.Name = "Times New Roman";
            int tfBorderI = Xls.AddFormat(tfBorder);

            TFlxFormat tfBorderTop = Xls.GetDefaultFormat;
            tfBorderTop.Borders.Top.Style = TFlxBorderStyle.Medium;
            tfBorderTop.Font.Size20 = 180;
            tfBorderTop.Format = "$#,##0";
            tfBorderTop.Font.Name = "Times New Roman";
            int tfBorderTopI = Xls.AddFormat(tfBorderTop);

            Common.FillEmptyRow(dt.Rows.Count, 6, myRange, Xls);//填格式

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (preNo == dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim())
                {
                    Xls.SetCellValue(i + 6, 1, "");
                    Xls.SetCellValue(i + 6, 2, "");
                    Xls.SetCellValue(i + 6, 3, "");
                    Xls.SetCellValue(i + 6, 4, "");
                    Xls.SetCellValue(i + 6, 8, "");
                    Xls.SetCellValue(i + 6, 9, "");
                    Xls.SetCellValue(i + 6, 10, "");
                    if (dt.Rows[i]["ia_iano"].ToString() == preIano)
                    {
                        Xls.SetCellValue(i + 6, 4, "");
                        Xls.SetCellValue(i + 6, 5, "");
                        Xls.SetCellValue(i + 6, 6, "");
                        Xls.SetCellValue(i + 6, 7, "");
                        Xls.SetCellValue(i + 6, 11, "");
                        Xls.SetCellValue(i + 6, 14, "");
                        Xls.SetCellValue(i + 6, 15, "", tfBorderI);
                    }
                    else
                    {
                        Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                        Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                        Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                        Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                        Xls.SetCellValue(i + 6, 11, dt.Rows[i]["ia_invno"].ToString());
                        Xls.SetCellValue(i + 6, 14, dt.Rows[i]["ia_syscd"].ToString());
                        Xls.SetCellValue(i + 6, 15, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                        TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString());
                    }

                }
                else
                {
                    Xls.SetCellValue(i + 6, 1, count + 1);
                    count = count + 1;
                    Xls.SetCellValue(i + 6, 2, dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 3, dt.Rows[i]["py_pyno"].ToString());
                    Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                    Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                    Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                    Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                    Xls.SetCellValue(i + 6, 8, dt.Rows[i]["py_wbcd"].ToString());
                    Xls.SetCellValue(i + 6, 9, dt.Rows[i]["py_waccno"].ToString());
                    Xls.SetCellValue(i + 6, 10, dt.Rows[i]["py_wdate"].ToString() == "" ? "" : dt.Rows[i]["py_wdate"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["py_wdate"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["py_wdate"].ToString().Substring(6, 2));
                    Xls.SetCellValue(i + 6, 11, dt.Rows[i]["ia_invno"].ToString());
                    Xls.SetCellValue(i + 6, 14, dt.Rows[i]["ia_syscd"].ToString());
                    Xls.SetCellValue(i + 6, 15, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                    TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString());
                }

                Xls.SetCellValue(i + 6, 12, dt.Rows[i]["iad_projno"].ToString());
                Xls.SetCellValue(i + 6, 13, dt.Rows[i]["iad_desc"].ToString());

                preNo = dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim();
                preIano = dt.Rows[i]["ia_iano"].ToString();

            }
            Xls.InsertAndCopyRange(myRangeTotal, dt.Rows.Count + 5 + 1, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
            Xls.SetCellValue(dt.Rows.Count + 6, 4, TotalCount, tfBorderTopI);

            Xls.ActiveSheet = 2;
            Xls.DeleteRange(myRangeTotal, TFlxInsertMode.NoneDown);
            Xls.ActiveSheet = 1;

            Common.excuteExcel(Xls, "py_list4.xls");
        }

        public void FunCtionpy_list5(ExcelFile Xls, string cname, string lblyyyymm, string lblbatch)
        {
            DataSet ds = myPay.SelectExportExcel("05", lblyyyymm, lblbatch);
            DataTable dt = ds.Tables[0];
            string preNo = "";
            string preIano = "";
            int TotalCount = 0;
            int count = 0;
            TXlsCellRange myRange = new TXlsCellRange("A6:O6");
            TXlsCellRange myRangeTotal = new TXlsCellRange("A1:O3");

            TFlxFormat tfMoney = Xls.GetDefaultFormat;
            tfMoney.Font.Name = "Times New Roman";
            //tfMoney.Font.Color = TExcelColor.FromArgb(System.Drawing.Color.Red.ToArgb());
            tfMoney.Font.Size20 = 180;
            tfMoney.Format = "$#,##0";
            //tfMoney.Borders.Bottom.Style = TFlxBorderStyle.Medium;
            int tfMoneyI = Xls.AddFormat(tfMoney);
            tfMoney = null;

            TFlxFormat tfBorder = Xls.GetDefaultFormat;
            tfBorder.Borders.Right.Style = TFlxBorderStyle.Medium;
            tfBorder.Font.Size20 = 180;
            tfBorder.Font.Name = "Times New Roman";
            int tfBorderI = Xls.AddFormat(tfBorder);

            TFlxFormat tfBorderTop = Xls.GetDefaultFormat;
            tfBorderTop.Borders.Top.Style = TFlxBorderStyle.Medium;
            tfBorderTop.Font.Size20 = 180;
            tfBorderTop.Format = "$#,##0";
            tfBorderTop.Font.Name = "Times New Roman";
            int tfBorderTopI = Xls.AddFormat(tfBorderTop);

            Common.FillEmptyRow(dt.Rows.Count, 6, myRange, Xls);//填格式

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (preNo == dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim())
                {
                    Xls.SetCellValue(i + 6, 1, "");
                    Xls.SetCellValue(i + 6, 2, "");
                    Xls.SetCellValue(i + 6, 3, "");
                    Xls.SetCellValue(i + 6, 4, "");
                    Xls.SetCellValue(i + 6, 8, "");
                    Xls.SetCellValue(i + 6, 9, "");
                    Xls.SetCellValue(i + 6, 10, "");
                    if (dt.Rows[i]["ia_iano"].ToString() == preIano)
                    {
                        Xls.SetCellValue(i + 6, 4, "");
                        Xls.SetCellValue(i + 6, 5, "");
                        Xls.SetCellValue(i + 6, 6, "");
                        Xls.SetCellValue(i + 6, 7, "");
                        Xls.SetCellValue(i + 6, 11, "");
                        Xls.SetCellValue(i + 6, 14, "");
                        Xls.SetCellValue(i + 6, 15, "", tfBorderI);
                    }
                    else
                    {
                        Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                        Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                        Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                        Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                        Xls.SetCellValue(i + 6, 11, dt.Rows[i]["ia_invno"].ToString());
                        Xls.SetCellValue(i + 6, 14, dt.Rows[i]["ia_syscd"].ToString());
                        Xls.SetCellValue(i + 6, 15, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                        TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString());
                    }

                }
                else
                {
                    Xls.SetCellValue(i + 6, 1, count + 1);
                    count = count + 1;
                    Xls.SetCellValue(i + 6, 2, dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 3, dt.Rows[i]["py_pyno"].ToString());
                    Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                    Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                    Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                    Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                    Xls.SetCellValue(i + 6, 8, dt.Rows[i]["py_ccno"].ToString());
                    Xls.SetCellValue(i + 6, 9, dt.Rows[i]["py_ccauthcd"].ToString());
                    Xls.SetCellValue(i + 6, 10, dt.Rows[i]["py_ccvdate"].ToString());
                    Xls.SetCellValue(i + 6, 11, dt.Rows[i]["ia_invno"].ToString());
                    Xls.SetCellValue(i + 6, 14, dt.Rows[i]["ia_syscd"].ToString());
                    Xls.SetCellValue(i + 6, 15, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                    TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString() == "" ? "0" : dt.Rows[i]["ia_pyat"].ToString());
                }

                Xls.SetCellValue(i + 6, 12, dt.Rows[i]["iad_projno"].ToString());
                Xls.SetCellValue(i + 6, 13, dt.Rows[i]["iad_desc"].ToString());

                preNo = dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim();
                preIano = dt.Rows[i]["ia_iano"].ToString();

            }
            Xls.InsertAndCopyRange(myRangeTotal, dt.Rows.Count + 5 + 1, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
            Xls.SetCellValue(dt.Rows.Count + 6, 4, TotalCount, tfBorderTopI);

            Xls.ActiveSheet = 2;
            Xls.DeleteRange(myRangeTotal, TFlxInsertMode.NoneDown);
            Xls.ActiveSheet = 1;

            Common.excuteExcel(Xls, "py_list5.xls");
        }
        #endregion
    }
}