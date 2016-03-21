<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CheckList3.aspx.cs" Inherits="mclpub.SetAccount.CheckList3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 雜誌叢書發票處理 / 發票開立單檢核表</span>
<span class="font_size13 font_bold font_gray">
<ol>
	<li>此檢核表列示之發票開立單是尚未產生發票開立清單之資料, 
已產生發票開立清單之發票資料不會在此列示</li>
    <li><span class="font_darkblue">發票類別</span>---2:二聯 3:三聯 4:其他
<span class="font_darkblue">課稅別</span>---1:應稅 2:零稅 3:免稅</li>
</ol>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
        &nbsp;</td>
</tr>
</table>
<span class="stripeMe">
    <asp:GridView ID="PayDelGV" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="font_blacklink font_size12" Font-Size="11px">
    <Columns>
                <asp:BoundField DataField="ia_iano" HeaderText="發票開立單編號" />
                <asp:BoundField DataField="ia_mfrno" HeaderText="統一編號"/>
                <asp:BoundField DataField="ia_rnm" HeaderText="發票收件人"/>
                <asp:BoundField DataField="ia_rjbti" HeaderText="稱謂" />
                <asp:BoundField DataField="ia_raddr" HeaderText="發票郵寄地址" />
                <asp:BoundField DataField="ia_rzip" HeaderText="郵遞區號"/>
                <asp:BoundField DataField="ia_rtel" HeaderText="電話"/>
                <asp:BoundField DataField="ia_invcd" HeaderText="發票類別"/>
                <asp:BoundField DataField="ia_taxtp" HeaderText="課稅別"/>
                <asp:BoundField DataField="iad_iaditem" HeaderText="發票開立單明細序號" />                
                <asp:BoundField DataField="iad_fk1" HeaderText="訂戶編號" />
                <asp:BoundField DataField="iad_fk2" HeaderText="訂購類別" />
                <asp:BoundField DataField="iad_fk3" HeaderText="訂單流水號" />
                <asp:BoundField DataField="iad_fk4" HeaderText="訂單項次" />
                <asp:BoundField DataField="iad_desc" HeaderText="品名" />
                <asp:BoundField DataField="iad_projno" HeaderText="計劃代號" />
                <asp:BoundField DataField="iad_costctr" HeaderText="成本中心" />
                <asp:BoundField DataField="iad_qty" HeaderText="數量" />
                <asp:BoundField DataField="iad_amt" HeaderText="金額" />
    </Columns>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>
</span>
</asp:Content>
