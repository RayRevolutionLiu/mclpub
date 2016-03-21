using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using FlexCel.Core;
using FlexCel.XlsAdapter;
using FlexCel.Render;

namespace mclpub.Layout
{
    public partial class RptFileUpQuery : System.Web.UI.Page
    {
        RptFileUpQuery_DB myRpt = new RptFileUpQuery_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind_ddlEmpData();
            }
        }

        #region 連結員工資料
        private void Bind_ddlEmpData()
        {

            DataSet ds5 = myRpt.GetSrspns();
            DataRow dr = ds5.Tables[0].NewRow();
            dr["srspn_empno"] = "000000";
            dr["srspn_cname"] = "請選擇";
            ds5.Tables[0].Rows.Add(dr);
            ds5.Tables[0].DefaultView.Sort = "srspn_empno ASC";
            ddlEmpData.DataSource = ds5.Tables[0].DefaultView;
            ddlEmpData.DataTextField = "srspn_cname";
            ddlEmpData.DataValueField = "srspn_empno";
            ddlEmpData.DataBind();

            if (ddlEmpData.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()) != null)
                ddlEmpData.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()).Selected = true;
            else
                ddlEmpData.SelectedIndex = 0;
        }
        #endregion

        protected void btnPrint_Click(object sender, EventArgs e)
        {

            DateTime sdate;
            DateTime edate;
            if (tbxSDate.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "區段起始日期不可空白，請輸入");
                return;
            }
            else
            {
                try
                {
                    sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
                }
                catch
                {
                    JavaScript.AlertMessage(this.Page, "區段起始日期格式錯誤，請重新輸入");
                    return;
                }
            }
            if (tbxEDate.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "區段結束日期不可空白，請輸入");
                return;
            }
            else
            {
                try
                {
                    edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
                }
                catch
                {
                    JavaScript.AlertMessage(this.Page, "區段結束日期格式錯誤，請輸入");
                    return;
                }

            }

            string STRtbxSDate = "";
            string STRtbxEDate = "";
            string STRddlEmpData = "";
            string STRddlKeyword = "";

            if (tbxSDate.Text.Trim() != "")
            {
                STRtbxSDate = tbxSDate.Text;
            }
            if (tbxEDate.Text.Trim() != "")
            {
                STRtbxEDate = tbxEDate.Text;
            }
            if (ddlEmpData.SelectedValue.ToString() != "000000")
            {
                STRddlEmpData = ddlEmpData.SelectedValue.ToString();
            }
            if (ddlKeyword.SelectedValue.ToString() != "00")
            {
                STRddlKeyword = ddlKeyword.SelectedValue.ToString();
            }

            DataSet ds = myRpt.SelectExcelList(STRtbxSDate, STRtbxEDate, STRddlEmpData, STRddlKeyword);

            DataView dv = ds.Tables[0].DefaultView;

            if (dv.Count > 0)
            {
                Response.Clear();
                ExcelFile Xls = new XlsFile(true);
                string fileSpec = Server.MapPath("~/Layout/Template/" + "RptFileUpList.xls");
                Xls.Open(fileSpec);
                Xls.ActiveSheet = 1;
                TXlsCellRange myRange = new TXlsCellRange("A6:E6");
                if (ddlEmpData.SelectedValue.ToString() != "000000")
                {
                    Xls.SetCellValue(3, 2, ddlEmpData.SelectedItem.Text.ToString().Trim());
                }
                else
                {
                    Xls.SetCellValue(3, 2, "[全部]");
                }

                Xls.SetCellValue(3, 6, Account.GetAccInfo().srspn_cname.ToString().Trim());
                Xls.SetCellValue(4, 2, STRtbxSDate + "~" + STRtbxEDate);
                Xls.SetCellValue(4, 6, DateTime.Now.ToString("yyyy/MM/dd"));

                for (int i = 0; i < dv.Count; i++)
                {
                    //把格式複製過去
                    if (i != 0 && dv.Count > 1)
                    {
                        Xls.InsertAndCopyRange(myRange, i + 6, 1, 1, TFlxInsertMode.NoneDown);
                    }


                    Xls.SetCellValue(i + 6, 1, dv[i]["adr_addate"].ToString().Trim() == "" ? "" : dv[i]["adr_addate"].ToString().Trim().Substring(0, 4) + "/" + dv[i]["adr_addate"].ToString().Trim().Substring(4, 2) + "/" + dv[i]["adr_addate"].ToString().Trim().Substring(6, 2));
                    switch (dv[i]["adr_adcate"].ToString().Trim())
                    {
                        case "M":
                            {
                                Xls.SetCellValue(i + 6, 2, "首頁");
                                break;
                            }
                        case "I":
                            {
                                Xls.SetCellValue(i + 6, 2, "內頁");
                                break;
                            }
                        case "N":
                            {
                                Xls.SetCellValue(i + 6, 2, "奈米");
                                break;
                            }
                        default:
                            {
                                Xls.SetCellValue(i + 6, 2, "(錯誤)");
                                break;
                            }
                    }

                    switch (dv[i]["adr_keyword"].ToString().Trim())
                    {
                        case "h0":
                            {
                                Xls.SetCellValue(i + 6, 3, "正中");
                                break;
                            }
                        case "h1":
                            {
                                Xls.SetCellValue(i + 6, 3, "右一");
                                break;
                            }
                        case "h2":
                            {
                                Xls.SetCellValue(i + 6, 3, "右二");
                                break;
                            }
                        case "h3":
                            {
                                Xls.SetCellValue(i + 6, 3, "右三");
                                break;
                            }
                        case "h4":
                            {
                                Xls.SetCellValue(i + 6, 3, "右四");
                                break;
                            }
                        case "w1":
                            {
                                Xls.SetCellValue(i + 6, 3, "右文一");
                                break;
                            }
                        case "w2":
                            {
                                Xls.SetCellValue(i + 6, 3, "右文二");
                                break;
                            }
                        case "w3":
                            {
                                Xls.SetCellValue(i + 6, 3, "右文三");
                                break;
                            }
                        case "w4":
                            {
                                Xls.SetCellValue(i + 6, 3, "右文四");
                                break;
                            }
                        case "w5":
                            {
                                Xls.SetCellValue(i + 6, 3, "右文五");
                                break;
                            }
                        case "w6":
                            {
                                Xls.SetCellValue(i + 6, 3, "右文六");
                                break;
                            }
                        default:
                            {
                                Xls.SetCellValue(i + 6, 3, "");
                                break;
                            }
                    }
                    Xls.SetCellValue(i + 6, 4, Convert.ToInt32(dv[i]["adr_count"].ToString()));
                    Xls.SetCellValue(i + 6, 5, Convert.ToInt32(dv[i]["sum_impr"].ToString()));
                }

                    Common.excuteExcel(Xls, "RptFileUpList.xls");
            }
            else
            {
                JavaScript.AlertMessage(this.Page, "查詢無資料,請重新輸入條件");
                return;
            }
        }
    }
}