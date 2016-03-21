using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace mclpub.LabelArea
{
    public partial class PubFm_label_search3Print : System.Web.UI.Page
    {
        PubFm_label_search_DB myPub = new PubFm_label_search_DB();
        security sec = new security();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbxPubDate.Text = DateTime.Now.ToString("yyyy/MM");
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
                btnPrintLabel.Visible = false;

                //this.tbxPubDate.Text = System.DateTime.Today.ToString("yyyy/MM");
            }
        }

        public DataSet bind()
        {
            string bkcd = ddlBookCode.SelectedItem.Value.ToString();
            string fgMOSea = ddlfgMOSea.SelectedItem.Value.ToString();
            string empno = tbxempno.Text.Trim();
            string strYYYYMM = tbxPubDate.Text.ToString().Trim() == "" ? "" : tbxPubDate.Text.ToString().Substring(0, 4) + tbxPubDate.Text.ToString().Substring(5, 2);

            DataSet ds = myPub.SelectC2_cont3print(bkcd, fgMOSea, strYYYYMM, empno);//strYYYYMM

            return ds;
        }


        protected void GVSearchLabel_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[1].Text.Trim() != "")
                {
                    e.Row.Cells[1].Text = e.Row.Cells[1].Text.Substring(0, 4) + "/" + e.Row.Cells[1].Text.Substring(4, 2);
                }
                if (e.Row.Cells[2].Text.Trim() != "")
                {
                    e.Row.Cells[2].Text = e.Row.Cells[2].Text.Substring(0, 4) + "/" + e.Row.Cells[2].Text.Substring(4, 2);
                }
            }
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            if (tbxPubDate.Text.IndexOf("/") != -1 && tbxPubDate.Text.IndexOf("/") == 4)
            {
                SearchIcon.Visible = true;
                GVSearchLabel.Visible = true;

                if (bind().Tables[0].Rows.Count > 0)
                {
                    btnPrintLabel.Visible = true;
                }
                else
                {
                    btnPrintLabel.Visible = false;
                }
                GVSearchLabel.DataSource = bind();
                GVSearchLabel.DataBind();
            }
            else
            {
                JavaScript.AlertMessage(this.Page, "日期格式錯誤");
            }
        }

        protected void btnPrintLabel_Click(object sender, EventArgs e)
        {
            string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
            string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
            strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            string fgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();
            string empno = tbxempno.Text.Trim();

            // 轉址
            string strbuf;
            strbuf = "PubFm_label3print.aspx?bkcd=" + sec.encryptquerystring(strBkcd) + "&fgmosea=" + sec.encryptquerystring(fgMOSea) + "&yyyymm=" + sec.encryptquerystring(strYYYYMM) + "&empno=" + sec.encryptquerystring(empno);

            this.ClientScript.RegisterStartupScript(typeof(string), "", "<script>window.open(\"" + strbuf + "\");</script>");
        }
    }
}