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
	/// Summary description for ContNew.
	/// </summary>
	public class ContNew : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblRespData;
		protected System.Web.UI.WebControls.TextBox tbxHidMfrNo;
		protected System.Web.UI.WebControls.TextBox tbxHidCustNo;
		protected System.Web.UI.WebControls.Label lblMfrNm;
		protected System.Web.UI.WebControls.Label lblMfrTelFax;
		protected System.Web.UI.WebControls.Label lblCustNm;
		protected System.Web.UI.WebControls.TextBox tbxSignDate;
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.DropDownList ddlContTp;
		protected System.Web.UI.WebControls.TextBox tbxSDate;
		protected System.Web.UI.WebControls.TextBox tbxEDate;
		protected System.Web.UI.WebControls.Label lblDayCount;
		protected System.Web.UI.WebControls.DropDownList ddlEmpData;
		protected System.Web.UI.WebControls.RadioButtonList rblPayOnce;
		protected System.Web.UI.WebControls.TextBox tbxRemark;
		protected System.Web.UI.WebControls.TextBox tbxPubTm;
		protected System.Web.UI.WebControls.Label lblUnPubTm;
		protected System.Web.UI.WebControls.TextBox tbxTotAmt;
		protected System.Web.UI.WebControls.TextBox tbxFreeTm;
		protected System.Web.UI.WebControls.TextBox tbxDisc;
		protected System.Web.UI.WebControls.TextBox tbxTotImgTm;
		protected System.Web.UI.WebControls.Label lblUnImgTm;
		protected System.Web.UI.WebControls.TextBox tbxTotUrlTm;
		protected System.Web.UI.WebControls.Label lblUnUrlTm;
		protected System.Web.UI.WebControls.TextBox tbxAuNm;
		protected System.Web.UI.WebControls.TextBox tbxAuTel;
		protected System.Web.UI.WebControls.TextBox tbxAuFax;
		protected System.Web.UI.WebControls.TextBox tbxAuCell;
		protected System.Web.UI.WebControls.TextBox tbxAuEmail;
		protected System.Web.UI.WebControls.TextBox tbxOldContNo;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Button btnNoSave;
		protected System.Web.UI.WebControls.Panel pnlContBody;
		protected System.Web.UI.WebControls.Button btnHome;
		protected System.Web.UI.WebControls.Panel pnlBack;
		protected System.Web.UI.WebControls.TextBox tbxCCont;
		protected System.Web.UI.WebControls.TextBox tbxCsDate;
		protected System.Web.UI.WebControls.RegularExpressionValidator revCsDate;
		protected System.Web.UI.WebControls.TextBox tbxPdCont;
		protected System.Web.UI.WebControls.DataGrid dgdAtpMatp1;
		protected System.Web.UI.WebControls.DataGrid dgdAtpMatp2;
		protected System.Web.UI.WebControls.DataGrid dgdNewOr;
		protected System.Web.UI.WebControls.DataGrid dgdNewFreeBk;
		protected System.Web.UI.WebControls.DataGrid dgdNewInvMfr;
		protected System.Web.UI.WebControls.Button btnCount;
		protected System.Web.UI.WebControls.Label lblCustNo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				pnlBack.Visible = false;
				pnlContBody.Visible = true;		
		
				Bind_ddlEmpData();
				if (Request.QueryString["old_contno"] == null || Request.QueryString["old_contno"] == "")
				{
					InitNewCont();
				}
				else
				{
					LoadHistContData();
				}		
			}
			
			//加入script的部分
			if (!IsClientScriptBlockRegistered("JSCALENDAR"))
			{
				System.IO.TextReader tr = System.IO.File.OpenText(Server.MapPath(".") + "\\ClientScripts\\jsCalendar.js");
				string script = tr.ReadToEnd();
				RegisterClientScriptBlock("JSCALENDAR", script);
			}

			if (!IsClientScriptBlockRegistered("JSCONTNEW"))
			{
				System.IO.TextReader tr = System.IO.File.OpenText(Server.MapPath(".") + "\\ClientScripts\\jsContNew.js");
				string script = tr.ReadToEnd();
				RegisterClientScriptBlock("JSCONTNEW", script);
			}
			ShowAtpMatp();
			ShowFreeBook();
			ShowInvMfr();
