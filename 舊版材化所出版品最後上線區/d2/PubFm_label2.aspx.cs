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
// WebApplication Virables - Web.config
using System.Configuration;


namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for PubFm_label2.
	/// </summary>
	public class PubFm_label2 : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.DataList DataList1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
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
			// 抓出篩選條件
			string strBkcd = "", strYYYYMM = "", strEmpNo = "", strConttp = "", strPubCountType = "", strfgMOSea = "", strMtpcd = "", strBookPNo = "";

			if(Context.Request.QueryString["bkcd"].ToString().Trim() != "")
			{
				strBkcd = Context.Request.QueryString["bkcd"].ToString();
			}
			else
			{
				strBkcd = strBkcd;
			}

			if(Context.Request.QueryString["yyyymm"].ToString().Trim() != "")
			{
				strYYYYMM = Context.Request.QueryString["yyyymm"].ToString().Trim();
			}
			else
			{
				strYYYYMM = strYYYYMM;
			}

			if(Context.Request.QueryString["empno"].ToString().Trim() != "")
			{
				strEmpNo = Context.Request.QueryString["empno"].ToString().Trim();
			}
			else
			{
				strEmpNo = strEmpNo;
			}

			if(Context.Request.QueryString["conttp"].ToString().Trim() != "")
			{
				strConttp = Context.Request.QueryString["conttp"].ToString();
			}
			else
			{
				strConttp = strConttp;
			}

			if(Context.Request.QueryString["pubcnttp"].ToString().Trim() != "")
			{
				strPubCountType = Context.Request.QueryString["pubcnttp"].ToString().Trim();
			}
			else
			{
				strPubCountType = strPubCountType;
			}

			if(Context.Request.QueryString["fgmosea"].ToString().Trim() != "")
			{
				strfgMOSea = Context.Request.QueryString["fgmosea"].ToString().Trim();
			}
			else
			{
				strfgMOSea = strfgMOSea;
			}

			if(Context.Request.QueryString["mtpcd"].ToString().Trim() != "")
			{
				strMtpcd = Context.Request.QueryString["mtpcd"].ToString().Trim();
			}
			else
			{
				strMtpcd = strMtpcd;
			}

			if(Context.Request.QueryString["bkpno"].ToString().Trim() != "")
			{
				strBookPNo = Context.Request.QueryString["bkpno"].ToString().Trim();
			}
			else
			{
				strBookPNo = strBookPNo;
			}


			// 執行 將值塞入 sqlCommand1.Parameters 中, 以執行 新增入資料庫
			//Response.Write(this.sqlCommand1.CommandText);
			this.sqlCommand1.Parameters["@bkcd"].Value = strBkcd;
			this.sqlCommand1.Parameters["@conttp"].Value = strConttp;
			this.sqlCommand1.Parameters["@fgmosea"].Value = strfgMOSea;
			this.sqlCommand1.Parameters["@yyyymm"].Value = strYYYYMM;
			DataSet xrds = new DataSet();

			// 確認執行 sqlCommand1 成功
			bool ResultFlag1 = false;
			this.sqlCommand1.Connection.Open();
			// 使用 Transaction 確認有執行動作
			System.Data.SqlClient.SqlTransaction myTrans1 = this.sqlCommand1.Connection.BeginTransaction();
			this.sqlCommand1.Transaction = myTrans1;
			//Response.Write(sqlCommand1.Parameters.Count.ToString().Trim());
			try
			{
				//System.Xml.XmlReader xr = this.sqlCommand1.ExecuteXmlReader();
				//xrds.ReadXml(xr, XmlReadMode.Fragment);
				System.Data.SqlClient.SqlDataAdapter da1 = new System.Data.SqlClient.SqlDataAdapter();
				da1.SelectCommand = this.sqlCommand1;
				da1.Fill(xrds, "c2_cont");
				myTrans1.Commit();
			}
			catch(System.Data.SqlClient.SqlException ex1)
			{
				Response.Write(ex1.Message + "<br>");
				myTrans1.Rollback();
			}
			finally
			{
				this.sqlCommand1.Connection.Close();
			}

			// 使用 DataSet 方法, 並指定使用的 table 名稱
			DataView dv1 = xrds.Tables["c2_cont"].DefaultView;

			// 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
			// 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
			string rowfilterstr1 = "1=1";
			// 承辦業務員 篩選條件
			if(strEmpNo != "")
			{
				rowfilterstr1 = rowfilterstr1 + " AND cont_empno='" + strEmpNo + "'";
			}
			else
			{
				rowfilterstr1 = rowfilterstr1;
			}

			// 郵寄類別
			if(strMtpcd != "")
			{
				rowfilterstr1 = rowfilterstr1 + " AND or_mtpcd='" + strMtpcd + "'";
			}
			else
			{
				rowfilterstr1 = rowfilterstr1;
			}
			dv1.RowFilter = rowfilterstr1;


			// 若搜尋結果為 "找不到" 的處理
			if (dv1.Count > 0)
			{
				//this.TextBox1.Text = xrds.GetXml();

				if(strfgMOSea == "0")
				{
					DataList1.DataSource = dv1;
					DataList1.DataBind();


					for(int i=0; i < DataList1.Items.Count; i++)
					{
						// 書籍期別
						((Label)DataList1.Items[i].FindControl("lblBkpNo1")).Text = strBookPNo;
					}
				}
				else
				{
					DataList2.DataSource=dv1;
					DataList2.DataBind();


					for(int j=0; j < DataList2.Items.Count; j++)
					{
						// 書籍期別
						((Label)DataList2.Items[j].FindControl("lblBkpNo2")).Text = strBookPNo;
					}
				}
			}
			else
			{
				this.DataList1.Visible = false;
				this.DataList2.Visible = false;
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			//
			// sqlCommand1
			//
			this.sqlCommand1.CommandText = "dbo.[sp_c2_pubfm_lbl_unpub]";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@bkcd", System.Data.SqlDbType.VarChar, 2));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@conttp", System.Data.SqlDbType.VarChar, 2));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@fgmosea", System.Data.SqlDbType.VarChar, 1));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.VarChar, 6));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
