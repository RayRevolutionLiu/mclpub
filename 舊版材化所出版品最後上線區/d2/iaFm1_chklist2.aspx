<%@ Page language="c#" Codebehind="iaFm1_chklist2.aspx.cs" Src="iaFm1_chklist2.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm1_chklist2" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>發票開立單檢核表 - 一次付款 (當月刊登清單)</title>
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
		<center><kw:header id="Header" runat="server"></kw:header></center>
		<!-- 目前所在位置 -->
		<table dataFld="items" id="tbItems" style="WIDTH: 739px">
			<tr>
				<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						發票處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						發票開立單檢核表 - 一次付款 (當月刊登清單)</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm1_chklist2" method="post" runat="server">
			<asp:panel id="pnlQuery" runat="server">
<asp:label id="lblBkcd" runat="server">書籍類別：</asp:label>
<asp:dropdownlist id="ddlBkcd" runat="server"></asp:dropdownlist><BR>
<asp:label id="lblYYYYMM" runat="server">刊登年月：</asp:label>
<asp:textbox id="tbxYYYYMM" runat="server" MaxLength="7" Width="60px"></asp:textbox>&nbsp;<FONT color="darkred" size="2">
					(預設值：當月，如2002/08)</FONT><BR>
<asp:button id="btnQuery" runat="server" Text="查詢"></asp:button>&nbsp; 
<asp:button id="btnClear" runat="server" Text="清除重查"></asp:button><BR>
<asp:label id="lblMessage" runat="server" Font-Size="X-Small" ForeColor="Maroon"></asp:label>
<asp:TextBox id="tbxIAStatus" runat="server" Width="30px" Visible="False"></asp:TextBox>
<asp:RegularExpressionValidator id="revPubDate" runat="server" Font-Size="X-Small" ValidationExpression="\d{4}/\d{2}" ControlToValidate="tbxYYYYMM" ErrorMessage="'刊登年月' 請依格式填入(請參旁邊文字說明)!!!"></asp:RegularExpressionValidator></asp:panel><br>
			<asp:label id="lblMessage2" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label><asp:button id="btnReQuery" runat="server" Text="重新查詢"></asp:button>&nbsp;&nbsp;<asp:button id="btnPrintList" runat="server" Text="列印檢核表"></asp:button><br>
			<asp:datagrid id="DataGrid1" runat="server" Font-Size="8pt" AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="1">
				<SelectedItemStyle ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
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
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
			</asp:datagrid><asp:literal id="Literal1" runat="server"></asp:literal><asp:textbox id="tbxLoginEmpCName" runat="server" Width="60px" Font-Size="X-Small" Visible="False"></asp:textbox><asp:textbox id="tbxLoginEmpNo" runat="server" Width="50px" Font-Size="X-Small" Visible="False"></asp:textbox></form>
		<br>
		</FORM>
		<br>
		<!-- 頁尾 Footer -->
		<center><kw:footer id="Footer" runat="server"></kw:footer></center>
	</body>
</HTML>
