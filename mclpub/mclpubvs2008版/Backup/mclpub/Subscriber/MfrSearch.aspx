<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MfrSearch.aspx.cs" Inherits="mclpub.Subscriber.MfrSearch" %>
<%@ Register Src="../UserControl/Pager.ascx" TagName="UCPager" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>查詢廠商</title>
<link href="/Art/css/style.css" rel="stylesheet" type="text/css" />
<link href="/Art/css/superfish.css" rel="stylesheet" type="text/css"  media="screen" />

</head>
<body>
    <form id="form1" runat="server">
    <span class="stripeMe">
        <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="false"  CssClass="font_blacklink font_size13"  AllowPaging="True" PagerSettings-Visible="false">
        <Columns>
            <asp:TemplateField HeaderText="選取" HeaderStyle-Width="5%">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="GVSelect">選取</asp:LinkButton>
             </ItemTemplate>
             </asp:TemplateField>
            <asp:BoundField DataField="mfr_mfrno" HeaderText="統一編號" />
            <asp:BoundField DataField="mfr_inm" HeaderText="公司名稱" />
            <asp:BoundField DataField="mfr_iaddr" HeaderText="發票地址" />
            <asp:BoundField DataField="mfr_izip" HeaderText="郵遞區號" />
            <asp:BoundField DataField="mfr_respnm" HeaderText="負責人" />
            <asp:BoundField DataField="mfr_respjbti" HeaderText="職稱" />
            <asp:BoundField DataField="mfr_tel" HeaderText="聯絡電話" />
            <asp:BoundField DataField="mfr_fax" HeaderText="傳真號碼" />
        </Columns>
        <EmptyDataRowStyle HorizontalAlign="Center" />
        <EmptyDataTemplate>
        查詢無結果
        </EmptyDataTemplate>
        </asp:GridView>
    </span>
    <!--{* 分頁start *}-->
<div class="pager font_size13">
 <uc3:ucpager id="UCPager1" runat="server" />    
</div>
    </form>
</body>
</html>
