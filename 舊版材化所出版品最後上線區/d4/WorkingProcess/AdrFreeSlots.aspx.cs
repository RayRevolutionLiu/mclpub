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
	/// Summary description for AdrFreeSlots.
	/// </summary>
	public class AdrFreeSlots : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgdFreeSlots;
		protected System.Web.UI.WebControls.TextBox tbxAdMonth;
		protected System.Web.UI.WebControls.LinkButton lnbPrevMonth;
		protected System.Web.UI.WebControls.LinkButton lnbNextMonth;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.RadioButtonList rblAdCate;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				rblAdCate.SelectedIndex = 0;
				tbxAdMonth.Text = DateTime.Now.ToString("yyyyMMdd");
				LoadFreeSlots(DateTime.Now);
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
			this.rblAdCate.SelectedIndexChanged += new System.EventHandler(this.rblAdCate_SelectedIndexChanged);
			this.lnbPrevMonth.Click += new System.EventHandler(this.lnbPrevMonth_Click);
			this.lnbNextMonth.Click += new System.EventHandler(this.lnbNextMonth_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void LoadFreeSlots(DateTime adMonth)
		{
			Advertisements adr = new Advertisements();
			string adcate = rblAdCate.SelectedItem.Value;
			DataSet ds = adr.GetAdrSlots(adcate, adMonth);
			DataView dv = ds.Tables[0].DefaultView;
			
			dgdFreeSlots.DataSource = dv;
			dgdFreeSlots.DataBind();

			FormatSlots();
		}

		#region 更換頁面
		private void rblAdCate_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DateTime adMonth = DateTime.ParseExact(tbxAdMonth.Text.Trim(), "yyyyMMdd", null);
			LoadFreeSlots(adMonth);
		}
		#endregion

		#region 格式化剩餘空間表
		private void FormatSlots()
		{
			for(int i=0; i<dgdFreeSlots.Items.Count; i++)
			{
				for (int j=1; j<dgdFreeSlots.Items[i].Cells.Count; j++)
				{
					int x = Convert.ToInt32(dgdFreeSlots.Items[i].Cells[j].Text.Trim());
					int y = 20 - x;	//數值反向 y = 20 - x = 廣告剩餘空間

					if (x<0 || x>20) throw new Exception("廣告落版計數數值異常，請通知聯絡人");

					dgdFreeSlots.Items[i].Cells[j].Text = y.ToString();
					if (y==0)
					{
						dgdFreeSlots.Items[i].Cells[j].BackColor = Color.Red;
						dgdFreeSlots.Items[i].Cells[j].ForeColor = Color.White;
					}

					if (y==20)
					{
						dgdFreeSlots.Items[i].Cells[j].ForeColor = Color.Green;
					}
				}
			}
		}
		#endregion

		#region 上個月下個月
		private void lnbPrevMonth_Click(object sender, System.EventArgs e)
		{
			DateTime currentMonth = DateTime.ParseExact(tbxAdMonth.Text.Trim(), "yyyyMMdd", null);
			DateTime targetMonth = currentMonth.AddMonths(-1);
			tbxAdMonth.Text = targetMonth.ToString("yyyyMMdd");

			LoadFreeSlots(targetMonth);
		}

		private void lnbNextMonth_Click(object sender, System.EventArgs e)
		{
			DateTime currentMonth = DateTime.ParseExact(tbxAdMonth.Text.Trim(), "yyyyMMdd", null);
			DateTime targetMonth = currentMonth.AddMonths(1);
			tbxAdMonth.Text = targetMonth.ToString("yyyyMMdd");
		
			LoadFreeSlots(targetMonth);
		}
		#endregion
	}
}
