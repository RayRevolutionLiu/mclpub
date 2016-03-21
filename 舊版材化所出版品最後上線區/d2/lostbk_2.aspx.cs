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
	/// Summary description for lostbk_2.
	/// </summary>
	public class lostbk_2 : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.Label lblConttp;
		protected System.Web.UI.WebControls.Label lblContsdate;
		protected System.Web.UI.WebControls.Label lblContedate;
		protected System.Web.UI.WebControls.Label lblfgClosed;
		protected System.Web.UI.WebControls.Label lblfgCancel;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Web.UI.WebControls.Label lblCustName;
		protected System.Web.UI.WebControls.Label lblMfrIName;
		protected System.Web.UI.WebControls.Label lblORName;
		protected System.Web.UI.WebControls.Label lblORmtpcd;
		protected System.Web.UI.WebControls.Label lblORZipcode;
		protected System.Web.UI.WebControls.Label lblORAddr;
		protected System.Web.UI.WebControls.Label lblLostSeq;
		protected System.Web.UI.WebControls.DropDownList ddlSendFlag;
		protected System.Web.UI.HtmlControls.HtmlTextArea textarea1;
		protected System.Web.UI.HtmlControls.HtmlTextArea textarea2;
		protected System.Web.UI.WebControls.TextBox tbxLostDate;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
	
		public lostbk_2()
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
				
				// ��X��l��� - �����ܼ�
				InitialData();
				
				// ���J �X��/�Ȥ�/����H �������
				LoadContData();
				
				// ���w �ʮѸ�� (�t�θ��)
				GetLostData();
			}
		}
		
		
		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		// ��X��l��� - �����ܼ�
		private void InitialData()
		{
			// ��X�����ܼ�
			string strContNo = "";
			string strORItem = "";
			string strContSEdate = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
				strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			else
				strContNo = strContNo;
			this.lblContNo.Text = strContNo;
			
			if(Context.Request.QueryString["oritem"].ToString().Trim() != "")
				strORItem = Context.Request.QueryString["oritem"].ToString().Trim();
			else
				strORItem = strORItem;
			
		}
		
		
		// ���J �X��/�Ȥ�/���x����H �������
		private void LoadContData()
		{
			// ��X�����ܼ�
			string strContNo = "";
			string strORItem = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
				strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			else
				strContNo = strContNo;
			
			if(Context.Request.QueryString["oritem"].ToString().Trim() != "")
				strORItem = Context.Request.QueryString["oritem"].ToString().Trim();
			else
				strORItem = strORItem;
			
			
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_cont");
			DataView dv1 = ds1.Tables["c2_cont"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� cust_mfrno and ��L rowfilter ����
			string rowfilterstr1 = " 1=1 ";
			rowfilterstr1 = rowfilterstr1 + " AND cont_contno='" + strContNo + "'";
			rowfilterstr1 = rowfilterstr1 + " AND or_oritem='" + strORItem + "'";
			dv1.RowFilter = rowfilterstr1;
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
			
			// �����, �ña�X������� ���B�z
			if (dv1.Count > 0)
			{
				// �X���� ��ư�
				string conttp = dv1[0]["cont_conttp"].ToString().Trim();
				string conttpText = "";
				if(conttp == "01")
					conttpText = "�@��X��";
				else if(conttp == "09")
					conttpText = "<font color='Red'>���s�X��</font>";
				this.lblConttp.Text = conttpText;
				string fgclosed = dv1[0]["cont_fgclosed"].ToString().Trim();
				string fgclosedText= "";
				if(fgclosed == "0")
					fgclosedText = "�_";
				else
					fgclosedText = "<font color='Red'>�O</font>";
				this.lblfgClosed.Text = fgclosedText;
				string fgCancel = "";
				string fgCancelText = "";
				fgCancel = dv1[0]["cont_fgcancel"].ToString().Trim();
				if(fgCancel == "0")
					fgCancelText = "�_";
				else
					fgCancelText = "<font color='Red'>�O</font>";
				this.lblfgCancel.Text = fgCancelText;
				// �X���_��
				string sdate = "";
				string edate = "";
				if(dv1[0]["cont_sdate"].ToString().Trim().Length >= 6)
				{
					sdate = dv1[0]["cont_sdate"].ToString().Trim();
					sdate = sdate.Substring(0, 4) + "/" + sdate.Substring(4, 2);
				}
				else
				{
					sdate = sdate;
				}
				if(dv1[0]["cont_edate"].ToString().Trim().Length >= 6)
				{
					edate = dv1[0]["cont_edate"].ToString().Trim();
					edate = edate .Substring(0, 4) + "/" + edate .Substring(4, 2);
				}
				else
				{
					edate = edate;
				}
				this.lblContsdate.Text = sdate;
				this.lblContedate.Text = edate;
				
				
				// �Ȥ� ��ư�
				this.lblCustNo.Text = dv1[0]["cont_custno"].ToString().Trim();
				this.lblCustName.Text = dv1[0]["cust_nm"].ToString().Trim();
				this.lblMfrIName.Text = dv1[0]["mfr_inm"].ToString().Trim() + " (" + dv1[0]["cont_mfrno"].ToString().Trim() + ")";
				
				// ���x����H ��ư�
				this.lblORName.Text = dv1[0]["or_nm"].ToString().Trim();
				this.lblORZipcode.Text = dv1[0]["or_zip"].ToString().Trim();
				this.lblORAddr.Text = dv1[0]["or_addr"].ToString().Trim();
				this.lblORmtpcd.Text = dv1[0]["mtp_nm"].ToString().Trim();
			}
				// �Y��L��ƪ��B�z
			else
			{
				this.lblConttp.Text = "<font color='Gray'>(�L���)</font>";
				this.lblfgClosed.Text = "<font color='Gray'>(�L���)</font>";
				this.lblfgCancel.Text = "<font color='Gray'>(�L���)</font>";
				this.lblCustNo.Text = "<font color='Gray'>(�L���)</font>";
				this.lblCustName.Text = "<font color='Gray'>(�L���)</font>";
				this.lblMfrIName.Text = "<font color='Gray'>(�L���)</font>";
				this.lblORName.Text = "<font color='Gray'>(�L���)</font>";
				this.lblORZipcode.Text = "<font color='Gray'>(�L���)</font>";
				this.lblORAddr.Text = "<font color='Gray'>(�L���)</font>";
				this.lblORmtpcd.Text = "<font color='Gray'>(�L���)</font>";
				
				this.lblMessage.Text = "�ܩ�p, �䤣�즹�X���s�����������!";
			}
			
		}
		
		
		// ��X �ʮѸ��
		private void GetLostData()
		{
			// ��X�����ܼ�
			string strContNo = "";
			string strORItem = "";
			string strLostSeq = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
				strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			else
				strContNo = strContNo;
			
			if(Context.Request.QueryString["oritem"].ToString().Trim() != "")
				strORItem = Context.Request.QueryString["oritem"].ToString().Trim();
			else
				strORItem = strORItem;
			
			if(Context.Request.QueryString["lstseq"].ToString().Trim() != "")
				strLostSeq = Context.Request.QueryString["lstseq"].ToString().Trim();
			else
				strLostSeq = strLostSeq;
			
			
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c2_lost");
			DataView dv2 = ds2.Tables["c2_lost"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� cust_mfrno and ��L rowfilter ����
			string rowfilterstr2 = " 1=1 ";
			rowfilterstr2 = rowfilterstr2 + " AND lst_contno='" + strContNo + "'";
			rowfilterstr2 = rowfilterstr2 + " AND lst_oritem='" + strORItem + "'";
			rowfilterstr2 = rowfilterstr2 + " AND lst_seq='" + strLostSeq + "'";
			dv2.RowFilter = rowfilterstr2;
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
			
			// �����, �ña�X������� ���B�z
			if (dv2.Count > 0)
			{
				// �ʮѤ��
				string strLostDate = dv2[0]["lst_date"].ToString().Trim();
				strLostDate = strLostDate.Substring(0, 4) + "/" + strLostDate.Substring(4, 2) + "/" + strLostDate.Substring(6, 2);
				this.tbxLostDate.Text = strLostDate;
				
				// �ʮѤ��e
				this.textarea1.Value = dv2[0]["lst_cont"].ToString().Trim();
				
				// �ʮѭ�]
				this.textarea2.Value = dv2[0]["lst_rea"].ToString().Trim();
				
				// �w�H�X���O
				this.ddlSendFlag.Items.FindByValue(dv2[0]["lst_fgsent"].ToString().Trim()).Selected = true;
				
			}
			else
			{
				this.tbxLostDate.Text = "";
			}
		}
		
		
		// �ק�ʮѸ�� ���s
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			// ��U �e���W����
			string strContNo = "";
			string strORItem = "";
			string strLostSeq = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
				strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			else
				strContNo = strContNo;
			
			if(Context.Request.QueryString["oritem"].ToString().Trim() != "")
				strORItem = Context.Request.QueryString["oritem"].ToString().Trim();
			else
				strORItem = strORItem;
			
			if(Context.Request.QueryString["lstseq"].ToString().Trim() != "")
				strLostSeq = Context.Request.QueryString["lstseq"].ToString().Trim();
			else
				strLostSeq = strLostSeq;
			
			string strLostContent = this.textarea1.Value.ToString().Trim();
			string strLostDate = "";
			if(this.tbxLostDate.Text.ToString().Trim() != "")
			{
				strLostDate = this.tbxLostDate.Text.ToString().Trim();
				if(strLostDate.Length >= 10)
				{
					strLostDate = strLostDate.Substring(0, 4) + strLostDate.Substring(5, 2) + strLostDate.Substring(8, 2);
				}
				else
					strLostDate = strLostDate;
			}
			else
				strLostDate = System.DateTime.Today.ToString("yyyyMMdd");
			string strLostReason = this.textarea2.Value.ToString().Trim();
			string strfgSent = this.ddlSendFlag.SelectedItem.Value.ToString().Trim();
			//Response.Write("strSyscd= " + strSyscd + "<br>");
			//Response.Write("strContNo= " + strContNo + "<br>");
			//Response.Write("strORItem= " + strORItem + "<br>");
			//Response.Write("strLostSeq= " + strLostSeq + "<br>");
			//Response.Write("strLostContent= " + strLostContent + "<br>");
			//Response.Write("strLostDate= " + strLostDate + "<br>");
			//Response.Write("strLostReason= " + strLostReason + "<br>");
			//Response.Write("strfgSent= " + strfgSent + "<br>");
			
			
			// ���� �x�s���
			// ���� �N�ȶ�J sqlCommand1.Parameters ��, �H���� �s�W�J��Ʈw
			this.sqlCommand1.Parameters["@contno"].Value = strContNo;
			this.sqlCommand1.Parameters["@oritem"].Value = strORItem;
			this.sqlCommand1.Parameters["@lostseq"].Value = strLostSeq;
			this.sqlCommand1.Parameters["@cont"].Value = strLostContent;
			this.sqlCommand1.Parameters["@date"].Value = strLostDate;
			this.sqlCommand1.Parameters["@rea"].Value = strLostReason;
			this.sqlCommand1.Parameters["@fgsent"].Value = strfgSent;
			
			
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
				//Response.Write("�ק令�\!<br>");
				
				// �H Javascript �� window.alert()  �ӧi���T��
				LiteralControl litAlert1 = new LiteralControl();
				litAlert1.Text = "<script language=javascript>alert(\"�ק令�\\");</script>";
				Page.Controls.Add(litAlert1);
				
				// ��}
				Response.Redirect("SaveMessage.aspx?str=modlost");
			}
			else
			{
				//Response.Write("�ק異��!<br>");
				
				// �H Javascript �� window.alert()  �ӧi���T��
				LiteralControl litAlert1 = new LiteralControl();
				litAlert1.Text = "<script language=javascript>alert(\"�ק異��\");</script>";
				Page.Controls.Add(litAlert1);
			}
		}
		
		
		// �����^�e��
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			// ��}
			Response.Redirect("lostbk_search.aspx?function1=mod");
		}
		
		
		
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT lst_syscd, lst_contno, lst_oritem, lst_seq, lst_cont, lst_date, lst_rea, l" +
				"st_fgsent, lst_sdate, lst_edate FROM c2_lost WHERE (lst_syscd = \'C2\')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
