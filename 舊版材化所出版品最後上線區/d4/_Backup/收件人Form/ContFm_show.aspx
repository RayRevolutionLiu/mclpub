<%@ Page language="c#" Codebehind="ContFm_show.aspx.cs" Src="ContFm_show.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ContFm_show" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>��ܦX����</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
	</HEAD>
	<body>
		<center>
			<!-- �����������s --><INPUT id="btnCloseWin" onclick="javascript:window.close();" type="button" value="��������">
			<br>
			<!-- Run at Server Form -->
			<form id="ContFm_show" method="post" runat="server">
				<!--Table �}�l-->
				<TABLE cellSpacing="0" cellPadding="4" width="92%" bgColor="#bfcff0" border="0">
					<!-- �t�ӤΫȤ��� -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">�t�ӤΫȤ���</font>
						</td>
					</TR>
					<!-- �t�Ӹ�� -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							���q�W�� (�t�Ӳνs)�G
						</TD>
						<TD class="cssData">
							<asp:label id="lblMfrIName" runat="server" ForeColor="Maroon"></asp:label>
							&nbsp;(
							<asp:label id="lblMfrNo" runat="server" ForeColor="Maroon"></asp:label>
							)
						</TD>
						<TD class="cssTitle" noWrap align="right">
							�ԲӸ�ơG
						</TD>
						<TD class="cssData">
							<IMG class="ico" id="imgMfrDetail" onclick="javascript:window.open('mfr_detail.aspx?mfrno=<% Response.Write(lblMfrNo.Text); %>', '_new', 'Height=300, Width=450, Top=100, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt="�t�ӸԲӸ��" src="../images/edit.gif" width="18" border="0">
						</TD>
					</TR>
					<!-- ���q�t�d�H��� -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							���q�t�d�H �m�W(¾��)�G
						</TD>
						<TD class="cssData">
							<asp:label id="lblMfrRespName" runat="server"></asp:label>
							&nbsp;<FONT face="�s�ө���">(
								<asp:label id="lblMfrRespJobTitle" runat="server"></asp:label>
								)</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							���q�q�� (�ǯu)�G
						</TD>
						<TD class="cssData">
							<asp:label id="lblMfrTel" runat="server"></asp:label>
							<FONT face="�s�ө���">&nbsp;(
								<asp:label id="lblMfrFax" runat="server"></asp:label>
								)</FONT>
						</TD>
					</TR>
					<!-- �Ȥ��� -->
					<TR vAlign="center">
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							�Ȥ�m�W (�Ȥ�s��)�G
						</TD>
						<TD class="cssData">
							<asp:label id="lblCustName" runat="server" ForeColor="Maroon"></asp:label>
							<FONT face="�s�ө���">&nbsp;(
								<asp:label id="lblCustNo" runat="server" ForeColor="Maroon"></asp:label>
								)</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							�ԲӸ�ơG
						</TD>
						<TD class="cssData">
							<IMG class="ico" id="imgCustDetail" onclick="javascript:window.open('cust_detail.aspx?custno=<% Response.Write(lblCustNo.Text); %>', '_new', 'Height=420, Width=550, Top=60, Left=100, toolbar=no, scrollbars=yes, status=no, resizable=no')" alt="�Ȥ�ԲӸ��" src="../images/edit.gif" width="18" border="0">
						</TD>
					</TR>
					<!-- �X���Ѱ򥻸�� -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="#ffffff">�X���Ѱ򥻸��&nbsp;&nbsp;</font>&nbsp;
							<asp:label id="lblfgClosedMessage" runat="server" ForeColor="Yellow"></asp:label>
						</td>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							ñ������G
						</TD>
						<TD class="cssData">
							<FONT color="red">*</FONT>
							<asp:textbox id="tbxSignDate" runat="server" Width="65px" MaxLength="10"></asp:textbox>
							&nbsp; <FONT color="blue">[</FONT><FONT color="red">*</FONT><FONT color="blue">���������]</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							�X���ѽs���G
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:label id="lblContNo" runat="server" ForeColor="Maroon"></asp:label>
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
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							���y���O�G
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:dropdownlist id="ddlBookCode" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							�X���_����G
						</TD>
						<TD class="cssData" noWrap>
							<FONT color="red">*</FONT>
							<asp:textbox id="tbxStartDate" runat="server" Width="55px" MaxLength="7"></asp:textbox>
							&nbsp; <font size="3">~</font> <FONT color="red">*</FONT>
							<asp:textbox id="tbxEndDate" runat="server" Width="55px" MaxLength="7"></asp:textbox>
							&nbsp;
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							���ɷ~�ȭ��G
						</TD>
						<TD class="cssData">
							<FONT color="red">*</FONT>
							<asp:dropdownlist id="ddlEmpNo" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							�@���I�M���O�G
						</TD>
						<TD class="cssData" noWrap>
							<asp:radiobuttonlist id="rblfgPayOnce" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">�O</asp:ListItem>
								<asp:ListItem Value="0">�_</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
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
							<asp:radiobuttonlist id="rblfgClosed" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">�O</asp:ListItem>
								<asp:ListItem Value="0">�_</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							�ק�~�ȭ��G
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;&nbsp;
							<asp:dropdownlist id="ddlModEmpNo" runat="server"></asp:dropdownlist>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							�X�����P���O�G
						</TD>
						<TD class="cssData" noWrap>
							<asp:radiobuttonlist id="rblfgCancel" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">�O</asp:ListItem>
								<asp:ListItem Value="0">�_</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							�ѦҦX���ѽs���G
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;&nbsp;
							<asp:label id="lblOldContNo" runat="server" ForeColor="Maroon"></asp:label>
							&nbsp;&nbsp;&nbsp;
							<asp:label id="lblOldContMessage" runat="server" ForeColor="Maroon"></asp:label>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							���ɤ���G
						</TD>
						<TD class="cssData" noWrap>
							&nbsp;
							<asp:label id="lblCreateDate" runat="server"></asp:label>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							�̫�ק����G
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;&nbsp;
							<asp:label id="lblModifyDate" runat="server"></asp:label>
						</TD>
					</TR>
					<!-- �X���ѲӸ` ��� -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">�X���ѲӸ`</font>
						</td>
					</TR>
					<TR>
						<TD class="cssTitle" vAlign="center" align="middle" colSpan="4">
							<TABLE borderColor="#214389" cellSpacing="1" cellPadding="1" width="90%" border="0">
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										�`�s�Z���ơG
									</TD>
									<TD class="cssData">
										<FONT color="red">*</FONT>
										<asp:textbox id="tbxTotalJTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�`�Z�n���ơG
									</TD>
									<TD class="cssData">
										<FONT color="red">*</FONT>
										<asp:textbox id="tbxTotalTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�X���`���B�G
									</TD>
									<TD class="cssData">
										<FONT color="red">* </FONT>$
										<asp:textbox id="tbxTotalAmt" runat="server" Width="60px" MaxLength="8"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										�w�s�Z���ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxMadeJTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�w�Z�n���ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxPubTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�wú���B�G
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;<FONT face="�s�ө���">$</FONT>
										<asp:textbox id="tbxPaidAmt" runat="server" Width="60px" MaxLength="8"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										�Ѿl�s�Z���ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxRestJTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�Ѿl�Z�n���ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxRestTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�Ѿl���B�G
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;<FONT face="�s�ө���">$</FONT>
										<asp:textbox id="tbxRestAmt" runat="server" Width="60px" MaxLength="8"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										���Z���ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxChangeJTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�ذe���ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxFreeTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" align="right">
										�s�i�O����G&nbsp;
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;$
										<asp:textbox id="tbxADAmt" runat="server" Width="40px" MaxLength="8"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										�u�f��ơG&nbsp;
									</TD>
									<TD class="cssData">
										<FONT color="red">*</FONT>
										<asp:textbox id="tbxDiscount" runat="server" Width="40px" MaxLength="6"></asp:textbox>
										<FONT face="�s�ө���">��</FONT>
									</TD>
									<TD class="cssTitle" align="right">
										�ذe���ơG&nbsp;
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxFreeBookCount" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" align="right">
										&nbsp;
									</TD>
									<TD class="cssData">
										&nbsp;
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										�m�⦸�ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxColorTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�M�⦸�ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxGetColorTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" align="right">
										�¥զ��ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:textbox id="tbxMenoTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										&nbsp;
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<font color="Gray">�w���� �`�s�i���B�G</font>
									</TD>
									<TD class="cssData">
										$
										<asp:textbox id="tbxPubAdAmt" runat="server" Width="60px" MaxLength="8"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<font color="Gray">�w���� �`���Z���B�G</font>
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;$
										<asp:textbox id="tbxPubChangeAmt" runat="server" Width="60px" MaxLength="8"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										<font color="Gray">�w���� �Ѿl�m�⦸�G</font>
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestClrtm" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<font color="Gray">�w���� �Ѿl�M�⦸�G</font>
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestGetClrtm" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<font color="Gray">�w���� �Ѿl�¥զ��ơG</font>
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;<FONT face="�s�ө���">&nbsp; </FONT>&nbsp;
										<asp:TextBox id="tbxRestMenotm" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR> <!-- �s�i�p���H ��� -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="white">�s�i�p���H���</font>
						</td>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							�s�i�p���H�m�W�G
						</TD>
						<TD class="cssData">
							<FONT color="red">* </FONT>
							<asp:textbox id="tbxAuName" runat="server" Width="65px" MaxLength="30"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right">
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
							<FONT face="�s�ө���">&nbsp;&nbsp; </FONT>
							<asp:textbox id="tbxAuTel" runat="server" Width="85px" MaxLength="30"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							�ǯu�G
						</TD>
						<TD class="cssData">
							<asp:textbox id="tbxAuFax" runat="server" Width="85px" MaxLength="30"></asp:textbox>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							����G
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:textbox id="tbxAuCell" runat="server" Width="85px" MaxLength="30"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							Email�G
						</TD>
						<TD class="cssData">
							<asp:textbox id="tbxAuEmail" runat="server" Width="160px" MaxLength="80"></asp:textbox>
						</TD>
					</TR>
					<!-- �Ƶ��@��� -->
					<TR bgColor="#214389">
						<TD colSpan="4">
							<font color="white">�Ƶ�</font>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" align="right">
							�B�~�Ƶ��G
						</TD>
						<TD class="cssData" colSpan="3">
							&nbsp;&nbsp;&nbsp;<TEXTAREA id="tarContRemark" name="tarContRemark" rows="5" cols="60" runat="server" disabled></TEXTAREA>
						</TD>
					</TR>
					<!-- �o���t�Ӧ���H ��� -->
					<TR bgColor="#214389">
						<TD colSpan="4">
							<font color="#ffffff">�o���t�Ӧ���H���</font>&nbsp;&nbsp;
						</TD>
					</TR>
					<TR>
						<TD colSpan="4">
							<asp:datagrid id="DataGrid1" runat="server" Font-Size="XX-Small" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False">
								<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="im_imseq" HeaderText="�Ǹ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_mfrno" HeaderText="�t�Ӳνs"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_nm" HeaderText="����H�m�W"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_jbti" HeaderText="¾��"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_addr" HeaderText="�o���a�}"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_tel" HeaderText="�q��"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_fax" HeaderText="�ǯu"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_cell" HeaderText="���"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_email" HeaderText="Email"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_invcd" HeaderText="�o�����O"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_taxtp" HeaderText="�o���ҵ|�O"></asp:BoundColumn>
									<asp:BoundColumn DataField="im_fgitri" HeaderText="�|�Ҥ����O"></asp:BoundColumn>
								</Columns>
							</asp:datagrid>
							<br>
						</TD>
					</TR>
					<!-- ���x����H ��� -->
					<TR bgColor="#214389">
						<td colSpan="4">
							<font color="#ffffff">���x����H���</font>&nbsp;&nbsp;
						</td>
					</TR>
					<TR>
						<TD colSpan="4">
							<asp:datagrid id="Datagrid2" runat="server" CellPadding="2" BorderStyle="None" BackColor="White" BorderWidth="1px" BorderColor="#3366CC" AutoGenerateColumns="False">
								<HeaderStyle Font-Bold="True" BackColor="#BFCFF0"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="or_oritem" HeaderText="�Ǹ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_inm" HeaderText="�t�ӦW��"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_nm" HeaderText="����H�m�W"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_jbti" HeaderText="¾��"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_zip" HeaderText="�l���ϸ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_addr" HeaderText="�l�H�a�}"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_tel" HeaderText="�q��"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_fax" HeaderText="�ǯu"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_cell" HeaderText="���"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_email" HeaderText="Email"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_pubcnt" HeaderText="���n����"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_unpubcnt" HeaderText="���n����"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_mtpcd" HeaderText="�l�H���O"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_fgmosea" HeaderText="���~�l�H"></asp:BoundColumn>
								</Columns>
							</asp:datagrid>
							<br>
							<div align="right">
								<font color="red">���n���ơ����n���� �`�p�G
									<asp:label id="lblORPunCnt" runat="server" ForeColor="Blue"></asp:label>
									&nbsp;
									<asp:label id="lblORUnPubCnt" runat="server" ForeColor="Blue"></asp:label>
								</font>&nbsp;
							</div>
						</TD>
					</TR>
					<TR bgColor="#ffffff">
						<TD align="middle" colSpan="4">
							<br>
							<INPUT id="btnCloseWin2" onclick="javascript:window.close();" type="button" value="��������" name="Button1">
						</TD>
					</TR>
				</TABLE>
			</form>
		</center>
	</body>
</HTML>
