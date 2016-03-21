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
	public class mailer_edit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox ml_mlcd;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox ml_nm;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		private static string global_mlcd;
	
		public mailer_edit()
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
						
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["mrlpub1"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			SqlDataAdapter cmd=new SqlDataAdapter("select * from mailer where ml_mlid='" + id + "'",myConn);
		
			DataSet ds = new DataSet();
			cmd.Fill(ds, "mailer");
			DataView dv = ds.Tables["mailer"].DefaultView;
			
			if (dv.Count <= 0)
			{
				Response.Redirect("nodata.aspx");
			}
			
			string mlcd = dv[0]["ml_mlcd"].ToString();
			string nm = dv[0]["ml_nm"].ToString();
			
			ml_mlcd.Text=mlcd.Trim();
			ml_nm.Text=nm.Trim();
			
			global_mlcd = mlcd.Trim();
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

			string strConn = System.Configuration.ConfigurationSettings.AppSettings["mrlpub1"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			string SQL = "select * from mailer";
			
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			dv.RowFilter = "ml_mlcd = '" + ml_mlcd.Text.Trim() +"'";

			if (dv.Count > 0 && ml_mlcd.Text != global_mlcd)
			{
				Label1.Text="此筆資料已經存在!";
			}

			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("update mailer set ml_mlcd=@ml_mlcd,ml_nm=@ml_nm where ml_mlid=@ml_mlid",myConn);
		
				cmd.SelectCommand.Parameters.Add("@ml_mlid",SqlDbType.Int,4).Value=id;
				cmd.SelectCommand.Parameters.Add("@ml_mlcd",SqlDbType.Char,2).Value=ml_mlcd.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@ml_nm",SqlDbType.Char,10).Value=ml_nm.Text.Trim();
			
				DataSet ds1 = new DataSet();
				cmd.Fill(ds1,"Title");
				Response.Redirect("mailer.aspx?ID=edit_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("mailer.aspx");
		}
	}
}
