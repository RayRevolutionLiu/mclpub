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
	/// Summary description for cont_new2.
	/// </summary>
	public class cont_new2 : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.DataGrid dgdCont;
		protected System.Web.UI.WebControls.Label lblRemark;
		protected System.Web.UI.WebControls.Label lblCaption;
		protected System.Web.UI.WebControls.Literal literal1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Button btnNew;

		public cont_new2()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			
			if (!IsPostBack)
			{
				Response.Expires=0;
				
				//�ǥѫe�@�����ǨӪ��ܼƭȦr�� custno
				string custno=Context.Request.QueryString["custno"].Trim();
				//Response.Write("custno= "+ custno + "<BR>");
//				string conttp=Context.Request.QueryString["conttp"].Trim();
//				//Response.Write("conttp= "+ conttp + "<BR>");
				
				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "c2_cont");
				DataView dv1 = ds1.Tables["c2_cont"].DefaultView;
				
				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
				// �] Row Filter: default �� cust_mfrno and ��L rowfilter ����
				//dv1.RowFilter="cont_syscd='c2' and cont_custno='" + custno + "'" + " and cont_conttp='" + conttp +"'";
				dv1.RowFilter="cont_syscd='c2' and cont_custno='" + custno + "'";
				
				// �ˬd�ÿ�X �̫� Row Filter �����G
				//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
				//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
				
				//���b�B�z: �Y�L��Ʈ�, �h�����~�T��
				//if (dv1.Count < 1)  ...
				// �Y�����, �h�b Server Web Control ��ܤ�
				
				
				// �Y�j�M���G�� "�䤣��" ���B�z
				if(dv1.Count==0)
				{
					this.lblMessage.Text="���Ȥ�S�����v�q��, �Ы��k����s =>";
					this.btnNew.Visible=true;
					this.lblCaption.Visible=false;
				}
				else
				{
					this.lblMessage.Text = "���Ȥᦳ " + dv1.Count.ToString() + "�����v���";
					dgdCont.DataSource=dv1;
					dgdCont.DataBind();
					

					//���O�� => �ƭȧ�H��r���
					int i;
					for(i=0; i< dgdCont.Items.Count ; i++)
					{
						// �X�����O
						string strconttp = dgdCont.Items[i].Cells[1].Text.ToString().Trim();
						//Response.Write("strconttp= " + strconttp + "<br>");
						if(strconttp == "01")
						{
							dgdCont.Items[i].Cells[1].Text = "�@��";
						}
						else
						{
							dgdCont.Items[i].Cells[1].Text = "<font color=red>���s</font>";
						}
						
						// ñ�����
						string SignDate = dgdCont.Items[i].Cells[3].Text.ToString().Trim();
						//dgdCont.Items[i].Cells[3].Text = SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
						if(SignDate != "")
						{
							if(SignDate.Length >= 7)
								SignDate = SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
							else
							{
								// ���� \ �Ÿ��H���o�Ʀr
								if(SignDate.IndexOf("\\") != -1)
								{
									//SignDate = SignDate.Split('/', 2);
								}
								else
									SignDate = SignDate;
							}
						}
						else
						{
							SignDate = SignDate;
						}
						dgdCont.Items[i].Cells[3].Text = SignDate;
						
						// �X���_��
						string StartDate = dgdCont.Items[i].Cells[4].Text.ToString().Trim();
						//dgdCont.Items[i].Cells[4].Text = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
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
						dgdCont.Items[i].Cells[4].Text = StartDate;
						
						// �X������
						string EndDate = dgdCont.Items[i].Cells[5].Text.ToString().Trim();
						//dgdCont.Items[i].Cells[5].Text = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
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
						dgdCont.Items[i].Cells[5].Text = EndDate;
						
						// �@���I�M���O
						string strfgpayonce = dgdCont.Items[i].Cells[9].Text.ToString().Trim();
						//Response.Write("strfgpayonce= " + strfgpayonce + "<br>");
						if(strfgpayonce != "")
						{
							if(strfgpayonce == "0")
							{
								dgdCont.Items[i].Cells[9].Text = "�_";
							}
							else if(strfgpayonce == "1")
							{
								dgdCont.Items[i].Cells[9].Text = "<font color=red>�O</font>";
							}
						}
						else
						{
							dgdCont.Items[i].Cells[9].Text = "<font color='Gray'>(�L���)</font>";
						}
						
						// ���׵��O
						string strfgclosed = dgdCont.Items[i].Cells[10].Text.ToString().Trim();
						//Response.Write("strfgclosed= " + strfgclosed + "<br>");
						if(strfgclosed == "0")
						{
							dgdCont.Items[i].Cells[10].Text = "�_";
						}
						else
						{
							dgdCont.Items[i].Cells[10].Text = "<font color=red>�O</font>";
						}
						
						// �w�������O
						string strfgpubed = dgdCont.Items[i].Cells[15].Text.ToString().Trim();
						//Response.Write("strfgpubed= " + strfgpubed + "<br>");
						if(strfgpubed == "0")
						{
							dgdCont.Items[i].Cells[15].Text = "�_";
						}
						else
						{
							dgdCont.Items[i].Cells[15].Text = "<font color=red>�O</font>";
						}
					
					// ���O�� for loop ����
					}
					
				}
				// �ˬd�ÿ�X �̫� Row Filter �����G
				//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
				//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
				
				
				// �̥ثe�n�D���ʧ@(�s�W/�ק�) ����ܤ��P�T��
				if(Context.Request.QueryString["function1"]=="new")
					this.lblCaption.Text="<br>��: ��� [��ܸ��] �i�˵��X���Ѫ���l���, �� [�T�w�s�W] �Y�N�i�J�s�W�e��";
				else if(Context.Request.QueryString["function1"]=="mod")
					this.lblCaption.Text="<br>��: ��� [��ܸ��] �i�˵��X���Ѫ���l���, �� [�T�w�ק�] �Y�N�i�J�ק�e��";		
				
			}
		}

		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}

		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			this.dgdCont.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdCont_ItemCommand);
			this.dgdCont.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdCont_PageIndexChanged);
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
//				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_contid", "cont_contid"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_disc", "cont_disc"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_clrtm", "cont_clrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_menotm", "cont_menotm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_getclrtm", "cont_getclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT c2_cont.cont_contid, c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_custno, c2_cont.cont_conttp, c2_cont.cont_bkcd, c2_cont.cont_signdate, c2_cont.cont_mfrno, c2_cont.cont_aunm, c2_cont.cont_autel, c2_cont.cont_fgclosed, c2_cont.cont_fgpayonce, book.bk_nm, book.bk_bkcd, mfr.mfr_inm, c2_cont.cont_disc, mfr.mfr_mfrno, c2_cont.cont_clrtm, c2_cont.cont_menotm, c2_cont.cont_getclrtm, c2_cont.cont_fgpubed, c2_cont.cont_sdate, c2_cont.cont_edate FROM c2_cont INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno ORDER BY c2_cont.cont_contno DESC";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		

		/// <summary>
		/// ���U "��ܸ��/�T�w�s�W" ���ʧ@
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void dgdCont_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			dgdCont.SelectedIndex=e.Item.ItemIndex;
			//Response.Write(DataGrid1.SelectedItem.Cells[2].Text);
			//Response.Write("contno= " + dgdCont.SelectedItem.Cells[0].Text.Trim());
			
			// �Y���U��ܸ�ƪ��ʧ@, ����}�� ContFm_show.aspx
			if(e.CommandName=="Detail")
			{
				//Response.Write("custno= " + Context.Request.QueryString["custno"] + "<br>");
				//Response.Write("conttp= " + Context.Request.QueryString["conttp"] + "<br>");
				//Response.Write("contseq= " + dgdCont.SelectedItem.Cells[0].Text.Trim() + "<br>");
				strbuf="ContFm_show.aspx?custno=" + Context.Request.QueryString["custno"] + "&old_contno=" + dgdCont.SelectedItem.Cells[0].Text.Trim();
				//Response.Write("strbuf= " + strbuf);
				literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\",null,\"top=30,left=30,height=480,width=730,status=no,scrollbars=yes,toolbar=no,menubar=no,\");</script>";
			}
			
			// �Y���U�T�w�s�W���ʧ@, ����}�� ContFm_Add.aspx
			else if(e.CommandName=="OK")
			{
				//Response.Write(dgdCont.SelectedItem.Cells[0].Text.Trim());
				if(Context.Request.QueryString["function1"]=="new")
				{
					Response.Redirect("ContFm_Add.aspx?custno=" + Context.Request.QueryString["custno"] + "&old_contno=" + dgdCont.SelectedItem.Cells[0].Text.Trim());
					//if(Context.Request.QueryString["conttp"]=="01")
						//Response.Redirect("ContFm_Add.aspx?custno=" + Context.Request.QueryString["custno"] + "&old_contno=" + dgdCont.SelectedItem.Cells[0].Text.Trim());
					//else if(Context.Request.QueryString["conttp"]=="09")
						//Response.Redirect("ContFm_Add.aspx?custno=" + Context.Request.QueryString["custno"] + "&old_contno=" + dgdCont.SelectedItem.Cells[0].Text.Trim());
				}
				else if(Context.Request.QueryString["function1"]=="mod")
				{
					Response.Redirect("ContFm.aspx?custno=" + Context.Request.QueryString["custno"] + "&contno=" + dgdCont.SelectedItem.Cells[0].Text.Trim());
					//if(Context.Request.QueryString["type1"]=="01")
						//Response.Redirect("ContFm.aspx?custno=" + Context.Request.QueryString["custno"] + "&contno=" + dgdCont.SelectedItem.Cells[0].Text.Trim());
					//else if(Context.Request.QueryString["type1"]=="09")
						//Response.Redirect("ContFm.aspx?custno=" + Context.Request.QueryString["custno"] + "&contno=" + dgdCont.SelectedItem.Cells[0].Text.Trim());
				}
			}
		}
		

		/// <summary>
		/// �����ʧ@
		/// </summary>
		/// <param name="source"></param>
		/// <param name="e"></param>
		private void dgdCont_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdCont.CurrentPageIndex=e.NewPageIndex;

			//�ǥѫe�@�����ǨӪ��ܼƭȦr�� custno
			string custno=Context.Request.QueryString["custno"].Trim();
			//Response.Write("custno= "+ custno + "<BR>");

			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_cont");
			DataView dv1 = ds1.Tables["c2_cont"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� cust_mfrno and ��L rowfilter ����
			dv1.RowFilter="cont_syscd='c2' and cont_custno='" + custno + "'";

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			//���b�B�z: �Y�L��Ʈ�, �h�����~�T��
			//if (dv1.Count < 1)  ...
			// �Y�����, �h�b Server Web Control ��ܤ�


			// �Y�j�M���G�� "�䤣��" ���B�z
			if(dv1.Count==0)
			{
				this.lblMessage.Text="�S�����v�q��, �Ы��k����s =>";
				this.btnNew.Visible=true;
				this.lblCaption.Visible=false;
			}
			else
			{
				//this.lblMessage.Text=dv1.Count.ToString() + "�����v���";
				dgdCont.DataSource=dv1;
				dgdCont.DataBind();
			}
		}

		
		/// <summary>
		/// ���U "�s�W�ťզX����" ���s���ʧ@
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnNew_Click(object sender, System.EventArgs e)
		{
			// ��}�B�z
			Response.Redirect("ContFm_Add.aspx?custno=" + Context.Request.QueryString["custno"] + "&old_contno=0");
			//if(Context.Request.QueryString["conttp"]=="01")
				//Response.Redirect("ContFm_Add.aspx?custno=" + Context.Request.QueryString["custno"] + "&old_contno=0");
			//else if(Context.Request.QueryString["conttp"]=="09")
				//Response.Redirect("ContFm_Add.aspx?custno=" + Context.Request.QueryString["custno"] + "&old_contno=0");

		}

	}
}
