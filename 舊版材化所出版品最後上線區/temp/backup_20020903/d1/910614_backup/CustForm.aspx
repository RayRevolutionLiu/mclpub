<%@ Page language="c#" Codebehind="CustForm.aspx.cs" src="CustForm.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.CustForm" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="CustForm" method="post" runat="server">
			<FONT face="�s�ө���"></FONT>
		</form>
		<center>
			<table dataFld="items" id="tbItems">
				<tr>
					<td style="WIDTH: 627px" align="left">
						<font color="#333333" size="2"><IMG height="10" src="images/header/right02.gif" width="10" border="0">
							���x�O�ѭq�\���t�� <IMG height="10" src="images/header/right02.gif" width="10" border="0">
							�q���� <IMG height="10" src="images/header/right02.gif" width="10" border="0">
							<% Response.Write(Context.Request.QueryString["type"]);%>
						</font>
					</td>
				</tr>
			</table>
			<TABLE style="WIDTH: 596px; HEIGHT: 68px" cellSpacing="0" cellPadding="4" bgColor="#bfcff0">
				<tr bgColor="#214389">
					<td colSpan="4">
						<font color="white">�q����</font>
					</td>
				</tr>
				<TR>
					<TD class="cssTitle" style="WIDTH: 189px" align="right">
						�q��s���G
					</TD>
					<TD class="cssData" style="WIDTH: 192px">
						<INPUT dataFld="�q�����O" id="invoiceid" type="text" name="invoiceid" style="WIDTH: 109px; HEIGHT: 22px" size="12">
						<IMG class="ico" onclick="doSelectCust('�q�����O', custname.value)" height="20" src="images/search.gif" width="18" border="0" title="�d��">
					</TD>
					<TD class="cssTitle" style="WIDTH: 109px" align="right">
						���q�W�١G
					</TD>
					<TD class="cssData" style="WIDTH: 192px">
						<INPUT dataFld="���q�W��" id="companyname" type="text" name="companyname" style="WIDTH: 159px; HEIGHT: 22px" size="21">
						<IMG class="ico" onclick="doSelectCust('���q�W��', companyname.value)" height="20" src="images/search.gif" width="18" border="0" title="�d��">
					</TD>
				</TR>
				<TR>
					<TD class="cssTitle" style="WIDTH: 189px" align="right">
						�m�W�G
					</TD>
					<TD class="cssData" style="WIDTH: 192px">
						<INPUT dataFld="�m�W" id="custname" type="text" name="custname" style="WIDTH: 108px; HEIGHT: 22px" size="12">
						<IMG class="ico" onclick="doSelectCust('�m�W', custname.value)" height="20" src="images/search.gif" width="18" border="0" title="�d��">
					</TD>
					<TD class="cssTitle" style="WIDTH: 109px" align="right">
						�ԲӸ�ơG
					</TD>
					<TD class="cssData" style="WIDTH: 192px">
						&nbsp;<IMG class="ico" title="�q��ԲӸ��" height="14" src="images/edit.gif" width="16" border="0">
					</TD>
				</TR>
				<tr bgColor="#214389">
					<td colSpan="4">
						<font color="white">�q��εo�����</font>
					</td>
				</tr>
				<tr>
					<td class="cssTitle" style="WIDTH: 189px; HEIGHT: 22px" align="right">
						�q��y�����G
					</td>
					<td class="cssData" style="WIDTH: 192px; HEIGHT: 22px">
						&nbsp;
						<asp:dropdownlist id="DropDownList3" runat="server">
							<asp:ListItem Value="1">001</asp:ListItem>
							<asp:ListItem Value="2">002</asp:ListItem>
							<asp:ListItem Value="3">003</asp:ListItem>
						</asp:dropdownlist>
					</td>
					<td class="cssTitle" style="WIDTH: 109px; HEIGHT: 22px" align="right">
						����H�G
					</td>
					<td class="cssData" style="WIDTH: 192px; HEIGHT: 22px">
						&nbsp;
						<asp:dropdownlist id="DropDownList4" runat="server">
							<asp:ListItem Value="001">���ɲ�</asp:ListItem>
							<asp:ListItem Value="002">���W�R</asp:ListItem>
						</asp:dropdownlist>
					</td>
				</tr>
				<tr>
					<td class="cssTitle" style="WIDTH: 189px; HEIGHT: 22px" align="right">
						�q�ʮ��y�G
					</td>
					<td class="cssData" style="WIDTH: 192px; HEIGHT: 22px">
						&nbsp;
						<asp:dropdownlist id="Dropdownlist2" runat="server">
							<asp:ListItem Value="1">�u���q��</asp:ListItem>
							<asp:ListItem Value="2">�q���q��</asp:ListItem>
						</asp:dropdownlist>
					</td>
					<td class="cssTitle" style="WIDTH: 109px; HEIGHT: 33px" align="right">
						�q�����O�G
					</td>
					<td class="cssData" style="WIDTH: 192px; HEIGHT: 33px">
						<FONT face="�s�ө���">�q�\</FONT>
					</td>
				</tr>
				<tr bgColor="#214389">
					<td colSpan="4">
						<font color="white">�ʮѸ��</font>
					</td>
				</tr>
				<tr>
					<td class="cssTitle" style="WIDTH: 189px; HEIGHT: 31px" align="right">
						�ʮѧǸ��G
					</td>
					<td class="cssData" style="WIDTH: 192px; HEIGHT: 31px">
						<input dataFld="�ʮѧǸ�" id="Text3" style="WIDTH: 98px; HEIGHT: 22px" type="text" size="11" name="Text3">
					</td>
					<td class="cssTitle" style="WIDTH: 109px; HEIGHT: 31px" align="right">
						�ʮѤ���G
					</td>
					<td class="cssData" style="WIDTH: 192px;HEIGHT: 31px">
						<input dataFld="�ʮѤ��" id="hh" style="WIDTH: 98px" type="text" size="11" name="hh">
					</td>
				</tr>
				<tr>
					<td class="cssTitle" style="WIDTH: 189px; HEIGHT: 75px" align="right">
						�ʮѤ��e�G
					</td>
					<td class="cssData" colSpan="3" style="HEIGHT: 75px">
						&nbsp;<TEXTAREA style="WIDTH: 445px; HEIGHT: 77px" rows="4" cols="53">							</TEXTAREA>
					</td>
				</tr>
				<tr>
					<td class="cssTitle" style="WIDTH: 189px; HEIGHT: 42px" align="right">
						�ʮѭ�]�G
					</td>
					<td class="cssData" colSpan="3">
						&nbsp;<TEXTAREA style="WIDTH: 445px; HEIGHT: 75px" rows="4" cols="53">							</TEXTAREA>
					</td>
				</tr>
			</TABLE>
			<!-- ���� Footer -->
		</center>
		<asp:Button id="Button1" runat="server" Text="�s�W���"></asp:Button>
		<asp:Button id="Button2" runat="server" Text="�ק���"></asp:Button>
		<asp:Button id="Button3" runat="server" Text="������J"></asp:Button>
	</body>
</HTML>
