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

namespace MRLPub.d4
{
	/// <summary>
	/// Summary description for AdManagement.
	/// </summary>
	public class AdManagement : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxDraftType;
		protected System.Web.UI.WebControls.DropDownList ddlKey;
		protected System.Web.UI.WebControls.TextBox tbxImpression;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Label lblAdDate;
		protected System.Web.UI.WebControls.Calendar calSelectAdDate;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileAdImage;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.TextBox tbxTxtAdCont;
		protected System.Web.UI.WebControls.Label lblStep1;
		protected System.Web.UI.WebControls.Label lblStep2;
		protected System.Web.UI.WebControls.Label lblStep3;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlFgFixAd;
		protected System.Web.UI.WebControls.DropDownList ddlAdCate;
		
		private string AdScope;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.TextBox tbxInvAmt;
		protected System.Web.UI.WebControls.TextBox tbxAltText;
		protected System.Web.UI.WebControls.TextBox tbxNavUrl;
		protected System.Web.UI.WebControls.TextBox tbxRemark;
		protected System.Web.UI.WebControls.DropDownList ddlFgGot;
		protected System.Web.UI.WebControls.TextBox tbxAdAmt;
		protected System.Web.UI.WebControls.TextBox tbxDesAmt;
		protected System.Web.UI.WebControls.TextBox tbxChgAmt;
		protected System.Web.UI.WebControls.DropDownList ddlInvMfr;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlCmdGetAdrSeq;

		//private static int ADSeq;
	
		public AdManagement()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				//初始化
				this.lblAdDate.Text = DateTime.Today.ToShortDateString();
				LoadContNo(); //先讓User自行輸入
				GetScopeStr();
				//ADSeq = 0;
				BindDDLInvMfr();
			}

			//取出QueryString（按：暫時用不著了，不確定AdScope這個變數這樣用對不對）
