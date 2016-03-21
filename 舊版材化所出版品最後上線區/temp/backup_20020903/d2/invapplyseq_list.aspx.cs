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

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for invapplyseq_list.
	/// </summary>
	public class invapplyseq_list : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		public invapplyseq_list()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				//
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
			this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Canel);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Edit);
			this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Update);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Delete);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Canel(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{

		}

		private void Delete(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{

		}

		private void Edit(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{

		}

		private void Update(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{

		}
	}
}
