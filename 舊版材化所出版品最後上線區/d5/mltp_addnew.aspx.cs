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
	/// Summary description for mfr_addnew.
	/// </summary>
	public class mltp_addnew : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox bk_nm;
		protected System.Web.UI.WebControls.TextBox bk_bkcd;
		protected System.Web.UI.WebControls.TextBox bkp_date;
		protected System.Web.UI.WebControls.TextBox bkp_pno;
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.DropDownList ddlmltp_syscd;
		protected System.Web.UI.WebControls.DropDownList ddlmltp_mlcd;
		protected System.Web.UI.WebControls.DropDownList ddlmltp_mltpcd;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.DropDownList ddlbkp_bkcd;
	
		public mltp_addnew()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
				InitData();
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
			//string id = Request.QueryString["ID"].ToString();
						
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			
			SqlDataAdapter cmd=new SqlDataAdapter("select * from syscd",myConn);
			DataSet ds = new DataSet();
			cmd.Fill(ds, "syscd");
			DataView dv = ds.Tables["syscd"].DefaultView;
			this.ddlmltp_syscd.DataTextField = "sys_nm";
			this.ddlmltp_syscd.DataValueField = "sys_syscd";
			this.ddlmltp_syscd.DataSource = dv;
			this.ddlmltp_syscd.DataBind();
			
			SqlDataAdapter cmd1=new SqlDataAdapter("select * from mailer",myConn);
			DataSet ds1 = new DataSet();
			cmd1.Fill(ds1, "mailer");
			DataView dv1 = ds1.Tables["mailer"].DefaultView;
			this.ddlmltp_mlcd.DataTextField = "ml_nm";
			this.ddlmltp_mlcd.DataValueField = "ml_mlcd";
			this.ddlmltp_mlcd.DataSource = dv1;
			this.ddlmltp_mlcd.DataBind();

			SqlDataAdapter cmd2=new SqlDataAdapter("select * from mtp",myConn);
			DataSet ds2 = new DataSet();
			cmd2.Fill(ds2, "mtp");
			DataView dv2 = ds2.Tables["mtp"].DefaultView;
			this.ddlmltp_mltpcd.DataTextField = "mtp_nm";
			this.ddlmltp_mltpcd.DataValueField = "mtp_mtpcd";
			this.ddlmltp_mltpcd.DataSource = dv2;
			this.ddlmltp_mltpcd.DataBind();
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		private void btnAddNew_Click(object sender, System.EventArgs e)
		{
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			string SQL = "select * from mltp";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds1 = new DataSet();
			myCommand.Fill(ds1,"Title");

			DataView dv = ds1.Tables["Title"].DefaultView;
			dv.RowFilter = "mltp_syscd = '" + ddlmltp_syscd.SelectedItem.Value.Trim() +"' AND mltp_mlcd = '" + ddlmltp_mlcd.SelectedItem.Value.Trim() +"' AND mltp_mltpcd = '" + ddlmltp_mltpcd.SelectedItem.Value.Trim() +"'";

			//DataGrid1.DataSource = dv;
			//DataGrid1.DataBind();

			if (dv.Count > 0)
			{
				Label1.Text="此筆資料已經存在!";
			}
			
			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("insert into mltp(mltp_syscd,mltp_mlcd,mltp_mltpcd) values(@mltp_syscd,@mltp_mlcd,@mltp_mltpcd)",myConn);
		
				cmd.SelectCommand.Parameters.Add("@mltp_syscd",SqlDbType.Char,2).Value=ddlmltp_syscd.SelectedItem.Value.Trim();
				cmd.SelectCommand.Parameters.Add("@mltp_mlcd",SqlDbType.Char,2).Value=ddlmltp_mlcd.SelectedItem.Value.Trim();
				cmd.SelectCommand.Parameters.Add("@mltp_mltpcd",SqlDbType.Char,2).Value=ddlmltp_mltpcd.SelectedItem.Value.Trim();
				
				DataSet ds = new DataSet();
				cmd.Fill(ds,"Title");

				Response.Redirect("mltp.aspx?ID=addnew_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("mltp.aspx");
		}
	}
}
