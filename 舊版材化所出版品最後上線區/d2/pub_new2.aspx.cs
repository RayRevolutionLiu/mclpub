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
// WebApplication Virables - Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for pub_new2.
	/// </summary>
	public class pub_new2 : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.TextBox tbxPubDate;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Literal literal1;

		public pub_new2()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;

			if (!Page.IsPostBack)
			{
				Response.Expires=0;

				// 給 截止年月 tbxPubDate 預設值 (今天年月)
				this.tbxPubDate.Text = System.DateTime.Today.ToString("yyyyMM").Trim();

				// 清除畫面資料
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


		// 查詢按鈕: 呼叫 Function: ShowPub()
		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			ShowPub();
		}


		private void ShowPub()
		{
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_pub");
			DataView dv1 = ds1.Tables["c2_pub"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			//防呆處理: 若無資料時, 則給錯誤訊息
			if(tbxContNo.Text!="")
				rowfilterstr1 = rowfilterstr1 + " and cont_contno like '%" + tbxContNo.Text.Trim() + "%'";

			if(tbxPubDate.Text!="")
				rowfilterstr1 = rowfilterstr1 + " and pub_yyyymm like '" + tbxPubDate.Text.Trim() + "%'";

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("rowfilterstr1= " + rowfilterstr1 + "<BR>");
			dv1.RowFilter = rowfilterstr1;


			// 若搜尋結果為 "找不到" 的處理
			if (dv1.Count==0)
				lblMessage.Text="結果: 找不到符合條件的資料, 您可以 重設條件";
			else
				lblMessage.Text="結果: 找到 "+dv1.Count.ToString()+"筆資料";

			DataGrid1.DataSource=dv1;
			DataGrid1.DataBind();


			// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
			int i;
			for(i=0; i< DataGrid1.Items.Count ; i++)
			{
				// 已落版註記
				string strfgclosed = DataGrid1.Items[i].Cells[9].Text.ToString().Trim();
				//Response.Write("strfgclosed= " + strfgclosed + "<br>");
				if(strfgclosed == "0")
				{
					DataGrid1.Items[i].Cells[9].Text = "否";
				}
				else
				{
					DataGrid1.Items[i].Cells[9].Text = "<font color=red>是</font>";
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
				this.sqlDataAdapter1.Fill(ds, "c2_pub");
				DataView dv = ds.Tables["c2_pub"].DefaultView;

				dv.RowFilter="cont_contno='"+DataGrid1.SelectedItem.Cells[0].Text+"'";
				//Response.Write("dv.RowFilter= " + dv.RowFilter + "<br>");
				//Response.Write("DataGrid1.SelectedItem.Cells[0].Text= " + DataGrid1.SelectedItem.Cells[0].Text + "<br>");

				// 按下確定(挑人)的處理: 先轉址
				//Response.Redirect("adpub_detail.aspx?contno=" + DataGrid1.SelectedItem.Cells[0].Text.Trim() + "&pubseq=" + DataGrid1.SelectedItem.Cells[2].Text.Trim());
				string strfgnew = "";
				Response.Redirect("PubFm.aspx?contno=" + DataGrid1.SelectedItem.Cells[0].Text.Trim() + "&bkcd=" + DataGrid1.SelectedItem.Cells[3].Text.Trim() + "&fgnew=" + DataGrid1.SelectedItem.Cells[10].Text.Trim());
			}
		}


		// 換頁處理
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			ShowPub();
		}


		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				new System.Data.Common.DataColumnMapping("cont_contid", "cont_contid"),
																																																				new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																				new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																				new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																				new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																				new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				new System.Data.Common.DataColumnMapping("cont_modempno", "cont_modempno"),
																																																				new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp")})});
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT DISTINCT dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_cont.cont_contid, dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_empno, dbo.c2_cont.cont_mfrno, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate, dbo.c2_cont.cont_custno, dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_autel, dbo.cust.cust_custid, dbo.cust.cust_nm, dbo.cust.cust_jbti, dbo.cust.cust_tel, dbo.mfr.mfr_mfrid, dbo.mfr.mfr_inm, dbo.cust.cust_custno, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_modempno, dbo.mfr.mfr_mfrno, dbo.c2_cont.cont_fgpubed, dbo.book.bk_nm, dbo.book.bk_bkcd, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp FROM dbo.c2_pub INNER JOIN dbo.c2_cont ON dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.book ON dbo.c2_pub.pub_bkcd = dbo.book.bk_bkcd WHERE (dbo.c2_cont.cont_fgclosed = '0') AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion




	}
}
