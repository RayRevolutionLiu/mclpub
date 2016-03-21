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
	/// Summary description for LostAdd.
	/// </summary>
	public class LostAdd : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.TextBox tbxMfrNm;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxCustName;
		protected System.Web.UI.WebControls.TextBox tbxSSDate;
		protected System.Web.UI.WebControls.TextBox tbxSEDate;
		protected System.Web.UI.WebControls.TextBox tbxOrName;
		protected System.Web.UI.WebControls.TextBox tbxOrTel;
		protected System.Web.UI.WebControls.TextBox tbxOrAddr;
		protected System.Web.UI.WebControls.RadioButtonList rblSent;
		protected System.Web.UI.WebControls.LinkButton lnbSearch;
		protected System.Web.UI.WebControls.DataGrid dgdContOr;
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPub;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaContOr;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaLostOr;
		protected System.Web.UI.WebControls.DataGrid dgdLost;
		protected System.Data.SqlClient.SqlCommand sqlCmdInsLost;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCmdDelUpdate;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Label lblMessage;
	
		public LostAdd()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				rblSent.Enabled = false;
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
			
			this.sqlDaLostOr = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCnnMRLPub = new System.Data.SqlClient.SqlConnection();
			this.sqlDaContOr = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdInsLost = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdDelUpdate = new System.Data.SqlClient.SqlCommand();
			this.lnbSearch.Click += new System.EventHandler(this.lnbSearch_Click);
			this.dgdContOr.SelectedIndexChanged += new System.EventHandler(this.dgdContOr_SelectedIndexChanged);
			this.dgdLost.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLost_CancelCommand);
			this.dgdLost.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLost_EditCommand);
			this.dgdLost.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLost_UpdateCommand);
			this.dgdLost.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLost_DeleteCommand);
			// 
			// sqlDaLostOr
			// 
			this.sqlDaLostOr.SelectCommand = this.sqlSelectCommand2;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT dbo.c4_cont.cont_syscd, dbo.c4_cont.cont_contno, dbo.c4_cont.cont_custno, " +
				"dbo.c4_cont.cont_conttp, dbo.c4_cont.cont_sdate, dbo.c4_cont.cont_edate, dbo.c4_" +
				"cont.cont_mfrno, dbo.c4_or.or_oritem, dbo.c4_or.or_nm, dbo.c4_or.or_jbti, dbo.c4" +
				"_or.or_addr, dbo.c4_or.or_tel, dbo.cust.cust_nm, dbo.mfr.mfr_inm, dbo.cust.cust_" +
				"custno, dbo.mfr.mfr_mfrno, dbo.c4_freebk.fbk_fbkitem, dbo.c4_freebk.fbk_bkcd, db" +
				"o.c4_ramt.ma_pubmnt, dbo.c4_ramt.ma_unpubmnt, dbo.c4_ramt.ma_fbkitem, dbo.c4_ram" +
				"t.ma_oritem, CONVERT(CHAR(2),dbo.c4_ramt.ma_pubmnt) + \'/\' + CONVERT(CHAR(2),dbo." +
				"c4_ramt.ma_unpubmnt) AS fbkmnt, dbo.c4_lost.lst_seq, dbo.c4_lost.lst_cont, dbo.c" +
				"4_lost.lst_date, dbo.c4_lost.lst_rea, dbo.c4_lost.lst_fgsent, dbo.c4_freebk.fbk_" +
				"contno, dbo.c4_freebk.fbk_syscd, dbo.c4_lost.lst_contno, dbo.c4_lost.lst_fbkitem" +
				", dbo.c4_lost.lst_oritem, dbo.c4_lost.lst_syscd, dbo.c4_or.or_contno, dbo.c4_or." +
				"or_syscd, dbo.c4_ramt.ma_contno, dbo.c4_ramt.ma_syscd FROM dbo.c4_cont INNER JOI" +
				"N dbo.c4_or ON dbo.c4_cont.cont_syscd = dbo.c4_or.or_syscd AND dbo.c4_cont.cont_" +
				"contno = dbo.c4_or.or_contno INNER JOIN dbo.cust ON dbo.c4_cont.cont_custno = db" +
				"o.cust.cust_custno INNER JOIN dbo.mfr ON dbo.c4_cont.cont_mfrno = dbo.mfr.mfr_mf" +
				"rno INNER JOIN dbo.c4_freebk ON dbo.c4_cont.cont_syscd = dbo.c4_freebk.fbk_syscd" +
				" AND dbo.c4_cont.cont_contno = dbo.c4_freebk.fbk_contno INNER JOIN dbo.c4_ramt O" +
				"N dbo.c4_cont.cont_syscd = dbo.c4_ramt.ma_syscd AND dbo.c4_cont.cont_contno = db" +
				"o.c4_ramt.ma_contno AND dbo.c4_freebk.fbk_fbkitem = dbo.c4_ramt.ma_fbkitem AND d" +
				"bo.c4_or.or_oritem = dbo.c4_ramt.ma_oritem INNER JOIN dbo.c4_lost ON dbo.c4_cont" +
				".cont_syscd = dbo.c4_lost.lst_syscd AND dbo.c4_cont.cont_contno = dbo.c4_lost.ls" +
				"t_contno AND dbo.c4_freebk.fbk_fbkitem = dbo.c4_lost.lst_fbkitem AND dbo.c4_or.o" +
				"r_oritem = dbo.c4_lost.lst_oritem";
			this.sqlSelectCommand2.Connection = this.sqlCnnMRLPub;
			// 
			// sqlCnnMRLPub
			// 
			this.sqlCnnMRLPub.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDaContOr
			// 
			this.sqlDaContOr.SelectCommand = this.sqlSelectCommand1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c4_cont.cont_syscd, dbo.c4_cont.cont_contno, dbo.c4_cont.cont_custno, dbo.c4_cont.cont_conttp, dbo.c4_cont.cont_sdate, dbo.c4_cont.cont_edate, dbo.c4_cont.cont_mfrno, dbo.c4_or.or_oritem, dbo.c4_or.or_nm, dbo.c4_or.or_jbti, dbo.c4_or.or_addr, dbo.c4_or.or_tel, dbo.cust.cust_nm, dbo.mfr.mfr_inm, dbo.cust.cust_custno, dbo.mfr.mfr_mfrno, dbo.c4_freebk.fbk_fbkitem, dbo.c4_freebk.fbk_bkcd, dbo.c4_ramt.ma_pubmnt, dbo.c4_ramt.ma_unpubmnt, dbo.c4_ramt.ma_fbkitem, dbo.c4_ramt.ma_oritem, dbo.c4_freebk.fbk_contno, dbo.c4_freebk.fbk_syscd, dbo.c4_or.or_contno, dbo.c4_or.or_syscd, dbo.c4_ramt.ma_contno, dbo.c4_ramt.ma_syscd, CONVERT(CHAR(2),dbo.c4_ramt.ma_pubmnt) + '/' + CONVERT(CHAR(2), dbo.c4_ramt.ma_unpubmnt) AS fbkmnt FROM dbo.c4_cont INNER JOIN dbo.c4_or ON dbo.c4_cont.cont_syscd = dbo.c4_or.or_syscd AND dbo.c4_cont.cont_contno = dbo.c4_or.or_contno INNER JOIN dbo.cust ON dbo.c4_cont.cont_custno = dbo.cust.cust_custno INNER JOIN dbo.mfr ON dbo.c4_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.c4_freebk ON dbo.c4_cont.cont_syscd = dbo.c4_freebk.fbk_syscd AND dbo.c4_cont.cont_contno = dbo.c4_freebk.fbk_contno INNER JOIN dbo.c4_ramt ON dbo.c4_cont.cont_syscd = dbo.c4_ramt.ma_syscd AND dbo.c4_cont.cont_contno = dbo.c4_ramt.ma_contno AND dbo.c4_freebk.fbk_fbkitem = dbo.c4_ramt.ma_fbkitem AND dbo.c4_or.or_oritem = dbo.c4_ramt.ma_oritem";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPub;
			// 
			// sqlCmdInsLost
			// 
			this.sqlCmdInsLost.CommandText = "INSERT INTO dbo.c4_lost (lst_syscd, lst_contno, lst_fbkitem, lst_oritem, lst_seq," +
				" lst_cont, lst_date, lst_rea, lst_fgsent) VALUES (\'C4\', @contno, @fbkitem, @orit" +
				"em, @seq, \'\', \'\', \'\', \'Y\')";
			this.sqlCmdInsLost.Connection = this.sqlCnnMRLPub;
			this.sqlCmdInsLost.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsLost.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fbkitem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsLost.Parameters.Add(new System.Data.SqlClient.SqlParameter("@oritem", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_fbkitem", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsLost.Parameters.Add(new System.Data.SqlClient.SqlParameter("@seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "lst_oritem", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCmdDelUpdate
			// 
			this.sqlCmdDelUpdate.Connection = this.sqlCnnMRLPub;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//放一個Alert在client script
		private void AlertMsg(string strMsg)
		{
			if (strMsg != null && strMsg != "")
			{
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"" + strMsg +"\");</script>";
				Page.Controls.Add(litAlert);
			}
		}

		private string GetContFilter()
		{
			string strFilter = "";
			int fcount = 0;
			//訂單編號
			if (tbxContNo.Text.Trim() != "")
			{
				if (fcount>0) strFilter += " AND ";
				strFilter += "cont_contno='" + tbxContNo.Text.Trim() + "'";
				fcount++;
			}

			//公司名稱
			if (tbxMfrNm.Text.Trim() != "")
			{
				if (fcount>0) strFilter += " AND ";
				strFilter += "mfr_inm LIKE '%" + tbxMfrNm.Text.Trim() + "%'";
				fcount++;
			}

			//統一編號
			if (tbxMfrNo.Text.Trim() != "")
			{
				if (fcount>0) strFilter += " AND ";
				strFilter += "cont_mfrno='" + tbxMfrNo.Text.Trim() + "'";
				fcount++;
			}

			//客戶姓名
			if (tbxCustName.Text.Trim() != "")
			{
				if (fcount>0) strFilter += " AND ";
				strFilter += "cust_nm LIKE '%" + tbxCustName.Text.Trim() + "%'";
				fcount++;
			}

			//客戶編號
			if (tbxCustNo.Text.Trim() != "")
			{
				if (fcount>0) strFilter += " AND ";
				strFilter += "cont_custno='" + tbxCustNo.Text.Trim() + "'";
				fcount++;
			}

			//簽約日期
			string SSDate;
			string SEDate;
			if (tbxSSDate.Text.Trim() != "" && tbxSEDate.Text.Trim() != "")
			{
				SSDate = DateTime.ParseExact(tbxSSDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
				SEDate = DateTime.ParseExact(tbxSEDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
				if (fcount>0) strFilter += " AND ";
				strFilter += "(cont_signdate>='" + SSDate + " AND cont_signdate<=" + SEDate + "')";
				fcount++;
			}

			//收件人姓名
			if (tbxOrName.Text.Trim() != "")
			{
				if (fcount>0) strFilter += " AND ";
				strFilter += "or_nm LIKE '%" + tbxOrName.Text.Trim() + "%'";
				fcount++;
			}
			//收件人電話
			if (tbxOrTel.Text.Trim() != "")
			{
				if (fcount>0) strFilter += " AND ";
				strFilter += "or_tel='" + tbxOrTel.Text.Trim() + "'";
				fcount++;
			}
			//收件人地址
			if (tbxOrAddr.Text.Trim() != "")
			{
				if (fcount>0) strFilter += " AND ";
				strFilter += "or_addr='" + tbxOrAddr.Text.Trim() + "'";
				fcount++;
			}
//
//			//寄書情況
//			if (fcount>0) strFilter += " AND ";
//			switch(this.rblSent.SelectedItem.Value.Trim())
//			{
//				case "0":
//					strFilter += "(lst_fgsent='Y' OR rm_fgsent='N')";
//					break;
//				case "1":
//					strFilter += "(lst_fgsent='C')";
//					break;
//				case "2":
//					strFilter += "(lst_fgsent='d')";
//					break;
//			}
//			fcount++;

			return strFilter;
		}

		private void Format_dgdContOr()
		{
			for (int i=0; i<dgdContOr.Items.Count; i++)
			{
				if (dgdContOr.Items[i].Cells[1].Text.Trim() == "01")
					dgdContOr.Items[i].Cells[1].Text = "一般";
				else
					dgdContOr.Items[i].Cells[1].Text = "推廣";
			}
		}

		private void Bind_dgdContOr(string strFilter)
		{
			dgdLost.Visible = false;
			//string strFilter = GetContFilter();
			DataSet ds = new DataSet();
			this.sqlDaContOr.Fill(ds, "CONTOR");
			DataView dv = ds.Tables["CONTOR"].DefaultView;
			dv.RowFilter = strFilter;

			if (!(dv.Count>0))
			{
				//無資料			
				AlertMsg("查無符合資料的合約");
				dgdContOr.Visible = false;
				return;
			}
			
			dgdContOr.Visible = true;
			dgdContOr.DataSource = dv;
			dgdContOr.DataBind();

			Format_dgdContOr();
		}

		protected object GetSelectedIndex(object fgsent)
		{
			int retValue = 0;
			switch(fgsent.ToString().Trim())
			{
				case "Y":
					retValue = 0;
					break;
				case "N":
					retValue = 1;
					break;
				case "d":
					retValue = 2;
					break;
			}
			return retValue;
		}


		protected object GetFgSentName(object fgsent)
		{
			string strReturn = "";
			switch(fgsent.ToString().Trim())
			{
				case "Y":
					strReturn = "可寄出";
					break;
				case "N":
					strReturn = "目前不寄出";
					break;
				case "d":
					strReturn = "不處理";
					break;
			}
			return strReturn;
		}

		private void Format_dgdLost()
		{
			for (int i=0; i<dgdLost.Items.Count; i++)
			{
				if (dgdLost.Items[i].Cells[2].Text.Trim() == "01")
					dgdLost.Items[i].Cells[2].Text = "一般";
				else
					dgdLost.Items[i].Cells[2].Text = "推廣";
			}
		}

		private void Bind_dgdLost(string strFilter)
		{
			dgdLost.Visible = true;

			DataSet ds = new DataSet();
			this.sqlDaLostOr.Fill(ds, "LOSTLOR");
			DataView dv = ds.Tables["LOSTLOR"].DefaultView;
			dv.RowFilter = strFilter;

			if (!(dv.Count>0))
			{
				//無資料
				AlertMsg("無缺書資料");
				dgdLost.Visible = false;
				return;
			}
			
			dgdLost.DataSource = dv;
			dgdLost.DataBind();

			Format_dgdLost();
		}

		private void lnbSearch_Click(object sender, System.EventArgs e)
		{
			string strFilter = GetContFilter();
			Bind_dgdContOr(strFilter);
			dgdContOr.SelectedIndex = -1;
			dgdLost.EditItemIndex = -1;
		}

		private void dgdContOr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string ContNo = dgdContOr.SelectedItem.Cells[0].Text.Trim();
			string FbkItem = dgdContOr.SelectedItem.Cells[5].Text.Trim();
			string OrItem = dgdContOr.SelectedItem.Cells[8].Text.Trim();
			string strFilter = "cont_contno='" + ContNo + "' AND fbk_fbkitem='" + FbkItem + "' AND or_oritem='" + OrItem + "'";

			this.sqlCmdInsLost.Connection.Open();
			System.Data.SqlClient.SqlTransaction myTrans = this.sqlCmdInsLost.Connection.BeginTransaction();
			this.sqlCmdInsLost.Transaction = myTrans;
			string OriginalCmd = this.sqlCmdInsLost.CommandText;

			this.sqlCmdInsLost.Parameters["@contno"].Value = ContNo;
			this.sqlCmdInsLost.Parameters["@fbkitem"].Value = FbkItem;
			this.sqlCmdInsLost.Parameters["@oritem"].Value = OrItem;
			this.sqlCmdInsLost.Parameters["@seq"].Value = "";
			int NewSeq = 0;

			try
			{
				//取得最大補書序號
				this.sqlCmdInsLost.CommandText = "SELECT ISNULL(MAX(lst_seq), 0) FROM c4_lost WHERE lst_syscd='C4' AND lst_contno=@contno AND lst_fbkitem=@fbkitem AND lst_oritem=@oritem";
				NewSeq = Convert.ToInt32(this.sqlCmdInsLost.ExecuteScalar()) + 1;

				//新增補書資料，預設rm_cont為''，rm_fgsent為'Y'，rm_date為補書標籤列印後才填入
				this.sqlCmdInsLost.CommandText = OriginalCmd;
				this.sqlCmdInsLost.Parameters["@seq"].Value = NewSeq.ToString("d2");
				this.sqlCmdInsLost.ExecuteNonQuery();

				myTrans.Commit();
				AlertMsg("缺書登錄項目成功，請修改填入缺書內容與缺書註記");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				myTrans.Rollback();
				AlertMsg("缺書登錄項目失敗，請通知聯絡人"+ex.Message);
			}
			this.sqlCmdInsLost.Connection.Close();

			Bind_dgdLost(strFilter);
			dgdLost.EditItemIndex = -1;
		}

		private void dgdLost_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = dgdContOr.SelectedItem.Cells[0].Text.Trim();
			string FbkItem = dgdContOr.SelectedItem.Cells[5].Text.Trim();
			string OrItem = dgdContOr.SelectedItem.Cells[8].Text.Trim();
			string strFilter = "cont_contno='" + ContNo + "' AND fbk_fbkitem='" + FbkItem + "' AND or_oritem='" + OrItem + "'";

			dgdLost.EditItemIndex = e.Item.ItemIndex;
			Bind_dgdLost(strFilter);

			//美觀
			((TextBox)dgdLost.Items[e.Item.ItemIndex].Cells[11].Controls[0]).Width = Unit.Pixel(100);
			((TextBox)dgdLost.Items[e.Item.ItemIndex].Cells[12].Controls[0]).Width = Unit.Pixel(100);
			((DropDownList)dgdLost.Items[e.Item.ItemIndex].Cells[13].Controls[1]).Width = Unit.Pixel(100);
		}

		private void dgdLost_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = dgdContOr.SelectedItem.Cells[0].Text.Trim();
			string FbkItem = dgdContOr.SelectedItem.Cells[5].Text.Trim();
			string OrItem = dgdContOr.SelectedItem.Cells[8].Text.Trim();
			string strFilter = "cont_contno='" + ContNo + "' AND fbk_fbkitem='" + FbkItem + "' AND or_oritem='" + OrItem + "'";

			dgdLost.EditItemIndex = -1;
			Bind_dgdLost(strFilter);
		}

		private void dgdLost_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = e.Item.Cells[1].Text.Trim();
			string FbkItem = e.Item.Cells[5].Text.Trim();
			string OrItem = e.Item.Cells[8].Text.Trim();
			string LstSeq = e.Item.Cells[10].Text.Trim();
			string strFilter = "cont_contno='" + ContNo + "' AND fbk_fbkitem='" + FbkItem + "' AND or_oritem='" + OrItem + "'";

			string strContent = ((TextBox)e.Item.Cells[11].Controls[0]).Text.Trim();
			string strReason = ((TextBox)e.Item.Cells[12].Controls[0]).Text.Trim();
			string strFgSent = ((DropDownList)e.Item.Cells[13].Controls[1]).SelectedItem.Value.Trim();

			this.sqlCmdDelUpdate.Connection.Open();
			try
			{
				this.sqlCmdDelUpdate.CommandText = "UPDATE c4_lost SET lst_cont='" + strContent + "', lst_rea='" + strReason + "', lst_fgsent='" + strFgSent + "' WHERE lst_syscd='C4' AND lst_contno='" + ContNo + "' AND lst_fbkitem='" + FbkItem + "' AND lst_oritem='" + OrItem + "' AND lst_seq='" + LstSeq + "'";
				this.sqlCmdDelUpdate.ExecuteNonQuery();
				AlertMsg("缺書資料修改成功");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("缺書資料修改失敗，請通知聯絡人");
			}
			this.sqlCmdDelUpdate.Connection.Close();

			dgdLost.EditItemIndex = -1;
			Bind_dgdLost(strFilter);
		}

		private void dgdLost_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = e.Item.Cells[1].Text.Trim();
			string FbkItem = e.Item.Cells[5].Text.Trim();
			string OrItem = e.Item.Cells[8].Text.Trim();
			string LstSeq = e.Item.Cells[10].Text.Trim();
			string strFilter = "cont_contno='" + ContNo + "' AND fbk_fbkitem='" + FbkItem + "' AND or_oritem='" + OrItem + "'";

			this.sqlCmdDelUpdate.Connection.Open();
			try
			{
				this.sqlCmdDelUpdate.CommandText = "DELETE FROM c4_lost WHERE lst_syscd='C4' AND lst_contno='" + ContNo + "' AND lst_fbkitem='" + FbkItem + "' AND lst_oritem='" + OrItem + "' AND lst_seq='" + LstSeq + "'";
				this.sqlCmdDelUpdate.ExecuteNonQuery();
				AlertMsg("缺書資料刪除成功");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("缺書資料刪除失敗，請通知聯絡人");
			}
			this.sqlCmdDelUpdate.Connection.Close();
			dgdLost.EditItemIndex = -1;
			Bind_dgdLost(strFilter);
		}
	}
}
