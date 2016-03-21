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
using System.Text;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for RptFileUpQuery.
	/// </summary>
	public class RptFileUpQuery : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxSDate;
		protected System.Web.UI.WebControls.TextBox tbxEDate;
		protected System.Web.UI.WebControls.Label lblyyyymmdd;
		protected System.Web.UI.WebControls.DropDownList ddlEmpData;
		protected System.Web.UI.WebControls.CheckBox cbxKeyword;
		protected System.Web.UI.WebControls.DropDownList ddlKeyword;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.CheckBox cbxSrspn;
		protected System.Web.UI.WebControls.Literal Literal1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				Bind_ddlEmpData();
			}
			if (!IsClientScriptBlockRegistered("JSCALENDAR"))
			{
				System.IO.TextReader tr = System.IO.File.OpenText(Server.MapPath(".") + "\\ClientScripts\\jsCalendar.js");
				string script = tr.ReadToEnd();
				RegisterClientScriptBlock("JSCALENDAR", script);
			}

			if (!IsClientScriptBlockRegistered("JSCONTNEW"))
			{
				System.IO.TextReader tr = System.IO.File.OpenText(Server.MapPath(".") + "\\ClientScripts\\jsContNew.js");
				string script = tr.ReadToEnd();
				RegisterClientScriptBlock("JSCONTNEW", script);
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
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		#region 連結員工資料
		private void Bind_ddlEmpData()
		{
			Srspns srspn = new Srspns();
			DataSet ds = srspn.GetSrspns();
			DataView dv = ds.Tables[0].DefaultView;

			this.ddlEmpData.DataTextField = "srspn_cname";
			this.ddlEmpData.DataValueField = "srspn_empno";
			this.ddlEmpData.DataSource = dv;
			this.ddlEmpData.DataBind();

			ddlEmpData.SelectedIndex = -1;
			if (ddlEmpData.Items.FindByValue(WhoAmI.EmpNo) != null)
				ddlEmpData.Items.FindByValue(WhoAmI.EmpNo).Selected = true;
			else
				ddlEmpData.SelectedIndex = 0;
		}
		#endregion

		#region 產生Query條件
		private string GetFilter()
		{
			int fc = 0;
			StringBuilder sb = new StringBuilder();
			//廣告刊登日期
			DateTime sdate;
			DateTime edate;
			if (tbxSDate.Text.Trim() == "")
			{
				jsAlertMsg("DateEmpty", "區段起始日期不可空白，請輸入");
				return "error";
			}
			else
			{
				try
				{
					sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
				}
				catch
				{
					jsAlertMsg("DateEmpty", "區段起始日期格式錯誤，請重新輸入");
					return "error";
				}
			}
			if (tbxEDate.Text.Trim() == "")
			{
				jsAlertMsg("INVALIDSDATE", "區段結束日期不可空白，請輸入");
				return "error";
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
					return "error";
				}

			}
			if (fc>0) sb.Append(" AND ");
			
			sb.Append("('" + sdate.ToString("yyyyMMdd") + "'<= adr_addate AND adr_addate<='" + edate.ToString("yyyyMMdd") + "')");
			fc++;

			if(cbxSrspn.Checked==true)
			{
				if (fc>0) sb.Append(" AND ");
				
				sb.Append("cont_empno='" + ddlEmpData.SelectedItem.Value.Trim() + "'");
				fc++;
			}
			if(cbxKeyword.Checked==true)
			{
				if (fc>0) sb.Append(" AND ");
				
				sb.Append("adr_keyword='" + ddlKeyword.SelectedItem.Value.Trim() + "'");
				fc++;
			}
			return sb.ToString();
		}
		#endregion

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Literal1.Text = "";
			string str_return = GetFilter();
			if(str_return == "error")
				return;
			else
			{
				Session["RPTADRLIST"] = str_return;
				string strbuf;
				strbuf="RptFileUpList.aspx?whoami=" + this.WhoAmI.CName+"&strdate="+tbxSDate.Text.Trim()+"~"+tbxEDate.Text.Trim();
				if(cbxSrspn.Checked==true)
					strbuf = strbuf + "&cname="+ddlEmpData.SelectedItem.Text.Trim();
				else
					strbuf = strbuf + "&cname=[全部]";
//				Response.Write(str_return);
				Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
			}
		}
	
	}
}
