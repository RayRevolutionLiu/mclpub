<%@ Page language="c#" Codebehind="iaFm1_Recia.aspx.cs" Src="iaFm1_Recia.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm1_Recia" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>發票開立單回復(Recovery) - 一次付款 步驟二: 回復發票開立單</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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
						發票開立單回復(Recovery) - 一次付款 步驟二: 回復發票開立單</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm1_Recia" method="post" runat="server">
			<asp:label id="lblContNo" runat="server" Font-Size="X-Small"></asp:label>&nbsp;
			<asp:label id="lblIMSeq" runat="server" Font-Size="X-Small"></asp:label>&nbsp;&nbsp;
			<asp:label id="lblMessage" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:label><br>
			<asp:label id="lblMfrCust" runat="server" Font-Size="X-Small" ForeColor="Maroon"></asp:label>&nbsp;
			<asp:button id="btnShowFullCont" runat="server" Width="120px" Text="顯示合約落版資料"></asp:button><asp:literal id="litWinOpen1" runat="server"></asp:literal><asp:textbox id="tbxCustNo" runat="server" Font-Size="X-Small" Width="60px" Visible="False"></asp:textbox>&nbsp;
			<asp:textbox id="tbxbkcd" runat="server" Font-Size="X-Small" Width="30px" Visible="False"></asp:textbox>&nbsp;
			<asp:textbox id="tbxfgpubed" runat="server" Font-Size="X-Small" Width="20px" Visible="False"></asp:textbox><br>
			<br>
			<asp:label id="lblMemo2" runat="server" Font-Size="X-Small" ForeColor="#C04000">操作步驟：整張發票開立單並被回復, 請先按 '確認金額', 再按下 '回復發票開立單' 按鈕來完成!</asp:label><asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False">
				<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
				<Columns>
					<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="im_imseq" HeaderText="發廠序號">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="im_nm" HeaderText="發廠收件人">
						<ItemStyle ForeColor="Red"></ItemStyle>
					</asp:BoundColumn>
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
				</Columns>
			</asp:datagrid><br>
			<asp:label id="lblIAMessage" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:label><asp:datagrid id="DataGrid2" runat="server" Font-Size="8pt" AutoGenerateColumns="False" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="1">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="ia_iano" HeaderText="發票開立單編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
					<asp:BoundColumn DataField="mfr_inm" HeaderText="廠商名稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rnm" HeaderText="發票收件人"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rjbti" HeaderText="稱謂"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_raddr" HeaderText="發票郵寄地址">
						<HeaderStyle Wrap="False"></HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rzip" HeaderText="郵遞區號"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rtel" HeaderText="電話"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invcd" HeaderText="發票類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_taxtp" HeaderText="課稅別"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_iaditem" HeaderText="發票開立單明細序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk1" HeaderText="合約編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk2" HeaderText="刊登年月"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk3" HeaderText="落版序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_desc" HeaderText="品名"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_projno" HeaderText="計劃代號"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_costctr" HeaderText="成本中心"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_qty" HeaderText="數量"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_amt" HeaderText="金額"></asp:BoundColumn>
				</Columns>
			</asp:datagrid><br>
			<br>
			<table borderColor="#336699" cellSpacing="2" cellPadding="4" width="100%" border="1">
				<tr>
					<td width="33%"><asp:panel id="pnl1" runat="server" Font-Size="X-Small">
<asp:Label id="lblContMessage" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Underline="True">合約金額 資料：</asp:Label><BR>合約金額：$ 
<asp:Label id="lblContTotalAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>已繳金額：$ 
<asp:Label id="lblContPaidAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>剩餘金額：$ 
<asp:Label id="lblContRestAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label></asp:panel></td>
					<td width="33%"><asp:panel id="pnl2" runat="server" Font-Size="X-Small">
<asp:Label id="lblPickMessage" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Underline="True">本開立單總金額 資料：</asp:Label><BR>$ 
<asp:Label id="lblPickTotalAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label></asp:panel></td>
					<td width="*"><asp:panel id="pnl3" runat="server" Font-Size="X-Small">
<asp:Label id="lblNewContMessage" runat="server" Font-Size="X-Small" ForeColor="Blue" Font-Underline="True">將更新之合約金額 資料：</asp:Label><BR>合約金額：$ 
<asp:Label id="lblNewContTotalAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>已繳金額：$ 
<asp:Label id="lblNewContPaidAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label><BR>剩餘金額：$ 
<asp:Label id="lblNewContRestAmt" runat="server" Font-Size="X-Small" ForeColor="Red"></asp:Label></asp:panel></td>
				</tr>
			</table>
			<asp:button id="btnRecia" runat="server" Text="回復發票開立單"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnModifyCont" runat="server" Text="修改合約書"></asp:button>&nbsp;
			<asp:button id="btnModifyPub" runat="server" Text="修改落版"></asp:button></form>
		<br>
		<!-- 頁尾 Footer -->
		<center>
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
