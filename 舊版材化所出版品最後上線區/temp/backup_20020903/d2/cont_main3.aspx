<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="cont_main3.aspx.cs" Src="cont_main3.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.cont_main3" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>���@�X���� �B�J�T</TITLE>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Object: DSO0, DSO1, DSOX -->
		<OBJECT id="DSO0" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
		<OBJECT id="DSO1" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
		<OBJECT id="DSOX" height="0" width="0" classid="clsid:f5078f39-c551-11d3-89b9-0000f81fe221">
		</OBJECT>
	</HEAD>
	<BODY>
		<!-- ���� Header -->
		<kw:header id="Header1" runat="server">
		</kw:header>
		<!-- �ثe�Ҧb��m -->
		<center>
			<table dataFld="items" id="tbItems" style="WIDTH: 739px; HEIGHT: 24px">
				<tr>
					<td style="WIDTH: 100%" align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�X���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							���@�X���� �B�J�T: �ק�X���Ѥ��e</font>
					</td>
				</tr>
			</table>
			<!-- �`�N:
			     1. �U table �̪� dataFld & dataSrc="#DSO0"  �n�� DSO0 �אּ DSO1; 
			     2. �B�U server control ����n�אּ input ����, �B input �n�[ dataFld �ݩ�
			     3. �U�ϰ� (�p�t�ӤΫȤ���...��) �n���[�@�h table, �n���U�Ϫ� dataFld -->
			<!-- Run at Server Form -->
			<form id="cont_main3" method="post" runat="server">
				<!--Table �}�l-->
				<TABLE dataFld="�X���Ѥ��e" id="Header" style="WIDTH: 95%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
					<TBODY>
						<TR>
							<TD colSpan="4">
								<TABLE dataFld="�t�Ӹ��" id="MfrData" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
									<!-- �t�ӤΫȤ��� -->
									<TR bgColor="#214389">
										<td colSpan="4">
											<font color="white">(2) �t�ӤΫȤ���</font>
										</td>
									</TR>
									<!-- �t�Ӹ�� -->
									<TR vAlign="center">
										<TD class="cssTitle" noWrap align="right" width="30%" bgColor="#bfcff0">
											<FONT color="#cc0099">(2)</FONT> ���q�W��/�Ӹ� (�t�Ӳνs)�G
										</TD>
										<TD class="cssData" width="33%">
											<asp:label dataFld="���q�o�����Y" id="lblCompanyName" runat="server"></asp:label>
											&nbsp;(
											<asp:label dataFld="�t�Ӳνs" id="lblMfrNo" runat="server"></asp:label>
											) <INPUT dataFld="�t�Ӳνs" id="hiddenMfrNo" type="hidden" size="1" name="hiddenMfrNo" runat="server">
										</TD>
										<TD class="cssTitle" noWrap align="right" width="10%">
											�ԲӸ�ơG
										</TD>
										<TD class="cssData" width="*">
											<IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>', '_new', 'Height=300, Width=400, Top=100, Left=100, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="�t�ӸԲӸ��" src="../images/edit.gif" width="18" border="0">&nbsp;
											<INPUT dataFld="�t�Ӧa�}" id="hiddenMfrName" type="hidden" size="1" name="hiddenMfrName" runat="server">
											<INPUT dataFld="�t�Ӷl���ϸ�" id="hiddenMfrZipcode" type="hidden" size="1" name="hiddenMfrZipcode" runat="server">
											<INPUT dataFld="�t�Ӧa�}" id="hiddenMfrAddress" type="hidden" size="1" name="hiddenMfrAddress" runat="server">
										</TD>
									</TR>
									<!-- ���q�t�d�H��� -->
									<TR vAlign="center">
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											���q�t�d�H�m�W��¾�١G
										</TD>
										<TD class="cssData">
											<asp:label dataFld="�t�ӭt�d�H�m�W" id="lblMfrRespName" runat="server"></asp:label>
											&nbsp;(
											<asp:label dataFld="�t�ӭt�d�H¾��" id="lblMfrRespJobTitle" runat="server"></asp:label>
											) <INPUT dataFld="�t�ӭt�d�H�m�W" id="hiddenMfrRespName" type="hidden" size="1" name="hiddenMfrRespName" runat="server">
											<INPUT dataFld="�t�ӭt�d�H¾��" id="hiddenMfrRespJobTitle" type="hidden" size="1" name="hiddenMfrRespJobTitle" runat="server">
										</TD>
										<TD class="cssTitle" noWrap align="right">
											���q�q��/�ǯu�G
										</TD>
										<TD class="cssData">
											<asp:label dataFld="�t�ӹq��" id="lblMfrTel" runat="server"></asp:label>
											&nbsp;(Fax:
											<asp:label dataFld="�t�Ӷǯu" id="lblMfrFax" runat="server"></asp:label>
											) <INPUT dataFld="�t�ӹq��" id="hiddenMfrTel" type="hidden" size="1" name="hiddenMfrTel" runat="server">
											<INPUT dataFld="�t�Ӷǯu" id="hiddenMfrFax" type="hidden" size="1" name="hiddenMfrFax" runat="server">
										</TD>
									</TR>
									<!-- �Ȥ��� -->
									<TR>
										<TD colSpan="4">
											<TABLE dataFld="�Ȥ���" id="CustData" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
												<TR vAlign="center">
													<TD class="cssTitle" noWrap align="right" width="28%" bgColor="#bfcff0">
														�Ȥ�m�W (�Ȥ�s��)�G
													</TD>
													<TD class="cssData" width="32%">
														<asp:label dataFld="�Ȥ�m�W" id="lblCustName" runat="server"></asp:label>
														&nbsp;&nbsp;(<asp:label dataFld="�Ȥ�s��" id="lblCustNo" Runat="server" ForeColor="Maroon"></asp:label>
														)&nbsp; <INPUT dataFld="�Ȥ�s��" id="hiddenCustNo" type="hidden" size="1" name="hiddenCustNo" runat="server">
														<INPUT id="hiddenPreXml" type="hidden" size="6" name="hiddenPreXml" runat="server">
													</TD>
													<TD class="cssTitle" noWrap align="right" width="15%">
														�ԲӸ�ơG
													</TD>
													<TD class="cssData" width="*">
														<IMG class="ico" id="imgCustDetail" onclick="javascript:window.open('cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>', '_new', 'Height=430, Width=550, Top=60, Left=100, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="�Ȥ�ԲӸ��" src="../images/edit.gif" width="18" border="0">&nbsp;
														<INPUT id="hiddenCustName" type="hidden" size="1" name="hiddenCustName" runat="server">
													</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<!-- �X���Ѱ򥻸�� -->
						<TR>
							<TD colSpan="4">
								<TABLE dataFld="�X���Ѱ򥻸��" id="ContBasicData" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
									<TR bgColor="#214389">
										<td colSpan="4">
											<font color="#ffffff">�X���Ѱ򥻸��&nbsp;&nbsp;</font>&nbsp;
											<asp:label id="lblfgClosedMessage" runat="server"></asp:label>
										</td>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											<font color="#cc0099">(1)</font> ñ������G
										</TD>
										<TD class="cssData">
											<FONT color="red">*</FONT> <INPUT dataFld="ñ�����" id="tbxSignDate" type="text" maxLength="10" size="9" name="tbxSignDate" runat="server">&nbsp;
											<IMG id="img_signdate" onclick='javascript:pick_date("tbxSignDate");return false;' height="18" alt="�d�ߤ��" src="../images/calendar01.gif" width="18">&nbsp;
											<FONT color="blue">[</FONT><FONT color="red">*</FONT><FONT color="blue">���������]</FONT>
											<INPUT dataFld="ñ�����" id="hiddenSignDate" type="hidden" size="2" name="hiddenSignDate" runat="server">
											<INPUT id="hiddenModDate" type="hidden" size="2" name="hiddenModDate" runat="server">
										</TD>
										<TD class="cssTitle" noWrap align="right">
											�X���s���G
										</TD>
										<TD class="cssData">
											&nbsp;&nbsp;
											<asp:label id="lblContNo" runat="server" ForeColor="Red"></asp:label>
											<INPUT id="hiddenContNo" type="hidden" size="6" name="hiddenContNo" runat="server">&nbsp;
											<INPUT id="hiddenOldContNo" style="WIDTH: 30px" type="hidden" size="6" name="hiddenOldContNo" runat="server">
										</TD>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right">
											�X�����O�G
										</TD>
										<TD class="cssData">
											&nbsp;&nbsp;
											<asp:dropdownlist id="ddlContType" runat="server" Enabled="False">
												<asp:ListItem Value="01" Selected="True">�@��X��</asp:ListItem>
												<asp:ListItem Value="09">���s�X��</asp:ListItem>
											</asp:dropdownlist>
											<INPUT id="hiddenContType" type="hidden" size="2" name="hiddenContType" runat="server">
										</TD>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											���y���O�G
										</TD>
										<TD class="cssData">
											&nbsp;&nbsp; <SELECT dataFld="���y���O�N�X" id="ddlBookCode" name="ddlBookCode" runat="server"></SELECT>&nbsp;
											<INPUT dataFld="���y���X" id="hiddenBkcdProjCost" type="hidden" size="1" name="hiddenBkcdProjCost" runat="server">&nbsp;
											<INPUT dataFld="�p���N��" id="hiddenProjNo" type="hidden" size="1" name="hiddenProjNo" runat="server">&nbsp;
											<INPUT dataFld="��������" id="hiddenCostCtr" type="hidden" size="1" name="hiddenCostCtr" runat="server">
										</TD>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right">
											<font color="#cc0099">(7)</font> �X���_����G
										</TD>
										<TD class="cssData" noWrap>
											<FONT color="red">*</FONT> <INPUT dataFld="�X���_��" id="tbxStartDate" style="WIDTH: 45px" type="text" maxLength="7" size="7" name="tbxStartDate" runat="server">&nbsp;
											<font size="3">~</font> <FONT color="red">*</FONT> <INPUT dataFld="�X������" id="tbxEndDate" style="WIDTH: 45px" type="text" maxLength="7" size="7" name="tbxEndDate" runat="server">
											<FONT face="�s�ө���" color="#c00000">(�w�]��: �@�~)</FONT>
										</TD>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											�ӿ�~�ȭ��G
										</TD>
										<TD class="cssData">
											<FONT color="red">* </FONT><SELECT id="ddlEmpNo" name="ddlEmpNo" runat="server"></SELECT>
											<INPUT dataFld="�ӿ�~�ȭ��u��" id="hiddenEmpNo" style="WIDTH: 45px" type="hidden" size="7" name="hiddenEmpNo" runat="server">
											<INPUT dataFld="�ӿ�~�ȭ��u��" id="hiddenLoginEmpNo" style="WIDTH: 45px" type="hidden" size="7" name="hiddenLoginEmpNo" runat="server">&nbsp; 
											<!--FONT face="�s�ө���" color="#c00000">(�w�]��: �n�J��)</FONT-->
										</TD>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right">
											�@���I�M���O�G
										</TD>
										<TD class="cssData" noWrap>
											&nbsp;&nbsp; <SELECT dataFld="�@���I�M���O" id="ddlfgPayOnce" name="ddlfgPayOnce" runat="server">
												<OPTION value="1">
													�O</OPTION>
												<OPTION value="0" selected>
													�_</OPTION></SELECT>&nbsp;
											<asp:textbox dataFld="�@���I�M���O" id="hiddenfgClosed" runat="server" MaxLength="1" Width="20px" ReadOnly="True" Visible="False"></asp:textbox>
											</FONT>
										</TD>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											&nbsp;
										</TD>
										<TD class="cssData" vAlign="top">
											&nbsp;
										</TD>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right">
											���׵��O�G
										</TD>
										<TD class="cssData" noWrap>
											&nbsp;&nbsp; <SELECT dataFld="���׵��O" id="ddlfgClosed" name="ddlfgClosed" runat="server">
												<OPTION value="1">
													�O</OPTION>
												<OPTION value="0" selected>
													�_</OPTION></SELECT>
										</TD>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											�¦X���s���G
										</TD>
										<TD class="cssData" vAlign="top">
											&nbsp;&nbsp;&nbsp; <INPUT dataFld="�¦X���s��" id="tbxOldContNo" type="text" maxLength="7" size="7" name="tbxOldContNo" runat="server" disabled>
										</TD>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											�̫�ק��G
										</TD>
										<TD class="cssData" vAlign="top">
											&nbsp;&nbsp;&nbsp; <INPUT dataFld="�̫�ק���" id="tbxModDate" style="COLOR: gray" readOnly type="text" maxLength="10" size="10" name="tbxModDate" runat="server">
										</TD>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											�ק�~�ȭ��u���G
										</TD>
										<TD class="cssData" vAlign="top">
											&nbsp;&nbsp;&nbsp; <SELECT id="ddlModEmpNo" name="ddlModEmpNo" runat="server"></SELECT>&nbsp;
											<INPUT dataFld="�ק�~�ȭ��u��" id="hiddenModEmpNo" style="WIDTH: 45px" type="hidden" size="7" name="hiddenModEmpNo" runat="server">&nbsp;
											<FONT face="�s�ө���" color="#c00000">(�w�]��: �n�J��)</FONT>
										</TD>
									</TR>
								</TABLE>
							</TD>
						<!-- �X���ѲӸ` -->
						<TR>
							<TD colSpan="4">
								<TABLE dataFld="�X���ѲӸ`" id="ContDetail" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
									<TR bgColor="#214389">
										<td colSpan="4">
											<font color="white">(9)&nbsp;�X���ѲӸ`</font>
										</td>
									</TR>
									<TR>
										<TD class="cssTitle" vAlign="center" align="middle" colSpan="4">
											<TABLE borderColor="#214389" cellSpacing="1" cellPadding="1" width="90%" border="0">
												<TR vAlign="center" align="left">
													<TD class="cssTitle" noWrap align="right">
														<font color="#cc0099">(9)</font> �`�s�Z���ơG
													</TD>
													<TD class="cssData">
														<FONT color="red">*</FONT> <INPUT dataFld="�`�s�Z����" id="tbxTotalJTime" maxLength="3" size="2" name="tbxTotalJTime" runat="server" onblur="Javascript: checkTotalJTime(this)">
													</TD>
													<TD class="cssTitle" noWrap align="right">
														�`�Z�n���ơG
													</TD>
													<TD class="cssData">
														<FONT color="red">*</FONT> <INPUT dataFld="�`�Z�n����" id="tbxTotalTime" maxLength="3" size="2" name="tbxTotalTime" runat="server" onblur="Javascript: checkTotalTime(this)">
													</TD>
													<TD class="cssTitle" align="right">
														<FONT color="#cc0099">(11)</FONT> �X���`���B�G
													</TD>
													<TD class="cssData">
														<FONT color="red">* </FONT>$ <INPUT dataFld="�X���`���B" id="tbxTotalAmt" maxLength="8" size="5" name="tbxTotalAmt" runat="server" onblur="Javascript: checkTotalAmt(this)">&nbsp;
														<INPUT dataFld="�`�s�Z����" id="hiddenTotalJTime" style="WIDTH: 30px" type="hidden" maxLength="3" size="3" name="hiddenTotalJTime" runat="server">&nbsp;
														<INPUT dataFld="�`�Z�n����" id="hiddenTotalTime" style="WIDTH: 30px" type="hidden" maxLength="3" size="3" name="hiddenTotalTime" runat="server">
													</TD>
												</TR>
												<TR vAlign="center" align="left">
													<TD class="cssTitle" noWrap align="right">
														�w�s�Z���ơG
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; <INPUT dataFld="�w�s�Z����" id="tbxMadeJTime" maxLength="3" size="2" name="tbxMadeJTime" runat="server" onblur="Javascript: checkRestJTime(this)">
													</TD>
													<TD class="cssTitle" noWrap align="right">
														�w�Z�n���ơG
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; <INPUT dataFld="�w�Z�n����" id="tbxPubTime" maxLength="3" size="2" name="tbxPubTime" runat="server" onblur="Javascript: checkRestTime(this)">
													</TD>
													<TD class="cssTitle" align="right">
														�wú���B�G
													</TD>
													<TD class="cssData">
														&nbsp; &nbsp; $ <INPUT dataFld="�wú���B" id="tbxPaidAmt" maxLength="8" size="5" name="tbxPaidAmt" runat="server" onblur="Javascript: checkRestAmt(this)">
													</TD>
												</TR>
												<TR vAlign="center" align="left">
													<TD class="cssTitle" noWrap align="right">
														�Ѿl�s�Z���ơG
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; <INPUT dataFld="�Ѿl�s�Z����" id="tbxRestJTime" maxLength="3" size="2" name="tbxRestJTime" runat="server">
													</TD>
													<TD class="cssTitle" noWrap align="right">
														�Ѿl�Z�n���ơG
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; <INPUT dataFld="�Ѿl�Z�n����" id="tbxRestTime" maxLength="3" size="2" name="tbxRestTime" runat="server">
													</TD>
													<TD class="cssTitle" align="right">
														�Ѿl���B�G
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; $ <INPUT dataFld="�Ѿl���B" id="tbxRestAmt" maxLength="8" size="5" name="tbxRestAmt" runat="server">
													</TD>
												</TR>
												<TR vAlign="center" align="left">
													<TD class="cssTitle" noWrap align="right">
														<font color="#cc0099">(9)</font> ���Z���ơG
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; <INPUT dataFld="���Z����" id="tbxChangeJTime" maxLength="3" size="2" name="tbxChangeJTime" runat="server">
													</TD>
													<TD class="cssTitle" noWrap align="right">
														<FONT color="#cc0099">(9)</FONT> �ذe���ơG
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; <INPUT dataFld="�ذe����" id="tbxFreeTime" maxLength="3" size="2" name="tbxFreeTime" runat="server">
													</TD>
													<TD class="cssTitle" align="right">
														<FONT color="#cc0099">(9)</FONT> �u�f��ơG
													</TD>
													<TD class="cssData">
														<FONT color="red">*&nbsp;&nbsp;&nbsp; </FONT><INPUT dataFld="�u�f���" id="tbxDiscount" maxLength="6" size="4" name="tbxDiscount" runat="server" onblur="Javascript: checkDiscount(this)">
														<FONT face="�s�ө���">��</FONT><FONT face="�s�ө���" color="#c00000">(����, �p 0.xxx)</FONT>
													</TD>
												</TR>
												<TR vAlign="center" align="left">
													<TD class="cssTitle" noWrap align="right">
														�m�⦸�ơG
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; <INPUT dataFld="�m�⦸��" id="tbxColorTime" maxLength="3" size="2" name="tbxColorTime" runat="server">
													</TD>
													<TD class="cssTitle" noWrap align="right">
														�¥զ��ơG
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp; <INPUT dataFld="�¥զ���" id="tbxMenoTime" maxLength="3" size="2" name="tbxMenoTime" runat="server">
													</TD>
													<TD class="cssTitle" align="right">
														�M�⦸�ơG
													</TD>
													<TD class="cssData">
														&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <INPUT dataFld="�M�⦸��" id="tbxGetColorTime" maxLength="3" size="2" name="tbxGetColorTime" runat="server">
													</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<!-- �o���t�Ӹ�� -->
						<TR>
							<TD colSpan="4">
								<TABLE dataFld="�o���t�Ӹ��" id="InvRec" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
									<TR bgColor="#214389">
										<TD colSpan="4">
											<FONT color="white">(4) �o���t�Ӧ���H���</FONT>
										</TD>
									</TR>
									<TR vAlign="center">
										<TD noWrap align="right" width="28%" bgColor="#bfcff0">
											<font color="#cc0099">(4)</font> �o������H�m�W�G
										</TD>
										<TD noWrap width="*" colSpan="3">
											<IMG class="ico" title="�s�W/�ק�o������H" onclick="doGetAllInvRec()" height="18" src="../images/new.gif" border="0">&nbsp;
											<INPUT dataFld="�o������H�m�W" id="hiddenInvRec" type="hidden" size="1" name="hiddenInvRec" runat="server">
											<DIV id="lblInvRec" style="DISPLAY: inline; WIDTH: 100px; COLOR: maroon" ms_positioning="FlowLayout">
											</DIV>
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<!-- ���x����H��� -->
						<TR>
							<TD colSpan="4">
								<TABLE dataFld="���x����H���" id="MazRec" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
									<TR bgColor="#214389">
										<TD colSpan="4">
											<FONT color="white">(4) ���x����H���</FONT>
										</TD>
									</TR>
									<TR vAlign="center">
										<TD noWrap align="right" width="28%" bgColor="#bfcff0">
											<font color="#cc0099">(4)</font> ���x����H�m�W�G
										</TD>
										<TD noWrap width="*" colSpan="3">
											<IMG class="ico" title="�s�W/�ק怜��H" onclick="doGetAllMazRec()" height="18" src="../images/new.gif" border="0">&nbsp;
											<INPUT dataFld="���x����H�m�W" id="hiddenMazRec" type="hidden" size="6" name="hiddenMazRec" runat="server">
											<DIV id="lblMazRec" style="DISPLAY: inline; WIDTH: 100px; COLOR: maroon" ms_positioning="FlowLayout">
											</DIV>
											&nbsp;&nbsp;&nbsp;
											<asp:label id="lblTotalPubCount" runat="server" ForeColor="Maroon"></asp:label>
											&nbsp; <INPUT dataFld="�`���n����" id="hiddenTotalPubCount" style="WIDTH: 30px" type="hidden" size="7" name="hiddenTotalPubCount" runat="server">&nbsp;
											<INPUT dataFld="�`���n����" id="hiddenTotalUnPubCount" style="WIDTH: 30px" type="hidden" size="7" name="hiddenTotalUnPubCount" runat="server">
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<!-- �s�i�p���H��� -->
						<TR>
							<TD colSpan="4">
								<TABLE dataFld="�s�i�p���H���" id="AdContactor" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
									<TR bgColor="#214389">
										<td colSpan="4">
											<font color="white">(6) �s�i�p���H���</font>
										</td>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right">
											<FONT color="#cc0099">(6)</FONT> �s�i�p���H�m�W�G
										</TD>
										<TD class="cssData">
											<FONT color="red">* </FONT><INPUT dataFld="�s�i�p���H�m�W" id="tbxAuName" maxLength="30" size="10" name="tbxAUName" runat="server">
											&nbsp; <FONT face="�s�ө���" color="#c00000">(�w�]�P�Ȥ���!)</FONT>
										</TD>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											&nbsp;
										</TD>
										<TD class="cssData" noWrap>
											&nbsp;
										</TD>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right">
											�q�ܡG
										</TD>
										<TD class="cssData">
											<FONT color="red">* </FONT><INPUT dataFld="�s�i�p���H�q��" id="tbxAUTel" maxLength="30" size="10" name="tbxAUTel" runat="server">
											&nbsp; <FONT face="�s�ө���" color="#c00000">(�w�]�P�Ȥ���!)</FONT>
										</TD>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											�ǯu�G
										</TD>
										<TD class="cssData">
											&nbsp;&nbsp; <INPUT dataFld="�s�i�p���H�ǯu" id="tbxAUFax" maxLength="30" size="10" name="tbxAUFax" runat="server">
											&nbsp; <FONT face="�s�ө���" color="#c00000">(�w�]�P�Ȥ���!)</FONT>
										</TD>
									</TR>
									<TR>
										<TD class="cssTitle" noWrap align="right">
											����G
										</TD>
										<TD class="cssData">
											&nbsp;&nbsp; <INPUT dataFld="�s�i�p���H���" id="tbxAUCell" maxLength="30" size="10" name="tbxAUCell" runat="server">
										</TD>
										<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
											Email�G
										</TD>
										<TD class="cssData">
											&nbsp;&nbsp; <INPUT dataFld="�s�i�p���HEmail" id="tbxAUEmail" maxLength="80" size="20" name="tbxAUEmail" runat="server">
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
					</TBODY>
				</TABLE>
				<!-- �����Z�n��� -->
				<TABLE dataFld="�X���Ѹ����Z�n���" id="xmlAdpubData" style="WIDTH: 98%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
					<TR>
						<TD>
							<TABLE dataFld="�������Ӫ�" id="Table2" style="WIDTH: 100%" dataSrc="#DSO1" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
								<THEAD>
									<TR bgColor="#214389">
										<TD style="WIDTH: 100%" colSpan="11">
											<FONT color="#ffffff">(10~12) �X���Ѹ����Z�n���</FONT>&nbsp; <FONT color="yellow" size="2">(�Y�����Ĥ@���� 
												'�Z�n�~��' ����, �N�����s�W�����ɪ��B�z, �z�i�y��s�W/���@��.)</FONT>
										</TD>
									</TR>
									<TR align="middle" borderColor="#bfcff0" bgColor="#bfcff0">
										<TD noWrap align="middle">
											�\��
										</TD>
										<TD>
											�Ǹ�
										</TD>
										<TD>
											<FONT color="red">* </FONT>�Z�n�~��
											<br>
											(�褸6�X, <FONT face="�s�ө���" color="#c00000">�p 200203</FONT>)
											<br>
											/ <FONT color="red">* </FONT>���y���O <IMG class="ico" title="���y���O�ѦҸ��" onclick="doGetBookp(this)" src="../images/edit.gif" border="0">
										</TD>
										<TD>
											�Z�n
											<br>
											���X
										</TD>
										<TD>
											�T�w
											<br>
											����
											<br>
											���O
											<br>
											<FONT face="�s�ө���" color="#c00000">(0: �_, 1:�O)</FONT>
										</TD>
										<TD>
											�s�i��m
										</TD>
										<TD>
											�s�i�g�T
											<br>
											<FONT face="�s�ө���" color="#c00000">(�P���
												<br>
												= &gt;�b��)</FONT>
										</TD>
										<TD>
											�s�i����
										</TD>
										<TD>
											��Z
											<br>
											���O
											<br>
											<FONT face="�s�ө���" color="#c00000">(0: �_, 1:�O)</FONT>
										</TD>
										<TD>
											�o��
											<br>
											����H
										</TD>
										<TD>
											����
											<br>
											�Ӹ`
										</TD>
									</TR>
								</THEAD>
								<TR align="middle" borderColor="#bfcff0" bgColor="#e2eafc">
									<TD>
										<IMG class="ico" title="�s�W���" style="WIDTH: 16px; HEIGHT: 15px" onclick="doAddNew(this)" src="../images/new.gif" width="16" border="0"><FONT face="�s�ө���">&nbsp;</FONT><IMG class="ico" title="�R�����" onclick="doDelete(this)" height="14" src="../images/cut.gif" width="9" border="0">
									</TD>
									<TD>
										<INPUT dataFld="�Ǹ�" id="tbxPubSeq" readOnly type="text" maxLength="2" size="2" value="1" name="tbxPubSeq">
									</TD>
									<TD>
										<FONT color="red">* </FONT><INPUT dataFld="�Z�n�~��" id="tbxPubDate" type="text" maxLength="6" size="6" name="tbxPubDate" onblur="Javascript:CheckPubDate(this);" onchange="Javascript:CheckPubDate2(this);">
										/ <FONT color="red">* </FONT><INPUT dataFld="���y���O" id="tbxBkpPno" type="text" maxLength="4" size="3" name="tbxBkpPno" onblur="Javascript:CheckBookPNo(this);">
										<IMG class="ico" title="���y���O�ѦҸ��" onclick="doGetBookp(this)" src="../images/edit.gif" border="0">
									</TD>
									<TD>
										<INPUT dataFld="�Z�n���X" id="tbxPageNo" type="text" maxLength="3" size="3" name="tbxPageNo">
									</TD>
									<TD>
										<INPUT dataFld="�T�w�������O" id="tbxfgFixPage" type="text" maxLength="1" size="3" name="tbxfgFixPage" onblur="Javascript:CheckfgFixPage(this);">
									</TD>
									<TD>
										<SELECT dataFld="�s�i��m�N�X" id="ddlColorCode" name="ddlColorCode" runat="server"></SELECT>
									</TD>
									<TD>
										<SELECT dataFld="�s�i�g�T�N�X" id="ddlPageSizeCode" name="ddlPageSizeCode" runat="server"></SELECT>
									</TD>
									<TD>
										<SELECT dataFld="�s�i�����N�X" id="ddlLTypeCode" name="ddlLTypeCode" runat="server"></SELECT>
									</TD>
									<TD>
										<INPUT dataFld="��Z���O" id="" type="text" maxLength="1" size="1" value="0" name="tbxfgGot" onblur="Javascript:CheckfgGot(this);">
									</TD>
									<TD>
										<IMG class="ico" title="�o���t�Ӧ���H�ԲӸ��" onclick="doSelectIMRec(this)" src="../images/edit.gif" border="0">
										<INPUT id="hiddenIMDetail" type="hidden" size="1" name="hiddenIMDetail" runat="server">
										<LABEL id="lblSingleIMRec" style="COLOR: maroon"></LABEL>
									</TD>
									<TD>
										<IMG class="ico" title="�����Ӹ`" onclick="doEditPub(this)" src="../images/edit.gif" border="0">
										<INPUT id="hiddenPubDetail" type="hidden" size="1" name="hiddenPubDetail" runat="server">
									</TD>
								</TR>
							</TABLE>
							<FONT face="�s�ө���">��: <font color="#cc0099">�Ʀr�Хܳ���</font>��ܹ�M���ѭ��Z����r����, �H��K��J���q�l���.</FONT>&nbsp;
							<br>
							<FONT face="�s�ө���">��: �Y�Y���e���� <FONT color="red">* </FONT>�Ÿ�, ��ܸ���O������, ���i�ť�!</FONT>
							<br>
							<!-- hiddenXML �� -->
							<input id="hiddenXML" type="hidden" name="hiddenXML" runat="server">
						</TD>
					</TR>
				</TABLE>
				<!-- Form���s -->
				<DIV align="center">
					<input id="btnSave" onclick="doSubmit()" type="button" value="�x�s�ק�" name="btnSave">&nbsp;&nbsp;
					<input id="btnCancel" onclick='javascritp:window.location.href="http://140.96.18.18/mrlpub/"' type="button" value="�����^����" name="btnCancel">
				</DIV>
			</form>
			<br>
			<!-- �� TEXTAREA �O���ˬd XML ��X�ˬd�� -->
			<!--TEXTAREA id="textarea1" name="textarea1" rows="20" cols="100"--> <!--/TEXTAREA-->
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
		<!-- Javascript -->
		<script language="javascript">
		<!--
		// ���q�ϥ� xmlDoc1 ���N xmlDoc0 (���P�� cont_new3.aspx)
		
		
		// ���w�q Object: DSO1, �]�w async = false
		DSO1.XMLDocument.async = false; 
		
		// �w�q xmlDoc1: ���v�� XML ���
		var xmlDoc1 = DSO1.XMLDocument;
		xmlDoc1.loadXML(document.all("hiddenXML").value);
		//alert(xmlDoc1.xml);
		
		// �w�q xmlDoc1: ���v�� XML ���
		var xmlDoc1 = DSO1.XMLDocument;
		xmlDoc1.loadXML(document.all("hiddenXML").value);
		//alert(xmlDoc1.xml);
		
		// �w�q xmlDoc1 �̪��U XML�`�I���W�٤Ψ䤺�e
		var xmlMain = xmlDoc1.selectSingleNode("/root");
		var xmlHeader = xmlDoc1.selectSingleNode("/root/�X���Ѥ��e");
		
		var xmlMfrData = xmlDoc1.selectSingleNode("/root/�X���Ѥ��e/�t�Ӹ��");
		var xmlCustData = xmlDoc1.selectSingleNode("/root/�X���Ѥ��e/�Ȥ���");
		var xmlContBasicData = xmlDoc1.selectSingleNode("/root/�X���Ѥ��e/�X���Ѱ򥻸��");
		var xmlInvRec = xmlDoc1.selectSingleNode("/root/�X���Ѥ��e/�H�o������H���");
		var xmlContDetail = xmlDoc1.selectSingleNode("/root/�X���Ѥ��e/�X���ѲӸ`");
		var xmlInvRec = xmlDoc1.selectSingleNode("/root/�o���t�Ӹ��");
		var xmlMazRec = xmlDoc1.selectSingleNode("/root/���x����H���");
		//alert(xmlMazRec.xml);
					// �w�]���w ���x����H���q�W��, ���x����H�a�} = ���q�W��, ���q�a�}(�o������H�a�})
			// �`�N: Javascript �̦n��� BODY ����, �H�K���� �U�� alert �|�X�{ error
			// PS. �U�G�檺���G�O�@�˪�
			//alert(document.cont_new3("hiddenMfrName").value);
			//alert(document.all("hiddenMfrNo").value);
			//alert(document.all("hiddenMfrName").value);
			//alert(document.all("hiddenMfrAddress").value);
			//alert(document.all("hiddenMfrZipcode").value);
			//xmlInvRec.childNodes.item(0).selectSingleNode("�o���t�ӧǸ�").text="1";
			//xmlInvRec.childNodes.item(0).selectSingleNode("�t�ΥN�X").text="C2";
			//xmlInvRec.childNodes.item(0).selectSingleNode("�X���ѽs��").text=document.all("hiddenContNo").value;
			//xmlInvRec.childNodes.item(0).selectSingleNode("�o������H�t�Ӳνs").text=document.all("hiddenMfrNo").value;
			//xmlInvRec.childNodes.item(0).selectSingleNode("�o������H�a�}").text=document.all("hiddenMfrAddress").value;
			//xmlInvRec.childNodes.item(0).selectSingleNode("�o������H�l���ϸ�").text=document.all("hiddenMfrZipcode").value;
			//xmlInvRec.childNodes.item(0).selectSingleNode("�o������H�q��").text=document.all("hiddenMfrTel").value;
			//xmlInvRec.childNodes.item(0).selectSingleNode("�o������H�ǯu").text=document.all("hiddenMfrFax").value;
			//xmlInvRec.childNodes.item(0).selectSingleNode("�o������H¾��").text=document.all("hiddenMfrRespJobTitle").value;
			
			//xmlMazRec.childNodes.item(0).selectSingleNode("���x����H�Ǹ�").text="1";
			//xmlMazRec.childNodes.item(0).selectSingleNode("�t�ΥN�X").text="C2";
			//xmlMazRec.childNodes.item(0).selectSingleNode("�X���ѽs��").text=document.all("hiddenContNo").value;
			//xmlMazRec.childNodes.item(0).selectSingleNode("���x����H���q�W��").text=document.all("hiddenMfrName").value;
			//xmlMazRec.childNodes.item(0).selectSingleNode("���x����H�a�}").text=document.all("hiddenMfrAddress").value;
			//xmlMazRec.childNodes.item(0).selectSingleNode("���x����H�l���ϸ�").text=document.all("hiddenMfrZipcode").value;
			//xmlMazRec.childNodes.item(0).selectSingleNode("���x����H�q��").text=document.all("hiddenMfrTel").value;
			//xmlMazRec.childNodes.item(0).selectSingleNode("���x����H�ǯu").text=document.all("hiddenMfrFax").value;
			//xmlMazRec.childNodes.item(0).selectSingleNode("���x����H¾��").text=document.all("hiddenMfrRespJobTitle").value;
		
		var xmlAdContactor = xmlDoc1.selectSingleNode("/root/�X���Ѥ��e/�s�i�p���H���");
			
		var xmlAdpubData = xmlDoc1.selectSingleNode("/root/�X���Ѹ����Z�n���");
		var xmlAdpubItems = xmlDoc1.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�");
		var xmlAdpubItemInvRec = xmlDoc1.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�o���t�Ӧ���H�Ӹ`");
		var xmlAdpubItemDetails = xmlDoc1.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�����Ӹ`");
		// �� windows.alert �覡����ܥX xmlAdpubItems �����e (�Υi�אּ��L�ܼƦW��), �����ˬd��
		//alert("�X���Ѥ��e= " + xmlHeader.xml);
		
		// �w�q xmlDocX, xmlEmptyAdpubData
		var xmlEmptyAdpubData = DSOX.XMLDocument;
		xmlEmptyAdpubData.load("�ťո����Z�n���.xml");

		
		// --- �H�U���s�� coding (�P cont_new3.aspx ���P�B)
		// ���ˬd�O�_����� xmlDoc1 ����� (�Y hiddenXML �����)
		//alert("xmlInvRec= " + xmlInvRec.xml);
		//alert("xmlInvRec2= " + xmlHeader.selectSingleNode("�H�o������H���").xml);
		//alert("xmlHeader�H�o������H�q��= " + xmlHeader.selectSingleNode("�H�o������H���/�H�o������H�q��").xml);
		//alert("xmlInvRec�H�o������H�q��= " + xmlInvRec.selectSingleNode("�H�o������H�q��").xml);
		//alert("xmlContBasicData�@���I�M���O= " + xmlContBasicData.selectSingleNode("�@���I�M���O").xml);
		
		// ���ۮ��y���O�N�X��X "�p���N��, ��������"	
		//var BkcdProjCost = window.document.all("hiddenBkcdProjCost").value;
		//alert("BkcdProjCost= " + BkcdProjCost);
		//var BookCode = window.document.all("ddlBookCode").value;
		//var BookCode = BkcdProjCost.substr(0, 2);
		//alert("BookCode= " + BookCode);
		//var ProjNo = BkcdProjCost.substr(2, 10);
		//alert("ProjNo= " + ProjNo);
		//alert("ProjNo= " + window.document.all("hiddenProjNo").value);
		//var CostCtr = BkcdProjCost.substr(12, 7);
		//alert("CostCtr= " + CostCtr);
		
		
		// ��X�D��X���Ҧ��o���t�Ӧ���H�m�W, �åH "," �Ÿ��j�};
		strbuf1 = "";
		for(i=0; i<xmlInvRec.childNodes.length; i++)
		{
			// �T�{�X���ѽs���� �s�W���s��, �H�K�s�W�J table �ɦ��~
			xmlInvRec.childNodes.item(i).selectSingleNode("�X���ѽs��").text=document.all("hiddenContNo").value;
			//strbuf1 += xmlInvRec.childNodes.item(i).selectSingleNode("�o������H�t�ө��Y").text + "-" + xmlInvRec.childNodes.item(i).selectSingleNode("�o������H�m�W").text + ", ";	//�o������H�t�ө��Y+�o������H�m�W ��
			strbuf1 += xmlInvRec.childNodes.item(i).selectSingleNode("�o������H�m�W").text + ", ";	//�o������H�m�W ��
		}
		//alert("strbuf=" + strbuf);	
		// ��o�X�����G�g�^��e���� 
		document.all("lblInvRec").innerText = strbuf1;
		
		
		// ��X��������@�o������H�m�W
		var idx=xmlAdpubData.childNodes.length;
		var Items = xmlAdpubData.xml;
		strbuf="";
		for(i=0; i<idx; i++){
			Items=xmlAdpubData.childNodes.item(i).selectSingleNode("�o���t�Ӧ���H�Ӹ`");
			//alert("Items(" + i + ")= " + Items.xml);
			//alert("Items.�o������H�m�W(" + i + ")= " + Items.childNodes.item(0).selectSingleNode("�o������H�m�W").text);
			//alert("strbuf= " + strbuf);
			strbuf=Items.childNodes.item(0).selectSingleNode("�o������H�m�W").text;	//<�o������H�m�W>���ĤG��
			// ��o�X�����G�g�^��e���� 
			document.all("lblSingleIMRec").innerText = strbuf;
		}
		//event.srcElement.parentElement.children("lblSingleIMRec").innerText=strbuf;
		
		
		// ��X�D��X���Ҧ����x����H�m�W, �åH "," �Ÿ��j�}; �ç�X ���n���� & ���n���ƪ��[�`
		strbuf2 = "";
		var TotalPubCount = 0;
		var TotalUnPubCount = 0;
		for(i=0; i<xmlMazRec.childNodes.length; i++)
		{
			// �T�{�X���ѽs���� �s�W���s��, �H�K�s�W�J table �ɦ��~
			xmlMazRec.childNodes.item(i).selectSingleNode("�X���ѽs��").text=document.all("hiddenContNo").value;
			strbuf2 += xmlMazRec.childNodes.item(i).selectSingleNode("���x����H�m�W").text + ", ";	//���x����H�m�W ��
			TotalPubCount += parseInt(xmlMazRec.childNodes.item(i).selectSingleNode("���n����").text);	//���n���� ��
			TotalUnPubCount += parseInt(xmlMazRec.childNodes.item(i).selectSingleNode("���n����").text);	//���n���� ��
		}
		//alert("strbuf2=" + strbuf2);
		// ��o�X�����G�g�^��s�W�e���� 
		// �ثe �`���n���� & �`���n���� �u���g��e���W���, �ө|���g�^�J xml �� DB ��!
		document.all("lblTotalPubCount").innerText = "(�`���n����: " + TotalPubCount + " / �`���n����: " + TotalUnPubCount + ")";
		//xmlContBasicData.selectSingleNode("�`���n����").text = String(TotalPubCount);
		//xmlContBasicData.selectSingleNode("�`���n����").text = String(TotalUnPubCount);
		document.all("lblMazRec").innerText = strbuf2;
		-->
		</script>
		<script language="javascript">
		<!--
		// �X���Ѹ����Z�n��ƪ��\����s: doAddNew, doDelete
			// �s�W������ƶ�
			function doAddNew(obj)
			{
				var idx = xmlAdpubData.childNodes.length;
				//alert("idx= " + idx);
				
				// ��� NodeList �䤺�e: �G��@�覡
				//alert(xmlAdpubData.childNodes.item(0).xml);

				//var xx = "";
				//for(var i=0; i<idx; i++)
				//{
					 //xx+= xmlAdpubData.childNodes.item(i).xml;
				//}
				//alert("xmlAdpubData ="+xx);
				
				
				// index �� 0 �}�l, �ҥH item(0); ����ܥX��Ǹ��ΥZ�n���
				//var newNode = xmlAdpubData.childNodes.item(idx-1).cloneNode(true);
				var newNode = xmlEmptyAdpubData.documentElement.cloneNode(true);
				//alert("newNode= " + newNode.xml)
				
				// �Y�ϥΤU�@�� (��ܥ��b�s�W�@��e, ���N�Ǹ��[�@); �h���ΨϥΤU���ĤG��; ���G�氵���ƬO�@�˪�, �ФG��@
				//newNode.selectSingleNode("�Ǹ�").text = idx + 1;
				xmlAdpubData.appendChild(newNode);
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�Ǹ�").text = idx + 1;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�����Ǹ�").text = idx + 1;
				
				// ���B����J�ĤG��������ƪ��w�]��, �Ĥ@�����w�]�ȼg�b Submit() ��
				// ���w cloneNode �̪��w�]��
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�Ȥ�s��").text=window.document.all("hiddenCustNo").value;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�X���ѽs��").text=window.document.all("hiddenContNo").value;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�X�����O�N�X").text=window.document.all("hiddenContType").value;
				
				// ���ۮ��y���O�N�X��X "�p���N��, ��������"
				var BkcdProjCost = window.document.all("ddlBookCode").value;
				window.document.all("hiddenBkcdProjCost").value = BkcdProjCost;
				//alert("BkcdProjCost= " + BkcdProjCost);
				var BookCode = BkcdProjCost.substr(0, 2)
				var ProjNo = BkcdProjCost.substr(2, 10);
				var CostCtr = BkcdProjCost.substr(12, 7);
				xmlAdpubData.childNodes.item(idx).selectSingleNode("���y���X").text=BkcdProjCost;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("���y���O�N�X").text=BookCode;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�p���N��").text=ProjNo;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("��������").text=CostCtr;
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�˫�ק���O").text=0;
				// �N �����̫�ק��� Reformat �h�� "/", �H�K�s�W�J c2_pub �� (�]�ϥ� sp_c2_cont_newSave_pub ����, �����b�s�W�e���T�{��ƥ��T) , �L�k�h���� "/", �ӳy����Ʀ��~
				var PubModDate = window.document.all("hiddenModDate").value;
				PubModDate = PubModDate.substring(0, 4) + PubModDate.substring(5, 7) + PubModDate.substring(8, 10);
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�����̫�ק���").text=PubModDate;
				// �U�@�� coding �P cont_show.aspx ���P (�P cont_new3.aspx)
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�����ק�~�ȭ��u��").text=window.document.all("ddlEmpNo").value;
				
				//xmlAdpubData.childNodes.item(idx).selectSingleNode("�����Ӹ`").text=xmlAdpubData.childNodes.item(idx-1).selectSingleNode("�����Ӹ`").text;
				
				// �ˬd�C�@�檺�X�{���Ǹ��ȬO�_���T
				//alert("idx= " + idx);
				//alert("�Ǹ�= " + xmlAdpubData.childNodes.item(idx).selectSingleNode("�Ǹ�").text);
				//alert("�����Ǹ�= " + xmlAdpubData.childNodes.item(idx).selectSingleNode("�����Ǹ�").text);
				
				//alert(xmlAdpubData.xml);
				
			}

			// �R��������ƶ�
			function doDelete(obj)
			{
				//	var idx=obj.parentElement.parentElement.rowIndex-1;
				var idx = obj.recordNumber-1;
				//alert("idx= " + idx);
				var oldNode = xmlAdpubData.childNodes.item(idx);
				//alert("oldNode= " + oldNode);
								
				if(xmlAdpubData.childNodes.length > 1)
				{
					oldNode.parentNode.removeChild(oldNode);
					// �R�� �Ǹ�
					for(i=0; i<xmlAdpubData.childNodes.length;i++)
					{
						xmlAdpubData.childNodes.item(i).selectSingleNode("�Ǹ�").text=i+1;
						xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ǹ�").text=i+1;
					}
				}
				
			}
		//-->
		</script>
		<script language="javascript">
		<!--
		// cal���s�� coding: ��t�Τ��
		function pick_date(theField)
		{
			var oParam = new Object();
			strFeature = "";
			strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
			var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
			window.document.all(theField).value=vreturn;
			return true;
			
			// �U�q���� run, �] doSubmit() �w�g�J xmlContBasicData.selectSingleNode("ñ�����").text ���
			//if(vreturn)
				//xmlContBasicData.selectSingleNode("ñ�����").text=vreturn;
			//return true;
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// �ˬd �X���_�� ���ȬO�_�X�z
		function checkContSDate(obj)
		{
			var StartDate = document.all("tbxStartDate").value;
			//alert("StartDate= " + StartDate);
			
			// �Y��J���A�� 6�X�~��(�L "/" �Ÿ�), �h�۰��ഫ��榡�� 'xxxx(4�X�~)/xx(2�X��)', �p '2002/05'
			if(StartDate.length==6)  {
				var StartDate = document.all("tbxStartDate").value;
				document.all("tbxStartDate").value=StartDate.substring(0, 4) + "/" + StartDate.substring(4, 6);
				//alert(document.all("tbxStartDate").value);
				
				// �ˬd �X���_�餧�~��O�_�X�z�� : �~(4�X, 1990~2200), ��(01~12)
				var yyyy = StartDate.substring(0, 4);
				var mm = StartDate.substring(4, 6);
				
				// �P�_�~�׬O�_�X�z��
				if(yyyy<=1990 || yyyy>=2200)  {
					alert("�`�N: �X���_�餧�~�� '" + yyyy + "' ���X�z, �d�� 1990~2200, �а��W��!");
					document.all("tbxStartDate").focus();
					return;
				}
				
				// �P�_����O�_�X�z��
				if(mm>12 || mm<=0)  {
					alert("�`�N: �X���_�餧��� '" + mm + "' ���X�z, �а��W��!");
					document.all("tbxStartDate").focus();
					return;
				}
				
				// �P�_�X���_�餧�~��O�_�� �ƭȫ��A
				if(isNaN(yyyy)==true)  {
					alert("�X���ѲӸ`�� '�X���_�餧�~��' ������J�Ʀr���A!");
					document.all("tbxStartDate").focus();
					return;
				}
				if(isNaN(mm)==true)  {
					alert("�X���ѲӸ`�� '�X���_�餧���' ������J�Ʀr���A!");
					document.all("tbxStartDate").focus();
					return;
				}
				
			}
			// �Y��J���A���� 6�X
			else
			{
				// �ˬd �X���_�� �����צX�z��: �Y���� 7, �h���Hĵ�i
				if(StartDate.length!=7)  {
					alert("�ܩ�p, �X���_�骺�ȶ��ŦX 'xxxx(4�X�~)/xx(2�X��)', �p '2002/05'\n �Эץ�!");
					document.all("tbxStartDate").focus();
					return;
				}
				// �Y��J���A�� �з� 7�X
				else
				{
					// �ˬd �X���_�餧�~�� �O�_�X�z�� : �~(4�X, 1990~2200), ��(01~12)
					var yyyy = StartDate.substring(0, 4);
					var mm = StartDate.substring(5, 7);
					
					// �P�_�~�׬O�_�X�z��
					if(yyyy<=1990 || yyyy>=2200)
					{
						alert("�`�N: �X���_�餧�~�� '" + yyyy + "' ���X�z, �d�� 1990~2200, �а��W��!");
						document.all("tbxStartDate").focus();
						return;
					}
					
					// �P�_����O�_�X�z��
					if(mm>12 || mm<=0)
					{
						alert("�`�N: �X���_�餧��� '" + mm + "' ���X�z, �а��W��!");
						document.all("tbxStartDate").focus();
						return;
					}
					
					// �P�_�X���_�餧�~��O�_�� �ƭȫ��A
					if(isNaN(yyyy)==true)  {
						alert("�X���ѲӸ`�� '�X���_�餧�~��' ������J�Ʀr���A!");
						document.all("tbxStartDate").focus();
						return;
					}
					if(isNaN(mm)==true)  {
						alert("�X���ѲӸ`�� '�X���_�餧���' ������J�Ʀr���A!");
						document.all("tbxStartDate").focus();
						return;
					}
					
				}
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// �ˬd �X������ ���ȬO�_�X�z
		function checkContEDate(obj)
		{
			var EndDate = document.all("tbxEndDate").value;
			//alert("EndDate= " + EndDate);

			// �Y��J���A�� 6�X�~��(�L "/" �Ÿ�), �h�۰��ഫ��榡�� 'xxxx(4�X�~)/xx(2�X��)', �p '2002/05'
			if(EndDate.length==6)  {
				var EndDate = document.all("tbxEndDate").value;
				document.all("tbxEndDate").value=EndDate.substring(0, 4) + "/" + EndDate.substring(4, 6);
				//alert(document.all("tbxEndDate").value);
				
				// �ˬd �X�����餧�~��O�_�X�z�� : �~(4�X, 1990~2200), ��(01~12)
				var yyyy = EndDate.substring(0, 4);
				var mm = EndDate.substring(4, 6);
				
				// �P�_�~�׬O�_�X�z��
				if(yyyy<=1990 || yyyy>=2200)  {
					alert("�`�N: �X���_�餧�~�� '" + yyyy + "' ���X�z, �d�� 1990~2200, �а��W��!");
					document.all("tbxEndDate").focus();
					return;
				}
				
				// �P�_����O�_�X�z��
				if(mm>12 || mm<=0)  {
					alert("�`�N: �X�����餧��� '" + mm + "' ���X�z, �а��W��!");
					document.all("tbxEndDate").focus();
					return;
				}
				
				// �P�_�X���_�餧�~��O�_�� �ƭȫ��A
				if(isNaN(yyyy)==true)  {
					alert("�X���ѲӸ`�� '�X�����餧�~��' ������J4�X�Ʀr���A!");
					document.all("tbxEndDate").focus();
					return;
				}
				if(isNaN(mm)==true)  {
					alert("�X���ѲӸ`�� '�X�����餧���' ������J2�X�Ʀr���A!");
					document.all("tbxEndDate").focus();
					return;
				}
				
			}
			// �Y��J���A���� 6�X
			else
			{		
				// �ˬd �X���_�� �����צX�z��: �Y���� 7, �h���Hĵ�i
				if(EndDate.length!=7)  {
					alert("�ܩ�p, �X���_�骺�ȶ��ŦX 'xxxx(4�X�~)/xx(2�X��)', �p '2002/05'\n �Эץ�!");
					document.all("tbxEndDate").focus();
					return;
				}
				// �Y��J���A�� �з� 7�X
				else
				{	
					// �ˬd �X���_�餧�~�� �O�_�X�z�� : �~(4�X, 1990~2200), ��(01~12)
					var yyyy = EndDate.substring(0, 4);
					var mm = EndDate.substring(5, 7);
					
					// �P�_�X���_�餧�~�׬O�_�X�z��
					if(yyyy<=1990 || yyyy>=2200)
					{
						alert("�`�N: �X�����餧�~�� '" + yyyy + "' ���X�z, �d�� 1990~2200, �а��W��!");
						document.all("tbxEndDate").focus();
						return;
					}
					
					// �P�_�X���_�餧����O�_�X�z��
					if(mm>12 || mm<=0)
					{
						alert("�`�N: �X�����餧��� '" + mm + "' ���X�z, �а��W��!");
						document.all("tbxEndDate").focus();
						return;
					}
					
					// �P�_�X���_�餧�~��O�_�� �ƭȫ��A
					if(isNaN(yyyy)==true)  {
						alert("�X���ѲӸ`�� '�X�����餧�~��' ������J4�X�Ʀr���A!");
						document.all("tbxEndDate").focus();
						return;
					}
					if(isNaN(mm)==true)  {
						alert("�X���ѲӸ`�� '�X�����餧���' ������J2�X�Ʀr���A!");
						document.all("tbxEndDate").focus();
						return;
					}
					
				}
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// �w�] �`�s�Z���� = ���Z����
		function checkTotalJTime(obj)
		{
			var TotalJTime = document.all("tbxTotalJTime").value;
			//alert("TotalJTime= " + TotalJTime);
			
			// �ˬd �`�s�Z���� �O�_��J�� �Ʀr���A
			if(isNaN(TotalJTime)==true)  {
				alert("�X���ѲӸ`�� '�`�s�Z����' ������J�Ʀr���A!");
				document.all("tbxTotalJTime").focus();
				return;
			}
			// �Y�O, �h�ˬd��X���A�O�_���T
			else  {
				document.all("tbxTotalJTime").value = TotalJTime;
				document.all("tbxChangeJTime").value = TotalJTime;
				document.all("hiddenTotalJTime").value = TotalJTime;
			}
			
			
			// �P cont_new3.aspx ���P�B : �Y����`�s�Z����, �����n�ܧ� ���Z����, "�Ѿl�s�Z����" �]�n�ܧ�.
			var RestJTime = document.all("tbxRestJTime").value;
			//alert("RestJTime= " + RestJTime);
			
			// �ˬd �Ѿl�s�Z���� �O�_��J�� �Ʀr���A
			if(isNaN(RestJTime)==true)  {
				alert("�X���ѲӸ`�� '�Ѿl�s�Z����' ������J�Ʀr���A!");
				document.all("tbxRestJTime").focus();
				return;
			}
			// �Y�O, �h�ˬd��X���A�O�_���T
			else  {
				// �Ѿl�s�Z���� = �`�s�Z���� - �w�s�Z����
				document.all("tbxRestJTime").value = parseInt(TotalJTime) - parseInt(document.all("tbxMadeJTime").value);
				xmlContDetail.selectSingleNode("�Ѿl�s�Z����").text = document.all("tbxRestJTime").value
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// �� �w�s�Z���� �p�� �Ѿl�s�Z����
		function checkRestJTime(obj)
		{
			var TotalJTime = document.all("tbxTotalJTime").value;
			var MadeJTime = document.all("tbxMadeJTime").value;
			//alert("PaidAmt= " + PaidAmt);
			
			// �ˬd �wú���B �O�_��J�� �Ʀr���A
			if(isNaN(MadeJTime)==true)  {
				alert("�X���ѲӸ`�� '�w�s�Z����' ������J�Ʀr���A!");
				document.all("tbxMadeJTime").focus();
				return;
			}
			// �Y�O, �h�ˬd��X���A�O�_���T
			else  {
				document.all("tbxMadeJTime").value = MadeJTime;
				
				// �ˬd �w�s�Z���� �O�_�W�L �`�s�Z����
				if(parseInt(MadeJTime)>parseInt(TotalJTime))  {
					alert("�w�s�Z���� �W�L �`�s�Z����!  �Эץ�");
					document.all("tbxMadeJTime").focus();
					return;
				}
				else
				{
					// �Ѿl�s�Z���� = �`�s�Z���� - �w�s�Z����
					document.all("tbxRestJTime").value = parseInt(TotalJTime) - parseInt(MadeJTime);
					xmlContDetail.selectSingleNode("�w�s�Z����").text = document.all("tbxMadeJTime").value;
					document.all("hiddenTotalJTime").value = parseInt(TotalJTime);
					xmlContDetail.selectSingleNode("�Ѿl�s�Z����").text = document.all("tbxRestJTime").value;
				}
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// �P�O �`�Z�n���� <= �X���_�����Ƥ� (�Y�C�Ӥ�@��), �p�X���_���� 12�Ӥ�, �h���`�Z�n���Ƥ����W�L 12��
		function checkTotalTime(obj)
		{
			var TotalTime = document.all("tbxTotalTime").value;
			//alert("TotalTime= " + TotalTime);
			
			// �ˬd�O�_��J�� �Ʀr���A
			if(isNaN(TotalTime)==true)  {
				alert("�X���ѲӸ`�� '�`�Z�n����' ������J�Ʀr���A!");
				document.all("tbxTotalTime").focus();
				return;
			}
			// �Y�O�Ʀr���A, �h�ˬd��X�榡�O�_���T
			else
			{
				//document.all("hiddenTotalTime").value = TotalTime;
				
				// ��X �X���_��~�X�����骺����ƥ�, �Y �`�Z�n���� �� Max
				var StartDate = document.all("tbxStartDate").value;
				var EndDate = document.all("tbxEndDate").value;
				//alert("StartDate= " + StartDate);
				//alert("EndDate= " + EndDate);
				// ����X �U�O�� �~�� & ���
				StartDate = StartDate.substring(0, 4) + StartDate.substring(5, 7);
				var StartDateyyyy = StartDate.substring(0, 4);
				var StartDatemm = StartDate.substring(4, 6);
				EndDate = EndDate.substring(0, 4) + EndDate.substring(5, 7);
				var EndDateyyyy = EndDate.substring(0, 4);
				var EndDatemm = EndDate.substring(4, 6);
				var Diffyyyy = parseInt(EndDateyyyy) - parseInt(StartDateyyyy);
				//alert("Diffyyyy= " + Diffyyyy);

				var DiffMonths = 0;			
				// �ˬd�O�_���P�~��
				// �Y �_���� �ۦP�~��, ��������۴�, �p 200201~200211  => 10 �Ӥ�
				if(Diffyyyy==0)
				{
					DiffMonths = parseInt(EndDatemm) - parseInt(StartDatemm);
				}
				// �Y �_���� ���P�~��, �h [����~���O(*12) +������]
				// �p 200205~200312 => ( [(2003-2002)*12 + 04] -05 ) + 01 = 20 �Ӥ�
				else
				{
					//DiffMonths = ((Diffyyyy*12) + parseInt(EndDatemm) ) - parseInt(StartDatemm) + 1
					DiffMonths = ((Diffyyyy*12) + parseInt(EndDatemm) ) - parseInt(StartDatemm) + 1
				}
				//alert("DiffMonths= " + DiffMonths);
				
				// �ˬd �`�Z�n���� �O�_�W�L Max (�X���_���骺����t)
				if(document.all("tbxTotalTime").value>DiffMonths)
				{
					var DiffTime = parseInt(TotalTime) - DiffMonths;
					alert("�X���ѲӸ`�� '�`�Z�n����' �W�L�X���_��(���) " + DiffTime + " ��");
					return;
				}
				
				// �Ѿl�Z�n���� = �`�Z�n���� - �w�Z�n����
				document.all("tbxRestTime").value = parseInt(TotalTime) - parseInt(document.all("tbxPubTime").value);
				xmlContDetail.selectSingleNode("�Ѿl�Z�n����").text = document.all("tbxRestTime").value
				
				
				// �P cont_new3.aspx ���P�B : �Y����`�Z�n����, "�Ѿl�Z�n����" �]�n�ܧ�.
				var RestTime = document.all("tbxRestTime").value;
				//alert("RestTime= " + RestTime);
				
				// �ˬd �Ѿl�Z�n���� �O�_��J�� �Ʀr���A
				if(isNaN(RestTime)==true)  {
					alert("�X���ѲӸ`�� '�Ѿl�Z�n����' ������J�Ʀr���A!");
					document.all("tbxRestTime").focus();
					return;
				}
				// �Y�O, �h�ˬd��X���A�O�_���T
				else  {
					document.all("tbxTotalTime").value = TotalTime;
					document.all("hiddenTotalTime").value = TotalTime;
					
					// �Ѿl�Z�n���� = �`�Z�n���� - �w�Z�n����
					document.all("tbxRestTime").value = parseInt(TotalTime) - parseInt(document.all("tbxPubTime").value);
					xmlContDetail.selectSingleNode("�Ѿl�Z�n����").text = document.all("tbxRestTime").value
				}
				
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// �� �w�Z�n���� �p�� �Ѿl�Z�n����
		function checkRestTime(obj)
		{
			var TotalTime = document.all("tbxTotalTime").value;
			var PubTime = document.all("tbxPubTime").value;
			//alert("PubTime= " + PubTime);
			
			// �ˬd �wú���B �O�_��J�� �Ʀr���A
			if(isNaN(PubTime)==true)  {
				alert("�X���ѲӸ`�� '�w�Z�n����' ������J�Ʀr���A!");
				document.all("tbxPubTime").focus();
				return;
			}
			// �Y�O, �h�ˬd��X���A�O�_���T
			else  {
				document.all("tbxPubTime").value = PubTime;
				
				// �ˬd �wú���B �O�_�W�L �X���`���B
				if(parseInt(PubTime)>parseInt(TotalTime))  {
					alert("�w�Z�n���� �W�L �`�Z�n����!  �Эץ�");
					document.all("tbxPubTime").focus();
					return;
				}
				else
				{
					// �Ѿl�Z�n���� = �`�Z�n���� - �w�Z�n����
					document.all("tbxRestTime").value = parseInt(TotalTime) - parseInt(PubTime);
					xmlContDetail.selectSingleNode("�w�Z�n����").text = document.all("tbxPubTime").value
					xmlContDetail.selectSingleNode("�Ѿl�Z�n����").text = document.all("tbxRestTime").value
				}
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// �� �X���`���B �p�� �wú���B, �Ѿl���B
		function checkTotalAmt(obj)
		{
			var TotalAmt = document.all("tbxTotalAmt").value;
			//alert("TotalAmt= " + TotalAmt);
			
			// �ˬd �X���`���B �O�_��J�� �Ʀr���A
			if(isNaN(TotalAmt)==true)  {
				alert("�X���ѲӸ`�� '�X���`���B' ������J�Ʀr���A!");
				document.all("tbxTotalAmt").focus();
				return;
			}
			// �Y�O, �h�ˬd��X���A�O�_���T
			else  {
				document.all("tbxTotalAmt").value = TotalAmt;
				
				// �Ѿl���B = �X���`���B - �wú���B
				document.all("tbxRestAmt").value = parseInt(TotalAmt) - parseInt(document.all("tbxPaidAmt").value);
				xmlContDetail.selectSingleNode("�Ѿl���B").text = document.all("tbxRestAmt").value
				
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// �� �wú���B �p�� �Ѿl���B
		function checkRestAmt(obj)
		{
			var TotalAmt = document.all("tbxTotalAmt").value;
			var PaidAmt = document.all("tbxPaidAmt").value;
			//alert("PaidAmt= " + PaidAmt);
			
			// �ˬd �wú���B �O�_��J�� �Ʀr���A
			if(isNaN(PaidAmt)==true)  {
				alert("�X���ѲӸ`�� '�wú���B' ������J�Ʀr���A!");
				document.all("tbxPaidAmt").focus();
				return;
			}
			// �Y�O, �h�ˬd��X���A�O�_���T
			else  {
				document.all("tbxPaidAmt").value = PaidAmt;
				
				// �ˬd �wú���B �O�_�W�L �X���`���B
				if(parseInt(PaidAmt)>parseInt(TotalAmt))  {
					alert("�wú���B �W�L �X���`���B!  �Эץ�");
					document.all("tbxPaidAmt").focus();
					return;
				}
				else
				{
					// �Ѿl���B = �X���`���B - �wú���B
					document.all("tbxRestAmt").value = parseInt(TotalAmt) - parseInt(PaidAmt);
					xmlContDetail.selectSingleNode("�wú���B").text = document.all("tbxPaidAmt").value
					xmlContDetail.selectSingleNode("�Ѿl���B").text = document.all("tbxRestAmt").value
				}
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// �Y�u�f��Ƥ������, �Ӭ���ƫ��A, �N����
		function checkDiscount(obj)
		{
			var Discount = document.all("tbxDiscount").value;
			//alert("Discount= " + Discount);
			
			// �ˬd�O�_��J�� �Ʀr���A
			if(isNaN(Discount)==true)  {
				alert("�X���ѲӸ`�� '�u�f���' ������J�Ʀr���A!");
				document.all("tbxDiscount").focus();
				return;
			}
			// �Y�O, �h�ˬd��X���A�O�_���T
			else  {
				//alert("Discount.substring(0, 2)= " + Discount.substring(0, 2));
				if(Discount.substring(0, 2) == "0.")  {
					Discount = Discount;
				}
				else  {
					Discount = "0." + Discount;
				}
				//alert("Discount= " + Discount);
				document.all("tbxDiscount").value = Discount;
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		//�ˬd������J�� "�Z�n�~��" ���ȬO�_���T
		function CheckPubDate(obj)
		{	
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			// �P�_�Z�n�~�몺���׬O�_�� 6�X
			var yyyymm = xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text;
			if(yyyymm.length!=6)
			{
				alert("������ " + (idx+1) + " �� '�Z�n�~��' �����ץ����� 6�X(�褸), �Эץ�!");
				return;
			}
			// �Y�Z�n�~�몺���׬� 6�X (�X�z)
			else
			{
				// �ˬd�O�_��J�� �Ʀr���A
				if(isNaN(yyyymm)==true)
					alert("������ " + (idx+1) + " ���� '�Z�n�~��' ������J�Ʀr���A!");
				
				// �P�_�Z�n�~��O�_�b �X���_���� �d��
				var ContStartDate = window.document.all("tbxStartDate").value;
				ContStartDate = ContStartDate.substring(0, 4) + ContStartDate.substring(5, 7);
				var ContEndDate = window.document.all("tbxEndDate").value;
				ContEndDate = ContEndDate.substring(0, 4) + ContEndDate.substring(5, 7);
				//alert("ContStartDate= " + ContStartDate);
				//alert("ContEndDate= " + ContEndDate);
				if(xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text<ContStartDate || xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text>ContEndDate)
				{
					alert("������ " + (idx+1) + " �� '�Z�n�~��' �����b�X���_���d��, �Эץ�!");
					return;
				}
				
				// �çP�_�褸�Z�n�~��O�_�X�z�� : �~(4�X, 1990~2200), ��(01~12)
				var yyyy = xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text.substring(0, 4);
				var mm = xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text.substring(4, 6);

				// �P�_�褸�Z�n�~�׬O�_�X�z��
				if(yyyy<=1990 || yyyy>=2200)
				{
					alert("�`�N: ������ " + (idx+1) + " �����Z�n�~�뤧�~�� '" + yyyy + "' ���X�z, �d�� 1990~2200, �Ч�!");
					return;
				}
				else
					yyyymm = yyyymm;
				
				// �P�_�褸�Z�n����O�_�X�z��
				if(mm>12 || mm<=0)
				{
					alert("�`�N: ������ " + (idx+1) + " �����Z�n�~�뤧��� '" + mm + "' ���X�z, �Ч�!");
					return;
				}
				else
					yyyymm = yyyymm;			
			// ���� - �Y�Z�n�~�몺���׬� 6�X (�X�z)
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// ���ܦ] '�Z�n�~��' �ܧ�, ������s '���y���O' ���� (�A���@�U)
		function CheckPubDate2(obj)
		{
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			if(xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text != "")
				alert("�z��s�F ������ " + (idx+1) + " ���� '�Z�n�~��' !\n �ЦA���@�U������ " + (idx+1) + " ���� '���y���O' �Ǫ����s�ӧ�s���!!!");
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// �ˬd "���y���O" �@��O�_����J
		function CheckBookPNo(obj)
		{	
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);

			var BookPNo = xmlAdpubData.childNodes.item(idx).selectSingleNode("���y���O").text;
			// �Y���y���O�S����J
			if(BookPNo.length==0)
			{
				//alert("������ " + (idx+1) + " ���� '���y���O' ������!\n �Ы��U�k����s�ӬD��!");
				return;
			}
			else
			{
				// �ˬd�O�_��J�� �Ʀr���A
				if(isNaN(BookPNo)==true)
					alert("������ " + (idx+1) + " ���� '���y���O' ������J�Ʀr���A!");
			}
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// <IMG class="ico" title="���y���O�ѦҸ��" ...> ���s�� coding: �̥Z�n�~����ܨ���y���O
		function doGetBookp(obj)
		{
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			var myObject = new Object();
			myObject.flag=true;
			
			//alert("xmlAdpubItems.xml= " + xmlAdpubItems.xml);
			myObject.xmldata = xmlAdpubItems.xml;
			//myObject.xmldata = xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").xml;
			//alert("myObject.xmldata= " + myObject.xmldata);
			
			// ���w�ǹL�h���ܼ� - ��X ���y���O�N�X & �Z�n�~��, �ӧ�X ���y���O
			var bkcd = document.all("ddlBookCode").value.substring(0, 2);
			var ym = xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text;
			//alert("ym= " + ym);
			myObject.bkcd = document.all("ddlBookCode").value.substring(0, 2);
			myObject.ym = xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text;
			
			// �}�ҵ�����ܮ�, �̫�N�ȶǤJ myObject
			var PageName = "bookp_get.aspx?bkcd=" + bkcd + "&ym=" + ym;
			vreturn=window.showModalDialog(PageName, myObject, "dialogHeight:420px;dialogWidth:350px;dialogLeft:250px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("myObject.result= " + myObject.result);
			
			if(vreturn)  {
				xmlAdpubData.childNodes.item(idx).selectSingleNode("���y���O").text = myObject.result;
				// �ѨM�Y�S��J �Z�n�~���, ������ '���y���O', �ӥZ�n�~�묰�� �����p
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text = myObject.yyyymm;
				
				// �P�W����k�G - �ѨM�Y�S��J �Z�n�~���, ������ '���y���O', �ӥZ�n�~�묰�� �����p
				//if(xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text=="")  {
					//var CurrentDate = new Date();
					//var Currentyyyy = CurrentDate.getFullYear();
					//var Currentmm = CurrentDate.getMonth()+1;
					//if(Currentmm.length!=2)
						//Currentmm = "0" + Currentmm;
					//var Currentym = Currentyyyy + Currentmm;
					//xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text=Currentym;
				//}
				return true;
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		//�ˬd������J�� "�T�w�������O" ���ȬO�_���T
		function CheckfgFixPage(obj)
		{	
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			var fgFixPage = parseInt(xmlAdpubData.childNodes.item(idx).selectSingleNode("�T�w�������O").text);
			if(fgFixPage!=1 && fgFixPage!=0)
			{
				alert("������ " + (idx+1) + " �����T�w�������O���ȿ��~, �Э��s��J!");
				return;
				//window.document.all("tbxfgFixPage").focus();
			}
			
		}
		
		//-->
		</script>
		<script language="javascript">
		<!--
		//�ˬd������J�� "��Z���O" ���ȬO�_���T
		function CheckfgGot(obj)
		{	
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			var fgGot = parseInt(xmlAdpubData.childNodes.item(idx).selectSingleNode("��Z���O").text);
			//alert((idx+1) + ", fgFixPage= " + fgFixPage);
			if(fgGot!=1 && fgGot!=0)
			{
				alert("������ " + (idx+1) + " ������Z���O���ȿ��~, �Э��s��J!");
				return;
				//window.document.all("tbxfgGot").focus();
			}
			
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// ��X�Ҧ��o���t�Ӧ���H���m�W���\����s: doGetAllMazRec()
		function doGetAllInvRec() 
		{
			var myObject = new Object();
			//alert("hiddenInvRec= " + document.all("hiddenInvRec").value);
			
			// �Y hiddenInvRec �L���: �h��ܰT�� "�S�����v���..."
			// �Y hiddenInvRec �����: ��X hiddenInvRec �̪����v���
			if(document.all("hiddenInvRec").value=="")
			{
				myObject.flag=false;
				alert("�S�����v���, �Цۦ��J���");
				
				// �N prexmldata ���v��� ��J MazRecForm.aspx �U��ťճB
				myObject.xmldata = xmlInvRec.xml;
			}
			else
			{
			    myObject.flag=true;
				myObject.prexmldata = document.all("hiddenInvRec").value;
				
				// �N prexmldata ���v��� ��J InvRecForm.aspx �U��ťճB + �H�U���w��� myObject.xxx
				myObject.xmldata = myObject.prexmldata;
			}
			//alert("myObject.prexmldata= " + myObject.prexmldata);
			//alert("myObject.xmldata= " + myObject.xmldata);
			
			// ��X ���q�W��, �H�o���a�}, �H�o���l���ϸ�; �ǵ����x����H��Ƥ����q�W��, �a�}, �l���ϸ� myObject.MfrName, myObject.MfrAddress, myObject.MfrZipcode
			myObject.Syscd="C2";
			myObject.ContNo=document.all("hiddenContNo").value;
			myObject.MfrNo=document.all("hiddenMfrNo").value;
			//alert(myObject.MfrNo);
			myObject.MfrName=document.all("hiddenMfrName").value;
			//alert(myObject.MfrName);
			myObject.MfrAddress=window.document.all("hiddenMfrAddress").value;
			myObject.MfrZipcode=window.document.all("hiddenMfrZipcode").value;
			myObject.MfrTel=window.document.all("hiddenMfrTel").value;
			myObject.MfrFax=window.document.all("hiddenMfrFax").value;
			myObject.CustJobTitle=window.document.all("hiddenMfrRespJobTitle").value;
			
			// �}�ҵ�����ܮ�
			vreturn=window.showModalDialog("InvRecForm.aspx", myObject, "dialogHeight:500px;dialogWidth:830px;center:yes;scroll:yes;status:no;help:no;"); 
			if(vreturn)
			{
				//���N�s�� xmlInvRec ���
				xmlInvRec.parentNode.replaceChild(myObject.result, xmlInvRec);
				xmlInvRec = xmlDoc1.selectSingleNode("/root/�o���t�Ӹ��");
				//alert(myObject.result.xml);
				//alert("xmlInvRec= " + xmlInvRec.xml);
				//alert("�o������H�m�W0= " + xmlInvRec.childNodes.item(0).selectSingleNode("�o������H�m�W").text);
				
				//�۫e��, �p��X�X����� xmlInvRec.childNodes.length
				//alert("xmlInvRec.childNodes.length = " + xmlInvRec.childNodes.length);
				
				// ��X�D��X���Ҧ��o������H�m�W, �åH "," �Ÿ��j�};
				strbuf1 = "";
				for(i=0; i<xmlInvRec.childNodes.length; i++)
				{
					// �T�{�X���ѽs���� �s�W���s��, �H�K�s�W�J table �ɦ��~
					xmlInvRec.childNodes.item(i).selectSingleNode("�X���ѽs��").text=document.all("hiddenContNo").value;
					//strbuf1 += xmlInvRec.childNodes.item(i).selectSingleNode("�o������H�t�ө��Y").text + "-" + xmlInvRec.childNodes.item(i).selectSingleNode("�o������H�m�W").text + ", ";	//�o������H�m�W ��
					strbuf1 += xmlInvRec.childNodes.item(i).selectSingleNode("�o������H�m�W").text + ", ";	//�o������H�m�W ��
				}
				//alert("strbuf=" + strbuf);
				
				// ��o�X�����G�g�^��s�W�e���� 
				document.all("lblInvRec").innerText = strbuf1;
				
				// ��o�X�����G�g�^�� hiddenInvRec ��, �H�K���X���Ѭ��s��(old_contno=0)��, doSelectIMRec() �|�줣����v���
				document.all("hiddenInvRec").value = xmlInvRec.xml;
				//document.all("textarea1").value=xmlInvRec.xml;
			}
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// �󸨪���ƳB�D�X��@�o���t�Ӧ���H���\����s: doSelectIMRec()	
		function doSelectIMRec(obj)
		{
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			var myObject = new Object();
			//alert("hiddenInvRec= " + document.all("hiddenInvRec").value);
			
			var Items=xmlAdpubData.childNodes.item(idx).selectSingleNode("�o���t�Ӧ���H�Ӹ`");
			
			// myObject.prexmldata �O�� InvRecSet.aspx �� #DSO3 �I�s���v��ƥ�;
			// �`�N: �Y�S�������U "�D��o���t�Ӧ���H" ���s, �h���B myObject.prexmldata ����Ʒ|�O�ťժ� xmlInvRec
			if(document.all("hiddenInvRec").value=="")
				myObject.prexmldata=xmlInvRec;
			else
				myObject.prexmldata=document.all("hiddenInvRec").value;
			//alert("myObject.prexmldata= " + myObject.prexmldata);
			
			// myObject.xmldata �O�� InvRecSet.aspx �� #DSO2 �ť�xmlInvRec��;
			myObject.xmldata = xmlAdpubData.childNodes.item(idx).selectSingleNode("�o���t�Ӧ���H�Ӹ`").xml;
			//alert("myObject.xmldata= " + myObject.xmldata);
			
			// ��X �t�ΥN�X, �X���ѽs��; �ǵ��o���t�Ӧ���H��Ƥ��t�ΥN�X, �X���ѽs�� myObject.Syscd, myObject.ContNo
			myObject.Syscd="C2";
			myObject.ContNo=document.all("hiddenContNo").value;
			
			// �}�ҵ�����ܮ�
			vreturn=window.showModalDialog("InvRecSet.aspx", myObject, "dialogHeight:450px;dialogWidth:750px;center:yes;scroll:yes;status:no;help:no;"); 
			if(vreturn)
			{
				Items.parentNode.replaceChild(myObject.result, Items);
				Items=xmlAdpubData.childNodes.item(idx).selectSingleNode("�o���t�Ӧ���H�Ӹ`");
				//alert("Items= " + Items.xml);
				//document.all("textarea1").value=xmlInvRec.xml;
				
				strbuf="";
				for(i=0; i<Items.childNodes.length; i++){
					strbuf+=Items.childNodes.item(i).selectSingleNode("�o������H�m�W").text;	//<�m�W>���ĤG��
				}
				//alert("strbuf= " + strbuf);
				
				// ��o�X�����G�g�^��s�W�e���� 
				event.srcElement.parentElement.children("lblSingleIMRec").innerText=strbuf;
				//document.all("textarea1").value=Items.xml;
			}
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// ��X�Ҧ����x����H���m�W���\����s: doGetAllMazRec()
		function doGetAllMazRec() 
		{
			var myObject = new Object();
			//alert("hiddenMazRec= " + document.all("hiddenMazRec").value);
			
			// �Y hiddenMazRec �L���: �h��ܰT�� "�S�����v���..."
			// �Y hiddenMazRec �����: ��X hiddenMazRec �̪����v���
			if(document.all("hiddenMazRec").value=="")
			{
				myObject.flag=false;
				alert("�S�����v���, �Цۦ��J���");
				
				// �N prexmldata ���v��� ��J MazRecForm.aspx �U��ťճB
				myObject.xmldata = xmlMazRec.xml;
			}
			else
			{
			    myObject.flag=true;
				myObject.prexmldata = document.all("hiddenMazRec").value;
				
				// �N prexmldata ���v��� ��J MazRecForm.aspx �U��ťճB
				myObject.xmldata = myObject.prexmldata;
			}
			//alert("myObject.prexmldata= " + myObject.prexmldata);
			//alert("myObject.xmldata= " + myObject.xmldata);
			
			// ��X ���q�W��, �H�o���a�}, �H�o���l���ϸ�; �ǵ����x����H��Ƥ����q�W��, �a�}, �l���ϸ� myObject.MfrName, myObject.MfrAddress, myObject.MfrZipcode
			myObject.Syscd="C2";
			myObject.ContNo=document.all("hiddenContNo").value;
			myObject.MfrName=document.all("hiddenMfrName").value;
			//alert(myObject.MfrName);
			myObject.MfrAddress=window.document.all("hiddenMfrAddress").value;
			myObject.MfrZipcode=window.document.all("hiddenMfrZipcode").value;
			myObject.MfrTel=window.document.all("hiddenMfrTel").value;
			myObject.MfrFax=window.document.all("hiddenMfrFax").value;
			myObject.CustJobTitle=window.document.all("hiddenMfrRespJobTitle").value;
			
			
			vreturn=window.showModalDialog("MazRecForm.aspx", myObject, "dialogHeight:500px;dialogWidth:830px;center:yes;scroll:yes;status:no;help:no;");
			if(vreturn)
			{
				//���N�s�� xmlMazRec ���
				xmlMazRec.parentNode.replaceChild(myObject.result, xmlMazRec);
				xmlMazRec = xmlDoc1.selectSingleNode("/root/���x����H���");
				//alert(myObject.result.xml);
				//alert("xmlMazRec= " + xmlMazRec.xml);
				//alert("���x����H�m�W0= " + xmlMazRec.childNodes.item(0).selectSingleNode("���x����H�m�W").text);
				
				//�۫e��, �p��X�X����� xmlMazRec.childNodes.length
				//alert("xmlMazRec.childNodes.length = " + xmlMazRec.childNodes.length);
				
				// ��X�D��X���Ҧ����x����H�m�W, �åH "," �Ÿ��j�}; �ç�X ���n���� & ���n���ƪ��[�`
				strbuf2 = "";
				var TotalPubCount = 0;
				var TotalUnPubCount = 0;
				for(i=0; i<xmlMazRec.childNodes.length; i++)
				{
					// �T�{�X���ѽs���� �s�W���s��, �H�K�s�W�J table �ɦ��~
					xmlMazRec.childNodes.item(i).selectSingleNode("�X���ѽs��").text=document.all("hiddenContNo").value;
					strbuf2 += xmlMazRec.childNodes.item(i).selectSingleNode("���x����H�m�W").text + ", ";	//���x����H�m�W ��
					TotalPubCount += parseInt(xmlMazRec.childNodes.item(i).selectSingleNode("���n����").text);	//���n���� ��
					TotalUnPubCount += parseInt(xmlMazRec.childNodes.item(i).selectSingleNode("���n����").text);	//���n���� ��
				}
				// �N �`���n����/�`���n���� �ȼg�J���� hidden �ȸ�, �n��K���᪺�� xml �ȧ��
				document.all("hiddenTotalPubCount").Value = TotalPubCount;
				document.all("hiddenTotalUnPubCount").Value = TotalUnPubCount;
				//alert("strbuf2=" + strbuf2);
				//alert("�`���n���� TotalPubCount=" + TotalPubCount);
				//alert("�`���n���� TotalUnPubCount=" + TotalUnPubCount);
				
				// ��o�X�����G�g�^��s�W�e���� 
				// �ثe �`���n���� & �`���n���� �u���g��e���W���, �ө|���g�^�J xml �� DB ��!
				document.all("lblTotalPubCount").innerText = "(�`���n����: " + TotalPubCount + " / �`���n����: " + TotalUnPubCount + ")";
				xmlContBasicData.selectSingleNode("�`���n����").text = parseInt(TotalPubCount);
				xmlContBasicData.selectSingleNode("�`���n����").text = parseInt(TotalUnPubCount);
				document.all("lblMazRec").innerText = strbuf2;
				
				// ��o�X�����G�g�^�� hiddenInvRec ��, �H�K���X���Ѭ��s��(old_contno=0)��, doSelectIMRec() �|�줣����v���
				document.all("hiddenMazRec").value = xmlMazRec.xml;
				//document.all("textarea1").value=xmlInvRec.xml;
			}
		
		}
		//-->
		</script>
		<script language="javascript">
		<!--
		// �Z�n�������ԲӸ�ƥ\����s: doEditPub()
		function doEditPub(obj)
		{	
			//alert("xmlAdpubItemDetails= " + xmlAdpubItemDetails.xml);		
			
			// ��渹
			var idx = obj.recordNumber-1;
			//alert("idx= " + idx);
			
			// �w�q myObject �������^�ǭ�
			var myObject = new Object();
			myObject.xmldata = xmlAdpubData.childNodes.item(idx).selectSingleNode("�����Ӹ`").xml;
			//alert("myObject.xmldata= " + myObject.xmldata);
			
			
			// ���w�ǹL�h���ܼ�
			// �����ӵ�����(�Ǹ�)�� xml ���
			//alert(xmlAdpubData.childNodes.item(idx).xml);
			
			// �`��������, ��K��X ��Z+�s�Z���`���� �� for loop
			myObject.TotalPubSeq=xmlAdpubData.childNodes.length;
			//alert("myObject.TotalPubSeq= " + myObject.TotalPubSeq);
			//alert(xmlAdpubData.childNodes.item(idx).selectSingleNode("�Ǹ�").text);
			
			// �ǤJ�X���ѲӸ`����� - �`�Z�n����, �`�s�Z����, ���Z����
			myObject.tottm=window.document.all("tbxTotalTime").value;
			myObject.totjtm=window.document.all("tbxTotalJTime").value;
			//alert("myObject.tottm= " + myObject.tottm);
			myObject.chgjtm=window.document.all("tbxChangeJTime").value;
			// �Ѿl���`�s�Z����, ��K�p�� �`�s�Z���Ƥ��Ѿl����
			myObject.hiddenTotalJTime= document.all("hiddenTotalJTime").value;
			//alert("myObject.hiddenTotalJTime= " + myObject.hiddenTotalJTime);
			
			// �ǤJ �t�ӽs�� & �t�Ӳνs, �ӰѦҦC�X�Ӽt�� ���Z�n(�üg�^)���Ҧ��������
			// ������J �½Z���O / ��Z���O ��, �۰ʰʥX �½Z���X / ��Z���X �d�ߵ��G
			myObject.contno= document.all("hiddenContNo").value;
			myObject.mfrno = document.all("hiddenMfrNo").value;
			
			// �ǤJ��L���, �H�b "�����Ӹ`��T" �U����ܨ������� (�ѨM�] showModalDialog ��������, �~��ݫe�����)
			myObject.pubseq=xmlAdpubData.childNodes.item(idx).selectSingleNode("�Ǹ�").text;
			myObject.yyyymm=xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n�~��").text;
			myObject.bkpno=xmlAdpubData.childNodes.item(idx).selectSingleNode("���y���O").text;
			myObject.pgno=xmlAdpubData.childNodes.item(idx).selectSingleNode("�Z�n���X").text;
			myObject.fgfixpage=xmlAdpubData.childNodes.item(idx).selectSingleNode("�T�w�������O").text;
			myObject.clrcd=xmlAdpubData.childNodes.item(idx).selectSingleNode("�s�i��m�N�X").text;
			myObject.pgscd=xmlAdpubData.childNodes.item(idx).selectSingleNode("�s�i�g�T�N�X").text;
			myObject.ltpcd=xmlAdpubData.childNodes.item(idx).selectSingleNode("�s�i�����N�X").text;
			
			//�w�q AdpubItemDetails ���ǹL�h���� �����Ӹ`
			var AdpubItemDetails = xmlAdpubData.childNodes.item(idx).selectSingleNode("�����Ӹ`");
			//alert("AdpubItemDetails.xml= " + AdpubItemDetails.xml);
			
			// �}�ҵ�����ܮ�, �̫�N�ȶǤJ myObject
			vreturn=window.showModalDialog("adpub_detail.aspx", myObject, "dialogHeight:300px;dialogWidth:750px;center:yes;scroll:yes;status:no;help:no;"); 
			//alert("myObject.result.xml= " + myObject.result.xml);
			
			//���N�s�� AdpubItemDetails ���
			AdpubItemDetails.parentNode.replaceChild(myObject.result, AdpubItemDetails);
			AdpubItemDetails = xmlDoc1.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�����Ӹ`");
			
			// ���N '�Ѿl���`�s�Z����' hiddenTotalJTime
			document.all("hiddenTotalJTime").value = myObject.hiddenTotalJTime;
			xmlContDetail.selectSingleNode("�Ѿl�s�Z����").text=myObject.hiddenTotalJTime;
			//alert("myObject.hiddenTotalJTime= " + myObject.hiddenTotalJTime);
			
			// �z�L textarea �����ˬd��X�� XML �O�_���T
			//document.all("textarea1").value=xmlAdpubItemDetails.xml;
			}
		//-->
		</script>
		<script language="javascript">
		<!--
		// ����椧 "�x�s�ק�" ���s: doSubmit()
		function doSubmit()
		{
			// ���q�ϥ� xmlDoc1 ���N xmlDoc0 (���P�� cont_new3.aspx)
			
			
			// �U�q�O�P cont_new3.aspx & cont_show.aspx ���P�B
			// ��s �̫�ק���
			xmlContBasicData.selectSingleNode("�̫�ק���").text=window.document.all("hiddenModDate").value;
			
			// �N �����̫�ק��� PubModDate ���ȥh�� "/", �H�K�s�W�J c2_pub �� (�]�ϥ� sp_c2_cont_newSave_pub ����, �����b�s�W�e���T�{��ƥ��T) , �L�k�h���� "/", �ӳy����Ʀ��~
			var PubModDate = window.document.all("hiddenModDate").value;
			PubModDate = PubModDate.substring(0, 4) + PubModDate.substring(5, 7) + PubModDate.substring(8, 10);
			xmlAdpubItems.selectSingleNode("�����̫�ק���").text=PubModDate;
			xmlAdpubItems.selectSingleNode("�����~�ȭ��u��").text=window.document.all("ddlEmpNo").value;
			xmlAdpubItems.selectSingleNode("�����ק�~�ȭ��u��").text=window.document.all("ddlEmpNo").value;
			
			// ��s �w�Z�n���� (�ھ� =�������`����) => ��k�@
			//xmlContDetail.selectSingleNode("�w�Z�n����").text = parseInt(idx);
			//var RestPubTime = parseInt(document.all("tbxTotalTime").value) - parseInt(idx);
			
			// ��s �w�Z�n���� & �Ѿl�Z�n����
			xmlContDetail.selectSingleNode("�w�Z�n����").text = document.all("tbxPubTime").value;
			var RestPubTime = parseInt(document.all("tbxTotalTime").value) - parseInt(document.all("tbxPubTime").value);
			xmlContDetail.selectSingleNode("�Ѿl�Z�n����").text = RestPubTime;
			//document.all("tbxPubTime").value = parseInt(idx);
			//document.all("tbxRestTime").value = parseInt(document.all("tbxPubTime").value) - parseInt(idx);
			
			
			// ��s �����̫�ק���, �����~�ȭ��u��, �����ק�~�ȭ��u��, �w�s�Z����
			var idx = xmlAdpubData.childNodes.length;
			//alert("idx= " + idx);
			//alert("xmlAdpubData= " + xmlAdpubData.xml);
			var i;
			var MadeJTime = 0;
			for(i=0; i<idx; i++) 
			{
				//var xmlAdpubData = xmlDoc1.selectSingleNode("/root/�X���Ѹ����Z�n���");
				//var xmlAdpubItems = xmlDoc1.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�");
				//var xmlAdpubItemInvRec = xmlDoc1.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�o���t�Ӧ���H�Ӹ`");
				//var xmlAdpubItemDetails = xmlDoc1.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�����Ӹ`");
				
				xmlAdpubData.childNodes.item(i).selectSingleNode("�����̫�ק���").text=PubModDate;
				xmlAdpubData.childNodes.item(i).selectSingleNode("�����~�ȭ��u��").text=window.document.all("ddlEmpNo").value;
				xmlAdpubData.childNodes.item(i).selectSingleNode("�����ק�~�ȭ��u��").text=window.document.all("ddlEmpNo").value;
				
				//alert("�Z�����O�N�X= " + xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/�Z�����O�N�X").xml);
				var drafttp = xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/�Z�����O�N�X").text;
				drafttp = parseInt(drafttp);
				//alert("�Z�����O�N�X= " + drafttp);
				switch(drafttp)
				{
					case 1:
						MadeJTime = parseInt(MadeJTime);
						break;
					case 2:
						MadeJTime = parseInt(MadeJTime) + 1;
						break;
					case 3:
						MadeJTime = parseInt(MadeJTime) + 1;
						break;
				}
			}
			//alert("hiddenTotalJTime=" + document.all("hiddenTotalJTime").value);
			//alert("MadeJTime=" + MadeJTime);
			//alert("�Ѿl�s�Z����=" + (parseInt(document.all("hiddenTotalJTime").value) - parseInt(MadeJTime)));
			xmlContDetail.selectSingleNode("�w�s�Z����").text = parseInt(MadeJTime);
			
			// �Y�������`�s�Z���� MadeJTime �P�X���ѲӸ`���`�s�Z���Ƥ��ŦX��, ����ĵ�i�T��
			if(parseInt(MadeJTime) != parseInt(document.all("tbxMadeJTime").value))
			{
				alert("�������`�s�Z����:" + parseInt(MadeJTime) + " �P �X���ѲӸ`���`�s�Z����:" + parseInt(document.all("tbxMadeJTime").value) + " ���ŦX!");
			}
			xmlContDetail.selectSingleNode("�w�s�Z����").text = parseInt(MadeJTime);
			document.all("tbxMadeJTime").value = parseInt(MadeJTime);
			
			xmlContDetail.selectSingleNode("�Ѿl�s�Z����").text = parseInt(document.all("tbxTotalJTime").value) - parseInt(MadeJTime);
			// �Y �Ѿl�s�Z���� < 0, �h��ȫ��w�� 0
			if((parseInt(document.all("tbxTotalJTime").value) - parseInt(MadeJTime)) > 0)
				xmlContDetail.selectSingleNode("�Ѿl�s�Z����").text = parseInt(document.all("tbxTotalJTime").value) - parseInt(MadeJTime);
			else
				xmlContDetail.selectSingleNode("�Ѿl�s�Z����").text = 0;	
			document.all("tbxRestJTime").value = parseInt(document.all("tbxTotalJTime").value) - parseInt(MadeJTime);
			
			
			// �z�L textarea �����ˬd��X�� XML �O�_���T 
			//document.all("textarea1").value=xmlMain.xml;
			//alert(xmlDoc1.xml);
			
			
			//// ����, ���Ǧr�굹�s�ɵ{�� (cont_mainSave.aspx) �ݬݬO�_�����D
			//// �Y�L, �A�i��� xml ���
			////  �b�o��� xmlDoc1.xml ����ƶǵ��s�ɵ{��
			////var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
			////xmlHTTP.Open("post", "cont_mainSave.aspx", false);
			// ��Ǧr��� cont_newSave.aspx �ݬݬO�_��o��; �Y��o��, �A�� xmlDoc1
			////xmlHTTP.Send("test");
			////document.all("textarea1").value=xmlHTTP.responseText;
			////var xmlHTTP = null;

			// �}�l�ǰe xml ��Ʀܸ�Ʈw���x�s ------------------
			// �b�o��� xmlDoc1.xml ����ƶǵ��s�ɵ{��
			var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
			xmlHTTP.Open("post", "cont_mainSave.aspx", false);
			xmlHTTP.Send(xmlDoc1);
			
			// �ˬd�ÿ�X xmlHTTP ���A�󥻭� textarea1 ��
			////alert(xmlHTTP.responseText);
			//document.all("textarea1").value=xmlHTTP.responseText;
			
			// �Y�x�s���\, �Hĵ�i�������
			if(xmlHTTP.statusText=="OK")
			{
				alert("�ק�X���Ѧ��\");
				window.location.href="/mrlpub/d2/cont_SaveMessage.aspx?str=modify";
				if(window.confirm("�ק�X���Ѧ��\,�n�~��ק�X����?"))
				{
					if(window.document.all("hiddenContType").value=="01")
						window.location.href="cont_main1.aspx?function1=mod&conttp=01";
					else if(window.document.all("hiddenContType").value=="09")
						window.location.href="cont_main1.aspx?function1=mod&conttp=09";
				}
				else
					window.location.href="http://140.96.18.18/mrlpub/";
			}
			
			// �M�� xmlHTTP ��Ƭ���
			var xmlHTTP = null;
		}
		//-->
		</script>
	</BODY>
</HTML>
