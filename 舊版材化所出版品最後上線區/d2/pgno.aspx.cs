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
// SqlConnection
using System.Data.SqlClient;
// WebApplication Virables - Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for pgno.
	/// </summary>
	public class pgno : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblResult;
		protected System.Web.UI.WebControls.Label lblNum;
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.TextBox tbxQString;
		protected System.Web.UI.WebControls.DropDownList ddlQueryField;
		protected System.Web.UI.WebControls.Button Query;
		protected System.Web.UI.WebControls.Button btnShowAll;
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.Button btnReturnHome;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if (!Page.IsPostBack)
			{
				Response.Expires = 0;

				// 檢查自 新增或修改回來時, 應給的確認訊息
				if (Request.QueryString["ID"] != null)
				{
					string id = Request.QueryString["action"].ToString();
					if (id == "addnew_ok")
					{
						lblState.Text = " ... 資料新增成功 !";
					}
					if (id == "edit_ok")
					{
						lblState.Text = " ... 資料修改成功 !";
					}
				}

				BindGrid1();
			}
		}


		// 顯示 DataGrid1
		public void BindGrid1()
		{
			// 先檢查該合約是否有未開發票的落版資料, 若無, 不予轉址
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_pgno");
			DataView dv1 = ds1.Tables["c2_pgno"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";
			dv1.RowFilter = rowfilterstr1;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");


			if(dv1.Count > 0)
			{
				lblResult.Text = "";
				lblNum.Text = dv1.Count.ToString();


				DataGrid1.DataSource = dv1;
				DataGrid1.DataBind();
			}
		}


		// 開始搜尋 按鈕的處理
		private void Query_Click(object sender, System.EventArgs e)
		{
			DataGrid1.CurrentPageIndex=0;
			DataGrid1.EditItemIndex=-1;

			// 先檢查該合約是否有未開發票的落版資料, 若無, 不予轉址
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_pgno");
			DataView dv1 = ds1.Tables["c2_pgno"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";
			if (tbxQString.Text !=null && tbxQString.Text != "")
			{
				rowfilterstr1 = rowfilterstr1 + " AND bk_nm LIKE '%" + this.tbxQString.Text.ToString().Trim() +"%'";
				lblResult.Text = "搜尋結果...";
				lblNum.Text = dv1.Count.ToString();
				lblState.Text = "";
			}
			else
			{
				rowfilterstr1 = rowfilterstr1;
			}
			dv1.RowFilter = rowfilterstr1;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");


			if(dv1.Count > 0)
			{
				lblResult.Text = "";
				lblNum.Text = dv1.Count.ToString();


				DataGrid1.DataSource = dv1;
				DataGrid1.DataBind();
			}
			lblState.Text = "";
		}


		// 全部顯示 按鈕的處理
		private void btnShowAll_Click(object sender, System.EventArgs e)
		{
			this.tbxQString.Text = "";
			lblState.Text = "";
			DataGrid1.CurrentPageIndex=0;

			BindGrid1();
		}


		// 新增資料 按鈕的處理
		private void btnAddNew_Click(object sender, System.EventArgs e)
		{
			// 轉址
			Response.Redirect("pgno_addnew.aspx");
		}


		// 回系統首頁 按鈕的處理
		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			// 轉址
			Response.Redirect("../default.aspx");
		}


		// DataGrid1 換頁 的處理
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid1();

			lblState.Text = "";
		}


		// 修改 按鈕的處理
		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string id = "ID="+DataGrid1.SelectedItem.Cells[0].Text;
			Response.Redirect("pgno_edit.aspx?" + id);
		}


		// 刪除 按鈕的處理
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//
			if(e.CommandName == "Delete")
			{
				// 抓出 PK 值 - 書籍類別代碼
				string strbkcd = e.Item.Cells[3].Text.ToString();
				//Response.Write("strbkcd= "+ strbkcd + "<BR>");

				// 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 新增入資料庫
				//Response.Write(this.sqlCommand1.CommandText);
				this.sqlCommand1.Parameters["@bkcd"].Value = strbkcd;
				//Response.Write(sqlCommand1.Parameters.Count.ToString().Trim());


				// 確認執行 sqlCommand1 成功
				this.sqlCommand1.Connection.Open();

				// 使用 Transaction 確認有執行動作
				System.Data.SqlClient.SqlTransaction myTrans = this.sqlCommand1.Connection.BeginTransaction();
				this.sqlCommand1.Transaction = myTrans;
				try
				{
					this.sqlCommand1.ExecuteNonQuery();
					myTrans.Commit();
					Literal1.Text = "<script language=javascript>alert(\"資料刪除成功!\");</script>";
				}
				catch(System.Data.SqlClient.SqlException ex1)
				{
					Response.Write(ex1.Message + "<br>");
					myTrans.Rollback();
					Literal1.Text = "<script language=javascript>alert(\"資料刪除失敗!\");</script>";
				}
				finally
				{
					this.sqlCommand1.Connection.Close();
				}


				// Refresh DataGrid1
				BindGrid1();
			}
		}



		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.Query.Click += new System.EventHandler(this.Query_Click);
			this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pgno", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("pg_pgid", "pg_pgid"),
																																																				 new System.Data.Common.DataColumnMapping("pg_bkcd", "pg_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pg_startpgno", "pg_startpgno"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd")})});
			//
			// sqlCommand1
			//
			this.sqlCommand1.CommandText = "DELETE FROM c2_pgno WHERE (pg_bkcd = @bkcd)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pg_bkcd", System.Data.DataRowVersion.Original, null));
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT dbo.c2_pgno.pg_pgid, dbo.c2_pgno.pg_bkcd, dbo.c2_pgno.pg_startpgno, dbo.bo" +
				"ok.bk_nm, dbo.book.bk_bkcd FROM dbo.c2_pgno INNER JOIN dbo.book ON dbo.c2_pgno.p" +
				"g_bkcd = dbo.book.bk_bkcd";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



	}
}
