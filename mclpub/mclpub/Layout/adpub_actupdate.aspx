<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="adpub_actupdate.aspx.cs" Inherits="mclpub.Layout.adpub_actupdate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript">
        function doSelectNjtype(win_width, win_height) {
            var iTop = (window.screen.availHeight - 30 - win_height) / 2;  //視窗的垂直位置;
            var iLeft = (window.screen.availWidth - 10 - win_width) / 2;   //視窗的水平位置;
            var features = "width=" + win_width + ",height=" + win_height + ",top=" + iTop + ",left=" + iLeft + ",resizable=yes,location=yes,scrollbars=yes,toolbar=yes";
            var vReturn = window.open("njtype.aspx", "Poping", features);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 平面廣告落版處理 / 美編樣後修改 步驟二</span>
    <span class="stripeMe">
    <asp:DataGrid ID="DataGrid1" runat="server" CssClass="font_blacklink font_size13"
        UseAccessibleHeader="true" Font-Size="X-Small" AutoGenerateColumns="False" AllowPaging="False">
        <FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
        <HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
        <PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399"
            Position="Top" BackColor="#99CCCC"></PagerStyle>
        <SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
        <ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
        <Columns>
            <asp:BoundColumn Visible="False" DataField="頁次" HeaderText="頁次"></asp:BoundColumn>
            <asp:BoundColumn DataField="合約書編號" HeaderText="合約書編號"></asp:BoundColumn>
            <asp:BoundColumn DataField="刊登年月" HeaderText="刊登年月"></asp:BoundColumn>
            <asp:BoundColumn DataField="落版序號" HeaderText="落版序號"></asp:BoundColumn>
            <asp:BoundColumn DataField="刊登頁碼" HeaderText="刊登頁碼"></asp:BoundColumn>
            <asp:BoundColumn DataField="廣告版面" HeaderText="廣告版面"></asp:BoundColumn>
            <asp:BoundColumn DataField="廣告色彩" HeaderText="廣告色彩"></asp:BoundColumn>
            <asp:BoundColumn DataField="廣告篇幅" HeaderText="廣告篇幅"></asp:BoundColumn>
            <asp:BoundColumn DataField="固定頁次註記" HeaderText="固定頁次">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundColumn>
            <asp:BoundColumn DataField="公司名稱" HeaderText="公司名稱"></asp:BoundColumn>
            <asp:BoundColumn DataField="到稿註記" HeaderText="到稿註記"></asp:BoundColumn>
            <asp:BoundColumn DataField="njtp_nostr" HeaderText="(參考新稿製法)"></asp:BoundColumn>
            <asp:TemplateColumn HeaderText="新稿製法代碼">
                <ItemStyle Width="55px"></ItemStyle>
                <ItemTemplate>
                    <asp:TextBox ID="tbxNjtpcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "新稿製法代碼").ToString().Trim() %>'
                        MaxLength="2" Width="30px" Font-Size="X-Small" Visible='<%# GetVisiblity1(DataBinder.Eval(Container.DataItem, "稿件類別代碼").ToString().Trim()) %>'
                        OnTextChanged='<%# CheckNjtpcd(DataBinder.Eval(Container.DataItem, "新稿製法代碼").ToString()) %>'>
                    </asp:TextBox>
                    <img class="ico" id="imgNjtpcd" onclick="javascript:doSelectNjtype(950, 550)"
                        alt="新稿製法資料" src="<%=ResolveUrl("~/Art/images/btn_data.gif")%>" width="18" border="0">
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="改稿書籍代碼" HeaderText="改稿書籍"></asp:BoundColumn>
            <asp:BoundColumn DataField="改稿期別" HeaderText="改稿期別"></asp:BoundColumn>
            <asp:TemplateColumn HeaderText="改稿頁碼">
                <ItemTemplate>
                    <asp:TextBox ID="tbxChgJBkNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "改稿頁碼").ToString().Trim() %>'
                        Visible='<%# GetVisiblity2(DataBinder.Eval(Container.DataItem, "稿件類別代碼").ToString().Trim()) %>'
                        Width="30px" Font-Size="X-Small" MaxLength="3">
                    </asp:TextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="改稿重出片">
                <ItemTemplate>
                    <asp:CheckBox ID="cbxfgReChg" runat="server" Checked='<%# GetfgReChg(DataBinder.Eval(Container.DataItem, "改稿重出片註記")) %>'>
                    </asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:BoundColumn DataField="舊稿書籍名稱" HeaderText="舊稿書籍"></asp:BoundColumn>
            <asp:BoundColumn DataField="舊稿期別" HeaderText="舊稿期別"></asp:BoundColumn>
            <asp:BoundColumn DataField="舊稿頁碼" HeaderText="舊稿頁碼"></asp:BoundColumn>
            <asp:BoundColumn DataField="落版業務員姓名" HeaderText="落版業務員"></asp:BoundColumn>
            <asp:BoundColumn DataField="備註" HeaderText="備註"></asp:BoundColumn>
            <asp:BoundColumn Visible="False" DataField="稿件類別代碼" HeaderText="稿件類別"></asp:BoundColumn>
            <asp:BoundColumn Visible="False" DataField="改稿頁碼" HeaderText="改稿頁碼"></asp:BoundColumn>
            <asp:BoundColumn Visible="False" DataField="改稿重出片註記" HeaderText="改稿重出片註記"></asp:BoundColumn>
            <asp:BoundColumn Visible="False" DataField="美編樣後修改註記" HeaderText="美編樣後修改註記"></asp:BoundColumn>
            <asp:TemplateColumn HeaderText="美編樣後修改">
                <ItemStyle Width="30px"></ItemStyle>
                <ItemTemplate>
                    <asp:TextBox ID="tbxfgupdated" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "美編樣後修改註記").ToString().Trim() %>'
                        MaxLength="1" Width="20px" Font-Size="X-Small" Visible='<%# GetfgUpdated(DataBinder.Eval(Container.DataItem, "稿件類別代碼").ToString().Trim()) %>'>
                    </asp:TextBox>
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
        <span class="font_size13 font_bold font_gray">
            <ol>
                <li>操作說明：請輸入您要修改的資料, 最後按下網頁頁尾處的<span class="font_darkblue">確認更新</span>按鈕即可</li><br />
                <span class="font_red">註:新稿製法：請輸入 "代碼", 勿輸入其名稱; 若不知代碼, 可按右方圖示來參考!</span><br />
                <span class="font_red">註:改稿重出片：若是重出, 請勾選; 否之, 請勿勾選</span>
            </ol>
        </span>
    <br />
    <div align="center">
    <asp:Button ID="btnUpdate" runat="server" Text="確認更新" onclick="btnUpdate_Click"></asp:Button>&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="取消回首頁" onclick="btnCancel_Click"></asp:Button><br />
    </div>
</span>
</asp:Content>
