using System;
using System.Data;

namespace mclpub.Layout
{
    public partial class RptAdrQuery : System.Web.UI.Page
    {
        RptAdrBillQuery_DB myRpt = new RptAdrBillQuery_DB();

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
            dr["srspn_empno"] = "000000";
            dr["srspn_cname"] = "請選擇";
            ds.Tables[0].Rows.Add(dr);
            ds.Tables[0].DefaultView.Sort = "srspn_empno ASC";

            DataView dv = ds.Tables[0].DefaultView;

            this.ddlEmpData.DataTextField = "srspn_cname";
            this.ddlEmpData.DataValueField = "srspn_empno";
            this.ddlEmpData.DataSource = dv;
            this.ddlEmpData.DataBind();

            ddlEmpData.SelectedIndex = -1;
            if (ddlEmpData.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()) != null)
                ddlEmpData.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()).Selected = true;
            else
                ddlEmpData.SelectedIndex = 0;
        }
        #endregion

        protected void btnPrintBill_Click(object sender, EventArgs e)
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
                    JavaScript.AlertMessage(this.Page, "區段結束日期格式錯誤，請重新輸入");
                    return;
                }

            }
            string ddlStr = "";
            if (ddlEmpData.SelectedValue.ToString() != "000000")
            {
                ddlStr = ddlEmpData.SelectedValue.ToString().Trim();
            }
            DataSet ds = myRpt.RptAdrList(sdate.ToString("yyyyMMdd"), edate.ToString("yyyyMMdd"), tbxMfrName.Text.Trim(), ddlStr);

            DataView dv = ds.Tables[0].DefaultView;

            Response.Write(dv.Count);
        }
    }
}