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
				
				// 依傳回之網頁變數 str, 給予不同提示訊息
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
		
		
		// 依傳回之網頁變數 str, 給予不同提示訊息
		private void CheckStatus()
		{
			this.hpl1.Visible = false;
			this.hpl2.Visible = true;
			
			// 判斷情況
			switch (Context.Request.QueryString["str"])
			{
				// 缺書登錄成功
				case "newlost":
					this.lblMessage.Text="缺書登錄 已完成!";
					this.hpl1.Visible = true;
					this.hpl1.Text = "繼續 缺書登錄~";
					this.hpl1.NavigateUrl = "lostbk_search.aspx?function1=new";
					this.hpl2.Text = "查詢/修改/刪除缺書資料~";
					this.hpl2.NavigateUrl = "lostbk_search.aspx?function1=mod";
					break;

				// 缺書修改成功
				case "modlost":
					this.lblMessage.Text="修改缺書資料 已完成!";
					this.hpl1.Visible = false;
					this.hpl2.Text = "繼續 修改/刪除缺書資料~";
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
