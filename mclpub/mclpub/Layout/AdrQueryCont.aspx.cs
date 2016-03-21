using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class AdrQueryCont : System.Web.UI.Page
    {
        AdrQueryCont_DB myAdr = new AdrQueryCont_DB();
        security sec = new security();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.UCPager1.Ctrl_GV = "dgdCont";
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                dgdCont.Visible = false;
                UCPager1.Visible = false;

            }
        }

        protected void dgdCont_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;

                switch (e.Row.Cells[9].Text.Trim())
                {
                    case "01":
                        e.Row.Cells[9].Text = "一般";
                        break;
                    case "09":
                        e.Row.Cells[9].Text = "推廣";
                        break;
                    default:
                        e.Row.Cells[9].Text = "(無法辨識)";
                        break;
                }
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }
        }

        protected void lngGoThis_Click(object sender, EventArgs e)
        {
            string contno = tbxContNo.Text.Trim();
            DataSet ds = myAdr.GetSingleContractByContNo(contno);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Response.Redirect("AdrPublish.aspx?NewContNo=" + sec.encryptquerystring(contno));
            }
            else
            {
                JavaScript.AlertMessage(this.Page, "找不到合約" + contno + "的資料，請檢查合約編號是否正確或通知聯絡人");
                return;
            }
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            Bind_dgdCont();
        }

        private void Bind_dgdCont()
        {
            SearchIcon.Visible = true;
            dgdCont.Visible = true;
            DataSet ds = myAdr.GetAllFormalContracts();
            DataView dv = ds.Tables[0].DefaultView;
            dv.Sort = "cont_contno DESC";

            string strFilter = GetFilters();

            //Response.Write(strFilter);
            if (strFilter.Trim() != "")
            {
                dv.RowFilter = strFilter;
            }

            UCPager1.Dtdata = dv.ToTable();
            UCPager1.UCPageBind();

            //Response.Write(dv.Count);

            if (dv.Count > 0)
            {
                UCPager1.Visible = true;
            }

        }



        #region 組合查詢條件
        /// <summary>
        /// 組合查詢條件
        /// </summary>
        /// <returns>組合後的條件字串</returns>
        private string GetFilters()
        {
            int fc = 0;
            string strFilter = " ";

            //廠商名稱
            if (tbxMfrNm.Text.Trim() != "")
            {
                strFilter += "mfr_inm LIKE '%" + tbxMfrNm.Text.Trim() + "%'";
                fc++;
            }

            //統一編號
            if (tbxMfrNo.Text.Trim() != "")
            {
                if (fc > 0) strFilter += " AND ";
                strFilter += "mfr_mfrno LIKE '%" + tbxMfrNo.Text.Trim() + "%'";
                fc++;
            }

            //客戶編號
            if (tbxCustNo.Text.Trim() != "")
            {
                if (fc > 0) strFilter += " AND ";
                strFilter += "cust_custno LIKE '%" + tbxCustNo.Text.Trim() + "%'";
                fc++;
            }

            //客戶姓名
            if (tbxCustNm.Text.Trim() != "")
            {
                if (fc > 0) strFilter += " AND ";
                strFilter += "cust_nm LIKE '%" + tbxCustNm.Text.Trim() + "%'";
                fc++;
            }

            return strFilter;
        }
        #endregion

        protected void PushButton_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string NewContNo = thisRow.Cells[0].Text.Trim();
            Response.Redirect("AdrPublish.aspx?NewContNo=" + sec.encryptquerystring(NewContNo));
        }
    }
}