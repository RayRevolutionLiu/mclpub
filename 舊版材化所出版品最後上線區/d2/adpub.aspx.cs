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
using System.Data.SqlClient;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adpub.
	/// </summary>
	public class adpub : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_thismonth;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidData;
	
		public adpub()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				/* ъ╰参ら戳, ノ substring ъ程 "/" 才腹ゎ╰参る
				 */ 
				string thisMonth = DateTime.Today.ToShortDateString();
				this.lbl_thismonth.Text = thisMonth.Substring(0,thisMonth.LastIndexOf("/"));

				//Load Data From DB
				//LoadDataFromDB();
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

		private void LoadDataFromDB()
		{
			string strDSN = "Server=isccom1;User ID=webuser;Password=db600;Database=MRLPub";
			string strSelectCommand = "SELECT pub_contno AS 磞瓃, pub_pgno AS 絏, pub_ltpcd AS , pub_clrcd AS ︹眒, pub_pgsizecd AS 絞碩 FROM c2_pub";
			SqlDataAdapter da = new SqlDataAdapter(strSelectCommand, strDSN);
			DataSet ds = new DataSet("root");
			da.Fill(ds, "item");

			hidData.Value = ds.GetXml();
		}
	}
}
