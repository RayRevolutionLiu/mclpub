<%@ Page language="c#" Codebehind="cust_detail.aspx.cs" Src="cust_detail.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.cust_detail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>客戶之細節資訊</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<!-- 標題 -->
		<DIV align="left">
			<B><FONT color="darkblue" size="4">客戶之細節資訊</FONT></B>&nbsp;
		</DIV>
		<br>
		<!-- Run at Server Form -->
		<form id="cust_detail" method="post" runat="server">
			<!-- Table 開始: 細節資訊 -->
			<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
				<!-- Table Title -->
				<tr bgColor="#214389">
					<td colSpan="4">
						<font color="white">廠商資料</font> <FONT color="#ffffff">(ID=
							<asp:label id="lblMfrID" runat="server"></asp:label>
							)</FONT>
					</td>
				</tr>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						公司名稱：
						<br>
						(發票抬頭)
					</TD>
					<TD class="cssData" colSpan="3">
						<asp:label id="lblMfrIName" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						統一編號：
					</TD>
					<TD class="cssData">
						<asp:label id="lblMfrNo" runat="server"></asp:label>
					</TD>
					<TD class="cssTitle" noWrap align="right">
						廠商聯絡電話：
					</TD>
					<TD class="cssData">
						<asp:Label id="lblMfrTel" runat="server"></asp:Label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						地址：
					</TD>
					<TD class="cssData" colSpan="3">
						<asp:label id="lblMfrIZipcode" runat="server"></asp:label>
						&nbsp;
						<asp:label id="lblMfrIAddr" runat="server"></asp:label>
					</TD>
				</TR>
				<!-- 細節資訊開始 -->
				<tr bgColor="#214389">
					<td colSpan="4">
						<font color="white">客戶資料</font> <FONT color="#ffffff">(ID：
							<asp:label id="lblCustID" runat="server" Font-Size="X-Small"></asp:label>
							／舊客戶編號：
							<asp:Label id="lblOldCustNo" runat="server" Font-Size="X-Small"></asp:Label>
							)</FONT>
					</td>
				</tr>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						姓名及編號：
					</TD>
					<TD class="cssData" nowrap>
						<asp:label id="lblCustName" runat="server" ForeColor="Red"></asp:label>
						&nbsp;(
						<asp:Label id="lblCustNo" runat="server" ForeColor="Red"></asp:Label>
						)
					</TD>
					<TD class="cssTitle" noWrap align="right">
						職稱：
					</TD>
					<TD class="cssData">
						<asp:label id="lblCustJobTitle" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						註冊日期：
					</TD>
					<TD class="cssData">
						<asp:label id="lblCustRegDate" runat="server"></asp:label>
					</TD>
					<TD class="cssTitle" noWrap align="right">
						修改日期：
					</TD>
					<TD class="cssData">
						<asp:label id="lblCustModDate" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						電話：
					</TD>
					<TD class="cssData">
						<asp:label id="lblCustTel" runat="server"></asp:label>
					</TD>
					<TD class="cssTitle" noWrap align="right">
						傳真：
					</TD>
					<TD class="cssData">
						<asp:label id="lblCustFax" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						手機：
					</TD>
					<TD class="cssData">
						<asp:label id="lblCustCell" runat="server"></asp:label>
					</TD>
					<TD class="cssTitle" noWrap align="right">
						Email：
					</TD>
					<TD class="cssData">
						<asp:label id="lblCustEmail" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						客戶領域：
					</TD>
					<TD class="cssData" colspan="3">
						<asp:Label id="lblCustItpcd" runat="server"></asp:Label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						客戶營業：
					</TD>
					<TD class="cssData" colspan="3">
						<asp:Label id="lblCustBtpcd" runat="server"></asp:Label>
					</TD>
				</TR>
			</TABLE>
			<br>
			<INPUT id="btn_close" onclick="Javascript: window.close()" type="button" value="關閉視窗" name="btn_close">
		</form>
		<!-- 頁尾 Footer -->
	</body>
</HTML>
