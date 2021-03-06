using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
// SQL
using System.Data.SqlClient;
namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adcolor_edit.
	/// </summary>
	public class adcolor_edit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.TextBox clr_clrcd;
		protected System.Web.UI.WebControls.TextBox clr_nm;
		protected System.Web.UI.WebControls.Button btnReturnHome;

		// 宣告 global_cd
		private static string global_cd;

	
		public adcolor_edit()
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
						
			String strConn="server=isccom1;database=mrlpub;uid=webuser;pwd=db600";
			SqlConnection myConn=new SqlConnection(strConn);
			SqlDataAdapter cmd=new SqlDataAdapter("select * from c2_clr where clr_clrid='" + id + "'",myConn);
		
			DataSet ds = new DataSet();
			cmd.Fill(ds, "c2_clr");
			DataView dv = ds.Tables["c2_clr"].DefaultView;
			
			string code = dv[0]["clr_clrcd"].ToString();
			string nm = dv[0]["clr_nm"].ToString();
			
			clr_clrcd.Text = code.Trim();
			clr_nm.Text = nm.Trim();
			
			global_cd = code.Trim();
			
			//Response.Write(global_cd.ToString());
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

			String strConn="server=isccom1;database=mrlpub;uid=webuser;pwd=db600";
			SqlConnection myConn=new SqlConnection(strConn);
			string SQL = "select * from c2_clr";
			
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			dv.RowFilter = "clr_clrcd = '" + clr_clrcd.Text.Trim() +"'";

			if (dv.Count > 0 && clr_clrcd.Text != global_cd)
			{
				Label1.Text="此筆資料已經存在!";
			}

			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("update c2_clr set clr_clrcd=@clr_clrcd,clr_nm=@clr_nm where clr_clrid=@clr_clrid",myConn);
		
				cmd.SelectCommand.Parameters.Add("@clr_clrid",SqlDbType.Int,4).Value = id;
				cmd.SelectCommand.Parameters.Add("@clr_clrcd",SqlDbType.Char,2).Value = clr_clrcd.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@clr_nm",SqlDbType.Char,10).Value = clr_nm.Text.Trim();
				
				DataSet ds1 = new DataSet();
				cmd.Fill(ds1,"Title");
				Response.Redirect("adcolor.aspx");
			}

		}


		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("adcolor.aspx");
		}


	}
}
