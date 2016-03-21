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
	public class srspn_addnew : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox srspn_empno;
		protected System.Web.UI.WebControls.TextBox srspn_cname;
		protected System.Web.UI.WebControls.TextBox srspn_tel;
		protected System.Web.UI.WebControls.TextBox srspn_deptcd;
		protected System.Web.UI.WebControls.TextBox srspn_date;
		protected System.Web.UI.WebControls.DropDownList ddlsrspn_atype;
		protected System.Web.UI.WebControls.DropDownList ddlsrspn_orgcd;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator1;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.RequiredFieldValidator Requiredfieldvalidator2;
		protected System.Web.UI.WebControls.TextBox srspn_pwd;
		DateTime TodayDate;
	
		public srspn_addnew()
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
						
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["mrlpub1"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			SqlDataAdapter cmd=new SqlDataAdapter("select * from itriorg",myConn);

			DataSet ds = new DataSet();
			cmd.Fill(ds, "Table");
			DataView dv = ds.Tables["Table"].DefaultView;

			this.ddlsrspn_orgcd.DataTextField = "io_orgcname";
			this.ddlsrspn_orgcd.DataValueField = "io_orgcd";
			this.ddlsrspn_orgcd.DataSource = dv;
			this.ddlsrspn_orgcd.DataBind();

			TodayDate = System.DateTime.Today;
			srspn_date.Text = TodayDate.ToString("yyyyMMdd");
			
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
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["mrlpub1"].ToString();
			SqlConnection myConn=new SqlConnection(strConn);
			string SQL = "select * from srspn";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds1 = new DataSet();
			myCommand.Fill(ds1,"srspn");

			DataView dv = ds1.Tables["srspn"].DefaultView;
			dv.RowFilter = "srspn_empno = '" + srspn_empno.Text.Trim() +"'";

			//DataGrid1.DataSource = dv;
			//DataGrid1.DataBind();

			if (dv.Count > 0)
			{
				Label1.Text="此筆資料已經存在!";
			}
			
			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter
					("insert into srspn(srspn_empno,srspn_cname,srspn_tel,srspn_atype,srspn_orgcd,srspn_deptcd,srspn_date,srspn_pwd) values(@srspn_empno,@srspn_cname,@srspn_tel,@srspn_atype,@srspn_orgcd,@srspn_deptcd,@srspn_date,@srspn_pwd)",myConn);
		
				cmd.SelectCommand.Parameters.Add("@srspn_empno",SqlDbType.Char,6).Value=srspn_empno.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@srspn_cname",SqlDbType.Char,10).Value=srspn_cname.Text;
				cmd.SelectCommand.Parameters.Add("@srspn_tel",SqlDbType.Char,12).Value=srspn_tel.Text;
				cmd.SelectCommand.Parameters.Add("@srspn_atype",SqlDbType.Char,1).Value=ddlsrspn_atype.SelectedItem.Value.Trim();
				cmd.SelectCommand.Parameters.Add("@srspn_orgcd",SqlDbType.Char,2).Value=ddlsrspn_orgcd.SelectedItem.Value.Trim();
				cmd.SelectCommand.Parameters.Add("@srspn_deptcd",SqlDbType.VarChar,5).Value=srspn_deptcd.Text;
				cmd.SelectCommand.Parameters.Add("@srspn_date",SqlDbType.Char,8).Value=srspn_date.Text;
				cmd.SelectCommand.Parameters.Add("@srspn_pwd",SqlDbType.Char,14).Value=srspn_pwd.Text;
			
				DataSet ds = new DataSet();
				cmd.Fill(ds,"srspn");
			
				Response.Redirect("srspn.aspx?ID=addnew_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("srspn.aspx");
		}
	}
}
