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
	/// Summary description for PayListFilter.
	/// </summary>
	public class PayListFilter : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnList;
		protected System.Web.UI.WebControls.Button btnListPrint;
		protected System.Web.UI.WebControls.DataList DataList2;
		protected System.Web.UI.WebControls.DataList DataList3;
		protected System.Web.UI.WebControls.DataList DataList4;
		protected System.Web.UI.WebControls.DataList DataList5;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlComUpdatePy;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.Label lblyyyymm;
		protected System.Web.UI.WebControls.Label lblbatch;
		protected System.Web.UI.WebControls.Label lbltoitem;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Web.UI.WebControls.DropDownList ddlPayType;
	
		public PayListFilter()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				Response.Expires=0;
			
				//付款方式
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "pytp");
				ddlPayType.DataSource=ds1;
				ddlPayType.DataTextField="pytp_nm";
				ddlPayType.DataValueField="pytp_pytpcd";
				ddlPayType.DataBind();
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
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlComUpdatePy = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.btnListPrint.Click += new System.EventHandler(this.btnListPrint_Click);
			this.ddlPayType.SelectedIndexChanged += new System.EventHandler(this.ddlPayType_SelectedIndexChanged);
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnList.Click += new System.EventHandler(this.btnList_Click);
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM dbo.pyseq WHERE (pys_pysdate = @pys_pysdate) AND (pys_pysseq = @pys_p" +
				"ysseq)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_pysdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_pysdate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_pysseq", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_pysseq", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM1;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=03212-840695;packet size=4096";
			this.sqlConnection1.ConnectionString = ConfigurationSettings.AppSettings["mrlpub2"].ToString();
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "pyseq", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("maxseq", "maxseq"),
																																																			   new System.Data.Common.DataColumnMapping("pys_pysdate", "pys_pysdate")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT MAX(pys_pysseq) AS maxseq, pys_pysdate FROM dbo.pyseq GROUP BY pys_pysdate" +
				"";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT pys_pysid, pys_syscd, pys_pysdate, pys_pysseq, pys_toitem, pys_pytpcd, pys" +
				"_ccseq, pys_createdate, pys_createmen FROM dbo.pyseq";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT py_pyid, py_pyno, py_amt, py_pytpcd, py_date, py_moseq, py_moitem, py_chkn" +
				"o, py_chkbnm, py_chkdate, py_waccno, py_wdate, py_wbcd, py_ccno, py_cctp, py_cca" +
				"uthcd, py_ccvdate, py_fgprinted, py_syscd, py_pysdate, py_pysseq, py_pysitem FRO" +
				"M dbo.py";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT pytp_pytpid, pytp_pytpcd, pytp_nm FROM dbo.pytp";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlComUpdatePy
			// 
			this.sqlComUpdatePy.CommandText = "UPDATE dbo.py SET py_pysdate = @py_pysdate, py_pysseq = @py_pysseq, py_pysitem = " +
				"@py_pysitem WHERE (py_pyno = @py_pyno)";
			this.sqlComUpdatePy.Connection = this.sqlConnection1;
			this.sqlComUpdatePy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysdate", System.Data.DataRowVersion.Current, null));
			this.sqlComUpdatePy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysseq", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysseq", System.Data.DataRowVersion.Current, null));
			this.sqlComUpdatePy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pysitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pysitem", System.Data.DataRowVersion.Current, null));
			this.sqlComUpdatePy.Parameters.Add(new System.Data.SqlClient.SqlParameter("@py_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "py_pyno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
																																																			new System.Data.Common.DataColumnMapping("py_fgprinted", "py_fgprinted"),
																																																			new System.Data.Common.DataColumnMapping("py_syscd", "py_syscd"),
																																																			new System.Data.Common.DataColumnMapping("py_pysdate", "py_pysdate"),
																																																			new System.Data.Common.DataColumnMapping("py_pysseq", "py_pysseq"),
																																																			new System.Data.Common.DataColumnMapping("py_pysitem", "py_pysitem")})});
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter3.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			this.sqlDataAdapter3.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO dbo.pyseq(pys_syscd, pys_pysdate, pys_pysseq, pys_toitem, pys_pytpcd," +
				" pys_fgprinted, pys_createdate, pys_createmen) VALUES (@pys_syscd, @pys_pysdate, @py" +
				"s_pysseq, @pys_toitem, @pys_pytpcd, @pys_fgprinted, @pys_createdate, @pys_createmen)" +
				"";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_pysdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_pysdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_pysseq", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_pysseq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_toitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_toitem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_pytpcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_fgprinted", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_fgprinted", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_createdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_createdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_createmen", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_createmen", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.pyseq SET pys_syscd = @pys_syscd, pys_pysdate = @pys_pysdate, pys_pysseq = @pys_pysseq, pys_toitem = @pys_toitem, pys_pytpcd = @pys_pytpcd, pys_fgprinted = @pys_fgprinted, pys_createdate = @pys_createdate, pys_createmen = @pys_createmen WHERE (pys_pysdate = @Original_pys_pysdate) AND (pys_pysseq = @Original_pys_pysseq)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_pysdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_pysdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_pysseq", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_pysseq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_toitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_toitem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_pytpcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_fgprinted", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_fgprinted", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_createdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_createdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pys_createmen", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_createmen", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_pys_pysdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_pysdate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_pys_pysseq", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "pys_pysseq", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "pytp", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("pytp_pytpid", "pytp_pytpid"),
																																																			  new System.Data.Common.DataColumnMapping("pytp_pytpcd", "pytp_pytpcd"),
																																																			  new System.Data.Common.DataColumnMapping("pytp_nm", "pytp_nm")})});
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "srspn", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("srspn_id", "srspn_id"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_empno", "srspn_empno"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_cname", "srspn_cname"),
																																																			   new System.Data.Common.DataColumnMapping("srspn_atype", "srspn_atype")})});
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT srspn_id, srspn_empno, srspn_cname, srspn_atype FROM dbo.srspn";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			DataList1.Visible=false;
			DataList2.Visible=false;
			DataList3.Visible=false;
			DataList4.Visible=false;
			DataList5.Visible=false;
			btnList.Enabled=false;
			btnListPrint.Enabled=false;
			lblMessage.Text="";
			lblyyyymm.Text="0";
			lblbatch.Text="0";
			lbltoitem.Text="0";
			DataGrid1.Visible=false;
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "py");
			DataView dv2 = ds2.Tables["py"].DefaultView;
			dv2.RowFilter="py_pytpcd='"+ddlPayType.SelectedItem.Value+"' and py_pysdate=''";
			if(dv2.Count<=0)
			{
				lblMessage.Text="沒有資料";
			}
			else
			{
				if(ddlPayType.SelectedItem.Value=="01")
				{
					DataList1.Visible=true;
					DataList1.DataSource=dv2;
					DataList1.DataBind();
					for(int i=0; i<DataList1.Items.Count; i++)
						((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked=true;
				}
				else if(ddlPayType.SelectedItem.Value=="02")
				{
					DataList2.Visible=true;
					DataList2.DataSource=dv2;
					DataList2.DataBind();
					for(int i=0; i<DataList2.Items.Count; i++)
						((CheckBox)DataList2.Items[i].FindControl("cbx2")).Checked=true;
				}
				else if(ddlPayType.SelectedItem.Value=="03")
				{
					DataList3.Visible=true;
					DataList3.DataSource=dv2;
					DataList3.DataBind();
					for(int i=0; i<DataList3.Items.Count; i++)
						((CheckBox)DataList3.Items[i].FindControl("cbx3")).Checked=true;
				}
				else if(ddlPayType.SelectedItem.Value=="04")
				{
					DataList4.Visible=true;
					DataList4.DataSource=dv2;
					DataList4.DataBind();
					for(int i=0; i<DataList4.Items.Count; i++)
						((CheckBox)DataList4.Items[i].FindControl("cbx4")).Checked=true;
				}
				else if(ddlPayType.SelectedItem.Value=="05")
				{
					DataList5.Visible=true;
					DataList5.DataSource=dv2;
					DataList5.DataBind();
					for(int i=0; i<DataList5.Items.Count; i++)
						((CheckBox)DataList5.Items[i].FindControl("cbx5")).Checked=true;
				}
				btnList.Enabled=true;
			}
		}

		private void btnList_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			int j=0;
			switch(ddlPayType.SelectedItem.Value)
			{
				case "01":
					for(int i=0; i<DataList1.Items.Count; i++)
					{
						if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked==true)
							j++;
					}
					break;
				case "02":
					for(int i=0; i<DataList2.Items.Count; i++)
					{
						if(((CheckBox)DataList2.Items[i].FindControl("cbx2")).Checked==true)
							j++;
					}
					break;
				case "03":
					for(int i=0; i<DataList3.Items.Count; i++)
					{
						if(((CheckBox)DataList3.Items[i].FindControl("cbx3")).Checked==true)
							j++;
					}
					break;
				case "04":
					for(int i=0; i<DataList4.Items.Count; i++)
					{
						if(((CheckBox)DataList4.Items[i].FindControl("cbx4")).Checked==true)
							j++;
					}
					break;
				case "05":
					for(int i=0; i<DataList5.Items.Count; i++)
					{
						if(((CheckBox)DataList5.Items[i].FindControl("cbx5")).Checked==true)
							j++;
					}
					break;
			}
			if(j>0)
				CreateList(j);
			else
				lblMessage.Text="注意!尚未選擇任何繳款單";

		}

		private void ddlPayType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			DataList1.Visible=false;
			DataList2.Visible=false;
			DataList3.Visible=false;
			DataList4.Visible=false;
			DataList5.Visible=false;
			btnList.Enabled=false;
			btnListPrint.Enabled=false;
			lblMessage.Text="";
			DataGrid1.Visible=false;
		}
		private void CreateList(int toitem)
		{
			string reg=User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
			string maxseq="";
			string	yyyymm=System.DateTime.Today.Year.ToString();
			if(System.DateTime.Today.Month.ToString().Length<2)
				yyyymm=yyyymm+"0"+System.DateTime.Today.Month.ToString();
			else
				yyyymm=yyyymm+System.DateTime.Today.Month.ToString();
			//取出批次
			DataSet ds4 = new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "pyseq");
			DataView dv4 = ds4.Tables["pyseq"].DefaultView;
			if(dv4.Count==0)
				maxseq="0001";
			else
			{
				dv4.RowFilter="pys_pysdate='"+yyyymm+"'";
				if(dv4.Count==0)
					maxseq="0001";
				else
				{
					maxseq=dv4[0].Row["maxseq"].ToString().Trim();
					if (maxseq=="")
						maxseq="0001";
					else
					{
						maxseq=Convert.ToString(Int32.Parse(maxseq)+1);
						//					lblMessage.Text=maxseq.Length.ToString();
						int	j1=maxseq.Length;
						for (int j=0; j<4-j1; j++)
							maxseq="0"+maxseq;
					}
				}
//				lblMessage.Text=maxseq;
			}
			//新增一筆繳款清單資料 (pyseq)
			this.sqlInsertCommand1.Parameters["@pys_syscd"].Value="";
			this.sqlInsertCommand1.Parameters["@pys_pysdate"].Value=yyyymm;
			this.sqlInsertCommand1.Parameters["@pys_pysseq"].Value=maxseq;
			this.sqlInsertCommand1.Parameters["@pys_toitem"].Value=toitem.ToString();
			this.sqlInsertCommand1.Parameters["@pys_pytpcd"].Value=ddlPayType.SelectedItem.Value;
			this.sqlInsertCommand1.Parameters["@pys_fgprinted"].Value="0";
			this.sqlInsertCommand1.Parameters["@pys_createdate"].Value=System.DateTime.Today.ToString("yyyyMMdd");
			this.sqlInsertCommand1.Parameters["@pys_createmen"].Value=reg;
			this.sqlInsertCommand1.Connection.Open();
			this.sqlInsertCommand1.ExecuteNonQuery();
			this.sqlInsertCommand1.Connection.Close();
