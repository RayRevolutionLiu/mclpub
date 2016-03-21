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
using System.Text;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for RptSingleCont0.
	/// </summary>
	public class RptSingleCont0 : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Button btnGo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				Session.Remove("RPTSINGLECONT");
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
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region �����ˮָ��
		private void btnGo_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			if (tbxContNo.Text.Trim() == "")
			{
				jsAlertMsg("INVALIDSDATE", "�п�J�X���s��");
				return;
			}
			Session["RPTSINGLECONT"] = GetFilter();
			Session["STRNOW"] = DateTime.Now.ToString();

			Contracts cont = new Contracts();
			cont.RtpGenData();
//			Response.Write("�d�߱���=" + Session["RPTSINGLECONT"].ToString() + "___");
			string strbuf;
			strbuf="RptSingleCont.aspx?whoami=" + this.WhoAmI.CName;
//			Response.Redirect(strbuf);
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}
		#endregion

		#region ����Query����
		private string GetFilter()
		{
			int fc = 0;
			StringBuilder sb = new StringBuilder();
			if (tbxContNo.Text.Trim() != "")
			{
				sb.Append("cont_contno='" + tbxContNo.Text.Trim() + "'");
				fc++;
			}
			else
			{
				jsAlertMsg("INVALIDSDATE", "�п�J�X���s��");
				return "";
			}

			return sb.ToString();
		}
		#endregion
	}
}
