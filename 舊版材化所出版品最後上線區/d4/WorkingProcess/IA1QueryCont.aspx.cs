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
using MRLPub.d4.DataTypes;
using MRLPub.d4.Configurations;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for IA1QueryCont.
	/// </summary>
	public class IA1QueryCont : MRLPub.d4.Pages.Page
	{
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
		protected System.Web.UI.WebControls.DataGrid dgdAdr;
		protected System.Web.UI.WebControls.Button btnSelAll;
		protected System.Web.UI.WebControls.Panel pnlAdr;
		protected System.Web.UI.WebControls.Button btnConfirmSelected;
		protected System.Web.UI.WebControls.Label lblAdrInfo;
		protected System.Web.UI.WebControls.Button btnDeSelAll;
		protected System.Web.UI.WebControls.DropDownList ddlInvMfr;
		protected System.Web.UI.WebControls.Label lblContInfo;
		protected System.Web.UI.WebControls.Label lblSelectInvMfr;
		protected System.Web.UI.WebControls.Panel pnlOptions;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				SwitchStep(1);
				string contno = Request.QueryString["ContNo"];
				LoadContData(contno);
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
			this.ddlInvMfr.SelectedIndexChanged += new System.EventHandler(this.ddlInvMfr_SelectedIndexChanged);
			this.btnSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
			this.btnDeSelAll.Click += new System.EventHandler(this.btnDeSelAll_Click);
			this.btnConfirmSelected.Click += new System.EventHandler(this.btnConfirmSelected_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SwitchStep(int step)
		{
			switch(step)
			{
				case 0:
					//��l��
//					pnlCont.Visible = false;
					pnlAdr.Visible = false;
//					pnlList.Visible = false;
					break;
				case 1:
					//��w�X���A��ܼs�i
//					pnlCont.Visible = true;
					pnlAdr.Visible = true;
//					pnlList.Visible = false;
					break;
				case 2:
					//�Ŀ��Check?
//					pnlCont.Visible = true;
					pnlAdr.Visible = true;
//					pnlList.Visible = true;
					break;
				case 3:
					break;
				default:
					break;

			}
		}


		#region ���J�X�����
		private void LoadContData(string contno)
		{
			if (contno.Trim() == "")
				throw new Exception("�X���s�����i���ť�");

			SwitchStep(1);
			Contracts cont = new Contracts();
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
//				tblCont.Visible = true;

				//Load InvMfr
				Bind_ddlInvMfr(contno);

				//Load Advertisements
				LoadAdr(contno);
				MatchCheckBox();
				string imseq = Request.QueryString["ImSeq"];
				if(imseq!="00")
				{
					ddlInvMfr.Items.FindByValue(imseq.Trim()).Selected=true;
					for (int i=0; i<dgdAdr.Items.Count; i++)
					{
						if (((Label)dgdAdr.Items[i].FindControl("lblEInfMfr")).Text.Trim() == ddlInvMfr.SelectedItem.Text.Trim())
						{
							((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Enabled = true;
							dgdAdr.Items[i].ForeColor=System.Drawing.Color.Red;
						}
						else
						{
							//					((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Checked = false;
							((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Enabled = false;
							dgdAdr.Items[i].ForeColor=System.Drawing.Color.Black;
						}
					}
				}
			}
			else
			{
				//Message
				lblContInfo.Text = "�L���s�����X����ơA�нT�{�X���s��";
//				tblCont.Visible = false;
			}
			dr.Close();
		}
		#endregion

		#region ���J�X�����s�i�������
		private void LoadAdr(string contno)
		{
			if (contno == null || contno.Trim().Length != 6)
			{
				jsAlertMsg("CONTNODATAERROR", "�X���s�����ŭȩή榡���~�A�гq���p���H");
				return;
			}

			Advertisements adr = new Advertisements();
			DataSet ds = adr.GetAdvertisements(contno);
			DataView dv = ds.Tables[0].DefaultView;
			dv.RowFilter="adr_fginved <> '1'";
			dgdAdr.DataSource = dv;
			dgdAdr.DataBind();

			if (dv.Count>0)
			{
				lblAdrInfo.Text = "���X���s�i���";
				dgdAdr.Visible = true;
				pnlOptions.Visible = true;
				MatchCheckBox();
				//				FormatAdr();
			}
			else
			{
				lblAdrInfo.Text = "���X���|�L�s�i���";
				dgdAdr.Visible = false;
				pnlOptions.Visible = false;
			}
		}
		#endregion

		#region �Ĥ@��Ū�J�s�i������ƮɡA��H�etag�������ХܥX��
		private void MatchCheckBox()
		{
			//�u���Ĥ@�����J�~�n���A�ҥH�n�W�ߥX��
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				if (dgdAdr.Items[i].Cells[15].Text.Trim() == "v")
				{
					((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Checked = true;
				}
			}
		}
		#endregion

		#region �s���o���t�ӤU�Ԧ����
		private void Bind_ddlInvMfr(string contno)
		{

			string imseq = Request.QueryString["ImSeq"];
			InvMfrs im = new InvMfrs();
			DataSet ds = im.GetInvMfr(contno);
			DataRow dr;
			dr=ds.Tables[0].NewRow();
			dr["im_nm"]="�п��...";
			dr["im_imseq"]="00";
			ds.Tables[0].Rows.Add(dr);
			DataView dv = ds.Tables[0].DefaultView;

			ddlInvMfr.DataTextField = "im_nm";
			ddlInvMfr.DataValueField = "im_imseq";
			ddlInvMfr.DataSource = dv;
			ddlInvMfr.DataBind();
//			if(imseq=="")
//				ddlInvMfr.Items.FindByValue("00").Selected=true;
//			else
				ddlInvMfr.Items.FindByValue(imseq.Trim()).Selected=true;
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
				throw new Exception("��Ʈw��͵o���t�Ӹ�ƿ��~�A�гq���p���H");
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

				//�ˬd���
				if (DateTime.Today >= DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyyMMdd", null))
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked = false;
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Enabled = false;
				}


				//�s�i����G�ഫ��yyyy/MM/dd
				dgdAdr.Items[i].Cells[3].Text = DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyyMMdd", null).ToString("yyyy/MM/dd");

				
				//--------------�w�g�睊
				//				//�s�i�����G�ഫ�������B�����B�`��
				//				string oriAdCate = dgdAdr.Items[i].Cells[5].Text.Trim();
				//				string transAdCate = "N/A";
				//				switch(oriAdCate)
				//				{
				//					case "M":
				//						transAdCate = "����";
				//						break;
				//					case "I":
				//						transAdCate = "����";
				//						break;
				//					case "N":
				//						transAdCate = "�`��";
				//						break;
				//					default:
				//						throw new Exception("��Ʈw��ͼs�i������ƿ��~�A�гq���p���H");
				//						break;
				//				}
				//				dgdAdr.Items[i].Cells[5].Text = transAdCate;
				//				//�s�i��m�G�ഫ������
				//				string oriKeyword = ((Label)dgdAdr.Items[i].Cells[6].FindControl("lblEKeyword")).Text.Trim();
				//				string transKeyword = "N/A";
				//				switch(oriKeyword)
				//				{
				//					case "h0":
				//						transKeyword = "����";
				//						break;
				//					case "h1":
				//						transKeyword = "�k�@";
				//						break;
				//					case "h2":
				//						transKeyword = "�k�G";
				//						break;
				//					case "h3":
				//						transKeyword = "�k�T";
				//						break;
				//					case "h4":
				//						transKeyword = "�k�|";
				//						break;
				//					case "w1":
				//						transKeyword = "�k��@";
				//						break;
				//					case "w2":
				//						transKeyword = "�k��G";
				//						break;
				//					case "w3":
				//						transKeyword = "�k��T";
				//						break;
				//					case "w4":
				//						transKeyword = "�k��|";
				//						break;
				//					case "w5":
				//						transKeyword = "�k�夭";
				//						break;
				//					case "w6":
				//						transKeyword = "�k�夻";
				//						break;
				//					default:
				//						throw new Exception("��Ʈw��ͼs�i��m��ƿ��~�A�гq���p���H");
				//						break;
				//				}
				//				dgdAdr.Items[i].Cells[6].Text = transKeyword;
				//				//�o���t�ӡG���m�W
				//				string oriImSeq = ((Label)dgdAdr.Items[i].Cells[6].FindControl("lblEInvMfr")).Text.Trim();
				//				dgdAdr.Items[i].Cells[12].Text = ddlInvMfr.Items.FindByValue(oriImSeq).Text.Trim();
			}
		}
		#endregion

		#region ����A�M��
		private void btnSelAll_Click(object sender, System.EventArgs e)
		{
//			for (int i=0; i<dgdAdr.Items.Count; i++)
//			{
//				//���ˬd���
//				if (DateTime.Today >= DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyy/MM/dd", null))
//				{
//					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked = false;
//					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Enabled = false;
//				}
//				else
//				{
//					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked = true;
//				}
//			}

//			LoadAdr(lblContNo.Text.Trim());
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//���ˬd�O�_Enable
				if (((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Enabled == true)
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked = true;
				}
			}
		}

		private void btnDeSelAll_Click(object sender, System.EventArgs e)
		{
//			for (int i=0; i<dgdAdr.Items.Count; i++)
//			{
//				//���ˬd���
//				if (DateTime.Today >= DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyy/MM/dd", null))
//				{
//					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Enabled = false;
//				}
//
//				((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked = false;
//			}	
//			LoadAdr(lblContNo.Text.Trim());	
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//���ˬd�O�_Enable
				if (((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Enabled == true)
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked = false;
				}
			}
		}
		#endregion

		#region �T�w�w�g�Ŀ諸�s�i��ơA�A���@����z�P�έp�A�H�o���t�Ӧ���H�B�s�i�����sort
		private void btnConfirmSelected_Click(object sender, System.EventArgs e)
		{
//			Bind_dlList(contno);
			int j=0;
			Advertisements adr = new Advertisements();
			for(int i=0; i<dgdAdr.Items.Count; i++){
				if((((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Enabled == true) && (((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Checked == true))
				{
					adr.UpdateAdrFginved(lblContNo.Text.Trim(), dgdAdr.Items[i].Cells[1].Text.Trim(), dgdAdr.Items[i].Cells[2].Text.Trim(), "v");
					j++;
				}
				else if((((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Enabled == true) && (((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Checked == false))
				{
					adr.UpdateAdrFginved(lblContNo.Text.Trim(), dgdAdr.Items[i].Cells[1].Text.Trim(), dgdAdr.Items[i].Cells[2].Text.Trim(), "");
				}
				//				else
//					adr.UpdateAdrFginved(lblContNo.Text.Trim(), dgdAdr.Items[i].Cells[1].Text.Trim(), dgdAdr.Items[i].Cells[2].Text.Trim(), "");
			}
			if(j>0)
				Response.Redirect("IA1ConfirmChecked.aspx?ContNo="+lblContNo.Text.Trim()+"&Imseq="+ddlInvMfr.SelectedItem.Value.Trim());
			else
				jsAlertMsg("", "�z�S������������!!");
		}
		#endregion

		private void ddlInvMfr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				if (((Label)dgdAdr.Items[i].FindControl("lblEInfMfr")).Text.Trim() == ddlInvMfr.SelectedItem.Text.Trim())
				{
					((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Enabled = true;
					dgdAdr.Items[i].ForeColor=System.Drawing.Color.Red;
				}
				else
				{
//					((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Checked = false;
					((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Enabled = false;
					dgdAdr.Items[i].ForeColor=System.Drawing.Color.Black;
				}
			}
		}


	}
}
