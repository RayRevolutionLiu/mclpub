using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Contract
{
    public partial class cust_detail : System.Web.UI.Page
    {
        cust_detail_DB mycust = new cust_detail_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 藉由前一網頁傳來的變數值字串 custno
                string custno = "";
                if (Context.Request.QueryString["custno"].ToString().Trim() != "")
                {
                    custno = Context.Request.QueryString["custno"].ToString().Trim();
                    //Response.Write("custno= " + custno + "<br>");

                    // 檢查此客戶編號是否在資料庫中存在
                    CheckExist();

                }
                else
                {
                    Response.Write("<font size=2 color=red><b>資料庫中無此 客戶編號及其資料, 請先<A HREF='../Subscriber/AddCust.aspx' Target='_blank' OnClick='window.close()'>新增此客戶</A>!</b></font><br><br>");
                }
            }
        }


        private void CheckExist()
        {
            // 藉由前一網頁傳來的變數值字串 custno
            string custno = Context.Request.QueryString["custno"].ToString().Trim();
            DataTable dt = mycust.SelecCust(custno);

            // 若有資料, 則顯示資料; 否則給予錯誤訊息
            if (dt.Rows.Count <= 0)
            {
                Response.Write("<font size=2 color=red><b>資料庫中無此 客戶編號及其資料, 請先<A HREF='../Subscriber/AddCust.aspx' Target='_blank' OnClick='window.close()'>新增此客戶</A>!</b></font><br><br>");
            }
            else
            {
                // 若有此 客戶編號, 則顯示其相關資料
                GetData();
            }

        }


        // 若有此客戶編號, 則顯示其相關資料
        private void GetData()
        {
            // 藉由前一網頁傳來的變數值字串 custno
            string custno = Context.Request.QueryString["custno"].ToString().Trim();

            DataTable dt = mycust.SelecCust(custno);

            // 檢查並輸出 最後 Row Filter 的結果
            //Response.Write("dv.Count= "+ dv.Count + "<BR>");
            //Response.Write("dv.RowFilter= " + dv.RowFilter + "<BR>");

            // 若有資料, 則顯示相關資料; 否則給予錯誤訊息
            if (dt.Rows.Count > 0)
            {
                // 顯示出所有的 dv 裡的資料, 並用 \ 符號隔開區別
                //for (int i =0; i < dv.Count; i++)
                //{
                //for (int j=0;j<14;j++)
                //Response.Write(j + ":" + dv[i][j] + "\\ ");
                //}

                // 填入資料
                this.lblMfrID.Text = dt.Rows[0]["mfr_mfrid"].ToString();
                this.lblMfrIName.Text = dt.Rows[0]["mfr_inm"].ToString().Trim();
                this.lblMfrNo.Text = dt.Rows[0]["cust_mfrno"].ToString();
                this.lblMfrTel.Text = dt.Rows[0]["mfr_tel"].ToString().Trim();
                this.lblMfrIZipcode.Text = dt.Rows[0]["mfr_izip"].ToString().Trim();
                this.lblMfrIAddr.Text = dt.Rows[0]["mfr_iaddr"].ToString().Trim();

                this.lblCustID.Text = dt.Rows[0]["cust_custid"].ToString();
                this.lblCustName.Text = dt.Rows[0]["cust_nm"].ToString().Trim();
                this.lblCustNo.Text = dt.Rows[0]["cust_custno"].ToString().Trim();
                this.lblCustJobTitle.Text = dt.Rows[0]["cust_jbti"].ToString().Trim();

                string RegDate = dt.Rows[0]["cust_regdate"].ToString();
                this.lblCustRegDate.Text = RegDate.Substring(0, 4) + "/" + RegDate.Substring(4, 2) + "/" + RegDate.Substring(6, 2);
                string ModDate = dt.Rows[0]["cust_moddate"].ToString();
                this.lblCustModDate.Text = ModDate.Substring(0, 4) + "/" + ModDate.Substring(4, 2) + "/" + ModDate.Substring(6, 2);

                this.lblCustTel.Text = dt.Rows[0]["cust_tel"].ToString().Trim();
                this.lblCustFax.Text = dt.Rows[0]["cust_fax"].ToString().Trim();
                this.lblCustCell.Text = dt.Rows[0]["cust_cell"].ToString().Trim();
                this.lblCustEmail.Text = dt.Rows[0]["cust_email"].ToString().Trim();
                //this.lblCustItpCode.Text = dv[0]["cust_itpcd"].ToString();
                //this.lblCustBtpCode.Text = dv[0]["cust_btpcd"].ToString();
                //this.lblCustRtpCode.Text = dv[0]["cust_rtpcd"].ToString();

                // 舊客戶編號
                string OldCustNo = dt.Rows[0]["cust_oldcustno"].ToString().Trim();
                if (OldCustNo != "")
                    this.lblOldCustNo.Text = OldCustNo;
                else
                    this.lblOldCustNo.Text = "<font color='Gainsboro'>無資料</font>";


                if (dt.Rows[0]["cust_itpcd"].ToString().Trim() != "")
                {
                    DataTable dtitp = mycust.Selecitp();
                    DataView dv2 = dtitp.DefaultView;

                    int ItpcdCount = dt.Rows[0]["cust_itpcd"].ToString().Length / 2;
                    //Response.Write("ItpcdCount=" + ItpcdCount + "<br>");

                    string EachItpcd = "";
                    string EachItpName = "";
                    for (int i = 0; i < ItpcdCount; i++)
                    {
                        EachItpcd = dt.Rows[0]["cust_itpcd"].ToString().Substring(i * 2, 2);
                        //Response.Write("EachItpcd= " + EachItpcd + "<br>");
                        dv2.RowFilter = "itp_itpcd=" + EachItpcd;
                        EachItpName = dv2[0]["itp_nm"].ToString().Trim();
                        EachItpName += ", ";
                        //Response.Write("EachItpName= " + EachItpName + "<br>");
                        this.lblCustItpcd.Text += EachItpName;
                    }
                }
                else
                {
                    this.lblCustItpcd.Text = "(無資料)";
                }


                // 使用 DataSet 方法, 並指定使用的 table 名稱
                //Response.Write("cust_btpcd= " + dv[0]["cust_btpcd"].ToString().Trim() + "<br>");
                if (dt.Rows[0]["cust_btpcd"].ToString().Trim() != "")
                {
                    DataTable dtbtp = mycust.Selecbtp();
                    DataView dv3 = dtbtp.DefaultView;

                    int BtpcdCount = dt.Rows[0]["cust_btpcd"].ToString().Length / 2;
                    //Response.Write("BtpcdCount=" + BtpcdCount + "<br>");

                    string EachBtpcd = "";
                    string EachBtpName = "";
                    for (int i = 0; i < BtpcdCount; i++)
                    {
                        EachBtpcd = dt.Rows[0]["cust_btpcd"].ToString().Substring(i * 2, 2);
                        //Response.Write("EachItpcd= " + EachItpcd + "<br>");
                        dv3.RowFilter = "btp_btpcd=" + EachBtpcd;
                        EachBtpName = dv3[0]["btp_nm"].ToString().Trim();
                        EachBtpName += ", ";
                        //Response.Write("EachBtpName= " + EachBtpName + "<br>");
                        this.lblCustBtpcd.Text += EachBtpName;
                    }
                }
                else
                {
                    this.lblCustBtpcd.Text = "(無資料)";
                }
            }
            else
            {
                // 若找無資料, 則清除資料
                this.lblMfrIName.Text = "(<font color='RED'>查無此廠商統編, 請先<A HREF='../Subscriber/AddComp.aspx' Target='_blank' OnClick='window.close()'>新增此廠商</A>!</font>)";
                this.lblMfrNo.Text = "";
                this.lblMfrTel.Text = "";
                this.lblMfrIZipcode.Text = "";
                this.lblMfrIAddr.Text = "";

                this.lblCustName.Text = "";
                this.lblCustNo.Text = "";
                this.lblCustJobTitle.Text = "";
                this.lblCustRegDate.Text = "";
                this.lblCustModDate.Text = "";
                this.lblCustTel.Text = "";
                this.lblCustFax.Text = "";
                this.lblCustCell.Text = "";
                this.lblCustEmail.Text = "";
                this.lblCustItpcd.Text = "";
                this.lblCustBtpcd.Text = "";
                //				this.lblCustRtpcd.Text = "";
                this.lblOldCustNo.Text = "";
            }
        }
    }
}
