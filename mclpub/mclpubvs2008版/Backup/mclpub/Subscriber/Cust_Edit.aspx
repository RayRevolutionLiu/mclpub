<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cust_Edit.aspx.cs" Inherits="mclpub.Subscriber.AddCust"  MasterPageFile="~/MasterPage.Master"%>
<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

<script>
$(function() {
$("#<% =cust_regdate.ClientID%>").datepicker(
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
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;訂戶管理 / <asp:Label ID="showWhere" runat="server" Text="新增客戶資料"></asp:Label></span>  
<span class="font_red font_size12">*為必填欄位</span>    
    <span class="stripeMe"> 
    <table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="4">
        <asp:Label ID="TitleName" runat="server" Text="新增客戶資料"></asp:Label>
        </th>
  </tr>
    <tr>
    <td align="right" class="font_red font_bold" width="150">*客戶編號:</td>
    <td>
        <asp:TextBox ID="cust_custno" runat="server" Width="46px" MaxLength="6" Enabled="false"></asp:TextBox>
    <span class="stripeMe">
    <asp:regularexpressionvalidator id="Regularexpressionvalidator1" runat="server" ControlToValidate="cust_custno" ErrorMessage="請輸入 6 位數字!" Display="Dynamic" ValidationExpression="[0-9]{6}"></asp:regularexpressionvalidator>
        <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="cust_custno" ErrorMessage="必填欄位!" Display="Dynamic"></asp:requiredfieldvalidator>
    </span>

      </td>
    <td align="right" class="font_bold" width="150">舊客戶編號:</td>
    <td>
        <asp:TextBox ID="cust_oldcustno" runat="server" MaxLength="5" Width="42px"></asp:TextBox>
    </td>
  </tr> 
  <tr>
    <td align="right" class="font_red font_bold" width="150">
        *客戶姓名:</td>
    <td>
        <asp:TextBox ID="cust_nm" runat="server" MaxLength="30"></asp:TextBox>
       <asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" ControlToValidate="cust_nm" ErrorMessage="必填欄位!" Display="Dynamic"></asp:requiredfieldvalidator>
      </td>
    <td align="right" class="font_bold" width="150">客戶職稱:</td>
    <td>
        <asp:TextBox ID="cust_jbti" runat="server" MaxLength="12" Width="100px"></asp:TextBox>

    <span class="stripeMe">
            <font face="新細明體"><font color="#696969">
        <br />
        (註:若無職稱時請輸入&quot;先生&quot;或&quot;小姐&quot;)</font> </font>
    </span>
    </td>
  </tr>
    <tr>
    <td align="right" width="150" class="font_red font_bold">
        <asp:Label ID="lblmfr_inm" runat="server" Text="*發票抬頭:"></asp:Label></td>
    <td>
        <asp:DropDownList ID="ddlcust_inm" runat="server" AutoPostBack="true" 
            onselectedindexchanged="ddlcust_inm_SelectedIndexChanged">
        </asp:DropDownList>
      </td>
    <td align="right" class="font_bold" width="150">廠商統一編號:</td>
    <td>
        <asp:Label ID="cust_mfrno" runat="server" Text="" ForeColor="#C00000"></asp:Label>
    </td>
  </tr>
   <tr>
    <td align="right" width="150" class="font_bold" >連絡電話:</td>
    <td>
        <asp:TextBox ID="cust_tel" runat="server" MaxLength="30"></asp:TextBox>

    <span class="stripeMe">
            <font color="#696969" face="新細明體">(範例:03-1234567#123)</font></span></td>
            
    <td align="right" class="font_bold" width="150">傳真號碼:</td>
    <td>
        <asp:TextBox ID="cust_fax" runat="server" MaxLength="30"></asp:TextBox>
            <span class="stripeMe">
            <font color="#696969" face="新細明體">
        <br />
        (範例:03-1234567#123)</font></span>
    </td>
    </tr>
    <tr>
        <td align="right" width="150" class="font_bold">手機號碼:</td>
        <td>
            <asp:TextBox ID="cust_cell" runat="server" MaxLength="30"></asp:TextBox>

    <span class="stripeMe">
            <font color="#696969" face="新細明體">(範例:0911-123456)</font></span></td>
        <td align="right" class="font_bold" width="150">Email:</td>
    <td>
        <asp:TextBox ID="cust_email" runat="server" MaxLength="80" Width="200px"></asp:TextBox>
        <asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" ControlToValidate="cust_email" ErrorMessage="格式錯誤!" ValidationExpression=".{1,}@.{3,}"></asp:regularexpressionvalidator>
    </td>
    </tr>
    <tr>
        <td align="right" width="150" class="font_bold">註冊日期:</td>
        <td>
        <asp:TextBox ID="cust_regdate" runat="server"></asp:TextBox>
        </td>
        
        <td align="right" width="150" class="font_bold">修改日期:</td>
        <td>
            <asp:Label ID="cust_moddate" runat="server" ForeColor="#C00000"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right" width="150" class="font_bold">業務人員:</td>
        <td>
            <asp:DropDownList ID="ddlEmpNo" runat="server">
            </asp:DropDownList>
        </td>
                <td align="right" width="150" class="font_bold">&nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
        <tr>
        <td align="right" width="150" class="font_bold">客戶領域代碼:</td>
        <td colspan="3">
            <asp:CheckBoxList ID="cblcust_itpcd" runat="server" tabIndex="1" Width="98%" RepeatDirection="Horizontal" RepeatColumns="6">
            </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
        <td align="right" width="150" class="font_bold">客戶營業代碼:</td>
        <td colspan="3">
        <asp:checkboxlist id="cblcust_btpcd" tabIndex="1" runat="server" Width="98%" RepeatDirection="Horizontal" RepeatColumns="5"></asp:checkboxlist>
        </td>
        </tr>
        <tr>
            <td align="right" width="150" class="font_bold">客戶閱讀代碼:</td>
            <td colspan="3">
                <asp:checkboxlist id="cblcust_rtpcd" tabIndex="1" runat="server" Width="98%" RepeatDirection="Horizontal" RepeatColumns="6"></asp:checkboxlist>
        </td>
        </tr>
    <tr>
    <td align="right" colspan="4">
        <asp:Button ID="submitBtn" runat="server" Text="確定新增" class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="submitBtn_Click" />
        <input id="ReChange" type="button" value="重新選擇廠商"  class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="location.href='AddCust.aspx'"/>  
        <input id="Button1" type="button" value="放棄新增"  class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="location.href='Customer.aspx'"/>  
    </td>
    </tr>
        </table>
    </span>
</asp:Content>
