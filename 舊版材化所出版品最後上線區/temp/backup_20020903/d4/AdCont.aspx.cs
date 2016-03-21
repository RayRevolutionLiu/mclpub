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
	/// Summary description for AdCont.
	/// </summary>
	public class AdCont : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxMfrName;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Web.UI.WebControls.TextBox tbxCustTel;
		protected System.Web.UI.WebControls.TextBox tbxCustTitle;
		protected System.Web.UI.WebControls.TextBox tbxContSignDate;
		protected System.Web.UI.WebControls.DropDownList ddlContTp;
		protected System.Web.UI.WebControls.TextBox tbxContSDate;
		protected System.Web.UI.WebControls.TextBox tbxContEDate;
		protected System.Web.UI.WebControls.DropDownList ddlPubCate;
		protected System.Web.UI.WebControls.TextBox tbxContEmp;
		protected System.Web.UI.WebControls.TextBox tbxAuName;
		protected System.Web.UI.WebControls.TextBox tbxAuTel;
		protected System.Web.UI.WebControls.TextBox tbxAuCell;
		protected System.Web.UI.WebControls.TextBox tbxAuFax;
		protected System.Web.UI.WebControls.TextBox tbxAuEmail;
		protected System.Web.UI.WebControls.TextBox tbxContPubTm;
		protected System.Web.UI.WebControls.TextBox tbxContFreeTm;
		protected System.Web.UI.WebControls.TextBox tbxContTotTm;
		protected System.Web.UI.WebControls.TextBox tbxContTotAmt;
		protected System.Web.UI.WebControls.TextBox tbxContDisc;
		protected System.Web.UI.WebControls.TextBox tbxContPaidAmt;
		protected System.Web.UI.WebControls.TextBox tbxIrName;
		protected System.Web.UI.WebControls.TextBox tbxIrTel;
		protected System.Web.UI.WebControls.TextBox tbxIrAddr;
		protected System.Web.UI.WebControls.TextBox tbxIrZip;
		protected System.Web.UI.WebControls.TextBox tbxCCont;
		protected System.Web.UI.WebControls.TextBox tbxCsDate;
		protected System.Web.UI.WebControls.TextBox tbxAdRemark;
		protected System.Web.UI.WebControls.TextBox tbxPdCont;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Web.UI.WebControls.TextBox tbxIrCell;
		protected System.Web.UI.WebControls.TextBox tbxIrEmail;
		protected System.Web.UI.WebControls.TextBox tbxIrFax;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Button btnRefresh;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidcond;
		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Web.UI.WebControls.Button btnRefIM;
		protected System.Web.UI.WebControls.Button btnRefAdr;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.Button btnRefBk;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Web.UI.WebControls.Button btnRefFreeBk;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlInsCmdIA;
		protected System.Data.SqlClient.SqlCommand sqlInsCmdIAD;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidInvMfrCount;
		protected System.Web.UI.WebControls.Button btnSave;
		//private static int lc;
	
		public AdCont()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				if (Request.QueryString["HisCont"]!=null)
				{
					if (Request.QueryString["HisCont"].ToString() == "1")
					{
						//如果有歷史訂單的話
						this.LoadHistoryCont();
					}
					else
					{
						//如果沒歷史訂單
						this.InitialData();
					}
				}
				else
				{
					Response.Write("網頁錯誤，請通知聯絡人");
				}
				//lc = 0;
			}
			else
			{
				//lc++;
				//Response.Write("Repost " + lc.ToString());
			}
			BindMfrInv();
			BindAdr();
			BindBk();
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
			this.sqlInsCmdIAD = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsCmdIA = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.DataGrid2.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid2_DeleteCommand);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// sqlInsCmdIAD
			// 
			this.sqlInsCmdIAD.CommandText = @"INSERT INTO iad (iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, iad_fk4, iad_projno, iad_costctr, iad_desc, iad_qty, iad_unit, iad_uprice, iad_amt) VALUES ('C4', @iad_iano, @iad_iaditem, @iad_fk1, @iad_fk2, @iad_fk3, @iad_fk4, @iad_projno, @iad_costctr, @iad_desc, @iad_qty, @iad_unit, @iad_uprice, @iad_amt)";
			this.sqlInsCmdIAD.Connection = this.sqlConnection1;
			this.sqlInsCmdIAD.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iano", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIAD.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iaditem", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iano", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIAD.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk1", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iaditem", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIAD.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk2", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk1", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIAD.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk3", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk2", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIAD.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk4", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk3", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIAD.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_projno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk4", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIAD.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_costctr", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_projno", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIAD.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_desc", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_costctr", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIAD.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_qty", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_desc", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIAD.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_unit", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_qty", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIAD.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_uprice", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_unit", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIAD.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_amt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_uprice", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-900103;packet size=4096";
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT im_imid, im_fgitri, im_syscd, im_contno, im_imseq, im_mfrno, im_nm, im_jbt" +
				"i, im_zip, im_addr, im_tel, im_fax, im_cell, im_email, im_invcd, im_taxtp FROM i" +
				"nvmfr";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT COUNT(*) AS C1, MAX(cont_contno) AS MaxContNo FROM c4_cont";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT cont_contid, cont_syscd, cont_contno, cont_custno, cont_conttp, cont_bkcd, cont_signdate, cont_sdate, cont_edate, cont_empno, cont_mfrno, cont_pubcate, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_disc, cont_freetm, cont_tottm, cont_pubtm, cont_resttm, cont_totamt, cont_paidamt, cont_restamt, cont_ccont, cont_csdate, cont_atp, cont_matp, cont_irnm, cont_iraddr, cont_irzip, cont_irtel, cont_irfax, cont_ircell, cont_iremail, cont_fgclosed, cont_adremark, cont_pdcont, cont_moddate, cont_invcd, cont_taxtp, cont_fgitri, cont_xmldata c4_cont";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = @"SELECT c4_freebk.fbk_syscd, c4_freebk.fbk_contno, c4_freebk.fbk_fbkitem, c4_freebk.fbk_sdate, c4_freebk.fbk_edate, c4_freebk.fbk_bkcd, book.bk_nm, c4_ramt.ma_oritem, c4_or.or_inm, c4_or.or_nm, c4_or.or_fgmosea, book.bk_bkcd, c4_or.or_contno, c4_or.or_oritem, c4_or.or_syscd, c4_ramt.ma_contno, c4_ramt.ma_fbkitem, c4_ramt.ma_syscd, c4_freebk.fbk_fbkid, c4_ramt.ma_pubmnt, c4_ramt.ma_unpubmnt FROM c4_freebk INNER JOIN c4_or ON c4_freebk.fbk_syscd = c4_or.or_syscd AND c4_freebk.fbk_contno = c4_or.or_contno INNER JOIN c4_ramt ON c4_freebk.fbk_syscd = c4_ramt.ma_syscd AND c4_freebk.fbk_contno = c4_ramt.ma_contno AND c4_freebk.fbk_fbkitem = c4_ramt.ma_fbkitem AND c4_or.or_oritem = c4_ramt.ma_oritem INNER JOIN book ON c4_freebk.fbk_bkcd = book.bk_bkcd";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = @"SELECT adr_adrid, adr_costctr, adr_syscd, adr_contno, adr_date, adr_seq, adr_invamt, adr_adcate, adr_keyword, adr_alttext, adr_imgurl, adr_drafttp, adr_navurl, adr_urlcate, adr_txtadcont, adr_txtadcontnm, adr_impr, adr_fgfixad, adr_fggot, adr_adamt, adr_desamt, adr_chgamt, adr_remark, adr_fginved, adr_fginvself, adr_projno FROM c4_adr";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlInsCmdIA
			// 
			this.sqlInsCmdIA.CommandText = @"INSERT INTO ia (ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat, ia_invno, ia_invdate, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti, ia_rtel, ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno) VALUES ('C4', @ia_iasdate, @ia_iasseq, @ia_iaitem, @ia_iano, @ia_refno, @ia_mfrno, @ia_pyno, @ia_pyseq, @ia_pyat, @ia_ivat, @ia_invno, @ia_invdate, @ia_fgitri, @ia_rnm, @ia_raddr, @ia_rzip, @ia_rjbti, @ia_rtel, @ia_fgnonauto, @ia_invcd, @ia_taxtp, @ia_status, @ia_cname, @ia_tel, @ia_contno)";
			this.sqlInsCmdIA.Connection = this.sqlConnection1;
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iasdate", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iasseq", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iasdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iaitem", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iasseq", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iano", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iaitem", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_refno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_refno", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyseq", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyno", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyat", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyseq", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_ivat", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyat", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invno", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_ivat", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invdate", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invno", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_fgitri", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rnm", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgitri", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_raddr", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rnm", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rzip", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_raddr", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rjbti", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rzip", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rtel", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rjbti", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_fgnonauto", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rtel", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgnonauto", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_status", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_taxtp", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_cname", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_status", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_tel", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_cname", System.Data.DataRowVersion.Current, null));
			this.sqlInsCmdIA.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_contno", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_tel", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE c4_cont SET cont_syscd = @cont_syscd, cont_contno = @cont_contno, cont_custno = @cont_custno, cont_conttp = @cont_conttp, cont_bkcd = @cont_bkcd, cont_signdate = @cont_signdate, cont_sdate = @cont_sdate, cont_edate = @cont_edate, cont_empno = @cont_empno, cont_mfrno = @cont_mfrno, cont_pubcate = @cont_pubcate, cont_aunm = @cont_aunm, cont_autel = @cont_autel, cont_aufax = @cont_aufax, cont_aucell = @cont_aucell, cont_auemail = @cont_auemail, cont_disc = @cont_disc, cont_freetm = @cont_freetm, cont_tottm = @cont_tottm, cont_pubtm = @cont_pubtm, cont_resttm = @cont_resttm, cont_totamt = @cont_totamt, cont_paidamt = @cont_paidamt, cont_restamt = @cont_restamt, cont_ccont = @cont_ccont, cont_csdate = @cont_csdate, cont_atp = @cont_atp, cont_matp = @cont_matp, cont_irnm = @cont_irnm, cont_iraddr = @cont_iraddr, cont_irzip = @cont_irzip, cont_irtel = @cont_irtel, cont_irfax = @cont_irfax, cont_ircell = @cont_ircell, cont_iremail = @cont_iremail, cont_fgclosed = @cont_fgclosed, cont_adremark = @cont_adremark, cont_pdcont = @cont_pdcont, cont_moddate = @cont_moddate, cont_invcd = @cont_invcd, cont_taxtp = @cont_taxtp, cont_fgitri = @cont_fgitri, cont_xmldata = @cont_xmldata WHERE (cont_contno = @Original_cont_contno) AND (cont_syscd = @Original_cont_syscd)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 13, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_conttp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_conttp", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_bkcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_signdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_signdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_sdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_sdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_edate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_edate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_empno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_empno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubcate", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubcate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aunm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aunm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_autel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_autel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aufax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aufax", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aucell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aucell", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_auemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_auemail", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_disc", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_disc", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_freetm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_freetm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_tottm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_tottm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubtm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_resttm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_resttm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totamt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_paidamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_paidamt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_restamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restamt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_ccont", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_ccont", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_csdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_csdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_atp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_atp", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_matp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_matp", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_irnm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_irnm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_iraddr", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_iraddr", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_irzip", System.Data.SqlDbType.VarChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_irzip", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_irtel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_irtel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_irfax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_irfax", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_ircell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_ircell", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_iremail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_iremail", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgclosed", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgclosed", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_adremark", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_adremark", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pdcont", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pdcont", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_invcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_taxtp", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgitri", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgitri", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_xmldata", System.Data.SqlDbType.NText, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_contno", System.Data.SqlDbType.Char, 13, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM c4_cont WHERE (cont_contno = @cont_contno) AND (cont_syscd = @cont_sy" +
				"scd)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 13, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "Table", new System.Data.Common.DataColumnMapping[] {
																																																			   new System.Data.Common.DataColumnMapping("MaxContNo", "MaxContNo")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
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
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO c4_cont(cont_syscd, cont_contno, cont_custno, cont_conttp, cont_bkcd, cont_signdate, cont_sdate, cont_edate, cont_empno, cont_mfrno, cont_pubcate, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_disc, cont_freetm, cont_tottm, cont_pubtm, cont_resttm, cont_totamt, cont_paidamt, cont_restamt, cont_ccont, cont_csdate, cont_atp, cont_matp, cont_irnm, cont_iraddr, cont_irzip, cont_irtel, cont_irfax, cont_ircell, cont_iremail, cont_fgclosed, cont_adremark, cont_pdcont, cont_moddate, cont_invcd, cont_taxtp, cont_fgitri, cont_xmldata) VALUES (@cont_syscd, @cont_contno, @cont_custno, @cont_conttp, @cont_bkcd, @cont_signdate, @cont_sdate, @cont_edate, @cont_empno, @cont_mfrno, @cont_pubcate, @cont_aunm, @cont_autel, @cont_aufax, @cont_aucell, @cont_auemail, @cont_disc, @cont_freetm, @cont_tottm, @cont_pubtm, @cont_resttm, @cont_totamt, @cont_paidamt, @cont_restamt, @cont_ccont, @cont_csdate, @cont_atp, @cont_matp, @cont_irnm, @cont_iraddr, @cont_irzip, @cont_irtel, @cont_irfax, @cont_ircell, @cont_iremail, @cont_fgclosed, @cont_adremark, @cont_pdcont, @cont_moddate, @cont_invcd, @cont_taxtp, @cont_fgitri, @cont_xmldata)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 13, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_conttp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_conttp", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_bkcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_signdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_signdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_sdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_sdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_edate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_edate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_empno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_empno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubcate", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubcate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aunm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aunm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_autel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_autel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aufax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aufax", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aucell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aucell", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_auemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_auemail", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_disc", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_disc", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_freetm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_freetm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_tottm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_tottm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubtm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_resttm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_resttm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totamt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_paidamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_paidamt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_restamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restamt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_ccont", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_ccont", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_csdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_csdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_atp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_atp", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_matp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_matp", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_irnm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_irnm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_iraddr", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_iraddr", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_irzip", System.Data.SqlDbType.VarChar, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_irzip", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_irtel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_irtel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_irfax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_irfax", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_ircell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_ircell", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_iremail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_iremail", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgclosed", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgclosed", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_adremark", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_adremark", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pdcont", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pdcont", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_invcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_taxtp", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgitri", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgitri", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_xmldata", System.Data.SqlDbType.NText, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_xmldata", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c4_freebk", new System.Data.Common.DataColumnMapping[] {
																																																				   new System.Data.Common.DataColumnMapping("fbk_syscd", "fbk_syscd"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_contno", "fbk_contno"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_fbkitem", "fbk_fbkitem"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_sdate", "fbk_sdate"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_edate", "fbk_edate"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_bkcd", "fbk_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm"),
																																																				   new System.Data.Common.DataColumnMapping("ma_oritem", "ma_oritem"),
																																																				   new System.Data.Common.DataColumnMapping("or_inm", "or_inm"),
																																																				   new System.Data.Common.DataColumnMapping("or_nm", "or_nm"),
																																																				   new System.Data.Common.DataColumnMapping("or_fgmosea", "or_fgmosea"),
																																																				   new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																				   new System.Data.Common.DataColumnMapping("or_contno", "or_contno"),
																																																				   new System.Data.Common.DataColumnMapping("or_oritem", "or_oritem"),
																																																				   new System.Data.Common.DataColumnMapping("or_syscd", "or_syscd"),
																																																				   new System.Data.Common.DataColumnMapping("ma_contno", "ma_contno"),
																																																				   new System.Data.Common.DataColumnMapping("ma_fbkitem", "ma_fbkitem"),
																																																				   new System.Data.Common.DataColumnMapping("ma_syscd", "ma_syscd"),
																																																				   new System.Data.Common.DataColumnMapping("fbk_fbkid", "fbk_fbkid"),
																																																				   new System.Data.Common.DataColumnMapping("ma_pubmnt", "ma_pubmnt"),
																																																				   new System.Data.Common.DataColumnMapping("ma_unpubmnt", "ma_unpubmnt")})});
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c4_adr", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("adr_adrid", "adr_adrid"),
																																																				new System.Data.Common.DataColumnMapping("adr_costctr", "adr_costctr"),
																																																				new System.Data.Common.DataColumnMapping("adr_syscd", "adr_syscd"),
																																																				new System.Data.Common.DataColumnMapping("adr_contno", "adr_contno"),
																																																				new System.Data.Common.DataColumnMapping("adr_date", "adr_date"),
																																																				new System.Data.Common.DataColumnMapping("adr_seq", "adr_seq"),
																																																				new System.Data.Common.DataColumnMapping("adr_invamt", "adr_invamt"),
																																																				new System.Data.Common.DataColumnMapping("adr_adcate", "adr_adcate"),
																																																				new System.Data.Common.DataColumnMapping("adr_keyword", "adr_keyword"),
																																																				new System.Data.Common.DataColumnMapping("adr_alttext", "adr_alttext"),
																																																				new System.Data.Common.DataColumnMapping("adr_imgurl", "adr_imgurl"),
																																																				new System.Data.Common.DataColumnMapping("adr_drafttp", "adr_drafttp"),
																																																				new System.Data.Common.DataColumnMapping("adr_navurl", "adr_navurl"),
																																																				new System.Data.Common.DataColumnMapping("adr_urlcate", "adr_urlcate"),
																																																				new System.Data.Common.DataColumnMapping("adr_txtadcont", "adr_txtadcont"),
																																																				new System.Data.Common.DataColumnMapping("adr_txtadcontnm", "adr_txtadcontnm"),
																																																				new System.Data.Common.DataColumnMapping("adr_impr", "adr_impr"),
																																																				new System.Data.Common.DataColumnMapping("adr_fgfixad", "adr_fgfixad"),
																																																				new System.Data.Common.DataColumnMapping("adr_fggot", "adr_fggot"),
																																																				new System.Data.Common.DataColumnMapping("adr_adamt", "adr_adamt"),
																																																				new System.Data.Common.DataColumnMapping("adr_desamt", "adr_desamt"),
																																																				new System.Data.Common.DataColumnMapping("adr_chgamt", "adr_chgamt"),
																																																				new System.Data.Common.DataColumnMapping("adr_remark", "adr_remark"),
																																																				new System.Data.Common.DataColumnMapping("adr_fginved", "adr_fginved"),
																																																				new System.Data.Common.DataColumnMapping("adr_fginvself", "adr_fginvself"),
																																																				new System.Data.Common.DataColumnMapping("adr_projno", "adr_projno")})});
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//每當進到這個Page時，該準備一些基本的資料
		private void InitialData()
		{
//			DataSet ds = new DataSet();
//			this.sqlDataAdapter1.Fill(ds, "CONT");
//			DataView dv = ds.Tables["CONT"].DefaultView;
			Session.Timeout = 540;
			DataView dv = (DataView)Session["QDV"];
			int i = Int32.Parse(Request.QueryString["SelectedCust"]);

			this.tbxMfrName.Text = dv[i]["mfr_inm"].ToString().Trim();
			this.tbxAuCell.Text = "";
			this.tbxAuEmail.Text = "";
			this.tbxAuFax.Text = "";
			this.tbxAuTel.Text = "";
			this.tbxContNo.Text = this.getNewContNo();
			this.tbxContDisc.Text = "0";
			this.tbxContEDate.Text = System.DateTime.Today.ToString("yyyyMMdd");
			this.tbxContEmp.Text = "";
			this.tbxContFreeTm.Text = "0";
			this.tbxContPaidAmt.Text = "0";
			this.tbxContPubTm.Text = "0";
			this.tbxContSDate.Text = System.DateTime.Today.ToString("yyyyMMdd");
			this.tbxContSignDate.Text = System.DateTime.Today.ToString("yyyyMMdd");
			this.tbxContTotAmt.Text = "0";
			this.tbxContTotTm.Text = "0";
			this.tbxCustName.Text = dv[i]["cust_nm"].ToString().Trim();
			this.tbxCustTel.Text = dv[i]["cust_tel"].ToString().Trim();
			this.tbxCustTitle.Text = dv[i]["cust_jbti"].ToString().Trim();
			this.tbxIrAddr.Text = "";
			this.tbxIrName.Text = "";
			this.tbxIrTel.Text = "";
			this.tbxIrZip.Text = "";
			this.tbxIrCell.Text = "";
			this.tbxIrFax.Text = "";
			this.tbxIrEmail.Text = "";
			this.tbxCCont.Text = "";
			this.tbxCsDate.Text = System.DateTime.Today.ToString("yyyyMMdd");
			this.tbxPdCont.Text = "";
			this.tbxAdRemark.Text = "";
		}

		//載入歷史訂單
		private void LoadHistoryCont()
		{
			//從歷史合約中載入資料
			DataView dv = (DataView)Session["QDV"];
			int i = Int32.Parse(Request.QueryString["SelectedCust"]);

			DataView hcdv = (DataView)Session["HCDV"];
			int j = Int32.Parse(Request.QueryString["SelectedHisCont"]);

			//這邊還沒正式完成，要在check從歷史資料中抓出來的各個帶入欄位
			this.tbxMfrName.Text = dv[i]["mfr_inm"].ToString();
			this.tbxAuCell.Text = hcdv[j]["cont_aucell"].ToString();
			this.tbxAuEmail.Text = hcdv[j]["cont_auemail"].ToString();
			this.tbxAuFax.Text = hcdv[j]["cont_aufax"].ToString();
			this.tbxAuTel.Text = hcdv[j]["cont_autel"].ToString();
			this.tbxContNo.Text = this.getNewContNo();
			this.tbxContDisc.Text = "0";
			this.tbxContEDate.Text = System.DateTime.Today.ToString("yyyyMMdd");
			this.tbxContEmp.Text = "";
			this.tbxContFreeTm.Text = "0";
			this.tbxContPaidAmt.Text = "0";
			this.tbxContPubTm.Text = "0";
			this.tbxContSDate.Text = System.DateTime.Today.ToString("yyyyMMdd");
			this.tbxContSignDate.Text = System.DateTime.Today.ToString("yyyyMMdd");
			this.tbxContTotAmt.Text = "0";
			this.tbxContTotTm.Text = "0";
			this.tbxCustName.Text = dv[i]["cust_nm"].ToString();
			this.tbxCustTel.Text = dv[i]["cust_tel"].ToString();
			this.tbxCustTitle.Text = dv[i]["cust_jbti"].ToString();
			this.tbxIrAddr.Text = hcdv[j]["cont_iraddr"].ToString();
			this.tbxIrName.Text = hcdv[j]["cont_irnm"].ToString();
			this.tbxIrTel.Text = hcdv[j]["cont_irtel"].ToString();
			this.tbxIrZip.Text = hcdv[j]["cont_irzip"].ToString();
			this.tbxIrCell.Text = hcdv[j]["cont_ircell"].ToString();
			this.tbxIrFax.Text = hcdv[j]["irfax"].ToString();
			this.tbxIrEmail.Text = hcdv[j]["cont_iremail"].ToString();
			this.tbxCCont.Text = hcdv[j]["cont_ccont"].ToString();
			this.tbxCsDate.Text = System.DateTime.Today.ToString("yyyyMMdd");
			this.tbxPdCont.Text = hcdv[j]["cont_pdcont"].ToString();
			this.tbxAdRemark.Text = hcdv[j]["cont_adremark"].ToString();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			DataView dv = (DataView)Session["QDV"];
			int i = Int32.Parse(Request.QueryString["SelectedCust"]);

//			string strAssignedContNo = Convert.ToString(System.DateTime.Today.Year-1911);
//			DataSet ds = new DataSet();
//			this.sqlDataAdapter2.Fill(ds, "maxcontno");
//			DataView dvmax = ds.Tables["maxcontno"].DefaultView;
//
//			if (dvmax.Count > 0 && dvmax[0]["C1"].ToString() != "0")
//			{
//				strAssignedContNo = Convert.ToString(Convert.ToInt32(dvmax[0]["MaxContNo"])+1);
//			}
//			else
//			{
//				strAssignedContNo += "0000";
//			}																								

			this.sqlInsertCommand1.Parameters["@cont_fgitri"].Value = "";
			this.sqlInsertCommand1.Parameters["@cont_syscd"].Value = "C4";
			this.sqlInsertCommand1.Parameters["@cont_contno"].Value = this.tbxContNo.Text;
			this.sqlInsertCommand1.Parameters["@cont_custno"].Value = dv[i]["cust_custno"].ToString();
			this.sqlInsertCommand1.Parameters["@cont_conttp"].Value = this.ddlContTp.SelectedItem.Value;
			this.sqlInsertCommand1.Parameters["@cont_bkcd"].Value = "";
			this.sqlInsertCommand1.Parameters["@cont_signdate"].Value = this.tbxContSignDate.Text;
			this.sqlInsertCommand1.Parameters["@cont_sdate"].Value = this.tbxContSDate.Text;
			this.sqlInsertCommand1.Parameters["@cont_edate"].Value = this.tbxContEDate.Text;
			this.sqlInsertCommand1.Parameters["@cont_empno"].Value = this.tbxContEmp.Text;//現在用姓名，事實上應該用工號才對
			this.sqlInsertCommand1.Parameters["@cont_mfrno"].Value = dv[i]["mfr_mfrno"].ToString();
			this.sqlInsertCommand1.Parameters["@cont_pubcate"].Value = this.ddlPubCate.SelectedItem.Value;
			this.sqlInsertCommand1.Parameters["@cont_aunm"].Value = this.tbxAuName.Text;
			this.sqlInsertCommand1.Parameters["@cont_autel"].Value = this.tbxAuTel.Text;
			this.sqlInsertCommand1.Parameters["@cont_aufax"].Value = this.tbxAuFax.Text;
			this.sqlInsertCommand1.Parameters["@cont_aucell"].Value = this.tbxAuCell.Text;
			this.sqlInsertCommand1.Parameters["@cont_auemail"].Value = this.tbxAuEmail.Text;

			this.sqlInsertCommand1.Parameters["@cont_disc"].Value = this.tbxContDisc.Text;
			this.sqlInsertCommand1.Parameters["@cont_freetm"].Value = this.tbxContFreeTm.Text;
			this.sqlInsertCommand1.Parameters["@cont_tottm"].Value = this.tbxContTotTm.Text;
			this.sqlInsertCommand1.Parameters["@cont_pubtm"].Value = this.tbxContPubTm.Text;
			this.sqlInsertCommand1.Parameters["@cont_resttm"].Value = 0;
			this.sqlInsertCommand1.Parameters["@cont_totamt"].Value = this.tbxContTotAmt.Text;
			this.sqlInsertCommand1.Parameters["@cont_paidamt"].Value = this.tbxContPaidAmt.Text;
			this.sqlInsertCommand1.Parameters["@cont_restamt"].Value = 0;

			this.sqlInsertCommand1.Parameters["@cont_ccont"].Value = this.tbxCCont.Text;
			this.sqlInsertCommand1.Parameters["@cont_csdate"].Value = this.tbxCsDate.Text;
			this.sqlInsertCommand1.Parameters["@cont_atp"].Value = "";
			this.sqlInsertCommand1.Parameters["@cont_matp"].Value = "";
			this.sqlInsertCommand1.Parameters["@cont_irnm"].Value = this.tbxIrName.Text;
			this.sqlInsertCommand1.Parameters["@cont_iraddr"].Value = this.tbxIrAddr.Text;
			this.sqlInsertCommand1.Parameters["@cont_irzip"].Value = this.tbxIrZip.Text;
			this.sqlInsertCommand1.Parameters["@cont_irtel"].Value = this.tbxIrTel.Text;
			this.sqlInsertCommand1.Parameters["@cont_irfax"].Value = this.tbxIrFax.Text;
			this.sqlInsertCommand1.Parameters["@cont_ircell"].Value = this.tbxIrCell.Text;
			this.sqlInsertCommand1.Parameters["@cont_iremail"].Value = this.tbxIrEmail.Text;
			this.sqlInsertCommand1.Parameters["@cont_fgclosed"].Value = "";
			this.sqlInsertCommand1.Parameters["@cont_adremark"].Value = this.tbxAdRemark.Text;
			this.sqlInsertCommand1.Parameters["@cont_pdcont"].Value = this.tbxPdCont.Text;
			this.sqlInsertCommand1.Parameters["@cont_moddate"].Value = System.DateTime.Today.ToString("yyyyMMdd");
			this.sqlInsertCommand1.Parameters["@cont_invcd"].Value = "";
			this.sqlInsertCommand1.Parameters["@cont_taxtp"].Value = "";
			this.sqlInsertCommand1.Parameters["@cont_xmldata"].Value = "<xmldata></xmldata>";

			bool InsAdContSuccess = false;
			this.sqlInsertCommand1.Connection.Open();
			try
			{
				this.sqlInsertCommand1.ExecuteNonQuery();
				InsAdContSuccess = true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				InsAdContSuccess = false;
			}
			this.sqlInsertCommand1.Connection.Close();
			if (InsAdContSuccess)
			{
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"合約編號: " + this.tbxContNo.Text + " 新增成功\");</script>";
				Page.Controls.Add(litAlert);
			}
			else
			{
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"合約編號: " + this.tbxContNo.Text + " 新增失敗\");</script>";
				Page.Controls.Add(litAlert);
			}

			GenIA_IAD();
		}

		private void btnAddAdr_Click(object sender, System.EventArgs e)
		{
			//Response.Redirect("AdManagement.aspx?ContNo=" + this.tbxContNo.Text);
			//想想要怎麼給定AdScope
		}

		private string getNewContNo()
		{
			string strAssignedContNo = Convert.ToString(System.DateTime.Today.Year-1911);
			DataSet ds = new DataSet();
			this.sqlDataAdapter2.Fill(ds, "maxcontno");
			DataView dvmax = ds.Tables["maxcontno"].DefaultView;

			if (dvmax.Count > 0 && dvmax[0]["C1"].ToString() != "0")
			{
				strAssignedContNo = Convert.ToString(Convert.ToInt32(dvmax[0]["MaxContNo"])+1);
			}
			else
			{
				strAssignedContNo += "0000";
			}
			return strAssignedContNo;																					
		}

		private void btnAddInvMfr_Click(object sender, System.EventArgs e)
		{
//			LiteralControl litOpenInvMfr = new LiteralControl();
//			litOpenInvMfr.Text = "<script language=javascript>"+
//				"doOpenInvMfr();"+
//				"</script>";
//			Page.Controls.Add(litOpenInvMfr);
		}

		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			//先mark掉，因為postback就會整理了
