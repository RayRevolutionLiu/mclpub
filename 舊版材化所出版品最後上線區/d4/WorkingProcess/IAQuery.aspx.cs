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
using MRLPub.d4.DataTypes;
using MRLPub.d4.Configurations;

namespace MRLPub.d4.WorkingProcess
{
	/// <summary>
	/// Summary description for IAQuery.
	/// </summary>
	public class IAQuery : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgdAdr;
		protected System.Web.UI.WebControls.Button btnSearch;
		protected System.Web.UI.WebControls.TextBox tbxDate;
		protected System.Web.UI.WebControls.Label lblDate;
		protected System.Web.UI.WebControls.Button btnSelAll;
		protected System.Web.UI.WebControls.Button btnDeSelAll;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnNextStep;
		protected System.Web.UI.WebControls.Button btnPreStep;
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Button btnOK;
		protected System.Web.UI.WebControls.Panel pnlSelect;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.DataGrid dgdConfirm;
		protected System.Web.UI.WebControls.Panel pnlConfirm;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Literal Literal1;
		protected System.Web.UI.WebControls.Button btnHome;
		protected System.Web.UI.WebControls.Panel pnlBack;
		protected System.Web.UI.WebControls.Panel pnlSearch;
		protected System.Web.UI.WebControls.Label lblyyyymmdd;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!IsClientScriptBlockRegistered("JSCALENDAR"))
			{
				System.IO.TextReader tr = System.IO.File.OpenText(Server.MapPath(".") + "\\ClientScripts\\jsCalendar.js");
				string script = tr.ReadToEnd();
				RegisterClientScriptBlock("JSCALENDAR", script);
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
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			this.btnSelAll.Click += new System.EventHandler(this.btnSelAll_Click);
			this.btnDeSelAll.Click += new System.EventHandler(this.btnDeSelAll_Click);
			this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
			this.btnPreStep.Click += new System.EventHandler(this.btnPreStep_Click);
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSearch_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			if(tbxDate.Text.Trim()=="")
			{
				lblMessage.Text = "<<<�п�J����A�i��d��>>>";
				return;
			}
			DateTime Date1;// = DateTime.Parse(tbxDate.Text.Trim());
			try
			{
				Date1 = DateTime.ParseExact(tbxDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("SDATEERROR", "�I��X�����榡���~�A�Э��s��J");
				return;
			}
			Bind_dgdAdr();
		}
		#region Bind_dgdAdr
		private void Bind_dgdAdr()
		{
			DateTime Date1 = DateTime.Parse(tbxDate.Text.Trim());
			string strDate = Date1.ToString("yyyyMMdd");
			Advertisements adr = new Advertisements();
			DataSet ds = adr.GetAdrForIA(strDate.Trim());
			DataView dv = ds.Tables[0].DefaultView;
			if(dv.Count>0)
			{
				pnlSelect.Visible=true;
				pnlConfirm.Visible = false;
				dgdAdr.Visible=true;
				dgdAdr.DataSource = dv;
				dgdAdr.DataBind();
			
				string strYYYYMM = strDate.Substring(0, 6);
				string yyyymm;
				for (int i=0; i<dgdAdr.Items.Count; i++)
				{
					// �Z�n�� -- �w�藍�P���, ��浹�����P�C��Х�
					// �ӥB�]�w��'�����'���A
					yyyymm = dgdAdr.Items[i].Cells[8].Text.Substring(0, 6);
					//Response.Write("yyyymm= " + yyyymm + "<br>");
					if(yyyymm != strYYYYMM)
					{
						dgdAdr.Items[i].Cells[8].ForeColor = Color.LimeGreen;
						dgdAdr.Items[i].BackColor = Color.MistyRose;//.Lavender;
						((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked = false;
					}
				}
				lblMessage.Text = "<<<�ثe�|�� "+dv.Count.ToString()+" ��������Ʃ|���}�ߵo��!>>>";
			}
			else
			{
				pnlSelect.Visible=false;
				lblMessage.Text = "�S���i�}�ߵo������������";
			}
		}
		#endregion

		#region �榡�Ƽs�i���
		protected object MatchAdCate(object adcate)
		{
			string transAdCate = "";
			switch(adcate.ToString())
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
			return transAdCate;
		}

		protected object MatchKeyword(object keyword)
		{
			string transKeyword = "";
			switch(keyword.ToString())
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
			return transKeyword;
		}

		protected object MatchFgitri(object fgitri)
		{
			string transFgitri = "";
			switch(fgitri.ToString().Trim())
			{
				case "06":
					transFgitri = "�Ҥ�";
					break;
				case "07":
					transFgitri = "�|��";
					break;
				case "":
					transFgitri = "�@��";
					break;
				default:
					throw new Exception("��Ʈw��ͼs�i������ƿ��~�A�гq���p���H");
					break;
			}
			return transFgitri;
		}
		#endregion

		#region ����A�M��
		private void btnSelAll_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//���ˬd�O�_Enable
				if (((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Enabled == true)
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked = true;
				}
			}
		}

		private void btnDeSelAll_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			for (int i=0; i<dgdAdr.Items.Count; i++)
			{
				//���ˬd�O�_Enable
				if (((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Enabled == true)
				{
					((CheckBox)dgdAdr.Items[i].Cells[0].FindControl("cbxSelAdr")).Checked = false;
				}
			}
		}
		#endregion

		#region �U�@�B
		private void btnNextStep_Click(object sender, System.EventArgs e)
		{
			
			Literal1.Text="";
			//�N��Ʈw���ݦs��adr_fginved = 'v'�M�� ''
			Advertisements adr = new Advertisements();
			adr.ClearAdrFginved();

			//�N�Ŀ諸�������adr_fginved = 'v'
			int	i;
			for(i=0; i<dgdAdr.Items.Count; i++)
			{
				if(((CheckBox)dgdAdr.Items[i].FindControl("cbxSelAdr")).Checked == true)
				{
					adr.UpdateAdrFginved(dgdAdr.Items[i].Cells[1].Text.Trim(), dgdAdr.Items[i].Cells[7].Text.Trim(), dgdAdr.Items[i].Cells[8].Text.Trim(), "v");
				}
			}
			//Ū�X���
			DateTime Date1 = DateTime.Parse(tbxDate.Text.Trim());
			string strDate = Date1.ToString("yyyyMMdd");
//			Advertisements adr = new Advertisements();
			DataSet ds = adr.GetAdrForIA(strDate.Trim());
			DataView dv = ds.Tables[0].DefaultView;
			dv.RowFilter = "adr_fginved = 'v'";
			if(dv.Count>0)
			{
				pnlSelect.Visible = false;
				pnlConfirm.Visible = true;
				dgdConfirm.Visible=true;
				dgdConfirm.DataSource = dv;
				dgdConfirm.DataBind();
			
				string strYYYYMM = strDate.Substring(0, 6);
				string yyyymm;
				for (i=0; i<dgdConfirm.Items.Count; i++)
				{
					// �Z�n�� -- �w�藍�P���, ��浹�����P�C��Х�
					yyyymm = dgdConfirm.Items[i].Cells[7].Text.Substring(0, 6);
					//Response.Write("yyyymm= " + yyyymm + "<br>");
					if(yyyymm != strYYYYMM)
					{
						dgdConfirm.Items[i].Cells[7].ForeColor = Color.LimeGreen;
						dgdConfirm.Items[i].BackColor = Color.Lavender;
					}
				}
				lblMessage.Text = "<<<�w��� "+dv.Count.ToString()+" ���������>>>";
			}
			else
			{
				lblMessage.Text = "�S��������󸨪�����";
			}
		}

		#endregion

		#region �W�@�B
		private void btnPreStep_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			
			//�N��Ʈw���ݦs��adr_fginved = 'v'�M�� ''
			Advertisements adr = new Advertisements();
			adr.ClearAdrFginved();

			//Ū�X���
			Bind_dgdAdr();
		}

		#endregion

		#region ����, �N������O�M��, �^����
		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Literal1.Text="";
			Advertisements adr = new Advertisements();
			adr.ClearAdrFginved();
			Response.Redirect("content.htm");
		}
		#endregion

		#region �C�L�w���M��
		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			Invoice inv = new Invoice();
			inv.IAPreList();
			string	strbuf="RptIA_PreList.aspx?whoami=" + this.WhoAmI.CName+"&strdate="+tbxDate.Text.Trim();
			Literal1.Text="<script language=\"javascript\">window.open(\""+strbuf+"\");</script>";
		}
		#endregion

		#region ����iab�Bia�Biad
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			Invoice inv = new Invoice();
			inv.IAPreList();
			string empno = this.WhoAmI.EmpNo.Trim();
			bool flag = inv.AddBatchIa(empno);
			if(flag)
			{
				jsAlertMsg("INVALIDPERIOD", "�s�W�o���}�߳�@�~����!!");
				pnlSearch.Visible = false;
				pnlConfirm.Visible=false;
				pnlBack.Visible=true;
			}
			else
				jsAlertMsg("INVALIDPERIOD", "�s�W�o���}�߳�@�~�o�Ϳ��~, �Э��s�s�W�εy��A�i��");
		}
		#endregion

		#region �^�D���
		private void btnHome_Click(object sender, System.EventArgs e)
		{
			string home = D4Settings.HomeUrl;
			Response.Redirect(home);
		}
		#endregion

	}
}
