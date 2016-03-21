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
	/// Summary description for adpub_main12.
	/// </summary>
	public class adpub_main12 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblCompanyName;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblMfrRespName;
		protected System.Web.UI.WebControls.Label lblMfrRespJobTitle;
		protected System.Web.UI.WebControls.Label lblMfrTel;
		protected System.Web.UI.WebControls.Label lblMfrFax;
		protected System.Web.UI.WebControls.Label lblCustName;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Web.UI.WebControls.Label lblSignDate;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.DropDownList ddlContType;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Web.UI.WebControls.TextBox tbxStartDate;
		protected System.Web.UI.WebControls.TextBox tbxEndDate;
		protected System.Web.UI.WebControls.Label lblCountDateMonths;
		protected System.Web.UI.WebControls.Label lblEmpNo;
		protected System.Web.UI.WebControls.RadioButtonList rblfgPayOnce;
		protected System.Web.UI.WebControls.RadioButtonList rblfgITRI;
		protected System.Web.UI.WebControls.RadioButtonList rblfgFixPage;
		protected System.Web.UI.WebControls.Label lblModDate;
		protected System.Web.UI.WebControls.Label lblOldContNo;
		protected System.Web.UI.WebControls.Label lblPubSeq;
		protected System.Web.UI.WebControls.RadioButtonList rblInvCode;
		protected System.Web.UI.WebControls.RadioButtonList rblTaxType;
		protected System.Web.UI.WebControls.TextBox tbxTotalJTime;
		protected System.Web.UI.WebControls.TextBox tbxMadeJTime;
		protected System.Web.UI.WebControls.TextBox tbxRestJTime;
		protected System.Web.UI.WebControls.TextBox tbxTotalTime;
		protected System.Web.UI.WebControls.TextBox tbxPubTime;
		protected System.Web.UI.WebControls.TextBox tbxRestTime;
		protected System.Web.UI.WebControls.TextBox tbxTotalAmt;
		protected System.Web.UI.WebControls.TextBox tbxPaidAmt;
		protected System.Web.UI.WebControls.TextBox tbxRestAmt;
		protected System.Web.UI.WebControls.TextBox tbxChangeJTime;
		protected System.Web.UI.WebControls.TextBox tbxFreeTime;
		protected System.Web.UI.WebControls.TextBox tbxDiscount;
		protected System.Web.UI.WebControls.TextBox tbxColorTime;
		protected System.Web.UI.WebControls.TextBox tbxMenoTime;
		protected System.Web.UI.WebControls.TextBox tbxGetColorTime;
		protected System.Web.UI.WebControls.TextBox tbxFreeBookCount;
		protected System.Web.UI.WebControls.TextBox tbxAuName;
		protected System.Web.UI.WebControls.TextBox tbxAuTel;
		protected System.Web.UI.WebControls.TextBox tbxAuFax;
		protected System.Web.UI.WebControls.TextBox tbxAuCell;
		protected System.Web.UI.WebControls.TextBox tbxAuEmail;
		protected System.Web.UI.WebControls.ImageButton imbPubAdd;
		protected System.Web.UI.WebControls.ImageButton imbPubDelete;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlColorCode;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlPageSizeCode;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlLTypeCode;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.RadioButtonList rblfgClosed;
	
		public adpub_main12()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				//顯示 [廠商及客戶資料區] 裡的所有資料
				//藉由前一網頁傳來的變數值字串 contno
				string contno=Context.Request.QueryString["contno"];
				lblContNo.Text = contno;
				GetMfrCust();
			
				// 呼叫 Function InitialMyData() 自資料庫抓出資料
				//InitialMyData();

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
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("pub_pubid", "pub_pubid"),
																																																				 new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pgno", "pub_pgno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_adamt", "pub_adamt"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgamt", "pub_chgamt"),
																																																				 new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																				 new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origjno", "pub_origjno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origjbkno", "pub_origjbkno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgjno", "pub_chgjno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																				 new System.Data.Common.DataColumnMapping("pub_njtpcd", "pub_njtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_projno", "pub_projno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_costctr", "pub_costctr"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fginved", "pub_fginved"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fginvself", "pub_fginvself"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pno", "pub_pno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_remark", "pub_remark"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fgfixpg", "pub_fgfixpg"),
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
																																																				 new System.Data.Common.DataColumnMapping("cont_aufax", "cont_aufax"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aucell", "cont_aucell"),
																																																				 new System.Data.Common.DataColumnMapping("cont_auemail", "cont_auemail"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_madejtm", "cont_madejtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restjtm", "cont_restjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_disc", "cont_disc"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freetm", "cont_freetm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubtm", "cont_pubtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_resttm", "cont_resttm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_chgjtm", "cont_chgjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubamt", "cont_pubamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_chgamt", "cont_chgamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_clrtm", "cont_clrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_menotm", "cont_menotm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_getclrtm", "cont_getclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_oldcontno", "cont_oldcontno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_moddate", "cont_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_tel", "mfr_tel"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_fax", "mfr_fax"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_regdate", "mfr_regdate"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_xmldata", "cont_xmldata"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origbkcd", "pub_origbkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgbkcd", "pub_chgbkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgjbkno", "pub_chgjbkno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_moddate", "pub_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("pub_modempno", "pub_modempno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_modempno", "cont_modempno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_imseq", "pub_imseq")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT c2_pub.pub_pubid, c2_pub.pub_syscd, c2_pub.pub_contno, c2_pub.pub_yyyymm, " +
				"c2_pub.pub_pubseq, c2_pub.pub_pgno, c2_pub.pub_ltpcd, c2_pub.pub_clrcd, c2_pub.p" +
				"ub_pgscd, c2_pub.pub_adamt, c2_pub.pub_chgamt, c2_pub.pub_drafttp, c2_pub.pub_bk" +
				"cd, c2_pub.pub_origjno, c2_pub.pub_origjbkno, c2_pub.pub_chgjno, c2_pub.pub_fgre" +
				"chg, c2_pub.pub_fggot, c2_pub.pub_njtpcd, c2_pub.pub_projno, c2_pub.pub_costctr," +
				" c2_pub.pub_fginved, c2_pub.pub_fginvself, c2_pub.pub_pno, c2_pub.pub_remark, c2" +
				"_pub.pub_fgfixpg, c2_cont.cont_contid, c2_cont.cont_syscd, c2_cont.cont_contno, " +
				"c2_cont.cont_conttp, c2_cont.cont_bkcd, c2_cont.cont_signdate, c2_cont.cont_empn" +
				"o, c2_cont.cont_mfrno, c2_cont.cont_aunm, c2_cont.cont_autel, c2_cont.cont_aufax" +
				", c2_cont.cont_aucell, c2_cont.cont_auemail, c2_cont.cont_sdate, c2_cont.cont_ed" +
				"ate, c2_cont.cont_totjtm, c2_cont.cont_madejtm, c2_cont.cont_restjtm, c2_cont.co" +
				"nt_disc, c2_cont.cont_freetm, c2_cont.cont_fgclosed, c2_cont.cont_tottm, c2_cont" +
				".cont_pubtm, c2_cont.cont_resttm, c2_cont.cont_chgjtm, c2_cont.cont_custno, c2_c" +
				"ont.cont_totamt, c2_cont.cont_pubamt, c2_cont.cont_chgamt, c2_cont.cont_paidamt," +
				" c2_cont.cont_restamt, c2_cont.cont_clrtm, c2_cont.cont_menotm, c2_cont.cont_get" +
				"clrtm, c2_cont.cont_oldcontno, c2_cont.cont_moddate, c2_cont.cont_fgpayonce, mfr" +
				".mfr_mfrid, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_iaddr, mfr.mfr_izip, mfr.mfr_res" +
				"pnm, mfr.mfr_respjbti, mfr.mfr_tel, mfr.mfr_fax, mfr.mfr_regdate, cust.cust_cust" +
				"id, cust.cust_custno, cust.cust_nm, cust.cust_jbti, cust.cust_tel, c2_cont.cont_" +
				"xmldata, c2_pub.pub_origbkcd, c2_pub.pub_chgbkcd, c2_pub.pub_chgjbkno, c2_pub.pu" +
				"b_moddate, c2_pub.pub_modempno, c2_cont.cont_modempno, c2_pub.pub_imseq FROM c2_" +
				"cont INNER JOIN c2_pub ON c2_cont.cont_contno = c2_pub.pub_contno INNER JOIN cus" +
				"t ON c2_cont.cont_custno = cust.cust_custno INNER JOIN mfr ON c2_cont.cont_mfrno" +
				" = mfr.mfr_mfrno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		private void InitialMyData()
		{
			//顯示 [廠商及客戶資料區] 裡的所有資料
			//藉由前一網頁傳來的變數值字串 contno
			string contno=Context.Request.QueryString["contno"];
			// 若開啟下一行, 程式會產生 Error
			//this.lblContNo.Text = contno;
			

			// 自資料庫中抓出整個合約書的資料
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_cont");
			DataView dv1 = ds1.Tables["c2_cont"].DefaultView;
			// 給 SQL 過濾條件 (填自 where 之後的條件)
			dv1.RowFilter = "cont_contno=" + contno;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
			
			//防呆處理: 若無資料時, 則給錯誤訊息
			//if (dv1.Count < 1)  ...
			// 若找到資料, 則在 Server Web Control 顯示之


			// 抓 合約內容區 的 DB 值, for lbl & tbx
			// 原本資料值為: 20011211, 寫法為: 如 this.tbxStartDate.Text = dv1[0]["cont_sdate"].ToString();
			// 因資料值為 char(8), 故要加上 "/" 符號來隔開 年月日
			// 才會將 原本資料值為: 20011211, 顯示為 2001/12/11 
			string SignDateYear = dv1[0]["cont_signdate"].ToString().Substring(0, 4).ToString();
			string SignDateMonth = dv1[0]["cont_signdate"].ToString().Substring(4, 2).ToString();
			string SignDateDay = dv1[0]["cont_signdate"].ToString().Substring(6, 2).ToString();
			string SignDate = SignDateYear + "/" + SignDateMonth + "/" + SignDateDay;
			//Response.Write("SignDate= "+ SignDate + "<BR>");
			this.lblSignDate.Text = SignDate;

			string StartDateYear = dv1[0]["cont_sdate"].ToString().Substring(0, 4).ToString();
			string StartDateMonth = dv1[0]["cont_sdate"].ToString().Substring(4, 2).ToString();
			string StartDateDay = dv1[0]["cont_sdate"].ToString().Substring(6, 2).ToString();
			string StartDate = StartDateYear + "/" + StartDateMonth + "/" + StartDateDay;
			//Response.Write("StartDate= "+ StartDate + "<BR>");
			this.tbxStartDate.Text = StartDate;

			string EndDateYear = dv1[0]["cont_edate"].ToString().Substring(0, 4).ToString();
			string EndDateMonth = dv1[0]["cont_edate"].ToString().Substring(4, 2).ToString();
			string EndDateDay = dv1[0]["cont_edate"].ToString().Substring(6, 2).ToString();
			string EndDate = EndDateYear + "/" + EndDateMonth + "/" + EndDateDay;
			//Response.Write("EndDate= "+ EndDate + "<BR>");
			this.tbxEndDate.Text = EndDate;

			this.lblEmpNo.Text = dv1[0]["cont_empno"].ToString();
			// 將 DB值 轉為另一table 的 DB 值
			//if lblEmpNo.Text = "800443" 
			//this.lblEmpNo.Text = "康靜怡";
			//else
			//this.lblEmpNo.Text = "...";

			this.lblModDate.Text = dv1[0]["cont_moddate"].ToString();
			this.lblOldContNo.Text = dv1[0]["cont_oldcontno"].ToString();
			//			if (this.lblOldContNo.Text.Trim() = "")
			//				{
			//					this.lblOldContNo.Text = "無";
			//				}


			// 抓 刊登細節區 的 DB 值, for lbl & tbx
			this.tbxTotalJTime.Text = dv1[0]["cont_totjtm"].ToString();
			this.tbxMadeJTime.Text = dv1[0]["cont_madejtm"].ToString();
			this.tbxRestJTime.Text = dv1[0]["cont_restjtm"].ToString();
			this.tbxTotalTime.Text = dv1[0]["cont_tottm"].ToString();
			this.tbxPubTime.Text = dv1[0]["cont_pubtm"].ToString();
			this.tbxRestTime.Text = dv1[0]["cont_resttm"].ToString();
			this.tbxTotalAmt.Text = dv1[0]["cont_totamt"].ToString();
			this.tbxPaidAmt.Text = dv1[0]["cont_paidamt"].ToString();
			this.tbxRestAmt.Text = dv1[0]["cont_restamt"].ToString();
			this.tbxChangeJTime.Text = dv1[0]["cont_chgjtm"].ToString();
			this.tbxFreeTime.Text = dv1[0]["cont_freetm"].ToString();
			this.tbxDiscount.Text = dv1[0]["cont_disc"].ToString();
			this.tbxColorTime.Text = dv1[0]["cont_clrtm"].ToString();
			this.tbxMenoTime.Text = dv1[0]["cont_menotm"].ToString();
			this.tbxGetColorTime.Text = dv1[0]["cont_getclrtm"].ToString();
			this.tbxFreeBookCount.Text = dv1[0]["cont_freebkcnt"].ToString();


			// 抓 廣告聯絡人資料區 的 DB 值, for lbl & tbx
			this.tbxAuName.Text = dv1[0]["cont_aunm"].ToString();
			this.tbxAuTel.Text = dv1[0]["cont_autel"].ToString();
			this.tbxAuFax.Text = dv1[0]["cont_aufax"].ToString();
			this.tbxAuCell.Text = dv1[0]["cont_aucell"].ToString();
			this.tbxAuEmail.Text = dv1[0]["cont_auemail"].ToString();


			// 抓 DropDownload List 的 DB 值, 但其顯示文字是固定死的
			this.ddlContType.SelectedIndex = int.Parse(dv1[0]["cont_conttp"].ToString());
			this.ddlBookCode.SelectedIndex = int.Parse(dv1[0]["cont_bkcd"].ToString());
			
			// 抓 RadioButtonList 的 DB 值: 二選一, 但其顯示文字是固定死的
			// 因 rblfgPayOnce 的 Item 順序(0為是, 1為否) 與顯示值不同(應該是1為是, 0為否); 故要將值 Mod(%) 2 處理
			// 也可寫 switch case 來處理
			this.rblfgPayOnce.SelectedIndex = (int.Parse(dv1[0]["cont_fgpayonce"].ToString())+1) % 2;
			this.rblfgClosed.SelectedIndex = (int.Parse(dv1[0]["cont_fgclosed"].ToString())+1) % 2;

			// 處理特別情況: 若 cont_fgitri 值為 6 或7, 則顯示為 "是"; 其他顯示為否
			this.rblfgITRI.SelectedIndex = (int.Parse(dv1[0]["cont_fgitri"].ToString())+1) % 2;
			int fgITRI= int.Parse(dv1[0]["cont_fgitri"].ToString());
			//Response.Write("fgITRI's DB value= " + fgITRI);
			// 若 rblfgITRI = 6 or 7 則顯示: 是; 其他為否
			//			if (fgITRI=6);
			//				{
			//				this.rblfgITRI.SelectedIndex = 1;		
			//				this.rblfgITRI.SelectedItem.Value = 1;
			//				}
			
			// 抓 RadioButtonList 的 DB 值: 多選一, 但其顯示文字是固定死的
			// 因 rblfgPayOnce 的 Item 順序(0為是, 1為否) 與顯示值不同(應該是1為是, 0為否); 故要將值 - 1 處理
			this.rblInvCode.SelectedIndex = int.Parse(dv1[0]["cont_invcd"].ToString())-1;
			this.rblTaxType.SelectedIndex = int.Parse(dv1[0]["cont_taxtp"].ToString())-1;
			
			// 測試資料是否有正確抓出
			//Response.Write(this.lblSignDate.Text.ToString());
			//Response.Write("cont_fgpayonce=" + dv1[0]["cont_fgpayonce"].ToString() + "<br>");
			//Response.Write("cont_fgfixpg=" + dv1[0]["cont_fgfixpg"].ToString()+ "<br>");
			//Response.Write("cont_fgclosed=" + dv1[0]["cont_fgclosed"].ToString()+ "<br>");
			//Response.Write("cont_invcd=" + dv1[0]["cont_invcd"].ToString() + "<br>");
			//Response.Write("cont_taxtp=" + dv1[0]["cont_taxtp"].ToString() + "<br>");

			// 抓 雜誌收件人區 的 DB 值

		}


		private void GetMfrCust()
		{
			//顯示 [廠商及客戶資料區] 裡的所有資料
			//藉由前一網頁傳來的變數值字串 contno
			string contno=Context.Request.QueryString["contno"];
			lblContNo.Text = contno;
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_cont");
			DataView dv1 = ds1.Tables["c2_cont"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			dv1.RowFilter = "cont_contno=" + lblContNo.Text;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			// 防呆處理: 若無資料時, 則給錯誤訊息
			//if (dv1.Count < 1)  ...
			// 若找到資料, 則在 Server Web Control 顯示之


			// 藉 c2_cont table 的 cont_mfrno 及 cont_custno 抓廠商及客戶資料
			this.lblMfrNo.Text = dv1[0]["cont_mfrno"].ToString();
			this.lblCustNo.Text = dv1[0]["cont_custno"].ToString();
			this.lblCustName.Text = dv1[0]["cust_nm"].ToString();
			this.lblCompanyName.Text = dv1[0][9].ToString();
			this.lblMfrRespName.Text = dv1[0]["mfr_respnm"].ToString();
			this.lblMfrRespJobTitle.Text = dv1[0]["mfr_respjbti"].ToString();
			this.lblMfrTel.Text = dv1[0]["mfr_tel"].ToString();
			this.lblMfrFax.Text = dv1[0]["mfr_fax"].ToString();

			// 顯示出所有的 dv1 裡的資料, 並用 \ 符號隔開區別
			//			for (int i =0; i < dv1.Count; i++)
			//				{
			//					for (int j=0;j<71;j++)
			//						Response.Write(j + ":" + dv1[i][j] + "\\ ");
			//				}
		}

		private void imbPubEdit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			// 抓本頁的變數給轉址的網頁
			string contno = lblContNo.Text;
			// 因 lblPubSeq 目前不是 Server 物件, 故無法抓取其值, 以供傳遞至下一網頁
			string pubseq = "1";
			//string pubseq = lblPubSeq.Text;
			
			// 轉址處理
			Response.Redirect("adpub_detail.aspx?contno=" + contno + "&pubseq=" + pubseq);
		}
	}
}
