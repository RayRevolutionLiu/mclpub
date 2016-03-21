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
	public class refm_addnew : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.DropDownList ddlrm_syscd;
		protected System.Web.UI.WebControls.TextBox rm_remark;
		protected System.Web.UI.WebControls.TextBox rm_deptcd;
		protected System.Web.UI.WebControls.TextBox rm_accddr;
		protected System.Web.UI.WebControls.TextBox rm_idescr;
		protected System.Web.UI.WebControls.TextBox rm_iunit;
		protected System.Web.UI.WebControls.TextBox rm_iremark;
		protected System.Web.UI.WebControls.Button btnAddNew;
	
		public refm_addnew()
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
			SqlDataAdapter cmd=new SqlDataAdapter("select * from syscd",myConn);

			DataSet ds = new DataSet();
			cmd.Fill(ds, "Table");
			DataView dv = ds.Tables["Table"].DefaultView;

			this.ddlrm_syscd.DataTextField = "sys_nm";
			this.ddlrm_syscd.DataValueField = "sys_syscd";
			this.ddlrm_syscd.DataSource = dv;
			this.ddlrm_syscd.DataBind();
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
			string SQL = "select * from refm";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds1 = new DataSet();
			myCommand.Fill(ds1,"refm");

			DataView dv = ds1.Tables["refm"].DefaultView;
			dv.RowFilter = "rm_syscd = '" + ddlrm_syscd.SelectedItem.Value.Trim() +"'";

			if (dv.Count > 0)
			{
				Label1.Text="此筆資料已經存在!";
			}
			
			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter
					("insert into refm(rm_syscd,rm_remark,rm_deptcd,rm_accddr,rm_idescr,rm_iunit,rm_iremark) values(@rm_syscd,@rm_remark,@rm_deptcd,@rm_accddr,@rm_idescr,@rm_iunit,@rm_iremark)",myConn);
		
				cmd.SelectCommand.Parameters.Add("@rm_syscd",SqlDbType.Char,2).Value=ddlrm_syscd.SelectedItem.Value.Trim();
				cmd.SelectCommand.Parameters.Add("@rm_remark",SqlDbType.Char,25).Value=rm_remark.Text;
				cmd.SelectCommand.Parameters.Add("@rm_deptcd",SqlDbType.Char,5).Value=rm_deptcd.Text;
				cmd.SelectCommand.Parameters.Add("@rm_accddr",SqlDbType.Char,7).Value=rm_accddr.Text;
				cmd.SelectCommand.Parameters.Add("@rm_idescr",SqlDbType.VarChar,40).Value=rm_idescr.Text;
				cmd.SelectCommand.Parameters.Add("@rm_iunit",SqlDbType.Char,3).Value=rm_iunit.Text;
				cmd.SelectCommand.Parameters.Add("@rm_iremark",SqlDbType.VarChar,20).Value=rm_iremark.Text;
			
				DataSet ds = new DataSet();
				cmd.Fill(ds,"refm");
			
				Response.Redirect("refm.aspx?ID=addnew_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("refm.aspx");
		}
	}
}
