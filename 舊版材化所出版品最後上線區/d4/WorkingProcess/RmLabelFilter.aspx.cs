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
	/// Summary description for RmLabelFilter.
	/// </summary>
	public class RmLabelFilter : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlMosea;
		protected System.Web.UI.WebControls.Button btnCheckAll;
		protected System.Web.UI.WebControls.Button btnLabelPrint1;
		protected System.Web.UI.WebControls.Button btnPrintOK;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnUnCheckAll;
		protected System.Web.UI.WebControls.Literal Literal1;
	
		public RmLabelFilter()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			if (!IsPostBack)
			{
				DataBind();
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
			this.ddlMosea.SelectedIndexChanged += new System.EventHandler(this.ddlMosea_SelectedIndexChanged);
			this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
			this.btnUnCheckAll.Click += new System.EventHandler(this.btnUnCheckAll_Click);
			this.btnLabelPrint1.Click += new System.EventHandler(this.btnLabelPrint1_Click);
			this.btnPrintOK.Click += new System.EventHandler(this.btnPrintOK_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region ���o�ɮѪ��A�W��
		protected object GetFgSentName(object fgsent)
		{
			string strReturn = "";
			switch(fgsent.ToString().Trim())
			{
				case "Y":
					strReturn = "�i�H�X";
					break;
				case "N":
					strReturn = "�ثe���H�X";
					break;
				case "C":
					strReturn = "�w�H�X";
					break;
				case "D":
					strReturn = "���B�z";
					break;
				default:
					strReturn = "(DB ERROR)";
					break;
			}
			return strReturn;
		}
		#endregion

		private void DataBind()
		{
			ReMailBooks rm = new ReMailBooks();
			DataSet ds1 = rm.GetContRemailOrMfrCustWithFilter("");
			DataView dv1 = ds1.Tables[0].DefaultView;
			dv1.RowFilter="or_fgmosea='"+ddlMosea.SelectedItem.Value.Trim()+"' and rm_fgsent<>'C'";
			DataList1.DataSource=dv1;
			DataList1.DataBind();
		}

		private void btnCheckAll_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Enabled)
					((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked=true;
			}
		}

		private void btnUnCheckAll_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Enabled)
					((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked=false;
			}
		
		}

		private void ddlMosea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			DataBind();
		}

		private void btnLabelPrint1_Click(object sender, System.EventArgs e)
		{
			string	strbuf, contno, oritem, seq;
			ReMailBooks rm = new ReMailBooks();
			//�M���C�L���ҵ��O
			rm.ClearRemailFgPrint();
			//�N�ҿ蠟�ʮѸ�ƪ��ɮѤ��(rm_date)��J���Ѫ����, �ñN�C�L���ҵ��O�]��'v'
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked)
				{
					contno = ((Label)DataList1.Items[i].FindControl("lblContno")).Text.Trim();
					oritem = ((Label)DataList1.Items[i].FindControl("lblOritem")).Text.Trim();
					seq = ((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim();
					rm.UpdateRemailDate(contno, oritem, seq, "v");
				}
			}
			btnPrintOK.Enabled=true;
			strbuf="Remail_label.aspx?mosea="+ddlMosea.SelectedItem.Value.Trim();
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
			//			Response.Redirect("lost_label.aspx");

		}

		private void btnPrintOK_Click(object sender, System.EventArgs e)
		{
			string	strbuf, contno, oritem, seq;
			Literal1.Text="";
			//�N�ҿ蠟�ɮѸ�ƪ��ɮѤ��(lst_date)��J���Ѫ����,�ñN�H�X���O(lst_fgsent)�]��'C'�αN�C�L���ҵ��O�]��''
			for(int i=0; i<DataList1.Items.Count; i++)
			{
				if(((CheckBox)DataList1.Items[i].FindControl("cbx1")).Checked)
				{
					contno = ((Label)DataList1.Items[i].FindControl("lblContno")).Text.Trim();
					oritem = ((Label)DataList1.Items[i].FindControl("lblOritem")).Text.Trim();
					seq = ((Label)DataList1.Items[i].FindControl("lblSeq")).Text.Trim();
					ReMailBooks rm = new ReMailBooks();
					rm.UpdateRemailPrintOK(contno, oritem, seq, "C", "");
				}
			}
			DataBind();

		}


	}
}
