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
	/// Summary description for S_SaveOrder.
	/// </summary>
	public class S_SaveOrder : System.Web.UI.Page
	{
		protected System.Data.SqlClient.SqlConnection sqlConnection1;
		protected System.Data.SqlClient.SqlCommand sqlCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter5;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_order;
		protected System.Data.SqlClient.SqlCommand sqlInsertCom_cust;
		protected System.Data.SqlClient.SqlCommand sqlSelectCom_cust;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCom_cust;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter_cust;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCom_cust;
		protected System.Data.SqlClient.SqlCommand sqlInsertCom_order;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCom_order;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCom_order;
		protected System.Data.SqlClient.SqlCommand sqlSelectCom_order;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand4;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand4;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand4;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand4;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand2;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand1;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter2;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand3;
		protected System.Data.SqlClient.SqlCommand sqlInsertCommand2;
		protected System.Data.SqlClient.SqlCommand sqlUpdateCommand2;
		protected System.Data.SqlClient.SqlCommand sqlDeleteCommand2;
		protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter3;
		protected System.Data.SqlClient.SqlCommand sqlSelectCommand5;
		XmlDocument XmlDoc;
		public S_SaveOrder()
		{
			Page.Init += new System.EventHandler(Page_Init);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
//			Request.SaveAs("c://test555.xml", false);
			Response.Expires=0;
			SqlTransaction Trans1;
			XmlDoc = new System.Xml.XmlDocument();
			XmlDoc.Load(Request.InputStream);
			XmlNode	ItemMain=XmlDoc.SelectSingleNode("/root");
			XmlNode	ItemOrder=XmlDoc.SelectSingleNode("/root/訂單");
			XmlNode	ItemDetail=XmlDoc.SelectSingleNode("/root/訂單明細");
			XmlElement root;
			XmlNodeList BookTypeList;
			root = XmlDoc.DocumentElement;
			BookTypeList = root.GetElementsByTagName("書籍類別");
			for(int i=0;i<this.sqlInsertCom_order.Parameters.Count;i++)
			{
				this.sqlInsertCom_order.Parameters[i].Value = "";
			}
			this.sqlInsertCom_order.Parameters["@o_syscd"].Value=ItemOrder["系統代碼"].FirstChild.OuterXml;
			this.sqlInsertCom_order.Parameters["@o_custno"].Value=ItemOrder["訂戶編號"].FirstChild.OuterXml;
			this.sqlInsertCom_order.Parameters["@o_otp1cd"].Value=ItemOrder["訂購類別一"].FirstChild.OuterXml;
			this.sqlInsertCom_order.Parameters["@o_otp1seq"].Value=ItemOrder["訂單流水號"].FirstChild.OuterXml.Substring(10,3);
			this.sqlInsertCom_order.Parameters["@o_otp2cd"].Value=ItemOrder["訂購類別二"].FirstChild.OuterXml;
			this.sqlInsertCom_order.Parameters["@o_mfrno"].Value=ItemOrder["統一編號"].FirstChild.OuterXml;
			if((ItemOrder["訂購類別一"].FirstChild.OuterXml=="01")||(ItemOrder["訂購類別一"].FirstChild.OuterXml=="09"))
			{
				this.sqlInsertCom_order.Parameters["@o_inm"].Value=ItemOrder["發票收件人姓名"].FirstChild.OuterXml;
				if(ItemOrder["發票收件人職稱"].FirstChild!=null)
					this.sqlInsertCom_order.Parameters["@o_ijbti"].Value=ItemOrder["發票收件人職稱"].FirstChild.OuterXml;
				this.sqlInsertCom_order.Parameters["@o_iaddr"].Value=ItemOrder["發票收件人地址"].FirstChild.OuterXml;
				this.sqlInsertCom_order.Parameters["@o_izip"].Value=ItemOrder["發票收件人郵遞區號"].FirstChild.OuterXml;
				this.sqlInsertCom_order.Parameters["@o_itel"].Value=ItemOrder["發票收件人電話"].FirstChild.OuterXml;
				if(ItemOrder["發票收件人傳真"].FirstChild!=null)
					this.sqlInsertCom_order.Parameters["@o_ifax"].Value=ItemOrder["發票收件人傳真"].FirstChild.OuterXml;
				if(ItemOrder["發票收件人手機"].FirstChild!=null)
					this.sqlInsertCom_order.Parameters["@o_icell"].Value=ItemOrder["發票收件人手機"].FirstChild.OuterXml;
				if(ItemOrder["發票收件人Email"].FirstChild!=null)
					this.sqlInsertCom_order.Parameters["@o_iemail"].Value=ItemOrder["發票收件人Email"].FirstChild.OuterXml;
				this.sqlInsertCom_order.Parameters["@o_pytpcd"].Value=ItemOrder["付款方式"].FirstChild.OuterXml;
				this.sqlInsertCom_order.Parameters["@o_invcd"].Value=ItemOrder["發票類別"].FirstChild.OuterXml;
				this.sqlInsertCom_order.Parameters["@o_taxtp"].Value=ItemOrder["發票課稅別"].FirstChild.OuterXml;
				this.sqlInsertCom_order.Parameters["@o_fgpreinv"].Value=ItemOrder["預開發票"].FirstChild.OuterXml;
			}
			string strbuf=ItemOrder["訂購日期"].FirstChild.OuterXml;
			this.sqlInsertCom_order.Parameters["@o_date"].Value=strbuf.Substring(0,4)+strbuf.Substring(5,2)+strbuf.Substring(8,2);
			this.sqlInsertCom_order.Parameters["@o_indate"].Value=System.DateTime.Today.ToString("yyyyMMdd");
			this.sqlInsertCom_order.Parameters["@o_moddate"].Value=System.DateTime.Today.ToString("yyyyMMdd");
			this.sqlInsertCom_order.Parameters["@o_empno"].Value=ItemOrder["承辦人員"].FirstChild.OuterXml;
			this.sqlInsertCom_order.Parameters["@o_orescd"].Value=ItemOrder["訂單來源"].FirstChild.OuterXml;
			this.sqlInsertCom_order.Parameters["@o_special"].Value="2";		//輸入舊訂單, 即不新增ia及py
//			Response.Write(ItemOrder["訂戶編號"].FirstChild.OuterXml);
			this.sqlInsertCom_order.Parameters["@o_xmldata"].Value="<?xml version=\"1.0\" encoding=\"big5\"?>"+ItemMain.OuterXml;
			this.sqlInsertCom_order.Connection.Open();
//			Trans1=this.sqlInsertCom_order.Connection.BeginTransaction();
//			this.sqlInsertCom_order.Transaction=Trans1;
			SqlDataReader myReader;
			bool resultflag;
			try
			{
				this.sqlInsertCom_order.ExecuteNonQuery();
//			this.sqlInsertCom_order.Connection.Close();			
			//-------Stored procedure 寫至訂單明細檔, 收件人檔, 收件人數量檔------//
				this.sqlCommand1.Parameters["@syscd"].Value=ItemOrder["系統代碼"].FirstChild.OuterXml;
				this.sqlCommand1.Parameters["@custno"].Value=ItemOrder["訂戶編號"].FirstChild.OuterXml;
				this.sqlCommand1.Parameters["@otp1cd"].Value=ItemOrder["訂購類別一"].FirstChild.OuterXml;
				this.sqlCommand1.Parameters["@otp1seq"].Value=ItemOrder["訂單流水號"].FirstChild.OuterXml;
				this.sqlCommand1.Parameters["@XML"].Value="<?xml version=\"1.0\" encoding=\"big5\"?>"+ItemMain.OuterXml;
//				this.sqlCommand1.Connection.Open();
				myReader=this.sqlCommand1.ExecuteReader();
				myReader.Read();
				myReader.Close();
//				this.sqlCommand1.Connection.Close();
//				Trans1.Commit();
				resultflag=true;
			}
			catch(System.Data.SqlClient.SqlException ex)
			{
//				Trans1.Rollback();
				resultflag=false;
			}
			finally
			{
				this.sqlInsertCom_order.Connection.Close();			
			}
			if(resultflag)
			{
				//訂單存檔成功
				//-------將訂戶檔之流水號更新--------//
				ModifyCustOtp1();

//				if((ItemOrder["訂購類別一"].FirstChild.OuterXml=="01")||(ItemOrder["訂購類別一"].FirstChild.OuterXml=="09"))
//				{	
					//------是否有贈閱或推廣訂單------//
//					if(CheckFreeOrder03(ItemOrder, BookTypeList))
//						Response.Write("OK");
					//-------新增發票開立單檔, 發票開立明細檔--------//
//					if(InsertIAData()==false)
//						Response.Write("Error1");//新增發票開立單檔失敗
//				}
//				else
					Response.Write("OK");
			}
			else
				Response.Write("Error2");//新增訂單失敗
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
			this.sqlDataAdapter5 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlConnection1 = new System.Data.SqlClient.SqlConnection();
			this.sqlDataAdapter4 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand4 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter_order = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCom_order = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCom_order = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCom_order = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCom_order = new System.Data.SqlClient.SqlCommand();
			this.sqlCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand3 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCommand5 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCom_cust = new System.Data.SqlClient.SqlCommand();
			this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter_cust = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCom_cust = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCom_cust = new System.Data.SqlClient.SqlCommand();
			this.sqlSelectCom_cust = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter2 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDeleteCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlInsertCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlUpdateCommand2 = new System.Data.SqlClient.SqlCommand();
			this.sqlDataAdapter3 = new System.Data.SqlClient.SqlDataAdapter();
			this.sqlDataAdapter1 = new System.Data.SqlClient.SqlDataAdapter();
			// 
			// sqlDataAdapter5
			// 
			this.sqlDataAdapter5.SelectCommand = this.sqlSelectCommand1;
			this.sqlDataAdapter5.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "ia", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("max_iano", "max_iano"),
																																																			new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd")})});
			// 
			// sqlSelectCommand1
			// 
			this.sqlSelectCommand1.CommandText = "SELECT MAX(ia_iano) AS max_iano, ia_syscd FROM dbo.ia GROUP BY ia_syscd HAVING (i" +
				"a_syscd = \'C1\')";
			this.sqlSelectCommand1.Connection = this.sqlConnection1;
			// 
			// sqlConnection1
			// 
//			this.sqlConnection1.ConnectionString = "data source=ISCCOM1;initial catalog=mrlpub;password=db600;persist security info=T" +
//				"rue;user id=webuser;workstation id=03212-840695;packet size=4096";
			this.sqlConnection1.ConnectionString = ConfigurationSettings.AppSettings["mrlpub2"].ToString();
			// 
			// sqlDataAdapter4
			// 
			this.sqlDataAdapter4.DeleteCommand = this.sqlDeleteCommand4;
			this.sqlDataAdapter4.InsertCommand = this.sqlInsertCommand4;
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
																																																			 new System.Data.Common.DataColumnMapping("iad_amt", "iad_amt")})});
			this.sqlDataAdapter4.UpdateCommand = this.sqlUpdateCommand4;
			// 
			// sqlDeleteCommand4
			// 
			this.sqlDeleteCommand4.CommandText = "DELETE FROM dbo.iad WHERE (iad_iaditem = @iad_iaditem) AND (iad_iano = @iad_iano)" +
				" AND (iad_syscd = @iad_syscd)";
			this.sqlDeleteCommand4.Connection = this.sqlConnection1;
			this.sqlDeleteCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iaditem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iaditem", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iano", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand4
			// 
			this.sqlInsertCommand4.CommandText = @"INSERT INTO dbo.iad(iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, iad_fk4, iad_projno, iad_costctr, iad_desc, iad_qty, iad_amt) VALUES (@iad_syscd, @iad_iano, @iad_iaditem, @iad_fk1, @iad_fk2, @iad_fk3, @iad_fk4, @iad_projno, @iad_costctr, @iad_desc, @iad_qty, @iad_amt)";
			this.sqlInsertCommand4.Connection = this.sqlConnection1;
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iano", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iaditem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iaditem", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk1", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk1", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk2", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk2", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk3", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk3", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk4", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk4", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_projno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_projno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_costctr", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_costctr", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_desc", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_desc", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_qty", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_qty", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_amt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_amt", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCommand4
			// 
			this.sqlSelectCommand4.CommandText = "SELECT iad_iadid, iad_syscd, iad_iano, iad_iaditem, iad_fk1, iad_fk2, iad_fk3, ia" +
				"d_fk4, iad_projno, iad_costctr, iad_desc, iad_qty, iad_amt FROM dbo.iad WHERE (i" +
				"ad_syscd = \'C1\')";
			this.sqlSelectCommand4.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCommand4
			// 
			this.sqlUpdateCommand4.CommandText = @"UPDATE dbo.iad SET iad_syscd = @iad_syscd, iad_iano = @iad_iano, iad_iaditem = @iad_iaditem, iad_fk1 = @iad_fk1, iad_fk2 = @iad_fk2, iad_fk3 = @iad_fk3, iad_fk4 = @iad_fk4, iad_projno = @iad_projno, iad_costctr = @iad_costctr, iad_desc = @iad_desc, iad_qty = @iad_qty, iad_amt = @iad_amt WHERE (iad_iaditem = @Original_iad_iaditem) AND (iad_iano = @Original_iad_iano) AND (iad_syscd = @Original_iad_syscd)";
			this.sqlUpdateCommand4.Connection = this.sqlConnection1;
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iano", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_iaditem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iaditem", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk1", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk1", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk2", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk2", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk3", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk3", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_fk4", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_fk4", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_projno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_projno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_costctr", System.Data.SqlDbType.Char, 7, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_costctr", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_desc", System.Data.SqlDbType.VarChar, 100, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_desc", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_qty", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_qty", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@iad_amt", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_amt", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_iaditem", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iaditem", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_iano", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand4.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_iad_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "iad_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter_order
			// 
			this.sqlDataAdapter_order.DeleteCommand = this.sqlDeleteCom_order;
			this.sqlDataAdapter_order.InsertCommand = this.sqlInsertCom_order;
			this.sqlDataAdapter_order.SelectCommand = this.sqlSelectCom_order;
			this.sqlDataAdapter_order.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
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
			this.sqlDataAdapter_order.UpdateCommand = this.sqlUpdateCom_order;
			// 
			// sqlDeleteCom_order
			// 
			this.sqlDeleteCom_order.CommandText = "DELETE FROM dbo.c1_order WHERE (o_custno = @o_custno) AND (o_otp1cd = @o_otp1cd) " +
				"AND (o_otp1seq = @o_otp1seq) AND (o_syscd = @o_syscd)";
			this.sqlDeleteCom_order.Connection = this.sqlConnection1;
			this.sqlDeleteCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCom_order
			// 
			this.sqlInsertCom_order.CommandText = @"INSERT INTO dbo.c1_order(o_syscd, o_custno, o_otp1cd, o_otp1seq, o_otp2cd, o_mfrno, o_inm, o_ijbti, o_iaddr, o_izip, o_itel, o_ifax, o_icell, o_iemail, o_pytpcd, o_fgpreinv, o_date, o_moddate, o_oldvdate, o_empno, o_xmldata, o_orescd, o_invcd, o_taxtp, o_indate, o_special) VALUES (@o_syscd, @o_custno, @o_otp1cd, @o_otp1seq, @o_otp2cd, @o_mfrno, @o_inm, @o_ijbti, @o_iaddr, @o_izip, @o_itel, @o_ifax, @o_icell, @o_iemail, @o_pytpcd, @o_fgpreinv, @o_date, @o_moddate, @o_oldvdate, @o_empno, @o_xmldata, @o_orescd, @o_invcd, @o_taxtp, @o_indate, @o_special)";
			this.sqlInsertCom_order.Connection = this.sqlConnection1;
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp2cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp2cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_inm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_inm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_ijbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_ijbti", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_iaddr", System.Data.SqlDbType.VarChar, 1000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_iaddr", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_izip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_izip", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_itel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_itel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_ifax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_ifax", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_icell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_icell", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_iemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_iemail", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_pytpcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_fgpreinv", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_fgpreinv", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_date", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_oldvdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_oldvdate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_empno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_empno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_xmldata", System.Data.SqlDbType.NText, 8000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_orescd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_orescd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_invcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_taxtp", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_indate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_indate", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_special", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_special", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCom_order
			// 
			this.sqlSelectCom_order.CommandText = @"SELECT o_oid, o_syscd, o_custno, o_otp1cd, o_otp1seq, o_otp2cd, o_mfrno, o_inm, o_ijbti, o_iaddr, o_izip, o_itel, o_ifax, o_icell, o_iemail, o_pytpcd, o_fgpreinv, o_date, o_moddate, o_oldvdate, o_empno, o_xmldata, o_orescd, o_invcd, o_taxtp, o_indate FROM dbo.c1_order";
			this.sqlSelectCom_order.Connection = this.sqlConnection1;
			// 
			// sqlUpdateCom_order
			// 
			this.sqlUpdateCom_order.CommandText = @"UPDATE dbo.c1_order SET o_syscd = @o_syscd, o_custno = @o_custno, o_otp1cd = @o_otp1cd, o_otp1seq = @o_otp1seq, o_otp2cd = @o_otp2cd, o_mfrno = @o_mfrno, o_inm = @o_inm, o_ijbti = @o_ijbti, o_iaddr = @o_iaddr, o_izip = @o_izip, o_itel = @o_itel, o_ifax = @o_ifax, o_icell = @o_icell, o_iemail = @o_iemail, o_pytpcd = @o_pytpcd, o_fgpreinv = @o_fgpreinv, o_date = @o_date, o_moddate = @o_moddate, o_oldvdate = @o_oldvdate, o_empno = @o_empno, o_xmldata = @o_xmldata, o_orescd = @o_orescd, o_invcd = @o_invcd, o_taxtp = @o_taxtp WHERE (o_custno = @Original_o_custno) AND (o_otp1cd = @Original_o_otp1cd) AND (o_otp1seq = @Original_o_otp1seq) AND (o_syscd = @Original_o_syscd)";
			this.sqlUpdateCom_order.Connection = this.sqlConnection1;
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp2cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp2cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_inm", System.Data.SqlDbType.Char, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_inm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_ijbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_ijbti", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_iaddr", System.Data.SqlDbType.VarChar, 1000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_iaddr", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_izip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_izip", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_itel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_itel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_ifax", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_ifax", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_icell", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_icell", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_iemail", System.Data.SqlDbType.VarChar, 80, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_iemail", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_pytpcd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_pytpcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_fgpreinv", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_fgpreinv", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_date", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_date", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_moddate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_moddate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_oldvdate", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_oldvdate", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_empno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_empno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_xmldata", System.Data.SqlDbType.NText, 8000, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_xmldata", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_orescd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_orescd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_invcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_taxtp", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCom_order.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Original, null));
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
			// sqlSelectCommand3
			// 
			this.sqlSelectCommand3.CommandText = "SELECT ia_iaid, ia_syscd, ia_iano, ia_refno, ia_mfrno, ia_pyat, ia_fgitri, ia_rnm" +
				", ia_raddr, ia_rzip, ia_rjbti, ia_rtel, ia_fgnonauto, ia_invcd, ia_taxtp, ia_sta" +
				"tus, ia_ivat FROM dbo.ia";
			this.sqlSelectCommand3.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand2
			// 
			this.sqlSelectCommand2.CommandText = "SELECT o_iano, o_custno, o_otp1cd, o_otp1seq, o_syscd FROM dbo.c1_order";
			this.sqlSelectCommand2.Connection = this.sqlConnection1;
			// 
			// sqlSelectCommand5
			// 
			this.sqlSelectCommand5.CommandText = "SELECT obtp_obtpid, obtp_otp1cd, obtp_obtpcd, obtp_obtpnm FROM dbo.c1_obtp";
			this.sqlSelectCommand5.Connection = this.sqlConnection1;
			// 
			// sqlInsertCommand1
			// 
			this.sqlInsertCommand1.CommandText = "INSERT INTO dbo.c1_order(o_iano, o_custno, o_otp1cd, o_otp1seq, o_syscd) VALUES (" +
				"@o_iano, @o_custno, @o_otp1cd, @o_otp1seq, @o_syscd)";
			this.sqlInsertCommand1.Connection = this.sqlConnection1;
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_iano", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand1
			// 
			this.sqlUpdateCommand1.CommandText = @"UPDATE dbo.c1_order SET o_iano = @o_iano, o_custno = @o_custno, o_otp1cd = @o_otp1cd, o_otp1seq = @o_otp1seq, o_syscd = @o_syscd WHERE (o_custno = @Original_o_custno) AND (o_otp1cd = @Original_o_otp1cd) AND (o_otp1seq = @Original_o_otp1seq) AND (o_syscd = @Original_o_syscd)";
			this.sqlUpdateCommand1.Connection = this.sqlConnection1;
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_iano", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_custno", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_otp1cd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1cd", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_otp1seq", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_otp1seq", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand1.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_o_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "o_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlUpdateCom_cust
			// 
			this.sqlUpdateCom_cust.CommandText = @"UPDATE dbo.c1_cust SET cust_otp1seq1 = @cust_otp1seq1, cust_otp1seq2 = @cust_otp1seq2, cust_otp1seq3 = @cust_otp1seq3, cust_otp1seq9 = @cust_otp1seq9, cust_custno = @cust_custno, cust_fgoi = @cust_fgoi, cust_fgoe = @cust_fgoe WHERE (cust_custno = @Original_cust_custno)";
			this.sqlUpdateCom_cust.Connection = this.sqlConnection1;
			this.sqlUpdateCom_cust.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq1", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq1", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_cust.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq2", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq2", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_cust.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq3", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq3", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_cust.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq9", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq9", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_cust.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_cust.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fgoi", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fgoi", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_cust.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fgoe", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fgoe", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCom_cust.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Original, null));
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
			// sqlDataAdapter_cust
			// 
			this.sqlDataAdapter_cust.DeleteCommand = this.sqlDeleteCom_cust;
			this.sqlDataAdapter_cust.InsertCommand = this.sqlInsertCom_cust;
			this.sqlDataAdapter_cust.SelectCommand = this.sqlSelectCom_cust;
			this.sqlDataAdapter_cust.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																										  new System.Data.Common.DataTableMapping("Table", "c1_cust", new System.Data.Common.DataColumnMapping[] {
																																																					 new System.Data.Common.DataColumnMapping("cust_otp1seq1", "cust_otp1seq1"),
																																																					 new System.Data.Common.DataColumnMapping("cust_otp1seq2", "cust_otp1seq2"),
																																																					 new System.Data.Common.DataColumnMapping("cust_otp1seq3", "cust_otp1seq3"),
																																																					 new System.Data.Common.DataColumnMapping("cust_otp1seq9", "cust_otp1seq9"),
																																																					 new System.Data.Common.DataColumnMapping("cust_custno", "cust_custno"),
																																																					 new System.Data.Common.DataColumnMapping("cust_fgoi", "cust_fgoi"),
																																																					 new System.Data.Common.DataColumnMapping("cust_fgoe", "cust_fgoe")})});
			this.sqlDataAdapter_cust.UpdateCommand = this.sqlUpdateCom_cust;
			// 
			// sqlDeleteCom_cust
			// 
			this.sqlDeleteCom_cust.CommandText = "DELETE FROM dbo.c1_cust WHERE (cust_custno = @cust_custno)";
			this.sqlDeleteCom_cust.Connection = this.sqlConnection1;
			this.sqlDeleteCom_cust.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCom_cust
			// 
			this.sqlInsertCom_cust.CommandText = "INSERT INTO dbo.c1_cust(cust_otp1seq1, cust_otp1seq2, cust_otp1seq3, cust_otp1seq" +
				"9, cust_custno, cust_fgoi, cust_fgoe) VALUES (@cust_otp1seq1, @cust_otp1seq2, @c" +
				"ust_otp1seq3, @cust_otp1seq9, @cust_custno, @cust_fgoi, @cust_fgoe)";
			this.sqlInsertCom_cust.Connection = this.sqlConnection1;
			this.sqlInsertCom_cust.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq1", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq1", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_cust.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq2", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq2", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_cust.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq3", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq3", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_cust.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_otp1seq9", System.Data.SqlDbType.Char, 3, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_otp1seq9", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_cust.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_custno", System.Data.SqlDbType.Char, 6, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_custno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_cust.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fgoi", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fgoi", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCom_cust.Parameters.Add(new System.Data.SqlClient.SqlParameter("@cust_fgoe", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "cust_fgoe", System.Data.DataRowVersion.Current, null));
			// 
			// sqlSelectCom_cust
			// 
			this.sqlSelectCom_cust.CommandText = "SELECT cust_otp1seq1, cust_otp1seq2, cust_otp1seq3, cust_otp1seq9, cust_custno, c" +
				"ust_fgoi, cust_fgoe FROM dbo.c1_cust";
			this.sqlSelectCom_cust.Connection = this.sqlConnection1;
			// 
			// sqlDataAdapter2
			// 
			this.sqlDataAdapter2.DeleteCommand = this.sqlDeleteCommand2;
			this.sqlDataAdapter2.InsertCommand = this.sqlInsertCommand2;
			this.sqlDataAdapter2.SelectCommand = this.sqlSelectCommand3;
			this.sqlDataAdapter2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "ia", new System.Data.Common.DataColumnMapping[] {
																																																			new System.Data.Common.DataColumnMapping("ia_iaid", "ia_iaid"),
																																																			new System.Data.Common.DataColumnMapping("ia_syscd", "ia_syscd"),
																																																			new System.Data.Common.DataColumnMapping("ia_iano", "ia_iano"),
																																																			new System.Data.Common.DataColumnMapping("ia_refno", "ia_refno"),
																																																			new System.Data.Common.DataColumnMapping("ia_mfrno", "ia_mfrno"),
																																																			new System.Data.Common.DataColumnMapping("ia_pyat", "ia_pyat"),
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
																																																			new System.Data.Common.DataColumnMapping("ia_ivat", "ia_ivat")})});
			this.sqlDataAdapter2.UpdateCommand = this.sqlUpdateCommand2;
			// 
			// sqlDeleteCommand2
			// 
			this.sqlDeleteCommand2.CommandText = "DELETE FROM dbo.ia WHERE (ia_iano = @ia_iano) AND (ia_syscd = @ia_syscd)";
			this.sqlDeleteCommand2.Connection = this.sqlConnection1;
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Original, null));
			this.sqlDeleteCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlInsertCommand2
			// 
			this.sqlInsertCommand2.CommandText = @"INSERT INTO dbo.ia (ia_syscd, ia_iano, ia_refno, ia_mfrno, ia_pyat, ia_fgitri, ia_rnm, ia_raddr, ia_rzip, ia_rjbti, ia_rtel, ia_fgnonauto, ia_invcd, ia_taxtp, ia_status, ia_ivat, ia_contno) VALUES (@ia_syscd, @ia_iano, @ia_refno, @ia_mfrno, @ia_pyat, @ia_fgitri, @ia_rnm, @ia_raddr, @ia_rzip, @ia_rjbti, @ia_rtel, @ia_fgnonauto, @ia_invcd, @ia_taxtp, @ia_status, @ia_ivat, @ia_contno)";
			this.sqlInsertCommand2.Connection = this.sqlConnection1;
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_refno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_refno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyat", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyat", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_fgitri", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgitri", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rnm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rnm", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_raddr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_raddr", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rzip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rzip", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rjbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rjbti", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rtel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rtel", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_fgnonauto", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgnonauto", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invcd", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_taxtp", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_status", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_status", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_ivat", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_ivat", System.Data.DataRowVersion.Current, null));
			this.sqlInsertCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_contno", System.Data.SqlDbType.Char, 13, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_contno", System.Data.DataRowVersion.Current, null));
			// 
			// sqlUpdateCommand2
			// 
			this.sqlUpdateCommand2.CommandText = @"UPDATE dbo.ia SET ia_syscd = @ia_syscd, ia_iano = @ia_iano, ia_refno = @ia_refno, ia_mfrno = @ia_mfrno, ia_pyat = @ia_pyat, ia_fgitri = @ia_fgitri, ia_rnm = @ia_rnm, ia_raddr = @ia_raddr, ia_rzip = @ia_rzip, ia_rjbti = @ia_rjbti, ia_rtel = @ia_rtel, ia_fgnonauto = @ia_fgnonauto, ia_invcd = @ia_invcd, ia_taxtp = @ia_taxtp, ia_status = @ia_status, ia_ivat = @ia_ivat WHERE (ia_iano = @Original_ia_iano) AND (ia_syscd = @Original_ia_syscd)";
			this.sqlUpdateCommand2.Connection = this.sqlConnection1;
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_refno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_refno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_mfrno", System.Data.SqlDbType.Char, 10, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_mfrno", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_pyat", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_pyat", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_fgitri", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgitri", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rnm", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rnm", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_raddr", System.Data.SqlDbType.VarChar, 120, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_raddr", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rzip", System.Data.SqlDbType.Char, 5, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rzip", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rjbti", System.Data.SqlDbType.VarChar, 12, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rjbti", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_rtel", System.Data.SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_rtel", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_fgnonauto", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_fgnonauto", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_invcd", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_invcd", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_taxtp", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_taxtp", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_status", System.Data.SqlDbType.Char, 1, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_status", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ia_ivat", System.Data.SqlDbType.Real, 4, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_ivat", System.Data.DataRowVersion.Current, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_iano", System.Data.SqlDbType.Char, 8, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_iano", System.Data.DataRowVersion.Original, null));
			this.sqlUpdateCommand2.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ia_syscd", System.Data.SqlDbType.Char, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "ia_syscd", System.Data.DataRowVersion.Original, null));
			// 
			// sqlDataAdapter3
			// 
			this.sqlDataAdapter3.SelectCommand = this.sqlSelectCommand5;
			this.sqlDataAdapter3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_obtp", new System.Data.Common.DataColumnMapping[] {
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpid", "obtp_obtpid"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_otp1cd", "obtp_otp1cd"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpcd", "obtp_obtpcd"),
																																																				 new System.Data.Common.DataColumnMapping("obtp_obtpnm", "obtp_obtpnm")})});
			// 
			// sqlDataAdapter1
			// 
			this.sqlDataAdapter1.DeleteCommand = this.sqlDeleteCommand1;
			this.sqlDataAdapter1.InsertCommand = this.sqlInsertCommand1;
			this.sqlDataAdapter1.SelectCommand = this.sqlSelectCommand2;
			this.sqlDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																									  new System.Data.Common.DataTableMapping("Table", "c1_order", new System.Data.Common.DataColumnMapping[] {
																																																				  new System.Data.Common.DataColumnMapping("o_iano", "o_iano"),
																																																				  new System.Data.Common.DataColumnMapping("o_custno", "o_custno"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1cd", "o_otp1cd"),
																																																				  new System.Data.Common.DataColumnMapping("o_otp1seq", "o_otp1seq"),
																																																				  new System.Data.Common.DataColumnMapping("o_syscd", "o_syscd")})});
			this.sqlDataAdapter1.UpdateCommand = this.sqlUpdateCommand1;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		//-------將訂戶檔之流水號更新--------//
		private void ModifyCustOtp1()
		{
			for(int i=0;i<this.sqlUpdateCom_cust.Parameters.Count;i++)
			{
				this.sqlUpdateCom_cust.Parameters[i].Value = "";
			}
			XmlNode	ItemOrder1=XmlDoc.SelectSingleNode("/root/訂單");
			XmlNode	ItemDetail1=XmlDoc.SelectSingleNode("/root/訂單明細");
			string str_fgoi, str_fgoe;
			str_fgoi="0";
			str_fgoe="0";
			this.sqlUpdateCom_cust.Parameters["@Original_cust_custno"].Value=ItemOrder1["訂戶編號"].FirstChild.OuterXml;
			this.sqlUpdateCom_cust.Parameters["@cust_custno"].Value=ItemOrder1["訂戶編號"].FirstChild.OuterXml;
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
					this.sqlUpdateCom_cust.Parameters["@cust_fgoi"].Value=str_fgoi;
					this.sqlUpdateCom_cust.Parameters["@cust_fgoe"].Value=str_fgoe;
					this.sqlUpdateCom_cust.CommandText = @"UPDATE dbo.c1_cust SET cust_otp1seq1 = @cust_otp1seq1, cust_custno = @cust_custno, cust_fgoi=@cust_fgoi, cust_fgoe=@cust_fgoe WHERE (cust_custno = @Original_cust_custno)";
				}
				else if((str_fgoi=="1") && (str_fgoe!="1"))
				{
					this.sqlUpdateCom_cust.Parameters["@cust_fgoi"].Value=str_fgoi;
					this.sqlUpdateCom_cust.CommandText = @"UPDATE dbo.c1_cust SET cust_otp1seq1 = @cust_otp1seq1, cust_custno = @cust_custno, cust_fgoi=@cust_fgoi WHERE (cust_custno = @Original_cust_custno)";
				}
				else if((str_fgoi!="1") && (str_fgoe=="1"))
				{
					this.sqlUpdateCom_cust.Parameters["@cust_fgoe"].Value=str_fgoe;
					this.sqlUpdateCom_cust.CommandText = @"UPDATE dbo.c1_cust SET cust_otp1seq1 = @cust_otp1seq1, cust_custno = @cust_custno, cust_fgoe=@cust_fgoe WHERE (cust_custno = @Original_cust_custno)";
				}
				else
					this.sqlUpdateCom_cust.CommandText = @"UPDATE dbo.c1_cust SET cust_otp1seq1 = @cust_otp1seq1, cust_custno = @cust_custno WHERE (cust_custno = @Original_cust_custno)";
				this.sqlUpdateCom_cust.Parameters["@cust_otp1seq1"].Value=ItemOrder1["訂單流水號"].FirstChild.OuterXml.Substring(10,3);
			}
			else if(ItemOrder1["訂購類別一"].FirstChild.OuterXml=="02")
			{
				this.sqlUpdateCom_cust.Parameters["@cust_otp1seq2"].Value=ItemOrder1["訂單流水號"].FirstChild.OuterXml.Substring(10,3);
				this.sqlUpdateCom_cust.CommandText = @"UPDATE dbo.c1_cust SET cust_otp1seq2 = @cust_otp1seq2, cust_custno = @cust_custno WHERE (cust_custno = @Original_cust_custno)";
			}
			else if(ItemOrder1["訂購類別一"].FirstChild.OuterXml=="03")
			{
				this.sqlUpdateCom_cust.Parameters["@cust_otp1seq3"].Value=ItemOrder1["訂單流水號"].FirstChild.OuterXml.Substring(10,3);
				this.sqlUpdateCom_cust.CommandText = @"UPDATE dbo.c1_cust SET cust_otp1seq3 = @cust_otp1seq3, cust_custno = @cust_custno WHERE (cust_custno = @Original_cust_custno)";
			}
			else if(ItemOrder1["訂購類別一"].FirstChild.OuterXml=="09")
			{
				this.sqlUpdateCom_cust.Parameters["@cust_otp1seq9"].Value=ItemOrder1["訂單流水號"].FirstChild.OuterXml.Substring(10,3);
				this.sqlUpdateCom_cust.CommandText = @"UPDATE dbo.c1_cust SET cust_otp1seq9 = @cust_otp1seq9, cust_custno = @cust_custno WHERE (cust_custno = @Original_cust_custno)";
			}
			this.sqlUpdateCom_cust.Connection.Open();
			this.sqlUpdateCom_cust.ExecuteNonQuery();
			this.sqlUpdateCom_cust.Connection.Close();
		}
		
		//------Check有無推廣訂單, 如果有將其推廣截止日改為今天-------//
		private bool CheckFreeOrder03(XmlNode ItemOrder, XmlNodeList BookTypeList)
		{
			bool	ret=false;
			string strbuf="";
			for (int i=0; i < BookTypeList.Count; i++)
			{   
				strbuf=strbuf+BookTypeList[i].InnerXml.Substring(0,2);
			} 
			string strbuf1=this.sqlSelectCom_order.CommandText;
			this.sqlSelectCom_order.CommandText=this.sqlSelectCom_order.CommandText+" ORDER BY  o_oid DESC";
			DataSet ds = new DataSet();
			this.sqlDataAdapter_order.Fill(ds, "c1_order");
			DataView dv = ds.Tables["c1_order"].DefaultView;
			dv.RowFilter=" o_syscd='C1' and o_custno='"+ItemOrder["訂戶編號"].FirstChild.OuterXml+"' and o_otp1cd='03'";
			if(dv.Count>0)
			{
				XmlDocument XmlDoc1 = new System.Xml.XmlDocument();
				XmlNode	ItemOrder1;
				XmlNode	ItemDetail1;
				XmlElement root1;
				XmlNodeList EndDateList1;
				XmlNodeList BookTypeList1;
				XmlDoc1.LoadXml(dv[0].Row["o_xmldata"].ToString());
				ItemOrder1=XmlDoc1.SelectSingleNode("/root/訂單");
				ItemDetail1=XmlDoc1.SelectSingleNode("/root/訂單明細");

				for(int i=0; i<ItemDetail1.ChildNodes.Count; i++)
				{   
					for(int j=0; j<BookTypeList.Count; j++)
					{
						if(ItemDetail1.ChildNodes.Item(i).SelectSingleNode("書籍類別").InnerText.Substring(0,2)==BookTypeList[j].InnerXml.Substring(0,2))
						{
							DateTime date1=DateTime.Parse(ItemDetail1.ChildNodes.Item(i).SelectSingleNode("訂閱訖時").InnerXml);
							if(date1>System.DateTime.Today)
							{
								ItemDetail1.ChildNodes.Item(i).SelectSingleNode("訂閱訖時").InnerXml=System.DateTime.Today.ToString("yyyy/MM/dd");
								ret=true;
							}
						}
					}
				} 
				for(int i=0;i<this.sqlUpdateCom_order.Parameters.Count;i++)
				{
					this.sqlUpdateCom_order.Parameters[i].Value = System.Data.ParameterDirection.Input;
				}
				this.sqlUpdateCom_order.Parameters["@Original_o_syscd"].Value="C1";
				this.sqlUpdateCom_order.Parameters["@Original_o_custno"].Value=ItemOrder1["訂戶編號"].FirstChild.OuterXml;
				this.sqlUpdateCom_order.Parameters["@Original_o_otp1cd"].Value="03";
				this.sqlUpdateCom_order.Parameters["@Original_o_otp1seq"].Value=ItemOrder1["訂單流水號"].FirstChild.OuterXml.Substring(10,3);
				this.sqlUpdateCom_order.Parameters["@o_syscd"].Value="C1";
				this.sqlUpdateCom_order.Parameters["@o_custno"].Value=ItemOrder1["訂戶編號"].FirstChild.OuterXml;
				this.sqlUpdateCom_order.Parameters["@o_otp1cd"].Value="03";
				this.sqlUpdateCom_order.Parameters["@o_otp1seq"].Value=ItemOrder1["訂單流水號"].FirstChild.OuterXml.Substring(10,3);
				this.sqlUpdateCom_order.Parameters["@o_xmldata"].Value=XmlDoc1.OuterXml;
				this.sqlUpdateCom_order.Parameters["@o_moddate"].Value=System.DateTime.Today.ToString("yyyyMMdd");
				this.sqlUpdateCom_order.CommandText=@"UPDATE dbo.c1_order SET o_xmldata = @o_xmldata, o_moddate = @o_moddate WHERE (o_custno = @Original_o_custno) AND (o_otp1cd = @Original_o_otp1cd) AND (o_otp1seq = @Original_o_otp1seq) AND (o_syscd = @Original_o_syscd)";
				this.sqlUpdateCom_order.Connection.Open();
				this.sqlUpdateCom_order.ExecuteNonQuery();
				this.sqlUpdateCom_order.Connection.Close();
				this.sqlSelectCom_order.CommandText=strbuf1;
				//		Stored procedure 修改推廣及贈閱的訂單明細檔, 收件人檔, 收件人數量檔
				//			....
			}
			return ret;
		}
	}
}
