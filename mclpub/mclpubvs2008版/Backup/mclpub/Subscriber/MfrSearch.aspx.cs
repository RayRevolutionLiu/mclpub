using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Subscriber
{
    public partial class MfrSearch : System.Web.UI.Page
    {
        MfrSearch_DB myMfr = new MfrSearch_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "GridView1";

            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            string mfrno = Request.QueryString["mfrno"].ToString();
            string company = Request.QueryString["company"].ToString();

            DataTable dt = myMfr.SelectComp(mfrno, company);
            this.UCPager1.Dtdata = dt;
            this.UCPager1.UCPageBind();
        }

        protected void GVSelect(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((LinkButton)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string mfr_mfrno = thisRow.Cells[1].Text;//統一編號
            string mfr_inm = thisRow.Cells[2].Text;//公司名稱
            string mfrnoID = Request.QueryString["mfrnoID"].ToString();
            string companyID = Request.QueryString["companyID"].ToString();
            this.Page.Controls.Add(new LiteralControl("<script>window.opener.document.getElementById(\"" + mfrnoID + "\").value = \"" + mfr_mfrno.Trim() + "\";window.opener.document.getElementById(\"" + companyID + "\").value = \"" + mfr_inm.Trim() + "\";window.close();</script>"));
        }
    }
}
