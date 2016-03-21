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
// SQLCommand
using System.Data.SqlClient;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adpub_actupdate.
	/// </summary>
	public class adpub_actupdate : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
	
		public adpub_actupdate()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				// �I�s DataBinding() 
				DataBinding();
			}
		}
		

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		

		private void DataBinding()
		{
			//��X�����ܼ�
			string Qstrbkcd = Context.Request.QueryString["bkcd"].ToString().Trim();
			string Qstryyyymm = Context.Request.QueryString["yyyymm"].ToString().Trim();
			
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "c2_pub");
			DataView dv = ds.Tables["c2_pub"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� cust_mfrno and ��L rowfilter ����
			string rowfilterstr = "1=1";
			if(Qstrbkcd != "")
				rowfilterstr = rowfilterstr + " and (���y���O�N�X = '" + Qstrbkcd + "')";
			else
				rowfilterstr = rowfilterstr;
			if(Qstryyyymm != "")
				rowfilterstr = rowfilterstr + " and (�Z�n�~�� LIKE '%" + Qstryyyymm + "%')";
			else
				rowfilterstr = rowfilterstr;
			dv.RowFilter = rowfilterstr;
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv.Count= "+ dv.Count + "<BR>");
			//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");
			
			// �Y�j�M���G�� "�䤣��" ���B�z
//			if (dv.Count==0)
//				lblMessage.Text="�d�ߵ��G: �䤣��ŦX���󪺸��, �z�i�H 1.���]����  2.�s�W�t�өέq����";
//			else
//				lblMessage.Text="�d�ߵ��G: ��� "+dv.Count.ToString()+"���Ȥ���";
			
			DataGrid1.DataSource=dv;
			DataGrid1.DataBind();
			
			
			// �S�O��줧��X�榡�ഫ - �ܧ�ñ��������榡
			int i;
			for(i=0; i< DataGrid1.Items.Count ; i++)
			{
				// �Z�n�~��
				string yyyymm = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
				yyyymm = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
				DataGrid1.Items[i].Cells[3].Text = yyyymm;
				
				// �s�i��m / �s�i�g�T / �s�i����
				string ClrName = DataGrid1.Items[i].Cells[5].Text.ToString().Trim();
				string PgsizeName = DataGrid1.Items[i].Cells[6].Text.ToString().Trim();
				string LtpName = DataGrid1.Items[i].Cells[7].Text.ToString().Trim();
				//Response.Write("ClrName=" + ClrName + ", ");
				//Response.Write("PgsizeName=" + PgsizeName + ", ");
				//Response.Write("LtpName=" + LtpName + "<br>");
				if(ClrName == "����")
				{
					DataGrid1.Items[i].Cells[5].Text = "<font color=DarkRed>" + ClrName + "<font>";
				}
				else
				{
					DataGrid1.Items[i].Cells[5].Text = ClrName;
				}
				
				if(PgsizeName == "����")
				{
					DataGrid1.Items[i].Cells[6].Text = "<font color=DarkRed>" + PgsizeName + "<font>";
				}
				else
				{
					DataGrid1.Items[i].Cells[6].Text = PgsizeName;
				}
				
				if(LtpName == "����")
				{
					DataGrid1.Items[i].Cells[7].Text = "<font color=DarkRed>" + LtpName + "<font>";
				}
				else
				{
					DataGrid1.Items[i].Cells[7].Text = LtpName;
				}
				
				
				// �T�w�������O
				string fgFixPg = DataGrid1.Items[i].Cells[8].Text.ToString().Trim();
				if(fgFixPg=="1")
                    DataGrid1.Items[i].Cells[8].Text = "<font color=Red>�O</font>";
				else
					DataGrid1.Items[i].Cells[8].Text = "�_";
				

				// ��Z���O
				string fgGot = DataGrid1.Items[i].Cells[11].Text.ToString().Trim();
				if(fgGot=="1")
					DataGrid1.Items[i].Cells[11].Text = "�O";
				else
					DataGrid1.Items[i].Cells[11].Text = "<font color=Red>�_</font>";
				

				// ��Z�������
				string Chgbkcd = DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
				string Chgjno = DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
				string Chgjbkno = DataGrid1.Items[i].Cells[14].Text.ToString().Trim();
				string fgReChg = DataGrid1.Items[i].Cells[15].Text.ToString().Trim();
				if(Chgbkcd == "01" || Chgbkcd == "02")
				{
					// �N ��Z���y�N�X �אּ��r���
					if(Chgbkcd == "01")
						DataGrid1.Items[i].Cells[12].Text = "�u�����x";
					else if(Chgbkcd == "02")
						DataGrid1.Items[i].Cells[12].Text = "�q�����x";

					// �N ��Z���X�����O �אּ��r���
					if(fgReChg == "0")
						DataGrid1.Items[i].Cells[15].Text = "<font color=Red>�O</font>";
					else
						DataGrid1.Items[i].Cells[15].Text = "�_";

					// �M���s�Z/�½Z���
					DataGrid1.Items[i].Cells[11].Text = "";
					DataGrid1.Items[i].Cells[16].Text = "";
					DataGrid1.Items[i].Cells[17].Text = "";
					DataGrid1.Items[i].Cells[18].Text = "";
				}
				else
				{
					// �Y�D��Z, �h�M�����Z���
					DataGrid1.Items[i].Cells[12].Text = DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
					Chgjno = "";
					Chgjbkno = "";
					fgReChg= "";
					DataGrid1.Items[i].Cells[13].Text = Chgjno;
					DataGrid1.Items[i].Cells[14].Text = Chgjbkno;
					DataGrid1.Items[i].Cells[15].Text = fgReChg;
				}
				

				// �½Z�������
				string Origbkcd = DataGrid1.Items[i].Cells[16].Text.ToString().Trim();
				string Origjno = DataGrid1.Items[i].Cells[17].Text.ToString().Trim();
				string Origjbkno = DataGrid1.Items[i].Cells[18].Text.ToString().Trim();
//				if(Origbkcd == "01" || Origbkcd == "02")
//				{
//				}
//				else
//				{
//					DataGrid1.Items[i].Cells[16].Text = "";
//					DataGrid1.Items[i].Cells[17].Text = "";
//					DataGrid1.Items[i].Cells[18].Text = "";
//				}

				
			// ���� for(i=0; i< DataGrid1.Items.Count ; i++)
			}
			
			
		}

		protected object GetfgUpdate(object fgupdate)
		{
			bool strReturn = false;
			if(fgupdate.ToString().Trim() == "1")
				strReturn = true;
			return strReturn;
		}
		

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																				new System.Data.Common.DataColumnMapping("����", "����"),
																																																				new System.Data.Common.DataColumnMapping("�X���ѽs��", "�X���ѽs��"),
																																																				new System.Data.Common.DataColumnMapping("�����Ǹ�", "�����Ǹ�"),
																																																				new System.Data.Common.DataColumnMapping("�Z�n�~��", "�Z�n�~��"),
																																																				new System.Data.Common.DataColumnMapping("�Z�n���X", "�Z�n���X"),
																																																				new System.Data.Common.DataColumnMapping("�s�i��m�N�X", "�s�i��m�N�X"),
																																																				new System.Data.Common.DataColumnMapping("�s�i�����N�X", "�s�i�����N�X"),
																																																				new System.Data.Common.DataColumnMapping("�s�i�g�T�N�X", "�s�i�g�T�N�X"),
																																																				new System.Data.Common.DataColumnMapping("�T�w�������O", "�T�w�������O"),
																																																				new System.Data.Common.DataColumnMapping("��Z���O", "��Z���O"),
																																																				new System.Data.Common.DataColumnMapping("�����~�ȭ��u��", "�����~�ȭ��u��"),
																																																				new System.Data.Common.DataColumnMapping("�Ƶ�", "�Ƶ�"),
																																																				new System.Data.Common.DataColumnMapping("�½Z���y�N�X", "�½Z���y�N�X"),
																																																				new System.Data.Common.DataColumnMapping("�½Z���O", "�½Z���O"),
																																																				new System.Data.Common.DataColumnMapping("�½Z���X", "�½Z���X"),
																																																				new System.Data.Common.DataColumnMapping("��Z���y�N�X", "��Z���y�N�X"),
																																																				new System.Data.Common.DataColumnMapping("��Z���O", "��Z���O"),
																																																				new System.Data.Common.DataColumnMapping("��Z���X", "��Z���X"),
																																																				new System.Data.Common.DataColumnMapping("��Z���X�����O", "��Z���X�����O"),
																																																				new System.Data.Common.DataColumnMapping("�s�Z�s�k�N�X", "�s�Z�s�k�N�X"),
																																																				new System.Data.Common.DataColumnMapping("���q�W��", "���q�W��"),
																																																				new System.Data.Common.DataColumnMapping("����2", "����2"),
																																																				new System.Data.Common.DataColumnMapping("���y���O�N�X", "���y���O�N�X"),
																																																				new System.Data.Common.DataColumnMapping("�s�i��m", "�s�i��m"),
																																																				new System.Data.Common.DataColumnMapping("�s�i����", "�s�i����"),
																																																				new System.Data.Common.DataColumnMapping("�s�i�g�T", "�s�i�g�T"),
																																																				new System.Data.Common.DataColumnMapping("�s�Z�s�k", "�s�Z�s�k"),
																																																				new System.Data.Common.DataColumnMapping("�½Z���y�W��", "�½Z���y�W��"),
																																																				new System.Data.Common.DataColumnMapping("�����~�ȭ��m�W", "�����~�ȭ��m�W"),
																																																				new System.Data.Common.DataColumnMapping("�Z�����O�N�X", "�Z�����O�N�X"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				new System.Data.Common.DataColumnMapping("���s�˫�ק���O", "���s�˫�ק���O")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT c2_pub.pub_pubid AS ID, 0 AS ����, RTRIM(c2_pub.pub_contno) AS �X���ѽs��, RTRIM(" +
				"c2_pub.pub_pubseq) AS �����Ǹ�, RTRIM(c2_pub.pub_yyyymm) AS �Z�n�~��, c2_pub.pub_pgno AS" +
				" �Z�n���X, RTRIM(c2_pub.pub_clrcd) AS �s�i��m�N�X, RTRIM(c2_pub.pub_pgscd) AS �s�i�����N�X, RTR" +
				"IM(c2_pub.pub_ltpcd) AS �s�i�g�T�N�X, RTRIM(c2_pub.pub_fgfixpg) AS �T�w�������O, RTRIM(c2_pu" +
				"b.pub_fggot) AS ��Z���O, RTRIM(c2_pub.pub_modempno) AS �����~�ȭ��u��, RTRIM(c2_pub.pub_re" +
				"mark) AS �Ƶ�, RTRIM(c2_pub.pub_origbkcd) AS �½Z���y�N�X, RTRIM(c2_pub.pub_origjno) AS " +
				"�½Z���O, RTRIM(c2_pub.pub_origjbkno) AS �½Z���X, RTRIM(c2_pub.pub_chgbkcd) AS ��Z���y�N�X, " +
				"RTRIM(c2_pub.pub_chgjno) AS ��Z���O, RTRIM(c2_pub.pub_chgjbkno) AS ��Z���X, RTRIM(c2_p" +
				"ub.pub_fgrechg) AS ��Z���X�����O, RTRIM(c2_pub.pub_njtpcd) AS �s�Z�s�k�N�X, RTRIM(mfr.mfr_in" +
				"m) AS ���q�W��, 8 AS ����2, RTRIM(c2_pub.pub_bkcd) AS ���y���O�N�X, RTRIM(c2_clr.clr_nm) AS " +
				"�s�i��m, RTRIM(c2_ltp.ltp_nm) AS �s�i����, RTRIM(c2_pgsize.pgs_nm) AS �s�i�g�T, RTRIM(c2_nj" +
				"tp.njtp_nm) AS �s�Z�s�k, RTRIM(book.bk_nm) AS �½Z���y�W��, RTRIM(srspn.srspn_cname) AS ����" +
				"�~�ȭ��m�W, RTRIM(c2_pub.pub_drafttp) AS �Z�����O�N�X, c2_pub.pub_contno, c2_pub.pub_pubseq" +
				", c2_pub.pub_syscd, c2_pub.pub_yyyymm, c2_pub.pub_fgupdated AS ���s�˫�ק���O FROM c2_" +
				"pub INNER JOIN c2_cont ON c2_pub.pub_contno = c2_cont.cont_contno AND c2_pub.pub" +
				"_syscd = c2_cont.cont_syscd INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno" +
				" LEFT OUTER JOIN c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd LEFT OUTER JOIN c" +
				"2_pgsize ON c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd LEFT OUTER JOIN c2_ltp ON c2_" +
				"pub.pub_ltpcd = c2_ltp.ltp_ltpcd LEFT OUTER JOIN c2_njtp ON c2_pub.pub_njtpcd = " +
				"c2_njtp.njtp_njtpcd LEFT OUTER JOIN book ON c2_pub.pub_origbkcd = book.bk_bkcd L" +
				"EFT OUTER JOIN srspn ON c2_cont.cont_empno = srspn.srspn_empno ORDER BY �Z�n���X, �X��" +
				"�ѽs��, �Z�n�~�� DESC, �����Ǹ�";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			// ��X�U�� ���s�˫�ק���O ����
			int i;
			for(i=0; i< DataGrid1.Items.Count ; i++)
			{ 
				// ��X c2_pub �� PK
				string strSyscd = "C2";
				string strContNo = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();
				string strYYYYMM = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
				string strPubSeq = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
				//Response.Write("syscd= " + strSyscd + "," );
				//Response.Write("ContNo=" + strContNo + "," );
				//Response.Write("yyyymm=" + strYYYYMM + "," );
				//Response.Write("pubseq=" + strPubSeq + "," );
				
				// ��X ItemTemplate �� CheckBox ���A�� cbxUpdate (Controls[1])
				string strfgUpdate = ((CheckBox)DataGrid1.Items[i].Cells[21].Controls[1]).Checked.ToString();
				//Response.Write("���s�˫�ק���O= " + ((CheckBox)DataGrid1.Items[i].Cells[21].Controls[1]).Checked.ToString() + "<br>");
				//Response.Write("strfgUpdate= " + strfgUpdate + "<br>");
				
				// ���� ��s sqlcmd
				string sqlcmd1 = "";
				// �T�{ myCommand ����s���O���e - sqlcmd1: �w�q�b for loop ���e
				sqlcmd1 = " UPDATE c2_pub ";

				// �Y  ���s�˫�ק���O ���Ŀ�, �h��s���
				if(strfgUpdate == "True")
				{
					//Response.Write("True, update sql table...<br>");
					
//					// ���� ��s sqlcmd
//					string sqlcmd1 = "";
//					// �T�{ myCommand ����s���O���e - sqlcmd1: �w�q�b for loop ���e
//					sqlcmd1 = " UPDATE c2_pub ";
					sqlcmd1 = sqlcmd1 + " SET pub_fgupdated = 1";
					
				}
				else
				{
					//Response.Write("False, do nothing~<br>");
					sqlcmd1 = sqlcmd1 + " SET pub_fgupdated = 0";
				}
				
				sqlcmd1 = sqlcmd1 + " WHERE (pub_syscd = '" + strSyscd + "') AND (pub_contno = '" + strContNo + "') AND (pub_yyyymm = '" + strYYYYMM + "') AND (pub_pubseq = '" + strPubSeq + "')";
				//Response.Write("sqlcmd1= " + sqlcmd1 + "<br><br>");
						
				// ���� myCommand (myCommand �O���� sqlCommand1: sp_c2_adpub_act3_pub ) ��s��Ʈw: ���� ��� c2_pub
				SqlCommand myCommand = new SqlCommand(sqlcmd1, sqlConnection1);
				myCommand.Connection = sqlConnection1;
				myCommand.Connection.Open();
				bool ResultFlag1;
				try
				{
					myCommand.ExecuteNonQuery();
					ResultFlag1=true;
				}
				catch(System.Data.SqlClient.SqlException ex1)
				{
					ResultFlag1=false;
					Response.Write(ex1.Message + "<br>");
				}
				finally
				{
					this.sqlConnection1.Close();
				}
				
				// ��X���浲�G
				if(ResultFlag1)
				{
					//Response.Write("��s���s�˫���O���\!<br>");
				}
				else  
				{
					//Response.Write("��s���s�˫���O����!<br>");
				}
				
				
			// ���� for loop
			}
			
		}
		

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			// �����^����
			Response.Redirect("/mrlpub/");
		}
		
		
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
		}
		
		
		// �����ɪ��B�z
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
		}
		
		
	}
}
