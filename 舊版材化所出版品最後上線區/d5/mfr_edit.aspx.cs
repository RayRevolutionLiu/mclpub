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
	/// Summary description for edit.
	/// </summary>
	public class mfr_edit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator3;
		protected System.Web.UI.WebControls.TextBox mfr_regdate;
		protected System.Web.UI.WebControls.TextBox mfr_fax;
		protected System.Web.UI.WebControls.TextBox mfr_tel;
		protected System.Web.UI.WebControls.TextBox mfr_respjbti;
		protected System.Web.UI.WebControls.TextBox mfr_respnm;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator4;
		protected System.Web.UI.WebControls.TextBox mfr_izip;
		protected System.Web.UI.WebControls.TextBox mfr_iaddr;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.TextBox mfr_inm;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator7;
		protected System.Web.UI.WebControls.TextBox Textbox10;
		protected System.Web.UI.WebControls.TextBox Textbox11;
		protected System.Web.UI.WebControls.TextBox Textbox12;
		protected System.Web.UI.WebControls.TextBox Textbox13;
		protected System.Web.UI.WebControls.TextBox Textbox14;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator8;
		protected System.Web.UI.WebControls.TextBox Textbox15;
		protected System.Web.UI.WebControls.TextBox Textbox16;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator3;
		protected System.Web.UI.WebControls.TextBox Textbox17;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator9;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator4;
		protected System.Web.UI.WebControls.TextBox Textbox18;
		protected System.Web.UI.WebControls.Button btnGoMain;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.Label mfr_mfrno;
		private static string global_mfrno;
	
		public mfr_edit()
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
			SqlDataAdapter cmd=new SqlDataAdapter("select * from mfr where mfr_mfrid='" + id + "'",myConn);
		
			DataSet ds = new DataSet();
			cmd.Fill(ds, "mfr");
			DataView dv = ds.Tables["mfr"].DefaultView;
			
			if (dv.Count <= 0)
			{
				Response.Redirect("nodata.aspx");
			}
			
			string mfrno = dv[0]["mfr_mfrno"].ToString();
			string inm = dv[0]["mfr_inm"].ToString();
			string iaddr = dv[0]["mfr_iaddr"].ToString();
			string izip = dv[0]["mfr_izip"].ToString();
			string respnm = dv[0]["mfr_respnm"].ToString();
			string respjbti = dv[0]["mfr_respjbti"].ToString();
			string tel = dv[0]["mfr_tel"].ToString();
			string fax = dv[0]["mfr_fax"].ToString();
			string regdate = dv[0]["mfr_regdate"].ToString();
			
			mfr_mfrno.Text=mfrno.Trim();
			mfr_inm.Text=inm.Trim();
			mfr_iaddr.Text=iaddr.Trim();
			mfr_izip.Text=izip.Trim();
			mfr_respnm.Text=respnm.Trim();
			mfr_respjbti.Text=respjbti.Trim();
			mfr_tel.Text=tel.Trim();
			mfr_fax.Text=fax.Trim();
			mfr_regdate.Text=regdate.Trim();

			global_mfrno = mfrno.Trim();
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
			string SQL = "select * from mfr";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			dv.RowFilter = "mfr_mfrno = '" + mfr_mfrno.Text.Trim() +"'";

			if (dv.Count > 0 && mfr_mfrno.Text != global_mfrno)
			{
				//Label1.Text="此筆資料已經存在!";
			}

			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter
					("update mfr set mfr_mfrno=@mfr_mfrno,mfr_inm=@mfr_inm,mfr_iaddr=@mfr_iaddr,mfr_izip=@mfr_izip,mfr_respnm=@mfr_respnm,mfr_respjbti=@mfr_respjbti,mfr_tel=@mfr_tel,mfr_fax=@mfr_fax,mfr_regdate=@mfr_regdate where mfr_mfrid=@mfr_mfrid",myConn);
		
				cmd.SelectCommand.Parameters.Add("@mfr_mfrid",SqlDbType.Int,4).Value=id;
				cmd.SelectCommand.Parameters.Add("@mfr_mfrno",SqlDbType.Char,10).Value=mfr_mfrno.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@mfr_inm",SqlDbType.Char,50).Value=mfr_inm.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@mfr_iaddr",SqlDbType.Char,1000).Value=mfr_iaddr.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@mfr_izip",SqlDbType.Char,5).Value=mfr_izip.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@mfr_respnm",SqlDbType.Char,30).Value=mfr_respnm.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@mfr_respjbti",SqlDbType.VarChar,12).Value=mfr_respjbti.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@mfr_tel",SqlDbType.VarChar,30).Value=mfr_tel.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@mfr_fax",SqlDbType.VarChar,30).Value=mfr_fax.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@mfr_regdate",SqlDbType.Char,8).Value=mfr_regdate.Text.Trim();
			
				DataSet ds1 = new DataSet();
				cmd.Fill(ds1,"Title");

				Response.Redirect("mfr.aspx?ID=edit_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("mfr.aspx");
		}
	}
}
