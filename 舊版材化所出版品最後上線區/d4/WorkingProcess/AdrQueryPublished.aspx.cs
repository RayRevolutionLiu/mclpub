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

		#region 直接跳到美編上稿畫面
		private void lngGoThis_Click(object sender, System.EventArgs e)
		{
			string contno = tbxContNo.Text.Trim();
			if (contno == "")
			{
				jsAlertMsg("BLANKCONTNO", "欲直接上稿，合約編號不可空白");
				return;
			}
			Contracts cont = new Contracts();
			SqlDataReader dr = cont.GetSingleContractByContNo(contno);

			if (dr.Read())
			{
				Response.Redirect("AdrFileUp.aspx?NewContNo=" + contno);
			}
			else
				jsAlertMsg("CONTNOTFOUND", "找不到合約"+contno+"的資料，請檢查合約編號是否正確或通知聯絡人");

		}
		#endregion

		#region 連結合約資料
		/// <summary>
		/// 連結合約資料
		/// </summary>
		/// <returns>找到的資料筆數</returns>
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
							dgdCont.Items[i].Cells[9].Text = "一般";
							break;
						case "09":
							dgdCont.Items[i].Cells[9].Text = "推廣";
							break;
						default:
							dgdCont.Items[i].Cells[9].Text = "(無法辨識)";
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

		#region 選定要上稿的合約
		private void dgdCont_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string NewContNo;
			NewContNo = dgdCont.SelectedItem.Cells[0].Text.Trim();

			Response.Redirect("AdrFileUp.aspx?NewContNo=" + NewContNo);
		}
		#endregion

		#region 換頁
		private void dgdCont_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgdCont.CurrentPageIndex = e.NewPageIndex;
			Bind_dgdCont();
		}
		#endregion


		#region 查詢
		private void lnbQuery_Click(object sender, System.EventArgs e)
		{
			// Reset Index
			dgdCont.CurrentPageIndex = 0;
			dgdCont.SelectedIndex = -1;

			int DataCount = Bind_dgdCont();

			lblCustFound.Text = "查詢結果：找到 " + DataCount.ToString() + " 筆資料";

		}
		#endregion

		#region 組合查詢條件
		/// <summary>
		/// 組合查詢條件
		/// </summary>
		/// <returns>組合後的條件字串</returns>
		private string GetFilters()
		{
			int fc = 0;
			string strFilter = "";

			//廠商名稱
			if (tbxMfrNm.Text.Trim() != "")
			{
				strFilter += "mfr_inm LIKE '%" + tbxMfrNm.Text.Trim() + "%'";
				fc++;
			}

			//統一編號
			if (tbxMfrNo.Text.Trim() != "")
			{
				if (fc>0) strFilter += " AND ";
				strFilter += "mfr_mfrno LIKE '%" + tbxMfrNo.Text.Trim() + "%'";
				fc++;
			}

			//客戶編號
			if (tbxCustNo.Text.Trim() != "")
			{
				if (fc>0) strFilter += " AND ";
				strFilter += "cust_custno LIKE '%" + tbxCustNo.Text.Trim() + "%'";
				fc++;
			}

			//客戶姓名
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
