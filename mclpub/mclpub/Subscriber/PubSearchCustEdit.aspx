<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PubSearchCustEdit.aspx.cs" Inherits="mclpub.Subscriber.PubSearchCustEdit"  MasterPageFile="~/MasterPage.Master"%>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

<script language="javascript">
    function setEncodeURI(reqs) {
        return encodeURI(reqs);
    }

    function doSelectMfr(win_width,win_height) {
        var mfrnoV = window.document.getElementById("<% =tbxMfrno.ClientID%>").value;
        var companyV = setEncodeURI(window.document.getElementById("<% =tbxCompanyname.ClientID%>").value);
        var mfrnoID = "<% =tbxMfrno.ClientID%>";
        var companyID = "<% =tbxCompanyname.ClientID%>";
        var iTop = (window.screen.availHeight - 30 - win_height) / 2;  //視窗的垂直位置;
        var iLeft = (window.screen.availWidth - 10 - win_width) / 2;   //視窗的水平位置;
        var features = "width=" + win_width + ",height=" + win_height + ",top=" + iTop + ",left=" + iLeft + ",location=no,status=no";
        var vReturn = window.open("MfrSearch.aspx?mfrno=" + mfrnoV + "&company=" + companyV + "&mfrnoID=" + mfrnoID + "&companyID=" + companyID + "", "Poping", features);
    }
</script>

    <span class="stripeMe">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;客戶管理 / <asp:Label ID="TopTitleName" runat="server" Text="新增雜誌叢書訂戶資料"></asp:Label></span> 
    <span class="font_red font_size12">*為必填欄位</span>    
    <table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="4">廠商資料</th>
  </tr>
    <tr id="TopTr">
    <td align="right" class="font_red font_bold" width="150">*公司名稱:</td>
    <td colspan="3">
        <font color="#696969">
    <span class="stripeMe">
        <asp:TextBox ID="tbxCompanyname" runat="server"></asp:TextBox>
        <img border="0" class="ico" onclick="doSelectMfr(900,500)" 
            src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" title="查詢" />(請輸入關鍵值然後按&quot;查詢&quot;以取得統一編號)</span></font></td>
  </tr>
  <tr>
    <td align="right" class="font_red font_bold" width="150">
        *統一編號:</td>
    <td colspan="3">
        <asp:TextBox ID="tbxMfrno" runat="server"></asp:TextBox>

        <img border="0" class="ico" onclick="doSelectMfr(900,500)" 
            src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" title="查詢" />
<%--        <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" Display="Dynamic" ErrorMessage="請輸入八位數字!" ControlToValidate="tbxMfrno" ValidationExpression="[0-9]{8}"></asp:RegularExpressionValidator>--%>
        <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="tbxMfrno"></asp:requiredfieldvalidator>
        
    <span class="stripeMe">
        <font color="#696969">(如確定輸入正確統一編號,即可跳過查詢功能輸入以下資料)</font></span></td>
  </tr>
  <tr>
    <th colspan="4">
        <asp:Label ID="TitleName" runat="server" Text="新增雜誌叢書訂戶資料"></asp:Label></th>
  </tr>
   <tr>
    <td align="right" width="150" class="font_bold" >訂戶編號:</td>
    <td>
        <asp:Label id="lblInvoiceid" runat="server"></asp:Label>
      </td>
      <td align="right" width="150" class="font_bold" >  
          登錄日期:</td>
      <td width="250">
          <asp:TextBox ID="tbxRegDate" runat="server" Enabled="false"></asp:TextBox>
          <asp:Label id="lblSEDateMemo0" runat="server"  ForeColor="Maroon">(yyyy/mm/dd)</asp:Label>
      </td>
    </tr>
    <tr>
        <td align="right" width="150" class="font_red font_bold">*姓名:</td>
        <td>
        <asp:TextBox ID="tbxCustname" runat="server"  MaxLength="50"></asp:TextBox>
        <asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" 
                Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="tbxCustname"></asp:requiredfieldvalidator>
        </td>
              <td align="right" width="150" class="font_bold" >
      
                  手機號碼:</td>
      <td>
      
          <asp:TextBox ID="tbxCell" runat="server"  MaxLength="20"></asp:TextBox>
      
      </td>
    </tr>
    <tr>
        <td align="right" width="150" class="font_red font_bold">*連絡電話:</td>
        <td>
        <asp:TextBox ID="tbxTel" runat="server" MaxLength="20"></asp:TextBox>
        <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" 
                Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="tbxTel"></asp:requiredfieldvalidator>
        </td>
        <td align="right" width="150" class="font_bold" >
            傳真號碼:</td>
        <td> 
          <asp:TextBox ID="tbxFax" runat="server" MaxLength="20"></asp:TextBox>
      </td>
    </tr>
    <tr>
        <td align="right" width="150" class="font_bold">職稱:</td>
        <td>
        <asp:radiobuttonlist id="rblJob" runat="server" RepeatDirection="Horizontal" 
                AutoPostBack="true" onselectedindexchanged="rblJob_SelectedIndexChanged">
        <asp:ListItem Value="先生" Selected="True">先生</asp:ListItem>
        <asp:ListItem Value="小姐">小姐</asp:ListItem>
        <asp:ListItem Value="自訂">自訂</asp:ListItem>
        </asp:radiobuttonlist>
          <asp:TextBox ID="tbxJob" runat="server"  MaxLength="10"></asp:TextBox>

        </td>
                <td align="right" width="150" class="font_bold" colspan="2" >
                    &nbsp;</td>
                    
    </tr>
     <tr>
        <td align="right" width="150" class="font_red font_bold">*Email:</td>
        <td colspan="3">
        <asp:TextBox ID="tbxEmail" runat="server" MaxLength="80"  Width="322px"></asp:TextBox>
        <asp:regularexpressionvalidator id="RegularExpressionValidator3" runat="server" ControlToValidate="tbxEmail" ErrorMessage="Email格式錯誤!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic"></asp:regularexpressionvalidator>
        <asp:requiredfieldvalidator id="RequiredFieldValidator4" runat="server" 
                Display="Dynamic" ErrorMessage="不可空白" ControlToValidate="tbxEmail"></asp:requiredfieldvalidator>

            </td>
    </tr>
     <tr>
        <td align="right" width="150" class="font_bold">營業項目:</td>
        <td colspan="3">
            <asp:CheckBoxList ID="cblbtp" runat="server" RepeatDirection="Horizontal" BorderStyle="Inset" BorderWidth="1px" RepeatColumns="4" Width="100%" tabIndex="1">
            </asp:CheckBoxList>
         </td>
    </tr>
     <tr>
        <td align="right" width="150" class="font_bold">專業領域:</td>
        <td colspan="3">
            <asp:CheckBoxList ID="cblitp" runat="server" RepeatDirection="Horizontal" BorderStyle="Inset" BorderWidth="1px" RepeatColumns="4" Width="100%" tabIndex="1">
            </asp:CheckBoxList>

         </td>
    </tr>
    <tr runat="server" id="Moddateid">
        <td align="right" width="150" class="font_bold">上次修改日期:</td>
        <td colspan="3">
            <asp:Label ID="tbxLastModdate" runat="server" Text=""></asp:Label></td>
    </tr>
    <tr>
    <td align="right" colspan="4">
        <asp:Button ID="submitBtn" runat="server" Text="確定新增" class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="submitBtn_Click" />
        <input id="Button1" type="button" value="放棄新增"  class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="location.href='PubSearchCust.aspx'"/>  
    </td>
    </tr>
        </table>
    </span>

</asp:Content>

