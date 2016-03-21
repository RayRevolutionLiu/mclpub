<%@ Page language="c#" Codebehind="ORForm.aspx.cs" Src="ORForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ORForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>新增 雜誌收件人資料</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="ORForm" method="post" runat="server">
			<!-- 雜誌收件人 歷史資料 區 -->
			<font size="2" color="#ff0066">[雜誌收件人 歷史資料 區]</font>
			<br>
			History DataGrid
			<br>
			<!-- 雜誌收件人 新增/儲存資料 區 -->
			<font size="2" color="#ff0066">[雜誌收件人 新增/儲存資料 區]</font>
			<br>
			<TABLE id="tblAdd" style="FONT-SIZE: x-small" borderColor="#bfcff0" cellSpacing="0" cellPadding="0" bgColor="#bfcff0" border="1">
				<THEAD>
					<TR>
						<TH>
							系統
							<br>
							代碼
						</TH>
						<TH>
							合約書
							<br>
							編號
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>公司名稱
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>姓名
						</TH>
						<TH>
							職稱
						</TH>
						<TH>
							電話
						</TH>
						<TH>
							有登
							<br>
							本數
						</TH>
						<TH>
							未登
							<br>
							本數
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>郵寄類別
						</TH>
						<TH>
							<FONT color="#c00000" size="2">*</FONT>海外
							<br>
							郵寄
						</TH>
					</TR>
				</THEAD>
				<TBODY>
					<TR bgColor="#e2eafc">
						<TD>
							<asp:textbox id="tbxORSysCode" runat="server" MaxLength="2" WIDTH="30px" Font-Size="X-Small" Enabled="False">C2</asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORContNo" runat="server" MaxLength="6" WIDTH="50px" Font-Size="X-Small" Enabled="False"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORMfrIName" runat="server" MaxLength="50" Width="80px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORName" runat="server" MaxLength="30" Width="70px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORJobTitle" runat="server" MaxLength="12" Width="70px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORTel" runat="server" MaxLength="30" WIDTH="90px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORPubCount" runat="server" MaxLength="3" WIDTH="30px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORPubUnCount" runat="server" MaxLength="3" WIDTH="30px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:dropdownlist id="ddlORmtpcd" runat="server"></asp:dropdownlist>
						</TD>
						<TD>
							<asp:dropdownlist id="ddlORfgmosea" runat="server">
								<asp:ListItem Value="0" Selected="True">國內</asp:ListItem>
								<asp:ListItem Value="1">國外</asp:ListItem>
							</asp:dropdownlist>
						</TD>
					</TR>
					<!-- 第二行 -->
					<TR>
						<TH>
							&nbsp;
						</TH>
						<TH>
							郵遞
							<br>
							區號
						</TH>
						<TH colSpan="3">
							地址
						</TH>
						<TH>
							傳真
						</TH>
						<TH colSpan="2">
							手機
						</TH>
						<TH colSpan="2">
							Email
						</TH>
					</TR>
					<TR bgColor="#e2eafc">
						<TD>
							&nbsp;
						</TD>
						<TD>
							<asp:textbox id="tbxORZipcode" runat="server" MaxLength="5" Width="40px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD colSpan="3">
							<asp:textbox id="tbxORAddr" runat="server" MaxLength="120" WIDTH="230px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD>
							<asp:textbox id="tbxORFax" runat="server" MaxLength="30" WIDTH="90px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD colSpan="2">
							<asp:textbox id="tbxORCell" runat="server" MaxLength="30" WIDTH="80px" Font-Size="X-Small"></asp:textbox>
						</TD>
						<TD colSpan="2">
							<asp:textbox id="tbxOREmail" runat="server" MaxLength="80" WIDTH="160px" Font-Size="X-Small"></asp:textbox>
						</TD>
					</TR>
				</TBODY>
			</TABLE>
			<FONT color="#c00000" size="2">註1：* 為必填欄位!</FONT>
			<br>
			<FONT color="#c00000" size="2">註1：預設顯示之廠商資料為該客戶之廠商資料; 若須修改, 請自行修正!</FONT>
			<br>
			<br>
			<asp:button id="btnSave" runat="server" Text="儲存新增"></asp:button>
			&nbsp;&nbsp;
			<asp:Button id="btnModify" runat="server" Text="儲存修改"></asp:Button>
			<FONT face="新細明體">&nbsp;&nbsp; <INPUT id="btnClose" onclick="Javascript:window.close();" type="button" value="關閉視窗" name="btnClose"></FONT>
		</form>
	</body>
</HTML>
