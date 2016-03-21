<%@ Page debug="true" language="c#" Codebehind="adlprior_addnew.aspx.cs" Src="adlprior_addnew.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adlprior_addnew" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>版面優先次序 - 新增</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
		<script language="javascript">
		<!--
		// <IMG class="ico" title="書籍期別參考資料" ...> 按鈕的 coding: 依刊登年月顯示其書籍期別
		function doGetLPrior(obj)
		{
			var myObject = new Object();
			myObject.flag=true;
			
			// 指定傳過去的變數 - 抓出 書籍類別代碼 & 刊登年月, 來找出 書籍期別
			var bkcd = document.all("ddlBookCode").value;
			myObject.bkcd = document.all("ddlBookCode").value;
			
			// 開啟視窗對話框, 最後將值傳入 myObject
			var PageName = "adlprior_get.aspx?bkcd=" + bkcd;
			vreturn=window.open(PageName,  '_new', 'Height=320, Width=280, Top=120, Left=490, toolbar=no, scrollbars=yes, status=no, resizable=no'); 
		}
		//-->
		</script>
	</HEAD>
	<body>
		<center>
			<!-- 頁首 Header -->
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle" bgColor="#e7ebff">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							相關維護區 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							版面優先次序 - 新增</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="adlprior_addnew" method="post" runat="server"> <!-- 修改 Table -->
				<TABLE cellSpacing="1" cellPadding="3" width="90%" bgColor="#bfcff0" border="0">
					<TR bgColor="#214389">
						<TD colSpan="4">
							<FONT color="#ffffff">新增版面優先次序</FONT>
						</TD>
					</TR>
					<TR>
						<TD width="26%">
							&nbsp;<FONT color="#ff0000">* </FONT>書籍名稱:
						</TD>
						<TD width="50%">
							<asp:dropdownlist id="ddlBookCode" runat="server" AutoPostBack="True"></asp:dropdownlist>
							<br>
							<asp:label id="Label1" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD width="*" align="right">
							&nbsp;<FONT color="#ff0000">*</FONT>&nbsp;<FONT color="#8b4513">為必填欄位</FONT>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>欲插入的排版優先次序值: <IMG class="ico" id="imgLPrior" title="顯示版面優先次序資料" onclick="doGetLPrior(this)" src="../images/edit.gif" border="0">
						</TD>
						<TD colspan="2">
							<asp:textbox id="tbxPriorSeq" runat="server" MaxLength="2" Width="30px"></asp:textbox>
							&nbsp;
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;
						</TD>
						<TD colspan="2">
							<FONT color="#8b4513">註一：請輸入要取代的次序代碼! 本筆新增成功後, 將會取代舊的此次序代碼, 而舊的次序代碼將自動往後順延!
								<br>
								註二：如果您要參考原本資料庫中的 '排版優先次序', 請按下左方 <IMG class="ico" id="imgLPrior" title="顯示版面優先次序資料" onclick="doGetLPrior(this)" src="../images/edit.gif" border="0">圖示來參考!
								<br>
								如輸入 07, 表示此筆新增資料將為新次序07, 而原本舊次序值(07~)將自動往後順延 (變為 08~) </FONT>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>廣告版面:
						</TD>
						<TD colSpan="2">
							<asp:dropdownlist id="ddlLayoutTypeCode" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>廣告色彩:
						</TD>
						<TD colSpan="2">
							<asp:dropdownlist id="ddlColorCode" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD>
							&nbsp;<FONT color="#ff0000">* </FONT>廣告篇幅:
						</TD>
						<TD colSpan="2">
							<asp:dropdownlist id="ddPageSizeCode" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD colspan="3" align="right">
							<asp:button id="btnUpdate" runat="server" Text="確定新增" Height="24px"></asp:button>
							&nbsp;
							<asp:button id="btnReturnHome" runat="server" Text="放棄新增" Height="24px" CausesValidation="False"></asp:button>
							&nbsp; <INPUT id="btnCloseWin" name="btnCloseWin" type="button" value="關閉視窗" onclick="Javascript: window.close()">&nbsp;
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- 頁尾 Footer -->
		</center>
	</body>
</HTML>
