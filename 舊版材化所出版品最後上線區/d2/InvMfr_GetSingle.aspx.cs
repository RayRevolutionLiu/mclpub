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
	/// Summary description for InvMfr_GetSingle.
	/// </summary>
	public class InvMfr_GetSingle : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.Label lblCountMessage;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		// html Control
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenContNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenCustNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenOldContNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenfgnew;
		
		
		public InvMfr_GetSingle()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}
		
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if(!Page.IsPostBack)
			{
				// �ˬd�O�_�����
				BindGrid1();
				
				// �Y�n�W�׸��, ����X�����ǻ��Ѽ�, �A���ѳs���Ӷ}�s����
				GoLink();
			}
		}
		
		
		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		// ���J���v���
		private void BindGrid1()
		{
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "invmfr");
			DataView dv1 = ds1.Tables["invmfr"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr1 = "1=1";
			
			string contno = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
			{
				contno = Context.Request.QueryString["contno"].ToString().Trim();
				rowfilterstr1 = rowfilterstr1 + " and im_contno = '" + contno + "'";
			}
			else
			{
				contno = "0";
			}
			dv1.RowFilter = rowfilterstr1;
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");
			
			// �Y�j�M���G�� "�䤣��" ���B�z
			if(dv1.Count > 0)
			{
				DataGrid1.DataSource=dv1;
				DataGrid1.DataBind();
				
				this.lblCountMessage.Text = "(�@�� " + dv1.Count + " �����.)";
				
				
				// �S�O��줧��X�榡�ഫ - �ܧ�ñ��������榡
				int i;
				for(i=0; i< DataGrid1.Items.Count ; i++)
				{
					// �o�����O
					string invcd =  DataGrid1.Items[i].Cells[10].Text.ToString().Trim();
					switch (invcd) 
					{
						case "2":
							DataGrid1.Items[i].Cells[10].Text = "�G�p";
							break;
						case "3":
							DataGrid1.Items[i].Cells[10].Text = "�T�p";
							break;
						case "4":
							DataGrid1.Items[i].Cells[10].Text = "��L";
							break;
						default:
							DataGrid1.Items[i].Cells[10].Text = "�T�p";
							break;
					}
					
					// �o���ҵ|�O
					string taxtp = DataGrid1.Items[i].Cells[11].Text.ToString().Trim();
					switch (taxtp) 
					{
						case "1":
							DataGrid1.Items[i].Cells[11].Text = "���|5%";
							break;
						case "2":
							DataGrid1.Items[i].Cells[11].Text = "�s�|";
							break;
						case "3":
							DataGrid1.Items[i].Cells[11].Text = "�K�|";
							break;
						default:
							DataGrid1.Items[i].Cells[11].Text = "���|5%";
							break;
					}
					
					// �|�Ҥ����O
					string fgItri = DataGrid1.Items[i].Cells[12].Text.ToString().Trim();
					switch (fgItri) 
					{
						case " ":
							DataGrid1.Items[i].Cells[12].Text = "�_";
							break;
						case "06":
							DataGrid1.Items[i].Cells[12].Text = "<font color='Red'>�Ҥ�</font>";
							break;
						case "07":
							DataGrid1.Items[i].Cells[12].Text = "<font color='Red'>�|��</font>";
							break;
						default:
							DataGrid1.Items[i].Cells[12].Text = "�_";
							break;
					}
					// ���� for loop
				}

				// ���� if(dv1.Count > 0)
			}
			else
			{
				this.lblCountMessage.Text = "(�L���!)";
			}
		}
		
		
		// �Y�n�W�׸��, ����X�����ǻ��Ѽ�, �A���ѳs���Ӷ}�s����
		private void GoLink()
		{
			// ��X�����ǻ��Ѽ�
			string contno = "";
			if(Context.Request.QueryString["contno"].ToString().Trim() != "")
			{
				contno = Context.Request.QueryString["contno"].ToString().Trim();
			}
			else
			{
				contno = "0";
			}
			//Response.Write("contno= " + contno + "<br>");
			this.hiddenContNo.Value = contno;
			//Response.Write("this.hiddenContNo.Value= " + this.hiddenContNo.Value + "<br>");
			
			string custno = "";
			if(Context.Request.QueryString["custno"].ToString().Trim() != "")
			{
				custno = Context.Request.QueryString["custno"].ToString().Trim();
			}
			else
			{
				custno = "0";
			}
			//Response.Write("custno= " + custno + "<br>");
			this.hiddenCustNo.Value = custno;
			//Response.Write("this.hiddenCustNo.Value= " + this.hiddenCustNo.Value + "<br>");
			
			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c2_cont");
			DataView dv2 = ds2.Tables["c2_cont"].DefaultView;
			
			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr2 = "1=1";
			rowfilterstr2 = rowfilterstr2 + " AND cont_contno=" + contno;
			dv2.RowFilter = rowfilterstr2;
			
			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
			//Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
			
			// �Y�j�M���G�� "�䤣��" ���B�z
			string oldcontno = "0";
			int CountNo = 0;
			string fgnew = "0";
			if(dv2.Count > 0)
			{
				// ��X��L�Ѽƭ�
				oldcontno = dv2[0]["cont_oldcontno"].ToString().Trim();
				this.hiddenOldContNo.Value = oldcontno;
				//Response.Write("this.hiddenOldContNo.Value= " + this.hiddenOldContNo.Value + "<br>");
				
				CountNo = Convert.ToInt32(dv2[0]["CountNo"].ToString().Trim());
				if(CountNo > 0)
					fgnew = "1";
				else
					fgnew = "0";
				this.hiddenfgnew.Value = fgnew;
				//Response.Write("this.hiddenfgnew.Value= " + this.hiddenfgnew.Value + "<br>");
				
				//Response.Write("oldcontno= " + oldcontno + "<BR>");
				//Response.Write("CountNo= " + CountNo + "<BR>");
				//Response.Write("fgnew= " + fgnew + "<BR>");
			}
		
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
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
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
																									  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																				new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																				new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																				new System.Data.Common.DataColumnMapping("im_mfrno", "im_mfrno"),
																																																				new System.Data.Common.DataColumnMapping("im_nm", "im_nm"),
																																																				new System.Data.Common.DataColumnMapping("im_jbti", "im_jbti"),
																																																				new System.Data.Common.DataColumnMapping("im_zip", "im_zip"),
																																																				new System.Data.Common.DataColumnMapping("im_addr", "im_addr"),
																																																				new System.Data.Common.DataColumnMapping("im_tel", "im_tel"),
																																																				new System.Data.Common.DataColumnMapping("im_fax", "im_fax"),
																																																				new System.Data.Common.DataColumnMapping("im_cell", "im_cell"),
																																																				new System.Data.Common.DataColumnMapping("im_email", "im_email"),
																																																				new System.Data.Common.DataColumnMapping("im_invcd", "im_invcd"),
																																																				new System.Data.Common.DataColumnMapping("im_taxtp", "im_taxtp"),
																																																				new System.Data.Common.DataColumnMapping("im_fgitri", "im_fgitri")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, " +
				"im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp, im_fgitri FROM invmfr";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_oldcontno", "cont_oldcontno"),
																																																				 new System.Data.Common.DataColumnMapping("CountNo", "CountNo")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_custno, c2_cont.cont_oldcontno, COUNT(invmfr.im_imseq) AS CountNo FROM c2_cont LEFT OUTER JOIN invmfr ON c2_cont.cont_syscd = invmfr.im_syscd AND c2_cont.cont_contno = invmfr.im_contno GROUP BY c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_custno, c2_cont.cont_oldcontno";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		
	}
}
