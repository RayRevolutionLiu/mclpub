<%@ Page language="c#" Codebehind="lostbk_list.aspx.cs" Src="lostbk_list.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.lostbk_list" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>缺書清單</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript-->
		<script language="javascript">
		<!--
		// cal按鈕的 coding: 抓系統日期
		function pick_date(theField)
		{
			// 簽約日期
			var oParam = new Object();
			strFeature = "";
			strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
			var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
			//alert("vreturn= " + vreturn);
			
			window.document.all(theField).value=vreturn;
			return true;
		}
		//-->
		</script>
	</HEAD>
	<body>
		<center>
			<!-- 頁首 Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" style="WIDTH: 739px">
				<tr>
					<td style="WIDTH: 100%" align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							缺書處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							缺書清單</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form-->
			<form id="lostbk_list" method="post" runat="server">
				<!-- 查詢條件 Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" align="center" bgColor="#bfcff0">
					<TBODY>
						<tr bgColor="#214389">
							<td colSpan="2">
								<font color="white">查詢條件</font>
							</td>
						</tr>
						<TR>
							<TD width="*">
								<asp:CheckBox id="cbx0" runat="server"></asp:CheckBox>
								<asp:Label id="lblfgSent" runat="server">寄書狀況：</asp:Label>
								<asp:DropDownList id="ddlfgSent" runat="server" AutoPostBack="True">
									<asp:ListItem Value="C">已寄出</asp:ListItem>
									<asp:ListItem Value="N">尚未寄出</asp:ListItem>
									<asp:ListItem Value="All">全部</asp:ListItem>
								</asp:DropDownList>
								<br>
								<br>
								<asp:CheckBox id="cbx1" runat="server"></asp:CheckBox>
								<asp:Label id="lblBkcd" runat="server">書籍類別：</asp:Label>
								<asp:DropDownList id="ddlBookCode" runat="server"></asp:DropDownList><br>
								<asp:checkbox id="cbx2" runat="server"></asp:checkbox>
								<asp:Label id="lblLostDate" runat="server">缺書日期區間：</asp:Label>
								<asp:textbox id="tbxLostDate1" runat="server" Width="65px" MaxLength="10"></asp:textbox>
								<IMG class="ico" title="日曆" onclick="pick_date(tbxLostDate1.name)" src="../images/calendar01.gif">
								&nbsp;～&nbsp;
								<asp:textbox id="tbxLostDate2" runat="server" Width="65px" MaxLength="10"></asp:textbox>
								<IMG class="ico" title="日曆" onclick="pick_date(tbxLostDate2.name)" src="../images/calendar01.gif">
								<br>
								<asp:checkbox id="cbx3" runat="server"></asp:checkbox>
								<asp:Label id="lblContSignDate" runat="server">合約簽約日期區間：</asp:Label>
								<asp:textbox id="tbxContSignDate1" runat="server" Width="65px" MaxLength="10"></asp:textbox>
								<IMG class="ico" title="日曆" onclick="pick_date(tbxContSignDate1.name)" src="../images/calendar01.gif">
								&nbsp;～&nbsp;
								<asp:textbox id="tbxContSignDate2" runat="server" Width="65px" MaxLength="10"></asp:textbox>
								<IMG class="ico" title="日曆" onclick="pick_date(tbxContSignDate2.name)" src="../images/calendar01.gif">&nbsp;&nbsp;&nbsp; 
								&nbsp;&nbsp; 
								<!-- 查詢按鈕 -->
								<asp:linkbutton id="lnbShow" runat="server">查詢</asp:linkbutton>&nbsp;&nbsp;
								<asp:linkbutton id="lnbClearAll" runat="server">清除重查</asp:linkbutton>
								<br>
								<!-- 查詢結果顯示 -->
								<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>&nbsp;&nbsp;
								<asp:Button id="btnPrintList" runat="server" Text="列印清單"></asp:Button>&nbsp;
								<br>
							</TD>
							<TD vAlign="top" align="left" width="50%">
								<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. 請輸入任一關鍵詞來查詢, 然後按下 "查詢".<br>
2. 出現結果後, 請再按下 "<font color="Gray">列印清單</font>" 來繼續!</asp:label>
								<asp:TextBox id="tbxLoginEmpNo" runat="server" Width="50px" Font-Size="X-Small" Visible="False"></asp:TextBox>
								<asp:TextBox id="tbxLoginEmpCName" runat="server" Width="60px" Font-Size="X-Small" Visible="False"></asp:TextBox>
								<asp:Literal id="Literal1" runat="server"></asp:Literal>
							</TD>
						</TR>
						<TR>
							<TD bgColor="#ffffff" colSpan="2">
								&nbsp;
							</TD>
						</TR>
					</TBODY>
				</TABLE>
			</form>
			<br>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
