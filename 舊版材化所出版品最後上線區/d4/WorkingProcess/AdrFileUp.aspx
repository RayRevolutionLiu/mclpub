<%@ Page language="c#" Codebehind="AdrFileUp.aspx.cs" Src="AdrFileUp.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.WorkingProcess.AdrFileUp" %>
<%@ Register TagPrefix="kw" TagName="footer" Src="~/UserControl/footer.ascx" %>
<%@ Register TagPrefix="kw" TagName="header" Src="~/UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>���ƩҥX���~�Ȥ�޲z�t��</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="AdrFileUp" method="post" runat="server">
			<!-- ���� Header --><kw:header id="Header" runat="server"></kw:header>
			<TABLE id="tblX" cellSpacing="0" cellPadding="0" width="95%" align="center">
				<tr>
					<td>
						<TABLE id="tbItems">
							<TR>
								<TD style="WIDTH: 100%" align="left"><FONT color="#333333" size="2"><IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;�����s�i���t�� <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										�s�i�����B�z <IMG height="10" src="../../images/header/right02.gif" width="10" border="0">
										&nbsp;���s�W�Z</FONT>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD>
						<TABLE class="TableColor" id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader" style="HEIGHT: 24px" colSpan="11">�X���򥻸��</TD>
							</TR>
							<tr>
								<td>
									<TABLE class="TableColor" id="Table14" cellSpacing="0" cellPadding="2" width="100%" border="1">
										<TR class="TableColor">
											<TD>�X���s��</TD>
											<TD>�X�����O</TD>
											<TD>ñ�����</TD>
											<TD>�X���_��</TD>
											<TD>�Z�n����</TD>
											<TD>�ذe����</TD>
											<TD>�X�����B</TD>
											<TD>�u�f���</TD>
											<TD>�`�s���ɽZ����</TD>
											<TD>�`�s�����Z����</TD>
										</TR>
										<TR>
											<TD bgColor="#ecebff"><asp:label id="lblContNo" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblContTp" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblSignDate" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblSDate" runat="server" CssClass="NormalLabel"></asp:label>��<asp:label id="lblEDate" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblPubTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblFreeTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblTotAmt" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblDisc" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblTotImgTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
											<TD bgColor="#ecebff"><asp:label id="lblTotUrlTm" runat="server" CssClass="NormalLabel"></asp:label></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</TABLE>
						<TABLE class="TableColor" id="Table3" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader" colspan="2">���s�W�Z</TD>
							</TR>
							<TR>
								<TD width="60%">
									<TABLE class="TableColor" id="Table31" cellSpacing="0" cellPadding="2" width="100%" border="0">
										<tr>
											<td colspan="2">
												<A class="HylerLinkStyle" href="AdrImages.aspx" target="_blank">�{���s�i����</A>&nbsp;&nbsp;&nbsp;<A class="HylerLinkStyle" href="AdrUpload.aspx" target="_blank">�W�Ǽs�i����</A>
												<asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label>
											</td>
										</tr>
										<TR>
											<TD align="right">
												<asp:CheckBox id="cbxImage" runat="server" Text="���ɡG"></asp:CheckBox>
											</TD>
											<td>
												<asp:DropDownList id="ddlImages" runat="server"></asp:DropDownList>
												<asp:Button id="btnRefresh" runat="server" Text="��s���ɸ��"></asp:Button>
											</td>
										</TR>
										<TR>
											<TD align="right">
												<asp:CheckBox id="cbxLink" runat="server" Text="�����s���G"></asp:CheckBox>
											</TD>
											<td><asp:TextBox id="tbxNavUrl" runat="server"></asp:TextBox>
											</td>
										</TR>
										<TR>
											<TD align="right">
												<asp:CheckBox id="cbxAltText" runat="server" Text="�s�i�лy�G"></asp:CheckBox>
											</TD>
											<td><asp:TextBox id="tbxAltText" runat="server"></asp:TextBox>
											</td>
										</TR>
										<TR>
											<TD align="right">
												<asp:Label id="lblType1" runat="server">�W�Z�覡 1�G</asp:Label>
											</TD>
											<td><asp:textbox id="tbxSDate" runat="server" Width="100px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxSDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">��
												<asp:textbox id="tbxEDate" runat="server" Width="100px"></asp:textbox><IMG onclick='javascript:pick_date_single("tbxEDate");return false;' alt="" src="../../images/calendar01.gif" name="imgSignDate">
												<asp:Button id="btnDateSetImage" runat="server" Text="����϶��W�Z"></asp:Button>
											</td>
										</TR>
										<TR>
											<TD align="right">
												<asp:Label id="Label1" runat="server">�W�Z�覡 2�G</asp:Label>
											</TD>
											<td><asp:Button id="btnSetImage" runat="server" Text="�Ŀﶵ�ؤW�Z"></asp:Button>
											</td>
										</TR>
									</TABLE>
								</TD>
								<td>
									<asp:Label id="lblInfo" runat="server" ForeColor="#C00000" Font-Size="X-Small">
									�ϥλ����G<br>1.�Q�Ρi�{���s�i���ɡj���d�ߩһݹ��ɬO�_�w�s�b<br>
									2.�p���s����, �ЧQ�Ρi�W�Ǽs�i���ɡj�N���ɤW��<br>
									3.�Q�Ρi��s���ɸ�ơj�N�W�ǹ��ɸ��J�U�Ԧ���椤<br>
									4.��ܹ��ɤο�J�����s�����<br>
									5.�Q�Ρi����϶��W�Z�j�覡�i�@���N���϶����Ҧ���ƤW�Z<br>
									6.�Q�Ρi�Ŀﶵ�ؤW�Z�j�覡�i�H�N�D����W�Z�����
									</asp:Label>
								</td>
							</TR>
						</TABLE>
						<TABLE class="TableColor" id="Table5" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD class="TableColorHeader">�s�i�������</TD>
							</TR>
							<TR>
								<TD>
									<asp:panel id="pnlAdr" runat="server" Width="100%">
										<asp:button id="btnSelAll" runat="server" Text="����"></asp:button>
										<asp:button id="btnDeSelAll" runat="server" Text="�M��"></asp:button>
										<asp:datagrid id="dgdAdr" runat="server" CssClass="DataGridStyle" AutoGenerateColumns="False">
											<SelectedItemStyle CssClass="SelectedItemStyle"></SelectedItemStyle>
											<EditItemStyle CssClass="EditItemStyle"></EditItemStyle>
											<AlternatingItemStyle CssClass="AlternatingItemStyle"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemStyle"></ItemStyle>
											<HeaderStyle CssClass="HeaderStyle"></HeaderStyle>
											<Columns>
												<asp:TemplateColumn HeaderText="�D��">
													<ItemTemplate>
														<asp:CheckBox id="cbxSel" runat="server"></asp:CheckBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="��s" CancelText="����" EditText="�ק�"></asp:EditCommandColumn>
												<asp:BoundColumn DataField="adr_seq" ReadOnly="True" HeaderText="�Ǹ�">
													<HeaderStyle Width="25px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="adr_addate" ReadOnly="True" HeaderText="���X���">
													<HeaderStyle Width="60px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="adr_alttext" HeaderText="�s�i�лy">
													<HeaderStyle Width="100px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="adr_adcate" ReadOnly="True" HeaderText="�s�i����"></asp:BoundColumn>
												<asp:BoundColumn DataField="adr_keyword" ReadOnly="True" HeaderText="�s�i��m"></asp:BoundColumn>
												<asp:BoundColumn DataField="adr_navurl" HeaderText="�s�i�s��">
													<HeaderStyle Width="100px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="adr_impr" ReadOnly="True" HeaderText="������v">
													<HeaderStyle Width="25px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="adr_remark" HeaderText="�Ƶ�">
													<HeaderStyle Width="100px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="�s�i����">
													<ItemTemplate>
														<asp:Label id=lblImgUrl runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "adr_imgurl") %>'>
														</asp:Label>
													</ItemTemplate>
													<EditItemTemplate>
														<asp:DropDownList id="ddlImgUrl" runat="server"></asp:DropDownList>
													</EditItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="���ɽZ���O">
													<ItemTemplate>
														<asp:Label id=lblDraftTp runat="server" Text='<%# GetDraftTpNm(DataBinder.Eval(Container.DataItem, "adr_drafttp")) %>'>
														</asp:Label>
													</ItemTemplate>
													<EditItemTemplate>
														<asp:DropDownList id="ddlDraftTp" runat="server">
															<asp:ListItem Value="1">�½Z</asp:ListItem>
															<asp:ListItem Value="2">�s�Z</asp:ListItem>
															<asp:ListItem Value="3">��Z</asp:ListItem>
														</asp:DropDownList>
													</EditItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="�����Z���O">
													<ItemTemplate>
														<asp:Label id=lblUrlTp runat="server" Text='<%# GetUrlTpNm(DataBinder.Eval(Container.DataItem, "adr_urltp")) %>'>
														</asp:Label>
													</ItemTemplate>
													<EditItemTemplate>
														<asp:DropDownList id="ddlUrlTp" runat="server">
															<asp:ListItem Value="1">�½Z</asp:ListItem>
															<asp:ListItem Value="2">�s�Z</asp:ListItem>
															<asp:ListItem Value="3">��Z</asp:ListItem>
														</asp:DropDownList>
													</EditItemTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn Visible="False" DataField="adr_adcate" ReadOnly="True" HeaderText="adr_adcate">
													<HeaderStyle Width="50px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="adr_keyword" ReadOnly="True" HeaderText="adr_keyword">
													<HeaderStyle Width="50px"></HeaderStyle>
												</asp:BoundColumn>
											</Columns>
										</asp:datagrid>
									</asp:panel>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<!-- ���� Footer --><kw:footer id="Footer" runat="server"></kw:footer>
		</form>
	</body>
</HTML>
