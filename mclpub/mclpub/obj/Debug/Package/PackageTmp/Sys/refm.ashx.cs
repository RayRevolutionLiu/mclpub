using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace mclpub.Sys
{
    /// <summary>
    ///refm1 的摘要描述
    /// </summary>
    public class refm1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string ddlrm_syscd = context.Request.Form["ddlrm_syscd"];
            string rm_remark = context.Request.Form["rm_remark"];
            string rm_deptcd = context.Request.Form["rm_deptcd"];
            string rm_accddr = context.Request.Form["rm_accddr"];
            string rm_idescr = context.Request.Form["rm_idescr"];
            string rm_iunit = context.Request.Form["rm_iunit"];
            string rm_iremark = context.Request.Form["rm_iremark"];

            refm_DB myrefm = new refm_DB();

            try
            {
                DataSet ds = new DataSet();
                ds = myrefm.SelectREFM_syscd(ddlrm_syscd);
                if (ds.Tables[0].Rows.Count > 0)//p key不可重複
                {
                    context.Response.Write("No!");
                    return;
                }
                else
                {
                    myrefm.INSERTrefm(ddlrm_syscd, rm_remark, rm_deptcd, rm_accddr, rm_idescr, rm_iunit, rm_iremark);
                    context.Response.Write("Ok!");
                }
            }
            catch
            {
                context.Response.Write("Error!");
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