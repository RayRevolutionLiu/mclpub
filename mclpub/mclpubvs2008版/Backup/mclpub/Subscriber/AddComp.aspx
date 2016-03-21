<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddComp.aspx.cs" Inherits="mclpub.Subscriber.AddComp"  MasterPageFile="~/MasterPage.Master"%>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

    <script>
$(function() {
$("#<% =createdate.ClientID%>").datepicker(
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
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;訂戶管理 / 新增廠商資料</span>  
    <span class="font_red font_size12">*為必填欄位</span>    
    <table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">新增廠商資料</th>
  </tr>
    <tr id="TopTr">
    <td align="right" class="font_red font_bold" width="150"><asp:Label ID="Label_type" runat="server" Text="*資料類別:"></asp:Label></td>
    <td>
        <asp:dropdownlist id="ddlmfr_type" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlmfr_type_SelectedIndexChanged">
        <asp:ListItem Value="A">廠商 - 統一編號</asp:ListItem>
        <asp:ListItem Value="B">姓名 - 身份證字號</asp:ListItem>
        <asp:ListItem Value="C">廠商 - 資料編號</asp:ListItem>
        </asp:dropdownlist>
        <font color="#696969"><asp:Label ID="PSddlmfr_type" runat="server" Text="(註:國外廠商請選擇 &quot;廠商 - 資料編號&quot;)"></asp:Label>
        </font>

      </td>
  </tr>
  <tr>
    <td align="right" class="font_red font_bold" width="150">
        <asp:Label ID="lblmfr_mfrno" runat="server" Text="*廠商統一編號:"></asp:Label></td>
    <td>
        <asp:TextBox ID="mfr_mfrno" runat="server"></asp:TextBox>

    <span class="stripeMe">
        <asp:Label ID="Labelddlmfr_type" runat="server" Text=""></asp:Label>
    </span>
        <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" Display="Dynamic" ErrorMessage="請輸入八位數字!" ControlToValidate="mfr_mfrno" ValidationExpression="[0-9]{8}"></asp:RegularExpressionValidator>
        <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="mfr_mfrno"></asp:requiredfieldvalidator>
        
      </td>
  </tr>
    <tr>
    <td align="right" width="150" class="font_red font_bold">
        <asp:Label ID="lblmfr_inm" runat="server" Text="*發票抬頭:"></asp:Label></td>
    <td>
        <asp:TextBox ID="mfr_inm" runat="server" MaxLength="50" Width="270px"></asp:TextBox>
        <asp:requiredfieldvalidator id="Requiredfieldvalidator2" runat="server" Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="mfr_inm"></asp:requiredfieldvalidator>
      </td>
  </tr>
   <tr>
    <td align="right" width="150" class="font_bold" >發票地址:</td>
    <td>
        <asp:TextBox ID="mfr_addr" runat="server" Width="370px" MaxLength="120"></asp:TextBox>
      </td>
    </tr>
    <tr>
        <td align="right" width="150" class="font_bold">廠商郵遞區號:</td>
        <td>
        <asp:TextBox ID="mfr_izip" runat="server" Width="42px" MaxLength="5"></asp:TextBox>
            <a href="#" target="_blank">郵遞區號查詢</a>
        <asp:regularexpressionvalidator id="Regularexpressionvalidator5" runat="server" Display="Dynamic" ErrorMessage="只能填寫數字!" ControlToValidate="mfr_izip" ValidationExpression="[0-9]{1,5}"></asp:regularexpressionvalidator>
        </td>
    </tr>
    <tr>
        <td align="right" width="150" class="font_bold">公司負責人姓名:</td>
        <td>
        <asp:TextBox ID="mfr_respnm" runat="server" MaxLength="30"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right" width="150" class="font_bold">公司負責人職稱:</td>
        <td>
        <asp:TextBox ID="mfr_respjbti" runat="server" Width="100px" MaxLength="12"></asp:TextBox>
            <font face="新細明體"><font color="#696969">(註:若無職稱時請輸入&quot;先生&quot;或&quot;小姐&quot;)</font> </font>
        </td>
    </tr>
     <tr>
        <td align="right" width="150" class="font_bold">公司連絡電話:</td>
        <td>
        <asp:TextBox ID="mfr_tel" runat="server" MaxLength="30"></asp:TextBox>
            <font color="#696969" face="新細明體">(範例:03-1234567#123)</font></td>
    </tr>
     <tr>
        <td align="right" width="150" class="font_bold">公司傳真號碼:</td>
        <td>
        <asp:TextBox ID="mfr_fax" runat="server" MaxLength="30"></asp:TextBox>
            <font color="#696969" face="新細明體">(範例:03-1234567#123)</font></td>
    </tr>
     <tr>
        <td align="right" width="150" class="font_bold">註冊日期:</td>
        <td>
        <asp:TextBox ID="createdate" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
    <td align="right" colspan="2">
        <asp:Button ID="submitBtn" runat="server" Text="確定新增" class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="submitBtn_Click" />
        <input id="Button1" type="button" value="放棄新增"  class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="location.href='Company.aspx'"/>  
    </td>
    </tr>
        </table>
    </span>
</asp:Content>
