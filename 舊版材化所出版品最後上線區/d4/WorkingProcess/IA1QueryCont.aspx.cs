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
using MRLPub.d4.DataTypes;
using MRLPub.d4.Configurations;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for IA1QueryCont.
	/// </summary>
	public class IA1QueryCont : MRLPub.d4.Pages.Page
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
		protected System.Web.UI.WebControls.Label lblTotUrlTm;
		protected System.Web.UI.WebControls.DataGrid dgdAdr;
		protected System.Web.UI.WebControls.Button btnSelAll;
		protected System.Web.UI.WebControls.Panel pnlAdr;
		protected System.Web.UI.WebControls.Button btnConfirmSelected;
		protected System.Web.UI.WebControls.Label lblAdrInfo;
		protected System.Web.UI.WebControls.Button btnDeSelAll;
		protected System.Web.UI.WebControls.DropDownList ddlInvMfr;
		protected System.Web.UI.WebControls.Label lblContInfo;
		protected System.Web.UI.WebControls.Label lblSelectInvMfr;
		protected System.Web.UI.WebControls.Panel pnlOptions;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				SwitchStep(1);
				string contno = Request.QueryString["ContNo"];
				LoadContData(contno);
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
			this.ddlInvMfr.SelectedIndexChanged += new System.EventHandler(this.ddlInvMfr_SelectedIndexChanged);
			this.btnSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
			this.btnDeSelAll.Click += new System.EventHandler(this.btnDeSelAll_Click);
			this.btnConfirmSelected.Click += new System.EventHandler(this.btnConfirmSelected_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SwitchStep(int step)
		{
			switch(step)
			{
				case 0:
					//初始化
//					pnlCont.Visible = false;
					pnlAdr.Visible = false;
//					pnlList.Visible = false;
					break;
				case 1:
					//選定合約，顯示廣告
//					pnlCont.Visible = true;
					pnlAdr.Visible = true;
//					pnlList.Visible = false;
					break;
				case 2:
					//勾選後Check?
//					pnlCont.Visible = true;
					pnlAdr.Visible = true;
//					pnlList.Visible = true;
					break;
				case 3:
					break;
				default:
					break;

			}
		}


		#region 載入合約資料
		private void LoadContData(string contno)
		{
			if (contno.Trim() == "")
				throw new Exception("合約編號不可為空白");

			SwitchStep(1);
			Contracts cont = new Contracts();
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

				//Message
				lblContInfo.Text = "本合約基本資料";
//				tblCont.Visible = true;

				//Load InvMfr
				Bind_ddlInvMfr(contno);

				//Load Advertisements
				LoadAdr(contno);
				MatchCheckBox();
				string imseq = Request.QueryString["ImSeq"];
				if(imseq!="00")
				{
					ddlInvMfr.Items.FindByValue(imseq.Trim()).Selected=true;
					for (int i=0; i<dgdAdr.Items.Count; i++)
					{
						if (((Label)dgdAdr.Items[i].FindControl("lblEInfMfr")).Text.Trim() == ddlInvMfr.SelectedItem.Text.Trim())
						{
							((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Enabled = true;
							dgdAdr.Items[i].ForeColor=System.Drawing.Color.Red;
						}
						else
						{
							//					((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Checked = false;
							((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Enabled = false;
							dgdAdr.Items[i].ForeColor=System.Drawing.Color.Black;
						}
					}
				}
			}
			else
			{
				//Message
				lblContInfo.Text = "無此編號的合約資料，請確認合約編號";
//				tblCont.Visible = false;
			}
			dr.Close();
		}
		#endregion

		#region 載入合約的廣告落版資料
		private void LoadAdr(string contno)
		{
			if (contno == null || contno.Trim().Length != 6)
			{
				jsAlertMsg("CONTNODATAERROR", "合約編號為空值或格式錯誤，請通知聯絡人");
				return;
			}

			Advertisements adr = new Advertisements();
			DataSet ds = adr.GetAdvertisements(contno);
			DataView dv = ds.Tables[0].DefaultView;
			dv.RowFilter="adr_fginved <> '1'";
			dgdAdr.DataSource = dv;
			dgdAdr.DataBind();

			if (dv.Count>0)
			{
				lblAdrInfo.Text = "本合約廣告資料";
				dgdAdr.Visible = true;
				pnlOptions.Visible = true;
				MatchCheckBox();
				//				FormatAdr();
			}
			else
			{
				lblAdrInfo.Text = "本合約尚無廣告資料";
				dgdAdr.Visible = false;
				pnlOptions.Visible = false;
			}
		}
		#endregion

		#region 第一次讀入廣告落版資料時，把以前tag的落版標示出來
		private void MatchCheckBox()
		{
			//只有第一次載入才要做，所以要獨立出來
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				if (dgdAdr.Items[i].Cells[15].Text.Trim() == "v")
				{
					((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Checked = true;
				}
			}
		}
		#endregion

		#region 連結發票廠商下拉式選單
		private void Bind_ddlInvMfr(string contno)
		{

			string imseq = Request.QueryString["ImSeq"];
			InvMfrs im = new InvMfrs();
			DataSet ds = im.GetInvMfr(contno);
			DataRow dr;
			dr=ds.Tables[0].NewRow();
			dr["im_nm"]="請選擇...";
			dr["im_imseq"]="00";
			ds.Tables[0].Rows.Add(dr);
			DataView dv = ds.Tables[0].DefaultView;

			ddlInvMfr.DataTextField = "im_nm";
			ddlInvMfr.DataValueField = "im_imseq";
			ddlInvMfr.DataSource = dv;
			ddlInvMfr.DataBind();
//			if(imseq=="")
//				ddlInvMfr.Items.FindByValue("00").Selected=true;
//			else
				ddlInvMfr.Items.FindByValue(imseq.Trim()).Selected=true;
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
				throw new Exception("資料庫原生發票廠商資料錯誤，請通知聯絡人");
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

				//檢查日期
				if (DateTime.Today >= DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyyMMdd", null))
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked = false;
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Enabled = false;
				}


				//廣告日期：轉換為yyyy/MM/dd
				dgdAdr.Items[i].Cells[3].Text = DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyyMMdd", null).ToString("yyyy/MM/dd");

				
				//--------------已經改版
				//				//廣告頁面：轉換為首頁、內頁、奈米
				//				string oriAdCate = dgdAdr.Items[i].Cells[5].Text.Trim();
				//				string transAdCate = "N/A";
				//				switch(oriAdCate)
				//				{
				//					case "M":
				//						transAdCate = "首頁";
				//						break;
				//					case "I":
				//						transAdCate = "內頁";
				//						break;
				//					case "N":
				//						transAdCate = "奈米";
				//						break;
				//					default:
				//						throw new Exception("資料庫原生廣告頁面資料錯誤，請通知聯絡人");
				//						break;
				//				}
				//				dgdAdr.Items[i].Cells[5].Text = transAdCate;
				//				//廣告位置：轉換成中文
				//				string oriKeyword = ((Label)dgdAdr.Items[i].Cells[6].FindControl("lblEKeyword")).Text.Trim();
				//				string transKeyword = "N/A";
				//				switch(oriKeyword)
				//				{
				//					case "h0":
				//						transKeyword = "正中";
				//						break;
				//					case "h1":
				//						transKeyword = "右一";
				//						break;
				//					case "h2":
				//						transKeyword = "右二";
				//						break;
				//					case "h3":
				//						transKeyword = "右三";
				//						break;
				//					case "h4":
				//						transKeyword = "右四";
				//						break;
				//					case "w1":
				//						transKeyword = "右文一";
				//						break;
				//					case "w2":
				//						transKeyword = "右文二";
				//						break;
				//					case "w3":
				//						transKeyword = "右文三";
				//						break;
				//					case "w4":
				//						transKeyword = "右文四";
				//						break;
				//					case "w5":
				//						transKeyword = "右文五";
				//						break;
				//					case "w6":
				//						transKeyword = "右文六";
				//						break;
				//					default:
				//						throw new Exception("資料庫原生廣告位置資料錯誤，請通知聯絡人");
				//						break;
				//				}
				//				dgdAdr.Items[i].Cells[6].Text = transKeyword;
				//				//發票廠商：取姓名
				//				string oriImSeq = ((Label)dgdAdr.Items[i].Cells[6].FindControl("lblEInvMfr")).Text.Trim();
				//				dgdAdr.Items[i].Cells[12].Text = ddlInvMfr.Items.FindByValue(oriImSeq).Text.Trim();
			}
		}
		#endregion

		#region 全選，清選
		private void btnSelAll_Click(object sender, System.EventArgs e)
		{
//			for (int i=0; i<dgdAdr.Items.Count; i++)
//			{
//				//先檢查日期
//				if (DateTime.Today >= DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyy/MM/dd", null))
//				{
//					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked = false;
//					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Enabled = false;
//				}
//				else
//				{
//					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked = true;
//				}
//			}

//			LoadAdr(lblContNo.Text.Trim());
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//先檢查是否Enable
				if (((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Enabled == true)
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked = true;
				}
			}
		}

		private void btnDeSelAll_Click(object sender, System.EventArgs e)
		{
//			for (int i=0; i<dgdAdr.Items.Count; i++)
//			{
//				//先檢查日期
//				if (DateTime.Today >= DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyy/MM/dd", null))
//				{
//					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Enabled = false;
//				}
//
//				((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxDelAdr")).Checked = false;
//			}	
//			LoadAdr(lblContNo.Text.Trim());	
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//先檢查是否Enable
				if (((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Enabled == true)
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked = false;
				}
			}
		}
		#endregion

		#region 確定已經勾選的廣告資料，再做一次整理與統計，以發票廠商收件人、廣告日期為sort
		private void btnConfirmSelected_Click(object sender, System.EventArgs e)
		{
//			Bind_dlList(contno);
			int j=0;
			Advertisements adr = new Advertisements();
			for(int i=0; i<dgdAdr.Items.Count; i++){
				if((((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Enabled == true) && (((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Checked == true))
				{
					adr.UpdateAdrFginved(lblContNo.Text.Trim(), dgdAdr.Items[i].Cells[1].Text.Trim(), dgdAdr.Items[i].Cells[2].Text.Trim(), "v");
					j++;
				}
				else if((((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Enabled == true) && (((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Checked == false))
				{
					adr.UpdateAdrFginved(lblContNo.Text.Trim(), dgdAdr.Items[i].Cells[1].Text.Trim(), dgdAdr.Items[i].Cells[2].Text.Trim(), "");
				}
				//				else
//					adr.UpdateAdrFginved(lblContNo.Text.Trim(), dgdAdr.Items[i].Cells[1].Text.Trim(), dgdAdr.Items[i].Cells[2].Text.Trim(), "");
			}
			if(j>0)
				Response.Redirect("IA1ConfirmChecked.aspx?ContNo="+lblContNo.Text.Trim()+"&Imseq="+ddlInvMfr.SelectedItem.Value.Trim());
			else
				jsAlertMsg("", "您沒有選取落版資料!!");
		}
		#endregion

		private void ddlInvMfr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				if (((Label)dgdAdr.Items[i].FindControl("lblEInfMfr")).Text.Trim() == ddlInvMfr.SelectedItem.Text.Trim())
				{
					((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Enabled = true;
					dgdAdr.Items[i].ForeColor=System.Drawing.Color.Red;
				}
				else
				{
//					((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Checked = false;
					((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Enabled = false;
					dgdAdr.Items[i].ForeColor=System.Drawing.Color.Black;
				}
			}
		}


	}
}
