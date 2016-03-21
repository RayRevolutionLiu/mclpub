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
using MRLPub.d4.Configurations;
using MRLPub.d4.DataTypes;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for RemailAdd.
	/// </summary>
	public class RemailAdd : MRLPub.d4.Pages.Page
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
		protected System.Web.UI.WebControls.LinkButton lnbSearch;
		protected System.Web.UI.WebControls.DataGrid dgdContOr;
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Web.UI.WebControls.DataGrid dgdRemail;
		protected System.Web.UI.WebControls.Label lblMessage;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			//加入script的部分
			if (!IsClientScriptBlockRegistered("JSCALENDAR"))
			{
				System.IO.TextReader tr = System.IO.File.OpenText(Server.MapPath(".") + "\\ClientScripts\\jsCalendar.js");
				string script = tr.ReadToEnd();
				RegisterClientScriptBlock("JSCALENDAR", script);
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.lnbSearch.Click += new System.EventHandler(this.lnbSearch_Click);
			this.dgdContOr.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdContOr_PageIndexChanged);
			this.dgdContOr.SelectedIndexChanged += new System.EventHandler(this.dgdContOr_SelectedIndexChanged);
			this.dgdRemail.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdRemail_CancelCommand);
			this.dgdRemail.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdRemail_EditCommand);
			this.dgdRemail.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdRemail_UpdateCommand);
			this.dgdRemail.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdRemail_DeleteCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region 製作WHERE條件
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

			return strFilter;
		}
		#endregion

		#region 格式化dgdContOr
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
		#endregion

		#region 連結ContOr
		private void Bind_dgdContOr(string strFilter)
		{
			dgdRemail.Visible = false;

			//取得查詢條件字串
			ReMailBooks rm = new ReMailBooks();
			DataSet ds = rm.GetContOrMfrCustWithFilter(strFilter);
			DataView dv = ds.Tables[0].DefaultView;

			if (!(dv.Count>0))
			{
				//無資料
				jsAlertMsg("NOMATCHCASE", "查無符合資料的合約");
				dgdContOr.Visible = false;
				return;
			}
			
			dgdContOr.DataSource = dv;
			dgdContOr.DataBind();
			dgdContOr.Visible = true;

			Format_dgdContOr();
		}
		#endregion

		#region 取得補書狀態的index
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
		#endregion

		#region 取得補書狀態名稱
		protected object GetFgSentName(object fgsent)
		{
			string strReturn = "";
			switch(fgsent.ToString().Trim())
			{
				case "Y":
					strReturn = "可寄出";
					break;
				case "N":
					strReturn = "目前暫不寄出";
					break;
				case "C":
					strReturn = "已寄出";
					break;
				case "D":
					strReturn = "不處理";
					break;
				default:
					strReturn = "(DB ERROR)";
					break;
			}
			return strReturn;
		}
		#endregion

		#region 格式化dgdRemail
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
		#endregion

		#region 連結補書資料
		private void Bind_dgdRemail(string strFilter)
		{
			dgdRemail.Visible = true;
			ReMailBooks rm = new ReMailBooks();
			DataSet ds = rm.GetContRemailOrMfrCustWithFilter(strFilter);
			DataView dv = ds.Tables[0].DefaultView;

			if (dv.Count<=0)
			{
				//無資料
				lblMessage.Text = "目前該合約的該雜誌收件人尚無補書資料";
				lblMessage.Visible = true;
				dgdRemail.Visible = false;
				return;
			}
			
			lblMessage.Visible = false;
			dgdRemail.DataSource = dv;
			dgdRemail.DataBind();

			Format_dgdRemail();
		}
		#endregion

		#region 搜尋補書資料
		private void lnbSearch_Click(object sender, System.EventArgs e)
		{
			string strFilter = GetContFilter();
			Bind_dgdContOr(strFilter);
			dgdContOr.SelectedIndex = -1;
			dgdRemail.EditItemIndex = -1;
		}
		#endregion

		#region 新增補書
		private void dgdContOr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string ContNo = dgdContOr.SelectedItem.Cells[0].Text.Trim();
			string OrItem = dgdContOr.SelectedItem.Cells[5].Text.Trim();
//			string strFilter = "cont_contno='" + ContNo + "' AND or_oritem='" + OrItem + "'";
			string strFilter = "cont_contno='" + ContNo + "'";

			ReMailBooks rm = new ReMailBooks();
			string rm_seq = rm.AddRemail(ContNo, OrItem);

			if (rm_seq == null || rm_seq == "00" || rm_seq == "0")
			{
				jsAlertMsg("ADDREMAILFAILED", "新增補書失敗，請通知聯絡人");
				return;
			}
			else
			{
				jsAlertMsg("ADDREMAILSUCCESS", "新增補書項目成功，請修改填入補書內容與補書註記");
			}

			Bind_dgdRemail(strFilter);
			dgdRemail.EditItemIndex = -1;
		}
		#endregion

		#region 選定修改補書資料
		private void dgdRemail_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = e.Item.Cells[1].Text.Trim();
			string OrItem = e.Item.Cells[5].Text.Trim();
//			string strFilter = "cont_contno='" + ContNo + "' AND or_oritem='" + OrItem + "'";
			string strFilter = "cont_contno='" + ContNo + "'";

			dgdRemail.EditItemIndex = e.Item.ItemIndex;
			Bind_dgdRemail(strFilter);
		}
		#endregion

		#region 取消修改
		private void dgdRemail_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = e.Item.Cells[1].Text.Trim();
			string OrItem = e.Item.Cells[5].Text.Trim();
//			string strFilter = "cont_contno='" + ContNo + "' AND or_oritem='" + OrItem + "'";
			string strFilter = "cont_contno='" + ContNo + "'";

			dgdRemail.EditItemIndex = -1;
			Bind_dgdRemail(strFilter);
		}
		#endregion

		#region 修改補書資料
		private void dgdRemail_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = e.Item.Cells[1].Text.Trim();
			string OrItem = e.Item.Cells[5].Text.Trim();
			string RmSeq = e.Item.Cells[7].Text.Trim();
//			string strFilter = "cont_contno='" + ContNo + "' AND or_oritem='" + OrItem + "'";
			string strFilter = "cont_contno='" + ContNo + "'";
			string strContent = ((TextBox)e.Item.Cells[8].Controls[0]).Text.Trim();
			string strFgSent = ((DropDownList)e.Item.Cells[9].Controls[1]).SelectedItem.Value.Trim();

			ReMailBooks rm = new ReMailBooks();
			rm.UpdateRemail(ContNo, OrItem, RmSeq, strContent, strFgSent);
		
			dgdRemail.EditItemIndex = -1;
			Bind_dgdRemail(strFilter);
		}
		#endregion

		#region 刪除補書資料
		private void dgdRemail_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = e.Item.Cells[1].Text.Trim();
			string OrItem = e.Item.Cells[5].Text.Trim();
			string RmSeq = e.Item.Cells[7].Text.Trim();
//			string strFilter = "cont_contno='" + ContNo + "' AND or_oritem='" + OrItem + "'";
			string strFilter = "cont_contno='" + ContNo + "'";
			
			ReMailBooks rm = new ReMailBooks();
			rm.DeleteRemail(ContNo, OrItem, RmSeq);

			dgdRemail.EditItemIndex = -1;
			Bind_dgdRemail(strFilter);
		}
		#endregion

		#region 換頁
		private void dgdContOr_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdContOr.CurrentPageIndex = e.NewPageIndex;
			string strFilter = GetContFilter();
			Bind_dgdContOr(strFilter);
		}
		#endregion
	}
}
