using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;

using System.Configuration;

using System.IO;


namespace mclpub.SetAccount
{
    public partial class SetSAPManage : System.Web.UI.Page
    {

        private string Conn = ConfigurationManager.AppSettings["itridpr_mrlpub"].ToString();

        SetSAPManage_DB myPub = new SetSAPManage_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            //無任何按鈕動作
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    Response.Write(Request.QueryString["id"].ToString());
                    Response.Flush();

                }
                if (PsGV.Rows.Count == 0)
                {
                    SearchIcon.Visible = false;

                    //隱藏建立按鈕
                    Button1.Visible = false;
                }
                else
                {
                    SearchIcon.Visible = true;
                    //顯示建立按鈕
                    Button1.Visible = true;
                }

                //-------------系統代號下拉選單
                DataTable dt = myPub.syscdDrpdownList();

                /*
                DataRow dr = dt.NewRow();
                dr["sys_syscd"] = "00";
                dr["sys_nm"] = "請選擇";
                dt.Rows.Add(dr);
                 */

                //將整個陣列排序
                dt.DefaultView.Sort = "sys_syscd ASC";

                sysocDrpdown.DataTextField = dt.Columns[1].ToString();
                sysocDrpdown.DataValueField = dt.Columns[0].ToString();
                sysocDrpdown.DataSource = dt.DefaultView;
                sysocDrpdown.DataBind();


                //-------------往來種類下拉選單
                DataTable dt2 = myPub.fgitriDrpdownList();

                /*
                DataRow dr2 = dt.NewRow();
                dr2["fgitri_fgitri"] = "00";
                dr2["fgitri_name"] = "請選擇";
                dt2.Rows.Add(dr);
                 */

                //將整個陣列排序
                dt2.DefaultView.Sort = "fgitri_fgitri ASC";

