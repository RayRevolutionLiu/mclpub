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
	/// Summary description for QueryHisCont.
	/// </summary>
	public class QueryHisCont : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Button btnAddNew;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		public QueryHisCont()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-900103;packet size=4096";
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT cont_contid, cont_syscd, cont_contno, cont_custno, cont_conttp, cont_bkcd, cont_signdate, cont_sdate, cont_edate, cont_empno, cont_mfrno, cont_pubcate, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_disc, cont_freetm, cont_tottm, cont_pubtm, cont_resttm, cont_totamt, cont_paidamt, cont_restamt, cont_ccont, cont_csdate, cont_atp, cont_matp, cont_irnm, cont_iraddr, cont_irzip, cont_irtel, cont_irfax, cont_ircell, cont_iremail, cont_fgclosed, cont_adremark, cont_pdcont, cont_moddate, cont_invcd, cont_taxtp, cont_fgitri, cont_xmldata FROM c4_cont";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c4_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_contid", "cont_contid"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubcate", "cont_pubcate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aufax", "cont_aufax"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aucell", "cont_aucell"),
																																																				 new System.Data.Common.DataColumnMapping("cont_auemail", "cont_auemail"),
																																																				 new System.Data.Common.DataColumnMapping("cont_disc", "cont_disc"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freetm", "cont_freetm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubtm", "cont_pubtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_resttm", "cont_resttm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_ccont", "cont_ccont"),
																																																				 new System.Data.Common.DataColumnMapping("cont_csdate", "cont_csdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_atp", "cont_atp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_matp", "cont_matp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_irnm", "cont_irnm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_iraddr", "cont_iraddr"),
																																																				 new System.Data.Common.DataColumnMapping("cont_irzip", "cont_irzip"),
																																																				 new System.Data.Common.DataColumnMapping("cont_irtel", "cont_irtel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_irfax", "cont_irfax"),
																																																				 new System.Data.Common.DataColumnMapping("cont_ircell", "cont_ircell"),
																																																				 new System.Data.Common.DataColumnMapping("cont_iremail", "cont_iremail"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_adremark", "cont_adremark"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pdcont", "cont_pdcont"),
																																																				 new System.Data.Common.DataColumnMapping("cont_moddate", "cont_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_invcd", "cont_invcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_taxtp", "cont_taxtp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgitri", "cont_fgitri"),
																																																				 new System.Data.Common.DataColumnMapping("cont_xmldata", "cont_xmldata")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void BindGrid()
		{
			DataView qdv = (DataView)Session["QDV"];
			int i = Int32.Parse(Request.QueryString["SelectedCust"]);

			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "HisCont");
			DataView dv = ds.Tables["HisCont"].DefaultView;
			dv.RowFilter = "cont_custno = '" + qdv[i]["cust_custno"].ToString() + "'";

			if (dv.Count>0)
			{
				DataGrid1.DataSource = dv;
				DataGrid1.DataBind();
				Session.Add("HCDV", dv);
			}
			else
			{
				this.btnAddNew.Text = "查無歷史合約，按此繼續新增合約";
				DataGrid1.Visible = false;
			}
		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//Response.Write("你選擇的是"+DataGrid1.SelectedItem.Cells[1].Text);
			Response.Redirect("AdCont.aspx?HisCont=1&SelectedCust="+ Int32.Parse(Request.QueryString["SelectedCust"])+"&SelectedHisCont="+DataGrid1.SelectedIndex.ToString());
		}

		private void btnAddNew_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("AdCont.aspx?HisCont=0&SelectedCust="+ Int32.Parse(Request.QueryString["SelectedCust"]));
		}
	}
}
