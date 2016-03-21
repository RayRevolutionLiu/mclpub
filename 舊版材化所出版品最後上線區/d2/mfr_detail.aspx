<%@ Page language="c#" Codebehind="mfr_detail.aspx.cs" Src="mfr_detail.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.mfr_detail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>廠商之細節資料</TITLE>
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
			<B><FONT color="darkblue" size="4">廠商之細節資訊</FONT></B>&nbsp;
		</DIV>
		<br>
		<!-- Run at Server Form -->
		<form id="mfr_detail" method="post" runat="server">
			<!-- Table 開始: 細節資訊 -->
			<TABLE style="WIDTH: 80%" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
				<!-- Table Title -->
				<tr bgColor="#214389">
					<td colSpan="4">
						<font color="white">廠商資料</font> <FONT color="#ffffff">(ID=
							<asp:label id="lblMfrID" runat="server"></asp:label>
							)</FONT>
					</td>
				</tr>
				<!-- 細節資訊開始 -->
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						公司名稱：
						<br>
						(發票抬頭)
					</TD>
					<TD class="cssData" colSpan="3">
						<asp:label id="lblMfrIName" runat="server" ForeColor="Red"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						統一編號：
					</TD>
					<TD class="cssData">
						<asp:label id="lblMfrNo" runat="server" ForeColor="Red"></asp:label>
					</TD>
					<TD class="cssTitle" noWrap align="right">
						註冊日期：
					</TD>
					<TD class="cssData">
						<asp:label id="lblMfrRegDate" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						負責人姓名：
					</TD>
					<TD class="cssData">
						<asp:label id="lblMfrRespName" runat="server"></asp:label>
					</TD>
					<TD class="cssTitle" noWrap align="right">
						負責人職稱：
					</TD>
					<TD class="cssData">
						<asp:label id="lblMfrRespJobTitle" runat="server"></asp:label>
					</TD>
				</TR>
				<TR vAlign="center">
					<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
						電話：
					</TD>
					<TD class="cssData">
						<asp:label id="lblMfrTel" runat="server"></asp:label>
					</TD>
					<TD class="cssTitle" noWrap align="right">
						傳真：
					</TD>
					<TD class="cssData">
						<asp:label id="lblMfrFax" runat="server"></asp:label>
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
			</TABLE>
			<br>
			<INPUT id="btn_close" onclick="Javascript: window.close()" type="button" value="關閉視窗" name="btn_close">
		</form>
		<!-- 頁尾 Footer -->
	</body>
</HTML>
