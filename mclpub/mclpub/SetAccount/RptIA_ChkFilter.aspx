<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RptIA_ChkFilter.aspx.cs" Inherits="mclpub.SetAccount.RptIA_ChkFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 網路廣告發票處理 / 大批月結之發票開立單檢核表：查詢條件</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>
    <td align="right" width="220" class="font_bold">
        發票開立單產生年月：</td>
    <td align="left">
        <asp:TextBox ID="tbxYYYYMM" runat="server" Width="80px" MaxLength="7"></asp:TextBox>
        <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Font-Size="Small"
                Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="tbxYYYYMM"></asp:requiredfieldvalidator>
        <asp:RegularExpressionValidator ID="revPubDate" runat="server" 
            ControlToValidate="tbxYYYYMM" ErrorMessage="刊登年月 請依格式填入" 
            Font-Size="Small" ValidationExpression="\d{4}/\d{2}" Display="Dynamic"></asp:RegularExpressionValidator>
      </td>
  </tr>
  <tr>
    <td align="right" width="220" class="font_bold">
        排序條件： </td>
    <td align="left">
        <asp:DropDownList ID="ddlSort" runat="server">
            <asp:ListItem Value="1">發票開立單編號</asp:ListItem>
            <asp:ListItem Value="2">業務員+合約編號+落版序號</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  </table>
</span>
 <table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left">
            <asp:label id="lblMessage" runat="server" Font-Size="Small" ForeColor="Red"></asp:label>   
            <INPUT id="hiddenSeq" type="hidden" name="hiddenSeq" runat="server">
        </td>
    <td align="right">
        <asp:Button ID="btnSearch" runat="server" Text="查詢" onclick="btnSearch_Click" />
    </td>
  </tr>
</table>
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />查詢結果
            </td>
            <td align="right">
<span class="stripeMe">
<asp:Button id="btnPrint" runat="server" Text="列印發票開立單檢核表" onclick="btnPrint_Click"></asp:Button>

</span>
            </td>        
        </tr>
</table>
<span class="stripeMe">
<asp:GridView ID="DataGrid1" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size13" 
                EnableModelValidation="True" AllowSorting="true" OnSorting="gv_data_Sorting">
        <Columns>
            <asp:BoundField DataField="iab_iabdate"  HeaderText="產生年月" />
            <asp:BoundField DataField="iab_iabseq"     HeaderText="產生批次▲" SortExpression="iab_iabseq" HeaderStyle-ForeColor="White"/>
            <asp:BoundField DataField="iab_createdate"      HeaderText="批次產生日期"/>
            <asp:BoundField DataField="srspn_cname"      HeaderText="批次產生人員姓名" />
            <asp:TemplateField HeaderStyle-Width="5%">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" Text="選取"  OnClick="Button1_Click"/>
                </ItemTemplate> 
            </asp:TemplateField>
        </Columns>  
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
        <PagerSettings Visible="False">
        </PagerSettings>
</asp:GridView>

<asp:panel id="pnlIA" Runat="server" Visible="False">

<asp:GridView ID="GridView1" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size13" 
                EnableModelValidation="True" 
        onrowdatabound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="ia_iano"  HeaderText="發票開立單編號" />
            <asp:BoundField DataField="ia_contno"     HeaderText="合約編號"/>
            <asp:BoundField DataField="ia_mfrno"      HeaderText="發票廠商統編"/>
            <asp:BoundField DataField="mfr_inm"      HeaderText="發票廠商名稱"/>
            <asp:BoundField DataField="ia_rnm"      HeaderText="發票收件人"/>
            <asp:BoundField DataField="ia_pyat"      HeaderText="發票金額"/>
            <asp:BoundField DataField="ia_invcd"      HeaderText="發票類別"/>
            <asp:BoundField DataField="ia_taxtp"      HeaderText="課稅別"/>
            <asp:BoundField DataField="ia_fgitri"      HeaderText="往來註記"/>
            <asp:BoundField DataField="ia_cname"      HeaderText="承辦人員"/>
        </Columns>  
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
        <PagerSettings Visible="False">
        </PagerSettings>
</asp:GridView>
</asp:panel>
</span>
</asp:Content>
