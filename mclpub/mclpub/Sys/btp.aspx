<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="btp.aspx.cs" Inherits="mclpub.Sys.btp" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function ValidateNumber(e, pnumber) {
            if (!/^\d+$/.test(pnumber)) {
                $(e).val(/^\d+/.exec($(e).val()));
            }
            return false;
        }

        function submitBtn() {
            var btp_btpcd = $('#<% =TextBoxbtp_btpcd.ClientID%>');
            var btp_nm = $('#<% =TextBoxbtp_nm.ClientID%>');

            if (btp_btpcd.val() == "") {
                alert("營業代碼為必填欄位!");
                return;
            }
            if (btp_nm.val() == "") {
                alert("營業代碼名稱為必填欄位!");
                return;
            }

            $.post("btpJudge.aspx", { btp_btpcd: btp_btpcd.val(), btp_nm: btp_nm.val() }, function (result) {
                if (result == "No!") {
                    alert('此筆資料已經存在!');
                }
                if (result == "Ok!") {
                    alert('新增成功!');
                    window.location.href = "btp.aspx";
                }
                if (result == "Error!") {
                    alert('資料錯誤!');
                }
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;系統管理 / 營業代碼資料維護</span>
    <table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
            </td>
            <td align="right">
        <input id="DialogAddBtn" type="button" value="新增資料" class="btn_mouseout" onmouseover="this.className='btn_mouseover'"
            onmouseout="this.className='btn_mouseout'" /></td>
        </tr>
    </table>
    <span class="stripeMe">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" PageSize="10"
            CssClass="font_blacklink font_size13" Width="100%" OnRowDataBound="GridView1_RowDataBound"
            AllowPaging="true" PagerSettings-Visible="false">
            <Columns>
                <asp:BoundField DataField="btp_btpid" HeaderText="ID" />
                <asp:TemplateField HeaderText="營業代碼">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxbtp_btpcd" runat="server" MaxLength="2" Width="80px" Text='<%# Bind("btp_btpcd") %>' Visible="false" onkeyup="return ValidateNumber($(this),value)"></asp:TextBox>
                        <asp:Label ID="Labelbtp_btpcd" runat="server" Text='<%# Bind("btp_btpcd") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="營業代碼名稱">
                    <ItemTemplate>
                        <asp:Label ID="Labelbtp_nm" runat="server" Text='<%# Bind("btp_nm") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxbtp_nm" runat="server" Width="80px" Visible="false"  Text='<%# Bind("btp_nm") %>' MaxLength="30">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="修改" OnClick="btnEdit_Click" CausesValidation="false" />
                        <asp:Button ID="SubBtn" runat="server" Text="確定" OnClick="SubBtn_Click" CausesValidation="false"
                            Visible="false" />
                        <asp:Button ID="CancelBtn" runat="server" Text="取消" OnClick="CancelBtn_Click" CausesValidation="false"
                            Visible="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="15%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnDel" runat="server" Text="刪除" OnClick="btnDel_Click" CausesValidation="false"
                            OnClientClick="javascript:return confirm('確定刪除?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle HorizontalAlign="Center" />
            <EmptyDataTemplate>
                查詢無結果
            </EmptyDataTemplate>
        </asp:GridView>
    </span>
    <div class="pager font_size13" style="width: 100%">
        <uc3:ucpager id="UCPager1" runat="server" />
    </div>
    <div id="dialog" style="text-align: left; display: none;" title="新增 營業代碼資料維護">
        <span class="stripeMe">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <font color="#ff0000">* </font>營業代碼:
                    </td>                
                    <td>
                        <asp:TextBox ID="TextBoxbtp_btpcd" runat="server" MaxLength="2" Width="35px" onkeyup="return ValidateNumber($(this),value)"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="#ff0000">* </font> 營業代碼名稱:
                    </td>
                    <td>
                        <asp:textbox id="TextBoxbtp_nm" runat="server" MaxLength="30"></asp:textbox>
                    </td>
                </tr>
            </table>
        </span>
        <div style="text-align: right">
            <input id="Button1" type="button" value="新增資料" class="btn_mouseout" onmouseover="this.className='btn_mouseover'"
                onmouseout="this.className='btn_mouseout'" onclick="submitBtn()" />
        </div>
    </div>
</asp:Content>
