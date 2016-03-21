using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Subscriber
{
    public partial class Printadvert2 : System.Web.UI.Page
    {
        Printadvert_DB myPrint = new Printadvert_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Expires = 0;

                // 抓出標籤資料
                GetLabelData();
            }
        }

        private void GetLabelData()
        {
            // 抓出篩選條件
            string strConttp = "", strBkcd = "", strMtpcd = "00";

            if (Request.QueryString["conttp"].ToString().Trim() != "")
            {
                strConttp = Request.QueryString["conttp"].ToString().Trim();
            }

            if (Request.QueryString["bkcd"].ToString().Trim() != "")
            {
                strBkcd = Request.QueryString["bkcd"].ToString().Trim();
            }

            if (Request.QueryString["mtpcd"].ToString().Trim() != "")
            {
                strMtpcd = Request.QueryString["mtpcd"].ToString().Trim();
            }

            DataTable dt = myPrint.Select3Chkbtn(strConttp, strBkcd, strMtpcd);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }


    }
}
