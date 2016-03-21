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
// SQLCommand
using System.Data.SqlClient;
// WebApplication Virables - Web.config
using System.Configuration;

namespace MRLPub.d2
{
	/// <summary>
	/// Summary description for adpub_act3.
	/// </summary>
	public class adpub_act3 : System.Web.UI.Page
	{
		System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationSettings.AppSettings;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCommand3;
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;

		// �ŧi xml��Ƭ� global, �n����L�{���i�H�I�s
		XmlDocument XmlDoc;
		XmlElement root;
		XmlDocument XmlDocCont;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		XmlElement rootCont;

	
		public adpub_act3()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
			
			if(!Page.IsPostBack)
			{
				Response.Expires=0;

				// ����: ���N�ǹL�Ӫ� Request.InputStream ��X���ɮ� test555.xml �Ӱ��ˬd
				// �q�L�F������, �A�}�l�U�����{��
				//Request.SaveAs("c:\\test_adpub_act3.xml", false);
				
				// �}�l�B�z�{����: �N�ǤJ�� XML ��� => �s�ܸ�Ʈw�� ---------------
				XmlDoc = new System.Xml.XmlDocument();
				XmlDoc.Load(Request.InputStream);
				root = XmlDoc.DocumentElement;
				
				// �N root ��xml���e��ܥX��, ���ˬd��
				//Response.Write(root.OuterXml);
				
				XmlNode xmlItem = XmlDoc.SelectSingleNode("/root");
				//Response.Write(xmlItem.OuterXml);
				
				
				// ��X xmlItem �`���� (�h�Y���ť� node �G��)
				int length = xmlItem.ChildNodes.Count - 2;
				//Response.Write("length= " + length + "\n");
				
				// Step 1 - ��X �U������Ƥ��s���� PageNo �����g�JDB c2_pub ��
				string PageNo = "";
				string sqlcmd1 = "";
				string sqlcmd2 = "";
				for(int i=0; i<=length; i++)
				{
					// ��X�D�ť� nodes ������
					if(xmlItem.ChildNodes.Item(i).SelectSingleNode("����").InnerText != "")
					{
						PageNo = xmlItem.ChildNodes.Item(i).SelectSingleNode("����").InnerText;
						//Response.Write("PageNo= " + PageNo + "\n");
						
						// �H�U�G�ؤ覡���i��s���: ��k�@������� server �귽, �]�b client �ݧY�ɰ�
						// ��k�@: �}�l�� xml���, �N�s������ �������� update sql statment (�ٽu�W client �� update), �Ӧs�J��Ʈw table ��
						// ��X���n����, �H���� sqlcmd1 ����s�ʧ@
						string sqlsyscd = "C2";
						string sqlcontno = xmlItem.ChildNodes.Item(i).SelectSingleNode("�X���ѽs��").InnerText;
						string sqlyyyymm = xmlItem.ChildNodes.Item(i).SelectSingleNode("�Z�n�~��").InnerText;
						string sqlpubseq = xmlItem.ChildNodes.Item(i).SelectSingleNode("�����Ǹ�").InnerText;
						//Response.Write("sqlsyscd= " + sqlsyscd + ", ");
						//Response.Write("sqlcontno= " + sqlcontno + ", ");
						//Response.Write("sqlyyyymm= " + sqlyyyymm + ", ");
						//Response.Write("sqlpubseq= " + sqlpubseq + "\n");

						int sqlpgno = int.Parse(PageNo);
						if(sqlpgno < 10)
							PageNo = "0" + sqlpgno;
						////Response.Write("sqlpgno= " + sqlpgno + ", ");
						////Response.Write("PageNo= " + PageNo + "\n");
						
						
						// ��X��L���
						string chgbkcd = xmlItem.ChildNodes.Item(i).SelectSingleNode("��Z���y�N�X").InnerText;
						if(chgbkcd=="�u�����x")
							chgbkcd = "01";
						else if(chgbkcd=="�q�����x")
							chgbkcd = "02";
						string chgjno = xmlItem.ChildNodes.Item(i).SelectSingleNode("��Z���O").InnerText;
						string chgjbkno = xmlItem.ChildNodes.Item(i).SelectSingleNode("��Z���X").InnerText;
						string fgrechg = xmlItem.ChildNodes.Item(i).SelectSingleNode("��Z���X�����O").InnerText;
						string njtpcd = xmlItem.ChildNodes.Item(i).SelectSingleNode("�s�Z�s�k�N�X").InnerText;
						//Response.Write("chgbkcd= " + chgbkcd + ", ");
						//Response.Write("chgjno= " + chgjno + ", ");
						//Response.Write("chgjbkno= " + chgjbkno + ", ");
						//Response.Write("fgrechg= " + fgrechg + ", ");
						//Response.Write("njtpcd= " + njtpcd + "\n");
						
						// �T�{ myCommand ����s���O���e - sqlcmd1: �w�q�b for loop ���e
						sqlcmd1 = " UPDATE c2_pub ";
						sqlcmd1 = sqlcmd1 + " SET pub_pgno = " + PageNo;
						//sqlcmd1 = sqlcmd1 + " SET pub_pgno = " + PageNo + ", pub_chgbkcd = '" + chgbkcd  + "', pub_chgjno = '" + chgjno + "', pub_chgjbkno = '" + chgjbkno + "', pub_fgrechg = '" + fgrechg + "', pub_njtpcd = '" + njtpcd + "'";
						sqlcmd1 = sqlcmd1 + " WHERE (pub_syscd = 'C2') AND (pub_contno = '" + sqlcontno + "') AND (pub_yyyymm = '" + sqlyyyymm + "') AND (pub_pubseq = '" + sqlpubseq + "')";
						//Response.Write("sqlcmd1= " + sqlcmd1 + "\n\n");
						
						// ���� myCommand (myCommand �O���� sqlCommand1: sp_c2_adpub_act3_pub ) ��s��Ʈw: ���� ��� c2_pub
						SqlCommand myCommand = new SqlCommand(sqlcmd1, sqlConnection1);
						myCommand.Connection = sqlConnection1;
						myCommand.Connection.Open();
						bool ResultFlag1;
						try
						{
							myCommand.ExecuteNonQuery();
							ResultFlag1=true;
						}
						catch(System.Data.SqlClient.SqlException ex1)
						{
							ResultFlag1=false;
							Response.Write(ex1.Message + "\n");
						}
						finally
						{
							this.sqlConnection1.Close();
						}
						
						// ��X���浲�G
						if(ResultFlag1)
						{
							Response.Write("��s�����ɤ��������\!\n");
						}
						else  
						{
							Response.Write("��s�����ɤ���������!\n");
						}
					
					// ���� ��X�D�ť� nodes ������ if
					}

				// ���� for loop
				}

			// ���� if(!Page.IsPostBack)
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
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand3 = new System.Data.SqlClient.SqlCommand();
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter2.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_xmldata", "cont_xmldata")})});
			this.sqlDataAdapter2.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM c2_cont WHERE (cont_contno = @cont_contno) AND (cont_syscd = @cont_sy" +
				"scd) AND (cont_xmldata LIKE @cont_xmldata)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_xmldata", System.Data.SqlDbType.NText, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_xmldata", System.Data.DataRowVersion.Original, null));
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=moc1847csi;persist security i" +
//				"nfo=True;user id=sa;workstation id=03212-890711;packet size=4096";
			this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpa_mrlpub");
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO c2_cont(cont_xmldata, cont_contno, cont_syscd) VALUES (@cont_xmldata," +
				" @cont_contno, @cont_syscd); SELECT cont_xmldata, cont_contno, cont_syscd FROM c" +
				"2_cont WHERE (cont_contno = @Select_cont_contno) AND (cont_syscd = @Select_cont_" +
				"syscd)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_xmldata", System.Data.SqlDbType.NText, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT cont_xmldata, cont_contno, cont_syscd FROM c2_cont";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE c2_cont SET cont_xmldata = @cont_xmldata, cont_contno = @cont_contno, cont_syscd = @cont_syscd WHERE (cont_contno = @Original_cont_contno) AND (cont_syscd = @Original_cont_syscd) AND (cont_xmldata LIKE @Original_cont_xmldata); SELECT cont_xmldata, cont_contno, cont_syscd FROM c2_cont WHERE (cont_contno = @Select_cont_contno) AND (cont_syscd = @Select_cont_syscd)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_xmldata", System.Data.SqlDbType.NText, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cont_xmldata", System.Data.SqlDbType.NText, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_xmldata", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_cont_contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Select_cont_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "dbo.sp_c2_adpub_act3_pub";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@yyyymm", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pubseq", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pgno", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c2_cont", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cont_xmldata", "cont_xmldata"),
																																																				 new System.Data.Common.DataColumnMapping("cont_contno", "cont_contno")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT cont_xmldata, cont_contno, cont_syscd FROM c2_cont";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlCommand3
			// 
			this.sqlCommand3.CommandText = "UPDATE c2_cont SET cont_xmldata = @xmldata WHERE (cont_syscd = \'C2\') AND (cont_co" +
				"ntno = @contno)";
			this.sqlCommand3.Connection = this.sqlConnection1;
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@xmldata", System.Data.SqlDbType.Text, 100000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlCommand3.Parameters.Add(new System.Data.SqlClient.SqlParameter("@contno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cont_contno", System.Data.DataRowVersion.Current, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
