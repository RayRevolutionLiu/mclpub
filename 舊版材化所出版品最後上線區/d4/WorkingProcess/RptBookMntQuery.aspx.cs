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
	/// Summary description for RptBookMntQuery.
	/// </summary>
	public class RptBookMntQuery : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Web.UI.WebControls.CheckBox cbxContType;
		protected System.Web.UI.WebControls.DropDownList ddlConttp;
		protected System.Web.UI.WebControls.CheckBox cbxMosea;
		protected System.Web.UI.WebControls.DropDownList ddlfgMOSea;
		protected System.Web.UI.WebControls.CheckBox cbxMtpcd;
		protected System.Web.UI.WebControls.DropDownList ddlMtpcd;
		protected System.Web.UI.WebControls.CheckBox cbxEmpno;
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.TextBox tbxBookNo;
		protected System.Web.UI.WebControls.TextBox tbxDate;
		protected System.Web.UI.WebControls.RegularExpressionValidator revDate;
		protected System.Web.UI.WebControls.Label lblTitle;
		protected System.Web.UI.WebControls.Label lblMessage;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				Response.Expires = 0;
				if(Request["type"]=="pub")
					lblTitle.Text = "本月刊登";
				else
					lblTitle.Text = "本月未刊登";
				Literal1.Text = "";
				InitialData();
			}
		}

		// 給預設值
		private void InitialData()
		{
			this.lblMessage.Text = "";

			this.tbxDate.Text = System.DateTime.Today.ToString("yyyy/MM");


			// 顯示下拉式選單 業務員 DB 值
			// 關於 nostr, 請參 sqlDataAdapter3.Select statement;
			// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
			Srspns srspn = new Srspns();
			DataSet ds = srspn.GetSrspns();
			DataView dv = ds.Tables[0].DefaultView;
			dv.RowFilter = "";
			ddlEmpNo.DataSource=dv;
			ddlEmpNo.DataTextField="srspn_cname";
			ddlEmpNo.DataValueField="srspn_empno";
			ddlEmpNo.DataBind();


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
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region 組合查詢條件
		/// <summary>
		/// 組合查詢條件
		/// </summary>
		/// <returns>組合後的條件字串</returns>
		private string GetFilters()
		{

			string strFilter = "";

			strFilter = " (bkcd = '"+ddlBookCode.SelectedItem.Value.Trim()+"')";

			if(cbxContType.Checked)
				strFilter += " AND (conttp = '"+ddlConttp.SelectedItem.Value.Trim()+"')";
			if(cbxMosea.Checked)
				strFilter += " AND (fgmosea = '"+ddlfgMOSea.SelectedItem.Value.Trim()+"')";
			if(cbxMtpcd.Checked)
			{
				if(ddlMtpcd.SelectedItem.Value.Trim()=="0")
					strFilter += " AND (mtpcd = '11')";
				else if(ddlMtpcd.SelectedItem.Value.Trim()=="1")
					strFilter += " AND (mtpcd <> '11')";
			}
			if(cbxEmpno.Checked)
				strFilter += " AND (empno = '"+ddlEmpNo.SelectedItem.Value.Trim()+"')";

			return strFilter;
		}
		#endregion

		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			Literal1.Text = "";
			Session["MAILLABEL"] = GetFilters();
			// 抓出篩選條件
			string strBk = this.ddlBookCode.SelectedItem.Text.ToString().Trim()+tbxBookNo.Text.Trim()+"期";
			string strConttp = "";
			if(cbxContType.Checked)
				strConttp = this.ddlConttp.SelectedItem.Text.ToString().Trim();
			else
				strConttp = "(所有)";
			string strMtpcd = "";
			string strSrspn = "";
			if(cbxEmpno.Checked)
				strSrspn = this.ddlEmpNo.SelectedItem.Text.ToString().Trim();
			else
				strSrspn = "(所有)";
			string strdate = tbxDate.Text.Trim();
			MailLabel ml = new MailLabel();
			ml.CreateMailMnt(strdate.Substring(0,4)+strdate.Substring(5,2), strdate.Substring(0,4)+strdate.Substring(5,2));
			string	strbuf="";
			if(Request["type"]=="pub")
				strbuf = "RptBookMntPub.aspx?bk=" + strBk + "&strdate=" + strdate + "&cname=" + strSrspn + "&conttp=" + strConttp 
					+ "&whoami=" + this.WhoAmI.CName;
			else
				strbuf = "RptBookMntUnPub.aspx?bk=" + strBk + "&strdate=" + strdate + "&cname=" + strSrspn + "&conttp=" + strConttp 
					+ "&whoami=" + this.WhoAmI.CName;

			//Response.Write("strbuf= " + strbuf + "<br>");
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}

	}
}
