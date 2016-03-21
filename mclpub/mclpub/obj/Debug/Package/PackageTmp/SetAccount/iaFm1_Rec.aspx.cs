﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.SetAccount
{
    public partial class iaFm1_Rec : System.Web.UI.Page
    {
        iaFm1_Rec_DB myiaFm1 = new iaFm1_Rec_DB();
        security sec = new security();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "DataGrid1";
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                UCPager1.Visible = false;
            }
        }


        // 網頁預設值
        private void InitialData()
        {
            this.lblMfrNo.Text = "";
            this.tbxMfrIName.Text = "";
            this.tbxIMName.Text = "";
            this.tbxIANo.Text = "";
        }


        protected void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.tbxMfrIName.Text.ToString().Trim() != "" || this.tbxIMName.Text.ToString().Trim() != "")
            {
                SearchIcon.Visible = true;
                BindGrid1();
            }
            else if (this.tbxMfrIName.Text.ToString().Trim() == "" && this.tbxIMName.Text.ToString().Trim() == "" && this.tbxIANo.Text.ToString().Trim() == "")
            {
                InitialData();
                JavaScript.AlertMessage(this.Page, "您並未輸入條件, 無法查詢!");
                return;
            }

            if (this.tbxIANo.Text.ToString().Trim() != "")
            {
                BindGrid2();
            }
        }


        // 顯示資料 DataGrid1
        private void BindGrid1()
        {
            // 抓出篩選條件
            string strMfrIName = this.tbxMfrIName.Text.ToString().Trim();
            string strIMName = this.tbxIMName.Text.ToString().Trim();
            //Response.Write("strMfrIName=" + strMfrIName + "<br>");
            //Response.Write("strIMName=" + strIMName + "<br>");


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = myiaFm1.Selectc2_cont();
            DataView dv1 = ds1.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr1 = "1=1";
            if (strMfrIName!="")
                rowfilterstr1 = rowfilterstr1 + " AND mfr_inm Like '%" + strMfrIName + "%'";
            if (strIMName!="")
                rowfilterstr1 = rowfilterstr1 + " AND im_nm Like '%" + strIMName + "%'";
            dv1.RowFilter = rowfilterstr1;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

            UCPager1.Dtdata = dv1.ToTable();
            UCPager1.UCPageBind();
            //DataGrid1.DataSource = dv1;
            //DataGrid1.DataBind();

            if (dv1.Count > 0)
            {
                this.DataGrid1.Visible = true;
                UCPager1.Visible = true;

                string MfrIName = dv1[0]["mfr_inm"].ToString().Trim();
                string MfrNo = dv1[0]["cont_mfrno"].ToString().Trim();
                this.lblMfrNo.Text = "(廠商名稱：" + MfrIName + "；廠商統編：" + MfrNo + ")";
                this.tbxMfrNo.Text = dv1[0]["cont_mfrno"].ToString().Trim();

            }
            else
            {
                this.lblMfrNo.Text = "無此廠商編號";
            }
        }

        // 顯示資料 DataGrid2 - 繼續挑選發票開立單編號
        private void BindGrid2()
        {
            // 抓出篩選條件
            string strMfrNo = this.tbxMfrNo.Text.ToString().Trim();
            string strContNo = "";
            string strIMSeq = "";
            string strIMName = "";
            string strIANo = "";
            if (this.tbxIANo.Text.ToString().Trim() != "")
                strIANo = this.tbxIANo.Text.ToString().Trim();
            if (this.tbxContNo.Text.ToString().Trim() != "" && this.tbxIMSeq.Text.ToString() != "")
            {
                strContNo = this.tbxContNo.Text.ToString().Trim();
                strIMSeq = this.tbxIMSeq.Text.ToString();
                strIMName = this.tbxIMName2.Text.ToString().Trim();
            }
            else
            {
                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds3 = myiaFm1.Selectia();
                DataView dv3 = ds3.Tables[0].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr3 = "1=1";
                rowfilterstr3 = rowfilterstr3 + " AND ia_iano='" + strIANo + "'";
                dv3.RowFilter = rowfilterstr3;

                // 
                if (dv3.Count > 0)
                {
                    strContNo = dv3[0]["ia_contno"].ToString().Trim();
                    strIMSeq = dv3[0]["im_imseq"].ToString().Trim();
                    strIMName = dv3[0]["ia_rnm"].ToString().Trim();
                    this.tbxContNo.Text = strContNo;
                    this.tbxIMSeq.Text = strIMSeq;
                    this.tbxIMName2.Text = strIMName;
                }
            }

            // 先檢查該合約是否有未開發票的落版資料, 若無, 不予轉址
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds2 = myiaFm1.Selectia2();
            DataView dv2 = ds2.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr2 = "1=1";
            if (strIANo!="")
            {
                rowfilterstr2 = rowfilterstr2 + " AND ia_iano = '" + strIANo + "'";
            }
            else
            {
                rowfilterstr2 = rowfilterstr2 + " AND ia_mfrno ='" + strMfrNo + "'";
                rowfilterstr2 = rowfilterstr2 + " AND ia_contno = 'C2" + strContNo + "'";
                rowfilterstr2 = rowfilterstr2 + " AND ia_rnm = '" + strIMName + "'";
            }
            dv2.RowFilter = rowfilterstr2;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
            //Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

            if (dv2.Count > 0)
            {
                this.DataGrid1.Visible = false;
                this.DataGrid2.Visible = true;
                UCPager1.Visible = false;
                DataGrid2.DataSource = dv2;
                DataGrid2.DataBind();

                this.lblMessage.Text = "合約編號 " + strContNo + " 有 " + dv2.Count + " 筆發票開立單資料!";
            }
            else
            {
                DataGrid2.Visible = false;
                DataGrid1.Visible = true;
                UCPager1.Visible = true;
                JavaScript.AlertMessage(this.Page, "無發票開立單資料!");
                return;
            }
        }

        protected void DataGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                // 合約類別
                string conttp = e.Row.Cells[6].Text.ToString().Trim();
                //Response.Write("conttp= " + conttp + "<br>");
                if (conttp == "01")
                    e.Row.Cells[6].Text = "一般";
                else if (conttp == "09")
                    e.Row.Cells[6].Text = "<font color='Red'>推廣</font>";

                // 簽約日期
                string SignDate = e.Row.Cells[7].Text.ToString().Trim();
                SignDate = SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
                //Response.Write("SignDate= " + SignDate + "<br>");
                e.Row.Cells[7].Text = SignDate;

                // 合約起日
                string StartDate = e.Row.Cells[8].Text.ToString().Trim();
                StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
                //Response.Write("StartDate= " + StartDate + "<br>");
                e.Row.Cells[8].Text = StartDate;

                // 合約迄日
                string EndDate = e.Row.Cells[9].Text.ToString().Trim();
                EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
                //Response.Write("EndDate= " + EndDate + "<br>");
                e.Row.Cells[9].Text = EndDate;

                // 結案註記
                string fgclosed = e.Row.Cells[17].Text.ToString().Trim();
                //Response.Write("fgclosed= " + fgclosed + "<br>");
                if (fgclosed == "0")
                    e.Row.Cells[17].Text = "否";
                else
                    e.Row.Cells[17].Text = "<font color='Red'>是</font>";

            }
        }

        protected void DataGrid2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                // 發票類別
                string invcd = e.Row.Cells[9].Text.ToString().Trim();
                //Response.Write("invcd= " + invcd + "<br>");
                switch (invcd)
                {
                    case "2":
                        e.Row.Cells[9].Text = "二聯式";
                        break;
                    case "3":
                        e.Row.Cells[9].Text = "三聯式";
                        break;
                    case "4":
                        e.Row.Cells[9].Text = "其他";
                        break;
                    default:
                        e.Row.Cells[9].Text = "三聯式";
                        break;
                }

                // 發票類別
                string taxtp = e.Row.Cells[10].Text.ToString().Trim();
                //Response.Write("taxtp= " + taxtp + "<br>");
                switch (taxtp)
                {
                    case "1":
                        e.Row.Cells[10].Text = "應稅5%";
                        break;
                    case "2":
                        e.Row.Cells[10].Text = "零稅";
                        break;
                    case "3":
                        e.Row.Cells[10].Text = "免稅";
                        break;
                    default:
                        e.Row.Cells[10].Text = "應稅5%";
                        break;
                }

                // 發票狀態
                string status = e.Row.Cells[11].Text.ToString().Trim();
                //Response.Write("status= " + status + "<br>");
                switch (status)
                {
                    case " ":
                        e.Row.Cells[11].Text = "已產生開立單";
                        break;
                    case "v":
                        e.Row.Cells[11].Text = "已產生開立清單";
                        break;
                    case "5":
                        e.Row.Cells[11].Text = "已列印開立單";
                        break;
                    case "7":
                        e.Row.Cells[11].Text = "已轉sap";
                        break;
                    default:
                        e.Row.Cells[11].Text = "已產生開立單";
                        break;
                }

                // 發票號碼
                string invno = e.Row.Cells[12].Text.ToString().Trim();
                //Response.Write("invno= " + invno + "<br>");
                if (invno != "")
                    e.Row.Cells[12].Text = invno;
                else
                    e.Row.Cells[12].Text = "(尚無)";

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((LinkButton)sender).Parent.Parent as GridViewRow;  //此段取到該Row

            // 抓出 ItemTemplate 之 RadioButton 型態之 cbxUpdate (Controls[1])
            //bool strSelectIM = ((RadioButton)DataGrid1.Items[i].Cells[0].FindControl("rabSelectIMSeq")).Checked;
            string strContNo = thisRow.Cells[1].Text.ToString().Trim();
            string strIMSeq = thisRow.Cells[2].Text.ToString().Trim();
            string strIMName = thisRow.Cells[3].Text.ToString().Trim();
            //Response.Write("strContNo= " + strContNo + ", ");
            //Response.Write("strIMSeq= " + strIMSeq + ", ");
            //Response.Write("strIMName= " + strIMName + "<br>");

            // 寫入隱藏值
            this.tbxContNo.Text = strContNo;
            this.tbxIMSeq.Text = strIMSeq;
            this.tbxIMName2.Text = strIMName;


            // 繼續挑選發票開立單編號
            this.DataGrid1.Visible = false;
            BindGrid2();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((LinkButton)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            // 判斷是否可做 回復動作
            string strContNo = this.tbxContNo.Text.ToString().Trim();
            string strIMSeq = this.tbxIMSeq.Text.ToString().Trim();
            string strIANo = thisRow.Cells[1].Text.ToString();
            string strIAStatus = thisRow.Cells[13].Text.ToString().Trim();
            		
            if (strIAStatus == "")
            {
                //轉址
                string strbuf = "iaFm1_Recia.aspx?contno=" + sec.encryptquerystring(strContNo) + "&imseq=" + sec.encryptquerystring(strIMSeq) + "&iano=" + sec.encryptquerystring(strIANo);
                Response.Redirect(strbuf);
            }
            else
            {
                JavaScript.AlertMessage(this.Page, "此狀態不予許做回復動作!");
                return;
            }
        }
    }
}