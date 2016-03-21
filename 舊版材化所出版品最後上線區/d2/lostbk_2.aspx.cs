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
	/// Summary description for lostbk_2.
	/// </summary>
	public class lostbk_2 : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.Label lblConttp;
		protected System.Web.UI.WebControls.Label lblContsdate;
		protected System.Web.UI.WebControls.Label lblContedate;
		protected System.Web.UI.WebControls.Label lblfgClosed;
		protected System.Web.UI.WebControls.Label lblfgCancel;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Web.UI.WebControls.Label lblCustName;
		protected System.Web.UI.WebControls.Label lblMfrIName;
		protected System.Web.UI.WebControls.Label lblORName;
		protected System.Web.UI.WebControls.Label lblORmtpcd;
		protected System.Web.UI.WebControls.Label lblORZipcode;
		protected System.Web.UI.WebControls.Label lblORAddr;
		protected System.Web.UI.WebControls.Label lblLostSeq;
		protected System.Web.UI.WebControls.DropDownList ddlSendFlag;
		protected System.Web.UI.HtmlControls.HtmlTextArea textarea1;
		protected System.Web.UI.HtmlControls.HtmlTextArea textarea2;
		protected System.Web.UI.WebControls.TextBox tbxLostDate;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
	
		public lostbk_2()
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
				
				// 抓出初始資料 - 網頁變數
				InitialData();
				
				// 載入 合約/客戶/收件人 相關資料
				LoadContData();
				
				// 指定 缺書資料 (系統資料)
				GetLostData();
			}
		}
		
		
		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		// 抓出初始資料 - 網頁變數
		private void InitialData()
		{
			// 抓出網頁變數
			string strContNo = "";
			string strORItem = "";
			string strContSEdate = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
				strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			else
				strContNo = strContNo;
			this.lblContNo.Text = strContNo;
			
			if(Context.Request.QueryString["oritem"].ToString().Trim() != "")
				strORItem = Context.Request.QueryString["oritem"].ToString().Trim();
			else
				strORItem = strORItem;
			
		}
		
		
		// 載入 合約/客戶/雜誌收件人 相關資料
		private void LoadContData()
		{
			// 抓出網頁變數
			string strContNo = "";
			string strORItem = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
				strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			else
				strContNo = strContNo;
			
			if(Context.Request.QueryString["oritem"].ToString().Trim() != "")
				strORItem = Context.Request.QueryString["oritem"].ToString().Trim();
			else
				strORItem = strORItem;
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_cont");
			DataView dv1 = ds1.Tables["c2_cont"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr1 = " 1=1 ";
			rowfilterstr1 = rowfilterstr1 + " AND cont_contno='" + strContNo + "'";
			rowfilterstr1 = rowfilterstr1 + " AND or_oritem='" + strORItem + "'";
			dv1.RowFilter = rowfilterstr1;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
			
			// 找到資料, 並帶出相關資料 的處理
			if (dv1.Count > 0)
			{
				// 合約書 資料區
				string conttp = dv1[0]["cont_conttp"].ToString().Trim();
				string conttpText = "";
				if(conttp == "01")
					conttpText = "一般合約";
				else if(conttp == "09")
					conttpText = "<font color='Red'>推廣合約</font>";
				this.lblConttp.Text = conttpText;
				string fgclosed = dv1[0]["cont_fgclosed"].ToString().Trim();
				string fgclosedText= "";
				if(fgclosed == "0")
					fgclosedText = "否";
				else
					fgclosedText = "<font color='Red'>是</font>";
				this.lblfgClosed.Text = fgclosedText;
				string fgCancel = "";
				string fgCancelText = "";
				fgCancel = dv1[0]["cont_fgcancel"].ToString().Trim();
				if(fgCancel == "0")
					fgCancelText = "否";
				else
					fgCancelText = "<font color='Red'>是</font>";
				this.lblfgCancel.Text = fgCancelText;
				// 合約起迄
				string sdate = "";
				string edate = "";
				if(dv1[0]["cont_sdate"].ToString().Trim().Length >= 6)
				{
					sdate = dv1[0]["cont_sdate"].ToString().Trim();
					sdate = sdate.Substring(0, 4) + "/" + sdate.Substring(4, 2);
				}
				else
				{
					sdate = sdate;
				}
				if(dv1[0]["cont_edate"].ToString().Trim().Length >= 6)
				{
					edate = dv1[0]["cont_edate"].ToString().Trim();
					edate = edate .Substring(0, 4) + "/" + edate .Substring(4, 2);
				}
				else
				{
					edate = edate;
				}
				this.lblContsdate.Text = sdate;
				this.lblContedate.Text = edate;
				
				
				// 客戶 資料區
				this.lblCustNo.Text = dv1[0]["cont_custno"].ToString().Trim();
				this.lblCustName.Text = dv1[0]["cust_nm"].ToString().Trim();
				this.lblMfrIName.Text = dv1[0]["mfr_inm"].ToString().Trim() + " (" + dv1[0]["cont_mfrno"].ToString().Trim() + ")";
				
				// 雜誌收件人 資料區
				this.lblORName.Text = dv1[0]["or_nm"].ToString().Trim();
				this.lblORZipcode.Text = dv1[0]["or_zip"].ToString().Trim();
				this.lblORAddr.Text = dv1[0]["or_addr"].ToString().Trim();
				this.lblORmtpcd.Text = dv1[0]["mtp_nm"].ToString().Trim();
			}
				// 若找無資料的處理
			else
			{
				this.lblConttp.Text = "<font color='Gray'>(無資料)</font>";
				this.lblfgClosed.Text = "<font color='Gray'>(無資料)</font>";
				this.lblfgCancel.Text = "<font color='Gray'>(無資料)</font>";
				this.lblCustNo.Text = "<font color='Gray'>(無資料)</font>";
				this.lblCustName.Text = "<font color='Gray'>(無資料)</font>";
				this.lblMfrIName.Text = "<font color='Gray'>(無資料)</font>";
				this.lblORName.Text = "<font color='Gray'>(無資料)</font>";
				this.lblORZipcode.Text = "<font color='Gray'>(無資料)</font>";
				this.lblORAddr.Text = "<font color='Gray'>(無資料)</font>";
				this.lblORmtpcd.Text = "<font color='Gray'>(無資料)</font>";
				
				this.lblMessage.Text = "很抱歉, 找不到此合約編號的相關資料!";
			}
			
		}
		
		
		// 抓出 缺書資料
		private void GetLostData()
		{
			// 抓出網頁變數
			string strContNo = "";
			string strORItem = "";
			string strLostSeq = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
				strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			else
				strContNo = strContNo;
			
			if(Context.Request.QueryString["oritem"].ToString().Trim() != "")
				strORItem = Context.Request.QueryString["oritem"].ToString().Trim();
			else
				strORItem = strORItem;
			
			if(Context.Request.QueryString["lstseq"].ToString().Trim() != "")
				strLostSeq = Context.Request.QueryString["lstseq"].ToString().Trim();
			else
				strLostSeq = strLostSeq;
			
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c2_lost");
			DataView dv2 = ds2.Tables["c2_lost"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr2 = " 1=1 ";
			rowfilterstr2 = rowfilterstr2 + " AND lst_contno='" + strContNo + "'";
			rowfilterstr2 = rowfilterstr2 + " AND lst_oritem='" + strORItem + "'";
			rowfilterstr2 = rowfilterstr2 + " AND lst_seq='" + strLostSeq + "'";
			dv2.RowFilter = rowfilterstr2;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
			
			// 找到資料, 並帶出相關資料 的處理
			if (dv2.Count > 0)
			{
				// 缺書日期
				string strLostDate = dv2[0]["lst_date"].ToString().Trim();
				strLostDate = strLostDate.Substring(0, 4) + "/" + strLostDate.Substring(4, 2) + "/" + strLostDate.Substring(6, 2);
				this.tbxLostDate.Text = strLostDate;
				
				// 缺書內容
				this.textarea1.Value = dv2[0]["lst_cont"].ToString().Trim();
				
				// 缺書原因
				this.textarea2.Value = dv2[0]["lst_rea"].ToString().Trim();
				
				// 已寄出註記
				this.ddlSendFlag.Items.FindByValue(dv2[0]["lst_fgsent"].ToString().Trim()).Selected = true;
				
			}
			else
			{
				this.tbxLostDate.Text = "";
			}
		}
		
		
		// 修改缺書資料 按鈕
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			// 抓下 畫面上的值
			string strContNo = "";
			string strORItem = "";
			string strLostSeq = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
				strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			else
				strContNo = strContNo;
			
			if(Context.Request.QueryString["oritem"].ToString().Trim() != "")
				strORItem = Context.Request.QueryString["oritem"].ToString().Trim();
			else
				strORItem = strORItem;
			
			if(Context.Request.QueryString["lstseq"].ToString().Trim() != "")
				strLostSeq = Context.Request.QueryString["lstseq"].ToString().Trim();
			else
				strLostSeq = strLostSeq;
			
			string strLostContent = this.textarea1.Value.ToString().Trim();
			string strLostDate = "";
			if(this.tbxLostDate.Text.ToString().Trim() != "")
			{
				strLostDate = this.tbxLostDate.Text.ToString().Trim();
				if(strLostDate.Length >= 10)
				{
					strLostDate = strLostDate.Substring(0, 4) + strLostDate.Substring(5, 2) + strLostDate.Substring(8, 2);
				}
				else
					strLostDate = strLostDate;
			}
			else
				strLostDate = System.DateTime.Today.ToString("yyyyMMdd");
			string strLostReason = this.textarea2.Value.ToString().Trim();
			string strfgSent = this.ddlSendFlag.SelectedItem.Value.ToString().Trim();
			//Response.Write("strSyscd= " + strSyscd + "<br>");
			//Response.Write("strContNo= " + strContNo + "<br>");
			//Response.Write("strORItem= " + strORItem + "<br>");
			//Response.Write("strLostSeq= " + strLostSeq + "<br>");
			//Response.Write("strLostContent= " + strLostContent + "<br>");
			//Response.Write("strLostDate= " + strLostDate + "<br>");
			//Response.Write("strLostReason= " + strLostReason + "<br>");
			//Response.Write("strfgSent= " + strfgSent + "<br>");
			
			
			// 執行 儲存資料
			// 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 新增入資料庫
			this.sqlCommand1.Parameters["@contno"].Value = strContNo;
			this.sqlCommand1.Parameters["@oritem"].Value = strORItem;
			this.sqlCommand1.Parameters["@lostseq"].Value = strLostSeq;
			this.sqlCommand1.Parameters["@cont"].Value = strLostContent;
			this.sqlCommand1.Parameters["@date"].Value = strLostDate;
			this.sqlCommand1.Parameters["@rea"].Value = strLostReason;
			this.sqlCommand1.Parameters["@fgsent"].Value = strfgSent;
			
			
			// 確認執行 sqlSelectCommand1 成功
			bool ResultFlag1 = false;
			this.sqlCommand1.Connection.Open();
			try
			{
				this.sqlCommand1.ExecuteNonQuery();
				ResultFlag1 = true;
			}
			catch(System.Data.SqlClient.SqlException ex1)
			{
				Response.Write(ex1.Message + "<br>");
				ResultFlag1 = false;
			}
			finally
			{
				this.sqlCommand1.Connection.Close();
			}
			
			// 輸出執行結果
			if (ResultFlag1)
			{
				//Response.Write("修改成功!<br>");
				
				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlert1 = new LiteralControl();
				litAlert1.Text = "<script language=javascript>alert(\"修改成功\");</script>";
				Page.Controls.Add(litAlert1);
				
				// 轉址
				Response.Redirect("SaveMessage.aspx?str=modlost");
			}
			else
			{
				//Response.Write("修改失敗!<br>");
				
				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlert1 = new LiteralControl();
				litAlert1.Text = "<script language=javascript>alert(\"修改失敗\");</script>";
				Page.Controls.Add(litAlert1);
			}
		}
		
		
		// 取消回前頁
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			// 轉址
			Response.Redirect("lostbk_search.aspx?function1=mod");
		}
		
		
		
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT lst_syscd, lst_contno, lst_oritem, lst_seq, lst_cont, lst_date, lst_rea, l" +
				"st_fgsent, lst_sdate, lst_edate FROM c2_lost WHERE (lst_syscd = \'C2\')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
