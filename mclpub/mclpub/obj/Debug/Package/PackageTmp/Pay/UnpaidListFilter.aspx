<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UnpaidListFilter.aspx.cs" Inherits="mclpub.Pay.UnpaidListFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 催款處理</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>
    <td align="right" class="font_bold" style="width:160px">計畫代號：
      </td>
      <td>
          <asp:TextBox ID="tbxProj" runat="server" Width="118px" MaxLength="10"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold" style="width:160px">發票日期：</td>
      <td>
          <asp:TextBox ID="tbxDate1" runat="server"  Width="82px" CssClass="UniqueDate"></asp:TextBox>
          ～<asp:TextBox ID="tbxDate2" runat="server" Width="84px" CssClass="UniqueDate"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold" style="width:160px">廠商統一編號：</td>
      <td>
          <asp:TextBox ID="tbxMfrno" runat="server" Width="122px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold" style="width:160px">廠商名稱：</td>
      <td>
          <asp:TextBox ID="tbxMfrname" runat="server"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold" style="width:160px">發票號碼：</td>
      <td>
          <asp:TextBox ID="tbxInvno" runat="server" Width="120px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold" style="width:160px">發票開立單編號：</td>
      <td>
          <asp:TextBox ID="tbxIano" runat="server" Width="106px"></asp:TextBox>
      </td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="btnSearch" runat="server" Text="查詢" onclick="btnSearch_Click" />
        <asp:Button ID="btnPrintList" runat="server" Enabled="False" 
            onclick="btnPrintList_Click" Text="列印報表" />
    </td>    
  </tr>
</table>
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
        <asp:Label ID="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
    </td>
</tr>
</table>
<span class="stripeMe">
    <asp:GridView ID="DataGrid1" runat="server" Width="100%" 
        AutoGenerateColumns="false" CssClass="font_blacklink font_size12" Font-Size="11px">
    <Columns>  
    <asp:BoundField DataField="mfr_inm" HeaderText="廠商名稱" />
    <asp:BoundField DataField="ia_mfrno" HeaderText="統一編號" />
    <asp:BoundField DataField="ia_invdate" HeaderText="發票日" />
    <asp:BoundField DataField="ia_invno" HeaderText="發票號碼" />
    <asp:BoundField DataField="iad_desc" HeaderText="品名" />
    <asp:BoundField DataField="ia_pyat" HeaderText="發票金額" />
    <asp:BoundField DataField="py_amt" HeaderText="繳款金額" />
    <asp:BoundField DataField="iad_amt" HeaderText="明細金額" />
    <asp:BoundField DataField="py_chkno" HeaderText="票據號碼" />
    <asp:BoundField DataField="py_pyno" HeaderText="繳款單號" />
    <asp:BoundField DataField="py_date" HeaderText="繳款日" />
    <asp:BoundField DataField="ia_syscd" HeaderText="系統代號" />
    <asp:BoundField DataField="ia_iano" HeaderText="發票開立單編號" />
    <asp:BoundField DataField="ia_iasdate" HeaderText="轉檔年月" />
    <asp:BoundField DataField="ia_iasseq" HeaderText="批次" />
    <asp:BoundField DataField="ias_createdate" HeaderText="產生清單日期" />
    <asp:BoundField DataField="ias_createmen" HeaderText="產生清單員工" />
    <asp:BoundField DataField="ia_fgitri" HeaderText="往來種類" />
    <asp:BoundField DataField="ias_trans_sap" HeaderText="已轉SAP" />
    <asp:BoundField DataField="ia_fgnonauto" HeaderText="人工產生註記" />
    <asp:BoundField DataField="ia_remark" HeaderText="備註" />
    <asp:BoundField DataField="iad_fk1" HeaderText="FK1" />
    <asp:BoundField DataField="iad_fk2" HeaderText="FK2" />
    <asp:BoundField DataField="iad_fk3" HeaderText="FK3" />
    <asp:BoundField DataField="iad_fk4" HeaderText="FK4" />
    </Columns>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>

</span>
</asp:Content>
