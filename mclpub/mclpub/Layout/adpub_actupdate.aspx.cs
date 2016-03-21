using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class adpub_actupdate : System.Web.UI.Page
    {
        adpub_actupdate_DB myadpub = new adpub_actupdate_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid1();
            }
        }

        // 產生 DataGrid1
        private void BindGrid1()
        {
            //抓出網頁變數
            string Qstrbkcd = Context.Request.QueryString["bkcd"].ToString().Trim();
            string Qstryyyymm = Context.Request.QueryString["yyyymm"].ToString().Trim();

            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = myadpub.Selectc2_pub();
            //this.sqlDataAdapter1.Fill(ds1, "c2_pub");
            DataView dv1 = ds1.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
            string rowfilterstr = "1=1";
            if (Qstrbkcd != "")
                rowfilterstr = rowfilterstr + " and (書籍類別代碼 = '" + Qstrbkcd + "')";
            else
                rowfilterstr = rowfilterstr;
            if (Qstryyyymm != "")
                rowfilterstr = rowfilterstr + " and (刊登年月 LIKE '%" + Qstryyyymm + "%')";
            else
                rowfilterstr = rowfilterstr;
            dv1.RowFilter = rowfilterstr;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

            // 若搜尋結果為 "找到" 的處理
            if (dv1.Count > 0)
            {
                DataGrid1.Visible = true;

                DataGrid1.DataSource = dv1;
                DataGrid1.DataBind();


                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                int i;
                for (i = 0; i < DataGrid1.Items.Count; i++)
                {
                    // 刊登年月
                    string yyyymm = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
                    yyyymm = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
                    DataGrid1.Items[i].Cells[2].Text = yyyymm;


                    // 固定頁次註記
                    string fgFixPg = DataGrid1.Items[i].Cells[8].Text.ToString().Trim();
                    if (fgFixPg == "1")
                        DataGrid1.Items[i].Cells[8].Text = "<font color=Red>是</font>";
                    else
                        DataGrid1.Items[i].Cells[8].Text = "否";


                    // 稿件類別代碼
                    string drafttp = DataGrid1.Items[i].Cells[22].Text.ToString().Trim();
                    //Response.Write("drafttp= " + drafttp + "<br>");
                    switch (drafttp)
                    {
                        // 舊稿相關欄位
                        case "1":
                            string Origbkcd = DataGrid1.Items[i].Cells[17].Text.ToString().Trim();
                            string Origjno = DataGrid1.Items[i].Cells[18].Text.ToString().Trim();
                            string Origjbkno = DataGrid1.Items[i].Cells[19].Text.ToString().Trim();

                            // 清除其他類別資料
                            DataGrid1.Items[i].Cells[10].Text = "";
                            DataGrid1.Items[i].Cells[11].Text = "";
                            //DataGrid1.Items[i].Cells[12].Enabled = false;
                            DataGrid1.Items[i].Cells[13].Text = "";
                            DataGrid1.Items[i].Cells[14].Text = "";
                            //DataGrid1.Items[i].Cells[15].Text = "";
                            //DataGrid1.Items[i].Cells[16].Text = "";
                            // 清除 已做樣後修改之值 0
                            DataGrid1.Items[i].Cells[26].Text = "";
                            break;

                        // 新稿相關欄位
                        case "2":
                            // 到稿註記
                            string fggot1 = DataGrid1.Items[i].Cells[10].Text.ToString().Trim();
                            if (fggot1 == "0")
                                fggot1 = "否";
                            else
                                fggot1 = "是";
                            DataGrid1.Items[i].Cells[10].Text = fggot1;

                            // 清除其他類別資料
                            DataGrid1.Items[i].Cells[13].Text = "";
                            DataGrid1.Items[i].Cells[14].Text = "";
                           // DataGrid1.Items[i].Cells[15].Text = "";
                            //DataGrid1.Items[i].Cells[16].Text = "";
                            DataGrid1.Items[i].Cells[17].Text = "";
                            DataGrid1.Items[i].Cells[18].Text = "";
                            DataGrid1.Items[i].Cells[19].Text = "";
                            break;

                        // 改稿相關欄位
                        case "3":
                            // 到稿註記
                            string fggot2 = DataGrid1.Items[i].Cells[10].Text.ToString().Trim();
                            if (fggot2 == "0")
                                fggot2 = "否";
                            else
                                fggot2 = "是";
                            DataGrid1.Items[i].Cells[10].Text = fggot2;

                            // 改稿書籍類別
                            string chgbkName;
                            string chgbkcd = DataGrid1.Items[i].Cells[13].Text.ToString().Trim();
                            if (chgbkcd == "01")
                                DataGrid1.Items[i].Cells[13].Text = "工材雜誌";
                            else if (chgbkcd == "02")
                                DataGrid1.Items[i].Cells[13].Text = "電材雜誌";
                            else
                                DataGrid1.Items[i].Cells[13].Text = "（資料有誤)";

                            // 改稿重出片註記
                            string fgReChg = DataGrid1.Items[i].Cells[24].Text;
                            //Response.Write("fgReChg= " + fgReChg + "<br>");
                            if (fgReChg == "1")
                                ((CheckBox)DataGrid1.Items[i].FindControl("cbxfgReChg")).Checked = true;
                            else if (fgReChg == "0")
                                ((CheckBox)DataGrid1.Items[i].FindControl("cbxfgReChg")).Checked = false;
                            else
                                ((CheckBox)DataGrid1.Items[i].FindControl("cbxfgReChg")).Checked = false;

                            //// 清除其他類別資料
                            DataGrid1.Items[i].Cells[11].Text = "";
                            //DataGrid1.Items[i].Cells[12].Text = "";
                            DataGrid1.Items[i].Cells[17].Text = "";
                            DataGrid1.Items[i].Cells[18].Text = "";
                            DataGrid1.Items[i].Cells[19].Text = "";
                            break;

                        default:
                            // 清除其他類別資料
                            DataGrid1.Items[i].Cells[10].Text = "";
                            DataGrid1.Items[i].Cells[11].Text = "";
                            //DataGrid1.Items[i].Cells[12].Text = "";
                            DataGrid1.Items[i].Cells[13].Text = "";
                            DataGrid1.Items[i].Cells[14].Text = "";
                            //DataGrid1.Items[i].Cells[15].Text = "";
                            //DataGrid1.Items[i].Cells[16].Text = "";
                            break;
                    }


                    // 結束 for(i=0; i< DataGrid1.Items.Count ; i++)
                }
            }
            else
            {
                DataGrid1.Visible = false;
            }
        }

        // for 新稿製法
        protected object GetVisiblity1(object drafttp)
        {
            //Response.Write("drafttp= " + drafttp.ToString() + "<br>");
            bool valReturn = false;
            if (drafttp.ToString() == "2")
            {
                valReturn = true;
            }
            return valReturn;
        }

        // 檢查 新稿類別代碼 是否輸入合理
        protected object CheckNjtpcd(object njtpcd)
        {
            //Response.Write("njtpcd= " + njtpcd.ToString() + "<br>");
            bool valReturn = false;

            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds2 = myadpub.Selectc2_njtp();
            DataView dv2 = ds2.Tables[0].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
            string rowfilterstr2 = "1=1";
            rowfilterstr2 = rowfilterstr2 + " AND njtp_njtpcd = '" + njtpcd + "'";
            dv2.RowFilter = rowfilterstr2;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
            //Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

            // 若搜尋結果為 "找到" 的處理
            if (dv2.Count > 0)
            {
                valReturn = true;
            }
            else
            {
                // 以 Javascript 的 window.alert()  來告知訊息
                JavaScript.AlertMessage(this.Page, "剛輸入的新稿製法代碼" + njtpcd + "不存在(不合理), 請修正!!!");
            }
            return valReturn;
        }


        // for 舊稿期別
        protected object GetVisiblity2(object drafttp)
        {
            //Response.Write("drafttp= " + drafttp.ToString() + "<br>");
            bool valReturn = false;
            if (drafttp.ToString() == "3")
            {
                valReturn = true;
            }
            return valReturn;
        }


        // for 改稿重出片
        protected object GetfgReChg(object fgrechg)
        {
            bool strReturn = false;
            if (fgrechg.ToString().Trim() == "1")
                strReturn = true;
            return strReturn;
        }


        // for 美編樣後修改註記
        protected object GetfgUpdated(object drafttp)
        {
            //Response.Write("drafttp= " + drafttp.ToString() + "<br>");
            bool valReturn = false;
            if (drafttp.ToString() == "2")
            {
                valReturn = true;
            }
            if (drafttp.ToString() == "3")
            {
                valReturn = true;
            }
            return valReturn;
        }


        protected object CheckfgUpdated(object fgupdated)
        {
            fgupdated = fgupdated.ToString().Trim();
            //Response.Write("fgupdated= " + fgupdated.ToString() + "<br>");
            bool valReturn = false;

            if (fgupdated == "0" || fgupdated == "1" || fgupdated == "2" || fgupdated == "3" || fgupdated == "4" || fgupdated == "5" || fgupdated == "6" || fgupdated == "7" || fgupdated == "8" || fgupdated == "9")
            {
                valReturn = true;
            }
            else
            {
                JavaScript.AlertMessage(this.Page, "剛輸入的美編樣後修正" + fgupdated + "必須輸入數字型態(0~9), 請修正!!!");
                // 以 Javascript 的 window.alert()  來告知訊息
            }
            return valReturn;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Response.Write("DataGrid1.Items.Count= " + DataGrid1.Items.CountDataGrid1.Items.Count + "<br>");
            // 抓出各行 美編樣後修改註記 之值
            for (int i = 0; i < DataGrid1.Items.Count; i++)
            {
                // 抓出 c2_pub 欲更新欄位值及 PK
                string iSyscd = "C2";
                string iContNo = DataGrid1.Items[i].Cells[1].Text.ToString().Trim();
                string iYYYYMM = DataGrid1.Items[i].Cells[2].Text.ToString().Trim();
                iYYYYMM = iYYYYMM.Substring(0, 4) + iYYYYMM.Substring(5, 2);
                string iPubSeq = DataGrid1.Items[i].Cells[3].Text.ToString().Trim();
                string iDrafttp = DataGrid1.Items[i].Cells[22].Text.ToString().Trim();
                string injtpcd = ((TextBox)DataGrid1.Items[i].FindControl("tbxNjtpcd")).Text;
                string chgjbkno = ((TextBox)DataGrid1.Items[i].FindControl("tbxChgJBkNo")).Text;
                bool fgrechg = ((CheckBox)DataGrid1.Items[i].FindControl("cbxfgReChg")).Checked;
                string ifgrechg;
                if (fgrechg == true)
                    ifgrechg = "1";
                else
                    ifgrechg = "0";
                string ifgupdated = ((TextBox)DataGrid1.Items[i].FindControl("tbxfgupdated")).Text;
                //Response.Write("isyscd= " + iSyscd + "," );
                //Response.Write("iContNo=" + iContNo + "," );
                //Response.Write("iYYYYMM=" + iYYYYMM + "," );
                //Response.Write("iPubSeq=" + iPubSeq + ", " );
                //Response.Write("iDrafttp=" + iDrafttp + ", ");
                //Response.Write("injtpcd=" + injtpcd + ", ");
                //Response.Write("chgjbkno=" + chgjbkno + ", ");
                //Response.Write("fgrechg=" + fgrechg + ", ");
                //Response.Write("ifgrechg=" + ifgrechg + ", ");
                //Response.Write("ifgupdated=" + ifgupdated + "<br>");


                // 若為新稿或改稿, 則執行 更新; 否則不做任何處理
                if (iDrafttp == "2" || iDrafttp == "3")
                {
                    // 檢查 美編樣後修正 是否為數字型態且介於 0~9 間
                    if (ifgupdated == "0" || ifgupdated == "1" || ifgupdated == "2" || ifgupdated == "3" || ifgupdated == "4" || ifgupdated == "5" || ifgupdated == "6" || ifgupdated == "7" || ifgupdated == "8" || ifgupdated == "9")
                    {
                        // 新稿
                        if (iDrafttp == "2")
                        {
                            chgjbkno = "0";
                            ifgrechg = " ";
                            injtpcd = injtpcd;

                            // 檢查 新稿製法是否合理
                            if (injtpcd.Trim() != "")
                            {
                                // 使用 DataSet 方法, 並指定使用的 table 名稱
                                DataSet ds2 = myadpub.Selectc2_njtp();
                                DataView dv2 = ds2.Tables[0].DefaultView;

                                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                                // 設 Row Filter: default 抓 cust_mfrno and 其他 rowfilter 條件
                                string rowfilterstr2 = "1=1";
                                rowfilterstr2 = rowfilterstr2 + " AND njtp_njtpcd = '" + injtpcd + "'";
                                dv2.RowFilter = rowfilterstr2;

                                // 檢查並輸出 最後 Row Filter 的結果
                                //Response.Write("dv2.Count= "+ dv2.Count + "<BR>");
                                //Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");

                                // 若搜尋結果為 "找到" 的處理
                                if (dv2.Count > 0)
                                {
                                    chgjbkno = "0";
                                    ifgrechg = " ";
                                    injtpcd = injtpcd;

                                    myadpub.Updatec2_pub(injtpcd, Convert.ToInt32(chgjbkno), ifgrechg, ifgupdated, iSyscd, iContNo, iYYYYMM, iPubSeq);
                                }
                                else
                                {
                                    // 以 Javascript 的 window.alert()  來告知訊息
                                    JavaScript.AlertMessage(this.Page, "合約編號-刊登年月-落版序號：" + iContNo + "-" + iYYYYMM + "-" + iPubSeq + " 的新稿製法代碼 " + injtpcd + " 不合理!\\n請修正(數字0~9), 否則該筆資料無法儲存!");
                                }
                            }
                        }


                        // 改稿
                        if (iDrafttp == "3")
                        {
                            chgjbkno = chgjbkno;
                            ifgrechg = ifgrechg;
                            injtpcd = "  ";
                            myadpub.Updatec2_pub(injtpcd, Convert.ToInt32(chgjbkno), ifgrechg, ifgupdated, iSyscd, iContNo, iYYYYMM, iPubSeq);
                        }
                    }
                    // 檢查 美編樣後修正 是否為數字型態且介於 0~9 間 => 否, 給予警告
                    else
                    {
                        // 以 Javascript 的 window.alert()  來告知訊息
                        JavaScript.AlertMessage(this.Page, "合約編號-刊登年月-落版序號：" + iContNo + "-" + iYYYYMM + "-" + iPubSeq + " 的美編樣後修正 " + ifgupdated + " 不合理!\\n請修正, 否則該筆資料無法儲存!");
                    }
                    // 結束 if(iDrafttp == "2" || iDrafttp == "3")
                }
                // 結束 for loop
            }


            // Refresh DataGrid1
            JavaScript.AlertMessage(this.Page, "即將更新頁面資料!");
            BindGrid1();
        }
    }
}