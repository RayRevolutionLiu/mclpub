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
	/// Summary description for iaFm2_Add.
	/// </summary>
	public class iaFm2_Add : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.DropDownList ddlBkcd;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Label lblBkcd;
		protected System.Web.UI.WebControls.Label lblYYYYMM;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnClear;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.Button btnCheckedAll;
		protected System.Web.UI.WebControls.Button btnCheckedClear;
		protected System.Web.UI.WebControls.DropDownList ddlOrderByFilter;
		protected System.Web.UI.WebControls.Label lblOrderByFilter;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Web.UI.WebControls.Panel pnlContAmtCount;
		protected System.Web.UI.WebControls.Label lblContAmtCount;
		protected System.Web.UI.WebControls.Label lblIA;
		protected System.Web.UI.WebControls.Button btnConfirmAmt;
		protected System.Web.UI.WebControls.TextBox tbxIAStatus;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Web.UI.WebControls.Button btnGoChklist;
		protected System.Web.UI.WebControls.TextBox tbxSubTotalAmt;
		protected System.Web.UI.WebControls.Label lblSubTotalAmt;
		protected System.Web.UI.WebControls.Panel pnlPub;
		protected System.Web.UI.WebControls.Button btnBackPick;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Data.SqlClient.SqlCommand sqlCommand3;
		protected System.Web.UI.WebControls.Label lblMemo1;
		protected System.Web.UI.WebControls.Label lblMemo2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidIAStatus;
		protected System.Web.UI.WebControls.Label lblContAmtMessage;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Web.UI.WebControls.TextBox tbxYYYYMM;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;
			
			if(!Page.IsPostBack)
			{
				Response.Expires = 0;
				
				// ���J��l���
				InitialData();
			}
		}
		
		
		private void InitialData()
		{
			this.lblMessage.Text  = "";
			
			
			// ��ܤU�Ԧ���� ���y���O�� DB ��
			// ���� nostr, �а� sqlDataAdapter2.Select statement; 
			// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "book");
			DataView dv1=ds1.Tables["book"].DefaultView;
			ddlBkcd.DataSource=dv1;
			dv1.RowFilter="proj_fgitri=''";
			ddlBkcd.DataTextField="bk_nm";
			//ddlBookCode.DataValueField="nostr";
			// ���@�e��: ddl�ȥ� nostr �אּ bk_bkcd, �~��Ϥ���� ���y���O, �_�h�� option �Ȭ� nostr, �ӫD bk_bkcd
			ddlBkcd.DataValueField="bk_bkcd";
			ddlBkcd.DataBind();
			this.ddlBkcd.SelectedIndex = 0;
			
			this.tbxYYYYMM.Text = System.DateTime.Today.ToString("yyyyMM");
			
			
			// ���õo���}�߸��
			this.pnlPub.Visible = false;
			this.pnlContAmtCount.Visible = false;
		}
		
		
		// �d�� ���s���B�z
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			// ��X�d�߱���
			string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
			//Response.Write("strBkcd= " + strBkcd + "<br>");
			//Response.Write("strYYYYMM= " + strYYYYMM + "<br>");
			
			
			// ��ܵo���}�߸��
			this.pnlPub.Visible = true;
			this.pnlContAmtCount.Visible = false;
			
			
			// �ˬd���O�_�w���D��ζ}�߰ʧ@, �A�P�_�O�_��}
			CheckIAStatus();
			
			
			// ���J���
			BindGrid1();
		}
		
		
		// �M�����d ���s���B�z
		private void btnClear_Click(object sender, System.EventArgs e)
		{
			InitialData();
		}
		
		
		// �ˬd���O�_�w���}�߰ʧ@, �A�P�_�O�_��}
		private void CheckIAStatus()
		{
			// ��X�e���W����, �@���z���ƪ�����
			string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
			
			
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			this.sqlDataAdapter5.SelectCommand.Parameters["@bkcd"].Value = strBkcd;
			this.sqlDataAdapter5.SelectCommand.Parameters["@yyyymm"].Value = strYYYYMM;
			DataSet ds5 = new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "c2_cont");
			DataView dv5 = ds5.Tables["c2_cont"].DefaultView;
					
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr5 = "1=1";
			dv5.RowFilter = rowfilterstr5;
			
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
			//Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");
			
			// ��� "�w" ���D��ζ}�߰ʧ@
			if(dv5.Count > 0)
			{
				this.tbxIAStatus.Text = "1";
				this.hidIAStatus.Value = "1";
				//Response.Write("Yes, " + this.hidIAStatus.Value + "<br>");
				
				// �H�U��H Javascript �� Client�� �ӧP�_
				// �H Javascript �� window.alert()  �ӧi���T��
				LiteralControl litAlertError = new LiteralControl();
				//litAlertError.Text = "<script language=javascript>confirm(\"�Ӥ�w���o���}�߳�}�߰ʧ@,\\n�аݬO�_�n�����w�����ˮ֪���!\");</script>";
				litAlertError.Text = "<script language=javascript>alert(\"�Ӥ�w���o���}�߳�}�߰ʧ@,\\n�z�i���L���B�J�����w�����ˮ֪���!\");</script>";
				Page.Controls.Add(litAlertError);
				
				// ����ܥ�����, �u�i��}�� �ˮ֪�
				this.pnlPub.Visible = false;
				this.pnlContAmtCount.Visible = true;
				this.DataGrid2.Visible = false;
				this.lblContAmtMessage.Visible = false;
				this.btnBackPick.Visible = false;
				this.btnGoChklist.Visible = true;
			}
			// ��� "�|��" ���D��ζ}�߰ʧ@
			else
			{
				this.tbxIAStatus.Text = "0";
				this.hidIAStatus.Value = "0";
				
				// ���J �}�ߪ��B�T�{��
				BindGrid2();
				//Response.Write("No, " + this.hidIAStatus.Value + "<br>");
			}
		}
		
		
		// ��� DataGrid1
		private void BindGrid1()
		{
			// ��X�e���W����, �@���z���ƪ�����
			string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
			
			
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c2_cont");
			DataView dv2 = ds2.Tables["c2_cont"].DefaultView;
				
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr2 = "1=1";
			rowfilterstr2 = rowfilterstr2 + " AND cont_bkcd='" + strBkcd + "'";
			rowfilterstr2 = rowfilterstr2 + " AND pub_yyyymm<='" + strYYYYMM + "'";
			dv2.RowFilter = rowfilterstr2;
			
			// Order By Filter
			if(this.ddlOrderByFilter.SelectedItem.Value == "1")
			{
				dv2.Sort = "cont_contno";
			}
			else if(this.ddlOrderByFilter.SelectedItem.Value == "2")
			{
				dv2.Sort = "cont_empno";
			}
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
			
			// �Y�j�M���G�� "���" ���B�z
			if (dv2.Count > 0)
			{
				if(this.tbxIAStatus.Text.ToString().Trim() == "0")
				{
					this.lblMessage.Text = strYYYYMM + "��|���}�߹L�o���}�߳�; ";
				}
				else
				{
					this.lblMessage.Text = strYYYYMM + "��w�}�߹L�o���}�߳�; �z�i�����˵����ˮ֪�. ";
				}
				this.lblMessage.Text = this.lblMessage.Text + "�ثe�|�� <font color='Red'>" + dv2.Count + "</font> ��������Ʃ|���}��!<br>�z�i�A�ɬD���͵o���}�߳� �� ���Ŀ諾�����U�w���ˮ֪�!";
				
				DataGrid1.DataSource = dv2;
				DataGrid1.DataBind();
				
				
				// �S�O��줧��X�榡�ഫ - �ܧ�ñ��������榡
				for(int i=0; i< DataGrid1.Items.Count; i++)
				{
					// �X�����O
					string conttp = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
					//Response.Write("conttp= " + conttp + "<br>");
					if(conttp == "01") 
						DataGrid1.Items[i].Cells[2].Text = "�@��";
					else if(conttp == "09")
						DataGrid1.Items[i].Cells[2].Text = "<font color='Red'>���s</font>";
					
					// �X���_��
					string StartDate = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
					StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
					//Response.Write("StartDate= " + StartDate + "<br>");
					DataGrid1.Items[i].Cells[3].Text = StartDate;
					
					// �X������
					string EndDate = DataGrid1.Items[i].Cells[4].Text.ToString().Trim();
					EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
					//Response.Write("EndDate= " + EndDate + "<br>");
					DataGrid1.Items[i].Cells[4].Text = EndDate;
					
					// �Z�n�~�� -- ���P����������P�C��Х�
					string yyyymm = DataGrid1.Items[i].Cells[10].Text.ToString().Trim();
					//Response.Write("yyyymm= " + yyyymm + "<br>");
					if(yyyymm != strYYYYMM)
					{
						DataGrid1.Items[i].Cells[10].ForeColor = Color.DarkOrange;
					}
					
					// �T�w�������O
					string fgfixpg = DataGrid1.Items[i].Cells[17].Text.ToString().Trim();
					//Response.Write("fgfixpg= " + fgfixpg + "<br>");
					if(fgfixpg == "0")
						DataGrid1.Items[i].Cells[17].Text = "�_";
					else
						DataGrid1.Items[i].Cells[17].Text = "�O";
					
					// �Z�����O
					string drafttp = DataGrid1.Items[i].Cells[18].Text.ToString().Trim();
					//Response.Write("drafttp= " + drafttp + "<br>");
					switch(drafttp)
					{
						case "1":
							DataGrid1.Items[i].Cells[18].Text = "�½Z";
							
							// �M����L���������
							DataGrid1.Items[i].Cells[19].Text = "";
							DataGrid1.Items[i].Cells[20].Text = "";
							DataGrid1.Items[i].Cells[21].Text = "";
							break;
						case "2":
							DataGrid1.Items[i].Cells[18].Text = "�s�Z";
							
							// ��Z���O
							string fggot1 = DataGrid1.Items[i].Cells[20].Text.ToString().Trim();
							//Response.Write("fggot1= " + fggot1 + "<br>");
							if(fggot1 == "0")
								DataGrid1.Items[i].Cells[20].Text = "�_";
							else
								DataGrid1.Items[i].Cells[20].Text = "�O";
							
							// �M����L���������
							DataGrid1.Items[i].Cells[21].Text = "";
							DataGrid1.Items[i].Cells[22].Text = "";
							break;
						case "3":
							DataGrid1.Items[i].Cells[18].Text = "��Z";
							
							// ��Z���O
							string fggot2 = DataGrid1.Items[i].Cells[20].Text.ToString().Trim();
							//Response.Write("fggot2= " + fggot2 + "<br>");
							if(fggot2 == "0")
								DataGrid1.Items[i].Cells[20].Text = "�_";
							else
								DataGrid1.Items[i].Cells[20].Text = "�O";
							
							// �M����L���������
							DataGrid1.Items[i].Cells[19].Text = "";
							DataGrid1.Items[i].Cells[22].Text = "";
							break;
						default:
							DataGrid1.Items[i].Cells[18].Text = "�½Z";
							
							// �M����L���������
							DataGrid1.Items[i].Cells[19].Text = "";
							DataGrid1.Items[i].Cells[20].Text = "";
							DataGrid1.Items[i].Cells[21].Text = "";
							break;
					}
				}
			// ���� if (dv2.Count > 0)
			}
			else
			{
				this.lblMessage.Text = "����w�L������ƶ��}�ߡI";
				
				// ��ܽT�{���B���
				this.pnlPub.Visible = false;
				this.pnlContAmtCount.Visible = true;
			}
		}
		
		
		// ���� ���s���B�z
		private void btnCheckedAll_Click(object sender, System.EventArgs e)
		{
			for(int i=0; i < DataGrid1.Items.Count; i++)
			{
				((CheckBox)this.DataGrid1.Items[i].FindControl("cbxChecked")).Checked = true;
			}
		}
		
		
		// �M�� ���s���B�z
		private void btnCheckedClear_Click(object sender, System.EventArgs e)
		{
			for(int i=0; i < DataGrid1.Items.Count; i++)
			{
				((CheckBox)this.DataGrid1.Items[i].FindControl("cbxChecked")).Checked = false;
			}
		}
		
		
		// �T�{���B�����s
		private void btnConfirmAmt_Click(object sender, System.EventArgs e)
		{
			// �N�w�D�諸������� pub_fginved �Ȱ����O (�� ' ' �אּ 't' (�N�� temp)), �n�� DataGrid2 �I�s
			UpdatefgTemp();
			this.pnlPub.Visible = false;
			this.pnlContAmtCount.Visible = true;
			
			
			// ���J �}�ߪ��B�T�{��
			BindGrid2();
		}
		
		
		// �N�w�D�諸������� pub_fginved �Ȱ����O (�� ' ' �אּ 't' (�N�� temp)), �n�� DataGrid2 �I�s
		private void UpdatefgTemp()
		{
			// ��X DataGrid1 �Q�D�諸���
			for(int i=0; i < DataGrid1.Items.Count; i++)
			{
				// �ˬd�Q�D�諸���A��
				bool strSelect = ((CheckBox)DataGrid1.Items[i].Cells[0].FindControl("cbxChecked")).Checked;
				//Response.Write("strSelect= " + strSelect + "<br>");
				
				// ��X�e���W����, �@���z���ƪ�����
				string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
				string strSyscd = "C2";
				string strContNo = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();;
				string strYYYYMM = DataGrid1.Items[i].Cells[10].Text.ToString().Trim();
				string strPubSeq = DataGrid1.Items[i].Cells[11].Text.ToString().Trim();
				//Response.Write("strBkcd= " + strBkcd + ", ");
				//Response.Write("strSyscd= " + strSyscd + ", ");
				//Response.Write("strContNo= " + strContNo + ", ");
				//Response.Write("strYYYYMM= " + strYYYYMM + ", ");
				//Response.Write("strPubSeq= " + strPubSeq + "<br>");
				
				// ��� DataGrid2, �̾� DataGrid1 �̳Q�D�諸�X�����
				if(strSelect == true)
				{
					// ��s '�Q�D��' ��������Ƥ� pub_fginved �q ' ' �ܬ� 't'
					// ���� �N�ȶ�J sqlCommand1.Parameters ��, �H���� ��s
					//Response.Write(this.sqlCommand1.CommandText);
					this.sqlCommand1.Parameters["@syscd"].Value = strSyscd;
					this.sqlCommand1.Parameters["@contno"].Value = strContNo;
					this.sqlCommand1.Parameters["@yyyymm"].Value = strYYYYMM;
					this.sqlCommand1.Parameters["@pubseq"].Value = strPubSeq;
					
					// �T�{���� sqlCommand1 ���\
					this.sqlCommand1.Connection.Open();
					// �ϥ� Transaction �T�{������ʧ@
					System.Data.SqlClient.SqlTransaction myTrans1 = this.sqlCommand1.Connection.BeginTransaction();
					this.sqlCommand1.Transaction = myTrans1;
					try
					{
						this.sqlCommand1.ExecuteNonQuery();
						myTrans1.Commit();
						//Response.Write("������Ƨ�s���\");
					}
					catch(System.Data.SqlClient.SqlException ex1)
					{
						Response.Write(ex1.Message + "<br>");
						myTrans1.Rollback();
						//Response.Write("������Ƨ�s����");
					}
					finally
					{
						this.sqlCommand1.Connection.Close();
					}
				// ���� if(strSelect == true)
				}
				else
				{
					// ��s '�S���Q�D��' ��������Ƥ� pub_fginved �q 't' �ܬ� ' '
					// ���� �N�ȶ�J sqlCommand3.Parameters ��, �H���� ��s
					//Response.Write(this.sqlCommand3.CommandText);
					this.sqlCommand3.Parameters["@syscd"].Value = strSyscd;
					this.sqlCommand3.Parameters["@contno"].Value = strContNo;
					this.sqlCommand3.Parameters["@yyyymm"].Value = strYYYYMM;
					this.sqlCommand3.Parameters["@pubseq"].Value = strPubSeq;
					
					// �T�{���� sqlCommand3 ���\
					this.sqlCommand3.Connection.Open();
					// �ϥ� Transaction �T�{������ʧ@
					System.Data.SqlClient.SqlTransaction myTrans3 = this.sqlCommand3.Connection.BeginTransaction();
					this.sqlCommand3.Transaction = myTrans3;
					try
					{
						this.sqlCommand3.ExecuteNonQuery();
						myTrans3.Commit();
						//Response.Write("������Ƨ�s���\");
					}
					catch(System.Data.SqlClient.SqlException ex3)
					{
						Response.Write(ex3.Message + "<br>");
						myTrans3.Rollback();
						//Response.Write("������Ƨ�s����");
					}
					finally
					{
						this.sqlCommand3.Connection.Close();
					}
				}
			// ���� for(int i=0; i < DataGrid1.Items.Count; i++)
			}
		}
		
		
		// ���J �}�ߪ��B�T�{��
		private void BindGrid2()
		{
			// ��X�e���W����, �@���z���ƪ�����
			string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
			//Response.Write("strBkcd= " + strBkcd + ", ");
			//Response.Write("strYYYYMM= " + strYYYYMM + ", ");
			
			
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			this.sqlDataAdapter3.SelectCommand.Parameters["@bkcd"].Value = strBkcd;
			this.sqlDataAdapter3.SelectCommand.Parameters["@yyyymm"].Value = strYYYYMM;
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c2_cont");
			DataView dv3 = ds3.Tables["c2_cont"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr3 = "1=1";
			dv3.RowFilter = rowfilterstr3;
			
			// Order by Filter
			if(this.ddlOrderByFilter.SelectedItem.Value == "1")
			{
				dv3.Sort = "cont_contno";
			}
			else if(this.ddlOrderByFilter.SelectedItem.Value == "2")
			{
				dv3.Sort = "cont_empno";
			}
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
			//Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR>");
			
			// �Y�j�M���G�� "���" ���B�z
			if (dv3.Count > 0)
			{
				this.lblContAmtMessage.Text = "�@�� " + dv3.Count + " ���o���}�߳� �Y�N����!";
				DataGrid2.DataSource = dv3;
				DataGrid2.DataBind();
			
				
				string TotAdAmt = "0", TotChgAmt = "0", TotAmt = "0";
				int SubTotalAmt = 0;
				for(int j=0; j < DataGrid2.Items.Count; j++)
				{
					// ��X ���s�i�`�B & ��봫�Z�`�B
					// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
					this.sqlDataAdapter4.SelectCommand.Parameters["@bkcd"].Value = strBkcd;
					this.sqlDataAdapter4.SelectCommand.Parameters["@yyyymm"].Value = strYYYYMM;
					DataSet ds4 = new DataSet();
					this.sqlDataAdapter4.Fill(ds4, "c2_cont");
					DataView dv4 = ds4.Tables["c2_cont"].DefaultView;
					
					// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
					// �] Row Filter: default �� 1=1 and ��L rowfilter ����
					string rowfilterstr4 = "1=1";
					dv4.RowFilter = rowfilterstr4;
					
					// �v�@�p��
					if(dv4.Count > 0)
					{
						TotAdAmt = dv4[j]["TotAdAmt"].ToString().Trim();
						TotChgAmt = dv4[j]["TotChgAmt"].ToString().Trim();
						TotAmt = dv4[j]["TotAmt"].ToString().Trim();
						this.DataGrid2.Items[j].Cells[13].Text = TotAdAmt;
						this.DataGrid2.Items[j].Cells[14].Text = TotChgAmt;
						this.DataGrid2.Items[j].Cells[15].Text = TotAmt;
					}
					else
					{
						this.DataGrid2.Items[j].Cells[13].Text = TotAdAmt;
						this.DataGrid2.Items[j].Cells[14].Text = TotChgAmt;
						this.DataGrid2.Items[j].Cells[15].Text = TotAmt;
					}
					
					SubTotalAmt = SubTotalAmt + Convert.ToInt32(TotAmt);
					// ���� for(int j=0; j < DataGrid2.Items.Count; j++)
				}
				
				
				// ��ܷ��}���`���B�p�p
				this.tbxSubTotalAmt.Text = Convert.ToString(SubTotalAmt);
				this.lblSubTotalAmt.Text = "���}���`�B �p�p�G$" + Convert.ToString(SubTotalAmt);
				//Response.Write("SubTotalAmt= " + SubTotalAmt + "<br>");
				// ���� if (dv3.Count > 0)
			}
			else
			{
				this.lblMessage.Text = "�d�L�}�ߪ��B�T�{�Ϫ����!";
			}
		}
		
		
		// �w�� �o���}�߳� ���s���B�z
		private void btnGoChklist_Click(object sender, System.EventArgs e)
		{
			string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
			//Response.Write("strBkcd= " + strBkcd + ", ");
			//Response.Write("strYYYYMM= " + strYYYYMM + ", ");
			
			
			// ��}
			string OrderByFilter = this.ddlOrderByFilter.SelectedItem.Value.ToString().Trim();
			string strbuf = "iaFm2_chklist.aspx?bkcd=" + strBkcd + "&yyyymm=" + strYYYYMM + "&iastatus=" + this.tbxIAStatus.Text.ToString().Trim() + "&sort=" + OrderByFilter;
			Response.Redirect(strbuf);
		}
		
		
		// �^�W�@�B�J ���D ���s���B�z
		private void btnBackPick_Click(object sender, System.EventArgs e)
		{
			// ��X DataGrid2 �����
			for(int j=0; j < DataGrid2.Items.Count; j++)
			{
				// ��X�e���W����, �@���z���ƪ�����
				string strBkcd = this.ddlBkcd.SelectedItem.Value.ToString();
				string strSyscd = "C2";
				string strContNo = DataGrid2.Items[j].Cells[0].Text.ToString().Trim();
				string strYYYYMM = this.tbxYYYYMM.Text.ToString().Trim();
				//Response.Write("strBkcd= " + strBkcd + ", ");
				//Response.Write("strSyscd= " + strSyscd + ", ");
				//Response.Write("strContNo= " + strContNo + ", ");
				//Response.Write("strYYYYMM= " + strYYYYMM + ", ");
				//Response.Write("strPubSeq= " + strPubSeq + "<br>");
				
				
				// ��s�Q�D�諸������Ƥ� pub_fginved �q 't' �ܬ� ' '
				// ���� �N�ȶ�J sqlCommand2.Parameters ��, �H���� ��s
				//Response.Write(this.sqlCommand2.CommandText);
				this.sqlCommand2.Parameters["@syscd"].Value = strSyscd;
				this.sqlCommand2.Parameters["@contno"].Value = strContNo;
				this.sqlCommand2.Parameters["@yyyymm"].Value = strContNo;
				this.sqlCommand2.Parameters["@bkcd"].Value = strBkcd;
				
				// �T�{���� sqlCommand2 ���\
				this.sqlCommand2.Connection.Open();
				// �ϥ� Transaction �T�{������ʧ@
				System.Data.SqlClient.SqlTransaction myTrans2 = this.sqlCommand1.Connection.BeginTransaction();
				this.sqlCommand2.Transaction = myTrans2;
				try
				{
					this.sqlCommand2.ExecuteNonQuery();
					myTrans2.Commit();
					//Response.Write("������Ƨ�s���\");
				}
				catch(System.Data.SqlClient.SqlException ex2)
				{
					Response.Write(ex2.Message + "<br>");
					myTrans2.Rollback();
					//Response.Write("������Ƨ�s����");
				}
				finally
				{
					this.sqlCommand2.Connection.Close();
				}
			}
			
			// �H Javascript �� window.alert()  �ӧi���T��
			LiteralControl litAlertError = new LiteralControl();
			litAlertError.Text = "<script language=javascript>alert(\"��Ʀ^�_���\, �Э��s�D��!\");</script>";
			Page.Controls.Add(litAlertError);
			
			
			// ���� DataGrid2, ��� DataGrid1
			this.pnlContAmtCount.Visible = false;
			this.pnlPub.Visible = true;
		}
		
		
		
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			this.btnCheckedAll.Click += new System.EventHandler(this.btnCheckedAll_Click);
			this.btnCheckedClear.Click += new System.EventHandler(this.btnCheckedClear_Click);
			this.btnConfirmAmt.Click += new System.EventHandler(this.btnConfirmAmt_Click);
			this.btnGoChklist.Click += new System.EventHandler(this.btnGoChklist_Click);
			this.btnBackPick.Click += new System.EventHandler(this.btnBackPick_Click);
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT book.bk_bkid, book.bk_bkcd, RTRIM(book.bk_nm) AS bk_nm, proj.proj_syscd, RTRIM(proj.proj_fgitri) AS proj_fgitri, proj.proj_projno, proj.proj_costctr, book.bk_bkcd + proj.proj_projno + proj.proj_costctr AS nostr, proj.proj_bkcd, proj.proj_fgitri AS Expr1 FROM book INNER JOIN proj ON book.bk_bkcd = proj.proj_bkcd WHERE (proj.proj_syscd = 'C2')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
//				"nfo=True;user id=sa;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
																																																				 new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				 new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pgno", "pub_pgno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																				 new System.Data.Common.DataColumnMapping("ltp_nm", "ltp_nm"),
																																																				 new System.Data.Common.DataColumnMapping("clr_nm", "clr_nm"),
																																																				 new System.Data.Common.DataColumnMapping("pgs_nm", "pgs_nm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fgfixpg", "pub_fgfixpg"),
																																																				 new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																				 new System.Data.Common.DataColumnMapping("pub_njtpcd", "pub_njtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("njtp_nm", "njtp_nm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgbkcd", "pub_chgbkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgjno", "pub_chgjno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgjbkno", "pub_chgjbkno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origbkcd", "pub_origbkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origjno", "pub_origjno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_origjbkno", "pub_origjbkno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_adamt", "pub_adamt"),
																																																				 new System.Data.Common.DataColumnMapping("pub_chgamt", "pub_chgamt"),
																																																				 new System.Data.Common.DataColumnMapping("pub_modempno", "pub_modempno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("pub_imseq", "pub_imseq"),
																																																				 new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				 new System.Data.Common.DataColumnMapping("pub_remark", "pub_remark"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("clr_clrcd", "clr_clrcd"),
																																																				 new System.Data.Common.DataColumnMapping("ltp_ltpcd", "ltp_ltpcd"),
																																																				 new System.Data.Common.DataColumnMapping("njtp_njtpcd", "njtp_njtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("pgs_pgscd", "pgs_pgscd"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				 new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				 new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fginved", "pub_fginved"),
																																																				 new System.Data.Common.DataColumnMapping("pub_fginvself", "pub_fginvself")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_conttp, c2_cont.cont" +
				"_bkcd, c2_cont.cont_signdate, c2_cont.cont_empno, c2_cont.cont_mfrno, c2_cont.co" +
				"nt_aunm, c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_totjtm, c2_cont.co" +
				"nt_tottm, c2_cont.cont_totamt, c2_cont.cont_paidamt, c2_cont.cont_restamt, c2_co" +
				"nt.cont_custno, c2_cont.cont_fgclosed, c2_cont.cont_fgpayonce, c2_cont.cont_fgca" +
				"ncel, c2_cont.cont_fgtemp, c2_cont.cont_fgpubed, mfr.mfr_inm, cust.cust_nm, cust" +
				".cust_tel, srspn.srspn_cname, c2_pub.pub_syscd, c2_pub.pub_contno, c2_pub.pub_yy" +
				"yymm, c2_pub.pub_pubseq, c2_pub.pub_pgno, c2_pub.pub_ltpcd, c2_pub.pub_clrcd, c2" +
				"_pub.pub_pgscd, c2_ltp.ltp_nm, c2_clr.clr_nm, c2_pgsize.pgs_nm, c2_pub.pub_fgfix" +
				"pg, c2_pub.pub_drafttp, c2_pub.pub_fggot, c2_pub.pub_njtpcd, c2_njtp.njtp_nm, c2" +
				"_pub.pub_chgbkcd, c2_pub.pub_chgjno, c2_pub.pub_chgjbkno, c2_pub.pub_fgrechg, c2" +
				"_pub.pub_origbkcd, c2_pub.pub_origjno, c2_pub.pub_origjbkno, c2_pub.pub_adamt, c" +
				"2_pub.pub_chgamt, c2_pub.pub_modempno, c2_pub.pub_bkcd, c2_pub.pub_imseq, invmfr" +
				".im_nm, c2_pub.pub_remark, book.bk_nm, book.bk_bkcd, c2_clr.clr_clrcd, c2_ltp.lt" +
				"p_ltpcd, c2_njtp.njtp_njtpcd, c2_pgsize.pgs_pgscd, cust.cust_custno, invmfr.im_c" +
				"ontno, invmfr.im_imseq, invmfr.im_syscd, mfr.mfr_mfrno, srspn.srspn_empno, c2_pu" +
				"b.pub_fginved, c2_pub.pub_fginvself FROM c2_cont INNER JOIN mfr ON c2_cont.cont_" +
				"mfrno = mfr.mfr_mfrno INNER JOIN cust ON c2_cont.cont_custno = cust.cust_custno " +
				"INNER JOIN srspn ON c2_cont.cont_empno = srspn.srspn_empno INNER JOIN c2_pub ON " +
				"c2_cont.cont_syscd = c2_pub.pub_syscd AND c2_cont.cont_contno = c2_pub.pub_contn" +
				"o INNER JOIN invmfr ON c2_pub.pub_imseq = invmfr.im_imseq AND c2_cont.cont_syscd" +
				" = invmfr.im_syscd AND c2_cont.cont_contno = invmfr.im_contno LEFT OUTER JOIN bo" +
				"ok ON c2_pub.pub_origbkcd = book.bk_bkcd LEFT OUTER JOIN c2_njtp ON c2_pub.pub_n" +
				"jtpcd = c2_njtp.njtp_njtpcd LEFT OUTER JOIN c2_ltp ON c2_pub.pub_ltpcd = c2_ltp." +
				"ltp_ltpcd LEFT OUTER JOIN c2_clr ON c2_pub.pub_clrcd = c2_clr.clr_clrcd LEFT OUT" +
				"ER JOIN c2_pgsize ON c2_pub.pub_pgscd = c2_pgsize.pgs_pgscd WHERE (c2_cont.cont_" +
				"fgpubed = \'1\') AND (c2_cont.cont_fgpayonce = \'0\') AND (c2_cont.cont_fgcancel = \'" +
				"0\') AND (c2_cont.cont_fgtemp = \'0\') AND (c2_pub.pub_fginved = \' \')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
																																																				 new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																				 new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				 new System.Data.Common.DataColumnMapping("im_nm", "im_nm")})});
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT DISTINCT c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_conttp, c2_cont.cont_bkcd, c2_cont.cont_signdate, c2_cont.cont_empno, c2_cont.cont_mfrno, c2_cont.cont_aunm, c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_totjtm, c2_cont.cont_tottm, c2_cont.cont_totamt, c2_cont.cont_paidamt, c2_cont.cont_restamt, c2_cont.cont_custno, c2_cont.cont_fgclosed, c2_cont.cont_fgpayonce, c2_cont.cont_fgcancel, c2_cont.cont_fgtemp, c2_cont.cont_fgpubed, mfr.mfr_inm, cust.cust_nm, cust.cust_tel, srspn.srspn_cname, invmfr.im_imseq, invmfr.im_nm FROM c2_cont INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN srspn ON c2_cont.cont_empno = srspn.srspn_empno INNER JOIN c2_pub ON c2_cont.cont_syscd = c2_pub.pub_syscd AND c2_cont.cont_contno = c2_pub.pub_contno INNER JOIN invmfr ON c2_pub.pub_syscd = invmfr.im_syscd AND c2_pub.pub_contno = invmfr.im_contno AND c2_pub.pub_imseq = invmfr.im_imseq WHERE (c2_pub.pub_yyyymm <= @yyyymm) AND (c2_cont.cont_bkcd = @bkcd) AND (c2_cont.cont_fgpubed = '1') AND (c2_cont.cont_fgpayonce = '0') AND (c2_cont.cont_fgcancel = '0') AND (c2_cont.cont_fgtemp = '0') AND (c2_pub.pub_fginved = 't')";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			this.sqlSelectCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, "pub_yyyymm"));
			this.sqlSelectCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "cont_bkcd"));
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("TotAdAmt", "TotAdAmt"),
																																																				 new System.Data.Common.DataColumnMapping("TotChgAmt", "TotChgAmt"),
																																																				 new System.Data.Common.DataColumnMapping("TotAmt", "TotAmt")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = @"SELECT c2_cont.cont_syscd, c2_cont.cont_contno, SUM(c2_pub.pub_adamt) AS TotAdAmt, SUM(c2_pub.pub_chgamt) AS TotChgAmt, SUM(c2_pub.pub_adamt + c2_pub.pub_chgamt) AS TotAmt FROM c2_cont INNER JOIN c2_pub ON c2_cont.cont_syscd = c2_pub.pub_syscd AND c2_cont.cont_contno = c2_pub.pub_contno WHERE (c2_cont.cont_bkcd = @bkcd) AND (c2_pub.pub_yyyymm <= @yyyymm) AND (c2_pub.pub_fginved = 't') AND (c2_cont.cont_fgpubed = '1') AND (c2_cont.cont_fgpayonce = '0') AND (c2_cont.cont_fgcancel = '0') AND (c2_cont.cont_fgtemp = '0') GROUP BY c2_cont.cont_syscd, c2_cont.cont_contno";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			this.sqlSelectCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "cont_bkcd"));
			this.sqlSelectCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, "pub_yyyymm"));
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_fginved", "pub_fginved"),
																																																				new System.Data.Common.DataColumnMapping("pub_fginvself", "pub_fginvself")})});
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "UPDATE c2_pub SET pub_fginved = \'t\' WHERE (pub_syscd = @syscd) AND (pub_contno = " +
				"@contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_contno", System.Data.DataRowVersion.Original, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_yyyymm", System.Data.DataRowVersion.Original, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubseq", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_pubseq", System.Data.DataRowVersion.Original, null));
			// 
			// sqlCommand2
			// 
			this.sqlCommand2.CommandText = "UPDATE c2_pub SET pub_fginved = \' \' WHERE (pub_syscd = @syscd) AND (pub_contno = " +
				"@contno) AND (pub_yyyymm = @yyyymm) AND (pub_bkcd = @bkcd)";
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_contno", System.Data.DataRowVersion.Original, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_yyyymm", System.Data.DataRowVersion.Original, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_bkcd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlCommand3
			// 
			this.sqlCommand3.CommandText = "UPDATE c2_pub SET pub_fginved = \' \' WHERE (pub_syscd = @syscd) AND (pub_contno = " +
				"@contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq)";
			this.sqlCommand3.Connection = this.sqlConnection1;
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_contno", System.Data.DataRowVersion.Original, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_yyyymm", System.Data.DataRowVersion.Original, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubseq", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pub_pubseq", System.Data.DataRowVersion.Original, null));
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = @"SELECT c2_pub.pub_syscd, c2_pub.pub_contno, c2_pub.pub_yyyymm, c2_pub.pub_pubseq, c2_pub.pub_fginved, c2_pub.pub_fginvself FROM c2_cont INNER JOIN c2_pub ON c2_cont.cont_syscd = c2_pub.pub_syscd AND c2_cont.cont_contno = c2_pub.pub_contno WHERE (c2_pub.pub_yyyymm <= @yyyymm) AND (c2_cont.cont_bkcd = @bkcd) AND (c2_cont.cont_fgpubed = '1') AND (c2_cont.cont_fgpayonce = '0') AND (c2_cont.cont_fgcancel = '0') AND (c2_cont.cont_fgtemp = '0') AND (c2_pub.pub_fginved = 'v' OR c2_pub.pub_fginved = '1')";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			this.sqlSelectCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6, "pub_yyyymm"));
			this.sqlSelectCommand5.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2, "cont_bkcd"));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
				
		
	}
}
