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

namespace MRLPub.d4
{
	/// <summary>
	/// Summary description for QueryHisCont.
	/// </summary>
	public class QueryHisCont : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.Literal literal1;
		protected System.Web.UI.WebControls.Label lblRemark;
		protected System.Web.UI.WebControls.DataGrid dgdCont;
		protected System.Web.UI.WebControls.Label lblCaption;
		protected System.Web.UI.WebControls.Button btnNew;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPub;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
	
		public QueryHisCont()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				//BindGrid();
				InitData();
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
			System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;

			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCnnMRLPub = new System.Data.SqlClient.SqlConnection();
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			this.dgdCont.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdCont_ItemCommand);
			this.dgdCont.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdCont_PageIndexChanged);
			this.dgdCont.SelectedIndexChanged += new System.EventHandler(this.dgdCont_SelectedIndexChanged);
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c4_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_contid", "cont_contid"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubcate", "cont_pubcate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aufax", "cont_aufax"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aucell", "cont_aucell"),
																																																				 new System.Data.Common.DataColumnMapping("cont_auemail", "cont_auemail"),
																																																				 new System.Data.Common.DataColumnMapping("cont_disc", "cont_disc"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freetm", "cont_freetm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubtm", "cont_pubtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_resttm", "cont_resttm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_ccont", "cont_ccont"),
																																																				 new System.Data.Common.DataColumnMapping("cont_csdate", "cont_csdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_atp", "cont_atp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_matp", "cont_matp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_adremark", "cont_adremark"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pdcont", "cont_pdcont"),
																																																				 new System.Data.Common.DataColumnMapping("cont_moddate", "cont_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_modempno", "cont_modempno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_credate", "cont_credate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totimgtm", "cont_totimgtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_toturltm", "cont_toturltm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c4_cont.cont_contid, dbo.c4_cont.cont_syscd, dbo.c4_cont.cont_contno, dbo.c4_cont.cont_custno, dbo.c4_cont.cont_conttp, dbo.c4_cont.cont_signdate, dbo.c4_cont.cont_sdate, dbo.c4_cont.cont_edate, dbo.c4_cont.cont_empno, dbo.c4_cont.cont_mfrno, dbo.c4_cont.cont_pubcate, dbo.c4_cont.cont_aunm, dbo.c4_cont.cont_autel, dbo.c4_cont.cont_aufax, dbo.c4_cont.cont_aucell, dbo.c4_cont.cont_auemail, dbo.c4_cont.cont_disc, dbo.c4_cont.cont_freetm, dbo.c4_cont.cont_pubtm, dbo.c4_cont.cont_resttm, dbo.c4_cont.cont_totamt, dbo.c4_cont.cont_paidamt, dbo.c4_cont.cont_restamt, dbo.c4_cont.cont_ccont, dbo.c4_cont.cont_csdate, dbo.c4_cont.cont_atp, dbo.c4_cont.cont_matp, dbo.c4_cont.cont_fgclosed, dbo.c4_cont.cont_adremark, dbo.c4_cont.cont_pdcont, dbo.c4_cont.cont_moddate, dbo.mfr.mfr_inm, dbo.mfr.mfr_mfrno, dbo.c4_cont.cont_fgpayonce, dbo.c4_cont.cont_fgtemp, dbo.c4_cont.cont_fgpubed, dbo.c4_cont.cont_modempno, dbo.c4_cont.cont_credate, dbo.c4_cont.cont_totimgtm, dbo.c4_cont.cont_toturltm, dbo.c4_cont.cont_fgcancel FROM dbo.c4_cont INNER JOIN dbo.mfr ON dbo.c4_cont.cont_mfrno = dbo.mfr.mfr_mfrno WHERE (dbo.c4_cont.cont_fgtemp='0') AND (dbo.c4_cont.cont_fgcancel='0')";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPub;
			// 
			// sqlCnnMRLPub
			// 
			this.sqlCnnMRLPub.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void InitData()
		{
			//�ǥѫe�@�����ǨӪ��ܼƭȦr�� custno
			string custno=Request.QueryString["custno"].Trim();
			//Response.Write("custno= "+ custno + "<BR>");
			string conttp=Request.QueryString["conttp"].Trim();

			LoadHistoryCont(custno, conttp);

		}

		private void LoadHistoryCont(string custno, string conttp)
		{
//SELECT c4_cont.cont_contid, c4_cont.cont_syscd, c4_cont.cont_contno, c4_cont.cont_custno, 42_cont.cont_conttp, c4_cont.cont_bkcd, c4_cont.cont_signdate, c4_cont.cont_mfrno, c4_cont.cont_aunm, c4_cont.cont_autel, c4_cont.cont_fgclosed, c4_cont.cont_fgpayonce, book.bk_nm, book.bk_bkcd, mfr.mfr_inm, c4_cont.cont_disc, mfr.mfr_mfrno, c4_cont.cont_clrtm, c4_cont.cont_menotm, c4_cont.cont_getclrtm FROM c4_cont INNER JOIN book ON c4_cont.cont_bkcd = book.bk_bkcd INNER JOIN mfr ON c4_cont.cont_mfrno = mfr.mfr_mfrno ORDER BY c4_cont.cont_contno DESC

			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c4_cont");
			DataView dv1 = ds1.Tables["c4_cont"].DefaultView;
			dv1.RowFilter="cont_syscd='c4' and cont_custno='" + custno + "'" + " and cont_conttp='" + conttp +"'";
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
					// ���U���
					string RegDate = dgdCont.Items[i].Cells[1].Text.ToString().Trim();
					dgdCont.Items[i].Cells[1].Text = DateTime.ParseExact(RegDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");//RegDate.Substring(0, 4) + "/" + RegDate.Substring(4, 2) + "/" + RegDate.Substring(6, 2);
						
					// �@���I�M���O
					string strfgpayonce = dgdCont.Items[i].Cells[6].Text.ToString().Trim();
					//Response.Write("strfgpayonce= " + strfgpayonce + "<br>");
					if(strfgpayonce == "0")
					{
						dgdCont.Items[i].Cells[6].Text = "�_";
					}
					else
					{
						dgdCont.Items[i].Cells[6].Text = "<font color=red>�O</font>";
					}
					
					// ���׵��O
					string strfgclosed = dgdCont.Items[i].Cells[7].Text.ToString().Trim();
					//Response.Write("strfgclosed= " + strfgclosed + "<br>");
					if(strfgclosed == "0")
					{
						dgdCont.Items[i].Cells[7].Text = "�_";
					}
					else
					{
						dgdCont.Items[i].Cells[7].Text = "<font color=red>�O</font>";
					}
						
					// �X�����O
					string strconttp = dgdCont.Items[i].Cells[8].Text.ToString().Trim();
					//Response.Write("strconttp= " + strconttp + "<br>");
					if(strconttp == "01")
					{
						dgdCont.Items[i].Cells[8].Text = "�@��";
					}
					else
					{
						dgdCont.Items[i].Cells[8].Text = "<font color=red>���s</font>";
					}
						
					
					// ���O�� for loop ����
				}
					
			}

			// �̥ثe�n�D���ʧ@(�s�W/�ק�) ����ܤ��P�T��
			if(Context.Request.QueryString["function1"]=="new")
				this.lblCaption.Text="<br>��: ��� [��ܸ��] �i�˵��X���Ѫ���l���, �� [�T�w�s�W] �Y�N�i�J�s�W�e��";
			else if(Context.Request.QueryString["function1"]=="mod")
				this.lblCaption.Text="<br>��: ��� [��ܸ��] �i�˵��X���Ѫ���l���, �� [�T�w�ק�] �Y�N�i�J�ק�e��";		
		}

		private void BindGrid()
		{
//			DataView qdv = (DataView)Session["QDV"];
//			int i = Int32.Parse(Request.QueryString["SelectedCust"]);
//
//			DataSet ds = new DataSet();
//			this.sqlDataAdapter1.Fill(ds, "HisCont");
//			DataView dv = ds.Tables["HisCont"].DefaultView;
//			dv.RowFilter = "cont_custno = '" + qdv[i]["cust_custno"].ToString() + "'";
//
//			if (dv.Count>0)
//			{
//				DataGrid1.DataSource = dv;
//				DataGrid1.DataBind();
//				Session.Add("HCDV", dv);
//			}
//			else
//			{
//				this.btnAddNew.Text = "�d�L���v�X���A�����~��s�W�X��";
//				DataGrid1.Visible = false;
//			}
		}

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
				strbuf="ShowOldCont.aspx?custno=" + Request.QueryString["custno"] + "&old_contno=" + dgdCont.SelectedItem.Cells[0].Text.Trim() + "&conttp="+Request.QueryString["conttp"];
				//Response.Write("strbuf= " + strbuf);
				literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\",null,\"top=30,left=30,height=480,width=730,status=no,scrollbars=yes,resizable=yes,toolbar=no,menubar=no,\");</script>";
			}
			
				// �Y���U�T�w�s�W���ʧ@, ����}�� ContFm_Add.aspx
//			else if(e.CommandName=="OK")
//			{
//				//Response.Write(dgdCont.SelectedItem.Cells[0].Text.Trim());
//				if(Request.QueryString["function1"]=="new")
//				{
//					if(Request.QueryString["conttp"]=="01")
//						Response.Redirect("NewCont.aspx?custno=" + Request.QueryString["custno"] + "&old_contno=" + dgdCont.SelectedItem.Cells[0].Text.Trim()+"&conttp="+Request.QueryString["conttp"]);
//					else if(Request.QueryString["conttp"]=="09")
//						Response.Redirect("NewCont.aspx?custno=" + Request.QueryString["custno"] + "&old_contno=" + dgdCont.SelectedItem.Cells[0].Text.Trim()+"&conttp="+Request.QueryString["conttp"]);
//				}
//				else if(Request.QueryString["function1"]=="mod")
//				{
//					if(Request.QueryString["type1"]=="01")
//						Response.Redirect("cont_main3.aspx?custno=" + Context.Request.QueryString["custno"] + "&conttp=" + Context.Request.QueryString["conttp"] + "&old_contno=" + dgdCont.SelectedItem.Cells[0].Text.Trim());
//					else if(Request.QueryString["type1"]=="09")
//						Response.Redirect("cont_main3.aspx?custno=" + Context.Request.QueryString["custno"] + "&conttp=" + Context.Request.QueryString["conttp"] + "&old_contno=" + dgdCont.SelectedItem.Cells[0].Text.Trim());
//				}
//			}
		}

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("NewCont.aspx?custno=" + Context.Request.QueryString["custno"] + "&old_contno=0");
		}

		private void dgdCont_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdCont.CurrentPageIndex=e.NewPageIndex;

			//�ǥѫe�@�����ǨӪ��ܼƭȦr�� custno
			string custno=Context.Request.QueryString["custno"].Trim();
			//Response.Write("custno= "+ custno + "<BR>");

			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c4_cont");
			DataView dv1 = ds1.Tables["c4_cont"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� cust_mfrno and ��L rowfilter ����
			dv1.RowFilter="cont_syscd='C4' and cont_custno='" + custno + "'";

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			//���b�B�z: �Y�L��Ʈ�, �h�����~�T��
			//if (dv1.Count < 1)  ...
			// �Y�����, �h�b Server Web Control ��ܤ�


			// �Y�j�M���G�� "�䤣��" ���B�z
			if(dv1.Count==0)
			{
				this.lblMessage.Text="�S�����v�q��";
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

		private void dgdCont_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string CustNo = Request.QueryString["custno"].Trim();
			string OldContNo = dgdCont.SelectedItem.Cells[0].Text.Trim();
			string ContTp = Request.QueryString["conttp"].Trim();

			Response.Redirect("NewCont.aspx?custno=" + CustNo  + "&old_contno=" + OldContNo +"&conttp=" + ContTp);
		}
	}
}
