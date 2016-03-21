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
	/// Summary description for RptContList0.
	/// </summary>
	public class RptContList0 : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.TextBox tbxSDate;
		protected System.Web.UI.WebControls.TextBox tbxEDate;
		protected System.Web.UI.WebControls.Label lblyyyymmdd;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.CheckBox cbxContNo;
		protected System.Web.UI.WebControls.CheckBox cbxDate;
		protected System.Web.UI.WebControls.DropDownList ddlClosed;
		protected System.Web.UI.WebControls.CheckBox cbxMfrIName;
		protected System.Web.UI.WebControls.TextBox tbxMfrIName;
		protected System.Web.UI.WebControls.CheckBox cbxEmpData;
		protected System.Web.UI.WebControls.DropDownList ddlEmpData;
		protected System.Web.UI.WebControls.DropDownList ddlCancel;
		protected System.Web.UI.WebControls.CheckBox cbxClosed;
		protected System.Web.UI.WebControls.CheckBox cbxCancel;
		protected System.Web.UI.WebControls.Button btnGo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				Session.Remove("RPTCONTLIST");
				Bind_ddlEmpData();
			}
			//�[�Jscript������
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

		#region ���ͲM����
		private void btnGo_Click(object sender, System.EventArgs e)
		{
			//Check��J����ƥ������T�A�Ӳz�����Φb�o�䭫�Ƽg�A
			//�i�O�A�S��k�F............
			//ñ�����
			DateTime sdate;
			DateTime edate;
			if (tbxSDate.Text.Trim() != "" && tbxEDate.Text.Trim() != "")
			{
				try
				{
					sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
				}
				catch
				{
					jsAlertMsg("INVALIDSDATE", "�Ϭq�_�l����榡���~�A�Э��s��J");
					return;
				}

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
			else if (tbxSDate.Text.Trim() != "")
			{
				try
				{
					sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
				}
				catch
				{
					jsAlertMsg("INVALIDSDATE", "�Ϭq�_�l����榡���~�A�Э��s��J");
					return;
				}
			}
			else if (tbxEDate.Text.Trim() != "")
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


			//�L�o����榡���~����~�i�H�����X����
			Session["RPTCONTLIST"] = GetFilter();
//			Session["STRNOW"] = DateTime.Now.ToString();
			Contracts cont = new Contracts();
			cont.RtpGenData();

//			Response.Write("�d�߱���=" + Session["RPTCONTLIST"].ToString() + "___");
//			Response.Redirect("RptContList.aspx?today=" + DateTime.Today.ToString("yyyy/MM/dd") + "&whoami=" + this.WhoAmI.CName);
			string strbuf;
			strbuf="RptContList.aspx?whoami=" + this.WhoAmI.CName;
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}
		#endregion

		#region ����Query����
		private string GetFilter()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("(1=1)");
			//�w����
			if(cbxClosed.Checked)
				sb.Append(" AND (cont_fgclosed='" + ddlClosed.SelectedItem.Value.Trim() + "')");
			//�w���P
			if(cbxCancel.Checked)
				sb.Append(" AND (cont_fgcancel='" + ddlCancel.SelectedItem.Value.Trim() + "')");
			//�X���s��
			if (cbxContNo.Checked)
			{
				sb.Append(" AND (cont_contno='" + tbxContNo.Text.Trim() + "')");
			}

			//ñ�����
			DateTime sdate;
			DateTime edate;
			if (cbxDate.Checked)
			{
				if (tbxSDate.Text.Trim() != "" && tbxEDate.Text.Trim() != "")
				{
					try
					{
						sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
					}
					catch
					{
						jsAlertMsg("INVALIDSDATE", "�Ϭq�_�l����榡���~�A�Э��s��J");
						return "";
					}

					try
					{
						edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
					}
					catch
					{
						jsAlertMsg("INVALIDEDATE", "�Ϭq��������榡���~�A�Э��s��J");
						return "";
					}
				
					sb.Append(" AND ('" + sdate.ToString("yyyyMMdd") + "'<=cont_signdate AND cont_signdate<='" + edate.ToString("yyyyMMdd") + "')");
				}
				else if (tbxSDate.Text.Trim() != "")
				{
					try
					{
						sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
					}
					catch
					{
						jsAlertMsg("INVALIDSDATE", "�Ϭq�_�l����榡���~�A�Э��s��J");
						return "";
					}

					sb.Append(" AND ('" + sdate.ToString("yyyyMMdd") + "'<=cont_signdate)");
				}
				else if (tbxEDate.Text.Trim() != "")
				{
					try
					{
						edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
					}
					catch
					{
						jsAlertMsg("INVALIDEDATE", "�Ϭq��������榡���~�A�Э��s��J");
						return "";
					}

					sb.Append(" AND (cont_signdate<='" + edate.ToString("yyyyMMdd") + "')");
				}
				else
				{
					//do nothing here
				}
			}
			//�ӿ�~�ȭ�
			if (cbxEmpData.Checked)
			{
				sb.Append(" AND (" + "cont_empno='" + ddlEmpData.SelectedItem.Value.Trim() + "')");
			}
			//�t�ӦW��
			if (cbxMfrIName.Checked)
			{
				sb.Append(" AND (" + "mfr_inm LIKE '%" + tbxMfrIName.Text.Trim() + "%')");
			}

			return sb.ToString();
		}
		#endregion
	}
}
