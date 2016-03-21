<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderListFilter.aspx.cs" Inherits="mclpub.Order.OrderListFilter"  MasterPageFile="~/MasterPage.Master"%>

<asp:Content id="Content1" ContentPlaceholderID="ContentPlaceHolder1" runat="server">
    <span class="font_size12 font_darkblue font_bold">目前位置:&nbsp;訂單管理 / 雜誌叢書訂單處理 / 訂單明細表</span> 
<span class="stripeMe">
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <th colspan="2">查詢條件</th>
  </tr>
  <tr>

    <td align="right" width="150" class="font_bold">付款方式：</td>
    <td>
        <asp:DropDownList ID="ddlPayType" runat="server">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>

    <td align="right" width="150" class="font_bold"><span class="stripeMe">訂購日期：</span></td>
    <td>
        <asp:TextBox ID="tbxOrderDate1" runat="server" Width="82px" CssClass="UniqueDate"></asp:TextBox>
        ~<asp:TextBox ID="tbxOrderDate2" runat="server" Width="84px"  CssClass="UniqueDate"></asp:TextBox>
      </td>
  </tr>
  <tr>

    <td align="right" width="150" class="font_bold"> 
        訂單登錄日期：</td>
    <td>
        <asp:TextBox ID="tbxDate1" runat="server" Width="82px" CssClass="UniqueDate"></asp:TextBox>
        ~<asp:TextBox ID="tbxDate2" runat="server" Width="84px" CssClass="UniqueDate"></asp:TextBox>
      </td>
  </tr>
  <tr>

    <td align="right" width="150" class="font_bold">訂閱類別：</td>
    <td>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="ddlOrderType" runat="server" AutoPostBack="True" 
            onselectedindexchanged="ddlOrderType_SelectedIndexChanged">
            <asp:ListItem Selected="True" Value="00">請選擇</asp:ListItem>
            <asp:ListItem Value="01">訂閱</asp:ListItem>
            <asp:ListItem Value="02">贈閱</asp:ListItem>
            <asp:ListItem Value="03">推廣</asp:ListItem>
            <asp:ListItem Value="09">零售</asp:ListItem>
        </asp:DropDownList>
        </ContentTemplate>
        </asp:UpdatePanel>
      </td>
  </tr>
  <tr>

    <td align="right" width="150" class="font_bold">訂閱書籍類別：</td>
    <td>
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:DropDownList ID="ddlBookType" runat="server">
            </asp:DropDownList>
        </ContentTemplate>
        </asp:UpdatePanel>
      </td>
  </tr>
  <tr>

    <td align="right" width="150" class="font_bold">雜誌收件人姓名：</td>
    <td>
        <asp:TextBox ID="tbxRecName" runat="server"></asp:TextBox>
      </td>
  </tr>
  </table>
</span>
<table border="0" width="100%" cellspacing="0" cellpadding="0">
  <tr>
    <td align="right">
        <asp:Button ID="CheckBtn" runat="server" Text="查詢" onclick="CheckBtn_Click"/>
        <asp:Button ID="btnPrintList" runat="server" Text="列印報表" />
    </td>
  </tr>
</table>          
<span class="stripeMe">
    <asp:GridView ID="GVSearchCust" runat="server" Width="100%" 
        AutoGenerateColumns="False" PagerSettings-Visible="false" 
        CssClass="font_blacklink font_size13">
        <Columns>
        <asp:BoundField DataField="nostr" HeaderText="訂單編號" />
        <asp:BoundField DataField="pytp_nm" HeaderText="付款方式" />
        <asp:BoundField DataField="o_fgpreinv" HeaderText="預開發票" />
        <asp:BoundField DataField="obtp_obtpnm" HeaderText="書籍類別" />
        <asp:BoundField DataField="datestr" HeaderText="訂閱起迄" />
        <asp:BoundField DataField="od_amt" HeaderText="金額" />
        <asp:BoundField DataField="or_nm" HeaderText="雜誌收件人" />
        <asp:BoundField DataField="or_inm" HeaderText="公司名稱" />
        <asp:BoundField DataField="or_zip" HeaderText="郵遞區號" />
        <asp:BoundField DataField="or_addr" HeaderText="寄送地址" />
        <asp:BoundField DataField="or_tel" HeaderText="電話" />
        <asp:BoundField DataField="ra_mnt" HeaderText="份數" />
        <asp:BoundField DataField="srspn_cname" HeaderText="承辦人員" />
        </Columns>
    <EmptyDataRowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate>
    查詢無結果
    </EmptyDataTemplate>
    </asp:GridView>
</span>
        
</asp:Content>
