<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="pgno.aspx.cs" Inherits="mclpub.Layout.pgno" %>
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
            var ddlBkcd = $('#<% =ddlBkcd.ClientID%> option:selected');
            var tbxStartPageNo = $('#<% =tbxStartPageNo.ClientID%>');
            $.post("pgnoJudge.aspx", { ddlBkcd: ddlBkcd.val(), tbxStartPageNo: tbxStartPageNo.val() }, function (result) {
                if (result == "No!") {
                    alert('很抱歉' + ddlBkcd.text() + ' 已有起啟內碼資料, 新增失敗!\n請重選書籍類別 或 放棄新增!');
                }
                if (result == "Ok!") {
                    alert('新增成功!');
                    window.location.href = "pgno.aspx";
                }
                if (result == "Error!") {
                    alert('資料錯誤!');
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 平面廣告落版處理 / 相關維護區
        / 內頁起始頁碼</span> <span class="stripeMe">
        </span>
    <span class="font_size13 font_bold font_gray">
        <ol>
            <span class="font_red">註：為避免發生錯誤，請勿任何"刪除"！ </span><br />
        </ol>
    </span>
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
                <asp:BoundField DataField="pg_pgid" HeaderText="ID" />
                <asp:TemplateField HeaderText="書籍類別名稱">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("bk_nm") %>'></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" Visible="false" Text='<%# Bind("bk_nm") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="內頁起始頁碼">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("pg_startpgno") %>'></asp:Label>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("pg_startpgno") %>' Visible="false"
                            onkeyup="return ValidateNumber($(this),value)"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="pg_bkcd" HeaderText="書籍類別代碼" />
                <asp:TemplateField HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
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
    <div id="dialog" style="text-align: left; display: none;" title="新增內頁起始頁碼">
        <span class="stripeMe">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <font color="#ff0000">*</font>
                        新增內頁起始頁碼
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBkcd" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="#ff0000">*</font>
                        內頁起始頁碼
                    </td>
                    <td>            
                        <asp:TextBox ID="tbxStartPageNo" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
                        <font color="#8b4513">(預設值為 4)</font>
                        <asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" Display="Dynamic"
                            ControlToValidate="tbxStartPageNo" ErrorMessage="起始頁碼為必填欄位!"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </span>
        <div style="text-align: right">
            <input id="Button1" type="button" value="確定新增" class="btn_mouseout" onmouseover="this.className='btn_mouseover'"
                onmouseout="this.className='btn_mouseout'" onclick="submitBtn()" />
        </div>
    </div>
</asp:Content>
