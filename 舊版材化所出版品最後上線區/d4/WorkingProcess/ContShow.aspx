<%@ Page language="c#" Codebehind="ContShow.aspx.cs" Src="ContShow.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.ContShow" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���ƩҥX���~�Ȥ�޲z�t��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="ContShow" method="post" runat="server">
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%">
				<tr>
					<td align="middle"><br>
						<TABLE id="tbItems">
							<TR>
								<TD width="100%" align="middle" class="NormalLabel">�X�����
								</TD>
							</TR>
						</TABLE>
						<br>
					</td>
				</tr>
				<TR>
					<TD align="middle">
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="2" width="90%" border="0">
							<TR>
								<TD class="TableColorHeader">�t�ӤΫȤ���</TD>
							</TR>
							<TR>
								<TD>
									<!--�t�ӤΫȤ��� -->
									<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
										<TR>
											<TD align="right" width="25%">���q�W��(�νs)�G</TD>
											<TD width="30%"><asp:label id="lblMfrNm" runat="server">���q�W��</asp:label>(
												<asp:label id="lblMfrNo" runat="server">00000000</asp:label>&nbsp; )</TD>
											<TD align="right" width="15%">�ԲӸ�ơG</TD>
											<TD width="30%"><IMG onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>', '_new', 'Height=300, Width=400, Top=100, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=yes')" alt=�t�ӸԲӸ�� src="../../images/edit.gif" name=imgMfrDetail ></TD>
										</TR>
										<TR>
											<TD align="right">���q�t�d�H�m�W(¾��)�G</TD>
											<TD><asp:label id="lblRespData" runat="server">�t�d�H(¾��)</asp:label></TD>
											<TD align="right">���q�q��(�ǯu)�G</TD>
											<TD><asp:label id="lblMfrTelFax" runat="server">00-00000000(Fax: 00-00000000)</asp:label></TD>
										<TR>
											<TD align="right">�Ȥ�m�W(�s��)�G</TD>
											<TD><asp:label id="lblCustNm" runat="server">�Ȥ�m�W</asp:label>(
												<asp:label id="lblCustNo" runat="server">000000</asp:label>&nbsp; )</TD>
											<TD align="right">�ԲӸ�ơG</TD>
											<TD><IMG onclick="javascript:window.open('cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>', '_new', 'Height=420, Width=550, Top=60, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=yes')" alt=�Ȥ�ԲӸ�� src="../../images/edit.gif" name=imgCustDetail ></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="TableColorHeader">�X���Ѱ򥻸��</TD>
							</TR>
							<TR>
								<TD>
									<!--�X���Ѱ򥻸��-->
									<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
										<TR>
											<TD align="right" width="25%">ñ������G</TD>
											<TD width="30%">
												<asp:Label id="lblSignDate" runat="server" CssClass="NormalLabel"></asp:Label></TD>
											<TD align="right" width="15%">�X���s���G</TD>
											<TD width="30%"><asp:label id="lblContNo" runat="server">000000</asp:label></TD>
										</TR>
										<TR>
											<TD align="right">�X�����O�G</TD>
											<TD>
												<asp:Label id="lblContTp" runat="server" CssClass="NormalLabel"></asp:Label></TD>
											<TD>&nbsp;</TD>
											<TD>&nbsp;</TD>
										</TR>
										<TR>
											<TD align="right">�X���_����G</TD>
											<TD>
												<asp:Label id="lblSDate" runat="server" CssClass="NormalLabel"></asp:Label>&nbsp;��
												<asp:Label id="lblEDate" runat="server" CssClass="NormalLabel"></asp:Label><asp:label id="lblDayCount" runat="server"></asp:label></TD>
											<TD align="right">�ӿ�~�ȭ��G</TD>
											<TD>
												<asp:Label id="lblEmpDate" runat="server" CssClass="NormalLabel"></asp:Label></TD>
										</TR>
										<TR>
											<TD align="right">�@���I�M���O�G</TD>
											<TD>
												<asp:Label id="lblPayOnce" runat="server" CssClass="NormalLabel"></asp:Label></TD>
											<TD>&nbsp;</TD>
											<TD>&nbsp;</TD>
										</TR>
										<TR>
											<TD align="right">�X���Ƶ��G</TD>
											<TD colSpan="3">
												<asp:Label id="lblRemark" runat="server" CssClass="NormalLabel"></asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="TableColorHeader">�X���ѲӸ`</TD>
							</TR>
							<TR>
								<TD>
									<!--�X���ѲӸ`-->
									<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
										<TR>
											<TD align="right" width="25%">�Z�n���ơG</TD>
											<TD width="30%">
												<asp:Label id="lblPubTm" runat="server" CssClass="NormalLabel"></asp:Label><asp:label id="lblUnPubTm" runat="server" Visible="False"></asp:label></TD>
											<TD align="right" width="15%">�X���`���B�G</TD>
											<TD width="30%">
												<asp:Label id="lblTotAmt" runat="server" CssClass="NormalLabel"></asp:Label></TD>
										</TR>
										<TR>
											<TD align="right">�ذe���ơG</TD>
											<TD>
												<asp:Label id="lblFreeTm" runat="server" CssClass="NormalLabel"></asp:Label></TD>
											<TD align="right">�u�f��ơG</TD>
											<TD>
												<asp:Label id="lblDisc" runat="server" CssClass="NormalLabel"></asp:Label>(��: 
												0.8��ܤK��)</TD>
										</TR>
										<TR>
											<TD align="right">�`�s���ɽZ���ơG</TD>
											<TD>
												<asp:Label id="lblTotImgTm" runat="server" CssClass="NormalLabel"></asp:Label><asp:label id="lblUnImgTm" runat="server" Visible="False"></asp:label></TD>
											<TD align="right">&nbsp;</TD>
											<TD>&nbsp;</TD>
										</TR>
										<TR>
											<TD align="right">�`�s�����Z���ơG</TD>
											<TD>
												<asp:Label id="lblTotUrlTm" runat="server" CssClass="NormalLabel"></asp:Label><asp:label id="lblUnUrlTm" runat="server" Visible="False"></asp:label></TD>
											<TD align="right">&nbsp;</TD>
											<TD>&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="TableColorHeader">�s�i�p���H���</TD>
							</TR>
							<TR>
								<TD>
									<!--�s�i�p���H���-->
									<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
										<TR>
											<TD align="right" width="25%">�s�i�p���H�m�W�G</TD>
											<TD width="30%">
												<asp:Label id="lblAuNm" runat="server" CssClass="NormalLabel"></asp:Label></TD>
											<TD align="right" width="15%">&nbsp;</TD>
											<TD width="30%">&nbsp;</TD>
										</TR>
										<TR>
											<TD align="right">�q�ܡG</TD>
											<TD>
												<asp:Label id="lblAuTel" runat="server" CssClass="NormalLabel"></asp:Label></TD>
											<TD align="right">�ǯu�G</TD>
											<TD>
												<asp:Label id="lblAuFax" runat="server" CssClass="NormalLabel"></asp:Label></TD>
										</TR>
										<TR>
											<TD align="right">����G</TD>
											<TD>
												<asp:Label id="lblAuCell" runat="server" CssClass="NormalLabel"></asp:Label></TD>
											<TD align="right">Email�G</TD>
											<TD>
												<asp:Label id="lblAuEmail" runat="server" CssClass="NormalLabel"></asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<!--
							<TR>
								<TD class="TableColorHeader">�s�i���s����B�����B���~�]�Ƥ���B���ƯS�ʡB���β��~���������</TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD class="TableColorHeader">�o���t�Ӧ���H���</TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD class="TableColorHeader">���x����H���خѸ��</TD>
							</TR>
							<TR>
								<TD><asp:datagrid id="dgdFreeBk" runat="server" Width="100%" AutoGenerateColumns="False" AllowPaging="True" CssClass="DataGridStyle">
										<ItemStyle CssClass="ItemStyle"></ItemStyle>
										<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="fbk_fbkitem" HeaderText="�خѶ���"></asp:BoundColumn>
											<asp:BoundColumn DataField="fbk_sdate" HeaderText="�خѰ_��"></asp:BoundColumn>
											<asp:BoundColumn DataField="fbk_edate" HeaderText="�خѨ���"></asp:BoundColumn>
											<asp:BoundColumn DataField="bk_nm" HeaderText="���y"></asp:BoundColumn>
											<asp:BoundColumn DataField="or_nm" HeaderText="����H"></asp:BoundColumn>
											<asp:BoundColumn DataField="or_addr" HeaderText="�a�}"></asp:BoundColumn>
											<asp:BoundColumn DataField="ma_pubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
											<asp:BoundColumn DataField="ma_unpubmnt" HeaderText="���Z�n����"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="�l�H���O">
												<ItemTemplate>
													<asp:Label id=lblMtpNm runat="server" Text='<%# GetMtpNm(DataBinder.Eval(Container.DataItem, "ma_mtpcd")) %>'>
													</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn Visible="False" DataField="fbk_fbkitem" HeaderText="fbkitem"></asp:BoundColumn>
										</Columns>
										<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" Position="Top" CssClass="PagerStyle"></PagerStyle>
									</asp:datagrid></TD>
							</TR>
							-->
							<TR>
								<TD align=center><INPUT onclick="javascript:window.close();" type="button" value="����" name="btnClose"></TD>
							</TR>
							<TR>
								<TD><asp:textbox id="tbxHidMfrNo" runat="server" Visible="False" Width="10px"></asp:textbox><asp:textbox id="tbxHidCustNo" runat="server" Visible="False" Width="10px"></asp:textbox>
									<asp:TextBox id="tbxOldContNo" runat="server" Visible="False" Width="10px"></asp:TextBox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
