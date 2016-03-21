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
	/// Summary description for AppriseFilter.
	/// </summary>
	public class AppriseFilter : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlMosea;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DropDownList ddlBookType;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlYear1;
		protected System.Web.UI.WebControls.DropDownList ddlMonth1;
		protected System.Web.UI.WebControls.DropDownList ddlYear2;
		protected System.Web.UI.WebControls.DropDownList ddlMonth2;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Web.UI.WebControls.Button btnPrintLabel;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Label Label6;
	
		public AppriseFilter()
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
				for(int i=myYear-3; i<=myYear+1; i++)
				{
					ddlYear1.Items.Add(new ListItem(i.ToString(),i.ToString()));
					ddlYear2.Items.Add(new ListItem(i.ToString(),i.ToString()));
					j++;
				}
				ddlYear1.SelectedIndex=j-2;
				ddlYear2.SelectedIndex=j-2;
				int myMonth=System.DateTime.Today.Month;
				ddlMonth1.SelectedIndex=myMonth-1;
				ddlMonth2.SelectedIndex=myMonth-1;
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
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.ddlType.SelectedIndexChanged += new System.EventHandler(this.ddlType_SelectedIndexChanged);
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnPrintLabel.Click += new System.EventHandler(this.btnPrintLabel_Click);
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT srspn_id, srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, s" +
				"rspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "dbo.sp_tmp_003";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@btpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@sdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@edate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
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
																																																					new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																					new System.Data.Common.DataColumnMapping("or_custno", "or_custno"),
																																																					new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																					new System.Data.Common.DataColumnMapping("or_otp1cd", "or_otp1cd"),
																																																					new System.Data.Common.DataColumnMapping("or_otp1seq", "or_otp1seq"),
																																																					new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.tmp_label1.od_odid, dbo.tmp_label1.od_syscd + dbo.tmp_label1.od_custno + dbo.tmp_label1.od_otp1cd + dbo.tmp_label1.od_otp1seq AS nostr, dbo.tmp_label1.od_oditem, dbo.tmp_label1.od_sdate + '~' + dbo.tmp_label1.od_edate AS datestr, dbo.tmp_label1.ra_mnt, dbo.tmp_label1.ra_mtpcd, dbo.tmp_label1.mtp_nm, dbo.tmp_label1.obtp_obtpnm, dbo.tmp_label1.ra_oritem, dbo.c1_or.or_fgmosea, dbo.c1_or.or_custno, dbo.c1_or.or_oritem, dbo.c1_or.or_otp1cd, dbo.c1_or.or_otp1seq, dbo.c1_or.or_syscd FROM dbo.tmp_label1 INNER JOIN dbo.c1_or ON dbo.tmp_label1.od_syscd = dbo.c1_or.or_syscd AND dbo.tmp_label1.od_custno = dbo.c1_or.or_custno AND dbo.tmp_label1.od_otp1cd = dbo.c1_or.or_otp1cd AND dbo.tmp_label1.od_otp1seq = dbo.c1_or.or_otp1seq ORDER BY dbo.tmp_label1.od_syscd + dbo.tmp_label1.od_custno + dbo.tmp_label1.od_otp1cd + dbo.tmp_label1.od_otp1seq";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ddlType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			int myMonth=System.DateTime.Today.Month;
			int myYear=System.DateTime.Today.Year;
			int j=0;
			for(int i=myYear-3; i<=myYear+1; i++)
			{
				ddlYear1.Items.Add(new ListItem(i.ToString(),i.ToString()));
				ddlYear2.Items.Add(new ListItem(i.ToString(),i.ToString()));
				j++;
			}
			ddlYear1.SelectedIndex=j-2;
			ddlYear2.SelectedIndex=j-2;
			if (ddlType.SelectedItem.Value=="0")		//到期
			{
				ddlMonth1.SelectedIndex=myMonth-1;
				ddlMonth2.SelectedIndex=myMonth-1;
			}
			else if (ddlType.SelectedItem.Value=="1")	//即將到期
			{
				if(myMonth==12)
				{
					ddlYear1.SelectedIndex=ddlYear1.SelectedIndex+1;
					ddlYear2.SelectedIndex=ddlYear2.SelectedIndex+1;
					ddlMonth1.SelectedIndex=0;
					ddlMonth2.SelectedIndex=0;
				}
				else
				{
					ddlMonth1.SelectedIndex=myMonth;
					ddlMonth2.SelectedIndex=myMonth;
				}
			}

		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			this.sqlCommand1.Parameters["@syscd"].Value="C1";
			this.sqlCommand1.Parameters["@otp1cd"].Value="01";
			this.sqlCommand1.Parameters["@btpcd"].Value=ddlBookType.SelectedItem.Value;
			this.sqlCommand1.Parameters["@sdate"].Value=ddlYear1.SelectedItem.Value.Trim()+ddlMonth1.SelectedItem.Value.Trim();
			this.sqlCommand1.Parameters["@edate"].Value=ddlYear2.SelectedItem.Value.Trim()+ddlMonth2.SelectedItem.Value.Trim();
			this.sqlCommand1.Connection.Open();
			SqlDataReader myReader=this.sqlCommand1.ExecuteReader();
			myReader.Read();
			myReader.Close();
			this.sqlCommand1.Connection.Close();
			DataSet	ds1=new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "tmp_label1");
			DataView dv1 = ds1.Tables["tmp_label1"].DefaultView;
			dv1.RowFilter="or_fgmosea='"+ddlMosea.SelectedItem.Value+"'";
			lblMessage.Text="查詢到"+dv1.Count.ToString()+"筆資料";
			DataGrid1.DataSource=dv1;
			DataGrid1.DataBind();
		}

		private void btnPrintLabel_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			string	strbuf;
			strbuf="appriselabel.aspx?type="+ddlType.SelectedItem.Value+"&mosea="+ddlMosea.SelectedItem.Value;
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";

		}

		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			string	strbuf;
			string reg=User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
			DataSet	ds2=new DataSet();
			this.sqlDataAdapter2.Fill(ds2, "srspn");
			DataView dv2 = ds2.Tables["srspn"].DefaultView;
			dv2.RowFilter="srspn_empno = '"+reg+"'";
			if(dv2.Count>=0)
			{
				string	cname=dv2[0].Row["srspn_cname"].ToString().Trim();
				strbuf="mail_list2.aspx?mosea="+ddlMosea.SelectedItem.Value+"&cname="+cname;
				Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
			}

		}

	}
}
