<%@ Page language="c#" Codebehind="njtp_detail.aspx.cs" Src="njtp_detail.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.njtp_detail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>新稿製法</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK REL="stylesheet" HREF="../UserControl/mrlpub.css" Type="text/css" Title="Style">
	</HEAD>
	<body>
		<!-- Run at Server Form -->
		<form id="njtp_detail" method="post" runat="server">
			<asp:Label id="lblMessage" runat="server" ForeColor="Blue" Font-Size="X-Small"></asp:Label>
			<br>
			<asp:DataGrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="njtp_njtpcd" HeaderText="代碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="njtp_nm" HeaderText="新稿製法名稱"></asp:BoundColumn>
				</Columns>
			</asp:DataGrid>
			<br>
			<asp:Button id="btnUpdate" runat="server" Text="新增/維護/刪除  新稿製法" Width="150px"></asp:Button>
			<FONT face="新細明體">&nbsp; <INPUT id="btnClose" onclick="Javascript:window.close();" type="button" value="關閉視窗" name="btnClose"></FONT>
		</form>
	</body>
</HTML>
