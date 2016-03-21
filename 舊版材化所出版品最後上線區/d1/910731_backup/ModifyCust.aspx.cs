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
	/// Summary description for ModifyCust.
	/// </summary>
	public class ModifyCust : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenId;
		protected System.Web.UI.WebControls.LinkButton lnbBack;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.TextBox tbxCompanyname;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.LinkButton lnbNewCust;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Web.UI.WebControls.TextBox tbxMfrnoSearch;
		protected System.Data.SqlClient.SqlConnection sqlConnection2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
	
		public ModifyCust()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				hiddenId.Value=Context.Request.QueryString["id"];
				tbxCustNo.Text=Context.Request.QueryString["id"];
				if(Context.Request.QueryString["id"]!=""){
					DataSet ds = new DataSet();
					this.sqlDataAdapter1.Fill(ds, "_1_cust");
					DataView dv = ds.Tables["_1_cust"].DefaultView;
					dv.RowFilter = "cust_custno = '"+hiddenId.Value+"'";
					tbxMfrnoSearch.Text=dv[0]["cust_mfrno"].ToString();
					DataList1.EditItemIndex=0;
					DataList1.DataSource = dv;
					DataList1.DataBind();

					DataSet ds1 = new DataSet();
					//show營業檔項目
					this.sqlDataAdapter4.Fill(ds1, "_btp");
					((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblbtp")).DataSource = ds1.Tables["_btp"];
					((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblbtp")).DataTextField="btp_nm";
					((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblbtp")).DataValueField="btp_btpcd";
					((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblbtp")).DataBind();
					//show領域檔項目
					this.sqlDataAdapter5.Fill(ds1, "_itp");
					((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblitp")).DataSource = ds1.Tables["_itp"];
					((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblitp")).DataTextField="itp_nm";
					((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblitp")).DataValueField="itp_itpcd";
					((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblitp")).DataBind();

					string strbtp=((TextBox)DataList1.Items[DataList1.EditItemIndex].FindControl("tbxBtpcd")).Text;
					string stritp=((TextBox)DataList1.Items[DataList1.EditItemIndex].FindControl("tbxItpcd")).Text;
					//選出營業項目
					if (strbtp.Length>0)
					{
						int j;
						for(int i=0; i<strbtp.Length;i+=2)
						{
							j=int.Parse(strbtp.Substring(i,2))-1;
							((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblbtp")).Items[j].Selected=true;
						}
					}
					//選出領域項目
					if (stritp.Length>0)
					{
						int j;
						for(int i=0; i<stritp.Length;i+=2)
						{
							j=int.Parse(stritp.Substring(i,2))-1;
							((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblitp")).Items[j].Selected=true;
						}
					}

				}
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
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection2 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.lnbNewCust.Click += new System.EventHandler(this.LinkButton1_Click);
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.DataList1.CancelCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_CancelCommand);
			this.DataList1.EditCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_EditCommand);
			this.DataList1.UpdateCommand += new System.Web.UI.WebControls.DataListCommandEventHandler(this.DataList1_UpdateCommand);
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM dbo.c1_cust WHERE (cust_custno = @cust_custno)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection2;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection2
			// 
			this.sqlConnection2.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "btp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("btp_btpid", "btp_btpid"),
																																																			 new System.Data.Common.DataColumnMapping("btp_nm", "btp_nm"),
																																																			 new System.Data.Common.DataColumnMapping("btp_btpcd", "btp_btpcd")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT btp_btpid, btp_nm, btp_btpcd FROM dbo.btp";
			this.sqlSelectCommand2.Connection = this.sqlConnection2;
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT itp_itpid, itp_nm, itp_itpcd FROM dbo.itp";
			this.sqlSelectCommand3.Connection = this.sqlConnection2;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT cust_custid, cust_custno, cust_nm, cust_jbti, cust_mfrno, cust_tel, cust_f" +
				"ax, cust_cell, cust_email, cust_regdate, cust_moddate, cust_itpcd, cust_btpcd FR" +
				"OM dbo.c1_cust";
			this.sqlSelectCommand1.Connection = this.sqlConnection2;
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT mfr_mfrid, mfr_mfrno FROM dbo.mfr";
			this.sqlSelectCommand5.Connection = this.sqlConnection2;
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = @"SELECT cust_custid, cust_custno, cust_nm, cust_jbti, cust_mfrno, cust_tel, cust_fax, cust_cell, cust_email, cust_regdate, cust_moddate, cust_fgoi, cust_fgoe, cust_otp1seq1, cust_otp1seq2, cust_otp1seq3, cust_otp1seq9, cust_itpcd, cust_btpcd, cust_oldcustno1, cust_oldcustno2 FROM dbo.c1_cust";
			this.sqlSelectCommand4.Connection = this.sqlConnection2;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.c1_cust SET cust_custno = @cust_custno, cust_nm = @cust_nm, cust_jbti = @cust_jbti, cust_mfrno = @cust_mfrno, cust_tel = @cust_tel, cust_fax = @cust_fax, cust_cell = @cust_cell, cust_email = @cust_email, cust_regdate = @cust_regdate, cust_moddate = @cust_moddate, cust_itpcd = @cust_itpcd, cust_btpcd = @cust_btpcd WHERE (cust_custno = @Original_cust_custno)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection2;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_nm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_nm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_tel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fax", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_cell", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_email", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_regdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_regdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_itpcd", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_itpcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_btpcd", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_btpcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "itp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("itp_itpid", "itp_itpid"),
																																																			 new System.Data.Common.DataColumnMapping("itp_nm", "itp_nm"),
																																																			 new System.Data.Common.DataColumnMapping("itp_itpcd", "itp_itpcd")})});
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mfr", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno")})});
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_cust", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("cust_mfrno", "cust_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("cust_fax", "cust_fax"),
																																																				 new System.Data.Common.DataColumnMapping("cust_cell", "cust_cell"),
																																																				 new System.Data.Common.DataColumnMapping("cust_email", "cust_email"),
																																																				 new System.Data.Common.DataColumnMapping("cust_regdate", "cust_regdate"),
																																																				 new System.Data.Common.DataColumnMapping("cust_moddate", "cust_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("cust_fgoi", "cust_fgoi"),
																																																				 new System.Data.Common.DataColumnMapping("cust_fgoe", "cust_fgoe"),
																																																				 new System.Data.Common.DataColumnMapping("cust_otp1seq1", "cust_otp1seq1"),
																																																				 new System.Data.Common.DataColumnMapping("cust_otp1seq2", "cust_otp1seq2"),
																																																				 new System.Data.Common.DataColumnMapping("cust_otp1seq3", "cust_otp1seq3"),
																																																				 new System.Data.Common.DataColumnMapping("cust_otp1seq9", "cust_otp1seq9"),
																																																				 new System.Data.Common.DataColumnMapping("cust_itpcd", "cust_itpcd"),
																																																				 new System.Data.Common.DataColumnMapping("cust_btpcd", "cust_btpcd"),
																																																				 new System.Data.Common.DataColumnMapping("cust_oldcustno1", "cust_oldcustno1"),
																																																				 new System.Data.Common.DataColumnMapping("cust_oldcustno2", "cust_oldcustno2")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_cust", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				 new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																				 new System.Data.Common.DataColumnMapping("cust_mfrno", "cust_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				 new System.Data.Common.DataColumnMapping("cust_fax", "cust_fax"),
																																																				 new System.Data.Common.DataColumnMapping("cust_cell", "cust_cell"),
																																																				 new System.Data.Common.DataColumnMapping("cust_email", "cust_email"),
																																																				 new System.Data.Common.DataColumnMapping("cust_regdate", "cust_regdate"),
																																																				 new System.Data.Common.DataColumnMapping("cust_moddate", "cust_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("cust_itpcd", "cust_itpcd"),
																																																				 new System.Data.Common.DataColumnMapping("cust_btpcd", "cust_btpcd")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO dbo.c1_cust(cust_custno, cust_nm, cust_jbti, cust_mfrno, cust_tel, cust_fax, cust_cell, cust_email, cust_regdate, cust_moddate, cust_itpcd, cust_btpcd) VALUES (@cust_custno, @cust_nm, @cust_jbti, @cust_mfrno, @cust_tel, @cust_fax, @cust_cell, @cust_email, @cust_regdate, @cust_moddate, @cust_itpcd, @cust_btpcd)";
			this.sqlInsertCommand1.Connection = this.sqlConnection2;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_nm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_nm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_tel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fax", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_cell", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_email", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_regdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_regdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_itpcd", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_itpcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_btpcd", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_btpcd", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//顯示訂戶資料
		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			string	strbuf="1=1";
			if(tbxMfrnoSearch.Text!="")
			{
				DataSet ds3 = new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "mfr");
				DataView dv3 = ds3.Tables["mfr"].DefaultView;
				dv3.RowFilter="mfr_mfrno='"+tbxMfrnoSearch.Text.Trim()+"'";
				if(dv3.Count==0)
				{
					lblMessage.Text="無此廠商資料,請先新增廠商資料";
					DataList1.Visible=false;
				}
				else
				{
					DataSet ds = new DataSet();
					this.sqlDataAdapter2.Fill(ds, "c1_cust");
					DataView dv = ds.Tables["c1_cust"].DefaultView;
					if(tbxMfrnoSearch.Text.Trim()!="")
						strbuf = strbuf +" and cust_mfrno = '"+tbxMfrnoSearch.Text+"'";
					if (hiddenId.Value!="")
						strbuf = strbuf + " and cust_custno = '"+hiddenId.Value+"'";
					else
					{
						if(tbxCustNo.Text.Trim()!="")
							strbuf = strbuf + " and cust_custno = '"+tbxCustNo.Text.Trim()+"'";
					}
					if(tbxCustName.Text.Trim()!="")
						strbuf = strbuf + " and cust_nm Like '%"+tbxCustName.Text.Trim()+"%'";
					dv.RowFilter = strbuf;
					if(dv.Count<=0)
					{
						lblMessage.Text="沒有訂戶資料";
						DataList1.Visible=false;
					}
					else
					{
						lblMessage.Text="找到"+dv.Count.ToString()+"筆資料";
						DataList1.Visible=true;
						DataList1.DataSource = dv;
						DataList1.DataBind();
					}
				}
			}
			else
			{
				DataSet ds = new DataSet();
				this.sqlDataAdapter2.Fill(ds, "c1_cust");
				DataView dv = ds.Tables["c1_cust"].DefaultView;
				if(tbxMfrnoSearch.Text.Trim()!="")
					strbuf = strbuf +" and cust_mfrno = '"+tbxMfrnoSearch.Text+"'";
				if (hiddenId.Value!="")
					strbuf = strbuf + " and cust_custno = '"+hiddenId.Value+"'";
				else
				{
					if(tbxCustNo.Text.Trim()!="")
						strbuf = strbuf + " and cust_custno = '"+tbxCustNo.Text.Trim()+"'";
				}
				if(tbxCustName.Text.Trim()!="")
					strbuf = strbuf + " and cust_nm Like '%"+tbxCustName.Text.Trim()+"%'";
				dv.RowFilter = strbuf;
				if(dv.Count<=0)
				{
					lblMessage.Text="沒有訂戶資料";
					DataList1.Visible=false;
				}
				else
				{
					lblMessage.Text="找到"+dv.Count.ToString()+"筆資料";
					DataList1.Visible=true;
					DataList1.DataSource = dv;
					DataList1.DataBind();
				}
			}
		}

		private void DataList1_EditCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			//Edit mode
			DataList1.EditItemIndex=e.Item.ItemIndex;
			DataList1_DataBind();
			DataSet ds1 = new DataSet();
			//show營業檔項目
			this.sqlDataAdapter4.Fill(ds1, "_btp");
			((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblbtp")).DataSource = ds1.Tables["_btp"];
			((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblbtp")).DataTextField="btp_nm";
			((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblbtp")).DataValueField="btp_btpcd";
			((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblbtp")).DataBind();
			//show領域檔項目
			this.sqlDataAdapter5.Fill(ds1, "_itp");
			((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblitp")).DataSource = ds1.Tables["_itp"];
			((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblitp")).DataTextField="itp_nm";
			((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblitp")).DataValueField="itp_itpcd";
			((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblitp")).DataBind();

			string strbtp=((TextBox)DataList1.Items[DataList1.EditItemIndex].FindControl("tbxBtpcd")).Text;
			string stritp=((TextBox)DataList1.Items[DataList1.EditItemIndex].FindControl("tbxItpcd")).Text;
			//選出營業項目
			if (strbtp.Length>0)
			{
				int j;
				for(int i=0; i<strbtp.Length;i+=2)
				{
					j=int.Parse(strbtp.Substring(i,2))-1;
					((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblbtp")).Items[j].Selected=true;
				}
			}
			//選出領域項目
			if (stritp.Length>0)
			{
				int j;
				for(int i=0; i<stritp.Length;i+=2)
				{
					j=int.Parse(stritp.Substring(i,2))-1;
					((CheckBoxList)DataList1.Items[DataList1.EditItemIndex].FindControl("cblitp")).Items[j].Selected=true;
				}
			}

		}

		private void DataList1_CancelCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			DataList1.EditItemIndex=-1;
			DataList1_DataBind();

		}

		private void DataList1_UpdateCommand(object source, System.Web.UI.WebControls.DataListCommandEventArgs e)
		{
			DateTime	date1;
			date1=System.DateTime.Today;
			string cblstr1, cblstr2;
			cblstr1=cblstr2="";
			int cblcount, i;
			DataSet ds3 = new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "mfr");
			DataView dv3 = ds3.Tables["mfr"].DefaultView;
			dv3.RowFilter="mfr_mfrno='"+((TextBox)e.Item.FindControl("tbxMfrno")).Text+"'";
			if(dv3.Count==0)
				((Label)e.Item.FindControl("lblError")).Text="無此廠商資料,請重新輸入統一編號";
			else
			{
				((Label)e.Item.FindControl("lblError")).Text="";
				cblcount=((CheckBoxList)e.Item.FindControl("cblbtp")).Items.Count;
				for(i=0; i<cblcount; i++)
				{
					if(((CheckBoxList)e.Item.FindControl("cblbtp")).Items[i].Selected)
					{
						if(i+1<10)
							cblstr1=cblstr1+"0"+(i+1).ToString();
						else 
							cblstr1=cblstr1+(i+1).ToString();
					}
				}
				cblcount=((CheckBoxList)e.Item.FindControl("cblitp")).Items.Count;
				for(i=0; i<cblcount; i++)
				{
					if(((CheckBoxList)e.Item.FindControl("cblitp")).Items[i].Selected)
					{
						if(i+1<10)
							cblstr2=cblstr2+"0"+(i+1).ToString();
						else
							cblstr2=cblstr2+(i+1).ToString();
					}
				}
				this.sqlUpdateCommand1.Parameters["@Original_cust_custno"].Value = ((Label)e.Item.FindControl("lblCustNo")).Text;
				this.sqlUpdateCommand1.Parameters["@cust_custno"].Value = ((Label)e.Item.FindControl("lblCustNo")).Text;
				this.sqlUpdateCommand1.Parameters["@cust_nm"].Value = ((TextBox)e.Item.FindControl("tbxName")).Text;
				this.sqlUpdateCommand1.Parameters["@cust_jbti"].Value = ((TextBox)e.Item.FindControl("tbxJob")).Text;
				this.sqlUpdateCommand1.Parameters["@cust_mfrno"].Value = ((TextBox)e.Item.FindControl("tbxMfrno")).Text;
				this.sqlUpdateCommand1.Parameters["@cust_tel"].Value = ((TextBox)e.Item.FindControl("tbxTel")).Text;
				this.sqlUpdateCommand1.Parameters["@cust_fax"].Value = ((TextBox)e.Item.FindControl("tbxFax")).Text;
				this.sqlUpdateCommand1.Parameters["@cust_cell"].Value = ((TextBox)e.Item.FindControl("tbxCell")).Text;
				this.sqlUpdateCommand1.Parameters["@cust_email"].Value = ((TextBox)e.Item.FindControl("tbxEmail")).Text;
				this.sqlUpdateCommand1.Parameters["@cust_regdate"].Value = ((Label)e.Item.FindControl("tbxRegdate")).Text;
				this.sqlUpdateCommand1.Parameters["@cust_btpcd"].Value = cblstr1.Trim();
				this.sqlUpdateCommand1.Parameters["@cust_itpcd"].Value = cblstr2.Trim();
				this.sqlUpdateCommand1.Parameters["@cust_moddate"].Value = date1.ToString("yyyyMMdd");;
				this.sqlUpdateCommand1.Connection.Open();
				try
				{
					this.sqlUpdateCommand1.ExecuteNonQuery();
				}
				catch(System.Data.SqlClient.SqlException ex)
				{
					Response.Write(ex.Message);
				}
				this.sqlUpdateCommand1.Connection.Close();

				DataList1.EditItemIndex=-1;
				if(Context.Request.QueryString["id"]!="")
					tbxMfrnoSearch.Text=((TextBox)e.Item.FindControl("tbxMfrno")).Text;
				DataList1_DataBind();
			}
		}

		private void DataList1_DataBind()
		{
			string	strbuf="1=1";
			DataSet ds = new DataSet();
			this.sqlDataAdapter2.Fill(ds, "c1_cust");
			DataView dv = ds.Tables["c1_cust"].DefaultView;
			if(tbxMfrnoSearch.Text.Trim()!="")
				strbuf = strbuf +" and cust_mfrno = '"+tbxMfrnoSearch.Text+"'";
			if (hiddenId.Value!="")
				strbuf = strbuf + " and cust_custno = '"+hiddenId.Value+"'";
			else
			{
				if(tbxCustNo.Text.Trim()!="")
					strbuf = strbuf + " and cust_custno = '"+tbxCustNo.Text.Trim()+"'";
			}
			if(tbxCustName.Text.Trim()!="")
				strbuf = strbuf + " and cust_nm Like '%"+tbxCustName.Text.Trim()+"%'";
			dv.RowFilter = strbuf;
			if(dv.Count<=0)
				lblMessage.Text="沒有訂戶資料";
			else
			{
				lblMessage.Text="找到"+dv.Count.ToString()+"筆資料";
				DataList1.DataSource = dv;
				DataList1.DataBind();
			}
		}

		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("NewCust.aspx?mfrno="+tbxMfrnoSearch.Text);
		}

	}
}
