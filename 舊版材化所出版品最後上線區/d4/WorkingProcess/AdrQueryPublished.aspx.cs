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
using MRLPub.d4.Configurations;
using MRLPub.d4.DataTypes;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for AdrQueryPublished.
	/// </summary>
	public class AdrQueryPublished : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgdCont;
		protected System.Web.UI.WebControls.LinkButton lngGoThis;
		protected System.Web.UI.WebControls.TextBox tbxMfrNm;
		protected System.Web.UI.WebControls.Label lblContHint;
		protected System.Web.UI.WebControls.TextBox tbxMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxCustNo;
		protected System.Web.UI.WebControls.TextBox tbxCustNm;
		protected System.Web.UI.WebControls.LinkButton lnbQuery;
		protected System.Web.UI.WebControls.Label lblCustFound;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
	
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
			this.lngGoThis.Click += new System.EventHandler(this.lngGoThis_Click);
			this.lnbQuery.Click += new System.EventHandler(this.lnbQuery_Click);
			this.dgdCont.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgdCont_PageIndexChanged);
			this.dgdCont.SelectedIndexChanged += new System.EventHandler(this.dgdCont_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region ����������s�W�Z�e��
		private void lngGoThis_Click(object sender, System.EventArgs e)
		{
			string contno = tbxContNo.Text.Trim();
			if (contno == "")
			{
				jsAlertMsg("BLANKCONTNO", "�������W�Z�A�X���s�����i�ť�");
				return;
			}
			Contracts cont = new Contracts();
			SqlDataReader dr = cont.GetSingleContractByContNo(contno);

			if (dr.Read())
			{
				Response.Redirect("AdrFileUp.aspx?NewContNo=" + contno);
			}
			else
				jsAlertMsg("CONTNOTFOUND", "�䤣��X��"+contno+"����ơA���ˬd�X���s���O�_���T�γq���p���H");

		}
		#endregion

		#region �s���X�����
		/// <summary>
		/// �s���X�����
		/// </summary>
		/// <returns>��쪺��Ƶ���</returns>
		private int Bind_dgdCont()
		{
			Contracts cont = new Contracts();
			DataSet ds = cont.GetAllFormalContracts();
			DataView dv = ds.Tables[0].DefaultView;
			dv.Sort= "cont_contno DESC";

			string strFilter = GetFilters();
			if (strFilter.Trim() != "")
			{
				dv.RowFilter = strFilter;
			}

			dgdCont.DataSource = dv;
			dgdCont.DataBind();

			if (dgdCont.Items.Count>0)
			{
				dgdCont.Visible = true;

				for(int i=0; i<dgdCont.Items.Count; i++)
				{
					switch(dgdCont.Items[i].Cells[9].Text.Trim())
					{
						case "01":
							dgdCont.Items[i].Cells[9].Text = "�@��";
							break;
						case "09":
							dgdCont.Items[i].Cells[9].Text = "���s";
							break;
						default:
							dgdCont.Items[i].Cells[9].Text = "(�L�k����)";
							break;
					}
				}
			}
			else
			{
				dgdCont.Visible = false;
			}
			return dv.Count;
		}
		#endregion

		#region ��w�n�W�Z���X��
		private void dgdCont_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string NewContNo;
			NewContNo = dgdCont.SelectedItem.Cells[0].Text.Trim();

			Response.Redirect("AdrFileUp.aspx?NewContNo=" + NewContNo);
		}
		#endregion

		#region ����
		private void dgdCont_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdCont.CurrentPageIndex = e.NewPageIndex;
			Bind_dgdCont();
		}
		#endregion


		#region �d��
		private void lnbQuery_Click(object sender, System.EventArgs e)
		{
			// Reset Index
			dgdCont.CurrentPageIndex = 0;
			dgdCont.SelectedIndex = -1;

			int DataCount = Bind_dgdCont();

			lblCustFound.Text = "�d�ߵ��G�G��� " + DataCount.ToString() + " �����";

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
	}
}
