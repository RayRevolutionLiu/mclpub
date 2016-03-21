<%@ Page language="c#" Codebehind="RptAdrQuery.aspx.cs" src="RptAdrQuery.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RptAdrQuery" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>RptAdrQuery</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="RptAdrQuery" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<table width="100%">
				<tr>
					<td align="middle">
						<TABLE id="tbItems" width="90%">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�s�i�����B�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">�s�i�����έp��</FONT></TD>
							</TR>
						</TABLE>
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="1" width="90%" border="0">
							<TR>
								<TD class="TableColorHeader" colSpan="3">�d�߱���</TD>
							</TR>
							<TR>
								<TD align="right" width="140"><asp:label id="lblAdDate" runat="server">�s�i��϶��G</asp:label></TD>
								<TD><asp:textbox id="tbxSDate" runat="server" Width="100px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxSDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">��
									<asp:textbox id="tbxEDate" runat="server" Width="100px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxEDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">
									<asp:label id="lblyyyymmdd" runat="server" CssClass="ImportantLabel" ForeColor="#C00000">(yyyy/mm/dd)</asp:label></TD>
							</TR>
							<TR>
								<TD align="right"><asp:checkbox id="cbxMfrName" runat="server" Text="�t�ӦW�١G"></asp:checkbox></TD>
								<TD><asp:textbox id="tbxMfrName" runat="server" Width="184px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD align="right"><asp:checkbox id="cbxSrspn" runat="server" Text="�ӿ�~�ȭ��G"></asp:checkbox></TD>
								<TD><asp:dropdownlist id="ddlEmpData" runat="server"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD><br>
									<asp:button id="btnPrintList" runat="server" Text="���ͼs�i�����έp��"></asp:button></TD>
							</TR>
						</TABLE>
						<asp:literal id="Literal1" runat="server"></asp:literal></td>
				</tr>
			</table>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
	</body>
</HTML>
