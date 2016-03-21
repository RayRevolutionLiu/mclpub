<%@ Page language="c#" Codebehind="lostbk_label.aspx.cs" Src="lostbk_label.aspx.cs" AutoEventWireup="false" Inherits="MRLPub_d2.lostbk_label" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>缺書標籤</title>
		<META NAME="Programmer" Content="Jean Chen">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK REL="stylesheet" HREF="../UserControl/mrlpub.css" Type="text/css" Title="Style">
	</HEAD>
	<BODY ondblclick="doReOrder()" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
		<center>
			<!-- 頁首 Header -->
			<kw:header id="Header" runat="server">
			</kw:header>
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							缺書處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							缺書標籤</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- 標題 -->
			<DIV align="center">
				<B><FONT color="darkblue" size="5">缺書標籤</FONT></B>
			</DIV>
			<!-- Run at Server Form -->
			<form ID="lbl_lostbk" name="lbl_lostbk" method="post" runat="server">
				<!-- 暫時連結 Excel 檔 -->
				<a href="label.aspx" class="external">參考樣章</a>
				<br>
			</form>
			<br>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
	</BODY>
</HTML>
