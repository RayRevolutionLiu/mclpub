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
	public class refm_edit : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.DropDownList ddlrm_syscd;
		protected System.Web.UI.WebControls.TextBox rm_remark;
		protected System.Web.UI.WebControls.TextBox rm_deptcd;
		protected System.Web.UI.WebControls.TextBox rm_accddr;
		protected System.Web.UI.WebControls.TextBox rm_idescr;
		protected System.Web.UI.WebControls.TextBox rm_iunit;
		protected System.Web.UI.WebControls.TextBox rm_iremark;
		private static string global_syscd;
		
		public refm_edit()
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

			SqlDataAdapter cmd2=new SqlDataAdapter("select * from refm where rm_rmid='" + id + "'",myConn);
					
			DataSet ds2 = new DataSet();
			cmd2.Fill(ds2, "refm");
			DataView dv2 = ds2.Tables["refm"].DefaultView;
			
			if (dv2.Count <= 0)
			{
				Response.Redirect("nodata.aspx");
			}
						
			string strsyscd = dv2[0]["rm_syscd"].ToString();
			string strremark = dv2[0]["rm_remark"].ToString();
			string strdeptcd = dv2[0]["rm_deptcd"].ToString();
			string straccddr = dv2[0]["rm_accddr"].ToString();
			string stridescr = dv2[0]["rm_idescr"].ToString();
			string striunit = dv2[0]["rm_iunit"].ToString();
			string striremark = dv2[0]["rm_iremark"].ToString();
						
			for(int i=0;i<ddlrm_syscd.Items.Count;i++)
			{
				if (ddlrm_syscd.Items[i].Value == strsyscd.Trim())
				{
					ddlrm_syscd.SelectedIndex = i;
				}
			}
			rm_remark.Text=strremark.Trim();
			rm_deptcd.Text=strdeptcd.Trim();
			rm_accddr.Text=straccddr.Trim();
			rm_idescr.Text=stridescr.Trim();
			rm_iunit.Text=striunit.Trim();
			rm_iremark.Text=striremark.Trim();
			
			global_syscd = strsyscd.Trim();
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
			string SQL = "select * from refm";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;
			dv.RowFilter = "rm_syscd = '" + ddlrm_syscd.SelectedItem.Value +"'";

			if (dv.Count > 0 && ddlrm_syscd.SelectedItem.Value != global_syscd)
			{
				Label1.Text="此筆資料已經存在!";
			}

			else
			{
				SqlDataAdapter cmd=new SqlDataAdapter
					("update refm set rm_syscd=@rm_syscd,rm_remark=@rm_remark,rm_deptcd=@rm_deptcd,rm_accddr=@rm_accddr,rm_idescr=@rm_idescr,rm_iunit=@rm_iunit,rm_iremark=@rm_iremark where rm_rmid=@rm_rmid",myConn);
		
				cmd.SelectCommand.Parameters.Add("@rm_rmid",SqlDbType.Char,4).Value=id;
				cmd.SelectCommand.Parameters.Add("@rm_syscd",SqlDbType.Char,2).Value=ddlrm_syscd.SelectedItem.Value.Trim();
				cmd.SelectCommand.Parameters.Add("@rm_remark",SqlDbType.Char,25).Value=rm_remark.Text;
				cmd.SelectCommand.Parameters.Add("@rm_deptcd",SqlDbType.Char,5).Value=rm_deptcd.Text;
				cmd.SelectCommand.Parameters.Add("@rm_accddr",SqlDbType.Char,7).Value=rm_accddr.Text;
				cmd.SelectCommand.Parameters.Add("@rm_idescr",SqlDbType.VarChar,40).Value=rm_idescr.Text;
				cmd.SelectCommand.Parameters.Add("@rm_iunit",SqlDbType.Char,3).Value=rm_iunit.Text;
				cmd.SelectCommand.Parameters.Add("@rm_iremark",SqlDbType.VarChar,20).Value=rm_iremark.Text;
			
				DataSet ds1 = new DataSet();
				cmd.Fill(ds1,"Title");

				Response.Redirect("refm.aspx?ID=edit_ok");
			}
		}

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("refm.aspx");
		}
	}
}
