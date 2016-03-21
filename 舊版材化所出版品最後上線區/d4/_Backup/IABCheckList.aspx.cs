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

namespace MRLPub.d4
{
	/// <summary>
	/// Summary description for IABCheckList.
	/// </summary>
	public class IABCheckList : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPub;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaIaList;
		protected System.Web.UI.WebControls.Label lblYYYYMM;
		protected System.Web.UI.WebControls.Label lblOrderByFilter;
		protected System.Web.UI.WebControls.DropDownList ddlOrderByFilter;
		protected System.Web.UI.WebControls.Label lblIabSeq;
		protected System.Web.UI.WebControls.TextBox tbxIabseq;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnClear;
		protected System.Web.UI.WebControls.Panel pnlQuery;
		protected System.Web.UI.WebControls.Label lblAdCate;
		protected System.Web.UI.WebControls.DropDownList ddlAdCate;
		protected System.Web.UI.WebControls.TextBox tbxAdMonth;
		protected System.Web.UI.WebControls.RegularExpressionValidator revAdMonth;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvAdMonth;
		protected System.Web.UI.WebControls.DataGrid dgdIaList;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Web.UI.WebControls.Panel pnlIaList;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
	
		public IABCheckList()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCnnMRLPub = new System.Data.SqlClient.SqlConnection();
			this.sqlDaIaList = new System.Data.SqlClient.SqlDataAdapter();
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.ia.ia_syscd, dbo.ia.ia_iano, RTRIM(dbo.ia.ia_mfrno) AS ia_mfrno, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, RTRIM(dbo.ia.ia_rnm) AS ia_rnm, RTRIM(dbo.ia.ia_rjbti) AS ia_rjbti, RTRIM(dbo.ia.ia_rzip) AS ia_rzip, RTRIM(dbo.ia.ia_raddr) AS ia_raddr, RTRIM(dbo.ia.ia_rtel) AS ia_rtel, dbo.ia.ia_invcd, dbo.ia.ia_taxtp, dbo.iad.iad_iaditem, RTRIM(dbo.iad.iad_fk1) AS iad_fk1, RTRIM(dbo.iad.iad_fk2) AS iad_fk2, RTRIM(dbo.iad.iad_fk3) AS iad_fk3, RTRIM(dbo.iad.iad_fk4) AS iad_fk4, RTRIM(dbo.iad.iad_desc) AS iad_desc, dbo.iad.iad_projno, dbo.iad.iad_costctr, dbo.iad.iad_qty, dbo.iad.iad_amt, RTRIM(dbo.ia.ia_contno) AS ia_contno, dbo.ia.ia_iabdate, dbo.ia.ia_iabseq, dbo.iad.iad_iano, dbo.iad.iad_syscd FROM dbo.ia INNER JOIN dbo.iad ON dbo.ia.ia_syscd = dbo.iad.iad_syscd AND dbo.ia.ia_iano = dbo.iad.iad_iano INNER JOIN dbo.iab ON dbo.ia.ia_syscd = dbo.iab.iab_syscd COLLATE Chinese_Taiwan_Stroke_CI_AS AND dbo.ia.ia_iabdate = dbo.iab.iab_iabdate AND dbo.ia.ia_iabseq = dbo.iab.iab_iabseq INNER JOIN dbo.mfr ON dbo.ia.ia_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.c4_cont ON dbo.ia.ia_contno = dbo.c4_cont.cont_syscd + dbo.c4_cont.cont_contno WHERE (dbo.c4_cont.cont_fgpayonce = '0') AND (dbo.c4_cont.cont_fgclosed = '0') AND (dbo.ia.ia_syscd = 'C4') AND (dbo.ia.ia_status = ' ') ORDER BY dbo.ia.ia_iano, dbo.iad.iad_fk1, dbo.iad.iad_fk2, dbo.iad.iad_fk3, dbo.iad.iad_fk4";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPub;
			// 
			// sqlCnnMRLPub
			// 
			this.sqlCnnMRLPub.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDaIaList
			// 
			this.sqlDaIaList.SelectCommand = this.sqlSelectCommand1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//放一個Alert在client script
		private void AlertMsg(string strMsg)
		{
			if (strMsg != null && strMsg != "")
			{
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"" + strMsg +"\");</script>";
				Page.Controls.Add(litAlert);
			}
		}

		private void Bind_dgdIaList()
		{
			DataSet ds = new DataSet();
			this.sqlDaIaList.Fill(ds, "IALIST");
			DataView dv = ds.Tables["IALIST"].DefaultView;

			if (!(dv.Count>0))
			{
				pnlIaList.Visible = false;
				AlertMsg("無符合條件的發票開立資料");
				return;
			}

			pnlIaList.Visible = true;
			dgdIaList.DataSource = dv;
			dgdIaList.DataBind();
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			this.pnlIaList.Visible = false;
			this.ddlAdCate.SelectedIndex = 0;
			this.tbxAdMonth.Text = "";	
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			Bind_dgdIaList();
		}

		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			//報表..
			Response.Redirect("");
		}
	}
}
