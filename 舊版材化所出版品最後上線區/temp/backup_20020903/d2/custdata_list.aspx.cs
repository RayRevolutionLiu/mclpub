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
	/// Summary description for custdata_list.
	/// </summary>
	public class custdata_list : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox tbxCustNoQ1;
		protected System.Web.UI.WebControls.TextBox tbxCustNoQ2;
		protected System.Web.UI.WebControls.TextBox tbxTelAC;
		protected System.Web.UI.WebControls.DropDownList ddlItpcd;
		protected System.Web.UI.WebControls.DropDownList ddlBtpcd;
		protected System.Web.UI.WebControls.DropDownList ddlRtpcd;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.CheckBox cbx2;
		protected System.Web.UI.WebControls.CheckBox cbx3;
		protected System.Web.UI.WebControls.CheckBox cbx4;
		protected System.Web.UI.WebControls.CheckBox cbx5;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
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
				this.tbxCustNoQ1.Text = "";
				this.tbxCustNoQ2.Text = "";
				this.tbxTelAC.Text = "";
				this.ddlItpcd.SelectedIndex = 0;
				this.ddlBtpcd.SelectedIndex = 0;
				this.ddlRtpcd.SelectedIndex = 0;
				this.cbx1.Checked = false;
				this.cbx2.Checked = false;
				this.cbx3.Checked = false;
				this.cbx4.Checked = false;
				this.cbx5.Checked = false;
				
				
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
				
				// 顯示下拉式選單 客戶閱讀代碼的 DB 值
				DataSet ds3 = new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "rtp");
				this.ddlRtpcd.DataSource=ds3;
				this.ddlRtpcd.DataTextField="rtp_nm";
				this.ddlRtpcd.DataValueField="rtp_rtpcd";
				this.ddlRtpcd.DataBind();
				
				
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT itp_itpcd, itp_nm FROM itp";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "itp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("itp_itpcd", "itp_itpcd"),
																																																			 new System.Data.Common.DataColumnMapping("itp_nm", "itp_nm")})});
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
			this.sqlSelectCommand2.CommandText = "SELECT btp_btpcd, btp_nm FROM btp";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "rtp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("rtp_rtpcd", "rtp_rtpcd"),
																																																			 new System.Data.Common.DataColumnMapping("rtp_nm", "rtp_nm")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT rtp_rtpcd, rtp_nm FROM rtp";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			// 抓出所選取的業務員工號
			string CustNoQ1 = "";
			string CustNoQ2 = "";
			string TelAC = "";
			string Itpcd = "";
			string Btpcd = "";
			string Rtpcd = "";
			string strbuf="custdata_list2.aspx?";
			
			if(cbx1.Checked)
			{
				CustNoQ1 = this.tbxCustNoQ1.Text.ToString().Trim();
				CustNoQ2 = this.tbxCustNoQ2.Text.ToString().Trim();
				strbuf = strbuf + "CustNoQ1=" + CustNoQ1 + "&CustNoQ2=" + CustNoQ2 + "&";
				//Response.Write("CustNoQ1= " + CustNoQ1 + "<br>");
				//Response.Write("CustNoQ2= " + CustNoQ2 + "<br>");
			}
			
			if(cbx2.Checked)
			{
				TelAC = this.tbxTelAC.Text.ToString().Trim();
				strbuf = strbuf + "TelAC=" + TelAC + "&";
				//Response.Write("TelAC= " + TelAC + "<br>");
			}
			
			if(cbx3.Checked)
			{
				Itpcd = this.ddlItpcd.SelectedItem.Value.ToString().Trim();
				strbuf = strbuf + "Itpcd=" + Itpcd + "&";
				//Response.Write("Itpcd= " + Itpcd + "<br>");
			}
			
			if(cbx4.Checked)
			{
				Btpcd = this.ddlBtpcd.SelectedItem.Value.ToString().Trim();
				strbuf = strbuf + "Btpcd=" + Btpcd + "&";
				//Response.Write("Btpcd= " + Btpcd + "<br>");
			}
			
			if(cbx5.Checked)
			{
				Rtpcd = this.ddlRtpcd.SelectedItem.Value.ToString().Trim();
				strbuf = strbuf + "Rtpcd=" + Rtpcd + "&";
				//Response.Write("Rtpcd= " + Rtpcd + "<br>");
			}
			//Response.Write("custdata_list2.aspx?CustNoQ1=" + CustNoQ1 + "&CustNoQ2=" + CustNoQ2 + "&TelAC=" + TelAC + "&Itpcd=" + Itpcd + "&Btpcd=" + Btpcd + "&Rtpcd=" + Rtpcd + "<br>");
			//Response.Write("strbuf= " + strbuf + "<br>");
			
			
			// 轉址: 執行 ExcelSpeedGen
			//Response.Redirect("custdata_list2.aspx");
			Response.Redirect(strbuf);
			
		}
	}
}
