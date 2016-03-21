<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PubFm_label_search3Print.aspx.cs" Inherits="mclpub.LabelArea.PubFm_label_search3Print" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;標籤管理 / 平面廣告標籤處理 / 合約外標籤列印</span>
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

    <td align="right" width="170" class="font_bold">郵寄地區：</td>
    <td>
        <asp:DropDownList ID="ddlfgMOSea" runat="server">
            <asp:ListItem Selected="True" Value="0">國內</asp:ListItem>
            <asp:ListItem Value="1">國外</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">列印年月：</td>
    <td>
        <asp:TextBox ID="tbxPubDate" runat="server" Width="60px" MaxLength="7"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revPubDate" runat="server" 
            ControlToValidate="tbxPubDate" ErrorMessage="刊登年月 請依格式填入" 
            Font-Size="Small" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator>
        <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Font-Size="Small"
                Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="tbxPubDate"></asp:requiredfieldvalidator>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">勾選者業務人員工號：</td>
    <td>
        <asp:TextBox ID="tbxempno" runat="server" MaxLength="7"></asp:TextBox>
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
    </td>
  </tr>
</table>

<span class="font_size13 font_bold font_gray">
<ol>
	<li>查詢結果為所有業務員<span class="font_darkblue"><span class="font_size13 font_bold font_gray">勾選之</span>合約期間外標籤</span></li>
    <li><span class="font_darkblue">查詢年月</span>欄位可查詢該輸入之年月總共被勾選多少筆要列印</li>
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
    <asp:GridView ID="GVSearchLabel" runat="server" Width="100%" 
        AutoGenerateColumns="False" PagerSettings-Visible="false" 
        CssClass="font_blacklink font_size13" EnableModelValidation="True" 
        onrowdatabound="GVSearchLabel_RowDataBound">
    <Columns>
    <asp:BoundField DataField="cont_contno" HeaderText="合約編號" />
    <asp:BoundField DataField="cont_sdate" HeaderText="合約起日" >
        <HeaderStyle Width="8%" />
        </asp:BoundField>
    <asp:BoundField DataField="cont_edate" HeaderText="合約迄日" >
        <HeaderStyle Width="8%" />
        </asp:BoundField>
    <asp:BoundField DataField="or_inm" HeaderText="公司名稱" />
    <asp:BoundField DataField="or_oritem" HeaderText="序號" />
    <asp:BoundField DataField="or_nm" HeaderText="收件人姓名" />
    <asp:BoundField DataField="or_jbti" HeaderText="稱謂" />
    <asp:BoundField DataField="or_zip" HeaderText="郵寄區號" />
    <asp:BoundField DataField="or_addr" HeaderText="郵寄地址" />
    <asp:BoundField DataField="or_pubcnt" HeaderText="有登本數" />
    <asp:BoundField DataField="or_unpubcnt" HeaderText="未登本數" />
    <asp:BoundField DataField="mtp_nm" HeaderText="郵寄類別" >
        <HeaderStyle Width="10%" />
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
