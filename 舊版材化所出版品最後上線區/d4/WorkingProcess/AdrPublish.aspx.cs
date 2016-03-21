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
	/// Summary description for AdrPublish.
	/// </summary>
	public class AdrPublish : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.Label lblContTp;
		protected System.Web.UI.WebControls.Label lblSignDate;
		protected System.Web.UI.WebControls.Label lblSDate;
		protected System.Web.UI.WebControls.Label lblEDate;
		protected System.Web.UI.WebControls.Label lblMfrNm;
		protected System.Web.UI.WebControls.Label lblCustNm;
		protected System.Web.UI.WebControls.Label lblPubTm;
		protected System.Web.UI.WebControls.Label lblFreeTm;
		protected System.Web.UI.WebControls.Label lblTotAmt;
		protected System.Web.UI.WebControls.Label lblDisc;
		protected System.Web.UI.WebControls.Label lbl_PubTm;
		protected System.Web.UI.WebControls.Label lbl_TotImgTm;
		protected System.Web.UI.WebControls.Label lbl_TotUrlTm;
		protected System.Web.UI.WebControls.Label lbl_PubedTm;
		protected System.Web.UI.WebControls.Label lbl_RestImgTm;
		protected System.Web.UI.WebControls.Label lbl_RestUrlTm;
		protected System.Web.UI.WebControls.Label lbl_RestTm;
		protected System.Web.UI.WebControls.Label lblTotMtm;
		protected System.Web.UI.WebControls.Label lblTotItm;
		protected System.Web.UI.WebControls.Label lblTotNtm;
		protected System.Web.UI.WebControls.TextBox tbxAltText;
		protected System.Web.UI.WebControls.DropDownList ddlInvMfr;
		protected System.Web.UI.WebControls.TextBox tbxSDate;
		protected System.Web.UI.WebControls.TextBox tbxEDate;
		protected System.Web.UI.WebControls.DropDownList ddlAdCate;
		protected System.Web.UI.WebControls.DropDownList ddlKeyword;
		protected System.Web.UI.WebControls.RadioButtonList rblFgFixAd;
		protected System.Web.UI.WebControls.TextBox tbxImpr;
		protected System.Web.UI.WebControls.RadioButtonList rblImgTp;
		protected System.Web.UI.WebControls.RadioButtonList rblUrlTp;
		protected System.Web.UI.WebControls.TextBox tbxNavUrl;
		protected System.Web.UI.WebControls.TextBox tbxAdAmt;
		protected System.Web.UI.WebControls.TextBox tbxDesAmt;
		protected System.Web.UI.WebControls.TextBox tbxChgAmt;
		protected System.Web.UI.WebControls.TextBox tbxInvAmt;
		protected System.Web.UI.WebControls.TextBox tbxRemark;
		protected System.Web.UI.WebControls.Button bthAddAdr;
		protected System.Web.UI.WebControls.DataGrid dgdAdr;
		protected System.Web.UI.WebControls.Button btnSelAll;
		protected System.Web.UI.WebControls.Button btnDeSelAll;
		protected System.Web.UI.WebControls.Button btnDelSeltedAdr;
		protected System.Web.UI.WebControls.Label lblAdrInfo;
		protected System.Web.UI.WebControls.DataGrid dgdNewInvMfr1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hiddenAdrImpr;
		protected System.Web.UI.WebControls.Label lblTotAdAmt;
		protected System.Web.UI.WebControls.Label lblTotDesAmt;
		protected System.Web.UI.WebControls.Label lblTotChgAmt;
		protected System.Web.UI.WebControls.Label lblTotPubedAmt;
		protected System.Web.UI.WebControls.Label lblHint;
		protected System.Web.UI.WebControls.TextBox tbxCountDay;
		protected System.Web.UI.WebControls.Button btnCount;
		protected System.Web.UI.WebControls.Label Label1;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				//預設欄位
				tbxAdAmt.Text = "0";
				tbxDesAmt.Text = "0";
				tbxChgAmt.Text = "0";
				tbxInvAmt.Text = "0";
				tbxImpr.Text = "1";


				//檢查變數，這樣大概可以過濾一些
				string new_contno = "";
				if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
				{
					throw new Exception("找不到合約編號");
				}
				else
				{
					new_contno = Request.QueryString["NewContNo"];
				}

				LoadContInfo(new_contno);

//				string old_contno = "";
//				if (Request.QueryString["OldContNo"] == null || Request.QueryString["OldContNo"] == "")
//				{
//					//在維護合約時，從合約資料去找.....
//					Contracts cont = new Contracts();
//					SqlDataReader dr = cont.GetSingleContractByContNo(new_contno);
//
//					dr.Read();
//					try
//					{
//						old_contno = dr["cont_oldcontno"].ToString();
//					}
//					catch
//					{
//						throw new Exception("找不到合約資料，請通知聯絡人");
//					}
//					dr.Close();
//
//				}
//				else
//				{
//					old_contno = Request.QueryString["OldContNo"];
//				}

