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
	/// Summary description for IABQueryInv.
	/// </summary>
	public class IABQueryInv : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Panel pnlQuery;
		protected System.Web.UI.WebControls.DropDownList ddlAdCate;
		protected System.Web.UI.WebControls.TextBox tbxAdMonth;
		protected System.Web.UI.WebControls.DropDownList ddlSort;
		protected System.Web.UI.WebControls.Button BtnQuery1;
		protected System.Web.UI.WebControls.Panel pnlStep1;
		protected System.Web.UI.WebControls.Label lblInfo1;
		protected System.Web.UI.WebControls.RequiredFieldValidator RequiredFieldValidator1;
		protected System.Web.UI.WebControls.RegularExpressionValidator RegularExpressionValidator1;
		protected System.Data.SqlClient.SqlConnection sqlCnnMRLPUB;
		protected System.Web.UI.WebControls.Button btnStep1SelAll;
		protected System.Web.UI.WebControls.Button btnStep1SelNone;
		protected System.Web.UI.WebControls.Button btnStep1Go;
		protected System.Web.UI.WebControls.Panel pnlStep2;
		protected System.Web.UI.WebControls.Label lblInfo2;
		protected System.Web.UI.WebControls.Button btnGoInv;
		protected System.Web.UI.WebControls.Button btnGoStep1;
		protected System.Data.SqlClient.SqlCommand sqlCmdUpdateAdrd;
		protected System.Web.UI.WebControls.Label lblTotAmt;
		protected System.Data.SqlClient.SqlCommand sqlCmdGetMaxIabNo;
		protected System.Data.SqlClient.SqlCommand sqlCmdInsIab;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaAdrTmp;
		protected System.Data.SqlClient.SqlCommand sqlCmdExecSp;
		protected System.Data.SqlClient.SqlCommand sqlCmdTagAdrd;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaInvBatch;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCmdSpInvBatch;
		protected System.Web.UI.WebControls.DataGrid dgdStep2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDaTagAdrd;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlCmdUnTagAdrd;
		protected System.Web.UI.WebControls.DataGrid dgdStep1;
	
		public IABQueryInv()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				this.pnlStep1.Visible = false;
				this.pnlStep2.Visible = false;
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

			this.sqlDaInvBatch = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCnnMRLPUB = new System.Data.SqlClient.SqlConnection();
			this.sqlDaTagAdrd = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdSpInvBatch = new System.Data.SqlClient.SqlCommand();
			this.sqlDaAdrTmp = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdInsIab = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdUpdateAdrd = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdTagAdrd = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdGetMaxIabNo = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdExecSp = new System.Data.SqlClient.SqlCommand();
			this.sqlCmdUnTagAdrd = new System.Data.SqlClient.SqlCommand();
			this.BtnQuery1.Click += new System.EventHandler(this.BtnQuery1_Click);
			this.btnStep1SelAll.Click += new System.EventHandler(this.btnStep1SelAll_Click);
			this.btnStep1SelNone.Click += new System.EventHandler(this.btnStep1SelNone_Click);
			this.btnStep1Go.Click += new System.EventHandler(this.btnStep1Go_Click);
			this.btnGoInv.Click += new System.EventHandler(this.btnGoInv_Click);
			this.btnGoStep1.Click += new System.EventHandler(this.btnGoStep1_Click);
			// 
			// sqlDaInvBatch
			// 
			this.sqlDaInvBatch.SelectCommand = this.sqlSelectCommand1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT cont_syscd, cont_contno, cont_custno, cont_mfrno, adr_sdate, adr_edate, ad" +
				"r_adcate, adr_keyword, adr_impr, suminvamt, mfr_inm, im_nm, im_jobti, im_invcd, " +
				"im_taxtp, im_fgitri, cont_empno, adr_seq, adr_imseq, adr_alttext FROM dbo.wk_c4_" +
				"invbatch";
			this.sqlSelectCommand1.Connection = this.sqlCnnMRLPUB;
			// 
			// sqlCnnMRLPUB
			// 
			this.sqlCnnMRLPUB.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlDaTagAdrd
			// 
			this.sqlDaTagAdrd.SelectCommand = this.sqlSelectCommand3;
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT dbo.c4_cont.cont_syscd, dbo.c4_cont.cont_contno, dbo.c4_cont.cont_custno, dbo.c4_cont.cont_mfrno, dbo.c4_adr.adr_sdate, dbo.c4_adr.adr_edate, dbo.c4_adr.adr_adcate, dbo.c4_adr.adr_keyword, dbo.c4_adr.adr_impr, DRIVERTBL.suminvamt, dbo.mfr.mfr_inm, dbo.invmfr.im_nm, dbo.invmfr.im_jbti, dbo.invmfr.im_invcd, dbo.invmfr.im_taxtp, dbo.invmfr.im_fgitri, dbo.c4_cont.cont_empno, dbo.c4_adr.adr_seq, dbo.c4_adr.adr_imseq, dbo.c4_adr.adr_alttext, dbo.c4_adr.adr_contno, dbo.c4_adr.adr_syscd, dbo.invmfr.im_contno, dbo.invmfr.im_imseq, dbo.invmfr.im_syscd, dbo.mfr.mfr_mfrno FROM dbo.c4_adr INNER JOIN (SELECT DISTINCT adrd_syscd , adrd_contno , adrd_adrseq , suminvamt = SUM(adrd_adramt) + SUM(adrd_chgamt) + SUM(adrd_desamt) FROM c4_adrd WHERE adrd_fginved = 't' GROUP BY adrd_syscd , adrd_contno , adrd_adrseq) DRIVERTBL ON DRIVERTBL.adrd_syscd = dbo.c4_adr.adr_syscd AND DRIVERTBL.adrd_contno = dbo.c4_adr.adr_contno AND DRIVERTBL.adrd_adrseq = dbo.c4_adr.adr_seq INNER JOIN dbo.c4_cont ON dbo.c4_adr.adr_syscd = dbo.c4_cont.cont_syscd AND dbo.c4_adr.adr_contno = dbo.c4_cont.cont_contno INNER JOIN dbo.invmfr ON dbo.c4_adr.adr_syscd = dbo.invmfr.im_syscd AND dbo.c4_adr.adr_contno = dbo.invmfr.im_contno AND dbo.c4_adr.adr_imseq = dbo.invmfr.im_imseq INNER JOIN dbo.mfr ON dbo.invmfr.im_mfrno = dbo.mfr.mfr_mfrno WHERE (dbo.c4_cont.cont_conttp = '01') AND (dbo.c4_cont.cont_fgclosed <> '1') AND (dbo.c4_cont.cont_fgtemp <> '1') AND (dbo.c4_cont.cont_fgcancel <> '1')";
			this.sqlSelectCommand3.Connection = this.sqlCnnMRLPUB;
			// 
			// sqlCmdSpInvBatch
			// 
			this.sqlCmdSpInvBatch.CommandText = "sp_c4_invbatch";
			this.sqlCmdSpInvBatch.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdSpInvBatch.Connection = this.sqlCnnMRLPUB;
			this.sqlCmdSpInvBatch.Parameters.Add(new System.Data.SqlClient.SqlParameter("@admonth", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDaAdrTmp
			// 
			this.sqlDaAdrTmp.SelectCommand = this.sqlSelectCommand2;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = @"SELECT dbo.c4_adr.adr_adrid, dbo.c4_adr.adr_syscd, dbo.c4_adr.adr_contno, dbo.c4_adr.adr_seq, dbo.c4_adr.adr_imseq, dbo.c4_adr.adr_sdate, dbo.c4_adr.adr_edate, dbo.c4_adr.adr_invamt, dbo.c4_adr.adr_adcate, dbo.c4_adr.adr_keyword, dbo.c4_adr.adr_alttext, dbo.c4_adr.adr_imgurl, dbo.c4_adr.adr_drafttp, dbo.c4_adr.adr_navurl, dbo.c4_adr.adr_urltp, dbo.c4_adr.adr_impr, dbo.c4_adr.adr_adamt, dbo.c4_adr.adr_desamt, dbo.c4_adr.adr_chgamt, dbo.c4_adr.adr_remark, dbo.c4_adr.adr_projno, dbo.c4_adr.adr_costctr, dbo.c4_adr.adr_fgfixad, dbo.c4_adr.adr_fggot, dbo.c4_adr.adr_fginvself, dbo.c4_adr.adr_fgact, DRIVERTBL.adrd_syscd, DRIVERTBL.adrd_contno, DRIVERTBL.adrd_adrseq FROM dbo.c4_adr INNER JOIN (SELECT DISTINCT adrd_syscd , adrd_contno , adrd_adrseq FROM c4_adrd WHERE adrd_fginved = 't') DRIVERTBL ON dbo.c4_adr.adr_syscd = DRIVERTBL.adrd_syscd AND dbo.c4_adr.adr_contno = DRIVERTBL.adrd_contno AND dbo.c4_adr.adr_seq = DRIVERTBL.adrd_adrseq WHERE (dbo.c4_adr.adr_imseq <> '')";
			this.sqlSelectCommand2.Connection = this.sqlCnnMRLPUB;
			// 
			// sqlCmdInsIab
			// 
			this.sqlCmdInsIab.Connection = this.sqlCnnMRLPUB;
			// 
			// sqlCmdUpdateAdrd
			// 
			this.sqlCmdUpdateAdrd.Connection = this.sqlCnnMRLPUB;
			// 
			// sqlCmdTagAdrd
			// 
			this.sqlCmdTagAdrd.Connection = this.sqlCnnMRLPUB;
			// 
			// sqlCmdGetMaxIabNo
			// 
			this.sqlCmdGetMaxIabNo.Connection = this.sqlCnnMRLPUB;
			// 
			// sqlCmdExecSp
			// 
			this.sqlCmdExecSp.CommandText = "sp_c4_add_ia";
			this.sqlCmdExecSp.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCmdExecSp.Connection = this.sqlCnnMRLPUB;
			//this.sqlCmdExecSp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.BigInt, 0, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdExecSp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdExecSp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdExecSp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@imseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdExecSp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iabdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCmdExecSp.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iabseq", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCmdUnTagAdrd
			// 
			this.sqlCmdUnTagAdrd.CommandText = "UPDATE dbo.c4_adrd SET adrd_fginved = \'0\' WHERE (adrd_fginved = \'t\')";
			this.sqlCmdUnTagAdrd.Connection = this.sqlCnnMRLPUB;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//放一個Alert在client script
		private void AlertMsg(string strMsg)
		{
			if (strMsg != null && strMsg != "")
			{
				LiteralControl litAlert = new LiteralControl();
				litAlert.Text = "<script language=javascript>alert(\"" + strMsg +"\");</script>";
				Page.Controls.Add(litAlert);
			}
		}

		private void BtnQuery1_Click(object sender, System.EventArgs e)
		{
			if (!Page.IsValid)
			{
				return;
			}

			this.pnlStep1.Visible = true;
			this.pnlStep2.Visible = false;

			Bind_dgdStep1();
		}

		private void Bind_dgdStep1()
		{
			string AdMonth = DateTime.ParseExact(this.tbxAdMonth.Text.Trim(), "yyyy/MM", null).ToString("yyyyMM");
			
			//產生當月發票資料
			this.sqlCmdSpInvBatch.Parameters["@admonth"].Value = AdMonth;
			this.sqlCmdSpInvBatch.Connection.Open();
			try
			{
				this.sqlCmdSpInvBatch.ExecuteNonQuery();
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("產生當月廣告發票資料失敗，請通知聯絡人");
				return;
			}
			this.sqlCmdSpInvBatch.Connection.Close();

			//把資料放到DataGrid上面去
			DataSet ds = new DataSet();
			this.sqlDaInvBatch.Fill(ds, "INVBATCH");
			DataView dv = ds.Tables["INVBATCH"].DefaultView;

			if (dv.Count>0)
			{
				if (this.ddlSort.SelectedItem.Value == "0")
				{
					dv.Sort = "cont_contno, adr_seq";
				}
				else
				{
					dv.Sort = "cont_empno";
				}				

				this.lblInfo1.Text = "請挑選合約廣告資料";
				this.btnStep1SelAll.Visible = true;
				this.btnStep1SelNone.Visible = true;
				this.dgdStep1.Visible = true;
				this.dgdStep1.DataSource = dv;
				this.dgdStep1.DataBind();
			}
			else
			{
				this.lblInfo1.Text = "無可挑選的合約廣告資料";
				this.btnStep1SelAll.Visible = false;
				this.btnStep1SelNone.Visible = false;
				this.dgdStep1.Visible = false;
			}
		}

		//步驟一全選
		private void btnStep1SelAll_Click(object sender, System.EventArgs e)
		{
			for(int i=0; i<dgdStep1.Items.Count; i++)
			{
				((CheckBox)dgdStep1.Items[i].Cells[0].FindControl("cbxSelContAdr")).Checked = true;
			}
		}

		//步驟一清選
		private void btnStep1SelNone_Click(object sender, System.EventArgs e)
		{
			for(int i=0; i<dgdStep1.Items.Count; i++)
			{
				((CheckBox)dgdStep1.Items[i].Cells[0].FindControl("cbxSelContAdr")).Checked = false;
			}
		}

		//將發票資料跟統計列出
		private void btnStep1Go_Click(object sender, System.EventArgs e)
		{
			string AdMonth = DateTime.ParseExact(this.tbxAdMonth.Text.Trim(), "yyyy/MM", null).ToString("yyyyMM");

			string strFilter = "";
			int adrcount = 0;
			string ContNo = "";
			string AdrSeq = "";
			for(int i=0; i<dgdStep1.Items.Count; i++)
			{
				if (((CheckBox)dgdStep1.Items[i].Cells[0].FindControl("cbxSelContAdr")).Checked)
				{
					if (adrcount>0)
					{
						strFilter += " OR ";
					}

					ContNo = this.dgdStep1.Items[i].Cells[1].Text.Trim();
					AdrSeq = this.dgdStep1.Items[i].Cells[5].Text.Trim();

					strFilter += "(adrd_contno='" + ContNo + "' AND adrd_adrseq='" + AdrSeq + "' AND SUBSTRING(adrd_addate,1,6)='" + AdMonth + "')";
					adrcount++;
				}
			}		

			this.pnlStep1.Visible = false;
			this.pnlStep2.Visible = true;

			//Response.Write(strFilter+"<br>");
			UpdateAdrd(strFilter);
		}

		private void UpdateAdrd(string strFilter)
		{
			string cmdtxt = "UPDATE c4_adrd SET adrd_fginved='t' WHERE " + strFilter;
			this.sqlCmdTagAdrd.CommandText = cmdtxt;

			this.sqlCmdTagAdrd.Connection.Open();
			System.Data.SqlClient.SqlTransaction myTrans = this.sqlCmdTagAdrd.Connection.BeginTransaction();
			this.sqlCmdTagAdrd.Transaction = myTrans;
			try
			{
				this.sqlCmdTagAdrd.ExecuteNonQuery();
				myTrans.Commit();
				AlertMsg("標記發票成功，請繼續");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				myTrans.Rollback();
				AlertMsg("標記批次發票失敗，請通知聯絡人");
			}
			this.sqlCmdTagAdrd.Connection.Close();
			//Response.Write(cmdtxt + "<br>");

			Bind_dgdStep2();
		}

		private void Bind_dgdStep2()
		{
			DataSet tds = new DataSet();
			this.sqlDaTagAdrd.Fill(tds, "TAGADRD");
			DataView tdv = tds.Tables["TAGADRD"].DefaultView;
			if (!(tdv.Count>0))
			{
				AlertMsg("無法列示已標記欲開立發票之廣告，請通知聯絡人");
				return;
			}
			
			this.dgdStep2.DataSource = tdv;
			this.dgdStep2.DataBind();

			//發票金額總計

			int totinvamt = 0;
			for(int i=0; i<tdv.Count; i++)
			{
				totinvamt += Convert.ToInt32(tdv[i]["suminvamt"].ToString().Trim());
			}
			
			this.lblTotAmt.Text = this.lblTotAmt.Text = "以上總計發票金額為：" + totinvamt.ToString("n") + " 元";

		}


		//未完成
		//未確認
		private void btnGoInv_Click(object sender, System.EventArgs e)
		{
			//1.產生一個iabseq跟iabdate
			//1.1取得目前最大的iabseq
			//select isnull(max(iab_iabseq), 0) from iab where iab_syscd='C4' AND iab_iabdate='200208'
			string iabdate = DateTime.ParseExact(this.tbxAdMonth.Text.Trim(), "yyyy/MM", null).ToString("yyyyMM");
			int MaxIabNo = 0;
			this.sqlCmdGetMaxIabNo.CommandText = "SELECT ISNULL(MAX(iab_iabseq), 0) FROM iab WHERE iab_syscd='C4' AND iab_iabdate='" + iabdate + "'";
			this.sqlCmdGetMaxIabNo.Connection.Open();
			try
			{
				MaxIabNo = Int32.Parse(this.sqlCmdGetMaxIabNo.ExecuteScalar().ToString());
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("取回發票批次編號錯誤，請通知聯絡人");
				return;
			}
			this.sqlCmdGetMaxIabNo.Connection.Close();

			int NewIabNo = MaxIabNo+1;//使用的時候要用六碼

			//1.2新增iab
			//insert into iab (iab_syscd, iab_iabdate, iab_iabseq,iab_createdate,iab_createmen)
			//values ('C4', @iab_iabdate, @newiabseq, @t_today ,@whoami)
			string tToday = DateTime.Today.ToString("yyyyMMdd");
			string whoami = User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1);
			this.sqlCmdInsIab.CommandText = "INSERT INTO iab (iab_syscd, iab_iabdate, iab_iabseq,iab_createdate,iab_createmen) "+
											"VALUES ('C4', '" + iabdate + "', '" + NewIabNo.ToString("d6") + "', '" + tToday + "' ,'" + whoami + "')";
			this.sqlCmdInsIab.Connection.Open();
			try
			{
				this.sqlCmdInsIab.ExecuteNonQuery();
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("新增發票批次錯誤，請通知聯絡人");
				return;
			}
			this.sqlCmdInsIab.Connection.Close();

			//2.把fginved為t的資料找出
			//select * from c4_adr inner join 
			//(select distinct adrd_syscd, adrd_contno, adrd_adrseq from c4_adrd where adrd_fginved='t') DRIVERTBL
			//on adr_syscd=adrd_syscd AND
			//adr_contno=adrd_contno AND
			//adr_seq= adrd_adrseq

			DataSet tds = new DataSet();
			this.sqlDaAdrTmp.Fill(tds, "TMPADR");
			DataView tdv = tds.Tables["TMPADR"].DefaultView;
			if (!(tdv.Count>0))
			{
				AlertMsg("找不到已標記欲開立發票之廣告，請通知聯絡人");
				return;
			}

			string tmpImSeq = "";
			string tmpContNo = "";

			this.sqlCmdExecSp.Connection.Open();
			System.Data.SqlClient.SqlTransaction myTrans = this.sqlCmdExecSp.Connection.BeginTransaction();
			this.sqlCmdExecSp.Transaction = myTrans;
			try
			{
				for (int i=0; i<tdv.Count; i++)
				{
					//3.把同一個imseq的變成v
					//for each data row in datatable
					//get imseq
					tmpImSeq = tdv[i]["adr_imseq"].ToString().Trim();
					tmpContNo = tdv[i]["adr_contno"].ToString().Trim();				
					//在SP裡面做掉
//					update c4_adrd set adrd_fginved='v' where adrd_fginved='t' 

					//4.然後呼叫stored procedure，產生一張發票
					//  一個ia，一或多筆iad
					//exec sp_c4_add_ia with parameters
					this.sqlCmdExecSp.Parameters["@syscd"].Value = "C4";
					this.sqlCmdExecSp.Parameters["@contno"].Value = tmpContNo;
					this.sqlCmdExecSp.Parameters["@imseq"].Value = tmpImSeq;
					this.sqlCmdExecSp.Parameters["@iabdate"].Value = iabdate;
					this.sqlCmdExecSp.Parameters["@iabseq"].Value = NewIabNo.ToString("d6");

					this.sqlCmdExecSp.ExecuteNonQuery();
					//5.loop回3
				}

				myTrans.Commit();
				AlertMsg("大批發票開立成功");
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				myTrans.Rollback();
				AlertMsg("大批發票開立失敗，請通知聯絡人"+ex.Message);
			}
			this.sqlCmdExecSp.Connection.Close();
		}

		private void btnGoStep1_Click(object sender, System.EventArgs e)
		{
			this.pnlStep2.Visible = false;

			//回復tag狀態
			this.sqlCmdUnTagAdrd.Connection.Open();
			try
			{
				this.sqlCmdUnTagAdrd.ExecuteNonQuery();
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				AlertMsg("標記狀態回復錯誤，請通知聯絡人");
				return;
			}
			this.sqlCmdUnTagAdrd.Connection.Close();

			this.pnlStep1.Visible = true;
			Bind_dgdStep1();
		}

	}
}
