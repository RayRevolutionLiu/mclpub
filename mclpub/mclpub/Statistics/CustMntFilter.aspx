<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CustMntFilter.aspx.cs" Inherits="mclpub.Statistics.CustMntFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;統計管理 / 客戶份數表</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="220" class="font_bold">統計月份：</td>
    <td>
        <asp:DropDownList ID="ddlYear" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlMonth" runat="server">
            <asp:ListItem Value="01">1</asp:ListItem>
            <asp:ListItem Value="02">2</asp:ListItem>
            <asp:ListItem Value="03">3</asp:ListItem>
            <asp:ListItem Value="04">4</asp:ListItem>
            <asp:ListItem Value="05">5</asp:ListItem>
            <asp:ListItem Value="06">6</asp:ListItem>
            <asp:ListItem Value="07">7</asp:ListItem>
            <asp:ListItem Value="08">8</asp:ListItem>
            <asp:ListItem Value="09">9</asp:ListItem>
            <asp:ListItem Value="10">10</asp:ListItem>
            <asp:ListItem Value="11">11</asp:ListItem>
            <asp:ListItem Value="12">12</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>

    <td align="right" width="220" class="font_bold">書籍類別：</td>
    <td>
        <asp:DropDownList ID="ddlBookType" runat="server">
            <asp:ListItem Selected="True" Value="01">工材訂閱</asp:ListItem>
            <asp:ListItem Value="02">電材訂閱</asp:ListItem>
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
            <asp:Button ID="btnPrintList" runat="server" Enabled="False" Text="列印報表" 
                onclick="btnPrintList_Click" />
        </td>
    </tr>
</table>

<span class="stripeMe">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
    CssClass="font_blacklink font_size13" Width="100%">
    <Columns>
        <asp:BoundField DataField="otp_otp1nm" HeaderText="訂閱類別一" />
        <asp:BoundField DataField="otp_otp2nm" HeaderText="訂閱類別二" />
        <asp:BoundField DataField="tmp_param1" HeaderText="訂戶數" />
        <asp:BoundField DataField="tmp_param2" HeaderText="訂閱份數" />
    </Columns>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
        查詢無結果
    </EmptyDataTemplate>
</asp:GridView>
</span>
</asp:Content>
