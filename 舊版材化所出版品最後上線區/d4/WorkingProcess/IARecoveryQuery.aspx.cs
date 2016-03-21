using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
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
	/// Summary description for IARecoveryQuery.
	/// </summary>
	public class IARecoveryQuery : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxYYYYMM;
		protected System.Web.UI.WebControls.Label lblyyyymm;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox tbxBatch;
		protected System.Web.UI.WebControls.Label lblBatch;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.DataGrid dgdCont;
		protected System.Web.UI.WebControls.Panel pnlSearch;
		protected System.Web.UI.WebControls.Panel pnlCont;
		protected System.Web.UI.WebControls.Button btnHome;
		protected System.Web.UI.WebControls.Panel pnlBack;
		protected System.Web.UI.WebControls.RegularExpressionValidator revDate;
		protected System.Web.UI.WebControls.Label lblMessage;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				string datestr = DateTime.Today.ToString("yyyy/MM/dd");
				tbxYYYYMM.Text = datestr.Substring(0, 7);
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
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			lblMessage.Text="";
			if(tbxYYYYMM.Text.Trim()=="")
			{
				jsAlertMsg("SDATEERROR", "���ͦ~�뤣�i�ť�");
				return;
			}
			if(tbxBatch.Text.Trim()=="")
			{
				jsAlertMsg("SDATEERROR", "���ͧ妸���i�ť�");
				return;
			}
			string iabdate = tbxYYYYMM.Text.Substring(0, 4)+tbxYYYYMM.Text.Substring(5, 2);
			string iabseq = tbxBatch.Text.Trim();
			Invoice inv = new Invoice();
			DataSet ds = inv.GetIA(iabdate, iabseq);
			DataView dv = ds.Tables[0].DefaultView;
			dgdCont.DataSource = dv;
			dgdCont.DataBind();
			if (dgdCont.Items.Count>0)
			{
				pnlCont.Visible = true;
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
							break;
						case "5":
							dgdCont.Items[i].Cells[9].Text = "<font color=red>�w�C�L�M��</font>";
							break;
						case "7":
							dgdCont.Items[i].Cells[9].Text = "<font color=red>�w��SAP</font>";
							break;
						default:
							dgdCont.Items[i].Cells[9].Text = "�|�����ͲM��";
							break;
					}

				}
			}
			else
			{
				pnlCont.Visible = false;
				lblMessage.Text="������Ƥ��s�b�άd�߱���榡���~";
			}


		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			switch(dgdCont.Items[0].Cells[10].Text.Trim())
			{
				case "v":
					jsAlertMsg("SDATEERROR", "����o���w���ͲM��, ����^�_(Recovery)");
					lblMessage.Text = "<<<����o���w���ͲM��, ����^�_(Recovery)>>>";
					return;
				case "5":
					jsAlertMsg("SDATEERROR", "����o���w�C�L�M��, ����^�_(Recovery)");
					lblMessage.Text = "<<<����o���w�C�L�M��, ����^�_(Recovery)>>>";
					return;
				case "7":
					jsAlertMsg("SDATEERROR", "����o���w��SAP, ����^�_(Recovery)");
					lblMessage.Text = "<<<����o���w��SAP, ����^�_(Recovery)>>>";
					return;
				default:
					lblMessage.Text = "�|�����ͲM��";
					break;
			}
			lblMessage.Text = "Recovery";
			string iabdate = tbxYYYYMM.Text.Substring(0, 4)+tbxYYYYMM.Text.Substring(5, 2);
			string iabseq = tbxBatch.Text.Trim();
			Invoice inv = new Invoice();
			bool flag = inv.RecoveryIA(iabdate, iabseq);
			if(flag)
			{
				jsAlertMsg("", "�o���}�߳�Recovery����");
				pnlSearch.Visible = false;
				pnlCont.Visible=false;
				pnlBack.Visible=true;
			}
			else
				jsAlertMsg("", "�o���}�߳�Recovery����, �еy��A��!!");
		
		}

		private void btnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("content.htm");
		}
	}
}
