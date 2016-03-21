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
	/// Summary description for ORCounts_stat_search2.
	/// </summary>
	public class ORCounts_stat_search2 : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Web.UI.WebControls.TextBox tbxPubDate;
		protected System.Web.UI.WebControls.Label lblfgMOSea;
		protected System.Web.UI.WebControls.DropDownList ddlfgMOSea;
		protected System.Web.UI.WebControls.Label lblMtpcd;
		protected System.Web.UI.WebControls.DropDownList ddlMtpcd;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.LinkButton lnbClearAll;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.CheckBox cbx2;
		protected System.Web.UI.WebControls.CheckBox cbx0;
		protected System.Web.UI.WebControls.Label lblConttp;
		protected System.Web.UI.WebControls.DropDownList ddlConttp;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPubDate;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpCName;

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


		// 給預設值
		private void InitialData()
		{
			this.lblMessage.Text = "";
			this.Literal1.Text = "";


			// 顯示下拉式選單 書籍類別的 DB 值
			// 關於 nostr, 請參 sqlDataAdapter3.Select statement;
			// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "book");
			DataView dv1=ds1.Tables["book"].DefaultView;
			ddlBookCode.DataSource=dv1;
			dv1.RowFilter="proj_fgitri=''";
			ddlBookCode.DataTextField="bk_nm";
			//ddlBookCode.DataValueField="nostr";
			// 同維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
			ddlBookCode.DataValueField="bk_bkcd";
			ddlBookCode.DataBind();


			// 顯示下拉式選單 業務員 DB 值
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "mtp");
			DataView dv2=ds2.Tables["mtp"].DefaultView;
			ddlMtpcd.DataSource=dv2;
			ddlMtpcd.DataTextField="mtp_nm";
			ddlMtpcd.DataValueField="mtp_mtpcd";
			ddlMtpcd.DataBind();


			this.cbx0.Checked = false;
			this.cbx1.Checked = false;
			this.cbx2.Checked = false;
			this.ddlBookCode.SelectedIndex = 0;
			this.ddlConttp.SelectedIndex = 0;
			this.ddlfgMOSea.ClearSelection();
			this.ddlfgMOSea.SelectedIndex = 0;
			this.ddlMtpcd.SelectedIndex = 0;


			this.tbxPubDate.Text = System.DateTime.Today.ToString("yyyy/MM");


			// 抓取登入業務員資訊 - 工號及姓名
			GetLoginEmpInfo();
		}


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
				DataSet ds3 = new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "srspn");
				DataView dv3 = ds3.Tables["srspn"].DefaultView;

				// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
				string rowfilterstr3 = "1=1";
				rowfilterstr3 = rowfilterstr3 + " AND srspn_empno='" + LoginEmpNo + "'";
				dv3.RowFilter = rowfilterstr3;

				// 檢查並輸出 最後 Row Filter 的結果
				//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
				//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

				// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
				if(dv3.Count > 0)
				{
					LoginEmpCName = dv3[0]["srspn_cname"].ToString().Trim();
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
		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			this.Literal1.Text = "";
			CountData();
		}


		// 統計結果
		private void CountData()
		{
			this.Literal1.Text = "";


			// 抓出篩選條件
			string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			string strConttp = this.ddlConttp.SelectedItem.Value.ToString();
			string fgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();
			string Mtpcd = this.ddlMtpcd.SelectedItem.Value.ToString().Trim();
			string LoginEmpNo = this.tbxLoginEmpNo.Text.ToString().Trim();
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");
			//Response.Write("strConttp= " + strConttp + "<br>");
			//Response.Write("fgMOSea= " + fgMOSea + "<br>");
			//Response.Write("Mtpcd= " + Mtpcd + "<br>");
			//Response.Write("LoginEmpNo= " + LoginEmpNo + "<br>");

			// 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 新增入資料庫
			//Response.Write(this.sqlCommand1.CommandText);
			this.sqlCommand1.Parameters["@bkcd"].Value = strBkcd;
			this.sqlCommand1.Parameters["@yyyymm"].Value = strYYYYMM;
			DataSet xrds = new DataSet();

			// 確認執行 sqlCommand1 成功
			bool ResultFlag1 = false;
			this.sqlCommand1.Connection.Open();
			// 使用 Transaction 確認有執行動作
			System.Data.SqlClient.SqlTransaction myTrans1 = this.sqlCommand1.Connection.BeginTransaction();
			this.sqlCommand1.Transaction = myTrans1;
			//Response.Write(sqlCommand1.Parameters.Count.ToString().Trim());
			try
			{
				//System.Xml.XmlReader xr = this.sqlCommand1.ExecuteXmlReader();
				//xrds.ReadXml(xr, XmlReadMode.Fragment);
				System.Data.SqlClient.SqlDataAdapter da1 = new System.Data.SqlClient.SqlDataAdapter();
				da1.SelectCommand = this.sqlCommand1;
				da1.Fill(xrds, "c2_cont");
				myTrans1.Commit();
			}
			catch(System.Data.SqlClient.SqlException ex1)
			{
				Response.Write(ex1.Message + "<br>");
				myTrans1.Rollback();
			}
			finally
			{
				this.sqlCommand1.Connection.Close();
			}

			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataView dv3 = xrds.Tables["c2_cont"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr3 = "1=1";

			// 合約類別
			if(this.cbx0.Checked)
			{
				rowfilterstr3 = rowfilterstr3 + " AND cont_conttp='" + strConttp + "'";
			}
			else
			{
				rowfilterstr3 = rowfilterstr3;
			}

			// 郵寄地區
			if(this.cbx1.Checked)
			{
				rowfilterstr3 = rowfilterstr3 + " AND or_fgmosea='" + fgMOSea + "'";
			}
			else
			{
				rowfilterstr3 = rowfilterstr3;
			}

			// 郵寄類別
			if(this.cbx2.Checked)
			{
				rowfilterstr3 = rowfilterstr3 + " AND or_mtpcd='" + Mtpcd + "'";
			}
			else
			{
				rowfilterstr3 = rowfilterstr3;
			}
			dv3.RowFilter = rowfilterstr3;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

			// 若有資料須修正時, 顯示 DataGrid1
			if(dv3.Count > 0)
			{
				// 轉址
				// 書籍類別 & 刊登年月 篩選條件
				string RedirectURL = "ORCounts_stat2b.aspx?bkcd=" + strBkcd + "&yyyymm=" + strYYYYMM;
				// 合約類別 篩選條件
				if(this.cbx0.Checked)
				{
					RedirectURL = RedirectURL + "&conttp=" + strConttp;
				}
				else
				{
					RedirectURL = RedirectURL + "&conttp=";
				}

				if(this.cbx1.Checked)
				{
					RedirectURL = RedirectURL + "&fgmosea=" + fgMOSea;
				}
				else
				{
					RedirectURL = RedirectURL;
				}

				if(this.cbx2.Checked)
				{
					RedirectURL = RedirectURL + "&mtpcd=" + Mtpcd;
				}
				else
				{
					RedirectURL = RedirectURL + "&mtpcd=";
				}
				RedirectURL = RedirectURL + "&LEmpno=" + LoginEmpNo;
				//Response.Write("RedirectURL= " + RedirectURL + "<br>");

				this.lblMessage.Text="結果: 找到 <B>" + dv3.Count + "</B>筆資料; 請繼續按 <A HREF='" + RedirectURL + "' Target='_blank'>此連結</A> 來繼續進行下一動作!<br>";
			}
			else
			{
				this.lblMessage.Text = "查無資料, 請重新輸入查詢條件!";
			}
		}


		// 郵寄地區(國內外註記) 勾選變更的處理
		private void cbx1_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.cbx1.Checked)
			{
				this.cbx1.Checked = true;
			}
			else
			{
				this.cbx1.Checked = false;
			}
		}


		// 郵寄地區(國內外註記) 勾選變更的處理
		private void ddlfgMOSea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string strfgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();
			//Response.Write("strfgMOSea= " + strfgMOSea + "<br>");

			if(strfgMOSea == "1")
			{
				this.cbx1.Checked = true;
				this.cbx2.Checked = false;
				this.ddlMtpcd.ClearSelection();
				this.ddlMtpcd.Items.FindByValue("24").Selected = true;

				// 以 Javascript 的 window.alert()  來告知訊息
				LiteralControl litAlertError = new LiteralControl();
				litAlertError.Text = "<script language=javascript>alert(\"請選擇您要的 '國外-郵寄類別',\n然後再按一下 '查詢' 按鈕!\");</script>";
				Page.Controls.Add(litAlertError);
			}
			else
			{
				this.cbx1.Checked = false;
				this.cbx2.Checked = false;
				this.ddlMtpcd.ClearSelection();
				this.ddlMtpcd.Items.FindByValue("11").Selected = true;
			}
		}


		// 郵寄類別 勾選變更的處理
		private void cbx2_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.cbx2.Checked)
			{
				this.cbx1.Checked = true;
			}
			else
			{
				this.cbx1.Checked = false;
			}
		}


		// 下拉式選單 郵寄類別 變更的處理
		private void ddlMtpcd_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int intMtpcd = Convert.ToInt32(this.ddlMtpcd.SelectedItem.Value.ToString().Trim());
			//Response.Write("intMtpcd= " + intMtpcd + "<br>");

			if(intMtpcd >= 20)
			{
				this.cbx1.Checked = true;
				this.ddlfgMOSea.SelectedIndex = 1;
				this.cbx2.Checked = true;
			}
			else
			{
				this.cbx1.Checked = true;
				this.ddlfgMOSea.SelectedIndex = 0;
				this.cbx2.Checked = true;
			}
		}


		// 清除重查 按鈕的處理
		private void lnbClearAll_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ORCounts_stat_search2.aspx");
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
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.cbx1.CheckedChanged += new System.EventHandler(this.cbx1_CheckedChanged);
			this.ddlfgMOSea.SelectedIndexChanged += new System.EventHandler(this.ddlfgMOSea_SelectedIndexChanged);
			this.cbx2.CheckedChanged += new System.EventHandler(this.cbx2_CheckedChanged);
			this.ddlMtpcd.SelectedIndexChanged += new System.EventHandler(this.ddlMtpcd_SelectedIndexChanged);
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.lnbClearAll.Click += new System.EventHandler(this.lnbClearAll_Click);
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (dbo.proj.proj_fgitri = ' ')";
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
																									  new System.Data.Common.DataTableMapping("Table", "mtp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mtp_mtpcd", "mtp_mtpcd"),
																																																			 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm")})});
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT mtp_mtpcd, RTRIM(mtp_nm) AS mtp_nm FROM dbo.mtp";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = "SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel" +
				", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srsp" +
				"n_empno FROM dbo.srspn";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			//
			// sqlCommand1
			//
			this.sqlCommand1.CommandText = "dbo.[sp_c2_ORCounts_stat2b]";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
