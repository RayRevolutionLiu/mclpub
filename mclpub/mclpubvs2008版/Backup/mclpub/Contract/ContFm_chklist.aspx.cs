using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Contract
{
    public partial class ContFm_chklist : System.Web.UI.Page
    {
        ContFm_chklist_DB myCont = new ContFm_chklist_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.SearchIcon.Visible = false;
                lbNoCount.Visible = false;
                InitialData();
            }
        }

        // 預設值
        private void InitialData()
        {
            // 簽約日期區間
            //this.tbxSignDate1.Text = System.DateTime.Today.ToString("yyyy/MM/dd");
            //this.tbxSignDate2.Text = System.DateTime.Today.ToString("yyyy/MM/dd");

            //// 合約起迄區間
            //this.tbxSDate.Text = System.DateTime.Today.ToString("yyyy") + "01";
            //this.tbxEDate.Text = System.DateTime.Today.ToString("yyyy") + "12";


            // 顯示下拉式選單 業務員的 DB 值
            // **注意: 原本資料庫內之 srspn_cname & srspn_empno 是 char(x) 型態, 故其 sqlDataAdapter4 裡, 要先做 RTRIM 的處理 (如 RTRIM(srspn_cname) AS srspn_cname), 否則其值會含有空白, 如 '800443 ', '康靜怡     ' .
            DataSet ds5 = myCont.SelectSrspn();
            DataRow dr = ds5.Tables["srspn"].NewRow();
            dr["srspn_empno"] = "000000";
            dr["srspn_cname"] = "請選擇";
            ds5.Tables["srspn"].Rows.Add(dr);
            ds5.Tables["srspn"].DefaultView.Sort = "srspn_empno ASC";
            this.ddlEmpNo.DataSource = ds5.Tables["srspn"].DefaultView;
            this.ddlEmpNo.DataTextField = "srspn_cname";
            this.ddlEmpNo.DataValueField = "srspn_empno";
            this.ddlEmpNo.DataBind();

            // 合約編號及廠商名稱
            this.tbxContNo.Text = "";
            this.tbxMfrIName.Text = "";

            //如果是D級管理者，僅能查看到自己的客戶資料
            if (Account.GetAccInfo().srspn_atype.ToString().Trim() != "")
            {
                if (Account.GetAccInfo().srspn_atype.ToString().Trim() == "D")
                {
                    if (this.ddlEmpNo.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()) != null)
                    {
                        this.ddlEmpNo.Items.FindByValue(Account.GetAccInfo().srspn_empno.ToString().Trim()).Selected = true;
                        this.ddlEmpNo.Enabled = false;
                    }
                }
            }
        }

        public DataView BindList()
        {
            // 抓出篩選條件
            // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
            string rowfilterstr1 = " (1=1) ";

            // 簽約日期區間
            if (tbxSignDate1.Text.Trim() != "" && tbxSignDate2.Text.Trim() != "")
            {
                string strSignDate1, strSignDate2;
                strSignDate1 = this.tbxSignDate1.Text.Substring(0, 4) + this.tbxSignDate1.Text.Substring(5, 2) + this.tbxSignDate1.Text.Substring(8, 2);
                strSignDate2 = this.tbxSignDate2.Text.Substring(0, 4) + this.tbxSignDate2.Text.Substring(5, 2) + this.tbxSignDate2.Text.Substring(8, 2);

                rowfilterstr1 = rowfilterstr1 + " AND (cont_signdate >= '" + strSignDate1 + "')";
                rowfilterstr1 = rowfilterstr1 + " AND (cont_signdate <= '" + strSignDate2 + "')";
            }

            // 若勾選查詢條件一時 - 合約起迄區間
            if (tbxSDate.Text.Trim() != "" && tbxEDate.Text.Trim() != "")
            {
                string strSDate, strEDate;
                strSDate = this.tbxSDate.Text.ToString().Trim();
                strEDate = this.tbxEDate.Text.ToString().Trim();

                rowfilterstr1 = rowfilterstr1 + " AND (cont_sdate >= '" + strSDate + "') ";
                rowfilterstr1 = rowfilterstr1 + " AND (cont_edate <= '" + strEDate + "') ";
            }

            // 若勾選查詢條件二時 - 已結案
            if (ddlfgclosed.SelectedItem.Value.ToString().Trim() != "99")
            {
                string strfgclosed;
                strfgclosed = this.ddlfgclosed.SelectedItem.Value.ToString().Trim();
                rowfilterstr1 = rowfilterstr1 + " AND (cont_fgclosed='" + strfgclosed + "') ";
            }

            // 若勾選查詢條件三時 - 承辦業務員
            if (ddlEmpNo.SelectedValue.ToString().Trim() != "000000")
            {
                string strEmpNo;
                strEmpNo = this.ddlEmpNo.SelectedItem.Value.ToString().Trim();
                rowfilterstr1 = rowfilterstr1 + " AND (cont_empno='" + strEmpNo + "') ";
            }

            // 若勾選查詢條件四時 - 合約書編號

            if (tbxContNo.Text.Trim() != "")
            {
                string QstrContNo;
                //this.cbx0.Checked = false;
                QstrContNo = this.tbxContNo.Text.ToString().Trim();
                rowfilterstr1 = rowfilterstr1 + " AND (cont_contno Like '%" + QstrContNo + "%') ";
            }

            // 若勾選查詢條件五時 - 廠商名稱

            if (tbxMfrIName.Text.Trim() != "")
            {
                string QstrMfrIName;
                //this.cbx0.Checked = false;
                QstrMfrIName = this.tbxMfrIName.Text.ToString().Trim();
                rowfilterstr1 = rowfilterstr1 + " AND (mfr_inm Like '%" + QstrMfrIName + "%') ";
            }


            // 使用 DataSet 方法, 並指定使用的 table 名稱
            DataSet ds1 = myCont.SelectC2_cont();
            DataView dv1 = ds1.Tables["c2_cont"].DefaultView;
            dv1.RowFilter = rowfilterstr1;

            return dv1;
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            //Response.Write(BindList().Count);
            if (BindList().Count > 0)
            {
                this.DataList1.Visible = true;
                this.SearchIcon.Visible = true;
                lbNoCount.Visible = false;
                //Response.Write("有 " + dv1.Count + " 筆資料");
                //this.lblRecordCount.Text = "查詢結果：共有 " + dv1.Count + " 筆資料!";
                DataList1.DataSource = BindList();
                DataList1.DataBind();


                for (int i = 0; i < DataList1.Items.Count; i++)
                {
                    // 簽約日期
                    string SignDate = ((Label)DataList1.Items[i].FindControl("lblSignDate")).Text;
                    SignDate = SignDate.ToString().Trim() == "" ? "" : SignDate.Substring(0, 4) + "/" + SignDate.Substring(4, 2) + "/" + SignDate.Substring(6, 2);
                    ((Label)DataList1.Items[i].FindControl("lblSignDate")).Text = SignDate;

                    // 合約類別
                    string conttp = ((Label)DataList1.Items[i].FindControl("lblConttp")).Text;
                    string ConttpName = "";
                    if (conttp == "01")
                        ConttpName = "一般合約";
                    else if (conttp == "09")
                        ConttpName = "推廣合約";
                    ((Label)DataList1.Items[i].FindControl("lblConttp")).Text = ConttpName;

                    // 合約起迄日
                    string StartDate = ((Label)DataList1.Items[i].FindControl("lblStartDate")).Text;
                    StartDate = StartDate.ToString().Trim() == "" ? "" : StartDate.Substring(0, 4) + "/" + StartDate.Substring(4, 2);
                    ((Label)DataList1.Items[i].FindControl("lblStartDate")).Text = StartDate;
                    string EndDate = ((Label)DataList1.Items[i].FindControl("lblEndDate")).Text;
                    EndDate = EndDate.ToString().Trim() == "" ? "" : EndDate.Substring(0, 4) + "/" + EndDate.Substring(4, 2);
                    ((Label)DataList1.Items[i].FindControl("lblEndDate")).Text = EndDate;

                    // 一次付款註記
                    string fgpayonce = ((Label)DataList1.Items[i].FindControl("lblfgPayonce")).Text;
                    string fgPayOnceText = "";
                    if (fgpayonce == "0")
                        fgPayOnceText = "否";
                    else
                        fgPayOnceText = "<font color='Red'>是</font>";
                    ((Label)DataList1.Items[i].FindControl("lblfgPayonce")).Text = fgPayOnceText;

                    // 結案註記
                    string fgClosed = ((Label)DataList1.Items[i].FindControl("lblfgClosed")).Text;
                    string fgClosedText = "";
                    if (fgClosed == "0")
                        fgClosedText = "否";
                    else
                        fgClosedText = "<font color='Red'>是</font>";
                    ((Label)DataList1.Items[i].FindControl("lblfgClosed")).Text = fgClosedText;

                    // 結案註記
                    string oldContNo = ((Label)DataList1.Items[i].FindControl("lblOldContNo")).Text;
                    string oldContNoText = "";
                    if (oldContNo == "0")
                        oldContNoText = "<font color='Gray'>(無)</font>";
                    else
                        oldContNoText = oldContNo;
                    ((Label)DataList1.Items[i].FindControl("lblOldContNo")).Text = oldContNoText;

                    // 建檔日期
                    string CreateDate = ((Label)DataList1.Items[i].FindControl("lblCreateDate")).Text;
                    CreateDate = CreateDate.ToString().Trim() == "" ? "" : CreateDate.Substring(0, 4) + "/" + CreateDate.Substring(4, 2) + "/" + CreateDate.Substring(6, 2);
                    ((Label)DataList1.Items[i].FindControl("lblCreateDate")).Text = CreateDate;

                    // 修改日期
                    string ModifyDate = ((Label)DataList1.Items[i].FindControl("lblModifyDate")).Text;
                    ModifyDate = ModifyDate.ToString().Trim() == "" ? "" : ModifyDate.Substring(0, 4) + "/" + ModifyDate.Substring(4, 2) + "/" + ModifyDate.Substring(6, 2);
                    ((Label)DataList1.Items[i].FindControl("lblModifyDate")).Text = ModifyDate;


                    // 先抓出 合約書編號, 以 filter 發票廠商收件人及雜誌收件人資料
                    string strContNo = ((Label)DataList1.Items[i].FindControl("lblContNo")).Text;


                    // 抓出 發票廠商收件人 DataGrid1			
                    // 使用 DataSet 方法, 並指定使用的 table 名稱
                    DataSet ds2 = myCont.SelectInvmfr();
                    DataView dv2 = ds2.Tables["invmfr"].DefaultView;

                    // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                    string rowfilterstr2 = "1=1";
                    rowfilterstr2 = rowfilterstr2 + " AND (im_syscd='C2')";
                    rowfilterstr2 = rowfilterstr2 + " AND (im_contno='" + strContNo + "')";
                    dv2.RowFilter = rowfilterstr2;

                    if (dv2.Count > 0)
                    {
                        ((GridView)DataList1.Items[i].FindControl("GridView1")).DataSource = dv2;
                        ((GridView)DataList1.Items[i].FindControl("GridView1")).DataBind();
                    }


                    // 抓出 雜誌收件人 DataGrid2
                    // 使用 DataSet 方法, 並指定使用的 table 名稱
                    DataSet ds3 = myCont.SelectC2_or();
                    DataView dv3 = ds3.Tables["c2_or"].DefaultView;

                    // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                    string rowfilterstr3 = "1=1";
                    rowfilterstr3 = rowfilterstr3 + " AND (or_syscd='C2')";
                    rowfilterstr3 = rowfilterstr3 + " AND (or_contno='" + strContNo + "')";
                    dv3.RowFilter = rowfilterstr3;

                    if (dv3.Count > 0)
                    {
                        ((GridView)DataList1.Items[i].FindControl("GridView2")).DataSource = dv3;
                        ((GridView)DataList1.Items[i].FindControl("GridView2")).DataBind();
                    }
                }

            }
            else
            {
                this.SearchIcon.Visible = true;
                lbNoCount.Visible = true;
                // 隱藏 DataList1 
                this.DataList1.Visible = false;
            }
			
        }

        protected void DataList1OnItemDataBound(Object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header)
            {
                if (BindList().Count != 0)//显示的数据项为0 既是没有数据
                {
                    ((Label)e.Item.FindControl("LbCount")).Visible = true;
                    ((Label)e.Item.FindControl("LbCount")).Text = "查詢結果：共有 " + BindList().Count.ToString() + " 筆資料!";
                    lbNoCount.Visible = false;
                }
                else
                {
                    lbNoCount.Visible = true;
                    DataList1.Visible = false;

                }
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Default.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 發票類別
                string invcd = e.Row.Cells[10].Text.Trim();
                //Response.Write("invcd = " + invcd + "<br>");
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
                        break;
                    default:
                        e.Row.Cells[10].Text = "三聯";
                        break;
                }

                // 發票課稅別
                string taxtp = e.Row.Cells[11].Text.Trim();
                //Response.Write("taxtp = " + taxtp + "<br>");
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
                        break;
                    default:
                        e.Row.Cells[11].Text = "應稅5%";
                        break;
                }

                // 院所內註記
                string fgitri = e.Row.Cells[12].Text.Trim();
                //Response.Write("fgitri = " + fgitri + "<br>");
                if (fgitri == "")
                    e.Row.Cells[12].Text = "否";
                else
                {
                    if (fgitri == "06")
                        e.Row.Cells[12].Text = "<font color='Red'>所內</font>";
                    if (fgitri == "07")
                        e.Row.Cells[12].Text = "<font color='Red'>院內</font>";
                }

            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // 特別欄位之輸出格式轉換 - 變更發票類別等的格式
                //Response.Write("DataGrid2.Count= " + ((DataGrid)DataList1.Items[i].FindControl("DataGrid2")).Items.Count + "<br>");
                // 郵寄類別
                string mtpcd = e.Row.Cells[12].Text.Trim();
                //Response.Write("mtpcd = " + mtpcd + "<br>");

                // 使用 DataSet 方法, 並指定使用的 table 名稱
                DataSet ds4 = myCont.SelectMtp();
                DataView dv4 = ds4.Tables["mtp"].DefaultView;

                // 給 SQL 過濾條件 - 設 Row Filter (填自 where 之後的條件)
                string rowfilterstr4 = "1=1";
                rowfilterstr4 = rowfilterstr4 + " AND (mtp_mtpcd='" + mtpcd + "')";
                dv4.RowFilter = rowfilterstr4;

                // 檢查並輸出 最後 Row Filter 的結果
                //Response.Write("dv4.Count= "+ dv4.Count + "<BR>");
                //Response.Write("dv4.RowFilter= " + dv4.RowFilter + "<BR>");

                // 若有資料, 則顯示相關資料; 否則給予錯誤訊息
                if (dv4.Count > 0)
                {
                    e.Row.Cells[12].Text = dv4[0]["mtp_nm"].ToString().Trim();
                }
                else
                {
                    e.Row.Cells[12].Text = "<font color='Red'>(資料有誤)</font>";
                }


                // 海外郵寄註記
                string fgmosea = e.Row.Cells[13].Text.Trim();
                //Response.Write("fgmosea = " + fgmosea + "<br>");
                if (fgmosea == "1")
                    e.Row.Cells[12].Text = "<font color='Red'>是</font>";
                else
                    e.Row.Cells[12].Text = "否";

            }
        }
    }
}
