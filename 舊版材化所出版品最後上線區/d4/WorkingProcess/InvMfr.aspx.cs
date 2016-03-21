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
	/// Summary description for AdrInvoice.
	/// </summary>
	public class InvMfr : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Label lblOldIm;
		protected System.Web.UI.WebControls.DataGrid dgdOldInvMfr;
		protected System.Web.UI.WebControls.Panel pnlOldIm;
		protected System.Web.UI.WebControls.TextBox tbxImSeq;
		protected System.Web.UI.WebControls.TextBox tbxImMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxImNm;
		protected System.Web.UI.WebControls.TextBox tbxImJbti;
		protected System.Web.UI.WebControls.TextBox tbxImAddr;
		protected System.Web.UI.WebControls.TextBox tbxImZip;
		protected System.Web.UI.WebControls.TextBox tbxImTel;
		protected System.Web.UI.WebControls.TextBox tbxImFax;
		protected System.Web.UI.WebControls.TextBox tbxImCell;
		protected System.Web.UI.WebControls.TextBox tbxImEmail;
		protected System.Web.UI.WebControls.Button btnAddIm;
		protected System.Web.UI.WebControls.Label lblNewIm;
		protected System.Web.UI.WebControls.DataGrid dgdNewInvMfr;
		protected System.Web.UI.WebControls.Panel pnlNewIm;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DropDownList ddlTaxTp;
		protected System.Web.UI.WebControls.DropDownList ddlFgItri;
		protected System.Web.UI.WebControls.DropDownList ddlInvcd;
		protected System.Web.UI.WebControls.DropDownList ddlInvCd;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{

				tbxImMfrNo.Text = Request.QueryString["mfrno"];
//				Response.Write(Request.QueryString["mfrno"]);
				//�ˬd�ܼơA�o�ˤj���i�H�L�o�@��
				string new_contno = "";
				if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
				{
					throw new Exception("�䤣��X���s��");
				}
				else
				{
					new_contno = Request.QueryString["NewContNo"];
					Contracts cont_new = new Contracts();
					SqlDataReader dr_new = cont_new.GetSingleContractByContNo(new_contno);

					dr_new.Read();
					tbxImMfrNo.Text = dr_new["cont_mfrno"].ToString();
					if(tbxImMfrNo.Text.Trim() == "")
						tbxImMfrNo.Text = Request.QueryString["mfrno"];
					dr_new.Close();
//				Response.Write("test");
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

//				if (tbxOldContNo.Text.Trim() == "")
//				{
//					jsAlertMsg("NOOLDCONT", "�L���v�X����ơA�ҥH���a�J�ӦX���o���t�Ӹ��");
//				}
//				else
//				{
//					old_contno = tbxOldContNo.Text.Trim();
//				}
//				Response.Write(Request.QueryString["mfrno"]);
				Bind_dgdOldInvMfr(old_contno);
				Bind_NewInvMfr(new_contno);
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
			this.dgdOldInvMfr.SelectedIndexChanged += new System.EventHandler(this.dgdOldInvMfr_SelectedIndexChanged);
			this.btnAddIm.Click += new System.EventHandler(this.btnAddIm_Click);
			this.dgdNewInvMfr.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdNewInvMfr_CancelCommand);
			this.dgdNewInvMfr.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdNewInvMfr_EditCommand);
			this.dgdNewInvMfr.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdNewInvMfr_UpdateCommand);
			this.dgdNewInvMfr.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdNewInvMfr_DeleteCommand);
			this.ID = "InvMfr";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region ���v�X�����o���t�Ӧ���H���
		private void Bind_dgdOldInvMfr(string contno)
		{
			if (contno.Trim() == "")
			{
				lblOldIm.Text = "�L���v�X���o���t�Ӧ���H���";
				dgdOldInvMfr.Visible = false;
				return;
			}

			InvMfrs im = new InvMfrs();
			DataSet ds = im.GetInvMfr(contno);
			DataView dv = ds.Tables[0].DefaultView;
			dgdOldInvMfr.DataSource = dv;
			dgdOldInvMfr.DataBind();

			if (dv.Count>0)
			{
				lblOldIm.Text = "���v�X���o���t�Ӧ���H���";
				dgdOldInvMfr.Visible = true;

				for (int i=0; i<dgdOldInvMfr.Items.Count; i++)
				{
					try
					{
						//�䪺��Ҥ��B�|���Nshow
						dgdOldInvMfr.Items[i].Cells[13].Text = ddlFgItri.Items.FindByValue(dgdOldInvMfr.Items[i].Cells[13].Text.Trim()).Text;
					}
					catch
					{
						//��L�������@��
						dgdOldInvMfr.Items[i].Cells[13].Text = "�@��";
					}
				}
			}
			else
			{
				lblOldIm.Text = "�L���v�X���o���t�Ӧ���H���";
				dgdOldInvMfr.Visible = false;
			}
		}
		#endregion

		#region ���X�����o���t�Ӧ���H���
		private void Bind_NewInvMfr(string contno)
		{
			InvMfrs im = new InvMfrs();
			DataSet ds = im.GetInvMfr(contno);
			DataView dv = ds.Tables[0].DefaultView;
			dgdNewInvMfr.DataSource = dv;
			dgdNewInvMfr.DataBind();


			if (dv.Count>0)
			{
				lblNewIm.Text = "���X���o���t�Ӧ���H���";
				dgdNewInvMfr.Visible = true;

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
				lblNewIm.Text = "���X���|�L�o���t�Ӧ���H���";
				dgdNewInvMfr.Visible = false;
			}
		}
		#endregion

		#region �M�����
		private void ClearForm()
		{
			tbxImSeq.Text = "";
			tbxImMfrNo.Text = "";
			tbxImNm.Text = "";
			tbxImJbti.Text = "";
			tbxImAddr.Text = "";
			tbxImZip.Text = "";
			tbxImTel.Text = "";
			tbxImFax.Text = "";
			tbxImCell.Text = "";
			tbxImEmail.Text = "";
			ddlInvCd.SelectedIndex = 0;
			ddlTaxTp.SelectedIndex = 0;
			ddlFgItri.SelectedIndex = 0;
		}
		#endregion

		#region �s�W�o���t�Ӧ���H���
		private void btnAddIm_Click(object sender, System.EventArgs e)
		{
			string mfrno = tbxImMfrNo.Text.Trim();
			string nm = tbxImNm.Text.Trim();
			string jbti = tbxImJbti.Text.Trim();
			string addr = tbxImAddr.Text.Trim();
			string zip = tbxImZip.Text.Trim();
			string tel = tbxImTel.Text.Trim();
			string fax = tbxImFax.Text.Trim();
			string cell = tbxImCell.Text.Trim();
			string email = tbxImEmail.Text.Trim();
			string invcd = ddlInvCd.SelectedItem.Value;
			string taxtp = ddlTaxTp.SelectedItem.Value;
			string fgitri = ddlFgItri.SelectedItem.Value;
			string contno = Request.QueryString["NewContNo"];

			InvMfrs im = new InvMfrs();
			string new_imseq = im.AddInvMfr(contno, mfrno, nm, jbti, addr, zip, tel, fax, cell, email, invcd, taxtp, fgitri);
			
			if (new_imseq=="0" || new_imseq=="00")
			{
				jsAlertMsg("ADDIMFAILED", "�L�k�s�W�o���t�Ӹ�ơA�гq���p���H");
				return;
			}
		
			Bind_NewInvMfr(contno);

			ClearForm();
		}
		#endregion


		#region �R���o���t�Ӧ���H���
		private void dgdNewInvMfr_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string contno = Request.QueryString["NewContNo"].Trim();
			string imseq = e.Item.Cells[1].Text.Trim();
			
			InvMfrs im = new InvMfrs();
			bool flag = im.DeleteIm(contno, imseq);
			if(!flag)
				jsAlertMsg("LOADIMFAILED", "���o���t�Ӧ��������, ����R��");
			else
				Bind_NewInvMfr(contno);
		}
		#endregion


		#region ���J���v�X���o���t�Ӧ���H���
		private void dgdOldInvMfr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string mfrno = dgdOldInvMfr.SelectedItem.Cells[2].Text.Trim();
			string nm = dgdOldInvMfr.SelectedItem.Cells[3].Text.Trim();
			string jbti = dgdOldInvMfr.SelectedItem.Cells[4].Text.Trim().Replace("&nbsp;", "");
			string addr = dgdOldInvMfr.SelectedItem.Cells[5].Text.Trim().Replace("&nbsp;", "");
			string zip = dgdOldInvMfr.SelectedItem.Cells[6].Text.Trim().Replace("&nbsp;", "");
			string tel = dgdOldInvMfr.SelectedItem.Cells[7].Text.Trim().Replace("&nbsp;", "");
			string fax = dgdOldInvMfr.SelectedItem.Cells[8].Text.Trim().Replace("&nbsp;", "");
			string cell = dgdOldInvMfr.SelectedItem.Cells[9].Text.Trim().Replace("&nbsp;", "");
			string email = dgdOldInvMfr.SelectedItem.Cells[10].Text.Trim().Replace("&nbsp;", "");
			string invcd = dgdOldInvMfr.SelectedItem.Cells[11].Text.Trim();
			string taxtp = dgdOldInvMfr.SelectedItem.Cells[12].Text.Trim();
			string fgitri = dgdOldInvMfr.SelectedItem.Cells[13].Text.Trim();

			tbxImSeq.Text = "";
			tbxImMfrNo.Text = mfrno;
			tbxImNm.Text = nm;
			tbxImJbti.Text = jbti;
			tbxImAddr.Text = addr;
			tbxImZip.Text = zip;
			tbxImTel.Text = tel;
			tbxImFax.Text = fax;
			tbxImCell.Text = cell;
			tbxImEmail.Text = email;

			if (ddlInvCd.Items.FindByValue(invcd) != null)
			{
				ddlInvCd.Items.FindByValue(invcd).Selected = true;
			}
			else
			{
				ddlInvCd.SelectedIndex = 0;
			}

			if (ddlTaxTp.Items.FindByValue(taxtp) != null)
			{
				ddlTaxTp.Items.FindByValue(taxtp).Selected = true;
			}
			else
			{
				ddlTaxTp.SelectedIndex = 0;
			}

			if (ddlFgItri.Items.FindByValue(fgitri) != null)
			{
				ddlFgItri.Items.FindByValue(fgitri).Selected = true;
			}
			else
			{
				ddlFgItri.SelectedIndex = 0;
			}		
		}
		#endregion

		private void dgdNewInvMfr_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dgdNewInvMfr.EditItemIndex = e.Item.ItemIndex;
			string contno = Request.QueryString["NewContNo"];
			Bind_NewInvMfr(contno);
			DataGridItem dgi = dgdNewInvMfr.Items[e.Item.ItemIndex];
			//�]�wtextbox���e��
			((TextBox)dgi.Cells[2].Controls[0]).Width = Unit.Pixel(60);
			((TextBox)dgi.Cells[3].Controls[0]).Width = Unit.Pixel(60);
			((TextBox)dgi.Cells[4].Controls[0]).Width = Unit.Pixel(40);
			((TextBox)dgi.Cells[5].Controls[0]).Width = Unit.Pixel(30);
			((TextBox)dgi.Cells[6].Controls[0]).Width = Unit.Pixel(120);
			((TextBox)dgi.Cells[7].Controls[0]).Width = Unit.Pixel(60);
			((TextBox)dgi.Cells[8].Controls[0]).Width = Unit.Pixel(60);
			((TextBox)dgi.Cells[9].Controls[0]).Width = Unit.Pixel(60);
			((TextBox)dgi.Cells[10].Controls[0]).Width = Unit.Pixel(80);
			((DropDownList)dgi.Cells[11].Controls[1]).Items.FindByValue(dgi.Cells[14].Text.Trim()).Selected = true;
			((DropDownList)dgi.Cells[12].Controls[1]).Items.FindByValue(dgi.Cells[15].Text.Trim()).Selected = true;
			((DropDownList)dgi.Cells[13].Controls[1]).Items.FindByValue(dgi.Cells[16].Text.Trim()).Selected = true;
		}

		private void dgdNewInvMfr_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dgdNewInvMfr.EditItemIndex = -1;
			string contno = Request.QueryString["NewContNo"];
			Bind_NewInvMfr(contno);
		}

		private void dgdNewInvMfr_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGridItem dgi = dgdNewInvMfr.Items[e.Item.ItemIndex];
		
			string imseq = dgi.Cells[1].Text.Trim();
			string mfrno = ((TextBox)dgi.Cells[2].Controls[0]).Text.Trim();
			string nm = ((TextBox)dgi.Cells[3].Controls[0]).Text.Trim();
			string jbti = ((TextBox)dgi.Cells[4].Controls[0]).Text.Trim();
			string zip = ((TextBox)dgi.Cells[5].Controls[0]).Text.Trim();
			string addr = ((TextBox)dgi.Cells[6].Controls[0]).Text.Trim();
			string tel = ((TextBox)dgi.Cells[7].Controls[0]).Text.Trim();
			string fax = ((TextBox)dgi.Cells[8].Controls[0]).Text.Trim();
			string cell = ((TextBox)dgi.Cells[9].Controls[0]).Text.Trim();
			string email = ((TextBox)dgi.Cells[10].Controls[0]).Text.Trim();
			string invcd = ((DropDownList)dgi.Cells[11].Controls[1]).SelectedItem.Value;
			string taxtp = ((DropDownList)dgi.Cells[12].Controls[1]).SelectedItem.Value;
			string fgitri = ((DropDownList)dgi.Cells[13].Controls[1]).SelectedItem.Value;
			string contno = Request.QueryString["NewContNo"];

			InvMfrs im = new InvMfrs();
			im.UpdateInvMfr(contno, imseq, mfrno, nm, jbti, addr, zip, tel, fax, cell, email, invcd, taxtp, fgitri);
		
			dgdNewInvMfr.EditItemIndex = -1;
			Bind_NewInvMfr(contno);

		}

	}
}
