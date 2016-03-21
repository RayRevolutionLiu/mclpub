<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="contpubfm_search.aspx.cs" Inherits="mclpub.Layout.contpubfm_search" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript">
        function doSelectMfr(win_width, win_height) {
            var mfrnoV = window.document.getElementById("<% =tbxMfrNo.ClientID%>").value;
            var iTop = (window.screen.availHeight - 30 - win_height) / 2;  //視窗的垂直位置;
            var iLeft = (window.screen.availWidth - 10 - win_width) / 2;   //視窗的水平位置;
            var features = "width=" + win_width + ",height=" + win_height + ",top=" + iTop + ",left=" + iLeft + ",location=no,status=no";
            var vReturn = window.open("../Contract/mfr_detail.aspx?mfrno=" + mfrnoV, "Poping", features);
        }
    </script>
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 平面廣告落版處理 / 顯示合約及落版資料</span> <span class="stripeMe">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <th colspan="2">
                        查詢條件
                    </th>
                </tr>
                <tr>
                    <td align="right" width="170" class="font_bold">
                        公司名稱：
                    </td>
                    <td>
                        <asp:TextBox ID="tbxMfrName" runat="server" AutoPostBack="True" TabIndex="1" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="170" class="font_bold">
                        <span class="stripeMe">統一編號：</span>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxMfrNo" runat="server" AutoPostBack="True" MaxLength="10" TabIndex="2"
                            Width="60px"></asp:TextBox>
                        <img border="0" class="ico" onclick="doSelectMfr(400,350)" src="<%=ResolveUrl("~/Art/images/btn_search.gif")%>"
                            title="查詢" />
                    </td>
                </tr>
                <tr>
                    <td align="right" width="170" class="font_bold">
                        <span class="stripeMe">客戶編號：</span>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxCustNo" runat="server" AutoPostBack="True" MaxLength="6" TabIndex="3"
                            Width="45px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="170" class="font_bold">
                        客戶性名：
                    </td>
                    <td>
                        <asp:TextBox ID="tbxCustName" runat="server" AutoPostBack="True" MaxLength="30" TabIndex="4"
                            Width="80px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="170" class="font_bold">
                        <font color="red">*</font>合約編號：
                    </td>
                    <td>
                        <asp:TextBox ID="tbxContNo" runat="server" AutoPostBack="True" MaxLength="6" TabIndex="5"
                            Width="80px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </span>
    <table border="0" width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <td align="right">
                <asp:Button ID="btnOK" runat="server" Text="查詢" OnClick="btnOK_Click" />
            </td>
        </tr>
    </table>
    <span class="font_size13 font_bold font_gray">
        <ol>
            <li>請輸入任一關鍵詞然後按下查詢</li>
            <li>查詢資料結果中,不包含<span class="font_darkblue">「未落版」</span>的合約資料<br />
                <span class="font_red">註:避免重複新增廠商資料</span><br />
                <span class="font_red">註:請先輸入統一編號後,按下旁邊按鈕進行查詢</span></li>
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
        <asp:GridView ID="GVcont" runat="server" Width="99%" AutoGenerateColumns="false"
            CssClass="font_blacklink font_size13" AllowPaging="true" PagerSettings-Visible="false"
            OnRowDataBound="GVcont_RowDataBound">
            <Columns>
                <asp:BoundField DataField="cont_contno" HeaderText="合約編號" />
                <asp:BoundField DataField="cont_conttp" HeaderText="合約類別" />
                <asp:BoundField DataField="cont_bkcd" HeaderText="書籍代碼" />
                <asp:BoundField DataField="bk_nm" HeaderText="書籍類別" />
                <asp:BoundField DataField="cont_sdate" HeaderText="合約起日" />
                <asp:BoundField DataField="cont_edate" HeaderText="合約迄日" />
                <asp:BoundField DataField="cont_mfrno" HeaderText="廠商統編" />
                <asp:BoundField DataField="mfr_inm" HeaderText="公司名稱" />
                <asp:BoundField DataField="cont_custno" HeaderText="客戶編號" />
                <asp:BoundField DataField="cust_nm" HeaderText="客戶姓名" />
                <asp:BoundField DataField="cust_tel" HeaderText="聯絡電話" />
                <asp:BoundField DataField="cont_fgclosed" HeaderText="已結案" />
                <asp:BoundField DataField="cont_fgcancel" HeaderText="已註銷" />
                <asp:TemplateField HeaderStyle-Width="7%">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server">顯示資料</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle HorizontalAlign="Center" />
            <EmptyDataTemplate>
                查詢無結果
            </EmptyDataTemplate>
        </asp:GridView>
    </span>
    <div class="pager font_size13">
        <uc3:ucpager id="UCPager1" runat="server" />
    </div>
</asp:Content>
