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

namespace mclpub.Pay
{
    public partial class PayListFilter : System.Web.UI.Page
    {
        PayListFilter_DB myPay = new PayListFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                //付款方式
                DataSet ds1 = myPay.Selectpytp();
                ddlPayType.DataSource = ds1;
                ddlPayType.DataTextField = "pytp_nm";
                ddlPayType.DataValueField = "pytp_pytpcd";
                ddlPayType.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataList1.Visible = false;
            DataList2.Visible = false;
            DataList3.Visible = false;
            DataList4.Visible = false;
            DataList5.Visible = false;
            btnList.Enabled = false;
            btnListPrint.Enabled = false;
            lblyyyymm.Text = "0";
            lblbatch.Text = "0";
            lbltoitem.Text = "0";
            DataGrid1.Visible = false;
            DataSet ds2 = myPay.Selectpy();
            DataView dv2 = ds2.Tables[0].DefaultView;
            dv2.RowFilter = "py_pytpcd='" + ddlPayType.SelectedItem.Value + "' and py_pysdate=''";
            if (dv2.Count <= 0)
            {
                JavaScript.AlertMessage(this.Page, "沒有資料");
                return;
            }
            else
            {
                if (ddlPayType.SelectedItem.Value == "01")
                {
                    DataList1.Visible = true;
                    DataList1.DataSource = dv2;
                    DataList1.DataBind();
                    if (DataList1.Rows.Count > 0)
                    {
                        for (int i = 0; i < DataList1.Rows.Count; i++)
                        {
                            ((CheckBox)DataList1.Rows[i].Cells[0].FindControl("CheckBox2")).Checked = true;
                        }
                    }
                }
                else if (ddlPayType.SelectedItem.Value == "02")
                {
                    DataList2.Visible = true;
                    DataList2.DataSource = dv2;
                    DataList2.DataBind();
                    if (DataList2.Rows.Count > 0)
                    {
                        for (int i = 0; i < DataList2.Rows.Count; i++)
                            ((CheckBox)DataList2.Rows[i].Cells[0].FindControl("CheckBox2")).Checked = true;
                    }
                }
                else if (ddlPayType.SelectedItem.Value == "03")
                {
                    DataList3.Visible = true;
                    DataList3.DataSource = dv2;
                    DataList3.DataBind();
                    if (DataList3.Rows.Count > 0)
                    {
                        for (int i = 0; i < DataList3.Rows.Count; i++)
                            ((CheckBox)DataList3.Rows[i].Cells[0].FindControl("CheckBox2")).Checked = true;
                    }
                }
                else if (ddlPayType.SelectedItem.Value == "04")
                {
                    DataList4.Visible = true;
                    DataList4.DataSource = dv2;
                    DataList4.DataBind();
                    if (DataList4.Rows.Count > 0)
                    {
                        for (int i = 0; i < DataList4.Rows.Count; i++)
                            ((CheckBox)DataList4.Rows[i].Cells[0].FindControl("CheckBox2")).Checked = true;
                    }
                }
                else if (ddlPayType.SelectedItem.Value == "05")
                {
                    DataList5.Visible = true;
                    DataList5.DataSource = dv2;
                    DataList5.DataBind();
                    if (DataList5.Rows.Count > 0)
                    {
                        for (int i = 0; i < DataList5.Rows.Count; i++)
                            ((CheckBox)DataList5.Rows[i].Cells[0].FindControl("CheckBox2")).Checked = true;
                    }
                }
                btnList.Enabled = true;
            }
        }

