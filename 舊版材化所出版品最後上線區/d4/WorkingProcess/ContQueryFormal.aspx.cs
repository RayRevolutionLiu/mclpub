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
using MRLPub.d4.DataTypes;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for ContQueryFormal.
	/// </summary>
	public class ContQueryFormal : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.LinkButton lnbBack;
		protected System.Web.UI.WebControls.Label lblCustFound;
		protected System.Web.UI.WebControls.DataGrid dgdCont;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				int DataCount = Bind_dgdCont();
				if (DataCount>0)
				{
					dgdCont.Visible = true;
					lblCustFound.Text = "此客戶共有 " + DataCount.ToString() + " 筆合約資料";
					lblCustFound.Visible = true;
					//pnlNoHistory.Visible = false;
				}
				else
				{
					dgdCont.Visible = false;
					lblCustFound.Visible = false;
					//pnlNoHistory.Visible = true;
				}
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
			this.lnbBack.Click += new System.EventHandler(this.lnbBack_Click);
			this.dgdCont.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdCont_PageIndexChanged);
			this.dgdCont.SelectedIndexChanged += new System.EventHandler(this.dgdCont_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region 回查詢畫面
		private void lnbBack_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("~/d4/WorkingProcess/ContQueryMaintain.aspx");
		}
		#endregion

		#region 連結該客戶的合約資料
		private int Bind_dgdCont()
		{
			string custno;
			if (Request.QueryString["custno"] == null || Request.QueryString["custno"] == "")
			{
				throw new Exception("客戶編號不能為空值");
			}
			else
			{
				custno = Request.QueryString["custno"];
			}

			Contracts cont = new Contracts();
			DataSet ds = cont.GetFormalContractsByCustNo(custno);
			DataView dv = ds.Tables[0].DefaultView;
			
			dgdCont.DataSource = dv;
			dgdCont.DataBind();

			Format_dgdCont();

			return dv.Count;
		}
		#endregion

		#region 格式化dgd_Cont的內容
		private void Format_dgdCont()
		{
			DateTime signdate, sdate, edate;
			foreach(DataGridItem dgi in dgdCont.Items)
			{
				//處理 簽約日期、合約起迄日
				try
				{
					signdate = DateTime.ParseExact(dgi.Cells[1].Text.Trim(), "yyyyMMdd", null);
				}
				catch
				{
					jsAlertMsg("SIGNDATEERROR", "資料庫中的簽約日期格式錯誤，請通知聯絡人");
					return;
				}

				try
				{
					sdate = DateTime.ParseExact(dgi.Cells[2].Text.Trim(), "yyyyMMdd", null);
				}
				catch
				{
					jsAlertMsg("SDATEERROR", "資料庫中的合約起始日期格式錯誤，請通知聯絡人");
					return;
				}

				try
				{
					edate = DateTime.ParseExact(dgi.Cells[3].Text.Trim(), "yyyyMMdd", null);
				}
				catch
				{
					jsAlertMsg("EDATEERROR", "資料庫中的合約結束日期格式錯誤，請通知聯絡人");
					return;
				}

				dgi.Cells[1].Text = signdate.ToString("yyyy/MM/dd");
				dgi.Cells[2].Text = sdate.ToString("yyyy/MM/dd");
				dgi.Cells[3].Text = edate.ToString("yyyy/MM/dd");

				//處理一次付清註記
				switch(dgi.Cells[7].Text.Trim())
				{
					case "0":
						dgi.Cells[7].Text = "否";
						break;	
					case "1":
						dgi.Cells[7].Text = "是";
						break;
					default:
						dgi.Cells[7].Text = "(錯誤)";
						break;
				}

				//處理結案註記
				switch(dgi.Cells[8].Text.Trim())
				{
					case "0":
						dgi.Cells[8].Text = "否";
						break;	
					case "1":
						dgi.Cells[8].Text = "是";
						break;
					default:
						dgi.Cells[8].Text = "(錯誤)";
						break;
				}

				//處理合約類別
				switch(dgi.Cells[9].Text.Trim())
				{
					case "01":
						dgi.Cells[9].Text = "一般";
						break;
					case "09":
						dgi.Cells[9].Text = "推廣";
						break;
					default:
						dgi.Cells[9].Text = "(錯誤)";
						break;
				}
			}
		}
		#endregion

		#region 選定合約
		private void dgdCont_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string contno = dgdCont.SelectedItem.Cells[0].Text.Trim();
			Response.Redirect("~/d4/WorkingProcess/ContMaintain.aspx?contno=" + contno);
		}
		#endregion

		#region 換頁
		private void dgdCont_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdCont.CurrentPageIndex = e.NewPageIndex;

			Bind_dgdCont();
		}
		#endregion
	}
}
