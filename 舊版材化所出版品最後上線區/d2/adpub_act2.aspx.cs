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
using System.Data.SqlClient;
// WebApplication Virables - Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adpub_act2.
	/// </summary>
	public class adpub_act2 : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblSearchKeyword;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidData_special;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidData;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.Label lblTotalCounts;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tbxStartPageNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.Label lblClrPgsGroupCount;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.Label lblDBMessage;

		public adpub_act2()
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

				// 讀取一般版面的起始頁碼 (根據指定之書籍類別)
				GetStartPageNo();

				// 給預設值
				InitialMyData();


				//Load Data From DB, 轉成 xml 型態, 再填入 document.form1.hidData.Value
				LoadDataFromDB_special();
				LoadDataFromDB();
			}

		}


		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		// 讀取一般版面的起始頁碼 (根據指定之書籍類別)
		private void GetStartPageNo()
		{
			// 抓出 書籍代碼
			string strBkcd = Context.Request.QueryString["bkcd"].ToString();

			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds3 = new DataSet();
			// 給 sqlDataAdapter1 過濾條件 - 指定 Parameters
			this.sqlDataAdapter3.Fill(ds3, "c2_pgno");
			DataView dv3 = ds3.Tables["c2_pgno"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr3 = "1=1";
			rowfilterstr3 = rowfilterstr3 + " AND pg_bkcd='" + strBkcd+ "'";
			dv3.RowFilter = rowfilterstr3;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

			// 若搜尋結果為 "找到" 的處理
			string strStartPgNo = "0";
			if (dv3.Count > 0)
			{
				strStartPgNo = dv3[0]["pg_startpgno"].ToString();
			}
			//Response.Write("strStartPgNo= " + strStartPgNo + "<br>");
			this.tbxStartPageNo.Value = strStartPgNo;
		}


		// 給預設值
		private void InitialMyData()
		{
			// 抓出網頁變數 bkcd & yyyymm, 將之轉成文字顯示之
			string Reqbkcd = Context.Request.QueryString["bkcd"].ToString();
			string Reqyyyymm = Context.Request.QueryString["yyyymm"].Trim();
			//Response.Write("Reqbkcd= " + Reqbkcd + "<br>");
			//Response.Write("Reqyyyymm= " + Reqyyyymm + "<br>");

			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "book");
			DataView dv = ds.Tables["book"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			dv.RowFilter = "1=1";
			if(Reqbkcd != "")
				dv.RowFilter = "bk_bkcd=" + Reqbkcd ;
			else
				dv.RowFilter = dv.RowFilter;

			//防呆處理: 若 BookName 無資料時, 則給錯誤訊息
			string BookName = "";
			if(dv.Count > 0)
				BookName = dv[0]["bk_nm"].ToString();
			else
				BookName = BookName;
			//Response.Write("BookName= " + BookName + "<br>");
			this.lblSearchKeyword.Text = BookName;

			// 檢查網頁變數 刊登年月 是否有輸入
			if(Reqyyyymm != "")
			{
				if(Reqyyyymm.Length==6)
					Reqyyyymm = Reqyyyymm.Substring(0, 4) + " / " + Reqyyyymm.Substring(4, 2);
				else
					Reqyyyymm = Reqyyyymm;
				this.lblSearchKeyword.Text = lblSearchKeyword.Text + " & 刊登年月 " + Reqyyyymm;
				//Response.Write("無刊登年月資料<br>");
			}
			else
			{
				this.lblSearchKeyword.Text = lblSearchKeyword.Text;
				//Response.Write("刊登年月 " + Reqyyyymm + "<br>");
			}


			// 抓出總筆數
			// 檢查網頁變數 刊登年月 是否有輸入
			if(Reqbkcd != "" && Reqyyyymm != "")
			{
				Reqyyyymm = Context.Request.QueryString["yyyymm"].Trim();

				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "c2_pub");
				DataView dv2 = ds2.Tables["c2_pub"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				string rowfilterstr2 = "1=1";
				rowfilterstr2 = rowfilterstr2 + " AND pub_bkcd='" + Reqbkcd + "'";
				rowfilterstr2 = rowfilterstr2 + " AND pub_yyyymm='" + Reqyyyymm + "'";
				dv2.RowFilter = rowfilterstr2;

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
				//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

				if(dv2.Count > 0)
				{
					//Response.Write("Total: " + dv2.Count.ToString() + "<br>");
					this.lblTotalCounts.Text = "(  總筆數：" + dv2.Count.ToString() + "筆；";
					this.lblTotalCounts.Text = this.lblTotalCounts.Text + "廣告色彩/篇幅 小計：";

					// 抓出 廣告色彩+廣告篇幅 的小計
					// 使用 DataSet 方法, 並指定使用的 table 名稱
					this.sqlDataAdapter4.SelectCommand.Parameters["@bkcd"].Value = Reqbkcd;
					this.sqlDataAdapter4.SelectCommand.Parameters["@yyyymm"].Value = Reqyyyymm;
					DataSet ds4 = new DataSet();
					this.sqlDataAdapter4.Fill(ds4, "c2_pub");
					DataView dv4 = ds4.Tables["c2_pub"].DefaultView;

					// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
					string rowfilterstr4 = "1=1";
					//rowfilterstr4 = rowfilterstr4 + " AND pub_bkcd='" + Reqbkcd + "'";
					//rowfilterstr4 = rowfilterstr4 + " AND pub_yyyymm='" + Reqyyyymm + "'";
					dv4.RowFilter = rowfilterstr4;

					// 檢查並輸出 最後 Row Filter 的結果
					//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
					//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

					if(dv4.Count > 0)
					{
						//this.lblClrPgsGroupCount.Text = "" + ")";
						this.lblClrPgsGroupCount.Text = "";

						string ClrName = "", PgsName = "";
						int ClrPgsCountNo = 0;
						for(int i=0; i<dv4.Count; i++)
						{
							// 抓出每一筆資料
							ClrName = dv4[i]["clr_nm"].ToString().Trim();
							PgsName = dv4[i]["pgs_nm"].ToString().Trim();
							ClrPgsCountNo = Convert.ToInt32(dv4[i]["CountNo"].ToString().Trim());
							this.lblClrPgsGroupCount.Text = this.lblClrPgsGroupCount.Text + ClrName + PgsName + ":" + ClrPgsCountNo + "筆&nbsp;&nbsp;";
							}
					}
					else
					{
						this.lblClrPgsGroupCount.Text = "<font color='Gray'>無資料</font>)";
					}
					this.lblClrPgsGroupCount.Text = this.lblClrPgsGroupCount.Text + ")";
				}
			}
		}


		// Load from DB : 特殊版面的資料
		private void LoadDataFromDB_special()
		{
			// 抓出網頁變數 bkcd & yyyymm
			string Reqbkcd = Context.Request.QueryString["bkcd"].ToString();
			string Reqyyyymm = Context.Request.QueryString["yyyymm"].Trim();

			// 抓出資料庫中的資料, 並給予別名, 以轉成 xml 型態
			// 註: RTRIM() 是 Transact-SQL 裡的 function, 將字串右方的空白去除; 但刊登頁碼不能用 RTRIM() 否則 Order by 會有錯誤
			// 註: 因頁次在資料庫中不存在, 故以 SELECT 0 AS 頁次 來代表之 (頁次之初始值設為 0)
			//string strDSN = "Server=isccom2;User ID=webuser;Password=db600;Database=mrlpub;";
			string strDSN = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			string strSelectCommand = "SELECT c2_pub.pub_pgno AS 頁次, RTRIM(c2_pub.pub_contno) AS 合約書編號, RTRIM(c2_pub.pub_pubseq) AS 落版序號, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_yyyymm) AS 刊登年月, c2_pub.pub_pgno AS 刊登頁碼, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_clrcd) AS 廣告色彩代碼, RTRIM(c2_pub.pub_pgscd) AS 廣告版面代碼, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_ltpcd) AS 廣告篇幅代碼, RTRIM(c2_pub.pub_fgfixpg) AS 固定頁次註記, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_fggot) AS 到稿註記, RTRIM(c2_pub.pub_modempno) AS 落版業務員工號, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_remark) AS 備註, RTRIM(c2_pub.pub_origbkcd) AS 舊稿書籍代碼, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_origjno) AS 舊稿期別, RTRIM(c2_pub.pub_origjbkno) AS 舊稿頁碼, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_chgbkcd) AS 改稿書籍代碼, RTRIM(c2_pub.pub_chgjno) ";
			strSelectCommand = strSelectCommand + " AS 改稿期別, RTRIM(c2_pub.pub_chgjbkno) AS 改稿頁碼, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_fgrechg) AS 改稿重出片註記, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_njtpcd) AS 新稿製法代碼, ";
			strSelectCommand = strSelectCommand + " RTRIM(mfr.mfr_inm) AS 公司名稱, 8 AS 版面2, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_bkcd) AS 書籍類別代碼, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_clr.clr_nm) AS 廣告色彩, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_ltp.ltp_nm) AS 廣告版面, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pgsize.pgs_nm) AS 廣告篇幅, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_njtp.njtp_nm) AS 新稿製法, ";
			strSelectCommand = strSelectCommand + " RTRIM(book.bk_nm) AS 舊稿書籍名稱, ";
			strSelectCommand = strSelectCommand + " RTRIM(srspn.srspn_cname) AS 落版業務員姓名, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_drafttp) AS 稿件類別代碼, ";
			strSelectCommand = strSelectCommand + " c2_lprior.lp_priorseq AS 廣告優先次序, c2_lprior.lp_bkcd AS 廣告優先次序書籍類別代碼";
			strSelectCommand = strSelectCommand + " FROM c2_pub ";
			strSelectCommand = strSelectCommand + " INNER JOIN ";
			strSelectCommand = strSelectCommand + " c2_cont ON c2_pub.pub_contno = c2_cont.cont_contno AND ";
			strSelectCommand = strSelectCommand + " c2_pub.pub_syscd = c2_cont.cont_syscd INNER JOIN ";
			strSelectCommand = strSelectCommand + " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN ";
			strSelectCommand = strSelectCommand + " c2_lprior ON c2_pub.pub_ltpcd = c2_lprior.lp_ltpcd AND ";
			strSelectCommand = strSelectCommand + " c2_pub.pub_clrcd = c2_lprior.lp_clrcd AND ";
			strSelectCommand = strSelectCommand + " c2_pub.pub_pgscd = c2_lprior.lp_pgscd AND ";
			strSelectCommand = strSelectCommand + " c2_pub.pub_bkcd = c2_lprior.lp_bkcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " c2_pgsize ON c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " c2_ltp ON c2_pub.pub_ltpcd = c2_ltp.ltp_ltpcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " c2_njtp ON c2_pub.pub_njtpcd = c2_njtp.njtp_njtpcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " book ON c2_pub.pub_origbkcd = book.bk_bkcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " srspn ON c2_cont.cont_empno = srspn.srspn_empno ";
			strSelectCommand = strSelectCommand + " WHERE (c2_pub.pub_bkcd =" + Reqbkcd + ") AND (c2_pub.pub_yyyymm =" + Reqyyyymm + ") ";
			strSelectCommand = strSelectCommand + " AND (c2_pub.pub_ltpcd <> '50') ";
			strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgclosed = '0') ";
			strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgcancel = '0') ";
			strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgtemp = '0') ";
			strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgpubed = '1') ";
			strSelectCommand = strSelectCommand + " ORDER BY 廣告優先次序, 刊登頁碼 ";
			//Response.Write("strSelectCommand= " + strSelectCommand + "<br>");

			SqlDataAdapter da = new SqlDataAdapter(strSelectCommand, strDSN);
			DataSet ds = new DataSet("root");
			da.Fill(ds, "item");
			DataView dv = ds.Tables[0].DefaultView;

			// 抓出總筆數
			int TotalCount = dv.Count;
			//Response.Write(" TotalCount = " + TotalCount + "<BR>");

			if(TotalCount>0)
			{
				// 抓出廣告版面代碼, 以算出版面２, 重排頁次時才能算對
				// 先抓出各行的 廣告版面代碼
				for(int i=0; i<TotalCount; i++)
				{
					// 此 for loop 是將 dv[i][j] 值為空者, 強迫塞入一個空白符號
					//顯示出所有的 dv[i][j] 裡的資料, 並用 \ 符號隔開區別
					// j=1; j<30 : 1~30 是根據 item 共有 29 個而來
					for (int j=1;j<30;j++)
					{
						//Response.Write(j + ":" + dv[i][j] + "\\ \n");
						if(dv[i][j].ToString().Trim() == "" || dv[i][j].ToString().Trim() == null)
							dv[i][j] = " ";
					}


					// 註: 改稿期別 若改為 改稿期別, 則會有 Error: "在必須有物件的執行個體處找到 null 值。"
					// 依不同的 稿件類別, 於畫面上不顯示(清除)不相關的資料值
					string drafttp = dv[i]["稿件類別代碼"].ToString();
					// 若稿件類別為 舊稿, 則清除 改稿及新稿之資料
					if(drafttp=="1")
					{
						dv[i]["改稿期別"] = " ";
						dv[i]["改稿頁碼"] = " ";
						dv[i]["改稿重出片註記"] = " ";
						dv[i]["新稿製法代碼"] = " ";
					}
						// 若稿件類別為 新稿, 則清除 舊稿及改稿之資料
					else if(drafttp=="2")
					{
						dv[i]["舊稿期別"] = " ";
						dv[i]["舊稿頁碼"] = " ";
						dv[i]["改稿期別"] = " ";
						dv[i]["改稿頁碼"] = " ";
						dv[i]["改稿重出片註記"] = " ";
					}
						// 若稿件類別為 改稿, 則清除 舊稿及新稿之資料
					else if(drafttp=="3")
					{
						dv[i]["舊稿期別"] = " ";
						dv[i]["舊稿頁碼"] = " ";
						dv[i]["新稿製法代碼"] = " ";
					}


					// 判別 廣告版面代碼 為 全頁(01) 或 半頁(02), 並使版面２資料與之同步, 再輸出訊息至版面２
					// 如此 doReOrder() 才可算出正確頁次
					string pgscd = dv[i]["廣告版面代碼"].ToString();

					// 判別 廣告篇幅 為 01(工材雜誌) 或 02(電材雜誌), 並輸出訊息
					if(pgscd == "01")
					{
						//Response.Write(" 版面２ = 8<BR>");
						// 注意只能將值再塞入 dv[i]["版面2"] 中, 因塞不進(抓不到) <Input id=pagelayout2> 中
						dv[i]["版面2"] = 8;
						//pagelayout2.Value = 8;
					}
					else if (pgscd == "02")
					{
						//Response.Write(" 版面２ = 4<BR>");
						// 注意只能將值再塞入 dv[i]["版面2"] 中, 因塞不進(抓不到) <Input id=pagelayout2> 中
						dv[i]["版面2"] = 4;
						//pagelayout2.Value = 4;
					}

					//					// 若廣告篇幅為 '半頁' 時, 輸出不同顏色供辨識
					//					// 因值塞入 xml 裡, 故顏色仍無法於 table 中顯示不同顏色
					//					string pgsnm = dv[i]["廣告篇幅"].ToString();
					//					if(pgsnm == "全頁")
					//					{
					//						pgsnm = pgsnm;
					//					}
					//					else if(pgsnm == "半頁")
					//					{
					//						pgsnm = "<font color='Red'>" + pgsnm + "</font>";
					//					}
					//					//Response.Write("pgsnm= " + pgsnm + "<br>");


					// 判別 固定頁次註記 為 0(否) 或 1(是), 並輸出訊息
					string fgFixPage = dv[i]["固定頁次註記"].ToString();
					if(fgFixPage == "0")
					{
						dv[i]["固定頁次註記"] = "否";
					}
					else
					{
						dv[i]["固定頁次註記"] = "是";
					}


					// 判別 到稿註記 為 0(否) 或 1(是), 並輸出訊息
					string fgGot = dv[i]["到稿註記"].ToString();
					if(fgGot == "0")
					{
						dv[i]["到稿註記"] = "否";
					}
					else
					{
						dv[i]["到稿註記"] = "是";
					}

					// 舊稿書籍名稱已抓到 bk_nm; 若舊稿書籍名稱使用 bk_nm, 改稿書籍名稱 不可同時又使用 bk_nm, 必須手動判別
					// 判別 改稿書籍代碼 為 01(工材雜誌) 或 02(電材雜誌), 並輸出訊息
					string chgbkcd = dv[i]["改稿書籍代碼"].ToString();
					if(chgbkcd == "01")
					{
						dv[i]["改稿書籍代碼"] = "工材雜誌";
					}
					else if(chgbkcd == "02")
					{
						dv[i]["改稿書籍代碼"] = "電材雜誌";
					}

				}
			}
				// 若資料庫裡無資料, 顯示其訊息
			else
			{
				this.lblDBMessage.Text = "目前資料庫中無資料!";
			}


			// 轉成 xml 型態, 填入 document.form1.hidData.Value
			//Response.Write("ds= " + ds.GetXml() + "<br>");
			hidData_special.Value = ds.GetXml();
			//Response.Write("hidData_special.Value= " + hidData_special.Value + "<br>");
		}


		// Load from DB : 一般版面的資料
		private void LoadDataFromDB()
		{
			// 抓出網頁變數 bkcd & yyyymm
			string Reqbkcd = Context.Request.QueryString["bkcd"].ToString();
			string Reqyyyymm = Context.Request.QueryString["yyyymm"].Trim();

			// 抓出資料庫中的資料, 並給予別名, 以轉成 xml 型態
			// 註: RTRIM() 是 Transact-SQL 裡的 function, 將字串右方的空白去除; 但刊登頁碼不能用 RTRIM() 否則 Order by 會有錯誤
			// 註: 因頁次在資料庫中不存在, 故以 SELECT 0 AS 頁次 來代表之 (頁次之初始值設為 0)
			//string strDSN = "Server=isccom2;User ID=webuser;Password=db600;Database=mrlpub;";
			string strDSN = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			string strSelectCommand = "SELECT 0 AS 頁次, RTRIM(c2_pub.pub_contno) AS 合約書編號, RTRIM(c2_pub.pub_pubseq) AS 落版序號, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_yyyymm) AS 刊登年月, c2_pub.pub_pgno AS 刊登頁碼, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_clrcd) AS 廣告色彩代碼, RTRIM(c2_pub.pub_pgscd) AS 廣告版面代碼, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_ltpcd) AS 廣告篇幅代碼, RTRIM(c2_pub.pub_fgfixpg) AS 固定頁次註記, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_fggot) AS 到稿註記, RTRIM(c2_pub.pub_modempno) AS 落版業務員工號, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_remark) AS 備註, RTRIM(c2_pub.pub_origbkcd) AS 舊稿書籍代碼, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_origjno) AS 舊稿期別, RTRIM(c2_pub.pub_origjbkno) AS 舊稿頁碼, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_chgbkcd) AS 改稿書籍代碼, RTRIM(c2_pub.pub_chgjno) ";
			strSelectCommand = strSelectCommand + " AS 改稿期別, RTRIM(c2_pub.pub_chgjbkno) AS 改稿頁碼, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_fgrechg) AS 改稿重出片註記, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_njtpcd) AS 新稿製法代碼, ";
			strSelectCommand = strSelectCommand + " RTRIM(mfr.mfr_inm) AS 公司名稱, 8 AS 版面2, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_bkcd) AS 書籍類別代碼, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_clr.clr_nm) AS 廣告色彩, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_ltp.ltp_nm) AS 廣告版面, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pgsize.pgs_nm) AS 廣告篇幅, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_njtp.njtp_nm) AS 新稿製法, ";
			strSelectCommand = strSelectCommand + " RTRIM(book.bk_nm) AS 舊稿書籍名稱, ";
			strSelectCommand = strSelectCommand + " RTRIM(srspn.srspn_cname) AS 落版業務員姓名, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_drafttp) AS 稿件類別代碼, ";
			strSelectCommand = strSelectCommand + " c2_lprior.lp_priorseq AS 廣告優先次序, c2_lprior.lp_bkcd AS 廣告優先次序書籍類別代碼";
			strSelectCommand = strSelectCommand + " FROM c2_pub ";
			strSelectCommand = strSelectCommand + " INNER JOIN ";
			strSelectCommand = strSelectCommand + " c2_cont ON c2_pub.pub_contno = c2_cont.cont_contno AND ";
			strSelectCommand = strSelectCommand + " c2_pub.pub_syscd = c2_cont.cont_syscd INNER JOIN ";
			strSelectCommand = strSelectCommand + " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN ";
			strSelectCommand = strSelectCommand + " c2_lprior ON c2_pub.pub_ltpcd = c2_lprior.lp_ltpcd AND ";
			strSelectCommand = strSelectCommand + " c2_pub.pub_clrcd = c2_lprior.lp_clrcd AND ";
			strSelectCommand = strSelectCommand + " c2_pub.pub_pgscd = c2_lprior.lp_pgscd AND ";
			strSelectCommand = strSelectCommand + " c2_pub.pub_bkcd = c2_lprior.lp_bkcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " c2_pgsize ON c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " c2_ltp ON c2_pub.pub_ltpcd = c2_ltp.ltp_ltpcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " c2_njtp ON c2_pub.pub_njtpcd = c2_njtp.njtp_njtpcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " book ON c2_pub.pub_origbkcd = book.bk_bkcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " srspn ON c2_cont.cont_empno = srspn.srspn_empno ";
			strSelectCommand = strSelectCommand + " WHERE (c2_pub.pub_bkcd =" + Reqbkcd + ") AND (c2_pub.pub_yyyymm =" + Reqyyyymm + ") ";
			strSelectCommand = strSelectCommand + " AND (c2_pub.pub_ltpcd = '50') ";
			strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgclosed = '0') ";
			strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgcancel = '0') ";
			strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgtemp = '0') ";
			strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgpubed = '1') ";
			strSelectCommand = strSelectCommand + " ORDER BY 廣告優先次序, 刊登頁碼, 合約書編號, 落版序號 ";
			//Response.Write("strSelectCommand= " + strSelectCommand + "<br>");

			SqlDataAdapter da = new SqlDataAdapter(strSelectCommand, strDSN);
			DataSet ds = new DataSet("root");
			da.Fill(ds, "item");
			DataView dv = ds.Tables[0].DefaultView;

			// 抓出總筆數
			int TotalCount = dv.Count;
			//Response.Write(" TotalCount = " + TotalCount + "<BR>");

			if(TotalCount>0)
			{
				// 抓出廣告版面代碼, 以算出版面２, 重排頁次時才能算對
				// 先抓出各行的 廣告版面代碼
				for(int i=0; i<TotalCount; i++)
				{
					// 此 for loop 是將 dv[i][j] 值為空者, 強迫塞入一個空白符號
					//顯示出所有的 dv[i][j] 裡的資料, 並用 \ 符號隔開區別
					// j=1; j<30 : 1~30 是根據 item 共有 29 個而來
					for (int j=1;j<30;j++)
					{
						//Response.Write(j + ":" + dv[i][j] + "\\ \n");
						if(dv[i][j].ToString().Trim() == "" || dv[i][j].ToString().Trim() == null)
							dv[i][j] = " ";
					}


					// 註: 改稿期別 若改為 改稿期別, 則會有 Error: "在必須有物件的執行個體處找到 null 值。"
					// 依不同的 稿件類別, 於畫面上不顯示(清除)不相關的資料值
					string drafttp = dv[i]["稿件類別代碼"].ToString();
					// 若稿件類別為 舊稿, 則清除 改稿及新稿之資料
					if(drafttp=="1")
					{
						dv[i]["改稿期別"] = " ";
						dv[i]["改稿頁碼"] = " ";
						dv[i]["改稿重出片註記"] = " ";
						dv[i]["新稿製法代碼"] = " ";
					}
						// 若稿件類別為 新稿, 則清除 舊稿及改稿之資料
					else if(drafttp=="2")
					{
						dv[i]["舊稿期別"] = " ";
						dv[i]["舊稿頁碼"] = " ";
						dv[i]["改稿期別"] = " ";
						dv[i]["改稿頁碼"] = " ";
						dv[i]["改稿重出片註記"] = " ";
					}
						// 若稿件類別為 改稿, 則清除 舊稿及新稿之資料
					else if(drafttp=="3")
					{
						dv[i]["舊稿期別"] = " ";
						dv[i]["舊稿頁碼"] = " ";
						dv[i]["新稿製法代碼"] = " ";
					}


					// 判別 廣告版面代碼 為 全頁(01) 或 半頁(02), 並使版面２資料與之同步, 再輸出訊息至版面２
					// 如此 doReOrder() 才可算出正確頁次
					string pgscd = dv[i]["廣告版面代碼"].ToString();

					// 判別 廣告篇幅 為 01(工材雜誌) 或 02(電材雜誌), 並輸出訊息
					if(pgscd == "01")
					{
						//Response.Write(" 版面２ = 8<BR>");
						// 注意只能將值再塞入 dv[i]["版面2"] 中, 因塞不進(抓不到) <Input id=pagelayout2> 中
						dv[i]["版面2"] = 8;
						//pagelayout2.Value = 8;
					}
					else if (pgscd == "02")
					{
						//Response.Write(" 版面２ = 4<BR>");
						// 注意只能將值再塞入 dv[i]["版面2"] 中, 因塞不進(抓不到) <Input id=pagelayout2> 中
						dv[i]["版面2"] = 4;
						//pagelayout2.Value = 4;
					}

					// 若廣告篇幅為 '半頁' 時, 輸出不同顏色供辨識
					// 因值塞入 xml 裡, 故顏色仍無法於 table 中顯示不同顏色
//					string pgsnm = dv[i]["廣告篇幅"].ToString();
//					if(pgsnm == "全頁")
//					{
//						pgsnm = pgsnm;
//					}
//					else if(pgsnm == "半頁")
//					{
//						pgsnm = "<font color='Red'>" + pgsnm + "</font>";
//					}
//					//Response.Write("pgsnm= " + pgsnm + "<br>");


					// 判別 固定頁次註記 為 0(否) 或 1(是), 並輸出訊息
					string fgFixPage = dv[i]["固定頁次註記"].ToString();
					if(fgFixPage == "0")
					{
						dv[i]["固定頁次註記"] = "否";
					}
					else
					{
						dv[i]["固定頁次註記"] = "是";
					}


					// 判別 到稿註記 為 0(否) 或 1(是), 並輸出訊息
					string fgGot = dv[i]["到稿註記"].ToString();
					if(fgGot == "0")
					{
						dv[i]["到稿註記"] = "否";
					}
					else
					{
						dv[i]["到稿註記"] = "是";
					}

					// 舊稿書籍名稱已抓到 bk_nm; 若舊稿書籍名稱使用 bk_nm, 改稿書籍名稱 不可同時又使用 bk_nm, 必須手動判別
					// 判別 改稿書籍代碼 為 01(工材雜誌) 或 02(電材雜誌), 並輸出訊息
					string chgbkcd = dv[i]["改稿書籍代碼"].ToString();
					if(chgbkcd == "01")
					{
						dv[i]["改稿書籍代碼"] = "工材雜誌";
					}
					else if(chgbkcd == "02")
					{
						dv[i]["改稿書籍代碼"] = "電材雜誌";
					}

				}
			}
			// 若資料庫裡無資料, 顯示其訊息
			else
			{
				this.lblDBMessage.Text = "目前資料庫中無資料!";
			}


			// 轉成 xml 型態, 填入 document.form1.hidData.Value
			//Response.Write("ds= " + ds.GetXml() + "<br>");
			hidData.Value = ds.GetXml();
			//Response.Write("hidData.Value= " + hidData.Value + "<br>");
		}



		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pgno", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("pg_bkcd", "pg_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pg_startpgno", "pg_startpgno")})});
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = "SELECT pg_bkcd, pg_startpgno FROM dbo.c2_pgno";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			//
			// sqlDataAdapter2
			//
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("PageNo", "PageNo"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgno", "pub_pgno"),
																																																				new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgfixpg", "pub_fgfixpg"),
																																																				new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																				new System.Data.Common.DataColumnMapping("pub_modempno", "pub_modempno"),
																																																				new System.Data.Common.DataColumnMapping("pub_remark", "pub_remark"),
																																																				new System.Data.Common.DataColumnMapping("pub_origbkcd", "pub_origbkcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_origjno", "pub_origjno"),
																																																				new System.Data.Common.DataColumnMapping("pub_origjbkno", "pub_origjbkno"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgbkcd", "pub_chgbkcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgjno", "pub_chgjno"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgjbkno", "pub_chgjbkno"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																				new System.Data.Common.DataColumnMapping("pub_njtpcd", "pub_njtpcd"),
																																																				new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				new System.Data.Common.DataColumnMapping("layout2", "layout2"),
																																																				new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																				new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																				new System.Data.Common.DataColumnMapping("njtp_nm", "njtp_nm"),
																																																				new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno1", "pub_contno1"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq1", "pub_pubseq1"),
																																																				new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm1", "pub_yyyymm1"),
																																																				new System.Data.Common.DataColumnMapping("lp_priorseq", "lp_priorseq"),
																																																				new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed")})});
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("bk_bkid", "bk_bkid"),
																																																			  new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT bk_bkid, bk_bkcd, RTRIM(bk_nm) AS bk_nm FROM dbo.book";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter4
			//
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																				new System.Data.Common.DataColumnMapping("CountNo", "CountNo"),
																																																				new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed")})});
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT dbo.c2_pub.pub_pgno AS PageNo, RTRIM(dbo.c2_pub.pub_contno) AS pub_contno," +
				" RTRIM(dbo.c2_pub.pub_pubseq) AS pub_pubseq, RTRIM(dbo.c2_pub.pub_yyyymm) AS pub" +
				"_yyyymm, dbo.c2_pub.pub_pgno AS pub_pgno, RTRIM(dbo.c2_pub.pub_ltpcd) AS pub_ltp" +
				"cd, RTRIM(dbo.c2_pub.pub_clrcd) AS pub_clrcd, RTRIM(dbo.c2_pub.pub_pgscd) AS pub" +
				"_pgscd, RTRIM(dbo.c2_pub.pub_fgfixpg) AS pub_fgfixpg, RTRIM(dbo.c2_pub.pub_fggot" +
				") AS pub_fggot, RTRIM(dbo.c2_pub.pub_modempno) AS pub_modempno, RTRIM(dbo.c2_pub" +
				".pub_remark) AS pub_remark, RTRIM(dbo.c2_pub.pub_origbkcd) AS pub_origbkcd, RTRI" +
				"M(dbo.c2_pub.pub_origjno) AS pub_origjno, RTRIM(dbo.c2_pub.pub_origjbkno) AS pub" +
				"_origjbkno, RTRIM(dbo.c2_pub.pub_chgbkcd) AS pub_chgbkcd, RTRIM(dbo.c2_pub.pub_c" +
				"hgjno) AS pub_chgjno, RTRIM(dbo.c2_pub.pub_chgjbkno) AS pub_chgjbkno, RTRIM(dbo." +
				"c2_pub.pub_fgrechg) AS pub_fgrechg, RTRIM(dbo.c2_pub.pub_njtpcd) AS pub_njtpcd, " +
				"RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, 8 AS layout2, RTRIM(dbo.c2_pub.pub_bkcd) AS p" +
				"ub_bkcd, RTRIM(dbo.c2_clr.clr_nm) AS clr_nm, RTRIM(dbo.c2_ltp.ltp_nm) AS ltp_nm," +
				" RTRIM(dbo.c2_pgsize.pgs_nm) AS pgs_nm, RTRIM(dbo.c2_njtp.njtp_nm) AS njtp_nm, R" +
				"TRIM(dbo.book.bk_nm) AS bk_nm, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname, RTRI" +
				"M(dbo.c2_pub.pub_drafttp) AS pub_drafttp, dbo.c2_pub.pub_contno AS pub_contno, d" +
				"bo.c2_pub.pub_pubseq AS pub_pubseq, dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_yyyymm " +
				"AS pub_yyyymm, dbo.c2_lprior.lp_priorseq, dbo.c2_lprior.lp_bkcd, dbo.c2_cont.con" +
				"t_fgclosed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont" +
				"_fgpubed, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd FROM dbo.c2_pub INNER " +
				"JOIN dbo.c2_cont ON dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno AND dbo.c2_p" +
				"ub.pub_syscd = dbo.c2_cont.cont_syscd INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfr" +
				"no = dbo.mfr.mfr_mfrno INNER JOIN dbo.c2_lprior ON dbo.c2_pub.pub_ltpcd = dbo.c2" +
				"_lprior.lp_ltpcd AND dbo.c2_pub.pub_clrcd = dbo.c2_lprior.lp_clrcd AND dbo.c2_pu" +
				"b.pub_pgscd = dbo.c2_lprior.lp_pgscd AND dbo.c2_pub.pub_bkcd = dbo.c2_lprior.lp_" +
				"bkcd LEFT OUTER JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd L" +
				"EFT OUTER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd L" +
				"EFT OUTER JOIN dbo.c2_ltp ON dbo.c2_pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd LEFT OU" +
				"TER JOIN dbo.c2_njtp ON dbo.c2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd LEFT OUT" +
				"ER JOIN dbo.book ON dbo.c2_pub.pub_origbkcd = dbo.book.bk_bkcd LEFT OUTER JOIN d" +
				"bo.srspn ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno WHERE (dbo.c2_cont.co" +
				"nt_fgclosed = \'0\') AND (dbo.c2_cont.cont_fgcancel = \'0\') AND (dbo.c2_cont.cont_f" +
				"gtemp = \'0\') AND (dbo.c2_cont.cont_fgpubed = \'1\') ORDER BY dbo.c2_lprior.lp_prio" +
				"rseq, dbo.c2_pub.pub_pgno, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_" +
				"pub.pub_pubseq";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand4
			//
			this.sqlSelectCommand4.CommandText = @"SELECT dbo.c2_pub.pub_clrcd, dbo.c2_pub.pub_pgscd, COUNT(dbo.c2_pub.pub_contno) AS CountNo, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed FROM dbo.c2_pub INNER JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd INNER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd INNER JOIN dbo.c2_cont ON dbo.c2_pub.pub_syscd = dbo.c2_cont.cont_syscd AND dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno WHERE (dbo.c2_pub.pub_bkcd = @bkcd) AND (dbo.c2_pub.pub_yyyymm = @yyyymm) AND (dbo.c2_cont.cont_fgclosed = '0') AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_cont.cont_fgpubed = '1') GROUP BY dbo.c2_pub.pub_clrcd, dbo.c2_pub.pub_pgscd, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			this.sqlSelectCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "pub_bkcd"));
			this.sqlSelectCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, "pub_yyyymm"));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



	}
}
