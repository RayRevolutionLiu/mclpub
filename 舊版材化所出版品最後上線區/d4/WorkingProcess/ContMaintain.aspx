<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="ContMaintain.aspx.cs" Src="ContMaintain.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.ContMaintain" %>
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
		<form id="ContMaintain" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="90%" align="center">
				<tr>
					<td>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�X���B�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										���@�X���� �B�J�T: ���@�X��</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD><asp:panel id="pnlContBody" Runat="server" Width="100%">
							<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
								<TR>
									<TD class="TableColorHeader">�t�ӤΫȤ���</TD>
								</TR>
								<TR>
									<TD><!--�t�ӤΫȤ��� -->
										<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
											<TR>
												<TD align="right" width="20%">���q�W��(�νs)�G</TD>
												<TD width="30%">
													<asp:label id="lblMfrNm" runat="server" ForeColor="Maroon">���q�W��</asp:label>(
													<asp:label id="lblMfrNo" runat="server" ForeColor="Maroon">00000000</asp:label>&nbsp; 
													)</TD>
												<TD align="right" width="15%">�ԲӸ�ơG</TD>
												<TD width="35%"><IMG 
                  onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>', '_new', 'Height=300, Width=400, Top=100, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=yes')" 
                  alt=�t�ӸԲӸ�� src="../../images/edit.gif" 
