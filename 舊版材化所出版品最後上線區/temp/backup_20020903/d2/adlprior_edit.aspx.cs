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
	/// Summary description for adlprior_edit.
	/// </summary>
	public class adlprior_edit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Web.UI.WebControls.DropDownList ddlColorCode;
		protected System.Web.UI.WebControls.DropDownList ddlLayoutTypeCode;
		protected System.Web.UI.WebControls.DropDownList ddPageSizeCode;
		protected System.Web.UI.WebControls.TextBox tbxPriorSeq;
		

		// �ŧi global_xxx
		private static string global_bkcd;
		private static string global_priorseq;
		private static string global_clrcd;
		private static string global_ltpcd;
		private static string global_pgscd;
		
		
		public adlprior_edit()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!IsPostBack)
			{
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
			// ��ܤU�Ԧ���� ���y���O�� DB ��
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "book");
			DataView dv2=ds2.Tables["book"].DefaultView;
			ddlBookCode.DataSource=dv2;
			ddlBookCode.DataTextField="bk_nm";
			ddlBookCode.DataValueField="bk_bkcd";
			ddlBookCode.DataBind();
			
			// ��ܤU�Ԧ���� �s�i��m�� DB ��
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c2_clr");
			DataView dv3=ds3.Tables["c2_clr"].DefaultView;
			ddlColorCode.DataSource=dv3;
			ddlColorCode.DataTextField="clr_nm";
			ddlColorCode.DataValueField="clr_clrcd";
			ddlColorCode.DataBind();
			
			// ��ܤU�Ԧ���� �s�i������ DB ��
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "c2_ltp");
			DataView dv4=ds4.Tables["c2_ltp"].DefaultView;
			ddlLayoutTypeCode.DataSource=dv4;
			ddlLayoutTypeCode.DataTextField="ltp_nm";
			ddlLayoutTypeCode.DataValueField="ltp_ltpcd";
			ddlLayoutTypeCode.DataBind();
			
			// ��ܤU�Ԧ���� �s�i�g�T�� DB ��
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "c2_pgsize");
			DataView dv5=ds5.Tables["c2_pgsize"].DefaultView;
			ddPageSizeCode.DataSource=dv5;
			ddPageSizeCode.DataTextField="pgs_nm";
			ddPageSizeCode.DataValueField="pgs_pgscd";
			ddPageSizeCode.DataBind();
			
			
			// ����X����ܸ�Ʈw���������
			string id = Request.QueryString["ID"].ToString();
			
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds1 = new DataSet();
			DataView dv1;
			this.sqlDataAdapter1.Fill(ds1, "c2_lprior");
			dv1 = ds1.Tables["c2_lprior"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			dv1.RowFilter = "lp_lpid=" + id;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			// �Y��즹�����, �h���J���
			if(dv1.Count>0)
			{
				string bkcd = dv1[0]["lp_bkcd"].ToString();
				string priorseq = dv1[0]["lp_priorseq"].ToString().Trim();
				string clrcd = dv1[0]["lp_clrcd"].ToString();
				string ltpcd = dv1[0]["lp_ltpcd"].ToString();
				string pgscd = dv1[0]["lp_pgscd"].ToString();
				//Response.Write("bkcd= " + bkcd + "<br>");
				
				// ���w global_xxx ����Ӧs�b��Ʈw������l��; �H�ǻ��� btnUpdate_Click() �Ӱ����
				global_bkcd = bkcd;
				global_priorseq = priorseq.Trim();
				global_clrcd = clrcd;
				global_ltpcd = ltpcd;
				global_pgscd = pgscd;
				
				this.ddlBookCode.SelectedIndex = (int.Parse(bkcd)-1);
				this.tbxPriorSeq.Text = priorseq;
				this.ddlColorCode.SelectedIndex = (int.Parse(clrcd)-1);
				this.ddlLayoutTypeCode.SelectedIndex = (int.Parse(ltpcd)-1);
				this.ddPageSizeCode.SelectedIndex = (int.Parse(pgscd)-1);

			}
			
			
		}
			

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM c2_lprior WHERE (lp_bkcd = @lp_bkcd) AND (lp_priorseq = @lp_priorseq)" +
				" AND (lp_clrcd = @lp_clrcd) AND (lp_lpid = @lp_lpid) AND (lp_ltpcd = @lp_ltpcd) " +
				"AND (lp_pgscd = @lp_pgscd)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lp_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_bkcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lp_priorseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_priorseq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lp_clrcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_clrcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lp_lpid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_lpid", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lp_ltpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_ltpcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lp_pgscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_pgscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_ltp", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("ltp_ltpid", "ltp_ltpid"),
																																																				new System.Data.Common.DataColumnMapping("ltp_ltpcd", "ltp_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT ltp_ltpid, ltp_ltpcd, ltp_nm FROM c2_ltp";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT clr_clrid, clr_clrcd, clr_nm FROM c2_clr";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT bk_bkid, bk_bkcd, bk_nm FROM book";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT lp_lpid, lp_bkcd, lp_priorseq, lp_clrcd, lp_ltpcd, lp_pgscd FROM c2_lprior" +
				"";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT pgs_pgsid, pgs_pgscd, pgs_nm FROM c2_pgsize";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("bk_bkid", "bk_bkid"),
																																																			  new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm")})});
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pgsize", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("pgs_pgsid", "pgs_pgsid"),
																																																				   new System.Data.Common.DataColumnMapping("pgs_pgscd", "pgs_pgscd"),
																																																				   new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm")})});
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_clr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("clr_clrid", "clr_clrid"),
																																																				new System.Data.Common.DataColumnMapping("clr_clrcd", "clr_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm")})});
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE c2_lprior SET lp_bkcd = @lp_bkcd, lp_priorseq = @lp_priorseq, lp_clrcd = @lp_clrcd, lp_ltpcd = @lp_ltpcd, lp_pgscd = @lp_pgscd WHERE (lp_bkcd = @Original_lp_bkcd) AND (lp_priorseq = @Original_lp_priorseq) AND (lp_clrcd = @Original_lp_clrcd) AND (lp_ltpcd = @Original_lp_ltpcd) AND (lp_pgscd = @Original_lp_pgscd); SELECT lp_lpid, lp_bkcd, lp_priorseq, lp_clrcd, lp_ltpcd, lp_pgscd FROM c2_lprior WHERE (lp_bkcd = @Select_lp_bkcd) AND (lp_priorseq = @Select_lp_priorseq)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lp_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_bkcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lp_priorseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_priorseq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lp_clrcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_clrcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lp_ltpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_ltpcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lp_pgscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_pgscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lp_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_bkcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lp_priorseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_priorseq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lp_clrcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_clrcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lp_ltpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_ltpcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_lp_pgscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_pgscd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_lp_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_bkcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_lp_priorseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_priorseq", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lprior", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("lp_lpid", "lp_lpid"),
																																																				   new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_priorseq", "lp_priorseq"),
																																																				   new System.Data.Common.DataColumnMapping("lp_clrcd", "lp_clrcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_ltpcd", "lp_ltpcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_pgscd", "lp_pgscd")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO c2_lprior(lp_bkcd, lp_priorseq, lp_clrcd, lp_ltpcd, lp_pgscd) VALUES (@lp_bkcd, @lp_priorseq, @lp_clrcd, @lp_ltpcd, @lp_pgscd); SELECT lp_lpid, lp_bkcd, lp_priorseq, lp_clrcd, lp_ltpcd, lp_pgscd FROM c2_lprior WHERE (lp_bkcd = @Select_lp_bkcd) AND (lp_priorseq = @Select_lp_priorseq)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lp_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_bkcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lp_priorseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_priorseq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lp_clrcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_clrcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lp_ltpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_ltpcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lp_pgscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_pgscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_lp_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_bkcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_lp_priorseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lp_priorseq", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void btnUpdate_Click(object sender, System.EventArgs e)
		{	
			string id = Request.QueryString["ID"].ToString();
			
			String strConn="server=isccom1;database=mrlpub;uid=webuser;pwd=db600";
			SqlConnection myConn=new SqlConnection(strConn);
			string SQL = "select * from c2_lprior";
			SqlDataAdapter myCommand = new SqlDataAdapter(SQL,myConn);

			DataSet ds = new DataSet();
			myCommand.Fill(ds,"c2_lprior");
			DataView dv = ds.Tables["c2_lprior"].DefaultView;
			
			// ��X�ثe�e���̪��U�ӭ�, �H��g�л\ db
			string Currentbkcd = ddlBookCode.SelectedItem.Value.Trim();
			string Currentpriorseq = tbxPriorSeq.Text.ToString().Trim();
			string Currentclrcd = ddlColorCode.SelectedItem.Value.Trim();
			string Currentltpcd = ddlLayoutTypeCode.SelectedItem.Value.Trim();
			string Currentpgscd = ddPageSizeCode.SelectedItem.Value.Trim();
			//Response.Write("ddlBookCode.SelectedItem.Value=" + Currentbkcd+ "<br>");
			//Response.Write("tbxPriorSeq.Text=" + Currentpriorseq + "<br>");
			//Response.Write("ddlColorCode.SelectedItem.Value=" + Currentclrcd + "<br>");
			//Response.Write("ddlLayoutTypeCode.SelectedItem.Value=" + Currentltpcd + "<br>");
			//Response.Write("ddPageSizeCode.SelectedItem.Value=" + Currentpgscd + "<br>");
			dv.RowFilter = "lp_bkcd = '" + Currentbkcd + "' AND lp_priorseq = '" + Currentpriorseq + "' AND lp_clrcd = '" + Currentclrcd + "' AND lp_ltpcd = '" + Currentltpcd + "' AND lp_pgscd = '" + Currentpgscd + "'";
			//Response.Write("dv.RowFilter=" + dv.RowFilter.ToString().Trim() + "<br>");
			//Response.Write("dv.Count=" + dv.Count + "<br>");

			// �ˬd initData() �� - ��Ӧs�b��Ʈw������ global_xxx �O�_�����
			//Response.Write("global_bkcd=" + global_bkcd + "<br>");
			//Response.Write("global_priorseq=" + global_priorseq + "<br>");
			//Response.Write("global_clrcd=" + global_clrcd + "<br>");
			//Response.Write("global_ltpcd=" + global_ltpcd + "<br>");
			//Response.Write("global_pgscd=" + global_pgscd + "<br><br>");
			
			// �Y�ثe�e���̪��Ȧb��Ʈw����o�� (�Y dv.count>0) �B pk �Ȥ��ۦP��: ���ˬd��Ʈw�̬O�_�����и��
			//Response.Write("Currentbkcd=" + Currentbkcd + "!= global_bkcd=" + global_bkcd + "<br>");
			//Response.Write("Currentpriorseq=" + Currentpriorseq + "!= global_priorseq=" + global_priorseq + "<br>");
			//Response.Write("Currentclrcd=" + Currentclrcd + "!= global_clrcd=" + global_clrcd + "<br>");
			//Response.Write("Currentltpcd=" + Currentltpcd + "!= global_ltpcd=" + global_ltpcd + "<br>");
			//Response.Write("Currentpgscd=" + Currentpgscd + "!= global_pgscd=" + global_pgscd + "<br>");
			if (dv.Count > 0 && (Currentbkcd != global_bkcd || Currentpriorseq != global_priorseq || Currentclrcd != global_clrcd || Currentltpcd != global_ltpcd || Currentpgscd != global_pgscd))
			{
				Label1.Text="�ק異��: ������Ƥw�g�s�b!";
			}
			// �Y�D���Ъ����, ��s���
			else
			{
				// ��s db table �ӵ��Ҧ�����
				SqlDataAdapter cmd=new SqlDataAdapter("update c2_lprior set lp_bkcd=@lp_bkcd, lp_priorseq=@lp_priorseq, lp_clrcd=@lp_clrcd, lp_ltpcd=@lp_ltpcd, lp_pgscd=@lp_pgscd where lp_lpid=@lp_lpid",myConn);
		
				cmd.SelectCommand.Parameters.Add("@lp_lpid",SqlDbType.Int,4).Value = id;
				cmd.SelectCommand.Parameters.Add("@lp_bkcd",SqlDbType.Char,2).Value = Currentbkcd;
				cmd.SelectCommand.Parameters.Add("@lp_priorseq",SqlDbType.Char,2).Value = Currentpriorseq;
				cmd.SelectCommand.Parameters.Add("@lp_clrcd",SqlDbType.Char,2).Value = Currentclrcd;
				cmd.SelectCommand.Parameters.Add("@lp_ltpcd",SqlDbType.Char,2).Value = Currentltpcd;
				cmd.SelectCommand.Parameters.Add("@lp_pgscd",SqlDbType.Char,2).Value = Currentpgscd;
				
				DataSet ds1 = new DataSet();
				cmd.Fill(ds1,"c2_lprior");
				
				// ��s��, ����}�ʧ@
				Response.Redirect("adlprior.aspx");
			}
			
		}

		
		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("adlprior.aspx");
		}


	}
}
