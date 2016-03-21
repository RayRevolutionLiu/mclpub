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
	public class refd2_addnew : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.DropDownList ddlrd_syscd;
		protected System.Web.UI.WebControls.DropDownList ddlrd_projno;
		protected System.Web.UI.WebControls.TextBox rd_costctr;
		protected System.Web.UI.WebControls.TextBox rd_accdcr;
		protected System.Web.UI.WebControls.TextBox rd_descr;
		protected System.Web.UI.WebControls.Button btnAddNew;
	
		public refd2_addnew()
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
			cmd.Fill(ds, "Table");
			DataView dv = ds.Tables["Table"].DefaultView;

			this.ddlrd_syscd.DataTextField = "sys_nm";
			this.ddlrd_syscd.DataValueField = "sys_syscd";
			this.ddlrd_syscd.DataSource = dv;
			this.ddlrd_syscd.DataBind();

			SqlDataAdapter cmd1=new SqlDataAdapter("select * from proj",myConn);

			DataSet ds1 = new DataSet();
			cmd1.Fill(ds1, "Table");
			DataView dv1 = ds1.Tables["Table"].DefaultView;

			this.ddlrd_projno.DataTextField = "proj_projno";
			this.ddlrd_projno.DataValueField = "proj_projno";
			this.ddlrd_projno.DataSource = dv1;
			this.ddlrd_projno.DataBind();
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
			string SQL = "select * from refd";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds1 = new DataSet();
			myCommand.Fill(ds1,"refm");

			DataView dv = ds1.Tables["refm"].DefaultView;
			dv.RowFilter = "rd_syscd = '" + ddlrd_syscd.SelectedItem.Value.Trim() +"' AND rd_projno = '" + ddlrd_projno.SelectedItem.Value.Trim() +"'";

			if (dv.Count > 0)
			{
				Label1.Text="此筆資料已經存在!";
			}
			
			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter
					("insert into refd(rd_syscd,rd_projno,rd_costctr,rd_accdcr,rd_descr) values(@rd_syscd,@rd_projno,@rd_costctr,@rd_accdcr,@rd_descr)",myConn);
		
				cmd.SelectCommand.Parameters.Add("@rd_syscd",SqlDbType.Char,2).Value=ddlrd_syscd.SelectedItem.Value.Trim();
				cmd.SelectCommand.Parameters.Add("@rd_projno",SqlDbType.Char,10).Value=ddlrd_projno.SelectedItem.Value.Trim();
				cmd.SelectCommand.Parameters.Add("@rd_costctr",SqlDbType.Char,7).Value=rd_costctr.Text;
				cmd.SelectCommand.Parameters.Add("@rd_accdcr",SqlDbType.Char,7).Value=rd_accdcr.Text;
				cmd.SelectCommand.Parameters.Add("@rd_descr",SqlDbType.VarChar,50).Value=rd_descr.Text;
				
				DataSet ds = new DataSet();
				cmd.Fill(ds,"refm");
			
				Response.Redirect("refd2.aspx?ID=addnew_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("refd2.aspx");
		}
	}
}
