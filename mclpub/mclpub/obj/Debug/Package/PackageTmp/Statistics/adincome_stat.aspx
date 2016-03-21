<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="adincome_stat.aspx.cs" Inherits="mclpub.Statistics.adincome_stat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;統計管理 / 廣告收入統計表</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="220" class="font_bold">統計月份：</td>
    <td>
        <asp:TextBox ID="tbxPubDate" runat="server" Width="60px"></asp:TextBox>
        <font color="maroon" size="2">(如2002/08, 預設值: 當月)</font>
        <asp:RegularExpressionValidator ID="revPubDate" runat="server" 
            ControlToValidate="tbxPubDate" ErrorMessage="刊登年月 請依格式填入" 
            Font-Size="Small" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator>
        <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Font-Size="Small"
                Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="tbxPubDate"></asp:requiredfieldvalidator>
      </td>
  </tr>
  <tr>

    <td align="right" width="220" class="font_bold">書籍類別：</td>
    <td>
        <asp:DropDownList ID="ddlBookCode" runat="server">
        </asp:DropDownList>
      </td>
 </tr>
  <tr>

    <td align="right" width="220" class="font_bold">承辦業務員：</td>
    <td>
        <asp:DropDownList ID="ddlEmpNo" runat="server">
        </asp:DropDownList>
      </td>
 </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="CheckBtn" runat="server" Text="查詢"  class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" OnClick="CheckBtn_Click"/>
    </td>
  </tr>
</table>  

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
    <tr>
        <td class="font_size18 font_bold">
            <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
        </td>
        <td align="right">
            &nbsp;</td>
    </tr>
</table>

<span class="stripeMe">
<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
<asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">此連結</asp:LinkButton>
<asp:label id="lblMessage2" runat="server" ForeColor="Red"></asp:label>
</span>
</asp:Content>
