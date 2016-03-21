using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using Newtonsoft.Json;

namespace mclpub.Pay
{
    /// <summary>
    ///PayListPrintGen 的摘要描述
    /// </summary>
    public class PayListPrintGen : IHttpHandler
    {

        public class TooL
        {
            public string py_pyno { get; set; }
            public string py_date { get; set; }
            public string py_amt { get; set; }
            public string py_pysdate { get; set; }
            public string py_pysseq { get; set; }
            public string py_pysitem { get; set; }
            public string py_moseq { get; set; }
            public string py_moitem { get; set; }
            public string py_chkno { get; set; }
            public string py_chkbnm { get; set; }
            public string py_chkdate { get; set; }
            public string py_waccno { get; set; }
            public string py_wdate { get; set; }
            public string py_wbcd { get; set; }
            public string py_ccno { get; set; }
            public string py_ccauthcd { get; set; }
            public string py_ccvdate { get; set; }
        }


        public void ProcessRequest(HttpContext context)
        {
            string pys_pysdate = context.Request.Form["pys_pysdate"];
            string pys_pysseq = context.Request.Form["pys_pysseq"];

            PayListPrint_DB myPay = new PayListPrint_DB();
            DataSet ds = myPay.Selectpy();
            DataView dv3 = ds.Tables[0].DefaultView;
            dv3.RowFilter = "py_pysdate = '" + pys_pysdate + "' and py_pysseq = '" + pys_pysseq + "'";


            List<TooL> eList = new List<TooL>();


            if (dv3.Count > 0)
            {
                for (int i = 0; i < dv3.Count; i++)
                {
                    TooL e = new TooL();
                    e.py_pyno = dv3[i]["py_pyno"].ToString();
                    e.py_date = dv3[i]["py_date"].ToString();
                    e.py_amt = dv3[i]["py_amt"].ToString();
                    e.py_pysdate = dv3[i]["py_pysdate"].ToString();
                    e.py_pysseq = dv3[i]["py_pysseq"].ToString();
                    e.py_pysitem = dv3[i]["py_pysitem"].ToString();
                    e.py_moseq = dv3[i]["py_moseq"].ToString();
                    e.py_moitem = dv3[i]["py_moitem"].ToString();
                    e.py_chkno = dv3[i]["py_chkno"].ToString();
                    e.py_chkbnm = dv3[i]["py_chkbnm"].ToString();
                    e.py_chkdate = dv3[i]["py_chkdate"].ToString();
                    e.py_waccno = dv3[i]["py_waccno"].ToString();
                    e.py_wdate = dv3[i]["py_wdate"].ToString();
                    e.py_wbcd = dv3[i]["py_wbcd"].ToString();
                    e.py_ccno = dv3[i]["py_ccno"].ToString();
                    e.py_ccauthcd = dv3[i]["py_ccauthcd"].ToString();
                    e.py_ccvdate = dv3[i]["py_ccvdate"].ToString();
                    eList.Add(e);
                }

                string ans = JavaScriptConvert.SerializeObject(eList);  //new
                context.Response.ContentType = "application/json";
                context.Response.Write(ans);
            }
            else
            {
                context.Response.Write("Empty");
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