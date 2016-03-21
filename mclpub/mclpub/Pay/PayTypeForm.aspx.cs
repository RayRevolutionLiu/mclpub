using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Xml;
using System.Configuration;


namespace mclpub.Pay
{
    public partial class PayTypeForm : System.Web.UI.Page
    {
        PayTypeForm_DB myPay = new PayTypeForm_DB();
        security se = new security();

        protected void Page_Load(object sender, EventArgs e)
        {
            //傳過來的三個參數
            //count = 價錢相加
            //caller=''
            //no=發票開立單編號組合(ex:C202000047C202000090)因為一定一組是十碼 所以塞資料庫的時候只要substring 10
            if (!IsPostBack)
            {
                try
                {
                    lblAmt.Text = se.decryptquerystring(Context.Request.QueryString["count"]);
                    //付款方式
                    DataSet ds = myPay.Selectpytp();
                    ddlPayType.DataSource = ds;
                    ddlPayType.DataTextField = "pytp_nm";
                    ddlPayType.DataValueField = "pytp_pytpcd";
                    ddlPayType.DataBind();
                    DataSet ds1 = myPay.Selectpy();
                    DataView dv1 = ds1.Tables[0].DefaultView;
                    string fy = System.DateTime.Today.Year.ToString();
                    string pyno = "";
                    //				Response.Write(dv1[0][0].ToString());
                    pyno = dv1[0].Row["max_pyno"].ToString();
                    if (pyno.Substring(0, 2) == fy.Substring(2, 2))
                        pyno = Convert.ToString(Int32.Parse(pyno) + 1);
                    else
                        pyno = fy.Substring(2, 2) + "000001";
                    for (int j = 0; j < 8 - pyno.Length; j++)
                        pyno = "0" + pyno;
                    lblPayNo.Text = pyno;
                    int myYear = System.DateTime.Today.Year;
                    for (int i = myYear; i <= myYear + 10; i++)
                        ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    ddlYear.SelectedIndex = 0;
                    int myMonth = System.DateTime.Today.Month;
                    ddlMonth.SelectedIndex = myMonth - 1;
                    tbxCcDate.Value = System.DateTime.Today.ToString("yyyy/MM/dd");
                    tbxPost.Value = "0";
                }
                catch(Exception ex)
                {
                    JavaScript.AlertMessageRedirect(this.Page, ex.Message.ToString(), "../Default.aspx");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void btnBefore_Click(object sender, EventArgs e)
        {
            Response.Redirect("PayFilter.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SaveToPy();
            Update_c1_order_pytpcd();
            JavaScript.AlertMessageRedirect(this.Page, "儲存成功", "PayFilter.aspx");
        }

        public void SaveToPy()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"INSERT INTO dbo.py(py_pyno, py_amt, py_pytpcd, py_date, py_moseq, py_moitem, py_chkno, py_chkbnm, py_chkdate, ");
                sb.Append(@"py_waccno, py_wdate, py_wbcd, py_ccno, py_cctp, py_ccauthcd, py_ccvdate, py_ccdate, py_fgprinted, py_syscd, ");
                sb.Append(@"py_pysdate, py_pysseq, py_pysitem, py_post) VALUES (@py_pyno, @py_amt, @py_pytpcd, @py_date, @py_moseq, ");
                sb.Append(@"@py_moitem, @py_chkno, @py_chkbnm, @py_chkdate, @py_waccno, @py_wdate, @py_wbcd, @py_ccno, @py_cctp, @py_ccauthcd,");
                sb.Append(@"@py_ccvdate, @py_ccdate, @py_fgprinted, @py_syscd, @py_pysdate, @py_pysseq, @py_pysitem, @py_post)");

                SqlCommand sqlInsertComPy = myPay.SaveToPy_DB(sb.ToString());
                //繳款單檔 py
                sqlInsertComPy.Parameters.AddWithValue("@py_pyno", lblPayNo.Text.Trim());
                //			this.sqlInsertComPy.Parameters["@py_syscd"].Value="C1";
                int amt = int.Parse(lblAmt.Text) - int.Parse(tbxPost.Value);
                //			this.sqlInsertComPy.Parameters["@py_amt"].Value=lblAmt.Text.Trim();
                sqlInsertComPy.Parameters.AddWithValue("@py_amt",amt.ToString());
                sqlInsertComPy.Parameters.AddWithValue("@py_pytpcd",ddlPayType.SelectedItem.Value.Trim());
                sqlInsertComPy.Parameters.AddWithValue("@py_date",System.DateTime.Today.ToString("yyyyMMdd"));
                sqlInsertComPy.Parameters.AddWithValue("@py_fgprinted","0");
                sqlInsertComPy.Parameters.AddWithValue("@py_post",tbxPost.Value);
                sqlInsertComPy.Parameters.AddWithValue("@py_chkno", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_chkbnm", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_chkdate", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_moseq", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_moitem", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_waccno", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_wdate", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_wbcd", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_ccno", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_cctp", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_ccauthcd", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_ccvdate", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_syscd", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_ccdate", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_pysdate", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_pysseq", "");
                sqlInsertComPy.Parameters.AddWithValue("@py_pysitem", "");
                switch (ddlPayType.SelectedItem.Value)
                {
                    //目前只用到現金(C)、票據(N)、郵撥/電匯(T)
                    case "01"://現金
                    case "06"://所內往來
                    case "07"://院內往來
                        break;
                    case "02"://票據
                        sqlInsertComPy.Parameters["@py_chkno"].Value = tbxChkno.Value;
                        sqlInsertComPy.Parameters["@py_chkbnm"].Value =tbxChkbnm.Value;
                        sqlInsertComPy.Parameters["@py_chkdate"].Value = tbxChkdate.Value.Substring(0, 4) + tbxChkdate.Value.Substring(5, 2) + tbxChkdate.Value.Substring(8, 2);
                        break;
                    case "03"://劃撥
                        sqlInsertComPy.Parameters["@py_moseq"].Value = tbxMoseq.Value;
                        sqlInsertComPy.Parameters["@py_moitem"].Value = tbxMoitem.Value;
                        break;
                    case "04"://電匯
                        sqlInsertComPy.Parameters["@py_waccno"].Value = tbxWaccno.Value;
                        sqlInsertComPy.Parameters["@py_wdate"].Value = tbxWdate.Value.Substring(0, 4) + tbxWdate.Value.Substring(5, 2) + tbxWdate.Value.Substring(8, 2);
                        sqlInsertComPy.Parameters["@py_wbcd"].Value = tbxWbcd.Value;
                        break;
                    case "05"://信用卡
                        sqlInsertComPy.Parameters["@py_ccno"].Value = tbxCcno1.Value + tbxCcno2.Value + tbxCcno3.Value + tbxCcno4.Value;
                        sqlInsertComPy.Parameters["@py_cctp"].Value = rblCctp.SelectedItem.Value;
                        sqlInsertComPy.Parameters["@py_ccauthcd"].Value = tbxCcauthcd.Value;
                        sqlInsertComPy.Parameters["@py_ccvdate"].Value = ddlYear.SelectedItem.Value + ddlMonth.SelectedItem.Value;
                        sqlInsertComPy.Parameters["@py_ccdate"].Value = tbxCcDate.Value.Substring(0, 4) + tbxCcDate.Value.Substring(5, 2) + tbxCcDate.Value.Substring(8, 2);
                        break;
                }
                sqlInsertComPy.Connection.Open();
                sqlInsertComPy.ExecuteNonQuery();
                sqlInsertComPy.Connection.Close();


                string nostr;
                string strbuf = se.decryptquerystring(Context.Request.QueryString["no"]);
                int j = 1;
                for (int i = 0; i < (strbuf.Length / 10); i++)
                {        
                    nostr = strbuf.Substring(i * 10, 10);
                    myPay.Insertpyd(nostr.Substring(0, 2), nostr.Substring(2, 8), lblPayNo.Text.Trim(), j.ToString());

                    //Update 發票開立單檔 ia
                    myPay.Updateia(nostr.Substring(0, 2), nostr.Substring(2, 8), nostr.Substring(0, 2), nostr.Substring(2, 8), lblPayNo.Text.Trim(), j.ToString());
                    j++;
                }
            }
            catch (Exception ex)
            {
                JavaScript.AlertMessageRedirect(this.Page, ex.Message.ToString(), "../Default.aspx");
                return;
            }
        }
        private void Update_c1_order_pytpcd()
        {
            try
            {
                XmlDocument XmlDoc;
                XmlDoc = new System.Xml.XmlDocument();

                XmlNode ItemMain;//=XmlDoc.SelectSingleNode("/root");
                XmlNode ItemOrder;//=XmlDoc.SelectSingleNode("/root/訂單");
                string nostr;
                string strbuf = se.decryptquerystring(Context.Request.QueryString["no"]);
                DataSet ds1 = myPay.Selectc1_order();
                DataView dv1 = ds1.Tables[0].DefaultView;

                DataSet ds2 = myPay.Selectia();
                DataView dv2 = ds1.Tables[0].DefaultView;

                for (int i = 0; i < (strbuf.Length / 10); i++)
                {
                    nostr = strbuf.Substring(i * 10, 10);
                    if (nostr.Substring(0, 2) == "C1")
                    {
                        dv1.RowFilter = "o_syscd='" + nostr.Substring(0, 2) + "' and o_iano='" + nostr.Substring(2, 8) + "'";
                        XmlDoc.LoadXml(dv1[0].Row["o_xmldata"].ToString());
                        ItemMain = XmlDoc.SelectSingleNode("/root");
                        ItemOrder = XmlDoc.SelectSingleNode("/root/訂單");
                        ItemOrder["付款方式"].FirstChild.InnerText = ddlPayType.SelectedItem.Value.Trim();

                        StringBuilder sbOrder = new StringBuilder();
                        sbOrder.Append(@"UPDATE dbo.c1_order SET o_pytpcd = @o_pytpcd, o_xmldata = @o_xmldata, o_status=@o");
                        sbOrder.Append(@"_status WHERE (o_syscd = @o_syscd) AND (o_iano = @o_iano)");

                        SqlCommand sqlUpdateOrder = myPay.SaveToPy_DB(sbOrder.ToString());
                        sqlUpdateOrder.Parameters.AddWithValue("@o_pytpcd", ddlPayType.SelectedItem.Value.Trim());
                        sqlUpdateOrder.Parameters.AddWithValue("@o_xmldata", ItemMain.OuterXml);
                        sqlUpdateOrder.Parameters.AddWithValue("@o_status", "5");	//已繳款
                        sqlUpdateOrder.Parameters.AddWithValue("@o_syscd", nostr.Substring(0, 2));
                        sqlUpdateOrder.Parameters.AddWithValue("@o_iano", nostr.Substring(2, 8));
                        sqlUpdateOrder.Connection.Open();
                        sqlUpdateOrder.ExecuteNonQuery();
                        sqlUpdateOrder.Connection.Close();
                    }
                    else if (nostr.Substring(0, 2) == "C3")
                    {
                        StringBuilder sbInvmfr = new StringBuilder();
                        sbInvmfr.Append(@"UPDATE dbo.c1_order SET o_pytpcd = @o_pytpcd, o_xmldata = @o_xmldata, o_status=@o");
                        sbInvmfr.Append(@"_status WHERE (o_syscd = @o_syscd) AND (o_iano = @o_iano)");

                        SqlCommand sqlUpdateInvmfr = myPay.SaveToPy_DB(sbInvmfr.ToString());
                        dv2.RowFilter = "ia_syscd='C3' and ia_iano='" + nostr.Substring(2, 8) + "'";
                        sqlUpdateInvmfr.Parameters.AddWithValue("@im_pytpcd", ddlPayType.SelectedItem.Value.Trim());
                        sqlUpdateInvmfr.Parameters.AddWithValue("@im_fgia", "5");	//已繳款
                        sqlUpdateInvmfr.Parameters.AddWithValue("@im_syscd", "C3");
                        sqlUpdateInvmfr.Parameters.AddWithValue("@im_appno", dv2[0].Row["iad_fk1"].ToString());
                        sqlUpdateInvmfr.Parameters.AddWithValue("@im_imseq", dv2[0].Row["iad_fk2"].ToString());
                        sqlUpdateInvmfr.Connection.Open();
                        sqlUpdateInvmfr.ExecuteNonQuery();
                        sqlUpdateInvmfr.Connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                JavaScript.AlertMessageRedirect(this.Page, ex.Message.ToString(), "../Default.aspx");
                return;
            }
        }

        protected void ddlPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlPayType.SelectedItem.Value)
            {
                case "01":
                case "06":
                case "07":
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    break;
                case "02":
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    break;
                case "03":
                    Panel1.Visible = false;
                    Panel2.Visible = true;
                    Panel3.Visible = false;
                    Panel4.Visible = false;
                    break;
                case "04":
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                    Panel4.Visible = false;
                    break;
                case "05":
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    Panel4.Visible = true;
                    break;
            }
        }
    }
}