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
	/// Summary description for IA1CheckList.
	/// </summary>
	public class IA1CheckList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblBkcd;
		protected System.Web.UI.WebControls.Label lblYYYYMM;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnClear;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DropDownList ddlAdCate;
		protected System.Web.UI.WebControls.TextBox tbxAdMonth;
		protected System.Web.UI.WebControls.RegularExpressionValidator revAdMonth;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvAdMonth;
		protected System.Web.UI.WebControls.Label lblMessage2;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Web.UI.WebControls.DataGrid dgdIaList;
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPub;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaIaList;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Panel pnlIaList;
		protected System.Web.UI.WebControls.Panel pnlQuery;
	
		public IA1CheckList()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				//一開始先藏起來
				this.pnlIaList.Visible = false;
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
			System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
			    
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCnnMRLPub = new System.Data.SqlClient.SqlConnection();
			this.sqlDaIaList = new System.Data.SqlClient.SqlDataAdapter();
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.ia.ia_iaid, dbo.ia.ia_syscd, dbo.ia.ia_iasdate, dbo.ia.ia_iasseq, dbo.ia.ia_iaitem, dbo.ia.ia_iano, dbo.ia.ia_refno, RTRIM(dbo.ia.ia_mfrno) AS ia_mfrno, dbo.ia.ia_pyno, dbo.ia.ia_pyseq, dbo.ia.ia_pyat, dbo.ia.ia_ivat, dbo.ia.ia_invno, dbo.ia.ia_invdate, dbo.ia.ia_fgitri, RTRIM(dbo.ia.ia_rnm) AS ia_rnm, RTRIM(dbo.ia.ia_raddr) AS ia_raddr, RTRIM(dbo.ia.ia_rzip) AS ia_rzip, RTRIM(dbo.ia.ia_rjbti) AS ia_rjbti, RTRIM(dbo.ia.ia_rtel) AS ia_rtel, dbo.ia.ia_fgnonauto, dbo.ia.ia_invcd, dbo.ia.ia_taxtp, dbo.ia.ia_status, RTRIM(dbo.ia.ia_cname) AS ia_cname, RTRIM(dbo.ia.ia_tel) AS ia_tel, dbo.ia.ia_contno, dbo.iad.iad_iadid, dbo.iad.iad_syscd, dbo.iad.iad_iano, dbo.iad.iad_iaditem, dbo.iad.iad_fk2, dbo.iad.iad_fk3, dbo.iad.iad_fk4, dbo.iad.iad_fk4 AS Expr1, dbo.iad.iad_projno, dbo.iad.iad_costctr, RTRIM(dbo.iad.iad_desc) AS iad_desc, dbo.iad.iad_qty, dbo.iad.iad_unit, dbo.iad.iad_uprice, dbo.iad.iad_amt, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, dbo.c4_cont.cont_contno, dbo.c4_cont.cont_syscd FROM dbo.ia INNER JOIN dbo.iad ON dbo.ia.ia_syscd = dbo.iad.iad_syscd AND dbo.ia.ia_iano = dbo.iad.iad_iano INNER JOIN dbo.c4_cont ON dbo.iad.iad_fk2 = dbo.c4_cont.cont_contno INNER JOIN dbo.mfr ON dbo.ia.ia_mfrno = dbo.mfr.mfr_mfrno WHERE (dbo.ia.ia_syscd = 'C4') AND (dbo.c4_cont.cont_fgpayonce = '1') ORDER BY dbo.ia.ia_iano DESC";
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

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			this.pnlIaList.Visible = false;
			this.ddlAdCate.SelectedIndex = 0;
			this.tbxAdMonth.Text = "";
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

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			Bind_dgdIaList();
		}

		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			//列印出來
			Response.Redirect("");
		}

	}
}