name=imgMfrDetail></TD>
											</TR>
											<TR>
												<TD align="right">���q�t�d�H�m�W(¾��)�G</TD>
												<TD>
													<asp:label id="lblRespData" runat="server" ForeColor="Maroon">�t�d�H(¾��)</asp:label></TD>
												<TD align="right">���q�q��(�ǯu)�G</TD>
												<TD>
													<asp:label id="lblMfrTelFax" runat="server" ForeColor="Maroon">00-00000000(Fax: 00-00000000)</asp:label></TD>
											<TR>
												<TD align="right">�Ȥ�m�W(�s��)�G</TD>
												<TD>
													<asp:label id="lblCustNm" runat="server" ForeColor="Maroon">�Ȥ�m�W</asp:label>(
													<asp:label id="lblCustNo" runat="server" ForeColor="Maroon">000000</asp:label>&nbsp; 
													)</TD>
												<TD align="right">�ԲӸ�ơG</TD>
												<TD><IMG 
                  onclick="javascript:window.open('cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>', '_new', 'Height=420, Width=550, Top=60, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=yes')" 
                  alt=�Ȥ�ԲӸ�� src="../../images/edit.gif" 
              name=imgCustDetail></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TableColorHeader">�X���Ѱ򥻸��</TD>
								</TR>
								<TR>
									<TD><!--�X���Ѱ򥻸��-->
										<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
											<TR>
												<TD align="right" width="20%">�X���s���G</TD>
												<TD width="30%">
													<asp:label id="lblContNo" runat="server" ForeColor="Maroon">000000</asp:label></TD>
												<TD align="right" width="15%">ñ������G</TD>
												<TD width="35%">
													<asp:textbox id="tbxSignDate" runat="server" Width="80px" MaxLength="10"></asp:textbox><IMG onclick='javascript:pick_date("tbxSignDate", "tbxSDate", "tbxEDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate"></TD>
											</TR>
											<TR>
												<TD align="right">�X�����O�G</TD>
												<TD>
													<asp:dropdownlist id="ddlContTp" runat="server">
														<asp:ListItem Value="01" Selected="True">�@��X��</asp:ListItem>
														<asp:ListItem Value="09">���s�X��</asp:ListItem>
													</asp:dropdownlist></TD>
												<TD align="right">�X���_����G</TD>
												<TD>
													<asp:textbox id="tbxSDate" runat="server" Width="80px" MaxLength="10"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxSDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">&nbsp;��
													<asp:textbox id="tbxEDate" runat="server" Width="80px" MaxLength="10" AutoPostBack="True"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxEDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">
													<asp:label id="lblDayCount" runat="server"></asp:label></TD>
											</TR>
											<TR>
												<TD align="right">�w�}�L�o���G</TD>
												<TD>
													<asp:radiobuttonlist id="rblPayOnce" runat="server" RepeatDirection="Horizontal" Enabled="False">
														<asp:ListItem Value="1">�O</asp:ListItem>
														<asp:ListItem Value="0" Selected="True">�_</asp:ListItem>
													</asp:radiobuttonlist></TD>
												<TD align="right">�ӿ�~�ȭ��G</TD>
												<TD>
													<asp:dropdownlist id="ddlEmpData" runat="server"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD align="right">�X���Ƶ��G</TD>
												<TD colSpan="3">
													<asp:textbox id="tbxRemark" runat="server" Width="273px" MaxLength="50"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TableColorHeader">�X���ѲӸ`</TD>
								</TR>
								<TR>
									<TD><!--�X���ѲӸ`-->
										<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
											<TR>
												<TD align="right" width="20%">�Z�n���ơG</TD>
												<TD width="30%">
													<asp:textbox id="tbxPubTm" runat="server" Width="80px"></asp:textbox>
													<asp:label id="lblUnPubTm" runat="server"></asp:label>
													<asp:Button id="btnCount" runat="server" Text="�p�⦸��"></asp:Button></TD>
												<TD align="right" width="15%">�X���`���B�G</TD>
												<TD width="35%">
													<asp:textbox id="tbxTotAmt" runat="server" Width="80px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD align="right">�ذe���ơG</TD>
												<TD>
													<asp:textbox id="tbxFreeTm" runat="server" Width="80px"></asp:textbox></TD>
												<TD align="right">�u�f��ơG</TD>
												<TD>
													<asp:textbox id="tbxDisc" runat="server" Width="80px"></asp:textbox>(��: 
													0.8��ܤK��)</TD>
											</TR>
											<TR>
												<TD align="right">�`�s���ɽZ���ơG</TD>
												<TD>
													<asp:textbox id="tbxTotImgTm" runat="server" Width="80px"></asp:textbox>
													<asp:label id="lblUnImgTm" runat="server"></asp:label></TD>
												<TD align="right">&nbsp;</TD>
												<TD>&nbsp;</TD>
											</TR>
											<TR>
												<TD align="right">�`�s�����Z���ơG</TD>
												<TD>
													<asp:textbox id="tbxTotUrlTm" runat="server" Width="80px"></asp:textbox>
													<asp:label id="lblUnUrlTm" runat="server"></asp:label></TD>
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
									<TD><!--�s�i�p���H���-->
										<TABLE cellSpacing="0" cellPadding="2" width="100%" border="0">
											<TR>
												<TD align="right" width="20%">�s�i�p���H�m�W�G</TD>
												<TD width="30%">
													<asp:textbox id="tbxAuNm" runat="server" Width="80px"></asp:textbox></TD>
												<TD align="right" width="15%">&nbsp;</TD>
												<TD width="35%">&nbsp;</TD>
											</TR>
											<TR>
												<TD align="right">�q�ܡG</TD>
												<TD>
													<asp:textbox id="tbxAuTel" runat="server" Width="80px"></asp:textbox></TD>
												<TD align="right">�ǯu�G</TD>
												<TD>
													<asp:textbox id="tbxAuFax" runat="server" Width="80px"></asp:textbox></TD>
											</TR>
											<TR>
												<TD align="right">����G</TD>
												<TD>
													<asp:textbox id="tbxAuCell" runat="server" Width="80px"></asp:textbox></TD>
												<TD align="right">Email�G</TD>
												<TD>
													<asp:textbox id="tbxAuEmail" runat="server" Width="150px"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TableColorHeader">�s�i���s����B�����B���~�]�Ƥ���</TD>
								</TR>
								<TR>
									<TD>
										<TABLE class="TableColor" cellSpacing="0" cellPadding="1" width="100%" border="0">
											<TR>
												<TD align="right" width="20%">�s�i���s����G</TD>
												<TD>
													<asp:textbox id="tbxCCont" runat="server" Width="407px" MaxLength="25"></asp:textbox></TD>
											</TR>
											<TR>
												<TD align="right">�j�M�����G</TD>
												<TD>
													<asp:textbox id="tbxCsDate" runat="server" Width="80px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxCsDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">
													<asp:regularexpressionvalidator id="revCsDate" runat="server" ErrorMessage="�榡���~�A�п�J���T�榡" Display="Dynamic" ControlToValidate="tbxCsDate" CssClass="ValidatorStyle" ValidationExpression="[1-2]\d{3}\/[0-2]\d\/[0-3]\d"></asp:regularexpressionvalidator>(�p�G2002/12/31)</TD>
											</TR>
											<TR>
												<TD align="right">���~�]�Ƥ���G
												</TD>
												<TD>
													<asp:textbox id="tbxPdCont" runat="server" Width="500px" MaxLength="250" TextMode="MultiLine" Rows="3" Height="94px"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="TableColorHeader">���ƯS�ʤ����β��~�������</TD>
								</TR>
								<TR>
									<TD>
										<TABLE class="TableColor" cellSpacing="0" cellPadding="1" width="100%" border="0">
											<TR>
												<TD vAlign="top" width="50%">���ƯS�ʡG<IMG 
                  onclick='doOpenMisc(<% Response.Write("\""+lblContNo.Text+"\""); %>, "1")' 
                  alt=ATP_MATP src="../../images/edit.gif" name=imgAtpMatp>
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
												<TD vAlign="top">���β��~�G<IMG 
                  onclick='doOpenMisc(<% Response.Write("\""+lblContNo.Text+"\""); %>, "2")' 
                  alt=ATP_MATP src="../../images/edit.gif" name=imgAtpMatp>
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
								<TR>
									<TD class="TableColorHeader">���x����H���خѸ��<IMG 
            onclick='doOpenFreeBk(<% Response.Write("\""+ lblCustNo.Text +"\""); %>, <% Response.Write("\""+lblContNo.Text+"\""); %>, <% Response.Write("\"" + tbxOldContNo.Text + "\""); %>)' 
            alt=�Բ� src="..\..\images\new.gif" name=imgAddFreeBk></TD>
								</TR>
								<TR>
									<TD>
										<asp:datagrid id="dgdNewOr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
											<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
											<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemStyle"></ItemStyle>
											<HeaderStyle CssClass="HeaderStyle" Wrap="False"></HeaderStyle>
											<Columns>
												<asp:BoundColumn ItemStyle-Width="25" DataField="or_oritem" HeaderText="�Ǹ�"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_inm" HeaderText="���q�W��"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_nm" HeaderText="���x����H�m�W"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_jbti" HeaderText="�ٿ�"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_addr" HeaderText="�a�}"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_tel" HeaderText="�q��"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_fax" HeaderText="�ǯu"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_cell" HeaderText="���"></asp:BoundColumn>
												<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="or_fgmosea" HeaderText="��~"></asp:BoundColumn>
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
										</asp:DataGrid></TD>
								</TR>
								<TR>
									<TD class="TableColorHeader">�o���t�Ӱ򥻸��<IMG 
            onclick='doOpenInvMfr(<% Response.Write("\""+lblContNo.Text+"\""); %>, <% Response.Write("\"" + tbxOldContNo.Text + "\""); %>, <% Response.Write("\"" + lblMfrNo.Text + "\""); %>)' 
            alt=�Բ� src="..\..\images\new.gif" name=imgAddInvMfr></TD>
								</TR>
								<TR>
									<TD>
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
										</asp:datagrid></TD>
								</TR>
								<TR>
									<TD>
										<TABLE borderColor="red" border="1">
											<TR>
												<TD>
													<asp:Label id="Label1" runat="server">�X���{�p</asp:Label></TD>
												<TD>
													<asp:RadioButtonList id="rblClosed" runat="server" Width="158px" RepeatDirection="Horizontal" Height="14px">
														<asp:ListItem Value="0">�i�椤</asp:ListItem>
														<asp:ListItem Value="1">�w����</asp:ListItem>
													</asp:RadioButtonList></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD>
										<asp:Button id="btnSave" runat="server" Text="�x�s�X��"></asp:Button>
										<asp:Button id="btnNoSave" runat="server" Text="�����x�s"></asp:Button>
										<asp:Button id="btnFgCancel" runat="server" Text="���P�X��" CssClass="AlertButtonStyle"></asp:Button></TD>
								</TR>
								<TR>
									<TD>
										<asp:textbox id="tbxHidMfrNo" runat="server" Width="10px" Visible="False"></asp:textbox>
										<asp:textbox id="tbxHidCustNo" runat="server" Width="10px" Visible="False"></asp:textbox>
										<asp:TextBox id="tbxOldContNo" runat="server" Width="10px" Visible="False"></asp:TextBox></TD>
								</TR>
							</TABLE>
						</asp:panel><asp:panel id="pnlBack" Runat="server" Width="100%">
							<P align="center">
								<asp:Button id="btnHome" Runat="server" Text="�^�D���"></asp:Button></P>
						</asp:panel></TD>
				</TR>
			</TABLE>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="���P�X��")
				event.returnValue=confirm("�T�w�n���P���X��?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
