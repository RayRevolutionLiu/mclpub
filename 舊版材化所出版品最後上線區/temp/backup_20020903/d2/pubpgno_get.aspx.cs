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
	/// Summary description for pubpgno_get.
	/// </summary>
	public class pubpgno_get : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblGetPageNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenPageNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenBookPNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenMfrNo;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		public pubpgno_get()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				BindGrid();
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("pub_yyyymm", "pub_yyyymm"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_pno", "pub_pno"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgno", "pub_pgno"),
																																																				new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT c2_pub.pub_syscd, c2_pub.pub_contno, c2_pub.pub_yyyymm, c2_pub.pub_pubseq, c2_pub.pub_pno, c2_pub.pub_pgno, c2_cont.cont_mfrno, c2_cont.cont_custno, c2_cont.cont_contno, c2_cont.cont_syscd FROM c2_pub LEFT OUTER JOIN c2_cont ON c2_pub.pub_syscd = c2_cont.cont_syscd AND c2_pub.pub_contno = c2_cont.cont_contno WHERE (c2_pub.pub_syscd = 'C2') AND (c2_pub.pub_pgno <> '0')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
		public void BindGrid()
		{
			// Put user code to initialize the page here
			// ��X��몺�Z�n�~�� Currentyyyymm, (�Y�O, �åH�������)
			string ThisYear = System.DateTime.Today.Year.ToString().Trim();
			string ThisMonth = System.DateTime.Today.Month.ToString().Trim();
			if(ThisMonth.Length==1)
				ThisMonth = "0" + ThisMonth;
			string Currentyyyymm = ThisYear + ThisMonth;
			//Response.Write("Currentyyyymm= " + Currentyyyymm + "<br>");
			
			
			// ��X �t�ӽs�� & �½Z���O/��Z���O, �ӰѦҦC�X�Ӽt�Ӵ��Z�n(�üg�^)���������
			// ������J �½Z���O / ��Z���O ��, �۰ʰʥX �½Z���X / ��Z���X �d�ߵ��G
			string MfrNo;
			if(Context.Request.QueryString["mfrno"].Trim()=="")
				MfrNo = "<font color='gray'>(�L���)</font>";
			else
				MfrNo = Context.Request.QueryString["mfrno"].Trim();
			hiddenMfrNo.Value = MfrNo;
			//Response.Write("MfrNo= " + MfrNo + "<br>");
			
			string bkpno;
			if(Context.Request.QueryString["bkpno"].Trim()=="")
				bkpno = "";
			else
				bkpno = Context.Request.QueryString["bkpno"].Trim();
			hiddenBookPNo.Value = bkpno;
			//Response.Write("bkpno= " + bkpno + "<br>");
			
			
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "c2_pub");
			DataView dv = ds.Tables["c2_pub"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� cust_mfrno and ��L rowfilter ����
			string rowfilterstr = "1=1";
			this.lblMessage.Text = "�d�߱���G";
			this.lblGetPageNo.Text = "";
			if(MfrNo!="")  
			{
				this.lblMessage.Text = this.lblMessage.Text + "�t�Ӳνs=" + MfrNo;
				rowfilterstr = rowfilterstr + " AND (cont_mfrno = '" + MfrNo + "') ";
			}
			else
				rowfilterstr = rowfilterstr;

			if(bkpno!="")  
			{
				this.lblMessage.Text = this.lblMessage.Text + ", �Z�n���O=" + bkpno;
				rowfilterstr = rowfilterstr + " AND (pub_pno = '" + bkpno + "') ";
			}
			else
				rowfilterstr = rowfilterstr;

			dv.RowFilter = rowfilterstr;
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv.Count= "+ dv.Count + "<BR>");
			//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");
			this.hiddenBookPNo.Value = "";

			
			// �ˬd�O�_���j�M���G
			if(dv.Count<1)
			{
				this.lblMessage.Text = "�d�L���, �Э��s��J�d��!<br>";
				this.lblGetPageNo.Text = "";
				
				// �Y�L DB ���, ���X�w�]�Ȭ� 0, �H�y��a�^�� hidden �ȸ�
				this.hiddenBookPNo.Value = bkpno;
				this.hiddenPageNo.Value = "0";
				//Response.Write("hiddenBookPNo= " + this.hiddenBookPNo.Value + "<br>");
				//Response.Write("hiddenPageNo= " + this.hiddenPageNo.Value + "<br>");
			}
			else
			{				
				DataGrid1.DataSource=dv;
				DataGrid1.DataBind();
				
				
				// �N DB �Ĥ@�����, �g�J hidden �ȸ�
				// ���g�b���B, �O�] �~���קK�a�^�H�U�t <font...> ����!
				this.hiddenBookPNo.Value = DataGrid1.Items[0].Cells[5].Text;
				this.hiddenPageNo.Value = DataGrid1.Items[0].Cells[6].Text;
				//Response.Write("hiddenBookPNo= " + this.hiddenBookPNo.Value + "<br>");
				//Response.Write("hiddenPageNo= " + this.hiddenPageNo.Value + "<br>");
				
				
				//�ܧ�Z�n�~�몺�榡, �O�����, �åB�H�������
				int j;
				for(j=0; j< DataGrid1.Items.Count ; j++)
				{
					// ��X �Z�n�~��, Reformat
					string yyyymm = DataGrid1.Items[j].Cells[3].Text.ToString().Trim();
					DataGrid1.Items[j].Cells[3].Text = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
					//Response.Write("yyyymm= " + yyyymm + "<br>");
					
					// �N�Ĥ@���� '���y���O' & '�Z�n���X' ����ܬ�����r��
					DataGrid1.Items[0].Cells[5].Text = "<font color=red>" + DataGrid1.Items[0].Cells[5].Text + "</font>";
					DataGrid1.Items[0].Cells[6].Text = "<font color=red>" + DataGrid1.Items[0].Cells[6].Text + "</font>";
				}
				
				// ���w lblMessage ���w�]�T�����
				this.lblMessage.Text = this.lblMessage.Text;
				this.lblGetPageNo.Text = "=> �Z�n���X = " + DataGrid1.Items[0].Cells[6].Text;
			}

		}
		

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
		}
		

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex=e.NewPageIndex;
			
			// �M���w�蠟 ItemStyle ���]�w(�C��...)
			//DataGrid1.SelectedItemStyle.Reset();
		}
		
		
	}
}
