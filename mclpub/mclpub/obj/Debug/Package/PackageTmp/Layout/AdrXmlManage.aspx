<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdrXmlManage.aspx.cs" Inherits="mclpub.Layout.AdrXmlManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;落版管理 / 網路廣告落版處理 / 刪除落版播出檔</span><br />
<span class="stripeMe">
<div align="center">
<asp:Label ID="lblxml" runat="server" ForeColor="#C00000">現有xml檔案</asp:Label>
<br />
    <asp:GridView ID="dgdXml" runat="server" AutoGenerateColumns="false" Width="50%">
    <Columns>
        <asp:TemplateField HeaderStyle-Width="5%">
            <ItemTemplate>
                <asp:Button ID="DelBtn" runat="server" Text="刪除" OnClick="DelBtn_Click" CausesValidation="false" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="filename" HeaderText="xml檔案" />
    </Columns>
        <EmptyDataRowStyle HorizontalAlign="Center" />
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
    </asp:GridView>
</div>
    </span>
</asp:Content>
