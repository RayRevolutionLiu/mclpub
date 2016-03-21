<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RptCont.aspx.cs" Inherits="mclpub.Contract.RptCont"  MasterPageFile="~/MasterPage.Master"%>

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
        window.document.getElementById("<% =tbxContNo0.ClientID%>").value = "";
        window.document.getElementById("<% =tbxSDate.ClientID%>").value = "";
        window.document.getElementById("<% =tbxEDate.ClientID%>").value = "";
        window.document.getElementById("<% =ddlEmpData.ClientID%>").value = "000000";
        window.document.getElementById("<% =tbxMfrIName.ClientID%>").value = "";
        window.document.getElementById("<% =ddlClosed.ClientID%>").value = "99";
        window.document.getElementById("<% =ddlCancel.ClientID%>").value = "99";
        //ddlCancel
    }

</script>


<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;廣告合約管理 / 網路廣告合約書 / 合約書清單</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">單一合約書清單</th>
  </tr>
  <tr>
    <td align="right" width="20%" class="font_bold">
        合約書編號：</td>
    <td>
        <asp:TextBox ID="tbxContNo" runat="server" Width="100px"></asp:TextBox>
      </td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right" colspan="2">
        <asp:Button ID="btnGo" runat="server" Text="產生合約書清單" onclick="btnGo_Click" />
        </td>
  </tr>
</table>
<br />
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">大批合約書清單</th>
  </tr>
  <tr>
    <td align="right" width="20%" class="font_bold">
        合約書編號：</td>
    <td>
        <asp:TextBox ID="tbxContNo0" runat="server" Width="100px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" width="20%" class="font_bold">
        簽約日期區間：</td>
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
  <tr>
    <td align="right" width="20%" class="font_bold">
        廠商名稱：</td>
    <td>
        <asp:TextBox ID="tbxMfrIName" runat="server"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" width="20%" class="font_bold">
        已結案：</td>
    <td>
        <asp:DropDownList ID="ddlClosed" runat="server">
            <asp:ListItem Value="99" Selected="True">請選擇</asp:ListItem>
            <asp:ListItem Value="0">否</asp:ListItem>
            <asp:ListItem Value="1">是</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" width="20%" class="font_bold">
        已註銷：</td>
    <td>
        <asp:DropDownList ID="ddlCancel" runat="server">
            <asp:ListItem Value="99" Selected="True">請選擇</asp:ListItem>
            <asp:ListItem Value="0">否</asp:ListItem>
            <asp:ListItem Value="1">是</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right" colspan="2">
        <asp:Button ID="btnGoAll" runat="server" Text="產生合約書清單" 
            onclick="btnGoAll_Click" />
        <input id="btnClose" name="btnClose" onclick="cleanAll();" type="button" value="清除重查" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'"/>
        </td>
  </tr>
</table>
        
</asp:Content>
