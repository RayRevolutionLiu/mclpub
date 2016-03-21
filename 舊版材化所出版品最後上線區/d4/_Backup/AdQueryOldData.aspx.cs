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
	/// Summary description for AdQueryOldData.
	/// </summary>
	public class AdQueryOldData : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPub;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaAdrData;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.HyperLink hylBack;
		protected System.Web.UI.WebControls.TextBox tbxCustNm;
		protected System.Web.UI.WebControls.TextBox tbxMfrNm;
		protected System.Web.UI.WebControls.CheckBox cbxCusrNm;
		protected System.Web.UI.WebControls.CheckBox cbxMfrNm;
		protected System.Web.UI.WebControls.Image imgAdFile;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.DataGrid dgdAdrData;
	
		public AdQueryOldData()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				InitData();
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

			this.sqlCnnMRLPub = new System.Data.SqlClient.SqlConnection();
			this.sqlDaAdrData = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.dgdAdrData.SelectedIndexChanged += new System.EventHandler(this.dgdAdrData_SelectedIndexChanged);
			// 
			// sqlCnnMRLPub
			// 
			this.sqlCnnMRLPub.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDaAdrData
			// 
			this.sqlDaAdrData.SelectCommand = this.sqlSelectCommand1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c4_adr.adr_navurl, dbo.c4_cont.cont_custno, dbo.c4_cont.cont_mfrno, dbo.c4_adr.adr_sdate, dbo.c4_adr.adr_edate, dbo.c4_adr.adr_contno, dbo.c4_adr.adr_seq, dbo.c4_adr.adr_syscd, dbo.c4_cont.cont_contno, dbo.c4_cont.cont_syscd, dbo.c4_adr.adr_imgurl, dbo.cust.cust_nm, dbo.mfr.mfr_inm, dbo.cust.cust_custno, dbo.mfr.mfr_mfrno, dbo.c4_adr.adr_alttext FROM dbo.c4_adr INNER JOIN dbo.c4_cont ON dbo.c4_adr.adr_syscd = dbo.c4_cont.cont_syscd AND dbo.c4_adr.adr_contno = dbo.c4_cont.cont_contno INNER JOIN dbo.cust ON dbo.c4_cont.cont_custno = dbo.cust.cust_custno INNER JOIN dbo.mfr ON dbo.c4_cont.cont_mfrno = dbo.mfr.mfr_mfrno";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPub;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void InitData()
		{
//			if (Request.QueryString.Get("CustNo") != null && Request.QueryString.Get("CustNo").Trim() != "")
//			{
//				Bind_dgdAdrData(Request.QueryString.Get("CustNo").Trim());
//				this.tbxCustNo.Text = Request.QueryString.Get("CustNo").Trim();
//				Bind_dgdAdrData(Request.QueryString.Get("CustNo").Trim());
//			}
//			else
//			{
//				//Do Nothing
//			}
		}

		private string GetFilter()
		{
			string strFilter = "";
			int fgCount = 0;
			
			//客戶名稱
			if (cbxCusrNm.Checked && this.tbxCustNm.Text.Trim() != "")
			{
				if (fgCount>0)
				{
					strFilter += " AND ";
				}
				strFilter += "cust_nm LIKE '%" + tbxCustNm.Text.Trim() + "%'";
				fgCount++;
			}

			//廠商名稱
			if (cbxMfrNm.Checked && this.tbxMfrNm.Text.Trim() != "")
			{
				if (fgCount>0)
				{
					strFilter += " AND ";
				}
				strFilter += "mfr_inm LIKE '%" + tbxMfrNm.Text.Trim() + "%'";
				fgCount++;
			}

			return strFilter;
		}

		private void Bind_dgdAdrData(string strFilter)
		{
			DataSet ds = new DataSet();
			this.sqlDaAdrData.Fill(ds, "ADRDATA");
			DataView dv = ds.Tables["ADRDATA"].DefaultView;
			dv.RowFilter = strFilter;
			dgdAdrData.DataSource = dv;
			dgdAdrData.DataBind();
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			dgdAdrData.SelectedIndex = -1;
			imgAdFile.Visible = false;
			Bind_dgdAdrData(GetFilter());
		}

		private void dgdAdrData_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Bind_dgdAdrData(GetFilter());

			if (dgdAdrData.SelectedIndex<0)
			{
				imgAdFile.Visible = false;
			}
			else
			{
				imgAdFile.Visible = true;
				imgAdFile.ImageUrl = "~/d4/AdImages/" + ((LinkButton)dgdAdrData.SelectedItem.Cells[3].Controls[0]).Text.Trim();
			}
		}
	}
}
