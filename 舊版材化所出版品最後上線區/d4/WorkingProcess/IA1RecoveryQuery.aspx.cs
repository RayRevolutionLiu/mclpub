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
	/// Summary description for IA1RecoveryQuery.
	/// </summary>
	public class IA1RecoveryQuery : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgdCont;
		protected System.Web.UI.WebControls.TextBox tbxMfrNm;
		protected System.Web.UI.WebControls.Label lblContHint;
		protected System.Web.UI.WebControls.TextBox tbxRecNm;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.LinkButton lnbQuery;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox tbxIano;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.lnbQuery.Click += new System.EventHandler(this.lnbQuery_Click);
			this.dgdCont.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdCont_PageIndexChanged);
			this.dgdCont.SelectedIndexChanged += new System.EventHandler(this.dgdCont_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

//		#region 直接跳到挑選開立發票項目
//		private void lngGo_Click(object sender, System.EventArgs e)
//		{
//			string Iano = tbxIano.Text.Trim();
//			if (Iano == "")
//			{
//				jsAlertMsg("BLANKIANO", "發票開立單編號不可空白");
//				return;
//			}
//			Invoice inv = new Invoice();
//			SqlDataReader dr = inv.GetSinglaIaByIano(Iano);
//
//			if (dr.Read())
//			{
//				if(dr["ia_status"].ToString().Trim()=="")
//					Response.Redirect("IA1RecoveryConfirm.aspx?Iano=" + Iano);
//				else if((dr["ia_status"].ToString().Trim()=="v")||(dr["ia_status"].ToString().Trim()=="5"))
//					jsAlertMsg("", "此發票已產生發票開立清單, 無法回復(Recovery)");
//				else if(dr["ia_status"].ToString().Trim()=="7")
//					jsAlertMsg("", "此發票已轉SAP, 無法回復(Recovery)");
//			}
//			else
//				jsAlertMsg("CONTNOTFOUND", "無此發票開立單編號，請檢查編號是否正確或通知業務負責人");
//
//		}
//		#endregion

		#region 查詢
		private void lnbQuery_Click(object sender, System.EventArgs e)
		{
			// Reset Index
			Search();

		}
		private void Search()
		{
			dgdCont.CurrentPageIndex = 0;
			dgdCont.SelectedIndex = -1;

			int DataCount = Bind_dgdCont();
			if (DataCount>0)
				lblMessage.Text = "查詢結果：找到 " + DataCount.ToString() + " 筆資料";
			else
				lblMessage.Text = "查無資料";
		}
		#endregion

		#region 換頁
		private void dgdCont_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdCont.CurrentPageIndex = e.NewPageIndex;
			Bind_dgdCont();
		}
		#endregion

		#region 連結合約資料
		/// <summary>
		/// 連結合約資料
		/// </summary>
		/// <returns>找到的資料筆數</returns>
		private int Bind_dgdCont()
		{
			Invoice inv = new Invoice();
			DataSet ds = inv.GetIA("", "");
			DataView dv = ds.Tables[0].DefaultView;

			string strFilter = GetFilters();
			if (strFilter.Trim() != "")
			{
				dv.RowFilter = strFilter;
			}

			dgdCont.DataSource = dv;
			dgdCont.DataBind();

			if (dgdCont.Items.Count>0)
			{
				dgdCont.Visible = true;

				for(int i=0; i<dgdCont.Items.Count; i++)
				{
					switch(dgdCont.Items[i].Cells[6].Text.Trim())
					{
						case "2":
							dgdCont.Items[i].Cells[6].Text = "二聯";
							break;
						case "3":
							dgdCont.Items[i].Cells[6].Text = "三聯";
							break;
						case "4":
							dgdCont.Items[i].Cells[6].Text = "其他";
							break;
						default:
							dgdCont.Items[i].Cells[6].Text = "";
							break;
					}
					switch(dgdCont.Items[i].Cells[7].Text.Trim())
					{
						case "1":
							dgdCont.Items[i].Cells[7].Text = "應稅5%";
							break;
						case "2":
							dgdCont.Items[i].Cells[7].Text = "零稅";
							break;
						case "3":
							dgdCont.Items[i].Cells[7].Text = "免稅";
							break;
						default:
							dgdCont.Items[i].Cells[7].Text = "";
							break;
					}
					switch(dgdCont.Items[i].Cells[8].Text.Trim())
					{
						case "06":
							dgdCont.Items[i].Cells[8].Text = "所內";
							break;
						case "07":
							dgdCont.Items[i].Cells[8].Text = "院內";
							break;
						case "":
							dgdCont.Items[i].Cells[8].Text = "一般";
							break;
						default:
							dgdCont.Items[i].Cells[8].Text = "";
							break;
					}
					switch(dgdCont.Items[i].Cells[10].Text.Trim())
					{
						case "v":
							dgdCont.Items[i].Cells[9].Text = "<font color=red>已產生清單</font>";
							((Button)dgdCont.Items[i].Cells[11].Controls[0]).Enabled=false;
							break;
						case "5":
							dgdCont.Items[i].Cells[9].Text = "<font color=red>已列印清單</font>";
							((Button)dgdCont.Items[i].Cells[11].Controls[0]).Enabled=false;
							break;
						case "7":
							dgdCont.Items[i].Cells[9].Text = "<font color=red>已轉SAP</font>";
							((Button)dgdCont.Items[i].Cells[11].Controls[0]).Enabled=false;
							break;
						default:
							dgdCont.Items[i].Cells[9].Text = "尚未產生清單";
							break;
					}

				}
			}
			else
			{
				dgdCont.Visible = false;
			}
			return dv.Count;

		}
		#endregion

		#region 組合查詢條件
		/// <summary>
		/// 組合查詢條件
		/// </summary>
		/// <returns>組合後的條件字串</returns>
		private string GetFilters()
		{
			int fc = 0;
			string strFilter = "";

			//廠商名稱
			if (tbxMfrNm.Text.Trim() != "")
			{
				strFilter += "mfr_inm LIKE '%" + tbxMfrNm.Text.Trim() + "%'";
				fc++;
			}

			//統一編號
			if (tbxMfrNo.Text.Trim() != "")
			{
				if (fc>0) strFilter += " AND ";
				strFilter += "ia_mfrno = '" + tbxMfrNo.Text.Trim() + "'";
				fc++;
			}

			//發票收件人
			if (tbxRecNm.Text.Trim() != "")
			{
				if (fc>0) strFilter += " AND ";
				strFilter += "ia_rnm LIKE '%" + tbxRecNm.Text.Trim() + "%'";
				fc++;
			}

			//發票開立單編號
			if (tbxIano.Text.Trim() != "")
			{
				if (fc>0) strFilter += " AND ";
				strFilter += "ia_iano = '" + tbxIano.Text.Trim() + "'";
				fc++;
			}

			return strFilter;
		}
		#endregion

		#region 選定要Recovery的發票
		private void dgdCont_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string iano = dgdCont.SelectedItem.Cells[0].Text.Trim();
			lblMessage.Text=iano.Trim();
			if(dgdCont.SelectedItem.Cells[10].Text.Trim() == "")
			{
				Invoice inv = new Invoice();
				bool flag = inv.RecoveryIA1(iano);
				if(flag)
				{
					Search();
					jsAlertMsg("", "發票開立單Recovery完成");
//					Response.Redirect("content.htm");
				}
				else
					jsAlertMsg("", "發票開立單Recovery失敗, 請稍後再試!!");
			}
			else if(dgdCont.SelectedItem.Cells[10].Text.Trim() == "v")
				jsAlertMsg("", "此發票開立單已產生清單,無法回復");
			else if(dgdCont.SelectedItem.Cells[10].Text.Trim() == "5")
				jsAlertMsg("", "此發票開立單已列印清單,無法回復");
			else if(dgdCont.SelectedItem.Cells[10].Text.Trim() == "7")
				jsAlertMsg("", "此發票開立單已轉SAP,無法回復");
		}
		#endregion
	}
}
