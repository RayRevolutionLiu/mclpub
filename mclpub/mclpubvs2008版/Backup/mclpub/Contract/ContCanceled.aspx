<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContCanceled.aspx.cs" Inherits="mclpub.Contract.ContCanceled" MasterPageFile="~/MasterPage.Master" %>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">

<span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;合約管理 / 網路廣告合約書 / 已註銷合約處理</span>

<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="center"><asp:Label id="lblContCanceled" runat="server" ForeColor="Red">目前共有0筆註銷合約</asp:Label></td>
  </tr>
</table>
<br />
<span class="stripeMe">
    <asp:GridView ID="dgdCont" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="font_blacklink font_size13">
    <Columns>
    <asp:BoundField DataField="cont_contno" HeaderText="合約編號" />
    <asp:BoundField DataField="cont_signdate" HeaderText="簽約日期" />
    <asp:BoundField DataField="mfr_inm" HeaderText="公司名稱" />
    <asp:BoundField DataField="cont_aunm" HeaderText="廣告聯絡人姓名" />
    <asp:BoundField DataField="cont_autel" HeaderText="廣告聯絡人電話" />
    <asp:BoundField DataField="cont_fgpayonce" HeaderText="一次付清註記" />
    <asp:BoundField DataField="cont_fgclosed" HeaderText="結案註記" />
    <asp:BoundField DataField="cont_conttp" HeaderText="合約類別" />
    <asp:BoundField DataField="cont_disc" HeaderText="優惠折數" />
    <asp:TemplateField>
        <ItemTemplate>
            <asp:Button ID="BtnCancel" runat="server" Text="取消註銷"  OnClick="BtnCancel_Click" OnClientClick="return confirm('是否取消註銷?')"/>
        </ItemTemplate>
    </asp:TemplateField>
    
    </Columns>
    </asp:GridView>
</span>
</asp:Content>