//			lblMessage.Text="產生年月:"+yyyymm+"<br>批次:"+maxseq+"<br>項次:"+toitem.ToString();
			lblyyyymm.Text=yyyymm;
			lblbatch.Text=maxseq;
			lbltoitem.Text=toitem.ToString();
			//將繳款清單產生年月,批次,項次回寫至繳款單檔(py)
			int	item=1;
			switch(ddlPayType.SelectedItem.Value)
			{
				case "01":
					for(int i=0; i<DataList1.Items.Count; i++)
					{
						if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked==true)
						{
							this.sqlComUpdatePy.Parameters["@py_pyno"].Value=((Label)DataList1.Items[i].FindControl("lblNo1")).Text.Trim();
							this.sqlComUpdatePy.Parameters["@py_pysdate"].Value=yyyymm;
							this.sqlComUpdatePy.Parameters["@py_pysseq"].Value=maxseq;
							this.sqlComUpdatePy.Parameters["@py_pysitem"].Value=item.ToString();
							this.sqlComUpdatePy.Connection.Open();
							this.sqlComUpdatePy.ExecuteNonQuery();
							this.sqlComUpdatePy.Connection.Close();
							item++;
						}
					}
					break;
				case "02":
					for(int i=0; i<DataList2.Items.Count; i++)
					{
						if(((CheckBox)DataList2.Items[i].FindControl("cbx2")).Checked==true)
						{
							this.sqlComUpdatePy.Parameters["@py_pyno"].Value=((Label)DataList2.Items[i].FindControl("lblNo2")).Text.Trim();
							this.sqlComUpdatePy.Parameters["@py_pysdate"].Value=yyyymm;
							this.sqlComUpdatePy.Parameters["@py_pysseq"].Value=maxseq;
							this.sqlComUpdatePy.Parameters["@py_pysitem"].Value=item.ToString();
							this.sqlComUpdatePy.Connection.Open();
							this.sqlComUpdatePy.ExecuteNonQuery();
							this.sqlComUpdatePy.Connection.Close();
							item++;
						}
					}
					break;
				case "03":
					for(int i=0; i<DataList3.Items.Count; i++)
					{
						if(((CheckBox)DataList3.Items[i].FindControl("cbx3")).Checked==true)
						{
							this.sqlComUpdatePy.Parameters["@py_pyno"].Value=((Label)DataList3.Items[i].FindControl("lblNo3")).Text.Trim();
							this.sqlComUpdatePy.Parameters["@py_pysdate"].Value=yyyymm;
							this.sqlComUpdatePy.Parameters["@py_pysseq"].Value=maxseq;
							this.sqlComUpdatePy.Parameters["@py_pysitem"].Value=item.ToString();
							this.sqlComUpdatePy.Connection.Open();
							this.sqlComUpdatePy.ExecuteNonQuery();
							this.sqlComUpdatePy.Connection.Close();
							item++;
						}
					}
					break;
				case "04":
					for(int i=0; i<DataList4.Items.Count; i++)
					{
						if(((CheckBox)DataList4.Items[i].FindControl("cbx4")).Checked==true)
						{
							this.sqlComUpdatePy.Parameters["@py_pyno"].Value=((Label)DataList4.Items[i].FindControl("lblNo4")).Text.Trim();
							this.sqlComUpdatePy.Parameters["@py_pysdate"].Value=yyyymm;
							this.sqlComUpdatePy.Parameters["@py_pysseq"].Value=maxseq;
							this.sqlComUpdatePy.Parameters["@py_pysitem"].Value=item.ToString();
							this.sqlComUpdatePy.Connection.Open();
							this.sqlComUpdatePy.ExecuteNonQuery();
							this.sqlComUpdatePy.Connection.Close();
							item++;
						}
					}
					break;
				case "05":
					for(int i=0; i<DataList5.Items.Count; i++)
					{
						if(((CheckBox)DataList5.Items[i].FindControl("cbx5")).Checked==true)
						{
							this.sqlComUpdatePy.Parameters["@py_pyno"].Value=((Label)DataList5.Items[i].FindControl("lblNo5")).Text.Trim();
							this.sqlComUpdatePy.Parameters["@py_pysdate"].Value=yyyymm;
							this.sqlComUpdatePy.Parameters["@py_pysseq"].Value=maxseq;
							this.sqlComUpdatePy.Parameters["@py_pysitem"].Value=item.ToString();
							this.sqlComUpdatePy.Connection.Open();
							this.sqlComUpdatePy.ExecuteNonQuery();
							this.sqlComUpdatePy.Connection.Close();
							item++;
						}
					}
					break;

			}
			btnListPrint.Enabled=true;
			btnList.Enabled=false;
			DataList1.Visible=false;
			DataList2.Visible=false;
			DataList3.Visible=false;
			DataList4.Visible=false;
			DataList5.Visible=false;
			DataSet ds2 = new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "py");
			DataView dv2 = ds2.Tables["py"].DefaultView;
			dv2.RowFilter="py_pytpcd='"+ddlPayType.SelectedItem.Value
				+"' and py_pysdate='"+lblyyyymm.Text.Trim()
				+"' and py_pysseq='"+lblbatch.Text.Trim()+"'";
			DataGrid1.Visible=true;
			DataGrid1.DataSource=dv2;
			DataGrid1.DataBind();

		}

		private void btnListPrint_Click(object sender, System.EventArgs e)
		{
			string reg=User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
			DataSet	ds5=new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "srspn");
			DataView dv5 = ds5.Tables["srspn"].DefaultView;
			dv5.RowFilter="srspn_empno = '"+reg+"'";
			if(dv5.Count>0)
			{
				string	cname=dv5[0].Row["srspn_cname"].ToString().Trim();
				string	strbuf="";
				if (ddlPayType.SelectedItem.Value=="01")
					strbuf="py_list1.aspx?cname="+cname+
						"&yyyymm="+lblyyyymm.Text+"&batch="+lblbatch.Text;
				else if (ddlPayType.SelectedItem.Value=="02")
					strbuf="py_list2.aspx?cname="+cname+
						"&yyyymm="+lblyyyymm.Text+"&batch="+lblbatch.Text;
				else if (ddlPayType.SelectedItem.Value=="03")
					strbuf="py_list3.aspx?cname="+cname+
						"&yyyymm="+lblyyyymm.Text+"&batch="+lblbatch.Text;
				else if (ddlPayType.SelectedItem.Value=="04")
					strbuf="py_list4.aspx?cname="+cname+
						"&yyyymm="+lblyyyymm.Text+"&batch="+lblbatch.Text;
				else if (ddlPayType.SelectedItem.Value=="05")
					strbuf="py_list5.aspx?cname="+cname+
						"&yyyymm="+lblyyyymm.Text+"&batch="+lblbatch.Text;
				Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
			}
		}
	}
}
