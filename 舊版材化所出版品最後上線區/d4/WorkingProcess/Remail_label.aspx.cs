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

namespace MRLPub.d4
{
	/// <summary>
	/// Summary description for remail_label.
	/// </summary>
	public class Remail_label : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.DataList DataList2;
		protected System.Web.UI.WebControls.DataList DataList1;
	
		public Remail_label()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				MailLabel ml = new MailLabel();
				DataSet ds = ml.GetRemailLabel();
				DataView dv = ds.Tables[0].DefaultView;
				dv.RowFilter = "or_fgmosea='"+Context.Request.QueryString["mosea"]+"'";
				if(Context.Request.QueryString["mosea"]=="0")
				{
					DataList1.DataSource=dv;
					DataList1.DataBind();
				}
				else
				{
					DataList2.DataSource=dv;
					DataList2.DataBind();
				}
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
			this.ID = "Remail_label";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
