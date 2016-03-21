<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PayDelete.aspx.cs" Inherits="mclpub.Pay.PayDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 繳款處理 / 刪除繳款資料</span> 
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="170" class="font_bold">繳款編號：</td>
    <td>
        <asp:TextBox ID="tbxPyno" runat="server" MaxLength="8"></asp:TextBox>
      </td>
  </tr>
  </table>
</span> 

<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="Button1" runat="server" Text="查詢" onclick="Button1_Click" />
    </td>
  </tr>
</table>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td class="font_size18 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果</td>
    <td align="right">
        <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
            Text="刪除繳款資料" Visible="False" />
    </td>
</tr>
</table>
<span class="stripeMe">
    <asp:GridView ID="PayDelGV" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="font_blacklink font_size13">
    <Columns>
                <asp:BoundField DataField="py_pyno" HeaderText="繳款編號" />
                <asp:BoundField DataField="py_amt" HeaderText="金額"/>
                <asp:BoundField DataField="pytp_nm" HeaderText="付款方式"/>
                <asp:BoundField DataField="py_date" HeaderText="繳款日期" />
                <asp:BoundField DataField="py_moitem" HeaderText="項次" />
                <asp:BoundField DataField="py_chkno" HeaderText="票據號碼"/>
                <asp:BoundField DataField="py_chkbnm" HeaderText="付款行"/>
                <asp:BoundField DataField="py_chkdate" HeaderText="到期日"/>
                <asp:BoundField DataField="py_waccno" HeaderText="電匯帳號"/>
                <asp:BoundField DataField="py_wdate" HeaderText="匯入日期" />                
                <asp:BoundField DataField="py_wbcd" HeaderText="金融代碼" />
                <asp:BoundField DataField="py_ccno" HeaderText="信用卡卡號" />
                <asp:BoundField DataField="py_ccauthcd" HeaderText="授權碼" />
                <asp:BoundField DataField="py_ccvdate" HeaderText="有效年月" />
                <asp:BoundField DataField="py_ccdate" HeaderText="交易日期" />
                <asp:BoundField DataField="pyd_pyditem" HeaderText="繳款序號" />
                <asp:BoundField DataField="pyd_iano" HeaderText="發票開立單編號" />
    </Columns>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>
</span>
</asp:Content>
