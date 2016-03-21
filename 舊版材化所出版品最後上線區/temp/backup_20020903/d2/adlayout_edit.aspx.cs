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
	/// Summary description for adlayout_edit.
	/// </summary>
	public class adlayout_edit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox ltp_ltpcd;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox ltp_nm;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnReturnHome;

		// 宣告 global_cd
		private static string global_cd;


		public adlayout_edit()
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
			SqlDataAdapter cmd=new SqlDataAdapter("select * from c2_ltp where ltp_ltpid='" + id + "'",myConn);
		
			DataSet ds = new DataSet();
			cmd.Fill(ds, "c2_ltp");
			DataView dv = ds.Tables["c2_ltp"].DefaultView;
			
			string code = dv[0]["ltp_ltpcd"].ToString();
			string nm = dv[0]["ltp_nm"].ToString();
			
			ltp_ltpcd.Text = code.Trim();
			ltp_nm.Text = nm.Trim();
			
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
			string SQL = "select * from c2_ltp";
			
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			dv.RowFilter = "ltp_ltpcd = '" + ltp_ltpcd.Text.Trim() +"'";

			if (dv.Count > 0 && ltp_ltpcd.Text != global_cd)
			{
				Label1.Text="此筆資料已經存在!";
			}

			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter("update c2_ltp set ltp_ltpcd=@ltp_ltpcd,ltp_nm=@ltp_nm where ltp_ltpid=@ltp_ltpid",myConn);
		
				cmd.SelectCommand.Parameters.Add("@ltp_ltpid",SqlDbType.Int,4).Value = id;
				cmd.SelectCommand.Parameters.Add("@ltp_ltpcd",SqlDbType.Char,2).Value = ltp_ltpcd.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@ltp_nm",SqlDbType.Char,10).Value = ltp_nm.Text.Trim();
			
				DataSet ds1 = new DataSet();
				cmd.Fill(ds1,"Title");
				Response.Redirect("adlayout.aspx");
			}

		}


		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("adlayout.aspx");
		}



	}
}
