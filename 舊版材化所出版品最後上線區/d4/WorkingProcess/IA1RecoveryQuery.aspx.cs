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
	/// Summary description for IA1RecoveryQuery.
	/// </summary>
	public class IA1RecoveryQuery : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgdCont;
		protected System.Web.UI.WebControls.TextBox tbxMfrNm;
		protected System.Web.UI.WebControls.Label lblContHint;
		protected System.Web.UI.WebControls.TextBox tbxRecNm;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.LinkButton lnbQuery;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox tbxIano;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.lnbQuery.Click += new System.EventHandler(this.lnbQuery_Click);
			this.dgdCont.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdCont_PageIndexChanged);
			this.dgdCont.SelectedIndexChanged += new System.EventHandler(this.dgdCont_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

//		#region ��������D��}�ߵo������
//		private void lngGo_Click(object sender, System.EventArgs e)
//		{
//			string Iano = tbxIano.Text.Trim();
//			if (Iano == "")
//			{
//				jsAlertMsg("BLANKIANO", "�o���}�߳�s�����i�ť�");
//				return;
//			}
//			Invoice inv = new Invoice();
//			SqlDataReader dr = inv.GetSinglaIaByIano(Iano);
//
//			if (dr.Read())
//			{
//				if(dr["ia_status"].ToString().Trim()=="")
//					Response.Redirect("IA1RecoveryConfirm.aspx?Iano=" + Iano);
//				else if((dr["ia_status"].ToString().Trim()=="v")||(dr["ia_status"].ToString().Trim()=="5"))
//					jsAlertMsg("", "���o���w���͵o���}�߲M��, �L�k�^�_(Recovery)");
//				else if(dr["ia_status"].ToString().Trim()=="7")
//					jsAlertMsg("", "���o���w��SAP, �L�k�^�_(Recovery)");
//			}
//			else
//				jsAlertMsg("CONTNOTFOUND", "�L���o���}�߳�s���A���ˬd�s���O�_���T�γq���~�ȭt�d�H");
//
//		}
//		#endregion

		#region �d��
		private void lnbQuery_Click(object sender, System.EventArgs e)
		{
			// Reset Index
			Search();

		}
		private void Search()
		{
			dgdCont.CurrentPageIndex = 0;
			dgdCont.SelectedIndex = -1;

			int DataCount = Bind_dgdCont();
			if (DataCount>0)
				lblMessage.Text = "�d�ߵ��G�G��� " + DataCount.ToString() + " �����";
			else
				lblMessage.Text = "�d�L���";
		}
		#endregion

		#region ����
		private void dgdCont_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdCont.CurrentPageIndex = e.NewPageIndex;
			Bind_dgdCont();
		}
		#endregion

		#region �s���X�����
		/// <summary>
		/// �s���X�����
		/// </summary>
		/// <returns>��쪺��Ƶ���</returns>
		private int Bind_dgdCont()
		{
			Invoice inv = new Invoice();
			DataSet ds = inv.GetIA("", "");
			DataView dv = ds.Tables[0].DefaultView;

			string strFilter = GetFilters();
			if (strFilter.Trim() != "")
			{
				dv.RowFilter = strFilter;
			}

			dgdCont.DataSource = dv;
			dgdCont.DataBind();

			if (dgdCont.Items.Count>0)
			{
				dgdCont.Visible = true;

				for(int i=0; i<dgdCont.Items.Count; i++)
				{
					switch(dgdCont.Items[i].Cells[6].Text.Trim())
					{
						case "2":
							dgdCont.Items[i].Cells[6].Text = "�G�p";
							break;
						case "3":
							dgdCont.Items[i].Cells[6].Text = "�T�p";
							break;
						case "4":
							dgdCont.Items[i].Cells[6].Text = "��L";
							break;
						default:
							dgdCont.Items[i].Cells[6].Text = "";
							break;
					}
					switch(dgdCont.Items[i].Cells[7].Text.Trim())
					{
						case "1":
							dgdCont.Items[i].Cells[7].Text = "���|5%";
							break;
						case "2":
							dgdCont.Items[i].Cells[7].Text = "�s�|";
							break;
						case "3":
							dgdCont.Items[i].Cells[7].Text = "�K�|";
							break;
						default:
							dgdCont.Items[i].Cells[7].Text = "";
							break;
					}
					switch(dgdCont.Items[i].Cells[8].Text.Trim())
					{
						case "06":
							dgdCont.Items[i].Cells[8].Text = "�Ҥ�";
							break;
						case "07":
							dgdCont.Items[i].Cells[8].Text = "�|��";
							break;
						case "":
							dgdCont.Items[i].Cells[8].Text = "�@��";
							break;
						default:
							dgdCont.Items[i].Cells[8].Text = "";
							break;
					}
					switch(dgdCont.Items[i].Cells[10].Text.Trim())
					{
						case "v":
							dgdCont.Items[i].Cells[9].Text = "<font color=red>�w���ͲM��</font>";
							((Button)dgdCont.Items[i].Cells[11].Controls[0]).Enabled=false;
							break;
						case "5":
							dgdCont.Items[i].Cells[9].Text = "<font color=red>�w�C�L�M��</font>";
							((Button)dgdCont.Items[i].Cells[11].Controls[0]).Enabled=false;
							break;
						case "7":
							dgdCont.Items[i].Cells[9].Text = "<font color=red>�w��SAP</font>";
							((Button)dgdCont.Items[i].Cells[11].Controls[0]).Enabled=false;
							break;
						default:
							dgdCont.Items[i].Cells[9].Text = "�|�����ͲM��";
							break;
					}

				}
			}
			else
			{
				dgdCont.Visible = false;
			}
			return dv.Count;

		}
		#endregion

		#region �զX�d�߱���
		/// <summary>
		/// �զX�d�߱���
		/// </summary>
		/// <returns>�զX�᪺����r��</returns>
		private string GetFilters()
		{
			int fc = 0;
			string strFilter = "";

			//�t�ӦW��
			if (tbxMfrNm.Text.Trim() != "")
			{
				strFilter += "mfr_inm LIKE '%" + tbxMfrNm.Text.Trim() + "%'";
				fc++;
			}

			//�Τ@�s��
			if (tbxMfrNo.Text.Trim() != "")
			{
				if (fc>0) strFilter += " AND ";
				strFilter += "ia_mfrno = '" + tbxMfrNo.Text.Trim() + "'";
				fc++;
			}

			//�o������H
			if (tbxRecNm.Text.Trim() != "")
			{
				if (fc>0) strFilter += " AND ";
				strFilter += "ia_rnm LIKE '%" + tbxRecNm.Text.Trim() + "%'";
				fc++;
			}

			//�o���}�߳�s��
			if (tbxIano.Text.Trim() != "")
			{
				if (fc>0) strFilter += " AND ";
				strFilter += "ia_iano = '" + tbxIano.Text.Trim() + "'";
				fc++;
			}

			return strFilter;
		}
		#endregion

		#region ��w�nRecovery���o��
		private void dgdCont_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string iano = dgdCont.SelectedItem.Cells[0].Text.Trim();
			lblMessage.Text=iano.Trim();
			if(dgdCont.SelectedItem.Cells[10].Text.Trim() == "")
			{
				Invoice inv = new Invoice();
				bool flag = inv.RecoveryIA1(iano);
				if(flag)
				{
					Search();
					jsAlertMsg("", "�o���}�߳�Recovery����");
//					Response.Redirect("content.htm");
				}
				else
					jsAlertMsg("", "�o���}�߳�Recovery����, �еy��A��!!");
			}
			else if(dgdCont.SelectedItem.Cells[10].Text.Trim() == "v")
				jsAlertMsg("", "���o���}�߳�w���ͲM��,�L�k�^�_");
			else if(dgdCont.SelectedItem.Cells[10].Text.Trim() == "5")
				jsAlertMsg("", "���o���}�߳�w�C�L�M��,�L�k�^�_");
			else if(dgdCont.SelectedItem.Cells[10].Text.Trim() == "7")
				jsAlertMsg("", "���o���}�߳�w��SAP,�L�k�^�_");
		}
		#endregion
	}
}
