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
//SQL
using System.Data.SqlClient;
// Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for cust_detail.
	/// </summary>
	public class cust_detail : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Web.UI.WebControls.Label lblCustID;
		protected System.Web.UI.WebControls.Label lblCustName;
		protected System.Web.UI.WebControls.Label lblCustJobTitle;
		protected System.Web.UI.WebControls.Label lblCustNo;
		protected System.Web.UI.WebControls.Label lblCustTel;
		protected System.Web.UI.WebControls.Label lblCustFax;
		protected System.Web.UI.WebControls.Label lblCustCell;
		protected System.Web.UI.WebControls.Label lblCustEmail;
		protected System.Web.UI.WebControls.Label lblMfrID;
		protected System.Web.UI.WebControls.Label lblMfrNo;
		protected System.Web.UI.WebControls.Label lblMfrTel;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Web.UI.WebControls.Label lblCustItpcd;
		protected System.Web.UI.WebControls.Label lblCustBtpcd;
		protected System.Web.UI.WebControls.Label lblMfrIName;
		protected System.Web.UI.WebControls.Label lblMfrIZipcode;
		protected System.Web.UI.WebControls.Label lblMfrIAddr;
		protected System.Web.UI.WebControls.Label lblCustModDate;
		protected System.Web.UI.WebControls.Label lblOldCustNo;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Web.UI.WebControls.Label lblCustRegDate;

		public cust_detail()
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

				// �ǥѫe�@�����ǨӪ��ܼƭȦr�� custno
				string custno = "";
				if(Context.Request.QueryString["custno"].ToString().Trim() != "")
				{
					custno = Context.Request.QueryString["custno"].ToString().Trim();
					//Response.Write("custno= " + custno + "<br>");

					// �ˬd���Ȥ�s���O�_�b��Ʈw���s�b
					CheckExist();

				}
				else
				{
					Response.Write("<font size=2 color=red><b>��Ʈw���L�� �Ȥ�s���Ψ���, �Х�<A HREF='../d5/cust_add.aspx' Target='_blank' OnClick='window.close()'>�s�W���Ȥ�</A>!</b></font><br><br>");
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
			string custno = Context.Request.QueryString["custno"].ToString().Trim();
			//Response.Write("custno= " + custno + "<br>");

			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds1 = new DataSet();
			this.sqlDataAdapter1.Fill(ds1, "cust");
			DataView dv1 = ds1.Tables["cust"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			string RowFilter = "1=1";
			RowFilter = "cust_custno=" + custno;
			dv1.RowFilter = RowFilter;

			// �ˬd�ÿ�X �̫� Row Filter �����G
			//Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
			//Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

			// �Y�����, �h��ܸ��; �_�h�������~�T��
			if(dv1.Count <= 0)
			{
				Response.Write("<font size=2 color=red><b>��Ʈw���L�� �Ȥ�s���Ψ���, �Х�<A HREF='../d5/cust_add.aspx' Target='_blank' OnClick='window.close()'>�s�W���Ȥ�</A>!</b></font><br><br>");
			}
			else
			{
				// �Y���� �Ȥ�s��, �h��ܨ�������
				GetData();
			}

		}


		// �Y�����Ȥ�s��, �h��ܨ�������
		private void GetData()
		{
			// �ǥѫe�@�����ǨӪ��ܼƭȦr�� custno
			string custno=Context.Request.QueryString["custno"].ToString().Trim();

			// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
			DataSet ds = new DataSet();
			this.sqlDataAdapter1.Fill(ds, "cust");
			DataView dv = ds.Tables["cust"].DefaultView;

			// �� SQL �L�o���� - �] Row Filter (��� where ���᪺����)
			string rowfilterstr = "1=1";
			rowfilterstr = rowfilterstr + " AND cust_custno='" + custno + "'";
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
				//for (int j=0;j<14;j++)
				//Response.Write(j + ":" + dv[i][j] + "\\ ");
				//}

				// ��J���
				this.lblMfrID.Text = dv[0]["mfr_mfrid"].ToString();
				this.lblMfrIName.Text = dv[0]["mfr_inm"].ToString().Trim();
				this.lblMfrNo.Text = dv[0]["cust_mfrno"].ToString();
				this.lblMfrTel.Text = dv[0]["mfr_tel"].ToString().Trim();
				this.lblMfrIZipcode.Text = dv[0]["mfr_izip"].ToString().Trim();
				this.lblMfrIAddr.Text = dv[0]["mfr_iaddr"].ToString().Trim();

				this.lblCustID.Text = dv[0]["cust_custid"].ToString();
				this.lblCustName.Text = dv[0]["cust_nm"].ToString().Trim();
				this.lblCustNo.Text = dv[0]["cust_custno"].ToString().Trim();
				this.lblCustJobTitle.Text = dv[0]["cust_jbti"].ToString().Trim();

				string RegDate = dv[0]["cust_regdate"].ToString();
				this.lblCustRegDate.Text = RegDate.Substring(0, 4) + "/" + RegDate.Substring(4, 2) + "/" + RegDate.Substring(6, 2);
				string ModDate = dv[0]["cust_moddate"].ToString();
				this.lblCustModDate.Text = ModDate.Substring(0, 4) + "/" + ModDate.Substring(4, 2) + "/" + ModDate.Substring(6, 2);

				this.lblCustTel.Text = dv[0]["cust_tel"].ToString().Trim();
				this.lblCustFax.Text = dv[0]["cust_fax"].ToString().Trim();
				this.lblCustCell.Text = dv[0]["cust_cell"].ToString().Trim();
				this.lblCustEmail.Text = dv[0]["cust_email"].ToString().Trim();
				//this.lblCustItpCode.Text = dv[0]["cust_itpcd"].ToString();
				//this.lblCustBtpCode.Text = dv[0]["cust_btpcd"].ToString();
				//this.lblCustRtpCode.Text = dv[0]["cust_rtpcd"].ToString();

				// �«Ȥ�s��
				string OldCustNo = dv[0]["cust_oldcustno"].ToString().Trim();
				if(OldCustNo != "")
					this.lblOldCustNo.Text = OldCustNo;
				else
					this.lblOldCustNo.Text = "<font color='Gainsboro'>�L���</font>";


				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
				//Response.Write("cust_itpcd= " + dv[0]["cust_itpcd"].ToString().Trim() + "<br>");
				if(dv[0]["cust_itpcd"].ToString().Trim() != "")
				{
					DataSet ds2 = new DataSet();
					this.sqlDataAdapter2.Fill(ds2, "itp");
					DataView dv2 = ds2.Tables["itp"].DefaultView;

					int ItpcdCount = dv[0]["cust_itpcd"].ToString().Length / 2;
					//Response.Write("ItpcdCount=" + ItpcdCount + "<br>");

					string EachItpcd="";
					string EachItpName="";
					for(int i=0; i<ItpcdCount; i++)
					{
						EachItpcd = dv[0]["cust_itpcd"].ToString().Substring(i*2, 2);
						//Response.Write("EachItpcd= " + EachItpcd + "<br>");
						dv2.RowFilter = "itp_itpcd=" + EachItpcd;
						EachItpName = dv2[0]["itp_nm"].ToString().Trim();
						EachItpName += ", ";
						//Response.Write("EachItpName= " + EachItpName + "<br>");
						this.lblCustItpcd.Text += EachItpName;
					}
				}
				else
				{
					this.lblCustItpcd.Text = "(�L���)";
				}


				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
				//Response.Write("cust_btpcd= " + dv[0]["cust_btpcd"].ToString().Trim() + "<br>");
				if(dv[0]["cust_btpcd"].ToString().Trim() != "")
				{
					DataSet ds3 = new DataSet();
					this.sqlDataAdapter3.Fill(ds3, "btp");
					DataView dv3 = ds3.Tables["btp"].DefaultView;

					int BtpcdCount = dv[0]["cust_btpcd"].ToString().Length / 2;
					//Response.Write("BtpcdCount=" + BtpcdCount + "<br>");

					string EachBtpcd="";
					string EachBtpName="";
					for(int i=0; i<BtpcdCount; i++)
					{
						EachBtpcd = dv[0]["cust_btpcd"].ToString().Substring(i*2, 2);
						//Response.Write("EachItpcd= " + EachItpcd + "<br>");
						dv3.RowFilter = "btp_btpcd=" + EachBtpcd;
						EachBtpName = dv3[0]["btp_nm"].ToString().Trim();
						EachBtpName += ", ";
						//Response.Write("EachBtpName= " + EachBtpName + "<br>");
						this.lblCustBtpcd.Text += EachBtpName;
					}
				}
				else
				{
					this.lblCustBtpcd.Text = "(�L���)";
				}


//				// rtp table �w����, �G�H�U coding ���ݭn~
//				// �ϥ� DataSet ��k, �ë��w�ϥΪ� table �W��
//				//Response.Write("cust_rtpcd= " + dv[0]["cust_rtpcd"].ToString().Trim() + "<br>");
//				if(dv[0]["cust_rtpcd"].ToString().Trim() != "")
//				{
//					DataSet ds4 = new DataSet();
//					this.sqlDataAdapter4.Fill(ds4, "rtp");
//					DataView dv4 = ds4.Tables["rtp"].DefaultView;
//
//					int RtpcdCount = dv[0]["cust_rtpcd"].ToString().Length / 2;
//					//Response.Write("RtpcdCount=" + RtpcdCount + "<br>");
//
//					string EachRtpcd="";
//					string EachRtpName="";
//					for(int i=0; i<RtpcdCount; i++)
//					{
//						EachRtpcd = dv[0]["cust_rtpcd"].ToString().Substring(i*2, 2);
//						//Response.Write("EachRtpcd= " + EachRtpcd + "<br>");
//						dv4.RowFilter = "rtp_rtpcd=" + EachRtpcd;
//						EachRtpName = dv4[0]["rtp_nm"].ToString().Trim();
//						EachRtpName += ", ";
//						//Response.Write("EachRtpName= " + EachRtpName + "<br>");
//						this.lblCustRtpcd.Text += EachRtpName;
//					}
//				}
//				else
//				{
//					this.lblCustRtpcd.Text = "(�L���)";
//				}

				// ���� if(dv.Count>0) �Y�����, �h��ܸ��
			}
			else
			{
				// �Y��L���, �h�M�����
				this.lblMfrIName.Text = "(<font color='RED'>�d�L���t�Ӳνs, �Х�<A HREF='../d5/mfr_addnew.aspx' Target='_blank' OnClick='window.close()'>�s�W���t��</A>!</font>)";
				this.lblMfrNo.Text = "";
				this.lblMfrTel.Text = "";
				this.lblMfrIZipcode.Text = "";
				this.lblMfrIAddr.Text = "";

				this.lblCustName.Text = "";
				this.lblCustNo.Text = "";
				this.lblCustJobTitle.Text = "";
				this.lblCustRegDate.Text = "";
				this.lblCustModDate.Text = "";
				this.lblCustTel.Text = "";
				this.lblCustFax.Text = "";
				this.lblCustCell.Text = "";
				this.lblCustEmail.Text = "";
				this.lblCustItpcd.Text = "";
				this.lblCustBtpcd.Text = "";
//				this.lblCustRtpcd.Text = "";
				this.lblOldCustNo.Text = "";
			}
		}



		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			//
			// sqlDataAdapter3
			//
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "btp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("btp_btpid", "btp_btpid"),
																																																			 new System.Data.Common.DataColumnMapping("btp_btpcd", "btp_btpcd"),
																																																			 new System.Data.Common.DataColumnMapping("btp_nm", "btp_nm")})});
			//
			// sqlSelectCommand3
			//
			this.sqlSelectCommand3.CommandText = "SELECT btp_btpid, btp_btpcd, btp_nm FROM dbo.btp";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			//
			// sqlConnection1
			//
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM2;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=17-0890711-01;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			//
			// sqlDataAdapter2
			//
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "itp", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("itp_itpid", "itp_itpid"),
																																																			 new System.Data.Common.DataColumnMapping("itp_itpcd", "itp_itpcd"),
																																																			 new System.Data.Common.DataColumnMapping("itp_nm", "itp_nm")})});
			//
			// sqlSelectCommand2
			//
			this.sqlSelectCommand2.CommandText = "SELECT itp_itpid, itp_itpcd, itp_nm FROM dbo.itp";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			//
			// sqlDataAdapter1
			//
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "cust", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("cust_custid", "cust_custid"),
																																																			  new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_nm", "cust_nm"),
																																																			  new System.Data.Common.DataColumnMapping("cust_jbti", "cust_jbti"),
																																																			  new System.Data.Common.DataColumnMapping("cust_mfrno", "cust_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_tel", "cust_tel"),
																																																			  new System.Data.Common.DataColumnMapping("cust_fax", "cust_fax"),
																																																			  new System.Data.Common.DataColumnMapping("cust_cell", "cust_cell"),
																																																			  new System.Data.Common.DataColumnMapping("cust_email", "cust_email"),
																																																			  new System.Data.Common.DataColumnMapping("cust_regdate", "cust_regdate"),
																																																			  new System.Data.Common.DataColumnMapping("cust_moddate", "cust_moddate"),
																																																			  new System.Data.Common.DataColumnMapping("cust_itpcd", "cust_itpcd"),
																																																			  new System.Data.Common.DataColumnMapping("cust_btpcd", "cust_btpcd"),
																																																			  new System.Data.Common.DataColumnMapping("cust_rtpcd", "cust_rtpcd"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrid", "mfr_mfrid"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_inm", "mfr_inm"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_iaddr", "mfr_iaddr"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_izip", "mfr_izip"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_tel", "mfr_tel"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_respnm", "mfr_respnm"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_respjbti", "mfr_respjbti"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_fax", "mfr_fax"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_regdate", "mfr_regdate"),
																																																			  new System.Data.Common.DataColumnMapping("mfr_mfrno", "mfr_mfrno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_oldcustno", "cust_oldcustno"),
																																																			  new System.Data.Common.DataColumnMapping("cust_orgisyscd", "cust_orgisyscd")})});
			//
			// sqlSelectCommand1
			//
			this.sqlSelectCommand1.CommandText = @"SELECT dbo.cust.cust_custid, dbo.cust.cust_custno, dbo.cust.cust_nm, dbo.cust.cust_jbti, dbo.cust.cust_mfrno, dbo.cust.cust_tel, dbo.cust.cust_fax, dbo.cust.cust_cell, dbo.cust.cust_email, dbo.cust.cust_regdate, dbo.cust.cust_moddate, dbo.cust.cust_itpcd, dbo.cust.cust_btpcd, dbo.cust.cust_rtpcd, dbo.mfr.mfr_mfrid, dbo.mfr.mfr_inm, dbo.mfr.mfr_iaddr, dbo.mfr.mfr_izip, dbo.mfr.mfr_tel, dbo.mfr.mfr_respnm, dbo.mfr.mfr_respjbti, dbo.mfr.mfr_fax, dbo.mfr.mfr_regdate, dbo.mfr.mfr_mfrno, dbo.cust.cust_oldcustno, dbo.cust.cust_orgisyscd FROM dbo.cust INNER JOIN dbo.mfr ON dbo.cust.cust_mfrno = dbo.mfr.mfr_mfrno";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


	}
}
