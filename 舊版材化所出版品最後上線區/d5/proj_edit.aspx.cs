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
	public class proj_edit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox bkp_date;
		protected System.Web.UI.WebControls.TextBox bkp_pno;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DropDownList ddlproj_syscd;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.DropDownList ddlproj_bkcd;
		protected System.Web.UI.WebControls.TextBox proj_projno;
		protected System.Web.UI.WebControls.TextBox proj_costctr;
		protected System.Web.UI.WebControls.TextBox proj_cont;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.DropDownList ddlbkp_bkcd;
		private static string global_syscd;
		private static string global_bkcd;
		protected System.Web.UI.WebControls.DropDownList ddlproj_fgitri;
		private static string global_fgitri;
	
		public proj_edit()
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

			SqlDataAdapter cmd2=new SqlDataAdapter("select * from fgitri",myConn);
			DataSet ds2 = new DataSet();
			cmd2.Fill(ds2, "fgitri");
			DataView dv2 = ds2.Tables["fgitri"].DefaultView;
			this.ddlproj_fgitri.DataTextField = "fgitri_name";
			this.ddlproj_fgitri.DataValueField = "fgitri_fgitri";
			this.ddlproj_fgitri.DataSource = dv2;
			this.ddlproj_fgitri.DataBind();

			SqlDataAdapter cmd3=new SqlDataAdapter("select * from proj where proj_projid='" + id + "'",myConn);
					
			DataSet ds3 = new DataSet();
			cmd3.Fill(ds3, "proj");
			DataView dv3 = ds3.Tables["proj"].DefaultView;
			
			if (dv3.Count <= 0)
			{
				Response.Redirect("nodata.aspx");
			}
						
			string strsyscd = dv3[0]["proj_syscd"].ToString();
			string strbkcd = dv3[0]["proj_bkcd"].ToString();
			string strfgitri = dv3[0]["proj_fgitri"].ToString();
			string strprojno = dv3[0]["proj_projno"].ToString();
			string strcostctr = dv3[0]["proj_costctr"].ToString();
			string cont = dv3[0]["proj_cont"].ToString();
						
			for(int i=0;i<ddlproj_syscd.Items.Count;i++)
			{
				if (ddlproj_syscd.Items[i].Value == strsyscd.Trim())
				{
					ddlproj_syscd.SelectedIndex = i;
				}
			}
			
			for(int i=0;i<ddlproj_bkcd.Items.Count;i++)
			{
				if (ddlproj_bkcd.Items[i].Value == strbkcd.Trim())
				{
					ddlproj_bkcd.SelectedIndex = i;
				}
			}
			
			for(int i=0;i<ddlproj_fgitri.Items.Count;i++)
			{
				if (ddlproj_fgitri.Items[i].Value == strfgitri.Trim())
				{
					ddlproj_fgitri.SelectedIndex = i;
				}
			}

			proj_projno.Text=strprojno.Trim();
			proj_costctr.Text=strcostctr.Trim();
			proj_cont.Text=cont.Trim();

			global_syscd = strsyscd.Trim();
			global_bkcd = strbkcd.Trim();
			global_fgitri = strfgitri.Trim();
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
			string SQL = "select * from proj";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			dv.RowFilter = "proj_syscd = '" + ddlproj_syscd.SelectedItem.Value.Trim() +"' AND proj_bkcd = '" + ddlproj_bkcd.SelectedItem.Value.Trim() +"' AND proj_fgitri = '" + ddlproj_fgitri.SelectedItem.Value.Trim() +"'";

			if (dv.Count > 0 && (ddlproj_syscd.SelectedItem.Value != global_syscd || ddlproj_bkcd.SelectedItem.Value != global_bkcd || ddlproj_fgitri.SelectedItem.Value.Trim() != global_fgitri.Trim()))
			{
				Label1.Text="此筆資料已經存在!";
			}

			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter
					("update proj set proj_syscd=@proj_syscd,proj_bkcd=@proj_bkcd,proj_fgitri=@proj_fgitri,proj_projno=@proj_projno,proj_costctr=@proj_costctr,proj_cont=@proj_cont where proj_projid=@proj_projid",myConn);
		
				cmd.SelectCommand.Parameters.Add("@proj_projid",SqlDbType.Int,4).Value=id;
				cmd.SelectCommand.Parameters.Add("@proj_syscd",SqlDbType.Char,2).Value=ddlproj_syscd.SelectedItem.Value.Trim();
				cmd.SelectCommand.Parameters.Add("@proj_bkcd",SqlDbType.Char,2).Value=ddlproj_bkcd.SelectedItem.Value.Trim();
				cmd.SelectCommand.Parameters.Add("@proj_fgitri",SqlDbType.Char,2).Value=ddlproj_fgitri.SelectedItem.Value.Trim();
				cmd.SelectCommand.Parameters.Add("@proj_projno",SqlDbType.Char,10).Value=proj_projno.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@proj_costctr",SqlDbType.Char,7).Value=proj_costctr.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@proj_cont",SqlDbType.Char,12).Value=proj_cont.Text.Trim();

				DataSet ds1 = new DataSet();
				cmd.Fill(ds1,"Title");

				Response.Redirect("proj.aspx?ID=edit_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("proj.aspx");
		}
	}
}
