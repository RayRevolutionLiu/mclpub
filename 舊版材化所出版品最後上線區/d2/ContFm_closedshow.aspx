<%@ Page language="c#" Codebehind="ContFm_closedshow.aspx.cs" Src="ContFm_closedshow.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ContFm_closedshow" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>顯示已結案合約書</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
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
							合約處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							顯示已結案合約書</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="ContFm_closedshow" method="post" runat="server">
				<!-- 查詢條件 Table -->
				<TABLE style="WIDTH: 96%" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<TR bgColor="#214389">
						<TD colSpan="2">
							<font color="white">查詢條件</font>
						</TD>
					</TR>
					<TR>
						<TD>
							公司名稱：
							<asp:textbox id="tbxMfrName" tabIndex="1" runat="server" AutoPostBack="True" Width="150px"></asp:textbox>
						</TD>
						<TD vAlign="top" rowSpan="4">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. 請輸入任一關鍵詞來查詢, 然後按下 "查詢".<br> 2. 查詢結果不包含<font color='Red'>
									未結案</font> 的資料.<br><font color="gray">註: 避免重覆新增廠商資料 -
									<br>
									請先 '輸入<U>廠商統一編號</U>後, 按下<U>旁邊的按鈕</U>來查詢!</font><br> 3. 此查詢結果將串接至 "合約書處理/落版/顯示合約及落版資料".<br> 4. 若您想顯示所有資料, 請勿輸入任何查詢關鍵字, <br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;直接按下 "查詢" 即可得到全部資料.</asp:label>
						</TD>
					</TR>
					<TR>
						<TD>
							統一編號：
							<asp:textbox id="tbxMfrNo" tabIndex="2" runat="server" AutoPostBack="True" Width="60px" MaxLength="10"></asp:textbox>
							&nbsp; <IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(tbxMfrNo.Text.ToString().Trim()); %>', '_new', 'Height=300, Width=400, Top=100, Left=200, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="查詢廠商" src="../images/edit.gif" width="18" border="0">
						</TD>
					</TR>
					<TR>
						<TD noWrap>
							客戶編號：
							<asp:textbox id="tbxCustNo" tabIndex="3" runat="server" AutoPostBack="True" Width="45px" MaxLength="6"></asp:textbox>
							&nbsp;(須正確的值)
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							客戶姓名：
							<asp:textbox id="tbxCustName" tabIndex="4" runat="server" AutoPostBack="True" Width="80px" MaxLength="30"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD>
							<FONT color="red">*</FONT>合約編號：
							<asp:textbox id="tbxContNo" tabIndex="5" runat="server" AutoPostBack="True" Width="80px" MaxLength="6"></asp:textbox>
							&nbsp; 
							<!-- 查詢按鈕 --><asp:linkbutton id="lnbShow" runat="server">查詢</asp:linkbutton>&nbsp;
							<asp:LinkButton id="lnbClear" runat="server">清除重查</asp:LinkButton>
							<br>
							<!-- 查詢結果顯示 --><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD>
							&nbsp;
						</TD>
					</TR>
					<TR>
						<TD colSpan="2">
							<asp:datagrid id="DataGrid1" Runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False" AllowPaging="True">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
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
									<asp:BoundColumn DataField="cont_fgcancel" HeaderText="已註銷"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_fgpubed" HeaderText="已落版"></asp:BoundColumn>
									<asp:ButtonColumn Text="顯示合約書" ButtonType="PushButton" CommandName="OK"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
						</TD>
					</TR>
				</TABLE>
				<asp:literal id="literal1" Runat="server"></asp:literal>
			</form>
			<br>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
	</body>
</HTML>
