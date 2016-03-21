<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="lost_label.aspx.cs" Inherits="mclpub.LabelArea.lost_label" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="lost_label" method="post" runat="server">
			<asp:datalist id="DataList1" runat="server" RepeatColumns="2" BorderColor="Black" ShowHeader="False" ShowFooter="False" Width="100%" CellPadding="0" RepeatDirection="Horizontal" BorderWidth="0px">
				<ItemStyle Font-Size="X-Small" Height="95pt" Width="55%"></ItemStyle>
				<ItemTemplate>
                <table>
                    <tr>
                        <td>
					<asp:Label id="lblZip" runat="server" Font-Bold="True" Font-Size="11">
							<%# DataBinder.Eval(Container.DataItem, "or_zip") %>
								&nbsp;&nbsp;
						</asp:Label></td>
				        <td><asp:Label id="lblAddr" runat="server" Width="300" Font-Bold="True" Font-Size="10">
						<%# DataBinder.Eval(Container.DataItem, "or_addr") %>
					</asp:Label></td>
                    </tr>
                </table>
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
								訂戶編號： <%# DataBinder.Eval(Container.DataItem, "lst_syscd") %><%# DataBinder.Eval(Container.DataItem, "lst_custno") %><%# DataBinder.Eval(Container.DataItem, "lst_otp1cd") %><%# DataBinder.Eval(Container.DataItem, "lst_otp1seq") %>
							</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label4" runat="server" Font-Names="新細明體" Width="300">
						缺書補發： <%# DataBinder.Eval(Container.DataItem, "lst_date") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "lst_cont") %>
					</asp:Label>
					<br>
					&nbsp;&nbsp;
					<asp:Label id="pagevalue1" runat="server" Font-Size="5pt" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>'></asp:Label>
					<br>
				</ItemTemplate>
			</asp:datalist>
			<asp:datalist id="DataList2" runat="server" RepeatColumns="2" BorderColor="Black" ShowHeader="False" ShowFooter="False" Width="100%" CellPadding="0" RepeatDirection="Horizontal" BorderWidth="0px">
				<ItemStyle Font-Size="X-Small" Height="130pt" Width="55%"></ItemStyle>
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
								訂戶編號： <%# DataBinder.Eval(Container.DataItem, "lst_syscd") %><%# DataBinder.Eval(Container.DataItem, "lst_custno") %><%# DataBinder.Eval(Container.DataItem, "lst_otp1cd") %><%# DataBinder.Eval(Container.DataItem, "lst_otp1seq") %>
							</asp:Label>
					<BR>
					&nbsp;&nbsp;&nbsp;&nbsp;
					<asp:Label id="Label10" runat="server" Font-Names="新細明體" Width="300">
						缺書補發： <%# DataBinder.Eval(Container.DataItem, "lst_date") %>&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "lst_cont") %>
					</asp:Label>
					<br>
					&nbsp;&nbsp;
					<asp:Label id="Label11" runat="server" Font-Size="5pt" Text='<%# DataBinder.Eval(Container, "ItemIndex", "{0}") %>'></asp:Label>
					<br>
				</ItemTemplate>
			</asp:datalist>
		</form>
	</body>
</html>
