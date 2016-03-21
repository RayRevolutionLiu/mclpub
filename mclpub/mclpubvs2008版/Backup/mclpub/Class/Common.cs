using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using FlexCel.Core;
using FlexCel.XlsAdapter;
using FlexCel.Render;

namespace mclpub
{
    /// <summary>
    /// Common 
    /// </summary>
    public class Common
    {
        #region 檢查身份證字號格式
        public static bool CheckIdentificationId(string Input_ID)
        {
            bool IsTrue = false;
            if (Input_ID.Length == 10)
            {
                Input_ID = Input_ID.ToUpper();
                if (Input_ID[0] >= 0x41 && Input_ID[0] <= 0x5A)
                {
                    int[] Location_No = new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 34, 18, 19, 20, 21, 22, 35, 23, 24, 25, 26, 27, 28, 29, 32, 30, 31, 33 };
                    int[] Temp = new int[11];
                    Temp[1] = Location_No[(Input_ID[0]) - 65] % 10;
                    int Sum = Temp[0] = Location_No[(Input_ID[0]) - 65] / 10;
                    for (int i = 1; i <= 9; i++)
                    {
                        Temp[i + 1] = Input_ID[i] - 48;
                        Sum += Temp[i] * (10 - i);
                    }
                    if (((Sum % 10) + Temp[10]) % 10 == 0)
                    {
                        IsTrue = true;
                    }
                }
            }
            return IsTrue;
        }
        #endregion

