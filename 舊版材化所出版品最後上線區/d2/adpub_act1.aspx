<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="adpub_act1.aspx.cs" Src="adpub_act1.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_act1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>廣告排版動作 步驟一 / 美編樣後修正 步驟一</title>
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
			<kw:header id="Header" runat="server"></kw:header>
			<!-- 目前所在位置 -->
			<table dataFld="items" id="tbItems" align="left">
				<tr>
					<td align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							落版處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							廣告排版動作 步驟一 / 美編樣後修正 步驟一</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="adpub_act1" method="post" runat="server">
				<!-- 查詢條件 Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" align="center" bgColor="#bfcff0">
					<tr bgColor="#214389">
						<td colSpan="2">
							<font color="white">查詢條件</font>
						</td>
					</tr>
					<TR>
						<TD width="*">
							書籍類別：
							<asp:dropdownlist id="ddlBookCode" runat="server">
								<asp:ListItem Value="00" Selected="True">請選擇...</asp:ListItem>
								<asp:ListItem Value="01">工材</asp:ListItem>
								<asp:ListItem Value="02">電材</asp:ListItem>
								<asp:ListItem Value="04">電材叢書</asp:ListItem>
								<asp:ListItem Value="05">材料</asp:ListItem>
							</asp:dropdownlist>
							<br>
							<br>
							刊登年月：
							<asp:textbox id="tbxPubDate" runat="server" Width="60px"></asp:textbox>&nbsp; 
							<!-- 查詢按鈕 -->
							<asp:linkbutton id="lnbShow" runat="server">查詢</asp:linkbutton>&nbsp;&nbsp;
							<asp:linkbutton id="lnbClearAll" runat="server">清除重查</asp:linkbutton>
							<br>
							<font color="gray">(請輸入 6碼年月, 如2002年 1月, 請輸入&nbsp;2002/01)</font>
							<br>
							<br>
							<!-- 查詢結果顯示 -->
							<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
						</TD>
						<TD vAlign="top" align="left" width="50%">
							<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. 請輸入任一關鍵詞來查詢, 然後按下 "查詢".<br>
								2. 出現結果後, 若有錯誤資料, 將要求先修正; <br>&nbsp;&nbsp;&nbsp;&nbsp;若無錯誤落版資料, 請再按下 "<font color="blue">
									<U>此連結</U></font>" 來進行排版動作!</asp:label>
						</TD>
					</TR>
					<TR>
						<TD bgColor="#ffffff" colSpan="2">&nbsp;
							<asp:RegularExpressionValidator id="revPubDate" runat="server" ErrorMessage="'刊登年月' 請依格式填入(請參旁邊文字說明)!!!" ControlToValidate="tbxPubDate" ValidationExpression="\d{4}/\d{2}" Font-Size="X-Small"></asp:RegularExpressionValidator>
						</TD>
					</TR>
					<TR>
						<TD bgColor="#ffffff" colSpan="2">
							<asp:datagrid id="DataGrid1" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="2" Runat="server">
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<Columns>
									<asp:BoundColumn DataField="pub_contno" HeaderText="合約書編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_pubseq" HeaderText="落版序號"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_ltpcd" HeaderText="廣告版面"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_clrcd" HeaderText="廣告色彩"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_pgscd" HeaderText="廣告篇幅"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_fggot" HeaderText="到稿"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_drafttp" HeaderText="稿件類別"></asp:BoundColumn>
									<asp:ButtonColumn Text="修改落版資料" ButtonType="PushButton" HeaderText="修改落版資料" CommandName="Select"></asp:ButtonColumn>
								</Columns>
							</asp:datagrid>
						</TD>
					</TR>
					<TR>
						<TD bgColor="#ffffff" colSpan="2">
							<asp:datagrid id="DataGrid2" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="2" Runat="server">
								<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
								<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
								<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
								<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
								<Columns>
									<asp:BoundColumn DataField="pub_contno" HeaderText="合約書編號"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_yyyymm" HeaderText="刊登年月"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_pubseq" HeaderText="落版序號"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_pgno" HeaderText="刊登頁碼">
										<ItemStyle ForeColor="Red"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="pub_fgfixpg" HeaderText="固定頁次">
										<ItemStyle ForeColor="Red"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="pub_ltpcd" HeaderText="廣告版面">
										<ItemStyle ForeColor="Blue"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="pub_clrcd" HeaderText="廣告色彩"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_pgscd" HeaderText="廣告篇幅"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_fggot" HeaderText="到稿"></asp:BoundColumn>
									<asp:BoundColumn DataField="pub_drafttp" HeaderText="稿件類別"></asp:BoundColumn>
									<asp:ButtonColumn Text="修改落版資料" ButtonType="PushButton" HeaderText="修改落版資料" CommandName="Select"></asp:ButtonColumn>
								</Columns>
								<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
							</asp:datagrid>
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</BODY>
</HTML>
