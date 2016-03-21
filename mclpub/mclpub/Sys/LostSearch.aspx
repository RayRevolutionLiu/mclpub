<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LostSearch.aspx.cs" Inherits="mclpub.Sys.LostSearch" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;系統管理 / 雜誌叢書缺書 / 查詢</span> 
        <span class="stripeMe">
            <table cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <th colspan="4">
                        訂戶資料
                    </th>
                </tr>
                <tr>
                    <td align="right" width="120" class="font_bold">
                        訂單編號：
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="tbxOrderNo" runat="server" Width="100px" MaxLength="13"></asp:TextBox>
                        (13碼例如：C100000101001)
                    </td>
                </tr>
                <tr>
                    <td align="right" width="120" class="font_bold">
                        公司名稱：
                    </td>
                    <td style="width: 232px">
                        <asp:TextBox ID="tbxCompanyname" runat="server" Width="204px" MaxLength="50"></asp:TextBox>
                    </td>
                    <td align="right" width="120" class="font_bold">
                        統一編號：
                    </td>
                    <td>
                        <asp:TextBox ID="tbxMfrno" runat="server" Width="99px" MaxLength="12"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="120" class="font_bold">
                        訂戶編號：
                    </td>
                    <td>
                        <asp:TextBox ID="tbxCustNo" runat="server" Width="52px" MaxLength="6"></asp:TextBox>
                    </td>
                    <td align="right" width="120" class="font_bold">
                        訂戶姓名：
                    </td>
                    <td>
                        <asp:TextBox ID="tbxCustName" runat="server" Width="99px" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th colspan="4">
                        <font color="white">收件人資料</font>
                    </th>
                </tr>
                <tr>
                    <td align="right" width="120" class="font_bold">
                        收件人姓名：
                    </td>
                    <td style="width: 232px">
                        <asp:TextBox ID="tbxRecName" runat="server" Width="99px" MaxLength="50"></asp:TextBox>
                    </td>
                    <td align="right" width="120" class="font_bold">
                        收件人電話：
                    </td>
                    <td>
                        <asp:TextBox ID="tbxRecTel" runat="server" Width="99px" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="120" class="font_bold">
                        收件人地址：
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="tbxRecAddr" runat="server" Width="431px" MaxLength="200"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="120" class="font_bold">
                        寄書狀態：
                    </td>
                    <td colspan="3">
                        <asp:RadioButtonList ID="rblSent" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0" Selected="True">未寄出</asp:ListItem>
                            <asp:ListItem Value="1">已寄出</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
        </span>
    <div align="right">
        <asp:Button ID="lnbSearch" runat="server" Text="查詢" OnClick="lnbSearch_Click" /></div>
    <table border="0" width="100%" cellspacing="0" cellpadding="0" runat="server" id="SearchIcon">
        <tr>
            <td class="font_size18 font_bold">
                <img src="<%=ResolveUrl("~/Art/images/icon_search.gif")%>" />搜尋結果
            </td>
            <td align="right">
            </td>
        </tr>
    </table>
    <span class="stripeMe">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" PageSize="10"
            CssClass="font_blacklink font_size13" Width="100%" AllowPaging="true" PagerSettings-Visible="false">
            <Columns>
                <asp:BoundField DataField="orderno" HeaderText="訂單編號" />
                <asp:BoundField DataField="otp_otp1nm" HeaderText="訂購類別" />
                <asp:BoundField DataField="o_date" HeaderText="訂購日期" />
                <asp:BoundField DataField="mfr_inm" HeaderText="公司名稱" />
                <asp:BoundField DataField="obtp_obtpnm" HeaderText="書籍名稱" />
                <asp:BoundField DataField="or_oritem" HeaderText="序號" />
                <asp:BoundField DataField="or_nm" HeaderText="收件人" />
                <asp:BoundField DataField="or_addr" HeaderText="地址" />
                <asp:BoundField DataField="or_tel" HeaderText="電話" />
                <asp:BoundField DataField="od_sdate" HeaderText="訂閱起時" />
                <asp:BoundField DataField="od_edate" HeaderText="訂閱迄時" />
                <asp:TemplateField HeaderStyle-Width="7%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnComplement" runat="server" Text="確定" OnClick="btnComplement_Click"
                            CausesValidation="false" />
                    </ItemTemplate>
                    <HeaderStyle Width="7%"></HeaderStyle>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle HorizontalAlign="Center" />
            <EmptyDataTemplate>
                查詢無結果
            </EmptyDataTemplate>
            <PagerSettings Visible="true"></PagerSettings>
            <PagerTemplate>
                <div align="center">
                    <asp:LinkButton ID="lbtn_first" runat="server" CausesValidation="false" CommandArgument="first"
                        OnClick="Query_Click">首頁</asp:LinkButton>
                    <asp:LinkButton ID="lbtn_pre10page" runat="server" Text="|<" CommandArgument="back10page"
                        OnClick="Query_Click" CausesValidation="false" />
                    <asp:LinkButton ID="lbtn_prepage" runat="server" Text="<" OnClick="Query_Click" CausesValidation="false"
                        CommandArgument="backpage" />
                    <asp:Repeater ID="rep_page" runat="server" OnItemDataBound="rep_page_ItemDataBound">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtn_page" runat="server" CommandArgument='<%#Eval("page") %>'
                                OnClick="lbtn_page_Click" CausesValidation="false"><%#Eval("page")%></asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:LinkButton ID="lbtn_nextpage" runat="server" Text=">" OnClick="Query_Click"
                        CausesValidation="false" CommandArgument="Advancepage" />
                    <asp:LinkButton ID="lbtn_next10page" runat="server" Text=">|" OnClick="Query_Click"
                        CausesValidation="false" CommandArgument="Advance10page" />
                    <asp:LinkButton ID="lbtn_last" runat="server" CausesValidation="false" CommandArgument="last"
                        OnClick="Query_Click">最末頁</asp:LinkButton>
                    &nbsp;共
                    <asp:Label ID="lbl_pagecount" runat="server" Text="0"></asp:Label>&nbsp;頁&nbsp;，
                    共&nbsp;<asp:Label ID="lbl_datacount" runat="server" Text="0"></asp:Label>&nbsp;筆
                    &nbsp;&nbsp;移至第&nbsp;<asp:DropDownList ID="ddl_gopage" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="ddl_gopage_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;頁
                </div>
            </PagerTemplate>
        </asp:GridView>
    </span>
    
    <span class="stripeMe">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" PageSize="10"
            CssClass="font_blacklink font_size13" Width="100%" AllowPaging="true" PagerSettings-Visible="false">
            <Columns>
                <asp:TemplateField HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" Text="刪除" OnClick="del_Click" OnClientClick="javascript:return confirm('確定刪除?');"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="orderno" HeaderText="訂單編號" />
                <asp:BoundField DataField="lst_seq" HeaderText="缺書序號" />
                <asp:BoundField DataField="otp_otp1nm" HeaderText="訂購類別一" />
                <asp:BoundField DataField="otp_otp2nm" HeaderText="訂購類別二" />
                <asp:BoundField DataField="mfr_inm" HeaderText="公司名稱" />
                <asp:BoundField DataField="cust_nm" HeaderText="訂戶姓名" />
                <asp:BoundField DataField="lst_oritem" HeaderText="收件人序號" />
                <asp:BoundField DataField="or_nm" HeaderText="收件人" />
                <asp:BoundField DataField="lst_cont" HeaderText="缺書內容" />
                <asp:TemplateField HeaderStyle-Width="7%" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="btnComplement" runat="server" Text="修改資料" OnClick="edit_Click" CausesValidation="false" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle HorizontalAlign="Center" />
            <EmptyDataTemplate>
                查詢無結果
            </EmptyDataTemplate>
        </asp:GridView>
        <div class="font_blacklink font_size13" align="center">
            <uc3:UCPager ID="UCPager2" runat="server" />
        </div>
    </span>
</asp:Content>
