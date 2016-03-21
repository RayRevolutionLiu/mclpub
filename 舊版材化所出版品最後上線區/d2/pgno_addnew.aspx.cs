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
	/// Summary description for pgno_addnew.
	/// </summary>
	public class pgno_addnew : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.DropDownList ddlBkcd;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.RequiredFieldValidator rev1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Web.UI.WebControls.TextBox tbxStartPageNo;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Button btnReturnHome;
		
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;
			
			if(!Page.IsPostBack)
			{
				Response.Expires = 0;
				
				// ���J�w�]���
				InitialData();
			}
		}
		
		
		private void InitialData()
		{
			this.lblMessage.Text = "";
			this.tbxStartPageNo.Text = "4";
			
			
			// ��ܤU�Ԧ���� ���y���O�� DB ��
			// ���� nostr, �а� sqlDataAdapter2.Select statement; 
			// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "book");
			DataView dv1=ds1.Tables["book"].DefaultView;
			ddlBkcd.DataSource=dv1;
			dv1.RowFilter="proj_fgitri=''";
			ddlBkcd.DataTextField="bk_nm";
			//ddlBookCode.DataValueField="nostr";
			// ���@�e��: ddl�ȥ� nostr �אּ bk_bkcd, �~��Ϥ���� ���y���O, �_�h�� option �Ȭ� nostr, �ӫD bk_bkcd
			ddlBkcd.DataValueField="bk_bkcd";
			ddlBkcd.DataBind();
		}
		
		
		// �T�{�s�W ���s���B�z
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			// ��X ���y���O PK, �ˬd��ƬO�_���п�J
			string strbkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c2_pgno");
			DataView dv2 = ds2.Tables["c2_pgno"].DefaultView;
				
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr2 = "1=1";
			rowfilterstr2 = rowfilterstr2 + " AND pg_bkcd='" + strbkcd + "'";
			dv2.RowFilter = rowfilterstr2;
				
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
				
			// �Y�j�M���G�� "�䤣��" ���B�z
			if (dv2.Count > 0)
			{
				this.lblMessage.Text = "�ܩ�p, '" + this.ddlBkcd.SelectedItem.Text.ToString().Trim() + "' �w���_�Ҥ��X���, �s�W����!<br>�Э�����y���O �� ���s�W!";
			}
			else
			{
				InsertToDB();
			}
		}
		
		
		private void InsertToDB()
		{
			// ��X�e���W����
			string strbkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			string strStartPageNo = this.tbxStartPageNo.Text.ToString().Trim();
			//Response.Write("strbkcd= " + strbkcd + "<br>");
			//Response.Write("strStartPageNo= " + strStartPageNo + "<br>");
			
			
			// ���� �N�ȶ�J sqlCommand1.Parameters ��, �H���� �s�W�J��Ʈw
			//Response.Write(this.sqlCommand1.CommandText);
			this.sqlCommand1.Parameters["@bkcd"].Value = strbkcd;
			this.sqlCommand1.Parameters["@startpgno"].Value = strStartPageNo;
			//Response.Write(sqlCommand1.Parameters.Count.ToString().Trim());
			
			
			// �T�{���� sqlCommand1 ���\
			this.sqlCommand1.Connection.Open();
    
			// �ϥ� Transaction �T�{������ʧ@
			System.Data.SqlClient.SqlTransaction myTrans = this.sqlCommand1.Connection.BeginTransaction();
			this.sqlCommand1.Transaction = myTrans;
			try
			{
				this.sqlCommand1.ExecuteNonQuery();
				myTrans.Commit();
				Literal1.Text = "<script language=javascript>alert(\"��Ʒs�W���\!\");</script>";
				// ��}
				Response.Redirect("pgno.aspx");
			}
			catch(System.Data.SqlClient.SqlException ex1)
			{
				Response.Write(ex1.Message + "<br>");
				myTrans.Rollback();
				Literal1.Text = "<script language=javascript>alert(\"��Ʒs�W����!\");</script>";
			}
			finally
			{
				this.sqlCommand1.Connection.Close();
			}
		}
		
		
		// ���s�W ���s���B�z
		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			// ��}
			Response.Redirect("pgno.aspx");
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
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
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
																																																			  new System.Data.Common.DataColumnMapping("proj_fgitri", "proj_fgitri"),
																																																			  new System.Data.Common.DataColumnMapping("proj_projno", "proj_projno"),
																																																			  new System.Data.Common.DataColumnMapping("proj_costctr", "proj_costctr"),
																																																			  new System.Data.Common.DataColumnMapping("nostr", "nostr"),
																																																			  new System.Data.Common.DataColumnMapping("proj_bkcd", "proj_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("Expr1", "Expr1")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT book.bk_bkid, book.bk_bkcd, RTRIM(book.bk_nm) AS bk_nm, proj.proj_syscd, RTRIM(proj.proj_fgitri) AS proj_fgitri, proj.proj_projno, proj.proj_costctr, book.bk_bkcd + proj.proj_projno + proj.proj_costctr AS nostr, proj.proj_bkcd, proj.proj_fgitri AS Expr1 FROM book INNER JOIN proj ON book.bk_bkcd = proj.proj_bkcd WHERE (proj.proj_syscd = 'C2')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
//				"nfo=True;user id=sa;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "INSERT INTO c2_pgno (pg_bkcd, pg_startpgno) VALUES (@bkcd, @startpgno)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "pg_bkcd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@startpgno", System.Data.SqlDbType.Int, 4, "pg_startpgno"));
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pgno", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("pg_pgid", "pg_pgid"),
																																																				 new System.Data.Common.DataColumnMapping("pg_bkcd", "pg_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pg_startpgno", "pg_startpgno")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT pg_pgid, pg_bkcd, pg_startpgno FROM c2_pgno";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
	}
}
