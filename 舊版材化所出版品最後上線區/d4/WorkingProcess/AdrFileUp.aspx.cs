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
				//�ˬd�ܼơA�o�ˤj���i�H�L�o�@��
				string new_contno = "";
				if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
				{
					throw new Exception("�䤣��X���s��");
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

		#region ���J�X���򥻸��
		private void LoadContInfo(string contno)
		{
			if (contno.Trim() == "")
				throw new Exception("�X���s�����i���ť�");

			Contracts cont;

			cont = new Contracts();
			SqlDataReader dr = cont.GetSingleContractByContNo(contno);
			if (dr.Read())
			{
				lblContNo.Text = dr["cont_contno"].ToString();

				switch(dr["cont_conttp"].ToString().Trim())
				{
					case "01":
						lblContTp.Text = "�@��";
						break;
					case "09":
						lblContTp.Text = "���s";
						break;
					default:
						lblContTp.Text = "(�L�k����)";
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

		#region �s���s�i���
		private void Bind_NewAdr(string contno)
		{
			if (contno == null || contno.Trim().Length != 6)
			{
				jsAlertMsg("CONTNODATAERROR", "�X���s�����ŭȩή榡���~�A�гq���p���H");
				return;
			}
			Advertisements adr = new Advertisements();
			DataSet ds = adr.GetAdvertisements(contno);
			DataView dv = ds.Tables[0].DefaultView;

			dgdAdr.DataSource = dv;
			dgdAdr.DataBind();

			if (dv.Count>0)
			{
//				lblAdrInfo.Text = "���X���s�i�������";
				pnlAdr.Visible = true;
				FormatAdr();
			}
			else
			{
				lblMessage.Text = "���X���|�L�s�i�������";
				pnlAdr.Visible = false;
			}
		}
		#endregion

		#region �榡�Ƽs�i���
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
					throw new Exception("����榡���šA��Ʈw����榡���~");
				}

				//checkbox��disable�p�󤵤Ѫ���Ƥ���ק�
				if (addate<DateTime.Today)
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSel")).Enabled = false;
					dgdAdr.Items[i].Cells[1].Enabled = false;
				}

				//�s�i����G�ഫ��yyyy/MM/dd
				dgdAdr.Items[i].Cells[3].Text = addate.ToString("yyyy/MM/dd");
				
				//�s�i�����G�ഫ�������B�����B�`��
				string oriAdCate = dgdAdr.Items[i].Cells[5].Text.Trim();
				string transAdCate = "N/A";
				switch(oriAdCate)
				{
					case "M":
						transAdCate = "����";
						break;
					case "I":
						transAdCate = "����";
						break;
					case "N":
						transAdCate = "�`��";
						break;
					default:
						throw new Exception("��Ʈw��ͼs�i������ƿ��~�A�гq���p���H");
						break;
				}
				dgdAdr.Items[i].Cells[5].Text = transAdCate;

				//�s�i��m�G�ഫ������
				string oriKeyword = dgdAdr.Items[i].Cells[6].Text.Trim();
				string transKeyword = "N/A";
				switch(oriKeyword)
				{
					case "h0":
						transKeyword = "����";
						break;
					case "h1":
						transKeyword = "�k�@";
						break;
					case "h2":
						transKeyword = "�k�G";
						break;
					case "h3":
						transKeyword = "�k�T";
						break;
					case "h4":
						transKeyword = "�k�|";
						break;
					case "w1":
						transKeyword = "�k��@";
						break;
					case "w2":
						transKeyword = "�k��G";
						break;
					case "w3":
						transKeyword = "�k��T";
						break;
					case "w4":
						transKeyword = "�k��|";
						break;
					case "w5":
						transKeyword = "�k�夭";
						break;
					case "w6":
						transKeyword = "�k�夻";
						break;
					default:
						throw new Exception("��Ʈw��ͼs�i��m��ƿ��~�A�гq���p���H");
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
					strReturn = "�½Z";
					break;
				case "2":
					strReturn = "�s�Z";
					break;
				case "3":
					strReturn = "��Z";
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
					strReturn = "�½Z";
					break;
				case "2":
					strReturn = "�s�Z";
					break;
				case "3":
					strReturn = "��Z";
					break;
				default:
					break;
			}
			return strReturn;
		}
		#endregion

		#region ��w�n�ק�W�Z������
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
				jsAlertMsg("FILEEXIST", "���Ѥ��e���s�i��Ƥ���ק�");
				dgdAdr.EditItemIndex = -1;
				Bind_NewAdr(contno);		
				return;
			}
			else
			{
				//�ˬdlogfile���O�_�������ק��Ƽ��X�骺�����A
				//�p�G���N�omessage�A�n��delete����~�i�H�ק︨�����
//				Advertisements adr11 = new Advertisements();
				bool xmlExist = adr.CheckXmlFileLog(addate.ToString("yyyyMMdd"));
				if (xmlExist)
				{
					jsAlertMsg("FILEEXIST", "�w�g���͹L�Ӥ�s�i������XML�ɮסA�p�n�ק�s�i������ƽХ��R�����ɮ�");
					dgdAdr.EditItemIndex = -1;
					Bind_NewAdr(contno);		
					return ;	//�s�i��Ƥ���ק�
				}
				else
				{
					Bind_NewAdr(contno);
					//�s�i���ɪ����s��
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


		#region �N�ɮ׸�T�B�z��DataView
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

		#region ��������
		private void dgdAdr_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			dgdAdr.EditItemIndex =-1;
			string contno = lblContNo.Text.Trim();
			Bind_NewAdr(contno);		
		}
		#endregion

		#region �x�s�W�Z������
		private void dgdAdr_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//�X���� ��
			string contno = lblContNo.Text.Trim();

			DataGridItem dgi = e.Item;
			//�s�i�Ǹ�
			string seq = dgi.Cells[2].Text.Trim();
			//�s�i���
			string addate = "";
			try
			{
				addate = DateTime.ParseExact(dgi.Cells[3].Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			}
			catch
			{
				throw new Exception("�s�i����榡�ഫ���~");
			}
			//�s�i�лy
			string alttext = ((TextBox)dgi.Cells[4].Controls[0]).Text.Trim();
			//�s�i�����Ahidden column
			//string adcate = dgi.Cells[12].Text.Trim;
			//�s�i��m
			//string keyword = dgi.Cells[13].Text.Trim;
			//�s�i�s��
			string navurl = ((TextBox)dgi.Cells[7].Controls[0]).Text.Trim();
			if (!navurl.ToLower().StartsWith("http://"))
				if (navurl.Trim()!="")
					navurl = "http://" + navurl;
			//������v
			//string impr = dgi.Cells[7].Text.Trim;
			//�s�i�Ƶ�
			string remark = ((TextBox)dgi.Cells[9].Controls[0]).Text.Trim();
			//�s�i����
			string imgurl = ((DropDownList)dgi.Cells[10].Controls[1]).SelectedItem.Value;
			//���ɽZ���O
			string drafttp = ((DropDownList)dgi.Cells[11].Controls[1]).SelectedItem.Value;
			//�����`���O
			string urltp = ((DropDownList)dgi.Cells[12].Controls[1]).SelectedItem.Value;
			//Response.Write("UPDATE c4_adr SET adr_alttext=" + alttext + ", adr_navurl=" + navurl + ", adr_remark=" + remark + ", adr_imgurl=" + imgurl + ", adr_drafttp=" + drafttp + ", adr_urltp=" + urltp + " WHERE adr_syscd='C4 AND adr_contno=" + contno + " AND adr_seq=" + seq + " AND adr_addate=" + addate );

			Advertisements adr = new Advertisements();
			adr.UpdateAdrFileUp(contno, seq, addate, alttext, navurl, remark, imgurl, drafttp, urltp);

			dgdAdr.EditItemIndex =-1;
			Bind_NewAdr(contno);		
		}
		#endregion

		#region ���URefresh
		private void btnRefresh_Click(object sender, System.EventArgs e)
		{
			Bind_ddlImages();
		}
		#endregion

		#region refresh�ɮ�
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

		#region �妸�]�w�ɮ�, �Ŀﶵ�ؤW�Z
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
					//�s�i���
					string addate = "";
					try
					{
						addate = DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
					}
					catch
					{
						throw new Exception("�s�i����榡�ഫ���~");
					}
					string alttext;
					if(cbxAltText.Checked==true)
					//�s�i�лy�n��s
						alttext = tbxAltText.Text.Trim();
					else
						alttext = dgdAdr.Items[i].Cells[4].Text.Trim();
					alttext = this.myTrimEnd(alttext);
					//�s�i�����Ahidden column
					//string adcate = dgi.Cells[12].Text.Trim;
					//�s�i��m
					//string keyword = dgi.Cells[13].Text.Trim;
					//�s�i�s��
					string navurl;
					if(cbxLink.Checked==true)
						navurl = tbxNavUrl.Text.Trim();
					else
						navurl = dgdAdr.Items[i].Cells[7].Text.Trim();
					navurl = this.myTrimEnd(navurl);
					if (!navurl.ToLower().StartsWith("http://"))
						if (navurl.Trim()!="")
							navurl = "http://" + navurl;

					//�s�i�Ƶ�
					string remark = dgdAdr.Items[i].Cells[9].Text.Trim();
					remark = this.myTrimEnd(remark);
					//�s�i����
					string imgurl;
					if(cbxImage.Checked==true)
						imgurl = ddlImages.SelectedItem.Value.Trim();
					else
						imgurl = ((Label)dgdAdr.Items[i].Cells[10].FindControl("lblImgUrl")).Text.Trim();
					//���ɽZ���O
					string drafttp = "1"; //�q�q�]�w���º`�A�A�Ѭ��s�h���w�s�Z
					//�����`���O
					string urltp = "1"; //�q�q�]�w���º`

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
//					throw new Exception("�L�k���o����������");
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

		#region ����, �M��
		private void DeSelectAll()
		{
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{		
				//���ˬd�O�_Enable
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
				//���ˬd�O�_Enable
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

		#region �妸�]�w�ɮ�, ����϶��W�Z
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
				jsAlertMsg("SDATEFORMATERROR", "�_�l����榡���~");
				return;
			}

			string edate;
			try
			{
				edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
			}
			catch(Exception ex)
			{
				jsAlertMsg("EDATEFORMATERROR", "��������榡���~");
				return;
			}

			if (DateTime.ParseExact(sdate, "yyyyMMdd", null) > DateTime.ParseExact(edate, "yyyyMMdd", null))
			{
				jsAlertMsg("NEGATIVETIMEPERIOD", "�_�l������i�H�񵲧�����j");
				return;
			}

			if (DateTime.ParseExact(sdate, "yyyyMMdd", null) < DateTime.Today)
			{
				jsAlertMsg("NEGATIVETIMEPERIOD", "����ק蘆�Ѥ��e���s�i���");
				return;
			}

			Advertisements adr = new Advertisements();
			ArrayList ary = new ArrayList();
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				string adrseq = dgdAdr.Items[i].Cells[2].Text.Trim();
				//�s�i���
				string addate = "";
				try
				{
					addate = DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
				}
				catch
				{
//						throw new Exception("�s�i����榡�ഫ���~");
					jsAlertMsg("SDATEFORMATERROR", "�s�i����榡���~");
					return;
				}
				if ((DateTime.ParseExact(sdate, "yyyyMMdd", null) <= DateTime.ParseExact(addate, "yyyyMMdd", null))
					&& (DateTime.ParseExact(addate, "yyyyMMdd", null) <= DateTime.ParseExact(edate, "yyyyMMdd", null)))
				{
//					jsAlertMsg("SDATEFORMATERROR", "�s�i���"+addate);
					string alttext;
					if(cbxAltText.Checked==true)
						//�s�i�лy�n��s
						alttext = tbxAltText.Text.Trim();
					else
						alttext = dgdAdr.Items[i].Cells[4].Text.Trim();
					alttext = this.myTrimEnd(alttext);
					//�s�i�����Ahidden column
					//string adcate = dgi.Cells[12].Text.Trim;
					//�s�i��m
					//string keyword = dgi.Cells[13].Text.Trim;
					//�s�i�s��
					string navurl;
					if(cbxLink.Checked==true)
						navurl = tbxNavUrl.Text.Trim();
					else
						navurl = dgdAdr.Items[i].Cells[7].Text.Trim();
					navurl = this.myTrimEnd(navurl);
					if (!navurl.ToLower().StartsWith("http://"))
						if (navurl.Trim()!="")
							navurl = "http://" + navurl;

					//�s�i�Ƶ�
					string remark = dgdAdr.Items[i].Cells[9].Text.Trim();
					remark = this.myTrimEnd(remark);
					//�s�i����
					string imgurl;
					if(cbxImage.Checked==true)
						imgurl = ddlImages.SelectedItem.Value.Trim();
					else
						imgurl = ((Label)dgdAdr.Items[i].Cells[10].FindControl("lblImgUrl")).Text.Trim();
					//���ɽZ���O
					string drafttp = "1"; //�q�q�]�w���º`�A�A�Ѭ��s�h���w�s�Z
					//�����`���O
					string urltp = "1"; //�q�q�]�w���º`

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
