<%@ Page Language="C#" Src="WebForm1.aspx.cs" AutoEventWireup="false" Inherits="WebProject1.WebForm1"%>
<%@ Register TagPrefix="kw" TagName="header" Src="../UserControl/header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="JScript">
	function Delete_confirm(e) {
		if(event.srcElement.type=="submit" && document.all(event.srcElement.name).value=="Delete")
			event.returnValue=confirm("�O�_�T�w�R��?")
	}
	document.onclick=Delete_confirm;
		</script>
	</HEAD>
	<body>
			<!-- ���� Header -->
		<kw:header id="Header" runat="server">
		</kw:header>
		<form id="WebForm1" method="post" runat="server">
			<P>
				<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
					<TR>
						<TD style="WIDTH: 437px" valign="top">
							<P>
								<asp:datagrid id="DataGrid1" runat="server" ForeColor="Navy" DataKeyField="ID" AllowPaging="True" GridLines="None" CellPadding="1" AutoGenerateColumns="False" BorderColor="White" CellSpacing="2" BorderStyle="None">
									<HeaderStyle HorizontalAlign="Center" Height="25px" ForeColor="White" BackColor="#FF4650"></HeaderStyle>
									<PagerStyle HorizontalAlign="Right" BackColor="#E0E0E0" Mode="NumericPages"></PagerStyle>
									<AlternatingItemStyle BackColor="#FFE8E9"></AlternatingItemStyle>
									<ItemStyle HorizontalAlign="Center" BackColor="#FFC8C9"></ItemStyle>
									<Columns>
										<asp:BoundColumn DataField="FName" HeaderText="FName">
											<HeaderStyle Width="90px">
											</HeaderStyle>
											<ItemStyle HorizontalAlign="Left">
											</ItemStyle>
										</asp:BoundColumn>
										<asp:BoundColumn DataField="LName" HeaderText="LName">
											<HeaderStyle Width="90px">
											</HeaderStyle>
											<ItemStyle HorizontalAlign="Left">
											</ItemStyle>
										</asp:BoundColumn>
										<asp:TemplateColumn HeaderText="Team">
											<HeaderStyle Width="75px">
											</HeaderStyle>
											<HeaderTemplate>
												<FONT face="�s�ө���"></FONT>
											</HeaderTemplate>
											<ItemTemplate>
												<FONT face="�s�ө���">
													<asp:Label id="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Team") %>'></asp:Label>
												</FONT>
											</ItemTemplate>
											<EditItemTemplate>
												<FONT face="�s�ө���">
													<asp:dropdownlist id="Team1" runat="server">
														<asp:ListItem Value="Alt">Alt</asp:ListItem>
														<asp:ListItem Value="Ana">Ana</asp:ListItem>
														<asp:ListItem Value="Ari">Ari</asp:ListItem>
														<asp:ListItem Value="Bal">Bal</asp:ListItem>
														<asp:ListItem Value="Bos">Bos</asp:ListItem>
														<asp:ListItem Value="Chc">Chc</asp:ListItem>
														<asp:ListItem Value="Chw">Chw</asp:ListItem>
														<asp:ListItem Value="Cin">Cin</asp:ListItem>
														<asp:ListItem Value="Cle">Cle</asp:ListItem>
														<asp:ListItem Value="Col">Col</asp:ListItem>
														<asp:ListItem Value="Det">Det</asp:ListItem>
														<asp:ListItem Value="Fla">Fla</asp:ListItem>
														<asp:ListItem Value="Hou">Hou</asp:ListItem>
														<asp:ListItem Value="KC">KC</asp:ListItem>
														<asp:ListItem Value="LA">LA</asp:ListItem>
														<asp:ListItem Value="Mil">Mil</asp:ListItem>
														<asp:ListItem Value="Min">Min</asp:ListItem>
														<asp:ListItem Value="Mon">Mon</asp:ListItem>
														<asp:ListItem Value="Nym">Nym</asp:ListItem>
														<asp:ListItem Value="Nyy">Nyy</asp:ListItem>
														<asp:ListItem Value="Oak">Oak</asp:ListItem>
														<asp:ListItem Value="Phi">Phi</asp:ListItem>
														<asp:ListItem Value="Pit">Pit</asp:ListItem>
														<asp:ListItem Value="SD">SD</asp:ListItem>
														<asp:ListItem Value="Sea">Sea</asp:ListItem>
														<asp:ListItem Value="SF">SF</asp:ListItem>
														<asp:ListItem Value="Stl">Stl</asp:ListItem>
														<asp:ListItem Value="TB">TB</asp:ListItem>
														<asp:ListItem Value="Tex">Tex</asp:ListItem>
														<asp:ListItem Value="Tor">Tor</asp:ListItem>
													</asp:dropdownlist>
												</FONT>
											</EditItemTemplate>
										</asp:TemplateColumn>
										<asp:ButtonColumn Text="Delete" ButtonType="PushButton" HeaderText="�R��" CommandName="Delete">
											<HeaderStyle Width="60px">
											</HeaderStyle>
											<ItemStyle HorizontalAlign="Center">
											</ItemStyle>
										</asp:ButtonColumn>
										<asp:EditCommandColumn ButtonType="PushButton" UpdateText="Update" HeaderText="�ק�" CancelText="Cancel" EditText="Edit">
											<HeaderStyle Width="60px">
											</HeaderStyle>
											<ItemStyle HorizontalAlign="Center">
											</ItemStyle>
										</asp:EditCommandColumn>
									</Columns>
								</asp:datagrid>
							</P>
						</TD>
						<TD valign="top">
							<TABLE id="AutoNumber1" borderColor="#111111" cellPadding="3" width="261" bgColor="lightcyan" border="0" cellSpacing="0">
								<TR>
									<TD align="middle" bgColor="#993300" colSpan="2" height="25">
										<FONT face="�s�ө���" color="#ffffff">��Ƭd��</FONT>
									</TD>
								</TR>
								<TR bgColor="#ffcc99" height="12">
									<TD align="middle" colSpan="2" height="12">
										<FONT face="�s�ө���"></FONT>
									</TD>
								</TR>
								<TR bgColor="#ffcc99">
									<TD align="middle" colSpan="2" height="25">
										<FONT face="�s�ө���">
											<asp:textbox id="QString" runat="server" Height="24px" Width="120px"></asp:textbox>
										</FONT>
									</TD>
								</TR>
								<TR>
									<TD align="middle" bgColor="#ffcc99" colSpan="2" height="25">
										<FONT face="�s�ө���">
											<asp:dropdownlist id="Search1" runat="server">
												<asp:ListItem Value="LName" Selected="True">LName</asp:ListItem>
												<asp:ListItem Value="Team">Team</asp:ListItem>
											</asp:dropdownlist>
										</FONT>
									</TD>
								</TR>
								<TR bgColor="#ffcc99">
									<TD align="middle" colSpan="2" height="45">
										<FONT face="�s�ө���">
											<asp:button id="Query" runat="server" Text="�}�l�j�M"></asp:button>
										</FONT>
									</TD>
								</TR>
								<TR>
									<TD align="middle" bgColor="#003399" colSpan="2" height="25">
										<FONT face="�s�ө���" color="#ffffff">�s�W�@�����</FONT>
									</TD>
								</TR>
								<TR height="12">
									<TD align="middle" colSpan="2" height="12">
										<FONT face="�s�ө���"></FONT>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 71px" align="right">
										<FONT face="�s�ө���">FName:</FONT>
									</TD>
									<TD>
										<FONT face="�s�ө���">
											<asp:textbox id="FName" runat="server" Height="24px" Width="120px"></asp:textbox>
											<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="FName" ErrorMessage="����J!"></asp:requiredfieldvalidator>
										</FONT>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 71px" align="right">
										<FONT face="�s�ө���">LName: </FONT>
									</TD>
									<TD>
										<asp:textbox id="LName" runat="server" Height="24px" Width="120px"></asp:textbox>
										<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="LName" ErrorMessage="����J!" DESIGNTIMEDRAGDROP="583"></asp:requiredfieldvalidator>
									</TD>
								</TR>
								<TR>
									<TD style="WIDTH: 71px; HEIGHT: 27px" align="right">
										<FONT face="�s�ө���">���ݲy��: </FONT>
									</TD>
									<TD style="HEIGHT: 27px">
										<asp:dropdownlist id="Team" runat="server">
											<asp:ListItem Value="Alt">Alt</asp:ListItem>
											<asp:ListItem Value="Ana">Ana</asp:ListItem>
											<asp:ListItem Value="Ari">Ari</asp:ListItem>
											<asp:ListItem Value="Bal">Bal</asp:ListItem>
											<asp:ListItem Value="Bos">Bos</asp:ListItem>
											<asp:ListItem Value="Chc">Chc</asp:ListItem>
											<asp:ListItem Value="Chw">Chw</asp:ListItem>
											<asp:ListItem Value="Cin">Cin</asp:ListItem>
											<asp:ListItem Value="Cle">Cle</asp:ListItem>
											<asp:ListItem Value="Col">Col</asp:ListItem>
											<asp:ListItem Value="Det">Det</asp:ListItem>
											<asp:ListItem Value="Fla">Fla</asp:ListItem>
											<asp:ListItem Value="Hou">Hou</asp:ListItem>
											<asp:ListItem Value="KC">KC</asp:ListItem>
											<asp:ListItem Value="LA">LA</asp:ListItem>
											<asp:ListItem Value="Mil">Mil</asp:ListItem>
											<asp:ListItem Value="Min">Min</asp:ListItem>
											<asp:ListItem Value="Mon">Mon</asp:ListItem>
											<asp:ListItem Value="Nym">Nym</asp:ListItem>
											<asp:ListItem Value="Nyy">Nyy</asp:ListItem>
											<asp:ListItem Value="Oak">Oak</asp:ListItem>
											<asp:ListItem Value="Phi">Phi</asp:ListItem>
											<asp:ListItem Value="Pit">Pit</asp:ListItem>
											<asp:ListItem Value="SD">SD</asp:ListItem>
											<asp:ListItem Value="Sea">Sea</asp:ListItem>
											<asp:ListItem Value="SF">SF</asp:ListItem>
											<asp:ListItem Value="Stl">Stl</asp:ListItem>
											<asp:ListItem Value="TB">TB</asp:ListItem>
											<asp:ListItem Value="Tex">Tex</asp:ListItem>
											<asp:ListItem Value="Tor">Tor</asp:ListItem>
										</asp:dropdownlist>
									</TD>
								</TR>
								<TR>
									<TD align="middle" colSpan="2" height="45">
										<FONT face="�s�ө���">
											<asp:button id="Button1" runat="server" Text="�T�w�s�W"></asp:button>
										</FONT>
									</TD>
								</TR>
								<TR bgColor="#009999" height="30">
									<TD align="middle" bgColor="#660099" colSpan="2" height="25">
										<FONT face="�s�ө���" color="#ffffff">�t��²�T</FONT>
									</TD>
								</TR>
								<TR bgColor="lavender">
									<TD align="middle" colSpan="2" height="45">
										<asp:label id="Label1" runat="server" ForeColor="DimGray">���ݤ�...</asp:label>
									</TD>
								</TR>
							</TABLE>
			</P>
			</TD> </TR> </TABLE> </P>
			<P>
			</P>
			<P>
			</P>
		</form>
	</body>
</HTML>
