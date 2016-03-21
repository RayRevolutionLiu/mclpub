<%@ Page language="c#" Codebehind="Pub_LabelFilter.aspx.cs" src="Pub_LabelFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.Pub_LabelFilter" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Pub_LabelFilter</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Pub_LabelFilter" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="90%" align="center">
				<tr>
					<td>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										標籤處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										大宗標籤(當月刊登)</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td>
						<TABLE class="TableColor" style="WIDTH: 604px" cellSpacing="0" cellPadding="2">
							<tr class="TableColorHeader">
								<td style="WIDTH: 550px" colSpan="2">查詢條件
									<asp:label id="Label1" runat="server" ForeColor="Yellow">(查詢結果不包含 '已結案/已註銷' 之合約)</asp:label></td>
							</tr>
							<tr>
								<td align="right" width="30%"><asp:label id="lblBookCode" runat="server" Font-Size="X-Small">書籍類別：</asp:label></td>
								<td><asp:dropdownlist id="ddlBookCode" runat="server">
										<asp:ListItem Value="00" Selected="True">請選擇...</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblPubDate" runat="server" Font-Size="X-Small">刊登年月：</asp:label></td>
								<td><asp:textbox id="tbxPubDate" runat="server" Width="60px"></asp:textbox>&nbsp;<font color="maroon" size="2">(如 
										2003/10, 預設值: 當月)
										<asp:regularexpressionvalidator id="revPubDate" runat="server" Font-Size="X-Small" ErrorMessage="輸入格式錯誤" ControlToValidate="tbxPubDate" ValidationExpression="\d{4}/\d{2}"></asp:regularexpressionvalidator></font></td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblConttp" runat="server" Font-Size="X-Small">合約類別：</asp:label></td>
								<td><asp:dropdownlist id="ddlConttp" runat="server">
										<asp:ListItem Value="01" Selected="True">一般</asp:ListItem>
										<asp:ListItem Value="09">推廣</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right"><asp:label id="lblfgMOSea" runat="server" Font-Size="X-Small">郵寄地區：</asp:label></td>
								<td><asp:dropdownlist id="ddlfgMOSea" runat="server">
										<asp:ListItem Value="0" Selected="True">國內</asp:ListItem>
										<asp:ListItem Value="1">國外</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right"><asp:checkbox id="cbxMtpcd" runat="server"></asp:checkbox><asp:label id="lblMtpcd" runat="server" Font-Size="X-Small">郵寄類別：</asp:label></td>
								<td><asp:dropdownlist id="ddlMtpcd" runat="server">
										<asp:ListItem Value="00" Selected="True">請選擇...</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
							<tr>
								<td align="right"><asp:checkbox id="cbxEmpno" runat="server"></asp:checkbox><asp:label id="lblEmpNo" runat="server" Font-Size="X-Small">合約承辦業務員：</asp:label></td>
								<td><asp:dropdownlist id="ddlEmpNo" runat="server">
										<asp:ListItem Value="00" Selected="True">請選擇...</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
						</TABLE>
						<br>
						<asp:button id="btnQuery" runat="server" Text="查詢"></asp:button><asp:button id="btnPrintList" runat="server" Text="列印清單"></asp:button><asp:button id="btnPrintLabel" runat="server" Text="列印標籤"></asp:button><asp:button id="btnBackHome" runat="server" Text="返回首頁"></asp:button>&nbsp;
						<asp:literal id="Literal1" runat="server"></asp:literal><br>
						<asp:label id="lblMessage" runat="server" ForeColor="Maroon" Font-Size="X-Small"></asp:label><br>
						<asp:datagrid id="dgdLabel" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
							<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemStyle"></ItemStyle>
							<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cont_contno" HeaderText="合約編號"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_sdate" HeaderText="合約起日"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_edate" HeaderText="合約迄日"></asp:BoundColumn>
								<asp:BoundColumn DataField="ma_sdate" HeaderText="贈閱起月"></asp:BoundColumn>
								<asp:BoundColumn DataField="ma_edate" HeaderText="贈閱迄月"></asp:BoundColumn>
								<asp:BoundColumn DataField="or_inm" HeaderText="公司名稱"></asp:BoundColumn>
								<asp:BoundColumn DataField="or_oritem" HeaderText="序號"></asp:BoundColumn>
								<asp:BoundColumn DataField="or_nm" HeaderText="收件人姓名"></asp:BoundColumn>
								<asp:BoundColumn DataField="or_jbti" HeaderText="稱謂"></asp:BoundColumn>
								<asp:BoundColumn DataField="or_zip" HeaderText="郵寄區號"></asp:BoundColumn>
								<asp:BoundColumn DataField="or_addr" HeaderText="郵寄地址"></asp:BoundColumn>
								<asp:BoundColumn DataField="ma_mnt" HeaderText="有登本數"></asp:BoundColumn>
								<asp:BoundColumn DataField="mtp_nm" HeaderText="郵寄類別"></asp:BoundColumn>
							</Columns>
						</asp:datagrid><br>
						<input id="hiddenBookNm" type="hidden" name="hiddenBookNm" runat="server"> <input id="hiddenBookPno" type="hidden" name="hiddenBookPno" runat="server">
					</td>
				</tr>
			</TABLE>
			<br>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
