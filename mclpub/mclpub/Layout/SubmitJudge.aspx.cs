using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class SubmitJudge : System.Web.UI.Page
    {
        SubmitJudge_DB mySubmit = new SubmitJudge_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string CurrentBookCode = Request.Form["BookCodeURL"];
                string CurrentPriorSeq = Request.Form["PriorSeqURL"];
                string CurrentLayoutTypeCode = Request.Form["LayoutTypeCodeURL"];
                string CurrentColorCode = Request.Form["ColorCodeURL"];
                string CurrentPageSizeCode = Request.Form["PageSizeCodeURL"];

                //Response.Write(CurrentBookCode + "," + CurrentPriorSeq + "," + CurrentLayoutTypeCode + "," + CurrentColorCode + "," + CurrentPageSizeCode);
                DataSet ds1 = mySubmit.Selectc2_lprior(CurrentBookCode, CurrentLayoutTypeCode, CurrentColorCode, CurrentPageSizeCode);
                DataView dv1;
                dv1 = ds1.Tables[0].DefaultView;
                //Response.Write("No!");
                //return;
                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 注意: 因為 lp_priorseq 是 自己填入之資料, 故不可填入 Row.Filter, 若填入將因找不到此筆資料, 而變成新增
                //       故要就除了 lp_priorseq 外, 其餘四項去比對資料庫裡是否資料有重覆!
                //Response.Write(dv1.Count);
                //return;

                // 若找到此筆資料, 則載入資料
                if (dv1.Count > 0)
                {
                    Response.Write("No!");
                    return;
                }
                else
                {
                    // 抓出 指定位置之排版優先次序, 並先執行更新動作 (先將之後筆數之次序值更新)
                    GetNewlpSeq();

                    // 指定新的 LPSeq (NewPriorSeq=CurrentPriorSeq)
                    string NewPriorSeq = CurrentPriorSeq;
                    if (NewPriorSeq.Length < 2)
                        NewPriorSeq = "0" + NewPriorSeq;
                    //Response.Write("NewPriorSeq=" + NewPriorSeq + "<br>");

                    // 執行 新增動作
                    mySubmit.Insertc2_lprior(CurrentBookCode, NewPriorSeq, CurrentLayoutTypeCode, CurrentColorCode, CurrentPageSizeCode);

                    Response.Write("Ok!");
                }
            }
            catch 
            {
                Response.Write("Error!");
            }
        }


        // 抓出 指定位置之排版優先次序, 並先執行更新動作 (先將之後筆數之次序值更新)
        private void GetNewlpSeq()
        {
            // 抓出 指定位置之排版優先次序 值
            string CurrentBookCode = Request.Form["BookCodeURL"];
            string CurrentPriorSeq = Request.Form["PriorSeqURL"];
            int intCurrentPriorSeq = Convert.ToInt16(CurrentPriorSeq);
            //Response.Write("CurrentBookCode= " + CurrentBookCode + "<br>");
            //Response.Write("CurrentPriorSeq= " + CurrentPriorSeq + "<br>");
            //Response.Write("intCurrentPriorSeq= " + intCurrentPriorSeq + "<br>");

            // 抓出目前最大值 MaxLPSeq, 好方便抓出之後筆數之逐行資料
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds6 = mySubmit.SelectMaxc2_lprior(CurrentBookCode);
            // 給 sqlDataAdapter1 過濾條件 - 指定 Parameters
            DataView dv6 = ds6.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr6 = "1=1";
            dv6.RowFilter = rowfilterstr6;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
            //Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            string MaxLPSeq = "01";
            int intMaxLPSeq = Convert.ToInt16(MaxLPSeq);
            if (dv6.Count > 0)
            {
                MaxLPSeq = dv6[0]["MaxSeq"].ToString();
                intMaxLPSeq = Convert.ToInt16(MaxLPSeq);
                //Response.Write("intMaxLPSeq= " + intMaxLPSeq + "<br>");

                for (int i = intMaxLPSeq; i >= intCurrentPriorSeq; i--)
                {
                    //Response.Write("i= " + i + ", ");
                    string stri = Convert.ToString(i);
                    if (stri.Length < 2)
                        stri = "0" + stri;
                    //Response.Write("stri= " + stri + "<br>");

                    // 使用 DataSet 方法, 並指定使用的 table 名稱
                    DataSet ds7 = mySubmit.SelectNextc2_lprior();
                    DataView dv7 = ds7.Tables[0].DefaultView;

                    // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                    // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                    string rowfilterstr7 = "1=1";
                    rowfilterstr7 = rowfilterstr7 + " AND lp_bkcd=" + CurrentBookCode;
                    rowfilterstr7 = rowfilterstr7 + " AND lp_priorseq=" + stri;
                    dv7.RowFilter = rowfilterstr7;

                    // 檢查並輸出 最後 Row Filter 的結果
                    //Response.Write("dv7.Count= "+ dv7.Count + "<BR>");
                    //Response.Write("dv7.RowFilter= " + dv7.RowFilter + "<BR>");

                    if (dv7.Count > 0)
                    {
                        // 抓出 之後筆數之相關值 - 書籍代碼, 廣告版面代碼, 廣告色彩代碼, 廣告篇幅代碼
                        string iBookCode = dv7[0]["lp_bkcd"].ToString();
                        string iLayoutTypeCode = dv7[0]["lp_ltpcd"].ToString();
                        string iColorCode = dv7[0]["lp_clrcd"].ToString();
                        string iPageSizeCode = dv7[0]["lp_pgscd"].ToString();
                        //Response.Write("iBookCode= " + iBookCode + ", ");
                        //Response.Write("iLPSeq= " + stri + ", ");
                        //Response.Write("iLayoutTypeCode= " + iLayoutTypeCode + ", ");
                        //Response.Write("iColorCode= " + iColorCode + ", ");
                        //Response.Write("iPageSizeCode= " + iPageSizeCode + "<br>");

                        int intNewLPSeq = i + 1;
                        string strNewLPSeq = Convert.ToString(intNewLPSeq);
                        if (strNewLPSeq.Length < 2)
                            strNewLPSeq = "0" + strNewLPSeq;
                        //Response.Write("strNewLPSeq= " + strNewLPSeq + "<br><br>");

                        // 執行更新動作
                        mySubmit.Updatec2_lprior(iBookCode,CurrentPriorSeq,iLayoutTypeCode,iColorCode,iPageSizeCode);
                    }
                }
            }
            else
            {
                MaxLPSeq = MaxLPSeq;
            }
            //Response.Write("MaxLPSeq= " + MaxLPSeq + "<br>");

        }
    }
}