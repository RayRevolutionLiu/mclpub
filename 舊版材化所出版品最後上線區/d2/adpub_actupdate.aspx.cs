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
// SQLCommand
using System.Data.SqlClient;
// WebApplication Virables - Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adpub_actupdate.
	/// </summary>
	public class adpub_actupdate : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.Literal litAlertWin;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;

		public adpub_actupdate()
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


				// �I�s BindGrid1()
				BindGrid1();
			}
		}


		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		// ���� DataGrid1
		private void BindGrid1()
		{
			//��X�����ܼ�
			string Qstrbkcd = Context.Request.QueryString["bkcd"].ToString().Trim();
			string Qstryyyymm = Context.Request.QueryString["yyyymm"].ToString().Trim();

			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_pub");
			DataView dv1 = ds1.Tables["c2_pub"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� cust_mfrno and ��L rowfilter ����
			string rowfilterstr = "1=1";
			if(Qstrbkcd != "")
				rowfilterstr = rowfilterstr + " and (���y���O�N�X = '" + Qstrbkcd + "')";
			else
				rowfilterstr = rowfilterstr;
			if(Qstryyyymm != "")
				rowfilterstr = rowfilterstr + " and (�Z�n�~�� LIKE '%" + Qstryyyymm + "%')";
			else
				rowfilterstr = rowfilterstr;
			dv1.RowFilter = rowfilterstr;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			// �Y�j�M���G�� "���" ���B�z
			if (dv1.Count>0)
			{
				DataGrid1.Visible = true;

				DataGrid1.DataSource = dv1;
				DataGrid1.DataBind();


				// �S�O��줧��X�榡�ഫ - �ܧ�ñ��������榡
				int i;
				for(i=0; i< DataGrid1.Items.Count ; i++)
				{
					// �Z�n�~��
					string yyyymm = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
					yyyymm = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
					DataGrid1.Items[i].Cells[2].Text = yyyymm;


					// �T�w�������O
					string fgFixPg = DataGrid1.Items[i].Cells[8].Text.ToString().Trim();
					if(fgFixPg=="1")
						DataGrid1.Items[i].Cells[8].Text = "<font color=Red>�O</font>";
					else
						DataGrid1.Items[i].Cells[8].Text = "�_";


					// �Z�����O�N�X
					string drafttp = DataGrid1.Items[i].Cells[22].Text.ToString().Trim();
					//Response.Write("drafttp= " + drafttp + "<br>");
					switch (drafttp)
					{
						// �½Z�������
						case "1":
							string Origbkcd = DataGrid1.Items[i].Cells[17].Text.ToString().Trim();
							string Origjno = DataGrid1.Items[i].Cells[18].Text.ToString().Trim();
							string Origjbkno = DataGrid1.Items[i].Cells[19].Text.ToString().Trim();

							// �M����L���O���
							DataGrid1.Items[i].Cells[10].Text = "";
							DataGrid1.Items[i].Cells[11].Text = "";
							DataGrid1.Items[i].Cells[12].Text = "";
							DataGrid1.Items[i].Cells[13].Text = "";
							DataGrid1.Items[i].Cells[14].Text = "";
							DataGrid1.Items[i].Cells[15].Text = "";
							DataGrid1.Items[i].Cells[16].Text = "";
							// �M�� �w���˫�ק蠟�� 0
							DataGrid1.Items[i].Cells[26].Text = "";
							break;

						// �s�Z�������
						case "2":
							// ��Z���O
							string fggot1 = DataGrid1.Items[i].Cells[10].Text.ToString().Trim();
							if(fggot1 == "0")
								fggot1 = "�_";
							else
								fggot1 = "�O";
							DataGrid1.Items[i].Cells[10].Text = fggot1;

							// �M����L���O���
							DataGrid1.Items[i].Cells[13].Text = "";
							DataGrid1.Items[i].Cells[14].Text = "";
							DataGrid1.Items[i].Cells[15].Text = "";
							DataGrid1.Items[i].Cells[16].Text = "";
							DataGrid1.Items[i].Cells[17].Text = "";
							DataGrid1.Items[i].Cells[18].Text = "";
							DataGrid1.Items[i].Cells[19].Text = "";
							break;

						// ��Z�������
						case "3":
							// ��Z���O
							string fggot2 = DataGrid1.Items[i].Cells[10].Text.ToString().Trim();
							if(fggot2 == "0")
								fggot2 = "�_";
							else
								fggot2 = "�O";
							DataGrid1.Items[i].Cells[10].Text = fggot2;

							// ��Z���y���O
							string chgbkName;
							string chgbkcd = DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
							if(chgbkcd == "01")
								DataGrid1.Items[i].Cells[13].Text = "�u�����x";
							else if(chgbkcd == "02")
								DataGrid1.Items[i].Cells[13].Text = "�q�����x";
							else
								DataGrid1.Items[i].Cells[13].Text = "�]��Ʀ��~)";

							// ��Z���X�����O
							string fgReChg = DataGrid1.Items[i].Cells[24].Text;
							//Response.Write("fgReChg= " + fgReChg + "<br>");
							if(fgReChg == "1")
								((CheckBox)DataGrid1.Items[i].FindControl("cbxfgReChg")).Checked = true;
							else if(fgReChg == "0")
								((CheckBox)DataGrid1.Items[i].FindControl("cbxfgReChg")).Checked = false;
							else
								((CheckBox)DataGrid1.Items[i].FindControl("cbxfgReChg")).Checked = false;

							// �M����L���O���
							DataGrid1.Items[i].Cells[11].Text = "";
							DataGrid1.Items[i].Cells[12].Text = "";
							DataGrid1.Items[i].Cells[17].Text = "";
							DataGrid1.Items[i].Cells[18].Text = "";
							DataGrid1.Items[i].Cells[19].Text = "";
							break;

						default:
							// �M����L���O���
							DataGrid1.Items[i].Cells[10].Text = "";
							DataGrid1.Items[i].Cells[11].Text = "";
							DataGrid1.Items[i].Cells[12].Text = "";
							DataGrid1.Items[i].Cells[13].Text = "";
							DataGrid1.Items[i].Cells[14].Text = "";
							DataGrid1.Items[i].Cells[15].Text = "";
							DataGrid1.Items[i].Cells[16].Text = "";
							break;
					}


					// ���� for(i=0; i< DataGrid1.Items.Count ; i++)
				}
			}
			else
			{
				DataGrid1.Visible = false;
			}
		}


		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			// �����^����
			Response.Redirect("/mrlpub/");
		}


		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
		}


		// ���U �T�{��s ���s���B�z
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			//Response.Write("DataGrid1.Items.Count= " + DataGrid1.Items.CountDataGrid1.Items.Count + "<br>");
			// ��X�U�� ���s�˫�ק���O ����
			for(int i=0; i< DataGrid1.Items.Count ; i++)
			{
				// ��X c2_pub ����s���Ȥ� PK
				string iSyscd = "C2";
				string iContNo = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();
				string iYYYYMM = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
				iYYYYMM = iYYYYMM.Substring(0, 4) + iYYYYMM.Substring(5, 2);
				string iPubSeq = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
				string iDrafttp = DataGrid1.Items[i].Cells[22].Text.ToString().Trim();
				string injtpcd = ((TextBox)DataGrid1.Items[i].FindControl("tbxNjtpcd")).Text;
				string chgjbkno = ((TextBox)DataGrid1.Items[i].FindControl("tbxChgJBkNo")).Text;
				bool fgrechg = ((CheckBox)DataGrid1.Items[i].FindControl("cbxfgReChg")).Checked = true;
				string ifgrechg;
				if(fgrechg = true)
					ifgrechg = "1";
				else
					ifgrechg = "0";
				string ifgupdated = ((TextBox)DataGrid1.Items[i].FindControl("tbxfgupdated")).Text;
				//Response.Write("isyscd= " + iSyscd + "," );
				//Response.Write("iContNo=" + iContNo + "," );
				//Response.Write("iYYYYMM=" + iYYYYMM + "," );
				//Response.Write("iPubSeq=" + iPubSeq + ", " );
				//Response.Write("iDrafttp=" + iDrafttp + ", ");
				//Response.Write("injtpcd=" + injtpcd + ", ");
				//Response.Write("chgjbkno=" + chgjbkno + ", ");
				//Response.Write("fgrechg=" + fgrechg + ", ");
				//Response.Write("ifgrechg=" + ifgrechg + ", ");
				//Response.Write("ifgupdated=" + ifgupdated + "<br>");


				// �Y���s�Z�Χ�Z, �h���� ��s; �_�h��������B�z
				if(iDrafttp == "2" || iDrafttp == "3")
				{
					// �ˬd ���s�˫�ץ� �O�_���Ʀr���A�B���� 0~9 ��
					if(ifgupdated == "0" || ifgupdated == "1" || ifgupdated == "2" || ifgupdated == "3" || ifgupdated == "4" || ifgupdated == "5" || ifgupdated == "6" || ifgupdated == "7" || ifgupdated == "8" || ifgupdated == "9" )
					{
						// �s�Z
						if(iDrafttp == "2")
						{
							chgjbkno = "0";
							ifgrechg = " ";
							injtpcd = injtpcd;

							// �ˬd �s�Z�s�k�O�_�X�z
							if(injtpcd.Trim() != "")
							{
								// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
								DataSet ds2 = new DataSet();
								this.sqlDataAdapter2.Fill(ds2, "c2_njtp");
								DataView dv2 = ds2.Tables["c2_njtp"].DefaultView;

								// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
								// �] Row Filter: default �� cust_mfrno and ��L rowfilter ����
								string rowfilterstr2 = "1=1";
								rowfilterstr2 = rowfilterstr2 + " AND njtp_njtpcd = '" + injtpcd + "'";
								dv2.RowFilter = rowfilterstr2;

								// �ˬd�ÿ�X �̫� Row Filter �����G
								//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
								//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

								// �Y�j�M���G�� "���" ���B�z
								if (dv2.Count > 0)
								{
									chgjbkno = "0";
									ifgrechg = " ";
									injtpcd = injtpcd;

									// ���w sqlCommand1 Parameters
									this.sqlCommand1.Parameters["@njtpcd"].Value = injtpcd;
									this.sqlCommand1.Parameters["@chgjbkno"].Value = chgjbkno;
									this.sqlCommand1.Parameters["@fgrechg"].Value = ifgrechg;
									this.sqlCommand1.Parameters["@fgupdated"].Value = ifgupdated;
									this.sqlCommand1.Parameters["@syscd"].Value = iSyscd;
									this.sqlCommand1.Parameters["@contno"].Value = iContNo;
									this.sqlCommand1.Parameters["@yyyymm"].Value = iYYYYMM;
									this.sqlCommand1.Parameters["@pubseq"].Value = iPubSeq;
									//Response.Write(sqlCommand1.Parameters.Count.ToString().Trim());

									// �T�{���� sqlCommand1 ���\
									this.sqlCommand1.Connection.Open();
									//Response.Write(sqlCommand1.CommandText.ToString().Trim());
									// Transaction Starting ...
									System.Data.SqlClient.SqlTransaction myTrans1 = this.sqlCommand1.Connection.BeginTransaction();
									this.sqlCommand1.Transaction = myTrans1;
									try
									{
										this.sqlCommand1.ExecuteNonQuery();
										myTrans1.Commit();
									}
									catch(System.Data.SqlClient.SqlException ex1)
									{
										Response.Write(ex1.Message + "<br>");
										myTrans1.Rollback();
									}
									finally
									{
										this.sqlCommand1.Connection.Close();
									}
								}
								else
								{
									// �H Javascript �� window.alert()  �ӧi���T��
									LiteralControl litAlert3 = new LiteralControl();
									litAlert3.Text = "<script language=javascript>alert(\" �X���s��-�Z�n�~��-�����Ǹ��G" + iContNo + "-" + iYYYYMM + "-" + iPubSeq + " ���s�Z�s�k�N�X " + injtpcd + " ���X�z!\\n�Эץ�(�Ʀr0~9), �_�h�ӵ���ƵL�k�x�s!\");</script>";
									Page.Controls.Add(litAlert3);
								}
							}
						}


						// ��Z
						if(iDrafttp == "3")
						{
							chgjbkno = chgjbkno;
							ifgrechg = ifgrechg;
							injtpcd = "  ";

							// ���w sqlCommand1 Parameters
							this.sqlCommand1.Parameters["@njtpcd"].Value = injtpcd;
							this.sqlCommand1.Parameters["@chgjbkno"].Value = chgjbkno;
							this.sqlCommand1.Parameters["@fgrechg"].Value = ifgrechg;
							this.sqlCommand1.Parameters["@fgupdated"].Value = ifgupdated;
							this.sqlCommand1.Parameters["@syscd"].Value = iSyscd;
							this.sqlCommand1.Parameters["@contno"].Value = iContNo;
							this.sqlCommand1.Parameters["@yyyymm"].Value = iYYYYMM;
							this.sqlCommand1.Parameters["@pubseq"].Value = iPubSeq;
							//Response.Write(sqlCommand1.Parameters.Count.ToString().Trim());

							// �T�{���� sqlCommand1 ���\
							this.sqlCommand1.Connection.Open();
							//Response.Write(sqlCommand1.CommandText.ToString().Trim());
							// Transaction Starting ...
							System.Data.SqlClient.SqlTransaction myTrans2 = this.sqlCommand1.Connection.BeginTransaction();
							this.sqlCommand1.Transaction = myTrans2;
							try
							{
								this.sqlCommand1.ExecuteNonQuery();
								myTrans2.Commit();
							}
							catch(System.Data.SqlClient.SqlException ex1)
							{
								Response.Write(ex1.Message + "<br>");
								myTrans2.Rollback();
							}
							finally
							{
								this.sqlCommand1.Connection.Close();
							}
						}
					}
					// �ˬd ���s�˫�ץ� �O�_���Ʀr���A�B���� 0~9 �� => �_, ����ĵ�i
					else
					{
						// �H Javascript �� window.alert()  �ӧi���T��
						LiteralControl litAlert3 = new LiteralControl();
						litAlert3.Text = "<script language=javascript>alert(\" �X���s��-�Z�n�~��-�����Ǹ��G" + iContNo + "-" + iYYYYMM + "-" + iPubSeq + " �����s�˫�ץ� " + ifgupdated + " ���X�z!\\n�Эץ�, �_�h�ӵ���ƵL�k�x�s!\");</script>";
						Page.Controls.Add(litAlert3);
					}
				// ���� if(iDrafttp == "2" || iDrafttp == "3")
				}
			// ���� for loop
			}


			// Refresh DataGrid1
			litAlertWin.Text = "<script language=javascript>alert(\"�Y�N��s�������!\");</script>";
			BindGrid1();
		}


		// for �s�Z�s�k
		protected object GetVisiblity1(object drafttp)
		{
			//Response.Write("drafttp= " + drafttp.ToString() + "<br>");
			bool valReturn = false;
			if (drafttp.ToString() == "2")
			{
				valReturn = true;
			}
			return valReturn;
		}


		// �ˬd �s�Z���O�N�X �O�_��J�X�z
		protected object CheckNjtpcd(object njtpcd)
		{
			//Response.Write("njtpcd= " + njtpcd.ToString() + "<br>");
			bool valReturn = false;

			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c2_njtp");
			DataView dv2 = ds2.Tables["c2_njtp"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� cust_mfrno and ��L rowfilter ����
			string rowfilterstr2 = "1=1";
			rowfilterstr2 = rowfilterstr2 + " AND njtp_njtpcd = '" + njtpcd + "'";
			dv2.RowFilter = rowfilterstr2;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

			// �Y�j�M���G�� "���" ���B�z
			if (dv2.Count > 0)
			{
				valReturn = true;
				this.litAlertWin.Text = "";
			}
			else
			{
				valReturn = valReturn;

				// �H Javascript �� window.alert()  �ӧi���T��
				this.litAlertWin.Text = "<script language=javascript>alert(\" ���J���s�Z�s�k�N�X" + njtpcd + "���s�b(���X�z), �Эץ�!!!\");</script>";
			}
			return valReturn;
		}


		// for �½Z���O
		protected object GetVisiblity2(object drafttp)
		{
			//Response.Write("drafttp= " + drafttp.ToString() + "<br>");
			bool valReturn = false;
			if (drafttp.ToString() == "3")
			{
				valReturn = true;
			}
			return valReturn;
		}


		// for ��Z���X��
		protected object GetfgReChg(object fgrechg)
		{
			bool strReturn = false;
			if(fgrechg.ToString().Trim() == "1")
				strReturn = true;
			return strReturn;
		}


		// for ���s�˫�ק���O
		protected object GetfgUpdated(object drafttp)
		{
			//Response.Write("drafttp= " + drafttp.ToString() + "<br>");
			bool valReturn = false;
			if (drafttp.ToString() == "2")
			{
				valReturn = true;
			}
			if (drafttp.ToString() == "3")
			{
				valReturn = true;
			}
			return valReturn;
		}


		protected object CheckfgUpdated(object fgupdated)
		{
			fgupdated = fgupdated.ToString().Trim();
			//Response.Write("fgupdated= " + fgupdated.ToString() + "<br>");
			bool valReturn = false;

			if(fgupdated == "0" || fgupdated == "1" || fgupdated == "2" || fgupdated == "3" || fgupdated == "4" || fgupdated == "5" || fgupdated == "6" || fgupdated == "7" || fgupdated == "8" || fgupdated == "9" )
			{
				valReturn = true;
			}
			else
			{
				valReturn = valReturn;

				// �H Javascript �� window.alert()  �ӧi���T��
				this.litAlertWin.Text = "<script language=javascript>alert(\" ���J�����s�˫�ץ�" + fgupdated + "������J�Ʀr���A(0~9), �Эץ�!!!\");</script>";
			}
			return valReturn;
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
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_njtpcd", "pub_njtpcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgjbkno", "pub_chgjbkno"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgupdated", "pub_fgupdated")})});
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = "SELECT pub_syscd, pub_contno, pub_yyyymm, pub_pubseq, pub_njtpcd, pub_chgjbkno, p" +
				"ub_fgrechg, pub_fgupdated FROM dbo.c2_pub";
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
																									  new System.Data.Common.DataTableMapping("Table", "c2_njtp", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("njtp_njtpcd", "njtp_njtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("njtp_nm", "njtp_nm")})});
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT njtp_njtpcd, njtp_nm FROM dbo.c2_njtp";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("ID", "ID"),
																																																				new System.Data.Common.DataColumnMapping("����", "����"),
																																																				new System.Data.Common.DataColumnMapping("�X���ѽs��", "�X���ѽs��"),
																																																				new System.Data.Common.DataColumnMapping("�����Ǹ�", "�����Ǹ�"),
																																																				new System.Data.Common.DataColumnMapping("�Z�n�~��", "�Z�n�~��"),
																																																				new System.Data.Common.DataColumnMapping("�Z�n���X", "�Z�n���X"),
																																																				new System.Data.Common.DataColumnMapping("�s�i��m�N�X", "�s�i��m�N�X"),
																																																				new System.Data.Common.DataColumnMapping("�s�i�����N�X", "�s�i�����N�X"),
																																																				new System.Data.Common.DataColumnMapping("�s�i�g�T�N�X", "�s�i�g�T�N�X"),
																																																				new System.Data.Common.DataColumnMapping("�T�w�������O", "�T�w�������O"),
																																																				new System.Data.Common.DataColumnMapping("��Z���O", "��Z���O"),
																																																				new System.Data.Common.DataColumnMapping("�����~�ȭ��u��", "�����~�ȭ��u��"),
																																																				new System.Data.Common.DataColumnMapping("�Ƶ�", "�Ƶ�"),
																																																				new System.Data.Common.DataColumnMapping("�½Z���y�N�X", "�½Z���y�N�X"),
																																																				new System.Data.Common.DataColumnMapping("�½Z���O", "�½Z���O"),
																																																				new System.Data.Common.DataColumnMapping("�½Z���X", "�½Z���X"),
																																																				new System.Data.Common.DataColumnMapping("��Z���y�N�X", "��Z���y�N�X"),
																																																				new System.Data.Common.DataColumnMapping("��Z���O", "��Z���O"),
																																																				new System.Data.Common.DataColumnMapping("��Z���X", "��Z���X"),
																																																				new System.Data.Common.DataColumnMapping("��Z���X�����O", "��Z���X�����O"),
																																																				new System.Data.Common.DataColumnMapping("�s�Z�s�k�N�X", "�s�Z�s�k�N�X"),
																																																				new System.Data.Common.DataColumnMapping("���q�W��", "���q�W��"),
																																																				new System.Data.Common.DataColumnMapping("����2", "����2"),
																																																				new System.Data.Common.DataColumnMapping("���y���O�N�X", "���y���O�N�X"),
																																																				new System.Data.Common.DataColumnMapping("�s�i��m", "�s�i��m"),
																																																				new System.Data.Common.DataColumnMapping("�s�i����", "�s�i����"),
																																																				new System.Data.Common.DataColumnMapping("�s�i�g�T", "�s�i�g�T"),
																																																				new System.Data.Common.DataColumnMapping("�s�Z�s�k", "�s�Z�s�k"),
																																																				new System.Data.Common.DataColumnMapping("�½Z���y�W��", "�½Z���y�W��"),
																																																				new System.Data.Common.DataColumnMapping("�����~�ȭ��m�W", "�����~�ȭ��m�W"),
																																																				new System.Data.Common.DataColumnMapping("�Z�����O�N�X", "�Z�����O�N�X"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				new System.Data.Common.DataColumnMapping("���s�˫�ק���O", "���s�˫�ק���O"),
																																																				new System.Data.Common.DataColumnMapping("�s�i�u������", "�s�i�u������"),
																																																				new System.Data.Common.DataColumnMapping("lp_bkcd", "lp_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("njtp_nostr", "njtp_nostr")})});
			//
			// sqlCommand1
			//
			this.sqlCommand1.CommandText = "UPDATE c2_pub SET pub_njtpcd = @njtpcd, pub_chgjbkno = @chgjbkno, pub_fgrechg = @" +
				"fgrechg, pub_fgupdated = @fgupdated WHERE (pub_syscd = @syscd) AND (pub_contno =" +
				" @contno) AND (pub_yyyymm = @yyyymm) AND (pub_pubseq = @pubseq)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@njtpcd", System.Data.SqlDbType.Char, 2, "pub_njtpcd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@chgjbkno", System.Data.SqlDbType.Int, 4, "pub_chgjbkno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgrechg", System.Data.SqlDbType.Char, 1, "pub_fgrechg"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgupdated", System.Data.SqlDbType.Char, 1, "pub_fgupdated"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, "pub_syscd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, "pub_contno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.Char, 6, "pub_yyyymm"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubseq", System.Data.SqlDbType.Char, 2, "pub_pubseq"));
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT TOP 100 PERCENT dbo.c2_pub.pub_pubid AS ID, 0 AS ����, RTRIM(dbo.c2_pub.pub_" +
				"contno) AS �X���ѽs��, RTRIM(dbo.c2_pub.pub_pubseq) AS �����Ǹ�, RTRIM(dbo.c2_pub.pub_yyy" +
				"ymm) AS �Z�n�~��, dbo.c2_pub.pub_pgno AS �Z�n���X, RTRIM(dbo.c2_pub.pub_clrcd) AS �s�i��m�N�X" +
				", RTRIM(dbo.c2_pub.pub_pgscd) AS �s�i�����N�X, RTRIM(dbo.c2_pub.pub_ltpcd) AS �s�i�g�T�N�X, " +
				"RTRIM(dbo.c2_pub.pub_fgfixpg) AS �T�w�������O, RTRIM(dbo.c2_pub.pub_fggot) AS ��Z���O, RT" +
				"RIM(dbo.c2_pub.pub_modempno) AS �����~�ȭ��u��, RTRIM(dbo.c2_pub.pub_remark) AS �Ƶ�, RTR" +
				"IM(dbo.c2_pub.pub_origbkcd) AS �½Z���y�N�X, RTRIM(dbo.c2_pub.pub_origjno) AS �½Z���O, RT" +
				"RIM(dbo.c2_pub.pub_origjbkno) AS �½Z���X, RTRIM(dbo.c2_pub.pub_chgbkcd) AS ��Z���y�N�X, " +
				"RTRIM(dbo.c2_pub.pub_chgjno) AS ��Z���O, RTRIM(dbo.c2_pub.pub_chgjbkno) AS ��Z���X, RT" +
				"RIM(dbo.c2_pub.pub_fgrechg) AS ��Z���X�����O, RTRIM(dbo.c2_pub.pub_njtpcd) AS �s�Z�s�k�N�X, " +
				"RTRIM(dbo.mfr.mfr_inm) AS ���q�W��, 8 AS ����2, RTRIM(dbo.c2_pub.pub_bkcd) AS ���y���O�N�X, " +
				"RTRIM(dbo.c2_clr.clr_nm) AS �s�i��m, RTRIM(dbo.c2_ltp.ltp_nm) AS �s�i����, RTRIM(dbo.c2" +
				"_pgsize.pgs_nm) AS �s�i�g�T, RTRIM(dbo.c2_njtp.njtp_nm) AS �s�Z�s�k, RTRIM(dbo.book.bk_n" +
				"m) AS �½Z���y�W��, RTRIM(dbo.srspn.srspn_cname) AS �����~�ȭ��m�W, RTRIM(dbo.c2_pub.pub_draf" +
				"ttp) AS �Z�����O�N�X, dbo.c2_pub.pub_contno, dbo.c2_pub.pub_pubseq, dbo.c2_pub.pub_sys" +
				"cd, dbo.c2_pub.pub_yyyymm, dbo.c2_pub.pub_fgupdated AS ���s�˫�ק���O, dbo.c2_lprior.l" +
				"p_priorseq AS �s�i�u������, dbo.c2_lprior.lp_bkcd, dbo.c2_pub.pub_njtpcd + \' \' + dbo.c" +
				"2_njtp.njtp_nm AS njtp_nostr FROM dbo.c2_pub INNER JOIN dbo.c2_cont ON dbo.c2_pu" +
				"b.pub_contno = dbo.c2_cont.cont_contno AND dbo.c2_pub.pub_syscd = dbo.c2_cont.co" +
				"nt_syscd INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER " +
				"JOIN dbo.c2_lprior ON dbo.c2_pub.pub_ltpcd = dbo.c2_lprior.lp_ltpcd AND dbo.c2_p" +
				"ub.pub_clrcd = dbo.c2_lprior.lp_clrcd AND dbo.c2_pub.pub_pgscd = dbo.c2_lprior.l" +
				"p_pgscd AND dbo.c2_pub.pub_bkcd = dbo.c2_lprior.lp_bkcd LEFT OUTER JOIN dbo.c2_c" +
				"lr ON dbo.c2_pub.pub_clrcd = dbo.c2_clr.clr_clrcd LEFT OUTER JOIN dbo.c2_pgsize " +
				"ON dbo.c2_pub.pub_pgscd = dbo.c2_pgsize.pgs_pgscd LEFT OUTER JOIN dbo.c2_ltp ON " +
				"dbo.c2_pub.pub_ltpcd = dbo.c2_ltp.ltp_ltpcd LEFT OUTER JOIN dbo.c2_njtp ON dbo.c" +
				"2_pub.pub_njtpcd = dbo.c2_njtp.njtp_njtpcd LEFT OUTER JOIN dbo.book ON dbo.c2_pu" +
				"b.pub_origbkcd = dbo.book.bk_bkcd LEFT OUTER JOIN dbo.srspn ON dbo.c2_cont.cont_" +
				"empno = dbo.srspn.srspn_empno WHERE (dbo.c2_cont.cont_fgclosed = \'0\') AND (dbo.c" +
				"2_cont.cont_fgcancel = \'0\') AND (dbo.c2_cont.cont_fgtemp = \'0\') AND (dbo.c2_cont" +
				".cont_fgpubed = \'1\') ORDER BY �s�i�u������, �Z�n���X, �X���ѽs��, �Z�n�~�� DESC, �����Ǹ�";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion




	}
}
