<%@ Page language="c#" Codebehind="pub_new1.aspx.cs" Src="pub_new1.aspx.cs"  AutoEventWireup="false" Inherits="MRLPub.d2.pub_new1" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>落版: 新增/維護/刪除落版 - 由合約書進入 步驟一 (挑選合約書)</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<center>
			<!-- 頁首 Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="center">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							合約處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							落版: 新增/維護/刪除落版 - 由合約書進入&nbsp;步驟一 (挑選合約書)</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="pub_new1" method="post" runat="server">
				<!-- 查詢條件 Table -->
				<TABLE style="WIDTH: 96%" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<TR bgColor="#214389">
						<td colSpan="2">
							<font color="white">查詢條件</font>
						</td>
					</TR>
					<TR>
						<TD>
							公司名稱：
							<asp:textbox id="tbxMfrName" tabIndex="1" runat="server" Width="150px" AutoPostBack="True"></asp:textbox>
						</TD>
						<TD vAlign="top" rowSpan="4">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. 請輸入任一關鍵詞來查詢, 然後按下 "查詢".<br> 2. 查詢結果不包含<font color="red">
									已結案／已註銷</font>的合約資料.<br><font color="gray">註: 避免重覆新增廠商資料 -
									<br>
									請先 '輸入<U>廠商統一編號</U>後, 按下<U>旁邊的按鈕</U>來查詢!</font><br> 3. 此查詢結果將串接至 "合約書處理/一般合約/合約書維護".</asp:label>
						</TD>
					</TR>
					<TR>
						<TD>
							統一編號：
							<asp:textbox id="tbxMfrNo" tabIndex="2" runat="server" Width="60px" AutoPostBack="True" MaxLength="10"></asp:textbox>
							&nbsp; <IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(tbxMfrNo.Text.ToString().Trim()); %>', '_new', 'Height=300, Width=400, Top=100, Left=200, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="查詢廠商" src="../images/edit.gif" width="18" border="0">
						</TD>
					</TR>
					<TR>
						<TD noWrap>
							客戶編號：
							<asp:textbox id="tbxCustNo" tabIndex="3" runat="server" Width="45px" AutoPostBack="True" MaxLength="6"></asp:textbox>
							&nbsp;(須正確的值)
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							客戶姓名：
							<asp:textbox id="tbxCustName" tabIndex="4" runat="server" Width="80px" AutoPostBack="True" MaxLength="30"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							<FONT color="red">*</FONT>合約編號：
							<asp:textbox id="tbxContNo" runat="server" AutoPostBack="True" tabIndex="5" Width="80px" MaxLength="6"></asp:textbox>&nbsp; 
							<!-- 查詢按鈕 -->
							<asp:linkbutton id="lnbShow" runat="server">查詢</asp:linkbutton>&nbsp; 
							<!-- 查詢結果顯示 -->
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<!-- 新增廠商或客戶 -->
						<td>
						</td>
					</TR>
					<TR>
						<td colSpan="2">
							<asp:datagrid id="DataGrid1" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#3366CC"
								BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="2" Runat="server">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399"
									Position="Top" BackColor="#99CCCC"></PagerStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<Columns>
									<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="合約編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_conttp" HeaderText="合約類別"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="cont_bkcd" HeaderText="書籍代碼"></asp:BoundColumn>
									<asp:BoundColumn DataField="bk_nm" HeaderText="書籍類別"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_sdate" HeaderText="合約起日"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_edate" HeaderText="合約迄日"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" HeaderText="公司名稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_custno" HeaderText="客戶編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" HeaderText="客戶姓名"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_tel" HeaderText="聯絡電話"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_oldcustno" HeaderText="舊客戶編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_fgpubed" HeaderText="已落版"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="cont_fgpubed" HeaderText="已落版代碼"></asp:BoundColumn>
									<asp:ButtonColumn Text="落版" ButtonType="PushButton" CommandName="OK"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</TR>
				</TABLE>
				<asp:literal id="literal1" Runat="server"></asp:literal>
			</form>
			<br>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
