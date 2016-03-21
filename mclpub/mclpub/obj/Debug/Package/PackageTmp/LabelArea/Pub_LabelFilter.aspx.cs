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


namespace mclpub.LabelArea
{
    public partial class Pub_LabelFilter : System.Web.UI.Page
    {
        Pub_labelFilter_DB myPub = new Pub_labelFilter_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitialData();
            }
        }

        // 給預設值
        private void InitialData()
        {
            this.lblMessage.Text = "";
            this.btnPrintLabel.Visible = false;
            this.btnPrintList.Visible = false;
            SearchIcon.Visible = false;

            // 顯示下拉式選單 書籍類別的 DB 值
            DataSet ds1 = myPub.GetFreeBook();
            ddlBookCode.DataSource = ds1;
            ddlBookCode.DataTextField = "fc_nm";
            ddlBookCode.DataValueField = "fc_fccd";
            ddlBookCode.DataBind();

            this.tbxPubDate.Text = System.DateTime.Today.ToString("yyyy/MM");


            // 顯示下拉式選單 業務員 DB 值
            // 關於 nostr, 請參 sqlDataAdapter3.Select statement;
            // nostr = dbo.book.bk_bkcd + dbo.proj.proj_projno + dbo.proj.proj_costctr AS nostr
            DataSet ds2 = myPub.GetSrspns();
            DataRow dr = ds2.Tables[0].NewRow();
            dr["srspn_empno"] = "000000";
            dr["srspn_cname"] = "請選擇";
            ds2.Tables[0].Rows.Add(dr);

            ds2.Tables[0].DefaultView.Sort = "srspn_empno ASC";
            DataView dv2 = ds2.Tables[0].DefaultView;
            dv2.RowFilter = "";
            ddlEmpNo.DataSource = dv2;
            ddlEmpNo.DataTextField = "srspn_cname";
            ddlEmpNo.DataValueField = "srspn_empno";
            ddlEmpNo.DataBind();

            // 顯示下拉式選單 郵寄類別 DB 值
            DataSet ds3 = myPub.GetMailType();
            DataRow dr2 = ds3.Tables[0].NewRow();
            dr2["mtp_mtpcd"] = "00";
            dr2["mtp_nm"] = "請選擇";
            ds3.Tables[0].Rows.Add(dr2);

            ds3.Tables[0].DefaultView.Sort = "mtp_mtpcd ASC";
            DataView dv3 = ds3.Tables[0].DefaultView;
            ddlMtpcd.DataSource = dv3;
            ddlMtpcd.DataTextField = "mtp_nm";
            ddlMtpcd.DataValueField = "mtp_mtpcd";
            ddlMtpcd.DataBind();
        }


        private DataView Bind()
        {
            string strfilter = GetFilters();
            DataSet ds = myPub.GetLabelWithFilter(strfilter);
            DataView dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "fgpub = '1'";
            return dv;
        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
            SearchIcon.Visible = true;
            string yyyymm = tbxPubDate.Text.Substring(0, 4) + tbxPubDate.Text.Substring(5, 2);
            if (myPub.CreateLabelList(yyyymm))
            {
                hiddenBookPno.Value = myPub.GetBookPno(ddlBookCode.SelectedItem.Value.Trim(), yyyymm);

                this.btnPrintLabel.Visible = true;
                this.btnPrintList.Visible = true;

                Bind();
                ////顯示查詢結果 -- 有登本數
                //string strfilter = GetFilters();
                //DataSet ds = myPub.GetLabelWithFilter(strfilter);
                //DataView dv = ds.Tables[0].DefaultView;
                //dv.RowFilter = "fgpub = '1'";

                if (Bind().Count == 0)
                {
                    btnPrintLabel.Visible = false;
                    btnPrintList.Visible = false;
                    lblMessage.Visible = false;
                }
                else
                {
                    btnPrintLabel.Visible = true;
                    btnPrintList.Visible = true;
                    lblMessage.Visible = true;
                }
                dgdLabel.DataSource = Bind();
                dgdLabel.DataBind();
                lblMessage.Text = "查詢結果:共有 " + Bind().Count.ToString() + " 筆資料";
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.Text = "產生標籤資料發生錯誤, 請稍後再試或聯絡相關人員!!";
            }
        }

        #region 組合查詢條件
        /// <summary>
        /// 組合查詢條件
        /// </summary>
        /// <returns>組合後的條件字串</returns>
        private string GetFilters()
        {
            string strBkcd = this.ddlBookCode.SelectedItem.Value.ToString();
            string strYYYYMM = this.tbxPubDate.Text.ToString().Trim();
            strYYYYMM = strYYYYMM.Substring(0, 4) + strYYYYMM.Substring(5, 2);
            string strEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
            string strConttp = this.ddlConttp.SelectedItem.Value.ToString();
            string fgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();
            string strMtpcd = this.ddlMtpcd.SelectedItem.Value.ToString();

            string strFilter = "";

            strFilter = " (fbk_bkcd = '" + ddlBookCode.SelectedItem.Value.Trim() + "')"
                + " AND (ma_sdate <= '" + strYYYYMM + "')"
                + " AND (ma_edate >= '" + strYYYYMM + "')"
                + " AND (cont_conttp = '" + ddlConttp.SelectedItem.Value.Trim() + "')"
                + " AND (or_fgmosea = '" + ddlfgMOSea.SelectedItem.Value.Trim() + "')";

            if (ddlMtpcd.SelectedItem.Value.ToString().Trim() != "00")
            {
                strFilter += " AND (ma_mtpcd = '" + ddlMtpcd.SelectedItem.Value.Trim() + "')";
            }
            if (ddlEmpNo.SelectedItem.Value.Trim() != "000000")
            {
                strFilter += " AND (cont_empno = '" + ddlEmpNo.SelectedItem.Value.Trim() + "')";
            }

            return strFilter;
        }
        #endregion

        protected void btnPrintList_Click(object sender, EventArgs e)
        {
            DataView dv = Bind();
            DataTable dt = Bind().ToTable();

            Response.Clear();
            ExcelFile Xls = new XlsFile(true);
            string fileSpec = Server.MapPath("~/LabelArea/Template/Pub_LabelList.xls");
            Xls.Open(fileSpec);
            Xls.ActiveSheet = 1;

            TXlsCellRange myRange = new TXlsCellRange("A8:J8");
            TXlsCellRange myRangeBlue = new TXlsCellRange("A9:J9");
            TXlsCellRange myRange2 = new TXlsCellRange("A1:J1");

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
                    for (int i = 10; i < dt.Rows.Count + 10 - 2; i++)
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
            Xls.InsertAndCopyRange(myRange2, dt.Rows.Count + 7 + 3, 1, 1, TFlxInsertMode.NoneDown, TRangeCopyMode.All, Xls, 2);

            Xls.SetCellValue(2, 1, ddlBookCode.SelectedItem.Text.ToString().Trim() + "(第 " + hiddenBookPno.Value.Trim() + " 期)");
            Xls.SetCellValue(3, 3, tbxPubDate.Text.Trim());
            Xls.SetCellValue(4, 3, ddlConttp.SelectedItem.Text.ToString().Trim() + "合約");
            Xls.SetCellValue(5, 3, ddlEmpNo.SelectedItem.Value.ToString().Trim() == "000000" ? "(所有)" : ddlEmpNo.SelectedItem.Text.ToString().Trim());
            Xls.SetCellValue(6, 3, ddlMtpcd.SelectedItem.Value.ToString().Trim() == "00" ? "(所有)" : ddlMtpcd.SelectedItem.Text.ToString().Trim());
            Xls.SetCellValue(5, 7, Account.GetAccInfo().srspn_cname.ToString().Trim());
            Xls.SetCellValue(6, 7, DateTime.Now.ToString("yyyy/MM/dd"));
            string strdate1 = "";
            string strdate2 = "";
            string strdate3 = "";
            string strdate4 = "";
            int count = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Xls.SetCellValue(i + 8, 1, i + 1);
                Xls.SetCellValue(i + 8, 2, dt.Rows[i]["cont_contno"].ToString());
                strdate1 = dt.Rows[i]["cont_sdate"].ToString() == "" ? "" : dt.Rows[i]["cont_sdate"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["cont_sdate"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["cont_sdate"].ToString().Substring(6, 2);
                strdate2 = dt.Rows[i]["cont_edate"].ToString() == "" ? "" : dt.Rows[i]["cont_edate"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["cont_edate"].ToString().Substring(4, 2) + "/" + dt.Rows[i]["cont_edate"].ToString().Substring(6, 2);
                Xls.SetCellValue(i + 8, 3, strdate1 + "~" + strdate2);
                strdate3 = dt.Rows[i]["ma_sdate"].ToString() == "" ? "" : dt.Rows[i]["ma_sdate"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["ma_sdate"].ToString().Substring(4, 2);
                strdate4 = dt.Rows[i]["ma_edate"].ToString() == "" ? "" : dt.Rows[i]["ma_edate"].ToString().Substring(0, 4) + "/" + dt.Rows[i]["ma_edate"].ToString().Substring(4, 2);
                Xls.SetCellValue(i + 8, 4, strdate3 + "~" + strdate4);
                Xls.SetCellValue(i + 8, 5, dt.Rows[i]["or_inm"].ToString());
                Xls.SetCellValue(i + 8, 6, dt.Rows[i]["or_nm"].ToString() + " " + dt.Rows[i]["or_jbti"].ToString());
                Xls.SetCellValue(i + 8, 7, dt.Rows[i]["or_zip"].ToString() + " " + dt.Rows[i]["or_addr"].ToString());
                Xls.SetCellValue(i + 8, 8, dt.Rows[i]["srspn_cname"].ToString());
                Xls.SetCellValue(i + 8, 9, dt.Rows[i]["mtp_nm"].ToString());
                Xls.SetCellValue(i + 8, 10, dt.Rows[i]["ma_mnt"].ToString());
                count = count + Convert.ToInt32(dt.Rows[i]["ma_mnt"].ToString());
            }

            Xls.SetCellValue(dt.Rows.Count + 3 + 7, 10, count);

            Xls.ActiveSheet = 2;
            Xls.DeleteRange(myRange2, TFlxInsertMode.NoneDown);
            Xls.ActiveSheet = 1;

            Common.excuteExcel(Xls, "Pub_LabelList.xls");
        }

        protected void btnPrintLabel_Click(object sender, EventArgs e)
        {
            // 抓出篩選條件
            Session["MAILLABEL"] = GetFilters();
            string fgMOSea = this.ddlfgMOSea.SelectedItem.Value.ToString().Trim();

            string strbuf;
            strbuf = "PubFm_label_Internet.aspx?fgmosea=" + fgMOSea + "&bkpno=" + hiddenBookPno.Value.Trim();

            this.ClientScript.RegisterStartupScript(typeof(string), "", "<script>window.open(\"" + strbuf + "\");</script>");
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }
    }
}