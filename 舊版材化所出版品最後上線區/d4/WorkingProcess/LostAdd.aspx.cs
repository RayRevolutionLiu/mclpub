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
	/// Summary description for LostAdd.
	/// </summary>
	public class LostAdd : MRLPub.d4.Pages.Page
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
		protected System.Web.UI.WebControls.DataGrid dgdLost;
		protected System.Web.UI.WebControls.Label lblMessage;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
			}

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
			this.dgdLost.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLost_CancelCommand);
			this.dgdLost.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLost_EditCommand);
			this.dgdLost.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLost_UpdateCommand);
			this.dgdLost.DeleteCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdLost_DeleteCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region 取得WHERE條件字串
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
		#endregion

		#region 格式化ContOr
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

		#region 連結ContOr資料
		private void Bind_dgdContOr(string strFilter)
		{
			dgdLost.Visible = false;
			LostBooks lst = new LostBooks();
			DataSet ds = lst.GetContOrMfrCustFbkRamtWithFilter(strFilter);
			DataView dv = ds.Tables[0].DefaultView;

			if (dv.Count<=0)
			{
				//無資料			
				lblInfo.Visible = true;
				lblInfo.Text = "目前查無符合查詢條件的合約資料";
				dgdContOr.Visible = false;
				return;
			}
			
			lblInfo.Visible = false;
			dgdContOr.Visible = true;
			dgdContOr.DataSource = dv;
			dgdContOr.DataBind();

			Format_dgdContOr();
		}
		#endregion

		#region 取得FgSent的index
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

		#region 取得fgSent的Name
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

		#region 格式化dgdLost
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
		#endregion

		#region 連結缺書資料
		private void Bind_dgdLost(string strFilter)
		{
			dgdLost.Visible = true;
			LostBooks lst = new LostBooks();
			DataSet ds = lst.GetContOrMfrCustFbkRamtLostWithFilter(strFilter);
			DataView dv = ds.Tables[0].DefaultView;

			if (dv.Count<=0)
			{
				//無資料
				lblMessage.Visible = true;
				lblMessage.Text = "目前該誌收件人無缺書資料";
				dgdLost.Visible = false;
				return;
			}
			
			lblMessage.Visible = false;
			dgdLost.DataSource = dv;
			dgdLost.DataBind();

			Format_dgdLost();
		}
		#endregion

		#region 搜尋合約
		private void lnbSearch_Click(object sender, System.EventArgs e)
		{
			string strFilter = GetContFilter();
			Bind_dgdContOr(strFilter);
			dgdContOr.SelectedIndex = -1;
			dgdLost.EditItemIndex = -1;
		}
		#endregion

		#region 缺書登錄
		private void dgdContOr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string ContNo = dgdContOr.SelectedItem.Cells[0].Text.Trim();
			string FbkItem = dgdContOr.SelectedItem.Cells[5].Text.Trim();
			string OrItem = dgdContOr.SelectedItem.Cells[8].Text.Trim();
			string strFilter = "cont_contno='" + ContNo + "' AND fbk_fbkitem='" + FbkItem + "' AND or_oritem='" + OrItem + "'";

			LostBooks lst = new LostBooks();
			string lst_seq = lst.AddLost(ContNo, FbkItem, OrItem);

			if (lst_seq == null || lst_seq.Trim() == "" || lst_seq == "0" || lst_seq == "00")
			{
				jsAlertMsg("ADDLOSTFAILED", "缺書登錄項目失敗，請通知聯絡人");
				
			}
			else
			{
				jsAlertMsg("ADDLOSTSUCCESS", "缺書登錄項目成功，請修改填入缺書內容與缺書註記");
			}


			Bind_dgdLost(strFilter);
			dgdLost.EditItemIndex = -1;
		}
		#endregion

		#region 選定編輯缺書資料
		private void dgdLost_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = e.Item.Cells[1].Text.Trim();
			string FbkItem = e.Item.Cells[5].Text.Trim();
			string OrItem = e.Item.Cells[8].Text.Trim();
			string strFilter = "cont_contno='" + ContNo + "' AND fbk_fbkitem='" + FbkItem + "' AND or_oritem='" + OrItem + "'";

			dgdLost.EditItemIndex = e.Item.ItemIndex;
			Bind_dgdLost(strFilter);

			//美觀
			((TextBox)dgdLost.Items[e.Item.ItemIndex].Cells[11].Controls[0]).Width = Unit.Pixel(100);
			((TextBox)dgdLost.Items[e.Item.ItemIndex].Cells[12].Controls[0]).Width = Unit.Pixel(100);
			((DropDownList)dgdLost.Items[e.Item.ItemIndex].Cells[13].Controls[1]).Width = Unit.Pixel(100);
		}
		#endregion

		#region 取消編輯缺書資料
		private void dgdLost_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = e.Item.Cells[1].Text.Trim();
			string FbkItem = e.Item.Cells[5].Text.Trim();
			string OrItem = e.Item.Cells[8].Text.Trim();
			string strFilter = "cont_contno='" + ContNo + "' AND fbk_fbkitem='" + FbkItem + "' AND or_oritem='" + OrItem + "'";

			dgdLost.EditItemIndex = -1;
			Bind_dgdLost(strFilter);
		}
		#endregion

		#region 儲存修改缺書資料
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

			LostBooks lst = new LostBooks();
			lst.UpdateLost(ContNo, FbkItem, OrItem, LstSeq, strContent, strReason, strFgSent);

			dgdLost.EditItemIndex = -1;
			Bind_dgdLost(strFilter);
		}
		#endregion

		#region 刪除缺書資料
		private void dgdLost_DeleteCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string ContNo = e.Item.Cells[1].Text.Trim();
			string FbkItem = e.Item.Cells[5].Text.Trim();
			string OrItem = e.Item.Cells[8].Text.Trim();
			string LstSeq = e.Item.Cells[10].Text.Trim();

			string strFilter = "cont_contno='" + ContNo + "' AND fbk_fbkitem='" + FbkItem + "' AND or_oritem='" + OrItem + "'";

			LostBooks lst = new LostBooks();
			lst.DeleteLost(ContNo, FbkItem, OrItem, LstSeq);

			dgdLost.EditItemIndex = -1;
			Bind_dgdLost(strFilter);
		}
		#endregion

		#region 換頁
		private void dgdContOr_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			string strFilter = GetContFilter();
			dgdContOr.CurrentPageIndex = e.NewPageIndex;
			Bind_dgdContOr(strFilter);
		}
		#endregion
	}
}
