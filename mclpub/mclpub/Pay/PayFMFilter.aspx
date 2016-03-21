<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PayFMFilter.aspx.cs" Inherits="mclpub.Pay.PayFMFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 繳款處理 / 修改繳款單</span> 
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">繳款編號：</td>
    <td>
        <asp:TextBox ID="tbxPyno" runat="server" MaxLength="8"></asp:TextBox>
      </td>
  </tr>
  </table>
</span> 

<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="Button1" runat="server" Text="查詢" onclick="Button1_Click" />
    </td>
  </tr>
</table>
</asp:Content>
