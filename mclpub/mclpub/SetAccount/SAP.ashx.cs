using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Newtonsoft.Json;

namespace mclpub.SetAccount
{
    /// <summary>
    ///SAP1 的摘要描述
    /// </summary>
    public class SAP1 : IHttpHandler
    {

        public class TooL
        {
            public string ia_refno { get; set; }
            public string ia_mfrno { get; set; }
            public string ia_pyno { get; set; }
            public string ia_pyat { get; set; }
            public string ia_rnm { get; set; }
            public string ia_raddr { get; set; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string ias_iasdate = context.Request.Form["ias_iasdate"];
            string ias_iasseq = context.Request.Form["ias_iasseq"];

            SAP_DB mySAP = new SAP_DB();

            DataSet ds = mySAP.Selectia(ias_iasdate, ias_iasseq);

            List<TooL> eList = new List<TooL>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TooL e = new TooL();
                    e.ia_refno = ds.Tables[0].Rows[i]["ia_refno"].ToString();
                    e.ia_mfrno = ds.Tables[0].Rows[i]["ia_mfrno"].ToString();
                    e.ia_pyno = ds.Tables[0].Rows[i]["ia_pyno"].ToString();
                    e.ia_pyat = ds.Tables[0].Rows[i]["ia_pyat"].ToString();
                    e.ia_rnm = ds.Tables[0].Rows[i]["ia_rnm"].ToString();
                    e.ia_raddr = ds.Tables[0].Rows[i]["ia_raddr"].ToString();
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