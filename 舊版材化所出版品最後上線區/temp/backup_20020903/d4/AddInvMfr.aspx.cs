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

namespace MRLPub.d4
{
	/// <summary>
	/// Summary description for AddInvMfr.
	/// </summary>
	public class AddInvMfr : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxNm;
		protected System.Web.UI.WebControls.TextBox tbxJbti;
		protected System.Web.UI.WebControls.DropDownList ddlInvCd;
		protected System.Web.UI.WebControls.DropDownList ddlTaxTp;
		protected System.Web.UI.WebControls.DropDownList ddlFgItri;
		protected System.Web.UI.WebControls.TextBox tbxZip;
		protected System.Web.UI.WebControls.TextBox tbxAddr;
		protected System.Web.UI.WebControls.TextBox tbxTel;
		protected System.Web.UI.WebControls.TextBox tbxFax;
		protected System.Web.UI.WebControls.TextBox tbxCell;
		protected System.Web.UI.WebControls.TextBox tbxEmail;
		protected System.Data.SqlClient.SqlCommand sqlCmdGetImSeq;
		protected System.Web.UI.WebControls.Button btnDone;

		//private static int IMCount;
	
		public AddInvMfr()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				//IMCount = 0;
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
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdGetImSeq = new System.Data.SqlClient.SqlCommand();
			this.DataGrid1.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_DeleteCommand);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO invmfr(im_fgitri, im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbti, im_zip, im_addr, im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp) VALUES (@im_fgitri, @im_syscd, @im_contno, @im_imseq, @im_mfrno, @im_nm, @im_jbti, @im_zip, @im_addr, @im_tel, @im_fax, @im_cell, @im_email, @im_invcd, @im_taxtp)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_fgitri", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_fgitri", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_contno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_imseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_imseq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_nm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_nm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_zip", System.Data.SqlDbType.VarChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_zip", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_addr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_addr", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_tel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_fax", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_cell", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_email", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_invcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_taxtp", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-900103;packet size=4096";
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT im_imid, im_fgitri, im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbt" +
				"i, im_zip, im_addr, im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp FROM i" +
				"nvmfr";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM invmfr WHERE (im_contno = @im_contno) AND (im_imseq = @im_imseq) AND " +
				"(im_syscd = @im_syscd)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_contno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_imseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_imseq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("im_imid", "im_imid"),
																																																				new System.Data.Common.DataColumnMapping("im_fgitri", "im_fgitri"),
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
																																																				new System.Data.Common.DataColumnMapping("im_taxtp", "im_taxtp")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE invmfr SET im_fgitri = @im_fgitri, im_syscd = @im_syscd, im_contno = @im_contno, im_imseq = @im_imseq, im_mfrno = @im_mfrno, im_nm = @im_nm, im_jbti = @im_jbti, im_zip = @im_zip, im_addr = @im_addr, im_tel = @im_tel, im_fax = @im_fax, im_cell = @im_cell, im_email = @im_email, im_invcd = @im_invcd, im_taxtp = @im_taxtp WHERE (im_contno = @Original_im_contno) AND (im_imseq = @Original_im_imseq) AND (im_syscd = @Original_im_syscd)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_fgitri", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_fgitri", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_contno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_imseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_imseq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_nm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_nm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_jbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_jbti", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_zip", System.Data.SqlDbType.VarChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_zip", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_addr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_addr", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_tel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_tel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_fax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_fax", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_cell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_cell", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_email", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_email", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_invcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_taxtp", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_im_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_contno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_im_imseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_imseq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_im_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlCmdGetImSeq
			// 
			this.sqlCmdGetImSeq.CommandText = "SELECT MAX(im_imseq) AS MaxImSeq FROM invmfr GROUP BY im_contno, im_syscd HAVING " +
				"(im_syscd = \'C4\') AND (im_contno = @im_contno)";
			this.sqlCmdGetImSeq.Connection = this.sqlConnection1;
			this.sqlCmdGetImSeq.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_contno", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnDone_Click(object sender, System.EventArgs e)
		{
			LiteralControl litSubmit = new LiteralControl();
			litSubmit.Text = "<script language=\"javascript\">"+
				"doSubmit();"+
				"</script>";
			Page.Controls.Add(litSubmit);
		}

		private void BindGrid()
		{
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "IM");
			DataView dv = ds.Tables["IM"].DefaultView;
			dv.RowFilter = "im_syscd = 'C4' AND im_contno = '" + Request.QueryString["ContNo"].ToString() + "'";
			DataGrid1.DataSource = dv;
			DataGrid1.DataBind();
			//IMCount = dv.Count;
			if (dv.Count>0)
			{
				DataGrid1.Visible = true;
			}
			else
			{
				DataGrid1.Visible = false;
			}
		}

		private int GetMaxIMSeq(string GivenContNo)
		{
			int MaxSeq = 0;
			this.sqlCmdGetImSeq.Parameters["@im_contno"].Value = GivenContNo;
			this.sqlCmdGetImSeq.Connection.Open();
			try
			{
				MaxSeq = Convert.ToInt32(this.sqlCmdGetImSeq.ExecuteScalar());
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				Response.Write("GET MAX IMSEQ ERROR");
			}
			this.sqlCmdGetImSeq.Connection.Close();
			return MaxSeq;
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			int NewImSeq = GetMaxIMSeq(Request.QueryString["ContNo"].ToString())+1;
			this.sqlInsertCommand1.Parameters["@im_syscd"].Value = "C4";
			this.sqlInsertCommand1.Parameters["@im_contno"].Value = Request.QueryString["ContNo"].ToString();
			this.sqlInsertCommand1.Parameters["@im_imseq"].Value = NewImSeq.ToString("d2", null);;
			this.sqlInsertCommand1.Parameters["@im_mfrno"].Value = this.tbxMfrNo.Text;
			this.sqlInsertCommand1.Parameters["@im_nm"].Value = this.tbxNm.Text;
			this.sqlInsertCommand1.Parameters["@im_jbti"].Value = this.tbxJbti.Text;
			this.sqlInsertCommand1.Parameters["@im_zip"].Value = this.tbxZip.Text;
			this.sqlInsertCommand1.Parameters["@im_addr"].Value = this.tbxAddr.Text;
			this.sqlInsertCommand1.Parameters["@im_tel"].Value = this.tbxTel.Text;
			this.sqlInsertCommand1.Parameters["@im_fax"].Value = this.tbxFax.Text;
			this.sqlInsertCommand1.Parameters["@im_cell"].Value = this.tbxCell.Text;
			this.sqlInsertCommand1.Parameters["@im_email"].Value = this.tbxEmail.Text;
			this.sqlInsertCommand1.Parameters["@im_invcd"].Value = this.ddlInvCd.SelectedItem.Value;
			this.sqlInsertCommand1.Parameters["@im_taxtp"].Value = this.ddlTaxTp.SelectedItem.Value;
			string strfgitri = this.ddlFgItri.SelectedItem.Value;
			if (strfgitri == "00")
				strfgitri = string.Empty;
			this.sqlInsertCommand1.Parameters["@im_fgitri"].Value = strfgitri;
			
			this.sqlInsertCommand1.Connection.Open();
			bool InsSuccess = false;
			try
			{
				this.sqlInsertCommand1.ExecuteNonQuery();
				InsSuccess = true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				InsSuccess = false;
				//Response.Write(ex.Message);
			}
			this.sqlInsertCommand1.Connection.Close();

			if (InsSuccess)
			{
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>"+
					"alert(\"資料輸入成功！\");"+
					"</script>";
				Page.Controls.Add(litAlert);
				//IMCount++;
				BindGrid();
			}
			else
			{
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>"+
					"alert(\"資料輸入失敗\");"+
					"</script>";
				Page.Controls.Add(litAlert);
			}
		}

		private void DataGrid1_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			this.sqlDeleteCommand1.Parameters["@im_contno"].Value = Request.QueryString["ContNo"].ToString();
			this.sqlDeleteCommand1.Parameters["@im_imseq"].Value = e.Item.Cells[0].Text;
			this.sqlDeleteCommand1.Parameters["@im_syscd"].Value = "C4";

			bool DeleteSuccess = false;
			this.sqlDeleteCommand1.Connection.Open();
			try
			{
				this.sqlDeleteCommand1.ExecuteNonQuery();
				DeleteSuccess = true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				DeleteSuccess = false;
			}
			this.sqlDeleteCommand1.Connection.Close();

			BindGrid();
		}
	}
}
