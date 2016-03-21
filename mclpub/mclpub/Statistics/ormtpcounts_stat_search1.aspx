<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ormtpcounts_stat_search1.aspx.cs" Inherits="mclpub.Statistics.ormtpcounts_stat_search1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;統計管理 / 印製份數統計表 / 當月刊登</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
    <tr>

    <td align="right" width="220" class="font_bold">書籍類別：</td>
    <td>
        <asp:DropDownList ID="ddlBookCode" runat="server">
        </asp:DropDownList>
      </td>
 </tr>
  <tr>

    <td align="right" width="220" class="font_bold">統計月份：</td>
    <td>
        <asp:TextBox ID="tbxPubDate" runat="server" Width="60px"></asp:TextBox>
        <font color="maroon" size="2">(如2002/08, 預設值: 當月)</font>
        <asp:RegularExpressionValidator ID="revPubDate" runat="server" 
            ControlToValidate="tbxPubDate" ErrorMessage="刊登年月 請依格式填入" 
            Font-Size="Small" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator>
        <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Font-Size="Small"
                Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="tbxPubDate"></asp:requiredfieldvalidator>
      </td>
  </tr>
    <tr>
        <td align="right" width="220" class="font_bold">
            合約類別：
        </td>
        <td>
            <asp:DropDownList ID="ddlConttp" runat="server">
                <asp:ListItem Value="00" Selected="True">請選擇</asp:ListItem>
                <asp:ListItem Value="01">一般</asp:ListItem>
                <asp:ListItem Value="09">推廣</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" width="220" class="font_bold">
            郵寄地區：
        </td>
        <td>
            <asp:DropDownList ID="ddlfgMOSea" runat="server">
                <asp:ListItem Value="" Selected="True">請選擇</asp:ListItem>
                <asp:ListItem Value="0">國內</asp:ListItem>
                <asp:ListItem Value="1">國外</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right" width="220" class="font_bold">
            郵寄方式：
        </td>
        <td>
            <asp:DropDownList ID="ddlMailType" runat="server">
                <asp:ListItem Selected="True" Value="0">大宗郵寄</asp:ListItem>
                <asp:ListItem Value="1">收發室經辦</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
  </table>
</span>
    <table border="0" width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <td align="left">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="CheckBtn" runat="server" Text="查詢" class="btn_mouseout" onmouseover="this.className='btn_mouseover'"
                    onmouseout="this.className='btn_mouseout'" OnClick="CheckBtn_Click" />
            </td>
        </tr>
    </table>
    <table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
            </td>
            <td align="right">
                <asp:Panel ID="Panel1" runat="server">
                    <input id="btnPrint" onclick="Javascript:window.print();" type="button" value="列印本頁"
                        name="btnPrint" class="btn_mouseout" onmouseover="this.className='btn_mouseover'"onmouseout="this.className='btn_mouseout'">&nbsp;
                    <asp:Button ID="btnPrintList" runat="server" Text="列印清單" 
                        onclick="btnPrintList_Click"></asp:Button>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <span class="stripeMe">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="font_blacklink font_size13"
            Width="100%" onrowdatabound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="cont_conttpName" HeaderText="合約類別" />
                <asp:BoundField DataField="bk_nm" HeaderText="書籍名稱" />
                <asp:BoundField DataField="mtp_nm" HeaderText="郵寄類別名稱" />
                <asp:BoundField DataField="or_pubcnt" HeaderText="有登本數" />
                <asp:BoundField DataField="PubCounts" HeaderText="份數" />
                <asp:BoundField DataField="SumCounts" HeaderText="小計本數" />
                <asp:BoundField DataField="or_mtpcd" HeaderText="小計本數" />
            </Columns>
            <EmptyDataRowStyle HorizontalAlign="Center" />
            <EmptyDataTemplate>
                查詢無結果
            </EmptyDataTemplate>
        </asp:GridView>
    </span>
</asp:Content>
