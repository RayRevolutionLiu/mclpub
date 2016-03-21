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
	/// Summary description for lostbk_list.
	/// </summary>
	public class lostbk_list : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblfgSent;
		protected System.Web.UI.WebControls.DropDownList ddlfgSent;
		protected System.Web.UI.WebControls.TextBox tbxLostDate1;
		protected System.Web.UI.WebControls.TextBox tbxLostDate2;
		protected System.Web.UI.WebControls.TextBox tbxContSignDate1;
		protected System.Web.UI.WebControls.TextBox tbxContSignDate2;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpNo;
		protected System.Web.UI.WebControls.TextBox tbxLoginEmpCName;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.LinkButton lnbClearAll;
		protected System.Web.UI.WebControls.CheckBox cbx0;
		protected System.Web.UI.WebControls.Label lblLostDate;
		protected System.Web.UI.WebControls.Label lblContSignDate;
		protected System.Web.UI.WebControls.CheckBox cbx2;
		protected System.Web.UI.WebControls.CheckBox cbx3;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.Label lblBkcd;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.Literal Literal1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if(!Page.IsPostBack)
			{
				Response.Expires = 0;

				// ���w�]��
				InitialData();
			}
		}


		// ���w�]��
		private void InitialData()
		{
			this.ddlfgSent.SelectedIndex = 0;
			this.ddlBookCode.SelectedIndex = 0;
			this.tbxLostDate1.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
			this.tbxLostDate2.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
			this.tbxContSignDate1.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
			this.tbxContSignDate2.Text = System.DateTime.Today.ToString("yyyy/MM/dd");


			// ��ܤU�Ԧ���� ���y���O�� DB ��
			// ���� nostr, �а� sqlDataAdapter3.Select statement;
			// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "book");
			DataView dv1=ds1.Tables["book"].DefaultView;
			ddlBookCode.DataSource=dv1;
			ddlBookCode.DataTextField="bk_nm";
			//ddlBookCode.DataValueField="nostr";
			// ���@�e��: ddl�ȥ� nostr �אּ bk_bkcd, �~��Ϥ���� ���y���O, �_�h�� option �Ȭ� nostr, �ӫD bk_bkcd
			ddlBookCode.DataValueField="bk_bkcd";
			ddlBookCode.DataBind();


			// ����n�J�~�ȭ���T - �u���Ωm�W
			GetLoginEmpInfo();

			this.btnPrintList.Visible = false;
			this.lblMessage.Text = "";
			this.Literal1.Text = "";
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
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "srspn");
				DataView dv2 = ds2.Tables["srspn"].DefaultView;

				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
				string rowfilterstr2 = "1=1";
				rowfilterstr2 = rowfilterstr2 + " AND srspn_empno='" + LoginEmpNo + "'";
				dv2.RowFilter = rowfilterstr2;

				// �ˬd�ÿ�X �̫� Row Filter �����G
				//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
				//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

				// �Y�����, �h��ܬ������; �_�h�������~�T��
				if(dv2.Count > 0)
				{
					LoginEmpCName = dv2[0]["srspn_cname"].ToString().Trim();
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


		// �d�� ���s���B�z
		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			this.Literal1.Text = "";

			BindGrid1();
		}


		// ��� DataGrid1
		private void BindGrid1()
		{
			// ��X�e���W����
			string strfgSent = this.ddlfgSent.SelectedItem.Value.ToString().Trim();
			string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
			string strLostSDate = this.tbxLostDate1.Text.ToString().Trim();
			strLostSDate = strLostSDate.Substring(0, 4) + strLostSDate.Substring(5, 2) + strLostSDate.Substring(8, 2);
			string strLostEDate = this.tbxLostDate2.Text.ToString().Trim();
			strLostEDate = strLostEDate.Substring(0, 4) + strLostEDate.Substring(5, 2) + strLostEDate.Substring(8, 2);
			string strContSDate = this.tbxContSignDate1.Text.ToString().Trim();
			strContSDate = strContSDate.Substring(0, 4) + strContSDate.Substring(5, 2) + strContSDate.Substring(8, 2);
			string strContEDate = this.tbxContSignDate2.Text.ToString().Trim();
			strContEDate = strContEDate.Substring(0, 4) + strContEDate.Substring(5, 2) + strContEDate.Substring(8, 2);
			//Response.Write("strfgSent= " + strfgSent + "<br>");
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strLostSDate= " + strLostSDate + "<br>");
			//Response.Write("strLostEDate= " + strLostEDate + "<br>");
			//Response.Write("strContSDate= " + strContSDate + "<br>");
			//Response.Write("strContEDate= " + strContEDate + "<br>");


			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c2_lost");
			DataView dv3 = ds3.Tables["c2_lost"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr3 = "1=1";

			// �H�Ѫ��p
			if(this.cbx0.Checked)
			{
				if(strfgSent == "All")
				{
					rowfilterstr3 = rowfilterstr3;
				}
				else
				{
					rowfilterstr3 = rowfilterstr3 + " AND lst_fgsent='" + strfgSent + "'";
					if(strfgSent == "C")
					{
						this.cbx2.Checked = true;
						// �ʮѤ���϶�
						if(this.cbx2.Checked)
						{
							rowfilterstr3 = rowfilterstr3 + " AND lst_date >= '" + strLostSDate + "'";
							rowfilterstr3 = rowfilterstr3 + " AND lst_date <= '" + strLostEDate + "'";
						}
					}
				}
			}

			// ���y���O
			if(this.cbx1.Checked)
			{
				rowfilterstr3 = rowfilterstr3 + " AND cont_bkcd = '" + strBkcd + "'";
			}

			// �ʮѤ���϶�
			if(this.cbx2.Checked)
			{
				rowfilterstr3 = rowfilterstr3 + " AND lst_date >= '" + strLostSDate + "'";
				rowfilterstr3 = rowfilterstr3 + " AND lst_date <= '" + strLostEDate + "'";
			}

			// �X��ñ������϶�
			if(this.cbx3.Checked)
			{
				rowfilterstr3 = rowfilterstr3 + " AND cont_signdate >= '" + strContSDate + "'";
				rowfilterstr3 = rowfilterstr3 + " AND cont_signdate <= '" + strContEDate + "'";
			}

			//�p�G�OD�ŷ~�ȤH���A�u��ݨ�ۤv���Ȥ���
			if(Session["atype"].ToString().Equals("D"))
				rowfilterstr3=rowfilterstr3+" and cont_empno = '" + Session["empid"] + "'";

			dv3.RowFilter = rowfilterstr3;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");


			// �Y�j�M���G�� "���" ���B�z
			if (dv3.Count > 0)
			{
				this.btnPrintList.Visible = true;

				this.lblMessage.Text = "�@��� " + dv3.Count + "���ʮѸ��!";
			}
			else
			{
				this.lblMessage.Text = "�䤣��ŦX���󪺸��, �z�i�H ���]����!";
			}
		}


		// �Y�U�Ԧ���� �H�Ѫ��p ���ܪ��B�z
		private void ddlfgSent_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Literal1.Text = "";

			// �Y�� "�w�H�X", ��ܩҦ��j�M�ﶵ
			if(this.ddlfgSent.SelectedItem.Value == "C")
			{
				cbx1.Enabled = true;
				tbxLostDate1.Enabled = true;
				tbxLostDate2.Enabled = true;
			}
				// �_�h, �u��� �X��ñ������϶� �ﶵ
			else
			{
				cbx1.Checked = false;
				cbx1.Enabled = false;
				tbxLostDate1.Enabled = false;
				tbxLostDate2.Enabled = false;
			}
		}


		// ���U �C�L���� ���B�z
		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			// ��X�z�����
			string strfgSent = this.ddlfgSent.SelectedItem.Value.ToString().Trim();
			string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
			string strLostSDate = this.tbxLostDate1.Text.ToString().Trim();
			string strLostEDate = this.tbxLostDate2.Text.ToString().Trim();
			string strContSDate = this.tbxContSignDate1.Text.ToString().Trim();
			string strContEDate = this.tbxContSignDate2.Text.ToString().Trim();
			string strLoginEmpNo = this.tbxLoginEmpNo.Text.ToString().Trim();
			//Response.Write("strfgSent= " + strfgSent + "<br>");
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strLostSDate= " + strLostSDate + "<br>");
			//Response.Write("strLostEDate= " + strLostEDate + "<br>");
			//Response.Write("strContSDate= " + strContSDate + "<br>");
			//Response.Write("strContEDate= " + strContEDate + "<br>");
			//Response.Write("strLoginEmpNo= " + strLoginEmpNo + "<br>");


			// ��}�B�z
			string	strbuf = "lostbk_list2.aspx?";

			// �H�Ѫ��p
			if(cbx0.Checked)
				strbuf += "&status=" + strfgSent;
			else
				strbuf += "&status=";

			// ���y���O
			if(cbx1.Checked)
				strbuf += "&bkcd=" + strBkcd;
			else
				strbuf += "&bkcd=";

			// �ʮѤ���϶�
			if(cbx2.Checked)
				strbuf += "&lostdate=" + strLostSDate + "~" + strLostEDate;
			else
				strbuf += "&lostdate=";

			// �X��ñ������϶�
			if(cbx3.Checked)
				strbuf += "&signdate=" + strContSDate + "~" + strContEDate;
			else
				strbuf += "&signdate=";

			// �n�J�~�ȭ��u��
			strbuf += "&LEmpNo=" + strLoginEmpNo;
			this.Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}


		// �M�����d ���s���B�z
		private void lnbClearAll_Click(object sender, System.EventArgs e)
		{
			//this.btnPrintList.Visible = false;
			//InitialData();
			Response.Redirect("lostbk_list.aspx");
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
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (dbo.proj.proj_fgitri = ' ')";
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
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel" +
				", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srsp" +
				"n_empno FROM dbo.srspn";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lost", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("lst_contno", "lst_contno"),
																																																				 new System.Data.Common.DataColumnMapping("lst_sdate", "lst_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("lst_edate", "lst_edate"),
																																																				 new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																				 new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				 new System.Data.Common.DataColumnMapping("lst_date", "lst_date"),
																																																				 new System.Data.Common.DataColumnMapping("lst_cont", "lst_cont"),
																																																				 new System.Data.Common.DataColumnMapping("lst_rea", "lst_rea"),
																																																				 new System.Data.Common.DataColumnMapping("lst_fgsent", "lst_fgsent"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("or_jbti", "or_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("lst_oritem", "lst_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("lst_seq", "lst_seq"),
																																																				 new System.Data.Common.DataColumnMapping("lst_syscd", "lst_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																				 new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd")})});
			this.ddlfgSent.SelectedIndexChanged += new System.EventHandler(this.ddlfgSent_SelectedIndexChanged);
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.lnbClearAll.Click += new System.EventHandler(this.lnbClearAll_Click);
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = @"SELECT dbo.c2_cont.cont_empno,dbo.c2_lost.lst_contno, dbo.c2_lost.lst_sdate, dbo.c2_lost.lst_edate, dbo.c2_or.or_nm, RTRIM(dbo.c2_or.or_zip) AS or_zip, dbo.c2_or.or_addr, dbo.c2_lost.lst_date, dbo.c2_lost.lst_cont, dbo.c2_lost.lst_rea, dbo.c2_lost.lst_fgsent, dbo.c2_cont.cont_signdate, dbo.c2_or.or_jbti, dbo.c2_or.or_inm, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd, dbo.c2_lost.lst_oritem, dbo.c2_lost.lst_seq, dbo.c2_lost.lst_syscd, dbo.c2_or.or_contno, dbo.c2_or.or_oritem, dbo.c2_or.or_syscd, dbo.c2_cont.cont_bkcd FROM dbo.c2_lost INNER JOIN dbo.c2_or ON dbo.c2_lost.lst_syscd = dbo.c2_or.or_syscd AND dbo.c2_lost.lst_contno = dbo.c2_or.or_contno AND dbo.c2_lost.lst_oritem = dbo.c2_or.or_oritem INNER JOIN dbo.c2_cont ON dbo.c2_or.or_syscd = dbo.c2_cont.cont_syscd AND dbo.c2_or.or_contno = dbo.c2_cont.cont_contno";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
