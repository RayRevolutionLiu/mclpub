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
	/// Summary description for admade_stat.
	/// </summary>
	public class admade_stat : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.LinkButton lnbClearAll;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Web.UI.WebControls.TextBox tbxyyyymm;
		protected System.Web.UI.WebControls.CheckBox cbx0;
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpCName;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpNo;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPubDate;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.Label lblMemo;
	
		public admade_stat()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{	
				Response.Expires=0;
				
				// �M���e�����
				this.cbx0.Checked = false;
				this.lblMessage.Text = "";
				
				
				// �� �ʽZ�~�� tbxYYYYMM �w�]�� (���Ѧ~��)
				this.tbxyyyymm.Text = System.DateTime.Today.ToString("yyyy/MM").Trim();
				
				
				// ��ܤU�Ԧ���� �~�ȭ��� DB ��
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "srspn");
				ddlEmpNo.DataSource=ds1;
				ddlEmpNo.DataTextField="srspn_cname";
				ddlEmpNo.DataValueField="srspn_empno";
				ddlEmpNo.DataBind();
				
				//�p�G�OD�ź޲z�̡A�ȯ�d�ݨ�ۤv���Ȥ���
				if((Session["RegOK"] != null) && ((bool)Session["RegOK"] == true))
				{
					
					if(Session["atype"].ToString().Equals("D"))
					{
						if(this.ddlEmpNo.Items.FindByValue(Session["empid"].ToString()) != null)
						{
							this.ddlEmpNo.Items.FindByValue(Session["empid"].ToString()).Selected = true;
							this.ddlEmpNo.Enabled = false;
							this.cbx0.Checked = true;
							this.cbx0.Enabled = false;
						}
					}
				}
				
				// ��X�n�J�̪��u��, �@���w�] �s��~�ȭ� ����
				string LoginEmpNo = "";
				string LoginEmpCName = "";
				//Response.Write("empid= " + User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) + "<br>");
				// �Y���n�J�̪����, �h��X�ùw�� ���ɷ~�ȭ����U�Ԧ����
				if(User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1)!=null && User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) != "")
				{
					LoginEmpNo = User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
					
					
					// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
					DataSet ds4 = new DataSet();
					this.sqlDataAdapter4.Fill(ds4, "srspn");
					DataView dv4 = ds4.Tables["srspn"].DefaultView;
					
					// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
					string rowfilterstr4 = "1=1";
					rowfilterstr4 = rowfilterstr4 + " AND srspn_empno='" + LoginEmpNo + "'";
					dv4.RowFilter = rowfilterstr4;
					
					// �ˬd�ÿ�X �̫� Row Filter �����G
					//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
					//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");
					
					// �Y�����, �h��ܬ������; �_�h�������~�T��
					if(dv4.Count > 0)
					{
						LoginEmpCName = dv4[0]["srspn_cname"].ToString().Trim();
					}
					else
					{
						LoginEmpCName = "(����)";
					}
				}
				this.tbxLoginEmpNo.Text = LoginEmpNo;
				this.tbxLoginEmpCName.Text = LoginEmpCName;
				//Response.Write("LoginEmpNo= " + LoginEmpNo + "<br>");
				//Response.Write("LoginEmpCName= " + LoginEmpCName + "<br>");
				
				
				// ��ܤU�Ԧ���� ���y���O�� DB ��
				// ���� nostr, �а� sqlDataAdapter3.Select statement; 
				// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "book");
				DataView dv2=ds2.Tables["book"].DefaultView;
				ddlBookCode.DataSource=dv2;
				dv2.RowFilter="proj_fgitri=''";
				ddlBookCode.DataTextField="bk_nm";
				//ddlBookCode.DataValueField="nostr";
				// ���@�e��: ddl�ȥ� nostr �אּ bk_bkcd, �~��Ϥ���� ���y���O, �_�h�� option �Ȭ� nostr, �ӫD bk_bkcd
				ddlBookCode.DataValueField="bk_bkcd";
				ddlBookCode.DataBind();
			}
		}
		
		
		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		// �M�����d ���s���B�z
		private void lnbClearAll_Click(object sender, System.EventArgs e)
		{
			// ��}
			Response.Redirect("admade_stat.aspx");
		}
		
		
		// ����U "�d��" ��
		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			// ���P�_�ʽZ�~��O�_����, �_�h�����~��ʧ@
			// �d�߱���G: �ʽZ�~�묰������, �Y�S��h�����~��ʧ@
			if(this.tbxyyyymm.Text.ToString().Trim() == "")
			{
				this.lblMessage.Text = "�ܩ�p, �ʽZ�~�묰������, �_�h�L�k�~��ʧ@!";
			}
			else
			{
				// �I�s Stored Procedures
				ExecGetadSP();
			}
		}
		
		
		// �I�s Stored Procedures, ���� wk_c2_rp2
		private void ExecGetadSP()
		{
			// ��X�e���W����, �ӷ��z�����
			string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxyyyymm.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			string strEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
			string strLoginEmpNo = this.tbxLoginEmpNo.Text.ToString().Trim();
			//Response.Write("strBkcd= " + strBkcd + "<BR>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<BR>");
			//Response.Write("strEmpNo= " + strEmpNo + "<BR>");
			//Response.Write("strLoginEmpNo= " + strLoginEmpNo + "<BR>");
			
			
			// Stored Procedures - �I�s sp_c2_rp2
			// ���� �N�ȶ�J sqlCommand1.Parameters ��, �H���� �s�W�J��Ʈw
			//Response.Write(this.sqlCommand1.CommandText);
			this.sqlCommand1.Parameters["@bkcd"].Value = strBkcd;
			this.sqlCommand1.Parameters["@yyyymm"].Value = strYYYYMM;
			
			
			// �T�{���� sqlCommand1 ���\
			this.sqlCommand1.Connection.Open();
			// �ϥ� Transaction �T�{������ʧ@
			System.Data.SqlClient.SqlTransaction myTrans1 = this.sqlCommand1.Connection.BeginTransaction();
			this.sqlCommand1.Transaction = myTrans1;
			//Response.Write(sqlCommand1.Parameters.Count.ToString().Trim());
			try
			{
				this.sqlCommand1.ExecuteNonQuery();
				myTrans1.Commit();
				//Response.Write("����SP��Ʀ��\!<br>");
			}
			catch(System.Data.SqlClient.SqlException ex1)
			{
				Response.Write(ex1.Message + "<br>");
				myTrans1.Rollback();
				//Response.Write("����SP��ƥ���!<br>");
			}
			finally
			{
				this.sqlCommand1.Connection.Close();
			}
			
			
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "wk_c2_rp2");
			DataView dv3 = ds3.Tables["wk_c2_rp2"].DefaultView;
			
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr3 = "1=1";
			
			// �X�����O �z�����
			if(this.cbx0.Checked)
			{
				rowfilterstr3 = rowfilterstr3 + " AND empno='" + strEmpNo + "'";
			}
			else
			{
				rowfilterstr3 = rowfilterstr3;
			}
			dv3.RowFilter = rowfilterstr3;
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");
			
			// �Y�j�M���G�� "�䤣��" ���B�z
			if (dv3.Count > 0)
			{
				// ��}
				string RedirectURL = "admade_stat2.aspx";
				
				// ���y���O & �Z�n�~�� �z�����
				RedirectURL = RedirectURL + "?bkcd=" + strBkcd;
				RedirectURL = RedirectURL + "&yyyymm=" + strYYYYMM;
				if(this.cbx0.Checked)
				{
					RedirectURL = RedirectURL + "&empno=" + strEmpNo;
				}
				else
				{
					RedirectURL = RedirectURL + "&empno=";
				}
				RedirectURL = RedirectURL + "&LEmpno=" + strLoginEmpNo;
				//Response.Write("RedirectURL= " + RedirectURL + "<br>");
				
				this.lblMessage.Text = "�d�ߵ��G: ��� " + dv3.Count + " �����; ���~��� <A HREF='" + RedirectURL + "' Target='_blank'>���s��</A> ���~��i��U�@�ʧ@!<br>";
			}
			else
			{
				this.lblMessage.Text = "�䤣��ŦX���󪺸��, �z�i�H ���]����!";
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
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.lnbClearAll.Click += new System.EventHandler(this.lnbClearAll_Click);
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("srspn_id", "srspn_id"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_orgcd", "srspn_orgcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_deptcd", "srspn_deptcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_date", "srspn_date")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT srspn_id, RTRIM(srspn_empno) AS srspn_empno, RTRIM(srspn_cname) AS srspn_c" +
				"name, RTRIM(srspn_tel) AS srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srs" +
				"pn_date FROM dbo.srspn WHERE (srspn_atype <> \'a\') AND (srspn_atype <> \'f\')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = ConfigurationSettings.AppSettings["itridpa_mrlpub"];
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("bk_bkid", "bk_bkid"),
																																																			  new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																			  new System.Data.Common.DataColumnMapping("proj_syscd", "proj_syscd"),
																																																			  new System.Data.Common.DataColumnMapping("proj_bkcd", "proj_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("proj_fgitri", "proj_fgitri"),
																																																			  new System.Data.Common.DataColumnMapping("proj_projno", "proj_projno"),
																																																			  new System.Data.Common.DataColumnMapping("proj_costctr", "proj_costctr")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (dbo.proj.proj_fgitri = ' ')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "wk_c2_rp2", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("contno", "contno"),
																																																				   new System.Data.Common.DataColumnMapping("yyyymm", "yyyymm"),
																																																				   new System.Data.Common.DataColumnMapping("pubseq", "pubseq"),
																																																				   new System.Data.Common.DataColumnMapping("pgno", "pgno"),
																																																				   new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				   new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																				   new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																				   new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				   new System.Data.Common.DataColumnMapping("fggot", "fggot"),
																																																				   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				   new System.Data.Common.DataColumnMapping("empno", "empno"),
																																																				   new System.Data.Common.DataColumnMapping("drafttp", "drafttp"),
																																																				   new System.Data.Common.DataColumnMapping("fgrechg", "fgrechg"),
																																																				   new System.Data.Common.DataColumnMapping("unfgrechg", "unfgrechg"),
																																																				   new System.Data.Common.DataColumnMapping("chgbk_nm", "chgbk_nm"),
																																																				   new System.Data.Common.DataColumnMapping("chgjno", "chgjno"),
																																																				   new System.Data.Common.DataColumnMapping("chgjbkno", "chgjbkno"),
																																																				   new System.Data.Common.DataColumnMapping("origbk_nm", "origbk_nm"),
																																																				   new System.Data.Common.DataColumnMapping("origjno", "origjno"),
																																																				   new System.Data.Common.DataColumnMapping("origjbkno", "origjbkno"),
																																																				   new System.Data.Common.DataColumnMapping("njtpcd01", "njtpcd01"),
																																																				   new System.Data.Common.DataColumnMapping("njtpcd02", "njtpcd02"),
																																																				   new System.Data.Common.DataColumnMapping("njtpcd03", "njtpcd03"),
																																																				   new System.Data.Common.DataColumnMapping("njtpcd04", "njtpcd04"),
																																																				   new System.Data.Common.DataColumnMapping("njtpcd05", "njtpcd05"),
																																																				   new System.Data.Common.DataColumnMapping("fgupdated", "fgupdated"),
																																																				   new System.Data.Common.DataColumnMapping("clrcd", "clrcd"),
																																																				   new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				   new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				   new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				   new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				   new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				   new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd")})});
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_orgcd", "srspn_orgcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_deptcd", "srspn_deptcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_date", "srspn_date")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT RTRIM(srspn_empno) AS srspn_empno, RTRIM(srspn_cname) AS srspn_cname, RTRI" +
				"M(srspn_tel) AS srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date FR" +
				"OM dbo.srspn";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "dbo.[sp_c2_rp2]";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6));
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT dbo.wk_c2_rp2.contno, dbo.wk_c2_rp2.yyyymm, dbo.wk_c2_rp2.pubseq, dbo.wk_c2_rp2.pgno, dbo.wk_c2_rp2.clr_nm, dbo.wk_c2_rp2.ltp_nm, dbo.wk_c2_rp2.pgs_nm, dbo.wk_c2_rp2.mfr_inm, dbo.wk_c2_rp2.fggot, dbo.wk_c2_rp2.srspn_cname, dbo.wk_c2_rp2.empno, dbo.wk_c2_rp2.drafttp, dbo.wk_c2_rp2.fgrechg, dbo.wk_c2_rp2.unfgrechg, dbo.wk_c2_rp2.chgbk_nm, dbo.wk_c2_rp2.chgjno, dbo.wk_c2_rp2.chgjbkno, dbo.wk_c2_rp2.origbk_nm, dbo.wk_c2_rp2.origjno, dbo.wk_c2_rp2.origjbkno, dbo.wk_c2_rp2.njtpcd01, dbo.wk_c2_rp2.njtpcd02, dbo.wk_c2_rp2.njtpcd03, dbo.wk_c2_rp2.njtpcd04, dbo.wk_c2_rp2.njtpcd05, dbo.wk_c2_rp2.fgupdated, dbo.wk_c2_rp2.clrcd, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd FROM dbo.wk_c2_rp2 INNER JOIN dbo.c2_cont ON dbo.wk_c2_rp2.contno COLLATE Chinese_Taiwan_Stroke_CI_AS = dbo.c2_cont.cont_contno WHERE (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_cont.cont_fgpubed = '1')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
	}
}
