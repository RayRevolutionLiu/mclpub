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
// XML
using System.Xml;
// IO
using System.IO;
// SQLCommand
using System.Data.SqlClient;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for cont_mainSave.
	/// </summary>
	public class cont_mainSave : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		
		
		// �ŧi xml��Ƭ� global, �n����L�{���i�H�I�s
		XmlDocument XmlDoc;
		XmlElement root;
		
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
		protected System.Data.SqlClient.SqlCommand sqlCommand3;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		
		
		public cont_mainSave()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;

			//// ����: ���N�ǹL�Ӫ� Request.InputStream ��X���ɮ� test_cont_mainSave.xml �Ӱ��ˬd
			//// �q�L�F������, �A�}�l�U�����{��
			//// Request.SaveAs("c:\\test_cont_mainSave.xml", false);
			
			
			// �}�l�B�z�{����: �N�ǤJ�� XML ��� => �s�ܸ�Ʈw�� ---------------
			XmlDoc = new System.Xml.XmlDocument();
			XmlDoc.Load(Request.InputStream);
			root = XmlDoc.DocumentElement;
			// �N root ��xml���e��ܥX��, ���ˬd��
			//Response.Write(root.OuterXml);
			XmlNode xmlMain = XmlDoc.SelectSingleNode("/root");
			XmlNode xmlHeader = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e");
			
			XmlNode xmlMfrData = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e/�t�Ӹ��");
			XmlNode xmlCustData = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e/�Ȥ���");
			XmlNode xmlContBasicData = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e/�X���Ѱ򥻸��");
			XmlNode xmlContDetail = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e/�X���ѲӸ`");
			XmlNode xmlInvRec = XmlDoc.SelectSingleNode("/root/�o���t�Ӹ��");
			XmlNode xmlMazRec = XmlDoc.SelectSingleNode("/root/���x����H���");
			XmlNode xmlAdContactor = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e/�s�i�p���H���");
			
			XmlNode xmlAdpubData = XmlDoc.SelectSingleNode("/root/�X���Ѹ����Z�n���");
			XmlNode xmlAdpubItems = XmlDoc.SelectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�");
			XmlNode xmlAdpubItemInvRec = XmlDoc.SelectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�o���t�Ӧ���H�Ӹ`");
			XmlNode xmlAdpubItemDetails = XmlDoc.SelectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�����Ӹ`");
			
			
			// �}�l�� xml��� �x�J��Ʈw
			this.sqlUpdateCommand1.Parameters["@Original_cont_syscd"].Value=xmlContBasicData["�t�ΥN�X"].FirstChild.OuterXml;
			this.sqlUpdateCommand1.Parameters["@Original_cont_contno"].Value=xmlContBasicData["�X���ѽs��"].FirstChild.OuterXml;
			this.sqlUpdateCommand1.Parameters["@cont_syscd"].Value=xmlContBasicData["�t�ΥN�X"].FirstChild.OuterXml;
			this.sqlUpdateCommand1.Parameters["@cont_contno"].Value=xmlContBasicData["�X���ѽs��"].FirstChild.OuterXml;
			
			// �Y�X�����O�N�X = 01 or 09, �h���x�s�ʧ@
			if((xmlContBasicData["�X�����O�N�X"].FirstChild.OuterXml=="01")||(xmlContBasicData["�X�����O�N�X"].FirstChild.OuterXml=="09"))
			{
				// �H�U�Y��������, �h�L�ˬd�O�_���ŭ�, �é�m��C�Ϫ��e�X��;
				// �_�h���ˬd�O�_���ŭ�, �A���J��XML���
				
				// �t�ӤΫȤ��� ��
				this.sqlUpdateCommand1.Parameters["@cont_mfrno"].Value=xmlMfrData["�t�Ӳνs"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_custno"].Value=xmlCustData["�Ȥ�s��"].FirstChild.OuterXml;
				
				// �X���Ѱ򥻸�� ��
				// ������B�z - ��XML��X, �h�� / �Ÿ���, �A�x�s�ܸ�Ʈw��
				string SignDate = xmlContBasicData["ñ�����"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_signdate"].Value = SignDate.Substring(0, 4) + SignDate.Substring(5, 2) + SignDate.Substring(8, 2);
				this.sqlUpdateCommand1.Parameters["@cont_moddate"].Value = System.DateTime.Today.ToString("yyyyMMdd");
				string StartDate = xmlContBasicData["�X���_��"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_sdate"].Value = StartDate.Substring(0, 4) + StartDate.Substring(5, 2);
				string EndDate = xmlContBasicData["�X������"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_edate"].Value = EndDate.Substring(0, 4) + EndDate.Substring(5, 2);
				string ModDate = xmlContBasicData["�̫�ק���"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_moddate"].Value = ModDate.Substring(0, 4) + ModDate.Substring(5, 2) + ModDate.Substring(8, 2);
				
				this.sqlUpdateCommand1.Parameters["@cont_conttp"].Value=xmlContBasicData["�X�����O�N�X"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_bkcd"].Value=xmlContBasicData["���y���O�N�X"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_empno"].Value=xmlContBasicData["�ӿ�~�ȭ��u��"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_fgpayonce"].Value=xmlContBasicData["�@���I�M���O"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_fgclosed"].Value=xmlContBasicData["���׵��O"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_oldcontno"].Value=xmlContBasicData["�¦X���s��"].FirstChild.OuterXml;		
				this.sqlUpdateCommand1.Parameters["@cont_modempno"].Value=xmlContBasicData["�ק�~�ȭ��u��"].FirstChild.OuterXml;
				
				
				// �X���ѲӸ` ��
				if(xmlContDetail["�`�s�Z����"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_totjtm"].Value=xmlContDetail["�`�s�Z����"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_totjtm"].Value="0";
				
				if(xmlContDetail["�w�s�Z����"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_madejtm"].Value=xmlContDetail["�w�s�Z����"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_madejtm"].Value="0";
				
				if(xmlContDetail["�Ѿl�s�Z����"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_restjtm"].Value=xmlContDetail["�Ѿl�s�Z����"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_restjtm"].Value="0";
				
				if(xmlContDetail["�u�f���"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_disc"].Value=xmlContDetail["�u�f���"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_disc"].Value="0";
				
				if(xmlContDetail["�ذe����"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_freetm"].Value=xmlContDetail["�ذe����"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_freetm"].Value="0";
				
				if(xmlContDetail["�`�Z�n����"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_tottm"].Value=xmlContDetail["�`�Z�n����"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_tottm"].Value="0";
				
				if(xmlContDetail["�w�Z�n����"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_pubtm"].Value=xmlContDetail["�w�Z�n����"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_pubtm"].Value="0";
				
				if(xmlContDetail["�Ѿl�Z�n����"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_resttm"].Value=xmlContDetail["�Ѿl�Z�n����"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_resttm"].Value="0";
				
				if(xmlContDetail["�X���`���B"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_totamt"].Value=xmlContDetail["�X���`���B"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_totamt"].Value="0";
				
				if(xmlContDetail["�wú���B"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_paidamt"].Value=xmlContDetail["�wú���B"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_paidamt"].Value="0";
				
				if(xmlContDetail["�Ѿl���B"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_restamt"].Value=xmlContDetail["�Ѿl���B"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_restamt"].Value="0";
				
				if(xmlContDetail["���Z����"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_chgjtm"].Value=xmlContDetail["���Z����"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_chgjtm"].Value="0";
				
				if(xmlAdpubItems["��������B"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_pubamt"].Value=xmlAdpubItems["��������B"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_pubamt"].Value="0";

				if(xmlAdpubItems["���Z�O��"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_chgamt"].Value=xmlAdpubItems["���Z�O��"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_chgamt"].Value="0";
				
				if(xmlContDetail["�m�⦸��"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_clrtm"].Value=xmlContDetail["�m�⦸��"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_clrtm"].Value="0";
				
				if(xmlContDetail["�¥զ���"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_menotm"].Value=xmlContDetail["�¥զ���"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_menotm"].Value="0";
				
				if(xmlContDetail["�M�⦸��"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_getclrtm"].Value=xmlContDetail["�M�⦸��"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_getclrtm"].Value="0";
				
				
				// �s�i�p���H��� ��
				if(xmlAdContactor["�s�i�p���H�m�W"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_aunm"].Value=xmlAdContactor["�s�i�p���H�m�W"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_aunm"].Value="";
				
				if(xmlAdContactor["�s�i�p���H�q��"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_autel"].Value=xmlAdContactor["�s�i�p���H�q��"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_autel"].Value="";
				
				if(xmlAdContactor["�s�i�p���H�ǯu"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_aufax"].Value=xmlAdContactor["�s�i�p���H�ǯu"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_aufax"].Value="";
				
				if(xmlAdContactor["�s�i�p���H���"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_aucell"].Value=xmlAdContactor["�s�i�p���H���"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_aucell"].Value="";
				
				if(xmlAdContactor["�s�i�p���HEmail"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_auemail"].Value=xmlAdContactor["�s�i�p���HEmail"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_auemail"].Value="";
				
				// �o���t�Ӧ���H��� ��: �ѤU�誺 stored procedure coding
				// ���x����H��� ��: �ѤU�誺 stored procedure coding
				// �X���Ѹ����Z�n��� ��: �ѤU�誺 stored procedure coding
				
			}			
			// �w�q PK ����, �_�h�L�k���J DB
			this.sqlUpdateCommand1.Parameters["@Select_cont_syscd"].Value=xmlContBasicData["�t�ΥN�X"].FirstChild.OuterXml;
			this.sqlUpdateCommand1.Parameters["@Select_cont_contno"].Value=xmlContBasicData["�X���ѽs��"].FirstChild.OuterXml;
			
			// ��s cont_xmldata ���
			this.sqlUpdateCommand1.Parameters["@cont_xmldata"].Value= "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlMain.OuterXml;
			
			// ���� sqlUpdateCommand1 ��s: �X���� ��� c2_cont
			this.sqlUpdateCommand1.Connection.Open();
			bool ResultFlag;
			try
			{
				this.sqlUpdateCommand1.ExecuteNonQuery();
				ResultFlag=true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				ResultFlag=false;
				Response.Write(ex.Message + "\n");
			}
			finally
			{
				this.sqlUpdateCommand1.Connection.Close();
			}
						
			// ��X���浲�G
			if(ResultFlag)
			{
				Response.Write("�ק�X�����ɦ��\!\n\n");
			}
			else  
			{
				Response.Write("�ק�X�����ɥ���!\n\n");
			}			
			
			
			// xml/Stored Procedure �ϥ� ExecuteReader() �覡; �@��ϥ� ExecuteNonQuery() �覡
			// ����.cs, ���Y�����I�s using System.Data.SqlClient, �~��ϥ� SqlDataReader
			
			//------- Stored Procedure: sp_c2_cont_newSave_or - �� XML �g�� ���x����H �� DB table ------//
			// �ˬd�ǤJ���ܼ�
			//Response.Write("syscd= " + xmlContBasicData["�t�ΥN�X"].FirstChild.OuterXml + "\n");
			//Response.Write("contno= " + xmlContBasicData["�X���ѽs��"].FirstChild.OuterXml + "\n");
			//Response.Write("XML= " + "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlMain.OuterXml + "\n");
			//Response.Write("xmlMazRec= " + "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlMazRec.OuterXml + "\n");
			//Response.Write("xmlMazRec.ChildNodes.Count= " + xmlMazRec.ChildNodes.Count + "\n");
			this.sqlCommand1.Parameters["@syscd"].Value=xmlContBasicData["�t�ΥN�X"].FirstChild.OuterXml;
			this.sqlCommand1.Parameters["@contno"].Value=xmlContBasicData["�X���ѽs��"].FirstChild.OuterXml;
			// ���B @XML �O�I�s�� xmlMazRec, �D xmlMain
			this.sqlCommand1.Parameters["@XML"].Value="<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlMazRec.OuterXml;
			
			// �������Y�����I�s using System.Data.SqlClient, �~��ϥ� SqlDataReader
			// xml/Stored Procedure �ϥ� ExecuteReader() �覡; �@��ϥ� ExecuteNonQuery() �覡
			
			// ���� sqlCommand1 �x�s�ק�: ���x����H ��� c2_or
			this.sqlCommand1.Connection.Open();
			bool ResultFlag1;
			try
			{
				SqlDataReader myReader1=this.sqlCommand1.ExecuteReader();
				myReader1.Read();
				myReader1.Close();
				ResultFlag1=true;
			}
			catch(System.Data.SqlClient.SqlException ex1)
			{
				//Trans1.Rollback();
				ResultFlag1=false;
				Response.Write(ex1.Message + "\n");
			}
			finally
			{
				this.sqlCommand1.Connection.Close();
			}
			
			// ��X���浲�G
			if(ResultFlag1)
			{
				Response.Write("�ק����x����H�ɦ��\!\n\n");
			}
			else  
			{
				Response.Write("�ק����x����H�ɥ���!\n\n");
			}
			
			
			//------- Stored Procedure: sp_c2_cont_newSave_IM - �� XML �g�� �o���t�Ӧ���H �� DB table ------//
			// �ˬd�ǤJ���ܼ�
			//Response.Write("syscd= " + xmlContBasicData["�t�ΥN�X"].FirstChild.OuterXml + "\n");
			//Response.Write("contno= " + xmlContBasicData["�X���ѽs��"].FirstChild.OuterXml + "\n");
			//Response.Write("XML= " + "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlMain.OuterXml + "\n");
			//Response.Write("xmlInvRec= " + "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlInvRec.OuterXml + "\n");
			//Response.Write("xmlInvRec.ChildNodes.Count= " + xmlInvRec.ChildNodes.Count + "\n");
			//Response.Write("imseq= " + xmlInvRec.ChildNodes.Item(xmlInvRec.ChildNodes.Count).SelectSingleNode["�o���t�ӧǸ�"].FirstChild.OuterXml + "\n");
			this.sqlCommand2.Parameters["@syscd"].Value=xmlContBasicData["�t�ΥN�X"].FirstChild.OuterXml;
			this.sqlCommand2.Parameters["@contno"].Value=xmlContBasicData["�X���ѽs��"].FirstChild.OuterXml;
			// ���B @XML �O�I�s�� xmlInvRec, �D xmlMain
			this.sqlCommand2.Parameters["@XML"].Value="<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlInvRec.OuterXml;
			
			// �������Y�����I�s using System.Data.SqlClient, �~��ϥ� SqlDataReader
			// xml/Stored Procedure �ϥ� ExecuteReader() �覡; �@��ϥ� ExecuteNonQuery() �覡
			
			// ���� sqlCommand2 �x�s�ק�: �o���t�Ӧ���H ��� invmfr
			this.sqlCommand2.Connection.Open();
			bool ResultFlag2;
			try
			{
				SqlDataReader myReader2=this.sqlCommand2.ExecuteReader();
				myReader2.Read();
				myReader2.Close();
				ResultFlag2=true;
			}
			catch(System.Data.SqlClient.SqlException ex2)
			{
				//Trans1.Rollback();
				ResultFlag2=false;
				Response.Write(ex2.Message + "\n");
			}
			finally
			{
				this.sqlCommand2.Connection.Close();
			}
				
			// ��X���浲�G
			if(ResultFlag2)
			{
				Response.Write("�ק�o���t�Ӧ���H�ɦ��\!\n\n");
			}
			else  
			{
				Response.Write("�ק�o���t�Ӧ���H�ɥ���!\n\n");
			}
			
			
			//------- Stored Procedure: sp_c2_cont_newSave_pub - �� XML �g�� �����Z�n��� �� DB table ------//
			// �ˬd�ǤJ���ܼ�
			//Response.Write("syscd= " + xmlContBasicData["�t�ΥN�X"].FirstChild.OuterXml + "\n");
			//Response.Write("contno= " + xmlContBasicData["�X���ѽs��"].FirstChild.OuterXml + "\n");
			//Response.Write("XML= " + "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlAdpubData.OuterXml + "\n");
			//Response.Write("xmlAdpubData= " + "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlAdpubData.OuterXml + "\n");
			//Response.Write("xmlAdpubData.ChildNodes.Count= " + xmlAdpubData.ChildNodes.Count + "\n");
			//Response.Write("xmlAdpubData.FirstChild= " + xmlAdpubData.FirstChild.OuterXml + "\n");
			//Response.Write("xmlAdpubData's 1st �Ǹ�= " + xmlAdpubData.FirstChild.FirstChild.InnerXml + "\n");
			//Response.Write("xmlAdpubData's 1st �Z�n�~��= " + xmlAdpubData.FirstChild.SelectSingleNode["���y���O�N�X"].InnerXml + "\n");
			this.sqlCommand3.Parameters["@syscd"].Value=xmlContBasicData["�t�ΥN�X"].FirstChild.OuterXml;
			this.sqlCommand3.Parameters["@contno"].Value=xmlContBasicData["�X���ѽs��"].FirstChild.OuterXml;
			// ���B @XML �O�I�s�� xmlAdpubData, �D xmlMain
			this.sqlCommand3.Parameters["@XML"].Value="<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlAdpubData.OuterXml;
			
			// �ˬd�����Ĥ@�����Z�n�~��O�_����, �A�P�_�O�_�s�W�J c2_pub table ��
			//Response.Write("xmlAdpubData.ChildNodes.Count= " + xmlAdpubData.ChildNodes.Count + "\n");
			//Response.Write("xmlAdpubData.FirstChild.InnerText= " + xmlAdpubData.FirstChild.SelectSingleNode("�Z�n�~��").InnerText + "\n");
			//if(xmlAdpubData.ChildNodes.Count>=1 && xmlAdpubData.FirstChild.SelectSingleNode("�Z�n�~��").InnerText != "")
			if(xmlAdpubData.FirstChild.SelectSingleNode("�Z�n�~��").InnerText != "")
			{
				//Response.Write("xmlAdpubData.OuterXml= " + xmlAdpubData.OuterXml + "\n");
				Response.Write("�����Ĥ@���Z�n�~�뤣����, �s�W������Ƥ�, �еy��!!!\n");
				
				// ���� sqlCommand3 �x�s�ק�: ���� ��� c2_pub
				this.sqlCommand3.Connection.Open();
				bool ResultFlag3;
				try
				{
					SqlDataReader myReader3=this.sqlCommand3.ExecuteReader();
					myReader3.Read();
					myReader3.Close();
					ResultFlag3=true;
				}
				catch(System.Data.SqlClient.SqlException ex3)
				{
					//Trans1.Rollback();
					ResultFlag3=false;
					Response.Write(ex3.Message + "\n");
				}
				finally
				{
					this.sqlCommand3.Connection.Close();
				}
				
				// ��X���浲�G
				if(ResultFlag3)
				{
					Response.Write("�ק︨���ɦ��\!\n\n");
				}
				else  
				{
					Response.Write("�ק︨���ɥ���!\n\n");
				}

			}
			// �Y�Ĥ@�����Z�n�~�묰�ŭ�
			else
			{
				//Response.Write("xmlAdpubData.OuterXml= " + xmlAdpubData.OuterXml + "\n");
				Response.Write("�����Ĥ@���Z�n�~�묰��, �N���s�W�ܸ�����!!!\n");
			}
		}
		
		
		private void Page_Init(object sender, EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
		}
		
		
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_contid", "cont_contid"),
																																																				 new System.Data.Common.DataColumnMapping("cont_syscd", "cont_syscd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_conttp", "cont_conttp"),
																																																				 new System.Data.Common.DataColumnMapping("cont_bkcd", "cont_bkcd"),
																																																				 new System.Data.Common.DataColumnMapping("cont_signdate", "cont_signdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_empno", "cont_empno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_mfrno", "cont_mfrno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aunm", "cont_aunm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_autel", "cont_autel"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aufax", "cont_aufax"),
																																																				 new System.Data.Common.DataColumnMapping("cont_aucell", "cont_aucell"),
																																																				 new System.Data.Common.DataColumnMapping("cont_auemail", "cont_auemail"),
																																																				 new System.Data.Common.DataColumnMapping("cont_sdate", "cont_sdate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_edate", "cont_edate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totjtm", "cont_totjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_madejtm", "cont_madejtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restjtm", "cont_restjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_disc", "cont_disc"),
																																																				 new System.Data.Common.DataColumnMapping("cont_freetm", "cont_freetm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgclosed", "cont_fgclosed"),
																																																				 new System.Data.Common.DataColumnMapping("cont_tottm", "cont_tottm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubtm", "cont_pubtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_resttm", "cont_resttm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_chgjtm", "cont_chgjtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_custno", "cont_custno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_totamt", "cont_totamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_pubamt", "cont_pubamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_chgamt", "cont_chgamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_paidamt", "cont_paidamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_restamt", "cont_restamt"),
																																																				 new System.Data.Common.DataColumnMapping("cont_clrtm", "cont_clrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_menotm", "cont_menotm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_getclrtm", "cont_getclrtm"),
																																																				 new System.Data.Common.DataColumnMapping("cont_oldcontno", "cont_oldcontno"),
																																																				 new System.Data.Common.DataColumnMapping("cont_moddate", "cont_moddate"),
																																																				 new System.Data.Common.DataColumnMapping("cont_fgpayonce", "cont_fgpayonce"),
																																																				 new System.Data.Common.DataColumnMapping("cont_xmldata", "cont_xmldata"),
																																																				 new System.Data.Common.DataColumnMapping("cont_modempno", "cont_modempno")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = @"DELETE FROM c2_cont WHERE (cont_contno = @cont_contno) AND (cont_syscd = @cont_syscd) AND (cont_aucell = @cont_aucell) AND (cont_auemail = @cont_auemail) AND (cont_aufax = @cont_aufax) AND (cont_aunm = @cont_aunm) AND (cont_autel = @cont_autel) AND (cont_bkcd = @cont_bkcd) AND (cont_chgamt = @cont_chgamt) AND (cont_chgjtm = @cont_chgjtm) AND (cont_clrtm = @cont_clrtm) AND (cont_contid = @cont_contid) AND (cont_conttp = @cont_conttp) AND (cont_custno = @cont_custno) AND (cont_disc = @cont_disc) AND (cont_edate = @cont_edate) AND (cont_empno = @cont_empno) AND (cont_fgclosed = @cont_fgclosed) AND (cont_fgpayonce = @cont_fgpayonce) AND (cont_freetm = @cont_freetm) AND (cont_getclrtm = @cont_getclrtm) AND (cont_madejtm = @cont_madejtm) AND (cont_menotm = @cont_menotm) AND (cont_mfrno = @cont_mfrno) AND (cont_moddate = @cont_moddate) AND (cont_modempno = @cont_modempno) AND (cont_oldcontno = @cont_oldcontno) AND (cont_paidamt = @cont_paidamt) AND (cont_pubamt = @cont_pubamt) AND (cont_pubtm = @cont_pubtm) AND (cont_restamt = @cont_restamt) AND (cont_restjtm = @cont_restjtm) AND (cont_resttm = @cont_resttm) AND (cont_sdate = @cont_sdate) AND (cont_signdate = @cont_signdate) AND (cont_totamt = @cont_totamt) AND (cont_totjtm = @cont_totjtm) AND (cont_tottm = @cont_tottm) AND (cont_xmldata LIKE @cont_xmldata)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aucell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aucell", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_auemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_auemail", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aufax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aufax", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aunm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aunm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_autel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_autel", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_bkcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_chgamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgamt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_chgjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgjtm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_clrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_clrtm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contid", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_conttp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_conttp", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_custno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_disc", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_disc", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_edate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_edate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_empno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgclosed", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgclosed", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgpayonce", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgpayonce", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_freetm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_freetm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_getclrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_getclrtm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_madejtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_madejtm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_menotm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_menotm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_mfrno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_moddate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_modempno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_modempno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_oldcontno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_oldcontno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_paidamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_paidamt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubamt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubtm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_restamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restamt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_restjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restjtm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_resttm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_resttm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_sdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_sdate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_signdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_signdate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totamt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totjtm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_tottm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_tottm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_xmldata", System.Data.SqlDbType.NText, 150000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_xmldata", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO c2_cont(cont_syscd, cont_contno, cont_conttp, cont_bkcd, cont_signdat" +
				"e, cont_empno, cont_mfrno, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_" +
				"auemail, cont_sdate, cont_edate, cont_totjtm, cont_madejtm, cont_restjtm, cont_d" +
				"isc, cont_freetm, cont_fgclosed, cont_tottm, cont_pubtm, cont_resttm, cont_chgjt" +
				"m, cont_custno, cont_totamt, cont_pubamt, cont_chgamt, cont_paidamt, cont_restam" +
				"t, cont_clrtm, cont_menotm, cont_getclrtm, cont_oldcontno, cont_moddate, cont_fg" +
				"payonce, cont_xmldata, cont_modempno) VALUES (@cont_syscd, @cont_contno, @cont_c" +
				"onttp, @cont_bkcd, @cont_signdate, @cont_empno, @cont_mfrno, @cont_aunm, @cont_a" +
				"utel, @cont_aufax, @cont_aucell, @cont_auemail, @cont_sdate, @cont_edate, @cont_" +
				"totjtm, @cont_madejtm, @cont_restjtm, @cont_disc, @cont_freetm, @cont_fgclosed, " +
				"@cont_tottm, @cont_pubtm, @cont_resttm, @cont_chgjtm, @cont_custno, @cont_totamt" +
				", @cont_pubamt, @cont_chgamt, @cont_paidamt, @cont_restamt, @cont_clrtm, @cont_m" +
				"enotm, @cont_getclrtm, @cont_oldcontno, @cont_moddate, @cont_fgpayonce, @cont_xm" +
				"ldata, @cont_modempno); SELECT cont_contid, cont_syscd, cont_contno, cont_conttp" +
				", cont_bkcd, cont_signdate, cont_empno, cont_mfrno, cont_aunm, cont_autel, cont_" +
				"aufax, cont_aucell, cont_auemail, cont_sdate, cont_edate, cont_totjtm, cont_made" +
				"jtm, cont_restjtm, cont_disc, cont_freetm, cont_fgclosed, cont_tottm, cont_pubtm" +
				", cont_resttm, cont_chgjtm, cont_custno, cont_totamt, cont_pubamt, cont_chgamt, " +
				"cont_paidamt, cont_restamt, cont_clrtm, cont_menotm, cont_getclrtm, cont_oldcont" +
				"no, cont_moddate, cont_fgpayonce, cont_xmldata, cont_modempno FROM c2_cont WHERE" +
				" (cont_contno = @Select_cont_contno) AND (cont_syscd = @Select_cont_syscd)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_conttp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_conttp", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_bkcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_signdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_signdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_empno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aunm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aunm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_autel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_autel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aufax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aufax", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aucell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aucell", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_auemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_auemail", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_sdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_sdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_edate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_edate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totjtm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_madejtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_madejtm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_restjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restjtm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_disc", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_disc", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_freetm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_freetm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgclosed", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgclosed", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_tottm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_tottm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubtm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_resttm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_resttm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_chgjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgjtm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totamt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubamt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_chgamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgamt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_paidamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_paidamt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_restamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restamt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_clrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_clrtm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_menotm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_menotm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_getclrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_getclrtm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_oldcontno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_oldcontno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgpayonce", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgpayonce", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_xmldata", System.Data.SqlDbType.NText, 150000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_modempno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_modempno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT cont_contid, cont_syscd, cont_contno, cont_conttp, cont_bkcd, cont_signdate, cont_empno, cont_mfrno, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_sdate, cont_edate, cont_totjtm, cont_madejtm, cont_restjtm, cont_disc, cont_freetm, cont_fgclosed, cont_tottm, cont_pubtm, cont_resttm, cont_chgjtm, cont_custno, cont_totamt, cont_pubamt, cont_chgamt, cont_paidamt, cont_restamt, cont_clrtm, cont_menotm, cont_getclrtm, cont_oldcontno, cont_moddate, cont_fgpayonce, cont_xmldata, cont_modempno FROM c2_cont";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = "UPDATE c2_cont SET cont_syscd = @cont_syscd, cont_contno = @cont_contno, cont_con" +
				"ttp = @cont_conttp, cont_bkcd = @cont_bkcd, cont_signdate = @cont_signdate, cont" +
				"_empno = @cont_empno, cont_mfrno = @cont_mfrno, cont_aunm = @cont_aunm, cont_aut" +
				"el = @cont_autel, cont_aufax = @cont_aufax, cont_aucell = @cont_aucell, cont_aue" +
				"mail = @cont_auemail, cont_sdate = @cont_sdate, cont_edate = @cont_edate, cont_t" +
				"otjtm = @cont_totjtm, cont_madejtm = @cont_madejtm, cont_restjtm = @cont_restjtm" +
				", cont_disc = @cont_disc, cont_freetm = @cont_freetm, cont_fgclosed = @cont_fgcl" +
				"osed, cont_tottm = @cont_tottm, cont_pubtm = @cont_pubtm, cont_resttm = @cont_re" +
				"sttm, cont_chgjtm = @cont_chgjtm, cont_custno = @cont_custno, cont_totamt = @con" +
				"t_totamt, cont_pubamt = @cont_pubamt, cont_chgamt = @cont_chgamt, cont_paidamt =" +
				" @cont_paidamt, cont_restamt = @cont_restamt, cont_clrtm = @cont_clrtm, cont_men" +
				"otm = @cont_menotm, cont_getclrtm = @cont_getclrtm, cont_oldcontno = @cont_oldco" +
				"ntno, cont_moddate = @cont_moddate, cont_fgpayonce = @cont_fgpayonce, cont_xmlda" +
				"ta = @cont_xmldata, cont_modempno = @cont_modempno WHERE (cont_contno = @Origina" +
				"l_cont_contno) AND (cont_syscd = @Original_cont_syscd)  ; SELECT cont_contid, co" +
				"nt_syscd, cont_contno, cont_conttp, cont_bkcd, cont_signdate, cont_empno, cont_m" +
				"frno, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_sdate, " +
				"cont_edate, cont_totjtm, cont_madejtm, cont_restjtm, cont_disc, cont_freetm, con" +
				"t_fgclosed, cont_tottm, cont_pubtm, cont_resttm, cont_chgjtm, cont_custno, cont_" +
				"totamt, cont_pubamt, cont_chgamt, cont_paidamt, cont_restamt, cont_clrtm, cont_m" +
				"enotm, cont_getclrtm, cont_oldcontno, cont_moddate, cont_fgpayonce, cont_xmldata" +
				", cont_modempno FROM c2_cont WHERE (cont_contno = @Select_cont_contno) AND (cont" +
				"_syscd = @Select_cont_syscd)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_conttp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_conttp", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_bkcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_signdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_signdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_empno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aunm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aunm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_autel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_autel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aufax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aufax", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_aucell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aucell", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_auemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_auemail", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_sdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_sdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_edate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_edate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totjtm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_madejtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_madejtm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_restjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restjtm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_disc", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_disc", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_freetm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_freetm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgclosed", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgclosed", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_tottm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_tottm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubtm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_resttm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_resttm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_chgjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgjtm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_totamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totamt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_pubamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubamt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_chgamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgamt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_paidamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_paidamt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_restamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restamt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_clrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_clrtm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_menotm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_menotm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_getclrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_getclrtm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_oldcontno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_oldcontno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_fgpayonce", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgpayonce", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_xmldata", System.Data.SqlDbType.NText, 150000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_modempno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_modempno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "dbo.sp_c2_cont_newSave_or";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@XML", System.Data.SqlDbType.Char, 8000, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommand2
			// 
			this.sqlCommand2.CommandText = "dbo.sp_c2_cont_newSave_IM";
			this.sqlCommand2.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@XML", System.Data.SqlDbType.Char, 8000, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommand3
			// 
			this.sqlCommand3.CommandText = "dbo.sp_c2_cont_newSave_pub";
			this.sqlCommand3.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand3.Connection = this.sqlConnection1;
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@XML", System.Data.SqlDbType.Char, 8000, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
