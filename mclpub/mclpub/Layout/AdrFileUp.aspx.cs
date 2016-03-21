using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Collections;

namespace mclpub.Layout
{
    public partial class AdrFileUp : System.Web.UI.Page
    {
        AdrFileUp_DB myAdr = new AdrFileUp_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //檢查變數，這樣大概可以過濾一些
                string new_contno = "";
                if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"] == "")
                {
                    JavaScript.AlertMessageRedirect(this.Page, "請輸入正確的合約編號", "../Default.aspx");
                    return;
                }
                else
                {
                    new_contno = Request.QueryString["NewContNo"];
                }

                LoadContInfo(new_contno);

                Bind_NewAdr(new_contno);

                Bind_ddlImages();
                LoadImages();//現有廣告圖檔清單
                cbxImage.Checked = true;
                cbxLink.Checked = true;
                cbxAltText.Checked = true;
            }
            SaveAsBtn.Attributes.Add("style", "display:none");
        }

        #region 載入圖檔
        private void LoadImages()
        {
            DataView dv = GetDataSource();
            if (dv.AllowDelete)
            {
                if (dv.Count > 0)
                {
                    dv.Delete(0);
                }
            }
            else
            {
                JavaScript.AlertMessage(this.Page, "Allowpage沒開");
            }

            if (dv.Count > 0)
            {
                dlImageList.DataSource = dv;
                dlImageList.DataBind();

                lblImageInfo.Text = "現有廣告圖檔";
                dlImageList.Visible = true;
            }
            else
            {
                lblImageInfo.Text = "目前尚無任何廣告圖檔";
                dlImageList.Visible = false;
            }
        }
        #endregion

        #region 載入合約基本資料
        private void LoadContInfo(string contno)
        {
            if (contno.Trim() == "")
                throw new Exception("合約編號不可為空白");

            DataSet ds = myAdr.GetSingleContractByContNo(contno);
            if (ds.Tables[0].Rows.Count > 0)
            {
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
                lblPubTm.Text = ds.Tables[0].Rows[0]["cont_pubtm"].ToString();
                lblFreeTm.Text = ds.Tables[0].Rows[0]["cont_freetm"].ToString();
                lblTotAmt.Text = ds.Tables[0].Rows[0]["cont_totamt"].ToString();
                lblDisc.Text = ds.Tables[0].Rows[0]["cont_disc"].ToString();
                lblTotImgTm.Text = ds.Tables[0].Rows[0]["cont_totimgtm"].ToString();
                lblTotUrlTm.Text = ds.Tables[0].Rows[0]["cont_toturltm"].ToString();

            }
        }
        #endregion

        #region refresh檔案
        private void Bind_ddlImages()
        {
            //CommonUtil.config_FileUploadPath
            DataView dv = GetDataSource();
            ddlImages.DataSource = dv;
            dv.Sort = "filename ASC";
            ddlImages.DataTextField = "filename";
            ddlImages.DataValueField = "filename";
            ddlImages.DataBind();
        }
        #endregion

        #region 將檔案資訊處理成DataView
        private DataView GetDataSource()
        {
            string path = Server.MapPath("~/UserImages");//20120222修改 因為nas不能用網路磁碟機 所以只能放在Web目錄底下
            //string path = CommonUtil.config_FileUploadPath;//本機上直接使用路徑
            string[] imagefiles = Directory.GetFiles(path);

            //Response.Write(imagefiles.GetValue(10).ToString());
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("filename");
            dt.Columns.Add(dc);

            for (int i = 0; i < imagefiles.Length; i++)
            {
                string rawFileName = imagefiles.GetValue(i).ToString();
                string SaveDBFileName = rawFileName.Substring(rawFileName.LastIndexOf("\\") + 1);
                if (SaveDBFileName.ToLower() == "thumbs.db")
                {
                    continue;
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr["filename"] = SaveDBFileName;
                    dt.Rows.Add(dr);
                }
                
            }

            DataRow dr0 = dt.NewRow();
            dr0["filename"] = "";
            dt.Rows.InsertAt(dr0, 0);
            //Response.Write(dt.Rows.Count);
            return dt.DefaultView;
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

            if (dv.Count == 0)
            {
                lblMessage.Text = "本合約尚無廣告落版資料";
            }
        }
        #endregion

        protected void dgdAdr_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Visible = false;
                DateTime addate;
                if (e.Row.Cells[3].Text.Trim() != "" && e.Row.Cells[3].Text.Length == 8)
                {
                    addate = DateTime.ParseExact(e.Row.Cells[3].Text.Trim(), "yyyyMMdd", null);
                    if (addate < DateTime.Today)
                    {

                        ((CheckBox)e.Row.Cells[0].FindControl("cbxDelAdr")).Enabled = false;
                        ((LinkButton)e.Row.Cells[1].FindControl("btnEdit")).Enabled = false;
                    }
                    e.Row.Cells[3].Text = addate.ToString("yyyy/MM/dd");

                }
                else
                {
                    e.Row.Cells[3].Text = "(日期格式錯誤)";
                }

                string oriAdCate = e.Row.Cells[5].Text.Trim();
                string transAdCate = "N/A";
                switch (oriAdCate)
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
                e.Row.Cells[5].Text = transAdCate;


                //廣告位置：轉換成中文
                string oriKeyword = e.Row.Cells[6].Text.Trim();
                string transKeyword = "N/A";
                switch (oriKeyword)
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


                ((Label)e.Row.Cells[11].FindControl("lblDraftTp")).Text = GetUrlTpNm(((Label)e.Row.Cells[11].FindControl("lblDraftTp")).Text.Trim());
                ((Label)e.Row.Cells[12].FindControl("lblUrlTp")).Text = GetUrlTpNm(((Label)e.Row.Cells[12].FindControl("lblUrlTp")).Text.Trim());

                e.Row.Cells[6].Text = transKeyword;

                DropDownList ddlImgUrl = ((DropDownList)e.Row.Cells[10].FindControl("ddlImgUrl"));
                DataView dv = GetDataSource();
                ddlImgUrl.DataSource = dv;
                dv.Sort = "filename ASC";
                ddlImgUrl.DataTextField = "filename";
                ddlImgUrl.DataValueField = "filename";
                ddlImgUrl.DataBind();

                e.Row.Cells[13].Visible = false;
                e.Row.Cells[14].Visible = false;


            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[13].Visible = false;
                e.Row.Cells[14].Visible = false;
            }
        }

        protected string GetUrlTpNm(string urltp)
        {
            string strReturn = "";
            switch (urltp.ToString())
            {
                case "1":
                    strReturn = "舊稿";
                    break;
                case "2":
                    strReturn = "新稿";
                    break;
                case "3":
                    strReturn = "改稿";
                    break;
                default:
                    break;
            }
            return strReturn;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((LinkButton)sender).Parent.Parent as GridViewRow;  //此段取到該Row

            Label lblEAlttext = (Label)thisRow.Cells[4].FindControl("lblEAlttext");
            Label lblEnavurl = (Label)thisRow.Cells[7].FindControl("lblEnavurl");
            Label lblEremark = (Label)thisRow.Cells[9].FindControl("lblEremark");
            Label lblImgUrl = (Label)thisRow.Cells[10].FindControl("lblImgUrl");
            Label lblDraftTp = (Label)thisRow.Cells[11].FindControl("lblDraftTp");
            Label lblUrlTp = (Label)thisRow.Cells[12].FindControl("lblUrlTp");

            TextBox tbxalttext = (TextBox)thisRow.Cells[4].FindControl("tbxalttext");
            TextBox tbxnavurl = (TextBox)thisRow.Cells[7].FindControl("tbxnavurl");
            TextBox tbxremark = (TextBox)thisRow.Cells[9].FindControl("tbxremark");
            DropDownList ddlImgUrl = (DropDownList)thisRow.Cells[10].FindControl("ddlImgUrl");
            ddlImgUrl.Width = System.Web.UI.WebControls.Unit.Pixel(150);
            DropDownList ddlDraftTp = (DropDownList)thisRow.Cells[11].FindControl("ddlDraftTp");
            DropDownList ddlUrlTp = (DropDownList)thisRow.Cells[12].FindControl("ddlUrlTp");

            //DataView dv = GetDataSource();
            //ddlImgUrl.DataSource = dv;
            //dv.Sort = "filename ASC";
            //ddlImgUrl.DataTextField = "filename";
            //ddlImgUrl.DataValueField = "filename";
            //ddlImgUrl.DataBind();
            DateTime addate = DateTime.ParseExact(thisRow.Cells[3].Text.Trim(), "yyyy/MM/dd", null);
            if (DateTime.Today > addate)
            {
                JavaScript.AlertMessage(this.Page, "今天之前的廣告資料不能修改");
                return;
            }
            else
            {
                //檢查logfile中是否有為欲修改資料播出日的紀錄，
                //如果有就發message，要先delete之後才可以修改落版資料
                //				Advertisements adr11 = new Advertisements();
                bool xmlExist = myAdr.CheckXmlFileLog(addate.ToString("yyyyMMdd"));
                if (xmlExist)
                {
                    JavaScript.AlertMessage(this.Page, "已經產生過該日廣告落版的XML檔案，如要修改廣告落版資料請先刪除該檔案");
                    return;	//廣告資料不能修改
                }
                else
                {
                    //廣告圖檔的選單連結
                    DataView dv = GetDataSource();
                    ddlImgUrl.DataSource = dv;
                    dv.Sort = "filename ASC";
                    ddlImgUrl.DataTextField = "filename";
                    ddlImgUrl.DataValueField = "filename";
                    ddlImgUrl.DataBind();
                }
            }

            lblEAlttext.Visible = false;
            lblEnavurl.Visible = false;
            lblEremark.Visible = false;
            lblImgUrl.Visible = false;
            lblDraftTp.Visible = false;
            lblUrlTp.Visible = false;

            tbxalttext.Visible = true;
            tbxnavurl.Visible = true;
            tbxremark.Visible = true;
            ddlImgUrl.Visible = true;
            ddlDraftTp.Visible = true;
            ddlUrlTp.Visible = true;

            LinkButton btnEdit_Click = (LinkButton)sender;
            LinkButton SubBtn = (LinkButton)thisRow.Cells[1].FindControl("SubBtn");
            LinkButton CancelBtn = (LinkButton)thisRow.Cells[1].FindControl("CancelBtn");

            btnEdit_Click.Visible = false;
            SubBtn.Visible = true;
            CancelBtn.Visible = true;
        }

        protected void SubBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((LinkButton)sender).Parent.Parent as GridViewRow;  //此段取到該Row

            Label lblEAlttext = (Label)thisRow.Cells[4].FindControl("lblEAlttext");
            Label lblEnavurl = (Label)thisRow.Cells[7].FindControl("lblEnavurl");
            Label lblEremark = (Label)thisRow.Cells[9].FindControl("lblEremark");
            Label lblImgUrl = (Label)thisRow.Cells[10].FindControl("lblImgUrl");
            Label lblDraftTp = (Label)thisRow.Cells[11].FindControl("lblDraftTp");
            Label lblUrlTp = (Label)thisRow.Cells[12].FindControl("lblUrlTp");

            TextBox tbxalttext = (TextBox)thisRow.Cells[4].FindControl("tbxalttext");
            TextBox tbxnavurl = (TextBox)thisRow.Cells[7].FindControl("tbxnavurl");
            TextBox tbxremark = (TextBox)thisRow.Cells[9].FindControl("tbxremark");
            DropDownList ddlImgUrl = (DropDownList)thisRow.Cells[10].FindControl("ddlImgUrl");
            DropDownList ddlDraftTp = (DropDownList)thisRow.Cells[11].FindControl("ddlDraftTp");
            DropDownList ddlUrlTp = (DropDownList)thisRow.Cells[12].FindControl("ddlUrlTp");

            LinkButton SubBtn_Click = (LinkButton)sender;
            LinkButton btnEdit = (LinkButton)thisRow.Cells[1].FindControl("btnEdit");
            LinkButton CancelBtn = (LinkButton)thisRow.Cells[1].FindControl("CancelBtn");

            //合約編號
            string contno = lblContNo.Text.Trim();
            //廣告序號
            string seq = thisRow.Cells[2].Text.Trim();
            //廣告日期
            string STRaddate = "";
            try
            {
                STRaddate = DateTime.ParseExact(thisRow.Cells[3].Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
            }
            catch
            {
                throw new Exception("廣告日期格式轉換錯誤");
            }
            //廣告標語
            string STRalttext = tbxalttext.Text.Trim();
            //廣告頁面，hidden column
            //string adcate = dgi.Cells[12].Text.Trim;
            //廣告位置
            //string keyword = dgi.Cells[13].Text.Trim;
            //廣告連結
            string STRnavurl = tbxnavurl.Text.Trim();
            if (!STRnavurl.ToLower().StartsWith("http://"))
                if (STRnavurl.Trim() != "")
                    STRnavurl = "http://" + STRnavurl;
            //播放機率
            //string impr = dgi.Cells[7].Text.Trim;
            //廣告備註
            string STRremark = tbxremark.Text.Trim();
            //廣告圖檔
            string STRimgurl = ddlImgUrl.SelectedItem.Value;

            //圖檔稿類別
            string STRdrafttp = ddlDraftTp.SelectedItem.Value;
            //網頁槁類別
            string STRurltp = ddlUrlTp.SelectedItem.Value;
            //Response.Write("UPDATE c4_adr SET adr_alttext=" + STRalttext + ", adr_navurl=" + STRnavurl + ", adr_remark=" + STRremark + ", adr_imgurl=" + STRimgurl + ", adr_drafttp=" + STRdrafttp + ", adr_urltp=" + STRurltp + " WHERE adr_syscd='C4' AND adr_contno=" + contno + " AND adr_seq=" + seq + " AND adr_addate=" + STRaddate);


            myAdr.UpdateAdrFileUp(contno, seq, STRaddate, STRalttext, STRnavurl, STRremark, STRimgurl, STRdrafttp, STRurltp);

            SubBtn_Click.Visible = false;
            btnEdit.Visible = true;
            CancelBtn.Visible = false;

            JavaScript.AlertMessageRedirect(this.Page, "修改成功", "AdrFileUp.aspx?NewContNo=" + Request.QueryString["NewContNo"].ToString());
        }

        protected void CancelBtn_Click(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((LinkButton)sender).Parent.Parent as GridViewRow;  //此段取到該Row

            Label lblEAlttext = (Label)thisRow.Cells[4].FindControl("lblEAlttext");
            Label lblEnavurl = (Label)thisRow.Cells[7].FindControl("lblEnavurl");
            Label lblEremark = (Label)thisRow.Cells[9].FindControl("lblEremark");
            Label lblImgUrl = (Label)thisRow.Cells[10].FindControl("lblImgUrl");
            Label lblDraftTp = (Label)thisRow.Cells[11].FindControl("lblDraftTp");
            Label lblUrlTp = (Label)thisRow.Cells[12].FindControl("lblUrlTp");

            TextBox tbxalttext = (TextBox)thisRow.Cells[4].FindControl("tbxalttext");
            TextBox tbxnavurl = (TextBox)thisRow.Cells[7].FindControl("tbxnavurl");
            TextBox tbxremark = (TextBox)thisRow.Cells[9].FindControl("tbxremark");
            DropDownList ddlImgUrl = (DropDownList)thisRow.Cells[10].FindControl("ddlImgUrl");
            DropDownList ddlDraftTp = (DropDownList)thisRow.Cells[11].FindControl("ddlDraftTp");
            DropDownList ddlUrlTp = (DropDownList)thisRow.Cells[12].FindControl("ddlUrlTp");

            lblEAlttext.Visible = true;
            lblEnavurl.Visible = true;
            lblEremark.Visible = true;
            lblImgUrl.Visible = true;
            lblDraftTp.Visible = true;
            lblUrlTp.Visible = true;

            tbxalttext.Visible = false;
            tbxnavurl.Visible = false;
            tbxremark.Visible = false;
            ddlImgUrl.Visible = false;
            ddlDraftTp.Visible = false;
            ddlUrlTp.Visible = false;


            LinkButton CancelBtn_Click = (LinkButton)sender;
            LinkButton SubBtn = (LinkButton)thisRow.Cells[1].FindControl("SubBtn");
            LinkButton btnEdit = (LinkButton)thisRow.Cells[1].FindControl("btnEdit");


            CancelBtn_Click.Visible = false;
            SubBtn.Visible = false;
            btnEdit.Visible = true;

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            Bind_ddlImages();
            JavaScript.AlertMessage(this.Page, "更新完成");
        }

        protected void btnDateSetImage_Click(object sender, EventArgs e)
        {
            //Response.Write(dgdAdr.Rows[0].Cells[2].Text);
            //Response.Write(((Label)dgdAdr.Rows[0].Cells[7].FindControl("lblEnavurl")).Text);
            //return;
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
                JavaScript.AlertMessage(this.Page, "不能修改今天之前的廣告資料");
                return;
            }

            ArrayList ary = new ArrayList();
            for (int i = 0; i < dgdAdr.Rows.Count; i++)
            {
                string adrseq = dgdAdr.Rows[i].Cells[2].Text.Trim();
                //廣告日期
                string addate = "";
                try
                {
                    addate = DateTime.ParseExact(dgdAdr.Rows[i].Cells[3].Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
                }
                catch
                {
                    JavaScript.AlertMessage(this.Page, "廣告日期格式錯誤");
                    return;
                }
                if ((DateTime.ParseExact(sdate, "yyyyMMdd", null) <= DateTime.ParseExact(addate, "yyyyMMdd", null))
                    && (DateTime.ParseExact(addate, "yyyyMMdd", null) <= DateTime.ParseExact(edate, "yyyyMMdd", null)))
                {
                    //					jsAlertMsg("SDATEFORMATERROR", "廣告日期"+addate);
                    string alttext;
                    if (cbxAltText.Checked == true)
                        //廣告標語要更新
                        alttext = tbxAltText.Text.Trim();
                    else
                        alttext = ((Label)dgdAdr.Rows[0].Cells[4].FindControl("lblEAlttext")).Text.Trim();
                    alttext = this.myTrimEnd(alttext);
                    //廣告頁面，hidden column
                    //string adcate = dgi.Cells[12].Text.Trim;
                    //廣告位置
                    //string keyword = dgi.Cells[13].Text.Trim;
                    //廣告連結
                    string navurl;
                    if (cbxLink.Checked == true)
                        navurl = tbxNavUrl.Text.Trim();
                    else
                        navurl = ((Label)dgdAdr.Rows[0].Cells[7].FindControl("lblEnavurl")).Text.Trim();
                    navurl = this.myTrimEnd(navurl);
                    if (!navurl.ToLower().StartsWith("http://"))
                        if (navurl.Trim() != "")
                            navurl = "http://" + navurl;

                    //廣告備註
                    string remark = ((Label)dgdAdr.Rows[0].Cells[9].FindControl("lblEremark")).Text.Trim();
                    remark = this.myTrimEnd(remark);
                    //廣告圖檔
                    string imgurl;
                    if (cbxImage.Checked == true)
                        imgurl = ddlImages.SelectedItem.Value.Trim();
                    else
                        imgurl = ((Label)dgdAdr.Rows[i].Cells[10].FindControl("lblImgUrl")).Text.Trim();
                    //圖檔稿類別
                    string drafttp = "1"; //通通設定為舊槁，再由美編去指定新稿
                    //網頁槁類別
                    string urltp = "1"; //通通設定為舊槁

                    myAdr.UpdateAdrFileUp(contno, adrseq, addate, alttext, navurl, remark, imgurl, drafttp, urltp);
                    //					ary.Add(contno + "," + adrseq + "," + addate + "," + alttext + "," + navurl + "," + remark + "," + imgurl + "," + drafttp + "," + urltp);
                }
            }
            Bind_NewAdr(contno);
        }

        protected string myTrimEnd(string oldstr)
        {
            if (oldstr == "&nbsp;")
            {
                return "";
            }
            return oldstr;
        }

        protected void dlImageList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                // Retrieve the Label control in the current DataListItem.

                Image PriceLabel = (Image)e.Item.FindControl("imgAdrImage");
                Label lblFileName = (Label)e.Item.FindControl("lblFileName");
                //string path = CommonUtil.config_FileUploadPath;//本機上直接使用路徑
                string path = Server.MapPath("~/UserImages");//20120222修改 因為nas不能用網路磁碟機 所以只能放在Web目錄底下
                PriceLabel.ImageUrl = "ImagePage.aspx?filename=" + path + "\\" + lblFileName.Text;
            }
        }

        protected void btnSetImage_Click(object sender, EventArgs e)
        {
            string contno = lblContNo.Text.Trim();

            ArrayList ary = new ArrayList();
            for (int i = 0; i < dgdAdr.Rows.Count; i++)
            {
                if (((CheckBox)dgdAdr.Rows[i].Cells[0].FindControl("cbxDelAdr")).Checked)
                {
                    string adrseq = dgdAdr.Rows[i].Cells[2].Text.Trim();
                    //廣告日期
                    string addate = "";
                    try
                    {
                        addate = DateTime.ParseExact(dgdAdr.Rows[i].Cells[3].Text.Trim(), "yyyy/MM/dd", null).ToString("yyyyMMdd");
                    }
                    catch
                    {
                        throw new Exception("廣告日期格式轉換錯誤");
                    }
                    string alttext;
                    if (cbxAltText.Checked == true)
                        //廣告標語要更新
                        alttext = tbxAltText.Text.Trim();
                    else
                        alttext = ((Label)dgdAdr.Rows[i].Cells[4].FindControl("lblEAlttext")).Text.Trim();
                    alttext = this.myTrimEnd(alttext);
                    //廣告頁面，hidden column
                    //string adcate = dgi.Cells[12].Text.Trim;
                    //廣告位置
                    //string keyword = dgi.Cells[13].Text.Trim;
                    //廣告連結
                    string navurl;
                    if (cbxLink.Checked == true)
                        navurl = tbxNavUrl.Text.Trim();
                    else
                        navurl = ((Label)dgdAdr.Rows[i].Cells[7].FindControl("lblEnavurl")).Text.Trim();
                    navurl = this.myTrimEnd(navurl);
                    if (!navurl.ToLower().StartsWith("http://"))
                        if (navurl.Trim() != "")
                            navurl = "http://" + navurl;

                    //廣告備註
                    string remark = ((Label)dgdAdr.Rows[i].Cells[9].FindControl("lblEremark")).Text.Trim();
                    remark = this.myTrimEnd(remark);
                    //廣告圖檔
                    string imgurl;
                    if (cbxImage.Checked == true)
                        imgurl = ddlImages.SelectedItem.Value.Trim();
                    else
                        imgurl = ((Label)dgdAdr.Rows[i].Cells[10].FindControl("lblImgUrl")).Text.Trim();
                    //圖檔稿類別
                    string drafttp = "1"; //通通設定為舊槁，再由美編去指定新稿
                    //網頁槁類別
                    string urltp = "1"; //通通設定為舊槁

                    myAdr.UpdateAdrFileUp(contno, adrseq, addate, alttext, navurl, remark, imgurl, drafttp, urltp);
                    //					ary.Add(contno + "," + adrseq + "," + addate + "," + alttext + "," + navurl + "," + remark + "," + imgurl + "," + drafttp + "," + urltp);
                }
            }

            Bind_NewAdr(contno);
        }

        protected void SaveAsBtn_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                string path = Server.MapPath("~/UserImages");//20120222修改 因為nas不能用網路磁碟機 所以只能放在Web目錄底下
                //string path = CommonUtil.config_FileUploadPath;//本機上直接使用路徑
                string filename = FileUpload1.FileName;
                try
                {
                    FileUpload1.PostedFile.SaveAs(path + "\\" + filename);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                Bind_ddlImages();
                LoadImages();
            }
        }
    }
}