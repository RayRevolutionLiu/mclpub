<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="iaFm2_RecAll.aspx.cs" Inherits="mclpub.SetAccount.iaFm2_RecAll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 平面廣告發票處理 / 發票開立單回復(Recovery) - 大批月結</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">

  <tr>
    <th colspan="2">查詢條件</th>
  </tr>

  <tr>

    <td align="right" width="220" class="font_bold">
        <asp:Label ID="lblIabDate" runat="server">發票開立單 開立年月：</asp:Label>
      </td>

    <td>
        <asp:TextBox ID="tbxIabDate" runat="server" MaxLength="7" Width="60px"></asp:TextBox>
        <FONT color="darkred" size="2">
					(預設值：當月，如2002/08)</FONT>
        <asp:RegularExpressionValidator ID="revPubDate" runat="server" 
            ControlToValidate="tbxIabDate" ErrorMessage="刊登年月 請依格式填入" 
            Font-Size="Small" ValidationExpression="\d{4}/\d{2}" Display="Dynamic"></asp:RegularExpressionValidator>
        <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Font-Size="Small"
                Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="tbxIabDate"></asp:requiredfieldvalidator>
    </td>
  </tr>

  <tr>

    <td align="right" width="220" class="font_bold">
        <asp:Label ID="lblIabNo" runat="server">發票開立單 批號：</asp:Label>
      </td>

    <td>
        <asp:TextBox ID="tbxIabNo" runat="server" MaxLength="6" Width="60px"></asp:TextBox>
        <FONT color="red" size="2">
					(請自 "發票開立單 檢核表" 參考，請填正確值，如 000001)</FONT>
        <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" Font-Size="Small"
                Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="tbxIabNo"></asp:requiredfieldvalidator>
      </td>
  </tr>
</table>
</span>
 <table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">

        <asp:Button ID="btnQuery" runat="server" Text="查詢" onclick="btnQuery_Click" />

    </td>
  </tr>
</table>
<span class="font_size13 font_bold font_gray">
<ol>
    <li>已於會計系統做處理之發票開立單無法做回復！</li>
    <li>查詢後將顯示該批資料, 您可<span class="font_darkblue">先列印回復清單</span>, 確認後再按下<span class="font_darkblue">確認回復</span>按鈕</li>
</ol>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
        <asp:Button ID="btnRecovery" runat="server" Text="確認回復" OnClick="btnRecovery_Click" />
        <asp:Button ID="btnPrintList" runat="server" Text="列印回復清單" 
            onclick="btnPrintList_Click" />
    </td>
</tr>
</table>
<span class="stripeMe">
    <asp:GridView ID="DataGrid1" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size12" 
                EnableModelValidation="True"
                 AllowPaging="true" PagerSettings-Visible="false" 
        onrowdatabound="DataGrid1_RowDataBound" Font-Size="11px">
        <Columns>
            <asp:BoundField DataField="ia_iano"  HeaderText="發票開立單編號" />
            <asp:BoundField DataField="ia_mfrno"  HeaderText="廠商統編" />
            <asp:BoundField DataField="mfr_inm"  HeaderText="廠商名稱" />
            <asp:BoundField DataField="ia_rnm"  HeaderText="發票收件人" />
            <asp:BoundField DataField="ia_rjbti"  HeaderText="稱謂" />
            <asp:BoundField DataField="ia_raddr"  HeaderText="發票郵寄地址" />
            <asp:BoundField DataField="ia_rzip"  HeaderText="郵遞區號" />
            <asp:BoundField DataField="ia_rtel"  HeaderText="電話" />
            <asp:BoundField DataField="ia_invcd"  HeaderText="發票類別" />
            <asp:BoundField DataField="ia_taxtp"  HeaderText="課稅別" />
            <asp:BoundField DataField="iad_iaditem"  HeaderText="發票開立單明細序號" />
            <asp:BoundField DataField="iad_fk1"  HeaderText="合約編號" />
            <asp:BoundField DataField="iad_fk2"  HeaderText="刊登年月" />
            <asp:BoundField DataField="iad_fk3"  HeaderText="落版序號" />
            <asp:BoundField DataField="iad_desc"  HeaderText="品名" />
            <asp:BoundField DataField="iad_projno"  HeaderText="計劃代號" />
            <asp:BoundField DataField="iad_costctr"  HeaderText="成本中心" />
            <asp:BoundField DataField="iad_qty"  HeaderText="數量" />
            <asp:BoundField DataField="iad_amt"  HeaderText="金額" />
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
