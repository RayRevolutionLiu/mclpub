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
		
		
		// 宣告 xml資料為 global, 好讓其他程式可以呼叫
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

			//// 測試: 先將傳過來的 Request.InputStream 輸出到檔案 test555.xml 來做檢查
			//// 通過了此測試, 再開始下面的程式
			//// Request.SaveAs("c:\\testContNewSave.xml", false);
			
			
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
			this.sqlInsertCommand1.Parameters["@cont_syscd"].Value=xmlContBasicData["系統代碼"].FirstChild.OuterXml;
			this.sqlInsertCommand1.Parameters["@cont_contno"].Value=xmlContBasicData["合約書編號"].FirstChild.OuterXml;
			
			// 若合約類別代碼 = 01 or 09, 則做儲存動作
			if((xmlContBasicData["合約類別代碼"].FirstChild.OuterXml=="01")||(xmlContBasicData["合約類別代碼"].FirstChild.OuterXml=="09"))
			{
				// 以下若為必填資料, 則無檢查是否為空值, 並放置於每區的前幾行;
				// 否則先檢查是否為空值, 再插入其XML資料
				
				// 廠商資料 區
				this.sqlInsertCommand1.Parameters["@cont_mfrno"].Value=xmlMfrData["廠商統編"].FirstChild.OuterXml;


				// 合約書基本資料 區
				this.sqlInsertCommand1.Parameters["@cont_custno"].Value=xmlCustData["客戶編號"].FirstChild.OuterXml;
				this.sqlInsertCommand1.Parameters["@cont_conttp"].Value=xmlContBasicData["合約類別代碼"].FirstChild.OuterXml;
				this.sqlInsertCommand1.Parameters["@cont_bkcd"].Value=xmlContBasicData["書籍類別代碼"].FirstChild.OuterXml;
				this.sqlInsertCommand1.Parameters["@cont_empno"].Value=xmlContBasicData["承辦業務員工號"].FirstChild.OuterXml;
				this.sqlInsertCommand1.Parameters["@cont_fgpayonce"].Value=xmlContBasicData["一次付清註記"].FirstChild.OuterXml;
				this.sqlInsertCommand1.Parameters["@cont_fgclosed"].Value=xmlContBasicData["結案註記"].FirstChild.OuterXml;
				
				if(xmlContBasicData["修改業務員工號"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_modempno"].Value=xmlContBasicData["修改業務員工號"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_modempno"].Value="";
				
				if(xmlContBasicData["舊合約編號"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_oldcontno"].Value=xmlContBasicData["舊合約編號"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_oldcontno"].Value="";
				
				// 日期的處理
				// 以下四行是舊的處理: 自畫面上抓下 (不含 / 符號), 並直接儲存至資料庫中
				//this.sqlInsertCommand1.Parameters["@cont_signdate"].Value=xmlContBasicData["簽約日期"].FirstChild.OuterXml;
				//this.sqlInsertCommand1.Parameters["@cont_moddate"].Value=System.DateTime.Today.ToString("yyyyMMdd");
				//this.sqlInsertCommand1.Parameters["@cont_sdate"].Value=xmlContBasicData["合約起日"].FirstChild.OuterXml;
				//this.sqlInsertCommand1.Parameters["@cont_edate"].Value=xmlContBasicData["合約迄日"].FirstChild.OuterXml;
				// 新的處理: 自畫面上抓下 (含 / 符號), 並去除該符號再儲存至資料庫中
				string SignDate = xmlContBasicData["簽約日期"].FirstChild.OuterXml;
				this.sqlInsertCommand1.Parameters["@cont_signdate"].Value = SignDate.Substring(0, 4) + SignDate.Substring(5, 2) + SignDate.Substring(8, 2);
				this.sqlInsertCommand1.Parameters["@cont_moddate"].Value = System.DateTime.Today.ToString("yyyyMMdd");
				string StartDate = xmlContBasicData["合約起日"].FirstChild.OuterXml;
				this.sqlInsertCommand1.Parameters["@cont_sdate"].Value = StartDate.Substring(0, 4) + StartDate.Substring(5, 2);
				string EndDate = xmlContBasicData["合約迄日"].FirstChild.OuterXml;
				this.sqlInsertCommand1.Parameters["@cont_edate"].Value = EndDate.Substring(0, 4) + EndDate.Substring(5, 2);
				
				
				// 合約書細節 區
				if(xmlContDetail["總製稿次數"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_totjtm"].Value=xmlContDetail["總製稿次數"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_totjtm"].Value="0";

				if(xmlContDetail["合約總金額"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_totamt"].Value=xmlContDetail["合約總金額"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_totamt"].Value="0";

				if(xmlContDetail["優惠折數"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_disc"].Value=xmlContDetail["優惠折數"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_disc"].Value="0";

				if(xmlContDetail["已製稿次數"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_madejtm"].Value=xmlContDetail["已製稿次數"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_madejtm"].Value="0";

				if(xmlContDetail["剩餘製稿次數"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_restjtm"].Value=xmlContDetail["剩餘製稿次數"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_restjtm"].Value="0";

				if(xmlContDetail["總刊登次數"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_tottm"].Value=xmlContDetail["總刊登次數"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_tottm"].Value="0";

				if(xmlContDetail["已刊登次數"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_pubtm"].Value=xmlContDetail["已刊登次數"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_pubtm"].Value="0";

				if(xmlContDetail["剩餘刊登次數"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_resttm"].Value=xmlContDetail["剩餘刊登次數"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_resttm"].Value="0";

				if(xmlContDetail["已繳金額"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_paidamt"].Value=xmlContDetail["已繳金額"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_paidamt"].Value="0";

				if(xmlContDetail["剩餘金額"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_restamt"].Value=xmlContDetail["剩餘金額"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_restamt"].Value="0";

				if(xmlContDetail["換稿次數"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_chgjtm"].Value=xmlContDetail["換稿次數"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_chgjtm"].Value="0";

				if(xmlContDetail["贈送次數"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_freetm"].Value=xmlContDetail["贈送次數"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_freetm"].Value="0";

				if(xmlAdpubItems["落版後金額"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_pubamt"].Value=xmlAdpubItems["落版後金額"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_pubamt"].Value="0";

				if(xmlAdpubItems["換稿費用"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_chgamt"].Value=xmlAdpubItems["換稿費用"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_chgamt"].Value="0";

				if(xmlContDetail["彩色次數"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_clrtm"].Value=xmlContDetail["彩色次數"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_clrtm"].Value="0";

				if(xmlContDetail["黑白次數"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_menotm"].Value=xmlContDetail["黑白次數"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_menotm"].Value="0";

				if(xmlContDetail["套色次數"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_getclrtm"].Value=xmlContDetail["套色次數"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_getclrtm"].Value="0";
				
				
				// 廣告聯絡人資料 區
				if(xmlAdContactor["廣告聯絡人姓名"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_aunm"].Value=xmlAdContactor["廣告聯絡人姓名"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_aunm"].Value="";

				if(xmlAdContactor["廣告聯絡人電話"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_autel"].Value=xmlAdContactor["廣告聯絡人電話"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_autel"].Value="";

				if(xmlAdContactor["廣告聯絡人傳真"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_aufax"].Value=xmlAdContactor["廣告聯絡人傳真"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_aufax"].Value="";

				if(xmlAdContactor["廣告聯絡人手機"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_aucell"].Value=xmlAdContactor["廣告聯絡人手機"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_aucell"].Value="";

				if(xmlAdContactor["廣告聯絡人Email"].FirstChild!=null)
					this.sqlInsertCommand1.Parameters["@cont_auemail"].Value=xmlAdContactor["廣告聯絡人Email"].FirstChild.OuterXml;
				else
					this.sqlInsertCommand1.Parameters["@cont_auemail"].Value="";
				

				// 發票廠商收件人資料 區: 參下方的 stored procedure coding
				// 雜誌收件人資料 區: 參下方的 stored procedure coding
				// 合約書落版刊登資料 區: 參下方的 stored procedure coding
				
			}
			
			// 定義 PK 之值, 否則無法插入 DB
			this.sqlInsertCommand1.Parameters["@Select_cont_syscd"].Value=xmlContBasicData["系統代碼"].FirstChild.OuterXml;
			this.sqlInsertCommand1.Parameters["@Select_cont_contno"].Value=xmlContBasicData["合約書編號"].FirstChild.OuterXml;
			
			// 插入 cont_xmldata 資料
			this.sqlInsertCommand1.Parameters["@cont_xmldata"].Value= "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlMain.OuterXml;
			
			// 執行 sqlInsertCommand1 新增插入: 合約書 資料 c2_cont
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
			
			// 輸出執行結果
			if(ResultFlag)
			{
				Response.Write("新增合約書檔成功!\n\n");
			}
			else
			{
				Response.Write("新增合約書檔失敗!\n\n");
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
				//Response.Write("\n xmlAdpubData.OuterXml= " + xmlAdpubData.OuterXml + "\n");
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
			
			
			//------- 若為一次付清, 則新增發票開立單檔, 發票開立明細檔; 否則在開立發票之大批處理才做 --------//
			//Response.Write("conttp= " + xmlContBasicData["合約類別代碼"].FirstChild.OuterXml + "\n");
			//Response.Write("一次付清註記= " + xmlContBasicData["一次付清註記"].FirstChild.OuterXml + "\n");
			//Response.Write("XML= " + "<?xml version=\"1.0\" encoding=\"big5\"?>" + xmlContBasicData.OuterXml + "\n");
//			if((xmlContBasicData["合約類別代碼"].FirstChild.OuterXml=="01" && xmlContBasicData["一次付清註記"].FirstChild.OuterXml=="1") || (xmlContBasicData["合約類別代碼"].FirstChild.OuterXml=="09" && xmlContBasicData["一次付清註記"].FirstChild.OuterXml=="1"))
//			{
//				Response.Write("一次付清, 做 發票開立申請單 之處理!\n\n");
//				//InsertIAData();
//				//Response.Redirect("cont_SaveMessage.aspx?str='cont_newSavefg'");
//			}
//			else
//			{
//				Response.Write("非一次付清, 不做 發票開立申請單 之處理!\n\n");
//				//Response.Redirect("cont_SaveMessage.aspx?str='cont_newSave'");
//				//Response.Write("無此合約類別代碼, 無法 新增發票開立單檔, 發票開立明細檔\n");
//			}


			//-------新增繳款單檔, 繳款單明細檔--------//
//			if((xmlContBasicData["合約類別代碼"].FirstChild.OuterXml=="01")||(xmlContBasicData["合約類別代碼"].FirstChild.OuterXml=="09"))
//			{			
//				//InsertPayData();
//			}
//			else
//			{
//				Response.Write("無此合約類別代碼, 無法 新增發票開立單檔, 發票開立明細檔");
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
		

		//-------新增發票開立單檔, 發票開立明細檔--------//
		private void InsertIAData()
		{
			// 因 XmlDoc & root 已宣告成 global 變數, 且在 Page_Load 已抓出, 故不用再宣告一次
//			root = XmlDoc.DocumentElement;
//			// 將 root 的xml內容顯示出來, 供檢查用
//			//Response.Write(root.OuterXml);
//			
//			XmlNode xmlMain = XmlDoc.SelectSingleNode("/root");
//			XmlNode xmlHeader = XmlDoc.SelectSingleNode("/root/合約書內容");
//			
//			XmlNode xmlMfrData = XmlDoc.SelectSingleNode("/root/合約書內容/廠商資料");
//			XmlNode xmlCustData = XmlDoc.SelectSingleNode("/root/合約書內容/客戶資料");
//			XmlNode xmlContBasicData = XmlDoc.SelectSingleNode("/root/合約書內容/合約書基本資料");
//			XmlNode xmlContDetail = XmlDoc.SelectSingleNode("/root/合約書內容/合約書細節");
//			XmlNode xmlInvRec = XmlDoc.SelectSingleNode("/root/發票廠商資料");
//			XmlNode xmlMazRec = XmlDoc.SelectSingleNode("/root/雜誌收件人資料");
//			XmlNode xmlAdContactor = XmlDoc.SelectSingleNode("/root/合約書內容/廣告聯絡人資料");
//			
//			XmlNode xmlAdpubData = XmlDoc.SelectSingleNode("/root/合約書落版刊登資料");
//			XmlNode xmlAdpubItems = XmlDoc.SelectSingleNode("/root/合約書落版刊登資料/落版明細表");
//			XmlNode xmlAdpubItemInvRec = XmlDoc.SelectSingleNode("/root/合約書落版刊登資料/落版明細表/發票廠商收件人細節");
//			//XmlNode xmlAdpubItemDetails = XmlDoc.SelectSingleNode("/root/合約書落版刊登資料/落版明細表/落版細節");
			
			
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
//				//若 dv2 無資料, 則指定起始編號為 八碼流水號, 如 00000000
//				iano = "00000000";
//			}
			//Response.Write("iano= " + iano + "\n");
			
			// 抓出西元年份後兩碼, 塞入 ia 八碼的前兩碼, 成為 2碼西元年碼+6碼流水號
//			string fy=System.DateTime.Today.Year.ToString();
			//Response.Write("fy= " + fy + "\n");
//			if(iano.Substring(0,2)==fy.Substring(2,2))
//				iano = Convert.ToString(Int32.Parse(iano)+1);
//			else
//				iano=fy.Substring(2,2)+"000001";
			//Response.Write("iano= " + iano + "<br>");
			
			// 做流水號補 0 的動作
//			for(int j=0; j<8-iano.Length; j++)
//				iano="0"+iano;
			
			//------- 新增發票開立單檔 sqlDataAdapter3 --------//
			//Response.Write("xmlAdpubData.ChildNodes.Count= " + xmlAdpubData.ChildNodes.Count + "\n\n");
//			for(int i=0; i<xmlAdpubData.ChildNodes.Count; i++)
//			{
//				//Response.Write("xmlAdpubData.ChildNodes(" + i + ").發票收件人姓名= " + xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("發票廠商收件人細節").ChildNodes.Item(0).SelectSingleNode("發票收件人姓名").InnerText + "\n");
//				//Response.Write("xmlAdpubData.ChildNodes(" + i + ").xml= " + xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("發票廠商收件人細節").OuterXml + "\n\n\n");
//				//Response.Write("第 " + (i+1) + "筆:" + xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("發票廠商收件人細節").ChildNodes.Item(0).SelectSingleNode("發票收件人姓名").InnerText + ", ia=" + (i+1) + ", iad=" + i + "\n");
//				
//				// 宣告 ArrayList(姓名, 該姓名的XML Data)
//				// Create and initialize a new ArrayList.
//				//ArrayList myAL = new ArrayList();
//				//myAL.Add(xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("發票廠商收件人細節").ChildNodes.Item(0).SelectSingleNode("發票收件人姓名").InnerText);
//				// Display the properties and values of the ArrayList.
//				//Console.WriteLine("myAL=" + myAL.ToString());
//				
//				// Create and initialize a new SortedList.
//				SortedList mySL = new SortedList();
//				mySL.Add(xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("發票廠商收件人細節").ChildNodes.Item(0).SelectSingleNode("發票收件人姓名").InnerText, xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("發票廠商收件人細節").OuterXml);
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
//			this.sqlInsertCommand2.Parameters["@ia_mfrno"].Value=xmlMfrData["廠商統編"].FirstChild.OuterXml;
//			
			// 給初始值(預設)為空, 這些值是日後有需求時, 再寫回
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
//			TotalAmt = Convert.ToInt32(xmlContDetail["合約總金額"].FirstChild.InnerText);
//			//Response.Write("TotalAmt= " + TotalAmt + "\n");
//			this.sqlInsertCommand2.Parameters["@ia_pyat"].Value=xmlContDetail["合約總金額"].FirstChild.OuterXml;
//			int amt_iv=(int)Math.Round((float)TotalAmt/1.05F);
//			//Response.Write("amt_iv= " + amt_iv + "\n");
//			this.sqlInsertCommand2.Parameters["@ia_ivat"].Value=amt_iv.ToString();
//			
//			if(xmlContBasicData["院所內註記"].FirstChild.OuterXml=="06" || xmlContBasicData["院所內註記"].FirstChild.OuterXml=="07")
//				this.sqlInsertCommand2.Parameters["@ia_fgitri"].Value = xmlContBasicData["院所內註記"].FirstChild.OuterXml;
//			else
//				this.sqlInsertCommand2.Parameters["@ia_fgitri"].Value = "";
//			
//			this.sqlInsertCommand2.Parameters["@ia_rnm"].Value = xmlInvRec["寄發票收件人姓名"].FirstChild.OuterXml;
//			this.sqlInsertCommand2.Parameters["@ia_raddr"].Value = xmlInvRec["寄發票地址"].FirstChild.OuterXml;
//			this.sqlInsertCommand2.Parameters["@ia_rzip"].Value = xmlInvRec["寄發票郵遞區號"].FirstChild.OuterXml;
//			
//			if(xmlInvRec["寄發票收件人職稱"].FirstChild!=null)
//				this.sqlInsertCommand2.Parameters["@ia_rjbti"].Value = xmlInvRec["發票收件人職稱"].FirstChild.OuterXml;
//			else
//				this.sqlInsertCommand2.Parameters["@ia_rjbti"].Value ="";
//			if(xmlInvRec["寄發票收件人電話"].FirstChild!=null)
//				this.sqlInsertCommand2.Parameters["@ia_rtel"].Value = xmlInvRec["寄發票收件人電話"].FirstChild.OuterXml;
//			else
//				this.sqlInsertCommand2.Parameters["@ia_rtel"].Value = "";
//			
//			this.sqlInsertCommand2.Parameters["@ia_fgnonauto"].Value = "0";
//			this.sqlInsertCommand2.Parameters["@ia_invcd"].Value = xmlContBasicData["發票類別代碼"].FirstChild.OuterXml;
//			this.sqlInsertCommand2.Parameters["@ia_taxtp"].Value = xmlContBasicData["發票課稅別代碼"].FirstChild.OuterXml;
//			this.sqlInsertCommand2.Parameters["@ia_status"].Value = "1";
//			this.sqlInsertCommand2.Parameters["@ia_cname"].Value = "test康";
//			this.sqlInsertCommand2.Parameters["@ia_tel"].Value = "03-";
//			this.sqlInsertCommand2.Parameters["@ia_contno"].Value = xmlContBasicData["合約書編號"].FirstChild.OuterXml;
//			Response.Write("承辦業務員工號= " + xmlContBasicData["承辦業務員工號"].FirstChild.OuterXml + "\n");
			//Response.Write("ia_cname= " + xmlContBasicData["承辦業務員工號"].FirstChild.OuterXml + "\n");
			//Response.Write("ia_tel= " + xmlContBasicData["承辦業務員工號"].FirstChild.OuterXml  + "\n");
//			Response.Write("ia_contno= " + xmlContBasicData["合約書編號"].FirstChild.OuterXml  + "\n");
			
			// 定義 PK 之值, 否則無法插入 DB
//			this.sqlInsertCommand2.Parameters["@Select_ia_iano"].Value=iano;
//			this.sqlInsertCommand2.Parameters["@Select_ia_syscd"].Value="C2";
			
			// 執行 sqlInsertCommand2: 插入 發票開立單 ia table
//			this.sqlInsertCommand2.Connection.Open();
//			this.sqlInsertCommand2.ExecuteNonQuery();
//			this.sqlInsertCommand2.Connection.Close();
			
			
			
			//------- 新增發票開立明細檔 sqlDataAdapter4 --------//
			// this.sqlDataAdapter4.InsertCommand = sqlInsertCommand3
			//Response.Write("xmlAdpubData.count= " + xmlAdpubData.ChildNodes.Count + "\n");
//			for(int i=0; i<xmlAdpubData.ChildNodes.Count; i++)
//			{
//				this.sqlInsertCommand3.Parameters["@iad_syscd"].Value = "C2";
//				this.sqlInsertCommand3.Parameters["@iad_iano"].Value = iano;
//				this.sqlInsertCommand3.Parameters["@iad_iaditem"].Value = Convert.ToString(i+1);
//				this.sqlInsertCommand3.Parameters["@iad_fk1"].Value = xmlContBasicData["系統代碼"].FirstChild.OuterXml;
//				this.sqlInsertCommand3.Parameters["@iad_fk2"].Value = xmlContBasicData["合約書編號"].FirstChild.OuterXml;
//				this.sqlInsertCommand3.Parameters["@iad_fk3"].Value = xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("刊登年月").InnerText;
//				this.sqlInsertCommand3.Parameters["@iad_fk4"].Value = xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("落版序號").InnerText;
//				this.sqlInsertCommand3.Parameters["@iad_projno"].Value = xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("計劃代號").InnerText;
//				this.sqlInsertCommand3.Parameters["@iad_costctr"].Value = xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("成本中心").InnerText;
				
				// 先抓出 書籍類別名稱 bk_nm
//				DataSet ds5 = new DataSet();
//				this.sqlDataAdapter5.Fill(ds5, "book");
//				DataView dv5 = ds5.Tables["book"].DefaultView;
//				dv5 = ds5.Tables["book"].DefaultView;
//				dv5.RowFilter = "bk_bkcd='" + xmlContBasicData["書籍類別代碼"].FirstChild.OuterXml + "'";
//				this.sqlInsertCommand3.Parameters["@iad_desc"].Value = dv5[0].Row["bk_nm"].ToString().Trim() + "訂購";

				// iad_desc 品名 = 書籍類別名稱 + 刊登年月
//				if((xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("刊登年月").InnerText != ""))
//				{
//					if((xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("刊登年月").InnerText.Length>=4))
//					{
//						this.sqlInsertCommand3.Parameters["@iad_desc"].Value = this.sqlInsertCommand3.Parameters["@iad_desc"].Value + " " + xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("刊登年月").InnerText;
//						//Response.Write(this.sqlInsertCommand3.Parameters["@iad_desc"].Value + "\n");
//					}
//				}
				
				// 每筆落版資料的份數為 1筆, 故為 ia 的數量
//				this.sqlInsertCommand3.Parameters["@iad_qty"].Value = "1";
//				this.sqlInsertCommand3.Parameters["@iad_unit"].Value = "";
//				this.sqlInsertCommand3.Parameters["@iad_uprice"].Value = 0.0;
				
				//Response.Write("Adamt= " + xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("落版細節/落版廣告金額").InnerText + "\n");
//				this.sqlInsertCommand3.Parameters["@iad_amt"].Value = xmlAdpubData.ChildNodes.Item(i).SelectSingleNode("落版細節/落版廣告金額").InnerText;
				

				// 定義 PK 之值, 否則無法插入 DB
//				this.sqlInsertCommand3.Parameters["@Select_iad_iaditem"].Value=Convert.ToString(i+1);
//				this.sqlInsertCommand3.Parameters["@Select_iad_iano"].Value=iano;
//				this.sqlInsertCommand3.Parameters["@Select_iad_syscd"].Value="C2";

				// 執行 sqlInsertCommand3: 插入 發票開立單明細 iad table
//				this.sqlInsertCommand3.Connection.Open();
//				this.sqlInsertCommand3.ExecuteNonQuery();
//				this.sqlInsertCommand3.Connection.Close();
//			}

		}
		

		//-------新增繳款單檔, 繳款單明細檔--------//
//		private void InsertPayData()
//		{
//			// 因 XmlDoc & root 已宣告成 global 變數, 且在 Page_Load 已抓出, 故不用再宣告一次
//			root = XmlDoc.DocumentElement;
//			// 將 root 的xml內容顯示出來, 供檢查用
//			//Response.Write(root.OuterXml);
//			
//			XmlNode ItemlMain = XmlDoc.SelectSingleNode("/root");
//			XmlNode ItemHeader = XmlDoc.SelectSingleNode("/root/合約書內容");
//			
//			XmlNode ItemMfrData = XmlDoc.SelectSingleNode("/root/合約書內容/廠商資料");
//			XmlNode ItemCustData = XmlDoc.SelectSingleNode("/root/合約書內容/客戶資料");
//			XmlNode ItemContBasicData = XmlDoc.SelectSingleNode("/root/合約書內容/合約書基本資料");
//			XmlNode ItemContDetail = XmlDoc.SelectSingleNode("/root/合約書內容/合約書細節");
//			XmlNode ItemInvRec = XmlDoc.SelectSingleNode("/root/發票廠商資料");
//			XmlNode ItemMazRec = XmlDoc.SelectSingleNode("/root/雜誌收件人資料");
//			XmlNode ItemAdContactor = XmlDoc.SelectSingleNode("/root/合約書內容/廣告聯絡人資料");
//			
//			XmlNode ItemAdpubData = XmlDoc.SelectSingleNode("/root/合約書落版刊登資料");
//			XmlNode ItemAdpubItems = XmlDoc.SelectSingleNode("/root/合約書落版刊登資料/落版明細表");
//			XmlNode ItemAdpubItemInvRec = XmlDoc.SelectSingleNode("/root/合約書落版刊登資料/落版明細表/發票廠商收件人細節");
//			//XmlNode ItemAdpubItemDetails = XmlDoc.SelectSingleNode("/root/合約書落版刊登資料/落版明細表/落版細節");
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
