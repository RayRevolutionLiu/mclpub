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

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adpub_main11.
	/// </summary>
	public class adpub_main11 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxMfrName;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Literal literal1;
		protected System.Web.UI.WebControls.LinkButton lnbNewMfr;
		protected System.Web.UI.WebControls.LinkButton lnbNewCust;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.HtmlControls.HtmlForm adpub_main;
	
		public adpub_main11()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				//
				literal1.Text="";

				// 不能清除輸入查詢之關鍵字, 否則無法出現正確結果
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
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT c2_cont.cont_contid, c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_conttp, c2_cont.cont_bkcd, c2_cont.cont_signdate, c2_cont.cont_empno, c2_cont.cont_mfrno, c2_cont.cont_aunm, c2_cont.cont_autel, c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_custno, mfr.mfr_mfrid, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_respnm, mfr.mfr_respjbti, mfr.mfr_tel, cust.cust_custid, cust.cust_custno, cust.cust_nm, cust.cust_jbti, cust.cust_tel, cust.cust_oldcustno, book.bk_nm, book.bk_bkcd, c2_cont.cont_fgclosed FROM c2_cont INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd WHERE (c2_cont.cont_fgclosed <> '1')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_contid", "cont_contid"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_tel", "mfr_tel"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("cust_oldcustno", "cust_oldcustno"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			// 查詢按鈕: 呼叫 Function: ShowPub() 
			ShowPub();
		}


		private void ShowPub()
		{
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "c2_pub");
			DataView dv = ds.Tables["c2_pub"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr = "mfr_mfrno Like '%"+tbxMfrNo.Text.Trim()+"%'";

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv.Count= "+ dv.Count + "<BR>");
			//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");

			//防呆處理: 若無資料時, 則給錯誤訊息
			//if (dv1.Count < 1)  ...
			// 若找到資料, 則在 Server Web Control 顯示之


			if(tbxMfrName.Text!="")
				rowfilterstr=rowfilterstr+" and mfr_inm Like '%"+tbxMfrName.Text.Trim()+"%'";
	        
			if(tbxCustNo.Text!="")
				rowfilterstr=rowfilterstr+" and cont_custno ='"+tbxCustNo.Text.Trim()+"'";

			if(tbxCustName.Text!="")
				rowfilterstr=rowfilterstr+" and cust_nm Like '%"+tbxCustName.Text.Trim()+"%'";
			
			if(tbxContNo.Text!="")
				rowfilterstr=rowfilterstr+" and cont_contno like '%"+tbxContNo.Text.Trim()+"%'";
			
			dv.RowFilter = rowfilterstr;

			// 若搜尋結果為 "找不到" 的處理
			if (dv.Count==0)
				lblMessage.Text="結果: 找不到符合條件的資料, 您可以 1.重設條件  2.新增廠商或訂戶資料";
				//lblMessage.Text="查詢結果: 找不到符合條件的資料, 請重設條件!  或請先新增<A HREF='../d5/Mfr.aspx' Target='_new'>廠商</A> 或 <A HREF='../d1/NewCust.aspx?mfrno=' Target='_new'>客戶</A>, 再回來搜尋並新增.";
			else
				lblMessage.Text="結果: 找到 "+dv.Count.ToString()+"筆資料";
			
			DataGrid1.DataSource=dv;
			DataGrid1.DataBind();

			// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
			int i;
			for(i=0; i< DataGrid1.Items.Count ; i++)
			{
				// 合約類別
				int ContTypeCode = int.Parse(DataGrid1.Items[i].Cells[1].Text.ToString().Trim());
				if(ContTypeCode==1)
					DataGrid1.Items[i].Cells[1].Text = "一般合約";
				else
					DataGrid1.Items[i].Cells[1].Text = "<font color=blue>推廣合約</font>";
				
				//書籍類別
				
				
				// 合約起日 & 合約迄日
				string StartDate = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
				string EndDate = DataGrid1.Items[i].Cells[4].Text.ToString().Trim();
				DataGrid1.Items[i].Cells[3].Text = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
				DataGrid1.Items[i].Cells[4].Text = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
				
				// 舊客戶資料
				string OldCustNo = DataGrid1.Items[i].Cells[10].Text.ToString().Trim();
				if(OldCustNo=="")
					DataGrid1.Items[i].Cells[10].Text = "<font color=Gray>無資料</font>";
				else
					DataGrid1.Items[i].Cells[10].Text = DataGrid1.Items[i].Cells[10].Text;
				
				// 結案註記
				string strfgclosed = DataGrid1.Items[i].Cells[11].Text.ToString().Trim();
				//Response.Write("strfgclosed= " + strfgclosed + "<br>");
				if(strfgclosed == "0")
				{
					DataGrid1.Items[i].Cells[11].Text = "否";
				}
				else
				{
					DataGrid1.Items[i].Cells[11].Text = "<font color=red>是</font>";
				}
				
				
			}
			
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
			//Response.Write(DataGrid1.SelectedItem.Cells[1].Text);

			if(e.CommandName=="OK")
			{
				DataSet ds = new DataSet();
				this.sqlDataAdapter1.Fill(ds, "cust");
				DataView dv = ds.Tables["cust"].DefaultView;
				
				dv.RowFilter="cont_contno='"+DataGrid1.SelectedItem.Cells[0].Text+"'";
				//Response.Write("dv.RowFilter= " + dv.RowFilter + "<br>");
				//Response.Write("DataGrid1.SelectedItem.Cells[0].Text= " + DataGrid1.SelectedItem.Cells[0].Text + "<br>");

				// 按下確定(挑人)的處理: 先轉址
				// 因合約類別在 DataGrid1 顯示為文字, 故要先轉換回 文字(數字)型態
				string ConttpText = DataGrid1.SelectedItem.Cells[1].Text.Trim();
				string Conttp = "";
				//Response.Write("ConttpText= " + ConttpText + "<br>");
				if(ConttpText=="一般合約")
					Conttp = "01";
				else
					Conttp = "09";
				Response.Redirect("cont_main3.aspx?custno=" + DataGrid1.SelectedItem.Cells[7].Text.Trim() + "&conttp=" + Conttp + "&old_contno=" + DataGrid1.SelectedItem.Cells[0].Text.Trim());
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
			ShowPub();
		}
	}
}
