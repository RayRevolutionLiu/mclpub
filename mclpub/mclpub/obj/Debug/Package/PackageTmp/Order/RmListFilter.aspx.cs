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


namespace mclpub.Sys
{
    public partial class RmListFilter : System.Web.UI.Page
    {
        RmListFilter_DB myRm = new RmListFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = myRm.Selectc1_remailEdit(ddlSent.SelectedValue.ToString(), tbxRemailDate1.Text.Trim(), tbxRemailDate2.Text.Trim(), tbxOrderDate1.Text.Trim(), tbxOrderDate2.Text.Trim());

            if (dt.Rows.Count == 0)
            {
                JavaScript.AlertMessage(this.Page, "查無資料");
                return;
            }

            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Sys/Template/remail_list.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            TXlsCellRange myRange = new TXlsCellRange("A6:I6");

            if (tbxRemailDate1.Text.Trim() != "" && tbxRemailDate2.Text.Trim() != "")
            {
                Xls.SetCellValue(3, 3, tbxRemailDate1.Text.Trim() + "~" + tbxRemailDate2.Text.Trim());
            }

            if (tbxOrderDate1.Text.Trim() != "" && tbxOrderDate2.Text.Trim() != "")
            {
                Xls.SetCellValue(2, 3, tbxOrderDate1.Text.Trim() + "~" + tbxOrderDate2.Text.Trim());
            }

            Xls.SetCellValue(2, 8, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(3, 8, DateTime.Now.ToString("yyyy/MM/dd"));

            if (dt.Rows.Count > 1)
            {
                for (int i = 7; i < dt.Rows.Count + 7; i++)//大於一筆 才去複製格式
                {
                    Xls.InsertAndCopyRange(myRange, i, 1, 1, TFlxInsertMode.NoneDown);
                }
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Xls.SetCellValue(i + 6, 1, i + 1);
                Xls.SetCellValue(i + 6, 2, dt.Rows[i]["nostr"].ToString());
                Xls.SetCellValue(i + 6, 3, dt.Rows[i]["rm_sdate"].ToString() + "~" + dt.Rows[i]["rm_edate"].ToString());
                Xls.SetCellValue(i + 6, 4, dt.Rows[i]["or_nm"].ToString());
                Xls.SetCellValue(i + 6, 5, dt.Rows[i]["or_addr"].ToString());
                Xls.SetCellValue(i + 6, 6, dt.Rows[i]["rm_date"].ToString().Trim() == "" ? "" : dt.Rows[i]["rm_date"].ToString().Trim().Substring(0, 4) + "/" + dt.Rows[i]["rm_date"].ToString().Trim().Substring(4, 2) + "/" + dt.Rows[i]["rm_date"].ToString().Trim().Substring(6, 2));
                Xls.SetCellValue(i + 6, 7, dt.Rows[i]["rm_cont"].ToString());
                if (dt.Rows[i]["rm_fgsent"].ToString().Trim() == "Y")
                {
                    Xls.SetCellValue(i + 6, 8, "可寄出");
                }
                else if (dt.Rows[i]["rm_fgsent"].ToString().Trim() == "N")
                {
                    Xls.SetCellValue(i + 6, 8, "目前暫時無法寄出");
                }
                else if (dt.Rows[i]["rm_fgsent"].ToString().Trim() == "C")
                {
                    Xls.SetCellValue(i + 6, 8, "已寄出");
                }
                else if (dt.Rows[i]["rm_fgsent"].ToString().Trim() == "D")
                {
                    Xls.SetCellValue(i + 6, 8, "不處理");
                }

                Xls.SetCellValue(i + 6, 9, dt.Rows[i]["o_date"].ToString().Trim() == "" ? "" : dt.Rows[i]["o_date"].ToString().Trim().Substring(0, 4) + "/" + dt.Rows[i]["o_date"].ToString().Trim().Substring(4, 2) + "/" + dt.Rows[i]["o_date"].ToString().Trim().Substring(6, 2));
            }


            Common.excuteExcel(Xls, "remail_list.xls");

        }

        protected void ddlSent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSent.SelectedItem.Value == "C")
            {
                tbxRemailDate1.Enabled = true;
                tbxRemailDate2.Enabled = true;
            }
            else
            {
                tbxRemailDate1.Enabled = false;
                tbxRemailDate2.Enabled = false;
            }
        }
    }
}