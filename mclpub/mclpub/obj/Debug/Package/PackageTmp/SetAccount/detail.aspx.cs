using System;
using System.Collections.Generic;

using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;
using System.Text;

using FlexCel.Core;
using FlexCel.XlsAdapter;
using FlexCel.Render;

namespace mclpub.Class.SetAccount
{
    public partial class detail : System.Web.UI.Page
    {
       

        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"].ToString();

        InvoiceListPrintCancle_DB myPub = new InvoiceListPrintCancle_DB();

        //為了對GET的參數進行編碼
        security se = new security();

        public string syscd;
        public string date;
        public string seq;
        public int i; //for迴圈用
     
        protected void Page_Load(object sender, EventArgs e)
        {
          
            //ASP.NET 慣例
            if (!IsPostBack)
            {
                try
                {
                 
                    //對編碼後的參數進行解讀
                    syscd = se.decryptquerystring(Request.QueryString["syscd"].ToString());
                    date = se.decryptquerystring(Request.QueryString["date"].ToString());
                    seq = se.decryptquerystring(Request.QueryString["seq"].ToString());
                   
                    LabelSyscd.Text = syscd;
                    LabelDate.Text = date;
                    LabelSeq.Text = seq;

                    DataTable dt = myPub.SelectC2cust(syscd, date, seq);

                    //將結果導給 PsGV
                    PsGV.DataSource = dt;
                    PsGV.DataBind();
                }
                    //GET參數如果不符合編碼規則, 則秀出錯誤訊息
                catch (Exception ex)
                {
                    JavaScript.AlertMessageRedirect(this.Page, ex.Message, "../Default.aspx");
                }

            }

        }

        protected void req(object sender, EventArgs e){

          

        }

        /* 按鈕動作 */

