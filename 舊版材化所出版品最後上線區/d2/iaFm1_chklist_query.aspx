<%@ Page language="c#" Codebehind="iaFm1_chklist_query.aspx.cs" Src="iaFm1_chklist_query.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm1_chklist_query" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>發票開立單檢核表 - 一次付款 - 步驟一: 查詢畫面</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
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
				<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						發票處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						發票開立單檢核表 - 一次付款 - 步驟一: 查詢畫面</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm1_chklist_query" method="post" runat="server">
			<asp:panel id="pnlSearch" runat="server" Font-Size="X-Small">
<asp:CheckBox id="cbx1" runat="server"></asp:CheckBox>
<asp:Label id="lblMfrIName" runat="server" Font-Size="X-Small" ForeColor="Maroon">廠商名稱：</asp:Label>
<asp:TextBox id="tbxMfrIName" runat="server" Font-Size="X-Small" MaxLength="50" Width="120px"></asp:TextBox>
<asp:label id="lblMfrNo" runat="server" Font-Size="X-Small" ForeColor="#C00000"></asp:label>
<asp:TextBox id="tbxMfrNo" runat="server" Font-Size="X-Small" Width="80px" Visible="False"></asp:TextBox><BR>
<asp:CheckBox id="cbx2" runat="server"></asp:CheckBox>
<asp:Label id="lblIMName" runat="server" Font-Size="X-Small" ForeColor="Maroon">發票廠商收件人姓名：</asp:Label>
<asp:TextBox id="tbxIMName" runat="server" MaxLength="30" Width="60px"></asp:TextBox><BR>
<asp:checkbox id="cbx3" runat="server"></asp:checkbox>
<asp:label id="lblIANo" runat="server" Font-Size="X-Small" ForeColor="Maroon">發票開立單號碼：</asp:label>
<asp:textbox id="tbxIANo" runat="server" MaxLength="8" Width="80px"></asp:textbox>&nbsp;&nbsp; 
<asp:Button id="btnQuery" runat="server" Text="查詢"></asp:Button>
<asp:Button id="btnClear" runat="server" Text="清除資料"></asp:Button><BR>
<asp:Label id="lblMessage" runat="server" Font-Size="X-Small" ForeColor="Blue"></asp:Label></asp:panel><br>
			<asp:label id="lblMemo1" runat="server" Font-Size="X-Small" ForeColor="#C04000">操作步驟 1：請挑選要檢核的合約書編號及發票廠商收件人, 再按下 '確認挑選' 按鈕!</asp:label><br>
			<asp:label id="lblMemo2" runat="server" Font-Size="X-Small" ForeColor="#C04000">操作步驟 2：請挑選要檢核的發票開立單編號, 再按下 '確認挑選' 按鈕!</asp:label><br>
			<asp:DataGrid id="DataGrid1" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False" AllowPaging="True">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<Columns>
					<asp:ButtonColumn Text="確認挑選" ButtonType="PushButton" HeaderText="挑選" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="im_imseq" HeaderText="發廠序號">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="im_nm" HeaderText="發廠收件人">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_inm" HeaderText="廠商名稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="bk_nm" HeaderText="書籍類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_conttp" HeaderText="合約類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_signdate" HeaderText="簽約日期"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_sdate" HeaderText="合約起日"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_edate" HeaderText="合約迄日"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_custno" HeaderText="客戶編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="cust_nm" HeaderText="客戶名稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_totjtm" HeaderText="總製稿"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_tottm" HeaderText="總刊登"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_totamt" HeaderText="總金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_paidamt" HeaderText="已付金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_restamt" HeaderText="剩餘金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_fgclosed" HeaderText="結案"></asp:BoundColumn>
					<asp:BoundColumn DataField="srspn_cname" HeaderText="承辦業務員"></asp:BoundColumn>
					<asp:BoundColumn Visible="False" DataField="cont_fgclosed" HeaderText="結案註記"></asp:BoundColumn>
				</Columns>
				<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
			</asp:DataGrid>
			<br>
			<asp:TextBox id="tbxContNo" runat="server" Font-Size="X-Small" MaxLength="6" Width="60px" Visible="False"></asp:TextBox>
			<asp:TextBox id="tbxIMSeq" runat="server" Font-Size="X-Small" Width="30px" Visible="False"></asp:TextBox>
			<asp:TextBox id="tbxIMName2" runat="server" Font-Size="X-Small" Width="80px" Visible="False"></asp:TextBox><br>
			<asp:DataGrid id="DataGrid2" runat="server" AllowPaging="True" AutoGenerateColumns="False" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="2">
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<Columns>
					<asp:ButtonColumn Text="確認挑選" ButtonType="PushButton" HeaderText="挑選" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="ia_iano" HeaderText="發票開立單編號">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ia_mfrno" HeaderText="廠商編號">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_inm" HeaderText="廠商名稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rnm" HeaderText="發票收件人">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rjbti" HeaderText="稱謂"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rzip" HeaderText="郵遞區號"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_raddr" HeaderText="發票郵寄地址"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rtel" HeaderText="電話"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invcd" HeaderText="發票類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_taxtp" HeaderText="發票課稅別"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_status" HeaderText="目前狀態"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invno" HeaderText="發票號碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_status" HeaderText="目前狀態"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_pyat" HeaderText="含稅(實付)金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_contno" HeaderText="合約編號"></asp:BoundColumn>
				</Columns>
				<PagerStyle NextPageText="下一頁" PrevPageText="上一頁" HorizontalAlign="Right" ForeColor="#003399" Position="Top" BackColor="#99CCCC"></PagerStyle>
			</asp:DataGrid>
		</form>
		<br>
		<!-- 頁尾 Footer -->
		<center>
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
