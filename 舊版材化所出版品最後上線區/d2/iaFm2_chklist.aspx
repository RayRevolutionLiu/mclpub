<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="iaFm2_chklist.aspx.cs" Src="iaFm2_chklist.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm2_chklist" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>預覽 發票開立單 - 大批月結</TITLE>
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
		<center>
			<kw:header id="Header" runat="server"></kw:header>
		</center>
		<!-- 目前所在位置 -->
		<table dataFld="items" id="tbItems" style="WIDTH: 739px">
			<tr>
				<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						發票處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						預覽 發票開立單 - 大批月結</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm2_chklist" method="post" runat="server">
			<asp:label id="lblRecordCount" runat="server" Font-Size="X-Small" ForeColor="Maroon"></asp:label>&nbsp;
			<asp:textbox id="tbxIAStatus" runat="server" Width="30px" Visible="False"></asp:textbox>&nbsp;
			<asp:Button id="btnBack" runat="server" Text="返回前一步驟"></asp:Button><br>
			<asp:label id="lblMemo1" runat="server" Font-Size="X-Small" ForeColor="#C04000">說明1：<br>此檢核表列示之發票開立單是尚未產生發票開立清單之資料, <br>已產生發票開立清單之發票資料不會在此列示.<br>不包含已結案之資料.</asp:label><br>
			<asp:panel id="pnlChklist" runat="server">
				<asp:Label id="lblChklist" runat="server" ForeColor="Blue" Font-Bold="True">預覽發票開立單：</asp:Label>
				<BR>
				<asp:DataGrid id="DataGrid1" runat="server" Font-Size="8pt" AutoGenerateColumns="False" CellPadding="1" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
					<SelectedItemStyle ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
					<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
					<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_nm" HeaderText="發票收件人"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_jbti" HeaderText="稱謂"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_addr" HeaderText="發票郵寄地址">
							<HeaderStyle Wrap="False"></HeaderStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="im_zip" HeaderText="郵遞區號"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_tel" HeaderText="電話"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_invcd" HeaderText="發票類別"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_taxtp" HeaderText="課稅別"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_yyyymm" HeaderText="刊登年月"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_pubseq" HeaderText="落版序號"></asp:BoundColumn>
						<asp:BoundColumn DataField="bk_nm" HeaderText="品名"></asp:BoundColumn>
						<asp:BoundColumn DataField="proj_projno" HeaderText="計劃代號"></asp:BoundColumn>
						<asp:BoundColumn DataField="proj_costctr" HeaderText="成本中心"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_count" HeaderText="數量"></asp:BoundColumn>
						<asp:BoundColumn DataField="pub_totamt" HeaderText="金額"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="pub_imseq" HeaderText="發廠序號"></asp:BoundColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				</asp:DataGrid>
				<DIV align="right">
					<asp:Label id="lblSubTotalAmt" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:Label></DIV>
			</asp:panel><asp:panel id="pnlContAmtCount" runat="server">
<asp:Label id="lblContAmtCount" runat="server" ForeColor="Blue" Font-Bold="True">預覽開立金額：</asp:Label></FONT>
<asp:DataGrid id="DataGrid2" runat="server" AutoGenerateColumns="False">
					<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
					<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
					<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
					<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
					<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
					<Columns>
						<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_imseq" HeaderText="發廠序號"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_nm" HeaderText="發廠收件人"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_conttp" HeaderText="合約類別"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_sdate" HeaderText="合約起日"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_edate" HeaderText="合約迄日"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_mfrno" HeaderText="廠商統編"></asp:BoundColumn>
						<asp:BoundColumn DataField="mfr_inm" HeaderText="廠商名稱">
							<ItemStyle Width="60px"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="cust_nm" HeaderText="客戶姓名"></asp:BoundColumn>
						<asp:BoundColumn DataField="srspn_cname" HeaderText="業務員"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_totamt" HeaderText="合約總金額"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_paidamt" HeaderText="已繳金額"></asp:BoundColumn>
						<asp:BoundColumn DataField="cont_restamt" HeaderText="剩餘金額"></asp:BoundColumn>
						<asp:BoundColumn HeaderText="當月廣告總額"></asp:BoundColumn>
						<asp:BoundColumn HeaderText="當月換稿總額"></asp:BoundColumn>
						<asp:BoundColumn HeaderText="當月開立總額"></asp:BoundColumn>
						<asp:BoundColumn Visible="False" DataField="cont_empno" HeaderText="業務員工號"></asp:BoundColumn>
						<asp:BoundColumn DataField="im_imseq" HeaderText="發廠序號"></asp:BoundColumn>
					</Columns>
				</asp:DataGrid><BR>
<DIV align="right">
					<asp:Label id="lblContSubTotalAmt" runat="server" ForeColor="Red" Font-Size="X-Small"></asp:Label>
					<asp:TextBox id="tbxContSubTotalAmt" runat="server" Visible="False" Width="80px"></asp:TextBox></DIV>
<asp:Button id="btnAddIA" runat="server" Text="產生發票開立單"></asp:Button></asp:panel></form>
		<br>
		<!-- 頁尾 Footer -->
		<center>
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</body>
</HTML>
