<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="njtype.aspx.cs" Inherits="mclpub.Layout.njtype" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
    function ValidateNumber(e, pnumber) {
        if (!/^\d+$/.test(pnumber)) {
            $(e).val(/^\d+/.exec($(e).val()));
        }
        return false;
    }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 平面廣告落版處理 / 相關維護區 / 新稿製法-資料瀏覽</span>
    <span class="stripeMe">
        <table border="0" width="100%" cellspacing="0" cellpadding="0">
            <tr>
                <th colspan="2">
                    查詢條件
                </th>
            </tr>
            <tr>
                <td style="width: 15%">
                    <asp:TextBox ID="tbxQString" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:DropDownList ID="ddlQueryField" runat="server">
                        <asp:ListItem Selected="True" Value="njtp_nm">新稿製法名稱</asp:ListItem>
                        <asp:ListItem Value="njtp_njtpcd">新稿製法代碼</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </span>
    <div style="text-align:right">
        <asp:Button ID="Query" runat="server" Text="開始搜尋" OnClick="Query_Click" CausesValidation="false" />
        <asp:Button ID="btnShowAll" runat="server" Text="全部顯示" OnClick="btnShowAll_Click"
            CausesValidation="false" />
        <input id="DialogAddBtn" type="button" value="新增資料" class="btn_mouseout" onmouseover="this.className='btn_mouseover'"
            onmouseout="this.className='btn_mouseout'" />
        <asp:Button ID="btnReturnHome" runat="server" Text="回系統首頁" OnClick="btnReturnHome_Click"
            CausesValidation="false" />
    </div>
    <span class="font_size13 font_bold font_gray">
        <ol>
            <span class="font_red">註：為避免因資料被刪，導致舊資料讀取錯誤，若該筆已被使用，將不允許刪除！</span><br />
        </ol>
    </span>
    <table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
            </td>
            <td align="right">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <span class="stripeMe">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" PageSize="10"
            CssClass="font_blacklink font_size13" Width="100%" OnRowDataBound="GridView1_RowDataBound"
            AllowPaging="true" PagerSettings-Visible="false">
        <Columns>
            <asp:BoundField DataField="njtp_njtpid" HeaderText="ID" />
            <asp:TemplateField HeaderText="新稿製法代碼">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("njtp_njtpcd") %>'></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" Visible="false" Text='<%# Bind("njtp_njtpcd") %>'
                        MaxLength="2" onkeyup="return ValidateNumber($(this),value)"></asp:TextBox>
                </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="新稿製法名稱">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("njtp_nm") %>'></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("njtp_nm") %>' Visible="false"
                        MaxLength="10"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderStyle-Width="20%" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Button ID="btnEdit" runat="server" Text="修改" OnClick="btnEdit_Click" CausesValidation="false" />
                    <asp:Button ID="SubBtn" runat="server" Text="確定" OnClick="SubBtn_Click" CausesValidation="false"  Visible="false"/>
                    <asp:Button ID="CancelBtn" runat="server" Text="取消" OnClick="CancelBtn_Click" CausesValidation="false" Visible="false" />
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
    <div class="pager font_size13" style="width:100%">
        <uc3:ucpager id="UCPager1" runat="server" />
    </div>
    <div id="dialog" style="text-align: left; display: none;" title="新增新稿製法">
    <span class="stripeMe">
        <table border="0" width="100%" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                    製法代碼
                </td>
                <td>
                    <asp:TextBox ID="njtp_njtpcd" runat="server" MaxLength="2" Width="25px" CssClass="text ui-widget-content ui-corner-all"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator1" runat="server" Display="Dynamic"
                        ControlToValidate="njtp_njtpcd" ErrorMessage="必填欄位!"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="Regularexpressionvalidator1" runat="server" Display="Dynamic"
                        ControlToValidate="njtp_njtpcd" ErrorMessage="請輸入 2 位數字!" ValidationExpression="[0-9]{2}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    製法名稱
                </td>
                <td>
                    <asp:TextBox ID="njtp_nm" runat="server" MaxLength="10" Width="142px" CssClass="text ui-widget-content ui-corner-all"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator2" runat="server" Display="Dynamic"
                        ControlToValidate="njtp_nm" ErrorMessage="必填欄位!"></asp:RequiredFieldValidator>
                </td>
            </tr>
            </table>
    </span>
    <div style="text-align:right">
        <asp:Button ID="AddBtn" runat="server" Text="確定新增" OnClick="AddBtn_Click" />
    </div>
    </div>
</asp:Content>
