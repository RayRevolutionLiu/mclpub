<%@ Page language="c#" Codebehind="AppriseLabel.aspx.cs" src="AppriseLabel.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.AppriseLabel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="AppriseLabel" method="post" runat="server">
			<asp:datalist id="DataList1" runat="server" RepeatColumns="2" BorderColor="Black" ShowHeader="False" ShowFooter="False" Width="100%" CellPadding="0" RepeatDirection="Horizontal" BorderWidth="0px">
				<ItemStyle Font-Size="X-Small" Height="108pt" Width="55%"></ItemStyle>
				<ItemTemplate>
					<asp:Label id="lblZip" runat="server" Font-Bold="True" Font-Size="11">
						<%# DataBinder.Eval(Container.DataItem, "or_zip") %>
						&nbsp;&nbsp;
						</asp:Label>
					<asp:Label id="lblAddr" runat="server" Font-Bold="True" Font-Size="10" Width="300">
						<%# DataBinder.Eval(Container.DataItem, "or_addr") %>
					</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label2" runat="server" Font-Names="�s�ө���">
						<%# DataBinder.Eval(Container.DataItem, "or_inm") %>
					</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label1" runat="server" Font-Names="�s�ө���">
								<%# DataBinder.Eval(Container.DataItem, "or_nm") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "or_jbti") %>
							</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label6" runat="server" Font-Names="�s�ө���">
								�q��s���G <%# DataBinder.Eval(Container.DataItem, "od_syscd") %><%# DataBinder.Eval(Container.DataItem, "od_custno") %><%# DataBinder.Eval(Container.DataItem, "od_otp1cd") %><%# DataBinder.Eval(Container.DataItem, "od_otp1seq") %>
							</asp:Label>
					<BR>
					<asp:Label id="lblMessage1" runat="server" Font-Names="�s�ө���" Font-Size="8">
					&nbsp;&nbsp;&nbsp;&nbsp;�ա���q�q���֡�
					<br>
						&nbsp;&nbsp;&nbsp;&nbsp;�z�q�\���y<%# DataBinder.Eval(Container.DataItem, "obtp_obtpnm") %>�z�b�y<%# DataBinder.Eval(Container.DataItem,  "od_edate") %>�z
					</asp:Label>
					<asp:Label id="lblMessage2" runat="server" Font-Names="�s�ө���" Font-Size="8">
						����A<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���W��q�A�i�ɦ��E���u�f�I�I
					</asp:Label>
					<BR>
					<asp:Label id="pagevalue1" runat="server" Font-Size="5pt" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>'></asp:Label>
					<br>
				</ItemTemplate>
			</asp:datalist>
			<asp:datalist id="DataList2" runat="server" RepeatColumns="2" BorderColor="Black" ShowHeader="False" ShowFooter="False" Width="100%" CellPadding="0" RepeatDirection="Horizontal" BorderWidth="0px">
				<ItemStyle Font-Size="X-Small" Height="108pt" Width="55%"></ItemStyle>
				<ItemTemplate>
					<asp:Label id="Label3" runat="server" Font-Bold="True" Font-Size="11">
						<%# DataBinder.Eval(Container.DataItem, "or_zip") %>
						&nbsp;&nbsp;
						</asp:Label>
					<asp:Label id="Label4" runat="server" Font-Bold="True" Font-Size="10" Width="300">
						<%# DataBinder.Eval(Container.DataItem, "or_addr") %>
					</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label5" runat="server" Font-Names="�s�ө���">
						<%# DataBinder.Eval(Container.DataItem, "or_inm") %>
					</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label7" runat="server" Font-Names="�s�ө���">
								<%# DataBinder.Eval(Container.DataItem, "or_nm") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "or_jbti") %>
							</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label8" runat="server" Font-Names="�s�ө���">
								�q��s���G <%# DataBinder.Eval(Container.DataItem, "od_syscd") %><%# DataBinder.Eval(Container.DataItem, "od_custno") %><%# DataBinder.Eval(Container.DataItem, "od_otp1cd") %><%# DataBinder.Eval(Container.DataItem, "od_otp1seq") %>
							</asp:Label>
					<BR>
					<asp:Label id="Label9" runat="server" Font-Names="�s�ө���" Font-Size="8">
					&nbsp;&nbsp;&nbsp;&nbsp;�ա���q�q���֡�
					<br>
						&nbsp;&nbsp;&nbsp;&nbsp;�z�q�\���y<%# DataBinder.Eval(Container.DataItem, "obtp_obtpnm") %>�z�b�y<%# DataBinder.Eval(Container.DataItem,  "od_edate") %>�z
					</asp:Label>
					<asp:Label id="Label10" runat="server" Font-Names="�s�ө���" Font-Size="8">
						�Y�N����A<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���W��q�A�i�ɦ��E���u�f�I�I
					</asp:Label>
					<BR>
					<asp:Label id="Label11" runat="server" Font-Size="5pt" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>'></asp:Label>
					<br>
				</ItemTemplate>
			</asp:datalist>
			<asp:datalist id="DataList3" runat="server" RepeatColumns="2" BorderColor="Black" ShowHeader="False" ShowFooter="False" Width="100%" CellPadding="0" RepeatDirection="Horizontal" BorderWidth="0px">
				<ItemStyle Font-Size="X-Small" Height="144pt" Width="55%"></ItemStyle>
				<ItemTemplate>
					<asp:Label id="Label12" runat="server" Font-Bold="True" Font-Size="11">
						<%# DataBinder.Eval(Container.DataItem, "or_zip") %>
						&nbsp;&nbsp;
						</asp:Label>
					<asp:Label id="Label13" runat="server" Font-Bold="True" Font-Size="10" Width="300">
						<%# DataBinder.Eval(Container.DataItem, "or_addr") %>
					</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label14" runat="server" Font-Names="�s�ө���">
						<%# DataBinder.Eval(Container.DataItem, "or_inm") %>
					</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label15" runat="server" Font-Names="�s�ө���">
								<%# DataBinder.Eval(Container.DataItem, "or_nm") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "or_jbti") %>
							</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label16" runat="server" Font-Names="�s�ө���">
								�q��s���G <%# DataBinder.Eval(Container.DataItem, "od_syscd") %><%# DataBinder.Eval(Container.DataItem, "od_custno") %><%# DataBinder.Eval(Container.DataItem, "od_otp1cd") %><%# DataBinder.Eval(Container.DataItem, "od_otp1seq") %>
							</asp:Label>
					<BR>
					<asp:Label id="Label17" runat="server" Font-Names="�s�ө���" Font-Size="8">
					&nbsp;&nbsp;&nbsp;&nbsp;�ա���q�q���֡�
					<br>
						&nbsp;&nbsp;&nbsp;&nbsp;�z�q�\���y<%# DataBinder.Eval(Container.DataItem, "obtp_obtpnm") %>�z�b�y<%# DataBinder.Eval(Container.DataItem,  "od_edate") %>�z
					</asp:Label>
					<asp:Label id="Label18" runat="server" Font-Names="�s�ө���" Font-Size="8">
						����A<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���W��q�A�i�ɦ��E���u�f�I�I
					</asp:Label>
					<BR>
					<asp:Label id="Label19" runat="server" Font-Size="5pt" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>'></asp:Label>
					<br>
				</ItemTemplate>
			</asp:datalist>
			<asp:datalist id="DataList4" runat="server" RepeatColumns="2" BorderColor="Black" ShowHeader="False" ShowFooter="False" Width="100%" CellPadding="0" RepeatDirection="Horizontal" BorderWidth="0px">
				<ItemStyle Font-Size="X-Small" Height="144pt" Width="55%"></ItemStyle>
				<ItemTemplate>
					<asp:Label id="Label20" runat="server" Font-Bold="True" Font-Size="11">
						<%# DataBinder.Eval(Container.DataItem, "or_zip") %>
						&nbsp;&nbsp;
						</asp:Label>
					<asp:Label id="Label21" runat="server" Font-Bold="True" Font-Size="10" Width="300">
						<%# DataBinder.Eval(Container.DataItem, "or_addr") %>
					</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label22" runat="server" Font-Names="�s�ө���">
						<%# DataBinder.Eval(Container.DataItem, "or_inm") %>
					</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label23" runat="server" Font-Names="�s�ө���">
								<%# DataBinder.Eval(Container.DataItem, "or_nm") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "or_jbti") %>
							</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label24" runat="server" Font-Names="�s�ө���">
								�q��s���G <%# DataBinder.Eval(Container.DataItem, "od_syscd") %><%# DataBinder.Eval(Container.DataItem, "od_custno") %><%# DataBinder.Eval(Container.DataItem, "od_otp1cd") %><%# DataBinder.Eval(Container.DataItem, "od_otp1seq") %>
							</asp:Label>
					<BR>
					<asp:Label id="Label25" runat="server" Font-Names="�s�ө���" Font-Size="8">
					&nbsp;&nbsp;&nbsp;&nbsp;�ա���q�q���֡�
					<br>
						&nbsp;&nbsp;&nbsp;&nbsp;�z�q�\���y<%# DataBinder.Eval(Container.DataItem, "obtp_obtpnm") %>�z�b�y<%# DataBinder.Eval(Container.DataItem,  "od_edate") %>�z
					</asp:Label>
					<asp:Label id="Label26" runat="server" Font-Names="�s�ө���" Font-Size="8">
						�Y�N����A<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;���W��q�A�i�ɦ��E���u�f�I�I
					</asp:Label>
					<BR>
					<asp:Label id="Label27" runat="server" Font-Size="5pt" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>'></asp:Label>
					<br>
				</ItemTemplate>
			</asp:datalist>
		</form>
	</body>
</HTML>
