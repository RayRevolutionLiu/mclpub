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

namespace mclpub.LabelArea
{
    public partial class appriseFilter : System.Web.UI.Page
    {
        appriseFilter_DB myapp = new appriseFilter_DB();
        public string ddlSTR = "0";//dropdownlist顯示的郵寄地區
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                GVSearchCust.Visible = false;
                lblMessage.Visible = false;

                int myYear = System.DateTime.Today.Year;
                int j = 0;
                for (int i = myYear - 3; i <= myYear + 1; i++)
                {
                    ddlYear1.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    ddlYear2.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    j++;
                }
                ddlYear1.SelectedIndex = j - 2;
                ddlYear2.SelectedIndex = j - 2;
                int myMonth = System.DateTime.Today.Month;
                ddlMonth1.SelectedIndex = myMonth - 1;
                ddlMonth2.SelectedIndex = myMonth - 1;
                btnPrintLabel.Enabled = false;
                btnPrintList.Enabled = false;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            myapp.Excute("C1", "01", ddlBookType.SelectedItem.Value, ddlYear1.SelectedItem.Value.Trim() + ddlMonth1.SelectedItem.Value.Trim(), ddlYear2.SelectedItem.Value.Trim() + ddlMonth2.SelectedItem.Value.Trim());

            DataSet ds1 = myapp.SelectTmp1_table();
            DataView dv1 = ds1.Tables["tmp_label1"].DefaultView;
            dv1.RowFilter = "or_fgmosea='" + ddlMosea.SelectedItem.Value + "'";
            if (dv1.Count == 0)
            {
                lblMessage.Visible = false;
                btnPrintLabel.Enabled = false;
                btnPrintList.Enabled = false;
            }
            else
            {
                btnPrintLabel.Enabled = true;
                btnPrintList.Enabled = true;
                lblMessage.Visible = true;
                lblMessage.Text = "查詢到" + dv1.Count.ToString() + "筆資料";
            }

            SearchIcon.Visible = true;
            GVSearchCust.Visible = true;
            GVSearchCust.DataSource = dv1;
            GVSearchCust.DataBind();

            ddlSTR = ddlMosea.SelectedItem.Value;
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int myMonth = System.DateTime.Today.Month;
            int myYear = System.DateTime.Today.Year;
            int j = 0;
            for (int i = myYear - 3; i <= myYear + 1; i++)
            {
                ddlYear1.Items.Add(new ListItem(i.ToString(), i.ToString()));
                ddlYear2.Items.Add(new ListItem(i.ToString(), i.ToString()));
                j++;
            }
            ddlYear1.SelectedIndex = j - 2;
            ddlYear2.SelectedIndex = j - 2;
            if (ddlType.SelectedItem.Value == "0")		//到期
            {
                ddlMonth1.SelectedIndex = myMonth - 1;
                ddlMonth2.SelectedIndex = myMonth - 1;
            }
            else if (ddlType.SelectedItem.Value == "1")	//即將到期
            {
                if (myMonth == 12)
                {
                    ddlYear1.SelectedIndex = ddlYear1.SelectedIndex + 1;
                    ddlYear2.SelectedIndex = ddlYear2.SelectedIndex + 1;
                    ddlMonth1.SelectedIndex = 0;
                    ddlMonth2.SelectedIndex = 0;
                }
                else
                {
                    ddlMonth1.SelectedIndex = myMonth;
                    ddlMonth2.SelectedIndex = myMonth;
                }
            }
        }

