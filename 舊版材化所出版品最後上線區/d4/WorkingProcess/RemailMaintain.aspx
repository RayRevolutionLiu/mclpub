<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<%@ Page language="c#" Codebehind="RemailMaintain.aspx.cs" Src="RemailMaintain.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.RemailMaintain" %>
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
		<form id="RemailMaintain" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<table id="tblX" border="0" width="100%">
				<tr>
					<td align="middle">
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�ɮѳB�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�ɮѭק�</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td align="middle">
						<TABLE style="WIDTH: 604px" cellSpacing="0" cellPadding="2" class="TableColor">
							<tr class="TableColorHeader">
								<td style="WIDTH: 550px" colSpan="4">�Ȥ���
								</td>
							</tr>
							<TR>
								<TD style="WIDTH: 104px" align="right">�X���s���G
								</TD>
								<td colSpan="3"><asp:textbox id="tbxContNo" runat="server" MaxLength="6" Width="100px"></asp:textbox></td>
							</TR>
							<TR>
								<TD style="WIDTH: 104px" align="right">���q�W�١G
								</TD>
								<td style="WIDTH: 232px"><asp:textbox id="tbxMfrNm" runat="server" Width="204px"></asp:textbox></td>
								<TD style="WIDTH: 78px" align="right">�Τ@�s���G
								</TD>
								<td><asp:textbox id="tbxMfrNo" runat="server" MaxLength="10" Width="99px"></asp:textbox></td>
							</TR>
							<TR>
								<TD style="WIDTH: 104px" align="right">�Ȥ�s���G
								</TD>
								<td style="WIDTH: 232px"><asp:textbox id="tbxCustNo" runat="server" MaxLength="6" Width="52px"></asp:textbox></td>
								<TD style="WIDTH: 78px" align="right">�Ȥ�m�W�G
								</TD>
								<td><asp:textbox id="tbxCustName" runat="server" Width="99px"></asp:textbox></td>
							</TR>
							<TR>
								<TD style="WIDTH: 104px" align="right">ñ������G
								</TD>
								<td colSpan="3"><asp:textbox id="tbxSSDate" runat="server" MaxLength="10" Width="82px"></asp:textbox><IMG class="ico" title="���" onclick='javascript:pick_date_single(tbxSSDate.name)' src="../../images/calendar01.gif">
									��<asp:textbox id="tbxSEDate" runat="server" MaxLength="10" Width="84px"></asp:textbox><IMG class="ico" title="���" onclick='javascript:pick_date_single(tbxSEDate.name)' src="../../images/calendar01.gif">
								</td>
							</TR>
							<tr class="TableColorHeader">
								<td style="WIDTH: 550px" colSpan="4">���x����H���
								</td>
							</tr>
							<TR>
								<TD style="WIDTH: 104px" align="right">����H�m�W�G
								</TD>
								<td style="WIDTH: 232px"><asp:textbox id="tbxOrName" runat="server" Width="99px"></asp:textbox></td>
								<TD style="WIDTH: 78px" align="right">����H�q�ܡG
								</TD>
								<td><asp:textbox id="tbxOrTel" runat="server" Width="99px"></asp:textbox></td>
							</TR>
							<TR>
								<TD style="WIDTH: 104px" align="right">����H�a�}�G
								</TD>
								<td colSpan="3"><asp:textbox id="tbxOrAddr" runat="server" Width="431px"></asp:textbox></td>
							</TR>
							<TR>
								<TD style="WIDTH: 104px" align="right">�H�Ѫ��A�G
								</TD>
								<td colSpan="3"><asp:radiobuttonlist id="rblSent" runat="server" RepeatDirection="Horizontal">
										<asp:ListItem Value="0" Selected="True">���H�X</asp:ListItem>
										<asp:ListItem Value="1">�w�H�X</asp:ListItem>
									</asp:radiobuttonlist></td>
							</TR>
						</TABLE>
						<asp:linkbutton id="lnbSearch" runat="server">�d��</asp:linkbutton>
						<DIV align="center"><asp:datagrid id="dgdRemail" runat="server" CellPadding="4" BackColor="White" BorderWidth="1px" BorderStyle="None" AutoGenerateColumns="False">
								<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
								<EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
								<AlternatingItemStyle CssClass="AlteringItemStyle"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemStyle"></ItemStyle>
								<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
								<FooterStyle CssClass="FooterStyle"></FooterStyle>
								<Columns>
									<asp:ButtonColumn Text="�R��" ButtonType="PushButton" CommandName="Delete"></asp:ButtonColumn>
									<asp:BoundColumn DataField="cont_contno" ReadOnly="True" HeaderText="�X���s��">
										<ItemStyle Wrap="False"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="cont_conttp" ReadOnly="True" HeaderText="�X�����O"></asp:BoundColumn>
									<asp:BoundColumn DataField="mfr_inm" ReadOnly="True" HeaderText="���q�W��"></asp:BoundColumn>
									<asp:BoundColumn DataField="cust_nm" ReadOnly="True" HeaderText="�q��m�W">
										<ItemStyle Wrap="False"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="rm_oritem" ReadOnly="True" HeaderText="����H�Ǹ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="or_nm" ReadOnly="True" HeaderText="����H"></asp:BoundColumn>
									<asp:BoundColumn DataField="rm_seq" ReadOnly="True" HeaderText="�ɮѧǸ�"></asp:BoundColumn>
									<asp:BoundColumn DataField="rm_cont" HeaderText="�ɮѤ��e"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="�ɮѵ��O">
										<ItemTemplate>
											<asp:Label id=lblFgSent runat="server" Text='<%# GetFgSentName(DataBinder.Eval(Container.DataItem, "rm_fgsent")) %>'>
											</asp:Label>
										</ItemTemplate>
										<EditItemTemplate>
											<asp:DropDownList id=ddlFgSent runat="server" SelectedIndex='<%# GetSelectedIndex(DataBinder.Eval(Container.DataItem, "rm_fgsent")) %>'>
												<asp:ListItem Value="Y" Selected="True">�i�H�X</asp:ListItem>
												<asp:ListItem Value="N">�ثe���H�X</asp:ListItem>
												<asp:ListItem Value="C">�w�H�X</asp:ListItem>
												<asp:ListItem Value="D">*���B�z*</asp:ListItem>
											</asp:DropDownList>
										</EditItemTemplate>
									</asp:TemplateColumn>
									<asp:EditCommandColumn ButtonType="PushButton" UpdateText="�x�s" CancelText="����" EditText="�ק�"></asp:EditCommandColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Left" CssClass="PagerStyle" Mode="NumericPages"></PagerStyle>
							</asp:datagrid><FONT face="�s�ө���"><BR>
							</FONT>
							<asp:label id="lblMessage" runat="server" Visible="False" CssClass="ImportantLabel"></asp:label></DIV>
					</td>
				</tr>
			</table>
		</form>
		<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer></FORM>
		<script language="javascript">
		function delete_confirm(e){
			if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="�R��")
				event.returnValue=confirm("�T�w�n�R�������ɮѸ��?");
		}
		document.onclick=delete_confirm;
		</script>
	</body>
</HTML>
