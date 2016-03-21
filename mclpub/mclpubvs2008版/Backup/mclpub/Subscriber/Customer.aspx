<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="mclpub.Subscriber.Customer" MasterPageFile="~/MasterPage.Master" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;訂戶管理 / 客戶資料維護</span>  
    <span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="4">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="120" class="font_bold">  
    <span class="stripeMe">
                廠商發票抬頭:</span></td>
    <td>
    <span class="stripeMe">
        <asp:TextBox ID="TXmfr_inm" runat="server"></asp:TextBox>
</span>
      </td>
    <td align="right" width="120" class="font_bold">  
    <span class="stripeMe">
        聯絡電話:</span></td>
    <td>
        <span class="stripeMe">
        <asp:TextBox ID="TXcust_tel" runat="server"></asp:TextBox>
</span>
      </td>
  </tr>
  <tr>
    <td align="right" width="120" class="font_bold">  
    <span class="stripeMe">
        廠商統編:</span></td>

    <td>
        <span class="stripeMe">
        <asp:TextBox ID="TXcust_mfrno" runat="server"></asp:TextBox>
</span>
      </td>
    <td align="right" width="120" class="font_bold">  
    <span class="stripeMe">
        業務人員:</span></td>
    <td>
    <span class="stripeMe">
        <asp:TextBox ID="TXcust_srspn_empno" runat="server"></asp:TextBox>
</span>
      </td>
  </tr>
  <tr>

    <td align="right" width="120" class="font_bold">  
    <span class="stripeMe">
        客戶姓名:</span></td>
    <td>
        <span class="stripeMe">
        <asp:TextBox ID="TXcust_nm" runat="server"></asp:TextBox>
</span>
      </td>
    <td align="right" width="120" class="font_bold">  
    <span class="stripeMe">
        客戶編號:</td>
    <td>
    <span class="stripeMe">
        <asp:TextBox ID="TXcust_custno" runat="server"></asp:TextBox>
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
    </td>
  </tr>
</table>  



<span class="font_size13 font_bold font_gray">
<ol>
	<li>請輸入任一關鍵詞然後按下查詢</li>
    <li>查詢資料結果中,按下<span class="font_darkblue">「修改客戶資料」</span>可進行編輯該客戶資料</li>

</ol>
</span>
<br />
<table border="0" width="100%" cellspacing="0" cellpadding="0">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
<asp:Button ID="AddNewBtn" runat="server" Text="新增客戶資料" CssClass="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="AddNewBtn_Click" />
    </td>
</tr>

</table>
<span class="stripeMe">
    <asp:GridView ID="CustGV" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="font_blacklink font_size13" OnRowDataBound="CustGVOnRowDataBound" AllowPaging="True" PagerSettings-Visible="false">
    <Columns>
                <asp:BoundField DataField="cust_custid" HeaderText="ID" />
                <asp:BoundField DataField="mfr_inm" HeaderText="廠商發票抬頭" HeaderStyle-Width="15%"/>
                <asp:BoundField DataField="mfr_mfrno" HeaderText="廠商統編" HeaderStyle-Width="10%"/>
                <asp:BoundField DataField="cust_nm" HeaderText="客戶姓名" HeaderStyle-Width="10%" />
                <asp:BoundField DataField="cust_jbti" HeaderText="客戶職稱" HeaderStyle-Width="10%" />
                <asp:BoundField DataField="cust_fax" HeaderText="傳真號碼" HeaderStyle-Width="10%" />
                <asp:BoundField DataField="cust_cell" HeaderText="手機號碼"/>
                <asp:BoundField DataField="cust_email" HeaderText="Email"  HeaderStyle-Width="10%"/>
                <asp:BoundField DataField="cust_custno" HeaderText="客戶編號"  HeaderStyle-Width="10%"/>
                <asp:BoundField DataField="srspn_cname" HeaderText="業務人員" />                
                <asp:BoundField DataField="cust_tel" HeaderText="聯絡電話" />
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

<!--{* 分頁end *}-->
 </asp:Content>