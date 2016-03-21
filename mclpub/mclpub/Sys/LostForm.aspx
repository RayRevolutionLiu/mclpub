<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LostForm.aspx.cs" Inherits="mclpub.Sys.LostForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;系統管理 / 雜誌叢書缺書 /缺書登錄</span>
    <span class="stripeMe">
        <table cellspacing="0" cellpadding="4" width="100%">
            <tr>
                <th colspan="4">
                    訂單資料
                </th>
            </tr>
            <tr>
                <td align="right" class="font_bold">
                    訂單編號：
                </td>
                <td>
                    <asp:Label ID="lblNo" ForeColor="Maroon" runat="server"></asp:Label>
                </td>
                <td align="right" class="font_bold">
                    訂購類別：
                </td>
                <td>
                    <asp:Label ID="lblType1" ForeColor="Maroon" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th colspan="4" class="font_bold">
                    訂戶資料
                </th>
            </tr>
            <tr>
                <td align="right" class="font_bold">
                    訂戶編號：
                </td>
                <td>
                    <asp:Label ID="lblCustNo" ForeColor="Maroon" runat="server"></asp:Label>
                </td>
                <td align="right" class="font_bold">
                    姓名：
                </td>
                <td>
                    <asp:Label ID="lblCustName" ForeColor="Maroon" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="font_bold">
                    公司名稱：
                </td>
                <td colspan="3">
                    <asp:Label ID="lblCoName" ForeColor="Maroon" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th colspan="4" class="font_bold">
                    收件人資料
                </th>
            </tr>
            <tr>
                <td align="right" class="font_bold">
                    收件人：
                </td>
                <td colspan="3">
                    <asp:Label ID="lblRecName" ForeColor="Maroon" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="font_bold">
                    地址：
                </td>
                <td style="width: 192px; height: 1px" colspan="3">
                    <asp:Label ID="lblRecAddr" ForeColor="Maroon" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th colspan="4" class="font_bold">
                    補書資料
                </th>
            </tr>
            <tr>
                <td align="right" class="font_bold">
                    缺書序號：
                </td>
                <td>
                    <asp:Label ID="lblRemailSeq" runat="server" ForeColor="Maroon"></asp:Label>
                </td>
                <td align="right" class="font_bold">
                    訂購起迄：
                </td>
                <td>
                    <asp:Label ID="lblsdate" runat="server" ForeColor="Maroon"></asp:Label>
                    ~<asp:Label ID="lbledate" runat="server" ForeColor="Maroon"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="font_bold">
                    補書內容：
                </td>
                <td colspan="3">
                    <textarea id="textarea1" style="width: 445px; height: 77px" name="textarea1" rows="4"
                        cols="53" runat="server"></textarea>
                </td>
            </tr>
            <tr>
                <td align="right" class="font_bold">
                    缺書原因：</td>
                <td colspan="3">
                    <textarea id="textarea2" style="width: 445px; height: 77px" name="textarea2" rows="4"
                        cols="53" runat="server"></textarea></td>
            </tr>
            <tr>
                <td align="right" class="font_bold">
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
        <asp:Button ID="btnModify" runat="server" Text="資料錯誤,修改訂單"  />
        <asp:Button ID="btnOK" runat="server" Text="確定新增缺書資料" OnClick="btnOK_Click"></asp:Button>
        <asp:Button ID="btnCancel" runat="server" Text="取消回首頁" OnClick="btnCancel_Click">
        </asp:Button>
    </div>
</asp:Content>
