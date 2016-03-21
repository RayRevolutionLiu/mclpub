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
// XML
using System.Xml;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for cont_new.
	/// </summary>
	public class cont_new3 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlContType;
		protected System.Web.UI.WebControls.Label lblEmpno;
		protected System.Web.UI.WebControls.Label lblPubItemNo;
		protected System.Web.UI.WebControls.Label lblRemark;
		protected System.Web.UI.WebControls.ImageButton imb_delete;
		protected System.Web.UI.WebControls.ImageButton imb_add;
		protected System.Web.UI.WebControls.Label lblProjNo;
		protected System.Web.UI.WebControls.Label lblCostCtr;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.TextBox tbxPageNo;
		protected System.Web.UI.WebControls.Label lblCustName;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblMfrRespName;
		protected System.Web.UI.WebControls.Label lblMfrRespJobTitle;
		protected System.Web.UI.WebControls.Label lblMfrTel;
		protected System.Web.UI.WebControls.Label lblMfrFax;
		protected System.Web.UI.WebControls.Label lblMfrInvAddr;
		protected System.Web.UI.WebControls.Label lblMfrInvZip;
		protected System.Web.UI.WebControls.Label lblORName;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.TextBox tbxCount;
		protected System.Web.UI.WebControls.TextBox tbxEmpNo;
		protected System.Web.UI.HtmlControls.HtmlForm cont_new2;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlBookCode;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlEmpNo;
		protected System.Web.UI.WebControls.TextBox tbxChangeJTime;
		protected System.Web.UI.WebControls.TextBox tbxColorTime;
		protected System.Web.UI.WebControls.TextBox tbxFreeTime;
		protected System.Web.UI.WebControls.TextBox tbxMenoTime;
		protected System.Web.UI.WebControls.TextBox tbxGetColorTime;
		protected System.Web.UI.WebControls.TextBox tbxTotalAmt;
		protected System.Web.UI.WebControls.TextBox tbxAuEmail;
		protected System.Web.UI.WebControls.TextBox tbxAuFax;
		protected System.Web.UI.WebControls.TextBox tbxAuName;
		protected System.Web.UI.WebControls.TextBox tbxAuTel;
		protected System.Web.UI.WebControls.TextBox tbxAuCell;
		protected System.Web.UI.HtmlControls.HtmlSelect Select1;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlPageSizeCode;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlConnection sqlConnection2;
		protected System.Web.UI.HtmlControls.HtmlSelect Select2;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlLTypeCode;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlColorCode;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter6;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter7;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenPreXml;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenContType;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxSignDate;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxStartDate;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxEndDate;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenModDate;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenCustNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenProjNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenContNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenCompanyName;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenfgITRI;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenfgPayOnce;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenCostCtr;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrName;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenCustName;
		protected System.Web.UI.WebControls.DropDownList ddlfgPayOnce;
		protected System.Web.UI.WebControls.TextBox hiddenfgClosed;
		protected System.Web.UI.WebControls.Label lblfgClosedMessage;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenEmpNo;
		protected System.Web.UI.WebControls.Label lblMazRecMessage;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter8;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand8;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrRespName;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrRespJobTitle;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrTel;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrFax;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenBkcdProjCost;
		protected System.Web.UI.WebControls.Label lblTotalPubCount;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenInvRec;
		protected System.Web.UI.WebControls.Label lblInvRecMessage;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrZipcode;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrAddress;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMazRec;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenIMDetail;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenPubDetail;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenLoginEmpNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenOldContNo;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxDiscount;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenTotalPubCount;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenTotalUnPubCount;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenTotalJTime;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxTotalJTime;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenTotalTime;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxTotalTime;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.Label lblCompanyName;

	
		public cont_new3()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				// 抓出登入者的工號, 作為預設之承辦業務員及修改業務員之值
				// 寫在 InitialMyData() 裡, LoadPreiousCont() 裡就不呼叫有關承辦業務員及修改業務員之值
				
				
				///下拉式選單 合約類別
				//藉由前一網頁傳來的變數值字串 conttp, 抓出下拉式選單 合約類別的預設值
				string conttp = Context.Request.QueryString["conttp"].ToString();
				//Response.Write("conttp= " + conttp + "<BR>");
				// 指定 合約類別 存入 hiddenOldContNo 值裡
				hiddenContType.Value = conttp;
				//Response.Write("hiddenContType.Value= " + hiddenContType.Value + "<BR>");

				// 若 conttp = 01 or 09, 顯示不同的下拉式選單的文字及值
				if(Context.Request.QueryString["conttp"]=="01")
					this.ddlContType.SelectedIndex = 0;
				//this.ddlContType.SelectedIndex = int.Parse(conttp);
				if(Context.Request.QueryString["conttp"]=="09")
					this.ddlContType.SelectedIndex = 01;
				

				///合約書編號: 用舊合約書編號抓到其歷史相關資料; 但顯示算出新的合約書編號
				//舊合約書編號: 藉由前一網頁傳來的變數值字串 old_contno; 在 LoadPreiousCont() 中處理
				// 算出合約書的新編號 = 資料庫中目前最大的合約書編號 + 1
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds8 = new DataSet();
				DataView dv8;
				this.sqlDataAdapter8.Fill(ds8, "c2_cont");
				dv8 = ds8.Tables["c2_cont"].DefaultView;
				
				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				dv8.RowFilter = "1=1";
				
				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv8.Count= "+ dv8.Count + "<BR>");
				//Response.Write("dv8.RowFilter= " + dv8.RowFilter + "<BR>");
				//Response.Write("MaxContNo= " + dv8[0]["MaxContNo"].ToString() + "<BR>");
				//Response.Write("TotalCount= " + dv8[0]["TotalCount"].ToString() + "<BR>");
				
				//TotalCount
				// 抓出資料庫中目前最大的合約書編號
				// 若資料庫裡無資料 MaxContNo=null 且 TotalCount=0, 則由 0開始算
				string strAssignedContNo = Convert.ToString(System.DateTime.Today.Year-1911);
				//Response.Write("init. strAssignedContNo= "+ strAssignedContNo + "<BR>");

				if(dv8.Count > 0 & dv8[0]["TotalCount"].ToString()!= "0")
				{
					strAssignedContNo = Convert.ToString(Convert.ToInt32(dv8[0]["MaxContNo"]) + 1);
				}
				else
				{
					// 若 c2_cont 無資料, 則指定起始編號為 Year+四碼流水號, 如 910000
					strAssignedContNo += "0000";
				}
				//Response.Write("strAssignedContNo= "+ strAssignedContNo + "<BR>");

				// 檢查 strAssignedContNo 是否為 6碼字串格式, 否則前面補 0
				//Response.Write("strAssignedContNo.Length= " + strAssignedContNo.Length + "<BR>");
				int ZeroLength = 6 - strAssignedContNo.Length;
				//Response.Write("ZeroLength= " + ZeroLength + "<BR>");
				for(int i=0; i<ZeroLength; i++)
					strAssignedContNo = "0" + strAssignedContNo;
				//Response.Write("strAssignedContNo= " + strAssignedContNo + "<BR>");
				
				//顯示新的合約書編號, 並給 hiddenContNo 值
				this.lblContNo.Text = strAssignedContNo.ToString().Trim();
				hiddenContNo.Value = strAssignedContNo.ToString().Trim();
				//Response.Write("hiddenContNo.Value= " + hiddenContNo.Value + "<BR>");
				
				
				// 呼叫 InitialMyData() function
				InitialMyData();
				//Response.Write("User.Identity.Name= " + User.Identity.Name.ToString().Trim() + "<br>");
				//Response.Write("hiddenEmpNo.Value= " + hiddenEmpNo.Value + "<br>");
				//Response.Write("hiddenEmpNo.Value= " + Session("Empid").ToString() + "<br>");
				
				
				//顯示 [廠商及客戶資料區] 裡的所有資料
				GetMfrCust();

				// 呼叫 LoadPreiousCont() function: 前一筆合約書資料, 並算出其合約書流水號
				// 若有歷史合約書編號 (表示該客戶有歷史資料), 則呼叫 LoadPreiousCont() function
				//Response.Write("old_contno= " + Context.Request.QueryString["old_contno"].ToString() + "<BR>");
				if (Context.Request.QueryString["old_contno"].ToString()!="0")
				{
					string old_contno = Context.Request.QueryString["old_contno"].ToString().Trim();
					//Response.Write("old_contno= " + old_contno + "<BR>");
					LoadPreiousCont();
				}
				else
				{
					// 指定廣告聯絡人的姓名, 電話, 傳真 預設 同客戶的姓名, 電話, 傳真
					this.tbxAuName.Text = this.lblCustName.Text.ToString().Trim();
					this.tbxAuTel.Text = this.lblMfrTel.Text.ToString().Trim();
					this.tbxAuFax.Text = this.lblMfrFax.Text.ToString().Trim();
				}
				// 指定 歷史合約書編號 存入 hiddenOldContNo 值裡
				hiddenOldContNo.Value= Context.Request.QueryString["old_contno"].ToString().Trim();
				//Response.Write("hiddenOldContNo.Value= " + hiddenOldContNo.Value + "<BR>");
				
