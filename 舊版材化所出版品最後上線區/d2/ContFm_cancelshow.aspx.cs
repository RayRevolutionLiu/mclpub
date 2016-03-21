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
	/// Summary description for ContFm_cancelshow.
	/// </summary>
	public class ContFm_cancelshow : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox tbxMfrName;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.LinkButton lnbClear;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.Literal literal1;
	
		public ContFm_cancelshow()
		{
			System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
			Page.Init += new System.EventHandler(Page_Init);
		}
		
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;
			
			if(!Page.IsPostBack)
			{
				// �M���T����r
				literal1.Text = "";
				
			}
		}
		
		
		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		// ���U "�d��" ���s ���B�z
		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			ShowCont();
		}
		
		
		private void ShowCont()
		{
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_cont");
			DataView dv1 = ds1.Tables["c2_cont"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� cust_mfrno and ��L rowfilter ����
			string rowfilterstr1 = "mfr_mfrno Like '%"+tbxMfrNo.Text.Trim()+"%'";
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
			
			//���b�B�z: �Y�L��Ʈ�, �h�����~�T��
			if(tbxMfrName.Text!="")
				rowfilterstr1=rowfilterstr1+" and mfr_inm Like '%"+tbxMfrName.Text.Trim()+"%'";
	        	
			if(tbxCustNo.Text!="")
				rowfilterstr1=rowfilterstr1+" and cont_custno ='"+tbxCustNo.Text.Trim()+"'";
			
			if(tbxCustName.Text!="")
				rowfilterstr1=rowfilterstr1+" and cust_nm Like '%"+tbxCustName.Text.Trim()+"%'";
			
			if(tbxContNo.Text!="")
				rowfilterstr1=rowfilterstr1+" and cont_contno like '%"+tbxContNo.Text.Trim()+"%'";
			
			dv1.RowFilter = rowfilterstr1;
			
			// �Y�j�M���G�� "�䤣��" ���B�z
			if (dv1.Count==0)
				lblMessage.Text="���G: 0����� �� �䤣��ŦX���󪺸��, �z�i ���]����!";
				//lblMessage.Text="�d�ߵ��G: �䤣��ŦX���󪺸��, �Э��]����!  �νХ��s�W<A HREF='../d5/Mfr.aspx' Target='_new'>�t��</A> �� <A HREF='../d1/NewCust.aspx?mfrno=' Target='_new'>�Ȥ�</A>, �A�^�ӷj�M�÷s�W.";
			else
				lblMessage.Text="���G: ��� "+dv1.Count.ToString()+"�����";
			
			DataGrid1.DataSource=dv1;
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
					DataGrid1.Items[i].Cells[1].Text = "<font color=blue>���s�X��</font>";
				
				//���y���O
				//string bkcd = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
				
				// �X���_�� & �X������
				string StartDate = DataGrid1.Items[i].Cells[4].Text.ToString().Trim();
				//DataGrid1.Items[i].Cells[4].Text = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
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
				DataGrid1.Items[i].Cells[4].Text = StartDate;
				
				string EndDate = DataGrid1.Items[i].Cells[5].Text.ToString().Trim();
				//DataGrid1.Items[i].Cells[5].Text = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
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
				DataGrid1.Items[i].Cells[5].Text = EndDate;
				
				// �«Ȥ���
				string OldCustNo = DataGrid1.Items[i].Cells[11].Text.ToString().Trim();
				//Response.Write("OldCustNo= " + OldCustNo + "<br>");
				if(OldCustNo=="")
					DataGrid1.Items[i].Cells[11].Text = "<font color=Gray>�L���</font>";
				else
					DataGrid1.Items[i].Cells[11].Text = DataGrid1.Items[i].Cells[11].Text;
				
				// �w���׵��O
				string strfgclosed = DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
				//Response.Write("strfgclosed= " + strfgclosed + "<br>");
				if(strfgclosed == "0")
				{
					DataGrid1.Items[i].Cells[12].Text = "�_";
				}
				else
				{
					DataGrid1.Items[i].Cells[12].Text = "<font color=red>�O</font>";
				}
				
				// �w�������O
				string strfgpubed = DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
				//Response.Write("strfgpubed= " + strfgpubed + "<br>");
				if(strfgpubed == "0")
				{
					DataGrid1.Items[i].Cells[13].Text = "�_";
				}
				else
				{
					DataGrid1.Items[i].Cells[13].Text = "<font color=red>�O</font>";
				}
				
			}
			
		}
		
		
		// ���U "��ܦX����" �����s�B�z
		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
			//Response.Write(DataGrid1.SelectedItem.Cells[1].Text);
			
			if(e.CommandName=="OK")
			{
				// �}�Ҥp����
				string strbuf = "ContPubFm_show.aspx?custno=" + DataGrid1.SelectedItem.Cells[8].Text.Trim() + "&old_contno=" + DataGrid1.SelectedItem.Cells[0].Text.Trim();
				//Response.Write(strbuf);
				this.literal1.Text="<script language=\"javascript\">window.open(\"" + strbuf + "\", '', 'width=720, height=450, left=20, top=20, scrollbars=yes');</script>";
			}
		}
		
		
		// �����B�z
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			ShowCont();
		}
		
		
		// �M�����d �����s
		private void lnbClear_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("ContFm_cancelshow.aspx");
		}
		
		
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.lnbClear.Click += new System.EventHandler(this.lnbClear_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
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
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																				 new System.Data.Common.DataColumnMapping("mfr_tel", "mfr_tel"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("cust_oldcustno", "cust_oldcustno"),
																																																				 new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				 new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpubed", "cont_fgpubed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT c2_cont.cont_contid, c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_conttp, c2_cont.cont_bkcd, c2_cont.cont_signdate, c2_cont.cont_empno, c2_cont.cont_mfrno, c2_cont.cont_aunm, c2_cont.cont_autel, c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_custno, mfr.mfr_mfrid, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_respnm, mfr.mfr_respjbti, mfr.mfr_tel, cust.cust_custid, cust.cust_custno, cust.cust_nm, cust.cust_jbti, cust.cust_tel, cust.cust_oldcustno, book.bk_nm, book.bk_bkcd, c2_cont.cont_fgclosed, c2_cont.cont_fgpubed, c2_cont.cont_fgcancel FROM c2_cont INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN cust ON c2_cont.cont_custno = cust.cust_custno INNER JOIN book ON c2_cont.cont_bkcd = book.bk_bkcd WHERE (c2_cont.cont_fgcancel <> '0')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
//				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
		
	}
}
