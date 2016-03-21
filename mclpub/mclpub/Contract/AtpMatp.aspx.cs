using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace mclpub.Contract
{
    public partial class AtpMatp : System.Web.UI.Page
    {
        AtpMatp_DB myAtp = new AtpMatp_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                string contno, classid;

                if (Request.QueryString["NewContNo"] == null || Request.QueryString["NewContNo"].ToString().Trim() == "")
                {
                    JavaScript.AlertMessageClose(this.Page, "無合約編號");
                    return;
                }
                else
                {
                    contno = Request.QueryString["NewContNo"];
                }
                classid = Request.QueryString["ClassId"];
                ddlClass1.Items.FindByValue(classid).Selected = true;
                ddlClass1.Enabled = false;

                //檢查，如果Page初始化時，這個資料存在，就是殘存值存在，就把殘存資料清除
                if (Session["ATPMTPS"] != null)
                {
                    Session.Remove("ATPMTPS");
                }

                InitData();

                LoadAtpMtps(contno);
            }
        }


        #region 初始化類別選項
        private void InitData()
        {
            Bing_dlClass21();
            Bing_dlClass22();
            //預設顯示應用產業
            if (ddlClass1.SelectedItem.Value == "1")
            {
                dlClass21.Visible = true;
                dlClass22.Visible = false;
            }
            else
            {
                dlClass21.Visible = false;
                dlClass22.Visible = true;
            }
            //			Bind_Class2_1();
            //			Bind_Class3_1(1, 1);
            //			Bind_Class2_2();
            //			Bind_Class3_2(1, 2);
        }
        #endregion

        #region 連結應用產業Class2
        private void Bing_dlClass21()
        {
            DataSet ds = myAtp.GetClass2(1);
            DataView dv = ds.Tables[0].DefaultView;

            dlClass21.DataSource = dv;
            dlClass21.DataBind();

            Bind_cblClass321();
        }
        #endregion

        #region 連結應用產業Class3
        private void Bind_cblClass321()
        {
            for (int i = 0; i < dlClass21.Items.Count; i++)
            {
                int cls2id = 1;
                if (dlClass21.Items[i].FindControl("tbxClass21") != null)
                    cls2id = Convert.ToInt32(((TextBox)dlClass21.Items[i].FindControl("tbxClass21")).Text);
                else
                {
                    Response.Write("no cls2id...");
                }
                DataSet ds = myAtp.GetClass3(1, cls2id);
                DataView dv = ds.Tables[0].DefaultView;

                if (dlClass21.Items[i].FindControl("cblClass321") != null)
                {
                    ((CheckBoxList)dlClass21.Items[i].FindControl("cblClass321")).DataSource = dv;
                    ((CheckBoxList)dlClass21.Items[i].FindControl("cblClass321")).DataTextField = "cls3_cname";
                    ((CheckBoxList)dlClass21.Items[i].FindControl("cblClass321")).DataValueField = "cls3_cls123id";
                    ((CheckBoxList)dlClass21.Items[i].FindControl("cblClass321")).DataBind();
                }
                else
                {
                    Response.Write("no control found");
                }
            }

        }
        #endregion

        #region 連結材料特性Class2
        private void Bing_dlClass22()
        {
            DataSet ds = myAtp.GetClass2(2);
            DataView dv = ds.Tables[0].DefaultView;

            dlClass22.DataSource = dv;
            dlClass22.DataBind();

            Bind_cblClass322();
        }
        #endregion

        #region 連結材料特性Class3
        private void Bind_cblClass322()
        {
            for (int i = 0; i < dlClass22.Items.Count; i++)
            {
                int cls2id = 1;
                if (dlClass22.Items[i].FindControl("tbxClass22") != null)
                    cls2id = Convert.ToInt32(((TextBox)dlClass22.Items[i].FindControl("tbxClass22")).Text);
                else
                {
                    Response.Write("no cls2id...");
                }
                DataSet ds = myAtp.GetClass3(2, cls2id);
                DataView dv = ds.Tables[0].DefaultView;

                if (dlClass22.Items[i].FindControl("cblClass322") != null)
                {
                    ((CheckBoxList)dlClass22.Items[i].FindControl("cblClass322")).DataSource = dv;
                    ((CheckBoxList)dlClass22.Items[i].FindControl("cblClass322")).DataTextField = "cls3_cname";
                    ((CheckBoxList)dlClass22.Items[i].FindControl("cblClass322")).DataValueField = "cls3_cls123id";
                    ((CheckBoxList)dlClass22.Items[i].FindControl("cblClass322")).DataBind();
                }
                else
                {
                    Response.Write("no control found");
                }
            }

        }
        #endregion

        #region 第一次載入類別資料
        private void LoadAtpMtps(string contno)
        {
            //應用產業與材料特性
            DataSet ds = myAtp.GetAtpMtps(contno);
            DataView dv = ds.Tables[0].DefaultView;

            //Match UI與Data
            for (int i = 0; i < dv.Count; i++)	//對於每個DataView裡面的資料檢查一次
            {
                for (int j = 0; j < dlClass21.Items.Count; j++)	//對於DataList裡面的每一個CheckBoxList
                {
                    for (int k = 0; k < ((CheckBoxList)dlClass21.Items[j].FindControl("cblClass321")).Items.Count; k++)	//對於CheckBoxList裡面的每一個ListItem
                    {
                        if (dv[i]["cls_cls123id"].ToString() == ((CheckBoxList)dlClass21.Items[j].FindControl("cblClass321")).Items[k].Value)
                        {
                            ((CheckBoxList)dlClass21.Items[j].FindControl("cblClass321")).Items[k].Selected = true;
                        }
                    }
                }

                for (int j = 0; j < dlClass22.Items.Count; j++)	//對於DataList裡面的每一個CheckBoxList
                {
                    for (int k = 0; k < ((CheckBoxList)dlClass22.Items[j].FindControl("cblClass322")).Items.Count; k++)	//對於CheckBoxList裡面的每一個ListItem
                    {
                        if (dv[i]["cls_cls123id"].ToString() == ((CheckBoxList)dlClass22.Items[j].FindControl("cblClass322")).Items[k].Value)
                        {
                            ((CheckBoxList)dlClass22.Items[j].FindControl("cblClass322")).Items[k].Selected = true;
                        }
                    }
                }
            }
        }
        #endregion



        protected void btnSave1_Click(object sender, EventArgs e)
        {
            string contno = "999999";

            if (Request.QueryString["NewContNo"] != null && Request.QueryString["NewContNo"].ToString().Trim() != "")
            {
                contno = Request.QueryString["NewContNo"];
            }
            else
            {
                JavaScript.AlertMessageClose(this.Page, "合約編號錯誤");
                return;
            }

            //應用產業與材料特性
            ArrayList ary = new ArrayList();


            CheckBoxList cbl1;
            for (int i = 0; i < dlClass21.Items.Count; i++)
            {
                cbl1 = (CheckBoxList)dlClass21.Items[i].FindControl("cblClass321");
                foreach (ListItem item in cbl1.Items)
                {
                    if (item.Selected) ary.Add(item.Value);
                }
            }

            CheckBoxList cbl2;
            for (int j = 0; j < dlClass22.Items.Count; j++)
            {
                cbl2 = (CheckBoxList)dlClass22.Items[j].FindControl("cblClass322");
                foreach (ListItem item in cbl2.Items)
                {
                    if (item.Selected) ary.Add(item.Value);
                }
            }

            string[] selstrs = (string[])ary.ToArray(typeof(string));


            //Response.Write(ary[0].ToString() + "," + ary[1].ToString() + "," + ary[2].ToString());
            string itemvalue;
            int cls1id, cls2id, cls3id;
            ArrayList amary = new ArrayList();
            for (int k = 0; k < selstrs.Length; k++)
            {
                itemvalue = selstrs.GetValue(k).ToString();
                cls1id = Convert.ToInt32(itemvalue.Substring(0, 2));
                cls2id = Convert.ToInt32(itemvalue.Substring(2, 2));
                cls3id = Convert.ToInt32(itemvalue.Substring(4, 2));
                AMEntry ame = new AMEntry(contno, cls1id, cls2id, cls3id);
                amary.Add(ame);
            }


            myAtp.SaveAtpMtps(contno, amary.ToArray());
            this.Page.Controls.Add(new LiteralControl("<script>if (window.opener) {alert('應用產業、材料特性等資料儲存成功');window.opener.PushBtn();}window.close();</script>"));
            //JavaScript.AlertMessageClose(this.Page, "應用產業、材料特性等資料儲存成功");
        }

        protected void dlClass21_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Command1")
            {
                CheckBoxList chklist = (CheckBoxList)e.Item.FindControl("cblClass321");

                for (int i = 0; i < chklist.Items.Count; i++)
                {
                    chklist.Items[i].Selected = true;
                }
            }

            if (e.CommandName == "Command2")
            {
                CheckBoxList chklist = (CheckBoxList)e.Item.FindControl("cblClass321");

                for (int i = 0; i < chklist.Items.Count; i++)
                {
                    chklist.Items[i].Selected = false;
                }
            }
        }

        protected void dlClass22_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Command1")
            {
                CheckBoxList chklist = (CheckBoxList)e.Item.FindControl("cblClass322");

                for (int i = 0; i < chklist.Items.Count; i++)
                {
                    chklist.Items[i].Selected = true;
                }
            }

            if (e.CommandName == "Command2")
            {
                CheckBoxList chklist = (CheckBoxList)e.Item.FindControl("cblClass322");

                for (int i = 0; i < chklist.Items.Count; i++)
                {
                    chklist.Items[i].Selected = false;
                }
            }
        }


    }
}
