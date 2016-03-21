<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="bookp.aspx.cs" Inherits="mclpub.Sys.bookp" %>
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
            var ddlbkp_bkcd = $('#<% =ddlbkp_bkcd.ClientID%> option:selected');
            var bkp_date = $('#<% =bkp_date.ClientID%>');
            var bkp_pno = $('#<% =bkp_pno.ClientID%>');
            if (ddlbkp_bkcd.val() == "") {
                alert("書籍名稱為必填欄位!");
                return;
            }
            if (bkp_date.val() == "") {
                alert("書籍出版年月為必填欄位!");
                return;
            }
            if (bkp_date.val().length < 6) {
                alert("書籍出版年月格式錯誤!");
                return;
            }
            if (bkp_pno.val() == "") {
                alert("書籍期別為必填欄位!");
                return;
            }

            $.post("bookpJudge.aspx", { ddlbkp_bkcd: ddlbkp_bkcd.val(), bkp_date: bkp_date.val(), bkp_pno: bkp_pno.val() }, function (result) {
                if (result == "No!") {
                    alert('此筆資料已經存在!');
                }
                if (result == "Ok!") {
                    alert('新增成功!');
                    window.location.href = "bookp.aspx";
                }
                if (result == "Error!") {
                    alert('資料錯誤!');
                }
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;系統管理 / 書籍期別資料維護</span>
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
            AllowPaging="true" PagerSettings-Visible="false" AllowSorting="true" OnSorting="GVEdit_Sorting">
            <Columns>
                <asp:BoundField DataField="bkp_bkpid" HeaderText="ID" />
                <asp:TemplateField HeaderText="書籍名稱">
                    <ItemTemplate>
                        <asp:DropDownList ID="TextBoxbk_nm" runat="server" Visible="false" >
                        </asp:DropDownList>
                        <asp:Label ID="Labelbk_nm" runat="server" Text='<%# Bind("bk_nm") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="書籍出版年月▼" SortExpression="bkp_date" HeaderStyle-ForeColor="White">
                    <ItemTemplate>
                        <asp:Label ID="Labelbkp_date" runat="server" Text='<%# Bind("bkp_date") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxbkp_date" runat="server" Width="80px" Visible="false"  Text='<%# Bind("bkp_date") %>' MaxLength="6" onkeyup="return ValidateNumber($(this),value)">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="書籍期別">
                    <ItemTemplate>
                        <asp:Label ID="Labelbkp_pno" runat="server" Text='<%# Bind("bkp_pno") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxbkp_pno" runat="server" Width="80px" Visible="false"  Text='<%# Bind("bkp_pno") %>' MaxLength="4" onkeyup="return ValidateNumber($(this),value)">
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
    <div id="dialog" style="text-align: left; display: none;" title="新增 書籍期別資料">
        <span class="stripeMe">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <font color="#ff0000">* </font>書籍名稱:
                    </td>
                    <td>
                        <asp:dropdownlist id="ddlbkp_bkcd" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="#ff0000">* </font> 書籍出版年月:
                    </td>
                    <td>
                        <asp:textbox id="bkp_date" runat="server" Width="70px" MaxLength="6" onkeyup="return ValidateNumber($(this),value)"></asp:textbox>
                        <FONT color="#696969">(範例: 200201)</FONT>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="#ff0000">* </font>書籍期別:
                    </td>
                    <td>
                        <asp:textbox id="bkp_pno" runat="server" Width="50px" MaxLength="4" onkeyup="return ValidateNumber($(this),value)"></asp:textbox>
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
