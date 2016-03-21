<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="adpub_main21.aspx.cs" Src="adpub_main21.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_main21" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>廣告落版資料維護 - 由年月落版進入 步驟一</TITLE>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<BODY bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
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
							落版處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							廣告落版資料的維護: 由年月落版進入&nbsp;步驟一</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- 標題 -->
			<DIV align="center">
				<FONT color="darkred" size="3">&nbsp;(步驟一: 搜尋及修改落版資料</FONT><FONT color="darkred" size="3">
					)</FONT></B>
				<br>
				<br>
			</DIV>
			<!-- Run at Server Form -->
			<form id="adpub_main21" name="adpub_main21" method="post" runat="server">
				<!-- 查詢條件 Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td colSpan="2">
							<font color="white">查詢條件</font>
						</td>
					</tr>
					<TR>
						<TD>
							合約編號：<asp:textbox id="tbxContNo" runat="server" AutoPostBack="True" tabIndex="5" Width="60px"></asp:textbox>
							&nbsp;
							<br>
							<br>
							刊登年月：
							<asp:textbox id="tbxPubDate" runat="server" Width="60px"></asp:textbox>
							&nbsp; 
							<!-- 查詢按鈕 -->
							<asp:linkbutton id="lnbShow" runat="server">查詢</asp:linkbutton>
							&nbsp; 
							<!-- 查詢結果顯示 -->
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
							<br>
							(請輸入 4~6碼數字, 如2002年 1月, 請輸入 200201)
						</TD>
						<td>
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. 請輸入關鍵詞來查詢, 然後按下 "查詢".<br>
							2. 查出資料後, 按下 "修改落版" 來修改資料.<br>3. 查詢結果不包含已結案的資料.<br> 4. 若不知欲修改之合約書編號, 可由 此連結<br> &nbsp;&nbsp;&nbsp;&nbsp; <A href="cont_main1.aspx" target="_self">
									合約書處理/一般合約/合約書維護</A> 來查詢修改.</asp:label>
						</td>
					</TR>
					<TR>
						<td colSpan="2">
							<asp:datagrid id="DataGrid1" Runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False" AllowPaging="True">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<Columns>
									<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_yyyymm" HeaderText="刊登年月"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_pubseq" HeaderText="落版序號"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" HeaderText="公司名稱"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_custno" HeaderText="客戶編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" HeaderText="客戶姓名"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_tel" HeaderText="聯絡電話"></asp:BoundColumn>
									<asp:BoundColumn DataField="cont_fgclosed" HeaderText="已結案"></asp:BoundColumn>
									<asp:ButtonColumn Text="修改落版" ButtonType="PushButton" CommandName="OK"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
						</td>
					</TR>
				</TABLE>
				<asp:literal id="literal1" Runat="server"></asp:literal>
			</form>
			<br>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
	</BODY>
</HTML>
