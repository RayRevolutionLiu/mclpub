<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search_label.aspx.cs" Inherits="mclpub.LabelArea.search_label"  MasterPageFile="~/MasterPage.Master" EnableEventValidation="false"%>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;標籤管理 / 雜誌叢書標籤處理 / 大宗標籤</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">郵寄地區：</td>
    <td>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <span class="stripeMe">
                <asp:DropDownList ID="ddlMosea" runat="server" AutoPostBack="true" 
                    onselectedindexchanged="ddlMosea_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">國內</asp:ListItem>
                    <asp:ListItem Value="1">國外</asp:ListItem>
                </asp:DropDownList>
                </span>
            </ContentTemplate>
        </asp:UpdatePanel>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">
<span class="stripeMe">
        郵寄類別：</span></td>
    <td>
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
            <ContentTemplate>
                <span class="stripeMe">
                <asp:DropDownList ID="ddlMailType" runat="server" AutoPostBack="true">
                </asp:DropDownList>
                </span>
            </ContentTemplate>
        </asp:UpdatePanel>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">訂購<span class="stripeMe">類別：</span></td>
    <td>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <span class="stripeMe">
                <asp:DropDownList ID="ddlOrderType1" runat="server" AutoPostBack="true"
                    onselectedindexchanged="ddlOrderType1_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="01">訂閱</asp:ListItem>
                    <asp:ListItem Value="02">贈閱</asp:ListItem>
                    <asp:ListItem Value="03">推廣</asp:ListItem>
                    <asp:ListItem Value="09">零售</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlOrderType2" runat="server" AutoPostBack="true">
                </asp:DropDownList>
                </span>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlOrderType1" 
            EventName="SelectedIndexChanged" />
        </Triggers>

        </asp:UpdatePanel>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">書籍類別<span class="stripeMe">：</span></td>
    <td>
        <asp:DropDownList ID="ddlBookType" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">郵寄份數<span class="stripeMe">：</span></td>
    <td>
        <asp:DropDownList ID="ddlMnt" runat="server">
            <asp:ListItem Value="1">單本</asp:ListItem>
            <asp:ListItem Value="2">2本</asp:ListItem>
            <asp:ListItem Value="3">3本</asp:ListItem>
            <asp:ListItem Value="4">4本</asp:ListItem>
            <asp:ListItem Value="5">5本</asp:ListItem>
            <asp:ListItem Value="0">5本以上</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">
<span class="stripeMe">
        郵寄年月：</span></td>
    <td>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <span class="stripeMe">
                <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="true" 
                    onselectedindexchanged="ddlYear_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="true" 
                    onselectedindexchanged="ddlMonth_SelectedIndexChanged">
                    <asp:ListItem Value="01">1</asp:ListItem>
                    <asp:ListItem Value="02">2</asp:ListItem>
                    <asp:ListItem Value="03">3</asp:ListItem>
                    <asp:ListItem Value="04">4</asp:ListItem>
                    <asp:ListItem Value="05">5</asp:ListItem>
                    <asp:ListItem Value="06">6</asp:ListItem>
                    <asp:ListItem Value="07">7</asp:ListItem>
                    <asp:ListItem Value="08">8</asp:ListItem>
                    <asp:ListItem Value="09">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="11">11</asp:ListItem>
                    <asp:ListItem Value="12">12</asp:ListItem>
                </asp:DropDownList>
                </span>
            </ContentTemplate>
        </asp:UpdatePanel>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">郵寄期數：</td>
    <td>
        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="tbxBookNo" runat="server" Width="75px"></asp:TextBox>
            </ContentTemplate>
        </asp:UpdatePanel>
        </td>
  </tr>
  </table>
</span> 
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="CheckBtn" runat="server" Text="查詢" onclick="CheckBtn_Click"/>
        <asp:Button ID="btnPrintLabel" runat="server" Text="列印標籤" 
            onclick="btnPrintLabel_Click" />
        <asp:Button ID="btnPrintList" runat="server" Text="列印郵寄清單" 
            onclick="btnPrintList_Click" />
        <asp:Button ID="Back" runat="server" Text="回首頁" onclick="Back_Click" />
    </td>
  </tr>
</table>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
        <asp:Label ID="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
    </td>
</tr>
</table>
<span class="stripeMe">
    <asp:GridView ID="GVSearchLabel" runat="server" Width="100%" 
        AutoGenerateColumns="False" PagerSettings-Visible="false" 
        CssClass="font_blacklink font_size13">
    <Columns>
    <asp:BoundField DataField="nostr" HeaderText="訂單編號" />
    <asp:BoundField DataField="datestr" HeaderText="訂閱起迄" />
    <asp:BoundField DataField="ra_mnt" HeaderText="份數" />
    <asp:BoundField DataField="mtp_nm" HeaderText="郵寄類別" />
    <asp:BoundField DataField="obtp_obtpnm" HeaderText="書籍類別" />
    </Columns>
<PagerSettings Visible="False"></PagerSettings>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>
</span>
</asp:Content>