//			if (Request.QueryString["AdScope"] !=null)
//			{
//				AdScope = Request.QueryString["AdScope"];
//			}
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
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdGetAdrSeq = new System.Data.SqlClient.SqlCommand();
			this.calSelectAdDate.SelectionChanged += new System.EventHandler(this.calSelectAdDate_SelectionChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO c4_adr (adr_costctr, adr_syscd, adr_contno, adr_date, adr_seq, adr_invamt, adr_adcate, adr_keyword, adr_alttext, adr_imgurl, adr_drafttp, adr_navurl, adr_urlcate, adr_txtadcont, adr_txtadcontnm, adr_impr, adr_fgfixad, adr_fggot, adr_adamt, adr_desamt, adr_chgamt, adr_remark, adr_fginved, adr_fginvself, adr_projno) VALUES (@adr_costctr, @adr_syscd, @adr_contno, @adr_date, @adr_seq, @adr_invamt, @adr_adcate, @adr_keyword, @adr_alttext, @adr_imgurl, @adr_drafttp, @adr_navurl, @adr_urlcate, @adr_txtadcont, @adr_txtadcontnm, @adr_impr, @adr_fgfixad, @adr_fggot, @adr_adamt, @adr_desamt, @adr_chgamt, @adr_remark, @adr_fginved, @adr_fginvself, @adr_projno); SELECT adr_adrid, adr_costctr, adr_syscd, adr_contno, adr_date, adr_seq, adr_invamt, adr_adcate, adr_keyword, adr_alttext, adr_imgurl, adr_drafttp, adr_navurl, adr_urlcate, adr_txtadcont, adr_txtadcontnm, adr_impr, adr_fgfixad, adr_fggot, adr_adamt, adr_desamt, adr_chgamt, adr_remark, adr_fginved, adr_fginvself, adr_projno FROM c4_adr WHERE (adr_adrid = @@IDENTITY)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_costctr", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_costctr", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_contno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_date", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_seq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_invamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_invamt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_adcate", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_adcate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_keyword", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_keyword", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_alttext", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_alttext", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_imgurl", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_imgurl", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_drafttp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_drafttp", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_navurl", System.Data.SqlDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_navurl", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_urlcate", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_urlcate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_txtadcont", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_txtadcont", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_txtadcontnm", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_txtadcontnm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_impr", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_impr", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_fgfixad", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fgfixad", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_fggot", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fggot", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_adamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_adamt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_desamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_desamt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_chgamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_chgamt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_remark", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_remark", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_fginved", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fginved", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_fginvself", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fginvself", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_projno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_projno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=ISCCOM1;initial catalog=MRLPub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-900103;packet size=4096";
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM c4_adr WHERE (adr_adrid = @adr_adrid) AND (adr_adamt = @adr_adamt) AND (adr_adcate = @adr_adcate) AND (adr_alttext = @adr_alttext) AND (adr_chgamt = @adr_chgamt) AND (adr_contno = @adr_contno) AND (adr_costctr = @adr_costctr) AND (adr_date = @adr_date) AND (adr_desamt = @adr_desamt) AND (adr_drafttp = @adr_drafttp) AND (adr_fgfixad = @adr_fgfixad) AND (adr_fggot = @adr_fggot) AND (adr_fginved = @adr_fginved) AND (adr_fginvself = @adr_fginvself) AND (adr_imgurl = @adr_imgurl) AND (adr_impr = @adr_impr) AND (adr_invamt = @adr_invamt) AND (adr_keyword = @adr_keyword) AND (adr_navurl = @adr_navurl) AND (adr_projno = @adr_projno) AND (adr_remark = @adr_remark) AND (adr_seq = @adr_seq) AND (adr_syscd = @adr_syscd) AND (adr_txtadcont = @adr_txtadcont) AND (adr_txtadcontnm = @adr_txtadcontnm) AND (adr_urlcate = @adr_urlcate)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_adrid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_adrid", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_adamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_adamt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_adcate", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_adcate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_alttext", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_alttext", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_chgamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_chgamt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_contno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_costctr", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_costctr", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_date", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_desamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_desamt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_drafttp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_drafttp", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_fgfixad", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fgfixad", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_fggot", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fggot", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_fginved", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fginved", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_fginvself", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fginvself", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_imgurl", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_imgurl", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_impr", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_impr", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_invamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_invamt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_keyword", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_keyword", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_navurl", System.Data.SqlDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_navurl", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_projno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_projno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_remark", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_remark", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_seq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_txtadcont", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_txtadcont", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_txtadcontnm", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_txtadcontnm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_urlcate", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_urlcate", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("im_imid", "im_imid"),
																																																				new System.Data.Common.DataColumnMapping("im_fgitri", "im_fgitri"),
																																																				new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				new System.Data.Common.DataColumnMapping("im_mfrno", "im_mfrno"),
																																																				new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				new System.Data.Common.DataColumnMapping("im_jbti", "im_jbti"),
																																																				new System.Data.Common.DataColumnMapping("im_zip", "im_zip"),
																																																				new System.Data.Common.DataColumnMapping("im_addr", "im_addr"),
																																																				new System.Data.Common.DataColumnMapping("im_tel", "im_tel"),
																																																				new System.Data.Common.DataColumnMapping("im_fax", "im_fax"),
																																																				new System.Data.Common.DataColumnMapping("im_cell", "im_cell"),
																																																				new System.Data.Common.DataColumnMapping("im_email", "im_email"),
																																																				new System.Data.Common.DataColumnMapping("im_invcd", "im_invcd"),
																																																				new System.Data.Common.DataColumnMapping("im_taxtp", "im_taxtp")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT im_imid, im_fgitri, im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbt" +
				"i, im_zip, im_addr, im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp FROM i" +
				"nvmfr WHERE (im_syscd = \'C4\')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c4_adr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("adr_adrid", "adr_adrid"),
																																																				new System.Data.Common.DataColumnMapping("adr_costctr", "adr_costctr"),
																																																				new System.Data.Common.DataColumnMapping("adr_syscd", "adr_syscd"),
																																																				new System.Data.Common.DataColumnMapping("adr_contno", "adr_contno"),
																																																				new System.Data.Common.DataColumnMapping("adr_date", "adr_date"),
																																																				new System.Data.Common.DataColumnMapping("adr_seq", "adr_seq"),
																																																				new System.Data.Common.DataColumnMapping("adr_invamt", "adr_invamt"),
																																																				new System.Data.Common.DataColumnMapping("adr_adcate", "adr_adcate"),
																																																				new System.Data.Common.DataColumnMapping("adr_keyword", "adr_keyword"),
																																																				new System.Data.Common.DataColumnMapping("adr_alttext", "adr_alttext"),
																																																				new System.Data.Common.DataColumnMapping("adr_imgurl", "adr_imgurl"),
																																																				new System.Data.Common.DataColumnMapping("adr_drafttp", "adr_drafttp"),
																																																				new System.Data.Common.DataColumnMapping("adr_navurl", "adr_navurl"),
																																																				new System.Data.Common.DataColumnMapping("adr_urlcate", "adr_urlcate"),
																																																				new System.Data.Common.DataColumnMapping("adr_txtadcont", "adr_txtadcont"),
																																																				new System.Data.Common.DataColumnMapping("adr_txtadcontnm", "adr_txtadcontnm"),
																																																				new System.Data.Common.DataColumnMapping("adr_impr", "adr_impr"),
																																																				new System.Data.Common.DataColumnMapping("adr_fgfixad", "adr_fgfixad"),
																																																				new System.Data.Common.DataColumnMapping("adr_fggot", "adr_fggot"),
																																																				new System.Data.Common.DataColumnMapping("adr_adamt", "adr_adamt"),
																																																				new System.Data.Common.DataColumnMapping("adr_desamt", "adr_desamt"),
																																																				new System.Data.Common.DataColumnMapping("adr_chgamt", "adr_chgamt"),
																																																				new System.Data.Common.DataColumnMapping("adr_remark", "adr_remark"),
																																																				new System.Data.Common.DataColumnMapping("adr_fginved", "adr_fginved"),
																																																				new System.Data.Common.DataColumnMapping("adr_fginvself", "adr_fginvself"),
																																																				new System.Data.Common.DataColumnMapping("adr_projno", "adr_projno")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT adr_adrid, adr_costctr, adr_syscd, adr_contno, adr_date, adr_seq, adr_invamt, adr_adcate, adr_keyword, adr_alttext, adr_imgurl, adr_drafttp, adr_navurl, adr_urlcate, adr_txtadcont, adr_txtadcontnm, adr_impr, adr_fgfixad, adr_fggot, adr_adamt, adr_desamt, adr_chgamt, adr_remark, adr_fginved, adr_fginvself, adr_projno FROM c4_adr";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "UPDATE c4_adr SET adr_costctr = @adr_costctr, adr_syscd = @adr_syscd, adr_contno " +
				"= @adr_contno, adr_date = @adr_date, adr_seq = @adr_seq, adr_invamt = @adr_invam" +
				"t, adr_adcate = @adr_adcate, adr_keyword = @adr_keyword, adr_alttext = @adr_altt" +
				"ext, adr_imgurl = @adr_imgurl, adr_drafttp = @adr_drafttp, adr_navurl = @adr_nav" +
				"url, adr_urlcate = @adr_urlcate, adr_txtadcont = @adr_txtadcont, adr_txtadcontnm" +
				" = @adr_txtadcontnm, adr_impr = @adr_impr, adr_fgfixad = @adr_fgfixad, adr_fggot" +
				" = @adr_fggot, adr_adamt = @adr_adamt, adr_desamt = @adr_desamt, adr_chgamt = @a" +
				"dr_chgamt, adr_remark = @adr_remark, adr_fginved = @adr_fginved, adr_fginvself =" +
				" @adr_fginvself, adr_projno = @adr_projno WHERE (adr_adrid = @Original_adr_adrid" +
				") AND (adr_adamt = @Original_adr_adamt) AND (adr_adcate = @Original_adr_adcate) " +
				"AND (adr_alttext = @Original_adr_alttext) AND (adr_chgamt = @Original_adr_chgamt" +
				") AND (adr_contno = @Original_adr_contno) AND (adr_costctr = @Original_adr_costc" +
				"tr) AND (adr_date = @Original_adr_date) AND (adr_desamt = @Original_adr_desamt) " +
				"AND (adr_drafttp = @Original_adr_drafttp) AND (adr_fgfixad = @Original_adr_fgfix" +
				"ad) AND (adr_fggot = @Original_adr_fggot) AND (adr_fginved = @Original_adr_fginv" +
				"ed) AND (adr_fginvself = @Original_adr_fginvself) AND (adr_imgurl = @Original_ad" +
				"r_imgurl) AND (adr_impr = @Original_adr_impr) AND (adr_invamt = @Original_adr_in" +
				"vamt) AND (adr_keyword = @Original_adr_keyword) AND (adr_navurl = @Original_adr_" +
				"navurl) AND (adr_projno = @Original_adr_projno) AND (adr_remark = @Original_adr_" +
				"remark) AND (adr_seq = @Original_adr_seq) AND (adr_syscd = @Original_adr_syscd) " +
				"AND (adr_txtadcont = @Original_adr_txtadcont) AND (adr_txtadcontnm = @Original_a" +
				"dr_txtadcontnm) AND (adr_urlcate = @Original_adr_urlcate); SELECT adr_adrid, adr" +
				"_costctr, adr_syscd, adr_contno, adr_date, adr_seq, adr_invamt, adr_adcate, adr_" +
				"keyword, adr_alttext, adr_imgurl, adr_drafttp, adr_navurl, adr_urlcate, adr_txta" +
				"dcont, adr_txtadcontnm, adr_impr, adr_fgfixad, adr_fggot, adr_adamt, adr_desamt," +
				" adr_chgamt, adr_remark, adr_fginved, adr_fginvself, adr_projno FROM c4_adr WHER" +
				"E (adr_adrid = @Select_adr_adrid)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_costctr", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_costctr", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_contno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_date", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_invamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_invamt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_adcate", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_adcate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_keyword", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_keyword", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_alttext", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_alttext", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_imgurl", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_imgurl", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_drafttp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_drafttp", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_navurl", System.Data.SqlDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_navurl", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_urlcate", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_urlcate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_txtadcont", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_txtadcont", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_txtadcontnm", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_txtadcontnm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_impr", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_impr", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_fgfixad", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fgfixad", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_fggot", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fggot", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_adamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_adamt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_desamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_desamt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_chgamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_chgamt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_remark", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_remark", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_fginved", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fginved", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_fginvself", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fginvself", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_projno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_projno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_adrid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_adrid", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_adamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_adamt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_adcate", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_adcate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_alttext", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_alttext", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_chgamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_chgamt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_contno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_costctr", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_costctr", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_date", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_desamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_desamt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_drafttp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_drafttp", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_fgfixad", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fgfixad", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_fggot", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fggot", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_fginved", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fginved", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_fginvself", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fginvself", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_imgurl", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_imgurl", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_impr", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_impr", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_invamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_invamt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_keyword", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_keyword", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_navurl", System.Data.SqlDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_navurl", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_projno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_projno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_remark", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_remark", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_seq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_txtadcont", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_txtadcont", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_txtadcontnm", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_txtadcontnm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_adr_urlcate", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_urlcate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_adr_adrid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_adrid", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCmdGetAdrSeq
			// 
			this.sqlCmdGetAdrSeq.CommandText = "SELECT MAX(adr_seq) AS MaxAdrSeq FROM c4_adr GROUP BY adr_date, adr_contno, adr_s" +
				"yscd HAVING (adr_date = @adr_date) AND (adr_contno = @adr_contno) AND (adr_syscd" +
				" = \'C4\')";
			this.sqlCmdGetAdrSeq.Connection = this.sqlConnection1;
			this.sqlCmdGetAdrSeq.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_date", System.Data.DataRowVersion.Current, null));
			this.sqlCmdGetAdrSeq.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_contno", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindDDLInvMfr()
		{
			DataSet ds = new DataSet();
			this.sqlDataAdapter2.Fill(ds, "INVMFR");
			DataView dv = ds.Tables["INVMFR"].DefaultView;
			dv.RowFilter = "im_contno='" + Request.QueryString["ContNo"].ToString() + "'";
			this.ddlInvMfr.DataTextField = "im_nm";
			this.ddlInvMfr.DataValueField = "im_imid";
			this.ddlInvMfr.DataSource = dv;
			this.ddlInvMfr.DataBind();
		}

		//not finished，不知道這樣對不對
		private int GetMaxAdrSeq(string GivenContNo, string GivenAdrDate)
		{
			int MaxSeq = 0;
			this.sqlCmdGetAdrSeq.Parameters["@adr_contno"].Value = GivenContNo;
			this.sqlCmdGetAdrSeq.Parameters["@adr_date"].Value = GivenAdrDate;

			this.sqlCmdGetAdrSeq.Connection.Open();
			try
			{
				MaxSeq = Convert.ToInt32(this.sqlCmdGetAdrSeq.ExecuteScalar());
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				Response.Write("GET MAX AdrSeq ERROR");
			}
			this.sqlCmdGetAdrSeq.Connection.Close();
			return MaxSeq;
		}

		private void calSelectAdDate_SelectionChanged(object sender, System.EventArgs e)
		{
			this.lblAdDate.Text = this.calSelectAdDate.SelectedDate.ToShortDateString();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (this.tbxContNo.Text==null || this.tbxContNo.Text == "")
			{
				Response.Write("你忘了選合約編號囉！！！");
			}
			else
			{
				//先把一些欄位先都填好，因為所有的欄位都不能allow null，暫時填入"9"代替
				for(int i=0;i<this.sqlInsertCommand1.Parameters.Count;i++)
				{
					this.sqlInsertCommand1.Parameters[i].Value = "9";
				}
				//INSERT IT
				DateTime AdDate = Convert.ToDateTime(lblAdDate.Text);
				string PostedFileName = "";
				if (this.fileAdImage.PostedFile != null)
				{
					PostedFileName = this.fileAdImage.PostedFile.FileName.Substring(fileAdImage.PostedFile.FileName.LastIndexOf("\\") + 1);
				}

				string strTextAdCont;
				if (this.tbxTxtAdCont.Text == null || this.tbxTxtAdCont.Text == "")
				{
					strTextAdCont = "";
				}
				else
				{
					strTextAdCont = this.tbxTxtAdCont.Text;
				}

				//AdrSeq
				int NewAdSeq = GetMaxAdrSeq(this.tbxContNo.Text, (AdDate.ToString("yyyyMM")+"01"))+1;

				this.sqlInsertCommand1.Parameters["@adr_contno"].Value = this.tbxContNo.Text;
				//version 1: by day
				//this.sqlInsertCommand1.Parameters["@adr_date"].Value = AdDate.ToString("yyyyMMdd");
				this.sqlInsertCommand1.Parameters["@adr_syscd"].Value = "C4";
				//this.sqlInsertCommand1.Parameters["@adr_seq"].Value = ADSeq.ToString("d2", null);
				this.sqlInsertCommand1.Parameters["@adr_seq"].Value = NewAdSeq.ToString("d2", null);

				//version 2: by month
				this.sqlInsertCommand1.Parameters["@adr_date"].Value = AdDate.ToString("yyyyMM") + "01";
				this.sqlInsertCommand1.Parameters["@adr_adcate"].Value = this.ddlAdCate.SelectedItem.Value;
				this.sqlInsertCommand1.Parameters["@adr_keyword"].Value = this.ddlKey.SelectedItem.Value;
				this.sqlInsertCommand1.Parameters["@adr_alttext"].Value = this.tbxAltText.Text;
				this.sqlInsertCommand1.Parameters["@adr_imgurl"].Value = "ADImages/" + PostedFileName;
				this.sqlInsertCommand1.Parameters["@adr_drafttp"].Value = this.tbxDraftType.Text;
				this.sqlInsertCommand1.Parameters["@adr_navurl"].Value = this.tbxNavUrl.Text;
				this.sqlInsertCommand1.Parameters["@adr_impr"].Value = this.tbxImpression.Text;
				this.sqlInsertCommand1.Parameters["@adr_fgfixad"].Value = this.ddlFgFixAd.SelectedItem.Value;
				this.sqlInsertCommand1.Parameters["@adr_urlcate"].Value = "";
				this.sqlInsertCommand1.Parameters["@adr_txtadcont"].Value = strTextAdCont;
				this.sqlInsertCommand1.Parameters["@adr_txtadcontnm"].Value = "";
				this.sqlInsertCommand1.Parameters["@adr_fggot"].Value = this.ddlFgGot.SelectedItem.Value;
				this.sqlInsertCommand1.Parameters["@adr_adamt"].Value = this.tbxAdAmt.Text;
				this.sqlInsertCommand1.Parameters["@adr_desamt"].Value = this.tbxDesAmt.Text;
				this.sqlInsertCommand1.Parameters["@adr_chgamt"].Value = this.tbxChgAmt.Text;
//				this.sqlInsertCommand1.Parameters["@adr_"].Value = ;
//				this.sqlInsertCommand1.Parameters["@adr_"].Value = ;
//				this.sqlInsertCommand1.Parameters["@adr_"].Value = ;
//				this.sqlInsertCommand1.Parameters["@adr_"].Value = ;
				
				//儲存到廣告播出檔
				bool InsertSuccessfully = true;
				this.sqlInsertCommand1.Connection.Open();
				try
				{
					this.sqlInsertCommand1.ExecuteNonQuery();
				}
				catch(System.Data.SqlClient.SqlException ex)
				{
					Response.Write(ex.Message);
					InsertSuccessfully = false;
				}
				this.sqlInsertCommand1.Connection.Close();

				//儲存圖檔
				if (InsertSuccessfully)
				{
					LiteralControl litAlert = new LiteralControl();
					litAlert.Text = "<script language=javascript>"+
						"alert(\"資料輸入成功！\");"+
						"</script>";
					Page.Controls.Add(litAlert);

					//新增成功，也順便存圖檔放在"./ADimages/"下
					if (this.fileAdImage.PostedFile.ContentLength>0)
					{
						fileAdImage.PostedFile.SaveAs(Server.MapPath(".") + "/" + "ADImages/"+ PostedFileName);
					}

					//因為成功，所以seq加一，
					//這個要再處理
					//ADSeq++;

					//submit and refresh
					LiteralControl litSubmit = new LiteralControl();
					litSubmit.Text = "<script language=\"javascript\">"+
						"doSubmit();"+
						"</script>";
					Page.Controls.Add(litSubmit);
				}
				else
				{
					LiteralControl litAlert = new LiteralControl();
					litAlert.Text = "<script language=javascript>"+
						"alert(\"資料輸入失敗\");"+
						"</script>";
					Page.Controls.Add(litAlert);
				}
			}
		}

		private void LoadContNo()
		{
			if (Request.QueryString["ContNo"]==null || Request.QueryString["ContNo"].ToString() == "")
			{
				Response.Write("錯誤，請檢查步驟或通知聯絡人");
				return;
			}

			this.tbxContNo.Text = Request.QueryString["ContNo"].ToString();
			this.tbxContNo.ReadOnly = true;
		}

		private string GetScopeStr()
		{
			string retstr = "M";
			if (Request.QueryString["AdScope"] !=null)
			{
				//按照QueryString來決定Keyword要怎麼生成...	
				switch(Request.QueryString["AdScope"])
				{
					case "Main":
						retstr = "M";
						break;
					case "Inner":
						retstr = "I";
						break;
					case "Nano":
						retstr = "N";
						break;
				}
			} 
			else
			{
				//預設值放在首頁
				retstr = "M";
			}

			//Default 傳回M，也就是做在主網頁上
			for (int i=0; i<this.ddlAdCate.Items.Count; i++)
			{
				if (this.ddlAdCate.Items[i].Value == retstr)
				{
					this.ddlAdCate.SelectedIndex = i;
				}
			}

			return retstr;//以後可以不用return了
		}
	}
}
