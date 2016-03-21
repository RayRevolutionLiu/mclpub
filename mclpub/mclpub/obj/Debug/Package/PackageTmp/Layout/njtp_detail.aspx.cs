using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class njtp_detail : System.Web.UI.Page
    {
        adpub_actupdate_DB myadpub = new adpub_actupdate_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid1();
            }
        }

        private void BindGrid1()
        {
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = myadpub.njtp_detailASPX();
            DataView dv1 = ds1.Tables[0].DefaultView;


            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr1 = "1=1";
            dv1.RowFilter = rowfilterstr1;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");


            if (dv1.Count > 0)
            {
                DataGrid1.Visible = true;

                DataGrid1.DataSource = dv1;
                DataGrid1.DataBind();
                this.lblMessage.Text = "新稿製法 總筆數：" + dv1.Count;
            }
            else
            {
                DataGrid1.Visible = false;
                this.lblMessage.Text = "(無任何資料!)";
            }
        }

        // 轉址處理
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("njtype.aspx");
        }

        

    }
}