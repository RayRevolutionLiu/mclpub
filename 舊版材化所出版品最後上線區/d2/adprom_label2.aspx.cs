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
	/// Summary description for adprom_label2.
	/// </summary>
	public class adprom_label2 : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.DataList DataList1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if (!IsPostBack)
			{
				Response.Expires = 0;

				// 抓出標籤資料
				GetLabelData();
			}
		}


		// 抓出標籤資料
		private void GetLabelData()
		{
			// 抓出篩選條件
			string strConttp = "", strBkcd = "", strMtpcd = "";


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_cont");
			DataView dv1 = ds1.Tables["c2_cont"].DefaultView;


			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";
			if(Context.Request.QueryString["conttp"].ToString().Trim() != "")
			{
				strConttp = Context.Request.QueryString["conttp"].ToString();
				rowfilterstr1 = rowfilterstr1 + " AND cont_conttp='" + strConttp + "'";
			}
			else
			{
				strConttp = strConttp;
				rowfilterstr1 = rowfilterstr1;
			}
			if(Context.Request.QueryString["bkcd"].ToString().Trim() != "")
			{
				strBkcd = Context.Request.QueryString["bkcd"].ToString();
				rowfilterstr1 = rowfilterstr1 + " AND cont_bkcd='" + strBkcd + "'";
			}
			else
			{
				strBkcd = strBkcd;
				rowfilterstr1 = rowfilterstr1;
			}
			if(Context.Request.QueryString["mtpcd"].ToString().Trim() != "")
			{
				strMtpcd = Context.Request.QueryString["mtpcd"].ToString();
				rowfilterstr1 = rowfilterstr1 + " AND or_mtpcd='" + strMtpcd + "'";
			}
			else
			{
				strBkcd = strBkcd;
				rowfilterstr1 = rowfilterstr1;
			}
			dv1.RowFilter = rowfilterstr1;


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
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}

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
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("cust_fax", "cust_fax"),
																																																				 new System.Data.Common.DataColumnMapping("cust_cell", "cust_cell"),
																																																				 new System.Data.Common.DataColumnMapping("cust_email", "cust_email"),
																																																				 new System.Data.Common.DataColumnMapping("cust_regdate", "cust_regdate"),
																																																				 new System.Data.Common.DataColumnMapping("cust_moddate", "cust_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("cust_itpcd", "cust_itpcd"),
																																																				 new System.Data.Common.DataColumnMapping("cust_btpcd", "cust_btpcd"),
																																																				 new System.Data.Common.DataColumnMapping("cust_rtpcd", "cust_rtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sedate", "cont_sedate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttpName", "cont_conttpName"),
																																																				 new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																				 new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_jbti", "or_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				 new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																				 new System.Data.Common.DataColumnMapping("or_pubcnt", "or_pubcnt"),
																																																				 new System.Data.Common.DataColumnMapping("or_unpubcnt", "or_unpubcnt"),
																																																				 new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																				 new System.Data.Common.DataColumnMapping("or_mtpcd", "or_mtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm")})});
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT DISTINCT TOP 100 PERCENT dbo.c2_cont.cont_contno, RTRIM(dbo.c2_cont.cont_c" +
				"ustno) AS cont_custno, RTRIM(dbo.c2_cont.cont_mfrno) AS cont_mfrno, RTRIM(dbo.mf" +
				"r.mfr_inm) AS mfr_inm, RTRIM(dbo.cust.cust_nm) AS cust_nm, RTRIM(dbo.cust.cust_j" +
				"bti) AS cust_jbti, dbo.cust.cust_tel, dbo.cust.cust_fax, dbo.cust.cust_cell, dbo" +
				".cust.cust_email, dbo.cust.cust_regdate, dbo.cust.cust_moddate, dbo.cust.cust_it" +
				"pcd, dbo.cust.cust_btpcd, dbo.cust.cust_rtpcd, dbo.mfr.mfr_respnm, RTRIM(dbo.mfr" +
				".mfr_respjbti) AS mfr_respjbti, RTRIM(dbo.mfr.mfr_izip) AS mfr_izip, RTRIM(dbo.m" +
				"fr.mfr_iaddr) AS mfr_iaddr, dbo.c2_cont.cont_syscd, dbo.cust.cust_custno, dbo.mf" +
				"r.mfr_mfrno, dbo.c2_cont.cont_conttp, RTRIM(dbo.c2_cont.cont_empno) AS cont_empn" +
				"o, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname, dbo.c2_cont.cont_bkcd, dbo.c2_co" +
				"nt.cont_signdate, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate, dbo.c2_cont.co" +
				"nt_aunm, dbo.c2_cont.cont_autel, SUBSTRING(dbo.c2_cont.cont_sdate, 1, 4) + \'/\' +" +
				" SUBSTRING(dbo.c2_cont.cont_sdate, 5, 6) + \'~\' + SUBSTRING(dbo.c2_cont.cont_edat" +
				"e, 1, 4) + \'/\' + SUBSTRING(dbo.c2_cont.cont_edate, 5, 6) AS cont_sedate, CASE WH" +
				"EN dbo.c2_cont.cont_conttp = \'01\' THEN \'一般\' ELSE \'推廣\' END AS cont_conttpName, db" +
				"o.c2_or.or_inm, dbo.c2_or.or_nm, dbo.c2_or.or_jbti, dbo.c2_or.or_addr, dbo.c2_or" +
				".or_zip, dbo.c2_or.or_pubcnt, dbo.c2_or.or_unpubcnt, dbo.c2_or.or_fgmosea, dbo.c" +
				"2_or.or_mtpcd, RTRIM(dbo.mtp.mtp_nm) AS mtp_nm, RTRIM(dbo.book.bk_nm) AS bk_nm F" +
				"ROM dbo.c2_cont INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_c" +
				"ustno INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOI" +
				"N dbo.srspn ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno INNER JOIN dbo.c2_" +
				"or ON dbo.c2_cont.cont_syscd = dbo.c2_or.or_syscd AND dbo.c2_cont.cont_contno = " +
				"dbo.c2_or.or_contno INNER JOIN dbo.mtp ON dbo.c2_or.or_mtpcd = dbo.mtp.mtp_mtpcd" +
				" INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd WHERE (dbo.c2_c" +
				"ont.cont_fgclosed = \'0\') AND (dbo.c2_cont.cont_fgcancel = \'0\') AND (dbo.c2_cont." +
				"cont_fgtemp = \'0\') AND (dbo.c2_or.or_pubcnt > 0) ORDER BY dbo.c2_cont.cont_bkcd," +
				" dbo.c2_cont.cont_empno, dbo.c2_cont.cont_contno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
