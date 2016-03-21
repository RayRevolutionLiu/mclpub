<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckList.aspx.cs" Inherits="mclpub.Order.CheckList"  MasterPageFile="~/MasterPage.Master"%>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;訂單管理 / 雜誌叢書訂單處理 / 訂單檢核表</span> 
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">訂單登錄日期區間：</td>
    <td>
        <asp:TextBox ID="tbxDate1" runat="server" Width="82px" CssClass="UniqueDate"></asp:TextBox>
        ~<asp:TextBox ID="tbxDate2" runat="server" Width="84px" CssClass="UniqueDate"></asp:TextBox>
      </td>
  </tr>
  </table>
</span> 
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="CheckBtn" runat="server" Text="查詢" onclick="CheckBtn_Click"/>
        <asp:Button ID="Back" runat="server" Text="回首頁" onclick="Back_Click" />
    </td>
  </tr>
</table>
<span class="font_size13 font_bold font_gray">
<ol>
	<li>此檢核表列示之訂單是尚未產生發票開立單之資料,已產生發票開立單之訂單資料不會在此列示</li>
	<li>發票類別--<span class="font_darkblue">2:二聯  3:三聯  4:其他</span><br />課稅別---<span class="font_darkblue">1:應稅  2:零稅  3:免稅</span><br />新續訂戶---<span class="font_darkblue">0:新訂戶  1:續訂戶</span></li>
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
    <asp:GridView ID="GVSearchCust" runat="server" Width="99%" 
        AutoGenerateColumns="False" AllowPaging="True" PagerSettings-Visible="false" 
        CssClass="font_blacklink font_size13">
    <Columns>
    <asp:BoundField DataField="nostr" HeaderText="訂單編號">
        <HeaderStyle Width="2%"/>
        </asp:BoundField>
    <asp:BoundField DataField="o_mfrno" HeaderText="統一編號">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="o_inm" HeaderText="發票收件人">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="o_ijbti" HeaderText="稱謂">
        <HeaderStyle Width="2%" />
        </asp:BoundField>
    <asp:BoundField DataField="o_iaddr" HeaderText="發票郵寄地址">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="o_izip" HeaderText="郵遞區號">
        <HeaderStyle Width="2%" />
        </asp:BoundField>
    <asp:BoundField DataField="o_itel" HeaderText="電話">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="o_ifax" HeaderText="傳真">
        <HeaderStyle Width="2%" />
        </asp:BoundField>
    <asp:BoundField DataField="o_icell" HeaderText="手機">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="o_iemail" HeaderText="Email">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="o_date" HeaderText="訂購日期">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="o_empno" HeaderText="承辦人員">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="o_invcd" HeaderText="發票類別">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="o_taxtp" HeaderText="課稅別">
        <HeaderStyle Width="3%" />
        </asp:BoundField> 
    <asp:BoundField DataField="od_oditem" HeaderText="明細項次">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="od_sdate" HeaderText="訂閱起時">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="od_edate" HeaderText="訂閱迄時">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="obtp_obtpnm" HeaderText="書籍名稱">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="od_projno" HeaderText="計劃代號">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="od_remark" HeaderText="備註">
        <HeaderStyle Width="3%" />
        </asp:BoundField> 
    <asp:BoundField DataField="od_amt" HeaderText="金額">
        <HeaderStyle Width="2%" />
        </asp:BoundField>
    <asp:BoundField DataField="od_custtp" HeaderText="新續訂戶">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="ra_mnt" HeaderText="數量">
        <HeaderStyle Width="2%" />
        </asp:BoundField>
    <asp:BoundField DataField="mtp_nm" HeaderText="郵寄類別">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="ra_oritem" HeaderText="序號">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="or_inm" HeaderText="公司名稱">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="or_nm" HeaderText="雜誌收件人">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="or_jbti" HeaderText="稱謂">
        <HeaderStyle Width="2%" />
        </asp:BoundField>
    <asp:BoundField DataField="or_addr" HeaderText="雜誌郵寄地址">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="or_zip" HeaderText="郵遞區號">
        <HeaderStyle Width="2%" />
        </asp:BoundField>
    <asp:BoundField DataField="or_tel" HeaderText="電話">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="or_fax" HeaderText="傳真">
        <HeaderStyle Width="2%" />
        </asp:BoundField>
    <asp:BoundField DataField="or_cell" HeaderText="手機">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    <asp:BoundField DataField="or_email" HeaderText="Email">
        <HeaderStyle Width="3%" />
        </asp:BoundField>
    </Columns>
<PagerSettings Visible="False"></PagerSettings>

    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>
</span>
</asp:Content>
