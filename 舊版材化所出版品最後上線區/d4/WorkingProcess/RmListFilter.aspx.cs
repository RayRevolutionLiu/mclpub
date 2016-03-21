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

namespace MRLPub.d4
{
	/// <summary>
	/// Summary description for RmListFilter.
	/// </summary>
	public class RmListFilter : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Web.UI.WebControls.TextBox tbxRemailDate1;
		protected System.Web.UI.WebControls.TextBox tbxRemailDate2;
		protected System.Web.UI.WebControls.CheckBox cbx1;
		protected System.Web.UI.WebControls.CheckBox cbx2;
		protected System.Web.UI.WebControls.TextBox tbxSignDate2;
		protected System.Web.UI.WebControls.TextBox tbxSignDate1;
		protected System.Web.UI.WebControls.DropDownList ddlSent;
		protected System.Web.UI.WebControls.Literal Literal1;
	
		public RmListFilter()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			if (!IsPostBack)
			{
				tbxRemailDate1.Text=System.DateTime.Today.ToString("yyyy/MM/dd");
				tbxRemailDate2.Text=System.DateTime.Today.ToString("yyyy/MM/dd");
				tbxSignDate1.Text=System.DateTime.Today.ToString("yyyy/MM/dd");
				tbxSignDate2.Text=System.DateTime.Today.ToString("yyyy/MM/dd");
			}
			//加入script的部分
			if (!IsClientScriptBlockRegistered("JSCALENDAR"))
			{
				System.IO.TextReader tr = System.IO.File.OpenText(Server.MapPath(".") + "\\ClientScripts\\jsCalendar.js");
				string script = tr.ReadToEnd();
				RegisterClientScriptBlock("JSCALENDAR", script);
			}
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
			this.ddlSent.SelectedIndexChanged += new System.EventHandler(this.ddlSent_SelectedIndexChanged);
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
				string	strbuf="RptRemailList.aspx?whoami=" + this.WhoAmI.CName+"&status="+ddlSent.SelectedItem.Value;
				if(cbx1.Checked)
					strbuf+="&date="+tbxRemailDate1.Text+"~"+tbxRemailDate2.Text;
				else
					strbuf+="&date=";
				if(cbx2.Checked)
					strbuf+="&o_date="+tbxSignDate1.Text+"~"+tbxSignDate2.Text;
				else
					strbuf+="&o_date=";
				Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}

		private void ddlSent_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			if(ddlSent.SelectedItem.Value=="C")
			{
				cbx1.Enabled=true;
				tbxRemailDate1.Enabled=true;
				tbxRemailDate2.Enabled=true;
			}
			else
			{
				cbx1.Checked=false;
				cbx1.Enabled=false;
				tbxRemailDate1.Enabled=false;
				tbxRemailDate2.Enabled=false;
			}
		}
	}
}
