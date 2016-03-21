using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace mclpub.Contract
{
    public partial class PlaneCont2Edit : System.Web.UI.Page
    {
        PlaneCont2Edit_DB myPlane = new PlaneCont2Edit_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            imbIMRefresh.Attributes.Add("style", "display:none");
            imbORRefresh.Attributes.Add("style", "display:none");

            if (!IsPostBack)
            {
                // 抓出 廠商及客戶資料 區之資料, 藉由前一網頁傳來的變數值字串 custno
                GetMfrCust();

                // 抓出網頁初始值, 如動態下拉式選單 (由DB來), 系統日期等 - 主要為 合約書基本資料區
                InitialData();

                if (Context.Request.QueryString["cont_contno"].ToString().Trim() != "0")
                {
                    this.lblContNo.Text = Context.Request.QueryString["cont_contno"].ToString().Trim();
                    //this.lblfgNew.Text = "1";
                }

                LoadOldCont();
            }

            BindGrid1();
            BindGrid2();
        }

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

                DataTable dt = myPlane.SelectCust(custno);

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


        // 抓出網頁初始值, 如動態下拉式選單 (由DB來), 系統日期等 - 主要為 合約書基本資料區
        private void InitialData()
        {
            // 合約書基本資料 區

            //			// 顯示 簽約日期及合約起迄日 之預設值: 抓系統日期之值
            //			// 顯示 合約迄日 之預設: 系統年月 + 加 11個月
            //			this.tbxSignDate.Text = System.DateTime.Today.ToString("yyyy/MM/dd").Trim();
            //			this.tbxStartDate.Text = System.DateTime.Today.ToString("yyyy/MM").Trim();
            //			//tbxEndDate.Value=System.DateTime.Today.AddDays(364).ToString("yyyy/MM");
            //			this.tbxEndDate.Text = System.DateTime.Today.AddMonths(11).ToString("yyyy/MM").Trim();

            // 最後修改日期之預設值
            //Response.Write("tbxStartDate.Value= " + tbxStartDate.Value + "<br>");
            //Response.Write("hiddenModDate.Value= " + hiddenModDate.Value + "<br>");

            // 顯示下拉式選單 書籍類別的 DB 值
            // 關於 nostr, 請參 sqlDataAdapter2.Select statement;
            // nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
            DataTable dtBook = myPlane.SelectBook();
            DataView dv2 = dtBook.DefaultView;
            ddlBookCode.DataSource = dv2;
            dv2.RowFilter = "proj_fgitri=''";
            ddlBookCode.DataTextField = "bk_nm";
            //ddlBookCode.DataValueField="nostr";
            // 維護畫面: ddl值由 nostr 改為 bk_bkcd, 才能使中抓到 書籍類別, 否則其 option 值為 nostr, 而非 bk_bkcd
            ddlBookCode.DataValueField = "bk_bkcd";
            ddlBookCode.DataBind();

            // 顯示下拉式選單 業務員的 DB 值
            // **注意: 原本資料庫內之 srspn_cname & srspn_empno 是 char(x) 型態, 故其 sqlDataAdapter4 裡, 要先做 RTRIM 的處理 (如 RTRIM(srspn_cname) AS srspn_cname), 否則其值會含有空白, 如 '800443 ', '康靜怡     ' .
            DataTable dtSrspn = myPlane.SelectSrspn();
            ddlEmpNo.DataSource = dtSrspn;
            ddlEmpNo.DataTextField = "srspn_cname";
            ddlEmpNo.DataValueField = "srspn_empno";
            ddlEmpNo.DataBind();

            // 下段程式在本網頁需要, 故新增之 -- 與 contFm_Add.aspx.cs 處不同處; 與 contFm_show.aspx.cs 相同
            // 顯示下拉式選單 修改業務員的 DB 值
            // **注意: 原本資料庫內之 srspn_cname & srspn_empno 是 char(x) 型態, 故其 sqlDataAdapter4 裡, 要先做 RTRIM 的處理 (如 RTRIM(srspn_cname) AS srspn_cname), 否則其值會含有空白, 如 '800443 ', '康靜怡     ' .
            ddlModEmpNo.ClearSelection();
            ddlModEmpNo.DataSource = dtSrspn;
            ddlModEmpNo.DataTextField = "srspn_cname";
            ddlModEmpNo.DataValueField = "srspn_empno";
            ddlModEmpNo.DataBind();
            // 將 修改業務員 disable
            this.ddlModEmpNo.Enabled = false;


            // 下段程式在本網頁並不需要, 故省略之 -- 與 contFm_show.aspx.cs 處不同處
            // 抓出登入者的工號, 作為預設 修改業務員 之值
            string LoginEmpNo = "";
            //Response.Write("empid= " + User.Identity.Name.Substring(User.Identity.Name.LastIndexOf("\\")+1) + "<br>");
            // 若有登入者的資料, 則抓出並預選 修改業務員之下拉式選單
            // 注意下段 if 可能與 line 413 相衝 -- this.ddlModEmpNo.Items.FindByValue(dv4[0]["cont_modempno"].ToString().Trim()).Selected = true;
            ddlModEmpNo.ClearSelection();
            //Response.Write(Account.GetAccInfo().srspn_empno.ToString());
            if (Account.GetAccInfo().srspn_empno.ToString() != "")
            {
                LoginEmpNo = Account.GetAccInfo().srspn_empno.ToString().Trim();
                string empno = "800443";
                for (int i = 0; i < this.ddlModEmpNo.Items.Count; i++)
                {
                    //    //Response.Write("ddlEmpNo(" + i + ").Value= " + this.ddlEmpNo.Items[i].Value + "<br>");
                    //    // 若下拉式選單的值 為 登入者工號, 則下拉式選單預選之; 否則為 康靜怡 (800443)
                    if (this.ddlModEmpNo.Items[i].Value.Trim() == LoginEmpNo)
                    {
                        empno = ddlModEmpNo.Items[i].Value.ToString().Trim();
                    }
                }

                ddlModEmpNo.SelectedValue = empno;

            }
            // 若無登入者的資料, 則抓出並預選 修改業務員為 康靜怡 (800443)
            //else
            //{
            //    //LoginEmpNo = User.Identity.Name.Substring(5, 6).ToString().Trim();
            //    //Response.Write("User.Identity.Name= " + User.Identity.Name.ToString().Trim() + "<br>");
            //    LoginEmpNo = "800443";
            //    this.ddlModEmpNo.Items.FindByValue("800443").Selected = true;
            //}

            // 下段程式在本網頁並不需要, 故省略之 -- 與 contFm_Add.aspx.cs 處不同處
            // 指定並顯示新的 合約書編號


            // 隱藏 維護落版資料 按鈕及相關資訊
            this.btnGoPub.Visible = false;
            this.lblfgPubed.Visible = false;
            this.lblpubfgnew.Visible = false;
        }


        // 載入舊有合約資料: 合約書細節 & 廣告聯落人 之初始預設值
        private void LoadOldCont()
        {
            // 抓出網頁變數: 客戶編號
            string strContNo = Context.Request.QueryString["cont_contno"].ToString().Trim();
            //Response.Write("strContNo= "+ strContNo + "<BR>");
            DataTable dtC2 = myPlane.SelectC2_cont();
            DataView dv4 = dtC2.DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            string rowfilterstr4 = "1=1";
            rowfilterstr4 = rowfilterstr4 + " AND cont_contno='" + strContNo + "'";
            dv4.RowFilter = rowfilterstr4;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
            //Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

            // 若有資料, 則顯示相關資料; 否則給予錯誤訊息
            if (dv4.Count > 0)
            {
                // 下段程式在本網頁需要, 故新增之 -- 與 contFm_Add.aspx.cs 處不同處
                // 合約書基本資料 區
                string SignDate = dv4[0]["cont_signdate"].ToString().Trim();
                //SignDate = SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
                if (SignDate != "")
                {
                    if (SignDate.Length >= 7)
                        SignDate = SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
                    else
                    {
                        // 分離 \ 符號以取得數字
                        if (SignDate.IndexOf("\\") != -1)
                        {
                            //SignDate = SignDate.Split('/', 2);
                        }
                        else
                            SignDate = SignDate;
                    }
                }
                else
                {
                    SignDate = SignDate;
                }
                this.tbxSignDate.Text = SignDate;
                string conttp = dv4[0]["cont_conttp"].ToString().Trim();
                int intConttpIndex = 0;
                if (conttp == "01")
                    intConttpIndex = 0;
                else
                    intConttpIndex = 1;
                this.ddlContType.SelectedIndex = intConttpIndex;
                this.ddlBookCode.SelectedIndex = Convert.ToInt32(dv4[0]["cont_bkcd"].ToString().Trim()) - 1;
                string StartDate = dv4[0]["cont_sdate"].ToString().Trim();
                //StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
                if (StartDate != "")
                {
                    if (StartDate.Length >= 6)
                        StartDate = StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
                    else
                    {
                        StartDate = StartDate;

                        // 以 Javascript 的 window.close() 來告知訊息
                        LiteralControl litAlert1 = new LiteralControl();
                        litAlert1.Text = "<script language=javascript>alert(\"注意：合約起日不符合規則 'yyyy/mm'.\");</script>";
                        Page.Controls.Add(litAlert1);
                    }
                }
                else
                {
                    StartDate = StartDate;
                }
                this.tbxStartDate.Text = StartDate;
                string EndDate = dv4[0]["cont_edate"].ToString().Trim();
                //EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
                if (EndDate != "")
                {
                    if (EndDate.Length >= 6)
                        EndDate = EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
                    else
                    {
                        EndDate = EndDate;

                        // 以 Javascript 的 window.close() 來告知訊息
                        LiteralControl litAlert1 = new LiteralControl();
                        litAlert1.Text = "<script language=javascript>alert(\"注意：合約迄日不符合規則 'yyyy/mm'.\");</script>";
                        Page.Controls.Add(litAlert1);
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
                this.ddlEmpNo.Items.FindByValue(dv4[0]["cont_empno"].ToString().Trim()).Selected = true;
                // 註: 下一行並不能正確顯示其 index, 且 rblfgPayOnce 的 Selected="True" 要關閉
                //this.rblfgPayOnce.SelectedItem.Value = dv4[0]["cont_fgpayonce"].ToString().Trim();
                if (Convert.ToString(this.rblfgPayOnce.Items.FindByValue(dv4[0]["cont_fgpayonce"].ToString().Trim())) != "")
                    this.rblfgPayOnce.Items.FindByValue(dv4[0]["cont_fgpayonce"].ToString().Trim()).Selected = true;
                //else
                //this.rblfgPayOnce.Items.FindByValue(dv4[0]["cont_fgpayonce"].ToString().Trim()).Selected = false;

                // 下段程式在本網頁需要, 故新增之 -- 與 contFm_Add.aspx.cs 處不同處
                this.rblfgClosed.Items.FindByValue(dv4[0]["cont_fgclosed"].ToString().Trim()).Selected = true;
                //this.ddlModEmpNo.Items.FindByValue(dv4[0]["cont_modempno"].ToString().Trim()).Selected = true;
                this.rblfgCancel.Items.FindByValue(dv4[0]["cont_fgcancel"].ToString().Trim()).Selected = true;

                // 顯示 lblOldContMessage 訊息 : 判斷是否為 第一張合約 或 有歷史參考資料
                string OldContNo = dv4[0]["cont_oldcontno"].ToString().Trim();
                //Response.Write("OldContNo= " + OldContNo + "<br>");
                // 告知 oldcontno 訊息, 並檢查告知 發票廠商收件人 & 雜誌收件人 是否已輸入資料
                if (OldContNo == "0")
                {
                    this.lblOldContNo.Visible = false;
                    this.lblOldContNo.Text = "0";
                    this.lblOldContMessage.Text = "(無歷史資料, 此為新合約)";

                    // 告知 發票廠商收件人 & 雜誌收件人 並無初始資料
                    this.lblfgNew.Text = "0";
                    //this.lblIMMessage.Text = "(無初始資料, 請自行新增)";
                    //this.lblORMessage.Text = "(無初始資料, 請自行新增)";
                }
                else
                {
                    OldContNo = dv4[0]["cont_oldcontno"].ToString().Trim();
                    this.lblOldContNo.Visible = true;
                    this.lblOldContNo.Text = OldContNo;
                    this.lblOldContMessage.Text = "(有歷史資料)";

                    // 告知 發票廠商收件人 & 雜誌收件人 並有歷史資料
                    this.lblfgNew.Text = "1";
                    //this.lblIMMessage.Text = "(有歷史資料)";
                    //this.lblORMessage.Text = "(有歷史資料)";
                }
                // 檢查告知 發票廠商收件人 & 雜誌收件人 是否已輸入資料
                CheckIMORExist();

                string CreateDate = dv4[0]["cont_credate"].ToString().Trim();
                //CreateDate = CreateDate.Substring(0, 4) + "/" + CreateDate.Substring(4, 2) + "/" + CreateDate.Substring(6, 2);
                if (CreateDate != "")
                {
                    if (CreateDate.Length >= 7)
                        CreateDate = CreateDate.Substring(0, 4) + "/" + CreateDate.Substring(4, 2) + "/" + CreateDate.Substring(6, 2);
                    else
                    {
                        // 分離 \ 符號以取得數字
                        if (CreateDate.IndexOf("\\") != -1)
                        {
                            //CreateDate = CreateDate.Split('/', 2);
                        }
                        else
                            CreateDate = CreateDate;
                    }
                }
                else
                {
                    CreateDate = CreateDate;
                }
                this.lblCreateDate.Text = CreateDate;
                string ModifyDate = dv4[0]["cont_moddate"].ToString().Trim();
                //ModifyDate = ModifyDate.Substring(0, 4) + "/" + ModifyDate.Substring(4, 2) + "/" + ModifyDate.Substring(6, 2);
                if (ModifyDate != "")
                {
                    if (ModifyDate.Length >= 7)
                        ModifyDate = ModifyDate.Substring(0, 4) + "/" + ModifyDate.Substring(4, 2) + "/" + ModifyDate.Substring(6, 2);
                    else
                    {
                        // 分離 \ 符號以取得數字
                        if (ModifyDate.IndexOf("\\") != -1)
                        {
                            //ModifyDate = ModifyDate.Split('/', 2);
                        }
                        else
                            ModifyDate = ModifyDate;
                    }
                }
                else
                {
                    ModifyDate = ModifyDate;
                }
                this.lblModifyDate.Text = ModifyDate;


                // 合約書細節 區
                this.tbxTotalJTime.Text = dv4[0]["cont_totjtm"].ToString().Trim();
                this.tbxMadeJTime.Text = dv4[0]["cont_madejtm"].ToString().Trim();
                this.tbxRestJTime.Text = dv4[0]["cont_restjtm"].ToString().Trim();
                this.tbxTotalTime.Text = dv4[0]["cont_tottm"].ToString().Trim();
                this.tbxPubTime.Text = dv4[0]["cont_pubtm"].ToString().Trim();
                this.tbxRestTime.Text = dv4[0]["cont_resttm"].ToString().Trim();
                this.tbxTotalAmt.Text = dv4[0]["cont_totamt"].ToString().Trim();
                this.tbxPaidAmt.Text = dv4[0]["cont_paidamt"].ToString().Trim();
                this.tbxRestAmt.Text = dv4[0]["cont_restamt"].ToString().Trim();
                this.tbxChangeJTime.Text = dv4[0]["cont_chgjtm"].ToString().Trim();
                this.tbxFreeTime.Text = dv4[0]["cont_freetm"].ToString().Trim();
                this.tbxADAmt.Text = dv4[0]["cont_adamt"].ToString().Trim();
                this.tbxDiscount.Text = dv4[0]["cont_disc"].ToString().Trim();
                this.tbxFreeBookCount.Text = dv4[0]["cont_freebkcnt"].ToString().Trim();
                this.tbxPubAdAmt.Text = dv4[0]["cont_pubamt"].ToString().Trim();
                this.tbxPubChangeAmt.Text = dv4[0]["cont_chgamt"].ToString().Trim();
                this.tbxColorTime.Text = dv4[0]["cont_clrtm"].ToString().Trim();
                this.tbxGetColorTime.Text = dv4[0]["cont_getclrtm"].ToString().Trim();
                this.tbxMenoTime.Text = dv4[0]["cont_menotm"].ToString().Trim();
                string strfgPubed = dv4[0]["cont_fgpubed"].ToString().Trim();
                this.tbxRestClrtm.Text = dv4[0]["cont_restclrtm"].ToString().Trim();
                this.tbxRestGetClrtm.Text = dv4[0]["cont_restgetclrtm"].ToString().Trim();
                this.tbxRestMenotm.Text = dv4[0]["cont_restmenotm"].ToString().Trim();

                // 廣告聯絡人 區
                this.tbxAuName.Text = dv4[0]["cont_aunm"].ToString().Trim();
                this.tbxAuTel.Text = dv4[0]["cont_autel"].ToString().Trim();
                this.tbxAuFax.Text = dv4[0]["cont_aufax"].ToString().Trim();
                this.tbxAuCell.Text = dv4[0]["cont_aucell"].ToString().Trim();
                this.tbxAuEmail.Text = dv4[0]["cont_auemail"].ToString().Trim();

                // 備註 區
                this.tarContRemark.Value = dv4[0]["cont_remark"].ToString().Trim();


                // 維護落版資料 按鈕區
                // 若該合約已落版 (cont_fgpubed=1), 則 lblpubfgnew = 1 (好方便 btn 轉址)
                string fgpubed = dv4[0]["cont_fgpubed"].ToString().Trim();
                string fgnew = "";
                this.lblfgPubed.Text = fgpubed;
                if (fgpubed == "0")
                {
                    fgnew = "0";
                    this.lblpubfgnew.Text = fgnew;
                    this.btnGoPub.Visible = false;
                }
                else
                {
                    fgnew = "1";
                    this.lblpubfgnew.Text = fgnew;
                    this.btnGoPub.Visible = true;
                }
            }
        }


        // 檢查告知 發票廠商收件人 & 雜誌收件人 是否已輸入資料
        private void CheckIMORExist()
        {
            // 抓出 篩選條件
            string strsyscd = "C2";
            string strConto = this.lblContNo.Text.ToString().Trim();

            DataTable dtinvmfr = myPlane.SelectInvmfr();
            DataView dv5 = dtinvmfr.DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr5 = "1=1";
            rowfilterstr5 = rowfilterstr5 + " AND im_syscd='" + strsyscd + "'";
            rowfilterstr5 = rowfilterstr5 + " AND im_contno='" + strConto + "'";
            dv5.RowFilter = rowfilterstr5;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
            //Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

            // 若有歷史資料, 則載入資料
            if (dv5.Count > 0)
            {
                this.lblIMMessage.Text = "已有資料";
            }
            else
            {
                this.lblIMMessage.Text = "(暫無資料)";
            }


            // 檢查告知 雜誌收件人 是否已輸入資料
            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataTable dtC2_or = myPlane.SelectC2_or();
            DataView dv6 = dtC2_or.DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr6 = "1=1";
            rowfilterstr6 = rowfilterstr6 + " AND or_syscd='" + strsyscd + "'";
            rowfilterstr6 = rowfilterstr6 + " AND or_contno='" + strConto + "'";
            dv6.RowFilter = rowfilterstr6;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
            //Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");

            // 若有歷史資料, 則載入資料
            if (dv6.Count > 0)
            {
                this.lblORMessage.Text = "已有資料";
            }
            else
            {
                this.lblORMessage.Text = "(暫無資料)";
            }
        }


        // 載入 發票廠商收件人資料
        private void BindGrid1()
        {
            // 抓出 篩選條件
            string strsyscd = "C2";
            string strConto = this.lblContNo.Text.ToString().Trim();


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataTable dtinvmfr = myPlane.SelectInvmfr();
            DataView dv5 = dtinvmfr.DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr5 = "1=1";
            rowfilterstr5 = rowfilterstr5 + " AND im_syscd='" + strsyscd + "'";
            rowfilterstr5 = rowfilterstr5 + " AND im_contno='" + strConto + "'";
            dv5.RowFilter = rowfilterstr5;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv5.Count= "+ dv5.Count + "<BR>");
            //Response.Write("dv5.RowFilter= " + dv5.RowFilter + "<BR>");

            GridView1.DataSource = dv5;
            GridView1.DataBind();


        }

        protected void GridView1OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                int i;
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


        // 載入 發票廠商收件人資料
        private void BindGrid2()
        {
            // 抓出 篩選條件
            string strsyscd = "C2";
            string strConto = this.lblContNo.Text.ToString().Trim();


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataTable dt = myPlane.SelectC2_or();
            DataView dv6 = dt.DefaultView;

            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
            string rowfilterstr6 = "1=1";
            rowfilterstr6 = rowfilterstr6 + " AND or_syscd='" + strsyscd + "'";
            rowfilterstr6 = rowfilterstr6 + " AND or_contno='" + strConto + "'";
            dv6.RowFilter = rowfilterstr6;

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv6.Count= "+ dv6.Count + "<BR>");
            //Response.Write("dv6.RowFilter= " + dv6.RowFilter + "<BR>");

            // 顯示其相關資料
            GridView2.DataSource = dv6;
            GridView2.DataBind();


            // 顯示 總計：有登本數 & 未登本數
            int PubCount = 0;
            int UnPubCount = 0;
            for (int i = 0; i < dv6.Count; i++)
            {
                PubCount += int.Parse(dv6[i]["or_pubcnt"].ToString().Trim());
                UnPubCount += int.Parse(dv6[i]["or_unpubcnt"].ToString().Trim());
            }
            this.lblORPunCnt.Text = Convert.ToString(PubCount);
            this.lblORUnPubCnt.Text = Convert.ToString(UnPubCount);

        }


        private void UpdateDB()
        {
            // 抓下畫面上的值 - 以區域來分
            // 廠商及客戶資料 區
            string strMfrNo = this.lblMfrNo.Text.ToString().Trim();
            string strCustNo = this.lblCustNo.Text.ToString().Trim();

            // 合約書基本資料 區
            string strContType = this.ddlContType.SelectedItem.Value.ToString().Trim();
            string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString().Trim();
            string strSignDate = this.tbxSignDate.Text.ToString().Trim();
            strSignDate = strSignDate.Substring(0, 4) + strSignDate.Substring(5, 2) + strSignDate.Substring(8, 2);
            string strEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
            string strStartDate = this.tbxStartDate.Text.ToString().Trim();
            strStartDate = strStartDate.Substring(0, 4) + strStartDate.Substring(5, 2);
            string strEndDate = this.tbxEndDate.Text.ToString().Trim();
            strEndDate = strEndDate.Substring(0, 4) + strEndDate.Substring(5, 2);

            // 註記類說明： 0代表否（預設）, １代表是
            string strfgClosed = this.rblfgClosed.SelectedItem.Value;
            // 顯示 lblOldContMessage 訊息 : 判斷是否為 第一張合約 或 有歷史參考資料
            string strOldContNo = this.lblOldContNo.Text;
            //			string strOldContNo = Context.Request.QueryString["contno"].ToString().Trim();
            //			if(strOldContNo == "0")
            //			{
            //				this.lblOldContMessage.Text = "(無歷史資料, 此為新合約)";
            //				strOldContNo = "0";
            //			}
            //			else
            //				strOldContNo = this.lblOldContNo.Text;
            string strModifyDate = System.DateTime.Today.ToString("yyyyMMdd").Trim();
            // 若 rblfgPayOnce 沒有選擇時, 給予預設值 0
            string strfgPayOnce = "0";
            if (this.rblfgPayOnce.SelectedIndex >= 0)
                strfgPayOnce = this.rblfgPayOnce.SelectedItem.Value.ToString().Trim();
            else
                strfgPayOnce = strfgPayOnce;
            string strModifyEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
            // 註記類說明： 0代表否（預設）, １代表是
            string strfgCancel = this.rblfgCancel.SelectedItem.Value;
            string strCreateDate = System.DateTime.Today.ToString("yyyyMMdd").Trim();
            string strSyscd = "C2";
            string strContNo = this.lblContNo.Text.ToString().Trim();
            //Response.Write("strContType= " + strContType + "<br>");
            //Response.Write("strSignDate= " + strSignDate + "<br>");
            //Response.Write("strEmpNo= " + strEmpNo + "<br>");
            //Response.Write("strfgClosed= " + strfgClosed + "<br>");
            //Response.Write("strOldContNo= " + strOldContNo + "<br>");
            //Response.Write("strModifyEmpNo= " + strModifyEmpNo + "<br>");
            //Response.Write("strCreateDate= " + strCreateDate + "<br>");

            // 合約書細節資料 區
            string strTotalJTime = this.tbxTotalJTime.Text.ToString().Trim();
            string strMadeJTime = this.tbxMadeJTime.Text.ToString().Trim();
            string strRestJTime = this.tbxRestJTime.Text.ToString().Trim();
            string strTotalTime = this.tbxTotalTime.Text.ToString().Trim();
            string strPubTime = this.tbxPubTime.Text.ToString().Trim();
            string strRestTime = this.tbxRestTime.Text.ToString().Trim();
            string strTotalAmount = this.tbxTotalAmt.Text.ToString().Trim();
            string strPaidAmount = this.tbxPaidAmt.Text.ToString().Trim();
            string strRestAmount = this.tbxRestAmt.Text.ToString().Trim();
            string strChangeJTime = this.tbxChangeJTime.Text.ToString().Trim();
            string strFreeTime = this.tbxFreeTime.Text.ToString().Trim();
            string strADAmount = this.tbxADAmt.Text.ToString().Trim();
            string strDiscount = this.tbxDiscount.Text.ToString().Trim();
            string strFreeBookCount = this.tbxFreeBookCount.Text.ToString().Trim();
            string strPubADAmount = this.tbxPubAdAmt.Text.ToString().Trim();
            string strPubChangeAmount = this.tbxPubChangeAmt.Text.ToString().Trim();
            string strColorTime = this.tbxColorTime.Text.ToString().Trim();
            string strGetColorTime = this.tbxGetColorTime.Text.ToString().Trim();
            string strMemoTime = this.tbxMenoTime.Text.ToString().Trim();
            //Response.Write("strADAmount= " + strADAmount + "<br>");
            // 備註 區 : Html Control 必須 Runat=server, 才能在 aspx.cs 中呼叫使用
            string strRemark = "";
            // 且在 .cs 必須自己加註 protected System.Web.UI.HtmlControls.HtmlTextArea tarContRemark;
            if (this.tarContRemark.Value.ToString().Trim() != "")
            {
                //Response.Write("cont_remark= " + this.tarContRemark.Value.ToString().Trim() + "<br>");
                strRemark = this.tarContRemark.Value.ToString().Trim();
            }

            // 廣告聯絡人 區
            string strAUName = this.tbxAuName.Text.ToString().Trim();
            string strAUTel = this.tbxAuTel.Text.ToString().Trim();
            string strAUFax = this.tbxAuFax.Text.ToString().Trim();
            string strAUCell = this.tbxAuCell.Text.ToString().Trim();
            string strAUEmail = this.tbxAuEmail.Text.ToString().Trim();


            //Response.Write(sqlCommand1.Parameters.Count.ToString().Trim());
            try
            {
                myPlane.UpdateC2_cont(strSyscd, strContNo, strContType, strBkcd, strSignDate, strEmpNo, strStartDate,
                    strEndDate, strfgClosed, strModifyDate, strfgPayOnce, strModifyEmpNo, strfgCancel, strTotalJTime,
                    strMadeJTime, strRestJTime, strTotalTime, strPubTime, strRestTime, strTotalAmount, strPaidAmount,
                    strRestAmount, strChangeJTime, strFreeTime, strADAmount, strDiscount, strPubADAmount, strPubChangeAmount,
                    strColorTime, strGetColorTime, strMemoTime, strFreeBookCount, strRemark, strAUName, strAUTel, strAUFax,
                    strAUCell, strAUEmail);

                JavaScript.AlertMessageRedirect(this.Page, "更新合約書成功", "ContFm_chklist.aspx");
                // 以 Javascript 的 window.close() 來告知訊息
                //LiteralControl litAlert1 = new LiteralControl();
                //litAlert1.Text = "<script language=javascript>alert(\"更新合約書成功\");location.</script>";
                //Page.Controls.Add(litAlert1);

                // 轉址處理 - 合約書檢核表
                //Response.Redirect("ContFm_chklist.aspx");
            }
            catch (System.Data.SqlClient.SqlException ex1)
            {
                Response.Write(ex1.Message + "<br>");
                //Response.Write("更新失敗!<br>");

                // 以 Javascript 的 window.close() 來告知訊息
                LiteralControl litAlert1 = new LiteralControl();
                litAlert1.Text = "<script language=javascript>alert(\"更新合約書失敗\");</script>";
                Page.Controls.Add(litAlert1);
            }

        }


        protected void GridView2OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更簽約日期的格式
                // 發票類別代碼
                string mtpcd = e.Row.Cells[12].Text.Trim();

                DataTable dtmtp = myPlane.SelectMtp();
                DataView dv7 = dtmtp.DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                // 設 Row Filter: default 抓 1=1 and 其他 rowfilter 條件
                string rowfilterstr7 = "1=1";
                rowfilterstr7 = rowfilterstr7 + " AND mtp_mtpcd='" + mtpcd + "'";
                dv7.RowFilter = rowfilterstr7;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv7.Count= "+ dv7.Count + "<BR>");
                //Response.Write("dv7.RowFilter= " + dv7.RowFilter + "<BR>");

                if (dv7.Count > 0)
                {
                    // 抓出 郵寄類別相關資料
                    string mtpnm = dv7[0]["mtp_nm"].ToString().Trim();
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


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");
        }

        protected void btnGoPub_Click(object sender, EventArgs e)
        {
            string strbuf = "";
            string strContNo = this.lblContNo.Text.ToString().Trim();
            string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
            strbuf = "PubFm.aspx?contno=" + strContNo + "&bkcd=" + strBkcd + "&fgnew=1";

            //Response.Write("strbuf= " + strbuf + "<br>");
            Response.Redirect(strbuf);
        }

        protected void imbORRefresh_Click(object sender, ImageClickEventArgs e)
        {
            CheckIMORExist();
            // 呼叫 發票廠商收件人 DataGrid1
            BindGrid2();
        }

        protected void imbIMRefresh_Click(object sender, ImageClickEventArgs e)
        {
            CheckIMORExist();
            BindGrid1();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // 將畫面上的資料, 更新入資料庫中
            UpdateDB();
        }
    }
}
