<%@ Page language="c#" Codebehind="adlprior_get.aspx.cs" Src="adlprior_get.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adlprior_get" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>顯示 版面優先次序 資料</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<!-- Run at Server Form -->
		<form id="adlprior_get" method="post" runat="server">
			<TABLE id="tbItems" cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
				<!-- DataGrid: 自資料庫抓最新資料 -->
				<TR>
					<TD width="5%">
						&nbsp;
					</TD>
					<TD>
						<!-- 操作說明 -->
						<font color="blue" size="2">操作說明：預設帶入
							<asp:Label id="lblBookName" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:Label>
							<FONT color="#8b0000">&nbsp;</FONT>之資料.</font>
						<br>
						<font color="blue" size="2">請按下 "<FONT color="darkred"><U>關閉視窗</U></FONT>" 按鈕, 
							來關閉此視窗!</font>
						<br>
					</TD>
				</TR>
				<TR>
					<TD width="5%">
						&nbsp;
					</TD>
					<TD vAlign="top" width="*">
						<asp:datagrid id="DataGrid1" runat="server" BorderColor="Black" AutoGenerateColumns="False">
							<HeaderStyle HorizontalAlign="Center" ForeColor="White" BackColor="#214389"></HeaderStyle>
							<AlternatingItemStyle BackColor="#E2EAFC"></AlternatingItemStyle>
							<ItemStyle BackColor="#BFCFF0"></ItemStyle>
							<Columns>
								<asp:BoundColumn DataField="lp_priorseq" HeaderText="排版優先次序">
									<ItemStyle HorizontalAlign="Center">
									</ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ltp_nm" HeaderText="廣告版面"></asp:BoundColumn>
								<asp:BoundColumn DataField="clr_nm" HeaderText="廣告色彩"></asp:BoundColumn>
								<asp:BoundColumn DataField="pgs_nm" HeaderText="廣告篇幅"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="lp_bkcd" HeaderText="書籍代碼"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="lp_ltpcd" HeaderText="廣告版面代碼"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="lp_clrcd" HeaderText="廣告色彩代碼"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="lp_pgscd" HeaderText="廣告篇幅代碼"></asp:BoundColumn>
							</Columns>
						</asp:datagrid>
						<!-- 資料筆數 -->
						<FONT color="#333333">
							<asp:label id="lblResult" runat="server" ForeColor="HotPink"></asp:label>
							(共有
							<asp:label id="lblNum" runat="server" ForeColor="Red"></asp:label>
							筆資料 )</FONT>
					</TD>
				</TR>
				<!-- 關閉視窗按鈕 -->
				<TR>
					<TD>
						&nbsp;
					</TD>
					<TD>
						<br>
						<INPUT id="btn_close" onclick="Javascript: window.close();" type="button" value="關閉視窗" name="btn_close" Height="18px">
						&nbsp;
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
