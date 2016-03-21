using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.SetAccount
{
    public partial class GetInvno : System.Web.UI.Page
    {
        SAP_DB mySAP = new SAP_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnGetInvno_Click(object sender, EventArgs e)
        {
            try
            {
                mySAP.EXEC_sp_from_sap_001();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                JavaScript.AlertMessage(this.Page, "發票號碼取回成功");
            }
        }
    }
}