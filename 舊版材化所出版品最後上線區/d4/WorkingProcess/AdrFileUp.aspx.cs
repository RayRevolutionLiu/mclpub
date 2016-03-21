using System;
using System.IO;
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
	/// Summary description for AdrFileUp.
	/// </summary>
	public class AdrFileUp : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Label lblContNo;
		protected System.Web.UI.WebControls.Label lblContTp;
		protected System.Web.UI.WebControls.Label lblSignDate;
		protected System.Web.UI.WebControls.Label lblSDate;
		protected System.Web.UI.WebControls.Label lblEDate;
		protected System.Web.UI.WebControls.Label lblPubTm;
		protected System.Web.UI.WebControls.Label lblFreeTm;
		protected System.Web.UI.WebControls.Label lblTotAmt;
		protected System.Web.UI.WebControls.Label lblDisc;
		protected System.Web.UI.WebControls.Label lblTotImgTm;
		protected System.Web.UI.WebControls.DataGrid dgdAdr;
		protected System.Web.UI.WebControls.Panel pnlAdr;
		protected System.Web.UI.WebControls.DropDownList ddlImages;
		protected System.Web.UI.WebControls.Button btnSetImage;
		protected System.Web.UI.WebControls.Button btnRefresh;
		protected System.Web.UI.WebControls.Label lblInfo;
		protected System.Web.UI.WebControls.TextBox tbxNavUrl;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnSelAll;
		protected System.Web.UI.WebControls.Button btnDeSelAll;
		protected System.Web.UI.WebControls.Label lblType1;
		protected System.Web.UI.WebControls.TextBox tbxSDate;
		protected System.Web.UI.WebControls.TextBox tbxEDate;
		protected System.Web.UI.WebControls.Button btnDateSetImage;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.CheckBox cbxImage;
		protected System.Web.UI.WebControls.CheckBox cbxLink;
		protected System.Web.UI.WebControls.CheckBox cbxAltText;
		protected System.Web.UI.WebControls.TextBox tbxAltText;
		protected System.Web.UI.WebControls.Label lblTotUrlTm;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!Page.IsPostBack)
			{
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

				Bind_NewAdr(new_contno);

				Bind_ddlImages();
				cbxImage.Checked = true;
				cbxLink.Checked = true;
				cbxAltText.Checked = true;
			}
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
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			this.btnDateSetImage.Click += new System.EventHandler(this.btnDateSetImage_Click);
			this.btnSetImage.Click += new System.EventHandler(this.btnSetImage_Click);
			this.btnSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
			this.btnDeSelAll.Click += new System.EventHandler(this.btnDeSelAll_Click);
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
				lblPubTm.Text = dr["cont_pubtm"].ToString();
				lblFreeTm.Text = dr["cont_freetm"].ToString();
				lblTotAmt.Text = dr["cont_totamt"].ToString();
				lblDisc.Text = dr["cont_disc"].ToString();
				lblTotImgTm.Text = dr["cont_totimgtm"].ToString();
				lblTotUrlTm.Text = dr["cont_toturltm"].ToString();

			}
			dr.Close();
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

			if (dv.Count>0)
			{
//				lblAdrInfo.Text = "本合約廣告落版資料";
				pnlAdr.Visible = true;
				FormatAdr();
			}
			else
			{
				lblMessage.Text = "本合約尚無廣告落版資料";
				pnlAdr.Visible = false;
			}
		}
		#endregion

		#region 格式化廣告資料
		private void FormatAdr()
		{
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{		
				DateTime addate;
				try
				{
					addate = DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyyMMdd", null);
				}
				catch
				{
					throw new Exception("日期格式不符，資料庫日期格式錯誤");
				}

				//checkbox的disable小於今天的資料不能修改
				if (addate<DateTime.Today)
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSel")).Enabled = false;
					dgdAdr.Items[i].Cells[1].Enabled = false;
				}

				//廣告日期：轉換為yyyy/MM/dd
				dgdAdr.Items[i].Cells[3].Text = addate.ToString("yyyy/MM/dd");
				
				//廣告頁面：轉換為首頁、內頁、奈米
				string oriAdCate = dgdAdr.Items[i].Cells[5].Text.Trim();
				string transAdCate = "N/A";
				switch(oriAdCate)
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
				dgdAdr.Items[i].Cells[5].Text = transAdCate;

				//廣告位置：轉換成中文
				string oriKeyword = dgdAdr.Items[i].Cells[6].Text.Trim();
				string transKeyword = "N/A";
				switch(oriKeyword)
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
				dgdAdr.Items[i].Cells[6].Text = transKeyword;

			}
		}

		protected object GetDraftTpNm(object drafttp)
		{
			string strReturn = "";
			switch(drafttp.ToString())
			{
				case "1":
					strReturn = "舊稿";
					break;
				case "2":
					strReturn = "新稿";
					break;
				case "3":
					strReturn = "改稿";
					break;
				default:
					break;
			}
			return strReturn;
		}

		protected object GetUrlTpNm(object urltp)
		{
			string strReturn = "";
			switch(urltp.ToString())
			{
				case "1":
					strReturn = "舊稿";
					break;
				case "2":
					strReturn = "新稿";
					break;
				case "3":
					strReturn = "改稿";
					break;
				default:
					break;
			}
			return strReturn;
		}
		#endregion

		#region 選定要修改上稿的落版
		private void dgdAdr_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(dgdAdr.Items[e.Item.ItemIndex].Cells[1].Enabled==false)
				return;
			Advertisements adr = new Advertisements();
			dgdAdr.EditItemIndex = e.Item.ItemIndex;
			string contno = lblContNo.Text.Trim();
			DateTime addate = DateTime.ParseExact(dgdAdr.Items[e.Item.ItemIndex].Cells[3].Text.Trim(), "yyyy/MM/dd", null);
			if (DateTime.Today > addate)
			{
				jsAlertMsg("FILEEXIST", "今天之前的廣告資料不能修改");
				dgdAdr.EditItemIndex = -1;
				Bind_NewAdr(contno);		
				return;
			}
			else
			{
				//檢查logfile中是否有為欲修改資料播出日的紀錄，
				//如果有就發message，要先delete之後才可以修改落版資料
//				Advertisements adr11 = new Advertisements();
				bool xmlExist = adr.CheckXmlFileLog(addate.ToString("yyyyMMdd"));
				if (xmlExist)
				{
					jsAlertMsg("FILEEXIST", "已經產生過該日廣告落版的XML檔案，如要修改廣告落版資料請先刪除該檔案");
					dgdAdr.EditItemIndex = -1;
					Bind_NewAdr(contno);		
					return ;	//廣告資料不能修改
				}
				else
				{
					Bind_NewAdr(contno);
					//廣告圖檔的選單連結
					DropDownList ddlimg = (DropDownList)dgdAdr.Items[dgdAdr.EditItemIndex].Cells[10].FindControl("ddlImgUrl");
					DataView dv = GetDataSource();
					ddlimg.DataSource = dv;
					dv.Sort = "filename ASC";
					ddlimg.DataTextField = "filename";
					ddlimg.DataValueField = "filename";
					ddlimg.DataBind();
				}
			}
		}
		#endregion


		#region 將檔案資訊處理成DataView
		private DataView GetDataSource()
		{
			string path = Server.MapPath("..\\Images");
			string[] imagefiles = Directory.GetFiles(path);
			
			DataTable dt = new DataTable();
			DataColumn dc = new DataColumn("filename");
			dt.Columns.Add(dc);

			for(int i=0; i<imagefiles.Length; i++)
			{
				DataRow dr = dt.NewRow();
				string rawFileName = imagefiles.GetValue(i).ToString();
				dr["filename"] = rawFileName.Substring(rawFileName.LastIndexOf("\\")+1);
				dt.Rows.Add(dr);
			}

			DataRow dr0 = dt.NewRow();
			dr0["filename"] = "";
			dt.Rows.InsertAt(dr0, 0);

			return dt.DefaultView;
		}
		#endregion

		#region 取消落版
		private void dgdAdr_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dgdAdr.EditItemIndex =-1;
			string contno = lblContNo.Text.Trim();
			Bind_NewAdr(contno);		
		}
		#endregion

		#region 儲存上稿的落版
		private void dgdAdr_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//合約邊 號
			string contno = lblContNo.Text.Trim();

			DataGridItem dgi = e.Item;
			//廣告序號
			string seq = dgi.Cells[2].Text.Trim();
			//廣告日期
			string addate = "";
			try
			{
				addate = DateTime.ParseExact(dgi.Cells[3].Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			}
			catch
			{
				throw new Exception("廣告日期格式轉換錯誤");
			}
			//廣告標語
			string alttext = ((TextBox)dgi.Cells[4].Controls[0]).Text.Trim();
			//廣告頁面，hidden column
			//string adcate = dgi.Cells[12].Text.Trim;
			//廣告位置
			//string keyword = dgi.Cells[13].Text.Trim;
			//廣告連結
			string navurl = ((TextBox)dgi.Cells[7].Controls[0]).Text.Trim();
			if (!navurl.ToLower().StartsWith("http://"))
				if (navurl.Trim()!="")
					navurl = "http://" + navurl;
			//播放機率
			//string impr = dgi.Cells[7].Text.Trim;
			//廣告備註
			string remark = ((TextBox)dgi.Cells[9].Controls[0]).Text.Trim();
			//廣告圖檔
			string imgurl = ((DropDownList)dgi.Cells[10].Controls[1]).SelectedItem.Value;
			//圖檔稿類別
			string drafttp = ((DropDownList)dgi.Cells[11].Controls[1]).SelectedItem.Value;
			//網頁槁類別
			string urltp = ((DropDownList)dgi.Cells[12].Controls[1]).SelectedItem.Value;
			//Response.Write("UPDATE c4_adr SET adr_alttext=" + alttext + ", adr_navurl=" + navurl + ", adr_remark=" + remark + ", adr_imgurl=" + imgurl + ", adr_drafttp=" + drafttp + ", adr_urltp=" + urltp + " WHERE adr_syscd='C4 AND adr_contno=" + contno + " AND adr_seq=" + seq + " AND adr_addate=" + addate );

			Advertisements adr = new Advertisements();
			adr.UpdateAdrFileUp(contno, seq, addate, alttext, navurl, remark, imgurl, drafttp, urltp);

			dgdAdr.EditItemIndex =-1;
			Bind_NewAdr(contno);		
		}
		#endregion

		#region 按下Refresh
		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			Bind_ddlImages();
		}
		#endregion

		#region refresh檔案
		private void Bind_ddlImages()
		{
			DataView dv = GetDataSource();
			ddlImages.DataSource = dv;
			dv.Sort = "filename ASC";
			ddlImages.DataTextField = "filename";
			ddlImages.DataValueField = "filename";
			ddlImages.DataBind();			
		}
		#endregion

		#region 批次設定檔案, 勾選項目上稿
		private void btnSetImage_Click(object sender, System.EventArgs e)
		{
			string contno = lblContNo.Text.Trim();

			Advertisements adr = new Advertisements();
			ArrayList ary = new ArrayList();
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				if (((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSel")).Checked)
				{
					string adrseq = dgdAdr.Items[i].Cells[2].Text.Trim();
					//廣告日期
					string addate = "";
					try
					{
						addate = DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
					}
					catch
					{
						throw new Exception("廣告日期格式轉換錯誤");
					}
					string alttext;
					if(cbxAltText.Checked==true)
					//廣告標語要更新
						alttext = tbxAltText.Text.Trim();
					else
						alttext = dgdAdr.Items[i].Cells[4].Text.Trim();
					alttext = this.myTrimEnd(alttext);
					//廣告頁面，hidden column
					//string adcate = dgi.Cells[12].Text.Trim;
					//廣告位置
					//string keyword = dgi.Cells[13].Text.Trim;
					//廣告連結
					string navurl;
					if(cbxLink.Checked==true)
						navurl = tbxNavUrl.Text.Trim();
					else
						navurl = dgdAdr.Items[i].Cells[7].Text.Trim();
					navurl = this.myTrimEnd(navurl);
					if (!navurl.ToLower().StartsWith("http://"))
						if (navurl.Trim()!="")
							navurl = "http://" + navurl;

					//廣告備註
					string remark = dgdAdr.Items[i].Cells[9].Text.Trim();
					remark = this.myTrimEnd(remark);
					//廣告圖檔
					string imgurl;
					if(cbxImage.Checked==true)
						imgurl = ddlImages.SelectedItem.Value.Trim();
					else
						imgurl = ((Label)dgdAdr.Items[i].Cells[10].FindControl("lblImgUrl")).Text.Trim();
					//圖檔稿類別
					string drafttp = "1"; //通通設定為舊槁，再由美編去指定新稿
					//網頁槁類別
					string urltp = "1"; //通通設定為舊槁

					adr.UpdateAdrFileUp(contno, adrseq, addate, alttext, navurl, remark, imgurl, drafttp, urltp);
//					ary.Add(contno + "," + adrseq + "," + addate + "," + alttext + "," + navurl + "," + remark + "," + imgurl + "," + drafttp + "," + urltp);
				}
			}

//			Advertisements adr = new Advertisements();
//
//			for (int i=0; i<ary.Count; i++)
//			{
//				string rawString = (string)ary[i];
//
//
//				string adrseq = ((string)(rawString.Split(',')).GetValue(1));
//
//				string addate = "";
//				try
//				{
//					addate = ((string)(rawString.Split(',')).GetValue(2));
//				}
//				catch(Exception ex)
//				{
//					throw new Exception("無法取得落版日期資料");
//				}
//
//				string alttext = ((string)(rawString.Split(',')).GetValue(3));
//				string navurl = ((string)(rawString.Split(',')).GetValue(4));
//				string remark = ((string)(rawString.Split(',')).GetValue(5));
//				string imgurl = ((string)(rawString.Split(',')).GetValue(6));
//				string drafttp = ((string)(rawString.Split(',')).GetValue(7));
//				string urltp = ((string)(rawString.Split(',')).GetValue(8));
//				//Response.Write(contno + "," + adrseq + "," + addate + "," + alttext + "," + navurl + "," + remark + "," + imgurl + "," + drafttp + "," + urltp);
//
//				adr.UpdateAdrFileUp(contno, adrseq, addate, alttext, navurl, remark, imgurl, drafttp, urltp);
//			}
			
			Bind_NewAdr(contno);
			
			DeSelectAll();
		}
		#endregion

		#region 全選, 清選
		private void DeSelectAll()
		{
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{		
				//先檢查是否Enable
				if (((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSel")).Enabled == true)
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSel")).Checked = false;
				}
			}
		}

		private void btnSelAll_Click(object sender, System.EventArgs e)
		{
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//先檢查是否Enable
				if (((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSel")).Enabled == true)
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSel")).Checked = true;
				}
			}
		}

		private void btnDeSelAll_Click(object sender, System.EventArgs e)
		{
			DeSelectAll();
		}

		#endregion

		#region 批次設定檔案, 日期區間上稿
		private void btnDateSetImage_Click(object sender, System.EventArgs e)
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
				jsAlertMsg("NEGATIVETIMEPERIOD", "不能修改今天之前的廣告資料");
				return;
			}

			Advertisements adr = new Advertisements();
			ArrayList ary = new ArrayList();
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				string adrseq = dgdAdr.Items[i].Cells[2].Text.Trim();
				//廣告日期
				string addate = "";
				try
				{
					addate = DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
				}
				catch
				{
//						throw new Exception("廣告日期格式轉換錯誤");
					jsAlertMsg("SDATEFORMATERROR", "廣告日期格式錯誤");
					return;
				}
				if ((DateTime.ParseExact(sdate, "yyyyMMdd", null) <= DateTime.ParseExact(addate, "yyyyMMdd", null))
					&& (DateTime.ParseExact(addate, "yyyyMMdd", null) <= DateTime.ParseExact(edate, "yyyyMMdd", null)))
				{
//					jsAlertMsg("SDATEFORMATERROR", "廣告日期"+addate);
					string alttext;
					if(cbxAltText.Checked==true)
						//廣告標語要更新
						alttext = tbxAltText.Text.Trim();
					else
						alttext = dgdAdr.Items[i].Cells[4].Text.Trim();
					alttext = this.myTrimEnd(alttext);
					//廣告頁面，hidden column
					//string adcate = dgi.Cells[12].Text.Trim;
					//廣告位置
					//string keyword = dgi.Cells[13].Text.Trim;
					//廣告連結
					string navurl;
					if(cbxLink.Checked==true)
						navurl = tbxNavUrl.Text.Trim();
					else
						navurl = dgdAdr.Items[i].Cells[7].Text.Trim();
					navurl = this.myTrimEnd(navurl);
					if (!navurl.ToLower().StartsWith("http://"))
						if (navurl.Trim()!="")
							navurl = "http://" + navurl;

					//廣告備註
					string remark = dgdAdr.Items[i].Cells[9].Text.Trim();
					remark = this.myTrimEnd(remark);
					//廣告圖檔
					string imgurl;
					if(cbxImage.Checked==true)
						imgurl = ddlImages.SelectedItem.Value.Trim();
					else
						imgurl = ((Label)dgdAdr.Items[i].Cells[10].FindControl("lblImgUrl")).Text.Trim();
					//圖檔稿類別
					string drafttp = "1"; //通通設定為舊槁，再由美編去指定新稿
					//網頁槁類別
					string urltp = "1"; //通通設定為舊槁

					adr.UpdateAdrFileUp(contno, adrseq, addate, alttext, navurl, remark, imgurl, drafttp, urltp);
					//					ary.Add(contno + "," + adrseq + "," + addate + "," + alttext + "," + navurl + "," + remark + "," + imgurl + "," + drafttp + "," + urltp);
				}
			}
			Bind_NewAdr(contno);
			
			DeSelectAll();
		
		}
		#endregion

	}
}
