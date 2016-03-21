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
using MRLPub.d4.Configurations;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for IAQuery.
	/// </summary>
	public class IAQuery : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgdAdr;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.TextBox tbxDate;
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.Button btnSelAll;
		protected System.Web.UI.WebControls.Button btnDeSelAll;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnNextStep;
		protected System.Web.UI.WebControls.Button btnPreStep;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Panel pnlSelect;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DataGrid dgdConfirm;
		protected System.Web.UI.WebControls.Panel pnlConfirm;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Button btnHome;
		protected System.Web.UI.WebControls.Panel pnlBack;
		protected System.Web.UI.WebControls.Panel pnlSearch;
		protected System.Web.UI.WebControls.Label lblyyyymmdd;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
			this.btnDeSelAll.Click += new System.EventHandler(this.btnDeSelAll_Click);
			this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
			this.btnPreStep.Click += new System.EventHandler(this.btnPreStep_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			if(tbxDate.Text.Trim()=="")
			{
				lblMessage.Text = "<<<請輸入日期再進行查詢>>>";
				return;
			}
			DateTime Date1;// = DateTime.Parse(tbxDate.Text.Trim());
			try
			{
				Date1 = DateTime.ParseExact(tbxDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("SDATEERROR", "截止播出日日期格式錯誤，請重新輸入");
				return;
			}
			Bind_dgdAdr();
		}
		#region Bind_dgdAdr
		private void Bind_dgdAdr()
		{
			DateTime Date1 = DateTime.Parse(tbxDate.Text.Trim());
			string strDate = Date1.ToString("yyyyMMdd");
			Advertisements adr = new Advertisements();
			DataSet ds = adr.GetAdrForIA(strDate.Trim());
			DataView dv = ds.Tables[0].DefaultView;
			if(dv.Count>0)
			{
				pnlSelect.Visible=true;
				pnlConfirm.Visible = false;
				dgdAdr.Visible=true;
				dgdAdr.DataSource = dv;
				dgdAdr.DataBind();
			
				string strYYYYMM = strDate.Substring(0, 6);
				string yyyymm;
				for (int i=0; i<dgdAdr.Items.Count; i++)
				{
					// 刊登日 -- 針對不同月份, 整行給予不同顏色標示
					// 而且設定為'未選取'狀態
					yyyymm = dgdAdr.Items[i].Cells[8].Text.Substring(0, 6);
					//Response.Write("yyyymm= " + yyyymm + "<br>");
					if(yyyymm != strYYYYMM)
					{
						dgdAdr.Items[i].Cells[8].ForeColor = Color.LimeGreen;
						dgdAdr.Items[i].BackColor = Color.MistyRose;//.Lavender;
						((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked = false;
					}
				}
				lblMessage.Text = "<<<目前尚有 "+dv.Count.ToString()+" 筆落版資料尚未開立發票!>>>";
			}
			else
			{
				pnlSelect.Visible=false;
				lblMessage.Text = "沒有可開立發票之落版明細";
			}
		}
		#endregion

		#region 格式化廣告資料
		protected object MatchAdCate(object adcate)
		{
			string transAdCate = "";
			switch(adcate.ToString())
			{
				case "M":
					transAdCate = "首頁";
					break;
				case "I":
					transAdCate = "內頁";
					break;
				case "N":
					transAdCate = "奈米";
					break;
				default:
					throw new Exception("資料庫原生廣告頁面資料錯誤，請通知聯絡人");
					break;
			}
			return transAdCate;
		}

		protected object MatchKeyword(object keyword)
		{
			string transKeyword = "";
			switch(keyword.ToString())
			{
				case "h0":
					transKeyword = "正中";
					break;
				case "h1":
					transKeyword = "右一";
					break;
				case "h2":
					transKeyword = "右二";
					break;
				case "h3":
					transKeyword = "右三";
					break;
				case "h4":
					transKeyword = "右四";
					break;
				case "w1":
					transKeyword = "右文一";
					break;
				case "w2":
					transKeyword = "右文二";
					break;
				case "w3":
					transKeyword = "右文三";
					break;
				case "w4":
					transKeyword = "右文四";
					break;
				case "w5":
					transKeyword = "右文五";
					break;
				case "w6":
					transKeyword = "右文六";
					break;
				default:
					throw new Exception("資料庫原生廣告位置資料錯誤，請通知聯絡人");
					break;
			}
			return transKeyword;
		}

		protected object MatchFgitri(object fgitri)
		{
			string transFgitri = "";
			switch(fgitri.ToString().Trim())
			{
				case "06":
					transFgitri = "所內";
					break;
				case "07":
					transFgitri = "院內";
					break;
				case "":
					transFgitri = "一般";
					break;
				default:
					throw new Exception("資料庫原生廣告頁面資料錯誤，請通知聯絡人");
					break;
			}
			return transFgitri;
		}
		#endregion

		#region 全選，清選
		private void btnSelAll_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//先檢查是否Enable
				if (((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Enabled == true)
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked = true;
				}
			}
		}

		private void btnDeSelAll_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//先檢查是否Enable
				if (((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Enabled == true)
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked = false;
				}
			}
		}
		#endregion

		#region 下一步
		private void btnNextStep_Click(object sender, System.EventArgs e)
		{
			
			Literal1.Text="";
			//將資料庫中殘存的adr_fginved = 'v'清為 ''
			Advertisements adr = new Advertisements();
			adr.ClearAdrFginved();

			//將勾選的落版資料adr_fginved = 'v'
			int	i;
			for(i=0; i<dgdAdr.Items.Count; i++)
			{
				if(((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Checked == true)
				{
					adr.UpdateAdrFginved(dgdAdr.Items[i].Cells[1].Text.Trim(), dgdAdr.Items[i].Cells[7].Text.Trim(), dgdAdr.Items[i].Cells[8].Text.Trim(), "v");
				}
			}
			//讀出資料
			DateTime Date1 = DateTime.Parse(tbxDate.Text.Trim());
			string strDate = Date1.ToString("yyyyMMdd");
//			Advertisements adr = new Advertisements();
			DataSet ds = adr.GetAdrForIA(strDate.Trim());
			DataView dv = ds.Tables[0].DefaultView;
			dv.RowFilter = "adr_fginved = 'v'";
			if(dv.Count>0)
			{
				pnlSelect.Visible = false;
				pnlConfirm.Visible = true;
				dgdConfirm.Visible=true;
				dgdConfirm.DataSource = dv;
				dgdConfirm.DataBind();
			
				string strYYYYMM = strDate.Substring(0, 6);
				string yyyymm;
				for (i=0; i<dgdConfirm.Items.Count; i++)
				{
					// 刊登日 -- 針對不同月份, 整行給予不同顏色標示
					yyyymm = dgdConfirm.Items[i].Cells[7].Text.Substring(0, 6);
					//Response.Write("yyyymm= " + yyyymm + "<br>");
					if(yyyymm != strYYYYMM)
					{
						dgdConfirm.Items[i].Cells[7].ForeColor = Color.LimeGreen;
						dgdConfirm.Items[i].BackColor = Color.Lavender;
					}
				}
				lblMessage.Text = "<<<已選取 "+dv.Count.ToString()+" 筆落版資料>>>";
			}
			else
			{
				lblMessage.Text = "沒有選取任何落版明細";
			}
		}

		#endregion

		#region 上一步
		private void btnPreStep_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			
			//將資料庫中殘存的adr_fginved = 'v'清為 ''
			Advertisements adr = new Advertisements();
			adr.ClearAdrFginved();

			//讀出資料
			Bind_dgdAdr();
		}

		#endregion

		#region 取消, 將選取註記清除, 回首頁
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			Advertisements adr = new Advertisements();
			adr.ClearAdrFginved();
			Response.Redirect("content.htm");
		}
		#endregion

		#region 列印預覽清單
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Invoice inv = new Invoice();
			inv.IAPreList();
			string	strbuf="RptIA_PreList.aspx?whoami=" + this.WhoAmI.CName+"&strdate="+tbxDate.Text.Trim();
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}
		#endregion

		#region 產生iab、ia、iad
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			Invoice inv = new Invoice();
			inv.IAPreList();
			string empno = this.WhoAmI.EmpNo.Trim();
			bool flag = inv.AddBatchIa(empno);
			if(flag)
			{
				jsAlertMsg("INVALIDPERIOD", "新增發票開立單作業完成!!");
				pnlSearch.Visible = false;
				pnlConfirm.Visible=false;
				pnlBack.Visible=true;
			}
			else
				jsAlertMsg("INVALIDPERIOD", "新增發票開立單作業發生錯誤, 請重新新增或稍後再進行");
		}
		#endregion

		#region 回主選單
		private void btnHome_Click(object sender, System.EventArgs e)
		{
			string home = D4Settings.HomeUrl;
			Response.Redirect(home);
		}
		#endregion

	}
}
