using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.SetAccount
{
    public partial class DeleteIa : System.Web.UI.Page
    {
        DeleteIa_DB myDel = new DeleteIa_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataGrid1.Visible = false;
            btnDelete.Visible = false;

            if (tbxIano.Text.Trim() == "")
            {
                JavaScript.AlertMessage(this.Page, "請輸入發票號碼");
                SearchIcon.Visible = false;
                return;
            }
            else
            {
                DataSet ds1 = myDel.Selectia();
                DataView dv1 = ds1.Tables[0].DefaultView;
                dv1.RowFilter = "ia_invno='" + tbxIano.Text.Trim() + "'";
                if (dv1.Count <= 0)
                {
                    JavaScript.AlertMessage(this.Page, "查無此發票號碼");
                    SearchIcon.Visible = false;
                    return;
                }
                else
                {
                    if (dv1[0].Row["ia_pyno"].ToString().Trim() == "")
                    {
                        hiddenIano.Value = dv1[0].Row["ia_iano"].ToString().Trim();
                        DataGrid1.Visible = true;
                        DataGrid1.DataSource = dv1;
                        DataGrid1.DataBind();
                        btnDelete.Visible = true;
                        SearchIcon.Visible = true;
                    }
                    else
                    {
                        SearchIcon.Visible = false;
                        JavaScript.AlertMessage(this.Page, "此發票已繳款不允許刪除!!");
                        return;
                    }
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //string reg = User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\") + 1);
            string reg = Account.GetAccInfo().srspn_empno.ToString().Trim();
            RecoveryIa_DB myRe = new RecoveryIa_DB();
            myRe.UPDATEc1_delete_ia("C1", hiddenIano.Value.Trim(), "1", reg);
            DataGrid1.Visible = false;
            btnDelete.Visible = false;
            SearchIcon.Visible = false;
            tbxIano.Text = "";
            JavaScript.AlertMessage(this.Page, "刪除發票資料已完成");
        }
    }
}