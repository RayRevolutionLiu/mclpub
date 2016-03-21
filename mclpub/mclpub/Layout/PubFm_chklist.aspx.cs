using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Layout
{
    public partial class PubFm_chklist : System.Web.UI.Page
    {
        PubFm_chklist_DB myPub = new PubFm_chklist_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchIcon.Visible = false;
                lbNoCount.Visible = false;
                InitialData();
            }
        }

        // 預設值
        private void InitialData()
        {
            // 查詢資料區
            //-----------------------


            // 刊登年月區間
            this.tbxDate1.Text = System.DateTime.Today.ToString("yyyy/MM");
            this.tbxDate2.Text = System.DateTime.Today.ToString("yyyy/MM");


            // 合約編號及廠商名稱
            this.tbxContNo.Text = "";
            this.tbxMfrIName.Text = "";


            // 清除 DataList
            this.DataList1.Visible = false;
        }

        private DataSet BindList()
        {
            string STRtbxDate1 = "";
            string STRtbxDate2 = "";
            string STRtbxContNo = "";
            string STRtbxMfrIName = "";

            if (tbxDate1.Text.Trim() != "" && tbxDate2.Text.Trim() != "")
            {
                STRtbxDate1 = tbxDate1.Text.Trim();
                STRtbxDate2 = tbxDate2.Text.Trim();
            }

            if (tbxContNo.Text.Trim() != "")
            {
                STRtbxContNo = tbxContNo.Text.Trim();
            }

            if (tbxMfrIName.Text.Trim() != "")
            {
                STRtbxMfrIName = tbxMfrIName.Text.Trim();
            }

            DataSet ds = myPub.Selectc2_pub(STRtbxDate1, STRtbxDate2, STRtbxContNo, STRtbxMfrIName);

            return ds;
        }

        protected void ReturnDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Deafult.aspx");
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            DataSet ds = BindList();
            SearchIcon.Visible = true;
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                this.DataList1.Visible = true;


                // Part I - 抓出符合條件的合約書編號及其資料
                DataList1.DataSource = ds;
                DataList1.DataBind();

                // 告知查詢結果
                lbNoCount.Visible = true;
                this.lbNoCount.Text = "查詢結果：共有 " + ds.Tables[0].Rows.Count + " 筆資料!";

                GetDetails();
            }
            else
            {
                this.DataList1.Visible = false;
                lbNoCount.Visible = true;
                this.lbNoCount.Text = "查詢無結果";
            }
        }


        // 抓出 DataList1 的細節資訊
        private void GetDetails()
        {
            // 抓出篩選條件
            string date1, date2;
            date1 = tbxDate1.Text.Trim() == "" ? "" : tbxDate1.Text.Substring(0, 4) + tbxDate1.Text.Substring(5, 2);
            date2 = tbxDate2.Text.Trim() == "" ? "" : tbxDate2.Text.Substring(0, 4) + tbxDate2.Text.Substring(5, 2);


            // 抓出 DataGrid1 (IM) 資料
            //Response.Write("DataList1.Items.Count= " + DataList1.Items.Count + "<br>");
            //Response.Write("DataList1.Controls.Count= " + DataList1.Controls.Count + "<br>");
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                //// 測試是否可抓到顯示各行之 Controls (如 lblContNo, DataList2, DataGrid1...)
                //for (int j = 0; j < DataList1.Items[i].Controls.Count; j++)
                //{
                //    string ID = DataList1.Items[i].Controls[j].ID;
                //    Response.Write("ID= " + ID + "<br>");
                //}


                // Part II - 抓出 發票廠商收件人 IM (DataGrid1) 的資料
                // 抓出 合約書編號, 以篩選 IM 資料
                string strContNo = ((Label)DataList1.Items[i].FindControl("lblContNo")).Text;
                //Response.Write("strContNo= " + strContNo + "<br>");
                //return;

                // 抓出 發票廠商收件人 DataGrid1
                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds2 = myPub.SelectInvmfr();
                DataView dv2 = ds2.Tables[0].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                string rowfilterstr2 = "1=1";
                rowfilterstr2 = rowfilterstr2 + " AND (im_contno='" + strContNo + "')";
                dv2.RowFilter = rowfilterstr2;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv2.Count= " + dv2.Count + "<BR>");
                //return;
                //Response.Write("dv2.RowFilter= " + dv2.RowFilter + "<BR>");
                
                // 若有資料, 則顯示相關資料; 否則給予錯誤訊息
                if (dv2.Count > 0)
                {
                    ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).DataSource = dv2;
                    ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).DataBind();


                    // 特別欄位之輸出格式轉換 - 變更發票類別等的格式
                    //Response.Write("DataGrid1.Count= " + ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items.Count + "<br>");
                    for (int j = 0; j < ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items.Count; j++)
                    {
                        // 發票類別
                        string invcd = ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[10].Text.ToString().Trim();
                        //Response.Write("invcd = " + invcd + "<br>");
                        switch (invcd)
                        {
                            case "2":
                                ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[10].Text = "二聯";
                                break;
                            case "3":
                                ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[10].Text = "三聯";
                                break;
                            case "4":
                                ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[10].Text = "其他";
                                break;
                            default:
                                ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[10].Text = "三聯";
                                break;
                        }

                        // 發票課稅別
                        string taxtp = ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[11].Text.ToString().Trim();
                        //Response.Write("taxtp = " + taxtp + "<br>");
                        switch (taxtp)
                        {
                            case "1":
                                ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[11].Text = "應稅5%";
                                break;
                            case "2":
                                ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[11].Text = "零稅";
                                break;
                            case "3":
                                ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[11].Text = "免稅";
                                break;
                            default:
                                ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[11].Text = "應稅5%";
                                break;
                        }

                        // 院所內註記
                        string fgitri = ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[12].Text.ToString().Trim();
                        //Response.Write("fgitri = " + fgitri + "<br>");
                        if (fgitri == "")
                            ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[12].Text = "否";
                        else
                        {
                            if (fgitri == "06")
                                ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[12].Text = "<font color='Red'>所內</font>";
                            if (fgitri == "07")
                                ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items[j].Cells[12].Text = "<font color='Red'>院內</font>";
                        }
                    }
                    // 結束 if(dv2.Count > 0)
                }



                // 抓出 發票廠商收件人 DataGrid2
                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds4 = myPub.Selectc2_cont();
                DataView dv4 = ds4.Tables[0].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                string rowfilterstr4 = "1=1";
                rowfilterstr4 = rowfilterstr4 + " AND (cont_syscd='C2')";
                rowfilterstr4 = rowfilterstr4 + " AND (cont_contno='" + strContNo + "')";
                dv4.RowFilter = rowfilterstr4;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
                //Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

                // 若有資料, 則顯示相關資料; 否則給予錯誤訊息
                if (dv4.Count > 0)
                {
                    ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).DataSource = dv4;
                    ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).DataBind();


                    // 特別欄位之輸出格式轉換 - 變更發票類別等的格式
                    //Response.Write("DataGrid2.Count= " + ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items.Count + "<br>");
                    for (int m = 0; m < ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items.Count; m++)
                    {
                        // 合約起日
                        string sdate = ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[m].Cells[4].Text.ToString().Trim();
                        //Response.Write("sdate = " + sdate + "<br>");
                        if (sdate.Length >= 6)
                            sdate = sdate.Substring(0, 4) + "/" + sdate.Substring(4, 2);
                        else
                            sdate = sdate;
                        ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[m].Cells[4].Text = sdate;

                        // 合約迄日
                        string edate = ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[m].Cells[5].Text.ToString().Trim();
                        //Response.Write("edate = " + edate + "<br>");
                        if (edate.Length >= 6)
                            edate = edate.Substring(0, 4) + "/" + edate.Substring(4, 2);
                        else
                            edate = edate;
                        ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[m].Cells[5].Text = edate;

                        // 一次付款註記
                        string fgpayonce = ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[m].Cells[6].Text.ToString().Trim();
                        //Response.Write("fgpayonce = " + fgpayonce + "<br>");
                        if (fgpayonce == "0")
                            ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[m].Cells[6].Text = "否";
                        else
                            ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items[m].Cells[6].Text = "<font color='Red'>是</font>";

                    }
                }



                // Part IIII - 抓出符合條件的對應落版資料
                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds3 = myPub.Selectc2_pub2(date1, date2, strContNo);
                DataView dv3 = ds3.Tables[0].DefaultView;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv3.Count= "+ dv3.Count + "<BR>");
                //Response.Write("dv3.RowFilter= " + dv3.RowFilter + "<BR><BR>");

                // 若有資料, 則顯示相關資料; 否則給予錯誤訊息
                if (dv3.Count > 0)
                {
                    ((DataList)DataList1.Items[i].FindControl("DataList2")).DataSource = dv3;
                    ((DataList)DataList1.Items[i].FindControl("DataList2")).DataBind();

                    // 特別欄位之輸出格式轉換 - 變更發票類別等的格式
                    //Response.Write("DataGrid1.Count= " + ((DataGrid)DataList1.Items[i].FindControl("DataGrid1")).Items.Count + "<br>");
                    for (int k = 0; k < ((DataList)DataList1.Items[i].FindControl("DataList2")).Items.Count; k++)
                    {
                        // 刊登年月
                        string yyyymm = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblYYYYMM")).Text.ToString().Trim();
                        //Response.Write("yyyymm = " + yyyymm + "<br>");
                        int intyyyymm = int.Parse(yyyymm);
                        if (intyyyymm >= 6)
                            yyyymm = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
                        else
                            yyyymm = yyyymm;
                        ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblYYYYMM")).Text = yyyymm;

                        // 固定頁次註記
                        string fgfixpg = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgFixPg")).Text.ToString().Trim();
                        //Response.Write("fgfixpg = " + fgfixpg + "<br>");
                        if (fgfixpg == "0")
                            ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgFixPg")).Text = "否";
                        else
                            ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgFixPg")).Text = "<font color='Red'>是</font>";

                        // 修改日期
                        string ModifyDate = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblModifyDate")).Text.ToString().Trim();
                        //Response.Write("ModifyDate = " + ModifyDate + "<br>");
                        int intModifyDate = int.Parse(ModifyDate);
                        if (intModifyDate >= 8)
                            ModifyDate = ModifyDate.Substring(0, 4) + "/" + ModifyDate.Substring(4, 2) + "/" + ModifyDate.Substring(6, 2);
                        else
                            ModifyDate = ModifyDate;
                        ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblModifyDate")).Text = ModifyDate;

                        // 已開立發票開立單註記
                        string fginved = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgInved")).Text.ToString().Trim();
                        //Response.Write("fginved = " + fginved + "<br>");
                        if (fginved == "")
                            ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgInved")).Text = "<font color='Red'>否</font>";
                        if (fginved == "v")
                            ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgInved")).Text = "<font color='Blue'>已挑未開</font>";
                        if (fginved == "1")
                            ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgInved")).Text = "已開立";

                        // 發票開立單人工處理註記
                        string fginvself = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgInvSelf")).Text.ToString().Trim();
                        //Response.Write("fginvself = " + fginvself + "<br>");
                        if (fginvself == "0")
                            ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgInvSelf")).Text = "否";
                        else
                            ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgInvSelf")).Text = "<font color='Red'>是</font>";

                        // 稿件類別
                        string drafttp = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblDrafttp")).Text.ToString().Trim();
                        //Response.Write("drafttp = " + drafttp + "<br>");
                        switch (drafttp)
                        {
                            case "1":
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblDrafttp")).Text = "舊稿";

                                // 到稿註記
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgGot")).Text = "";

                                // 改稿相關資料
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgbkcd")).Text = "";
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgJNo")).Text = "";
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgJbkno")).Text = "";
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgReChg")).Text = "";

                                // 新稿相關資料
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgNjtpcd")).Text = "";
                                break;

                            case "2":
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblDrafttp")).Text = "新稿";

                                // 到稿註記
                                string fggot1 = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgGot")).Text.ToString().Trim();
                                //Response.Write("fggot1 = " + fggot1 + "<br>");
                                if (fggot1 == "0")
                                    ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgGot")).Text = "<font color='Red'>否</font>";
                                else
                                    ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgGot")).Text = "是";

                                // 舊稿相關資料
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblOrigBkcd")).Text = "";
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblOrigJNo")).Text = "";
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblOrigJbkno")).Text = "";

                                // 改稿相關資料
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgbkcd")).Text = "";
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgJNo")).Text = "";
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgJbkno")).Text = "";
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgReChg")).Text = "";
                                break;

                            case "3":
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblDrafttp")).Text = "改稿";

                                // 到稿註記
                                string fggot2 = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgGot")).Text.ToString().Trim();
                                //Response.Write("fggot2 = " + fggot2 + "<br>");
                                if (fggot2 == "0")
                                    ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgGot")).Text = "<font color='Red'>否</font>";
                                else
                                    ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgGot")).Text = "是";

                                // 改稿書類
                                string chgbkcd = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgbkcd")).Text.ToString().Trim();
                                //Response.Write("chgbkcd = " + chgbkcd + "<br>");
                                switch (chgbkcd)
                                {
                                    case "  ":
                                        ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgbkcd")).Text = "";
                                        break;
                                    case "01":
                                        ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgbkcd")).Text = "工材雜誌";
                                        break;
                                    case "02":
                                        ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgbkcd")).Text = "電材雜誌";
                                        break;
                                    default:
                                        ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgbkcd")).Text = "工材雜誌";
                                        break;
                                }

                                // 改稿重出片註記
                                string fgrechg = ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgReChg")).Text.ToString().Trim();
                                //Response.Write("fgrechg = " + fgrechg + "<br>");
                                if (fgrechg == "0")
                                    ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgReChg")).Text = "<font color='Red'>否</font>";
                                else
                                    ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgReChg")).Text = "是";

                                // 舊稿相關資料
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblOrigBkcd")).Text = "";
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblOrigJNo")).Text = "";
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblOrigJbkno")).Text = "";

                                // 新稿相關資料
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgNjtpcd")).Text = "";
                                break;

                            default:
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblDrafttp")).Text = "舊稿";

                                // 到稿註記
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgGot")).Text = "";

                                // 改稿相關資料
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgbkcd")).Text = "";
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgJNo")).Text = "";
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblChgJbkno")).Text = "";
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgReChg")).Text = "";

                                // 新稿相關資料
                                ((Label)((DataList)DataList1.Items[i].FindControl("DataList2")).Items[k].FindControl("lblfgNjtpcd")).Text = "";
                                break;
                        }
                        // 	結束 for(int k=0; k< ((DataList)DataList1.Items[i].FindControl("DataList2")).Items.Count ; k++)
                    }
                    // 結束 if(dv3.Count > 0)
                }
                // 結束 for(int i=0; i<DataList1.Items.Count; i++)
            }
        }
    }
}