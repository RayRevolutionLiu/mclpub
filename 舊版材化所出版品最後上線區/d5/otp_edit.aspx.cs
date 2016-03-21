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
	/// Summary description for otp_edit.
	/// </summary>
	public class otp_edit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.TextBox otp_otp1cd;
		protected System.Web.UI.WebControls.TextBox otp_otp1nm;
		protected System.Web.UI.WebControls.TextBox otp_otp2cd;
		protected System.Web.UI.WebControls.TextBox otp_otp2nm;
		protected System.Web.UI.WebControls.DropDownList ddlotp_otp1cd;
		private static string global_otp1cd;
		private static string global_otp2cd;
	
		public otp_edit()
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
						
			String strConn=System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			SqlDataAdapter cmd=new SqlDataAdapter("select * from c1_otp where otp_otpid='" + id + "'",myConn);
		
			DataSet ds = new DataSet();
			cmd.Fill(ds, "Title");
			DataView dv = ds.Tables["Title"].DefaultView;
			
			if (dv.Count <= 0)
			{
				Response.Redirect("nodata.aspx");
			}
			
			string otp1cd = dv[0]["otp_otp1cd"].ToString();
			string otp2cd = dv[0]["otp_otp2cd"].ToString();
			string otp2nm = dv[0]["otp_otp2nm"].ToString();
			
			for(int i=0;i<ddlotp_otp1cd.Items.Count;i++)
			{
				if (ddlotp_otp1cd.Items[i].Value.Trim() == otp1cd.Trim())
				{
					ddlotp_otp1cd.SelectedIndex = i;
				}
			}
			
			otp_otp2cd.Text=otp2cd.Trim();
			otp_otp2nm.Text=otp2nm.Trim();
			
			global_otp1cd = otp1cd.Trim();
			global_otp2cd = otp2cd.Trim();
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

			String strConn=System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			string SQL = "select * from c1_otp";
			
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			dv.RowFilter = "otp_otp1cd = '" + ddlotp_otp1cd.SelectedItem.Value.Trim() +"' AND otp_otp2cd = '" + otp_otp2cd.Text.Trim() +"'";

			if (dv.Count > 0 && (ddlotp_otp1cd.SelectedItem.Value != global_otp1cd || otp_otp2cd.Text != global_otp2cd))
			{
				Label1.Text="此筆資料已經存在!";
			}

			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("update c1_otp set otp_otp1cd=@otp_otp1cd,otp_otp1nm=@otp_otp1nm,otp_otp2cd=@otp_otp2cd,otp_otp2nm=@otp_otp2nm where otp_otpid=@otp_otpid",myConn);
		
				cmd.SelectCommand.Parameters.Add("@otp_otpid",SqlDbType.Int,4).Value=id;
				cmd.SelectCommand.Parameters.Add("@otp_otp1cd",SqlDbType.Char,2).Value=ddlotp_otp1cd.SelectedItem.Value.Trim();
				cmd.SelectCommand.Parameters.Add("@otp_otp1nm",SqlDbType.Char,8).Value=ddlotp_otp1cd.SelectedItem.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@otp_otp2cd",SqlDbType.Char,2).Value=otp_otp2cd.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@otp_otp2nm",SqlDbType.Char,20).Value=otp_otp2nm.Text.Trim();
			
				DataSet ds1 = new DataSet();
				cmd.Fill(ds1,"Title");
				Response.Redirect("otp.aspx?ID=edit_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("otp.aspx");
		}
	}
}
