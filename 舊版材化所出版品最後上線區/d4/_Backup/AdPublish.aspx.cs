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
	/// Summary description for AdPublish.
	/// </summary>
	public class AdPublish : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlInvMfr;
		protected System.Web.UI.WebControls.TextBox tbxChgAmt;
		protected System.Web.UI.WebControls.TextBox tbxNavUrl;
		protected System.Web.UI.WebControls.DropDownList ddlFgGot;
		protected System.Web.UI.WebControls.TextBox tbxDesAmt;
		protected System.Web.UI.WebControls.TextBox tbxAltText;
		protected System.Web.UI.WebControls.TextBox tbxInvAmt;
		protected System.Web.UI.WebControls.TextBox tbxAdAmt;
		protected System.Web.UI.WebControls.TextBox tbxContNo;
		protected System.Web.UI.WebControls.Calendar calSelectAdDate;
		protected System.Data.SqlClient.SqlCommand sqlCmdInsAdr;
		protected System.Data.SqlClient.SqlConnection sqlCnnITRINTS8;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator2;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Data.SqlClient.SqlCommand sqlCmdGetSeq;
		protected System.Web.UI.WebControls.TextBox tbxRemark;
		protected System.Web.UI.WebControls.TextBox tbxBeginDate;
		protected System.Web.UI.WebControls.TextBox tbxEndDate;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidDateTarget;
		protected System.Web.UI.WebControls.DropDownList ddlAdCate;
		protected System.Web.UI.WebControls.DropDownList ddlKey;
		protected System.Web.UI.WebControls.DropDownList ddlFgFixAd;
		protected System.Web.UI.WebControls.TextBox tbxImpression;
		protected System.Web.UI.WebControls.TextBox tbxDraftType;
		protected System.Web.UI.HtmlControls.HtmlInputFile fileAdImage;
		protected System.Web.UI.WebControls.ImageButton imbStartDate;
		protected System.Web.UI.WebControls.ImageButton imbEndDate;
		protected System.Web.UI.WebControls.Label lblStep2;
		protected System.Web.UI.WebControls.Label lblStep3;
		protected System.Web.UI.WebControls.Label lblAdDate;
		protected System.Web.UI.WebControls.TextBox tbxTxtAdCont;
		protected System.Web.UI.WebControls.Label lblStep1;
	
		public AdPublish()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
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
			this.sqlCnnITRINTS8 = new System.Data.SqlClient.SqlConnection();
			this.sqlCmdGetSeq = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdInsAdr = new System.Data.SqlClient.SqlCommand();
			// 
			// sqlCnnITRINTS8
			// 
			this.sqlCnnITRINTS8.ConnectionString = "data source=140.96.170.7,1995;password=ji3z7ha;persist security info=True;user id" +
				"=mrlpubadm;workstation id=17-0900103-01;packet size=4096";
			// 
			// sqlCmdGetSeq
			// 
			this.sqlCmdGetSeq.CommandText = "SELECT adr_seq FROM dbo.c4_adr WHERE (adr_date = @adr_date) AND (adr_contno = @ad" +
				"r_contno) AND (adr_syscd = @adr_syscd)";
			this.sqlCmdGetSeq.Connection = this.sqlCnnITRINTS8;
			this.sqlCmdGetSeq.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_date", System.Data.DataRowVersion.Current, null));
			this.sqlCmdGetSeq.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCmdGetSeq.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCmdInsAdr
			// 
			this.sqlCmdInsAdr.CommandText = @"INSERT INTO dbo.c4_adr (adr_syscd, adr_contno, adr_date, adr_seq, adr_invamt, adr_adcate, adr_keyword, adr_alttext, adr_imgurl, adr_drafttp, adr_navurl, adr_urlcate, adr_txtadcont, adr_txtadcontnm, adr_impr, adr_fgfixad, adr_fggot, adr_adamt, adr_desamt, adr_chgamt, adr_remark, adr_fginved, adr_fginvself, adr_projno, adr_costctr, adr_imseq) VALUES (@adr_syscd, @adr_contno, @adr_date, @adr_seq, @adr_invamt, @adr_adcate, @adr_keyword, @adr_alttext, @adr_imgurl, @adr_drafttp, @adr_navurl, @adr_urlcate, @adr_txtadcont, @adr_txtadcontnm, @adr_impr, @adr_fgfixad, @adr_fggot, @adr_adamt, @adr_desamt, @adr_chgamt, @adr_remark, @adr_fginved, @adr_fginvself, @adr_projno, @adr_costctr, @adr_imseq)";
			this.sqlCmdInsAdr.Connection = this.sqlCnnITRINTS8;
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_contno", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_date", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_seq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_seq", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_invamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_invamt", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_adcate", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_adcate", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_keyword", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_keyword", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_alttext", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_alttext", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_imgurl", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_imgurl", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_drafttp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_drafttp", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_navurl", System.Data.SqlDbType.VarChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_navurl", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_urlcate", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_urlcate", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_txtadcont", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_txtadcont", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_txtadcontnm", System.Data.SqlDbType.Char, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_txtadcontnm", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_impr", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_impr", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_fgfixad", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fgfixad", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_fggot", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fggot", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_adamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_adamt", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_desamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_desamt", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_chgamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_chgamt", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_remark", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_remark", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_fginved", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fginved", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_fginvself", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_fginvself", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_projno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_projno", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_costctr", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_costctr", System.Data.DataRowVersion.Current, null));
			this.sqlCmdInsAdr.Parameters.Add(new System.Data.SqlClient.SqlParameter("@adr_imseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "adr_imseq", System.Data.DataRowVersion.Current, null));
			this.calSelectAdDate.SelectionChanged += new System.EventHandler(this.calSelectAdDate_SelectionChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//初始化設定資料
		private void InitData()
		{
			this.calSelectAdDate.SelectedDate = DateTime.Today;
			this.lblAdDate.Text = this.calSelectAdDate.SelectedDate.ToString("yyyy/MM/dd",null);
			this.tbxAdAmt.Text = "0";
			this.tbxAltText.Text = "";
			this.tbxChgAmt.Text = "0";
			this.tbxContNo.Text = "999999";
			this.tbxDesAmt.Text = "0";
			this.tbxDraftType.Text = "1";
			this.tbxImpression.Text = "1";
			this.tbxInvAmt.Text = "0";
			this.tbxNavUrl.Text = "http://";
			this.tbxRemark.Text = "";
			this.tbxTxtAdCont.Text ="";
		}

		private int GetMaxSeq(string syscd, string contno, string adrdate)
		{
			int retValue = 0;
			this.sqlCmdGetSeq.Parameters["@adr_syscd"].Value = syscd;
			this.sqlCmdGetSeq.Parameters["@adr_contno"].Value = contno;
			this.sqlCmdGetSeq.Parameters["@adr_date"].Value = adrdate;
			this.sqlCmdGetSeq.Connection.Open();
			try
			{
				retValue = Convert.ToInt32(this.sqlCmdGetSeq.ExecuteScalar());
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				retValue = 0;
			}
			this.sqlCmdGetSeq.Connection.Close();
			return retValue;
		}

		private void InsertAdr()
		{
			DateTime AdDate = DateTime.ParseExact(lblAdDate.Text, "yyyy/MM/dd", null);

			string strTextAdCont;
			if (this.tbxTxtAdCont.Text == null || this.tbxTxtAdCont.Text == "")
			{
				strTextAdCont = "";
			}
			else
			{
				strTextAdCont = this.tbxTxtAdCont.Text;
			}

			this.sqlCmdInsAdr.Parameters["@adr_contno"].Value = this.tbxContNo.Text;
			this.sqlCmdInsAdr.Parameters["@adr_syscd"].Value = "C4";
			this.sqlCmdInsAdr.Parameters["@adr_seq"].Value = Convert.ToInt32((GetMaxSeq("C4", this.tbxContNo.Text, AdDate.ToString("yyyyMM") + "01")+1)).ToString();

			//version 2: by month
			this.sqlCmdInsAdr.Parameters["@adr_date"].Value = AdDate.ToString("yyyyMM") + "01";
			this.sqlCmdInsAdr.Parameters["@adr_adcate"].Value = this.ddlAdCate.SelectedItem.Value;
			this.sqlCmdInsAdr.Parameters["@adr_keyword"].Value = this.ddlKey.SelectedItem.Value;
			this.sqlCmdInsAdr.Parameters["@adr_alttext"].Value = this.tbxAltText.Text;

			string PostedFileName = "";
			if (this.fileAdImage!= null && this.fileAdImage.PostedFile != null)
			{
				PostedFileName = this.fileAdImage.PostedFile.FileName.Substring(fileAdImage.PostedFile.FileName.LastIndexOf("\\") + 1);
				this.sqlCmdInsAdr.Parameters["@adr_imgurl"].Value = "ADImages/" + PostedFileName;
			}
			else
			{
				this.sqlCmdInsAdr.Parameters["@adr_imgurl"].Value = "";
			}
			
			this.sqlCmdInsAdr.Parameters["@adr_drafttp"].Value = this.tbxDraftType.Text;
			this.sqlCmdInsAdr.Parameters["@adr_navurl"].Value = this.tbxNavUrl.Text;
			this.sqlCmdInsAdr.Parameters["@adr_impr"].Value = this.tbxImpression.Text;
			this.sqlCmdInsAdr.Parameters["@adr_fgfixad"].Value = this.ddlFgFixAd.SelectedItem.Value;
			this.sqlCmdInsAdr.Parameters["@adr_urlcate"].Value = "";
			this.sqlCmdInsAdr.Parameters["@adr_txtadcont"].Value = strTextAdCont;
			this.sqlCmdInsAdr.Parameters["@adr_txtadcontnm"].Value = "";
			this.sqlCmdInsAdr.Parameters["@adr_fggot"].Value = this.ddlFgGot.SelectedItem.Value;
			this.sqlCmdInsAdr.Parameters["@adr_adamt"].Value = this.tbxAdAmt.Text;
			this.sqlCmdInsAdr.Parameters["@adr_desamt"].Value = this.tbxDesAmt.Text;
			this.sqlCmdInsAdr.Parameters["@adr_chgamt"].Value = this.tbxChgAmt.Text;

			//not handled
			this.sqlCmdInsAdr.Parameters["@adr_invamt"].Value = "9";
			this.sqlCmdInsAdr.Parameters["@adr_remark"].Value = this.tbxRemark.Text;
			this.sqlCmdInsAdr.Parameters["@adr_fginved"].Value = "9";
			this.sqlCmdInsAdr.Parameters["@adr_fginvself"].Value = "9";
			this.sqlCmdInsAdr.Parameters["@adr_projno"].Value = "9";
			this.sqlCmdInsAdr.Parameters["@adr_costctr"].Value = "9";
			this.sqlCmdInsAdr.Parameters["@adr_imseq"].Value = "9";


			this.sqlCnnITRINTS8.Open();
			System.Data.SqlClient.SqlTransaction sqlTran = this.sqlCnnITRINTS8.BeginTransaction();
			this.sqlCmdInsAdr.Transaction = sqlTran;

			//用Transaction做合約儲存跟檔案儲存
			try
			{
				this.sqlCmdInsAdr.ExecuteNonQuery();
				SaveImage();
				sqlTran.Commit();
				Response.Write("資料庫儲存成功");
			}
			catch(System.IO.IOException ioex)
			{
				sqlTran.Rollback();
				Response.Write("存檔錯誤"+ioex.Message);
			}
			catch(System.Data.SqlClient.SqlException sqlex)
			{
				sqlTran.Rollback();
				Response.Write("資料庫儲存錯誤: "+sqlex.Message);
			}
			this.sqlCnnITRINTS8.Close();
		}

		private void SaveImage()
		{
			//儲存圖檔

			string PostedFileName = "";
			if (this.fileAdImage == null)
			{
				Response.Write("fileAdImage is null");
				return;
			}
			if (this.fileAdImage.PostedFile == null)
			{
				Response.Write("PostedFile is null");
				return;
			}
			PostedFileName = this.fileAdImage.PostedFile.FileName.Substring(fileAdImage.PostedFile.FileName.LastIndexOf("\\") + 1);
			Response.Write("#file: " + PostedFileName+"#");

			if (this.fileAdImage.PostedFile.ContentLength<=0)
			{
				Response.Write("檔案大小為零。");
				return;
			}
			
			if (System.IO.File.Exists(Server.MapPath("/") + "/ADImages/"+ PostedFileName))
			{
				Response.Write("已經存在，請重新更改檔名再選擇。");
				return;
			}

			fileAdImage.PostedFile.SaveAs(Server.MapPath("/") + "/ADImages/"+ PostedFileName);
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid)
			{
				InsertAdr();
			}
		}

		private void calSelectAdDate_SelectionChanged(object sender, System.EventArgs e)
		{
			this.lblAdDate.Text = this.calSelectAdDate.SelectedDate.ToString("yyyy/MM/dd", null);
		}
	}
}
