<%@ Page language="c#" Codebehind="cont_SaveMessage.aspx.cs" Src="cont_SaveMessage.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.cont_SaveMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>執行動作 確認訊息顯示</TITLE>
		<META http-equiv="Content-Type" content="text/html; charset=big5">
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- 目前所在位置 -->
		<center>
			<table dataFld="items" id="tbItems" style="WIDTH: 739px; HEIGHT: 24px">
				<tr>
					<td style="WIDTH: 100%" align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							合約處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							執行動作 確認訊息顯示</font>
					</td>
				</tr>
			</table>
			<!-- Run at Server Form -->
			<form id="cont_mainSave" method="post" runat="server">
				<asp:Label id="lblMessage" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
				<br>
				<font size="3" color="#990033">請選擇繼續之動作：</font>
				<br>
				<br>
				<A id="hplNewCust" href="../d5/cust.aspx" runat="server">繼續新增客戶</A>
				<br>
				<br>
				<A id="hplMainCont" href="cont_main1.aspx?function1=mod&amp;conttp=01" runat="server">
					繼續維護其他合約書</A>&nbsp;&nbsp;&nbsp; <A id="hplNewCont" href="cont_new1.aspx?function1=new&amp;conttp=01" runat="server">
					繼續新增一合約書</A>&nbsp;&nbsp;&nbsp; <A id="hplAddia" href="ia.aspx?fgpayonce=1" runat="server">
					立即做 '開立發票' 動作(尚未完成)</A>&nbsp;&nbsp;&nbsp;<A id="hpladPubMain21" href="adpub_main21.aspx" runat="server">
					繼續維護其他廣告落版資料</A>
				<br>
				<br>
				<!-- form 按鈕 -->
				<input id="btnCancel" onclick='javascritp:window.location.href="http://140.96.18.18/mrlpub/"' type="button" value="返回首頁">
			</form>
			<!-- 頁尾 Footer -->
		</center>
	</body>
</HTML>
