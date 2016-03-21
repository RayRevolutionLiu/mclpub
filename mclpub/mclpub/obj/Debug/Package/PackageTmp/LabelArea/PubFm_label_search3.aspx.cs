using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.LabelArea
{
    public partial class PubFm_label_search3 : System.Web.UI.Page
    {
        PubFm_label_search_DB myPub = new PubFm_label_search_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Account.GetAccInfo().srspn_atype.ToString().Trim() == "A" || Account.GetAccInfo().srspn_atype.ToString().Trim() == "F")
            //{
            //    JavaScript.AlertMessageRedirect(this.Page, "您身分不合,不允許進入!", "../Default.aspx");
            //    return;
            //}

            if (!IsPostBack)
            {
                DataSet ds1 = myPub.SelectBook();
                DataView dv1 = ds1.Tables["book"].DefaultView;
                ddlBookCode.DataSource = dv1;
                dv1.RowFilter = "proj_fgitri=''";
                ddlBookCode.DataTextField = "bk_nm";
                //ddlBookCode.DataValueField="nostr";
                // 同維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
                ddlBookCode.DataValueField = "bk_bkcd";
                ddlBookCode.DataBind();

                SearchIcon.Visible = false;
                GVSearchLabel.Visible = false;

                this.tbxPubDate.Text = System.DateTime.Today.ToString("yyyy/MM");
                this.tbxPrintDate.Text = System.DateTime.Today.ToString("yyyy/MM");
            }
        }

        protected void GVSearchLabel_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[2].Text.Trim() != "")
                {
                    e.Row.Cells[2].Text = e.Row.Cells[2].Text.Substring(0, 4) + "/" + e.Row.Cells[2].Text.Substring(4, 2);
                }
                if (e.Row.Cells[3].Text.Trim() != "")
                {
                    e.Row.Cells[3].Text = e.Row.Cells[3].Text.Substring(0, 4) + "/" + e.Row.Cells[3].Text.Substring(4, 2);
                }
            }
        }

        public DataSet bind()
        {
            string strBkcd = ddlBookCode.SelectedItem.Value.ToString();
            string strYYYYMM = tbxPubDate.Text.ToString().Trim() == "" ? "" : tbxPubDate.Text.ToString().Substring(0, 4) + tbxPubDate.Text.ToString().Substring(5, 2);
            string strConttp = ddlConttp.SelectedItem.Value.ToString();
            //string empno = Account.GetAccInfo().srspn_empno.ToString().Trim();

            DataSet ds = myPub.SelectC2_cont3(strBkcd, strConttp, strYYYYMM);

            return ds;
        }


        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;
            GVSearchLabel.Visible = true;

            if (bind().Tables[0].Rows.Count > 0)
            {
                btnSave.Visible = true;
                lblMessage.Text = "查詢結果: 找到" + bind().Tables[0].Rows.Count + "筆雜誌收件人資料!";
            }
            else
            {
                btnSave.Visible = false;
                lblMessage.Visible = false;
            }
            GVSearchLabel.DataSource = bind();
            GVSearchLabel.DataBind();


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int i;
            bool chk = false;
            string printdate = tbxPrintDate.Text.Trim();
            for (i = 0; i < this.GVSearchLabel.Rows.Count; i++)
            {
                if (((CheckBox)GVSearchLabel.Rows[i].FindControl("CheckBox2")).Checked)
                {
                    chk = true;
                    string contno = GVSearchLabel.Rows[i].Cells[1].Text;
                    string sdate = GVSearchLabel.Rows[i].Cells[2].Text;
                    string edate = GVSearchLabel.Rows[i].Cells[3].Text;
                    string oritem = GVSearchLabel.Rows[i].Cells[5].Text;
                    string empno = Account.GetAccInfo().srspn_empno.ToString().Trim();
                    //string yyyymm = GVSearchLabel.Rows[i].Cells[13].Text;
                    myPub.InsertC2_cont3(contno, sdate, edate, oritem, printdate, empno);
                }
            }

            if (chk == true)
            {
                JavaScript.AlertMessage(this.Page, string.Format("已儲存!"));
                GVSearchLabel.DataSource = bind();
                GVSearchLabel.DataBind();
                lblMessage.Text = "查詢結果: 找到" + bind().Tables[0].Rows.Count + "筆雜誌收件人資料!";
            }
            else
            {
                JavaScript.AlertMessage(this.Page, string.Format("請勾選需要儲存的資料"));
            }
        }
    }
}