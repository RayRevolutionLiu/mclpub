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
using System.Xml;
using System.IO;
using System.Configuration;

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for CreateIa.
	/// </summary>
	public class CreateIa : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnCreateIa;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlUpdateOrderIano;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		XmlDocument XmlDoc;
	
		public CreateIa()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				Response.Expires=0;
				DataList_DataBind();			
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
			System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateOrderIano = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.btnCreateIa.Click += new System.EventHandler(this.btnCreateIa_Click);
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO dbo.ia(ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat, ia_invno, ia_invdate, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti, ia_rtel, ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno) VALUES (@ia_syscd, @ia_iasdate, @ia_iasseq, @ia_iaitem, @ia_iano, @ia_refno, @ia_mfrno, @ia_pyno, @ia_pyseq, @ia_pyat, @ia_ivat, @ia_invno, @ia_invdate, @ia_fgitri, @ia_rnm, @ia_raddr, @ia_rzip, @ia_rjbti, @ia_rtel, @ia_fgnonauto, @ia_invcd, @ia_taxtp, @ia_status, @ia_cname, @ia_tel, @ia_contno)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iasdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iasdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iasseq", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iasseq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iaitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iaitem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_refno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_refno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyseq", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyseq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyat", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyat", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_ivat", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_ivat", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_fgitri", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgitri", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rnm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rnm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_raddr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_raddr", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rzip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rzip", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rjbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rjbti", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rtel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rtel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_fgnonauto", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgnonauto", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_taxtp", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_status", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_status", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_cname", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_cname", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_tel", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_tel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_contno", System.Data.SqlDbType.Char, 13, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = @"INSERT INTO dbo.iad(iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, iad_fk4, iad_projno, iad_costctr, iad_desc, iad_qty, iad_amt) VALUES (@iad_syscd, @iad_iano, @iad_iaditem, @iad_fk1, @iad_fk2, @iad_fk3, @iad_fk4, @iad_projno, @iad_costctr, @iad_desc, @iad_qty, @iad_amt)";
			this.sqlInsertCommand2.Connection = this.sqlConnection1;
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iano", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iaditem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iaditem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk1", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk1", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk2", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk2", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk3", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk3", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk4", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk4", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_projno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_projno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_costctr", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_costctr", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_desc", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_desc", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_qty", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_qty", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_amt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_amt", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT ia_iaid, ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat, ia_invno, ia_invdate, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti, ia_rtel, ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno FROM dbo.ia";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT obtp_obtpid, obtp_otp1cd, obtp_obtpcd, obtp_obtpnm FROM dbo.c1_obtp";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c1_order.o_oid, dbo.c1_order.o_syscd, dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_order.o_otp2cd, dbo.c1_order.o_mfrno, dbo.c1_order.o_date, dbo.c1_order.o_xmldata, dbo.c1_order.o_cancel, dbo.c1_order.o_iano, dbo.c1_cust.cust_nm, dbo.mfr.mfr_inm, dbo.c1_cust.cust_custno, dbo.mfr.mfr_mfrno, dbo.c1_order.o_syscd + dbo.c1_order.o_custno + dbo.c1_order.o_otp1cd + dbo.c1_order.o_otp1seq AS nostr, dbo.c1_order.o_indate, dbo.c1_order.o_special, dbo.c1_order.o_status FROM dbo.c1_order INNER JOIN dbo.c1_cust ON dbo.c1_order.o_custno = dbo.c1_cust.cust_custno INNER JOIN dbo.mfr ON dbo.c1_order.o_mfrno = dbo.mfr.mfr_mfrno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT iad_iadid, iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, ia" +
				"d_fk4, iad_projno, iad_costctr, iad_desc, iad_qty, iad_amt FROM dbo.iad";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = "DELETE FROM dbo.iad WHERE (iad_iaditem = @iad_iaditem) AND (iad_iano = @iad_iano)" +
				" AND (iad_syscd = @iad_syscd)";
			this.sqlDeleteCommand2.Connection = this.sqlConnection1;
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iaditem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iaditem", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iano", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM dbo.ia WHERE (ia_iano = @ia_iano) AND (ia_syscd = @ia_syscd)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT MAX(ia_iano) AS max_iano, ia_syscd FROM dbo.ia GROUP BY ia_syscd HAVING (i" +
				"a_syscd = \'C1\')";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlUpdateOrderIano
			// 
			this.sqlUpdateOrderIano.CommandText = "UPDATE dbo.c1_order SET o_iano = @o_iano, o_status = @o_status WHERE (o_syscd = @" +
				"o_syscd) AND (o_custno = @o_custno) AND (o_otp1cd = @o_otp1cd) AND (o_otp1seq = " +
				"@o_otp1seq)";
			this.sqlUpdateOrderIano.Connection = this.sqlConnection1;
			this.sqlUpdateOrderIano.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_iano", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateOrderIano.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_status", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_status", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateOrderIano.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateOrderIano.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateOrderIano.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateOrderIano.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter3.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "ia", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("ia_iaid", "ia_iaid"),
																																																			new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd"),
																																																			new System.Data.Common.DataColumnMapping("ia_iasdate", "ia_iasdate"),
																																																			new System.Data.Common.DataColumnMapping("ia_iasseq", "ia_iasseq"),
																																																			new System.Data.Common.DataColumnMapping("ia_iaitem", "ia_iaitem"),
																																																			new System.Data.Common.DataColumnMapping("ia_iano", "ia_iano"),
																																																			new System.Data.Common.DataColumnMapping("ia_refno", "ia_refno"),
																																																			new System.Data.Common.DataColumnMapping("ia_mfrno", "ia_mfrno"),
																																																			new System.Data.Common.DataColumnMapping("ia_pyno", "ia_pyno"),
																																																			new System.Data.Common.DataColumnMapping("ia_pyseq", "ia_pyseq"),
																																																			new System.Data.Common.DataColumnMapping("ia_pyat", "ia_pyat"),
																																																			new System.Data.Common.DataColumnMapping("ia_ivat", "ia_ivat"),
																																																			new System.Data.Common.DataColumnMapping("ia_invno", "ia_invno"),
																																																			new System.Data.Common.DataColumnMapping("ia_invdate", "ia_invdate"),
																																																			new System.Data.Common.DataColumnMapping("ia_fgitri", "ia_fgitri"),
																																																			new System.Data.Common.DataColumnMapping("ia_rnm", "ia_rnm"),
																																																			new System.Data.Common.DataColumnMapping("ia_raddr", "ia_raddr"),
																																																			new System.Data.Common.DataColumnMapping("ia_rzip", "ia_rzip"),
																																																			new System.Data.Common.DataColumnMapping("ia_rjbti", "ia_rjbti"),
																																																			new System.Data.Common.DataColumnMapping("ia_rtel", "ia_rtel"),
																																																			new System.Data.Common.DataColumnMapping("ia_fgnonauto", "ia_fgnonauto"),
																																																			new System.Data.Common.DataColumnMapping("ia_invcd", "ia_invcd"),
																																																			new System.Data.Common.DataColumnMapping("ia_taxtp", "ia_taxtp"),
																																																			new System.Data.Common.DataColumnMapping("ia_status", "ia_status"),
																																																			new System.Data.Common.DataColumnMapping("ia_cname", "ia_cname"),
																																																			new System.Data.Common.DataColumnMapping("ia_tel", "ia_tel"),
																																																			new System.Data.Common.DataColumnMapping("ia_contno", "ia_contno")})});
			this.sqlDataAdapter3.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.ia SET ia_syscd = @ia_syscd, ia_iasdate = @ia_iasdate, ia_iasseq = @ia_iasseq, ia_iaitem = @ia_iaitem, ia_iano = @ia_iano, ia_refno = @ia_refno, ia_mfrno = @ia_mfrno, ia_pyno = @ia_pyno, ia_pyseq = @ia_pyseq, ia_pyat = @ia_pyat, ia_ivat = @ia_ivat, ia_invno = @ia_invno, ia_invdate = @ia_invdate, ia_fgitri = @ia_fgitri, ia_rnm = @ia_rnm, ia_raddr = @ia_raddr, ia_rzip = @ia_rzip, ia_rjbti = @ia_rjbti, ia_rtel = @ia_rtel, ia_fgnonauto = @ia_fgnonauto, ia_invcd = @ia_invcd, ia_taxtp = @ia_taxtp, ia_status = @ia_status, ia_cname = @ia_cname, ia_tel = @ia_tel, ia_contno = @ia_contno WHERE (ia_iano = @Original_ia_iano) AND (ia_syscd = @Original_ia_syscd)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iasdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iasdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iasseq", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iasseq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iaitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iaitem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_refno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_refno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyseq", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyseq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyat", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyat", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_ivat", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_ivat", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_fgitri", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgitri", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rnm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rnm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_raddr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_raddr", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rzip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rzip", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rjbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rjbti", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rtel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rtel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_fgnonauto", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgnonauto", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_taxtp", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_status", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_status", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_cname", System.Data.SqlDbType.VarChar, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_cname", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_tel", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_tel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_contno", System.Data.SqlDbType.Char, 13, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_contno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_obtp", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpid", "obtp_obtpid"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_otp1cd", "obtp_otp1cd"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpcd", "obtp_obtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpnm", "obtp_obtpnm")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_order", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("o_oid", "o_oid"),
																																																				  new System.Data.Common.DataColumnMapping("o_syscd", "o_syscd"),
																																																				  new System.Data.Common.DataColumnMapping("o_custno", "o_custno"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1cd", "o_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1seq", "o_otp1seq"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp2cd", "o_otp2cd"),
																																																				  new System.Data.Common.DataColumnMapping("o_mfrno", "o_mfrno"),
																																																				  new System.Data.Common.DataColumnMapping("o_date", "o_date"),
																																																				  new System.Data.Common.DataColumnMapping("o_xmldata", "o_xmldata"),
																																																				  new System.Data.Common.DataColumnMapping("o_cancel", "o_cancel"),
																																																				  new System.Data.Common.DataColumnMapping("o_iano", "o_iano"),
																																																				  new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				  new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				  new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				  new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				  new System.Data.Common.DataColumnMapping("nostr", "nostr"),
																																																				  new System.Data.Common.DataColumnMapping("o_indate", "o_indate"),
																																																				  new System.Data.Common.DataColumnMapping("o_special", "o_special"),
																																																				  new System.Data.Common.DataColumnMapping("o_status", "o_status")})});
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = @"UPDATE dbo.iad SET iad_syscd = @iad_syscd, iad_iano = @iad_iano, iad_iaditem = @iad_iaditem, iad_fk1 = @iad_fk1, iad_fk2 = @iad_fk2, iad_fk3 = @iad_fk3, iad_fk4 = @iad_fk4, iad_projno = @iad_projno, iad_costctr = @iad_costctr, iad_desc = @iad_desc, iad_qty = @iad_qty, iad_amt = @iad_amt WHERE (iad_iaditem = @Original_iad_iaditem) AND (iad_iano = @Original_iad_iano) AND (iad_syscd = @Original_iad_syscd)";
			this.sqlUpdateCommand2.Connection = this.sqlConnection1;
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iano", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iaditem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iaditem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk1", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk1", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk2", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk2", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk3", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk3", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk4", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk4", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_projno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_projno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_costctr", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_costctr", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_desc", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_desc", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_qty", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_qty", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_amt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_amt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_iaditem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iaditem", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iano", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "ia", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("max_iano", "max_iano"),
																																																			new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd")})});
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.DeleteCommand = this.sqlDeleteCommand2;
			this.sqlDataAdapter4.InsertCommand = this.sqlInsertCommand2;
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "iad", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("iad_iadid", "iad_iadid"),
																																																			 new System.Data.Common.DataColumnMapping("iad_syscd", "iad_syscd"),
																																																			 new System.Data.Common.DataColumnMapping("iad_iano", "iad_iano"),
																																																			 new System.Data.Common.DataColumnMapping("iad_iaditem", "iad_iaditem"),
																																																			 new System.Data.Common.DataColumnMapping("iad_fk1", "iad_fk1"),
																																																			 new System.Data.Common.DataColumnMapping("iad_fk2", "iad_fk2"),
																																																			 new System.Data.Common.DataColumnMapping("iad_fk3", "iad_fk3"),
																																																			 new System.Data.Common.DataColumnMapping("iad_fk4", "iad_fk4"),
																																																			 new System.Data.Common.DataColumnMapping("iad_projno", "iad_projno"),
																																																			 new System.Data.Common.DataColumnMapping("iad_costctr", "iad_costctr"),
																																																			 new System.Data.Common.DataColumnMapping("iad_desc", "iad_desc"),
																																																			 new System.Data.Common.DataColumnMapping("iad_qty", "iad_qty"),
																																																			 new System.Data.Common.DataColumnMapping("iad_amt", "iad_amt")})});
			this.sqlDataAdapter4.UpdateCommand = this.sqlUpdateCommand2;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCreateIa_Click(object sender, System.EventArgs e)
		{
			string	nostr;
			XmlDoc = new System.Xml.XmlDocument();
			int	j=0;
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked==true)
				{
					nostr=((Label)DataList1.Items[i].FindControl("lblNo")).Text.Trim();
					XmlDoc.LoadXml(((HtmlInputHidden)DataList1.Items[i].FindControl("hiddenXML")).Value);
					InsertIAData();
					j++;
//					ItemMain=XmlDoc.SelectSingleNode("/root");
//					textarea1.Value=ItemMain.OuterXml;
//					textarea1.Value=((HtmlInputHidden)DataList1.Items[i].FindControl("hiddenXML")).Value;
				}
			}
			if(j<=0)
				lblMessage.Text="您尚未選擇任何訂單";
			else
				DataList_DataBind();
		}

		private void DataList_DataBind()
		{
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c1_order");
			DataView dv1 = ds1.Tables["c1_order"].DefaultView;
			dv1.RowFilter="o_iano='' and o_status='1' and o_special='' and (o_otp1cd='01' or o_otp1cd='09')";
			if(dv1.Count<=0)
				lblMessage.Text="沒有未開發票之訂單";
			else
			{
				btnCreateIa.Enabled=true;
				lblMessage.Text="有"+dv1.Count.ToString()+"筆未開發票之訂單";
			}
			DataList1.DataSource=dv1;
			DataList1.DataBind();
		}
		private bool InsertIAData()
		{
			XmlNode	ItemMain=XmlDoc.SelectSingleNode("/root");
			XmlNode	ItemOrder=XmlDoc.SelectSingleNode("/root/訂單");
			XmlNode	ItemDetail=XmlDoc.SelectSingleNode("/root/訂單明細");
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c1_obtp");
			DataView dv2 = ds2.Tables["c1_obtp"].DefaultView;
			//Get Max Iano
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "ia");
			DataView dv5 = ds5.Tables["ia"].DefaultView;
			string	iano=dv5[0].Row["max_iano"].ToString();
			string	fy=System.DateTime.Today.Year.ToString();
			if(iano.Substring(0,2)==fy.Substring(2,2))
				iano=Convert.ToString(Int32.Parse(iano)+1);
			else
				iano=fy.Substring(2,2)+"000001";
			//			Response.Write("iano="+iano);
			int	j1=iano.Length;
			for(int j=0; j<8-j1; j++)
				iano="0"+iano;
			//-------新增發票開立單檔--------//
			for(int i=0;i<this.sqlInsertCommand1.Parameters.Count;i++)
			{
				this.sqlInsertCommand1.Parameters[i].Value = "";
			}
			this.sqlInsertCommand1.Parameters["@ia_iano"].Value=iano;
			this.sqlInsertCommand1.Parameters["@ia_syscd"].Value="C1";
			this.sqlInsertCommand1.Parameters["@ia_refno"].Value="C1"+iano;
			this.sqlInsertCommand1.Parameters["@ia_mfrno"].Value=ItemOrder["統一編號"].FirstChild.OuterXml;
			int amt=0;
			for(int i=0; i<ItemDetail.ChildNodes.Count; i++)
			{
				amt=amt+Int32.Parse(ItemDetail.ChildNodes.Item(i).SelectSingleNode("金額").InnerText);
			}
			this.sqlInsertCommand1.Parameters["@ia_pyat"].Value=amt.ToString();
			int amt_iv=(int)Math.Round((float)amt/1.05F);
			this.sqlInsertCommand1.Parameters["@ia_ivat"].Value=amt_iv.ToString();
			if(ItemOrder["付款方式"].FirstChild.OuterXml=="06" || ItemOrder["付款方式"].FirstChild.OuterXml=="07")
				this.sqlInsertCommand1.Parameters["@ia_fgitri"].Value=ItemOrder["付款方式"].FirstChild.OuterXml;
			else
				this.sqlInsertCommand1.Parameters["@ia_fgitri"].Value="";
			this.sqlInsertCommand1.Parameters["@ia_rnm"].Value=ItemOrder["發票收件人姓名"].FirstChild.OuterXml;
			this.sqlInsertCommand1.Parameters["@ia_raddr"].Value=ItemOrder["發票收件人地址"].FirstChild.OuterXml;
			this.sqlInsertCommand1.Parameters["@ia_rzip"].Value=ItemOrder["發票收件人郵遞區號"].FirstChild.OuterXml;
			if(ItemOrder["發票收件人職稱"].FirstChild!=null)
				this.sqlInsertCommand1.Parameters["@ia_rjbti"].Value=ItemOrder["發票收件人職稱"].FirstChild.OuterXml;
			else
				this.sqlInsertCommand1.Parameters["@ia_rjbti"].Value="";
			if(ItemOrder["發票收件人電話"].FirstChild!=null)
				this.sqlInsertCommand1.Parameters["@ia_rtel"].Value=ItemOrder["發票收件人電話"].FirstChild.OuterXml;
			else
				this.sqlInsertCommand1.Parameters["@ia_rtel"].Value="";
			this.sqlInsertCommand1.Parameters["@ia_invcd"].Value=ItemOrder["發票類別"].FirstChild.OuterXml;
			this.sqlInsertCommand1.Parameters["@ia_taxtp"].Value=ItemOrder["發票課稅別"].FirstChild.OuterXml;
			this.sqlInsertCommand1.Parameters["@ia_fgnonauto"].Value="0";
			this.sqlInsertCommand1.Parameters["@ia_status"].Value="";
			this.sqlInsertCommand1.Parameters["@ia_contno"].Value=ItemOrder["訂單流水號"].FirstChild.OuterXml;
			this.sqlInsertCommand1.Connection.Open();
			bool resultflag;
			try
			{
				this.sqlInsertCommand1.ExecuteNonQuery();
				resultflag=true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				resultflag=false;
			}
		
			this.sqlInsertCommand1.Connection.Close();
			if(resultflag)
			{
				//-------新增發票開立明細檔--------//
				int item;
				string	str2;
				for(int i=0; i<ItemDetail.ChildNodes.Count; i++)
				{
					for(int i1=0;i1<this.sqlInsertCommand2.Parameters.Count;i1++)
					{
						this.sqlInsertCommand2.Parameters[i1].Value = "";
					}
					this.sqlInsertCommand2.Parameters["@iad_syscd"].Value="C1";
					this.sqlInsertCommand2.Parameters["@iad_iano"].Value=iano;
					str2=Convert.ToString(i+1);
					item=3-str2.Length;
					for(int k=0; k<item; k++)
						str2="0"+str2;
					this.sqlInsertCommand2.Parameters["@iad_iaditem"].Value=str2;
					this.sqlInsertCommand2.Parameters["@iad_fk1"].Value=ItemOrder["訂戶編號"].FirstChild.OuterXml;
					this.sqlInsertCommand2.Parameters["@iad_fk2"].Value=ItemOrder["訂購類別一"].FirstChild.OuterXml;
					this.sqlInsertCommand2.Parameters["@iad_fk3"].Value=ItemOrder["訂單流水號"].FirstChild.OuterXml.Substring(10,3);
					this.sqlInsertCommand2.Parameters["@iad_fk4"].Value=ItemDetail.ChildNodes.Item(i).SelectSingleNode("項次").InnerText;
					this.sqlInsertCommand2.Parameters["@iad_projno"].Value=ItemDetail.ChildNodes.Item(i).SelectSingleNode("計劃代號").InnerText;
					this.sqlInsertCommand2.Parameters["@iad_costctr"].Value=ItemDetail.ChildNodes.Item(i).SelectSingleNode("成本中心").InnerText;
					//				dv1 = ds1.Tables["c1_obtp"].DefaultView;
					dv2.RowFilter="obtp_otp1cd='"+ItemOrder["訂購類別一"].FirstChild.OuterXml+"' and obtp_obtpcd='"
						+ItemDetail.ChildNodes.Item(i).SelectSingleNode("書籍類別").InnerText+"'";
					this.sqlInsertCommand2.Parameters["@iad_desc"].Value=dv2[0].Row["obtp_obtpnm"].ToString();
					if((ItemDetail.ChildNodes.Item(i).SelectSingleNode("訂閱起時").InnerText!="")&&(ItemDetail.ChildNodes.Item(i).SelectSingleNode("訂閱訖時").InnerText!=""))
					{
						if((ItemDetail.ChildNodes.Item(i).SelectSingleNode("訂閱起時").InnerText.Length>=7)&&(ItemDetail.ChildNodes.Item(i).SelectSingleNode("訂閱訖時").InnerText.Length>=7))
							this.sqlInsertCommand2.Parameters["@iad_desc"].Value=this.sqlInsertCommand2.Parameters["@iad_desc"].Value+ItemDetail.ChildNodes.Item(i).SelectSingleNode("訂閱起時").InnerText.Substring(0,7)
								+"~"+ItemDetail.ChildNodes.Item(i).SelectSingleNode("訂閱訖時").InnerText.Substring(0,7);
					}
					//				this.sqlInsertCommand2.Parameters["@iad_unit"].Value="";
					this.sqlInsertCommand2.Parameters["@iad_qty"].Value=Convert.ToInt32(ItemDetail.ChildNodes.Item(i).SelectSingleNode("總數量").InnerText);
					//				this.sqlInsertCommand2.Parameters["@iad_uprice"].Value=0.0;
					this.sqlInsertCommand2.Parameters["@iad_amt"].Value=Convert.ToInt32(ItemDetail.ChildNodes.Item(i).SelectSingleNode("金額").InnerText);
					this.sqlInsertCommand2.Connection.Open();
					this.sqlInsertCommand2.ExecuteNonQuery();
					this.sqlInsertCommand2.Connection.Close();
				}
//				this.sqlUpdateOrderIano.Parameters["@Original_o_syscd"].Value=ItemOrder["系統代碼"].FirstChild.OuterXml;
//				this.sqlUpdateOrderIano.Parameters["@Original_o_custno"].Value=ItemOrder["訂戶編號"].FirstChild.OuterXml;
//				this.sqlUpdateOrderIano.Parameters["@Original_o_otp1cd"].Value=ItemOrder["訂購類別一"].FirstChild.OuterXml;
//				this.sqlUpdateOrderIano.Parameters["@Original_o_otp1seq"].Value=ItemOrder["訂單流水號"].FirstChild.OuterXml.Substring(10,3);
				this.sqlUpdateOrderIano.Parameters["@o_syscd"].Value=ItemOrder["系統代碼"].FirstChild.OuterXml;
				this.sqlUpdateOrderIano.Parameters["@o_custno"].Value=ItemOrder["訂戶編號"].FirstChild.OuterXml;
				this.sqlUpdateOrderIano.Parameters["@o_otp1cd"].Value=ItemOrder["訂購類別一"].FirstChild.OuterXml;
				this.sqlUpdateOrderIano.Parameters["@o_otp1seq"].Value=ItemOrder["訂單流水號"].FirstChild.OuterXml.Substring(10,3);
				this.sqlUpdateOrderIano.Parameters["@o_iano"].Value=iano;
				this.sqlUpdateOrderIano.Parameters["@o_status"].Value="3";	//已產生發票開立單
				this.sqlUpdateOrderIano.Connection.Open();
				this.sqlUpdateOrderIano.ExecuteNonQuery();
				this.sqlUpdateOrderIano.Connection.Close();
			}
			return resultflag;
//			return true;
		}
	}
}