        protected void ReturnDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }

        protected void btnPrintLabel_Click(object sender, EventArgs e)
        {
            string strbuf = "appriselabel.aspx?type=" + ddlType.SelectedItem.Value + "&mosea=" + ddlMosea.SelectedItem.Value;
            this.ClientScript.RegisterStartupScript(typeof(string), "", "<script>window.open(\"" + strbuf + "\");</script>"); 
        }

        protected void btnPrintList_Click(object sender, EventArgs e)
        {
            string empnoST = Account.GetAccInfo().srspn_empno;
            DataSet ds5 = myapp.SelectSrspn();
            DataView dv5 = ds5.Tables[0].DefaultView;
            dv5.RowFilter = "srspn_empno = '" + empnoST + "'";
            if (dv5.Count >= 0)
            {
                DataSet ds = myapp.SelectExportExcel(ddlMosea.SelectedItem.Value);
                DataTable dt = ds.Tables[0];

                Response.Clear();
                ExcelFile Xls = new XlsFile(true);
                string fileSpec = Server.MapPath("~/LabelArea/Template/mail_list2.xls");
                Xls.Open(fileSpec);
                Xls.ActiveSheet = 1;

                TXlsCellRange myRange = new TXlsCellRange("A5:K5");
                TXlsCellRange myRange2 = new TXlsCellRange("A1:K1");

                if (dt.Rows.Count > 1)
                {
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    Xls.InsertAndCopyRange(myRange, 5 + i, 1, 1, TFlxInsertMode.NoneDown);
                    //}
                    Xls.InsertAndCopyRange(myRange, 6, 1, dt.Rows.Count - 1, TFlxInsertMode.NoneDown);
                }
                else
                {
                    //do nothing
                }
                Xls.InsertAndCopyRange(myRange2, dt.Rows.Count + 4 + 1, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);
                if (ddlSTR == "0")
                {
                    Xls.SetCellValue(2, 3, "國內");
                }
                else
                {
                    Xls.SetCellValue(2, 3, "國外");
                }

                Xls.SetCellValue(2, 8, DateTime.Now.ToString("yyyy/MM/dd"));
                Xls.SetCellValue(3, 8, Account.GetAccInfo().srspn_cname.ToString().Trim());



                int count = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Xls.SetCellValue(i + 5, 1, i + 1);
                    Xls.SetCellValue(i + 5, 2, dt.Rows[i]["or_nm"].ToString());
                    Xls.SetCellValue(i + 5, 3, dt.Rows[i]["or_zip"].ToString());
                    Xls.SetCellValue(i + 5, 4, dt.Rows[i]["or_addr"].ToString());
                    Xls.SetCellValue(i + 5, 5, dt.Rows[i]["od_syscd"].ToString() + dt.Rows[i]["od_custno"].ToString().Trim() + dt.Rows[i]["od_otp1seq"].ToString().Trim());
                    Xls.SetCellValue(i + 5, 6, dt.Rows[i]["o_date"].ToString() == "" ? "" : dt.Rows[i]["o_date"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["o_date"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["o_date"].ToString().Substring(6, 2));
                    Xls.SetCellValue(i + 5, 7, dt.Rows[i]["od_custno"].ToString());
                    Xls.SetCellValue(i + 5, 8, dt.Rows[i]["cust_nm"].ToString());
                    Xls.SetCellValue(i + 5, 9, dt.Rows[i]["mfr_inm"].ToString());
                    Xls.SetCellValue(i + 5, 10, dt.Rows[i]["od_sdate"].ToString() + "~" + dt.Rows[i]["od_edate"].ToString());
                    Xls.SetCellValue(i + 5, 11, dt.Rows[i]["ra_mnt"].ToString());
                    count = count + Convert.ToInt32(dt.Rows[i]["ra_mnt"].ToString());
                }

                Xls.SetCellValue(dt.Rows.Count + 4 + 1, 11, count);

                Xls.ActiveSheet = 2;
                Xls.DeleteRange(myRange2, TFlxInsertMode.NoneDown);//只有一筆的話刪除第一區塊的藍色
                Xls.ActiveSheet = 1;

                Common.excuteExcel(Xls, "mail_list2.xls");

            }
            else
            {
                JavaScript.AlertMessage(this.Page, "權限不足");
                return;
            }
        }
    }
}