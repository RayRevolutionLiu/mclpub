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
	/// Summary description for ContCanceled.
	/// </summary>
	public class ContCanceled : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Label lblContCanceled;
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
					lblContCanceled.Text = "目前共有 " + DataCount.ToString() + " 筆註銷合約";
					lblContCanceled.Visible = true;
					//pnlNoHistory.Visible = false;
				}
				else
				{
					dgdCont.Visible = false;
					lblContCanceled.Visible = false;
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
			this.dgdCont.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdCont_PageIndexChanged);
			this.dgdCont.SelectedIndexChanged += new System.EventHandler(this.dgdCont_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region 連結該客戶的合約資料
		private int Bind_dgdCont()
		{
			Contracts cont = new Contracts();

			DataSet ds = cont.GetContCanceled();
			DataView dv = ds.Tables[0].DefaultView;
			
			dgdCont.DataSource = dv;
			dgdCont.DataBind();

			return dv.Count;
		}
		#endregion

		#region 換頁
		private void dgdCont_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdCont.CurrentPageIndex = e.NewPageIndex;

			Bind_dgdCont();
		}
		#endregion

		#region 取消合約註銷狀態
		private void dgdCont_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string contno = dgdCont.SelectedItem.Cells[0].Text.Trim();
			Contracts cont = new Contracts();
			bool success = cont.UpdateContRecoverCanceled(contno);
			if (!success)
			{
				jsAlertMsg("RECOVERCONTFAILED", "取消合約註銷狀態失敗，請通知聯絡人");
				return;
			}

			int DataCount = Bind_dgdCont();

			if (DataCount>0)
			{
				dgdCont.Visible = true;
				lblContCanceled.Text = "目前共有 " + DataCount.ToString() + " 筆註銷合約";
				lblContCanceled.Visible = true;
				//pnlNoHistory.Visible = false;
			}
			else
			{
				dgdCont.Visible = false;
				lblContCanceled.Visible = false;
				//pnlNoHistory.Visible = true;
			}
		}
		#endregion
	}
}
