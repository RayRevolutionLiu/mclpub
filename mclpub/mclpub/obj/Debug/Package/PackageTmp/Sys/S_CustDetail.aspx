﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="S_CustDetail.aspx.cs" Inherits="mclpub.Sys.S_CustDetail" %>
<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;系統管理 / 雜誌叢書訂單處理 / 新增舊訂單(不新增ia及py) /
    <asp:Label ID="titlename" runat="server"></asp:Label> &nbsp;挑出該訂戶的歷史訂單資料</span> 

<table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
<tr>
	<td align="right" width="50%"><asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></td>
    <td align="right">
    <asp:Button ID="AddNewCont" runat="server" Text="新增空白訂單" 
            onclick="AddNewCont_Click"/>
    <asp:Button ID="BackBtn" runat="server" Text="回查詢畫面" onclick="BackBtn_Click" />
    </td>
</tr>
<tr>
    <td align="center" colspan="2">
        <asp:Label ID="lblCaption" runat="server" ForeColor="#C00000"></asp:Label>
    </td>
</tr>
</table>
<span class="stripeMe">
<asp:GridView ID="PCGV2" runat="server" AutoGenerateColumns="false" Width="99%" 
        CssClass="font_blacklink font_size13" onrowdatabound="PCGV2_RowDataBound" 
        onsorting="PCGV2_Sorting" AllowSorting="true">
<Columns>
<%--    <asp:TemplateField HeaderStyle-Width="5%">
    <ItemTemplate>
        <asp:Button ID="Button3" runat="server" Text="註銷" OnClick="delete_Click" />
    </ItemTemplate>
    </asp:TemplateField>--%>
    <asp:BoundField DataField="od_otp1seq" HeaderText="訂單流水號▲" SortExpression="od_otp1seq" HeaderStyle-ForeColor="White"/>
    <asp:BoundField DataField="otp_otp1nm" HeaderText="訂購類別一" />
    <asp:BoundField DataField="otp_otp2nm" HeaderText="訂購類別二" />
    <asp:BoundField DataField="obtp_obtpnm" HeaderText="書籍類別" />
    <asp:BoundField DataField="begin_end" HeaderText="訂閱起迄" />
    <asp:BoundField DataField="or_nm" HeaderText="收件人" />
    <asp:TemplateField HeaderStyle-Width="7%">
    <ItemTemplate>
        <asp:HyperLink ID="HyperLink1" runat="server">詳細資料</asp:HyperLink>
    </ItemTemplate>
    </asp:TemplateField>
<%--    <asp:TemplateField HeaderStyle-Width="5%">
    <ItemTemplate>
        <asp:Button ID="Button2" runat="server" Text="修改" OnClick="Edit_Click" />
    </ItemTemplate>
    </asp:TemplateField>--%>
    <asp:TemplateField HeaderStyle-Width="5%">
    <ItemTemplate>
        <asp:Button ID="Button1" runat="server" Text="新增" OnClick="Add_Click" />
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
