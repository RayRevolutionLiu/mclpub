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
using MRLPub.d4.Configurations;
using MRLPub.d4.DataTypes;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for RptGetAd.
	/// </summary>
	public class RptGetAd : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxSDate;
		protected System.Web.UI.WebControls.TextBox tbxEDate;
		protected System.Web.UI.WebControls.Button btnGo;
		protected System.Web.UI.WebControls.Label lblyyyymmdd;
		protected System.Web.UI.WebControls.CheckBox cbxAddAdr;
		protected System.Web.UI.WebControls.Literal Literal1;
	
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
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnGo_Click(object sender, System.EventArgs e)
		{
			DateTime sdate;
			DateTime edate;
			if (tbxSDate.Text.Trim() == "")
			{
				jsAlertMsg("INVALIDSDATE", "區段起始日期不可空白，請輸入");
				return;
			}
			else
			{
				try
				{
					sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
				}
				catch
				{
					jsAlertMsg("INVALIDSDATE", "區段起始日期格式錯誤，請重新輸入");
					return;
				}
			}
			if (tbxEDate.Text.Trim() == "")
			{
				jsAlertMsg("INVALIDSDATE", "區段結束日期不可空白，請輸入");
				return;
			}
			else
			{
				try
				{
					edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
				}
				catch
				{
					jsAlertMsg("INVALIDEDATE", "區段結束日期格式錯誤，請重新輸入");
					return;
				}

			}
			Contracts cont = new Contracts();
			cont.RtpGetAd(sdate.ToString("yyyyMMdd"),edate.ToString("yyyyMMdd"), cbxAddAdr.Checked);
			string strbuf;
			if(cbxAddAdr.Checked)
				strbuf="RptGetAdList_Adr.aspx?whoami=" + this.WhoAmI.CName+"&strdate="+sdate.ToString("yyyy/MM/dd")+"~"+edate.ToString("yyyy/MM/dd");
			else
				strbuf="RptGetAdList.aspx?whoami=" + this.WhoAmI.CName+"&strdate="+sdate.ToString("yyyy/MM/dd")+"~"+edate.ToString("yyyy/MM/dd");
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";

		}
	}
}
