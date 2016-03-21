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
// WebApplication Virables - Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for SaveMessage.
	/// </summary>
	public class SaveMessage : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.HyperLink hpl1;
		protected System.Web.UI.WebControls.HyperLink hpl2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		public SaveMessage()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}
		
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			
			if(!Page.IsPostBack)
			{
				Response.Expires=0;
				
				// �̶Ǧ^�������ܼ� str, �������P���ܰT��
				CheckStatus();
			}
			
			CheckStatus();
		}
		
		
		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		// �̶Ǧ^�������ܼ� str, �������P���ܰT��
		private void CheckStatus()
		{
			this.hpl1.Visible = false;
			this.hpl2.Visible = true;
			
			// �P�_���p
			switch (Context.Request.QueryString["str"])
			{
				// �ʮѵn�����\
				case "newlost":
					this.lblMessage.Text="�ʮѵn�� �w����!";
					this.hpl1.Visible = true;
					this.hpl1.Text = "�~�� �ʮѵn��~";
					this.hpl1.NavigateUrl = "lostbk_search.aspx?function1=new";
					this.hpl2.Text = "�d��/�ק�/�R���ʮѸ��~";
					this.hpl2.NavigateUrl = "lostbk_search.aspx?function1=mod";
					break;

				// �ʮѭק令�\
				case "modlost":
					this.lblMessage.Text="�ק�ʮѸ�� �w����!";
					this.hpl1.Visible = false;
					this.hpl2.Text = "�~�� �ק�/�R���ʮѸ��~";
					this.hpl2.NavigateUrl = "lostbk_search.aspx?function1=mod";
					break;
			}
			
		}
		
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
		
	}
}
