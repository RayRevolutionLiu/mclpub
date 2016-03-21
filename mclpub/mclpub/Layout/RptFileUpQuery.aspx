<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RptFileUpQuery.aspx.cs" Inherits="mclpub.Layout.RptFileUpQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 網路廣告落版處理 / 美編上稿清單</span>
    <span class="stripeMe">
        <table border="0" width="100%" cellspacing="0" cellpadding="0">
            <tr>
                <th colspan="2">
                    查詢條件
                </th>
            </tr>
            <tr>
                <td align="right" width="140" class="font_bold">
                    <font color="#ff0000">*</font>廣告日期區間：
                </td>
                <td>
                    <asp:TextBox ID="tbxSDate" runat="server" Width="100px" CssClass="UniqueDate"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSDate" runat="server" ControlToValidate="tbxSDate"
                        Display="Dynamic" ErrorMessage="起始日期不可空白"></asp:RequiredFieldValidator>
                    ～<asp:TextBox ID="tbxEDate" runat="server" Width="100px" CssClass="UniqueDate"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEDate" runat="server" ControlToValidate="tbxEDate"
                        Display="Dynamic" ErrorMessage="結束日期不可空白"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblyyyymmdd" runat="server"  ForeColor="#C00000">(yyyy/mm/dd)</asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" width="140" class="font_bold">
                    <span class="stripeMe">承辦業務員：</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlEmpData" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" width="140" class="font_bold">
                    廣告位置<span class="stripeMe">：</span>
                </td>
                <td>
                    <asp:DropDownList ID="ddlKeyword" runat="server">
                        <asp:ListItem Selected="True" Value="00">請選擇</asp:ListItem>
                        <asp:ListItem Value="h1">右一</asp:ListItem>
                        <asp:ListItem Value="h2">右二</asp:ListItem>
                        <asp:ListItem Value="h3">右三</asp:ListItem>
                        <asp:ListItem Value="h4">右四</asp:ListItem>
                        <asp:ListItem Value="w1">右文一</asp:ListItem>
                        <asp:ListItem Value="w2">右文二</asp:ListItem>
                        <asp:ListItem Value="w3">右文三</asp:ListItem>
                        <asp:ListItem Value="w4">右文四</asp:ListItem>
                        <asp:ListItem Value="w5">右文五</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            </table>
    </span>
    <table border="0" width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <td align="right">
                <asp:Button ID="btnPrint" runat="server" onclick="btnPrint_Click" 
                    Text="產生美編上稿清單" />
            </td>
        </tr>
    </table>
</asp:Content>
