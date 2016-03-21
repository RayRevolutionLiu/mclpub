<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="orcounts_stat_search3.aspx.cs" Inherits="mclpub.Statistics.orcounts_stat_search3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;統計管理 / 郵寄份數統計表 / 合約外寄送</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
    <tr>

    <td align="right" width="220" class="font_bold">書籍類別：</td>
    <td>
        <asp:DropDownList ID="ddlBookCode" runat="server">
        </asp:DropDownList>
      </td>
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
        <td align="right" width="220" class="font_bold">
            合約類別：
        </td>
        <td>
            <asp:DropDownList ID="ddlConttp" runat="server">
                <asp:ListItem Value="00" Selected="True">請選擇</asp:ListItem>
                <asp:ListItem Value="01">一般</asp:ListItem>
                <asp:ListItem Value="09">推廣</asp:ListItem>
            </asp:DropDownList>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="right" width="220" class="font_bold">
            郵寄地區：
        </td>
        <td>
            <asp:DropDownList ID="ddlfgMOSea" runat="server" 
                onselectedindexchanged="ddlfgMOSea_SelectedIndexChanged">
                <asp:ListItem Value="" Selected="True">請選擇</asp:ListItem>
                <asp:ListItem Value="0">國內</asp:ListItem>
                <asp:ListItem Value="1">國外</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" width="220" class="font_bold">
            郵寄類別：
        </td>
        <td>
            <asp:DropDownList ID="ddlMtpcd" runat="server">
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
