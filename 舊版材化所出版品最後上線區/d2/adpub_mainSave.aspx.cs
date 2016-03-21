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
	/// Summary description for adpub_mainSave.
	/// </summary>
	public class adpub_mainSave : System.Web.UI.Page
	{

		// �ŧi xml��Ƭ� global, �n����L�{���i�H�I�s
		XmlDocument XmlDoc;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCommand2;
		XmlElement root;
		
		
		public adpub_mainSave()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			if (!Page.IsPostBack)
			{
				Response.Expires=0;
				
				// ����: ���N�ǹL�Ӫ� Request.InputStream ��X���ɮ� test555.xml �Ӱ��ˬd
				// �q�L�F������, �A�}�l�U�����{��
				// Request.SaveAs("c:\\test_adpub_mainSave.xml", false);
				
				
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
				
								
				// ���w��s���s��-�� xml��� ��J, �� sqlCommand2 �ǳƦs�J��Ʈw c2_cont
				// �`�N: �Ш� Web Form Designer generated code �̭ק� sqlCommand2 �H�U @�ܼ� ����ƫ��A �� Variant �אּ�A�����A (�p Char)
				this.sqlCommand2.Parameters["@cont_moddate"].Value = Convert.ToString(xmlContBasicData["�̫�ק���"].FirstChild.OuterXml);
				this.sqlCommand2.Parameters["@cont_xmldata"].Value = "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlMain.OuterXml;
				this.sqlCommand2.Parameters["@cont_modempno"].Value = Convert.ToString(xmlContBasicData["�ק�~�ȭ��u��"].FirstChild.OuterXml);
				this.sqlCommand2.Parameters["@cont_contno"].Value = Convert.ToString(xmlContBasicData["�X���ѽs��"].FirstChild.OuterXml);
				
				// �ˬd��X��
				//Response.Write("@cont_moddate= " + this.sqlCommand2.Parameters["@cont_moddate"].Value + "\n");
				//Response.Write("@cont_xmldata= " + this.sqlCommand2.Parameters["@cont_xmldata"].Value + "\n");
				//Response.Write("@cont_modempno= " + this.sqlCommand2.Parameters["@cont_modempno"].Value + "\n");
				//Response.Write("@cont_contno= " + this.sqlCommand2.Parameters["@cont_contno"].Value + "\n");
				
				
				// ���� sqlCommand2 �x�s�ק�: �X���� ��� c2_cont
				this.sqlCommand2.Connection.Open();
				bool ResultFlag2;
				try
				{
					this.sqlCommand2.ExecuteNonQuery();
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
					Response.Write("�x�s�ק�X�����ɦ��\!\n\n");
				}
				else  
				{
					Response.Write("�x�s�ק�X�����ɥ���!\n\n");
				}
				

				// xml/Stored Procedure �ϥ� ExecuteReader() �覡; �@��ϥ� ExecuteNonQuery() �覡
				// ����.cs, ���Y�����I�s using System.Data.SqlClient, �~��ϥ� SqlDataReader
				
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
				this.sqlCommand1.Parameters["@syscd"].Value=xmlContBasicData["�t�ΥN�X"].FirstChild.OuterXml;
				this.sqlCommand1.Parameters["@contno"].Value=xmlContBasicData["�X���ѽs��"].FirstChild.OuterXml;
				// ���B @XML �O�I�s�� xmlAdpubData, �D xmlMain
				this.sqlCommand1.Parameters["@XML"].Value="<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlAdpubData.OuterXml;
			
				// �ˬd�����Ĥ@�����Z�n�~��O�_����, �A�P�_�O�_�s�W�J c2_pub table ��
				//Response.Write("xmlAdpubData.ChildNodes.Count= " + xmlAdpubData.ChildNodes.Count + "\n");
				//Response.Write("xmlAdpubData.FirstChild.InnerText= " + xmlAdpubData.FirstChild.SelectSingleNode("�Z�n�~��").InnerText + "\n");
				//if(xmlAdpubData.ChildNodes.Count>=1 && xmlAdpubData.FirstChild.SelectSingleNode("�Z�n�~��").InnerText != "")
				if(xmlAdpubData.FirstChild.SelectSingleNode("�Z�n�~��").InnerText != "")
				{					
					//Response.Write("xmlAdpubData.OuterXml= " + xmlAdpubData.OuterXml + "\n");
					//Response.Write("�����Ĥ@���Z�n�~�뤣����, �s�W������Ƥ�, �еy��!!!\n");
					
					// ���� sqlCommand1 �x�s�ק�: ���� ��� c2_pub
					this.sqlCommand1.Connection.Open();				
					bool ResultFlag3;
					try
					{
						SqlDataReader myReader1=this.sqlCommand1.ExecuteReader();
						myReader1.Read();
						myReader1.Close();
						ResultFlag3=true;
					}
					catch(System.Data.SqlClient.SqlException ex3)
					{
						ResultFlag3=false;
						Response.Write(ex3.Message + "\n");
					}
					finally
					{
						this.sqlCommand1.Connection.Close();			
					}
				
					// ��X���浲�G
					if(ResultFlag3)
					{
						Response.Write("�x�s�ק︨���ɦ��\!\n\n");
					}
					else  
					{
						Response.Write("�x�s�ק︨���ɥ���!\n\n");
					}
					
				}
				else
				{
					//Response.Write("xmlAdpubData.OuterXml= " + xmlAdpubData.OuterXml + "\n");
					Response.Write("�����Ĥ@���Z�n�~�묰��, �N���s�W�ܸ�����!!!\n");
				}
				
				// ��}�B�z
				//Response.Redirect("cont_SaveMessage.aspx?str='adpub_mainSave'&ResultFlag2=" & ResultFlag2 & "&ResultFlag1=" & ResultFlag1);
				

			// ���� if (!Page.IsPostBack)
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
			this.sqlCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			// 
			// sqlCommand2
			// 
			this.sqlCommand2.CommandText = "UPDATE c2_cont SET cont_moddate = @cont_moddate, cont_modempno = @cont_modempno, " +
				"cont_xmldata = @cont_xmldata WHERE (cont_syscd = \'C2\') AND (cont_contno = @cont_" +
				"contno)";
			this.sqlCommand2.Connection = this.sqlConnection1;
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_modempno", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_modempno", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_xmldata", System.Data.SqlDbType.NText, 150000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlConnection1
			// 
			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "dbo.sp_c2_cont_newSave_pub";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@XML", System.Data.SqlDbType.Char, 8000, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
