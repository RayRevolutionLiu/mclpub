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
	/// Summary description for FreeBook.
	/// </summary>
	public class FreeBook : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgdOldOr;
		protected System.Web.UI.WebControls.TextBox tbxOrSeq;
		protected System.Web.UI.WebControls.TextBox tbxOrJbti;
		protected System.Web.UI.WebControls.TextBox tbxOrZip;
		protected System.Web.UI.WebControls.TextBox tbxOrAddr;
		protected System.Web.UI.WebControls.TextBox tbxOrTel;
		protected System.Web.UI.WebControls.TextBox tbxOrFax;
		protected System.Web.UI.WebControls.TextBox tbxOrCell;
		protected System.Web.UI.WebControls.TextBox tbxOrEmail;
		protected System.Web.UI.WebControls.DropDownList ddlOrMoSea;
		protected System.Web.UI.WebControls.Button btnAddOr;
		protected System.Web.UI.WebControls.Button btnUpdateOr;
		protected System.Web.UI.WebControls.Label lblOrMsg;
		protected System.Web.UI.WebControls.DataGrid dgdNewOr;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.DataGrid dgdOldFreeBk;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvSDate;
		protected System.Web.UI.WebControls.RegularExpressionValidator revSDate;
		protected System.Web.UI.WebControls.DropDownList ddlFbkBkCd;
		protected System.Web.UI.WebControls.DropDownList ddlMtpCd;
		protected System.Web.UI.WebControls.TextBox tbxPubMnt;
		protected System.Web.UI.WebControls.TextBox tbxUnPubMnt;
		protected System.Web.UI.WebControls.DropDownList ddlOrSeq;
		protected System.Web.UI.WebControls.Button btnUpdateFreeBk;
		protected System.Web.UI.WebControls.Label lblFreeBkMsg;
		protected System.Web.UI.WebControls.DataGrid dgdNewFreeBk;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvEDate;
		protected System.Web.UI.WebControls.RegularExpressionValidator revEDate;
		protected System.Web.UI.WebControls.Label lblyymm;
		protected System.Web.UI.WebControls.Label lblyymm2;
		protected System.Web.UI.WebControls.Label lblOldOr;
		protected System.Web.UI.WebControls.Label lblOldFreeBk;
		protected System.Web.UI.WebControls.Button btnAddFreeBk;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvPubMnt;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvUnPubMnt;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPubMnt;
		protected System.Web.UI.WebControls.RegularExpressionValidator revUnPubMnt;
		protected System.Web.UI.WebControls.TextBox tbxMaSDate;
		protected System.Web.UI.WebControls.TextBox tbxMaEDate;
		protected System.Web.UI.WebControls.TextBox tbxOrInm;
		protected System.Web.UI.WebControls.TextBox tbxOrNm;
		protected System.Web.UI.WebControls.Button btnCancelOr;
		protected System.Web.UI.WebControls.Button btnCancelFreeBk;
		protected System.Web.UI.WebControls.Literal litAlert;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				string new_contno = "";
				if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
				{
					throw new Exception("�L�X���s���A�{�����~�A�гq���p���H");
				}
				else
				{
					new_contno = Request.QueryString["NewContNo"].Trim();
				}

				string old_contno = "";
				if (Request.QueryString["OldContNo"] == null || Request.QueryString["OldContNo"] == "")
				{
					//�b���@�X���ɡA�q�X����ƥh��.....
					Contracts cont = new Contracts();
					SqlDataReader dr = cont.GetSingleContractByContNo(new_contno);
					dr.Read();
					try
					{
						old_contno = dr["cont_oldcontno"].ToString();
					}
					catch
					{
						//Response.Write(ex.Message + new_contno);
						throw new Exception("�䤣��X����ơA�гq���p���H");
					}
					dr.Close();

					if (old_contno == "")
						jsAlertMsg("NOOLDCONTNO", "�L���v�X���s���A���a�J���v��ơF�`�N�G�Y���X�������v�ѦҦX���A�h���t�αa�J��Ʈɵo�Ϳ��~�A�гq���p���H�C");
				}
				else
				{
					old_contno = Request.QueryString["OldContNo"];
				}


				string custno = "";
				if (Request.QueryString["CustNo"] == null || Request.QueryString["CustNo"] == "")
				{
					throw new Exception("�䤣��Ȥ�s��");
				}
				else
				{
					custno = Request.QueryString["CustNo"];
				}
				LoadCustToBeDefaultOr(custno);

				//�T�Ӱ�Ū����ơA���v����H�A���v�خѡA�l�H���O
				if (old_contno != "")
				{
					Bind_dgdOldOr(old_contno);
					Bind_dgdOldFreeBk(old_contno);
				}
				else
				{
					//�]�w��T
					dgdOldOr.Visible = false;
					lblOldOr.Text = "[�L���v�X�����x����H���]";

					dgdOldFreeBk.Visible = false;
					lblOldFreeBk.Text = "[�L���v�X���خѸ��]";
				}
				Bind_ddlMtpCd();

				//���X������H�B���X���خ�
				Bind_dgdNewOr(new_contno);
				Bind_dgdNewFreeBk(new_contno);

				//�]�w�ק���s��invisible
				btnUpdateOr.Visible = false;
				btnCancelOr.Visible = false;
				btnUpdateFreeBk.Visible = false;
				btnCancelFreeBk.Visible = false;
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
			this.btnAddOr.Click += new System.EventHandler(this.btnAddOr_Click);
			this.btnUpdateOr.Click += new System.EventHandler(this.btnUpdateOr_Click);
			this.btnAddFreeBk.Click += new System.EventHandler(this.btnAddFreeBk_Click);
			this.btnUpdateFreeBk.Click += new System.EventHandler(this.btnUpdateFreeBk_Click);
			this.dgdNewFreeBk.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdNewFreeBk_DeleteCommand);
			this.dgdNewFreeBk.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdNewFreeBk_ItemDataBound);
			this.dgdNewFreeBk.SelectedIndexChanged += new System.EventHandler(this.dgdNewFreeBk_SelectedIndexChanged);
			this.dgdOldOr.SelectedIndexChanged += new System.EventHandler(this.dgdOldOr_SelectedIndexChanged);
			this.dgdNewOr.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdNewOr_DeleteCommand);
			this.dgdNewOr.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgdNewOr_ItemDataBound);
			this.dgdNewOr.SelectedIndexChanged += new System.EventHandler(this.dgdNewOr_SelectedIndexChanged);
			this.btnCancelOr.Click += new System.EventHandler(this.btnCancelOr_Click);
			this.btnCancelFreeBk.Click += new System.EventHandler(this.btnCancelFreeBk_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region ���^�����~�l�H���O�W��
		protected object GetYNCh(object fgmosea)
		{
			if (Convert.ToString(fgmosea) == "1")
				return "��~";
			else
				return "�ꤺ";
		}
		#endregion
		
		#region ���^�l�H���O�W��
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
				strReturn = mtpdv[0]["mtp_nm"].ToString().Trim();
			}
			mtpdv.RowFilter = "";

			return strReturn;
		}
		#endregion

		#region �s�����v�X������H��Ƹ��
		private void Bind_dgdOldOr(string contno)
		{
			if (contno == "")
			{
				throw new Exception("�X���s�����i�ť�");
			}

			FreeBooks fbk = new FreeBooks();
			DataSet ds = fbk.GetOrByContNo(contno);
			DataView dv = ds.Tables[0].DefaultView;
			dgdNewOr.DataSource = dv;
			dgdNewOr.DataBind();

			if (dv.Count>0)
			{
				dgdOldOr.Visible = true;
				lblOldOr.Text = "[���v�X�����x����H���]";
			}
			else
			{
				dgdOldOr.Visible = false;
				lblOldOr.Text = "[�L���v�X�����x����H���]";
			}
		}
		#endregion

		#region �s�����X������H��Ƹ��
		private void Bind_dgdNewOr(string contno)
		{
			if (contno == "")
			{
				throw new Exception("�X���s�����i�ť�");
			}

			FreeBooks fbk = new FreeBooks();
			DataSet ds = fbk.GetOrByContNo(contno);
			DataView dv = ds.Tables[0].DefaultView;
			dgdNewOr.DataSource = dv;
			dgdNewOr.DataBind();

			//���K�s������H���U�Ԧ����
			Bind_ddlOr(dv);


			if (dv.Count>0)
			{
				lblOrMsg.Text = "[���X�����x����H���]";
				dgdNewOr.Visible = true;
			}
			else
			{
				lblOrMsg.Text = "[���X���|�L���x����H���]";
				dgdNewOr.Visible = false;
			}
		}
		#endregion

		#region �s�����v�خѸ��
		private void Bind_dgdOldFreeBk(string contno)
		{
			FreeBooks fbk = new FreeBooks();
			DataSet ds = fbk.GetFbkOrByContNo(contno);
			DataView dv = ds.Tables[0].DefaultView;
			dgdOldFreeBk.DataSource = dv;
			dgdOldFreeBk.DataBind();

			if (dv.Count>0)
			{
				dgdOldFreeBk.Visible = true;
				lblOldFreeBk.Text = "[���v�X���خѸ��]";

//				for (int i=0; i<dv.Count; i++)
//				{
//					string bkcd = dgdNewFreeBk.Items[i].Cells[5].Text.Trim();
//					try
//					{
//						dgdNewFreeBk.Items[i].Cells[5].Text = ddlFbkBkCd.Items.FindByValue(bkcd).Text;
//					}
//					catch
//					{
//						dgdNewFreeBk.Items[i].Cells[5].Text = "(�ഫ����)";
//					}
//				}
			}
			else
			{
				dgdOldFreeBk.Visible = false;
				lblOldFreeBk.Text = "[�L���v�X���خѸ��]";
			}
		}
		#endregion

		#region �s�����X���خѸ��
		private void Bind_dgdNewFreeBk(string contno)
		{
			FreeBooks fbk = new FreeBooks();
			DataSet ds = fbk.GetFbkOrByContNo(contno);
			DataView dv = ds.Tables[0].DefaultView;
			dgdNewFreeBk.DataSource = dv;
			dgdNewFreeBk.DataBind();
		
			if (dv.Count>0)
			{
				lblFreeBkMsg.Text = "[���X���خѸ��]";
				dgdNewFreeBk.Visible = true;

				for (int i=0; i<dv.Count; i++)
				{
					string bkcd = dgdNewFreeBk.Items[i].Cells[5].Text.Trim();
					try
					{
						dgdNewFreeBk.Items[i].Cells[5].Text = ddlFbkBkCd.Items.FindByValue(bkcd).Text;
					}
					catch
					{
						dgdNewFreeBk.Items[i].Cells[5].Text = "(�ഫ����)";
					}
				}
			}
			else
			{
				lblFreeBkMsg.Text = "[���X���|�L�خѸ��]";
				dgdNewFreeBk.Visible = false;
			}
		}
		#endregion

		#region �s���l�H���O���
		private void Bind_ddlMtpCd()
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
			
			ddlMtpCd.DataSource = mtpdv;
			ddlMtpCd.DataTextField = "mtp_nm";
			ddlMtpCd.DataValueField = "mtp_mtpcd";
			ddlMtpCd.DataBind();
		}
		#endregion

		#region �s������H���
		private void Bind_ddlOr(DataView dv)
		{
			ddlOrSeq.DataSource = dv;
			ddlOrSeq.DataTextField = "or_nm";
			ddlOrSeq.DataValueField = "or_oritem";
			ddlOrSeq.DataBind();
			
			if (dv.Count>0)
			{
				ddlOrSeq.Enabled = true;
				ddlOrSeq.BackColor = Color.Transparent;
			}
			else
			{
				ddlOrSeq.Enabled = false;
				ddlOrSeq.BackColor = Color.LightGray;
			}
		}
		#endregion

		#region ���J�Ȥ��Ƨ@���w�]����H���
		private void LoadCustToBeDefaultOr(string custno)
		{
			Customers cust = new Customers();
//			SqlDataReader dr = cust.GetSingleCustomer(custno);
			SqlDataReader dr = cust.GetMfrCustByCustNo(custno);
			
			if (dr.Read())
			{
				tbxOrInm.Text = dr["mfr_inm"].ToString().Trim();
				tbxOrNm.Text = dr["cust_nm"].ToString().Trim();
				tbxOrJbti.Text = dr["cust_jbti"].ToString().Trim();
				tbxOrTel.Text = dr["cust_tel"].ToString().Trim();
				tbxOrCell.Text = dr["cust_cell"].ToString().Trim();
				tbxOrFax.Text = dr["cust_fax"].ToString().Trim();
				tbxOrEmail.Text = dr["cust_email"].ToString().Trim();
			}
			dr.Close();
			
			//�����~���O�N���ޤF
			ddlOrMoSea.SelectedIndex = 0;
		}
		#endregion

		#region ���J�浧����H���
		private void dgdOldOr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			tbxOrInm.Text = "";
			tbxOrNm.Text = "";
			tbxOrJbti.Text = "";
			tbxOrTel.Text = "";
			tbxOrCell.Text = "";
			tbxOrFax.Text = "";
			tbxOrEmail.Text = "";
		
			string strmosea = dgdOldOr.SelectedItem.Cells[10].Text.Trim();
			if (ddlOrMoSea.Items.FindByText(strmosea) != null)
			{
				ddlOrMoSea.Items.FindByText(strmosea).Selected = true;
			}
			else
			{
				ddlOrMoSea.SelectedIndex = 0;
			}
		}
		#endregion

		#region �s�W����H
		private void btnAddOr_Click(object sender, System.EventArgs e)
		{
			string new_contno = "";
			if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
			{
				throw new Exception("�䤣��X���s��");
			}
			else
			{
				new_contno = Request.QueryString["NewContNo"];
			}
			string or_inm = tbxOrInm.Text.Trim();
			string or_nm = tbxOrNm.Text.Trim();
			string or_jbti = tbxOrJbti.Text.Trim();
			string or_addr = tbxOrAddr.Text.Trim();
			string or_zip = tbxOrZip.Text.Trim();
			string or_tel = tbxOrTel.Text.Trim();
			string or_fax = tbxOrFax.Text.Trim();
			string or_cell = tbxOrCell.Text.Trim();
			string or_email = tbxOrEmail.Text.Trim();
			string or_fgmosea = ddlOrMoSea.SelectedItem.Value.Trim();

			FreeBooks fbk = new FreeBooks();
			
			string or_oritem = fbk.AddOr(new_contno, or_inm, or_nm, or_jbti, or_addr, or_zip, or_tel, or_fax, or_cell, or_email, or_fgmosea);
			
			if (or_oritem == null || or_oritem == "00")
				jsAlertMsg("ADDORFAILED", "�s�W����H����");

			Bind_dgdNewOr(new_contno);
			CleanOrFields();
		}
		#endregion

		#region �ק怜��H
		private void btnUpdateOr_Click(object sender, System.EventArgs e)
		{
			string new_contno = "";
			if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
			{
				throw new Exception("�䤣��X���s��");
			}
			else
			{
				new_contno = Request.QueryString["NewContNo"];
			}

			string or_oritem = "";
			if (tbxOrSeq.Text.Trim() == "")
			{
				throw new Exception("����H�Ǹ����ť�");
			}
			else
			{
				or_oritem = tbxOrSeq.Text.Trim();
			}

			string or_inm = tbxOrInm.Text.Trim();
			string or_nm = tbxOrNm.Text.Trim();
			string or_jbti = tbxOrJbti.Text.Trim();
			string or_addr = tbxOrAddr.Text.Trim();
			string or_zip = tbxOrZip.Text.Trim();
			string or_tel = tbxOrTel.Text.Trim();
			string or_fax = tbxOrFax.Text.Trim();
			string or_cell = tbxOrCell.Text.Trim();
			string or_email = tbxOrEmail.Text.Trim();
			string or_fgmosea = ddlOrMoSea.SelectedItem.Value.Trim();		

			FreeBooks fbk = new FreeBooks();
			fbk.UpdateOr(new_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, or_tel, or_fax, or_cell, or_email, or_fgmosea);

			Bind_dgdNewOr(new_contno);
			CleanOrFields();

			//���íק�A��ܷs�W
			btnAddOr.Visible = true;
			btnUpdateOr.Visible = false;
			btnCancelOr.Visible = false;
		}
		#endregion

		#region ��w�ק糧�X��������H
		private void dgdNewOr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string or_oritem = dgdNewOr.SelectedItem.Cells[2].Text.Trim();
			string or_inm = dgdNewOr.SelectedItem.Cells[3].Text.Trim();
			string or_nm = dgdNewOr.SelectedItem.Cells[4].Text.Trim();
			string or_jbti = dgdNewOr.SelectedItem.Cells[5].Text.Trim();
			string or_zip = dgdNewOr.SelectedItem.Cells[6].Text.Trim();
			string or_addr = dgdNewOr.SelectedItem.Cells[7].Text.Trim();
			string or_tel = dgdNewOr.SelectedItem.Cells[8].Text.Trim();
			string or_fax = dgdNewOr.SelectedItem.Cells[9].Text.Trim();
			string or_cell = dgdNewOr.SelectedItem.Cells[10].Text.Trim().Replace("&nbsp;", "");
			string or_email = dgdNewOr.SelectedItem.Cells[11].Text.Trim().Replace("&nbsp;", "");
			string or_fgmosea = dgdNewOr.SelectedItem.Cells[13].Text.Trim();

			tbxOrSeq.Text = or_oritem;
			tbxOrInm.Text = or_inm;
			tbxOrNm.Text = or_nm;
			tbxOrJbti.Text = or_jbti;
			tbxOrAddr.Text = or_addr;
			tbxOrZip.Text = or_zip;
			tbxOrTel.Text = or_tel;
			tbxOrFax.Text = or_fax;
			tbxOrCell.Text = or_cell;
			tbxOrEmail.Text = or_email;
			if (ddlOrMoSea.Items.FindByValue(or_fgmosea) != null)
				ddlOrMoSea.Items.FindByValue(or_fgmosea).Selected = true;
			else
				ddlOrMoSea.SelectedIndex = 0;

			//���÷s�W�A��ܭק�
			btnAddOr.Visible = false;
			btnUpdateOr.Visible = true;
			btnCancelOr.Visible = true;
		}
		#endregion

		#region �M�Ŧ���H���
		private void CleanOrFields()
		{
			tbxOrSeq.Text = "";
			tbxOrInm.Text = "";
			tbxOrNm.Text = "";
			tbxOrJbti.Text = "";
			tbxOrAddr.Text = "";
			tbxOrZip.Text = "";
			tbxOrTel.Text = "";
			tbxOrFax.Text = "";
			tbxOrCell.Text = "";
			tbxOrEmail.Text = "";
			ddlOrMoSea.SelectedIndex = 0;
		}
		#endregion

		#region �R�����X��������H
		private void dgdNewOr_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string new_contno = "";
			if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
			{
				throw new Exception("�䤣��X���s��");
			}
			else
			{
				new_contno = Request.QueryString["NewContNo"];
			}

			string or_oritem = e.Item.Cells[2].Text.Trim();

			FreeBooks fbk = new FreeBooks();
			int effects = fbk.DeleteOr(new_contno, or_oritem);
			//efffects>0�N�O���l�H���ƩΪ̯ʮѥΨ즹����H
			if (effects>0)
				jsAlertMsg("DELETEORFAILED", "�L�k�R��������H�A�]��������H�����خѩίʮ�");

			Bind_dgdNewOr(new_contno);
			CleanOrFields();

			//���íק�A��ܷs�W
			btnAddOr.Visible = true;
			btnUpdateOr.Visible = false;
		}
		#endregion

		#region �s�W�خ�
		private void btnAddFreeBk_Click(object sender, System.EventArgs e)
		{
			string new_contno = "";
			if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
			{
				throw new Exception("�䤣��X���s��");
			}
			else
			{
				new_contno = Request.QueryString["NewContNo"];
			}

			//������H�~�i�H�s�W�خ�
			if ( !(ddlOrSeq.Items.Count>0) )
			{
				jsAlertMsg("NOORNOFBK", "�Х��W����H��~��s�W�خ�");
				return;
			}

			//�ˬd�ɶ����ᶶ��
			DateTime sdate = DateTime.ParseExact(tbxMaSDate.Text.Trim(), "yyyy/MM", null);
			DateTime edate = DateTime.ParseExact(tbxMaEDate.Text.Trim(), "yyyy/MM", null);
			string ma_sdate = sdate.ToString("yyyyMM");
			string ma_edate = edate.ToString("yyyyMM");

			if (edate<sdate)
			{
				jsAlertMsg("INVALIDDATESECTION", "�خѰ_����Ϭq���~�A���ˬd�ɶ��X�z��");
				return;
			}

			string ma_oritem = ddlOrSeq.SelectedItem.Value;
			string fbk_bkcd = ddlFbkBkCd.SelectedItem.Value;
			string ma_pubmnt = tbxPubMnt.Text.Trim();
			string ma_unpubmnt = tbxUnPubMnt.Text.Trim();
			string ma_mtpcd = ddlMtpCd.SelectedItem.Value;

			//�s�W�خѻP�l�H����
			FreeBooks fbk = new FreeBooks();
			string new_fbkitem = fbk.AddFreeBk(new_contno, fbk_bkcd, ma_oritem, ma_sdate, ma_edate, ma_pubmnt, ma_unpubmnt, ma_mtpcd);
			
			if (new_fbkitem == null || new_fbkitem == "00")
			{
				jsAlertMsg("ADDFREEBOOKFAILED", "�s�W�خѥ���");
				return;
			}

			Bind_dgdNewFreeBk(new_contno);
			CleanFreeBkFields();
		}
		#endregion

		#region ��ܭn�ק諸�خѶ���
		private void dgdNewFreeBk_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string ma_sdate = dgdNewFreeBk.SelectedItem.Cells[3].Text.Trim();
			string ma_edate = dgdNewFreeBk.SelectedItem.Cells[4].Text.Trim();
			string fbk_bkcd = dgdNewFreeBk.SelectedItem.Cells[5].Text.Trim();
			string ma_oritem = dgdNewFreeBk.SelectedItem.Cells[6].Text.Trim();
			string ma_pubmnt = dgdNewFreeBk.SelectedItem.Cells[7].Text.Trim();
			string ma_unpubmnt = dgdNewFreeBk.SelectedItem.Cells[8].Text.Trim();
			string ma_mtpcd = ((Label)dgdNewFreeBk.SelectedItem.Cells[9].FindControl("lblMtpNm")).Text.Trim();

			tbxMaSDate.Text = ma_sdate;
			tbxMaEDate.Text = ma_edate;

			ddlFbkBkCd.SelectedIndex = -1;
			if (ddlFbkBkCd.Items.FindByText(fbk_bkcd) != null)
				ddlFbkBkCd.Items.FindByText(fbk_bkcd).Selected = true;
			else
				ddlFbkBkCd.SelectedIndex = 0;

			ddlOrSeq.SelectedIndex = -1;
			if (ddlOrSeq.Items.FindByText(ma_oritem) != null)
				ddlOrSeq.Items.FindByText(ma_oritem).Selected = true;
			else
				ddlOrSeq.SelectedIndex = 0;

			tbxPubMnt.Text = ma_pubmnt;
			tbxUnPubMnt.Text = ma_unpubmnt;
			
			ddlMtpCd.SelectedIndex = -1;
			if (ddlMtpCd.Items.FindByText(ma_mtpcd) != null)
				ddlMtpCd.Items.FindByText(ma_mtpcd).Selected = true;
			else
				ddlMtpCd.SelectedIndex = 0;

			//���÷s�W�A��ܭק�
			btnAddFreeBk.Visible = false;
			btnUpdateFreeBk.Visible = true;
			btnCancelFreeBk.Visible = true;
		}
		#endregion

		#region �M���خ����
		private void CleanFreeBkFields()
		{
			string ma_sdate = "";
			string ma_edate = "";
			string fbk_bkcd = "";
			string ma_oritem = "";
			string ma_pubmnt = "";
			string ma_unpubmnt = "";
			string ma_mtpcd = "";

			tbxMaSDate.Text = "";
			tbxMaEDate.Text = "";

			ddlFbkBkCd.SelectedIndex = 0;

			ddlOrSeq.SelectedIndex = 0;

			tbxPubMnt.Text = "";
			tbxUnPubMnt.Text = "";
			
			ddlMtpCd.SelectedIndex = 0;
		}
		#endregion

		#region �ק��خ�
		private void btnUpdateFreeBk_Click(object sender, System.EventArgs e)
		{
			string new_contno = "";
			if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
			{
				throw new Exception("�䤣��X���s��");
			}
			else
			{
				new_contno = Request.QueryString["NewContNo"];
			}

			//�קKuser�S�⦬��H�˱��F...�A�ˬd�@���A���M�O���ӥi���
			if ( !(ddlOrSeq.Items.Count>0) )
			{
				jsAlertMsg("NOORNOFBK", "�Х��W����H��~��s�W�خ�");
				return;
			}

			//�ˬd�ɶ����ᶶ��
			DateTime sdate = DateTime.ParseExact(tbxMaSDate.Text.Trim(), "yyyy/MM", null);
			DateTime edate = DateTime.ParseExact(tbxMaEDate.Text.Trim(), "yyyy/MM", null);
			string ma_sdate = sdate.ToString("yyyyMM");
			string ma_edate = edate.ToString("yyyyMM");

			if (edate<sdate)
			{
				jsAlertMsg("INVALIDDATESECTION", "�خѰ_����Ϭq���~�A���ˬd�ɶ��X�z��");
				return;
			}

			string fbk_fbkitem = dgdNewFreeBk.SelectedItem.Cells[2].Text.Trim();
			string ma_oritem = ddlOrSeq.SelectedItem.Value;
			string fbk_bkcd = ddlFbkBkCd.SelectedItem.Value;
			string ma_pubmnt = tbxPubMnt.Text.Trim();
			string ma_unpubmnt = tbxUnPubMnt.Text.Trim();
			string ma_mtpcd = ddlMtpCd.SelectedItem.Value;

			//��delete�Ainsert
			FreeBooks fbk = new FreeBooks();
			string new_fbkitem = fbk.UpdateFreeBk(new_contno, fbk_fbkitem, fbk_bkcd, ma_oritem, ma_sdate, ma_edate, ma_pubmnt, ma_unpubmnt, ma_mtpcd);

			if (new_fbkitem == null || new_fbkitem == "00")
			{
				jsAlertMsg("ADDFREEBOOKFAILED", "�ק��خѥ���");
				return;
			}

			Bind_dgdNewFreeBk(new_contno);
			CleanFreeBkFields();

			//��ܷs�W�A���íק�
			btnAddFreeBk.Visible = true;
			btnUpdateFreeBk.Visible = false;
			btnCancelFreeBk.Visible = false;
		}
		#endregion

		#region �R���خ�
		private void dgdNewFreeBk_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string new_contno = "";
			if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
			{
				throw new Exception("�䤣��X���s��");
			}
			else
			{
				new_contno = Request.QueryString["NewContNo"];
			}	

			string fbk_fbkitem = e.Item.Cells[2].Text.Trim();
			string ma_oritem = e.Item.Cells[6].Text.Trim();
	
			FreeBooks fbk = new FreeBooks();
			bool success = fbk.Delete_1_FreeBk(new_contno, fbk_fbkitem, ma_oritem);

			if (!success)
			{
				jsAlertMsg("DELETEFREEBOOKFAILED", "�R���خѥ���");
			}

			Bind_dgdNewFreeBk(new_contno);
			CleanFreeBkFields();

			//��ܷs�W�A���íק�
			btnAddFreeBk.Visible = true;
			btnUpdateFreeBk.Visible = false;
		}
		#endregion

		#region ����H���R��confirm
		private void dgdNewOr_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			for (int i=0; i<e.Item.Controls[1].Controls.Count; i++)
			{
				if (e.Item.Controls[1].Controls[i] != null)
				{
					if ( ((LinkButton)e.Item.Controls[1].Controls[i]).Text == "�R��" )
						((LinkButton)e.Item.Controls[1].Controls[i]).Attributes.Add("onClick", "return confirm('�T�w�R��?');");
				}
			}
		}
		#endregion

		#region �خѪ��R��confirm
		private void dgdNewFreeBk_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			for (int i=0; i<e.Item.Controls[1].Controls.Count; i++)
			{
				if (e.Item.Controls[1].Controls[i] != null)
				{
					if ( ((LinkButton)e.Item.Controls[1].Controls[i]).Text == "�R��" )
						((LinkButton)e.Item.Controls[1].Controls[i]).Attributes.Add("onClick", "return confirm('�T�w�R��?');");
				}
			}	
		}
		#endregion

		private void btnCancelOr_Click(object sender, System.EventArgs e)
		{
			CleanOrFields();
			string custno = Request.QueryString["CustNo"];
			LoadCustToBeDefaultOr(custno);
			//���íק�A��ܷs�W
			btnAddOr.Visible = true;
			btnUpdateOr.Visible = false;
			btnCancelOr.Visible = false;
		
		}

		private void btnCancelFreeBk_Click(object sender, System.EventArgs e)
		{
			CleanFreeBkFields();

			//��ܷs�W�A���íק�
			btnAddFreeBk.Visible = true;
			btnUpdateFreeBk.Visible = false;
			btnCancelFreeBk.Visible = false;
		
		}
	}
}
