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
    public partial class RptIncomeQuery : System.Web.UI.Page
    {
        RptIncomeQuery_DB myRpt = new RptIncomeQuery_DB();

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
            DataSet ds = myRpt.GetSrspns();
            DataRow dr = ds.Tables[0].NewRow();
            dr["srspn_cname"] = "請選擇";
            dr["srspn_empno"] = "000000";
            ds.Tables[0].Rows.Add(dr);
            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = "srspn_empno ASC";
            this.ddlEmpData.DataTextField = "srspn_cname";
            this.ddlEmpData.DataValueField = "srspn_empno";
            this.ddlEmpData.DataSource = dv;
            this.ddlEmpData.DataBind();
        }
        #endregion

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            DateTime dt1 = new DateTime();
            DateTime dt2 = new DateTime();
            try
            {
                if (tbxSDate.Text.Trim() == "" || tbxEDate.Text.Trim() == "")
                {
                    JavaScript.AlertMessage(this.Page, "請輸入日期");
                    return;
                }
                dt1 = Convert.ToDateTime(tbxSDate.Text.Trim());
                dt2 = Convert.ToDateTime(tbxEDate.Text.Trim());
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "時間格式錯誤");
                return;
            }
            string empno = ddlEmpData.SelectedItem.Value.ToString() == "000000" ? "" : ddlEmpData.SelectedItem.Value.ToString();
            DataSet ds = myRpt.SelectAll(dt1.ToString("yyyyMMdd"), dt2.ToString("yyyyMMdd"), empno);
            DataTable dt = ds.Tables[0];


            if (dt.Rows.Count == 0)
            {
                JavaScript.AlertMessage(this.Page, "查詢無資料");
                return;
            }


            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Statistics/Template/RptIncome.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            TXlsCellRange myRange = new TXlsCellRange("A5:I5");
            Xls.SetCellValue(2, 3, ddlEmpData.SelectedItem.Value.ToString() == "000000" ? "" : ddlEmpData.SelectedItem.Text.ToString());
            Xls.SetCellValue(2, 7, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(3, 7, DateTime.Now.ToString("yyyy/MM/dd"));
            Xls.SetCellValue(3, 3, tbxSDate.Text.Trim() + "~" + tbxEDate.Text.Trim());


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Xls.InsertAndCopyRange(myRange, i + 5, 1, 1, TFlxInsertMode.ShiftRowDown, TRangeCopyMode.All, Xls, 1);//ShiftRowDown可以把destRow給往下推
            }
            string dateStrS = "";
            string dateStrE = "";
            string dateStrAll = "";
            int sum_adamt = 0;
            int sum_chgamt = 0;
            int sum_desamt = 0;
            int adr_count = 0;
            int sum_invamt = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Xls.SetCellValue(i + 5, 1, i + 1);
                Xls.SetCellValue(i + 5, 2, dt.Rows[i]["adr_contno"].ToString());
                dateStrS = dt.Rows[i]["sdate"].ToString() == "" ? "" : dt.Rows[i]["sdate"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["sdate"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["sdate"].ToString().Substring(6, 2);
                dateStrE = dt.Rows[i]["edate"].ToString() == "" ? "" : dt.Rows[i]["edate"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["edate"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["edate"].ToString().Substring(6, 2);
                dateStrAll = dateStrS + "~" + dateStrE;
                Xls.SetCellValue(i + 5, 3, dateStrAll);
                Xls.SetCellValue(i + 5, 4, dt.Rows[i]["mfr_inm"].ToString());
                Xls.SetCellValue(i + 5, 5, Convert.ToInt32(dt.Rows[i]["sum_adamt"].ToString()));
                Xls.SetCellValue(i + 5, 6, Convert.ToInt32(dt.Rows[i]["sum_chgamt"].ToString()));
                Xls.SetCellValue(i + 5, 7, Convert.ToInt32(dt.Rows[i]["sum_desamt"].ToString()));
                Xls.SetCellValue(i + 5, 8, Convert.ToInt32(dt.Rows[i]["adr_count"].ToString()));
                Xls.SetCellValue(i + 5, 9, Convert.ToInt32(dt.Rows[i]["sum_invamt"].ToString()));
                sum_adamt += Convert.ToInt32(dt.Rows[i]["sum_adamt"].ToString());
                sum_chgamt += Convert.ToInt32(dt.Rows[i]["sum_chgamt"].ToString());
                sum_desamt += Convert.ToInt32(dt.Rows[i]["sum_desamt"].ToString());
                adr_count += Convert.ToInt32(dt.Rows[i]["adr_count"].ToString());
                sum_invamt += Convert.ToInt32(dt.Rows[i]["sum_invamt"].ToString());
            }

            Xls.SetCellValue(dt.Rows.Count + 7, 5, sum_adamt);
            Xls.SetCellValue(dt.Rows.Count + 7, 6, sum_chgamt);
            Xls.SetCellValue(dt.Rows.Count + 7, 7, sum_desamt);
            Xls.SetCellValue(dt.Rows.Count + 7, 8, adr_count);
            Xls.SetCellValue(dt.Rows.Count + 7, 9, sum_invamt);

            Common.excuteExcel(Xls, "RptIncome.xls");
        }
    }
}