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
	/// Summary description for RemailMaintain.
	/// </summary>
	public class RemailMaintain : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.TextBox tbxMfrNm;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Web.UI.WebControls.TextBox tbxSSDate;
		protected System.Web.UI.WebControls.TextBox tbxSEDate;
		protected System.Web.UI.WebControls.TextBox tbxOrName;
		protected System.Web.UI.WebControls.TextBox tbxOrTel;
		protected System.Web.UI.WebControls.TextBox tbxOrAddr;
		protected System.Web.UI.WebControls.RadioButtonList rblSent;
		protected System.Web.UI.WebControls.LinkButton lnbSearch;
		protected System.Web.UI.WebControls.DataGrid dgdRemail;
		protected System.Web.UI.WebControls.Label lblMessage;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here

			//�[�Jscript������
			if (!IsClientScriptBlockRegistered("JSCALENDAR"))
			{
				System.IO.TextReader tr = System.IO.File.OpenText(Server.MapPath(".") + "\\ClientScripts\\jsCalendar.js");
				string script = tr.ReadToEnd();
				RegisterClientScriptBlock("JSCALENDAR", script);
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
			this.lnbSearch.Click += new System.EventHandler(this.lnbSearch_Click);
			this.dgdRemail.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdRemail_CancelCommand);
			this.dgdRemail.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdRemail_EditCommand);
			this.dgdRemail.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdRemail_UpdateCommand);
			this.dgdRemail.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdRemail_DeleteCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		#region �s�@WHERE����
		private string GetContFilter()
		{
			string strFilter = "";
			int fcount = 0;
			//�q��s��
			if (tbxContNo.Text.Trim() != "")
			{
				if (fcount>0) strFilter += " AND ";
				strFilter += "cont_contno='" + tbxContNo.Text.Trim() + "'";
				fcount++;
			}

			//���q�W��
			if (tbxMfrNm.Text.Trim() != "")
			{
				if (fcount>0) strFilter += " AND ";
				strFilter += "mfr_inm LIKE '%" + tbxMfrNm.Text.Trim() + "%'";
				fcount++;
			}

			//�Τ@�s��
			if (tbxMfrNo.Text.Trim() != "")
			{
				if (fcount>0) strFilter += " AND ";
				strFilter += "cont_mfrno='" + tbxMfrNo.Text.Trim() + "'";
				fcount++;
			}

			//�Ȥ�m�W
			if (tbxCustName.Text.Trim() != "")
			{
				if (fcount>0) strFilter += " AND ";
				strFilter += "cust_nm LIKE '%" + tbxCustName.Text.Trim() + "%'";
				fcount++;
			}

			//�Ȥ�s��
			if (tbxCustNo.Text.Trim() != "")
			{
				if (fcount>0) strFilter += " AND ";
				strFilter += "cont_custno='" + tbxCustNo.Text.Trim() + "'";
				fcount++;
			}

			//ñ�����
			string SSDate;
			string SEDate;
			if (tbxSSDate.Text.Trim() != "" && tbxSEDate.Text.Trim() != "")
			{
				SSDate = DateTime.ParseExact(tbxSSDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
				SEDate = DateTime.ParseExact(tbxSEDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
				if (fcount>0) strFilter += " AND ";
				strFilter += "(cont_signdate>='" + SSDate + " AND cont_signdate<=" + SEDate + "')";
				fcount++;
			}

			//����H�m�W
			if (tbxOrName.Text.Trim() != "")
			{
				if (fcount>0) strFilter += " AND ";
				strFilter += "or_nm LIKE '%" + tbxOrName.Text.Trim() + "%'";
				fcount++;
			}
			//����H�q��
			if (tbxOrTel.Text.Trim() != "")
			{
				if (fcount>0) strFilter += " AND ";
				strFilter += "or_tel='" + tbxOrTel.Text.Trim() + "'";
				fcount++;
			}
			//����H�a�}
			if (tbxOrAddr.Text.Trim() != "")
			{
				if (fcount>0) strFilter += " AND ";
				strFilter += "or_addr='" + tbxOrAddr.Text.Trim() + "'";
				fcount++;
			}
			//�H�ѵ��O
			if (fcount>0) strFilter += " AND ";
			if (rblSent.SelectedItem.Value.Trim()=="0")	//���H�X
				strFilter += "rm_fgsent<>'C'";
			else if (rblSent.SelectedItem.Value.Trim()=="1")	//�w�H�X
				strFilter += "rm_fgsent='C'";

			return strFilter;
		}
		#endregion



		#region ���o�ɮѪ��A��index
		protected object GetSelectedIndex(object fgsent)
		{
			int retValue = 0;
			switch(fgsent.ToString().Trim())
			{
				case "Y":
					retValue = 0;
					break;
				case "N":
					retValue = 1;
					break;
				case "D":
					retValue = 2;
					break;
			}
			return retValue;
		}
		#endregion

		#region ���o�ɮѪ��A�W��
		protected object GetFgSentName(object fgsent)
		{
			string strReturn = "";
			switch(fgsent.ToString().Trim())
			{
				case "Y":
					strReturn = "�i�H�X";
					break;
				case "N":
					strReturn = "�ثe���H�X";
					break;
				case "C":
					strReturn = "�w�H�X";
					break;
				case "D":
					strReturn = "���B�z";
					break;
				default:
					strReturn = "(DB ERROR)";
					break;
			}
			return strReturn;
		}
		#endregion

		#region �榡��dgdRemail
		private void Format_dgdRemail()
		{
			for (int i=0; i<dgdRemail.Items.Count; i++)
			{
				if (dgdRemail.Items[i].Cells[2].Text.Trim() == "01")
					dgdRemail.Items[i].Cells[2].Text = "�@��";
				else
					dgdRemail.Items[i].Cells[2].Text = "���s";
			}
		}
		#endregion

		#region �s���ɮѸ��
		private void Bind_dgdRemail(string strFilter)
		{
			dgdRemail.Visible = true;
			ReMailBooks rm = new ReMailBooks();
			DataSet ds = rm.GetContRemailOrMfrCustWithFilter(strFilter);
			DataView dv = ds.Tables[0].DefaultView;

			if (dv.Count<=0)
			{
				//�L���
				lblMessage.Text = "�ثe�|�L�ɮѸ��";
				lblMessage.Visible = true;
				dgdRemail.Visible = false;
				return;
			}
			
			lblMessage.Visible = false;
			dgdRemail.DataSource = dv;
			dgdRemail.DataBind();

			Format_dgdRemail();
		}
		#endregion

		#region �j�M�ɮѸ��
		private void lnbSearch_Click(object sender, System.EventArgs e)
		{
			string strFilter = GetContFilter();
			Bind_dgdRemail(strFilter);
			dgdRemail.EditItemIndex = -1;
		}
		#endregion


		#region ��w�ק�ɮѸ��
		private void dgdRemail_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = e.Item.Cells[1].Text.Trim();
			string OrItem = e.Item.Cells[5].Text.Trim();
			string strFilter = GetContFilter();

			dgdRemail.EditItemIndex = e.Item.ItemIndex;
			Bind_dgdRemail(strFilter);
		}
		#endregion

		#region �����ק�
		private void dgdRemail_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = e.Item.Cells[1].Text.Trim();
			string OrItem = e.Item.Cells[5].Text.Trim();
			string strFilter = GetContFilter();

			dgdRemail.EditItemIndex = -1;
			Bind_dgdRemail(strFilter);
		}
		#endregion

		#region �ק�ɮѸ��
		private void dgdRemail_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = e.Item.Cells[1].Text.Trim();
			string OrItem = e.Item.Cells[5].Text.Trim();
			string RmSeq = e.Item.Cells[7].Text.Trim();
			string strFilter = GetContFilter();
			string strContent = ((TextBox)e.Item.Cells[8].Controls[0]).Text.Trim();
			string strFgSent = ((DropDownList)e.Item.Cells[9].Controls[1]).SelectedItem.Value.Trim();

			ReMailBooks rm = new ReMailBooks();
			rm.UpdateRemail(ContNo, OrItem, RmSeq, strContent, strFgSent);
		
			dgdRemail.EditItemIndex = -1;
			Bind_dgdRemail(strFilter);
		}
		#endregion

		#region �R���ɮѸ��
		private void dgdRemail_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = e.Item.Cells[1].Text.Trim();
			string OrItem = e.Item.Cells[5].Text.Trim();
			string RmSeq = e.Item.Cells[7].Text.Trim();
			string strFilter = GetContFilter();
			
			ReMailBooks rm = new ReMailBooks();
			rm.DeleteRemail(ContNo, OrItem, RmSeq);

			dgdRemail.EditItemIndex = -1;
			Bind_dgdRemail(strFilter);
		}
		#endregion


	}
}
