<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="or.aspx.cs" Src="or.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.or" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>雜誌收件人 - 資料瀏覽</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
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
			<!-- 頁首 Header -->
			<kw:header id="Header" runat="server">
			</kw:header>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="or" method="post" runat="server">
				<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
					<!-- 目前所在位置 & Query Line -->
					<TR>
						<TD width="5%">
							&nbsp;
						</TD>
						<TD vAlign="top" width="*">
							<FONT title="書籍資料維護" color="#333333"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;平面廣告次系統
								<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 相關維護區
								<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 雜誌收件人 
								- 資料瀏覽 (
								<asp:label id="lblResult" runat="server" ForeColor="HotPink"></asp:label>
								共有
								<asp:label id="lblNum" runat="server" ForeColor="Red"></asp:label>
								筆資料 )</FONT>
							<asp:label id="lblState" runat="server" ForeColor="DeepPink"></asp:label>
							</FONT>
						</TD>
					</TR>
					<!-- DataGrid: 自資料庫抓最新資料 -->
					<TR>
						<TD>
							&nbsp;
						</TD>
						<TD vAlign="top">
							<asp:datagrid id="DataGrid1" runat="server" BorderColor="Black" AutoGenerateColumns="False" AllowPaging="True" PageSize="10">
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
								<PagerStyle NextPageText="下一頁" PrevPageText="上一頁"></PagerStyle>
								<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
								<ItemStyle BackColor="#BFCFF0"></ItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="or_orid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_contno" HeaderText="合約書編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_signdate" HeaderText="簽約日期"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_fgclosed" HeaderText="結案"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_oritem" HeaderText="序號"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_nm" HeaderText="姓名"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_jbti" HeaderText="職稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_tel" HeaderText="電話"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_cell" HeaderText="手機"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
									<asp:BoundColumn DataField="mtp_nm" HeaderText="郵寄類別代碼"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_pubcnt" HeaderText="有登本數">
										<ItemStyle HorizontalAlign="Right">
										</ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="or_unpubcnt" HeaderText="未登本數">
										<ItemStyle HorizontalAlign="Right">
										</ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="or_fgmosea" HeaderText="海外郵寄">
										<ItemStyle HorizontalAlign="Center">
										</ItemStyle>
									</asp:BoundColumn>
									<asp:ButtonColumn Text="修改" ButtonType="PushButton" HeaderText="修改" CommandName="Select"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
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
								<asp:ListItem Value="or_contno" Selected="True">合約書編號</asp:ListItem>
								<asp:ListItem Value="or_oritem">序號</asp:ListItem>
								<asp:ListItem Value="or_nm">姓名</asp:ListItem>
								<asp:ListItem Value="or_tel">電話</asp:ListItem>
								<asp:ListItem Value="mtp_nm">郵寄類別名稱</asp:ListItem>
							</asp:dropdownlist>
							<asp:button id="Query" runat="server" Height="23px" Font-Size="9pt" Text="開始搜尋"></asp:button>
							<asp:button id="btnShowAll" runat="server" Height="23px" Font-Size="9pt" Text="全部顯示"></asp:button>
							&nbsp;&nbsp;&nbsp;
							<asp:button id="btnReturnHome" runat="server" Height="23px" Font-Size="9pt" Text="回系統首頁"></asp:button>
						</TD>
						<TD height="36">
							&nbsp;
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
	</body>
</HTML>
