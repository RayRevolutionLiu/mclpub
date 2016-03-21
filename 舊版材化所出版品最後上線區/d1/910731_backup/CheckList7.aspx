<%@ Page language="c#" Codebehind="CheckList7.aspx.cs" src="CheckList7.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.CheckList7" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>【材料所 出版品客戶管理系統】 繳款單檢核表</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="CheckList7" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				繳款處理 <IMG height="10" src="images/header/right02.gif" width="10" border="0">繳款單檢核表
			</FONT>
			<br>
			<INPUT onclick="doClose()" type="button" value="回首頁">
			<br>
			<asp:datagrid id="DataGrid1" runat="server" BorderStyle="None" BorderWidth="1px" BorderColor="#3366CC" BackColor="White" CellPadding="1" AutoGenerateColumns="False" Font-Size="8pt" Font-Names="新細明體">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
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
			<asp:label id="Label3" runat="server" Font-Size="X-Small" ForeColor="#C04000">說明1：<br>此檢核表列示之繳款單是尚未產生繳款清單之資料, <br>已產生繳款清單之繳款資料不會在此列示</asp:label>
		</form>
		<script language="javascript">
function doClose()
{
	window.close();
}
	</script>
	</body>
</HTML>
