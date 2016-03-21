<%@ Page language="c#" Codebehind="ContFm_chk1.aspx.cs" Src="ContFm_chk1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ContFm_chk1" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>合約書 錯誤資料清單</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<!-- 頁首 Header -->
		<center>
			<kw:header id="Header" runat="server"></kw:header>
		</center>
		<!-- 目前所在位置 -->
		<table dataFld="items" id="tbItems" style="WIDTH: 739px">
			<tr>
				<td style="WIDTH: 100%" align="left">
					<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						合約處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						合約書 錯誤資料清單</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="ContFm_chk1" method="post" runat="server">
			請選擇您要查詢的項目：<asp:DropDownList id="ddlFilter" runat="server">
				<asp:ListItem Value="1">彩套黑次數皆為０</asp:ListItem>
				<asp:ListItem Value="2">承辦業務員資料不對應</asp:ListItem>
			</asp:DropDownList>
			<asp:Button id="btnQuery" runat="server" Text="查詢"></asp:Button>
			&nbsp;
			<asp:Button id="btnClearAll" runat="server" Text="清除重查"></asp:Button>
			<br>
			<asp:Label id="lblMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:Label>
			<br>
			<br>
			<!-- 頁尾 Footer -->
			<asp:datagrid id="DataGrid1" Runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False" AllowPaging="True">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="合約編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_conttp" HeaderText="合約類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="bk_nm" HeaderText="書籍類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_sdate" HeaderText="合約起日"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_edate" HeaderText="合約迄日"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_signdate" HeaderText="簽約日期"></asp:BoundColumn>
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
					<asp:BoundColumn DataField="srspn_cname" HeaderText="業務員"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="cont_oldcontno" HeaderText="舊合約編號"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="cont_custno" HeaderText="客戶編號"></asp:BoundColumn>
					<asp:ButtonColumn Text="顯示合約歷史" CommandName="Show"></asp:ButtonColumn>
					<asp:ButtonColumn Text="確定修改" ButtonType="PushButton" CommandName="Modify"></asp:ButtonColumn>
				</Columns>
			</asp:datagrid>
			<asp:Literal id="Literal1" runat="server"></asp:Literal>
		</form>
		<!-- 頁尾 Footer -->
		<center>
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
