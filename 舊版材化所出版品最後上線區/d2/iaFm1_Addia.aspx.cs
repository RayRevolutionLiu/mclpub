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
	/// Summary description for iaFm1_Addia.
	/// </summary>
	public class iaFm1_Addia : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblMemo2;
		protected System.Web.UI.WebControls.Button btnAddia;
		protected System.Web.UI.WebControls.Button btnShowFullCont;
		protected System.Web.UI.WebControls.Literal litWinOpen1;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.Label lblMfrCust;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Web.UI.WebControls.Button btnConfirmAmt;
		protected System.Web.UI.WebControls.Panel pnl1;
		protected System.Web.UI.WebControls.Label lblContPaidAmt;
		protected System.Web.UI.WebControls.Label lblContTotalAmt;
		protected System.Web.UI.WebControls.Label lblContRestAmt;
		protected System.Web.UI.WebControls.Panel pnl2;
		protected System.Web.UI.WebControls.Panel pnl3;
		protected System.Web.UI.WebControls.Label lblPickChgAmt;
		protected System.Web.UI.WebControls.Label lblContMessage;
		protected System.Web.UI.WebControls.Label lblPickMessage;
		protected System.Web.UI.WebControls.Label lblPickAdAmt;
		protected System.Web.UI.WebControls.Label lblPickTotalAmt;
		protected System.Web.UI.WebControls.Label lblNewContMessage;
		protected System.Web.UI.WebControls.Label lblNewContTotalAmt;
		protected System.Web.UI.WebControls.Label lblNewContPaidAmt;
		protected System.Web.UI.WebControls.Label lblNewContRestAmt;
		protected System.Data.SqlClient.SqlCommand sqlCommand3;
		protected System.Web.UI.WebControls.Button btnModifyCont;
		protected System.Web.UI.WebControls.Button btnModifyPub;
		protected System.Web.UI.WebControls.TextBox tbxbkcd;
		protected System.Web.UI.WebControls.TextBox tbxfgpubed;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.TextBox tbxIANo;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Label lblIMSeq;

		public iaFm1_Addia()
		{
			System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if(!Page.IsPostBack)
			{
				Response.Expires = 0;


				// ��X �X���εo�t���
				GetContIM();
			}
		}


		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		// ��X �X���εo�t���
		private void GetContIM()
		{
			this.lblMessage.Text = "";
			this.btnConfirmAmt.Visible = true;
			this.btnAddia.Visible = false;
			this.btnModifyCont.Visible = false;
			this.btnModifyPub.Visible = false;


			if(Context.Request.QueryString["contno"].Trim() != "" && Context.Request.QueryString["imseq"].Trim() != "")
			{
				// ��X�����ܼƪ���
				string strContNo = Context.Request.QueryString["contno"].Trim();
				string strIMSeq = Context.Request.QueryString["imseq"].Trim();
				string strIMName = "";
				this.lblContNo.Text = "�z�D�諸�X���ѽs���G" + strContNo;
				this.lblIMSeq.Text = "�o���t�Ӧ���H�G" + strIMSeq;


				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "c2_cont");
				DataView dv1 = ds1.Tables["c2_cont"].DefaultView;

				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
				// �] Row Filter: default �� 1=1 and ��L rowfilter ����
				string rowfilterstr1 = "1=1";
				rowfilterstr1 = rowfilterstr1 + " AND im_contno = '" + strContNo + "'";
				rowfilterstr1 = rowfilterstr1 + " AND im_imseq = '" + strIMSeq + "'";
				dv1.RowFilter = rowfilterstr1;

				// �ˬd�ÿ�X �̫� Row Filter �����G
				//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
				//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

				if(dv1.Count > 0)
				{
					strIMName = dv1[0]["im_nm"].ToString().Trim();
					this.lblContNo.Text = "�z�D�諸�X���O�G" + strContNo;
					this.lblIMSeq.Text = this.lblIMSeq.Text + "-" + strIMName;

					// ��ܦX��������� -- �t�t��/�Ȥ�, �X�����B���
					LoadCont();

					// ��ܨ丨����� - �|���}�ߵo����
					BindGrid1();
				}
			}
		}


		// ��ܦX��������� -- custno, �H�K���� '��ܦX���������' ���ǻ��ܼ�
		private void LoadCont()
		{
			string strContNo = Context.Request.QueryString["contno"].Trim();


			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_cont");
			DataView dv1 = ds1.Tables["c2_cont"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr1 = "1=1";
			rowfilterstr1 = rowfilterstr1 + " AND cont_contno = '" + strContNo + "'";
			dv1.RowFilter = rowfilterstr1;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			if(dv1.Count > 0)
			{
				// ��X���
				string strbkcd = dv1[0]["cont_bkcd"].ToString();
				string strfgpubed = dv1[0]["cont_fgpubed"].ToString().Trim();
				string strCustNo = dv1[0]["cont_custno"].ToString().Trim();
				string strCustName = dv1[0]["cust_nm"].ToString().Trim();
				string strMfrNo = dv1[0]["cont_mfrno"].ToString().Trim();
				string strMfrIName = dv1[0]["mfr_inm"].ToString().Trim();
				string intTotalAmt = dv1[0]["cont_totamt"].ToString().Trim();
				string intPaidAmt = dv1[0]["cont_paidamt"].ToString().Trim();
				string intRestAmt = dv1[0]["cont_restamt"].ToString().Trim();

				// ��ܸ��
				this.tbxbkcd.Text = strbkcd;
				this.tbxfgpubed.Text = strfgpubed;
				this.tbxCustNo.Text = strCustNo;
				this.lblMfrCust.Text = "(�t�ӦW�١G" + strMfrIName + " (" +strMfrNo + ")" + "�F�Ȥ�W�١G" + strCustName + ")";

				this.pnl1.Visible = true;
				this.pnl2.Visible = false;
				this.pnl3.Visible = false;
				this.lblContTotalAmt.Text = intTotalAmt;
				this.lblContPaidAmt.Text = intPaidAmt;
				this.lblContRestAmt.Text = intRestAmt;
			}
		}


		// ��ܨ丨����� - �|���}�ߵo����
		private void BindGrid1()
		{
			// ��X�����ܼƪ���
			string strContNo = Context.Request.QueryString["contno"].Trim();
			string strIMSeq = Context.Request.QueryString["imseq"].Trim();


			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c2_cont");
			DataView dv2 = ds2.Tables["c2_cont"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr2 = "1=1";
			rowfilterstr2 = rowfilterstr2 + " AND pub_contno = '" + strContNo + "'";
			rowfilterstr2 = rowfilterstr2 + " AND pub_imseq = '" + strIMSeq + "'";
			rowfilterstr2 = rowfilterstr2 + " AND pub_fginved = ' '";
			// �U�@�椧�Ƶ�: �]�Ϲj���ƩҪ��W�u��T, �G�¸�����Ƥp�󵥩� 200209 ��, �N����A�X�{�� �o������ �y�{��
			// �H�K�¸�T���ж}�ߵo�����, �y���x�Z.
			rowfilterstr2 = rowfilterstr2 + " AND pub_yyyymm>='200209'";
			dv2.RowFilter = rowfilterstr2;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

			if(dv2.Count > 0)
			{
				this.lblMessage.Text = "(���X���٦� " + dv2.Count + " �����}�ߪ��������.)";


				DataGrid1.DataSource = dv2;
				DataGrid1.DataBind();


				// �S�O��줧��X�榡�ഫ - �ܧ�ñ��������榡
				int i;
				for(i=0; i< DataGrid1.Items.Count ; i++)
				{
					// �Z�n�~��
					string YYYYMM = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();
					YYYYMM = YYYYMM.Substring(0, 4) + "/" + YYYYMM.Substring(4, 2);
					//Response.Write("StartDate= " + StartDate + "<br>");
					DataGrid1.Items[i].Cells[1].Text = YYYYMM;

					// �T�w�������O
					string fgfixpg = DataGrid1.Items[i].Cells[7].Text.ToString().Trim();
					//Response.Write("fgfixpg= " + fgfixpg + "<br>");
					if(fgfixpg == "0")
						DataGrid1.Items[i].Cells[7].Text = "�_";
					else
						DataGrid1.Items[i].Cells[7].Text = "<font color='Red'>�O</font>";

					// �Z�����O
					string drfttp = DataGrid1.Items[i].Cells[8].Text.ToString().Trim();
					//Response.Write("drfttp= " + drfttp + "<br>");
					switch(drfttp)
					{
						case "1":
							DataGrid1.Items[i].Cells[8].Text = "�½Z";

							// �M����L�Z����
							DataGrid1.Items[i].Cells[9].Text = "";
							DataGrid1.Items[i].Cells[10].Text = "";
							DataGrid1.Items[i].Cells[11].Text = "";
							DataGrid1.Items[i].Cells[12].Text = "";
							DataGrid1.Items[i].Cells[13].Text = "";
							DataGrid1.Items[i].Cells[14].Text = "";
							break;
						case "2":
							DataGrid1.Items[i].Cells[8].Text = "�s�Z";

							// ��Z���O
							string fggot1 = DataGrid1.Items[i].Cells[9].Text.ToString().Trim();
							//Response.Write("fggot1= " + fggot1 "<br>");
							if(fggot1 == "0")
								DataGrid1.Items[i].Cells[9].Text = "<font color='Red'>�_</font>";
							else
								DataGrid1.Items[i].Cells[9].Text = "�O";

							// �M����L�Z����
							DataGrid1.Items[i].Cells[11].Text = "";
							DataGrid1.Items[i].Cells[12].Text = "";
							DataGrid1.Items[i].Cells[13].Text = "";
							DataGrid1.Items[i].Cells[14].Text = "";
							DataGrid1.Items[i].Cells[15].Text = "";
							DataGrid1.Items[i].Cells[16].Text = "";
							DataGrid1.Items[i].Cells[17].Text = "";
							break;
						case "3":
							DataGrid1.Items[i].Cells[8].Text = "��Z";

							// ���y���O
							string chgbkcd = DataGrid1.Items[i].Cells[11].Text.ToString().Trim();
							//Response.Write("chgbkcd= " + chgbkcd "<br>");
							if(chgbkcd == "01")
								DataGrid1.Items[i].Cells[11].Text = "�u�����x";
							else if(chgbkcd == "02")
								DataGrid1.Items[i].Cells[11].Text = "�q�����x";

							// ��Z���O
							string fggot2 = DataGrid1.Items[i].Cells[9].Text.ToString().Trim();
							//Response.Write("fggot2= " + fggot2 "<br>");
							if(fggot2 == "0")
								DataGrid1.Items[i].Cells[9].Text = "<font color='Red'>�_</font>";
							else
								DataGrid1.Items[i].Cells[9].Text = "�O";

							// ��Z���X�����O
							string fgrechg = DataGrid1.Items[i].Cells[14].Text.ToString().Trim();
							//Response.Write("fgrechg= " + fgrechg "<br>");
							if(fgrechg == "0")
								DataGrid1.Items[i].Cells[14].Text = "�_";
							else
								DataGrid1.Items[i].Cells[14].Text = "<font color='Red'>�O</font>";

							// �M����L�Z����
							DataGrid1.Items[i].Cells[10].Text = "";
							DataGrid1.Items[i].Cells[15].Text = "";
							DataGrid1.Items[i].Cells[16].Text = "";
							DataGrid1.Items[i].Cells[17].Text = "";
							break;
						default:
							DataGrid1.Items[i].Cells[8].Text = "�½Z";
							break;
					}
				// ���� for loop
				}

			// ���� if(dv2.Count > 0)
			}
			else
			{
				this.btnAddia.Visible = false;
				this.lblMemo2.Text = "�L���}�ߵo���}�߳檺�������, �� '��^�e��' ���s�ާ@! <A HREF='iaFm1_Add.aspx' Target='_self'>(�����B ��^�e��)</A>";
			}
		}


		// �T�{���B ���s���B�z
		private void btnConfirmAmt_Click(object sender, System.EventArgs e)
		{
			// ��� Panel ���
			this.pnl1.Visible = true;
			this.pnl2.Visible = true;
			this.pnl3.Visible = true;

			// ��X �w�D�� pnl2 �� �N��s pnl3 �����
			int intPickTotalAdAmt = 0, intPickTotalChgAmt = 0, intPickTotalAmt = 0;
			int intContTotalAmt = 0, intContPaidAmt = 0, intContRestAmt = 0;
			int intNewContTotalAmt = 0, intNewContPaidAmt = 0, intNewContRestAmt = 0;
			for(int i=0; i< DataGrid1.Items.Count ; i++)
			{
				bool strSelect = ((CheckBox)DataGrid1.Items[i].Cells[0].FindControl("cbxSelect")).Checked;


				// ��X�Q�D���
				if(strSelect == true)
				{
					// ��X�U���� �s�i���B, ���Z���B
					int intAdAmt = Convert.ToInt32(DataGrid1.Items[i].Cells[18].Text.ToString());
					int intChgAmt = Convert.ToInt32(DataGrid1.Items[i].Cells[19].Text.ToString());
					//Response.Write("intAdAmt= " + intAdAmt + ", ");
					//Response.Write("intChgAmt= " + intChgAmt + "<br>");

					// ��X�w�D����B��� �� �`�s�i���B, �`���Z���B, �p�p
					intPickTotalAdAmt = intPickTotalAdAmt + intAdAmt;
					intPickTotalChgAmt = intPickTotalChgAmt + intChgAmt;
					intPickTotalAmt = intPickTotalAdAmt + intPickTotalChgAmt;
					this.lblPickAdAmt.Text = Convert.ToString(intPickTotalAdAmt);
					this.lblPickChgAmt.Text = Convert.ToString(intPickTotalChgAmt);
					this.lblPickTotalAmt.Text = Convert.ToString(intPickTotalAmt);
					//Response.Write("intPickTotalAdAmt= " + intPickTotalAdAmt + ", ");
					//Response.Write("intPickTotalChgAmt= " + intPickTotalChgAmt + "<br>");
					//Response.Write("intPickTotalAmt= " + intPickTotalAmt + "<br>");


					// ��X�X�����B��� �� �X�����B, �wú���B, �Ѿl���B
					intContTotalAmt = Convert.ToInt32(this.lblContTotalAmt.Text.ToString().Trim());
					intContPaidAmt = Convert.ToInt32(this.lblContPaidAmt.Text.ToString().Trim());
					intContRestAmt = Convert.ToInt32(this.lblContRestAmt.Text.ToString().Trim());
					//Response.Write("intContTotalAmt= " + intContTotalAmt + "<br>");
					//Response.Write("intContPaidAmt= " + intContPaidAmt + "<br>");
					//Response.Write("intContRestAmt= " + intContRestAmt + "<br>");


					// ��X�N��s���X�����B��� �� �X�����B, �wú���B, �Ѿl���B
					intNewContTotalAmt = intContTotalAmt;
					intNewContPaidAmt = intContPaidAmt + intPickTotalAmt;
					intNewContRestAmt = intNewContTotalAmt - intNewContPaidAmt;
					//Response.Write("intNewContTotalAmt= " + intNewContTotalAmt + "<br>");
					//Response.Write("intNewContPaidAmt= " + intNewContPaidAmt + "<br>");
					//Response.Write("intNewContRestAmt= " + intNewContRestAmt + "<br>");
					this.lblNewContTotalAmt.Text = Convert.ToString(intNewContTotalAmt);
					this.lblNewContPaidAmt.Text = Convert.ToString(intNewContPaidAmt);
					this.lblNewContRestAmt.Text = Convert.ToString(intNewContRestAmt);
				}
			}


			// �ˬd �N��s���X�� '�Ѿl���B' & '�wú���B' ��ƬO�_�X�z
			if(intNewContRestAmt > 0 || intNewContPaidAmt <= intContTotalAmt)
			{
				this.btnConfirmAmt.Visible = false;
				this.btnAddia.Visible = true;

				this.btnModifyCont.Visible = false;
				this.btnModifyPub.Visible = false;
			}
			else if(intNewContRestAmt < 0 || intNewContPaidAmt > intContTotalAmt)
			{
				this.btnAddia.Visible = false;

				// �H Javascript �� window.close() �ӧi���T��
				LiteralControl litAlert1 = new LiteralControl();
				litAlert1.Text = "<script language=javascript>alert(\"�N��s���X�� '�Ѿl���B' & '�wú���B' ��Ƥ��X�z,\\n �L�k���͵o���}�߳�, �Х��ץ� �X���θ������!!!\");</script>";
				Page.Controls.Add(litAlert1);

				this.btnModifyCont.Visible = true;
				this.btnModifyPub.Visible = true;
			}
		}


		// ���͵o���}�߳� ���s���B�z
		private void btnAddia_Click(object sender, System.EventArgs e)
		{
			// ���D�X�Q�Ŀ諸 ContNo & IMseq
			// ���� �s�W ia & iad
			CreateIA();


			// Refresh DataList1
			BindGrid1();
		}


		// ��ܦX��������� ���s���B�z
		private void btnShowFullCont_Click(object sender, System.EventArgs e)
		{
			// �}�Ҥp����
			string strbuf = "ContPubFm_show.aspx?custno=" + this.tbxCustNo.Text.ToString().Trim() + "&old_contno=" + Context.Request.QueryString["contno"].Trim();
			//Response.Write(strbuf);

			// �H Javascript �� window.open()  �ӧi���T��
			litWinOpen1.Text = "<script language=\"javascript\">window.open(\"" + strbuf + "\", '', 'width=720, height=450, left=20, top=20, scrollbars=yes');</script>";
		}


		// ���͵o���}�߳� ���s���B�z
		private void CreateIA()
		{
			string strSyscd = "C2";
			string strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			string strIMSeq = Context.Request.QueryString["imseq"].ToString().Trim();


			// step1 - ��s�Q�D�︨���� �o���}�߳���O (�� ' ' �אּ 'v')
			int intTotalAdAmt = 0, intTotalChgAmt = 0;
			for(int i=0; i< DataGrid1.Items.Count ; i++)
			{
				// ��X �C�@���������
				bool strSelect = ((CheckBox)DataGrid1.Items[i].Cells[0].FindControl("cbxSelect")).Checked;
				string strYYYYMM = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();
				strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
				string strPubSeq = DataGrid1.Items[i].Cells[2].Text.ToString();
				int intAdAmt = Convert.ToInt32(DataGrid1.Items[i].Cells[18].Text.ToString());
				int intChgAmt = Convert.ToInt32(DataGrid1.Items[i].Cells[19].Text.ToString());
				//Response.Write("i= " + i + ", ");
				//Response.Write("strSyscd= " + strSyscd + ", ");
				//Response.Write("strContNo= " + strContNo + ", ");
				//Response.Write("strSelect= " + strSelect + ", ");
				//Response.Write("strYYYYMM= " + strYYYYMM + ", ");
				//Response.Write("strPubSeq= " + strPubSeq + "");
				//Response.Write("strIMSeq= " + strIMSeq + ", ");
				//Response.Write("intAdAmt= " + intAdAmt + ", ");
				//Response.Write("intChgAmt= " + intChgAmt + "<br>");

				// ��X�Q�D���
				if(strSelect == true)
				{
					intTotalAdAmt = intTotalAdAmt + intAdAmt;
					intTotalChgAmt = intTotalChgAmt + intChgAmt;
					//this.lblAmtCount.Text = "���B �p�p�G$" + intTotalAdAmt + "��$" + intTotalChgAmt;
					//Response.Write("i= " + i + ", ");
					//Response.Write("strSyscd= " + strSyscd + ", ");
					//Response.Write("strContNo= " + strContNo + ", ");
					//Response.Write("strYYYYMM= " + strYYYYMM + ", ");
					//Response.Write("strPubSeq= " + strPubSeq + ", ");
					//Response.Write("strIMSeq= " + strIMSeq + "<br>");
					//Response.Write("intTotalAdAmt= " + intTotalAdAmt + ", ");
					//Response.Write("intTotalChgAmt= " + intTotalChgAmt + "<br>");


					// ��s�Q�D�諸������Ƥ� pub_fginved �q ' ' �ܬ� 'v'
					// ���� �N�ȶ�J sqlCommand1.Parameters ��, �H���� ��s
					//Response.Write(this.sqlCommand1.CommandText);
					this.sqlCommand1.Parameters["@syscd"].Value = strSyscd;
					this.sqlCommand1.Parameters["@contno"].Value = strContNo;
					this.sqlCommand1.Parameters["@yyyymm"].Value = strYYYYMM;
					this.sqlCommand1.Parameters["@pubseq"].Value = strPubSeq;

					// �T�{���� sqlCommand1 ���\
					bool ResultFlag1 = false;
					this.sqlCommand1.Connection.Open();
					try
					{
						this.sqlCommand1.ExecuteNonQuery();
						ResultFlag1 = true;
					}
					catch(System.Data.SqlClient.SqlException ex1)
					{
						Response.Write(ex1.Message + "<br>");
						ResultFlag1 = false;
					}
					finally
					{
						this.sqlCommand1.Connection.Close();
					}
					//Response.Write("ResultFlag1= " + ResultFlag1 + "<br>");

					// ��X���浲�G
					if (ResultFlag1)
					{
						//Response.Write("��s�����ɪ��o���}�߳���O ���\!<br>");
					}
					else
					{
						//Response.Write("��s�����ɪ��o���}�߳���O ����!<br>");
					}
				// ���� if(strSelect == true)
				}
			// ���� for loop
			}



			// step2 - ���� ia & iad -- �I�s sp_c2_add_1_ia_1
			//Response.Write(this.sqlCommand2.CommandText);
			this.sqlCommand2.Parameters["@syscd"].Value = strSyscd;
			this.sqlCommand2.Parameters["@contno"].Value = strContNo;
			this.sqlCommand2.Parameters["@imseq"].Value = strIMSeq;

			// �T�{���� sqlCommand2 ���\
			bool ResultFlag2 = false;
			this.sqlCommand2.Connection.Open();
			try
			{
				this.sqlCommand2.ExecuteNonQuery();
				ResultFlag2 = true;
			}
			catch(System.Data.SqlClient.SqlException ex2)
			{
				Response.Write(ex2.Message + "<br>");
				ResultFlag2 = false;
			}
			finally
			{
				this.sqlCommand2.Connection.Close();
			}
			//Response.Write("ResultFlag2= " + ResultFlag2 + "<br>");

			// ��X���浲�G
			if (ResultFlag2)
			{
				//Response.Write("<font size=2>�s�W�o���}�߳榨�\!</font><br>");

				// �H Javascript �� window.close() �ӧi���T��
				LiteralControl litAlert1 = new LiteralControl();
				litAlert1.Text = "<script language=javascript>alert(\"�X���ѽs��: " + strContNo + " ���o���}�߳� �s�W���\\");</script>";
				Page.Controls.Add(litAlert1);
			}
			else
			{
				//Response.Write("<font size=2>�s�W�o���}�߳楢��!</font><br>");

				// �H Javascript �� window.close() �ӧi���T��
				LiteralControl litAlert1 = new LiteralControl();
				litAlert1.Text = "<script language=javascript>alert(\"�X���ѽs��: " + strContNo + " ���o���}�߳� �s�W����\");</script>";
				Page.Controls.Add(litAlert1);
			}



			// step3 - ��s �X����Ƥ� �wú���B & �Ѿl���B ����
			//Response.Write(this.sqlCommand3.CommandText);
			string strNewContPaidAmt = this.lblNewContPaidAmt.Text.ToString().Trim();
			string strNewContRestAmt = this.lblNewContRestAmt.Text.ToString().Trim();
			this.sqlCommand3.Parameters["@paidamt"].Value = strNewContPaidAmt;
			this.sqlCommand3.Parameters["@restamt"].Value = strNewContRestAmt;
			this.sqlCommand3.Parameters["@contno"].Value = strContNo;

			// �T�{���� sqlCommand3 ���\
			bool ResultFlag3 = false;
			this.sqlCommand3.Connection.Open();
			try
			{
				this.sqlCommand3.ExecuteNonQuery();
				ResultFlag3 = true;
			}
			catch(System.Data.SqlClient.SqlException ex3)
			{
				Response.Write(ex3.Message + "<br>");
				ResultFlag3 = false;
			}
			finally
			{
				this.sqlCommand3.Connection.Close();
			}
			//Response.Write("ResultFlag3= " + ResultFlag3 + "<br>");

			// ��X���浲�G
			if (ResultFlag3)
			{
				//Response.Write("<font size=2>��s�X�����wú���B&�Ѿl���B���\!</font><br>");

				// �H Javascript �� window.close() �ӧi���T��
				LiteralControl litAlert2 = new LiteralControl();
				litAlert2.Text = "<script language=javascript>alert(\"�X���ѽs��: " + strContNo + " ���wú&�Ѿl���B ��s���\\");</script>";
				Page.Controls.Add(litAlert2);
			}
			else
			{
				//Response.Write("<font size=2>��s�X�����wú���B&�Ѿl���B����!</font><br>");

				// �H Javascript �� window.close() �ӧi���T��
				LiteralControl litAlert2 = new LiteralControl();
				litAlert2.Text = "<script language=javascript>alert(\"�X���ѽs��: " + strContNo + " ���wú&�Ѿl���B ��s���\����\");</script>";
				Page.Controls.Add(litAlert2);
			}


			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "ia");
			DataView dv3 = ds3.Tables["ia"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr3 = "1=1";
			dv3.RowFilter = rowfilterstr3;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

			// �Y�j�M���G�� "�䤣��" ���B�z
			if (dv3.Count > 0)
			{
				string strMaxIANo = dv3[0]["MaxIANno"].ToString().Trim();
				this.tbxIANo.Text = strMaxIANo;
				//Response.Write("strMaxIANo= " + strMaxIANo + "<br>");

				// ��}�B�z - �o���}�߳��ˮ֪� - �@���I��
				Response.Redirect("iaFm1_chklist.aspx?contno=" + strContNo + "&imseq=" + strIMSeq + "&iano=" + strMaxIANo);
			}
		}


		// DataGrid1 �����B�z
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid1();
		}


		// �ק�X���� ���s���B�z
		private void btnModifyCont_Click(object sender, System.EventArgs e)
		{
			string strCustNo = this.tbxCustNo.Text.ToString().Trim();
			string strContNo = Context.Request.QueryString["contno"].ToString().Trim();

			// �}�Ҥp����
			string strbuf = "ContFm_modify.aspx?custno=" + strCustNo + "&contno=" + strContNo;
			litWinOpen1.Text = "<script language=\"javascript\">window.open(\"" + strbuf + "\", '', 'width=720, height=450, left=20, top=20, scrollbars=yes');</script>";
		}


		// �ק︨�� ���s���B�z
		private void btnModifyPub_Click(object sender, System.EventArgs e)
		{
			string strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			string strBkcd = this.tbxbkcd.Text.ToString();
			string strfgPubed = this.tbxfgpubed.Text.ToString().Trim();

			// �}�Ҥp����
			string strbuf = "PubFm.aspx?contno=" + strContNo + "&bkcd=" + strBkcd + "&fgnew=" + strfgPubed;
			litWinOpen1.Text = "<script language=\"javascript\">window.open(\"" + strbuf + "\", '', 'width=720, height=450, left=20, top=20, scrollbars=yes');</script>";
		}


		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.btnShowFullCont.Click += new System.EventHandler(this.btnShowFullCont_Click);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.btnConfirmAmt.Click += new System.EventHandler(this.btnConfirmAmt_Click);
			this.btnAddia.Click += new System.EventHandler(this.btnAddia_Click);
			this.btnModifyCont.Click += new System.EventHandler(this.btnModifyCont_Click);
			this.btnModifyPub.Click += new System.EventHandler(this.btnModifyPub_Click);
			//
			// sqlCommand3
			//
			this.sqlCommand3.CommandText = "UPDATE c2_cont SET cont_paidamt = @paidamt, cont_restamt = @restamt WHERE (cont_s" +
				"yscd = \'C2\') AND (cont_contno = @contno)";
			this.sqlCommand3.Connection = this.sqlConnection1;
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@paidamt", System.Data.SqlDbType.Int, 4, "cont_paidamt"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@restamt", System.Data.SqlDbType.Int, 4, "cont_restamt"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, "cont_contno"));
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			//
			// sqlCommand2
			//
			this.sqlCommand2.CommandText = "dbo.sp_c2_add_1_ia_1";
			this.sqlCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			//
			// sqlCommand1
			//
			this.sqlCommand1.CommandText = "UPDATE c2_pub SET pub_fginved = \'v\' WHERE (pub_fginved = \' \') AND (pub_syscd = @s" +
				"yscd) AND (pub_contno = @contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @p" +
				"ubseq)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, "pub_syscd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, "pub_contno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.Char, 6, "pub_yyyymm"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubseq", System.Data.SqlDbType.Char, 2, "pub_pubseq"));
			//
			// sqlDataAdapter2
			//
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																			   new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																			   new System.Data.Common.DataColumnMapping("pub_pgno", "pub_pgno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																			   new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																			   new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																			   new System.Data.Common.DataColumnMapping("pub_fgfixpg", "pub_fgfixpg"),
																																																			   new System.Data.Common.DataColumnMapping("pub_remark", "pub_remark"),
																																																			   new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																			   new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																			   new System.Data.Common.DataColumnMapping("pub_njtpcd", "pub_njtpcd"),
																																																			   new System.Data.Common.DataColumnMapping("pub_origbkcd", "pub_origbkcd"),
																																																			   new System.Data.Common.DataColumnMapping("pub_origjno", "pub_origjno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_origjbkno", "pub_origjbkno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_chgbkcd", "pub_chgbkcd"),
																																																			   new System.Data.Common.DataColumnMapping("pub_chgjno", "pub_chgjno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_chgjbkno", "pub_chgjbkno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																			   new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																			   new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																			   new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																			   new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																			   new System.Data.Common.DataColumnMapping("njtp_nm", "njtp_nm"),
																																																			   new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("pub_modempno", "pub_modempno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_imseq", "pub_imseq"),
																																																			   new System.Data.Common.DataColumnMapping("pub_fginved", "pub_fginved"),
																																																			   new System.Data.Common.DataColumnMapping("pub_adamt", "pub_adamt"),
																																																			   new System.Data.Common.DataColumnMapping("pub_chgamt", "pub_chgamt"),
																																																			   new System.Data.Common.DataColumnMapping("pub_projno", "pub_projno"),
																																																			   new System.Data.Common.DataColumnMapping("pub_costctr", "pub_costctr"),
																																																			   new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			   new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																			   new System.Data.Common.DataColumnMapping("Expr1", "Expr1"),
																																																			   new System.Data.Common.DataColumnMapping("Expr2", "Expr2"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("Expr3", "Expr3"),
																																																			   new System.Data.Common.DataColumnMapping("Expr4", "Expr4"),
																																																			   new System.Data.Common.DataColumnMapping("Expr5", "Expr5"),
																																																			   new System.Data.Common.DataColumnMapping("Expr6", "Expr6"),
																																																			   new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			   new System.Data.Common.DataColumnMapping("clr_clrcd", "clr_clrcd"),
																																																			   new System.Data.Common.DataColumnMapping("ltp_ltpcd", "ltp_ltpcd"),
																																																			   new System.Data.Common.DataColumnMapping("njtp_njtpcd", "njtp_njtpcd"),
																																																			   new System.Data.Common.DataColumnMapping("pgs_pgscd", "pgs_pgscd"),
																																																			   new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																			   new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno")})});
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_pubseq, dbo.c" +
				"2_pub.pub_pgno AS pub_pgno, dbo.c2_pub.pub_ltpcd, dbo.c2_pub.pub_clrcd, dbo.c2_p" +
				"ub.pub_pgscd, dbo.c2_pub.pub_fgfixpg, dbo.c2_pub.pub_remark, dbo.c2_pub.pub_draf" +
				"ttp, dbo.c2_pub.pub_fggot, dbo.c2_pub.pub_njtpcd, dbo.c2_pub.pub_origbkcd, dbo.c" +
				"2_pub.pub_origjno, dbo.c2_pub.pub_origjbkno, dbo.c2_pub.pub_chgbkcd, dbo.c2_pub." +
				"pub_chgjno, dbo.c2_pub.pub_chgjbkno, dbo.c2_pub.pub_fgrechg, dbo.c2_pub.pub_bkcd" +
				", RTRIM(dbo.c2_ltp.ltp_nm) AS ltp_nm, RTRIM(dbo.c2_clr.clr_nm) AS clr_nm, RTRIM(" +
				"dbo.c2_pgsize.pgs_nm) AS pgs_nm, RTRIM(dbo.c2_njtp.njtp_nm) AS njtp_nm, RTRIM(db" +
				"o.book.bk_nm) AS bk_nm, RTRIM(dbo.srspn.srspn_cname) AS srspn_cname, dbo.c2_pub." +
				"pub_modempno, dbo.c2_pub.pub_imseq, dbo.c2_pub.pub_fginved, dbo.c2_pub.pub_adamt" +
				", dbo.c2_pub.pub_chgamt, dbo.c2_pub.pub_projno, dbo.c2_pub.pub_costctr, dbo.c2_p" +
				"ub.pub_syscd, dbo.mfr.mfr_inm, dbo.cust.cust_nm, dbo.book.bk_nm AS Expr1, dbo.sr" +
				"spn.srspn_cname AS Expr2, dbo.srspn.srspn_tel, dbo.c2_ltp.ltp_nm AS Expr3, dbo.c" +
				"2_clr.clr_nm AS Expr4, dbo.c2_pgsize.pgs_nm AS Expr5, dbo.c2_njtp.njtp_nm AS Exp" +
				"r6, dbo.book.bk_bkcd, dbo.c2_clr.clr_clrcd, dbo.c2_ltp.ltp_ltpcd, dbo.c2_njtp.nj" +
				"tp_njtpcd, dbo.c2_pgsize.pgs_pgscd, dbo.cust.cust_custno, dbo.mfr.mfr_mfrno, dbo" +
				".srspn.srspn_empno FROM dbo.srspn RIGHT OUTER JOIN dbo.c2_ltp RIGHT OUTER JOIN d" +
				"bo.c2_pub INNER JOIN dbo.c2_cont ON dbo.c2_pub.pub_contno = dbo.c2_cont.cont_con" +
				"tno AND dbo.c2_pub.pub_syscd = dbo.c2_cont.cont_syscd INNER JOIN dbo.mfr ON dbo." +
				"c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.cust ON dbo.c2_cont.cont_c" +
				"ustno = dbo.cust.cust_custno LEFT OUTER JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd " +
				"= dbo.c2_clr.clr_clrcd LEFT OUTER JOIN dbo.c2_pgsize ON dbo.c2_pub.pub_pgscd = d" +
				"bo.c2_pgsize.pgs_pgscd ON dbo.c2_ltp.ltp_ltpcd = dbo.c2_pub.pub_ltpcd LEFT OUTER" +
				" JOIN dbo.c2_njtp ON dbo.c2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd LEFT OUTER " +
				"JOIN dbo.book ON dbo.c2_pub.pub_origbkcd = dbo.book.bk_bkcd ON dbo.srspn.srspn_e" +
				"mpno = dbo.c2_cont.cont_empno WHERE (dbo.c2_pub.pub_fginved = \' \') AND (dbo.c2_c" +
				"ont.cont_fgpubed = \'1\') AND (dbo.c2_cont.cont_fgpayonce = \'1\') AND (dbo.c2_cont." +
				"cont_fgcancel = \'0\') AND (dbo.c2_cont.cont_fgtemp = \'0\') AND (dbo.c2_pub.pub_ada" +
				"mt + dbo.c2_pub.pub_chgamt > 0) ORDER BY dbo.c2_pub.pub_contno, dbo.c2_pub.pub_y" +
				"yyymm, dbo.c2_pub.pub_pubseq";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_oldcontno", "cont_oldcontno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_moddate", "cont_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("cont_modempno", "cont_modempno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_credate", "cont_credate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				 new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				 new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				 new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_conttp, " +
				"dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_empno, dbo.c2" +
				"_cont.cont_mfrno, dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_sdate, dbo.c2_cont.con" +
				"t_edate, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_custno, RTRIM(dbo.cust.cust" +
				"_nm) AS cust_nm, dbo.cust.cust_tel, dbo.c2_cont.cont_totamt, dbo.c2_cont.cont_pa" +
				"idamt, dbo.c2_cont.cont_restamt, dbo.c2_cont.cont_oldcontno, dbo.c2_cont.cont_mo" +
				"ddate, dbo.c2_cont.cont_fgpayonce, dbo.c2_cont.cont_modempno, dbo.c2_cont.cont_f" +
				"gcancel, dbo.c2_cont.cont_credate, dbo.c2_cont.cont_fgtemp, dbo.c2_cont.cont_fgp" +
				"ubed, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, dbo.invmfr.im_imseq, RTRIM(dbo.invmfr.i" +
				"m_nm) AS im_nm, dbo.cust.cust_custno, dbo.invmfr.im_contno, dbo.invmfr.im_syscd," +
				" dbo.mfr.mfr_mfrno, RTRIM(dbo.book.bk_nm) AS bk_nm, RTRIM(dbo.srspn.srspn_cname)" +
				" AS srspn_cname, dbo.book.bk_bkcd, dbo.srspn.srspn_empno, dbo.c2_cont.cont_totjt" +
				"m, dbo.c2_cont.cont_tottm FROM dbo.c2_cont INNER JOIN dbo.invmfr ON dbo.c2_cont." +
				"cont_syscd = dbo.invmfr.im_syscd AND dbo.c2_cont.cont_contno = dbo.invmfr.im_con" +
				"tno INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER " +
				"JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.book O" +
				"N dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.srspn ON dbo.c2_cont.c" +
				"ont_empno = dbo.srspn.srspn_empno LEFT OUTER JOIN dbo.c2_pub ON dbo.c2_cont.cont" +
				"_syscd = dbo.c2_pub.pub_syscd AND dbo.c2_cont.cont_contno = dbo.c2_pub.pub_contn" +
				"o WHERE (dbo.c2_cont.cont_fgpayonce = \'1\') AND (dbo.c2_cont.cont_fgcancel = \'0\')" +
				" AND (dbo.c2_cont.cont_fgtemp = \'0\') AND (dbo.c2_cont.cont_fgpubed = \'1\') AND (d" +
				"bo.c2_pub.pub_fginved = \' \')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("MaxIANno", "MaxIANno")})});
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = "SELECT MAX(ia_iano) AS MaxIANno FROM dbo.ia WHERE (ia_syscd = \'C2\')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion




	}
}
