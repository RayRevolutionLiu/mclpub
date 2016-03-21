using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Contract
{
    public partial class mfr_detail : System.Web.UI.Page
    {
        PlaneCont_DB myPlane = new PlaneCont_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Context.Request.QueryString["mfrno"].ToString().Trim() != "")
                {
                    string mfrno = "";
                    mfrno = Context.Request.QueryString["mfrno"].ToString().Trim();

                    CheckExist();

                }
                else
                {
                    Response.Write("<font size=2 color=red><b>資料庫中無此 廠商統編及其資料, 請先<A HREF='../Subscriber/AddComp.aspx' Target='_blank' OnClick='window.close()'>新增此廠商</A>!</b></font><br><br>");
                }
            }
        }

        private void CheckExist()
        {
            // 藉由前一網頁傳來的變數值字串 custno
            string mfrno = Context.Request.QueryString["mfrno"].ToString().Trim();
            //Response.Write("mfrno= " + mfrno + "<br>");

            DataTable dt = myPlane.Checkmfrno(mfrno);

            // 若有資料, 則顯示相關資料; 否則給予錯誤訊息
            if (dt.Rows.Count <= 0)
            {
                Response.Write("<font size=2 color=red><b>資料庫中無此 廠商統編及其資料, 請先<A HREF='../Subscriber/AddComp.aspx' Target='_blank' OnClick='window.close()'>新增此廠商</A>!</b></font><br><br>");
            }
            else
            {
                // 若有此 廠商統編, 則顯示其相關資料
                GetData();
            }

        }

        private void GetData()
        {
            // 抓前一步驟來的 mfrno 變數值
            string mfrno = Context.Request.QueryString["mfrno"].ToString().Trim();
            //Response.Write("mfrno= " + mfrno + "<br>");

            DataTable dt = myPlane.Checkmfrno(mfrno);


            // 若有資料, 則顯示相關資料; 否則給予錯誤訊息
            if (dt.Rows.Count > 0)
            {

                // 填入資料
                this.lblMfrID.Text = dt.Rows[0]["mfr_mfrid"].ToString();
                this.lblMfrIName.Text = dt.Rows[0]["mfr_inm"].ToString();
                this.lblMfrNo.Text = dt.Rows[0]["mfr_mfrno"].ToString();

                string RegDate = dt.Rows[0]["mfr_regdate"].ToString();
                this.lblMfrRegDate.Text = RegDate.Substring(0, 4) + "/" + RegDate.Substring(4, 2) + "/" + RegDate.Substring(6, 2);

                this.lblMfrRespName.Text = dt.Rows[0]["mfr_respnm"].ToString();
                this.lblMfrRespJobTitle.Text = dt.Rows[0]["mfr_respjbti"].ToString();
                this.lblMfrTel.Text = dt.Rows[0]["mfr_tel"].ToString();
                this.lblMfrFax.Text = dt.Rows[0]["mfr_fax"].ToString();
                this.lblMfrIZipcode.Text = dt.Rows[0]["mfr_izip"].ToString();
                this.lblMfrIAddr.Text = dt.Rows[0]["mfr_iaddr"].ToString();
            }
            else
            {
                // 若找無資料, 則清除資料
                this.lblMfrIName.Text = "(<font color='RED'>查無此廠商統編, 請先<A HREF='../Subscriber/AddComp.aspx' Target='_blank' OnClick='window.close()'>新增此廠商</A>!</font>)";
                this.lblMfrNo.Text = "";
                this.lblMfrRespName.Text = "";
                this.lblMfrRespJobTitle.Text = "";
                this.lblMfrTel.Text = "";
                this.lblMfrFax.Text = "";
                this.lblMfrIZipcode.Text = "";
                this.lblMfrIAddr.Text = "";
                this.lblMfrRegDate.Text = "";
            }

        }
    }
}
