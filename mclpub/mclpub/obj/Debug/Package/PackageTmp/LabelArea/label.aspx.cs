using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace mclpub.LabelArea
{
    public partial class label : System.Web.UI.Page
    {
        label_DB mylabel = new label_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds1 = mylabel.SelectTmp_label1(Context.Request.QueryString["type2"].ToString().Trim(), Context.Request.QueryString["mnt"].ToString().Trim());
                //			this.sqlConnection1.ConnectionTimeout=60;
                DataView dv1 = ds1.Tables["tmp_label1"].DefaultView;
                dv1.Sort = "od_custno";
                //				dv1.RowFilter=strbuf;

                //20121214修改
                int tableCount = 0;//算出要產生幾個TABLE
                int i = 0;//
                int judge = 0;
                bool recordTr = true;//用來判斷TR的新增(開關)
                bool judge12 = false;//因為只要是第12筆都會有問題 會導致無窮跳出 所以要加個判斷
                if (dv1.Count > 0)
                {
                    if (dv1.Count % 12 != 0)
                    {
                        tableCount = dv1.Count / 12 + 1;
                    }
                    else
                    {
                        tableCount = dv1.Count / 12;
                    }
                }
                //Response.Write(tableCount);
                HtmlGenericControl tr = null;

                for (i = 0; i < tableCount; i++)
                {
                    #region 空白
                    HtmlGenericControl BRspanFront1 = new HtmlGenericControl("br");
                    Panel1.Controls.Add(BRspanFront1);
                    HtmlGenericControl BRspanFront2 = new HtmlGenericControl("br");
                    Panel1.Controls.Add(BRspanFront2);
                    HtmlGenericControl BRspanFront3 = new HtmlGenericControl("br");
                    Panel1.Controls.Add(BRspanFront3);
                    HtmlGenericControl BRspanFront4 = new HtmlGenericControl("br");
                    Panel1.Controls.Add(BRspanFront4);
                    #endregion



                    HtmlGenericControl table = new HtmlGenericControl("table");
                    table.Attributes.Add("cellpadding", "0");
                    table.Attributes.Add("cellspacing", "0");
                    table.Attributes.Add("style", "border-collapse: collapse;page-break-after:always;");
                    table.Attributes.Add("width", "100%");

                    for (int j = judge; j < dv1.Count; j++)
                    {

                        if (j % 12 == 0 && j != 0 && judge12 == false)//如果超過12筆 就跳出迴圈 新增另一個TABLE
                        {
                            judge12 = true;
                            break;
                        }
                        else
                        {
                            if (recordTr == true)
                            {
                                tr = new HtmlGenericControl("tr");
                                table.Controls.Add(tr);
                                tr.Controls.Add(TdInside(dv1, judge));

                                recordTr = false;

                            }
                            else
                            {
                                tr.Controls.Add(TdInside(dv1, judge));

                                recordTr = true;
                            }
                            judge++;
                            judge12 = false;
                        }

                    }


                    Panel1.Controls.Add(table);
                }




                //Response.Write(judge);









                //cellpadding="0" cellspacing="0" style="border-collapse: collapse;"



                //if (Context.Request.QueryString["mosea"] == "0")
                //{
                //    DataList1.DataSource = dv1;
                //    DataList1.DataBind();
                //    for (int i = 0; i < dv1.Count; i++)
                //    {
                //        ((Label)DataList1.Items[i].FindControl("lblBookNo1")).Text = Context.Request.QueryString["book"] + "期";
                //        //System.Web.UI.HtmlControls.HtmlGenericControl p1 = new System.Web.UI.HtmlControls.HtmlGenericControl("p");

                //        //if (i % 13 == 0 && i / 13 >= 1)
                //        //{
                //        //    //DataList1.Attributes.Add("style", "page-break-after:always");
                //        //    ((Label)DataList1.Items[i].FindControl("pagevalue1")).Attributes.Add("style", "page-break-after:always");
                //        //}

                //    }
                //}
                //else
                //{
                //    DataList2.DataSource = dv1;
                //    DataList2.DataBind();
                //    for (int i = 0; i < dv1.Count; i++)
                //        ((Label)DataList2.Items[i].FindControl("lblBookNo2")).Text = Context.Request.QueryString["book"] + "期";
                //}
            }
        }



        private HtmlGenericControl TdInside(DataView dv1, int judge)
        {
            HtmlGenericControl td = new HtmlGenericControl("td");
            td.Attributes.Add("width", "53%");

            if (Context.Request.QueryString["mosea"] == "0")
            {
                HtmlGenericControl table = new HtmlGenericControl("table");
                table.Attributes.Add("cellpadding", "0");
                table.Attributes.Add("cellspacing", "0");
                table.Attributes.Add("style", "border-collapse: collapse;");

                #region 郵遞區號跟地址
                HtmlGenericControl tr = new HtmlGenericControl("tr");
                HtmlGenericControl td1 = new HtmlGenericControl("td");
                td1.InnerHtml = dv1[judge]["or_zip"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;";
                td1.Attributes.Add("style", "font-size: 14pt; font-weight: bold;");
                tr.Controls.Add(td1);
                HtmlGenericControl td2 = new HtmlGenericControl("td");
                td2.InnerHtml = dv1[judge]["or_addr"].ToString();
                if (dv1[judge]["or_addr"].ToString().Trim().Length > 23)
                {
                    td2.Attributes.Add("style", "font-size: 9.5pt; font-weight: bold;");
                }
                else
                {
                    td2.Attributes.Add("style", "font-size: 10pt; font-weight: bold;");
                }
                tr.Controls.Add(td2);
                table.Controls.Add(tr);
                td.Controls.Add(table);
                #endregion

                #region 公司名稱跟收件人+職稱
                HtmlGenericControl spaninm = new HtmlGenericControl("span");
                HtmlGenericControl spannm = new HtmlGenericControl("span");
                HtmlGenericControl spanjbti = new HtmlGenericControl("span");

                spaninm.Attributes.Add("style", "font-size: 10pt;");
                spannm.Attributes.Add("style", "font-size: 10pt;");
                spanjbti.Attributes.Add("style", "font-size: 10pt;");

                spaninm.InnerHtml = dv1[judge]["or_inm"].ToString() + "<br />";
                spannm.InnerHtml = dv1[judge]["or_nm"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;";
                spanjbti.InnerHtml = dv1[judge]["or_jbti"].ToString() + "<br />";

                td.Controls.Add(spaninm);
                td.Controls.Add(spannm);
                td.Controls.Add(spanjbti);
                #endregion

                #region 訂閱起迄
                HtmlGenericControl spandate = new HtmlGenericControl("span");
                spandate.Attributes.Add("style", "font-size: 10pt;");
                spandate.InnerHtml = "訂閱起迄：&nbsp;&nbsp;" + dv1[judge]["od_sdate"].ToString() + "~" + dv1[judge]["od_edate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;份數：" + dv1[judge]["ra_mnt"].ToString() + "<br />";
                td.Controls.Add(spandate);
                #endregion

                #region 訂戶編號
                HtmlGenericControl spansyscd = new HtmlGenericControl("span");
                spansyscd.Attributes.Add("style", "font-size: 10pt;");
                spansyscd.InnerHtml = "訂戶編號：&nbsp;&nbsp;" + dv1[judge]["od_syscd"].ToString() + dv1[judge]["od_custno"].ToString() + dv1[judge]["od_otp1cd"].ToString() + dv1[judge]["od_otp1seq"].ToString() + "&nbsp;&nbsp;(" + dv1[judge]["otp_otp2nm"].ToString() + ")&nbsp;&nbsp;" + dv1[judge]["mtp_nm"].ToString() + "<br />";
                td.Controls.Add(spansyscd);
                #endregion

                #region 工材(電材等)訂購期別
                HtmlGenericControl spanobtpnm = new HtmlGenericControl("span");
                spanobtpnm.Attributes.Add("style", "font-size: 10pt;");
                spanobtpnm.InnerHtml = dv1[judge]["obtp_obtpnm"].ToString() + "&nbsp;&nbsp;" + Context.Request.QueryString["book"] + "期" + "<br />";
                td.Controls.Add(spanobtpnm);
                #endregion

                #region 序號
                HtmlGenericControl ItemIndex = new HtmlGenericControl("span");
                ItemIndex.Attributes.Add("style", "font-size: 6pt;");
                ItemIndex.InnerHtml = judge.ToString();
                td.Controls.Add(ItemIndex);
                #endregion

                #region 空白
                HtmlGenericControl BRspan = new HtmlGenericControl("br");
                td.Controls.Add(BRspan);
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.TagName = "div";
                div.Style.Add("height", "13pt");
                td.Controls.Add(div);
                #endregion
            }
            else
            {
                HtmlGenericControl table = new HtmlGenericControl("table");
                table.Attributes.Add("cellpadding", "0");
                table.Attributes.Add("cellspacing", "0");
                table.Attributes.Add("style", "border-collapse: collapse;");

                #region 公司名稱跟收件人+職稱
                HtmlGenericControl spaninm = new HtmlGenericControl("span");
                HtmlGenericControl spannm = new HtmlGenericControl("span");
                HtmlGenericControl spanjbti = new HtmlGenericControl("span");

                spaninm.Attributes.Add("style", "font-size: 10pt;");
                spannm.Attributes.Add("style", "font-size: 10pt;");
                spanjbti.Attributes.Add("style", "font-size: 10pt;");

                spannm.InnerHtml = dv1[judge]["or_nm"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;";
                spanjbti.InnerHtml = dv1[judge]["or_jbti"].ToString() + "<br />";
                spaninm.InnerHtml = dv1[judge]["or_inm"].ToString() + "<br />";
          
                td.Controls.Add(spannm);
                td.Controls.Add(spanjbti);
                td.Controls.Add(spaninm);

                #endregion

                #region 郵遞區號跟地址
                HtmlGenericControl tr = new HtmlGenericControl("tr");
                //國外的標籤 郵遞區號不用加
                //HtmlGenericControl td1 = new HtmlGenericControl("td");
                //td1.InnerHtml = dv1[judge]["or_zip"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;";
                //td1.Attributes.Add("style", "font-size: 14pt; font-weight: bold;");
                //tr.Controls.Add(td1);
                HtmlGenericControl td2 = new HtmlGenericControl("td");
                td2.InnerHtml = dv1[judge]["or_addr"].ToString();
                if (dv1[judge]["or_addr"].ToString().Trim().Length > 23)
                {
                    td2.Attributes.Add("style", "font-size: 9.5pt; font-weight: bold;");
                }
                else
                {
                    td2.Attributes.Add("style", "font-size: 10pt; font-weight: bold;");
                }
                tr.Controls.Add(td2);
                table.Controls.Add(tr);
                td.Controls.Add(table);
                #endregion


                #region 訂閱起迄
                HtmlGenericControl spandate = new HtmlGenericControl("span");
                spandate.Attributes.Add("style", "font-size: 10pt;");
                spandate.InnerHtml = "訂閱起迄：&nbsp;&nbsp;" + dv1[judge]["od_sdate"].ToString() + "~" + dv1[judge]["od_edate"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;份數：" + dv1[judge]["ra_mnt"].ToString() + "<br />";
                td.Controls.Add(spandate);
                #endregion

                #region 訂戶編號
                HtmlGenericControl spansyscd = new HtmlGenericControl("span");
                spansyscd.Attributes.Add("style", "font-size: 10pt;");
                spansyscd.InnerHtml = "訂戶編號：&nbsp;&nbsp;" + dv1[judge]["od_syscd"].ToString() + dv1[judge]["od_custno"].ToString() + dv1[judge]["od_otp1cd"].ToString() + dv1[judge]["od_otp1seq"].ToString() + "&nbsp;&nbsp;(" + dv1[judge]["otp_otp2nm"].ToString() + ")&nbsp;&nbsp;" + dv1[judge]["mtp_nm"].ToString() + "<br />";
                td.Controls.Add(spansyscd);
                #endregion

                #region 工材(電材等)訂購期別
                HtmlGenericControl spanobtpnm = new HtmlGenericControl("span");
                spanobtpnm.Attributes.Add("style", "font-size: 10pt;");
                spanobtpnm.InnerHtml = dv1[judge]["obtp_obtpnm"].ToString() + "&nbsp;&nbsp;" + Context.Request.QueryString["book"] + "期" + "<br />";
                td.Controls.Add(spanobtpnm);
                #endregion

                #region 序號
                HtmlGenericControl ItemIndex = new HtmlGenericControl("span");
                ItemIndex.Attributes.Add("style", "font-size: 6pt;");
                ItemIndex.InnerHtml = judge.ToString();
                td.Controls.Add(ItemIndex);
                #endregion

                #region 空白
                HtmlGenericControl BRspan = new HtmlGenericControl("br");
                td.Controls.Add(BRspan);
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.TagName = "div";
                div.Style.Add("height", "13pt");
                td.Controls.Add(div);
                #endregion
            }
            return td;
        }
    }
}