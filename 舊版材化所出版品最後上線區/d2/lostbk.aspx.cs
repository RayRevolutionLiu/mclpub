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
	/// Summary description for lostbk.
	/// </summary>
	public class lostbk : System.Web.UI.Page
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
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.Button btnReturnHome;

		public lostbk()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if (!Page.IsPostBack)
			{
				Response.Expires = 0;

				// 指定 ddlQueryField 的預設選項
				this.ddlQueryField.SelectedIndex = 01;

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
			//string strConn = "Data Source=isccom2;Initial Catalog=mrlpub;User ID=webuser;Password=db600";
			string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			SqlConnection myConnection = new SqlConnection(strConn);

			string SQL = "SELECT c2_lost.lst_lstid, c2_lost.lst_contno, c2_cont.cont_signdate, c2_cont.cont_fgclosed, ";
			SQL = SQL + " c2_lost.lst_oritem, c2_or.or_nm, c2_or.or_tel, ";
			SQL = SQL + " c2_lost.lst_seq, c2_lost.lst_cont, c2_lost.lst_date, ";
			SQL = SQL + " c2_lost.lst_rea, c2_lost.lst_fgsent ";
			SQL = SQL + " FROM c2_cont INNER JOIN c2_or ";
			SQL = SQL + " ON c2_cont.cont_syscd = c2_or.or_syscd ";
			SQL = SQL + " AND c2_cont.cont_contno = c2_or.or_contno ";
			SQL = SQL + " RIGHT OUTER JOIN c2_lost ON c2_or.or_syscd = c2_lost.lst_syscd ";
			SQL = SQL + " AND c2_or.or_contno = c2_lost.lst_contno ";
			SQL = SQL + " AND c2_or.or_oritem = c2_lost.lst_oritem ";

			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConnection);

			DataSet ds1 = new DataSet();
			myCommand.Fill(ds1,"Title");

			DataView dv1 = ds1.Tables["Title"].DefaultView;


			//			// 我的方法: 使用 sqlDataAdapter1
			//			// 使用 DataSet 方法, 並指定使用的 table 名稱
			//			DataSet ds1 = new DataSet();
			//			DataView dv1;
			//			this.sqlDataAdapter1.Fill(ds1, "cust");
			//			dv1= ds1.Tables["cust"].DefaultView;
			//
			//			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			//			dv1.RowFilter = "1=1";
			//			//string old_contno = Context.Request.QueryString["old_contno"].ToString().Trim();
			//			//dv1.RowFilter = dv1.RowFilter + " and cust_custno=" + lblCustNo.Text;
			//
			//			// 檢查並輸出 最後 Row Filter 的結果
			//			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
			//
			lblResult.Text = "";
			if(dv1.Count>0)
				lblNum.Text = dv1.Count.ToString();
			else
				lblNum.Text = "0";

			if (tbxQString.Text !=null && tbxQString.Text != "")
			{
				dv1.RowFilter = ddlQueryField.SelectedItem.Value + " LIKE '%" + tbxQString.Text.Trim() +"%'";
				lblResult.Text = "搜尋結果...";
				lblNum.Text = dv1.Count.ToString();
				lblState.Text = "";
			}

			DataGrid1.DataSource = dv1;
			DataGrid1.DataBind();


			//註記類 => 數值改以文字顯示
			int i;
			for(i=0; i< DataGrid1.Items.Count ; i++)
			{
				// 抓出 郵寄類別的文字 及 海外郵寄註記的值
				// 變更簽約日期的格式
				string SignDate = "";
				if(DataGrid1.Items[i].Cells[2].Text.Trim()=="")
					DataGrid1.Items[i].Cells[2].Text = DataGrid1.Items[i].Cells[2].Text;
				else
				{
					if(DataGrid1.Items[i].Cells[2].Text.Length >=8)
					{
						SignDate = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
						DataGrid1.Items[i].Cells[2].Text = SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
					}
					else
						DataGrid1.Items[i].Cells[2].Text = DataGrid1.Items[i].Cells[2].Text;
				}
				//Response.Write("SignDate= " + SignDate + "<br>");

				// 顯示結案註記的文字說明
				string fgclosed = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
				if(fgclosed != "0")
					DataGrid1.Items[i].Cells[3].Text = "<FONT Color=Red>是</FONT>";
				else
					DataGrid1.Items[i].Cells[3].Text = "否";

				// 變更缺書日期的格式
				string lostRegDate = "";
				if(DataGrid1.Items[i].Cells[9].Text.Trim()=="")
					DataGrid1.Items[i].Cells[9].Text = DataGrid1.Items[i].Cells[9].Text;
				else
				{
					if(DataGrid1.Items[i].Cells[9].Text.Length >=8)
					{
						lostRegDate = DataGrid1.Items[i].Cells[9].Text.ToString().Trim();
						DataGrid1.Items[i].Cells[9].Text = lostRegDate.Substring(0, 4) + "/" + lostRegDate.Substring(4, 2) + "/" + lostRegDate.Substring(6, 2);
					}
					else
						DataGrid1.Items[i].Cells[9].Text = DataGrid1.Items[i].Cells[9].Text;
				}
				DataGrid1.Items[i].Cells[9].Text = lostRegDate.Substring(0, 4) + "/" + lostRegDate.Substring(4, 2) + "/" + lostRegDate.Substring(6, 2);
				//Response.Write("lostRegDate= " + lostRegDate + "<br>");

				// 依註記類的值, 顯示其文字; 若為是, 則以紅色字顯示
				string fgsent = DataGrid1.Items[i].Cells[11].Text.ToString().Trim();
				if(fgsent == "Y")
				{
					DataGrid1.Items[i].Cells[11].Text = "可寄出";
				}
				else if(fgsent == "N")
				{
					DataGrid1.Items[i].Cells[11].Text = "<font color='Red'>目前暫時無法寄出</font>";
				}
				else if(fgsent == "D")
				{
					DataGrid1.Items[i].Cells[11].Text = "<font color='Red'>不處理</font>";
				}
				else if(fgsent == "C")
				{
					DataGrid1.Items[i].Cells[11].Text = "<font color='Blue'>已寄出</font>";
				}
			}

			// 恢復 ddlQueryField 的預設選項
			//this.ddlQueryField.SelectedIndex = 01;

		}


		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid();
		}


		private void Query_Click(object sender, System.EventArgs e)
		{
			DataGrid1.CurrentPageIndex=0;
			DataGrid1.EditItemIndex=-1;
			BindGrid();
		}


		private void btnShowAll_Click(object sender, System.EventArgs e)
		{
			tbxQString.Text="";
			DataGrid1.CurrentPageIndex=0;
			BindGrid();
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
			this.Query.Click += new System.EventHandler(this.Query_Click);
			this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("lst_lstid", "lst_lstid"),
																																																				 new System.Data.Common.DataColumnMapping("lst_contno", "lst_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("lst_oritem", "lst_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_tel", "or_tel"),
																																																				 new System.Data.Common.DataColumnMapping("lst_seq", "lst_seq"),
																																																				 new System.Data.Common.DataColumnMapping("lst_cont", "lst_cont"),
																																																				 new System.Data.Common.DataColumnMapping("lst_date", "lst_date"),
																																																				 new System.Data.Common.DataColumnMapping("lst_rea", "lst_rea"),
																																																				 new System.Data.Common.DataColumnMapping("lst_fgsent", "lst_fgsent"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("lst_syscd", "lst_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																				 new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c2_lost.lst_lstid, dbo.c2_lost.lst_contno, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_fgclosed, dbo.c2_lost.lst_oritem, dbo.c2_or.or_nm, dbo.c2_or.or_tel, dbo.c2_lost.lst_seq, dbo.c2_lost.lst_cont, dbo.c2_lost.lst_date, dbo.c2_lost.lst_rea, dbo.c2_lost.lst_fgsent, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd, dbo.c2_lost.lst_syscd, dbo.c2_or.or_contno, dbo.c2_or.or_oritem, dbo.c2_or.or_syscd FROM dbo.c2_cont INNER JOIN dbo.c2_or ON dbo.c2_cont.cont_syscd = dbo.c2_or.or_syscd AND dbo.c2_cont.cont_contno = dbo.c2_or.or_contno RIGHT OUTER JOIN dbo.c2_lost ON dbo.c2_or.or_syscd = dbo.c2_lost.lst_syscd AND dbo.c2_or.or_contno = dbo.c2_lost.lst_contno AND dbo.c2_or.or_oritem = dbo.c2_lost.lst_oritem";
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
