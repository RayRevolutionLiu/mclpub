<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="ORMtpCounts_stat.aspx.cs" Src="ORMtpCounts_stat.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ORMtpCounts_stat" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>印製份數統計表</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<center>
			<!-- 頁首 Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							統計表 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 印製份數統計表</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="ORMtpCounts_stat" method="post" runat="server">
				<!-- 查詢條件 Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" align="center" bgColor="#bfcff0">
					<TBODY>
						<tr bgColor="#214389">
							<td colSpan="2"><font color="white">查詢條件</font>
							</td>
						</tr>
						<TR>
							<TD width="*"><asp:checkbox id="cbx0" runat="server"></asp:checkbox><asp:label id="lblConttp" runat="server" Font-Size="X-Small">合約類別：</asp:label><asp:dropdownlist id="ddlConttp" runat="server">
									<asp:ListItem Value="01" Selected="True">一般</asp:ListItem>
									<asp:ListItem Value="09">推廣</asp:ListItem>
								</asp:dropdownlist><br>
								<asp:label id="lblBookCode" runat="server">書籍類別：</asp:label><asp:dropdownlist id="ddlBookCode" runat="server">
									<asp:ListItem Value="00" Selected="True">請選擇...</asp:ListItem>
									<asp:ListItem Value="01">工材</asp:ListItem>
									<asp:ListItem Value="02">電材</asp:ListItem>
									<asp:ListItem Value="04">電材叢書</asp:ListItem>
									<asp:ListItem Value="05">材料</asp:ListItem>
								</asp:dropdownlist><br>
								<br>
								<asp:label id="lblPubDate" runat="server">刊登年月：</asp:label><asp:textbox id="tbxPubDate" runat="server" Width="60px"></asp:textbox>&nbsp;<font color="maroon" size="2">(如 
									2002/08, 預設值: 當月)</font><br>
								<asp:label id="lblCountType" runat="server" Font-Size="X-Small">當月 有登本數／未登本數：</asp:label><asp:dropdownlist id="ddlPubCountType" runat="server">
									<asp:ListItem Value="1" Selected="True">有登本數</asp:ListItem>
									<asp:ListItem Value="2">未登本數</asp:ListItem>
								</asp:dropdownlist>&nbsp;<font color="maroon" size="2">(請選擇!)</font><br>
								<asp:checkbox id="cbx1" runat="server"></asp:checkbox><asp:label id="lblfgMOSea" runat="server" Font-Size="X-Small">郵寄地區：</asp:label><asp:dropdownlist id="ddlfgMOSea" runat="server">
									<asp:ListItem Value="0" Selected="True">國內</asp:ListItem>
									<asp:ListItem Value="1">國外</asp:ListItem>
								</asp:dropdownlist>&nbsp; 
								<!-- 查詢按鈕 --><asp:linkbutton id="lnbShow" runat="server">查詢</asp:linkbutton><FONT color="#800000" size="2">&nbsp;
									<asp:linkbutton id="lnbClearAll" runat="server">清除重查</asp:linkbutton></FONT><br>
								<!-- 查詢結果顯示 --><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
							<TD vAlign="top" align="left" width="50%"><asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. 請輸入任一關鍵詞來查詢, 然後按下 "查詢".<br>
2. 出現結果後, 您可按下 "<font color="blue">列印本頁</font>" 來列印結果!</asp:label><asp:textbox id="tbxLoginEmpNo" runat="server" Width="50px" Font-Size="X-Small" Visible="False"></asp:textbox><asp:textbox id="tbxLoginEmpCName" runat="server" Width="60px" Font-Size="X-Small" Visible="False"></asp:textbox></TD>
						</TR>
						<TR>
							<TD bgColor="#ffffff" colSpan="2">&nbsp;
							</TD>
						</TR>
					</TBODY>
				</TABLE>
				<asp:panel id="pnlCounts" runat="server">
					<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="2" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
						<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
						<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
						<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
						<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
						<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
						<Columns>
							<asp:BoundColumn DataField="cont_conttpName" HeaderText="合約類別"></asp:BoundColumn>
							<asp:BoundColumn DataField="bk_nm" HeaderText="書籍名稱"></asp:BoundColumn>
							<asp:BoundColumn DataField="pub_yyyymm" HeaderText="刊登年月"></asp:BoundColumn>
							<asp:BoundColumn DataField="mtp_nm" HeaderText="郵寄類別名稱"></asp:BoundColumn>
							<asp:BoundColumn DataField="or_pubcnt" HeaderText="有登本數"></asp:BoundColumn>
							<asp:BoundColumn DataField="or_unpubcnt" HeaderText="未登本數"></asp:BoundColumn>
							<asp:BoundColumn DataField="PubCounts" HeaderText="份數">
								<ItemStyle ForeColor="Red"></ItemStyle>
							</asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="cont_conttp" HeaderText="合約類別代碼"></asp:BoundColumn>
							<asp:BoundColumn Visible="False" DataField="or_mtpcd" HeaderText="郵寄類別代碼"></asp:BoundColumn>
						</Columns>
						<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
					</asp:datagrid>
					<BR>
					<INPUT id="btnPrint" onclick="Javascript:window.print();" type="button" value="列印本頁" name="btnPrint"></asp:panel>
			</form>
			<br>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
