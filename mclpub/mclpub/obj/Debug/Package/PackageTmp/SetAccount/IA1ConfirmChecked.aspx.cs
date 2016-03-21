using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FlexCel.Core;
using FlexCel.XlsAdapter;
using FlexCel.Render;

namespace mclpub.SetAccount
{
    public partial class IA1ConfirmChecked : System.Web.UI.Page
    {
        security sec = new security();
        IA1ConfirmChecked_DB myia1 = new IA1ConfirmChecked_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string contno = "";
                    string imseq = "";

                    contno = sec.decryptquerystring(Request.QueryString["ContNo"].ToString().Trim());
                    imseq = Request.QueryString["ImSeq"].ToString().Trim();

                    LoadContData(contno, imseq);
                }
                catch (Exception ex)
                {
                    throw new Exception("無合約編號，程式錯誤，請通知聯絡人");
                }
            }
        }

        #region 載入合約資料
        private void LoadContData(string contno, string imseq)
        {
            if (contno.Trim() == "")
                throw new Exception("合約編號不可為空白");

            DataSet ds = myia1.GetSingleContractByContNo(contno);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count>0)
            {
                lblContNo.Text = dt.Rows[0]["cont_contno"].ToString();

                switch (dt.Rows[0]["cont_conttp"].ToString().Trim())
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

                lblSignDate.Text = DateTime.ParseExact(dt.Rows[0]["cont_signdate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
                lblSDate.Text = DateTime.ParseExact(dt.Rows[0]["cont_sdate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
                lblEDate.Text = DateTime.ParseExact(dt.Rows[0]["cont_edate"].ToString(), "yyyyMMdd", null).ToString("yyyy/MM/dd");
                lblPubTm.Text = dt.Rows[0]["cont_pubtm"].ToString();
                lblFreeTm.Text = dt.Rows[0]["cont_freetm"].ToString();
                lblTotAmt.Text = dt.Rows[0]["cont_totamt"].ToString();
                lblDisc.Text = dt.Rows[0]["cont_disc"].ToString();
                lblTotImgTm.Text = dt.Rows[0]["cont_totimgtm"].ToString();
                lblTotUrlTm.Text = dt.Rows[0]["cont_toturltm"].ToString();

                //Message
                lblContInfo.Text = "本合約基本資料";

                //Load InvMfr
                //				Bind_ddlInvMfr(contno);

                //Load Advertisements
                LoadAdr(contno, imseq);
            }
            else
            {
                //Message
                lblContInfo.Text = "無此編號的合約資料，請確認合約編號";
            }
        }
        #endregion


        #region 載入發票主檔及明細資料
        private void LoadAdr(string contno, string imseq)
        {
            if (contno == null || contno.Trim().Length != 6)
            {
                JavaScript.AlertMessage(this.Page, "合約編號為空值或格式錯誤，請通知聯絡人");
                return;
            }

            DataSet ds1 = myia1.GetInvMfr(contno);
            DataView dv1 = ds1.Tables[0].DefaultView;
            dv1.RowFilter = "im_imseq='" + imseq + "'";//只有指定發票廠商的資料會出現
            lblMfrno.Text = dv1[0].Row["im_mfrno"].ToString();
            lblNm.Text = dv1[0].Row["im_nm"].ToString();
            lblAddr.Text = dv1[0].Row["im_addr"].ToString();
            lblZip.Text = dv1[0].Row["im_zip"].ToString();
            lblJbti.Text = dv1[0].Row["im_jbti"].ToString();
            lblTel.Text = dv1[0].Row["im_tel"].ToString();
            lblInvcd1.Text = dv1[0].Row["im_invcd"].ToString();
            lblInvcd.Text = dv1[0].Row["invcd"].ToString();
            lblTaxtp1.Text = dv1[0].Row["im_taxtp"].ToString();
            lblTaxtp.Text = dv1[0].Row["taxtp"].ToString();
            lblFgitri1.Text = dv1[0].Row["im_fgitri"].ToString();
            lblProjNo.Text = dv1[0].Row["proj_projno"].ToString();
            switch (lblFgitri1.Text.Trim())
            {
                case "06":
                    lblFgitri.Text = "所內";
                    break;
                case "07":
                    lblFgitri.Text = "院內";
                    break;
                case "":
                    lblFgitri.Text = "";
                    break;
            }

            DataSet ds = myia1.GetAdvertisements(contno);
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "adr_fginved='v' and adr_imseq='" + imseq + "'";
            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();
            lblCount.Text = "<<共 " + dv.Count.ToString() + " 筆明細資料>>";
            int pyat = 0;
            for (int i = 0; i < DataGrid1.Rows.Count; i++)
            {
                pyat += Convert.ToInt32(DataGrid1.Rows[i].Cells[10].Text);
            }
            lblPyat.Text = pyat.ToString();

        }
        #endregion

        protected void DataGrid1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            string contno, imseq;
            contno = Request.QueryString["ContNo"].ToString().Trim();
            imseq = Request.QueryString["ImSeq"].Trim();
            Response.Redirect("IA1QueryCont.aspx?ContNo=" + contno.Trim() + "&ImSeq=" + imseq.Trim());
        }

        protected void btnModifyAdr_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Layout/AdrPublish.aspx?NewContNo=" + sec.encryptquerystring(lblContNo.Text.Trim()));
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            //條件應為合約編號與fginved='v'
            string contno, imseq;
            contno =sec.decryptquerystring(Request.QueryString["ContNo"].ToString().Trim());
            imseq = Request.QueryString["ImSeq"].ToString().Trim();

            bool errorflg = myia1.AddIa(contno, imseq,Account.GetAccInfo().srspn_empno.ToString().Trim());
            if (errorflg)
            {
                JavaScript.AlertMessage(this.Page, "新增發票開立單作業完成");
                pnlAdr.Visible = false;
                pnlNext.Visible = true;
            }
            else
                JavaScript.AlertMessage(this.Page, "新增發票開立單作業發生錯誤, 請重新新增或稍後再進行");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        #region 沒有再用了
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //沒有再用了
            try
            {
                string contno = "";
                string imseq = "";

                contno = sec.decryptquerystring(Request.QueryString["ContNo"].ToString().Trim());
                imseq = Request.QueryString["ImSeq"].ToString().Trim();
                //抓到該匯出的EXCEL所屬TABLE
                DataSet ds = myia1.sp_c4_ia_prelistNew(contno, imseq);
                DataTable dt = ds.Tables[0];

                Response.Clear();
                ExcelFile Xls = new XlsFile(true);
                string fileSpec = Server.MapPath("~/SetAccount/template/RptIA1_PreList1.xls");
                Xls.Open(fileSpec);
                Xls.ActiveSheet = 1;

                TXlsCellRange myRange = new TXlsCellRange("A5:V5");
                TXlsCellRange myRangeBlue = new TXlsCellRange("A6:V6");
                TXlsCellRange myRangeTotal = new TXlsCellRange("A1:V1");

                if (dt.Rows.Count == 1)
                {
                    Xls.DeleteRange(myRangeBlue, TFlxInsertMode.NoneDown);//只有一筆的話刪除第一區塊的藍色
                    //下面一個迴圈添加單一筆內所有資料
                }
                else
                {
                    if (dt.Rows.Count > 2)
                    {
                        int countback = 0;
                        //兩筆的話就不用動任何迴圈
                        for (int i = 7; i < dt.Rows.Count + 7 - 2; i++)
                        {
                            countback++;
                            if (countback % 2 == 0)
                            {
                                //藍色
                                Xls.InsertAndCopyRange(myRangeBlue, i, 1, 1, TFlxInsertMode.NoneDown);

                            }
                            else
                            {
                                //白色
                                Xls.InsertAndCopyRange(myRange, i, 1, 1, TFlxInsertMode.NoneDown);
                            }
                        }
                    }
                }

                Xls.SetCellValue(3, 4, Account.GetAccInfo().srspn_cname.ToString().Trim());


                string contno_pre = "";
                int idx = 1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["cont_contno"].ToString() == contno_pre)
                    {

                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("IA1QueryCont.aspx?ContNo=" + Request.QueryString["ContNo"].Trim() + "&ImSeq=00");
        }

        protected void btnGoIA1_Click(object sender, EventArgs e)
        {
            Response.Redirect("IA1Query.aspx");
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}