<%@ Page language="c#" Codebehind="AdrXmlManage.aspx.cs" Src="AdrXmlManage.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.AdrXmlManage" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���ƩҥX���~�Ȥ�޲z�t��</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="AdrXmlManage" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD align="middle">
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�����B�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">�R���������X��
									</FONT>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td align="middle">
						<asp:Label id="lblxml" runat="server" CssClass="NormalLabel" ForeColor="#C00000">�{��xml�ɮ�</asp:Label><br>
						<asp:datagrid id="dgdXml" runat="server" AutoGenerateColumns="False" CssClass="DataGridStyle">
							<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
							<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemStyle"></ItemStyle>
							<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
							<Columns>
								<asp:ButtonColumn Text="�R��" CommandName="Delete"></asp:ButtonColumn>
								<asp:BoundColumn DataField="filename" HeaderText="xml�ɮ�"></asp:BoundColumn>
							</Columns>
						</asp:datagrid>
					</td>
				</tr>
			</TABLE>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
