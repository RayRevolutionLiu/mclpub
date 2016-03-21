<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IA1RecoveryQuery.aspx.cs" Inherits="mclpub.SetAccount.IA1RecoveryQuery" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 網路廣告發票處理 / 一廠商之發票開立單回復(Recovery)</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>
    <td align="right" width="220" class="font_bold">
        發票廠商名稱：</td>
    <td align="left">
        <asp:TextBox ID="tbxMfrNm" runat="server" Width="150px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" width="220" class="font_bold">
        統一編號： </td>
    <td align="left">
        <asp:TextBox ID="tbxMfrNo" runat="server" Width="80px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" width="220" class="font_bold">
        發票收件人：</td>
    <td align="left">
        <asp:TextBox ID="tbxRecNm" runat="server" Width="100px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" width="220" class="font_bold">
        發票開立單編號：</td>
    <td align="left">
        <asp:TextBox ID="tbxIano" runat="server" Width="100px"></asp:TextBox>
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
    <li>請輸入任一關鍵詞來查詢，然後按下<span class="font_darkblue">查詢</span></li>
    <li>查出資料後，選擇所需的發票開立單按下<span class="font_darkblue">確定</span>可進行發票開立單回復</li>
    <li>大批產生之發票開立單不會在此出現</li>
</ol>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
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
        onrowdatabound="DataGrid1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="ia_iano"  HeaderText="發票開立單編號" />
            <asp:BoundField DataField="ia_contno"     HeaderText="合約編號" />
            <asp:BoundField DataField="ia_mfrno"      HeaderText="發票廠商統編" />
            <asp:BoundField DataField="mfr_inm"      HeaderText="發票廠商名稱" />
            <asp:BoundField DataField="ia_rnm"  HeaderText="發票收件人" />
            <asp:BoundField DataField="ia_pyat"     HeaderText="發票金額" />
            <asp:BoundField DataField="ia_invcd"   HeaderText="發票類別" />
            <asp:BoundField DataField="ia_taxtp"      HeaderText="課稅別" />
            <asp:BoundField DataField="ia_fgitri"      HeaderText="往來註記" />
            <asp:BoundField DataField="ia_status"      HeaderText="進行狀態" />
            <asp:TemplateField HeaderStyle-Width="35px">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" Text="確定" OnClick="Button1_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ia_status"      HeaderText="ia_status" />
        </Columns>  
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
        <PagerSettings Visible="False">
        </PagerSettings>
    </asp:GridView>
</span>
<div class="pager font_size13">
 <uc3:ucpager id="UCPager1" runat="server" />  
 </div> 
</asp:Content>
