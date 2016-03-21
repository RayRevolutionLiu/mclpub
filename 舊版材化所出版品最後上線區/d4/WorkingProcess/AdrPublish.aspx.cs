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
	/// Summary description for AdrPublish.
	/// </summary>
	public class AdrPublish : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.Label lblContTp;
		protected System.Web.UI.WebControls.Label lblSignDate;
		protected System.Web.UI.WebControls.Label lblSDate;
		protected System.Web.UI.WebControls.Label lblEDate;
		protected System.Web.UI.WebControls.Label lblMfrNm;
		protected System.Web.UI.WebControls.Label lblCustNm;
		protected System.Web.UI.WebControls.Label lblPubTm;
		protected System.Web.UI.WebControls.Label lblFreeTm;
		protected System.Web.UI.WebControls.Label lblTotAmt;
		protected System.Web.UI.WebControls.Label lblDisc;
		protected System.Web.UI.WebControls.Label lbl_PubTm;
		protected System.Web.UI.WebControls.Label lbl_TotImgTm;
		protected System.Web.UI.WebControls.Label lbl_TotUrlTm;
		protected System.Web.UI.WebControls.Label lbl_PubedTm;
		protected System.Web.UI.WebControls.Label lbl_RestImgTm;
		protected System.Web.UI.WebControls.Label lbl_RestUrlTm;
		protected System.Web.UI.WebControls.Label lbl_RestTm;
		protected System.Web.UI.WebControls.Label lblTotMtm;
		protected System.Web.UI.WebControls.Label lblTotItm;
		protected System.Web.UI.WebControls.Label lblTotNtm;
		protected System.Web.UI.WebControls.TextBox tbxAltText;
		protected System.Web.UI.WebControls.DropDownList ddlInvMfr;
		protected System.Web.UI.WebControls.TextBox tbxSDate;
		protected System.Web.UI.WebControls.TextBox tbxEDate;
		protected System.Web.UI.WebControls.DropDownList ddlAdCate;
		protected System.Web.UI.WebControls.DropDownList ddlKeyword;
		protected System.Web.UI.WebControls.RadioButtonList rblFgFixAd;
		protected System.Web.UI.WebControls.TextBox tbxImpr;
		protected System.Web.UI.WebControls.RadioButtonList rblImgTp;
		protected System.Web.UI.WebControls.RadioButtonList rblUrlTp;
		protected System.Web.UI.WebControls.TextBox tbxNavUrl;
		protected System.Web.UI.WebControls.TextBox tbxAdAmt;
		protected System.Web.UI.WebControls.TextBox tbxDesAmt;
		protected System.Web.UI.WebControls.TextBox tbxChgAmt;
		protected System.Web.UI.WebControls.TextBox tbxInvAmt;
		protected System.Web.UI.WebControls.TextBox tbxRemark;
		protected System.Web.UI.WebControls.Button bthAddAdr;
		protected System.Web.UI.WebControls.DataGrid dgdAdr;
		protected System.Web.UI.WebControls.Button btnSelAll;
		protected System.Web.UI.WebControls.Button btnDeSelAll;
		protected System.Web.UI.WebControls.Button btnDelSeltedAdr;
		protected System.Web.UI.WebControls.Label lblAdrInfo;
		protected System.Web.UI.WebControls.DataGrid dgdNewInvMfr1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenAdrImpr;
		protected System.Web.UI.WebControls.Label lblTotAdAmt;
		protected System.Web.UI.WebControls.Label lblTotDesAmt;
		protected System.Web.UI.WebControls.Label lblTotChgAmt;
		protected System.Web.UI.WebControls.Label lblTotPubedAmt;
		protected System.Web.UI.WebControls.Label lblHint;
		protected System.Web.UI.WebControls.TextBox tbxCountDay;
		protected System.Web.UI.WebControls.Button btnCount;
		protected System.Web.UI.WebControls.Label Label1;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				//�w�]���
				tbxAdAmt.Text = "0";
				tbxDesAmt.Text = "0";
				tbxChgAmt.Text = "0";
				tbxInvAmt.Text = "0";
				tbxImpr.Text = "1";


				//�ˬd�ܼơA�o�ˤj���i�H�L�o�@��
				string new_contno = "";
				if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
				{
					throw new Exception("�䤣��X���s��");
				}
				else
				{
					new_contno = Request.QueryString["NewContNo"];
				}

				LoadContInfo(new_contno);

//				string old_contno = "";
//				if (Request.QueryString["OldContNo"] == null || Request.QueryString["OldContNo"] == "")
//				{
//					//�b���@�X���ɡA�q�X����ƥh��.....
//					Contracts cont = new Contracts();
//					SqlDataReader dr = cont.GetSingleContractByContNo(new_contno);
//
//					dr.Read();
//					try
//					{
//						old_contno = dr["cont_oldcontno"].ToString();
//					}
//					catch
//					{
//						throw new Exception("�䤣��X����ơA�гq���p���H");
//					}
//					dr.Close();
//
//				}
//				else
//				{
//					old_contno = Request.QueryString["OldContNo"];
//				}