//				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_conttp, c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_custno, cust.cust_nm, mfr.mfr_inm, cust.cust_custno, mfr.mfr_mfrno, c2_cont.cont_mfrno, c2_or.or_oritem, c2_or.or_nm, c2_or.or_jbti, c2_or.or_zip, c2_or.or_addr, c2_or.or_tel, c2_or.or_fax, c2_or.or_cell, c2_or.or_email, c2_or.or_mtpcd, c2_or.or_pubcnt, c2_or.or_unpubcnt, c2_or.or_fgmosea, c2_or.or_contno, c2_or.or_syscd, c2_cont.cont_fgclosed, c2_cont.cont_fgcancel, mtp.mtp_nm, mtp.mtp_mtpcd, c2_cont.cont_bkcd, book.bk_nm, book.bk_bkcd FROM c2_cont INNER JOIN cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN c2_or ON c2_cont.cont_syscd = c2_or.or_syscd AND c2_cont.cont_contno = c2_or.or_contno INNER JOIN mtp ON c2_or.or_mtpcd = mtp.mtp_mtpcd INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_lost", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("lst_syscd", "lst_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("lst_contno", "lst_contno"),
																																																				 new System.Data.Common.DataColumnMapping("lst_oritem", "lst_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("lst_seq", "lst_seq"),
																																																				 new System.Data.Common.DataColumnMapping("lst_cont", "lst_cont"),
																																																				 new System.Data.Common.DataColumnMapping("lst_date", "lst_date"),
																																																				 new System.Data.Common.DataColumnMapping("lst_rea", "lst_rea"),
																																																				 new System.Data.Common.DataColumnMapping("lst_fgsent", "lst_fgsent"),
																																																				 new System.Data.Common.DataColumnMapping("lst_sdate", "lst_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("lst_edate", "lst_edate")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_jbti", "or_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																				 new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				 new System.Data.Common.DataColumnMapping("or_tel", "or_tel"),
																																																				 new System.Data.Common.DataColumnMapping("or_fax", "or_fax"),
																																																				 new System.Data.Common.DataColumnMapping("or_cell", "or_cell"),
																																																				 new System.Data.Common.DataColumnMapping("or_email", "or_email"),
																																																				 new System.Data.Common.DataColumnMapping("or_mtpcd", "or_mtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("or_pubcnt", "or_pubcnt"),
																																																				 new System.Data.Common.DataColumnMapping("or_unpubcnt", "or_unpubcnt"),
																																																				 new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																				 new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																				 new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm"),
																																																				 new System.Data.Common.DataColumnMapping("mtp_mtpcd", "mtp_mtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm")})});
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "UPDATE c2_lost SET lst_cont = @cont, lst_date = @date, lst_rea = @rea, lst_fgsent" +
				" = @fgsent WHERE (lst_syscd = \'C2\') AND (lst_contno = @contno) AND (lst_oritem =" +
				" @oritem) AND (lst_seq = @lostseq)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_cont", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_date", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@rea", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_rea", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgsent", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_fgsent", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lostseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_seq", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
		
	}
}
