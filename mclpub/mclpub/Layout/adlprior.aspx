<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="adlprior.aspx.cs" Inherits="mclpub.Layout.adlprior" MaintainScrollPositionOnPostback="true" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
    function submitBtn() {
        var BookCode = $('#<% =ddlBookCode.ClientID%> option:selected');
        var PriorSeq = $('#<% =tbxPriorSeq.ClientID%>');
        var LayoutTypeCode = $('#<% =ddlLayoutTypeCode.ClientID%> option:selected');
        var ColorCode = $('#<% =ddlColorCode.ClientID%> option:selected');
        var PageSizeCode = $('#<% =ddPageSizeCode.ClientID%> option:selected');
        $.post("SubmitJudge.aspx", { BookCodeURL: BookCode.val(), PriorSeqURL: PriorSeq.val(), LayoutTypeCodeURL: LayoutTypeCode.val(), ColorCodeURL: ColorCode.val(), PageSizeCodeURL: PageSizeCode.val() }, function (result) {
            if (result == "No!") {
                alert('新增失敗: 資料重覆, 請修正再新增!');
            }
            if (result == "Ok!") {
                alert('新增成功!');
                window.location.href = "adlprior.aspx";
            }
            if (result == "Error!") {
                alert('資料錯誤!');
            }
        });
                }
                function doDetailThis(win_width, win_height) {
                    var BookCode = $('#<% =ddlBookCode.ClientID%> option:selected');
                    var iTop = (window.screen.availHeight - 30 - win_height) / 2;  //視窗的垂直位置;
                    var iLeft = (window.screen.availWidth - 10 - win_width) / 2;   //視窗的水平位置;
                    var features = "width=" + win_width + ",height=" + win_height + ",top=" + iTop + ",left=" + iLeft + ",menubar=no, scrollbars=yes,location=no,status=no";
                    var vReturn = window.open("adlprior_get.aspx?bkcd=" + BookCode.val(), "new", features);
                }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 平面廣告落版處理 / 相關維護區 / 版面優先次序</span>
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
                        <asp:ListItem Value="bk_nm" Selected="True">書籍名稱</asp:ListItem>
                        <asp:ListItem Value="lp_priorseq">排版優先次序</asp:ListItem>
                        <asp:ListItem Value="ltp_nm">廣告版面</asp:ListItem>
                        <asp:ListItem Value="clr_nm">廣告色彩</asp:ListItem>
                        <asp:ListItem Value="pgs_nm">廣告篇幅</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </span>
    <div style="text-align: right">
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
            <span class="font_red">為避免舊資料讀取錯誤，若該筆已被使用(筆數>0)，將不允許修改/刪除！</span><br />
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
                <asp:BoundField DataField="lp_lpid" HeaderText="ID" />
                <asp:TemplateField HeaderText="書籍名稱">
                    <ItemTemplate>
                        <asp:Label ID="Labelbk_nm" runat="server" Text='<%# Bind("bk_nm") %>'></asp:Label>
                        <asp:DropDownList ID="TextBoxbk_nm" runat="server" Width="80px" Visible="false">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="排版優先次序">
                    <ItemTemplate>
                        <asp:Label ID="Labellp_priorseq" runat="server" Text='<%# Bind("lp_priorseq") %>'></asp:Label>
                        <asp:TextBox ID="TextBoxlp_priorseq" runat="server" Text='<%# Bind("lp_priorseq") %>'
                            Width="80px" Visible="false"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="廣告版面">
                    <ItemTemplate>
                        <asp:Label ID="Labelltp_nm" runat="server" Text='<%# Bind("ltp_nm") %>'></asp:Label>
                        <asp:DropDownList ID="TextBoxltp_nm" runat="server" Width="80px" Visible="false">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="廣告色彩">
                    <ItemTemplate>
                        <asp:Label ID="Labelclr_nm" runat="server" Text='<%# Bind("clr_nm") %>'></asp:Label>
                        <asp:DropDownList ID="TextBoxclr_nm" runat="server" Width="80px" Visible="false">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="廣告篇幅">
                    <ItemTemplate>
                        <asp:Label ID="Labelpgs_nm" runat="server" Text='<%# Bind("pgs_nm") %>'></asp:Label>
                        <asp:DropDownList ID="TextBoxpgs_nm" runat="server" Width="80px" Visible="false">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="lp_bkcd" HeaderText="書籍代碼" />
                <asp:BoundField DataField="lp_ltpcd" HeaderText="廣告版面代碼" />
                <asp:BoundField DataField="lp_clrcd" HeaderText="廣告色彩代碼" />
                <asp:BoundField DataField="lp_pgscd" HeaderText="廣告篇幅代碼" />
                <asp:BoundField DataField="PubCounts" HeaderText="已使用之落版筆數" />
                <asp:TemplateField HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
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
    <div id="dialog" style="text-align: left; display: none;" title="新增 版面優先次序">
        <span class="stripeMe">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <font color="#ff0000">* </font>書籍名稱:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBookCode" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="#ff0000">* </font>欲插入的排版優先次序值:
                        <img class="ico" id="imgLPrior" title="顯示版面優先次序資料" onclick="doDetailThis(280,320)"
                            src="<%=ResolveUrl("~/Art/images/btn_data.gif")%>" border="0">
                    </td>
                    <td>
                        <asp:TextBox ID="tbxPriorSeq" runat="server" MaxLength="2" Width="30px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="#ff0000">* </font>廣告版面:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlLayoutTypeCode" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="#ff0000">* </font>廣告色彩:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlColorCode" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <font color="#ff0000">* </font>廣告篇幅:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddPageSizeCode" runat="server">
                        </asp:DropDownList>
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
