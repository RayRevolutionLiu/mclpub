<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="ContChkList.aspx.cs" src="ContChkList.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.ContChkList" %>
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
		<form id="ContChkList" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<table width="100%">
				<tr>
					<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
							�X���B�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
							�X�����ˮ֪�</FONT>
					</TD>
				</tr>
				<tr>
					<td>
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader" colSpan="2">�d�߱���</TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxContNo" runat="server" Text="�X���ѽs���G"></asp:checkbox><asp:textbox id="tbxContNo" runat="server" Width="100px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxDate" runat="server" Text="ñ������϶��G"></asp:checkbox><asp:textbox id="tbxSDate" runat="server" Width="100px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxSDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">��
									<asp:textbox id="tbxEDate" runat="server" Width="100px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxEDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">
									<asp:label id="lblyyyymmdd" runat="server" CssClass="ImportantLabel">(yyyy/mm/dd)</asp:label></TD>
							</TR>
							<TR>
								<TD><asp:checkbox id="cbxEmpData" runat="server" Text="�ӿ�~�ȭ��G"></asp:checkbox><asp:dropdownlist id="ddlEmpData" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD>
									<asp:CheckBox id="cbxClosed" runat="server" Text="�w���סG"></asp:CheckBox><asp:dropdownlist id="ddlClosed" runat="server">
										<asp:ListItem Value="0" Selected="True">�_</asp:ListItem>
										<asp:ListItem Value="1">�O</asp:ListItem>
									</asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD><asp:button id="btnGo" runat="server" Text="���ͦX�����ˮ֪�"></asp:button><asp:label id="lblRecordCount" runat="server" ForeColor="Red"></asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table2" cellSpacing="0" cellPadding="1" width="100%" border="0">
							<tr>
								<td colSpan="2"><asp:datalist id="DataList1" runat="server" Width="100%" Font-Size="8pt" Font-Names="�s�ө���">
										<ItemTemplate>
											<TABLE width="100%" bgColor="#e6ebf9" borderColor="#666666" cellSpacing="1" cellPadding="0" align="center" style="FONT-SIZE: x-small" border="1">
												<!-- ���D -->
												<TR style="COLOR: white" bgColor="#21418c">
													<TD>
														�X���ѽs��
													</TD>
													<TD colSpan="3">
														�t�ӦW��(�t�Ӳνs)
													</TD>
													<TD>
														�Ȥ�W��(�s��)
													</TD>
													<TD>
														ñ�����
													</TD>
													<TD>
														�X�����O
													</TD>
													<TD>
														�X���_��
													</TD>
													<TD>
														�~�ȤH��
													</TD>
													<TD>
														�ק�H��
													</TD>
													<TD>
														�@���I�M
													</TD>
													<TD>
														����
													</TD>
													<TD>
														���ɤ��
													</TD>
													<TD>
														�ק���
													</TD>
												</TR>
												<!-- ��X���e -->
												<TR vAlign="top">
													<TD width="7%" style="FONT-WEIGHT: bold" rowspan="8">
														<asp:Label id="lblContno" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_contno") %>'>
														</asp:Label>
													</TD>
													<TD colSpan="3" width="*">
														<asp:Label id="lblMfrIName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "mfr_inm").ToString().Trim() %>'>
														</asp:Label>
														(
														<asp:Label id="lblMfrNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_mfrno").ToString().Trim() %>'>
														</asp:Label>
														)
													</TD>
													<TD width="9%">
														<asp:Label id="lblCustName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cust_nm").ToString().Trim() %>'>
														</asp:Label>
														(
														<asp:Label id="lblCustNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_custno").ToString().Trim() %>'>
														</asp:Label>
														)
													</TD>
													<TD width="6%">
														<asp:Label id="lblSignDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_signdate").ToString().Trim() %>'>
														</asp:Label>
													</TD>
													<TD width="6%">
														<asp:Label id="lblConttp" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_conttp").ToString().Trim() %>'>
														</asp:Label>
													</TD>
													<TD width="6%">
														<asp:Label id="lblStartDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_sdate").ToString().Trim() %>'>
														</asp:Label>~
														<asp:Label id="lblEndDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_edate").ToString().Trim() %>'>
														</asp:Label>
													</TD>
													<TD width="6%">
														<asp:Label id="lblEmpNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "inputuser").ToString().Trim() %>'>
														</asp:Label>
													</TD>
													<TD width="8%">
														<asp:Label id="lblModEmpNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "moduser").ToString().Trim() %>'>
														</asp:Label>
													</TD>
													<TD width="8%">
														<asp:Label id="lblfgPayonce" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_fgpayonce").ToString().Trim() %>'>
														</asp:Label>
													</TD>
													<TD width="8%">
														<asp:Label id="lblfgClosed" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_fgclosed").ToString().Trim() %>'>
														</asp:Label>
													</TD>
													<TD width="8%">
														<asp:Label id="lblCreateDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_credate").ToString().Trim() %>'>
														</asp:Label>
													</TD>
													<TD width="8%">
														<asp:Label id="lblModifyDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_moddate").ToString().Trim() %>'>
														</asp:Label>
													</TD>
												</TR>
												<TR style="COLOR: #000000" bgColor="#BFCFF0">
													<TD>
														�`�s���ɽZ����
													</TD>
													<TD>
														�`�s�����Z����
													</TD>
													<td>�Z�n����</td>
													<td>�ذe����</td>
													<TD>
														�`�Z�n����
													</TD>
													<TD>
														�w�Z�n����
													</TD>
													<TD>
														�Ѿl�Z�n����
													</TD>
													<TD>
														�X���`���B
													</TD>
													<TD>
														�wú���B
													</TD>
													<TD>
														�Ѿl���B
													</TD>
													<TD>
														�u�f�馩
													</TD>
													<td colspan="2">�X���Ƶ�</td>
												</TR>
												<TR vAlign="top" align="right">
													<TD>
														<asp:Label id="lblTotimgtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_totimgtm").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</TD>
													<TD>
														<asp:Label id="lblToturltm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_toturltm").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</TD>
													<TD>
														<asp:Label id="lblRestjtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_pubtm").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</TD>
													<TD>
														<asp:Label id="lblTottm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_freetm").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</TD>
													<TD>
														<asp:Label id="lblPubtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_pubtm").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</TD>
													<TD>
														<asp:Label id="lblResttm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "enpubtm").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</TD>
													<TD>
														<asp:Label id="lblTotamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_resttm").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</TD>
													<TD>
														$
														<asp:Label id="lblPaidamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_totamt").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</TD>
													<TD>
														$
														<asp:Label id="lblRestamt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_paidamt").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</TD>
													<TD>$
														<asp:Label id="lblChgjtm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_restamt").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</TD>
													<TD>
														<asp:Label id="lblFreetm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_disc").ToString().Trim() %>'>
														</asp:Label>
													</TD>
													<TD colspan="2">
														<asp:Label id="lblRemark" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_remark").ToString().Trim() %>'>
														</asp:Label>
													</TD>
												</TR>
												<TR style="COLOR: #000000" bgColor="#BFCFF0">
													<TD>
														�p���H�m�W
													</TD>
													<TD>
														�q��
													</TD>
													<TD>
														�ǯu
													</TD>
													<TD colspan="2">
														��� / Email
													</TD>
													<TD colspan="2">
														�s�i���s����
													</TD>
													<td>�j�M����</td>
													<td colspan="5">���~�]�Ƥ���</td>
												</TR>
												<TR vAlign="top">
													<TD>
														<asp:Label id="lblAunm" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_aunm").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</TD>
													<TD>
														<asp:Label id="lblAuTel" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_autel").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</TD>
													<TD>
														<asp:Label id="lblAuFax" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_aufax").ToString().Trim() %>'>
														</asp:Label>
														&nbsp;
													</TD>
													<TD colspan="2">
														<asp:Label id="lblAuCell" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_aucell").ToString().Trim() %>'>
														</asp:Label>/
														<asp:Label id="lblAuEmail" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_auemail").ToString().Trim() %>'>
														</asp:Label>
													</TD>
													<td colspan="2">
														<asp:Label id="lblCcont" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_ccont").ToString().Trim() %>'>
														</asp:Label>
													</td>
													<td>
														<asp:Label id="lblCsdate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_csdate").ToString().Trim() %>'>
														</asp:Label>
													</td>
													<td colspan="5">
														<asp:Label id="lblPdcont" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "cont_pdcont").ToString().Trim() %>'>
														</asp:Label>
													</td>
												</TR>
												<!-- ���ƯS�ʤ����β��~������� -->
												<TR vAlign="top">
													<TD colSpan="14" style="COLOR: #ffffff" bgColor="#5980d9">
														<TABLE cellSpacing="0" cellPadding="1" width="100%" border="0">
															<TR>
																<TD vAlign="top" width="50%" style="COLOR: #ffffff" bgColor="#5980d9">���ƯS�ʡG
																	<asp:datagrid id="dgdAtpMatp1" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False" ShowHeader="False" CellPadding="2">
																		<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
																		<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
																		<ItemStyle CssClass="ItemStyle"></ItemStyle>
																		<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
																		<Columns>
																			<asp:BoundColumn DataField="cls2_cname" ReadOnly="True">
																				<ItemStyle Wrap="False"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="cls3_cname" ReadOnly="True"></asp:BoundColumn>
																		</Columns>
																	</asp:datagrid></TD>
																<TD vAlign="top" style="COLOR: #ffffff" bgColor="#5980d9">���β��~�G
																	<asp:datagrid id="dgdAtpMatp2" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False" ShowHeader="False" CellPadding="2">
																		<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
																		<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
																		<ItemStyle CssClass="ItemStyle"></ItemStyle>
																		<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
																		<Columns>
																			<asp:BoundColumn DataField="cls2_cname" ReadOnly="True">
																				<ItemStyle Wrap="False"></ItemStyle>
																			</asp:BoundColumn>
																			<asp:BoundColumn DataField="cls3_cname" ReadOnly="True"></asp:BoundColumn>
																		</Columns>
																	</asp:datagrid></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<!-- �o���t�Ӧ���H -->
												<TR vAlign="top">
													<TD colSpan="14" style="COLOR: #ffffff" bgColor="#5980d9">
														&nbsp;�o���t�Ӱ򥻸�ơG
														<BR>
														<asp:datagrid id="dgdNewInvMfr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
															<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
															<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
															<ItemStyle CssClass="ItemStyle"></ItemStyle>
															<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
															<Columns>
																<asp:BoundColumn ItemStyle-Width="25" DataField="im_imseq" HeaderText="�Ǹ�"></asp:BoundColumn>
																<asp:BoundColumn ItemStyle-Width="60" DataField="im_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
																<asp:BoundColumn ItemStyle-Width="60" DataField="im_nm" HeaderText="����H�m�W"></asp:BoundColumn>
																<asp:BoundColumn DataField="im_jbti" HeaderText="�ٿ�"></asp:BoundColumn>
																<asp:BoundColumn DataField="im_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
																<asp:BoundColumn DataField="im_addr" HeaderText="�a�}"></asp:BoundColumn>
																<asp:BoundColumn DataField="im_tel" HeaderText="�q��"></asp:BoundColumn>
																<asp:BoundColumn DataField="im_fax" HeaderText="�ǯu"></asp:BoundColumn>
																<asp:BoundColumn DataField="im_cell" HeaderText="���"></asp:BoundColumn>
																<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
																<asp:BoundColumn DataField="invcd" HeaderText="�o�����O"></asp:BoundColumn>
																<asp:BoundColumn DataField="taxtp" HeaderText="�o���ҵ|�O"></asp:BoundColumn>
																<asp:BoundColumn DataField="im_fgitri" HeaderText="�|�Ҥ����O"></asp:BoundColumn>
															</Columns>
														</asp:datagrid>
													</TD>
												</TR>
												<!-- ���x����H���خѸ�� -->
												<TR vAlign="top">
													<TD colSpan="14" style="COLOR: #ffffff" bgColor="#5980d9">
														&nbsp;���x����H���خѸ�ơG
														<BR>
														<asp:datagrid id="dgdNewOr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
															<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
															<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
															<ItemStyle CssClass="ItemStyle"></ItemStyle>
															<HeaderStyle CssClass="HeaderStyle" Wrap="False"></HeaderStyle>
															<Columns>
																<asp:BoundColumn ItemStyle-Width="25" DataField="or_oritem" HeaderText="�Ǹ�"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_nm" HeaderText="���x����H�m�W"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_jbti" HeaderText="�ٿ�"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_addr" HeaderText="�a�}"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_tel" HeaderText="�q��"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_fax" HeaderText="�ǯu"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_cell" HeaderText="���"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
																<asp:BoundColumn DataField="or_fgmosea" HeaderText="��~"></asp:BoundColumn>
															</Columns>
														</asp:datagrid>
														<asp:DataGrid id="dgdNewFreeBk" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
															<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
															<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
															<ItemStyle CssClass="ItemStyle"></ItemStyle>
															<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
															<Columns>
																<asp:BoundColumn ItemStyle-Width="25" DataField="fbk_fbkitem" HeaderText="����"></asp:BoundColumn>
																<asp:BoundColumn ItemStyle-Width="60" DataField="str_ma_sdate" HeaderText="�خѰ_��"></asp:BoundColumn>
																<asp:BoundColumn ItemStyle-Width="60" DataField="str_ma_edate" HeaderText="�خѨ���"></asp:BoundColumn>
																<asp:BoundColumn DataField="fc_nm" HeaderText="���y"></asp:BoundColumn>
																<asp:BoundColumn ItemStyle-Width="60" DataField="or_nm" HeaderText="����H"></asp:BoundColumn>
																<asp:BoundColumn DataField="ma_pubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
																<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
																<asp:BoundColumn Visible="False" DataField="fbk_fbkitem" HeaderText="fbkitem"></asp:BoundColumn>
															</Columns>
															<PagerStyle CssClass="PagerStyle"></PagerStyle>
														</asp:DataGrid>
													</TD>
												</TR>
											</TABLE>
										</ItemTemplate>
									</asp:datalist></td>
							</tr>
						</TABLE>
					</td>
				</tr>
			</table>
			<!-- ���� Footer --></form>
	</body>
</HTML>
