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
// WebApplication Virables - Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adlprior_addnew.
	/// </summary>
	public class adlprior_addnew : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox tbxPriorSeq;
		protected System.Web.UI.WebControls.DropDownList ddlColorCode;
		protected System.Web.UI.WebControls.DropDownList ddlLayoutTypeCode;
		protected System.Web.UI.WebControls.DropDownList ddPageSizeCode;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter6;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter7;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Button btnReturnHome;

		public adlprior_addnew()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if(!Page.IsPostBack)
			{
				Response.Expires = 0;

				// ��X�U�U�Ԧ���檺��
				InitData();

				// �̮��y���O�ӧ�X��s���ƪ��u������
				//BookchangeSeq();


				// �� ���� �s�W/���@/�R�� �e���Ө�, �I�s���e���� �S��B�z
				if(Context.Request.QueryString["function"].ToString().Trim() != "")
				{
					FromPub();
				}
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
			this.ddlBookCode.Enabled = true;

			// �M�����
			this.tbxPriorSeq.Text = "";

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
		}


		// �̮��y���O�ӧ�X��s���ƪ��u������
//		private void BookchangeSeq()
//		{
//			// ��X�ثe�e����(�w�]��)�����y���O����
//			string CurrentBookCode = this.ddlBookCode.SelectedItem.Value.ToString();
//			//Response.Write("CurrentBookCode= "+ CurrentBookCode + "<BR>");
//
//
//			// �̤��P���y���O, ��X�s���ƪ��u������ max(lp_priorseq)
//			string strConn="server=isccom1;database=mrlpub;uid=webuser;pwd=db600";
//			//string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
//			SqlConnection myConn=new SqlConnection(strConn);
//
//			//��X�ثe��Ʈw�� (�̸Ӯ��y���O), �ثe�̤j���ƪ��u�����Ǥ���
//			SqlDataAdapter cmd=new SqlDataAdapter("select COUNT(*) AS TotalCounts, MAX(lp_priorseq) AS MaxSeq from c2_lprior where lp_bkcd='" + CurrentBookCode + "'",myConn);
//			//SqlDataAdapter cmd=new SqlDataAdapter("select COUNT(*) AS TotalCounts, MAX(lp_priorseq) AS MaxSeq from c2_lprior where (lp_bkcd='03')",myConn);
//			//SqlDataAdapter cmd=new SqlDataAdapter("select COUNT(*) AS TotalCounts, MAX(lp_priorseq) AS MaxSeq from c2_lprior where (lp_bkcd = '02')",myConn);
//			DataSet ds = new DataSet();
//			cmd.Fill(ds, "c2_lprior");
//			DataView dv = ds.Tables["c2_lprior"].DefaultView;
//			//Response.Write("dv.Count= "+ dv.Count + "<BR>");
//
//			string TotalCounts = dv[0]["TotalCounts"].ToString().Trim();
//			string MaxSeq = "";
//			int intNewMaxSeq = 0;
//			// �`�N, �Y c2_lprior �̧䤣��Ӯ��y���O����(�p 03), �� MaxSeq �N�� null
//			// �ҥH�n���P�_ MaxSeq �O�_�� null, �H�K��䤣��Ӯ��y���O����(�p03)��, �N���� error: ���{�� lp_bkcd=03 (�Y Row.Filter �L���h)
//			if (dv[0]["MaxSeq"].ToString().Trim() != "")
//			{
//				MaxSeq = dv[0]["MaxSeq"].ToString().Trim();
//				//Response.Write("MaxSeq= " + MaxSeq + "<br>");
//
//				// ��X�s���ƪ��u������
//				intNewMaxSeq = (int.Parse(MaxSeq) ) + 1;
//				//Response.Write("intNewMaxSeq= " + intNewMaxSeq + "<br>");
//			}
//			else
//			{
//				MaxSeq = "";
//				intNewMaxSeq = 1;
//			}
//			//Response.Write("TotalCounts= " + TotalCounts + "<br>");
//
//
//			// �Y��즹�����, �h���J���
//			if(dv.Count>0)
//			{
//				this.tbxPriorSeq.Text = intNewMaxSeq.ToString().Trim();
//			}
//			else
//			{
//				this.tbxPriorSeq.Text = "1";
//			}
//
//		}


		// �Y���y�W���ܧ�, �h��X�̷s�����ǭ�
		private void ddlBookCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//BookchangeSeq();
		}


		// ��X ���w��m���ƪ��u������, �å������s�ʧ@ (���N���ᵧ�Ƥ����ǭȧ�s)
		private void GetNewlpSeq()
		{
			// ��X ���w��m���ƪ��u������ ��
			string CurrentBookCode = this.ddlBookCode.SelectedItem.Value.ToString();
			string CurrentPriorSeq = this.tbxPriorSeq.Text.ToString();
			int intCurrentPriorSeq = Convert.ToInt16(CurrentPriorSeq);
			//Response.Write("CurrentBookCode= " + CurrentBookCode + "<br>");
			//Response.Write("CurrentPriorSeq= " + CurrentPriorSeq + "<br>");
			//Response.Write("intCurrentPriorSeq= " + intCurrentPriorSeq + "<br>");

			// ��X�ثe�̤j�� MaxLPSeq, �n��K��X���ᵧ�Ƥ��v����
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds6 = new DataSet();
			// �� sqlDataAdapter1 �L�o���� - ���w Parameters
			this.sqlDataAdapter6.SelectCommand.Parameters["@bkcd"].Value = CurrentBookCode;
			this.sqlDataAdapter6.Fill(ds6, "c2_lprior");
			DataView dv6 = ds6.Tables["c2_lprior"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr6 = "1=1";
			dv6.RowFilter = rowfilterstr6;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
			//Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");

			// �Y�j�M���G�� "�䤣��" ���B�z
			string MaxLPSeq = "01";
			int intMaxLPSeq = Convert.ToInt16(MaxLPSeq);
			if (dv6.Count > 0)
			{
				MaxLPSeq = dv6[0]["MaxSeq"].ToString();
				intMaxLPSeq = Convert.ToInt16(MaxLPSeq);
				//Response.Write("intMaxLPSeq= " + intMaxLPSeq + "<br>");

				for(int i=intMaxLPSeq; i>=intCurrentPriorSeq; i--)
				{
					//Response.Write("i= " + i + ", ");
					string stri = Convert.ToString(i);
					if(stri.Length < 2)
						stri = "0" + stri;
					//Response.Write("stri= " + stri + "<br>");

					// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
					DataSet ds7 = new DataSet();
					this.sqlDataAdapter7.Fill(ds7, "c2_lprior");
					DataView dv7 = ds7.Tables["c2_lprior"].DefaultView;

					// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
					// �] Row Filter: default �� 1=1 and ��L rowfilter ����
					string rowfilterstr7 = "1=1";
					rowfilterstr7 = rowfilterstr7 + " AND lp_bkcd=" + CurrentBookCode;
					rowfilterstr7 = rowfilterstr7 + " AND lp_priorseq=" + stri;
					dv7.RowFilter = rowfilterstr7;

					// �ˬd�ÿ�X �̫� Row Filter �����G
					//Response.Write("dv7.Count= "+ dv7.Count + "<BR>");
					//Response.Write("dv7.RowFilter= " + dv7.RowFilter + "<BR>");

					if(dv7.Count > 0)
					{
						// ��X ���ᵧ�Ƥ������� - ���y�N�X, �s�i�����N�X, �s�i��m�N�X, �s�i�g�T�N�X
						string iBookCode = dv7[0]["lp_bkcd"].ToString();
						string iLayoutTypeCode = dv7[0]["lp_ltpcd"].ToString();
						string iColorCode = dv7[0]["lp_clrcd"].ToString();
						string iPageSizeCode = dv7[0]["lp_pgscd"].ToString();
						//Response.Write("iBookCode= " + iBookCode + ", ");
						//Response.Write("iLPSeq= " + stri + ", ");
						//Response.Write("iLayoutTypeCode= " + iLayoutTypeCode + ", ");
						//Response.Write("iColorCode= " + iColorCode + ", ");
						//Response.Write("iPageSizeCode= " + iPageSizeCode + "<br>");

						int intNewLPSeq = i+1;
						string strNewLPSeq = Convert.ToString(intNewLPSeq);
						if(strNewLPSeq.Length < 2)
							strNewLPSeq = "0" + strNewLPSeq;
						//Response.Write("strNewLPSeq= " + strNewLPSeq + "<br><br>");

						// �����s�ʧ@
						//string strConn="server=isccom2;database=mrlpub;uid=webuser;pwd=db600";
						string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
						SqlConnection myConn=new SqlConnection(strConn);

						SqlDataAdapter cmd=new SqlDataAdapter("UPDATE c2_lprior SET lp_priorseq = '" + strNewLPSeq + "' WHERE (lp_bkcd = @lp_bkcd) AND (lp_clrcd = @lp_clrcd) AND (lp_ltpcd = @lp_ltpcd) AND (lp_pgscd = @lp_pgscd)",myConn);
						//Response.Write("iLPSeq= " + stri + "<br>");
						//Response.Write("cmd= UPDATE c2_lprior SET lp_priorseq = '" + strNewLPSeq + "' WHERE (lp_bkcd = @lp_bkcd) AND (lp_clrcd = @lp_clrcd) AND (lp_ltpcd = @lp_ltpcd) AND (lp_pgscd = @lp_pgscd + ")");

						//cmd.SelectCommand.Parameters.Add("@lp_lpid",SqlDbType.Int,4).Value = id;
						cmd.SelectCommand.Parameters.Add("@lp_bkcd",SqlDbType.Char,2).Value = iBookCode;
						cmd.SelectCommand.Parameters.Add("@lp_priorseq",SqlDbType.Char,2).Value = CurrentPriorSeq;
						cmd.SelectCommand.Parameters.Add("@lp_ltpcd",SqlDbType.Char,2).Value = iLayoutTypeCode;
						cmd.SelectCommand.Parameters.Add("@lp_clrcd",SqlDbType.Char,2).Value = iColorCode;
						cmd.SelectCommand.Parameters.Add("@lp_pgscd",SqlDbType.Char,2).Value = iPageSizeCode;

						DataSet ds = new DataSet();
						cmd.Fill(ds,"c2_lprior");
					}
				}
			}
			else
			{
				MaxLPSeq = MaxLPSeq;
			}
			//Response.Write("MaxLPSeq= " + MaxLPSeq + "<br>");

		}


		// ���U �T�w�s�W ���s�ɪ��B�z
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			// ��X�ثe�e�����Ҧ�����, �A����Ʈw�̬O�_������;
			// �Y����(��Ƥw�s�b), ��ĵ�i; �Ϥ�, �h�s�W�ܸ�Ʈw��
			string CurrentBookCode = this.ddlBookCode.SelectedItem.Value.ToString();
			string CurrentPriorSeq = this.tbxPriorSeq.Text.ToString();
			string CurrentLayoutTypeCode = this.ddlLayoutTypeCode.SelectedItem.Value.ToString();
			string CurrentColorCode = this.ddlColorCode.SelectedItem.Value.ToString();
			string CurrentPageSizeCode = this.ddPageSizeCode.SelectedItem.Value.ToString();
			//Response.Write("CurrentBookCode= " + CurrentBookCode + "<br>");
			//Response.Write("CurrentPriorSeq= " + CurrentPriorSeq + "<br>");
			//Response.Write("CurrentLayoutTypeCode= " + CurrentLayoutTypeCode + "<br>");
			//Response.Write("CurrentColorCode= " + CurrentColorCode + "<br>");
			//Response.Write("CurrentPageSizeCode= " + CurrentPageSizeCode + "<br>");


			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds1 = new DataSet();
			DataView dv1;
			this.sqlDataAdapter1.Fill(ds1, "c2_lprior");
			dv1 = ds1.Tables["c2_lprior"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �`�N: �]�� lp_priorseq �O �ۤv��J�����, �G���i��J Row.Filter, �Y��J�N�]�䤣�즹�����, ���ܦ��s�W
			//       �G�n�N���F lp_priorseq �~, ��l�|���h����Ʈw�̬O�_��Ʀ�����!
			string rowfilter1 = " 1=1 ";
			rowfilter1 = rowfilter1 + " AND lp_bkcd=" + CurrentBookCode;
			rowfilter1 = rowfilter1 + " AND lp_ltpcd=" + CurrentLayoutTypeCode;
			rowfilter1 = rowfilter1 + " AND lp_clrcd=" + CurrentColorCode;
			rowfilter1 = rowfilter1 + " AND lp_pgscd=" + CurrentPageSizeCode;
			dv1.RowFilter = rowfilter1;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			// �Y��즹�����, �h���J���
			if(dv1.Count>0)
			{
				Label1.Text="�s�W����: ��ƭ���, �Эץ��A�s�W!";
			}
			else
			{
				// ��X ���w��m���ƪ��u������, �å������s�ʧ@ (���N���ᵧ�Ƥ����ǭȧ�s)
				GetNewlpSeq();

				// ���w�s�� LPSeq (NewPriorSeq=CurrentPriorSeq)
				string NewPriorSeq = CurrentPriorSeq;
				if(NewPriorSeq.Length < 2)
					NewPriorSeq = "0" + NewPriorSeq;
				//Response.Write("NewPriorSeq=" + NewPriorSeq + "<br>");

				// ���� �s�W�ʧ@
				//string strConn="server=isccom2;database=mrlpub;uid=webuser;pwd=db600";
				string strConn = System.Configuration.ConfigurationSettings.AppSettings["itridpa_mrlpub"].ToString();
				SqlConnection myConn=new SqlConnection(strConn);

				SqlDataAdapter cmd=new SqlDataAdapter("insert into c2_lprior(lp_bkcd, lp_priorseq, lp_ltpcd, lp_clrcd, lp_pgscd) values('" + CurrentBookCode + "', '" + NewPriorSeq + "', '" + CurrentLayoutTypeCode + "', '" + CurrentColorCode + "', '" + CurrentPageSizeCode + "')", myConn);
				//Response.Write("cmd= insert into c2_lprior(lp_bkcd, lp_priorseq, lp_ltpcd, lp_clrcd, lp_pgscd) values('" + CurrentBookCode + "', '" + NewPriorSeq + "', '" + CurrentLayoutTypeCode + "', '" + CurrentColorCode + "', '" + CurrentPageSizeCode + "')");

				//cmd.SelectCommand.Parameters.Add("@lp_lpid",SqlDbType.Int,4).Value = id;
				cmd.SelectCommand.Parameters.Add("@lp_bkcd",SqlDbType.Char,2).Value = CurrentBookCode;
				cmd.SelectCommand.Parameters.Add("@lp_priorseq",SqlDbType.Char,2).Value = NewPriorSeq;
				cmd.SelectCommand.Parameters.Add("@lp_ltpcd",SqlDbType.Char,2).Value = CurrentLayoutTypeCode;
				cmd.SelectCommand.Parameters.Add("@lp_clrcd",SqlDbType.Char,2).Value = CurrentColorCode;
				cmd.SelectCommand.Parameters.Add("@lp_pgscd",SqlDbType.Char,2).Value = CurrentPageSizeCode;

				DataSet ds = new DataSet();
				cmd.Fill(ds,"c2_lprior");

				Response.Redirect("adlprior.aspx");
			}
		}


		private void btnReturnHome_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("adlprior.aspx");
		}


		// �� ���� �s�W/���@/�R�� �e���Ө�, �I�s���e���� �S��B�z
		private void FromPub()
		{
			if(Context.Request.QueryString["function"].ToString().Trim() != "")
			{
				// �۷s�W������ƪ��B�z
				if(Context.Request.QueryString["function"].ToString().Trim() == "new")
				{
					// �H Javascript �� window.alert()  �ӧi���T��
					LiteralControl litAlert1 = new LiteralControl();
					litAlert1.Text = "<script language=javascript>alert(\"�䤣�즹�����u������, �Х�'�s�W�������u������'; �_�h���������L�k�s�W!!!\\n\\n �s�i��Ƥw�a�J���e��, �Х���J�u�����ǭ�, �M��� '�T�w�s�W' \\n�� �����k�W����'x' ������������!\\\n\\n�^�츨���e��, �ЦA���@�� '�x�s�s�W' ���s!\");</script>";
					Page.Controls.Add(litAlert1);
				}
				// �ۺ��@������ƪ��B�z
				else if(Context.Request.QueryString["function"].ToString().Trim() == "mod")
				{
					// �H Javascript �� window.alert()  �ӧi���T��
					LiteralControl litAlert2 = new LiteralControl();
					litAlert2.Text = "<script language=javascript>alert(\"�䤣�즹�����u������, �Х�'�s�W�������u������'; �_�h���������L�k�ק�!!!\\n\\n �s�i��Ƥw�a�J���e��, �Х���J�u�����ǭ�, �M��� '�T�w�s�W' \\n�� �����k�W����'x' ������������!\\n\\n�^�츨���e��, �ЦA���@�� '�x�s�ק�' ���s!\");</script>";
					Page.Controls.Add(litAlert2);
				}

				// ����@�Ϊ������ܼ�
				string strLtpcd = Context.Request.QueryString["ltpcd"].ToString();
				string strClrcd = Context.Request.QueryString["clrcd"].ToString();
				string strPgscd = Context.Request.QueryString["pgscd"].ToString();
				this.ddlLayoutTypeCode.Items.FindByValue(strLtpcd).Selected = true;
				this.ddlColorCode.Items.FindByValue(strClrcd).Selected = true;
				this.ddPageSizeCode.Items.FindByValue(strPgscd).Selected = true;

				// Disable �U�Ԧ���� - ���y���O
				this.ddlBookCode.Enabled = false;
			}
		}



		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter7 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter6 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.ddlBookCode.SelectedIndexChanged += new System.EventHandler(this.ddlBookCode_SelectedIndexChanged);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnReturnHome.Click += new System.EventHandler(this.btnReturnHome_Click);
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
			// sqlDataAdapter7
			//
			this.sqlDataAdapter7.SelectCommand = this.sqlSelectCommand7;
			this.sqlDataAdapter7.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lprior", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_priorseq", "lp_priorseq"),
																																																				   new System.Data.Common.DataColumnMapping("lp_clrcd", "lp_clrcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_ltpcd", "lp_ltpcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_pgscd", "lp_pgscd")})});
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
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lprior", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("lp_lpid", "lp_lpid"),
																																																				   new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_priorseq", "lp_priorseq"),
																																																				   new System.Data.Common.DataColumnMapping("lp_clrcd", "lp_clrcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_ltpcd", "lp_ltpcd"),
																																																				   new System.Data.Common.DataColumnMapping("lp_pgscd", "lp_pgscd")})});
			//
			// sqlDataAdapter6
			//
			this.sqlDataAdapter6.SelectCommand = this.sqlSelectCommand6;
			this.sqlDataAdapter6.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lprior", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("MaxSeq", "MaxSeq")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT lp_lpid, lp_bkcd, lp_priorseq, lp_clrcd, lp_ltpcd, lp_pgscd FROM dbo.c2_lp" +
				"rior";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = "SELECT clr_clrid, clr_clrcd, clr_nm FROM dbo.c2_clr";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand4
			//
			this.sqlSelectCommand4.CommandText = "SELECT ltp_ltpid, ltp_ltpcd, ltp_nm FROM dbo.c2_ltp";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand5
			//
			this.sqlSelectCommand5.CommandText = "SELECT pgs_pgsid, pgs_pgscd, pgs_nm FROM dbo.c2_pgsize";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand6
			//
			this.sqlSelectCommand6.CommandText = "SELECT lp_bkcd, MAX(lp_priorseq) AS MaxSeq FROM dbo.c2_lprior WHERE (lp_bkcd = @b" +
				"kcd) GROUP BY lp_bkcd";
			this.sqlSelectCommand6.Connection = this.sqlConnection1;
			this.sqlSelectCommand6.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "lp_bkcd"));
			//
			// sqlSelectCommand7
			//
			this.sqlSelectCommand7.CommandText = "SELECT lp_bkcd, lp_priorseq, lp_clrcd, lp_ltpcd, lp_pgscd FROM dbo.c2_lprior";
			this.sqlSelectCommand7.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2') AND (dbo.proj.proj_fgitri = ' ')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



	}
}