//				// 否則給與提示訊息 ==> 此段不 work
//				else if(Context.Request.QueryString["old_contno"].ToString()=="0")
//				{
//					//Response.Write("new<BR>");
//					Response.Write("<Font Color=Yellow>(你沒有呼叫歷史合約書資料, 請自行填入所有的資料!)</Font>");
//				}

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
		/// 
 
		/// <summary>
		/// 連結至資料庫 db & tabel 中抓資料
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter7 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter6 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter8 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection2 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT cont_contid, cont_syscd, cont_contno, cont_conttp, cont_bkcd, cont_signdate, cont_empno, cont_mfrno, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_sdate, cont_edate, cont_totjtm, cont_madejtm, cont_restjtm, cont_disc, cont_freetm, cont_fgclosed, cont_tottm, cont_pubtm, cont_resttm, cont_chgjtm, cont_custno, cont_totamt, cont_pubamt, cont_chgamt, cont_paidamt, cont_restamt, cont_clrtm, cont_menotm, cont_getclrtm, cont_oldcontno, cont_moddate, cont_fgpayonce, cont_xmldata FROM c2_cont";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "application name=mrlpub;data source=isccom1;initial catalog=mrlpub;password=moc18" +
				"47csi;persist security info=True;user id=sa;workstation id=03212-890711;packet s" +
				"ize=4096";
			// 
			// sqlSelectCommand7
			// 
			this.sqlSelectCommand7.CommandText = "SELECT ltp_ltpid, ltp_ltpcd, ltp_nm FROM c2_ltp";
			this.sqlSelectCommand7.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand6
			// 
			this.sqlSelectCommand6.CommandText = "SELECT clr_clrid, clr_clrcd, clr_nm FROM c2_clr";
			this.sqlSelectCommand6.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT pgs_pgsid, pgs_pgscd, pgs_nm FROM c2_pgsize";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("bk_bkid", "bk_bkid"),
																																																			  new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																			  new System.Data.Common.DataColumnMapping("proj_syscd", "proj_syscd"),
																																																			  new System.Data.Common.DataColumnMapping("proj_fgitri", "proj_fgitri"),
																																																			  new System.Data.Common.DataColumnMapping("proj_projno", "proj_projno"),
																																																			  new System.Data.Common.DataColumnMapping("proj_costctr", "proj_costctr"),
																																																			  new System.Data.Common.DataColumnMapping("nostr", "nostr")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT book.bk_bkid, book.bk_bkcd, book.bk_nm, proj.proj_syscd, proj.proj_fgitri, proj.proj_projno, proj.proj_costctr, book.bk_bkcd + proj.proj_projno + proj.proj_costctr AS nostr, proj.proj_bkcd FROM book INNER JOIN proj ON book.bk_bkcd = proj.proj_bkcd WHERE (proj.proj_syscd = 'C2')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "cust", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																			  new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																			  new System.Data.Common.DataColumnMapping("cust_mfrno", "cust_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																			  new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																			  new System.Data.Common.DataColumnMapping("cust_fax", "cust_fax"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_tel", "mfr_tel"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_fax", "mfr_fax"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_regdate", "mfr_regdate"),
																																																			  new System.Data.Common.DataColumnMapping("cust_cell", "cust_cell"),
																																																			  new System.Data.Common.DataColumnMapping("cust_email", "cust_email")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT cust.cust_custid, cust.cust_custno, cust.cust_nm, cust.cust_mfrno, cust.cust_jbti, cust.cust_tel, cust.cust_fax, mfr.mfr_mfrid, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_respnm, mfr.mfr_respjbti, mfr.mfr_tel, mfr.mfr_fax, mfr.mfr_iaddr, mfr.mfr_izip, mfr.mfr_regdate, cust.cust_cell, cust.cust_email FROM cust INNER JOIN mfr ON cust.cust_mfrno = mfr.mfr_mfrno";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
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
																																																				 new System.Data.Common.DataColumnMapping("cont_xmldata", "cont_xmldata")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM c2_cont WHERE (cont_contno = @cont_contno) AND (cont_syscd = @cont_syscd) AND (cont_aucell = @cont_aucell) AND (cont_auemail = @cont_auemail) AND (cont_aufax = @cont_aufax) AND (cont_aunm = @cont_aunm) AND (cont_autel = @cont_autel) AND (cont_bkcd = @cont_bkcd) AND (cont_chgamt = @cont_chgamt) AND (cont_chgjtm = @cont_chgjtm) AND (cont_clrtm = @cont_clrtm) AND (cont_contid = @cont_contid) AND (cont_conttp = @cont_conttp) AND (cont_custno = @cont_custno) AND (cont_disc = @cont_disc) AND (cont_edate = @cont_edate) AND (cont_empno = @cont_empno) AND (cont_fgclosed = @cont_fgclosed) AND (cont_fgpayonce = @cont_fgpayonce) AND (cont_freetm = @cont_freetm) AND (cont_getclrtm = @cont_getclrtm) AND (cont_madejtm = @cont_madejtm) AND (cont_menotm = @cont_menotm) AND (cont_mfrno = @cont_mfrno) AND (cont_moddate = @cont_moddate) AND (cont_oldcontno = @cont_oldcontno) AND (cont_paidamt = @cont_paidamt) AND (cont_pubamt = @cont_pubamt) AND (cont_pubtm = @cont_pubtm) AND (cont_restamt = @cont_restamt) AND (cont_restjtm = @cont_restjtm) AND (cont_resttm = @cont_resttm) AND (cont_sdate = @cont_sdate) AND (cont_signdate = @cont_signdate) AND (cont_totamt = @cont_totamt) AND (cont_totjtm = @cont_totjtm) AND (cont_tottm = @cont_tottm) AND (cont_xmldata LIKE @cont_xmldata)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aucell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aucell", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_auemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_auemail", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aufax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aufax", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aunm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aunm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_autel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_autel", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_bkcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_chgamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgamt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_chgjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgjtm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_clrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_clrtm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contid", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_conttp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_conttp", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_custno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_disc", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_disc", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_edate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_edate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_empno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgclosed", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgclosed", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgpayonce", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgpayonce", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_freetm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_freetm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_getclrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_getclrtm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_madejtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_madejtm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_menotm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_menotm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_mfrno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_moddate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_oldcontno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_oldcontno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_paidamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_paidamt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubamt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubtm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_restamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restamt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_restjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restjtm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_resttm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_resttm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_sdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_sdate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_signdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_signdate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totamt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totjtm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_tottm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_tottm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_xmldata", System.Data.SqlDbType.NText, 100000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_xmldata", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO c2_cont(cont_syscd, cont_contno, cont_conttp, cont_bkcd, cont_signdat" +
				"e, cont_empno, cont_mfrno, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_" +
				"auemail, cont_sdate, cont_edate, cont_totjtm, cont_madejtm, cont_restjtm, cont_d" +
				"isc, cont_freetm, cont_fgclosed, cont_tottm, cont_pubtm, cont_resttm, cont_chgjt" +
				"m, cont_custno, cont_totamt, cont_pubamt, cont_chgamt, cont_paidamt, cont_restam" +
				"t, cont_clrtm, cont_menotm, cont_getclrtm, cont_oldcontno, cont_moddate, cont_fg" +
				"payonce, cont_xmldata) VALUES (@cont_syscd, @cont_contno, @cont_conttp, @cont_bk" +
				"cd, @cont_signdate, @cont_empno, @cont_mfrno, @cont_aunm, @cont_autel, @cont_auf" +
				"ax, @cont_aucell, @cont_auemail, @cont_sdate, @cont_edate, @cont_totjtm, @cont_m" +
				"adejtm, @cont_restjtm, @cont_disc, @cont_freetm, @cont_fgclosed, @cont_tottm, @c" +
				"ont_pubtm, @cont_resttm, @cont_chgjtm, @cont_custno, @cont_totamt, @cont_pubamt," +
				" @cont_chgamt, @cont_paidamt, @cont_restamt, @cont_clrtm, @cont_menotm, @cont_ge" +
				"tclrtm, @cont_oldcontno, @cont_moddate, @cont_fgpayonce, @cont_xmldata); SELECT " +
				"cont_contid, cont_syscd, cont_contno, cont_conttp, cont_bkcd, cont_signdate, con" +
				"t_empno, cont_mfrno, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemai" +
				"l, cont_sdate, cont_edate, cont_totjtm, cont_madejtm, cont_restjtm, cont_disc, c" +
				"ont_freetm, cont_fgclosed, cont_tottm, cont_pubtm, cont_resttm, cont_chgjtm, con" +
				"t_custno, cont_totamt, cont_pubamt, cont_chgamt, cont_paidamt, cont_restamt, con" +
				"t_clrtm, cont_menotm, cont_getclrtm, cont_oldcontno, cont_moddate, cont_fgpayonc" +
				"e, cont_xmldata FROM c2_cont WHERE (cont_contno = @Select_cont_contno) AND (cont" +
				"_syscd = @Select_cont_syscd)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_conttp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_conttp", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_bkcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_signdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_signdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_empno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aunm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aunm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_autel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_autel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aufax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aufax", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aucell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aucell", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_auemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_auemail", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_sdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_sdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_edate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_edate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totjtm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_madejtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_madejtm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_restjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restjtm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_disc", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_disc", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_freetm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_freetm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgclosed", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgclosed", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_tottm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_tottm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubtm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_resttm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_resttm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_chgjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgjtm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totamt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubamt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_chgamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgamt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_paidamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_paidamt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_restamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restamt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_clrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_clrtm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_menotm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_menotm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_getclrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_getclrtm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_oldcontno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_oldcontno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgpayonce", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgpayonce", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_xmldata", System.Data.SqlDbType.NText, 100000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "UPDATE c2_cont SET cont_syscd = @cont_syscd, cont_contno = @cont_contno, cont_con" +
				"ttp = @cont_conttp, cont_bkcd = @cont_bkcd, cont_signdate = @cont_signdate, cont" +
				"_empno = @cont_empno, cont_mfrno = @cont_mfrno, cont_aunm = @cont_aunm, cont_aut" +
				"el = @cont_autel, cont_aufax = @cont_aufax, cont_aucell = @cont_aucell, cont_aue" +
				"mail = @cont_auemail, cont_sdate = @cont_sdate, cont_edate = @cont_edate, cont_t" +
				"otjtm = @cont_totjtm, cont_madejtm = @cont_madejtm, cont_restjtm = @cont_restjtm" +
				", cont_disc = @cont_disc, cont_freetm = @cont_freetm, cont_fgclosed = @cont_fgcl" +
				"osed, cont_tottm = @cont_tottm, cont_pubtm = @cont_pubtm, cont_resttm = @cont_re" +
				"sttm, cont_chgjtm = @cont_chgjtm, cont_custno = @cont_custno, cont_totamt = @con" +
				"t_totamt, cont_pubamt = @cont_pubamt, cont_chgamt = @cont_chgamt, cont_paidamt =" +
				" @cont_paidamt, cont_restamt = @cont_restamt, cont_clrtm = @cont_clrtm, cont_men" +
				"otm = @cont_menotm, cont_getclrtm = @cont_getclrtm, cont_oldcontno = @cont_oldco" +
				"ntno, cont_moddate = @cont_moddate, cont_fgpayonce = @cont_fgpayonce, cont_xmlda" +
				"ta = @cont_xmldata WHERE (cont_contno = @Original_cont_contno) AND (cont_syscd =" +
				" @Original_cont_syscd) AND (cont_aucell = @Original_cont_aucell) AND (cont_auema" +
				"il = @Original_cont_auemail) AND (cont_aufax = @Original_cont_aufax) AND (cont_a" +
				"unm = @Original_cont_aunm) AND (cont_autel = @Original_cont_autel) AND (cont_bkc" +
				"d = @Original_cont_bkcd) AND (cont_chgamt = @Original_cont_chgamt) AND (cont_chg" +
				"jtm = @Original_cont_chgjtm) AND (cont_clrtm = @Original_cont_clrtm) AND (cont_c" +
				"onttp = @Original_cont_conttp) AND (cont_custno = @Original_cont_custno) AND (co" +
				"nt_disc = @Original_cont_disc) AND (cont_edate = @Original_cont_edate) AND (cont" +
				"_empno = @Original_cont_empno) AND (cont_fgclosed = @Original_cont_fgclosed) AND" +
				" (cont_fgpayonce = @Original_cont_fgpayonce) AND (cont_freetm = @Original_cont_f" +
				"reetm) AND (cont_getclrtm = @Original_cont_getclrtm) AND (cont_madejtm = @Origin" +
				"al_cont_madejtm) AND (cont_menotm = @Original_cont_menotm) AND (cont_mfrno = @Or" +
				"iginal_cont_mfrno) AND (cont_moddate = @Original_cont_moddate) AND (cont_oldcont" +
				"no = @Original_cont_oldcontno) AND (cont_paidamt = @Original_cont_paidamt) AND (" +
				"cont_pubamt = @Original_cont_pubamt) AND (cont_pubtm = @Original_cont_pubtm) AND" +
				" (cont_restamt = @Original_cont_restamt) AND (cont_restjtm = @Original_cont_rest" +
				"jtm) AND (cont_resttm = @Original_cont_resttm) AND (cont_sdate = @Original_cont_" +
				"sdate) AND (cont_signdate = @Original_cont_signdate) AND (cont_totamt = @Origina" +
				"l_cont_totamt) AND (cont_totjtm = @Original_cont_totjtm) AND (cont_tottm = @Orig" +
				"inal_cont_tottm) AND (cont_xmldata LIKE @Original_cont_xmldata); SELECT cont_con" +
				"tid, cont_syscd, cont_contno, cont_conttp, cont_bkcd, cont_signdate, cont_empno," +
				" cont_mfrno, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_" +
				"sdate, cont_edate, cont_totjtm, cont_madejtm, cont_restjtm, cont_disc, cont_free" +
				"tm, cont_fgclosed, cont_tottm, cont_pubtm, cont_resttm, cont_chgjtm, cont_custno" +
				", cont_totamt, cont_pubamt, cont_chgamt, cont_paidamt, cont_restamt, cont_clrtm," +
				" cont_menotm, cont_getclrtm, cont_oldcontno, cont_moddate, cont_fgpayonce, cont_" +
				"xmldata FROM c2_cont WHERE (cont_contno = @Select_cont_contno) AND (cont_syscd =" +
				" @Select_cont_syscd)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_conttp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_conttp", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_bkcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_signdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_signdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_empno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aunm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aunm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_autel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_autel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aufax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aufax", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aucell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aucell", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_auemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_auemail", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_sdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_sdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_edate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_edate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totjtm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_madejtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_madejtm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_restjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restjtm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_disc", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_disc", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_freetm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_freetm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgclosed", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgclosed", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_tottm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_tottm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubtm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_resttm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_resttm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_chgjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgjtm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totamt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubamt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_chgamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgamt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_paidamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_paidamt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_restamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restamt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_clrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_clrtm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_menotm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_menotm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_getclrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_getclrtm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_oldcontno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_oldcontno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgpayonce", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgpayonce", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_xmldata", System.Data.SqlDbType.NText, 100000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_aucell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aucell", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_auemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_auemail", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_aufax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aufax", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_aunm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aunm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_autel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_autel", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_bkcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_chgamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgamt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_chgjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgjtm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_clrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_clrtm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_conttp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_conttp", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_custno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_disc", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_disc", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_edate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_edate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_empno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_fgclosed", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgclosed", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_fgpayonce", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgpayonce", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_freetm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_freetm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_getclrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_getclrtm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_madejtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_madejtm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_menotm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_menotm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_mfrno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_moddate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_oldcontno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_oldcontno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_paidamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_paidamt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_pubamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubamt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_pubtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubtm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_restamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restamt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_restjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restjtm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_resttm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_resttm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_sdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_sdate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_signdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_signdate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_totamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totamt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_totjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totjtm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_tottm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_tottm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_xmldata", System.Data.SqlDbType.NText, 100000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_xmldata", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter7
			// 
			this.sqlDataAdapter7.SelectCommand = this.sqlSelectCommand7;
			this.sqlDataAdapter7.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_ltp", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("ltp_ltpid", "ltp_ltpid"),
																																																				new System.Data.Common.DataColumnMapping("ltp_ltpcd", "ltp_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm")})});
			// 
			// sqlDataAdapter6
			// 
			this.sqlDataAdapter6.SelectCommand = this.sqlSelectCommand6;
			this.sqlDataAdapter6.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_clr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("clr_clrid", "clr_clrid"),
																																																				new System.Data.Common.DataColumnMapping("clr_clrcd", "clr_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm")})});
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
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("srspn_id", "srspn_id"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_orgcd", "srspn_orgcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_deptcd", "srspn_deptcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_date", "srspn_date"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno")})});
			// 
			// sqlDataAdapter8
			// 
			this.sqlDataAdapter8.SelectCommand = this.sqlSelectCommand8;
			this.sqlDataAdapter8.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("TotalCount", "TotalCount"),
																																																			   new System.Data.Common.DataColumnMapping("MaxContNo", "MaxContNo")})});
			// 
			// sqlSelectCommand8
			// 
			this.sqlSelectCommand8.CommandText = "SELECT COUNT(*) AS TotalCount, MAX(cont_contno) AS MaxContNo FROM c2_cont";
			this.sqlSelectCommand8.Connection = this.sqlConnection1;
			// 
			// sqlConnection2
			// 
			this.sqlConnection2.ConnectionString = "data source=isccom1;initial catalog=MRLPublish;password=moc1847csi;persist securi" +
				"ty info=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, srspn_tel, srspn_atype, srspn" +
				"_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srspn_empno FROM srspn W" +
				"HERE (srspn_atype <> \'a\') AND (srspn_atype <> \'d\')";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		/// <summary>
		/// 抓出 PageLoad 之預設值, 如動態下拉式選單 (由DB來), 系統日期等
		/// </summary>
		private void InitialMyData()
		{
			// 顯示 [合約內容區] 簽約日期及合約開始日之預設值: 抓系統日期之值	
			// 顯示合約迄日之預設: 系統日期 + 加日數 364 天 (因材料人員要求 要出現合約起日隔年日期的前一天, 即364天) => 改為 12 個內一年整
			tbxSignDate.Value=System.DateTime.Today.ToString("yyyy/MM/dd").Trim();
			tbxStartDate.Value=System.DateTime.Today.ToString("yyyy/MM").Trim();
			//tbxEndDate.Value=System.DateTime.Today.AddDays(364).ToString("yyyy/MM");
			tbxEndDate.Value=System.DateTime.Today.AddMonths(11).ToString("yyyy/MM").Trim();
			// 最後修改日期之預設值
			hiddenModDate.Value=System.DateTime.Today.ToString("yyyy/MM/dd").Trim();
			//Response.Write("tbxStartDate.Value= " + tbxStartDate.Value + "<br>");
			//Response.Write("hiddenModDate.Value= " + hiddenModDate.Value + "<br>");
			
			// 顯示下拉式選單 書籍類別的 DB 值
			// 關於 nostr, 請參 sqlDataAdapter3.Select statement; 
			// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "book");
			DataView dv3=ds3.Tables["book"].DefaultView;
			ddlBookCode.DataSource=dv3;
			dv3.RowFilter="proj_fgitri=''";
			ddlBookCode.DataTextField="bk_nm";
			ddlBookCode.DataValueField="nostr";
			// 維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
			//ddlBookCode.DataValueField="bk_bkcd";
			ddlBookCode.DataBind();
			
			// 顯示下拉式選單 業務員的 DB 值
			// **注意: 原本資料庫內之 srspn_cname & srspn_empno 是 char(x) 型態, 故其 sqlDataAdapter4 裡, 要先做 RTRIM 的處理 (如 RTRIM(srspn_cname) AS srspn_cname), 否則其值會含有空白, 如 '800443 ', '康靜怡     ' .
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "srspn");
			ddlEmpNo.DataSource=ds4;
			ddlEmpNo.DataTextField="srspn_cname";
			ddlEmpNo.DataValueField="srspn_empno";
			ddlEmpNo.DataBind();
			
			
			// 抓出登入者的工號, 作為預設之承辦業務員及修改業務員之值
			string LoginEmpNo = "";
			//Response.Write("Session["empid"]= " + Session["empid"].ToString().Trim() + "<br>");
			// 若有登入者的資料, 則抓出並預選業務員之下拉式選單
			if(Session["empid"]!=null && Session["empid"].ToString()!="")
			{
				LoginEmpNo = Session["empid"].ToString().Trim();
				for(int i=0; i<this.ddlEmpNo.Items.Count; i++)
				{
					//Response.Write("ddlEmpNo(" + i + ").Value= " + this.ddlEmpNo.Items[i].Value + "<br>");
					// 若下拉式選單的值 為 登入者工號, 則下拉式選單預選之; 否則為 康靜怡 (800443, SelectedIndex=02)
					if(this.ddlEmpNo.Items[i].Value.Trim() == LoginEmpNo)  
					{
						this.ddlEmpNo.SelectedIndex = i;
					}
					else
					{
						this.ddlEmpNo.SelectedIndex = 02;
					}
				}
				//this.ddlEmpNo.SelectedIndex = this.ddlEmpNo.Items.IndexOf(this.ddlEmpNo.Items.FindByValue(LoginEmpNo));
			}
			// 若無登入者的資料, 則抓出並預選業務員為 康靜怡 (800443, SelectedIndex=02)
			else
			{
				//LoginEmpNo = User.Identity.Name.Substring(5, 6).ToString().Trim();
				//Response.Write("User.Identity.Name= " + User.Identity.Name.ToString().Trim() + "<br>");
				LoginEmpNo = "800443";
				this.ddlEmpNo.SelectedIndex = 02;
			}
			//Response.Write("LoginEmpNo= " + LoginEmpNo + "<br>");
			hiddenEmpNo.Value = this.ddlEmpNo.Value.Trim();
			hiddenLoginEmpNo.Value = LoginEmpNo;
			
			
			// 顯示下拉式選單 廣告篇幅的 DB 值
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "c2_pgsize");
			ddlPageSizeCode.DataSource=ds5;
			ddlPageSizeCode.DataTextField="pgs_nm";
			ddlPageSizeCode.DataValueField="pgs_pgscd";
			ddlPageSizeCode.DataBind();
			
			// 顯示下拉式選單 廣告色彩的 DB 值
			DataSet ds6 = new DataSet();
			this.sqlDataAdapter6.Fill(ds6, "c2_clr");
			ddlColorCode.DataSource=ds6;
			ddlColorCode.DataTextField="clr_nm";
			ddlColorCode.DataValueField="clr_clrcd";
			ddlColorCode.DataBind();

			// 顯示下拉式選單 廣告版面的 DB 值
			DataSet ds7 = new DataSet();
			this.sqlDataAdapter7.Fill(ds7, "c2_ltp");
			ddlLTypeCode.DataSource=ds7;
			ddlLTypeCode.DataTextField="ltp_nm";
			ddlLTypeCode.DataValueField="ltp_ltpcd";
			ddlLTypeCode.DataBind();
			
		}
		

		private void GetMfrCust()
		{

			///藉視窗傳入變數之客戶編號, 抓出其廠商統編等相關資料
			string custno = Context.Request.QueryString["custno"].ToString().Trim();
			//Response.Write("custno= " + custno + "<BR>");
			lblCustNo.Text = custno;
			// 給 hiddenCustNo 值
			hiddenCustNo.Value=custno;
			//Response.Write("hiddenCustNo.Value= " + hiddenCustNo.Value + "<BR>");

			/// 抓出客戶其他相關資料
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "cust");
			DataView dv2 = ds2.Tables["cust"].DefaultView;
	
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			dv2.RowFilter = "cust_custno=" + custno;
				
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
				
			//防呆處理: 若無資料時, 則給錯誤訊息
			if(dv2.Count > 0)
			{
				// 藉變數 custno 抓客戶資料
				this.lblCustName.Text = dv2[0]["cust_nm"].ToString().Trim();
				// 給 hiddenCustName 值, 並 Trim 去除空白
				hiddenCustName.Value=this.lblCustName.Text;
				//Response.Write(dv2[0]["cust_nm"].ToString() + "<BR>");
				

				///抓出廠商統編 (藉 cust_mfrno)
				string mfrno = dv2[0]["cust_mfrno"].ToString().Trim();
				//Response.Write("cont_mfrno= " + mfrno + "<BR>");
				lblMfrNo.Text = mfrno;
				// 給 hiddenCustNo 值
				hiddenMfrNo.Value = mfrno;
				//Response.Write("mfrno= " + mfrno + "<BR>");

				// 藉變數 mfrno 抓廠商資料
				this.lblMfrNo.Text = mfrno;
				// 給 hiddenMfrNo 值
				hiddenMfrNo.Value = mfrno;
				this.lblCompanyName.Text = dv2[0]["mfr_inm"].ToString().Trim();
				// 給 hiddenMfrName 值, 並 Trim 去除空白
				hiddenMfrName.Value=this.lblCompanyName.Text;

				// 給其他廠商資料 hidden 值
				this.lblMfrRespName.Text = dv2[0]["mfr_respnm"].ToString().Trim();
				hiddenMfrRespName.Value=this.lblMfrRespName.Text;

				this.lblMfrRespJobTitle.Text = dv2[0]["mfr_respjbti"].ToString().Trim();
				hiddenMfrRespJobTitle.Value=this.lblMfrRespJobTitle.Text;

				this.lblMfrTel.Text = dv2[0]["mfr_tel"].ToString().Trim();
				hiddenMfrTel.Value=this.lblMfrTel.Text;

				this.lblMfrFax.Text = dv2[0]["mfr_fax"].ToString().Trim();
				hiddenMfrFax.Value=this.lblMfrFax.Text;
				
				
				// 給預設值 (同廠商地址): 發票收件人資料之預設值
				hiddenMfrZipcode.Value = dv2[0]["mfr_izip"].ToString().Trim();
				hiddenMfrAddress.Value = dv2[0]["mfr_iaddr"].ToString().Trim();
				//Response.Write("hiddenMfrZipcode= " + dv2[0]["mfr_izip"] + "<BR>");
				//Response.Write("tbxIRAddr= " + dv2[0]["mfr_iaddr"] + "<BR>");
				
				
//				//顯示出所有的 dv2 裡的資料, 並用 \ 符號隔開區別
//				for (int i =0; i < dv2.Count; i++)
//				{
//					for (int j=0;j<14;j++)
//						Response.Write(j + ":" + dv2[i][j] + "\\ ");
//				}

			}
		}

		/// <summary>
		/// 呼叫該客戶之前合約書的歷史資料
		/// </summary>
		private void LoadPreiousCont()
		{
			//藉由前一網頁傳來的變數值字串 custno, conttp, contseq
			string old_contno=Context.Request.QueryString["old_contno"].ToString().Trim();
			string conttp=Context.Request.QueryString["conttp"].ToString().Trim();
			//Response.Write("old_contno= " + old_contno + "<BR>");
			
			
			// 若有合約書編號, 表示非新合約書 (即有歷史合約書資料)
			if(old_contno!="")
			{
				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds3 = new DataSet();
				DataView dv3;
				this.sqlDataAdapter1.Fill(ds3, "c2_cont");
				dv3 = ds3.Tables["c2_cont"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				dv3.RowFilter = "cont_syscd='C2' and cont_contno='" + old_contno + "' and cont_conttp='" + conttp + "'";

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
				//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

				// 若有歷史合約書資料, 則載入
				if(dv3.Count>0)
				{
					// 檢查該合約書是否結案, 並顯示出相關訊息.
					// 若已結案, 則不予修改.
					this.hiddenfgClosed.Text = dv3[0].Row["cont_fgclosed"].ToString().Trim();
					int fgClosed = int.Parse(dv3[0].Row["cont_fgclosed"].ToString().Trim());
					if(fgClosed==1)
						lblfgClosedMessage.Text = "<Font Color=Yellow>(被呼叫之歷史合約書已結案!!!)</Font>";
					else if(fgClosed==0)
						lblfgClosedMessage.Text = "<Font Color=Yellow>注意: 被呼叫之歷史合約書目前尚未結案, 請先維護之!!!</Font>";
					
					// 抓出 cont_bkcd 直接減 1 的值: 0, 1 即正好為 ddlBookCode.SelectedIndex
					//Response.Write("cont_bkcd= " + (int.Parse(dv3[0]["cont_bkcd"].ToString())-1) + "<br>");
					this.ddlBookCode.SelectedIndex = (int.Parse(dv3[0]["cont_bkcd"].ToString())-1);
					//ddlBookCode.Value = dv3[0].Row["cont_bkcd"].ToString();
					
					// 抓出承辦業務員工號之值 並給 hiddenEmpNo 值
					// --> 不在此段做, 因承辦業務員工號之值預設應該是 LoginEmpNo (已在 InitialMyData() 裡做了)
					//ddlEmpNo.Value = dv3[0].Row["cont_empno"].ToString().Trim();
					//hiddenEmpNo.Value = ddlEmpNo.Value;
					//Response.Write("hiddenEmpNo.Value= " + hiddenEmpNo.Value + "<br>");

					// 抓出 ddlfgPayOnce 先加1, 再除 2 後的餘值: 0, 1 即正好為 ddlfgPayOnce.SelectedIndex
					this.ddlfgPayOnce.SelectedIndex = (int.Parse(dv3[0]["cont_fgpayonce"].ToString())+1) % 2;

					// 抓 cont_fgitri 院/所內註記之下拉式選單的值 GetddlfgITRI (value=0, 06, 07; SelectedIndex=0, 1, 2)
					// 方法一: 抓出 GetddlfgITRI 除 5 後的餘值: 0, 1, 2, 即正好為 ddlfgITRI.SelectedIndex
					//int ddlfgITRIIndex = (int.Parse(dv3[0].Row["cont_fgitri"].ToString().Trim())) % 5;
					//Response.Write("ddlfgITRIIndex= " + ddlfgITRIIndex + "<br>");
					//this.ddlfgITRI.SelectedIndex = ddlfgITRIIndex;
						// 方法二: 用 if else 來做挑選
						//int GetddlfgITRI = int.Parse(dv3[0].Row["cont_fgitri"].ToString().Trim());
						//Response.Write("GetddlfgITRI= " + GetddlfgITRI + "<br>");
						//if(GetddlfgITRI==0)
						//this.ddlfgITRI.SelectedIndex = 0;
						//else if(GetddlfgITRI==6)
						//this.ddlfgITRI.SelectedIndex = 1;
						//else if(GetddlfgITRI==7)
						//this.ddlfgITRI.SelectedIndex = 2;
					
					
					// 合約書細節區
					// 注意: 總製稿次數
					tbxTotalJTime.Value = dv3[0].Row["cont_totjtm"].ToString().Trim();
					// 給 總製稿次數(同 換稿次數) hidden 值, 方便落版選 "改稿/新稿" 時, 可供計算剩餘次數之用
					hiddenTotalJTime.Value = dv3[0].Row["cont_totjtm"].ToString().Trim();
					//Response.Write("hiddenTotalJTime.Value= " + hiddenTotalJTime.Value + "<br>");
					// 給 總刊登次數 hidden 值, 方便判別其次數是否在合約起迄次數內(若每月一次)
					tbxTotalTime.Value = dv3[0].Row["cont_tottm"].ToString().Trim();
					hiddenTotalTime.Value = dv3[0].Row["cont_tottm"].ToString().Trim();
					//Response.Write("hiddenTotalTime.Value= " + hiddenTotalTime.Value + "<br>");
					tbxTotalAmt.Text = dv3[0].Row["cont_totamt"].ToString().Trim();
					tbxChangeJTime.Text = dv3[0].Row["cont_chgjtm"].ToString().Trim();
					tbxFreeTime.Text = dv3[0].Row["cont_freetm"].ToString().Trim();
					// 因應 tbxDiscount1 由 client 變更, 故由 Server/Web Control 改為 Client/HTML Control
					//tbxDiscount.Text = dv3[0].Row["cont_disc"].ToString().Trim();
					tbxDiscount.Value = dv3[0].Row["cont_disc"].ToString().Trim();
					//Response.Write("tbxDiscount.Value= " + tbxDiscount.Value + "<br>");
					tbxColorTime.Text = dv3[0].Row["cont_clrtm"].ToString().Trim();
					tbxMenoTime.Text = dv3[0].Row["cont_menotm"].ToString().Trim();
					tbxGetColorTime.Text = dv3[0].Row["cont_getclrtm"].ToString().Trim();


					// 廣告聯絡人資料區
					tbxAuName.Text = dv3[0].Row["cont_aunm"].ToString().Trim();
					tbxAuTel.Text = dv3[0].Row["cont_autel"].ToString().Trim();
					tbxAuFax.Text = dv3[0].Row["cont_aufax"].ToString().Trim();
					tbxAuCell.Text = dv3[0].Row["cont_aucell"].ToString().Trim();
					tbxAuEmail.Text = dv3[0].Row["cont_auemail"].ToString().Trim();
					
					
					// 雜誌收件人區
					// 使用 XML 方式 來抓其雜誌收件人之歷史資料 xmlItem
					XmlDocument xmldoc= new XmlDocument();
					
					// 先抓出整個合約書的 XML 資料 cont_xmldata, 儲存於 hiddenPreXml
					hiddenPreXml.Value = dv3[0].Row["cont_xmldata"].ToString().Trim();
					//Response.Write("hiddenPreXml.Value= " + hiddenPreXml.Value + "<br><br>");
					xmldoc.LoadXml(hiddenPreXml.Value);
					//Response.Write("xmldoc=" + xmldoc.OuterXml);
					

					// 抓出合約書發票收件人資料之歷史 XML 資料 xmlInvRecHistory, 儲存於 hiddenMazRec
					XmlNode xmlInvRecHistory;
					xmlInvRecHistory = xmldoc.SelectSingleNode("/root/發票廠商資料");
					//Response.Write("xmlInvRecHistory= " + xmlInvRecHistory.OuterXml + "<br>");

					// 發票收件人資料: 傳 XML 歷史資料給 hiddenInvRec					
					hiddenInvRec.Value = xmlInvRecHistory.OuterXml;
					//Response.Write("hiddenInvRec.Value= " + hiddenInvRec.Value + "<br>");
					if(hiddenInvRec.Value!="")
					{
						hiddenInvRec.Value = xmlInvRecHistory.OuterXml;
						this.lblInvRecMessage.Text = "&nbsp;<FONT Color=Yellow>(有歷史資料, 請按下方按鈕來挑選)</FONT>";
					}
					else
					{
						hiddenInvRec.Value = "";
						this.lblInvRecMessage.Text = "";
					}
					

					// 抓出合約書雜誌收件人之歷史 XML 資料 xmlMazRecHistory, 儲存於 hiddenMazRec
					XmlNode xmlMazRecHistory;
					xmlMazRecHistory = xmldoc.SelectSingleNode("/root/雜誌收件人資料");
					//Response.Write("xmlMazRecHistory= " + xmlMazRecHistory.OuterXml + "<br>");

					// 雜誌收件人資料: 傳 XML 歷史資料給 hiddenMazRec
					hiddenMazRec.Value = xmlMazRecHistory.OuterXml;
					//Response.Write("hiddenMazRec.Value= " + hiddenMazRec.Value + "<br>");
					if(hiddenMazRec.Value!="")
					{
						hiddenMazRec.Value = xmlMazRecHistory.OuterXml;
						this.lblMazRecMessage.Text = "&nbsp;<FONT Color=Yellow>(有歷史資料, 請按下方按鈕來挑選)</FONT>";
					}
					else
					{
						hiddenMazRec.Value = "";
						this.lblMazRecMessage.Text = "";
					}

					// 抓出合約書落版刊登資料之歷史 XML 資料 xmlMazRecHistory, 儲存於 hiddenPubDetail
					XmlNode xmlAdPubItemHistory;
					xmlAdPubItemHistory = xmldoc.SelectSingleNode("/root/合約書落版刊登資料");
					hiddenPubDetail.Value=xmlAdPubItemHistory.OuterXml;
					//Response.Write("xmlAdPubItemHistory= " + xmlAdPubItemHistory.OuterXml + "<br><br>");
					//Response.Write("hiddenPubDetail.Value= " + hiddenPubDetail.Value + "<br>");
				}
			}
		}
		
		

	}
}
