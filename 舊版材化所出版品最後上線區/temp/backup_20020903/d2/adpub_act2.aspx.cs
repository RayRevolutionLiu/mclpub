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

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adpub_act2.
	/// </summary>
	public class adpub_act2 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblSearchKeyword;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.HtmlControls.HtmlForm form1;
		protected System.Web.UI.WebControls.Label lblDBMessage;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidData;
	
		public adpub_act2()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				// ��X�����ܼ� bkcd & yyyymm, �N���ন��r��ܤ�
				InitialMyData();
				

				//Load Data From DB, �ন xml ���A, �A��J document.form1.hidData.Value
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
		

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
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
			this.sqlSelectCommand1.CommandText = "SELECT bk_bkid, bk_bkcd, bk_nm FROM book";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
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
		}
		
		
		private void LoadDataFromDB()
		{
			// ��X�����ܼ� bkcd & yyyymm
			string Reqbkcd = Context.Request.QueryString["bkcd"].ToString();
			string Reqyyyymm = Context.Request.QueryString["yyyymm"].Trim();
			
			// ��X��Ʈw�������, �õ����O�W, �H�ন xml ���A
			// ��: RTRIM() �O Transact-SQL �̪� function, �N�r��k�誺�ťեh��; ���Z�n���X����� RTRIM() �_�h Order by �|�����~
			// ��: �]�����b��Ʈw�����s�b, �G�H SELECT 0 AS ���� �ӥN�� (��������l�ȳ]�� 0)
			string strDSN = "Server=isccom1;User ID=webuser;Password=db600;Database=mrlpub;";
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
			strSelectCommand = strSelectCommand + " RTRIM(c2_pub.pub_drafttp) AS �Z�����O�N�X ";
			strSelectCommand = strSelectCommand + " FROM c2_pub ";
			strSelectCommand = strSelectCommand + " INNER JOIN c2_cont ON c2_pub.pub_contno = c2_cont.cont_contno ";
			strSelectCommand = strSelectCommand + " AND c2_pub.pub_syscd = c2_cont.cont_syscd ";
			strSelectCommand = strSelectCommand + " INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno ";
			strSelectCommand = strSelectCommand + " LEFT OUTER JOIN c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd ";
			strSelectCommand = strSelectCommand + " LEFT OUTER JOIN c2_pgsize ON c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd ";
			strSelectCommand = strSelectCommand + " LEFT OUTER JOIN c2_ltp ON c2_pub.pub_ltpcd = c2_ltp.ltp_ltpcd ";
			strSelectCommand = strSelectCommand + " LEFT OUTER JOIN c2_njtp ON c2_pub.pub_njtpcd = c2_njtp.njtp_njtpcd ";
			strSelectCommand = strSelectCommand + " LEFT OUTER JOIN book ON c2_pub.pub_origbkcd = book.bk_bkcd ";
			strSelectCommand = strSelectCommand + " LEFT OUTER JOIN srspn ON c2_cont.cont_empno = srspn.srspn_empno ";
			strSelectCommand = strSelectCommand + " WHERE (c2_pub.pub_bkcd =" + Reqbkcd + ") AND (c2_pub.pub_yyyymm LIKE '%" + Reqyyyymm + "%') ";
			strSelectCommand = strSelectCommand + " ORDER BY �Z�n���X, �X���ѽs��, �Z�n�~�� DESC, �����Ǹ� ";
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
			hidData.Value = ds.GetXml();
			//Response.Write("hidData.Value= " + hidData.Value + "<br>");

		}

	}
}
