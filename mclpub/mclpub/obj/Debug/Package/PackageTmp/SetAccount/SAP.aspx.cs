using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.SetAccount
{
    public partial class SAP : System.Web.UI.Page
    {
        SAP_DB mySAP = new SAP_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Account.GetAccInfo().srspn_atype.ToString().Trim() != "A" && Account.GetAccInfo().srspn_atype.ToString().Trim() != "F")
                {
                    JavaScript.AlertMessageRedirect(this.Page, "很抱歉!!您沒有權限使用此系統","../Default.aspx");
                }

                DataSet ds = mySAP.Selectias();
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();
            }
        }

        protected void GVEdit_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null)//如果第一次點選排序的話，預設就是「升」
            {
                ViewState["SortDirection"] = " DESC";
            }
            //判斷如果已經對某欄位排序過，再判斷是否針對同個欄位排序
            if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
            {
                //如果針對同個欄位排序，則進行「升」「降」的切換
                if (ViewState["SortDirection"].ToString() == " DESC")
                {
                    ViewState["SortDirection"] = " ASC";
                }
                else
                {
                    ViewState["SortDirection"] = " DESC";
                }

            }
            else
            {
                //第一次對某欄位排序，就是「升」
                ViewState["SortDirection"] = " DESC";
            }

            for (int i = 0; i <= ((GridView)sender).Columns.Count - 1; i++)
            {
                ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText.Replace("▲", "");
                ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText.Replace("▼", "");
            }
            int Columns_i = 0;
            for (int i = 0; i <= ((GridView)sender).Columns.Count - 1; i++)
            {
                if (e.SortExpression == ((GridView)sender).Columns[i].SortExpression)
                {
                    Columns_i = i;
                    if (ViewState["SortDirection"].ToString() == " ASC")
                    {
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText + "▲";
                    }
                    else
                    {
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText + "▼";
                    }
                }
            }

            ViewState["SortExpression"] = e.SortExpression;//指定欄位名稱

            DataSet ds = mySAP.Selectias();
            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortDirection"].ToString();
            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string reg = Account.GetAccInfo().srspn_empno.ToString().Trim();
            string STRyyyymm = lblyyyymm.Value.ToString().Trim();
            string STRbatch = lblbatch.Value.ToString().Trim();

            try
            {
                mySAP.EXEC_sap01(STRyyyymm, STRbatch, reg);
            }
            catch (Exception ex)
            {
                throw new Exception("SAP01:" + ex.Message);
            }

            try
            {
                mySAP.EXEC_sap02(STRyyyymm, STRbatch);
            }
            catch (Exception ex)
            {
                throw new Exception("SAP02:" + ex.Message);
            }

            try
            {
                mySAP.EXEC_sap03(STRyyyymm, STRbatch);

            }
            catch (Exception ex)
            {

                throw new Exception("SAP03:" + ex.Message);
            }

            JavaScript.AlertMessage(this.Page, "SAP轉檔成功");

            DataSet ds = mySAP.Selectias();
            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
        }
    }
}