//			BindMfrInv();
//			BindAdr();
//			BindBk();
		}

		//發票廠商資料
		private void BindMfrInv()
		{
			DataSet ds = new DataSet();
			sqlDataAdapter3.Fill(ds, "IM");
			DataView dv = ds.Tables["IM"].DefaultView;

			//系統代號、合約編號
			dv.RowFilter = "im_syscd='C4' AND im_contno='" + tbxContNo.Text + "'";
			this.hidInvMfrCount.Value = dv.Count.ToString();

			DataList1.DataSource = dv;
			DataList1.DataBind();
			if (dv.Count>0)
			{
				DataList1.Visible = true;
			}
			else
			{
				DataList1.Visible = false;
			}
		}

		private void BindAdr()
		{
			DataSet ds = new DataSet();
			sqlDataAdapter4.Fill(ds, "ADR");
			DataView dv = ds.Tables["ADR"].DefaultView;
			//合約編號，c4_adr只有c4在用吧....
			dv.RowFilter = "adr_contno='" + tbxContNo.Text + "'";
			DataGrid2.Visible = false;
			DataGrid2.DataSource = dv;
			DataGrid2.DataBind();
			if (dv.Count>0)
			{
				DataGrid2.Visible = true;
			}
			else
			{
				DataGrid2.Visible = false;
			}
		}

		private void BindBk()
		{
			DataSet ds = new DataSet();
			sqlDataAdapter5.Fill(ds, "FreeBK");
			DataView dv = ds.Tables["FreeBK"].DefaultView;

			//合約編號，c4_freebk只有c4在用吧...
			dv.RowFilter = "fbk_syscd='C4' AND fbk_contno='" + tbxContNo.Text + "'";
			DataGrid1.Visible = false;
			DataGrid1.DataSource = dv;
			DataGrid1.DataBind();

			if (dv.Count>0)
			{
				DataGrid1.Visible = true;
			}
			else
			{
				DataGrid1.Visible = false;
			}
		}

		private void DataGrid2_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
			cmd.CommandText = "DELETE FROM c4_adr WHERE adr_adrid=@adr_id";
			cmd.CommandType = CommandType.Text;
			cmd.Connection = this.sqlConnection1;

			cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_adrid", System.Data.SqlDbType.Int, 4));
			cmd.Connection.Open();
			cmd.ExecuteNonQuery();
			cmd.Connection.Close();
		}

		private void GenIA_IAD()
		{
			//填入IAD
//			this.sqlInsCmdIA.Parameters["@iad_iano"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_iaditem"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_fk1"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_fk2"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_fk3"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_fk4"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_projno"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_costctr"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_desc"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_qty"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_unit"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_uprice"].Value = "";
//			this.sqlInsCmdIA.Parameters["@iad_amt"].Value = "";
//
//			//填入IA
//			//this.sqlInsCmdIA.Parameters["@ia_syscd"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_contno"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_iasdate"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_iasseq"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_iaitem"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_iano"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_refno"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_mfrno"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_pyno"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_pyseq"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_pyat"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_ivat"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_invno"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_invdate"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_fgitri"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_rnm"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_raddr"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_rzip"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_rjbti"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_rtel"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_fgnonauto"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_invcd"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_taxtp"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_status"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_cname"].Value = "";
//			this.sqlInsCmdIA.Parameters["@ia_tel"].Value = "";
//
//			System.Data.SqlClient.SqlTransaction sqlTran = this.sqlInsCmdIAD.Connection.BeginTransaction();
//			bool InsIaIadSuccess = false;
//			try
//			{
//				InsIaIadSuccess = true;
//				sqlTran.Commit();
//			}
//			catch(System.Data.SqlClient.SqlException ex)
//			{
//				InsIaIadSuccess = false;
//				sqlTran.Rollback();
//			}

			//顯示錯誤訊息
			//最好不管成功或失敗都給user回應..
		}
	}
}
