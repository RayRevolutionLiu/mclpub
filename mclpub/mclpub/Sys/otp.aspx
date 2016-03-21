<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="otp.aspx.cs" Inherits="mclpub.Sys.otp"  MaintainScrollPositionOnPostback="true"%>
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
            var otp_otp1cd = $('#<% =ddlotp_otp1cd.ClientID%> option:selected');
            var otp_otp2cd = $('#<% =TextBoxotp_otp2cd.ClientID%>');
            var otp_otp2nm = $('#<% =TextBoxotp_otp2nm.ClientID%>');

            if (otp_otp1cd.val() == "") {
                alert("訂購類別1名稱為必填欄位!");
                return;
            }
            if (otp_otp2cd.val() == "") {
                alert("訂購類別2代碼為必填欄位!");
                return;
            }
            if (otp_otp2nm.val() == "") {
                alert("訂購類別2名稱為必填欄位!");
                return;
            }

            $.post("otpJudge.aspx", { otp_otp1cd: otp_otp1cd.val(), otp_otp1nm: otp_otp1cd.text(), otp_otp2cd: otp_otp2cd.val(), otp_otp2nm: otp_otp2nm.val() }, function (result) {
                if (result == "No!") {
                    alert('此筆資料已經存在!');
                }
                if (result == "Ok!") {
                    alert('新增成功!');
                    window.location.href = "otp.aspx";
                }
                if (result == "Error!") {
                    alert('資料錯誤!');
                }
            });
        }

        function onddlChange() {
            //            var tranValue = $('#<% =ddlotp_otp1cd.ClientID%> option:selected');
            //            $.post("HandlerOtp.ashx", { ddlotp_otp1cd: tranValue.val() }, function (result) {
            //                if (result == "no") {
            //                    alert('參數錯誤!');
            //                    return;
            //                }
            //                else {
            //                    $('#<% =TextBoxotp_otp2cd.ClientID%>')[0].value = name;
            //                }
            //            });
            var tranValue = $('#<% =ddlotp_otp1cd.ClientID%> option:selected');
            $.ajax({
                type: "post",
                url: "HandlerOtp.ashx",
                data: 'ddlotp_otp1cd=' + tranValue.val(),
                success: function (name) {
                    $('#<% =TextBoxotp_otp2cd.ClientID%>')[0].value = name;
                },
                error: function () { alert('fail!!'); }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;系統管理 / 訂購類別檔資料維護</span>
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
                <asp:BoundField DataField="otp_otpid" HeaderText="ID" />
                <asp:BoundField DataField="otp_otp1cd" HeaderText="訂購類別1代碼" />
                <asp:TemplateField HeaderText="訂購類別1名稱">
                    <ItemTemplate>
                        <asp:Label ID="Labelotp_otp1nm" runat="server" Text='<%# Bind("otp_otp1nm") %>'></asp:Label>
                        <asp:DropDownList ID="ddlotp_otp1nm" runat="server" Visible="false">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="訂購類別2代碼">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBoxotp_otp2cd" runat="server" MaxLength="2" Width="80px" Text='<%# Bind("otp_otp2cd") %>' Visible="false" onkeyup="return ValidateNumber($(this),value)"></asp:TextBox>
                        <asp:Label ID="Labelotp_otp2cd" runat="server" Text='<%# Bind("otp_otp2cd") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="訂購類別2名稱">
                    <ItemTemplate>
                        <asp:Label ID="Labelotp_otp2nm" runat="server" Text='<%# Bind("otp_otp2nm") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxotp_otp2nm" runat="server" Width="80px" Visible="false"  Text='<%# Bind("otp_otp2nm") %>' MaxLength="20">
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
    <div id="dialog" style="text-align: left; display: none;" title="新增 訂購類別檔資料">
        <span class="stripeMe">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <font color="#ff0000">* </font>訂購類別1名稱:
                    </td>                
                    <td>
						<asp:DropDownList id="ddlotp_otp1cd" runat="server" onchange="onddlChange();" >
						</asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="#ff0000">* </font> 訂購類別2代碼:
                    </td>
                    <td>
                        <asp:textbox id="TextBoxotp_otp2cd" runat="server" MaxLength="2" Width="20px"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="#ff0000">* </font> 訂購類別2代碼:
                    </td>
                    <td>
                        <asp:textbox id="TextBoxotp_otp2nm" runat="server" MaxLength="20" Width="150px"></asp:textbox>
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
