<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="ContFm_modify.aspx.cs" Src="ContFm_modify.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ContFm_modify" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>���@�X���� �B�J�T</TITLE>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
		<script language="javascript">
		<!--
		// cal���s�� coding: ��t�Τ��
		function pick_date(theField, theField1, theField2)
		{
			// ñ�����
			var oParam = new Object();
			strFeature = "";
			strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
			var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
			//alert("vreturn= " + vreturn);
			
			// �X���_��: ñ��������U�@�Ӥ��
			var vreturn1YYYY = vreturn.substring(0, 4);
			var vreturn1MM = vreturn.substring(5, 7);
			vreturn1MM = parseInt(vreturn1MM) + 1;
			if(vreturn1MM < 10)
				vreturn1MM = "0" + vreturn1MM;
			else
				vreturn1MM = vreturn1MM;
			var vreturn1 = vreturn1YYYY + "/" + vreturn1MM;
			//alert("vreturn1= " + vreturn1);
			
			// �X������: �X���_��@�~�� (+ 11�Ӥ�)
			var vreturn2YYYY = vreturn1YYYY;
			var vreturn2MM = vreturn1MM;
			//alert(parseInt(vreturn2MM));
			// �Y�X���_������ 1��, �h��X������= �~��=�X���_���� & ���=12
			if(parseInt(vreturn2MM) == 1)
			{
				vreturn2YYYY = vreturn2YYYY;
				vreturn2MM = 12;
			}
			// �_�h, �X������= �~��=�X���_��~��+1 & ���=�X���_����-1
			else
			{
				// �Y����� 11~12, �h���X�榡 �e�褣���[ 0 �����
				if(parseInt(vreturn2MM) >= 11)
				{
					vreturn2YYYY = parseInt(vreturn1YYYY) + 1;
					vreturn2MM = parseInt(vreturn1MM) - 1;
					vreturn2MM = vreturn2MM;
				}
				// �Y����p�� 11, �h���X�榡 �e��[ 0 �����
				else
				{
					vreturn2YYYY = parseInt(vreturn1YYYY) + 1;
					//alert(parseInt(vreturn1MM));
					vreturn2MM = parseInt(vreturn1MM) - 1;
					vreturn2MM = "0" + vreturn2MM;
					
					// �S�O�w��ñ����������=8, 9 �� bug �ѨM
					if(parseInt(vreturn1MM) == 0)
					{
						vreturn2MM = parseInt(vreturn.substring(6, 7)) - 1;
						vreturn2MM = "0" + vreturn2MM;
					}
				}
			}
			var vreturn2 = vreturn2YYYY + "/" + vreturn2MM;
			//alert("vreturn2= " + vreturn2);
			
			window.document.all(theField).value=vreturn;
			window.document.all(theField1).value=vreturn1;
			window.document.all(theField2).value=vreturn2;
			return true;
		}
		//-->
		</script>
	</HEAD>
	<body>
		<!-- ���� Header -->
		<kw:header id="Header" runat="server">
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
			<!-- Run at Server Form-->
			<form id="ContFm_modify" method="post" runat="server">
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
						<TD class="cssTitle" noWrap align="right" bgcolor="#bfcff0">
							ñ������G
						</TD>
						<TD class="cssData">
							<FONT color="red">*</FONT>
							<asp:textbox id="tbxSignDate" runat="server" MaxLength="10" Width="65px"></asp:textbox>
							<IMG id="img_signdate" onclick='javascript:pick_date("tbxSignDate", "tbxStartDate", "tbxEndDate");return false;' height="18" alt="�d�ߤ��" src="../images/calendar01.gif" width="18">&nbsp;
							<FONT color="blue">[</FONT><FONT color="red">*</FONT><FONT color="blue">���������]</FONT>
							<br>
							<FONT face="�s�ө���" color="#c00000">(�w�]��: �@�~, �p 2002/06 ~ 2003/05)</FONT>
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
							<asp:textbox id="tbxStartDate" runat="server" MaxLength="7" Width="55px"></asp:textbox>
							&nbsp; <font size="3">~</font> <FONT color="red">*</FONT>
							<asp:textbox id="tbxEndDate" runat="server" MaxLength="7" Width="55px"></asp:textbox>
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
							<asp:RadioButtonList id="rblfgClosed" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">�O</asp:ListItem>
								<asp:ListItem Value="0">�_</asp:ListItem>
							</asp:RadioButtonList>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							�ק�~�ȭ��G
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;&nbsp;
							<asp:DropDownList id="ddlModEmpNo" runat="server"></asp:DropDownList>
							<br>
							<FONT face="�s�ө���" color="#c00000">(�w�]��: �n�J��)</FONT>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							�X�����P���O�G
						</TD>
						<TD class="cssData" noWrap>
							<asp:RadioButtonList id="rblfgCancel" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">�O</asp:ListItem>
								<asp:ListItem Value="0">�_</asp:ListItem>
							</asp:RadioButtonList>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							�ѦҦX���ѽs���G
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;&nbsp;
							<asp:Label id="lblOldContNo" runat="server" ForeColor="Maroon"></asp:Label>
							&nbsp;&nbsp;
							<asp:Label id="lblOldContMessage" runat="server" ForeColor="Maroon"></asp:Label>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							���ɤ���G
						</TD>
						<TD class="cssData" noWrap>
							&nbsp;
							<asp:Label id="lblCreateDate" runat="server"></asp:Label>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							�̫�ק����G
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;&nbsp;
							<asp:Label id="lblModifyDate" runat="server"></asp:Label>
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
										<asp:textbox id="tbxTotalJTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�`�Z�n���ơG
									</TD>
									<TD class="cssData">
										<FONT color="red">*</FONT>
										<asp:textbox id="tbxTotalTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�X���`���B�G
									</TD>
									<TD class="cssData">
										<FONT color="red">* </FONT>$
										<asp:textbox id="tbxTotalAmt" runat="server" MaxLength="8" Width="60px"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										�w�s�Z���ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxMadeJTime" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�w�Z�n���ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxPubTime" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�wú���B�G
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;<FONT face="�s�ө���">$</FONT>
										<asp:TextBox id="tbxPaidAmt" runat="server" MaxLength="8" Width="60px"></asp:TextBox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										�Ѿl�s�Z���ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestJTime" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�Ѿl�Z�n���ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestTime" runat="server" MaxLength="3" Width="30px"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�Ѿl���B�G
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;<FONT face="�s�ө���">$</FONT>
										<asp:TextBox id="tbxRestAmt" runat="server" MaxLength="8" Width="60px"></asp:TextBox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										���Z���ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxChangeJTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�ذe���ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxFreeTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD class="cssTitle" align="right">
										�s�i�O����G
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;$
										<asp:TextBox id="tbxADAmt" runat="server" MaxLength="8" Width="40px"></asp:TextBox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										�u�f��ơG
										<BR>
										<FONT face="�s�ө���" color="#c00000">(�ж���!)</FONT>
									</TD>
									<TD class="cssData">
										<FONT color="red">*</FONT>
										<asp:textbox id="tbxDiscount" runat="server" MaxLength="6" Width="40px"></asp:textbox>
										<FONT face="�s�ө���">��</FONT>&nbsp;
										<br>
										<FONT color="#c00000">�C����, �ж� 0.75</FONT>
									</TD>
									<TD class="cssTitle" align="right">
										�ذe���ơG
									</TD>
									<TD class="cssData">
										$
										<asp:textbox id="tbxFreeBookCount" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
									<TD class="cssTitle" align="right">
										&nbsp;
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										�m�⦸�ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxColorTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
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
										<font color="gray">�w���� �`�s�i���B�G</font>
									</TD>
									<TD class="cssData">
										$
										<asp:textbox id="tbxPubAdAmt" runat="server" Width="60px" MaxLength="8" ForeColor="Gray" Enabled="False"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<font color="gray">�w���� �`���Z���B�G</font>
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;$
										<asp:textbox id="tbxPubChangeAmt" runat="server" Width="60px" MaxLength="8" ForeColor="Gray" Enabled="False"></asp:textbox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										<font color="gray">�w���� �Ѿl�m�⦸�G</font>
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestClrtm" runat="server" MaxLength="3" Width="30px" ForeColor="Gray" Enabled="False"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<font color="gray">�w���� �Ѿl�M�⦸�G</font>
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxRestGetClrtm" runat="server" MaxLength="3" Width="30px" ForeColor="Gray" Enabled="False"></asp:TextBox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										<font color="gray">�w���� �Ѿl�¥զ��G</font>
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:TextBox id="tbxRestMenotm" runat="server" MaxLength="3" Width="30px" ForeColor="Gray" Enabled="False"></asp:TextBox>
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
							<asp:textbox id="tbxAuName" runat="server" MaxLength="30" Width="65px"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right">
							&nbsp;
						</TD>
						<TD class="cssData" noWrap>
							<FONT face="�s�ө���" color="#c00000">(���ϸ�� �w�]�P�Ȥ���!)</FONT>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							�q�ܡG
						</TD>
						<TD class="cssData">
							&nbsp;&nbsp;
							<asp:textbox id="tbxAuTel" runat="server" MaxLength="30" Width="85px"></asp:textbox>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							�ǯu�G
						</TD>
						<TD class="cssData">
							<asp:textbox id="tbxAuFax" runat="server" MaxLength="30" Width="85px"></asp:textbox>
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
							<asp:textbox id="tbxAuEmail" runat="server" MaxLength="80" Width="160px"></asp:textbox>
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
							&nbsp;&nbsp;&nbsp;<TEXTAREA id="tarContRemark" name="tarContRemark" rows="5" cols="60" runat="server"></TEXTAREA>
						</TD>
					</TR>
					<!-- �o���t�Ӧ���H ��� -->
					<TR bgColor="#214389">
						<TD colSpan="4">
							<font color="#ffffff">�o���t�Ӧ���H���</font>&nbsp;&nbsp;&nbsp;
							<asp:Label id="lblIMMessage" runat="server" ForeColor="Yellow"></asp:Label>
							&nbsp;&nbsp; <IMG class="ico" title="�s�W/�ק�/�R�� �o���t�Ӧ���H" height="18" src="../images/new.gif" border="0" onclick="javascript:window.open('InvMfrForm.aspx?contno=<% Response.Write(lblContNo.Text); %>&amp;custno=<% Response.Write(lblCustNo.Text); %>&amp;old_contno=<% Response.Write(lblOldContNo.Text); %>&amp;fgnew=<% Response.Write(lblfgNew.Text); %>', '_new', 'Height=450, Width=750, Top=20, Left=20, toolbar=no, scrollbars=yes, status=no, resizable=no')">&nbsp;&nbsp;&nbsp;
							<asp:ImageButton id="imbIMRefresh" runat="server" ImageUrl="../images/refresh.gif" AlternateText="���s��z �o���t�Ӧ���H���"></asp:ImageButton>
							<asp:Label id="lblfgNew" runat="server" ForeColor="Yellow" Visible="False"></asp:Label>
						</TD>
					</TR>
					<TR>
						<TD colspan="4">
							<font color="darkred">�ާ@�����G</font>�� <img src="../images/new.gif" border="0" alt="�s�W/�ק�/�R�� ���x����H">
							�� �s�W / �ק� / �R�� ����H���; &nbsp;�� <img src="../images/refresh.gif" border="0" alt="���s��z ���x����H���">
							�Ө��o�νT�{�̷s���!
						</TD>
					</TR>
					<TR>
						<TD colSpan="4">
							<asp:datagrid id="DataGrid1" runat="server" AutoGenerateColumns="False" BorderColor="#3366CC" BorderWidth="1px" BackColor="White" BorderStyle="None" CellPadding="2" Font-Size="XX-Small">
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
						<TD colSpan="4">
							<font color="#ffffff">���x����H���</font>&nbsp;&nbsp;
							<asp:Label id="lblORMessage" runat="server" ForeColor="Yellow"></asp:Label>
							&nbsp;&nbsp;&nbsp; <IMG class="ico" title="�s�W/�ק�/�R�� ���x����H" height="18" src="../images/new.gif" border="0" onclick="javascript:window.open('ORForm.aspx?contno=<% Response.Write(lblContNo.Text); %>&amp;custno=<% Response.Write(lblCustNo.Text); %>&amp;old_contno=<% Response.Write(lblOldContNo.Text); %>&amp;fgnew=<% Response.Write(lblfgNew.Text); %>', '_new', 'Height=450, Width=750, Top=20, Left=20, toolbar=no, scrollbars=yes, status=no, resizable=no')">&nbsp;&nbsp;&nbsp;
							<asp:ImageButton id="imbORRefresh" runat="server" AlternateText="���s��z ���x����H���" ImageUrl="../images/refresh.gif"></asp:ImageButton>
							<font color="yellow">(��ƨ��^��, �Ы��@�U������s)</font>
						</TD>
					</TR>
					<TR>
						<TD colspan="4">
							<font color="darkred">�ާ@�����G</font>�� <img src="../images/new.gif" border="0" alt="�s�W/�ק�/�R�� ���x����H">
							�� �s�W / �ק� / �R�� ����H���; &nbsp;�� <img src="../images/refresh.gif" border="0" alt="���s��z ���x����H���">
							�Ө��o�νT�{�̷s���!
						</TD>
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
									<asp:Label id="lblORPunCnt" runat="server" ForeColor="Blue"></asp:Label>
									&nbsp;
									<asp:Label id="lblORUnPubCnt" runat="server" ForeColor="Blue"></asp:Label>
								</font>&nbsp;
							</div>
						</TD>
					</TR>
					<TR bgColor="#ffffff">
						<TD align="middle" colSpan="4">
							<br>
							<asp:button id="btnSave" runat="server" Text="�x�s�ק�"></asp:button>
							&nbsp;&nbsp;
							<asp:button id="btnCancel" runat="server" Text="�����^����"></asp:button>
							&nbsp;
							<asp:Button id="btnGoPub" runat="server" Text="���@�������"></asp:Button>
							&nbsp;
							<asp:Label id="lblfgPubed" runat="server"></asp:Label>
							<asp:Label id="lblpubfgnew" runat="server"></asp:Label>
						</TD>
					</TR>
				</TABLE>
			</form>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
		<!-- �������s��z �\�� (�� ����H����������, �|�I�s�� function) -->
		<script language="javascript">
			function RefreshMe()
			{
				window.ContFm_modify.submit();
			}
		</script>
	</body>
</HTML>
