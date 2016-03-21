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
	/// Summary description for ORForm.
	/// </summary>
	public class ORForm : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox tbxORName;
		protected System.Web.UI.WebControls.TextBox tbxORMfrIName;
		protected System.Web.UI.WebControls.TextBox tbxORJobTitle;
		protected System.Web.UI.WebControls.TextBox tbxORZipcode;
		protected System.Web.UI.WebControls.TextBox tbxORAddr;
		protected System.Web.UI.WebControls.TextBox tbxORTel;
		protected System.Web.UI.WebControls.TextBox tbxORFax;
		protected System.Web.UI.WebControls.TextBox tbxORCell;
		protected System.Web.UI.WebControls.TextBox tbxOREmail;
		protected System.Web.UI.WebControls.TextBox tbxORPubCount;
		protected System.Web.UI.WebControls.DropDownList ddlORmtpcd;
		protected System.Web.UI.WebControls.DropDownList ddlORfgmosea;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.TextBox tbxORSysCode;
		protected System.Web.UI.WebControls.TextBox tbxORContNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Web.UI.WebControls.Label lblMfrInfo;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Web.UI.WebControls.TextBox tbxORUnPubCount;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblORItem;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Data.SqlClient.SqlCommand sqlCommand3;
		protected System.Web.UI.WebControls.Label lblHistoryMessage;
		protected System.Web.UI.WebControls.DataGrid Datagrid2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter6;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Web.UI.WebControls.Button btnLoadData;
		protected System.Web.UI.WebControls.Label lblPreFormName;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
	
		public ORForm()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				Response.Expires=0;
				
				// ���w�]��� - �s�WForm
				InitialData();
				
				// �P�_�O�_�n ���J���v���
				// �Y fgnew=1 ���J ���v���
				// �Y fgnew=0 ���s�X��, �õL��l���, �G���ݰ� BindGrid1()
				if(Context.Request.QueryString["fgnew"].ToString().Trim() == "1")
				{
					BindGrid1();
				}
				else
				{
					// do nothing �����J
					this.lblHistoryMessage.Text = "�L��l���, �Цۦ�s�W!<br>";
				}
				
				
				// ���� �x�s�ק���s & �ק�ɪ��o���t�Ӧ���H���Ǹ�
				this.btnModify.Visible = false;
				this.btnSave.Visible = true;
				this.btnLoadData.Visible = true;
				this.lblORItem.Visible = false;
				
				BindGrid2();
				
				
				// ��ܤU�Ԧ���� �l�H���O�N�X�� DB ��
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "mtp");
				ddlORmtpcd.DataSource=ds1;
				ddlORmtpcd.DataTextField="mtp_nm";
				ddlORmtpcd.DataValueField="mtp_mtpcd";
				ddlORmtpcd.DataBind();
				
				// ���U�Ԧ���� �w���
				ddlORmtpcd.SelectedIndex = 0;
				ddlORfgmosea.SelectedIndex = 0;
				
			}
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		// ���w�]��� - �s�WForm
		private void InitialData()
		{
			// �]�w�]��: ���n���� & ���n����
			this.tbxORPubCount.Text = "0";
			this.tbxORUnPubCount.Text = "0";
			
			
			// �ǥѫe�@�����ǨӪ��ܼƭȦr�� 
			string contno = "";
			string custno = "";
			
			// ���J�w�]��� - �X���ѽs��
			if(Context.Request.QueryString["contno"].ToString().Trim() != "" || Context.Request.QueryString["contno"].ToString().Trim() != null)
			{
				contno = Context.Request.QueryString["contno"].ToString().Trim();
				//Response.Write("contno= " + contno + "<BR>");
			}
			
			// ���J�w�]��� - ��X�t�ӽs���ΫȤ���
			if(Context.Request.QueryString["custno"].ToString().Trim() != "" || Context.Request.QueryString["custno"].ToString().Trim() != null)
			{
				custno = Context.Request.QueryString["custno"].ToString().Trim();
				//Response.Write("custno= " + custno + "<BR>");
				
				
				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
				DataSet ds3 = new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "cust");
				DataView dv3 = ds3.Tables["cust"].DefaultView;
				
				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
				string rowfilterstr3 = "1=1";
				rowfilterstr3 = rowfilterstr3 + " AND cust_custno='" + custno + "'";
				dv3.RowFilter = rowfilterstr3;
				
				// �ˬd�ÿ�X �̫� Row Filter �����G
				//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
				//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");
				
				// �Y�����, �h��ܬ������; �_�h�������~�T��
				if(dv3.Count > 0)
				{
					// ��X �Ȥ�������
					string custnm = "";
					string custjbti = "";
					string custtel = "";
					string custfax = "";
					string custcell = "";
					string custemail = "";
					string mfrno = "";
					custnm = dv3[0]["cust_nm"].ToString().Trim();
					custjbti = dv3[0]["cust_jbti"].ToString().Trim();
					custtel = dv3[0]["cust_tel"].ToString().Trim();
					custfax = dv3[0]["cust_fax"].ToString().Trim();
					custcell = dv3[0]["cust_cell"].ToString().Trim();
					custemail = dv3[0]["cust_email"].ToString().Trim();
					mfrno = dv3[0]["cust_mfrno"].ToString().Trim();
					//Response.Write("mfrno= " + mfrno + "<br>");
					
					if(custnm != "")
						this.tbxORName.Text = custnm;
					if(custjbti != "")
						this.tbxORJobTitle.Text = custjbti;
					if(custtel != "")
						this.tbxORTel.Text = custtel;
					if(custfax != "")
						this.tbxORFax.Text = custfax;
					if(custcell != "")
						this.tbxORCell.Text = custcell;
					if(custemail != "")
						this.tbxOREmail.Text = custemail;
					
					// ��� �Ȥ�s�� (not visible)
					this.lblCustNo.Text = custno;
					
					
					// ��ܼt�Ӭ������
					if(mfrno != "")
					{
						// ��� �t�Ӳνs (not visible)
						this.lblMfrNo.Text = mfrno;
						
						// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
						DataSet ds4 = new DataSet();
						this.sqlDataAdapter4.Fill(ds4, "mfr");
						DataView dv4 = ds4.Tables["mfr"].DefaultView;
					
						// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
						string rowfilterstr4 = "1=1";
						rowfilterstr4 = rowfilterstr4 + " AND mfr_mfrno='" + mfrno + "'";
						dv4.RowFilter = rowfilterstr4;
					
						// �ˬd�ÿ�X �̫� Row Filter �����G
						//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
						//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");
					
						if(dv4.Count > 0)
						{
							// ��X �t�Ӭ������
							string mfrinm = "";
							string mfrzipcode = "";
							string mfraddr = "";
							mfrinm = dv4[0]["mfr_inm"].ToString().Trim();
							mfrzipcode = dv4[0]["mfr_izip"].ToString().Trim();
							mfraddr = dv4[0]["mfr_iaddr"].ToString().Trim();
						
							if(mfrinm != "")
								this.tbxORMfrIName.Text = mfrinm;
							if(mfrzipcode != "")
								this.tbxORZipcode.Text = mfrzipcode;
							if(mfraddr != "")
								this.tbxORAddr.Text = mfraddr;
						
							// ��ܼt�ӵo���W�٤βνs
							this.lblMfrNo.Text = mfrno;
							this.lblMfrInfo.Text = "�w�]�t�ӡG" + mfrinm + " (" + mfrno + ")";
						}
					}
				}
			}
		}
		
		
		// ���J���v���
		private void BindGrid1()
		{
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "c2_or");
			DataView dv5 = ds5.Tables["c2_or"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr5 = "1=1";
			
			string old_contno = "";
			if(Context.Request.QueryString["old_contno"].ToString().Trim() != "")
			{
				old_contno = Context.Request.QueryString["old_contno"].ToString().Trim();
				rowfilterstr5 = rowfilterstr5 + " and or_contno = '" + old_contno + "'";
			}
			else
			{
				old_contno = "0";
			}
			dv5.RowFilter = rowfilterstr5;
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
			//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");
			
			// �Y�j�M���G�� "�䤣��" ���B�z
			if (dv5.Count > 0)
			{			
				DataGrid1.DataSource=dv5;
				DataGrid1.DataBind();
				
				
				// �S�O��줧��X�榡�ഫ - �ܧ�ñ��������榡
				int i;
				for(i=0; i< DataGrid1.Items.Count ; i++)
				{
					// �l�H���O�N�X
					string mtpcd =  DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
					//Response.Write("mtpcd= " + mtpcd + "<br>");
					
					// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
					DataSet ds1 = new DataSet();
					this.sqlDataAdapter1.Fill(ds1, "mtp");
					DataView dv1 = ds1.Tables["mtp"].DefaultView;
					
					// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
					// �] Row Filter: default �� 1=1 and ��L rowfilter ����
					string rowfilterstr1 = "1=1";
					rowfilterstr1 = rowfilterstr1 + " AND mtp_mtpcd='" + mtpcd + "'";
					dv1.RowFilter = rowfilterstr1;
					
					// �ˬd�ÿ�X �̫� Row Filter �����G
					//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
					//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
					
					if(dv1.Count > 0)
					{
						// ��X �l�H���O�������
						string mtpnm = dv1[0]["mtp_nm"].ToString().Trim();
						DataGrid1.Items[i].Cells[13].Text = mtpnm;
					}
					else
					{
						DataGrid1.Items[i].Cells[13].Text = "<font color='Red'>�]��Ʀ��~)</font>";
					}
					
					
					// ���~�l�H���O
					string fgmosea = DataGrid1.Items[i].Cells[14].Text.ToString().Trim();
					switch (fgmosea) 
					{
						case "0":
							DataGrid1.Items[i].Cells[14].Text = "�ꤺ";
							break;
						case "1":
							DataGrid1.Items[i].Cells[14].Text = "<font color='Red'>��~</font>";
							break;
						default:
							DataGrid1.Items[i].Cells[14].Text = "�ꤺ";
							break;
					}
					
				}
				
			}
			
		}
		
		
		// ���J �w�s�W�����
		private void BindGrid2()
		{
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "c2_or");
			DataView dv5 = ds5.Tables["c2_or"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr5 = "1=1";
			
			string contno = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
			{
				contno = Context.Request.QueryString["contno"].ToString().Trim();
				rowfilterstr5 = rowfilterstr5 + " and or_contno = '" + contno + "'";
			}
			dv5.RowFilter = rowfilterstr5;
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
			//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");
			
			// �Y�j�M���G�� "�䤣��" ���B�z
			if (dv5.Count > 0)
			{			
				Datagrid2.DataSource=dv5;
				Datagrid2.DataBind();
				
				
				// �S�O��줧��X�榡�ഫ - �ܧ�ñ��������榡
				int i;
				for(i=0; i< Datagrid2.Items.Count ; i++)
				{
					// �l�H���O�N�X
					string mtpcd =  Datagrid2.Items[i].Cells[14].Text.ToString().Trim();
					
					// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
					DataSet ds1 = new DataSet();
					this.sqlDataAdapter1.Fill(ds1, "mtp");
					DataView dv1 = ds1.Tables["mtp"].DefaultView;
					
					// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
					// �] Row Filter: default �� 1=1 and ��L rowfilter ����
					string rowfilterstr1 = "1=1";
					rowfilterstr1 = rowfilterstr1 + " AND mtp_mtpcd='" + mtpcd + "'";
					dv1.RowFilter = rowfilterstr1;
					
					// �ˬd�ÿ�X �̫� Row Filter �����G
					//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
					//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
					
					if(dv1.Count > 0)
					{
						// ��X �l�H���O�������
						string mtpnm = dv1[0]["mtp_nm"].ToString().Trim();
						Datagrid2.Items[i].Cells[14].Text = mtpnm;
					}
					else
					{
						Datagrid2.Items[i].Cells[14].Text = "�]��Ʀ��~)";
					}
					
					
					// ���~�l�H���O
					string fgmosea = Datagrid2.Items[i].Cells[15].Text.ToString().Trim();
					switch (fgmosea) 
					{
						case "0":
							Datagrid2.Items[i].Cells[15].Text = "�ꤺ";
							break;
						case "1":
							Datagrid2.Items[i].Cells[15].Text = "<font color='Red'>��~</font>";
							break;
						default:
							Datagrid2.Items[i].Cells[15].Text = "�ꤺ";
							break;
					}
					
				}
				
			}
			// �Y�����R������, ����ܴݦs���̫�@�����; �U�q���M���� bug
			else
			{
				Datagrid2.Visible = false;
			}
		}
		
		
		// �x�s�s�W ���s
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			// ���� �s�W�ʧ@ (���ˬd����H�m�W�O�_�����п�J; �Y�_, �h�s�W��)
			//CheckDuplication();
			
			// �s�W�J��Ʈw
			InsertDB();
			
			
			// Refresh Datagrid2
			Datagrid2.Visible = true;
			Datagrid2.CurrentPageIndex=0;
			BindGrid2();
		}
		
		
		// �s�W��ƤJ DB Table
		private void CheckDuplication()
		{
			// ��X �e���W����
			string strSyscd = "C2";
			string strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			string strORName = this.tbxORName.Text.ToString().Trim();
			//Response.Write("strContNo= " + strContNo + "<br>");
			//Response.Write("strORName= " + strORName + "<br>");
			
			
			// ��X�s�Ǹ�, ����X�ثe�̤j�� im_imseq+1
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "c2_or");
			DataView dv5 = ds5.Tables["c2_or"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr5 = "1=1";
			rowfilterstr5 = rowfilterstr5 + " AND or_contno='" + strContNo + "'";
			rowfilterstr5 = rowfilterstr5 + " AND or_nm='" + strORName + "'";
			dv5.RowFilter = rowfilterstr5;
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
			//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");
			
			// �Y����H�m�W���Ю�
			if (dv5.Count > 0)
			{
				// ��ܪ�l���
				InitialData();
				
				// �H Javascript �� window.close() �ӧi���T��
				LiteralControl litCloseWin = new LiteralControl();
				litCloseWin.Text = "<script language=javascript>alert(\"������H�m�W�w�s�b, �L�k�s�W�������, �Эץ���!\");</script>";
				Page.Controls.Add(litCloseWin);
			}
				// �Y���ۦP(���s���), �h�s�W�J��Ʈw��
			else
			{
				// ����s�W
				InsertDB();
			}
		}
		
		
		// �s�W��ƤJ DB Table
		private void InsertDB()
		{
			// ��X �e���W����
			string strSyscd = "C2";
			string strContNo = Context.Request.QueryString["contno"].ToString().Trim();
			string strMfrinm = this.tbxORMfrIName.Text.ToString().Trim();
			string strORName = this.tbxORName.Text.ToString().Trim();
			string strORJobTitle = this.tbxORJobTitle.Text.ToString().Trim();
			string strORZipcode = this.tbxORZipcode.Text.ToString().Trim();
			string strORAddr = this.tbxORAddr.Text.ToString().Trim();
			string strORTel = this.tbxORTel.Text.ToString().Trim();
			string strORFax = this.tbxORFax.Text.ToString().Trim();
			string strORCell = this.tbxORCell.Text.ToString().Trim();
			string strOREmail = this.tbxOREmail.Text.ToString().Trim();
			string strPubCount = this.tbxORPubCount.Text.ToString().Trim();
			string strUnPubCount = this.tbxORUnPubCount.Text.ToString().Trim();
			string strORmtpcd = this.ddlORmtpcd.SelectedItem.Value.ToString().Trim();
			string strORfgmosea = this.ddlORfgmosea.SelectedItem.Value.ToString().Trim();
			//Response.Write("strContNo= " + strContNo + "<br>");
			//Response.Write("strMfrinm= " + strMfrinm + "<br>");
			//Response.Write("strORmtpcd= " + strORmtpcd + "<br>");
			//Response.Write("strORfgmosea= " + strORfgmosea + "<br>");
			
			
			// ��X�s�Ǹ�, ����X�ثe�̤j�� im_imseq+1
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds6 = new DataSet();
			this.sqlDataAdapter6.Fill(ds6, "c2_or");
			DataView dv6 = ds6.Tables["c2_or"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr6 = "1=1";
			rowfilterstr6 = rowfilterstr6 + " AND or_contno='" + strContNo + "'";
			dv6.RowFilter = rowfilterstr6;
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
			//Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");
			
			// ��X�̷s�� �o���t�Ӧ���H�Ǹ�
			string strORItem = "01";
			if (dv6.Count > 0)
			{
				strORItem = Convert.ToString(Convert.ToInt32(dv6[0][0].ToString().Trim())+1);
				if(strORItem.Length < 2)
					strORItem = "0" + strORItem;
			}
			else
			{
				strORItem = "01";
			}
			//Response.Write("strORItem= " + strORItem + "<br>");
			
			// ���� �N�ȶ�J sqlCommand1.Parameters ��, �H���� �s�W�J��Ʈw
			//Response.Write(this.sqlCommand1.CommandText);
			this.sqlCommand1.Parameters["@syscd"].Value = strSyscd;
			this.sqlCommand1.Parameters["@contno"].Value = strContNo;
			this.sqlCommand1.Parameters["@oritem"].Value = strORItem;
			this.sqlCommand1.Parameters["@inm"].Value = strMfrinm;
			this.sqlCommand1.Parameters["@nm"].Value = strORName;
			this.sqlCommand1.Parameters["@jbti"].Value = strORJobTitle;
			this.sqlCommand1.Parameters["@zip"].Value = strORZipcode;
			this.sqlCommand1.Parameters["@addr"].Value = strORAddr;
			this.sqlCommand1.Parameters["@tel"].Value = strORTel;
			this.sqlCommand1.Parameters["@fax"].Value = strORFax;
			this.sqlCommand1.Parameters["@cell"].Value = strORCell;
			this.sqlCommand1.Parameters["@email"].Value = strOREmail;
			this.sqlCommand1.Parameters["@pubcnt"].Value = strPubCount;
			this.sqlCommand1.Parameters["@unpubcnt"].Value = strUnPubCount;
			this.sqlCommand1.Parameters["@mtpcd"].Value = strORmtpcd;
			this.sqlCommand1.Parameters["@fgmosea"].Value = strORfgmosea;
			
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
				//Response.Write("�s�W���\!<br>");
				
				// �H Javascript �� window.alert()  �ӧi���T��
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"�s�W���\\");</script>";
				Page.Controls.Add(litAlert);
				
				// �H Javascript �� window.close() �ӧi���T��
				//LiteralControl litCloseWin = new LiteralControl();
				//litCloseWin.Text = "<script language=javascript>javascript: window.close();</script>";
				//Page.Controls.Add(litCloseWin);
			}
			else
			{
				//Response.Write("�s�W����!<br>");
				
				// �H Javascript �� window.alert()  �ӧi���T��
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"�s�W����\");</script>";
				Page.Controls.Add(litAlert);
				
				// �H Javascript �� window.close() �ӧi���T��
				//LiteralControl litCloseWin = new LiteralControl();
				//litCloseWin.Text = "<script language=javascript>javascript: window.close();</script>";
				//Page.Controls.Add(litCloseWin);
			}
			// �N�e���W�ݾl��ƲM������
			ClearForm();
			
		}
		
		
		// DataGrid1 �� ���J�s�W���s �\��
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// ��X PK ��, �N������Ƹ��J �s�WForm ��
			string strsyscd = "C2";
			string strcontno = Context.Request.QueryString["old_contno"].ToString().Trim();
			string strORItem = e.Item.Cells[1].Text.ToString().Trim();
			//Response.Write("strsyscd= " + strsyscd + ", ");
			//Response.Write("strcontno= " + strcontno + ", ");
			//Response.Write("strORItem= " + strORItem + "<br>");
			
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "c2_or");
			DataView dv5 = ds5.Tables["c2_or"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr5 = "1=1";
			rowfilterstr5 = rowfilterstr5 + " AND or_syscd='" + strsyscd + "'";
			rowfilterstr5 = rowfilterstr5 + " AND or_contno='" + strcontno + "'";
			rowfilterstr5 = rowfilterstr5 + " AND or_oritem='" + strORItem + "'";
			dv5.RowFilter = rowfilterstr5;
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
			//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");
			
			// ���J���			
			if (dv5.Count > 0)
			{
				// �N�Ǹ���ܦb lblORItem; �_�h�ק�ɵL�k��X��Ǹ�
				this.lblORItem.Visible = true;
				this.lblORItem.Text = strORItem;
				
				// ��ܨ�������
				this.tbxORContNo.Text = strcontno;
				this.tbxORMfrIName.Text = dv5[0]["or_inm"].ToString().Trim();
				this.tbxORName.Text = dv5[0]["or_nm"].ToString().Trim();
				this.tbxORJobTitle.Text = dv5[0]["or_jbti"].ToString().Trim();
				this.tbxORZipcode.Text = dv5[0]["or_zip"].ToString().Trim();
				this.tbxORAddr.Text = dv5[0]["or_addr"].ToString().Trim();
				this.tbxORTel.Text = dv5[0]["or_tel"].ToString().Trim();
				this.tbxORFax.Text = dv5[0]["or_fax"].ToString().Trim();
				this.tbxORCell.Text = dv5[0]["or_cell"].ToString().Trim();
				this.tbxOREmail.Text = dv5[0]["or_email"].ToString().Trim();
				this.tbxORPubCount.Text = dv5[0]["or_pubcnt"].ToString().Trim();
				this.tbxORUnPubCount.Text = dv5[0]["or_unpubcnt"].ToString().Trim();
				// �U�z coding �L�k��X���T�� �U�Ԧ���檺�w���
				//this.ddlORmtpcd.SelectedItem.Value = dv5[0]["or_mtpcd"].ToString().Trim();
				//this.ddlORfgmosea.SelectedItem.Value = dv5[0]["or_fgmosea"].ToString().Trim();
				
				// �o�����O�N�X
				string mtpcd = dv5[0]["or_mtpcd"].ToString().Trim();
				switch (mtpcd) 
				{
					case "11":
						this.ddlORmtpcd.SelectedIndex = 0;
						break;
					case "12":
						this.ddlORmtpcd.SelectedIndex = 1;
						break;
					case "19":
						this.ddlORmtpcd.SelectedIndex = 2;
						break;
					case "21":
						this.ddlORmtpcd.SelectedIndex = 3;
						break;
					case "22":
						this.ddlORmtpcd.SelectedIndex = 4;
						break;
					case "23":
						this.ddlORmtpcd.SelectedIndex = 5;
						break;
					case "24":
						this.ddlORmtpcd.SelectedIndex = 6;
						break;
					case "26":
						this.ddlORmtpcd.SelectedIndex = 7;
						break;
					case "27":
						this.ddlORmtpcd.SelectedIndex = 8;
						break;
					case "28":
						this.ddlORmtpcd.SelectedIndex = 9;
						break;
					case "29":
						this.ddlORmtpcd.SelectedIndex = 10;
						break;
					default:
						this.ddlORmtpcd.SelectedIndex = 0;
						break;
				}
				
				// �o�����O�N�X
				string fgmosea = dv5[0]["or_fgmosea"].ToString().Trim();
				switch (fgmosea) 
				{
					case "0":
						this.ddlORfgmosea.SelectedIndex = 0;
						break;
					case "1":
						this.ddlORfgmosea.SelectedIndex = 1;
						break;
					default:
						this.ddlORfgmosea.SelectedIndex = 0;
						break;
				}
				
			}
			
			// ��� �x�s�ק���s; ���� �x�s�s�W���s
			// ���J���v��ƫ�, ���A�� �x�s�s�W, �~�|�I�s btnSave_Click()
			this.btnModify.Visible = false;
			this.btnSave.Visible = true;
		}
		
		
		// Datagrid2 �� �ק���s �\�� 
		private void Datagrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// ��X PK ��, �N������Ƹ��J �s�WForm ��
			string strsyscd = "C2";
			string strcontno = Context.Request.QueryString["contno"].ToString().Trim();
			string strORItem = e.Item.Cells[2].Text.ToString().Trim();
			//Response.Write("strsyscd= " + strsyscd + ", ");
			//Response.Write("strcontno= " + strcontno + ", ");
			///Response.Write("strORItem= " + strORItem + "<br>");
			
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "invmfr");
			DataView dv5 = ds5.Tables["invmfr"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr5 = "1=1";
			rowfilterstr5 = rowfilterstr5 + " AND or_syscd='" + strsyscd + "'";
			rowfilterstr5 = rowfilterstr5 + " AND or_contno='" + strcontno + "'";
			rowfilterstr5 = rowfilterstr5 + " AND or_oritem='" + strORItem + "'";
			dv5.RowFilter = rowfilterstr5;
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
			//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");
			
			// ���J���			
			if (dv5.Count > 0)
			{
				// �N�Ǹ���ܦb lblORItem; �_�h�ק�ɵL�k��X��Ǹ�
				this.lblORItem.Visible = true;
				this.lblORItem.Text = strORItem;
				
				// ��ܨ�������
				this.tbxORContNo.Text = strcontno;
				this.tbxORMfrIName.Text = dv5[0]["or_inm"].ToString().Trim();
				this.tbxORName.Text = dv5[0]["or_nm"].ToString().Trim();
				this.tbxORJobTitle.Text = dv5[0]["or_jbti"].ToString().Trim();
				this.tbxORZipcode.Text = dv5[0]["or_zip"].ToString().Trim();
				this.tbxORAddr.Text = dv5[0]["or_addr"].ToString().Trim();
				this.tbxORTel.Text = dv5[0]["or_tel"].ToString().Trim();
				this.tbxORFax.Text = dv5[0]["or_fax"].ToString().Trim();
				this.tbxORCell.Text = dv5[0]["or_cell"].ToString().Trim();
				this.tbxOREmail.Text = dv5[0]["or_email"].ToString().Trim();
				this.tbxORPubCount.Text = dv5[0]["or_pubcnt"].ToString().Trim();
				this.tbxORUnPubCount.Text = dv5[0]["or_unpubcnt"].ToString().Trim();
				// �U�z coding �L�k��X���T�� �U�Ԧ���檺�w���
				//this.ddlORmtpcd.SelectedItem.Value = dv5[0]["or_mtpcd"].ToString().Trim();
				//this.ddlORfgmosea.SelectedItem.Value = dv5[0]["or_fgmosea"].ToString().Trim();
				
				// �o�����O�N�X
				string mtpcd = dv5[0]["or_mtpcd"].ToString().Trim();
				switch (mtpcd) 
				{
					case "11":
						this.ddlORmtpcd.SelectedIndex = 0;
						break;
					case "12":
						this.ddlORmtpcd.SelectedIndex = 1;
						break;
					case "19":
						this.ddlORmtpcd.SelectedIndex = 2;
						break;
					case "21":
						this.ddlORmtpcd.SelectedIndex = 3;
						break;
					case "22":
						this.ddlORmtpcd.SelectedIndex = 4;
						break;
					case "23":
						this.ddlORmtpcd.SelectedIndex = 5;
						break;
					case "24":
						this.ddlORmtpcd.SelectedIndex = 6;
						break;
					case "26":
						this.ddlORmtpcd.SelectedIndex = 7;
						break;
					case "27":
						this.ddlORmtpcd.SelectedIndex = 8;
						break;
					case "28":
						this.ddlORmtpcd.SelectedIndex = 9;
						break;
					case "29":
						this.ddlORmtpcd.SelectedIndex = 10;
						break;
					default:
						this.ddlORmtpcd.SelectedIndex = 0;
						break;
				}
				
				// �o�����O�N�X
				string fgmosea = dv5[0]["or_fgmosea"].ToString().Trim();
				switch (fgmosea) 
				{
					case "0":
						this.ddlORfgmosea.SelectedIndex = 0;
						break;
					case "1":
						this.ddlORfgmosea.SelectedIndex = 1;
						break;
					default:
						this.ddlORfgmosea.SelectedIndex = 0;
						break;
				}
				
			}
			
			// ��� �x�s�ק���s; ���� �x�s�s�W���s
			this.btnModify.Visible = true;
			this.btnSave.Visible = false;
			this.btnLoadData.Visible = false;
		}
		
		
		// Datagrid2 �� �R�����s �\��
		private void Datagrid2_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// ��X PK ��, �H�y�ᰵ �R���ʧ@
			string strsyscd = "C2";
			string strcontno = Context.Request.QueryString["contno"].ToString().Trim();
			string strORItem = e.Item.Cells[2].Text.ToString().Trim();
			//Response.Write("strsyscd= " + strsyscd + ", ");
			//Response.Write("strcontno= " + strcontno + ", ");
			//Response.Write("strORItem= " + strORItem + "<br>");
			
			// ���� �N�ȶ�J sqlCommand2.Parameters ��, �H���� �s�W�J��Ʈw
			this.sqlCommand2.Parameters["@syscd"].Value = strsyscd;
			this.sqlCommand2.Parameters["@contno"].Value = strcontno;
			this.sqlCommand2.Parameters["@oritem"].Value = strORItem;
			
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
				//Response.Write("�R�����\!<br>");
				
				// �H Javascript �� window.alert()  �ӧi���T��
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"�R�����\\");</script>";
				Page.Controls.Add(litAlert);
			}
			else
			{
				//Response.Write("�R������!<br>");
				
				// �H Javascript �� window.alert()  �ӧi���T��
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"�R������\");</script>";
				Page.Controls.Add(litAlert);
			}
			
			
			// Refresh Page
			Datagrid2.CurrentPageIndex=0;
			BindGrid2();
			
			// �N�e���W�ݾl��ƲM������
			ClearForm();
			
			// ��� �x�s�ק���s; ���� �x�s�s�W���s
			this.btnModify.Visible = false;
			this.btnSave.Visible = true;
			this.btnLoadData.Visible = true;
			
			// �Y�R���Ҧ���Ʈ�, �h�����A��� Datagrid2()
			//Response.Write("Datagrid2.Items.Count= " + Datagrid2.Items.Count + "<br>");
			if(Datagrid2.Items.Count == 1)
			{
				InitialData();
			}
		}
		
		
		// �x�s�ק� ���s
		private void btnModify_Click(object sender, System.EventArgs e)
		{
			// ���� �ק�ʧ@
			ModifyDB();
			
			// Refresh Page
			Datagrid2.CurrentPageIndex=0;
			BindGrid2();
			
			// �ק令�\��, �N �x�s�ק���s���ð_��
			this.btnModify.Visible = false;
			this.btnSave.Visible = true;
			this.btnLoadData.Visible = true;
			
			// �N�e���W�ݾl��ƲM������
			ClearForm();
		}
		
		
		// �ק��� from DB Table
		private void ModifyDB()
		{
			// ��ܱ��ק蠟 ���x����H�Ǹ�
			this.lblORItem.Visible = true;
			
			// ��X �e���W����
			string strsyscd = "C2";
			string strcontno = this.tbxORContNo.Text.ToString().Trim();
			// ��X�� ����H�Ǹ� (�� DataGrid1_ItemCommand() �a�X���Ȩ� lblORItem )
			string strORItem = this.lblORItem.Text.ToString();
			string strMfrinm = this.tbxORMfrIName.Text.ToString().Trim();
			string strORName = this.tbxORName.Text.ToString().Trim();
			string strORJobTitle = this.tbxORJobTitle.Text.ToString().Trim();
			string strORZipcode = this.tbxORZipcode.Text.ToString().Trim();
			string strORAddr = this.tbxORAddr.Text.ToString().Trim();
			string strORTel = this.tbxORTel.Text.ToString().Trim();
			string strORFax = this.tbxORFax.Text.ToString().Trim();
			string strORCell = this.tbxORCell.Text.ToString().Trim();
			string strOREmail = this.tbxOREmail.Text.ToString().Trim();
			string strORPubCount = this.tbxORPubCount.Text.ToString().Trim();
			string strORUnPubCount = this.tbxORUnPubCount.Text.ToString().Trim();
			string strORmtpcd = this.ddlORmtpcd.SelectedItem.Value.ToString().Trim();
			string strORfgmosea = this.ddlORfgmosea.SelectedItem.Value.ToString().Trim();
			//Response.Write("strimseq= " + strimseq + "<br>");
			//Response.Write("strIMName= " + strIMName + "<br>");
			//Response.Write("strORmtpcd= " + strORmtpcd + "<br>");
			//Response.Write("strORfgmosea= " + strORfgmosea + "<br>");
			
			// ���� �N�ȶ�J sqlCommand3.Parameters ��, �H���� �s�W�J��Ʈw
			// �`�N: �� sqlCommand3 (update) ���� Web Form Designer generated code �B, ��ʭק�� sql���O �� Variant �אּ�p VarChar ����
			this.sqlCommand3.Parameters["@inm"].Value = strMfrinm;
			this.sqlCommand3.Parameters["@nm"].Value = strORName;
			this.sqlCommand3.Parameters["@jbti"].Value = strORJobTitle;
			this.sqlCommand3.Parameters["@zip"].Value = strORZipcode;
			this.sqlCommand3.Parameters["@addr"].Value = strORAddr;
			this.sqlCommand3.Parameters["@tel"].Value = strORTel;
			this.sqlCommand3.Parameters["@fax"].Value = strORFax;
			this.sqlCommand3.Parameters["@cell"].Value = strORCell;
			this.sqlCommand3.Parameters["@email"].Value = strOREmail;
			this.sqlCommand3.Parameters["@pubcnt"].Value = strORPubCount;
			this.sqlCommand3.Parameters["@unpubcnt"].Value = strORUnPubCount;
			this.sqlCommand3.Parameters["@mtpcd"].Value = strORmtpcd;
			this.sqlCommand3.Parameters["@fgmosea"].Value = strORfgmosea;
			this.sqlCommand3.Parameters["@syscd"].Value = strsyscd;
			this.sqlCommand3.Parameters["@contno"].Value = strcontno;
			this.sqlCommand3.Parameters["@oritem"].Value = strORItem;
			
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
				//Response.Write("�ק令�\!<br>");
				
				// �H Javascript �� window.alert()  �ӧi���T��
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"�ק令�\\");</script>";
				Page.Controls.Add(litAlert);
			}
			else
			{
				//Response.Write("�ק異��!<br>");
				
				// �H Javascript �� window.alert()  �ӧi���T��
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"�ק異��\");</script>";
				Page.Controls.Add(litAlert);
			}
			
		}
		
		
		// �N�e���W�ݾl���(���U �s�W/�ק�/�R����) �M��
		private void ClearForm()
		{
			// �N�e���W�ݾl��ƲM������
			// �`�N: �U�Ԧ���� �n�ϥ� SelectedIndex ���ޥ�
			this.lblORItem.Text = "";
			//this.tbxORContNo.Text = "";
			this.tbxORMfrIName.Text = "";
			this.tbxORName.Text = "";
			this.tbxORJobTitle.Text = "";
			this.tbxORZipcode.Text = "";
			this.tbxORAddr.Text = "";
			this.tbxORTel.Text = "";
			this.tbxORFax.Text = "";
			this.tbxORCell.Text = "";
			this.tbxOREmail.Text = "";
			this.tbxORPubCount.Text = "";
			this.tbxORUnPubCount.Text = "";
			this.ddlORmtpcd.SelectedIndex = 0;
			this.ddlORfgmosea.SelectedIndex = 0;
		}
		
		
		// ���J�w�]��� - �t�ӤΫȤ���
		private void btnLoadData_Click(object sender, System.EventArgs e)
		{
			// 
			InitialData();
		}
		
		
		// �Y�� �l�H���O�N�X �ܧ��, �h�]�ܧ� ���~�l�H���O
		private void ddlORmtpcd_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// ��X �l�H���O�N�X
			int mtpcd = Convert.ToInt16(this.ddlORmtpcd.SelectedItem.Value.ToString().Trim());
			//Response.Write("mtpcd= " + mtpcd + "<br>");
			
			// �ܧ� �U�Ԧ���� - ���~�l�H
			if(mtpcd >= 20)
				this.ddlORfgmosea.SelectedIndex = 1;
			else
				this.ddlORfgmosea.SelectedIndex = 0;
		}
		
		
		
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter6 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.ddlORmtpcd.SelectedIndexChanged += new System.EventHandler(this.ddlORmtpcd_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			this.Datagrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Datagrid2_ItemCommand);
			this.Datagrid2.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Datagrid2_DeleteCommand);
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT cust_custno, cust_nm, cust_jbti, cust_tel, cust_fax, cust_cell, cust_email" +
				", cust_mfrno FROM cust";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
