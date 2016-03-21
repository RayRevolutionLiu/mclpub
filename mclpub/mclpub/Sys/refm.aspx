<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="refm.aspx.cs" Inherits="mclpub.Sys.refm" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script>
       function submitBtn() {
           var ddlrm_syscd = $('#<% =ddlrm_syscd.ClientID%> option:selected');
           var rm_remark = $('#<% =rm_remark.ClientID%>');
           var rm_deptcd = $('#<% =rm_deptcd.ClientID%>');
           var rm_accddr = $('#<% =rm_accddr.ClientID%>');
           var rm_idescr = $('#<% =rm_idescr.ClientID%>');
           var rm_iunit = $('#<% =rm_iunit.ClientID%>');
           var rm_iremark = $('#<% =rm_iremark.ClientID%>');

           if (ddlrm_syscd.val() == "") {
               alert("系統代碼名稱為必填欄位!");
               return;
           }
           if (rm_remark.val() == "") {
               alert("發票事由為必填欄位!");
               return;
           }


           $.post("refm.ashx", {
               ddlrm_syscd: ddlrm_syscd.val()
           , rm_remark: rm_remark.val()
           , rm_deptcd: rm_deptcd.val()
           , rm_accddr: rm_accddr.val()
           , rm_idescr: rm_idescr.val()
           , rm_iunit: rm_iunit.val()
           , rm_iremark: rm_iremark.val()
           }, function (result) {
               if (result == "Ok!") {
                   alert('新增成功!');
                   window.location.href = "refm.aspx";
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;系統管理 / 轉 SAP 發票摘要檔</span>
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
                <asp:BoundField DataField="rm_rmid" HeaderText="ID" />
                <asp:TemplateField HeaderText="系統代碼名稱">
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownListsys_nm" runat="server" Visible="false"></asp:DropDownList>
                        <asp:Label ID="Labelsys_nm" runat="server" Text='<%# Bind("sys_nm") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="發票事由">
                    <ItemTemplate>
                        <asp:Label ID="Labelrm_remark" runat="server" Text='<%# Bind("rm_remark") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxrm_remark" runat="server" Width="80px" Visible="false"  Text='<%# Bind("rm_remark") %>' MaxLength="15">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="業務部門代號">
                    <ItemTemplate>
                        <asp:Label ID="Labelrm_deptcd" runat="server" Text='<%# Bind("rm_deptcd") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxrm_deptcd" runat="server" Width="80px" Visible="false"  Text='<%# Bind("rm_deptcd") %>' MaxLength="5">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="發票借方總帳科目">
                    <ItemTemplate>
                        <asp:Label ID="Labelrm_accddr" runat="server" Text='<%# Bind("rm_accddr") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxrm_accddr" runat="server" Width="80px" Visible="false"  Text='<%# Bind("rm_accddr") %>' MaxLength="7">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="發票明細品名">
                    <ItemTemplate>
                        <asp:Label ID="Labelrm_idescr" runat="server" Text='<%# Bind("rm_idescr") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxrm_idescr" runat="server" Width="80px" Visible="false"  Text='<%# Bind("rm_idescr") %>' MaxLength="30">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="發票明細單位">
                    <ItemTemplate>
                        <asp:Label ID="Labelrm_iunit" runat="server" Text='<%# Bind("rm_iunit") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxrm_iunit" runat="server" Width="80px" Visible="false"  Text='<%# Bind("rm_iunit") %>' MaxLength="3">
                        </asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="發票明細備註">
                    <ItemTemplate>
                        <asp:Label ID="Labelrm_iremark" runat="server" Text='<%# Bind("rm_iremark") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxrm_iremark" runat="server" Width="80px" Visible="false"  Text='<%# Bind("rm_iremark") %>' MaxLength="12">
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
    <div id="dialog" style="text-align: left; display: none;" title="新增 轉 SAP 發票摘要檔">
        <span class="stripeMe">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <font color="#ff0000">* </font>系統代碼名稱:
                    </td>
                    <td>
                        <asp:dropdownlist id="ddlrm_syscd" runat="server"></asp:dropdownlist>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="#ff0000">* </font>發票事由:
                    </td>
                    <td>
                        <asp:textbox id="rm_remark" runat="server" MaxLength="15" Width="150px"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        業務部門代號:
                    </td>
                    <td>
                        <asp:textbox id="rm_deptcd" runat="server" Width="50px" MaxLength="5"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        發票借方總帳科目:
                    </td>
                    <td>
                        <asp:textbox id="rm_accddr" runat="server" MaxLength="7" Width="54px"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        發票明細品名:
                    </td>
                    <td>
                        <asp:textbox id="rm_idescr" runat="server" MaxLength="30" Width="150px"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        發票明細單位:
                    </td>
                    <td>
                        <asp:textbox id="rm_iunit" runat="server" Width="50px" MaxLength="3"></asp:textbox>
                    </td>
                </tr>
                <tr>
                    <td>
                        發票明細備註:
                    </td>
                    <td>
                        <asp:textbox id="rm_iremark" runat="server" Width="150px" MaxLength="15"></asp:textbox>
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
