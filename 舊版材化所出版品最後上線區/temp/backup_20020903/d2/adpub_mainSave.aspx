<%@ Page language="c#" Codebehind="adpub_mainSave.aspx.cs" Src="adpub_mainSave.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_mainSave" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>廣告落版資料維護 - 由年月落版進入 步驟三: 儲存修改之確認</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<!-- 頁首 Header -->
		<!-- 目前所在位置 -->
		<CENTER>
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							落版處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							廣告落版資料的維護: 由年月落版進入&nbsp;步驟三: 儲存修改之確認</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="adpub_mainSave" method="post" runat="server">
				<!-- Form按鈕 -->
				<DIV align="center">
					<input id="btnCancel" onclick='javascritp:window.location.href="..default.aspx"' type="button" value="回首頁" name="btnCancel">
				</DIV>
			</form>
			<br>
			<!-- 頁尾 Footer -->
		</CENTER>
	</BODY>
</HTML>
