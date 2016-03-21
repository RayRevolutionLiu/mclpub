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

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adpub_act2.
	/// </summary>
	public class adpub_act2 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblSearchKeyword;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected System.Web.UI.WebControls.Label lblDBMessage;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidData;
	
		public adpub_act2()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				// 抓出網頁變數 bkcd & yyyymm, 將之轉成文字顯示之
				InitialMyData();
				

				//Load Data From DB, 轉成 xml 型態, 再填入 document.form1.hidData.Value
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
		

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
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
			this.sqlSelectCommand1.CommandText = "SELECT bk_bkid, bk_bkcd, bk_nm FROM book";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
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
		}
		
		
		private void LoadDataFromDB()
		{
			// 抓出網頁變數 bkcd & yyyymm
			string Reqbkcd = Context.Request.QueryString["bkcd"].ToString();
			string Reqyyyymm = Context.Request.QueryString["yyyymm"].Trim();
			
			// 抓出資料庫中的資料, 並給予別名, 以轉成 xml 型態
			// 註: RTRIM() 是 Transact-SQL 裡的 function, 將字串右方的空白去除; 但刊登頁碼不能用 RTRIM() 否則 Order by 會有錯誤
			// 註: 因頁次在資料庫中不存在, 故以 SELECT 0 AS 頁次 來代表之 (頁次之初始值設為 0)
			string strDSN = "Server=isccom1;User ID=webuser;Password=db600;Database=mrlpub;";
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
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_drafttp) AS 稿件類別代碼 ";
			strSelectCommand = strSelectCommand + " FROM c2_pub ";
			strSelectCommand = strSelectCommand + " INNER JOIN c2_cont ON c2_pub.pub_contno = c2_cont.cont_contno ";
			strSelectCommand = strSelectCommand + " AND c2_pub.pub_syscd = c2_cont.cont_syscd ";
			strSelectCommand = strSelectCommand + " INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno ";
			strSelectCommand = strSelectCommand + " LEFT OUTER JOIN c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd ";
			strSelectCommand = strSelectCommand + " LEFT OUTER JOIN c2_pgsize ON c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd ";
			strSelectCommand = strSelectCommand + " LEFT OUTER JOIN c2_ltp ON c2_pub.pub_ltpcd = c2_ltp.ltp_ltpcd ";
			strSelectCommand = strSelectCommand + " LEFT OUTER JOIN c2_njtp ON c2_pub.pub_njtpcd = c2_njtp.njtp_njtpcd ";
			strSelectCommand = strSelectCommand + " LEFT OUTER JOIN book ON c2_pub.pub_origbkcd = book.bk_bkcd ";
			strSelectCommand = strSelectCommand + " LEFT OUTER JOIN srspn ON c2_cont.cont_empno = srspn.srspn_empno ";
			strSelectCommand = strSelectCommand + " WHERE (c2_pub.pub_bkcd =" + Reqbkcd + ") AND (c2_pub.pub_yyyymm LIKE '%" + Reqyyyymm + "%') ";
			strSelectCommand = strSelectCommand + " ORDER BY 刊登頁碼, 合約書編號, 刊登年月 DESC, 落版序號 ";
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
			hidData.Value = ds.GetXml();
			//Response.Write("hidData.Value= " + hidData.Value + "<br>");

		}

	}
}