//				Bind_dgdOldInvMfr(old_contno);
				Bind_NewInvMfr(new_contno);
				Bind_NewAdr(new_contno);
			}
			//�[�Jscript������
			if (!IsClientScriptBlockRegistered("JSCALENDAR"))
			{
				System.IO.TextReader tr = System.IO.File.OpenText(Server.MapPath(".") + "\\ClientScripts\\jsCalendar.js");
				string script = tr.ReadToEnd();
				RegisterClientScriptBlock("JSCALENDAR", script);
			}

			if (!IsClientScriptBlockRegistered("JSCONTNEW"))
			{
				System.IO.TextReader tr = System.IO.File.OpenText(Server.MapPath(".") + "\\ClientScripts\\jsContNew.js");
				string script = tr.ReadToEnd();
				RegisterClientScriptBlock("JSCONTNEW", script);
			}
			Bind_NewInvMfr(Request.QueryString["NewContNo"]);
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
			this.tbxEDate.TextChanged += new System.EventHandler(this.tbxEDate_TextChanged);
			this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
			this.bthAddAdr.Click += new System.EventHandler(this.bthAddAdr_Click);
			this.btnSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
			this.btnDeSelAll.Click += new System.EventHandler(this.btnDeSelAll_Click);
			this.btnDelSeltedAdr.Click += new System.EventHandler(this.btnDelSeltedAdr_Click);
			this.dgdAdr.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdAdr_CancelCommand);
			this.dgdAdr.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdAdr_EditCommand);
			this.dgdAdr.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdAdr_UpdateCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region ���J�X���򥻸��
		private void LoadContInfo(string contno)
		{
			if (contno.Trim() == "")
				throw new Exception("�X���s�����i���ť�");

			Contracts cont;

//			�Ӳz�����ݭn�q�Ȧs�@�����쩳....�q ��ƮwLoad�X�ӧa
//			if (Session["TMPCONT"] == null)
//				throw new Exception("�򥢼Ȧs�X������");
//			else
//				cont = (Contracts)Session["TMPCONT"];

//			lblContNo.Text = cont.ContNo;
//			lblContTp.Text = cont.ContTp;
//			lblSignDate.Text = DateTime.ParseExact(cont.SignDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
//			lblSDate.Text = DateTime.ParseExact(cont.SDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
//			lblEDate.Text = DateTime.ParseExact(cont.EDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
//			lblPubTm.Text = cont.PubTm.ToString();
//			lblFreeTm.Text = cont.FreeTm.ToString();
//			lblTotAmt.Text = cont.TotAmt.ToString();
//			lblDisc.Text = cont.Disc.ToString();
//			lblTotImgTm.Text = cont.TotImgTm.ToString();
//			lblTotUrlTm.Text = cont.TotUrlTm.ToString();


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
				lblMfrNm.Text = dr["mfr_inm"].ToString();
				lblCustNm.Text = dr["cust_nm"].ToString();
				lblPubTm.Text = dr["cont_pubtm"].ToString();
				//lblRestTm.Text = dr["cont_resttm"].ToString();
				lblFreeTm.Text = dr["cont_freetm"].ToString();
				lblTotAmt.Text = dr["cont_totamt"].ToString();
				lblDisc.Text = dr["cont_disc"].ToString();
				//lblTotImgTm.Text = dr["cont_totimgtm"].ToString();
				//lblTotUrlTm.Text = dr["cont_toturltm"].ToString();


				//���[����T
				Advertisements adr = new Advertisements();
				SqlDataReader dr2 = adr.GetAdrCounts(contno);
				int imgtm = 0;
				int urltm = 0;
				int pubedtm = 0;
				int totmtm = 0;
				int totitm = 0;
				int totntm = 0;
				if (dr2.Read())
				{
					imgtm = Convert.ToInt32(dr2["imgtm"]);
					urltm = Convert.ToInt32(dr2["urltm"]);
					pubedtm = Convert.ToInt32(dr2["pubedtm"]);
					totmtm = Convert.ToInt32(dr2["totmtm"]);
					totitm = Convert.ToInt32(dr2["totitm"]);
					totntm = Convert.ToInt32(dr2["totntm"]);
				}
				dr2.Close();

				lbl_PubTm.Text = dr["cont_pubtm"].ToString();
				lbl_PubedTm.Text = pubedtm.ToString();
				lbl_RestTm.Text = Convert.ToString( Convert.ToInt32(lbl_PubTm.Text) - Convert.ToInt32(lbl_PubedTm.Text));
				lbl_TotImgTm.Text = dr["cont_totimgtm"].ToString();
				lbl_RestImgTm.Text = Convert.ToString(Convert.ToInt32(lbl_TotImgTm.Text)-imgtm);
				if (Convert.ToInt32(lbl_RestImgTm.Text)<0)
				{
					jsAlertMsg("NEGRESTIMGTM", "�Ѿl�s���ɽZ���Ƥp�l�s�A���ˬd/�ק���ɽZ�����O");
				}
				lbl_TotUrlTm.Text = dr["cont_toturltm"].ToString();
				lbl_RestUrlTm.Text = Convert.ToString(Convert.ToInt32(lbl_TotUrlTm.Text)-urltm);
				if (Convert.ToInt32(lbl_RestUrlTm.Text)<0)
				{
					jsAlertMsg("NEGRESTURLTM", "�Ѿl�s�����Z���Ƥp�l�s�A���ˬd/�ק�����Z�����O");
				}
				
				lblTotMtm.Text = totmtm.ToString();
				lblTotItm.Text = totitm.ToString();
				lblTotNtm.Text = totntm.ToString();
			}
			dr.Close();
		}
		#endregion

		#region ���v�X�����o���t�Ӧ���H���
