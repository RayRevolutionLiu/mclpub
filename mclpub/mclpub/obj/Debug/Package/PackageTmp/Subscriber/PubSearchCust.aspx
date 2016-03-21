<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PubSearchCust.aspx.cs" Inherits="mclpub.Subscriber.PubSearchCust"  MasterPageFile="~/MasterPage.Master" MaintainScrollPositionOnPostback="true"%>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

<script language="javascript">
    function doSelectMfr(win_width,win_height) {
        var mfrnoV = window.document.getElementById("<% =tbxMfrnoSearch.ClientID%>").value;
        var companyV = window.document.getElementById("<% =tbxCompanyname.ClientID%>").value;
        var iTop = (window.screen.availHeight - 30 - win_height) / 2;  //視窗的垂直位置;
        var iLeft = (window.screen.availWidth - 10 - win_width) / 2;   //視窗的水平位置;
        var features = "width=" + win_width + ",height=" + win_height + ",top=" + iTop + ",left=" + iLeft + ",location=no,status=no";
        var vReturn = window.open("MfrSearch.aspx?mfrno=" + mfrnoV + "&company=" + companyV + "&mfrnoID=<% =tbxMfrnoSearch.ClientID%>&companyID=<% =tbxCompanyname.ClientID%>", "Poping", features);
//        vReturn.document.title = "查詢廠商";
    }
</script>
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;客戶管理 / 雜誌叢書訂戶資料</span>  
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">訂戶資料</th>
  </tr>
  <tr>

    <td align="right" width="120" class="font_bold">公司名稱:</td>
    <td>
        <asp:TextBox ID="tbxCompanyname" runat="server" Width="204px"></asp:TextBox>
        <IMG class="ico" title="查詢" onclick="doSelectMfr(900,500)" src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0">
      </td>
  </tr>
  <tr>
    <td align="right" width="120" class="font_bold">統一編號:</td><td>
        <asp:TextBox ID="tbxMfrnoSearch" runat="server"></asp:TextBox>
        <IMG class="ico" title="查詢" onclick="doSelectMfr(900,500)" src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0">
      </td>
  </tr>
  <tr>

    <td align="right" width="120" class="font_bold">訂戶編號:</td>
    <td>
        <asp:TextBox ID="tbxCustNo" runat="server"></asp:TextBox>
</td>
</tr><tr>
    <td align="right" class="font_bold">訂戶姓名:</td><td>
        <asp:TextBox ID="tbxCustName" runat="server"></asp:TextBox></td></tr>
</table>
        </span><table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left">
        <asp:Button ID="CustDetail" runat="server" Text="訂戶明細表" CssClass="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="CustDetail_Click" />
    </td>
    <td align="right">
        <asp:Button ID="CheckBtn" runat="server" Text="查詢" CssClass="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="CheckBtn_Click"/>
        <asp:Button ID="AddCust" runat="server" Text="新增訂戶資料" CssClass="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="AddCust_Click" />
    </td>
  </tr>
</table> 
 
<span class="font_size13 font_bold font_gray">
<ol>
	<li>請輸入任一關鍵詞然後按下查詢</li><li>選擇<span class="font_darkblue">「修改資料」</span>可進入訂戶修改畫面</li></ol>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
        &nbsp;</td>
</tr>
</table>

<span class="stripeMe">
<asp:GridView ID="PsGV" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="font_blacklink font_size13" OnRowDataBound="PsGVOnRowDataBound" AllowPaging="true" PagerSettings-Visible="false" AllowSorting ="true" OnSorting="gv_data_Sorting">
    <Columns>
    <asp:BoundField DataField="cust_custid" HeaderText="ID" />
    <asp:BoundField DataField="cust_custno" HeaderText="訂戶編號" />
    <asp:BoundField DataField="cust_nm" HeaderText="訂戶姓名" />
    <asp:BoundField DataField="cust_jbti" HeaderText="訂戶職稱" />
    <asp:BoundField DataField="cust_tel" HeaderText="聯絡電話" />
    <asp:BoundField DataField="cust_regdate" HeaderText="註冊日期▲" SortExpression ="cust_regdate" HeaderStyle-ForeColor="White" />
    <asp:TemplateField  HeaderStyle-Width="5%">
    <ItemTemplate>
        <asp:Button ID="Button1" runat="server" Text="修改資料"  class="btn_mouseout" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" OnClick="RedrectEdit" />
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
