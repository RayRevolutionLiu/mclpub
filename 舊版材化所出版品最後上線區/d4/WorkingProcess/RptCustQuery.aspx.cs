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
	/// Summary description for RptCustQuery.
	/// </summary>
	public class RptCustQuery : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.CheckBox cbxAdDate;
		protected System.Web.UI.WebControls.TextBox tbxSDate;
		protected System.Web.UI.WebControls.TextBox tbxEDate;
		protected System.Web.UI.WebControls.Label lblyyyymmdd;
		protected System.Web.UI.WebControls.CheckBox cbxSrspn;
		protected System.Web.UI.WebControls.DropDownList ddlEmpData;
		protected System.Web.UI.WebControls.CheckBox cbxClosed;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.CheckBox cbxContType;
		protected System.Web.UI.WebControls.DropDownList ddlContType;
		protected System.Web.UI.WebControls.CheckBox cbxClass1;
		protected System.Web.UI.WebControls.CheckBox cbxClass2;
		protected System.Web.UI.WebControls.DropDownList ddlClass2;
		protected System.Web.UI.WebControls.DropDownList ddlClosed;
		protected System.Web.UI.WebControls.DropDownList ddlClass;
		protected System.Web.UI.WebControls.DropDownList ddlClass1;
		protected System.Web.UI.WebControls.Literal Literal1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				Bing_ddlClass1();
				Bing_ddlClass2();
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

		#region 連結材料特性Class1
		private void Bing_ddlClass1()
		{
			AtpMtps ams = new AtpMtps();
			DataSet ds = ams.GetClass2(1);
			DataView dv = ds.Tables[0].DefaultView;
			
			this.ddlClass1.DataTextField = "cls2_cname";
			this.ddlClass1.DataValueField = "cls2_cls2id";
			this.ddlClass1.DataSource = dv;
			this.ddlClass1.DataBind();
		}
		#endregion

		#region 連結應用產業Class2
		private void Bing_ddlClass2()
		{
			AtpMtps ams = new AtpMtps();
			DataSet ds = ams.GetClass2(2);
			DataView dv = ds.Tables[0].DefaultView;
			
			this.ddlClass2.DataTextField = "cls2_cname";
			this.ddlClass2.DataValueField = "cls2_cls2id";
			this.ddlClass2.DataSource = dv;
			this.ddlClass2.DataBind();

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
			//合約類別
			if(cbxContType.Checked)
			{
				if (fc>0) sb.Append(" AND ");
				
				sb.Append("cont_conttp='" + ddlContType.SelectedItem.Value.Trim() + "'");
				fc++;
			}
			//合約起訖
			if(cbxAdDate.Checked)
			{
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
			
				sb.Append("(( cont_sdate<='" + sdate.ToString("yyyyMMdd") + "' AND cont_edate>='" + sdate.ToString("yyyyMMdd") + "')");
				sb.Append(" OR ( cont_sdate>='" + sdate.ToString("yyyyMMdd") + "' AND cont_sdate<='" + edate.ToString("yyyyMMdd") + "'))");
				fc++;
			}
			//材料特性
			if(cbxClass1.Checked)
			{
				if (fc>0) sb.Append(" AND ");
				sb.Append("wkmatp_matpstr LIKE '%" + ddlClass1.SelectedItem.Text.Trim() + "%'");
				fc++;
			}
			//應用產業
			if(cbxClass2.Checked)
			{
				if (fc>0) sb.Append(" AND ");
				sb.Append("wkatp_atpstr LIKE '%" + ddlClass2.SelectedItem.Text.Trim() + "%'");
				fc++;
			}
			//承辦業務員
			if(cbxSrspn.Checked==true)
			{
				if (fc>0) sb.Append(" AND ");
				
				sb.Append("cont_empno='" + ddlEmpData.SelectedItem.Value.Trim() + "'");
				fc++;
			}
			//已結案
			if(cbxClosed.Checked==true)
			{
				if (fc>0) sb.Append(" AND ");
				
				sb.Append("cont_fgclosed='" + ddlClosed.SelectedItem.Value.Trim() + "'");
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
				Session["RPTCONTLIST"] = str_return;
				Contracts cont = new Contracts();
				cont.RtpGenData();
				string strbuf;
				strbuf="RptCustList.aspx?whoami=" + this.WhoAmI.CName;
				Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
			}

		}

	}
}
