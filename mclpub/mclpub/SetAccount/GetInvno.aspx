<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="GetInvno.aspx.cs" Inherits="mclpub.SetAccount.GetInvno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 發票號碼取回</span>
<br />
<asp:button id="btnGetInvno" runat="server" Text="取回發票號碼" 
        onclick="btnGetInvno_Click"></asp:button>
<br />
<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label>
</asp:Content>
