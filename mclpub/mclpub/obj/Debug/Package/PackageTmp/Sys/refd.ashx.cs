using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace mclpub.Sys
{
    /// <summary>
    ///refd1 的摘要描述
    /// </summary>
    public class refd1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string ddlrd_syscd = context.Request.Form["ddlrd_syscd"];
            string ddlrd_projno = context.Request.Form["ddlrd_projno"];
            string rd_costctr = context.Request.Form["rd_costctr"];
            string rd_accdcr = context.Request.Form["rd_accdcr"];
            string rd_descr = context.Request.Form["rd_descr"];


            refd_DB myrefd = new refd_DB();

            try
            {
                DataSet ds = new DataSet();
                ds = myrefd.SelectPkeyDouble(ddlrd_syscd, ddlrd_projno);
                if (ds.Tables[0].Rows.Count > 0)//p key不可重複
                {
                    context.Response.Write("No!");
                    return;
                }
                else
                {
                    myrefd.INSERTrefd(ddlrd_syscd, ddlrd_projno, rd_costctr, rd_accdcr, rd_descr);
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