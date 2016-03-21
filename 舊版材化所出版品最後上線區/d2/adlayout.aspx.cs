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
	/// Summary description for adlayout.
	/// </summary>
	public class adlayout : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox tbxQString;
		protected System.Web.UI.WebControls.DropDownList ddlQueryField;
		protected System.Web.UI.WebControls.Button Query;
		protected System.Web.UI.WebControls.Button btnShowAll;
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.Label lblResult;
		protected System.Web.UI.WebControls.Label lblNum;
		protected System.Web.UI.WebControls.Label lblState;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;

		public adlayout()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{

				BindGrid();
			}

		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		public void BindGrid()
		{
			//Kevin: 透過 SqlDataAdapter 從資料庫中讀取資料
			//string DSN = "Data Source=isccom2;Initial Catalog=mrlpub;User ID=webuser;Password=db600";
			//SqlConnection myConnection = new SqlConnection(DSN);
			//string strConn="Data Source=isccom2;database=mrlpub;uid=webuser;pwd=db600";
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConnection = new SqlConnection(strConn);

			string SQL = "select * from c2_ltp";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConnection);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"Title");

			DataView dv = ds.Tables["Title"].DefaultView;

			lblResult.Text = "";
			lblNum.Text = dv.Count.ToString();

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


			if (tbxQString.Text !=null && tbxQString.Text != "")
			{
				dv.RowFilter = ddlQueryField.SelectedItem.Value + " LIKE '%" + tbxQString.Text.Trim() +"%'";
				lblResult.Text = "搜尋結果...";
				lblNum.Text = dv.Count.ToString();
				lblState.Text = "";
			}

			DataGrid1.DataSource = dv;
			DataGrid1.DataBind();
		}


		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// 檢查資料項是否已被使用, 若是, 將不允許刪除
			DataGrid1.SelectedIndex=e.Item.ItemIndex;

			// 抓出 廣告相關欄位之值
			string strltpcd = e.Item.Cells[1].Text.ToString();
			//Response.Write("strltpcd= "+ strltpcd + "<BR>");

			// 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 篩選資料
			this.sqlSelectCommand1.Parameters["@ltpcd"].Value = strltpcd;


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_pub");
			DataView dv1 = ds1.Tables["c2_pub"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";
			dv1.RowFilter = rowfilterstr1;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");


			// 若搜尋結果為 "找不到" 的處理
			if (dv1.Count > 0)
			{
				int intPubCounts = Convert.ToInt16(dv1[0]["PubCounts"].ToString().Trim());
				//Response.Write("intPubCounts= "+ intPubCounts + "<BR>");

				if (intPubCounts > 0)
				{
					// 以 Javascript 的 window.close() 來告知訊息
					LiteralControl litAlert1 = new LiteralControl();
					litAlert1.Text = "<script language=javascript>alert(\"刪除無效：本筆資料已被使用, 將不允許刪除！\");</script>";
					Page.Controls.Add(litAlert1);
				}
			}
			// 進行刪除
			else
			{
				//string strConn="Data Source=isccom2;database=mrlpub;uid=webuser;pwd=db600";
				string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
				SqlConnection myConn=new SqlConnection(strConn);
				SqlDataAdapter cmd=new SqlDataAdapter("delete from c2_ltp where ltp_ltpid=@ltp_ltpid",myConn);

				cmd.SelectCommand.Parameters.Add("@ltp_ltpid",SqlDbType.Int,4).Value=e.Item.Cells[0].Text;

				cmd.SelectCommand.Connection.Open();
				cmd.SelectCommand.ExecuteNonQuery();
				cmd.SelectCommand.Connection.Close();
				DataGrid1.CurrentPageIndex=0;
				BindGrid();

				lblState.Text = " ... 資料刪除成功 !";
			}
		}


		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string id = "ID="+DataGrid1.SelectedItem.Cells[0].Text;
			Response.Redirect("adlayout_edit.aspx?" + id);
		}


		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid();

			lblState.Text = "";
		}


		private void Query_Click(object sender, System.EventArgs e)
		{
			DataGrid1.CurrentPageIndex=0;
			DataGrid1.EditItemIndex=-1;
			BindGrid();

			lblState.Text = "";
		}


		private void btnShowAll_Click(object sender, System.EventArgs e)
		{
			tbxQString.Text="";
			DataGrid1.CurrentPageIndex=0;
			BindGrid();

			lblState.Text = "";
		}


		private void btnAddNew_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("adlayout_addnew.aspx");
		}


		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("../default.aspx");
		}


		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
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
																									  new System.Data.Common.DataTableMapping("Table", "c2_ltp", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("PubCounts", "PubCounts"),
																																																				new System.Data.Common.DataColumnMapping("ltp_ltpcd", "ltp_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT COUNT(dbo.c2_pub.pub_contno) AS PubCounts, dbo.c2_ltp.ltp_ltpcd, dbo.c2_ltp.ltp_nm FROM dbo.c2_ltp INNER JOIN dbo.c2_pub ON dbo.c2_ltp.ltp_ltpcd = dbo.c2_pub.pub_ltpcd WHERE (dbo.c2_ltp.ltp_ltpcd = @ltpcd) GROUP BY dbo.c2_ltp.ltp_ltpcd, dbo.c2_ltp.ltp_nm";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ltpcd", System.Data.SqlDbType.VarChar, 2, "ltp_ltpcd"));
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
