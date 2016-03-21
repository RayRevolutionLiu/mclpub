<%@ Page language="c#" Codebehind="adlprior.aspx.cs" Src="adlprior.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adlprior" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>版面優先次序 - 資料瀏覽</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
		<script language="JScript">
			function Delete_confirm(e) {
				if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="刪除")
					event.returnValue=confirm("是否確定刪除?")
			}
			document.onclick=Delete_confirm;
		</script>
	</HEAD>
	<body>
		<center>
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>&nbsp; 
			<!-- Run at Server Form -->
			<form id="adlprior" method="post" runat="server">
				<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<!-- 目前所在位置 & Query Line -->
					<TR>
						<TD width="5%">
							&nbsp;
						</TD>
						<TD vAlign="top" width="*">
							<FONT title="書籍資料維護" color="#333333"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;平面廣告次系統
								<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 相關維護區
								<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 版面優先次序 
								- 資料瀏覽 (
								<asp:label id="lblResult" runat="server" ForeColor="HotPink"></asp:label>
								共有
								<asp:label id="lblNum" runat="server" ForeColor="Red"></asp:label>
								筆資料 )</FONT>
							<asp:label id="lblState" runat="server" ForeColor="DeepPink"></asp:label></FONT>
						</TD>
					</TR>
					<!-- 備註 -->
					<TR>
						<TD align="left" colSpan="2">
							<font color="darkred" size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;註：為避免舊資料讀取錯誤，若該筆已被使用(筆數&gt;0)，將不允許修改/刪除！</font>
						</TD>
					</TR>
					<!-- DataGrid: 自資料庫抓最新資料 -->
					<TR>
						<TD>
							&nbsp;
						</TD>
						<TD vAlign="top">
							<asp:datagrid id="DataGrid1" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="Black">
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
								<PagerStyle NextPageText="下一頁" PrevPageText="上一頁"></PagerStyle>
								<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
								<ItemStyle BackColor="#BFCFF0"></ItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="lp_lpid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
									<asp:BoundColumn DataField="bk_nm" HeaderText="書籍名稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="lp_priorseq" HeaderText="排版優先次序">
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ltp_nm" HeaderText="廣告版面"></asp:BoundColumn>
									<asp:BoundColumn DataField="clr_nm" HeaderText="廣告色彩"></asp:BoundColumn>
									<asp:BoundColumn DataField="pgs_nm" HeaderText="廣告篇幅"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="lp_bkcd" HeaderText="書籍代碼"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="lp_ltpcd" HeaderText="廣告版面代碼"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="lp_clrcd" HeaderText="廣告色彩代碼"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="lp_pgscd" HeaderText="廣告篇幅代碼"></asp:BoundColumn>
									<asp:BoundColumn DataField="PubCounts" HeaderText="已使用之落版筆數"></asp:BoundColumn>
									<asp:ButtonColumn Text="修改" ButtonType="PushButton" HeaderText="修改" CommandName="Select"></asp:ButtonColumn>
									<asp:ButtonColumn Text="刪除" ButtonType="PushButton" HeaderText="刪除" CommandName="Delete"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
						</TD>
					</TR>
					<!-- 備註 -->
					<TR>
						<TD align="left" colSpan="2">
							<font color="darkred" size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;註：為避免舊資料讀取錯誤，若該筆已被使用(筆數&gt;0)，將不允許修改/刪除！</font>
						</TD>
					</TR>
					<!-- 搜尋資料功能 -->
					<TR>
						<TD>
							&nbsp;
							<br>
							<br>
						</TD>
						<TD>
							<br>
							<br>
							<asp:textbox id="tbxQString" runat="server" Width="96px"></asp:textbox>
							<asp:dropdownlist id="ddlQueryField" runat="server">
								<asp:ListItem Value="bk_nm" Selected="True">書籍名稱</asp:ListItem>
								<asp:ListItem Value="lp_priorseq">排版優先次序</asp:ListItem>
								<asp:ListItem Value="ltp_nm">廣告版面</asp:ListItem>
								<asp:ListItem Value="clr_nm">廣告色彩</asp:ListItem>
								<asp:ListItem Value="pgs_nm">廣告篇幅</asp:ListItem>
							</asp:dropdownlist>
							<asp:button id="Query" runat="server" Text="開始搜尋" Font-Size="9pt" Height="23px"></asp:button>
							<asp:button id="btnShowAll" runat="server" Text="全部顯示" Font-Size="9pt" Height="23px"></asp:button>
							&nbsp; &nbsp;
							<asp:button id="btnAddNew" runat="server" Text="新增資料" Font-Size="9pt" Height="23px"></asp:button>
							<asp:button id="btnReturnHome" runat="server" Text="回系統首頁" Font-Size="9pt" Height="23px"></asp:button>
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
