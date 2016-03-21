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
	public class srspn_edit : System.Web.UI.Page
	{
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
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.DropDownList ddlbkp_bkcd;
		protected System.Web.UI.WebControls.TextBox srspn_empno;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox srspn_cname;
		protected System.Web.UI.WebControls.TextBox srspn_tel;
		protected System.Web.UI.WebControls.DropDownList ddlsrspn_atype;
		protected System.Web.UI.WebControls.DropDownList ddlsrspn_orgcd;
		protected System.Web.UI.WebControls.TextBox srspn_deptcd;
		protected System.Web.UI.WebControls.TextBox srspn_date;
		protected System.Web.UI.WebControls.RegularExpressionValidator Regularexpressionvalidator2;
		protected System.Web.UI.WebControls.TextBox srspn_pwd;
		private static string global_empno;
		
		public srspn_edit()
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
			SqlDataAdapter cmd=new SqlDataAdapter("select * from itriorg",myConn);

			DataSet ds = new DataSet();
			cmd.Fill(ds, "Table");
			DataView dv = ds.Tables["Table"].DefaultView;

			this.ddlsrspn_orgcd.DataTextField = "io_orgcname";
			this.ddlsrspn_orgcd.DataValueField = "io_orgcd";
			this.ddlsrspn_orgcd.DataSource = dv;
			this.ddlsrspn_orgcd.DataBind();

			SqlDataAdapter cmd2=new SqlDataAdapter("select * from srspn where srspn_id='" + id + "'",myConn);
					
			DataSet ds2 = new DataSet();
			cmd2.Fill(ds2, "srspn");
			DataView dv2 = ds2.Tables["srspn"].DefaultView;
			
			if (dv2.Count <= 0)
			{
				Response.Redirect("nodata.aspx");
			}
						
			string strempno = dv2[0]["srspn_empno"].ToString();
			string strcname = dv2[0]["srspn_cname"].ToString();
			string strtel = dv2[0]["srspn_tel"].ToString();
			string stratype = dv2[0]["srspn_atype"].ToString();
			string strorgcd = dv2[0]["srspn_orgcd"].ToString();
			string strdeptcd = dv2[0]["srspn_deptcd"].ToString();
			string strdate = dv2[0]["srspn_date"].ToString();
			string pwd = dv2[0]["srspn_pwd"].ToString();
						
			srspn_empno.Text=strempno.Trim();
			srspn_cname.Text=strcname.Trim();
			srspn_tel.Text=strtel.Trim();

			for(int i=0;i<ddlsrspn_atype.Items.Count;i++)
			{
				if (ddlsrspn_atype.Items[i].Value == stratype.Trim())
				{
					ddlsrspn_atype.SelectedIndex = i;
				}
			}
			
			for(int i=0;i<ddlsrspn_orgcd.Items.Count;i++)
			{
				if (ddlsrspn_orgcd.Items[i].Value == strorgcd.Trim())
				{
					ddlsrspn_orgcd.SelectedIndex = i;
				}
			}
			
			srspn_deptcd.Text=strdeptcd.Trim();
			srspn_date.Text=strdate.Trim();
			srspn_pwd.Text=pwd.Trim();
			
			global_empno = strempno.Trim();
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
			string SQL = "select * from srspn";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			dv.RowFilter = "srspn_empno = '" + srspn_empno.Text.Trim() +"'";

			if (dv.Count > 0 && srspn_empno.Text != global_empno)
			{
				Label1.Text="此筆資料已經存在!";
			}

			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter
					("update srspn set srspn_empno=@srspn_empno,srspn_cname=@srspn_cname,srspn_tel=@srspn_tel,srspn_atype=@srspn_atype,srspn_orgcd=@srspn_orgcd,srspn_deptcd=@srspn_deptcd,srspn_date=@srspn_date,srspn_pwd=@srspn_pwd where srspn_id=@srspn_id",myConn);
		
				cmd.SelectCommand.Parameters.Add("@srspn_id",SqlDbType.Int,4).Value=id;
				cmd.SelectCommand.Parameters.Add("@srspn_empno",SqlDbType.Char,6).Value=srspn_empno.Text.Trim();
				cmd.SelectCommand.Parameters.Add("@srspn_cname",SqlDbType.Char,10).Value=srspn_cname.Text;
				cmd.SelectCommand.Parameters.Add("@srspn_tel",SqlDbType.Char,12).Value=srspn_tel.Text;
				cmd.SelectCommand.Parameters.Add("@srspn_atype",SqlDbType.Char,1).Value=ddlsrspn_atype.SelectedItem.Value.Trim();
				cmd.SelectCommand.Parameters.Add("@srspn_orgcd",SqlDbType.Char,2).Value=ddlsrspn_orgcd.SelectedItem.Value.Trim();
				cmd.SelectCommand.Parameters.Add("@srspn_deptcd",SqlDbType.VarChar,5).Value=srspn_deptcd.Text;
				cmd.SelectCommand.Parameters.Add("@srspn_date",SqlDbType.Char,8).Value=srspn_date.Text;
				cmd.SelectCommand.Parameters.Add("@srspn_pwd",SqlDbType.Char,14).Value=srspn_pwd.Text;

				DataSet ds1 = new DataSet();
				cmd.Fill(ds1,"Title");

				Response.Redirect("srspn.aspx?ID=edit_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("srspn.aspx");
		}
	}
}
