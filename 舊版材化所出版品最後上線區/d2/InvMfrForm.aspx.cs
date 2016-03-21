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
	/// Summary description for InvMfrForm.
	/// </summary>
	public class InvMfrForm : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox tbxIMSysCode;
		protected System.Web.UI.WebControls.TextBox tbxIMMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxIMName;
		protected System.Web.UI.WebControls.TextBox tbxIMJobTitle;
		protected System.Web.UI.WebControls.TextBox tbxIMZipcode;
		protected System.Web.UI.WebControls.TextBox tbxIMTel;
		protected System.Web.UI.WebControls.TextBox tbxIMFax;
		protected System.Web.UI.WebControls.TextBox tbxIMCell;
		protected System.Web.UI.WebControls.TextBox tbxIMEmail;
		protected System.Web.UI.WebControls.DropDownList ddlIMInvtp;
		protected System.Web.UI.WebControls.DropDownList ddlIMTaxtp;
		protected System.Web.UI.WebControls.TextBox tbxIMAddr;
		protected System.Web.UI.WebControls.DropDownList ddlIMfgITRI;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnModify;
		protected System.Web.UI.WebControls.Label lblImSeq;
		protected System.Data.SqlClient.SqlCommand sqlCommand3;
		protected System.Web.UI.WebControls.Label lblMfrInfo;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Web.UI.WebControls.DataGrid Datagrid2;
		protected System.Web.UI.WebControls.Label lblHistoryMessage;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Web.UI.WebControls.Button btnLoadData;
		protected System.Web.UI.WebControls.Button btnClearAll;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter6;
		protected System.Data.SqlClient.SqlCommand sqlCommand4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand6;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter7;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand7;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.TextBox tbxIMContNo;

		public InvMfrForm()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;

			if(!Page.IsPostBack)
			{
				Response.Expires=0;

				// ��w�]��� (�t�ӫȤ���) - �s�WForm
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
				this.lblImSeq.Visible = false;

				BindGrid2();
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
			// ��ܤU�Ԧ���� �{���W�٪� DB ��
			DataSet ds7 = new DataSet();
			this.sqlDataAdapter7.Fill(ds7, "fgitri");
			ddlIMfgITRI.DataSource=ds7;
			ddlIMfgITRI.DataTextField="fgitri_name";
			ddlIMfgITRI.DataValueField="fgitri_fgitri";
			ddlIMfgITRI.DataBind();


			// ���U�Ԧ���� �w���
			this.ddlIMInvtp.ClearSelection();
			this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
			this.ddlIMTaxtp.ClearSelection();
			ddlIMTaxtp.SelectedIndex = 0;
			this.ddlIMfgITRI.ClearSelection();
			ddlIMfgITRI.SelectedIndex = 0;


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
				DataSet ds2 = new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "cust");
				DataView dv2 = ds2.Tables["cust"].DefaultView;

				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
				string rowfilterstr2 = "1=1";
				rowfilterstr2 = rowfilterstr2 + " AND cust_custno='" + custno + "'";
				dv2.RowFilter = rowfilterstr2;

				// �ˬd�ÿ�X �̫� Row Filter �����G
				//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
				//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

				if(dv2.Count > 0)
				{
					// ��X �Ȥ�������
					string custnm = "";
					string custjbti = "";
					string custtel = "";
					string custfax = "";
					string custcell = "";
					string custemail = "";
					string mfrno = "";
					custnm = dv2[0]["cust_nm"].ToString().Trim();
					custjbti = dv2[0]["cust_jbti"].ToString().Trim();
					custtel = dv2[0]["cust_tel"].ToString().Trim();
					custfax = dv2[0]["cust_fax"].ToString().Trim();
					custcell = dv2[0]["cust_cell"].ToString().Trim();
					custemail = dv2[0]["cust_email"].ToString().Trim();
					mfrno = dv2[0]["cust_mfrno"].ToString().Trim();
					//Response.Write("mfrno= " + mfrno + "<br>");

					if(custnm != "")
						this.tbxIMName.Text = custnm;
					if(custjbti != "")
						this.tbxIMJobTitle.Text = custjbti;
					if(custtel != "")
						this.tbxIMTel.Text = custtel;
					if(custfax != "")
						this.tbxIMFax.Text = custfax;
					if(custcell != "")
						this.tbxIMCell.Text = custcell;
					if(custemail != "")
						this.tbxIMEmail.Text = custemail;

					// ��� �Ȥ�s�� (not visible)
					this.lblCustNo.Text = custno;


					// ��ܼt�Ӭ������
					if(mfrno != "")
					{
						// ��� �t�Ӳνs (not visible)
						this.lblMfrNo.Text = mfrno;

						this.tbxIMMfrNo.Text = mfrno;
						// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
						DataSet ds3 = new DataSet();
						this.sqlDataAdapter3.Fill(ds3, "mfr");
						DataView dv3 = ds3.Tables["mfr"].DefaultView;

						// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
						string rowfilterstr3 = "1=1";
						rowfilterstr3 = rowfilterstr3 + " AND mfr_mfrno='" + mfrno + "'";
						dv3.RowFilter = rowfilterstr3;

						// �ˬd�ÿ�X �̫� Row Filter �����G
						//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
						//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");

						if(dv3.Count > 0)
						{
							// ��X �t�Ӭ������
							string mfrinm = "";
							string mfrzipcode = "";
							string mfraddr = "";
							mfrinm = dv3[0]["mfr_inm"].ToString().Trim();
							mfrzipcode = dv3[0]["mfr_izip"].ToString().Trim();
							mfraddr = dv3[0]["mfr_iaddr"].ToString().Trim();

							if(mfrzipcode != "")
								this.tbxIMZipcode.Text = mfrzipcode;
							if(mfraddr != "")
								this.tbxIMAddr.Text = mfraddr;

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
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "invmfr");
			DataView dv4 = ds4.Tables["invmfr"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr4 = "1=1";

			string old_contno = "";
			if(Context.Request.QueryString["old_contno"].ToString().Trim() != "")
			{
				old_contno = Context.Request.QueryString["old_contno"].ToString().Trim();
				rowfilterstr4 = rowfilterstr4 + " and im_contno = '" + old_contno + "'";
			}
			else
			{
				old_contno = "0";
			}
			dv4.RowFilter = rowfilterstr4;
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
			//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

			// �Y�j�M���G�� "�䤣��" ���B�z
			if (dv4.Count > 0)
			{
				DataGrid1.DataSource=dv4;
				DataGrid1.DataBind();


				// �S�O��줧��X�榡�ഫ - �ܧ�ñ��������榡
				int i;
				for(i=0; i< DataGrid1.Items.Count ; i++)
				{
					// �o�����O
					string invcd =  DataGrid1.Items[i].Cells[11].Text.ToString().Trim();
					switch (invcd)
					{
						case "2":
							DataGrid1.Items[i].Cells[11].Text = "�G�p";
							DataGrid1.Items[i].Cells[11].ForeColor = Color.OrangeRed;
							break;
						case "3":
							DataGrid1.Items[i].Cells[11].Text = "�T�p";
							break;
						case "4":
							DataGrid1.Items[i].Cells[11].Text = "��L";
							DataGrid1.Items[i].Cells[11].ForeColor = Color.Green;
							break;
						case "9":
							DataGrid1.Items[i].Cells[11].Text = "���M��";
							DataGrid1.Items[i].Cells[11].ForeColor = Color.Red;
							break;
						default:
							DataGrid1.Items[i].Cells[11].Text = "�T�p";
							break;
					}

					// �o���ҵ|�O
					string taxtp = DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
					switch (taxtp)
					{
						case "1":
							DataGrid1.Items[i].Cells[12].Text = "���|5%";
							break;
						case "2":
							DataGrid1.Items[i].Cells[12].Text = "�s�|";
							DataGrid1.Items[i].Cells[12].ForeColor = Color.OrangeRed;
							break;
						case "3":
							DataGrid1.Items[i].Cells[12].Text = "�K�|";
							DataGrid1.Items[i].Cells[12].ForeColor = Color.Green;
							break;
						case "9":
							DataGrid1.Items[i].Cells[12].Text = "���M��";
							DataGrid1.Items[i].Cells[12].ForeColor = Color.Red;
							break;
						default:
							DataGrid1.Items[i].Cells[12].Text = "���|5%";
							break;
					}

					// �|�Ҥ����O
					string fgItri = DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
					switch (fgItri)
					{
						case "":
							DataGrid1.Items[i].Cells[13].Text = "�_";
							break;
						case "06":
							DataGrid1.Items[i].Cells[13].Text = "�Ҥ�";
							DataGrid1.Items[i].Cells[13].ForeColor = Color.OrangeRed;
							break;
						case "07":
							DataGrid1.Items[i].Cells[13].Text = "�|��";
							DataGrid1.Items[i].Cells[13].ForeColor = Color.Blue;
							break;
						default:
							DataGrid1.Items[i].Cells[13].Text = "�_";
							break;
					}

				}
			}

		}


		// ���J �w�s�W�����
		private void BindGrid2()
		{
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "invmfr");
			DataView dv4 = ds4.Tables["invmfr"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr4 = "1=1";

			string contno = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
			{
				contno = Context.Request.QueryString["contno"].ToString().Trim();
				rowfilterstr4 = rowfilterstr4 + " and im_contno = '" + contno + "'";
			}
			dv4.RowFilter = rowfilterstr4;
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
			//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

			// �Y�j�M���G�� "�䤣��" ���B�z
			if (dv4.Count > 0)
			{
				Datagrid2.DataSource=dv4;
				Datagrid2.DataBind();


				// �S�O��줧��X�榡�ഫ - �ܧ�ñ��������榡
				int i;
				for(i=0; i< Datagrid2.Items.Count ; i++)
				{
					// �o�����O
					string invcd =  Datagrid2.Items[i].Cells[12].Text.ToString().Trim();
					switch (invcd)
					{
						case "2":
							Datagrid2.Items[i].Cells[12].Text = "�G�p";
							Datagrid2.Items[i].Cells[12].ForeColor = Color.OrangeRed;
							break;
						case "3":
							Datagrid2.Items[i].Cells[12].Text = "�T�p";
							break;
						case "4":
							Datagrid2.Items[i].Cells[12].Text = "��L";
							Datagrid2.Items[i].Cells[12].ForeColor = Color.Green;
							break;
						case "9":
							Datagrid2.Items[i].Cells[12].Text = "���M��";
							Datagrid2.Items[i].Cells[12].ForeColor = Color.Red;
							break;
						default:
							Datagrid2.Items[i].Cells[12].Text = "�T�p";
							break;
					}

					// �o���ҵ|�O
					string taxtp = Datagrid2.Items[i].Cells[13].Text.ToString().Trim();
					switch (taxtp)
					{
						case "1":
							Datagrid2.Items[i].Cells[13].Text = "���|5%";
							break;
						case "2":
							Datagrid2.Items[i].Cells[13].Text = "�s�|";
							Datagrid2.Items[i].Cells[13].ForeColor = Color.OrangeRed;
							break;
						case "3":
							Datagrid2.Items[i].Cells[13].Text = "�K�|";
							Datagrid2.Items[i].Cells[13].ForeColor = Color.Green;
							break;
						case "9":
							Datagrid2.Items[i].Cells[13].Text = "���M��";
							Datagrid2.Items[i].Cells[13].ForeColor = Color.Red;
							break;
						default:
							Datagrid2.Items[i].Cells[13].Text = "���|5%";
							break;
					}

					// �|�Ҥ����O
					string fgItri = Datagrid2.Items[i].Cells[14].Text.ToString().Trim();
					switch (fgItri)
					{
						case "":
							Datagrid2.Items[i].Cells[14].Text = "�_";
							break;
						case "06":
							Datagrid2.Items[i].Cells[14].Text = "�Ҥ�";
							Datagrid2.Items[i].Cells[14].ForeColor = Color.OrangeRed;
							break;
						case "07":
							Datagrid2.Items[i].Cells[14].Text = "�|��";
							Datagrid2.Items[i].Cells[14].ForeColor = Color.Blue;
							break;
						default:
							Datagrid2.Items[i].Cells[14].Text = "�_";
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
			string strIMName = this.tbxIMName.Text.ToString().Trim();
			//Response.Write("strContNo= " + strContNo + "<br>");
			//Response.Write("strIMName= " + strIMName + "<br>");


			// �ˬd ����H�m�W �O�_���п�J
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "invmfr");
			DataView dv4 = ds4.Tables["invmfr"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr4  = "1=1";
			rowfilterstr4 = rowfilterstr4 + " AND im_contno='" + strContNo + "'";
			rowfilterstr4 = rowfilterstr4 + " AND im_nm='" + strIMName + "'";
			dv4.RowFilter = rowfilterstr4;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
			//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

			// �Y����H�m�W���Ю�
			if (dv4.Count > 0)
			{
				// ��ܪ�l���
				InitialData();

				// �H Javascript �� window.close() �ӧi���T��
				LiteralControl litCloseWin = new LiteralControl();
				litCloseWin.Text = "<script language=javascript>alert(\"������H�m�W�w�s�b, �U���s�W�ɽЦh�[�`�N!\");</script>";
				Page.Controls.Add(litCloseWin);

				// ����s�W
				InsertDB();
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
			string strMfrno = this.tbxIMMfrNo.Text.ToString().Trim();
			string strIMName = this.tbxIMName.Text.ToString().Trim();
			string strIMJobTitle = this.tbxIMJobTitle.Text.ToString().Trim();
			string strIMZipcode = this.tbxIMZipcode.Text.ToString().Trim();
			string strIMAddr = this.tbxIMAddr.Text.ToString().Trim();
			string strIMTel = this.tbxIMTel.Text.ToString().Trim();
			string strIMFax = this.tbxIMFax.Text.ToString().Trim();
			string strIMCell = this.tbxIMCell.Text.ToString().Trim();
			string strIMEmail = this.tbxIMEmail.Text.ToString().Trim();
			string strIMinvcd = this.ddlIMInvtp.SelectedItem.Value.ToString().Trim();
			string strIMtaxtp = this.ddlIMTaxtp.SelectedItem.Value.ToString().Trim();
			string strIMfgitri = this.ddlIMfgITRI.SelectedItem.Value.ToString().Trim();
			//Response.Write("strContNo= " + strContNo + "<br>");
			//Response.Write("strMfrno= " + strMfrno + "<br>");
			//Response.Write("strIMinvcd= " + strIMinvcd + "<br>");


			// �ˬd�t�Ӳνs: �Y�D�@��s�X(�Q��ƬҬ��Ʀr), �h���ӤH��, �h�u���\�� "�o�� ���O" �� "�G�p"
			string strFirststrMfrno = strMfrno.Substring(0, 1);
			//Response.Write("strFirststrMfrno= " + strFirststrMfrno + "<br>");
			//Response.Write("Compare(strFirststrMfrno, 'A')= " + Compare(strFirststrMfrno, 'A') + "<br>");
			//Response.Write("strFirststrMfrno.CompareTo('A')= " + strFirststrMfrno.CompareTo('A') + "<br>");
			// Syntax of Compare class: Less than zero meaning strA is greater than strB
			//if(Compare(strFirststrMfrno, 'A') > 0)
//			if(strFirststrMfrno.ToUpper().CompareTo('A') > 0)
//			if(strFirststrMfrno != "0" || strFirststrMfrno != "1" || strFirststrMfrno != "2" || strFirststrMfrno != "3" || strFirststrMfrno != "4" || strFirststrMfrno != "5" || strFirststrMfrno != "6" || strFirststrMfrno != "7" || strFirststrMfrno != "8" || strFirststrMfrno != "9")
			if(strFirststrMfrno != "0" && strFirststrMfrno != "1" && strFirststrMfrno != "2" && strFirststrMfrno != "3" && strFirststrMfrno != "4" && strFirststrMfrno != "5" && strFirststrMfrno != "6" && strFirststrMfrno != "7" && strFirststrMfrno != "8" && strFirststrMfrno != "9")
			{
				if(strIMinvcd != "2")
				{
					// �H Javascript �� window.alert()  �ӧi���T��
					LiteralControl litAlert = new LiteralControl();
					litAlert.Text = "<script language=javascript>alert(\"�۰ʧ�s�q��: �������ӤH��, �o�����O�w�󥿬��G�p\");</script>";
					Page.Controls.Add(litAlert);
				}

				// ���۰ʧ󥿤��ʧ@
				strIMinvcd = "2";
				this.ddlIMInvtp.ClearSelection();
				this.ddlIMInvtp.Items.FindByValue("2").Selected = true;
				//Response.Write("strFirststrMfrno= " + strFirststrMfrno + ", �ӤH��-�G�p<br>");
			}
//			else
//			{
//				//Response.Write("strFirststrMfrno= " + strFirststrMfrno + ", �t��-�G�p�ΤT�p<-br>");
//			}


			// ��X�s�Ǹ�, ����X�ثe�̤j�� im_imseq+1
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "invmfr");
			DataView dv5 = ds5.Tables["invmfr"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr5 = "1=1";
			rowfilterstr5 = rowfilterstr5 + " AND im_contno='" + strContNo + "'";
			dv5.RowFilter = rowfilterstr5;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
			//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

			// ��X�̷s�� �o���t�Ӧ���H�Ǹ�
			string strIMSeq = "01";
			if (dv5.Count > 0)
			{
				strIMSeq = Convert.ToString(Convert.ToInt32(dv5[0][0].ToString().Trim())+1);
				if(strIMSeq.Length < 2)
					strIMSeq = "0" + strIMSeq;
			}
			else
			{
				strIMSeq = "01";
			}
			//Response.Write("strIMSeq= " + strIMSeq + "<br>");

			// ���� �N�ȶ�J sqlCommand1.Parameters ��, �H���� �s�W�J��Ʈw
			//Response.Write(this.sqlCommand1.CommandText);
			this.sqlCommand1.Parameters["@syscd"].Value = strSyscd;
			this.sqlCommand1.Parameters["@contno"].Value = strContNo;
			this.sqlCommand1.Parameters["@imseq"].Value = strIMSeq;
			this.sqlCommand1.Parameters["@mfrno"].Value = strMfrno;
			this.sqlCommand1.Parameters["@nm"].Value = strIMName;
			this.sqlCommand1.Parameters["@jbti"].Value = strIMJobTitle;
			this.sqlCommand1.Parameters["@zip"].Value = strIMZipcode;
			this.sqlCommand1.Parameters["@addr"].Value = strIMAddr;
			this.sqlCommand1.Parameters["@tel"].Value = strIMTel;
			this.sqlCommand1.Parameters["@fax"].Value = strIMFax;
			this.sqlCommand1.Parameters["@cell"].Value = strIMCell;
			this.sqlCommand1.Parameters["@email"].Value = strIMEmail;
			this.sqlCommand1.Parameters["@invcd"].Value = strIMinvcd;
			this.sqlCommand1.Parameters["@taxtp"].Value = strIMtaxtp;
			this.sqlCommand1.Parameters["@fgitri"].Value = strIMfgitri;

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


		// DataGrid1 �� ���J��� ���s �\��
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// ���U �ק� ���s���B�z
			if(e.CommandName == "Select")
			{
				// ��X PK ��, �N������Ƹ��J �s�WForm ��
				string strsyscd = "C2";
				string strcontno = Context.Request.QueryString["old_contno"].ToString().Trim();
				string strimseq = e.Item.Cells[1].Text.ToString().Trim();
				//Response.Write("strsyscd= " + strsyscd + ", ");
				//Response.Write("strcontno= " + strcontno + ", ");
				//Response.Write("strimseq= " + strimseq + "<br>");


				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
				DataSet ds4 = new DataSet();
				this.sqlDataAdapter4.Fill(ds4, "invmfr");
				DataView dv4 = ds4.Tables["invmfr"].DefaultView;

				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
				// �] Row Filter: default �� 1=1 and ��L rowfilter ����
				string rowfilterstr4 = "1=1";
				rowfilterstr4 = rowfilterstr4 + " AND im_syscd='" + strsyscd + "'";
				rowfilterstr4 = rowfilterstr4 + " AND im_contno='" + strcontno + "'";
				rowfilterstr4 = rowfilterstr4 + " AND im_imseq='" + strimseq + "'";
				dv4.RowFilter = rowfilterstr4;

				// �ˬd�ÿ�X �̫� Row Filter �����G
				//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
				//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

				// ���J���
				if (dv4.Count > 0)
				{
					// �N�Ǹ���ܦb lblIMSeq; �_�h�ק�ɵL�k��X��Ǹ�
					this.lblImSeq.Visible = true;
					this.lblImSeq.Text = strimseq;

					// ��ܨ�������
					this.tbxIMContNo.Text = strcontno;
					this.tbxIMMfrNo.Text = dv4[0]["im_mfrno"].ToString().Trim();
					this.tbxIMName.Text = dv4[0]["im_nm"].ToString().Trim();
					this.tbxIMJobTitle.Text = dv4[0]["im_jbti"].ToString().Trim();
					this.tbxIMZipcode.Text = dv4[0]["im_zip"].ToString().Trim();
					this.tbxIMAddr.Text = dv4[0]["im_addr"].ToString().Trim();
					this.tbxIMTel.Text = dv4[0]["im_tel"].ToString().Trim();
					this.tbxIMFax.Text = dv4[0]["im_fax"].ToString().Trim();
					this.tbxIMCell.Text = dv4[0]["im_cell"].ToString().Trim();
					this.tbxIMEmail.Text = dv4[0]["im_email"].ToString().Trim();
					// �U�z coding �L�k��X���T�� �U�Ԧ���檺�w���
					//this.ddlIMInvtp.ClearSelection();
					//this.ddlIMInvtp.SelectedItem.Value = dv4[0]["im_invcd"].ToString().Trim();
					//this.ddlIMTaxtp.ClearSelection();
					//this.ddlIMTaxtp.SelectedItem.Value = dv4[0]["im_taxtp"].ToString().Trim();
					//this.ddlIMfgITRI.ClearSelection();
					//this.ddlIMfgITRI.SelectedItem.Value = dv4[0]["im_fgitri"].ToString().Trim();
					
					// �o�����O�N�X
					this.ddlIMInvtp.ClearSelection();
					string invcd = dv4[0]["im_invcd"].ToString().Trim();
					switch (invcd)
					{
						case "2":
							this.ddlIMInvtp.Items.FindByValue("2").Selected = true;
							break;
						case "3":
							this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
							break;
						case "4":
							this.ddlIMInvtp.Items.FindByValue("4").Selected = true;
							break;
						case "9":
							this.ddlIMInvtp.Items.FindByValue("9").Selected = true;
							break;
						default:
							this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
							break;
					}

					// �o���ҵ|�O
					this.ddlIMTaxtp.ClearSelection();
					string taxtp = dv4[0]["im_taxtp"].ToString().Trim();
					switch (taxtp)
					{
						case "1":
							this.ddlIMTaxtp.SelectedIndex = 0;
							break;
						case "2":
							this.ddlIMTaxtp.SelectedIndex = 1;
							break;
						case "3":
							this.ddlIMTaxtp.SelectedIndex = 2;
							break;
						case "9":
							this.ddlIMTaxtp.SelectedIndex = 3;
							break;
						default:
							this.ddlIMTaxtp.SelectedIndex = 0;
							break;
					}

					// �|�Ҥ����O
					this.ddlIMfgITRI.ClearSelection();
					string fgitri = dv4[0]["im_fgitri"].ToString().Trim();
					switch (fgitri)
					{
						case "":
							this.ddlIMfgITRI.SelectedIndex = 0;
							break;
						case "06":
							this.ddlIMfgITRI.SelectedIndex = 1;
							break;
						case "07":
							this.ddlIMfgITRI.SelectedIndex = 2;
							break;
						default:
							this.ddlIMfgITRI.SelectedIndex = 0;
							break;
					}
				}

				// �s�W���\��, �N �x�s�ק���s���ð_��
				this.btnModify.Visible = false;
				this.btnSave.Visible = true;
			}
		}


		// Datagrid2 �� �ק���s �\��
		private void Datagrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// ���U �ק� ���s���B�z
			if(e.CommandName == "Select")
			{
				// ��X PK ��, �N������Ƹ��J �s�WForm ��
				string strSyscd = "C2";
				string strContNo = Context.Request.QueryString["contno"].ToString().Trim();
				string strIMSeq = e.Item.Cells[2].Text.ToString().Trim();
				//Response.Write("strsyscd= " + strsyscd + ", ");
				//Response.Write("strcontno= " + strcontno + ", ");
				///Response.Write("strimseq= " + strimseq + "<br>");


				// �B�J�@: �ˬd�� IMSeq �O�_��������ƨϥΤ�, �Y�O, �����\�ק�
				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
				DataSet ds6 = new DataSet();
				this.sqlDataAdapter6.Fill(ds6, "c2_pub");
				DataView dv6 = ds6.Tables["c2_pub"].DefaultView;

				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
				// �] Row Filter: default �� 1=1 and ��L rowfilter ����
				string rowfilterstr6 = "1=1";
				rowfilterstr6 = rowfilterstr6 + " AND im_syscd='" + strSyscd + "'";
				rowfilterstr6 = rowfilterstr6 + " AND im_contno='" + strContNo + "'";
				rowfilterstr6 = rowfilterstr6 + " AND im_imseq='" + strIMSeq + "'";
				dv6.RowFilter = rowfilterstr6;

				// �ˬd�ÿ�X �̫� Row Filter �����G
				//Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
				//Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");

				// �Y�w�Q�����ϥ�, ����ĵ�i�T��
				if (dv6.Count > 0)
				{
					// �H Javascript �� window.alert()  �ӧi���T��
					LiteralControl litAlert1 = new LiteralControl();
					litAlert1.Text = "<script language=javascript>alert(\"�Ъ`�N�G���o���t�Ӥw�Q�����ϥ�, \\n�Фŭק�o�t����H�m�W, �y���¸�Ʀ��~�I(��L�a�}����ƥi�ק�^\");</script>";
					Page.Controls.Add(litAlert1);
					this.tbxIMName.Enabled = false;
				}
				else
				{
					this.tbxIMName.Enabled = true;
				}

				// �B�J�G: �i��ק�ʧ@
				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
				DataSet ds4 = new DataSet();
				this.sqlDataAdapter4.Fill(ds4, "invmfr");
				DataView dv4 = ds4.Tables["invmfr"].DefaultView;

				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
				// �] Row Filter: default �� 1=1 and ��L rowfilter ����
				string rowfilterstr4 = "1=1";
				rowfilterstr4 = rowfilterstr4 + " AND im_syscd='" + strSyscd + "'";
				rowfilterstr4 = rowfilterstr4 + " AND im_contno='" + strContNo + "'";
				rowfilterstr4 = rowfilterstr4 + " AND im_imseq='" + strIMSeq + "'";
				dv4.RowFilter = rowfilterstr4;

				// �ˬd�ÿ�X �̫� Row Filter �����G
				//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
				//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

				// ���J���
				if (dv4.Count > 0)
				{
					// �N�Ǹ���ܦb lblIMSeq; �_�h�ק�ɵL�k��X��Ǹ�
					this.lblImSeq.Visible = true;
					this.lblImSeq.Text = strIMSeq;

					// ��ܨ�������
					this.tbxIMContNo.Text = strContNo;
					this.tbxIMMfrNo.Text = dv4[0]["im_mfrno"].ToString().Trim();
					this.tbxIMName.Text = dv4[0]["im_nm"].ToString().Trim();
					this.tbxIMJobTitle.Text = dv4[0]["im_jbti"].ToString().Trim();
					this.tbxIMZipcode.Text = dv4[0]["im_zip"].ToString().Trim();
					this.tbxIMAddr.Text = dv4[0]["im_addr"].ToString().Trim();
					this.tbxIMTel.Text = dv4[0]["im_tel"].ToString().Trim();
					this.tbxIMFax.Text = dv4[0]["im_fax"].ToString().Trim();
					this.tbxIMCell.Text = dv4[0]["im_cell"].ToString().Trim();
					this.tbxIMEmail.Text = dv4[0]["im_email"].ToString().Trim();
					// �U�z coding �L�k��X���T�� �U�Ԧ���檺�w���
					//this.ddlIMInvtp.SelectedItem.Value = dv4[0]["im_invcd"].ToString().Trim();
					//this.ddlIMTaxtp.SelectedItem.Value = dv4[0]["im_taxtp"].ToString().Trim();
					//this.ddlIMfgITRI.SelectedItem.Value = dv4[0]["im_fgitri"].ToString().Trim();

					// �o�����O�N�X
					this.ddlIMInvtp.ClearSelection();
					string invcd = dv4[0]["im_invcd"].ToString().Trim();
					switch (invcd)
					{
						case "2":
							this.ddlIMInvtp.Items.FindByValue("2").Selected = true;
							break;
						case "3":
							this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
							break;
						case "4":
							this.ddlIMInvtp.Items.FindByValue("4").Selected = true;
							break;
						case "9":
							this.ddlIMInvtp.Items.FindByValue("9").Selected = true;
							break;
						default:
							this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
							break;
					}

					// �o���ҵ|�O
					this.ddlIMTaxtp.ClearSelection();
					string taxtp = dv4[0]["im_taxtp"].ToString().Trim();
					switch (taxtp)
					{
						case "1":
							this.ddlIMTaxtp.SelectedIndex = 0;
							break;
						case "2":
							this.ddlIMTaxtp.SelectedIndex = 1;
							break;
						case "3":
							this.ddlIMTaxtp.SelectedIndex = 2;
							break;
						case "9":
							this.ddlIMTaxtp.SelectedIndex = 3;
							break;
						default:
							this.ddlIMTaxtp.SelectedIndex = 0;
							break;
					}

					// �|�Ҥ����O
					this.ddlIMfgITRI.ClearSelection();
					string fgitri = dv4[0]["im_fgitri"].ToString().Trim();
					switch (fgitri)
					{
						case "":
							this.ddlIMfgITRI.SelectedIndex = 0;
							break;
						case "06":
							this.ddlIMfgITRI.SelectedIndex = 1;
							break;
						case "07":
							this.ddlIMfgITRI.SelectedIndex = 2;
							break;
						default:
							this.ddlIMfgITRI.SelectedIndex = 0;
							break;
					}
				}

				// ��� �x�s�ק���s; ���� �x�s�s�W���s
				this.btnModify.Visible = true;
				this.btnSave.Visible = false;
				this.btnLoadData.Visible = false;

			// ���� if(e.CommandName == "Select")
			}
		}


		// Datagrid2 �R�����s �\��
		private void Datagrid2_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// ���U �R�� ���s���B�z
			if(e.CommandName == "Delete")
			{
				// ��X PK ��, �H�y�ᰵ �R���ʧ@
				string strSyscd = "C2";
				string strContNo = Context.Request.QueryString["contno"].ToString().Trim();
				string strIMSeq = e.Item.Cells[2].Text.ToString().Trim();
				//Response.Write("strSyscd= " + strSyscd + ", ");
				//Response.Write("strContNo= " + strContNo + ", ");
				//Response.Write("strIMSeq= " + strIMSeq + "<br>");


				// �B�J�@: �ˬd�� IMSeq �O�_��������ƨϥΤ�, �Y�O, �����\�ק�
				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
				DataSet ds6 = new DataSet();
				this.sqlDataAdapter6.Fill(ds6, "c2_pub");
				DataView dv6 = ds6.Tables["c2_pub"].DefaultView;

				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
				// �] Row Filter: default �� 1=1 and ��L rowfilter ����
				string rowfilterstr6 = "1=1";
				rowfilterstr6 = rowfilterstr6 + " AND im_syscd='" + strSyscd + "'";
				rowfilterstr6 = rowfilterstr6 + " AND im_contno='" + strContNo + "'";
				rowfilterstr6 = rowfilterstr6 + " AND im_imseq='" + strIMSeq + "'";
				dv6.RowFilter = rowfilterstr6;

				// �ˬd�ÿ�X �̫� Row Filter �����G
				//Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
				//Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");

				// �Y�w�Q�����ϥ�, ����ĵ�i�T��
				if (dv6.Count > 0)
				{
					// �H Javascript �� window.alert()  �ӧi���T��
					LiteralControl litAlert1 = new LiteralControl();
					litAlert1.Text = "<script language=javascript>alert(\"�R�����ѡG���o���t�Ӥw�Q�����ϥ�, �L�k�R������\");</script>";
					Page.Controls.Add(litAlert1);
				}
				// �Y�|���Q�����ϥ�, ���\�R��
				// �B�J�G: �i��R���ʧ@
				else
				{
					// �B�J�@�G�i��R���ʧ@
					// ���� �N�ȶ�J sqlCommand2.Parameters ��, �H���� �s�W�J��Ʈw
					this.sqlCommand2.Parameters["@syscd"].Value = strSyscd;
					this.sqlCommand2.Parameters["@contno"].Value = strContNo;
					this.sqlCommand2.Parameters["@imseq"].Value = strIMSeq;

					// �T�{���� sqlCommand2 ���\
					this.sqlCommand2.Connection.Open();
					// �ϥ� Transaction �T�{������ʧ@
					System.Data.SqlClient.SqlTransaction myTrans2 = this.sqlCommand2.Connection.BeginTransaction();
					this.sqlCommand2.Transaction = myTrans2;
					try
					{
						this.sqlCommand2.ExecuteNonQuery();
						myTrans2.Commit();

						// �H Javascript �� window.alert()  �ӧi���T��
						LiteralControl litAlert = new LiteralControl();
						litAlert.Text = "<script language=javascript>alert(\"�R�����\\");</script>";
						Page.Controls.Add(litAlert);
					}
					catch(System.Data.SqlClient.SqlException ex2)
					{
						Response.Write(ex2.Message + "<br>");
						myTrans2.Rollback();

						// �H Javascript �� window.alert()  �ӧi���T��
						LiteralControl litAlert = new LiteralControl();
						litAlert.Text = "<script language=javascript>alert(\"�R������\");</script>";
						Page.Controls.Add(litAlert);
					}
					finally
					{
						this.sqlCommand2.Connection.Close();
					}


					// �B�J�G: ��X�ثe�̤j�����H�Ǹ�, �H�P�_�O�_�n�� or_oritem ����s�ʧ@
					// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
					DataSet ds5 = new DataSet();
					this.sqlDataAdapter5.Fill(ds5, "invmfr");
					DataView dv5 = ds5.Tables["invmfr"].DefaultView;

					// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
					// �] Row Filter: default �� 1=1 and ��L rowfilter ����
					string rowfilterstr5 = "1=1";
					rowfilterstr5 = rowfilterstr5 + " AND im_contno='" + strContNo + "'";
					dv5.RowFilter = rowfilterstr5;

					// �ˬd�ÿ�X �̫� Row Filter �����G
					//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
					//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

					// ��X�̷s�� ���x����H�Ǹ�
					string MaxIMSeq = "01";
					int intMaxIMSeq = Convert.ToInt16(MaxIMSeq);
					if (dv5.Count > 0)
					{
						MaxIMSeq = dv5[0]["MaxIMSeq"].ToString();
						//Response.Write("MaxIMSeq= " + MaxIMSeq + "<br>");
						intMaxIMSeq = Convert.ToInt16(MaxIMSeq);
						//Response.Write("intMaxIMSeq= " + intMaxIMSeq + "<br>");

						// �B�J�T: ��s���᪺�Ǹ����B�z
						int intCurrentIMSeq = Convert.ToInt16(strIMSeq);
						if(strIMSeq == MaxIMSeq)
						{
							//Response.Write("do nothing...��������R����ƧY�i<br>");
						}
						else
						{
							//Response.Write("�B�z��s�Ʃy<br>");


							// ��X ���U�R�����U�@�Ǹ�, ���� for loop �_�l��
							int intNextIMSeq = intCurrentIMSeq+1;
							//Response.Write("intNextIMSeq= " + intNextIMSeq + "<br>");

							// ��X�v�渨�����, ����s�丨���Ǹ����ʧ@
							for(int i=intNextIMSeq; i<=intMaxIMSeq; i++)
							{
								string stri = Convert.ToString(i);
								if(stri.Length < 2)
									stri = "0" + stri;
								//Response.Write("stri= " + stri + "<br>");

								// ��X�v�渨����Ƥ� PK
								// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
								DataSet ds4 = new DataSet();
								// �� sqlDataAdapter4 �L�o���� - ���w Parameters
								this.sqlDataAdapter4.Fill(ds4, "c2_or");
								DataView dv4 = ds4.Tables["c2_or"].DefaultView;

								// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
								// �] Row Filter: default �� 1=1 and ��L rowfilter ����
								string rowfilterstr4 = "1=1";
								rowfilterstr4 = rowfilterstr4 + " AND  im_syscd='C2' ";
								rowfilterstr4 = rowfilterstr4 + " AND  im_contno='" + strContNo + "'";
								dv4.RowFilter = rowfilterstr4;

								// �ˬd�ÿ�X �̫� Row Filter �����G
								//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
								//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

								if(dv4.Count > 0)
								{
									string iSyscd = "C2";
									string iContNo = dv4[0]["im_contno"].ToString();
									string iIMSeq = dv4[0]["im_imseq"].ToString();
									//Response.Write("iSyscd= " + iSyscd + ", ");
									//Response.Write("iContNo= " + iContNo + ", ");
									//Response.Write("iIMSeq= " + iIMSeq + "<br>");

									int intNewIMSeq = i-1;
									string strNewIMSeq = Convert.ToString(intNewIMSeq);
									if(strNewIMSeq.Length < 2)
										strNewIMSeq = "0" + strNewIMSeq;
									//Response.Write("strNewIMSeq= " + strNewIMSeq + "<br>");


									// �����s�ʧ@
									// ���� �N�ȶ�J sqlCommand4.Parameters ��, �H���� �s�W�J��Ʈw
									//Response.Write(this.sqlCommand4.CommandText);
									this.sqlCommand4.Parameters["@syscd"].Value = strSyscd;
									this.sqlCommand4.Parameters["@contno"].Value = strContNo;
									this.sqlCommand4.Parameters["@NewIMSeq"].Value = strNewIMSeq;
									this.sqlCommand4.Parameters["@imseq"].Value = stri;

									// �T�{���� sqlCommand4 ���\
									this.sqlCommand4.Connection.Open();
									// �ϥ� Transaction �T�{������ʧ@
									System.Data.SqlClient.SqlTransaction myTrans4 = this.sqlCommand4.Connection.BeginTransaction();
									this.sqlCommand4.Transaction = myTrans4;
									try
									{
										this.sqlCommand4.ExecuteNonQuery();
										myTrans4.Commit();
									}
									catch(System.Data.SqlClient.SqlException ex4)
									{
										Response.Write(ex4.Message + "<br>");
										myTrans4.Rollback();
									}
									finally
									{
										this.sqlCommand4.Connection.Close();
									}
								}
							// ���� for loop
							}
						// ���� �B�J�T else
						}
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

					// ���w�]��� - �s�WForm
					//Response.Write("Datagrid2.Items.Count= " + Datagrid2.Items.Count + "<br>");
					if(Datagrid2.Items.Count == 1)
					{
						InitialData();
					}
				}

			// ���� if(e.CommandName == "Delete")
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
			// ��ܱ��ק蠟 �o���t�Ӧ���H�Ǹ�
			this.lblImSeq.Visible = true;

			// ��X �e���W����
			string strsyscd = "C2";
			string strcontno = this.tbxIMContNo.Text.ToString().Trim();
			// ��X�� ����H�Ǹ� (�� DataGrid1_ItemCommand() �a�X���Ȩ� lblImSeq )
			string strimseq = this.lblImSeq.Text.ToString();
			string strMfrno = this.tbxIMMfrNo.Text.ToString().Trim();
			string strIMName = this.tbxIMName.Text.ToString().Trim();
			string strIMJobTitle = this.tbxIMJobTitle.Text.ToString().Trim();
			string strIMZipcode = this.tbxIMZipcode.Text.ToString().Trim();
			string strIMAddr = this.tbxIMAddr.Text.ToString().Trim();
			string strIMTel = this.tbxIMTel.Text.ToString().Trim();
			string strIMFax = this.tbxIMFax.Text.ToString().Trim();
			string strIMCell = this.tbxIMCell.Text.ToString().Trim();
			string strIMEmail = this.tbxIMEmail.Text.ToString().Trim();
			string strIMinvcd = this.ddlIMInvtp.SelectedItem.Value.ToString().Trim();
			string strIMtaxtp = this.ddlIMTaxtp.SelectedItem.Value.ToString().Trim();
			string strIMfgitri = this.ddlIMfgITRI.SelectedItem.Value.ToString().Trim();
			//Response.Write("strimseq= " + strimseq + "<br>");
			//Response.Write("strIMName= " + strIMName + "<br>");
			//Response.Write("strIMinvcd= " + strIMinvcd + "<br>");
			//Response.Write("strIMtaxtp= " + strIMtaxtp + "<br>");
			//Response.Write("strIMfgitri= " + strIMfgitri + "<br>");


			// ���q coding �P InsertDB() �̤��P�q
			// �ˬd�t�Ӳνs: �Y�D�@��s�X(�Q��ƬҬ��Ʀr), �h���ӤH��, �h�u���\�� "�o�� ���O" �� "�G�p"
			string strFirststrMfrno = strMfrno.Substring(0, 1);
			//Response.Write("strFirststrMfrno= " + strFirststrMfrno + "<br>");
//			if(strFirststrMfrno != "0" || strFirststrMfrno != "1" || strFirststrMfrno != "2" || strFirststrMfrno != "3" || strFirststrMfrno != "4" || strFirststrMfrno != "5" || strFirststrMfrno != "6" || strFirststrMfrno != "7" || strFirststrMfrno != "8" || strFirststrMfrno != "9")
			if(strFirststrMfrno != "0" && strFirststrMfrno != "1" && strFirststrMfrno != "2" && strFirststrMfrno != "3" && strFirststrMfrno != "4" && strFirststrMfrno != "5" && strFirststrMfrno != "6" && strFirststrMfrno != "7" && strFirststrMfrno != "8" && strFirststrMfrno != "9")
			{
				if(strIMinvcd != "2")
				{
					// �H Javascript �� window.alert()  �ӧi���T��
					LiteralControl litAlert = new LiteralControl();
					litAlert.Text = "<script language=javascript>alert(\"�۰ʧ�s�q��: �������ӤH��, �o�����O�w�󥿬��G�p\");</script>";
					Page.Controls.Add(litAlert);
				}

				// ���۰ʧ󥿤��ʧ@
				strIMinvcd = "2";
				this.ddlIMInvtp.ClearSelection();
				this.ddlIMInvtp.Items.FindByValue("2").Selected = true;
				//Response.Write("strFirststrMfrno= " + strFirststrMfrno + ", �ӤH��-�G�p<br>");
			}
//			else
//			{
//				//Response.Write("strFirststrMfrno= " + strFirststrMfrno + ", �t��-�G�p�ΤT�p<-br>");
//			}


			// ���� �N�ȶ�J sqlCommand3.Parameters ��, �H���� �s�W�J��Ʈw
			// �`�N: �� sqlCommand3 (update) ���� Web Form Designer generated code �B, ��ʭק�� sql���O �� Variant �אּ�p VarChar ����
			this.sqlCommand3.Parameters["@mfrno"].Value = strMfrno;
			this.sqlCommand3.Parameters["@nm"].Value = strIMName;
			this.sqlCommand3.Parameters["@jbti"].Value = strIMJobTitle;
			this.sqlCommand3.Parameters["@zip"].Value = strIMZipcode;
			this.sqlCommand3.Parameters["@addr"].Value = strIMAddr;
			this.sqlCommand3.Parameters["@tel"].Value = strIMTel;
			this.sqlCommand3.Parameters["@fax"].Value = strIMFax;
			this.sqlCommand3.Parameters["@cell"].Value = strIMCell;
			this.sqlCommand3.Parameters["@email"].Value = strIMEmail;
			this.sqlCommand3.Parameters["@invcd"].Value = strIMinvcd;
			this.sqlCommand3.Parameters["@taxtp"].Value = strIMtaxtp;
			this.sqlCommand3.Parameters["@fgitri"].Value = strIMfgitri;
			this.sqlCommand3.Parameters["@syscd"].Value = strsyscd;
			this.sqlCommand3.Parameters["@contno"].Value = strcontno;
			this.sqlCommand3.Parameters["@imseq"].Value = strimseq;

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
			this.lblImSeq.Text = "";
			//this.tbxIMContNo.Text = "";
			this.tbxIMMfrNo.Text = "";
			this.tbxIMName.Text = "";
			this.tbxIMJobTitle.Text = "";
			this.tbxIMZipcode.Text = "";
			this.tbxIMAddr.Text = "";
			this.tbxIMTel.Text = "";
			this.tbxIMFax.Text = "";
			this.tbxIMCell.Text = "";
			this.tbxIMEmail.Text = "";

			// ���U�Ԧ���� �w��� (�P InitialData() �̦P�q�� )
			this.ddlIMInvtp.ClearSelection();
			this.ddlIMInvtp.Items.FindByValue("3").Selected = true;
			this.ddlIMTaxtp.ClearSelection();
			ddlIMTaxtp.SelectedIndex = 0;
			this.ddlIMfgITRI.ClearSelection();
			ddlIMfgITRI.SelectedIndex = 0;
		}


		// ���J�w�]��� - �t�ӤΫȤ���
		private void btnLoadData_Click(object sender, System.EventArgs e)
		{
			//
			InitialData();
		}


		// �M���e���W�����
		private void btnClearAll_Click(object sender, System.EventArgs e)
		{
			ClearForm();
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
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter6 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand6 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter7 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand7 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
			this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
			this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
			this.Datagrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Datagrid2_ItemCommand);
			this.Datagrid2.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.Datagrid2_DeleteCommand);
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mfr", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip")})});
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = "SELECT mfr_mfrno, mfr_inm, mfr_iaddr, mfr_izip FROM dbo.mfr";
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
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT cust_custno, cust_nm, cust_jbti, cust_tel, cust_fax, cust_cell, cust_email" +
				", cust_mfrno FROM dbo.cust";
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
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT cont_contid, cont_syscd, cont_contno, cont_mfrno, cont_custno FROM dbo.c2_" +
				"cont";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter5
			//
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("MaxIMSeq", "MaxIMSeq"),
																																																				new System.Data.Common.DataColumnMapping("im_contno", "im_contno")})});
			//
			// sqlSelectCommand5
			//
			this.sqlSelectCommand5.CommandText = "SELECT MAX(im_imseq) AS MaxIMSeq, im_contno FROM dbo.invmfr WHERE (im_syscd = \'C2" +
				"\') GROUP BY im_contno";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter4
			//
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
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
																																																				new System.Data.Common.DataColumnMapping("im_fgitri", "im_fgitri"),
																																																				new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd")})});
			//
			// sqlCommand3
			//
			this.sqlCommand3.CommandText = @"UPDATE invmfr SET im_mfrno = @mfrno, im_nm = @nm, im_jbti = @jbti, im_zip = @zip, im_addr = @addr, im_tel = @tel, im_fax = @fax, im_cell = @cell, im_email = @email, im_invcd = @invcd, im_taxtp = @taxtp, im_fgitri = @fgitri WHERE (im_syscd = @syscd) AND (im_contno = @contno) AND (im_imseq = @imseq)";
			this.sqlCommand3.Connection = this.sqlConnection1;
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mfrno", System.Data.SqlDbType.Char, 10, "im_mfrno"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nm", System.Data.SqlDbType.VarChar, 30, "im_nm"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@jbti", System.Data.SqlDbType.VarChar, 12, "im_jbti"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.VarChar, 5, "im_zip"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@addr", System.Data.SqlDbType.VarChar, 120, "im_addr"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tel", System.Data.SqlDbType.VarChar, 30, "im_tel"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fax", System.Data.SqlDbType.VarChar, 30, "im_fax"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cell", System.Data.SqlDbType.VarChar, 30, "im_cell"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.VarChar, 80, "im_email"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@invcd", System.Data.SqlDbType.Char, 1, "im_invcd"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@taxtp", System.Data.SqlDbType.Char, 1, "im_taxtp"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgitri", System.Data.SqlDbType.Char, 2, "im_fgitri"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, "im_syscd"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, "im_contno"));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.Char, 2, "im_imseq"));
			//
			// sqlCommand2
			//
			this.sqlCommand2.CommandText = "DELETE FROM invmfr WHERE (im_syscd = @syscd) AND (im_contno = @contno) AND (im_im" +
				"seq = @imseq)";
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, "im_syscd"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, "im_contno"));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.Char, 2, "im_imseq"));
			//
			// sqlCommand1
			//
			this.sqlCommand1.CommandText = @"INSERT INTO invmfr (im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri) VALUES (@syscd, @contno, @imseq, @mfrno, @nm, @jbti, @zip, @addr, @tel, @fax, @cell, @email, @invcd, @taxtp, @fgitri)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, "im_syscd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, "im_contno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.Char, 2, "im_imseq"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mfrno", System.Data.SqlDbType.Char, 10, "im_mfrno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@nm", System.Data.SqlDbType.VarChar, 30, "im_nm"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@jbti", System.Data.SqlDbType.VarChar, 12, "im_jbti"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@zip", System.Data.SqlDbType.VarChar, 5, "im_zip"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@addr", System.Data.SqlDbType.VarChar, 120, "im_addr"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@tel", System.Data.SqlDbType.VarChar, 30, "im_tel"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fax", System.Data.SqlDbType.VarChar, 30, "im_fax"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cell", System.Data.SqlDbType.VarChar, 30, "im_cell"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.VarChar, 80, "im_email"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@invcd", System.Data.SqlDbType.Char, 1, "im_invcd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@taxtp", System.Data.SqlDbType.Char, 1, "im_taxtp"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgitri", System.Data.SqlDbType.Char, 2, "im_fgitri"));
			//
			// sqlDataAdapter6
			//
			this.sqlDataAdapter6.SelectCommand = this.sqlSelectCommand6;
			this.sqlDataAdapter6.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq")})});
			//
			// sqlSelectCommand6
			//
			this.sqlSelectCommand6.CommandText = "SELECT dbo.invmfr.im_syscd, dbo.invmfr.im_contno, dbo.invmfr.im_imseq FROM dbo.in" +
				"vmfr INNER JOIN dbo.c2_pub ON dbo.invmfr.im_syscd = dbo.c2_pub.pub_syscd AND dbo" +
				".invmfr.im_contno = dbo.c2_pub.pub_contno AND dbo.invmfr.im_imseq = dbo.c2_pub.p" +
				"ub_imseq";
			this.sqlSelectCommand6.Connection = this.sqlConnection1;
			//
			// sqlCommand4
			//
			this.sqlCommand4.CommandText = "UPDATE invmfr SET im_imseq = @NewIMSeq WHERE (im_syscd = @syscd) AND (im_contno =" +
				" @contno) AND (im_imseq = @imseq)";
			this.sqlCommand4.Connection = this.sqlConnection1;
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NewIMSeq", System.Data.SqlDbType.VarChar, 2, "im_imseq"));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_contno", System.Data.DataRowVersion.Original, null));
			this.sqlCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_imseq", System.Data.DataRowVersion.Original, null));
			//
			// sqlDataAdapter7
			//
			this.sqlDataAdapter7.SelectCommand = this.sqlSelectCommand7;
			this.sqlDataAdapter7.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "proj", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("fgitri_fgitri", "fgitri_fgitri"),
																																																			  new System.Data.Common.DataColumnMapping("fgitri_name", "fgitri_name"),
																																																			  new System.Data.Common.DataColumnMapping("proj_fgitri", "proj_fgitri")})});
			//
			// sqlSelectCommand7
			//
			this.sqlSelectCommand7.CommandText = "SELECT DISTINCT fgitri.fgitri_fgitri, fgitri.fgitri_name, dbo.proj.proj_fgitri FR" +
				"OM dbo.proj INNER JOIN fgitri ON dbo.proj.proj_fgitri COLLATE Chinese_Taiwan_Str" +
				"oke_BIN = fgitri.fgitri_fgitri WHERE (dbo.proj.proj_syscd = \'C2\')";
			this.sqlSelectCommand7.Connection = this.sqlConnection1;
			//
			// sqlSelectCommand4
			//
			this.sqlSelectCommand4.CommandText = "SELECT im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, im_tel, im" +
				"_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri, im_syscd FROM dbo.invmfr" +
				" WHERE (im_syscd = \'C2\')";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
