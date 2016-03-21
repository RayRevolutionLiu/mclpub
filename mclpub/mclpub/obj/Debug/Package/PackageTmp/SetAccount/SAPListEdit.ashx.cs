using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace mclpub.SetAccount
{
    /// <summary>
    ///SAPListEdit1 的摘要描述
    /// </summary>
    public class SAPListEdit1 : IHttpHandler
    {
        public class TooL
        {
            public string ia_iaitem { get; set; }
            public string ia_refno { get; set; }
            public string ia_mfrno { get; set; }
            public string mfr_inm { get; set; }
            public string ia_invno { get; set; }
            public string ia_invdate { get; set; }
            public string ia_fgitri { get; set; }
            public string ia_fgnonauto { get; set; }
            //public string ia_syscd { get; set; }
            //public string ia_iasdate { get; set; }
            //public string ia_iasseq { get; set; }
        }


        public void ProcessRequest(HttpContext context)
        {
            string ia_syscd = context.Request.Form["ia_syscd"];
            string ia_iasdate = context.Request.Form["ia_iasdate"];
            string ia_iasseq = context.Request.Form["ia_iasseq"];

            if (ia_syscd.Length != 2 || ia_syscd.IndexOf("C") == -1)
            {
                //參數防APP_Scan
                context.Response.Write("Error");
                return;
            }

            try
            {
                //參數防APP_Scan
                int tmpia_iasdate = Convert.ToInt32(ia_iasdate);
                int tmpia_iasseq = Convert.ToInt32(ia_iasseq);
            }
            catch
            {
                context.Response.Write("Error");
            }

            SAPListEdit_DB mySAP = new SAPListEdit_DB();
            DataSet ds = mySAP.Selectia(ia_syscd, ia_iasdate, ia_iasseq);

            List<TooL> eList = new List<TooL>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    TooL e = new TooL();
                    e.ia_iaitem = ds.Tables[0].Rows[i]["ia_iaitem"].ToString();
                    e.ia_refno = ds.Tables[0].Rows[i]["ia_refno"].ToString();
                    e.ia_mfrno = ds.Tables[0].Rows[i]["ia_mfrno"].ToString();
                    e.mfr_inm = ds.Tables[0].Rows[i]["mfr_inm"].ToString();
                    e.ia_invno = ds.Tables[0].Rows[i]["ia_invno"].ToString();
                    e.ia_invdate = ds.Tables[0].Rows[i]["ia_invdate"].ToString();
                    e.ia_fgitri = ds.Tables[0].Rows[i]["ia_fgitri"].ToString();
                    e.ia_fgnonauto = ds.Tables[0].Rows[i]["ia_fgnonauto"].ToString();
                    eList.Add(e);
                }

                System.Web.Script.Serialization.JavaScriptSerializer objSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                string ans = objSerializer.Serialize(eList);  //new
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