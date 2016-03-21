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
// SQL
using System.Data.SqlClient;
namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for or_edit.
	/// </summary>
	public class or_edit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Web.UI.WebControls.TextBox or_syscd;
		protected System.Web.UI.WebControls.TextBox or_nm;
		protected System.Web.UI.WebControls.TextBox or_jbti;
		protected System.Web.UI.WebControls.TextBox or_tel;
		protected System.Web.UI.WebControls.TextBox or_fax;
		protected System.Web.UI.WebControls.TextBox or_cell;
		protected System.Web.UI.WebControls.TextBox or_email;
		protected System.Web.UI.WebControls.TextBox or_zip;
		protected System.Web.UI.WebControls.TextBox or_addr;
		protected System.Web.UI.WebControls.TextBox or_pubcnt;
		protected System.Web.UI.WebControls.TextBox or_unpubcnt;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.TextBox or_contno;
		protected System.Web.UI.WebControls.TextBox or_oritem;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Web.UI.WebControls.TextBox or_fgmoseanm;
		protected System.Web.UI.WebControls.DropDownList ddlORMailTypeCode;
		protected System.Web.UI.HtmlControls.HtmlInputHidden or_fgmosea;
		

		// 宣告 global_cd
		private static string global_syscd;
		private static string global_contno;
		private static string global_oritem;
		private static string global_nm;
		private static string global_jbti;
		private static string global_addr;
		private static string global_zip;
		private static string global_tel;
		private static string global_fax;
		private static string global_cell;
		private static string global_email;
		private static string global_mtpcd;
		private static string global_pubcnt;
		private static string global_unpubcnt;
		private static string global_fgmosea;
		
		
		
		public or_edit()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				string id = Request.QueryString["ID"].ToString();
				
				// 顯示下拉式選單 郵寄類別代碼的 DB 值
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "mtp");
				DataView dv1=ds1.Tables["mtp"].DefaultView;
				ddlORMailTypeCode.DataSource=dv1;
				ddlORMailTypeCode.DataTextField="mtp_nm";
				ddlORMailTypeCode.DataValueField="mtp_mtpcd";
				ddlORMailTypeCode.DataBind();
				//this.ddlORMailTypeCode.SelectedItem.Value = global_fgmosea;
				//Response.Write("global_fgmosea= " + global_fgmosea);
				
				
				InitData();
			}

		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		private void InitData()
		{
			string id = Request.QueryString["ID"].ToString();
			
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds2 = new DataSet();
			DataView dv2;
			this.sqlDataAdapter2.Fill(ds2, "c2_or");
			dv2 = ds2.Tables["c2_or"].DefaultView;
			
			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			dv2.RowFilter = "or_orid=" + id;
			
			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
			
			// 若找到此筆資料, 則載入資料
			if(dv2.Count>0)
			{
				string syscd = dv2[0]["or_syscd"].ToString();
				string contno = dv2[0]["or_contno"].ToString();
				string oritem = dv2[0]["or_oritem"].ToString();
				string nm = dv2[0]["or_nm"].ToString();
				string jbti = dv2[0]["or_jbti"].ToString();
				string addr = dv2[0]["or_addr"].ToString();
				string zip = dv2[0]["or_zip"].ToString();
				string tel = dv2[0]["or_tel"].ToString();
				string fax = dv2[0]["or_fax"].ToString();
				string cell = dv2[0]["or_cell"].ToString();
				string email = dv2[0]["or_email"].ToString();
				string mtpcd = dv2[0]["or_mtpcd"].ToString();
				string pubcnt = dv2[0]["or_pubcnt"].ToString();
				string unpubcnt = dv2[0]["or_unpubcnt"].ToString();
				string fgmosea = dv2[0]["or_fgmosea"].ToString();
				// 指定 fgmosea 的值至隱藏欄位 or_fgmosea; 因畫面上只顯示其相對文字, 而非其值
				or_fgmosea.Value = fgmosea;
				//Response.Write("mtpcd= " + mtpcd + "<br>");
				//Response.Write("fgmosea= " + fgmosea + "<br>");
				//Response.Write("or_fgmosea.Value= " + or_fgmosea.Value + "<br>");
				
				// 指定 global_xxx 為原來存在資料庫中的初始值; 以傳遞到 btnUpdate_Click() 來做比較
				global_syscd = syscd.Trim();
				global_contno = contno.Trim();
				global_oritem = oritem.Trim();
				global_nm = nm.Trim();
				global_jbti = jbti.Trim();
				global_addr = addr.Trim();
				global_zip = zip.Trim();
				global_tel = tel.Trim();
				global_fax = fax.Trim();
				global_cell = cell.Trim();
				global_email = email.Trim();
				global_mtpcd = mtpcd;
				global_pubcnt = pubcnt.Trim();
				global_unpubcnt = unpubcnt.Trim();
				global_fgmosea = fgmosea.Trim();
				//Response.Write("global_nm= " + global_nm + "<br>");
				//Response.Write("global_fgmosea= " + global_fgmosea + "<br><br>");
				
				this.or_syscd.Text = syscd.Trim();
				this.or_contno.Text = contno.Trim();
				this.or_oritem.Text = oritem.Trim();
				this.or_nm.Text = nm.Trim();
				this.or_jbti.Text = jbti.Trim();
				this.or_addr.Text = addr.Trim();
				this.or_zip.Text = zip.Trim();
				this.or_tel.Text = tel.Trim();
				this.or_fax.Text = fax.Trim();
				this.or_cell.Text = cell.Trim();
				this.or_email.Text = email.Trim();
				this.or_pubcnt.Text = pubcnt.Trim();
				this.or_unpubcnt.Text = unpubcnt.Trim();
				
				
				// 抓出郵寄類別的名稱
				DataSet ds1 = new DataSet();
				DataView dv1;
				this.sqlDataAdapter1.Fill(ds1, "mtp");
				dv1 = ds1.Tables["mtp"].DefaultView;
				dv1.RowFilter = "mtp_mtpcd=" + mtpcd;

				// 若找得到此郵寄類別代碼, 則顯示其名稱
				string or_mtpname = "";
				if(dv1.Count>0)
					or_mtpname = dv1[0]["mtp_nm"].ToString().Trim();
				else
					or_mtpname = "目前暫無資料";

				// 因 ddlORMailTypeCode 的 code 無法與 SelectIndex 做出原則, 故以 SelectedItem 來取代 SelectIndex
				//this.ddlORMailTypeCode.SelectedIndex = (int.Parse(mtpcd)-1);
				this.ddlORMailTypeCode.SelectedItem.Text = or_mtpname.ToString().Trim();
				
				// 抓出海外郵寄類別 fgmosea - 改以 textbox 唯讀屬性來顯示, 而非下拉式選單顯示
				int intfgmosea = int.Parse(fgmosea);
				if(intfgmosea==1)
					this.or_fgmoseanm.Text = "是";
				else
					this.or_fgmoseanm.Text = "否";
				// 抓出 fgmosea 先加1, 再除 2 後的餘值: 0, 1 即正好為 ddlfgmosea.SelectedIndex
				//this.ddlfgmosea.SelectedIndex = (int.Parse(fgmosea)+1) % 2;

			}
			
		}


		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.ddlORMailTypeCode.SelectedIndexChanged += new System.EventHandler(this.ddlORMailTypeCode_SelectedIndexChanged);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO c2_or(or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, or_tel, or_fax, or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_fgmosea) VALUES (@or_syscd, @or_contno, @or_oritem, @or_inm, @or_nm, @or_jbti, @or_addr, @or_zip, @or_tel, @or_fax, @or_cell, @or_email, @or_mtpcd, @or_pubcnt, @or_unpubcnt, @or_fgmosea); SELECT or_orid, or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, or_tel, or_fax, or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_fgmosea FROM c2_or WHERE (or_contno = @Select_or_contno) AND (or_oritem = @Select_or_oritem) AND (or_syscd = @Select_or_syscd)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_inm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_inm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_nm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_nm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_addr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_addr", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_zip", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_tel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fax", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_cell", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_email", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_mtpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_mtpcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_pubcnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_pubcnt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_unpubcnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_unpubcnt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_fgmosea", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fgmosea", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_or_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_or_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_or_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM c2_or WHERE (or_contno = @or_contno) AND (or_oritem = @or_oritem) AND (or_syscd = @or_syscd) AND (or_addr = @or_addr) AND (or_cell = @or_cell) AND (or_email = @or_email) AND (or_fax = @or_fax) AND (or_fgmosea = @or_fgmosea) AND (or_inm = @or_inm) AND (or_jbti = @or_jbti) AND (or_mtpcd = @or_mtpcd) AND (or_nm = @or_nm) AND (or_orid = @or_orid) AND (or_pubcnt = @or_pubcnt) AND (or_tel = @or_tel) AND (or_unpubcnt = @or_unpubcnt) AND (or_zip = @or_zip)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_oritem", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_addr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_addr", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_cell", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_email", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fax", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_fgmosea", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fgmosea", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_inm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_inm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_jbti", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_mtpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_mtpcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_nm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_nm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_orid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_orid", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_pubcnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_pubcnt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_tel", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_unpubcnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_unpubcnt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_zip", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter2.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_or", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("or_orid", "or_orid"),
																																																			   new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																			   new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																			   new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																			   new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																			   new System.Data.Common.DataColumnMapping("or_jbti", "or_jbti"),
																																																			   new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																			   new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																			   new System.Data.Common.DataColumnMapping("or_tel", "or_tel"),
																																																			   new System.Data.Common.DataColumnMapping("or_fax", "or_fax"),
																																																			   new System.Data.Common.DataColumnMapping("or_cell", "or_cell"),
																																																			   new System.Data.Common.DataColumnMapping("or_email", "or_email"),
																																																			   new System.Data.Common.DataColumnMapping("or_mtpcd", "or_mtpcd"),
																																																			   new System.Data.Common.DataColumnMapping("or_pubcnt", "or_pubcnt"),
																																																			   new System.Data.Common.DataColumnMapping("or_unpubcnt", "or_unpubcnt"),
																																																			   new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea")})});
			this.sqlDataAdapter2.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT or_orid, or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, " +
				"or_zip, or_tel, or_fax, or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_" +
				"fgmosea FROM c2_or";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE c2_or SET or_syscd = @or_syscd, or_contno = @or_contno, or_oritem = @or_oritem, or_inm = @or_inm, or_nm = @or_nm, or_jbti = @or_jbti, or_addr = @or_addr, or_zip = @or_zip, or_tel = @or_tel, or_fax = @or_fax, or_cell = @or_cell, or_email = @or_email, or_mtpcd = @or_mtpcd, or_pubcnt = @or_pubcnt, or_unpubcnt = @or_unpubcnt, or_fgmosea = @or_fgmosea WHERE (or_contno = @Original_or_contno) AND (or_oritem = @Original_or_oritem) AND (or_syscd = @Original_or_syscd) AND (or_addr = @Original_or_addr) AND (or_cell = @Original_or_cell) AND (or_email = @Original_or_email) AND (or_fax = @Original_or_fax) AND (or_fgmosea = @Original_or_fgmosea) AND (or_inm = @Original_or_inm) AND (or_jbti = @Original_or_jbti) AND (or_mtpcd = @Original_or_mtpcd) AND (or_nm = @Original_or_nm) AND (or_pubcnt = @Original_or_pubcnt) AND (or_tel = @Original_or_tel) AND (or_unpubcnt = @Original_or_unpubcnt) AND (or_zip = @Original_or_zip); SELECT or_orid, or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, or_tel, or_fax, or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_fgmosea FROM c2_or WHERE (or_contno = @Select_or_contno) AND (or_oritem = @Select_or_oritem) AND (or_syscd = @Select_or_syscd)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_inm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_inm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_nm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_nm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_addr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_addr", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_zip", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_tel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fax", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_cell", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_email", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_mtpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_mtpcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_pubcnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_pubcnt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_unpubcnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_unpubcnt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@or_fgmosea", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fgmosea", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_oritem", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_addr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_addr", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_cell", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_email", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fax", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_fgmosea", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fgmosea", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_inm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_inm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_jbti", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_mtpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_mtpcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_nm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_nm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_pubcnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_pubcnt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_tel", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_unpubcnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_unpubcnt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_or_zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_zip", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_or_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_or_oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_or_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mtp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mtp_mtpid", "mtp_mtpid"),
																																																			 new System.Data.Common.DataColumnMapping("mtp_mtpcd", "mtp_mtpcd"),
																																																			 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT mtp_mtpid, mtp_mtpcd, mtp_nm FROM mtp";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		

		// 若變更郵寄類別時, 也要同時變更海外郵寄註記
		private void ddlORMailTypeCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//string NewText = this.ddlORMailTypeCode.SelectedItem.Text;
			int NewValue = int.Parse(this.ddlORMailTypeCode.SelectedItem.Value);
			
			// 規則: 若其值大於等於 20, 則表示為海外註記
			// 注意, 一定要把 ddlORMailTypeCode 的 AutoPostBack = true 開啟, 否則 or_fgmoseanm.Text 不會同時變更 
			if(NewValue >= 20)
			{
				//Response.Write(NewText + "(" + NewValue + ", 是)<BR>");
				this.or_fgmoseanm.Text = "是";
			}
			else
			{
				//Response.Write(NewText + "(" + NewValue + ", 否)<BR>");
				this.or_fgmoseanm.Text = "否";
			}
		}

		
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			string id = Request.QueryString["ID"].ToString();
			
			String strConn="server=isccom1;database=mrlpub;uid=webuser;pwd=db600";
			SqlConnection myConn=new SqlConnection(strConn);
			string SQL = "select * from c2_or";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);
			
			DataSet ds = new DataSet();
			myCommand.Fill(ds,"c2_or");
			DataView dv = ds.Tables["c2_or"].DefaultView;
			//Response.Write(dv.Count);
			
			// 抓出目前畫面裡的各個值, 以改寫覆蓋 db
			string CurrentSyscd = this.or_syscd.Text.ToString().Trim();
			string CurrentContNo = this.or_contno.Text.ToString().Trim();
			string CurrentORItem = this.or_oritem.Text.ToString().Trim();
			string CurrentORName = this.or_nm.Text.ToString().Trim();
			string CurrentORJobTitle = this.or_jbti.Text.ToString().Trim();
			string CurrentORTel = this.or_tel.Text.ToString().Trim();
			string CurrentORFax = this.or_fax.Text.ToString().Trim();
			string CurrentORCell = this.or_cell.Text.ToString().Trim();
			string CurrentOREmail = this.or_email.Text.ToString().Trim();
			string CurrentORZip = this.or_zip.Text.ToString().Trim();
			string CurrentORAddr = this.or_addr.Text.ToString().Trim();
			// 注意: Currentfgmosea 的值由隱藏欄位抓出
			string Currentfgmosea = or_fgmosea.Value;
			string CurrentPubcnt = this.or_pubcnt.Text.ToString().Trim();
			string CurrentUNPubcnt = this.or_unpubcnt.Text.ToString().Trim();
			// 注意: CurrentddlORMailTypeCode 的值由下拉式選單抓出其值
			string CurrentddlORMailTypeCode = this.ddlORMailTypeCode.SelectedItem.Value.Trim();
			//Response.Write("or_syscd.Text=" + CurrentSyscd+ "<br>");
			//Response.Write("or_contno.Text=" + CurrentContNo + "<br>");
			//Response.Write("or_oritem.Text=" + CurrentORItem + "<br>");
			//Response.Write("or_nm.Text=" + CurrentORName + "<br>");
			//Response.Write("or_jbti.Text=" + CurrentORJobTitle + "<br>");
			//Response.Write("or_tel.Text=" + CurrentORTel + "<br>");
			//Response.Write("or_fax.Text=" + CurrentORCell + "<br>");
			//Response.Write("or_cell.Text=" + CurrentOREmail + "<br>");
			//Response.Write("or_zip.Text=" + CurrentORZip + "<br>");
			//Response.Write("or_addr.Text=" + CurrentORAddr + "<br>");
			//Response.Write("ddlORMailTypeCode=" + CurrentddlORMailTypeCode + "<br>");
			//Response.Write("or_fgmosea.Text=" + Currentfgmosea + "<br>");
			//Response.Write("or_pubcnt.Text=" + CurrentPubcnt + "<br>");
			//Response.Write("or_pubcnt.Text=" + CurrentUNPubcnt + "<br>");
			dv.RowFilter = "or_syscd = '" + CurrentSyscd + "' AND or_contno = '" + CurrentContNo + "' AND or_oritem = '" + CurrentORItem + "'";
			//Response.Write("dv.RowFilter=" + dv.RowFilter.ToString().Trim() + "<br>");
			//Response.Write("dv.Count=" + dv.Count + "<br>");
			
			// 檢查 initData() 裡 - 原來存在資料庫中的值 global_xxx 是否有抓到
			//Response.Write("global_syscd=" + global_syscd + "<br>");
			//Response.Write("global_contno=" + global_contno + "<br>");
			//Response.Write("global_oritem=" + global_oritem + "<br>");
			//Response.Write("global_mtpcd=" + global_mtpcd + "<br>");
			//Response.Write("global_fgmosea=" + global_fgmosea + "<br>");
			
			// 若目前畫面裡的值在資料庫中找得到 (即 dv.count>0) 且 pk 值不相同時: 先檢查資料庫裡是否有重覆資料
			//Response.Write("CurrentSyscd=" + CurrentSyscd + "!= global_syscd=" + global_syscd + "<br>");
			//Response.Write("CurrentContNo=" + CurrentContNo + "!= global_contno=" + global_contno + "<br>");
			//Response.Write("CurrentORItem=" + CurrentORItem + "!= global_oritem=" + global_oritem + "<br>");
			if (dv.Count > 0 && (CurrentSyscd != global_syscd || CurrentContNo != global_contno || CurrentORItem != global_oritem))
			{
				Label1.Text="修改失敗: 此筆資料已經存在!";
			}
			// 若非重覆的資料, 更新其值
			else
			{
				// 更新 db table 該筆所有的值
				SqlDataAdapter cmd=new SqlDataAdapter("update c2_or set or_syscd=@or_syscd, or_contno=@or_contno, or_oritem=@or_oritem, or_nm=@or_nm, or_jbti=@or_jbti, or_addr=@or_addr, or_zip=@or_zip, or_tel=@or_tel, or_fax=@or_fax, or_cell=@or_cell, or_email=@or_email, or_mtpcd=@or_mtpcd, or_pubcnt=@or_pubcnt, or_unpubcnt=@or_unpubcnt, or_fgmosea=@or_fgmosea where or_orid=@or_orid",myConn);
		
				cmd.SelectCommand.Parameters.Add("@or_orid",SqlDbType.Int,4).Value = id;
				cmd.SelectCommand.Parameters.Add("@or_syscd",SqlDbType.Char,2).Value = CurrentSyscd;
				cmd.SelectCommand.Parameters.Add("@or_contno",SqlDbType.Char,6).Value = CurrentContNo;
				cmd.SelectCommand.Parameters.Add("@or_oritem",SqlDbType.Char,2).Value = CurrentORItem;
				cmd.SelectCommand.Parameters.Add("@or_nm",SqlDbType.Char,30).Value = CurrentORName;
				cmd.SelectCommand.Parameters.Add("@or_jbti",SqlDbType.Char,12).Value = CurrentORJobTitle;
				cmd.SelectCommand.Parameters.Add("@or_addr",SqlDbType.Char,120).Value = CurrentORAddr;
				cmd.SelectCommand.Parameters.Add("@or_zip",SqlDbType.Char,5).Value = CurrentORZip;
				cmd.SelectCommand.Parameters.Add("@or_tel",SqlDbType.Char,30).Value = CurrentORTel;
				cmd.SelectCommand.Parameters.Add("@or_fax",SqlDbType.Char,30).Value = CurrentORFax;
				cmd.SelectCommand.Parameters.Add("@or_cell",SqlDbType.Char,30).Value = CurrentORCell;
				cmd.SelectCommand.Parameters.Add("@or_email",SqlDbType.Char,80).Value = CurrentOREmail;
				cmd.SelectCommand.Parameters.Add("@or_mtpcd",SqlDbType.Char,2).Value = CurrentddlORMailTypeCode;
				cmd.SelectCommand.Parameters.Add("@or_pubcnt",SqlDbType.Int,4).Value = CurrentPubcnt;
				cmd.SelectCommand.Parameters.Add("@or_unpubcnt",SqlDbType.Int,4).Value = CurrentUNPubcnt;
				cmd.SelectCommand.Parameters.Add("@or_fgmosea",SqlDbType.Char,1).Value = Currentfgmosea;

				DataSet ds1 = new DataSet();
				cmd.Fill(ds1,"c2_or");
			
				// 更新完, 做轉址動作
				Response.Redirect("or.aspx");
			}
			
		}
		

		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("or.aspx");
		}


	}
}
