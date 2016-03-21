<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Printadvert.aspx.cs" Inherits="mclpub.Subscriber.Printadvert" MasterPageFile="~/MasterPage.Master"  MaintainScrollPositionOnPostback="true" %>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
    function Reset1() {
        window.document.getElementById("<% =tbxCustNoQ1.ClientID%>").value = "";
        window.document.getElementById("<% =tbxCustNoQ2.ClientID%>").value = "";
        window.document.getElementById("<% =tbxTelAC.ClientID%>").value = "";
        window.document.getElementById("<% =ddlItpcd.ClientID%>").value = "00";
        window.document.getElementById("<% =ddlBtpcd.ClientID%>").value = "00";
    }
    function Reset2() {
        window.document.getElementById("<% =ddlConttp.ClientID%>").value = "00";
        window.document.getElementById("<% =ddlBookCode.ClientID%>").value = "00";
    }

    function Reset3() {
        window.document.getElementById("<% =ddlConttp2.ClientID%>").value = "00";
        window.document.getElementById("<% =ddlBookCode2.ClientID%>").value = "00";
        window.document.getElementById("<% =ddlMtpcd.ClientID%>").value = "00";
    }
</script>
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;客戶管理 / 平面廣告推廣戶</span>  
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">客戶基本資料清單</th>
  </tr>
  <tr>

    <td align="right" width="200" class="font_bold">客戶編號範圍:</td>
    <td>
        <asp:TextBox ID="tbxCustNoQ1" runat="server" Width="60px" MaxLength="6"></asp:TextBox>
        ~<span class="stripeMe"><asp:TextBox ID="tbxCustNoQ2" runat="server" Width="60px" MaxLength="6"></asp:TextBox>
</span>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">客戶電話號碼:</td>
    <td>
        <asp:TextBox ID="tbxTelAC" runat="server" MaxLength="10"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">客戶領域代碼:</td>
    <td>
        <asp:DropDownList ID="ddlItpcd" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">客戶營業代碼:</td>
    <td>
        <asp:DropDownList ID="ddlBtpcd" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
</table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="CheckBtn1" runat="server" Text="查詢"  class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="CheckBtn1_Click" />
         <input id="ResetBtn" type="button" value="清除重查"  class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="Reset1()"/>
    </td>
  </tr>
</table>
<br />
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">廣告推廣戶清單</th>
  </tr>
  <tr>
    <td align="right" class="font_bold" width="120">  合約類別:</td>
    <td>
        <asp:DropDownList ID="ddlConttp" runat="server">
        <asp:ListItem Value="00" Selected="True">請選擇</asp:ListItem>        
        <asp:ListItem Value="01">一般合約</asp:ListItem>
        <asp:ListItem Value="09">推廣合約</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">書籍類別:</td>
    <td>
        <asp:DropDownList ID="ddlBookCode" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
</table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="CheckBtn2" runat="server" Text="查詢"  class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="CheckBtn2_Click" />
         <input id="ResetBtn2" type="button" value="清除重查"  class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="Reset2()"/>
    </td>
  </tr>
</table>  
<br />
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">廣告推廣戶標簽</th>
  </tr>
  <tr>
    <td align="right" class="font_bold" width="120">合約類別:</td>
    <td>
        <asp:DropDownList ID="ddlConttp2" runat="server">
        <asp:ListItem Value="00" Selected="True">請選擇</asp:ListItem>      
        <asp:ListItem Value="01">一般合約</asp:ListItem>
        <asp:ListItem Value="09">推廣合約</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">書籍類別:</td>
    <td>
        <asp:DropDownList ID="ddlBookCode2" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">郵寄類別:</td>
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
        <asp:Button ID="CheckBtn3" runat="server" Text="查詢"  class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="CheckBtn3_Click" />
         <input id="ResetBtn3" type="button" value="清除重查"  class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="Reset3()"/>
    </td>
  </tr>
</table>  
</span>
</asp:Content>
