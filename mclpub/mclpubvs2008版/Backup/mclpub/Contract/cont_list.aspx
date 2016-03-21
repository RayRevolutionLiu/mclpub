<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cont_list.aspx.cs" Inherits="mclpub.Contract.cont_list"  MasterPageFile="~/MasterPage.Master"%>

<asp:Content  id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

<script>
    $(function() {
    $("#<% =tbxSignDate1.ClientID%>").datepicker(
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
    $("#<% =tbxSignDate2.ClientID%>").datepicker(
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


<script language="javascript">
    function cleanAll() {
        window.document.getElementById("<% =ddlEmpNo.ClientID%>").value = "000000";
        window.document.getElementById("<% =tbxSignDate1.ClientID%>").value = "";
        window.document.getElementById("<% =tbxSignDate2.ClientID%>").value = "";
        window.document.getElementById("<% =tbxSDate.ClientID%>").value = "";
        window.document.getElementById("<% =tbxEDate.ClientID%>").value = "";
        window.document.getElementById("<% =ddlfgclosed.ClientID%>").value = "99";
        window.document.getElementById("<% =tbxMfrIName.ClientID%>").value = "";
    }

</script>

<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;合約管理 / 平面廣告合約書 / 合約書清單</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>
    <td align="right" width="20%" class="font_bold">
        書籍類別名稱:</td>
    <td>
        <asp:DropDownList ID="ddlBookCode" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">
        承辦業務員:</td>
    <td>
        <asp:DropDownList ID="ddlEmpNo" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">
        合約簽約日期區間:</td>
    <td>
        <asp:TextBox ID="tbxSignDate1" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
        ~<asp:TextBox ID="tbxSignDate2" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">
        合約起訖區間:</td>
    <td>
        <asp:TextBox ID="tbxSDate" runat="server" Width="60px"></asp:TextBox>
        ~<asp:TextBox ID="tbxEDate" runat="server" Width="60px"></asp:TextBox>
        <asp:label id="lblSEDateMemo" runat="server" ForeColor="Maroon" >(如 2002/06  ～ 2002/12)</asp:label>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">
        已結案:</td>
    <td>
        <asp:DropDownList ID="ddlfgclosed" runat="server">
            <asp:ListItem Selected="True" Value="99">請選擇</asp:ListItem>
            <asp:ListItem Value="1">是</asp:ListItem>
            <asp:ListItem Value="0">否</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">
        廠商名稱:</td>
    <td>
        <asp:TextBox ID="tbxMfrIName" runat="server" MaxLength="20"></asp:TextBox>
      </td>
  </tr>
</table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right" colspan="2">
        <asp:Button ID="btnQuery" runat="server" Text="查詢" onclick="btnQuery_Click" />
        <input id="btnClose" name="btnClose" onclick="cleanAll();" type="button" value="清除重查" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'"/>
        <asp:Button ID="btnBack" runat="server" Text="返回首頁" onclick="btnBack_Click" />
        
        </td>
  </tr>
</table>
</asp:Content>