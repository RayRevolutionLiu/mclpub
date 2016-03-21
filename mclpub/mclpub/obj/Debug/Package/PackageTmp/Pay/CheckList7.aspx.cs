using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Pay
{
    public partial class CheckList7 : System.Web.UI.Page
    {
        PayDelete_DB myPay = new PayDelete_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds1 = myPay.SelectCheckList7();
                DataView dv1 = ds1.Tables[0].DefaultView;
                dv1.RowFilter = "py_pysdate='' and py_pysseq='' and py_pysitem=''";
                PayDelGV.DataSource = dv1;
                PayDelGV.DataBind();
            }
        }
    }
}