//		private void Bind_dgdOldInvMfr(string contno)
//		{
//			if (contno.Trim() == "")
//			{
//				lblOldIm.Text = "�L���v�X���o���t�Ӧ���H���";
//				dgdOldInvMfr.Visible = false;
//				return;
//			}
//
//			InvMfrs im = new InvMfrs();
//			DataSet ds = im.GetInvMfr(contno);
//			DataView dv = ds.Tables[0].DefaultView;
//			dgdOldInvMfr.DataSource = dv;
//			dgdOldInvMfr.DataBind();
//
//			if (dv.Count>0)
//			{
//				lblOldIm.Text = "���v�X���o���t�Ӧ���H���";
//				dgdOldInvMfr.Visible = true;
//
//				for (int i=0; i<dgdOldInvMfr.Items.Count; i++)
//				{
//					try
//					{
//						//�䪺��Ҥ��B�|���Nshow
//						dgdOldInvMfr.Items[i].Cells[13].Text = ddlFgItri.Items.FindByValue(dgdOldInvMfr.Items[i].Cells[13].Text.Trim()).Text;
//					}
//					catch
//					{
//						//��L�������@��
//						dgdOldInvMfr.Items[i].Cells[13].Text = "�@��";
//					}
//				}
//			}
//			else
//			{
//				lblOldIm.Text = "�L���v�X���o���t�Ӧ���H���";
//				dgdOldInvMfr.Visible = false;
//			}
//		}
		#endregion

		#region ���X�����o���t�Ӧ���H���
		private void Bind_NewInvMfr(string contno)
		{
			InvMfrs im = new InvMfrs();
			DataSet ds = im.GetInvMfr(contno);
			DataView dv = ds.Tables[0].DefaultView;
			dgdNewInvMfr1.DataSource = dv;
			dgdNewInvMfr1.DataBind();

			Bind_ddlInvMfr(dv);

			if (dv.Count>0)
			{
//				lblNewIm.Text = "���X���o���t�Ӧ���H���";
				dgdNewInvMfr1.Visible = true;

//				for (int i=0; i<dgdNewInvMfr.Items.Count; i++)
//				{
//					try
//					{
//						//�䪺��Ҥ��B�|���Nshow
//						dgdNewInvMfr.Items[i].Cells[13].Text = ddlFgItri.Items.FindByValue(dgdNewInvMfr.Items[i].Cells[13].Text.Trim()).Text;
//					}
//					catch
//					{
//						//��L�������@��
//						dgdNewInvMfr.Items[i].Cells[13].Text = "�@��";
//					}
//				}
			}
			else
			{
//				lblNewIm.Text = "���X���|�L�o���t�Ӧ���H���";
				dgdNewInvMfr1.Visible = false;
			}
		}
		#endregion

		#region �s���o���t�ӤU�Ԧ����
		private void Bind_ddlInvMfr(DataView dv)
		{
			ddlInvMfr.DataTextField = "im_nm";
			ddlInvMfr.DataValueField = "im_imseq";
			ddlInvMfr.DataSource = dv;
			ddlInvMfr.DataBind();
		}
		#endregion

		#region �s�W�s�i����
		private void bthAddAdr_Click(object sender, System.EventArgs e)
		{
			string contno = lblContNo.Text.Trim();

			string sdate;
			try
			{
				sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			}
			catch(Exception ex)
			{
				jsAlertMsg("SDATEFORMATERROR", "�_�l����榡���~");
				return;
			}

			string edate;
			try
			{
				edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			}
			catch(Exception ex)
			{
				jsAlertMsg("EDATEFORMATERROR", "��������榡���~");
				return;
			}

			if (DateTime.ParseExact(sdate, "yyyyMMdd", null) > DateTime.ParseExact(edate, "yyyyMMdd", null))
			{
				jsAlertMsg("NEGATIVETIMEPERIOD", "�_�l������i�H�񵲧�����j");
				return;
			}

			if (DateTime.ParseExact(sdate, "yyyyMMdd", null) < DateTime.Today)
			{
				jsAlertMsg("NEGATIVETIMEPERIOD", "����s�W���Ѥ��e���s�i���");
				return;
			}

			DateTime csdate = DateTime.ParseExact(lblSDate.Text.Trim(), "yyyy/MM/dd", null);
			DateTime cedate = DateTime.ParseExact(lblEDate.Text.Trim(), "yyyy/MM/dd", null);

			if ( !(csdate <= DateTime.ParseExact(sdate, "yyyyMMdd", null) &&  DateTime.ParseExact(edate, "yyyyMMdd", null) <= cedate) )
			{
				jsAlertMsg("INVALIDPERIOD", "�s�i�_���϶����i�W�X�X���_���϶�");
				return;
			}

			double addays = ((TimeSpan)DateTime.ParseExact(edate, "yyyyMMdd", null).Subtract(DateTime.ParseExact(sdate, "yyyyMMdd", null))).TotalDays + 1;
			if (addays > Convert.ToInt32(lbl_RestTm.Text.Trim()))
			{
				jsAlertMsg("INVALIDDAYS", "�s�W���Z�n���(����:" + addays.ToString() + ")���i�j��Ѿl�Z�n����:" + lbl_RestTm.Text.Trim());
				return;
			}



			string adcate = ddlAdCate.SelectedItem.Value;
			string keyword = ddlKeyword.SelectedItem.Value;
			string alttext = tbxAltText.Text.Trim();
			string imgurl = "";	//�Ѭ��s�M�w
			string navurl = tbxNavUrl.Text.Trim();	//���s�i�H�A�M�w
			if (!navurl.ToLower().StartsWith("http://"))
				if (navurl.Trim()!="")
					navurl = "http://" + navurl;
			int impr;
			try
			{
				impr = Convert.ToInt32(tbxImpr.Text.Trim());
			}
			catch(Exception ex)
			{
				jsAlertMsg("IMPRFORMATERROR", "���X���v�榡���~");
				return;
			}

			string drafttp = rblImgTp.SelectedItem.Value;
			string urltp = rblUrlTp.SelectedItem.Value;

			if (ddlInvMfr.Items.Count<=0 && lblContTp.Text.Trim() == "�@��")
			{
				jsAlertMsg("NOINVMFR", "���X�����@��X���A�Х��s�W�o���t�Ӧ���H��A�s�W�s�i");
				return;
			}
			string imseq;
			if (lblContTp.Text.Trim() == "�@��")
			{
				imseq = ddlInvMfr.SelectedItem.Value;
			}
			else
			{
				imseq = "";
			}

			int adamt;
			try
			{
				adamt = Convert.ToInt32(tbxAdAmt.Text.Trim());
			}
			catch(Exception ex)
			{
				jsAlertMsg("ADAMTFORMATERROR", "�s�i���B�榡���~");
				return;
			}

			int desamt;
			try
			{
				desamt = Convert.ToInt32(tbxDesAmt.Text.Trim());
			}
			catch(Exception ex)
			{
				jsAlertMsg("DESAMTFORMATERROR", "�]�p����榡���~");
				return;
			}

			int chgamt;
			try
			{
				chgamt = Convert.ToInt32(tbxChgAmt.Text.Trim());
			}
			catch(Exception ex)
			{
				jsAlertMsg("CHGAMTFORMATERROR", "���Z�O�ή榡���~");
				return;
			}

			//�ˬd�s�i���B���D
			int totamt = 0;
			try
			{
				totamt = Convert.ToInt32(lblTotAmt.Text.Trim());
			}
			catch
			{
				jsAlertMsg("INVALIDTOTAMT", "�X���`���B�榡���~�A�ЦܦX�����@�ק���B");
				return;
			}


			//
			// 2003/06/11
			//���G�o��ܭ��n�A��C300�Q�׵��G�A
			//�Ȧ��s�i����n��X�����B��������A
			//�ӳ]�p����P���Z�O�Τ��]�t�b�X�����B�̭�
			//

			//�X���Ѿl���B���p��
			int restamt = int.Parse(lblTotAmt.Text.ToString());
			for(int k=0; k<dgdAdr.Items.Count; k++)
			{
				try
				{
					restamt -= Convert.ToInt32(dgdAdr.Items[k].Cells[9].Text.Trim());
				}
				catch
				{
					jsAlertMsg("ERRORINSUMATION", "�[�`�p��w�������B�ɵo�Ϳ��~�A�гq���p���H");
					return;
				}
			}

			if ( adamt>restamt )	//���ӥγo��          !VerifyMoneyIsValid(adamt, desamt, chgamt, totamt)
			{
				jsAlertMsg("INVALIDMONEY", "�s�W���s�i���椣�o�W�L�X���`���B�A�Ч����B��A�s�W");
				return;
			}

			string remark = tbxRemark.Text.Trim();

			string fgfixad = rblFgFixAd.SelectedItem.Value;
			//CHCECK�O�_�w��
			if (fgfixad == "1")
			{
				impr = 20;
				jsAlertMsg("SETIMPRTO20", "�ѩ�w���A�ҥH�j���ഫ������v��20");
			}

			//�ˬd�Ѿl���Ŷ�������
			DateTime firstXday;
			Advertisements adr = new Advertisements();
			SqlDataReader drslot = adr.CheckAdrSlot(adcate, keyword, sdate, edate, impr, 0);
			if (drslot.Read())
			{
				firstXday = DateTime.ParseExact(drslot["cnt_date"].ToString(), "yyyyMMdd", null);
				jsAlertMsg("NOTENOUGH", firstXday.ToString("yyyy/MM/dd") + "���Ѿl�Ŷ������A�Эק�_������Ϭq");
				return;
			}
			drslot.Close();


			//�|�Ҥ����O��o���t�Ӹ�ƨ�
			string fgitri = "";

			if (ddlInvMfr.Items.Count>=0 && lblContTp.Text.Trim() == "�@��")
			{
				InvMfrs im = new InvMfrs();
				SqlDataReader dr = im.GetSingleIm(contno, imseq);
				if (dr.Read())
				{
					fgitri = dr["im_fgitri"].ToString().Trim();
				}
				else
				{
					jsAlertMsg("LOSSINVMFR", "��Ʈw�򥢥��X���o���t�Ӹ�ơA�гq���p���H");
					return;
				}
				dr.Close();
			}

			if (fgitri=="00")
			{
				//�]��DropDownList��ListItem�L�k�H""��Value�A�ҥH��00���N�A
				//�o��A�ഫ�^��
				fgitri="";
			}
			string fgimggot="0";//rblFgImgGot.SelectedItem.Value.Trim();
			string fgurlgot="0";//rblFgUrlGot.SelectedItem.Value.Trim();
			//�H�W�O���o�ƭ�

			//INSERT INTO Database
			adr.AddAdr(contno, sdate, edate, adcate, keyword, alttext, imgurl, navurl, impr,
				drafttp, urltp, imseq, adamt, desamt, chgamt, remark, fgfixad, fgitri, fgimggot,fgurlgot);

			Bind_NewAdr(contno);
			LoadContInfo(contno);
		}
		#endregion

		#region �s���s�i���
		private void Bind_NewAdr(string contno)
		{
			if (contno == null || contno.Trim().Length != 6)
			{
				jsAlertMsg("CONTNODATAERROR", "�X���s�����ŭȩή榡���~�A�гq���p���H");
				return;
			}
			Advertisements adr = new Advertisements();
			DataSet ds = adr.GetAdvertisements(contno);
			DataView dv = ds.Tables[0].DefaultView;

			dgdAdr.DataSource = dv;
			dgdAdr.DataBind();

			for(int i=0; i<dgdAdr.Items.Count; i++)
			{
				if(dgdAdr.Items[i].Cells[18].Text=="1")
				{
					dgdAdr.Items[i].Cells[19].Text="<font color=red>�w�}�o��</font>";
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked = false;
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Enabled = false;
				}
				else
					dgdAdr.Items[i].Cells[19].Text="";
			}
			if (dv.Count>0)
			{
				lblAdrInfo.Text = "";
				FormatAdr();
			}
			else
			{
				lblAdrInfo.Text = "���X���|�L�s�i���";
			}
			GetAdrInfo(contno);
		}
		#endregion

		#region ���o�s�i�ƭȲέp
		private void GetAdrInfo(string contno)
		{
			int totadamt = 0;
			int totdesamt = 0;
			int totchgamt = 0;
			int totpubedamt = 0;

			Advertisements adr = new Advertisements();
			SqlDataReader dr = adr.GetAdrAmounts(contno);
			if (dr.Read())
			{
				totadamt = Convert.ToInt32(dr["totadamt"]);
				totdesamt = Convert.ToInt32(dr["totdesamt"]);
				totchgamt = Convert.ToInt32(dr["totchgamt"]);
				totpubedamt = totadamt + totdesamt + totchgamt;
			}
			dr.Close();

			lblTotAdAmt.Text = totadamt.ToString();
			lblTotDesAmt.Text = totdesamt.ToString();
			lblTotChgAmt.Text = totchgamt.ToString();
			lblTotPubedAmt.Text = totpubedamt.ToString();

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

		protected object MatchImSeq(object imseq)
		{
			string transImSeq = "";
			try
			{
				transImSeq = ddlInvMfr.Items.FindByValue(imseq.ToString()).Text;
			}
			catch
			{
//				if (lblContTp.Text == "�@��")
//					throw new Exception("��Ʈw��͵o���t�Ӹ�ƿ��~�A�гq���p���H");
			}
			return transImSeq;
		}

		private void FormatAdr()
		{
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//�s�褤�����L
				if (dgdAdr.EditItemIndex == i)
				{
					continue;	//�i��U�@��item
				}

				//�ˬd���;92/8/15�M�w��Ѹ�ƥi�R��
//				if (DateTime.Today >= DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyyMMdd", null))
				if (DateTime.Today > DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyyMMdd", null))
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked = false;
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Enabled = false;
				}


				//�s�i����G�ഫ��yyyy/MM/dd
				dgdAdr.Items[i].Cells[3].Text = DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyyMMdd", null).ToString("yyyy/MM/dd");

				
			}
		}
		#endregion

		#region ����A�M��
		private void btnSelAll_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//���ˬd���
				if (DateTime.Today >= DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyy/MM/dd", null))
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked = false;
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Enabled = false;
				}
				else
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked = true;
				}
			}

			//Bind_NewAdr(lblContNo.Text.Trim());
		}

		private void btnDeSelAll_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//���ˬd���
				if (DateTime.Today >= DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyy/MM/dd", null))
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Enabled = false;
				}

				((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked = false;
			}	
			Bind_NewAdr(lblContNo.Text.Trim());	
		}
		#endregion

		#region �R���Ŀ諸�s�i
		private void btnDelSeltedAdr_Click(object sender, System.EventArgs e)
		{
			ArrayList ary = new ArrayList();
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				if (((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked)
				{
					string adrseq = dgdAdr.Items[i].Cells[2].Text.Trim();
					string addate = RevertAdDate(dgdAdr.Items[i].Cells[3].Text.Trim());
					string adcate = RevertAdCate(((Label)dgdAdr.Items[i].Cells[5].FindControl("lblEAdCate")).Text.Trim());
					string keyword = RevertKeyword(((Label)dgdAdr.Items[i].Cells[6].FindControl("lblEKeyword")).Text.Trim());
					string impr = dgdAdr.Items[i].Cells[8].Text.Trim();

					ary.Add(adrseq + "," + addate + "," + adcate + "," + keyword + "," + impr);
				}
			}

			Advertisements adr = new Advertisements();

			//�R���e�A��check
			bool xmlExist = false;
			ArrayList xeArray = new ArrayList();

			for (int i=0; i<ary.Count; i++)
			{
				string rawString = (string)ary[i];

				string addate = "";

				try
				{
					addate = ((string)(rawString.Split(',')).GetValue(1));
				}
				catch(Exception ex)
				{
					throw new Exception("�L�k���o����������");
				}

				string strCmd = "";
				if (addate=="")
					throw new Exception("�s�i���������ƿ��~");

				//checking....
				xmlExist = adr.CheckXmlFileLog(addate);

				if (xmlExist)
				{
					xeArray.Add(addate);
				}
			}
			

			//���L����X�{�H
			if (xeArray.Count>0)
			{
				string strDate = "";
				for (int j=0; j<xeArray.Count; j++)
				{
					strDate += (string)xeArray[j] +",";
				}

				jsAlertMsg("XMLFILELOGALERT", strDate + "�w���͹L����xml�ɮסA���R���o�Ǥ����������ơA�Х��R���o�Ǥ��������xml�����ɮ�");
				return;
			}

			//�H�U���i�H�R������������
			string adr_contno = lblContNo.Text.Trim();
			adr.DeleteAdr(adr_contno, ary);

			Bind_NewAdr(adr_contno);
			LoadContInfo(adr_contno);
		
			#region ���ո�ư�
//			for (int i=0; i<ary.Count; i++)
//			{
//				string rawString = (string)ary[i];
//
//				string seq = "";
//				string addate = "";
//				string adcate = "";
//				string keyword = "";
//				string impr = "";
//
//				try
//				{
//					seq = ((string)(rawString.Split(',')).GetValue(0));
//					addate = ((string)(rawString.Split(',')).GetValue(1));
//					adcate = ((string)(rawString.Split(',')).GetValue(2));
//					keyword = ((string)(rawString.Split(',')).GetValue(3));
//					impr = ((string)(rawString.Split(',')).GetValue(4));
//				}
//				catch(Exception ex)
//				{
//					throw new Exception("�L�k���o�����Ǹ��B�s�i����B�s�i�����B�s�i��m�B���X���v�����");
//				}
//
//				string strCmd = "";
//				if (seq == "" || addate == "" || adcate == "" || keyword == "" || impr == "")
//					throw new Exception("��͸����Ǹ��B�s�i����B�s�i�����B�s�i��m�B���X���v����ƿ��~");
//
//				//�R��c4_adr�����
//				strCmd = "DELETE FROM c4_adr WHERE adr_syscd='C4' AND adr_contno='" + adr_contno + "' AND adr_seq='" + seq + "' AND adr_addate='" + addate + "'";
//				Response.Write(strCmd + "<br>");
//				//��sc4_adcnt�����
//				strCmd = "UPDATE c4_adcnt SET cnt_" + keyword + "=cnt_" + keyword + "+" + impr + " WHERE cnt_date='" + addate + "' AND cnt_adcate='" + adcate + "'";
//				Response.Write(strCmd + "<br>");
//			}
			#endregion

		}
		#endregion

		#region ���ഫ�s�i������^��͸��
		//�������榡�^�GyyyyMMdd
		private string RevertAdDate(string transAdDate)
		{
			string oriAdDate = "";

			try
			{
				oriAdDate = DateTime.ParseExact(transAdDate, "yyyy/MM/dd", null).ToString("yyyyMMdd");
			}
			catch(Exception ex)
			{
				throw new Exception("�������榡�ɵo�Ϳ��~");
			}
			return oriAdDate;
		}

		//�s�i�����G�ഫ�������B�����B�`�̡A���Τ�
		private string RevertAdCate(string transAdCate)
		{	
			string oriAdCate = "";

			switch(transAdCate.Trim())
			{
				case "����":
					oriAdCate = "M";
					break;
				case "����":
					oriAdCate = "I";
					break;
				case "�`��":
					oriAdCate = "N";
					break;
				default:
					throw new Exception("����s�i�����榡��ƿ��~");
					//Response.Write("error=" + transAdCate + ".");
					break;
			}
			return oriAdCate;
		}

		//�s�i��m�G�ഫ������A���Τ�
		private string RevertKeyword(string transKeyword)
		{
			string oriKeyword = "";

			switch(transKeyword)
			{
				case "����":
					oriKeyword = "h0";
					break;
				case "�k�@":
					oriKeyword = "h1";
					break;
				case "�k�G":
					oriKeyword = "h2";
					break;
				case "�k�T":
					oriKeyword = "h3";
					break;
				case "�k�|":
					oriKeyword = "h4";
					break;
				case "�k��@":
					oriKeyword = "w1";
					break;
				case "�k��G":
					oriKeyword = "w2";
					break;
				case "�k��T":
					oriKeyword = "w3";
					break;
				case "�k��|":
					oriKeyword = "w4";
					break;
				case "�k�夭":
					oriKeyword = "w5";
					break;
				case "�k�夻":
					oriKeyword = "w6";
					break;
				default:
					throw new Exception("����s�i��m�榡��ƿ��~");
					//Response.Write("error="+transKeyword+".");
					break;
			}
			
			return oriKeyword;
		}
		#endregion

		#region ��w�ק�
		private void dgdAdr_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DateTime csdate = DateTime.ParseExact(lblSDate.Text.Trim(), "yyyy/MM/dd", null);
			DateTime cedate = DateTime.ParseExact(lblEDate.Text.Trim(), "yyyy/MM/dd", null);
			DateTime addate = DateTime.ParseExact(e.Item.Cells[3].Text.Trim(), "yyyy/MM/dd", null);

			if ( !(csdate <= addate &&  addate <= cedate) )
			{
				jsAlertMsg("INVALIDPERIOD", "�L�k�ק�W�X�X���_���϶����s�i�������");
				return;
			}		
//			if (DateTime.Today >= DateTime.ParseExact(dgdAdr.Items[e.Item.ItemIndex].Cells[3].Text.Trim(), "yyyy/MM/dd", null))
//			{
//				jsAlertMsg("EDITPASTADRDENIED", "�L�k�ק蘆�餧�e���s�i�������");
//				return;
//			}
//
//			//�s�褧�e....
//			//�ˬdlogfile���O�_�������ק��Ƽ��X�骺�����A
//			//�p�G���N�omessage�A�n��delete����~�i�H�ק︨�����
//			Advertisements adr = new Advertisements();
//			bool xmlExist = adr.CheckXmlFileLog(addate.ToString("yyyyMMdd"));
//			if (xmlExist)
//			{
//				jsAlertMsg("FILEEXIST", "�w�g���͹L�Ӥ�s�i������XML�ɮסA�Х��R�����ɮ׫��A�ק�s�i�������");
//				dgdAdr.EditItemIndex = -1;
//				//				return;
//			}
			///////////
			
			int	flag=EditCheck(e.Item.ItemIndex);
			if(flag==4)
			{
				jsAlertMsg("INVALIDPERIOD", "�����s�i������Ƥw�}�ߵo��, �����\�ק�");
				dgdAdr.EditItemIndex = -1;
				return;
			}
			dgdAdr.EditItemIndex = e.Item.ItemIndex;
			string contno = lblContNo.Text.Trim();
			Bind_NewAdr(contno);

			//�]�wtextbox���e��
			DataGridItem dgi = dgdAdr.Items[e.Item.ItemIndex];

			dgi.Cells[3].Text = DateTime.ParseExact(dgi.Cells[3].Text.Trim(), "yyyyMMdd", null).ToString("yyyy/MM/dd");

			//ETC
			((TextBox)dgi.Cells[4].Controls[0]).Width = Unit.Percentage(100);

			//�B�z�s�i����
			foreach(ListItem li in ddlAdCate.Items)
			{
				((DropDownList)dgi.Cells[5].Controls[1]).Items.Add(li);
			}
			((DropDownList)dgi.Cells[5].Controls[1]).SelectedIndex = -1;
			try
			{
				((DropDownList)dgi.Cells[5].Controls[1]).Items.FindByValue(dgi.Cells[15].Text.Trim()).Selected = true;
			}
			catch
			{
				//Response.Write(dgi.Cells[15].Text.Trim()+"_");
				((DropDownList)dgi.Cells[5].Controls[1]).SelectedIndex = 0;
			}

			//�B�z�s�i��m
			foreach(ListItem li in ddlKeyword.Items)
			{
				((DropDownList)dgi.Cells[6].Controls[1]).Items.Add(li);
			}
			((DropDownList)dgi.Cells[6].Controls[1]).SelectedIndex = -1;
			try
			{
				((DropDownList)dgi.Cells[6].Controls[1]).Items.FindByValue(dgi.Cells[16].Text.Trim()).Selected = true;
			}
			catch
			{
				//Response.Write("<br>"+dgi.Cells[16].Text.Trim()+"_");
				((DropDownList)dgi.Cells[6].Controls[1]).SelectedIndex = 0;
			}


			((TextBox)dgi.Cells[7].Controls[0]).Width = Unit.Percentage(100);
			hiddenAdrImpr.Value=((TextBox)dgi.Cells[8].Controls[0]).Text;
			((TextBox)dgi.Cells[8].Controls[0]).Width = Unit.Percentage(100);
			((TextBox)dgi.Cells[9].Controls[0]).Width = Unit.Percentage(100);
			((TextBox)dgi.Cells[10].Controls[0]).Width = Unit.Percentage(100);
			((TextBox)dgi.Cells[11].Controls[0]).Width = Unit.Percentage(100);

			//�o�����B
			dgi.Cells[12].Text = "[�[�`��]";

			//�B�z�o���t��
			foreach(ListItem li in ddlInvMfr.Items)
			{
				((DropDownList)dgi.Cells[13].Controls[1]).Items.Add(li);
			}
			((DropDownList)dgi.Cells[13].Controls[1]).SelectedIndex = -1;
			try
			{
				((DropDownList)dgi.Cells[13].Controls[1]).Items.FindByValue(dgi.Cells[17].Text.Trim()).Selected = true;
			}
			catch
			{
				//Response.Write("<br>"+dgi.Cells[17].Text.Trim()+"_");
				((DropDownList)dgi.Cells[13].Controls[1]).SelectedIndex = 0;
			}

			((TextBox)dgi.Cells[14].Controls[0]).Width = Unit.Percentage(100);
//			((TextBox)dgi.Cells[18].Controls[0]).Width = Unit.Percentage(100);
//			((TextBox)dgi.Cells[19].Controls[0]).Width = Unit.Percentage(100);
			if(flag==2)
			{
				((TextBox)dgi.Cells[9].Controls[0]).Enabled=false;
				((TextBox)dgi.Cells[10].Controls[0]).Enabled=false;
				((TextBox)dgi.Cells[11].Controls[0]).Enabled=false;
				((DropDownList)dgi.Cells[13].Controls[1]).Enabled=false;
			}
			else if(flag==3)
			{
				((TextBox)dgi.Cells[4].Controls[0]).Enabled=false;
				((DropDownList)dgi.Cells[5].Controls[1]).Enabled=false;
				((DropDownList)dgi.Cells[6].Controls[1]).Enabled=false;
				((TextBox)dgi.Cells[7].Controls[0]).Enabled=false;
				((TextBox)dgi.Cells[8].Controls[0]).Enabled=false;
			}
			if (DateTime.Today >= addate)
			{
				((CheckBox)dgi.Cells[0].FindControl("cbxDelAdr")).Checked = false;
				((CheckBox)dgi.Cells[0].FindControl("cbxDelAdr")).Enabled = false;
			}
		}
		#endregion

		#region ������ƬO�_�i�ק�
		private int EditCheck(int idx)
		{
			DateTime addate = DateTime.ParseExact(dgdAdr.Items[idx].Cells[3].Text.Trim(), "yyyy/MM/dd", null);
			if (DateTime.Today > addate)
			{
				if(dgdAdr.Items[idx].Cells[18].Text.Trim()=="1")
					return 4;	//�Ҧ�������Ƥ���ק�
				else
					return 3;	//�s�i��Ƥ���ק�, �o����ƥi�ק�
			}
			else
			{
				//�ˬdlogfile���O�_�������ק��Ƽ��X�骺�����A
				//�p�G���N�omessage�A�n��delete����~�i�H�ק︨�����
				Advertisements adr = new Advertisements();
				bool xmlExist = adr.CheckXmlFileLog(addate.ToString("yyyyMMdd"));
				if (xmlExist)
				{
					jsAlertMsg("FILEEXIST", "�w�g���͹L�Ӥ�s�i������XML�ɮסA�p�n�ק�s�i������ƽХ��R�����ɮ�");
					if(dgdAdr.Items[idx].Cells[18].Text.Trim()=="1")
						return 4;	//�Ҧ�������Ƥ���ק�
					else
						return 3;	//�s�i��Ƥ���ק�, �o����ƥi�ק�
				}
				else
				{
					if(dgdAdr.Items[idx].Cells[18].Text.Trim()=="1")
						return 2;	//�s�i��ƥi�ק�, �o����Ƥ���ק�
					else
						return 1;	//�Ҧ�������Ƭҥi�ק�
				}
			}

			return 0;
		}
		#endregion

		#region �����ק�
		private void dgdAdr_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dgdAdr.EditItemIndex = -1;
			string contno = lblContNo.Text.Trim();
			Bind_NewAdr(contno);
		}
		#endregion

		#region �x�s�ק�s�i�������
		private void dgdAdr_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string contno = lblContNo.Text.Trim();

			DataGridItem dgi = e.Item;

			string seq = dgi.Cells[2].Text.Trim();

			//���
			string addate = "";
			try
			{
				addate = DateTime.ParseExact(dgi.Cells[3].Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			}
			catch
			{
				jsAlertMsg("UPDATEADDATEERROR", "����榡���~");
				return;
			}

			//���i�H�]�w�����ѥH�e�A�]�t���Ѫ����
//			if (DateTime.ParseExact(addate, "yyyyMMdd", null) <= DateTime.Today)
//			{
//				jsAlertMsg("INVALIDDATE", "���i�H�]�w�����ѩΤ��ѥH�e�����");
//				return;
//			}

			//alttext
			string alttext = ((TextBox)dgi.Cells[4].Controls[0]).Text.Trim();

			string adcate = ((DropDownList)dgi.Cells[5].Controls[1]).SelectedItem.Value;

			string keyword = ((DropDownList)dgi.Cells[6].Controls[1]).SelectedItem.Value;

			string navurl = ((TextBox)dgi.Cells[7].Controls[0]).Text.Trim();
			if (!navurl.ToLower().StartsWith("http://"))
				if (navurl.Trim()!="")
					navurl = "http://" + navurl;

			int impr = Convert.ToInt32(((TextBox)dgi.Cells[8].Controls[0]).Text.Trim());
			int impr_old = int.Parse(hiddenAdrImpr.Value.Trim());

			int adamt = 0;
			try
			{
				adamt = Convert.ToInt32(((TextBox)dgi.Cells[9].Controls[0]).Text.Trim());
			}
			catch
			{
				jsAlertMsg("UPDATEADAMTERROR", "�s�i���B�榡���~");
				return;
			}

			int desamt = 0;
			try
			{
				desamt = Convert.ToInt32(((TextBox)dgi.Cells[10].Controls[0]).Text.Trim());
			}
			catch
			{
				jsAlertMsg("UPDATEDESAMTERROR", "�]�p���B�榡���~");
				return;
			}
			int chgamt = 0;
			try
			{
				chgamt = Convert.ToInt32(((TextBox)dgi.Cells[11].Controls[0]).Text.Trim());
			}
			catch
			{
				jsAlertMsg("UPDATECHGAMTERROR", "���Z�O�Ϊ��B�榡���~");
				return;
			}

			//�ˬd�s�i���B���D
			int totamt = 0;
			try
			{
				totamt = Convert.ToInt32(lblTotAmt.Text.Trim());
			}
			catch
			{
				jsAlertMsg("INVALIDTOTAMT", "�X���`���B�榡���~�A�ЦܦX�����@�ק���B");
				return;
			}

			if ( !VerifyMoneyIsValid(adamt, desamt, chgamt, totamt) )
			{
				jsAlertMsg("INVALIDMONEY", "�s�i����B�]�p����B���Z�O���`�M���o�W�L�X���`���B�A�Ч����B��A�s�W");
				return;
			}

			if (((DropDownList)dgi.Cells[13].Controls[1]).Items.Count<=0 && lblContTp.Text.Trim() == "�@��")
			{
				jsAlertMsg("NOINVMFR", "���X�����@��X���A�Х��s�W�o���t�Ӧ���H��A�ק�/�x�s�s�i");
				return;
			}
			string imseq;
			if (lblContTp.Text.Trim() == "�@��")
			{
				imseq = ((DropDownList)dgi.Cells[13].Controls[1]).SelectedItem.Value;
			}
			else
			{
				imseq = "";
			}

			//�ˬd�Ѿl�Ŷ�
			Advertisements adr = new Advertisements();
			DateTime firstXday;
			SqlDataReader drslot = adr.CheckAdrSlot(adcate, keyword, addate, addate, impr, impr_old);
			if (drslot.Read())
			{
				firstXday = DateTime.ParseExact(drslot["cnt_date"].ToString(), "yyyyMMdd", null);
				jsAlertMsg("NOTENOUGH", firstXday.ToString("yyyy/MM/dd") + "���Ѿl�Ŷ������A�Эק�_������Ϭq");
				return;
			}
			drslot.Close();
			
			//�|�Ҥ����O��o���t�Ӹ�ƨ�
			string fgitri = "";

			if (lblContTp.Text.Trim() == "�@��")
			{
				InvMfrs im = new InvMfrs();
				SqlDataReader dr = im.GetSingleIm(contno, imseq);
				if (dr.Read())
				{
					fgitri = dr["im_fgitri"].ToString().Trim();
				}
				else
				{
					jsAlertMsg("LOSSINVMFR", "��Ʈw�򥢥��X���o���t�Ӹ�ơA�гq���p���H");
					return;
				}
				dr.Close();
			}

			if (fgitri=="00")
			{
				//�]��DropDownList��ListItem�L�k�H""��Value�A�ҥH��00���N�A
				//�o��A�ഫ�^��
				fgitri="";
			}
			//�H�W�O���o�ƭ�

			string remark = ((TextBox)dgi.Cells[14].Controls[0]).Text.Trim();
//			Response.Write("imseq=" + imseq);


			//�q�q�n�F�N��UPDATE�A�ثe�p�e�N���A�������ߤ���user�a
			//Response.Write("UPDATE c4_adr SET adr_addate="+addate+", adr_alttext="+alttext+", adr_adcate="+adcate+", adr_keyword="+keyword+", adr_navurl="+navurl+", adr_impr="+impr+", adr_adamt="+adamt.ToString()+", adr_desamt="+desamt.ToString()+", adr_chgamt="+chgamt.ToString()+", adr_invamt="+Convert.ToString(adamt+desamt+chgamt)+", adr_imseq="+imseq+", adr_remark="+remark+" WHERE adr_contno=contno AND adr_seq=seq");
			int errorcode = adr.UpdateAdrLite1(contno, seq, addate, adcate, keyword, alttext, navurl, impr, imseq, adamt, desamt, chgamt, remark);

			if (errorcode<0)
			{
				//��ܦ����o��
				switch(errorcode)
				{
					case -1:
						jsAlertMsg("UPDATEADRFAILE1", "�Ѿl�Ŷ������A������s�ʧ@");
						break;
					case -2:
						jsAlertMsg("UPDATEADRFAILE2", "�s�i��s����");
						break;
					case -3:
						jsAlertMsg("UPDATEADRFAILE2", "�s�i�p�Ƹɨ����ѡA������s�ʧ@");
						break;
					default:
						break;
				}
				return;
			}
			
			//Finally....Success!!!
			dgdAdr.EditItemIndex = -1;
			Bind_NewAdr(contno);
			LoadContInfo(contno);
		}
		#endregion

		#region �ˬd��J����ƬO�_�X�G�޿�
		private bool VerifyMoneyIsValid(int adamt, int desamt, int chgamt, int totamt)
		{
			if (adamt+desamt+chgamt>totamt)
				return false;
			else
				return true;
		}
		#endregion

		#region ��J�X�����������p��Ѽ�
		private void tbxEDate_TextChanged(object sender, System.EventArgs e)
		{
			DateTime sdate;
			DateTime edate;
			try
			{
				sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("SDATEERROR", "�_�l����榡���~�A�L�k�Ψӭp��϶��Ѽ�");
				return;
			}

			try
			{
				edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("EDATEERROR", "��������榡���~�A�L�k�Ψӭp��϶��Ѽ�");
				return;
			}
			if (sdate>edate)
			{
				jsAlertMsg("INVALIDPERIOD", "�_�l������i�j�󵲧�����A�Ч�");
				return;
			}

			double pubdays = ((TimeSpan)edate.Subtract(sdate)).TotalDays + 1;

			tbxCountDay.Text = pubdays.ToString();
		
		}

		private void btnCount_Click(object sender, System.EventArgs e)
		{
			DateTime sdate;
			DateTime edate;
			try
			{
				sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("SDATEERROR", "�_�l����榡���~�A�L�k�Ψӭp��϶��Ѽ�");
				return;
			}

			try
			{
				edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("EDATEERROR", "��������榡���~�A�L�k�Ψӭp��϶��Ѽ�");
				return;
			}
			if (sdate>edate)
			{
				jsAlertMsg("INVALIDPERIOD", "�_�l������i�j�󵲧�����A�Ч�");
				return;
			}

			double pubdays = ((TimeSpan)edate.Subtract(sdate)).TotalDays + 1;

			tbxCountDay.Text = pubdays.ToString();
		}
		#endregion


	}
}
