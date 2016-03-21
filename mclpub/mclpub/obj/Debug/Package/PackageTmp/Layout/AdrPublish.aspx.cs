using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace mclpub.Layout
{
    public partial class AdrPublish : System.Web.UI.Page
    {
        AdrPublish_DB myAdr = new AdrPublish_DB();
        security sec = new security();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //預設欄位
                    tbxAdAmt.Text = "0";
                    tbxDesAmt.Text = "0";
                    tbxChgAmt.Text = "0";
                    tbxInvAmt.Text = "0";
                    tbxImpr.Text = "1";

                    //檢查變數，這樣大概可以過濾一些
                    string new_contno = "";
                    if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
                    {
                        throw new Exception("找不到合約編號");
                    }
                    else
                    {
                        new_contno = sec.decryptquerystring(Request.QueryString["NewContNo"].ToString());
                    }

                    LoadContInfo(new_contno);
                    Bind_NewInvMfr(new_contno);
                    Bind_NewAdr(new_contno);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        #region 載入合約基本資料
        private void LoadContInfo(string contno)
        {
            if (contno.Trim() == "")
                throw new Exception("合約編號不可為空白");

            DataSet ds = myAdr.GetSingleContractByContNo(contno);
            lblContNo.Text = ds.Tables[0].Rows[0]["cont_contno"].ToString();

            switch (ds.Tables[0].Rows[0]["cont_conttp"].ToString().Trim())
            {
                case "01":
                    lblContTp.Text = "一般";
                    break;
                case "09":
                    lblContTp.Text = "推廣";
                    break;
                default:
                    lblContTp.Text = "(無法辨識)";
                    break;
            }

            lblSignDate.Text = DateTime.ParseExact(ds.Tables[0].Rows[0]["cont_signdate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
            lblSDate.Text = DateTime.ParseExact(ds.Tables[0].Rows[0]["cont_sdate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
            lblEDate.Text = DateTime.ParseExact(ds.Tables[0].Rows[0]["cont_edate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
            lblMfrNm.Text = ds.Tables[0].Rows[0]["mfr_inm"].ToString();
            lblCustNm.Text = ds.Tables[0].Rows[0]["cust_nm"].ToString();
            lblPubTm.Text = ds.Tables[0].Rows[0]["cont_pubtm"].ToString();
            //lblRestTm.Text = dr["cont_resttm"].ToString();
            lblFreeTm.Text = ds.Tables[0].Rows[0]["cont_freetm"].ToString();
            lblTotAmt.Text = ds.Tables[0].Rows[0]["cont_totamt"].ToString();
            lblDisc.Text = ds.Tables[0].Rows[0]["cont_disc"].ToString();
            //lblTotImgTm.Text = dr["cont_totimgtm"].ToString();
            //lblTotUrlTm.Text = dr["cont_toturltm"].ToString();


            //附加的資訊
            DataSet dsGetAdrCounts = myAdr.GetAdrCounts(contno);
            int imgtm = 0;
            int urltm = 0;
            int pubedtm = 0;
            int totmtm = 0;
            int totitm = 0;
            int totntm = 0;

            if (dsGetAdrCounts.Tables[0].Rows.Count > 0)
            {
                imgtm = Convert.ToInt32(dsGetAdrCounts.Tables[0].Rows[0]["imgtm"]);
                urltm = Convert.ToInt32(dsGetAdrCounts.Tables[0].Rows[0]["urltm"]);
                pubedtm = Convert.ToInt32(dsGetAdrCounts.Tables[0].Rows[0]["pubedtm"]);
                totmtm = Convert.ToInt32(dsGetAdrCounts.Tables[0].Rows[0]["totmtm"]);
                totitm = Convert.ToInt32(dsGetAdrCounts.Tables[0].Rows[0]["totitm"]);
                totntm = Convert.ToInt32(dsGetAdrCounts.Tables[0].Rows[0]["totntm"]);
            }

            lbl_PubTm.Text = ds.Tables[0].Rows[0]["cont_pubtm"].ToString();
            lbl_PubedTm.Text = pubedtm.ToString();
            lbl_RestTm.Text = Convert.ToString(Convert.ToInt32(lbl_PubTm.Text) - Convert.ToInt32(lbl_PubedTm.Text));
            lbl_TotImgTm.Text = ds.Tables[0].Rows[0]["cont_totimgtm"].ToString();
            lbl_RestImgTm.Text = Convert.ToString(Convert.ToInt32(lbl_TotImgTm.Text) - imgtm);
            if (Convert.ToInt32(lbl_RestImgTm.Text) < 0)
            {
                JavaScript.AlertMessage(this.Page, "剩餘製圖檔稿次數小餘零，請檢查/修改圖檔稿件類別");
                return;
            }
            lbl_TotUrlTm.Text = ds.Tables[0].Rows[0]["cont_toturltm"].ToString();
            lbl_RestUrlTm.Text = Convert.ToString(Convert.ToInt32(lbl_TotUrlTm.Text) - urltm);
            if (Convert.ToInt32(lbl_RestUrlTm.Text) < 0)
            {
                JavaScript.AlertMessage(this.Page, "剩餘製網頁稿次數小餘零，請檢查/修改網頁稿件類別");
                return;
            }

            lblTotMtm.Text = totmtm.ToString();
            lblTotItm.Text = totitm.ToString();
            //lblTotNtm.Text = totntm.ToString();
        }
        #endregion

        #region 本合約的發票廠商收件人資料
        private void Bind_NewInvMfr(string contno)
        {
            DataSet ds = myAdr.GetInvMfr(contno);
            DataView dv = ds.Tables[0].DefaultView;
            dgdNewInvMfr1.DataSource = dv;
            dgdNewInvMfr1.DataBind();

            Bind_ddlInvMfr(dv);

            if (dv.Count > 0)
            {
                dgdNewInvMfr1.Visible = true;
            }
            else
            {
                dgdNewInvMfr1.Visible = false;
            }
        }
        #endregion

        #region 連結發票廠商下拉式選單
        private void Bind_ddlInvMfr(DataView dv)
        {
            ddlInvMfr.DataTextField = "im_nm";
            ddlInvMfr.DataValueField = "im_imseq";
            ddlInvMfr.DataSource = dv;
            ddlInvMfr.DataBind();
        }
        #endregion

        #region 連結廣告資料
        private void Bind_NewAdr(string contno)
        {
            if (contno == null || contno.Trim().Length != 6)
            {
                JavaScript.AlertMessage(this.Page, "合約編號為空值或格式錯誤，請通知聯絡人");
                return;
            }
            DataSet ds = myAdr.GetAdvertisements(contno);
            DataView dv = ds.Tables[0].DefaultView;

            dgdAdr.DataSource = dv;
            dgdAdr.DataBind();

            if (dv.Count > 0)
            {
                btnDelSeltedAdr.Visible = true;
            }
            else
            {
                btnDelSeltedAdr.Visible = false;
            }
            GetAdrInfo(contno);
        }
        #endregion

        #region 取得廣告數值統計
        private void GetAdrInfo(string contno)
        {
            int totadamt = 0;
            int totdesamt = 0;
            int totchgamt = 0;
            int totpubedamt = 0;

            DataSet ds = myAdr.GetAdrAmounts(contno);
            if (ds.Tables[0].Rows.Count > 0)
            {
                totadamt = Convert.ToInt32(ds.Tables[0].Rows[0]["totadamt"]);
                totdesamt = Convert.ToInt32(ds.Tables[0].Rows[0]["totdesamt"]);
                totchgamt = Convert.ToInt32(ds.Tables[0].Rows[0]["totchgamt"]);
                totpubedamt = totadamt + totdesamt + totchgamt;
            }

            lblTotAdAmt.Text = totadamt.ToString();
            lblTotDesAmt.Text = totdesamt.ToString();
            lblTotChgAmt.Text = totchgamt.ToString();
            lblTotPubedAmt.Text = totpubedamt.ToString();

        }
        #endregion

        #region 格式化廣告資料
        protected string MatchAdCate(string adcate)
        {
            string transAdCate = "";
            switch (adcate.ToString())
            {
                case "M":
                    transAdCate = "首頁";
                    break;
                case "I":
                    transAdCate = "內頁";
                    break;
                case "N":
                    transAdCate = "奈米";
                    break;
                default:
                    throw new Exception("資料庫原生廣告頁面資料錯誤，請通知聯絡人");
                    break;
            }
            return transAdCate;
        }

        protected string MatchKeyword(string keyword)
        {
            string transKeyword = "";
            switch (keyword.ToString())
            {
                case "h0":
                    transKeyword = "正中";
                    break;
                case "h1":
                    transKeyword = "右一";
                    break;
                case "h2":
                    transKeyword = "右二";
                    break;
                case "h3":
                    transKeyword = "右三";
                    break;
                case "h4":
                    transKeyword = "右四";
                    break;
                case "w1":
                    transKeyword = "右文一";
                    break;
                case "w2":
                    transKeyword = "右文二";
                    break;
                case "w3":
                    transKeyword = "右文三";
                    break;
                case "w4":
                    transKeyword = "右文四";
                    break;
                case "w5":
                    transKeyword = "右文五";
                    break;
                case "w6":
                    transKeyword = "右文六";
                    break;
                default:
                    throw new Exception("資料庫原生廣告位置資料錯誤，請通知聯絡人");
                    break;
            }
            return transKeyword;
        }

        protected object MatchImSeq(object imseq)
        {
            string transImSeq = "";
            try
            {
                transImSeq = ddlInvMfr.Items.FindByValue(imseq.ToString()).Text;
            }
            catch
            {
                //				if (lblContTp.Text == "一般")
                //					throw new Exception("資料庫原生發票廠商資料錯誤，請通知聯絡人");
            }
            return transImSeq;
        }

        #endregion

        protected void dgdAdr_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[15].Visible = false;
                e.Row.Cells[16].Visible = false;
                e.Row.Cells[17].Visible = false;
                e.Row.Cells[18].Visible = false;

                if (e.Row.Cells[18].Text == "1")
                {
                    e.Row.Cells[19].Text = "<font color=red>已開發票</font>";
                    ((CheckBox)e.Row.Cells[0].FindControl("cbxDelAdr")).Checked = false;
                    ((CheckBox)e.Row.Cells[0].FindControl("cbxDelAdr")).Enabled = false;
                }
                else
                {
                    e.Row.Cells[19].Text = "";
                }

                //檢查日期;92/8/15決定當天資料可刪除
                //				if (DateTime.Today >= DateTime.ParseExact(dgdAdr.Items[i].Cells[3].Text.Trim(), "yyyyMMdd", null))
                if (DateTime.Today > DateTime.ParseExact(e.Row.Cells[3].Text.Trim(), "yyyyMMdd", null))
                {
                    ((CheckBox)e.Row.Cells[0].FindControl("cbxDelAdr")).Checked = false;
                    ((CheckBox)e.Row.Cells[0].FindControl("cbxDelAdr")).Enabled = false;
                }


                //廣告日期：轉換為yyyy/MM/dd
                e.Row.Cells[3].Text = DateTime.ParseExact(e.Row.Cells[3].Text.Trim(), "yyyyMMdd", null).ToString("yyyy/MM/dd");


                ((Label)e.Row.Cells[5].FindControl("lblEAdCate")).Text = MatchAdCate(((Label)e.Row.Cells[5].FindControl("lblEAdCate")).Text);
                ((Label)e.Row.Cells[6].FindControl("lblEKeyword")).Text = MatchKeyword(((Label)e.Row.Cells[6].FindControl("lblEKeyword")).Text);

            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[15].Visible = false;
                e.Row.Cells[16].Visible = false;
                e.Row.Cells[17].Visible = false;
                e.Row.Cells[18].Visible = false;
            }
        }

        protected void bthAddAdr_Click(object sender, EventArgs e)
        {
            string contno = lblContNo.Text.Trim();
            string sdate;
            try
            {
                sdate = DateTime.ParseExact(tbxSDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
            }
            catch (Exception ex)
            {
                JavaScript.AlertMessage(this.Page, "起始日期格式錯誤");
                return;
            }

            string edate;
            try
            {
                edate = DateTime.ParseExact(tbxEDate.Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
            }
            catch (Exception ex)
            {
                JavaScript.AlertMessage(this.Page, "結束日期格式錯誤");
                return;
            }

            if (DateTime.ParseExact(sdate, "yyyyMMdd", null) > DateTime.ParseExact(edate, "yyyyMMdd", null))
            {
                JavaScript.AlertMessage(this.Page, "起始日期不可以比結束日期大");
                return;
            }

            if (DateTime.ParseExact(sdate, "yyyyMMdd", null) < DateTime.Today)
            {
                JavaScript.AlertMessage(this.Page, "不能新增今天之前的廣告資料");
                return;
            }

            DateTime csdate = DateTime.ParseExact(lblSDate.Text.Trim(), "yyyy/MM/dd", null);
            DateTime cedate = DateTime.ParseExact(lblEDate.Text.Trim(), "yyyy/MM/dd", null);

            if (!(csdate <= DateTime.ParseExact(sdate, "yyyyMMdd", null) && DateTime.ParseExact(edate, "yyyyMMdd", null) <= cedate))
            {
                JavaScript.AlertMessage(this.Page, "廣告起迄區間不可超出合約起迄區間");
                return;
            }

            double addays = ((TimeSpan)DateTime.ParseExact(edate, "yyyyMMdd", null).Subtract(DateTime.ParseExact(sdate, "yyyyMMdd", null))).TotalDays + 1;
            if (addays > Convert.ToInt32(lbl_RestTm.Text.Trim()))
            {
                JavaScript.AlertMessage(this.Page, "新增的刊登日數(次數:" + addays.ToString() + ")不可大於剩餘刊登次數:" + lbl_RestTm.Text.Trim());
                return;
            }


            string adcate = ddlAdCate.SelectedItem.Value;
            string keyword = ddlKeyword.SelectedItem.Value;
            string alttext = tbxAltText.Text.Trim();
            string imgurl = "";	//由美編決定
            string navurl = tbxNavUrl.Text.Trim();	//美編可以再決定
            if (!navurl.ToLower().StartsWith("http://"))
                if (navurl.Trim() != "")
                    navurl = "http://" + navurl;
            int impr;
            try
            {
                impr = Convert.ToInt32(tbxImpr.Text.Trim());
            }
            catch (Exception ex)
            {
                JavaScript.AlertMessage(this.Page, "播出機率格式錯誤");
                return;
            }

            string drafttp = rblImgTp.SelectedItem.Value;
            string urltp = rblUrlTp.SelectedItem.Value;

            if (ddlInvMfr.Items.Count <= 0 && lblContTp.Text.Trim() == "一般")
            {
                JavaScript.AlertMessage(this.Page, "本合約為一般合約，請先新增發票廠商收件人後再新增廣告");
                return;
            }
            string imseq;
            if (lblContTp.Text.Trim() == "一般")
            {
                imseq = ddlInvMfr.SelectedItem.Value;
            }
            else
            {
                imseq = "";
            }

            int adamt;
            try
            {
                adamt = Convert.ToInt32(tbxAdAmt.Text.Trim());
            }
            catch (Exception ex)
            {
                JavaScript.AlertMessage(this.Page, "廣告金額格式錯誤");
                return;
            }

            int desamt;
            try
            {
                desamt = Convert.ToInt32(tbxDesAmt.Text.Trim());
            }
            catch (Exception ex)
            {
                JavaScript.AlertMessage(this.Page, "設計價格格式錯誤");
                return;
            }

            int chgamt;
            try
            {
                chgamt = Convert.ToInt32(tbxChgAmt.Text.Trim());
            }
            catch (Exception ex)
            {
                JavaScript.AlertMessage(this.Page, "換稿費用格式錯誤");
                return;
            }

            //檢查廣告金額問題
            int totamt = 0;
            try
            {
                totamt = Convert.ToInt32(lblTotAmt.Text.Trim());
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "合約總金額格式錯誤，請至合約維護修改金額");
                return;
            }

            // 2003/06/11
            //註：這邊很重要，跟C300討論結果，
            //僅有廣告價格要跟合約金額做限制比對，
            //而設計價格與換稿費用不包含在合約金額裡面
            


            //Response.Write(dgdAdr.Rows[1].Cells[3].Text.Trim());

            //合約剩餘金額的計算
            int restamt = int.Parse(lblTotAmt.Text.ToString());
            for (int k = 0; k < dgdAdr.Rows.Count; k++)
            {
                try
                {
                    restamt -= Convert.ToInt32(((Label)dgdAdr.Rows[0].Cells[9].FindControl("lblEadamt")).Text.Trim());
                }
                catch
                {
                    JavaScript.AlertMessage(this.Page, "加總計算已落版金額時發生錯誤，請通知聯絡人");
                    return;
                }
            }

            if (adamt > restamt)	//本來用這個          !VerifyMoneyIsValid(adamt, desamt, chgamt, totamt)
            {
                JavaScript.AlertMessage(this.Page, "新增的廣告價格不得超過合約總金額，請更改金額後再新增");
                return;
            }

            string remark = tbxRemark.Text.Trim();

            string fgfixad = rblFgFixAd.SelectedItem.Value;
            //CHCECK是否定播
            if (fgfixad == "1")
            {
                impr = 20;
                JavaScript.AlertMessage(this.Page, "由於定播，所以強制轉換播放機率為20");
            }

            //檢查剩餘的空間夠不夠
            DateTime firstXday;
            DataSet ds = myAdr.CheckAdrSlot(adcate, keyword, sdate, edate, impr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                firstXday = DateTime.ParseExact(ds.Tables[0].Rows[0]["cnt_date"].ToString(), "yyyyMMdd", null);
                JavaScript.AlertMessage(this.Page, firstXday.ToString("yyyy/MM/dd") + "的剩餘空間不足，請修改起迄日期區段");
                return;
            }


            //院所內註記跟發票廠商資料走
            string fgitri = "";

            if (ddlInvMfr.Items.Count >= 0 && lblContTp.Text.Trim() == "一般")
            {
                DataSet dsGetSingleIm = myAdr.GetSingleIm(contno, imseq);
                if (dsGetSingleIm.Tables[0].Rows.Count>0)
                {
                    fgitri = dsGetSingleIm.Tables[0].Rows[0]["im_fgitri"].ToString().Trim();
                }
                else
                {
                    JavaScript.AlertMessage(this.Page, "資料庫遺失本合約發票廠商資料，請通知聯絡人");
                    return;
                }
            }

            if (fgitri == "00")
            {
                //因為DropDownList的ListItem無法以""為Value，所以用00替代，
                //這邊再轉換回來
                fgitri = "";
            }
            string fgimggot = "0";//rblFgImgGot.SelectedItem.Value.Trim();
            string fgurlgot = "0";//rblFgUrlGot.SelectedItem.Value.Trim();
            //以上是取得數值

            //INSERT INTO Database
            myAdr.AddAdr(contno, sdate, edate, adcate, keyword, alttext, imgurl, navurl, impr,
                drafttp, urltp, imseq, adamt, desamt, chgamt, remark, fgfixad, fgitri, fgimggot, fgurlgot);

            Bind_NewAdr(contno);
            LoadContInfo(contno);
        }

        protected void btnDelSeltedAdr_Click(object sender, EventArgs e)
        {
            bool chk = false;
            ArrayList ary = new ArrayList();
            for (int i = 0; i < dgdAdr.Rows.Count; i++)
            {
                if (((CheckBox)dgdAdr.Rows[i].Cells[0].FindControl("cbxDelAdr")).Checked)
                {
                    string adrseq = dgdAdr.Rows[i].Cells[2].Text.Trim();
                    string addate = RevertAdDate(dgdAdr.Rows[i].Cells[3].Text.Trim());
                    string adcate = RevertAdCate(((Label)dgdAdr.Rows[i].Cells[5].FindControl("lblEAdCate")).Text.Trim());
                    string keyword = RevertKeyword(((Label)dgdAdr.Rows[i].Cells[6].FindControl("lblEKeyword")).Text.Trim());
                    string impr = ((Label)dgdAdr.Rows[i].Cells[8].FindControl("lblEimpr")).Text.Trim();
                    chk = true;
                    ary.Add(adrseq + "," + addate + "," + adcate + "," + keyword + "," + impr);
                }
            }

            if (chk == false)
            {
                JavaScript.AlertMessage(this.Page, "並未勾選任何項目");
                return;
            }

            //刪除前，先check
            bool xmlExist = false;
            ArrayList xeArray = new ArrayList();

            for (int i = 0; i < ary.Count; i++)
            {
                string rawString = (string)ary[i];

                string addate = "";

                try
                {
                    addate = ((string)(rawString.Split(',')).GetValue(1));
                }
                catch (Exception ex)
                {
                    throw new Exception("無法取得落版日期資料");
                }

                string strCmd = "";
                if (addate == "")
                    throw new Exception("廣告落版日期資料錯誤");

                //checking....
                xmlExist = myAdr.CheckXmlFileLog(addate);

                if (xmlExist)
                {
                    xeArray.Add(addate);
                }
            }


            //有無日期出現？
            if (xeArray.Count > 0)
            {
                string strDate = "";
                for (int j = 0; j < xeArray.Count; j++)
                {
                    strDate += (string)xeArray[j] + ",";
                }
                JavaScript.AlertMessage(this.Page, strDate + "已產生過落版xml檔案，欲刪除這些日期的落版資料，請先刪除這些日期對應的xml落版檔案");
                return;
            }

            //以下為可以刪除落版的執行
            string adr_contno = lblContNo.Text.Trim();
            myAdr.DeleteAdr(adr_contno, ary);

            Bind_NewAdr(adr_contno);
            LoadContInfo(adr_contno);
        }


        #region GRIDVIEW內的更新 修改及刪除三個按鈕

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((LinkButton)sender).Parent.Parent as GridViewRow;  //此段取到該Row

            Label lblEAlttext = (Label)thisRow.Cells[4].FindControl("lblEAlttext");
            Label lblEAdCate = (Label)thisRow.Cells[5].FindControl("lblEAdCate");
            Label lblEKeyword = (Label)thisRow.Cells[6].FindControl("lblEKeyword");
            Label lblEnavurl = (Label)thisRow.Cells[7].FindControl("lblEnavurl");
            Label lblEimpr = (Label)thisRow.Cells[8].FindControl("lblEimpr");
            Label lblEadamt = (Label)thisRow.Cells[9].FindControl("lblEadamt");
            Label lblEdesamt = (Label)thisRow.Cells[10].FindControl("lblEdesamt");
            Label lblEchgamt = (Label)thisRow.Cells[11].FindControl("lblEchgamt");
            Label adr_invamt = (Label)thisRow.Cells[12].FindControl("adr_invamt");
            Label lblInvMfr = (Label)thisRow.Cells[13].FindControl("lblInvMfr");
            Label lblEremark = (Label)thisRow.Cells[14].FindControl("lblEremark");


            TextBox tbxalttext = (TextBox)thisRow.Cells[4].FindControl("tbxalttext");
            DropDownList ddlEAdCate = (DropDownList)thisRow.Cells[5].FindControl("ddlEAdCate");
            DropDownList ddlEKeyword = (DropDownList)thisRow.Cells[6].FindControl("ddlEKeyword");
            TextBox tbxnavurl = (TextBox)thisRow.Cells[7].FindControl("tbxnavurl");
            TextBox tbximpr = (TextBox)thisRow.Cells[8].FindControl("tbximpr");
            TextBox tbxadamt = (TextBox)thisRow.Cells[9].FindControl("tbxadamt");
            TextBox tbxdesamt = (TextBox)thisRow.Cells[10].FindControl("tbxdesamt");
            TextBox tbxchgamt = (TextBox)thisRow.Cells[11].FindControl("tbxchgamt");
            Label adr_invamtNew = (Label)thisRow.Cells[12].FindControl("adr_invamtNew");
            DropDownList ddlEInvMfr = (DropDownList)thisRow.Cells[13].FindControl("ddlEInvMfr");
            TextBox tbxremark = (TextBox)thisRow.Cells[14].FindControl("tbxremark");

            LinkButton btnEdit_Click = (LinkButton)sender;
            LinkButton SubBtn = (LinkButton)thisRow.Cells[1].FindControl("SubBtn");
            LinkButton CancelBtn = (LinkButton)thisRow.Cells[1].FindControl("CancelBtn");
            
            btnEdit_Click.Visible = false;
            SubBtn.Visible = true;
            CancelBtn.Visible = true;

            lblEAlttext.Visible = false;
            lblEAdCate.Visible = false;
            lblEKeyword.Visible = false;
            lblEnavurl.Visible = false;
            lblEimpr.Visible = false;
            lblEadamt.Visible = false;
            lblEdesamt.Visible = false;
            lblEchgamt.Visible = false;
            adr_invamt.Visible = false;
            lblInvMfr.Visible = false;
            lblEremark.Visible = false;

            tbxalttext.Visible = true;
            ddlEAdCate.Visible = true;
            ddlEKeyword.Visible = true;
            tbxnavurl.Visible = true;
            tbximpr.Visible = true;
            tbxadamt.Visible = true;
            tbxdesamt.Visible = true;
            tbxchgamt.Visible = true;
            adr_invamtNew.Visible = true;
            ddlEInvMfr.Visible = true;
            tbxremark.Visible = true;

            //Response.Write(thisRow.RowIndex);
            DateTime csdate = DateTime.ParseExact(lblSDate.Text.Trim(), "yyyy/MM/dd", null);
            DateTime cedate = DateTime.ParseExact(lblEDate.Text.Trim(), "yyyy/MM/dd", null);
            DateTime addate = DateTime.ParseExact(thisRow.Cells[3].Text.Trim(), "yyyy/MM/dd", null);

            if (!(csdate <= addate && addate <= cedate))
            {
                JavaScript.AlertMessage(this.Page, "無法修改超出合約起迄區間的廣告落版資料");
                return;
            }

            int flag = EditCheck(thisRow.RowIndex);
            if (flag == 4)
            {
                JavaScript.AlertMessage(this.Page, "此筆廣告落版資料已開立發票, 不允許修改");
                return;
            }

            string contno = lblContNo.Text.Trim();
            //Bind_NewAdr(contno);


            //設定textbox的寬度

            //thisRow.Cells[3].Text = DateTime.ParseExact(thisRow.Cells[3].Text.Trim(), "yyyyMMdd", null).ToString("yyyy/MM/dd");


            //處理廣告頁面
            foreach (ListItem li in ddlAdCate.Items)
            {
                ddlEAdCate.Items.Add(li);
            }
            ddlEAdCate.SelectedIndex = -1;
            try
            {
                ddlEAdCate.Items.FindByValue(thisRow.Cells[15].Text.Trim()).Selected = true;
            }
            catch
            {
                //Response.Write(dgi.Cells[15].Text.Trim()+"_");
                ddlEAdCate.SelectedIndex = 0;
            }

            //處理廣告位置
            foreach (ListItem li in ddlKeyword.Items)
            {
                ddlEKeyword.Items.Add(li);
            }
            ddlEKeyword.SelectedIndex = -1;
            try
            {
                ddlEKeyword.Items.FindByValue(thisRow.Cells[16].Text.Trim()).Selected = true;
            }
            catch
            {
                //Response.Write("<br>"+dgi.Cells[16].Text.Trim()+"_");
                ddlEKeyword.SelectedIndex = 0;
            }

            hiddenAdrImpr.Value = lblEimpr.Text;
            //發票金額
            adr_invamtNew.Text = "[加總值]";

            //處理發票廠商
            foreach (ListItem li in ddlInvMfr.Items)
            {
                ddlEInvMfr.Items.Add(li);
            }
            ddlEInvMfr.SelectedIndex = -1;
            try
            {
                ddlEInvMfr.Items.FindByValue(thisRow.Cells[17].Text.Trim()).Selected = true;
            }
            catch
            {
                //Response.Write("<br>"+dgi.Cells[17].Text.Trim()+"_");
                ddlEInvMfr.SelectedIndex = -1;
            }

            if (flag == 2)
            {
                tbxadamt.Enabled = false;
                tbxdesamt.Enabled = false;
                tbxchgamt.Enabled = false;
                ddlEInvMfr.Enabled = false;
            }
            else if (flag == 3)
            {
                tbxalttext.Enabled = false;
                ddlEAdCate.Enabled = false;
                ddlEKeyword.Enabled = false;
                tbxnavurl.Enabled = false;
                tbximpr.Enabled = false;
            }
        }


        protected void SubBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((LinkButton)sender).Parent.Parent as GridViewRow;  //此段取到該Row

            Label lblEAlttext = (Label)thisRow.Cells[4].FindControl("lblEAlttext");
            Label lblEAdCate = (Label)thisRow.Cells[5].FindControl("lblEAdCate");
            Label lblEKeyword = (Label)thisRow.Cells[6].FindControl("lblEKeyword");
            Label lblEnavurl = (Label)thisRow.Cells[7].FindControl("lblEnavurl");
            Label lblEimpr = (Label)thisRow.Cells[8].FindControl("lblEimpr");
            Label lblEadamt = (Label)thisRow.Cells[9].FindControl("lblEadamt");
            Label lblEdesamt = (Label)thisRow.Cells[10].FindControl("lblEdesamt");
            Label lblEchgamt = (Label)thisRow.Cells[11].FindControl("lblEchgamt");
            Label adr_invamt = (Label)thisRow.Cells[12].FindControl("adr_invamt");
            Label lblInvMfr = (Label)thisRow.Cells[13].FindControl("lblInvMfr");
            Label lblEremark = (Label)thisRow.Cells[14].FindControl("lblEremark");


            TextBox tbxalttext = (TextBox)thisRow.Cells[4].FindControl("tbxalttext");
            DropDownList ddlEAdCate = (DropDownList)thisRow.Cells[5].FindControl("ddlEAdCate");
            DropDownList ddlEKeyword = (DropDownList)thisRow.Cells[6].FindControl("ddlEKeyword");
            TextBox tbxnavurl = (TextBox)thisRow.Cells[7].FindControl("tbxnavurl");
            TextBox tbximpr = (TextBox)thisRow.Cells[8].FindControl("tbximpr");
            TextBox tbxadamt = (TextBox)thisRow.Cells[9].FindControl("tbxadamt");
            TextBox tbxdesamt = (TextBox)thisRow.Cells[10].FindControl("tbxdesamt");
            TextBox tbxchgamt = (TextBox)thisRow.Cells[11].FindControl("tbxchgamt");
            Label adr_invamtNew = (Label)thisRow.Cells[12].FindControl("adr_invamtNew");
            DropDownList ddlEInvMfr = (DropDownList)thisRow.Cells[13].FindControl("ddlEInvMfr");
            TextBox tbxremark = (TextBox)thisRow.Cells[14].FindControl("tbxremark");

            LinkButton SubBtn_Click = (LinkButton)sender;
            LinkButton btnEdit = (LinkButton)thisRow.Cells[1].FindControl("btnEdit");
            LinkButton CancelBtn = (LinkButton)thisRow.Cells[1].FindControl("CancelBtn");

            string contno = lblContNo.Text.Trim();
            string seq = thisRow.Cells[2].Text.Trim();

            //日期
            string addate = "";
            try
            {
                addate = DateTime.ParseExact(thisRow.Cells[3].Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "日期格式錯誤");
                return;
            }

            //alttext
            string alttext = tbxalttext.Text.Trim();
            string adcate = ddlEAdCate.SelectedItem.Value;
            string keyword = ddlEKeyword.SelectedItem.Value;
            string navurl = tbxnavurl.Text.Trim();
            if (!navurl.ToLower().StartsWith("http://"))
                if (navurl.Trim() != "")
                    navurl = "http://" + navurl;



            int impr = Convert.ToInt32(tbximpr.Text.Trim());
            int impr_old = int.Parse(hiddenAdrImpr.Value.Trim() == "" ? "" : "0");

            int adamt = 0;
            try
            {
                adamt = Convert.ToInt32(tbxadamt.Text.Trim());
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "廣告金額格式錯誤");
                return;
            }

            int desamt = 0;
            try
            {
                desamt = Convert.ToInt32(tbxdesamt.Text.Trim());
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "設計金額格式錯誤");
                return;
            }
            int chgamt = 0;
            try
            {
                chgamt = Convert.ToInt32(tbxchgamt.Text.Trim());
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "換稿費用金額格式錯誤");
                return;
            }

            //檢查廣告金額問題
            int totamt = 0;
            try
            {
                totamt = Convert.ToInt32(lblTotAmt.Text.Trim());
            }
            catch
            {
                JavaScript.AlertMessage(this.Page, "合約總金額格式錯誤，請至合約維護修改金額");
                return;
            }

            if (!VerifyMoneyIsValid(adamt, desamt, chgamt, totamt))
            {
                JavaScript.AlertMessage(this.Page, "廣告價格、設計價格、換稿費用總和不得超過合約總金額，請更改金額後再新增");
                return;
            }

            if (ddlEInvMfr.Items.Count <= 0 && lblContTp.Text.Trim() == "一般")
            {
                JavaScript.AlertMessage(this.Page, "本合約為一般合約，請先新增發票廠商收件人後再修改/儲存廣告");
                return;
            }
            string imseq;
            if (lblContTp.Text.Trim() == "一般")
            {
                imseq = ddlEInvMfr.SelectedItem.Value;
            }
            else
            {
                imseq = "";
            }



            //檢查剩餘空間
            DateTime firstXday;
            DataSet drslot = myAdr.CheckAdrSlot(adcate, keyword, addate, addate, impr, impr_old);
            if (drslot.Tables[0].Rows.Count > 0)
            {
                firstXday = DateTime.ParseExact(drslot.Tables[0].Rows[0]["cnt_date"].ToString(), "yyyyMMdd", null);
                JavaScript.AlertMessage(this.Page, firstXday.ToString("yyyy/MM/dd") + "的剩餘空間不足，請修改起迄日期區段");
                return;
            }

            //院所內註記跟發票廠商資料走
            string fgitri = "";

            if (lblContTp.Text.Trim() == "一般")
            {
                DataSet ds = myAdr.GetSingleIm(contno, imseq);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    fgitri = ds.Tables[0].Rows[0]["im_fgitri"].ToString().Trim();
                }
                else
                {
                    JavaScript.AlertMessage(this.Page, "資料庫遺失本合約發票廠商資料，請通知聯絡人");
                    return;
                }
            }

            if (fgitri == "00")
            {
                //因為DropDownList的ListItem無法以""為Value，所以用00替代，
                //這邊再轉換回來
                fgitri = "";
            }
            //以上是取得數值

            string remark = tbxremark.Text.Trim();
            //			Response.Write("imseq=" + imseq);


            //通通好了就做UPDATE，目前計畫代號，成本中心不給user帶
            //Response.Write("UPDATE c4_adr SET adr_addate="+addate+", adr_alttext="+alttext+", adr_adcate="+adcate+", adr_keyword="+keyword+", adr_navurl="+navurl+", adr_impr="+impr+", adr_adamt="+adamt.ToString()+", adr_desamt="+desamt.ToString()+", adr_chgamt="+chgamt.ToString()+", adr_invamt="+Convert.ToString(adamt+desamt+chgamt)+", adr_imseq="+imseq+", adr_remark="+remark+" WHERE adr_contno=contno AND adr_seq=seq");
            int errorcode = myAdr.UpdateAdrLite1(contno, seq, addate, adcate, keyword, alttext, navurl, impr, imseq, adamt, desamt, chgamt, remark);

            if (errorcode < 0)
            {
                //表示有錯發生
                switch (errorcode)
                {
                    case -1:
                        JavaScript.AlertMessage(this.Page, "剩餘空間不足，取消更新動作");
                        break;
                    case -2:
                        JavaScript.AlertMessage(this.Page, "廣告更新失敗");
                        break;
                    case -3:
                        JavaScript.AlertMessage(this.Page, "廣告計數補足失敗，取消更新動作");
                        break;
                    default:
                        break;
                }
                return;
            }
            else
            {
                JavaScript.AlertMessageRedirect(this.Page, "廣告更新成功", "AdrPublish.aspx?NewContNo=" + sec.encryptquerystring(Request.QueryString["NewContNo"].ToString()));
            }


            SubBtn_Click.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((LinkButton)sender).Parent.Parent as GridViewRow;  //此段取到該Row

            Label lblEAlttext = (Label)thisRow.Cells[4].FindControl("lblEAlttext");
            Label lblEAdCate = (Label)thisRow.Cells[5].FindControl("lblEAdCate");
            Label lblEKeyword = (Label)thisRow.Cells[6].FindControl("lblEKeyword");
            Label lblEnavurl = (Label)thisRow.Cells[7].FindControl("lblEnavurl");
            Label lblEimpr = (Label)thisRow.Cells[8].FindControl("lblEimpr");
            Label lblEadamt = (Label)thisRow.Cells[9].FindControl("lblEadamt");
            Label lblEdesamt = (Label)thisRow.Cells[10].FindControl("lblEdesamt");
            Label lblEchgamt = (Label)thisRow.Cells[11].FindControl("lblEchgamt");
            Label adr_invamt = (Label)thisRow.Cells[12].FindControl("adr_invamt");
            Label lblInvMfr = (Label)thisRow.Cells[13].FindControl("lblInvMfr");
            Label lblEremark = (Label)thisRow.Cells[14].FindControl("lblEremark");


            TextBox tbxalttext = (TextBox)thisRow.Cells[4].FindControl("tbxalttext");
            DropDownList ddlEAdCate = (DropDownList)thisRow.Cells[5].FindControl("ddlEAdCate");
            DropDownList ddlEKeyword = (DropDownList)thisRow.Cells[6].FindControl("ddlEKeyword");
            TextBox tbxnavurl = (TextBox)thisRow.Cells[7].FindControl("tbxnavurl");
            TextBox tbximpr = (TextBox)thisRow.Cells[8].FindControl("tbximpr");
            TextBox tbxadamt = (TextBox)thisRow.Cells[9].FindControl("tbxadamt");
            TextBox tbxdesamt = (TextBox)thisRow.Cells[10].FindControl("tbxdesamt");
            TextBox tbxchgamt = (TextBox)thisRow.Cells[11].FindControl("tbxchgamt");
            Label adr_invamtNew = (Label)thisRow.Cells[12].FindControl("adr_invamtNew");
            DropDownList ddlEInvMfr = (DropDownList)thisRow.Cells[13].FindControl("ddlEInvMfr");
            TextBox tbxremark = (TextBox)thisRow.Cells[14].FindControl("tbxremark");


            LinkButton CancelBtn_Click = (LinkButton)sender;
            LinkButton SubBtn = (LinkButton)thisRow.Cells[1].FindControl("SubBtn");
            LinkButton btnEdit = (LinkButton)thisRow.Cells[1].FindControl("btnEdit");


            CancelBtn_Click.Visible = false;
            SubBtn.Visible = false;
            btnEdit.Visible = true;


            lblEAlttext.Visible = true;
            lblEAdCate.Visible = true;
            lblEKeyword.Visible = true;
            lblEnavurl.Visible = true;
            lblEimpr.Visible = true;
            lblEadamt.Visible = true;
            lblEdesamt.Visible = true;
            lblEchgamt.Visible = true;
            adr_invamt.Visible = true;
            lblInvMfr.Visible = true;
            lblEremark.Visible = true;

            tbxalttext.Visible = false;
            ddlEAdCate.Visible = false;
            ddlEKeyword.Visible = false;
            tbxnavurl.Visible = false;
            tbximpr.Visible = false;
            tbxadamt.Visible = false;
            tbxdesamt.Visible = false;
            tbxchgamt.Visible = false;
            adr_invamtNew.Visible = false;
            ddlEInvMfr.Visible = false;
            tbxremark.Visible = false;
        }


        #endregion

        #region 落版資料是否可修改
        private int EditCheck(int idx)
        {
            DateTime addate = DateTime.ParseExact(dgdAdr.Rows[idx].Cells[3].Text.Trim(), "yyyy/MM/dd", null);
            if (DateTime.Today > addate)
            {
                if (dgdAdr.Rows[idx].Cells[18].Text.Trim() == "1")
                    return 4;	//所有落版資料不能修改
                else
                    return 3;	//廣告資料不能修改, 發票資料可修改
            }
            else
            {
                //檢查logfile中是否有為欲修改資料播出日的紀錄，
                //如果有就發message，要先delete之後才可以修改落版資料
                bool xmlExist = myAdr.CheckXmlFileLog(addate.ToString("yyyyMMdd"));
                if (xmlExist)
                {
                    JavaScript.AlertMessage(this.Page, "已經產生過該日廣告落版的XML檔案，如要修改廣告落版資料請先刪除該檔案");
                    if (dgdAdr.Rows[idx].Cells[18].Text.Trim() == "1")
                        return 4;	//所有落版資料不能修改
                    else
                        return 3;	//廣告資料不能修改, 發票資料可修改
                }
                else
                {
                    if (dgdAdr.Rows[idx].Cells[18].Text.Trim() == "1")
                        return 2;	//廣告資料可修改, 發票資料不能修改
                    else
                        return 1;	//所有落版資料皆可修改
                }
            }

            return 0;
        }
        #endregion

        #region 檢查輸入的資料是否合乎邏輯
        private bool VerifyMoneyIsValid(int adamt, int desamt, int chgamt, int totamt)
        {
            if (adamt + desamt + chgamt > totamt)
                return false;
            else
                return true;
        }
        #endregion

        #region 反轉換廣告資料欄位回原生資料
        //反轉日期格式回：yyyyMMdd
        private string RevertAdDate(string transAdDate)
        {
            string oriAdDate = "";

            try
            {
                oriAdDate = DateTime.ParseExact(transAdDate, "yyyy/MM/dd", null).ToString("yyyyMMdd");
            }
            catch (Exception ex)
            {
                throw new Exception("反轉日期格式時發生錯誤");
            }
            return oriAdDate;
        }

        //廣告頁面：轉換為首頁、內頁、奈米，停用中
        private string RevertAdCate(string transAdCate)
        {
            string oriAdCate = "";

            switch (transAdCate.Trim())
            {
                case "首頁":
                    oriAdCate = "M";
                    break;
                case "內頁":
                    oriAdCate = "I";
                    break;
                case "奈米":
                    oriAdCate = "N";
                    break;
                default:
                    throw new Exception("反轉廣告頁面格式資料錯誤");
                    //Response.Write("error=" + transAdCate + ".");
                    break;
            }
            return oriAdCate;
        }

        //廣告位置：轉換成中文，停用中
        private string RevertKeyword(string transKeyword)
        {
            string oriKeyword = "";

            switch (transKeyword)
            {
                case "正中":
                    oriKeyword = "h0";
                    break;
                case "右一":
                    oriKeyword = "h1";
                    break;
                case "右二":
                    oriKeyword = "h2";
                    break;
                case "右三":
                    oriKeyword = "h3";
                    break;
                case "右四":
                    oriKeyword = "h4";
                    break;
                case "右文一":
                    oriKeyword = "w1";
                    break;
                case "右文二":
                    oriKeyword = "w2";
                    break;
                case "右文三":
                    oriKeyword = "w3";
                    break;
                case "右文四":
                    oriKeyword = "w4";
                    break;
                case "右文五":
                    oriKeyword = "w5";
                    break;
                case "右文六":
                    oriKeyword = "w6";
                    break;
                default:
                    throw new Exception("反轉廣告位置格式資料錯誤");
                    //Response.Write("error="+transKeyword+".");
                    break;
            }

            return oriKeyword;
        }
        #endregion
    }
}