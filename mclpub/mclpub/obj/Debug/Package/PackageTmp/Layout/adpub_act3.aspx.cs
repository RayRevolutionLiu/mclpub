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

namespace mclpub.Layout
{
    public partial class adpub_act3 : System.Web.UI.Page
    {
        System.Collections.Specialized.NameValueCollection configurationAppSettings = System.Configuration.ConfigurationManager.AppSettings;
        protected System.Data.SqlClient.SqlCommand sqlCommand1;
        protected System.Data.SqlClient.SqlCommand sqlCommand3;
        protected System.Data.SqlClient.SqlConnection sqlConnection1;
        protected System.Data.SqlClient.SqlDataAdapter sqlDataAdapter1;
        protected System.Data.SqlClient.SqlCommand sqlSelectCommand1;


        // 宣告 xml資料為 global, 好讓其他程式可以呼叫
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

        protected void Page_Load(object sender, EventArgs e)
        {
            // Put user code to initialize the page here
            //Response.Expires = 0;

            if (!Page.IsPostBack)
            {
                //Response.Expires = 0;

                // 測試: 先將傳過來的 Request.InputStream 輸出到檔案 test555.xml 來做檢查
                // 通過了此測試, 再開始下面的程式
                //Request.SaveAs("c:\\test_adpub_act3.xml", false);

                // 開始處理程式序: 將傳入的 XML 資料 => 存至資料庫中 ---------------
                XmlDoc = new System.Xml.XmlDocument();
                //XmlDoc.Load(Request.InputStream);
                string transValueXml = Request.Form["transValueXml"].ToString();
                XmlDoc.LoadXml(transValueXml);
                root = XmlDoc.DocumentElement;

                // 將 root 的xml內容顯示出來, 供檢查用
                //Response.Write(root.OuterXml);

                XmlNode xmlItem = XmlDoc.SelectSingleNode("/root");
                //Response.Write(xmlItem.OuterXml);


                // 抓出 xmlItem 總筆數 (去頭尾空白 node 二筆)
                int length = xmlItem.ChildNodes.Count - 2;
                //Response.Write("length= " + length + "\n");

                // Step 1 - 抓出 各落版資料之新頁次 PageNo 直接寫入DB c2_pub 裡
                string PageNo = "";
                string sqlcmd1 = "";
                string sqlcmd2 = "";
                bool ResultFlag1 = false;
                for (int i = 0; i <= length; i++)
                {
                    // 抓出非空白 nodes 的頁次
                    if (xmlItem.ChildNodes.Item(i).SelectSingleNode("頁次").InnerText != "")
                    {
                        PageNo = xmlItem.ChildNodes.Item(i).SelectSingleNode("頁次").InnerText;
                        //Response.Write("PageNo= " + PageNo + "\n");

                        // 以下二種方式都可更新資料: 方法一比較不耗 server 資源, 因在 client 端即時做
                        // 方法一: 開始抓 xml資料, 將新頁次藉 直接執行 update sql statment (稱線上 client 端 update), 來存入資料庫 table 中
                        // 抓出必要條件, 以執行 sqlcmd1 做更新動作
                        string sqlsyscd = "C2";
                        string sqlcontno = xmlItem.ChildNodes.Item(i).SelectSingleNode("合約書編號").InnerText;
                        string sqlyyyymm = xmlItem.ChildNodes.Item(i).SelectSingleNode("刊登年月").InnerText;
                        string sqlpubseq = xmlItem.ChildNodes.Item(i).SelectSingleNode("落版序號").InnerText;
                        //Response.Write("sqlsyscd= " + sqlsyscd + ", ");
                        //Response.Write("sqlcontno= " + sqlcontno + ", ");
                        //Response.Write("sqlyyyymm= " + sqlyyyymm + ", ");
                        //Response.Write("sqlpubseq= " + sqlpubseq + "\n");

                        int sqlpgno = int.Parse(PageNo);
                        if (sqlpgno < 10)
                            PageNo = "0" + sqlpgno;
                        ////Response.Write("sqlpgno= " + sqlpgno + ", ");
                        ////Response.Write("PageNo= " + PageNo + "\n");


                        // 抓出其他資料
                        string chgbkcd = xmlItem.ChildNodes.Item(i).SelectSingleNode("改稿書籍代碼").InnerText;
                        if (chgbkcd == "工材雜誌")
                            chgbkcd = "01";
                        else if (chgbkcd == "電材雜誌")
                            chgbkcd = "02";
                        string chgjno = xmlItem.ChildNodes.Item(i).SelectSingleNode("改稿期別").InnerText;
                        string chgjbkno = xmlItem.ChildNodes.Item(i).SelectSingleNode("改稿頁碼").InnerText;
                        string fgrechg = xmlItem.ChildNodes.Item(i).SelectSingleNode("改稿重出片註記").InnerText;
                        string njtpcd = xmlItem.ChildNodes.Item(i).SelectSingleNode("新稿製法代碼").InnerText;
                        //Response.Write("chgbkcd= " + chgbkcd + ", ");
                        //Response.Write("chgjno= " + chgjno + ", ");
                        //Response.Write("chgjbkno= " + chgjbkno + ", ");
                        //Response.Write("fgrechg= " + fgrechg + ", ");
                        //Response.Write("njtpcd= " + njtpcd + "\n");

                        // 確認 myCommand 之更新指令內容 - sqlcmd1: 定義在 for loop 之前
                        sqlcmd1 = " UPDATE c2_pub ";
                        sqlcmd1 = sqlcmd1 + " SET pub_pgno = " + PageNo;
                        //sqlcmd1 = sqlcmd1 + " SET pub_pgno = " + PageNo + ", pub_chgbkcd = '" + chgbkcd  + "', pub_chgjno = '" + chgjno + "', pub_chgjbkno = '" + chgjbkno + "', pub_fgrechg = '" + fgrechg + "', pub_njtpcd = '" + njtpcd + "'";
                        sqlcmd1 = sqlcmd1 + " WHERE (pub_syscd = 'C2') AND (pub_contno = '" + sqlcontno + "') AND (pub_yyyymm = '" + sqlyyyymm + "') AND (pub_pubseq = '" + sqlpubseq + "')";
                        //Response.Write("sqlcmd1= " + sqlcmd1 + "\n\n");

                        // 執行 myCommand (myCommand 是執行 sqlCommand1: sp_c2_adpub_act3_pub ) 更新資料庫: 落版 資料 c2_pub
                        SqlCommand myCommand = new SqlCommand(sqlcmd1, sqlConnection1);
                        myCommand.Connection = sqlConnection1;
                        myCommand.Connection.Open();

                        try
                        {
                            myCommand.ExecuteNonQuery();
                            ResultFlag1 = true;
                        }
                        catch (System.Data.SqlClient.SqlException ex1)
                        {
                            ResultFlag1 = false;
                            Response.Write(ex1.Message + "\n");
                            break;
                        }
                        finally
                        {
                            this.sqlConnection1.Close();
                        }
                        // 結束 抓出非空白 nodes 的頁次 if
                    }

                    // 結束 for loop
                }
                // 結束 if(!Page.IsPostBack)
                // 輸出執行結果
                if (ResultFlag1)
                {

                    Response.Write("更新落版檔之頁次成功!\n");
                }
                else
                {
                    Response.Write("更新落版檔之頁次失敗!\n");
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
            this.sqlConnection1.ConnectionString = configurationAppSettings.Get("itridpr_mrlpub");
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

        }
        #endregion
    }
}