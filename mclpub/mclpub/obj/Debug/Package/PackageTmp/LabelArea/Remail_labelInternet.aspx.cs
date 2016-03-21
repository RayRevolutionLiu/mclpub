using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.LabelArea
{
    public partial class Remail_labelInternet : System.Web.UI.Page
    {
        RmLabelFilterInternet_DB myRm = new RmLabelFilterInternet_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = myRm.GetRemailLabel();
                DataView dv = ds.Tables[0].DefaultView;
                dv.RowFilter = "or_fgmosea='" + Context.Request.QueryString["mosea"] + "'";
                if (Context.Request.QueryString["mosea"] == "0")
                {
                    DataList1.DataSource = dv;
                    DataList1.DataBind();
                }
                else
                {
                    DataList2.DataSource = dv;
                    DataList2.DataBind();
                }
            }
        }
    }
}