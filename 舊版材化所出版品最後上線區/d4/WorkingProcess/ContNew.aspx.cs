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
			
			//�[�Jscript������
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
//			btnNoSave.Attributes["OnClick"] = "JavaScript:confirm('�T�{���x�s���X��(�ߧY�M�����)');";
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

		#region �ƥ��s�W�X���A�]�w�X���ݩʬ��Ȧs
		private string PreAddNewCont()
		{		
			string cont_oldcontno =" ";
			if (Request.QueryString["old_contno"] == null || Request.QueryString["old_contno"] == "")
			{
				jsAlertMsg("PREADDERROR", "�`�N�G���X���L���v�X���ѦҸ��...");
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

		#region �s�����u���
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

		#region ��l�ƵL�ѦҪ����s�X��
		private void InitNewCont()
		{
			string cust_custno;
			if (Request.QueryString["CustNo"] == null || Request.QueryString["CustNo"] == "")
			{
				throw new Exception("�s�W���s�X���ɡA�Ȥ�s�����i���ŭ�");
			}
			else
			{
				cust_custno = Request.QueryString["CustNo"];
			}

			string new_contno = PreAddNewCont(); //�h��Ʈw�s�W�Ȧs�X���A�Ǧ^�s�X�����X���s��

			Customers cust = new Customers();
			SqlDataReader dr = cust.GetMfrCustByCustNo(cust_custno);

			if (dr.Read())
			{
				//�t�ӤΫȤ���
				lblCustNm.Text = dr["cust_nm"].ToString().Trim();
				lblCustNo.Text = cust_custno;
				tbxHidCustNo.Text = cust_custno;
				lblMfrNm.Text = dr["mfr_inm"].ToString().Trim();
				lblMfrNo.Text = dr["cust_mfrno"].ToString().Trim();
				tbxHidMfrNo.Text = dr["cust_mfrno"].ToString().Trim();
				lblMfrTelFax.Text = dr["mfr_tel"].ToString() + "(Fax�G" + dr["mfr_fax"].ToString().Trim() + ")";
				lblRespData.Text = dr["mfr_respnm"].ToString() + "(" + dr["mfr_respjbti"].ToString().Trim() + ")";

				//�X���Ѱ򥻸��
				tbxSignDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
				ddlContTp.SelectedIndex = 0;
				tbxSDate.Text = DateTime.Today.ToString("yyyy/MM/dd");
				tbxEDate.Text = "";
				tbxRemark.Text = "";
				lblContNo.Text = new_contno;
				ddlContTp.SelectedIndex = 0;
				rblPayOnce.SelectedIndex = 1;

				//�X���ѲӸ`
				tbxPubTm.Text = "0";
				tbxFreeTm.Text = "0";
				tbxTotImgTm.Text = "0";
				tbxTotUrlTm.Text = "0";
				tbxTotAmt.Text = "0";
				tbxDisc.Text = "1";

				//�s�i�p���H���
				tbxAuNm.Text = "";
				tbxAuEmail.Text = "";
				tbxAuTel.Text = "";
				tbxAuCell.Text = "";
				tbxAuFax.Text = "";

				//�s�i���s����B�����B���~�]�Ƥ���B���ƯS�ʡB���β��~���������

				//�o���t�Ӧ���H���

				//���x����H���خѸ��
			}
			else
			{
				jsAlertMsg("CUSTMFRNOTFOUND", "�䤣��Ȥ�μt�Ӹ�ơA�гq���p���H");
			}
			dr.Close();
		}
		#endregion

		#region ���^���v�X�����
		private void LoadHistContData()
		{
			string old_contno;
			string new_contno = PreAddNewCont(); //�h��Ʈw�s�W�Ȧs�X���A�Ǧ^�s�X�����X���s��

			if (Request.QueryString["old_contno"] == null || Request.QueryString["old_contno"] == "")
			{
				throw new Exception("���v�X���s�����i���ŭ�");
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
				//�t�ӤΫȤ���
				lblCustNm.Text = dr["cust_nm"].ToString().Trim();
				lblCustNo.Text = dr["cont_custno"].ToString().Trim();
				tbxHidCustNo.Text = dr["cont_custno"].ToString().Trim();
				lblMfrNm.Text = dr["mfr_inm"].ToString().Trim();
				lblMfrNo.Text = dr["cont_mfrno"].ToString().Trim();
				tbxHidMfrNo.Text = dr["cont_mfrno"].ToString().Trim();
				lblMfrTelFax.Text = dr["mfr_tel"].ToString() + "(Fax�G" + dr["mfr_fax"].ToString().Trim() + ")";
				lblRespData.Text = dr["mfr_respnm"].ToString() + "(" + dr["mfr_respjbti"].ToString().Trim() + ")";

				//�X���Ѱ򥻸��
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

				//�X���ѲӸ`
				tbxPubTm.Text = "0";
				tbxFreeTm.Text = "0";
				tbxTotImgTm.Text = "0";
				tbxTotUrlTm.Text = "0";
				tbxTotAmt.Text = "0";
				tbxDisc.Text = "1";

				//�s�i�p���H���
				tbxAuNm.Text = dr["cont_aunm"].ToString().Trim();
				tbxAuEmail.Text = dr["cont_auemail"].ToString().Trim();
				tbxAuTel.Text = dr["cont_autel"].ToString().Trim();
				tbxAuCell.Text = dr["cont_aucell"].ToString().Trim();
				tbxAuFax.Text = dr["cont_aufax"].ToString().Trim();

				//�s�i���s����B�����B���~�]�Ƥ���B���ƯS�ʡB���β��~���������

				//�o���t�Ӧ���H���

				//���x����H���خѸ��
			}
			dr.Close();
		}
		#endregion

		#region ���o�l�H���O�W��
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

		#region �s������H���خѸ��--�ثe���ϥ�
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

		#region ���s��z���x����H���خѸ��--����
//		private void imbRefFreeBk_Click(object sender, System.Web.UI.ImageClickEventArgs e)
//		{
//			Bind_dgdFreeBk(lblContNo.Text.Trim());
//		}
		#endregion

		#region �x�s�X���A�b��Ʈw����s��ƨç���fgtemp
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			string cont_contno = lblContNo.Text.Trim();
			string cont_conttp= ddlContTp.SelectedItem.Value;

			//�������
			DateTime signdate;
			DateTime sdate;
			DateTime edate;

			try
			{
				signdate = DateTime.ParseExact(tbxSignDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("INVALIDSIGNDATE", "�X��ñ��������~�A�Ч�");
				return;
			}

			try
			{
				sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("INVALIDSDATE", "�X���_�l������~�A�Ч�");
				return;
			}

			try
			{
				edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("INVALIDEDATE", "�X������������~�A�Ч�");
				return;
			}

			if (sdate>edate)
			{
				jsAlertMsg("INVALIDPERIOD", "�_�l������i�j�󵲧�����A�Ч�");
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
				jsAlertMsg("INVALIDFREETM", "�ذe���Ʈ榡���~�A�������");
				return;
			}

			int cont_pubtm = 0;
			try
			{
				cont_pubtm = Convert.ToInt32(tbxPubTm.Text.Trim());
			}
			catch
			{
				jsAlertMsg("INVALIDPUBTM", "�Z�n���Ʈ榡���~�A�������");
				return;
			}

			int pubedtm = 0;
			int cont_resttm = cont_pubtm - pubedtm;	//�`�Z�n���� - �w�Z�n(����)����

			int cont_totimgtm = 0;
			try
			{
				cont_totimgtm = Convert.ToInt32(tbxTotImgTm.Text.Trim());
			}
			catch
			{
				jsAlertMsg("INVALIDTOTIMGTM", "�`�s���ɽZ���Ʈ榡���~�A�������");
				return;
			}

			int cont_toturltm = 0;
			try
			{
				cont_toturltm = Convert.ToInt32(tbxTotUrlTm.Text.Trim());
			}
			catch
			{
				jsAlertMsg("INVALIDTOTURLTM", "�`�s�����Z���Ʈ榡���~�A�������");
				return;
			}

			float cont_disc = 0;
			try
			{
				cont_disc = Convert.ToSingle(tbxDisc.Text.Trim());
			}
			catch
			{
				jsAlertMsg("INVALIDDISC", "�u�f��Ʈ榡���~�A�������");
				return;
			}

			float cont_totamt = 0;
			try
			{
				cont_totamt = Convert.ToSingle(tbxTotAmt.Text.Trim());
			}
			catch
			{
				jsAlertMsg("INVALIDTOTAMT", "�X�����B�榡���~�A�������");
				return;
			}

			float cont_paidamt = 0; //�@�}�l���ӳ��٨S�I��
			float cont_restamt = Convert.ToSingle(tbxTotAmt.Text.Trim()); //�@�}�l���O����...
			string cont_remark = tbxRemark.Text.Trim();
			string cont_credate = DateTime.Now.ToString("yyyyMMdd");
			string cont_moddate = DateTime.Now.ToString("yyyyMMdd");
			string cont_modempno = this.WhoAmI.EmpNo;
			string cong_fgpayonce = rblPayOnce.SelectedItem.Value;
			
			//���~�]�Ƥ���B�s�i���s����B�j�M����
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
					jsAlertMsg("INVALIDCSDATE", "[�j�M����]<BR>�L�k�ഫ����榡�A�Э��s��J�X�k������A�p2003/01/01");
					return;
				}
			}

			Contracts cont = new Contracts();
			bool success = cont.UpdateToBeFormal(cont_contno, cont_conttp, cont_signdate, cont_sdate, cont_edate, cont_empno, cont_mfrno, cont_custno, 
								cont_aunm, 	cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_freetm, cont_pubtm, 
								cont_resttm, cont_totimgtm, cont_toturltm, cont_disc, cont_totamt, cont_paidamt, cont_restamt, 
								cont_remark, cont_credate, cont_moddate, cont_modempno, cong_fgpayonce, cont_ccont, cont_pdcont, cont_csdate);

			//�ˬd�X���O�_�����x�s���\
			if (success)
			{
				jsAlertMsg("SAVECONTSUCCESS", "�X���x�s���\�A�i�~��q���i�渨���Ψ�L�����Ʃy");
				//btnSave.Visible = false;
				//btnNoSave.Visible = false;
				pnlBack.Visible = true;
				pnlContBody.Visible = false;
			}
			else
			{
				jsAlertMsg("SAVECONTFAILED", "�X���x�s���ѡA�t�Υi��X���A�гq���p���H");
			}
		}
		#endregion

		#region �R�����Ȧs�X��
		private void btnNoSave_Click(object sender, System.EventArgs e)
		{
			string contno = lblContNo.Text.Trim();
				Contracts cont = new Contracts();
				cont.DeleteContTemp(contno);

				jsAlertMsg("DELETECONTFAILED", "�Ȧs��Ƥw�g�M���A���~���L�\��B�z");

				//btnSave.Visible = false;
				//btnNoSave.Visible = false;
				pnlBack.Visible = true;
				pnlContBody.Visible = false;
		}
		#endregion

		#region Show���β��~�Χ��ƯS��
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
				//�̫�@��
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
				//�̫�@��
				dr=dt.NewRow();
				dr["cls2_cname"]=strcls2;
				dr["cls3_cname"]=strcls3;
				dt.Rows.Add(dr);
				dgdAtpMatp2.DataSource = dt;
				dgdAtpMatp2.DataBind();
			}

		}
		#endregion

		#region Show���x����H���خѸ��
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

		#region Show�o���t�Ӹ��
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

		#region �^�D���
		private void btnHome_Click(object sender, System.EventArgs e)
		{
			string home = D4Settings.HomeUrl;
			Response.Redirect(home);
		}
		#endregion

		#region ��J�X�����������p��Ѽ�
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
				jsAlertMsg("SDATEERROR", "�X���_�l����榡���~�A�L�k�Ψӭp��϶��Ѽ�");
				return;
			}

			try
			{
				edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("EDATEERROR", "�X����������榡���~�A�L�k�Ψӭp��϶��Ѽ�");
				return;
			}
			if (sdate>edate)
			{
				jsAlertMsg("INVALIDPERIOD", "�_�l������i�j�󵲧�����A�Ч�");
				return;
			}

			double pubdays = ((TimeSpan)edate.Subtract(sdate)).TotalDays + 1;

			tbxPubTm.Text = pubdays.ToString();
		}
		#endregion

		#region �Q�ΦX���_�W����p�⦸��
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
				jsAlertMsg("SDATEERROR", "�X���_�l����榡���~�A�L�k�Ψӭp��϶��Ѽ�");
				return;
			}

			try
			{
				edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("EDATEERROR", "�X����������榡���~�A�L�k�Ψӭp��϶��Ѽ�");
				return;
			}

			double pubdays = ((TimeSpan)edate.Subtract(sdate)).TotalDays + 1;

			tbxPubTm.Text = pubdays.ToString();		

		}
		#endregion
	}
}
