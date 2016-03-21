<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RemailFM.aspx.cs" Inherits="mclpub.Sys.RemailFM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;系統管理 / 雜誌叢書補書 /補書資料修改</span>
    <span class="stripeMe">
        <table cellspacing="0" cellpadding="4" width="100%">
            <tr>
                <th colspan="4">
                    訂單資料
                </th>
            </tr>
            <tr>
                <td align="right">
                    訂單編號：
                </td>
                <td>
                    <asp:Label ID="lblNo" ForeColor="Maroon" runat="server"></asp:Label>
                </td>
                <td align="right">
                    訂購類別：
                </td>
                <td>
                    <asp:Label ID="lblType1" ForeColor="Maroon" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th colspan="4">
                    訂戶資料
                </th>
            </tr>
            <tr>
                <td align="right">
                    訂戶編號：
                </td>
                <td>
                    <asp:Label ID="lblCustNo" ForeColor="Maroon" runat="server"></asp:Label>
                </td>
                <td align="right">
                    姓名：
                </td>
                <td>
                    <asp:Label ID="lblCustName" ForeColor="Maroon" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    公司名稱：
                </td>
                <td colspan="3">
                    <asp:Label ID="lblCoName" ForeColor="Maroon" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th colspan="4">
                    收件人資料
                </th>
            </tr>
            <tr>
                <td align="right">
                    收件人：
                </td>
                <td colspan="3">
                    <asp:Label ID="lblRecName" ForeColor="Maroon" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    地址：
                </td>
                <td style="width: 192px; height: 1px" colspan="3">
                    <asp:Label ID="lblRecAddr" ForeColor="Maroon" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th colspan="4">
                    補書資料
                </th>
            </tr>
            <tr>
                <td align="right">
                    補書序號：
                </td>
                <td>
                    <asp:Label ID="lblRemailSeq" runat="server" ForeColor="Maroon"></asp:Label>
                </td>
                <td align="right">
                    訂購起迄：
                </td>
                <td>
                    <asp:Label ID="lblsdate" runat="server" ForeColor="Maroon"></asp:Label>
                    ~<asp:Label ID="lbledate" runat="server" ForeColor="Maroon"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    補書日期：</td>
                <td colspan="3">
                    <asp:TextBox ID="tbxRemailDate" runat="server" Enabled="False" Width="82px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    補書內容：
                </td>
                <td colspan="3">
                    <textarea id="textarea1" style="width: 445px; height: 77px" name="textarea1" rows="4"
                        cols="53" runat="server"></textarea>
                </td>
            </tr>
            <tr>
                <td align="right">
                    寄書狀態：
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlSendFlag" runat="server">
                        <asp:ListItem Value="Y" Selected="True">可寄出</asp:ListItem>
                        <asp:ListItem Value="N">目前暫時無法寄出</asp:ListItem>
                        <asp:ListItem Value="D">不處理</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </span>
    <div align="right">
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <asp:Button ID="btnUpdate" runat="server" onclick="btnUpdate_Click" 
            Text="修改補書資料" />
        <asp:Button ID="btnCancel" runat="server" Text="取消回首頁" OnClick="btnCancel_Click">
        </asp:Button>
    </div>
</asp:Content>
