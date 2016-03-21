<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pub_LabelFilter.aspx.cs" Inherits="mclpub.LabelArea.Pub_LabelFilter" MasterPageFile="~/MasterPage.Master" %>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;標籤管理 / 網路廣告標籤處理 / 大宗標籤(當月刊登)</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">書籍類別：</td>
    <td>
        <asp:DropDownList ID="ddlBookCode" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">刊登年月：</td>
    <td>
        <asp:TextBox ID="tbxPubDate" runat="server" Width="60px"></asp:TextBox>
        <font color="maroon" size="2">(如 
				2002/08, 預設值: 當月)</font>
        <asp:RegularExpressionValidator ID="revPubDate" runat="server" 
            ControlToValidate="tbxPubDate" ErrorMessage="刊登年月 請依格式填入" 
            Font-Size="Small" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator>
        <br />
        <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Font-Size="Small"
                Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="tbxPubDate"></asp:requiredfieldvalidator>

      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">合約承辦業務員：</td>
    <td>
        <asp:DropDownList ID="ddlEmpNo" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">合約類別：</td>
    <td>
        <asp:DropDownList ID="ddlConttp" runat="server">
            <asp:ListItem Selected="True" Value="01">一般</asp:ListItem>
            <asp:ListItem Value="09">推廣</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">郵寄地區：</td>
    <td>
        <asp:DropDownList ID="ddlfgMOSea" runat="server">
            <asp:ListItem Selected="True" Value="0">國內</asp:ListItem>
            <asp:ListItem Value="1">國外</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">郵寄類別：</td>
    <td>
        <asp:DropDownList ID="ddlMtpcd" runat="server">
        </asp:DropDownList>
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
        <asp:Button ID="btnPrintList" runat="server" Text="列印清單" 
            onclick="btnPrintList_Click" />
        <asp:Button ID="Back" runat="server" Text="回首頁" onclick="Back_Click" />
        <input id="hiddenBookNm" type="hidden" name="hiddenBookNm" runat="server">
        <input id="hiddenBookPno" type="hidden" name="hiddenBookPno" runat="server">
        <asp:TextBox id="tbxBookPNo" runat="server" Font-Size="X-Small" Width="60px" Visible="False"></asp:TextBox>
    </td>
  </tr>
</table>

<span class="font_size13 font_bold font_gray">
<ol>
	<li>查詢結果不包含<span class="font_darkblue">已結案/已註銷</span>之合約</li>
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
    <asp:GridView ID="dgdLabel" runat="server" Width="100%" 
        AutoGenerateColumns="False" PagerSettings-Visible="false" 
        CssClass="font_blacklink font_size13" EnableModelValidation="True" >
    <Columns>
    <asp:BoundField DataField="cont_contno" HeaderText="合約編號" />
    <asp:BoundField DataField="cont_sdate" HeaderText="合約起日" >
        <HeaderStyle Width="8%" />
        </asp:BoundField>
    <asp:BoundField DataField="cont_edate" HeaderText="合約迄日" >
        <HeaderStyle Width="8%" />
        </asp:BoundField>
    <asp:BoundField DataField="ma_sdate" HeaderText="贈閱起月" />
    <asp:BoundField DataField="ma_edate" HeaderText="贈閱迄月" />
    <asp:BoundField DataField="or_inm" HeaderText="公司名稱" />
    <asp:BoundField DataField="or_oritem" HeaderText="序號" />
    <asp:BoundField DataField="or_nm" HeaderText="收件人姓名" />
    <asp:BoundField DataField="or_jbti" HeaderText="稱謂" />
    <asp:BoundField DataField="or_zip" HeaderText="郵寄區號" />
    <asp:BoundField DataField="or_addr" HeaderText="郵寄地址" />
    <asp:BoundField DataField="ma_mnt" HeaderText="有登本數" />
    <asp:BoundField DataField="mtp_nm" HeaderText="郵寄類別" />
    </Columns>
<PagerSettings Visible="False"></PagerSettings>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>
</span>
 </asp:Content>
