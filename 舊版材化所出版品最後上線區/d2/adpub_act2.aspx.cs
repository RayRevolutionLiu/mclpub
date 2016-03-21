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
using System.Data.SqlClient;
// WebApplication Virables - Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adpub_act2.
	/// </summary>
	public class adpub_act2 : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblSearchKeyword;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidData_special;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidData;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.Label lblTotalCounts;
		protected System.Web.UI.HtmlControls.HtmlInputHidden tbxStartPageNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.Label lblClrPgsGroupCount;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.Label lblDBMessage;

		public adpub_act2()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if (!Page.IsPostBack)
			{
				Response.Expires = 0;

				// Ū���@�목�����_�l���X (�ھګ��w�����y���O)
				GetStartPageNo();

				// ���w�]��
				InitialMyData();


				//Load Data From DB, �ন xml ���A, �A��J document.form1.hidData.Value
				LoadDataFromDB_special();
				LoadDataFromDB();
			}

		}


		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		// Ū���@�목�����_�l���X (�ھګ��w�����y���O)
		private void GetStartPageNo()
		{
			// ��X ���y�N�X
			string strBkcd = Context.Request.QueryString["bkcd"].ToString();

			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds3 = new DataSet();
			// �� sqlDataAdapter1 �L�o���� - ���w Parameters
			this.sqlDataAdapter3.Fill(ds3, "c2_pgno");
			DataView dv3 = ds3.Tables["c2_pgno"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr3 = "1=1";
			rowfilterstr3 = rowfilterstr3 + " AND pg_bkcd='" + strBkcd+ "'";
			dv3.RowFilter = rowfilterstr3;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

			// �Y�j�M���G�� "���" ���B�z
			string strStartPgNo = "0";
			if (dv3.Count > 0)
			{
				strStartPgNo = dv3[0]["pg_startpgno"].ToString();
			}
			//Response.Write("strStartPgNo= " + strStartPgNo + "<br>");
			this.tbxStartPageNo.Value = strStartPgNo;
		}


		// ���w�]��
		private void InitialMyData()
		{
			// ��X�����ܼ� bkcd & yyyymm, �N���ন��r��ܤ�
			string Reqbkcd = Context.Request.QueryString["bkcd"].ToString();
			string Reqyyyymm = Context.Request.QueryString["yyyymm"].Trim();
			//Response.Write("Reqbkcd= " + Reqbkcd + "<br>");
			//Response.Write("Reqyyyymm= " + Reqyyyymm + "<br>");

			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "book");
			DataView dv = ds.Tables["book"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			dv.RowFilter = "1=1";
			if(Reqbkcd != "")
				dv.RowFilter = "bk_bkcd=" + Reqbkcd ;
			else
				dv.RowFilter = dv.RowFilter;

			//���b�B�z: �Y BookName �L��Ʈ�, �h�����~�T��
			string BookName = "";
			if(dv.Count > 0)
				BookName = dv[0]["bk_nm"].ToString();
			else
				BookName = BookName;
			//Response.Write("BookName= " + BookName + "<br>");
			this.lblSearchKeyword.Text = BookName;

			// �ˬd�����ܼ� �Z�n�~�� �O�_����J
			if(Reqyyyymm != "")
			{
				if(Reqyyyymm.Length==6)
					Reqyyyymm = Reqyyyymm.Substring(0, 4) + " / " + Reqyyyymm.Substring(4, 2);
				else
					Reqyyyymm = Reqyyyymm;
				this.lblSearchKeyword.Text = lblSearchKeyword.Text + " & �Z�n�~�� " + Reqyyyymm;
				//Response.Write("�L�Z�n�~����<br>");
			}
			else
			{
				this.lblSearchKeyword.Text = lblSearchKeyword.Text;
				//Response.Write("�Z�n�~�� " + Reqyyyymm + "<br>");
			}


			// ��X�`����
			// �ˬd�����ܼ� �Z�n�~�� �O�_����J
			if(Reqbkcd != "" && Reqyyyymm != "")
			{
				Reqyyyymm = Context.Request.QueryString["yyyymm"].Trim();

				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "c2_pub");
				DataView dv2 = ds2.Tables["c2_pub"].DefaultView;

				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
				string rowfilterstr2 = "1=1";
				rowfilterstr2 = rowfilterstr2 + " AND pub_bkcd='" + Reqbkcd + "'";
				rowfilterstr2 = rowfilterstr2 + " AND pub_yyyymm='" + Reqyyyymm + "'";
				dv2.RowFilter = rowfilterstr2;

				// �ˬd�ÿ�X �̫� Row Filter �����G
				//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
				//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

				if(dv2.Count > 0)
				{
					//Response.Write("Total: " + dv2.Count.ToString() + "<br>");
					this.lblTotalCounts.Text = "(  �`���ơG" + dv2.Count.ToString() + "���F";
					this.lblTotalCounts.Text = this.lblTotalCounts.Text + "�s�i��m/�g�T �p�p�G";

					// ��X �s�i��m+�s�i�g�T ���p�p
					// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
					this.sqlDataAdapter4.SelectCommand.Parameters["@bkcd"].Value = Reqbkcd;
					this.sqlDataAdapter4.SelectCommand.Parameters["@yyyymm"].Value = Reqyyyymm;
					DataSet ds4 = new DataSet();
					this.sqlDataAdapter4.Fill(ds4, "c2_pub");
					DataView dv4 = ds4.Tables["c2_pub"].DefaultView;

					// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
					string rowfilterstr4 = "1=1";
					//rowfilterstr4 = rowfilterstr4 + " AND pub_bkcd='" + Reqbkcd + "'";
					//rowfilterstr4 = rowfilterstr4 + " AND pub_yyyymm='" + Reqyyyymm + "'";
					dv4.RowFilter = rowfilterstr4;

					// �ˬd�ÿ�X �̫� Row Filter �����G
					//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
					//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

					if(dv4.Count > 0)
					{
						//this.lblClrPgsGroupCount.Text = "" + ")";
						this.lblClrPgsGroupCount.Text = "";

						string ClrName = "", PgsName = "";
						int ClrPgsCountNo = 0;
						for(int i=0; i<dv4.Count; i++)
						{
							// ��X�C�@�����
							ClrName = dv4[i]["clr_nm"].ToString().Trim();
							PgsName = dv4[i]["pgs_nm"].ToString().Trim();
							ClrPgsCountNo = Convert.ToInt32(dv4[i]["CountNo"].ToString().Trim());
							this.lblClrPgsGroupCount.Text = this.lblClrPgsGroupCount.Text + ClrName + PgsName + ":" + ClrPgsCountNo + "��&nbsp;&nbsp;";
							}
					}
					else
					{
						this.lblClrPgsGroupCount.Text = "<font color='Gray'>�L���</font>)";
					}
					this.lblClrPgsGroupCount.Text = this.lblClrPgsGroupCount.Text + ")";
				}
			}
		}


		// Load from DB : �S���������
		private void LoadDataFromDB_special()
		{
			// ��X�����ܼ� bkcd & yyyymm
			string Reqbkcd = Context.Request.QueryString["bkcd"].ToString();
			string Reqyyyymm = Context.Request.QueryString["yyyymm"].Trim();

			// ��X��Ʈw�������, �õ����O�W, �H�ন xml ���A
			// ��: RTRIM() �O Transact-SQL �̪� function, �N�r��k�誺�ťեh��; ���Z�n���X����� RTRIM() �_�h Order by �|�����~
			// ��: �]�����b��Ʈw�����s�b, �G�H SELECT 0 AS ���� �ӥN�� (��������l�ȳ]�� 0)
			//string strDSN = "Server=isccom2;User ID=webuser;Password=db600;Database=mrlpub;";
			string strDSN = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			string strSelectCommand = "SELECT c2_pub.pub_pgno AS ����, RTRIM(c2_pub.pub_contno) AS �X���ѽs��, RTRIM(c2_pub.pub_pubseq) AS �����Ǹ�, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_yyyymm) AS �Z�n�~��, c2_pub.pub_pgno AS �Z�n���X, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_clrcd) AS �s�i��m�N�X, RTRIM(c2_pub.pub_pgscd) AS �s�i�����N�X, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_ltpcd) AS �s�i�g�T�N�X, RTRIM(c2_pub.pub_fgfixpg) AS �T�w�������O, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_fggot) AS ��Z���O, RTRIM(c2_pub.pub_modempno) AS �����~�ȭ��u��, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_remark) AS �Ƶ�, RTRIM(c2_pub.pub_origbkcd) AS �½Z���y�N�X, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_origjno) AS �½Z���O, RTRIM(c2_pub.pub_origjbkno) AS �½Z���X, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_chgbkcd) AS ��Z���y�N�X, RTRIM(c2_pub.pub_chgjno) ";
			strSelectCommand = strSelectCommand + " AS ��Z���O, RTRIM(c2_pub.pub_chgjbkno) AS ��Z���X, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_fgrechg) AS ��Z���X�����O, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_njtpcd) AS �s�Z�s�k�N�X, ";
			strSelectCommand = strSelectCommand + " RTRIM(mfr.mfr_inm) AS ���q�W��, 8 AS ����2, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_bkcd) AS ���y���O�N�X, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_clr.clr_nm) AS �s�i��m, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_ltp.ltp_nm) AS �s�i����, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pgsize.pgs_nm) AS �s�i�g�T, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_njtp.njtp_nm) AS �s�Z�s�k, ";
			strSelectCommand = strSelectCommand + " RTRIM(book.bk_nm) AS �½Z���y�W��, ";
			strSelectCommand = strSelectCommand + " RTRIM(srspn.srspn_cname) AS �����~�ȭ��m�W, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_drafttp) AS �Z�����O�N�X, ";
			strSelectCommand = strSelectCommand + " c2_lprior.lp_priorseq AS �s�i�u������, c2_lprior.lp_bkcd AS �s�i�u�����Ǯ��y���O�N�X";
			strSelectCommand = strSelectCommand + " FROM c2_pub ";
			strSelectCommand = strSelectCommand + " INNER JOIN ";
			strSelectCommand = strSelectCommand + " c2_cont ON c2_pub.pub_contno = c2_cont.cont_contno AND ";
			strSelectCommand = strSelectCommand + " c2_pub.pub_syscd = c2_cont.cont_syscd INNER JOIN ";
			strSelectCommand = strSelectCommand + " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN ";
			strSelectCommand = strSelectCommand + " c2_lprior ON c2_pub.pub_ltpcd = c2_lprior.lp_ltpcd AND ";
			strSelectCommand = strSelectCommand + " c2_pub.pub_clrcd = c2_lprior.lp_clrcd AND ";
			strSelectCommand = strSelectCommand + " c2_pub.pub_pgscd = c2_lprior.lp_pgscd AND ";
			strSelectCommand = strSelectCommand + " c2_pub.pub_bkcd = c2_lprior.lp_bkcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " c2_pgsize ON c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " c2_ltp ON c2_pub.pub_ltpcd = c2_ltp.ltp_ltpcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " c2_njtp ON c2_pub.pub_njtpcd = c2_njtp.njtp_njtpcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " book ON c2_pub.pub_origbkcd = book.bk_bkcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " srspn ON c2_cont.cont_empno = srspn.srspn_empno ";
			strSelectCommand = strSelectCommand + " WHERE (c2_pub.pub_bkcd =" + Reqbkcd + ") AND (c2_pub.pub_yyyymm =" + Reqyyyymm + ") ";
			strSelectCommand = strSelectCommand + " AND (c2_pub.pub_ltpcd <> '50') ";
			strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgclosed = '0') ";
			strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgcancel = '0') ";
			strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgtemp = '0') ";
			strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgpubed = '1') ";
			strSelectCommand = strSelectCommand + " ORDER BY �s�i�u������, �Z�n���X ";
			//Response.Write("strSelectCommand= " + strSelectCommand + "<br>");

			SqlDataAdapter da = new SqlDataAdapter(strSelectCommand, strDSN);
			DataSet ds = new DataSet("root");
			da.Fill(ds, "item");
			DataView dv = ds.Tables[0].DefaultView;

			// ��X�`����
			int TotalCount = dv.Count;
			//Response.Write(" TotalCount = " + TotalCount + "<BR>");

			if(TotalCount>0)
			{
				// ��X�s�i�����N�X, �H��X������, ���ƭ����ɤ~����
				// ����X�U�檺 �s�i�����N�X
				for(int i=0; i<TotalCount; i++)
				{
					// �� for loop �O�N dv[i][j] �Ȭ��Ū�, �j����J�@�ӪťղŸ�
					//��ܥX�Ҧ��� dv[i][j] �̪����, �å� \ �Ÿ��j�}�ϧO
					// j=1; j<30 : 1~30 �O�ھ� item �@�� 29 �ӦӨ�
					for (int j=1;j<30;j++)
					{
						//Response.Write(j + ":" + dv[i][j] + "\\ \n");
						if(dv[i][j].ToString().Trim() == "" || dv[i][j].ToString().Trim() == null)
							dv[i][j] = " ";
					}


					// ��: ��Z���O �Y�אּ ��Z���O, �h�|�� Error: "�b���������󪺰������B��� null �ȡC"
					// �̤��P�� �Z�����O, ��e���W�����(�M��)����������ƭ�
					string drafttp = dv[i]["�Z�����O�N�X"].ToString();
					// �Y�Z�����O�� �½Z, �h�M�� ��Z�ηs�Z�����
					if(drafttp=="1")
					{
						dv[i]["��Z���O"] = " ";
						dv[i]["��Z���X"] = " ";
						dv[i]["��Z���X�����O"] = " ";
						dv[i]["�s�Z�s�k�N�X"] = " ";
					}
						// �Y�Z�����O�� �s�Z, �h�M�� �½Z�Χ�Z�����
					else if(drafttp=="2")
					{
						dv[i]["�½Z���O"] = " ";
						dv[i]["�½Z���X"] = " ";
						dv[i]["��Z���O"] = " ";
						dv[i]["��Z���X"] = " ";
						dv[i]["��Z���X�����O"] = " ";
					}
						// �Y�Z�����O�� ��Z, �h�M�� �½Z�ηs�Z�����
					else if(drafttp=="3")
					{
						dv[i]["�½Z���O"] = " ";
						dv[i]["�½Z���X"] = " ";
						dv[i]["�s�Z�s�k�N�X"] = " ";
					}


					// �P�O �s�i�����N�X �� ����(01) �� �b��(02), �èϪ�������ƻP���P�B, �A��X�T���ܪ�����
					// �p�� doReOrder() �~�i��X���T����
					string pgscd = dv[i]["�s�i�����N�X"].ToString();

					// �P�O �s�i�g�T �� 01(�u�����x) �� 02(�q�����x), �ÿ�X�T��
					if(pgscd == "01")
					{
						//Response.Write(" ������ = 8<BR>");
						// �`�N�u��N�ȦA��J dv[i]["����2"] ��, �]�뤣�i(�줣��) <Input id=pagelayout2> ��
						dv[i]["����2"] = 8;
						//pagelayout2.Value = 8;
					}
					else if (pgscd == "02")
					{
						//Response.Write(" ������ = 4<BR>");
						// �`�N�u��N�ȦA��J dv[i]["����2"] ��, �]�뤣�i(�줣��) <Input id=pagelayout2> ��
						dv[i]["����2"] = 4;
						//pagelayout2.Value = 4;
					}

					//					// �Y�s�i�g�T�� '�b��' ��, ��X���P�C��ѿ���
					//					// �]�ȶ�J xml ��, �G�C�⤴�L�k�� table ����ܤ��P�C��
					//					string pgsnm = dv[i]["�s�i�g�T"].ToString();
					//					if(pgsnm == "����")
					//					{
					//						pgsnm = pgsnm;
					//					}
					//					else if(pgsnm == "�b��")
					//					{
					//						pgsnm = "<font color='Red'>" + pgsnm + "</font>";
					//					}
					//					//Response.Write("pgsnm= " + pgsnm + "<br>");


					// �P�O �T�w�������O �� 0(�_) �� 1(�O), �ÿ�X�T��
					string fgFixPage = dv[i]["�T�w�������O"].ToString();
					if(fgFixPage == "0")
					{
						dv[i]["�T�w�������O"] = "�_";
					}
					else
					{
						dv[i]["�T�w�������O"] = "�O";
					}


					// �P�O ��Z���O �� 0(�_) �� 1(�O), �ÿ�X�T��
					string fgGot = dv[i]["��Z���O"].ToString();
					if(fgGot == "0")
					{
						dv[i]["��Z���O"] = "�_";
					}
					else
					{
						dv[i]["��Z���O"] = "�O";
					}

					// �½Z���y�W�٤w��� bk_nm; �Y�½Z���y�W�٨ϥ� bk_nm, ��Z���y�W�� ���i�P�ɤS�ϥ� bk_nm, ������ʧP�O
					// �P�O ��Z���y�N�X �� 01(�u�����x) �� 02(�q�����x), �ÿ�X�T��
					string chgbkcd = dv[i]["��Z���y�N�X"].ToString();
					if(chgbkcd == "01")
					{
						dv[i]["��Z���y�N�X"] = "�u�����x";
					}
					else if(chgbkcd == "02")
					{
						dv[i]["��Z���y�N�X"] = "�q�����x";
					}

				}
			}
				// �Y��Ʈw�̵L���, ��ܨ�T��
			else
			{
				this.lblDBMessage.Text = "�ثe��Ʈw���L���!";
			}


			// �ন xml ���A, ��J document.form1.hidData.Value
			//Response.Write("ds= " + ds.GetXml() + "<br>");
			hidData_special.Value = ds.GetXml();
			//Response.Write("hidData_special.Value= " + hidData_special.Value + "<br>");
		}


		// Load from DB : �@�목�������
		private void LoadDataFromDB()
		{
			// ��X�����ܼ� bkcd & yyyymm
			string Reqbkcd = Context.Request.QueryString["bkcd"].ToString();
			string Reqyyyymm = Context.Request.QueryString["yyyymm"].Trim();

			// ��X��Ʈw�������, �õ����O�W, �H�ন xml ���A
			// ��: RTRIM() �O Transact-SQL �̪� function, �N�r��k�誺�ťեh��; ���Z�n���X����� RTRIM() �_�h Order by �|�����~
			// ��: �]�����b��Ʈw�����s�b, �G�H SELECT 0 AS ���� �ӥN�� (��������l�ȳ]�� 0)
			//string strDSN = "Server=isccom2;User ID=webuser;Password=db600;Database=mrlpub;";
			string strDSN = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
			string strSelectCommand = "SELECT 0 AS ����, RTRIM(c2_pub.pub_contno) AS �X���ѽs��, RTRIM(c2_pub.pub_pubseq) AS �����Ǹ�, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_yyyymm) AS �Z�n�~��, c2_pub.pub_pgno AS �Z�n���X, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_clrcd) AS �s�i��m�N�X, RTRIM(c2_pub.pub_pgscd) AS �s�i�����N�X, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_ltpcd) AS �s�i�g�T�N�X, RTRIM(c2_pub.pub_fgfixpg) AS �T�w�������O, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_fggot) AS ��Z���O, RTRIM(c2_pub.pub_modempno) AS �����~�ȭ��u��, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_remark) AS �Ƶ�, RTRIM(c2_pub.pub_origbkcd) AS �½Z���y�N�X, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_origjno) AS �½Z���O, RTRIM(c2_pub.pub_origjbkno) AS �½Z���X, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_chgbkcd) AS ��Z���y�N�X, RTRIM(c2_pub.pub_chgjno) ";
			strSelectCommand = strSelectCommand + " AS ��Z���O, RTRIM(c2_pub.pub_chgjbkno) AS ��Z���X, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_fgrechg) AS ��Z���X�����O, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_njtpcd) AS �s�Z�s�k�N�X, ";
			strSelectCommand = strSelectCommand + " RTRIM(mfr.mfr_inm) AS ���q�W��, 8 AS ����2, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_bkcd) AS ���y���O�N�X, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_clr.clr_nm) AS �s�i��m, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_ltp.ltp_nm) AS �s�i����, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pgsize.pgs_nm) AS �s�i�g�T, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_njtp.njtp_nm) AS �s�Z�s�k, ";
			strSelectCommand = strSelectCommand + " RTRIM(book.bk_nm) AS �½Z���y�W��, ";
			strSelectCommand = strSelectCommand + " RTRIM(srspn.srspn_cname) AS �����~�ȭ��m�W, ";
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_drafttp) AS �Z�����O�N�X, ";
			strSelectCommand = strSelectCommand + " c2_lprior.lp_priorseq AS �s�i�u������, c2_lprior.lp_bkcd AS �s�i�u�����Ǯ��y���O�N�X";
			strSelectCommand = strSelectCommand + " FROM c2_pub ";
			strSelectCommand = strSelectCommand + " INNER JOIN ";
			strSelectCommand = strSelectCommand + " c2_cont ON c2_pub.pub_contno = c2_cont.cont_contno AND ";
			strSelectCommand = strSelectCommand + " c2_pub.pub_syscd = c2_cont.cont_syscd INNER JOIN ";
			strSelectCommand = strSelectCommand + " mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN ";
			strSelectCommand = strSelectCommand + " c2_lprior ON c2_pub.pub_ltpcd = c2_lprior.lp_ltpcd AND ";
			strSelectCommand = strSelectCommand + " c2_pub.pub_clrcd = c2_lprior.lp_clrcd AND ";
			strSelectCommand = strSelectCommand + " c2_pub.pub_pgscd = c2_lprior.lp_pgscd AND ";
			strSelectCommand = strSelectCommand + " c2_pub.pub_bkcd = c2_lprior.lp_bkcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " c2_pgsize ON c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " c2_ltp ON c2_pub.pub_ltpcd = c2_ltp.ltp_ltpcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " c2_njtp ON c2_pub.pub_njtpcd = c2_njtp.njtp_njtpcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " book ON c2_pub.pub_origbkcd = book.bk_bkcd LEFT OUTER JOIN ";
			strSelectCommand = strSelectCommand + " srspn ON c2_cont.cont_empno = srspn.srspn_empno ";
			strSelectCommand = strSelectCommand + " WHERE (c2_pub.pub_bkcd =" + Reqbkcd + ") AND (c2_pub.pub_yyyymm =" + Reqyyyymm + ") ";
			strSelectCommand = strSelectCommand + " AND (c2_pub.pub_ltpcd = '50') ";
			strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgclosed = '0') ";
			strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgcancel = '0') ";
			strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgtemp = '0') ";
			strSelectCommand = strSelectCommand + " AND (c2_cont.cont_fgpubed = '1') ";
			strSelectCommand = strSelectCommand + " ORDER BY �s�i�u������, �Z�n���X, �X���ѽs��, �����Ǹ� ";
			//Response.Write("strSelectCommand= " + strSelectCommand + "<br>");

			SqlDataAdapter da = new SqlDataAdapter(strSelectCommand, strDSN);
			DataSet ds = new DataSet("root");
			da.Fill(ds, "item");
			DataView dv = ds.Tables[0].DefaultView;

			// ��X�`����
			int TotalCount = dv.Count;
			//Response.Write(" TotalCount = " + TotalCount + "<BR>");

			if(TotalCount>0)
			{
				// ��X�s�i�����N�X, �H��X������, ���ƭ����ɤ~����
				// ����X�U�檺 �s�i�����N�X
				for(int i=0; i<TotalCount; i++)
				{
					// �� for loop �O�N dv[i][j] �Ȭ��Ū�, �j����J�@�ӪťղŸ�
					//��ܥX�Ҧ��� dv[i][j] �̪����, �å� \ �Ÿ��j�}�ϧO
					// j=1; j<30 : 1~30 �O�ھ� item �@�� 29 �ӦӨ�
					for (int j=1;j<30;j++)
					{
						//Response.Write(j + ":" + dv[i][j] + "\\ \n");
						if(dv[i][j].ToString().Trim() == "" || dv[i][j].ToString().Trim() == null)
							dv[i][j] = " ";
					}


					// ��: ��Z���O �Y�אּ ��Z���O, �h�|�� Error: "�b���������󪺰������B��� null �ȡC"
					// �̤��P�� �Z�����O, ��e���W�����(�M��)����������ƭ�
					string drafttp = dv[i]["�Z�����O�N�X"].ToString();
					// �Y�Z�����O�� �½Z, �h�M�� ��Z�ηs�Z�����
					if(drafttp=="1")
					{
						dv[i]["��Z���O"] = " ";
						dv[i]["��Z���X"] = " ";
						dv[i]["��Z���X�����O"] = " ";
						dv[i]["�s�Z�s�k�N�X"] = " ";
					}
						// �Y�Z�����O�� �s�Z, �h�M�� �½Z�Χ�Z�����
					else if(drafttp=="2")
					{
						dv[i]["�½Z���O"] = " ";
						dv[i]["�½Z���X"] = " ";
						dv[i]["��Z���O"] = " ";
						dv[i]["��Z���X"] = " ";
						dv[i]["��Z���X�����O"] = " ";
					}
						// �Y�Z�����O�� ��Z, �h�M�� �½Z�ηs�Z�����
					else if(drafttp=="3")
					{
						dv[i]["�½Z���O"] = " ";
						dv[i]["�½Z���X"] = " ";
						dv[i]["�s�Z�s�k�N�X"] = " ";
					}


					// �P�O �s�i�����N�X �� ����(01) �� �b��(02), �èϪ�������ƻP���P�B, �A��X�T���ܪ�����
					// �p�� doReOrder() �~�i��X���T����
					string pgscd = dv[i]["�s�i�����N�X"].ToString();

					// �P�O �s�i�g�T �� 01(�u�����x) �� 02(�q�����x), �ÿ�X�T��
					if(pgscd == "01")
					{
						//Response.Write(" ������ = 8<BR>");
						// �`�N�u��N�ȦA��J dv[i]["����2"] ��, �]�뤣�i(�줣��) <Input id=pagelayout2> ��
						dv[i]["����2"] = 8;
						//pagelayout2.Value = 8;
					}
					else if (pgscd == "02")
					{
						//Response.Write(" ������ = 4<BR>");
						// �`�N�u��N�ȦA��J dv[i]["����2"] ��, �]�뤣�i(�줣��) <Input id=pagelayout2> ��
						dv[i]["����2"] = 4;
						//pagelayout2.Value = 4;
					}

					// �Y�s�i�g�T�� '�b��' ��, ��X���P�C��ѿ���
					// �]�ȶ�J xml ��, �G�C�⤴�L�k�� table ����ܤ��P�C��
//					string pgsnm = dv[i]["�s�i�g�T"].ToString();
//					if(pgsnm == "����")
//					{
//						pgsnm = pgsnm;
//					}
//					else if(pgsnm == "�b��")
//					{
//						pgsnm = "<font color='Red'>" + pgsnm + "</font>";
//					}
//					//Response.Write("pgsnm= " + pgsnm + "<br>");


					// �P�O �T�w�������O �� 0(�_) �� 1(�O), �ÿ�X�T��
					string fgFixPage = dv[i]["�T�w�������O"].ToString();
					if(fgFixPage == "0")
					{
						dv[i]["�T�w�������O"] = "�_";
					}
					else
					{
						dv[i]["�T�w�������O"] = "�O";
					}


					// �P�O ��Z���O �� 0(�_) �� 1(�O), �ÿ�X�T��
					string fgGot = dv[i]["��Z���O"].ToString();
					if(fgGot == "0")
					{
						dv[i]["��Z���O"] = "�_";
					}
					else
					{
						dv[i]["��Z���O"] = "�O";
					}

					// �½Z���y�W�٤w��� bk_nm; �Y�½Z���y�W�٨ϥ� bk_nm, ��Z���y�W�� ���i�P�ɤS�ϥ� bk_nm, ������ʧP�O
					// �P�O ��Z���y�N�X �� 01(�u�����x) �� 02(�q�����x), �ÿ�X�T��
					string chgbkcd = dv[i]["��Z���y�N�X"].ToString();
					if(chgbkcd == "01")
					{
						dv[i]["��Z���y�N�X"] = "�u�����x";
					}
					else if(chgbkcd == "02")
					{
						dv[i]["��Z���y�N�X"] = "�q�����x";
					}

				}
			}
			// �Y��Ʈw�̵L���, ��ܨ�T��
			else
			{
				this.lblDBMessage.Text = "�ثe��Ʈw���L���!";
			}


			// �ন xml ���A, ��J document.form1.hidData.Value
			//Response.Write("ds= " + ds.GetXml() + "<br>");
			hidData.Value = ds.GetXml();
			//Response.Write("hidData.Value= " + hidData.Value + "<br>");
		}



		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pgno", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("pg_bkcd", "pg_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pg_startpgno", "pg_startpgno")})});
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = "SELECT pg_bkcd, pg_startpgno FROM dbo.c2_pgno";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
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
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("PageNo", "PageNo"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgno", "pub_pgno"),
																																																				new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgfixpg", "pub_fgfixpg"),
																																																				new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																				new System.Data.Common.DataColumnMapping("pub_modempno", "pub_modempno"),
																																																				new System.Data.Common.DataColumnMapping("pub_remark", "pub_remark"),
																																																				new System.Data.Common.DataColumnMapping("pub_origbkcd", "pub_origbkcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_origjno", "pub_origjno"),
																																																				new System.Data.Common.DataColumnMapping("pub_origjbkno", "pub_origjbkno"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgbkcd", "pub_chgbkcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgjno", "pub_chgjno"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgjbkno", "pub_chgjbkno"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																				new System.Data.Common.DataColumnMapping("pub_njtpcd", "pub_njtpcd"),
																																																				new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				new System.Data.Common.DataColumnMapping("layout2", "layout2"),
																																																				new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																				new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																				new System.Data.Common.DataColumnMapping("njtp_nm", "njtp_nm"),
																																																				new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno1", "pub_contno1"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq1", "pub_pubseq1"),
																																																				new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm1", "pub_yyyymm1"),
																																																				new System.Data.Common.DataColumnMapping("lp_priorseq", "lp_priorseq"),
																																																				new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed")})});
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("bk_bkid", "bk_bkid"),
																																																			  new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT bk_bkid, bk_bkcd, RTRIM(bk_nm) AS bk_nm FROM dbo.book";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter4
			//
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																				new System.Data.Common.DataColumnMapping("CountNo", "CountNo"),
																																																				new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed")})});
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT dbo.c2_pub.pub_pgno AS PageNo, RTRIM(dbo.c2_pub.pub_contno) AS pub_contno," +
				" RTRIM(dbo.c2_pub.pub_pubseq) AS pub_pubseq, RTRIM(dbo.c2_pub.pub_yyyymm) AS pub" +
				"_yyyymm, dbo.c2_pub.pub_pgno AS pub_pgno, RTRIM(dbo.c2_pub.pub_ltpcd) AS pub_ltp" +
				"cd, RTRIM(dbo.c2_pub.pub_clrcd) AS pub_clrcd, RTRIM(dbo.c2_pub.pub_pgscd) AS pub" +
				"_pgscd, RTRIM(dbo.c2_pub.pub_fgfixpg) AS pub_fgfixpg, RTRIM(dbo.c2_pub.pub_fggot" +
				") AS pub_fggot, RTRIM(dbo.c2_pub.pub_modempno) AS pub_modempno, RTRIM(dbo.c2_pub" +
				".pub_remark) AS pub_remark, RTRIM(dbo.c2_pub.pub_origbkcd) AS pub_origbkcd, RTRI" +
				"M(dbo.c2_pub.pub_origjno) AS pub_origjno, RTRIM(dbo.c2_pub.pub_origjbkno) AS pub" +
				"_origjbkno, RTRIM(dbo.c2_pub.pub_chgbkcd) AS pub_chgbkcd, RTRIM(dbo.c2_pub.pub_c" +
				"hgjno) AS pub_chgjno, RTRIM(dbo.c2_pub.pub_chgjbkno) AS pub_chgjbkno, RTRIM(dbo." +
				"c2_pub.pub_fgrechg) AS pub_fgrechg, RTRIM(dbo.c2_pub.pub_njtpcd) AS pub_njtpcd, " +
				"RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, 8 AS layout2, RTRIM(dbo.c2_pub.pub_bkcd) AS p" +
				"ub_bkcd, RTRIM(dbo.c2_clr.clr_nm) AS clr_nm, RTRIM(dbo.c2_ltp.ltp_nm) AS ltp_nm," +
				" RTRIM(dbo.c2_pgsize.pgs_nm) AS pgs_nm, RTRIM(dbo.c2_njtp.njtp_nm) AS njtp_nm, R" +
				"TRIM(dbo.book.bk_nm) AS bk_nm, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname, RTRI" +
				"M(dbo.c2_pub.pub_drafttp) AS pub_drafttp, dbo.c2_pub.pub_contno AS pub_contno, d" +
				"bo.c2_pub.pub_pubseq AS pub_pubseq, dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_yyyymm " +
				"AS pub_yyyymm, dbo.c2_lprior.lp_priorseq, dbo.c2_lprior.lp_bkcd, dbo.c2_cont.con" +
				"t_fgclosed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont" +
				"_fgpubed, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd FROM dbo.c2_pub INNER " +
				"JOIN dbo.c2_cont ON dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno AND dbo.c2_p" +
				"ub.pub_syscd = dbo.c2_cont.cont_syscd INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfr" +
				"no = dbo.mfr.mfr_mfrno INNER JOIN dbo.c2_lprior ON dbo.c2_pub.pub_ltpcd = dbo.c2" +
				"_lprior.lp_ltpcd AND dbo.c2_pub.pub_clrcd = dbo.c2_lprior.lp_clrcd AND dbo.c2_pu" +
				"b.pub_pgscd = dbo.c2_lprior.lp_pgscd AND dbo.c2_pub.pub_bkcd = dbo.c2_lprior.lp_" +
				"bkcd LEFT OUTER JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd L" +
				"EFT OUTER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd L" +
				"EFT OUTER JOIN dbo.c2_ltp ON dbo.c2_pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd LEFT OU" +
				"TER JOIN dbo.c2_njtp ON dbo.c2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd LEFT OUT" +
				"ER JOIN dbo.book ON dbo.c2_pub.pub_origbkcd = dbo.book.bk_bkcd LEFT OUTER JOIN d" +
				"bo.srspn ON dbo.c2_cont.cont_empno = dbo.srspn.srspn_empno WHERE (dbo.c2_cont.co" +
				"nt_fgclosed = \'0\') AND (dbo.c2_cont.cont_fgcancel = \'0\') AND (dbo.c2_cont.cont_f" +
				"gtemp = \'0\') AND (dbo.c2_cont.cont_fgpubed = \'1\') ORDER BY dbo.c2_lprior.lp_prio" +
				"rseq, dbo.c2_pub.pub_pgno, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_" +
				"pub.pub_pubseq";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand4
			//
			this.sqlSelectCommand4.CommandText = @"SELECT dbo.c2_pub.pub_clrcd, dbo.c2_pub.pub_pgscd, COUNT(dbo.c2_pub.pub_contno) AS CountNo, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed FROM dbo.c2_pub INNER JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd INNER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd INNER JOIN dbo.c2_cont ON dbo.c2_pub.pub_syscd = dbo.c2_cont.cont_syscd AND dbo.c2_pub.pub_contno = dbo.c2_cont.cont_contno WHERE (dbo.c2_pub.pub_bkcd = @bkcd) AND (dbo.c2_pub.pub_yyyymm = @yyyymm) AND (dbo.c2_cont.cont_fgclosed = '0') AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0') AND (dbo.c2_cont.cont_fgpubed = '1') GROUP BY dbo.c2_pub.pub_clrcd, dbo.c2_pub.pub_pgscd, dbo.c2_clr.clr_nm, dbo.c2_pgsize.pgs_nm, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgpubed";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			this.sqlSelectCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "pub_bkcd"));
			this.sqlSelectCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, "pub_yyyymm"));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



	}
}
