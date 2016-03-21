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
	/// Summary description for adpub_detail.
	/// </summary>
	public class adpub_detail : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidden_xml;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlOrigBookCode;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlDraftTypeCode;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlNJTypeCode;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlChgBookCode;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
	
		public adpub_detail()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				// 設定無 Expires Time
				Response.Expires=0;


				// 顯示下拉式選單 舊稿書籍類別代碼&改稿書籍類別代碼的 DB 值
				// 此處參考 cont_new3.aspx 的 sqlAdapter3 所改寫
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "book");
				ddlOrigBookCode.DataSource=ds1;
				ddlOrigBookCode.DataTextField="bk_nm";
				ddlOrigBookCode.DataValueField="bk_bkcd";
				ddlOrigBookCode.DataBind();
				
				ddlChgBookCode.DataSource=ds1;
				ddlChgBookCode.DataTextField="bk_nm";
				ddlChgBookCode.DataValueField="bk_bkcd";
				ddlChgBookCode.DataBind();
				
				
				// 顯示下拉式選單 新稿製法代碼的 DB 值
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "c2_njtp");
				ddlNJTypeCode.DataSource=ds2;
				ddlNJTypeCode.DataTextField="njtp_nm";
				ddlNJTypeCode.DataValueField="njtp_njtpcd";
				ddlNJTypeCode.DataBind();


				// 在畫面顯示其 預設值為第一項 "國內郵寄: 普遍郵"
				// 目前下一行 coding 不 work, 不知為何??????????????????????
				// 但相同功能, cont_new3.aspx.cs Line 154 卻 work; 在 localhost 也 work 
				this.ddlOrigBookCode.SelectedIndex = 01;
				this.ddlChgBookCode.SelectedIndex = 01;
				this.ddlNJTypeCode.SelectedIndex = 01;

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
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.DeleteCommand = this.sqlDeleteCommand2;
			this.sqlDataAdapter2.InsertCommand = this.sqlInsertCommand2;
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_njtp", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("njtp_njtpid", "njtp_njtpid"),
																																																				 new System.Data.Common.DataColumnMapping("njtp_njtpcd", "njtp_njtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("njtp_nm", "njtp_nm")})});
			this.sqlDataAdapter2.UpdateCommand = this.sqlUpdateCommand2;
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = "DELETE FROM c2_njtp WHERE (njtp_njtpcd = @njtp_njtpcd) AND (njtp_njtpid = @njtp_n" +
				"jtpid) AND (njtp_nm = @njtp_nm)";
			this.sqlDeleteCommand2.Connection = this.sqlConnection1;
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@njtp_njtpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "njtp_njtpcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@njtp_njtpid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "njtp_njtpid", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@njtp_nm", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "njtp_nm", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = "INSERT INTO c2_njtp(njtp_njtpcd, njtp_nm) VALUES (@njtp_njtpcd, @njtp_nm); SELECT" +
				" njtp_njtpid, njtp_njtpcd, njtp_nm FROM c2_njtp WHERE (njtp_njtpcd = @Select_njt" +
				"p_njtpcd)";
			this.sqlInsertCommand2.Connection = this.sqlConnection1;
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@njtp_njtpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "njtp_njtpcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@njtp_nm", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "njtp_nm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_njtp_njtpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "njtp_njtpcd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT njtp_njtpid, njtp_njtpcd, njtp_nm FROM c2_njtp";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = "UPDATE c2_njtp SET njtp_njtpcd = @njtp_njtpcd, njtp_nm = @njtp_nm WHERE (njtp_njt" +
				"pcd = @Original_njtp_njtpcd) AND (njtp_nm = @Original_njtp_nm); SELECT njtp_njtp" +
				"id, njtp_njtpcd, njtp_nm FROM c2_njtp WHERE (njtp_njtpcd = @Select_njtp_njtpcd)";
			this.sqlUpdateCommand2.Connection = this.sqlConnection1;
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@njtp_njtpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "njtp_njtpcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@njtp_nm", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "njtp_nm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_njtp_njtpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "njtp_njtpcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_njtp_nm", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "njtp_nm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_njtp_njtpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "njtp_njtpcd", System.Data.DataRowVersion.Current, null));
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
																																																			  new System.Data.Common.DataColumnMapping("nostr", "nostr"),
																																																			  new System.Data.Common.DataColumnMapping("proj_bkcd", "proj_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("proj_fgitri", "proj_fgitri")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT book.bk_bkid, book.bk_bkcd, book.bk_nm, proj.proj_syscd, book.bk_bkcd + proj.proj_projno + proj.proj_costctr AS nostr, proj.proj_bkcd, proj.proj_fgitri FROM book INNER JOIN proj ON book.bk_bkcd = proj.proj_bkcd WHERE (proj.proj_syscd = 'C2') AND (proj.proj_fgitri = '')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	}
}
