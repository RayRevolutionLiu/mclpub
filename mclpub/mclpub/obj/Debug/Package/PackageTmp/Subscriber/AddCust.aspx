<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCust.aspx.cs" Inherits="mclpub.Subscriber.AddCust1"  MasterPageFile="~/MasterPage.Master"%>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

<script type="text/javascript">
    function clearTx() {
        window.document.getElementById("<% =tbxInm.ClientID%>").value = "";
        window.document.getElementById("<% =tbxMfrno.ClientID%>").value = "";
    }
</script>
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;客戶管理 / 客戶資料維護 / 廠商資料查詢</span>  
    <span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="120" class="font_bold">廠商發票抬頭:</td>
    <td>
        <asp:TextBox ID="tbxInm" runat="server"></asp:TextBox>
        <asp:LinkButton ID="AddComp_Lk" runat="server" onclick="AddComp_Lk_Click">新增廠商資料</asp:LinkButton>
      </td>
  </tr>
  <tr>
    <td align="right" width="120" class="font_bold">廠商統一編號:</td>

    <td>
<span class="stripeMe">
        <asp:TextBox ID="tbxMfrno" runat="server"></asp:TextBox>
</span>
      </td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="CheckBtn" runat="server" Text="查詢" CssClass="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="CheckBtn_Click" />
        <input id="ClearBtn" type="button" value="清除" class="btn_mouseout" onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="clearTx()" />
    </td>
  </tr>
</table>  

<table border="0" width="100%" cellspacing="0" cellpadding="0" id="SearchIcon" runat="server">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
        &nbsp;</td>
</tr>
</table>
<span class="stripeMe">
    <asp:GridView ID="CompGV" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="font_blacklink font_size13" OnRowDataBound="CompGVOnRowDataBound" AllowPaging="True" PagerSettings-Visible="false">
    <Columns>
                <asp:BoundField DataField="mfr_mfrid" HeaderText="ID" />
                <asp:BoundField DataField="mfr_mfrno" HeaderText="廠商統一編號"  HeaderStyle-Width="20%"/>
                <asp:BoundField DataField="mfr_inm" HeaderText="發票抬頭" HeaderStyle-Width="20%" />
                <asp:BoundField DataField="mfr_iaddr" HeaderText="發票地址" HeaderStyle-Width="25%" />
                <asp:BoundField DataField="mfr_izip" HeaderText="公司聯絡電話" HeaderStyle-Width="20%"/>
                <asp:TemplateField HeaderText="選取" HeaderStyle-Width="5%">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" Text="選取"  class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" OnClick="RedrectEdit" />
                </ItemTemplate>
                </asp:TemplateField>
    </Columns>
    
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>
</span>
<!--{* 分頁start *}-->
<div class="pager font_size13">
 <uc3:ucpager id="UCPager1" runat="server" />    
</div>
</asp:Content>
