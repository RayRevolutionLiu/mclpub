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
// XML
using System.Xml;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for cont_show.
	/// </summary>
	public class cont_show : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblCompanyName;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblMfrRespName;
		protected System.Web.UI.WebControls.Label lblMfrRespJobTitle;
		protected System.Web.UI.WebControls.Label lblMfrTel;
		protected System.Web.UI.WebControls.Label lblMfrFax;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Web.UI.WebControls.Label lblfgClosedMessage;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.DropDownList ddlContType;
		protected System.Web.UI.WebControls.TextBox hiddenfgClosed;
		protected System.Web.UI.WebControls.Label lblMazRecMessage;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenCustNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenPreXml;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenCustName;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxSignDate;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenContNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenContType;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlBookCode;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenBkcdProjCost;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenProjNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenCostCtr;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxStartDate;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxEndDate;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenEmpNo;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlfgPayOnce;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlfgITRI;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlfgClosed;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxOldContNo;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxIRName;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxIRTel;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxIRFax;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxIRCell;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxIREmail;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxIRZipcode;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxIRAddr;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxTotalJTime;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxTotalTime;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxTotalAmt;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxMadeJTime;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxPaidAmt;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxRestJTime;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxRestTime;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxRestAmt;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxChangeJTime;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxFreeTime;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxDiscount;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxColorTime;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxMenoTime;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxGetColorTime;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxAuName;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxAUTel;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxAUFax;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxAUCell;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxAUEmail;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlColorCode;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlPageSizeCode;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlLTypeCode;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenPubDetail;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter6;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter7;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter8;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand8;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrZipcode;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrName;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrRespName;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrRespJobTitle;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrTel;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrFax;
		protected System.Web.UI.WebControls.Label lblCustName;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenLoginEmpNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenSignDate;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenModEmpNo;
		protected System.Web.UI.WebControls.Label lblInvRecMessage;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenInvRec;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMazRec;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxModDate;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenIMDetail;
		protected System.Web.UI.WebControls.Label lblTotalPubCount;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrAddress;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenTotalJTime;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenModDate;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenTotalPubCount;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenTotalUnPubCount;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenOldContNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenTotalTime;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlEmpNo;
		protected System.Web.UI.HtmlControls.HtmlSelect ddlModEmpNo;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.HtmlControls.HtmlInputText tbxPubTime;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenXML;
	
		public cont_show()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{			
				///�U�Ԧ���� ���y���O
				//�ǥѫe�@�����ǨӪ��ܼƭȦr�� conttp, ��X�U�Ԧ���� ���y���O���w�]��
				string conttp = Context.Request.QueryString["conttp"].ToString().Trim();
				//Response.Write("conttp= " + conttp + "<BR>");
				hiddenContType.Value = conttp;
				//Response.Write("hiddenContType.Value= " + conttp + "<BR>");

				// �Y conttp = 01 or 09, ��ܤ��P���U�Ԧ���檺��r�έ�
				if(Context.Request.QueryString["conttp"]=="01")
					this.ddlContType.SelectedIndex = 01;
				//this.ddlContType.SelectedIndex = int.Parse(conttp);
				if(Context.Request.QueryString["conttp"]=="09")
					this.ddlContType.SelectedIndex = 02;
				
				// �H�U�P cont_new3.aspx.cs �ߤ@���P�B: ���κ�X�s���X���ѽs��, �ӥξ��v��ƧY�i
				//��ܾ��v�X���ѽs��, �õ� hiddenContNo ��
				this.lblContNo.Text = Context.Request.QueryString["old_contno"].ToString();
				hiddenContNo.Value = this.lblContNo.Text.ToString().Trim();
				//Response.Write("hiddenContNo.Value= " + hiddenContNo.Value + "<BR>");
				
			
				// �I�s InitialMyData() function
				InitialMyData();
				

				//��� [�t�ӤΫȤ��ư�] �̪��Ҧ����
				//GetMfrCust();

				// �H�U�P cont_new3.aspx.cs ���P�B
				// �n���w lblMfrNo.Text & lblCustNo.Text, �_�h��Ӹ`��ƵL�k���
				this.lblCustNo.Text = Context.Request.QueryString["custno"].ToString().Trim();

				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
				DataSet ds2 = new DataSet();
				DataView dv2;
				this.sqlDataAdapter2.Fill(ds2, "cust");
				dv2= ds2.Tables["cust"].DefaultView;
				
				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
				dv2.RowFilter = "1=1";
				//string old_contno = Context.Request.QueryString["old_contno"].ToString().Trim();
				dv2.RowFilter = dv2.RowFilter + " and cust_custno=" + lblCustNo.Text;
				
				// �ˬd�ÿ�X �̫� Row Filter �����G
				//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
				//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
				
				if(dv2.Count>0)
				{
					this.lblMfrNo.Text = dv2[0].Row["cust_mfrno"].ToString().Trim();
				}


				// �I�s LoadPreiousCont() function: �e�@���X���Ѹ��, �ú�X��X���Ѭy����
				// �Y�����v�X���ѽs�� (��ܸӫȤᦳ���v���), �h�I�s LoadPreiousCont() function
				//Response.Write("old_contno= " + Context.Request.QueryString["old_contno"].ToString() + "<BR>");
				if (Context.Request.QueryString["old_contno"].ToString()!="0")
				{
					string old_contno = Context.Request.QueryString["old_contno"].ToString().Trim();
					//Response.Write("old_contno= " + old_contno + "<BR>");
					//LoadPreiousCont();
				}
				//				// �_�h���P���ܰT�� ==> ���q�� work
				//				else if(Context.Request.QueryString["old_contno"].ToString()=="0")
				//				{
				//					//Response.Write("new<BR>");
				//					Response.Write("<Font Color=Yellow>(�A�S���I�s���v�X���Ѹ��, �Цۦ��J�Ҧ������!)</Font>");
				//				}


				// �I�s�X���x����H�� XML ���
				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
				DataSet ds1 = new DataSet();
				DataView dv1;
				this.sqlDataAdapter1.Fill(ds1, "c2_cont");
				dv1= ds1.Tables["c2_cont"].DefaultView;
				
				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
				dv1.RowFilter = "1=1";
				//string old_contno = Context.Request.QueryString["old_contno"].ToString().Trim();
				dv1.RowFilter = dv1.RowFilter + " and cont_syscd='C2' and cont_conttp='" + conttp + "' and cont_contno='" + Context.Request.QueryString["old_contno"].ToString().Trim() + "'";
				
				// �ˬd�ÿ�X �̫� Row Filter �����G
				//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
				//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
				
				// �Y�����, ��X hiddenXML ��� �� ���x����H���
				XmlNode xmlInvRec;
				XmlNode xmlMazRec;
				XmlDocument xmldoc= new XmlDocument();
				if(dv1.Count>0)
				{
					hiddenXML.Value=dv1[0].Row["cont_xmldata"].ToString().Trim();
					//Response.Write("hiddenXML.Value=" + hiddenXML.Value + "<br>");
					xmldoc.LoadXml(hiddenXML.Value);
					
					xmlInvRec =  xmldoc.SelectSingleNode("/root/�o���t�Ӹ��");
					xmlMazRec = xmldoc.SelectSingleNode("/root/���x����H���");
					//Response.Write("xmlInvRec=" + xmlInvRec.OuterXml + "<br>");
					//Response.Write("xmlMazRec=" + xmlMazRec.OuterXml + "<br>");
					// �N�o���t�Ӧ���H��ƭ� & ���x����H��ƭ� �g�J hidden ��, �n���J���
					hiddenInvRec.Value = xmlInvRec.OuterXml;
					hiddenMazRec.Value = xmlMazRec.OuterXml;
					//Response.Write("hiddenInvRec.Value=" + hiddenInvRec.Value + "<br>");
					//Response.Write("hiddenMazRec.Value=" + hiddenMazRec.Value + "<br>");
					//textarea1.Value=xmldoc.OuterXml;
					
					
					// ��X �U�Ԧ���� - �~�ȭ��u�� & �ק�~�ȭ��u��
					// (�� ddlEmpNo�� ���i�A�� dataFld="�ӿ�~�ȭ��u��" ) 
					// �U�Ԧ���椧�Ҧ��� �w�b InitialMyData() �̧�X
					
					// ��X �U�Ԧ���� �~�ȭ��u�� �w���
					string EmpNo = dv1[0].Row["cont_empno"].ToString().Trim();
					//Response.Write("ddlEmpNo= " + EmpNo + "<br>");
					for(int i=0; i<this.ddlEmpNo.Items.Count; i++)
					{
						// ��X��Ʈw���� EmpNo, �Ψ䶶�� i, ���w�U�Ԧ���檺�w���
						//Response.Write("ddlEmpNo(" + i + ").Value= " + this.ddlEmpNo.Items[i].Value + "<br>");
						if(this.ddlEmpNo.Items[i].Value.Trim()==EmpNo)
						{
							this.ddlEmpNo.SelectedIndex = i;
						}
						else
						{
							this.ddlEmpNo.SelectedIndex = 02;
						}
					}
					hiddenEmpNo.Value = EmpNo;
					

					// ��X �U�Ԧ���� �ק�~�ȭ��u�� �w���
					string ModEmpNo = dv1[0].Row["cont_modempno"].ToString().Trim();
					for(int i=0; i<this.ddlModEmpNo.Items.Count; i++)
					{
						// ��X��Ʈw���� EmpNo, �Ψ䶶�� i, ���w�U�Ԧ���檺�w���
						//Response.Write("ddlEmpNo(" + i + ").Value= " + this.ddlEmpNo.Items[i].Value + "<br>");
						if(this.ddlModEmpNo.Items[i].Value.Trim()==ModEmpNo)
						{
							this.ddlModEmpNo.SelectedIndex = i;
						}
						else
						{
							this.ddlModEmpNo.SelectedIndex = 02;
						}
					}
					hiddenModEmpNo.Value = ModEmpNo;

					
					// �`�N: ���B�P cont_new3.aspx.cs ���P�B
					// ��X�n�J�̪��u��, �@���w�]���ק�~�ȭ�����
					string LoginEmpNo = "";
					//Response.Write("Session["empid"]= " + Session["empid"].ToString().Trim() + "<br>");
					// �Y���n�J�̪����, �h��X�ç@���w�]���ק�~�ȭ�����
					if(Session["empid"]!=null && Session["empid"].ToString()!="")
					{
						LoginEmpNo = Session["empid"].ToString().Trim();
					}
						// �Y�L�n�J�̪����, �h��X�ùw��~�ȭ��� "�d�R��" (SelectedIndex = 02)
					else
					{
						LoginEmpNo = "800443";
					}
					//Response.Write("LoginEmpNo= " + LoginEmpNo + "<br>");
					
					// �`�N: ���B�P cont_new3.aspx.cs ���P�B
					// cont_main3.aspx �ק�~�ȭ���input��ܳB ���� ��dataFld�ݩ�, �_�h��ȷ|���~(�QdataFld�\��)
					hiddenLoginEmpNo.Value = LoginEmpNo;
					//Response.Write("hiddenModEmpNo.Value= " + hiddenModEmpNo.Value + "<br>");
					//Response.Write("hiddenLoginEmpNo.Value= " + hiddenLoginEmpNo.Value + "<br>");
					
				
				// ���� if(dv1.Count) 
				}
			
			// ���� if (!Page.IsPostBack)
			}
		
		}


		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		private void InitialMyData()
		{
			// ��� [�X�����e��] ñ������ΦX���}�l�餧�w�]��: ��t�Τ������	
			// ��ܦX�����餧�w�]: �t�Τ�� + �[��� 364 �� (�]���ƤH���n�D �n�X�{�X���_��j�~������e�@��, �Y364��) => �אּ 12 �Ӥ��@�~��
			//tbxSignDate.Value=System.DateTime.Today.ToString("yyyy/MM/dd").Trim();
			//tbxStartDate.Value=System.DateTime.Today.ToString("yyyy/MM").Trim();
			//tbxEndDate.Value=System.DateTime.Today.AddDays(364).ToString("yyyy/MM");
			//tbxEndDate.Value=System.DateTime.Today.AddMonths(11).ToString("yyyy/MM").Trim();
			// �̫�ק������w�]��
			//hiddenModDate.Value=System.DateTime.Today.ToString("yyyy/MM/dd").Trim();
			//Response.Write("tbxStartDate.Value= " + tbxStartDate.Value + "<br>");
			//Response.Write("hiddenModDate.Value= " + hiddenModDate.Value + "<br>");
			
			// ��ܤU�Ԧ���� ���y���O�� DB ��
			// ���� nostr, �а� sqlDataAdapter3.Select statement; 
			// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "book");
			DataView dv3=ds3.Tables["book"].DefaultView;
			ddlBookCode.DataSource=dv3;
			dv3.RowFilter="proj_fgitri=''";
			ddlBookCode.DataTextField="bk_nm";
			//ddlBookCode.DataValueField="nostr";
			// ���@�e��: ddl�ȥ� nostr �אּ bk_bkcd, �~��Ϥ���� ���y���O, �_�h�� option �Ȭ� nostr, �ӫD bk_bkcd
			ddlBookCode.DataValueField="bk_bkcd";
			ddlBookCode.DataBind();
			

			// ��ܤU�Ԧ���� �~�ȭ��� DB ��
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "srspn");
			ddlEmpNo.DataSource=ds4;
			ddlEmpNo.DataTextField="srspn_cname";
			ddlEmpNo.DataValueField="srspn_empno";
			ddlEmpNo.DataBind();
			
			/// �`�N: ���B�P cont_new3.aspx.cs ���P�B
			// ��ܤU�Ԧ���� �ק�~�ȭ��� DB ��
			ddlModEmpNo.DataSource=ds4;
			ddlModEmpNo.DataTextField="srspn_cname";
			ddlModEmpNo.DataValueField="srspn_empno";
			ddlModEmpNo.DataBind();
			
			
			// ��ܤU�Ԧ���� �s�i�g�T�� DB ��
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "c2_pgsize");
			ddlPageSizeCode.DataSource=ds5;
			ddlPageSizeCode.DataTextField="pgs_nm";
			ddlPageSizeCode.DataValueField="pgs_pgscd";
			ddlPageSizeCode.DataBind();

			// ��ܤU�Ԧ���� �s�i��m�� DB ��
			DataSet ds6 = new DataSet();
			this.sqlDataAdapter6.Fill(ds6, "c2_clr");
			ddlColorCode.DataSource=ds6;
			ddlColorCode.DataTextField="clr_nm";
			ddlColorCode.DataValueField="clr_clrcd";
			ddlColorCode.DataBind();

			// ��ܤU�Ԧ���� �s�i������ DB ��
			DataSet ds7 = new DataSet();
			this.sqlDataAdapter7.Fill(ds7, "c2_ltp");
			ddlLTypeCode.DataSource=ds7;
			ddlLTypeCode.DataTextField="ltp_nm";
			ddlLTypeCode.DataValueField="ltp_ltpcd";
			ddlLTypeCode.DataBind();

		}


		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter7 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter6 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter8 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand8 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT cont_contid, cont_syscd, cont_contno, cont_conttp, cont_bkcd, cont_signdate, cont_empno, cont_mfrno, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_sdate, cont_edate, cont_totjtm, cont_madejtm, cont_restjtm, cont_disc, cont_freetm, cont_fgclosed, cont_tottm, cont_pubtm, cont_resttm, cont_chgjtm, cont_custno, cont_totamt, cont_pubamt, cont_chgamt, cont_paidamt, cont_restamt, cont_clrtm, cont_menotm, cont_getclrtm, cont_oldcontno, cont_moddate, cont_fgpayonce, cont_xmldata, cont_modempno FROM c2_cont";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlSelectCommand7
			// 
			this.sqlSelectCommand7.CommandText = "SELECT ltp_ltpid, ltp_ltpcd, ltp_nm FROM c2_ltp";
			this.sqlSelectCommand7.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand6
			// 
			this.sqlSelectCommand6.CommandText = "SELECT clr_clrid, clr_clrcd, clr_nm FROM c2_clr";
			this.sqlSelectCommand6.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT pgs_pgsid, pgs_pgscd, pgs_nm FROM c2_pgsize";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT book.bk_bkid, book.bk_bkcd, book.bk_nm, proj.proj_syscd, proj.proj_fgitri, proj.proj_projno, proj.proj_costctr, book.bk_bkcd + proj.proj_projno + proj.proj_costctr AS nostr, proj.proj_bkcd FROM book INNER JOIN proj ON book.bk_bkcd = proj.proj_bkcd WHERE (proj.proj_syscd = 'C2')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
																																																			  new System.Data.Common.DataColumnMapping("cust_email", "cust_email")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT cust.cust_custid, cust.cust_custno, cust.cust_nm, cust.cust_mfrno, cust.cust_jbti, cust.cust_tel, cust.cust_fax, mfr.mfr_mfrid, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_respnm, mfr.mfr_respjbti, mfr.mfr_tel, mfr.mfr_fax, mfr.mfr_iaddr, mfr.mfr_izip, mfr.mfr_regdate, cust.cust_cell, cust.cust_email FROM cust INNER JOIN mfr ON cust.cust_mfrno = mfr.mfr_mfrno";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
																																																				 new System.Data.Common.DataColumnMapping("cont_xmldata", "cont_xmldata"),
																																																				 new System.Data.Common.DataColumnMapping("cont_modempno", "cont_modempno")})});
			// 
			// sqlDataAdapter7
			// 
			this.sqlDataAdapter7.SelectCommand = this.sqlSelectCommand7;
			this.sqlDataAdapter7.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_ltp", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("ltp_ltpid", "ltp_ltpid"),
																																																				new System.Data.Common.DataColumnMapping("ltp_ltpcd", "ltp_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm")})});
			// 
			// sqlDataAdapter6
			// 
			this.sqlDataAdapter6.SelectCommand = this.sqlSelectCommand6;
			this.sqlDataAdapter6.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_clr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("clr_clrid", "clr_clrid"),
																																																				new System.Data.Common.DataColumnMapping("clr_clrcd", "clr_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm")})});
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
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("srspn_id", "srspn_id"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_orgcd", "srspn_orgcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_deptcd", "srspn_deptcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_date", "srspn_date"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																			   new System.Data.Common.DataColumnMapping("Expr1", "Expr1")})});
			// 
			// sqlDataAdapter8
			// 
			this.sqlDataAdapter8.SelectCommand = this.sqlSelectCommand8;
			this.sqlDataAdapter8.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("TotalCount", "TotalCount"),
																																																			   new System.Data.Common.DataColumnMapping("MaxContNo", "MaxContNo")})});
			// 
			// sqlSelectCommand8
			// 
			this.sqlSelectCommand8.CommandText = "SELECT COUNT(*) AS TotalCount, MAX(cont_contno) AS MaxContNo FROM c2_cont";
			this.sqlSelectCommand8.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, srspn_tel, srspn_atype, srspn" +
				"_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srspn_empno, srspn_empno" +
				" AS Expr1 FROM srspn WHERE (srspn_atype <> \'a\') AND (srspn_atype <> \'d\')";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
