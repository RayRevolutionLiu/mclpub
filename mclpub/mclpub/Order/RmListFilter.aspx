<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RmListFilter.aspx.cs" Inherits="mclpub.Sys.RmListFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;訂戶管理 / 雜誌叢書訂單處理 / 補書清單列印</span>
    <span class="stripeMe">
        <table cellspacing="0" cellpadding="4" width="100%">
            <tr>
                <th colspan="2">
                    查詢條件</th>
            </tr>
            <tr>
                <td align="right" style="width: 15%" class="font_bold">
                    寄書狀況：
                </td>
                <td>
                    <asp:DropDownList ID="ddlSent" runat="server" AutoPostBack="true"
                        onselectedindexchanged="ddlSent_SelectedIndexChanged">
                        <asp:ListItem Value="C">已寄出</asp:ListItem>
                        <asp:ListItem Value="N">尚未寄出</asp:ListItem>
                        <asp:ListItem Value="ALL">全部</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="font_bold">
                    補書日期區間：</td>
                <td class="style1">
                    <asp:TextBox ID="tbxRemailDate1" runat="server" Width="82px" CssClass="UniqueDate"></asp:TextBox>
                    ~<asp:TextBox ID="tbxRemailDate2" runat="server" Width="84px" CssClass="UniqueDate"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="font_bold">
                    訂購日期區間：</td>
                <td>
                    <asp:TextBox ID="tbxOrderDate1" runat="server" Width="82px" CssClass="UniqueDate"></asp:TextBox>
                    ~<asp:TextBox ID="tbxOrderDate2" runat="server" Width="84px" CssClass="UniqueDate"></asp:TextBox>
                </td>
            </tr>
            </table>
    </span>
    <div align="right">
        <asp:Button ID="btnPrint" runat="server" Text="列印報表" onclick="btnPrint_Click" />
    </div>
    <span class="font_size13 font_bold font_gray">
        <ol>
            <li>請輸入任一關鍵詞然後按下查詢</li>
            <li>若寄書狀況選擇<span class="font_darkblue">全部</span>以及<span class="font_darkblue">尚未寄出</span>則不可輸入補書日期區間</li>
        </ol>
    </span>
</asp:Content>
