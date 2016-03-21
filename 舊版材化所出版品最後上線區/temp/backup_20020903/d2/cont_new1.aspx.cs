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

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for cont_new1.
	/// </summary>
	public class cont_new1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.TextBox tbxCompanyName;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.LinkButton lnbNewMfr;
		protected System.Web.UI.WebControls.LinkButton lnbNewCust;
		protected System.Web.UI.WebControls.Label lblContTypeCode;
		protected System.Web.UI.WebControls.Label lblExplain;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Literal literal1;
	
		public cont_new1()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			// ��X�X�����O�N�X (�ѳs���ܼ�), ����ܨ��r
			if(Context.Request.QueryString["conttp"]=="01")
				this.lblContTypeCode.Text = "(�@��X����)";
			else if(Context.Request.QueryString["conttp"]=="09")
				this.lblContTypeCode.Text = "(���s�X����)";
				

			// �M�����
			literal1.Text="";

			// ������M����J�d�ߤ�����r, �_�h�L�k�X�{���T���G
			//tbxCompanyName.Text="";
			//tbxMfrNo.Text="";
			//tbxCustNo.Text="";
			//tbxCustName.Text="";
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
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.lnbNewMfr.Click += new System.EventHandler(this.lnbNewMfr_Click);
			this.lnbNewCust.Click += new System.EventHandler(this.lnbNewCust_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "application name=mrlpub;data source=isccom1;initial catalog=mrlpub;password=moc18" +
				"47csi;persist security info=True;user id=sa;workstation id=03212-890711;packet s" +
				"ize=4096";
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT mfr.mfr_mfrid, mfr.mfr_mfrno, mfr.mfr_inm, cust.cust_custid, cust.cust_custno, cust.cust_nm, cust.cust_jbti, cust.cust_mfrno, cust.cust_tel, cust.cust_fax, cust.cust_cell, cust.cust_regdate, cust.cust_moddate, cust.cust_itpcd, cust.cust_btpcd, cust.cust_rtpcd, cust.cust_email, cust.cust_oldcustno, cust.cust_orgisyscd FROM cust INNER JOIN mfr ON cust.cust_mfrno = mfr.mfr_mfrno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "cust", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			  new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																			  new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																			  new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																			  new System.Data.Common.DataColumnMapping("cust_mfrno", "cust_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																			  new System.Data.Common.DataColumnMapping("cust_fax", "cust_fax"),
																																																			  new System.Data.Common.DataColumnMapping("cust_cell", "cust_cell"),
																																																			  new System.Data.Common.DataColumnMapping("cust_regdate", "cust_regdate"),
																																																			  new System.Data.Common.DataColumnMapping("cust_moddate", "cust_moddate"),
																																																			  new System.Data.Common.DataColumnMapping("cust_itpcd", "cust_itpcd"),
																																																			  new System.Data.Common.DataColumnMapping("cust_btpcd", "cust_btpcd"),
																																																			  new System.Data.Common.DataColumnMapping("cust_rtpcd", "cust_rtpcd"),
																																																			  new System.Data.Common.DataColumnMapping("cust_email", "cust_email"),
																																																			  new System.Data.Common.DataColumnMapping("cust_oldcustno", "cust_oldcustno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_orgisyscd", "cust_orgisyscd")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		

		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			// �d�߫��s: �I�s Function: ShowCust() 
			ShowCust();
		}
		
		
		/// <summary>
		/// ��ܫȤ���
		/// </summary>
		private void ShowCust()
		{
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "cust");
			DataView dv = ds.Tables["cust"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� cust_mfrno and ��L rowfilter ����
			string rowfilterstr = "1=1";

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv.Count= "+ dv.Count + "<BR>");
			//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");

			//���b�B�z: �Y�L��Ʈ�, �h�����~�T��
			//if (dv1.Count < 1)  ...
			// �Y�����, �h�b Server Web Control ��ܤ�

			if(tbxCompanyName.Text!="")
				rowfilterstr=rowfilterstr+" and mfr_inm Like '%"+tbxCompanyName.Text.Trim()+"%'";

			if(tbxMfrNo.Text!="")
				rowfilterstr=rowfilterstr+" and cust_mfrno Like '%"+tbxMfrNo.Text.Trim()+"%'";

			if(tbxCustNo.Text!="")
				rowfilterstr=rowfilterstr+" and cust_custno ='"+tbxCustNo.Text.Trim()+"'";

			if(tbxCustName.Text!="")
				rowfilterstr=rowfilterstr+" and cust_nm Like '%"+tbxCustName.Text.Trim()+"%'";
			
			dv.RowFilter = rowfilterstr;

			// �Y�j�M���G�� "�䤣��" ���B�z
			if (dv.Count==0)
				lblMessage.Text="�d�ߵ��G: �䤣��ŦX���󪺸��, �z�i�H 1.���]����  2.�s�W�t�өέq����";
			else
				lblMessage.Text="�d�ߵ��G: ��� "+dv.Count.ToString()+"���Ȥ���";
			
			DataGrid1.DataSource=dv;
			DataGrid1.DataBind();
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv.Count= "+ dv.Count + "<BR>");
			//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");
			
			// �S�O��줧��X�榡�ഫ - �ܧ�ñ��������榡
			int i;
			for(i=0; i< DataGrid1.Items.Count ; i++)
			{
				// ���U���
				string RegDate = DataGrid1.Items[i].Cells[8].Text.ToString().Trim();
				DataGrid1.Items[i].Cells[8].Text = RegDate.Substring(0, 4) + "/" + RegDate.Substring(4, 2) + "/" + RegDate.Substring(6, 2);

				// �«Ȥ���
				string OldCustNo = DataGrid1.Items[i].Cells[9].Text.ToString().Trim();
				if(OldCustNo=="")
					DataGrid1.Items[i].Cells[9].Text = "<font color=Gray>�L���</font>";
				else
					DataGrid1.Items[i].Cells[9].Text = DataGrid1.Items[i].Cells[9].Text;
				
			}
			
		}
		

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
			//Response.Write(DataGrid1.SelectedItem.Cells[4].Text);

			if(e.CommandName=="Modify")
			{
				// �ק�Ȥ��ƪ��B�z: ����}
				//Response.Write("ID= " + DataGrid1.SelectedItem.Cells[1].Text);
				Response.Redirect("../d5/cust_edit.aspx?ID=" + DataGrid1.SelectedItem.Cells[1].Text);
			}
			else if(e.CommandName=="OK")
			{
				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
				DataSet ds = new DataSet();
				this.sqlDataAdapter1.Fill(ds, "cust");
				DataView dv = ds.Tables["cust"].DefaultView;

				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
				// �] Row Filter: default �� cust_mfrno and ��L rowfilter ����
				dv.RowFilter = "cust_custno='" + DataGrid1.SelectedItem.Cells[4].Text + "'";

				// �ˬd�ÿ�X �̫� Row Filter �����G
				//Response.Write("dv.Count= "+ dv.Count + "<BR>");
				//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");

				//���b�B�z: �Y�L��Ʈ�, �h�����~�T��
				//if (dv1.Count < 1)  ...
				// �Y�����, �h�b Server Web Control ��ܤ�


				//// ���U�T�w(�D�H)���B�z: ����}
				if(Context.Request.QueryString["conttp"]=="01")
					Response.Redirect("cont_new2.aspx?function1=new&custno="+DataGrid1.SelectedItem.Cells[4].Text.Trim() + "&conttp=01");
				else if(Context.Request.QueryString["conttp"]=="09")
					Response.Redirect("cont_new2.aspx?function1=new&custno="+DataGrid1.SelectedItem.Cells[4].Text.Trim() + "&conttp=09");

			}
		}
		

		private void lnbNewMfr_Click(object sender, System.EventArgs e)
		{
			// ��}�B�z
			Response.Redirect("../d5/mfr_addnew.aspx");
		}
		

		private void lnbNewCust_Click(object sender, System.EventArgs e)
		{
			// ��}�B�z
			Response.Redirect("../d5/cust_add.aspx");
		}
		

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			ShowCust();
		}

	}
}
