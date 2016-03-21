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
	/// Summary description for SelectCont.
	/// </summary>
	public class SelectCont : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxMfrName;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Web.UI.WebControls.LinkButton lnbQuery;
		protected System.Web.UI.WebControls.LinkButton lnbAddMfr;
		protected System.Web.UI.WebControls.LinkButton lnbAddCust;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		public SelectCont()
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
			this.lnbQuery.Click += new System.EventHandler(this.lnbQuery_Click);
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-900103;packet size=4096";
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "cust", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																			  new System.Data.Common.DataColumnMapping("cust_oldcustno", "cust_oldcustno"),
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
																																																			  new System.Data.Common.DataColumnMapping("cust_btpcd", "cust_btpcd"),
																																																			  new System.Data.Common.DataColumnMapping("cust_rtpcd", "cust_rtpcd"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_tel", "mfr_tel"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_fax", "mfr_fax"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_regdate", "mfr_regdate")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT cust.cust_custid, cust.cust_oldcustno, cust.cust_custno, cust.cust_nm, cust.cust_jbti, cust.cust_mfrno, cust.cust_tel, cust.cust_fax, cust.cust_cell, cust.cust_email, cust.cust_regdate, cust.cust_moddate, cust.cust_itpcd, cust.cust_btpcd, cust.cust_rtpcd, mfr.mfr_mfrid, mfr.mfr_mfrno, mfr.mfr_inm, mfr.mfr_iaddr, mfr.mfr_izip, mfr.mfr_respnm, mfr.mfr_respjbti, mfr.mfr_tel, mfr.mfr_fax, mfr.mfr_regdate FROM cust INNER JOIN mfr ON cust.cust_mfrno = mfr.mfr_mfrno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT cont_contid, cont_syscd, cont_contno, cont_custno, cont_conttp, cont_bkcd, cont_signdate, cont_sdate, cont_edate, cont_empno, cont_mfrno, cont_pubcate, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_disc, cont_freetm, cont_tottm, cont_pubtm, cont_resttm, cont_totamt, cont_paidamt, cont_restamt, cont_ccont, cont_csdate, cont_atp, cont_matp, cont_irnm, cont_iraddr, cont_irzip, cont_irtel, cont_irfax, cont_ircell, cont_iremail, cont_fgclosed, cont_adremark, cont_pdcont, cont_moddate, cont_invcd, cont_taxtp, cont_fgitri, cont_xmldata FROM c4_cont";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnbQuery_Click(object sender, System.EventArgs e)
		{
			string strFilter = "1=1";

			if (this.tbxMfrName.Text !=null && this.tbxMfrName.Text != "")
				strFilter += " AND mfr_inm LIKE '%" + this.tbxMfrName.Text + "%'";

			if (this.tbxMfrNo.Text !=null && this.tbxMfrNo.Text != "")
				strFilter += " AND mfr_mfrno LIKE '%" + this.tbxMfrNo.Text + "%'";

			if (this.tbxCustName.Text !=null && this.tbxCustName.Text != "")
				strFilter += " AND cust_nm LIKE '%" + this.tbxCustName.Text + "%'";

			if (this.tbxCustNo.Text !=null && this.tbxCustNo.Text != "")
				strFilter += " AND cust_custno LIKE '%" + this.tbxCustNo.Text + "%'";

			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "mfrcust");
			DataView dv = ds.Tables["mfrcust"].DefaultView;

			dv.RowFilter = strFilter;

			//合約部分

			if (dv.Count > 0)
			{
				//不應該這麼用
//				if (dv.Count > 1)
//				{
//					Response.Write("有兩筆以上的資料，請重新查詢");
//				}
//				else
//				{
//					DataSet dscont = new DataSet();
//					this.sqlDataAdapter2.Fill(dscont, "CONT");
//					DataView dvcont = dscont.Tables["CONT"].DefaultView;
//					dvcont.RowFilter = "cont_custno = '" + dv[0]["cust_custno"].ToString() + "' AND cont_mfrno = '" + dv[0]["mfr_mfrno"].ToString() + "'";
//
//					if (dvcont.Count > 0)
//					{
//						DataGrid1.DataSource = dvcont;
//						DataGrid1.DataBind();
//					}
//					else
//					{
//						Response.Write("查無符合此條件的合約");
//					}
//				}

				//ver2
				DataSet dscont = new DataSet();
				this.sqlDataAdapter2.Fill(dscont, "CONT");
				DataView dvcont = dscont.Tables["CONT"].DefaultView;

				string strRowFilter = "cont_custno = '" + dv[0]["cust_custno"].ToString() + "'";
				for (int i=1; i<dv.Count; i++)
				{
					strRowFilter += " OR cont_custno = '" + dv[i]["cust_custno"].ToString() + "'";
				}

				dvcont.RowFilter = strRowFilter;

				if (dvcont.Count > 0)
				{
					DataGrid1.DataSource = dvcont;
					DataGrid1.DataBind();
				}
				else
				{
					Response.Write("查無符合此條件的合約");
				}
			}

			//Session.Add("QDV", dv);
		}

		private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//DataView dv = (DataView)Session["QDV"];
			//Response.Redirect("AdCont.aspx?SelectedCust=" + DataGrid1.SelectedIndex.ToString());
		}
	}
}
