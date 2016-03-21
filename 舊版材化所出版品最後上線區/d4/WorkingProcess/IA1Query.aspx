<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="IA1Query.aspx.cs" src="IA1Query.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.IA1Query" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>��@�t�ӵo���}�߲��͡G�d�߱���</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="IA1Query" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td align="middle">
						<TABLE id="tbItems" width="90%">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�o���B�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										��@�t�ӵo���}�߲��͡G�d�߱���</FONT>
								</TD>
							</TR>
						</TABLE>
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="0" width="90%" border="0">
							<TR>
								<TD class="TableColorHeader" colSpan="3">�d�߱���</TD>
							</TR>
							<TR>
								<TD align="right" width="90">���q�W�١G</TD>
								<TD width="160"><asp:textbox id="tbxMfrNm" runat="server" Width="150px"></asp:textbox></TD>
								<TD class="ContAnnounce" rowSpan="4"><asp:label id="lblContHint" Runat="server" CssClass="ContAnnounce">
									1.�п�J���@������Ӭd�ߡA�M����U"�d��".<BR>
									2.�d�X��ƫ�A��ܩһݪ��X�����U"�T�w"�i�i��U�@�B�J<br>
									3.�p��J�T�w���X���s��, ���U"GO!!"�i�����i��U�@�B�J</asp:label><BR>
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
						<asp:datagrid id="dgdCont" runat="server" Width="90%" CssClass="DataGridStyle" AllowPaging="True" AutoGenerateColumns="False">
							<ItemStyle CssClass="ItemStyle"></ItemStyle>
							<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="�X���s��"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_signdate" HeaderText="ñ�����"></asp:BoundColumn>
								<asp:BoundColumn DataField="mfr_inm" HeaderText="���q�W��"></asp:BoundColumn>
								<asp:BoundColumn DataField="cust_custno" HeaderText="�Ȥ�s��"></asp:BoundColumn>
								<asp:BoundColumn DataField="cust_nm" HeaderText="�Ȥ�m�W"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_aunm" HeaderText="�s�i�p���H�m�W"></asp:BoundColumn>
								<asp:BoundColumn DataField="cont_autel" HeaderText="�s�i�p���H�q��"></asp:BoundColumn>
								<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="cont_fgpayonce" HeaderText="�@���I�M���O"></asp:BoundColumn>
								<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="cont_fgclosed" HeaderText="�w����"></asp:BoundColumn>
								<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="cont_conttp" HeaderText="�X�����O"></asp:BoundColumn>
								<asp:BoundColumn ItemStyle-HorizontalAlign="Center" DataField="cont_disc" HeaderText="�u�f���"></asp:BoundColumn>
								<asp:ButtonColumn Text="�T�w" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
								<asp:BoundColumn Visible="False" DataField="cont_oldcontno" ReadOnly="True" HeaderText="cont_oldcontno"></asp:BoundColumn>
							</Columns>
							<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" Position="Top" CssClass="PagerStyle"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</TABLE>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
