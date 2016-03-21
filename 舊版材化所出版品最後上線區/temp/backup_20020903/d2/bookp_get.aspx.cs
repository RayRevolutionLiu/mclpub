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
	/// Summary description for bookp_get.
	/// </summary>
	public class bookp_get : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblYYYYMM;
		protected System.Web.UI.WebControls.Label lblGetBookPNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenBookPNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenYYYYMM;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
	
		public bookp_get()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
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
																									  new System.Data.Common.DataTableMapping("Table", "bookp", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																			   new System.Data.Common.DataColumnMapping("bkp_date", "bkp_date"),
																																																			   new System.Data.Common.DataColumnMapping("bkp_pno", "bkp_pno"),
																																																			   new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			   new System.Data.Common.DataColumnMapping("bkp_bkcd", "bkp_bkcd")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT book.bk_nm, bookp.bkp_date, RTRIM(bookp.bkp_pno) AS bkp_pno, book.bk_bkcd," +
				" bookp.bkp_bkcd FROM bookp INNER JOIN book ON bookp.bkp_bkcd = book.bk_bkcd";
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
			
			// ��X ���y���O�N�X
			string BookCode;
			if(Context.Request.QueryString["bkcd"].Trim()=="")
				BookCode = "01";
			else
				BookCode = Context.Request.QueryString["bkcd"].Trim();
			//Response.Write("BookCode= " + BookCode + "<br>");
			//Response.Write("ThisYear+2= " + (int.Parse(ThisYear)+2) + "<br>");
			
			// �Ѻ����ܼƧ�X�Ҷ񤧥Z�n�~��, �n�ϸӵ��C�⬰��
			string ym;
			if(Context.Request.QueryString["ym"].Trim()=="")
				ym = Currentyyyymm;
			else
				ym = Context.Request.QueryString["ym"].Trim();
			hiddenYYYYMM.Value= ym;
			//Response.Write("ym= " + ym + "<br>");
			// ��X ym ���~�׽X 4�X, �n��J sql RowFilter
			string Gotyyyy = "";
			Gotyyyy = ym.Substring(0, 4).Trim();
			
			// ���w lblGetBookPNo ���w�]�T�����
			string Searchym = ym.Substring(0, 4).ToString() + "/" + ym.Substring(4, 2).ToString();
			this.lblMessage.Text = "�d�ߤ��Z�n�~��= " + Searchym.Trim();
			this.lblGetBookPNo.Text = "";
			
			
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "bookp");
			DataView dv = ds.Tables["bookp"].DefaultView;
			
			// **�`�N: �쥻��Ʈw���� bkp_pno  �O char(x) ���A, �G�� sqlDataAdapter4 ��, �n���� RTRIM ���B�z (�p RTRIM(dbo.bookp.bkp_pno) AS bkp_pno), �_�h��ȷ|�t���ť�, �p '184 ' .
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� cust_mfrno and ��L rowfilter ����
			string rowfilterstr = "1=1";
			rowfilterstr = rowfilterstr + "AND bkp_date LIKE '" + Gotyyyy + "%'";
			rowfilterstr = rowfilterstr + "AND bk_bkcd = " + BookCode;
			dv.RowFilter = rowfilterstr;
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv.Count= "+ dv.Count + "<BR>");
			//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");
			
			
			DataGrid1.DataSource=dv;
			DataGrid1.DataBind();
			
			// �ܧ�Z�n�~�몺�榡, �O�����, �åB�H�������
			int i;
			for(i=0; i< DataGrid1.Items.Count ; i++)
			{
				// ��X �Z�n�~��, Reformat
				string yyyymm = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();
				DataGrid1.Items[i].Cells[1].Text = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
				
				// �Y�������, �Z�n�~��ή��y���O��ܬ�����r��
				if(yyyymm==Currentyyyymm)  {
					// ���w�� '���y���O' �w�]�� hiddenBookPNo (�� [�����] ���۹��� [���y���O] ��.)
					hiddenBookPNo.Value = DataGrid1.Items[i].Cells[2].Text;
					//Response.Write("hiddenBookPNo.Value= " + hiddenBookPNo.Value + "<br>");
					this.lblGetBookPNo.Text = "; ���y���O= " + hiddenBookPNo.Value;
					
					DataGrid1.Items[i].Cells[1].Text = "<font color=Red>" + DataGrid1.Items[i].Cells[1].Text + "</font>";
					DataGrid1.Items[i].Cells[2].Text = "<font color=Red>" + DataGrid1.Items[i].Cells[2].Text + "</font>";
				}
				
							
				// �Y���Ҷ�J���~����, �h�Ҷ�J�� '�Z�n�~��ή��y���O' ����ܬ��Ŧ�r��
				string DByyyymm = DataGrid1.Items[i].Cells[1].Text;
				DByyyymm = DByyyymm.Substring(0, 4).ToString() + DByyyymm.Substring(5, 2).ToString();
				//Response.Write("DByyyymm= " + DByyyymm + "<br>");
				if(DByyyymm==ym)  
				{
					// ���w�� '���y���O' �w�]�� hiddenBookPNo (�� [�Ҷ�J�~��] ���۹��� [���y���O] ��.)
					hiddenBookPNo.Value = DataGrid1.Items[i].Cells[2].Text;
					//Response.Write("hiddenBookPNo.Value= " + hiddenBookPNo.Value + "<br>");
					this.lblGetBookPNo.Text = "; ���y���O= " + hiddenBookPNo.Value;
					
					DataGrid1.Items[i].Cells[1].Text = "<font color=Blue>" + DataGrid1.Items[i].Cells[1].Text + "</font>";
					DataGrid1.Items[i].Cells[2].Text = "<font color=Blue>" + DataGrid1.Items[i].Cells[2].Text + "</font>";
				}
				
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
		
		
		// ���\�ର�쥻���� �j�M���P�~���Ϊ� coding
//		private void Query_Click(object sender, System.EventArgs e)
//		{
//			// ��X�s�j�M���� (�Z�n�~��)
//			string yyyyQuery = "";
//			if(this.tbxQString.Text.ToString().Trim() != "")
//			{
//				yyyyQuery = this.tbxQString.Text.ToString().Trim();
//
//				//------------------------------------------------------
//				//�����@�� BindGrid() ���ʧ@, �����s�� RowFilter ����
//				// ��X���y���O�N�X
//				string BookCode;
//				if(Context.Request.QueryString["bkcd"].Trim()=="")
//					BookCode = "01";
//				else
//					BookCode = Context.Request.QueryString["bkcd"].Trim();
//				//Response.Write("BookCode= " + BookCode + "<br>");
//				//Response.Write("ThisYear+2= " + (int.Parse(ThisYear)+2) + "<br>");
//			
//				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
//				DataSet ds = new DataSet();
//				this.sqlDataAdapter1.Fill(ds, "bookp");
//				DataView dv = ds.Tables["bookp"].DefaultView;
//
//				// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
//				// �] Row Filter: default �� cust_mfrno and ��L rowfilter ����
//				string rowfilterstr = "1=1";
//				rowfilterstr = rowfilterstr + "AND bkp_date LIKE '" + yyyyQuery + "%'";
//				//rowfilterstr = rowfilterstr + "AND bkp_date >= '" + ThisYear + "%'";
//				//rowfilterstr = rowfilterstr + "AND bkp_date <= '" + (int.Parse(ThisYear)+2) + "%'";
//				rowfilterstr = rowfilterstr + "AND bk_bkcd = " + BookCode;
//				dv.RowFilter = rowfilterstr;
//			
//				// �ˬd�ÿ�X �̫� Row Filter �����G
//				//Response.Write("dv.Count= "+ dv.Count + "<BR>");
//				//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");
//			
//			
//				DataGrid1.DataSource=dv;
//				DataGrid1.DataBind();
//				
//				// �ˬd�O�_���Ӧ~�������, �Y��, �h��X
//				if(DataGrid1.Items.Count>0)
//				{
//					// ��X���~���褸�~��
//					string ThisYear = System.DateTime.Today.Year.ToString().Trim();
//			
//					// �ܧ�Z�n�~�몺�榡
//					int i;
//					for(i=0; i< DataGrid1.Items.Count ; i++)
//					{
//						// ��X �Z�n�~��
//						string yyyymm = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();
//						DataGrid1.Items[i].Cells[1].Text = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
//				
//						// �Y����~���, �Z�n�~����ܬ�����r��
//						if(yyyyQuery==ThisYear)  
//						{
//							DataGrid1.Items[i].Cells[1].Text = "<font color=Red>" + DataGrid1.Items[i].Cells[1].Text + "</font>";
//							//DataGrid1.Items[i].Cells[2].Text = "<font color=Red>" + DataGrid1.Items[i].Cells[2].Text + "</font>";
//						}
//					}
//				}
//					//
//				else
//				{
//					Response.Write("<font size=2 color=Red>�d�L���~�������!</font>");
//				}
//			
//			}
//			else
//			{
//				//Response.Write("<font size=2 color=red>�z�S����J�j�M�����!</font><br>");
//				BindGrid();
//			}
//			//Response.Write("yyyyQuery= " + yyyyQuery + "<br>");
//			
//
//			// �M���w�蠟 ItemStyle ���]�w(�C��...)
//			//DataGrid1.SelectedItemStyle.Reset();
//		}
		
		
//		private void Cleartbx_Click(object sender, System.EventArgs e)
//		{
//			this.tbxQString.Text = "";
//			BindGrid();
//
//			// �M���w�蠟 ItemStyle ���]�w(�C��...)
//			//DataGrid1.SelectedItemStyle.Reset();
//		}
		
		
//		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			// ��� ���U���D��s�� �X�{���T��
//			this.lblMessage.Text = "=> �z�D�諸�O: ";
//			this.lblGetBookPNo.Text = ((LinkButton)DataGrid1.SelectedItem.Cells[3].Controls[0]).Text;
//			hiddenBookPNo.Value = this.lblGetBookPNo.Text;
//
//			this.lblYYYYMM.Text = DataGrid1.SelectedItem.Cells[1].Text.ToString();
//			string yyyymm = DataGrid1.SelectedItem.Cells[1].Text.ToString();
//			// �Yyyyymm�Ȥ@���C��, �h������X���; �_�h, �h�� <font> ������r���X���
//			if(yyyymm.Length==7)
//				hiddenYYYYMM.Value = yyyymm.Substring(0, 4) + yyyymm.Substring(5, 2);
//			else if(yyyymm.Length==31)
//				hiddenYYYYMM.Value = yyyymm.Substring(17, 4) + yyyymm.Substring(22, 2);
//		}
		
		
		
	}
}
