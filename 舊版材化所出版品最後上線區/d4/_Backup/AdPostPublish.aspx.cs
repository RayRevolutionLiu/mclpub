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
	/// Summary description for AdPostPublish.
	/// </summary>
	public class AdPostPublish : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblStep0;
		protected System.Web.UI.WebControls.Label lblStep1;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.DropDownList ddlInvMfr;
		protected System.Web.UI.WebControls.TextBox tbxNavUrl;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.TextBox tbxAdAmt;
		protected System.Web.UI.WebControls.TextBox tbxInvAmt;
		protected System.Web.UI.WebControls.TextBox tbxAltText;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.TextBox tbxDesAmt;
		protected System.Web.UI.WebControls.TextBox tbxChgAmt;
		protected System.Web.UI.WebControls.TextBox tbxBeginDate;
		protected System.Web.UI.WebControls.DropDownList ddlFgGot;
		protected System.Web.UI.WebControls.TextBox tbxEndDate;
		protected System.Web.UI.WebControls.DropDownList ddlAdCate;
		protected System.Web.UI.WebControls.DropDownList ddlFgFixAd;
		protected System.Web.UI.WebControls.TextBox tbxImpression;
		protected System.Web.UI.WebControls.TextBox tbxRemark;
		protected System.Web.UI.WebControls.Label lblStep2;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidDateTarget;
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPUB;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaAdrIm;
		protected System.Web.UI.WebControls.DataGrid dgdAdrIm;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaIm;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlCmdUpdateAdr;
		protected System.Web.UI.WebControls.RadioButtonList rblDraftTp;
		protected System.Web.UI.WebControls.RadioButtonList rblUrlTp;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidOldContNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCustNo;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Web.UI.WebControls.DropDownList ddlKey;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileAdImage;
	
		public AdPostPublish()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				Bind_dgdAdrIm();
				Bind_ddlInvMfr();
				InitData();
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

			this.sqlCmdUpdateAdr = new System.Data.SqlClient.SqlCommand();
			this.sqlCnnMRLPUB = new System.Data.SqlClient.SqlConnection();
			this.sqlDaIm = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDaAdrIm = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.dgdAdrIm.SelectedIndexChanged += new System.EventHandler(this.dgdAdrIm_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// sqlCmdUpdateAdr
			// 
			this.sqlCmdUpdateAdr.CommandText = @"UPDATE dbo.c4_adr SET adr_fggot = '1', adr_remark = @adr_remark, adr_alttext = @adr_alttext, adr_imgurl = @adr_imgurl, adr_drafttp = @adr_drafttp, adr_navurl = @adr_navurl, adr_urltp = @adr_urltp WHERE (adr_syscd = 'C4') AND (adr_contno = @adr_contno) AND (adr_seq = @adr_seq)";
			this.sqlCmdUpdateAdr.Connection = this.sqlCnnMRLPUB;
			this.sqlCmdUpdateAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_remark", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_remark", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_alttext", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_alttext", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_imgurl", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_imgurl", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_drafttp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_drafttp", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_navurl", System.Data.SqlDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_navurl", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_urltp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_urltp", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCmdUpdateAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_seq", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCnnMRLPUB
			// 
			this.sqlCnnMRLPUB.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDaIm
			// 
			this.sqlDaIm.SelectCommand = this.sqlSelectCommand2;
			this.sqlDaIm.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																							  new System.Data.Common.DataTableMapping("Table", "invmfr", new System.Data.Common.DataColumnMapping[] {
																																																		new System.Data.Common.DataColumnMapping("im_syscd", "im_syscd"),
																																																		new System.Data.Common.DataColumnMapping("im_contno", "im_contno"),
																																																		new System.Data.Common.DataColumnMapping("im_imseq", "im_imseq"),
																																																		new System.Data.Common.DataColumnMapping("im_mfrno", "im_mfrno"),
																																																		new System.Data.Common.DataColumnMapping("im_nm", "im_nm")})});
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT im_syscd, im_contno, im_imseq, im_mfrno, im_nm FROM dbo.invmfr WHERE (im_s" +
				"yscd = \'C4\') AND (im_contno = @im_contno)";
			this.sqlSelectCommand2.Connection = this.sqlCnnMRLPUB;
			this.sqlSelectCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@im_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "im_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDaAdrIm
			// 
			this.sqlDaAdrIm.SelectCommand = this.sqlSelectCommand1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.c4_adr.adr_syscd, dbo.c4_adr.adr_contno, dbo.c4_adr.adr_sdate, dbo.c4_adr.adr_edate, dbo.c4_adr.adr_seq, dbo.c4_adr.adr_invamt, dbo.c4_adr.adr_adcate, dbo.c4_adr.adr_keyword, dbo.c4_adr.adr_alttext, dbo.c4_adr.adr_imgurl, dbo.c4_adr.adr_drafttp, dbo.c4_adr.adr_navurl, dbo.c4_adr.adr_urltp, dbo.c4_adr.adr_impr, dbo.c4_adr.adr_fgfixad, dbo.c4_adr.adr_fggot, dbo.c4_adr.adr_adamt, dbo.c4_adr.adr_desamt, dbo.c4_adr.adr_chgamt, dbo.c4_adr.adr_remark, dbo.c4_adr.adr_fginvself, dbo.c4_adr.adr_projno, dbo.c4_adr.adr_costctr, dbo.c4_adr.adr_imseq, dbo.c4_adr.adr_fgact, dbo.invmfr.im_nm, dbo.invmfr.im_mfrno, dbo.invmfr.im_contno, dbo.invmfr.im_imseq, dbo.invmfr.im_syscd, dbo.c4_adr.adr_urltp AS Expr1 FROM dbo.c4_adr LEFT OUTER JOIN dbo.invmfr ON dbo.c4_adr.adr_syscd = dbo.invmfr.im_syscd AND dbo.c4_adr.adr_contno = dbo.invmfr.im_contno AND dbo.c4_adr.adr_imseq = dbo.invmfr.im_imseq WHERE (dbo.c4_adr.adr_syscd = 'C4') AND (dbo.c4_adr.adr_contno = @adr_contno)";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPUB;
			this.sqlSelectCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_contno", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
//		this.sqlCmdUpdateAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_navurl", System.Data.SqlDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_navurl", System.Data.DataRowVersion.Current, null));
//		this.sqlCmdUpdateAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_alttext", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_alttext", System.Data.DataRowVersion.Current, null));
//		this.sqlCmdUpdateAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_imgurl", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_imgurl", System.Data.DataRowVersion.Current, null));
//		this.sqlCmdUpdateAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_remark", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_remark", System.Data.DataRowVersion.Current, null));
//		this.sqlCmdUpdateAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_contno", System.Data.DataRowVersion.Current, null));
//		this.sqlCmdUpdateAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_seq", System.Data.DataRowVersion.Current, null));


		//初始資料
		private void InitData()
		{
			string NewContNo = Request.QueryString["NewContNo"];
			this.lblStep0.Text = NewContNo + "的網路廣告落版資料";
			this.hidOldContNo.Value = "";
			this.hidCustNo.Value = Request.QueryString.Get("CustNo").Trim();
		}

		//連接落版資料跟發票廠商資料
		private void Bind_dgdAdrIm()
		{
			string NewContNo = Request.QueryString["NewContNo"].Trim();
			this.sqlDaAdrIm.SelectCommand.Parameters["@adr_contno"].Value = NewContNo;
			DataSet ds = new DataSet();
			this.sqlDaAdrIm.Fill(ds, "ADRIM");
			DataView dv = ds.Tables["ADRIM"].DefaultView;

			if (dv.Count>0)
			{
				dgdAdrIm.DataSource = dv;
				dgdAdrIm.DataBind();

				dgdAdrIm.Visible = true;
			}
			else
			{
				dgdAdrIm.Visible = false;
			}
		}

		//發票廠商資料
		private void Bind_ddlInvMfr()
		{
			string NewContNo = Request.QueryString["NewContNo"];
			this.sqlDaIm.SelectCommand.Parameters["@im_contno"].Value = NewContNo;
			DataSet ds = new DataSet();
			this.sqlDaIm.Fill(ds, "IM");
			DataView dv = ds.Tables["IM"].DefaultView;

			this.ddlInvMfr.DataTextField = "im_nm";
			this.ddlInvMfr.DataValueField = "im_imseq";
			this.ddlInvMfr.DataSource = dv;
			this.ddlInvMfr.DataBind();
		}

		//丟alert message
		private void AlertMsg(string strMsg)
		{
			if (strMsg != null && strMsg != "")
			{
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"" + strMsg +"\");</script>";
				Page.Controls.Add(litAlert);
			}
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

		//載入填表區
		private void dgdAdrIm_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string NewContNo = Request.QueryString["NewContNo"];
			this.tbxAdAmt.Text = dgdAdrIm.SelectedItem.Cells[12].Text.Trim();
			this.tbxAltText.Text = dgdAdrIm.SelectedItem.Cells[2].Text.Trim();
			this.tbxBeginDate.Text = DateTime.ParseExact(dgdAdrIm.SelectedItem.Cells[3].Text.Trim(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
			this.tbxChgAmt.Text = dgdAdrIm.SelectedItem.Cells[14].Text.Trim();
			this.tbxContNo.Text = NewContNo;
			this.tbxDesAmt.Text = dgdAdrIm.SelectedItem.Cells[13].Text.Trim();
			this.tbxEndDate.Text = DateTime.ParseExact(dgdAdrIm.SelectedItem.Cells[4].Text.Trim(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
			this.tbxImpression.Text = dgdAdrIm.SelectedItem.Cells[7].Text.Trim();
			this.tbxInvAmt.Text = dgdAdrIm.SelectedItem.Cells[10].Text.Trim();
			this.tbxNavUrl.Text = dgdAdrIm.SelectedItem.Cells[15].Text.Trim();
			this.tbxRemark.Text = dgdAdrIm.SelectedItem.Cells[16].Text.Trim();
			this.ddlAdCate.SelectedIndex = -1;
			this.ddlAdCate.Items.FindByValue(dgdAdrIm.SelectedItem.Cells[5].Text.Trim()).Selected = true;
			this.ddlFgFixAd.SelectedIndex = -1;
			this.ddlFgFixAd.Items.FindByValue(dgdAdrIm.SelectedItem.Cells[18].Text.Trim()).Selected = true;
			this.ddlFgGot.SelectedIndex = -1;
			this.ddlFgGot.Items.FindByValue(dgdAdrIm.SelectedItem.Cells[19].Text.Trim()).Selected = true;

			if (dgdAdrIm.SelectedItem.Cells[17].Text.Trim()!="")
			{
				this.ddlInvMfr.SelectedIndex = -1;
				this.ddlInvMfr.Items.FindByValue(dgdAdrIm.SelectedItem.Cells[17].Text.Trim()).Selected = true;
			}
			this.ddlKey.SelectedIndex = -1;
			this.ddlKey.Items.FindByValue(dgdAdrIm.SelectedItem.Cells[6].Text.Trim()).Selected = true;
			this.rblDraftTp.SelectedIndex = -1;
			this.rblDraftTp.Items.FindByValue(dgdAdrIm.SelectedItem.Cells[20].Text.Trim()).Selected = true;
			this.rblUrlTp.SelectedIndex = -1;
			this.rblUrlTp.Items.FindByValue(dgdAdrIm.SelectedItem.Cells[21].Text.Trim()).Selected = true;
			this.hidCustNo.Value = Request.QueryString.Get("CustNo").Trim();
		}

		//觸發儲存廣告
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (dgdAdrIm.SelectedIndex < 0)
			{
				AlertMsg("尚未選擇要落版的廣告");
				return;
			}

			//處理圖檔
			string PostedFileName = "";
			if (this.fileAdImage == null)
			{
				AlertMsg("檔案上傳物件為NULL，請通知聯絡人");
				return;
			}
			if (this.fileAdImage.PostedFile == null)
			{
				AlertMsg("檔案上傳內容為NULL，請通知聯絡人");
				return;
			}

			PostedFileName = this.fileAdImage.PostedFile.FileName.Substring(fileAdImage.PostedFile.FileName.LastIndexOf("\\") + 1);

			if (this.fileAdImage.PostedFile.ContentLength<=0)
			{
				AlertMsg("檔案: " + PostedFileName + " 大小為零。");
				return;
			}
			
			//注意路徑
			if (System.IO.File.Exists(Server.MapPath(".") + "/ADImages/"+ PostedFileName))
			{
				AlertMsg("檔案: " + PostedFileName + "已經存在，請重新更改檔名再選擇");
				return;
			}

			fileAdImage.PostedFile.SaveAs(Server.MapPath(".") + "/ADImages/"+ PostedFileName);

			//AlertMsg("檔案: " + PostedFileName + "成功上傳");

			//Update c4_adr
			string NewContNo = Request.QueryString["NewContNo"];

			this.sqlCmdUpdateAdr.Parameters["@adr_contno"].Value = NewContNo;
			this.sqlCmdUpdateAdr.Parameters["@adr_seq"].Value = dgdAdrIm.SelectedItem.Cells[1].Text.Trim();
			this.sqlCmdUpdateAdr.Parameters["@adr_imgurl"].Value = PostedFileName;
			this.sqlCmdUpdateAdr.Parameters["@adr_navurl"].Value = this.tbxNavUrl.Text.Trim();
			this.sqlCmdUpdateAdr.Parameters["@adr_alttext"].Value = this.tbxAltText.Text.Trim();
			this.sqlCmdUpdateAdr.Parameters["@adr_remark"].Value = this.tbxRemark.Text.Trim();
			this.sqlCmdUpdateAdr.Parameters["@adr_drafttp"].Value = this.rblDraftTp.SelectedItem.Value;
			this.sqlCmdUpdateAdr.Parameters["@adr_urltp"].Value = this.rblUrlTp.SelectedItem.Value;


			this.sqlCmdUpdateAdr.Connection.Open();
			try
			{
				this.sqlCmdUpdateAdr.ExecuteNonQuery();
				AlertMsg("廣告落版儲存成功");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				System.IO.File.Delete(Server.MapPath(".") + "/ADImages/"+ PostedFileName);
				AlertMsg("廣告落版儲存失敗，" + "檔案: " + PostedFileName + "清除"+ex.Message);
			}
			this.sqlCmdUpdateAdr.Connection.Close();

			Bind_dgdAdrIm();
		}

		//清除欄位
		private void ClearFields()
		{
			this.tbxAdAmt.Text = "";
			this.tbxAltText.Text = "";
			this.tbxBeginDate.Text = "";
			this.tbxChgAmt.Text = "";
			this.tbxContNo.Text = "";
			this.tbxDesAmt.Text = "";
			this.tbxEndDate.Text = "";
			this.tbxImpression.Text = "";
			this.tbxInvAmt.Text = "";
			this.tbxNavUrl.Text = "";
			this.tbxRemark.Text = "";
			this.ddlAdCate.SelectedIndex = -1;
			this.ddlFgFixAd.SelectedIndex = -1;
			this.ddlFgGot.SelectedIndex = -1;
			this.ddlInvMfr.SelectedIndex = -1;
			this.ddlKey.SelectedIndex = -1;
			this.rblDraftTp.SelectedIndex = 0;
			this.rblUrlTp.SelectedIndex = 0;
		}
	}
}
