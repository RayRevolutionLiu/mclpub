using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace mclpub.Sys
{
    /// <summary>
    ///HandlerOtp 的摘要描述
    /// </summary>
    public class HandlerOtp : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            otp_DB myotp = new otp_DB();
            string ddlotp_otp1cd = context.Request.Form["ddlotp_otp1cd"];

            if (ddlotp_otp1cd.ToString().Trim() != "01" && ddlotp_otp1cd.ToString().Trim() != "02" && ddlotp_otp1cd.ToString().Trim() != "03" && ddlotp_otp1cd.ToString().Trim() != "09")
            {
                throw new Exception();
                //context.Response.Write("no");//表示參數被惡意動過
                //return;
            }

            DataTable dt = myotp.OutPutMaxValue(ddlotp_otp1cd);
            DataView dv = dt.DefaultView;

            string strAssignedContNo = "";

            if (dv.Count > 0 && dv[0]["C1"].ToString() != "0")
            {
                if (Convert.ToInt32((Convert.ToInt32(dv[0]["MaxCountNo"]) + 1)) < 10)
                {
                    strAssignedContNo = Convert.ToString("0" + (Convert.ToInt32(dv[0]["MaxCountNo"]) + 1));
                }
                else
                {
                    strAssignedContNo = Convert.ToString((Convert.ToInt32(dv[0]["MaxCountNo"]) + 1));
                }
            }
            else
            {
                strAssignedContNo += "01";
            }
//            string aa = @" [
//        {'ircEvent': 'PRIVMSG', 'method': 'newURI', 'regex': '^http://.*'}]";
//            context.Response.Write(aa);
            context.Response.Write(strAssignedContNo);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}