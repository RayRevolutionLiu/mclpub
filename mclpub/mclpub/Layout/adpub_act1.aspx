<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adpub_act1.aspx.cs" Inherits="mclpub.Layout.adpub_act1"  MasterPageFile="~/MasterPage.Master"%>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 平面廣告落版處理 / 
        <asp:Label ID="lbtitle" runat="server" ></asp:Label></span>&nbsp;<span class="stripeMe"><table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="120" class="font_bold">書籍類別:</td>
    <td>
        <asp:DropDownList ID="ddlBookCode" runat="server">
            <asp:ListItem Selected="True" Value="00">請選擇</asp:ListItem>
            <asp:ListItem Value="01">工材</asp:ListItem>
            <asp:ListItem Value="02">電材</asp:ListItem>
            <asp:ListItem Value="04">電材叢書</asp:ListItem>
            <asp:ListItem Value="05">材料</asp:ListItem>
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">刊登年月:</td>
    <td>
        <asp:TextBox ID="tbxPubDate" runat="server" Width="70px"></asp:TextBox>

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
        <asp:Button ID="lnbShow" runat="server" Text="查詢"  class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="lnbShow_Click"/>
        </td>
  </tr>
</table>
<span class="font_size13 font_bold font_gray">
<ol>
	<li>請輸入任一關鍵詞然後按下查詢</li>
    <li>出現結果後, 若有錯誤資料, 將要求先修正</li>
    <li>若無錯誤落版資料, 請再按下<span class="font_darkblue">此連結</span>來進行排版動作!</li>
</ol>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
    </td>
</tr>
</table>

<span class="stripeMe">

    <asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
    <asp:GridView ID="GV1" runat="server" Width="99%" AutoGenerateColumns="false" 
        CssClass="font_blacklink font_size13" PagerSettings-Visible="false" 
        onrowdatabound="GV1_RowDataBound">
    <Columns>
    <asp:BoundField DataField="pub_contno" HeaderText="合約書編號" />
    <asp:BoundField DataField="pub_pubseq" HeaderText="落版序號" />
    <asp:BoundField DataField="pub_ltpcd" HeaderText="廣告版面" />
    <asp:BoundField DataField="pub_clrcd" HeaderText="廣告色彩" />
    <asp:BoundField DataField="pub_pgscd" HeaderText="廣告篇幅" />
    <asp:BoundField DataField="pub_fggot" HeaderText="到稿" />
    <asp:BoundField DataField="pub_drafttp" HeaderText="稿件類別" />
    <asp:TemplateField HeaderStyle-Width="5%">
    <ItemTemplate>
        <asp:Button ID="Button2" runat="server" Text="修改" OnClick="BtnRedrectEdit" />
    </ItemTemplate>
    </asp:TemplateField>      
    </Columns>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>

    <asp:GridView ID="GV2" runat="server" Width="99%" AutoGenerateColumns="false" 
        CssClass="font_blacklink font_size13" PagerSettings-Visible="false" 
        onrowdatabound="GV2_RowDataBound">
    <Columns>
    <asp:BoundField DataField="pub_contno" HeaderText="合約書編號" />
    <asp:BoundField DataField="pub_yyyymm" HeaderText="刊登年月" />
    <asp:BoundField DataField="pub_pubseq" HeaderText="落版序號" />
    <asp:BoundField DataField="pub_pgno" HeaderText="刊登頁碼" ItemStyle-ForeColor="Red" />
    <asp:BoundField DataField="pub_fgfixpg" HeaderText="固定頁次" ItemStyle-ForeColor="Red"/>

    <asp:BoundField DataField="pub_ltpcd" HeaderText="廣告版面" ItemStyle-ForeColor="Blue"/>

    <asp:BoundField DataField="pub_clrcd" HeaderText="廣告色彩" />
    <asp:BoundField DataField="pub_pgscd" HeaderText="廣告篇幅" />
    <asp:BoundField DataField="pub_fggot" HeaderText="到稿" />
    <asp:BoundField DataField="pub_drafttp" HeaderText="稿件類別" />
    <asp:TemplateField HeaderStyle-Width="5%">
    <ItemTemplate>
        <asp:Button ID="Button2" runat="server" Text="修改" OnClick="BtnRedrectEdit2" />
    </ItemTemplate>
    </asp:TemplateField>      
    </Columns>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>
</span>
 </asp:Content>