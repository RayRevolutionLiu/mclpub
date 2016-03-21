<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptAdAmtQuery.aspx.cs" Inherits="mclpub.Contract.RptAdAmtQuery"  MasterPageFile="~/MasterPage.Master"%>

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

<script language="javascript">
    function cleanAll() {
        window.document.getElementById("<% =tbxMfrName.ClientID%>").value = "";
        window.document.getElementById("<% =tbxSDate.ClientID%>").value = "";
        window.document.getElementById("<% =tbxEDate.ClientID%>").value = "";
        window.document.getElementById("<% =ddlEmpData.ClientID%>").value = "000000";
        //ddlCancel
    }

</script>


<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;合約管理 / 網路廣告合約書 / 廣告費用檢查清單</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>
    <td align="right" width="20%" class="font_bold">
        廠商名稱：</td>
    <td>
        <asp:TextBox ID="tbxMfrName" runat="server" Width="184px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" width="20%" class="font_bold">
        廣告日期區間：</td>
    <td>
        <asp:TextBox ID="tbxSDate" runat="server" Width="100px"></asp:TextBox>
        ~<asp:TextBox ID="tbxEDate" runat="server" Width="100px"></asp:TextBox>
        <asp:Label ID="lblSEDateMemo" runat="server" ForeColor="Maroon">(yyyy/mm/dd)</asp:Label>
      </td>
  </tr>
  <tr>
    <td align="right" width="20%" class="font_bold">
        承辦業務員：</td>
    <td>
        <asp:DropDownList ID="ddlEmpData" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right" colspan="2">
        <asp:Button ID="btnPrint" runat="server" Text="產生廣告費用檢查清單" 
            onclick="btnPrint_Click" />
        <input id="btnClose" name="btnClose" onclick="cleanAll();" type="button" value="清除重查" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'"/>
        </td>
  </tr>
</table>
</asp:Content>