//				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_conttp, c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_custno, cust.cust_nm, mfr.mfr_inm, cust.cust_custno, mfr.mfr_mfrno, c2_cont.cont_mfrno, c2_or.or_oritem, c2_or.or_nm, c2_or.or_jbti, c2_or.or_zip, c2_or.or_addr, c2_or.or_tel, c2_or.or_fax, c2_or.or_cell, c2_or.or_email, c2_or.or_mtpcd, c2_or.or_pubcnt, c2_or.or_unpubcnt, c2_or.or_fgmosea, c2_or.or_contno, c2_or.or_syscd, c2_cont.cont_fgclosed, c2_cont.cont_fgcancel, mtp.mtp_nm, mtp.mtp_mtpcd, c2_cont.cont_bkcd, book.bk_nm, book.bk_bkcd FROM c2_cont INNER JOIN cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN c2_or ON c2_cont.cont_syscd = c2_or.or_syscd AND c2_cont.cont_contno = c2_or.or_contno INNER JOIN mtp ON c2_or.or_mtpcd = mtp.mtp_mtpcd INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lost", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("lst_syscd", "lst_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("lst_contno", "lst_contno"),
																																																				 new System.Data.Common.DataColumnMapping("lst_oritem", "lst_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("lst_seq", "lst_seq"),
																																																				 new System.Data.Common.DataColumnMapping("lst_cont", "lst_cont"),
																																																				 new System.Data.Common.DataColumnMapping("lst_date", "lst_date"),
																																																				 new System.Data.Common.DataColumnMapping("lst_rea", "lst_rea"),
																																																				 new System.Data.Common.DataColumnMapping("lst_fgsent", "lst_fgsent"),
																																																				 new System.Data.Common.DataColumnMapping("lst_sdate", "lst_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("lst_edate", "lst_edate")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_jbti", "or_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																				 new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				 new System.Data.Common.DataColumnMapping("or_tel", "or_tel"),
																																																				 new System.Data.Common.DataColumnMapping("or_fax", "or_fax"),
																																																				 new System.Data.Common.DataColumnMapping("or_cell", "or_cell"),
																																																				 new System.Data.Common.DataColumnMapping("or_email", "or_email"),
																																																				 new System.Data.Common.DataColumnMapping("or_mtpcd", "or_mtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("or_pubcnt", "or_pubcnt"),
																																																				 new System.Data.Common.DataColumnMapping("or_unpubcnt", "or_unpubcnt"),
																																																				 new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																				 new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																				 new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm"),
																																																				 new System.Data.Common.DataColumnMapping("mtp_mtpcd", "mtp_mtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm")})});
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "UPDATE c2_lost SET lst_cont = @cont, lst_date = @date, lst_rea = @rea, lst_fgsent" +
				" = @fgsent WHERE (lst_syscd = \'C2\') AND (lst_contno = @contno) AND (lst_oritem =" +
				" @oritem) AND (lst_seq = @lostseq)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_cont", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_date", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rea", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_rea", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgsent", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_fgsent", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lostseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_seq", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
		
	}
}
