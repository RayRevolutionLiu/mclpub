<%@ Page Language="c#" CodeBehind="Default.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.CDefault" %>
<%@ Register TagPrefix="kw" TagName="Header" Src="usercontrol/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="Footer" Src="usercontrol/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="Welcome" Src="welcome.ascx" %>
<HTML>
	<HEAD>
		<TITLE>�i���Ʃ� �X���~�Ȥ�޲z�t�Ρj ����</TITLE>
		<META http-equiv="Content-Language" Content="zh-tw">
		<META http-equiv="Content-Type" Content="text/html" Charset="BIG5">
		<META NAME="GENERATOR" Content="Ultra Editor v8.0">
		<META NAME="Programmer" Content="Kevin Wei">
		<!-- CSS -->
		<LINK REL="stylesheet" HREF="usercontrol/mrlpub.css" Type="text/css" Title="Style">
			<!-- Javascript -->
			<!-- check if the browser support JavaScript or not -->
			<noscript>
			Your browser does not support JavaScript. Please update it as soon as soon as possible!
		</noscript>
	</HEAD>
	<BODY>
		<CENTER>
			<!-- place contents here -->
			<!-- ���Y: �D�\���� -->
			<kw:Header runat="server" />
			<!-- welcome -->
			<kw:Welcome runat="server" />
			<!-- ���: ���v�� -->
			<kw:Footer runat="server" />
		</CENTER>
	</BODY>
</HTML>
