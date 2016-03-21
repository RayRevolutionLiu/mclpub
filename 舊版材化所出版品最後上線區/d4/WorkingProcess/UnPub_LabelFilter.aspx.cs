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
	/// Summary description for Pub_LabelFilter.
	/// </summary>
	public class UnPub_LabelFilter : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Label lblBookCode;
		protected System.Web.UI.WebControls.DropDownList ddlBookCode;
		protected System.Web.UI.WebControls.Label lblPubDate;
		protected System.Web.UI.WebControls.TextBox tbxPubDate;
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Web.UI.WebControls.Label lblConttp;
		protected System.Web.UI.WebControls.DropDownList ddlConttp;
		protected System.Web.UI.WebControls.Label lblfgMOSea;
		protected System.Web.UI.WebControls.DropDownList ddlfgMOSea;
		protected System.Web.UI.WebControls.DropDownList ddlMtpcd;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnPrintList;
		protected System.Web.UI.WebControls.Button btnPrintLabel;
		protected System.Web.UI.WebControls.Button btnBackHome;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblEmpNo;
		protected System.Web.UI.WebControls.Label lblMtpcd;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.CheckBox cbxMtpcd;
		protected System.Web.UI.WebControls.CheckBox cbxEmpno;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenBookPno;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenBookNm;
		protected System.Web.UI.WebControls.DataGrid dgdLabel;
		protected System.Web.UI.WebControls.RegularExpressionValidator revPubDate;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				Response.Expires = 0;

				Literal1.Text = "";
				InitialData();
			}
		}

		// ���w�]��
		private void InitialData()
		{
			this.lblMessage.Text = "";
			this.btnPrintLabel.Visible = false;
			this.btnPrintList.Visible = false;


			// ��ܤU�Ԧ���� ���y���O�� DB ��
			MailLabel ml = new MailLabel();
			DataSet ds1 = ml.GetFreeBook();
			ddlBookCode.DataSource=ds1;
			ddlBookCode.DataTextField="fc_nm";
			ddlBookCode.DataValueField="fc_fccd";
			ddlBookCode.DataBind();

			this.tbxPubDate.Text = System.DateTime.Today.ToString("yyyy/MM");


			// ��ܤU�Ԧ���� �~�ȭ� DB ��
			// ���� nostr, �а� sqlDataAdapter3.Select statement;
			// nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
			Srspns srspn = new Srspns();
			DataSet ds2 = srspn.GetSrspns();
			DataView dv2 = ds2.Tables[0].DefaultView;
			dv2.RowFilter = "";
			ddlEmpNo.DataSource=dv2;
			ddlEmpNo.DataTextField="srspn_cname";
			ddlEmpNo.DataValueField="srspn_empno";
			ddlEmpNo.DataBind();

			// ��ܤU�Ԧ���� �l�H���O DB ��
			DataSet ds3 = ml.GetMailType();
			ddlMtpcd.DataSource=ds3;
			ddlMtpcd.DataTextField="mtp_nm";
			ddlMtpcd.DataValueField="mtp_mtpcd";
			ddlMtpcd.DataBind();

			this.cbxEmpno.Checked = false;
			this.cbxMtpcd.Checked = false;


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
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnPrintList.Click += new System.EventHandler(this.btnPrintList_Click);
			this.btnPrintLabel.Click += new System.EventHandler(this.btnPrintLabel_Click);
			this.btnBackHome.Click += new System.EventHandler(this.btnBackHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region �d��
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			Literal1.Text = "";
			string yyyymm = tbxPubDate.Text.Substring(0,4)+tbxPubDate.Text.Substring(5,2);
			MailLabel ml = new MailLabel();
			if(ml.CreateLabelList(yyyymm))
			{
				hiddenBookPno.Value = ml.GetBookPno(ddlBookCode.SelectedItem.Value.Trim(), yyyymm);

				this.btnPrintLabel.Visible = true;
				this.btnPrintList.Visible = true;

				//��ܬd�ߵ��G -- ���n����
				string strfilter = GetFilters();
				DataSet ds = ml.GetLabelWithFilter(strfilter);
				DataView dv = ds.Tables[0].DefaultView;
				dv.RowFilter = "fgpub = '0'";
				dgdLabel.DataSource = dv;
				dgdLabel.DataBind();
				lblMessage.Text = "�d�ߵ��G:�@�� "+dv.Count.ToString()+" �����";
			}
			else
				lblMessage.Text = "���ͼ��Ҹ�Ƶo�Ϳ��~, �еy��A�թ��p�������H��!!";
		}
		#endregion


		#region �զX�d�߱���
		/// <summary>
		/// �զX�d�߱���
		/// </summary>
		/// <returns>�զX�᪺����r��</returns>
		private string GetFilters()
		{
			string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
			string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			string strEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
			string strConttp = this.ddlConttp.SelectedItem.Value.ToString();
			string fgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();
			string strMtpcd = this.ddlMtpcd.SelectedItem.Value.ToString();

			string strFilter = "";

			strFilter = " (fbk_bkcd = '"+ddlBookCode.SelectedItem.Value.Trim()+"')"
				+ " AND (ma_sdate <= '"+strYYYYMM+"')"
				+ " AND (ma_edate >= '"+strYYYYMM+"')"
				+ " AND (cont_conttp = '"+ddlConttp.SelectedItem.Value.Trim()+"')"
				+ " AND (or_fgmosea = '"+ddlfgMOSea.SelectedItem.Value.Trim()+"')";

			if(cbxMtpcd.Checked)
				strFilter += " AND (ma_mtpcd = '"+ddlMtpcd.SelectedItem.Value.Trim()+"')";

			if(cbxEmpno.Checked)
				strFilter += " AND (cont_empno = '"+ddlEmpNo.SelectedItem.Value.Trim()+"')";

			return strFilter;
		}
		#endregion

		private void btnPrintLabel_Click(object sender, System.EventArgs e)
		{
			Literal1.Text = "";
			// ��X�z�����
			Session["MAILLABEL"] = GetFilters();
			string fgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();


			// ��}
			string	strbuf;
			strbuf = "UnPubFm_label.aspx?fgmosea=" + fgMOSea + "&bkpno=" + hiddenBookPno.Value.Trim();
			//Response.Write("strbuf= " + strbuf + "<br>");
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		
		}

		private void btnPrintList_Click(object sender, System.EventArgs e)
		{
			Literal1.Text = "";
			// ��X�z�����
			Session["MAILLABEL"] = GetFilters();
			string fgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();

			string strBk = this.ddlBookCode.SelectedItem.Text.ToString().Trim();
			string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
			strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
			string strConttp = this.ddlConttp.SelectedItem.Value.ToString().Trim();
			string strMtpcd = "";
			if(cbxMtpcd.Checked)
				strMtpcd = this.ddlMtpcd.SelectedItem.Value.ToString().Trim();
			string strSrspn = "";
			if(cbxEmpno.Checked)
				strSrspn = this.ddlEmpNo.SelectedItem.Text.ToString().Trim();

			string	strbuf;
			strbuf = "UnPub_LabelList.aspx?bk=" + strBk + "&yyyymm=" + strYYYYMM + "&srspn=" + strSrspn + "&conttp=" + strConttp + "&fgmosea=" + fgMOSea 
				+ "&mtpcd=" + strMtpcd + "&bkpno=" + hiddenBookPno.Value.Trim()+ "&whoami=" + this.WhoAmI.CName;
			//Response.Write("strbuf= " + strbuf + "<br>");
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		
		}

		#region �^�D���
		private void btnBackHome_Click(object sender, System.EventArgs e)
		{
			string home = D4Settings.HomeUrl;
			Response.Redirect(home);
		}
		#endregion

	}
}
