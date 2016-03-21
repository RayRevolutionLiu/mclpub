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
	/// Summary description for book_edit.
	/// </summary>
	public class book_edit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox bk_bkcd;
		protected System.Web.UI.WebControls.TextBox bk_nm;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		private static string global_bkcd;
		
	
		public book_edit()
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
			SqlDataAdapter cmd=new SqlDataAdapter("select * from book where bk_bkid='" + id + "'",myConn);
		
			DataSet ds = new DataSet();
			cmd.Fill(ds, "book");
			DataView dv = ds.Tables["book"].DefaultView;
			
			if (dv.Count <= 0)
			{
				Response.Redirect("nodata.aspx");
			}
			
			string bkcd = dv[0]["bk_bkcd"].ToString();
			string nm = dv[0]["bk_nm"].ToString();
			
			bk_bkcd.Text=bkcd.Trim();
			bk_nm.Text=nm.Trim();
			
			global_bkcd = bkcd.Trim();
			
			//Response.Write(global_bkcd.ToString());
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
			string SQL = "select * from book";
			
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			dv.RowFilter = "bk_bkcd = '" + bk_bkcd.Text.Trim() +"'";

			if (dv.Count > 0 && bk_bkcd.Text != global_bkcd)
			{
				Label1.Text="此筆資料已經存在!";
			}

			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("update book set bk_bkcd=@bk_bkcd,bk_nm=@bk_nm where bk_bkid=@bk_bkid",myConn);
		
				cmd.SelectCommand.Parameters.Add("@bk_bkid",SqlDbType.Int,4).Value=id;
				cmd.SelectCommand.Parameters.Add("@bk_bkcd",SqlDbType.Char,2).Value=bk_bkcd.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@bk_nm",SqlDbType.Char,10).Value=bk_nm.Text.Trim();
			
				DataSet ds1 = new DataSet();
				cmd.Fill(ds1,"Title");
				Response.Redirect("book.aspx?ID=edit_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("book.aspx");
		}
	}
}