//			btnNoSave.Attributes["OnClick"] = "JavaScript:confirm('確認不儲存此合約(立即清除資料)');";
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
			this.tbxEDate.TextChanged += new System.EventHandler(this.tbxEDate_TextChanged);
			this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnNoSave.Click += new System.EventHandler(this.btnNoSave_Click);
			this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region 事先新增合約，設定合約屬性為暫存
		private string PreAddNewCont()
		{		
			string cont_oldcontno =" ";
			if (Request.QueryString["old_contno"] == null || Request.QueryString["old_contno"] == "")
			{
				jsAlertMsg("PREADDERROR", "注意：本合約無歷史合約參考資料...");
			}
			else
			{
				cont_oldcontno = Request.QueryString["old_contno"];
			}

			string cont_empno = this.WhoAmI.EmpNo;

			Contracts cont = new Contracts();
			string new_contno = cont.AddContract(cont_empno, cont_oldcontno);

			return new_contno;
		}
		#endregion

		#region 連結員工資料
		private void Bind_ddlEmpData()
		{
			SqlConnection myConnection = new SqlConnection(D4Settings.ConnectionString);
			string strCmd = "SELECT RTRIM(srspn_empno) AS srspn_empno, srspn_cname, srspn_tel, srspn_atype, srspn_orgcd, srspn_deptcd, srspn_date, srspn_pwd FROM srspn where srspn_atype <> 'A' and srspn_atype <> 'E' and srspn_atype <> 'F'";

			SqlDataAdapter myCommand = new SqlDataAdapter(strCmd, myConnection);
			
			DataSet ds = new DataSet();

			myCommand.Fill(ds);

			this.ddlEmpData.DataTextField = "srspn_cname";
			this.ddlEmpData.DataValueField = "srspn_empno";
			this.ddlEmpData.DataSource = ds;
			this.ddlEmpData.DataBind();

			ddlEmpData.SelectedIndex = -1;
			if (ddlEmpData.Items.FindByValue(WhoAmI.EmpNo) != null)
				ddlEmpData.Items.FindByValue(WhoAmI.EmpNo).Selected = true;
			else
				ddlEmpData.SelectedIndex = 0;
		}
		#endregion

		#region 初始化無參考的全新合約
		private void InitNewCont()
		{
			string cust_custno;
			if (Request.QueryString["CustNo"] == null || Request.QueryString["CustNo"] == "")
			{
				throw new Exception("新增全新合約時，客戶編號不可為空值");
			}
			else
			{
				cust_custno = Request.QueryString["CustNo"];
			}

			string new_contno = PreAddNewCont(); //去資料庫新增暫存合約，傳回新合約的合約編號

			Customers cust = new Customers();
			SqlDataReader dr = cust.GetMfrCustByCustNo(cust_custno);

			if (dr.Read())
			{
				//廠商及客戶資料
				lblCustNm.Text = dr["cust_nm"].ToString().Trim();
				lblCustNo.Text = cust_custno;
				tbxHidCustNo.Text = cust_custno;
				lblMfrNm.Text = dr["mfr_inm"].ToString().Trim();
				lblMfrNo.Text = dr["cust_mfrno"].ToString().Trim();
				tbxHidMfrNo.Text = dr["cust_mfrno"].ToString().Trim();
				lblMfrTelFax.Text = dr["mfr_tel"].ToString() + "(Fax：" + dr["mfr_fax"].ToString().Trim() + ")";
				lblRespData.Text = dr["mfr_respnm"].ToString() + "(" + dr["mfr_respjbti"].ToString().Trim() + ")";

				//合約書基本資料
				tbxSignDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
				ddlContTp.SelectedIndex = 0;
				tbxSDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
				tbxEDate.Text = "";
				tbxRemark.Text = "";
				lblContNo.Text = new_contno;
				ddlContTp.SelectedIndex = 0;
				rblPayOnce.SelectedIndex = 1;

				//合約書細節
				tbxPubTm.Text = "0";
				tbxFreeTm.Text = "0";
				tbxTotImgTm.Text = "0";
				tbxTotUrlTm.Text = "0";
				tbxTotAmt.Text = "0";
				tbxDisc.Text = "1";

				//廣告聯絡人資料
				tbxAuNm.Text = "";
				tbxAuEmail.Text = "";
				tbxAuTel.Text = "";
				tbxAuCell.Text = "";
				tbxAuFax.Text = "";

				//廣告推廣內文、期限、產品設備內文、材料特性、應用產業等相關資料

				//發票廠商收件人資料

				//雜誌收件人及贈書資料
			}
			else
			{
				jsAlertMsg("CUSTMFRNOTFOUND", "找不到客戶及廠商資料，請通知聯絡人");
			}
			dr.Close();
		}
		#endregion

		#region 取回歷史合約資料
		private void LoadHistContData()
		{
			string old_contno;
			string new_contno = PreAddNewCont(); //去資料庫新增暫存合約，傳回新合約的合約編號

			if (Request.QueryString["old_contno"] == null || Request.QueryString["old_contno"] == "")
			{
				throw new Exception("歷史合約編號不可為空值");
			}
			else
			{
				old_contno = Request.QueryString["old_contno"];
				tbxOldContNo.Text = old_contno;
			}

			Contracts cont = new Contracts();
			
			SqlDataReader dr = cont.GetSingleContractByContNo(old_contno);

			if (dr.Read())
			{
				//廠商及客戶資料
				lblCustNm.Text = dr["cust_nm"].ToString().Trim();
				lblCustNo.Text = dr["cont_custno"].ToString().Trim();
				tbxHidCustNo.Text = dr["cont_custno"].ToString().Trim();
				lblMfrNm.Text = dr["mfr_inm"].ToString().Trim();
				lblMfrNo.Text = dr["cont_mfrno"].ToString().Trim();
				tbxHidMfrNo.Text = dr["cont_mfrno"].ToString().Trim();
				lblMfrTelFax.Text = dr["mfr_tel"].ToString() + "(Fax：" + dr["mfr_fax"].ToString().Trim() + ")";
				lblRespData.Text = dr["mfr_respnm"].ToString() + "(" + dr["mfr_respjbti"].ToString().Trim() + ")";

				//合約書基本資料
				tbxSignDate.Text = DateTime.Today.ToString("yyyy/MM/dd");

				ddlContTp.SelectedIndex = -1;
				if (ddlContTp.Items.FindByValue(dr["cont_conttp"].ToString()) != null)
				{
					ddlContTp.Items.FindByValue(dr["cont_conttp"].ToString()).Selected = true;
				}
				else
				{
					ddlContTp.SelectedIndex = 0;
				}

				tbxSDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
				tbxEDate.Text = "";
				tbxRemark.Text = dr["cont_remark"].ToString().Trim();
				lblContNo.Text = new_contno;

				ddlContTp.SelectedIndex = -1;
				if (ddlEmpData.Items.FindByValue(this.WhoAmI.EmpNo) != null)
				{
					ddlEmpData.Items.FindByValue(this.WhoAmI.EmpNo).Selected = true;
				}
				else
				{
					ddlContTp.SelectedIndex = 0;
				}

				rblPayOnce.SelectedIndex = 0;

				//合約書細節
				tbxPubTm.Text = "0";
				tbxFreeTm.Text = "0";
				tbxTotImgTm.Text = "0";
				tbxTotUrlTm.Text = "0";
				tbxTotAmt.Text = "0";
				tbxDisc.Text = "1";

				//廣告聯絡人資料
				tbxAuNm.Text = dr["cont_aunm"].ToString().Trim();
				tbxAuEmail.Text = dr["cont_auemail"].ToString().Trim();
				tbxAuTel.Text = dr["cont_autel"].ToString().Trim();
				tbxAuCell.Text = dr["cont_aucell"].ToString().Trim();
				tbxAuFax.Text = dr["cont_aufax"].ToString().Trim();

				//廣告推廣內文、期限、產品設備內文、材料特性、應用產業等相關資料

				//發票廠商收件人資料

				//雜誌收件人及贈書資料
			}
			dr.Close();
		}
		#endregion

		#region 取得郵寄類別名稱
		protected object GetMtpNm(object mtpcd)
		{
			string strReturn = "";
			if(Session["MTP"]==null)
			{
				Mtps mtps = new Mtps();
				DataSet ds = mtps.GetMtps();
				DataView dv = ds.Tables[0].DefaultView;
				Session.Add("MTP", dv);
			}
			DataView mtpdv = (DataView)Session["MTP"];
			mtpdv.RowFilter = "mtp_mtpcd='" + mtpcd.ToString() + "'";
			if (mtpdv.Count>0)
			{
				strReturn = mtpdv[0]["ddl_text"].ToString().Trim();
			}
			mtpdv.RowFilter = "";

			return strReturn;
		}
		#endregion

		#region 連結收件人及贈書資料--目前不使用
