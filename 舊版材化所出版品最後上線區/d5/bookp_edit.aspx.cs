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
	public class bookp_edit : System.Web.UI.Page
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
		private static string global_bkcd;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.Button btnUpdate;
		private static string global_date;
	
		public bookp_edit()
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
			SqlDataAdapter cmd1=new SqlDataAdapter("select * from book",myConn);

			DataSet ds1 = new DataSet();
			cmd1.Fill(ds1, "bookp");
			DataView dv1 = ds1.Tables["bookp"].DefaultView;

			this.ddlbkp_bkcd.DataTextField = "bk_nm";
			this.ddlbkp_bkcd.DataValueField = "bk_bkcd";
			this.ddlbkp_bkcd.DataSource = dv1;
			this.ddlbkp_bkcd.DataBind();

			//string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			//SqlConnection myConn=new SqlConnection(strConn);
			SqlDataAdapter cmd=new SqlDataAdapter("select * from bookp where bkp_bkpid='" + id + "'",myConn);
		
			DataSet ds = new DataSet();
			cmd.Fill(ds, "bookp");
			DataView dv = ds.Tables["bookp"].DefaultView;
			
			if (dv.Count <= 0)
			{
				Response.Redirect("nodata.aspx");
			}
			
			string bkcd = dv[0]["bkp_bkcd"].ToString();
			string date = dv[0]["bkp_date"].ToString();
			string pno = dv[0]["bkp_pno"].ToString();
			
			//ddlbkp_bkcd.SelectedItem.Value=bkcd.Trim();
			for(int i=0;i<ddlbkp_bkcd.Items.Count;i++)
			{
				if (ddlbkp_bkcd.Items[i].Value == bkcd.Trim())
				{
					ddlbkp_bkcd.SelectedIndex = i;
				}
			}

			bkp_date.Text=date.Trim();
			bkp_pno.Text=pno.Trim();

			global_bkcd = bkcd.Trim();
			global_date = date.Trim();
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
			string SQL = "select * from bookp";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			dv.RowFilter = "bkp_bkcd = '" + ddlbkp_bkcd.SelectedItem.Value.Trim() +"' AND bkp_date = '" + bkp_date.Text.Trim() +"'";

			if (dv.Count > 0 && (ddlbkp_bkcd.SelectedItem.Value != global_bkcd || bkp_date.Text != global_date))
			{
				Label1.Text="此筆資料已經存在!";
			}

			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("update bookp set bkp_bkcd=@bkp_bkcd,bkp_date=@bkp_date,bkp_pno=@bkp_pno where bkp_bkpid=@bkp_bkpid",myConn);
		
				cmd.SelectCommand.Parameters.Add("@bkp_bkpid",SqlDbType.Int,4).Value=id;
				cmd.SelectCommand.Parameters.Add("@bkp_bkcd",SqlDbType.Char,2).Value=ddlbkp_bkcd.SelectedItem.Value;
				cmd.SelectCommand.Parameters.Add("@bkp_date",SqlDbType.Char,6).Value=bkp_date.Text;
				cmd.SelectCommand.Parameters.Add("@bkp_pno",SqlDbType.Char,4).Value=bkp_pno.Text;
						
				DataSet ds1 = new DataSet();
				cmd.Fill(ds1,"Title");
			
				Response.Redirect("bookp.aspx?ID=edit_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("bookp.aspx");
		}
	}
}
