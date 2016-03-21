<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contfm_chk.aspx.cs" Inherits="mclpub.Contract.contfm_chk"  MasterPageFile="~/MasterPage.Master" MaintainScrollPositionOnPostback="true"%>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;合約管理 / 平面廣告合約書 / 合約書錯誤資料清單</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>
    <td align="right" width="30%" class="font_bold">
        <asp:Label ID="lblSignDate" runat="server">請選擇您要查詢的項目：</asp:Label>
      </td>
    <td>
        <asp:DropDownList ID="ddlFilter" runat="server">
            <asp:ListItem Value="1">彩套黑次數皆為０</asp:ListItem>
            <asp:ListItem Value="2">承辦業務員資料不對應</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" colspan="2">
        <asp:Button ID="btnQuery" runat="server" Text="查詢" onclick="btnQuery_Click" />
        <asp:Button id="btnClearAll" runat="server" Text="清除重查" 
            onclick="btnClearAll_Click"></asp:Button>
        </td>
  </tr>
</table>
</span>

<span class="font_size13 font_bold font_gray">
<ol>
	<li>請選擇查詢的項目然後按下查詢</li>
    <li>查詢資料結果中,按下<span class="font_darkblue">「確定修改」</span>可修改該合約的資料</li>
    <li>查出資料後,按下<span class="font_darkblue">「顯示合約歷史」</span>可查看合約歷史紀錄</li>
</ol>
</span>
<br />
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right"></td>
</tr>
</table>

<span class="stripeMe">
    <asp:GridView ID="GridView1" runat="server" Width="99%" AutoGenerateColumns="false" OnRowDataBound="GridView1OnRowDataBound" CssClass="font_blacklink font_size13" AllowPaging="true" PagerSettings-Visible="false"
     AllowSorting="true" OnSorting="GVEdit_Sorting">
    <Columns>
    <asp:BoundField DataField="cont_contno" HeaderText="合約編號" />
    <asp:BoundField DataField="cont_conttp" HeaderText="合約類別" />
    <asp:BoundField DataField="bk_nm" HeaderText="書籍類別" />
    <asp:BoundField DataField="cont_sdate" HeaderText="合約起日" />
    <asp:BoundField DataField="cont_edate" HeaderText="合約迄日" />
    <asp:BoundField DataField="cont_signdate" HeaderText="簽約日期" SortExpression="cont_signdate" />
    <asp:BoundField DataField="mfr_inm" HeaderText="公司名稱" />
    <asp:BoundField DataField="cont_aunm" HeaderText="廣告聯絡人姓名" />
    <asp:BoundField DataField="cont_autel" HeaderText="廣告聯絡人電話" />
    <asp:BoundField DataField="cont_fgpayonce" HeaderText="一次付清" />
    <asp:BoundField DataField="cont_fgclosed" HeaderText="已結案" />
    <asp:BoundField DataField="cont_disc" HeaderText="優惠折數" />
    <asp:BoundField DataField="cont_clrtm" HeaderText="彩色次數" />
    <asp:BoundField DataField="cont_getclrtm" HeaderText="套色次數" />
    <asp:BoundField DataField="cont_menotm" HeaderText="黑白次數" />
    <asp:BoundField DataField="cont_fgpubed" HeaderText="已落版" />
    <asp:BoundField DataField="cont_fgcancel" HeaderText="已註銷" />
    <asp:BoundField DataField="srspn_cname" HeaderText="業務員" />
    <asp:TemplateField HeaderStyle-Width="5%">
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server">顯示合約歷史</asp:HyperLink>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderStyle-Width="5%">
    <ItemTemplate>
        <asp:Button ID="Button2" runat="server" Text="修改" />
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="cont_custno" HeaderText="客戶編號" />
    </Columns>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>
</span>
<div class="pager font_size13">
 <uc3:ucpager id="UCPager1" runat="server" />  
 </div> 
</asp:Content>
