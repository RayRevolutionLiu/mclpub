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

namespace MRLPub.d4
{
	/// <summary>
	/// Summary description for QueryCont.
	/// </summary>
	public class QueryCont : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.LinkButton lnbNewCust;
		protected System.Web.UI.WebControls.LinkButton lnbNewMfr;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.Label lblExplain;
		protected System.Web.UI.WebControls.TextBox tbxCompanyName;
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPub;
		protected System.Web.UI.WebControls.Label lblContTypeCode;
	
		public QueryCont()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
  
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCnnMRLPub = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.lnbNewMfr.Click += new System.EventHandler(this.lnbNewMfr_Click);
			this.lnbNewCust.Click += new System.EventHandler(this.lnbNewCust_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT mfr.mfr_mfrid, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_iaddr, mfr.mfr_izip, mfr.mfr_respnm, mfr.mfr_respjbti, mfr.mfr_tel, mfr.mfr_fax, mfr.mfr_regdate, cust.cust_custid, cust.cust_custno, cust.cust_nm, cust.cust_jbti, cust.cust_mfrno, cust.cust_tel, cust.cust_fax, cust.cust_cell, cust.cust_email, cust.cust_regdate, cust.cust_moddate, cust.cust_itpcd, cust.cust_btpcd, cust.cust_rtpcd, cust.cust_oldcustno FROM cust INNER JOIN mfr ON cust.cust_mfrno = mfr.mfr_mfrno";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPub;
			// 
			// sqlCnnMRLPub
			// 
			this.sqlCnnMRLPub.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "cust", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_tel", "mfr_tel"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_fax", "mfr_fax"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_regdate", "mfr_regdate"),
																																																			  new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
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
																																																			  new System.Data.Common.DataColumnMapping("cust_itpcd", "cust_itpcd"),
																																																			  new System.Data.Common.DataColumnMapping("cust_btpcd", "cust_btpcd"),
																																																			  new System.Data.Common.DataColumnMapping("cust_rtpcd", "cust_rtpcd"),
																																																			  new System.Data.Common.DataColumnMapping("cust_oldcustno", "cust_oldcustno")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			string strFilter = "1=1";

			if (this.tbxCompanyName.Text.Trim() != "")
				strFilter += " AND mfr_inm LIKE '%" + this.tbxCompanyName.Text.Trim() + "%'";

			if (this.tbxMfrNo.Text.Trim() != "")
				strFilter += " AND mfr_mfrno LIKE '%" + this.tbxMfrNo.Text.Trim() + "%'";

			if (this.tbxCustName.Text.Trim() != "")
				strFilter += " AND cust_nm LIKE '%" + this.tbxCustName.Text.Trim() + "%'";

			if (this.tbxCustNo.Text.Trim() != "")
				strFilter += " AND cust_custno LIKE '%" + this.tbxCustNo.Text.Trim() + "%'";

			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "mfrcust");
			DataView dv = ds.Tables["mfrcust"].DefaultView;

			dv.RowFilter = strFilter;

			if (dv.Count > 0)
			{
				DataGrid1.SelectedIndex = -1;
				DataGrid1.CurrentPageIndex = 0;
				DataGrid1.DataSource = dv;
				DataGrid1.DataBind();
				DataGrid1.Visible = true;
			}
			else
			{
				DataGrid1.Visible = false;
			}

		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			DataSet ds = new DataSet();
//			this.sqlDataAdapter1.Fill(ds, "cust");
//			DataView dv = ds.Tables["cust"].DefaultView;
//
//			dv.RowFilter = "cust_custno='" + DataGrid1.SelectedItem.Cells[4].Text + "'";

			string CustNo = DataGrid1.SelectedItem.Cells[4].Text.Trim();

			Response.Redirect("QueryHisCont.aspx?conttp=01&custno=" + CustNo);
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;

			string strFilter = "1=1";

			if (this.tbxCompanyName.Text.Trim() != "")
				strFilter += " AND mfr_inm LIKE '%" + this.tbxCompanyName.Text.Trim() + "%'";

			if (this.tbxMfrNo.Text.Trim() != "")
				strFilter += " AND mfr_mfrno LIKE '%" + this.tbxMfrNo.Text.Trim() + "%'";

			if (this.tbxCustName.Text.Trim() != "")
				strFilter += " AND cust_nm LIKE '%" + this.tbxCustName.Text.Trim() + "%'";

			if (this.tbxCustNo.Text.Trim() != "")
				strFilter += " AND cust_custno LIKE '%" + this.tbxCustNo.Text.Trim() + "%'";

			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "mfrcust");
			DataView dv = ds.Tables["mfrcust"].DefaultView;

			dv.RowFilter = strFilter;

			if (dv.Count > 0)
			{
				DataGrid1.DataSource = dv;
				DataGrid1.DataBind();
				DataGrid1.Visible = true;
			}
			else
			{
				DataGrid1.Visible = false;
			}
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
			//Response.Write(DataGrid1.SelectedItem.Cells[4].Text);

			if(e.CommandName=="Modify")
			{
				// 修改客戶資料的處理: 先轉址
				//Response.Write("ID= " + DataGrid1.SelectedItem.Cells[1].Text);
				Response.Redirect("../d5/cust_edit.aspx?ID=" + DataGrid1.SelectedItem.Cells[1].Text);
				return;
			}

//			if(e.CommandName=="OK")
//			{
//				// 使用 DataSet 方法, 並指定使用的 table 名稱
//				DataSet ds = new DataSet();
//				this.sqlDataAdapter1.Fill(ds, "cust");
//				DataView dv = ds.Tables["cust"].DefaultView;
//
//				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
//				// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
//				dv.RowFilter = "cust_custno='" + DataGrid1.SelectedItem.Cells[4].Text + "'";
//
//				// 檢查並輸出 最後 Row Filter 的結果
//				//Response.Write("dv.Count= "+ dv.Count + "<BR>");
//				//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");
//
//				//防呆處理: 若無資料時, 則給錯誤訊息
//				//if (dv1.Count < 1)  ...
//				// 若找到資料, 則在 Server Web Control 顯示之
//
//
//				//// 按下確定(挑人)的處理: 先轉址
//				if(Request.QueryString["conttp"]=="01")
//					Response.Redirect("QueryHisCont.aspx?function1=new&custno="+DataGrid1.SelectedItem.Cells[4].Text.Trim() + "&conttp=01");
//				else if(Request.QueryString["conttp"]=="09")
//					Response.Redirect("QueryHisCont?function1=new&custno="+DataGrid1.SelectedItem.Cells[4].Text.Trim() + "&conttp=09");
//
//				return;
//			}

			//照理說這邊還要做一些預防處理
		}

		private void lnbNewMfr_Click(object sender, System.EventArgs e)
		{
			// 轉址處理
			Response.Redirect("../d5/mfr_addnew.aspx");
		}

		private void lnbNewCust_Click(object sender, System.EventArgs e)
		{
			// 轉址處理
			Response.Redirect("../d5/cust_add.aspx");
		}
	}
}
