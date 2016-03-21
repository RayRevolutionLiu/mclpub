<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="adlayout.aspx.cs" Inherits="mclpub.Layout.adlayout" %>
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
            var ltp_ltpcd = $('#<% =ltp_ltpcd.ClientID%>');
            var ltp_nm = $('#<% =ltp_nm.ClientID%>');
            if (ltp_ltpcd.val() == "") {
                alert("廣告版面代碼為必填欄位!");
                return;
            }
            if (ltp_nm.val() == "") {
                alert("廣告版面名稱為必填欄位!");
                return;
            }

            $.post("adlayoutJudge.aspx", { ltp_ltpcd: ltp_ltpcd.val(), ltp_nm: ltp_nm.val() }, function (result) {
                if (result == "No!") {
                    alert('此筆資料已經存在!');
                }
                if (result == "Ok!") {
                    alert('新增成功!');
                    window.location.href = "adlayout.aspx";
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
        / 廣告版面</span> <span class="stripeMe"></span>
        <span class="font_size13 font_bold font_gray">
            <ol>
                <span class="font_red">註：為避免舊資料讀取錯誤，若該筆已被使用，將不允許修改/刪除！ </span><br />
                <span class="font_red">註：若要新增特殊版面，廣告版面代碼需小於50！ </span>
                <br />
            </ol>
        </span>
    <table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
            </td>
            <td align="right">
                <input id="DialogAddBtn" type="button" value="新增資料" class="btn_mouseout" onmouseover="this.className='btn_mouseover'"
                    onmouseout="this.className='btn_mouseout'" />
            </td>
        </tr>
    </table>
    <span class="stripeMe">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" PageSize="10"
            CssClass="font_blacklink font_size13" Width="100%" OnRowDataBound="GridView1_RowDataBound"
            AllowPaging="true" PagerSettings-Visible="false">
            <Columns>
                <asp:BoundField DataField="ltp_ltpid" HeaderText="ID" />
                <asp:TemplateField HeaderText="廣告版面代碼">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ltp_ltpcd") %>'></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" Visible="false" Text='<%# Bind("ltp_ltpcd") %>'
                            onkeyup="return ValidateNumber($(this),value)" MaxLength="2"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="廣告版面名稱">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ltp_nm") %>'></asp:Label>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ltp_nm") %>' Visible="false"
                            MaxLength="10"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
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
    <div id="dialog" style="text-align: left; display: none;" title="新增廣告版面">
        <span class="stripeMe">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <font color="#ff0000">*</font> 廣告版面代碼
                    </td>
                    <td>
                        <asp:TextBox ID="ltp_ltpcd" runat="server" MaxLength="2" Width="25px" onkeyup="return ValidateNumber($(this),value)"></asp:TextBox>
                        <font color="#8b4513">請輸入 2 位數字!</font>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="#ff0000">*</font> 廣告版面名稱
                    </td>
                    <td>
                        <asp:TextBox ID="ltp_nm" runat="server" MaxLength="10" Width="142px"></asp:TextBox>
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
