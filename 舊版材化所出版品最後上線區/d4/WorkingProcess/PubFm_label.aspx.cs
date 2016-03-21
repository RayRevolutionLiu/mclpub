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
	/// Summary description for PubFm_label.
	/// </summary>
	public class PubFm_label : MRLPub.d4.Pages.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Web.UI.WebControls.DataList DataList2;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if (!IsPostBack)
			{
				Response.Expires = 0;

				// 抓出標籤資料
				GetLabelData();
			}
		}


		// 抓出標籤資料
		private void GetLabelData()
		{
			string strfilter = Session["MAILLABEL"].ToString().Trim();
			MailLabel ml = new MailLabel();
			DataSet ds = ml.GetLabelWithFilter(strfilter);
			DataView dv = ds.Tables[0].DefaultView;
			dv.RowFilter = "fgpub = '1'";
			string strfgMOSea = Context.Request.QueryString["fgmosea"].ToString().Trim();
			string strBookPNo = Context.Request.QueryString["bkpno"].ToString().Trim();
			// 若搜尋結果為 "找不到" 的處理
			if (dv.Count > 0)
			{
				if(strfgMOSea == "0")
				{
					DataList1.DataSource = dv;
					DataList1.DataBind();


					for(int i=0; i < DataList1.Items.Count; i++)
					{
						// 書籍期別
						((Label)DataList1.Items[i].FindControl("lblBkpNo1")).Text = strBookPNo;
					}
				}
				else
				{
					DataList2.DataSource=dv;
					DataList2.DataBind();


					for(int j=0; j < DataList2.Items.Count; j++)
					{
						// 書籍期別
						((Label)DataList2.Items[j].FindControl("lblBkpNo2")).Text = strBookPNo;
					}
				}
			// 結束 if (dv1.Count > 0)
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion




	}
}
