<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="njtp_detail.aspx.cs" Inherits="mclpub.Layout.njtp_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>新稿製法<</title>
</head>
<body>
    <form id="njtp_detail" method="post" runat="server">
    <span class="stripeMe">
    <asp:Label ID="lblMessage" runat="server" ForeColor="Blue"></asp:Label>
    <br />
    <asp:DataGrid ID="DataGrid1" runat="server" AutoGenerateColumns="False" UseAccessibleHeader="true" Width="100%">
        <PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399"
            Position="Top" BackColor="#99CCCC"></PagerStyle>
        <SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
        <ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
        <Columns>
            <asp:BoundColumn DataField="njtp_njtpcd" HeaderText="代碼"></asp:BoundColumn>
            <asp:BoundColumn DataField="njtp_nm" HeaderText="新稿製法名稱"></asp:BoundColumn>
        </Columns>
    </asp:DataGrid>
    <br />
    <asp:Button ID="btnUpdate" runat="server" Text="新增/維護/刪除  新稿製法" 
        onclick="btnUpdate_Click"></asp:Button>&nbsp;
    <input id="btnClose" onclick="Javascript:window.close();" type="button" value="關閉視窗" name="btnClose" class="btn_mouseout" onmouseover="this.className='btn_mouseover'"
        onmouseout="this.className='btn_mouseout'" />
    </span>
    </form>
</body>
</html>
