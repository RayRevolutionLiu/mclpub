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
using System.Configuration;

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for SearchCust1.
	/// </summary>
	public class SearchCust1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxMfrno;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Web.UI.WebControls.TextBox tbxCompanyname;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.LinkButton lnbNewMfr;
		protected System.Web.UI.WebControls.LinkButton lnbNewCust;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Label lblMessage1;
		protected System.Web.UI.WebControls.Label lblTitle1;
		protected System.Web.UI.WebControls.Label lblTitle2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		public SearchCust1()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			if (!IsPostBack)
			{
				string type1=Context.Request.QueryString["type1"];
				string status=Context.Request.QueryString["function1"];
				if(type1=="01")
					lblTitle1.Text="訂閱訂單";
				else if(type1=="02")
					lblTitle1.Text="贈閱訂單";
				else if(type1=="03")
					lblTitle1.Text="推廣訂單";
				else if(type1=="09")
					lblTitle1.Text="零售訂單";

				if(status=="new")
					lblTitle2.Text="新增訂單";
				else if(status=="mod")
					lblTitle2.Text="註銷/修改訂單";
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
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT mfr_mfrid, mfr_mfrno, mfr_inm, mfr_iaddr, mfr_izip, mfr_respnm, mfr_respjb" +
				"ti, mfr_tel, mfr_fax, mfr_regdate FROM dbo.mfr";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c1_cust.cust_custid, dbo.c1_cust.cust_btpcd, dbo.c1_cust.cust_custno, dbo.c1_cust.cust_nm, dbo.c1_cust.cust_jbti, dbo.c1_cust.cust_mfrno, dbo.c1_cust.cust_tel, dbo.c1_cust.cust_fax, dbo.c1_cust.cust_cell, dbo.c1_cust.cust_email, dbo.c1_cust.cust_regdate, dbo.c1_cust.cust_moddate, dbo.c1_cust.cust_fgoi, dbo.c1_cust.cust_fgoe, dbo.c1_cust.cust_otp1seq1, dbo.c1_cust.cust_otp1seq2, dbo.c1_cust.cust_otp1seq3, dbo.c1_cust.cust_otp1seq9, dbo.c1_cust.cust_itpcd, dbo.mfr.mfr_inm AS mfrnm, dbo.mfr.mfr_mfrid, dbo.mfr.mfr_mfrno, dbo.c1_cust.cust_oldcustno1, dbo.c1_cust.cust_oldcustno2 FROM dbo.c1_cust INNER JOIN dbo.mfr ON dbo.c1_cust.cust_mfrno = dbo.mfr.mfr_mfrno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "dbo.sp_tmp_002";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mfr", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_tel", "mfr_tel"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_fax", "mfr_fax"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_regdate", "mfr_regdate")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_cust", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																				 new System.Data.Common.DataColumnMapping("cust_btpcd", "cust_btpcd"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("cust_mfrno", "cust_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("cust_fax", "cust_fax"),
																																																				 new System.Data.Common.DataColumnMapping("cust_cell", "cust_cell"),
																																																				 new System.Data.Common.DataColumnMapping("cust_email", "cust_email"),
																																																				 new System.Data.Common.DataColumnMapping("cust_regdate", "cust_regdate"),
																																																				 new System.Data.Common.DataColumnMapping("cust_moddate", "cust_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("cust_fgoi", "cust_fgoi"),
																																																				 new System.Data.Common.DataColumnMapping("cust_fgoe", "cust_fgoe"),
																																																				 new System.Data.Common.DataColumnMapping("cust_otp1seq1", "cust_otp1seq1"),
																																																				 new System.Data.Common.DataColumnMapping("cust_otp1seq2", "cust_otp1seq2"),
																																																				 new System.Data.Common.DataColumnMapping("cust_otp1seq3", "cust_otp1seq3"),
																																																				 new System.Data.Common.DataColumnMapping("cust_otp1seq9", "cust_otp1seq9"),
																																																				 new System.Data.Common.DataColumnMapping("cust_itpcd", "cust_itpcd"),
																																																				 new System.Data.Common.DataColumnMapping("mfrnm", "mfrnm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_oldcustno1", "cust_oldcustno1"),
																																																				 new System.Data.Common.DataColumnMapping("cust_oldcustno2", "cust_oldcustno2")})});
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.lnbNewMfr.Click += new System.EventHandler(this.lnbNewMfr_Click);
			this.lnbNewCust.Click += new System.EventHandler(this.lnbNewCust_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			DataGrid1.CurrentPageIndex=0;
			ShowCust();
		}


		private void ShowCust()
		{
			lblMessage1.Text="";
			lblMessage.Text="";
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "c1_cust");
			DataView dv = ds.Tables["c1_cust"].DefaultView;
			string rowfilterstr = "1=1";
			if(tbxMfrno.Text!="")
			{
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "mfr");
				DataView dv2 = ds2.Tables["mfr"].DefaultView;
				dv2.RowFilter="mfr_mfrno='"+tbxMfrno.Text.Trim()+"'";
				if(dv2.Count==0)
					lblMessage1.Text="無此廠商資料,請先新增廠商資料";
				else
				{
					tbxCompanyname.Text=dv2[0].Row["mfr_inm"].ToString();
					rowfilterstr=rowfilterstr+" and cust_mfrno Like '%"+tbxMfrno.Text.Trim()+"%'";
					if(tbxCustName.Text!="")
						rowfilterstr=rowfilterstr+" and cust_nm Like '%"+tbxCustName.Text.Trim()+"%'";
					if(tbxCompanyname.Text!="")
						rowfilterstr=rowfilterstr+" and mfrnm Like '%"+tbxCompanyname.Text.Trim()+"%'";
					if(tbxCustNo.Text!="")
						rowfilterstr=rowfilterstr+" and cust_custno ='"+tbxCustNo.Text.Trim()+"'";
					dv.RowFilter = rowfilterstr;
					if (dv.Count==0)
						lblMessage.Text="找不到符合條件的訂戶資料, 您可以1.重設條件2.新增訂戶資料";
					else
						lblMessage.Text="找到"+dv.Count.ToString()+"筆訂戶資料";
					DataGrid1.DataSource=dv;
					DataGrid1.DataBind();
				}
			}
			else
			{
				if(tbxCustName.Text!="")
					rowfilterstr=rowfilterstr+" and cust_nm Like '%"+tbxCustName.Text.Trim()+"%'";
				if(tbxCompanyname.Text!="")
					rowfilterstr=rowfilterstr+" and mfrnm Like '%"+tbxCompanyname.Text.Trim()+"%'";
				if(tbxCustNo.Text!="")
					rowfilterstr=rowfilterstr+" and cust_custno ='"+tbxCustNo.Text.Trim()+"'";
				dv.RowFilter = rowfilterstr;
				if (dv.Count==0)
					lblMessage.Text="找不到符合條件的訂戶資料, 您可以1.重設條件2.新增廠商或訂戶資料";
				else
					lblMessage.Text="找到"+dv.Count.ToString()+"筆訂戶資料";
				DataGrid1.DataSource=dv;
				DataGrid1.DataBind();
			}
		}


		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
