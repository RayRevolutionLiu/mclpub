<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlaneCont_2.aspx.cs" Inherits="mclpub.Contract.PlaneCont_2"  MasterPageFile="~/MasterPage.Master"%>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;合約管理 / 平面廣告合約書 步驟二:挑出該客戶的歷史合約書資料</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td align="right"><asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></td>
    <td align="right">
    <asp:Button ID="AddNewCont" runat="server" Text="新增空白合約書" 
            onclick="AddNewCont_Click"/>
    <asp:Button ID="BackBtn" runat="server" Text="回查詢畫面" onclick="BackBtn_Click" />
    </td>
</tr>
</table>
<span class="font_size13 font_bold font_gray">
<ol>
	<li>已結案的合約，將不允許 "修改"，只能檢視其資料(顯示合約歷史)！</li>
	<li>選擇 [顯示合約歷史] 可檢視合約書的原始資料, 選 [新增/修改] 即可進入[新增/修改]畫面</li>
</ol>
</span>
<span class="stripeMe">
<asp:GridView ID="PCGV2" runat="server" AutoGenerateColumns="false" Width="99%" CssClass="font_blacklink font_size13" OnRowDataBound="PCGV2OnRowDataBound">
<Columns>
    <asp:BoundField DataField="cont_contno" HeaderText="合約編號" />
    <asp:BoundField DataField="cont_conttp" HeaderText="合約類別" />
    <asp:BoundField DataField="bk_nm" HeaderText="書籍類別" />
    <asp:BoundField DataField="cont_signdate" HeaderText="簽約日期" />
    <asp:BoundField DataField="cont_sdate" HeaderText="合約起日" />
    <asp:BoundField DataField="cont_edate" HeaderText="合約迄日" />
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
    <asp:TemplateField HeaderStyle-Width="5%">
    <ItemTemplate>
        <asp:Button ID="Button1" runat="server" Text="新增" />
    </ItemTemplate>
    </asp:TemplateField>  
</Columns>
<EmptyDataRowStyle HorizontalAlign="Center" />
<EmptyDataTemplate>
查詢無結果
</EmptyDataTemplate>
</asp:GridView>
</span>
</asp:Content>


