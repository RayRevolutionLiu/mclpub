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
		
		
		// 宣告 xml資料為 global, 好讓其他程式可以呼叫
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

			//// 測試: 先將傳過來的 Request.InputStream 輸出到檔案 test_cont_mainSave.xml 來做檢查
			//// 通過了此測試, 再開始下面的程式
			//// Request.SaveAs("c:\\test_cont_mainSave.xml", false);
			
			
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
			
			
			// 開始抓 xml資料 儲入資料庫
			this.sqlUpdateCommand1.Parameters["@Original_cont_syscd"].Value=xmlContBasicData["系統代碼"].FirstChild.OuterXml;
			this.sqlUpdateCommand1.Parameters["@Original_cont_contno"].Value=xmlContBasicData["合約書編號"].FirstChild.OuterXml;
			this.sqlUpdateCommand1.Parameters["@cont_syscd"].Value=xmlContBasicData["系統代碼"].FirstChild.OuterXml;
			this.sqlUpdateCommand1.Parameters["@cont_contno"].Value=xmlContBasicData["合約書編號"].FirstChild.OuterXml;
			
			// 若合約類別代碼 = 01 or 09, 則做儲存動作
			if((xmlContBasicData["合約類別代碼"].FirstChild.OuterXml=="01")||(xmlContBasicData["合約類別代碼"].FirstChild.OuterXml=="09"))
			{
				// 以下若為必填資料, 則無檢查是否為空值, 並放置於每區的前幾行;
				// 否則先檢查是否為空值, 再插入其XML資料
				
				// 廠商及客戶資料 區
				this.sqlUpdateCommand1.Parameters["@cont_mfrno"].Value=xmlMfrData["廠商統編"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_custno"].Value=xmlCustData["客戶編號"].FirstChild.OuterXml;
				
				// 合約書基本資料 區
				// 日期的處理 - 自XML抓出, 去除 / 符號後, 再儲存至資料庫中
				string SignDate = xmlContBasicData["簽約日期"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_signdate"].Value = SignDate.Substring(0, 4) + SignDate.Substring(5, 2) + SignDate.Substring(8, 2);
				this.sqlUpdateCommand1.Parameters["@cont_moddate"].Value = System.DateTime.Today.ToString("yyyyMMdd");
				string StartDate = xmlContBasicData["合約起日"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_sdate"].Value = StartDate.Substring(0, 4) + StartDate.Substring(5, 2);
				string EndDate = xmlContBasicData["合約迄日"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_edate"].Value = EndDate.Substring(0, 4) + EndDate.Substring(5, 2);
				string ModDate = xmlContBasicData["最後修改日期"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_moddate"].Value = ModDate.Substring(0, 4) + ModDate.Substring(5, 2) + ModDate.Substring(8, 2);
				
				this.sqlUpdateCommand1.Parameters["@cont_conttp"].Value=xmlContBasicData["合約類別代碼"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_bkcd"].Value=xmlContBasicData["書籍類別代碼"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_empno"].Value=xmlContBasicData["承辦業務員工號"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_fgpayonce"].Value=xmlContBasicData["一次付清註記"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_fgclosed"].Value=xmlContBasicData["結案註記"].FirstChild.OuterXml;
				this.sqlUpdateCommand1.Parameters["@cont_oldcontno"].Value=xmlContBasicData["舊合約編號"].FirstChild.OuterXml;		
				this.sqlUpdateCommand1.Parameters["@cont_modempno"].Value=xmlContBasicData["修改業務員工號"].FirstChild.OuterXml;
				
				
				// 合約書細節 區
				if(xmlContDetail["總製稿次數"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_totjtm"].Value=xmlContDetail["總製稿次數"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_totjtm"].Value="0";
				
				if(xmlContDetail["已製稿次數"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_madejtm"].Value=xmlContDetail["已製稿次數"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_madejtm"].Value="0";
				
				if(xmlContDetail["剩餘製稿次數"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_restjtm"].Value=xmlContDetail["剩餘製稿次數"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_restjtm"].Value="0";
				
				if(xmlContDetail["優惠折數"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_disc"].Value=xmlContDetail["優惠折數"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_disc"].Value="0";
				
				if(xmlContDetail["贈送次數"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_freetm"].Value=xmlContDetail["贈送次數"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_freetm"].Value="0";
				
				if(xmlContDetail["總刊登次數"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_tottm"].Value=xmlContDetail["總刊登次數"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_tottm"].Value="0";
				
				if(xmlContDetail["已刊登次數"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_pubtm"].Value=xmlContDetail["已刊登次數"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_pubtm"].Value="0";
				
				if(xmlContDetail["剩餘刊登次數"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_resttm"].Value=xmlContDetail["剩餘刊登次數"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_resttm"].Value="0";
				
				if(xmlContDetail["合約總金額"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_totamt"].Value=xmlContDetail["合約總金額"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_totamt"].Value="0";
				
				if(xmlContDetail["已繳金額"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_paidamt"].Value=xmlContDetail["已繳金額"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_paidamt"].Value="0";
				
				if(xmlContDetail["剩餘金額"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_restamt"].Value=xmlContDetail["剩餘金額"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_restamt"].Value="0";
				
				if(xmlContDetail["換稿次數"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_chgjtm"].Value=xmlContDetail["換稿次數"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_chgjtm"].Value="0";
				
				if(xmlAdpubItems["落版後金額"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_pubamt"].Value=xmlAdpubItems["落版後金額"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_pubamt"].Value="0";

				if(xmlAdpubItems["換稿費用"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_chgamt"].Value=xmlAdpubItems["換稿費用"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_chgamt"].Value="0";
				
				if(xmlContDetail["彩色次數"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_clrtm"].Value=xmlContDetail["彩色次數"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_clrtm"].Value="0";
				
				if(xmlContDetail["黑白次數"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_menotm"].Value=xmlContDetail["黑白次數"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_menotm"].Value="0";
				
				if(xmlContDetail["套色次數"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_getclrtm"].Value=xmlContDetail["套色次數"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_getclrtm"].Value="0";
				
				
				// 廣告聯絡人資料 區
				if(xmlAdContactor["廣告聯絡人姓名"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_aunm"].Value=xmlAdContactor["廣告聯絡人姓名"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_aunm"].Value="";
				
				if(xmlAdContactor["廣告聯絡人電話"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_autel"].Value=xmlAdContactor["廣告聯絡人電話"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_autel"].Value="";
				
				if(xmlAdContactor["廣告聯絡人傳真"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_aufax"].Value=xmlAdContactor["廣告聯絡人傳真"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_aufax"].Value="";
				
				if(xmlAdContactor["廣告聯絡人手機"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_aucell"].Value=xmlAdContactor["廣告聯絡人手機"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_aucell"].Value="";
				
				if(xmlAdContactor["廣告聯絡人Email"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@cont_auemail"].Value=xmlAdContactor["廣告聯絡人Email"].FirstChild.OuterXml;
				else
					this.sqlUpdateCommand1.Parameters["@cont_auemail"].Value="";
				
				// 發票廠商收件人資料 區: 參下方的 stored procedure coding
				// 雜誌收件人資料 區: 參下方的 stored procedure coding
				// 合約書落版刊登資料 區: 參下方的 stored procedure coding
				
			}			
			// 定義 PK 之值, 否則無法插入 DB
			this.sqlUpdateCommand1.Parameters["@Select_cont_syscd"].Value=xmlContBasicData["系統代碼"].FirstChild.OuterXml;
			this.sqlUpdateCommand1.Parameters["@Select_cont_contno"].Value=xmlContBasicData["合約書編號"].FirstChild.OuterXml;
			
			// 更新 cont_xmldata 資料
			this.sqlUpdateCommand1.Parameters["@cont_xmldata"].Value= "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlMain.OuterXml;
			
			// 執行 sqlUpdateCommand1 更新: 合約書 資料 c2_cont
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
						
			// 輸出執行結果
			if(ResultFlag)
			{
				Response.Write("修改合約書檔成功!\n\n");
			}
			else  
			{
				Response.Write("修改合約書檔失敗!\n\n");
			}			
			
			
			// xml/Stored Procedure 使用 ExecuteReader() 方式; 一般使用 ExecuteNonQuery() 方式
			// 本檔.cs, 檔頭須先呼叫 using System.Data.SqlClient, 才能使用 SqlDataReader
			
			//------- Stored Procedure: sp_c2_cont_newSave_or - 抓 XML 寫至 雜誌收件人 的 DB table ------//
			// 檢查傳入之變數
			//Response.Write("syscd= " + xmlContBasicData["系統代碼"].FirstChild.OuterXml + "\n");
			//Response.Write("contno= " + xmlContBasicData["合約書編號"].FirstChild.OuterXml + "\n");
			//Response.Write("XML= " + "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlMain.OuterXml + "\n");
			//Response.Write("xmlMazRec= " + "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlMazRec.OuterXml + "\n");
			//Response.Write("xmlMazRec.ChildNodes.Count= " + xmlMazRec.ChildNodes.Count + "\n");
			this.sqlCommand1.Parameters["@syscd"].Value=xmlContBasicData["系統代碼"].FirstChild.OuterXml;
			this.sqlCommand1.Parameters["@contno"].Value=xmlContBasicData["合約書編號"].FirstChild.OuterXml;
			// 此處 @XML 是呼叫自 xmlMazRec, 非 xmlMain
			this.sqlCommand1.Parameters["@XML"].Value="<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlMazRec.OuterXml;
			
			// 本檔檔頭須先呼叫 using System.Data.SqlClient, 才能使用 SqlDataReader
			// xml/Stored Procedure 使用 ExecuteReader() 方式; 一般使用 ExecuteNonQuery() 方式
			
			// 執行 sqlCommand1 儲存修改: 雜誌收件人 資料 c2_or
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
			
			// 輸出執行結果
			if(ResultFlag1)
			{
				Response.Write("修改雜誌收件人檔成功!\n\n");
			}
			else  
			{
				Response.Write("修改雜誌收件人檔失敗!\n\n");
			}
			
			
			//------- Stored Procedure: sp_c2_cont_newSave_IM - 抓 XML 寫至 發票廠商收件人 的 DB table ------//
			// 檢查傳入之變數
			//Response.Write("syscd= " + xmlContBasicData["系統代碼"].FirstChild.OuterXml + "\n");
			//Response.Write("contno= " + xmlContBasicData["合約書編號"].FirstChild.OuterXml + "\n");
			//Response.Write("XML= " + "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlMain.OuterXml + "\n");
			//Response.Write("xmlInvRec= " + "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlInvRec.OuterXml + "\n");
			//Response.Write("xmlInvRec.ChildNodes.Count= " + xmlInvRec.ChildNodes.Count + "\n");
			//Response.Write("imseq= " + xmlInvRec.ChildNodes.Item(xmlInvRec.ChildNodes.Count).SelectSingleNode["發票廠商序號"].FirstChild.OuterXml + "\n");
			this.sqlCommand2.Parameters["@syscd"].Value=xmlContBasicData["系統代碼"].FirstChild.OuterXml;
			this.sqlCommand2.Parameters["@contno"].Value=xmlContBasicData["合約書編號"].FirstChild.OuterXml;
			// 此處 @XML 是呼叫自 xmlInvRec, 非 xmlMain
			this.sqlCommand2.Parameters["@XML"].Value="<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlInvRec.OuterXml;
			
			// 本檔檔頭須先呼叫 using System.Data.SqlClient, 才能使用 SqlDataReader
			// xml/Stored Procedure 使用 ExecuteReader() 方式; 一般使用 ExecuteNonQuery() 方式
			
			// 執行 sqlCommand2 儲存修改: 發票廠商收件人 資料 invmfr
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
				
			// 輸出執行結果
			if(ResultFlag2)
			{
				Response.Write("修改發票廠商收件人檔成功!\n\n");
			}
			else  
			{
				Response.Write("修改發票廠商收件人檔失敗!\n\n");
			}
			
			
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
			this.sqlCommand3.Parameters["@syscd"].Value=xmlContBasicData["系統代碼"].FirstChild.OuterXml;
			this.sqlCommand3.Parameters["@contno"].Value=xmlContBasicData["合約書編號"].FirstChild.OuterXml;
			// 此處 @XML 是呼叫自 xmlAdpubData, 非 xmlMain
			this.sqlCommand3.Parameters["@XML"].Value="<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlAdpubData.OuterXml;
			
			// 檢查落版第一筆的刊登年月是否為空, 再判斷是否新增入 c2_pub table 內
			//Response.Write("xmlAdpubData.ChildNodes.Count= " + xmlAdpubData.ChildNodes.Count + "\n");
			//Response.Write("xmlAdpubData.FirstChild.InnerText= " + xmlAdpubData.FirstChild.SelectSingleNode("刊登年月").InnerText + "\n");
			//if(xmlAdpubData.ChildNodes.Count>=1 && xmlAdpubData.FirstChild.SelectSingleNode("刊登年月").InnerText != "")
			if(xmlAdpubData.FirstChild.SelectSingleNode("刊登年月").InnerText != "")
			{
				//Response.Write("xmlAdpubData.OuterXml= " + xmlAdpubData.OuterXml + "\n");
				Response.Write("落版第一筆刊登年月不為空, 新增落版資料中, 請稍後!!!\n");
				
				// 執行 sqlCommand3 儲存修改: 落版 資料 c2_pub
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
				
				// 輸出執行結果
				if(ResultFlag3)
				{
					Response.Write("修改落版檔成功!\n\n");
				}
				else  
				{
					Response.Write("修改落版檔失敗!\n\n");
				}

			}
			// 若第一筆之刊登年月為空值
			else
			{
				//Response.Write("xmlAdpubData.OuterXml= " + xmlAdpubData.OuterXml + "\n");
				Response.Write("落版第一筆刊登年月為空, 將不新增至落版檔!!!\n");
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
