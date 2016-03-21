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
	/// Summary description for PubFm_label.
	/// </summary>
	public class PubFm_label : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.DataList DataList2;

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
			string strBkcd = "", strYYYYMM = "", strEmpNo = "", strConttp = "", strPubCountType = "", strfgMOSea = "", strMtpcd = "", strBookPNo = "";

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";


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

			if(Context.Request.QueryString["yyyymm"].ToString().Trim() != "")
			{
				strYYYYMM = Context.Request.QueryString["yyyymm"].ToString().Trim();
				rowfilterstr1 = rowfilterstr1 + " AND cont_sdate <= '" + strYYYYMM + "'";
				rowfilterstr1 = rowfilterstr1 + " AND cont_edate >='" + strYYYYMM + "'";
				rowfilterstr1 = rowfilterstr1 + " AND or_pubcnt > 0";
				rowfilterstr1 = rowfilterstr1 + " AND pub_yyyymm='" + strYYYYMM + "'";
			}
			else
			{
				strYYYYMM = strYYYYMM;
				rowfilterstr1 = rowfilterstr1;
			}

			if(Context.Request.QueryString["empno"].ToString().Trim() != "")
			{
				strEmpNo = Context.Request.QueryString["empno"].ToString().Trim();
				rowfilterstr1 = rowfilterstr1 + " AND cont_empno='" + strEmpNo + "'";
			}
			else
			{
				strEmpNo = strEmpNo;
				rowfilterstr1 = rowfilterstr1;
			}

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

			if(Context.Request.QueryString["pubcnttp"].ToString().Trim() != "")
			{
				strPubCountType = Context.Request.QueryString["pubcnttp"].ToString().Trim();
			}
			else
			{
				strPubCountType = strPubCountType;
				rowfilterstr1 = rowfilterstr1;
			}

			if(Context.Request.QueryString["fgmosea"].ToString().Trim() != "")
			{
				strfgMOSea = Context.Request.QueryString["fgmosea"].ToString().Trim();
				rowfilterstr1 = rowfilterstr1 + " AND or_fgmosea='" + strfgMOSea + "'";
				//rowfilterstr1 = rowfilterstr1 + " AND or_fgmosea='0'";
			}
			else
			{
				strfgMOSea = strfgMOSea;
				rowfilterstr1 = rowfilterstr1;
				//rowfilterstr1 = rowfilterstr1 + " AND or_fgmosea='1'";
			}

			if(Context.Request.QueryString["mtpcd"].ToString().Trim() != "")
			{
				strMtpcd = Context.Request.QueryString["mtpcd"].ToString().Trim();
				rowfilterstr1 = rowfilterstr1 + " AND or_mtpcd='" + strMtpcd + "'";
			}
			else
			{
				strMtpcd = strMtpcd;
				rowfilterstr1 = rowfilterstr1;
			}

			if(Context.Request.QueryString["bkpno"].ToString().Trim() != "")
			{
				strBookPNo = Context.Request.QueryString["bkpno"].ToString().Trim();
			}
			else
			{
				strBookPNo = strBookPNo;
				rowfilterstr1 = rowfilterstr1;
			}


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_cont");
			DataView dv1 = ds1.Tables["c2_cont"].DefaultView;

			// 依上述條件 做篩選動作
			dv1.RowFilter = rowfilterstr1;


			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			// 若搜尋結果為 "找不到" 的處理
			if (dv1.Count > 0)
			{
				if(strfgMOSea == "0")
				{
					DataList1.DataSource = dv1;
					DataList1.DataBind();


					for(int i=0; i < DataList1.Items.Count; i++)
					{
						// 書籍期別
						((Label)DataList1.Items[i].FindControl("lblBkpNo1")).Text = strBookPNo;
					}
				}
				else
				{
					DataList2.DataSource=dv1;
					DataList2.DataBind();


					for(int j=0; j < DataList2.Items.Count; j++)
					{
						// 書籍期別
						((Label)DataList2.Items[j].FindControl("lblBkpNo2")).Text = strBookPNo;
					}
				}
			// 結束 if (dv1.Count > 0)
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
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttpName", "cont_conttpName"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sedate", "cont_sedate"),
																																																				 new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																				 new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_mtpcd", "or_mtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_pubcnt", "or_pubcnt"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				 new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																				 new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																				 new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				 new System.Data.Common.DataColumnMapping("or_jbti", "or_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("bkp_pno", "bkp_pno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				 new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea")})});
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT DISTINCT TOP 100 PERCENT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, " +
				"dbo.c2_cont.cont_conttp, CASE WHEN dbo.c2_cont.cont_conttp = \'01\' THEN \'一般\' ELSE" +
				" \'推廣\' END AS cont_conttpName, dbo.c2_cont.cont_bkcd, RTRIM(dbo.book.bk_nm) AS bk" +
				"_nm, dbo.c2_cont.cont_signdate, RTRIM(dbo.c2_cont.cont_empno) AS cont_empno, RTR" +
				"IM(dbo.c2_cont.cont_mfrno) AS cont_mfrno, dbo.c2_cont.cont_sdate, dbo.c2_cont.co" +
				"nt_edate, SUBSTRING(dbo.c2_cont.cont_sdate, 1, 4) + \'/\' + SUBSTRING(dbo.c2_cont." +
				"cont_sdate, 5, 6) + \'~\' + SUBSTRING(dbo.c2_cont.cont_edate, 1, 4) + \'/\' + SUBSTR" +
				"ING(dbo.c2_cont.cont_edate, 5, 6) AS cont_sedate, dbo.c2_or.or_oritem, RTRIM(dbo" +
				".c2_or.or_inm) AS or_inm, RTRIM(dbo.c2_or.or_nm) AS or_nm, dbo.c2_or.or_mtpcd, R" +
				"TRIM(dbo.mtp.mtp_nm) AS mtp_nm, dbo.c2_or.or_pubcnt, RTRIM(dbo.srspn.srspn_cname" +
				") AS srspn_cname, dbo.c2_or.or_contno, dbo.c2_or.or_syscd, RTRIM(dbo.c2_or.or_zi" +
				"p) AS or_zip, RTRIM(dbo.c2_or.or_addr) AS or_addr, RTRIM(dbo.c2_or.or_jbti) AS o" +
				"r_jbti, RTRIM(dbo.bookp.bkp_pno) AS bkp_pno, dbo.c2_pub.pub_yyyymm, dbo.c2_or.or" +
				"_fgmosea FROM dbo.c2_cont INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.boo" +
				"k.bk_bkcd INNER JOIN dbo.c2_or ON dbo.c2_cont.cont_syscd = dbo.c2_or.or_syscd AN" +
				"D dbo.c2_cont.cont_contno = dbo.c2_or.or_contno INNER JOIN dbo.mtp ON dbo.c2_or." +
				"or_mtpcd = dbo.mtp.mtp_mtpcd INNER JOIN dbo.c2_pub ON dbo.c2_cont.cont_syscd = d" +
				"bo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contno INNER JO" +
				"IN dbo.srspn ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno INNER JOIN dbo.bo" +
				"okp ON dbo.c2_pub.pub_yyyymm = dbo.bookp.bkp_date AND dbo.c2_pub.pub_bkcd = dbo." +
				"bookp.bkp_bkcd WHERE (dbo.c2_cont.cont_fgclosed = \'0\') AND (dbo.c2_cont.cont_fgc" +
				"ancel = \'0\') AND (dbo.c2_cont.cont_fgtemp = \'0\') ORDER BY dbo.c2_or.or_pubcnt, d" +
				"bo.c2_cont.cont_contno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



	}
}
