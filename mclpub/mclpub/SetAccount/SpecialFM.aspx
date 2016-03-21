<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SpecialFM.aspx.cs" Inherits="mclpub.SetAccount.SpecialFM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 雜誌叢書發票處理 / 已繳款之發票退回處理</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">

  <tr>
    <th colspan="2">發票資料</th>
  </tr>

  <tr>

    <td align="right" width="170" class="font_bold">請輸入發票號碼:</td>

    <td>
        <asp:TextBox ID="tbxIano" runat="server" MaxLength="10" 
            Width="93px"></asp:TextBox>
			<input id="hiddenIano" type="hidden" runat="server" NAME="hiddenIano">
            <input id="hiddenid" type="hidden" runat="server" NAME="hiddenid">
			<input id="hiddentype1" type="hidden" runat="server" NAME="hiddentype1"> 
            <input id="hiddenseq" type="hidden" runat="server" NAME="hiddenseq">
    </td>
  </tr>
</table>
</span>
 <table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">

        <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" Text="查詢" />

    </td>
  </tr>
</table>
<span class="font_size13 font_bold font_gray">
<ol>
    <li><span class="font_darkblue">發票類別</span>---2:二聯 3:三聯 4:其他
<span class="font_darkblue">課稅別</span>---1:應稅 2:零稅 3:免稅</li>
</ol>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
    <tr>
    	<td class="font_size18 font_bold">
            <img alt="搜尋" src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
        </td>
        
        <td align="right">
            &nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="訂單中作註記並進入修改訂單畫面" Visible="False" 
                onclick="btnDelete_Click" />
        </td>
    </tr>
</table>

<span class="stripeMe">

    <asp:GridView ID="DataGrid1" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size13" 
                EnableModelValidation="True">
    
        <Columns>
            <asp:BoundField DataField="ia_iano"       HeaderText="發票開立單編號" />
            <asp:BoundField DataField="ia_invno"     HeaderText="發票號碼" />
            <asp:BoundField DataField="ia_invdate"      HeaderText="發票日期" />
            <asp:BoundField DataField="ia_pyat"      HeaderText="金額" />
            <asp:BoundField DataField="ia_mfrno"  HeaderText="統一編號" />
            <asp:BoundField DataField="ia_rnm"     HeaderText="發票收件人姓名" />
            <asp:BoundField DataField="ia_raddr"   HeaderText="地址" />
            <asp:BoundField DataField="ia_invcd"      HeaderText="發票類別" />
            <asp:BoundField DataField="ia_taxtp"      HeaderText="課稅別" />
            <asp:BoundField DataField="nostr"      HeaderText="訂單編號" />
            <asp:BoundField DataField="o_date"      HeaderText="訂購日期" />
            <asp:BoundField DataField="datestr"      HeaderText="訂閱起迄" />
            <asp:BoundField DataField="obtp_obtpnm"      HeaderText="書籍類別" />
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

