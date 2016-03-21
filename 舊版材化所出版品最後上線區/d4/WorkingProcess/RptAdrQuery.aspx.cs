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
	/// Summary description for RptAdrQuery.
	/// </summary>
	public class RptAdrQuery : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxSDate;
		protected System.Web.UI.WebControls.TextBox tbxEDate;
		protected System.Web.UI.WebControls.Label lblyyyymmdd;
		protected System.Web.UI.WebControls.CheckBox cbxSrspn;
		protected System.Web.UI.WebControls.DropDownList ddlEmpData;
		protected System.Web.UI.WebControls.CheckBox cbxMfrName;
		protected System.Web.UI.WebControls.TextBox tbxMfrName;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Web.UI.WebControls.Label lblAdDate;
	
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
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region �s�����u���
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

		#region ����Query����
		private string GetFilter()
		{
			int fc = 0;
			StringBuilder sb = new StringBuilder();
			if(cbxMfrName.Checked==true)
			{
				if (tbxMfrName.Text.Trim() != "")
				{
					sb.Append("mfr_inm LIKE '%" + tbxMfrName.Text.Trim() + "%'");
					fc++;
				}
				else
				{
					jsAlertMsg("INVALIDSDATE", "�t�ӦW�٨S����J��ơA�п�J");
					return "error";
				}
			}

			//�s�i�Z�n���
//			DateTime sdate;
//			DateTime edate;
//			if (tbxSDate.Text.Trim() != "" && tbxEDate.Text.Trim() != "")
//			{
//				try
//				{
//					sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
//				}
//				catch
//				{
//					jsAlertMsg("INVALIDSDATE", "�Ϭq�_�l����榡���~�A�Э��s��J");
//					return "error";
//				}
//
//				try
//				{
//					edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
//				}
//				catch
//				{
//					jsAlertMsg("INVALIDEDATE", "�Ϭq��������榡���~�A�Э��s��J");
//					return "error";
//				}
//
//				if (fc>0) sb.Append(" AND ");
//			
//				sb.Append("('" + sdate.ToString("yyyyMMdd") + "'<= adr_addate AND adr_addate<='" + edate.ToString("yyyyMMdd") + "')");
//				fc++;
//			}
//			else if (tbxSDate.Text.Trim() != "")
//			{
//				try
//				{
//					sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
//				}
//				catch
//				{
//					jsAlertMsg("INVALIDSDATE", "�Ϭq�_�l����榡���~�A�Э��s��J");
//					return "error";
//				}
//
//				if (fc>0) sb.Append(" AND ");
//			
//				sb.Append("('" + sdate.ToString("yyyyMMdd") + "'<=adr_addate)");
//				fc++;
//			}
//			else if (tbxEDate.Text.Trim() != "")
//			{
//				try
//				{
//					edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
//				}
//				catch
//				{
//					jsAlertMsg("INVALIDEDATE", "�Ϭq��������榡���~�A�Э��s��J");
//					return "error";
//				}
//
//				if (fc>0) sb.Append(" AND ");
//			
//				sb.Append("(" + "adr_addate<='" + edate.ToString("yyyyMMdd") + "')");
//				fc++;
//			}
			if(cbxSrspn.Checked==true)
			{
				if (fc>0) sb.Append(" AND ");
				
				sb.Append("cont_empno='" + ddlEmpData.SelectedItem.Value.Trim() + "'");
				fc++;
			}
			return sb.ToString();
		}
		#endregion

		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			DateTime sdate;
			DateTime edate;
			Literal1.Text = "";
			if (tbxSDate.Text.Trim() == "")
			{
				jsAlertMsg("DateEmpty", "�Ϭq�_�l������i�ťաA�п�J");
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
					jsAlertMsg("DateEmpty", "�Ϭq�_�l����榡���~�A�Э��s��J");
					return;
				}
			}
			if (tbxEDate.Text.Trim() == "")
			{
				jsAlertMsg("INVALIDSDATE", "�Ϭq����������i�ťաA�п�J");
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
					jsAlertMsg("INVALIDEDATE", "�Ϭq��������榡���~�A�Э��s��J");
					return;
				}

			}
			string str_return = GetFilter();
			if(str_return == "error")
				return;
			else
			{
				Session["RPTADRLIST"] = str_return;
				Advertisements ad = new Advertisements();
				ad.RptAdrList(sdate.ToString("yyyyMMdd"),edate.ToString("yyyyMMdd"));

				string strbuf;
				strbuf="RptAdrList.aspx?whoami=" + this.WhoAmI.CName+"&strdate="+sdate.ToString("yyyy/MM/dd")+"~"+edate.ToString("yyyy/MM/dd");
				Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
			}
		}

	}
}
