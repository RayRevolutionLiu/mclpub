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

namespace MRLPub.d4
{
	/// <summary>
	/// Summary description for RptAdList0.
	/// </summary>
	public class RptAdList0 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Web.UI.WebControls.LinkButton lnbShow;
		protected System.Web.UI.WebControls.LinkButton lnbClearAll;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox tbxAdMinDate;
		protected System.Web.UI.WebControls.RegularExpressionValidator revAdMaxDate;
		protected System.Web.UI.WebControls.TextBox tbxMfrNm;
		protected System.Web.UI.WebControls.TextBox tbxAdMaxDate;
		protected System.Web.UI.WebControls.RegularExpressionValidator revAdMinDate;
		protected System.Web.UI.WebControls.CheckBox cbxEmpNo;
		protected System.Web.UI.WebControls.CheckBox cbxMfrNm;
		protected System.Web.UI.WebControls.CheckBox cbxAdDate;
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPub;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaSrspn;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCmdExecSp;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaMfr;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Web.UI.WebControls.Label lblMemo;
	
		public RptAdList0()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				Bind_ddlEmpNo();
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
			System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
			this.sqlDaMfr = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCnnMRLPub = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdExecSp = new System.Data.SqlClient.SqlCommand();
			this.sqlDaSrspn = new System.Data.SqlClient.SqlDataAdapter();
			this.lnbShow.Click += new System.EventHandler(this.lnbShow_Click);
			this.lnbClearAll.Click += new System.EventHandler(this.lnbClearAll_Click);
			// 
			// sqlDaMfr
			// 
			this.sqlDaMfr.SelectCommand = this.sqlSelectCommand2;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT mfr_mfrno, mfr_inm FROM dbo.mfr";
			this.sqlSelectCommand2.Connection = this.sqlCnnMRLPub;
			// 
			// sqlCnnMRLPub
			// 
			this.sqlCnnMRLPub.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT srspn_empno, srspn_id, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, s" +
				"rspn_deptcd, srspn_date, srspn_pwd FROM dbo.srspn WHERE (srspn_atype = \'B\') OR (" +
				"srspn_atype = \'C\')";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPub;
			// 
			// sqlCmdExecSp
			// 
			this.sqlCmdExecSp.CommandText = "dbo.sp_c4_rp_ad_list";
			this.sqlCmdExecSp.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdExecSp.Connection = this.sqlCnnMRLPub;
			this.sqlCmdExecSp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDaSrspn
			// 
			this.sqlDaSrspn.SelectCommand = this.sqlSelectCommand1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void AlertMsg(string strMsg)
		{
			if (strMsg != null && strMsg != "")
			{
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"" + strMsg +"\");</script>";
				Page.Controls.Add(litAlert);
			}
		}

		private string GetFilter()
		{
			string strReturn = "";
			int fcount = 0;

			DateTime AdMinDate;
			DateTime AdMaxDate;

			//for公司名稱
			DataSet ds = new DataSet();
			this.sqlDaMfr.Fill(ds, "MFR");
			DataView dv = ds.Tables["MFR"].DefaultView;
			dv.RowFilter = "mfr_inm LIKE '%" + this.tbxMfrNm.Text.Trim() + "%'";

			if (cbxEmpNo.Checked)
			{
				if (fcount>0) strReturn += " AND ";
				strReturn += "(cont_empno='" + ddlEmpNo.SelectedItem.Value.Trim() + "' OR cont_empno='" + ddlEmpNo.SelectedItem.Value.Trim() + " " +"')";
				fcount++;
			}

			if (cbxMfrNm.Checked)
			{
				if (this.tbxMfrNm.Text.Trim()!="")
				{
					if (dv.Count>0)
					{
						if (fcount>0) strReturn += " AND ";
						strReturn += "cont_mfrno='" + dv[0]["mfr_mfrno"].ToString().Trim() + "'";
//						strReturn += "mfr_inm LIKE '%" + this.tbxMfrNm.Text.Trim() + "%'";
						fcount++;
					}
					else
					{
						//無此公司
						strReturn += "cont_mfrno='000000'";
						//AlertMsg("無此廠商名稱");
					}
				}
			}

			if (cbxAdDate.Checked)
			{
				if (this.tbxAdMaxDate.Text.Trim()!="" && this.tbxAdMinDate.Text.Trim()!="")
				{
					AdMinDate = DateTime.ParseExact(this.tbxAdMinDate.Text.Trim(), "yyyy/MM/dd", null);
					AdMaxDate = DateTime.ParseExact(this.tbxAdMaxDate.Text.Trim(), "yyyy/MM/dd", null);

					if (AdMinDate > AdMaxDate)
					{
						AlertMsg("最小日期不可大於最大日期");
								
					}
					else
					{
						if (fcount>0) strReturn += " AND ";
						strReturn += "NOT (adr_sdate>'" + AdMaxDate.ToString("yyyyMMdd", null) + "' OR adr_edate<'" + AdMinDate.ToString("yyyyMMdd", null)  + "')";
						fcount++;
					}
				}
			}
			return strReturn;
		}

		private void Bind_ddlEmpNo()
		{
			DataSet ds = new DataSet();
			this.sqlDaSrspn.Fill(ds, "SRSPN");
			DataView dv = ds.Tables["SRSPN"].DefaultView;
			ddlEmpNo.DataSource = dv;
			ddlEmpNo.DataTextField = "srspn_cname";
			ddlEmpNo.DataValueField = "srspn_empno";
			ddlEmpNo.DataBind();
		}

		private void lnbClearAll_Click(object sender, System.EventArgs e)
		{
			this.tbxAdMaxDate.Text = "";
			this.tbxAdMinDate.Text = "";
			this.tbxMfrNm.Text = "";
		}

		private void lnbShow_Click(object sender, System.EventArgs e)
		{
			string strFilter = GetFilter();
			string whoami;
			string DomainUser = User.Identity.Name;
			whoami = DomainUser.Substring(DomainUser.LastIndexOf("\\")+1);
			this.sqlCmdExecSp.Connection.Open();
			try
			{
				this.sqlCmdExecSp.ExecuteNonQuery();
				Response.Redirect("RptAdList.aspx?whoami=" + whoami + "&strFilter="+strFilter);
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("廣告列表清單資料產生錯誤");
			}
			this.sqlCmdExecSp.Connection.Close();
		}
	}
}
