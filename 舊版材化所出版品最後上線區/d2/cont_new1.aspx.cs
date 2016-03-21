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

// WebApplication Virables - Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for cont_new1.
	/// </summary>
	public class cont_new1 : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.TextBox tbxCompanyName;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.LinkButton lnbNewMfr;
		protected System.Web.UI.WebControls.LinkButton lnbNewCust;
		protected System.Web.UI.WebControls.Label lblContTypeCode;
		protected System.Web.UI.WebControls.Label lblExplain;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Literal literal1;
	
		public cont_new1()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			
			// 抓出合約類別代碼 (由連結變數), 並顯示其文字
			if(Context.Request.QueryString["conttp"]=="01")
				this.lblContTypeCode.Text = "(一般合約書)";
			else if(Context.Request.QueryString["conttp"]=="09")
				this.lblContTypeCode.Text = "(推廣合約書)";
			
			if (!IsPostBack)
			{
				Response.Expires = 0;
				
				// 清除資料
				literal1.Text="";
				
				// 但不能清除輸入查詢之關鍵字, 否則無法出現正確結果
				//tbxCompanyName.Text="";
				//tbxMfrNo.Text="";
				//tbxCustNo.Text="";
				//tbxCustName.Text="";
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.lnbNewMfr.Click += new System.EventHandler(this.lnbNewMfr_Click);
			this.lnbNewCust.Click += new System.EventHandler(this.lnbNewCust_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "application name=mrlpub;data source=isccom1;initial catalog=mrlpub;password=moc18" +
//				"47csi;persist security info=True;user id=sa;workstation id=03212-890711;packet s" +
//				"ize=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT mfr.mfr_mfrid, mfr.mfr_mfrno, mfr.mfr_inm, cust.cust_custid, cust.cust_custno, cust.cust_nm, cust.cust_jbti, cust.cust_mfrno, cust.cust_tel, cust.cust_fax, cust.cust_cell, cust.cust_regdate, cust.cust_moddate, cust.cust_itpcd, cust.cust_btpcd, cust.cust_rtpcd, cust.cust_email, cust.cust_oldcustno, cust.cust_orgisyscd,cust_srspn_empno FROM cust INNER JOIN mfr ON cust.cust_mfrno = mfr.mfr_mfrno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "cust", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			  new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																			  new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																			  new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																			  new System.Data.Common.DataColumnMapping("cust_mfrno", "cust_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																			  new System.Data.Common.DataColumnMapping("cust_fax", "cust_fax"),
																																																			  new System.Data.Common.DataColumnMapping("cust_cell", "cust_cell"),
																																																			  new System.Data.Common.DataColumnMapping("cust_regdate", "cust_regdate"),
																																																			  new System.Data.Common.DataColumnMapping("cust_moddate", "cust_moddate"),
																																																			  new System.Data.Common.DataColumnMapping("cust_itpcd", "cust_itpcd"),
																																																			  new System.Data.Common.DataColumnMapping("cust_btpcd", "cust_btpcd"),
																																																			  new System.Data.Common.DataColumnMapping("cust_rtpcd", "cust_rtpcd"),
																																																			  new System.Data.Common.DataColumnMapping("cust_email", "cust_email"),
																																																			  new System.Data.Common.DataColumnMapping("cust_oldcustno", "cust_oldcustno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_orgisyscd", "cust_orgisyscd")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		

		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			// 查詢按鈕: 呼叫 Function: ShowCust() 
			ShowCust();
		}

		private string FindMfrByEmpno(string empno){
			SqlConnection connection = new SqlConnection(configurationAppSettings["itridpa_mrlpub"]);
			connection.Open();
			string sql = "select cont_mfrno from c2_cont where cont_empno = '" + empno + "' group by cont_mfrno";
			SqlCommand com = new SqlCommand(sql,connection);
			SqlDataReader dr = com.ExecuteReader();
			string mfrnos = "";
			while(dr.Read())
				mfrnos += "'" + dr[0] + "',";

			dr.Close();
			connection.Close();
			if(mfrnos.Length > 0)
				return mfrnos.Substring(0,mfrnos.Length-1);
			else
				return "''";
		}
		
		
		/// <summary>
		/// 顯示客戶資料
		/// </summary>
		private void ShowCust()
		{
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds = new DataSet();
			
			this.sqlDataAdapter1.Fill(ds, "cust");
			DataView dv = ds.Tables["cust"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr = "1=1";

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv.Count= "+ dv.Count + "<BR>");
			//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");

			//防呆處理: 若無資料時, 則給錯誤訊息
			//if (dv1.Count < 1)  ...
			// 若找到資料, 則在 Server Web Control 顯示之

			if(tbxCompanyName.Text!="")
				rowfilterstr=rowfilterstr+" and mfr_inm Like '%"+tbxCompanyName.Text.Trim()+"%'";

			if(tbxMfrNo.Text!="")
				rowfilterstr=rowfilterstr+" and cust_mfrno Like '%"+tbxMfrNo.Text.Trim()+"%'";

			if(tbxCustNo.Text!="")
				rowfilterstr=rowfilterstr+" and cust_custno ='"+tbxCustNo.Text.Trim()+"'";

			if(tbxCustName.Text!="")
				rowfilterstr=rowfilterstr+" and cust_nm Like '%"+tbxCustName.Text.Trim()+"%'";
			
			//如果是D級業務人員，只能看到自己的客戶資料
			if(Session["atype"].ToString().Equals("D"))
				rowfilterstr=rowfilterstr + " and (cust_srspn_empno = '" + Session["empid"].ToString() + "'  or  cust_mfrno in ( " + FindMfrByEmpno(Session["empid"].ToString()) + "))";

			dv.RowFilter = rowfilterstr;

			// 若搜尋結果為 "找不到" 的處理
			if (dv.Count==0)
				lblMessage.Text="查詢結果: 找不到符合條件的資料, 您可以 1.重設條件  2.新增廠商或訂戶資料";
			else
				lblMessage.Text="查詢結果: 找到 "+dv.Count.ToString()+"筆客戶資料";
			
			DataGrid1.DataSource=dv;
			DataGrid1.DataBind();
			

			// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
			int i;
			for(i=0; i< DataGrid1.Items.Count ; i++)
			{
				// 檢查廠商統編是否存在, 並輸出其公司名稱
				string mfrNo =  DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
				if(mfrNo == "99999999")
					DataGrid1.Items[i].Cells[3].Text = "沒統一編號之廠商";
				
				
				// 註冊日期
				string RegDate = "";
				if(DataGrid1.Items[i].Cells[8].Text != "")
				{
					RegDate = DataGrid1.Items[i].Cells[8].Text.ToString().Trim();
					if(RegDate.Length >= 8)
						DataGrid1.Items[i].Cells[8].Text = RegDate.Substring(0, 4) + "/" + RegDate.Substring(4, 2) + "/" + RegDate.Substring(6, 2);
					else
						DataGrid1.Items[i].Cells[8].Text = RegDate;
				}
				else
				{
					DataGrid1.Items[i].Cells[8].Text = "";
				}
				
				// 舊客戶資料
				string OldCustNo = DataGrid1.Items[i].Cells[9].Text.ToString().Trim();
				if(OldCustNo=="")
					DataGrid1.Items[i].Cells[9].Text = "<font color=Gray>無資料</font>";
				else
					DataGrid1.Items[i].Cells[9].Text = DataGrid1.Items[i].Cells[9].Text;
				
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
			}
			else if(e.CommandName=="OK")
			{
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds = new DataSet();
				this.sqlDataAdapter1.Fill(ds, "cust");
				DataView dv = ds.Tables["cust"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
				dv.RowFilter = "cust_custno='" + DataGrid1.SelectedItem.Cells[4].Text + "'";

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv.Count= "+ dv.Count + "<BR>");
				//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");

				//防呆處理: 若無資料時, 則給錯誤訊息
				//if (dv1.Count < 1)  ...
				// 若找到資料, 則在 Server Web Control 顯示之


				//// 按下確定(挑人)的處理: 先轉址
				Response.Redirect("cont_new2.aspx?function1=new&custno="+DataGrid1.SelectedItem.Cells[4].Text.Trim());
				//if(Context.Request.QueryString["conttp"]=="01")
					//Response.Redirect("cont_new2.aspx?function1=new&custno="+DataGrid1.SelectedItem.Cells[4].Text.Trim() + "&conttp=01");
				//else if(Context.Request.QueryString["conttp"]=="09")
					//Response.Redirect("cont_new2.aspx?function1=new&custno="+DataGrid1.SelectedItem.Cells[4].Text.Trim() + "&conttp=09");

			}
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
		

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			ShowCust();
		}

	}
}