        protected void ddlPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataList1.Visible = false;
            DataList2.Visible = false;
            DataList3.Visible = false;
            DataList4.Visible = false;
            DataList5.Visible = false;
            btnList.Enabled = false;
            btnListPrint.Enabled = false;
            DataGrid1.Visible = false;
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            int j = 0;
            switch (ddlPayType.SelectedItem.Value)
            {
                case "01":
                    for (int i = 0; i < DataList1.Rows.Count; i++)
                    {
                        if (((CheckBox)DataList1.Rows[i].Cells[0].FindControl("CheckBox2")).Checked == true)
                            j++;
                    }
                    break;
                case "02":
                    for (int i = 0; i < DataList2.Rows.Count; i++)
                    {
                        if (((CheckBox)DataList2.Rows[i].Cells[0].FindControl("CheckBox2")).Checked == true)
                            j++;
                    }
                    break;
                case "03":
                    for (int i = 0; i < DataList3.Rows.Count; i++)
                    {
                        if (((CheckBox)DataList3.Rows[i].Cells[0].FindControl("CheckBox2")).Checked == true)
                            j++;
                    }
                    break;
                case "04":
                    for (int i = 0; i < DataList4.Rows.Count; i++)
                    {
                        if (((CheckBox)DataList4.Rows[i].Cells[0].FindControl("CheckBox2")).Checked == true)
                            j++;
                    }
                    break;
                case "05":
                    for (int i = 0; i < DataList5.Rows.Count; i++)
                    {
                        if (((CheckBox)DataList5.Rows[i].Cells[0].FindControl("CheckBox2")).Checked == true)
                            j++;
                    }
                    break;
            }
            if (j > 0)
                CreateList(j);
            else
                JavaScript.AlertMessage(this.Page, "尚未選擇任何繳款單");
        }


        private void CreateList(int toitem)
        {

            string reg = Account.GetAccInfo().srspn_empno.ToString().Trim();
            string maxseq = "";
            string yyyymm = System.DateTime.Today.Year.ToString();
            if (System.DateTime.Today.Month.ToString().Length < 2)
                yyyymm = yyyymm + "0" + System.DateTime.Today.Month.ToString();
            else
                yyyymm = yyyymm + System.DateTime.Today.Month.ToString();
            //取出批次
            DataSet ds4 = myPay.SelectMAXpyseq();
            DataView dv4 = ds4.Tables[0].DefaultView;
            if (dv4.Count == 0)
                maxseq = "0001";
            else
            {
                dv4.RowFilter = "pys_pysdate='" + yyyymm + "'";
                if (dv4.Count == 0)
                    maxseq = "0001";
                else
                {
                    maxseq = dv4[0].Row["maxseq"].ToString().Trim();
                    if (maxseq == "")
                        maxseq = "0001";
                    else
                    {
                        maxseq = Convert.ToString(Int32.Parse(maxseq) + 1);
                        //					lblMessage.Text=maxseq.Length.ToString();
                        int j1 = maxseq.Length;
                        for (int j = 0; j < 4 - j1; j++)
                            maxseq = "0" + maxseq;
                    }
                }
                //				lblMessage.Text=maxseq;
            }


            //新增一筆繳款清單資料 (pyseq)
            myPay.Insertpyseq("", yyyymm, maxseq, toitem.ToString(), ddlPayType.SelectedItem.Value, "0", DateTime.Now.ToString("yyyyMMdd"), reg);
            //			lblMessage.Text="產生年月:"+yyyymm+"<br>批次:"+maxseq+"<br>項次:"+toitem.ToString();
            lblyyyymm.Text = yyyymm;
            lblbatch.Text = maxseq;
            lbltoitem.Text = toitem.ToString();
            //將繳款清單產生年月,批次,項次回寫至繳款單檔(py)
            int item = 1;
            switch (ddlPayType.SelectedItem.Value)
            {
                case "01":
                    for (int i = 0; i < DataList1.Rows.Count; i++)
                    {
                        if (((CheckBox)DataList1.Rows[i].Cells[0].FindControl("CheckBox2")).Checked == true)
                        {
                            myPay.UPDATEpy(yyyymm, maxseq, item.ToString(), DataList1.Rows[i].Cells[1].Text);
                            item++;
                        }
                    }
                    break;
                case "02":
                    for (int i = 0; i < DataList2.Rows.Count; i++)
                    {
                        if (((CheckBox)DataList2.Rows[i].Cells[0].FindControl("CheckBox2")).Checked == true)
                        {
                            myPay.UPDATEpy(yyyymm, maxseq, item.ToString(), DataList2.Rows[i].Cells[1].Text);
                            item++;
                        }
                    }
                    break;
                case "03":
                    for (int i = 0; i < DataList3.Rows.Count; i++)
                    {
                        if (((CheckBox)DataList3.Rows[i].Cells[0].FindControl("CheckBox2")).Checked == true)
                        {
                            myPay.UPDATEpy(yyyymm, maxseq, item.ToString(), DataList3.Rows[i].Cells[1].Text);
                            item++;
                        }
                    }
                    break;
                case "04":
                    for (int i = 0; i < DataList4.Rows.Count; i++)
                    {
                        if (((CheckBox)DataList4.Rows[i].Cells[0].FindControl("CheckBox2")).Checked == true)
                        {
                            myPay.UPDATEpy(yyyymm, maxseq, item.ToString(), DataList4.Rows[i].Cells[1].Text);
                            item++;
                        }
                    }
                    break;
                case "05":
                    for (int i = 0; i < DataList5.Rows.Count; i++)
                    {
                        if (((CheckBox)DataList5.Rows[i].Cells[0].FindControl("CheckBox2")).Checked == true)
                        {
                            myPay.UPDATEpy(yyyymm, maxseq, item.ToString(), DataList5.Rows[i].Cells[1].Text);
                            item++;
                        }
                    }
                    break;

            }
            btnListPrint.Enabled = true;
            btnList.Enabled = false;
            DataList1.Visible = false;
            DataList2.Visible = false;
            DataList3.Visible = false;
            DataList4.Visible = false;
            DataList5.Visible = false;
            DataSet ds2 = myPay.Selectpy();
            DataView dv2 = ds2.Tables[0].DefaultView;
            dv2.RowFilter = "py_pytpcd='" + ddlPayType.SelectedItem.Value
                + "' and py_pysdate='" + lblyyyymm.Text.Trim()
                + "' and py_pysseq='" + lblbatch.Text.Trim() + "'";
            DataGrid1.Visible = true;
            DataGrid1.DataSource = dv2;
            DataGrid1.DataBind();

        }

        protected void btnListPrint_Click(object sender, EventArgs e)
        {
            try
            {
                //string empno = Account.GetAccInfo().srspn_empno.ToString().Trim();
                string cname = Account.GetAccInfo().srspn_cname.ToString().Trim();

                Response.Clear();
                ExcelFile Xls = new XlsFile(true);
                //用SWITCH來控制要去抓哪個EXCEL TEMPLATE
                string whitch = "";
                switch (ddlPayType.SelectedItem.Value)
                {
                    case "01":
                        {
                            whitch = "1";
                            break;
                        }
                    case "02":
                        {
                            whitch = "2";
                            break;
                        }
                    case "03":
                        {
                            whitch = "3";
                            break;
                        }
                    case "04":
                        {
                            whitch = "4";
                            break;
                        }
                    case "05":
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

                if (ddlPayType.SelectedItem.Value == "01")
                {
                    FunCtionpy_list1(Xls, cname);
                }
                else if (ddlPayType.SelectedItem.Value == "02")
                {
                    FunCtionpy_list2(Xls, cname);
                }
                else if (ddlPayType.SelectedItem.Value == "03")
                {
                    FunCtionpy_list3(Xls, cname);
                }
                else if (ddlPayType.SelectedItem.Value == "04")
                {
                    FunCtionpy_list4(Xls, cname);
                }
                else if (ddlPayType.SelectedItem.Value == "05")
                {
                    FunCtionpy_list5(Xls, cname);
                }
            }
            catch (Exception ex)
            {
                JavaScript.AlertMessageRedirect(this.Page, ex.Message, "../Deafult.aspx");
            }
        }


        #region 匯出報表list1~list5

        public void FunCtionpy_list1(ExcelFile Xls,string cname)
        {
            DataSet ds = myPay.SelectExportExcel("01", lblyyyymm.Text, lblbatch.Text);
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
            tfMoney.HAlignment = THFlxAlignment.left;
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
            tfBorderTop.HAlignment = THFlxAlignment.left;
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
                        Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                        Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                        Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                        Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                        Xls.SetCellValue(i + 6, 8, dt.Rows[i]["ia_invno"].ToString());
                        Xls.SetCellValue(i + 6, 11, dt.Rows[i]["ia_syscd"].ToString());
                        Xls.SetCellValue(i + 6, 12, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                        TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString());
                    }

                }
                else
                {
                    Xls.SetCellValue(i + 6, 1, count + 1);
                    count = count + 1;
                    Xls.SetCellValue(i + 6, 2, dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 3, dt.Rows[i]["py_pyno"].ToString());
                    Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                    Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                    Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                    Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                    Xls.SetCellValue(i + 6, 8, dt.Rows[i]["ia_invno"].ToString());
                    Xls.SetCellValue(i + 6, 11, dt.Rows[i]["ia_syscd"].ToString());
                    Xls.SetCellValue(i + 6, 12, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                    TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString());
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

        public void FunCtionpy_list2(ExcelFile Xls, string cname)
        {
            DataSet ds = myPay.SelectExportExcel("02", lblyyyymm.Text, lblbatch.Text);
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
            tfMoney.HAlignment = THFlxAlignment.left;
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
            tfBorderTop.HAlignment = THFlxAlignment.left;
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
                        Xls.SetCellValue(i + 6, 5, "");
                        Xls.SetCellValue(i + 6, 6, "");
                        Xls.SetCellValue(i + 6, 7, "");
                        Xls.SetCellValue(i + 6, 11, "");
                        Xls.SetCellValue(i + 6, 14, "");
                        Xls.SetCellValue(i + 6, 15, "", tfBorderI);
                    }
                    else
                    {
                        //Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                        Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                        Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                        Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                        Xls.SetCellValue(i + 6, 11, dt.Rows[i]["ia_invno"].ToString());
                        Xls.SetCellValue(i + 6, 14, dt.Rows[i]["ia_syscd"].ToString());
                        Xls.SetCellValue(i + 6, 15, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                        TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString());
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
                        Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["py_amt"].ToString()), tfMoneyI);
                    }

                    Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                    Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                    Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                    Xls.SetCellValue(i + 6, 8, dt.Rows[i]["py_chkno"].ToString());
                    Xls.SetCellValue(i + 6, 9, dt.Rows[i]["py_chkbnm"].ToString());
                    Xls.SetCellValue(i + 6, 10, dt.Rows[i]["py_chkdate"].ToString() == "" ? "" : dt.Rows[i]["py_chkdate"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["py_chkdate"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["py_chkdate"].ToString().Substring(6, 2));
                    Xls.SetCellValue(i + 6, 11, dt.Rows[i]["ia_invno"].ToString());
                    Xls.SetCellValue(i + 6, 14, dt.Rows[i]["ia_syscd"].ToString());
                    Xls.SetCellValue(i + 6, 15, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                    TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["py_amt"].ToString());
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

        public void FunCtionpy_list3(ExcelFile Xls, string cname)
        {
            DataSet ds = myPay.SelectExportExcel("03", lblyyyymm.Text, lblbatch.Text);
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
            tfMoney.HAlignment = THFlxAlignment.left;
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
            tfBorderTop.HAlignment = THFlxAlignment.left;
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
                        Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                        Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                        Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                        Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                        Xls.SetCellValue(i + 6, 10, dt.Rows[i]["ia_invno"].ToString());
                        Xls.SetCellValue(i + 6, 13, dt.Rows[i]["ia_syscd"].ToString());
                        Xls.SetCellValue(i + 6, 14, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                        TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString());
                    }

                }
                else
                {
                    Xls.SetCellValue(i + 6, 1, count + 1);
                    count = count + 1;
                    Xls.SetCellValue(i + 6, 2, dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 3, dt.Rows[i]["py_pyno"].ToString());
                    Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                    Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                    Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                    Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                    Xls.SetCellValue(i + 6, 8, dt.Rows[i]["py_moseq"].ToString());
                    Xls.SetCellValue(i + 6, 9, dt.Rows[i]["py_moitem"].ToString());
                    Xls.SetCellValue(i + 6, 10, dt.Rows[i]["ia_invno"].ToString());
                    Xls.SetCellValue(i + 6, 13, dt.Rows[i]["ia_syscd"].ToString());
                    Xls.SetCellValue(i + 6, 14, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                    TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString());
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

        public void FunCtionpy_list4(ExcelFile Xls, string cname)
        {
            DataSet ds = myPay.SelectExportExcel("04", lblyyyymm.Text, lblbatch.Text);
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
            tfMoney.HAlignment = THFlxAlignment.left;
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
            tfBorderTop.HAlignment = THFlxAlignment.left;
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
                        Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                        Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                        Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                        Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                        Xls.SetCellValue(i + 6, 11, dt.Rows[i]["ia_invno"].ToString());
                        Xls.SetCellValue(i + 6, 14, dt.Rows[i]["ia_syscd"].ToString());
                        Xls.SetCellValue(i + 6, 15, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                        TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString());
                    }

                }
                else
                {
                    Xls.SetCellValue(i + 6, 1, count + 1);
                    count = count + 1;
                    Xls.SetCellValue(i + 6, 2, dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 3, dt.Rows[i]["py_pyno"].ToString());
                    Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                    Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                    Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                    Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                    Xls.SetCellValue(i + 6, 8, dt.Rows[i]["py_wbcd"].ToString());
                    Xls.SetCellValue(i + 6, 9, dt.Rows[i]["py_waccno"].ToString());
                    Xls.SetCellValue(i + 6, 10, dt.Rows[i]["py_wdate"].ToString() == "" ? "" : dt.Rows[i]["py_wdate"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["py_wdate"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["py_wdate"].ToString().Substring(6, 2));
                    Xls.SetCellValue(i + 6, 11, dt.Rows[i]["ia_invno"].ToString());
                    Xls.SetCellValue(i + 6, 14, dt.Rows[i]["ia_syscd"].ToString());
                    Xls.SetCellValue(i + 6, 15, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                    TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString());
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

        public void FunCtionpy_list5(ExcelFile Xls, string cname)
        {
            DataSet ds = myPay.SelectExportExcel("05", lblyyyymm.Text, lblbatch.Text);
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
            tfMoney.HAlignment = THFlxAlignment.left;
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
            tfBorderTop.HAlignment = THFlxAlignment.left;
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
                        Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                        Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                        Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                        Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                        Xls.SetCellValue(i + 6, 11, dt.Rows[i]["ia_invno"].ToString());
                        Xls.SetCellValue(i + 6, 14, dt.Rows[i]["ia_syscd"].ToString());
                        Xls.SetCellValue(i + 6, 15, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                        TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString());
                    }

                }
                else
                {
                    Xls.SetCellValue(i + 6, 1, count + 1);
                    count = count + 1;
                    Xls.SetCellValue(i + 6, 2, dt.Rows[i]["iad_syscd"].ToString() + dt.Rows[i]["iad_fk1"].ToString().Trim() + dt.Rows[i]["iad_fk2"].ToString().Trim() + dt.Rows[i]["iad_fk3"].ToString().Trim());
                    Xls.SetCellValue(i + 6, 3, dt.Rows[i]["py_pyno"].ToString());
                    Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString()), tfMoneyI);
                    Xls.SetCellValue(i + 6, 5, dt.Rows[i]["ia_rnm"].ToString());
                    Xls.SetCellValue(i + 6, 6, dt.Rows[i]["mfr_inm"].ToString());
                    Xls.SetCellValue(i + 6, 7, dt.Rows[i]["ia_mfrno"].ToString());
                    Xls.SetCellValue(i + 6, 8, dt.Rows[i]["py_ccno"].ToString());
                    Xls.SetCellValue(i + 6, 9, dt.Rows[i]["py_ccauthcd"].ToString());
                    Xls.SetCellValue(i + 6, 10, dt.Rows[i]["py_ccvdate"].ToString());
                    Xls.SetCellValue(i + 6, 11, dt.Rows[i]["ia_invno"].ToString());
                    Xls.SetCellValue(i + 6, 14, dt.Rows[i]["ia_syscd"].ToString());
                    Xls.SetCellValue(i + 6, 15, dt.Rows[i]["ia_iano"].ToString(), tfBorderI);
                    TotalCount = TotalCount + Convert.ToInt32(dt.Rows[i]["ia_pyat"].ToString());
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