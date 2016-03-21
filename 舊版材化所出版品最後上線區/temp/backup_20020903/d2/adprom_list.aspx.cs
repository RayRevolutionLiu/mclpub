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

namespace MRLPub_d2
{
	/// <summary>
	/// Summary description for adprom_list.
	/// </summary>
	public class adprom_list : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DropDownList ddlConttp;
		protected System.Web.UI.WebControls.Label lblMemo;
	
		public adprom_list()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				// 給合約類別 預設值 = 推廣合約 (value=09)
				this.ddlConttp.SelectedIndex = 1;
			}
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			string ConttpCode, ConttpName;
			ConttpCode = this.ddlConttp.SelectedItem.Value.ToString().Trim();
			ConttpName = this.ddlConttp.SelectedItem.Text.ToString().Trim();
			//Response.Write("ConttpCode= " + ConttpCode + "<br>");
			//Response.Write("ConttpName= " + ConttpName + "<br>");
			
			// 轉址: 執行 ExcelSpeedGen
			Response.Redirect("adprom_list2.aspx?conttp=" + ConttpCode);
			
		}
	}
}
