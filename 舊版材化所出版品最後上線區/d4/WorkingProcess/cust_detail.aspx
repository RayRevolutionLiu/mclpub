<%@ Page language="c#" Codebehind="cust_detail.aspx.cs" Src="cust_detail.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.cust_detail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<!-- 標題 -->
		<DIV align="left">
			<B><FONT color="darkblue" size="4">客戶之細節資訊</FONT></B>&nbsp;
		</DIV>
		<br>
		<form id="cust_detail" method="post" runat="server">
			<!-- Table 開始: 細節資訊 -->
			<TABLE class="TableColor" style="WIDTH: 90%" cellSpacing="0" cellPadding="4" border="1">
				<!-- Table Title -->
				<tr>
					<td colSpan="4" class="TableColorHeader">
						廠商資料(ID=
						<asp:label id="lblMfrID" runat="server"></asp:label>
						)
					</td>
				</tr>
				<TR>
					<TD class="TableColor" noWrap align="right">
						公司名稱：
						<br>
						(發票抬頭)
					</TD>
					<TD bgColor="#ecebff" colSpan="3">
						<asp:label id="lblMfrIName" runat="server"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD class="TableColor" noWrap align="right">
						統一編號：
					</TD>
					<TD bgColor="#ecebff">
						<asp:label id="lblMfrNo" runat="server"></asp:label>
					</TD>
					<TD class="TableColor" noWrap align="right">
						廠商聯絡電話：
					</TD>
					<TD bgColor="#ecebff">
						<asp:Label id="lblMfrTel" runat="server"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD class="TableColor" noWrap align="right">
						地址：
					</TD>
					<TD bgColor="#ecebff" colSpan="3">
						<asp:label id="lblMfrIZipcode" runat="server"></asp:label>
						&nbsp;
						<asp:label id="lblMfrIAddr" runat="server"></asp:label>
					</TD>
				</TR>
				<!-- 細節資訊開始 -->
				<tr>
					<td colSpan="4" class="TableColorHeader">
						客戶資料(ID=
						<asp:label id="lblCustID" runat="server"></asp:label>
						)
					</td>
				</tr>
				<TR>
					<TD class="TableColor" noWrap align="right">
						姓名及編號：
					</TD>
					<TD bgColor="#ecebff" nowrap>
						<asp:label id="lblCustName" runat="server" ForeColor="Red"></asp:label>
						&nbsp;(
						<asp:Label id="lblCustNo" runat="server" ForeColor="Red"></asp:Label>
						)
					</TD>
					<TD class="TableColor" noWrap align="right">
						職稱：
					</TD>
					<TD bgColor="#ecebff">
						<asp:label id="lblCustJobTitle" runat="server"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD class="TableColor" noWrap align="right">
						註冊日期：
					</TD>
					<TD bgColor="#ecebff">
						<asp:label id="lblCustRegDate" runat="server"></asp:label>
					</TD>
					<TD class="TableColor" noWrap align="right">
						修改日期：
					</TD>
					<TD bgColor="#ecebff">
						<asp:label id="lblCustModDate" runat="server"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD class="TableColor" noWrap align="right">
						電話：
					</TD>
					<TD bgColor="#ecebff">
						<asp:label id="lblCustTel" runat="server"></asp:label>
					</TD>
					<TD class="TableColor" noWrap align="right">
						傳真：
					</TD>
					<TD bgColor="#ecebff">
						<asp:label id="lblCustFax" runat="server"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD class="TableColor" noWrap align="right">
						手機：
					</TD>
					<TD bgColor="#ecebff">
						<asp:label id="lblCustCell" runat="server"></asp:label>
					</TD>
					<TD class="TableColor" noWrap align="right">
						Email：
					</TD>
					<TD bgColor="#ecebff">
						<asp:label id="lblCustEmail" runat="server"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD class="TableColor" noWrap align="right">
						客戶領域：
					</TD>
					<TD bgColor="#ecebff" colspan="3">
						<asp:Label id="lblCustItpcd" runat="server"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD class="TableColor" noWrap align="right">
						客戶營業：
					</TD>
					<TD bgColor="#ecebff" colspan="3">
						<asp:Label id="lblCustBtpcd" runat="server"></asp:Label>
					</TD>
				</TR>
				<TR>
					<TD class="TableColor" noWrap align="right">
						客戶閱讀：
					</TD>
					<TD bgColor="#ecebff" colspan="3">
						<asp:Label id="lblCustRtpcd" runat="server"></asp:Label>
					</TD>
				</TR>
			</TABLE>
			<br>
			<INPUT id="btn_close" onclick="Javascript: window.close()" type="button" value="關閉視窗" name="btn_close">
		</form>
	</body>
</HTML>
