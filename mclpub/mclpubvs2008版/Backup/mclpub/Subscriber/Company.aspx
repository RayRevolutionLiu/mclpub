<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Company.aspx.cs" Inherits="mclpub.Subscriber.Company" MasterPageFile="~/MasterPage.Master" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
    <asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
    
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;訂戶管理 / 廠商資料維護</span> 
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="4">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="90" class="font_bold">發票抬頭:</td>
    <td>
        <asp:TextBox ID="TicketName" runat="server"></asp:TextBox>
      </td>
    <td align="right" width="120" class="font_bold">廠商統編:</td>
    <td><asp:TextBox ID="TicketNum" runat="server"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">發票地址:</td>
    <td>
        <asp:TextBox ID="TicketAddr" runat="server"></asp:TextBox>
      </td>
    <td align="right" class="font_bold">公司聯絡電話:</td>
    <td>
        <asp:TextBox ID="CompTel" runat="server"></asp:TextBox>
      </td>
  </tr>
</table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="CheckBtn" runat="server" Text="查詢"  class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" OnClick="CheckBtn_Click"/>
    </td>
  </tr>
</table>  


<span class="font_size13 font_bold font_gray">
<ol>
	<li>請輸入任一關鍵詞然後按下查詢</li>
    <li>查詢資料結果中,按下<span class="font_darkblue">「修改廠商資料」</span>可進行編輯該廠商資料</li>

</ol>
</span>
<br />
<table border="0" width="100%" cellspacing="0" cellpadding="0">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
        <asp:Button ID="AddCompBtn" runat="server" Text="新增廠商資料" class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="AddCompBtn_Click" />
    </td>
</tr>
</table>
<span class="stripeMe">
<asp:GridView ID="CompGV" runat="server" Width="100%" AutoGenerateColumns="false" OnRowDataBound="CompGVOnRowDataBound"  AllowPaging="True" PagerSettings-Visible="false" CssClass="font_blacklink font_size13">
<Columns>
            <asp:BoundField DataField="mfr_mfrid" HeaderText="ID" />
            <asp:BoundField DataField="mfr_mfrno" HeaderText="廠商統一編號" />
            <asp:BoundField DataField="mfr_inm" HeaderText="發票抬頭" />
            <asp:BoundField DataField="mfr_iaddr" HeaderText="發票地址" />
            <asp:BoundField DataField="mfr_tel" HeaderText="公司聯絡電話" />
            <asp:TemplateField HeaderText="修改" HeaderStyle-Width="5%">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" Text="修改"  class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" OnClick="RedrectEdit" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="刪除" HeaderStyle-Width="5%">
                <ItemTemplate>
                    <asp:Button ID="Button2" runat="server" Text="刪除"  class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" OnClick="Delete"/>
                </ItemTemplate>
            </asp:TemplateField>
</Columns>
</asp:GridView>
</span>
<div class="pager font_size13">
 <uc3:ucpager id="UCPager1" runat="server" />  
 </div> 

        </asp:Content>
