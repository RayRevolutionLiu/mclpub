<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PubFm_label_search3.aspx.cs" Inherits="mclpub.LabelArea.PubFm_label_search3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
    function SelectAllCheckboxes(spanChk) {
        elm = document.forms[0];
        for (i = 0; i <= elm.length - 1; i++) {
            if (elm[i].type == "checkbox" && elm[i].id != spanChk.id) {
                if (elm.elements[i].checked != spanChk.checked)
                    elm.elements[i].click();
            }
        }
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;標籤管理 / 平面廣告標籤處理 / 合約外標籤</span>
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

    <td align="right" width="170" class="font_bold">合約類別：</td>
    <td>
        <asp:DropDownList ID="ddlConttp" runat="server">
            <asp:ListItem Value="01" Selected="True">一般</asp:ListItem>
            <asp:ListItem Value="09">推廣</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">截止年月：</td>
    <td>
        <asp:TextBox ID="tbxPubDate" runat="server" Width="60px" MaxLength="7"></asp:TextBox>
                <font color="maroon" size="2">(如 
				2002/08, 預設值: 當月)</font>
        <asp:RegularExpressionValidator ID="revPubDate" runat="server" 
            ControlToValidate="tbxPubDate" ErrorMessage="刊登年月 請依格式填入" 
            Font-Size="Small" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator>
        <br />
        <asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" Font-Size="Small"
                Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="tbxPubDate"></asp:requiredfieldvalidator>
      </td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="CheckBtn" runat="server" Text="查詢" onclick="CheckBtn_Click"/>
    </td>
  </tr>
</table>
<span class="font_size13 font_bold font_gray">
<ol>
	<li>查詢結果為屬於您個人業務之<span class="font_darkblue">合約期間外標籤</span></li>
    <li>查詢結果為合約迄日在<span class="font_darkblue">截止年月</span>之前之資料</li>
    <li><span class="font_darkblue">列印年月</span>代表勾選的資料所要列印時的年月</li>
</ol>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold" ><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right" class="font_bold" width="180px">
        列印年月：</td>
    <td align="left">
        <asp:TextBox ID="tbxPrintDate" runat="server" Width="60px" MaxLength="7"></asp:TextBox>
        <font color="maroon" size="2">(如 
        2002/08, 預設值: 當月)</font>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
    ControlToValidate="tbxPrintDate" ErrorMessage="刊登年月 請依格式填入" 
    Font-Size="Small" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator>
        <br />
        <asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" Font-Size="Small"
                Display="Dynamic" ErrorMessage="必填欄位!" ControlToValidate="tbxPrintDate"></asp:requiredfieldvalidator>
    </td>
    <td align="right">
        <asp:Label ID="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
        <asp:Button ID="btnSave" runat="server" Text="儲存" onclick="btnSave_Click" />
    </td>
</tr>
</table>

<span class="stripeMe">
    <asp:GridView ID="GVSearchLabel" runat="server" Width="100%" 
        AutoGenerateColumns="False" PagerSettings-Visible="false" 
        CssClass="font_blacklink font_size13" EnableModelValidation="True" 
        onrowdatabound="GVSearchLabel_RowDataBound">
    <Columns>
    <asp:TemplateField HeaderStyle-Width="3%"> 
        <headertemplate>  
            <asp:CheckBox ID="CheckAll" runat="server" onclick="javascript:SelectAllCheckboxes(this)" ToolTip="按一次全選，再按一次取消全選" />  
        </headertemplate> 
        <itemtemplate>  
            <asp:CheckBox ID="CheckBox2" runat="server"/>  
        </itemtemplate> 
    </asp:TemplateField> 
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
