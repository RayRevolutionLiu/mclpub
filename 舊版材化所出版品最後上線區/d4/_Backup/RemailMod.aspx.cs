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
	/// Summary description for RemailMod.
	/// </summary>
	public class RemailMod : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.DataGrid dgdRemail;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPub;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaContOr;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaRemailOr;
		protected System.Data.SqlClient.SqlCommand sqlCmdInsRemail;
		protected System.Data.SqlClient.SqlCommand sqlCmdDelUpdate;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
	
		public RemailMod()
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

			this.sqlDaRemailOr = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCnnMRLPub = new System.Data.SqlClient.SqlConnection();
			this.sqlDaContOr = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCmdDelUpdate = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdInsRemail = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.lnbSearch.Click += new System.EventHandler(this.lnbSearch_Click);
			this.dgdContOr.SelectedIndexChanged += new System.EventHandler(this.dgdContOr_SelectedIndexChanged);
			this.dgdRemail.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdRemail_CancelCommand);
			this.dgdRemail.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdRemail_EditCommand);
			this.dgdRemail.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdRemail_UpdateCommand);
			this.dgdRemail.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdRemail_DeleteCommand);
			// 
			// sqlDaRemailOr
			// 
			this.sqlDaRemailOr.SelectCommand = this.sqlSelectCommand2;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.c4_cont.cont_syscd, dbo.c4_cont.cont_contno, dbo.c4_remail.rm_mseq, dbo.c4_remail.rm_seq, dbo.c4_remail.rm_cont, dbo.c4_remail.rm_date, dbo.c4_remail.rm_fgsent, dbo.c4_or.or_nm, dbo.c4_or.or_jbti, dbo.c4_or.or_addr, dbo.c4_or.or_zip, dbo.c4_or.or_tel, dbo.c4_or.or_fax, dbo.c4_or.or_cell, dbo.c4_or.or_email, dbo.c4_or.or_fgmosea, dbo.c4_or.or_contno, dbo.c4_or.or_oritem, dbo.c4_or.or_syscd, dbo.c4_remail.rm_contno, dbo.c4_remail.rm_syscd, dbo.c4_cont.cont_conttp, dbo.mfr.mfr_inm, dbo.mfr.mfr_mfrno, dbo.cust.cust_nm, dbo.cust.cust_custno FROM dbo.c4_cont INNER JOIN dbo.c4_remail ON dbo.c4_cont.cont_syscd = dbo.c4_remail.rm_syscd AND dbo.c4_cont.cont_contno = dbo.c4_remail.rm_contno INNER JOIN dbo.c4_or ON dbo.c4_cont.cont_syscd = dbo.c4_or.or_syscd AND dbo.c4_cont.cont_contno = dbo.c4_or.or_contno AND dbo.c4_remail.rm_mseq = dbo.c4_or.or_oritem INNER JOIN dbo.mfr ON dbo.c4_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.cust ON dbo.c4_cont.cont_custno = dbo.cust.cust_custno";
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
			// sqlCmdDelUpdate
			// 
			this.sqlCmdDelUpdate.Connection = this.sqlCnnMRLPub;
			// 
			// sqlCmdInsRemail
			// 
			this.sqlCmdInsRemail.CommandText = "INSERT INTO dbo.c4_remail (rm_syscd, rm_contno, rm_mseq, rm_seq, rm_cont, rm_date" +
				", rm_fgsent) VALUES (\'C4\', @contno, @mseq, @seq, \'\', \'\', \'Y\')";
			this.sqlCmdInsRemail.Connection = this.sqlCnnMRLPub;
			this.sqlCmdInsRemail.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsRemail.Parameters.Add(new System.Data.SqlClient.SqlParameter("@mseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsRemail.Parameters.Add(new System.Data.SqlClient.SqlParameter("@seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "rm_mseq", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c4_cont.cont_syscd, dbo.c4_cont.cont_contno, dbo.c4_cont.cont_custno, dbo.c4_cont.cont_conttp, dbo.c4_cont.cont_signdate, dbo.c4_cont.cont_sdate, dbo.c4_cont.cont_edate, dbo.c4_cont.cont_mfrno, dbo.c4_or.or_nm, dbo.c4_or.or_jbti, dbo.c4_or.or_addr, dbo.c4_or.or_tel, dbo.cust.cust_nm, dbo.mfr.mfr_inm, dbo.c4_or.or_contno, dbo.c4_or.or_oritem, dbo.c4_or.or_syscd, dbo.cust.cust_custno, dbo.mfr.mfr_mfrno, dbo.c4_remail.rm_seq, dbo.c4_remail.rm_cont, dbo.c4_remail.rm_date, dbo.c4_remail.rm_fgsent, dbo.c4_remail.rm_contno, dbo.c4_remail.rm_mseq, dbo.c4_remail.rm_syscd FROM dbo.c4_cont INNER JOIN dbo.c4_or ON dbo.c4_cont.cont_syscd = dbo.c4_or.or_syscd AND dbo.c4_cont.cont_contno = dbo.c4_or.or_contno INNER JOIN dbo.cust ON dbo.c4_cont.cont_custno = dbo.cust.cust_custno INNER JOIN dbo.mfr ON dbo.c4_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.c4_remail ON dbo.c4_cont.cont_syscd = dbo.c4_remail.rm_syscd AND dbo.c4_cont.cont_contno = dbo.c4_remail.rm_contno AND dbo.c4_or.or_oritem = dbo.c4_remail.rm_mseq";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPub;
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

//			//寄書情況
//			if (fcount>0) strFilter += " AND ";
//			switch(this.rblSent.SelectedItem.Value.Trim())
//			{
//				case "0":
//					strFilter += "(rm_fgsent='Y' OR rm_fgsent='N')";
//					break;
//				case "1":
//					strFilter += "(rm_fgsent='C')";
//					break;
//				case "2":
//					strFilter += "(rm_fgsent='d')";
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
			//第一層的filter
			string strFilter1="";
			switch(this.rblSent.SelectedItem.Value.Trim())
			{
				case "0":
					strFilter1 += "(rm_fgsent='Y' OR rm_fgsent='N')";
					break;
				case "1":
					strFilter1 += "(rm_fgsent='C')";
					break;
				case "2":
					strFilter1 += "(rm_fgsent='d')";
					break;
			}
			
			string strCmd1 = "SELECT DISTINCT dbo.c4_cont.cont_syscd, dbo.c4_cont.cont_contno, dbo.c4_cont.cont_custno, dbo.c4_cont.cont_conttp, "+
							"dbo.c4_cont.cont_signdate, dbo.c4_cont.cont_sdate, dbo.c4_cont.cont_edate, dbo.c4_cont.cont_mfrno, dbo.c4_or.or_nm, "+
							"dbo.c4_or.or_jbti, dbo.c4_or.or_addr, dbo.c4_or.or_tel, dbo.cust.cust_nm, dbo.mfr.mfr_inm, "+
							"dbo.c4_or.or_contno, dbo.c4_or.or_oritem, dbo.c4_or.or_syscd, dbo.cust.cust_custno, dbo.mfr.mfr_mfrno "+
							"FROM dbo.c4_cont INNER JOIN dbo.c4_or ON "+
							"dbo.c4_cont.cont_syscd = dbo.c4_or.or_syscd AND dbo.c4_cont.cont_contno = dbo.c4_or.or_contno "+
							"INNER JOIN dbo.cust ON dbo.c4_cont.cont_custno = dbo.cust.cust_custno "+
							"INNER JOIN dbo.mfr ON dbo.c4_cont.cont_mfrno = dbo.mfr.mfr_mfrno INNER JOIN dbo.c4_remail ON "+		
							"dbo.c4_cont.cont_syscd = dbo.c4_remail.rm_syscd AND dbo.c4_cont.cont_contno = dbo.c4_remail.rm_contno AND dbo.c4_or.or_oritem = dbo.c4_remail.rm_mseq"+
							" WHERE " + strFilter1;
			string strCmd2 = "SELECT * FROM (" + strCmd1 + ") DRIVERTBL";
			this.sqlDaContOr.SelectCommand.CommandText = strCmd2;

			dgdRemail.Visible = false;
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

		private void Format_dgdRemail()
		{
			for (int i=0; i<dgdRemail.Items.Count; i++)
			{
				if (dgdRemail.Items[i].Cells[2].Text.Trim() == "01")
					dgdRemail.Items[i].Cells[2].Text = "一般";
				else
					dgdRemail.Items[i].Cells[2].Text = "推廣";
			}
		}

		private void Bind_dgdRemail(string strFilter)
		{
			dgdRemail.Visible = true;
			DataSet ds = new DataSet();
			this.sqlDaRemailOr.Fill(ds, "REMAILOR");
			DataView dv = ds.Tables["REMAILOR"].DefaultView;
			dv.RowFilter = strFilter;

			if (!(dv.Count>0))
			{
				//無資料
				AlertMsg("無補書資料");
				return;
			}
			
			dgdRemail.DataSource = dv;
			dgdRemail.DataBind();

			Format_dgdRemail();
		}

		private void lnbSearch_Click(object sender, System.EventArgs e)
		{
			string strFilter = GetContFilter();
			Bind_dgdContOr(strFilter);
			dgdContOr.SelectedIndex = -1;
			dgdRemail.EditItemIndex = -1;
		}

		private void dgdContOr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string ContNo = dgdContOr.SelectedItem.Cells[0].Text.Trim();
			string OrItem = dgdContOr.SelectedItem.Cells[5].Text.Trim();
			string strFilter = "cont_contno='" + ContNo + "' AND or_oritem='" + OrItem + "'";

			//查詢不做這段
//			this.sqlCmdInsRemail.Connection.Open();
//			System.Data.SqlClient.SqlTransaction myTrans = this.sqlCmdInsRemail.Connection.BeginTransaction();
//			this.sqlCmdInsRemail.Transaction = myTrans;
//			string OriginalCmd = this.sqlCmdInsRemail.CommandText;
//
//			this.sqlCmdInsRemail.Parameters["@contno"].Value = ContNo;
//			this.sqlCmdInsRemail.Parameters["@mseq"].Value = OrItem;
//			this.sqlCmdInsRemail.Parameters["@seq"].Value = "";
//			int NewSeq = 0;
//
//			try
//			{
//				//取得最大補書序號
//				this.sqlCmdInsRemail.CommandText = "SELECT ISNULL(MAX(rm_seq), 0) FROM c4_remail WHERE rm_syscd='C4' AND rm_contno=@contno AND rm_mseq=@mseq";
//				NewSeq = Convert.ToInt32(this.sqlCmdInsRemail.ExecuteScalar()) + 1;
//
//				//新增補書資料，預設rm_cont為''，rm_fgsent為'Y'，rm_date為補書標籤列印後才填入
//				this.sqlCmdInsRemail.CommandText = OriginalCmd;
//				this.sqlCmdInsRemail.Parameters["@seq"].Value = NewSeq.ToString("d2");
//				this.sqlCmdInsRemail.ExecuteNonQuery();
//
//				myTrans.Commit();
//				AlertMsg("新增補書項目成功，請修改填入補書內容與補書註記");
//			}
//			catch(System.Data.SqlClient.SqlException ex)
//			{
//				myTrans.Rollback();
//				AlertMsg("新增補書項目失敗，請通知聯絡人"+ex.Message);
//			}
//			this.sqlCmdInsRemail.Connection.Close();

			Bind_dgdRemail(strFilter);
			dgdRemail.EditItemIndex = -1;
		}

		private void dgdRemail_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = dgdContOr.SelectedItem.Cells[0].Text.Trim();
			string OrItem = dgdContOr.SelectedItem.Cells[5].Text.Trim();
			string strFilter = "cont_contno='" + ContNo + "' AND or_oritem='" + OrItem + "'";

			dgdRemail.EditItemIndex = e.Item.ItemIndex;
			Bind_dgdRemail(strFilter);
		}

		private void dgdRemail_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = dgdContOr.SelectedItem.Cells[0].Text.Trim();
			string OrItem = dgdContOr.SelectedItem.Cells[5].Text.Trim();
			string strFilter = "cont_contno='" + ContNo + "' AND or_oritem='" + OrItem + "'";

			dgdRemail.EditItemIndex = -1;
			Bind_dgdRemail(strFilter);
		}

		private void dgdRemail_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = e.Item.Cells[1].Text.Trim();
			string OrItem = e.Item.Cells[5].Text.Trim();
			string RmSeq = e.Item.Cells[7].Text.Trim();
			string strFilter = "cont_contno='" + ContNo + "' AND or_oritem='" + OrItem + "'";
			string strContent = ((TextBox)e.Item.Cells[8].Controls[0]).Text.Trim();
			string strFgSent = ((DropDownList)e.Item.Cells[9].Controls[1]).SelectedItem.Value.Trim();
			
			this.sqlCmdDelUpdate.Connection.Open();
			try
			{
				this.sqlCmdDelUpdate.CommandText = "UPDATE c4_remail SET rm_cont='" + strContent + "', rm_fgsent='" + strFgSent + "' WHERE rm_syscd='C4' AND rm_contno='" + ContNo + "' AND rm_mseq='" + OrItem + "' AND rm_seq='" + RmSeq + "'";
				this.sqlCmdDelUpdate.ExecuteNonQuery();
				AlertMsg("補書資料修改成功");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("補書資料修改失敗，請通知聯絡人");
			}
			this.sqlCmdDelUpdate.Connection.Close();

			dgdRemail.EditItemIndex = -1;
			Bind_dgdRemail(strFilter);
		}

		private void dgdRemail_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = e.Item.Cells[1].Text.Trim();
			string OrItem = e.Item.Cells[5].Text.Trim();
			string RmSeq = e.Item.Cells[7].Text.Trim();
			string strFilter = "cont_contno='" + ContNo + "' AND or_oritem='" + OrItem + "'";
			
			this.sqlCmdDelUpdate.Connection.Open();
			try
			{
				this.sqlCmdDelUpdate.CommandText = "DELETE FROM c4_remail WHERE rm_syscd='C4' AND rm_contno='" + ContNo + "' AND rm_mseq='" + OrItem + "' AND rm_seq='" + RmSeq + "'";
				this.sqlCmdDelUpdate.ExecuteNonQuery();
				AlertMsg("補書資料刪除成功");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("補書資料刪除失敗，請通知聯絡人");
			}
			this.sqlCmdDelUpdate.Connection.Close();

			dgdRemail.EditItemIndex = -1;
			Bind_dgdRemail(strFilter);
		}
	}
}