        //列印發票開立清單
        protected void Btn1_Click(object sender, EventArgs e)
        {
            bool chk = false;
            for (int i = 0; i < PsGV.Rows.Count; i++)
            {
                if (((CheckBox)PsGV.Rows[i].Cells[0].FindControl("CheckBox2")).Checked)
                {
                    chk = true;
                }
            }

            if (chk == false)
            {
                JavaScript.AlertMessage(this.Page, string.Format("尚未勾選任何項目"));
                return;
            }

            //對編碼後的參數進行解讀
            syscd = se.decryptquerystring(Request.QueryString["syscd"].ToString());
            date = se.decryptquerystring(Request.QueryString["date"].ToString());
            seq = se.decryptquerystring(Request.QueryString["seq"].ToString());

            Response.Clear();

            ExcelFile Xls = new XlsFile(true); //設定一XLS 物件
            //設定XLS範本路徑
            string fileSpec = Server.MapPath("~/SetAccount/template/" + "invoiceList.xls");
            Xls.Open(fileSpec); // 打開範本
            Xls.ActiveSheet = 1; //設定EXCEL分頁標籤


            //取出清單相關資料

            /* ----- 清單內容-----*/

            //新增SQL 指令
            SqlCommand oCmd = new SqlCommand();
            //新增SQL指令的連線
            oCmd.Connection = new SqlConnection(Conn);


            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT ia.ia_iano,ia.ia_iaitem ,ia.ia_refno ,ia.ia_mfrno ,mfr.mfr_inm ,ia.ia_invno ,ia.ia_invdate ,ia.ia_fgnonauto ,ia.ia_syscd ,ia.ia_iasdate ,ia.ia_iasseq,ia.ia_pyat");
            sb.Append(@",case ia.ia_invcd when '2' then '二聯式' when '3' then '三聯式' when '4' then '其他' end as ia_invcd,");
            sb.Append(@"case ia.ia_taxtp when '1' then '應稅' when '2' then '零稅' when '3' then '免稅' end as ia_taxtp ,mfr_inm ");
            sb.Append(@",CASE ia.ia_fgitri when '06' then ' 所內委託' when '07' then '院內往來' else '' end as ia_fgitri ");
            //sb.Append(@"");
            //sb.Append(@"");
            sb.Append(@"FROM ia,mfr ");
            sb.Append(@"WHERE  ia.ia_mfrno = mfr.mfr_mfrno  and ia.ia_iasdate = @listDate and ia.ia_iasseq = @listSeq ORDER BY ia.ia_iaitem ");
        

            oCmd.Parameters.AddWithValue("@listDate", date); //轉檔年月
            oCmd.Parameters.AddWithValue("@listSeq", seq); //批號

            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;


            //設定資料讀取
            SqlDataReader dr = null;

            //資料庫連線
            oCmd.Connection.Open();
            //執行資料庫指令
            dr = oCmd.ExecuteReader();

            //讀取資料
            
            int col = 5;
            string item;
            int TotalCount = 0;//發票總金額

            //將所清單資料 寫入EXCEL 檔

            Xls.SetCellValue(3, 2, syscd);    // 系統代號

            Xls.SetCellValue(3, 4, date);      // 轉檔年月

            Xls.SetCellValue(3, 6, seq);       // 批號

            Xls.SetCellValue(1, 7, "列表日期：" + DateTime.Now.ToString("yyyy/MM/dd"));       // 列表日期

            while (dr.Read())
            {



                for (i = 0; i < this.PsGV.Rows.Count; i++)
                {


                    if (((CheckBox)PsGV.Rows[i].FindControl("CheckBox2")).Checked)
                    {

                        //選取清單的項目
                        item = PsGV.Rows[i].Cells[1].Text;

                        string drItem = dr["ia_iaitem"].ToString();
                        //輸出之前, 檢查該項目是否有被選取
                        if (drItem == item)
                        {
                            Xls.SetCellValue(col, 1, dr["ia_iaitem"]);//將資料寫入EXCEL檔 

                            //if (dr["ia_refno"].ToString().Length != 10)
                            //{
                            //    Xls.SetCellValue(col, 2, dr["ia_refno"]);
                            //}

                            Xls.SetCellValue(col, 2, dr["ia_mfrno"]);
                            Xls.SetCellValue(col, 3, dr["mfr_inm"]);
                            Xls.SetCellValue(col, 4, dr["ia_refno"]);
                            Xls.SetCellValue(col, 5, dr["ia_pyat"]);
                            Xls.SetCellValue(col, 6, dr["ia_invcd"]);
                            Xls.SetCellValue(col, 7, dr["ia_taxtp"]);
                            Xls.SetCellValue(col, 8, dr["ia_fgitri"]);
                            col++;
                            TotalCount += Convert.ToInt32(dr["ia_pyat"]);
                        }
                    }
                }

            }

            TFlxFormat tfBorderTop = Xls.GetDefaultFormat;
            tfBorderTop.Borders.Top.Style = TFlxBorderStyle.Double;
            tfBorderTop.Font.Name = "Times New Roman";
            tfBorderTop.HAlignment = THFlxAlignment.center;
            int tfBorderTopI = Xls.AddFormat(tfBorderTop);
            tfBorderTop = null;

            Xls.SetCellValue(5 + PsGV.Rows.Count + 1, 1, "");
            Xls.SetCellValue(5 + PsGV.Rows.Count + 1, 2, "");
            Xls.SetCellValue(5 + PsGV.Rows.Count + 1, 3, "");
            Xls.SetCellValue(5 + PsGV.Rows.Count + 1, 4, "發票總金額");
            Xls.SetCellValue(5 + PsGV.Rows.Count + 1, 5, TotalCount);
            Xls.SetCellValue(5 + PsGV.Rows.Count + 1, 6, "");
            Xls.SetCellValue(5 + PsGV.Rows.Count + 1, 7, "");
            Xls.SetCellValue(5 + PsGV.Rows.Count + 1, 8, "");
            

            Common.excuteExcel(Xls, "invoice.xls");

        }

