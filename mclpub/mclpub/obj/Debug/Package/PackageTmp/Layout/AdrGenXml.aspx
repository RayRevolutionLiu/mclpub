<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdrGenXml.aspx.cs" Inherits="mclpub.Layout.AdrGenXml" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .UrlClass
        {
            word-break:break-all;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 網路廣告落版處理 / 產生播出檔</span>
        <table border="0" cellpadding="0" cellspacing="0" width="80%" class="font_size13">
            <tr>
                <td>
                    點選右方日曆上的日期<br />
                    或直接輸入日期：<br />
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <asp:TextBox ID="tbxAdDate" runat="server" Width="80px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="rdvAdDate" runat="server" CssClass="ValidatorStyle"
                        ErrorMessage="格式應為yyyy/mm/dd" Display="Dynamic" ControlToValidate="tbxAdDate"
                        ValidationExpression="[1-9]\d{3}\/[0-1][0-9]\/[0-3][0-9]"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvSDate" runat="server" ControlToValidate="tbxAdDate"
                        Display="Dynamic" ErrorMessage="不可空白"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    <br />

                    <asp:Button ID="btnQueryPublish" runat="server" Text="查詢該日落版狀況" 
                        onclick="btnQueryPublish_Click"></asp:Button>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                    <asp:Calendar ID="calDates" runat="server" BackColor="White" 
                        BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                        DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                        ForeColor="#003399" Height="200px" 
                        onselectionchanged="calDates_SelectionChanged1" Width="300px">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                            Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    <span class="stripeMe font_size13">
            <asp:Panel ID="pnlAdr" runat="server" Width="100%" Visible="False">
            <div align="right">
                <asp:Button ID="btnGenXml" Text="產生yyyy/MM/dd的播出檔" runat="server" CausesValidation="False"
                    OnClick="btnGenXml_Click"></asp:Button></div>
                <asp:TextBox ID="tbxSelDate" runat="server" Width="10px" Visible="False"></asp:TextBox>
                <asp:DataGrid ID="dgdAdr" runat="server" CssClass="font_size12" AutoGenerateColumns="False" UseAccessibleHeader="true">
                    <Columns>
                        <asp:BoundColumn DataField="adr_contno" ReadOnly="True" HeaderText="合約書編號"></asp:BoundColumn>
                        <asp:BoundColumn DataField="adr_seq" ReadOnly="True" HeaderText="序號">
                            <HeaderStyle Width="25px"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="adr_addate" ReadOnly="True" HeaderText="播出日期">
                            <HeaderStyle Width="60px"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="adr_alttext" ReadOnly="True" HeaderText="廣告標語">
                            <HeaderStyle Width="100px"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="adr_adcate" ReadOnly="True" HeaderText="廣告頁面"></asp:BoundColumn>
                        <asp:BoundColumn DataField="adr_keyword" ReadOnly="True" HeaderText="廣告位置"></asp:BoundColumn>
                        <asp:BoundColumn DataField="adr_navurl" ReadOnly="True" HeaderText="廣告連結">
                            <HeaderStyle Width="50px"></HeaderStyle>
                            <ItemStyle  CssClass="UrlClass" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="adr_impr" ReadOnly="True" HeaderText="播放機率">
                            <HeaderStyle Width="25px"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="adr_fgfixad" ReadOnly="True" HeaderText="播放方式"></asp:BoundColumn>
                        <asp:BoundColumn DataField="adr_imgurl" ReadOnly="True" HeaderText="廣告圖檔"></asp:BoundColumn>
                        <asp:BoundColumn DataField="adr_drafttp" ReadOnly="True" HeaderText="圖檔稿類別"></asp:BoundColumn>
                        <asp:BoundColumn DataField="adr_urltp" ReadOnly="True" HeaderText="網頁稿類別"></asp:BoundColumn>
                        <asp:BoundColumn DataField="cont_empno" ReadOnly="True" HeaderText="負責業務員"></asp:BoundColumn>
                        <asp:BoundColumn DataField="cust_nm" ReadOnly="True" HeaderText="客戶姓名"></asp:BoundColumn>
                        <asp:BoundColumn DataField="mfr_inm" ReadOnly="True" HeaderText="廠商名稱"></asp:BoundColumn>
                        <asp:BoundColumn DataField="cont_aunm" ReadOnly="True" HeaderText="聯絡人"></asp:BoundColumn>
                        <asp:BoundColumn DataField="im_nm" ReadOnly="True" HeaderText="發票廠商收件人"></asp:BoundColumn>
                        <asp:BoundColumn DataField="adr_remark" ReadOnly="True" HeaderText="備註">
                            <HeaderStyle Width="10px"></HeaderStyle>
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="False" DataField="sort_adcate" HeaderText="sort_adcate">
                        </asp:BoundColumn>
                        <asp:BoundColumn Visible="False" DataField="sort_keyword" HeaderText="sort_keyword">
                        </asp:BoundColumn>
                    </Columns>
                </asp:DataGrid>
            </asp:Panel>
            <asp:TextBox ID="TextBox1" runat="server" Width="90%" TextMode="MultiLine" Rows="20"></asp:TextBox>
    </span>
</asp:Content>
