<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptCustQuery.aspx.cs" Inherits="mclpub.Subscriber.RptCustQuery"  MasterPageFile="~/MasterPage.Master"%>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

    <script>
$(function() {
$("#<% =tbxSDate.ClientID%>").datepicker(
{
    showButtonPanel: true,
    autoSize: true,
    changeYear: true,
    changeMonth: true,
    dateFormat: 'yy/mm/dd',
    dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
    monthNamesShort: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12'],
    nextText: "下一月",
    prevText: "上一月",
    closeText: "關閉",
    currentText: "今天"
});
});

$(function() {
$("#<% =tbxEDate.ClientID%>").datepicker(
{
    showButtonPanel: true,
    autoSize: true,
    changeYear: true,
    changeMonth: true,
    dateFormat: 'yy/mm/dd',
    dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
    monthNamesShort: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12'],
    nextText: "下一月",
    prevText: "上一月",
    closeText: "關閉",
    currentText: "今天"
});
});
</script>
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;訂戶管理 / 網廣合約客戶基本資料清單</span> 
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">客戶基本資料清單</th>
  </tr>
  <tr>

    <td align="right" width="200" class="font_bold">合約類別:</td>
    <td>
        <asp:DropDownList ID="ddlContType" runat="server">
        <asp:ListItem Value="00" Selected="True">請選擇</asp:ListItem>
        <asp:ListItem Value="01">一般</asp:ListItem>
        <asp:ListItem Value="09">推廣</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>

    <td align="right" width="200" class="font_bold">
        <label for="cbxAdDate">
        合約起迄區間</label>:</td>
    <td>
        <asp:TextBox ID="tbxSDate" runat="server"></asp:TextBox>
        ~<span class="stripeMe"><asp:TextBox ID="tbxEDate" runat="server"></asp:TextBox>
</span>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">材料特性:</td>
    <td>
<span class="stripeMe">
        <asp:DropDownList ID="ddlClass1" runat="server">
        </asp:DropDownList>
</span>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">應用產業:</td>
    <td>
        <asp:DropDownList ID="ddlClass2" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">承辦業務員:</td>
    <td>
        <asp:DropDownList ID="ddlEmpData" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">已結案:</td>
    <td>
        <asp:DropDownList ID="ddlClosed" runat="server">
        <asp:ListItem Value="00">請選擇</asp:ListItem>
        <asp:ListItem Value="0">否</asp:ListItem>
        <asp:ListItem Value="1">是</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
</table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <%--<asp:Button ID="Chkbtn" runat="server" Text="查詢" onclick="Chkbtn_Click" />--%>
        <asp:Button ID="CheckBtn1" runat="server" Text="產生合約客戶基本資料清單" onclick="CheckBtn1_Click" />
    </td>
  </tr>
</table>

<%--<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果<span class="font_size12 font_red">(由於資料筆數過大 
        頁面僅展示前300筆內資料 完整資料可匯出報表查詢)</span></td>
    <td align="right">
        &nbsp;</td>
</tr>
</table>


<span class="stripeMe">
<asp:GridView ID="CLFGV" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="font_blacklink font_size13" >
    <Columns>
    <asp:BoundField DataField="nostr" HeaderText="訂單編號" />
    <asp:BoundField DataField="od_custno" HeaderText="訂戶編號" />
    <asp:BoundField DataField="o_date" HeaderText="訂購日期" />
    <asp:BoundField DataField="obtp_obtpnm" HeaderText="書籍類別" />
    <asp:BoundField DataField="datestr" HeaderText="訂閱起迄" />
    <asp:BoundField DataField="or_nm" HeaderText="雜誌收件人" />
    <asp:BoundField DataField="or_inm" HeaderText="公司名稱" />
    <asp:BoundField DataField="or_zip" HeaderText="郵遞區號" />
    <asp:BoundField DataField="or_addr" HeaderText="寄送地址" />
    <asp:BoundField DataField="or_tel" HeaderText="電話" />
    <asp:BoundField DataField="ra_mnt" HeaderText="份數" />
    <asp:BoundField DataField="ra_mtpcd" HeaderText="郵寄類別" />
    </Columns>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>
</span>--%>

</asp:Content>
