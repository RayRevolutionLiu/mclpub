using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.LabelArea
{
    public partial class lost_label : System.Web.UI.Page
    {
        lost_label_DB mylost = new lost_label_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds1 = mylost.Selectc1_lost();
                DataView dv1 = ds1.Tables["c1_lost"].DefaultView;
                if (Context.Request.QueryString["mosea"] == "0")
                {
                    DataList1.DataSource = dv1;
                    DataList1.DataBind();
                }
                else
                {
                    DataList2.DataSource = dv1;
                    DataList2.DataBind();
                }
            }
        }
    }
}