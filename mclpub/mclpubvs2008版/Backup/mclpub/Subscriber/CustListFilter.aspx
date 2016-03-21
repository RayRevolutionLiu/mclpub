<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustListFilter.aspx.cs" Inherits="mclpub.Subscriber.CustListFilter"  MasterPageFile="~/MasterPage.Master"%>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
<script>
$(function() {
$("#<% =tbxOrderDate1.ClientID%>").datepicker(
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
$("#<% =tbxOrderDate2.ClientID%>").datepicker(
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
$("#<% =tbxDate1.ClientID%>").datepicker(
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
    $("#<% =tbxDate2.ClientID%>").datepicker(
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
$("#<% =tbxDate.ClientID%>").datepicker(
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
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">訂戶明細表查詢</th>
  </tr>
  <tr>

    <td align="right" width="180" class="font_bold">訂戶別:</td>
    <td>
        <asp:DropDownList ID="ddlCustType" runat="server">
        <asp:ListItem Value="請選擇">請選擇</asp:ListItem>
        <asp:ListItem Value="新訂戶">新訂戶</asp:ListItem>
	    <asp:ListItem Value="續訂戶">續訂戶</asp:ListItem>
        </asp:DropDownList>
        <span class="font_red"><asp:Label ID="CountNum" runat="server" Text=""></asp:Label></span>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">訂購日期:</td><td>
        <asp:TextBox ID="tbxOrderDate1" runat="server"></asp:TextBox>
        ~<span class="stripeMe"><asp:TextBox ID="tbxOrderDate2" runat="server"></asp:TextBox>
</span>
      </td>
  </tr>
  <tr>

    <td align="right" class="font_bold">訂單登錄日期:</td>
    <td>
<span class="stripeMe">
        <asp:TextBox ID="tbxDate1" runat="server"></asp:TextBox>
        ~<asp:TextBox ID="tbxDate2" runat="server"></asp:TextBox>
</span>
      </td>
</tr><tr>
    <td align="right" class="font_bold">訂閱類別:</td><td>
        <asp:DropDownList ID="ddlOrderType1" runat="server" 
            onselectedindexchanged="ddlOrderType1_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Value="00" Selected="True">請選擇</asp:ListItem>
            	<asp:ListItem Value="01">訂閱</asp:ListItem>
				<asp:ListItem Value="02">贈閱</asp:ListItem>
				<asp:ListItem Value="03">推廣</asp:ListItem>
				<asp:ListItem Value="09">零售</asp:ListItem>
        </asp:DropDownList>
<span class="stripeMe">
        <asp:DropDownList ID="ddlOrderType2" runat="server">
        </asp:DropDownList>
</span>
        </td></tr>
        <tr>
    <td align="right" class="font_bold">訂閱書籍類別:</td><td>
<span class="stripeMe">
            <asp:DropDownList ID="ddlBookType" runat="server">
            </asp:DropDownList>
</span>
            </td></tr>
        <tr>
    <td align="right" class="font_bold">郵寄類別:</td><td>
<span class="stripeMe">
            <asp:DropDownList ID="ddlMosea" runat="server" 
                onselectedindexchanged="ddlMosea_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Value="9" Selected="True">請選擇</asp:ListItem>
            <asp:ListItem Value="0">國內</asp:ListItem>
			<asp:ListItem Value="1">國外</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="ddlMailType" runat="server">
            </asp:DropDownList>
</span>
            </td></tr>
        <tr>
    <td align="right" class="font_bold">雜誌收件人姓名:</td><td>
            <asp:TextBox ID="tbxRecName" runat="server"></asp:TextBox>
            </td></tr>
        <tr>
    <td align="right" class="font_bold">訂閱起迄:</td><td>
<span class="stripeMe">
            <asp:TextBox ID="tbxDate" runat="server"></asp:TextBox><span class="font_red">(此日期為訂閱起迄所包含的日期)</span>
</span>
            </td></tr>
        <tr>
    <td align="right" class="font_bold" colspan="2">
        
        <asp:Button ID="CheckBtn" runat="server" Text="查詢" CssClass="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="CheckBtn_Click"/>
     <asp:Button ID="ExportExcel" runat="server" Text="列印報表" CssClass="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="ExportExcel_Click"/>
            </td></tr>
</table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
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
</span>


</asp:Content>

