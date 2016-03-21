<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IARecoveryQuery.aspx.cs" Inherits="mclpub.SetAccount.IARecoveryQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 網路廣告發票處理 / 大批月結之發票開立單回復(Recovery)</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>
    <td align="right" width="220" class="font_bold">
        發票開立單 產生年月：</td>
    <td align="left">
        <asp:TextBox ID="tbxYYYYMM" runat="server" Width="58px"></asp:TextBox>
        <asp:Label ID="lblyyyymm" runat="server" ForeColor="#C04000">(例如 : 2003/09)</asp:Label>
        <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Font-Size="Small"
                Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="tbxYYYYMM"></asp:requiredfieldvalidator>
        <asp:RegularExpressionValidator ID="revPubDate" runat="server" 
            ControlToValidate="tbxYYYYMM" ErrorMessage="刊登年月 請依格式填入" 
            Font-Size="Small" ValidationExpression="\d{4}/\d{2}" Display="Dynamic"></asp:RegularExpressionValidator>
      </td>
  </tr>
  <tr>
    <td align="right" width="220" class="font_bold">
        發票開立單 產生批次： </td>
    <td align="left">
        <asp:TextBox ID="tbxBatch" runat="server" Width="58px"></asp:TextBox>
        <asp:Label ID="lblBatch" runat="server" ForeColor="#C04000">(例如 : 000001)</asp:Label>
        <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" Font-Size="Small"
                Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="tbxBatch"></asp:requiredfieldvalidator>

      </td>
  </tr>
  </table>
</span>
 <table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left">
        &nbsp;</td>
    <td align="right">
        <asp:Button ID="btnSearch" runat="server" Text="查詢" onclick="btnSearch_Click" />
    </td>
  </tr>
</table>

<span class="font_size13 font_bold font_gray">
<ol>
    <li>已於會計系統做處理之發票開立單無法做回復</li>
</ol>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />查詢結果
            </td>
            <td align="right">
<asp:Button id="btnOK" runat="server" Text="確定回復這一批資料" onclick="btnOK_Click" Visible="false"></asp:Button>
            </td>        
        </tr>
</table>

<span class="stripeMe">
<asp:GridView ID="DataGrid1" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size13" 
                EnableModelValidation="True" 
        onrowdatabound="DataGrid1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="ia_iano"  HeaderText="發票開立單編號" />
            <asp:BoundField DataField="ia_contno"  HeaderText="合約編號" />
            <asp:BoundField DataField="ia_mfrno"  HeaderText="發票廠商統編" />
            <asp:BoundField DataField="mfr_inm"  HeaderText="發票廠商名稱" />
            <asp:BoundField DataField="ia_rnm"  HeaderText="發票收件人" />
            <asp:BoundField DataField="ia_pyat"  HeaderText="發票金額" />
            <asp:BoundField DataField="ia_invcd"  HeaderText="發票類別" />
            <asp:BoundField DataField="ia_taxtp"  HeaderText="課稅別" />
            <asp:BoundField DataField="ia_fgitri"  HeaderText="往來註記" />
            <asp:BoundField DataField="ia_status"  HeaderText="進行狀態" />
            <asp:BoundField DataField="ia_status"  HeaderText="ia_status" />
        </Columns>  
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
        <PagerSettings Visible="False">
        </PagerSettings>
</asp:GridView>
</span>
</asp:Content>
