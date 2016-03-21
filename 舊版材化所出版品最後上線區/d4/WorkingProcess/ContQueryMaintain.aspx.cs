using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MRLPub.d4.DataTypes;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for ContQueryMaintain.
	/// </summary>
	public class ContQueryMaintain : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxMfrNm;
		protected System.Web.UI.WebControls.Label lblContHint;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxCustNm;
		protected System.Web.UI.WebControls.LinkButton lnbQuery;
		protected System.Web.UI.WebControls.DataGrid dgdMfrCust;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.LinkButton lngGoThis;
		protected System.Web.UI.WebControls.Label lblCustFound;
		protected System.Web.UI.WebControls.Panel pnlQuery;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			this.lnbQuery.Click += new System.EventHandler(this.lnbQuery_Click);
			this.lngGoThis.Click += new System.EventHandler(this.lngGoThis_Click);
			this.dgdMfrCust.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdMfrCust_PageIndexChanged);
			this.dgdMfrCust.SelectedIndexChanged += new System.EventHandler(this.dgdMfrCust_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region �զX�d�߱���
		/// <summary>
		/// �զX�d�߱���
		/// </summary>
		/// <returns>�զX�᪺����r��</returns>
		private string GetFilters()
		{
			int fc = 0;
			string strFilter = "";

			//�t�ӦW��
			if (tbxMfrNm.Text.Trim() != "")
			{
				strFilter += "mfr_inm LIKE '%" + tbxMfrNm.Text.Trim() + "%'";
				fc++;
			}

			//�Τ@�s��
			if (tbxMfrNo.Text.Trim() != "")
			{
				if (fc>0) strFilter += " AND ";
				strFilter += "mfr_mfrno LIKE '%" + tbxMfrNo.Text.Trim() + "%'";
				fc++;
			}

			//�Ȥ�s��
			if (tbxCustNo.Text.Trim() != "")
			{
				if (fc>0) strFilter += " AND ";
				strFilter += "cust_custno LIKE '%" + tbxCustNo.Text.Trim() + "%'";
				fc++;
			}

			//�Ȥ�m�W
			if (tbxCustNm.Text.Trim() != "")
			{
				if (fc>0) strFilter += " AND ";
				strFilter += "cust_nm LIKE '%" + tbxCustNm.Text.Trim() + "%'";
				fc++;
			}

			return strFilter;
		}
		#endregion

		#region �s���t�ӫȤ���
		/// <summary>
		/// �s���t�ӫȤ���
		/// </summary>
		/// <returns>��쪺��Ƶ���</returns>
		private int Bind_dgdMfrCust()
		{
			Customers cust = new Customers();
			DataSet ds = cust.GetMfrCustomers();
			DataView dv = ds.Tables[0].DefaultView;

			string strFilter = GetFilters();

			if (strFilter.Trim() != "")
			{
				dv.RowFilter = strFilter;
			}
			dv.Sort = "cust_custno";

			dgdMfrCust.DataSource = dv;
			dgdMfrCust.DataBind();

			return dv.Count;
		}
		#endregion

		#region �d��
		private void lnbQuery_Click(object sender, System.EventArgs e)
		{
			pnlQuery.Visible = true;

			// Reset Index
			dgdMfrCust.CurrentPageIndex = 0;
			dgdMfrCust.SelectedIndex = -1;

			int DataCount = Bind_dgdMfrCust();

			lblCustFound.Text = "�d�ߵ��G�G��� " + DataCount.ToString() + " ���Ȥ���";

			if (DataCount > 0)
			{
				dgdMfrCust.Visible = true;
			}
			else
			{
				dgdMfrCust.Visible = false;
			}
		}
		#endregion

		#region �s�W�t�Ӹ��
		private void lnbNewMfr_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("~/d5/mfr.aspx");
		}
		#endregion

		#region �s�W�Ȥ���
		private void lnbNewCust_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("~/d5/cust.aspx");
		}
		#endregion

		#region ��ܫȤ�
		private void dgdMfrCust_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string custno = dgdMfrCust.SelectedItem.Cells[3].Text.Trim();
			Response.Redirect("ContQueryFormal.aspx?custno=" + custno);
		}
		#endregion

		#region ����
		private void dgdMfrCust_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdMfrCust.CurrentPageIndex = e.NewPageIndex;
			dgdMfrCust.SelectedIndex = -1;
			
			Bind_dgdMfrCust();
		}
		#endregion

		#region ��������X�����@
		private void lngGoThis_Click(object sender, System.EventArgs e)
		{
			string contno = tbxContNo.Text.Trim();
			if (contno == "")
			{
				jsAlertMsg("BLANKCONTNO", "���������@�X���A�X���s�����i�ť�");
				return;
			}
			Contracts cont = new Contracts();
			SqlDataReader dr = cont.GetSingleContractByContNo(contno);

			if (dr.Read())
			{
				Response.Redirect("ContMaintain.aspx?ContNo=" + contno);
			}
			else
				jsAlertMsg("CONTNOTFOUND", "�䤣��X��"+contno+"����ơA���ˬd�X���s���O�_���T�γq���p���H");

		}
		#endregion
	}
}
