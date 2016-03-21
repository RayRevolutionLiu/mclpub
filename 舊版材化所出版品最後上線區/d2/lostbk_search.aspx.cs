using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
	/// Summary description for lostbk_search.
	/// </summary>
	public class lostbk_search : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Web.UI.WebControls.TextBox tbxMfrIName;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxORName;
		protected System.Web.UI.WebControls.TextBox tbxORTel;
		protected System.Web.UI.WebControls.TextBox tbxORAddr;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.RadioButtonList rblSent;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Web.UI.WebControls.LinkButton lnbClearAll;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.LinkButton lnbSearch;

		public lostbk_search()
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

				if(Context.Request.QueryString["function1"]=="new")
				{
					this.rblSent.Enabled = false;
				}
			}
		}


		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		// ���U "�d��" ���s�ɪ��B�z
		private void lnbSearch_Click(object sender, System.EventArgs e)
		{
			// �P�_�B�z�����A: �s�W �� �ק�/�R��
			if(Context.Request.QueryString["function1"]=="new")
			{
				//Response.Write("DataGrid1<br>");
				DataGrid1.CurrentPageIndex = 0;
				BindGrid1();
			}
			else if(Context.Request.QueryString["function1"]=="mod")
			{
				//Response.Write("DataGrid2<br>");
				DataGrid2.CurrentPageIndex = 0;
				BindGrid2();
			}
		}


		// DataGrid1 �� DataBind()
		private void BindGrid1()
		{
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_or");
			DataView dv1 = ds1.Tables["c2_or"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� cust_mfrno and ��L rowfilter ����
			string rowfilterstr1 = " mfr_mfrno Like '%" + tbxMfrNo.Text.Trim() + "%'";

			if(this.tbxContNo.Text!="")
				rowfilterstr1 = rowfilterstr1 + " and cont_contno Like '%" + this.tbxContNo.Text.Trim() + "%'";

			if(this.tbxMfrIName.Text!="")
				rowfilterstr1 = rowfilterstr1 + " and mfr_inm Like '%" + tbxMfrIName.Text.Trim() + "%'";

			if(this.tbxCustNo.Text!="")
				rowfilterstr1 = rowfilterstr1 + " and cont_custno ='" + tbxCustNo.Text.Trim() + "'";

			if(this.tbxCustName.Text!="")
				rowfilterstr1 = rowfilterstr1 + " and cust_nm Like '%" + tbxCustName.Text.Trim() + "%'";

			if(this.tbxORName.Text!="")
				rowfilterstr1 = rowfilterstr1 + " and or_nm like '%" + tbxORName.Text.Trim() + "%'";

			if(this.tbxORTel.Text!="")
				rowfilterstr1 = rowfilterstr1 + " and or_tel like '%" + tbxORTel.Text.Trim() + "%'";

			if(this.tbxORAddr.Text!="")
				rowfilterstr1 = rowfilterstr1 + " and or_addr like '%" + tbxORAddr.Text.Trim() + "%'";
//			�p�G�OD�ŷ~�ȤH���A�u��ݨ�ۤv���Ȥ���
			if(Session["atype"].ToString().Equals("D"))
				rowfilterstr1=rowfilterstr1+" and mfr_mfrno in (" + this.FindMfrByEmpno(Session["empid"].ToString()) + ")";
			dv1.RowFilter = rowfilterstr1;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			// �Y�j�M���G�� "�䤣��" ���B�z
			if (dv1.Count <= 0)
			{
				this.lblMessage.Visible = true;
				this.lblMessage.Text="���G: �䤣��ŦX���󪺸��, �z�i�H���]����!";
			}
			else
			{
				this.lblMessage.Visible = true;
				this.lblMessage.Text="���G: ��� " + dv1.Count.ToString() + "�����";

				DataGrid1.DataSource = dv1;
				DataGrid1.DataBind();


				// �S�O��줧��X�榡�ഫ - �ܧ�ñ��������榡
				int i;
				for(i=0; i< DataGrid1.Items.Count ; i++)
				{
					// �X�����O
					int ContTypeCode = int.Parse(DataGrid1.Items[i].Cells[1].Text.ToString().Trim());
					if(ContTypeCode==1)
						DataGrid1.Items[i].Cells[1].Text = "�@��X��";
					else
					{
						DataGrid1.Items[i].Cells[1].Text = "���s�X��";
						DataGrid1.Items[i].Cells[1].ForeColor = Color.Blue;
					}

					// ñ�����
					string signdate = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
					if(signdate.Length >=8)
					{
						signdate = signdate.Substring(0, 4) + "/" + signdate.Substring(4, 2) + "/" + signdate.Substring(6, 2);
					}
					else
						signdate = signdate;
					DataGrid1.Items[i].Cells[3].Text = signdate;

					// �X���_��
					string sdate = DataGrid1.Items[i].Cells[6].Text.ToString().Trim();
					if(sdate.Length >=6)
					{
						sdate = sdate.Substring(0, 4) + "/" + sdate.Substring(4, 2);
					}
					else
						signdate = sdate;
					DataGrid1.Items[i].Cells[6].Text = sdate;

					// �X������
					string edate = DataGrid1.Items[i].Cells[7].Text.ToString().Trim();
					if(edate.Length >=6)
					{
						edate = edate.Substring(0, 4) + "/" + edate.Substring(4, 2);
					}
					else
						edate = edate;
					DataGrid1.Items[i].Cells[7].Text = edate;

					// ���׵��O
					string fgclosed = DataGrid1.Items[i].Cells[8].Text.ToString().Trim();
					if(fgclosed == "0")
						DataGrid1.Items[i].Cells[8].Text = "�_";
					else
					{
						DataGrid1.Items[i].Cells[8].Text = "�O";
						DataGrid1.Items[i].Cells[8].ForeColor = Color.Red;
					}

					// �w�������O
					string fgpubed = DataGrid1.Items[i].Cells[15].Text.ToString().Trim();
					if(fgpubed == "0")
						DataGrid1.Items[i].Cells[15].Text = "�_";
					else
					{
						DataGrid1.Items[i].Cells[15].Text = "�O";
						DataGrid1.Items[i].Cells[15].ForeColor = Color.Red;
					}

					// �w���P���O
					string fgcancel = DataGrid1.Items[i].Cells[16].Text.ToString().Trim();
					if(fgcancel == "0")
						DataGrid1.Items[i].Cells[16].Text = "�_";
					else
					{
						DataGrid1.Items[i].Cells[16].Text = "�O";
						DataGrid1.Items[i].Cells[16].ForeColor = Color.Red;
					}
				}
			}
		}

		private string FindMfrByEmpno(string empno)
		{
			SqlConnection connection = new SqlConnection(configurationAppSettings["itridpa_mrlpub"]);
			connection.Open();
			string sql = "select cont_mfrno from c2_cont where cont_empno = '" + empno + "' group by cont_mfrno";
			SqlCommand com = new SqlCommand(sql,connection);
			SqlDataReader dr = com.ExecuteReader();
			string mfrnos = "";
			while(dr.Read())
				mfrnos += "'" + dr[0] + "',";

			dr.Close();
			connection.Close();
			if(mfrnos.Length > 0)
				return mfrnos.Substring(0,mfrnos.Length-1);
			else
				return "''";
		}


		// ���U "�T�w" ���B�z, ��}
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.SelectedIndex = e.Item.ItemIndex;

			if(e.CommandName=="Select")
			{
				// ���w�����ܼ�
				string strContNo = DataGrid1.SelectedItem.Cells[0].Text.Trim();
				string strORItem = DataGrid1.SelectedItem.Cells[9].Text.Trim();
				string strSEDate = DataGrid1.SelectedItem.Cells[13].Text.Trim()+DataGrid1.SelectedItem.Cells[14].Text.Trim();
				//Response.Write("strContNo= " + strContNo + "<br>");
				//Response.Write("strORItem= " + strORItem + "<br>");
				//Response.Write("strSEDate= " + strSEDate + "<br>");

				// ��}�B�z
				string strbuf;
				strbuf = "lostbk_1.aspx?contno=" + strContNo  + "&oritem=" + strORItem + "&sedate=" + strSEDate;
				//Response.Write("strbuf= " + strbuf + "<br>");
				Response.Redirect(strbuf);
			}

		}


		// DataGrid1 �����B�z
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			BindGrid1();
		}


		// DataGrid2 �� DataBind()
		private void BindGrid2()
		{
			// ���w �H�Ѫ��A �� - ���H�X = 0; �w�H�X = 1 (C)
			string strbuf="";
			if(this.rblSent.SelectedItem.Value == "0")
				strbuf = "lst_fgsent <> 'C'";
			else if(this.rblSent.SelectedItem.Value == "1")
				strbuf = "lst_fgsent = 'C'";
			//Response.Write("strbuf= " + strbuf + "<br>");


			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c2_lost");
			DataView dv2 = ds2.Tables["c2_lost"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� cust_mfrno and ��L rowfilter ����
			string rowfilterstr2 = " mfr_mfrno Like '%" + tbxMfrNo.Text.Trim() + "%'";

			if(this.tbxContNo.Text!="")
				rowfilterstr2 = rowfilterstr2 + " and lst_contno Like '%" + this.tbxContNo.Text.Trim() + "%'";

			if(this.tbxMfrIName.Text!="")
				rowfilterstr2 = rowfilterstr2 + " and mfr_inm Like '%" + tbxMfrIName.Text.Trim() + "%'";

			if(this.tbxCustNo.Text!="")
				rowfilterstr2 = rowfilterstr2 + " and lst_custno ='" + tbxCustNo.Text.Trim() + "'";

			if(this.tbxCustName.Text!="")
				rowfilterstr2 = rowfilterstr2 + " and cust_nm Like '%" + tbxCustName.Text.Trim() + "%'";

			if(this.tbxORName.Text!="")
				rowfilterstr2 = rowfilterstr2 + " and or_nm like '%" + tbxORName.Text.Trim() + "%'";

			if(this.tbxORTel.Text!="")
				rowfilterstr2 = rowfilterstr2 + " and or_tel like '%" + tbxORTel.Text.Trim() + "%'";

			if(this.tbxORAddr.Text!="")
				rowfilterstr2 = rowfilterstr2 + " and or_addr like '%" + tbxORAddr.Text.Trim() + "%'";
			//�p�G�OD�ŷ~�ȤH���A�u��ݨ�ۤv���Ȥ���
			if(Session["atype"].ToString().Equals("D"))
				rowfilterstr2=rowfilterstr2+" and mfr_mfrno in (" + this.FindMfrByEmpno(Session["empid"].ToString()) + ")";			
			rowfilterstr2 = rowfilterstr2 + " and " + strbuf;
			dv2.RowFilter = rowfilterstr2;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

			// �Y�j�M���G�� "�䤣��" ���B�z
			if (dv2.Count <= 0)
			{
				this.lblMessage.Visible = true;
				this.lblMessage.Text="���G: �䤣��ŦX���󪺸��, �z�i�H���]����!";
			}
			else
			{
				this.lblMessage.Visible = true;
				this.lblMessage.Text="���G: ��� " + dv2.Count.ToString() + "�����";

				DataGrid2.DataSource = dv2;
				DataGrid2.DataBind();


				// �S�O��줧��X�榡�ഫ - �ܧ�ñ��������榡
				int i;
				for(i=0; i< DataGrid2.Items.Count ; i++)
				{
					// �X�����O
					string Conttp = DataGrid2.Items[i].Cells[3].Text.ToString();
					if(Conttp == "01")
						DataGrid2.Items[i].Cells[3].Text = "�@��X��";
					else if(Conttp == "09")
						DataGrid2.Items[i].Cells[3].Text = "<font color=blue>���s�X��</font>";

					// �ʮѤ��
					string LostDate = DataGrid2.Items[i].Cells[10].Text.ToString().Trim();
					if(LostDate.Length >= 8)
					{
						LostDate = LostDate.Substring(0, 4) + "/" + LostDate.Substring(4, 2) + "/" + LostDate.Substring(6, 2);
					}
					else
						LostDate = LostDate;
					DataGrid2.Items[i].Cells[10].Text = LostDate;

					// �w�H�X���O
					string fgsent = DataGrid2.Items[i].Cells[11].Text.ToString().Trim();
					string fgsentText = "";
					if(fgsent == "Y")
						fgsentText = "<font color='Gray'>�i�H�X</font>";
					else if(fgsent == "D")
						fgsentText = "<font color='Blue'>���B�z</font>";
					else if(fgsent == "N")
						fgsentText = "<font color='Red'>�ثe�ȮɵL�k�H�X</font>";
					else if(fgsent == "C")
						fgsentText = "�w�H�X";
					DataGrid2.Items[i].Cells[11].Text = fgsentText;

				}
			}
		}


		private void DataGrid2_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid2.SelectedIndex = e.Item.ItemIndex;


			if(e.CommandName == "Select")
			{
				// ���w�����ܼ� - ��X PK ��
				string strSyscd = "C2";
				string strContNo = DataGrid2.SelectedItem.Cells[1].Text.ToString().Trim();
				string strORItem = DataGrid2.SelectedItem.Cells[7].Text.ToString();
				string strLostSeq = DataGrid2.SelectedItem.Cells[2].Text.ToString();
				//Response.Write("strSyscd= " + strSyscd + ", ");
				//Response.Write("strContNo= " + strContNo + ", ");
				//Response.Write("strORItem= " + strORItem + ", ");
				//Response.Write("strLostSeq= " + strLostSeq + "<br>");

				// ��}�B�z
				string	strbuf;
				strbuf = "lostbk_2.aspx?contno=" + strContNo + "&lstseq="+ strLostSeq + "&oritem=" + strORItem;
				//Response.Write("strbuf= " + strbuf + "<br>");
				Response.Redirect(strbuf);
			}
		}


		// DataGrid2 �����B�z
		private void DataGrid2_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid2.CurrentPageIndex = e.NewPageIndex;
			BindGrid2();
		}


		// DataGrid2 �R���B�z
		private void DataGrid2_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			// ��X PK ��, �H�y�ᰵ �R���ʧ@
			string strSyscd = "C2";
			string strContNo = DataGrid2.SelectedItem.Cells[1].Text.ToString().Trim();
			string strORItem = DataGrid2.SelectedItem.Cells[7].Text.ToString();
			string strLostSeq = DataGrid2.SelectedItem.Cells[2].Text.ToString();
			//Response.Write("strSyscd= " + strSyscd + ", ");
			//Response.Write("strContNo= " + strContNo + ", ");
			//Response.Write("strORItem= " + strORItem + ", ");
			//Response.Write("strLostSeq= " + strLostSeq + "<br>");

			// ���� �N�ȶ�J sqlCommand1.Parameters ��, �H���� �s�W�J��Ʈw
			this.sqlCommand1.Parameters["@syscd"].Value = strSyscd;
			this.sqlCommand1.Parameters["@contno"].Value = strContNo;
			this.sqlCommand1.Parameters["@oritem"].Value = strORItem;
			this.sqlCommand1.Parameters["@lstseq"].Value = strLostSeq;

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


			// Refresh DataGrid2
			BindGrid2();
			DataGrid2.SelectedIndex=-1;
		}


		// �M�����d ���s���B�z
		private void lnbClearAll_Click(object sender, System.EventArgs e)
		{
			// ��}
			Response.Redirect("lostbk_search.aspx?function1=" + Context.Request.QueryString["function1"]);
		}


		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.lnbSearch.Click += new System.EventHandler(this.lnbSearch_Click);
			this.lnbClearAll.Click += new System.EventHandler(this.lnbClearAll_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid2.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_ItemCommand);
			this.DataGrid2.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid2_PageIndexChanged);
			this.DataGrid2.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_DeleteCommand);
			//
			// sqlCommand1
			//
			this.sqlCommand1.CommandText = "DELETE FROM c2_lost WHERE (lst_syscd = @syscd) AND (lst_contno = @contno) AND (ls" +
				"t_oritem = @oritem) AND (lst_seq = @lstseq)";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, "lst_syscd"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, "lst_contno"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@oritem", System.Data.SqlDbType.Char, 2, "lst_oritem"));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@lstseq", System.Data.SqlDbType.Char, 2, "lst_seq"));
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
																									  new System.Data.Common.DataTableMapping("Table", "c2_lost", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("lst_oritem", "lst_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("lst_seq", "lst_seq"),
																																																				 new System.Data.Common.DataColumnMapping("lst_cont", "lst_cont"),
																																																				 new System.Data.Common.DataColumnMapping("lst_date", "lst_date"),
																																																				 new System.Data.Common.DataColumnMapping("lst_rea", "lst_rea"),
																																																				 new System.Data.Common.DataColumnMapping("lst_fgsent", "lst_fgsent"),
																																																				 new System.Data.Common.DataColumnMapping("lst_contno", "lst_contno"),
																																																				 new System.Data.Common.DataColumnMapping("lst_syscd", "lst_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("lst_sdate", "lst_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("lst_edate", "lst_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																				 new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_zip", "or_zip"),
																																																				 new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				 new System.Data.Common.DataColumnMapping("or_tel", "or_tel"),
																																																				 new System.Data.Common.DataColumnMapping("or_mtpcd", "or_mtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("or_pubcnt", "or_pubcnt"),
																																																				 new System.Data.Common.DataColumnMapping("or_unpubcnt", "or_unpubcnt"),
																																																				 new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																				 new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd")})});
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.c2_lost.lst_oritem, dbo.c2_lost.lst_seq, dbo.c2_lost.lst_cont, dbo.c2_lost.lst_date, dbo.c2_lost.lst_rea, dbo.c2_lost.lst_fgsent, dbo.c2_lost.lst_contno, dbo.c2_lost.lst_syscd, dbo.c2_lost.lst_sdate, dbo.c2_lost.lst_edate, dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_mfrno, dbo.mfr.mfr_inm, dbo.cust.cust_nm, dbo.c2_or.or_inm, dbo.c2_or.or_nm, dbo.c2_or.or_zip, dbo.c2_or.or_addr, dbo.c2_or.or_tel, dbo.c2_or.or_mtpcd, dbo.c2_or.or_pubcnt, dbo.c2_or.or_unpubcnt, dbo.c2_or.or_fgmosea, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_syscd, dbo.c2_or.or_contno, dbo.c2_or.or_oritem, dbo.c2_or.or_syscd, dbo.cust.cust_custno, dbo.mfr.mfr_mfrno, dbo.book.bk_nm, dbo.book.bk_bkcd FROM dbo.c2_lost INNER JOIN dbo.c2_cont ON dbo.c2_lost.lst_syscd = dbo.c2_cont.cont_syscd AND dbo.c2_lost.lst_contno = dbo.c2_cont.cont_contno INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER JOIN dbo.c2_or ON dbo.c2_lost.lst_syscd = dbo.c2_or.or_syscd AND dbo.c2_lost.lst_contno = dbo.c2_or.or_contno AND dbo.c2_lost.lst_oritem = dbo.c2_or.or_oritem INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd";
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
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				 new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																				 new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				 new System.Data.Common.DataColumnMapping("or_addr", "or_addr"),
																																																				 new System.Data.Common.DataColumnMapping("or_tel", "or_tel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																				 new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_mfrno, dbo.mfr.mfr_inm, dbo.c2_cont.cont_bkcd, dbo.book.bk_nm, dbo.c2_or.or_oritem, dbo.c2_or.or_inm, dbo.c2_or.or_nm, dbo.c2_or.or_addr, dbo.c2_or.or_tel, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate, dbo.c2_cont.cont_custno, dbo.cust.cust_nm, dbo.book.bk_bkcd, dbo.c2_or.or_contno, dbo.c2_or.or_syscd, dbo.cust.cust_custno, dbo.mfr.mfr_mfrno, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgpubed, dbo.c2_cont.cont_fgtemp FROM dbo.c2_cont INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER JOIN dbo.c2_or ON dbo.c2_cont.cont_syscd = dbo.c2_or.or_syscd AND dbo.c2_cont.cont_contno = dbo.c2_or.or_contno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
