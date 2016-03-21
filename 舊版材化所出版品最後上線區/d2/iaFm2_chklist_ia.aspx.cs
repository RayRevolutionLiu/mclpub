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
	/// Summary description for iaFm2_chklist_ia.
	/// </summary>
	public class iaFm2_chklist_ia : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Panel pnlQuery;
		protected System.Web.UI.WebControls.Label lblBkcd;
		protected System.Web.UI.WebControls.DropDownList ddlBkcd;
		protected System.Web.UI.WebControls.Label lblYYYYMM;
		protected System.Web.UI.WebControls.TextBox tbxYYYYMM;
		protected System.Web.UI.WebControls.Label lblOrderByFilter;
		protected System.Web.UI.WebControls.DropDownList ddlOrderByFilter;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnClear;
		protected System.Web.UI.WebControls.TextBox tbxIAStatus;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblMessage2;
		protected System.Web.UI.WebControls.Label lblIabSeq;
		protected System.Web.UI.WebControls.TextBox tbxIabseq;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpNo;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpCName;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPubDate;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.Button btnReQuery;


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;

			if(!Page.IsPostBack)
			{
				Response.Expires = 0;


				// ��ܸ��
				GetAction();
				//InitialData();
			}
		}


		//
		private void GetAction()
		{
			// ��X QueryString
			string strAction = Context.Request.QueryString["action"].Trim();
			//Response.Write("strAction= " + strAction + "<br>");

			// �Y strAction �� 1, ��ܬd�߿ﶵ; �Y�� 2, �h������� ia �ˮ֪��e
			if(strAction == "1")
			{
				this.pnlQuery.Visible = true;
				InitialData();
			}
			else if(strAction == "2")
			{
				this.pnlQuery.Visible = false;

				// ��� DataGrid1
				BindGrid1();
			}
		}


		// �� �w�]��
		private void InitialData()
		{
			this.lblMessage.Text  = "";
			this.lblMessage2.Text = "";
			this.btnPrintList.Visible = false;
			this.btnReQuery.Visible = false;


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
			this.ddlBkcd.SelectedIndex = 0;

			this.tbxYYYYMM.Text = System.DateTime.Today.ToString("yyyy/MM");


			// ����n�J�~�ȭ���T - �u���Ωm�W
			GetLoginEmpInfo();
		}


		// �d�� ���s���B�z
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			string strSort = this.ddlOrderByFilter.SelectedItem.Value.ToString().Trim();
			string strIabSeq = this.tbxIabseq.Text.ToString();


			// ��} - ������� ia �ˮ֪�
			string strbuf = "iaFm2_chklist_ia.aspx?bkcd=" + strBkcd + "&yyyymm=" + strYYYYMM + "&sort=" + strSort + "&action=2&iabseq=" + strIabSeq;
			Response.Redirect(strbuf);
		}


		// ��� DataGrid1
		private void BindGrid1()
		{
			// �� ia ��X iabdate & iabseq, �H�@���z�����
			string TodayDate = System.DateTime.Today.ToString("yyyy/MM/dd");
			string strBkcd, strBkName, strIabDate, strIabSeq;
			strBkcd = Context.Request.QueryString["bkcd"].ToString();
			if(Context.Request.QueryString["yyyymm"].Trim() != "")
				strIabDate = Context.Request.QueryString["yyyymm"].Trim();
			else
				strIabDate = "";
			if(Context.Request.QueryString["iabseq"].Trim() != "")
				strIabSeq = Context.Request.QueryString["iabseq"].Trim();
			else
				strIabSeq = "";
			//Response.Write("strIabDate= " + strIabDate + "<br>");
			//Response.Write("strIabSeq= " + strIabSeq + "<br>");


			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "ia");
			DataView dv2 = ds2.Tables["ia"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr2 = "1=1";
			if(strIabDate != "")
				rowfilterstr2 = rowfilterstr2 + " AND ia_iabdate='" + strIabDate + "'";
			if(strIabSeq != "")
				rowfilterstr2 = rowfilterstr2 + " AND ia_iabseq='" + strIabSeq + "'";
			dv2.RowFilter = rowfilterstr2;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

			// �Y�j�M���G�� "�䤣��" ���B�z
			if (dv2.Count > 0)
			{
				// ����n�J�~�ȭ���T - �u���Ωm�W
				GetLoginEmpInfo();

				this.btnPrintList.Visible = true;
				this.btnReQuery.Visible = false;

				DataGrid1.DataSource=dv2;
				DataGrid1.DataBind();


				// �S�O��줧��X�榡�ഫ - �ܧ�ñ��������榡
				for(int i=0; i< DataGrid1.Items.Count; i++)
				{
					// �o�����O
					string invcd = DataGrid1.Items[i].Cells[8].Text.ToString().Trim();
					//Response.Write("invcd= " + invcd + "<br>");
					switch (invcd)
					{
						case "2":
							DataGrid1.Items[i].Cells[8].Text = "�G�p";
							break;
						case "3":
							DataGrid1.Items[i].Cells[8].Text = "�T�p";
							break;
						case "4":
							DataGrid1.Items[i].Cells[8].Text = "��L";
							break;
						case "9":
							DataGrid1.Items[i].Cells[8].Text = "���M��";
							DataGrid1.Items[i].Cells[8].ForeColor = Color.Red;
							break;
						default:
							DataGrid1.Items[i].Cells[8].Text = "�T�p";
							break;
					}

					// �o���ҵ|�O
					string taxtp = DataGrid1.Items[i].Cells[9].Text.ToString().Trim();
					//Response.Write("taxtp= " + taxtp + "<br>");
					switch (taxtp)
					{
						case "1":
							DataGrid1.Items[i].Cells[9].Text = "���|5%";
							break;
						case "2":
							DataGrid1.Items[i].Cells[9].Text = "�s�|";
							break;
						case "3":
							DataGrid1.Items[i].Cells[9].Text = "�K�|";
							break;
						case "9":
							DataGrid1.Items[i].Cells[9].Text = "���M��";
							DataGrid1.Items[i].Cells[9].ForeColor = Color.Red;
							break;
						default:
							DataGrid1.Items[i].Cells[9].Text = "���|5%";
							break;
					}

				}


				// ��X������T
				string strIabDate1 = strIabDate.Substring(0, 4) + "/" + strIabDate.Substring(4, 2);
				string strIabDateNew = strIabDate;
				strIabDateNew = strIabDate.Substring(0, 4) + "/" + strIabDate.Substring(4, 2);
				//string strIabEmpNo = dv2[0]["iab_createmen"].ToString().Trim();
				//string strIabEmpName = dv2[0]["srspn_cname"].ToString().Trim();
				//Response.Write("strIabDate1= " + strIabDate1 + "<br>");
				//Response.Write("strIabDateNew= " + strIabDateNew + "<br>");
				//Response.Write("strIabEmpNo= " + strIabEmpNo + "<br>");
				//Response.Write("strIabEmpName= " + strIabEmpName + "<br>");


				// ����`����
				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "book");
				DataView dv1 = ds1.Tables["book"].DefaultView;

				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
				// �] Row Filter: default �� 1=1 and ��L rowfilter ����
				string rowfilterstr1 = "1=1";
				rowfilterstr1 = rowfilterstr1 + " AND bk_bkcd='" + strBkcd + "'";
				if (dv1.Count > 0)
				{
					strBkName = dv1[0]["bk_nm"].ToString().Trim();
				}
				else
				{
					strBkName = "";
				}
				//Response.Write("strBkName= " + strBkName + "<br>");

				this.lblMessage2.Text = strIabDateNew + "�}�ߪ���Ƭ��G" + strBkName + " " + strIabDate1 + "��A�o���}�߳�帹���G" + strIabSeq + "�F�@�}�ߤF " + dv2.Count.ToString().Trim() + " �����Ӹ��";


				// �S�O��줧��X�榡�ഫ - �ܧ�ñ��������榡
			}
			else
			{
				this.lblMessage2.Text = "���|���}�ߥ���o���}�߳�!<br>�νЭ��s�j�M�I";
				this.btnReQuery.Visible = true;
				this.btnPrintList.Visible = false;
			}
		}


		// ��^���� ���s���B�z
		private void btnBack_Click(object sender, System.EventArgs e)
		{
			// ��}
			Response.Redirect("../default.aspx");
		}


		// ����n�J�~�ȭ���T - �u���Ωm�W
		private void GetLoginEmpInfo()
		{
			// ��X�n�J�̪��u��, �@���w�] �s��~�ȭ� ����
			string LoginEmpNo = "";
			string LoginEmpCName = "";
			//Response.Write("LoginEmpNo= " + User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) + "<br>");
			// �Y���n�J�̪����, �h��X�ùw�� ���ɷ~�ȭ����U�Ԧ����
			if(User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1)!=null && User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) != "")
			{
				LoginEmpNo = User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);


				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
				DataSet ds3 = new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "srspn");
				DataView dv3 = ds3.Tables["srspn"].DefaultView;

				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
				string rowfilterstr3 = "1=1";
				rowfilterstr3 = rowfilterstr3 + " AND srspn_empno='" + LoginEmpNo + "'";
				dv3.RowFilter = rowfilterstr3;

				// �ˬd�ÿ�X �̫� Row Filter �����G
				//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
				//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

				// �Y�����, �h��ܬ������; �_�h�������~�T��
				if(dv3.Count > 0)
				{
					LoginEmpCName = dv3[0]["srspn_cname"].ToString().Trim();
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
		}


		// �C�L�ˮ֪� ���s���B�z
		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			// ����n�J�~�ȭ���T - �u���Ωm�W
			//GetLoginEmpInfo();

			// ��X�e���W����, �@���z���ƪ�����
			string strBkcd = Context.Request.QueryString["bkcd"].ToString();
			string strYYYYMM = Context.Request.QueryString["yyyymm"].Trim();
			string strSortFilter = Context.Request.QueryString["sort"].Trim();
			string strIabSeq = Context.Request.QueryString["iabseq"].Trim();
			string strLEmpNo = this.tbxLoginEmpNo.Text.ToString().Trim();
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");
			//Response.Write("strSortFilter= " + strSortFilter + "<br>");
			//Response.Write("strIabSeq= " + strIabSeq + "<br>");
			//Response.Write("strLEmpNo= " + strLEmpNo + "<br>");


			// �}�Ҥp����
			string strbuf = "iaFm2_list2.aspx?bkcd=" + strBkcd + "&yyyymm=" + strYYYYMM + "&sort=" + strSortFilter + "&iabseq=" + strIabSeq + "&LEmpNo=" + strLEmpNo;
			//Response.Write(strbuf);
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}


		// ���s�d�� ���s���B�z
		private void btnReQuery_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("iaFm2_chklist_ia.aspx?bkcd=&yyyymm=&sort=&action=1&iabseq=");
		}

		// ���s�d�� ���s���B�z
		private void btnClear_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("iaFm2_chklist_ia.aspx?bkcd=&yyyymm=&sort=&action=1&iabseq=");
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
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.btnReQuery.Click += new System.EventHandler(this.btnReQuery_Click);
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
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
																																																			  new System.Data.Common.DataColumnMapping("proj_bkcd", "proj_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("proj_fgitri", "proj_fgitri"),
																																																			  new System.Data.Common.DataColumnMapping("proj_projno", "proj_projno"),
																																																			  new System.Data.Common.DataColumnMapping("proj_costctr", "proj_costctr")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2')";
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
																									  new System.Data.Common.DataTableMapping("Table", "ia", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd"),
																																																			new System.Data.Common.DataColumnMapping("ia_iano", "ia_iano"),
																																																			new System.Data.Common.DataColumnMapping("ia_mfrno", "ia_mfrno"),
																																																			new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			new System.Data.Common.DataColumnMapping("ia_rnm", "ia_rnm"),
																																																			new System.Data.Common.DataColumnMapping("ia_rjbti", "ia_rjbti"),
																																																			new System.Data.Common.DataColumnMapping("ia_rzip", "ia_rzip"),
																																																			new System.Data.Common.DataColumnMapping("ia_raddr", "ia_raddr"),
																																																			new System.Data.Common.DataColumnMapping("ia_rtel", "ia_rtel"),
																																																			new System.Data.Common.DataColumnMapping("ia_invcd", "ia_invcd"),
																																																			new System.Data.Common.DataColumnMapping("ia_taxtp", "ia_taxtp"),
																																																			new System.Data.Common.DataColumnMapping("iad_iaditem", "iad_iaditem"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk1", "iad_fk1"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk2", "iad_fk2"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk3", "iad_fk3"),
																																																			new System.Data.Common.DataColumnMapping("iad_fk4", "iad_fk4"),
																																																			new System.Data.Common.DataColumnMapping("iad_desc", "iad_desc"),
																																																			new System.Data.Common.DataColumnMapping("iad_projno", "iad_projno"),
																																																			new System.Data.Common.DataColumnMapping("iad_costctr", "iad_costctr"),
																																																			new System.Data.Common.DataColumnMapping("iad_qty", "iad_qty"),
																																																			new System.Data.Common.DataColumnMapping("iad_amt", "iad_amt"),
																																																			new System.Data.Common.DataColumnMapping("ia_contno", "ia_contno"),
																																																			new System.Data.Common.DataColumnMapping("ia_iabdate", "ia_iabdate"),
																																																			new System.Data.Common.DataColumnMapping("ia_iabseq", "ia_iabseq"),
																																																			new System.Data.Common.DataColumnMapping("iad_iano", "iad_iano"),
																																																			new System.Data.Common.DataColumnMapping("iad_syscd", "iad_syscd")})});
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.ia.ia_syscd, dbo.ia.ia_iano, RTRIM(dbo.ia.ia_mfrno) AS ia_mfrno, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, RTRIM(dbo.ia.ia_rnm) AS ia_rnm, RTRIM(dbo.ia.ia_rjbti) AS ia_rjbti, RTRIM(dbo.ia.ia_rzip) AS ia_rzip, RTRIM(dbo.ia.ia_raddr) AS ia_raddr, RTRIM(dbo.ia.ia_rtel) AS ia_rtel, dbo.ia.ia_invcd, dbo.ia.ia_taxtp, dbo.iad.iad_iaditem, RTRIM(dbo.iad.iad_fk1) AS iad_fk1, RTRIM(dbo.iad.iad_fk2) AS iad_fk2, RTRIM(dbo.iad.iad_fk3) AS iad_fk3, RTRIM(dbo.iad.iad_fk4) AS iad_fk4, RTRIM(dbo.iad.iad_desc) AS iad_desc, dbo.iad.iad_projno, dbo.iad.iad_costctr, dbo.iad.iad_qty, dbo.iad.iad_amt, RTRIM(dbo.ia.ia_contno) AS ia_contno, dbo.ia.ia_iabdate, dbo.ia.ia_iabseq, dbo.iad.iad_iano, dbo.iad.iad_syscd FROM dbo.ia INNER JOIN dbo.iad ON dbo.ia.ia_syscd = dbo.iad.iad_syscd AND dbo.ia.ia_iano = dbo.iad.iad_iano INNER JOIN dbo.iab ON dbo.ia.ia_syscd = dbo.iab.iab_syscd COLLATE Chinese_Taiwan_Stroke_CI_AS AND dbo.ia.ia_iabdate = dbo.iab.iab_iabdate AND dbo.ia.ia_iabseq = dbo.iab.iab_iabseq INNER JOIN dbo.mfr ON dbo.ia.ia_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.c2_cont ON dbo.ia.ia_contno = dbo.c2_cont.cont_syscd + dbo.c2_cont.cont_contno WHERE (dbo.c2_cont.cont_fgpayonce = '0') AND (dbo.c2_cont.cont_fgclosed = '0') AND (dbo.ia.ia_syscd = 'C2') AND (dbo.ia.ia_status = ' ') ORDER BY dbo.ia.ia_iano, dbo.iad.iad_fk1, dbo.iad.iad_fk2, dbo.iad.iad_fk3, dbo.iad.iad_fk4";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("srspn_id", "srspn_id"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_orgcd", "srspn_orgcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_deptcd", "srspn_deptcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_date", "srspn_date"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno")})});
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = "SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel" +
				", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srsp" +
				"n_empno FROM dbo.srspn WHERE (srspn_atype <> \'a\') AND (srspn_atype <> \'d\')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