//				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT cont_contid, cont_syscd, cont_contno, cont_mfrno, cont_custno FROM c2_cont" +
				"";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT mtp_mtpcd, RTRIM(mtp_nm) AS mtp_nm FROM mtp";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand6
			// 
			this.sqlSelectCommand6.CommandText = "SELECT MAX(or_oritem) AS MaxIMSeq, or_contno FROM c2_or WHERE (or_syscd = \'C2\') G" +
				"ROUP BY or_contno";
			this.sqlSelectCommand6.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, o" +
				"r_tel, or_fax, or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_fgmosea F" +
				"ROM c2_or WHERE (or_syscd = \'C2\')";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT mfr_mfrno, mfr_inm, mfr_iaddr, mfr_izip FROM mfr";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "cust", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																			  new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																			  new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																			  new System.Data.Common.DataColumnMapping("cust_fax", "cust_fax"),
																																																			  new System.Data.Common.DataColumnMapping("cust_cell", "cust_cell"),
																																																			  new System.Data.Common.DataColumnMapping("cust_email", "cust_email"),
																																																			  new System.Data.Common.DataColumnMapping("cust_mfrno", "cust_mfrno")})});
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_contid", "cont_contid"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mtp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mtp_mtpcd", "mtp_mtpcd"),
																																																			 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm")})});
			// 
			// sqlDataAdapter6
			// 
			this.sqlDataAdapter6.SelectCommand = this.sqlSelectCommand6;
			this.sqlDataAdapter6.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_or", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("MaxIMSeq", "MaxIMSeq"),
																																																			   new System.Data.Common.DataColumnMapping("or_contno", "or_contno")})});
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mfr", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip")})});
			// 
			// sqlCommand3
			// 
			this.sqlCommand3.CommandText = @"UPDATE c2_or SET or_inm = @inm, or_nm = @nm, or_jbti = @jbti, or_addr = @addr, or_zip = @zip, or_tel = @tel, or_fax = @fax, or_cell = @cell, or_email = @email, or_mtpcd = @mtpcd, or_pubcnt = @pubcnt, or_unpubcnt = @unpubcnt, or_fgmosea = @fgmosea WHERE (or_syscd = @syscd) AND (or_contno = @contno) AND (or_oritem = @oritem)";
			this.sqlCommand3.Connection = this.sqlConnection1;
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@inm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_inm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_nm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@addr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_addr", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_zip", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_tel", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fax", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_cell", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_email", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mtpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_mtpcd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubcnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_pubcnt", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@unpubcnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_unpubcnt", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgmosea", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fgmosea", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_oritem", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommand2
			// 
			this.sqlCommand2.CommandText = "DELETE FROM c2_or WHERE (or_syscd = @syscd) AND (or_oritem = @oritem) AND (or_con" +
				"tno = @contno)";
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = @"INSERT INTO c2_or (or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, or_tel, or_fax, or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_fgmosea) VALUES (@syscd, @contno, @oritem, @inm, @nm, @jbti, @addr, @zip, @tel, @fax, @cell, @email, @mtpcd, @pubcnt, @unpubcnt, @fgmosea)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_oritem", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@inm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_inm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_nm", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@addr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_addr", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_zip", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_tel", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fax", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_cell", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_email", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mtpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_mtpcd", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubcnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_pubcnt", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@unpubcnt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_unpubcnt", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgmosea", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "or_fgmosea", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
		
		
	}
}
