<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pub_new1.aspx.cs" Inherits="mclpub.Layout.pub_new1" MasterPageFile="~/MasterPage.Master" MaintainScrollPositionOnPostback="true" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

<script language="javascript">
    function doSelectMfr(win_width, win_height) {
        var mfrnoV = window.document.getElementById("<% =tbxMfrNo.ClientID%>").value;
        var iTop = (window.screen.availHeight - 30 - win_height) / 2;  //視窗的垂直位置;
        var iLeft = (window.screen.availWidth - 10 - win_width) / 2;   //視窗的水平位置;
        var features = "width=" + win_width + ",height=" + win_height + ",top=" + iTop + ",left=" + iLeft + ",location=no,status=no";
        var vReturn = window.open("../Contract/mfr_detail.aspx?mfrno=" + mfrnoV, "Poping", features);
    }
</script>

    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 平面廣告落版處理 / 新增/維護/顯示 落版 / 由合約書進入</span>
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">公司名稱：</td>
    <td>
        <asp:TextBox ID="tbxMfrName" runat="server"></asp:TextBox>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold"><span class="stripeMe">統一編號：</span></td>
    <td>
        <asp:TextBox ID="tbxMfrNo" runat="server" MaxLength="10" Width="60px"></asp:TextBox>
            <img border="0" class="ico" onclick="doSelectMfr(400,350)" 
            src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>" title="查詢" />
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">
<span class="stripeMe">
        客戶編號：</span></td>
    <td>
        <asp:TextBox ID="tbxCustNo" runat="server" MaxLength="6" 
            tabIndex="3" Width="45px"></asp:TextBox>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">
        客戶性名：</td>
    <td>
        <asp:TextBox ID="tbxCustName" runat="server" MaxLength="30" 
            tabIndex="4" Width="80px"></asp:TextBox>
      </td>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">
        <font color="red">*</font>合約編號：</td>
    <td>
        <asp:TextBox ID="tbxContNo" runat="server" MaxLength="6" 
            tabIndex="5" Width="80px"></asp:TextBox>
      </td>
  </tr>
  </table>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="btnOK" runat="server" Text="查詢" onclick="btnOK_Click" />
    </td>
  </tr>
</table>

<span class="font_size13 font_bold font_gray">
<ol>
	<li>請輸入任一關鍵詞然後按下查詢</li>
    <li>查詢資料結果中,不包含<span class="font_darkblue">「已結案/已註銷」</span>的合約資料<br /><span class="font_red">註:避免重複新增廠商資料</span><br />
        <span class="font_red">註:請先輸入統一編號後,按下旁邊按鈕進行查詢</span></li>
    <li>此查詢結果將串接至<span class="font_darkblue">「合約管理/平面廣告合約書/合約書」</span></li>

</ol>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    </td>
</tr>
</table>

<span class="stripeMe">
    <asp:GridView ID="GVcont" runat="server" Width="99%" 
        AutoGenerateColumns="false" CssClass="font_blacklink font_size13" 
        AllowPaging="true" PagerSettings-Visible="false" 
        onrowdatabound="GVcont_RowDataBound">
    <Columns>
    <asp:BoundField DataField="cont_contno" HeaderText="合約編號" />
    <asp:BoundField DataField="cont_conttp" HeaderText="合約類別" />
    <asp:BoundField DataField="cont_bkcd" HeaderText="書籍代碼" />
    <asp:BoundField DataField="bk_nm" HeaderText="書籍類別" />
    <asp:BoundField DataField="cont_sdate" HeaderText="合約起日" />
    <asp:BoundField DataField="cont_edate" HeaderText="合約迄日" />
    <asp:BoundField DataField="cont_mfrno" HeaderText="廠商統編" />
    <asp:BoundField DataField="mfr_inm" HeaderText="公司名稱" />
    <asp:BoundField DataField="cont_custno" HeaderText="客戶編號" />
    <asp:BoundField DataField="cust_nm" HeaderText="客戶姓名" />
    <asp:BoundField DataField="cust_tel" HeaderText="聯絡電話" />
    <asp:BoundField DataField="cont_fgpubed" HeaderText="已落版" />
    <asp:BoundField DataField="cont_fgpubed" HeaderText="已落版" />
    <asp:TemplateField HeaderStyle-Width="5%">
    <ItemTemplate>
      <asp:Button ID="btnRedirect" runat="server" Text="落版" OnClick="btnRedirect_Click" />
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