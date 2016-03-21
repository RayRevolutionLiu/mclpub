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
	public class rtp_edit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox itp_itpcd;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox itp_nm;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.TextBox rtp_rtpcd;
		protected System.Web.UI.WebControls.TextBox rtp_nm;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		private static string global_rtpcd;
	
		public rtp_edit()
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
			SqlDataAdapter cmd=new SqlDataAdapter("select * from rtp where rtp_rtpid='" + id + "'",myConn);
		
			DataSet ds = new DataSet();
			cmd.Fill(ds, "rtp");
			DataView dv = ds.Tables["rtp"].DefaultView;
			
			if (dv.Count <= 0)
			{
				Response.Redirect("nodata.aspx");
			}
			
			string rtpcd = dv[0]["rtp_rtpcd"].ToString();
			string nm = dv[0]["rtp_nm"].ToString();
			
			rtp_rtpcd.Text=rtpcd.Trim();
			rtp_nm.Text=nm.Trim();
			
			global_rtpcd = rtpcd.Trim();
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
			string SQL = "select * from rtp";
			
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			dv.RowFilter = "rtp_rtpcd = '" + rtp_rtpcd.Text.Trim() +"'";

			if (dv.Count > 0 && rtp_rtpcd.Text != global_rtpcd)
			{
				Label1.Text="此筆資料已經存在!";
			}

			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("update rtp set rtp_rtpcd=@rtp_rtpcd,rtp_nm=@rtp_nm where rtp_rtpid=@rtp_rtpid",myConn);
		
				cmd.SelectCommand.Parameters.Add("@rtp_rtpid",SqlDbType.Int,4).Value=id;
				cmd.SelectCommand.Parameters.Add("@rtp_rtpcd",SqlDbType.Char,2).Value=rtp_rtpcd.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@rtp_nm",SqlDbType.Char,12).Value=rtp_nm.Text.Trim();
			
				DataSet ds1 = new DataSet();
				cmd.Fill(ds1,"Title");
				Response.Redirect("rtp.aspx?ID=edit_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("rtp.aspx");
		}
	}
}
