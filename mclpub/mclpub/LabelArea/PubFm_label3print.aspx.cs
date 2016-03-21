using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace mclpub.LabelArea
{
    public partial class PubFm_label3print : System.Web.UI.Page
    {
        PubFm_label_search_DB myPub = new PubFm_label_search_DB();
        security sec = new security();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 抓出標籤資料
                GetLabelData();
            }
        }


        private string GetBkpNo(string strYYYYMM)
        {
            // 抓出篩選條件
            string strBkcd = sec.decryptquerystring(Request["bkcd"].ToString());
            //string strYYYYMM = Request["yyyymm"].ToString();


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds5 = myPub.SelectBookp();
            DataView dv5 = ds5.Tables["bookp"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr5 = "1=1";
            rowfilterstr5 = rowfilterstr5 + " AND bkp_bkcd='" + strBkcd + "'";
            rowfilterstr5 = rowfilterstr5 + " AND bkp_date='" + strYYYYMM + "'";
            dv5.RowFilter = rowfilterstr5;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
            //Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            if (dv5.Count > 0)
            {
               return dv5[0]["bkp_pno"].ToString().Trim();
            }
            else
            {
                return "";
            }
        }


        // 抓出書籍期別, 好代入標籤及清單中
        private string GetBkpNo()
        {
            // 抓出篩選條件
            string strBkcd = sec.decryptquerystring(Request["bkcd"].ToString());
            string strYYYYMM = sec.decryptquerystring(Request["yyyymm"].ToString());
            string strBkPNo = "";


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds5 = myPub.SelectBookp();
            DataView dv5 = ds5.Tables["bookp"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr5 = "1=1";
            rowfilterstr5 = rowfilterstr5 + " AND bkp_bkcd='" + strBkcd + "'";
            rowfilterstr5 = rowfilterstr5 + " AND bkp_date='" + strYYYYMM + "'";
            dv5.RowFilter = rowfilterstr5;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
            //Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

            // 若搜尋結果為 "找不到" 的處理
            if (dv5.Count > 0)
            {
                strBkPNo = dv5[0]["bkp_pno"].ToString().Trim();
            }
            else
            {
                strBkPNo = strBkPNo;
            }
            return strBkPNo;
            //Response.Write("strBkPNo= " + strBkPNo + "<br>");
        }

        // 抓出標籤資料
        private void GetLabelData()
        {
            // 抓出篩選條件
            string strBkcd = "", strYYYYMM = "", strfgMOSea = "";
            strBkcd = sec.decryptquerystring(Request["bkcd"].ToString());
            strYYYYMM = sec.decryptquerystring(Request["yyyymm"].ToString());
            strfgMOSea = sec.decryptquerystring(Request["fgmosea"].ToString());
            string empno = sec.decryptquerystring(Request["empno"].ToString());
            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件

            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = myPub.SelectC2_cont3print(strBkcd, strfgMOSea, strYYYYMM, empno);
            DataView dv1 = ds1.Tables[0].DefaultView;


            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");



            //20121214修改
            int tableCount = 0;//算出要產生幾個TABLE
            int i = 0;//
            int judge = 0;
            bool recordTr = true;//用來判斷TR的新增(開關)
            bool judge12 = false;//因為只要是第12筆都會有問題 會導致無窮跳出 所以要加個判斷
            if (dv1.Count > 0)
            {
                if (dv1.Count % 12 != 0)
                {
                    tableCount = dv1.Count / 12 + 1;
                }
                else
                {
                    tableCount = dv1.Count / 12;
                }
            }
            //Response.Write(tableCount);
            HtmlGenericControl tr = null;

            for (i = 0; i < tableCount; i++)
            {
                #region 空白
                HtmlGenericControl BRspanFront1 = new HtmlGenericControl("br");
                Panel1.Controls.Add(BRspanFront1);
                HtmlGenericControl BRspanFront2 = new HtmlGenericControl("br");
                Panel1.Controls.Add(BRspanFront2);
                HtmlGenericControl BRspanFront3 = new HtmlGenericControl("br");
                Panel1.Controls.Add(BRspanFront3);
                HtmlGenericControl BRspanFront4 = new HtmlGenericControl("br");
                Panel1.Controls.Add(BRspanFront4);
                #endregion



                HtmlGenericControl table = new HtmlGenericControl("table");
                table.Attributes.Add("cellpadding", "0");
                table.Attributes.Add("cellspacing", "0");
                table.Attributes.Add("style", "border-collapse: collapse;page-break-after:always;");
                table.Attributes.Add("width", "100%");

                for (int j = judge; j < dv1.Count; j++)
                {

                    if (j % 12 == 0 && j != 0 && judge12 == false)//如果超過12筆 就跳出迴圈 新增另一個TABLE
                    {
                        judge12 = true;
                        break;
                    }
                    else
                    {
                        if (recordTr == true)
                        {
                            tr = new HtmlGenericControl("tr");
                            table.Controls.Add(tr);
                            tr.Controls.Add(TdInside(dv1, judge));

                            recordTr = false;

                        }
                        else
                        {
                            tr.Controls.Add(TdInside(dv1, judge));

                            recordTr = true;
                        }
                        judge++;
                        judge12 = false;
                    }

                }


                Panel1.Controls.Add(table);
            }




            // 若搜尋結果為 "找不到" 的處理
            //if (dv1.Count > 0)
            //{
            //    if (strfgMOSea == "0")
            //    {
            //        DataList1.DataSource = dv1;
            //        DataList1.DataBind();


            //        //for (int i = 0; i < DataList1.Items.Count; i++)
            //        //{
            //        //    // 書籍期別
            //        //    ((Label)DataList1.Items[i].FindControl("lblBkpNo1")).Text = GetBkpNo(dv1[i]["pub_yyyymm"].ToString());
            //        //}
            //    }
            //    else
            //    {
            //        DataList2.DataSource = dv1;
            //        DataList2.DataBind();


            //        //for (int j = 0; j < DataList2.Items.Count; j++)
            //        //{
            //        //    // 書籍期別
            //        //    ((Label)DataList2.Items[j].FindControl("lblBkpNo2")).Text = GetBkpNo(dv1[j]["pub_yyyymm"].ToString());
            //        //}
            //    }
            //    // 結束 if (dv1.Count > 0)
            //}
        }


        private HtmlGenericControl TdInside(DataView dv1, int judge)
        {
            HtmlGenericControl td = new HtmlGenericControl("td");
            td.Attributes.Add("width", "53%");

            string strfgMOSea = sec.decryptquerystring(Request["fgmosea"].ToString());

            if (strfgMOSea == "0")
            {
                HtmlGenericControl table = new HtmlGenericControl("table");
                table.Attributes.Add("cellpadding", "0");
                table.Attributes.Add("cellspacing", "0");
                table.Attributes.Add("style", "border-collapse: collapse;");

                #region 郵遞區號跟地址
                HtmlGenericControl tr = new HtmlGenericControl("tr");
                HtmlGenericControl td1 = new HtmlGenericControl("td");
                td1.InnerHtml = dv1[judge]["or_zip"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;";
                td1.Attributes.Add("style", "font-size: 14pt; font-weight: bold;");
                tr.Controls.Add(td1);
                HtmlGenericControl td2 = new HtmlGenericControl("td");
                td2.InnerHtml = dv1[judge]["or_addr"].ToString();
                if (dv1[judge]["or_addr"].ToString().Trim().Length > 23)
                {
                    td2.Attributes.Add("style", "font-size: 9.5pt; font-weight: bold;");
                }
                else
                {
                    td2.Attributes.Add("style", "font-size: 10pt; font-weight: bold;");
                }
                tr.Controls.Add(td2);
                table.Controls.Add(tr);
                td.Controls.Add(table);
                #endregion

                #region 公司名稱跟收件人+職稱
                HtmlGenericControl spaninm = new HtmlGenericControl("span");
                HtmlGenericControl spannm = new HtmlGenericControl("span");
                HtmlGenericControl spanjbti = new HtmlGenericControl("span");

                spaninm.Attributes.Add("style", "font-size: 10pt;");
                spannm.Attributes.Add("style", "font-size: 10pt;");
                spanjbti.Attributes.Add("style", "font-size: 10pt;");

                spaninm.InnerHtml = dv1[judge]["or_inm"].ToString() + "<br />";
                spannm.InnerHtml = dv1[judge]["or_nm"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;";
                spanjbti.InnerHtml = dv1[judge]["or_jbti"].ToString() + "<br />";

                td.Controls.Add(spaninm);
                td.Controls.Add(spannm);
                td.Controls.Add(spanjbti);
                #endregion

                #region 合約起訖
                HtmlGenericControl spandate = new HtmlGenericControl("span");
                spandate.Attributes.Add("style", "font-size: 10pt;");
                spandate.InnerHtml = "合約起訖：&nbsp;&nbsp;" + dv1[judge]["cont_sedate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;未登本數：" + dv1[judge]["or_unpubcnt"].ToString() + "<br />";
                td.Controls.Add(spandate);
                #endregion

                #region 合約編號
                HtmlGenericControl spansyscd = new HtmlGenericControl("span");
                spansyscd.Attributes.Add("style", "font-size: 10pt;");
                spansyscd.InnerHtml = "合約編號：&nbsp;&nbsp;" + dv1[judge]["cont_contno"].ToString() + "&nbsp;&nbsp;(" + dv1[judge]["cont_conttpName"].ToString() + ")&nbsp;&nbsp;&nbsp;&nbsp;" + dv1[judge]["mtp_nm"].ToString() + "<br />";
                td.Controls.Add(spansyscd);
                #endregion

                #region 工材(電材等)訂購期別
                HtmlGenericControl spanobtpnm = new HtmlGenericControl("span");
                spanobtpnm.Attributes.Add("style", "font-size: 10pt;");
                spanobtpnm.InnerHtml = dv1[judge]["bk_nm"].ToString() + "&nbsp;" + GetBkpNo() + "期 <br />";
                td.Controls.Add(spanobtpnm);
                #endregion

                #region 序號
                HtmlGenericControl ItemIndex = new HtmlGenericControl("span");
                ItemIndex.Attributes.Add("style", "font-size: 6pt;");
                ItemIndex.InnerHtml = judge.ToString();
                td.Controls.Add(ItemIndex);
                #endregion

                #region 空白
                HtmlGenericControl BRspan = new HtmlGenericControl("br");
                td.Controls.Add(BRspan);
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.TagName = "div";
                div.Style.Add("height", "13pt");
                td.Controls.Add(div);
                #endregion
            }
            else
            {
                HtmlGenericControl table = new HtmlGenericControl("table");
                table.Attributes.Add("cellpadding", "0");
                table.Attributes.Add("cellspacing", "0");
                table.Attributes.Add("style", "border-collapse: collapse;");

                #region 公司名稱跟收件人+職稱
                HtmlGenericControl spaninm = new HtmlGenericControl("span");
                HtmlGenericControl spannm = new HtmlGenericControl("span");
                HtmlGenericControl spanjbti = new HtmlGenericControl("span");

                spaninm.Attributes.Add("style", "font-size: 10pt;");
                spannm.Attributes.Add("style", "font-size: 10pt;");
                spanjbti.Attributes.Add("style", "font-size: 10pt;");

                spaninm.InnerHtml = dv1[judge]["or_inm"].ToString() + "<br />";
                spannm.InnerHtml = dv1[judge]["or_nm"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;";
                spanjbti.InnerHtml = dv1[judge]["or_jbti"].ToString() + "<br />";

                td.Controls.Add(spannm);
                td.Controls.Add(spanjbti);
                td.Controls.Add(spaninm);
                #endregion

                #region 郵遞區號跟地址
                HtmlGenericControl tr = new HtmlGenericControl("tr");
                //HtmlGenericControl td1 = new HtmlGenericControl("td");
                //td1.InnerHtml = dv1[judge]["or_zip"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;";
                //td1.Attributes.Add("style", "font-size: 14pt; font-weight: bold;");
                //tr.Controls.Add(td1);
                HtmlGenericControl td2 = new HtmlGenericControl("td");
                td2.InnerHtml = dv1[judge]["or_addr"].ToString();
                if (dv1[judge]["or_addr"].ToString().Trim().Length > 23)
                {
                    td2.Attributes.Add("style", "font-size: 9.5pt; font-weight: bold;");
                }
                else
                {
                    td2.Attributes.Add("style", "font-size: 10pt; font-weight: bold;");
                }
                tr.Controls.Add(td2);
                table.Controls.Add(tr);
                td.Controls.Add(table);
                #endregion

                #region 合約起訖
                HtmlGenericControl spandate = new HtmlGenericControl("span");
                spandate.Attributes.Add("style", "font-size: 10pt;");
                spandate.InnerHtml = "合約起訖：&nbsp;&nbsp;" + dv1[judge]["cont_sedate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;未登本數：" + dv1[judge]["or_unpubcnt"].ToString() + "<br />";
                td.Controls.Add(spandate);
                #endregion

                #region 合約編號
                HtmlGenericControl spansyscd = new HtmlGenericControl("span");
                spansyscd.Attributes.Add("style", "font-size: 10pt;");
                spansyscd.InnerHtml = "合約編號：&nbsp;&nbsp;" + dv1[judge]["cont_contno"].ToString() + "&nbsp;&nbsp;(" + dv1[judge]["cont_conttpName"].ToString() + ")&nbsp;&nbsp;&nbsp;&nbsp;" + dv1[judge]["mtp_nm"].ToString() + "<br />";
                td.Controls.Add(spansyscd);
                #endregion

                #region 工材(電材等)訂購期別
                HtmlGenericControl spanobtpnm = new HtmlGenericControl("span");
                spanobtpnm.Attributes.Add("style", "font-size: 10pt;");
                spanobtpnm.InnerHtml = dv1[judge]["bk_nm"].ToString() + "&nbsp;" + GetBkpNo() + "期 <br />";
                td.Controls.Add(spanobtpnm);
                #endregion

                #region 序號
                HtmlGenericControl ItemIndex = new HtmlGenericControl("span");
                ItemIndex.Attributes.Add("style", "font-size: 6pt;");
                ItemIndex.InnerHtml = judge.ToString();
                td.Controls.Add(ItemIndex);
                #endregion

                #region 空白
                HtmlGenericControl BRspan = new HtmlGenericControl("br");
                td.Controls.Add(BRspan);
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.TagName = "div";
                div.Style.Add("height", "13pt");
                td.Controls.Add(div);
                #endregion
            }
            return td;
        }
    }
}