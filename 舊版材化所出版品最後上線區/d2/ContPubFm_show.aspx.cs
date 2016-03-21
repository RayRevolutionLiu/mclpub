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
	/// Summary description for ContPubFm_show.
	/// </summary>
	public class ContPubFm_show : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblMfrIName;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblMfrRespName;
		protected System.Web.UI.WebControls.Label lblMfrRespJobTitle;
		protected System.Web.UI.WebControls.Label lblMfrTel;
		protected System.Web.UI.WebControls.Label lblMfrFax;
		protected System.Web.UI.WebControls.Label lblCustName;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Web.UI.WebControls.Label lblfgClosedMessage;
		protected System.Web.UI.WebControls.TextBox tbxSignDate;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.DropDownList ddlContType;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Web.UI.WebControls.TextBox tbxStartDate;
		protected System.Web.UI.WebControls.TextBox tbxEndDate;
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Web.UI.WebControls.RadioButtonList rblfgPayOnce;
		protected System.Web.UI.WebControls.RadioButtonList rblfgClosed;
		protected System.Web.UI.WebControls.DropDownList ddlModEmpNo;
		protected System.Web.UI.WebControls.RadioButtonList rblfgCancel;
		protected System.Web.UI.WebControls.Label lblOldContNo;
		protected System.Web.UI.WebControls.Label lblOldContMessage;
		protected System.Web.UI.WebControls.Label lblCreateDate;
		protected System.Web.UI.WebControls.Label lblModifyDate;
		protected System.Web.UI.WebControls.TextBox tbxTotalJTime;
		protected System.Web.UI.WebControls.TextBox tbxTotalTime;
		protected System.Web.UI.WebControls.TextBox tbxTotalAmt;
		protected System.Web.UI.WebControls.TextBox tbxMadeJTime;
		protected System.Web.UI.WebControls.TextBox tbxPubTime;
		protected System.Web.UI.WebControls.TextBox tbxPaidAmt;
		protected System.Web.UI.WebControls.TextBox tbxRestJTime;
		protected System.Web.UI.WebControls.TextBox tbxRestTime;
		protected System.Web.UI.WebControls.TextBox tbxRestAmt;
		protected System.Web.UI.WebControls.TextBox tbxChangeJTime;
		protected System.Web.UI.WebControls.TextBox tbxFreeTime;
		protected System.Web.UI.WebControls.TextBox tbxADAmt;
		protected System.Web.UI.WebControls.TextBox tbxDiscount;
		protected System.Web.UI.WebControls.TextBox tbxFreeBookCount;
		protected System.Web.UI.WebControls.TextBox tbxColorTime;
		protected System.Web.UI.WebControls.TextBox tbxGetColorTime;
		protected System.Web.UI.WebControls.TextBox tbxMenoTime;
		protected System.Web.UI.WebControls.TextBox tbxPubAdAmt;
		protected System.Web.UI.WebControls.TextBox tbxPubChangeAmt;
		protected System.Web.UI.WebControls.TextBox tbxRestClrtm;
		protected System.Web.UI.WebControls.TextBox tbxRestGetClrtm;
		protected System.Web.UI.WebControls.TextBox tbxRestMenotm;
		protected System.Web.UI.WebControls.TextBox tbxAuName;
		protected System.Web.UI.WebControls.TextBox tbxAuTel;
		protected System.Web.UI.WebControls.TextBox tbxAuFax;
		protected System.Web.UI.WebControls.TextBox tbxAuCell;
		protected System.Web.UI.WebControls.TextBox tbxAuEmail;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.DataGrid Datagrid2;
		protected System.Web.UI.WebControls.Label lblORPunCnt;
		protected System.Web.UI.WebControls.Label lblORUnPubCnt;
		protected System.Web.UI.WebControls.DataList DataList2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter6;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter7;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter8;
		protected System.Web.UI.WebControls.Label lblPubMessage;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand8;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.HtmlControls.HtmlTextArea tarContRemark;

		public ContPubFm_show()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;


			if(!Page.IsPostBack)
			{
				Response.Expires=0;

				// ���éҦ��� ��J���, �����\�ק�
				DisabledAll();


				// ��X �t�ӤΫȤ��� �Ϥ����, �ǥѫe�@�����ǨӪ��ܼƭȦr�� custno
				GetMfrCust();

				// ��X������l��, �p�ʺA�U�Ԧ���� (��DB��), �t�Τ���� - �D�n�� �X���Ѱ򥻸�ư�
				InitialData();

				// ��� �X���ѽs��
				if(Context.Request.QueryString["old_contno"].ToString().Trim() != "" || Context.Request.QueryString["old_contno"].ToString().Trim() != null)
				{
					this.lblContNo.Text = Context.Request.QueryString["old_contno"].ToString().Trim();
				}

				// ���J�¦��X�����: �X���ѲӸ` & �s�i�p���H ����l�w�]��
				LoadOldCont();

				// ���J �o���t�Ӧ���H & ���x����H �����v��� (�̾� old_contno)
				BindGrid1();
				BindGrid2();

				// ���J�������
				BindList2();
			}
		}


		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		// ���éҦ��� tbx��J���, �����\�ק� (lbl ��줣�� disable; �_�h��ܮ�, ��r�|���M��)
		private void DisabledAll()
		{
			// �X���Ѱ򥻸�� ��
			this.tbxSignDate.Enabled = false;
			this.ddlContType.Enabled = false;
			this.ddlBookCode.Enabled = false;
			this.tbxStartDate.Enabled = false;
			this.tbxEndDate.Enabled = false;
			this.ddlEmpNo.Enabled = false;
			this.rblfgPayOnce.Enabled = false;
			this.rblfgClosed.Enabled = false;
			this.ddlModEmpNo.Enabled = false;
			this.rblfgCancel.Enabled = false;
			//this.lblOldContNo.Enabled = false;
			//this.lblCreateDate.Enabled = false;
			//this.lblModifyDate.Enabled = false;

			// �X���ѲӸ` ��
			this.tbxTotalJTime.Enabled = false;
			this.tbxMadeJTime.Enabled = false;
			this.tbxRestJTime.Enabled = false;
			this.tbxTotalTime.Enabled = false;
			this.tbxPubTime.Enabled = false;
			this.tbxRestTime.Enabled = false;
			this.tbxTotalAmt.Enabled = false;
			this.tbxPaidAmt.Enabled = false;
			this.tbxRestAmt.Enabled = false;
			this.tbxChangeJTime.Enabled = false;
			this.tbxFreeTime.Enabled = false;
			this.tbxADAmt.Enabled = false;
			this.tbxDiscount.Enabled = false;
			this.tbxFreeBookCount.Enabled = false;
			this.tbxPubAdAmt.Enabled = false;
			this.tbxPubChangeAmt.Enabled = false;
			this.tbxColorTime.Enabled = false;
			this.tbxGetColorTime.Enabled = false;
			this.tbxMenoTime.Enabled = false;
			this.tbxRestClrtm.Enabled = false;
			this.tbxRestGetClrtm.Enabled = false;
			this.tbxRestMenotm.Enabled = false;

			// �s�i�p���H ��
			this.tbxAuName.Enabled = false;
			this.tbxAuTel.Enabled = false;
			this.tbxAuFax.Enabled = false;
			this.tbxAuCell.Enabled = false;
			this.tbxAuEmail.Enabled = false;

			// �Ƶ� �� - tarContRemark (Html Control) �w�ϥ� disable �ݩ� Disable �F
		}



		// ��X �t�ӤΫȤ��� �Ϥ����
		private void GetMfrCust()
		{
			// �ǥѫe�@�����ǨӪ��ܼƭȦr�� custno
			string custno = "";

			// �Y���Ȥ�s��, �h���w��ܤ�
			if(Context.Request.QueryString["custno"].ToString().Trim() != "" || Context.Request.QueryString["custno"].ToString().Trim() != null)
			{
				custno = Context.Request.QueryString["custno"].ToString().Trim();
				//Response.Write("custno= " + custno + "<BR>");
				lblCustNo.Text = custno;


				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "cust");
				DataView dv1 = ds1.Tables["cust"].DefaultView;

				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
				string rowfilterstr = "1=1";
				rowfilterstr = rowfilterstr + " AND cust_custno='" + custno + "'";
				dv1.RowFilter = rowfilterstr;

				// �ˬd�ÿ�X �̫� Row Filter �����G
				//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
				//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

				// �Y�����, �h��ܬ������; �_�h�������~�T��
				if(dv1.Count > 0)
				{
					// �ǥѫe�@�����ǨӪ��ܼƭȦr�� custno
					this.lblCustName.Text = dv1[0]["cust_nm"].ToString().Trim();

					///��X�ӫȤᤧ�t�Ӳνs mfrno (�� cust_mfrno)
					string mfrno = dv1[0]["cust_mfrno"].ToString().Trim();
					//Response.Write("mfrno= " + mfrno + "<BR>");

					// �Y���t�Ӥ��s�b, �h��� ��� "�L���" ��T; �_�h, ��ܨ�������
					if(mfrno == "9999999999")
					{
						this.lblMfrIName.Text = "<font color='RED'>�L�����Τ@�s��</font>";
						this.lblMfrNo.Text = mfrno;
						this.lblMfrRespName.Text = "<font color='Gray'>�L���</font>";
						this.lblMfrRespJobTitle.Text = "<font color='Gray'>�L���</font>";
						this.lblMfrTel.Text = "<font color='Gray'>�L���</font>";
						this.lblMfrFax.Text = "<font color='Gray'>�L���</font>";
					}
					else
					{
						this.lblMfrNo.Text = mfrno;

						// �A�� �t�Ӳνs mfrno, ���������
						if(dv1[0]["mfr_inm"].ToString().Trim() != "")
							this.lblMfrIName.Text = dv1[0]["mfr_inm"].ToString().Trim();
						else
							this.lblMfrIName.Text = "<font color='Gray'>�L���</font>";

						if(dv1[0]["mfr_respnm"].ToString().Trim() != "")
							this.lblMfrRespName.Text = dv1[0]["mfr_respnm"].ToString().Trim();
						else
							this.lblMfrRespName.Text = "<font color='Gray'>�L���</font>";

						if(dv1[0]["mfr_respjbti"].ToString().Trim() != "")
							this.lblMfrRespJobTitle.Text = dv1[0]["mfr_respjbti"].ToString().Trim();
						else
							this.lblMfrRespJobTitle.Text = "<font color='Gray'>�L���</font>";

						if(dv1[0]["mfr_tel"].ToString().Trim() != "")
							this.lblMfrTel.Text = dv1[0]["mfr_tel"].ToString().Trim();
						else
							this.lblMfrTel.Text = "<font color='Gray'>�L���</font>";

						if(dv1[0]["mfr_fax"].ToString().Trim() != "")
							this.lblMfrFax.Text = dv1[0]["mfr_fax"].ToString().Trim();
						else
							this.lblMfrFax.Text = "<font color='Gray'>�L���</font>";
					}
				}
					// �Y��L���, �h�M�����
				else
				{
					this.lblMfrNo.Text = "<font color='Gray'>�d�L���t�Ӳνs</font>";
					//					this.lblMfrIName.Text = "<font color='Gray'>�L���</font>";
					this.lblMfrRespName.Text = "<font color='Gray'>�L���</font>";
					this.lblMfrRespJobTitle.Text = "<font color='Gray'>�L���</font>";
					this.lblMfrTel.Text = "<font color='Gray'>�L���</font>";
					this.lblMfrFax.Text = "<font color='Gray'>�L���</font>";

					this.lblCustName.Text = "(<font color='RED'>�d�L���Ȥ�s��</font>)";
					this.lblCustNo.Text = "<font color='Gray'>�L���</font>";
				}

				// ���� if  // �Y���Ȥ�s��, �h���w��ܤ�
			}
		}


		// ��X������l��, �p�ʺA�U�Ԧ���� (��DB��), �t�Τ���� - �D�n�� �X���Ѱ򥻸�ư�
		private void InitialData()
		{
			// �X���Ѱ򥻸�� ��

			// ��� ñ������ΦX���_���� ���w�]��: ��t�Τ������
			// ��� �X������ ���w�]: �t�Φ~�� + �[ 11�Ӥ�
			this.tbxSignDate.Text = System.DateTime.Today.ToString("yyyy/MM/dd").Trim();
			this.tbxStartDate.Text = System.DateTime.Today.ToString("yyyy/MM").Trim();
			//tbxEndDate.Value=System.DateTime.Today.AddDays(364).ToString("yyyy/MM");
			this.tbxEndDate.Text = System.DateTime.Today.AddMonths(11).ToString("yyyy/MM").Trim();

			// �̫�ק������w�]��
			//Response.Write("tbxStartDate.Value= " + tbxStartDate.Value + "<br>");
			//Response.Write("hiddenModDate.Value= " + hiddenModDate.Value + "<br>");

			// ��ܤU�Ԧ���� ���y���O�� DB ��
			// ���� nostr, �а� sqlDataAdapter2.Select statement;
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

			// ��ܤU�Ԧ���� �~�ȭ��� DB ��
			// **�`�N: �쥻��Ʈw���� srspn_cname & srspn_empno �O char(x) ���A, �G�� sqlDataAdapter4 ��, �n���� RTRIM ���B�z (�p RTRIM(srspn_cname) AS srspn_cname), �_�h��ȷ|�t���ť�, �p '800443 ', '�d�R��     ' .
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "srspn");
			ddlEmpNo.DataSource=ds3;
			ddlEmpNo.DataTextField="srspn_cname";
			ddlEmpNo.DataValueField="srspn_empno";
			ddlEmpNo.DataBind();

			// �U�q�{���b�������ݭn, �G�s�W�� -- �P contFm_Add.aspx.cs �B���P�B
			// ��ܤU�Ԧ���� �ק�~�ȭ��� DB ��
			// **�`�N: �쥻��Ʈw���� srspn_cname & srspn_empno �O char(x) ���A, �G�� sqlDataAdapter4 ��, �n���� RTRIM ���B�z (�p RTRIM(srspn_cname) AS srspn_cname), �_�h��ȷ|�t���ť�, �p '800443 ', '�d�R��     ' .
			DataSet ds8 = new DataSet();
			this.sqlDataAdapter3.Fill(ds8, "srspn");
			ddlModEmpNo.DataSource=ds8;
			ddlModEmpNo.DataTextField="srspn_cname";
			ddlModEmpNo.DataValueField="srspn_empno";
			ddlModEmpNo.DataBind();


			// �U�q�{���b�������ä��ݭn, �G�ٲ��� -- �P contFm_Add.aspx.cs �B���P�B
			// ��X�n�J�̪��u��, �@���w�] ���ɷ~�ȭ� ����

			// �U�q�{���b�������ä��ݭn, �G�ٲ��� -- �P contFm_Add.aspx.cs �B���P�B
			// ���w����ܷs�� �X���ѽs��

		}


		// ���J�¦��X�����: �X���ѲӸ` & �s�i�p���H ����l�w�]��
		private void LoadOldCont()
		{
			// ��X�����ܼ�: �Ȥ�s��
			string strOldContNo = Context.Request.QueryString["old_contno"].ToString().Trim();
			//Response.Write("strOldContNo= "+ strOldContNo + "<BR>");

			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "c2_cont");
			DataView dv4 = ds4.Tables["c2_cont"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			string rowfilterstr4 = "1=1";
			rowfilterstr4 = rowfilterstr4 + " AND cont_contno='" + strOldContNo + "'";
			dv4.RowFilter = rowfilterstr4;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
			//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

			// �Y�����, �h��ܬ������; �_�h�������~�T��
			if(dv4.Count > 0)
			{
				// �U�q�{���b�������ݭn, �G�s�W�� -- �P contFm_Add.aspx.cs �B���P�B
				// �X���Ѱ򥻸�� ��
				string SignDate = dv4[0]["cont_signdate"].ToString().Trim();
				SignDate = SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
				this.tbxSignDate.Text = SignDate;
				string conttp = dv4[0]["cont_conttp"].ToString().Trim();
				int intConttpIndex = 0;
				if(conttp=="01")
					intConttpIndex = 0;
				else
					intConttpIndex = 1;
				this.ddlContType.SelectedIndex = intConttpIndex;
				this.ddlBookCode.SelectedIndex = Convert.ToInt32(dv4[0]["cont_bkcd"].ToString().Trim())-1;
				string StartDate = dv4[0]["cont_sdate"].ToString().Trim();
				//StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
				if(StartDate != "")
				{
					if(StartDate.Length >= 6)
						StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
					else
					{
						// ���� \ �Ÿ��H���o�Ʀr
						if(StartDate.IndexOf("\\") != -1)
						{
							//StartDate = StartDate.Split('/', 2);
						}
						else
							StartDate = StartDate;
					}
				}
				else
				{
					StartDate = StartDate;
				}
				this.tbxStartDate.Text = StartDate;
				string EndDate = dv4[0]["cont_edate"].ToString().Trim();
				//EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
				if(EndDate != "")
				{
					if(EndDate.Length >= 6)
						EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
					else
					{
						// ���� \ �Ÿ��H���o�Ʀr
						if(EndDate.IndexOf("\\") != -1)
						{
							//EndDate = EndDate.Split('/', 2);
						}
						else
							EndDate = EndDate;
					}
				}
				else
				{
					EndDate = EndDate;
				}
				this.tbxEndDate.Text = EndDate;
				// ��X�U�Ԧ���� �~�ȭ������
				// ��: �U�@��ä��ॿ�T��ܨ� index, ���u����V�Ĥ@�� index (0)
				//this.ddlEmpNo.SelectedItem.Value = dv4[0]["cont_empno"].ToString().Trim();
				this.ddlEmpNo.Items.FindByValue(dv4[0]["cont_empno"].ToString().Trim()).Selected = true;
				// ��: �U�@��ä��ॿ�T��ܨ� index, �B rblfgPayOnce �� Selected="True" �n����
				//this.rblfgPayOnce.SelectedItem.Value = dv4[0]["cont_fgpayonce"].ToString().Trim();
				if(Convert.ToString(this.rblfgPayOnce.Items.FindByValue(dv4[0]["cont_fgpayonce"].ToString().Trim())) != "")
					this.rblfgPayOnce.Items.FindByValue(dv4[0]["cont_fgpayonce"].ToString().Trim()).Selected = true;
				//else
				//this.rblfgPayOnce.Items.FindByValue(dv4[0]["cont_fgpayonce"].ToString().Trim()).Selected = false;

				// �U�q�{���b�������ݭn, �G�s�W�� -- �P contFm_Add.aspx.cs �B���P�B
				this.rblfgClosed.Items.FindByValue(dv4[0]["cont_fgclosed"].ToString().Trim()).Selected = true;
				this.ddlModEmpNo.Items.FindByValue(dv4[0]["cont_modempno"].ToString().Trim()).Selected = true;
				this.rblfgCancel.Items.FindByValue(dv4[0]["cont_fgcancel"].ToString().Trim()).Selected = true;
				// ��� lblOldContMessage �T�� : �P�_�O�_�� �Ĥ@�i�X�� �� �����v�ѦҸ��
				string OldContNo = dv4[0]["cont_oldcontno"].ToString().Trim();
				if(OldContNo == "0")
					this.lblOldContMessage.Text = "(�L���v���, �����s�X��)";
				else
					this.lblOldContMessage.Text = OldContNo;
				string CreateDate = dv4[0]["cont_credate"].ToString().Trim();
				CreateDate = CreateDate.Substring(0, 4) + "/" + CreateDate.Substring(4, 2) + "/" + CreateDate.Substring(6, 2);
				this.lblCreateDate.Text = CreateDate;
				string ModifyDate = dv4[0]["cont_moddate"].ToString().Trim();
				ModifyDate = ModifyDate.Substring(0, 4) + "/" + ModifyDate.Substring(4, 2) + "/" + ModifyDate.Substring(6, 2);
				this.lblModifyDate.Text = ModifyDate;


				// �X���ѲӸ` ��
				this.tbxTotalJTime.Text = dv4[0]["cont_totjtm"].ToString().Trim();
				this.tbxMadeJTime.Text = dv4[0]["cont_madejtm"].ToString().Trim();
				this.tbxRestJTime.Text = dv4[0]["cont_restjtm"].ToString().Trim();
				this.tbxTotalTime.Text = dv4[0]["cont_tottm"].ToString().Trim();
				this.tbxPubTime.Text = dv4[0]["cont_pubtm"].ToString().Trim();
				this.tbxRestTime.Text = dv4[0]["cont_resttm"].ToString().Trim();
				this.tbxTotalAmt.Text = dv4[0]["cont_totamt"].ToString().Trim();
				this.tbxPaidAmt.Text = dv4[0]["cont_paidamt"].ToString().Trim();
				this.tbxRestAmt.Text = dv4[0]["cont_restamt"].ToString().Trim();
				this.tbxChangeJTime.Text = dv4[0]["cont_chgjtm"].ToString().Trim();
				this.tbxFreeTime.Text = dv4[0]["cont_freetm"].ToString().Trim();
				this.tbxADAmt.Text = dv4[0]["cont_adamt"].ToString().Trim();
				this.tbxDiscount.Text = dv4[0]["cont_disc"].ToString().Trim();
				this.tbxFreeBookCount.Text = dv4[0]["cont_freebkcnt"].ToString().Trim();
				this.tbxPubAdAmt.Text = dv4[0]["cont_pubamt"].ToString().Trim();
				this.tbxPubChangeAmt.Text = dv4[0]["cont_chgamt"].ToString().Trim();
				this.tbxColorTime.Text = dv4[0]["cont_clrtm"].ToString().Trim();
				this.tbxGetColorTime.Text = dv4[0]["cont_getclrtm"].ToString().Trim();
				this.tbxMenoTime.Text = dv4[0]["cont_menotm"].ToString().Trim();
				string strfgPubed = dv4[0]["cont_fgpubed"].ToString().Trim();
				this.tbxRestClrtm.Text = dv4[0]["cont_restclrtm"].ToString().Trim();
				this.tbxRestGetClrtm.Text = dv4[0]["cont_restgetclrtm"].ToString().Trim();
				this.tbxRestMenotm.Text = dv4[0]["cont_restmenotm"].ToString().Trim();

				// �s�i�p���H ��
				this.tbxAuName.Text = dv4[0]["cont_aunm"].ToString().Trim();
				this.tbxAuTel.Text = dv4[0]["cont_autel"].ToString().Trim();
				this.tbxAuFax.Text = dv4[0]["cont_aufax"].ToString().Trim();
				this.tbxAuCell.Text = dv4[0]["cont_aucell"].ToString().Trim();
				this.tbxAuEmail.Text = dv4[0]["cont_auemail"].ToString().Trim();

				// �Ƶ� �� : Html Control ���� Runat=server, �~��b aspx.cs ���I�s�ϥ�
				// �B�b .cs �����ۤv�[�� protected System.Web.UI.HtmlControls.HtmlTextArea tarContRemark;
				if(dv4[0]["cont_remark"].ToString().Trim() != "")
				{
					//Response.Write("cont_remark= " + dv4[0]["cont_remark"].ToString().Trim() + "<br>");
					this.tarContRemark.Value = dv4[0]["cont_remark"].ToString().Trim();
				}
			}
		}


		// ��� DataGrid1 ���
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// ���J���
			BindGrid1();
		}


		// ���J �o���t�Ӧ���H���
		private void BindGrid1()
		{
			// ��X �z�����
			string strsyscd = "C2";
			string strConto = this.lblContNo.Text.ToString().Trim();


			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "invmfr");
			DataView dv5 = ds5.Tables["invmfr"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr5 = "1=1";
			rowfilterstr5 = rowfilterstr5 + " AND im_syscd='" + strsyscd + "'";
			rowfilterstr5 = rowfilterstr5 + " AND im_contno='" + strConto + "'";
			dv5.RowFilter = rowfilterstr5;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
			//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

			// �Y�����v���, �h���J���
			if (dv5.Count > 0)
			{
				// ��ܨ�������
				DataGrid1.DataSource=dv5;
				DataGrid1.DataBind();


				// �S�O��줧��X�榡�ഫ - �ܧ�ñ��������榡
				int i;
				for(i=0; i< DataGrid1.Items.Count ; i++)
				{
					// �o�����O
					string invcd =  DataGrid1.Items[i].Cells[10].Text.ToString().Trim();
					switch (invcd)
					{
						case "2":
							DataGrid1.Items[i].Cells[10].Text = "�G�p";
							break;
						case "3":
							DataGrid1.Items[i].Cells[10].Text = "�T�p";
							break;
						case "4":
							DataGrid1.Items[i].Cells[10].Text = "��L";
							break;
						case "9":
							DataGrid1.Items[i].Cells[10].Text = "���M��";
							DataGrid1.Items[i].Cells[10].ForeColor = Color.Red;
							break;
						default:
							DataGrid1.Items[i].Cells[10].Text = "�T�p";
							break;
					}

					// �o���ҵ|�O
					string taxtp = DataGrid1.Items[i].Cells[11].Text.ToString().Trim();
					switch (taxtp)
					{
						case "1":
							DataGrid1.Items[i].Cells[11].Text = "���|5%";
							break;
						case "2":
							DataGrid1.Items[i].Cells[11].Text = "�s�|";
							break;
						case "3":
							DataGrid1.Items[i].Cells[11].Text = "�K�|";
							break;
						case "9":
							DataGrid1.Items[i].Cells[11].Text = "���M��";
							DataGrid1.Items[i].Cells[11].ForeColor = Color.Red;
							break;
						default:
							DataGrid1.Items[i].Cells[11].Text = "���|5%";
							break;
					}

					// �|�Ҥ����O
					string fgItri = DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
					switch (fgItri)
					{
						case "":
							DataGrid1.Items[i].Cells[12].Text = "�_";
							break;
						case "06":
							DataGrid1.Items[i].Cells[12].Text = "<font color='Red'>�Ҥ�</font>";
							break;
						case "07":
							DataGrid1.Items[i].Cells[12].Text = "<font color='Red'>�|��</font>";
							break;
						default:
							DataGrid1.Items[i].Cells[12].Text = "�_";
							break;
					}

				}

			}

		}


		// ��� DataGrid2 ���
		private void Datagrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// ���J���
			BindGrid2();
		}


		// ���J �o���t�Ӧ���H���
		private void BindGrid2()
		{
			// ��X �z�����
			string strsyscd = "C2";
			string strConto = this.lblContNo.Text.ToString().Trim();


			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds6 = new DataSet();
			this.sqlDataAdapter6.Fill(ds6, "c2_or");
			DataView dv6 = ds6.Tables["c2_or"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr6 = "1=1";
			rowfilterstr6 = rowfilterstr6 + " AND or_syscd='" + strsyscd + "'";
			rowfilterstr6 = rowfilterstr6 + " AND or_contno='" + strConto + "'";
			dv6.RowFilter = rowfilterstr6;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
			//Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");

			// �Y�����v���, �h���J���
			if (dv6.Count > 0)
			{
				// ��ܨ�������
				Datagrid2.DataSource=dv6;
				Datagrid2.DataBind();

				int PubCount = 0;
				int UnPubCount = 0;
				// �S�O��줧��X�榡�ഫ - �ܧ�ñ��������榡
				int i;
				for(i=0; i< Datagrid2.Items.Count ; i++)
				{
					// �o�����O�N�X
					string mtpcd =  Datagrid2.Items[i].Cells[12].Text.ToString().Trim();

					// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
					DataSet ds7 = new DataSet();
					this.sqlDataAdapter7.Fill(ds7, "mtp");
					DataView dv7 = ds7.Tables["mtp"].DefaultView;

					// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
					// �] Row Filter: default �� 1=1 and ��L rowfilter ����
					string rowfilterstr7 = "1=1";
					rowfilterstr7 = rowfilterstr7 + " AND mtp_mtpcd='" + mtpcd + "'";
					dv7.RowFilter = rowfilterstr7;

					// �ˬd�ÿ�X �̫� Row Filter �����G
					//Response.Write("dv7.Count= "+ dv7.Count + "<BR>");
					//Response.Write("dv7.RowFilter= " + dv7.RowFilter + "<BR>");

					if(dv7.Count > 0)
					{
						// ��X �l�H���O�������
						string mtpnm = dv7[0]["mtp_nm"].ToString().Trim();
						Datagrid2.Items[i].Cells[12].Text = mtpnm;
					}
					else
					{
						Datagrid2.Items[i].Cells[12].Text = "�]��Ʀ��~)";
					}


					// ���~�l�H���O
					string fgmosea = Datagrid2.Items[i].Cells[13].Text.ToString().Trim();
					switch (fgmosea)
					{
						case "0":
							Datagrid2.Items[i].Cells[13].Text = "�ꤺ";
							break;
						case "1":
							Datagrid2.Items[i].Cells[13].Text = "<font color='Red'>��~</font>";
							break;
						default:
							Datagrid2.Items[i].Cells[13].Text = "�ꤺ";
							break;
					}

					// ��X �U�� ���n���� & ���n���� ���[�`��
					PubCount += int.Parse(Datagrid2.Items[i].Cells[10].Text.ToString().Trim());
					UnPubCount += int.Parse(Datagrid2.Items[i].Cells[11].Text.ToString().Trim());
				}

				// ��� �`�p�G���n���� & ���n����
				//Response.Write("Toal PubCount= " + PubCount + "<br>");
				//Response.Write("Toal UnPubCount= " + UnPubCount + "<br>");
				this.lblORPunCnt.Text = Convert.ToString(PubCount);
				this.lblORUnPubCnt.Text = Convert.ToString(UnPubCount);
			}

		}


		// ���J �o���t�Ӧ���H���
		private void BindList2()
		{
			string strContNo = this.lblContNo.Text.ToString().Trim();


			// ��X�ŦX���󪺹����������
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds8 = new DataSet();
			this.sqlDataAdapter8.Fill(ds8, "c2_pub");
			DataView dv8 = ds8.Tables["c2_pub"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			string rowfilterst8 = " 1=1 ";
			rowfilterst8 = rowfilterst8 + " AND (pub_syscd ='C2') ";
			rowfilterst8 = rowfilterst8 + " AND (pub_contno ='" + strContNo + "') ";
			dv8.RowFilter= rowfilterst8;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv8.Count= "+ dv8.Count + "<BR>");
			//Response.Write("dv8.RowFilter= " + dv8.RowFilter + "<BR><BR>");

			// �Y�����, �h��ܬ������; �_�h�������~�T��
			if(dv8.Count > 0)
			{
				DataList2.DataSource=dv8;
				DataList2.DataBind();

				//Response.Write("DataList2.Items.Count= " + DataList2.Items.Count + "<br>");
				//Response.Write("DataList2.Controls.Count= " + DataList2.Controls.Count + "<br>");
				// �S�O��줧��X�榡�ഫ - �ܧ�o�����O�����榡
				for(int i=0; i<DataList2.Items.Count; i++)
				{
					// �Z�n�~��
					string yyyymm = ((Label)DataList2.Items[i].FindControl("lblYYYYMM")).Text.ToString().Trim();
					//Response.Write("yyyymm = " + yyyymm + "<br>");
					int intyyyymm = int.Parse(yyyymm);
					if(intyyyymm >= 6)
						yyyymm = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
					else
						yyyymm = yyyymm;
					((Label)DataList2.Items[i].FindControl("lblYYYYMM")).Text = yyyymm;

					// �T�w�������O
					string fgfixpg = ((Label)DataList2.Items[i].FindControl("lblfgFixPg")).Text.ToString().Trim();
					//Response.Write("fgfixpg = " + fgfixpg + "<br>");
					if(fgfixpg == "0")
						((Label)DataList2.Items[i].FindControl("lblfgFixPg")).Text = "�_";
					else
						((Label)DataList2.Items[i].FindControl("lblfgFixPg")).Text = "<font color='Red'>�O</font>";

					// �ק���
					string ModifyDate = ((Label)DataList2.Items[i].FindControl("lblModifyDate")).Text.ToString().Trim();
					//Response.Write("ModifyDate = " + ModifyDate + "<br>");
					int intModifyDate = int.Parse(ModifyDate);
					if(intModifyDate >= 8)
						ModifyDate = ModifyDate.Substring(0, 4) + "/" + ModifyDate.Substring(4, 2) + "/" + ModifyDate.Substring(6, 2);
					else
						ModifyDate = ModifyDate;
					((Label)DataList2.Items[i].FindControl("lblModifyDate")).Text = ModifyDate;

					// �w�}�ߵo���}�߳���O
					string fginved = ((Label)DataList2.Items[i].FindControl("lblfgInved")).Text.ToString().Trim();
					//Response.Write("fginved = " + fginved + "<br>");
					if(fginved == "")
						((Label)DataList2.Items[i].FindControl("lblfgInved")).Text = "<font color='Red'>�_</font>";
					if(fginved == "v")
						((Label)DataList2.Items[i].FindControl("lblfgInved")).Text = "<font color='Blue'>�w�D���}</font>";
					if(fginved == "1")
						((Label)DataList2.Items[i].FindControl("lblfgInved")).Text = "�w�}��";

					// �o���}�߳�H�u�B�z���O
					string fginvself = ((Label)DataList2.Items[i].FindControl("lblfgInvSelf")).Text.ToString().Trim();
					//Response.Write("fginvself = " + fginvself + "<br>");
					if(fginvself == "0")
						((Label)DataList2.Items[i].FindControl("lblfgInvSelf")).Text = "�_";
					else
						((Label)DataList2.Items[i].FindControl("lblfgInvSelf")).Text = "<font color='Red'>�O</font>";

					// �Z�����O
					string drafttp = ((Label)DataList2.Items[i].FindControl("lblDrafttp")).Text.ToString().Trim();
					//Response.Write("drafttp = " + drafttp + "<br>");
					switch (drafttp)
					{
						case "1":
							((Label)DataList2.Items[i].FindControl("lblDrafttp")).Text = "�½Z";

							// ��Z���O
							((Label)DataList2.Items[i].FindControl("lblfgGot")).Text = "";

							// ��Z�������
							((Label)DataList2.Items[i].FindControl("lblChgbkcd")).Text = "";
							((Label)DataList2.Items[i].FindControl("lblChgJNo")).Text = "";
							((Label)DataList2.Items[i].FindControl("lblChgJbkno")).Text = "";
							((Label)DataList2.Items[i].FindControl("lblfgReChg")).Text = "";

							// �s�Z�������
							((Label)DataList2.Items[i].FindControl("lblfgNjtpcd")).Text = "";
							break;

						case "2":
							((Label)DataList2.Items[i].FindControl("lblDrafttp")).Text = "�s�Z";

							// ��Z���O
							string fggot1 = ((Label)DataList2.Items[i].FindControl("lblfgGot")).Text.ToString().Trim();
							//Response.Write("fggot1 = " + fggot1 + "<br>");
							if(fggot1 == "0")
								((Label)DataList2.Items[i].FindControl("lblfgGot")).Text = "<font color='Red'>�_</font>";
							else
								((Label)DataList2.Items[i].FindControl("lblfgGot")).Text = "�O";

							// �½Z�������
							((Label)DataList2.Items[i].FindControl("lblOrigBkcd")).Text = "";
							((Label)DataList2.Items[i].FindControl("lblOrigJNo")).Text = "";
							((Label)DataList2.Items[i].FindControl("lblOrigJbkno")).Text = "";

							// ��Z�������
							((Label)DataList2.Items[i].FindControl("lblChgbkcd")).Text = "";
							((Label)DataList2.Items[i].FindControl("lblChgJNo")).Text = "";
							((Label)DataList2.Items[i].FindControl("lblChgJbkno")).Text = "";
							((Label)DataList2.Items[i].FindControl("lblfgReChg")).Text = "";
							break;

						case "3":
							((Label)DataList2.Items[i].FindControl("lblDrafttp")).Text = "��Z";

							// ��Z���O
							string fggot2 = ((Label)DataList2.Items[i].FindControl("lblfgGot")).Text.ToString().Trim();
							//Response.Write("fggot2 = " + fggot2 + "<br>");
							if(fggot2 == "0")
								((Label)DataList2.Items[i].FindControl("lblfgGot")).Text = "<font color='Red'>�_</font>";
							else
								((Label)DataList2.Items[i].FindControl("lblfgGot")).Text = "�O";

							// ��Z����
							string chgbkcd = ((Label)DataList2.Items[i].FindControl("lblChgbkcd")).Text.ToString().Trim();
							//Response.Write("chgbkcd = " + chgbkcd + "<br>");
							switch (chgbkcd)
							{
								case "  ":
									((Label)DataList2.Items[i].FindControl("lblChgbkcd")).Text = "";
									break;
								case "01":
									((Label)DataList2.Items[i].FindControl("lblChgbkcd")).Text = "�u�����x";
									break;
								case "02":
									((Label)DataList2.Items[i].FindControl("lblChgbkcd")).Text = "�q�����x";
									break;
								default:
									((Label)DataList2.Items[i].FindControl("lblChgbkcd")).Text = "�u�����x";
									break;
							}

							// ��Z���X�����O
							string fgrechg = ((Label)DataList2.Items[i].FindControl("lblfgReChg")).Text.ToString().Trim();
							//Response.Write("fgrechg = " + fgrechg + "<br>");
							if(fgrechg == "0")
								((Label)DataList2.Items[i].FindControl("lblfgReChg")).Text = "<font color='Red'>�_</font>";
							else
								((Label)DataList2.Items[i].FindControl("lblfgReChg")).Text = "�O";

							// �½Z�������
							((Label)DataList2.Items[i].FindControl("lblOrigBkcd")).Text = "";
							((Label)DataList2.Items[i].FindControl("lblOrigJNo")).Text = "";
							((Label)DataList2.Items[i].FindControl("lblOrigJbkno")).Text = "";

							// �s�Z�������
							((Label)DataList2.Items[i].FindControl("lblfgNjtpcd")).Text = "";
							break;

						default:
							((Label)DataList2.Items[i].FindControl("lblDrafttp")).Text = "�½Z";

							// ��Z���O
							((Label)DataList2.Items[i].FindControl("lblfgGot")).Text = "";

							// ��Z�������
							((Label)DataList2.Items[i].FindControl("lblChgbkcd")).Text = "";
							((Label)DataList2.Items[i].FindControl("lblChgJNo")).Text = "";
							((Label)DataList2.Items[i].FindControl("lblChgJbkno")).Text = "";
							((Label)DataList2.Items[i].FindControl("lblfgReChg")).Text = "";

							// �s�Z�������
							((Label)DataList2.Items[i].FindControl("lblfgNjtpcd")).Text = "";
							break;
					}
				// 	���� for loop
				}
			// ���� if(dv8.Count > 0)
			}
			else
			{
				this.lblPubMessage.Text = "�d�L�������~";
			}

		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter7 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter6 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter8 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
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
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "cust", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																			  new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																			  new System.Data.Common.DataColumnMapping("cust_mfrno", "cust_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																			  new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																			  new System.Data.Common.DataColumnMapping("cust_fax", "cust_fax"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_tel", "mfr_tel"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_fax", "mfr_fax"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_regdate", "mfr_regdate"),
																																																			  new System.Data.Common.DataColumnMapping("cust_cell", "cust_cell"),
																																																			  new System.Data.Common.DataColumnMapping("cust_email", "cust_email"),
																																																			  new System.Data.Common.DataColumnMapping("cust_oldcustno", "cust_oldcustno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_orgisyscd", "cust_orgisyscd"),
																																																			  new System.Data.Common.DataColumnMapping("cust_regdate", "cust_regdate"),
																																																			  new System.Data.Common.DataColumnMapping("cust_moddate", "cust_moddate"),
																																																			  new System.Data.Common.DataColumnMapping("Expr1", "Expr1")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.cust.cust_custid, dbo.cust.cust_custno, RTRIM(dbo.cust.cust_nm) AS cust_nm, RTRIM(dbo.cust.cust_mfrno) AS cust_mfrno, dbo.cust.cust_jbti, dbo.cust.cust_tel, dbo.cust.cust_fax, dbo.mfr.mfr_mfrid, RTRIM(dbo.mfr.mfr_mfrno) AS mfr_mfrno, RTRIM(dbo.mfr.mfr_inm) AS mfr_inm, RTRIM(dbo.mfr.mfr_respnm) AS mfr_respnm, dbo.mfr.mfr_respjbti, dbo.mfr.mfr_tel, RTRIM(dbo.mfr.mfr_fax) AS mfr_fax, RTRIM(dbo.mfr.mfr_iaddr) AS mfr_iaddr, dbo.mfr.mfr_izip, dbo.mfr.mfr_regdate, dbo.cust.cust_cell, dbo.cust.cust_email, RTRIM(dbo.cust.cust_oldcustno) AS cust_oldcustno, RTRIM(dbo.cust.cust_orgisyscd) AS cust_orgisyscd, dbo.cust.cust_regdate, dbo.cust.cust_moddate, dbo.mfr.mfr_mfrno AS Expr1 FROM dbo.cust INNER JOIN dbo.mfr ON dbo.cust.cust_mfrno = dbo.mfr.mfr_mfrno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
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
			//
			// sqlDataAdapter7
			//
			this.sqlDataAdapter7.SelectCommand = this.sqlSelectCommand7;
			this.sqlDataAdapter7.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mtp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mtp_mtpcd", "mtp_mtpcd"),
																																																			 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm")})});
			//
			// sqlSelectCommand7
			//
			this.sqlSelectCommand7.CommandText = "SELECT mtp_mtpcd, mtp_nm FROM dbo.mtp";
			this.sqlSelectCommand7.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter6
			//
			this.sqlDataAdapter6.SelectCommand = this.sqlSelectCommand6;
			this.sqlDataAdapter6.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_or", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																			   new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																			   new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																			   new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																			   new System.Data.Common.DataColumnMapping("or_jbti", "or_jbti"),
																																																			   new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																			   new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																			   new System.Data.Common.DataColumnMapping("or_tel", "or_tel"),
																																																			   new System.Data.Common.DataColumnMapping("or_fax", "or_fax"),
																																																			   new System.Data.Common.DataColumnMapping("or_cell", "or_cell"),
																																																			   new System.Data.Common.DataColumnMapping("or_email", "or_email"),
																																																			   new System.Data.Common.DataColumnMapping("or_mtpcd", "or_mtpcd"),
																																																			   new System.Data.Common.DataColumnMapping("or_pubcnt", "or_pubcnt"),
																																																			   new System.Data.Common.DataColumnMapping("or_unpubcnt", "or_unpubcnt"),
																																																			   new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea")})});
			//
			// sqlSelectCommand6
			//
			this.sqlSelectCommand6.CommandText = "SELECT or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, o" +
				"r_tel, or_fax, or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_fgmosea F" +
				"ROM dbo.c2_or";
			this.sqlSelectCommand6.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter5
			//
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				new System.Data.Common.DataColumnMapping("im_mfrno", "im_mfrno"),
																																																				new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				new System.Data.Common.DataColumnMapping("im_jbti", "im_jbti"),
																																																				new System.Data.Common.DataColumnMapping("im_zip", "im_zip"),
																																																				new System.Data.Common.DataColumnMapping("im_addr", "im_addr"),
																																																				new System.Data.Common.DataColumnMapping("im_tel", "im_tel"),
																																																				new System.Data.Common.DataColumnMapping("im_fax", "im_fax"),
																																																				new System.Data.Common.DataColumnMapping("im_cell", "im_cell"),
																																																				new System.Data.Common.DataColumnMapping("im_email", "im_email"),
																																																				new System.Data.Common.DataColumnMapping("im_invcd", "im_invcd"),
																																																				new System.Data.Common.DataColumnMapping("im_taxtp", "im_taxtp"),
																																																				new System.Data.Common.DataColumnMapping("im_fgitri", "im_fgitri")})});
			//
			// sqlSelectCommand5
			//
			this.sqlSelectCommand5.CommandText = "SELECT im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, " +
				"im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri FROM dbo.invmfr" +
				" WHERE (im_syscd = \'C2\')";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter4
			//
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_contid", "cont_contid"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aufax", "cont_aufax"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aucell", "cont_aucell"),
																																																				 new System.Data.Common.DataColumnMapping("cont_auemail", "cont_auemail"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_madejtm", "cont_madejtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restjtm", "cont_restjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_disc", "cont_disc"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freetm", "cont_freetm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubtm", "cont_pubtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_resttm", "cont_resttm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_chgjtm", "cont_chgjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubamt", "cont_pubamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_chgamt", "cont_chgamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_clrtm", "cont_clrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_menotm", "cont_menotm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_getclrtm", "cont_getclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_oldcontno", "cont_oldcontno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_moddate", "cont_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("cont_modempno", "cont_modempno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_credate", "cont_credate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_adamt", "cont_adamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freebkcnt", "cont_freebkcnt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_remark", "cont_remark"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restclrtm", "cont_restclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restmenotm", "cont_restmenotm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restgetclrtm", "cont_restgetclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_njtpcnt", "cont_njtpcnt")})});
			//
			// sqlSelectCommand4
			//
			this.sqlSelectCommand4.CommandText = @"SELECT cont_contid, cont_syscd, cont_contno, cont_conttp, cont_bkcd, cont_signdate, cont_empno, cont_mfrno, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_sdate, cont_edate, cont_totjtm, cont_madejtm, cont_restjtm, cont_disc, cont_freetm, cont_fgclosed, cont_tottm, cont_pubtm, cont_resttm, cont_chgjtm, cont_custno, cont_totamt, cont_pubamt, cont_chgamt, cont_paidamt, cont_restamt, cont_clrtm, cont_menotm, cont_getclrtm, cont_oldcontno, cont_moddate, cont_fgpayonce, cont_modempno, cont_fgcancel, cont_credate, cont_adamt, cont_freebkcnt, cont_remark, cont_fgtemp, cont_fgpubed, cont_restclrtm, cont_restmenotm, cont_restgetclrtm, cont_njtpcnt FROM dbo.c2_cont";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter8
			//
			this.sqlDataAdapter8.SelectCommand = this.sqlSelectCommand8;
			this.sqlDataAdapter8.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgno", "pub_pgno"),
																																																				new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_adamt", "pub_adamt"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgamt", "pub_chgamt"),
																																																				new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																				new System.Data.Common.DataColumnMapping("pub_origbkcd", "pub_origbkcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_origjno", "pub_origjno"),
																																																				new System.Data.Common.DataColumnMapping("pub_origjbkno", "pub_origjbkno"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgbkcd", "pub_chgbkcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgjno", "pub_chgjno"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgjbkno", "pub_chgjbkno"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																				new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																				new System.Data.Common.DataColumnMapping("pub_njtpcd", "pub_njtpcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_projno", "pub_projno"),
																																																				new System.Data.Common.DataColumnMapping("pub_costctr", "pub_costctr"),
																																																				new System.Data.Common.DataColumnMapping("pub_fginved", "pub_fginved"),
																																																				new System.Data.Common.DataColumnMapping("pub_fginvself", "pub_fginvself"),
																																																				new System.Data.Common.DataColumnMapping("pub_pno", "pub_pno"),
																																																				new System.Data.Common.DataColumnMapping("pub_remark", "pub_remark"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgfixpg", "pub_fgfixpg"),
																																																				new System.Data.Common.DataColumnMapping("pub_moddate", "pub_moddate"),
																																																				new System.Data.Common.DataColumnMapping("pub_modempno", "pub_modempno"),
																																																				new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_imseq", "pub_imseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgupdated", "pub_fgupdated"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgact", "pub_fgact"),
																																																				new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																				new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																				new System.Data.Common.DataColumnMapping("njtp_nm", "njtp_nm"),
																																																				new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("clr_clrcd", "clr_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("ltp_ltpcd", "ltp_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("njtp_njtpcd", "njtp_njtpcd"),
																																																				new System.Data.Common.DataColumnMapping("pgs_pgscd", "pgs_pgscd"),
																																																				new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno")})});
			//
			// sqlSelectCommand8
			//
			this.sqlSelectCommand8.CommandText = "SELECT dbo.c2_pub.pub_syscd, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_yyyymm, dbo.c2" +
				"_pub.pub_pubseq, dbo.c2_pub.pub_pgno, dbo.c2_pub.pub_ltpcd, dbo.c2_pub.pub_clrcd" +
				", dbo.c2_pub.pub_pgscd, dbo.c2_pub.pub_adamt, dbo.c2_pub.pub_chgamt, dbo.c2_pub." +
				"pub_drafttp, dbo.c2_pub.pub_origbkcd, dbo.c2_pub.pub_origjno, dbo.c2_pub.pub_ori" +
				"gjbkno, dbo.c2_pub.pub_chgbkcd, dbo.c2_pub.pub_chgjno, dbo.c2_pub.pub_chgjbkno, " +
				"dbo.c2_pub.pub_fgrechg, dbo.c2_pub.pub_fggot, dbo.c2_pub.pub_njtpcd, dbo.c2_pub." +
				"pub_projno, dbo.c2_pub.pub_costctr, dbo.c2_pub.pub_fginved, dbo.c2_pub.pub_fginv" +
				"self, dbo.c2_pub.pub_pno, dbo.c2_pub.pub_remark, dbo.c2_pub.pub_fgfixpg, dbo.c2_" +
				"pub.pub_moddate, dbo.c2_pub.pub_modempno, dbo.c2_pub.pub_bkcd, dbo.c2_pub.pub_im" +
				"seq, dbo.c2_pub.pub_fgupdated, dbo.c2_pub.pub_fgact, dbo.c2_ltp.ltp_nm, dbo.c2_c" +
				"lr.clr_nm, dbo.c2_pgsize.pgs_nm, dbo.c2_njtp.njtp_nm, dbo.srspn.srspn_cname, dbo" +
				".invmfr.im_nm, dbo.book.bk_nm, dbo.book.bk_bkcd, dbo.c2_clr.clr_clrcd, dbo.c2_lt" +
				"p.ltp_ltpcd, dbo.c2_njtp.njtp_njtpcd, dbo.c2_pgsize.pgs_pgscd, dbo.invmfr.im_con" +
				"tno, dbo.invmfr.im_imseq, dbo.invmfr.im_syscd, dbo.srspn.srspn_empno FROM dbo.c2" +
				"_pub INNER JOIN dbo.c2_ltp ON dbo.c2_pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd INNER " +
				"JOIN dbo.c2_clr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd INNER JOIN dbo.c2" +
				"_pgsize ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd INNER JOIN dbo.srspn O" +
				"N dbo.c2_pub.pub_modempno = dbo.srspn.srspn_empno INNER JOIN dbo.invmfr ON dbo.c" +
				"2_pub.pub_syscd = dbo.invmfr.im_syscd AND dbo.c2_pub.pub_contno = dbo.invmfr.im_" +
				"contno AND dbo.c2_pub.pub_imseq = dbo.invmfr.im_imseq LEFT OUTER JOIN dbo.c2_njt" +
				"p ON dbo.c2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd LEFT OUTER JOIN dbo.book ON" +
				" dbo.c2_pub.pub_origbkcd = dbo.book.bk_bkcd";
			this.sqlSelectCommand8.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.book.bk_bkid, dbo.book.bk_bkcd, RTRIM(dbo.book.bk_nm) AS bk_nm, dbo.proj.proj_syscd, dbo.proj.proj_bkcd, dbo.proj.proj_fgitri, dbo.proj.proj_projno, dbo.proj.proj_costctr FROM dbo.book INNER JOIN dbo.proj ON dbo.book.bk_bkcd COLLATE Chinese_Taiwan_Stroke_BIN = dbo.proj.proj_bkcd WHERE (dbo.proj.proj_syscd = 'C2')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



	}
}
