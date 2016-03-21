<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="admade_stat.aspx.cs" Inherits="mclpub.Layout.admade_stat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 平面廣告落版處理 / 廣告製稿統計表</span>
    <span class="stripeMe">
        <table border="0" width="100%" cellspacing="0" cellpadding="0">
            <tr>
                <th colspan="2">
                    查詢條件
                </th>
            </tr>
            <tr>
                <td align="right" width="170" class="font_bold">
                    書籍類別：
                </td>
                <td>
                    <asp:DropDownList ID="ddlBookCode" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" width="170" class="font_bold">
                    <span class="stripeMe">刊登年月：</span>
                </td>
                <td>
                    <asp:TextBox ID="tbxyyyymm" runat="server" MaxLength="7" Width="60px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revPubDate" runat="server" Display="Dynamic"
                        ErrorMessage="'刊登年月' 請依格式填入(請參旁邊文字說明)!!!" ControlToValidate="tbxyyyymm" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvSDate" runat="server" ControlToValidate="tbxyyyymm"
                        Display="Dynamic" ErrorMessage="不可空白"></asp:RequiredFieldValidator>
                    <font color="gray">(請輸入 6碼年月,&nbsp;如2002年 1月, 請輸入&nbsp;2002/01)</font>
                </td>
            </tr>
            <tr>
                <td align="right" width="170" class="font_bold">
                    承辦業務員：
                </td>
                <td>
                    <asp:DropDownList ID="ddlEmpNo" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </span>
    <table border="0" width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <td align="right">
                <asp:Button ID="lnbShow" runat="server" Text="查詢" OnClick="lnbShow_Click" />
                <asp:Button ID="lnbClearAll" runat="server" Text="清除" OnClick="lnbClearAll_Click"
                    CausesValidation="false" />
            </td>
        </tr>
    </table>
    <span class="font_size13 font_bold font_gray">
        <ol>
            <li>請輸入任一關鍵詞來查詢, 然後按下<span class="font_darkblue">查詢</span></li><br />
            <li>出現結果後, 請再按下<span class="font_darkblue">此連結</span>來繼續!</li>
        </ol>
    </span>
    <table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
            </td>
            <td align="right">
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:Label ID="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
    <asp:LinkButton ID="Lkdownload" runat="server" OnClick="Lkdownload_Click">此連結</asp:LinkButton>
    <asp:Label ID="lblMessageAfter" runat="server" ForeColor="#C00000"></asp:Label>
</asp:Content>
