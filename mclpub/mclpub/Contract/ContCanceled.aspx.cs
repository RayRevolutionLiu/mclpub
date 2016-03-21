using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Contract
{
    public partial class ContCanceled : System.Web.UI.Page
    {
        ContCanceled_DB myCont = new ContCanceled_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int DataCount = Bind_dgdCont();
                if (DataCount > 0)
                {
                    dgdCont.Visible = true;
                    lblContCanceled.Text = "目前共有 " + DataCount.ToString() + " 筆註銷合約";
                    lblContCanceled.Visible = true;
                    //pnlNoHistory.Visible = false;
                }
                else
                {
                    dgdCont.Visible = false;
                    lblContCanceled.Visible = false;
                    //pnlNoHistory.Visible = true;
                }
            }
        }


        #region 連結該客戶的合約資料
        private int Bind_dgdCont()
        {
            DataSet ds = myCont.GetContCanceled();
            DataView dv = ds.Tables[0].DefaultView;

            dgdCont.DataSource = dv;
            dgdCont.DataBind();

            return dv.Count;
        }
        #endregion


        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Button thislbtn = (Button)sender;
            GridViewRow row = ((Button)sender).Parent.Parent as GridViewRow;

            string contno = row.Cells[0].Text.Trim();
            bool success = myCont.UpdateContRecoverCanceled(contno);
            if (!success)
            {
                JavaScript.AlertMessage(this.Page, "取消合約註銷狀態失敗，請通知聯絡人");
                return;
            }

            int DataCount = Bind_dgdCont();

            if (DataCount > 0)
            {
                dgdCont.Visible = true;
                lblContCanceled.Text = "目前共有 " + DataCount.ToString() + " 筆註銷合約";
                lblContCanceled.Visible = true;
                //pnlNoHistory.Visible = false;
            }
            else
            {
                dgdCont.Visible = false;
                lblContCanceled.Visible = false;
                //pnlNoHistory.Visible = true;
            }
        }
    }
}
