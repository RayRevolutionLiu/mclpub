<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pub_new2.aspx.cs" Inherits="mclpub.Layout.pub_new2" MasterPageFile="~/MasterPage.Master" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 平面廣告落版處理 / 新增/維護/顯示 落版 / 由年月落版進入</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">合約編號：</td>
    <td>
        <asp:TextBox ID="tbxContNo" runat="server" AutoPostBack="True" MaxLength="6" 
            tabIndex="5" Width="60px"></asp:TextBox>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">刊登年月<span class="stripeMe">：</span></td>
    <td>
        <asp:TextBox ID="tbxPubDate" runat="server" MaxLength="6" Width="60px"></asp:TextBox>
      </td>
  </tr>
  </table>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="btnOK" runat="server" Text="查詢" onclick="btnOK_Click" />
    </td>
  </tr>
</table>

<span class="font_size13 font_bold font_gray">
<ol>
	<li>請輸入任一關鍵詞然後按下查詢</li>
    <li>查詢資料結果中,不包含<span class="font_darkblue">「已結案/已註銷」</span>的合約資料<br /></li>
    <li>若不知欲修改之合約書編號，至 <a href="../Contract/PlaneCont.aspx" target="_self">合約管理/平面廣告合約書/合約書</a> 來查詢修改</li>

</ol>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    </td>
</tr>
</table>

<span class="stripeMe">
    <asp:GridView ID="GVcont" runat="server" Width="99%" 
        AutoGenerateColumns="false" CssClass="font_blacklink font_size13" 
        AllowPaging="true" PagerSettings-Visible="false" 
        onrowdatabound="GVcont_RowDataBound">
    <Columns>
    <asp:BoundField DataField="cont_contno" HeaderText="合約編號" />
    <asp:BoundField DataField="bk_nm" HeaderText="書籍類別" />
    <asp:BoundField DataField="cont_bkcd" HeaderText="書籍類別代碼" />
    <asp:BoundField DataField="cont_mfrno" HeaderText="廠商統編" />
    <asp:BoundField DataField="mfr_inm" HeaderText="公司名稱" />
    <asp:BoundField DataField="cont_custno" HeaderText="客戶編號" />
    <asp:BoundField DataField="cust_nm" HeaderText="客戶姓名" />
    <asp:BoundField DataField="cust_tel" HeaderText="聯絡電話" />
    <asp:BoundField DataField="cont_fgpubed" HeaderText="已落版" />
    <asp:BoundField DataField="cont_fgpubed" HeaderText="已落版" />
    <asp:BoundField DataField="cust_tel" HeaderText="聯絡電話" />
    <asp:TemplateField HeaderStyle-Width="5%">
    <ItemTemplate>
      <asp:Button ID="btnRedirect" runat="server" Text="落版" OnClick="btnRedirect_Click" />
    </ItemTemplate>
    </asp:TemplateField>   
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
