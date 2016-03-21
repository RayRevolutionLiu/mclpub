<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="PayDelete.aspx.cs" src="PayDelete.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.PayDelete" %>
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
		<form id="PayDelete" method="post" runat="server">
			<table>
				<tr>
					<td>
						<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
							雜誌叢書訂閱次系統<IMG height="10" src="images/header/right02.gif" width="10" border="0">
							繳款處理<IMG height="10" src="images/header/right02.gif" width="10" border="0">刪除繳款資料
						</font>
					</td>
				</tr>
			</table>
			<br>
			<asp:label id="Label1" runat="server">請輸入繳款編號：</asp:label>
			<asp:textbox id="tbxPyno" runat="server" MaxLength="8" Height="24px" Width="83px"></asp:textbox>
			<asp:button id="btnSearch" runat="server" Text="查詢"></asp:button>
			<asp:label id="lblMessage" runat="server" ForeColor="#C00000"></asp:label>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" CellPadding="1" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="py_pyno" HeaderText="繳款編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_amt" HeaderText="金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="pytp_nm" HeaderText="付款方式"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_date" HeaderText="繳款日期"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_moseq" HeaderText="劃撥單批號">
						<HeaderStyle Wrap="False">
						</HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="py_moitem" HeaderText="項次"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_chkno" HeaderText="票據號碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_chkbnm" HeaderText="付款行"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_chkdate" HeaderText="到期日"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_waccno" HeaderText="電匯帳號"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_wdate" HeaderText="匯入日期"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_wbcd" HeaderText="金融代碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_ccno" HeaderText="信用卡卡號"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_ccauthcd" HeaderText="授權碼"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_ccvdate" HeaderText="有效年月"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_ccdate" HeaderText="交易日期"></asp:BoundColumn>
					<asp:BoundColumn DataField="pyd_pyditem" HeaderText="繳款序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="pyd_iano" HeaderText="發票開立單編號"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<br>
			<asp:Button id="btnDelete" runat="server" Text="刪除繳款資料" Visible="False"></asp:Button>
		</form>
		<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="刪除繳款資料")
				event.returnValue=confirm("確定要刪除此筆繳款資料?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
