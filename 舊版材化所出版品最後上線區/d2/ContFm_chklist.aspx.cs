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
	/// Summary description for ContFm_chklist.
	/// </summary>
	public class ContFm_chklist : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Label lblMemo1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Web.UI.WebControls.Label lblRecordCount;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Button btnBack;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.TextBox tbxSDate;
		protected System.Web.UI.WebControls.TextBox tbxEDate;
		protected System.Web.UI.WebControls.Label lblSEDate;
		protected System.Web.UI.WebControls.CheckBox cbx2;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.Label lblfgclosed;
		protected System.Web.UI.WebControls.CheckBox cbx3;
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Web.UI.WebControls.DropDownList ddlfgclosed;
		protected System.Web.UI.WebControls.Label lblSEDateMemo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Web.UI.WebControls.Label lblSignDate;
		protected System.Web.UI.WebControls.TextBox tbxSignDate1;
		protected System.Web.UI.WebControls.TextBox tbxSignDate2;
		protected System.Web.UI.WebControls.Button btnClear;
		protected System.Web.UI.WebControls.CheckBox cbx4;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.CheckBox cbx5;
		protected System.Web.UI.WebControls.Label lblMfrIName;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.TextBox tbxMfrIName;
		protected System.Web.UI.WebControls.CheckBox cbx0;
		protected System.Web.UI.WebControls.Label lblEmpNo;
	
		public ContFm_chklist()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;
			
			
			if (!IsPostBack)
			{
				Response.Expires=0;
				
				// �w�]��
				InitialData();
				
				
				// �M����Ƶ��Ƥ��T��
				this.lblRecordCount.Text = "";
			}
		}
		
		
		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		// �w�]��
		private void InitialData()
		{
			// �d�߸�ư�
			//-----------------------
			this.cbx0.Checked = true;
			this.cbx1.Checked = false;
			this.cbx2.Checked = false;
			this.cbx3.Checked = false;
			this.cbx4.Checked = false;
			this.cbx5.Checked = false;
			
			
			// ñ������϶�
			this.tbxSignDate1.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
			this.tbxSignDate2.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
			
			// �X���_���϶�
			this.tbxSDate.Text = System.DateTime.Today.ToString("yyyy") + "01";
			this.tbxEDate.Text = System.DateTime.Today.ToString("yyyy") + "12";
			
			
			// �U�Ԧ���� -- �w����
			this.ddlfgclosed.SelectedIndex = 1;
			
			// ��ܤU�Ԧ���� �~�ȭ��� DB ��
			// **�`�N: �쥻��Ʈw���� srspn_cname & srspn_empno �O char(x) ���A, �G�� sqlDataAdapter4 ��, �n���� RTRIM ���B�z (�p RTRIM(srspn_cname) AS srspn_cname), �_�h��ȷ|�t���ť�, �p '800443 ', '�d�R��     ' .
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "srspn");
			this.ddlEmpNo.DataSource = ds5;
			this.ddlEmpNo.DataTextField="srspn_cname";
			this.ddlEmpNo.DataValueField="srspn_empno";
			this.ddlEmpNo.DataBind();
			
			// �X���s���μt�ӦW��
			this.tbxContNo.Text = "";
			this.tbxMfrIName.Text = "";

			//�p�G�OD�ź޲z�̡A�ȯ�d�ݨ�ۤv���Ȥ���
			if((Session["RegOK"] != null) && ((bool)Session["RegOK"] == true))
			{
				if(Session["atype"].ToString().Equals("D"))
				{
					if(this.ddlEmpNo.Items.FindByValue(Session["empid"].ToString()) != null)
					{
						this.ddlEmpNo.Items.FindByValue(Session["empid"].ToString()).Selected = true;
						this.ddlEmpNo.Enabled = false;
						this.cbx3.Checked = true;
						this.cbx3.Enabled = false;
					}
				}
			}
		}
		
		
		// �d�� ���s
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			// ��X�z�����
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			string rowfilterstr1 = " (1=1) ";
			
			// ñ������϶�
			string strSignDate1, strSignDate2;
			strSignDate1 = this.tbxSignDate1.Text.Substring(0,4) + this.tbxSignDate1.Text.Substring(5,2) + this.tbxSignDate1.Text.Substring(8,2);
			strSignDate2 = this.tbxSignDate2.Text.Substring(0,4) + this.tbxSignDate2.Text.Substring(5,2) + this.tbxSignDate2.Text.Substring(8,2);
			
			// �Y�Ŀ�d�߱���@�� - �X���_���϶�
			string strSDate, strEDate;
			if(cbx1.Checked)
			{
				strSDate = this.tbxSDate.Text.ToString().Trim();
				strEDate = this.tbxEDate.Text.ToString().Trim();
				rowfilterstr1 = rowfilterstr1 + " AND (cont_sdate >= '" + strSDate + "') ";
				rowfilterstr1 = rowfilterstr1 + " AND (cont_edate <= '" + strEDate + "') ";
			}
			else
			{
				rowfilterstr1 = rowfilterstr1;
			}
			
			// �Y�Ŀ�d�߱���G�� - �w����
			string strfgclosed;
			if(cbx2.Checked)
			{
				strfgclosed = this.ddlfgclosed.SelectedItem.Value.ToString().Trim();
				rowfilterstr1 = rowfilterstr1 + " AND (cont_fgclosed='" + strfgclosed + "') ";
			}
			else
			{
				rowfilterstr1 = rowfilterstr1;
			}
			
			// �Y�Ŀ�d�߱���T�� - �ӿ�~�ȭ�
			string strEmpNo;
			if(cbx3.Checked)
			{
				strEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
				rowfilterstr1 = rowfilterstr1 + " AND (cont_empno='" + strEmpNo + "') ";
			}
			else
			{
				rowfilterstr1 = rowfilterstr1;
			}
			
			// �Y�Ŀ�d�߱���|�� - �X���ѽs��
			string QstrContNo;
			if(cbx4.Checked)
			{
				this.cbx0.Checked = false;
				QstrContNo = this.tbxContNo.Text.ToString().Trim();
				rowfilterstr1 = rowfilterstr1 + " AND (cont_contno Like '%" + QstrContNo + "%') ";
			}
			else
			{
				rowfilterstr1 = rowfilterstr1;
			}
			
			// �Y�Ŀ�d�߱��󤭮� - �t�ӦW��
			string QstrMfrIName;
			if(cbx5.Checked)
			{
				//this.cbx0.Checked = false;
				QstrMfrIName = this.tbxMfrIName.Text.ToString().Trim();
				rowfilterstr1 = rowfilterstr1 + " AND (mfr_inm Like '%" + QstrMfrIName + "%') ";
			}
			else
			{
				rowfilterstr1 = rowfilterstr1;
			}
			
			
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_cont");
			DataView dv1 = ds1.Tables["c2_cont"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			if(cbx0.Checked)
			{
				rowfilterstr1 = rowfilterstr1 + " AND (cont_signdate >= '" + strSignDate1 + "')"; 
				rowfilterstr1 = rowfilterstr1 + " AND (cont_signdate <= '" + strSignDate2 + "')";
			}
			dv1.RowFilter= rowfilterstr1;
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
			
			
			// �Y�����, �h��ܬ������; �_�h�������~�T��
			if(dv1.Count > 0)
			{
				// ��� DataList1 
				this.DataList1.Visible = true;
				
				
				//Response.Write("�� " + dv1.Count + " �����");
				this.lblRecordCount.Text = "�d�ߵ��G�G�@�� " + dv1.Count + " �����!";
				DataList1.DataSource=dv1;
				DataList1.DataBind();
				
				// �S�O��줧��X�榡�ഫ
				for(int i=0; i<DataList1.Items.Count; i++)
				{
					// ���լO�_�i�����ܦU�椧 Controls (�p lblContNo, lblMfrNo...)
					//for(int j=0; j<DataList1.Items[i].Controls.Count; j++)
					//{
						//string ID = DataList1.Items[i].Controls[j].ID;
						//Response.Write("ID= " + ID + "<br>");
					//}
						
					// ñ�����
					string SignDate = ((Label)DataList1.Items[i].FindControl("lblSignDate")).Text;
					SignDate = SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
					((Label)DataList1.Items[i].FindControl("lblSignDate")).Text = SignDate;
					
					// �X�����O
					string conttp = ((Label)DataList1.Items[i].FindControl("lblConttp")).Text;
					string ConttpName = "";
					if(conttp == "01")
						ConttpName = "�@��X��";
					else if(conttp == "09")
						ConttpName = "���s�X��";
					((Label)DataList1.Items[i].FindControl("lblConttp")).Text = ConttpName;
					
					// �X���_����
					string StartDate = ((Label)DataList1.Items[i].FindControl("lblStartDate")).Text;
					StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
					((Label)DataList1.Items[i].FindControl("lblStartDate")).Text = StartDate;
					string EndDate = ((Label)DataList1.Items[i].FindControl("lblEndDate")).Text;
					EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
					((Label)DataList1.Items[i].FindControl("lblEndDate")).Text = EndDate;
					
					// �@���I�ڵ��O
					string fgpayonce = ((Label)DataList1.Items[i].FindControl("lblfgPayonce")).Text;
					string fgPayOnceText = "";
					if(fgpayonce == "0")
						fgPayOnceText = "�_";
					else
						fgPayOnceText = "<font color='Red'>�O</font>";
					((Label)DataList1.Items[i].FindControl("lblfgPayonce")).Text = fgPayOnceText;
					
					// ���׵��O
					string fgClosed = ((Label)DataList1.Items[i].FindControl("lblfgClosed")).Text;
					string fgClosedText = "";
					if(fgClosed == "0")
						fgClosedText = "�_";
					else
						fgClosedText = "<font color='Red'>�O</font>";
					((Label)DataList1.Items[i].FindControl("lblfgClosed")).Text = fgClosedText;
					
					// ���׵��O
					string oldContNo = ((Label)DataList1.Items[i].FindControl("lblOldContNo")).Text;
					string oldContNoText = "";
					if(oldContNo == "0")
						oldContNoText = "<font color='Gray'>(�L)</font>";
					else
						oldContNoText = oldContNo;
					((Label)DataList1.Items[i].FindControl("lblOldContNo")).Text = oldContNoText;
					
					// ���ɤ��
					string CreateDate = ((Label)DataList1.Items[i].FindControl("lblCreateDate")).Text;
					CreateDate = CreateDate.Substring(0, 4) + "/" + CreateDate.Substring(4, 2) + "/" + CreateDate.Substring(6, 2);
					((Label)DataList1.Items[i].FindControl("lblCreateDate")).Text = CreateDate;
					
					// �ק���
					string ModifyDate = ((Label)DataList1.Items[i].FindControl("lblModifyDate")).Text;
					ModifyDate = ModifyDate.Substring(0, 4) + "/" + ModifyDate.Substring(4, 2) + "/" + ModifyDate.Substring(6, 2);
					((Label)DataList1.Items[i].FindControl("lblModifyDate")).Text = ModifyDate;
					
					
					// ����X �X���ѽs��, �H filter �o���t�Ӧ���H�����x����H���
					string strContNo = ((Label)DataList1.Items[i].FindControl("lblContNo")).Text;
					//Response.Write("strContNo= " + strContNo + "<br>");
					
					// ��X �o���t�Ӧ���H DataGrid1			
					// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
					DataSet ds2 = new DataSet();
					this.sqlDataAdapter2.Fill(ds2, "invmfr");
					DataView dv2 = ds2.Tables["invmfr"].DefaultView;
					
					// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
					string rowfilterstr2 = "1=1"; 
					rowfilterstr2 = rowfilterstr2 + " AND (im_syscd='C2')";
					rowfilterstr2 = rowfilterstr2 + " AND (im_contno='" + strContNo + "')";
					dv2.RowFilter= rowfilterstr2;
					
					// �ˬd�ÿ�X �̫� Row Filter �����G
					//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
					//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
					
					// �Y�����, �h��ܬ������; �_�h�������~�T��
					if(dv2.Count > 0)
					{
						((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).DataSource = dv2;
						((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).DataBind();
						
						
						// �S�O��줧��X�榡�ഫ - �ܧ�o�����O�����榡
						//Response.Write("DataGrid1.Count= " + ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items.Count + "<br>");
						int j;
						for(j=0; j< ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items.Count ; j++)
						{
							// �o�����O
							string invcd = ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[10].Text.ToString().Trim();
							//Response.Write("invcd = " + invcd + "<br>");
							switch (invcd) 
							{
								case "2":
									((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[10].Text = "�G�p";
									break;
								case "3":
									((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[10].Text = "�T�p";
									break;
								case "4":
									((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[10].Text = "��L";
									break;
								case "9":
									((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[10].Text = "���M��";
									break;
								default:
									((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[10].Text = "�T�p";
									break;
							}
							
							// �o���ҵ|�O
							string taxtp = ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[11].Text.ToString().Trim();
							//Response.Write("taxtp = " + taxtp + "<br>");
							switch (taxtp) 
							{
								case "1":
									((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[11].Text = "���|5%";
									break;
								case "2":
									((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[11].Text = "�s�|";
									break;
								case "3":
									((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[11].Text = "�K�|";
									break;
								case "9":
									((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[11].Text = "���M��";
									break;
								default:
									((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[11].Text = "���|5%";
									break;
							}
							
							// �|�Ҥ����O
							string fgitri = ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[12].Text.ToString().Trim();
							//Response.Write("fgitri = " + fgitri + "<br>");
							if(fgitri == "")
								((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[12].Text = "�_";
							else
							{
								if(fgitri == "06")
									((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[12].Text = "<font color='Red'>�Ҥ�</font>";
								if(fgitri == "07")
									((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[12].Text = "<font color='Red'>�|��</font>";
							}
						}
					
					}
					
					
					// ��X ���x����H DataGrid2
					// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
					DataSet ds3 = new DataSet();
					this.sqlDataAdapter3.Fill(ds3, "c2_or");
					DataView dv3 = ds3.Tables["c2_or"].DefaultView;
					
					// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
					string rowfilterstr3 = "1=1"; 
					rowfilterstr3 = rowfilterstr3 + " AND (or_syscd='C2')";
					rowfilterstr3 = rowfilterstr3 + " AND (or_contno='" + strContNo + "')";
					dv3.RowFilter= rowfilterstr3;
					
					// �ˬd�ÿ�X �̫� Row Filter �����G
					//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
					//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");
					
					// �Y�����, �h��ܬ������; �_�h�������~�T��
					if(dv3.Count > 0)
					{
						((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).DataSource = dv3;
						((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).DataBind();
						
						
						// �S�O��줧��X�榡�ഫ - �ܧ�o�����O�����榡
						//Response.Write("DataGrid2.Count= " + ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items.Count + "<br>");
						int j;
						for(j=0; j< ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items.Count ; j++)
						{
							// �l�H���O
							string mtpcd = ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[j].Cells[12].Text.ToString().Trim();
							//Response.Write("mtpcd = " + mtpcd + "<br>");
							
							// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
							DataSet ds4 = new DataSet();
							this.sqlDataAdapter4.Fill(ds4, "mtp");
							DataView dv4 = ds4.Tables["mtp"].DefaultView;
					
							// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
							string rowfilterstr4 = "1=1"; 
							rowfilterstr4 = rowfilterstr4 + " AND (mtp_mtpcd='" + mtpcd + "')";
							dv4.RowFilter= rowfilterstr4;
					
							// �ˬd�ÿ�X �̫� Row Filter �����G
							//Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
							//Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");
					
							// �Y�����, �h��ܬ������; �_�h�������~�T��
							if(dv4.Count > 0)
							{
								((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[j].Cells[12].Text = dv4[0]["mtp_nm"].ToString().Trim();
							}
							else
							{
								((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[j].Cells[12].Text = "<font color='Red'>(��Ʀ��~)</font>";
							}
							
							
							// ���~�l�H���O
							string fgmosea = ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[j].Cells[13].Text.ToString().Trim();
							//Response.Write("fgmosea = " + fgmosea + "<br>");
							if(fgmosea == "1")
								((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[j].Cells[13].Text = "<font color='Red'>�O</font>";
							else
								((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[j].Cells[13].Text = "�_";
							
						}
					}
				
				}
			}
			else
			{
				this.lblRecordCount.Text = "�d�L���, �Э��s��J�d�߱���!";
				
				// ���� DataList1 
				this.DataList1.Visible = false;
			}

		}
		
		
		// ��^���� ���s
		private void btnBack_Click(object sender, System.EventArgs e)
		{
			// ��}
			Response.Redirect("../default.aspx");
		}
		
		
		// �M�����d ���s
		private void btnClear_Click(object sender, System.EventArgs e)
		{
			InitialData();
		}
		
		
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
//				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT or_syscd, or_contno, or_oritem, or_inm, or_nm, or_jbti, or_addr, or_zip, o" +
				"r_tel, or_fax, or_cell, or_email, or_mtpcd, or_pubcnt, or_unpubcnt, or_fgmosea F" +
				"ROM c2_or";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, " +
				"im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri FROM invmfr";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT c2_cont.cont_contno, c2_cont.cont_mfrno, mfr.mfr_inm, c2_cont.cont_custno, cust.cust_nm, c2_cont.cont_signdate, c2_cont.cont_conttp, c2_cont.cont_bkcd, c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_empno, c2_cont.cont_fgpayonce, c2_cont.cont_fgclosed, c2_cont.cont_modempno, c2_cont.cont_fgcancel, c2_cont.cont_oldcontno, c2_cont.cont_credate, c2_cont.cont_moddate, c2_cont.cont_totjtm, c2_cont.cont_madejtm, c2_cont.cont_restjtm, c2_cont.cont_tottm, c2_cont.cont_pubtm, c2_cont.cont_resttm, c2_cont.cont_totamt, c2_cont.cont_paidamt, c2_cont.cont_restamt, c2_cont.cont_chgjtm, c2_cont.cont_freetm, c2_cont.cont_adamt, c2_cont.cont_disc, c2_cont.cont_freebkcnt, c2_cont.cont_clrtm, c2_cont.cont_getclrtm, c2_cont.cont_menotm, c2_cont.cont_pubamt, c2_cont.cont_chgamt, c2_cont.cont_aunm, c2_cont.cont_autel, c2_cont.cont_aufax, c2_cont.cont_aucell, c2_cont.cont_auemail, c2_cont.cont_remark, c2_cont.cont_fgtemp, c2_cont.cont_syscd, cust.cust_custno, mfr.mfr_mfrno, srspn.srspn_cname, srspn.srspn_empno, book.bk_nm, book.bk_bkcd FROM c2_cont INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN srspn ON c2_cont.cont_empno = srspn.srspn_empno INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd WHERE (c2_cont.cont_fgtemp = '0') AND (c2_cont.cont_syscd = 'C2')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT srspn_id, RTRIM(srspn_cname) AS srspn_cname, RTRIM(srspn_tel) AS srspn_tel" +
				", srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, RTRIM(srspn_empno) AS srsp" +
				"n_empno FROM srspn WHERE (srspn_atype <> \'a\') AND (srspn_atype <> \'f\')";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mtp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mtp_mtpcd", "mtp_mtpcd"),
																																																			 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT mtp_mtpcd, mtp_nm FROM mtp";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_modempno", "cont_modempno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_oldcontno", "cont_oldcontno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_credate", "cont_credate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_moddate", "cont_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_madejtm", "cont_madejtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restjtm", "cont_restjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubtm", "cont_pubtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_resttm", "cont_resttm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_chgjtm", "cont_chgjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freetm", "cont_freetm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_adamt", "cont_adamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_disc", "cont_disc"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freebkcnt", "cont_freebkcnt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_clrtm", "cont_clrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_getclrtm", "cont_getclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_menotm", "cont_menotm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubamt", "cont_pubamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_chgamt", "cont_chgamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aufax", "cont_aufax"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aucell", "cont_aucell"),
																																																				 new System.Data.Common.DataColumnMapping("cont_auemail", "cont_auemail"),
																																																				 new System.Data.Common.DataColumnMapping("cont_remark", "cont_remark"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
		
	}
}
