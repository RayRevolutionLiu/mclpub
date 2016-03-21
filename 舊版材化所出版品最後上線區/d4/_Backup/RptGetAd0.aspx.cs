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
	/// Summary description for RptGetAd0.
	/// </summary>
	public class RptGetAd0 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.LinkButton lnbClearAll;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.RequiredFieldValidator rfvyyyymm;
		protected System.Web.UI.WebControls.RegularExpressionValidator revyyyymm;
		protected System.Data.SqlClient.SqlConnection sqlCnnMrlPub;
		protected System.Data.SqlClient.SqlCommand sqlCmdExecSp;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaSrspn;
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.TextBox tbxyyyymm;
	
		public RptGetAd0()
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
			this.sqlCnnMrlPub = new System.Data.SqlClient.SqlConnection();
			this.sqlDaSrspn = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCmdExecSp = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.lnbClearAll.Click += new System.EventHandler(this.lnbClearAll_Click);
			// 
			// sqlCnnMrlPub
			// 
			this.sqlCnnMrlPub.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDaSrspn
			// 
			this.sqlDaSrspn.SelectCommand = this.sqlSelectCommand1;
			// 
			// sqlCmdExecSp
			// 
			this.sqlCmdExecSp.CommandText = "sp_c4_rp_getad";
			this.sqlCmdExecSp.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdExecSp.Connection = this.sqlCnnMrlPub;
			this.sqlCmdExecSp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT srspn_empno, srspn_id, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, s" +
				"rspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn WHERE (srspn_atype = \'B\') OR (" +
				"srspn_atype = \'C\')";
			this.sqlSelectCommand1.Connection = this.sqlCnnMrlPub;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void InitData()
		{
			Bind_ddlEmpNo();
		}

		private void Bind_ddlEmpNo()
		{
			DataSet ds = new DataSet();
			this.sqlDaSrspn.Fill(ds, "SRSPN");
			DataView dv = ds.Tables["SRSPN"].DefaultView;
			ddlEmpNo.DataSource = dv;
			ddlEmpNo.DataTextField = "srspn_cname";
			ddlEmpNo.DataValueField = "srspn_empno";
			ddlEmpNo.DataBind();

			ddlEmpNo.Items.Insert(0, new ListItem("¥þ³¡", "all"));
		}

		private void lnbClearAll_Click(object sender, System.EventArgs e)
		{
			this.tbxyyyymm.Text = "";
		}

		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			//this.sqlCmdExecSp.Parameters["@empno"].Value = this.ddlEmpNo.SelectedItem.Value.Trim();
			this.sqlCmdExecSp.Parameters["@yyyymm"].Value = DateTime.ParseExact(this.tbxyyyymm.Text.Trim(), "yyyy/MM", null).ToString("yyyyMM");
			this.sqlCmdExecSp.Connection.Open();
			try
			{
				this.sqlCmdExecSp.ExecuteNonQuery();
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
			}
			this.sqlCmdExecSp.Connection.Close();

			Response.Redirect("RptGetAd.aspx?Qempno="+ddlEmpNo.SelectedItem.Value.Trim());
		}

	}
}
