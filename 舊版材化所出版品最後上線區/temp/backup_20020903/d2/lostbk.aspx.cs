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
namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for lostbk.
	/// </summary>
	public class lostbk : System.Web.UI.Page
	{
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
			if (!Page.IsPostBack)
			{
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
																																																				 new System.Data.Common.DataColumnMapping("lst_fgsent", "lst_fgsent")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT c2_lost.lst_lstid, c2_lost.lst_contno, c2_cont.cont_signdate, c2_cont.cont_fgclosed, c2_lost.lst_oritem, c2_or.or_nm, c2_or.or_tel, c2_lost.lst_seq, c2_lost.lst_cont, c2_lost.lst_date, c2_lost.lst_rea, c2_lost.lst_fgsent, c2_cont.cont_contno, c2_cont.cont_syscd, c2_lost.lst_syscd, c2_or.or_contno, c2_or.or_oritem, c2_or.or_syscd FROM c2_cont INNER JOIN c2_or ON c2_cont.cont_syscd = c2_or.or_syscd AND c2_cont.cont_contno = c2_or.or_contno RIGHT OUTER JOIN c2_lost ON c2_or.or_syscd = c2_lost.lst_syscd AND c2_or.or_contno = c2_lost.lst_contno AND c2_or.or_oritem = c2_lost.lst_oritem";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		public void BindGrid()
		{
			//Kevin: 透過 SqlDataAdapter 從資料庫中讀取資料
			string DSN = "Data Source=isccom1;Initial Catalog=mrlpub;User ID=webuser;Password=db600";
			SqlConnection myConnection = new SqlConnection(DSN);
			
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
				string signdate = "";
				string lostregdate = "";
				if(DataGrid1.Items[i].Cells[2].Text.ToString().Trim()!="")
					signdate = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
				string fgclosed = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
				if(DataGrid1.Items[i].Cells[9].Text.ToString().Trim()!="")
					lostregdate = DataGrid1.Items[i].Cells[9].Text.ToString().Trim();
				string fgsent = DataGrid1.Items[i].Cells[11].Text.ToString().Trim();
				//Response.Write("signdate= " + signdate + "<br>");
				//Response.Write("fgsent= " + fgsent + "<br>");
				
				// 變更簽約日期的格式
				if(DataGrid1.Items[i].Cells[2].Text.Trim()=="")
					DataGrid1.Items[i].Cells[2].Text = DataGrid1.Items[i].Cells[2].Text;
				else
					DataGrid1.Items[i].Cells[2].Text = signdate.Substring(0, 4) + "/" + signdate.Substring(5, 2) + "/" + signdate.Substring(6, 2);
				DataGrid1.Items[i].Cells[9].Text = lostregdate.Substring(0, 4) + "/" + lostregdate.Substring(5, 2) + "/" + lostregdate.Substring(6, 2);
				
				// 顯示結案註記的文字說明
				int intfgclosed = int.Parse(fgclosed);
				if(intfgclosed != 0)
					DataGrid1.Items[i].Cells[3].Text = "<FONT Color=Red>是</FONT>";
				else
					DataGrid1.Items[i].Cells[3].Text = "否";
				
				// 依註記類的值, 顯示其文字; 若為是, 則以紅色字顯示
				if(fgsent == "0")
				{
					DataGrid1.Items[i].Cells[11].Text = "<font color=red>否</font>";
				}
				else
				{
					DataGrid1.Items[i].Cells[11].Text = "是";
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
			Response.Redirect("/mrlpub/default.aspx");
		}
		
		
	}
}
