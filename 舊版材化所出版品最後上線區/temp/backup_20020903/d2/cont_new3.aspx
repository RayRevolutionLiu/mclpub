<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="cont_new3.aspx.cs" Src="cont_new3.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.cont_new3" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�s�W�X���� �B�J�T</TITLE>
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
			<table dataFld="items" id="tbItems" style="WIDTH: 739px">
				<tr>
					<td style="WIDTH: 100%" align="left">
						<font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�X���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�s�W�X���� �B�J�T: �s�W�X���Ѥ��e</font>
					</td>
				</tr>
			</table>
			<!-- Run at Server Form-->
			<FORM id="cont_new3" name="cont_new3" method="post" runat="server">
				<!--Table �}�l-->
				<!-- �Ъ`�N�U table �̪� dataFld & dataSrc="#DSO0" -->
				<TABLE dataFld="�X���Ѥ��e" dataSrc="#DSO0" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
					<!-- �t�ӤΫȤ��� -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">(2) �t�ӤΫȤ���</font>
						</td>
					</TR>
					<!-- �t�Ӹ�� -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							<FONT color="#cc0099">(2)</FONT> ���q�W��/�Ӹ� (�t�Ӳνs)�G
						</TD>
						<TD class="cssData">
							<asp:label id="lblCompanyName" runat="server"></asp:label>
							&nbsp;(
							<asp:label id="lblMfrNo" runat="server"></asp:label>
							) <INPUT id="hiddenMfrNo" type="hidden" size="1" name="hiddenMfrNo" runat="server">
						</TD>
						<TD class="cssTitle" noWrap align="right">
							�ԲӸ�ơG
						</TD>
						<TD class="cssData">
							<IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>', '_new', 'Height=300, Width=400, Top=100, Left=100, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="�t�ӸԲӸ��" src="../images/edit.gif" width="18" border="0">&nbsp;
							<INPUT id="hiddenMfrName" type="hidden" size="1" name="hiddenMfrName" runat="server">
							<INPUT id="hiddenMfrZipcode" type="hidden" size="1" name="hiddenMfrZipcode" runat="server">
							<INPUT id="hiddenMfrAddress" type="hidden" size="1" name="hiddenMfrAddress" runat="server">
						</TD>
					</TR>
					<!-- ���q�t�d�H��� -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							���q�t�d�H�m�W��¾�١G
						</TD>
						<TD class="cssData">
							<asp:label id="lblMfrRespName" runat="server"></asp:label>
							&nbsp;(
							<asp:label id="lblMfrRespJobTitle" runat="server"></asp:label>
							) <INPUT id="hiddenMfrRespName" type="hidden" size="1" name="hiddenMfrRespName" runat="server">
							<INPUT id="hiddenMfrRespJobTitle" type="hidden" size="1" name="hiddenMfrRespJobTitle" runat="server">
						</TD>
						<TD class="cssTitle" noWrap align="right">
							���q�q��/�ǯu�G
						</TD>
						<TD class="cssData">
							<asp:label id="lblMfrTel" runat="server"></asp:label>
							&nbsp;(Fax:
							<asp:label id="lblMfrFax" runat="server"></asp:label>
							) <INPUT id="hiddenMfrTel" type="hidden" size="1" name="hiddenMfrTel" runat="server">
							<INPUT id="hiddenMfrFax" type="hidden" size="1" name="hiddenMfrFax" runat="server">
						</TD>
					</TR>
					<!-- �Ȥ��� -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							�Ȥ�m�W (�Ȥ�s��)�G
						</TD>
						<TD class="cssData">
							<asp:label id="lblCustName" runat="server"></asp:label>
							&nbsp;&nbsp;(
							<asp:label id="lblCustNo" Runat="server" ForeColor="Maroon"></asp:label>
							)&nbsp; <INPUT id="hiddenCustNo" type="hidden" size="1" name="hiddenCustNo" runat="server">
							<INPUT id="hiddenPreXml" type="hidden" size="6" name="hiddenPreXml" runat="server">
						</TD>
						<TD class="cssTitle" noWrap align="right">
							�ԲӸ�ơG
						</TD>
						<TD class="cssData">
							<IMG class="ico" id="imgCustDetail" onclick="javascript:window.open('cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>', '_new', 'Height=420, Width=550, Top=60, Left=100, toolbar=no, scrollbar=yes, status=no, resizable=no')" alt="�Ȥ�ԲӸ��" src="../images/edit.gif" width="18" border="0">&nbsp;
							<INPUT id="hiddenCustName" type="hidden" size="1" name="hiddenCustName" runat="server">
						</TD>
					</TR>
					<!-- �X���Ѱ򥻸�� -->
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
							<INPUT id="hiddenModDate" type="hidden" size="2" name="hiddenModDate" runat="server">
						</TD>
						<TD class="cssTitle" noWrap align="right">
							�X���s���G
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:label id="lblContNo" runat="server" ForeColor="Red"></asp:label>
							<INPUT id="hiddenContNo" style="WIDTH: 30px" type="hidden" size="6" name="hiddenContNo" runat="server">&nbsp;
							<INPUT id="hiddenOldContNo" style="WIDTH: 30px" type="hidden" size="6" name="hiddenOldContNo" runat="server">
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							�X�����O�G
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:dropdownlist id="ddlContType" runat="server">
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
							<FONT color="red">*</FONT> <INPUT id="tbxStartDate" style="WIDTH: 45px" type="text" maxLength="7" size="6" name="tbxStartDate" runat="server" onblur="Javascript: checkContSDate(this)">&nbsp;
							<font size="3">~</font> <FONT color="red">*</FONT> <INPUT id="tbxEndDate" style="WIDTH: 45px" type="text" maxLength="7" size="6" name="tbxEndDate" runat="server" onblur="Javascript: checkContEDate(this)">
							<FONT face="�s�ө���" color="#c00000">(�w�]��: �@�~)</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							�ӿ�~�ȭ��G
						</TD>
						<TD class="cssData">
							<FONT color="red">* </FONT><SELECT dataFld="�ӿ�~�ȭ��u��" id="ddlEmpNo" name="ddlEmpNo" runat="server"></SELECT>
							<INPUT dataFld="�ӿ�~�ȭ��u��" id="hiddenEmpNo" style="WIDTH: 45px" type="hidden" size="7" name="hiddenEmpNo" runat="server">&nbsp;&nbsp;
							<INPUT dataFld="�n�J�~�ȭ��u��" id="hiddenLoginEmpNo" style="WIDTH: 45px" type="hidden" size="7" name="hiddenLoginEmpNo" runat="server">&nbsp;
							<FONT face="�s�ө���" color="#c00000">(�w�]��: �n�J��)</FONT>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							�@���I�M���O�G
						</TD>
						<TD class="cssData" noWrap>
							&nbsp;&nbsp;
							<asp:dropdownlist id="ddlfgPayOnce" runat="server">
								<asp:ListItem Value="1">�O</asp:ListItem>
								<asp:ListItem Value="0" Selected="True">�_</asp:ListItem>
							</asp:dropdownlist>
							&nbsp;
							<asp:textbox id="hiddenfgClosed" runat="server" MaxLength="1" Width="20px" ReadOnly="True" Visible="False"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							&nbsp;
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;
						</TD>
					</TR>
					<!-- �X���ѲӸ` -->
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
										<FONT color="red">* </FONT><INPUT dataFld="�`�s�Z����" id="tbxTotalJTime" style="WIDTH: 28px" maxLength="3" size="3" name="tbxTotalJTime" runat="server" onblur="Javascript: checkTotalJTime(this)">
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�`�Z�n���ơG&nbsp;
									</TD>
									<TD class="cssData">
										<FONT color="red">* </FONT><INPUT dataFld="�`�Z�n����" id="tbxTotalTime" style="WIDTH: 28px" maxLength="3" size="3" name="tbxTotalTime" runat="server" onblur="Javascript: checkTotalTime(this)">
									</TD>
									<TD class="cssTitle" align="right">
										<FONT color="#cc0099">(11)</FONT> �X���`���B�G&nbsp;
									</TD>
									<TD class="cssData">
										<FONT face="�s�ө���"><FONT color="red">* </FONT>$</FONT>
										<asp:textbox id="tbxTotalAmt" runat="server" MaxLength="8" Width="55px"></asp:textbox>
										&nbsp; <INPUT dataFld="�`�s�Z����" id="hiddenTotalJTime" style="WIDTH: 30px" type="hidden" maxLength="3" size="3" name="hiddenTotalJTime" runat="server">&nbsp;
										<INPUT dataFld="�`�Z�n����" id="hiddenTotalTime" style="WIDTH: 30px" type="hidden" maxLength="3" size="3" name="hiddenTotalTime" runat="server">
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										<font color="#cc0099">(9)</font> ���Z���ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxChangeJTime" runat="server" MaxLength="3" Width="28px"></asp:textbox>
										<FONT face="�s�ө���" color="#c00000">&nbsp;</FONT>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<FONT color="#cc0099">(9)</FONT> �ذe���ơG&nbsp;
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxFreeTime" runat="server" MaxLength="3" Width="28px"></asp:textbox>
									</TD>
									<TD class="cssTitle" align="right">
										<FONT color="#cc0099">(9)</FONT> �u�f��ơG&nbsp;
									</TD>
									<TD class="cssData">
										<FONT color="red">* </FONT>&nbsp;&nbsp; <INPUT dataFld="�u�f���" id="tbxDiscount" style="WIDTH: 40px" maxLength="6" size="4" name="tbxDiscount" runat="server" onblur="Javascript: checkDiscount(this)">
										<FONT face="�s�ө���">��</FONT><FONT face="�s�ө���" color="#c00000">(����, �p 0.xxx)</FONT>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										�m�⦸�ơG
									</TD>
									<TD class="cssData">
										<FONT face="�s�ө���">&nbsp;&nbsp; </FONT>
										<asp:textbox id="tbxColorTime" runat="server" MaxLength="3" Width="28px"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�¥զ��ơG
									</TD>
									<TD class="cssData">
										<FONT face="�s�ө���">&nbsp;&nbsp; </FONT>
										<asp:textbox id="tbxMenoTime" runat="server" MaxLength="3" Width="28px"></asp:textbox>
									</TD>
									<TD class="cssTitle" align="right">
										�M�⦸�ơG
									</TD>
									<TD class="cssData">
										<FONT face="�s�ө���">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:textbox id="tbxGetColorTime" runat="server" MaxLength="3" Width="28px"></asp:textbox>
										</FONT>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<!-- �o���t�Ӹ�� -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<FONT color="#ffffff">(3) �o���t�Ӧ���H���&nbsp;&nbsp; </FONT>
							<asp:label id="lblInvRecMessage" runat="server"></asp:label>
						</td>
					</TR>
					<TR vAlign="center">
						<TD noWrap align="right" bgColor="#bfcff0">
							<font color="#cc0099">(3)</font> �o������H�m�W�G
						</TD>
						<TD noWrap colSpan="3">
							<IMG class="ico" title="�s�W/�ק�o������H" onclick="doGetAllInvRec()" height="18" src="../images/new.gif" border="0">&nbsp;
							<INPUT id="hiddenInvRec" type="hidden" size="1" name="hiddenInvRec" runat="server">
							<DIV id="lblInvRec" style="DISPLAY: inline; WIDTH: 100px; COLOR: maroon" ms_positioning="FlowLayout">
							</DIV>
						</TD>
					</TR>
					<!-- ���x����H��� -->
					<TR bgColor="#214389">
						<TD colSpan="4">
							<FONT color="#ffffff">(4) ���x����H���&nbsp;&nbsp; </FONT>
							<asp:label id="lblMazRecMessage" runat="server"></asp:label>
						</TD>
					</TR>
					<TR vAlign="center">
						<TD noWrap align="right" bgColor="#bfcff0">
							<font color="#cc0099">(4)</font> ���x����H�m�W�G
						</TD>
						<TD noWrap colSpan="3">
							<IMG class="ico" title="�s�W/�ק怜��H" onclick="doGetAllMazRec()" height="18" src="../images/new.gif" border="0">&nbsp;
							<INPUT id="hiddenMazRec" type="hidden" size="1" name="hiddenMazRec" runat="server">
							<DIV id="lblMazRec" style="DISPLAY: inline; WIDTH: 100px; COLOR: maroon" ms_positioning="FlowLayout">
							</DIV>
							&nbsp;&nbsp;&nbsp;
							<asp:label id="lblTotalPubCount" runat="server" ForeColor="Maroon"></asp:label>
							&nbsp; <INPUT dataFld="�`���n����" id="hiddenTotalPubCount" style="WIDTH: 30px" type="hidden" size="7" name="hiddenTotalPubCount" runat="server">&nbsp;
							<INPUT dataFld="�`���n����" id="hiddenTotalUnPubCount" style="WIDTH: 30px" type="hidden" size="7" name="hiddenTotalUnPubCount" runat="server">
						</TD>
					</TR>
					<!-- �s�i�p���H��� -->
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
							<FONT color="red">* </FONT>
							<asp:textbox id="tbxAuName" runat="server" MaxLength="30" Width="65px"></asp:textbox>
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
							<FONT color="red">* </FONT>
							<asp:textbox id="tbxAuTel" runat="server" MaxLength="30" Width="85px"></asp:textbox>
							&nbsp; <FONT face="�s�ө���" color="#c00000">(�w�]�P�Ȥ���!)</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							�ǯu�G
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:textbox id="tbxAuFax" runat="server" MaxLength="30" Width="85px"></asp:textbox>
							&nbsp; <FONT face="�s�ө���" color="#c00000">(�w�]�P�Ȥ���!)</FONT>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							����G
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:textbox id="tbxAuCell" runat="server" MaxLength="30" Width="85px"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							Email�G
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:textbox id="tbxAuEmail" runat="server" MaxLength="80" Width="160px"></asp:textbox>
						</TD>
					</TR>
				</TABLE>
				<!-- �����Z�n��� -->
				<TABLE dataFld="�X���Ѹ����Z�n���" id="Table1" style="WIDTH: 98%" dataSrc="#DSO0" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
					<TR>
						<TD>
							<TABLE dataFld="�������Ӫ�" id="Table2" style="WIDTH: 100%" dataSrc="#DSO0" cellSpacing="0" cellPadding="4" bgColor="#bfcff0" border="0">
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
							<!-- Form���s -->
							<DIV align="center">
								<input id="btnSave" onclick="doSubmit()" type="button" value="�x�s�s�W" name="btnSave">&nbsp;&nbsp;
								<input id="btnCancel" onclick='javascritp:window.location.href="http://140.96.18.18/mrlpub/"' type="button" value="�����^����" name="btnCancel">
							</DIV>
						</TD>
					</TR>
				</TABLE>
			</FORM>
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
		// ���q�ϥ� xmlDoc0 (�ť� XML ���; ���P�� cont_main3.aspx)
		
		// ���w�q Object: DSO0, DSO1, DSOX; �]�w async = false
		DSO0.XMLDocument.async = false;
		DSO1.XMLDocument.async = false; 
		DSOX.XMLDocument.async = false;
		
		// �w�q xmlDoc0
		var xmlDoc0 = DSO0.XMLDocument;
		xmlDoc0.load("�ťզX����.xml");
		//alert(xmlDoc0.xml);
		
		// �w�q xmlDoc0 �̪��U XML�`�I���W�٤Ψ䤺�e
		var xmlMain = xmlDoc0.selectSingleNode("/root");
		var xmlHeader = xmlDoc0.selectSingleNode("/root/�X���Ѥ��e");
		
		var xmlMfrData = xmlDoc0.selectSingleNode("/root/�X���Ѥ��e/�t�Ӹ��");
		var xmlCustData = xmlDoc0.selectSingleNode("/root/�X���Ѥ��e/�Ȥ���");
		var xmlContBasicData = xmlDoc0.selectSingleNode("/root/�X���Ѥ��e/�X���Ѱ򥻸��");
		var xmlContDetail = xmlDoc0.selectSingleNode("/root/�X���Ѥ��e/�X���ѲӸ`");
		var xmlInvRec = xmlDoc0.selectSingleNode("/root/�o���t�Ӹ��");
		var xmlMazRec = xmlDoc0.selectSingleNode("/root/���x����H���");
		//alert(xmlMazRec.xml);
			// �w�]���w ���x����H���q�W��, ���x����H�a�} = ���q�W��, ���q�a�}(�o������H�a�})
			// �`�N: Javascript �̦n��� BODY ����, �H�K���� �U�� alert �|�X�{ error
			// PS. �U�G�檺���G�O�@�˪�
			//alert(document.cont_new3("hiddenMfrName").value);
			//alert(document.all("hiddenMfrNo").value);
			//alert(document.all("hiddenMfrName").value);
			//alert(document.all("hiddenMfrAddress").value);
			//alert(document.all("hiddenMfrZipcode").value);
			xmlInvRec.childNodes.item(0).selectSingleNode("�o���t�ӧǸ�").text="1";
			xmlInvRec.childNodes.item(0).selectSingleNode("�t�ΥN�X").text="C2";
			xmlInvRec.childNodes.item(0).selectSingleNode("�X���ѽs��").text=document.all("hiddenContNo").value;
			xmlInvRec.childNodes.item(0).selectSingleNode("�o������H�t�Ӳνs").text=document.all("hiddenMfrNo").value;
			xmlInvRec.childNodes.item(0).selectSingleNode("�o������H�a�}").text=document.all("hiddenMfrAddress").value;
			xmlInvRec.childNodes.item(0).selectSingleNode("�o������H�l���ϸ�").text=document.all("hiddenMfrZipcode").value;
			xmlInvRec.childNodes.item(0).selectSingleNode("�o������H�q��").text=document.all("hiddenMfrTel").value;
			xmlInvRec.childNodes.item(0).selectSingleNode("�o������H�ǯu").text=document.all("hiddenMfrFax").value;
			xmlInvRec.childNodes.item(0).selectSingleNode("�o������H¾��").text=document.all("hiddenMfrRespJobTitle").value;
			
			xmlMazRec.childNodes.item(0).selectSingleNode("���x����H�Ǹ�").text="1";
			xmlMazRec.childNodes.item(0).selectSingleNode("�t�ΥN�X").text="C2";
			xmlMazRec.childNodes.item(0).selectSingleNode("�X���ѽs��").text=document.all("hiddenContNo").value;
			xmlMazRec.childNodes.item(0).selectSingleNode("���x����H���q�W��").text=document.all("hiddenMfrName").value;
			xmlMazRec.childNodes.item(0).selectSingleNode("���x����H�a�}").text=document.all("hiddenMfrAddress").value;
			xmlMazRec.childNodes.item(0).selectSingleNode("���x����H�l���ϸ�").text=document.all("hiddenMfrZipcode").value;
			xmlMazRec.childNodes.item(0).selectSingleNode("���x����H�q��").text=document.all("hiddenMfrTel").value;
			xmlMazRec.childNodes.item(0).selectSingleNode("���x����H�ǯu").text=document.all("hiddenMfrFax").value;
			xmlMazRec.childNodes.item(0).selectSingleNode("���x����H¾��").text=document.all("hiddenMfrRespJobTitle").value;
		
		var xmlAdContactor = xmlDoc0.selectSingleNode("/root/�X���Ѥ��e/�s�i�p���H���");
		
		var xmlAdpubData = xmlDoc0.selectSingleNode("/root/�X���Ѹ����Z�n���");
		var xmlAdpubItems = xmlDoc0.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�");
		var xmlAdpubItemInvRec = xmlDoc0.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�o���t�Ӧ���H�Ӹ`");
		var xmlAdpubItemDetails = xmlDoc0.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�����Ӹ`");
		// �� windows.alert �覡����ܥX xmlAdpubItems �����e (�Υi�אּ��L�ܼƦW��), �����ˬd��
		//alert(xmlHeader.xml);
	
		// �w�q xmlDoc1, xmlEmptyAdpubData
		var xmlEmptyAdpubData = DSO1.XMLDocument;
		xmlEmptyAdpubData.load("�ťո����Z�n���.xml");

		// �w�q xmlDocX
		var xmlDocX = DSOX.XMLDocument;
		
		// (���P�� cont_main3.aspx)
		
		
		// �Y�ťզX����, �X���Ӹ`�B����������쵹�w�]��
		if(window.document.all("tbxChangeJTime").value=="")  {
			window.document.all("tbxChangeJTime").value="0";  }
		if(window.document.all("tbxFreeTime").value=="")  {
			window.document.all("tbxFreeTime").value="0";  }
		if(window.document.all("tbxColorTime").value=="")  {
			window.document.all("tbxColorTime").value="0";  }
		if(window.document.all("tbxMenoTime").value=="")  {
			window.document.all("tbxMenoTime").value="0";  }
		if(window.document.all("tbxGetColorTime").value=="")  {
			window.document.all("tbxGetColorTime").value="0";  }
		
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
				xmlAdpubData.childNodes.item(idx).selectSingleNode("�����~�ȭ��u��").text=window.document.all("ddlEmpNo").value;
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
			
			// �ˬd�O�_��J�� �Ʀr���A
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
			
			// �ˬd �`�s�Z���� �O�_��J�� �Ʀr���A
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
				xmlInvRec = xmlDoc0.selectSingleNode("/root/�o���t�Ӹ��");
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
				
				// �Y�o���t�Ӧ���H�u���@��, �h���w�����B���o������H���ӤH
				//alert("xmlInvRec.xml= " + xmlInvRec.xml)
				//xmlAdpubItemInvRec = xmlDoc0.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�o���t�Ӧ���H�Ӹ`");
				//if(xmlInvRec.childNodes.length==1)  {
					//alert("�o���t�Ӧ���H�u���@��!");
					// �U�@�椣 work => �]��B xml�[�c���P, �L�k�������N
					//xmlAdpubItemInvRec.xml = xmlInvRec.xml;
				//}
				//alert("xmlInvRec=" + xmlInvRec.xml);
				
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
			
			
			// �}�ҵ�����ܮ�
			vreturn=window.showModalDialog("MazRecForm.aspx", myObject, "dialogHeight:500px;dialogWidth:830px;center:yes;scroll:yes;status:no;help:no;");
			if(vreturn)
			{
				//���N�s�� xmlMazRec ���
				xmlMazRec.parentNode.replaceChild(myObject.result, xmlMazRec);
				xmlMazRec = xmlDoc0.selectSingleNode("/root/���x����H���");
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
				//document.all("textarea1").value=xmlMazRec.xml;
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
			AdpubItemDetails = xmlDoc0.selectSingleNode("/root/�X���Ѹ����Z�n���/�������Ӫ�/�����Ӹ`");
			
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
		// ����椧 "�x�s�s�W" ���s: doSubmit()
		function doSubmit()
		{
			// �ˬd�������O�_�ť�
			if(window.document.all("tbxSignDate").value=="")  {
					alert("ñ��������i�ť�");
					document.all("tbxSignDate").focus();
					return;	}

			if(window.document.all("tbxStartDate").value=="")  {
				alert("�X���_�餣�i�ť�");
				document.all("tbxStartDate").focus();
				return;	}

			if(window.document.all("tbxEndDate").value=="")  {
				alert("�X�����餣�i�ť�");
				document.all("tbxEndDate").focus();
				return;	}

			if(window.document.all("ddlEmpNo").value=="")  {
				alert("�ӿ�~�ȭ��u�����i�ť�");
				document.all("ddlEmpNo").focus();
				return;	}
					
			if(window.document.all("tbxTotalJTime").value=="")  {
				alert("�`�s�Z���Ƥ��i�ť�");
				document.all("tbxTotalJTime").focus();
				return;	}
			
			if(window.document.all("tbxTotalAmt").value=="")  {
				alert("�X���`���B���i�ť�");
				document.all("tbxTotalAmt").focus();
				return;	}

			if(window.document.all("tbxDiscount").value=="0.")  {
				alert("�u�f��Ƥ��i�ť�");
				document.all("tbxDiscount").focus();
				return;	}

			if(window.document.all("tbxAuName").value=="")  {
				alert("�s�i�p���H�m�W���i�ť�");
				document.all("tbxAuName").focus();
				return;	}

			if(window.document.all("tbxAuTel").value=="")  {
				alert("�s�i�p���H�q�ܤ��i�ť�");
				document.all("tbxAuTel").focus();
				return;	}
			
			
			// ���q�ϥ� xmlDoc0 (�ť� XML ���; ���P�� cont_main3.aspx)
			
			
			// xmlMfrData���U XML�`�I���W�٤Ψ䤺�e, �i�ѫe���� coding (Line 33~46)
			// ��p var xmlMfrData = xmlDoc0.selectSingleNode("/root/�X���Ѥ��e/�t�Ӹ��"); (Line 36)
			// xmlMfrData�̪��`�I�W�ٻP window.document �̪�����W�٭n�������T, �_�h�|�� errror

			// �t�ӤΫȤ��ư�
			xmlMfrData.selectSingleNode("�t�Ӳνs").text=window.document.all("hiddenMfrNo").value;
			xmlMfrData.selectSingleNode("���q�o�����Y").text=window.document.all("hiddenMfrName").value;
			xmlMfrData.selectSingleNode("�t�ӭt�d�H�m�W").text=window.document.all("hiddenMfrRespName").value;
			xmlMfrData.selectSingleNode("�t�ӭt�d�H¾��").text=window.document.all("hiddenMfrRespJobTitle").value;
			xmlMfrData.selectSingleNode("�t�ӹq��").text=window.document.all("hiddenMfrTel").value;
			xmlMfrData.selectSingleNode("�t�Ӷǯu").text=window.document.all("hiddenMfrFax").value;
			xmlMfrData.selectSingleNode("�t�Ӷl���ϸ�").text=window.document.all("hiddenMfrZipcode").value;
			xmlMfrData.selectSingleNode("�t�Ӧa�}").text=window.document.all("hiddenMfrAddress").value;
			//alert("hiddenMfrName= " + window.document.all("hiddenMfrName").value);

			xmlCustData.selectSingleNode("�Ȥ�s��").text=window.document.all("hiddenCustNo").value;
			xmlCustData.selectSingleNode("�Ȥ�m�W").text=window.document.all("hiddenCustName").value;
			//alert("hiddenCustName= " + window.document.all("hiddenCustName").value);
			
			
			// �X���Ѱ򥻸�ư�
			xmlContBasicData.selectSingleNode("�X���ѽs��").text=window.document.all("hiddenContNo").value;		
			xmlContBasicData.selectSingleNode("�X�����O�N�X").text=window.document.all("hiddenContType").value;		
				// �� �U�Ԧ���� ���y���O�� DB ��(19�X nostr, �а� .cs sqlDataAdapter3), ��X��p���N���Φ�������
				// �N nostr �s�J hiddenBook ��, �H��K���@�e����X���
				var BkcdProjCost = window.document.all("ddlBookCode").value;
				window.document.all("hiddenBkcdProjCost").value = BkcdProjCost;
				//alert("BkcdProjCost= " + BkcdProjCost);
				var BookCode = BkcdProjCost.substr(0, 2);
				var ProjNo = BkcdProjCost.substr(2, 10);
				var CostCtr = BkcdProjCost.substr(12, 7);
			xmlContBasicData.selectSingleNode("���y���X").text=BkcdProjCost;
			xmlContBasicData.selectSingleNode("���y���O�N�X").text=BookCode;
			xmlContBasicData.selectSingleNode("�p���N��").text=ProjNo;
			xmlContBasicData.selectSingleNode("��������").text=CostCtr;
			xmlContBasicData.selectSingleNode("�ӿ�~�ȭ��u��").text=window.document.all("ddlEmpNo").value;
			xmlContBasicData.selectSingleNode("�ק�~�ȭ��u��").text=window.document.all("ddlEmpNo").value;
			
			// �@���I�M���O, �Y�ϥ� rab �覡, ��������줣���� ==> �ҥH�ثe�H ddl �覡���
			//alert("rabfgPayOnce.value= " + window.document.all("rabfgITRI").value);
			xmlContBasicData.selectSingleNode("�@���I�M���O").text=window.document.all("ddlfgPayOnce").value;
			
			// �|�Ҥ����O, �Y�ϥ� rab �覡, ��������줣���� ==> �ҥH�ثe�H ddl �覡���
			//alert("rabfgITRI.value= " + window.document.all("rabfgITRI").value);
			//xmlContBasicData.selectSingleNode("�|�Ҥ����O").text=window.document.all("ddlfgITRI").value;
			
			// ����쥻�O��t�� / �Ÿ�, �A�N�h��/����(NewstrSignDate) �s�J xml & DB
			// �{����榡�אּ�����x�s�t / �Ÿ������, �H��K���@�e��; ���`�N�x�s�J DB �ɤ��n�h�� / �Ÿ�
			//strSignDate=window.document.all("tbxSignDate").value;
				//var NewstrModDate="";
				//NewstrSignDate = strSignDate.substring(0, 4) + strSignDate.substring(5, 7) + strSignDate.substring(8, 10);
				////alert("NewstrSignDate= " + NewstrSignDate);
			////xmlContBasicData.selectSingleNode("ñ�����").text=strSignDate.split("/");  // ����k�u�O�� "/" �אּ ","
			//xmlContBasicData.selectSingleNode("ñ�����").text=NewstrSignDate;
			xmlContBasicData.selectSingleNode("ñ�����").text=window.document.all("tbxSignDate").value;
			xmlContBasicData.selectSingleNode("�X���_��").text=window.document.all("tbxStartDate").value;
			xmlContBasicData.selectSingleNode("�X������").text=window.document.all("tbxEndDate").value;
			
			
			// �S���X�{�b�e���̪����, �����w�]��
			xmlContBasicData.selectSingleNode("�t�ΥN�X").text="C2";
			xmlContBasicData.selectSingleNode("�̫�ק���").text=window.document.all("hiddenModDate").value;
			xmlContBasicData.selectSingleNode("�¦X���s��").text= window.document.all("hiddenOldContNo").value;
			xmlContBasicData.selectSingleNode("�`���n����").text=document.all("hiddenTotalPubCount").Value;
			xmlContBasicData.selectSingleNode("�`���n����").text= document.all("hiddenTotalUnPubCount").Value;
			
			// �X���ѲӸ`��
			xmlContDetail.selectSingleNode("�`�s�Z����").text=window.document.all("tbxTotalJTime").value;
			xmlContDetail.selectSingleNode("�`�Z�n����").text=window.document.all("tbxTotalTime").value;
			xmlContDetail.selectSingleNode("�X���`���B").text=window.document.all("tbxTotalAmt").value;
			xmlContDetail.selectSingleNode("���Z����").text=window.document.all("tbxChangeJTime").value;
			xmlContDetail.selectSingleNode("�ذe����").text=window.document.all("tbxFreeTime").value;
			xmlContDetail.selectSingleNode("�u�f���").text=window.document.all("tbxDiscount").value;
			xmlContDetail.selectSingleNode("�m�⦸��").text=window.document.all("tbxColorTime").value;
			xmlContDetail.selectSingleNode("�¥զ���").text=window.document.all("tbxMenoTime").value;
			xmlContDetail.selectSingleNode("�M�⦸��").text=window.document.all("tbxGetColorTime").value;
			// �S���X�{�b�e���̪����, �����w�]��
			// �`�N: �w�s�Z���� ���ȼg�b�U�� (�]���S�O�B�z)
			xmlContDetail.selectSingleNode("�Ѿl�s�Z����").text=document.all("hiddenTotalJTime").value;
			var TotalTime = window.document.all("tbxTotalTime").value;
			var PubTime = xmlAdpubData.childNodes.length;
			var RestTime = parseInt(TotalTime) - parseInt(PubTime);
			xmlContDetail.selectSingleNode("�w�Z�n����").text = parseInt(PubTime);
			xmlContDetail.selectSingleNode("�Ѿl�Z�n����").text = parseInt(RestTime);
			xmlContDetail.selectSingleNode("�wú���B").text= "0";
			xmlContDetail.selectSingleNode("�Ѿl���B").text = window.document.all("tbxTotalAmt").value;
			
			// �s�i�p���H��ư�
			xmlAdContactor.selectSingleNode("�s�i�p���H�m�W").text=window.document.all("tbxAuName").value;
			xmlAdContactor.selectSingleNode("�s�i�p���H�q��").text=window.document.all("tbxAuTel").value;
			xmlAdContactor.selectSingleNode("�s�i�p���H�ǯu").text=window.document.all("tbxAuFax").value;
			xmlAdContactor.selectSingleNode("�s�i�p���H���").text=window.document.all("tbxAuCell").value;
			xmlAdContactor.selectSingleNode("�s�i�p���HEmail").text=window.document.all("tbxAuEmail").value;
			
			// �X���Ѹ����Z�n��ư� (�Ĥ@����)
			// ��: �� idx ���� xml ��ƭ�(�Y�ĤG���H�᪺������ƪ��w�]��), �g�b doAddNew() �� 
			xmlAdpubItems.selectSingleNode("�Ȥ�s��").text=window.document.all("hiddenCustNo").value;
			xmlAdpubItems.selectSingleNode("�X���ѽs��").text=window.document.all("hiddenContNo").value;
			xmlAdpubItems.selectSingleNode("�X�����O�N�X").text=window.document.all("hiddenContType").value;
			xmlAdpubItems.selectSingleNode("���y���X").text=BkcdProjCost;
			xmlAdpubItems.selectSingleNode("���y���O�N�X").text=BookCode;
			xmlAdpubItems.selectSingleNode("�p���N��").text=ProjNo;
			xmlAdpubItems.selectSingleNode("��������").text=CostCtr;
			xmlAdpubItems.selectSingleNode("�˫�ק���O").text=0;
			// �N �����̫�ק��� Reformat �h�� "/", �H�K�s�W�J c2_pub �� (�]�ϥ� sp_c2_cont_newSave_pub ����, �����b�s�W�e���T�{��ƥ��T) , �L�k�h���� "/", �ӳy����Ʀ��~
			var PubModDate = window.document.all("hiddenModDate").value;
			PubModDate = PubModDate.substring(0, 4) + PubModDate.substring(5, 7) + PubModDate.substring(8, 10);
			xmlAdpubItems.selectSingleNode("�����̫�ק���").text=PubModDate;
			xmlAdpubItems.selectSingleNode("�����~�ȭ��u��").text=window.document.all("ddlEmpNo").value;
			xmlAdpubItems.selectSingleNode("�����ק�~�ȭ��u��").text=window.document.all("ddlEmpNo").value;
			
			
			// ------------- �H�U�O���P�_, �ˬd��ƬO�_�X�z, �_�h���Hĵ�i --------------------
			// ���ثe������Ʀ��X�� idx
			var idx = xmlAdpubData.childNodes.length;
			//alert("idx= " + idx);
			
			// --------  �H�U��U���������(�a for loop)�̪��Y��, �Ӱ��[�`���p�� ------------------
			// A�q: �p�� �X���ѲӸ`�P�������s�i��m���ƬO�_�ŦX. �������s�i��m�N�X���Ҧ��[�`���� �P �X���Ѫ��`�m�⦸��, �`�¥զ���, �`�M�⦸�� �����.
			var clrtm = 0;
			var memotm = 0;
			var getclrtm = 0;
			var noncolor = 0;
			
			// B�q: �p��X ���Z���� = ����/��Z���� + ����/�s�Z����
			var Chgjtm = 0;
			
			// C�q: �p��X �w�s�Z���� = ��Z���X�����O=1(�O) + �s�Z�s�k=01~04 ���Ҧ��������ƪ��[�`
			var Madejtm = 0;
			
			// D�q: �p��X "��������B" = �C�� "�����s�i���B" ���[�`
			var pubamt=0;
			
			// E�q: �p��X "���Z�O��" = �C�� "���Z���B" ���[�`
			var chgamt=0;
			
			// F�q: �ˬd "�Z�n�~��" �O�_����J
			var yyyymm="";
			//alert("�`����= " + parseInt(xmlAdpubData.childNodes.length));
			
			// G�q: �ˬd "���y���O" �O�_����J
			var bkp="";
			
			var i;
			for(i=0; i<idx; i++) 
			{
				// A�q: �p�� �X���ѲӸ`�P�������s�i��m���ƬO�_�ŦX. 
				// ����X������ �s�i��m�N�X ���Ҧ��[�`����: �����m�⦸��, �����¥զ���, �����M�⦸��
					//alert("�s�i��m�N�X= " + xmlAdpubData.childNodes.item(k).selectSingleNode("�s�i��m�N�X").text);
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("�s�i��m�N�X").text=="01")  {
						//alert("�� " + (i+1) + "��: �z��ܱm��");
						clrtm = clrtm + 1;	}
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("�s�i��m�N�X").text=="02")  {
						//alert("�� " + (i+1) + "��: �z��ܶ¥�");
						memotm = memotm + 1;	}
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("�s�i��m�N�X").text=="03")  {
						//alert("�� " + (i+1) + "��: �z��ܮM��");
						getclrtm = getclrtm + 1;	}
				
				// B�q: �p��X ���Z���� = ����/��Z���� + ����/�s�Z����
				// ����X �Z�����O�N�X�� ��Z �ηs�Z ������(����, ����; �C�����@��)
					// �Y����Z
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/�Z�����O�N�X").text == "3")
						Chgjtm = Chgjtm + 1;
					else
						Chgjtm = Chgjtm;
					
					// �Y���s�Z
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/�Z�����O�N�X").text == "2")
						Chgjtm = Chgjtm + 1;
					else
						Chgjtm = Chgjtm;
				
				// C�q: �p��X �w�s�Z���� = ��Z���X�����O=1(�O) + �s�Z�s�k=01~04 ���Ҧ��������ƪ��[�`
				// ����X ��Z���X�����O=1 �� �s�Z�s�k�N�X=1~4 ������(����, ����; �C�����@��)
					//alert("�� " + i + "�檺�Z�����O�N�X: " + xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/�Z�����O�N�X").text);
					//alert("�� " + i + "�檺��Z���X�����O: " + xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/��Z���X�����O").text);
					// �Y����Z���X��
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/�Z�����O�N�X").text == "3" && xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/��Z���X�����O").text == "1")
						Madejtm = Madejtm + 1;
					else
						Madejtm = Madejtm;
					
					// �Y �s�Z�s�k �� ���s
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/�Z�����O�N�X").text == "2" && xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/�s�Z�s�k�N�X").text == "01")
						Madejtm = Madejtm + 1;
					else
						Madejtm = Madejtm;
					
					// �Y �s�Z�s�k �� �~�s
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/�Z�����O�N�X").text == "2" && xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/�s�Z�s�k�N�X").text == "02")
						Madejtm = Madejtm + 1;
					else
						Madejtm = Madejtm;
					
					// �Y �s�Z�s�k �� �e�s
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/�Z�����O�N�X").text == "2" && xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/�s�Z�s�k�N�X").text == "03")
						Madejtm = Madejtm + 1;
					else
						Madejtm = Madejtm;
					
					// �Y �s�Z�s�k �� �~��
					if(xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/�Z�����O�N�X").text == "2" && xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/�s�Z�s�k�N�X").text == "04")
						Madejtm = Madejtm + 1;
					else
						Madejtm = Madejtm;
				
				// D�q: �p��X "��������B" = �C�� "�����s�i���B" ���[�` 
					pubamt = pubamt + parseInt(xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/�����s�i���B").text);
				
				// E�q: �p��X "���Z�O��" = �C�� "���Z���B" ���[�`
					chgamt = chgamt + parseInt(xmlAdpubData.childNodes.item(i).selectSingleNode("�����Ӹ`/���Z���B").text);
				
				// F�q: �ˬd "�Z�n�~��" �O�_����J
					yyyymm = xmlAdpubData.childNodes.item(i).selectSingleNode("�Z�n�~��").text;
					
					//�Y�����Z�n��Ʀ��h���� - �Y��Z�n�~�묰�ŭ�, �����s�W�� c2_pub �B�z
					if(parseInt(xmlAdpubData.childNodes.length) >=2)
					{
						// �ˬd �Z�n�~�� �O�_���ŭ�
						// �Y���ŭ�, �hĵ�i�� �ä����\�~�򪺰ʧ@(return), ����Ҧ����Z�n�~���J����
						if(xmlAdpubData.childNodes.item(i).selectSingleNode("�Z�n�~��").text == "")  {
							yyyymm = "";
							alert("������ " + (i+1) + " �����Z�n�~��(�褸6�X)������, �Х��ץ�!");
							return;
						}
						// �Y �Z�n�~�� �����ŭ� - �h���ˬd��榡, ���T�h��J xml
						else
						{
							
							// �P�_�Z�n�~�몺���׬O�_�� 6�X
							var yyyymm = xmlAdpubData.childNodes.item(i).selectSingleNode("�Z�n�~��").text;
							if(yyyymm.length!=6)  {
								alert("������ " + (i+1) + " �� '�Z�n�~��' �����ץ����� 6�X(�褸), �Эץ�!");
								return;
								//window.document.all("tbxfgFixPage").focus();
							}
							// �Y�Z�n�~�몺���׬� 6�X (�X�z)
							else
							{
								//** �H�U�P checkPubDate() function **
								
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
								if(xmlAdpubData.childNodes.item(i).selectSingleNode("�Z�n�~��").text<ContStartDate || xmlAdpubData.childNodes.item(i).selectSingleNode("�Z�n�~��").text>ContEndDate)
								{
									alert("������ " + (i+1) + " �� '�Z�n�~��' �����b�X���_���d��, �Эץ�!");
									return;
								}
								
								// �çP�_�褸�Z�n�~��O�_�X�z�� : �~(4�X, 1990~2200), ��(01~12)
								var yyyy = xmlAdpubData.childNodes.item(i).selectSingleNode("�Z�n�~��").text.substring(0, 4);
								var mm = xmlAdpubData.childNodes.item(i).selectSingleNode("�Z�n�~��").text.substring(4, 6);
								
								// �P�_�褸�Z�n�~�׬O�_�X�z��
								if(yyyy<=1990 || yyyy>=2200)  {
									alert("�`�N: ������ " + (i+1) + " �����Z�n�~�뤧�~�� '" + yyyy + "' ���X�z, �d�� 1990~2200, �Ч�!");
									return;
								}
								else
									yyyymm = yyyymm;
								
								// �P�_�褸�Z�n����O�_�X�z��
								if(mm>12 || mm<=0)  {
									alert("�`�N: ������ " + (i+1) + " �����Z�n�~�뤧��� '" + mm + "' ���X�z, �Ч�!");
									return;
								}
								else
									yyyymm = yyyymm;			
							// ���� - �Y�Z�n�~�몺���׬� 6�X (�X�z)
							}

						// ���� �����Z�n��Ʀ��h���� ���P�_�� else
						}
						
						// G�q: �ˬd "���y���O" �O�_����J
						var BookPNo = xmlAdpubData.childNodes.item(i).selectSingleNode("���y���O").text;
						// �Y���y���O�S����J
						if(BookPNo.length==0)  {
							alert("������ " + (i+1) + " ���� '���y���O' ������, �Эץ�!");
							return;
						}
						else  {
							// �ˬd�O�_��J�� �Ʀr���A
							if(isNaN(BookPNo)==true)
								alert("������ " + (i+1) + " ���� '���y���O' ������J�Ʀr���A!");
						}
						
						// H �q: �ˬd�O�_�����U�ӵ��� '�o������H'
						if(document.all("lblSingleIMRec").innerText == "")  {
							alert("�z�S�����U �������� " + (i+1) + " ���� '�o������H�m�W'�Ǫ����s, �Ы��@�U���T�{!");
							return;
						}
						
					}
					
					
					//�Y�����Z�n��ƥu���@���� - �Y��Z�n�~�묰�ŭ�, �����s�W�� c2_pub �B�z
					else
					{
						// �ˬd �Z�n�~�� �O�_���ŭ�
						// �@�����Z�n�~�몺�Y���ŭ�, ����ĵ�i�T��: �����s�W������ƪ��B�z
						if(xmlAdpubData.childNodes.item(i).selectSingleNode("�Z�n�~��").text == "")  {
							yyyymm = "";
							alert("������ " + (i+1) + " ���� '�Z�n�~��' ����, �N�����s�W�����ɪ��B�z!\n �z�i�y��s�W/���@��.\n\n �X�����ɵ���L��Ʒs�W��...�еy��!");
						}
						// �Y �Z�n�~�� �����ŭ� - �h���ˬd��榡, ���T�h��J xml
						else
						{						
							// G�q: �ˬd "���y���O" �O�_����J
							var BookPNo = xmlAdpubData.childNodes.item(i).selectSingleNode("���y���O").text;
							// �Y���y���O�S����J
							if(BookPNo.length==0)  {
								alert("������ " + (i+1) + " ���� '���y���O' ������, �Эץ�!");
								return;
							}
							else  {
								// �ˬd�O�_��J�� �Ʀr���A
								if(isNaN(BookPNo)==true)
									alert("������ " + (i+1) + " ���� '���y���O' ������J�Ʀr���A!");
							}
							
							// H �q: �ˬd�O�_�����U�ӵ��� '�o������H'
							if(document.all("lblSingleIMRec").innerText == "")  {
								alert("�z�S�����U �������� " + (i+1) + " ���� '�o������H�m�W' �Ǫ����s, �Ы��@�U���D��!");
								return;
							}
							
						}

					// ���� �����Z�n��ƥu���@���� ���P�_�� else
					}
					
					// H �q: �ˬd�O�_�����U�ӵ��� '�o������H'
					//if(document.all("lblSingleIMRec").innerText == "")  {
						//alert("�z�S���D�� �������� ���� '�o������H�m�W'�Ǫ����s, �Ы��@�U���T�{!");
						//return;
					//}
			
			// ���� for loop
			}
			// ��X�`���G, �g�J xml �εe���W
			//alert("clrtm= " + clrtm);
			//alert("memotm= " + memotm);
			//alert("getclrtm= " + getclrtm);
			//alert("Chgjtm= " + Chgjtm);
			//alert("Madejtm= " + parseInt(Madejtm));
			//alert("pubamt= " + pubamt);
			//alert("chgamt= " + chgamt);
			//alert("yyyymm= " + yyyymm);
			
			// �`�N: �]�X���ѲӸ`����Ƴ��O�ѷ~�ȭ��ۦ��J, �ҥH������H�U�����G�^�g�ܦX���ѲӸ`�B;
			//       ���Y������������� �P �X���ѲӸ`��������� ����(�p�W�L����), �h�n���Hĵ�i!
			//xmlContDetail.selectSingleNode("���Z����").text = parseInt(Chgjtm);
			//window.document.all("tbxChangeJTime").value = Chgjtm;
			
			// A �q:
			// �Y������ �`�m�⦸��/ �`�¥զ��� / �`�M�⦸�� > �X���Ѥ� �m�⦸��/ �¥զ��� / �M�⦸��, �h���Hĵ�i
			var ContClrtm = window.document.all("tbxColorTime").value;
			var DiffClrtm = clrtm - ContClrtm;
			var ContMemotm = window.document.all("tbxMenoTime").value;
			var DiffMemotm = memotm - ContMemotm;
			var ContGetClrtm = window.document.all("tbxGetColorTime").value;
			var DiffGetClrtm = getclrtm - ContGetClrtm;
			if(parseInt(clrtm) > ContClrtm)  {
				alert("�`�N: �����B�w�W�L�X���Ѥ��m�⦸�ơG" + DiffClrtm + " ��, �Х��ץ�!");	
				return;
				}
			if(parseInt(memotm) > ContMemotm)  {
				alert("�`�N: �����B�w�W�L�X���Ѥ��¥զ��ơG" + DiffMemotm + " ��, �Х��ץ�!");	
				return;
				}
			if(parseInt(getclrtm) > ContGetClrtm)  {
				alert("�`�N: �����B�w�W�L�X���Ѥ��M�⦸�ơG" + DiffGetClrtm + " ��, �Х��ץ�!");	
				return;
				}
			
			// �Y �X���� �� �m�⦸��+�¥զ���+�M�⦸�� > �`�Z�n����, �h���Hĵ�i
			var ContTotalTime = window.document.all("tbxTotalTime").value; 
			var ContFreeTime = window.document.all("tbxFreeTime").value;
			ContTotalTime = parseInt(ContTotalTime) + parseInt(ContFreeTime);
			//alert("ContTotalTime= " + ContTotalTime);
			var ContTotalColorTime = parseInt(ContClrtm) + parseInt(ContMemotm) + parseInt(ContGetClrtm);
			//alert("ContTotalColorTime= " + ContTotalColorTime);
			var DiffContTime1 = parseInt(ContTotalColorTime) - parseInt(ContTotalTime);
			if(ContTotalColorTime>ContTotalTime)  {
				alert("�`�N: �X���ѲӸ`�� �m��+�¥�+�M�⦸�� �W�L �`�Z�n���� " + DiffContTime1 + " ��!");
				return;
			}
			
			
			// �Y�������`�s�i��m����(�m�⦸��+�¥զ���+�M�⦸��) �W�L�X���ѲӸ`�� �`�Z�n���� or �`�s�i��m���� �� ���Hĵ�i		
			var PubColorTime = clrtm + memotm + getclrtm;
			//alert("PubColorTime= " + PubColorTime);
			var DiffPubNonColor1 = noncolor - ContTotalTime;
			var DiffPubNonColor2 = noncolor - ContTotalColorTime;
			if(noncolor > ContTotalTime)  {
				alert("�`�N: ������ '�`�s�i��m����' �W�L�X���ѲӸ`�� '�`�Z�n����' " + DiffPubNonColor1 + " ��!");
				return;
			}
			if(noncolor > ContTotalColorTime)  {
				alert("�`�N: ������ '�`�s�i��m����' �W�L�X���ѲӸ`�� '�`�s�i��m����' " + DiffPubNonColor2 + " ��!");
				return;
			}
			
			//// �Y ���� �� �`�m�⦸��+�`�¥զ���+�`�M�⦸�� > �`�Z�n����, �h���Hĵ�i
			//var PubTotalColorTime = parseInt(clrtm) + parseInt(memotm) + parseInt(getclrtm);
			////alert("PubTotalColorTime= " + PubTotalColorTime);
			//var DiffContTime2 = parseInt(PubTotalColorTime) - parseInt(ContTotalTime);
			//if(PubTotalColorTime>ContTotalTime)  {
				//alert("�`�N: �����B �m��+�¥�+�M�⦸�� �W�L �`�Z�n���� " + DiffContTime2 + " ��!");
				//return;
			//}
			
			
			// B �q:	
			// �Y ��Z+�s�Z������(�C���������@��) > ���Z����, �h���Hĵ�i�T��
			var ContChgjtm = window.document.all("tbxChangeJTime").value;
			var DiffChgjtm = Chgjtm - ContChgjtm;
			if(parseInt(Chgjtm) > ContChgjtm)  {
				alert("�`�N: �����B �w�W�L�X���Ӹ`�����Z���ơG" + DiffChgjtm + " ��, �нT�{�O�_�n�����Z�O��!");  
				return; }
			
			// C �q:
			// �Y�`�s�Z���� > �w�s�Z����, �h���Hĵ�i�T��
			var ContTotjtm = window.document.all("tbxTotalJTime").value;
			var Diffjtm = Madejtm - ContTotjtm;
			if(parseInt(Madejtm) > ContTotjtm)  {
				alert("�`�N: �����B �w�W�L�X���Ӹ`���`�s�Z���ơG" + Diffjtm + " ��, �нT�{�O�_�n�����Z�O��!");  
				return; }
			// �X���ѲӸ`�� �w�s�Z���� �b���e�����S�����, �O�������, �n��X���, �H�Ѧb���@�e�������.
			xmlContDetail.selectSingleNode("�w�s�Z����").text = parseInt(Madejtm);
			
			// D �q:
			// ���w�Ĥ@��������Ƥ����Z�O�� (idx=1, item(0)) �� XML ��Ƭ� chgamt
			xmlAdpubItems.selectSingleNode("��������B").text=parseInt(pubamt);
			// ���w�� N ��������Ƥ����Z�O�� (idx=2..., item(idx-1)) �� XML ��Ƭ� chgamt
			for(m=1; m<=idx-1; m++) {
				xmlAdpubData.childNodes.item(m).selectSingleNode("��������B").text=parseInt(pubamt);
			}		
			
			// E �q:
			// ���w�Ĥ@��������Ƥ����Z�O�� (idx=1, item(0)) �� XML ��Ƭ� chgamt
			xmlAdpubItems.selectSingleNode("���Z�O��").text=parseInt(chgamt);
			// ���w�� N ��������Ƥ����Z�O�� (idx=2..., item(idx-1)) �� XML ��Ƭ� chgamt
			for(n=1; n<=idx-1; n++) {
				xmlAdpubData.childNodes.item(n).selectSingleNode("���Z�O��").text=parseInt(chgamt);
			}
			// �Y���w idx = 1, 2, 3, ...N ��, item(0), item(1), item(2), ..., item(idx-1) ���ȳ��n�@�ˬۦP.
			//xmlAdpubData.childNodes.item(idx-1).selectSingleNode("���Z�O��").text=parseInt(chgamt);
			//alert(xmlAdpubData.xml);
			
			//----
			// �Y "�������`�O�� (pubamt+chgamt)" �W�L�X���ѲӸ`�� "�X���`���B", �h���Hĵ�i
			var ContTotalAmt = window.document.all("tbxTotalAmt").value;
			var PubTotalAmt = parseInt(pubamt) + parseInt(chgamt);
			var DiffAmt = parseInt(PubTotalAmt) - parseInt(ContTotalAmt);
			if(PubTotalAmt>ContTotalAmt)  {
				alert("�������`���B (�����s�i���B+���Z���B) �W�L�X���ѲӸ`�� '�X���`���B' $ " + DiffAmt + ",\n �Эץ�!");
				return;
			}
			
			// �P�_�O�_�����U '�o���t�Ӧ���H�m�W'�Ǫ����s, �_�h���Hĵ�i
			if(document.all("lblInvRec").innerText == "")  {
				alert("�z�S�����U '�o���t�Ӧ���H�m�W' �Ǫ����s, �Ы��@�U���T�{!");
				return;
			}
			
			// �P�_�O�_�����U '���x����H�m�W'�Ǫ����s, �_�h���Hĵ�i
			if(document.all("lblTotalPubCount").innerText == "")  {
				alert("�z�S�����U '���x����H�m�W' �Ǫ����s, �Ы��@�U���T�{!");
				return;
			}
			
			// �P�_�O�_�����U '���x����H�m�W'�Ǫ����s, �_�h���Hĵ�i
			// �g�b�W�� for loop -  H �q�� 
			
			
			// �Y�������`���� > �`�Z�n����, �h����ĵ�i�T��, �B�����H�~��s�W
			//alert("idx= " + idx);
			var tottm = window.document.all("tbxTotalTime").value;
			var freetm = window.document.all("tbxFreeTime").value;
			var TotalContPubTime = tottm + freetm;
			//alert(TotalContPubTime);
			if (idx > tottm)  {
				alert("�`�N: ���i�X�����`�Z�n���Ƥw��, �ЦҼ{�Añ�q�X��.  (�νнT�{�`�Z�n����!)");
				alert("��Ʃ|���s�W!!!!!!");
				return; }
			else
			{
				// �z�L textarea �����ˬd��X�� XML �O�_���T 
				//document.all("textarea1").value=xmlMain.xml;
				////alert(xmlDoc0.xml);
				
				
				//// ����, ���Ǧr�굹�s�ɵ{�� (cont_newSave.aspx) �ݬݬO�_�����D
				//// �Y�L, �A�i��� xml ���
				////  �b�o��� xmlDoc1.xml ����ƶǵ��s�ɵ{��
				////var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
				////xmlHTTP.Open("post", "cont_mainSave.aspx", false);
				//// ��Ǧr��� cont_newSave.aspx �ݬݬO�_��o��; �Y��o��, �A�� xmlDoc1
				////xmlHTTP.Send("test");
				////document.all("textarea1").value=xmlHTTP.responseText;
				////var xmlHTTP = null;
				
				
				// �}�l�ǰe xml ��Ʀܸ�Ʈw���x�s ------------------
				// �b�o��� xmlDoc1.xml ����ƶǵ��s�ɵ{��
				var xmlHTTP = new ActiveXObject("MSXML2.XMLHTTP.3.0");
				xmlHTTP.Open("post", "cont_newSave.aspx", false);
				xmlHTTP.Send(xmlDoc0);
				
				// �ˬd�ÿ�X xmlHTTP ���A�󥻭� textarea1 ��
				//document.all("textarea1").value=xmlHTTP.responseText;
				
				// �Y�x�s���\, �Hĵ�i�������
				if(xmlHTTP.statusText=="OK")
				{
					alert("�s�W�X���Ѧ��\");
					
					// �s�W���\, ��}��T����:
					// ��}��T����: �D�@���I��
					if(xmlContBasicData.selectSingleNode("�@���I�M���O").text==0)  {
						window.location.href="cont_SaveMessage.aspx?str=cont_newSave&cno=" + window.document.all("hiddenContNo").value;
					}
					// ��}��T����: �@���I��
					else  {
						window.location.href="cont_SaveMessage.aspx?str=cont_newSavefg&cno=" + window.document.all("hiddenContNo").value;
					}
					
				}
				
				// �M�� xmlHTTP ��Ƭ���
				var xmlHTTP = null;
			}
			
		}
		//-->
		</script>
	</BODY>
</HTML>
