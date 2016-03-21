<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="errorPage.aspx.cs" Inherits="mclpub.errorPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <fieldset>
            <legend class="font_black font_size15">錯誤訊息</legend>
            <table>
                <tr>
                    <td class="font_black font_size15">
                        <br />
                        <%
                            string ErrorMsg = (Application["ErrorMsg"] == null) ? "您不可以進入本網頁!" : (string)Application["ErrorMsg"];
                            Response.Write(ErrorMsg);
                        %>                        
                    </td>
                </tr>
                <tr>
                    <td class="font_size13">
                    <a href="<%=ResolveUrl("~/Default.aspx")%>" target="_self">返回首頁</a>
                    </td>
                </tr>
             </table>
        </fieldset>
    </div>
    </form>
</body>
</html>
