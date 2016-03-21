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

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for SpecialFM.
	/// </summary>
	public class SpecialFM : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.TextBox tbxInvno;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button btnDelete;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenIano;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddentype1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenseq;
		protected System.Web.UI.WebControls.Label lblMessage;
	
		public SpecialFM()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "ia", new System.Data.Common.DataColumnMapping[] {
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
																																																			new System.Data.Common.DataColumnMapping("nostr", "nostr"),
																																																			new System.Data.Common.DataColumnMapping("o_date", "o_date"),
																																																			new System.Data.Common.DataColumnMapping("datestr", "datestr"),
																																																			new System.Data.Common.DataColumnMapping("od_btpcd", "od_btpcd"),
																																																			new System.Data.Common.DataColumnMapping("obtp_obtpnm", "obtp_obtpnm"),
																																																			new System.Data.Common.DataColumnMapping("obtp_obtpcd", "obtp_obtpcd"),
																																																			new System.Data.Common.DataColumnMapping("obtp_otp1cd", "obtp_otp1cd"),
																																																			new System.Data.Common.DataColumnMapping("od_custno", "od_custno"),
																																																			new System.Data.Common.DataColumnMapping("od_oditem", "od_oditem"),
																																																			new System.Data.Common.DataColumnMapping("od_otp1cd", "od_otp1cd"),
																																																			new System.Data.Common.DataColumnMapping("od_otp1seq", "od_otp1seq"),
																																																			new System.Data.Common.DataColumnMapping("od_syscd", "od_syscd"),
																																																			new System.Data.Common.DataColumnMapping("o_custno", "o_custno"),
																																																			new System.Data.Common.DataColumnMapping("o_otp1cd", "o_otp1cd"),
																																																			new System.Data.Common.DataColumnMapping("o_otp1seq", "o_otp1seq"),
																																																			new System.Data.Common.DataColumnMapping("o_syscd", "o_syscd")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.ia.ia_iaid, dbo.ia.ia_syscd, dbo.ia.ia_iasdate, dbo.ia.ia_iasseq, dbo.ia.ia_iaitem, dbo.ia.ia_iano, dbo.ia.ia_refno, dbo.ia.ia_mfrno, dbo.ia.ia_pyno, dbo.ia.ia_pyseq, dbo.ia.ia_pyat, dbo.ia.ia_ivat, dbo.ia.ia_invno, dbo.ia.ia_invdate, dbo.ia.ia_fgitri, dbo.ia.ia_rnm, dbo.ia.ia_raddr, dbo.ia.ia_rzip, dbo.ia.ia_rjbti, dbo.ia.ia_rtel, dbo.ia.ia_fgnonauto, dbo.ia.ia_invcd, dbo.ia.ia_taxtp, dbo.ia.ia_status, dbo.ia.ia_cname, dbo.ia.ia_tel, dbo.ia.ia_contno, dbo.c1_order.o_syscd + dbo.c1_order.o_custno + dbo.c1_order.o_otp1cd + dbo.c1_order.o_otp1seq AS nostr, dbo.c1_order.o_date, dbo.c1_od.od_sdate + '~' + dbo.c1_od.od_edate AS datestr, dbo.c1_od.od_btpcd, dbo.c1_obtp.obtp_obtpnm, dbo.c1_obtp.obtp_obtpcd, dbo.c1_obtp.obtp_otp1cd, dbo.c1_od.od_custno, dbo.c1_od.od_oditem, dbo.c1_od.od_otp1cd, dbo.c1_od.od_otp1seq, dbo.c1_od.od_syscd, dbo.c1_order.o_custno, dbo.c1_order.o_otp1cd, dbo.c1_order.o_otp1seq, dbo.c1_order.o_syscd FROM dbo.ia INNER JOIN dbo.c1_order ON dbo.ia.ia_syscd = dbo.c1_order.o_syscd AND dbo.ia.ia_iano = dbo.c1_order.o_iano INNER JOIN dbo.c1_od ON dbo.c1_order.o_syscd = dbo.c1_od.od_syscd AND dbo.c1_order.o_custno = dbo.c1_od.od_custno AND dbo.c1_order.o_otp1cd = dbo.c1_od.od_otp1cd AND dbo.c1_order.o_otp1seq = dbo.c1_od.od_otp1seq INNER JOIN dbo.c1_obtp ON dbo.c1_od.od_otp1cd = dbo.c1_obtp.obtp_otp1cd AND dbo.c1_od.od_btpcd = dbo.c1_obtp.obtp_obtpcd";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "UPDATE dbo.c1_order SET o_modstatus = @modstatus, o_moduid = @moduid WHERE (o_ian" +
				"o = @iano) AND (o_syscd = \'C1\')";
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@modstatus", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_modstatus", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@moduid", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_moduid", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_iano", System.Data.DataRowVersion.Current, null));
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			DataGrid1.Visible=false;
			btnDelete.Visible=false;
			bool	flag1=true;
			lblMessage.Text="";
			if(tbxInvno.Text.Trim()=="")
				lblMessage.Text="<<請輸入發票號碼>>";
			else
			{
				DataSet ds1 = new DataSet();
				this.sqlDataAdapter1.Fill(ds1, "ia");
				DataView dv1 = ds1.Tables["ia"].DefaultView;
				dv1.RowFilter="ia_invno='"+tbxInvno.Text.Trim()+"'";
				if(dv1.Count<=0)
					lblMessage.Text="<<查無此發票號碼>>";
				else
				{
					if(dv1[0].Row["ia_pyno"].ToString().Trim()!="")
					{
						hiddenIano.Value=dv1[0].Row["ia_iano"].ToString().Trim();
						hiddenid.Value=dv1[0].Row["o_custno"].ToString().Trim();
						hiddentype1.Value=dv1[0].Row["o_otp1cd"].ToString().Trim();
						hiddenseq.Value=dv1[0].Row["o_otp1seq"].ToString().Trim();
						DataGrid1.Visible=true;
						DataGrid1.DataSource=dv1;
						DataGrid1.DataBind();
						btnDelete.Visible=true;
					}
					else
						lblMessage.Text="<<此發票尚未繳款請利用[註銷發票]處理!!>>";
				}
			}
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			string reg=User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
			this.sqlCommand1.Parameters["@iano"].Value=hiddenIano.Value.Trim();
			this.sqlCommand1.Parameters["@modstatus"].Value="3";
			this.sqlCommand1.Parameters["@moduid"].Value=reg;
			this.sqlCommand1.Connection.Open();
			this.sqlCommand1.ExecuteNonQuery();
			this.sqlCommand1.Connection.Close();
			Response.Redirect("S_OrderFM.aspx?id="+hiddenid.Value+"&type1="+hiddentype1.Value+"&seq="+hiddenseq.Value);
		}
	}
}
