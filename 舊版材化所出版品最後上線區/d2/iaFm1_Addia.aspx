<%@ Page language="c#" Codebehind="iaFm1_Addia.aspx.cs" Src="iaFm1_Addia.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm1_Addia" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>發票開立單產生 - 一次付款 - 步驟二: 產生發票開立單</TITLE>
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
						發票處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						發票開立單產生 - 一次付款 - 步驟二: 產生發票開立單</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm1_Addia" method="post" runat="server">
			<asp:Label id="lblContNo" runat="server" Font-Size="X-Small"></asp:Label>
			&nbsp;
			<asp:Label id="lblIMSeq" runat="server" Font-Size="X-Small"></asp:Label>
			&nbsp;&nbsp;
			<asp:Label id="lblMessage" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
			<br>
			<asp:Label id="lblMfrCust" runat="server" Font-Size="X-Small" ForeColor="Maroon"></asp:Label>
			&nbsp;
			<asp:Button id="btnShowFullCont" runat="server" Text="顯示合約落版資料" Width="120px"></asp:Button>
			<asp:Literal id="litWinOpen1" runat="server"></asp:Literal>
			<asp:TextBox id="tbxCustNo" runat="server" Font-Size="X-Small" Width="60px" Visible="False"></asp:TextBox>
			&nbsp;
			<asp:TextBox id="tbxbkcd" runat="server" Font-Size="X-Small" Width="30px" Visible="False"></asp:TextBox>
			&nbsp;
			<asp:TextBox id="tbxfgpubed" runat="server" Font-Size="X-Small" Width="20px" Visible="False"></asp:TextBox>
			<br>
			<br>
			<asp:label id="lblMemo2" runat="server" Font-Size="X-Small" ForeColor="#C04000">操作步驟：請去除目前不要開立的資料 (被挑選者會被開立成同一張開立單), 先按 '確認金額', 再按下 '產生發票開立單' 按鈕來完成!</asp:label>
			<br>
			<asp:DataGrid id="DataGrid1" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False" AllowPaging="True">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<Columns>
					<asp:TemplateColumn HeaderText="挑選">
						<ItemTemplate>
							<asp:CheckBox id="cbxSelect" runat="server" Checked="True"></asp:CheckBox>
						</ItemTemplate>
					</asp:TemplateColumn>
					<asp:BoundColumn DataField="pub_yyyymm" HeaderText="刊登年月"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pubseq" HeaderText="落版序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_pgno" HeaderText="刊登頁碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="ltp_nm" HeaderText="廣告版面"></asp:BoundColumn>
					<asp:BoundColumn DataField="clr_nm" HeaderText="廣告色彩"></asp:BoundColumn>
					<asp:BoundColumn DataField="pgs_nm" HeaderText="廣告篇幅"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fgfixpg" HeaderText="固定頁次"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_drafttp" HeaderText="稿件類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fggot" HeaderText="到稿"></asp:BoundColumn>
					<asp:BoundColumn DataField="njtp_nm" HeaderText="新稿製法"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_chgbkcd" HeaderText="改稿書籍"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_chgjno" HeaderText="改稿期別"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_chgjbkno" HeaderText="改稿頁碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_fgrechg" HeaderText="改稿重出片"></asp:BoundColumn>
					<asp:BoundColumn DataField="bk_nm" HeaderText="舊稿書籍"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_origjno" HeaderText="舊稿期別"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_origjbkno" HeaderText="舊稿頁碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_adamt" HeaderText="廣告金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_chgamt" HeaderText="換稿金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="srspn_cname" HeaderText="落版業務員"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_remark" HeaderText="備註"></asp:BoundColumn>
					<asp:BoundColumn DataField="bk_nm" HeaderText="書籍名稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_projno" HeaderText="計劃代號"></asp:BoundColumn>
					<asp:BoundColumn DataField="pub_costctr" HeaderText="成本中心"></asp:BoundColumn>
				</Columns>
				<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
			</asp:DataGrid>
			<asp:Button id="btnConfirmAmt" runat="server" Text="確認金額"></asp:Button>
			<br>
			<br>
			<table width="100%" border="1" bordercolor="#336699" cellpadding="4" cellspacing="2">
				<tr>
					<td width="33%">
						<asp:Panel id="pnl1" runat="server" Font-Size="X-Small">
<asp:Label id="lblContMessage" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Underline="True">合約金額 資料：</asp:Label><BR>合約金額：$ 
<asp:Label id="lblContTotalAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>已繳金額：$ 
<asp:Label id="lblContPaidAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>剩餘金額：$ 
<asp:Label id="lblContRestAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
					</asp:Panel>
					</td>
					<td width="33%">
						<asp:Panel id="pnl2" runat="server" Font-Size="X-Small">
<asp:Label id="lblPickMessage" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Underline="True">已挑選金額 資料：</asp:Label><BR>總廣告金額：$ 
<asp:Label id="lblPickAdAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR><U>總換稿金額：</U>$ 
<asp:Label id="lblPickChgAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>已挑選小計：$ 
<asp:Label id="lblPickTotalAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
</asp:Panel>
					</td>
					<td width="*">
						<asp:Panel id="pnl3" runat="server" Font-Size="X-Small">
<asp:Label id="lblNewContMessage" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Underline="True">將更新之合約金額 資料：</asp:Label><BR>合約金額：$ 
<asp:Label id="lblNewContTotalAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>已繳金額：$ 
<asp:Label id="lblNewContPaidAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>剩餘金額：$ 
<asp:Label id="lblNewContRestAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label>
</asp:Panel>
					</td>
				</tr>
			</table>
			<asp:Button id="btnAddia" runat="server" Text="產生發票開立單"></asp:Button>
			&nbsp;&nbsp;
			<asp:Button id="btnModifyCont" runat="server" Text="修改合約書"></asp:Button>
			&nbsp;
			<asp:Button id="btnModifyPub" runat="server" Text="修改落版"></asp:Button>
			<asp:TextBox id="tbxIANo" runat="server" Font-Size="X-Small" Width="100px" Visible="False"></asp:TextBox>
		</form>
		<br>
		<!-- 頁尾 Footer -->
		<center>
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
