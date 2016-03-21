<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RptIncomeQuery.aspx.cs" Inherits="mclpub.Statistics.RptIncomeQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;統計管理 / 印製份數統計表 / 當月未刊登</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
    <tr>

    <td align="right" width="220" class="font_bold">廣告日區間：</td>
    <td>
        <asp:TextBox ID="tbxSDate" runat="server" Width="100px" CssClass="UniqueDate"></asp:TextBox>～
        <asp:textbox id="tbxEDate" runat="server" Width="100px" CssClass="UniqueDate"></asp:textbox>
        </td>
 </tr>
  <tr>

    <td align="right" width="220" class="font_bold">承辦業務員：</td>
    <td>
        <asp:dropdownlist id="ddlEmpData" runat="server"></asp:dropdownlist>
      </td>
  </tr>
    </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <td align="left">
            </td>
            <td align="right">
                <asp:Button ID="CheckBtn" runat="server" Text="產生廣告收入統計表" OnClick="CheckBtn_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
