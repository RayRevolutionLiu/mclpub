<%@ Page language="c#" Codebehind="RecoveryPayList.aspx.cs" src="RecoveryPayList.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.RecoveryPayList" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
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
		<form id="RecoveryPayList" method="post" runat="server">
			<FONT color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
				雜誌叢書訂閱次系統<IMG height="10" src="images/header/right02.gif" width="10" border="0">
				繳款處理<IMG height="10" src="images/header/right02.gif" width="10" border="0">刪除繳款清單
			</FONT>
			<br>
			<asp:label id="Label2" runat="server" ForeColor="Blue" Font-Size="Small" Font-Names="細明體" Font-Bold="True">請選擇條件</asp:label>
			<HR width="100%" SIZE="1">
			<asp:label id="Label3" runat="server">清單產生年月：</asp:label>
			<asp:dropdownlist id="ddlYear" runat="server"></asp:dropdownlist>
			年
			<asp:dropdownlist id="ddlMonth" runat="server">
				<asp:ListItem Value="01">1</asp:ListItem>
				<asp:ListItem Value="02">2</asp:ListItem>
				<asp:ListItem Value="03">3</asp:ListItem>
				<asp:ListItem Value="04">4</asp:ListItem>
				<asp:ListItem Value="05">5</asp:ListItem>
				<asp:ListItem Value="06">6</asp:ListItem>
				<asp:ListItem Value="07">7</asp:ListItem>
				<asp:ListItem Value="08">8</asp:ListItem>
				<asp:ListItem Value="09">9</asp:ListItem>
				<asp:ListItem Value="10">10</asp:ListItem>
				<asp:ListItem Value="11">11</asp:ListItem>
				<asp:ListItem Value="12">12</asp:ListItem>
			</asp:dropdownlist>
			月
			<br>
			<asp:button id="btnSearch" runat="server" Text="查詢"></asp:button>
			<asp:button id="btnDelete" runat="server" Text="刪除繳款清單" Enabled="False"></asp:button>
			<asp:Label id="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
			<br>
			產生年月：
			<asp:label id="lblyyyymm" runat="server" ForeColor="Purple" BackColor="#C0FFC0">0</asp:label>
			批次：
			<asp:label id="lblbatch" runat="server" ForeColor="Purple" BackColor="#C0FFC0">0</asp:label>
			<br>
			<asp:datagrid id="DataGrid1" runat="server" BackColor="White" AutoGenerateColumns="False" CellPadding="1" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<Columns>
					<asp:ButtonColumn Text="選取" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
					<asp:BoundColumn DataField="pys_pysdate" HeaderText="產生年月"></asp:BoundColumn>
					<asp:BoundColumn DataField="pys_pysseq" HeaderText="批次"></asp:BoundColumn>
					<asp:BoundColumn DataField="pys_toitem" HeaderText="總項次"></asp:BoundColumn>
					<asp:BoundColumn DataField="pytp_nm" HeaderText="付款方式"></asp:BoundColumn>
					<asp:BoundColumn DataField="pys_createdate" HeaderText="建立日期"></asp:BoundColumn>
					<asp:BoundColumn DataField="pys_createmen" HeaderText="建立者"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
			<asp:datagrid id="DataGrid2" runat="server" BackColor="White" AutoGenerateColumns="False" CellPadding="1" BorderColor="#3366CC" BorderWidth="1px" BorderStyle="None">
				<FooterStyle ForeColor="#003399" BackColor="#99CCCC"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" BackColor="#003399"></HeaderStyle>
				<PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" Mode="NumericPages"></PagerStyle>
				<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" BackColor="#009999"></SelectedItemStyle>
				<ItemStyle ForeColor="#003399" BackColor="White"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="py_pyno" HeaderText="繳款編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_date" HeaderText="繳款日期"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_amt" HeaderText="金額"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_pysdate" HeaderText="繳款清單產生年月"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_pysseq" HeaderText="繳款清單批次"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_pysitem" HeaderText="繳款清單項次"></asp:BoundColumn>
					<asp:BoundColumn DataField="py_moseq" HeaderText="劃撥單批號"></asp:BoundColumn>
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
				</Columns>
			</asp:datagrid>
		</form>
		<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server">
		</kw:footer>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="刪除繳款清單")
				event.returnValue=confirm("此動作將會刪除所選的繳款清單及明細, 確定要刪除此筆繳款清單?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
