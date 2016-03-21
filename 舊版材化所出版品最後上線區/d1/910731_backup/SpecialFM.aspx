<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="SpecialFM.aspx.cs" src="SpecialFM.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.SpecialFM" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<!-- 頁首 Header --><kw:header id="Header" runat="server">
		</kw:header>
		<form id="SpecialFM" method="post" runat="server">
			<table>
				<tr>
					<td>
						<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
							雜誌叢書訂閱次系統<IMG height="10" src="images/header/right02.gif" width="10" border="0">
							發票處理<IMG height="10" src="images/header/right02.gif" width="10" border="0">已繳款之發票退回處理
						</font>
					</td>
				</tr>
			</table>
			<br>
			<asp:label id="Label1" runat="server">請輸入發票號碼：</asp:label>
			<asp:textbox id="tbxInvno" runat="server" Width="83px" Height="24px" MaxLength="10"></asp:textbox>
			<asp:button id="btnSearch" runat="server" Text="查詢"></asp:button>
			<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label>
			<input id="hiddenIano" type="hidden" runat="server" NAME="hiddenIano"> <input id="hiddenid" type="hidden" runat="server" NAME="hiddenid">
			<input id="hiddentype1" type="hidden" runat="server" NAME="hiddentype1"> <input id="hiddenseq" type="hidden" runat="server" NAME="hiddenseq">
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
			<asp:button id="btnDelete" runat="server" Text="訂單中作註記並進入修改訂單畫面" Visible="False"></asp:button>
			<br>
			<asp:Label id="Label2" runat="server" ForeColor="#C04000" Font-Size="X-Small">說明：<br>發票類別---2:二聯  3:三聯  4:其他<br>課稅別---1:應稅  2:零稅  3:免稅</asp:Label>
		</form>
		<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="訂單中作註記並進入修改訂單畫面")
				event.returnValue=confirm("確定要在訂單中作註記並進入修改訂單畫面?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
