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
	/// Summary description for iaFm2_RecAll.
	/// </summary>
	public class iaFm2_RecAll : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnClear;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblMemo1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblIabNo;
		protected System.Web.UI.WebControls.Label lblIabDate;
		protected System.Web.UI.WebControls.TextBox tbxIabDate;
		protected System.Web.UI.WebControls.TextBox tbxIabNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.Button btnRecovery;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Web.UI.WebControls.Panel pnlQuery;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpCName;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.RegularExpressionValidator revIabSeq;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPubDate;
		protected System.Web.UI.WebControls.Label lblMemo2;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if(!Page.IsPostBack)
			{
				Response.Expires = 0;

				InitialData();
			}
		}


		// 顯示預設資料
		private void InitialData()
		{
			this.tbxIabDate.Text = System.DateTime.Today.ToString("yyyy/MM");
			this.tbxIabNo.Text = "";
			this.lblMessage.Text = "";

			this.DataGrid1.Visible = false;
			this.btnRecovery.Visible = false;
			this.btnPrintList.Visible =false;

			// 抓取登入業務員資訊 - 工號及姓名
			GetLoginEmpInfo();
		}


		// 抓取登入業務員資訊 - 工號及姓名
		private void GetLoginEmpInfo()
		{
			// 抓出登入者的工號, 作為預設 製表業務員 之值
			string LoginEmpNo = "";
			string LoginEmpCName = "";
			//Response.Write("LoginEmpNo= " + User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) + "<br>");
			// 若有登入者的資料, 則抓出並預選 建檔業務員之下拉式選單
			if(User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1)!=null && User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) != "")
			{
				LoginEmpNo = User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);


				// 使用 DataSet 方法, 並指定使用的 table 名稱
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "srspn");
				DataView dv2 = ds2.Tables["srspn"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				string rowfilterstr2 = "1=1";
				rowfilterstr2 = rowfilterstr2 + " AND srspn_empno='" + LoginEmpNo + "'";
				dv2.RowFilter = rowfilterstr2;

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
				//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

				// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
				if(dv2.Count > 0)
				{
					LoginEmpCName = dv2[0]["srspn_cname"].ToString().Trim();
				}
				else
				{
					LoginEmpCName = "(不詳)";
				}
			}
			this.tbxLoginEmpNo.Text = LoginEmpNo;
			this.tbxLoginEmpCName.Text = LoginEmpCName;
			//Response.Write("LoginEmpNo= " + LoginEmpNo + "<br>");
			//Response.Write("LoginEmpCName= " + LoginEmpCName + "<br>");
		}


		// 查詢 按鈕的處理
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			if(this.tbxIabDate.Text.ToString().Trim() != "" && this.tbxIabNo.Text.ToString().Trim() != "")
			{
				BindGrid1();
			}
			else
			{
				this.lblMessage.Text = "很抱歉, 您必須輸入查詢條件, 才能繼續!";
			}

		}


		// 清除重查 按鈕的處理
		private void btnClear_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("iaFm2_RecAll.aspx");
			//InitialData();
		}


		// 顯示 DataGrid1
		private void BindGrid1()
		{
			// 抓出畫面上的值
			string strIabDate = this.tbxIabDate.Text.ToString().Trim();
			strIabDate = strIabDate.Substring(0, 4) + strIabDate.Substring(5, 2);
			string strIabSeq = this.tbxIabNo.Text.ToString().Trim();
			//Response.Write("strIabDate= " + strIabDate + "<br>");
			//Response.Write("strIabSeq= " + strIabSeq + "<br>");


			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "ia");
			DataView dv1 = ds1.Tables["ia"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";
			if(strIabDate != "")
				rowfilterstr1 = rowfilterstr1 + " AND ia_iabdate = '" + strIabDate + "'";
			if(strIabSeq != "")
				rowfilterstr1 = rowfilterstr1 + " AND ia_iabseq = '" + strIabSeq + "'";
			dv1.RowFilter = rowfilterstr1;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			if(dv1.Count > 0)
			{
				this.DataGrid1.Visible = true;
				this.btnRecovery.Visible = true;
				this.btnPrintList.Visible = true;

				DataGrid1.DataSource = dv1;
				DataGrid1.DataBind();


				this.lblMessage.Text = "查有 " + dv1.Count + " 筆資料";


				// 特別欄位之輸出格式轉換 - 變更簽約日期的格式
				for(int i=0; i< DataGrid1.Items.Count; i++)
				{
					// 發票類別
					string invcd = DataGrid1.Items[i].Cells[8].Text.ToString().Trim();
					//Response.Write("invcd= " + invcd + "<br>");
					switch (invcd)
					{
						case "2":
							DataGrid1.Items[i].Cells[8].Text = "二聯";
							break;
						case "3":
							DataGrid1.Items[i].Cells[8].Text = "三聯";
							break;
						case "4":
							DataGrid1.Items[i].Cells[8].Text = "其他";
							break;
						case "9":
							DataGrid1.Items[i].Cells[8].Text = "不清楚";
							DataGrid1.Items[i].Cells[8].ForeColor = Color.Red;
							break;
						default:
							DataGrid1.Items[i].Cells[8].Text = "三聯";
							break;
					}

					// 發票課稅別
					string taxtp = DataGrid1.Items[i].Cells[9].Text.ToString().Trim();
					//Response.Write("taxtp= " + taxtp + "<br>");
					switch (taxtp)
					{
						case "1":
							DataGrid1.Items[i].Cells[9].Text = "應稅5%";
							break;
						case "2":
							DataGrid1.Items[i].Cells[9].Text = "零稅";
							break;
						case "3":
							DataGrid1.Items[i].Cells[9].Text = "免稅";
							break;
						case "9":
							DataGrid1.Items[i].Cells[9].Text = "不清楚";
							DataGrid1.Items[i].Cells[9].ForeColor = Color.Red;
							break;
						default:
							DataGrid1.Items[i].Cells[9].Text = "應稅5%";
							break;
					}

					// 刊登年月
					string yyyymm = DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
					//Response.Write("yyyymm= " + yyyymm + "<br>");
					yyyymm = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
					DataGrid1.Items[i].Cells[12].Text = yyyymm;
				}
			}
			else
			{
				this.DataGrid1.Visible = false;
				this.btnRecovery.Visible = false;
				this.btnPrintList.Visible = false;
				this.lblMessage.Text = "查無資料(或已於會計系統中處理), 或請重新輸入查詢條件!";
			}
		}


		// 列印回復清單 按鈕的處理
		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			// 抓出畫面上的值, 作為篩選資料的條件
			string strIabDate = this.tbxIabDate.Text.ToString().Trim();
			strIabDate = strIabDate.Substring(0, 4) + strIabDate.Substring(5, 2);
			string strIabSeq = this.tbxIabNo.Text.ToString().Trim();
			string strLEmpNo = this.tbxLoginEmpNo.Text.ToString().Trim();
			//Response.Write("strIabDate= " + strIabDate + "<br>");
			//Response.Write("strIabSeq= " + strIabSeq + "<br>");
			//Response.Write("strLEmpNo= " + strLEmpNo + "<br>");


			// 開啟小視窗
			string strbuf = "iaFm2_RecList.aspx?iabdate=" + strIabDate + "&iabseq=" + strIabSeq + "&LEmpNo=" + strLEmpNo;
			//Response.Write(strbuf);
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}


		// 確認回復 按鈕的處理
		private void btnRecovery_Click(object sender, System.EventArgs e)
		{
			// 抓出畫面上的值
			string strIabDate = this.tbxIabDate.Text.ToString().Trim();
			strIabDate = strIabDate.Substring(0, 4) + strIabDate.Substring(5, 2);
			string strIabSeq = this.tbxIabNo.Text.ToString().Trim();
			//Response.Write("strIabDate= " + strIabDate + "<br>");
			//Response.Write("strIabSeq= " + strIabSeq + "<br>");


			for(int i=0; i < DataGrid1.Items.Count; i++)
			{
				// 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 更新
				//Response.Write(this.sqlCommand1.CommandText);
				this.sqlCommand1.Parameters["@iabdate"].Value = strIabDate;
				this.sqlCommand1.Parameters["@iabseq"].Value = strIabSeq;

				// 確認執行 sqlCommand1 成功
				this.sqlCommand1.Connection.Open();
				// 使用 Transaction 確認有執行動作
				System.Data.SqlClient.SqlTransaction myTrans1 = this.sqlCommand1.Connection.BeginTransaction();
				this.sqlCommand1.Transaction = myTrans1;
				try
				{
					this.sqlCommand1.ExecuteNonQuery();
					myTrans1.Commit();
					//Response.Write("落版資料更新成功");
					this.lblMessage.Text = "回復成功!<br>";

					this.DataGrid1.Visible = false;
					this.lblMemo2.Visible = false;
					this.btnRecovery.Visible = false;
					this.btnPrintList.Visible = false;
				}
				catch(System.Data.SqlClient.SqlException ex1)
				{
					Response.Write(ex1.Message + "<br>");
					myTrans1.Rollback();
					this.lblMessage.Text = "回復失敗!<br>";
					//Response.Write("回復失敗");
				}
				finally
				{
					this.sqlCommand1.Connection.Close();
				}
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
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "ia", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd"),
																																																			new System.Data.Common.DataColumnMapping("ia_iano", "ia_iano"),
																																																			new System.Data.Common.DataColumnMapping("ia_mfrno", "ia_mfrno"),
																																																			new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			new System.Data.Common.DataColumnMapping("ia_rnm", "ia_rnm"),
																																																			new System.Data.Common.DataColumnMapping("ia_rjbti", "ia_rjbti"),
																																																			new System.Data.Common.DataColumnMapping("ia_rzip", "ia_rzip"),
																																																			new System.Data.Common.DataColumnMapping("ia_raddr", "ia_raddr"),
																																																			new System.Data.Common.DataColumnMapping("ia_rtel", "ia_rtel"),
																																																			new System.Data.Common.DataColumnMapping("ia_invcd", "ia_invcd"),
																																																			new System.Data.Common.DataColumnMapping("ia_taxtp", "ia_taxtp"),
																																																			new System.Data.Common.DataColumnMapping("iad_iaditem", "iad_iaditem"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk1", "iad_fk1"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk2", "iad_fk2"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk3", "iad_fk3"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk4", "iad_fk4"),
																																																			new System.Data.Common.DataColumnMapping("iad_desc", "iad_desc"),
																																																			new System.Data.Common.DataColumnMapping("iad_projno", "iad_projno"),
																																																			new System.Data.Common.DataColumnMapping("iad_costctr", "iad_costctr"),
																																																			new System.Data.Common.DataColumnMapping("iad_qty", "iad_qty"),
																																																			new System.Data.Common.DataColumnMapping("iad_amt", "iad_amt"),
																																																			new System.Data.Common.DataColumnMapping("ia_iabdate", "ia_iabdate"),
																																																			new System.Data.Common.DataColumnMapping("ia_iabseq", "ia_iabseq"),
																																																			new System.Data.Common.DataColumnMapping("iad_iano", "iad_iano"),
																																																			new System.Data.Common.DataColumnMapping("iad_syscd", "iad_syscd"),
																																																			new System.Data.Common.DataColumnMapping("ia_cname", "ia_cname"),
																																																			new System.Data.Common.DataColumnMapping("iab_createdate", "iab_createdate"),
																																																			new System.Data.Common.DataColumnMapping("iab_createmen", "iab_createmen"),
																																																			new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			new System.Data.Common.DataColumnMapping("iab_iabdate", "iab_iabdate"),
																																																			new System.Data.Common.DataColumnMapping("iab_iabseq", "iab_iabseq"),
																																																			new System.Data.Common.DataColumnMapping("iab_syscd", "iab_syscd")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.ia.ia_syscd, dbo.ia.ia_iano, RTRIM(dbo.ia.ia_mfrno) AS ia_mfrno, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, RTRIM(dbo.ia.ia_rnm) AS ia_rnm, RTRIM(dbo.ia.ia_rjbti) AS ia_rjbti, RTRIM(dbo.ia.ia_rzip) AS ia_rzip, RTRIM(dbo.ia.ia_raddr) AS ia_raddr, RTRIM(dbo.ia.ia_rtel) AS ia_rtel, dbo.ia.ia_invcd, dbo.ia.ia_taxtp, dbo.iad.iad_iaditem, RTRIM(dbo.iad.iad_fk1) AS iad_fk1, RTRIM(dbo.iad.iad_fk2) AS iad_fk2, RTRIM(dbo.iad.iad_fk3) AS iad_fk3, RTRIM(dbo.iad.iad_fk4) AS iad_fk4, RTRIM(dbo.iad.iad_desc) AS iad_desc, dbo.iad.iad_projno, dbo.iad.iad_costctr, dbo.iad.iad_qty, dbo.iad.iad_amt, dbo.ia.ia_iabdate, dbo.ia.ia_iabseq, dbo.iad.iad_iano, dbo.iad.iad_syscd, RTRIM(dbo.ia.ia_cname) AS ia_cname, dbo.iab.iab_createdate, RTRIM(dbo.iab.iab_createmen) AS iab_createmen, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname, dbo.iab.iab_iabdate, dbo.iab.iab_iabseq, dbo.iab.iab_syscd FROM dbo.ia INNER JOIN dbo.iad ON dbo.ia.ia_syscd = dbo.iad.iad_syscd AND dbo.ia.ia_iano = dbo.iad.iad_iano INNER JOIN dbo.mfr ON dbo.ia.ia_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.iab ON dbo.ia.ia_syscd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.iab.iab_syscd AND dbo.ia.ia_iabdate = dbo.iab.iab_iabdate AND dbo.ia.ia_iabseq = dbo.iab.iab_iabseq INNER JOIN dbo.srspn ON dbo.iab.iab_createmen COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.srspn.srspn_empno WHERE (dbo.ia.ia_syscd = 'C2') AND (dbo.ia.ia_status = ' ') ORDER BY dbo.ia.ia_iano, dbo.ia.ia_mfrno, dbo.ia.ia_rnm";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
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
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel" +
				", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srsp" +
				"n_empno FROM dbo.srspn WHERE (srspn_atype <> \'a\') AND (srspn_atype <> \'d\')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlCommand1
			//
			this.sqlCommand1.CommandText = "dbo.[sp_c2_delete_ia_all]";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iabdate", System.Data.SqlDbType.VarChar, 6));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iabseq", System.Data.SqlDbType.VarChar, 6));
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.btnRecovery.Click += new System.EventHandler(this.btnRecovery_Click);
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



	}
}
