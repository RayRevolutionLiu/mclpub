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
	/// Summary description for custdata_list.
	/// </summary>
	public class custdata_list : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox tbxCustNoQ1;
		protected System.Web.UI.WebControls.TextBox tbxCustNoQ2;
		protected System.Web.UI.WebControls.TextBox tbxTelAC;
		protected System.Web.UI.WebControls.DropDownList ddlItpcd;
		protected System.Web.UI.WebControls.DropDownList ddlBtpcd;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.CheckBox cbx2;
		protected System.Web.UI.WebControls.CheckBox cbx3;
		protected System.Web.UI.WebControls.CheckBox cbx4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.LinkButton lnbClearAll;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Label lblMemo;

		public custdata_list()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				// 清除畫面資料
				this.Literal1.Text = "";
				this.tbxCustNoQ1.Text = "";
				this.tbxCustNoQ2.Text = "";
				this.tbxTelAC.Text = "";
				this.ddlItpcd.SelectedIndex = 0;
				this.ddlBtpcd.SelectedIndex = 0;
//				this.ddlRtpcd.SelectedIndex = 0;
				this.cbx1.Checked = false;
				this.cbx2.Checked = false;
				this.cbx3.Checked = false;
				this.cbx4.Checked = false;
//				this.cbx5.Checked = false;


				// 顯示下拉式選單 客戶領域代碼的 DB 值
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "itp");
				this.ddlItpcd.DataSource=ds1;
				this.ddlItpcd.DataTextField="itp_nm";
				this.ddlItpcd.DataValueField="itp_itpcd";
				this.ddlItpcd.DataBind();

				// 顯示下拉式選單 客戶營業代碼的 DB 值
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "btp");
				this.ddlBtpcd.DataSource=ds2;
				this.ddlBtpcd.DataTextField="btp_nm";
				this.ddlBtpcd.DataValueField="btp_btpcd";
				this.ddlBtpcd.DataBind();

			}
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		// 按下 查詢 按鈕的處理
		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			// 抓出所選取的查詢條件
			this.Literal1.Text = "";
			string CustNoQ1 = "";
			string CustNoQ2 = "";
			string TelAC = "";
			string Itpcd = "";
			string Btpcd = "";
//			string Rtpcd = "";
			string strbuf="custdata_list2.aspx?";

			// 若勾選查詢條件一時
			if(cbx1.Checked)
			{
				CustNoQ1 = this.tbxCustNoQ1.Text.ToString().Trim();
				CustNoQ2 = this.tbxCustNoQ2.Text.ToString().Trim();
				strbuf = strbuf + "CustNoQ1=" + CustNoQ1 + "&CustNoQ2=" + CustNoQ2 + "&";
				//Response.Write("CustNoQ1= " + CustNoQ1 + "<br>");
				//Response.Write("CustNoQ2= " + CustNoQ2 + "<br>");
			}

			// 若勾選查詢條件二時
			if(cbx2.Checked)
			{
				TelAC = this.tbxTelAC.Text.ToString().Trim();
				strbuf = strbuf + "TelAC=" + TelAC + "&";
				//Response.Write("TelAC= " + TelAC + "<br>");
			}

			// 若勾選查詢條件三時
			if(cbx3.Checked)
			{
				Itpcd = this.ddlItpcd.SelectedItem.Value.ToString().Trim();
				strbuf = strbuf + "Itpcd=" + Itpcd + "&";
				//Response.Write("Itpcd= " + Itpcd + "<br>");
			}

			// 若勾選查詢條件四時
			if(cbx4.Checked)
			{
				Btpcd = this.ddlBtpcd.SelectedItem.Value.ToString().Trim();
				strbuf = strbuf + "Btpcd=" + Btpcd + "&";
				//Response.Write("Btpcd= " + Btpcd + "<br>");
			}

			//			// 若勾選查詢條件五時
			//			if(cbx5.Checked)
			//			{
			//				Rtpcd = this.ddlRtpcd.SelectedItem.Value.ToString().Trim();
			//				strbuf = strbuf + "Rtpcd=" + Rtpcd + "&";
			//				//Response.Write("Rtpcd= " + Rtpcd + "<br>");
			//			}
			//			//Response.Write("custdata_list2.aspx?CustNoQ1=" + CustNoQ1 + "&CustNoQ2=" + CustNoQ2 + "&TelAC=" + TelAC + "&Itpcd=" + Itpcd + "&Btpcd=" + Btpcd + "&Rtpcd=" + Rtpcd + "<br>");
			//			//Response.Write("strbuf= " + strbuf + "<br>");
			//

			// 轉址: 執行 ExcelSpeedGen
			//Response.Redirect(strbuf);
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}


		// 清除重查 按鈕的處理
		private void lnbClearAll_Click(object sender, System.EventArgs e)
		{
			// 轉址
			Response.Redirect("custdata_list.aspx");
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
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.lnbClearAll.Click += new System.EventHandler(this.lnbClearAll_Click);
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "itp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("itp_itpcd", "itp_itpcd"),
																																																			 new System.Data.Common.DataColumnMapping("itp_nm", "itp_nm")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT itp_itpcd, itp_nm FROM dbo.itp";
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
																									  new System.Data.Common.DataTableMapping("Table", "btp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("btp_btpcd", "btp_btpcd"),
																																																			 new System.Data.Common.DataColumnMapping("btp_nm", "btp_nm")})});
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT btp_btpcd, btp_nm FROM dbo.btp";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
