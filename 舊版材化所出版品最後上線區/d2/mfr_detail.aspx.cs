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
// Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for mfr_detail.
	/// </summary>
	public class mfr_detail : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblMfrRespName;
		protected System.Web.UI.WebControls.Label lblMfrRespJobTitle;
		protected System.Web.UI.WebControls.Label lblMfrTel;
		protected System.Web.UI.WebControls.Label lblMfrID;
		protected System.Web.UI.WebControls.Label lblMfrName;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.Label lblMfrIName;
		protected System.Web.UI.WebControls.Label lblMfrRegDate;
		protected System.Web.UI.WebControls.Label lblMfrIZipcode;
		protected System.Web.UI.WebControls.Label lblMfrIAddr;
		protected System.Web.UI.WebControls.Label lblMfrFax;

		public mfr_detail()
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


				// 藉由前一網頁傳來的變數值字串 mfrno
				string mfrno = "";
				if(Context.Request.QueryString["mfrno"].ToString().Trim() != "")
				{
					mfrno = Context.Request.QueryString["mfrno"].ToString().Trim();
					//Response.Write("mfrno= " + mfrno + "<br>");

					// 檢查此廠商統編是否在資料庫中存在
					CheckExist();

				}
				else
				{
					Response.Write("<font size=2 color=red><b>資料庫中無此 廠商統編及其資料, 請先<A HREF='../d5/mfr_addnew.aspx' Target='_blank' OnClick='window.close()'>新增此廠商</A>!</b></font><br><br>");
				}

			}
		}


		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		// 檢查此客戶編號是否在資料庫中存在
		private void CheckExist()
		{
			// 藉由前一網頁傳來的變數值字串 custno
			string mfrno = Context.Request.QueryString["mfrno"].ToString().Trim();
			//Response.Write("mfrno= " + mfrno + "<br>");

			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "mfr");
			DataView dv1 = ds1.Tables["mfr"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			string rowfilterstr = "1=1";
			rowfilterstr = rowfilterstr + " AND mfr_mfrno='" + mfrno + "'";
			dv1.RowFilter = rowfilterstr;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
			if(dv1.Count <= 0)
			{
				Response.Write("<font size=2 color=red><b>資料庫中無此 廠商統編及其資料, 請先<A HREF='../d5/mfr_addnew.aspx' Target='_blank' OnClick='window.close()'>新增此廠商</A>!</b></font><br><br>");
			}
			else
			{
				// 若有此 廠商統編, 則顯示其相關資料
				GetData();
			}

		}


		private void GetData()
		{
			// 抓前一步驟來的 mfrno 變數值
			string mfrno = Context.Request.QueryString["mfrno"].ToString().Trim();
			//Response.Write("mfrno= " + mfrno + "<br>");

			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "mfr");
			DataView dv = ds.Tables["mfr"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			string rowfilterstr = "1=1";
			rowfilterstr = rowfilterstr + " AND mfr_mfrno='" + mfrno + "'";
			dv.RowFilter = rowfilterstr;

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv.Count= "+ dv.Count + "<BR>");
			//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");

			// 若有資料, 則顯示相關資料; 否則給予錯誤訊息
			if (dv.Count > 0)
			{
				// 顯示出所有的 dv 裡的資料, 並用 \ 符號隔開區別
				//for (int i =0; i < dv.Count; i++)
				//{
					//for (int j=0;j<10;j++)
						//Response.Write(j + ":" + dv[i][j] + "\\ ");
				//}

				// 填入資料
				this.lblMfrID.Text = dv[0]["mfr_mfrid"].ToString();
				this.lblMfrIName.Text = dv[0]["mfr_inm"].ToString();
				this.lblMfrNo.Text = dv[0]["mfr_mfrno"].ToString();

				string RegDate = dv[0]["mfr_regdate"].ToString();
				this.lblMfrRegDate.Text = RegDate.Substring(0, 4) + "/" + RegDate.Substring(4, 2) + "/" + RegDate.Substring(6, 2);

				this.lblMfrRespName.Text = dv[0]["mfr_respnm"].ToString();
				this.lblMfrRespJobTitle.Text = dv[0]["mfr_respjbti"].ToString();
				this.lblMfrTel.Text = dv[0]["mfr_tel"].ToString();
				this.lblMfrFax.Text = dv[0]["mfr_fax"].ToString();
				this.lblMfrIZipcode.Text = dv[0]["mfr_izip"].ToString();
				this.lblMfrIAddr.Text = dv[0]["mfr_iaddr"].ToString();
			}
			else
			{
				// 若找無資料, 則清除資料
				this.lblMfrIName.Text = "(<font color='RED'>查無此廠商統編, 請先<A HREF='../d5/mfr_addnew.aspx' Target='_blank' OnClick='window.close()'>新增此廠商</A>!</font>)";
				this.lblMfrNo.Text = "";
				this.lblMfrRespName.Text = "";
				this.lblMfrRespJobTitle.Text = "";
				this.lblMfrTel.Text = "";
				this.lblMfrFax.Text = "";
				this.lblMfrIZipcode.Text = "";
				this.lblMfrIAddr.Text = "";
				this.lblMfrRegDate.Text = "";
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
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mfr", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_tel", "mfr_tel"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_fax", "mfr_fax"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_regdate", "mfr_regdate")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT mfr_mfrid, mfr_mfrno, mfr_inm, mfr_iaddr, mfr_izip, mfr_respnm, mfr_respjb" +
				"ti, mfr_tel, mfr_fax, mfr_regdate FROM mfr";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
//				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	}
}
