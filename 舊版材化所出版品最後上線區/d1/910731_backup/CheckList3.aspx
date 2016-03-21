<%@ Page language="c#" Codebehind="CheckList3.aspx.cs" src="CheckList3.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.CheckList3" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>【材料所 出版品客戶管理系統】 發票開立單檢核表</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="CheckList3" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				雜誌叢書訂閱次系統 <IMG height="10" src="images/header/right02.gif" width="10" border="0">
				發票處理 <IMG height="10" src="images/header/right02.gif" width="10" border="0">發票開立單檢核表
			</FONT>
			<br>
			<INPUT onclick="doClose()" type="button" value="回首頁">
			<br>
			<asp:datagrid id="DataGrid1" runat="server" Font-Names="新細明體" Font-Size="8pt" AutoGenerateColumns="False" CellPadding="1" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Lavender"></AlternatingItemStyle>
				<ItemStyle ForeColor="Navy" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="ia_iano" HeaderText="發票開立單編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_mfrno" HeaderText="統一編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rnm" HeaderText="發票收件人"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rjbti" HeaderText="稱謂"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_raddr" HeaderText="發票郵寄地址">
						<HeaderStyle Wrap="False">
						</HeaderStyle>
					</asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rzip" HeaderText="郵遞區號"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_rtel" HeaderText="電話"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_invcd" HeaderText="發票類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="ia_taxtp" HeaderText="課稅別"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_iaditem" HeaderText="發票開立單明細序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk1" HeaderText="訂戶編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk2" HeaderText="訂購類別"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk3" HeaderText="訂單流水號"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_fk4" HeaderText="訂單項次"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_desc" HeaderText="品名"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_projno" HeaderText="計劃代號"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_costctr" HeaderText="成本中心"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_qty" HeaderText="數量"></asp:BoundColumn>
					<asp:BoundColumn DataField="iad_amt" HeaderText="金額"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<asp:label id="Label3" runat="server" Font-Size="X-Small" ForeColor="#C04000">說明1：<br>此檢核表列示之發票開立單是尚未產生發票開立清單之資料, <br>已產生發票開立清單之發票資料不會在此列示</asp:label>
			<br>
			<asp:label id="Label2" runat="server" Font-Size="X-Small" ForeColor="#C04000">說明2：<br>發票類別---2:二聯  3:三聯  4:其他<br>課稅別---1:應稅  2:零稅  3:免稅</asp:label>
		</form>
		<script language="javascript">
function doClose()
{
	window.close();
}
	</script>
	</body>
</HTML>
