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
	/// Summary description for cont_newSave.
	/// </summary>
	public class cont_newSave : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand3;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand3;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand3;
		
		
		// �ŧi xml��Ƭ� global, �n����L�{���i�H�I�s
		XmlDocument XmlDoc;
		XmlElement root;

		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
		protected System.Data.SqlClient.SqlCommand sqlCommand3;
		
		
		public cont_newSave()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;

			//// ����: ���N�ǹL�Ӫ� Request.InputStream ��X���ɮ� test555.xml �Ӱ��ˬd
			//// �q�L�F������, �A�}�l�U�����{��
			//// Request.SaveAs("c:\\testContNewSave.xml", false);
			
			
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
			this.sqlInsertCommand1.Parameters["@cont_syscd"].Value=xmlContBasicData["�t�ΥN�X"].FirstChild.OuterXml;
			this.sqlInsertCommand1.Parameters["@cont_contno"].Value=xmlContBasicData["�X���ѽs��"].FirstChild.OuterXml;
			
			// �Y�X�����O�N�X = 01 or 09, �h���x�s�ʧ@
			if((xmlContBasicData["�X�����O�N�X"].FirstChild.OuterXml=="01")||(xmlContBasicData["�X�����O�N�X"].FirstChild.OuterXml=="09"))
			{
				// �H�U�Y��������, �h�L�ˬd�O�_���ŭ�, �é�m��C�Ϫ��e�X��;
				// �_�h���ˬd�O�_���ŭ�, �A���J��XML���
				
				// �t�Ӹ�� ��
				this.sqlInsertCommand1.Parameters["@cont_mfrno"].Value=xmlMfrData["�t�Ӳνs"].FirstChild.OuterXml;


				// �X���Ѱ򥻸�� ��
				this.sqlInsertCommand1.Parameters["@cont_custno"].Value=xmlCustData["�Ȥ�s��"].FirstChild.OuterXml;
				this.sqlInsertCommand1.Parameters["@cont_conttp"].Value=xmlContBasicData["�X�����O�N�X"].FirstChild.OuterXml;
				this.sqlInsertCommand1.Parameters["@cont_bkcd"].Value=xmlContBasicData["���y���O�N�X"].FirstChild.OuterXml;
				this.sqlInsertCommand1.Parameters["@cont_empno"].Value=xmlContBasicData["�ӿ�~�ȭ��u��"].FirstChild.OuterXml;
				this.sqlInsertCommand1.Parameters["@cont_fgpayonce"].Value=xmlContBasicData["�@���I�M���O"].FirstChild.OuterXml;
				this.sqlInsertCommand1.Parameters["@cont_fgclosed"].Value=xmlContBasicData["���׵��O"].FirstChild.OuterXml;
				
				if(xmlContBasicData["�ק�~�ȭ��u��"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_modempno"].Value=xmlContBasicData["�ק�~�ȭ��u��"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_modempno"].Value="";
				
				if(xmlContBasicData["�¦X���s��"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_oldcontno"].Value=xmlContBasicData["�¦X���s��"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_oldcontno"].Value="";
				
				// ������B�z
				// �H�U�|��O�ª��B�z: �۵e���W��U (���t / �Ÿ�), �ê����x�s�ܸ�Ʈw��
				//this.sqlInsertCommand1.Parameters["@cont_signdate"].Value=xmlContBasicData["ñ�����"].FirstChild.OuterXml;
				//this.sqlInsertCommand1.Parameters["@cont_moddate"].Value=System.DateTime.Today.ToString("yyyyMMdd");
				//this.sqlInsertCommand1.Parameters["@cont_sdate"].Value=xmlContBasicData["�X���_��"].FirstChild.OuterXml;
				//this.sqlInsertCommand1.Parameters["@cont_edate"].Value=xmlContBasicData["�X������"].FirstChild.OuterXml;
				// �s���B�z: �۵e���W��U (�t / �Ÿ�), �åh���ӲŸ��A�x�s�ܸ�Ʈw��
				string SignDate = xmlContBasicData["ñ�����"].FirstChild.OuterXml;
				this.sqlInsertCommand1.Parameters["@cont_signdate"].Value = SignDate.Substring(0, 4) + SignDate.Substring(5, 2) + SignDate.Substring(8, 2);
				this.sqlInsertCommand1.Parameters["@cont_moddate"].Value = System.DateTime.Today.ToString("yyyyMMdd");
				string StartDate = xmlContBasicData["�X���_��"].FirstChild.OuterXml;
				this.sqlInsertCommand1.Parameters["@cont_sdate"].Value = StartDate.Substring(0, 4) + StartDate.Substring(5, 2);
				string EndDate = xmlContBasicData["�X������"].FirstChild.OuterXml;
				this.sqlInsertCommand1.Parameters["@cont_edate"].Value = EndDate.Substring(0, 4) + EndDate.Substring(5, 2);
				
				
				// �X���ѲӸ` ��
				if(xmlContDetail["�`�s�Z����"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_totjtm"].Value=xmlContDetail["�`�s�Z����"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_totjtm"].Value="0";

				if(xmlContDetail["�X���`���B"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_totamt"].Value=xmlContDetail["�X���`���B"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_totamt"].Value="0";

				if(xmlContDetail["�u�f���"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_disc"].Value=xmlContDetail["�u�f���"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_disc"].Value="0";

				if(xmlContDetail["�w�s�Z����"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_madejtm"].Value=xmlContDetail["�w�s�Z����"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_madejtm"].Value="0";

				if(xmlContDetail["�Ѿl�s�Z����"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_restjtm"].Value=xmlContDetail["�Ѿl�s�Z����"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_restjtm"].Value="0";

				if(xmlContDetail["�`�Z�n����"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_tottm"].Value=xmlContDetail["�`�Z�n����"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_tottm"].Value="0";

				if(xmlContDetail["�w�Z�n����"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_pubtm"].Value=xmlContDetail["�w�Z�n����"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_pubtm"].Value="0";

				if(xmlContDetail["�Ѿl�Z�n����"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_resttm"].Value=xmlContDetail["�Ѿl�Z�n����"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_resttm"].Value="0";

				if(xmlContDetail["�wú���B"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_paidamt"].Value=xmlContDetail["�wú���B"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_paidamt"].Value="0";

				if(xmlContDetail["�Ѿl���B"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_restamt"].Value=xmlContDetail["�Ѿl���B"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_restamt"].Value="0";

				if(xmlContDetail["���Z����"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_chgjtm"].Value=xmlContDetail["���Z����"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_chgjtm"].Value="0";

				if(xmlContDetail["�ذe����"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_freetm"].Value=xmlContDetail["�ذe����"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_freetm"].Value="0";

				if(xmlAdpubItems["��������B"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_pubamt"].Value=xmlAdpubItems["��������B"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_pubamt"].Value="0";

				if(xmlAdpubItems["���Z�O��"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_chgamt"].Value=xmlAdpubItems["���Z�O��"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_chgamt"].Value="0";

				if(xmlContDetail["�m�⦸��"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_clrtm"].Value=xmlContDetail["�m�⦸��"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_clrtm"].Value="0";

				if(xmlContDetail["�¥զ���"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_menotm"].Value=xmlContDetail["�¥զ���"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_menotm"].Value="0";

				if(xmlContDetail["�M�⦸��"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_getclrtm"].Value=xmlContDetail["�M�⦸��"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_getclrtm"].Value="0";
				
				
				// �s�i�p���H��� ��
				if(xmlAdContactor["�s�i�p���H�m�W"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_aunm"].Value=xmlAdContactor["�s�i�p���H�m�W"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_aunm"].Value="";

				if(xmlAdContactor["�s�i�p���H�q��"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_autel"].Value=xmlAdContactor["�s�i�p���H�q��"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_autel"].Value="";

				if(xmlAdContactor["�s�i�p���H�ǯu"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_aufax"].Value=xmlAdContactor["�s�i�p���H�ǯu"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_aufax"].Value="";

				if(xmlAdContactor["�s�i�p���H���"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_aucell"].Value=xmlAdContactor["�s�i�p���H���"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_aucell"].Value="";

				if(xmlAdContactor["�s�i�p���HEmail"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_auemail"].Value=xmlAdContactor["�s�i�p���HEmail"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_auemail"].Value="";
				

				// �o���t�Ӧ���H��� ��: �ѤU�誺 stored procedure coding
				// ���x����H��� ��: �ѤU�誺 stored procedure coding
				// �X���Ѹ����Z�n��� ��: �ѤU�誺 stored procedure coding
				
			}
			
			// �w�q PK ����, �_�h�L�k���J DB
			this.sqlInsertCommand1.Parameters["@Select_cont_syscd"].Value=xmlContBasicData["�t�ΥN�X"].FirstChild.OuterXml;
			this.sqlInsertCommand1.Parameters["@Select_cont_contno"].Value=xmlContBasicData["�X���ѽs��"].FirstChild.OuterXml;
			
			// ���J cont_xmldata ���
			this.sqlInsertCommand1.Parameters["@cont_xmldata"].Value= "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlMain.OuterXml;
			
			// ���� sqlInsertCommand1 �s�W���J: �X���� ��� c2_cont
			this.sqlInsertCommand1.Connection.Open();
			bool ResultFlag;
			try
			{
				this.sqlInsertCommand1.ExecuteNonQuery();
				ResultFlag=true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				ResultFlag=false;
				Response.Write(ex.Message + "\n");
			}
			finally
			{
				this.sqlInsertCommand1.Connection.Close();
			}
			
			// ��X���浲�G
			if(ResultFlag)
			{
				Response.Write("�s�W�X�����ɦ��\!\n\n");
			}
			else
			{
				Response.Write("�s�W�X�����ɥ���!\n\n");
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
				//Response.Write("\n xmlAdpubData.OuterXml= " + xmlAdpubData.OuterXml + "\n");
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
			
			
			//------- �Y���@���I�M, �h�s�W�o���}�߳���, �o���}�ߩ�����; �_�h�b�}�ߵo�����j��B�z�~�� --------//
			//Response.Write("conttp= " + xmlContBasicData["�X�����O�N�X"].FirstChild.OuterXml + "\n");
			//Response.Write("�@���I�M���O= " + xmlContBasicData["�@���I�M���O"].FirstChild.OuterXml + "\n");
			//Response.Write("XML= " + "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlContBasicData.OuterXml + "\n");
//			if((xmlContBasicData["�X�����O�N�X"].FirstChild.OuterXml=="01" && xmlContBasicData["�@���I�M���O"].FirstChild.OuterXml=="1") || (xmlContBasicData["�X�����O�N�X"].FirstChild.OuterXml=="09" && xmlContBasicData["�@���I�M���O"].FirstChild.OuterXml=="1"))
//			{
//				Response.Write("�@���I�M, �� �o���}�ߥӽг� ���B�z!\n\n");
//				//InsertIAData();
//				//Response.Redirect("cont_SaveMessage.aspx?str='cont_newSavefg'");
//			}
//			else
//			{
//				Response.Write("�D�@���I�M, ���� �o���}�ߥӽг� ���B�z!\n\n");
//				//Response.Redirect("cont_SaveMessage.aspx?str='cont_newSave'");
//				//Response.Write("�L���X�����O�N�X, �L�k �s�W�o���}�߳���, �o���}�ߩ�����\n");
//			}


			//-------�s�Wú�ڳ���, ú�ڳ������--------//
//			if((xmlContBasicData["�X�����O�N�X"].FirstChild.OuterXml=="01")||(xmlContBasicData["�X�����O�N�X"].FirstChild.OuterXml=="09"))
//			{			
//				//InsertPayData();
//			}
//			else
//			{
//				Response.Write("�L���X�����O�N�X, �L�k �s�W�o���}�߳���, �o���}�ߩ�����");
//			}

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
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
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
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = @"INSERT INTO ia(ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat, ia_invno, ia_invdate, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti, ia_rtel, ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno) VALUES (@ia_syscd, @ia_iasdate, @ia_iasseq, @ia_iaitem, @ia_iano, @ia_refno, @ia_mfrno, @ia_pyno, @ia_pyseq, @ia_pyat, @ia_ivat, @ia_invno, @ia_invdate, @ia_fgitri, @ia_rnm, @ia_raddr, @ia_rzip, @ia_rjbti, @ia_rtel, @ia_fgnonauto, @ia_invcd, @ia_taxtp, @ia_status, @ia_cname, @ia_tel, @ia_contno); SELECT ia_iaid, ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat, ia_invno, ia_invdate, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti, ia_rtel, ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno FROM ia WHERE (ia_iano = @Select_ia_iano) AND (ia_syscd = @Select_ia_syscd)";
			this.sqlInsertCommand2.Connection = this.sqlConnection1;
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iasdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iasdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iasseq", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iasseq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iaitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iaitem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_refno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_refno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyseq", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyseq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyat", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyat", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_ivat", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_ivat", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_fgitri", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgitri", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rnm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rnm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_raddr", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_raddr", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rzip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rzip", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rjbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rjbti", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rtel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rtel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_fgnonauto", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgnonauto", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_taxtp", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_status", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_status", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_cname", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_cname", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_tel", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_tel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_contno", System.Data.SqlDbType.Char, 13, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_contno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_ia_syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlInsertCommand3
			// 
			this.sqlInsertCommand3.CommandText = @"INSERT INTO iad(iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, iad_fk4, iad_projno, iad_costctr, iad_desc, iad_qty, iad_amt, iad_unit, iad_uprice) VALUES (@iad_syscd, @iad_iano, @iad_iaditem, @iad_fk1, @iad_fk2, @iad_fk3, @iad_fk4, @iad_projno, @iad_costctr, @iad_desc, @iad_qty, @iad_amt, @iad_unit, @iad_uprice); SELECT iad_iadid, iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, iad_fk4, iad_projno, iad_costctr, iad_desc, iad_qty, iad_amt, iad_unit, iad_uprice FROM iad WHERE (iad_iaditem = @Select_iad_iaditem) AND (iad_iano = @Select_iad_iano) AND (iad_syscd = @Select_iad_syscd)";
			this.sqlInsertCommand3.Connection = this.sqlConnection1;
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iano", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iaditem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iaditem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk1", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk1", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk2", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk2", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk3", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk3", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk4", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk4", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_projno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_projno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_costctr", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_costctr", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_desc", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_desc", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_qty", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_qty", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_amt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_amt", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_unit", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_unit", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_uprice", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_uprice", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_iad_iaditem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iaditem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_iad_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iano", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_iad_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand3
			// 
			this.sqlUpdateCommand3.CommandText = @"UPDATE iad SET iad_syscd = @iad_syscd, iad_iano = @iad_iano, iad_iaditem = @iad_iaditem, iad_fk1 = @iad_fk1, iad_fk2 = @iad_fk2, iad_fk3 = @iad_fk3, iad_fk4 = @iad_fk4, iad_projno = @iad_projno, iad_costctr = @iad_costctr, iad_desc = @iad_desc, iad_qty = @iad_qty, iad_amt = @iad_amt, iad_unit = @iad_unit, iad_uprice = @iad_uprice WHERE (iad_iaditem = @Original_iad_iaditem) AND (iad_iano = @Original_iad_iano) AND (iad_syscd = @Original_iad_syscd) AND (iad_amt = @Original_iad_amt) AND (iad_costctr = @Original_iad_costctr) AND (iad_desc = @Original_iad_desc) AND (iad_fk1 = @Original_iad_fk1) AND (iad_fk2 = @Original_iad_fk2) AND (iad_fk3 = @Original_iad_fk3) AND (iad_fk4 = @Original_iad_fk4) AND (iad_projno = @Original_iad_projno) AND (iad_qty = @Original_iad_qty) AND (iad_unit = @Original_iad_unit) AND (iad_uprice = @Original_iad_uprice); SELECT iad_iadid, iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, iad_fk4, iad_projno, iad_costctr, iad_desc, iad_qty, iad_amt, iad_unit, iad_uprice FROM iad WHERE (iad_iaditem = @Select_iad_iaditem) AND (iad_iano = @Select_iad_iano) AND (iad_syscd = @Select_iad_syscd)";
			this.sqlUpdateCommand3.Connection = this.sqlConnection1;
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iano", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iaditem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iaditem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk1", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk1", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk2", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk2", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk3", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk3", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk4", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk4", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_projno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_projno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_costctr", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_costctr", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_desc", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_desc", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_qty", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_qty", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_amt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_amt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_unit", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_unit", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_uprice", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_uprice", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_iaditem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iaditem", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iano", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_amt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_amt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_costctr", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_costctr", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_desc", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_desc", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_fk1", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk1", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_fk2", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk2", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_fk3", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk3", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_fk4", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk4", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_projno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_projno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_qty", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_qty", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_unit", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_unit", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_uprice", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_uprice", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_iad_iaditem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iaditem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_iad_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iano", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_iad_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = @"SELECT ia_iaid, ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat, ia_invno, ia_invdate, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti, ia_rtel, ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno FROM ia";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT MAX(ia_iano) AS max_iano, ia_syscd, COUNT(*) AS CountNo FROM ia GROUP BY i" +
				"a_syscd HAVING (ia_syscd = \'C2\')";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT cont_contid, cont_syscd, cont_contno, cont_conttp, cont_bkcd, cont_signdate, cont_empno, cont_mfrno, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_sdate, cont_edate, cont_totjtm, cont_madejtm, cont_restjtm, cont_disc, cont_freetm, cont_fgclosed, cont_tottm, cont_pubtm, cont_resttm, cont_chgjtm, cont_custno, cont_totamt, cont_pubamt, cont_chgamt, cont_paidamt, cont_restamt, cont_clrtm, cont_menotm, cont_getclrtm, cont_oldcontno, cont_moddate, cont_fgpayonce, cont_xmldata, cont_modempno FROM c2_cont";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT iad_iadid, iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, ia" +
				"d_fk4, iad_projno, iad_costctr, iad_desc, iad_qty, iad_amt, iad_unit, iad_uprice" +
				" FROM iad WHERE (iad_syscd = \'C2\')";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = @"DELETE FROM ia WHERE (ia_iano = @ia_iano) AND (ia_syscd = @ia_syscd) AND (ia_cname = @ia_cname) AND (ia_contno = @ia_contno) AND (ia_fgitri = @ia_fgitri) AND (ia_fgnonauto = @ia_fgnonauto) AND (ia_iaid = @ia_iaid) AND (ia_iaitem = @ia_iaitem) AND (ia_iasdate = @ia_iasdate) AND (ia_iasseq = @ia_iasseq) AND (ia_invcd = @ia_invcd) AND (ia_invdate = @ia_invdate) AND (ia_invno = @ia_invno) AND (ia_ivat = @ia_ivat) AND (ia_mfrno = @ia_mfrno) AND (ia_pyat = @ia_pyat) AND (ia_pyno = @ia_pyno) AND (ia_pyseq = @ia_pyseq) AND (ia_raddr LIKE @ia_raddr) AND (ia_refno = @ia_refno) AND (ia_rjbti = @ia_rjbti) AND (ia_rnm = @ia_rnm) AND (ia_rtel = @ia_rtel) AND (ia_rzip = @ia_rzip) AND (ia_status = @ia_status) AND (ia_taxtp = @ia_taxtp) AND (ia_tel = @ia_tel)";
			this.sqlDeleteCommand2.Connection = this.sqlConnection1;
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_cname", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_cname", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_contno", System.Data.SqlDbType.Char, 13, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_contno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_fgitri", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgitri", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_fgnonauto", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgnonauto", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iaid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iaid", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iaitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iaitem", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iasdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iasdate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iasseq", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iasseq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invcd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invdate", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_ivat", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_ivat", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_mfrno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyat", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyat", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyseq", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyseq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_raddr", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_raddr", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_refno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_refno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rjbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rjbti", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rnm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rnm", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rtel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rtel", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rzip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rzip", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_status", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_status", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_taxtp", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_tel", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_tel", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDeleteCommand3
			// 
			this.sqlDeleteCommand3.CommandText = @"DELETE FROM iad WHERE (iad_iaditem = @iad_iaditem) AND (iad_iano = @iad_iano) AND (iad_syscd = @iad_syscd) AND (iad_amt = @iad_amt) AND (iad_costctr = @iad_costctr) AND (iad_desc = @iad_desc) AND (iad_fk1 = @iad_fk1) AND (iad_fk2 = @iad_fk2) AND (iad_fk3 = @iad_fk3) AND (iad_fk4 = @iad_fk4) AND (iad_iadid = @iad_iadid) AND (iad_projno = @iad_projno) AND (iad_qty = @iad_qty) AND (iad_unit = @iad_unit) AND (iad_uprice = @iad_uprice)";
			this.sqlDeleteCommand3.Connection = this.sqlConnection1;
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iaditem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iaditem", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iano", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_amt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_amt", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_costctr", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_costctr", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_desc", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_desc", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk1", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk1", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk2", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk2", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk3", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk3", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk4", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk4", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iadid", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iadid", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_projno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_projno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_qty", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_qty", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_unit", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_unit", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_uprice", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_uprice", System.Data.DataRowVersion.Original, null));
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
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT bk_bkid, bk_bkcd, bk_nm FROM book";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.DeleteCommand = this.sqlDeleteCommand2;
			this.sqlDataAdapter3.InsertCommand = this.sqlInsertCommand2;
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "ia", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("ia_iaid", "ia_iaid"),
																																																			new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd"),
																																																			new System.Data.Common.DataColumnMapping("ia_iasdate", "ia_iasdate"),
																																																			new System.Data.Common.DataColumnMapping("ia_iasseq", "ia_iasseq"),
																																																			new System.Data.Common.DataColumnMapping("ia_iaitem", "ia_iaitem"),
																																																			new System.Data.Common.DataColumnMapping("ia_iano", "ia_iano"),
																																																			new System.Data.Common.DataColumnMapping("ia_refno", "ia_refno"),
																																																			new System.Data.Common.DataColumnMapping("ia_mfrno", "ia_mfrno"),
																																																			new System.Data.Common.DataColumnMapping("ia_pyno", "ia_pyno"),
																																																			new System.Data.Common.DataColumnMapping("ia_pyseq", "ia_pyseq"),
																																																			new System.Data.Common.DataColumnMapping("ia_pyat", "ia_pyat"),
																																																			new System.Data.Common.DataColumnMapping("ia_ivat", "ia_ivat"),
																																																			new System.Data.Common.DataColumnMapping("ia_invno", "ia_invno"),
																																																			new System.Data.Common.DataColumnMapping("ia_invdate", "ia_invdate"),
																																																			new System.Data.Common.DataColumnMapping("ia_fgitri", "ia_fgitri"),
																																																			new System.Data.Common.DataColumnMapping("ia_rnm", "ia_rnm"),
																																																			new System.Data.Common.DataColumnMapping("ia_raddr", "ia_raddr"),
																																																			new System.Data.Common.DataColumnMapping("ia_rzip", "ia_rzip"),
																																																			new System.Data.Common.DataColumnMapping("ia_rjbti", "ia_rjbti"),
																																																			new System.Data.Common.DataColumnMapping("ia_rtel", "ia_rtel"),
																																																			new System.Data.Common.DataColumnMapping("ia_fgnonauto", "ia_fgnonauto"),
																																																			new System.Data.Common.DataColumnMapping("ia_invcd", "ia_invcd"),
																																																			new System.Data.Common.DataColumnMapping("ia_taxtp", "ia_taxtp"),
																																																			new System.Data.Common.DataColumnMapping("ia_status", "ia_status"),
																																																			new System.Data.Common.DataColumnMapping("ia_cname", "ia_cname"),
																																																			new System.Data.Common.DataColumnMapping("ia_tel", "ia_tel"),
																																																			new System.Data.Common.DataColumnMapping("ia_contno", "ia_contno")})});
			this.sqlDataAdapter3.UpdateCommand = this.sqlUpdateCommand2;
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = "UPDATE ia SET ia_syscd = @ia_syscd, ia_iasdate = @ia_iasdate, ia_iasseq = @ia_ias" +
				"seq, ia_iaitem = @ia_iaitem, ia_iano = @ia_iano, ia_refno = @ia_refno, ia_mfrno " +
				"= @ia_mfrno, ia_pyno = @ia_pyno, ia_pyseq = @ia_pyseq, ia_pyat = @ia_pyat, ia_iv" +
				"at = @ia_ivat, ia_invno = @ia_invno, ia_invdate = @ia_invdate, ia_fgitri = @ia_f" +
				"gitri, ia_rnm = @ia_rnm, ia_raddr = @ia_raddr, ia_rzip = @ia_rzip, ia_rjbti = @i" +
				"a_rjbti, ia_rtel = @ia_rtel, ia_fgnonauto = @ia_fgnonauto, ia_invcd = @ia_invcd," +
				" ia_taxtp = @ia_taxtp, ia_status = @ia_status, ia_cname = @ia_cname, ia_tel = @i" +
				"a_tel, ia_contno = @ia_contno WHERE (ia_iano = @Original_ia_iano) AND (ia_syscd " +
				"= @Original_ia_syscd) AND (ia_cname = @Original_ia_cname) AND (ia_contno = @Orig" +
				"inal_ia_contno) AND (ia_fgitri = @Original_ia_fgitri) AND (ia_fgnonauto = @Origi" +
				"nal_ia_fgnonauto) AND (ia_iaitem = @Original_ia_iaitem) AND (ia_iasdate = @Origi" +
				"nal_ia_iasdate) AND (ia_iasseq = @Original_ia_iasseq) AND (ia_invcd = @Original_" +
				"ia_invcd) AND (ia_invdate = @Original_ia_invdate) AND (ia_invno = @Original_ia_i" +
				"nvno) AND (ia_ivat = @Original_ia_ivat) AND (ia_mfrno = @Original_ia_mfrno) AND " +
				"(ia_pyat = @Original_ia_pyat) AND (ia_pyno = @Original_ia_pyno) AND (ia_pyseq = " +
				"@Original_ia_pyseq) AND (ia_raddr LIKE @Original_ia_raddr) AND (ia_refno = @Orig" +
				"inal_ia_refno) AND (ia_rjbti = @Original_ia_rjbti) AND (ia_rnm = @Original_ia_rn" +
				"m) AND (ia_rtel = @Original_ia_rtel) AND (ia_rzip = @Original_ia_rzip) AND (ia_s" +
				"tatus = @Original_ia_status) AND (ia_taxtp = @Original_ia_taxtp) AND (ia_tel = @" +
				"Original_ia_tel); SELECT ia_iaid, ia_syscd, ia_iasdate, ia_iasseq, ia_iaitem, ia" +
				"_iano, ia_refno, ia_mfrno, ia_pyno, ia_pyseq, ia_pyat, ia_ivat, ia_invno, ia_inv" +
				"date, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti, ia_rtel, ia_fgnonauto, ia_" +
				"invcd, ia_taxtp, ia_status, ia_cname, ia_tel, ia_contno FROM ia WHERE (ia_iano =" +
				" @Select_ia_iano) AND (ia_syscd = @Select_ia_syscd)";
			this.sqlUpdateCommand2.Connection = this.sqlConnection1;
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iasdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iasdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iasseq", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iasseq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iaitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iaitem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_refno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_refno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyseq", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyseq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyat", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyat", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_ivat", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_ivat", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_fgitri", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgitri", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rnm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rnm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_raddr", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_raddr", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rzip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rzip", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rjbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rjbti", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rtel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rtel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_fgnonauto", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgnonauto", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_taxtp", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_status", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_status", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_cname", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_cname", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_tel", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_tel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_contno", System.Data.SqlDbType.Char, 13, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_contno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_cname", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_cname", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_contno", System.Data.SqlDbType.Char, 13, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_contno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_fgitri", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgitri", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_fgnonauto", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgnonauto", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_iaitem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iaitem", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_iasdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iasdate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_iasseq", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iasseq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_invdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invdate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_invno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_ivat", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_ivat", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_mfrno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_pyat", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyat", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_pyno", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_pyseq", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyseq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_raddr", System.Data.SqlDbType.Text, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_raddr", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_refno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_refno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_rjbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rjbti", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_rnm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rnm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_rtel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rtel", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_rzip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rzip", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_status", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_status", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_taxtp", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_tel", System.Data.SqlDbType.Char, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_tel", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_ia_syscd", System.Data.SqlDbType.VarChar, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "ia", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("max_iano", "max_iano"),
																																																			new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd"),
																																																			new System.Data.Common.DataColumnMapping("CountNo", "CountNo")})});
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
				"l_cont_contno) AND (cont_syscd = @Original_cont_syscd) AND (cont_aucell = @Origi" +
				"nal_cont_aucell) AND (cont_auemail = @Original_cont_auemail) AND (cont_aufax = @" +
				"Original_cont_aufax) AND (cont_aunm = @Original_cont_aunm) AND (cont_autel = @Or" +
				"iginal_cont_autel) AND (cont_bkcd = @Original_cont_bkcd) AND (cont_chgamt = @Ori" +
				"ginal_cont_chgamt) AND (cont_chgjtm = @Original_cont_chgjtm) AND (cont_clrtm = @" +
				"Original_cont_clrtm) AND (cont_conttp = @Original_cont_conttp) AND (cont_custno " +
				"= @Original_cont_custno) AND (cont_disc = @Original_cont_disc) AND (cont_edate =" +
				" @Original_cont_edate) AND (cont_empno = @Original_cont_empno) AND (cont_fgclose" +
				"d = @Original_cont_fgclosed) AND (cont_fgpayonce = @Original_cont_fgpayonce) AND" +
				" (cont_freetm = @Original_cont_freetm) AND (cont_getclrtm = @Original_cont_getcl" +
				"rtm) AND (cont_madejtm = @Original_cont_madejtm) AND (cont_menotm = @Original_co" +
				"nt_menotm) AND (cont_mfrno = @Original_cont_mfrno) AND (cont_moddate = @Original" +
				"_cont_moddate) AND (cont_modempno = @Original_cont_modempno) AND (cont_oldcontno" +
				" = @Original_cont_oldcontno) AND (cont_paidamt = @Original_cont_paidamt) AND (co" +
				"nt_pubamt = @Original_cont_pubamt) AND (cont_pubtm = @Original_cont_pubtm) AND (" +
				"cont_restamt = @Original_cont_restamt) AND (cont_restjtm = @Original_cont_restjt" +
				"m) AND (cont_resttm = @Original_cont_resttm) AND (cont_sdate = @Original_cont_sd" +
				"ate) AND (cont_signdate = @Original_cont_signdate) AND (cont_totamt = @Original_" +
				"cont_totamt) AND (cont_totjtm = @Original_cont_totjtm) AND (cont_tottm = @Origin" +
				"al_cont_tottm) AND (cont_xmldata LIKE @Original_cont_xmldata); SELECT cont_conti" +
				"d, cont_syscd, cont_contno, cont_conttp, cont_bkcd, cont_signdate, cont_empno, c" +
				"ont_mfrno, cont_aunm, cont_autel, cont_aufax, cont_aucell, cont_auemail, cont_sd" +
				"ate, cont_edate, cont_totjtm, cont_madejtm, cont_restjtm, cont_disc, cont_freetm" +
				", cont_fgclosed, cont_tottm, cont_pubtm, cont_resttm, cont_chgjtm, cont_custno, " +
				"cont_totamt, cont_pubamt, cont_chgamt, cont_paidamt, cont_restamt, cont_clrtm, c" +
				"ont_menotm, cont_getclrtm, cont_oldcontno, cont_moddate, cont_fgpayonce, cont_xm" +
				"ldata, cont_modempno FROM c2_cont WHERE (cont_contno = @Select_cont_contno) AND " +
				"(cont_syscd = @Select_cont_syscd)";
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
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_aucell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aucell", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_auemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_auemail", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_aufax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aufax", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_aunm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_aunm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_autel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_autel", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_bkcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_bkcd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_chgamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgamt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_chgjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_chgjtm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_clrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_clrtm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_conttp", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_conttp", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_custno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_disc", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_disc", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_edate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_edate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_empno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_empno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_fgclosed", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgclosed", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_fgpayonce", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_fgpayonce", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_freetm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_freetm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_getclrtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_getclrtm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_madejtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_madejtm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_menotm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_menotm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_mfrno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_moddate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_modempno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_modempno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_oldcontno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_oldcontno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_paidamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_paidamt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_pubamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubamt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_pubtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_pubtm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_restamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restamt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_restjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_restjtm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_resttm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_resttm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_sdate", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_sdate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_signdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_signdate", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_totamt", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totamt", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_totjtm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_totjtm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_tottm", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_tottm", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_xmldata", System.Data.SqlDbType.NText, 150000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_xmldata", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "book", new System.Data.Common.DataColumnMapping[] {
																																																			  new System.Data.Common.DataColumnMapping("bk_bkid", "bk_bkid"),
																																																			  new System.Data.Common.DataColumnMapping("bk_bkcd", "bk_bkcd"),
																																																			  new System.Data.Common.DataColumnMapping("bk_nm", "bk_nm")})});
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.DeleteCommand = this.sqlDeleteCommand3;
			this.sqlDataAdapter4.InsertCommand = this.sqlInsertCommand3;
			this.sqlDataAdapter4.SelectCommand = this.sqlSelectCommand4;
			this.sqlDataAdapter4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "iad", new System.Data.Common.DataColumnMapping[] {
																																																			 new System.Data.Common.DataColumnMapping("iad_iadid", "iad_iadid"),
																																																			 new System.Data.Common.DataColumnMapping("iad_syscd", "iad_syscd"),
																																																			 new System.Data.Common.DataColumnMapping("iad_iano", "iad_iano"),
																																																			 new System.Data.Common.DataColumnMapping("iad_iaditem", "iad_iaditem"),
																																																			 new System.Data.Common.DataColumnMapping("iad_fk1", "iad_fk1"),
																																																			 new System.Data.Common.DataColumnMapping("iad_fk2", "iad_fk2"),
																																																			 new System.Data.Common.DataColumnMapping("iad_fk3", "iad_fk3"),
																																																			 new System.Data.Common.DataColumnMapping("iad_fk4", "iad_fk4"),
																																																			 new System.Data.Common.DataColumnMapping("iad_projno", "iad_projno"),
																																																			 new System.Data.Common.DataColumnMapping("iad_costctr", "iad_costctr"),
																																																			 new System.Data.Common.DataColumnMapping("iad_desc", "iad_desc"),
																																																			 new System.Data.Common.DataColumnMapping("iad_qty", "iad_qty"),
																																																			 new System.Data.Common.DataColumnMapping("iad_amt", "iad_amt"),
																																																			 new System.Data.Common.DataColumnMapping("iad_unit", "iad_unit"),
																																																			 new System.Data.Common.DataColumnMapping("iad_uprice", "iad_uprice")})});
			this.sqlDataAdapter4.UpdateCommand = this.sqlUpdateCommand3;
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
		

		//-------�s�W�o���}�߳���, �o���}�ߩ�����--------//
		private void InsertIAData()
		{
			// �] XmlDoc & root �w�ŧi�� global �ܼ�, �B�b Page_Load �w��X, �G���ΦA�ŧi�@��
//			root = XmlDoc.DocumentElement;
//			// �N root ��xml���e��ܥX��, ���ˬd��
//			//Response.Write(root.OuterXml);
//			
//			XmlNode xmlMain = XmlDoc.SelectSingleNode("/root");
//			XmlNode xmlHeader = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e");
//			
//			XmlNode xmlMfrData = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e/�t�Ӹ��");
//			XmlNode xmlCustData = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e/�Ȥ���");
//			XmlNode xmlContBasicData = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e/�X���Ѱ򥻸��");
//			XmlNode xmlContDetail = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e/�X���ѲӸ`");
//			XmlNode xmlInvRec = XmlDoc.SelectSingleNode("/root/�o���t�Ӹ��");
//			XmlNode xmlMazRec = XmlDoc.SelectSingleNode("/root/���x����H���");
//			XmlNode xmlAdContactor = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e/�s�i�p���H���");
//			
//			XmlNode xmlAdpubData = XmlDoc.SelectSingleNode("/root/�X���Ѹ����Z�n���");
//			XmlNode xmlAdpubItems = XmlDoc.SelectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�");
//			XmlNode xmlAdpubItemInvRec = XmlDoc.SelectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�o���t�Ӧ���H�Ӹ`");
//			//XmlNode xmlAdpubItemDetails = XmlDoc.SelectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�����Ӹ`");
			
			
//			DataSet ds2 = new DataSet();
//			this.sqlDataAdapter2.Fill(ds2, "ia");
//			DataView dv2 = ds2.Tables["ia"].DefaultView;
//			//Response.Write("Count= " + dv2.Count + "\n");
//
//			string	iano = "";
//			if(dv2.Count != 0)
//			{
//				iano = dv2[0].Row["max_iano"].ToString();
//				//iano = Convert.ToString(Convert.ToInt32(dv2[0]["max_iano"]) + 1);
//			}
//			else
//			{
//				//�Y dv2 �L���, �h���w�_�l�s���� �K�X�y����, �p 00000000
//				iano = "00000000";
//			}
			//Response.Write("iano= " + iano + "\n");
			
			// ��X�褸�~�����X, ��J ia �K�X���e��X, ���� 2�X�褸�~�X+6�X�y����
//			string fy=System.DateTime.Today.Year.ToString();
			//Response.Write("fy= " + fy + "\n");
//			if(iano.Substring(0,2)==fy.Substring(2,2))
//				iano = Convert.ToString(Int32.Parse(iano)+1);
//			else
//				iano=fy.Substring(2,2)+"000001";
			//Response.Write("iano= " + iano + "<br>");
			
			// ���y������ 0 ���ʧ@
//			for(int j=0; j<8-iano.Length; j++)
//				iano="0"+iano;
			
			//------- �s�W�o���}�߳��� sqlDataAdapter3 --------//
			//Response.Write("xmlAdpubData.ChildNodes.Count= " + xmlAdpubData.ChildNodes.Count + "\n\n");
//			for(int i=0; i<xmlAdpubData.ChildNodes.Count; i++)
//			{
//				//Response.Write("xmlAdpubData.ChildNodes(" + i + ").�o������H�m�W= " + xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("�o���t�Ӧ���H�Ӹ`").ChildNodes.Item(0).SelectSingleNode("�o������H�m�W").InnerText + "\n");
//				//Response.Write("xmlAdpubData.ChildNodes(" + i + ").xml= " + xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("�o���t�Ӧ���H�Ӹ`").OuterXml + "\n\n\n");
//				//Response.Write("�� " + (i+1) + "��:" + xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("�o���t�Ӧ���H�Ӹ`").ChildNodes.Item(0).SelectSingleNode("�o������H�m�W").InnerText + ", ia=" + (i+1) + ", iad=" + i + "\n");
//				
//				// �ŧi ArrayList(�m�W, �өm�W��XML Data)
//				// Create and initialize a new ArrayList.
//				//ArrayList myAL = new ArrayList();
//				//myAL.Add(xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("�o���t�Ӧ���H�Ӹ`").ChildNodes.Item(0).SelectSingleNode("�o������H�m�W").InnerText);
//				// Display the properties and values of the ArrayList.
//				//Console.WriteLine("myAL=" + myAL.ToString());
//				
//				// Create and initialize a new SortedList.
//				SortedList mySL = new SortedList();
//				mySL.Add(xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("�o���t�Ӧ���H�Ӹ`").ChildNodes.Item(0).SelectSingleNode("�o������H�m�W").InnerText, xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("�o���t�Ӧ���H�Ӹ`").OuterXml);
//				// Display the properties and values of the SortedList.
//				Console.WriteLine( "Keys and Values:" );
//				PrintKeysAndValues( mySL );
//				
//			}
			//Response.Write("xmlAdpubItemInvRec= \n" + "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlAdpubItemInvRec.OuterXml + "\n");
			//this.sqlDataAdapter3.InsertCommand = sqlInsertCommand2
			
//			this.sqlInsertCommand2.Parameters["@ia_iano"].Value=iano;
//			this.sqlInsertCommand2.Parameters["@ia_syscd"].Value="C2";
//			this.sqlInsertCommand2.Parameters["@ia_refno"].Value="C2"+iano;
//			this.sqlInsertCommand2.Parameters["@ia_mfrno"].Value=xmlMfrData["�t�Ӳνs"].FirstChild.OuterXml;
//			
			// ����l��(�w�])����, �o�ǭȬO��ᦳ�ݨD��, �A�g�^
//			this.sqlInsertCommand2.Parameters["@ia_iasdate"].Value = "";
//			this.sqlInsertCommand2.Parameters["@ia_iasseq"].Value = "";
//			this.sqlInsertCommand2.Parameters["@ia_iaitem"].Value = "";
//			this.sqlInsertCommand2.Parameters["@ia_pyno"].Value = "";
//			this.sqlInsertCommand2.Parameters["@ia_pyseq"].Value = "";
//			this.sqlInsertCommand2.Parameters["@ia_invno"].Value = "";
//			this.sqlInsertCommand2.Parameters["@ia_invdate"].Value = "";
//			this.sqlInsertCommand2.Parameters["@ia_rjbti"].Value = "";
//			this.sqlInsertCommand2.Parameters["@ia_cname"].Value = "";
//			this.sqlInsertCommand2.Parameters["@ia_tel"].Value = "";
//			this.sqlInsertCommand2.Parameters["@ia_contno"].Value = "";
//			
//			int TotalAmt = 0;
//			TotalAmt = Convert.ToInt32(xmlContDetail["�X���`���B"].FirstChild.InnerText);
//			//Response.Write("TotalAmt= " + TotalAmt + "\n");
//			this.sqlInsertCommand2.Parameters["@ia_pyat"].Value=xmlContDetail["�X���`���B"].FirstChild.OuterXml;
//			int amt_iv=(int)Math.Round((float)TotalAmt/1.05F);
//			//Response.Write("amt_iv= " + amt_iv + "\n");
//			this.sqlInsertCommand2.Parameters["@ia_ivat"].Value=amt_iv.ToString();
//			
//			if(xmlContBasicData["�|�Ҥ����O"].FirstChild.OuterXml=="06" || xmlContBasicData["�|�Ҥ����O"].FirstChild.OuterXml=="07")
//				this.sqlInsertCommand2.Parameters["@ia_fgitri"].Value = xmlContBasicData["�|�Ҥ����O"].FirstChild.OuterXml;
//			else
//				this.sqlInsertCommand2.Parameters["@ia_fgitri"].Value = "";
//			
//			this.sqlInsertCommand2.Parameters["@ia_rnm"].Value = xmlInvRec["�H�o������H�m�W"].FirstChild.OuterXml;
//			this.sqlInsertCommand2.Parameters["@ia_raddr"].Value = xmlInvRec["�H�o���a�}"].FirstChild.OuterXml;
//			this.sqlInsertCommand2.Parameters["@ia_rzip"].Value = xmlInvRec["�H�o���l���ϸ�"].FirstChild.OuterXml;
//			
//			if(xmlInvRec["�H�o������H¾��"].FirstChild!=null)
//				this.sqlInsertCommand2.Parameters["@ia_rjbti"].Value = xmlInvRec["�o������H¾��"].FirstChild.OuterXml;
//			else
//				this.sqlInsertCommand2.Parameters["@ia_rjbti"].Value ="";
//			if(xmlInvRec["�H�o������H�q��"].FirstChild!=null)
//				this.sqlInsertCommand2.Parameters["@ia_rtel"].Value = xmlInvRec["�H�o������H�q��"].FirstChild.OuterXml;
//			else
//				this.sqlInsertCommand2.Parameters["@ia_rtel"].Value = "";
//			
//			this.sqlInsertCommand2.Parameters["@ia_fgnonauto"].Value = "0";
//			this.sqlInsertCommand2.Parameters["@ia_invcd"].Value = xmlContBasicData["�o�����O�N�X"].FirstChild.OuterXml;
//			this.sqlInsertCommand2.Parameters["@ia_taxtp"].Value = xmlContBasicData["�o���ҵ|�O�N�X"].FirstChild.OuterXml;
//			this.sqlInsertCommand2.Parameters["@ia_status"].Value = "1";
//			this.sqlInsertCommand2.Parameters["@ia_cname"].Value = "test�d";
//			this.sqlInsertCommand2.Parameters["@ia_tel"].Value = "03-";
//			this.sqlInsertCommand2.Parameters["@ia_contno"].Value = xmlContBasicData["�X���ѽs��"].FirstChild.OuterXml;
//			Response.Write("�ӿ�~�ȭ��u��= " + xmlContBasicData["�ӿ�~�ȭ��u��"].FirstChild.OuterXml + "\n");
			//Response.Write("ia_cname= " + xmlContBasicData["�ӿ�~�ȭ��u��"].FirstChild.OuterXml + "\n");
			//Response.Write("ia_tel= " + xmlContBasicData["�ӿ�~�ȭ��u��"].FirstChild.OuterXml  + "\n");
//			Response.Write("ia_contno= " + xmlContBasicData["�X���ѽs��"].FirstChild.OuterXml  + "\n");
			
			// �w�q PK ����, �_�h�L�k���J DB
//			this.sqlInsertCommand2.Parameters["@Select_ia_iano"].Value=iano;
//			this.sqlInsertCommand2.Parameters["@Select_ia_syscd"].Value="C2";
			
			// ���� sqlInsertCommand2: ���J �o���}�߳� ia table
//			this.sqlInsertCommand2.Connection.Open();
//			this.sqlInsertCommand2.ExecuteNonQuery();
//			this.sqlInsertCommand2.Connection.Close();
			
			
			
			//------- �s�W�o���}�ߩ����� sqlDataAdapter4 --------//
			// this.sqlDataAdapter4.InsertCommand = sqlInsertCommand3
			//Response.Write("xmlAdpubData.count= " + xmlAdpubData.ChildNodes.Count + "\n");
//			for(int i=0; i<xmlAdpubData.ChildNodes.Count; i++)
//			{
//				this.sqlInsertCommand3.Parameters["@iad_syscd"].Value = "C2";
//				this.sqlInsertCommand3.Parameters["@iad_iano"].Value = iano;
//				this.sqlInsertCommand3.Parameters["@iad_iaditem"].Value = Convert.ToString(i+1);
//				this.sqlInsertCommand3.Parameters["@iad_fk1"].Value = xmlContBasicData["�t�ΥN�X"].FirstChild.OuterXml;
//				this.sqlInsertCommand3.Parameters["@iad_fk2"].Value = xmlContBasicData["�X���ѽs��"].FirstChild.OuterXml;
//				this.sqlInsertCommand3.Parameters["@iad_fk3"].Value = xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("�Z�n�~��").InnerText;
//				this.sqlInsertCommand3.Parameters["@iad_fk4"].Value = xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("�����Ǹ�").InnerText;
//				this.sqlInsertCommand3.Parameters["@iad_projno"].Value = xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("�p���N��").InnerText;
//				this.sqlInsertCommand3.Parameters["@iad_costctr"].Value = xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("��������").InnerText;
				
				// ����X ���y���O�W�� bk_nm
//				DataSet ds5 = new DataSet();
//				this.sqlDataAdapter5.Fill(ds5, "book");
//				DataView dv5 = ds5.Tables["book"].DefaultView;
//				dv5 = ds5.Tables["book"].DefaultView;
//				dv5.RowFilter = "bk_bkcd='" + xmlContBasicData["���y���O�N�X"].FirstChild.OuterXml + "'";
//				this.sqlInsertCommand3.Parameters["@iad_desc"].Value = dv5[0].Row["bk_nm"].ToString().Trim() + "�q��";

				// iad_desc �~�W = ���y���O�W�� + �Z�n�~��
//				if((xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("�Z�n�~��").InnerText != ""))
//				{
//					if((xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("�Z�n�~��").InnerText.Length>=4))
//					{
//						this.sqlInsertCommand3.Parameters["@iad_desc"].Value = this.sqlInsertCommand3.Parameters["@iad_desc"].Value + " " + xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("�Z�n�~��").InnerText;
//						//Response.Write(this.sqlInsertCommand3.Parameters["@iad_desc"].Value + "\n");
//					}
//				}
				
				// �C��������ƪ����Ƭ� 1��, �G�� ia ���ƶq
//				this.sqlInsertCommand3.Parameters["@iad_qty"].Value = "1";
//				this.sqlInsertCommand3.Parameters["@iad_unit"].Value = "";
//				this.sqlInsertCommand3.Parameters["@iad_uprice"].Value = 0.0;
				
				//Response.Write("Adamt= " + xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("�����Ӹ`/�����s�i���B").InnerText + "\n");
//				this.sqlInsertCommand3.Parameters["@iad_amt"].Value = xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("�����Ӹ`/�����s�i���B").InnerText;
				

				// �w�q PK ����, �_�h�L�k���J DB
//				this.sqlInsertCommand3.Parameters["@Select_iad_iaditem"].Value=Convert.ToString(i+1);
//				this.sqlInsertCommand3.Parameters["@Select_iad_iano"].Value=iano;
//				this.sqlInsertCommand3.Parameters["@Select_iad_syscd"].Value="C2";

				// ���� sqlInsertCommand3: ���J �o���}�߳���� iad table
//				this.sqlInsertCommand3.Connection.Open();
//				this.sqlInsertCommand3.ExecuteNonQuery();
//				this.sqlInsertCommand3.Connection.Close();
//			}

		}
		

		//-------�s�Wú�ڳ���, ú�ڳ������--------//
//		private void InsertPayData()
//		{
//			// �] XmlDoc & root �w�ŧi�� global �ܼ�, �B�b Page_Load �w��X, �G���ΦA�ŧi�@��
//			root = XmlDoc.DocumentElement;
//			// �N root ��xml���e��ܥX��, ���ˬd��
//			//Response.Write(root.OuterXml);
//			
//			XmlNode ItemlMain = XmlDoc.SelectSingleNode("/root");
//			XmlNode ItemHeader = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e");
//			
//			XmlNode ItemMfrData = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e/�t�Ӹ��");
//			XmlNode ItemCustData = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e/�Ȥ���");
//			XmlNode ItemContBasicData = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e/�X���Ѱ򥻸��");
//			XmlNode ItemContDetail = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e/�X���ѲӸ`");
//			XmlNode ItemInvRec = XmlDoc.SelectSingleNode("/root/�o���t�Ӹ��");
//			XmlNode ItemMazRec = XmlDoc.SelectSingleNode("/root/���x����H���");
//			XmlNode ItemAdContactor = XmlDoc.SelectSingleNode("/root/�X���Ѥ��e/�s�i�p���H���");
//			
//			XmlNode ItemAdpubData = XmlDoc.SelectSingleNode("/root/�X���Ѹ����Z�n���");
//			XmlNode ItemAdpubItems = XmlDoc.SelectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�");
//			XmlNode ItemAdpubItemInvRec = XmlDoc.SelectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�o���t�Ӧ���H�Ӹ`");
//			//XmlNode ItemAdpubItemDetails = XmlDoc.SelectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�����Ӹ`");
//			
//		}
		

//		public static void PrintKeysAndValues( SortedList myList )  
//		{
//			Console.WriteLine( "\t-KEY-\t-VALUE-" );
//			//Response.Write( "\t-KEY-\t-VALUE-" );
//			for ( int i = 0; i < myList.Count; i++ )  
//			{
//				Console.WriteLine( "\t{0}:\t{1}", myList.GetKey(i), myList.GetByIndex(i) );
//				//Response.Write( "\t{0}:\t{1}", myList.GetKey(i), myList.GetByIndex(i) );
//			}
//			Console.WriteLine();
//			//Response.Write();
//		}
		
		
	}
}