//		private void Bind_dgdFreeBk(string contno)
//		{
//			FreeBooks fbks = new FreeBooks();
//			DataSet ds = fbks.GetFbkOrByContNo(contno);
//			DataView dv = ds.Tables[0].DefaultView;
//			this.dgdFreeBk.DataSource = dv;
//			this.dgdFreeBk.DataBind();
//
//			if (dv.Count>0)
//			{
//				this.dgdFreeBk.Visible = true;
//			}
//			else
//			{
//				this.dgdFreeBk.Visible = false;
//			}
//		}
		#endregion

		#region 重新整理雜誌收件人及贈書資料--停用
//		private void imbRefFreeBk_Click(object sender, System.Web.UI.ImageClickEventArgs e)
//		{
//			Bind_dgdFreeBk(lblContNo.Text.Trim());
//		}
		#endregion

		#region 儲存合約，在資料庫中更新資料並改變fgtemp
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			string cont_contno = lblContNo.Text.Trim();
			string cont_conttp= ddlContTp.SelectedItem.Value;

			//日期部分
			DateTime signdate;
			DateTime sdate;
			DateTime edate;

			try
			{
				signdate = DateTime.ParseExact(tbxSignDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("INVALIDSIGNDATE", "合約簽約日期錯誤，請更正");
				return;
			}

			try
			{
				sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("INVALIDSDATE", "合約起始日期錯誤，請更正");
				return;
			}

			try
			{
				edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("INVALIDEDATE", "合約結束日期錯誤，請更正");
				return;
			}

			if (sdate>edate)
			{
				jsAlertMsg("INVALIDPERIOD", "起始日期不可大於結束日期，請更正");
				return;
			}

			string cont_signdate = signdate.ToString("yyyyMMdd");
			string cont_sdate = sdate.ToString("yyyyMMdd");
			string cont_edate = edate.ToString("yyyyMMdd");

			string cont_empno = ddlEmpData.SelectedItem.Value.Trim();
			string cont_mfrno = tbxHidMfrNo.Text.Trim();
			string cont_custno = tbxHidCustNo.Text.Trim();
			string cont_aunm = tbxAuNm.Text.Trim();
			string cont_autel = tbxAuTel.Text.Trim();
			string cont_aufax = tbxAuFax.Text.Trim();
			string cont_aucell = tbxAuCell.Text.Trim();
			string cont_auemail = tbxAuEmail.Text.Trim();
			int cont_freetm = 0;

			try
			{
				cont_freetm = Convert.ToInt32(tbxFreeTm.Text.Trim());
			}
			catch
			{
				jsAlertMsg("INVALIDFREETM", "贈送次數格式錯誤，應為整數");
				return;
			}

			int cont_pubtm = 0;
			try
			{
				cont_pubtm = Convert.ToInt32(tbxPubTm.Text.Trim());
			}
			catch
			{
				jsAlertMsg("INVALIDPUBTM", "刊登次數格式錯誤，應為整數");
				return;
			}

			int pubedtm = 0;
			int cont_resttm = cont_pubtm - pubedtm;	//總刊登次數 - 已刊登(落版)次數

			int cont_totimgtm = 0;
			try
			{
				cont_totimgtm = Convert.ToInt32(tbxTotImgTm.Text.Trim());
			}
			catch
			{
				jsAlertMsg("INVALIDTOTIMGTM", "總製圖檔稿次數格式錯誤，應為整數");
				return;
			}

			int cont_toturltm = 0;
			try
			{
				cont_toturltm = Convert.ToInt32(tbxTotUrlTm.Text.Trim());
			}
			catch
			{
				jsAlertMsg("INVALIDTOTURLTM", "總製網頁稿次數格式錯誤，應為整數");
				return;
			}

			float cont_disc = 0;
			try
			{
				cont_disc = Convert.ToSingle(tbxDisc.Text.Trim());
			}
			catch
			{
				jsAlertMsg("INVALIDDISC", "優惠折數格式錯誤，應為整數");
				return;
			}

			float cont_totamt = 0;
			try
			{
				cont_totamt = Convert.ToSingle(tbxTotAmt.Text.Trim());
			}
			catch
			{
				jsAlertMsg("INVALIDTOTAMT", "合約金額格式錯誤，應為整數");
				return;
			}

			float cont_paidamt = 0; //一開始應該都還沒付錢
			float cont_restamt = Convert.ToSingle(tbxTotAmt.Text.Trim()); //一開始都是滿的...
			string cont_remark = tbxRemark.Text.Trim();
			string cont_credate = DateTime.Now.ToString("yyyyMMdd");
			string cont_moddate = DateTime.Now.ToString("yyyyMMdd");
			string cont_modempno = this.WhoAmI.EmpNo;
			string cong_fgpayonce = rblPayOnce.SelectedItem.Value;
			
			//產品設備內文、廣告推廣內文、搜尋期限
			string cont_ccont = tbxCCont.Text.Trim();
			string cont_pdcont = tbxPdCont.Text.Trim();
			string cont_csdate = "";
			if(tbxCsDate.Text.Trim()!="")
			{
				try
				{
					cont_csdate = DateTime.ParseExact(tbxCsDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
				}
				catch(Exception ex)
				{
					jsAlertMsg("INVALIDCSDATE", "[搜尋期限]<BR>無法轉換日期格式，請重新輸入合法的日期，如2003/01/01");
					return;
				}
			}

			Contracts cont = new Contracts();
			bool success = cont.UpdateToBeFormal(cont_contno, cont_conttp, cont_signdate, cont_sdate, cont_edate, cont_empno, cont_mfrno, cont_custno, 
								cont_aunm, 	cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_freetm, cont_pubtm, 
								cont_resttm, cont_totimgtm, cont_toturltm, cont_disc, cont_totamt, cont_paidamt, cont_restamt, 
								cont_remark, cont_credate, cont_moddate, cont_modempno, cong_fgpayonce, cont_ccont, cont_pdcont, cont_csdate);

			//檢查合約是否正式儲存成功
			if (success)
			{
				jsAlertMsg("SAVECONTSUCCESS", "合約儲存成功，可繼續從選單進行落版或其他相關事宜");
				//btnSave.Visible = false;
				//btnNoSave.Visible = false;
				pnlBack.Visible = true;
				pnlContBody.Visible = false;
			}
			else
			{
				jsAlertMsg("SAVECONTFAILED", "合約儲存失敗，系統可能出錯，請通知聯絡人");
			}
		}
		#endregion

		#region 刪除此暫存合約
		private void btnNoSave_Click(object sender, System.EventArgs e)
		{
			string contno = lblContNo.Text.Trim();
				Contracts cont = new Contracts();
				cont.DeleteContTemp(contno);

				jsAlertMsg("DELETECONTFAILED", "暫存資料已經清除，請繼續其他功能處理");

				//btnSave.Visible = false;
				//btnNoSave.Visible = false;
				pnlBack.Visible = true;
				pnlContBody.Visible = false;
		}
		#endregion

		#region Show應用產業及材料特性
		private void ShowAtpMatp()
		{
			string contno = lblContNo.Text.Trim();
			AtpMtps ams1 = new AtpMtps();
			DataSet ds1 = ams1.GetAtpMtps_Display(contno, "1");
			DataView dv1 = ds1.Tables[0].DefaultView;
			if (dv1.Count>0)
			{
				DataTable dt = new DataTable();
				DataColumn c1 = new DataColumn("cls2_cname", typeof(System.String));
				dt.Columns.Add(c1);
				DataColumn c2 = new DataColumn("cls3_cname", typeof(System.String));
				dt.Columns.Add(c2);
				DataRow dr;
						
				string	strcls2, strcls3;
				strcls2=strcls3="";
				for(int idx=0; idx<dv1.Count; idx++)
				{
					if(dv1[idx].Row["cls2_cname"].ToString()!=strcls2)
					{
						if (idx>0)
						{
							dr=dt.NewRow();
							dr["cls2_cname"]=strcls2;
							dr["cls3_cname"]=strcls3;
							dt.Rows.Add(dr);
						}
						strcls2=dv1[idx].Row["cls2_cname"].ToString();
						strcls3=dv1[idx].Row["cls3_cname"].ToString();
					}
					else
					{
						strcls3=strcls3+";"+dv1[idx].Row["cls3_cname"].ToString();
					}
				}
				//最後一次
				dr=dt.NewRow();
				dr["cls2_cname"]=strcls2;
				dr["cls3_cname"]=strcls3;
				dt.Rows.Add(dr);
				dgdAtpMatp1.DataSource = dt;
				dgdAtpMatp1.DataBind();
			}
			

			AtpMtps ams2 = new AtpMtps();
			DataSet ds2 = ams2.GetAtpMtps_Display(contno, "2");
			DataView dv2 = ds2.Tables[0].DefaultView;
			
			if (dv2.Count>0)
			{
				DataTable dt = new DataTable();
				DataColumn c1 = new DataColumn("cls2_cname", typeof(System.String));
				dt.Columns.Add(c1);
				DataColumn c2 = new DataColumn("cls3_cname", typeof(System.String));
				dt.Columns.Add(c2);
				DataRow dr;
						
				string	strcls2, strcls3;
				strcls2=strcls3="";
				for(int idx=0; idx<dv2.Count; idx++)
				{
					if(dv2[idx].Row["cls2_cname"].ToString()!=strcls2)
					{
						if (idx>0)
						{
							dr=dt.NewRow();
							dr["cls2_cname"]=strcls2;
							dr["cls3_cname"]=strcls3;
							dt.Rows.Add(dr);
						}
						strcls2=dv2[idx].Row["cls2_cname"].ToString();
						strcls3=dv2[idx].Row["cls3_cname"].ToString();
					}
					else
					{
						strcls3=strcls3+";"+dv2[idx].Row["cls3_cname"].ToString();
					}
				}
				//最後一次
				dr=dt.NewRow();
				dr["cls2_cname"]=strcls2;
				dr["cls3_cname"]=strcls3;
				dt.Rows.Add(dr);
				dgdAtpMatp2.DataSource = dt;
				dgdAtpMatp2.DataBind();
			}

		}
		#endregion

		#region Show雜誌收件人及贈書資料
		private void ShowFreeBook()
		{
			string contno = lblContNo.Text.Trim();
			FreeBooks fbk1 = new FreeBooks();
			DataSet ds1 = fbk1.GetOrByContNo(contno);
			DataView dv1 = ds1.Tables[0].DefaultView;
			dgdNewOr.DataSource = dv1;
			dgdNewOr.DataBind();
			if (dv1.Count>0)
			{
				dgdNewOr.Visible = true;
			}
			else
			{
				dgdNewOr.Visible = false;
			}

			FreeBooks fbk2 = new FreeBooks();
			DataSet ds2 = fbk2.GetFbkOrByContNo(contno);
			DataView dv2 = ds2.Tables[0].DefaultView;
			dgdNewFreeBk.DataSource = dv2;
			dgdNewFreeBk.DataBind();
			if (dv2.Count>0)
			{
				dgdNewFreeBk.Visible = true;
			}
			else
			{
				dgdNewFreeBk.Visible = false;
			}

		}
		#endregion

		#region Show發票廠商資料
		private void ShowInvMfr()
		{
			string contno = lblContNo.Text.Trim();
			InvMfrs im = new InvMfrs();
			DataSet ds = im.GetInvMfr(contno);
			DataView dv = ds.Tables[0].DefaultView;
			dgdNewInvMfr.DataSource = dv;
			dgdNewInvMfr.DataBind();
			if (dv.Count>0)
			{
				dgdNewInvMfr.Visible = true;

			}
			else
			{
				dgdNewInvMfr.Visible = false;
			}

		}
		#endregion

		#region 回主選單
		private void btnHome_Click(object sender, System.EventArgs e)
		{
			string home = D4Settings.HomeUrl;
			Response.Redirect(home);
		}
		#endregion

		#region 輸入合約結束日期後計算天數
		private void tbxEDate_TextChanged(object sender, System.EventArgs e)
		{
			DateTime sdate;
			DateTime edate;
			try
			{
				sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("SDATEERROR", "合約起始日期格式錯誤，無法用來計算區間天數");
				return;
			}

			try
			{
				edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("EDATEERROR", "合約結束日期格式錯誤，無法用來計算區間天數");
				return;
			}
			if (sdate>edate)
			{
				jsAlertMsg("INVALIDPERIOD", "起始日期不可大於結束日期，請更正");
				return;
			}

			double pubdays = ((TimeSpan)edate.Subtract(sdate)).TotalDays + 1;

			tbxPubTm.Text = pubdays.ToString();
		}
		#endregion

		#region 利用合約起訖日期計算次數
		private void btnCount_Click(object sender, System.EventArgs e)
		{
			DateTime sdate;
			DateTime edate;
			try
			{
				sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("SDATEERROR", "合約起始日期格式錯誤，無法用來計算區間天數");
				return;
			}

			try
			{
				edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("EDATEERROR", "合約結束日期格式錯誤，無法用來計算區間天數");
				return;
			}

			double pubdays = ((TimeSpan)edate.Subtract(sdate)).TotalDays + 1;

			tbxPubTm.Text = pubdays.ToString();		

		}
		#endregion
	}
}