        #region 產出Excel
        public static void excuteExcel(ExcelFile Xls,string ShowfileName)
        {
            HttpContext.Current.Response.ContentType = "application/ms-excel";

            string fileName = HttpContext.Current.Server.UrlPathEncode(ShowfileName);
            string strContentDisposition = String.Format("{0}; filename=\"{1}\"", "attachment", fileName);
            HttpContext.Current.Response.AddHeader("Content-Disposition", strContentDisposition);

            MemoryStream ms = new MemoryStream();

            Xls.Save(ms, TFileFormats.Xls);
            ms.Position = 0;
            //FlexCelPdfExport ExPdf = new FlexCelPdfExport(Xls);
            //ExPdf.Workbook = Xls;
            //ExPdf.Export(ms);


            BinaryReader br = new BinaryReader(ms);
            BinaryWriter bw = new BinaryWriter(HttpContext.Current.Response.OutputStream);

            for (int i = 0; i < ms.Length; i++)
            {
                bw.Write(br.ReadByte());
            }
            bw.Close();
            ms.Close();

            bw = null;
            ms = null;

            HttpContext.Current.Response.OutputStream.Flush();
            HttpContext.Current.Response.OutputStream.Close();
            return;




            //HttpContext.Current.Response.ContentType = "application/ms-excel";

            //string fileName = HttpContext.Current.Server.UrlPathEncode("reply.xls");
            //string strContentDisposition = String.Format("{0}; filename=\"{1}\"", "attachment", fileName);
            //HttpContext.Current.Response.AddHeader("Content-Disposition", strContentDisposition);

            //MemoryStream ms = new MemoryStream();
            //Xls.Save(ms, TFileFormats.Xls);
            //ms.Position = 0;

            //BinaryReader br = new BinaryReader(ms);
            //BinaryWriter bw = new BinaryWriter(HttpContext.Current.Response.OutputStream);

            //for (int i = 0; i < ms.Length; i++)
            //{
            //    bw.Write(br.ReadByte());
            //}
            //bw.Close();
            //ms.Close();

            //bw = null;
            //ms = null;
            //HttpContext.Current.Response.OutputStream.Close();
        }
        #endregion

    }
    /// <summary>
    /// MbrAccount 的摘要描述。
    /// </summary>
    public class Account
    {
        string conn = ConfigurationManager.AppSettings["itridpr_mrlpub"].ToString();
        /// <summary>
        /// GetAccInfo
        /// </summary>
        /// <returns></returns>
        public static AccountInfo GetAccInfo()
        {
            return (AccountInfo)HttpContext.Current.Session["pwerRowData"];
        }


        /// <summary>
        /// 進行帳號登入檢查，通過後會取得登入者資料並放入session:ds_CurrentUser
        /// </summary>
        /// <param name="inputID"></param>
        /// <returns></returns>
        public AccountInfo ExecLogon(string getAD)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter oda = new SqlDataAdapter();
            SqlConnection thisConnection = new SqlConnection(conn);
            SqlCommand thisCommand = thisConnection.CreateCommand();
            StringBuilder show_value = new StringBuilder();
            try
            {
                thisConnection.Open();
                show_value.Append(@"select * from srspn where srspn_empno=@getAD");
                thisCommand.Parameters.AddWithValue("@getAD", getAD);
                thisCommand.CommandType = CommandType.Text;
                thisCommand.CommandText = show_value.ToString();
                oda.SelectCommand = thisCommand;
                oda.Fill(ds);
            }
            finally
            {
                oda.Dispose();
                thisConnection.Close();
                thisConnection.Dispose();
                thisCommand.Dispose();

            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                return new AccountInfo(ds);
            }
            else
            {
                return null;
            }
        }

    }

    /*-------------------------------------------------------------------------------------------------------------------------*/

    /// <summary>
    /// MbrInfo 的摘要描述。
    /// </summary>
    public class AccountInfo
    {
        /// <summary>
        /// 工號
        /// </summary>
        public readonly string srspn_empno = "";
        /// <summary>
        /// 姓名
        /// </summary>
        public readonly string srspn_cname = "";
        /// <summary>
        /// 電話
        /// </summary>
        public readonly string srspn_tel = "";
        /// <summary>
        /// 身分類別
        /// </summary>
        public readonly string srspn_atype = "";
        /// <summary>
        /// 單位
        /// </summary>
        public readonly string srspn_orgcd = "";
        /// <summary>
        /// 部門
        /// </summary>
        public readonly string srspn_deptcd = "";


        public AccountInfo(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];

                srspn_empno = dr["srspn_empno"].ToString();
                srspn_cname = dr["srspn_cname"].ToString();
                srspn_tel = dr["srspn_tel"].ToString();
                srspn_atype = dr["srspn_atype"].ToString();
                srspn_orgcd = dr["srspn_orgcd"].ToString();
                srspn_deptcd = dr["srspn_deptcd"].ToString();
                //if (mbrAccid.ToLower() == "guest")
                //{
                //    isGuestRole = true;
                //}
                //else if (mbrAccid.ToLower() != "guest")
                //{
                //    if (mbrTypeStatus == "1")
                //    {
                //        isApplyMbrRole = true;
                //    }
                //    else if (mbrTypeStatus == "2")
                //    {
                //        isApproveMbrRole = true;
                //    }


                //    if (mbrTypeStatus == "2" && mbrTypeAdmin == "1")
                //    {
                //        isAdminRole = true;
                //    }


                //    //if (mbrTypeClass == "mbr4")
                //    //{
                //    //    mbrTypeClass2 = "MEMBER04";
                //    //    isMbrClassOfService = true;
                //    //}
                //    //else if (mbrTypeClass == "mbr5")
                //    //{
                //    //    mbrTypeClass2 = "MEMBER05";
                //    //    isMbrClassOfPOrT = true;
                //    //    isMbrClassOfTeam = true;
                //    //}
                //    //else if (mbrTypeClass == "mbr6")
                //    //{
                //    //    mbrTypeClass2 = "MEMBER06";
                //    //    isMbrClassOfPOrT = true;
                //    //    isMbrClassOfPerson = true;
                //}
            }
        }
    }

    /*-------------------------------------------------------------------------------------------------------------------------*/
    /// <summary>
    /// JavaScript 的摘要描述。
    /// </summary>
    public class JavaScript
    {
        /// <summary>
        /// AlertMessage
        /// </summary>
        public static void AlertMessage(System.Web.UI.Page objPage, string strMessage)
        {
            strMessage = strMessage.Replace("\r\n", "\\r");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"<Script language=""javascript"" type=""text/javascript"">");
            sb.AppendFormat(@"alert(""{0}"");", strMessage);
            sb.AppendFormat(@"</Script>");

            //objPage.ClientScript.RegisterClientScriptBlock(objPage.GetType(), "", strJS, false);
            objPage.ClientScript.RegisterStartupScript(objPage.GetType(), "", sb.ToString(), false);
        }

        /// <summary>
        /// AlertMessageClose
        /// </summary>
        public static void AlertMessageClose(System.Web.UI.Page objPage, string strMessage)
        {
            string strJS = "";
            strMessage = strMessage.Replace("\r\n", "\\r");
            strJS = @"<Script language='javascript' type='text/javascript' >";
            strJS += "alert('" + strMessage + "');";
            strJS += "window.close();";
            strJS += "</Script>";
            //objPage.ClientScript.RegisterClientScriptBlock(objPage.GetType(), "", strJS, false);
            objPage.ClientScript.RegisterStartupScript(objPage.GetType(), "", strJS, false);
        }

        /// <summary>
        /// AlertMessageRedirect
        /// </summary>
        public static void AlertMessageRedirect(System.Web.UI.Page objPage, string strMessage, string strRedirectPage)
        {
            AlertMessageRedirect(objPage, strMessage, strRedirectPage, false);
        }

        public static void AlertMessageRedirect(System.Web.UI.Page objPage, string strMessage, string strRedirectPage, bool IsDisplayData)
        {
            string strJS = "";
            strMessage = strMessage.Replace("\r\n", "\\r");
            strJS = @"<Script language='javascript' type='text/javascript'>";
            strJS += "alert('" + strMessage + "');";
            strJS += "window.location ='" + strRedirectPage + "'; ";
            strJS += "</Script>";

            if (IsDisplayData)
                objPage.ClientScript.RegisterStartupScript(objPage.GetType(), "", strJS, false);
            else
                objPage.ClientScript.RegisterClientScriptBlock(objPage.GetType(), "", strJS, false);
        }

    }

}
