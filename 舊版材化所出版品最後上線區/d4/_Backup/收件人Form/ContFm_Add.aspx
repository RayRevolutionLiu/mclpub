<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Page language="c#" Codebehind="ContFm_Add.aspx.cs" Src="ContFm_Add.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.ContFm_Add" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<TITLE>�s�W�X���� �B�J�T</TITLE>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
	<BODY>
		<!-- ���� Header -->
		<kw:header id="Header" runat="server">
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
			<form id="ContFm_Add" method="post" runat="server">
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
							<font color="#ffffff">�X���Ѱ򥻸��&nbsp;&nbsp;</font>&nbsp;&nbsp;<font siz2="2" color="yellow">(���ϨS�����J���v���, 
								�Цۦ��J�T�{!)</font>&nbsp;
							<asp:label id="lblfgClosedMessage" runat="server" ForeColor="Yellow"></asp:label>
						</td>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							ñ������G
						</TD>
						<TD class="cssData">
							<FONT color="red">*</FONT>
							<asp:textbox id="tbxSignDate" runat="server" MaxLength="10" Width="65px"></asp:textbox>
							<IMG id="img_signdate" onclick='javascript:pick_date("tbxSignDate", "tbxStartDate", "tbxEndDate");return false;' height="18" alt="�d�ߤ��" src="../images/calendar01.gif" width="18">&nbsp;
							<FONT color="blue">[</FONT><FONT color="red">*</FONT><FONT color="blue">���������]</FONT>
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
							<br>
							<FONT face="�s�ө���" color="#c00000">(�w�]��: �@�~, �p 2002/06 ~ 2003/05)</FONT>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							�ӿ�~�ȭ��G
						</TD>
						<TD class="cssData">
							<FONT color="red">*</FONT>
							<asp:dropdownlist id="ddlEmpNo" runat="server"></asp:dropdownlist>
							<br>
							<FONT face="�s�ө���" color="#c00000">(�w�]��: �n�J��)</FONT>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							�@���I�M���O�G
						</TD>
						<TD class="cssData" noWrap>
							<asp:radiobuttonlist id="rblfgPayOnce" runat="server" RepeatDirection="Horizontal">
								<asp:ListItem Value="1">�O</asp:ListItem>
								<asp:ListItem Value="0" Selected="True">�_</asp:ListItem>
							</asp:radiobuttonlist>
						</TD>
						<TD class="cssTitle" noWrap align="right" bgColor="#bfcff0">
							&nbsp;
						</TD>
						<TD class="cssData" vAlign="top">
							&nbsp;&nbsp;
							<asp:Label id="lblOldContNo" runat="server" ForeColor="Maroon" Visible="False"></asp:Label>
							&nbsp;&nbsp;
							<asp:Label id="lblOldContMessage" runat="server" ForeColor="Maroon"></asp:Label>
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
										�`�Z�n���ơG&nbsp;
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
										���Z���ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxChangeJTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�ذe���ơG&nbsp;
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:textbox id="tbxFreeTime" runat="server" MaxLength="3" Width="30px"></asp:textbox>
									</TD>
									<TD class="cssTitle" noWrap align="right">
										�s�i�O����G
									</TD>
									<TD class="cssData">
										&nbsp;<FONT face="�s�ө���">$</FONT>
										<asp:TextBox id="tbxADAmt" runat="server" Width="40px" MaxLength="8"></asp:TextBox>
									</TD>
								</TR>
								<TR vAlign="center" align="left">
									<TD class="cssTitle" noWrap align="right">
										�u�f��ơG
										<BR>
										<FONT face="�s�ө���" color="#c00000">(�ж���!)</FONT>
									</TD>
									<TD class="cssData">
										&nbsp;<FONT color="red">*</FONT>
										<asp:textbox id="tbxDiscount" runat="server" Width="40px" MaxLength="6"></asp:textbox>
										<FONT face="�s�ө���">��</FONT>&nbsp;
										<br>
										<FONT color="#c00000">�C����, �ж� 0.75</FONT>
									</TD>
									<TD class="cssTitle" align="right">
										�ذe���ơG
									</TD>
									<TD class="cssData">
										&nbsp;&nbsp;
										<asp:TextBox id="tbxFreeBookCount" runat="server" Width="30px" MaxLength="3"></asp:TextBox>
									</TD>
									<TD class="cssData" colspan="2">
										<font color="#c00000">(�m/�M/�¥զ���=�`�Z�n���� + �ذe����)</font>
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
										&nbsp;&nbsp;&nbsp;
										<asp:textbox id="tbxMenoTime" runat="server" Width="30px" MaxLength="3"></asp:textbox>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR> <!-- �s�i�p���H ��� -->
					<TR bgColor="#214389">
						<TD colSpan="4">
							<FONT color="white">�s�i�p���H���</FONT>
						</TD>
					</TR>
					<TR>
						<TD class="cssTitle" noWrap align="right">
							�s�i�p���H�m�W�G
						</TD>
						<TD class="cssData">
							<FONT color="red">* </FONT>
							<asp:textbox id="tbxAuName" runat="server" MaxLength="30" Width="65px"></asp:textbox>
							&nbsp;
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
							<font color="#ffffff">�o���t�Ӧ���H���</font>&nbsp;&nbsp;
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
							<font color="#ffffff">���x����H���&nbsp;&nbsp;</font>
							<asp:Label id="lblORMessage" runat="server" ForeColor="Yellow"></asp:Label>
							&nbsp;&nbsp; <IMG class="ico" title="�s�W/�ק�/�R�� ���x����H" height="18" src="../images/new.gif" border="0" onclick="javascript:window.open('ORForm.aspx?contno=<% Response.Write(lblContNo.Text); %>&amp;custno=<% Response.Write(lblCustNo.Text); %>&amp;old_contno=<% Response.Write(lblOldContNo.Text); %>&amp;fgnew=<% Response.Write(lblfgNew.Text); %>', '_new', 'Height=450, Width=750, Top=20, Left=20, toolbar=no, scrollbars=yes, status=no, resizable=no')">&nbsp;&nbsp;&nbsp;
							<asp:ImageButton id="imbORRefresh" runat="server" ImageUrl="../images/refresh.gif" AlternateText="���s��z ���x����H���"></asp:ImageButton>
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
					<TR bgcolor="#ffffff">
						<TD colSpan="4" align="middle">
							<asp:Label id="lblAddMessage" runat="server" ForeColor="Maroon"></asp:Label>
							<br>
							<asp:Button id="btnSave" runat="server" Text="�x�s�s�W"></asp:Button>
							&nbsp;&nbsp;
							<asp:Button id="btnCancel" runat="server" Text="���s�W"></asp:Button>
							<FONT face="�s�ө���">&nbsp;&nbsp; </FONT>
							<asp:Button id="btnBack" runat="server" Text="�����^����"></asp:Button>
						</TD>
					</TR>
				</TABLE>
			</form>
			<br>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server">
			</kw:footer>
		</center>
		<!-- �������s��z �\�� (�� ����H����������, �|�I�s�� function) -->
		<script language="javascript">
			function RefreshMe()
			{
				window.ContFm_Add.submit();
			}
		</script>
	</BODY>
</HTML>
