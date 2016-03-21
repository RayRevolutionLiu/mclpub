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
	/// Summary description for AdrGenXml.
	/// </summary>
	public class AdrGenXml : MRLPub.d4.Pages.Page
	{
		protected System.Web.UI.WebControls.Calendar calDates;
		protected System.Web.UI.WebControls.RegularExpressionValidator rdvAdDate;
		protected System.Web.UI.WebControls.Button btnQueryPublish;
		protected System.Web.UI.WebControls.Panel pnlAdr;
		protected System.Web.UI.WebControls.DataGrid dgdAdr;
		protected System.Web.UI.WebControls.Button btnGenXml;
		protected System.Web.UI.WebControls.TextBox tbxSelDate;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox tbxAdDate;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				//�u���ڦۤv�ݳo�Ӹ��:>
				if (this.WhoAmI.EmpNo.Trim() != "900103")
				{
					TextBox1.Visible = false;
				}
				pnlAdr.Visible = false;
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
			this.btnQueryPublish.Click += new System.EventHandler(this.btnQueryPublish_Click);
			this.calDates.SelectionChanged += new System.EventHandler(this.calDates_SelectionChanged);
			this.btnGenXml.Click += new System.EventHandler(this.btnGenXml_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region ��w���
		private void calDates_SelectionChanged(object sender, System.EventArgs e)
		{
			tbxAdDate.Text = calDates.SelectedDate.ToString("yyyy/MM/dd");
			
			//�@��w�N�⸨���ð_��
			pnlAdr.Visible = false;
		}
		#endregion

		#region �a�J�s�i�����W�Z���
		private void btnQueryPublish_Click(object sender, System.EventArgs e)
		{
			if (tbxAdDate.Text.Trim() == "")
			{
				jsAlertMsg("EMPTYDATE", "�d�ߤ�����i���ŭ�");
				return;
			}			

			DateTime addate;
			try
			{
				addate = DateTime.ParseExact(tbxAdDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("DATECONVERSIONFAIL", "��J���~��餣�X�z�A�Э��s��J");
				return;
			}

			//OK�F�N�i�H�}�l�d��
			Advertisements adr = new Advertisements();
			DataSet ds = adr.GetAdrPublishFileUp(addate.ToString("yyyyMMdd"));
			DataView dv = ds.Tables[0].DefaultView;
			dv.Sort = "sort_adcate DESC, sort_keyword ASC";

			if (dv.Count>0)
			{
				pnlAdr.Visible = true;
				dgdAdr.DataSource = dv;
				dgdAdr.DataBind();
			}
			else
			{
				pnlAdr.Visible = false;
				jsAlertMsg("NOADR", "�Ӥ�|�L�s�i����");
			}

			//�]�wbutton��r
			btnGenXml.Text = "����" + tbxAdDate.Text + "���s�i���X��";
			
			//���íȡA���F�קKuser�S�]�htextbox��J���..but..not gen�ɮ�
			tbxSelDate.Text = tbxAdDate.Text;
		}
		#endregion

		#region ����xml�ɮ�
		private void btnGenXml_Click(object sender, System.EventArgs e)
		{
			string path = Server.MapPath("..\\XmlFiles") + "\\";
			string filename = DateTime.ParseExact(tbxSelDate.Text, "yyyy/MM/dd", null).ToString("yyyyMMdd") + ".xml";
			DateTime addate;
			try
			{
				addate = DateTime.ParseExact(tbxSelDate.Text.Trim(), "yyyy/MM/dd", null);
			}
			catch
			{
				jsAlertMsg("PARSEDATEFAIL", "�ഫ����榡���ѡA�гq���p���H");
				return;
			}

			Advertisements adr = new Advertisements();
			DataSet ds = adr.GetAdrXmlData(addate.ToString("yyyyMMdd"));

			//���F�O�I�_���A�A�]�w�@��
			ds.DataSetName = "Advertisements";
			ds.Tables[0].TableName = "Ad";

			TextBox1.Text = ds.GetXml();

			//�g�XXML
			string filepath = Server.MapPath("..") + "\\XmlFiles\\" + addate.ToString("yyyyMMdd") + ".xml";

			if (System.IO.File.Exists(filepath))
			{
				jsAlertMsg("FILEEXIST", "�ɮפw�g�s�b�A�Ш�xml�ɮ׺��@(�R��)��A�A���ͤ@��");
				return;
			}

			try
			{
				ds.WriteXml(filepath);
				jsAlertMsg("GENXMLSUCCESS", addate.ToString("yyyyMMdd") +".xml ���ͦ��\");
			}
			catch(Exception ex)
			{
				jsAlertMsg("GENXMLFAILED", "����xml�ɮ׮ɵo�Ϳ��~�A�гq���p���H");
			}
			pnlAdr.Visible = false;

			adr.UpdateXmlFileLog(addate.ToString("yyyyMMdd"));
		}
		#endregion
	}
}
