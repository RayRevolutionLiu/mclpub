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
    public partial class CustMntFilter : System.Web.UI.Page
    {
        CustMntFilter_DB myCust = new CustMntFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                int myYear = System.DateTime.Today.Year;
                int j = 0;
                for (int i = myYear - 1; i <= myYear + 1; i++)
                {
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    j++;
                }
                ddlYear.SelectedIndex = j - 2;
                int myMonth = System.DateTime.Today.Month;
                ddlMonth.SelectedIndex = myMonth - 1;
            }
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;

            myCust.sp_c1_tmp_statistics(ddlBookType.SelectedItem.Value.Trim(), ddlYear.SelectedItem.Value.Trim() + ddlMonth.SelectedItem.Value.Trim());

            DataSet ds = myCust.Selecttmp_statistics();
            GridView1.DataSource = ds;
            GridView1.DataBind();

            if (ds.Tables[0].Rows.Count > 0)
            {
                btnPrintList.Enabled = true;
            }
            else
            {
                btnPrintList.Enabled = false;
            }
        }

        protected void btnPrintList_Click(object sender, EventArgs e)
        {
            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            TXlsCellRange myRange1 = new TXlsCellRange("A6:F6");
            string fileSpec = Server.MapPath("~/Statistics/Template/cust_mnt.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            Xls.SetCellValue(1, 1, ddlBookType.SelectedItem.Text.ToString().Trim() + "客戶份數表");
            Xls.SetCellValue(2, 2, ddlYear.SelectedItem.Value.Trim() + ddlMonth.SelectedItem.Value.Trim());
            Xls.SetCellValue(3, 2, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(3, 5, DateTime.Now.ToString("yyyy/MM/dd"));

            DataSet ds1 = myCust.Selecttmp_statisticsForExcel("01");
            #region 第一區塊
            for (int i1 = 0; i1 < ds1.Tables[0].Rows.Count - 1; i1++)
            {
                if (ds1.Tables[0].Rows.Count > 1)
                {
                    Xls.InsertAndCopyRange(myRange1, i1 + 7, 1, 1, TFlxInsertMode.ShiftRowDown, TRangeCopyMode.All, Xls, 1);//ShiftRowDown可以把destRow給往下推
                }
            }
            #endregion

            DataSet ds2 = myCust.Selecttmp_statisticsForExcel("02");
            #region 第二區塊
            for (int i2 = 0; i2 < ds2.Tables[0].Rows.Count - 1; i2++)
            {
                if (ds2.Tables[0].Rows.Count > 1)
                {
                    Xls.InsertAndCopyRange(myRange1, i2 + 12 + ds1.Tables[0].Rows.Count - 1, 1, 1, TFlxInsertMode.ShiftRowDown, TRangeCopyMode.All, Xls, 1);//ShiftRowDown可以把destRow給往下推
                }
            }
            #endregion


            string preotp1cd = "";
            int tmp_param1 = 0;
            int tmp_param2 = 0;
            for (int ib1 = 0; ib1 < ds1.Tables[0].Rows.Count; ib1++)
            {
                if (ds1.Tables[0].Rows[ib1]["tmp_otp1cd"].ToString() == preotp1cd)
                {
                    Xls.SetCellValue(ib1 + 6, 1, "");
                }
                else
                {
                    Xls.SetCellValue(ib1 + 6, 1, ds1.Tables[0].Rows[ib1]["otp_otp1nm"].ToString());
                }

                Xls.SetCellValue(ib1 + 6, 3, ds1.Tables[0].Rows[ib1]["otp_otp2nm"].ToString());
                Xls.SetCellValue(ib1 + 6, 5, ds1.Tables[0].Rows[ib1]["tmp_param1"].ToString());
                Xls.SetCellValue(ib1 + 6, 6, ds1.Tables[0].Rows[ib1]["tmp_param2"].ToString());
                preotp1cd = ds1.Tables[0].Rows[ib1]["tmp_otp1cd"].ToString();
                tmp_param1 += Convert.ToInt32(ds1.Tables[0].Rows[ib1]["tmp_param1"].ToString());
                tmp_param2 += Convert.ToInt32(ds1.Tables[0].Rows[ib1]["tmp_param2"].ToString());
            }

            Xls.SetCellValue(ds1.Tables[0].Rows.Count + 1 + 6, 5, tmp_param1);
            Xls.SetCellValue(ds1.Tables[0].Rows.Count + 1 + 7, 6, tmp_param2);

            preotp1cd = "";
            tmp_param1 = 0;
            tmp_param2 = 0;
            for (int ib2 = 0; ib2 < ds2.Tables[0].Rows.Count; ib2++)
            {
                if (ds2.Tables[0].Rows[ib2]["tmp_otp1cd"].ToString() == preotp1cd)
                {
                    Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 1, "");
                }
                else
                {
                    Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 1, ds2.Tables[0].Rows[ib2]["otp_otp1nm"].ToString());
                }

                Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 3, ds2.Tables[0].Rows[ib2]["otp_otp2nm"].ToString());
                Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 5, ds2.Tables[0].Rows[ib2]["tmp_param1"].ToString());
                Xls.SetCellValue(ib2 + 11 + ds1.Tables[0].Rows.Count - 1, 6, ds2.Tables[0].Rows[ib2]["tmp_param2"].ToString());
                preotp1cd = ds2.Tables[0].Rows[ib2]["tmp_otp1cd"].ToString();
                tmp_param1 += Convert.ToInt32(ds2.Tables[0].Rows[ib2]["tmp_param1"].ToString());
                tmp_param2 += Convert.ToInt32(ds2.Tables[0].Rows[ib2]["tmp_param2"].ToString());
            }

            Xls.SetCellValue(ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + 1 + 11 - 1, 5, tmp_param1);
            Xls.SetCellValue(ds1.Tables[0].Rows.Count + ds2.Tables[0].Rows.Count + 1 + 12 - 1, 6, tmp_param2);

            Common.excuteExcel(Xls, "cust_mnt.xls");

        }
    }
}