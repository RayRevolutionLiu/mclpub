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
	/// Summary description for RptIA_ChkList.
	/// </summary>
	public class RptIA_ChkFilter : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxYYYYMM;
		protected System.Web.UI.WebControls.Label lblyyyymm;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Button btnHome;
		protected System.Web.UI.WebControls.DataGrid dgdIAB;
		protected System.Web.UI.WebControls.Panel pnlIA;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenSeq;
		protected System.Web.UI.WebControls.DataGrid dgdIA;
		protected System.Web.UI.WebControls.DropDownList ddlSort;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.RegularExpressionValidator revDate;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Panel pnlBack;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				Literal1.Text="";
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
			this.dgdIAB.SelectedIndexChanged += new System.EventHandler(this.dgdIAB_SelectedIndexChanged);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.ID = "RptIA_ChkFilter";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			lblMessage.Text="";
			if(tbxYYYYMM.Text.Trim()=="")
			{
				jsAlertMsg("SDATEERROR", "產生年月不可空白");
				return;
			}
			string iabdate = tbxYYYYMM.Text.Substring(0, 4)+tbxYYYYMM.Text.Substring(5, 2);
			Invoice inv = new Invoice();
			DataSet ds = inv.GetIAB(iabdate);
			dgdIAB.Visible = true;
			dgdIAB.DataSource = ds;
			dgdIAB.DataBind();
		
		}

		private void dgdIAB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			lblMessage.Text="";
			hiddenSeq.Value = dgdIAB.SelectedItem.Cells[1].Text.Trim();
			string iabdate = tbxYYYYMM.Text.Substring(0, 4)+tbxYYYYMM.Text.Substring(5, 2);
			string iabseq = hiddenSeq.Value.Trim();
			Invoice inv = new Invoice();
			DataSet ds = inv.GetIA(iabdate, iabseq);
			DataView dv = ds.Tables[0].DefaultView;
			dv.RowFilter = "ia_status = ''";
			switch (ddlSort.SelectedItem.Value)
			{
				case "1":
					dv.Sort = "ia_iano";
					break;
				case "2":
					dv.Sort = "cont_empno, ia_contno";
					break;
			}
			dgdIA.DataSource = dv;
			dgdIA.DataBind();
			if (dgdIA.Items.Count>0)
			{
				pnlIA.Visible = true;
				dgdIA.Visible = true;

				for(int i=0; i<dgdIA.Items.Count; i++)
				{
					switch(dgdIA.Items[i].Cells[6].Text.Trim())
					{
						case "2":
							dgdIA.Items[i].Cells[6].Text = "二聯";
							break;
						case "3":
							dgdIA.Items[i].Cells[6].Text = "三聯";
							break;
						case "4":
							dgdIA.Items[i].Cells[6].Text = "其他";
							break;
						default:
							dgdIA.Items[i].Cells[6].Text = "";
							break;
					}
					switch(dgdIA.Items[i].Cells[7].Text.Trim())
					{
						case "1":
							dgdIA.Items[i].Cells[7].Text = "應稅5%";
							break;
						case "2":
							dgdIA.Items[i].Cells[7].Text = "零稅";
							break;
						case "3":
							dgdIA.Items[i].Cells[7].Text = "免稅";
							break;
						default:
							dgdIA.Items[i].Cells[7].Text = "";
							break;
					}
					switch(dgdIA.Items[i].Cells[8].Text.Trim())
					{
						case "06":
							dgdIA.Items[i].Cells[8].Text = "所內";
							break;
						case "07":
							dgdIA.Items[i].Cells[8].Text = "院內";
							break;
						case "":
							dgdIA.Items[i].Cells[8].Text = "一般";
							break;
						default:
							dgdIA.Items[i].Cells[8].Text = "";
							break;
					}

				}
			}
			else
			{
				pnlIA.Visible = false;
				lblMessage.Text="此批發票已進入會計系統, 無法列印檢核表";
			}

		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			string iabdate = tbxYYYYMM.Text.Substring(0, 4)+tbxYYYYMM.Text.Substring(5, 2);
			string iabseq = hiddenSeq.Value.Trim();
			string	strbuf="RptIA_ChkList.aspx?whoami=" + this.WhoAmI.CName+"&iabdate="+iabdate.Trim()+"&iabseq="+iabseq.Trim();
			strbuf += "&sort="+ddlSort.SelectedItem.Value;

			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}
	}
}
