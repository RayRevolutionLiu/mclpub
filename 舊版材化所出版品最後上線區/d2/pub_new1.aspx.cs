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
	/// Summary description for pub_new1.
	/// </summary>
	public class pub_new1 : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.TextBox tbxMfrName;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Literal literal1;

		public pub_new1()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;

			if (!Page.IsPostBack)
			{
				Response.Expires=0;

				// �M���T����r
				literal1.Text = "";

				// ����M����J�d�ߤ�����r, �_�h�L�k�X�{���T���G
				//tbxCompanyName.Text="";
				//tbxMfrNo.Text="";
				//tbxCustNo.Text="";
				//tbxCustName.Text="";
			}
		}


		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		// �d�߫��s: �I�s Function: ShowPub()
		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			ShowPub();
		}

		private void ShowPub()
		{
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "c2_pub");
			DataView dv1 = ds1.Tables["c2_pub"].DefaultView;

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
			
			//�p�G���OB�ŷ~�ȤH���A�u��ݨ�ۤv���Ȥ���
			if(!Session["atype"].ToString().Equals("B"))
				rowfilterstr1=rowfilterstr1+" and cont_empno ='" + Session["empid"].ToString() + "'";

			dv1.RowFilter = rowfilterstr1;

			// �Y�j�M���G�� "�䤣��" ���B�z
			if (dv1.Count==0)
				lblMessage.Text="���G: �䤣��ŦX���󪺸��, �z�i�H 1.���]����  2.�s�W�t�өέq����";
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
				string EndDate = DataGrid1.Items[i].Cells[5].Text.ToString().Trim();
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
				DataGrid1.Items[i].Cells[4].Text = StartDate;
				DataGrid1.Items[i].Cells[5].Text = EndDate;

				// �«Ȥ���
				string OldCustNo = DataGrid1.Items[i].Cells[11].Text.ToString().Trim();
				//Response.Write("OldCustNo= " + OldCustNo + "<br>");
				if(OldCustNo=="")
					DataGrid1.Items[i].Cells[11].Text = "<font color=Gray>�L���</font>";
				else
					DataGrid1.Items[i].Cells[11].Text = DataGrid1.Items[i].Cells[11].Text;

				// �w�������O
				string strfgpubed = DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
				//Response.Write("strfgpubed= " + strfgpubed + "<br>");
				if(strfgpubed == "0")
				{
					DataGrid1.Items[i].Cells[12].Text = "�_";
				}
				else
				{
					DataGrid1.Items[i].Cells[12].Text = "<font color=red>�O</font>";
				}

			}

		}


		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
			//Response.Write(DataGrid1.SelectedItem.Cells[1].Text);

			if(e.CommandName=="OK")
			{
				DataSet ds = new DataSet();
				this.sqlDataAdapter1.Fill(ds, "cust");
				DataView dv = ds.Tables["cust"].DefaultView;

				dv.RowFilter="cont_contno='"+DataGrid1.SelectedItem.Cells[0].Text+"'";
				//Response.Write("dv.RowFilter= " + dv.RowFilter + "<br>");
				//Response.Write("DataGrid1.SelectedItem.Cells[0].Text= " + DataGrid1.SelectedItem.Cells[0].Text + "<br>");

				// ���U�T�w(�D�H)���B�z: ����}
				string ConttpText = DataGrid1.SelectedItem.Cells[1].Text.Trim();
				//Response.Write("ConttpText= " + ConttpText + "<br>");
				Response.Redirect("PubFm.aspx?contno=" + DataGrid1.SelectedItem.Cells[0].Text.Trim() + "&bkcd=" + DataGrid1.SelectedItem.Cells[2].Text.Trim() + "&fgnew=" + DataGrid1.SelectedItem.Cells[13].Text.Trim());
			}
		}


		// �����B�z
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			ShowPub();
		}



		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
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
																																																				 new System.Data.Common.DataColumnMapping("cont_fgcancel", "cont_fgcancel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgtemp", "cont_fgtemp")})});
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c2_cont.cont_contid, dbo.c2_cont.cont_syscd, dbo.c2_cont.cont_contno, dbo.c2_cont.cont_conttp, dbo.c2_cont.cont_bkcd, dbo.c2_cont.cont_signdate, dbo.c2_cont.cont_empno, dbo.c2_cont.cont_mfrno, dbo.c2_cont.cont_aunm, dbo.c2_cont.cont_autel, dbo.c2_cont.cont_sdate, dbo.c2_cont.cont_edate, dbo.c2_cont.cont_custno, dbo.mfr.mfr_mfrid, dbo.mfr.mfr_mfrno, dbo.mfr.mfr_inm, dbo.mfr.mfr_respnm, dbo.mfr.mfr_respjbti, dbo.mfr.mfr_tel, dbo.cust.cust_custid, dbo.cust.cust_custno, dbo.cust.cust_nm, dbo.cust.cust_jbti, dbo.cust.cust_tel, dbo.cust.cust_oldcustno, dbo.book.bk_nm, dbo.book.bk_bkcd, dbo.c2_cont.cont_fgclosed, dbo.c2_cont.cont_fgpubed, dbo.c2_cont.cont_fgcancel, dbo.c2_cont.cont_fgtemp FROM dbo.c2_cont INNER JOIN dbo.mfr ON dbo.c2_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.cust ON dbo.c2_cont.cont_custno = dbo.cust.cust_custno INNER JOIN dbo.book ON dbo.c2_cont.cont_bkcd = dbo.book.bk_bkcd WHERE (dbo.c2_cont.cont_fgclosed = '0') AND (dbo.c2_cont.cont_fgcancel = '0') AND (dbo.c2_cont.cont_fgtemp = '0')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



	}
}
