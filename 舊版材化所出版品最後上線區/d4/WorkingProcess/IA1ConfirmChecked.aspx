<%@ Page language="c#" Codebehind="IA1ConfirmChecked.aspx.cs" src="IA1ConfirmChecked.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.IA1ConfirmChecked" %>
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
		<form id="IA1ConfirmChecked" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="90%" align="center">
				<tr>
					<td><br>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�o�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										��@�X���o���}�ߡG�o���}�߽T�{</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD>
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader" style="HEIGHT: 24px" colSpan="11"><asp:label id="lblContInfo" runat="server" CssClass="TableColorHeader">�X���򥻸��</asp:label></TD>
							</TR>
							<tr>
								<td>
									<TABLE class="TableColor" id="Table11" cellSpacing="0" cellPadding="2" width="100%" border="1">
										<TR class="TableColor">
											<TD>�X���s��</TD>
											<TD>�X�����O</TD>
											<TD>ñ�����</TD>
											<TD>�X���_��</TD>
											<TD>�Z�n����</TD>
											<TD>�ذe����</TD>
											<TD>�X�����B</TD>
											<TD>�u�f���</TD>
											<TD>�`�s���ɽZ����</TD>
											<TD>�`�s�����Z����</TD>
										</TR>
										<TR>
											<TD bgColor="#ecebff"><asp:label id="lblContNo" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblContTp" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblSignDate" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblSDate" runat="server" CssClass="NormalLabel"></asp:label>��
												<asp:label id="lblEDate" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblPubTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblFreeTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD align="right" bgColor="#ecebff">$<asp:label id="lblTotAmt" runat="server" CssClass="NormalLabel" ForeColor="Red"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblDisc" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblTotImgTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblTotUrlTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE class="TableColor" id="Table2" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader" style="HEIGHT: 24px" colSpan="11"><asp:label id="Label1" runat="server" CssClass="TableColorHeader">�o���}�߳���</asp:label></TD>
							</TR>
							<tr>
								<td>
									<TABLE class="TableColor" id="Table21" cellSpacing="0" cellPadding="2" width="100%" border="1">
										<TR class="TableColor">
											<TD>�t�Ӳνs</TD>
											<TD>�o�����B</TD>
											<TD>�p���N��</TD>
											<TD>�o������H�m�W</TD>
											<TD>¾��</TD>
											<TD>�l���ϸ�</TD>
											<TD>�a�}</TD>
											<TD>�q��</TD>
											<TD>�o�����O</TD>
											<TD>�ҵ|�O</TD>
											<TD>����</TD>
										</TR>
										<TR>
											<TD bgColor="#ecebff"><asp:label id="lblMfrno" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD align="right" bgColor="#ecebff">$<asp:label id="lblPyat" runat="server" CssClass="NormalLabel" ForeColor="Red"></asp:label></TD>
											<TD align="middle" bgColor="#ecebff"><asp:label id="lblProjNo" runat="server" CssClass="NormalLabel" ForeColor="Red"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblNm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblJbti" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblZip" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblAddr" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblTel" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblInvcd" runat="server" CssClass="NormalLabel"></asp:label><asp:label id="lblInvcd1" runat="server" CssClass="NormalLabel" Visible="False"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblTaxtp" runat="server" CssClass="NormalLabel"></asp:label><asp:label id="lblTaxtp1" runat="server" CssClass="NormalLabel" Visible="False"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblFgitri" runat="server" CssClass="NormalLabel"></asp:label><asp:label id="lblFgitri1" runat="server" CssClass="NormalLabel" Visible="False"></asp:label></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<td>
						<TABLE class="TableColor" id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader" style="HEIGHT: 24px" colSpan="11"><asp:label id="lblAdrInfo" runat="server" CssClass="TableColorHeader">�o���}�߳���Ӹ��</asp:label>
									<asp:Label id="lblCount" runat="server" ForeColor="Yellow"></asp:Label></TD>
							</TR>
							<tr>
								<td><asp:datagrid id="dgdSubAdr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
										<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
										<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemStyle"></ItemStyle>
										<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="adr_seq" ReadOnly="True" HeaderText="�Ǹ�">
												<HeaderStyle Width="25px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_addate" ReadOnly="True" HeaderText="���X���">
												<HeaderStyle Width="60px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_alttext" ReadOnly="True" HeaderText="�s�i�лy">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="adr_adcate" ReadOnly="True" HeaderText="�s�i����">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="adr_keyword" ReadOnly="True" HeaderText="�s�i��m">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_navurl" ReadOnly="True" HeaderText="�s�i�s��">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_impr" ReadOnly="True" HeaderText="������v">
												<HeaderStyle Width="25px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_adamt" ReadOnly="True" HeaderText="�s�i����">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_desamt" ReadOnly="True" HeaderText="�]�p����">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_chgamt" ReadOnly="True" HeaderText="���Z�O��">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_invamt" ReadOnly="True" HeaderText="�o�����B">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="adr_remark" ReadOnly="True" HeaderText="�Ƶ�">
												<HeaderStyle Width="100px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="adr_imseq" ReadOnly="True" HeaderText="�o���t��">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
									</asp:datagrid><asp:panel id="pnlAdr" Width="100%" Runat="server">
										<asp:Button id="btnBack" runat="server" Text="�D�����s�D��" ToolTip="�Ŀ諸���ؤ���, ���s�D��"></asp:Button>
										<asp:Button id="btnModifyAdr" runat="server" Text="�������B���~, �ק︨�����B" ToolTip="�������B���~, �e�������B�z"></asp:Button>
										<asp:Button id="btnCancel" runat="server" Text="����, �^����" ToolTip="�^����"></asp:Button>
										<asp:Button id="btnPrint" runat="server" Text="�C�L�w���M��"></asp:Button>
										<asp:Button id="btnConfirm" runat="server" ForeColor="Red" Text="�T�w���͵o���}�߳�" ToolTip="�T�w���͵o���}�߳�"></asp:Button>
									</asp:panel><asp:panel id="pnlNext" Visible="False" Width="100%" Runat="server">
										<asp:Label id="lblMessage" runat="server" ForeColor="#C00000"></asp:Label>
										<BR>
										<asp:Button id="btnContinue" runat="server" Text="�~��o���}�ߧ@�~(�P�X��)"></asp:Button>
										<asp:Button id="btnGoIA1" runat="server" Text="�~��o���}�ߧ@�~(���P�X��)"></asp:Button>
										<asp:Button id="btnExit" runat="server" Text="����, �^����"></asp:Button>
									</asp:panel></td>
							</tr>
						</TABLE>
						<asp:Literal id="Literal1" runat="server"></asp:Literal></td>
				</TR>
			</TABLE>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
	</body>
</HTML>
