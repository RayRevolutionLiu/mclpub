<%@ Page language="c#" Codebehind="DeleteIa.aspx.cs" src="DeleteIa.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.DeleteIa" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- 頁首 Header --><kw:header id="Header" runat="server">
		</kw:header>
		<form id="DeleteIa" method="post" runat="server">
			<table>
				<tr>
					<td>
						<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
							雜誌叢書訂閱次系統<IMG height="10" src="images/header/right02.gif" width="10" border="0">
							發票處理<IMG height="10" src="images/header/right02.gif" width="10" border="0">註銷發票 </font>
					</td>
				</tr>
			</table>
			<br>
			<asp:label id="Label1" runat="server">請輸入發票號碼：</asp:label>
			<asp:textbox id="tbxIano" runat="server" Width="83px" Height="24px" MaxLength="10"></asp:textbox>
			<input id="hiddenIano" type="hidden" runat="server">
			<asp:button id="btnSearch" runat="server" Text="查詢"></asp:button>
			<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="1" AutoGenerateColumns="False">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="ia_iano" HeaderText="發票開立單編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invno" HeaderText="發票號碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invdate" HeaderText="發票日期"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_pyat" HeaderText="金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_mfrno" HeaderText="統一編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rnm" HeaderText="發票收件人姓名"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_raddr" HeaderText="地址"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invcd" HeaderText="發票類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_taxtp" HeaderText="課稅別"></asp:BoundColumn>
					<asp:BoundColumn DataField="nostr" HeaderText="訂單編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="o_date" HeaderText="訂購日期"></asp:BoundColumn>
					<asp:BoundColumn DataField="datestr" HeaderText="訂閱起迄"></asp:BoundColumn>
					<asp:BoundColumn DataField="obtp_obtpnm" HeaderText="書籍類別"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<br>
			<asp:button id="btnDelete" runat="server" Text="註銷發票" Visible="False"></asp:button>
			<br>
			<asp:Label id="Label2" runat="server" ForeColor="#C04000" Font-Size="X-Small">說明：<br>發票類別---2:二聯  3:三聯  4:其他<br>課稅別---1:應稅  2:零稅  3:免稅</asp:Label>
		</form>
		<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="註銷發票")
				event.returnValue=confirm("確定要刪除此筆發票資料?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