                fgitriDropdown.DataTextField = dt2.Columns[1].ToString();
                fgitriDropdown.DataValueField = dt2.Columns[0].ToString();
                fgitriDropdown.DataSource = dt2.DefaultView;
                fgitriDropdown.DataBind();

            }

        }

        protected void CheckBtn_Click(object sender, EventArgs e)
        {
           
            SearchIcon.Visible = true;
            BindGrid();

        }

        public void BindGrid()
        {
            DataTable dt = myPub.SelectC1cust(sysocDrpdown.SelectedItem.Value.Trim(), fgitriDropdown.SelectedItem.Value.Trim());

            /*
            if (dt.Rows.Count < PsGV.PageSize)
            {
                UCPager1.Visible = false;
            }
            */
            PsGV.DataSource = dt;
            PsGV.DataBind();

            if (dt.Rows.Count == 0)
            {
                Button1.Visible = false;
            }
            else {

                Button1.Visible = true;
            }
        }

        protected void PsGVOnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;
               // e.Row.Cells[0]. = false;
            }
        }

        protected void gv_data_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortDirection"] == null)//如果第一次點選排序的話，預設就是「升」
            {
                ViewState["SortDirection"] = " ASC";
            }
            //判斷如果已經對某欄位排序過，再判斷是否針對同個欄位排序
            if (ViewState["SortExpression"] != null && ViewState["SortExpression"].ToString() == e.SortExpression)
            {
                //如果針對同個欄位排序，則進行「升」「降」的切換
                if (ViewState["SortDirection"].ToString() == " DESC")
                {
                    ViewState["SortDirection"] = " ASC";
                }
                else
                {
                    ViewState["SortDirection"] = " DESC";
                }

            }
            else
            {
                //第一次對某欄位排序，就是「升」
                ViewState["SortDirection"] = " ASC";
            }

            for (int i = 0; i <= ((GridView)sender).Columns.Count - 1; i++)
            {
                ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText.Replace("▲", "");
                ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText.Replace("▼", "");
            }
            int Columns_i = 0;
            for (int i = 0; i <= ((GridView)sender).Columns.Count - 1; i++)
            {
                if (e.SortExpression == ((GridView)sender).Columns[i].SortExpression)
                {
                    Columns_i = i;
                    if (ViewState["SortDirection"].ToString() == " ASC")
                    {
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText + "▼";
                    }
                    else
                    {
                        ((GridView)sender).Columns[i].HeaderText = ((GridView)sender).Columns[i].HeaderText + "▲";
                    }
                }
            }


            ViewState["SortExpression"] = e.SortExpression;//指定欄位名稱

            DataTable dt = myPub.SelectC1cust(sysocDrpdown.SelectedItem.Value.Trim(), fgitriDropdown.SelectedItem.Value.Trim());

            //給予資料來源(DataTable)並重新繫結資料
            DataView dv = dt.DefaultView;
            dv.Sort = ViewState["SortExpression"].ToString() + ViewState["SortDirection"].ToString();
            PsGV.DataSource = dv;
            PsGV.DataBind();
        }

        protected void RedrectEdit(object sender, EventArgs e)
        {
            GridViewRow thisRow = ((Button)sender).Parent.Parent as GridViewRow;  //此段取到該Row
            string ide = thisRow.Cells[1].Text;
            Response.Redirect(string.Format("PubSearchCustEdit.aspx?custnoID={0}", ide));

        }

        //建立發票清單
        protected void Button1_Click(object sender, EventArgs e)
        {
            bool judge = false;
            //
            string selectSyscd = sysocDrpdown.SelectedItem.Value.Trim();
            string selectKind = fgitriDropdown.SelectedItem.Value.Trim();

            //目前年月:
            DateTime dt2 = DateTime.Now;

            string nowym = string.Format("{0:yyyyMM}",dt2);

           
            /* -----取得該分類當月最大批號 -----*/
            //輸入 所選系統代號 、 往來種類 和 目前年月
            int nb = myPub.getNext(selectSyscd, selectKind, nowym);

            /* -----結束 -----*/

            /* -----取得 ID 值 -----*/
            //int nid = myPub.getId();

           // int nid = myPub.getId();


            //Response.Write(" IP :  " + nid);

            /* -----結束 -----*/
            
            /*-----更改單據狀態 ----*/
            int i;
            int iaSelect = 0; //作為選取發票的計數
            for (i = 0; i < this.PsGV.Rows.Count; i++)
            {
                if (((CheckBox)PsGV.Rows[i].FindControl("CheckBox2")).Checked)
                {           
                    string iaid = PsGV.Rows[i].Cells[1].Text;

                    //---------------資料庫操作
                    SqlCommand oCmd = new SqlCommand();
                    oCmd.Connection = new SqlConnection(Conn);
                    StringBuilder sb = new StringBuilder();

                    //寫入資料庫: 將所屬發票清單寫入並將狀態改為已處理
                    sb.Append(@"UPDATE ia SET ia_status = 'v' , ia_iasseq = @nb , ia_iasdate = @nowym , ia_iaitem = @iaitem WHERE ia_iaid = @iaid ");

                    //資料庫指令
                    oCmd.CommandText = sb.ToString();
                    //資料庫指令型態
                    oCmd.CommandType = CommandType.Text;
                    //資料庫連接器
                    SqlDataAdapter oda = new SqlDataAdapter(oCmd);

                    //SQL參數設定
                    oCmd.Parameters.AddWithValue("@iaid", iaid);
                    oCmd.Parameters.AddWithValue("@nb", nb);
                    oCmd.Parameters.AddWithValue("@nowym", nowym);
                    oCmd.Parameters.AddWithValue("@iaitem", string.Format("{0:000}", i + 1));
                    //開始資料庫連線
                    oCmd.Connection.Open();
                    
                    //執行SQL
                    oCmd.ExecuteNonQuery();
                    
                    //結束資料庫連線
                    oCmd.Connection.Close();
                    //---------------資料庫操作結束

                    iaSelect++;

                    judge = true;
                }
            }


            if (judge == true)
            {

                /* ----- 寫入資料庫 ----- */
                
                //---------------資料庫操作
                SqlCommand oCmd = new SqlCommand();
                oCmd.Connection = new SqlConnection(Conn);
                StringBuilder sb2 = new StringBuilder();

                //寫入資料庫

                sb2.Append(@"INSERT INTO  ias (ias_syscd, ias_iasdate, ias_iasseq, ias_toitem,ias_cancel, ias_trans_sap, ias_createdate, ias_createmen, ias_fgitri )  VALUES ( @syscd, @nowym , @nb , @toitem ,'0','0' , CONVERT(varchar(12), GETDATE(), 112),@createmen, @kind )");

                //sb2.Append(@"INSERT INTO  ias (ias_iasid, ias_syscd, ias_iasdate, ias_iasseq, ias_toitem, ias_createdate, ias_fgitri )  VALUES (  @id, @syscd, @nowym, @nb, @toitem, CONVERT(varchar(12), GETDATE(), 112), @kind )");

                //資料庫指令
                oCmd.CommandText = sb2.ToString();
                //資料庫指令型態
                oCmd.CommandType = CommandType.Text;
                //資料庫連接器
                SqlDataAdapter oda = new SqlDataAdapter(oCmd);


                oCmd.Parameters.AddWithValue("@nb", nb);
                oCmd.Parameters.AddWithValue("@nowym", nowym);
                //上方FOR迴圈的計數, 為選取發票的計數
                oCmd.Parameters.AddWithValue("@toitem", iaSelect);
                //oCmd.Parameters.AddWithValue("@id", nid);
                oCmd.Parameters.AddWithValue("@createmen", Account.GetAccInfo().srspn_empno.ToString().Trim());

                //oCmd.Parameters.AddWithValue("@id", nid);


                oCmd.Parameters.AddWithValue("@syscd", selectSyscd);
                oCmd.Parameters.AddWithValue("@kind", selectKind);

                //開始資料庫連線
                oCmd.Connection.Open();
                //執行SQL
                oCmd.ExecuteNonQuery();
                //結束資料庫連線
                oCmd.Connection.Close();
                
                /* -----結束 -----*/

                //如果有勾選任何資料
                JavaScript.AlertMessage(this.Page, " HELLO!!!請注意記注以下資訊!!! 系統代號為："  + selectSyscd + "  轉檔年~月~：" + nowym + "  批次為：" + nb );
            
            }
            else
            {
                //如果沒勾選
                JavaScript.AlertMessage(this.Page, "尚未位勾選資料");
            }

            BindGrid();
          
        }
    }
}