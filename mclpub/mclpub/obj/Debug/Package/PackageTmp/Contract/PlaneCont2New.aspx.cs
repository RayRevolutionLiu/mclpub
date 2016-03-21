using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Contract
{
    public partial class PlaneCont2New : System.Web.UI.Page
    {
        PlaneCont2New_DB myPlane = new PlaneCont2New_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            imbIMRefresh.Attributes.Add("style", "display:none");
            imbORRefresh.Attributes.Add("style", "display:none");
            if (!IsPostBack)
            {

                DeleteBlankContData();

                // 抓出 廠商及客戶資料 區之資料, 藉由前一網頁傳來的變數值字串 custno
                GetMfrCust();

                // 抓出網頁初始值, 如動態下拉式選單 (由DB來), 系統日期等
                InitialData();


                // 若須載入舊有合約資料(when old_contno!="0"), 則載入之; 否則給予初始預設值
                if (Context.Request.QueryString["cont_contno"].ToString().Trim() != "0")
                {
                    // 將 參考合約書編號 寫入 lblOldContNo
                    this.lblOldContNo.Text = Context.Request.QueryString["cont_contno"].ToString().Trim();

                    // 載入舊有合約資料: 合約書細節 & 廣告聯落人 之初始預設值
                    LoadOldCont();


                    // 告知 發票廠商收件人 & 雜誌收件人 並有歷史資料
                    this.lblfgNew.Text = "1";
                    this.lblIMMessage.Text = "(有歷史資料)";
                    this.lblORMessage.Text = "(有歷史資料)";
                }
                else
                {
                    // 告知 參考合約書編號 無歷史資料
                    this.lblOldContNo.Text = "0";
                    this.lblOldContMessage.Text = "(無歷史資料, 此為新合約)";

                    // 給空白合約書: 合約書細節 & 廣告聯落人 之初始預設值
                    InitialContDetails();
                    InitialContContactor();

                    // 告知 發票廠商收件人 & 雜誌收件人 並無初始資料
                    this.lblfgNew.Text = "0";
                    this.lblIMMessage.Text = "(無初始資料, 請自行新增)";
                    this.lblORMessage.Text = "(無初始資料, 請自行新增)";

                    // 設 雜誌收件人-有登本數 & 未登本數 之初始值
                    this.lblORPunCnt.Text = "0";
                    this.lblORUnPubCnt.Text = "0";
                }
            }

            if (Context.Request.QueryString["cont_contno"].ToString().Trim() != "0")
            {
                // 載入 發票廠商收件人 & 雜誌收件人 之歷史資料 (依據 old_contno)
                BindGrid1();
                BindGrid2();
            }
        }


        // 抓出網頁初始值, 如動態下拉式選單 (由DB來), 系統日期等 - 主要為 合約書基本資料區
        private void InitialData()
        {
            // 合約書基本資料 區

            // 顯示 簽約日期及合約起迄日 之預設值: 抓系統日期之值
            // 顯示 合約迄日 之預設: 系統年月 + 加 11個月
            this.tbxSignDate.Text = System.DateTime.Today.ToString("yyyy/MM/dd").Trim();
            this.tbxStartDate.Text = System.DateTime.Today.ToString("yyyy/MM").Trim();
            //tbxEndDate.Value=System.DateTime.Today.AddDays(364).ToString("yyyy/MM");
            this.tbxEndDate.Text = System.DateTime.Today.AddMonths(11).ToString("yyyy/MM").Trim();

            // 最後修改日期之預設值
            //Response.Write("tbxStartDate.Value= " + tbxStartDate.Value + "<br>");
            //Response.Write("hiddenModDate.Value= " + hiddenModDate.Value + "<br>");

            // 顯示下拉式選單 書籍類別的 DB 值
            // 關於 nostr, 請參 sqlDataAdapter2.Select statement;
            // nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
            DataSet ds2 = myPlane.SelectBooks();
            DataView dv2 = ds2.Tables["book"].DefaultView;
            ddlBookCode.DataSource = dv2;
            dv2.RowFilter = "proj_fgitri=''";
            ddlBookCode.DataTextField = "bk_nm";
            //ddlBookCode.DataValueField="nostr";
            // 維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
            ddlBookCode.DataValueField = "bk_bkcd";
            ddlBookCode.DataBind();

            // 顯示下拉式選單 業務員的 DB 值
            // **注意: 原本資料庫內之 srspn_cname & srspn_empno 是 char(x) 型態, 故其 sqlDataAdapter4 裡, 要先做 RTRIM 的處理 (如 RTRIM(srspn_cname) AS srspn_cname), 否則其值會含有空白, 如 '800443 ', '康靜怡     ' .
            DataSet ds3 = myPlane.SelectSrspn();
            ddlEmpNo.ClearSelection();
            ddlEmpNo.DataSource = ds3;
            ddlEmpNo.DataTextField = "srspn_cname";
            ddlEmpNo.DataValueField = "srspn_empno";
            ddlEmpNo.DataBind();


            // 抓出登入者的工號, 作為預設 建檔業務員 之值
            string LoginEmpNo = "";
            //Response.Write("empid= " + User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) + "<br>");
            // 若有登入者的資料, 則抓出並預選 建檔業務員之下拉式選單
            if (ddlEmpNo.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()) != null)
            {
                ddlEmpNo.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()).Selected = true;
            }
            // 若無登入者的資料, 則抓出並預選業務員為 康靜怡 (800443, SelectedIndex=02)
            else
            {
                //LoginEmpNo = User.Identity.Name.Substring(5, 6).ToString().Trim();
                //Response.Write("User.Identity.Name= " + User.Identity.Name.ToString().Trim() + "<br>");
                LoginEmpNo = "800443";
                this.ddlEmpNo.Items.FindByValue("800443").Selected = true;
            }
            //Response.Write("LoginEmpNo= " + LoginEmpNo + "<br>");


            // 指定並顯示新的 合約書編號
            string strDBMaxContNo = "";
            string strAssignedContNo = "";
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds4 = myPlane.SelectMaxC2_cont();
            DataView dv4 = ds4.Tables["c2_cont"].DefaultView;

            //Response.Write("dv4.Count= " + dv4.Count + "<br>");
            //Response.Write("Current MaxContNo= " + dv4[0][0].ToString().Trim() + "<br>");

            // 若有資料, 則顯示相關資料; 否則給予錯誤訊息
            // 注意： 此處因 sqlDataAdapter4 不管是否有資料, 其 dv4[0][0] 會回傳數字: 0以上; 故當大於0時, 表示資料庫中真正有 MaxCountNo
            // 故此處不可用 if(dv4.Count >0) 來做判斷
            if (int.Parse(dv4[0][0].ToString().Trim()) > 0)
            {
                // 抓出 新的合約書編號 = 目前資料庫中的Max合約書編號+1
                strAssignedContNo = Convert.ToString(Convert.ToInt32(dv4[0][1].ToString().Trim()) + 1);
                //Response.Write("strAssignedContNo= " + strAssignedContNo + "<br>");

                // 做補零動作: strAssignedContNo 必須是四位數
                // 方法一: 用 if 來判斷 做補零動作
                if (strAssignedContNo.Length == 1)
                    strAssignedContNo = "00000" + strAssignedContNo;
                if (strAssignedContNo.Length == 2)
                    strAssignedContNo = "0000" + strAssignedContNo;
                if (strAssignedContNo.Length == 3)
                    strAssignedContNo = "000" + strAssignedContNo;
                if (strAssignedContNo.Length == 4)
                    strAssignedContNo = "00" + strAssignedContNo;
                if (strAssignedContNo.Length == 5)
                    strAssignedContNo = "0" + strAssignedContNo;
                if (strAssignedContNo.Length == 6)
                    strAssignedContNo = strAssignedContNo;

                // 方法二: 以 for loop 做補零動作
                //				for (int i=1; i<strAssignedContNo.Length; i++)
                //				{
                //					//strAssignedContNo = "0" + strAssignedContNo;
                //				}
            }
            else
            {
                strAssignedContNo = "000001";
            }
            // 指定並顯示新的 合約書編號
            //Response.Write("strAssignedContNo= " + strAssignedContNo + "<br>");
            this.lblContNo.Text = strAssignedContNo;

            // 新增 此新的合約書編號 入資料庫中, 以免同時有二人以上做 新增合約書動作時, 新增之合約書編號相同
            // 日後, 若發生此同時有二人以上操作時, 則系統因會自動抓 MaxContNo 而不會發生新增錯誤 (因合約書編號相同, 但資料卻可能不同)
            InsertNewContNo();
        }


        // 新增 此新的合約書編號 入資料庫中
        private void InsertNewContNo()
        {
            // 抓出 新合約書編號
            string strSyscd = "C2";
            string strCurrentContNo = this.lblContNo.Text.ToString().Trim();


            // 確認執行 sqlSelectCommand1 成功
            bool ResultFlag1 = false;
            try
            {
                myPlane.InsertC2_cont(strSyscd, strCurrentContNo);
                ResultFlag1 = true;
            }
            catch (System.Data.SqlClient.SqlException ex1)
            {
                Response.Write(ex1.Message + "<br>");
                ResultFlag1 = false;
            }

            // 輸出執行結果
            if (ResultFlag1)
            {
                //Response.Write("新增 合約檔PK 成功!<br>");

                // 以 Javascript 的 window.close() 來告知訊息
                //LiteralControl litAlert1 = new LiteralControl();
                //litAlert1.Text = "<script language=javascript>alert(\"新增 合約檔PK 成功\");</script>";
                //Page.Controls.Add(litAlert1);
            }
            else
            {
                //Response.Write("新增 合約檔PK 失敗!<br>");

                // 以 Javascript 的 window.close() 來告知訊息
                //LiteralControl litAlert1 = new LiteralControl();
                //litAlert1.Text = "<script language=javascript>alert(\"新增 合約檔PK 失敗\");</script>";
                //Page.Controls.Add(litAlert1);
            }

        }


        // 抓出 廠商及客戶資料 區之資料
        private void GetMfrCust()
        {
            // 藉由前一網頁傳來的變數值字串 custno
            string custno = "";

            // 若有客戶編號, 則指定顯示之
            if (Context.Request.QueryString["cust_custno"].ToString().Trim() != "" || Context.Request.QueryString["cust_custno"].ToString().Trim() != null)
            {
                custno = Context.Request.QueryString["cust_custno"].ToString().Trim();


                //Response.Write("custno= " + custno + "<BR>");
                lblCustNo.Text = custno;


                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds1 = myPlane.SelectCust();
                DataView dv1 = ds1.Tables["cust"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                string rowfilterstr = "1=1";
                rowfilterstr = rowfilterstr + " AND cust_custno='" + custno + "'";
                dv1.RowFilter = rowfilterstr;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
                //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

                // 若有資料, 則顯示相關資料; 否則給予錯誤訊息
                if (dv1.Count > 0)
                {
                    // 藉由前一網頁傳來的變數值字串 custno
                    this.lblCustName.Text = dv1[0]["cust_nm"].ToString().Trim();

                    ///抓出該客戶之廠商統編 mfrno (藉 cust_mfrno)
                    string mfrno = dv1[0]["cust_mfrno"].ToString().Trim();
                    //Response.Write("mfrno= " + mfrno + "<BR>");

                    // 若此廠商不存在, 則顯示 顯示 "無資料" 資訊; 否則, 顯示其相關資料
                    if (mfrno == "9999999999")
                    {
                        this.lblMfrIName.Text = "<font color='RED'>無對應統一編號</font>";
                        this.lblMfrNo.Text = mfrno;
                        this.lblMfrRespName.Text = "<font color='Gray'>無資料</font>";
                        this.lblMfrRespJobTitle.Text = "<font color='Gray'>無資料</font>";
                        this.lblMfrTel.Text = "<font color='Gray'>無資料</font>";
                        this.lblMfrFax.Text = "<font color='Gray'>無資料</font>";
                    }
                    else
                    {
                        this.lblMfrNo.Text = mfrno;

                        // 再藉 廠商統編 mfrno, 抓其相關資料
                        if (dv1[0]["mfr_inm"].ToString().Trim() != "")
                            this.lblMfrIName.Text = dv1[0]["mfr_inm"].ToString().Trim();
                        else
                            this.lblMfrIName.Text = "<font color='Gray'>無資料</font>";

                        if (dv1[0]["mfr_respnm"].ToString().Trim() != "")
                            this.lblMfrRespName.Text = dv1[0]["mfr_respnm"].ToString().Trim();
                        else
                            this.lblMfrRespName.Text = "<font color='Gray'>無資料</font>";

                        if (dv1[0]["mfr_respjbti"].ToString().Trim() != "")
                            this.lblMfrRespJobTitle.Text = dv1[0]["mfr_respjbti"].ToString().Trim();
                        else
                            this.lblMfrRespJobTitle.Text = "<font color='Gray'>無資料</font>";

                        if (dv1[0]["mfr_tel"].ToString().Trim() != "")
                            this.lblMfrTel.Text = dv1[0]["mfr_tel"].ToString().Trim();
                        else
                            this.lblMfrTel.Text = "<font color='Gray'>無資料</font>";

                        if (dv1[0]["mfr_fax"].ToString().Trim() != "")
                            this.lblMfrFax.Text = dv1[0]["mfr_fax"].ToString().Trim();
                        else
                            this.lblMfrFax.Text = "<font color='Gray'>無資料</font>";
                    }
                }
                // 若找無資料, 則清除資料
                else
                {
                    this.lblMfrNo.Text = "<font color='Gray'>查無此廠商統編</font>";
                    //					this.lblMfrIName.Text = "<font color='Gray'>無資料</font>";
                    this.lblMfrRespName.Text = "<font color='Gray'>無資料</font>";
                    this.lblMfrRespJobTitle.Text = "<font color='Gray'>無資料</font>";
                    this.lblMfrTel.Text = "<font color='Gray'>無資料</font>";
                    this.lblMfrFax.Text = "<font color='Gray'>無資料</font>";

                    this.lblCustName.Text = "(<font color='RED'>查無此客戶編號</font>)";
                    this.lblCustNo.Text = "<font color='Gray'>無資料</font>";
                }

                // 結束 if  // 若有客戶編號, 則指定顯示之
            }
        }


        // 刪除空白的合約書資料
        private void DeleteBlankContData()
        {
            // 確認執行 sqlCommand6 成功
            try
            {
                myPlane.DelBlankContData();
            }
            catch (System.Data.SqlClient.SqlException ex6)
            {
                Response.Write(ex6.Message + "<br>");
            }
        }


        // 載入舊有合約資料: 合約書細節 & 廣告聯落人 之初始預設值
        private void LoadOldCont()
        {
            // 抓出網頁變數: 客戶編號
            string strOldContNo = Context.Request.QueryString["cont_contno"].ToString().Trim();
            //Response.Write("strOldContNo= "+ strOldContNo + "<BR>");

            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds5 = myPlane.SelectC2_cont();
            DataView dv5 = ds5.Tables["c2_cont"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            string rowfilterstr5 = "1=1";
            rowfilterstr5 = rowfilterstr5 + " AND cont_contno='" + strOldContNo + "'";
            dv5.RowFilter = rowfilterstr5;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
            //Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

            // 若有資料, 則顯示相關資料; 否則給予錯誤訊息
            if (dv5.Count > 0)
            {
                // 合約書細節 區
                this.tbxTotalJTime.Text = dv5[0]["cont_totjtm"].ToString().Trim();
                this.tbxTotalTime.Text = dv5[0]["cont_tottm"].ToString().Trim();
                this.tbxChangeJTime.Text = dv5[0]["cont_chgjtm"].ToString().Trim();
                this.tbxFreeTime.Text = dv5[0]["cont_freetm"].ToString().Trim();
                this.tbxADAmt.Text = dv5[0]["cont_adamt"].ToString().Trim();
                this.tbxDiscount.Text = dv5[0]["cont_disc"].ToString().Trim();
                this.tbxFreeBookCount.Text = dv5[0]["cont_freebkcnt"].ToString().Trim();
                this.tbxTotalAmt.Text = dv5[0]["cont_totamt"].ToString().Trim();
                this.tbxColorTime.Text = dv5[0]["cont_clrtm"].ToString().Trim();
                this.tbxGetColorTime.Text = dv5[0]["cont_getclrtm"].ToString().Trim();
                this.tbxMenoTime.Text = dv5[0]["cont_menotm"].ToString().Trim();
                this.tarContRemark.Value = dv5[0]["cont_remark"].ToString().Trim();

                // 廣告聯絡人 區
                this.tbxAuName.Text = dv5[0]["cont_aunm"].ToString().Trim();
                this.tbxAuTel.Text = dv5[0]["cont_autel"].ToString().Trim();
                this.tbxAuFax.Text = dv5[0]["cont_aufax"].ToString().Trim();
                this.tbxAuCell.Text = dv5[0]["cont_aucell"].ToString().Trim();
                this.tbxAuEmail.Text = dv5[0]["cont_auemail"].ToString().Trim();
            }
        }


        // 載入 發票廠商收件人資料
        private void BindGrid1()
        {
            // 抓出 篩選條件
            string strsyscd = "C2";
            string strConto = this.lblContNo.Text.ToString().Trim();


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds6 = myPlane.SelectInvmfr();
            DataView dv6 = ds6.Tables["invmfr"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr6 = "1=1";
            rowfilterstr6 = rowfilterstr6 + " AND im_syscd='" + strsyscd + "'";
            rowfilterstr6 = rowfilterstr6 + " AND im_contno='" + strConto + "'";
            dv6.RowFilter = rowfilterstr6;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
            //Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");

            // 顯示其相關資料
            GridView1.DataSource = dv6;
            GridView1.DataBind();

        }


        // 載入 發票廠商收件人資料
        private void BindGrid2()
        {
            // 抓出 篩選條件
            string strsyscd = "C2";
            string strConto = this.lblContNo.Text.ToString().Trim();


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds7 = myPlane.SelectC2_or();
            DataView dv7 = ds7.Tables["c2_or"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr7 = "1=1";
            rowfilterstr7 = rowfilterstr7 + " AND or_syscd='" + strsyscd + "'";
            rowfilterstr7 = rowfilterstr7 + " AND or_contno='" + strConto + "'";
            dv7.RowFilter = rowfilterstr7;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv7.Count= "+ dv7.Count + "<BR>");
            //Response.Write("dv7.RowFilter= " + dv7.RowFilter + "<BR>");

            // 顯示其相關資料
            GridView2.DataSource = dv7;
            GridView2.DataBind();

            int PubCount = 0;
            int UnPubCount = 0;
            for (int i = 0; i < dv7.Count; i++)
            {
                PubCount += int.Parse(dv7[i]["or_pubcnt"].ToString().Trim());
                UnPubCount += int.Parse(dv7[i]["or_unpubcnt"].ToString().Trim());
            }

            // 顯示 總計：有登本數 & 未登本數
            //Response.Write("Toal PubCount= " + PubCount + "<br>");
            //Response.Write("Toal UnPubCount= " + UnPubCount + "<br>");
            this.lblORPunCnt.Text = Convert.ToString(PubCount);
            this.lblORUnPubCnt.Text = Convert.ToString(UnPubCount);

        }


        // 給空白合約書: 合約書細節 之初始預設值
        private void InitialContDetails()
        {
            this.tbxTotalJTime.Text = "0";
            this.tbxTotalTime.Text = "0";
            this.tbxChangeJTime.Text = "0";
            this.tbxFreeTime.Text = "0";
            this.tbxADAmt.Text = "0";
            this.tbxDiscount.Text = "0.";
            this.tbxFreeBookCount.Text = "1";
            this.tbxTotalAmt.Text = "0";
            this.tbxColorTime.Text = "0";
            this.tbxGetColorTime.Text = "0";
            this.tbxMenoTime.Text = "0";
        }


        // 給空白合約書: 廣告聯絡人 之初始預設值
        private void InitialContContactor()
        {
            // 抓出網頁變數: 客戶編號
            string strCustNo = Context.Request.QueryString["cust_custno"].ToString().Trim();

            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = myPlane.SelectCust();
            DataView dv1 = ds1.Tables["cust"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            string rowfilterstr = "1=1";
            rowfilterstr = rowfilterstr + " AND cust_custno='" + strCustNo + "'";
            dv1.RowFilter = rowfilterstr;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv1.Count= "+ dv1.Count + "<BR>");
            //Response.Write("dv1.RowFilter= " + dv1.RowFilter + "<BR>");

            // 若有資料, 則顯示相關資料; 否則給予錯誤訊息
            if (dv1.Count > 0)
            {
                this.tbxAuName.Text = dv1[0]["cust_nm"].ToString().Trim();
                this.tbxAuTel.Text = dv1[0]["cust_tel"].ToString().Trim();
                this.tbxAuFax.Text = dv1[0]["cust_fax"].ToString().Trim();
                this.tbxAuCell.Text = dv1[0]["cust_cell"].ToString().Trim();
                this.tbxAuEmail.Text = dv1[0]["cust_email"].ToString().Trim();
            }
        }

        protected void GridView1OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                    // 發票類別
                string invcd = e.Row.Cells[10].Text.Trim();
                    switch (invcd)
                    {
                        case "2":
                            e.Row.Cells[10].Text = "二聯";
                            break;
                        case "3":
                            e.Row.Cells[10].Text = "三聯";
                            break;
                        case "4":
                            e.Row.Cells[10].Text = "其他";
                            break;
                        case "9":
                            e.Row.Cells[10].Text = "不清楚";
                            e.Row.Cells[10].ForeColor = System.Drawing.Color.Red;
                            break;
                        default:
                            e.Row.Cells[10].Text = "三聯";
                            break;
                    }

                    // 發票課稅別
                    string taxtp = e.Row.Cells[11].Text.Trim();
                    switch (taxtp)
                    {
                        case "1":
                            e.Row.Cells[11].Text = "應稅5%";
                            break;
                        case "2":
                            e.Row.Cells[11].Text = "零稅";
                            break;
                        case "3":
                            e.Row.Cells[11].Text = "免稅";
                            break;
                        case "9":
                            e.Row.Cells[11].Text = "不清楚";
                            e.Row.Cells[11].ForeColor = System.Drawing.Color.Red;
                            break;
                        default:
                            e.Row.Cells[11].Text = "應稅5%";
                            break;
                    }

                    // 院所內註記
                    string fgItri = e.Row.Cells[12].Text.Trim();
                    switch (fgItri)
                    {
                        case "":
                            e.Row.Cells[12].Text = "否";
                            break;
                        case "06":
                            e.Row.Cells[12].Text = "<font color='Red'>所內</font>";
                            break;
                        case "07":
                            e.Row.Cells[12].Text = "<font color='Red'>院內</font>";
                            break;
                        default:
                            e.Row.Cells[12].Text = "否";
                            break;
                    }

                
            }

        }


        protected void GridView2OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式

                // 發票類別代碼
                string mtpcd = e.Row.Cells[12].Text.Trim();

                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds8 = myPlane.SelectMtp();
                DataView dv8 = ds8.Tables["mtp"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr8 = "1=1";
                rowfilterstr8 = rowfilterstr8 + " AND mtp_mtpcd='" + mtpcd + "'";
                dv8.RowFilter = rowfilterstr8;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv8.Count= "+ dv8.Count + "<BR>");
                //Response.Write("dv8.RowFilter= " + dv8.RowFilter + "<BR>");

                if (dv8.Count > 0)
                {
                    // 抓出 郵寄類別相關資料
                    string mtpnm = dv8[0]["mtp_nm"].ToString().Trim();
                    e.Row.Cells[12].Text = mtpnm;
                }
                else
                {
                    e.Row.Cells[12].Text = "（資料有誤)";
                }


                // 海外郵寄註記
                string fgmosea = e.Row.Cells[13].Text.Trim();
                switch (fgmosea)
                {
                    case "0":
                        e.Row.Cells[13].Text = "國內";
                        break;
                    case "1":
                        e.Row.Cells[13].Text = "<font color='Red'>國外</font>";
                        break;
                    default:
                        e.Row.Cells[13].Text = "國內";
                        break;
                }
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            // 將畫面上的資料, 更新入資料庫中
            UpdateContDB();
        }


        // 更新資料入 DB Table
        private void UpdateContDB()
        {
            // 抓下畫面上的值 - 以區域來分
            // 廠商及客戶資料 區
            string strMfrNo = this.lblMfrNo.Text.ToString().Trim();
            string strCustNo = this.lblCustNo.Text.ToString().Trim();

            // 合約書基本資料 區
            string strSyscd = "C2";
            string strContNo = this.lblContNo.Text.ToString().Trim();
            string strContType = this.ddlContType.SelectedItem.Value.ToString().Trim();
            string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString().Trim();
            string strSignDate = this.tbxSignDate.Text.ToString().Trim();
            strSignDate = strSignDate == "" ? "" : strSignDate.Substring(0, 4) + strSignDate.Substring(5, 2) + strSignDate.Substring(8, 2);
            string strEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
            string strStartDate = this.tbxStartDate.Text.ToString().Trim();
            strStartDate = strStartDate == "" ? "" : strStartDate.Substring(0, 4) + strStartDate.Substring(5, 2);
            string strEndDate = this.tbxEndDate.Text.ToString().Trim();
            strEndDate = strEndDate == "" ? "" : strEndDate.Substring(0, 4) + strEndDate.Substring(5, 2);
            // 註記類說明： 0代表否（預設）, １代表是
            string strfgClosed = "0";
            // 處理 lblOldContNo : 若為文字, 則轉為正確之數值
            string strOldContNo = this.lblOldContNo.Text.ToString().Trim();
            // 若 strOldContNo 值為 (無歷史資料, 此為新合約) => Length >6; 則改存為0; 否則存為原舊合約編號之值(Length=6)
            if (strOldContNo.Length > 6)
                strOldContNo = "0";
            else
                strOldContNo = Context.Request.QueryString["cont_contno"].ToString().Trim();
            string strModifyDate = System.DateTime.Today.ToString("yyyyMMdd").Trim();
            // 若 rblfgPayOnce 沒有選擇時, 給予預設值 0
            string strfgPayOnce = "0";
            if (this.rblfgPayOnce.SelectedIndex >= 0)
                strfgPayOnce = this.rblfgPayOnce.SelectedItem.Value.ToString().Trim();

            string strModifyEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
            // 註記類說明： 0代表否（預設）, １代表是
            string strfgCancel = "0";
            string strCreateDate = System.DateTime.Today.ToString("yyyyMMdd").Trim();
            //Response.Write("strSyscd= " + strSyscd + "<br>");
            //Response.Write("strContNo= " + strContNo + "<br>");
            //Response.Write("strContType= " + strContType + "<br>");
            //Response.Write("strSignDate= " + strSignDate + "<br>");
            //Response.Write("strEmpNo= " + strEmpNo + "<br>");
            //Response.Write("strfgClosed= " + strfgClosed + "<br>");
            //Response.Write("strOldContNo= " + strOldContNo + "<br>");
            //Response.Write("strModifyEmpNo= " + strModifyEmpNo + "<br>");
            //Response.Write("strCreateDate= " + strCreateDate + "<br>");

            // 合約書細節資料 區
            string strTotalJTime = "0";
            if (this.tbxTotalJTime.Text.ToString().Trim() != "")
                strTotalJTime = this.tbxTotalJTime.Text.ToString().Trim();
            string strMadeJTime = "0";
            string strRestJTime = "0";
            if (this.tbxTotalJTime.Text.ToString().Trim() != "")
                strRestJTime = this.tbxTotalJTime.Text.ToString().Trim();
            string strTotalTime = "0";
            if (this.tbxTotalTime.Text.ToString().Trim() != "")
                strTotalTime = this.tbxTotalTime.Text.ToString().Trim();
            string strPubTime = "0";
            string strRestTime = "0";
            if (this.tbxTotalTime.Text.ToString().Trim() != "")
                strRestTime = this.tbxTotalTime.Text.ToString().Trim();
            string strTotalAmount = "0";
            if (this.tbxTotalAmt.Text.ToString().Trim() != "")
                strTotalAmount = this.tbxTotalAmt.Text.ToString().Trim();
            string strPaidAmount = "0";
            string strRestAmount = "0";
            if (this.tbxTotalAmt.Text.ToString().Trim() != "")
                strRestAmount = this.tbxTotalAmt.Text.ToString().Trim();
            string strChangeJTime = "0";
            if (this.tbxChangeJTime.Text.ToString().Trim() != "")
                strChangeJTime = this.tbxChangeJTime.Text.ToString().Trim();
            string strFreeTime = "0";
            if (this.tbxFreeTime.Text.ToString().Trim() != "")
                strFreeTime = this.tbxFreeTime.Text.ToString().Trim();
            string strADAmount = "0";
            if (this.tbxADAmt.Text.ToString().Trim() != "")
                strADAmount = this.tbxADAmt.Text.ToString().Trim();
            string strDiscount = "0.99";
            if (this.tbxDiscount.Text.ToString().Trim() != "")
                strDiscount = this.tbxDiscount.Text.ToString().Trim();
            string strFreeBookCount = "0";
            if (this.tbxFreeBookCount.Text.ToString().Trim() != "")
                strFreeBookCount = this.tbxFreeBookCount.Text.ToString().Trim();
            string strPubAdAmount = "0";
            string strPubChangeAmount = "0";
            string strColorTime = "0";
            if (this.tbxColorTime.Text.ToString().Trim() != "")
                strColorTime = this.tbxColorTime.Text.ToString().Trim();
            string strMenoTime = "0";
            if (this.tbxMenoTime.Text.ToString().Trim() != "")
                strMenoTime = this.tbxMenoTime.Text.ToString().Trim();
            string strGetColorTime = "0";
            if (this.tbxGetColorTime.Text.ToString().Trim() != "")
                strMenoTime = this.tbxGetColorTime.Text.ToString().Trim();
            string strRestColorTime = "0";
            string strRestGetColorTime = "0";
            string strRestMenoTime = "0";
            if (this.tbxColorTime.Text.ToString().Trim() != "0")
                strRestColorTime = Convert.ToString(int.Parse(this.tbxColorTime.Text.ToString().Trim()) + int.Parse(this.tbxFreeTime.Text.ToString().Trim()));

            if (this.tbxGetColorTime.Text.ToString().Trim() != "0")
                strRestGetColorTime = Convert.ToString(int.Parse(this.tbxGetColorTime.Text.ToString().Trim()) + int.Parse(this.tbxFreeTime.Text.ToString().Trim()));

            if (this.tbxMenoTime.Text.ToString().Trim() != "0")
                strRestMenoTime = Convert.ToString(int.Parse(this.tbxMenoTime.Text.ToString().Trim()) + int.Parse(this.tbxFreeTime.Text.ToString().Trim()));

            //Response.Write("strADAmount= " + strADAmount + "<br>");

            // 廣告聯絡人 區
            string strAUName = this.tbxAuName.Text.ToString().Trim();
            string strAUTel = this.tbxAuTel.Text.ToString().Trim();
            string strAUFax = this.tbxAuFax.Text.ToString().Trim();
            string strAUCell = this.tbxAuCell.Text.ToString().Trim();
            string strAUEmail = this.tbxAuEmail.Text.ToString().Trim();

            // 廣告聯絡人 區
            string strRemark = this.tarContRemark.Value.ToString().Trim();


            // 確認執行 sqlSelectCommand5 成功
            bool ResultFlag5 = false;
            try
            {
                myPlane.UpdateC2_cont(strMfrNo, strCustNo, strSyscd, strContNo, strContType, strBkcd, strSignDate, strEmpNo, strStartDate, strEndDate, strfgClosed,
                    strOldContNo, strModifyDate, strfgPayOnce, strModifyEmpNo, strfgCancel, strCreateDate, strTotalJTime, strMadeJTime, strRestJTime, strDiscount, strFreeTime,
                    strTotalTime, strPubTime, strRestTime, strChangeJTime, strTotalAmount, strPubAdAmount, strPubChangeAmount, strPaidAmount, strRestAmount, strColorTime, strMenoTime
                    , strGetColorTime, strADAmount, strFreeBookCount, strRestColorTime, strRestGetColorTime, strRestMenoTime, strAUName, strAUTel, strAUFax, strAUCell, strAUEmail, strRemark);
                ResultFlag5 = true;
            }
            catch (System.Data.SqlClient.SqlException ex5)
            {
                Application["ErrorMsg"] = ex5;
                Response.Redirect("~/errorPage.aspx");
            }

            // 輸出執行結果
            if (ResultFlag5)
            {
                //Response.Write("新增合約書成功!<br>");
                LiteralControl litAlert5 = new LiteralControl();
                litAlert5.Text = "<script language=javascript>alert(\"新增合約書成功\");</script>";
                Page.Controls.Add(litAlert5);

                // 轉址處理 - 合約書檢核表
                Response.Redirect("ContFm_chklist.aspx");

            }
            else
            {
                //Response.Write("新增合約書失敗!<br>");
                LiteralControl litAlert5 = new LiteralControl();
                litAlert5.Text = "<script language=javascript>alert(\"新增合約書失敗, \n請印出畫面, 通知網頁連絡人!\");</script>";
                Page.Controls.Add(litAlert5);
            }

            // 告知 合約書已新增過的訊息, 避免使用者重覆按下 '儲存新增' 的按鈕
            this.lblAddMessage.Text = "合約書資料已新增成功! 您已按過 '儲存新增' 按鈕了, 請勿重覆按下!";
        }



        protected void btnBack_Click(object sender, EventArgs e)
        {
            // 刪除空白的合約書資料
            DeleteBlankContData();


            // 轉址處理
            Response.Redirect("../default.aspx");
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // 抓出 新合約書編號
            string strSyscd = "C2";
            string strCurrentContNo = this.lblContNo.Text.ToString().Trim();

            bool ResultFlag2 = false;
            try
            {
                myPlane.DelInvmfr(strSyscd, strCurrentContNo);
                ResultFlag2 = true;
            }
            catch (System.Data.SqlClient.SqlException ex2)
            {
                Application["ErrorMsg"] = ex2;
                Response.Redirect("~/errorPage.aspx");
            }


            // 輸出執行結果
            if (ResultFlag2)
            {
                //Response.Write("刪除 發票廠商收件人 成功!<br>");

                // 以 Javascript 的 window.close() 來告知訊息
                JavaScript.AlertMessage(this.Page, "\"刪除 發票廠商收件人 成功\"");
                //LiteralControl litAlert2 = new LiteralControl();
                //litAlert2.Text = "<script language=javascript>alert(\"刪除 發票廠商收件人 成功\");</script>";
                //Page.Controls.Add(litAlert2);
            }
            else
            {
                //Response.Write("刪除 發票廠商收件人 失敗!<br>");

                // 以 Javascript 的 window.close() 來告知訊息
                JavaScript.AlertMessage(this.Page, "\"刪除 發票廠商收件人 失敗\"");
                //LiteralControl litAlert2 = new LiteralControl();
                //litAlert2.Text = "<script language=javascript>alert(\"刪除 發票廠商收件人 失敗\");</script>";
                //Page.Controls.Add(litAlert2);
            }


            // 確認執行 sqlSelectCommand1 成功
            bool ResultFlag3 = false;
            try
            {
                myPlane.DelC2_or(strSyscd, strCurrentContNo);
                ResultFlag3 = true;
            }
            catch (System.Data.SqlClient.SqlException ex3)
            {
                Application["ErrorMsg"] = ex3;
                Response.Redirect("~/errorPage.aspx");
            }

            // 輸出執行結果
            if (ResultFlag3)
            {
                //Response.Write("刪除 雜誌收件人 成功!<br>");

                // 以 Javascript 的 window.close() 來告知訊息
                JavaScript.AlertMessage(this.Page, "\"刪除 雜誌收件人 成功\"");
                //LiteralControl litAlert3 = new LiteralControl();
                //litAlert3.Text = "<script language=javascript>alert(\"刪除 雜誌收件人 成功\");</script>";
                //Page.Controls.Add(litAlert3);
            }
            else
            {
                //Response.Write("刪除 雜誌收件人 失敗!<br>");

                // 以 Javascript 的 window.close() 來告知訊息
                JavaScript.AlertMessage(this.Page, "\"刪除 雜誌收件人 失敗\"");
                //LiteralControl litAlert3 = new LiteralControl();
                //litAlert3.Text = "<script language=javascript>alert(\"刪除 雜誌收件人 失敗\");</script>";
                //Page.Controls.Add(litAlert3);
            }


            // 確認執行 sqlSelectCommand1 成功
            bool ResultFlag4 = false;

            try
            {
                myPlane.DelC2_cont(strSyscd, strCurrentContNo);
                ResultFlag4 = true;
            }
            catch (System.Data.SqlClient.SqlException ex4)
            {
                Application["ErrorMsg"] = ex4;
                Response.Redirect("~/errorPage.aspx");
            }


            // 輸出執行結果
            if (ResultFlag4)
            {
                //Response.Write("刪除 合約書 成功!<br>");

                //// 以 Javascript 的 window.close() 來告知訊息
                //LiteralControl litAlert4 = new LiteralControl();
                //litAlert4.Text = "<script language=javascript>alert(\"刪除 合約書 成功\");</script>";
                //Page.Controls.Add(litAlert4);
                JavaScript.AlertMessageRedirect(this.Page, "\"刪除 合約書 成功\"", "../Default.aspx");
            }
            else
            {
                //Response.Write("刪除 合約書 失敗!<br>");

                // 以 Javascript 的 window.close() 來告知訊息
                LiteralControl litAlert4 = new LiteralControl();
                litAlert4.Text = "<script language=javascript>alert(\"刪除 合約書 失敗\");</script>";
                Page.Controls.Add(litAlert4);
            }
        }


        protected void imbORRefresh_Click(object sender, ImageClickEventArgs e)
        {
            // 若須載入舊有合約資料(when old_contno!="0"), 則載入之; 否則給予初始預設值
            if (Context.Request.QueryString["cont_contno"].ToString().Trim() != "0")
            {
                // 將 參考合約書編號 寫入 lblOldContNo
                this.lblOldContNo.Text = Context.Request.QueryString["cont_contno"].ToString().Trim();

                // 載入舊有合約資料: 合約書細節 & 廣告聯落人 之初始預設值
                LoadOldCont();


                // 告知 發票廠商收件人 & 雜誌收件人 並有歷史資料
                this.lblfgNew.Text = "1";
                this.lblIMMessage.Text = "(有歷史資料)";
                this.lblORMessage.Text = "(有歷史資料)";
            }
            else
            {
                // 告知 參考合約書編號 無歷史資料
                this.lblOldContNo.Text = "0";
                this.lblOldContMessage.Text = "(無歷史資料, 此為新合約)";

                // 給空白合約書: 合約書細節 & 廣告聯落人 之初始預設值
                InitialContDetails();
                InitialContContactor();

                // 告知 發票廠商收件人 & 雜誌收件人 並無初始資料
                this.lblfgNew.Text = "0";
                this.lblIMMessage.Text = "(無初始資料, 請自行新增)";
                this.lblORMessage.Text = "(無初始資料, 請自行新增)";

                // 設 雜誌收件人-有登本數 & 未登本數 之初始值
                this.lblORPunCnt.Text = "0";
                this.lblORUnPubCnt.Text = "0";
            }
            BindGrid2();
        }

        protected void imbIMRefresh_Click(object sender, ImageClickEventArgs e)
        {
            // 若須載入舊有合約資料(when old_contno!="0"), 則載入之; 否則給予初始預設值
            if (Context.Request.QueryString["cont_contno"].ToString().Trim() != "0")
            {
                // 將 參考合約書編號 寫入 lblOldContNo
                this.lblOldContNo.Text = Context.Request.QueryString["cont_contno"].ToString().Trim();

                // 載入舊有合約資料: 合約書細節 & 廣告聯落人 之初始預設值
                LoadOldCont();


                // 告知 發票廠商收件人 & 雜誌收件人 並有歷史資料
                this.lblfgNew.Text = "1";
                this.lblIMMessage.Text = "(有歷史資料)";
                this.lblORMessage.Text = "(有歷史資料)";
            }
            else
            {
                // 告知 參考合約書編號 無歷史資料
                this.lblOldContNo.Text = "0";
                this.lblOldContMessage.Text = "(無歷史資料, 此為新合約)";

                // 給空白合約書: 合約書細節 & 廣告聯落人 之初始預設值
                InitialContDetails();
                InitialContContactor();

                // 告知 發票廠商收件人 & 雜誌收件人 並無初始資料
                this.lblfgNew.Text = "0";
                this.lblIMMessage.Text = "(無初始資料, 請自行新增)";
                this.lblORMessage.Text = "(無初始資料, 請自行新增)";

                // 設 雜誌收件人-有登本數 & 未登本數 之初始值
                this.lblORPunCnt.Text = "0";
                this.lblORUnPubCnt.Text = "0";
            }
            BindGrid1();
            BindGrid2();
        }
    }
}
