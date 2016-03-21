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
	/// Summary description for adlprior_addnew.
	/// </summary>
	public class adlprior_addnew : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox tbxPriorSeq;
		protected System.Web.UI.WebControls.DropDownList ddlColorCode;
		protected System.Web.UI.WebControls.DropDownList ddlLayoutTypeCode;
		protected System.Web.UI.WebControls.DropDownList ddPageSizeCode;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter6;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter7;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Button btnReturnHome;

		public adlprior_addnew()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if(!Page.IsPostBack)
			{
				Response.Expires = 0;

				// 抓出各下拉式選單的值
				InitData();

				// 依書籍類別而抓出其新的排版優先次序
				//BookchangeSeq();


				// 自 落版 新增/維護/刪除 畫面而來, 呼叫本畫面的 特殊處理
				if(Context.Request.QueryString["function"].ToString().Trim() != "")
				{
					FromPub();
				}
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
			this.ddlBookCode.Enabled = true;

			// 清除資料
			this.tbxPriorSeq.Text = "";

			// 顯示下拉式選單 書籍類別的 DB 值
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "book");
			DataView dv2=ds2.Tables["book"].DefaultView;
			ddlBookCode.DataSource=dv2;
			ddlBookCode.DataTextField="bk_nm";
			ddlBookCode.DataValueField="bk_bkcd";
			ddlBookCode.DataBind();

			// 顯示下拉式選單 廣告色彩的 DB 值
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c2_clr");
			DataView dv3=ds3.Tables["c2_clr"].DefaultView;
			ddlColorCode.DataSource=dv3;
			ddlColorCode.DataTextField="clr_nm";
			ddlColorCode.DataValueField="clr_clrcd";
			ddlColorCode.DataBind();

			// 顯示下拉式選單 廣告版面的 DB 值
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "c2_ltp");
			DataView dv4=ds4.Tables["c2_ltp"].DefaultView;
			ddlLayoutTypeCode.DataSource=dv4;
			ddlLayoutTypeCode.DataTextField="ltp_nm";
			ddlLayoutTypeCode.DataValueField="ltp_ltpcd";
			ddlLayoutTypeCode.DataBind();

			// 顯示下拉式選單 廣告篇幅的 DB 值
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "c2_pgsize");
			DataView dv5=ds5.Tables["c2_pgsize"].DefaultView;
			ddPageSizeCode.DataSource=dv5;
			ddPageSizeCode.DataTextField="pgs_nm";
			ddPageSizeCode.DataValueField="pgs_pgscd";
			ddPageSizeCode.DataBind();
		}


		// 依書籍類別而抓出其新的排版優先次序
