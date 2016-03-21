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

		// 宣告 xml資料為 global, 好讓其他程式可以呼叫
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
				
				// 測試: 先將傳過來的 Request.InputStream 輸出到檔案 test555.xml 來做檢查
				// 通過了此測試, 再開始下面的程式
				// Request.SaveAs("c:\\test_adpub_mainSave.xml", false);
				
				
				// 開始處理程式序: 將傳入的 XML 資料 => 存至資料庫中 ---------------
				XmlDoc = new System.Xml.XmlDocument();
				XmlDoc.Load(Request.InputStream);
				root = XmlDoc.DocumentElement;

				// 將 root 的xml內容顯示出來, 供檢查用
				//Response.Write(root.OuterXml);
				
				XmlNode xmlMain = XmlDoc.SelectSingleNode("/root");
				XmlNode xmlHeader = XmlDoc.SelectSingleNode("/root/合約書內容");
				
				XmlNode xmlMfrData = XmlDoc.SelectSingleNode("/root/合約書內容/廠商資料");
				XmlNode xmlCustData = XmlDoc.SelectSingleNode("/root/合約書內容/客戶資料");
				XmlNode xmlContBasicData = XmlDoc.SelectSingleNode("/root/合約書內容/合約書基本資料");
				XmlNode xmlContDetail = XmlDoc.SelectSingleNode("/root/合約書內容/合約書細節");
				XmlNode xmlInvRec = XmlDoc.SelectSingleNode("/root/發票廠商資料");
				XmlNode xmlMazRec = XmlDoc.SelectSingleNode("/root/雜誌收件人資料");
				XmlNode xmlAdContactor = XmlDoc.SelectSingleNode("/root/合約書內容/廣告聯絡人資料");
				
				XmlNode xmlAdpubData = XmlDoc.SelectSingleNode("/root/合約書落版刊登資料");
				XmlNode xmlAdpubItems = XmlDoc.SelectSingleNode("/root/合約書落版刊登資料/落版明細表");
				XmlNode xmlAdpubItemInvRec = XmlDoc.SelectSingleNode("/root/合約書落版刊登資料/落版明細表/發票廠商收件人細節");
				XmlNode xmlAdpubItemDetails = XmlDoc.SelectSingleNode("/root/合約書落版刊登資料/落版明細表/落版細節");
				
								
				// 指定更新之新值-抓 xml資料 塞入, 藉 sqlCommand2 準備存入資料庫 c2_cont
				// 注意: 請到 Web Form Designer generated code 裡修改 sqlCommand2 以下 @變數 之資料型態 由 Variant 改為適當的型態 (如 Char)
				this.sqlCommand2.Parameters["@cont_moddate"].Value = Convert.ToString(xmlContBasicData["最後修改日期"].FirstChild.OuterXml);
				this.sqlCommand2.Parameters["@cont_xmldata"].Value = "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlMain.OuterXml;
				this.sqlCommand2.Parameters["@cont_modempno"].Value = Convert.ToString(xmlContBasicData["修改業務員工號"].FirstChild.OuterXml);
				this.sqlCommand2.Parameters["@cont_contno"].Value = Convert.ToString(xmlContBasicData["合約書編號"].FirstChild.OuterXml);
				
				// 檢查輸出值
				//Response.Write("@cont_moddate= " + this.sqlCommand2.Parameters["@cont_moddate"].Value + "\n");
				//Response.Write("@cont_xmldata= " + this.sqlCommand2.Parameters["@cont_xmldata"].Value + "\n");
				//Response.Write("@cont_modempno= " + this.sqlCommand2.Parameters["@cont_modempno"].Value + "\n");
				//Response.Write("@cont_contno= " + this.sqlCommand2.Parameters["@cont_contno"].Value + "\n");
				
				
				// 執行 sqlCommand2 儲存修改: 合約書 資料 c2_cont
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
				
				// 輸出執行結果
				if(ResultFlag2)
				{
					Response.Write("儲存修改合約書檔成功!\n\n");
				}
				else  
				{
					Response.Write("儲存修改合約書檔失敗!\n\n");
				}
				

				// xml/Stored Procedure 使用 ExecuteReader() 方式; 一般使用 ExecuteNonQuery() 方式
				// 本檔.cs, 檔頭須先呼叫 using System.Data.SqlClient, 才能使用 SqlDataReader
				
				//------- Stored Procedure: sp_c2_cont_newSave_pub - 抓 XML 寫至 落版刊登資料 的 DB table ------//
				// 檢查傳入之變數
				//Response.Write("syscd= " + xmlContBasicData["系統代碼"].FirstChild.OuterXml + "\n");
				//Response.Write("contno= " + xmlContBasicData["合約書編號"].FirstChild.OuterXml + "\n");
				//Response.Write("XML= " + "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlAdpubData.OuterXml + "\n");
				//Response.Write("xmlAdpubData= " + "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlAdpubData.OuterXml + "\n");
				//Response.Write("xmlAdpubData.ChildNodes.Count= " + xmlAdpubData.ChildNodes.Count + "\n");
				//Response.Write("xmlAdpubData.FirstChild= " + xmlAdpubData.FirstChild.OuterXml + "\n");
				//Response.Write("xmlAdpubData's 1st 序號= " + xmlAdpubData.FirstChild.FirstChild.InnerXml + "\n");
				//Response.Write("xmlAdpubData's 1st 刊登年月= " + xmlAdpubData.FirstChild.SelectSingleNode["書籍類別代碼"].InnerXml + "\n");
				this.sqlCommand1.Parameters["@syscd"].Value=xmlContBasicData["系統代碼"].FirstChild.OuterXml;
				this.sqlCommand1.Parameters["@contno"].Value=xmlContBasicData["合約書編號"].FirstChild.OuterXml;
				// 此處 @XML 是呼叫自 xmlAdpubData, 非 xmlMain
				this.sqlCommand1.Parameters["@XML"].Value="<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlAdpubData.OuterXml;
			
				// 檢查落版第一筆的刊登年月是否為空, 再判斷是否新增入 c2_pub table 內
				//Response.Write("xmlAdpubData.ChildNodes.Count= " + xmlAdpubData.ChildNodes.Count + "\n");
				//Response.Write("xmlAdpubData.FirstChild.InnerText= " + xmlAdpubData.FirstChild.SelectSingleNode("刊登年月").InnerText + "\n");
				//if(xmlAdpubData.ChildNodes.Count>=1 && xmlAdpubData.FirstChild.SelectSingleNode("刊登年月").InnerText != "")
				if(xmlAdpubData.FirstChild.SelectSingleNode("刊登年月").InnerText != "")
				{					
					//Response.Write("xmlAdpubData.OuterXml= " + xmlAdpubData.OuterXml + "\n");
					//Response.Write("落版第一筆刊登年月不為空, 新增落版資料中, 請稍後!!!\n");
					
					// 執行 sqlCommand1 儲存修改: 落版 資料 c2_pub
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
				
					// 輸出執行結果
					if(ResultFlag3)
					{
						Response.Write("儲存修改落版檔成功!\n\n");
					}
					else  
					{
						Response.Write("儲存修改落版檔失敗!\n\n");
					}
					
				}
				else
				{
					//Response.Write("xmlAdpubData.OuterXml= " + xmlAdpubData.OuterXml + "\n");
					Response.Write("落版第一筆刊登年月為空, 將不新增至落版檔!!!\n");
				}
				
				// 轉址處理
				//Response.Redirect("cont_SaveMessage.aspx?str='adpub_mainSave'&ResultFlag2=" & ResultFlag2 & "&ResultFlag1=" & ResultFlag1);
				

			// 結束 if (!Page.IsPostBack)
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
