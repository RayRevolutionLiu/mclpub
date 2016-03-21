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
using System.Configuration;

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for OrderListFilter.
	/// </summary>
	public class UnpaidListFilter : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.CheckBox cbx2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.CheckBox cbx4;
		protected System.Web.UI.WebControls.CheckBox cbx5;
		protected System.Web.UI.WebControls.CheckBox cbx6;
		protected System.Web.UI.WebControls.CheckBox cbx3;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox tbxDate1;
		protected System.Web.UI.WebControls.TextBox tbxDate2;
		protected System.Web.UI.WebControls.TextBox tbxMfrno;
		protected System.Web.UI.WebControls.TextBox tbxIano;
		protected System.Web.UI.WebControls.TextBox tbxInvno;
		protected System.Web.UI.WebControls.TextBox tbxMfrname;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.TextBox tbxProj;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Label lblDateMessage;
		protected System.Web.UI.WebControls.Label lblProjMessage;

		public UnpaidListFilter()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			if (!IsPostBack)
			{
				tbxDate1.Text=DateTime.Today.ToString("yyyy/MM/dd");
				tbxDate2.Text=DateTime.Today.ToString("yyyy/MM/dd");
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "v_ia_unpaid", new System.Data.Common.DataColumnMapping[] {
																																																					 new System.Data.Common.DataColumnMapping("ia_iaid", "ia_iaid"),
																																																					 new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd"),
																																																					 new System.Data.Common.DataColumnMapping("ia_iasdate", "ia_iasdate"),
																																																					 new System.Data.Common.DataColumnMapping("ia_iasseq", "ia_iasseq"),
																																																					 new System.Data.Common.DataColumnMapping("ia_iaitem", "ia_iaitem"),
																																																					 new System.Data.Common.DataColumnMapping("ia_iano", "ia_iano"),
																																																					 new System.Data.Common.DataColumnMapping("ia_refno", "ia_refno"),
																																																					 new System.Data.Common.DataColumnMapping("ia_mfrno", "ia_mfrno"),
																																																					 new System.Data.Common.DataColumnMapping("ia_pyno", "ia_pyno"),
																																																					 new System.Data.Common.DataColumnMapping("ia_pyseq", "ia_pyseq"),
																																																					 new System.Data.Common.DataColumnMapping("ia_pyat", "ia_pyat"),
																																																					 new System.Data.Common.DataColumnMapping("ia_ivat", "ia_ivat"),
																																																					 new System.Data.Common.DataColumnMapping("ia_invno", "ia_invno"),
																																																					 new System.Data.Common.DataColumnMapping("ia_invdate", "ia_invdate"),
																																																					 new System.Data.Common.DataColumnMapping("ia_fgitri", "ia_fgitri"),
																																																					 new System.Data.Common.DataColumnMapping("ia_rnm", "ia_rnm"),
																																																					 new System.Data.Common.DataColumnMapping("ia_raddr", "ia_raddr"),
																																																					 new System.Data.Common.DataColumnMapping("ia_rzip", "ia_rzip"),
																																																					 new System.Data.Common.DataColumnMapping("ia_rjbti", "ia_rjbti"),
																																																					 new System.Data.Common.DataColumnMapping("ia_rtel", "ia_rtel"),
																																																					 new System.Data.Common.DataColumnMapping("ia_fgnonauto", "ia_fgnonauto"),
																																																					 new System.Data.Common.DataColumnMapping("ia_invcd", "ia_invcd"),
																																																					 new System.Data.Common.DataColumnMapping("ia_taxtp", "ia_taxtp"),
																																																					 new System.Data.Common.DataColumnMapping("ia_status", "ia_status"),
																																																					 new System.Data.Common.DataColumnMapping("ia_cname", "ia_cname"),
																																																					 new System.Data.Common.DataColumnMapping("ia_tel", "ia_tel"),
																																																					 new System.Data.Common.DataColumnMapping("ia_contno", "ia_contno"),
																																																					 new System.Data.Common.DataColumnMapping("ia_iabdate", "ia_iabdate"),
																																																					 new System.Data.Common.DataColumnMapping("ia_iabseq", "ia_iabseq"),
																																																					 new System.Data.Common.DataColumnMapping("ia_remark", "ia_remark"),
																																																					 new System.Data.Common.DataColumnMapping("py_amt", "py_amt"),
																																																					 new System.Data.Common.DataColumnMapping("py_chkno", "py_chkno"),
																																																					 new System.Data.Common.DataColumnMapping("py_pyno", "py_pyno"),
																																																					 new System.Data.Common.DataColumnMapping("py_date", "py_date"),
																																																					 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																					 new System.Data.Common.DataColumnMapping("iad_fk1", "iad_fk1"),
																																																					 new System.Data.Common.DataColumnMapping("iad_fk2", "iad_fk2"),
																																																					 new System.Data.Common.DataColumnMapping("iad_fk3", "iad_fk3"),
																																																					 new System.Data.Common.DataColumnMapping("iad_fk4", "iad_fk4"),
																																																					 new System.Data.Common.DataColumnMapping("iad_projno", "iad_projno"),
																																																					 new System.Data.Common.DataColumnMapping("iad_desc", "iad_desc"),
																																																					 new System.Data.Common.DataColumnMapping("iad_amt", "iad_amt"),
																																																					 new System.Data.Common.DataColumnMapping("ias_trans_sap", "ias_trans_sap"),
																																																					 new System.Data.Common.DataColumnMapping("ias_createdate", "ias_createdate"),
																																																					 new System.Data.Common.DataColumnMapping("ias_createmen", "ias_createmen"),
																																																					 new System.Data.Common.DataColumnMapping("ias_fgitri", "ias_fgitri")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT ia_iaid, ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat, ia_invno, ia_invdate, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti, ia_rtel, ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno, ia_iabdate, ia_iabseq, ia_remark, py_amt, py_chkno, py_pyno, py_date, mfr_inm, iad_fk1, iad_fk2, iad_fk3, iad_fk4, iad_projno, iad_desc, iad_amt, ias_trans_sap, ias_createdate, ias_createmen, ias_fgitri FROM dbo.v_ia_unpaid";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("srspn_id", "srspn_id"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_tel", "srspn_tel"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_orgcd", "srspn_orgcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_deptcd", "srspn_deptcd"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_date", "srspn_date"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_pwd", "srspn_pwd")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, s" +
				"rspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.ID = "UnpaidListFilter";

		}
		#endregion


		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			DataGrid1.Visible=false;
			btnPrintList.Enabled=false;
			lblProjMessage.Text="";
			lblMessage.Text="";
			Literal1.Text="";
			string	strbuf="1=1";
			string	date1, date2;
			DataSet	ds1=new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "v_ia_unpaid");
			DataView dv1 = ds1.Tables["v_ia_unpaid"].DefaultView;
			if(cbx1.Checked)
			{
				if(tbxProj.Text.Trim().Length<10)
				{
					lblProjMessage.Text="請注意!!計劃代號為10碼";
					return;
				}
				strbuf+=" and iad_projno='"+tbxProj.Text.Trim()+"'";
			}
			if(cbx2.Checked){
				if(tbxDate1.Text=="")
				{
					lblDateMessage.Text="起始日期不可空白!!";
					return;
				}
				else if(tbxDate2.Text=="")
				{
					lblDateMessage.Text="結束日期不可空白!!";
					return;
				}
				else
				{
					date1=tbxDate1.Text.Substring(0,4)+tbxDate1.Text.Substring(5,2)+tbxDate1.Text.Substring(8,2);
					date2=tbxDate2.Text.Substring(0,4)+tbxDate2.Text.Substring(5,2)+tbxDate2.Text.Substring(8,2);
					strbuf+=" and (ia_invdate>='"+date1+"' and ia_invdate<='"+date2+"')";
				}
			}
			if(cbx3.Checked)
			{
				strbuf+=" and ia_mfrno='"+tbxMfrno.Text.Trim()+"'";
			}
			if(cbx4.Checked)
				strbuf+=" and mfr_inm LIKE '%"+tbxMfrname.Text.Trim()+"%'";
			if(cbx5.Checked)
				strbuf+=" and ia_invno='"+tbxInvno.Text.Trim()+"'";
			if(cbx6.Checked)
				strbuf+=" and ia_iano ='"+tbxIano.Text.Trim()+"'";
			dv1.RowFilter=strbuf;
