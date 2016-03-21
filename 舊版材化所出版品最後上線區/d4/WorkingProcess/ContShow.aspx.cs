using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MRLPub.d4.Configurations;
using MRLPub.d4.DataTypes;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for ContShow.
	/// </summary>
	public class ContShow : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Label lblMfrNm;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblRespData;
		protected System.Web.UI.WebControls.Label lblMfrTelFax;
		protected System.Web.UI.WebControls.Label lblCustNm;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.Label lblDayCount;
		protected System.Web.UI.WebControls.Label lblUnPubTm;
		protected System.Web.UI.WebControls.Label lblUnImgTm;
		protected System.Web.UI.WebControls.Label lblUnUrlTm;
		protected System.Web.UI.WebControls.TextBox tbxHidMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxHidCustNo;
		protected System.Web.UI.WebControls.Label lblSignDate;
		protected System.Web.UI.WebControls.Label lblContTp;
		protected System.Web.UI.WebControls.Label lblSDate;
		protected System.Web.UI.WebControls.Label lblEDate;
		protected System.Web.UI.WebControls.Label lblEmpDate;
		protected System.Web.UI.WebControls.Label lblPayOnce;
		protected System.Web.UI.WebControls.Label lblRemark;
		protected System.Web.UI.WebControls.Label lblPubTm;
		protected System.Web.UI.WebControls.Label lblTotAmt;
		protected System.Web.UI.WebControls.Label lblFreeTm;
		protected System.Web.UI.WebControls.Label lblDisc;
		protected System.Web.UI.WebControls.Label lblTotImgTm;
		protected System.Web.UI.WebControls.Label lblTotUrlTm;
		protected System.Web.UI.WebControls.Label lblAuNm;
		protected System.Web.UI.WebControls.Label lblAuTel;
		protected System.Web.UI.WebControls.Label lblAuCell;
		protected System.Web.UI.WebControls.Label lblAuFax;
		protected System.Web.UI.WebControls.Label lblAuEmail;
		protected System.Web.UI.WebControls.TextBox tbxOldContNo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region 取得郵寄類別名稱
		protected object GetMtpNm(object mtpcd)
		{
			string strReturn = "";
			if(Session["MTP"]==null)
			{
				Mtps mtps = new Mtps();
				DataSet ds = mtps.GetMtps();
				DataView dv = ds.Tables[0].DefaultView;
				Session.Add("MTP", dv);
			}
			DataView mtpdv = (DataView)Session["MTP"];
			mtpdv.RowFilter = "mtp_mtpcd='" + mtpcd.ToString() + "'";
			if (mtpdv.Count>0)
			{
				strReturn = mtpdv[0]["ddl_text"].ToString().Trim();
			}
			mtpdv.RowFilter = "";

			return strReturn;
		}
		#endregion

		#region 載入合約資料
		private void LoadCont(string contno)
		{
			if (contno.Trim() == "")
			{
				throw new Exception("合約編號不可為空白");
			}
			
			Contracts cont = new Contracts();
			SqlDataReader dr = cont.GetSingleContractByContNo(contno);

			if (dr.Read())
			{
				lblContNo.Text = dr["cont_contno"].ToString().Trim();
				//廠商及客戶資料
				lblCustNm.Text = dr["cust_nm"].ToString().Trim();
				lblCustNo.Text = dr["cont_custno"].ToString().Trim();
				lblMfrNm.Text = dr["mfr_inm"].ToString().Trim();
				lblMfrNo.Text = dr["cont_mfrno"].ToString().Trim();
				lblMfrTelFax.Text = dr["mfr_tel"].ToString() + "(Fax：" + dr["mfr_fax"].ToString().Trim() + ")";
				lblRespData.Text = dr["mfr_respnm"].ToString() + "(" + dr["mfr_respjbti"].ToString().Trim() + ")";

				//合約書基本資料
				lblSignDate.Text = DateTime.ParseExact(dr["cont_signdate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");

				lblContTp.Text = (dr["cont_conttp"].ToString()=="01"?"一般":"推廣");

				lblSDate.Text = DateTime.ParseExact(dr["cont_sdate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
				lblEDate.Text = DateTime.ParseExact(dr["cont_edate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
				lblRemark.Text = dr["cont_remark"].ToString().Trim();
				lblContNo.Text = contno;

				lblEmpDate.Text = this.WhoAmI.CName;


				lblPayOnce.Text = (dr["cont_fgpayonce"].ToString()=="1"?"是":"否");

				//合約書細節
				lblPubTm.Text = dr["cont_pubtm"].ToString();
				lblFreeTm.Text = dr["cont_freetm"].ToString();
				lblTotImgTm.Text = dr["cont_totimgtm"].ToString();
				lblTotUrlTm.Text = dr["cont_toturltm"].ToString();
				lblTotAmt.Text = dr["cont_totamt"].ToString();
				lblDisc.Text = dr["cont_disc"].ToString();

				//廣告聯絡人資料
				lblAuNm.Text = dr["cont_aunm"].ToString().Trim();
				lblAuEmail.Text = dr["cont_auemail"].ToString().Trim();
				lblAuTel.Text = dr["cont_autel"].ToString().Trim();
				lblAuCell.Text = dr["cont_aucell"].ToString().Trim();
				lblAuFax.Text = dr["cont_aufax"].ToString().Trim();
			}
			else
			{
				jsAlertMsg("CONTNOTFOUND", "找不到合約"+contno+"的資料，請通知聯絡人");
			}
			dr.Close();
		}
		#endregion
	}
}
