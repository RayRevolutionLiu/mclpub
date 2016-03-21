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
	/// Summary description for RptIA1_ChkFilter.
	/// </summary>
	public class RptIA1_ChkFilter : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Button btnHome;
		protected System.Web.UI.WebControls.DataGrid dgdIA;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Panel pnlBack;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				Literal1.Text="";
				Bind_dgdIA();
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
			this.dgdIA.SelectedIndexChanged += new System.EventHandler(this.dgdIA_SelectedIndexChanged);
			this.ID = "RptIA_ChkFilter";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Bind_dgdIA()
		{
			Literal1.Text="";
			Invoice inv = new Invoice();
			DataSet ds = inv.GetIA("", "");		//�S���妸���
			DataView dv = ds.Tables[0].DefaultView;
			dv.RowFilter = "ia_status = ''";
			dv.Sort = "ia_iano";
//			switch (ddlSort.SelectedItem.Value)
//			{
//				case "1":
//					dv.Sort = "ia_iano";
//					break;
//				case "2":
//					dv.Sort = "cont_empno, ia_contno";
//					break;
//			}
			dgdIA.DataSource = dv;
			dgdIA.DataBind();
			if (dgdIA.Items.Count>0)
			{
				dgdIA.Visible = true;

				for(int i=0; i<dgdIA.Items.Count; i++)
				{
					switch(dgdIA.Items[i].Cells[6].Text.Trim())
					{
						case "2":
							dgdIA.Items[i].Cells[6].Text = "�G�p";
							break;
						case "3":
							dgdIA.Items[i].Cells[6].Text = "�T�p";
							break;
						case "4":
							dgdIA.Items[i].Cells[6].Text = "��L";
							break;
						default:
							dgdIA.Items[i].Cells[6].Text = "";
							break;
					}
					switch(dgdIA.Items[i].Cells[7].Text.Trim())
					{
						case "1":
							dgdIA.Items[i].Cells[7].Text = "���|5%";
							break;
						case "2":
							dgdIA.Items[i].Cells[7].Text = "�s�|";
							break;
						case "3":
							dgdIA.Items[i].Cells[7].Text = "�K�|";
							break;
						default:
							dgdIA.Items[i].Cells[7].Text = "";
							break;
					}
					switch(dgdIA.Items[i].Cells[8].Text.Trim())
					{
						case "06":
							dgdIA.Items[i].Cells[8].Text = "�Ҥ�";
							break;
						case "07":
							dgdIA.Items[i].Cells[8].Text = "�|��";
							break;
						case "":
							dgdIA.Items[i].Cells[8].Text = "�@��";
							break;
						default:
							dgdIA.Items[i].Cells[8].Text = "";
							break;
					}

				}
			}
			else
			{
				dgdIA.Visible = false;
				lblMessage.Text="�S���i�C�L�ˮ֪��o�����";
			}

		}

		private void dgdIA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			string	strbuf="RptIA1_ChkList.aspx?whoami=" + this.WhoAmI.CName+"&iano="+dgdIA.SelectedItem.Cells[0].Text.Trim();

			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		
		}

//		private void btnPrint_Click(object sender, System.EventArgs e)
//		{
//			Literal1.Text="";
//			string iabdate = tbxYYYYMM.Text.Substring(0, 4)+tbxYYYYMM.Text.Substring(5, 2);
//			string iabseq = hiddenSeq.Value.Trim();
//			string	strbuf="RptIA_ChkList.aspx?whoami=" + this.WhoAmI.CName+"&iabdate="+iabdate.Trim()+"&iabseq="+iabseq.Trim();
//			strbuf += "&sort="+ddlSort.SelectedItem.Value;
//
//			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
//		}
	}
}
