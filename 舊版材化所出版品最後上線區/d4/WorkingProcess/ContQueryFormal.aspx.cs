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
using MRLPub.d4.DataTypes;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for ContQueryFormal.
	/// </summary>
	public class ContQueryFormal : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.LinkButton lnbBack;
		protected System.Web.UI.WebControls.Label lblCustFound;
		protected System.Web.UI.WebControls.DataGrid dgdCont;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				int DataCount = Bind_dgdCont();
				if (DataCount>0)
				{
					dgdCont.Visible = true;
					lblCustFound.Text = "���Ȥ�@�� " + DataCount.ToString() + " ���X�����";
					lblCustFound.Visible = true;
					//pnlNoHistory.Visible = false;
				}
				else
				{
					dgdCont.Visible = false;
					lblCustFound.Visible = false;
					//pnlNoHistory.Visible = true;
				}
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
			this.lnbBack.Click += new System.EventHandler(this.lnbBack_Click);
			this.dgdCont.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdCont_PageIndexChanged);
			this.dgdCont.SelectedIndexChanged += new System.EventHandler(this.dgdCont_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region �^�d�ߵe��
		private void lnbBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("~/d4/WorkingProcess/ContQueryMaintain.aspx");
		}
		#endregion

		#region �s���ӫȤ᪺�X�����
		private int Bind_dgdCont()
		{
			string custno;
			if (Request.QueryString["custno"] == null || Request.QueryString["custno"] == "")
			{
				throw new Exception("�Ȥ�s�����ର�ŭ�");
			}
			else
			{
				custno = Request.QueryString["custno"];
			}

			Contracts cont = new Contracts();
			DataSet ds = cont.GetFormalContractsByCustNo(custno);
			DataView dv = ds.Tables[0].DefaultView;
			
			dgdCont.DataSource = dv;
			dgdCont.DataBind();

			Format_dgdCont();

			return dv.Count;
		}
		#endregion

		#region �榡��dgd_Cont�����e
		private void Format_dgdCont()
		{
			DateTime signdate, sdate, edate;
			foreach(DataGridItem dgi in dgdCont.Items)
			{
				//�B�z ñ������B�X���_����
				try
				{
					signdate = DateTime.ParseExact(dgi.Cells[1].Text.Trim(), "yyyyMMdd", null);
				}
				catch
				{
					jsAlertMsg("SIGNDATEERROR", "��Ʈw����ñ������榡���~�A�гq���p���H");
					return;
				}

				try
				{
					sdate = DateTime.ParseExact(dgi.Cells[2].Text.Trim(), "yyyyMMdd", null);
				}
				catch
				{
					jsAlertMsg("SDATEERROR", "��Ʈw�����X���_�l����榡���~�A�гq���p���H");
					return;
				}

				try
				{
					edate = DateTime.ParseExact(dgi.Cells[3].Text.Trim(), "yyyyMMdd", null);
				}
				catch
				{
					jsAlertMsg("EDATEERROR", "��Ʈw�����X����������榡���~�A�гq���p���H");
					return;
				}

				dgi.Cells[1].Text = signdate.ToString("yyyy/MM/dd");
				dgi.Cells[2].Text = sdate.ToString("yyyy/MM/dd");
				dgi.Cells[3].Text = edate.ToString("yyyy/MM/dd");

				//�B�z�@���I�M���O
				switch(dgi.Cells[7].Text.Trim())
				{
					case "0":
						dgi.Cells[7].Text = "�_";
						break;	
					case "1":
						dgi.Cells[7].Text = "�O";
						break;
					default:
						dgi.Cells[7].Text = "(���~)";
						break;
				}

				//�B�z���׵��O
				switch(dgi.Cells[8].Text.Trim())
				{
					case "0":
						dgi.Cells[8].Text = "�_";
						break;	
					case "1":
						dgi.Cells[8].Text = "�O";
						break;
					default:
						dgi.Cells[8].Text = "(���~)";
						break;
				}

				//�B�z�X�����O
				switch(dgi.Cells[9].Text.Trim())
				{
					case "01":
						dgi.Cells[9].Text = "�@��";
						break;
					case "09":
						dgi.Cells[9].Text = "���s";
						break;
					default:
						dgi.Cells[9].Text = "(���~)";
						break;
				}
			}
		}
		#endregion

		#region ��w�X��
		private void dgdCont_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string contno = dgdCont.SelectedItem.Cells[0].Text.Trim();
			Response.Redirect("~/d4/WorkingProcess/ContMaintain.aspx?contno=" + contno);
		}
		#endregion

		#region ����
		private void dgdCont_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdCont.CurrentPageIndex = e.NewPageIndex;

			Bind_dgdCont();
		}
		#endregion
	}
}
