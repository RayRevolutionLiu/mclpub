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
	/// Summary description for IA1ConfirmChecked.
	/// </summary>
	public class IA1ConfirmChecked : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Label lblContInfo;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.Label lblContTp;
		protected System.Web.UI.WebControls.Label lblSignDate;
		protected System.Web.UI.WebControls.Label lblSDate;
		protected System.Web.UI.WebControls.Label lblEDate;
		protected System.Web.UI.WebControls.Label lblPubTm;
		protected System.Web.UI.WebControls.Label lblFreeTm;
		protected System.Web.UI.WebControls.Label lblTotAmt;
		protected System.Web.UI.WebControls.Label lblDisc;
		protected System.Web.UI.WebControls.Label lblTotImgTm;
		protected System.Web.UI.WebControls.Label lblTotUrlTm;
		protected System.Web.UI.WebControls.DataGrid dgdSubAdr;
		protected System.Web.UI.WebControls.Label lblAdrInfo;
		protected System.Web.UI.WebControls.Panel pnlAdr;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblMfrno;
		protected System.Web.UI.WebControls.Label lblPyat;
		protected System.Web.UI.WebControls.Label lblNm;
		protected System.Web.UI.WebControls.Label lblAddr;
		protected System.Web.UI.WebControls.Label lblZip;
		protected System.Web.UI.WebControls.Label lblJbti;
		protected System.Web.UI.WebControls.Label lblTel;
		protected System.Web.UI.WebControls.Label lblInvcd;
		protected System.Web.UI.WebControls.Label lblTaxtp;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Label lblInvcd1;
		protected System.Web.UI.WebControls.Label lblTaxtp1;
		protected System.Web.UI.WebControls.Label lblFgitri;
		protected System.Web.UI.WebControls.Label lblFgitri1;
		protected System.Web.UI.WebControls.Button btnModifyAdr;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnContinue;
		protected System.Web.UI.WebControls.Button btnGoIA1;
		protected System.Web.UI.WebControls.Panel pnlNext;
		protected System.Web.UI.WebControls.Button btnExit;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Label lblProjNo;
		protected System.Web.UI.WebControls.Label lblCount;
		protected System.Web.UI.WebControls.Button btnConfirm;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				string contno = "";
				string imseq="";
				if (Request.QueryString["ContNo"] == null || Request.QueryString["ContNo"] == "")
				{
					throw new Exception("無合約編號，程式錯誤，請通知聯絡人");
				}
				else
				{
					contno = Request.QueryString["ContNo"].Trim();
					imseq = Request.QueryString["ImSeq"].Trim();
				}
				LoadContData(contno, imseq);
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
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			this.btnModifyAdr.Click += new System.EventHandler(this.btnModifyAdr_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
			this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
			this.btnGoIA1.Click += new System.EventHandler(this.btnGoIA1_Click);
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region 載入合約資料
		private void LoadContData(string contno, string imseq)
		{
			if (contno.Trim() == "")
				throw new Exception("合約編號不可為空白");

			Contracts cont;

			cont = new Contracts();
			SqlDataReader dr = cont.GetSingleContractByContNo(contno);
			if (dr.Read())
			{
				lblContNo.Text = dr["cont_contno"].ToString();

				switch(dr["cont_conttp"].ToString().Trim())
				{
					case "01":
						lblContTp.Text = "一般";
						break;
					case "09":
						lblContTp.Text = "推廣";
						break;
					default:
						lblContTp.Text = "(無法辨識)";
						break;
				}

				lblSignDate.Text = DateTime.ParseExact(dr["cont_signdate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
				lblSDate.Text = DateTime.ParseExact(dr["cont_sdate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
				lblEDate.Text = DateTime.ParseExact(dr["cont_edate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
				lblPubTm.Text = dr["cont_pubtm"].ToString();
				lblFreeTm.Text = dr["cont_freetm"].ToString();
				lblTotAmt.Text = dr["cont_totamt"].ToString();
				lblDisc.Text = dr["cont_disc"].ToString();
				lblTotImgTm.Text = dr["cont_totimgtm"].ToString();
				lblTotUrlTm.Text = dr["cont_toturltm"].ToString();

				//Message
				lblContInfo.Text = "本合約基本資料";

				//Load InvMfr
//				Bind_ddlInvMfr(contno);

				//Load Advertisements
				LoadAdr(contno, imseq);
			}
			else
			{
				//Message
				lblContInfo.Text = "無此編號的合約資料，請確認合約編號";
			}
			dr.Close();
		}
		#endregion

		#region 載入發票主檔及明細資料
		private void LoadAdr(string contno, string imseq)
		{
			if (contno == null || contno.Trim().Length != 6)
			{
				jsAlertMsg("CONTNODATAERROR", "合約編號為空值或格式錯誤，請通知聯絡人");
				return;
			}
			InvMfrs im = new InvMfrs();
			DataSet ds1 = im.GetInvMfr(contno);
			DataView dv1 = ds1.Tables[0].DefaultView;
			dv1.RowFilter="im_imseq='"+imseq+"'";//只有指定發票廠商的資料會出現
			lblMfrno.Text = dv1[0].Row["im_mfrno"].ToString();
			lblNm.Text = dv1[0].Row["im_nm"].ToString();
			lblAddr.Text = dv1[0].Row["im_addr"].ToString();
			lblZip.Text = dv1[0].Row["im_zip"].ToString();
			lblJbti.Text = dv1[0].Row["im_jbti"].ToString();
			lblTel.Text = dv1[0].Row["im_tel"].ToString();
			lblInvcd1.Text = dv1[0].Row["im_invcd"].ToString();
			lblInvcd.Text = dv1[0].Row["invcd"].ToString();
			lblTaxtp1.Text = dv1[0].Row["im_taxtp"].ToString();
			lblTaxtp.Text = dv1[0].Row["taxtp"].ToString();
			lblFgitri1.Text = dv1[0].Row["im_fgitri"].ToString();
			lblProjNo.Text = dv1[0].Row["proj_projno"].ToString();
			switch(lblFgitri1.Text.Trim())
			{
				case "06":
					lblFgitri.Text = "所內";
					break;
				case "07":
					lblFgitri.Text = "院內";
					break;
				case "":
					lblFgitri.Text = "";
					break;
			}

			Advertisements adr = new Advertisements();
			DataSet ds = adr.GetAdvertisements(contno);
			DataView dv = ds.Tables[0].DefaultView;
			dv.RowFilter="adr_fginved='v' and adr_imseq='"+imseq+"'";
			dgdSubAdr.DataSource = dv;
			dgdSubAdr.DataBind();
			lblCount.Text = "<<共 "+dv.Count.ToString()+" 筆明細資料>>";
			int	pyat=0;
			for(int i=0; i<dgdSubAdr.Items.Count; i++)
			{
				pyat += Convert.ToInt32(dgdSubAdr.Items[i].Cells[10].Text);
			}
			lblPyat.Text = pyat.ToString();

		}
		#endregion

		#region 格式化廣告資料
		protected object MatchAdCate(object adcate)
		{
			string transAdCate = "";
			switch(adcate.ToString())
			{
				case "M":
					transAdCate = "首頁";
					break;
				case "I":
					transAdCate = "內頁";
					break;
				case "N":
					transAdCate = "奈米";
					break;
				default:
					throw new Exception("資料庫原生廣告頁面資料錯誤，請通知聯絡人");
					break;
			}
			return transAdCate;
		}

		protected object MatchKeyword(object keyword)
		{
			string transKeyword = "";
			switch(keyword.ToString())
			{
				case "h0":
					transKeyword = "正中";
					break;
				case "h1":
					transKeyword = "右一";
					break;
				case "h2":
					transKeyword = "右二";
					break;
				case "h3":
					transKeyword = "右三";
					break;
				case "h4":
					transKeyword = "右四";
					break;
				case "w1":
					transKeyword = "右文一";
					break;
				case "w2":
					transKeyword = "右文二";
					break;
				case "w3":
					transKeyword = "右文三";
					break;
				case "w4":
					transKeyword = "右文四";
					break;
				case "w5":
					transKeyword = "右文五";
					break;
				case "w6":
					transKeyword = "右文六";
					break;
				default:
					throw new Exception("資料庫原生廣告位置資料錯誤，請通知聯絡人");
					break;
			}
			return transKeyword;
		}

//		protected object MatchImSeq(object imseq)
//		{
//			string transImSeq = "";
//			try
//			{
//				transImSeq = ddlInvMfr.Items.FindByValue(imseq.ToString()).Text;
//			}
//			catch
//			{
//				throw new Exception("資料庫原生發票廠商資料錯誤，請通知聯絡人");
//			}
//			return transImSeq;
//		}

		private void FormatAdr()
		{
			for (int i=0; i<dgdSubAdr.Items.Count; i++)
			{

				//檢查日期
//				if (DateTime.Today >= DateTime.ParseExact(dgdSubAdr.Items[i].Cells[3].Text.Trim(), "yyyyMMdd", null))
//				{
					((CheckBox)dgdSubAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked = false;
					((CheckBox)dgdSubAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Enabled = false;
//				}


				//廣告日期：轉換為yyyy/MM/dd
				dgdSubAdr.Items[i].Cells[3].Text = DateTime.ParseExact(dgdSubAdr.Items[i].Cells[3].Text.Trim(), "yyyyMMdd", null).ToString("yyyy/MM/dd");

				
			}
		}
		#endregion

		#region 產生ia、iad
		private void btnConfirm_Click(object sender, System.EventArgs e)
		{
			//條件應為合約編號與fginved='v'
			string contno, imseq;
			contno = Request.QueryString["ContNo"].Trim();
			imseq = Request.QueryString["ImSeq"].Trim();
			Invoice inv = new Invoice();
			bool errorflg = inv.AddIa(contno, imseq, this.WhoAmI.EmpNo);
			if(errorflg){
				jsAlertMsg("INVALIDPERIOD", "新增發票開立單作業完成!!");
				pnlAdr.Visible=false;
				pnlNext.Visible=true;
			}
			else
				jsAlertMsg("INVALIDPERIOD", "新增發票開立單作業發生錯誤, 請重新新增或稍後再進行");
		}
		#endregion

		#region 取消, 將選取註記清除, 回首頁
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Advertisements adr = new Advertisements();
			for(int i=0; i<dgdSubAdr.Items.Count; i++)
			{
				adr.UpdateAdrFginved(lblContNo.Text.Trim(), dgdSubAdr.Items[i].Cells[0].Text.Trim(), dgdSubAdr.Items[i].Cells[1].Text.Trim(), "");
			}
			Response.Redirect("content.htm");
		}
		#endregion

		#region 前往落版畫面, 修改落版資料, 不清除選取註記
		private void btnModifyAdr_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AdrPublish.aspx?NewContNo="+lblContNo.Text.Trim());
		}
		#endregion

		#region 繼續發票開立作業(同合約)
		private void btnContinue_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("IA1QueryCont.aspx?ContNo="+Request.QueryString["ContNo"].Trim()+"&ImSeq=00");
		}
		#endregion

		#region 繼續發票開立作業(不同合約)
		private void btnGoIA1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("IA1Query.aspx");		
		}
		#endregion

		#region 取消, 回首頁
		private void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("content.htm");
		}
		#endregion

		#region 列印預覽清單
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			string contno, imseq;
			contno = Request.QueryString["ContNo"].Trim();
			imseq = Request.QueryString["ImSeq"].Trim();
			Invoice inv = new Invoice();
			inv.IA1PreList(contno, imseq);
			string	strbuf="RptIA1_PreList.aspx?whoami=" + this.WhoAmI.CName;
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}
		#endregion

		private void btnBack_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			string contno, imseq;
			contno = Request.QueryString["ContNo"].Trim();
			imseq = Request.QueryString["ImSeq"].Trim();
			Response.Redirect("IA1QueryCont.aspx?ContNo="+contno.Trim()+"&ImSeq="+imseq.Trim());
		}

	}
}