//			Response.Write(DataGrid1.SelectedItem.Cells[2].Text);
			if(e.CommandName=="Modify")
			{
				Response.Redirect("ModifyCust.aspx?id="+DataGrid1.SelectedItem.Cells[2].Text);
			}
			else if(e.CommandName=="OK")
			{
				DataSet ds = new DataSet();
				this.sqlDataAdapter1.Fill(ds, "c1_cust");
				DataView dv = ds.Tables["c1_cust"].DefaultView;
				dv.RowFilter="cust_custno='"+DataGrid1.SelectedItem.Cells[2].Text+"'";

				this.sqlCommand1.Parameters["@syscd"].Value="C1";
				this.sqlCommand1.Parameters["@custno"].Value=DataGrid1.SelectedItem.Cells[2].Text;
				this.sqlCommand1.Connection.Open();
				SqlDataReader myReader=this.sqlCommand1.ExecuteReader();
				myReader.Read();
				myReader.Close();
				this.sqlCommand1.Connection.Close();
//				Response.Write(dv[0].Row["cust_otp1seq1"]);
				string	type1=Context.Request.QueryString["type1"];
				string	function1=Context.Request.QueryString["function1"];
				Response.Redirect("CustDetail.aspx?id="+DataGrid1.SelectedItem.Cells[2].Text.Trim()+"&type1="+type1+"&function1="+function1);

/*				if(Context.Request.QueryString["type1"]=="01")
					Response.Redirect("CustDetail.aspx?id="+DataGrid1.SelectedItem.Cells[2].Text.Trim()+"&type1=01");
//				Response.Redirect("OrderForm.aspx?id="+DataGrid1.SelectedItem.Cells[2].Text.Trim()+"&seq1="+dv[0].Row["cust_otp1seq1"].ToString().Trim()+"&type1="+Context.Request.QueryString["type1"]);
				else if(Context.Request.QueryString["type1"]=="02")
					Response.Redirect("CustDetail.aspx?id="+DataGrid1.SelectedItem.Cells[2].Text.Trim()+"&type1=02");
				else if(Context.Request.QueryString["type1"]=="03")
					Response.Redirect("CustDetail.aspx?id="+DataGrid1.SelectedItem.Cells[2].Text.Trim()+"&type1=03");
				else if(Context.Request.QueryString["type1"]=="09")
					Response.Redirect("CustDetail.aspx?id="+DataGrid1.SelectedItem.Cells[2].Text.Trim()+"&type1=09");
*/			}
		}

		private void lnbNewMfr_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../d5/mfr.aspx");
		}

		private void lnbNewCust_Click(object sender, System.EventArgs e)
		{
			string	str1="coname=";
			string	str2="mfrno=";
			if(tbxCompanyname.Text!="")
				str1+=tbxCompanyname.Text.Trim();
			if(tbxMfrno.Text!="")
				str2+=tbxMfrno.Text.Trim();
//			Response.Redirect("NewCust.aspx?"+str1+"&"+str2);
			Response.Redirect("NewCust.aspx?"+str2);
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			ShowCust();

		}
	}
}
