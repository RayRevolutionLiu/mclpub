<%@ Page language="c#" Codebehind="ContQueryMaintain.aspx.cs" Src="ContQueryMaintain.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.ContQueryMaintain" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���ƩҥX���~�Ȥ�޲z�t��</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="ContQueryMaintain" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td align="middle"><br>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�X���B�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										���@�X���� �B�J�@: �D�X�Ȥ�Ϊ�����J�X���ѽs��</FONT>
								</TD>
							</TR>
						</TABLE>
						<br>
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="0" width="90%" border="0">
							<TR>
								<TD class="TableColorHeader" colSpan="3">�d�߱���</TD>
							</TR>
							<TR>
								<TD align="right" width="90">���q�W�١G</TD>
								<TD width="160"><asp:textbox id="tbxMfrNm" runat="server" Width="150px"></asp:textbox></TD>
								<TD class="ContAnnounce" rowSpan="4"><asp:label id="lblContHint" CssClass="ContAnnounce" Runat="server">
									1.�п�J���@������Ӭd�ߡA�M����U"�d��".<BR>
										2.�d�X��ƫ�A���U"�ק�Ȥ���"�i�ק�ӫȤ᪺���<BR>
											3.�d�X��ƫ�A���U"�T�w"�i�~��[���@�X����]�B�J</asp:label><BR>
								</TD>
							</TR>
							<TR>
								<TD align="right">�Τ@�s���G</TD>
								<TD><asp:textbox id="tbxMfrNo" runat="server" Width="80px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="right">�Ȥ�s���G</TD>
								<TD><asp:textbox id="tbxCustNo" runat="server" Width="60px" MaxLength="6"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="right">�Ȥ�m�W�G</TD>
								<TD><asp:textbox id="tbxCustNm" runat="server" Width="80px"></asp:textbox><asp:linkbutton id="lnbQuery" runat="server">�d��</asp:linkbutton></TD>
							</TR>
							<TR>
								<TD align="right">�X���ѽs���G</TD>
								<TD><asp:textbox id="tbxContNo" runat="server" Width="80px"></asp:textbox><asp:linkbutton id="lngGoThis" runat="server">GO!!</asp:linkbutton></TD>
								<td><asp:label id="lblCustFound" runat="server" CssClass="SearchingMessage" ForeColor="Maroon"></asp:label></td>
							</TR>
						</TABLE>
						<asp:panel id="pnlQuery" runat="server" Width="90%">
							<BR>
							<asp:DataGrid id="dgdMfrCust" runat="server" Width="100%" CssClass="DataGridStyle" AllowPaging="True" AutoGenerateColumns="False">
								<ItemStyle CssClass="ItemStyle"></ItemStyle>
								<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
								<Columns>
									<asp:HyperLinkColumn Text="�ק�Ȥ���" Target="_self" DataNavigateUrlField="cust_custid" DataNavigateUrlFormatString="~/d5/cust_edit.aspx?ID={0}"></asp:HyperLinkColumn>
									<asp:BoundColumn DataField="mfr_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_custno" HeaderText="�Ȥ�s��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" HeaderText="�Ȥ�m�W"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_jbti" HeaderText="�Ȥ�¾��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_tel" HeaderText="�p���q��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_regdate" HeaderText="���U���"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_oldcustno" HeaderText="�«Ȥ�s��"></asp:BoundColumn>
									<asp:ButtonColumn Text="�T�w" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
								</Columns>
								<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" Position="Top" CssClass="PagerStyle"></PagerStyle>
							</asp:DataGrid>
						</asp:panel></td>
				</tr>
			</TABLE>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
	</body>
</HTML>