//				Bind_dgdOldInvMfr(old_contno);
				Bind_NewInvMfr(new_contno);
				Bind_NewAdr(new_contno);
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
			Bind_NewInvMfr(Request.QueryString["NewContNo"]);
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
			this.bthAddAdr.Click += new System.EventHandler(this.bthAddAdr_Click);
			this.btnSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
			this.btnDeSelAll.Click += new System.EventHandler(this.btnDeSelAll_Click);
			this.btnDelSeltedAdr.Click += new System.EventHandler(this.btnDelSeltedAdr_Click);
			this.dgdAdr.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdAdr_CancelCommand);
			this.dgdAdr.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdAdr_EditCommand);
			this.dgdAdr.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgdAdr_UpdateCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region 載入合約基本資料
		private void LoadContInfo(string contno)
		{
			if (contno.Trim() == "")
				throw new Exception("合約編號不可為空白");

			Contracts cont;

//			照理說不需要從暫存一路做到底....從 資料庫Load出來吧
//			if (Session["TMPCONT"] == null)
//				throw new Exception("遺失暫存合約物件");
//			else
//				cont = (Contracts)Session["TMPCONT"];

//			lblContNo.Text = cont.ContNo;
//			lblContTp.Text = cont.ContTp;
//			lblSignDate.Text = DateTime.ParseExact(cont.SignDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
//			lblSDate.Text = DateTime.ParseExact(cont.SDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
//			lblEDate.Text = DateTime.ParseExact(cont.EDate, "yyyyMMdd", null).ToString("yyyy/MM/dd");
//			lblPubTm.Text = cont.PubTm.ToString();
//			lblFreeTm.Text = cont.FreeTm.ToString();
//			lblTotAmt.Text = cont.TotAmt.ToString();
//			lblDisc.Text = cont.Disc.ToString();
//			lblTotImgTm.Text = cont.TotImgTm.ToString();
//			lblTotUrlTm.Text = cont.TotUrlTm.ToString();


			cont = new Contracts();
			SqlDataReader dr = cont.GetSingleContractByContNo(contno);
			if (dr.Read())
			{
				lblContNo.Text = dr["cont_contno"].ToString();

				switch(dr["cont_conttp"].ToString().Trim())
				{
					case "01":
						lblContTp.Text = "一般";
						break;
					case "09":
						lblContTp.Text = "推廣";
						break;
					default:
						lblContTp.Text = "(無法辨識)";
						break;
				}

				lblSignDate.Text = DateTime.ParseExact(dr["cont_signdate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
				lblSDate.Text = DateTime.ParseExact(dr["cont_sdate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
				lblEDate.Text = DateTime.ParseExact(dr["cont_edate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
				lblMfrNm.Text = dr["mfr_inm"].ToString();
				lblCustNm.Text = dr["cust_nm"].ToString();
				lblPubTm.Text = dr["cont_pubtm"].ToString();
				//lblRestTm.Text = dr["cont_resttm"].ToString();
				lblFreeTm.Text = dr["cont_freetm"].ToString();
				lblTotAmt.Text = dr["cont_totamt"].ToString();
				lblDisc.Text = dr["cont_disc"].ToString();
				//lblTotImgTm.Text = dr["cont_totimgtm"].ToString();
				//lblTotUrlTm.Text = dr["cont_toturltm"].ToString();


				//附加的資訊
				Advertisements adr = new Advertisements();
				SqlDataReader dr2 = adr.GetAdrCounts(contno);
				int imgtm = 0;
				int urltm = 0;
				int pubedtm = 0;
				int totmtm = 0;
				int totitm = 0;
				int totntm = 0;
				if (dr2.Read())
				{
					imgtm = Convert.ToInt32(dr2["imgtm"]);
					urltm = Convert.ToInt32(dr2["urltm"]);
					pubedtm = Convert.ToInt32(dr2["pubedtm"]);
					totmtm = Convert.ToInt32(dr2["totmtm"]);
					totitm = Convert.ToInt32(dr2["totitm"]);
					totntm = Convert.ToInt32(dr2["totntm"]);
				}
				dr2.Close();

				lbl_PubTm.Text = dr["cont_pubtm"].ToString();
				lbl_PubedTm.Text = pubedtm.ToString();
				lbl_RestTm.Text = Convert.ToString( Convert.ToInt32(lbl_PubTm.Text) - Convert.ToInt32(lbl_PubedTm.Text));
				lbl_TotImgTm.Text = dr["cont_totimgtm"].ToString();
				lbl_RestImgTm.Text = Convert.ToString(Convert.ToInt32(lbl_TotImgTm.Text)-imgtm);
				if (Convert.ToInt32(lbl_RestImgTm.Text)<0)
				{
					jsAlertMsg("NEGRESTIMGTM", "剩餘製圖檔稿次數小餘零，請檢查/修改圖檔稿件類別");
				}
				lbl_TotUrlTm.Text = dr["cont_toturltm"].ToString();
				lbl_RestUrlTm.Text = Convert.ToString(Convert.ToInt32(lbl_TotUrlTm.Text)-urltm);
				if (Convert.ToInt32(lbl_RestUrlTm.Text)<0)
				{
					jsAlertMsg("NEGRESTURLTM", "剩餘製網頁稿次數小餘零，請檢查/修改網頁稿件類別");
				}
				
				lblTotMtm.Text = totmtm.ToString();
				lblTotItm.Text = totitm.ToString();
				lblTotNtm.Text = totntm.ToString();
			}
			dr.Close();
		}
		#endregion

		#region 歷史合約的發票廠商收件人資料
//		private void Bind_dgdOldInvMfr(string contno)
//		{
//			if (contno.Trim() == "")
//			{
//				lblOldIm.Text = "無歷史合約發票廠商收件人資料";
//				dgdOldInvMfr.Visible = false;
//				return;
//			}
//
//			InvMfrs im = new InvMfrs();
//			DataSet ds = im.GetInvMfr(contno);
//			DataView dv = ds.Tables[0].DefaultView;
//			dgdOldInvMfr.DataSource = dv;
//			dgdOldInvMfr.DataBind();
//
//			if (dv.Count>0)
//			{
//				lblOldIm.Text = "歷史合約發票廠商收件人資料";
//				dgdOldInvMfr.Visible = true;
//
//				for (int i=0; i<dgdOldInvMfr.Items.Count; i++)
//				{
//					try
//					{
//						//找的到所內、院內就show
//						dgdOldInvMfr.Items[i].Cells[13].Text = ddlFgItri.Items.FindByValue(dgdOldInvMfr.Items[i].Cells[13].Text.Trim()).Text;
//					}
//					catch
//					{
//						//其他的視為一般
//						dgdOldInvMfr.Items[i].Cells[13].Text = "一般";
//					}
//				}
//			}
//			else
//			{
//				lblOldIm.Text = "無歷史合約發票廠商收件人資料";
//				dgdOldInvMfr.Visible = false;
//			}
//		}
		#endregion

		#region 本合約的發票廠商收件人資料
		private void Bind_NewInvMfr(string contno)
		{
			InvMfrs im = new InvMfrs();
			DataSet ds = im.GetInvMfr(contno);
			DataView dv = ds.Tables[0].DefaultView;
			dgdNewInvMfr1.DataSource = dv;
			dgdNewInvMfr1.DataBind();

			Bind_ddlInvMfr(dv);

			if (dv.Count>0)
			{
//				lblNewIm.Text = "本合約發票廠商收件人資料";
				dgdNewInvMfr1.Visible = true;

//				for (int i=0; i<dgdNewInvMfr.Items.Count; i++)
//				{
//					try
//					{
//						//找的到所內、院內就show
//						dgdNewInvMfr.Items[i].Cells[13].Text = ddlFgItri.Items.FindByValue(dgdNewInvMfr.Items[i].Cells[13].Text.Trim()).Text;
//					}
//					catch
//					{
//						//其他的視為一般
//						dgdNewInvMfr.Items[i].Cells[13].Text = "一般";
//					}
//				}
			}
			else
			{
//				lblNewIm.Text = "本合約尚無發票廠商收件人資料";
				dgdNewInvMfr1.Visible = false;
			}
		}
		#endregion

		#region 連結發票廠商下拉式選單
		private void Bind_ddlInvMfr(DataView dv)
		{
			ddlInvMfr.DataTextField = "im_nm";
			ddlInvMfr.DataValueField = "im_imseq";
			ddlInvMfr.DataSource = dv;
			ddlInvMfr.DataBind();
		}
		#endregion

		#region 新增廣告落版
		private void bthAddAdr_Click(object sender, System.EventArgs e)
		{
			string contno = lblContNo.Text.Trim();

			string sdate;
			try
			{
				sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			}
			catch(Exception ex)
			{
				jsAlertMsg("SDATEFORMATERROR", "起始日期格式錯誤");
				return;
			}

			string edate;
			try
			{
				edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			}
			catch(Exception ex)
			{
				jsAlertMsg("EDATEFORMATERROR", "結束日期格式錯誤");
				return;
			}

			if (DateTime.ParseExact(sdate, "yyyyMMdd", null) > DateTime.ParseExact(edate, "yyyyMMdd", null))
			{
				jsAlertMsg("NEGATIVETIMEPERIOD", "起始日期不可以比結束日期大");
				return;
			}

			if (DateTime.ParseExact(sdate, "yyyyMMdd", null) < DateTime.Today)
			{
				jsAlertMsg("NEGATIVETIMEPERIOD", "不能新增今天之前的廣告資料");
				return;
			}

			DateTime csdate = DateTime.ParseExact(lblSDate.Text.Trim(), "yyyy/MM/dd", null);
			DateTime cedate = DateTime.ParseExact(lblEDate.Text.Trim(), "yyyy/MM/dd", null);

			if ( !(csdate <= DateTime.ParseExact(sdate, "yyyyMMdd", null) &&  DateTime.ParseExact(edate, "yyyyMMdd", null) <= cedate) )
			{
				jsAlertMsg("INVALIDPERIOD", "廣告起迄區間不可超出合約起迄區間");
				return;
			}

			double addays = ((TimeSpan)DateTime.ParseExact(edate, "yyyyMMdd", null).Subtract(DateTime.ParseExact(sdate, "yyyyMMdd", null))).TotalDays + 1;
			if (addays > Convert.ToInt32(lbl_RestTm.Text.Trim()))
			{
				jsAlertMsg("INVALIDDAYS", "新增的刊登日數(次數:" + addays.ToString() + ")不可大於剩餘刊登次數:" + lbl_RestTm.Text.Trim());
				return;
			}



			string adcate = ddlAdCate.SelectedItem.Value;
			string keyword = ddlKeyword.SelectedItem.Value;
			string alttext = tbxAltText.Text.Trim();
			string imgurl = "";	//由美編決定
			string navurl = tbxNavUrl.Text.Trim();	//美編可以再決定
			if (!navurl.ToLower().StartsWith("http://"))
				if (navurl.Trim()!="")
					navurl = "http://" + navurl;
			int impr;
			try
			{
				impr = Convert.ToInt32(tbxImpr.Text.Trim());
			}
			catch(Exception ex)
			{
				jsAlertMsg("IMPRFORMATERROR", "播出機率格式錯誤");
				return;
			}

			string drafttp = rblImgTp.SelectedItem.Value;
			string urltp = rblUrlTp.SelectedItem.Value;

			if (ddlInvMfr.Items.Count<=0 && lblContTp.Text.Trim() == "一般")
			{
				jsAlertMsg("NOINVMFR", "本合約為一般合約，請先新增發票廠商收件人後再新增廣告");
				return;
			}
			string imseq;
			if (lblContTp.Text.Trim() == "一般")
			{
				imseq = ddlInvMfr.SelectedItem.Value;
			}
			else
			{
				imseq = "";
			}

			int adamt;
			try
			{
				adamt = Convert.ToInt32(tbxAdAmt.Text.Trim());
			}
			catch(Exception ex)
			{
				jsAlertMsg("ADAMTFORMATERROR", "廣告金額格式錯誤");
				return;
			}

			int desamt;
			try
			{
				desamt = Convert.ToInt32(tbxDesAmt.Text.Trim());
			}
			catch(Exception ex)
			{
				jsAlertMsg("DESAMTFORMATERROR", "設計價格格式錯誤");
				return;
			}

			int chgamt;
			try
			{
				chgamt = Convert.ToInt32(tbxChgAmt.Text.Trim());
			}
			catch(Exception ex)
			{
				jsAlertMsg("CHGAMTFORMATERROR", "換稿費用格式錯誤");
				return;
			}

			//檢查廣告金額問題
			int totamt = 0;
			try
			{
				totamt = Convert.ToInt32(lblTotAmt.Text.Trim());
			}
			catch
			{
				jsAlertMsg("INVALIDTOTAMT", "合約總金額格式錯誤，請至合約維護修改金額");
				return;
			}


			//
			// 2003/06/11
			//註：這邊很重要，跟C300討論結果，
			//僅有廣告價格要跟合約金額做限制比對，
			//而設計價格與換稿費用不包含在合約金額裡面
			//

			//合約剩餘金額的計算
			int restamt = int.Parse(lblTotAmt.Text.ToString());
			for(int k=0; k<dgdAdr.Items.Count; k++)
			{
				try
				{
					restamt -= Convert.ToInt32(dgdAdr.Items[k].Cells[9].Text.Trim());
				}
				catch
				{
					jsAlertMsg("ERRORINSUMATION", "加總計算已落版金額時發生錯誤，請通知聯絡人");
					return;
				}
			}

			if ( adamt>restamt )	//本來用這個          !VerifyMoneyIsValid(adamt, desamt, chgamt, totamt)
			{
				jsAlertMsg("INVALIDMONEY", "新增的廣告價格不得超過合約總金額，請更改金額後再新增");
				return;
			}

			string remark = tbxRemark.Text.Trim();

			string fgfixad = rblFgFixAd.SelectedItem.Value;
			//CHCECK是否定播
			if (fgfixad == "1")
			{
				impr = 20;
				jsAlertMsg("SETIMPRTO20", "由於定播，所以強制轉換播放機率為20");
			}

			//檢查剩餘的空間夠不夠
			DateTime firstXday;
			Advertisements adr = new Advertisements();
			SqlDataReader drslot = adr.CheckAdrSlot(adcate, keyword, sdate, edate, impr, 0);
			if (drslot.Read())
			{
				firstXday = DateTime.ParseExact(drslot["cnt_date"].ToString(), "yyyyMMdd", null);
				jsAlertMsg("NOTENOUGH", firstXday.ToString("yyyy/MM/dd") + "的剩餘空間不足，請修改起迄日期區段");
				return;
			}
			drslot.Close();


			//院所內註記跟發票廠商資料走
			string fgitri = "";

			if (ddlInvMfr.Items.Count>=0 && lblContTp.Text.Trim() == "一般")
			{
				InvMfrs im = new InvMfrs();
				SqlDataReader dr = im.GetSingleIm(contno, imseq);
				if (dr.Read())
				{
					fgitri = dr["im_fgitri"].ToString().Trim();
				}
				else
				{
					jsAlertMsg("LOSSINVMFR", "資料庫遺失本合約發票廠商資料，請通知聯絡人");
					return;
				}
				dr.Close();
			}

			if (fgitri=="00")
			{
				//因為DropDownList的ListItem無法以""為Value，所以用00替代，
				//這邊再轉換回來
				fgitri="";
			}
			string fgimggot="0";//rblFgImgGot.SelectedItem.Value.Trim();
			string fgurlgot="0";//rblFgUrlGot.SelectedItem.Value.Trim();
			//以上是取得數值

			//INSERT INTO Database
			adr.AddAdr(contno, sdate, edate, adcate, keyword, alttext, imgurl, navurl, impr,
				drafttp, urltp, imseq, adamt, desamt, chgamt, remark, fgfixad, fgitri, fgimggot,fgurlgot);

			Bind_NewAdr(contno);
			LoadContInfo(contno);
		}
		#endregion

		#region 連結廣告資料
		private void Bind_NewAdr(string contno)
		{
			if (contno == null || contno.Trim().Length != 6)
			{
				jsAlertMsg("CONTNODATAERROR", "合約編號為空值或格式錯誤，請通知聯絡人");
				return;
			}
			Advertisements adr = new Advertisements();
			DataSet ds = adr.GetAdvertisements(contno);
			DataView dv = ds.Tables[0].DefaultView;

			dgdAdr.DataSource = dv;
			dgdAdr.DataBind();

			for(int i=0; i<dgdAdr.Items.Count; i++)
			{
				if(dgdAdr.Items[i].Cells[18].Text=="1")
				{
					dgdAdr.Items[i].Cells[19].Text="<font color=red>已開發票</font>";
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked = false;
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Enabled = false;
				}
				else
					dgdAdr.Items[i].Cells[19].Text="";
			}
			if (dv.Count>0)
			{
				lblAdrInfo.Text = "";
				FormatAdr();
			}
			else
			{
				lblAdrInfo.Text = "本合約尚無廣告資料";
			}
			GetAdrInfo(contno);
		}
		#endregion

		#region 取得廣告數值統計
		private void GetAdrInfo(string contno)
		{
			int totadamt = 0;
			int totdesamt = 0;
			int totchgamt = 0;
			int totpubedamt = 0;

			Advertisements adr = new Advertisements();
			SqlDataReader dr = adr.GetAdrAmounts(contno);
			if (dr.Read())
			{
				totadamt = Convert.ToInt32(dr["totadamt"]);
				totdesamt = Convert.ToInt32(dr["totdesamt"]);
				totchgamt = Convert.ToInt32(dr["totchgamt"]);
				totpubedamt = totadamt + totdesamt + totchgamt;
			}
			dr.Close();

			lblTotAdAmt.Text = totadamt.ToString();
			lblTotDesAmt.Text = totdesamt.ToString();
			lblTotChgAmt.Text = totchgamt.ToString();
			lblTotPubedAmt.Text = totpubedamt.ToString();

		}
		#endregion

		#region 格式化廣告資料
		protected object MatchAdCate(object adcate)
		{
			string transAdCate = "";
			switch(adcate.ToString())
			{
				case "M":
					transAdCate = "首頁";
					break;
				case "I":
					transAdCate = "內頁";
					break;
				case "N":
					transAdCate = "奈米";
					break;
				default:
					throw new Exception("資料庫原生廣告頁面資料錯誤，請通知聯絡人");
					break;
			}
			return transAdCate;
		}

		protected object MatchKeyword(object keyword)
		{
			string transKeyword = "";
			switch(keyword.ToString())
			{
				case "h0":
					transKeyword = "正中";
					break;
				case "h1":
					transKeyword = "右一";
					break;
				case "h2":
					transKeyword = "右二";
					break;
				case "h3":
					transKeyword = "右三";
					break;
				case "h4":
					transKeyword = "右四";
					break;
				case "w1":
					transKeyword = "右文一";
					break;
				case "w2":
					transKeyword = "右文二";
					break;
				case "w3":
					transKeyword = "右文三";
					break;
				case "w4":
					transKeyword = "右文四";
					break;
				case "w5":
					transKeyword = "右文五";
					break;
				case "w6":
					transKeyword = "右文六";
					break;
				default:
					throw new Exception("資料庫原生廣告位置資料錯誤，請通知聯絡人");
					break;
			}
			return transKeyword;
		}

		protected object MatchImSeq(object imseq)
		{
			string transImSeq = "";
			try
			{
				transImSeq = ddlInvMfr.Items.FindByValue(imseq.ToString()).Text;
			}
			catch
			{
//				if (lblContTp.Text == "一般")
//					throw new Exception("資料庫原生發票廠商資料錯誤，請通知聯絡人");
			}
			return transImSeq;
		}

		private void FormatAdr()
		{
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//編輯中的略過
				if (dgdAdr.EditItemIndex == i)
				{
					continue;	//進行下一個item
				}

				//檢查日期;92/8/15決定當天資料可刪除
//				if (DateTime.Today >= DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyyMMdd", null))
				if (DateTime.Today > DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyyMMdd", null))
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked = false;
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Enabled = false;
				}


				//廣告日期：轉換為yyyy/MM/dd
				dgdAdr.Items[i].Cells[3].Text = DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyyMMdd", null).ToString("yyyy/MM/dd");

				
			}
		}
		#endregion

		#region 全選，清選
		private void btnSelAll_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//先檢查日期
				if (DateTime.Today >= DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyy/MM/dd", null))
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked = false;
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Enabled = false;
				}
				else
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked = true;
				}
			}

			//Bind_NewAdr(lblContNo.Text.Trim());
		}

		private void btnDeSelAll_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//先檢查日期
				if (DateTime.Today >= DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyy/MM/dd", null))
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Enabled = false;
				}

				((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked = false;
			}	
			Bind_NewAdr(lblContNo.Text.Trim());	
		}
		#endregion

		#region 刪除勾選的廣告
		private void btnDelSeltedAdr_Click(object sender, System.EventArgs e)
		{
			ArrayList ary = new ArrayList();
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				if (((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked)
				{
					string adrseq = dgdAdr.Items[i].Cells[2].Text.Trim();
					string addate = RevertAdDate(dgdAdr.Items[i].Cells[3].Text.Trim());
					string adcate = RevertAdCate(((Label)dgdAdr.Items[i].Cells[5].FindControl("lblEAdCate")).Text.Trim());
					string keyword = RevertKeyword(((Label)dgdAdr.Items[i].Cells[6].FindControl("lblEKeyword")).Text.Trim());
					string impr = dgdAdr.Items[i].Cells[8].Text.Trim();

					ary.Add(adrseq + "," + addate + "," + adcate + "," + keyword + "," + impr);
				}
			}

			Advertisements adr = new Advertisements();

			//刪除前，先check
			bool xmlExist = false;
			ArrayList xeArray = new ArrayList();

			for (int i=0; i<ary.Count; i++)
			{
				string rawString = (string)ary[i];

				string addate = "";

				try
				{
					addate = ((string)(rawString.Split(',')).GetValue(1));
				}
				catch(Exception ex)
				{
					throw new Exception("無法取得落版日期資料");
				}

				string strCmd = "";
				if (addate=="")
					throw new Exception("廣告落版日期資料錯誤");

				//checking....
				xmlExist = adr.CheckXmlFileLog(addate);

				if (xmlExist)
				{
					xeArray.Add(addate);
				}
			}
			

			//有無日期出現？
			if (xeArray.Count>0)
			{
				string strDate = "";
				for (int j=0; j<xeArray.Count; j++)
				{
					strDate += (string)xeArray[j] +",";
				}

				jsAlertMsg("XMLFILELOGALERT", strDate + "已產生過落版xml檔案，欲刪除這些日期的落版資料，請先刪除這些日期對應的xml落版檔案");
				return;
			}

			//以下為可以刪除落版的執行
			string adr_contno = lblContNo.Text.Trim();
			adr.DeleteAdr(adr_contno, ary);

			Bind_NewAdr(adr_contno);
			LoadContInfo(adr_contno);
		
			#region 測試資料區
//			for (int i=0; i<ary.Count; i++)
//			{
//				string rawString = (string)ary[i];
//
//				string seq = "";
//				string addate = "";
//				string adcate = "";
//				string keyword = "";
//				string impr = "";
//
//				try
//				{
//					seq = ((string)(rawString.Split(',')).GetValue(0));
//					addate = ((string)(rawString.Split(',')).GetValue(1));
//					adcate = ((string)(rawString.Split(',')).GetValue(2));
//					keyword = ((string)(rawString.Split(',')).GetValue(3));
//					impr = ((string)(rawString.Split(',')).GetValue(4));
//				}
//				catch(Exception ex)
//				{
//					throw new Exception("無法取得落版序號、廣告日期、廣告頁面、廣告位置、播出機率等資料");
//				}
//
//				string strCmd = "";
//				if (seq == "" || addate == "" || adcate == "" || keyword == "" || impr == "")
//					throw new Exception("原生落版序號、廣告日期、廣告頁面、廣告位置、播出機率等資料錯誤");
//
//				//刪除c4_adr的資料
//				strCmd = "DELETE FROM c4_adr WHERE adr_syscd='C4' AND adr_contno='" + adr_contno + "' AND adr_seq='" + seq + "' AND adr_addate='" + addate + "'";
//				Response.Write(strCmd + "<br>");
//				//更新c4_adcnt的資料
//				strCmd = "UPDATE c4_adcnt SET cnt_" + keyword + "=cnt_" + keyword + "+" + impr + " WHERE cnt_date='" + addate + "' AND cnt_adcate='" + adcate + "'";
//				Response.Write(strCmd + "<br>");
//			}
			#endregion

		}
		#endregion

		#region 反轉換廣告資料欄位回原生資料
		//反轉日期格式回：yyyyMMdd
		private string RevertAdDate(string transAdDate)
		{
			string oriAdDate = "";

			try
			{
				oriAdDate = DateTime.ParseExact(transAdDate, "yyyy/MM/dd", null).ToString("yyyyMMdd");
			}
			catch(Exception ex)
			{
				throw new Exception("反轉日期格式時發生錯誤");
			}
			return oriAdDate;
		}

		//廣告頁面：轉換為首頁、內頁、奈米，停用中
		private string RevertAdCate(string transAdCate)
		{	
			string oriAdCate = "";

			switch(transAdCate.Trim())
			{
				case "首頁":
					oriAdCate = "M";
					break;
				case "內頁":
					oriAdCate = "I";
					break;
				case "奈米":
					oriAdCate = "N";
					break;
				default:
					throw new Exception("反轉廣告頁面格式資料錯誤");
					//Response.Write("error=" + transAdCate + ".");
					break;
			}
			return oriAdCate;
		}

		//廣告位置：轉換成中文，停用中
		private string RevertKeyword(string transKeyword)
		{
			string oriKeyword = "";

			switch(transKeyword)
			{
				case "正中":
					oriKeyword = "h0";
					break;
				case "右一":
					oriKeyword = "h1";
					break;
				case "右二":
					oriKeyword = "h2";
					break;
				case "右三":
					oriKeyword = "h3";
					break;
				case "右四":
					oriKeyword = "h4";
					break;
				case "右文一":
					oriKeyword = "w1";
					break;
				case "右文二":
					oriKeyword = "w2";
					break;
				case "右文三":
					oriKeyword = "w3";
					break;
				case "右文四":
					oriKeyword = "w4";
					break;
				case "右文五":
					oriKeyword = "w5";
					break;
				case "右文六":
					oriKeyword = "w6";
					break;
				default:
					throw new Exception("反轉廣告位置格式資料錯誤");
					//Response.Write("error="+transKeyword+".");
					break;
			}
			
			return oriKeyword;
		}
		#endregion

		#region 選定修改
		private void dgdAdr_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DateTime csdate = DateTime.ParseExact(lblSDate.Text.Trim(), "yyyy/MM/dd", null);
			DateTime cedate = DateTime.ParseExact(lblEDate.Text.Trim(), "yyyy/MM/dd", null);
			DateTime addate = DateTime.ParseExact(e.Item.Cells[3].Text.Trim(), "yyyy/MM/dd", null);

			if ( !(csdate <= addate &&  addate <= cedate) )
			{
				jsAlertMsg("INVALIDPERIOD", "無法修改超出合約起迄區間的廣告落版資料");
				return;
			}		
//			if (DateTime.Today >= DateTime.ParseExact(dgdAdr.Items[e.Item.ItemIndex].Cells[3].Text.Trim(), "yyyy/MM/dd", null))
//			{
//				jsAlertMsg("EDITPASTADRDENIED", "無法修改今日之前的廣告落版資料");
//				return;
//			}
//
//			//編輯之前....
//			//檢查logfile中是否有為欲修改資料播出日的紀錄，
//			//如果有就發message，要先delete之後才可以修改落版資料
//			Advertisements adr = new Advertisements();
//			bool xmlExist = adr.CheckXmlFileLog(addate.ToString("yyyyMMdd"));
//			if (xmlExist)
//			{
//				jsAlertMsg("FILEEXIST", "已經產生過該日廣告落版的XML檔案，請先刪除該檔案後後再修改廣告落版資料");
//				dgdAdr.EditItemIndex = -1;
//				//				return;
//			}
			///////////
			
			int	flag=EditCheck(e.Item.ItemIndex);
			if(flag==4)
			{
				jsAlertMsg("INVALIDPERIOD", "此筆廣告落版資料已開立發票, 不允許修改");
				dgdAdr.EditItemIndex = -1;
				return;
			}
			dgdAdr.EditItemIndex = e.Item.ItemIndex;
			string contno = lblContNo.Text.Trim();
			Bind_NewAdr(contno);

			//設定textbox的寬度
			DataGridItem dgi = dgdAdr.Items[e.Item.ItemIndex];

			dgi.Cells[3].Text = DateTime.ParseExact(dgi.Cells[3].Text.Trim(), "yyyyMMdd", null).ToString("yyyy/MM/dd");

			//ETC
			((TextBox)dgi.Cells[4].Controls[0]).Width = Unit.Percentage(100);

			//處理廣告頁面
			foreach(ListItem li in ddlAdCate.Items)
			{
				((DropDownList)dgi.Cells[5].Controls[1]).Items.Add(li);
			}
			((DropDownList)dgi.Cells[5].Controls[1]).SelectedIndex = -1;
			try
			{
				((DropDownList)dgi.Cells[5].Controls[1]).Items.FindByValue(dgi.Cells[15].Text.Trim()).Selected = true;
			}
			catch
			{
				//Response.Write(dgi.Cells[15].Text.Trim()+"_");
				((DropDownList)dgi.Cells[5].Controls[1]).SelectedIndex = 0;
			}

			//處理廣告位置
			foreach(ListItem li in ddlKeyword.Items)
			{
				((DropDownList)dgi.Cells[6].Controls[1]).Items.Add(li);
			}
			((DropDownList)dgi.Cells[6].Controls[1]).SelectedIndex = -1;
			try
			{
				((DropDownList)dgi.Cells[6].Controls[1]).Items.FindByValue(dgi.Cells[16].Text.Trim()).Selected = true;
			}
			catch
			{
				//Response.Write("<br>"+dgi.Cells[16].Text.Trim()+"_");
				((DropDownList)dgi.Cells[6].Controls[1]).SelectedIndex = 0;
			}


			((TextBox)dgi.Cells[7].Controls[0]).Width = Unit.Percentage(100);
			hiddenAdrImpr.Value=((TextBox)dgi.Cells[8].Controls[0]).Text;
			((TextBox)dgi.Cells[8].Controls[0]).Width = Unit.Percentage(100);
			((TextBox)dgi.Cells[9].Controls[0]).Width = Unit.Percentage(100);
			((TextBox)dgi.Cells[10].Controls[0]).Width = Unit.Percentage(100);
			((TextBox)dgi.Cells[11].Controls[0]).Width = Unit.Percentage(100);

			//發票金額
			dgi.Cells[12].Text = "[加總值]";

			//處理發票廠商
			foreach(ListItem li in ddlInvMfr.Items)
			{
				((DropDownList)dgi.Cells[13].Controls[1]).Items.Add(li);
			}
			((DropDownList)dgi.Cells[13].Controls[1]).SelectedIndex = -1;
			try
			{
				((DropDownList)dgi.Cells[13].Controls[1]).Items.FindByValue(dgi.Cells[17].Text.Trim()).Selected = true;
			}
			catch
			{
				//Response.Write("<br>"+dgi.Cells[17].Text.Trim()+"_");
				((DropDownList)dgi.Cells[13].Controls[1]).SelectedIndex = 0;
			}

			((TextBox)dgi.Cells[14].Controls[0]).Width = Unit.Percentage(100);
//			((TextBox)dgi.Cells[18].Controls[0]).Width = Unit.Percentage(100);
//			((TextBox)dgi.Cells[19].Controls[0]).Width = Unit.Percentage(100);
			if(flag==2)
			{
				((TextBox)dgi.Cells[9].Controls[0]).Enabled=false;
				((TextBox)dgi.Cells[10].Controls[0]).Enabled=false;
				((TextBox)dgi.Cells[11].Controls[0]).Enabled=false;
				((DropDownList)dgi.Cells[13].Controls[1]).Enabled=false;
			}
			else if(flag==3)
			{
				((TextBox)dgi.Cells[4].Controls[0]).Enabled=false;
				((DropDownList)dgi.Cells[5].Controls[1]).Enabled=false;
				((DropDownList)dgi.Cells[6].Controls[1]).Enabled=false;
				((TextBox)dgi.Cells[7].Controls[0]).Enabled=false;
				((TextBox)dgi.Cells[8].Controls[0]).Enabled=false;
			}
			if (DateTime.Today >= addate)
			{
				((CheckBox)dgi.Cells[0].FindControl("cbxDelAdr")).Checked = false;
				((CheckBox)dgi.Cells[0].FindControl("cbxDelAdr")).Enabled = false;
			}
		}
		#endregion

		#region 落版資料是否可修改
		private int EditCheck(int idx)
		{
			DateTime addate = DateTime.ParseExact(dgdAdr.Items[idx].Cells[3].Text.Trim(), "yyyy/MM/dd", null);
			if (DateTime.Today > addate)
			{
				if(dgdAdr.Items[idx].Cells[18].Text.Trim()=="1")
					return 4;	//所有落版資料不能修改
				else
					return 3;	//廣告資料不能修改, 發票資料可修改
			}
			else
			{
				//檢查logfile中是否有為欲修改資料播出日的紀錄，
				//如果有就發message，要先delete之後才可以修改落版資料
				Advertisements adr = new Advertisements();
				bool xmlExist = adr.CheckXmlFileLog(addate.ToString("yyyyMMdd"));
				if (xmlExist)
				{
					jsAlertMsg("FILEEXIST", "已經產生過該日廣告落版的XML檔案，如要修改廣告落版資料請先刪除該檔案");
					if(dgdAdr.Items[idx].Cells[18].Text.Trim()=="1")
						return 4;	//所有落版資料不能修改
					else
						return 3;	//廣告資料不能修改, 發票資料可修改
				}
				else
				{
					if(dgdAdr.Items[idx].Cells[18].Text.Trim()=="1")
						return 2;	//廣告資料可修改, 發票資料不能修改
					else
						return 1;	//所有落版資料皆可修改
				}
			}

			return 0;
		}
		#endregion

		#region 取消修改
		private void dgdAdr_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dgdAdr.EditItemIndex = -1;
			string contno = lblContNo.Text.Trim();
			Bind_NewAdr(contno);
		}
		#endregion

		#region 儲存修改廣告落版資料
		private void dgdAdr_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			string contno = lblContNo.Text.Trim();

			DataGridItem dgi = e.Item;

			string seq = dgi.Cells[2].Text.Trim();

			//日期
			string addate = "";
			try
			{
				addate = DateTime.ParseExact(dgi.Cells[3].Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			}
			catch
			{
				jsAlertMsg("UPDATEADDATEERROR", "日期格式錯誤");
				return;
			}

			//不可以設定為今天以前，包含今天的日期
//			if (DateTime.ParseExact(addate, "yyyyMMdd", null) <= DateTime.Today)
//			{
//				jsAlertMsg("INVALIDDATE", "不可以設定為今天或今天以前的日期");
//				return;
//			}

			//alttext
			string alttext = ((TextBox)dgi.Cells[4].Controls[0]).Text.Trim();

			string adcate = ((DropDownList)dgi.Cells[5].Controls[1]).SelectedItem.Value;

			string keyword = ((DropDownList)dgi.Cells[6].Controls[1]).SelectedItem.Value;

			string navurl = ((TextBox)dgi.Cells[7].Controls[0]).Text.Trim();
			if (!navurl.ToLower().StartsWith("http://"))
				if (navurl.Trim()!="")
					navurl = "http://" + navurl;

			int impr = Convert.ToInt32(((TextBox)dgi.Cells[8].Controls[0]).Text.Trim());
			int impr_old = int.Parse(hiddenAdrImpr.Value.Trim());

			int adamt = 0;
			try
			{
				adamt = Convert.ToInt32(((TextBox)dgi.Cells[9].Controls[0]).Text.Trim());
			}
			catch
			{
				jsAlertMsg("UPDATEADAMTERROR", "廣告金額格式錯誤");
				return;
			}

			int desamt = 0;
			try
			{
				desamt = Convert.ToInt32(((TextBox)dgi.Cells[10].Controls[0]).Text.Trim());
			}
			catch
			{
				jsAlertMsg("UPDATEDESAMTERROR", "設計金額格式錯誤");
				return;
			}
			int chgamt = 0;
			try
			{
				chgamt = Convert.ToInt32(((TextBox)dgi.Cells[11].Controls[0]).Text.Trim());
			}
			catch
			{
				jsAlertMsg("UPDATECHGAMTERROR", "換稿費用金額格式錯誤");
				return;
			}

			//檢查廣告金額問題
			int totamt = 0;
			try
			{
				totamt = Convert.ToInt32(lblTotAmt.Text.Trim());
			}
			catch
			{
				jsAlertMsg("INVALIDTOTAMT", "合約總金額格式錯誤，請至合約維護修改金額");
				return;
			}

			if ( !VerifyMoneyIsValid(adamt, desamt, chgamt, totamt) )
			{
				jsAlertMsg("INVALIDMONEY", "廣告價格、設計價格、換稿費用總和不得超過合約總金額，請更改金額後再新增");
				return;
			}

			if (((DropDownList)dgi.Cells[13].Controls[1]).Items.Count<=0 && lblContTp.Text.Trim() == "一般")
			{
				jsAlertMsg("NOINVMFR", "本合約為一般合約，請先新增發票廠商收件人後再修改/儲存廣告");
				return;
			}
			string imseq;
			if (lblContTp.Text.Trim() == "一般")
			{
				imseq = ((DropDownList)dgi.Cells[13].Controls[1]).SelectedItem.Value;
			}
			else
			{
				imseq = "";
			}

			//檢查剩餘空間
			Advertisements adr = new Advertisements();
			DateTime firstXday;
			SqlDataReader drslot = adr.CheckAdrSlot(adcate, keyword, addate, addate, impr, impr_old);
			if (drslot.Read())
			{
				firstXday = DateTime.ParseExact(drslot["cnt_date"].ToString(), "yyyyMMdd", null);
				jsAlertMsg("NOTENOUGH", firstXday.ToString("yyyy/MM/dd") + "的剩餘空間不足，請修改起迄日期區段");
				return;
			}
			drslot.Close();
			
			//院所內註記跟發票廠商資料走
			string fgitri = "";

			if (lblContTp.Text.Trim() == "一般")
			{
				InvMfrs im = new InvMfrs();
				SqlDataReader dr = im.GetSingleIm(contno, imseq);
				if (dr.Read())
				{
					fgitri = dr["im_fgitri"].ToString().Trim();
				}
				else
				{
					jsAlertMsg("LOSSINVMFR", "資料庫遺失本合約發票廠商資料，請通知聯絡人");
					return;
				}
				dr.Close();
			}

			if (fgitri=="00")
			{
				//因為DropDownList的ListItem無法以""為Value，所以用00替代，
				//這邊再轉換回來
				fgitri="";
			}
			//以上是取得數值

			string remark = ((TextBox)dgi.Cells[14].Controls[0]).Text.Trim();
//			Response.Write("imseq=" + imseq);


			//通通好了就做UPDATE，目前計畫代號，成本中心不給user帶
			//Response.Write("UPDATE c4_adr SET adr_addate="+addate+", adr_alttext="+alttext+", adr_adcate="+adcate+", adr_keyword="+keyword+", adr_navurl="+navurl+", adr_impr="+impr+", adr_adamt="+adamt.ToString()+", adr_desamt="+desamt.ToString()+", adr_chgamt="+chgamt.ToString()+", adr_invamt="+Convert.ToString(adamt+desamt+chgamt)+", adr_imseq="+imseq+", adr_remark="+remark+" WHERE adr_contno=contno AND adr_seq=seq");
			int errorcode = adr.UpdateAdrLite1(contno, seq, addate, adcate, keyword, alttext, navurl, impr, imseq, adamt, desamt, chgamt, remark);

			if (errorcode<0)
			{
				//表示有錯發生
				switch(errorcode)
				{
					case -1:
						jsAlertMsg("UPDATEADRFAILE1", "剩餘空間不足，取消更新動作");
						break;
					case -2:
						jsAlertMsg("UPDATEADRFAILE2", "廣告更新失敗");
						break;
					case -3:
						jsAlertMsg("UPDATEADRFAILE2", "廣告計數補足失敗，取消更新動作");
						break;
					default:
						break;
				}
				return;
			}
			
			//Finally....Success!!!
			dgdAdr.EditItemIndex = -1;
			Bind_NewAdr(contno);
			LoadContInfo(contno);
		}
		#endregion

		#region 檢查輸入的資料是否合乎邏輯
		private bool VerifyMoneyIsValid(int adamt, int desamt, int chgamt, int totamt)
		{
			if (adamt+desamt+chgamt>totamt)
				return false;
			else
				return true;
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
				jsAlertMsg("SDATEERROR", "起始日期格式錯誤，無法用來計算區間天數");
				return;
			}

			try
			{
				edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("EDATEERROR", "結束日期格式錯誤，無法用來計算區間天數");
				return;
			}
			if (sdate>edate)
			{
				jsAlertMsg("INVALIDPERIOD", "起始日期不可大於結束日期，請更正");
				return;
			}

			double pubdays = ((TimeSpan)edate.Subtract(sdate)).TotalDays + 1;

			tbxCountDay.Text = pubdays.ToString();
		
		}

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
				jsAlertMsg("SDATEERROR", "起始日期格式錯誤，無法用來計算區間天數");
				return;
			}

			try
			{
				edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("EDATEERROR", "結束日期格式錯誤，無法用來計算區間天數");
				return;
			}
			if (sdate>edate)
			{
				jsAlertMsg("INVALIDPERIOD", "起始日期不可大於結束日期，請更正");
				return;
			}

			double pubdays = ((TimeSpan)edate.Subtract(sdate)).TotalDays + 1;

			tbxCountDay.Text = pubdays.ToString();
		}
		#endregion


	}
}
