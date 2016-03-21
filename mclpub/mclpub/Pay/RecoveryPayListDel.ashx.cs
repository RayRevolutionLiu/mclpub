using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mclpub.Pay
{
    /// <summary>
    ///RecoveryPayListDel 的摘要描述
    /// </summary>
    public class RecoveryPayListDel : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            PayListPrint_DB myPay = new PayListPrint_DB();
            string pys_pysdate = context.Request.Form["pys_pysdate"];
            string pys_pysseq = context.Request.Form["pys_pysseq"];
            try
            {
                myPay.DelPyseq(pys_pysdate, pys_pysseq);
                context.Response.Write("OK");
            }
            catch (Exception ex)
            {
                context.Response.Write(ex.Message);
            }
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