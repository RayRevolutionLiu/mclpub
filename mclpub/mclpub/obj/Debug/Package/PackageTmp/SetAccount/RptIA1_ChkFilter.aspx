<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RptIA1_ChkFilter.aspx.cs" Inherits="mclpub.SetAccount.RptIA1_ChkFilter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;帳務管理 / 網路廣告發票處理 / 單一廠商之發票開立單檢核表：列印</span>
<span class="font_size13 font_bold font_gray">
<ol>
    <li>請注意：已於會計系統做處理之發票開立單無法再列印檢核表！</li>
</ol>
</span>
<span class="stripeMe">
    <asp:GridView ID="DataGrid1" 
                runat="server" 
                Width="100%" 
                AutoGenerateColumns="False" 
                CssClass="font_blacklink font_size12" 
                EnableModelValidation="True" 
        onrowdatabound="DataGrid1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="ia_iano"  HeaderText="發票開立單編號" />
            <asp:BoundField DataField="ia_contno"     HeaderText="合約編號" />
            <asp:BoundField DataField="ia_mfrno"      HeaderText="發票廠商統編" />
            <asp:BoundField DataField="mfr_inm"      HeaderText="發票廠商名稱" />
            <asp:BoundField DataField="ia_rnm"  HeaderText="發票收件人" />
            <asp:BoundField DataField="ia_pyat"     HeaderText="發票金額" />
            <asp:BoundField DataField="ia_invcd"   HeaderText="發票類別" />
            <asp:BoundField DataField="ia_taxtp"      HeaderText="課稅別" />
            <asp:BoundField DataField="ia_fgitri"      HeaderText="往來註記" />
            <asp:BoundField DataField="ia_cname"      HeaderText="承辦人員" />
            <asp:TemplateField HeaderStyle-Width="35px">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" Text="確定" OnClick="Button1_Click"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>  
        <EmptyDataRowStyle HorizontalAlign="Center" />   
        <EmptyDataTemplate>
            查詢無結果
        </EmptyDataTemplate>
        <PagerSettings Visible="False">
        </PagerSettings>
    </asp:GridView>
</span>
</asp:Content>
