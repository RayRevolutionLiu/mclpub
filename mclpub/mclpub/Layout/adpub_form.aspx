<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="adpub_form.aspx.cs" Inherits="mclpub.Layout.adpub_form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 平面廣告落版處理 / 廣告落版單</span>
    <span class="stripeMe">
    <table border="0" width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <th colspan="2">
                查詢條件</th>
        </tr>
        <tr>
            <td align="right" width="170" class="font_bold">
                書籍類別：</td>
            <td>
            <asp:DropDownList ID="ddlBookCode" runat="server">
                <asp:ListItem Selected="True" Value="00">請選擇</asp:ListItem>
                <asp:ListItem Value="01">工材</asp:ListItem>
                <asp:ListItem Value="02">電材</asp:ListItem>
                <asp:ListItem Value="04">電材叢書</asp:ListItem>
                <asp:ListItem Value="05">材料</asp:ListItem>
            </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" width="170" class="font_bold">
                <span class="stripeMe">刊登年月：</span></td>
            <td>
                <asp:TextBox ID="tbxPubDate" runat="server" MaxLength="7" Width="60px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revPubDate" runat="server" Display="Dynamic" ErrorMessage="'刊登年月' 請依格式填入(請參旁邊文字說明)!!!" ControlToValidate="tbxPubDate" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvSDate" runat="server" ControlToValidate="tbxPubDate"
                    Display="Dynamic" ErrorMessage="不可空白"></asp:RequiredFieldValidator>
                <font color="gray">(請輸入 6碼年月,&nbsp;如2002年 1月, 請輸入&nbsp;2002/01)</font>
            </td>
        </tr>
        </table>
    </span>
    <table border="0" width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <td align="right">
                <asp:Button ID="lnbShow" runat="server" Text="查詢" onclick="lnbShow_Click" />
                <asp:Button ID="lnbClearAll" runat="server" Text="清除" 
                    onclick="lnbClearAll_Click"  CausesValidation="false"/>
                </td>
        </tr>
    </table>
    <span class="font_size13 font_bold font_gray">
        <ol>
            <li>請輸入任一關鍵詞來查詢, 然後按下<span class="font_darkblue">查詢</span></li><br />
            <li>出現結果後, 若有錯誤資料, 將要求先修正;<br />
                若無錯誤落版資料, 請再按下<span class="font_darkblue">此連結</span>來繼續!</li>
        </ol>
    </span>
    <table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
            </td>
            <td align="right">
                &nbsp;</td>
        </tr>
    </table>
            <asp:Label ID="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
            <asp:LinkButton ID="Lkdownload" runat="server" 
    onclick="Lkdownload_Click">此連結</asp:LinkButton>
            <asp:Label ID="lblMessageAfter" runat="server" ForeColor="#C00000"></asp:Label>
            </asp:Content>
