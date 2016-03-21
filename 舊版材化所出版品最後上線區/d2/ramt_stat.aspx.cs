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
	/// Summary description for ramt_stat.
	/// </summary>
	public class ramt_stat : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.TextBox tbxYYYYMM;
		protected System.Web.UI.HtmlControls.HtmlForm adincome_list;
	
		public ramt_stat()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				// 給 截止年月 tbxYYYYMM 預設值 (今天年月)
				//this.tbxYYYYMM.Text = System.DateTime.Today.ToString("yyyy/MM").Trim();
				this.tbxYYYYMM.Text = System.DateTime.Today.ToString("yyyyMM").Trim();
				
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
			// 抓出所選取的截止年月
			string YYYYMM = "";
			YYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
			//YYYYMM = YYYYMM.Substring(0, 4) + YYYYMM.Substring(5, 2);
			//Response.Write("YYYYMM= " + YYYYMM + "<br>");
			
			// 轉址: 執行 ExcelSpeedGen
			Response.Redirect("ramt_stat2.aspx?enddate=" + YYYYMM);
			
		}


	}
}
