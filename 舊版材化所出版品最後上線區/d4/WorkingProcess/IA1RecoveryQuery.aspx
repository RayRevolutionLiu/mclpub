<%@ Page language="c#" Codebehind="IA1RecoveryQuery.aspx.cs" src="IA1RecoveryQuery.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.IA1RecoveryQuery" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>��@�t�Ӥ��o���}�߳�^�_(Recovery):�d�߱���</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="IA1RecoveryQuery" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<table width="100%">
				<tr>
					<td align="middle"><br>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 90%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�o���B�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										��@�t�Ӥ��o���}�߳�^�_(Recovery):�d�߱���</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td align="middle">
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="1" width="90%" border="0">
							<TR>
								<TD class="TableColorHeader" colSpan="3">�d�߱���</TD>
							</TR>
							<TR>
								<TD align="right" width="160">�o���t�ӦW�١G</TD>
								<TD width="160"><asp:textbox id="tbxMfrNm" runat="server" Width="150px"></asp:textbox></TD>
								<TD class="ContAnnounce" rowSpan="3"><asp:label id="lblContHint" Runat="server" CssClass="ContAnnounce">
									1.�п�J���@������Ӭd�ߡA�M����U"�d��".<BR>
									2.�d�X��ƫ�A��ܩһݪ��o���}�߳���U"�T�w"�i�i��o���}�߳�^�_
									3.�j�岣�ͤ��o���}�߳椣�|�b���X�{
									</asp:label></TD>
							</TR>
							<TR>
								<TD align="right">�Τ@�s���G</TD>
								<TD><asp:textbox id="tbxMfrNo" runat="server" Width="80px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 156px" align="right">�o������H�G</TD>
								<TD><asp:textbox id="tbxRecNm" runat="server" Width="100px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 156px" align="right">�o���}�߳�s���G</TD>
								<TD><asp:textbox id="tbxIano" runat="server" Width="100px"></asp:textbox><asp:linkbutton id="lnbQuery" runat="server">�d��</asp:linkbutton></TD>
								<td><asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label></td>
							</TR>
						</TABLE>
						<asp:datagrid id="dgdCont" runat="server" Width="90%" CssClass="DataGridStyle" AutoGenerateColumns="False" AllowPaging="True">
							<ItemStyle CssClass="ItemStyle"></ItemStyle>
							<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="ia_iano" ReadOnly="True" HeaderText="�o���}�߳�s��"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_contno" HeaderText="�X���s��"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_mfrno" HeaderText="�o���t�Ӳνs"></asp:BoundColumn>
								<asp:BoundColumn DataField="mfr_inm" HeaderText="�o���t�ӦW��"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_rnm" HeaderText="�o������H"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_pyat" HeaderText="�o�����B"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_invcd" HeaderText="�o�����O"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_taxtp" HeaderText="�ҵ|�O"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_fgitri" HeaderText="���ӵ��O"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_status" HeaderText="�i�檬�A"></asp:BoundColumn>
								<asp:BoundColumn DataField="ia_status" HeaderText="" Visible="False"></asp:BoundColumn>
								<asp:ButtonColumn Text="�T�w" ButtonType="PushButton" CommandName="Select"></asp:ButtonColumn>
							</Columns>
							<PagerStyle NextPageText="�U�@��" PrevPageText="�W�@��" HorizontalAlign="Right" Position="Top" CssClass="PagerStyle"></PagerStyle>
						</asp:datagrid></td>
				</tr>
			</table>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer></form>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="�T�w")
				event.returnValue=confirm("�T�w�n�^�_(Recovery)�����o�����?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
