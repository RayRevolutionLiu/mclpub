<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="cont_main2.aspx.cs" Src="cont_main2.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.cont_main2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>維護合約書 步驟二</TITLE>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<kw:header id="Header" runat="server"></kw:header>
		<!-- 目前所在位置 -->
		<center>
			<table dataFld="items" id="tbItems" style="WIDTH: 739px; HEIGHT: 24px">
				<tr>
					<td style="WIDTH: 100%" align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							合約處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							維護合約書 步驟二: 挑出該客戶的歷史合約書資料</font>
					</td>
				</tr>
			</table>
			<!-- Run at Server Form -->
			<form id="cont_main2" method="post" runat="server">
				<A id="goback" href="cont_main1.aspx?function1=main&amp;conttp=01">回查詢畫面</A>&nbsp; 
				&nbsp;
				<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
				&nbsp;&nbsp;
				<asp:button id="btnNew" runat="server" Text="新增空白合約書" Visible="False"></asp:button>
				<br>
				<asp:Label id="lblCaption" runat="server" ForeColor="#C00000" Font-Size="X-Small"></asp:Label>
				<asp:datagrid id="dgdCont" runat="server" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="4" AutoGenerateColumns="False" PageSize="8" AllowPaging="True">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="合約編號"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_conttp" HeaderText="合約類別"></asp:BoundColumn>
						<asp:BoundColumn DataField="bk_nm" HeaderText="書籍類別"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_signdate" HeaderText="簽約日期"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_sdate" HeaderText="合約起日"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_edate" HeaderText="合約迄日"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_inm" HeaderText="公司名稱"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_aunm" HeaderText="廣告聯絡人姓名"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_autel" HeaderText="廣告聯絡人電話"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_fgpayonce" HeaderText="一次付清"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_fgclosed" HeaderText="已結案"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_disc" HeaderText="優惠折數"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_clrtm" HeaderText="彩色次數"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_getclrtm" HeaderText="套色次數"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_menotm" HeaderText="黑白次數"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_fgpubed" HeaderText="已落版"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_fgcancel" HeaderText="已註銷"></asp:BoundColumn>
						<asp:ButtonColumn Text="顯示合約歷史" CommandName="Detail"></asp:ButtonColumn>
						<asp:ButtonColumn Text="確定修改" ButtonType="PushButton" CommandName="OK"></asp:ButtonColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
				<font size="2" color="Gray">註：已結案的合約，將不允許 "修改"，只能檢視其資料(顯示合約歷史)！</font><br>
				<asp:Label id="lblRemark" runat="server" ForeColor="#004040">&nbsp;</asp:Label>
				<asp:literal id="literal1" runat="server"></asp:literal>
			</form>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
