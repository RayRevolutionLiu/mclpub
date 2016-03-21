using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace MRLPub.d5
{
	/// <summary>
	/// Summary description for mailer_edit.
	/// </summary>
	public class syscd_edit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox itp_itpcd;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox itp_nm;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.TextBox btp_btpcd;
		protected System.Web.UI.WebControls.TextBox btp_nm;
		protected System.Web.UI.WebControls.TextBox sys_syscd;
		protected System.Web.UI.WebControls.TextBox sys_nm;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.TextBox sys_deptcd;
		private static string global_syscd;
	
		public syscd_edit()
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
						
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			SqlDataAdapter cmd=new SqlDataAdapter("select * from syscd where sys_sysid='" + id + "'",myConn);
		
			DataSet ds = new DataSet();
			cmd.Fill(ds, "syscd");
			DataView dv = ds.Tables["syscd"].DefaultView;
			
			if (dv.Count <= 0)
			{
				Response.Redirect("nodata.aspx");
			}
			
			else
			{
				string syscd = dv[0]["sys_syscd"].ToString();
				string nm = dv[0]["sys_nm"].ToString();
				string deptcd = dv[0]["sys_deptcd"].ToString();
			
				sys_syscd.Text=syscd.Trim();
				sys_nm.Text=nm.Trim();
				sys_deptcd.Text=deptcd.Trim();
			
				global_syscd = syscd.Trim();
			}
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

			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			string SQL = "select * from syscd";
			
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			dv.RowFilter = "sys_syscd = '" + sys_syscd.Text.Trim() +"'";

			if (dv.Count > 0 && sys_syscd.Text != global_syscd)
			{
				Label1.Text="此筆資料已經存在!";
			}

			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("update syscd set sys_syscd=@sys_syscd,sys_nm=@sys_nm,sys_deptcd=@sys_deptcd where sys_sysid=@sys_sysid",myConn);
		
				cmd.SelectCommand.Parameters.Add("@sys_sysid",SqlDbType.Int,4).Value=id;
				cmd.SelectCommand.Parameters.Add("@sys_syscd",SqlDbType.Char,2).Value=sys_syscd.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@sys_nm",SqlDbType.Char,12).Value=sys_nm.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@sys_deptcd",SqlDbType.Char,7).Value=sys_deptcd.Text.Trim();
			
				DataSet ds1 = new DataSet();
				cmd.Fill(ds1,"Title");
				Response.Redirect("syscd.aspx?ID=edit_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("syscd.aspx");
		}
	}
}
