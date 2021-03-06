﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="mclpub._Default" MasterPageFile="~/MasterPage.Master" %>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server"> 
<table border="0" width="100%" cellspacing="0" cellpadding="0" summary="標題列">
<tr>
	<td valign="bottom" class="font_size21 font_bold"><img src="<%=ResolveUrl("~/Art/images/icon_2401.gif")%>" />首頁查詢介面</td>
</tr>
</table>
    <span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>

  <tr>
    <td align="right" width="90" class="font_bold">公司名稱:</td>
    <td>
    <asp:TextBox ID="tbxCompany" runat="server" MaxLength="50" Width="306px"></asp:TextBox>
<%--    <input type="image" src="<%=ResolveUrl("~/Art/images/btn_view.gif")%>" />&nbsp;
    <span class="font_size12">請輸入關鍵值然後按查詢以取得統一編號</span>--%>
    </td>
      
  </tr>
  <tr>

    <td align="right" class="font_bold">統一編號:</td>
    <td>
    <asp:TextBox ID="tbxcontno" runat="server" MaxLength="10" Width="306px"></asp:TextBox>
<%--    <input type="image" src="<%=ResolveUrl("~/Art/images/btn_view.gif")%>" />--%>
    </td>
  </tr>
  <tr>

    <td align="right" class="font_bold">姓名:</td>
    <td><asp:TextBox ID="tbxCname" runat="server" MaxLength="20" Width="306px"></asp:TextBox></td>
  </tr>
</table>
</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0"> 
    <tr>
        <td align="right">
        <asp:Button ID="btnSearch" runat="server" Text="查詢" onclick="btnSearch_Click" />
        </td>
    </tr>
</table>

<%--<span class="font_size13 font_bold font_gray">
<ol>
	<li>請輸入任一關鍵詞然後按下查詢</li>
</ol>
</span>--%>

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_2402.gif")%>" />查詢結果
            </td>
            <td align="right">
            </td>        
        </tr>
</table>

<span class="stripeMe">
    <asp:GridView ID="GVDefault" runat="server" AutoGenerateColumns="False" CssClass="font_blacklink font_size13"
        Width="99%">
        <Columns>
            <asp:BoundField DataField="CompanyName" HeaderText="廠商名稱" />
            <asp:BoundField DataField="cust_nm" HeaderText="客戶名稱" />
            <asp:BoundField DataField="CustName" HeaderText="統一編號" />
            <asp:BoundField DataField="c1_custno" HeaderText="訂戶編號" />
            <asp:BoundField DataField="c2_contno" HeaderText="平面廣告合約編號" />
            <asp:BoundField DataField="c4_contno" HeaderText="網路廣告合約編號" />
        </Columns>
        <EmptyDataRowStyle HorizontalAlign="Center" />
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
    </asp:GridView>

<%--<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="4">新訂戶資料</th>
  </tr>
  <tr>
    <td align="right" width="90" class="font_bold">訂戶編號:</td>
    <td>003879</td>

    <td align="right" width="90" class="font_bold">登錄日期:</td>
    <td>
    <Input type="text" size="20" />&nbsp;<input type="image" src="<%=ResolveUrl("~/Art/images/btn_data.gif")%>" />&nbsp;
    </td>
  </tr>
  <tr>
    <td align="right" class="font_red font_bold">*姓名:</td>
    <td>

    <Input type="text" size="30" />
    </td>
    <td align="right" width="90" class="font_bold">手機號碼:</td>
    <td>
    <Input type="text" size="30" />
    </td>
  </tr>
  <tr>

    <td align="right" class="font_red font_bold">*聯絡電話:</td>
    <td>
    <Input type="text" size="30" />
    </td>
    <td align="right" width="90" class="font_bold">傳真號碼:</td>
    <td>
    <Input type="text" size="30" />
    </td>

  </tr>
  <tr>
    <td align="right" class="font_bold">職稱:</td>
    <td colspan="3">
    <input type="radio" />&nbsp;先生&nbsp;&nbsp;<input type="radio" />&nbsp;小姐&nbsp;&nbsp;<input type="radio" />&nbsp;自訂&nbsp;&nbsp;<Input type="text" size="20" />
    </td>
  </tr>

  <tr>
    <td align="right" class="font_bold">Email:</td>
    <td colspan="3">
    <Input type="text" size="100" />
    </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">營業項目:</td>

    <td colspan="3">
    <input type="checkbox" />銷售&nbsp;<input type="checkbox" />製造&nbsp;<input type="checkbox" />學校/研究機構/社團&nbsp;<input type="checkbox" />其他&nbsp;
    </td>
  </tr>
  <tr>
    <td align="right" class="font_bold">專業領域:</td>

    <td colspan="3">
    <span class="stripMenone">
    <table border="0" width="100%" cellspacing="0" cellpadding="0" class="font_size13">
  <tr>
    <td width="15%"><input type="checkbox" />半導體</td>
    <td width="15%"><input type="checkbox" />電子/電機</td>
    <td width="15%"><input type="checkbox" />平面顯示器</td>

    <td width="15%"><input type="checkbox" />光電產業</td>
    <td width="15%"><input type="checkbox" />無線通訊</td>
    <td width="15%"><input type="checkbox" />交通運輸</td>
  </tr>
  <tr>
    <td width="15%"><input type="checkbox" />建材</td>
    <td width="15%"><input type="checkbox" />金屬產業</td>

    <td width="15%"><input type="checkbox" />化學/化工</td>
    <td width="15%"><input type="checkbox" />運動/休閒</td>
    <td width="15%"><input type="checkbox" />電池產業</td>
    <td width="15%"><input type="checkbox" />資訊產業</td>
  </tr>
   <tr>
    <td width="15%"><input type="checkbox" />機械</td>

    <td width="15%"><input type="checkbox" />生技/醫療</td>
    <td width="15%"><input type="checkbox" />傳統產業之奈米化學</td>
    <td width="15%"><input type="checkbox" />其他</td>
    <td width="15%">&nbsp;</td>
    <td width="15%">&nbsp;</td>
  </tr>
</table>
    </span>

    
    </td>
  </tr>
</table>--%>



</span>
    </asp:Content>