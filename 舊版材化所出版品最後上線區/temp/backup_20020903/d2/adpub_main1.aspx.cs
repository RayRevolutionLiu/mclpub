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

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adpub_main.
	/// </summary>
	public class adpub_main1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Web.UI.WebControls.TextBox tbxPubDate;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.HtmlControls.HtmlForm adpub_main;
		protected System.Web.UI.WebControls.TextBox tbxMfrName;
		protected System.Web.UI.WebControls.Label lblMemo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.DropDownList ddlDataFilter;
		protected System.Web.UI.WebControls.Literal literal1;
	
		public adpub_main1()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				//
				literal1.Text="";

				// 不能清除輸入查詢之關鍵字, 否則無法出現正確結果
				//tbxCompanyName.Text="";
				//tbxMfrNo.Text="";
				//tbxCustNo.Text="";
				//tbxCustName.Text="";
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
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT c2_pub.pub_pubid, c2_pub.pub_syscd, c2_pub.pub_contno, c2_pub.pub_date, c2_pub.pub_pubseq, c2_pub.pub_pgno, c2_pub.pub_ltpcd, c2_pub.pub_clrcd, c2_pub.pub_pgscd, c2_pub.pub_adamt, c2_pub.pub_chgamt, c2_pub.pub_drafttp, c2_pub.pub_bkcd, c2_pub.pub_origjno, c2_pub.pub_origjbkno, c2_pub.pub_chgjno, c2_pub.pub_fgrechg, c2_pub.pub_fggot, c2_pub.pub_njtpcd, c2_pub.pub_projno, c2_pub.pub_costctr, c2_pub.pub_fginved, c2_pub.pub_fginvself, c2_pub.pub_pno, c2_pub.pub_remark, c2_pub.pub_mnt, c2_pub.pub_fgfixpg, c2_cont.cont_contid, c2_cont.cont_syscd, c2_cont.cont_contno, c2_cont.cont_signdate, c2_cont.cont_empno, c2_cont.cont_mfrno, c2_cont.cont_custno, c2_cont.cont_fgclosed, c2_cont.cont_fgfixpg, c2_cont.cont_fgpayonce, c2_cont.cont_fgitri, c2_cont.cont_sdate, c2_cont.cont_edate, c2_cont.cont_totjtm, c2_cont.cont_disc, c2_cont.cont_freetm, c2_cont.cont_freebkcnt, c2_cont.cont_tottm, c2_cont.cont_totamt, cust.cust_custid, cust.cust_nm, cust.cust_tel, mfr.mfr_mfrid, mfr.mfr_inm, mfr.mfr_tel, mfr.mfr_fax, cust.cust_custno FROM c2_pub INNER JOIN c2_cont ON c2_pub.pub_contno = c2_cont.cont_contno INNER JOIN mfr ON c2_cont.cont_mfrno = mfr.mfr_mfrno INNER JOIN cust ON c2_cont.cont_custno = cust.cust_custno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_pub", new System.Data.Common.DataColumnMapping[] {
																																																				new System.Data.Common.DataColumnMapping("pub_pubid", "pub_pubid"),
																																																				new System.Data.Common.DataColumnMapping("pub_syscd", "pub_syscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_contno", "pub_contno"),
																																																				new System.Data.Common.DataColumnMapping("pub_date", "pub_date"),
																																																				new System.Data.Common.DataColumnMapping("pub_pubseq", "pub_pubseq"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgno", "pub_pgno"),
																																																				new System.Data.Common.DataColumnMapping("pub_ltpcd", "pub_ltpcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_clrcd", "pub_clrcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_pgscd", "pub_pgscd"),
																																																				new System.Data.Common.DataColumnMapping("pub_adamt", "pub_adamt"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgamt", "pub_chgamt"),
																																																				new System.Data.Common.DataColumnMapping("pub_drafttp", "pub_drafttp"),
																																																				new System.Data.Common.DataColumnMapping("pub_bkcd", "pub_bkcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_origjno", "pub_origjno"),
																																																				new System.Data.Common.DataColumnMapping("pub_origjbkno", "pub_origjbkno"),
																																																				new System.Data.Common.DataColumnMapping("pub_chgjno", "pub_chgjno"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgrechg", "pub_fgrechg"),
																																																				new System.Data.Common.DataColumnMapping("pub_fggot", "pub_fggot"),
																																																				new System.Data.Common.DataColumnMapping("pub_njtpcd", "pub_njtpcd"),
																																																				new System.Data.Common.DataColumnMapping("pub_projno", "pub_projno"),
																																																				new System.Data.Common.DataColumnMapping("pub_costctr", "pub_costctr"),
																																																				new System.Data.Common.DataColumnMapping("pub_fginved", "pub_fginved"),
																																																				new System.Data.Common.DataColumnMapping("pub_fginvself", "pub_fginvself"),
																																																				new System.Data.Common.DataColumnMapping("pub_pno", "pub_pno"),
																																																				new System.Data.Common.DataColumnMapping("pub_remark", "pub_remark"),
																																																				new System.Data.Common.DataColumnMapping("pub_mnt", "pub_mnt"),
																																																				new System.Data.Common.DataColumnMapping("pub_fgfixpg", "pub_fgfixpg"),
																																																				new System.Data.Common.DataColumnMapping("cont_contid", "cont_contid"),
																																																				new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgfixpg", "cont_fgfixpg"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				new System.Data.Common.DataColumnMapping("cont_fgitri", "cont_fgitri"),
																																																				new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				new System.Data.Common.DataColumnMapping("cont_disc", "cont_disc"),
																																																				new System.Data.Common.DataColumnMapping("cont_freetm", "cont_freetm"),
																																																				new System.Data.Common.DataColumnMapping("cont_freebkcnt", "cont_freebkcnt"),
																																																				new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																				new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																				new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																				new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																				new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																				new System.Data.Common.DataColumnMapping("mfr_tel", "mfr_tel"),
																																																				new System.Data.Common.DataColumnMapping("mfr_fax", "mfr_fax")})});
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			// 查詢按鈕: 呼叫 Function: ShowCust() 
			ShowPub();
		}


		private void ShowPub()
		{
			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "c2_pub");
			DataView dv = ds.Tables["c2_pub"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
			string rowfilterstr = "cont_mfrno Like '%"+tbxMfrNo.Text.Trim()+"%'";

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("dv.Count= "+ dv.Count + "<BR>");
			//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");

			//防呆處理: 若無資料時, 則給錯誤訊息
			//if (dv1.Count < 1)  ...
			// 若找到資料, 則在 Server Web Control 顯示之


			if(tbxMfrName.Text!="")
				rowfilterstr=rowfilterstr+" and mfr_inm Like '%"+tbxMfrName.Text.Trim()+"%'";
	        
			if(tbxCustNo.Text!="")
				rowfilterstr=rowfilterstr+" and cont_custno ='"+tbxCustNo.Text.Trim()+"'";

			if(tbxCustName.Text!="")
				rowfilterstr=rowfilterstr+" and cust_nm Like '%"+tbxCustName.Text.Trim()+"%'";
			
			if(tbxContNo.Text!="")
				rowfilterstr=rowfilterstr+" and cont_contno like '%"+tbxContNo.Text.Trim()+"%'";

			if(tbxPubDate.Text!="")
				rowfilterstr=rowfilterstr+" and pub_date like '%"+tbxPubDate.Text.Trim()+"%'";


			dv.RowFilter = rowfilterstr;

			// 若搜尋結果為 "找不到" 的處理
			if (dv.Count==0)
				lblMessage.Text="查詢結果: 找不到符合條件的資料, 請重設條件!  或請先新增<A HREF='../d5/Mfr.aspx' Target='_new'>廠商</A> 或 <A HREF='../d1/NewCust.aspx?mfrno=' Target='_new'>客戶</A>, 再回來搜尋並新增.";
			else
				lblMessage.Text="查詢結果: 找到 "+dv.Count.ToString()+"筆資料";
			
			DataGrid1.DataSource=dv;
			DataGrid1.DataBind();

			// 檢查並輸出 最後 Row Filter 的結果
			//Response.Write("rowfilterstr= " + rowfilterstr + "<BR>");
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string	strbuf;
			DataGrid1.SelectedIndex=e.Item.ItemIndex;
			//Response.Write(DataGrid1.SelectedItem.Cells[1].Text);

			if(e.CommandName=="Modify")
			{
				// 修改資料的處理: 先轉址
				Response.Redirect("ModifyCust.aspx?id="+DataGrid1.SelectedItem.Cells[1].Text);
			}
			else if(e.CommandName=="Detail")
			{
				// 觀看細節資料的處理: 先轉址
				strbuf="CustDetail.aspx?id="+DataGrid1.SelectedItem.Cells[1].Text;
				literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
			}
			else if(e.CommandName=="OK")
			{
				DataSet ds = new DataSet();
				this.sqlDataAdapter1.Fill(ds, "cust");
				DataView dv = ds.Tables["cust"].DefaultView;
				
				dv.RowFilter="cont_contno='"+DataGrid1.SelectedItem.Cells[1].Text+"'";
				Response.Write("dv.RowFilter= " + dv.RowFilter + "<br>");
				Response.Write("DataGrid1.SelectedItem.Cells[1].Text= " + DataGrid1.SelectedItem.Cells[1].Text + "<br>");

				//// 按下確定(挑人)的處理: 先轉址
				Response.Redirect("adpub_main2.aspx?contno="+DataGrid1.SelectedItem.Cells[1].Text.Trim()+"&pubseq=" + DataGrid1.SelectedItem.Cells[3].Text.Trim());
			}

		}
	}
}
