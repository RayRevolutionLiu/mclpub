using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Order
{
    public partial class SetRecForm : System.Web.UI.Page
    {
        SetRecForm_DB mySet = new SetRecForm_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Expires = 0;
                DataSet ds = mySet.SelectMtp();
                ddlSendType.DataSource = ds;
                ddlSendType.DataTextField = "mtp_nm";
                ddlSendType.DataValueField = "mtp_mtpcd";
                ddlSendType.DataBind();
            }
        }
    }
}
