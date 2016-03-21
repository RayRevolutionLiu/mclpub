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
    public partial class remail_label : System.Web.UI.Page
    {
        remail_label_DB myremail = new remail_label_DB();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataSet ds1 = myremail.Selectc1_remail();
                DataView dv1 = ds1.Tables["c1_remail"].DefaultView;
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
            //if (!IsPostBack)
            //{
            //    DataSet ds1 = myremail.Selectc1_remail();
            //    DataView dv1 = ds1.Tables["c1_remail"].DefaultView;
            //    if (Context.Request.QueryString["mosea"] == "0")
            //    {
            //        DataList1.DataSource = dv1;
            //        DataList1.DataBind();
            //    }
            //    else
            //    {
            //        DataList2.DataSource = dv1;
            //        DataList2.DataBind();
            //    }
            //}
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

                #region 訂閱起訖(沒有用 但是為了版面要讓她留著)
                HtmlGenericControl spandate = new HtmlGenericControl("span");
                spandate.Attributes.Add("style", "font-size: 10pt;");
                spandate.InnerHtml = "&nbsp;<br />";
                td.Controls.Add(spandate);
                #endregion

                #region 訂戶編號
                HtmlGenericControl spansyscd = new HtmlGenericControl("span");
                spansyscd.Attributes.Add("style", "font-size: 10pt;");
                spansyscd.InnerHtml = "訂戶編號：&nbsp;&nbsp;" + dv1[judge]["rm_syscd"].ToString() + dv1[judge]["rm_custno"].ToString() + dv1[judge]["rm_otp1cd"].ToString() + dv1[judge]["rm_otp1seq"].ToString() + "<br />";
                td.Controls.Add(spansyscd);
                #endregion

                #region 補書內容
                HtmlGenericControl spanobtpnm = new HtmlGenericControl("span");
                spanobtpnm.Attributes.Add("style", "font-size: 10pt;");
                spanobtpnm.InnerHtml = "補書內容：" + dv1[judge]["rm_date"].ToString() + "&nbsp;&nbsp;" + dv1[judge]["rm_cont"].ToString() + "<br />";
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

                #region 訂閱起訖(沒有用 但是為了版面要讓她留著)
                HtmlGenericControl spandate = new HtmlGenericControl("span");
                spandate.Attributes.Add("style", "font-size: 10pt;");
                spandate.InnerHtml = "&nbsp;<br />";
                td.Controls.Add(spandate);
                #endregion

                #region 訂戶編號
                HtmlGenericControl spansyscd = new HtmlGenericControl("span");
                spansyscd.Attributes.Add("style", "font-size: 10pt;");
                spansyscd.InnerHtml = "訂戶編號：&nbsp;&nbsp;" + dv1[judge]["rm_syscd"].ToString() + dv1[judge]["rm_custno"].ToString() + dv1[judge]["rm_otp1cd"].ToString() + dv1[judge]["rm_otp1seq"].ToString() + "<br />";
                td.Controls.Add(spansyscd);
                #endregion

                #region 補書內容
                HtmlGenericControl spanobtpnm = new HtmlGenericControl("span");
                spanobtpnm.Attributes.Add("style", "font-size: 10pt;");
                spanobtpnm.InnerHtml = "補書內容：" + dv1[judge]["rm_date"].ToString() + "&nbsp;&nbsp;" + dv1[judge]["rm_cont"].ToString() + "<br />";
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