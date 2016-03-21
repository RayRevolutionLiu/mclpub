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
	/// Summary description for ContFm_Add.
	/// </summary>
	public class ContFm_Add : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblMfrIName;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblMfrRespName;
		protected System.Web.UI.WebControls.Label lblMfrRespJobTitle;
		protected System.Web.UI.WebControls.Label lblMfrTel;
		protected System.Web.UI.WebControls.Label lblMfrFax;
		protected System.Web.UI.WebControls.Label lblCustName;
		protected System.Web.UI.WebControls.Label lblfgClosedMessage;
		protected System.Web.UI.WebControls.TextBox tbxSignDate;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.DropDownList ddlContType;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Web.UI.WebControls.TextBox tbxStartDate;
		protected System.Web.UI.WebControls.TextBox tbxEndDate;
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Web.UI.WebControls.RadioButtonList rblfgPayOnce;
		protected System.Web.UI.WebControls.TextBox tbxTotalJTime;
		protected System.Web.UI.WebControls.TextBox tbxTotalTime;
		protected System.Web.UI.WebControls.TextBox tbxTotalAmt;
		protected System.Web.UI.WebControls.TextBox tbxChangeJTime;
		protected System.Web.UI.WebControls.TextBox tbxFreeTime;
		protected System.Web.UI.WebControls.TextBox tbxDiscount;
		protected System.Web.UI.WebControls.TextBox tbxColorTime;
		protected System.Web.UI.WebControls.TextBox tbxGetColorTime;
		protected System.Web.UI.WebControls.TextBox tbxMenoTime;
		protected System.Web.UI.WebControls.TextBox tbxAuName;
		protected System.Web.UI.WebControls.TextBox tbxAuTel;
		protected System.Web.UI.WebControls.TextBox tbxAuFax;
		protected System.Web.UI.WebControls.TextBox tbxAuCell;
		protected System.Web.UI.WebControls.TextBox tbxAuEmail;
		protected System.Web.UI.WebControls.Label lblIMMessage;
		protected System.Web.UI.WebControls.Label lblORMessage;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter6;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Web.UI.WebControls.DataGrid Datagrid2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter7;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter8;
		protected System.Web.UI.WebControls.Label lblORPunCnt;
		protected System.Web.UI.WebControls.Label lblORUnPubCnt;
		protected System.Web.UI.WebControls.ImageButton imbORRefresh;
		protected System.Web.UI.WebControls.ImageButton imbIMRefresh;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Data.SqlClient.SqlCommand sqlCommand3;
		protected System.Web.UI.WebControls.Label lblOldContNo;
		protected System.Web.UI.WebControls.TextBox tbxADAmt;
		protected System.Web.UI.WebControls.Label lblfgNew;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand8;
		protected System.Web.UI.WebControls.Label lblOldContMessage;
		protected System.Web.UI.WebControls.TextBox tbxFreeBookCount;
		protected System.Web.UI.HtmlControls.HtmlTextArea tarContRemark;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Data.SqlClient.SqlCommand sqlCommand4;
		protected System.Data.SqlClient.SqlCommand sqlCommand5;
		protected System.Web.UI.WebControls.Label lblAddMessage;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Web.UI.WebControls.Label lblCustNo;
	
		public ContFm_Add()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				Response.Expires=0;
				
				
				// ��X �t�ӤΫȤ��� �Ϥ����, �ǥѫe�@�����ǨӪ��ܼƭȦr�� custno
				GetMfrCust();
				
				// ��X������l��, �p�ʺA�U�Ԧ���� (��DB��), �t�Τ����
				InitialData();
								
				
				// �Y�����J�¦��X�����(when old_contno!="0"), �h���J��; �_�h������l�w�]��
				if(Context.Request.QueryString["old_contno"].ToString().Trim() != "0")
				{
					// �N �ѦҦX���ѽs�� �g�J lblOldContNo
					this.lblOldContNo.Text = Context.Request.QueryString["old_contno"].ToString().Trim();
					
					// ���J�¦��X�����: �X���ѲӸ` & �s�i�p���H ����l�w�]��
					LoadOldCont();
					
					
					// �i�� �o���t�Ӧ���H & ���x����H �æ����v���
					this.lblfgNew.Text = "1";
					this.lblIMMessage.Text = "(�����v���)";
					this.lblORMessage.Text = "(�����v���)";
					
					// ���J �o���t�Ӧ���H & ���x����H �����v��� (�̾� old_contno)
					BindGrid1();
					BindGrid2();
				}
				else
				{
					// �i�� �ѦҦX���ѽs�� �L���v���
					this.lblOldContNo.Text = "0";
					this.lblOldContMessage.Text = "(�L���v���, �����s�X��)";
					
					// ���ťզX����: �X���ѲӸ` & �s�i�p���H ����l�w�]��
					InitialContDetails();
					InitialContContactor();
					
					// �i�� �o���t�Ӧ���H & ���x����H �õL��l���
					this.lblfgNew.Text = "0";
					this.lblIMMessage.Text = "(�L��l���, �Цۦ�s�W)";
					this.lblORMessage.Text = "(�L��l���, �Цۦ�s�W)";
					
					// �] ���x����H-���n���� & ���n���� ����l��
					this.lblORPunCnt.Text = "0";
					this.lblORUnPubCnt.Text = "0";
				}
				
			}
			BindGrid1();
			BindGrid2();
		}
		

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
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
			
			
			// ��X�n�J�̪��u��, �@���w�] ���ɷ~�ȭ� ����
			string LoginEmpNo = "";
			//Response.Write("Session["empid"]= " + Session["empid"].ToString().Trim() + "<br>");
			// �Y���n�J�̪����, �h��X�ùw�� ���ɷ~�ȭ����U�Ԧ����
			if(Session["empid"]!=null && Session["empid"].ToString()!="")
			{
				LoginEmpNo = Session["empid"].ToString().Trim();
				for(int i=0; i<this.ddlEmpNo.Items.Count; i++)
				{
					//Response.Write("ddlEmpNo(" + i + ").Value= " + this.ddlEmpNo.Items[i].Value + "<br>");
					// �Y�U�Ԧ���檺�� �� �n�J�̤u��, �h�U�Ԧ����w�蠟; �_�h�� �d�R�� (800443, SelectedIndex=02)
					if(this.ddlEmpNo.Items[i].Value.Trim() == LoginEmpNo)  
					{
						this.ddlEmpNo.SelectedIndex = i;
					}
					else
					{
						this.ddlEmpNo.Items.FindByValue("800443").Selected = true;
					}
				}
				//this.ddlEmpNo.SelectedIndex = this.ddlEmpNo.Items.IndexOf(this.ddlEmpNo.Items.FindByValue(LoginEmpNo));
			}
				// �Y�L�n�J�̪����, �h��X�ùw��~�ȭ��� �d�R�� (800443, SelectedIndex=02)
			else
			{
				//LoginEmpNo = User.Identity.Name.Substring(5, 6).ToString().Trim();
				//Response.Write("User.Identity.Name= " + User.Identity.Name.ToString().Trim() + "<br>");
				LoginEmpNo = "800443";
				this.ddlEmpNo.Items.FindByValue("800443").Selected = true;
			}
			//Response.Write("LoginEmpNo= " + LoginEmpNo + "<br>");
			
			
			// ���w����ܷs�� �X���ѽs��
			string strDBMaxContNo = "";
			string strAssignedContNo = "";
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "c2_cont");
			DataView dv4 = ds4.Tables["c2_cont"].DefaultView;
			
			//Response.Write("dv4.Count= " + dv4.Count + "<br>");
			//Response.Write("Current MaxContNo= " + dv4[0][0].ToString().Trim() + "<br>");
			
			// �Y�����, �h��ܬ������; �_�h�������~�T��
			// �`�N�G ���B�] sqlDataAdapter4 ���ެO�_�����, �� dv4[0][0] �|�^�ǼƦr: 0�H�W; �G��j��0��, ��ܸ�Ʈw���u���� MaxCountNo
			// �G���B���i�� if(dv4.Count >0) �Ӱ��P�_
			if(int.Parse(dv4[0][0].ToString().Trim()) > 0)
			{
				// ��X �s���X���ѽs�� = �ثe��Ʈw����Max�X���ѽs��+1
				strAssignedContNo = Convert.ToString(Convert.ToInt32(dv4[0][1].ToString().Trim())+1);
				//Response.Write("strAssignedContNo= " + strAssignedContNo + "<br>");
				
				// ���ɹs�ʧ@: strAssignedContNo �����O�|���
				// ��k�@: �� if �ӧP�_ ���ɹs�ʧ@
				if(strAssignedContNo.Length==1)
					strAssignedContNo = "00000" + strAssignedContNo;
				if(strAssignedContNo.Length==2)
					strAssignedContNo = "0000" + strAssignedContNo;
				if(strAssignedContNo.Length==3)
					strAssignedContNo = "000" + strAssignedContNo;
				if(strAssignedContNo.Length==4)
					strAssignedContNo = "00" + strAssignedContNo;
				if(strAssignedContNo.Length==5)
					strAssignedContNo = "0" + strAssignedContNo;
				if(strAssignedContNo.Length==6)
					strAssignedContNo = strAssignedContNo;
				
				// ��k�G: �H for loop ���ɹs�ʧ@
//				for (int i=1; i<strAssignedContNo.Length; i++)
//				{
//					//strAssignedContNo = "0" + strAssignedContNo;
//				}	
			}
			else
			{
				strAssignedContNo = "000001";
			}
			// ���w����ܷs�� �X���ѽs��
			//Response.Write("strAssignedContNo= " + strAssignedContNo + "<br>");
			this.lblContNo.Text = strAssignedContNo;
			
			// �s�W ���s���X���ѽs�� �J��Ʈw��, �H�K�P�ɦ��G�H�H�W�� �s�W�X���Ѱʧ@��, �s�W���X���ѽs���ۦP
			// ���, �Y�o�ͦ��P�ɦ��G�H�H�W�ާ@��, �h�t�Φ]�|�۰ʧ� MaxContNo �Ӥ��|�o�ͷs�W���~ (�]�X���ѽs���ۦP, ����ƫo�i�ण�P)
			InsertNewContNo();
		}
		
		
		// �s�W ���s���X���ѽs�� �J��Ʈw��
		private void InsertNewContNo()
		{
			// ��X �s�X���ѽs��
			string strSyscd = "C2";
			string strCurrentContNo = this.lblContNo.Text.ToString().Trim();
			//Response.Write("strSyscd= " + strSyscd + "<br>");
			//Response.Write("strCurrentContNo= " + strCurrentContNo + "<br>");
			
			// Step 1: �R���w�s�W�� �o���t�Ӧ���H ���
			// ���� �N�ȶ�J sqlCommand1.Parameters ��, �H���� �s�W�J��Ʈw
			this.sqlCommand1.Parameters["@syscd"].Value = strSyscd;
			this.sqlCommand1.Parameters["@contno"].Value = strCurrentContNo;
			
			// �T�{���� sqlSelectCommand1 ���\
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
			
			// ��X���浲�G
			if (ResultFlag1)
			{
				//Response.Write("�s�W �X����PK ���\!<br>");
				
				// �H Javascript �� window.close() �ӧi���T��
				//LiteralControl litAlert1 = new LiteralControl();
				//litAlert1.Text = "<script language=javascript>alert(\"�s�W �X����PK ���\\");</script>";
				//Page.Controls.Add(litAlert1);
			}
			else
			{
				//Response.Write("�s�W �X����PK ����!<br>");
				
				// �H Javascript �� window.close() �ӧi���T��
				//LiteralControl litAlert1 = new LiteralControl();
				//litAlert1.Text = "<script language=javascript>alert(\"�s�W �X����PK ����\");</script>";
				//Page.Controls.Add(litAlert1);
			}
			
		}
		
		
		// ���J�¦��X�����: �X���ѲӸ` & �s�i�p���H ����l�w�]��
		private void LoadOldCont()
		{
			// ��X�����ܼ�: �Ȥ�s�� 
			string strOldContNo = Context.Request.QueryString["old_contno"].ToString().Trim();
			//Response.Write("strOldContNo= "+ strOldContNo + "<BR>");
			
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "c2_cont");
			DataView dv5 = ds5.Tables["c2_cont"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			string rowfilterstr5 = "1=1";
			rowfilterstr5 = rowfilterstr5 + " AND cont_contno='" + strOldContNo + "'";
			dv5.RowFilter = rowfilterstr5;
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
			//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");
			
			// �Y�����, �h��ܬ������; �_�h�������~�T��
			if(dv5.Count > 0)
			{
				// �X���ѲӸ` ��
				this.tbxTotalJTime.Text = dv5[0]["cont_totjtm"].ToString().Trim();
				this.tbxTotalTime.Text = dv5[0]["cont_tottm"].ToString().Trim();
				this.tbxChangeJTime.Text = dv5[0]["cont_chgjtm"].ToString().Trim();
				this.tbxFreeTime.Text = dv5[0]["cont_freetm"].ToString().Trim();
				this.tbxADAmt.Text = dv5[0]["cont_adamt"].ToString().Trim();
				this.tbxDiscount.Text = dv5[0]["cont_disc"].ToString().Trim();
				this.tbxFreeBookCount.Text = dv5[0]["cont_freebkcnt"].ToString().Trim();
				this.tbxTotalAmt.Text = dv5[0]["cont_totamt"].ToString().Trim();
				this.tbxColorTime.Text = dv5[0]["cont_clrtm"].ToString().Trim();
				this.tbxGetColorTime.Text = dv5[0]["cont_getclrtm"].ToString().Trim();
				this.tbxMenoTime.Text = dv5[0]["cont_menotm"].ToString().Trim();
				this.tarContRemark.Value = dv5[0]["cont_remark"].ToString().Trim();
				
				// �s�i�p���H ��
				this.tbxAuName.Text = dv5[0]["cont_aunm"].ToString().Trim();
				this.tbxAuTel.Text = dv5[0]["cont_autel"].ToString().Trim();
				this.tbxAuFax.Text = dv5[0]["cont_aufax"].ToString().Trim();
				this.tbxAuCell.Text = dv5[0]["cont_aucell"].ToString().Trim();
				this.tbxAuEmail.Text = dv5[0]["cont_auemail"].ToString().Trim();
			}
		}
		
		
		// ���ťզX����: �X���ѲӸ` ����l�w�]��
		private void InitialContDetails()
		{
			//this.tbxTotalJTime.Text = "0";
			//this.tbxTotalTime.Text = "0";
			this.tbxChangeJTime.Text = "0";
			this.tbxFreeTime.Text = "0";
			//this.tbxADAmt.Text = "0";
			this.tbxDiscount.Text = "0.";
			this.tbxFreeBookCount.Text = "1";
			//this.tbxTotalAmt.Text = "0";
			this.tbxColorTime.Text = "0";
			this.tbxGetColorTime.Text = "0";
			this.tbxMenoTime.Text = "0";
		}
		
		
		// ���ťզX����: �s�i�p���H ����l�w�]�� 
		private void InitialContContactor()
		{
			// ��X�����ܼ�: �Ȥ�s�� 
			string strCustNo = Context.Request.QueryString["custno"].ToString().Trim();
			
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "cust");
			DataView dv1 = ds1.Tables["cust"].DefaultView;
				
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			string rowfilterstr = "1=1";
			rowfilterstr = rowfilterstr + " AND cust_custno='" + strCustNo + "'";
			dv1.RowFilter = rowfilterstr;
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
				
			// �Y�����, �h��ܬ������; �_�h�������~�T��
			if(dv1.Count > 0)
			{
				this.tbxAuName.Text = dv1[0]["cust_nm"].ToString().Trim();
				this.tbxAuTel.Text = dv1[0]["cust_tel"].ToString().Trim();
				this.tbxAuFax.Text = dv1[0]["cust_fax"].ToString().Trim();
				this.tbxAuCell.Text = dv1[0]["cust_cell"].ToString().Trim();
				this.tbxAuEmail.Text = dv1[0]["cust_email"].ToString().Trim();
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
			DataSet ds6 = new DataSet();
			this.sqlDataAdapter6.Fill(ds6, "invmfr");
			DataView dv6 = ds6.Tables["invmfr"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr6 = "1=1";
			rowfilterstr6 = rowfilterstr6 + " AND im_syscd='" + strsyscd + "'";
			rowfilterstr6 = rowfilterstr6 + " AND im_contno='" + strConto + "'";
			dv6.RowFilter = rowfilterstr6;
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
			//Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");
			
			// �Y�����v���, �h���J���	
			if (dv6.Count > 0)
			{
				// ��ܨ�������
				DataGrid1.DataSource=dv6;
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
						default:
							DataGrid1.Items[i].Cells[10].Text = "�T�p";
							break;
					}
					
					// �o���ҵ|�O
					string taxtp = DataGrid1.Items[i].Cells[11].Text.ToString().Trim();
					switch (invcd) 
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
			DataSet ds7 = new DataSet();
			this.sqlDataAdapter7.Fill(ds7, "c2_or");
			DataView dv7 = ds7.Tables["c2_or"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr7 = "1=1";
			rowfilterstr7 = rowfilterstr7 + " AND or_syscd='" + strsyscd + "'";
			rowfilterstr7 = rowfilterstr7 + " AND or_contno='" + strConto + "'";
			dv7.RowFilter = rowfilterstr7;
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv7.Count= "+ dv7.Count + "<BR>");
			//Response.Write("dv7.RowFilter= " + dv7.RowFilter + "<BR>");
			
			// �Y�����v���, �h���J���	
			if (dv7.Count > 0)
			{
				// ��ܨ�������
				Datagrid2.DataSource=dv7;
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
					DataSet ds8 = new DataSet();
					this.sqlDataAdapter8.Fill(ds8, "mtp");
					DataView dv8 = ds8.Tables["mtp"].DefaultView;
					
					// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
					// �] Row Filter: default �� 1=1 and ��L rowfilter ����
					string rowfilterstr8 = "1=1";
					rowfilterstr8 = rowfilterstr8 + " AND mtp_mtpcd='" + mtpcd + "'";
					dv8.RowFilter = rowfilterstr8;
					
					// �ˬd�ÿ�X �̫� Row Filter �����G
					//Response.Write("dv8.Count= "+ dv8.Count + "<BR>");
					//Response.Write("dv8.RowFilter= " + dv8.RowFilter + "<BR>");
					
					if(dv8.Count > 0)
					{
						// ��X �l�H���O�������
						string mtpnm = dv8[0]["mtp_nm"].ToString().Trim();
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
		
		
		// ���U ���s��z-�o���t�Ӧ���H ���s
		private void imbIMRefresh_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			// �I�s �o���t�Ӧ���H DataGrid1
			BindGrid1();
		}
		
		
		// ���U ���s��z-���x����H ���s
		private void imbORRefresh_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			// �I�s ���x����H Datagrid2
			BindGrid2();
		}
		
				
		// �x�s�s�W ���s
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			// �N�e���W�����, ��s�J��Ʈw��
			UpdateContDB();
			
		}
		
		
		// ��s��ƤJ DB Table
		private void UpdateContDB()
		{
			// ��U�e���W���� - �H�ϰ�Ӥ�
			// �t�ӤΫȤ��� ��
			string strMfrNo = this.lblMfrNo.Text.ToString().Trim();
			string strCustNo = this.lblCustNo.Text.ToString().Trim();
			
			// �X���Ѱ򥻸�� ��
			string strSyscd = "C2";
			string strContNo = this.lblContNo.Text.ToString().Trim();
			string strContType = this.ddlContType.SelectedItem.Value.ToString().Trim();
			string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString().Trim();
			string strSignDate = this.tbxSignDate.Text.ToString().Trim();
			strSignDate = strSignDate.Substring(0, 4) + strSignDate.Substring(5, 2) + strSignDate.Substring(8, 2);
			string strEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
			string strStartDate = this.tbxStartDate.Text.ToString().Trim();
			strStartDate = strStartDate.Substring(0, 4) + strStartDate.Substring(5, 2);
			string strEndDate = this.tbxEndDate.Text.ToString().Trim();
			strEndDate = strEndDate.Substring(0, 4) + strEndDate.Substring(5, 2);
			// ���O�������G 0�N��_�]�w�]�^, ���N��O
			string strfgClosed = "0";
			// �B�z lblOldContNo : �Y����r, �h�ର���T���ƭ�
			string strOldContNo = this.lblOldContNo.Text.ToString().Trim();
			// �Y strOldContNo �Ȭ� (�L���v���, �����s�X��) => Length >6; �h��s��0; �_�h�s�����¦X���s������(Length=6)
			if(strOldContNo.Length>6)
				strOldContNo = "0";
			else
				strOldContNo = Context.Request.QueryString["old_contno"].ToString().Trim();
			string strModifyDate = System.DateTime.Today.ToString("yyyyMMdd").Trim();
			string strfgPayOnce = this.rblfgPayOnce.SelectedItem.Value.ToString().Trim();
			string strModifyEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
			// ���O�������G 0�N��_�]�w�]�^, ���N��O
			string strfgCancel = "0";
			string strCreateDate = System.DateTime.Today.ToString("yyyyMMdd").Trim();
			//Response.Write("strSyscd= " + strSyscd + "<br>");
			//Response.Write("strContNo= " + strContNo + "<br>");
			//Response.Write("strContType= " + strContType + "<br>");
			//Response.Write("strSignDate= " + strSignDate + "<br>");
			//Response.Write("strEmpNo= " + strEmpNo + "<br>");
			//Response.Write("strfgClosed= " + strfgClosed + "<br>");
			//Response.Write("strOldContNo= " + strOldContNo + "<br>");
			//Response.Write("strModifyEmpNo= " + strModifyEmpNo + "<br>");
			//Response.Write("strCreateDate= " + strCreateDate + "<br>");
			
			// �X���ѲӸ`��� ��
			string strTotalJTime = this.tbxTotalJTime.Text.ToString().Trim();
			string strMadeJTime = "0";
			string strRestJTime = this.tbxTotalJTime.Text.ToString().Trim();
			string strTotalTime = this.tbxTotalTime.Text.ToString().Trim();
			string strPubTime = "0";
			string strRestTime = this.tbxTotalTime.Text.ToString().Trim();
			string strTotalAmount = this.tbxTotalAmt.Text.ToString().Trim();
			string strPaidAmount = "0";
			string strRestAmount = this.tbxTotalAmt.Text.ToString().Trim();
			string strChangeJTime = this.tbxChangeJTime.Text.ToString().Trim();
			string strFreeTime = this.tbxFreeTime.Text.ToString().Trim();
			string strADAmount = this.tbxADAmt.Text.ToString().Trim();
			string strDiscount = this.tbxDiscount.Text.ToString().Trim();
			string strFreeBookCount = this.tbxFreeBookCount.Text.ToString().Trim();
			string strPubAdAmount = "0";
			string strPubChangeAmount = "0";
			string strColorTime = this.tbxColorTime.Text.ToString().Trim();
			string strMenoTime = this.tbxMenoTime.Text.ToString().Trim();
			string strGetColorTime = this.tbxGetColorTime.Text.ToString().Trim();
			string strRestColorTime = "0";
			string strRestGetColorTime = "0";
			string strRestMenoTime = "0";
			if(this.tbxColorTime.Text.ToString().Trim() != "0")
				strRestColorTime = Convert.ToString(int.Parse(this.tbxColorTime.Text.ToString().Trim()) + int.Parse(this.tbxFreeTime.Text.ToString().Trim()));
			else
				strRestColorTime = strRestColorTime;
			if(this.tbxGetColorTime.Text.ToString().Trim() != "0")
				strRestGetColorTime = Convert.ToString(int.Parse(this.tbxGetColorTime.Text.ToString().Trim()) + int.Parse(this.tbxFreeTime.Text.ToString().Trim()));
			else
				strRestGetColorTime = strRestGetColorTime;
			if(this.tbxMenoTime.Text.ToString().Trim() != "0")
				strRestMenoTime = Convert.ToString(int.Parse(this.tbxMenoTime.Text.ToString().Trim()) + int.Parse(this.tbxFreeTime.Text.ToString().Trim()));
			else
				strRestMenoTime = strRestMenoTime;
			//Response.Write("strADAmount= " + strADAmount + "<br>");
			
			// �s�i�p���H ��
			string strAUName = this.tbxAuName.Text.ToString().Trim();
			string strAUTel = this.tbxAuTel.Text.ToString().Trim();
			string strAUFax = this.tbxAuFax.Text.ToString().Trim();
			string strAUCell = this.tbxAuCell.Text.ToString().Trim();
			string strAUEmail = this.tbxAuEmail.Text.ToString().Trim();
			
			// �s�i�p���H ��
			string strRemark = this.tarContRemark.Value.ToString().Trim();
			
			
			// ���� �N�ȶ�J sqlCommand1.Parameters ��, �H���� �s�W�J��Ʈw
			//Response.Write(this.sqlCommand5.CommandText);
			// �t�ӤΫȤ��� ��
			this.sqlCommand5.Parameters["@mfrno"].Value = strMfrNo;
			this.sqlCommand5.Parameters["@custno"].Value = strCustNo;
			
			// �X���Ѱ򥻸�� ��
			this.sqlCommand5.Parameters["@syscd"].Value = strSyscd;
			this.sqlCommand5.Parameters["@contno"].Value = strContNo;
			this.sqlCommand5.Parameters["@conttp"].Value = strContType;
			this.sqlCommand5.Parameters["@bkcd"].Value = strBkcd;
			this.sqlCommand5.Parameters["@signdate"].Value = strSignDate;
			this.sqlCommand5.Parameters["@empno"].Value = strEmpNo;
			this.sqlCommand5.Parameters["@sdate"].Value = strStartDate;
			this.sqlCommand5.Parameters["@edate"].Value = strEndDate;
			this.sqlCommand5.Parameters["@fgclosed"].Value = strfgClosed;
			this.sqlCommand5.Parameters["@oldcontno"].Value = strOldContNo;
			this.sqlCommand5.Parameters["@moddate"].Value = strModifyDate;
			this.sqlCommand5.Parameters["@fgpayonce"].Value = strfgPayOnce;
			this.sqlCommand5.Parameters["@modempno"].Value = strModifyEmpNo;
			this.sqlCommand5.Parameters["@fgcancel"].Value = strfgCancel;
			this.sqlCommand5.Parameters["@credate"].Value = strCreateDate;
			
			// �X���ѲӸ`��� ��
			this.sqlCommand5.Parameters["@totjtm"].Value = strTotalJTime;
			this.sqlCommand5.Parameters["@madejtm"].Value = strMadeJTime;
			this.sqlCommand5.Parameters["@restjtm"].Value = strRestJTime;
			this.sqlCommand5.Parameters["@disc"].Value = strDiscount;
			this.sqlCommand5.Parameters["@freetm"].Value = strFreeTime;
			this.sqlCommand5.Parameters["@tottm"].Value = strTotalTime;
			this.sqlCommand5.Parameters["@pubtm"].Value = strPubTime;
			this.sqlCommand5.Parameters["@resttm"].Value = strRestTime;
			this.sqlCommand5.Parameters["@chgjtm"].Value = strChangeJTime;
			this.sqlCommand5.Parameters["@totamt"].Value = strTotalAmount;
			this.sqlCommand5.Parameters["@pubamt"].Value = strPubAdAmount;
			this.sqlCommand5.Parameters["@chgamt"].Value = strPubChangeAmount;
			this.sqlCommand5.Parameters["@paidamt"].Value = strPaidAmount;
			this.sqlCommand5.Parameters["@restamt"].Value = strRestAmount;
			this.sqlCommand5.Parameters["@clrtm"].Value = strColorTime;
			this.sqlCommand5.Parameters["@menotm"].Value = strMenoTime;
			this.sqlCommand5.Parameters["@getclrtm"].Value = strGetColorTime;
			this.sqlCommand5.Parameters["@adamt"].Value = strADAmount;
			this.sqlCommand5.Parameters["@freebkcnt"].Value = strFreeBookCount;
			//this.sqlCommand5.Parameters["@fgpubed"].Value = "0";
			this.sqlCommand5.Parameters["@restclrtm"].Value = strRestColorTime;
			this.sqlCommand5.Parameters["@restmenotm"].Value = strRestGetColorTime;
			this.sqlCommand5.Parameters["@restgetclrtm"].Value = strRestMenoTime;
			
			// �s�i�p���H ��
			this.sqlCommand5.Parameters["@aunm"].Value = strAUName;
			this.sqlCommand5.Parameters["@autel"].Value = strAUTel;
			this.sqlCommand5.Parameters["@aufax"].Value = strAUFax;
			this.sqlCommand5.Parameters["@aucell"].Value = strAUCell;
			this.sqlCommand5.Parameters["@auemail"].Value = strAUEmail;
			
			// �Ƶ� ��
			this.sqlCommand5.Parameters["@remark"].Value = strRemark;
			
			
			// �T�{���� sqlSelectCommand5 ���\
			bool ResultFlag5 = false;
			this.sqlCommand5.Connection.Open();
			try
			{
				this.sqlCommand5.ExecuteNonQuery();
				ResultFlag5 = true;
			}
			catch(System.Data.SqlClient.SqlException ex5)
			{
				Response.Write(ex5.Message + "<br>");
				ResultFlag5 = false;
			}
			finally
			{
				this.sqlCommand5.Connection.Close();
			}
			
			// ��X���浲�G
			if (ResultFlag5)
			{
				//Response.Write("�s�W�X���Ѧ��\!<br>");
				LiteralControl litAlert5 = new LiteralControl();
				litAlert5.Text = "<script language=javascript>alert(\"�s�W�X���Ѧ��\\");</script>";
				Page.Controls.Add(litAlert5);
				
				// ��}�B�z - �X�����ˮ֪�
				Response.Redirect("ContFm_chklist.aspx");
				
			}
			else
			{
				//Response.Write("�s�W�X���ѥ���!<br>");
				LiteralControl litAlert5 = new LiteralControl();
				litAlert5.Text = "<script language=javascript>alert(\"�s�W�X���ѥ���, \n�ЦL�X�e��, �q�������s���H!\");</script>";
				Page.Controls.Add(litAlert5);
			}
			
			// �i�� �X���Ѥw�s�W�L���T��, �קK�ϥΪ̭��Ы��U '�x�s�s�W' �����s
			this.lblAddMessage.Text = "�X���Ѹ�Ƥw�s�W���\! �z�w���L '�x�s�s�W' ���s�F, �Фŭ��Ы��U!";
		}
		
		
		// ���s�W �����s
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			// ��X �s�X���ѽs��
			string strSyscd = "C2";
			string strCurrentContNo = this.lblContNo.Text.ToString().Trim();
			//Response.Write("strSyscd= " + strSyscd + ", ");
			//Response.Write("strCurrentContNo= " + strCurrentContNo + ", ");
			
			// Step 1: �R���w�s�W�� �o���t�Ӧ���H ���
			// ���� �N�ȶ�J sqlCommand2.Parameters ��, �H���� �s�W�J��Ʈw
			this.sqlCommand2.Parameters["@syscd"].Value = strSyscd;
			this.sqlCommand2.Parameters["@contno"].Value = strCurrentContNo;
			
			// �T�{���� sqlSelectCommand1 ���\
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
			
			// ��X���浲�G
			if (ResultFlag2)
			{
				//Response.Write("�R�� �o���t�Ӧ���H ���\!<br>");
				
				// �H Javascript �� window.close() �ӧi���T��
				LiteralControl litAlert2 = new LiteralControl();
				litAlert2.Text = "<script language=javascript>alert(\"�R�� �o���t�Ӧ���H ���\\");</script>";
				Page.Controls.Add(litAlert2);
			}
			else
			{
				//Response.Write("�R�� �o���t�Ӧ���H ����!<br>");
				
				// �H Javascript �� window.close() �ӧi���T��
				LiteralControl litAlert2 = new LiteralControl();
				litAlert2.Text = "<script language=javascript>alert(\"�R�� �o���t�Ӧ���H ����\");</script>";
				Page.Controls.Add(litAlert2);
			}
			
			
			// Step 2: �R���w�s�W�� ���x����H ���
			// ���� �N�ȶ�J sqlCommand3.Parameters ��, �H���� �s�W�J��Ʈw
			this.sqlCommand3.Parameters["@syscd"].Value = strSyscd;
			this.sqlCommand3.Parameters["@contno"].Value = strCurrentContNo;
			
			// �T�{���� sqlSelectCommand1 ���\
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
			
			// ��X���浲�G
			if (ResultFlag3)
			{
				//Response.Write("�R�� ���x����H ���\!<br>");
				
				// �H Javascript �� window.close() �ӧi���T��
				LiteralControl litAlert3 = new LiteralControl();
				litAlert3.Text = "<script language=javascript>alert(\"�R�� ���x����H ���\\");</script>";
				Page.Controls.Add(litAlert3);
			}
			else
			{
				//Response.Write("�R�� ���x����H ����!<br>");
				
				// �H Javascript �� window.close() �ӧi���T��
				LiteralControl litAlert3 = new LiteralControl();
				litAlert3.Text = "<script language=javascript>alert(\"�R�� ���x����H ����\");</script>";
				Page.Controls.Add(litAlert3);
			}
			
			
			// Step 3: �R���w�s�W�� �X���� ���
			// ���� �N�ȶ�J sqlCommand2.Parameters ��, �H���� �s�W�J��Ʈw
			this.sqlCommand4.Parameters["@syscd"].Value = strSyscd;
			this.sqlCommand4.Parameters["@contno"].Value = strCurrentContNo;
			
			// �T�{���� sqlSelectCommand1 ���\
			bool ResultFlag4 = false;
			this.sqlCommand4.Connection.Open();
			try
			{
				this.sqlCommand4.ExecuteNonQuery();
				ResultFlag4 = true;
			}
			catch(System.Data.SqlClient.SqlException ex4)
			{
				Response.Write(ex4.Message + "<br>");
				ResultFlag4 = false;
			}
			finally
			{
				this.sqlCommand4.Connection.Close();
			}
			
			// ��X���浲�G
			if (ResultFlag4)
			{
				//Response.Write("�R�� �X���� ���\!<br>");
				
				// �H Javascript �� window.close() �ӧi���T��
				LiteralControl litAlert4 = new LiteralControl();
				litAlert4.Text = "<script language=javascript>alert(\"�R�� �X���� ���\\");</script>";
				Page.Controls.Add(litAlert4);
			}
			else
			{
				//Response.Write("�R�� �X���� ����!<br>");
				
				// �H Javascript �� window.close() �ӧi���T��
				LiteralControl litAlert4 = new LiteralControl();
				litAlert4.Text = "<script language=javascript>alert(\"�R�� �X���� ����\");</script>";
				Page.Controls.Add(litAlert4);
			}
			
			// ��}�B�z
			Response.Redirect("../default.aspx");
		}
		
		
		// �����^���� �����s
		private void btnBack_Click(object sender, System.EventArgs e)
		{
			// ��}�B�z
			Response.Redirect("../default.aspx");
		}
		
		
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter7 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter6 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter8 = new System.Data.SqlClient.SqlDataAdapter();
			this.imbIMRefresh.Click += new System.Web.UI.ImageClickEventHandler(this.imbIMRefresh_Click);
			this.imbORRefresh.Click += new System.Web.UI.ImageClickEventHandler(this.imbORRefresh_Click);
			this.Datagrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Datagrid2_ItemCommand);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// sqlSelectCommand7
			// 
			this.sqlSelectCommand7.CommandText = "SELECT or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, o" +
				"r_tel, or_fax, or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_fgmosea F" +
				"ROM c2_or";
			this.sqlSelectCommand7.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand6
			// 
			this.sqlSelectCommand6.CommandText = "SELECT im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, " +
				"im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri FROM invmfr WHE" +
				"RE (im_syscd = \'C2\')";
			this.sqlSelectCommand6.Connection = this.sqlConnection1;
			// 
			// sqlCommand3
			// 
			this.sqlCommand3.CommandText = "DELETE FROM c2_or WHERE (or_syscd = @syscd) AND (or_contno = @contno)";
			this.sqlCommand3.Connection = this.sqlConnection1;
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommand2
			// 
			this.sqlCommand2.CommandText = "DELETE FROM invmfr WHERE (im_syscd = @syscd) AND (im_contno = @contno)";
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "INSERT INTO c2_cont (cont_syscd, cont_contno, cont_fgtemp) VALUES (@syscd, @contn" +
				"o, \'1\')";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommand5
			// 
			this.sqlCommand5.CommandText = @"UPDATE c2_cont SET cont_conttp = @conttp, cont_bkcd = @bkcd, cont_signdate = @signdate, cont_empno = @empno, cont_mfrno = @mfrno, cont_aunm = @aunm, cont_autel = @autel, cont_aufax = @aufax, cont_aucell = @aucell, cont_auemail = @auemail, cont_sdate = @sdate, cont_edate = @edate, cont_totjtm = @totjtm, cont_madejtm = @madejtm, cont_restjtm = @restjtm, cont_disc = @disc, cont_freetm = @freetm, cont_fgclosed = @fgclosed, cont_tottm = @tottm, cont_pubtm = @pubtm, cont_resttm = @resttm, cont_chgjtm = @chgjtm, cont_custno = @custno, cont_totamt = @totamt, cont_pubamt = @pubamt, cont_chgamt = @chgamt, cont_paidamt = @paidamt, cont_restamt = @restamt, cont_clrtm = @clrtm, cont_menotm = @menotm, cont_getclrtm = @getclrtm, cont_oldcontno = @oldcontno, cont_moddate = @moddate, cont_fgpayonce = @fgpayonce, cont_modempno = @modempno, cont_fgcancel = @fgcancel, cont_credate = @credate, cont_adamt = @adamt, cont_freebkcnt = @freebkcnt, cont_remark = @remark, cont_fgtemp = 0, cont_fgpubed = '0', cont_restclrtm = @restclrtm, cont_restmenotm = @restmenotm, cont_restgetclrtm = @restgetclrtm, cont_njtpcnt = '0' WHERE (cont_syscd = @syscd) AND (cont_contno = @contno)";
			this.sqlCommand5.Connection = this.sqlConnection1;
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@conttp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_conttp", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_bkcd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@signdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_signdate", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_empno", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@aunm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aunm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@autel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_autel", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@aufax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aufax", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@aucell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aucell", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@auemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_auemail", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_sdate", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@edate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_edate", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@totjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totjtm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@madejtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_madejtm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@restjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restjtm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@disc", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_disc", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@freetm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_freetm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgclosed", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgclosed", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tottm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_tottm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubtm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@resttm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_resttm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@chgjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgjtm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_custno", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@totamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totamt", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubamt", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@chgamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgamt", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@paidamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_paidamt", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@restamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restamt", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@clrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_clrtm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@menotm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_menotm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@getclrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_getclrtm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@oldcontno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_oldcontno", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgpayonce", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgpayonce", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@modempno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_modempno", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgcancel", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgcancel", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@credate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_credate", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_adamt", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@freebkcnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_freebkcnt", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@remark", System.Data.SqlDbType.Text, 16000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_remark", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@restclrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restclrtm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@restmenotm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restmenotm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@restgetclrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restgetclrtm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommand4
			// 
			this.sqlCommand4.CommandText = "DELETE FROM c2_cont WHERE (cont_syscd = @syscd) AND (cont_contno = @contno)";
			this.sqlCommand4.Connection = this.sqlConnection1;
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCommand8
			// 
			this.sqlSelectCommand8.CommandText = "SELECT mtp_mtpcd, mtp_nm FROM mtp";
			this.sqlSelectCommand8.Connection = this.sqlConnection1;
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
			this.sqlSelectCommand1.CommandText = @"SELECT cust.cust_custid, cust.cust_custno, RTRIM(cust.cust_nm) AS cust_nm, RTRIM(cust.cust_mfrno) AS cust_mfrno, cust.cust_jbti, cust.cust_tel, cust.cust_fax, mfr.mfr_mfrid, RTRIM(mfr.mfr_mfrno) AS mfr_mfrno, RTRIM(mfr.mfr_inm) AS mfr_inm, RTRIM(mfr.mfr_respnm) AS mfr_respnm, mfr.mfr_respjbti, mfr.mfr_tel, RTRIM(mfr.mfr_fax) AS mfr_fax, RTRIM(mfr.mfr_iaddr) AS mfr_iaddr, mfr.mfr_izip, mfr.mfr_regdate, cust.cust_cell, cust.cust_email, RTRIM(cust.cust_oldcustno) AS cust_oldcustno, RTRIM(cust.cust_orgisyscd) AS cust_orgisyscd, cust.cust_regdate, cust.cust_moddate, mfr.mfr_mfrno AS Expr1 FROM cust INNER JOIN mfr ON cust.cust_mfrno = mfr.mfr_mfrno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel" +
				", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srsp" +
				"n_empno FROM srspn WHERE (srspn_atype <> \'a\') AND (srspn_atype <> \'d\')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT book.bk_bkid, book.bk_bkcd, RTRIM(book.bk_nm) AS bk_nm, proj.proj_syscd, RTRIM(proj.proj_fgitri) AS proj_fgitri, proj.proj_projno, proj.proj_costctr, book.bk_bkcd + proj.proj_projno + proj.proj_costctr AS nostr, proj.proj_bkcd, proj.proj_fgitri AS Expr1 FROM book INNER JOIN proj ON book.bk_bkcd = proj.proj_bkcd WHERE (proj.proj_syscd = 'C2')";
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
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("bk_bkid", "bk_bkid"),
																																																			  new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																			  new System.Data.Common.DataColumnMapping("proj_syscd", "proj_syscd"),
																																																			  new System.Data.Common.DataColumnMapping("proj_fgitri", "proj_fgitri"),
																																																			  new System.Data.Common.DataColumnMapping("proj_projno", "proj_projno"),
																																																			  new System.Data.Common.DataColumnMapping("proj_costctr", "proj_costctr"),
																																																			  new System.Data.Common.DataColumnMapping("nostr", "nostr"),
																																																			  new System.Data.Common.DataColumnMapping("proj_bkcd", "proj_bkcd")})});
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = @"SELECT cont_contid, cont_syscd, cont_contno, cont_conttp, cont_bkcd, cont_signdate, cont_empno, cont_mfrno, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_sdate, cont_edate, cont_totjtm, cont_madejtm, cont_restjtm, cont_disc, cont_freetm, cont_fgclosed, cont_tottm, cont_pubtm, cont_resttm, cont_chgjtm, cont_custno, cont_totamt, cont_pubamt, cont_chgamt, cont_paidamt, cont_restamt, cont_clrtm, cont_menotm, cont_getclrtm, cont_oldcontno, cont_moddate, cont_fgpayonce, cont_modempno, cont_fgcancel, cont_credate, cont_adamt, cont_freebkcnt, cont_remark, cont_fgtemp, cont_fgpubed, cont_restclrtm, cont_restmenotm, cont_restgetclrtm FROM c2_cont";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT COUNT(*) AS TotalCount, MAX(cont_contno) AS MaxContNo FROM c2_cont";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter7
			// 
			this.sqlDataAdapter7.SelectCommand = this.sqlSelectCommand7;
			this.sqlDataAdapter7.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlDataAdapter6
			// 
			this.sqlDataAdapter6.SelectCommand = this.sqlSelectCommand6;
			this.sqlDataAdapter6.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
																																																				 new System.Data.Common.DataColumnMapping("cont_restgetclrtm", "cont_restgetclrtm")})});
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("TotalCount", "TotalCount"),
																																																			   new System.Data.Common.DataColumnMapping("MaxContNo", "MaxContNo")})});
			// 
			// sqlDataAdapter8
			// 
			this.sqlDataAdapter8.SelectCommand = this.sqlSelectCommand8;
			this.sqlDataAdapter8.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mtp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mtp_mtpcd", "mtp_mtpcd"),
																																																			 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
		
	}
}