//			dv1.RowFilter="ia_invdate>='20030401' and ia_invdate<='20030410'";
			if(dv1.Count==0)
				lblMessage.Text="查無資料, 請重設查詢條件";

			else
			{
				lblProjMessage.Text="";
				lblDateMessage.Text="";
				lblMessage.Text="查詢到"+dv1.Count.ToString()+"筆資料";
				DataGrid1.Visible=true;
				DataGrid1.DataSource=dv1;
				DataGrid1.DataBind();
				btnPrintList.Enabled=true;
			}
		}

		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			string	date1, date2;
			string reg=User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
			DataSet	ds2=new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "srspn");
			DataView dv2 = ds2.Tables["srspn"].DefaultView;
			dv2.RowFilter="srspn_empno = '"+reg+"'";
			if(dv2.Count>0)
			{
				string	cname=dv2[0].Row["srspn_cname"].ToString().Trim();
				string	strbuf="unpaid_list.aspx?cname="+cname;
				if(cbx1.Checked)
					strbuf+="&proj="+tbxProj.Text.Trim();
				else
					strbuf+="&proj=";

				if(cbx2.Checked)
				{
					date1=tbxDate1.Text.Substring(0,4)+tbxDate1.Text.Substring(5,2)+tbxDate1.Text.Substring(8,2);
					date2=tbxDate2.Text.Substring(0,4)+tbxDate2.Text.Substring(5,2)+tbxDate2.Text.Substring(8,2);
					strbuf+="&date1="+date1+"&date2="+date2;
				}
				else
					strbuf+="&date1=&date2=";
				
				if(cbx3.Checked)
					strbuf+="&mfrno="+tbxMfrno.Text.Trim();
				else
					strbuf+="&mfrno=";
				
				if(cbx4.Checked)
					strbuf+="&mfrname="+tbxMfrname.Text.Trim();
				else
					strbuf+="&mfrname=";

				if(cbx5.Checked)
					strbuf+="&invno="+tbxInvno.Text.Trim();
				else
					strbuf+="&invno=";

				if(cbx6.Checked)
					strbuf+="&iano="+tbxIano.Text.Trim();
				else
					strbuf+="&iano=";
				Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
			}
			else
				lblMessage.Text="您沒有權限列印此份報表";
		}
	}
}
