<%@ Page language="c#" Codebehind="adpub_actupdate.aspx.cs" Src="adpub_actupdate.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_actupdate" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>美編樣後修正 步驟二 (畫面同 廣告落版動作 步驟二)</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<CENTER>
			<!-- 頁首 Header -->
			<kw:header id="Header" runat="server">
			</kw:header>
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" align="left">
				<tr>
					<td align="left">
						<FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							落版處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							美編樣後修改&nbsp; </FONT>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="adpub_actupdate" method="post" runat="server">
				<div align="left">
					<font color="#990033" size="2">操作說明：請由最右方欄位 '勾選' 您要的更新的資料, 最後按下網頁頁尾處的 '確認更新' 按鈕即可.</font>
				</div>
				<div align="Right">
					<font color="DarkBlue" size="2">(每頁顯示 50筆資料.)</font>
					<br>
				</div>
				<asp:datagrid id="DataGrid1" Runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False" AllowPaging="True" PageSize="50">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<Columns>
						<asp:BoundColumn Visible="False" DataField="頁次" HeaderText="頁次"></asp:BoundColumn>
						<asp:BoundColumn DataField="合約書編號" HeaderText="合約書編號"></asp:BoundColumn>
						<asp:BoundColumn DataField="落版序號" HeaderText="落版序號"></asp:BoundColumn>
						<asp:BoundColumn DataField="刊登年月" HeaderText="刊登年月"></asp:BoundColumn>
						<asp:BoundColumn DataField="刊登頁碼" HeaderText="刊登頁碼"></asp:BoundColumn>
						<asp:BoundColumn DataField="廣告色彩" HeaderText="廣告色彩"></asp:BoundColumn>
						<asp:BoundColumn DataField="廣告篇幅" HeaderText="廣告篇幅"></asp:BoundColumn>
						<asp:BoundColumn DataField="廣告版面" HeaderText="廣告版面"></asp:BoundColumn>
						<asp:BoundColumn DataField="固定頁次註記" HeaderText="固定頁次">
							<ItemStyle HorizontalAlign="Center">
							</ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="公司名稱" HeaderText="公司名稱"></asp:BoundColumn>
						<asp:BoundColumn DataField="新稿製法" HeaderText="新稿製法"></asp:BoundColumn>
						<asp:BoundColumn DataField="到稿註記" HeaderText="到稿註記"></asp:BoundColumn>
						<asp:BoundColumn DataField="改稿書籍代碼" HeaderText="改稿書籍"></asp:BoundColumn>
						<asp:BoundColumn DataField="改稿期別" HeaderText="改稿期別"></asp:BoundColumn>
						<asp:BoundColumn DataField="改稿頁碼" HeaderText="改稿頁碼"></asp:BoundColumn>
						<asp:BoundColumn DataField="改稿重出片註記" HeaderText="改稿重出片註記"></asp:BoundColumn>
						<asp:BoundColumn DataField="舊稿書籍名稱" HeaderText="舊稿書籍"></asp:BoundColumn>
						<asp:BoundColumn DataField="舊稿期別" HeaderText="舊稿期別"></asp:BoundColumn>
						<asp:BoundColumn DataField="舊稿頁碼" HeaderText="舊稿頁碼"></asp:BoundColumn>
						<asp:BoundColumn DataField="落版業務員姓名" HeaderText="落版業務員"></asp:BoundColumn>
						<asp:BoundColumn DataField="備註" HeaderText="備註"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="美編樣後修改註記">
							<ItemTemplate>
								<asp:CheckBox id="cbxUpdate" runat="server" Checked='<%# GetfgUpdate(DataBinder.Eval(Container.DataItem, "美編樣後修改註記")) %>'></asp:CheckBox>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:datagrid>
				<br>
				<br>
				<asp:button id="btnUpdate" runat="server" Text="確認更新"></asp:button>
				<FONT face="新細明體">&nbsp;
					<asp:Button id="btnCancel" runat="server" Text="取消回首頁"></asp:Button>
				</FONT>
				<br>
			</form>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</CENTER>
	</body>
</HTML>
