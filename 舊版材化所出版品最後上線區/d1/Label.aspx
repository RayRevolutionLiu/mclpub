<%@ Page language="c#" Codebehind="Label.aspx.cs" src="Label.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d1.Labeltest" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Label" method="post" runat="server">
			<FONT face="新細明體">
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
						<asp:Label id="Label3" runat="server" Font-Names="新細明體">
							訂閱起迄：
								<%# DataBinder.Eval(Container.DataItem, "od_sdate") %>
								~<%# DataBinder.Eval(Container.DataItem, "od_edate") %>&nbsp;&nbsp;&nbsp;&nbsp; 
								份數：<%# DataBinder.Eval(Container.DataItem, "ra_mnt") %>
						</asp:Label>
						<BR>
						&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Label id="Label6" runat="server" Font-Names="新細明體">
								訂戶編號： <%# DataBinder.Eval(Container.DataItem, "od_syscd") %><%# DataBinder.Eval(Container.DataItem, "od_custno") %><%# DataBinder.Eval(Container.DataItem, "od_otp1cd") %><%# DataBinder.Eval(Container.DataItem, "od_otp1seq") %>&nbsp;&nbsp;(<%# DataBinder.Eval(Container.DataItem, "otp_otp2nm") %>)&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "mtp_nm") %>
							</asp:Label>
						<BR>
						&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:Label id="Label4" runat="server" Font-Names="新細明體">
							<%# DataBinder.Eval(Container.DataItem, "obtp_obtpnm") %>
						</asp:Label>
						&nbsp;&nbsp;
						<asp:Label id="lblBookNo1" runat="server"></asp:Label>
						<BR>
						<asp:Label id="pagevalue1" runat="server" Font-Size="5pt" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>'></asp:Label>
						<br>
					</ItemTemplate>
				</asp:datalist>
				<asp:datalist id="DataList2" runat="server" RepeatColumns="2" ShowHeader="False" ShowFooter="False" Width="100%" CellPadding="5" RepeatDirection="Horizontal">
					<ItemStyle Font-Size="X-Small" Height="144pt" Width="55%"></ItemStyle>
					<ItemTemplate>
						<asp:Label id="Label10" runat="server" Font-Names="新細明體" Font-Size="10pt">
							<%# DataBinder.Eval(Container.DataItem, "or_nm") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "or_jbti") %>
						</asp:Label>
						<BR>
						<asp:Label id="Label9" runat="server" Font-Names="新細明體" Font-Size="10pt">
							<%# DataBinder.Eval(Container.DataItem, "or_inm") %>
						</asp:Label>
						<BR>
						<asp:Label id="lbl_addr" runat="server" Font-Size="10pt" Font-Bold="True" Width="300">
							<%# DataBinder.Eval(Container.DataItem, "or_addr") %>
						</asp:Label>
						<BR>
						<BR>
						&nbsp;&nbsp;
						<asp:Label id="Label11" runat="server" Font-Names="新細明體">
								訂閱起迄： <%# DataBinder.Eval(Container.DataItem, "od_sdate") %>~<%# DataBinder.Eval(Container.DataItem, "od_edate") %>&nbsp;&nbsp;&nbsp;&nbsp;
								份數：<%# DataBinder.Eval(Container.DataItem, "ra_mnt") %>
							</asp:Label>
						<BR>
						&nbsp;&nbsp;
						<asp:Label id="Label12" runat="server" Font-Names="新細明體">
								訂戶編號： <%# DataBinder.Eval(Container.DataItem, "od_syscd") %><%# DataBinder.Eval(Container.DataItem, "od_custno") %><%# DataBinder.Eval(Container.DataItem, "od_otp1cd") %><%# DataBinder.Eval(Container.DataItem, "od_otp1seq") %>&nbsp;&nbsp;(<%# DataBinder.Eval(Container.DataItem, "otp_otp2nm") %>)&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "mtp_nm") %>
							</asp:Label>
						<BR>
						&nbsp;&nbsp;
						<asp:Label id="Label13" runat="server" Font-Names="新細明體">
							<%# DataBinder.Eval(Container.DataItem, "obtp_obtpnm") %>
						</asp:Label>
						&nbsp;&nbsp;
						<asp:Label id="lblBookNo2" runat="server"></asp:Label>
						<BR>
						<asp:Label id="pagevalue2" runat="server" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>' Font-Size="5pt"></asp:Label>
					</ItemTemplate>
				</asp:datalist>
			</FONT>
		</form>
	</body>
</HTML>