//		private void BookchangeSeq()
//		{
//			// 抓出目前畫面中(預設的)的書籍類別之值
//			string CurrentBookCode = this.ddlBookCode.SelectedItem.Value.ToString();
//			//Response.Write("CurrentBookCode= "+ CurrentBookCode + "<BR>");
//
//
//			// 依不同書籍類別, 抓出新的排版優先次序 max(lp_priorseq)
//			string strConn="server=isccom1;database=mrlpub;uid=webuser;pwd=db600";
//			//string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
//			SqlConnection myConn=new SqlConnection(strConn);
//
//			//抓出目前資料庫中 (依該書籍類別), 目前最大的排版優先次序之值
//			SqlDataAdapter cmd=new SqlDataAdapter("select COUNT(*) AS TotalCounts, MAX(lp_priorseq) AS MaxSeq from c2_lprior where lp_bkcd='" + CurrentBookCode + "'",myConn);
//			//SqlDataAdapter cmd=new SqlDataAdapter("select COUNT(*) AS TotalCounts, MAX(lp_priorseq) AS MaxSeq from c2_lprior where (lp_bkcd='03')",myConn);
//			//SqlDataAdapter cmd=new SqlDataAdapter("select COUNT(*) AS TotalCounts, MAX(lp_priorseq) AS MaxSeq from c2_lprior where (lp_bkcd = '02')",myConn);
//			DataSet ds = new DataSet();
//			cmd.Fill(ds, "c2_lprior");
//			DataView dv = ds.Tables["c2_lprior"].DefaultView;
//			//Response.Write("dv.Count= "+ dv.Count + "<BR>");
//
//			string TotalCounts = dv[0]["TotalCounts"].ToString().Trim();
//			string MaxSeq = "";
//			int intNewMaxSeq = 0;
//			// 注意, 若 c2_lprior 裡找不到該書籍類別之值(如 03), 其 MaxSeq 將為 null
//			// 所以要先判斷 MaxSeq 是否為 null, 以免當找不到該書籍類別之值(如03)時, 將產生 error: 不認識 lp_bkcd=03 (即 Row.Filter 過不去)
//			if (dv[0]["MaxSeq"].ToString().Trim() != "")
//			{
//				MaxSeq = dv[0]["MaxSeq"].ToString().Trim();
//				//Response.Write("MaxSeq= " + MaxSeq + "<br>");
//
//				// 抓出新的排版優先次序
//				intNewMaxSeq = (int.Parse(MaxSeq) ) + 1;
//				//Response.Write("intNewMaxSeq= " + intNewMaxSeq + "<br>");
//			}
//			else
//			{
//				MaxSeq = "";
//				intNewMaxSeq = 1;
//			}
//			//Response.Write("TotalCounts= " + TotalCounts + "<br>");
//
//
//			// 若找到此筆資料, 則載入資料
//			if(dv.Count>0)
//			{
//				this.tbxPriorSeq.Text = intNewMaxSeq.ToString().Trim();
//			}
//			else
//			{
//				this.tbxPriorSeq.Text = "1";
//			}
//
//		}


		// 若書籍名稱變更, 則抓出最新的次序值
		private void ddlBookCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//BookchangeSeq();
		}


		// 抓出 指定位置之排版優先次序, 並先執行更新動作 (先將之後筆數之次序值更新)
		private void GetNewlpSeq()
		{
			// 抓出 指定位置之排版優先次序 值
			string CurrentBookCode = this.ddlBookCode.SelectedItem.Value.ToString();
			string CurrentPriorSeq = this.tbxPriorSeq.Text.ToString();
			int intCurrentPriorSeq = Convert.ToInt16(CurrentPriorSeq);
			//Response.Write("CurrentBookCode= " + CurrentBookCode + "<br>");
			//Response.Write("CurrentPriorSeq= " + CurrentPriorSeq + "<br>");
			//Response.Write("intCurrentPriorSeq= " + intCurrentPriorSeq + "<br>");

			// 抓出目前最大值 MaxLPSeq, 好方便抓出之後筆數之逐行資料
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds6 = new DataSet();
			// 給 sqlDataAdapter1 過濾條件 - 指定 Parameters
			this.sqlDataAdapter6.SelectCommand.Parameters["@bkcd"].Value = CurrentBookCode;
			this.sqlDataAdapter6.Fill(ds6, "c2_lprior");
			DataView dv6 = ds6.Tables["c2_lprior"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr6 = "1=1";
			dv6.RowFilter = rowfilterstr6;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
			//Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");

			// 若搜尋結果為 "找不到" 的處理
			string MaxLPSeq = "01";
			int intMaxLPSeq = Convert.ToInt16(MaxLPSeq);
			if (dv6.Count > 0)
			{
				MaxLPSeq = dv6[0]["MaxSeq"].ToString();
				intMaxLPSeq = Convert.ToInt16(MaxLPSeq);
				//Response.Write("intMaxLPSeq= " + intMaxLPSeq + "<br>");

				for(int i=intMaxLPSeq; i>=intCurrentPriorSeq; i--)
				{
					//Response.Write("i= " + i + ", ");
					string stri = Convert.ToString(i);
					if(stri.Length < 2)
						stri = "0" + stri;
					//Response.Write("stri= " + stri + "<br>");

					// 使用 DataSet 方法, 並指定使用的 table 名稱
					DataSet ds7 = new DataSet();
					this.sqlDataAdapter7.Fill(ds7, "c2_lprior");
					DataView dv7 = ds7.Tables["c2_lprior"].DefaultView;

					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
					string rowfilterstr7 = "1=1";
					rowfilterstr7 = rowfilterstr7 + " AND lp_bkcd=" + CurrentBookCode;
					rowfilterstr7 = rowfilterstr7 + " AND lp_priorseq=" + stri;
					dv7.RowFilter = rowfilterstr7;

					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv7.Count= "+ dv7.Count + "<BR>");
					//Response.Write("dv7.RowFilter= " + dv7.RowFilter + "<BR>");

					if(dv7.Count > 0)
					{
						// 抓出 之後筆數之相關值 - 書籍代碼, 廣告版面代碼, 廣告色彩代碼, 廣告篇幅代碼
						string iBookCode = dv7[0]["lp_bkcd"].ToString();
						string iLayoutTypeCode = dv7[0]["lp_ltpcd"].ToString();
						string iColorCode = dv7[0]["lp_clrcd"].ToString();
						string iPageSizeCode = dv7[0]["lp_pgscd"].ToString();
						//Response.Write("iBookCode= " + iBookCode + ", ");
						//Response.Write("iLPSeq= " + stri + ", ");
						//Response.Write("iLayoutTypeCode= " + iLayoutTypeCode + ", ");
						//Response.Write("iColorCode= " + iColorCode + ", ");
						//Response.Write("iPageSizeCode= " + iPageSizeCode + "<br>");

						int intNewLPSeq = i+1;
						string strNewLPSeq = Convert.ToString(intNewLPSeq);
						if(strNewLPSeq.Length < 2)
							strNewLPSeq = "0" + strNewLPSeq;
						//Response.Write("strNewLPSeq= " + strNewLPSeq + "<br><br>");

						// 執行更新動作
						//string strConn="server=isccom2;database=mrlpub;uid=webuser;pwd=db600";
						string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
						SqlConnection myConn=new SqlConnection(strConn);

						SqlDataAdapter cmd=new SqlDataAdapter("UPDATE c2_lprior SET lp_priorseq = '" + strNewLPSeq + "' WHERE (lp_bkcd = @lp_bkcd) AND (lp_clrcd = @lp_clrcd) AND (lp_ltpcd = @lp_ltpcd) AND (lp_pgscd = @lp_pgscd)",myConn);
						//Response.Write("iLPSeq= " + stri + "<br>");
						//Response.Write("cmd= UPDATE c2_lprior SET lp_priorseq = '" + strNewLPSeq + "' WHERE (lp_bkcd = @lp_bkcd) AND (lp_clrcd = @lp_clrcd) AND (lp_ltpcd = @lp_ltpcd) AND (lp_pgscd = @lp_pgscd + ")");

						//cmd.SelectCommand.Parameters.Add("@lp_lpid",SqlDbType.Int,4).Value = id;
						cmd.SelectCommand.Parameters.Add("@lp_bkcd",SqlDbType.Char,2).Value = iBookCode;
						cmd.SelectCommand.Parameters.Add("@lp_priorseq",SqlDbType.Char,2).Value = CurrentPriorSeq;
						cmd.SelectCommand.Parameters.Add("@lp_ltpcd",SqlDbType.Char,2).Value = iLayoutTypeCode;
						cmd.SelectCommand.Parameters.Add("@lp_clrcd",SqlDbType.Char,2).Value = iColorCode;
						cmd.SelectCommand.Parameters.Add("@lp_pgscd",SqlDbType.Char,2).Value = iPageSizeCode;

						DataSet ds = new DataSet();
						cmd.Fill(ds,"c2_lprior");
					}
				}
			}
			else
			{
				MaxLPSeq = MaxLPSeq;
			}
			//Response.Write("MaxLPSeq= " + MaxLPSeq + "<br>");

		}


		// 按下 確定新增 按鈕時的處理
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			// 抓出目前畫面中所有的值, 再比對資料庫裡是否有重覆;
			// 若重覆(資料已存在), 給警告; 反之, 則新增至資料庫中
			string CurrentBookCode = this.ddlBookCode.SelectedItem.Value.ToString();
			string CurrentPriorSeq = this.tbxPriorSeq.Text.ToString();
			string CurrentLayoutTypeCode = this.ddlLayoutTypeCode.SelectedItem.Value.ToString();
			string CurrentColorCode = this.ddlColorCode.SelectedItem.Value.ToString();
			string CurrentPageSizeCode = this.ddPageSizeCode.SelectedItem.Value.ToString();
			//Response.Write("CurrentBookCode= " + CurrentBookCode + "<br>");
			//Response.Write("CurrentPriorSeq= " + CurrentPriorSeq + "<br>");
			//Response.Write("CurrentLayoutTypeCode= " + CurrentLayoutTypeCode + "<br>");
			//Response.Write("CurrentColorCode= " + CurrentColorCode + "<br>");
			//Response.Write("CurrentPageSizeCode= " + CurrentPageSizeCode + "<br>");


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			DataView dv1;
			this.sqlDataAdapter1.Fill(ds1, "c2_lprior");
			dv1 = ds1.Tables["c2_lprior"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 注意: 因為 lp_priorseq 是 自己填入之資料, 故不可填入 Row.Filter, 若填入將因找不到此筆資料, 而變成新增
			//       故要就除了 lp_priorseq 外, 其餘四項去比對資料庫裡是否資料有重覆!
			string rowfilter1 = " 1=1 ";
			rowfilter1 = rowfilter1 + " AND lp_bkcd=" + CurrentBookCode;
			rowfilter1 = rowfilter1 + " AND lp_ltpcd=" + CurrentLayoutTypeCode;
			rowfilter1 = rowfilter1 + " AND lp_clrcd=" + CurrentColorCode;
			rowfilter1 = rowfilter1 + " AND lp_pgscd=" + CurrentPageSizeCode;
			dv1.RowFilter = rowfilter1;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			// 若找到此筆資料, 則載入資料
			if(dv1.Count>0)
			{
				Label1.Text="新增失敗: 資料重覆, 請修正再新增!";
			}
			else
			{
				// 抓出 指定位置之排版優先次序, 並先執行更新動作 (先將之後筆數之次序值更新)
				GetNewlpSeq();

				// 指定新的 LPSeq (NewPriorSeq=CurrentPriorSeq)
				string NewPriorSeq = CurrentPriorSeq;
				if(NewPriorSeq.Length < 2)
					NewPriorSeq = "0" + NewPriorSeq;
				//Response.Write("NewPriorSeq=" + NewPriorSeq + "<br>");

				// 執行 新增動作
				//string strConn="server=isccom2;database=mrlpub;uid=webuser;pwd=db600";
				string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
				SqlConnection myConn=new SqlConnection(strConn);

				SqlDataAdapter cmd=new SqlDataAdapter("insert into c2_lprior(lp_bkcd, lp_priorseq, lp_ltpcd, lp_clrcd, lp_pgscd) values('" + CurrentBookCode + "', '" + NewPriorSeq + "', '" + CurrentLayoutTypeCode + "', '" + CurrentColorCode + "', '" + CurrentPageSizeCode + "')", myConn);
				//Response.Write("cmd= insert into c2_lprior(lp_bkcd, lp_priorseq, lp_ltpcd, lp_clrcd, lp_pgscd) values('" + CurrentBookCode + "', '" + NewPriorSeq + "', '" + CurrentLayoutTypeCode + "', '" + CurrentColorCode + "', '" + CurrentPageSizeCode + "')");

				//cmd.SelectCommand.Parameters.Add("@lp_lpid",SqlDbType.Int,4).Value = id;
				cmd.SelectCommand.Parameters.Add("@lp_bkcd",SqlDbType.Char,2).Value = CurrentBookCode;
				cmd.SelectCommand.Parameters.Add("@lp_priorseq",SqlDbType.Char,2).Value = NewPriorSeq;
				cmd.SelectCommand.Parameters.Add("@lp_ltpcd",SqlDbType.Char,2).Value = CurrentLayoutTypeCode;
				cmd.SelectCommand.Parameters.Add("@lp_clrcd",SqlDbType.Char,2).Value = CurrentColorCode;
				cmd.SelectCommand.Parameters.Add("@lp_pgscd",SqlDbType.Char,2).Value = CurrentPageSizeCode;

				DataSet ds = new DataSet();
				cmd.Fill(ds,"c2_lprior");

				Response.Redirect("adlprior.aspx");
			}
		}


		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("adlprior.aspx");
		}


		// 自 落版 新增/維護/刪除 畫面而來, 呼叫本畫面的 特殊處理
		private void FromPub()
		{
			if(Context.Request.QueryString["function"].ToString().Trim() != "")
			{
				// 自新增落版資料的處理
				if(Context.Request.QueryString["function"].ToString().Trim() == "new")
				{
					// 以 Javascript 的 window.alert()  來告知訊息
					LiteralControl litAlert1 = new LiteralControl();
					litAlert1.Text = "<script language=javascript>alert(\"找不到此版面優先次序, 請先'新增此版面優先次序'; 否則此筆落版無法新增!!!\\n\\n 廣告資料已帶入本畫面, 請先填入優先次序值, 然後按 '確定新增' \\n及 視窗右上角之'x' 來關閉本視窗!\\\n\\n回到落版畫面, 請再按一次 '儲存新增' 按鈕!\");</script>";
					Page.Controls.Add(litAlert1);
				}
				// 自維護落版資料的處理
				else if(Context.Request.QueryString["function"].ToString().Trim() == "mod")
				{
					// 以 Javascript 的 window.alert()  來告知訊息
					LiteralControl litAlert2 = new LiteralControl();
					litAlert2.Text = "<script language=javascript>alert(\"找不到此版面優先次序, 請先'新增此版面優先次序'; 否則此筆落版無法修改!!!\\n\\n 廣告資料已帶入本畫面, 請先填入優先次序值, 然後按 '確定新增' \\n及 視窗右上角之'x' 來關閉本視窗!\\n\\n回到落版畫面, 請再按一次 '儲存修改' 按鈕!\");</script>";
					Page.Controls.Add(litAlert2);
				}

				// 抓取共用的網頁變數
				string strLtpcd = Context.Request.QueryString["ltpcd"].ToString();
				string strClrcd = Context.Request.QueryString["clrcd"].ToString();
				string strPgscd = Context.Request.QueryString["pgscd"].ToString();
				this.ddlLayoutTypeCode.Items.FindByValue(strLtpcd).Selected = true;
				this.ddlColorCode.Items.FindByValue(strClrcd).Selected = true;
				this.ddPageSizeCode.Items.FindByValue(strPgscd).Selected = true;

				// Disable 下拉式選單 - 書籍類別
				this.ddlBookCode.Enabled = false;
			}
		}



		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter7 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter6 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.ddlBookCode.SelectedIndexChanged += new System.EventHandler(this.ddlBookCode_SelectedIndexChanged);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			//
			// sqlDataAdapter4
			//
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_ltp", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("ltp_ltpid", "ltp_ltpid"),
																																																				new System.Data.Common.DataColumnMapping("ltp_ltpcd", "ltp_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm")})});
			//
			// sqlDataAdapter7
			//
			this.sqlDataAdapter7.SelectCommand = this.sqlSelectCommand7;
			this.sqlDataAdapter7.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lprior", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_priorseq", "lp_priorseq"),
																																																				   new System.Data.Common.DataColumnMapping("lp_clrcd", "lp_clrcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_ltpcd", "lp_ltpcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_pgscd", "lp_pgscd")})});
			//
			// sqlDataAdapter5
			//
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pgsize", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("pgs_pgsid", "pgs_pgsid"),
																																																				   new System.Data.Common.DataColumnMapping("pgs_pgscd", "pgs_pgscd"),
																																																				   new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm")})});
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_clr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("clr_clrid", "clr_clrid"),
																																																				new System.Data.Common.DataColumnMapping("clr_clrcd", "clr_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm")})});
			//
			// sqlDataAdapter2
			//
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("bk_bkid", "bk_bkid"),
																																																			  new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																			  new System.Data.Common.DataColumnMapping("proj_syscd", "proj_syscd"),
																																																			  new System.Data.Common.DataColumnMapping("proj_bkcd", "proj_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("proj_fgitri", "proj_fgitri"),
																																																			  new System.Data.Common.DataColumnMapping("proj_projno", "proj_projno"),
																																																			  new System.Data.Common.DataColumnMapping("proj_costctr", "proj_costctr")})});
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lprior", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("lp_lpid", "lp_lpid"),
																																																				   new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_priorseq", "lp_priorseq"),
																																																				   new System.Data.Common.DataColumnMapping("lp_clrcd", "lp_clrcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_ltpcd", "lp_ltpcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_pgscd", "lp_pgscd")})});
			//
			// sqlDataAdapter6
			//
			this.sqlDataAdapter6.SelectCommand = this.sqlSelectCommand6;
			this.sqlDataAdapter6.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lprior", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("MaxSeq", "MaxSeq")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT lp_lpid, lp_bkcd, lp_priorseq, lp_clrcd, lp_ltpcd, lp_pgscd FROM dbo.c2_lp" +
				"rior";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = "SELECT clr_clrid, clr_clrcd, clr_nm FROM dbo.c2_clr";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand4
			//
			this.sqlSelectCommand4.CommandText = "SELECT ltp_ltpid, ltp_ltpcd, ltp_nm FROM dbo.c2_ltp";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand5
			//
			this.sqlSelectCommand5.CommandText = "SELECT pgs_pgsid, pgs_pgscd, pgs_nm FROM dbo.c2_pgsize";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand6
			//
			this.sqlSelectCommand6.CommandText = "SELECT lp_bkcd, MAX(lp_priorseq) AS MaxSeq FROM dbo.c2_lprior WHERE (lp_bkcd = @b" +
				"kcd) GROUP BY lp_bkcd";
			this.sqlSelectCommand6.Connection = this.sqlConnection1;
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "lp_bkcd"));
			//
			// sqlSelectCommand7
			//
			this.sqlSelectCommand7.CommandText = "SELECT lp_bkcd, lp_priorseq, lp_clrcd, lp_ltpcd, lp_pgscd FROM dbo.c2_lprior";
			this.sqlSelectCommand7.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (dbo.proj.proj_fgitri = ' ')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



	}
}
