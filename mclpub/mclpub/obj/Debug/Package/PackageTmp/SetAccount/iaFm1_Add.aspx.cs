using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.SetAccount
{
    public partial class iaFm1_Add : System.Web.UI.Page
    {
        iaFm1_Add_DB myia = new iaFm1_Add_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "DataGrid1";
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                UCPager1.Visible = false;
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            DataTable dt = BindGrid1().ToTable();
            SearchIcon.Visible = true;
            UCPager1.Dtdata = dt;
            UCPager1.UCPageBind();
            if (dt.Rows.Count > 0)
            {
                UCPager1.Visible = true;

            }
            else
            {
                UCPager1.Visible = false;
            }
        }

        private DataView BindGrid1()
        {
            // 抓出廠商名稱
            string strMfrIName = this.tbxMfrIName.Text.ToString().Trim();
            string strIMName = this.tbxIMName.Text.ToString().Trim();
            //Response.Write("strMfrIName=" + strMfrIName + "<br>");
            //Response.Write("strIMName=" + strIMName + "<br>");


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = myia.Selectc2_Cont();
            DataView dv1 = ds1.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr1 = "1=1";
            if (strMfrIName.ToString().Trim() != "")
                rowfilterstr1 = rowfilterstr1 + " AND mfr_inm Like '%" + strMfrIName + "%'";
            if (strIMName.ToString().Trim() != "")
                rowfilterstr1 = rowfilterstr1 + " AND im_nm Like '%" + strIMName + "%'";
            dv1.RowFilter = rowfilterstr1;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

            return dv1;
        }

        protected void DataGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[19].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[19].Visible = false;
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

        protected void LinkButton1_Click(object sender, System.EventArgs e)
        {
            GridViewRow thisRow = ((LinkButton)sender).Parent.Parent as GridViewRow;  //此段取到該Row

            string strContNo = thisRow.Cells[1].Text.ToString().Trim();
            string strIMSeq = thisRow.Cells[2].Text.ToString().Trim();
            string strfgclosed = thisRow.Cells[19].Text.ToString().Trim();

            if (strfgclosed == "0")
            {
                // 先檢查該合約是否有未開發票的落版資料, 若無, 不予轉址
                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds2 = myia.Selectc2_pub();
                DataView dv2 = ds2.Tables[0].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr2 = "1=1";
                rowfilterstr2 = rowfilterstr2 + " AND pub_contno = '" + strContNo + "'";
                rowfilterstr2 = rowfilterstr2 + " AND pub_imseq = '" + strIMSeq + "'";
                dv2.RowFilter = rowfilterstr2;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
                //Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

                if (dv2.Count > 0)
                {
                    security sec = new security();
                    // 轉址
                    string strbuf = "iaFm1_Addia.aspx?contno=" + sec.encryptquerystring(strContNo) + "&imseq=" + sec.encryptquerystring(strIMSeq);
                    Response.Redirect(strbuf);
                }
                else
                {
                    JavaScript.AlertMessage(this.Page, "此合約的落版資料已全開完");
                }
            }
            else
            {
                JavaScript.AlertMessage(this.Page, "此合約已結案, 不允許再開立發票!");
            }
        }
    }
}