using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Contract
{
    public partial class ContShow : System.Web.UI.Page
    {
        ContShow_DB myCont = new ContShow_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string contno = "";
                if (Request.QueryString["ContNo"] == null || Request.QueryString["ContNo"] == "")
                {
                    throw new Exception("找不到合約編號");
                }
                else
                {
                    contno = Request.QueryString["ContNo"];
                }

                LoadCont(contno);
            }
        }

        #region 載入合約資料
        private void LoadCont(string contno)
        {
            if (contno.Trim() == "")
            {
                throw new Exception("合約編號不可為空白");
            }

            DataSet ds = myCont.GetSingleContractByContNo(contno);

            if (ds.Tables[0].Rows.Count>0)
            {
                lblContNo.Text = ds.Tables[0].Rows[0]["cont_contno"].ToString().Trim();
                //廠商及客戶資料
                lblCustNm.Text = ds.Tables[0].Rows[0]["cust_nm"].ToString().Trim();
                lblCustNo.Text = ds.Tables[0].Rows[0]["cont_custno"].ToString().Trim();
                lblMfrNm.Text = ds.Tables[0].Rows[0]["mfr_inm"].ToString().Trim();
                lblMfrNo.Text = ds.Tables[0].Rows[0]["cont_mfrno"].ToString().Trim();
                lblMfrTelFax.Text = ds.Tables[0].Rows[0]["mfr_tel"].ToString() + "(Fax：" + ds.Tables[0].Rows[0]["mfr_fax"].ToString().Trim() + ")";
                lblRespData.Text = ds.Tables[0].Rows[0]["mfr_respnm"].ToString() + "(" + ds.Tables[0].Rows[0]["mfr_respjbti"].ToString().Trim() + ")";

                //合約書基本資料
                lblSignDate.Text = DateTime.ParseExact(ds.Tables[0].Rows[0]["cont_signdate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");

                lblContTp.Text = (ds.Tables[0].Rows[0]["cont_conttp"].ToString() == "01" ? "一般" : "推廣");

                lblSDate.Text = DateTime.ParseExact(ds.Tables[0].Rows[0]["cont_sdate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
                lblEDate.Text = DateTime.ParseExact(ds.Tables[0].Rows[0]["cont_edate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
                lblRemark.Text = ds.Tables[0].Rows[0]["cont_remark"].ToString().Trim();
                lblContNo.Text = contno;

                lblEmpDate.Text = myCont.SelectSrspnCname(ds.Tables[0].Rows[0]["cont_empno"].ToString().Trim());


                lblPayOnce.Text = (ds.Tables[0].Rows[0]["cont_fgpayonce"].ToString() == "1" ? "是" : "否");

                //合約書細節
                lblPubTm.Text = ds.Tables[0].Rows[0]["cont_pubtm"].ToString();
                lblFreeTm.Text = ds.Tables[0].Rows[0]["cont_freetm"].ToString();
                lblTotImgTm.Text = ds.Tables[0].Rows[0]["cont_totimgtm"].ToString();
                lblTotUrlTm.Text = ds.Tables[0].Rows[0]["cont_toturltm"].ToString();
                lblTotAmt.Text = ds.Tables[0].Rows[0]["cont_totamt"].ToString();
                lblDisc.Text = ds.Tables[0].Rows[0]["cont_disc"].ToString();

                //廣告聯絡人資料
                lblAuNm.Text = ds.Tables[0].Rows[0]["cont_aunm"].ToString().Trim();
                lblAuEmail.Text = ds.Tables[0].Rows[0]["cont_auemail"].ToString().Trim();
                lblAuTel.Text = ds.Tables[0].Rows[0]["cont_autel"].ToString().Trim();
                lblAuCell.Text = ds.Tables[0].Rows[0]["cont_aucell"].ToString().Trim();
                lblAuFax.Text = ds.Tables[0].Rows[0]["cont_aufax"].ToString().Trim();
            }
            else
            {
                JavaScript.AlertMessageClose(this.Page,"找不到合約" + contno + "的資料，請通知聯絡人");
                return;
            }
        }
        #endregion
    }
}