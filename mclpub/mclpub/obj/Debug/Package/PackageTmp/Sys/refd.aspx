<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="refd.aspx.cs" Inherits="mclpub.Sys.refd" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script>
       function submitBtn() {
           var ddlrd_syscd = $('#<% =ddlrd_syscd.ClientID%> option:selected');
           var ddlrd_projno = $('#<% =ddlrd_projno.ClientID%> option:selected');
           var rd_costctr = $('#<% =rd_costctr.ClientID%>');
           var rd_accdcr = $('#<% =rd_accdcr.ClientID%>');
           var rd_descr = $('#<% =rd_descr.ClientID%>');

           if (ddlrd_syscd.val() == "") {
               alert("系統代碼名稱為必填欄位!");
               return;
           }
           if (ddlrd_projno.val() == "") {
               alert("計畫代號為必填欄位!");
               return;
           }


           $.post("refd.ashx", {
             ddlrd_syscd: ddlrd_syscd.val()
           , ddlrd_projno: ddlrd_projno.val()
           , rd_costctr: rd_costctr.val()
           , rd_accdcr: rd_accdcr.val()
           , rd_descr: rd_descr.val()
           }, function (result) {
               if (result == "Ok!") {
                   alert('新增成功!');
                   window.location.href = "refd.aspx";
               }
               if (result == "No!") {
                   alert('系統代碼重複!');
               }
               if (result == "Error!") {
                   alert('資料錯誤!');
               }
           });
       }
    </script>
    <script>
        function ValidateNumber(e, pnumber) {
            var reg = /^([a-zA-Z0-9]|[\uFE30-\uFFA0|\/:,;])*$/gi;
            if (!reg.test(pnumber)) {
                alert("此欄位僅可輸入英數字及簡單的符號");
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;系統管理 / 轉 SAP 傳票摘要檔</span>
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
            CssClass="font_blacklink font_size12" Width="100%" OnRowDataBound="GridView1_RowDataBound"
            AllowPaging="true" PagerSettings-Visible="false">
            <Columns>
                <asp:BoundField DataField="rd_rdid" HeaderText="ID" />
                <asp:TemplateField HeaderText="系統代碼名稱">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownListsys_nm" runat="server" Visible="false"></asp:DropDownList>
                        <asp:Label ID="Labelsys_nm" runat="server" Text='<%# Bind("sys_nm") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="計劃代號">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownListrd_projno" runat="server" Visible="false"></asp:DropDownList>
                        <asp:Label ID="Labelrd_projno" runat="server" Text='<%# Bind("rd_projno") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="成本中心">
                    <ItemTemplate>
                        <asp:Label ID="Labelrd_costctr" runat="server" Text='<%# Bind("rd_costctr") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxrd_costctr" runat="server" Width="67px" Visible="false"  Text='<%# Bind("rd_costctr") %>' MaxLength="7" onkeyup="return ValidateNumber($(this),value)">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="傳票貸方總帳科目">
                    <ItemTemplate>
                        <asp:Label ID="Labelrd_accdcr" runat="server" Text='<%# Bind("rd_accdcr") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxrd_accdcr" runat="server" Width="54px" Visible="false"  Text='<%# Bind("rd_accdcr") %>' MaxLength="7" onkeyup="return ValidateNumber($(this),value)">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="傳票摘要">
                    <ItemTemplate>
                        <asp:Label ID="Labelrd_descr" runat="server" Text='<%# Bind("rd_descr") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxrd_descr" runat="server" Width="270px" Visible="false"  Text='<%# Bind("rd_descr") %>' MaxLength="20">
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
                <asp:TemplateField HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
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
    <div id="dialog" style="text-align: left; display: none;" title="新增 轉 SAP 傳票摘要檔">
        <span class="stripeMe">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <font color="#ff0000">* </font>系統代碼名稱:
                    </td>
                    <td>
                        <asp:dropdownlist id="ddlrd_syscd" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="#ff0000">* </font>計劃代號:
                    </td>
                    <td>
                        <asp:dropdownlist id="ddlrd_projno" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        成本中心:
                    </td>
                    <td>
                        <asp:textbox id="rd_costctr" runat="server" Width="67px" MaxLength="7" onkeyup="return ValidateNumber($(this),value)"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        傳票貸方總帳科目:
                    </td>
                    <td>
                        <asp:textbox id="rd_accdcr" runat="server" MaxLength="7" Width="54px" onkeyup="return ValidateNumber($(this),value)"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        傳票摘要:
                    </td>
                    <td>
                        <asp:textbox id="rd_descr" runat="server" MaxLength="20" Width="170px"></asp:textbox>
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
