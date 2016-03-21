using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace mclpub.Contract
{
    public partial class ContShowDetail : System.Web.UI.Page
    {
        ContShowDetail_DB myCont = new ContShowDetail_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Response.Write("cust_custno='" + Request.QueryString["cust_custno"].ToString() + "',cont_contno='" + Request.QueryString["cont_contno"].ToString() + "'");
                // 隱藏所有的 輸入欄位, 不允許修改
                DisabledAll();
                // 抓出 廠商及客戶資料 區之資料, 藉由前一網頁傳來的變數值字串 custno
                GetMfrCust();
                // 抓出網頁初始值, 如動態下拉式選單 (由DB來), 系統日期等 - 主要為 合約書基本資料區
                InitialData();

                // 顯示 合約書編號
                if (Context.Request.QueryString["cont_contno"].ToString().Trim() != "" || Context.Request.QueryString["cont_contno"].ToString().Trim() != null)
                {
                    this.lblContNo.Text = Context.Request.QueryString["cont_contno"].ToString().Trim();
                }
                // 載入舊有合約資料: 合約書細節 & 廣告聯落人 之初始預設值
                LoadOldCont();

                // 載入 發票廠商收件人 & 雜誌收件人 之歷史資料 (依據 old_contno)
                BindGrid1();
                BindGrid2();


                if (Context.Request.QueryString["dpplane"].ToString() == "true")
                {
                    Panel1.Visible = true;
                    // 載入落版資料
                    BindList2();
                    btnPrintWin2.Visible = true;
                }
                else
                {
                    Panel1.Visible = false;
                    btnPrintWin2.Visible = false;
                }
            }
        }

        private void DisabledAll()
        {
            // 合約書基本資料 區 
            this.tbxSignDate.Enabled = false;
            this.ddlContType.Enabled = false;
            this.ddlBookCode.Enabled = false;
            this.tbxStartDate.Enabled = false;
            this.tbxEndDate.Enabled = false;
            this.ddlEmpNo.Enabled = false;
            this.rblfgPayOnce.Enabled = false;
            this.rblfgClosed.Enabled = false;
            this.ddlModEmpNo.Enabled = false;
            this.rblfgCancel.Enabled = false;
            //this.lblOldContNo.Enabled = false;
            //this.lblCreateDate.Enabled = false;
            //this.lblModifyDate.Enabled = false;

            // 合約書細節 區
            this.tbxTotalJTime.Enabled = false;
            this.tbxMadeJTime.Enabled = false;
            this.tbxRestJTime.Enabled = false;
            this.tbxTotalTime.Enabled = false;
            this.tbxPubTime.Enabled = false;
            this.tbxRestTime.Enabled = false;
            this.tbxTotalAmt.Enabled = false;
            this.tbxPaidAmt.Enabled = false;
            this.tbxRestAmt.Enabled = false;
            this.tbxChangeJTime.Enabled = false;
            this.tbxFreeTime.Enabled = false;
            this.tbxADAmt.Enabled = false;
            this.tbxDiscount.Enabled = false;
            this.tbxFreeBookCount.Enabled = false;
            this.tbxPubAdAmt.Enabled = false;
            this.tbxPubChangeAmt.Enabled = false;
            this.tbxColorTime.Enabled = false;
            this.tbxGetColorTime.Enabled = false;
            this.tbxMenoTime.Enabled = false;
            this.tbxRestClrtm.Enabled = false;
            this.tbxRestGetClrtm.Enabled = false;
            this.tbxRestMenotm.Enabled = false;

            // 廣告聯絡人 區
            this.tbxAuName.Enabled = false;
            this.tbxAuTel.Enabled = false;
            this.tbxAuFax.Enabled = false;
            this.tbxAuCell.Enabled = false;
            this.tbxAuEmail.Enabled = false;

            // 備註 區 - tarContRemark (Html Control) 已使用 disable 屬性 Disable 了
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

                DataTable dt = myCont.SelecAllValue(custno);


                // 若有資料, 則顯示相關資料; 否則給予錯誤訊息
                if (dt.Rows.Count > 0)
                {
                    // 藉由前一網頁傳來的變數值字串 custno
                    this.lblCustName.Text = dt.Rows[0]["cust_nm"].ToString().Trim();

                    ///抓出該客戶之廠商統編 mfrno (藉 cust_mfrno)
                    string mfrno = dt.Rows[0]["cust_mfrno"].ToString().Trim();
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
                        if (dt.Rows[0]["mfr_inm"].ToString().Trim() != "")
                            this.lblMfrIName.Text = dt.Rows[0]["mfr_inm"].ToString().Trim();
                        else
                            this.lblMfrIName.Text = "<font color='Gray'>無資料</font>";

                        if (dt.Rows[0]["mfr_respnm"].ToString().Trim() != "")
                            this.lblMfrRespName.Text = dt.Rows[0]["mfr_respnm"].ToString().Trim();
                        else
                            this.lblMfrRespName.Text = "<font color='Gray'>無資料</font>";

                        if (dt.Rows[0]["mfr_respjbti"].ToString().Trim() != "")
                            this.lblMfrRespJobTitle.Text = dt.Rows[0]["mfr_respjbti"].ToString().Trim();
                        else
                            this.lblMfrRespJobTitle.Text = "<font color='Gray'>無資料</font>";

                        if (dt.Rows[0]["mfr_tel"].ToString().Trim() != "")
                            this.lblMfrTel.Text = dt.Rows[0]["mfr_tel"].ToString().Trim();
                        else
                            this.lblMfrTel.Text = "<font color='Gray'>無資料</font>";

                        if (dt.Rows[0]["mfr_fax"].ToString().Trim() != "")
                            this.lblMfrFax.Text = dt.Rows[0]["mfr_fax"].ToString().Trim();
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
            DataTable dtBook = myCont.SelectBooks();
            ddlBookCode.DataSource = dtBook;
            ddlBookCode.DataTextField = "bk_nm";
            //ddlBookCode.DataValueField="nostr";
            // 維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
            ddlBookCode.DataValueField = "bk_bkcd";
            ddlBookCode.DataBind();

            // 顯示下拉式選單 業務員的 DB 值
            // **注意: 原本資料庫內之 srspn_cname & srspn_empno 是 char(x) 型態, 故其 sqlDataAdapter4 裡, 要先做 RTRIM 的處理 (如 RTRIM(srspn_cname) AS srspn_cname), 否則其值會含有空白, 如 '800443 ', '康靜怡     ' .
            DataTable dtSrspn = myCont.SelectSrspn();
            ddlEmpNo.DataSource = dtSrspn;
            ddlEmpNo.DataTextField = "srspn_cname";
            ddlEmpNo.DataValueField = "srspn_empno";
            ddlEmpNo.DataBind();

            // 下段程式在本網頁需要, 故新增之 -- 與 contFm_Add.aspx.cs 處不同處
            // 顯示下拉式選單 修改業務員的 DB 值
            // **注意: 原本資料庫內之 srspn_cname & srspn_empno 是 char(x) 型態, 故其 sqlDataAdapter4 裡, 要先做 RTRIM 的處理 (如 RTRIM(srspn_cname) AS srspn_cname), 否則其值會含有空白, 如 '800443 ', '康靜怡     ' .
            ddlModEmpNo.DataSource = dtSrspn;
            ddlModEmpNo.DataTextField = "srspn_cname";
            ddlModEmpNo.DataValueField = "srspn_empno";
            ddlModEmpNo.DataBind();


            // 下段程式在本網頁並不需要, 故省略之 -- 與 contFm_Add.aspx.cs 處不同處 
            // 抓出登入者的工號, 作為預設 建檔業務員 之值

            // 下段程式在本網頁並不需要, 故省略之 -- 與 contFm_Add.aspx.cs 處不同處
            // 指定並顯示新的 合約書編號

        }


        // 載入舊有合約資料: 合約書細節 & 廣告聯落人 之初始預設值
        private void LoadOldCont()
        {
            // 抓出網頁變數: 客戶編號 
            string strOldContNo = Context.Request.QueryString["cont_contno"].ToString().Trim();
            DataTable dt = myCont.SelectContract(strOldContNo);

            // 若有資料, 則顯示相關資料; 否則給予錯誤訊息
            if (dt.Rows.Count > 0)
            {
                // 下段程式在本網頁需要, 故新增之 -- 與 contFm_Add.aspx.cs 處不同處
                // 合約書基本資料 區
                string SignDate = dt.Rows[0]["cont_signdate"].ToString().Trim();
                SignDate = SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
                this.tbxSignDate.Text = SignDate;
                string conttp = dt.Rows[0]["cont_conttp"].ToString().Trim();
                int intConttpIndex = 0;
                if (conttp == "01")
                    intConttpIndex = 0;
                else
                    intConttpIndex = 1;
                this.ddlContType.SelectedIndex = intConttpIndex;
                this.ddlBookCode.SelectedIndex = Convert.ToInt32(dt.Rows[0]["cont_bkcd"].ToString().Trim()) - 1;
                string StartDate = dt.Rows[0]["cont_sdate"].ToString().Trim();
                //StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
                if (StartDate != "")
                {
                    if (StartDate.Length >= 6)
                        StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
                    else
                    {
                        // 分離 \ 符號以取得數字
                        if (StartDate.IndexOf("\\") != -1)
                        {
                            //StartDate = StartDate.Split('/', 2);
                        }
                        else
                            StartDate = StartDate;
                    }
                }
                else
                {
                    StartDate = StartDate;
                }
                this.tbxStartDate.Text = StartDate;
                string EndDate = dt.Rows[0]["cont_edate"].ToString().Trim();
                //EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
                if (EndDate != "")
                {
                    if (EndDate.Length >= 6)
                        EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
                    else
                    {
                        // 分離 \ 符號以取得數字
                        if (EndDate.IndexOf("\\") != -1)
                        {
                            //EndDate = EndDate.Split('/', 2);
                        }
                        else
                            EndDate = EndDate;
                    }
                }
                else
                {
                    EndDate = EndDate;
                }
                this.tbxEndDate.Text = EndDate;

                // 抓出下拉式選單 業務員之資料
                // 註: 下一行並不能正確顯示其 index, 它只能指向第一個 index (0)
                //this.ddlEmpNo.SelectedItem.Value = dv4[0]["cont_empno"].ToString().Trim();
                this.ddlEmpNo.Items.FindByValue(dt.Rows[0]["cont_empno"].ToString().Trim()).Selected = true;
                // 註: 下一行並不能正確顯示其 index, 且 rblfgPayOnce 的 Selected="True" 要關閉
                //this.rblfgPayOnce.SelectedItem.Value = dv4[0]["cont_fgpayonce"].ToString().Trim();
                if (Convert.ToString(this.rblfgPayOnce.Items.FindByValue(dt.Rows[0]["cont_fgpayonce"].ToString().Trim())) != "")
                    this.rblfgPayOnce.Items.FindByValue(dt.Rows[0]["cont_fgpayonce"].ToString().Trim()).Selected = true;
                //else
                //this.rblfgPayOnce.Items.FindByValue(dv4[0]["cont_fgpayonce"].ToString().Trim()).Selected = false;

                // 下段程式在本網頁需要, 故新增之 -- 與 contFm_Add.aspx.cs 處不同處
                this.rblfgClosed.Items.FindByValue(dt.Rows[0]["cont_fgclosed"].ToString().Trim()).Selected = true;
                this.ddlModEmpNo.Items.FindByValue(dt.Rows[0]["cont_modempno"].ToString().Trim()).Selected = true;
                this.rblfgCancel.Items.FindByValue(dt.Rows[0]["cont_fgcancel"].ToString().Trim()).Selected = true;
                // 顯示 lblOldContMessage 訊息 : 判斷是否為 第一張合約 或 有歷史參考資料
                string OldContNo = dt.Rows[0]["cont_oldcontno"].ToString().Trim();
                if (OldContNo == "0")
                    this.lblOldContMessage.Text = "(無歷史資料, 此為新合約)";
                else
                    this.lblOldContMessage.Text = OldContNo;
                string CreateDate = dt.Rows[0]["cont_credate"].ToString().Trim();
                CreateDate = CreateDate.Substring(0, 4) + "/" + CreateDate.Substring(4, 2) + "/" + CreateDate.Substring(6, 2);
                this.lblCreateDate.Text = CreateDate;
                string ModifyDate = dt.Rows[0]["cont_moddate"].ToString().Trim();
                ModifyDate = ModifyDate.Substring(0, 4) + "/" + ModifyDate.Substring(4, 2) + "/" + ModifyDate.Substring(6, 2);
                this.lblModifyDate.Text = ModifyDate;


                // 合約書細節 區
                this.tbxTotalJTime.Text = dt.Rows[0]["cont_totjtm"].ToString().Trim();
                this.tbxMadeJTime.Text = dt.Rows[0]["cont_madejtm"].ToString().Trim();
                this.tbxRestJTime.Text = dt.Rows[0]["cont_restjtm"].ToString().Trim();
                this.tbxTotalTime.Text = dt.Rows[0]["cont_tottm"].ToString().Trim();
                this.tbxPubTime.Text = dt.Rows[0]["cont_pubtm"].ToString().Trim();
                this.tbxRestTime.Text = dt.Rows[0]["cont_resttm"].ToString().Trim();
                this.tbxTotalAmt.Text = dt.Rows[0]["cont_totamt"].ToString().Trim();
                this.tbxPaidAmt.Text = dt.Rows[0]["cont_paidamt"].ToString().Trim();
                this.tbxRestAmt.Text = dt.Rows[0]["cont_restamt"].ToString().Trim();
                this.tbxChangeJTime.Text = dt.Rows[0]["cont_chgjtm"].ToString().Trim();
                this.tbxFreeTime.Text = dt.Rows[0]["cont_freetm"].ToString().Trim();
                this.tbxADAmt.Text = dt.Rows[0]["cont_adamt"].ToString().Trim();
                this.tbxDiscount.Text = dt.Rows[0]["cont_disc"].ToString().Trim();
                this.tbxFreeBookCount.Text = dt.Rows[0]["cont_freebkcnt"].ToString().Trim();
                this.tbxPubAdAmt.Text = dt.Rows[0]["cont_pubamt"].ToString().Trim();
                this.tbxPubChangeAmt.Text = dt.Rows[0]["cont_chgamt"].ToString().Trim();
                this.tbxColorTime.Text = dt.Rows[0]["cont_clrtm"].ToString().Trim();
                this.tbxGetColorTime.Text = dt.Rows[0]["cont_getclrtm"].ToString().Trim();
                this.tbxMenoTime.Text = dt.Rows[0]["cont_menotm"].ToString().Trim();
                string strfgPubed = dt.Rows[0]["cont_fgpubed"].ToString().Trim();
                this.tbxRestClrtm.Text = dt.Rows[0]["cont_restclrtm"].ToString().Trim();
                this.tbxRestGetClrtm.Text = dt.Rows[0]["cont_restgetclrtm"].ToString().Trim();
                this.tbxRestMenotm.Text = dt.Rows[0]["cont_restmenotm"].ToString().Trim();

                // 廣告聯絡人 區
                this.tbxAuName.Text = dt.Rows[0]["cont_aunm"].ToString().Trim();
                this.tbxAuTel.Text = dt.Rows[0]["cont_autel"].ToString().Trim();
                this.tbxAuFax.Text = dt.Rows[0]["cont_aufax"].ToString().Trim();
                this.tbxAuCell.Text = dt.Rows[0]["cont_aucell"].ToString().Trim();
                this.tbxAuEmail.Text = dt.Rows[0]["cont_auemail"].ToString().Trim();

                // 備註 區 : Html Control 必須 Runat=server, 才能在 aspx.cs 中呼叫使用
                // 且在 .cs 必須自己加註 protected System.Web.UI.HtmlControls.HtmlTextArea tarContRemark;
                if (dt.Rows[0]["cont_remark"].ToString().Trim() != "")
                {
                    //Response.Write("cont_remark= " + dv4[0]["cont_remark"].ToString().Trim() + "<br>");
                    this.tarContRemark.Value = dt.Rows[0]["cont_remark"].ToString().Trim();
                }
            }
        }


        private void BindGrid1()
        {
            string strConto = this.lblContNo.Text.ToString().Trim();
            DataTable dt = myCont.Selectinvmfr(strConto);

            // 若有歷史資料, 則載入資料	
            if (dt.Rows.Count > 0)
            {
                // 顯示其相關資料
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }

        }

        protected void GridView1OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
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


        private void BindGrid2()
        {
            // 抓出 篩選條件
            string strConto = this.lblContNo.Text.ToString().Trim();
            DataTable dt = myCont.Selectc2_or(strConto);

            // 若有歷史資料, 則載入資料	
            if (dt.Rows.Count > 0)
            {
                // 顯示其相關資料
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }

            int PubCount = 0;
            int UnPubCount = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PubCount += int.Parse(dt.Rows[i]["or_pubcnt"].ToString().Trim());
                UnPubCount += int.Parse(dt.Rows[i]["or_unpubcnt"].ToString().Trim());
            }

            // 顯示 總計：有登本數 & 未登本數
            //Response.Write("Toal PubCount= " + PubCount + "<br>");
            //Response.Write("Toal UnPubCount= " + UnPubCount + "<br>");
            this.lblORPunCnt.Text = Convert.ToString(PubCount);
            this.lblORUnPubCnt.Text = Convert.ToString(UnPubCount);

        }


        protected void GridView2OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                    // 發票類別代碼
                    string mtpcd =e.Row.Cells[12].Text.Trim();
                    DataTable dt = myCont.Selectmtp(mtpcd);

                    if (dt.Rows.Count > 0)
                    {
                        // 抓出 郵寄類別相關資料
                        string mtpnm = dt.Rows[0]["mtp_nm"].ToString().Trim();
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

                    // 抓出 各行 有登本數 & 未登本數 之加總值

            }

        }



        // 載入 發票廠商收件人資料
        private void BindList2()
        {
            string strContNo = this.lblContNo.Text.ToString().Trim();


            // 抓出符合條件的對應落版資料
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds8 = myCont.SelectC2_pub();
            DataView dv8 = ds8.Tables["c2_pub"].DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            string rowfilterst8 = " 1=1 ";
            rowfilterst8 = rowfilterst8 + " AND (pub_syscd ='C2') ";
            rowfilterst8 = rowfilterst8 + " AND (pub_contno ='" + strContNo + "') ";
            dv8.RowFilter = rowfilterst8;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv8.Count= "+ dv8.Count + "<BR>");
            //Response.Write("dv8.RowFilter= " + dv8.RowFilter + "<BR><BR>");

            // 若有資料, 則顯示相關資料; 否則給予錯誤訊息
            if (dv8.Count > 0)
            {
                DataList2.DataSource = dv8;
                DataList2.DataBind();

                //Response.Write("DataList2.Items.Count= " + DataList2.Items.Count + "<br>");
                //Response.Write("DataList2.Controls.Count= " + DataList2.Controls.Count + "<br>");
                // 特別欄位之輸出格式轉換 - 變更發票類別等的格式
                for (int i = 0; i < DataList2.Items.Count; i++)
                {
                    // 刊登年月
                    string yyyymm = ((Label)DataList2.Items[i].FindControl("lblYYYYMM")).Text.ToString().Trim();
                    //Response.Write("yyyymm = " + yyyymm + "<br>");
                    int intyyyymm = int.Parse(yyyymm);
                    if (intyyyymm >= 6)
                        yyyymm = yyyymm.Substring(0, 4) + "/" + yyyymm.Substring(4, 2);
                    else
                        yyyymm = yyyymm;
                    ((Label)DataList2.Items[i].FindControl("lblYYYYMM")).Text = yyyymm;

                    // 固定頁次註記
                    string fgfixpg = ((Label)DataList2.Items[i].FindControl("lblfgFixPg")).Text.ToString().Trim();
                    //Response.Write("fgfixpg = " + fgfixpg + "<br>");
                    if (fgfixpg == "0")
                        ((Label)DataList2.Items[i].FindControl("lblfgFixPg")).Text = "否";
                    else
                        ((Label)DataList2.Items[i].FindControl("lblfgFixPg")).Text = "<font color='Red'>是</font>";

                    // 修改日期
                    string ModifyDate = ((Label)DataList2.Items[i].FindControl("lblModifyDate")).Text.ToString().Trim();
                    //Response.Write("ModifyDate = " + ModifyDate + "<br>");
                    int intModifyDate = int.Parse(ModifyDate);
                    if (intModifyDate >= 8)
                        ModifyDate = ModifyDate.Substring(0, 4) + "/" + ModifyDate.Substring(4, 2) + "/" + ModifyDate.Substring(6, 2);
                    else
                        ModifyDate = ModifyDate;
                    ((Label)DataList2.Items[i].FindControl("lblModifyDate")).Text = ModifyDate;

                    // 已開立發票開立單註記
                    string fginved = ((Label)DataList2.Items[i].FindControl("lblfgInved")).Text.ToString().Trim();
                    //Response.Write("fginved = " + fginved + "<br>");
                    if (fginved == "")
                        ((Label)DataList2.Items[i].FindControl("lblfgInved")).Text = "<font color='Red'>否</font>";
                    if (fginved == "v")
                        ((Label)DataList2.Items[i].FindControl("lblfgInved")).Text = "<font color='Blue'>已挑未開</font>";
                    if (fginved == "1")
                        ((Label)DataList2.Items[i].FindControl("lblfgInved")).Text = "已開立";

                    // 發票開立單人工處理註記
                    string fginvself = ((Label)DataList2.Items[i].FindControl("lblfgInvSelf")).Text.ToString().Trim();
                    //Response.Write("fginvself = " + fginvself + "<br>");
                    if (fginvself == "0")
                        ((Label)DataList2.Items[i].FindControl("lblfgInvSelf")).Text = "否";
                    else
                        ((Label)DataList2.Items[i].FindControl("lblfgInvSelf")).Text = "<font color='Red'>是</font>";

                    // 稿件類別
                    string drafttp = ((Label)DataList2.Items[i].FindControl("lblDrafttp")).Text.ToString().Trim();
                    //Response.Write("drafttp = " + drafttp + "<br>");
                    switch (drafttp)
                    {
                        case "1":
                            ((Label)DataList2.Items[i].FindControl("lblDrafttp")).Text = "舊稿";

                            // 到稿註記
                            ((Label)DataList2.Items[i].FindControl("lblfgGot")).Text = "";

                            // 改稿相關資料
                            ((Label)DataList2.Items[i].FindControl("lblChgbkcd")).Text = "";
                            ((Label)DataList2.Items[i].FindControl("lblChgJNo")).Text = "";
                            ((Label)DataList2.Items[i].FindControl("lblChgJbkno")).Text = "";
                            ((Label)DataList2.Items[i].FindControl("lblfgReChg")).Text = "";

                            // 新稿相關資料
                            ((Label)DataList2.Items[i].FindControl("lblfgNjtpcd")).Text = "";
                            break;

                        case "2":
                            ((Label)DataList2.Items[i].FindControl("lblDrafttp")).Text = "新稿";

                            // 到稿註記
                            string fggot1 = ((Label)DataList2.Items[i].FindControl("lblfgGot")).Text.ToString().Trim();
                            //Response.Write("fggot1 = " + fggot1 + "<br>");
                            if (fggot1 == "0")
                                ((Label)DataList2.Items[i].FindControl("lblfgGot")).Text = "<font color='Red'>否</font>";
                            else
                                ((Label)DataList2.Items[i].FindControl("lblfgGot")).Text = "是";

                            // 舊稿相關資料
                            ((Label)DataList2.Items[i].FindControl("lblOrigBkcd")).Text = "";
                            ((Label)DataList2.Items[i].FindControl("lblOrigJNo")).Text = "";
                            ((Label)DataList2.Items[i].FindControl("lblOrigJbkno")).Text = "";

                            // 改稿相關資料
                            ((Label)DataList2.Items[i].FindControl("lblChgbkcd")).Text = "";
                            ((Label)DataList2.Items[i].FindControl("lblChgJNo")).Text = "";
                            ((Label)DataList2.Items[i].FindControl("lblChgJbkno")).Text = "";
                            ((Label)DataList2.Items[i].FindControl("lblfgReChg")).Text = "";
                            break;

                        case "3":
                            ((Label)DataList2.Items[i].FindControl("lblDrafttp")).Text = "改稿";

                            // 到稿註記
                            string fggot2 = ((Label)DataList2.Items[i].FindControl("lblfgGot")).Text.ToString().Trim();
                            //Response.Write("fggot2 = " + fggot2 + "<br>");
                            if (fggot2 == "0")
                                ((Label)DataList2.Items[i].FindControl("lblfgGot")).Text = "<font color='Red'>否</font>";
                            else
                                ((Label)DataList2.Items[i].FindControl("lblfgGot")).Text = "是";

                            // 改稿書類
                            string chgbkcd = ((Label)DataList2.Items[i].FindControl("lblChgbkcd")).Text.ToString().Trim();
                            //Response.Write("chgbkcd = " + chgbkcd + "<br>");
                            switch (chgbkcd)
                            {
                                case "  ":
                                    ((Label)DataList2.Items[i].FindControl("lblChgbkcd")).Text = "";
                                    break;
                                case "01":
                                    ((Label)DataList2.Items[i].FindControl("lblChgbkcd")).Text = "工材雜誌";
                                    break;
                                case "02":
                                    ((Label)DataList2.Items[i].FindControl("lblChgbkcd")).Text = "電材雜誌";
                                    break;
                                default:
                                    ((Label)DataList2.Items[i].FindControl("lblChgbkcd")).Text = "工材雜誌";
                                    break;
                            }

                            // 改稿重出片註記
                            string fgrechg = ((Label)DataList2.Items[i].FindControl("lblfgReChg")).Text.ToString().Trim();
                            //Response.Write("fgrechg = " + fgrechg + "<br>");
                            if (fgrechg == "0")
                                ((Label)DataList2.Items[i].FindControl("lblfgReChg")).Text = "<font color='Red'>否</font>";
                            else
                                ((Label)DataList2.Items[i].FindControl("lblfgReChg")).Text = "是";

                            // 舊稿相關資料
                            ((Label)DataList2.Items[i].FindControl("lblOrigBkcd")).Text = "";
                            ((Label)DataList2.Items[i].FindControl("lblOrigJNo")).Text = "";
                            ((Label)DataList2.Items[i].FindControl("lblOrigJbkno")).Text = "";

                            // 新稿相關資料
                            ((Label)DataList2.Items[i].FindControl("lblfgNjtpcd")).Text = "";
                            break;

                        default:
                            ((Label)DataList2.Items[i].FindControl("lblDrafttp")).Text = "舊稿";

                            // 到稿註記
                            ((Label)DataList2.Items[i].FindControl("lblfgGot")).Text = "";

                            // 改稿相關資料
                            ((Label)DataList2.Items[i].FindControl("lblChgbkcd")).Text = "";
                            ((Label)DataList2.Items[i].FindControl("lblChgJNo")).Text = "";
                            ((Label)DataList2.Items[i].FindControl("lblChgJbkno")).Text = "";
                            ((Label)DataList2.Items[i].FindControl("lblfgReChg")).Text = "";

                            // 新稿相關資料
                            ((Label)DataList2.Items[i].FindControl("lblfgNjtpcd")).Text = "";
                            break;
                    }
                    // 	結束 for loop
                }
                // 結束 if(dv8.Count > 0)
            }
            else
            {
                this.lblPubMessage.Text = "查無落版資料~";
            }

        }

        protected void btnPrintWin2_Click(object sender, EventArgs e)
        {
            this.Page.Controls.Add(new LiteralControl("<script>window.print();</script>"));
        }
    }
}
