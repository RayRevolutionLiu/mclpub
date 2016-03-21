using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.SetAccount
{
    public partial class iaFm1_chklist : System.Web.UI.Page
    {
        security sec = new security();
        iaFm1_chklist_DB myiaFm = new iaFm1_chklist_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string StrCont = sec.decryptquerystring(Context.Request.QueryString["contno"].ToString().Trim());
                    string Strimseq = sec.decryptquerystring(Context.Request.QueryString["imseq"].ToString().Trim());
                    if (StrCont != "" && Strimseq!="")
                    {
                        // 抓出剛產生的發票開立單編號
                        GetNewIANo();

                        // 載入合約資料
                        BindGrid1();

                        // 顯示發票資料
                        BindGrid2();
                    }
                    else
                    {
                        this.lblCont.Visible = false;
                        this.lblIA.Visible = false;

                        this.DataGrid1.Visible = false;
                        this.DataGrid2.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        // 抓出剛產生的發票開立單編號
        private void GetNewIANo()
        {
            string strContNo = sec.decryptquerystring(Context.Request.QueryString["contno"].ToString().Trim());

            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = myiaFm.SelectMAXia();
            DataView dv1 = ds1.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr1 = "1=1";
            dv1.RowFilter = rowfilterstr1;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            if (dv1.Count > 0)
            {
                string strIANo = dv1[0]["MaxIANno"].ToString().Trim();
                this.tbxIANo.Text = strIANo;
                //Response.Write("strIANo= " + strIANo + "<br>");

                string strIMSeq = "", strIMName = "";
                strIMSeq = sec.decryptquerystring(Context.Request.QueryString["imseq"].ToString().Trim());
                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds2 = myiaFm.Selectinvmfra();
                DataView dv2 = ds2.Tables[0].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr2 = "1=1";
                rowfilterstr2 = rowfilterstr2 + " AND im_contno='" + strContNo + "'";
                rowfilterstr2 = rowfilterstr2 + " AND im_imseq='" + strIMSeq + "'";
                dv2.RowFilter = rowfilterstr2;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
                //Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

                // 若搜尋結果為 "找不到" 的處理
                if (dv2.Count > 0)
                {
                    strIMName = dv2[0]["im_nm"].ToString().Trim();
                }
                else
                {
                    strIMName = "";
                }


                // 顯示總筆數
                this.lblContMessage.Text = "(合約編號／發票廠商：" + strContNo + "／" + strIMSeq + "-" + strIMName + ")";
                this.lblIAMessage.Text = "(發票開立單號：" + strIANo + ")";


                // 載入合約資料
                BindGrid1();
            }
            else
            {
                this.lblContMessage.Text = "無合約資料!";
                this.lblIAMessage.Text = "無開立發票資料!";
            }
        }


        // 顯示 DataGrid1 的資料項 -- 合約資料
        private void BindGrid1()
        {
            string strContNo = sec.decryptquerystring(Context.Request.QueryString["contno"].ToString().Trim());

            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds3 = myiaFm.Selectc2_cont();
            DataView dv3 = ds3.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr3 = "1=1";
            rowfilterstr3 = rowfilterstr3 + " AND cont_syscd='C2'";
            rowfilterstr3 = rowfilterstr3 + " AND cont_contno='" + strContNo + "'";
            dv3.RowFilter = rowfilterstr3;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
            //Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            DataGrid1.DataSource = dv3;
            DataGrid1.DataBind();

        }


        // 顯示 DataGrid2 的資料項 -- 發票資料
        private void BindGrid2()
        {
            string strContNo, strIANo;
            strContNo = sec.decryptquerystring(Context.Request.QueryString["contno"].ToString().Trim());
            strIANo = this.tbxIANo.Text.ToString().Trim();


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds4 = myiaFm.Selectia();
            DataView dv4 = ds4.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr4 = "1=1";
            rowfilterstr4 = rowfilterstr4 + " AND ia_syscd = 'C2'";
            rowfilterstr4 = rowfilterstr4 + " AND ia_iano = '" + strIANo + "'";
            rowfilterstr4 = rowfilterstr4 + " AND ia_iasdate = '' ";
            rowfilterstr4 = rowfilterstr4 + " AND ia_iasseq = '' ";
            rowfilterstr4 = rowfilterstr4 + " AND ia_iaitem = '' ";
            rowfilterstr4 = rowfilterstr4 + " AND ia_contno = 'C2" + strContNo + "'";
            dv4.RowFilter = rowfilterstr4;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
            //Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            DataGrid2.DataSource = dv4;
            DataGrid2.DataBind();

            // 結束 if (dv4.Count > 0)

        }

        protected void DataGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                // 合約類別
                string conttp = e.Row.Cells[5].Text.ToString().Trim();
                //Response.Write("conttp= " + conttp + "<br>");
                if (conttp == "01")
                    e.Row.Cells[5].Text = "一般";
                else if (conttp == "09")
                    e.Row.Cells[5].Text = "<font color='Red'>推廣</font>";

                // 簽約日期
                string SignDate = e.Row.Cells[6].Text.ToString().Trim();
                SignDate = SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
                //Response.Write("SignDate= " + SignDate + "<br>");
                e.Row.Cells[6].Text = SignDate;

                // 合約起日
                string StartDate = e.Row.Cells[7].Text.ToString().Trim();
                StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
                //Response.Write("StartDate= " + StartDate + "<br>");
                e.Row.Cells[7].Text = StartDate;

                // 合約迄日
                string EndDate = e.Row.Cells[8].Text.ToString().Trim();
                EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
                //Response.Write("EndDate= " + EndDate + "<br>");
                e.Row.Cells[8].Text = EndDate;

                // 結案註記
                string fgclosed = e.Row.Cells[16].Text.ToString().Trim();
                //Response.Write("fgclosed= " + fgclosed + "<br>");
                if (fgclosed == "0")
                    e.Row.Cells[16].Text = "否";
                else
                    e.Row.Cells[16].Text = "<font color='Red'>是</font>";

            }
        }

        protected void DataGrid2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                // 發票類別代碼
                string invcd = e.Row.Cells[8].Text.ToString().Trim();
                //Response.Write("invcd= " + invcd + "<br>");
                switch (invcd)
                {
                    case "2":
                        e.Row.Cells[8].Text = "<font color='Red'>二聯式</font>";
                        break;
                    case "3":
                        e.Row.Cells[8].Text = "三聯式";
                        break;
                    case "4":
                        e.Row.Cells[8].Text = "<font color='Red'>其他</font>";
                        break;
                    default:
                        e.Row.Cells[8].Text = "三聯式";
                        break;
                }

                // 發票課稅別代碼
                string taxtp = e.Row.Cells[9].Text.ToString().Trim();
                //Response.Write("taxtp= " + taxtp + "<br>");
                switch (taxtp)
                {
                    case "1":
                        e.Row.Cells[9].Text = "應稅5%";
                        break;
                    case "2":
                        e.Row.Cells[9].Text = "<font color='Red'>零稅</font>";
                        break;
                    case "3":
                        e.Row.Cells[9].Text = "<font color='Red'>免稅</font>";
                        break;
                    default:
                        e.Row.Cells[9].Text = "應稅5%";
                        break;
                }
            }
        }

        protected void btnAddIA_Click(object sender, EventArgs e)
        {
            string strbuf = "iaFm1_Add.aspx";
            Response.Redirect(strbuf);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}