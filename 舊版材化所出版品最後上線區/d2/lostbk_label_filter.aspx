<%@ Register TagPrefix="kw" TagName="footer" Src="../UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="lostbk_label_filter.aspx.cs" SRC="lostbk_label_filter.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d2.lostbk_label_filter" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>�ʮѼ��� �j�M</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!-- CSS --><LINK href="../UserControl/mrlpub.css" type="text/css" rel="stylesheet">
		<!-- Javascript-->
		<script language="javascript">
		<!--
		// cal���s�� coding: ��t�Τ��
		function pick_date(theField)
		{
			// ñ�����
			var oParam = new Object();
			strFeature = "";
			strFeature += "dialogHeight:250px;dialogWidth:200px;center:yes;scroll:yes;status:no;help:no;";
			var vreturn = window.showModalDialog("calendar.asp", oParam, strFeature); 
			//alert("vreturn= " + vreturn);
			
			window.document.all(theField).value=vreturn;
			return true;
		}
		//-->
		</script>
	</HEAD>
	<body>
		<center>
			<!-- ���� Header -->
			<kw:header id="Header" runat="server"></kw:header>
			<!-- �ثe�Ҧb��m -->
			<table dataFld="items" id="tbItems" style="WIDTH: 739px">
				<tr>
					<td style="WIDTH: 100%" align="left"><font color="#333333" size="2"><IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�����s�i���t�� <IMG height="10" src="../images/header/right02.gif" width="10" border="0">
							�ʮѳB�z <IMG height="10" src="../images/header/right02.gif" width="10" border="0"> 
							�ʮѼ��� �j�M</font>
					</td>
				</tr>
			</table>
			&nbsp; 
			<!-- Run at Server Form-->
			<form id="lostbk_label_filter" method="post" runat="server">
				<!-- �d�߱��� Table -->
				<TABLE style="WIDTH: 90%" cellSpacing="0" cellPadding="2" align="center" bgColor="#bfcff0">
					<TBODY>
						<tr bgColor="#214389">
							<td colSpan="2"><font color="white">�d�߱���</font>
							</td>
						</tr>
						<TR>
							<TD width="*"><asp:label id="lblfgmosea" runat="server">�l�H�a�ϡG</asp:label><asp:dropdownlist id="ddlfgmosea" runat="server" AutoPostBack="True">
									<asp:ListItem Value="0" Selected="True">�ꤺ</asp:ListItem>
									<asp:ListItem Value="1">��~</asp:ListItem>
								</asp:dropdownlist>&nbsp; 
								<!-- �d�߫��s --><asp:linkbutton id="lnbShow" runat="server">�d��</asp:linkbutton>&nbsp;&nbsp;
								<asp:linkbutton id="lnbClearAll" runat="server">�M�����d</asp:linkbutton>&nbsp;&nbsp;&nbsp;&nbsp;
								<br>
								<!-- �d�ߵ��G��� --><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></TD>
							<TD vAlign="top" align="left" width="50%"><asp:label id="lblMemo" runat="server" ForeColor="DarkRed">1. �п�J���@������Ӭd��, �M����U "�d��".<br>
