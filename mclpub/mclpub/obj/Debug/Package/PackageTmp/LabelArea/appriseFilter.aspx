<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="appriseFilter.aspx.cs" Inherits="mclpub.LabelArea.appriseFilter" MasterPageFile="~/MasterPage.Master" %>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;訂單管理 / 雜誌叢書標籤處理 / 續訂標籤列印</span> 
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">郵寄地區：</td>
    <td>
        <asp:DropDownList ID="ddlMosea" runat="server">
            <asp:ListItem Value="0">國內</asp:ListItem>
            <asp:ListItem Value="1">國外</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">書籍類別：</td>
    <td>
        <asp:DropDownList ID="ddlBookType" runat="server">
            <asp:ListItem Value="01">工材</asp:ListItem>
            <asp:ListItem Value="02">電材</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">通知類別：</td>
    <td>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <span class="stripeMe">
                <asp:DropDownList ID="ddlType" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlType_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">到期</asp:ListItem>
                    <asp:ListItem Value="1">即將到期</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="Label7" runat="server" ForeColor="Maroon">(註)</asp:Label>
                </span>
            </ContentTemplate>
        </asp:UpdatePanel>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">訂閱迄期區間：</td>
    <td>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <span class="stripeMe">
                <asp:DropDownList ID="ddlYear1" runat="server">
                </asp:DropDownList>
                年<asp:DropDownList ID="ddlMonth1" runat="server">
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
                月~<asp:DropDownList ID="ddlYear2" runat="server">
                </asp:DropDownList>
                年<asp:DropDownList ID="ddlMonth2" runat="server">
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
                月</span>
            </ContentTemplate>
        </asp:UpdatePanel>
      </td>
  </tr>
  </table>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="btnOK" runat="server" Text="查詢" onclick="btnOK_Click" />
        <asp:Button ID="btnPrintLabel" runat="server" Text="列印標籤" 
            onclick="btnPrintLabel_Click" />
        <asp:Button ID="btnPrintList" runat="server" Text="列印郵寄清單" 
            onclick="btnPrintList_Click" />
        <asp:Button ID="ReturnDefault" runat="server" Text="回首頁" 
            onclick="ReturnDefault_Click" />
    </td>
  </tr>
</table>

<span class="font_size13 font_bold font_gray">
<ol>
	<li>如通知類別選擇<span class="font_darkblue">到期</span>時, 迄期區間請輸入本月之前的月份(含本月)</li>
	<li>選擇<span class="font_darkblue">即將到期</span>時, 迄期區間請輸入本月之後的月份(不含本月)</li>
</ol>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
        <asp:Label ID="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
    </td>
</tr>
</table>

<span class="stripeMe">
    <asp:GridView ID="GVSearchCust" runat="server" Width="99%" 
        AutoGenerateColumns="false" PagerSettings-Visible="false" 
        CssClass="font_blacklink font_size13">
    <Columns>
    <asp:BoundField DataField="nostr" HeaderText="訂單編號" />
    <asp:BoundField DataField="datestr" HeaderText="訂閱起訖" />
    <asp:BoundField DataField="ra_mnt" HeaderText="份數" />
    <asp:BoundField DataField="mtp_nm" HeaderText="郵寄類別" />
    <asp:BoundField DataField="obtp_obtpnm" HeaderText="書籍類別" />
    </Columns>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>
</span>
</asp:Content>
