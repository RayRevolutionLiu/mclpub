<%@ Page language="c#" Codebehind="RptIA_ChkFilter.aspx.cs" src="RptIA_ChkFilter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RptIA_ChkFilter" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptIA_ChkFilter</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="RptIA_ChkFilter" method="post" runat="server">
			<!-- 頁首 Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td align="middle">
						<TABLE id="tbItems" width="700">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;網路廣告次系統 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										發票處理 <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										大批月結之發票開立單檢核表&nbsp;： 查詢條件</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td align="middle">
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="2" width="700" border="0">
							<TR>
								<TD class="TableColorHeader">查詢條件
									<asp:Label id="Label1" runat="server" ForeColor="Yellow">(請注意：已於會計系統做處理之發票開立單無法再列印檢核表！)</asp:Label></TD>
							</TR>
							<tr>
								<td>
									發票開立單 <FONT color="blue">產生年月</FONT>：
									<asp:textbox id="tbxYYYYMM" runat="server" Width="58px"></asp:textbox>
									<asp:label id="lblyyyymm" runat="server" ForeColor="#C04000">(例如 : 2003/09)</asp:label>
									<asp:regularexpressionvalidator id="revDate" runat="server" Font-Size="X-Small" ErrorMessage="輸入格式錯誤" ControlToValidate="tbxYYYYMM" ValidationExpression="\d{4}/\d{2}"></asp:regularexpressionvalidator>
									<INPUT id="hiddenSeq" type="hidden" name="hiddenSeq" runat="server"><br>
									排序條件：
									<asp:DropDownList id="ddlSort" runat="server">
										<asp:ListItem Value="1">發票開立單編號</asp:ListItem>
										<asp:ListItem Value="2">業務員+合約編號+落版序號</asp:ListItem>
									</asp:DropDownList>
									<asp:button id="btnSearch" runat="server" Text="查詢"></asp:button>
									<asp:label id="lblMessage" runat="server" ForeColor="Red" Font-Size="Small"></asp:label>
								</td>
							</tr>
							<tr>
								<td>
									<asp:datagrid id="dgdIAB" runat="server" Visible="False" AutoGenerateColumns="False" CssClass="DataGridStyle">
										<SelectedItemStyle BackColor="#FFFFC0"></SelectedItemStyle>
										<ItemStyle CssClass="ItemStyle"></ItemStyle>
										<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="iab_iabdate" ReadOnly="True" HeaderText="產生年月"></asp:BoundColumn>
											<asp:BoundColumn DataField="iab_iabseq" HeaderText="產生批次"></asp:BoundColumn>
											<asp:BoundColumn DataField="iab_createdate" HeaderText="批次產生日期"></asp:BoundColumn>
											<asp:BoundColumn DataField="srspn_cname" HeaderText="批次產生人員姓名"></asp:BoundColumn>
											<asp:ButtonColumn Text="選取" ButtonType="PushButton" HeaderText="細項資料" CommandName="Select"></asp:ButtonColumn>
										</Columns>
									</asp:datagrid>
								</td>
							</tr>
							<tr>
								<td>
									<asp:panel id="pnlIA" Runat="server" Visible="False">
										<asp:Button id="btnPrint" runat="server" Text="列印發票開立單檢核表"></asp:Button>
										<asp:datagrid id="dgdIA" runat="server" Width="100%" CssClass="DataGridStyle" AutoGenerateColumns="False">
											<ItemStyle CssClass="ItemStyle"></ItemStyle>
											<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="ia_iano" ReadOnly="True" HeaderText="發票開立單編號"></asp:BoundColumn>
												<asp:BoundColumn DataField="ia_contno" HeaderText="合約編號"></asp:BoundColumn>
												<asp:BoundColumn DataField="ia_mfrno" HeaderText="發票廠商統編"></asp:BoundColumn>
												<asp:BoundColumn DataField="mfr_inm" HeaderText="發票廠商名稱"></asp:BoundColumn>
												<asp:BoundColumn DataField="ia_rnm" HeaderText="發票收件人"></asp:BoundColumn>
												<asp:BoundColumn DataField="ia_pyat" HeaderText="發票金額"></asp:BoundColumn>
												<asp:BoundColumn DataField="ia_invcd" HeaderText="發票類別"></asp:BoundColumn>
												<asp:BoundColumn DataField="ia_taxtp" HeaderText="課稅別"></asp:BoundColumn>
												<asp:BoundColumn DataField="ia_fgitri" HeaderText="往來註記"></asp:BoundColumn>
												<asp:BoundColumn DataField="ia_cname" HeaderText="承辦人員"></asp:BoundColumn>
											</Columns>
										</asp:datagrid>
									</asp:panel>
									<asp:panel id="pnlBack" Width="100%" Runat="server" Visible="False">
										<P align="center">
											<asp:Button id="btnHome" Runat="server" Text="回主選單"></asp:Button></P>
									</asp:panel>
								</td>
							</tr>
						</TABLE>
						<asp:Literal id="Literal1" runat="server"></asp:Literal>
					</td>
				</tr>
			</TABLE>
			<!-- 頁尾 Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
	</body>
</HTML>
