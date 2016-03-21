<%@ Page language="c#" Codebehind="remail_label.aspx.cs" src="remail_label.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.remail_label" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="remail_label" method="post" runat="server">
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
					<asp:Label id="Label2" runat="server" Font-Names="新細明體">
						<%# DataBinder.Eval(Container.DataItem, "or_inm") %>
					</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label1" runat="server" Font-Names="新細明體">
								<%# DataBinder.Eval(Container.DataItem, "or_nm") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "or_jbti") %>
							</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label6" runat="server" Font-Names="新細明體">
								訂戶編號： <%# DataBinder.Eval(Container.DataItem, "rm_syscd") %><%# DataBinder.Eval(Container.DataItem, "rm_custno") %><%# DataBinder.Eval(Container.DataItem, "rm_otp1cd") %><%# DataBinder.Eval(Container.DataItem, "rm_otp1seq") %>
							</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label4" runat="server" Font-Names="新細明體" Width="300">
						補書內容： <%# DataBinder.Eval(Container.DataItem, "rm_date") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "rm_cont") %>
					</asp:Label>
					<br>
					&nbsp;&nbsp;
					<asp:Label id="pagevalue1" runat="server" Font-Size="5pt" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>'></asp:Label>
					<br>
				</ItemTemplate>
			</asp:datalist>
			<asp:datalist id="DataList2" runat="server" RepeatColumns="2" BorderColor="Black" ShowHeader="False" ShowFooter="False" Width="100%" CellPadding="0" RepeatDirection="Horizontal" BorderWidth="0px">
				<ItemStyle Font-Size="X-Small" Height="144pt" Width="55%"></ItemStyle>
				<ItemTemplate>
					<asp:Label id="Label3" runat="server" Font-Bold="True" Font-Size="11">
							<%# DataBinder.Eval(Container.DataItem, "or_zip") %>
								&nbsp;&nbsp;
						</asp:Label>
					<asp:Label id="Label5" runat="server" Font-Bold="True" Font-Size="10" Width="300">
						<%# DataBinder.Eval(Container.DataItem, "or_addr") %>
					</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label7" runat="server" Font-Names="新細明體">
						<%# DataBinder.Eval(Container.DataItem, "or_inm") %>
					</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label8" runat="server" Font-Names="新細明體">
								<%# DataBinder.Eval(Container.DataItem, "or_nm") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "or_jbti") %>
							</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label9" runat="server" Font-Names="新細明體">
								訂戶編號： <%# DataBinder.Eval(Container.DataItem, "rm_syscd") %><%# DataBinder.Eval(Container.DataItem, "rm_custno") %><%# DataBinder.Eval(Container.DataItem, "rm_otp1cd") %><%# DataBinder.Eval(Container.DataItem, "rm_otp1seq") %>
							</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label10" runat="server" Font-Names="新細明體" Width="300">
						補書內容： <%# DataBinder.Eval(Container.DataItem, "rm_date") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "rm_cont") %>
					</asp:Label>
					<br>
					&nbsp;&nbsp;
					<asp:Label id="Label11" runat="server" Font-Size="5pt" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>'></asp:Label>
					<br>
				</ItemTemplate>
			</asp:datalist>
		</form>
	</body>
</HTML>
