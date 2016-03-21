using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Contract
{
    public partial class ContChkList : System.Web.UI.Page
    {
        ContChkList_DB myCont = new ContChkList_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.SearchIcon.Visible = false;
                lbNoCount.Visible = false;

                Session.Remove("RPTCONTLIST");
                Bind_ddlEmpData();
            }
        }

        #region 連結員工資料
        private void Bind_ddlEmpData()
        {
            DataSet ds = myCont.SelectSrspn();
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


        protected void btnQuery_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;
            this.lbNoCount.Text = "";

            string STRtbxContNo = "";
            string STRtbxSDate = "";
            string STRtbxEDate = "";
            string STRddlEmpData = "";
            string STRddlClosed = "";
            if (tbxContNo.Text.Trim() != "")
            {
                STRtbxContNo = tbxContNo.Text.Trim();
            }
            if (tbxSDate.Text.Trim() != "")
            {
                STRtbxSDate = tbxSDate.Text.Trim();
            }
            if (tbxEDate.Text.Trim() != "")
            {
                STRtbxEDate = tbxEDate.Text.Trim();
            }
            if (ddlEmpData.SelectedValue.ToString().Trim() != "000000")
            {
                STRddlEmpData = ddlEmpData.SelectedValue.ToString().Trim();
            }
            if (ddlClosed.SelectedValue.ToString().Trim() != "99")
            {
                STRddlClosed = ddlClosed.SelectedValue.ToString().Trim();
            }


            DataSet ds1 = myCont.GetContract(STRtbxContNo, STRtbxSDate, STRtbxEDate, STRddlEmpData, STRddlClosed);

            // 若有資料, 則顯示相關資料; 否則給予錯誤訊息
            if (ds1.Tables[0].Rows.Count > 0)
            {
                // 顯示 DataList1 
                this.DataList1.Visible = true;

                //Response.Write("有 " + dv1.Count + " 筆資料");
                //				this.lblRecordCount.Text = "查詢結果：共有 " + dv1.Count + " 筆資料!";
                DataList1.DataSource = ds1;
                DataList1.DataBind();

                // 特別欄位之輸出格式轉換
                for (int i = 0; i < DataList1.Items.Count; i++)
                {

                    // 抓出 發票廠商收件人 dgdNewInvMfr			
                    // 使用 DataSet 方法, 並指定使用的 table 名稱
                    string contno = ((Label)DataList1.Items[i].FindControl("lblContno")).Text.Trim();
                    DataSet ds2 = myCont.GetInvMfr(contno);
                    DataView dv2 = ds2.Tables[0].DefaultView;
                    if (dv2.Count > 0)
                    {
                        ((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).DataSource = dv2;
                        ((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).DataBind();


                        // 特別欄位之輸出格式轉換 - 變更發票類別等的格式
                        int j;
                        for (j = 0; j < ((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).Items.Count; j++)
                        {
                            // 院所內註記
                            string fgitri = ((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).Items[j].Cells[12].Text.ToString().Trim();
                            if (fgitri == "")
                                ((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).Items[j].Cells[12].Text = "否";
                            else
                            {
                                if (fgitri == "06")
                                    ((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).Items[j].Cells[12].Text = "<font color='Red'>所內</font>";
                                if (fgitri == "07")
                                    ((DataGrid)DataList1.Items[i].FindControl("dgdNewInvMfr")).Items[j].Cells[12].Text = "<font color='Red'>院內</font>";
                            }
                        }
                    }


                    // 抓出 雜誌收件人 DataGrid2
                    // 使用 DataSet 方法, 並指定使用的 table 名稱
                    DataSet ds3 = myCont.GetOrByContNo(contno);
                    DataView dv3 = ds3.Tables[0].DefaultView;
                    if (dv3.Count > 0)
                    {
                        ((DataGrid)DataList1.Items[i].FindControl("dgdNewOr")).DataSource = dv3;
                        ((DataGrid)DataList1.Items[i].FindControl("dgdNewOr")).DataBind();

                        int j;
                        for (j = 0; j < ((DataGrid)DataList1.Items[i].FindControl("dgdNewOr")).Items.Count; j++)
                        {
                            // 海外郵寄註記
                            string fgmosea = ((DataGrid)DataList1.Items[i].FindControl("dgdNewOr")).Items[j].Cells[9].Text.ToString().Trim();
                            //Response.Write("fgmosea = " + fgmosea + "<br>");
                            if (fgmosea == "1")
                                ((DataGrid)DataList1.Items[i].FindControl("dgdNewOr")).Items[j].Cells[9].Text = "是";
                            else
                                ((DataGrid)DataList1.Items[i].FindControl("dgdNewOr")).Items[j].Cells[9].Text = "否";

                        }
                    }

                    DataSet ds4 = myCont.GetFbkOrByContNo(contno);
                    DataView dv4 = ds4.Tables[0].DefaultView;
                    if (dv4.Count > 0)
                    {
                        ((DataGrid)DataList1.Items[i].FindControl("dgdNewFreeBk")).DataSource = dv4;
                        ((DataGrid)DataList1.Items[i].FindControl("dgdNewFreeBk")).DataBind();
                    }

                    //應用產業及材料特性				

                    DataSet ds5 = myCont.GetAtpMtps_Display(contno, "1");
                    DataView dv5 = ds5.Tables[0].DefaultView;
                    if (dv5.Count > 0)
                    {
                        DataTable dt = new DataTable();
                        DataColumn c1 = new DataColumn("cls2_cname", typeof(System.String));
                        dt.Columns.Add(c1);
                        DataColumn c2 = new DataColumn("cls3_cname", typeof(System.String));
                        dt.Columns.Add(c2);
                        DataRow dr;

                        string strcls2, strcls3;
                        strcls2 = strcls3 = "";
                        for (int idx = 0; idx < dv5.Count; idx++)
                        {
                            if (dv5[idx].Row["cls2_cname"].ToString() != strcls2)
                            {
                                if (idx > 0)
                                {
                                    dr = dt.NewRow();
                                    dr["cls2_cname"] = strcls2;
                                    dr["cls3_cname"] = strcls3;
                                    dt.Rows.Add(dr);
                                }
                                strcls2 = dv5[idx].Row["cls2_cname"].ToString();
                                strcls3 = dv5[idx].Row["cls3_cname"].ToString();
                            }
                            else
                            {
                                strcls3 = strcls3 + ";" + dv5[idx].Row["cls3_cname"].ToString();
                            }
                        }
                        //最後一次
                        dr = dt.NewRow();
                        dr["cls2_cname"] = strcls2;
                        dr["cls3_cname"] = strcls3;
                        dt.Rows.Add(dr);
                        ((DataGrid)DataList1.Items[i].FindControl("dgdAtpMatp1")).DataSource = dt;
                        ((DataGrid)DataList1.Items[i].FindControl("dgdAtpMatp1")).DataBind();
                    }

                    DataSet ds6 = myCont.GetAtpMtps_Display(contno, "2");
                    DataView dv6 = ds6.Tables[0].DefaultView;

                    if (dv6.Count > 0)
                    {
                        DataTable dt = new DataTable();
                        DataColumn c1 = new DataColumn("cls2_cname", typeof(System.String));
                        dt.Columns.Add(c1);
                        DataColumn c2 = new DataColumn("cls3_cname", typeof(System.String));
                        dt.Columns.Add(c2);
                        DataRow dr;

                        string strcls2, strcls3;
                        strcls2 = strcls3 = "";
                        for (int idx = 0; idx < dv6.Count; idx++)
                        {
                            if (dv6[idx].Row["cls2_cname"].ToString() != strcls2)
                            {
                                if (idx > 0)
                                {
                                    dr = dt.NewRow();
                                    dr["cls2_cname"] = strcls2;
                                    dr["cls3_cname"] = strcls3;
                                    dt.Rows.Add(dr);
                                }
                                strcls2 = dv6[idx].Row["cls2_cname"].ToString();
                                strcls3 = dv6[idx].Row["cls3_cname"].ToString();
                            }
                            else
                            {
                                strcls3 = strcls3 + ";" + dv6[idx].Row["cls3_cname"].ToString();
                            }
                        }
                        //最後一次
                        dr = dt.NewRow();
                        dr["cls2_cname"] = strcls2;
                        dr["cls3_cname"] = strcls3;
                        dt.Rows.Add(dr);
                        ((DataGrid)DataList1.Items[i].FindControl("dgdAtpMatp2")).DataSource = dt;
                        ((DataGrid)DataList1.Items[i].FindControl("dgdAtpMatp2")).DataBind();
                    }
                }
            }
            else
            {
                this.lbNoCount.Visible = true;
                this.lbNoCount.Text = "查無資料, 請重新輸入查詢條件!";

                // 隱藏 DataList1 
                this.DataList1.Visible = false;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}
