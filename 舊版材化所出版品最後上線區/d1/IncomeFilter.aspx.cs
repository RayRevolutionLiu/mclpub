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
	/// Summary description for IncomeFilter.
	/// </summary>
	public class IncomeFilter : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox tbxOrderDate2;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.DropDownList ddlBookType;
		protected System.Web.UI.WebControls.CheckBox cbx2;
		protected System.Web.UI.WebControls.TextBox tbxProj;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.DropDownList ddlOrderType1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Label lblMessage1;
		protected System.Web.UI.WebControls.TextBox tbxOrderDate1;
	
		public IncomeFilter()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			if (!IsPostBack)
			{
				//書籍類別
				DataSet	ds2=new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "c1_obtp");
				DataView dv2 = ds2.Tables["c1_obtp"].DefaultView;
				dv2.RowFilter="obtp_otp1cd='"+ddlOrderType1.SelectedItem.Value+"'";
				ddlBookType.DataSource=dv2;
				ddlBookType.DataTextField="obtp_obtpnm";
				ddlBookType.DataValueField="obtp_obtpcd";
				ddlBookType.DataBind();
				tbxOrderDate1.Text=System.DateTime.Today.ToString("yyyy/MM/dd");
				tbxOrderDate2.Text=System.DateTime.Today.ToString("yyyy/MM/dd");
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
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.ddlOrderType1.SelectedIndexChanged += new System.EventHandler(this.ddlOrderType1_SelectedIndexChanged);
			this.cbx1.CheckedChanged += new System.EventHandler(this.cbx1_CheckedChanged);
			this.cbx2.CheckedChanged += new System.EventHandler(this.cbx2_CheckedChanged);
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT obtp_obtpid, obtp_otp1cd, obtp_obtpcd, obtp_obtpnm FROM dbo.c1_obtp";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.tmp_statistics.tmp_otp1cd, dbo.tmp_statistics.tmp_otp2cd, dbo.tmp_statistics.tmp_btpcd, dbo.tmp_statistics.tmp_param1, dbo.tmp_statistics.tmp_param2, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2nm, dbo.c1_obtp.obtp_obtpnm, dbo.c1_obtp.obtp_obtpcd, dbo.c1_obtp.obtp_otp1cd, dbo.c1_otp.otp_otp1cd, dbo.c1_otp.otp_otp2cd FROM dbo.tmp_statistics INNER JOIN dbo.c1_otp ON dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp1cd AND dbo.tmp_statistics.tmp_otp2cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_otp.otp_otp2cd INNER JOIN dbo.c1_obtp ON dbo.tmp_statistics.tmp_otp1cd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_obtp.obtp_otp1cd AND dbo.tmp_statistics.tmp_btpcd COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c1_obtp.obtp_obtpcd";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "dbo.sp_c1_tmp_income1";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date1", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date2", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@projno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, s" +
				"rspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_obtp", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpid", "obtp_obtpid"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_otp1cd", "obtp_otp1cd"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpcd", "obtp_obtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpnm", "obtp_obtpnm")})});
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
																																																						new System.Data.Common.DataColumnMapping("obtp_obtpnm", "obtp_obtpnm")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ddlOrderType1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			//書籍類別
			DataSet	ds2=new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c1_obtp");
			DataView dv2 = ds2.Tables["c1_obtp"].DefaultView;
			dv2.RowFilter="obtp_otp1cd='"+ddlOrderType1.SelectedItem.Value+"'";
			ddlBookType.DataSource=dv2;
			ddlBookType.DataTextField="obtp_obtpnm";
			ddlBookType.DataValueField="obtp_obtpcd";
			ddlBookType.DataBind();
		}

		private void cbx1_CheckedChanged(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			if(cbx1.Checked==true)
				cbx2.Enabled=false;
			else
				cbx2.Enabled=true;
		}

		private void cbx2_CheckedChanged(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			if(cbx2.Checked==true)
				cbx1.Enabled=false;
			else
				cbx1.Enabled=true;

		}

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			lblMessage.Text="";
			lblMessage1.Text="";
			DataGrid1.Visible=false;
			if((tbxOrderDate1.Text.Trim()=="") ||(tbxOrderDate2.Text.Trim()==""))
				lblMessage.Text="日期區間不可為空白!!";
			else
			{
				string	date1=tbxOrderDate1.Text.Trim();
				string	date2=tbxOrderDate2.Text.Trim();
				if((date1.Length<10)||(date2.Length<10))
				{
					lblMessage.Text="請注意!日期輸入格式為yyyy/mm/dd";
					return;
				}
				if(cbx2.Checked)
				{
					if(tbxProj.Text.Trim().Length<10)
					{
						lblMessage1.Text="請注意!!計劃代號為10碼";
						return;
					}
					this.sqlCommand1.Parameters["@projno"].Value=tbxProj.Text.Trim();
				}
				else
					this.sqlCommand1.Parameters["@projno"].Value="";
				this.sqlCommand1.Parameters["@date1"].Value=date1.Substring(0,4)+date1.Substring(5,2)+date1.Substring(8,2);
				this.sqlCommand1.Parameters["@date2"].Value=date2.Substring(0,4)+date2.Substring(5,2)+date2.Substring(8,2);
				this.sqlCommand1.Parameters["@otp1cd"].Value=ddlOrderType1.SelectedItem.Value.Trim();
				//				if(cbx1.Checked)
				//					this.sqlCommand1.Parameters["@btpcd"].Value=ddlBookType.SelectedItem.Value.Trim();
				//				else
				//					this.sqlCommand1.Parameters["@btpcd"].Value="";
				this.sqlCommand1.Connection.Open();
				SqlDataReader myReader=this.sqlCommand1.ExecuteReader();
				myReader.Read();
				myReader.Close();
				this.sqlCommand1.Connection.Close();
				DataSet	ds1=new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "tmp_statistics");
				DataView dv1 = ds1.Tables["tmp_statistics"].DefaultView;
				//				dv1.RowFilter="tmp_otp1cd='"+ddlOrderType1.SelectedItem.Value+"'";
				DataGrid1.Visible=true;
				DataGrid1.DataSource=dv1;
				DataGrid1.DataBind();
				btnPrintList.Enabled=true;
			}
		}

		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			string reg=User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
			DataSet	ds3=new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "srspn");
			DataView dv3 = ds3.Tables["srspn"].DefaultView;
			dv3.RowFilter="srspn_empno = '"+reg+"'";
			if(dv3.Count>0)
			{
				string	cname=dv3[0].Row["srspn_cname"].ToString().Trim();
				string	strbuf="income1.aspx?cname="+cname;
				if(cbx1.Checked)
					strbuf+="&btpcd="+ddlBookType.SelectedItem.Value.Trim();
				else
					strbuf+="&btpcd=";
				strbuf+="&date="+tbxOrderDate1.Text+"~"+tbxOrderDate2.Text;
				Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
			}
		}
	}
}
