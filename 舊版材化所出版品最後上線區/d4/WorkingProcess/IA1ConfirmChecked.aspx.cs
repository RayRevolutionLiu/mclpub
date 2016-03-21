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
					throw new Exception("�L�X���s���A�{�����~�A�гq���p���H");
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

		#region ���J�X�����
		private void LoadContData(string contno, string imseq)
		{
			if (contno.Trim() == "")
				throw new Exception("�X���s�����i���ť�");

			Contracts cont;

			cont = new Contracts();
			SqlDataReader dr = cont.GetSingleContractByContNo(contno);
			if (dr.Read())
			{
				lblContNo.Text = dr["cont_contno"].ToString();

				switch(dr["cont_conttp"].ToString().Trim())
				{
					case "01":
						lblContTp.Text = "�@��";
						break;
					case "09":
						lblContTp.Text = "���s";
						break;
					default:
						lblContTp.Text = "(�L�k����)";
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
				lblContInfo.Text = "���X���򥻸��";

				//Load InvMfr
//				Bind_ddlInvMfr(contno);

				//Load Advertisements
				LoadAdr(contno, imseq);
			}
			else
			{
				//Message
				lblContInfo.Text = "�L���s�����X����ơA�нT�{�X���s��";
			}
			dr.Close();
		}
		#endregion

		#region ���J�o���D�ɤΩ��Ӹ��
		private void LoadAdr(string contno, string imseq)
		{
			if (contno == null || contno.Trim().Length != 6)
			{
				jsAlertMsg("CONTNODATAERROR", "�X���s�����ŭȩή榡���~�A�гq���p���H");
				return;
			}
			InvMfrs im = new InvMfrs();
			DataSet ds1 = im.GetInvMfr(contno);
			DataView dv1 = ds1.Tables[0].DefaultView;
			dv1.RowFilter="im_imseq='"+imseq+"'";//�u�����w�o���t�Ӫ���Ʒ|�X�{
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
					lblFgitri.Text = "�Ҥ�";
					break;
				case "07":
					lblFgitri.Text = "�|��";
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
			lblCount.Text = "<<�@ "+dv.Count.ToString()+" �����Ӹ��>>";
			int	pyat=0;
			for(int i=0; i<dgdSubAdr.Items.Count; i++)
			{
				pyat += Convert.ToInt32(dgdSubAdr.Items[i].Cells[10].Text);
			}
			lblPyat.Text = pyat.ToString();

		}
		#endregion

		#region �榡�Ƽs�i���
		protected object MatchAdCate(object adcate)
		{
			string transAdCate = "";
			switch(adcate.ToString())
			{
				case "M":
					transAdCate = "����";
					break;
				case "I":
					transAdCate = "����";
					break;
				case "N":
					transAdCate = "�`��";
					break;
				default:
					throw new Exception("��Ʈw��ͼs�i������ƿ��~�A�гq���p���H");
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
					transKeyword = "����";
					break;
				case "h1":
					transKeyword = "�k�@";
					break;
				case "h2":
					transKeyword = "�k�G";
					break;
				case "h3":
					transKeyword = "�k�T";
					break;
				case "h4":
					transKeyword = "�k�|";
					break;
				case "w1":
					transKeyword = "�k��@";
					break;
				case "w2":
					transKeyword = "�k��G";
					break;
				case "w3":
					transKeyword = "�k��T";
					break;
				case "w4":
					transKeyword = "�k��|";
					break;
				case "w5":
					transKeyword = "�k�夭";
					break;
				case "w6":
					transKeyword = "�k�夻";
					break;
				default:
					throw new Exception("��Ʈw��ͼs�i��m��ƿ��~�A�гq���p���H");
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
//				throw new Exception("��Ʈw��͵o���t�Ӹ�ƿ��~�A�гq���p���H");
//			}
//			return transImSeq;
//		}

		private void FormatAdr()
		{
			for (int i=0; i<dgdSubAdr.Items.Count; i++)
			{

				//�ˬd���
//				if (DateTime.Today >= DateTime.ParseExact(dgdSubAdr.Items[i].Cells[3].Text.Trim(), "yyyyMMdd", null))
//				{
					((CheckBox)dgdSubAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked = false;
					((CheckBox)dgdSubAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Enabled = false;
//				}


				//�s�i����G�ഫ��yyyy/MM/dd
				dgdSubAdr.Items[i].Cells[3].Text = DateTime.ParseExact(dgdSubAdr.Items[i].Cells[3].Text.Trim(), "yyyyMMdd", null).ToString("yyyy/MM/dd");

				
			}
		}
		#endregion

		#region ����ia�Biad
		private void btnConfirm_Click(object sender, System.EventArgs e)
		{
			//���������X���s���Pfginved='v'
			string contno, imseq;
			contno = Request.QueryString["ContNo"].Trim();
			imseq = Request.QueryString["ImSeq"].Trim();
			Invoice inv = new Invoice();
			bool errorflg = inv.AddIa(contno, imseq, this.WhoAmI.EmpNo);
			if(errorflg){
				jsAlertMsg("INVALIDPERIOD", "�s�W�o���}�߳�@�~����!!");
				pnlAdr.Visible=false;
				pnlNext.Visible=true;
			}
			else
				jsAlertMsg("INVALIDPERIOD", "�s�W�o���}�߳�@�~�o�Ϳ��~, �Э��s�s�W�εy��A�i��");
		}
		#endregion

		#region ����, �N������O�M��, �^����
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

		#region �e�������e��, �ק︨�����, ���M��������O
		private void btnModifyAdr_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AdrPublish.aspx?NewContNo="+lblContNo.Text.Trim());
		}
		#endregion

		#region �~��o���}�ߧ@�~(�P�X��)
		private void btnContinue_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("IA1QueryCont.aspx?ContNo="+Request.QueryString["ContNo"].Trim()+"&ImSeq=00");
		}
		#endregion

		#region �~��o���}�ߧ@�~(���P�X��)
		private void btnGoIA1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("IA1Query.aspx");		
		}
		#endregion

		#region ����, �^����
		private void btnExit_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("content.htm");
		}
		#endregion

		#region �C�L�w���M��
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
