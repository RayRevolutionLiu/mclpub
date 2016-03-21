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
using System.Xml;
using System.IO;
using System.Configuration;

namespace MRLPub.d1
{
	/// <summary>
	/// Summary description for ModifyOrder.
	/// </summary>
	public class ModifyOrder : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		XmlDocument XmlDoc;
	
		public ModifyOrder()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			Response.Expires=0;
//			Request.SaveAs("\test555.xml", false);
			XmlDoc = new System.Xml.XmlDocument();
			XmlDoc.Load(Request.InputStream);
			XmlNode	ItemMain=XmlDoc.SelectSingleNode("/root");
			XmlNode	ItemOrder=XmlDoc.SelectSingleNode("/root/訂單");
			XmlNode	ItemDetail=XmlDoc.SelectSingleNode("/root/訂單明細");
			XmlElement root;
			XmlNodeList BookTypeList;
			root = XmlDoc.DocumentElement;
			BookTypeList = root.GetElementsByTagName("書籍類別");
			for(int i=0;i<this.sqlUpdateCommand1.Parameters.Count;i++)
			{
				this.sqlUpdateCommand1.Parameters[i].Value = "";
			}
			this.sqlUpdateCommand1.Parameters["@Original_o_syscd"].Value=ItemOrder["系統代碼"].FirstChild.OuterXml;
			this.sqlUpdateCommand1.Parameters["@Original_o_custno"].Value=ItemOrder["訂戶編號"].FirstChild.OuterXml;
			this.sqlUpdateCommand1.Parameters["@Original_o_otp1cd"].Value=ItemOrder["訂購類別一"].FirstChild.OuterXml;
			this.sqlUpdateCommand1.Parameters["@Original_o_otp1seq"].Value=ItemOrder["訂單流水號"].FirstChild.OuterXml.Substring(10,3);
			this.sqlUpdateCommand1.Parameters["@o_syscd"].Value=ItemOrder["系統代碼"].FirstChild.OuterXml;
			this.sqlUpdateCommand1.Parameters["@o_custno"].Value=ItemOrder["訂戶編號"].FirstChild.OuterXml;
			this.sqlUpdateCommand1.Parameters["@o_otp1cd"].Value=ItemOrder["訂購類別一"].FirstChild.OuterXml;
			this.sqlUpdateCommand1.Parameters["@o_otp1seq"].Value=ItemOrder["訂單流水號"].FirstChild.OuterXml.Substring(10,3);
			this.sqlUpdateCommand1.Parameters["@o_otp2cd"].Value=ItemOrder["訂購類別二"].FirstChild.OuterXml;
			this.sqlUpdateCommand1.Parameters["@o_mfrno"].Value=ItemOrder["統一編號"].FirstChild.OuterXml;
			if((ItemOrder["訂購類別一"].FirstChild.OuterXml=="01")||(ItemOrder["訂購類別一"].FirstChild.OuterXml=="09"))
			{
				this.sqlUpdateCommand1.Parameters["@o_inm"].Value=ItemOrder["發票收件人姓名"].FirstChild.OuterXml;
				if(ItemOrder["發票收件人職稱"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@o_ijbti"].Value=ItemOrder["發票收件人職稱"].FirstChild.OuterXml;
				if(ItemOrder["發票收件人地址"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@o_iaddr"].Value=ItemOrder["發票收件人地址"].FirstChild.OuterXml;
				if(ItemOrder["發票收件人郵遞區號"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@o_izip"].Value=ItemOrder["發票收件人郵遞區號"].FirstChild.OuterXml;
				if(ItemOrder["發票收件人電話"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@o_itel"].Value=ItemOrder["發票收件人電話"].FirstChild.OuterXml;
				if(ItemOrder["發票收件人傳真"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@o_ifax"].Value=ItemOrder["發票收件人傳真"].FirstChild.OuterXml;
				if(ItemOrder["發票收件人手機"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@o_icell"].Value=ItemOrder["發票收件人手機"].FirstChild.OuterXml;
				if(ItemOrder["發票收件人Email"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@o_iemail"].Value=ItemOrder["發票收件人Email"].FirstChild.OuterXml;
				if(ItemOrder["付款方式"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@o_pytpcd"].Value=ItemOrder["付款方式"].FirstChild.OuterXml;
				if(ItemOrder["發票類別"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@o_invcd"].Value=ItemOrder["發票類別"].FirstChild.OuterXml;
				if(ItemOrder["發票課稅別"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@o_taxtp"].Value=ItemOrder["發票課稅別"].FirstChild.OuterXml;
				if(ItemOrder["預開發票"].FirstChild!=null)
					this.sqlUpdateCommand1.Parameters["@o_fgpreinv"].Value=ItemOrder["預開發票"].FirstChild.OuterXml;
			}
			string strbuf=ItemOrder["訂購日期"].FirstChild.OuterXml;
			this.sqlUpdateCommand1.Parameters["@o_date"].Value=strbuf.Substring(0,4)+strbuf.Substring(5,2)+strbuf.Substring(8,2);
			this.sqlUpdateCommand1.Parameters["@o_moddate"].Value=System.DateTime.Today.ToString("yyyyMMdd");
			if(ItemOrder["承辦人員"].FirstChild!=null)
				this.sqlUpdateCommand1.Parameters["@o_empno"].Value=ItemOrder["承辦人員"].FirstChild.OuterXml;;
			if(ItemOrder["訂單來源"].FirstChild!=null)
				this.sqlUpdateCommand1.Parameters["@o_orescd"].Value=ItemOrder["訂單來源"].FirstChild.OuterXml;
			this.sqlUpdateCommand1.Parameters["@o_xmldata"].Value="<?xml version=\"1.0\" encoding=\"big5\"?>"+ItemMain.OuterXml;
			this.sqlUpdateCommand1.Connection.Open();
			int ret=this.sqlUpdateCommand1.ExecuteNonQuery();
			this.sqlUpdateCommand1.Connection.Close();
//			Stored procedure 寫至訂單明細檔, 收件人檔, 收件人數量檔
			this.sqlCommand1.Parameters["@syscd"].Value=ItemOrder["系統代碼"].FirstChild.OuterXml.Trim();
			this.sqlCommand1.Parameters["@custno"].Value=ItemOrder["訂戶編號"].FirstChild.OuterXml.Trim();
			this.sqlCommand1.Parameters["@otp1cd"].Value=ItemOrder["訂購類別一"].FirstChild.OuterXml.Trim();
			this.sqlCommand1.Parameters["@otp1seq"].Value=ItemOrder["訂單流水號"].FirstChild.OuterXml.Substring(10,3);
			this.sqlCommand1.Parameters["@XML"].Value="<?xml version=\"1.0\" encoding=\"big5\"?>"+ItemMain.OuterXml;
			this.sqlCommand1.Connection.Open();
			bool resultflag;
			SqlDataReader myReader;
			try
			{
				myReader=this.sqlCommand1.ExecuteReader();
				myReader.Read();
				myReader.Close();
				resultflag=true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
				resultflag=false;
			}
			this.sqlCommand1.Connection.Close();
//			ModifyCustfg();
//			Response.Write(XmlDoc.OuterXml);
			if(resultflag)
			{
				//訂單修改成功
//				if(ret>0)
					Response.Write("OK");
//				else
//					Response.Write("ERROR");
			}
			else
				Response.Write("Error");//修改訂單失敗
		}

		//將訂戶檔之續訂戶更新
		private void ModifyCustfg()
		{
			//			XmlDocument XmlDoc = new System.Xml.XmlDocument();
			//			XmlDoc.Load(Request.InputStream);
			for(int i=0;i<this.sqlUpdateCommand2.Parameters.Count;i++)
			{
				this.sqlUpdateCommand2.Parameters[i].Value = "";
			}
			XmlNode	ItemOrder1=XmlDoc.SelectSingleNode("/root/訂單");
			XmlNode	ItemDetail1=XmlDoc.SelectSingleNode("/root/訂單明細");
			string str_fgoi, str_fgoe;
			str_fgoi="0";
			str_fgoe="0";
			this.sqlUpdateCommand2.Parameters["@Original_cust_custno"].Value=ItemOrder1["訂戶編號"].FirstChild.OuterXml;
			this.sqlUpdateCommand2.Parameters["@cust_custno"].Value=ItemOrder1["訂戶編號"].FirstChild.OuterXml;
			if(ItemOrder1["訂購類別一"].FirstChild.OuterXml=="01")
			{
				for(int i=0; i<ItemDetail1.ChildNodes.Count; i++)
				{
					if(ItemDetail1.ChildNodes.Item(i).SelectSingleNode("書籍類別").InnerText=="01")
						str_fgoi="1";
					if(ItemDetail1.ChildNodes.Item(i).SelectSingleNode("書籍類別").InnerText=="02")
						str_fgoe="1";
				}
				if((str_fgoi=="1") && (str_fgoe=="1"))
				{
					this.sqlUpdateCommand2.Parameters["@cust_fgoi"].Value=str_fgoi;
					this.sqlUpdateCommand2.Parameters["@cust_fgoe"].Value=str_fgoe;
					this.sqlUpdateCommand2.CommandText = @"UPDATE dbo.c1_cust SET cust_custno = @cust_custno, cust_fgoi=@cust_fgoi, cust_fgoe=@cust_fgoe WHERE (cust_custno = @Original_cust_custno)";
				}
				else if((str_fgoi=="1") && (str_fgoe!="1"))
				{
					this.sqlUpdateCommand2.Parameters["@cust_fgoi"].Value=str_fgoi;
					this.sqlUpdateCommand2.CommandText = @"UPDATE dbo.c1_cust SET cust_custno = @cust_custno, cust_fgoi=@cust_fgoi WHERE (cust_custno = @Original_cust_custno)";
				}
				else if((str_fgoi!="1") && (str_fgoe=="1"))
				{
					this.sqlUpdateCommand2.Parameters["@cust_fgoe"].Value=str_fgoe;
					this.sqlUpdateCommand2.CommandText = @"UPDATE dbo.c1_cust SET cust_custno = @cust_custno, cust_fgoe=@cust_fgoe WHERE (cust_custno = @Original_cust_custno)";
				}
				//				this.sqlUpdateCommand2.CommandText = @"UPDATE dbo.c1_cust SET cust_otp1seq1 = @cust_otp1seq1, cust_custno = @cust_custno, cust_fgoi WHERE (cust_custno = @Original_cust_custno)";
			this.sqlUpdateCommand2.Connection.Open();
			this.sqlUpdateCommand2.ExecuteNonQuery();
			this.sqlUpdateCommand2.Connection.Close();
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
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=isccom1;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=03212-840695;packet size=4096";
			this.sqlConnection1.ConnectionString = ConfigurationSettings.AppSettings["mrlpub2"].ToString();
			// 
			// sqlDeleteCommand1
			// 
			this.sqlDeleteCommand1.CommandText = "DELETE FROM dbo.c1_order WHERE (o_custno = @o_custno) AND (o_otp1cd = @o_otp1cd) " +
				"AND (o_otp1seq = @o_otp1seq) AND (o_syscd = @o_syscd)";
			this.sqlDeleteCommand1.Connection = this.sqlConnection1;
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.c1_order SET o_syscd = @o_syscd, o_custno = @o_custno, o_otp1cd = @o_otp1cd, o_otp1seq = @o_otp1seq, o_otp2cd = @o_otp2cd, o_mfrno = @o_mfrno, o_inm = @o_inm, o_ijbti = @o_ijbti, o_iaddr = @o_iaddr, o_izip = @o_izip, o_itel = @o_itel, o_ifax = @o_ifax, o_icell = @o_icell, o_iemail = @o_iemail, o_pytpcd = @o_pytpcd, o_fgpreinv = @o_fgpreinv, o_date = @o_date, o_moddate = @o_moddate, o_empno = @o_empno, o_xmldata = @o_xmldata, o_orescd = @o_orescd, o_invcd = @o_invcd, o_taxtp = @o_taxtp WHERE (o_custno = @Original_o_custno) AND (o_otp1cd = @Original_o_otp1cd) AND (o_otp1seq = @Original_o_otp1seq) AND (o_syscd = @Original_o_syscd)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp2cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp2cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_inm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_inm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_ijbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_ijbti", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_iaddr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_iaddr", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_izip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_izip", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_itel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_itel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_ifax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_ifax", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_icell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_icell", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_iemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_iemail", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_pytpcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_fgpreinv", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_fgpreinv", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_date", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_empno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_empno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_xmldata", System.Data.SqlDbType.NText, 10000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_orescd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_orescd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_invcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_taxtp", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = @"INSERT INTO dbo.c1_order(o_syscd, o_custno, o_otp1cd, o_otp1seq, o_otp2cd, o_mfrno, o_inm, o_ijbti, o_iaddr, o_izip, o_itel, o_ifax, o_icell, o_iemail, o_pytpcd, o_fgpreinv, o_date, o_moddate, o_oldvdate, o_empno, o_xmldata, o_orescd, o_invcd, o_taxtp) VALUES (@o_syscd, @o_custno, @o_otp1cd, @o_otp1seq, @o_otp2cd, @o_mfrno, @o_inm, @o_ijbti, @o_iaddr, @o_izip, @o_itel, @o_ifax, @o_icell, @o_iemail, @o_pytpcd, @o_fgpreinv, @o_date, @o_moddate, @o_oldvdate, @o_empno, @o_xmldata, @o_orescd, @o_invcd, @o_taxtp)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp2cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp2cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_inm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_inm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_ijbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_ijbti", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_iaddr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_iaddr", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_izip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_izip", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_itel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_itel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_ifax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_ifax", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_icell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_icell", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_iemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_iemail", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_pytpcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_fgpreinv", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_fgpreinv", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_date", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_oldvdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_oldvdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_empno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_empno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_xmldata", System.Data.SqlDbType.NText, 16, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_orescd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_orescd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_invcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_taxtp", System.Data.DataRowVersion.Current, null));
			// 
			// sqlCommand1
			// 
			this.sqlCommand1.CommandText = "dbo.sp_order_to_detail";
			this.sqlCommand1.CommandType = System.Data.CommandType.StoredProcedure;
			this.sqlCommand1.Connection = this.sqlConnection1;
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, true, ((System.Byte)(10)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@XML", System.Data.SqlDbType.Char, 7000, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			this.sqlCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, true, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = @"SELECT o_oid, o_syscd, o_custno, o_otp1cd, o_otp1seq, o_otp2cd, o_mfrno, o_inm, o_ijbti, o_iaddr, o_izip, o_itel, o_ifax, o_icell, o_iemail, o_pytpcd, o_fgpreinv, o_date, o_moddate, o_oldvdate, o_empno, o_xmldata, o_orescd, o_invcd, o_taxtp FROM dbo.c1_order";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_order", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("o_oid", "o_oid"),
																																																				  new System.Data.Common.DataColumnMapping("o_syscd", "o_syscd"),
																																																				  new System.Data.Common.DataColumnMapping("o_custno", "o_custno"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1cd", "o_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1seq", "o_otp1seq"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp2cd", "o_otp2cd"),
																																																				  new System.Data.Common.DataColumnMapping("o_mfrno", "o_mfrno"),
																																																				  new System.Data.Common.DataColumnMapping("o_inm", "o_inm"),
																																																				  new System.Data.Common.DataColumnMapping("o_ijbti", "o_ijbti"),
																																																				  new System.Data.Common.DataColumnMapping("o_iaddr", "o_iaddr"),
																																																				  new System.Data.Common.DataColumnMapping("o_izip", "o_izip"),
																																																				  new System.Data.Common.DataColumnMapping("o_itel", "o_itel"),
																																																				  new System.Data.Common.DataColumnMapping("o_ifax", "o_ifax"),
																																																				  new System.Data.Common.DataColumnMapping("o_icell", "o_icell"),
																																																				  new System.Data.Common.DataColumnMapping("o_iemail", "o_iemail"),
																																																				  new System.Data.Common.DataColumnMapping("o_pytpcd", "o_pytpcd"),
																																																				  new System.Data.Common.DataColumnMapping("o_fgpreinv", "o_fgpreinv"),
																																																				  new System.Data.Common.DataColumnMapping("o_date", "o_date"),
																																																				  new System.Data.Common.DataColumnMapping("o_moddate", "o_moddate"),
																																																				  new System.Data.Common.DataColumnMapping("o_oldvdate", "o_oldvdate"),
																																																				  new System.Data.Common.DataColumnMapping("o_empno", "o_empno"),
																																																				  new System.Data.Common.DataColumnMapping("o_xmldata", "o_xmldata"),
																																																				  new System.Data.Common.DataColumnMapping("o_orescd", "o_orescd"),
																																																				  new System.Data.Common.DataColumnMapping("o_invcd", "o_invcd"),
																																																				  new System.Data.Common.DataColumnMapping("o_taxtp", "o_taxtp")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.DeleteCommand = this.sqlDeleteCommand2;
			this.sqlDataAdapter2.InsertCommand = this.sqlInsertCommand2;
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_cust", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("cust_fgoi", "cust_fgoi"),
																																																				 new System.Data.Common.DataColumnMapping("cust_fgoe", "cust_fgoe"),
																																																				 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno")})});
			this.sqlDataAdapter2.UpdateCommand = this.sqlUpdateCommand2;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT cust_fgoi, cust_fgoe, cust_custno FROM dbo.c1_cust";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = "INSERT INTO dbo.c1_cust(cust_fgoi, cust_fgoe, cust_custno) VALUES (@cust_fgoi, @c" +
				"ust_fgoe, @cust_custno)";
			this.sqlInsertCommand2.Connection = this.sqlConnection1;
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fgoi", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fgoi", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fgoe", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fgoe", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = "UPDATE dbo.c1_cust SET cust_fgoi = @cust_fgoi, cust_fgoe = @cust_fgoe, cust_custn" +
				"o = @cust_custno WHERE (cust_custno = @Original_cust_custno)";
			this.sqlUpdateCommand2.Connection = this.sqlConnection1;
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fgoi", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fgoi", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fgoe", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fgoe", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = "DELETE FROM dbo.c1_cust WHERE (cust_custno = @cust_custno)";
			this.sqlDeleteCommand2.Connection = this.sqlConnection1;
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Original, null));
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
