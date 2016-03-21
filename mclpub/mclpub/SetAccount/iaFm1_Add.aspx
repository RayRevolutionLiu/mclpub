<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="iaFm1_Add.aspx.cs" Inherits="mclpub.SetAccount.iaFm1_Add" MaintainScrollPositionOnPostback="true" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 平面廣告發票處理 / 發票開立單產生 - 一次付款 - 步驟一: 挑選發票廠商</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">

  <tr>
    <th colspan="2">查詢條件</th>
  </tr>

  <tr>

    <td align="right" width="170" class="font_bold">廠商名稱:</td>

    <td>
        <asp:TextBox ID="tbxMfrIName" runat="server" MaxLength="50" 
            Width="120px"></asp:TextBox>
    </td>
  </tr>

  <tr>

    <td align="right" width="170" class="font_bold">發票廠商收件人姓名:</td>

    <td>
        <asp:TextBox ID="tbxIMName" runat="server" MaxLength="30" Width="60px"></asp:TextBox>
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
    <li>請挑選單一的合約書編號及發票廠商收件人, 再按下<span class="font_darkblue">確認挑選</span>按鈕</li>
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
        onrowdatabound="DataGrid1_RowDataBound" Font-Size="11px">
        <Columns>
            <asp:TemplateField HeaderStyle-Width="35px">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">確認挑選</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="cont_contno"  HeaderText="合約編號" />
            <asp:BoundField DataField="im_imseq"     HeaderText="發廠序號" />
            <asp:BoundField DataField="im_nm"      HeaderText="發廠收件人" />
            <asp:BoundField DataField="mfr_inm"      HeaderText="廠商名稱" />
            <asp:BoundField DataField="bk_nm"  HeaderText="書籍類別" />
            <asp:BoundField DataField="cont_conttp"     HeaderText="合約類別" />
            <asp:BoundField DataField="cont_signdate"   HeaderText="簽約日期" />
            <asp:BoundField DataField="cont_sdate"      HeaderText="合約起日" />
            <asp:BoundField DataField="cont_edate"      HeaderText="合約迄日" />
            <asp:BoundField DataField="cont_custno"      HeaderText="客戶編號" />
            <asp:BoundField DataField="cust_nm"      HeaderText="客戶名稱" />
            <asp:BoundField DataField="cont_totjtm"      HeaderText="總製稿" />
            <asp:BoundField DataField="cont_tottm"      HeaderText="總刊登" />
            <asp:BoundField DataField="cont_totamt"      HeaderText="總金額" />
            <asp:BoundField DataField="cont_paidamt"      HeaderText="已付金額" />
            <asp:BoundField DataField="cont_restamt"      HeaderText="剩餘金額" />
            <asp:BoundField DataField="cont_fgclosed"      HeaderText="結案" />
            <asp:BoundField DataField="srspn_cname"      HeaderText="承辦業務員" />
            <asp:BoundField DataField="cont_fgclosed"      HeaderText="結案註記" />
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
