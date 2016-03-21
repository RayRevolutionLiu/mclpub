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

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for cal.
	/// </summary>
	public class cal : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Calendar cal11;
		protected System.Web.UI.WebControls.Label lbText;
	
		public cal()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				//
				// Evals true first time browser hits the page
				//
				lbText.Text = DateTime.Today.Date.ToShortDateString();
				lbText.Attributes.Add("value", DateTime.Today.Date.ToShortDateString());
				cal11.SelectedDate = DateTime.Today;
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
			this.cal11.SelectionChanged += new System.EventHandler(this.cal11_SelectionChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void cal11_SelectionChanged(object sender, System.EventArgs e)
		{
			lbText.Text = cal11.SelectedDate.Date.ToShortDateString();
			lbText.Attributes.Add("value", cal11.SelectedDate.Date.ToShortDateString());

		}
	}
}
