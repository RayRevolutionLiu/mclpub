using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.SetAccount
{
    public partial class CheckList3 : System.Web.UI.Page
    {
        CheckList3_DB myCheck = new CheckList3_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds1 = myCheck.Selectc1_Order();
                DataView dv1 = ds1.Tables[0].DefaultView;
                dv1.RowFilter = "ia_syscd='C1' and ia_iasdate='' and ia_iasseq='' and ia_iaitem='' and o_status='3'";
                PayDelGV.DataSource = dv1;
                PayDelGV.DataBind();
            }
        }
    }
}