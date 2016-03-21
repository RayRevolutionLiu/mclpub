<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="S_SearchCust1.aspx.cs" Inherits="mclpub.Sys.S_SearchCust1" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;系統管理 / 雜誌叢書訂單處理 / 新增舊訂單(不新增ia及py)</span> 
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="90" class="font_bold">公司名稱：</td>
    <td>
        <asp:TextBox ID="tbxCompanyname" runat="server" Width="204px"></asp:TextBox>
      </td>
  </tr>
  <tr>

    <td align="right" width="90" class="font_bold">統一編號<span class="stripeMe">：</span></td>
    <td>
        <asp:TextBox ID="tbxMfrno" runat="server" Width="80px"></asp:TextBox>
      </td>
  </tr>
  <tr>

    <td align="right" width="90" class="font_bold"> 
<span class="stripeMe">
        訂戶編號：</span></td>
    <td>
        <asp:TextBox ID="tbxCustNo" runat="server" Width="80px"></asp:TextBox>
<span class="stripeMe">
        <font color="maroon" size="2">(請輸入正確之訂戶編號)</font>
      </span>

      </td>
  </tr>
  <tr>

    <td align="right" width="90" class="font_bold">訂戶<span class="stripeMe">姓名：</span></td>
    <td>
        <asp:TextBox ID="tbxCustName" runat="server" Width="99px"></asp:TextBox>
      </td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="CheckBtn" runat="server" Text="查詢" onclick="CheckBtn_Click"/>
        <asp:Button ID="AddComp" runat="server" Text="新增廠商資料" onclick="AddComp_Click"/>
        <asp:Button ID="AddCust" runat="server" Text="新增訂戶資料" 
            onclick="AddCust_Click" />
    </td>
  </tr>
</table>  

<span class="font_size13 font_bold font_gray">
<ol>
	<li>請輸入任一關鍵詞然後按下<span class="font_darkblue">「查詢」</span></li>
	<li>選擇<span class="font_darkblue">「修改資料」</span>可進入訂戶修改畫面</li>
	<li>選擇<span class="font_darkblue">「確定」</span>進入此訂戶之歷史訂單畫面</li>
</ol>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
        &nbsp;</td>
</tr>
</table>

<span class="stripeMe">
    <asp:GridView ID="GVSearchCust" runat="server" Width="99%" 
        AutoGenerateColumns="false" AllowPaging="True" PagerSettings-Visible="false" 
        CssClass="font_blacklink font_size13" OnSorting="gv_data_Sorting" 
        AllowSorting ="true" onrowdatabound="GVSearchCust_RowDataBound">
    <Columns>
    <asp:BoundField DataField="cust_custid" HeaderText="ID" />
    <asp:TemplateField HeaderStyle-Width="7%">
        <ItemTemplate>
            <asp:LinkButton ID="LinkButton1" runat="server" Text="修改資料" OnClick="Edit_Click"></asp:LinkButton>
        </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="mfrnm" HeaderText="公司名稱" />
    <asp:BoundField DataField="cust_custno" HeaderText="訂戶編號" />
    <asp:BoundField DataField="cust_nm" HeaderText="訂戶姓名" />
    <asp:BoundField DataField="cust_jbti" HeaderText="訂戶職稱" />
    <asp:BoundField DataField="cust_tel" HeaderText="聯絡電話" />
    <asp:BoundField DataField="cust_regdate" HeaderText="註冊日期▼"  SortExpression="cust_regdate" HeaderStyle-ForeColor="White"/>
    <asp:TemplateField HeaderStyle-Width="5%">
        <ItemTemplate>
            <asp:Button ID="Button1" runat="server" Text="確定" OnClick="OK_Click"/>
        </ItemTemplate>
    </asp:TemplateField>
    </Columns>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>
</span>
<div class="pager font_size13">
 <uc3:ucpager id="UCPager1" runat="server" />  
 </div>
</asp:Content>
