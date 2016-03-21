<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="cont_list.aspx.cs" Src="cont_list.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.cont_list" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�X���ѲM��</title>
		<META content="Jean Chen" name="Programmer">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS -->
		<LINK title="Style" href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript -->
		<script language="javascript">
		function pick_date(theField){
		var oParam = new Object();
		strFeature = "";
		strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
		var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature);
		if(vreturn)
			window.document.all(theField).value=vreturn;
		return true;
		}

		function doClose()
		{
			window.close();
		}
		</script>
	</HEAD>
	<BODY>
		<center>
			<!-- ���� Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" align="left" border="0">
				<tr>
					<td align="middle"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�X���B�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�X���ѲM��</font>
					</td>
				</tr>
			</table>
			<br>
			&nbsp; 
			<!-- Run at Server Form -->
			<form id="cont_list" name="cont_list" method="post" runat="server">
				<!-- �z�����, ���ܼ� -->
				<!-- �d�߱��� Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" align="center" bgColor="#bfcff0">
					<TBODY>
						<tr bgColor="#214389">
							<td colSpan="2"><font color="white">�d�߱���</font>
							</td>
						</tr>
						<TR>
							<TD>���y���O�W�١G
								<asp:dropdownlist id="ddlBookCode" runat="server"></asp:dropdownlist><br>
								<br>
								<asp:checkbox id="cbx0" runat="server"></asp:checkbox>�ӿ�~�ȭ��G
								<asp:dropdownlist id="ddlEmpNo" runat="server"></asp:dropdownlist>&nbsp;&nbsp;
								<br>
								<asp:CheckBox id="cbx1" runat="server"></asp:CheckBox>
								<asp:label id="lblSignDate" runat="server">�X��ñ������϶��G</asp:label>
								<asp:textbox id="tbxSignDate1" runat="server" MaxLength="10" Width="70px"></asp:textbox>
								<IMG class="ico" title="���" onclick="pick_date(tbxSignDate1.name)" src="../images/calendar01.gif">
								��
								<asp:textbox id="tbxSignDate2" runat="server" MaxLength="10" Width="70px"></asp:textbox>
								<IMG class="ico" title="���" onclick="pick_date(tbxSignDate2.name)" src="../images/calendar01.gif">
								<br>
								<asp:checkbox id="cbx2" runat="server"></asp:checkbox><asp:label id="lblSEDate" runat="server">�X���_���϶��G</asp:label><asp:textbox id="tbxSDate" runat="server" Width="50px"></asp:textbox>��
								<asp:textbox id="tbxEDate" runat="server" Width="50px"></asp:textbox>&nbsp;
								<asp:label id="lblSEDateMemo" runat="server" ForeColor="Maroon" Font-Size="X-Small">(�p 2002/06  �� 2002/12)</asp:label>
								<br>
								<asp:CheckBox id="cbx3" runat="server"></asp:CheckBox>
								<asp:Label id="lblfgclosed" runat="server">�w���סG</asp:Label>
								<asp:DropDownList id="ddlfgclosed" runat="server">
									<asp:ListItem Value="1">�O</asp:ListItem>
									<asp:ListItem Value="0" Selected="True">�_</asp:ListItem>
								</asp:DropDownList>
								<br>
								<asp:CheckBox id="cbx4" runat="server"></asp:CheckBox>
								<asp:Label id="lblMfrIName" runat="server">�t�ӦW�١G</asp:Label>
								<asp:TextBox id="tbxMfrIName" runat="server" Font-Size="X-Small"></asp:TextBox><br>
								&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								<asp:label id="lblMfrMemo" runat="server" ForeColor="Maroon" Font-Size="X-Small">(�п�J�ǽT���t�ӦW��)</asp:label>
								<asp:linkbutton id="InbSearchMfr" runat="server">(�d�߼t�Ӹ�T)</asp:linkbutton>
								<br>
								<!-- �d�߫��s -->
								<asp:linkbutton id="lnbShow" runat="server">�d��</asp:linkbutton>&nbsp;&nbsp;
								<asp:linkbutton id="lnbClearAll" runat="server">�M�����d</asp:linkbutton>
								<br>
								<br>
								<!-- �d�ߵ��G��� -->
								<asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
							<TD vAlign="top" align="left">
								<asp:label id="lblMemo" runat="server" ForeColor="DarkRed">* �пz����, �M����U "�d��".<br><br>*�Y�n�d�߳�@�t�Ӥ��Ҧ��X�����, �Х��Ŀ�<br>�t�ӦW��, ��J�䥿�T�W��(�p�Y����, �i��<br>(�d�߼t�Ӹ�T), �é�Ӷ}�ҵ������U��<br>�Ӭd�ߨ䧹��W��, �A�N�W��[�ƻs&�K�W]�ܥ�����!<br><br>
							</asp:label>
								<asp:TextBox id="tbxLoginEmpNo" runat="server" Width="50px" Font-Size="X-Small" Visible="False" MaxLength="7"></asp:TextBox>
								<asp:TextBox id="tbxLoginEmpCName" runat="server" Width="60px" Font-Size="X-Small" Visible="False"></asp:TextBox>
								<asp:TextBox id="tbxMfrNo" runat="server" Width="70px" MaxLength="10" Font-Size="X-Small" Visible="False"></asp:TextBox>
								<asp:Literal id="Literal1" runat="server"></asp:Literal></TD>
						</TR>
						<TR>
							<TD align="middle" bgColor="#ffffff" colSpan="2">
								&nbsp;
							</TD>
						</TR>
					</TBODY>
				</TABLE>
			</form>
			<br>
			<!-- ���� Footer -->
			<kw:footer id="Footer" runat="server"></kw:footer>
		</center>
	</BODY>
</HTML>
