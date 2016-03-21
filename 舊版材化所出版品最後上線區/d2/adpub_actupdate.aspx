<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="adpub_actupdate.aspx.cs" Src="adpub_actupdate.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.adpub_actupdate" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>美編樣後修正 步驟二 (畫面同 廣告落版動作 步驟二)</title>
		<META content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<META content="C#" name="CODE_LANGUAGE">
		<META content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"> <!-- CSS --><LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<BODY>
		<CENTER>
			<!-- 頁首 Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<!-- 目前所在位置 -->
			<TABLE dataFld="items" id="tbItems" align="left">
				<TR>
					<TD align="left"><FONT color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							落版處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							美編樣後修改&nbsp; </FONT>
					</TD>
				</TR>
			</TABLE>
			&nbsp; 
			<!-- Run at Server Form -->
			<FORM id="adpub_actupdate" method="post" runat="server">
				<DIV align="left"><FONT color="#990033" size="2">操作說明：請輸入您要修改的資料, 最後按下網頁頁尾處的 '確認更新' 
						按鈕即可.
						<br>
						註： 新稿製法：請輸入 "代碼", 勿輸入其名稱; 若不知代碼, 可按右方圖示來參考!
						<br>
						註： 改稿重出片：若是重出, 請勾選; 否之, 請勿勾選</FONT>
				</DIV>
				<asp:literal id="litAlertWin" runat="server"></asp:literal><asp:datagrid id="DataGrid1" Runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False" AllowPaging="False">
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<Columns>
						<asp:BoundColumn Visible="False" DataField="頁次" HeaderText="頁次"></asp:BoundColumn>
						<asp:BoundColumn DataField="合約書編號" HeaderText="合約書編號"></asp:BoundColumn>
						<asp:BoundColumn DataField="刊登年月" HeaderText="刊登年月"></asp:BoundColumn>
						<asp:BoundColumn DataField="落版序號" HeaderText="落版序號"></asp:BoundColumn>
						<asp:BoundColumn DataField="刊登頁碼" HeaderText="刊登頁碼"></asp:BoundColumn>
						<asp:BoundColumn DataField="廣告版面" HeaderText="廣告版面"></asp:BoundColumn>
						<asp:BoundColumn DataField="廣告色彩" HeaderText="廣告色彩"></asp:BoundColumn>
						<asp:BoundColumn DataField="廣告篇幅" HeaderText="廣告篇幅"></asp:BoundColumn>
						<asp:BoundColumn DataField="固定頁次註記" HeaderText="固定頁次">
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="公司名稱" HeaderText="公司名稱"></asp:BoundColumn>
						<asp:BoundColumn DataField="到稿註記" HeaderText="到稿註記"></asp:BoundColumn>
						<asp:BoundColumn DataField="njtp_nostr" HeaderText="(參考新稿製法)"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="新稿製法代碼">
							<ItemStyle Width="55px"></ItemStyle>
							<ItemTemplate>
								<asp:TextBox id="tbxNjtpcd" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "新稿製法代碼").ToString().Trim() %>' MaxLength="2" Width="30px" Font-Size="X-Small" Visible='<%# GetVisiblity1(DataBinder.Eval(Container.DataItem, "稿件類別代碼").ToString().Trim()) %>' OnTextChanged='<%# CheckNjtpcd(DataBinder.Eval(Container.DataItem, "新稿製法代碼").ToString()) %>'>
								</asp:TextBox>
								<IMG class="ico" id="imgNjtpcd" onclick="javascript:window.open('njtp_detail.aspx', '_new', 'Height=300, Width=380, Top=100, Left=20, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt="新稿製法資料" src="../images/edit.gif" width="18" border="0">
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="改稿書籍代碼" HeaderText="改稿書籍"></asp:BoundColumn>
						<asp:BoundColumn DataField="改稿期別" HeaderText="改稿期別"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="改稿頁碼">
							<ItemTemplate>
								<asp:TextBox id="tbxChgJBkNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "改稿頁碼").ToString().Trim() %>' Visible='<%# GetVisiblity2(DataBinder.Eval(Container.DataItem, "稿件類別代碼").ToString().Trim()) %>' Width="30px" Font-Size="X-Small" MaxLength="3">
								</asp:TextBox>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:TemplateColumn HeaderText="改稿重出片">
							<ItemTemplate>
								<asp:CheckBox id="cbxfgReChg" runat="server" Checked='<%# GetfgReChg(DataBinder.Eval(Container.DataItem, "改稿重出片註記")) %>'>
								</asp:CheckBox>
							</ItemTemplate>
						</asp:TemplateColumn>
						<asp:BoundColumn DataField="舊稿書籍名稱" HeaderText="舊稿書籍"></asp:BoundColumn>
						<asp:BoundColumn DataField="舊稿期別" HeaderText="舊稿期別"></asp:BoundColumn>
						<asp:BoundColumn DataField="舊稿頁碼" HeaderText="舊稿頁碼"></asp:BoundColumn>
						<asp:BoundColumn DataField="落版業務員姓名" HeaderText="落版業務員"></asp:BoundColumn>
						<asp:BoundColumn DataField="備註" HeaderText="備註"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="稿件類別代碼" HeaderText="稿件類別"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="改稿頁碼" HeaderText="改稿頁碼"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="改稿重出片註記" HeaderText="改稿重出片註記"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="美編樣後修改註記" HeaderText="美編樣後修改註記"></asp:BoundColumn>
						<asp:TemplateColumn HeaderText="美編樣後修改">
							<ItemStyle Width="30px"></ItemStyle>
							<ItemTemplate>
								<asp:TextBox id="tbxfgupdated" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "美編樣後修改註記").ToString().Trim() %>' MaxLength="1" Width="20px" Font-Size="X-Small" Visible='<%# GetfgUpdated(DataBinder.Eval(Container.DataItem, "稿件類別代碼").ToString().Trim()) %>' OnTextChanged='<%# CheckfgUpdated(DataBinder.Eval(Container.DataItem, "美編樣後修改註記").ToString().Trim()) %>'>
								</asp:TextBox>
							</ItemTemplate>
						</asp:TemplateColumn>
					</Columns>
				</asp:datagrid><br>
				<br>
				<asp:button id="btnUpdate" runat="server" Text="確認更新"></asp:button>&nbsp;
				<asp:button id="btnCancel" runat="server" Text="取消回首頁"></asp:button><br>
			</FORM>
			<!-- 頁尾 Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</CENTER>
	</BODY>
</HTML>
