using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace mclpub
{
    public class Global : System.Web.HttpApplication
    {

        //public string GetSSOAttribute(string AttrName)
        //{

        //    if (ConfigurationSettings.AppSettings["DEBUG"].ToUpper() == "TRUE")
        //    {
        //        return ConfigurationSettings.AppSettings["DEBUG.ACCOUNT"];
        //    }

        //    string AllHttpAttrs, FullAttrName, Result;
        //    int AttrLocation;
        //    AllHttpAttrs = Request.ServerVariables["ALL_HTTP"];
        //    FullAttrName = "HTTP_" + AttrName.ToUpper();
        //    AttrLocation = AllHttpAttrs.IndexOf(FullAttrName + ":");
        //    if (AttrLocation > 0)
        //    {
        //        Result = AllHttpAttrs.Substring(AttrLocation + FullAttrName.Length + 1);
        //        AttrLocation = Result.IndexOf("\n");
        //        if (AttrLocation <= 0) AttrLocation = Result.Length + 1;
        //        //return Result.Substring(0, AttrLocation - 1);
        //        return HttpContext.Current.Request.ServerVariables["HTTP_SM_USER"];
        //    }

        //    return "";
        //}


        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            ////把single sign on 之後的工號抓到
            //string getAD = GetSSOAttribute("SM_USER");
            //AccountInfo accInfo = new Account().ExecLogon(getAD);
            ////如果accinfo不等於空值
            //if (accInfo != null)
            //{
            //    //將該物件accinfo傳給Session["AccountInfo"]保存
            //    Session["pwerRowData"] = accInfo;

            //}
            //else
            //{
            //    Application["ErrorMsg"] = "您沒有權限";
            //    Response.Redirect("~/errorPage.aspx");
            //}
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            /////*===========explain：save message*/
            //bool IsExecAjax = false;
            //Regex regexFormat = new Regex(@"exec\S*\.aspx", RegexOptions.IgnoreCase);
            //IsExecAjax = (regexFormat.Match(Request.Path).Success == true) ? true : false;

            //Exception ex = Server.GetLastError().GetBaseException();
            //string Message = string.Format("訊息：{0}", ex.GetBaseException().Message);


            ///*===========explain：show message*/
            //Server.ClearError();

            //if (IsExecAjax)
            //{
            //    Response.Write(Message);
            //}
            //else
            //{
            //    Application["ErrorMsg"] = Message;
            //    Response.Redirect("~/errorPage.aspx");

            //}
        }

        protected void Session_End(object sender, EventArgs e)
        {
            //Session.Add("pwerRowData", null);
            //Session["OrderType"] = null;
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}