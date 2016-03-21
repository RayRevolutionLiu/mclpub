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
// SQL
using System.Data.SqlClient;
// WebApplication Virables - Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for njtype_edit.
	/// </summary>
	public class njtype_edit : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox njtp_njtpcd;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox njtp_nm;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnReturnHome;


		// 宣告 global_cd
		private static string global_cd;


		public njtype_edit()
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


		private void InitData()
		{
			string id = Request.QueryString["ID"].ToString();

			//String strConn="server=isccom2;database=mrlpub;uid=webuser;pwd=db600";
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			SqlDataAdapter cmd=new SqlDataAdapter("select * from c2_njtp where njtp_njtpid='" + id + "'",myConn);

			DataSet ds = new DataSet();
			cmd.Fill(ds, "c2_njtp");
			DataView dv = ds.Tables["c2_njtp"].DefaultView;

			string code = dv[0]["njtp_njtpcd"].ToString();
			string nm = dv[0]["njtp_nm"].ToString();

			njtp_njtpcd.Text = code.Trim();
			njtp_nm.Text = nm.Trim();

			global_cd = code.Trim();

			//Response.Write(global_cd.ToString());
		}


		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			string id = Request.QueryString["ID"].ToString();

			//String strConn="server=isccom2;database=mrlpub;uid=webuser;pwd=db600";
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			string SQL = "select * from c2_njtp";

			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			dv.RowFilter = "njtp_njtpcd = '" + njtp_njtpcd.Text.Trim() +"'";

			if (dv.Count > 0 && njtp_njtpcd.Text != global_cd)
			{
				Label1.Text="此筆資料已經存在!";
			}

			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("update c2_njtp set njtp_njtpcd=@njtp_njtpcd,njtp_nm=@njtp_nm where njtp_njtpid=@njtp_njtpid",myConn);

				cmd.SelectCommand.Parameters.Add("@njtp_njtpid",SqlDbType.Int,4).Value = id;
				cmd.SelectCommand.Parameters.Add("@njtp_njtpcd",SqlDbType.Char,2).Value = njtp_njtpcd.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@njtp_nm",SqlDbType.Char,10).Value = njtp_nm.Text.Trim();

				DataSet ds1 = new DataSet();
				cmd.Fill(ds1,"Title");
				Response.Redirect("njtype.aspx");
			}

		}


		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("njtype.aspx");
		}


	}
}
