using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class pub_new1 : System.Web.UI.Page
    {
        pub_new1_DB mypub = new pub_new1_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GVcont";
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                UCPager1.Visible = false;
                lblMessage.Visible = false;
            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            ShowPub();
        }

        private void ShowPub()
        {
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = mypub.Selectc2_pub();
            DataView dv1 = ds1.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
            string rowfilterstr1 = " 1=1 ";

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

            //防呆處理: 若無資料時, 則給錯誤訊息
            if (tbxMfrNo.Text.Trim() != "")
            {
                rowfilterstr1 = rowfilterstr1 + " AND mfr_mfrno Like '%" + tbxMfrNo.Text.Trim() + "%' ";
            }

            if (tbxMfrName.Text != "")
            {
                rowfilterstr1 = rowfilterstr1 + " AND mfr_inm Like '%" + tbxMfrName.Text.Trim() + "%'";
            }

            if (tbxCustNo.Text != "")
            {
                rowfilterstr1 = rowfilterstr1 + " AND cont_custno Like '%" + tbxCustNo.Text.Trim() + "%'";
            }

            if (tbxCustName.Text != "")
            {
                rowfilterstr1 = rowfilterstr1 + " AND cust_nm Like '%" + tbxCustName.Text.Trim() + "%'";
            }

            if (tbxContNo.Text != "")
            {
                rowfilterstr1 = rowfilterstr1 + " AND cont_contno like '%" + tbxContNo.Text.Trim() + "%'";
            }

            //如果不是B級業務人員，只能看到自己的客戶資料 這沒什麼意義 拿掉好了
            //if (Account.GetAccInfo().srspn_atype.ToString().Trim() != "B")
            //{
            //    rowfilterstr1 = rowfilterstr1 + " and cont_empno ='" + Account.GetAccInfo().srspn_atype.ToString().Trim() + "'";
            //}

            dv1.RowFilter = rowfilterstr1;



            //Response.Write(dv1.Count);
            // 若搜尋結果為 "找不到" 的處理
            if (dv1.Count == 0)
            {
                lblMessage.Text = "結果: 找不到符合條件的資料, 您可以 1.重設條件  2.新增廠商或訂戶資料";
            }
            //lblMessage.Text="查詢結果: 找不到符合條件的資料, 請重設條件!  或請先新增<A HREF='../d5/Mfr.aspx' Target='_new'>廠商</A> 或 <A HREF='../d1/NewCust.aspx?mfrno=' Target='_new'>客戶</A>, 再回來搜尋並新增.";
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "結果: 找到 " + dv1.Count.ToString() + "筆資料";
                UCPager1.Visible = true;
            }

            this.UCPager1.Dtdata = dv1.ToTable();
            this.UCPager1.UCPageBind();

            SearchIcon.Visible = true;

        }

        protected void GVcont_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[12].Visible = false;
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                // 合約類別
                int ContTypeCode = int.Parse(e.Row.Cells[1].Text.ToString().Trim());
                if (ContTypeCode == 1)
                    e.Row.Cells[1].Text = "一般合約";
                else
                    e.Row.Cells[1].Text = "<font color=blue>推廣合約</font>";

                //書籍類別
                //string bkcd = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();

                // 合約起日 & 合約迄日
                string StartDate = e.Row.Cells[4].Text.ToString().Trim();
                if (StartDate != "")
                {
                    if (StartDate.Length >= 6)
                        StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
                    else
                    {
                        // 分離 \ 符號以取得數字
                        if (StartDate.IndexOf("\\") != -1)
                        {
                            //StartDate = StartDate.Split('/', 2);
                        }
                        else
                            StartDate = StartDate;
                    }
                }
                else
                {
                    StartDate = StartDate;
                }
                string EndDate = e.Row.Cells[5].Text.ToString().Trim();
                if (EndDate != "")
                {
                    if (EndDate.Length >= 6)
                        EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
                    else
                    {
                        // 分離 \ 符號以取得數字
                        if (EndDate.IndexOf("\\") != -1)
                        {
                            //EndDate = EndDate.Split('/', 2);
                        }
                        else
                            EndDate = EndDate;
                    }
                }
                else
                {
                    EndDate = EndDate;
                }
                e.Row.Cells[4].Text = StartDate;
                e.Row.Cells[5].Text = EndDate;


                // 已落版註記
                string strfgpubed = e.Row.Cells[11].Text.ToString().Trim();
                //Response.Write("strfgpubed= " + strfgpubed + "<br>");
                if (strfgpubed == "0")
                {
                    e.Row.Cells[11].Text = "否";
                }
                else
                {
                    e.Row.Cells[11].Text = "<font color=red>是</font>";
                }

            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[12].Visible = false;
            }


        }

        protected void btnRedirect_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ide = thisRow.Cells[0].Text;
            string ide2 = thisRow.Cells[2].Text;
            string ide12 = thisRow.Cells[12].Text;
            // 按下確定(挑人)的處理: 先轉址
            //Response.Write("ConttpText= " + ConttpText + "<br>");
            Response.Redirect("PubFm.aspx?contno=" + ide + "&bkcd=" + ide2 + "&fgnew=" + ide12);

        }
    }
}