        //列印發票開立申請單
        protected void Btn2_Click(object sender, EventArgs e)
        {
            bool chk = false;
            for (int j = 0; j < PsGV.Rows.Count; j++)
            {
                if (((CheckBox)PsGV.Rows[j].Cells[0].FindControl("CheckBox2")).Checked)
                {
                    chk = true;
                }
            }

            if (chk == false)
            {
                JavaScript.AlertMessage(this.Page, string.Format("尚未勾選任何項目"));
                return;
            }

            //對編碼後的參數進行解讀
            syscd = se.decryptquerystring(Request.QueryString["syscd"].ToString());
            date = se.decryptquerystring(Request.QueryString["date"].ToString());
            seq = se.decryptquerystring(Request.QueryString["seq"].ToString());

            //輸出EXCEL前一定要執行否則容易出錯
            Response.Clear();

            ExcelFile Xls = new XlsFile(true); //設定一XLS 物件
            //設定XLS範本路徑
            string fileSpec = Server.MapPath("~/SetAccount/template/" + "invoiceApply.xls");
            Xls.Open(fileSpec); // 打開範本
            Xls.ActiveSheet = 1; //設定EXCEL分頁標籤


            //取出清單相關資料


            //將所清單資料 寫入EXCEL 檔

            DateTime pdt = DateTime.Now;
            string printdate = string.Format("{0:d}", pdt);

           


            /* ----- 發票資料-----*/

            //新增SQL 指令
            SqlCommand oCmd = new SqlCommand();
            //新增SQL指令的連線
            oCmd.Connection = new SqlConnection(Conn);


            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT  ia.ia_pyat,ia.ia_invcd,ia.ia_taxtp,ia.ia_iano,ia.ia_rtel,ia.ia_cname,ia.ia_tel,ia.ia_contno,ia.ia_rjbti ,ia.ia_rzip ,ia.ia_raddr ,ia.ia_rnm ,ia.ia_iaitem ,ia.ia_refno ,ia.ia_mfrno ,mfr.mfr_inm ,ia.ia_invno ,ia.ia_invdate ,ia.ia_fgitri,ia.ia_fgnonauto ,ia.ia_syscd ,ia.ia_iasdate ,ia.ia_iasseq, syscd.sys_deptcd FROM ia,mfr, syscd WHERE  ia.ia_mfrno = mfr.mfr_mfrno  and ia.ia_iasdate = @listDate and ia.ia_iasseq = @listSeq and ia.ia_syscd = syscd.sys_syscd ORDER BY ia.ia_iaitem DESC");//加DESC是因為EXCEL的SHEET會從大的放在最左邊 對使用者而言看起來是第一筆

            oCmd.Parameters.AddWithValue("@listDate", date); //轉檔年月
            oCmd.Parameters.AddWithValue("@listSeq", seq); //批號

            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;


            //設定資料讀取
            SqlDataReader dr = null;

            //資料庫連線
            oCmd.Connection.Open();
            //執行資料庫指令
            dr = oCmd.ExecuteReader();

            //讀取資料
            int col = 4;
            int i;
            string item;

            while (dr.Read())
            {

                for (i = 0; i < this.PsGV.Rows.Count; i++)
                {

                    if (((CheckBox)PsGV.Rows[i].FindControl("CheckBox2")).Checked)
                    {

                        //選取清單的項目
                        item = PsGV.Rows[i].Cells[1].Text;

                        string drItem = dr["ia_iaitem"].ToString();
                        //輸出之前, 檢查該項目是否有被選取
                        if (drItem == item)
                        {

                            //複製第一頁分頁至 第二分頁之前 成為新的第二頁
                            Xls.InsertAndCopySheets(1, 2, 1);

                            //切換至第二頁 也就是新的分頁
                            Xls.ActiveSheet = 2;

                           

                            //發票基本資料
                            Xls.SetCellValue(5, 2, printdate);       // 列印日期

                            Xls.SetCellValue(7,  2, dr["ia_rzip"].ToString().Trim() + dr["ia_raddr"].ToString().Trim());    //發票郵寄地址
                            Xls.SetCellValue(8,  2, dr["mfr_inm"].ToString().Trim());      //公司名稱

                            //如果是身分證字號就不顯示
                            if (dr["ia_mfrno"].ToString().Trim().Length == 10)
                            {
                                Xls.SetCellValue(9, 2, "");     //統一編號
                            }
                            else
                            {
                                Xls.SetCellValue(9, 2, dr["ia_mfrno"].ToString().Trim());     //統一編號
                            }

                            Xls.SetCellValue(10, 2, dr["ia_rnm"].ToString().Trim() + dr["ia_rjbti"].ToString().Trim());    //發票收件人姓名
                            Xls.SetCellValue(11, 2, dr["ia_rtel"].ToString().Trim());      //電話
                            
                           //發票類別

                            if(dr["ia_invcd"].ToString().Trim() == "2"){
                                Xls.SetCellValue(13, 2, " ●  二聯            ○  三聯               ○  其它 ");     
                            }
                            else if(dr["ia_invcd"].ToString().Trim() == "3"){
                                Xls.SetCellValue(13, 2, " ○  二聯            ●  三聯               ○  其它 ");    
                            }
                            else{
                                Xls.SetCellValue(13, 2, " ○  二聯            ○  三聯               ●  其它 ");    
                            }

                            //營業稅

                            if (dr["ia_taxtp"].ToString().Trim() == "1") {
                                Xls.SetCellValue(14, 2, " ●  應稅5%          ○  零稅               ○  免稅  ");
                            }
                            else if (dr["ia_taxtp"].ToString().Trim() == "2")
                            {
                                Xls.SetCellValue(14, 2, " ○  應稅5%          ●  零稅               ○  免稅  ");
                            }
                            else {
                                Xls.SetCellValue(14, 2, " ○  應稅5%          ○  零稅               ●  免稅  ");
                            }

                            Xls.SetCellValue( 8, 7, dr["ia_refno"].ToString().Trim());    //發票開立單編號
                            Xls.SetCellValue( 9, 7, dr["sys_deptcd"].ToString().Trim());  //部門代號
                            Xls.SetCellValue(10, 7, dr["ia_contno"].ToString().Trim());   //合約編號(訂單編號)

                            //Xls.SetCellValue(13, 6, dr["ia_mfrno"].ToString().Trim());    //發票日期
                            //Xls.SetCellValue(14, 6, dr["ia_rtel"].ToString().Trim());     //發票號碼

                            Xls.SetCellValue(6, 10, ConfigurationManager.AppSettings["invoiceApply"].ToString());     //訂戶聯絡人先寫死阿鳳
                            Xls.SetCellValue(7, 10, dr["ia_cname"].ToString().Trim());     //業務聯絡人
                            Xls.SetCellValue(8, 10, dr["ia_tel"].ToString().Trim());       //電話

                            Xls.SetCellValue(36, 7, dr["ia_pyat"].ToString().Trim());       //總計

                            //--------------------發票細項

                            //如果發票種類是C4 則要使用不同方式列印細項
                            if (syscd == "C4")
                            {

                                //取得發票第一筆資料

                                //新增SQL 指令
                                SqlCommand oCmd2 = new SqlCommand();
                                //新增SQL指令的連線
                                oCmd2.Connection = new SqlConnection(Conn);

                                StringBuilder sb2 = new StringBuilder();

                                sb2.Append(@" SELECT TOP 1  iad.iad_iaditem ,iad.iad_projno ,iad.iad_desc ,iad.iad_qty ,iad.iad_uprice ,ia.ia_syscd ,ia.ia_iano ,ia.ia_invcd,ia.ia_taxtp ,ia.ia_pyat ,iad.iad_amt FROM ia ,iad WHERE ia.ia_syscd = iad.iad_syscd and ia.ia_iano = iad.iad_iano and ia.ia_iano = @iano and ia.ia_syscd = @syscd ORDER BY ia.ia_syscd ASC, ia.ia_iano ASC,iad.iad_iaditem ASC,iad.iad_projno ASC ");

                                oCmd2.Parameters.AddWithValue("@iano", dr["ia_iano"].ToString()); //發票號碼
                                oCmd2.Parameters.AddWithValue("@syscd", dr["ia_syscd"].ToString()); //系統總類


                                oCmd2.CommandText = sb2.ToString();
                                oCmd2.CommandType = CommandType.Text;


                                //設定資料讀取
                                SqlDataReader dr2 = null;

                                //資料庫連線
                                oCmd2.Connection.Open();
                                //執行資料庫指令
                                dr2 = oCmd2.ExecuteReader();


                              
                                dr2.Read();

                                string dritem   = dr2["iad_iaditem"].ToString();  // 項次
                                string drprojno = dr2["iad_projno"].ToString();   // 計畫代號
                                string drdesc   = dr2["iad_desc"].ToString().Trim();     // 品名

                                //取得發票最後一筆資料

                                //新增SQL 指令
                                SqlCommand oCmdt = new SqlCommand();
                                //新增SQL指令的連線
                                oCmdt.Connection = new SqlConnection(Conn);

                                StringBuilder sbt = new StringBuilder();

                                sbt.Append(@" SELECT TOP 1  iad.iad_iaditem ,iad.iad_projno ,iad.iad_desc ,iad.iad_qty ,iad.iad_uprice ,ia.ia_syscd ,ia.ia_iano ,ia.ia_invcd,ia.ia_taxtp ,ia.ia_pyat ,iad.iad_amt FROM ia ,iad WHERE ia.ia_syscd = iad.iad_syscd and ia.ia_iano = iad.iad_iano and ia.ia_iano = @iano and ia.ia_syscd = @syscd ORDER BY ia.ia_syscd ASC, ia.ia_iano ASC,iad.iad_iaditem DESC,iad.iad_projno ASC ");

                                oCmdt.Parameters.AddWithValue("@iano", dr["ia_iano"].ToString()); //發票號碼
                                oCmdt.Parameters.AddWithValue("@syscd", dr["ia_syscd"].ToString()); //系統總類


                                oCmdt.CommandText = sbt.ToString();
                                oCmdt.CommandType = CommandType.Text;


                                //設定資料讀取
                                SqlDataReader drt = null;

                                //資料庫連線
                                oCmdt.Connection.Open();
                                //執行資料庫指令
                                drt = oCmdt.ExecuteReader();
                             
                                drt.Read();

                                //string drtd =drt["iad_desc"].ToString().Trim().Replace("材網廣告費", "");

                                drdesc = drdesc + "~" + drt["iad_desc"].ToString().Trim().Replace("材網廣告費", "");


                                //取得發票總計
                                //新增SQL 指令
                                SqlCommand oCmdc = new SqlCommand();
                                //新增SQL指令的連線
                                oCmdc.Connection = new SqlConnection(Conn);

                                StringBuilder sbc = new StringBuilder();

                                sbc.Append(@" SELECT iad_iano, SUM(iad_qty) AS qty, SUM(iad_amt) AS amt FROM [mclpub].[dbo].[iad]  WHERE [iad_syscd] = @syscd AND iad_iano = @iano GROUP BY iad_iano");

                                oCmdc.Parameters.AddWithValue("@iano", dr["ia_iano"].ToString()); //發票號碼
                                oCmdc.Parameters.AddWithValue("@syscd", dr["ia_syscd"].ToString()); //系統總類


                                oCmdc.CommandText = sbc.ToString();
                                oCmdc.CommandType = CommandType.Text;


                                //設定資料讀取
                                SqlDataReader drc = null;

                                //資料庫連線
                                oCmdc.Connection.Open();
                                //執行資料庫指令
                                drc = oCmdc.ExecuteReader();

                                drc.Read();

                                string drqty = drc["qty"].ToString();
                                string dramt = drc["amt"].ToString();

                                //將所有資料寫入EXCEL
                                int detail_cunt = 16;

                                    Xls.SetCellValue(detail_cunt, 1, dritem);  // 項次
                                    Xls.SetCellValue(detail_cunt, 2, drprojno);   // 計畫代號
                                    Xls.SetCellValue(detail_cunt, 4, drdesc);     // 品名
                                    Xls.SetCellValue(detail_cunt, 5, drqty);      // 數量
                                    //Xls.SetCellValue(detail_cunt, 6, drt["iad_uprice"]);   // 單價
                                    Xls.SetCellValue(detail_cunt, 7, dramt);      // 總價
                                    Xls.SetCellValue(detail_cunt + 1, 4, "(以下空白)");
                            }
                            //發票種類非C4 則單純印出細項
                            else {

                                //新增SQL 指令
                                SqlCommand oCmd2 = new SqlCommand();
                                //新增SQL指令的連線
                                oCmd2.Connection = new SqlConnection(Conn);

                                StringBuilder sb2 = new StringBuilder();

                                sb2.Append(@" SELECT  iad.iad_iaditem ,iad.iad_projno ,iad.iad_desc ,iad.iad_qty ,iad.iad_uprice ,ia.ia_syscd ,ia.ia_iano ,ia.ia_invcd,ia.ia_taxtp ,ia.ia_pyat ,iad.iad_amt FROM ia ,iad WHERE ia.ia_syscd = iad.iad_syscd and ia.ia_iano = iad.iad_iano and ia.ia_iano = @iano and ia.ia_syscd = @syscd ORDER BY ia.ia_syscd ASC, ia.ia_iano ASC,iad.iad_iaditem ASC,iad.iad_projno ASC ");

                                oCmd2.Parameters.AddWithValue("@iano", dr["ia_iano"].ToString()); //發票號碼
                                oCmd2.Parameters.AddWithValue("@syscd", dr["ia_syscd"].ToString()); //系統總類


                                oCmd2.CommandText = sb2.ToString();
                                oCmd2.CommandType = CommandType.Text;


                                //設定資料讀取
                                SqlDataReader dr2 = null;

                                //資料庫連線
                                oCmd2.Connection.Open();
                                //執行資料庫指令
                                dr2 = oCmd2.ExecuteReader();

                                int detail_cunt = 16;

                                while (dr2.Read())
                                {

                                    Xls.SetCellValue(detail_cunt, 1, dr2["iad_iaditem"]);  // 項次
                                    Xls.SetCellValue(detail_cunt, 2, dr2["iad_projno"]);   // 計畫代號
                                    Xls.SetCellValue(detail_cunt, 4, dr2["iad_desc"]);     // 品名
                                    Xls.SetCellValue(detail_cunt, 5, dr2["iad_qty"]);      // 數量
                                    Xls.SetCellValue(detail_cunt, 6, dr2["iad_uprice"]);   // 單價
                                    Xls.SetCellValue(detail_cunt, 7, dr2["iad_amt"]);      // 總價
                                    Xls.SetCellValue(detail_cunt + 1, 4, "(以下空白)");
                                    detail_cunt++;

                                }

                            }
                            
                            //
                            col++;
                        
                        }
                    }
                }
            }

           
           //操作完畢後，將分頁回歸到第一頁, 並將作為範例的第一頁刪除
            Xls.ActiveSheet = 1;
            Xls.DeleteSheet(1);
           
    
            //操作完畢後，將分頁回歸到第一頁
            Xls.ActiveSheet = 1;

            //下載的檔名
            Common.excuteExcel(Xls, "invoiceApply.xls");
        }

