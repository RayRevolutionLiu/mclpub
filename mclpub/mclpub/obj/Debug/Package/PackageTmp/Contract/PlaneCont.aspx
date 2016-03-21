<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PlaneCont.aspx.cs" Inherits="mclpub.Contract.PlaneCont"  MasterPageFile="~/MasterPage.Master" MaintainScrollPositionOnPostback="true"%>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;廣告合約管理 / 平面廣告合約書 步驟一:挑出客戶</span>  
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">平面廣告合約書處理</th>
  </tr>
  <tr>

    <td align="right" width="120" class="font_bold">公司名稱:</td>
    <td>
        <asp:TextBox ID="tbxCompanyName" runat="server" Width="150px"></asp:TextBox>
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">廠商統編:</td>
    <td>
        <asp:TextBox ID="tbxMfrNo" runat="server" Width="60px" MaxLength="10"></asp:TextBox>
        <IMG class="ico" title="查詢" onclick="doSelectMfr('450','300')" src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" border="0" alt="查詢廠商">
      </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">客戶編號:</td>
    <td>
        <asp:TextBox ID="tbxCustNo" runat="server" Width="45px" MaxLength="6"></asp:TextBox>
        (須正確的值)</td>
  </tr>
  <tr>
    <td align="right" class="font_bold">客戶姓名:</td>
    <td>
        <asp:TextBox ID="tbxCustName" runat="server" Width="80px"></asp:TextBox>
      </td>
  </tr>
</table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="CheckBtn" runat="server" Text="查詢"  class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="CheckBtn_Click"/>
        <asp:Button ID="AddComp" runat="server" Text="新增廠商資料"  class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="AddComp_Click"/>
        <asp:Button ID="AddCust" runat="server" Text="新增客戶資料"  class="btn_mouseout" 
            onmouseover="this.className='btn_mouseover'" 
            onmouseout="this.className='btn_mouseout'" onclick="AddCust_Click"/>
    </td>
  </tr>
</table>
<span class="font_size13 font_bold font_gray">
<ol>
	<li>請輸入任一關鍵詞然後按下查詢</li>
    <li>查詢資料結果中,按下<span class="font_darkblue">「修改客戶資料」</span>可修改該客戶的資料</li>
    <li>查出資料後,按下<span class="font_darkblue">「確定」</span>可繼續新增/維護合約書步驟,並帶入該客戶的相關資料</li>
</ol>
</span>
<br />
<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
    </td>
</tr>
</table>
<span class="stripeMe">
    <asp:GridView ID="ContGV" runat="server" Width="99%" AutoGenerateColumns="false" CssClass="font_blacklink font_size13" OnRowDataBound="ContGVOnRowDataBound" AllowPaging="true" PagerSettings-Visible="false"
    AllowSorting="True" OnSorting="GVEdit_Sorting">
    <Columns>
    <asp:TemplateField HeaderStyle-Width="10%">
    <ItemTemplate>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lkRedrectEdit">修改客戶資料</asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
    <asp:BoundField DataField="cust_custid" HeaderText="ID" />
    <asp:BoundField DataField="mfr_mfrno" HeaderText="廠商統編" />
    <asp:BoundField DataField="mfr_inm" HeaderText="公司名稱" />
    <asp:BoundField DataField="cust_custno" HeaderText="客戶編號" />
    <asp:BoundField DataField="cust_nm" HeaderText="客戶姓名" />
    <asp:BoundField DataField="cust_jbti" HeaderText="客戶職稱" />
    <asp:BoundField DataField="cust_tel" HeaderText="聯絡電話" />
    <asp:BoundField DataField="cust_regdate" HeaderText="註冊日期"  SortExpression="cust_regdate"/>
    <asp:TemplateField HeaderStyle-Width="5%">
    <ItemTemplate>
        <asp:Button ID="Button2" runat="server" Text="確定" OnClick="BtnRedrectEdit" />
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
<script language="javascript">
    function doSelectMfr(win_width,win_height) {
        var mfrnoV = window.document.getElementById("<% =tbxMfrNo.ClientID%>").value;
        var iTop = (window.screen.availHeight - 30 - win_height) / 2;  //視窗的垂直位置;
        var iLeft = (window.screen.availWidth - 10 - win_width) / 2;   //視窗的水平位置;
        var features = "width=" + win_width + ",height=" + win_height + ",top=" + iTop + ",left=" + iLeft + ",location=no,status=no";
        var vReturn = window.open("mfr_detail.aspx?mfrno=" + mfrnoV, "Poping", features);
    }
</script>
</asp:Content>