2. �X�{���G��, �ФĿ�, �A���U "<font color="Gray">���ҦC�L/�C�L���T</font>" �ӧ���!<br>3. �p�G�C�L���Ҥ����G���~, �����L.  �а��W���U '�C�L�����T, �^�_' ���s�ӭ��L.</asp:label><asp:textbox id="tbxLoginEmpNo" runat="server" Width="50px" Visible="False" Font-Size="X-Small"></asp:textbox><asp:textbox id="tbxLoginEmpCName" runat="server" Width="60px" Visible="False" Font-Size="X-Small"></asp:textbox><asp:literal id="Literal1" runat="server"></asp:literal></TD>
						</TR>
						<TR>
							<TD bgColor="#ffffff" colSpan="2"><asp:panel id="pnlLabelData" runat="server">
<asp:button id="btnCheckAll" runat="server" Text="����"></asp:button>&nbsp;&nbsp; 
<asp:Button id="btnPrintLabel" runat="server" Text="���ҦC�L"></asp:Button>&nbsp;&nbsp; 
<asp:Button id="btnPrintOK" runat="server" Text="�C�L���T" Enabled="False"></asp:Button>&nbsp; 
<asp:Button id="btnPrintError" runat="server" Text="�C�L�����T, �^�_" Enabled="False"></asp:Button><BR>
<asp:datalist id="DataList1" runat="server" BorderWidth="1px" GridLines="Horizontal" CellPadding="3" BackColor="White" BorderStyle="None" BorderColor="#E7E7FF">
										<SelectedItemStyle Font-Bold="True" ForeColor="#F7F7F7" BackColor="#738A9C"></SelectedItemStyle>
										<HeaderTemplate>
											<TABLE border="0">
												<TR align="left">
													<TD width="30">
														<FONT color="white">���</FONT>
													</TD>
													<TD width="50">
														<FONT color="white">�X���s��</FONT>
													</TD>
													<TD width="50">
														<FONT color="white">�ʮѧǸ�</FONT>
													</TD>
													<TD width="60">
														<FONT color="white">���x����H</FONT>
													</TD>
													<TD width="60">
														<FONT color="white">�ʮѤ��</FONT>
													</TD>
													<TD width="150">
														<FONT color="white">�ʮѤ��e</FONT>
													</TD>
													<TD width="120">
														<FONT color="white">�ʮѭ�]</FONT>
													</TD>
													<TD width="100">
														<FONT color="white">�H�Ѫ��A</FONT>
													</TD>
												</TR>
											</TABLE>
										</HeaderTemplate>
										<EditItemStyle BackColor="Info"></EditItemStyle>
										<AlternatingItemStyle BackColor="#F7F7F7"></AlternatingItemStyle>
										<ItemStyle BorderWidth="1px" ForeColor="#4A3C8C" BackColor="#E7E7FF"></ItemStyle>
										<FooterStyle ForeColor="#4A3C8C" BackColor="#B5C7DE"></FooterStyle>
										<ItemTemplate>
											<TABLE border="0">
												<TR align="left">
													<TD>
														<asp:CheckBox id="cbx1" Width="30" Runat="server"></asp:CheckBox>
													</TD>
													<TD>
														<asp:Label id="lblContNo" Width="50" text='<%# DataBinder.Eval(Container.DataItem, "lst_contno")%>' Runat="server">
														</asp:Label>
													</TD>
													<TD>
														<asp:Label id="lblLostSeq" Width="50" text='<%# DataBinder.Eval(Container.DataItem, "lst_seq")%>' Runat="server">
														</asp:Label>
													</TD>
													<TD>
														<asp:Label id="lblORName" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "or_nm")%>' Runat="server">
														</asp:Label>
													</TD>
													<TD>
														<asp:Label id="lblLostDate" Width="60" text='<%# DataBinder.Eval(Container.DataItem, "lst_date")%>' Runat="server">
														</asp:Label>
													</TD>
													<TD>
														<asp:Label id="lblLostCont" Width="150" text='<%# DataBinder.Eval(Container.DataItem, "lst_cont")%>' Runat="server">
														</asp:Label>
													</TD>
													<TD>
														<asp:Label id="lblLostRea" Width="120" text='<%# DataBinder.Eval(Container.DataItem, "lst_rea")%>' Runat="server">
														</asp:Label>
													</TD>
													<TD>
														<asp:Label id="lblLostfgSent" Width="100" text='<%# DataBinder.Eval(Container.DataItem, "lst_fgsentText")%>' Runat="server">
														</asp:Label>
													</TD>
												</TR>
											</TABLE>
										</ItemTemplate>
										<HeaderStyle Font-Bold="True" BorderWidth="1px" ForeColor="#F7F7F7" BackColor="#4A3C8C"></HeaderStyle>
									</asp:datalist></asp:panel></TD>
						</TR>
					</TBODY>
				</TABLE>
			</form>
			<br>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer></center>
	</body>
</HTML>
