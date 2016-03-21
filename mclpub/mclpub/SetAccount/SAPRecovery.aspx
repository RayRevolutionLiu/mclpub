<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SAPRecovery.aspx.cs" Inherits="mclpub.SetAccount.SAPRecovery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 發票開立單轉SAP回復</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="120" class="font_bold">轉檔年月:</td>
    <td>
        <font face="新細明體">
        <asp:TextBox ID="lblyyyymm" runat="server" MaxLength="6" Width="83px"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" ForeColor="#C00000">(yyyymm例如:200301)</asp:Label>
		<asp:RequiredFieldValidator id="rfvEDate" runat="server" ControlToValidate="lblyyyymm" Display="Dynamic" ErrorMessage="不可空白"></asp:RequiredFieldValidator>
		<asp:RegularExpressionValidator id="revEDate" runat="server" ControlToValidate="lblyyyymm" Display="Dynamic" ErrorMessage="格式錯誤" ValidationExpression="[0-9]{6}"></asp:RegularExpressionValidator>
        </font>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">批次:</td>
    <td>
        <font face="新細明體">
        <asp:TextBox ID="lblbatchseq" runat="server" MaxLength="6" Width="83px"></asp:TextBox>
        </font>
      </td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <font face="新細明體">
        <asp:Label ID="lblMessage1" runat="server" Font-Size="Small" 
            ForeColor="#C00000"></asp:Label>
        <asp:Button ID="btn_Recovery" runat="server" Text="發票開立單轉SAP回復" 
             OnClientClick="javascript:return confirm('確定要執行發票開立單轉SAP回復?');" 
            onclick="btn_Recovery_Click" />
        </font>
    </td>
  </tr>
</table>
</asp:Content>
