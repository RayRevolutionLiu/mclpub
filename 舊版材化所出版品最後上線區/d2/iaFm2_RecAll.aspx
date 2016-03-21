<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="iaFm2_RecAll.aspx.cs" Src="iaFm2_RecAll.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.iaFm2_RecAll" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>發票開立單回復(Recovery) - 大批月結</title>
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
						發票開立單回復(Recovery) - 大批月結</font>
				</td>
			</tr>
		</table>
		<!-- Run at Server Form-->
		<form id="iaFm2_RecAll" method="post" runat="server">
			<asp:Panel id="pnlQuery" runat="server">
<asp:label id="lblTitle" runat="server" Font-Size="Small" ForeColor="Blue" Font-Bold="True">請輸入查詢條件：</asp:label>&nbsp;&nbsp; 
<asp:label id="lblMemo1" runat="server" Font-Size="X-Small" ForeColor="#C04000">(說明：已於會計系統做處理之發票開立單無法做回復！)</asp:label><BR>
<asp:label id="lblIabDate" runat="server" Font-Size="X-Small" ForeColor="Maroon">發票開立單 開立年月：</asp:label>
<asp:textbox id="tbxIabDate" runat="server" Width="60px" MaxLength="7"></asp:textbox>&nbsp;<FONT color="darkred" size="2">
					(預設值：當月，如2002/08)</FONT><BR>
<asp:label id="lblIabNo" runat="server" Font-Size="X-Small" ForeColor="Maroon">發票開立單 批號：</asp:label>
<asp:textbox id="tbxIabNo" runat="server" Width="60px" MaxLength="6"></asp:textbox>&nbsp;<FONT color="red" size="2">
					(請自 "發票開立單 檢核表" 參考，請填正確值，如 000001)</FONT><BR>
<asp:button id="btnQuery" runat="server" Text="查詢"></asp:button>&nbsp; 
<asp:Button id="btnClear" runat="server" Text="清除重查"></asp:Button>
			</asp:Panel>
			<asp:label id="lblMessage" runat="server" Font-Size="X-Small" ForeColor="Blue"></asp:label>
			<asp:TextBox id="tbxLoginEmpNo" runat="server" Font-Size="X-Small" Width="50px" Visible="False"></asp:TextBox>
			<asp:TextBox id="tbxLoginEmpCName" runat="server" Font-Size="X-Small" Width="60px" Visible="False"></asp:TextBox><br>
			<asp:RegularExpressionValidator id="revIabSeq" runat="server" Font-Size="X-Small" ValidationExpression="\d{6}" ControlToValidate="tbxIabNo" ErrorMessage="'發票開立單批號' 請依格式填入(請參旁邊文字說明)!!!"></asp:RegularExpressionValidator><br>
			<asp:RegularExpressionValidator id="revPubDate" runat="server" Font-Size="X-Small" ValidationExpression="\d{4}/\d{2}" ControlToValidate="tbxIabDate" ErrorMessage="'發票開立單 開立年月' 請依格式填入(請參旁邊文字說明)!!!"></asp:RegularExpressionValidator>
			<br>
			<!-- 操作步驟 -->
			<asp:label id="lblMemo2" runat="server" Font-Size="X-Small" ForeColor="#C04000">操作步驟：查詢後將顯示該批資料, 您可<B>
					先列印回復清單</B>, 確認後<B>再按下 '確認回復' 按鈕</B>!</asp:label><br>
			<!-- 發票開立單 資料 DataGrid1 -->
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
			</asp:datagrid>
			<asp:Button id="btnRecovery" runat="server" Text="確認回復"></asp:Button><FONT face="新細明體">&nbsp;
				<asp:Button id="btnPrintList" runat="server" Text="列印回復清單"></asp:Button></FONT>
			<asp:Literal id="Literal1" runat="server"></asp:Literal>
		</form>
		<br>
		<!-- 頁尾 Footer -->
		<center><kw:footer id="Footer" runat="server"></kw:footer></center>
	</body>
</HTML>