        protected void Btn3_Click(object sender, EventArgs e)
        {
            bool chk = false;
            for (int i = 0; i < PsGV.Rows.Count; i++)
            {
                if (((CheckBox)PsGV.Rows[i].Cells[0].FindControl("CheckBox2")).Checked)
                {
                    chk = true;
                }
            }

            if (chk == false)
            {
                JavaScript.AlertMessage(this.Page, string.Format("尚未勾選任何項目"));
                return;
            }

            //對編碼後的參數進行解讀
            syscd = se.decryptquerystring(Request.QueryString["syscd"].ToString());
            date = se.decryptquerystring(Request.QueryString["date"].ToString());
            seq = se.decryptquerystring(Request.QueryString["seq"].ToString());

            DateTime pdt = DateTime.Now;

            string printdate = string.Format("{0:d}", pdt);

            //輸出EXCEL前一定要執行否則容易出錯
            Response.Clear();

            ExcelFile Xls = new XlsFile(true); //設定一XLS 物件
            //設定XLS範本路徑
            string fileSpec = Server.MapPath("~/SetAccount/template/" + "invoiceSend.xls");
            Xls.Open(fileSpec); // 打開範本
            Xls.ActiveSheet = 1; //設定EXCEL分頁標籤


            //取出清單相關資料


            //將所清單資料 寫入EXCEL 檔

            Xls.SetCellValue(2, 2, syscd);       // 系統代號

            Xls.SetCellValue(2, 4, date);         // 轉檔年月

            Xls.SetCellValue(2, 6, seq);          // 批號

            Xls.SetCellValue(2, 9, printdate);       // 列印日期


            /* ----- 清單內容-----*/

            //新增SQL 指令
            SqlCommand oCmd = new SqlCommand();
            //新增SQL指令的連線
            oCmd.Connection = new SqlConnection(Conn);


            StringBuilder sb = new StringBuilder();

            sb.Append(@"SELECT 
ia.ia_rzip ,ia.ia_raddr ,ia.ia_rnm ,ia.ia_iaitem ,ia.ia_refno ,ia.ia_mfrno ,mfr.mfr_inm ,ia.ia_invno ,ia.ia_invdate ,ia.ia_fgitri,ia.ia_fgnonauto ,ia.ia_syscd ,ia.ia_iasdate ,ia.ia_iasseq FROM ia,mfr WHERE  ia.ia_mfrno = mfr.mfr_mfrno  and ia.ia_iasdate = @listDate and ia.ia_iasseq = @listSeq ORDER BY ia.ia_iaitem ASC");

            oCmd.Parameters.AddWithValue("@listDate", date); //轉檔年月
            oCmd.Parameters.AddWithValue("@listSeq", seq); //批號

            oCmd.CommandText = sb.ToString();
            oCmd.CommandType = CommandType.Text;


            //設定資料讀取
            SqlDataReader dr = null;

            //資料庫連線
            oCmd.Connection.Open();
            //執行資料庫指令
            dr = oCmd.ExecuteReader();

            //讀取資料
            int col = 4;
            string item;
            int num = 0;
            TXlsCellRange myRange = new TXlsCellRange("A4:J4");

            if (PsGV.Rows.Count > 1)
            {
                for (i = 0; i < PsGV.Rows.Count-1; i++)
                {
                    if (((CheckBox)PsGV.Rows[i].FindControl("CheckBox2")).Checked)
                    {
                        Xls.InsertAndCopyRange(myRange, col + 1, 1, 1, TFlxInsertMode.NoneDown);
                        col++;

                    }
                }
            }
            col = 4;//回歸於預設值

            while (dr.Read())
            {
                if (((CheckBox)PsGV.Rows[num].FindControl("CheckBox2")).Checked)
                {
                    //選取清單的項目
                    item = PsGV.Rows[num].Cells[1].Text;

                    string drItem = dr["ia_iaitem"].ToString();
                    //輸出之前, 檢查該項目是否有被選取
                    if (drItem == item)
                    {
                        Xls.SetCellValue(col, 1, dr["ia_iaitem"].ToString().Trim());    //項次 
                        Xls.SetCellValue(col, 2, dr["ia_refno"].ToString().Trim());     //發票開立單編號
                        Xls.SetCellValue(col, 4, dr["ia_mfrno"].ToString().Trim());     //統一編號
                        Xls.SetCellValue(col, 5, dr["mfr_inm"].ToString().Trim());      //公司名稱
                        Xls.SetCellValue(col, 6, dr["ia_rnm"].ToString().Trim());    //發票收件人姓名
                        Xls.SetCellValue(col, 8, dr["ia_rzip"].ToString().Trim()+"  " + dr["ia_raddr"].ToString().Trim());    //發票郵寄地址                            
                        col++;
                    }
                    num++;
                }

            }


            //下載的檔名
            Common.excuteExcel(Xls, "invoiceSend.xls");


        }

        //發票開立清單回復
        protected void Btn4_Click(object sender, EventArgs e)
        {
            bool chk = false;
            for (int i = 0; i < PsGV.Rows.Count; i++)
            {
                if (((CheckBox)PsGV.Rows[i].Cells[0].FindControl("CheckBox2")).Checked)
                {
                    chk = true;
                }
            }

            if (chk == false)
            {
                JavaScript.AlertMessage(this.Page, string.Format("尚未勾選任何項目"));
                return;
            }

            //對編碼後的參數進行解讀
            syscd = se.decryptquerystring(Request.QueryString["syscd"].ToString());
            date = se.decryptquerystring(Request.QueryString["date"].ToString());
            seq = se.decryptquerystring(Request.QueryString["seq"].ToString());

            //---------------資料庫操作
            SqlCommand oCmd = new SqlCommand();
            oCmd.Connection = new SqlConnection(Conn);
            StringBuilder sb = new StringBuilder();

            //寫入資料庫: 將發票清單所屬發票狀態改回未處理狀態
            sb.Append(@"UPDATE ia SET ia_iasdate = '' ,ia_iasseq = '' ,ia_iaitem = '' ,ia_status = '' WHERE ia.ia_iasdate = @listDate AND ia.ia_iasseq = @listSeq ");

            //資料庫指令
            oCmd.CommandText = sb.ToString();
            //資料庫指令型態
            oCmd.CommandType = CommandType.Text;
            //資料庫連接器
            SqlDataAdapter oda = new SqlDataAdapter(oCmd);

            //SQL參數設定
            oCmd.Parameters.AddWithValue("@listDate", date);
            oCmd.Parameters.AddWithValue("@listSeq", seq);

            //開始資料庫連線
            oCmd.Connection.Open();

            //執行SQL
            oCmd.ExecuteNonQuery();

            //結束資料庫連線
            oCmd.Connection.Close();
            //---------------資料庫操作結束

            //---------------資料庫操作
            SqlCommand oCmd2 = new SqlCommand();
            oCmd2.Connection = new SqlConnection(Conn);
            StringBuilder sb2 = new StringBuilder();

            //寫入資料庫: 將所屬發票清單刪除
            sb2.Append(@"DELETE ias WHERE ias_iasdate = @listDate AND ias_iasseq = @listSeq");

            //資料庫指令
            oCmd2.CommandText = sb2.ToString();
            //資料庫指令型態
            oCmd2.CommandType = CommandType.Text;
            //資料庫連接器
            SqlDataAdapter oda2 = new SqlDataAdapter(oCmd);

            //SQL參數設定
            oCmd2.Parameters.AddWithValue("@listDate", date);
            oCmd2.Parameters.AddWithValue("@listSeq", seq);

            //開始資料庫連線
            oCmd2.Connection.Open();

            //執行SQL
            oCmd2.ExecuteNonQuery();

            //結束資料庫連線
            oCmd2.Connection.Close();
            //---------------資料庫操作結束


            JavaScript.AlertMessageRedirect(this.Page, "發票清單回復成功", "InvoiceListPrintCancle.aspx");
            //畫面搜尋結果資料刷新
            //Response.Redirect("InvoiceListPrintCancle.aspx");

        }

      
    }
}