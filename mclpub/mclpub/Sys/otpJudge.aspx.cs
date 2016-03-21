using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace mclpub.Sys
{
    public partial class otpJudge : System.Web.UI.Page
    {
        otp_DB myotp = new otp_DB();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string otp_otp1cd = Request.Form["otp_otp1cd"];
                string otp_otp1nm = Request.Form["otp_otp1nm"];
                string otp_otp2cd = Request.Form["otp_otp2cd"];
                string otp_otp2nm = Request.Form["otp_otp2nm"];


                if (otp_otp1cd != "01" && otp_otp1cd != "02" && otp_otp1cd != "03" && otp_otp1cd != "09")
                {
                    Response.Write("Error!");
                    return;
                }

                DataSet ds1 = myotp.Selectc1_otp();

                DataView dv = ds1.Tables[0].DefaultView;
                string Strfilter = " 1=1 AND otp_otp1cd = '" + otp_otp1cd.ToString().Trim() + "' AND otp_otp2cd='" + otp_otp2cd + "'";

                dv.RowFilter = Strfilter;

                if (dv.Count > 0)
                {
                    Response.Write("No!");
                    return;
                }

                else
                {
                    myotp.Insertc1_otp(otp_otp1cd, otp_otp1nm, otp_otp2cd, otp_otp2nm);
                    Response.Write("Ok!");
                }
            }
            catch
            {
                Response.Write("Error!");
            }
        }
    }
}