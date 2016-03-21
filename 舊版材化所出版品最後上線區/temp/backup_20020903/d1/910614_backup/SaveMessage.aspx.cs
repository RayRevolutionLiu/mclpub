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
using System.Configuration;

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for SaveMessage.
	/// </summary>
	public class SaveMessage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.HtmlControls.HtmlAnchor hp1;
		protected System.Web.UI.HtmlControls.HtmlAnchor hp2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Label lblMessage;
	
		public SaveMessage()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				hp1.Visible=false;
//				hp2.Visible=false;
				switch (Context.Request.QueryString["str"])
				{
					case "newcust":
						lblMessage.Text="新增訂戶資料已完成";
						hp1.Visible=true;
//						hp2.Visible=true;
						break;
					case "bulk":
						lblMessage.Text="所選贈閱訂戶之續訂動作已完成";
						break;
					case "modify":
						lblMessage.Text="訂單修改動作已完成";
						break;
					case "newlost":
						lblMessage.Text="缺書登錄已完成";
						break;
					case "modlost":
						lblMessage.Text="修改缺書資料已完成";
						break;
					case "modremail":
						lblMessage.Text="修改補書資料已完成";
						break;
					case "pay":
//						if(Context.Request.QueryString["caller"]=="order")
//						{
//							lblMessage.Text="繳款處理已完成, 如欲補書請選擇下列欲補書之項目";
//							string id=Context.Request.QueryString["id"];
//							DataSet ds = new DataSet();
//							this.sqlDataAdapter1.Fill(ds, "c1_order");
//							DataView dv = ds.Tables["c1_order"].DefaultView;
//							dv.RowFilter="o_syscd='"+id.Substring(0,2)+"' and o_custno='"+id.Substring(2,6)
//								+"' and o_otp1cd='"+id.Substring(8,2)+"' and o_otp1seq='"+id.Substring(10,3)+"'";;
//							DataGrid1.Visible=true;
//							DataGrid1.DataSource=dv;
//							DataGrid1.DataBind();
//						}
//						else
							lblMessage.Text="繳款處理已完成";
						break;
				}
/*				if(Context.Request.QueryString["str"]=="newcust")
				{
					lblMessage.Text="新增訂戶資料已完成";
					hp1.Visible=true;
					hp2.Visible=true;
				}
				else if(Context.Request.QueryString["str"]=="bulk")
					lblMessage.Text="所選贈閱訂戶之續訂動作已完成";
				else if(Context.Request.QueryString["str"]=="modify")
					lblMessage.Text="訂單修改動作已完成";
				else if(Context.Request.QueryString["str"]=="newlost")
					lblMessage.Text="缺書登錄已完成";
				else if(Context.Request.QueryString["str"]=="pay")
				{
					if(Context.Request.QueryString["caller"]=="order")
					{
						lblMessage.Text="繳款處理已完成, 如欲補書請選擇下列欲補書之項目";
						string id=Context.Request.QueryString["id"];
						DataSet ds = new DataSet();
						this.sqlDataAdapter1.Fill(ds, "c1_order");
						DataView dv = ds.Tables["c1_order"].DefaultView;
						dv.RowFilter="o_syscd='"+id.Substring(0,2)+"' and o_custno='"+id.Substring(2,6)
							+"' and o_otp1cd='"+id.Substring(8,2)+"' and o_otp1seq='"+id.Substring(10,3)+"'";;
						DataGrid1.Visible=true;
						DataGrid1.DataSource=dv;
						DataGrid1.DataBind();
					}
					else
						lblMessage.Text="繳款處理已完成";
				}*/
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
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=03212-840695;packet size=4096";
			this.sqlConnection1.ConnectionString = ConfigurationSettings.AppSettings["mrlpub2"].ToString();
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_or", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("o_custno", "o_custno"),
																																																			   new System.Data.Common.DataColumnMapping("o_otp1cd", "o_otp1cd"),
																																																			   new System.Data.Common.DataColumnMapping("o_otp1seq", "o_otp1seq"),
																																																			   new System.Data.Common.DataColumnMapping("o_mfrno", "o_mfrno"),
																																																			   new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																			   new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																			   new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																			   new System.Data.Common.DataColumnMapping("or_tel", "or_tel"),
																																																			   new System.Data.Common.DataColumnMapping("o_syscd", "o_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			   new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																			   new System.Data.Common.DataColumnMapping("or_custno", "or_custno"),
																																																			   new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																			   new System.Data.Common.DataColumnMapping("or_otp1cd", "or_otp1cd"),
																																																			   new System.Data.Common.DataColumnMapping("or_otp1seq", "or_otp1seq"),
																																																			   new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																			   new System.Data.Common.DataColumnMapping("otp_otp1nm", "otp_otp1nm"),
																																																			   new System.Data.Common.DataColumnMapping("otp_otp2cd", "otp_otp2cd"),
																																																			   new System.Data.Common.DataColumnMapping("otp_otp1cd", "otp_otp1cd"),
																																																			   new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			   new System.Data.Common.DataColumnMapping("orderno", "orderno")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_order.o_mfrno, dbo.c1_cust.cust_nm, dbo.c1_or.or_nm, dbo.c1_or.or_addr, dbo.c1_or.or_tel, dbo.c1_order.o_syscd, dbo.mfr.mfr_inm, dbo.c1_cust.cust_custno, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, dbo.c1_or.or_syscd, dbo.mfr.mfr_mfrid, dbo.c1_otp.otp_otp1nm, dbo.c1_otp.otp_otp2cd, dbo.c1_otp.otp_otp1cd, dbo.mfr.mfr_mfrno, dbo.c1_or.or_syscd + dbo.c1_or.or_custno + dbo.c1_or.or_otp1cd + dbo.c1_or.or_otp1seq AS orderno FROM dbo.c1_or INNER JOIN dbo.c1_otp INNER JOIN dbo.mfr INNER JOIN dbo.c1_order INNER JOIN dbo.c1_cust ON dbo.c1_order.o_custno = dbo.c1_cust.cust_custno ON dbo.mfr.mfr_mfrno = dbo.c1_order.o_mfrno ON dbo.c1_otp.otp_otp1cd = dbo.c1_order.o_otp1cd AND dbo.c1_otp.otp_otp2cd = dbo.c1_order.o_otp2cd ON dbo.c1_or.or_syscd = dbo.c1_order.o_syscd AND dbo.c1_or.or_custno = dbo.c1_order.o_custno AND dbo.c1_or.or_otp1cd = dbo.c1_order.o_otp1cd AND dbo.c1_or.or_otp1seq = dbo.c1_order.o_otp1seq WHERE (dbo.c1_order.o_syscd = 'C1')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
			if(e.CommandName=="Select")
				Response.Redirect("RemailForm.aspx?id="+DataGrid1.SelectedItem.Cells[0].Text.Trim()+"&oritem="+DataGrid1.SelectedItem.Cells[5].Text.Trim()+"&prepage=pay");
		}
	}
}
