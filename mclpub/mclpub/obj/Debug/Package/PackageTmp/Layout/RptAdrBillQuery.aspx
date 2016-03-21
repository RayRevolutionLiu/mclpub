<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RptAdrBillQuery.aspx.cs" Inherits="mclpub.Layout.RptAdrBillQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 網路廣告落版處理 / 廣告落版單</span>
    <span class="stripeMe">
        <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <th colspan="3">
                    查詢條件
                </th>
            </tr>
            <tr>
                <td align="right" width="120" class="font_bold">
                    廠商名稱：
                </td>
                <td>
                    <asp:TextBox ID="tbxMfrName" runat="server" Width="184px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="120" class="font_bold">
                    廣告日區間：
                </td>
                <td>
                    <asp:TextBox ID="tbxSDate" runat="server" Width="100px" CssClass="UniqueDate"></asp:TextBox>～<asp:TextBox ID="tbxEDate" runat="server" Width="100px" CssClass="UniqueDate"></asp:TextBox>
                    &nbsp;
                        <asp:Label ID="lblyyyymmdd" runat="server" CssClass="ImportantLabel" ForeColor="#C00000">(yyyy/mm/dd)</asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" width="120" class="font_bold">
                    承辦業務員：
                </td>
                <td>
                    <asp:DropDownList
                        ID="ddlEmpData" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" width="120" class="font_bold">
                    廣告位置：
                </td>
                <td>
                    <asp:DropDownList ID="ddlKeyword" runat="server">
                        <asp:ListItem Value="00" Selected="True">請選擇</asp:ListItem>
                        <asp:ListItem Value="h0">正中</asp:ListItem>
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
                <asp:Button ID="btnPrintBill" runat="server" Text="產生廣告落版單" 
                    onclick="btnPrintBill_Click"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
