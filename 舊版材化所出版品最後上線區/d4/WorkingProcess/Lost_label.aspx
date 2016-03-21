<%@ Page language="c#" Codebehind="Lost_label.aspx.cs" src="Lost_label.aspx.cs" AutoEventWireup="false" Inherits="MRLPub.d4.Lost_label" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Lost_label" method="post" runat="server">
			<asp:datalist id="DataList1" runat="server" RepeatColumns="2" BorderColor="Black" ShowHeader="False" ShowFooter="False" Width="100%" CellPadding="0" RepeatDirection="Horizontal" BorderWidth="0px">
				<ItemStyle Font-Size="X-Small" Height="108pt" Width="55%"></ItemStyle>
				<ItemTemplate>
					<asp:Label id="lblZip1" runat="server" Font-Bold="True" Font-Size="11">
							<%# DataBinder.Eval(Container.DataItem, "or_zip") %>
								&nbsp;&nbsp;
						</asp:Label>
					<asp:Label id="lblAddr1" runat="server" Font-Bold="True" Font-Size="10" Width="300">
						<%# DataBinder.Eval(Container.DataItem, "or_addr") %>
					</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblMfrIName1" runat="server" Font-Names="新細明體">
						<%# DataBinder.Eval(Container.DataItem, "or_inm") %>
					</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblORName1" runat="server" Font-Names="新細明體">
								<%# DataBinder.Eval(Container.DataItem, "or_nm") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "or_jbti") %>
							</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblContSEDate1" runat="server" Font-Names="新細明體">
							贈閱起迄：
								<%# DataBinder.Eval(Container.DataItem, "ma_sdate") %>~<%# DataBinder.Eval(Container.DataItem, "ma_edate") %></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblPubCnt1" runat="server" Font-Names="新細明體">有登/未登本數：<%# DataBinder.Eval(Container.DataItem, "ma_pubmnt") %>/<%# DataBinder.Eval(Container.DataItem, "ma_unpubmnt") %></asp:Label><BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="lblContNo1" runat="server" Font-Names="新細明體">
								合約編號： <%# DataBinder.Eval(Container.DataItem, "or_contno") %>&nbsp;&nbsp;(
<asp:Label id="lblConttp1" runat="server" Font-Names="新細明體">
							<%# DataBinder.Eval(Container.DataItem, "cont_conttpName") %>
						</asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "mtp_nm") %>
							</asp:Label><BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label4" runat="server" Font-Names="新細明體" Width="300">
						缺書內容： <%# DataBinder.Eval(Container.DataItem, "lst_cont") %>&nbsp;&nbsp;(<%# DataBinder.Eval(Container.DataItem, "lst_date") %>)
					</asp:Label>
					<br>
					&nbsp;&nbsp;
					<asp:Label id="pagevalue1" runat="server" Font-Size="5pt" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>'>
					</asp:Label>
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
					<asp:Label id="Label1" runat="server" Font-Names="新細明體">
							贈閱起迄：
								<%# DataBinder.Eval(Container.DataItem, "ma_sdate") %>~<%# DataBinder.Eval(Container.DataItem, "ma_edate") %></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label2" runat="server" Font-Names="新細明體">有登/未登本數：<%# DataBinder.Eval(Container.DataItem, "ma_pubmnt") %>/<%# DataBinder.Eval(Container.DataItem, "ma_unpubmnt") %></asp:Label><BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label6" runat="server" Font-Names="新細明體">
								合約編號： <%# DataBinder.Eval(Container.DataItem, "or_contno") %>&nbsp;&nbsp;(
<asp:Label id="Label9" runat="server" Font-Names="新細明體">
							<%# DataBinder.Eval(Container.DataItem, "cont_conttpName") %>
						</asp:Label>)&nbsp;&nbsp;&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "mtp_nm") %>
							</asp:Label><BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label10" runat="server" Font-Names="新細明體" Width="300">
						缺書內容： <%# DataBinder.Eval(Container.DataItem, "lst_cont") %>&nbsp;&nbsp;(<%# DataBinder.Eval(Container.DataItem, "lst_date") %>)
					</asp:Label>
					<br>
					&nbsp;&nbsp;
					<asp:Label id="Label11" runat="server" Font-Size="5pt" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>'>
					</asp:Label>
					<br>
				</ItemTemplate>
			</asp:datalist>
		</form>
	</body>
</HTML>
