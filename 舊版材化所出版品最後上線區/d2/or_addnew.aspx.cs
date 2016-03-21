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
// WebApplication Virables - Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for or_addnew.
	/// </summary>
	public class or_addnew : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox or_syscd;
		protected System.Web.UI.WebControls.TextBox or_contno;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox or_oritem;
		protected System.Web.UI.WebControls.TextBox or_nm;
		protected System.Web.UI.WebControls.TextBox or_jbti;
		protected System.Web.UI.WebControls.TextBox or_tel;
		protected System.Web.UI.WebControls.TextBox or_fax;
		protected System.Web.UI.WebControls.TextBox or_cell;
		protected System.Web.UI.WebControls.TextBox or_email;
		protected System.Web.UI.WebControls.TextBox or_zip;
		protected System.Web.UI.WebControls.TextBox or_addr;
		protected System.Web.UI.WebControls.TextBox or_fgmoseanm;
		protected System.Web.UI.WebControls.TextBox or_pubcnt;
		protected System.Web.UI.WebControls.TextBox or_unpubcnt;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.DropDownList ddlORMailTypeCode;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden or_fgmosea;

		public or_addnew()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				//給預設值
				InitData();

				// 抓出下拉式選單 郵寄類別
				BindDDL();

				// 若郵寄類別有變更, 則變更海外郵寄註記的文字
				GetfgmosearName();

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
			// 若合約書編號有輸入時, 要抓出 "雜誌收件人序號 (db max+1)"
			// 但一開始 load 此網頁時, 合約書編號都是空的

			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			DataView dv1;
			this.sqlDataAdapter1.Fill(ds1, "c2_or");
			dv1 = ds1.Tables["c2_or"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			string CurrentContNo = "";
			if(this.or_contno.Text.ToString().Trim() != "")
				CurrentContNo = this.or_contno.Text.ToString().Trim();
			else
				CurrentContNo = CurrentContNo;
			//Response.Write("CurrentContNo= "+ CurrentContNo + "<BR>");
			//dv1.RowFilter = "or_contno='" + CurrentContNo + "'";

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			// 若找到此筆資料, 則載入資料
//			if(dv1.Count>0)
//			{
//				string syscd = dv1[0]["or_syscd"].ToString();
//				string contno = dv1[0]["or_contno"].ToString();
//				string oritem = dv1[0]["or_oritem"].ToString();
//				Response.Write("syscd= " + syscd + "<br>");
//				Response.Write("contno= " + contno + "<br>");
//				Response.Write("oritem= " + oritem + "<br>");
//
//				//
//
//			}
		}


		// 抓出下拉式選單 郵寄類別
		private void BindDDL()
		{
			// 顯示下拉式選單 郵寄類別的 DB 值
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "mtp");
			DataView dv2=ds2.Tables["mtp"].DefaultView;
			ddlORMailTypeCode.DataSource=dv2;
			ddlORMailTypeCode.DataTextField="mtp_nm";
			ddlORMailTypeCode.DataValueField="mtp_mtpcd";
			ddlORMailTypeCode.DataBind();
		}


		// 若郵寄類別有變更, 則變更海外郵寄註記的文字
		private void GetfgmosearName()
		{
			string strddlfgmosea = ddlORMailTypeCode.SelectedItem.Value.ToString().Trim();
			int intddlfgmosea = int.Parse(strddlfgmosea);
			//Response.Write("strddlfgmosea= "+ strddlfgmosea + "<BR>");
			//Response.Write("intddlfgmosea= "+ intddlfgmosea + "<BR>");

			if(intddlfgmosea> 21)
				this.or_fgmoseanm.Text = "是";
			else
				this.or_fgmoseanm.Text = "否";

		}


		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.ddlORMailTypeCode.SelectedIndexChanged += new System.EventHandler(this.ddlORMailTypeCode_SelectedIndexChanged);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			//
			// sqlDataAdapter2
			//
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mtp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mtp_mtpid", "mtp_mtpid"),
																																																			 new System.Data.Common.DataColumnMapping("mtp_mtpcd", "mtp_mtpcd"),
																																																			 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm")})});
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_or", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																			   new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																			   new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																			   new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																			   new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																			   new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																			   new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																			   new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																			   new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																			   new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																			   new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																			   new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																			   new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp")})});
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_or", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("or_orid", "or_orid"),
																																																			   new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																			   new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																			   new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																			   new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																			   new System.Data.Common.DataColumnMapping("or_jbti", "or_jbti"),
																																																			   new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																			   new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																			   new System.Data.Common.DataColumnMapping("or_tel", "or_tel"),
																																																			   new System.Data.Common.DataColumnMapping("or_fax", "or_fax"),
																																																			   new System.Data.Common.DataColumnMapping("or_cell", "or_cell"),
																																																			   new System.Data.Common.DataColumnMapping("or_email", "or_email"),
																																																			   new System.Data.Common.DataColumnMapping("or_mtpcd", "or_mtpcd"),
																																																			   new System.Data.Common.DataColumnMapping("or_pubcnt", "or_pubcnt"),
																																																			   new System.Data.Common.DataColumnMapping("or_unpubcnt", "or_unpubcnt"),
																																																			   new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT or_orid, or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, " +
				"or_zip, or_tel, or_fax, or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_" +
				"fgmosea FROM dbo.c2_or";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT mtp_mtpid, mtp_mtpcd, mtp_nm FROM dbo.mtp";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = @"SELECT dbo.c2_or.or_contno, dbo.c2_or.or_oritem, dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_mfrno, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd, dbo.c2_or.or_syscd, dbo.c2_cont.cont_empno, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgpubed, dbo.c2_cont.cont_fgtemp FROM dbo.c2_or INNER JOIN dbo.c2_cont ON dbo.c2_or.or_syscd = dbo.c2_cont.cont_syscd AND dbo.c2_or.or_contno = dbo.c2_cont.cont_contno";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void btnUpdate_Click(object sender, System.EventArgs e)
		{

			//Response.Redirect("or.aspx");
		}


		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("or.aspx");
		}


		private void ddlORMailTypeCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// 注意: 此處不要再做一次 BindDDL();
			//Response.Write("value= " + ddlORMailTypeCode.SelectedItem.Value.ToString().Trim() + "<br>");

			// 若郵寄類別有變更, 則變更海外郵寄註記的文字
			GetfgmosearName();
		}


	}
}
