<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IncomeFilter.aspx.cs" Inherits="mclpub.Statistics.IncomeFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;統計管理 / 收入統計表</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="220" class="font_bold">統計日期(訂購日期)區間：</td>
    <td>
        <asp:TextBox ID="tbxOrderDate1" runat="server" CssClass="UniqueDate" MaxLength="10"></asp:TextBox>～
       
        <asp:TextBox ID="tbxOrderDate2" runat="server" CssClass="UniqueDate" MaxLength="10"></asp:TextBox>
      </td>
  </tr>
  <tr>

    <td align="right" width="220" class="font_bold">訂閱類別：</td>
    <td>
        <asp:DropDownList ID="ddlOrderType1" runat="server" AutoPostBack="true" 
            onselectedindexchanged="ddlOrderType1_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="01">訂閱</asp:ListItem>
            <asp:ListItem Value="02">贈閱</asp:ListItem>
            <asp:ListItem Value="03">推廣</asp:ListItem>
            <asp:ListItem Value="09">零售</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>

    <td align="right" width="220" class="font_bold">訂閱書籍類別：</td>
    <td>
        <asp:DropDownList ID="ddlBookType" runat="server" 
            onselectedindexchanged="ddlBookType_SelectedIndexChanged" AutoPostBack="true">
        </asp:DropDownList>
      </td>
 </tr>
  <tr>

    <td align="right" width="220" class="font_bold">計畫代號：</td>
    <td>
        <asp:TextBox ID="tbxProj" runat="server" MaxLength="20" 
            ontextchanged="tbxProj_TextChanged" AutoPostBack="true"></asp:TextBox>
      </td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="CheckBtn" runat="server" Text="查詢"  class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" OnClick="CheckBtn_Click"/>
    </td>
  </tr>
</table>  

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
    <tr>
        <td class="font_size18 font_bold">
            <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
        </td>
        <td align="right">
            <asp:Button ID="btnPrintList" runat="server" Enabled="False" Text="列印報表" 
                onclick="btnPrintList_Click" />
        </td>
    </tr>
</table>

<span class="stripeMe">
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
    CssClass="font_blacklink font_size13" Width="100%">
    <Columns>
        <asp:BoundField DataField="otp_otp1nm" HeaderText="訂閱類別一" />
        <asp:BoundField DataField="otp_otp2nm" HeaderText="訂閱類別二" />
        <asp:BoundField DataField="obtp_obtpnm" HeaderText="書籍類別" />
        <asp:BoundField DataField="tmp_param2" HeaderText="份數" />
        <asp:BoundField DataField="tmp_param1" HeaderText="金額" />
    </Columns>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
        查詢無結果
    </EmptyDataTemplate>
</asp:GridView>
</span>
</asp:Content>
