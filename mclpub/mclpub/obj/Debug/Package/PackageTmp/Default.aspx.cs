using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace mclpub
{
    public partial class _Default : System.Web.UI.Page
    {
        Default_DB myDefault = new Default_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
            }
        }

        public void BindGrid()
        {
            string STRtbxCompany = tbxCompany.Text.Trim();
            string STRtbxcontno = tbxcontno.Text.Trim();
            string STRtbxCname = tbxCname.Text.Trim();

            DataSet ds = myDefault.SelectindexSp_Inquiry(STRtbxCompany, STRtbxcontno, STRtbxCname);
            GVDefault.DataSource = ds;
            GVDefault.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string STRtbxCompany = tbxCompany.Text.Trim();
            string STRtbxcontno = tbxcontno.Text.Trim();
            string STRtbxCname = tbxCname.Text.Trim();
            if (STRtbxCompany == "" && STRtbxcontno == "" && STRtbxCname == "")
            {
                JavaScript.AlertMessage(this.Page, "請輸入查詢條件");
                return;
            }
            SearchIcon.Visible = true;
            BindGrid();
        }
    }
}
