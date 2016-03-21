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
	/// Summary description for AdCheckList.
	/// </summary>
	public class AdCheckList : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox tbxQContNo;
		protected System.Web.UI.WebControls.TextBox tbxMinDate;
		protected System.Web.UI.WebControls.ImageButton imbMinDate;
		protected System.Web.UI.WebControls.TextBox tbxMaxDate;
		protected System.Web.UI.WebControls.ImageButton imbMaxDate;
		protected System.Web.UI.WebControls.Calendar calSelectAdDate;
		protected System.Web.UI.WebControls.Button btnGo;
		protected System.Web.UI.WebControls.Panel pnlQArea;
		protected System.Web.UI.WebControls.Label lblAdrDesc;
		protected System.Web.UI.WebControls.DataGrid dgdAdr;
		protected System.Web.UI.WebControls.Panel pnlAdr;
		protected System.Web.UI.HtmlControls.HtmlTable tblByContNo;
		protected System.Web.UI.HtmlControls.HtmlTable tblBySignDate;
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPUB;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaAdrIm;
		protected System.Web.UI.WebControls.TextBox tbxAdMaxDate;
		protected System.Web.UI.WebControls.TextBox tbxMfrNm;
		protected System.Web.UI.WebControls.TextBox tbxAdMinDate;
		protected System.Web.UI.HtmlControls.HtmlTable tblByEmpNo;
		protected System.Web.UI.HtmlControls.HtmlTable tblByMfrNm;
		protected System.Web.UI.HtmlControls.HtmlTable tblByAdrInterval;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaMfr;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.CheckBox cbxContNo;
		protected System.Web.UI.WebControls.CheckBox cbxSignDate;
		protected System.Web.UI.WebControls.CheckBox cbxEmpNo;
		protected System.Web.UI.WebControls.CheckBox cbxAdDate;
		protected System.Web.UI.WebControls.CheckBox cbxMfrNm;
		protected System.Web.UI.WebControls.DropDownList ddlEmpNo;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaSrspn;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidDateTarget;
	
		public AdCheckList()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				this.calSelectAdDate.Visible = false;
				this.dgdAdr.Visible = false;
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
			this.sqlCnnMRLPUB = new System.Data.SqlClient.SqlConnection();
			this.sqlDaAdrIm = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDaSrspn = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.imbMinDate.Click += new System.Web.UI.ImageClickEventHandler(this.imbMinDate_Click);
			this.imbMaxDate.Click += new System.Web.UI.ImageClickEventHandler(this.imbMaxDate_Click);
			this.calSelectAdDate.SelectionChanged += new System.EventHandler(this.calSelectAdDate_SelectionChanged);
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// sqlDaMfr
			// 
			this.sqlDaMfr.SelectCommand = this.sqlSelectCommand2;
			this.sqlDaMfr.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							   new System.Data.Common.DataTableMapping("Table", "mfr", new System.Data.Common.DataColumnMapping[] {
																																																	  new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																	  new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT mfr_mfrno, mfr_inm FROM dbo.mfr";
			this.sqlSelectCommand2.Connection = this.sqlCnnMRLPUB;
			// 
			// sqlCnnMRLPUB
			// 
			this.sqlCnnMRLPUB.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDaAdrIm
			// 
			this.sqlDaAdrIm.SelectCommand = this.sqlSelectCommand1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c4_adr.adr_syscd, dbo.c4_adr.adr_contno, dbo.c4_adr.adr_sdate, dbo.c4_adr.adr_edate, dbo.c4_adr.adr_seq, dbo.c4_adr.adr_invamt, dbo.c4_adr.adr_adcate, dbo.c4_adr.adr_keyword, dbo.c4_adr.adr_alttext, dbo.c4_adr.adr_imgurl, dbo.c4_adr.adr_drafttp, dbo.c4_adr.adr_navurl, dbo.c4_adr.adr_impr, dbo.c4_adr.adr_fgfixad, dbo.c4_adr.adr_fggot, dbo.c4_adr.adr_adamt, dbo.c4_adr.adr_desamt, dbo.c4_adr.adr_chgamt, dbo.c4_adr.adr_remark, dbo.c4_adr.adr_fginvself, dbo.c4_adr.adr_projno, dbo.c4_adr.adr_costctr, dbo.c4_adr.adr_imseq, dbo.c4_adr.adr_fgact, dbo.invmfr.im_nm, dbo.invmfr.im_mfrno, dbo.invmfr.im_contno, dbo.invmfr.im_imseq, dbo.invmfr.im_syscd, dbo.c4_cont.cont_signdate, dbo.c4_cont.cont_contno, dbo.c4_cont.cont_syscd, dbo.c4_cont.cont_empno, dbo.c4_cont.cont_sdate, dbo.c4_cont.cont_edate, dbo.c4_cont.cont_mfrno, dbo.c4_adr.adr_urltp FROM dbo.c4_adr INNER JOIN dbo.c4_cont ON dbo.c4_adr.adr_syscd = dbo.c4_cont.cont_syscd AND dbo.c4_adr.adr_contno = dbo.c4_cont.cont_contno LEFT OUTER JOIN dbo.invmfr ON dbo.c4_adr.adr_syscd = dbo.invmfr.im_syscd AND dbo.c4_adr.adr_contno = dbo.invmfr.im_contno AND dbo.c4_adr.adr_imseq = dbo.invmfr.im_imseq WHERE (dbo.c4_adr.adr_syscd = 'C4')";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPUB;
			// 
			// sqlDaSrspn
			// 
			this.sqlDaSrspn.SelectCommand = this.sqlSelectCommand3;
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT srspn_empno, srspn_cname FROM dbo.srspn WHERE (srspn_atype = 'B' OR srspn_atype = 'C')";
			this.sqlSelectCommand3.Connection = this.sqlCnnMRLPUB;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void imbMinDate_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.hidDateTarget.Value = "BEGIN";
			this.calSelectAdDate.Visible = true;
		}

		private void imbMaxDate_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.hidDateTarget.Value = "END";
			this.calSelectAdDate.Visible = true;
		}

		private void calSelectAdDate_SelectionChanged(object sender, System.EventArgs e)
		{
			if (this.hidDateTarget.Value == "BEGIN")
				this.tbxMinDate.Text = this.calSelectAdDate.SelectedDate.ToString("yyyy/MM/dd");
			else
				this.tbxMaxDate.Text = this.calSelectAdDate.SelectedDate.ToString("yyyy/MM/dd");

			this.calSelectAdDate.Visible = false;
		}

		private void AlertMsg(string strMsg)
		{
			if (strMsg != null && strMsg != "")
			{
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"" + strMsg +"\");</script>";
				Page.Controls.Add(litAlert);
			}
		}

		private void Bind_ddlEmpNo()
		{
			DataSet ds = new DataSet();
			this.sqlDaSrspn.Fill(ds, "EMPDATA");
			DataView dv = ds.Tables["EMPDATA"].DefaultView;

			this.ddlEmpNo.DataTextField = "srspn_cname";
			this.ddlEmpNo.DataValueField = "srspn_empno";
			this.ddlEmpNo.DataSource = dv;
			this.ddlEmpNo.DataBind();
		}

		private string GetFilter()
		{
			string strReturn = "";
			int fcount = 0;

			DateTime MinDate;
			DateTime MaxDate;
			DateTime AdMinDate;
			DateTime AdMaxDate;

			//for公司名稱
			DataSet ds = new DataSet();
			this.sqlDaMfr.Fill(ds, "MFR");
			DataView dv = ds.Tables["MFR"].DefaultView;
			dv.RowFilter = "mfr_inm LIKE '%" + this.tbxMfrNm.Text.Trim() + "%'";

			if (cbxContNo.Checked)
			{
				if (tbxQContNo.Text.Trim()!="")
				{
					//if (fcount>0) strReturn += " AND ";
					strReturn = "adr_contno = '" + this.tbxQContNo.Text.Trim() + "'";
					fcount++;
				}
			}

			if (cbxSignDate.Checked)
			{
				if (this.tbxMinDate.Text.Trim()!="" && this.tbxMaxDate.Text.Trim()!="")
				{
					MinDate = DateTime.ParseExact(this.tbxMinDate.Text.Trim(), "yyyy/MM/dd", null);
					MaxDate = DateTime.ParseExact(this.tbxMaxDate.Text.Trim(), "yyyy/MM/dd", null);
					if (MinDate > MaxDate)
					{
						AlertMsg("最小日期不可大於最大日期");
					}
					else
					{
						if (fcount>0) strReturn += " AND ";
						strReturn += "cont_signdate>='" + MinDate.ToString("yyyyMMdd", null) + "' AND cont_signdate<='" + MaxDate.ToString("yyyyMMdd", null)  + "'";
						fcount++;
					}
				}
			}

			if (cbxEmpNo.Checked)
			{
				if (fcount>0) strReturn += " AND ";
				strReturn += "cont_empno='" + ddlEmpNo.SelectedItem.Value.Trim() + "' OR cont_empno='" + ddlEmpNo.SelectedItem.Value.Trim() + " " +"'";
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
						fcount++;
					}
					else
					{
						AlertMsg("無此廠商名稱");
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

		private void btnGo_Click(object sender, System.EventArgs e)
		{
			Bind_dgdAdr(GetFilter());
		}

		//定輪播中文轉換
		protected object GetFgFixAdNm(object fgfixad)
		{
			string strReturn = "";
			
			if (fgfixad.ToString() == "1")
				strReturn = "定播";
			else
				strReturn = "輪播";

			return strReturn;
		}

		//到稿註記中文轉換
		protected object GetFgGotNm(object fggot)
		{
			string strReturn = "";
			
			if (fggot.ToString() == "1")
				strReturn = "是";
			else
				strReturn = "否";

			return strReturn;
		}

		//取得純粹圖檔檔名
		protected object GetImgUrlFile(object imgurl)
		{
			string strReturn = "";
		
			if (imgurl.ToString() != "")
			{
				strReturn = imgurl.ToString().Substring(imgurl.ToString().LastIndexOf("/") + 1);
			}

			return strReturn;
		}

		private void Bind_dgdAdr(string strFilter)
		{
			DataSet ds = new DataSet();
			this.sqlDaAdrIm.Fill(ds, "ADRIM");
			DataView dv = ds.Tables["ADRIM"].DefaultView;

			dv.RowFilter = strFilter;
			dv.Sort = "adr_contno, adr_seq";

			if (dv.Count > 0)
			{
				dgdAdr.DataSource = dv;
				dgdAdr.DataBind();

				this.dgdAdr.Visible = true;
				this.lblAdrDesc.Text = "廣告落版列表";
			}
			else
			{
				this.dgdAdr.Visible = false;
				this.lblAdrDesc.Text = "選取的條件下無廣告落版";
			}
		}

	}
}
