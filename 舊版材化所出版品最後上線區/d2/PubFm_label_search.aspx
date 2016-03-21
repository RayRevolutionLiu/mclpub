<%@ Page language="c#" Codebehind="PubFm_label_search.aspx.cs" Src="PubFm_label_search.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.PubFm_label_search" %>
<%@ Register TagPrefix="kw" TagName="Header" Src="../usercontrol/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="Footer" Src="../usercontrol/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>平面廣告標籤 當月刊登 步驟一: 搜尋</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
			<!-- 表頭: 主功能選單 -->
			<kw:Header runat="server" />
		<center>
		</center>
		<!-- 目前所在位置 --><FONT color="#800000" size="2"></FONT><FONT color="#800000" size="2"></FONT><FONT color="#800000" size="2"></FONT><FONT color="#800000" size="2"></FONT><FONT color="#800000" size="2"></FONT>
		<table dataFld="items" id="tbItems" align="left" border="0">
			<tr>
				<td align="middle"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						平面廣告次系統 <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
						合約處理 <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
						平面廣告標籤 當月刊登 步驟一: 搜尋</font>&nbsp;
				</td>
			</tr>
		</table>
		&nbsp; 
		<!-- Run at Server Form -->
		<form id="PubFm_label_search" method="post" runat="server">
			<asp:label id="lblQuery" runat="server" ForeColor="Blue" Font-Bold="True">請選擇篩選條件：</asp:label>
			<asp:label id="lblQuery2" runat="server" Font-Bold="True" ForeColor="MediumBlue" Font-Size="X-Small">(查詢結果不包含 '已結案/已註銷' 之合約)</asp:label><br>
			<asp:label id="lblBookCode" runat="server" Font-Size="X-Small">書籍類別：</asp:label><asp:dropdownlist id="ddlBookCode" runat="server">
				<asp:ListItem Value="00" Selected="True">請選擇...</asp:ListItem>
			</asp:dropdownlist><br>
			<asp:label id="lblPubDate" runat="server" Font-Size="X-Small">刊登年月：</asp:label><asp:textbox id="tbxPubDate" runat="server" Width="60px"></asp:textbox>&nbsp;<font color="maroon" size="2">(如 
				2002/08, 預設值: 當月)</font><br>
			<asp:checkbox id="cbx0" runat="server"></asp:checkbox><asp:label id="lblEmpNo" runat="server" Font-Size="X-Small">合約承辦業務員：</asp:label><asp:dropdownlist id="ddlEmpNo" runat="server">
				<asp:ListItem Value="00" Selected="True">請選擇...</asp:ListItem>
			</asp:dropdownlist><br>
			<asp:label id="lblConttp" runat="server" Font-Size="X-Small">合約類別：</asp:label><asp:dropdownlist id="ddlConttp" runat="server">
				<asp:ListItem Value="01" Selected="True">一般</asp:ListItem>
				<asp:ListItem Value="09">推廣</asp:ListItem>
			</asp:dropdownlist><br>
			<asp:label id="lblfgMOSea" runat="server" Font-Size="X-Small">郵寄地區：</asp:label><asp:dropdownlist id="ddlfgMOSea" runat="server">
				<asp:ListItem Value="0" Selected="True">國內</asp:ListItem>
				<asp:ListItem Value="1">國外</asp:ListItem>
			</asp:dropdownlist><br>
			<asp:checkbox id="cbx1" runat="server"></asp:checkbox>
			<asp:label id="lblv" runat="server" Font-Size="X-Small">郵寄類別：</asp:label>
			<asp:dropdownlist id="ddlMtpcd" runat="server">
				<asp:ListItem Value="00" Selected="True">請選擇...</asp:ListItem>
			</asp:dropdownlist><br>
			<asp:Label id="lblMemo1" runat="server" ForeColor="Maroon" Font-Size="X-Small">註：如要在本頁再查詢其他資料, 請先按 '清除重查', 再按 '查詢'來繼續!<br> 要切換到其他次系統之功能, 請按 '返回首頁' 按鈕.</asp:Label>
			<br>
			<asp:button id="btnQuery" runat="server" Text="查詢"></asp:button>&nbsp;
			<asp:button id="btnClearAll" runat="server" Text="清除重查"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnPrintList" runat="server" Text="列印清單"></asp:button>&nbsp;
			<asp:button id="btnPrintLabel" runat="server" Text="列印標籤"></asp:button>&nbsp;&nbsp;
			<asp:button id="btnBackHome" runat="server" Text="返回首頁"></asp:button>&nbsp;
			<asp:literal id="Literal1" runat="server"></asp:literal>
			<asp:TextBox id="tbxLoginEmpNo" runat="server" Font-Size="X-Small" Width="50px" Visible="False"></asp:TextBox>
			<asp:TextBox id="tbxLoginEmpCName" runat="server" Font-Size="X-Small" Width="60px" Visible="False"></asp:TextBox>
			<asp:TextBox id="tbxBookPNo" runat="server" Font-Size="X-Small" Width="60px" Visible="False"></asp:TextBox><br>
			<asp:label id="lblMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label><br>
			<asp:datagrid id="DataGrid1" runat="server" BorderStyle="None" GridLines="Vertical" BorderWidth="1px" BorderColor="#999999" BackColor="White" CellPadding="3" AutoGenerateColumns="False">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
				<AlternatingItemStyle BackColor="Gainsboro"></AlternatingItemStyle>
				<ItemStyle ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
				<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_sdate" HeaderText="合約起日"></asp:BoundColumn>
					<asp:BoundColumn DataField="cont_edate" HeaderText="合約迄日"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_inm" HeaderText="公司名稱"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_oritem" HeaderText="序號"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_nm" HeaderText="收件人姓名"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_jbti" HeaderText="稱謂"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_zip" HeaderText="郵寄區號"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_addr" HeaderText="郵寄地址"></asp:BoundColumn>
					<asp:BoundColumn DataField="or_pubcnt" HeaderText="有登本數"></asp:BoundColumn>
					<asp:BoundColumn DataField="mtp_nm" HeaderText="郵寄類別"></asp:BoundColumn>
				</Columns>
				<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
			</asp:datagrid><br>
			<asp:RegularExpressionValidator id="revPubDate" Font-Size="X-Small" runat="server" ErrorMessage="'刊登年月' 請依格式填入(請參旁邊文字說明)!!!" ControlToValidate="tbxPubDate" ValidationExpression="\d{4}/\d{2}"></asp:RegularExpressionValidator></form>
		<br>
			<!-- 表尾: 版權區 -->
			<kw:Footer runat="server" />
	</body>
</HTML>
