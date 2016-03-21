<%@ Page language="c#" Codebehind="ramt_stat.aspx.cs" Src="ramt_stat.aspx.cs" AutoEventWireup="false" Inherits="MRLPub_d2.ramt_stat" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>秎盚セ计参璸</title>
		<META NAME="Programmer" Content="Jean Chen">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK REL="stylesheet" HREF="../UserControl/mrlpub.css" Type="text/css" Title="Style">
	</HEAD>
	<BODY>
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
		<center>
			<!--  Header -->
			<kw:header id="Header" runat="server">
			</kw:header>
			<!-- ヘ玡┮竚 -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							キ約Ω╰参 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							参璸 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 秎盚セ计参璸</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- Run at Server Form -->
			<form ID="ramt_stat" name="ramt_stat" method="post" runat="server">
				<!-- 縵匡兵ン, 肚跑计 -->
				<!-- 琩高兵ン Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" align="center" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td colSpan="2">
							<font color="white">琩高兵ン</font>
						</td>
					</tr>
					<TR>
						<TD>
							篒ゎる&nbsp;
							<asp:TextBox id="tbxYYYYMM" runat="server" Width="60px" MaxLength="6"></asp:TextBox>
							&nbsp;&nbsp;&nbsp;&nbsp; 
							<!-- 琩高秙 -->
							<asp:linkbutton id="lnbShow" runat="server">琩高</asp:linkbutton>
							&nbsp;
							<br>
							(叫块 4~6絏计, 2002 1る, 叫块 200201)
							<br>
							<br>
							<!-- 琩高挡狦陪ボ -->
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD vAlign="top" align="left">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">* 叫縵匡戈, 礛 "琩高".<br><br>
							</asp:label>
						</TD>
					</TR>
					<TR>
						<TD align="middle" bgColor="#ffffff" colSpan="2">
							&nbsp;
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- Ю Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
	</BODY>
</HTML>
