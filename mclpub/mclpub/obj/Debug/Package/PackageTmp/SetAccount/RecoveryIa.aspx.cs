using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.SetAccount
{
    public partial class RecoveryIa : System.Web.UI.Page
    {
        RecoveryIa_DB myRe = new RecoveryIa_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataList_DataBind();
            }
        }

        private void DataList_DataBind()
        {
            DataSet ds1 = myRe.Selectia();
            DataView dv1 = ds1.Tables[0].DefaultView;

            dv1.RowFilter = "ia_syscd='C1' and ia_iasdate='' and ia_iasseq='' and ia_iaitem='' and (o_status = '3' OR o_status IS NULL)";
            //			dv1.RowFilter="ia_syscd='C1' and ia_iasdate='' and ia_iasseq='' and ia_iaitem='' and o_status='3'";
            DataList1.DataSource = dv1;
            DataList1.DataBind();
        }

        protected void btnCreateIa_Click(object sender, EventArgs e)
        {
            //string reg = User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\") + 1);
            string reg = Account.GetAccInfo().srspn_empno.ToString().Trim();
            string iano;
            int j = 0;
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                if (((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked == true)
                {

                    iano = ((Label)DataList1.Items[i].FindControl("lblNo")).Text.Trim();

                    myRe.UPDATEc1_delete_ia("C1", iano, "0", reg);
                    j++;
                }
            }
            if (j <= 0)
            {
                JavaScript.AlertMessage(this.Page, "您尚未選擇任何發票開立單");
                return;
            }
            else
            {
                DataList_DataBind();
            }
        }


        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                if (DataList1.Items.Count == 0)
                {
                    ((Panel)e.Item.FindControl("Panel_Noting")).Visible = true;
                }
            }
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //}
        }
    }
}