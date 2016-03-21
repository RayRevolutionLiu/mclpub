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
using System.Configuration;

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for CardListFilter.
	/// </summary>
	public class CardListFilter : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxOrderDate1;
		protected System.Web.UI.WebControls.TextBox tbxOrderDate2;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DropDownList ddlPrintFlag;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdatePyseq;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.Label Label1;
	
		public CardListFilter()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			if (!IsPostBack)
			{
				Literal1.Text="";
				tbxOrderDate1.Text=System.DateTime.Today.ToString("yyyy/MM/dd");
				tbxOrderDate2.Text=System.DateTime.Today.ToString("yyyy/MM/dd");
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
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlUpdatePyseq = new System.Data.SqlClient.SqlCommand();
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.DataList1.ItemCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_ItemCommand);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT py_pyid, py_pyno, py_amt, py_pytpcd, py_date, py_moseq, py_moitem, py_chkno, py_chkbnm, py_chkdate, py_waccno, py_wdate, py_wbcd, py_ccno, py_cctp, py_ccauthcd, py_ccvdate, py_ccdate, py_fgprinted, py_syscd, py_pysdate, py_pysseq, py_pysitem FROM dbo.py";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, s" +
				"rspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT pys_pysid, pys_syscd, pys_pysdate, pys_pysseq, pys_toitem, pys_pytpcd, pys" +
				"_fgprinted, pys_createdate, pys_createmen FROM dbo.pyseq";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "py", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("py_pyid", "py_pyid"),
																																																			new System.Data.Common.DataColumnMapping("py_pyno", "py_pyno"),
																																																			new System.Data.Common.DataColumnMapping("py_amt", "py_amt"),
																																																			new System.Data.Common.DataColumnMapping("py_pytpcd", "py_pytpcd"),
																																																			new System.Data.Common.DataColumnMapping("py_date", "py_date"),
																																																			new System.Data.Common.DataColumnMapping("py_moseq", "py_moseq"),
																																																			new System.Data.Common.DataColumnMapping("py_moitem", "py_moitem"),
																																																			new System.Data.Common.DataColumnMapping("py_chkno", "py_chkno"),
																																																			new System.Data.Common.DataColumnMapping("py_chkbnm", "py_chkbnm"),
																																																			new System.Data.Common.DataColumnMapping("py_chkdate", "py_chkdate"),
																																																			new System.Data.Common.DataColumnMapping("py_waccno", "py_waccno"),
																																																			new System.Data.Common.DataColumnMapping("py_wdate", "py_wdate"),
																																																			new System.Data.Common.DataColumnMapping("py_wbcd", "py_wbcd"),
																																																			new System.Data.Common.DataColumnMapping("py_ccno", "py_ccno"),
																																																			new System.Data.Common.DataColumnMapping("py_cctp", "py_cctp"),
																																																			new System.Data.Common.DataColumnMapping("py_ccauthcd", "py_ccauthcd"),
																																																			new System.Data.Common.DataColumnMapping("py_ccvdate", "py_ccvdate"),
																																																			new System.Data.Common.DataColumnMapping("py_ccdate", "py_ccdate"),
																																																			new System.Data.Common.DataColumnMapping("py_fgprinted", "py_fgprinted"),
																																																			new System.Data.Common.DataColumnMapping("py_syscd", "py_syscd"),
																																																			new System.Data.Common.DataColumnMapping("py_pysdate", "py_pysdate"),
																																																			new System.Data.Common.DataColumnMapping("py_pysseq", "py_pysseq"),
																																																			new System.Data.Common.DataColumnMapping("py_pysitem", "py_pysitem")})});
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
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "pyseq", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("pys_pysid", "pys_pysid"),
																																																			   new System.Data.Common.DataColumnMapping("pys_syscd", "pys_syscd"),
																																																			   new System.Data.Common.DataColumnMapping("pys_pysdate", "pys_pysdate"),
																																																			   new System.Data.Common.DataColumnMapping("pys_pysseq", "pys_pysseq"),
																																																			   new System.Data.Common.DataColumnMapping("pys_toitem", "pys_toitem"),
																																																			   new System.Data.Common.DataColumnMapping("pys_pytpcd", "pys_pytpcd"),
																																																			   new System.Data.Common.DataColumnMapping("pys_fgprinted", "pys_fgprinted"),
																																																			   new System.Data.Common.DataColumnMapping("pys_createdate", "pys_createdate"),
																																																			   new System.Data.Common.DataColumnMapping("pys_createmen", "pys_createmen")})});
			// 
			// sqlUpdatePyseq
			// 
			this.sqlUpdatePyseq.CommandText = "UPDATE dbo.pyseq SET pys_fgprinted = @pys_fgprinted WHERE (pys_pysdate = @pys_pys" +
				"date) AND (pys_pysseq = @pys_pysseq)";
			this.sqlUpdatePyseq.Connection = this.sqlConnection1;
			this.sqlUpdatePyseq.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_fgprinted", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_fgprinted", System.Data.DataRowVersion.Current, null));
			this.sqlUpdatePyseq.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_pysdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_pysdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdatePyseq.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_pysseq", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_pysseq", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			string	date1, date2;
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "pyseq");
			DataView dv1 = ds1.Tables["pyseq"].DefaultView;
			date1=tbxOrderDate1.Text.Substring(0,4)+tbxOrderDate1.Text.Substring(5,2)+tbxOrderDate1.Text.Substring(8,2);
			date2=tbxOrderDate2.Text.Substring(0,4)+tbxOrderDate2.Text.Substring(5,2)+tbxOrderDate2.Text.Substring(8,2);
			dv1.RowFilter = "pys_fgprinted='"+ddlPrintFlag.SelectedItem.Value.Trim()+"' and (pys_createdate>='"+date1+"' and pys_createdate<='"+date2+"')"+
				" and pys_pytpcd = '05'";
			if(dv1.Count>0)
			{
				DataList1.Visible=true;
				DataList1.DataSource = dv1;
				DataList1.DataBind();
				btnPrint.Enabled=true;
				lblMessage.Text="";
			}
			else
			{
				DataList1.Visible=false;
				lblMessage.Text="沒有符合的資料";
				btnPrint.Enabled=false;
			}
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			string	strbuf="";
			string	strbuf1="";
			int	j=0;
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked==true)
				{
					strbuf+=((Label)DataList1.Items[i].FindControl("lblpysdate")).Text.Trim();
					strbuf+=((Label)DataList1.Items[i].FindControl("lblpysseq")).Text.Trim();
					j++;
				}
			}
			if(j<=0)
				lblMessage.Text="您尚未選擇任何繳款清單";
			else
			{
				string reg=User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
				DataSet	ds2=new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "srspn");
				DataView dv2 = ds2.Tables["srspn"].DefaultView;
				dv2.RowFilter="srspn_empno = '"+reg+"'";
				if(dv2.Count>0)
				{
					string	cname=dv2[0].Row["srspn_cname"].ToString().Trim();
					strbuf1="card_list1.aspx?cname="+cname+"&pyseq="+strbuf+"&count="+j.ToString().Trim();
					Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf1+"\");</script>";
					//將 pyseq 中 pys_printed 設為 1
					if(ddlPrintFlag.SelectedItem.Value.Trim()=="0")
					{
						for(int i=0; i<DataList1.Items.Count; i++)
						{
							if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked==true)
							{
								this.sqlUpdatePyseq.Parameters["@pys_pysdate"].Value=((Label)DataList1.Items[i].FindControl("lblpysdate")).Text.Trim();
								this.sqlUpdatePyseq.Parameters["@pys_pysseq"].Value=((Label)DataList1.Items[i].FindControl("lblpysseq")).Text.Trim();
								this.sqlUpdatePyseq.Parameters["@pys_fgprinted"].Value="1";
								this.sqlUpdatePyseq.Connection.Open();
								this.sqlUpdatePyseq.ExecuteNonQuery();
								this.sqlUpdatePyseq.Connection.Close();
							}
						}
					}
				}
			}
		}

		private void DataList1_ItemCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			if(e.CommandName=="detail")
			{
				DataSet	ds3=new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "py");
				DataView dv3 = ds3.Tables["py"].DefaultView;
				dv3.RowFilter="py_pysdate = '"+((Label)e.Item.FindControl("lblpysdate")).Text+"'"
							+ " and py_pysseq = '"+((Label)e.Item.FindControl("lblpysseq")).Text+"'";
//				Response.Write(((Label)e.Item.FindControl("lblpysdate")).Text+"-"+((Label)e.Item.FindControl("lblpysseq")).Text);
				DataGrid1.DataSource=dv3;
				DataGrid1.DataBind();
			}
		}
	}
}
