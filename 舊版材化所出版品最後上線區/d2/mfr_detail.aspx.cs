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
// Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for mfr_detail.
	/// </summary>
	public class mfr_detail : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblMfrRespName;
		protected System.Web.UI.WebControls.Label lblMfrRespJobTitle;
		protected System.Web.UI.WebControls.Label lblMfrTel;
		protected System.Web.UI.WebControls.Label lblMfrID;
		protected System.Web.UI.WebControls.Label lblMfrName;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Web.UI.WebControls.Label lblMfrIName;
		protected System.Web.UI.WebControls.Label lblMfrRegDate;
		protected System.Web.UI.WebControls.Label lblMfrIZipcode;
		protected System.Web.UI.WebControls.Label lblMfrIAddr;
		protected System.Web.UI.WebControls.Label lblMfrFax;

		public mfr_detail()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}


		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires = 0;

			if (!Page.IsPostBack)
			{
				Response.Expires = 0;


				// �ǥѫe�@�����ǨӪ��ܼƭȦr�� mfrno
				string mfrno = "";
				if(Context.Request.QueryString["mfrno"].ToString().Trim() != "")
				{
					mfrno = Context.Request.QueryString["mfrno"].ToString().Trim();
					//Response.Write("mfrno= " + mfrno + "<br>");

					// �ˬd���t�Ӳνs�O�_�b��Ʈw���s�b
					CheckExist();

				}
				else
				{
					Response.Write("<font size=2 color=red><b>��Ʈw���L�� �t�Ӳνs�Ψ���, �Х�<A HREF='../d5/mfr_addnew.aspx' Target='_blank' OnClick='window.close()'>�s�W���t��</A>!</b></font><br><br>");
				}

			}
		}


		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}


		// �ˬd���Ȥ�s���O�_�b��Ʈw���s�b
		private void CheckExist()
		{
			// �ǥѫe�@�����ǨӪ��ܼƭȦr�� custno
			string mfrno = Context.Request.QueryString["mfrno"].ToString().Trim();
			//Response.Write("mfrno= " + mfrno + "<br>");

			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "mfr");
			DataView dv1 = ds1.Tables["mfr"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			string rowfilterstr = "1=1";
			rowfilterstr = rowfilterstr + " AND mfr_mfrno='" + mfrno + "'";
			dv1.RowFilter = rowfilterstr;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			// �Y�����, �h��ܬ������; �_�h�������~�T��
			if(dv1.Count <= 0)
			{
				Response.Write("<font size=2 color=red><b>��Ʈw���L�� �t�Ӳνs�Ψ���, �Х�<A HREF='../d5/mfr_addnew.aspx' Target='_blank' OnClick='window.close()'>�s�W���t��</A>!</b></font><br><br>");
			}
			else
			{
				// �Y���� �t�Ӳνs, �h��ܨ�������
				GetData();
			}

		}


		private void GetData()
		{
			// ��e�@�B�J�Ӫ� mfrno �ܼƭ�
			string mfrno = Context.Request.QueryString["mfrno"].ToString().Trim();
			//Response.Write("mfrno= " + mfrno + "<br>");

			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "mfr");
			DataView dv = ds.Tables["mfr"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			string rowfilterstr = "1=1";
			rowfilterstr = rowfilterstr + " AND mfr_mfrno='" + mfrno + "'";
			dv.RowFilter = rowfilterstr;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv.Count= "+ dv.Count + "<BR>");
			//Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");

			// �Y�����, �h��ܬ������; �_�h�������~�T��
			if (dv.Count > 0)
			{
				// ��ܥX�Ҧ��� dv �̪����, �å� \ �Ÿ��j�}�ϧO
				//for (int i =0; i < dv.Count; i++)
				//{
					//for (int j=0;j<10;j++)
						//Response.Write(j + ":" + dv[i][j] + "\\ ");
				//}

				// ��J���
				this.lblMfrID.Text = dv[0]["mfr_mfrid"].ToString();
				this.lblMfrIName.Text = dv[0]["mfr_inm"].ToString();
				this.lblMfrNo.Text = dv[0]["mfr_mfrno"].ToString();

				string RegDate = dv[0]["mfr_regdate"].ToString();
				this.lblMfrRegDate.Text = RegDate.Substring(0, 4) + "/" + RegDate.Substring(4, 2) + "/" + RegDate.Substring(6, 2);

				this.lblMfrRespName.Text = dv[0]["mfr_respnm"].ToString();
				this.lblMfrRespJobTitle.Text = dv[0]["mfr_respjbti"].ToString();
				this.lblMfrTel.Text = dv[0]["mfr_tel"].ToString();
				this.lblMfrFax.Text = dv[0]["mfr_fax"].ToString();
				this.lblMfrIZipcode.Text = dv[0]["mfr_izip"].ToString();
				this.lblMfrIAddr.Text = dv[0]["mfr_iaddr"].ToString();
			}
			else
			{
				// �Y��L���, �h�M�����
				this.lblMfrIName.Text = "(<font color='RED'>�d�L���t�Ӳνs, �Х�<A HREF='../d5/mfr_addnew.aspx' Target='_blank' OnClick='window.close()'>�s�W���t��</A>!</font>)";
				this.lblMfrNo.Text = "";
				this.lblMfrRespName.Text = "";
				this.lblMfrRespJobTitle.Text = "";
				this.lblMfrTel.Text = "";
				this.lblMfrFax.Text = "";
				this.lblMfrIZipcode.Text = "";
				this.lblMfrIAddr.Text = "";
				this.lblMfrRegDate.Text = "";
			}

		}


		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "mfr", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_tel", "mfr_tel"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_fax", "mfr_fax"),
																																																			 new System.Data.Common.DataColumnMapping("mfr_regdate", "mfr_regdate")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = "SELECT mfr_mfrid, mfr_mfrno, mfr_inm, mfr_iaddr, mfr_izip, mfr_respnm, mfr_respjb" +
				"ti, mfr_tel, mfr_fax, mfr_regdate FROM mfr";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
//				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	}
}
