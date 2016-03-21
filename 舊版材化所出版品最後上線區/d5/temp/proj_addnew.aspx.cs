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
	public class proj_addnew : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.TextBox bkp_date;
		protected System.Web.UI.WebControls.TextBox bkp_pno;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DropDownList ddlproj_syscd;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.DropDownList ddlproj_bkcd;
		protected System.Web.UI.WebControls.TextBox proj_fgitri;
		protected System.Web.UI.WebControls.TextBox proj_projno;
		protected System.Web.UI.WebControls.TextBox proj_costctr;
		protected System.Web.UI.WebControls.TextBox proj_cont;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.DropDownList ddlbkp_bkcd;
	
		public proj_addnew()
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
			this.ddlproj_syscd.DataTextField = "sys_nm";
			this.ddlproj_syscd.DataValueField = "sys_syscd";
			this.ddlproj_syscd.DataSource = dv;
			this.ddlproj_syscd.DataBind();
			
			SqlDataAdapter cmd1=new SqlDataAdapter("select * from book",myConn);
			DataSet ds1 = new DataSet();
			cmd1.Fill(ds1, "book");
			DataView dv1 = ds1.Tables["book"].DefaultView;
			this.ddlproj_bkcd.DataTextField = "bk_nm";
			this.ddlproj_bkcd.DataValueField = "bk_bkcd";
			this.ddlproj_bkcd.DataSource = dv1;
			this.ddlproj_bkcd.DataBind();
			
			this.ddlproj_bkcd.Items.Insert(0, "");
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
			string SQL = "select * from proj";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds1 = new DataSet();
			myCommand.Fill(ds1,"Title");

			DataView dv = ds1.Tables["Title"].DefaultView;
			dv.RowFilter = "proj_syscd = '" + ddlproj_syscd.SelectedItem.Value.Trim() +"' AND proj_bkcd = '" + ddlproj_bkcd.SelectedItem.Value.Trim() +"' AND proj_fgitri = '" + proj_fgitri.Text.Trim() +"'";

			//DataGrid1.DataSource = dv;
			//DataGrid1.DataBind();

			if (dv.Count > 0)
			{
				Label1.Text="此筆資料已經存在!";
			}
			
			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("insert into proj(proj_syscd,proj_bkcd,proj_fgitri,proj_projno,proj_costctr,proj_cont) values(@proj_syscd,@proj_bkcd,@proj_fgitri,@proj_projno,@proj_costctr,@proj_cont)",myConn);
		
				cmd.SelectCommand.Parameters.Add("@proj_syscd",SqlDbType.Char,2).Value=ddlproj_syscd.SelectedItem.Value.Trim();
				cmd.SelectCommand.Parameters.Add("@proj_bkcd",SqlDbType.Char,2).Value=ddlproj_bkcd.SelectedItem.Value.Trim();
				cmd.SelectCommand.Parameters.Add("@proj_fgitri",SqlDbType.Char,2).Value=proj_fgitri.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@proj_projno",SqlDbType.Char,10).Value=proj_projno.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@proj_costctr",SqlDbType.Char,7).Value=proj_costctr.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@proj_cont",SqlDbType.Char,12).Value=proj_cont.Text.Trim();

				DataSet ds = new DataSet();
				cmd.Fill(ds,"Title");

				Response.Redirect("proj.aspx?ID=addnew_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("proj.aspx");
		}
	}
}
