using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FlexCel.Core;
using FlexCel.XlsAdapter;
using FlexCel.Render;

namespace mclpub.Subscriber
{
    public partial class RptCustQuery : System.Web.UI.Page
    {
        RptCustQuery_DB myRpt = new RptCustQuery_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();

                //if (CLFGV.Rows.Count > 0)
                //{
                //    CheckBtn1.Enabled = true;
                //    SearchIcon.Visible = true;
                //}
                //else
                //{
                //    SearchIcon.Visible = false;
                //    CheckBtn1.Enabled = false;
                //}
            }
        }

        public void BindData()
        {
            DataTable dt1 = myRpt.GetClass2(1);
            DataRow dr1 = dt1.NewRow();
            dr1["cls2_cls2id"] = "0";
            dr1["cls2_cname"] = "請選擇";
            dt1.Rows.Add(dr1);
            dt1.DefaultView.Sort = "cls2_cls2id ASC";

            DataView dv = dt1.DefaultView;
            this.ddlClass1.DataTextField = "cls2_cname";
            this.ddlClass1.DataValueField = "cls2_cls2id";
            this.ddlClass1.DataSource = dv;
            this.ddlClass1.DataBind();



            DataTable dt2 = myRpt.GetClass2(2);
            DataRow dr2 = dt2.NewRow();
            dr2["cls2_cls2id"] = "0";
            dr2["cls2_cname"] = "請選擇";
            dt2.Rows.Add(dr2);
            dt2.DefaultView.Sort = "cls2_cls2id ASC";

            DataView dv2 = dt2.DefaultView;
            this.ddlClass2.DataTextField = "cls2_cname";
            this.ddlClass2.DataValueField = "cls2_cls2id";
            this.ddlClass2.DataSource = dv2;
            this.ddlClass2.DataBind();



            DataTable dt3 = myRpt.GetSrspns();
            DataRow dr3 = dt3.NewRow();
            dr3["srspn_empno"] = "000000";
            dr3["srspn_cname"] = "請選擇";
            dt3.Rows.Add(dr3);
            dt3.DefaultView.Sort = "srspn_empno ASC";

            DataView dv3 = dt3.DefaultView;
            this.ddlEmpData.DataTextField = "srspn_cname";
            this.ddlEmpData.DataValueField = "srspn_empno";
            this.ddlEmpData.DataSource = dv3;
            this.ddlEmpData.DataBind();
        }

        protected void CheckBtn1_Click(object sender, EventArgs e)
        {
            string strddlContType = "";
            string strtbxSDate = "";
            string strtbxEDate = "";
            string strddlClass1 = "";
            string strddlClass2 = "";
            string strddlEmpData = "";
            string strddlClosed = "";
            if (ddlContType.SelectedValue.ToString() != "00")
            {
                strddlContType = ddlContType.SelectedValue.ToString();
            }
            if (tbxSDate.Text.Trim() != "" && tbxEDate.Text.Trim() != "")
            {
                strtbxSDate = tbxSDate.Text;
                strtbxEDate = tbxEDate.Text;
            }
            if (ddlClass1.SelectedValue.ToString() != "0")
            {
                strddlClass1 = ddlClass1.SelectedItem.Text.ToString();
            }
            if (ddlClass2.SelectedValue.ToString() != "0")
            {
                strddlClass2 = ddlClass2.SelectedItem.Text.ToString();
            }
            if (ddlEmpData.SelectedValue.ToString() != "000000")
            {
                strddlEmpData = ddlEmpData.SelectedValue.ToString();
            }
            if (ddlClosed.SelectedValue.ToString() != "00")
            {
                strddlClosed = ddlClosed.SelectedValue.ToString();
            }

            //Response.Write(strddlContType + "/" + strtbxSDate + "/" + strtbxEDate + "/" + strddlClass1 + "/" + strddlClass2 + "/" + strddlEmpData + "/" + strddlClosed);
            DataTable dt = myRpt.SelectChkBtn(strddlContType, strtbxSDate, strtbxEDate, strddlClass1, strddlClass2, strddlEmpData, strddlClosed);

            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/Subscriber/Template/" + "RptCustQuery.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;
            Xls.SetCellValue(3, 3, Account.GetAccInfo().srspn_cname.ToString());
            Xls.SetCellValue(4, 3, DateTime.Now.ToString("yyyy/MM/dd"));

            for (int i = 6; i < dt.Rows.Count + 6; i++)
            {
                Xls.SetCellValue(i, 1, i - 5);

                Xls.SetCellValue(i, 2, dt.Rows[i - 6]["cont_contno"].ToString());
                Xls.SetCellValue(i, 3, dt.Rows[i - 6]["mfr_inm"].ToString());
                Xls.SetCellValue(i, 4, dt.Rows[i - 6]["cont_signdate"].ToString().Trim() == "" ? "" : dt.Rows[i - 6]["cont_signdate"].ToString().Substring(0, 4) + "/" + dt.Rows[i - 6]["cont_signdate"].ToString().Substring(4, 2) + "/" + dt.Rows[i - 6]["cont_signdate"].ToString().Substring(6, 2));

                if (dt.Rows[i - 6]["cont_conttp"].ToString().Trim() == "01")
                {
                    Xls.SetCellValue(i, 5, "一般");
                }
                else
                {
                    Xls.SetCellValue(i, 5, "推廣");
                }

                string strSdate = dt.Rows[i - 6]["cont_sdate"].ToString().Trim() == "" ? "" : dt.Rows[i - 6]["cont_sdate"].ToString().Substring(0, 4) + "/" + dt.Rows[i - 6]["cont_sdate"].ToString().Substring(4, 2) + "/" + dt.Rows[i - 6]["cont_sdate"].ToString().Substring(6, 2);
                string strEdate = dt.Rows[i - 6]["cont_edate"].ToString().Trim() == "" ? "" : dt.Rows[i - 6]["cont_edate"].ToString().Substring(0, 4) + "/" + dt.Rows[i - 6]["cont_edate"].ToString().Substring(4, 2) + "/" + dt.Rows[i - 6]["cont_edate"].ToString().Substring(6, 2);

                Xls.SetCellValue(i, 6, strSdate + "~" + strEdate);
                Xls.SetCellValue(i, 7, dt.Rows[i - 6]["cont_pubtm"].ToString());
                DataTable dtPayed = myRpt.PayedMoney(dt.Rows[i - 6]["cont_contno"].ToString());
                if (dtPayed.Rows.Count > 0)
                {
                    Xls.SetCellValue(i, 8, dtPayed.Rows[0]["sum_py"].ToString());
                }
                else
                {
                    Xls.SetCellValue(i, 8, "0");
                }
                Xls.SetCellValue(i, 9, dt.Rows[i - 6]["cont_aunm"].ToString());
                Xls.SetCellValue(i, 10, dt.Rows[i - 6]["cont_autel"].ToString());
                Xls.SetCellValue(i, 11, dt.Rows[i - 6]["cont_aufax"].ToString());
                Xls.SetCellValue(i, 12, dt.Rows[i - 6]["cont_aucell"].ToString());
                Xls.SetCellValue(i, 13, dt.Rows[i - 6]["cont_auemail"].ToString());
                Xls.SetCellValue(i, 14, dt.Rows[i - 6]["wkmatp_matpstr"].ToString());
                Xls.SetCellValue(i, 15, dt.Rows[i - 6]["wkatp_atpstr"].ToString());
                Xls.SetCellValue(i, 16, dt.Rows[i - 6]["cont_ccont"].ToString());
                Xls.SetCellValue(i, 17, dt.Rows[i - 6]["cont_pdcont"].ToString());
                Xls.SetCellValue(i, 18, dt.Rows[i - 6]["cont_csdate"].ToString().Trim() == "" ? "" : dt.Rows[i - 6]["cont_csdate"].ToString().Substring(0, 4) + "/" + dt.Rows[i - 6]["cont_csdate"].ToString().Substring(4, 2) + "/" + dt.Rows[i - 6]["cont_csdate"].ToString().Substring(6, 2));
                Xls.SetCellValue(i, 19, dt.Rows[i - 6]["wkfbk_fbkstr"].ToString());
                DataTable dtDateSandE = myRpt.CountDateSandE(dt.Rows[i - 6]["cont_contno"].ToString());
                if (dtDateSandE.Rows.Count > 0)
                {
                    string datestrS = dtDateSandE.Rows[0]["sdate"].ToString().Length < 8 ? "" : dtDateSandE.Rows[0]["sdate"].ToString().Substring(0, 4) + "/" + dtDateSandE.Rows[0]["sdate"].ToString().Substring(4, 2) + "/" + dtDateSandE.Rows[0]["sdate"].ToString().Substring(6, 2);
                    string datestrE = dtDateSandE.Rows[0]["edate"].ToString().Length < 8 ? "" : dtDateSandE.Rows[0]["edate"].ToString().Substring(0, 4) + "/" + dtDateSandE.Rows[0]["edate"].ToString().Substring(4, 2) + "/" + dtDateSandE.Rows[0]["edate"].ToString().Substring(6, 2);
                    Xls.SetCellValue(i, 20, datestrS + "~" + datestrE);
                }
                else
                {
                    Xls.SetCellValue(i, 20, "");
                }
                Xls.SetCellValue(i, 21, dt.Rows[i - 6]["srspn_cname"].ToString());
                Xls.SetCellValue(i, 22, dt.Rows[i - 6]["cont_remark"].ToString());
            }

            Common.excuteExcel(Xls, "RptCustQuery.xls");
        }

        protected void Chkbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
