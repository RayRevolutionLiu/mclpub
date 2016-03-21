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
    public partial class IncomeFilter : System.Web.UI.Page
    {
        IncomeFilter_DB myIncome = new IncomeFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                btnPrintList.Enabled = false;
                //書籍類別
                DataSet ds2 = myIncome.Selectc1_obtp();
                DataView dv2 = ds2.Tables[0].DefaultView;
                dv2.RowFilter = "obtp_otp1cd='" + ddlOrderType1.SelectedItem.Value + "'";

                //為了要讓請選擇放在最上面
                DataTable dt = dv2.ToTable();
                DataRow dr = dt.NewRow();
                dr["obtp_obtpid"] = 0;
                dr["obtp_otp1cd"] = "";
                dr["obtp_obtpcd"] = "00";
                dr["obtp_obtpnm"] = "請選擇";
                dt.Rows.Add(dr);

                DataView dv = dt.DefaultView;
                dv.Sort = "obtp_obtpcd ASC";

                ddlBookType.DataSource = dv;
                ddlBookType.DataTextField = "obtp_obtpnm";
                ddlBookType.DataValueField = "obtp_obtpcd";
                ddlBookType.DataBind();
                tbxOrderDate1.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
                tbxOrderDate2.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
            }
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    DateTime dt1 = Convert.ToDateTime(tbxOrderDate1.Text);
                    DateTime dt2 = Convert.ToDateTime(tbxOrderDate2.Text);
                }
                catch
                {
                    JavaScript.AlertMessage(this.Page, "日期格式錯誤");
                    return;
                }

                if (tbxProj.Text.Trim() != "")
                {
                    if (tbxProj.Text.Trim().Length < 10)
                    {
                        JavaScript.AlertMessage(this.Page, "計劃代號為10碼");
                        return;
                    }
                }

                string date1 = tbxOrderDate1.Text.Trim();
                string date2 = tbxOrderDate2.Text.Trim();
                string projno = tbxProj.Text.Trim();
                string otp1cd = ddlOrderType1.SelectedItem.Value.Trim();

                myIncome.sp_c1_tmp_income1(date1.Substring(0, 4) + date1.Substring(5, 2) + date1.Substring(8, 2), date2.Substring(0, 4) + date2.Substring(5, 2) + date2.Substring(8, 2)
                    , projno, ddlOrderType1.SelectedItem.Value.Trim());

                SearchIcon.Visible = true;
                DataSet ds = myIncome.Selecttmp_statistics();
                GridView1.DataSource = ds;
                GridView1.DataBind();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    btnPrintList.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void btnPrintList_Click(object sender, EventArgs e)
        {
            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Statistics/Template/income1.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            DataSet ds = myIncome.Selecttmp_statisticsEXCEL();
            DataTable dt = ds.Tables[0];
            string date1 = tbxOrderDate1.Text.Trim();
            string date2 = tbxOrderDate2.Text.Trim();
            string preotp1cd = "";
            string preotp2cd = "";
            int tmp_param2 = 0;
            int tmp_param1 = 0;
            Xls.SetCellValue(2, 2, date1 + "~" + date2);
            Xls.SetCellValue(3, 2, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(3, 5, DateTime.Now.ToString("yyyy/MM/dd"));

            TXlsCellRange myRange = new TXlsCellRange("A5:F5");
            TXlsCellRange myRangeTotal = new TXlsCellRange("A1:F2");


            Common.FillEmptyRow(dt.Rows.Count, 5, myRange, Xls);//填格式

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["tmp_otp1cd"].ToString() == preotp1cd)
                {
                    Xls.SetCellValue(5 + i, 1, "");
                    if (dt.Rows[i]["tmp_otp2cd"].ToString() == preotp2cd)
                    {
                        Xls.SetCellValue(5 + i, 2, "");
                    }
                    else
                    {
                        Xls.SetCellValue(5 + i, 2, dt.Rows[i]["otp_otp2nm"].ToString().Trim());
                    }
                }
                else
                {
                    Xls.SetCellValue(5 + i, 1, dt.Rows[i]["otp_otp1nm"].ToString());
                    Xls.SetCellValue(5 + i, 2, dt.Rows[i]["otp_otp2nm"].ToString());
                }

                Xls.SetCellValue(5 + i, 3, dt.Rows[i]["proj_projno"].ToString());
                Xls.SetCellValue(5 + i, 4, dt.Rows[i]["obtp_obtpnm"].ToString());

                if (ddlBookType.SelectedValue.ToString() == "00")
                {
                    Xls.SetCellValue(5 + i, 5, Convert.ToInt32(dt.Rows[i]["tmp_param2"].ToString()));
                    Xls.SetCellValue(5 + i, 6, Convert.ToInt32(dt.Rows[i]["tmp_param1"].ToString()));
                }
                else
                {
                    if (dt.Rows[i]["tmp_btpcd"].ToString() == ddlBookType.SelectedValue.ToString())
                    {
                        Xls.SetCellValue(5 + i, 5, Convert.ToInt32(dt.Rows[i]["tmp_param2"].ToString()));
                        Xls.SetCellValue(5 + i, 6, Convert.ToInt32(dt.Rows[i]["tmp_param1"].ToString()));
                    }
                    else
                    {
                        Xls.SetCellValue(5 + i, 5, 0);
                        Xls.SetCellValue(5 + i, 6, 0);
                    }
                }

                preotp1cd = dt.Rows[i]["tmp_otp1cd"].ToString();
                preotp2cd = dt.Rows[i]["tmp_otp2cd"].ToString();
                tmp_param2 += Convert.ToInt32(dt.Rows[i]["tmp_param2"].ToString());
                tmp_param1 += Convert.ToInt32(dt.Rows[i]["tmp_param1"].ToString());
            }

            Xls.InsertAndCopyRange(myRangeTotal, dt.Rows.Count + 4 + 1, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
            Xls.SetCellValue(dt.Rows.Count + 4 + 1, 5, tmp_param2);
            Xls.SetCellValue(dt.Rows.Count + 4 + 2, 6 ,tmp_param1);
            Xls.ActiveSheet = 2;
            Xls.DeleteRange(myRangeTotal, TFlxInsertMode.NoneDown);
            Xls.ActiveSheet = 1;

            Common.excuteExcel(Xls, "income1.xls");
        }

        protected void ddlOrderType1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //書籍類別
            DataSet ds2 = myIncome.Selectc1_obtp();
            DataView dv2 = ds2.Tables[0].DefaultView;
            dv2.RowFilter = "obtp_otp1cd='" + ddlOrderType1.SelectedItem.Value + "'";

            //為了要讓請選擇放在最上面
            DataTable dt = dv2.ToTable();
            DataRow dr = dt.NewRow();
            dr["obtp_obtpid"] = 0;
            dr["obtp_otp1cd"] = "";
            dr["obtp_obtpcd"] = "00";
            dr["obtp_obtpnm"] = "請選擇";
            dt.Rows.Add(dr);

            DataView dv = dt.DefaultView;
            dv.Sort = "obtp_obtpcd ASC";

            ddlBookType.DataSource = dv;
            ddlBookType.DataTextField = "obtp_obtpnm";
            ddlBookType.DataValueField = "obtp_obtpcd";
            ddlBookType.DataBind();

            if (ddlBookType.SelectedItem.Value != "00")
            {
                tbxProj.Enabled = false;
            }
            else
            {
                tbxProj.Enabled = true;
            }
        }

        protected void ddlBookType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBookType.SelectedItem.Value != "00")
            {
                tbxProj.Enabled = false;
            }
            else
            {
                tbxProj.Enabled = true;
            }
        }

        protected void tbxProj_TextChanged(object sender, EventArgs e)
        {
            if (tbxProj.Text.Trim() != "")
            {
                ddlBookType.Enabled = false;
                ddlBookType.SelectedIndex = 0;

            }
            else
            {
                ddlBookType.Enabled = true;
                ddlBookType.SelectedIndex = 0;
            }
        }
    }
}