<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RptAdrQuery.aspx.cs" Inherits="mclpub.Layout.RptAdrQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 網路廣告落版處理 / 廣告落版統計表</span>
    <span class="stripeMe">
        <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tr>
                <th colspan="3">
                    查詢條件
                </th>
            </tr>
            <tr>
                <td align="right" width="120" class="font_bold">
                    廣告日區間：
                </td>
                <td>
                    <asp:TextBox ID="tbxSDate" runat="server" Width="100px" CssClass="UniqueDate"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSDate" runat="server" ControlToValidate="tbxSDate"
                        Display="Dynamic" ErrorMessage="不可空白"></asp:RequiredFieldValidator>
                        ～
                        <asp:TextBox ID="tbxEDate" runat="server" Width="100px" CssClass="UniqueDate"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEDate" runat="server" ControlToValidate="tbxEDate"
                            Display="Dynamic" ErrorMessage="不可空白"></asp:RequiredFieldValidator>
                    &nbsp;
                    <asp:Label ID="lblyyyymmdd" runat="server" CssClass="ImportantLabel" ForeColor="#C00000">(yyyy/mm/dd)</asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" width="120" class="font_bold">
                    廠商名稱：
                </td>
                <td>
                    <asp:TextBox ID="tbxMfrName" runat="server" Width="184px" MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" width="120" class="font_bold">
                    承辦業務員：
                </td>
                <td>
                    <asp:DropDownList ID="ddlEmpData" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </span>
    <table border="0" width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <td align="right">
                <asp:Button ID="btnPrintBill" runat="server" Text="產生廣告落版統計表" OnClick="btnPrintBill_Click">
                </asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>
