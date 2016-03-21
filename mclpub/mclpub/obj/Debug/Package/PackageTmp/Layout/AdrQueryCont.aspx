<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="AdrQueryCont.aspx.cs" Inherits="mclpub.Layout.AdrQueryCont" MaintainScrollPositionOnPostback="true" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 網路廣告落版處理 / 廣告落版處理</span> 
        <span class="stripeMe">
            <table border="0" width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <th colspan="2">
                        查詢條件
                    </th>
                </tr>
                <tr>
                    <td align="right" width="120" class="font_bold">
                        公司名稱：
                    </td>
                    <td>
                        <asp:TextBox ID="tbxMfrNm" runat="server" Width="150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="120" class="font_bold">
                        統一編號<span class="stripeMe">：</span>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxMfrNo" runat="server" Width="80px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="120" class="font_bold">
        <span class="stripeMe">
                        客戶編號：</span></td>
                    <td>
                        <asp:TextBox ID="tbxCustNo" runat="server" MaxLength="6" Width="60px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="120" class="font_bold">
                        客戶姓名<span class="stripeMe">：</span>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxCustNm" runat="server" Width="80px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="120" class="font_bold">
                        合約書編號<span class="stripeMe">：</span>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxContNo" runat="server"></asp:TextBox>
                        <asp:LinkButton ID="lngGoThis" runat="server" onclick="lngGoThis_Click">GO</asp:LinkButton>
                        <asp:RequiredFieldValidator ID="rfvSDate" runat="server" ControlToValidate="tbxContNo"
                            Display="Dynamic" ErrorMessage="不可空白"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </span>
    <table border="0" width="100%" cellspacing="0" cellpadding="0">
        <tr>
            <td align="right">
                <asp:Button ID="CheckBtn" runat="server" Text="查詢" OnClick="CheckBtn_Click" CausesValidation="false" />
            </td>
        </tr>
    </table>
    <span class="font_size13 font_bold font_gray">
        <ol>
            <li>請輸入任一關鍵詞然後按下<span class="font_darkblue">「查詢」</span></li>
            <li>查出資料後，按下<span class="font_darkblue">選定落版</span>可進行[落版資料維護]</li>
            <li>如輸入確定的合約編號, 按下<span class="font_darkblue">GO</span>可直接進行[落版資料維護]進入此訂戶之歷史訂單畫面</li>
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

    <span class="stripeMe">
        <asp:GridView ID="dgdCont" runat="server" Width="99%" AutoGenerateColumns="false"
            AllowPaging="True" PagerSettings-Visible="false" CssClass="font_blacklink font_size12" OnRowDataBound="dgdCont_RowDataBound">
            <Columns>
                <asp:BoundField DataField="cont_contno" HeaderText="合約編號" />
                <asp:BoundField DataField="cont_signdate" HeaderText="簽約日期" />
                <asp:BoundField DataField="mfr_inm" HeaderText="公司名稱" />
                <asp:BoundField DataField="cust_custno" HeaderText="客戶編號" />
                <asp:BoundField DataField="cust_nm" HeaderText="客戶姓名" />
                <asp:BoundField DataField="cont_aunm" HeaderText="廣告聯絡人姓名" />
                <asp:BoundField DataField="cont_autel" HeaderText="廣告聯絡人電話" />
                <asp:BoundField DataField="cont_fgpayonce" HeaderText="一次付清註記" />
                <asp:BoundField DataField="cont_fgclosed" HeaderText="結案註記" />
                <asp:BoundField DataField="cont_conttp" HeaderText="合約類別" />
                <asp:BoundField DataField="cont_disc" HeaderText="優惠折數" />
                <asp:TemplateField HeaderStyle-Width="5%">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" Text="選定落版" OnClick="PushButton_Click"  CausesValidation="false"/>
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
