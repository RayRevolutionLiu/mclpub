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
	/// Summary description for book_addnew.
	/// </summary>
	public class mltp_edit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.TextBox bk_nm;
		protected System.Web.UI.WebControls.TextBox bkp_bkcd;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.TextBox bkp_date;
		protected System.Web.UI.WebControls.TextBox bkp_pno;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator3;
		protected System.Web.UI.WebControls.DropDownList ddlbkp_bkcd;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.DropDownList ddlmltp_syscd;
		protected System.Web.UI.WebControls.DropDownList ddlmltp_mlcd;
		protected System.Web.UI.WebControls.DropDownList ddlmltp_mltpcd;
		private static string global_syscd;
		private static string global_mlcd;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		private static string global_mltpcd;
	
		public mltp_edit()
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
			string id = Request.QueryString["ID"].ToString();
						
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["mrlpub1"].ToString();
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
						
			SqlDataAdapter cmd3=new SqlDataAdapter("select * from mltp where mltp_mltpid='" + id + "'",myConn);
		
			DataSet ds3 = new DataSet();
			cmd3.Fill(ds3, "mltp");
			DataView dv3 = ds3.Tables["mltp"].DefaultView;
			
			if (dv3.Count <= 0)
			{
				Response.Redirect("nodata.aspx");
			}
			
			string syscd = dv3[0]["mltp_syscd"].ToString();
			string mlcd = dv3[0]["mltp_mlcd"].ToString();
			string mltpcd = dv3[0]["mltp_mltpcd"].ToString();
			
			for(int i=0;i<ddlmltp_syscd.Items.Count;i++)
			{
				if (ddlmltp_syscd.Items[i].Value == syscd.Trim())
				{
					ddlmltp_syscd.SelectedIndex = i;
				}
			}

			for(int i=0;i<ddlmltp_mlcd.Items.Count;i++)
			{
				if (ddlmltp_mlcd.Items[i].Value == mlcd.Trim())
				{
					ddlmltp_mlcd.SelectedIndex = i;
				}
			}

			for(int i=0;i<ddlmltp_mltpcd.Items.Count;i++)
			{
				if (ddlmltp_mltpcd.Items[i].Value == mltpcd.Trim())
				{
					ddlmltp_mltpcd.SelectedIndex = i;
				}
			}

			global_syscd = syscd.Trim();
			global_mlcd = mlcd.Trim();
			global_mltpcd = mltpcd.Trim();			
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
			string SQL = "select * from mltp";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			dv.RowFilter = "mltp_syscd = '" + ddlmltp_syscd.SelectedItem.Value.Trim() +"' AND mltp_mlcd = '" + ddlmltp_mlcd.SelectedItem.Value.Trim() +"' AND mltp_mltpcd = '" + ddlmltp_mltpcd.SelectedItem.Value.Trim() +"'";

			if (dv.Count > 0 && (ddlmltp_syscd.SelectedItem.Value != global_syscd || ddlmltp_mlcd.SelectedItem.Value != global_mlcd || ddlmltp_mltpcd.SelectedItem.Value != global_mltpcd))
			{
				Label1.Text="此筆資料已經存在!";
			}

			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("update mltp set mltp_syscd=@mltp_syscd,mltp_mlcd=@mltp_mlcd,mltp_mltpcd=@mltp_mltpcd where mltp_mltpid=@mltp_mltpid",myConn);
		
				cmd.SelectCommand.Parameters.Add("@mltp_mltpid",SqlDbType.Int,4).Value=id;
				cmd.SelectCommand.Parameters.Add("@mltp_syscd",SqlDbType.Char,2).Value=ddlmltp_syscd.SelectedItem.Value;
				cmd.SelectCommand.Parameters.Add("@mltp_mlcd",SqlDbType.Char,2).Value=ddlmltp_mlcd.SelectedItem.Value;
				cmd.SelectCommand.Parameters.Add("@mltp_mltpcd",SqlDbType.Char,2).Value=ddlmltp_mltpcd.SelectedItem.Value;
						
				DataSet ds1 = new DataSet();
				cmd.Fill(ds1,"Title");
			
				Response.Redirect("mltp.aspx?ID=edit_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("mltp.aspx");
		}
	}
}
