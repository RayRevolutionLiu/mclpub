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
	/// Summary description for search_label.
	/// </summary>
	public class search_label : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.ImageButton ImageButton1;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.DropDownList ddlMosea;
		protected System.Web.UI.WebControls.DropDownList ddlMailType;
		protected System.Web.UI.WebControls.DropDownList ddlBookType;
		protected System.Web.UI.WebControls.DropDownList ddlYear;
		protected System.Web.UI.WebControls.DropDownList ddlMonth;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox tbxBookNo;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.DropDownList ddlOrderType1;
		protected System.Web.UI.WebControls.DropDownList ddlOrderType2;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button btnPrintLabel;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.DropDownList ddlMnt;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		string	str1;
		public search_label()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			if (!IsPostBack)
			{
				int myYear=System.DateTime.Today.Year;
				int j=0;
				for(int i=1987; i<=myYear; i++)
				{
					ddlYear.Items.Add(new ListItem(i.ToString(),i.ToString()));
					j++;
				}
				ddlYear.SelectedIndex=j-1;
				int myMonth=System.DateTime.Today.Month;
				ddlMonth.SelectedIndex=myMonth-1;
				//郵寄類別
				DataSet	ds1=new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "mtp");
				DataView dv1 = ds1.Tables["mtp"].DefaultView;
				if(ddlMosea.SelectedItem.Value=="0")
					dv1.RowFilter="mtp_mtpcd LIKE '1%'";
				else
					dv1.RowFilter="mtp_mtpcd LIKE '2%'";
				ddlMailType.DataSource=dv1;
				ddlMailType.DataTextField="mtp_nm";
				ddlMailType.DataValueField="mtp_mtpcd";
				ddlMailType.DataBind();
				//書籍類別
				DataSet	ds2=new DataSet();
				this.sqlDataAdapter2.Fill(ds2, "c1_obtp");
				DataView dv2 = ds2.Tables["c1_obtp"].DefaultView;
				dv2.RowFilter="obtp_otp1cd='"+ddlOrderType1.SelectedItem.Value+"'";
				ddlBookType.DataSource=dv2;
				ddlBookType.DataTextField="obtp_obtpnm";
				ddlBookType.DataValueField="obtp_obtpcd";
				ddlBookType.DataBind();
				//訂購類別二
				DataSet	ds3=new DataSet();
				this.sqlDataAdapter3.Fill(ds3, "c1_otp");
				DataView dv3 = ds3.Tables["c1_otp"].DefaultView;
				dv3.RowFilter="otp_otp1cd='"+ddlOrderType1.SelectedItem.Value+"'";
				ddlOrderType2.DataSource=dv3;
				ddlOrderType2.DataTextField="otp_otp2nm";
				ddlOrderType2.DataValueField="otp_otp2cd";
				ddlOrderType2.DataBind();
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
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.ddlMosea.SelectedIndexChanged += new System.EventHandler(this.ddlMosea_SelectedIndexChanged);
			this.ddlOrderType1.SelectedIndexChanged += new System.EventHandler(this.ddlOrderType1_SelectedIndexChanged);
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnPrintLabel.Click += new System.EventHandler(this.btnPrintLabel_Click);
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO dbo.c1_otp(otp_otp1cd, otp_otp1nm, otp_otp2cd, otp_otp2nm) VALUES (@otp_otp1cd, @otp_otp1nm, @otp_otp2cd, @otp_otp2nm); SELECT otp_otpid, otp_otp1cd, otp_otp1nm, otp_otp2cd, otp_otp2nm FROM dbo.c1_otp WHERE (otp_otp1cd = @Select_otp_otp1cd) AND (otp_otp2cd = @Select_otp_otp2cd)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp_otp1nm", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp1nm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp_otp2cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp2cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp_otp2nm", System.Data.SqlDbType.Char, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp2nm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_otp_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_otp_otp2cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp2cd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM1;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=03212-840695;packet size=4096";
			this.sqlConnection1.ConnectionString = ConfigurationSettings.AppSettings["mrlpub2"].ToString();
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM dbo.c1_otp WHERE (otp_otp1cd = @otp_otp1cd) AND (otp_otp2cd = @otp_ot" +
				"p2cd) AND (otp_otp1nm = @otp_otp1nm) AND (otp_otp2nm = @otp_otp2nm) AND (otp_otp" +
				"id = @otp_otpid)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp_otp2cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp2cd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp_otp1nm", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp1nm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp_otp2nm", System.Data.SqlDbType.Char, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp2nm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp_otpid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otpid", System.Data.DataRowVersion.Original, null));
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "dbo.sp_tmp_001";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mtpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@btpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@maildate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter3.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_otp", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("otp_otpid", "otp_otpid"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp1cd", "otp_otp1cd"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp1nm", "otp_otp1nm"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp2cd", "otp_otp2cd"),
																																																				new System.Data.Common.DataColumnMapping("otp_otp2nm", "otp_otp2nm")})});
			this.sqlDataAdapter3.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT otp_otpid, otp_otp1cd, otp_otp1nm, otp_otp2cd, otp_otp2nm FROM dbo.c1_otp";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.c1_otp SET otp_otp1cd = @otp_otp1cd, otp_otp1nm = @otp_otp1nm, otp_otp2cd = @otp_otp2cd, otp_otp2nm = @otp_otp2nm WHERE (otp_otp1cd = @Original_otp_otp1cd) AND (otp_otp2cd = @Original_otp_otp2cd) AND (otp_otp1nm = @Original_otp_otp1nm) AND (otp_otp2nm = @Original_otp_otp2nm); SELECT otp_otpid, otp_otp1cd, otp_otp1nm, otp_otp2cd, otp_otp2nm FROM dbo.c1_otp WHERE (otp_otp1cd = @Select_otp_otp1cd) AND (otp_otp2cd = @Select_otp_otp2cd)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp_otp1nm", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp1nm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp_otp2cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp2cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp_otp2nm", System.Data.SqlDbType.Char, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp2nm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_otp_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_otp_otp2cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp2cd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_otp_otp1nm", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp1nm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_otp_otp2nm", System.Data.SqlDbType.Char, 20, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp2nm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_otp_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_otp_otp2cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "otp_otp2cd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_obtp", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpid", "obtp_obtpid"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_otp1cd", "obtp_otp1cd"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpcd", "obtp_obtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpnm", "obtp_obtpnm")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT obtp_obtpid, obtp_otp1cd, obtp_obtpcd, obtp_obtpnm FROM dbo.c1_obtp";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT mtp_mtpid, mtp_mtpcd, mtp_nm FROM dbo.mtp";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "tmp_label1", new System.Data.Common.DataColumnMapping[] {
																																																					new System.Data.Common.DataColumnMapping("od_odid", "od_odid"),
																																																					new System.Data.Common.DataColumnMapping("nostr", "nostr"),
																																																					new System.Data.Common.DataColumnMapping("od_oditem", "od_oditem"),
																																																					new System.Data.Common.DataColumnMapping("datestr", "datestr"),
																																																					new System.Data.Common.DataColumnMapping("ra_mnt", "ra_mnt"),
																																																					new System.Data.Common.DataColumnMapping("ra_mtpcd", "ra_mtpcd"),
																																																					new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm"),
																																																					new System.Data.Common.DataColumnMapping("obtp_obtpnm", "obtp_obtpnm"),
																																																					new System.Data.Common.DataColumnMapping("ra_oritem", "ra_oritem"),
																																																					new System.Data.Common.DataColumnMapping("o_otp2cd", "o_otp2cd")})});
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = @"SELECT dbo.tmp_label1.od_odid, dbo.tmp_label1.od_syscd + dbo.tmp_label1.od_custno + dbo.tmp_label1.od_otp1cd + dbo.tmp_label1.od_otp1seq AS nostr, dbo.tmp_label1.od_oditem, dbo.tmp_label1.od_sdate + '~' + dbo.tmp_label1.od_edate AS datestr, dbo.tmp_label1.ra_mnt, dbo.tmp_label1.ra_mtpcd, dbo.tmp_label1.mtp_nm, dbo.tmp_label1.obtp_obtpnm, dbo.tmp_label1.ra_oritem, dbo.c1_order.o_otp2cd, dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_order.o_syscd FROM dbo.tmp_label1 INNER JOIN dbo.c1_order ON dbo.tmp_label1.od_syscd = dbo.c1_order.o_syscd AND dbo.tmp_label1.od_custno = dbo.c1_order.o_custno AND dbo.tmp_label1.od_otp1cd = dbo.c1_order.o_otp1cd AND dbo.tmp_label1.od_otp1seq = dbo.c1_order.o_otp1seq";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mtp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mtp_mtpid", "mtp_mtpid"),
																																																			 new System.Data.Common.DataColumnMapping("mtp_mtpcd", "mtp_mtpcd"),
																																																			 new System.Data.Common.DataColumnMapping("mtp_nm", "mtp_nm")})});
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, s" +
				"rspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			this.sqlCommand1.Parameters["@syscd"].Value="C1";
			this.sqlCommand1.Parameters["@otp1cd"].Value=ddlOrderType1.SelectedItem.Value;
			this.sqlCommand1.Parameters["@mtpcd"].Value=ddlMailType.SelectedItem.Value;
			this.sqlCommand1.Parameters["@btpcd"].Value=ddlBookType.SelectedItem.Value;
			this.sqlCommand1.Parameters["@maildate"].Value=ddlYear.SelectedItem.Value.Trim()+ddlMonth.SelectedItem.Value.Trim();
			this.sqlCommand1.Connection.Open();
			SqlDataReader myReader=this.sqlCommand1.ExecuteReader();
			myReader.Read();
			myReader.Close();
			this.sqlCommand1.Connection.Close();
			DataSet	ds4=new DataSet();
			this.sqlDataAdapter4.Fill(ds4, "tmp_label1");
			DataView dv4 = ds4.Tables["tmp_label1"].DefaultView;
			string strbuf="o_otp2cd="+ddlOrderType2.SelectedItem.Value;
			if (ddlMnt.SelectedItem.Value=="0")//5本以上(不含5本)
				strbuf+=" and ra_mnt>5";
			else
				strbuf+=" and ra_mnt="+ddlMnt.SelectedItem.Value;
			dv4.RowFilter=strbuf;
			lblMessage.Text="查詢到"+dv4.Count.ToString()+"筆資料";
			DataGrid1.DataSource=dv4;
			DataGrid1.DataBind();
		}

		private void ddlMosea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			DataSet	ds1=new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "mtp");
			DataView dv1 = ds1.Tables["mtp"].DefaultView;
			if(ddlMosea.SelectedItem.Value=="0")
				dv1.RowFilter="mtp_mtpcd LIKE '1%'";
			else
				dv1.RowFilter="mtp_mtpcd LIKE '2%'";
			ddlMailType.DataSource=dv1;
			ddlMailType.DataTextField="mtp_nm";
			ddlMailType.DataValueField="mtp_mtpcd";
			ddlMailType.DataBind();

		}

		private void ddlOrderType1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			//書籍類別
			DataSet	ds2=new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "c1_obtp");
			DataView dv2 = ds2.Tables["c1_obtp"].DefaultView;
			dv2.RowFilter="obtp_otp1cd='"+ddlOrderType1.SelectedItem.Value+"'";
			ddlBookType.DataSource=dv2;
			ddlBookType.DataTextField="obtp_obtpnm";
			ddlBookType.DataValueField="obtp_obtpcd";
			ddlBookType.DataBind();
			//訂購類別二
			DataSet	ds3=new DataSet();
			this.sqlDataAdapter3.Fill(ds3, "c1_otp");
			DataView dv3 = ds3.Tables["c1_otp"].DefaultView;
			dv3.RowFilter="otp_otp1cd='"+ddlOrderType1.SelectedItem.Value+"'";
			ddlOrderType2.DataSource=dv3;
			ddlOrderType2.DataTextField="otp_otp2nm";
			ddlOrderType2.DataValueField="otp_otp2cd";
			ddlOrderType2.DataBind();
			if(ddlOrderType1.SelectedItem.Value=="09")
			{
				ddlYear.Enabled=false;
				ddlMonth.Enabled=false;
			}
			else
			{
				ddlYear.Enabled=true;
				ddlMonth.Enabled=true;
			}
		}

		private void btnPrintLabel_Click(object sender, System.EventArgs e)
		{
			string	strbuf;
			strbuf="label.aspx?type2="+ddlOrderType2.SelectedItem.Value+"&mosea="+ddlMosea.SelectedItem.Value
					+"&book="+tbxBookNo.Text+"&mnt="+ddlMnt.SelectedItem.Value;
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}

		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			string	strbuf;
			string reg=User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
			DataSet	ds5=new DataSet();
			this.sqlDataAdapter5.Fill(ds5, "srspn");
			DataView dv5 = ds5.Tables["srspn"].DefaultView;
			dv5.RowFilter="srspn_empno = '"+reg+"'";
			if(dv5.Count>=0)
			{
				string	cname=dv5[0].Row["srspn_cname"].ToString().Trim();
				strbuf="mail_list1.aspx?type2="+ddlOrderType2.SelectedItem.Value
					+"&mnt="+ddlMnt.SelectedItem.Value+"&cname="+cname;
				Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
			}
		}
	}
}
