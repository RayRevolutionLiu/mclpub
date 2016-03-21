<%@ Page language="c#" Codebehind="lostbk.aspx.cs" Src="lostbk.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.lostbk" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>缺書 - 資料瀏覽</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
			<!-- Run at Server Form -->
			<form id="lostbk" method="post" runat="server">
				<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
					<!-- 目前所在位置 & Query Line -->
					<TR>
						<TD width="5%">
							&nbsp;
						</TD>
						<TD vAlign="top" width="*">
							<FONT title="書籍資料維護" color="#333333"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">&nbsp;平面廣告次系統
								<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 相關維護區
								<IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 缺書 - 
								資料瀏覽 (
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
							<asp:datagrid id="DataGrid1" runat="server" PageSize="10" AllowPaging="True" AutoGenerateColumns="False" BorderColor="Black">
								<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
								<PagerStyle NextPageText="下一頁" PrevPageText="上一頁"></PagerStyle>
								<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
								<ItemStyle BackColor="#BFCFF0"></ItemStyle>
								<Columns>
									<asp:BoundColumn Visible="False" DataField="lst_lstid" ReadOnly="True" HeaderText="ID"></asp:BoundColumn>
									<asp:BoundColumn DataField="lst_contno" HeaderText="合約書編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_signdate" HeaderText="簽約日期"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_fgclosed" HeaderText="結案"></asp:BoundColumn>
									<asp:BoundColumn DataField="lst_oritem" HeaderText="收件人序號"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_nm" HeaderText="收件人姓名"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_tel" HeaderText="收件人電話"></asp:BoundColumn>
									<asp:BoundColumn DataField="lst_seq" HeaderText="缺書序號"></asp:BoundColumn>
									<asp:BoundColumn DataField="lst_cont" HeaderText="缺書內容"></asp:BoundColumn>
									<asp:BoundColumn DataField="lst_date" HeaderText="缺書日期"></asp:BoundColumn>
									<asp:BoundColumn DataField="lst_rea" HeaderText="缺書原因"></asp:BoundColumn>
									<asp:BoundColumn DataField="lst_fgsent" HeaderText="已寄出註記">
										<ItemStyle HorizontalAlign="Center">
										</ItemStyle>
									</asp:BoundColumn>
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
								<asp:ListItem Value="lst_contno" Selected="True">合約書編號</asp:ListItem>
								<asp:ListItem Value="or_nm">收件人姓名</asp:ListItem>
								<asp:ListItem Value="or_tel">收件人電話</asp:ListItem>
								<asp:ListItem Value="lst_date">缺書日期</asp:ListItem>
							</asp:dropdownlist>
							<asp:button id="Query" runat="server" Text="開始搜尋" Font-Size="9pt" Height="23px"></asp:button>
							<asp:button id="btnShowAll" runat="server" Text="全部顯示" Font-Size="9pt" Height="23px"></asp:button>
							&nbsp;&nbsp;&nbsp;
							<asp:button id="btnReturnHome" runat="server" Text="回系統首頁" Font-Size="9pt" Height="23px"></asp:button>
						</TD>
						<TD>
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
