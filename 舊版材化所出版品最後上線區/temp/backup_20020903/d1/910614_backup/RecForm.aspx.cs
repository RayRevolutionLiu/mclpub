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
using System.Xml;

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for RecForm.
	/// </summary>
	public class RecForm : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidden_xml;
		protected System.Web.UI.HtmlControls.HtmlInputText tt1;
		protected System.Web.UI.HtmlControls.HtmlInputText tt2;
		protected System.Web.UI.HtmlControls.HtmlInputText tt3;
		protected System.Web.UI.HtmlControls.HtmlInputText tt4;
		protected System.Web.UI.HtmlControls.HtmlInputText tt6;
		protected System.Web.UI.HtmlControls.HtmlInputText tt7;
		protected System.Web.UI.HtmlControls.HtmlInputText tt8;
		protected System.Web.UI.HtmlControls.HtmlInputText tt9;
		protected System.Web.UI.HtmlControls.HtmlInputText tt5;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Table Table2;
		protected System.Web.UI.HtmlControls.HtmlSelect ddl1;
	
		public RecForm()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			XmlNode xmlItem;
			XmlDocument xmldoc;
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				Response.Expires=0;
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
