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

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for BookMntFilter.
	/// </summary>
	public class BookMntFilter : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlYear;
		protected System.Web.UI.WebControls.DropDownList ddlMonth;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlBookType;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox tbxBookNo;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlMailType;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Literal Literal1;
	
		public BookMntFilter()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			if (!IsPostBack)
			{
				int myYear=System.DateTime.Today.Year;
				int j=0;
				for(int i=myYear-1; i<=myYear; i++)
				{
					ddlYear.Items.Add(new ListItem(i.ToString(),i.ToString()));
					j++;
				}
				ddlYear.SelectedIndex=j-1;
				int myMonth=System.DateTime.Today.Month;
				ddlMonth.SelectedIndex=myMonth-1;
			}
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, s" +
				"rspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.tmp_statistics.tmp_otp1cd, dbo.tmp_statistics.tmp_otp2cd, dbo.tmp_statistics.tmp_btpcd, dbo.tmp_statistics.tmp_param1, dbo.tmp_statistics.tmp_param2, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2nm, dbo.c1_otp.otp_otp1cd, dbo.c1_otp.otp_otp2cd, dbo.mtp.mtp_nm, dbo.mtp.mtp_mtpcd FROM dbo.tmp_statistics LEFT OUTER JOIN dbo.c1_otp ON dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp1cd AND dbo.tmp_statistics.tmp_otp2cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp2cd INNER JOIN dbo.mtp ON dbo.tmp_statistics.tmp_btpcd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.mtp.mtp_mtpcd";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("srspn_id", "srspn_id"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_orgcd", "srspn_orgcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_deptcd", "srspn_deptcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_date", "srspn_date"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_pwd", "srspn_pwd")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "tmp_statistics", new System.Data.Common.DataColumnMapping[] {
																																																						new System.Data.Common.DataColumnMapping("tmp_otp1cd", "tmp_otp1cd"),
																																																						new System.Data.Common.DataColumnMapping("tmp_otp2cd", "tmp_otp2cd"),
																																																						new System.Data.Common.DataColumnMapping("tmp_btpcd", "tmp_btpcd"),
																																																						new System.Data.Common.DataColumnMapping("tmp_param1", "tmp_param1"),
																																																						new System.Data.Common.DataColumnMapping("tmp_param2", "tmp_param2"),
																																																						new System.Data.Common.DataColumnMapping("otp_otp1nm", "otp_otp1nm"),
																																																						new System.Data.Common.DataColumnMapping("otp_otp2nm", "otp_otp2nm"),
																																																						new System.Data.Common.DataColumnMapping("otp_otp1cd", "otp_otp1cd"),
																																																						new System.Data.Common.DataColumnMapping("otp_otp2cd", "otp_otp2cd"),
																																																						new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm")})});
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "dbo.sp_c1_tmp_statistics";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@type", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@btpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			DataGrid1.Visible=false;
			this.sqlCommand1.Parameters["@type"].Value=ddlMailType.SelectedItem.Value.Trim();
			this.sqlCommand1.Parameters["@btpcd"].Value=ddlBookType.SelectedItem.Value.Trim();
			this.sqlCommand1.Parameters["@yyyymm"].Value=ddlYear.SelectedItem.Value.Trim()+ddlMonth.SelectedItem.Value.Trim();
			this.sqlCommand1.Connection.Open();
			SqlDataReader myReader=this.sqlCommand1.ExecuteReader();
			myReader.Read();
			myReader.Close();
			this.sqlCommand1.Connection.Close();
			DataSet	ds1=new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "tmp_statistics");
			DataView dv1 = ds1.Tables["tmp_statistics"].DefaultView;
			DataGrid1.Visible=true;
			DataGrid1.DataSource=dv1;
			DataGrid1.DataBind();
			btnPrintList.Enabled=true;

		}

		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			string	strbuf;
			string reg=User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
			DataSet	ds2=new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "srspn");
			DataView dv2 = ds2.Tables["srspn"].DefaultView;
			dv2.RowFilter="srspn_empno = '"+reg+"'";
			if(dv2.Count>0)
			{
				string	cname=dv2[0].Row["srspn_cname"].ToString().Trim();
				if(ddlMailType.SelectedItem.Value.Trim()=="0")
					strbuf="book_mnt1.aspx?cname="+cname;
				else
					strbuf="book_mnt2.aspx?cname="+cname;
				strbuf+="&btpcd="+ddlBookType.SelectedItem.Text.Trim();
				strbuf+="&date="+ddlYear.SelectedItem.Value.Trim()+ddlMonth.SelectedItem.Value.Trim();
				strbuf+="&bookno="+tbxBookNo.Text.Trim();
				Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
			}

		}
	}
}
