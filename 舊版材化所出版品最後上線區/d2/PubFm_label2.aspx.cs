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

				// ��X���Ҹ��
				GetLabelData();
			}
		}


		// ��X���Ҹ��
		private void GetLabelData()
		{
			// ��X�z�����
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


			// ���� �N�ȶ�J sqlCommand1.Parameters ��, �H���� �s�W�J��Ʈw
			//Response.Write(this.sqlCommand1.CommandText);
			this.sqlCommand1.Parameters["@bkcd"].Value = strBkcd;
			this.sqlCommand1.Parameters["@conttp"].Value = strConttp;
			this.sqlCommand1.Parameters["@fgmosea"].Value = strfgMOSea;
			this.sqlCommand1.Parameters["@yyyymm"].Value = strYYYYMM;
			DataSet xrds = new DataSet();

			// �T�{���� sqlCommand1 ���\
			bool ResultFlag1 = false;
			this.sqlCommand1.Connection.Open();
			// �ϥ� Transaction �T�{������ʧ@
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

			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataView dv1 = xrds.Tables["c2_cont"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			// �] Row Filter: default �� 1=1 and ��L rowfilter ����
			string rowfilterstr1 = "1=1";
			// �ӿ�~�ȭ� �z�����
			if(strEmpNo != "")
			{
				rowfilterstr1 = rowfilterstr1 + " AND cont_empno='" + strEmpNo + "'";
			}
			else
			{
				rowfilterstr1 = rowfilterstr1;
			}

			// �l�H���O
			if(strMtpcd != "")
			{
				rowfilterstr1 = rowfilterstr1 + " AND or_mtpcd='" + strMtpcd + "'";
			}
			else
			{
				rowfilterstr1 = rowfilterstr1;
			}
			dv1.RowFilter = rowfilterstr1;


			// �Y�j�M���G�� "�䤣��" ���B�z
			if (dv1.Count > 0)
			{
				//this.TextBox1.Text = xrds.GetXml();

				if(strfgMOSea == "0")
				{
					DataList1.DataSource = dv1;
					DataList1.DataBind();


					for(int i=0; i < DataList1.Items.Count; i++)
					{
						// ���y���O
						((Label)DataList1.Items[i].FindControl("lblBkpNo1")).Text = strBookPNo;
					}
				}
				else
				{
					DataList2.DataSource=dv1;
					DataList2.DataBind();


					for(int j=0; j < DataList2.Items.Count; j++)
					{
						// ���y���O
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
