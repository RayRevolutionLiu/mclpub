<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="S_FixCostCenter.aspx.cs" Inherits="mclpub.Sys.S_FixCostCenter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;系統管理 / 成本中心異動修正</span> 
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>
    <td align="right" class="font_bold" style="width:160px">新成本中心代號：
      </td>
      <td>
          <asp:TextBox ID="tbxCostCenterNo" runat="server" Width="180px" MaxLength="7"></asp:TextBox>
          <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="請輸入新成本中心代號，不能空白!!" ControlToValidate="tbxCostCenterNo"></asp:RequiredFieldValidator>
      </td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="btnSearch" runat="server" Text="確定異動" onclick="btnSearch_Click" />
    </td>    
  </tr>
</table>


</asp:Content>
