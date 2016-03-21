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
	/// Summary description for AdQueryCont.
	/// </summary>
	public class AdQueryCont : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.RadioButtonList rblQueryType;
		protected System.Web.UI.WebControls.Button btnGo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidDateTarget;
		protected System.Web.UI.WebControls.TextBox tbxQContNo;
		protected System.Web.UI.WebControls.ImageButton imbMinDate;
		protected System.Web.UI.HtmlControls.HtmlTable tblBySignDate;
		protected System.Web.UI.HtmlControls.HtmlTable tblByContNo;
		protected System.Web.UI.WebControls.Calendar calSelectAdDate;
		protected System.Web.UI.WebControls.ImageButton imbMaxDate;
		protected System.Web.UI.WebControls.TextBox tbxMinDate;
		protected System.Web.UI.WebControls.TextBox tbxMaxDate;
		protected System.Web.UI.WebControls.Panel pnlAdr;
		protected System.Web.UI.WebControls.DataGrid dgdAdr;
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPUB;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaAdrIm;
		protected System.Web.UI.WebControls.Panel pnlQArea;
		protected System.Web.UI.WebControls.TextBox tbxMfrNm;
		protected System.Web.UI.HtmlControls.HtmlTable tblByMfrNm;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.Label lblAdrDesc;
	
		public AdQueryCont()
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

				//預設隱藏日期範圍
				this.tblBySignDate.Visible = false;
				this.tblByMfrNm.Visible = false;
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

			this.sqlDaAdrIm = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCnnMRLPUB = new System.Data.SqlClient.SqlConnection();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.rblQueryType.SelectedIndexChanged += new System.EventHandler(this.rblQueryType_SelectedIndexChanged);
			this.imbMinDate.Click += new System.Web.UI.ImageClickEventHandler(this.imbMinDate_Click);
			this.imbMaxDate.Click += new System.Web.UI.ImageClickEventHandler(this.imbMaxDate_Click);
			this.calSelectAdDate.SelectionChanged += new System.EventHandler(this.calSelectAdDate_SelectionChanged);
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			this.dgdAdr.SelectedIndexChanged += new System.EventHandler(this.dgdAdr_SelectedIndexChanged);
			// 
			// sqlDaAdrIm
			// 
			this.sqlDaAdrIm.SelectCommand = this.sqlSelectCommand1;
			// 
			// sqlCnnMRLPUB
			// 
			this.sqlCnnMRLPUB.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT dbo.invmfr.im_syscd, dbo.invmfr.im_contno, dbo.invmfr.im_imseq, dbo.invmfr" +
				".im_mfrno, dbo.invmfr.im_nm, DRIVERTBL.adr_syscd, DRIVERTBL.adr_contno, DRIVERTB" +
				"L.adr_sdate, DRIVERTBL.adr_edate, DRIVERTBL.adr_seq, DRIVERTBL.adr_invamt, DRIVE" +
				"RTBL.adr_adcate, DRIVERTBL.adr_keyword, DRIVERTBL.adr_alttext, DRIVERTBL.adr_img" +
				"url, DRIVERTBL.adr_drafttp, DRIVERTBL.adr_navurl, DRIVERTBL.adr_impr, DRIVERTBL." +
				"adr_fgfixad, DRIVERTBL.adr_fggot, DRIVERTBL.adr_adamt, DRIVERTBL.adr_desamt, DRI" +
				"VERTBL.adr_chgamt, DRIVERTBL.adr_remark, DRIVERTBL.adr_fginvself, DRIVERTBL.adr_" +
				"projno, DRIVERTBL.adr_costctr, DRIVERTBL.adr_imseq, DRIVERTBL.adr_fgact, DRIVERT" +
				"BL.cont_signdate, DRIVERTBL.cont_contno, DRIVERTBL.cont_syscd, DRIVERTBL.adr_url" +
				"tp, DRIVERTBL.cont_custno, DRIVERTBL.cont_conttp, DRIVERTBL.cont_mfrno, dbo.mfr." +
				"mfr_inm, dbo.mfr.mfr_mfrno FROM (SELECT dbo.c4_adr.adr_syscd , dbo.c4_adr.adr_co" +
				"ntno , dbo.c4_adr.adr_sdate , dbo.c4_adr.adr_edate , dbo.c4_adr.adr_seq , dbo.c4" +
				"_adr.adr_invamt , dbo.c4_adr.adr_adcate , dbo.c4_adr.adr_keyword , dbo.c4_adr.ad" +
				"r_alttext , dbo.c4_adr.adr_imgurl , dbo.c4_adr.adr_drafttp , dbo.c4_adr.adr_navu" +
				"rl , dbo.c4_adr.adr_impr , dbo.c4_adr.adr_fgfixad , dbo.c4_adr.adr_fggot , dbo.c" +
				"4_adr.adr_adamt , dbo.c4_adr.adr_desamt , dbo.c4_adr.adr_chgamt , dbo.c4_adr.adr" +
				"_remark , dbo.c4_adr.adr_fginvself , dbo.c4_adr.adr_projno , dbo.c4_adr.adr_cost" +
				"ctr , dbo.c4_adr.adr_imseq , dbo.c4_adr.adr_fgact , dbo.c4_cont.cont_signdate , " +
				"dbo.c4_cont.cont_contno , dbo.c4_cont.cont_syscd , dbo.c4_adr.adr_urltp , dbo.c4" +
				"_cont.cont_custno , cont_conttp , cont_mfrno FROM dbo.c4_adr INNER JOIN dbo.c4_c" +
				"ont ON dbo.c4_adr.adr_syscd = dbo.c4_cont.cont_syscd AND dbo.c4_adr.adr_contno =" +
				" dbo.c4_cont.cont_contno WHERE (dbo.c4_adr.adr_syscd = \'C4\') AND (dbo.c4_cont.co" +
				"nt_fgtemp = \'0\') AND (dbo.c4_cont.cont_fgclosed = \'0\') AND (dbo.c4_cont.cont_fgc" +
				"ancel = \'0\')) DRIVERTBL LEFT OUTER JOIN dbo.mfr ON DRIVERTBL.cont_mfrno COLLATE " +
				"Chinese_Taiwan_Stroke_CI_AS = dbo.mfr.mfr_mfrno LEFT OUTER JOIN dbo.invmfr ON DR" +
				"IVERTBL.adr_syscd = dbo.invmfr.im_syscd AND DRIVERTBL.adr_contno = dbo.invmfr.im" +
				"_contno AND DRIVERTBL.adr_imseq = dbo.invmfr.im_imseq";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPUB;
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

		private void btnGo_Click(object sender, System.EventArgs e)
		{
			string strFilter = "";
			if (this.rblQueryType.SelectedItem.Value == "0")
			{
				//由合約書編號
				strFilter = "adr_contno = '" + this.tbxQContNo.Text.Trim() + "'";
			}
			else if (this.rblQueryType.SelectedItem.Value == "1")
			{
				//由範圍日期
				if (tbxMinDate.Text == "" || tbxMaxDate.Text == "")
				{
					AlertMsg("日期範圍兩者皆不可空白");
					return;
				}

				DateTime MinDate = DateTime.ParseExact(this.tbxMinDate.Text.Trim(), "yyyy/MM/dd", null);
				DateTime MaxDate = DateTime.ParseExact(this.tbxMaxDate.Text.Trim(), "yyyy/MM/dd", null);

				if (MinDate > MaxDate)
				{
					AlertMsg("最小日期不可大於最大日期");
					return;
				}

				strFilter = "cont_signdate>='" + MinDate.ToString("yyyyMMdd", null) + "' AND cont_signdate<='" + MaxDate.ToString("yyyyMMdd", null)  + "'";
			}
			else
			{
				//由廠商名稱
				if (tbxMfrNm.Text == "")
				{
					AlertMsg("廠商名稱不可空白");
					return;
				}

				strFilter = "mfr_inm LIKE '%" + tbxMfrNm.Text.Trim()  + "%'";
			}

			Bind_dgdAdr(strFilter);
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

		private void rblQueryType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.rblQueryType.SelectedItem.Value == "0")
			{
				//由合約編號
				this.tblByContNo.Visible = true;
				this.tblBySignDate.Visible = false;
				this.tblByMfrNm.Visible = false;
			}
			else if (this.rblQueryType.SelectedItem.Value == "1")
			{
				//由簽約日期
				this.tblByContNo.Visible = false;
				this.tblBySignDate.Visible = true;
				this.tblByMfrNm.Visible = false;
			}
			else
			{
				//由廠商名稱
				this.tblByContNo.Visible = false;
				this.tblBySignDate.Visible = false;
				this.tblByMfrNm.Visible = true;
			}
		}

		private void dgdAdr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string NewContNo = dgdAdr.SelectedItem.Cells[1].Text.Trim();
			string AdSeq = dgdAdr.SelectedItem.Cells[2].Text.Trim();
			Response.Redirect("./AdPostPublish.aspx?NewContNo="+NewContNo+"&CustNo="+dgdAdr.SelectedItem.Cells[20].Text.Trim());
		}
	}
}
