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

namespace MRLPub_d2
{
	/// <summary>
	/// Summary description for lostbk_label.
	/// </summary>
	public class lostbk_label : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.HtmlControls.HtmlForm lbl_lostbk;

		public lostbk_label()
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

				// 抓出標籤資料
				GetLabelData();
			}
		}


		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		// 抓出標籤資料
		private void GetLabelData()
		{
			// 抓出篩選條件
//			string strStatus = "", strBkcd = "", strLostDate = "", strSignDate = "";
//			string strLostDateS = "", strLostDateE = "", strSignDateS = "", strSignDateE = "";
			string strfgmosea = "";

			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_cont");
			DataView dv1 = ds1.Tables["c2_cont"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";

			// 依條件 做篩選動作
//			// 寄書狀況
//			if(Context.Request.QueryString["status"].ToString().Trim() != "")
//			{
//				strStatus = Context.Request.QueryString["status"].ToString();
//				if(strStatus == "C")
//				{
//					// 缺書日期
//					if(Context.Request.QueryString["lostdate"].ToString().Trim() != "")
//					{
//						strLostDate = Context.Request.QueryString["lostdate"].ToString().Trim();
//						strLostDateS = strLostDate.Substring(0, 4) + strLostDate.Substring(5, 2) + strLostDate.Substring(8, 2);
//						strLostDateE = strLostDate.Substring(11, 4) + strLostDate.Substring(16, 2) + strLostDate.Substring(19, 2);
//						rowfilterstr1 = rowfilterstr1 + " AND lst_date>='" + strLostDateS + "'";
//						rowfilterstr1 = rowfilterstr1 + " AND lst_date<='" + strLostDateE + "'";
//					}
//					rowfilterstr1 = rowfilterstr1 + " AND lst_fgsent = 'C'";
//				}
//				else if(strStatus == "N")
//				{
//					rowfilterstr1 = rowfilterstr1 + " AND lst_fgsent = 'N'";
//				}
//				else if(strStatus == "All")
//				{
//					rowfilterstr1 = rowfilterstr1;
//				}
//			}
//			else
//			{
//				rowfilterstr1 = rowfilterstr1;
//			}
//
//			// 書籍類別
//			if(Context.Request.QueryString["bkcd"].ToString().Trim() != "")
//			{
//				strBkcd = Context.Request.QueryString["bkcd"].ToString();
//				rowfilterstr1 = rowfilterstr1 + " AND cont_bkcd ='" + strBkcd + "'";
//			}
//			else
//			{
//				rowfilterstr1 = rowfilterstr1;
//			}
//
//			// 簽約日期
//			if(Context.Request.QueryString["signdate"].ToString().Trim() != "")
//			{
//				strSignDate = Context.Request.QueryString["signdate"].ToString();
//				strSignDateS = strSignDate.Substring(0, 4) + strSignDate.Substring(5, 2) + strSignDate.Substring(8, 2);
//				strSignDateE = strSignDate.Substring(11, 4) + strSignDate.Substring(16, 2) + strSignDate.Substring(19, 2);
//				rowfilterstr1 = rowfilterstr1 + " AND cont_signdate>='" + strSignDateS + "'";
//				rowfilterstr1 = rowfilterstr1 + " AND cont_signdate<='" + strSignDateE + "'";
//			}
//			else
//			{
//				rowfilterstr1 = rowfilterstr1;
//			}

			// 簽約日期
			if(Context.Request.QueryString["fgmosea"].ToString().Trim() != "")
			{
				strfgmosea = Context.Request.QueryString["fgmosea"].ToString();
				rowfilterstr1 = rowfilterstr1 + " AND or_fgmosea='" + strfgmosea + "'";
			}
			else
			{
				rowfilterstr1 = rowfilterstr1;
			}
			dv1.RowFilter = rowfilterstr1;
			//Response.Write("strStatus= " + strStatus + "<br>");
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strLostDate= " + strLostDate + "<br>");
			//Response.Write("strLostDateS= " + strLostDateS + "<br>");
			//Response.Write("strLostDateE= " + strLostDateE + "<br>");
			//Response.Write("strSignDate= " + strSignDate + "<br>");
			//Response.Write("strSignDateS= " + strSignDateS + "<br>");
			//Response.Write("strSignDateE= " + strSignDateE + "<br>");


			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			// 若搜尋結果為 "找不到" 的處理
			if (dv1.Count > 0)
			{
				DataList1.DataSource = dv1;
				DataList1.DataBind();
			}
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
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lost", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("lst_contno", "lst_contno"),
																																																				 new System.Data.Common.DataColumnMapping("lst_sdate", "lst_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("lst_edate", "lst_edate"),
																																																				 new System.Data.Common.DataColumnMapping("lost_sedate", "lost_sedate"),
																																																				 new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																				 new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				 new System.Data.Common.DataColumnMapping("lst_date", "lst_date"),
																																																				 new System.Data.Common.DataColumnMapping("lst_cont", "lst_cont"),
																																																				 new System.Data.Common.DataColumnMapping("lst_rea", "lst_rea"),
																																																				 new System.Data.Common.DataColumnMapping("lst_fgsent", "lst_fgsent"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("lst_oritem", "lst_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("lst_seq", "lst_seq"),
																																																				 new System.Data.Common.DataColumnMapping("lst_syscd", "lst_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																				 new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																				 new System.Data.Common.DataColumnMapping("or_mtpcd", "or_mtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("or_pubcnt", "or_pubcnt"),
																																																				 new System.Data.Common.DataColumnMapping("or_unpubcnt", "or_unpubcnt"),
																																																				 new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																				 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm"),
																																																				 new System.Data.Common.DataColumnMapping("mtp_mtpcd", "mtp_mtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttpName", "cont_conttpName"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_jbti", "or_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("lst_fgprepnt", "lst_fgprepnt"),
																																																				 new System.Data.Common.DataColumnMapping("lst_fgpntlbl", "lst_fgpntlbl")})});
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c2_lost.lst_contno, dbo.c2_lost.lst_sdate, dbo.c2_lost.lst_edate, SUBSTRING(dbo.c2_lost.lst_sdate, 1, 4) + '/' + SUBSTRING(dbo.c2_lost.lst_sdate, 5, 6) + '~' + SUBSTRING(dbo.c2_lost.lst_edate, 1, 4) + '/' + SUBSTRING(dbo.c2_lost.lst_edate, 5, 6) AS lost_sedate, dbo.c2_or.or_nm, dbo.c2_or.or_zip, dbo.c2_or.or_addr, dbo.c2_lost.lst_date, dbo.c2_lost.lst_cont, dbo.c2_lost.lst_rea, dbo.c2_lost.lst_fgsent, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd, dbo.c2_lost.lst_oritem, dbo.c2_lost.lst_seq, dbo.c2_lost.lst_syscd, dbo.c2_or.or_contno, dbo.c2_or.or_oritem, dbo.c2_or.or_syscd, dbo.c2_or.or_inm, dbo.c2_or.or_mtpcd, dbo.c2_or.or_pubcnt, dbo.c2_or.or_unpubcnt, dbo.c2_or.or_fgmosea, dbo.mtp.mtp_nm, dbo.mtp.mtp_mtpcd, dbo.c2_cont.cont_conttp, CASE WHEN dbo.c2_cont.cont_conttp = '01' THEN '一般' ELSE '推廣' END AS cont_conttpName, dbo.c2_cont.cont_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, RTRIM(dbo.c2_or.or_jbti) AS or_jbti, dbo.c2_lost.lst_fgprepnt, dbo.c2_lost.lst_fgpntlbl FROM dbo.c2_lost INNER JOIN dbo.c2_or ON dbo.c2_lost.lst_syscd = dbo.c2_or.or_syscd AND dbo.c2_lost.lst_contno = dbo.c2_or.or_contno AND dbo.c2_lost.lst_oritem = dbo.c2_or.or_oritem INNER JOIN dbo.c2_cont ON dbo.c2_or.or_syscd = dbo.c2_cont.cont_syscd AND dbo.c2_or.or_contno = dbo.c2_cont.cont_contno INNER JOIN dbo.mtp ON dbo.c2_or.or_mtpcd = dbo.mtp.mtp_mtpcd INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd WHERE (dbo.c2_lost.lst_fgprepnt = 'v')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



	}
}
